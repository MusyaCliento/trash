using System;
using Pathfinding.Collections;
using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile(FloatMode = FloatMode.Fast, CompileSynchronously = true)]
	public struct JobCalculateGridConnections : IJobParallelForBatched
	{
		public float maxStepHeight;

		public float4x4 graphToWorld;

		public IntBounds bounds;

		public int3 arrayBounds;

		public NumNeighbours neighbours;

		public float characterHeight;

		public bool use2D;

		public bool cutCorners;

		public bool maxStepUsesSlope;

		public bool layeredDataLayout;

		[ReadOnly]
		public UnsafeSpan<bool> nodeWalkable;

		[ReadOnly]
		public UnsafeSpan<float4> nodeNormals;

		[ReadOnly]
		public UnsafeSpan<Vector3> nodePositions;

		[WriteOnly]
		public UnsafeSpan<ulong> nodeConnections;

		public bool allowBoundsChecks => false;

		public static bool IsValidConnection(float y, float y2, float maxStepHeight)
		{
			return math.abs(y - y2) <= maxStepHeight;
		}

		public static bool IsValidConnection(float2 yRange, float2 yRange2, float maxStepHeight, float characterHeight)
		{
			if (!IsValidConnection(yRange.x, yRange2.x, maxStepHeight))
			{
				return false;
			}
			float num = math.max(yRange.x, yRange2.x);
			return math.min(yRange.y, yRange2.y) - num >= characterHeight;
		}

		private static float ConnectionY(UnsafeSpan<float3> nodePositions, UnsafeSpan<float4> nodeNormals, NativeArray<float4> normalToHeightOffset, int nodeIndex, int dir, float4 up, bool reverse)
		{
			Hint.Assume(nodeIndex >= 0 && nodeIndex < nodePositions.length);
			Hint.Assume(nodeIndex >= 0 && nodeIndex < nodeNormals.length);
			Hint.Assume(dir >= 0 && dir < normalToHeightOffset.Length);
			float4 y = new float4(nodePositions[(uint)nodeIndex], 0f);
			return math.dot(up, y) + (float)((!reverse) ? 1 : (-1)) * math.dot(nodeNormals[nodeIndex], normalToHeightOffset[dir]);
		}

		private static float2 ConnectionYRange(UnsafeSpan<float3> nodePositions, UnsafeSpan<float4> nodeNormals, NativeArray<float4> normalToHeightOffset, int nodeIndex, int layerStride, int y, int maxY, int dir, float4 up, bool reverse)
		{
			float x = ConnectionY(nodePositions, nodeNormals, normalToHeightOffset, nodeIndex, dir, up, reverse);
			int num = nodeIndex + layerStride;
			float y2 = (((uint)num >= nodeNormals.length || !math.any(nodeNormals[(uint)num])) ? float.PositiveInfinity : ConnectionY(nodePositions, nodeNormals, normalToHeightOffset, num, dir, up, reverse));
			return new float2(x, y2);
		}

		private static NativeArray<float4> HeightOffsetProjections(float4x4 graphToWorldTranform, bool maxStepUsesSlope)
		{
			NativeArray<float4> result = new NativeArray<float4>(8, Allocator.Temp);
			if (maxStepUsesSlope)
			{
				for (int i = 0; i < result.Length; i++)
				{
					float3 xyz = GridGraph.neighbourXOffsets[i] * graphToWorldTranform.c0.xyz + GridGraph.neighbourZOffsets[i] * graphToWorldTranform.c2.xyz;
					result[i] = -new float4(xyz, 0f) * 0.5f;
				}
			}
			return result;
		}

		public void Execute(int start, int count)
		{
			if (nodePositions.Length != nodeNormals.Length)
			{
				throw new Exception("nodePositions and nodeNormals must have the same length");
			}
			if (nodePositions.Length != nodeWalkable.Length)
			{
				throw new Exception("nodePositions and nodeWalkable must have the same length");
			}
			if (nodePositions.Length != nodeConnections.Length)
			{
				throw new Exception("nodePositions and nodeConnections must have the same length");
			}
			if (layeredDataLayout)
			{
				ExecuteLayered(start, count);
			}
			else
			{
				ExecuteFlat(start, count);
			}
		}

		public void ExecuteFlat(int start, int count)
		{
			if (maxStepHeight <= 0f || use2D)
			{
				maxStepHeight = float.PositiveInfinity;
			}
			float4 c = graphToWorld.c1;
			NativeArray<int> nativeArray = new NativeArray<int>(8, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < 8; i++)
			{
				nativeArray[i] = GridGraph.neighbourZOffsets[i] * arrayBounds.x + GridGraph.neighbourXOffsets[i];
			}
			UnsafeSpan<float3> unsafeSpan = nodePositions.Reinterpret<float3>();
			NativeArray<float4> normalToHeightOffset = HeightOffsetProjections(graphToWorld, maxStepUsesSlope);
			start += bounds.min.z;
			for (int j = start; j < start + count; j++)
			{
				int num = 255;
				if (j == 0)
				{
					num &= -146;
				}
				if (j == arrayBounds.z - 1)
				{
					num &= -101;
				}
				for (int k = bounds.min.x; k < bounds.max.x; k++)
				{
					int num2 = j * arrayBounds.x + k;
					if (!nodeWalkable[num2])
					{
						nodeConnections[num2] = 0uL;
						continue;
					}
					int num3 = num;
					if (k == 0)
					{
						num3 &= -201;
					}
					if (k == arrayBounds.x - 1)
					{
						num3 &= -51;
					}
					for (int l = 0; l < 8; l++)
					{
						float y = ConnectionY(unsafeSpan, nodeNormals, normalToHeightOffset, num2, l, c, reverse: false);
						int num4 = num2 + nativeArray[l];
						if ((num3 & (1 << l)) != 0)
						{
							float y2 = ConnectionY(unsafeSpan, nodeNormals, normalToHeightOffset, num4, l, c, reverse: true);
							if (!nodeWalkable[num4] || !IsValidConnection(y, y2, maxStepHeight))
							{
								num3 &= ~(1 << l);
							}
						}
					}
					nodeConnections[num2] = (ulong)GridNode.FilterDiagonalConnections(num3, neighbours, cutCorners);
				}
			}
		}

		public void ExecuteLayered(int start, int count)
		{
			if (maxStepHeight <= 0f || use2D)
			{
				maxStepHeight = float.PositiveInfinity;
			}
			float4 c = graphToWorld.c1;
			NativeArray<int> nativeArray = new NativeArray<int>(8, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < 8; i++)
			{
				nativeArray[i] = GridGraph.neighbourZOffsets[i] * arrayBounds.x + GridGraph.neighbourXOffsets[i];
			}
			UnsafeSpan<float3> unsafeSpan = nodePositions.Reinterpret<float3>();
			NativeArray<float4> normalToHeightOffset = HeightOffsetProjections(graphToWorld, maxStepUsesSlope);
			int num = arrayBounds.z * arrayBounds.x;
			start += bounds.min.z;
			for (int j = bounds.min.y; j < bounds.max.y; j++)
			{
				for (int k = start; k < start + count; k++)
				{
					for (int l = bounds.min.x; l < bounds.max.x; l++)
					{
						ulong num2 = 0uL;
						int num3 = k * arrayBounds.x + l;
						int num4 = num3 + j * num;
						if (nodeWalkable[num4])
						{
							for (int m = 0; m < 8; m++)
							{
								int num5 = l + GridGraph.neighbourXOffsets[m];
								int num6 = k + GridGraph.neighbourZOffsets[m];
								int num7 = 15;
								if (num5 >= 0 && num6 >= 0 && num5 < arrayBounds.x && num6 < arrayBounds.z)
								{
									float2 yRange = ConnectionYRange(unsafeSpan, nodeNormals, normalToHeightOffset, num4, num, j, arrayBounds.y, m, c, reverse: false);
									int num8 = num3 + nativeArray[m];
									for (int n = 0; n < arrayBounds.y; n++)
									{
										int num9 = num8 + n * num;
										if (nodeWalkable[num9])
										{
											float2 yRange2 = ConnectionYRange(unsafeSpan, nodeNormals, normalToHeightOffset, num9, num, n, arrayBounds.y, m, c, reverse: true);
											if (IsValidConnection(yRange, yRange2, maxStepHeight, characterHeight))
											{
												num7 = n;
												break;
											}
										}
									}
								}
								num2 |= (ulong)((long)num7 << 4 * m);
							}
						}
						else
						{
							num2 = 4294967295uL;
						}
						nodeConnections[num4] = num2;
					}
				}
			}
		}
	}
}
