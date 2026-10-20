using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Clipper2Lib;
using Pathfinding.Collections;
using Pathfinding.Graphs.Navmesh.Voxelization;
using Pathfinding.Pooling;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using andywiecko.BurstTriangulator;
using andywiecko.BurstTriangulator.LowLevel.Unsafe;

namespace Pathfinding.Graphs.Navmesh
{
	[BurstCompile]
	public static class TileHandler
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate bool CutFunction(ref UnsafeSpan<Point64Wrapper> subject, ref UnsafeSpan<Point64Wrapper> contourVertices, ref UnsafeSpan<NavmeshCut.ContourBurst> contours, ref UnsafeSpan<int> contourIndices, ref UnsafeSpan<int> contourIndicesDual, ref UnsafeList<Vector2Int> outputVertices, ref UnsafeList<int> outputVertexCountPerPolygon, int dual);

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct CutFunctionKey
		{
		}

		internal struct TileCuts
		{
			public int contourStartIndex;

			public int contourEndIndex;
		}

		internal struct ContourMeta
		{
			public bool isDual;

			public bool cutsAddedGeom;
		}

		internal struct CutCollection : IDisposable
		{
			public UnsafeList<float2> contourVertices;

			public UnsafeList<NavmeshCut.ContourBurst> contours;

			public UnsafeList<ContourMeta> contoursExtra;

			public UnsafeList<TileCuts> tileCuts;

			[MarshalAs(UnmanagedType.U1)]
			public bool cuttingRequired;

			public void Dispose()
			{
				contourVertices.Dispose();
				contours.Dispose();
				contoursExtra.Dispose();
				tileCuts.Dispose();
			}
		}

		public struct Point64Wrapper
		{
			public long x;

			public long y;

