using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct UnsafeTriangulator
	{
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct UnsafeTriangulator<T2> where T2 : unmanaged
	{
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct UnsafeTriangulator<T, T2, TBig, TTransform, TUtils> where T : unmanaged, IComparable<T> where T2 : unmanaged where TBig : unmanaged, IComparable<TBig> where TTransform : unmanaged, ITransform<TTransform, T, T2> where TUtils : unmanaged, IUtils<T, T2, TBig>
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct Markers
		{
			public static readonly ProfilerMarker PreProcessInputStep = new ProfilerMarker("PreProcessInputStep");

			public static readonly ProfilerMarker PostProcessInputStep = new ProfilerMarker("PostProcessInputStep");

			public static readonly ProfilerMarker ValidateInputStep = new ProfilerMarker("ValidateInputStep");

			public static readonly ProfilerMarker DelaunayTriangulationStep = new ProfilerMarker("DelaunayTriangulationStep");

			public static readonly ProfilerMarker ConstrainEdgesStep = new ProfilerMarker("ConstrainEdgesStep");

			public static readonly ProfilerMarker PlantingSeedStep = new ProfilerMarker("PlantingSeedStep");

			public static readonly ProfilerMarker RefineMeshStep = new ProfilerMarker("RefineMeshStep");
		}

		private struct ValidateInputStep
		{
			private NativeArray<T2>.ReadOnly positions;

			private NativeReference<Status> status;

			private readonly Args args;

			private NativeArray<int>.ReadOnly constraints;

			private NativeArray<ConstraintType>.ReadOnly constraintTypes;

			private NativeArray<T2>.ReadOnly holes;

			public ValidateInputStep(InputData<T2> input, OutputData<T2> output, Args args)
			{
				positions = output.Positions.AsReadOnly();
				status = output.Status;
				this.args = args;
				constraints = input.ConstraintEdges.AsReadOnly();
				constraintTypes = input.ConstraintEdgeTypes.AsReadOnly();
				holes = input.HoleSeeds.AsReadOnly();
			}

			public void Execute()
			{
				if (!args.ValidateInput)
				{
					return;
				}
				using (Markers.ValidateInputStep.Auto())
				{
					ValidateArgs();
					ValidatePositions();
					ValidateConstraints();
					ValidateHoles();
				}
			}

			private void ValidateArgs()
			{
				if (args.AutoHolesAndBoundary && !constraints.IsCreated)
				{
					status.Value = Status.ConstraintEdgesMissingForAutoHolesAndBoundary;
				}
				if (args.RestoreBoundary && !constraints.IsCreated)
				{
					status.Value = Status.ConstraintEdgesMissingForRestoreBoundary;
				}
				if (args.RefineMesh && !UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.SupportsRefinement())
				{
					status.Value = Status.RefinementNotSupportedForCoordinateType;
				}
				if (constraints.IsCreated && args.SloanMaxIters < 1)
				{
					status.Value = Status.SloanMaxItersMustBePositive(args.SloanMaxIters);
				}
				if (args.RefineMesh && args.RefinementThresholdArea < 0f)
				{
					status.Value = Status.RefinementThresholdAreaMustBePositive;
				}
				if ((args.RefineMesh && args.RefinementThresholdAngle < 0f) || args.RefinementThresholdAngle > MathF.PI / 4f)
				{
					status.Value = Status.RefinementThresholdAngleOutOfRange;
				}
			}

			private void ValidatePositions()
			{
				if (positions.Length < 3)
				{
					status.Value = Status.PositionsLengthLessThan3(positions.Length);
					return;
				}
				for (int i = 0; i < positions.Length; i++)
				{
					if (math.any(!UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.isfinite(positions[i])))
					{
						status.Value = Status.PositionsMustBeFinite(i);
						break;
					}
					T2 v = positions[i];
					for (int j = i + 1; j < positions.Length; j++)
					{
						T2 w = positions[j];
						if (math.all(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.eq(v, w)))
						{
							status.Value = Status.DuplicatePosition(i);
							return;
						}
					}
				}
			}

			private void ValidateConstraints()
			{
				if (!constraints.IsCreated)
				{
					return;
				}
				if (constraints.Length % 2 != 0)
				{
					status.Value = Status.ConstraintsLengthNotDivisibleBy2(constraints.Length);
					return;
				}
				if (constraintTypes.IsCreated && constraintTypes.Length * 2 != constraints.Length)
				{
					status.Value = Status.ConstraintArrayLengthMismatch(constraints.Length, constraintTypes.Length);
					return;
				}
				for (int i = 0; i < constraints.Length / 2; i++)
				{
					int num = constraints[2 * i];
					int num2 = constraints[2 * i + 1];
					int num3 = num;
					int num4 = num2;
					int length = positions.Length;
					if (num3 >= length || num3 < 0 || num4 >= length || num4 < 0)
					{
						status.Value = Status.ConstraintOutOfBounds(i, new int2(num3, num4), length);
						return;
					}
					if (num3 == num4)
					{
						status.Value = Status.ConstraintSelfLoop(i, new int2(num3, num4));
						return;
					}
				}
				for (int j = 0; j < constraints.Length / 2; j++)
				{
					int num = constraints[2 * j];
					int num5 = constraints[2 * j + 1];
					int num6 = num;
					int num7 = num5;
					T2 val = positions[num6];
					T2 val2 = positions[num7];
					T2 val3 = val;
					T2 val4 = val2;
					for (int k = j + 1; k < constraints.Length / 2; k++)
					{
						num = constraints[2 * k];
						int num8 = constraints[2 * k + 1];
						int num9 = num;
						int num10 = num8;
						if ((num6 == num9 && num7 == num10) || (num6 == num10 && num7 == num9))
						{
							status.Value = Status.DuplicateConstraint(j, k);
							return;
						}
						if (num6 != num9 && num6 != num10 && num7 != num9 && num7 != num10)
						{
							val = positions[num9];
							T2 val5 = positions[num10];
							T2 val6 = val;
							T2 val7 = val5;
							if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.EdgeEdgeIntersection(val3, val4, val6, val7) && !UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.PointLineSegmentIntersection(val3, val6, val7) && !UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.PointLineSegmentIntersection(val4, val6, val7) && !UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.PointLineSegmentIntersection(val6, val3, val4) && !UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.PointLineSegmentIntersection(val7, val3, val4))
							{
								status.Value = Status.ConstraintIntersection(j, k);
								return;
							}
						}
					}
				}
			}

			private void ValidateHoles()
			{
				if (!holes.IsCreated)
				{
					return;
				}
				if (!constraints.IsCreated)
				{
					status.Value = Status.RedudantHolesArray;
				}
				for (int i = 0; i < holes.Length; i++)
				{
					if (math.any(!UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.isfinite(holes[i])))
					{
						status.Value = Status.HoleMustBeFinite(i);
						break;
					}
				}
			}
		}

		private struct DelaunayTriangulationStep
		{
			private struct DistComparer : IComparer<int>
			{
				private NativeArray<TBig> dist;

				public DistComparer(NativeArray<TBig> dist)
				{
					this.dist = dist;
				}

				public int Compare(int x, int y)
				{
					return dist[x].CompareTo(dist[y]);
				}
			}

			private NativeReference<Status> status;

			private NativeArray<T2>.ReadOnly positions;

			private NativeList<int> triangles;

			private NativeList<int> halfedges;

			private NativeList<HalfedgeState> constrainedHalfedges;

			private NativeArray<int> hullNext;

			private NativeArray<int> hullPrev;

			private NativeArray<int> hullTri;

			private NativeArray<int> hullHash;

			private NativeArray<int> EDGE_STACK;

			private readonly int hashSize;

			private readonly bool verbose;

			private int hullStart;

			private int trianglesLen;

			public DelaunayTriangulationStep(OutputData<T2> output, Args args)
			{
				status = output.Status;
				positions = output.Positions.AsReadOnly();
				triangles = output.Triangles;
				halfedges = output.Halfedges;
				constrainedHalfedges = output.ConstrainedHalfedges;
				hullStart = int.MaxValue;
				verbose = args.Verbose;
				hashSize = (int)math.ceil(math.sqrt(positions.Length));
				trianglesLen = 0;
				hullNext = default(NativeArray<int>);
				hullPrev = default(NativeArray<int>);
				hullTri = default(NativeArray<int>);
				hullHash = default(NativeArray<int>);
				EDGE_STACK = default(NativeArray<int>);
			}

			public void Execute(Allocator allocator)
			{
				if (status.Value.IsError)
				{
					return;
				}
				using (Markers.DelaunayTriangulationStep.Auto())
				{
					int length = positions.Length;
					int num = math.max(2 * length - 5, 0);
					triangles.Length = 3 * num;
					halfedges.Length = 3 * num;
					NativeArray<int> array = new NativeArray<int>(length, allocator);
					T2 val = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.MaxValue2();
					T2 val2 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.MinValue2();
					for (int i = 0; i < positions.Length; i++)
					{
						T2 w = positions[i];
						val = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.min(val, w);
						val2 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.max(val2, w);
						array[i] = i;
					}
					T2 a = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.avg(val, val2);
					int num2 = int.MaxValue;
					int num3 = int.MaxValue;
					int num4 = int.MaxValue;
					TBig b = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.MaxValue();
					for (int j = 0; j < positions.Length; j++)
					{
						TBig val3 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.distancesq(a, positions[j]);
						if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.less(val3, b))
						{
							num2 = j;
							b = val3;
						}
					}
					T2 val4 = positions[num2];
					b = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.MaxValue();
					for (int k = 0; k < positions.Length; k++)
					{
						if (k != num2)
						{
							TBig val5 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.distancesq(val4, positions[k]);
							if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.less(val5, b))
							{
								num3 = k;
								b = val5;
							}
						}
					}
					T2 val6 = positions[num3];
					TBig b2 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.MaxValue();
					for (int l = 0; l < positions.Length; l++)
					{
						if (l != num2 && l != num3)
						{
							T2 c = positions[l];
							TBig val7 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.CircumRadiusSq(val4, val6, c);
							if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.less(val7, b2))
							{
								num4 = l;
								b2 = val7;
							}
						}
					}
					if (num4 == int.MaxValue || math.any(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.eq(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.CircumCenter(val4, val6, positions[num4]), UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.MaxValue2())))
					{
						status.Value = Status.DegenerateInput;
						array.Dispose();
						return;
					}
					using (hullPrev = new NativeArray<int>(length, allocator))
					{
						using (hullNext = new NativeArray<int>(length, allocator))
						{
							using (hullTri = new NativeArray<int>(length, allocator))
							{
								using (hullHash = new NativeArray<int>(hashSize, allocator))
								{
									using (EDGE_STACK = new NativeArray<int>(math.min(3 * num, 512), allocator))
									{
										NativeArray<TBig> dist = new NativeArray<TBig>(length, allocator);
										T2 val8 = positions[num4];
										int num6;
										if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.less(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.Orient2dFast(val4, val6, val8), UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.ZeroTBig()))
										{
											int num5 = num4;
											num6 = num3;
											num3 = num5;
											num4 = num6;
											T2 val9 = val8;
											T2 val10 = val6;
											val6 = val9;
											val8 = val10;
										}
										T2 val11 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.CircumCenter(val4, val6, val8);
										for (int m = 0; m < positions.Length; m++)
										{
											dist[m] = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.distancesq(val11, positions[m]);
										}
										array.Sort(new DistComparer(dist));
										hullStart = num2;
										ref NativeArray<int> reference = ref hullNext;
										int index = num2;
										num6 = (hullPrev[num4] = num3);
										reference[index] = num6;
										ref NativeArray<int> reference2 = ref hullNext;
										int index2 = num3;
										num6 = (hullPrev[num2] = num4);
										reference2[index2] = num6;
										ref NativeArray<int> reference3 = ref hullNext;
										int index3 = num4;
										num6 = (hullPrev[num3] = num2);
										reference3[index3] = num6;
										hullTri[num2] = 0;
										hullTri[num3] = 1;
										hullTri[num4] = 2;
										hullHash[UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.hashkey(val4, val11, hashSize)] = num2;
										hullHash[UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.hashkey(val6, val11, hashSize)] = num3;
										hullHash[UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.hashkey(val8, val11, hashSize)] = num4;
										AddTriangle(num2, num3, num4, -1, -1, -1);
										for (int n = 0; n < array.Length; n++)
										{
											int num10 = array[n];
											if (num10 == num2 || num10 == num3 || num10 == num4)
											{
												continue;
											}
											T2 val12 = positions[num10];
											int num11 = 0;
											int num12 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.hashkey(val12, val11, hashSize);
											for (int num13 = 0; num13 < hashSize; num13++)
											{
												num11 = hullHash[(num12 + num13) % hashSize];
												if (num11 != -1 && num11 != hullNext[num11])
												{
													break;
												}
											}
											num11 = hullPrev[num11];
											int num14 = num11;
											int num15 = hullNext[num14];
											while (!UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.less(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.Orient2dFast(val12, positions[num14], positions[num15]), UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.ZeroTBig()))
											{
												num14 = num15;
												if (num14 == num11)
												{
													num14 = int.MaxValue;
													break;
												}
												num15 = hullNext[num14];
											}
											if (num14 == int.MaxValue)
											{
												continue;
											}
											int num16 = AddTriangle(num14, num10, hullNext[num14], -1, -1, hullTri[num14]);
											hullTri[num10] = Legalize(num16 + 2);
											hullTri[num14] = num16;
											int num17 = hullNext[num14];
											num15 = hullNext[num17];
											while (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.less(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.Orient2dFast(val12, positions[num17], positions[num15]), UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.ZeroTBig()))
											{
												num16 = AddTriangle(num17, num10, num15, hullTri[num10], -1, hullTri[num17]);
												hullTri[num10] = Legalize(num16 + 2);
												hullNext[num17] = num17;
												num17 = num15;
												num15 = hullNext[num17];
											}
											if (num14 == num11)
											{
												num15 = hullPrev[num14];
												while (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.less(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.Orient2dFast(val12, positions[num15], positions[num14]), UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.ZeroTBig()))
												{
													num16 = AddTriangle(num15, num10, num14, -1, hullTri[num14], hullTri[num15]);
													Legalize(num16 + 2);
													hullTri[num15] = num16;
													hullNext[num14] = num14;
													num14 = num15;
													num15 = hullPrev[num14];
												}
											}
											num6 = (hullPrev[num10] = num14);
											hullStart = num6;
											ref NativeArray<int> reference4 = ref hullNext;
											int index4 = num14;
											num6 = (hullPrev[num17] = num10);
											reference4[index4] = num6;
											hullNext[num10] = num17;
											hullHash[UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.hashkey(val12, val11, hashSize)] = num10;
											hullHash[UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.hashkey(positions[num14], val11, hashSize)] = num14;
										}
										triangles.Length = trianglesLen;
										halfedges.Length = trianglesLen;
										constrainedHalfedges.Length = trianglesLen;
										array.Dispose();
										dist.Dispose();
									}
								}
							}
						}
					}
				}
			}

			private int Legalize(int a)
			{
				int num = 0;
				int num4;
				while (true)
				{
					int num2 = halfedges[a];
					int num3 = a - a % 3;
					num4 = num3 + (a + 2) % 3;
					if (num2 == -1)
					{
						if (num == 0)
						{
							break;
						}
						a = EDGE_STACK[--num];
						continue;
					}
					int num5 = num2 - num2 % 3;
					int index = num3 + (a + 1) % 3;
					int num6 = num5 + (num2 + 2) % 3;
					int num7 = triangles[num4];
					int index2 = triangles[a];
					int index3 = triangles[index];
					int num8 = triangles[num6];
					if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.InCircle(positions[num7], positions[index2], positions[index3], positions[num8]))
					{
						triangles[a] = num8;
						triangles[num2] = num7;
						int num9 = halfedges[num6];
						if (num9 == -1)
						{
							int num10 = hullStart;
							do
							{
								if (hullTri[num10] == num6)
								{
									hullTri[num10] = a;
									break;
								}
								num10 = hullPrev[num10];
							}
							while (num10 != hullStart);
						}
						Link(a, num9);
						Link(num2, halfedges[num4]);
						Link(num4, num6);
						int value = num5 + (num2 + 1) % 3;
						if (num < EDGE_STACK.Length)
						{
							EDGE_STACK[num++] = value;
						}
					}
					else
					{
						if (num == 0)
						{
							break;
						}
						a = EDGE_STACK[--num];
					}
				}
				return num4;
			}

			private int AddTriangle(int i0, int i1, int i2, int a, int b, int c)
			{
				int num = trianglesLen;
				triangles[num] = i0;
				triangles[num + 1] = i1;
				triangles[num + 2] = i2;
				Link(num, a);
				Link(num + 1, b);
				Link(num + 2, c);
				trianglesLen += 3;
				return num;
			}

			private void Link(int a, int b)
			{
				halfedges[a] = b;
				if (b != -1)
				{
					halfedges[b] = a;
				}
			}
		}

		private struct ConstrainEdgesStep
		{
			private NativeReference<Status> status;

			private NativeArray<T2>.ReadOnly positions;

			private NativeArray<int> triangles;

			private NativeArray<int>.ReadOnly inputConstraintEdges;

			private NativeArray<ConstraintType>.ReadOnly inputConstraintEdgeTypes;

			private NativeList<int> halfedges;

			private NativeList<HalfedgeState> constrainedHalfedges;

			private readonly Args args;

			private NativeList<int> intersections;

			private NativeList<int> unresolvedIntersections;

			private NativeArray<int> pointToHalfedge;

			public ConstrainEdgesStep(InputData<T2> input, OutputData<T2> output, Args args)
			{
				status = output.Status;
				positions = output.Positions.AsReadOnly();
				triangles = output.Triangles.AsArray();
				inputConstraintEdges = input.ConstraintEdges.AsReadOnly();
				inputConstraintEdgeTypes = input.ConstraintEdgeTypes.AsReadOnly();
				halfedges = output.Halfedges;
				constrainedHalfedges = output.ConstrainedHalfedges;
				this.args = args;
				intersections = default(NativeList<int>);
				unresolvedIntersections = default(NativeList<int>);
				pointToHalfedge = default(NativeArray<int>);
			}

			public void Execute(Allocator allocator)
			{
				if (!inputConstraintEdges.IsCreated || status.Value.IsError)
				{
					return;
				}
				using (Markers.ConstrainEdgesStep.Auto())
				{
					using (intersections = new NativeList<int>(allocator))
					{
						using (unresolvedIntersections = new NativeList<int>(allocator))
						{
							using (pointToHalfedge = new NativeArray<int>(positions.Length, allocator))
							{
								for (int i = 0; i < triangles.Length; i++)
								{
									pointToHalfedge[triangles[i]] = i;
								}
								for (int j = 0; j < inputConstraintEdges.Length / 2; j++)
								{
									int2 int5 = math.int2(inputConstraintEdges[2 * j], inputConstraintEdges[2 * j + 1]);
									int5 = ((int5.x < int5.y) ? int5.xy : int5.yx);
									ConstraintType constraintType = ((!inputConstraintEdgeTypes.IsCreated) ? ConstraintType.ConstrainedAndHoleBoundary : inputConstraintEdgeTypes[j]);
									TryApplyConstraint(int5, (constraintType == ConstraintType.Constrained) ? HalfedgeState.Constrained : HalfedgeState.ConstrainedAndHoleBoundary);
								}
							}
						}
					}
				}
			}

			private void TryResolveIntersections(int2 c, HalfedgeState constrainValue, ref int iter)
			{
				for (int i = 0; i < intersections.Length; i++)
				{
					if (IsMaxItersExceeded(iter++, args.SloanMaxIters))
					{
						return;
					}
					int value = intersections[i];
					int num = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(value);
					int value2 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num);
					int num2 = halfedges[value];
					int num3 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num2);
					int num4 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num3);
					int index = triangles[value];
					int index2 = triangles[num];
					int num5 = triangles[value2];
					int num6 = triangles[num4];
					T2 val = positions[index];
					T2 val2 = positions[num6];
					T2 val3 = positions[index2];
					T2 val4 = positions[num5];
					T2 a = val;
					T2 b = val2;
					T2 c2 = val3;
					T2 d = val4;
					if (!UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.IsConvexQuadrilateral(a, b, c2, d))
					{
						unresolvedIntersections.Add(in value);
						continue;
					}
					triangles[value] = num6;
					triangles[num2] = num5;
					pointToHalfedge[num6] = value;
					pointToHalfedge[num5] = num2;
					pointToHalfedge[index] = num3;
					pointToHalfedge[index2] = num;
					ReplaceHalfedge(num4, value);
					ReplaceHalfedge(value2, num2);
					halfedges[value2] = num4;
					halfedges[num4] = value2;
					constrainedHalfedges[value2] = HalfedgeState.Unconstrained;
					constrainedHalfedges[num4] = HalfedgeState.Unconstrained;
					for (int j = i + 1; j < intersections.Length; j++)
					{
						int num7 = intersections[j];
						intersections[j] = ((num7 == value2) ? num2 : ((num7 == num4) ? value : num7));
					}
					for (int k = 0; k < unresolvedIntersections.Length; k++)
					{
						int num8 = unresolvedIntersections[k];
						unresolvedIntersections[k] = ((num8 == value2) ? num2 : ((num8 == num4) ? value : num8));
					}
					int2 e = math.int2(num5, num6);
					if (math.all(c.xy == e.xy) || math.all(c.xy == e.yx))
					{
						constrainedHalfedges[value2] = constrainValue;
						constrainedHalfedges[num4] = constrainValue;
					}
					if (EdgeEdgeIntersection(c, e))
					{
						unresolvedIntersections.Add(in value2);
					}
				}
				intersections.Clear();
			}

			private void ReplaceHalfedge(int h0, int h1)
			{
				int num = halfedges[h0];
				halfedges[h1] = num;
				constrainedHalfedges[h1] = constrainedHalfedges[h0];
				if (num != -1)
				{
					halfedges[num] = h1;
					constrainedHalfedges[num] = constrainedHalfedges[h0];
				}
			}

			private bool EdgeEdgeIntersection(int2 e1, int2 e2)
			{
				T2 val = positions[e1.x];
				T2 val2 = positions[e1.y];
				T2 a = val;
				T2 a2 = val2;
				val = positions[e2.x];
				T2 val3 = positions[e2.y];
				T2 b = val;
				T2 b2 = val3;
				if (!math.any((e1.xy == e2.xy) | (e1.xy == e2.yx)))
				{
					return UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.EdgeEdgeIntersection(a, a2, b, b2);
				}
				return false;
			}

			private void MarkHalfedgeConstrained(int halfedge, HalfedgeState constrainValue)
			{
				constrainValue = (HalfedgeState)math.max((int)constrainedHalfedges[halfedge], (int)constrainValue);
				constrainedHalfedges[halfedge] = constrainValue;
				int num = halfedges[halfedge];
				if (num != -1)
				{
					constrainedHalfedges[num] = constrainValue;
				}
			}

			private void TryApplyConstraint(int2 edge, HalfedgeState constrainValue)
			{
				intersections.Clear();
				unresolvedIntersections.Clear();
				int num = -1;
				int x = edge.x;
				int y = edge.y;
				int num2 = x;
				int num3 = y;
				int num4 = pointToHalfedge[num2];
				int num5 = num4;
				do
				{
					int value = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num5);
					if (triangles[value] == num3)
					{
						MarkHalfedgeConstrained(num5, constrainValue);
						break;
					}
					int num6 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(value);
					if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.PointLineSegmentIntersection(positions[triangles[value]], positions[num2], positions[num3]))
					{
						MarkHalfedgeConstrained(num5, constrainValue);
						num3 = triangles[value];
						break;
					}
					if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.PointLineSegmentIntersection(positions[triangles[num6]], positions[num2], positions[num3]) && triangles[num6] != num3)
					{
						MarkHalfedgeConstrained(num6, constrainValue);
						num3 = triangles[num6];
						break;
					}
					if (EdgeEdgeIntersection(new int2(num2, num3), new int2(triangles[value], triangles[num6])))
					{
						unresolvedIntersections.Add(in value);
						num = halfedges[value];
						break;
					}
					num5 = halfedges[num6];
					if (num5 == -1)
					{
						if (triangles[num6] == num3)
						{
							MarkHalfedgeConstrained(num6, constrainValue);
						}
						break;
					}
				}
				while (num5 != num4);
				num5 = halfedges[num4];
				if (num == -1 && num5 != -1)
				{
					num5 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num5);
					do
					{
						int value2 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num5);
						if (triangles[value2] == num3)
						{
							MarkHalfedgeConstrained(num5, constrainValue);
							break;
						}
						int num7 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(value2);
						if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.PointLineSegmentIntersection(positions[triangles[value2]], positions[num2], positions[num3]))
						{
							MarkHalfedgeConstrained(num5, constrainValue);
							num3 = triangles[value2];
							break;
						}
						if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.PointLineSegmentIntersection(positions[triangles[num7]], positions[num2], positions[num3]) && triangles[num7] != num3)
						{
							MarkHalfedgeConstrained(num7, constrainValue);
							num3 = triangles[num7];
							break;
						}
						if (EdgeEdgeIntersection(new int2(num2, num3), new int2(triangles[value2], triangles[num7])))
						{
							unresolvedIntersections.Add(in value2);
							num = halfedges[value2];
							break;
						}
						num5 = halfedges[num5];
						if (num5 == -1)
						{
							break;
						}
						num5 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num5);
					}
					while (num5 != num4);
				}
				while (num != -1)
				{
					int num8 = num;
					num = -1;
					int value3 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num8);
					int value4 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(value3);
					if (triangles[value4] == num3)
					{
						break;
					}
					if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.PointLineSegmentIntersection(positions[triangles[value4]], positions[num2], positions[num3]))
					{
						num3 = triangles[value4];
						break;
					}
					if (EdgeEdgeIntersection(new int2(num2, num3), new int2(triangles[value3], triangles[value4])))
					{
						unresolvedIntersections.Add(in value3);
						num = halfedges[value3];
					}
					else if (EdgeEdgeIntersection(new int2(num2, num3), new int2(triangles[value4], triangles[num8])))
					{
						unresolvedIntersections.Add(in value4);
						num = halfedges[value4];
					}
				}
				int iter = 0;
				do
				{
					if (status.Value.IsError)
					{
						return;
					}
					NativeList<int> nativeList = unresolvedIntersections;
					NativeList<int> nativeList2 = intersections;
					intersections = nativeList;
					unresolvedIntersections = nativeList2;
					TryResolveIntersections(new int2(num2, num3), constrainValue, ref iter);
				}
				while (!unresolvedIntersections.IsEmpty);
				if (edge.y != num3)
				{
					TryApplyConstraint(new int2(num3, edge.y), constrainValue);
				}
			}

			private bool IsMaxItersExceeded(int iter, int maxIters)
			{
				if (iter >= maxIters)
				{
					status.Value = Status.SloanMaxItersExceeded;
					return true;
				}
				return false;
			}
		}

		private struct PlantingSeedStep
		{
			private NativeReference<Status> status;

			private NativeList<int> triangles;

			[ReadOnly]
			private NativeList<T2> positions;

			private NativeList<HalfedgeState> constrainedHalfedges;

			private NativeList<int> halfedges;

			private NativeArray<bool> shouldRemoveTriangle;

			private NativeQueue<int> trianglesQueue;

			private NativeArray<T2> holes;

			private bool anyRemovedTriangles;

			private readonly Args args;

			public PlantingSeedStep(InputData<T2> input, OutputData<T2> output, Args args)
				: this(output, args, input.HoleSeeds)
			{
			}

			public PlantingSeedStep(OutputData<T2> output, Args args, NativeArray<T2> localHoles)
			{
				status = output.Status;
				triangles = output.Triangles;
				positions = output.Positions;
				constrainedHalfedges = output.ConstrainedHalfedges;
				halfedges = output.Halfedges;
				holes = localHoles;
				this.args = args;
				shouldRemoveTriangle = default(NativeArray<bool>);
				trianglesQueue = default(NativeQueue<int>);
				anyRemovedTriangles = false;
			}

			public void Execute(Allocator allocator, bool constraintsIsCreated)
			{
				if (!constraintsIsCreated || (status.IsCreated && status.Value.IsError))
				{
					return;
				}
				using (Markers.PlantingSeedStep.Auto())
				{
					using (shouldRemoveTriangle = new NativeArray<bool>(triangles.Length / 3, allocator))
					{
						if (args.AutoHolesAndBoundary)
						{
							PlantAuto(allocator);
						}
						if (holes.IsCreated || args.RestoreBoundary)
						{
							trianglesQueue = new NativeQueue<int>(allocator);
							if (holes.IsCreated)
							{
								PlantHoleSeeds(holes);
							}
							if (args.RestoreBoundary)
							{
								PlantBoundarySeeds();
							}
							trianglesQueue.Dispose();
						}
						RemoveVisitedTriangles(allocator);
					}
				}
			}

			private void PlantBoundarySeeds()
			{
				for (int i = 0; i < halfedges.Length; i++)
				{
					if (halfedges[i] == -1 && !shouldRemoveTriangle[i / 3] && constrainedHalfedges[i] != HalfedgeState.ConstrainedAndHoleBoundary)
					{
						PlantSeed(i / 3);
					}
				}
			}

			private void PlantHoleSeeds(NativeArray<T2> holeSeeds)
			{
				foreach (T2 item in holeSeeds)
				{
					int num = FindTriangle(item);
					if (num != -1)
					{
						PlantSeed(num);
					}
				}
			}

			private void RemoveVisitedTriangles(Allocator allocator)
			{
				if (!anyRemovedTriangles)
				{
					return;
				}
				NativeArray<int> indexRemap = new NativeArray<int>(triangles.Length / 3, allocator);
				int num = 0;
				for (int i = 0; i < shouldRemoveTriangle.Length; i++)
				{
					indexRemap[i] = (shouldRemoveTriangle[i] ? (-1) : num++);
				}
				NativeArray<bool3> nativeArray = constrainedHalfedges.AsArray().Reinterpret<bool3>(1);
				NativeArray<int3> nativeArray2 = triangles.AsArray().Reinterpret<int3>(4);
				for (int j = 0; j < indexRemap.Length; j++)
				{
					int num2 = indexRemap[j];
					if (num2 != -1)
					{
						nativeArray2[num2] = nativeArray2[j];
						nativeArray[num2] = nativeArray[j];
						halfedges[3 * num2] = RemapHalfedge(halfedges[3 * j]);
						halfedges[3 * num2 + 1] = RemapHalfedge(halfedges[3 * j + 1]);
						halfedges[3 * num2 + 2] = RemapHalfedge(halfedges[3 * j + 2]);
					}
				}
				triangles.Length = 3 * num;
				constrainedHalfedges.Length = 3 * num;
				halfedges.Length = 3 * num;
				indexRemap.Dispose();
				int RemapHalfedge(int he)
				{
					if (he == -1)
					{
						return -1;
					}
					int num3 = indexRemap[he / 3];
					if (num3 != -1)
					{
						return 3 * num3 + he % 3;
					}
					return -1;
				}
			}

			private void PlantSeed(int tId)
			{
				NativeArray<bool> nativeArray = shouldRemoveTriangle;
				NativeQueue<int> nativeQueue = trianglesQueue;
				if (nativeArray[tId])
				{
					return;
				}
				nativeArray[tId] = true;
				nativeQueue.Enqueue(tId);
				anyRemovedTriangles = true;
				while (nativeQueue.TryDequeue(out tId))
				{
					for (int i = 0; i < 3; i++)
					{
						int index = 3 * tId + i;
						int num = halfedges[index];
						if (constrainedHalfedges[index] != HalfedgeState.ConstrainedAndHoleBoundary && num != -1)
						{
							int num2 = num / 3;
							if (!nativeArray[num2])
							{
								nativeArray[num2] = true;
								nativeQueue.Enqueue(num2);
							}
						}
					}
				}
			}

			private int FindTriangle(T2 p)
			{
				for (int i = 0; i < triangles.Length / 3; i++)
				{
					int num = triangles[3 * i];
					int num2 = triangles[3 * i + 1];
					int num3 = triangles[3 * i + 2];
					int index = num;
					int index2 = num2;
					int index3 = num3;
					T2 val = positions[index];
					T2 val2 = positions[index2];
					T2 val3 = positions[index3];
					T2 a = val;
					T2 b = val2;
					T2 c = val3;
					if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.PointInsideTriangle(p, a, b, c))
					{
						return i;
					}
				}
				return -1;
			}

			private void PlantAuto(Allocator allocator)
			{
				int num = triangles.Length / 3;
				NativeQueue<int> nativeQueue = new NativeQueue<int>(allocator);
				NativeQueue<int> nativeQueue2 = new NativeQueue<int>(allocator);
				NativeArray<bool> nativeArray = new NativeArray<bool>(num, allocator);
				for (int i = 0; i < num; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						if (halfedges[3 * i + j] == -1)
						{
							((constrainedHalfedges[3 * i + j] == HalfedgeState.ConstrainedAndHoleBoundary) ? nativeQueue2 : nativeQueue).Enqueue(i);
							nativeArray[i] = true;
							break;
						}
					}
				}
				bool flag = false;
				bool flag2 = true;
				while (!nativeQueue.IsEmpty() || !nativeQueue2.IsEmpty())
				{
					int item;
					while (nativeQueue.TryDequeue(out item))
					{
						if (flag2)
						{
							shouldRemoveTriangle[item] = true;
							flag = true;
						}
						for (int k = 0; k < 3; k++)
						{
							int index = 3 * item + k;
							int num2 = halfedges[index];
							int num3 = num2 / 3;
							if (num2 != -1 && !nativeArray[num3])
							{
								((constrainedHalfedges[index] == HalfedgeState.ConstrainedAndHoleBoundary) ? nativeQueue2 : nativeQueue).Enqueue(num3);
								nativeArray[num3] = true;
							}
						}
					}
					NativeQueue<int> nativeQueue3 = nativeQueue2;
					NativeQueue<int> nativeQueue4 = nativeQueue;
					nativeQueue = nativeQueue3;
					nativeQueue2 = nativeQueue4;
					flag2 = !flag2;
				}
				anyRemovedTriangles = flag;
				nativeQueue.Dispose();
				nativeQueue2.Dispose();
				nativeArray.Dispose();
			}
		}

		private struct RefineMeshStep
		{
			private readonly struct Circle
			{
				public readonly T2 Center;

				public readonly T RadiusSq;

				public Circle((T2 center, T radiusSq) circle)
				{
					T2 item = circle.center;
					T item2 = circle.radiusSq;
					Center = item;
					RadiusSq = item2;
				}
			}

			private NativeReference<Status> status;

			private NativeList<int> triangles;

			private NativeList<T2> outputPositions;

			private NativeList<int> halfedges;

			private NativeList<HalfedgeState> constrainedHalfedges;

			private NativeList<Circle> circles;

			private NativeQueue<int> trianglesQueue;

			private NativeList<int> badTriangles;

			private NativeList<int> pathPoints;

			private NativeList<int> pathHalfedges;

			private NativeList<bool> visitedTriangles;

			private readonly T maximumArea2;

			private readonly T angleThreshold;

			private readonly int initialPointsCount;

			private const float ConcentricShellReferenceRadius = 0.001f;

			public RefineMeshStep(OutputData<T2> output, Args args, TTransform lt)
				: this(output, UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.Cast(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.mul(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.Cast(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.mul(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.Const(2f), UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.Const(args.RefinementThresholdArea))), lt.AreaScalingFactor)), UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.Const(args.RefinementThresholdAngle))
			{
			}

			public RefineMeshStep(OutputData<T2> output, T area2Threshold, T angleThreshold)
			{
				status = output.Status;
				initialPointsCount = output.Positions.Length;
				maximumArea2 = area2Threshold;
				this.angleThreshold = angleThreshold;
				triangles = output.Triangles;
				outputPositions = output.Positions;
				halfedges = output.Halfedges;
				constrainedHalfedges = output.ConstrainedHalfedges;
				circles = default(NativeList<Circle>);
				trianglesQueue = default(NativeQueue<int>);
				badTriangles = default(NativeList<int>);
				pathPoints = default(NativeList<int>);
				pathHalfedges = default(NativeList<int>);
				visitedTriangles = default(NativeList<bool>);
			}

			public void Execute(Allocator allocator, bool refineMesh, bool constrainBoundary)
			{
				if (!refineMesh || (status.IsCreated && status.Value.IsError))
				{
					return;
				}
				using (Markers.RefineMeshStep.Auto())
				{
					if (!UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.SupportsRefinement())
					{
						status.Value = Status.IntegersDoNotSupportMeshRefinement;
						return;
					}
					if (constrainBoundary)
					{
						for (int i = 0; i < constrainedHalfedges.Length; i++)
						{
							constrainedHalfedges[i] = ((halfedges[i] == -1) ? HalfedgeState.ConstrainedAndHoleBoundary : HalfedgeState.Unconstrained);
						}
					}
					using (circles = new NativeList<Circle>(allocator)
					{
						Length = triangles.Length / 3
					})
					{
						using (trianglesQueue = new NativeQueue<int>(allocator))
						{
							using (badTriangles = new NativeList<int>(triangles.Length / 3, allocator))
							{
								using (pathPoints = new NativeList<int>(allocator))
								{
									using (pathHalfedges = new NativeList<int>(allocator))
									{
										using (visitedTriangles = new NativeList<bool>(triangles.Length / 3, allocator))
										{
											using NativeList<int> heQueue = new NativeList<int>(triangles.Length, allocator);
											using NativeList<int> tQueue = new NativeList<int>(triangles.Length, allocator);
											for (int j = 0; j < triangles.Length / 3; j++)
											{
												int num = triangles[3 * j];
												int num2 = triangles[3 * j + 1];
												int num3 = triangles[3 * j + 2];
												int i2 = num;
												int j2 = num2;
												int k = num3;
												circles[j] = new Circle(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.CalculateCircumCircle(i2, j2, k, outputPositions.AsArray()));
											}
											for (int l = 0; l < constrainedHalfedges.Length; l++)
											{
												if ((int)constrainedHalfedges[l] >= 1 && IsEncroached(l))
												{
													heQueue.Add(in l);
												}
											}
											SplitEncroachedEdges(heQueue, default(NativeList<int>));
											for (int m = 0; m < triangles.Length / 3; m++)
											{
												if (IsBadTriangle(m))
												{
													tQueue.Add(in m);
												}
											}
											for (int n = 0; n < tQueue.Length; n++)
											{
												int num4 = tQueue[n];
												if (num4 != -1)
												{
													SplitTriangle(num4, heQueue, tQueue, allocator);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}

			private void SplitEncroachedEdges(NativeList<int> heQueue, NativeList<int> tQueue)
			{
				for (int i = 0; i < heQueue.Length; i++)
				{
					int num = heQueue[i];
					if (num != -1)
					{
						SplitEdge(num, heQueue, tQueue);
					}
				}
				heQueue.Clear();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private bool IsEncroached(int he0)
			{
				int num = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(he0);
				int index = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num);
				T2 a = outputPositions[triangles[he0]];
				T2 a2 = outputPositions[triangles[num]];
				T2 b = outputPositions[triangles[index]];
				return UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.le(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.dot(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.diff(a, b), UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.diff(a2, b)), UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.Zero());
			}

			private void SplitEdge(int he, NativeList<int> heQueue, NativeList<int> tQueue)
			{
				int num = triangles[he];
				int num2 = triangles[UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(he)];
				int num3 = num;
				int num4 = num2;
				T2 val = outputPositions[num3];
				T2 val2 = outputPositions[num4];
				T2 val3 = val;
				T2 val4 = val2;
				T2 p;
				if ((num3 < initialPointsCount && num4 < initialPointsCount) || (num3 >= initialPointsCount && num4 >= initialPointsCount))
				{
					p = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.avg(val3, val4);
				}
				else
				{
					T v = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.alpha(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.Const(0.001f), UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.Cast(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.distancesq(val3, val4)));
					p = ((num3 < initialPointsCount) ? UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.lerp(val3, val4, v) : UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.lerp(val4, val3, v));
				}
				constrainedHalfedges[he] = HalfedgeState.Unconstrained;
				int num5 = halfedges[he];
				if (num5 != -1)
				{
					constrainedHalfedges[num5] = HalfedgeState.Unconstrained;
				}
				if (halfedges[he] != -1)
				{
					UnsafeInsertPointBulk(p, he / 3, heQueue, tQueue);
					int num6 = triangles.Length - 3;
					int value = -1;
					int value2 = -1;
					while (value == -1 || value2 == -1)
					{
						int num7 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num6);
						if (triangles[num7] == num3)
						{
							value = num6;
						}
						if (triangles[num7] == num4)
						{
							value2 = num6;
						}
						int index = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num7);
						num6 = halfedges[index];
					}
					if (IsEncroached(value))
					{
						heQueue.Add(in value);
					}
					int value3 = halfedges[value];
					if (IsEncroached(value3))
					{
						heQueue.Add(in value3);
					}
					if (IsEncroached(value2))
					{
						heQueue.Add(in value2);
					}
					int value4 = halfedges[value2];
					if (IsEncroached(value4))
					{
						heQueue.Add(in value4);
					}
					constrainedHalfedges[value] = HalfedgeState.Constrained;
					constrainedHalfedges[value3] = HalfedgeState.Constrained;
					constrainedHalfedges[value2] = HalfedgeState.Constrained;
					constrainedHalfedges[value4] = HalfedgeState.Constrained;
				}
				else
				{
					UnsafeInsertPointBoundary(p, he, heQueue, tQueue);
					int num8 = 3 * (pathPoints.Length - 1);
					int value5 = halfedges.Length - 1;
					int value6 = halfedges.Length - num8;
					if (IsEncroached(value5))
					{
						heQueue.Add(in value5);
					}
					if (IsEncroached(value6))
					{
						heQueue.Add(in value6);
					}
					constrainedHalfedges[value5] = HalfedgeState.Constrained;
					constrainedHalfedges[value6] = HalfedgeState.Constrained;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private bool IsBadTriangle(int tId)
			{
				int num = triangles[3 * tId];
				int num2 = triangles[3 * tId + 1];
				int num3 = triangles[3 * tId + 2];
				int index = num;
				int index2 = num2;
				int index3 = num3;
				T2 val = outputPositions[index];
				T2 val2 = outputPositions[index2];
				T2 val3 = outputPositions[index3];
				T2 a = val;
				T2 b = val2;
				T2 c = val3;
				T a2 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.Area2(a, b, c);
				if (!UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.greater(a2, maximumArea2))
				{
					return AngleIsTooSmall(tId, angleThreshold);
				}
				return true;
			}

			private void SplitTriangle(int tId, NativeList<int> heQueue, NativeList<int> tQueue, Allocator allocator)
			{
				Circle circle = circles[tId];
				NativeList<int> nativeList = new NativeList<int>(allocator);
				for (int i = 0; i < constrainedHalfedges.Length; i++)
				{
					if (constrainedHalfedges[i] == HalfedgeState.Unconstrained)
					{
						continue;
					}
					int num = triangles[i];
					int num2 = triangles[UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(i)];
					int num3 = num;
					int num4 = num2;
					if (halfedges[i] == -1 || num3 < num4)
					{
						T2 val = outputPositions[num3];
						T2 val2 = outputPositions[num4];
						T2 a = val;
						T2 a2 = val2;
						if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.le(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.dot(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.diff(a, circle.Center), UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.diff(a2, circle.Center)), UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.Zero()))
						{
							nativeList.Add(in i);
						}
					}
				}
				if (nativeList.IsEmpty)
				{
					UnsafeInsertPointBulk(circle.Center, tId, heQueue, tQueue);
				}
				else
				{
					int num = triangles[3 * tId];
					int num5 = triangles[3 * tId + 1];
					int num6 = triangles[3 * tId + 2];
					int index = num;
					int index2 = num5;
					int index3 = num6;
					T2 val = outputPositions[index];
					T2 val3 = outputPositions[index2];
					T2 val4 = outputPositions[index3];
					T2 a3 = val;
					T2 b = val3;
					T2 c = val4;
					T a4 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.Area2(a3, b, c);
					if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.greater(a4, maximumArea2))
					{
						foreach (int item in nativeList.AsReadOnly())
						{
							heQueue.Add(item);
						}
					}
					if (!heQueue.IsEmpty)
					{
						tQueue.Add(in tId);
						SplitEncroachedEdges(heQueue, tQueue);
					}
				}
				nativeList.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private bool AngleIsTooSmall(int tId, T minimumAngle)
			{
				int num = triangles[3 * tId];
				int num2 = triangles[3 * tId + 1];
				int num3 = triangles[3 * tId + 2];
				int index = num;
				int index2 = num2;
				int index3 = num3;
				T2 val = outputPositions[index];
				T2 val2 = outputPositions[index2];
				T2 val3 = outputPositions[index3];
				T2 pA = val;
				T2 pB = val2;
				T2 pC = val3;
				return UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.AngleIsTooSmall(pA, pB, pC, minimumAngle);
			}

			private int UnsafeInsertPointCommon(T2 p, int initTriangle)
			{
				int length = outputPositions.Length;
				outputPositions.Add(in p);
				badTriangles.Clear();
				trianglesQueue.Clear();
				pathPoints.Clear();
				pathHalfedges.Clear();
				visitedTriangles.Clear();
				visitedTriangles.Length = triangles.Length / 3;
				trianglesQueue.Enqueue(initTriangle);
				badTriangles.Add(in initTriangle);
				visitedTriangles[initTriangle] = true;
				RecalculateBadTriangles(p);
				return length;
			}

			private void UnsafeInsertPointBulk(T2 p, int initTriangle, NativeList<int> heQueue = default(NativeList<int>), NativeList<int> tQueue = default(NativeList<int>))
			{
				int pId = UnsafeInsertPointCommon(p, initTriangle);
				BuildStarPolygon();
				ProcessBadTriangles(heQueue, tQueue);
				BuildNewTrianglesForStar(pId, heQueue, tQueue);
			}

			private void UnsafeInsertPointBoundary(T2 p, int initHe, NativeList<int> heQueue = default(NativeList<int>), NativeList<int> tQueue = default(NativeList<int>))
			{
				int pId = UnsafeInsertPointCommon(p, initHe / 3);
				BuildAmphitheaterPolygon(initHe);
				ProcessBadTriangles(heQueue, tQueue);
				BuildNewTrianglesForAmphitheater(pId, heQueue, tQueue);
			}

			private void RecalculateBadTriangles(T2 p)
			{
				int item;
				while (trianglesQueue.TryDequeue(out item))
				{
					VisitEdge(p, 3 * item);
					VisitEdge(p, 3 * item + 1);
					VisitEdge(p, 3 * item + 2);
				}
			}

			private void VisitEdge(T2 p, int t0)
			{
				int num = halfedges[t0];
				if (num == -1 || (int)constrainedHalfedges[num] >= 1)
				{
					return;
				}
				int value = num / 3;
				if (!visitedTriangles[value])
				{
					Circle circle = circles[value];
					if (UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.le(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.Cast(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.utils.distancesq(circle.Center, p)), circle.RadiusSq))
					{
						badTriangles.Add(in value);
						trianglesQueue.Enqueue(value);
						visitedTriangles[value] = true;
					}
				}
			}

			private void BuildAmphitheaterPolygon(int initHe)
			{
				int num = initHe;
				int num2 = triangles[num];
				while (true)
				{
					num = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num);
					if (triangles[num] == num2)
					{
						break;
					}
					int value = halfedges[num];
					if (value == -1 || !badTriangles.Contains(value / 3))
					{
						pathPoints.Add(triangles[num]);
						pathHalfedges.Add(in value);
					}
					else
					{
						num = value;
					}
				}
				pathPoints.Add(triangles[initHe]);
				pathHalfedges.Add(-1);
			}

			private void BuildStarPolygon()
			{
				int num = -1;
				for (int i = 0; i < badTriangles.Length; i++)
				{
					int num2 = badTriangles[i];
					for (int j = 0; j < 3; j++)
					{
						int num3 = 3 * num2 + j;
						int value = halfedges[num3];
						if (value == -1 || !badTriangles.Contains(value / 3))
						{
							pathPoints.Add(triangles[num3]);
							pathHalfedges.Add(in value);
							num = num3;
							break;
						}
					}
					if (num != -1)
					{
						break;
					}
				}
				int num4 = num;
				int num5 = pathPoints[0];
				while (true)
				{
					num4 = UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.NextHalfedge(num4);
					if (triangles[num4] != num5)
					{
						int value2 = halfedges[num4];
						if (value2 == -1 || !badTriangles.Contains(value2 / 3))
						{
							pathPoints.Add(triangles[num4]);
							pathHalfedges.Add(in value2);
						}
						else
						{
							num4 = value2;
						}
						continue;
					}
					break;
				}
			}

			private void ProcessBadTriangles(NativeList<int> heQueue, NativeList<int> tQueue)
			{
				badTriangles.Sort();
				for (int num = badTriangles.Length - 1; num >= 0; num--)
				{
					int num2 = badTriangles[num];
					triangles.RemoveAt(3 * num2 + 2);
					triangles.RemoveAt(3 * num2 + 1);
					triangles.RemoveAt(3 * num2);
					circles.RemoveAt(num2);
					RemoveHalfedge(3 * num2 + 2, 0);
					RemoveHalfedge(3 * num2 + 1, 1);
					RemoveHalfedge(3 * num2, 2);
					constrainedHalfedges.RemoveAt(3 * num2 + 2);
					constrainedHalfedges.RemoveAt(3 * num2 + 1);
					constrainedHalfedges.RemoveAt(3 * num2);
					for (int i = 3 * num2; i < halfedges.Length; i++)
					{
						int num3 = halfedges[i];
						if (num3 != -1)
						{
							halfedges[(num3 < 3 * num2) ? num3 : i] -= 3;
						}
					}
					for (int j = 0; j < pathHalfedges.Length; j++)
					{
						if (pathHalfedges[j] > 3 * num2 + 2)
						{
							pathHalfedges[j] -= 3;
						}
					}
					if (heQueue.IsCreated)
					{
						for (int k = 0; k < heQueue.Length; k++)
						{
							int num4 = heQueue[k];
							if (num4 == 3 * num2 || num4 == 3 * num2 + 1 || num4 == 3 * num2 + 2)
							{
								heQueue[k] = -1;
							}
							else if (num4 > 3 * num2 + 2)
							{
								heQueue[k] -= 3;
							}
						}
					}
					if (tQueue.IsCreated)
					{
						for (int l = 0; l < tQueue.Length; l++)
						{
							int num5 = tQueue[l];
							if (num5 == num2)
							{
								tQueue[l] = -1;
							}
							else if (num5 > num2)
							{
								tQueue[l]--;
							}
						}
					}
				}
			}

			private void RemoveHalfedge(int he, int offset)
			{
				int num = halfedges[he];
				int num2 = ((num > he) ? (num - offset) : num);
				if (num2 > -1)
				{
					halfedges[num2] = -1;
				}
				halfedges.RemoveAt(he);
			}

			private void BuildNewTrianglesForStar(int pId, NativeList<int> heQueue, NativeList<int> tQueue)
			{
				int length = triangles.Length;
				triangles.Length += 3 * pathPoints.Length;
				circles.Length += pathPoints.Length;
				for (int i = 0; i < pathPoints.Length - 1; i++)
				{
					triangles[length + 3 * i] = pId;
					triangles[length + 3 * i + 1] = pathPoints[i];
					triangles[length + 3 * i + 2] = pathPoints[i + 1];
					circles[length / 3 + i] = new Circle(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.CalculateCircumCircle(pId, pathPoints[i], pathPoints[i + 1], outputPositions.AsArray()));
				}
				ref NativeList<int> reference = ref triangles;
				reference[reference.Length - 3] = pId;
				ref NativeList<int> reference2 = ref triangles;
				int index = reference2.Length - 2;
				ref NativeList<int> reference3 = ref pathPoints;
				reference2[index] = reference3[reference3.Length - 1];
				ref NativeList<int> reference4 = ref triangles;
				reference4[reference4.Length - 1] = pathPoints[0];
				ref NativeList<Circle> reference5 = ref circles;
				int index2 = reference5.Length - 1;
				ref NativeList<int> reference6 = ref pathPoints;
				reference5[index2] = new Circle(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.CalculateCircumCircle(pId, reference6[reference6.Length - 1], pathPoints[0], outputPositions.AsArray()));
				int length2 = halfedges.Length;
				halfedges.Length += 3 * pathPoints.Length;
				constrainedHalfedges.Length += 3 * pathPoints.Length;
				for (int j = 0; j < pathPoints.Length - 1; j++)
				{
					int num = pathHalfedges[j];
					halfedges[3 * j + 1 + length2] = num;
					if (num != -1)
					{
						halfedges[num] = 3 * j + 1 + length2;
						constrainedHalfedges[3 * j + 1 + length2] = constrainedHalfedges[num];
					}
					else
					{
						constrainedHalfedges[3 * j + 1 + length2] = HalfedgeState.Constrained;
					}
					halfedges[3 * j + 2 + length2] = 3 * j + 3 + length2;
					halfedges[3 * j + 3 + length2] = 3 * j + 2 + length2;
				}
				ref NativeList<int> reference7 = ref pathHalfedges;
				int num2 = reference7[reference7.Length - 1];
				halfedges[length2 + 3 * (pathPoints.Length - 1) + 1] = num2;
				if (num2 != -1)
				{
					halfedges[num2] = length2 + 3 * (pathPoints.Length - 1) + 1;
					constrainedHalfedges[length2 + 3 * (pathPoints.Length - 1) + 1] = constrainedHalfedges[num2];
				}
				else
				{
					constrainedHalfedges[length2 + 3 * (pathPoints.Length - 1) + 1] = HalfedgeState.Constrained;
				}
				halfedges[length2] = length2 + 3 * (pathPoints.Length - 1) + 2;
				halfedges[length2 + 3 * (pathPoints.Length - 1) + 2] = length2;
				if (!heQueue.IsCreated)
				{
					return;
				}
				for (int k = 0; k < pathPoints.Length - 1; k++)
				{
					int value = length2 + 3 * k + 1;
					if ((int)constrainedHalfedges[value] >= 1 && IsEncroached(value))
					{
						heQueue.Add(in value);
					}
					else if (tQueue.IsCreated && IsBadTriangle(value / 3))
					{
						tQueue.Add(value / 3);
					}
				}
			}

			private void BuildNewTrianglesForAmphitheater(int pId, NativeList<int> heQueue, NativeList<int> tQueue)
			{
				int length = triangles.Length;
				triangles.Length += 3 * (pathPoints.Length - 1);
				circles.Length += pathPoints.Length - 1;
				for (int i = 0; i < pathPoints.Length - 1; i++)
				{
					triangles[length + 3 * i] = pId;
					triangles[length + 3 * i + 1] = pathPoints[i];
					triangles[length + 3 * i + 2] = pathPoints[i + 1];
					circles[length / 3 + i] = new Circle(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>.CalculateCircumCircle(pId, pathPoints[i], pathPoints[i + 1], outputPositions.AsArray()));
				}
				int length2 = halfedges.Length;
				halfedges.Length += 3 * (pathPoints.Length - 1);
				constrainedHalfedges.Length += 3 * (pathPoints.Length - 1);
				for (int j = 0; j < pathPoints.Length - 2; j++)
				{
					int num = pathHalfedges[j];
					halfedges[3 * j + 1 + length2] = num;
					if (num != -1)
					{
						halfedges[num] = 3 * j + 1 + length2;
						constrainedHalfedges[3 * j + 1 + length2] = constrainedHalfedges[num];
					}
					else
					{
						constrainedHalfedges[3 * j + 1 + length2] = HalfedgeState.Constrained;
					}
					halfedges[3 * j + 2 + length2] = 3 * j + 3 + length2;
					halfedges[3 * j + 3 + length2] = 3 * j + 2 + length2;
				}
				ref NativeList<int> reference = ref pathHalfedges;
				int num2 = reference[reference.Length - 2];
				halfedges[length2 + 3 * (pathPoints.Length - 2) + 1] = num2;
				if (num2 != -1)
				{
					halfedges[num2] = length2 + 3 * (pathPoints.Length - 2) + 1;
					constrainedHalfedges[length2 + 3 * (pathPoints.Length - 2) + 1] = constrainedHalfedges[num2];
				}
				else
				{
					constrainedHalfedges[length2 + 3 * (pathPoints.Length - 2) + 1] = HalfedgeState.Constrained;
				}
				halfedges[length2] = -1;
				halfedges[length2 + 3 * (pathPoints.Length - 2) + 2] = -1;
				if (!heQueue.IsCreated)
				{
					return;
				}
				for (int k = 0; k < pathPoints.Length - 1; k++)
				{
					int value = length2 + 3 * k + 1;
					if ((int)constrainedHalfedges[value] >= 1 && IsEncroached(value))
					{
						heQueue.Add(in value);
					}
					else if (tQueue.IsCreated && IsBadTriangle(value / 3))
					{
						tQueue.Add(value / 3);
					}
				}
			}
		}

		private static readonly TUtils utils;

		public void Triangulate(InputData<T2> input, OutputData<T2> output, Args args, Allocator allocator)
		{
			NativeReference<Status> nativeReference = default(NativeReference<Status>);
			NativeList<T2> nativeList = default(NativeList<T2>);
			NativeList<int> nativeList2 = default(NativeList<int>);
			NativeList<HalfedgeState> nativeList3 = default(NativeList<HalfedgeState>);
			if (!output.Status.IsCreated)
			{
				nativeReference = (output.Status = new NativeReference<Status>(allocator));
			}
			if (!output.Positions.IsCreated)
			{
				nativeList = (output.Positions = new NativeList<T2>(16384, allocator));
			}
			if (!output.Halfedges.IsCreated)
			{
				nativeList2 = (output.Halfedges = new NativeList<int>(98304, allocator));
			}
			if (!output.ConstrainedHalfedges.IsCreated)
			{
				nativeList3 = (output.ConstrainedHalfedges = new NativeList<HalfedgeState>(98304, allocator));
			}
			output.Status.Value = Status.Ok;
			output.Triangles.Clear();
			output.Positions.Clear();
			output.Halfedges.Clear();
			output.ConstrainedHalfedges.Clear();
			PreProcessInputStep(input, output, args, out var localHoles, out var lt, allocator);
			new ValidateInputStep(input, output, args).Execute();
			new DelaunayTriangulationStep(output, args).Execute(allocator);
			new ConstrainEdgesStep(input, output, args).Execute(allocator);
			new PlantingSeedStep(output, args, localHoles).Execute(allocator, input.ConstraintEdges.IsCreated);
			new RefineMeshStep(output, args, lt).Execute(allocator, args.RefineMesh, !input.ConstraintEdges.IsCreated || !args.RestoreBoundary);
			PostProcessInputStep(output, args, lt);
			Status value = output.Status.Value;
			if (localHoles.IsCreated)
			{
				localHoles.Dispose();
			}
			if (nativeReference.IsCreated)
			{
				nativeReference.Dispose();
			}
			if (nativeList.IsCreated)
			{
				nativeList.Dispose();
			}
			if (nativeList2.IsCreated)
			{
				nativeList2.Dispose();
			}
			if (nativeList3.IsCreated)
			{
				nativeList3.Dispose();
			}
			if (args.Verbose && value.IsError)
			{
				Debug.LogError(value.ToFixedString());
			}
		}

		public void PlantHoleSeeds(InputData<T2> input, OutputData<T2> output, Args args, Allocator allocator)
		{
			new PlantingSeedStep(input, output, args).Execute(allocator, constraintsIsCreated: true);
		}

		public void RefineMesh(OutputData<T2> output, Allocator allocator, T area2Threshold, T angleThreshold, bool constrainBoundary = false)
		{
			new RefineMeshStep(output, area2Threshold, angleThreshold).Execute(allocator, refineMesh: true, constrainBoundary);
		}

		private void PreProcessInputStep(InputData<T2> input, OutputData<T2> output, Args args, out NativeArray<T2> localHoles, out TTransform lt, Allocator allocator)
		{
			using (Markers.PreProcessInputStep.Auto())
			{
				NativeList<T2> positions = output.Positions;
				positions.ResizeUninitialized(input.Positions.Length);
				if (args.Preprocessor == Preprocessor.PCA || args.Preprocessor == Preprocessor.COM)
				{
					lt = ((args.Preprocessor == Preprocessor.PCA) ? default(TTransform).CalculatePCATransformation(input.Positions) : default(TTransform).CalculateLocalTransformation(input.Positions));
					for (int i = 0; i < input.Positions.Length; i++)
					{
						positions[i] = lt.Transform(input.Positions[i]);
					}
					localHoles = (input.HoleSeeds.IsCreated ? new NativeArray<T2>(input.HoleSeeds.Length, allocator) : default(NativeArray<T2>));
					for (int j = 0; j < input.HoleSeeds.Length; j++)
					{
						localHoles[j] = lt.Transform(input.HoleSeeds[j]);
					}
				}
				else
				{
					if (args.Preprocessor != Preprocessor.None)
					{
						throw new ArgumentException();
					}
					positions.CopyFrom(in input.Positions);
					localHoles = (input.HoleSeeds.IsCreated ? new NativeArray<T2>(input.HoleSeeds, allocator) : default(NativeArray<T2>));
					lt = default(TTransform).Identity;
				}
			}
		}

		private void PostProcessInputStep(OutputData<T2> output, Args args, TTransform lt)
		{
			if (args.Preprocessor == Preprocessor.None)
			{
				return;
			}
			using (Markers.PostProcessInputStep.Auto())
			{
				TTransform val = lt.Inverse();
				for (int i = 0; i < output.Positions.Length; i++)
				{
					output.Positions[i] = val.Transform(output.Positions[i]);
				}
			}
		}

		internal static bool AngleIsTooSmall(T2 pA, T2 pB, T2 pC, T minimumAngle)
		{
			T v = utils.cos(minimumAngle);
			T2 val = utils.normalizesafe(utils.diff(pB, pA));
			T2 val2 = utils.normalizesafe(utils.diff(pC, pB));
			T2 val3 = utils.normalizesafe(utils.diff(pA, pC));
			return utils.anygreaterthan(utils.dot(val, utils.neg(val3)), utils.dot(val2, utils.neg(val)), utils.dot(val3, utils.neg(val2)), v);
		}

		internal static T Area2(T2 a, T2 b, T2 c)
		{
			return utils.abs(Cross(utils.diff(b, a), utils.diff(c, a)));
		}

		private static T Cross(T2 a, T2 b)
		{
			return utils.Cast(utils.diff(utils.mul(utils.X(a), utils.Y(b)), utils.mul(utils.Y(a), utils.X(b))));
		}

		private static TBig CircumRadiusSq(T2 a, T2 b, T2 c)
		{
			return utils.distancesq(utils.CircumCenter(a, b, c), a);
		}

		private static (T2, T) CalculateCircumCircle(int i, int j, int k, NativeArray<T2> positions)
		{
			T2 val = positions[i];
			T2 val2 = positions[j];
			T2 val3 = positions[k];
			T2 a = val;
			T2 b = val2;
			T2 c = val3;
			return (utils.CircumCenter(a, b, c), utils.Cast(CircumRadiusSq(a, b, c)));
		}

		private static bool ccw(T2 a, T2 b, T2 c)
		{
			return utils.greater(utils.mul(utils.diff(utils.Y(c), utils.Y(a)), utils.diff(utils.X(b), utils.X(a))), utils.mul(utils.diff(utils.Y(b), utils.Y(a)), utils.diff(utils.X(c), utils.X(a))));
		}

		internal static bool EdgeEdgeIntersection(T2 a0, T2 a1, T2 b0, T2 b1)
		{
			if (ccw(a0, a1, b0) != ccw(a0, a1, b1))
			{
				return ccw(b0, b1, a0) != ccw(b0, b1, a1);
			}
			return false;
		}

		private static int NextHalfedge(int he)
		{
			if (he % 3 != 2)
			{
				return he + 1;
			}
			return he - 2;
		}

		internal static bool IsConvexQuadrilateral(T2 a, T2 b, T2 c, T2 d)
		{
			if (utils.greater(utils.abs(Orient2dFast(a, c, b)), utils.EPSILON()) && utils.greater(utils.abs(Orient2dFast(a, c, d)), utils.EPSILON()) && utils.greater(utils.abs(Orient2dFast(b, d, a)), utils.EPSILON()) && utils.greater(utils.abs(Orient2dFast(b, d, c)), utils.EPSILON()))
			{
				return EdgeEdgeIntersection(a, c, b, d);
			}
			return false;
		}

		private static TBig Orient2dFast(T2 a, T2 b, T2 c)
		{
			return utils.diff(utils.mul(utils.diff(utils.Y(a), utils.Y(c)), utils.diff(utils.X(b), utils.X(c))), utils.mul(utils.diff(utils.X(a), utils.X(c)), utils.diff(utils.Y(b), utils.Y(c))));
		}

		internal static bool PointLineSegmentIntersection(T2 a, T2 b0, T2 b1)
		{
			if (utils.le(utils.abs(Orient2dFast(a, b0, b1)), utils.EPSILON()))
			{
				return math.all(utils.ge(a, utils.min(b0, b1)) & utils.le(a, utils.max(b0, b1)));
			}
			return false;
		}
	}
}