			public Point64Wrapper(long x, long y)
			{
				this.x = x;
				this.y = y;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void CutTiles_00000B31_0024PostfixBurstDelegate(ref UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags, ref Vector2Int tileSize, ref CutCollection cutCollection, ref UnsafeSpan<TileMesh.TileMeshUnsafe> output, Allocator allocator);

		internal static class CutTiles_00000B31_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<CutTiles_00000B31_0024PostfixBurstDelegate>(CutTiles).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags, ref Vector2Int tileSize, ref CutCollection cutCollection, ref UnsafeSpan<TileMesh.TileMeshUnsafe> output, Allocator allocator)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>>, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>>, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>>, ref Vector2Int, ref CutCollection, ref UnsafeSpan<TileMesh.TileMeshUnsafe>, Allocator, void>)functionPointer)(ref tileVertices, ref tileTriangles, ref tileTags, ref tileSize, ref cutCollection, ref output, allocator);
						return;
					}
				}
				CutTiles_0024BurstManaged(ref tileVertices, ref tileTriangles, ref tileTags, ref tileSize, ref cutCollection, ref output, allocator);
			}
		}

		private static readonly ProfilerMarker MarkerTriangulate = new ProfilerMarker("Triangulate");

		private static readonly ProfilerMarker MarkerClipping = new ProfilerMarker("Clipping");

		private static readonly ProfilerMarker MarkerPrepare = new ProfilerMarker("Prepare");

		private static readonly ProfilerMarker MarkerAllocate = new ProfilerMarker("Allocate");

		private static readonly ProfilerMarker MarkerCore = new ProfilerMarker("Core");

		private static readonly ProfilerMarker MarkerCompress = new ProfilerMarker("Compress");

		private static readonly ProfilerMarker MarkerRefine = new ProfilerMarker("Refine");

		private static readonly ProfilerMarker MarkerEdgeSnapping = new ProfilerMarker("EdgeSnapping");

		private static readonly ProfilerMarker MarkerCopyClippingResult = new ProfilerMarker("CopyClippingResult");

		private static readonly ProfilerMarker CopyTriangulationToOutputMarker = new ProfilerMarker("Copy to output");

		private static readonly SharedStatic<IntPtr> CutFunctionPtr = SharedStatic<IntPtr>.GetOrCreateUnsafe(0u, -3121683876094195160L, 0L);

		private static CutFunction DelegateGCRoot;

		private const int EdgeSnappingMaxDistance = 1;

		internal unsafe static CutCollection CollectCuts(GridLookup<NavmeshClipper> cuts, List<Vector2Int> tileCoordinates, float characterRadius, TileLayout tileLayout, ref UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags)
		{
			UnsafeList<float2> contourVertices = new UnsafeList<float2>(0, Allocator.Persistent);
			UnsafeList<NavmeshCut.ContourBurst> contours = new UnsafeList<NavmeshCut.ContourBurst>(0, Allocator.Persistent);
			UnsafeList<ContourMeta> contoursExtra = new UnsafeList<ContourMeta>(0, Allocator.Persistent);
			bool flag = false;
			UnsafeList<TileCuts> tileCuts = new UnsafeList<TileCuts>(0, Allocator.Persistent);
			Int3[] vbuffer = null;
			for (int i = 0; i < tileCoordinates.Count; i++)
			{
				Vector2Int vector2Int = tileCoordinates[i];
				Vector3 min = tileLayout.GetTileBoundsInGraphSpace(vector2Int.x, vector2Int.y).min;
				GraphTransform graphTransform = tileLayout.transform * Matrix4x4.Translate(min);
				Vector2Int vector2Int2 = tileCoordinates[i];
				List<NavmeshCut> list = cuts.QueryRect<NavmeshCut>(new IntRect(vector2Int2.x, vector2Int2.y, vector2Int2.x, vector2Int2.y));
				int length = contours.Length;
				flag |= list.Count > 0;
				for (int j = 0; j < list.Count; j++)
				{
					int length2 = contours.Length;
					list[j].GetContourBurst(&contourVertices, &contours, graphTransform.inverseMatrix, characterRadius);
					ContourMeta value = new ContourMeta
					{
						isDual = list[j].isDual,
						cutsAddedGeom = list[j].cutsAddedGeom
					};
					for (int k = length2; k < contours.Length; k++)
					{
						contoursExtra.Add(in value);
					}
				}
				ListPool<NavmeshCut>.Release(ref list);
				List<NavmeshAdd> list2 = cuts.QueryRect<NavmeshAdd>(new IntRect(vector2Int2.x, vector2Int2.y, vector2Int2.x, vector2Int2.y));
				flag |= list2.Count > 0;
				for (int l = 0; l < list2.Count; l++)
				{
					list2[l].GetMesh(ref vbuffer, out var tbuffer, out var vertexCount, graphTransform);
					UnsafeSpan<Int3> value2 = new UnsafeSpan<Int3>(Allocator.Persistent, vertexCount);
					UnsafeSpan<int> value3 = new UnsafeSpan<int>(Allocator.Persistent, tbuffer.Length);
					for (int m = 0; m < vertexCount; m++)
					{
						value2[m] = vbuffer[m];
					}
					for (int n = 0; n < tbuffer.Length; n++)
					{
						value3[n] = tbuffer[n];
					}
					UnsafeSpan<int> value4 = new UnsafeSpan<int>(Allocator.Persistent, tbuffer.Length / 3);
					for (int num = 0; num < value4.Length; num++)
					{
						value4[num] = 0;
					}
					tileVertices[i].Add(in value2);
					tileTriangles[i].Add(in value3);
					tileTags[i].Add(in value4);
				}
				ListPool<NavmeshAdd>.Release(ref list2);
				tileCuts.Add(new TileCuts
				{
					contourStartIndex = length,
					contourEndIndex = contours.Length
				});
			}
			ArrayPool<Int3>.Release(ref vbuffer);
			return new CutCollection
			{
				contourVertices = contourVertices,
				contours = contours,
				contoursExtra = contoursExtra,
				tileCuts = tileCuts,
				cuttingRequired = flag
			};
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Pathfinding_002EGraphs_002ENavmesh_002ECutTiles_00000B31_0024PostfixBurstDelegate))]
		internal static void CutTiles(ref UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags, ref Vector2Int tileSize, ref CutCollection cutCollection, ref UnsafeSpan<TileMesh.TileMeshUnsafe> output, Allocator allocator)
		{
			CutTiles_00000B31_0024BurstDirectCall.Invoke(ref tileVertices, ref tileTriangles, ref tileTags, ref tileSize, ref cutCollection, ref output, allocator);
		}

		private static void FindIntersectingCuts(UnsafeSpan<ContourMeta> contoursMeta, UnsafeSpan<IntBounds> cutBounds, NativeList<int> interestingCuts, NativeList<int> interestingDualCuts, IntBounds triBounds, bool addedGeometry)
		{
			interestingCuts.Clear();
			interestingDualCuts.Clear();
			triBounds.max += 1;
			triBounds.min -= 1;
			for (int i = 0; i < cutBounds.Length; i++)
			{
				if (IntBounds.Intersects(triBounds, cutBounds[i]) && (!addedGeometry || contoursMeta[i].cutsAddedGeom))
				{
					if (contoursMeta[i].isDual)
					{
						interestingDualCuts.Add(in i);
					}
					else
					{
						interestingCuts.Add(in i);
					}
				}
			}
		}

		private static IntBounds TriangleBounds(Int3 a, Int3 b, Int3 c)
		{
			int3 x = (int3)a;
			int3 x2 = (int3)a;
			int3 min = math.min(math.min(x, (int3)b), (int3)c);
			x2 = math.max(x2, (int3)b);
			x2 = math.max(x2, (int3)c);
			return new IntBounds(min, x2 + 1);
		}

		private static TileMesh.TileMeshUnsafe CompressAndRefineTile(NativeList<Int3> tileOutputVertices, NativeList<int> tileOutputTriangles, NativeList<int> tileOutputTags, Allocator allocator)
		{
			MeshUtility.JobRemoveDuplicateVertices jobRemoveDuplicateVertices = default(MeshUtility.JobRemoveDuplicateVertices);
			jobRemoveDuplicateVertices.vertices = tileOutputVertices;
			jobRemoveDuplicateVertices.triangles = tileOutputTriangles;
			jobRemoveDuplicateVertices.tags = tileOutputTags;
			jobRemoveDuplicateVertices.Execute();
			int num = (tileOutputTriangles.Length = DelaunayRefinement(tileOutputVertices.AsUnsafeSpan(), tileOutputTriangles.AsUnsafeSpan(), tileOutputTags.AsUnsafeSpan(), delaunay: true, colinear: true));
			tileOutputTags.Length = num / 3;
			return new TileMesh.TileMeshUnsafe
			{
				verticesInTileSpace = tileOutputVertices.AsUnsafeSpan().Clone(allocator),
				triangles = tileOutputTriangles.AsUnsafeSpan().Clone(allocator),
				tags = tileOutputTags.AsUnsafeSpan().Reinterpret<uint>().Clone(allocator)
			};
		}

		private static void CopyTriangulationToOutput(ref andywiecko.BurstTriangulator.LowLevel.Unsafe.OutputData<int2> triangulatorOutput, NativeList<Int3> tileOutputVertices, NativeList<int> tileOutputTriangles, NativeList<int> tileOutputTags, int tag, Int3 a, Int3 b, Int3 c)
		{
			int length = tileOutputVertices.Length;
			Polygon.BarycentricTriangleInterpolator barycentricTriangleInterpolator = new Polygon.BarycentricTriangleInterpolator(a, b, c);
			for (int i = 0; i < triangulatorOutput.Positions.Length; i++)
			{
				Int3 value = new Int3(triangulatorOutput.Positions[i].x, 0, triangulatorOutput.Positions[i].y);
				value.y = barycentricTriangleInterpolator.SampleY(new int2(value.x, value.z));
				tileOutputVertices.Add(in value);
			}
			tileOutputTags.AddReplicate(in tag, triangulatorOutput.Triangles.Length / 3);
			for (int j = 0; j < triangulatorOutput.Triangles.Length; j += 3)
			{
				int value2 = triangulatorOutput.Triangles[j] + length;
				int value3 = triangulatorOutput.Triangles[j + 1] + length;
				int value4 = triangulatorOutput.Triangles[j + 2] + length;
				tileOutputTriangles.Add(in value2);
				tileOutputTriangles.Add(in value3);
				tileOutputTriangles.Add(in value4);
			}
		}

		private static void SnapEdges(ref NativeArray<Point64Wrapper> triBuffer, ref int vertexCount, UnsafeSpan<NavmeshCut.ContourBurst> contours, ref NativeList<int> interestingCuts, ref NativeArray<Point64Wrapper> contourVerticesP64)
		{
			int i = 0;
			int index = vertexCount - 1;
			for (; i < vertexCount; i++)
			{
				int2 int5 = new int2((int)triBuffer[index].x, (int)triBuffer[index].y);
				int2 int6 = new int2((int)triBuffer[i].x, (int)triBuffer[i].y);
				int2 int7 = int6 - int5;
				long num = (long)int7.x * (long)int7.x + (long)int7.y * (long)int7.y;
				long num2 = (long)math.sqrt((double)num) * 2;
				for (int j = 0; j < interestingCuts.Length; j++)
				{
					NavmeshCut.ContourBurst contourBurst = contours[interestingCuts[j]];
					for (int k = contourBurst.startIndex; k < contourBurst.endIndex; k++)
					{
						int2 int8 = new int2((int)contourVerticesP64[k].x, (int)contourVerticesP64[k].y);
						if (math.abs(VectorMath.SignedTriangleAreaTimes2(int5, int6, int8)) > num2)
						{
							continue;
						}
						int2 int9 = int8 - int5;
						long num3 = (long)int9.x * (long)int7.x + (long)int9.y * (long)int7.y;
						if (num3 > 0 && num3 < num)
						{
							if (triBuffer.Length < vertexCount + 1)
							{
								NativeArray<Point64Wrapper> nativeArray = new NativeArray<Point64Wrapper>(vertexCount * 2, Allocator.Temp);
								triBuffer.AsUnsafeSpan().CopyTo(nativeArray.AsUnsafeSpan());
								triBuffer.Dispose();
								triBuffer = nativeArray;
							}
							triBuffer.AsUnsafeSpan().Move(i, i + 1, vertexCount - i);
							triBuffer[i] = new Point64Wrapper(int8.x, int8.y);
							vertexCount++;
							int6 = int8;
							int7 = int6 - int5;
							num = (long)int7.x * (long)int7.x + (long)int7.y * (long)int7.y;
							num2 = (long)math.sqrt((double)num) * 2;
						}
					}
				}
				index = i;
			}
		}

		private static NativeArray<Point64Wrapper> ConvertTo64BitCoordinates(UnsafeList<float2> vertices)
		{
			NativeArray<Point64Wrapper> result = new NativeArray<Point64Wrapper>(vertices.Length, Allocator.Temp);
			for (int i = 0; i < vertices.Length; i++)
			{
				float2 float5 = math.round(vertices[i] * 1000f);
				result[i] = new Point64Wrapper((long)float5.x, (long)float5.y);
			}
			return result;
		}

		private static NativeArray<IntBounds> CalculateCutBounds(ref CutCollection cutCollection, ref NativeArray<Point64Wrapper> contourVerticesP64)
		{
			NativeArray<IntBounds> result = new NativeArray<IntBounds>(cutCollection.contours.Length, Allocator.Temp);
			for (int i = 0; i < cutCollection.contours.Length; i++)
			{
				NavmeshCut.ContourBurst contourBurst = cutCollection.contours[i];
				int2 x = new int2(int.MaxValue, int.MaxValue);
				int2 x2 = new int2(int.MinValue, int.MinValue);
				for (int j = contourBurst.startIndex; j < contourBurst.endIndex; j++)
				{
					int2 y = new int2((int)contourVerticesP64[j].x, (int)contourVerticesP64[j].y);
					x = math.min(x, y);
					x2 = math.max(x2, y);
				}
				result[i] = new IntBounds(new int3(x.x, (int)(contourBurst.ymin * 1000f), x.y), new int3(x2.x + 1, (int)math.ceil(contourBurst.ymax * 1000f), x2.y + 1));
			}
			return result;
		}

		private unsafe static void AddContours(Clipper64 clipper, ref UnsafeSpan<NavmeshCut.ContourBurst> contours, ref UnsafeSpan<Point64Wrapper> contourVertices, ref UnsafeSpan<int> contourIndices)
		{
			for (int i = 0; i < contourIndices.Length; i++)
			{
				NavmeshCut.ContourBurst contourBurst = contours[contourIndices[i]];
				UnsafeSpan<Point64Wrapper> unsafeSpan = contourVertices.Slice(contourBurst.startIndex, contourBurst.endIndex - contourBurst.startIndex);
				clipper.AddPath((Point64*)unsafeSpan.ptr, unsafeSpan.Length, PathType.Clip);
			}
		}

		private static void CopyClipperOutput(List<List<Point64>> closedSolutions, ref UnsafeList<Vector2Int> outputVertices, ref UnsafeList<int> outputVertexCountPerPolygon)
		{
			outputVertexCountPerPolygon.Length = closedSolutions.Count;
			for (int i = 0; i < closedSolutions.Count; i++)
			{
				List<Point64> list = closedSolutions[i];
				for (int j = 0; j < list.Count; j++)
				{
					outputVertices.Add(new Vector2Int((int)list[j].X, (int)list[j].Y));
				}
				outputVertexCountPerPolygon[i] = list.Count;
			}
		}

		[MonoPInvokeCallback(typeof(CutFunction))]
		private unsafe static bool CutPolygon(ref UnsafeSpan<Point64Wrapper> subject, ref UnsafeSpan<Point64Wrapper> contourVertices, ref UnsafeSpan<NavmeshCut.ContourBurst> contours, ref UnsafeSpan<int> contourIndices, ref UnsafeSpan<int> contourIndicesDual, ref UnsafeList<Vector2Int> outputVertices, ref UnsafeList<int> outputVertexCountPerPolygon, int mode)
		{
			int threadIndex = JobsUtility.ThreadIndex;
			Clipper64[] cachedClippers = TileHandlerCache.cachedClippers;
			Clipper64 obj = TileHandlerCache.cachedClippers[threadIndex] ?? new Clipper64();
			Clipper64 clipper = obj;
			cachedClippers[threadIndex] = obj;
			Clipper64 clipper2 = clipper;
			clipper2.PreserveCollinear = true;
			List<List<Point64>> list = ListPool<List<Point64>>.Claim();
			List<List<Point64>> list2 = ListPool<List<Point64>>.Claim();
			if (mode != 1)
			{
				clipper2.Clear();
				clipper2.AddPath((Point64*)subject.ptr, subject.Length, PathType.Subject);
				AddContours(clipper2, ref contours, ref contourVertices, ref contourIndices);
				AddContours(clipper2, ref contours, ref contourVertices, ref contourIndicesDual);
			}
			else
			{
				clipper2.Clear();
				clipper2.AddPath((Point64*)subject.ptr, subject.Length, PathType.Subject);
				AddContours(clipper2, ref contours, ref contourVertices, ref contourIndicesDual);
				if (!clipper2.Execute(ClipType.Intersection, FillRule.NonZero, list, list2))
				{
					return false;
				}
				clipper2.Clear();
				for (int i = 0; i < list.Count; i++)
				{
					List<Point64> list3 = list[i];
					if (Clipper.IsPositive(list3))
					{
						clipper2.AddSubject(list3);
					}
					else
					{
						clipper2.AddClip(list3);
					}
				}
				AddContours(clipper2, ref contours, ref contourVertices, ref contourIndices);
				list.Clear();
				list2.Clear();
			}
			if (!clipper2.Execute(ClipType.Difference, FillRule.NonZero, list, list2))
			{
				return false;
			}
			CopyClipperOutput(list, ref outputVertices, ref outputVertexCountPerPolygon);
			ListPool<List<Point64>>.Release(ref list);
			ListPool<List<Point64>>.Release(ref list2);
			return true;
		}

		internal static void InitDelegates()
		{
			if (DelegateGCRoot == null)
			{
				CutFunction d = (DelegateGCRoot = CutPolygon);
				CutFunctionPtr.Data = Marshal.GetFunctionPointerForDelegate(d);
			}
		}

		private static int ClipAgainstRectangle(UnsafeSpan<Int3> clipIn, UnsafeSpan<Int3> clipTmp, Vector2Int size)
		{
			Int3PolygonClipper int3PolygonClipper = default(Int3PolygonClipper);
			int num = int3PolygonClipper.ClipPolygon(clipIn, 3, clipTmp, 1, 0, 0);
			if (num == 0)
			{
				return num;
			}
			num = int3PolygonClipper.ClipPolygon(clipTmp, num, clipIn, -1, size.x, 0);
			if (num == 0)
			{
				return num;
			}
			num = int3PolygonClipper.ClipPolygon(clipIn, num, clipTmp, 1, 0, 2);
			if (num == 0)
			{
				return num;
			}
			return int3PolygonClipper.ClipPolygon(clipTmp, num, clipIn, -1, size.y, 2);
		}

		private static int DelaunayRefinement(UnsafeSpan<Int3> verts, UnsafeSpan<int> tris, UnsafeSpan<int> tags, bool delaunay, bool colinear)
		{
			if (tris.Length % 3 != 0)
			{
				throw new ArgumentException("Triangle array length must be a multiple of 3");
			}
			if (tags.Length != tris.Length / 3)
			{
				throw new ArgumentException("There must be exactly 1 tag per 3 triangle indices");
			}
			NativeHashMap<Vector2Int, int> lookup = new NativeHashMap<Vector2Int, int>(tris.Length, Allocator.Temp);
			for (int i = 0; i < tris.Length; i += 3)
			{
				if (!VectorMath.IsClockwiseXZ(verts[tris[i]], verts[tris[i + 1]], verts[tris[i + 2]]))
				{
					int num = tris[i];
					tris[i] = tris[i + 2];
					tris[i + 2] = num;
				}
				AddTriangleToLookup(lookup, tris, i);
			}
			int tCount = tris.Length;
			int num2 = 0;
			int num3 = 0;
			while (num2 < tCount)
			{
				int num4 = tags[num3];
				for (int j = 0; j < 3; j++)
				{
					int num5 = tris[num2 + j % 3];
					int num6 = tris[num2 + (j + 1) % 3];
					if (!lookup.TryGetValue(new Vector2Int(num6, num5), out var item))
					{
						continue;
					}
					int num7 = tris[num2 + (j + 2) % 3];
					Int3 int5 = verts[num7];
					Int3 int6 = verts[num6];
					Int3 int7 = verts[num5];
					Int3 int8 = verts[tris[item]];
					int num8 = tags[item / 3];
					if (num4 != num8)
					{
						continue;
					}
					int5.y = 0;
					int6.y = 0;
					int7.y = 0;
					int8.y = 0;
					bool flag = false;
					if (!VectorMath.RightOrColinearXZ(int5, int7, int8) || VectorMath.RightXZ(int5, int6, int8))
					{
						if (!colinear)
						{
							continue;
						}
						flag = true;
					}
					if (colinear && VectorMath.SqrDistancePointSegmentApproximate(int5, int8, int6) <= 9f && !lookup.ContainsKey(new Vector2Int(num7, num6)) && !lookup.ContainsKey(new Vector2Int(num6, tris[item])))
					{
						num6 = (tris[num2 + (j + 1) % 3] = tris[item]);
						RemoveTriangleWithVertex(item, ref tCount, tris, tags, lookup);
						AddTriangleToLookup(lookup, tris, num2);
						j--;
					}
					else if (delaunay && !flag)
					{
						float num9 = Int3.Angle(int6 - int5, int7 - int5);
						if (Int3.Angle(int6 - int8, int7 - int8) > MathF.PI * 2f - 2f * num9)
						{
							tris[num2 + (j + 1) % 3] = tris[item];
							int num10 = item / 3 * 3;
							int num11 = item - num10;
							tris[num10 + (num11 - 1 + 3) % 3] = tris[num2 + (j + 2) % 3];
							AddTriangleToLookup(lookup, tris, num2);
							lookup[new Vector2Int(tris[num10], tris[num10 + 1])] = num10 + 2;
							lookup[new Vector2Int(tris[num10 + 1], tris[num10 + 2])] = num10;
							lookup[new Vector2Int(tris[num10 + 2], tris[num10])] = num10 + 1;
						}
					}
				}
				num2 += 3;
				num3++;
			}
			return tCount;
			static void AddTriangleToLookup(NativeHashMap<Vector2Int, int> nativeHashMap, UnsafeSpan<int> unsafeSpan, int num12)
			{
				nativeHashMap[new Vector2Int(unsafeSpan[num12], unsafeSpan[num12 + 1])] = num12 + 2;
				nativeHashMap[new Vector2Int(unsafeSpan[num12 + 1], unsafeSpan[num12 + 2])] = num12;
				nativeHashMap[new Vector2Int(unsafeSpan[num12 + 2], unsafeSpan[num12])] = num12 + 1;
			}
			static void RemoveTriangleWithVertex(int vertexIndex, ref int reference, UnsafeSpan<int> unsafeSpan, UnsafeSpan<int> unsafeSpan2, NativeHashMap<Vector2Int, int> nativeHashMap)
			{
				reference -= 3;
				int num12 = vertexIndex / 3 * 3;
				if (num12 != reference)
				{
					unsafeSpan[num12] = unsafeSpan[reference];
					unsafeSpan[num12 + 1] = unsafeSpan[reference + 1];
					unsafeSpan[num12 + 2] = unsafeSpan[reference + 2];
					unsafeSpan2[num12 / 3] = unsafeSpan2[reference / 3];
					nativeHashMap[new Vector2Int(unsafeSpan[num12], unsafeSpan[num12 + 1])] = num12 + 2;
					nativeHashMap[new Vector2Int(unsafeSpan[num12 + 1], unsafeSpan[num12 + 2])] = num12;
					nativeHashMap[new Vector2Int(unsafeSpan[num12 + 2], unsafeSpan[num12])] = num12 + 1;
					unsafeSpan[reference] = 0;
					unsafeSpan[reference + 1] = 0;
					unsafeSpan[reference + 2] = 0;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal unsafe static void CutTiles_0024BurstManaged(ref UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags, ref Vector2Int tileSize, ref CutCollection cutCollection, ref UnsafeSpan<TileMesh.TileMeshUnsafe> output, Allocator allocator)
		{
			NativeArray<Point64Wrapper> contourVerticesP = ConvertTo64BitCoordinates(cutCollection.contourVertices);
			NativeArray<IntBounds> arr = CalculateCutBounds(ref cutCollection, ref contourVerticesP);
			int length = tileVertices.Length;
			NativeList<int> interestingCuts = new NativeList<int>(4, Allocator.Temp);
			NativeList<int> nativeList = new NativeList<int>(0, Allocator.Temp);
			NativeArray<Int3> arr2 = new NativeArray<Int3>(7, Allocator.Temp);
			NativeArray<Int3> arr3 = new NativeArray<Int3>(7, Allocator.Temp);
			NativeArray<Point64Wrapper> triBuffer = new NativeArray<Point64Wrapper>(16, Allocator.Temp);
			NativeList<int2> nativeList2 = new NativeList<int2>(Allocator.Temp);
			NativeList<int> nativeList3 = new NativeList<int>(Allocator.Temp);
			NativeHashMap<int2, int> nativeHashMap = new NativeHashMap<int2, int>(64, Allocator.Temp);
			andywiecko.BurstTriangulator.LowLevel.Unsafe.OutputData<int2> triangulatorOutput = new andywiecko.BurstTriangulator.LowLevel.Unsafe.OutputData<int2>
			{
				Positions = new NativeList<int2>(Allocator.Temp),
				Triangles = new NativeList<int>(Allocator.Temp),
				Status = new NativeReference<Status>(Allocator.Temp),
				Halfedges = new NativeList<int>(Allocator.Temp),
				ConstrainedHalfedges = new NativeList<HalfedgeState>(Allocator.Temp)
			};
			NativeList<Int3> tileOutputVertices = new NativeList<Int3>(Allocator.Temp);
			NativeList<int> tileOutputTriangles = new NativeList<int>(Allocator.Temp);
			NativeList<int> tileOutputTags = new NativeList<int>(Allocator.Temp);
			NativeList<Vector2Int> nativeList4 = new NativeList<Vector2Int>(0, Allocator.Temp);
			NativeList<int> nativeList5 = new NativeList<int>(0, Allocator.Temp);
			for (int i = 0; i < length; i++)
			{
				UnsafeList<UnsafeSpan<Int3>> unsafeList = tileVertices[i];
				UnsafeList<UnsafeSpan<int>> unsafeList2 = tileTriangles[i];
				TileCuts tileCuts = cutCollection.tileCuts[i];
				if (tileCuts.contourStartIndex == tileCuts.contourEndIndex && unsafeList.Length == 1)
				{
					output[i] = new TileMesh.TileMeshUnsafe
					{
						verticesInTileSpace = unsafeList[0].Clone(allocator),
						triangles = unsafeList2[0].Clone(allocator),
						tags = tileTags[i][0].Clone(allocator).Reinterpret<uint>()
					};
					continue;
				}
				tileOutputVertices.Clear();
				tileOutputTriangles.Clear();
				tileOutputTags.Clear();
				for (int j = 0; j < unsafeList.Length; j++)
				{
					UnsafeSpan<Int3> unsafeSpan = unsafeList[j];
					UnsafeSpan<int3> unsafeSpan2 = unsafeList2[j].Reinterpret<int3>(4);
					UnsafeSpan<int> unsafeSpan3 = tileTags[i][j];
					for (int k = 0; k < unsafeSpan2.Length; k++)
					{
						int3 int5 = unsafeSpan2[k];
						Int3 int6 = unsafeSpan[int5.x];
						Int3 int7 = unsafeSpan[int5.y];
						Int3 int8 = unsafeSpan[int5.z];
						IntBounds triBounds = TriangleBounds(int6, int7, int8);
						triBounds.max += 1;
						triBounds.min -= 1;
						FindIntersectingCuts(cutCollection.contoursExtra.AsUnsafeSpan().Slice(tileCuts.contourStartIndex, tileCuts.contourEndIndex - tileCuts.contourStartIndex), arr.AsUnsafeSpan().Slice(tileCuts.contourStartIndex, tileCuts.contourEndIndex - tileCuts.contourStartIndex), interestingCuts, nativeList, triBounds, j > 0);
						int value = unsafeSpan3[k];
						if (interestingCuts.Length == 0 && nativeList.Length == 0 && j == 0)
						{
							int length2 = tileOutputVertices.Length;
							tileOutputVertices.Capacity = math.max(tileOutputVertices.Capacity, tileOutputVertices.Length + 3);
							tileOutputTriangles.Capacity = math.max(tileOutputTriangles.Capacity, tileOutputTriangles.Length + 3);
							tileOutputVertices.AddNoResize(int6);
							tileOutputVertices.AddNoResize(int7);
							tileOutputVertices.AddNoResize(int8);
							for (int l = 0; l < 3; l++)
							{
								tileOutputTriangles.AddNoResize(length2 + l);
							}
							tileOutputTags.Add(in value);
							continue;
						}
						int vertexCount;
						if (j > 0)
						{
							arr2[0] = int6;
							arr2[1] = int7;
							arr2[2] = int8;
							vertexCount = ClipAgainstRectangle(arr2.AsUnsafeSpan(), arr3.AsUnsafeSpan(), tileSize);
							for (int m = 0; m < vertexCount; m++)
							{
								triBuffer[m] = new Point64Wrapper(arr2[m].x, arr2[m].z);
							}
						}
						else
						{
							vertexCount = 3;
							triBuffer[0] = new Point64Wrapper(int6.x, int6.z);
							triBuffer[1] = new Point64Wrapper(int7.x, int7.z);
							triBuffer[2] = new Point64Wrapper(int8.x, int8.z);
						}
						UnsafeSpan<NavmeshCut.ContourBurst> contours = cutCollection.contours.AsUnsafeSpan().Slice(tileCuts.contourStartIndex, tileCuts.contourEndIndex - tileCuts.contourStartIndex);
						SnapEdges(ref triBuffer, ref vertexCount, contours, ref interestingCuts, ref contourVerticesP);
						for (int n = 0; n < 2 && (n != 1 || nativeList.Length != 0); n++)
						{
							UnsafeSpan<Point64Wrapper> subject = triBuffer.AsUnsafeReadOnlySpan().Slice(0, vertexCount);
							UnsafeSpan<int> contourIndices = interestingCuts.AsUnsafeSpan();
							UnsafeSpan<int> contourIndicesDual = nativeList.AsUnsafeSpan();
							UnsafeSpan<Point64Wrapper> contourVertices = contourVerticesP.AsUnsafeReadOnlySpan();
							nativeList4.Clear();
							nativeList5.Clear();
							if (!new FunctionPointer<CutFunction>(CutFunctionPtr.Data).Invoke(ref subject, ref contourVertices, ref contours, ref contourIndices, ref contourIndicesDual, ref UnsafeUtility.AsRef<UnsafeList<Vector2Int>>(nativeList4.GetUnsafeList()), ref UnsafeUtility.AsRef<UnsafeList<int>>(nativeList5.GetUnsafeList()), n))
							{
								Debug.LogError("Error during cutting");
							}
							else
							{
								if (nativeList5.Length == 0)
								{
									continue;
								}
								if (nativeList4.Length == 3 && nativeList5.Length == 1)
								{
									int length3 = tileOutputVertices.Length;
									tileOutputVertices.Capacity = math.max(tileOutputVertices.Capacity, tileOutputVertices.Length + 3);
									tileOutputTriangles.Capacity = math.max(tileOutputTriangles.Capacity, tileOutputTriangles.Length + 3);
									Polygon.BarycentricTriangleInterpolator barycentricTriangleInterpolator = new Polygon.BarycentricTriangleInterpolator(int6, int7, int8);
									for (int num = 0; num < 3; num++)
									{
										Int3 value2 = new Int3(nativeList4[num].x, 0, nativeList4[num].y);
										value2.y = barycentricTriangleInterpolator.SampleY(new int2(value2.x, value2.z));
										tileOutputVertices.Add(in value2);
									}
									int value3 = length3;
									tileOutputTriangles.Add(in value3);
									tileOutputTriangles.Add(length3 + 1);
									tileOutputTriangles.Add(length3 + 2);
									tileOutputTags.Add(in value);
									continue;
								}
								nativeList2.Clear();
								nativeList3.Clear();
								nativeHashMap.Clear();
								int num2 = 0;
								for (int num3 = 0; num3 < nativeList5.Length; num3++)
								{
									int num4 = num2;
									num2 += nativeList5[num3];
									int num5 = num2;
									int value4 = -1;
									int length4 = nativeList3.Length;
									for (int num6 = num4; num6 < num5; num6++)
									{
										int2 value5 = new int2(nativeList4[num6].x, nativeList4[num6].y);
										if (!nativeHashMap.TryGetValue(value5, out var item))
										{
											item = nativeList2.Length;
											nativeList2.Add(in value5);
											nativeHashMap.Add(value5, item);
										}
										if (value4 != -1)
										{
											nativeList3.Add(in value4);
											nativeList3.Add(in item);
										}
										value4 = item;
									}
									nativeList3.Add(in value4);
									nativeList3.Add(nativeList3[length4]);
								}
								andywiecko.BurstTriangulator.LowLevel.Unsafe.InputData<int2> input = new andywiecko.BurstTriangulator.LowLevel.Unsafe.InputData<int2>
								{
									Positions = nativeList2.AsArray(),
									ConstraintEdges = nativeList3.AsArray()
								};
								andywiecko.BurstTriangulator.LowLevel.Unsafe.Extensions.Triangulate(args: new Args(Preprocessor.None, 1000000, autoHolesAndBoundary: true, refineMesh: false, restoreBoundary: false, validateInput: false, verbose: false, 0f, 0f), @this: default(UnsafeTriangulator<int2>), input: input, output: triangulatorOutput, allocator: Allocator.Temp);
								if (triangulatorOutput.Status.Value.IsError)
								{
									Debug.LogError("Error during triangulation");
								}
								else
								{
									CopyTriangulationToOutput(ref triangulatorOutput, tileOutputVertices, tileOutputTriangles, tileOutputTags, value, int6, int7, int8);
								}
							}
						}
					}
				}
				output[i] = CompressAndRefineTile(tileOutputVertices, tileOutputTriangles, tileOutputTags, allocator);
			}
			tileOutputVertices.Dispose();
			tileOutputTriangles.Dispose();
			tileOutputTags.Dispose();
		}
	}
}
