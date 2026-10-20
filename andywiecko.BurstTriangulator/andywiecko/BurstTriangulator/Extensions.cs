using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using andywiecko.BurstTriangulator.LowLevel.Unsafe;

namespace andywiecko.BurstTriangulator
{
	public static class Extensions
	{
		[Obsolete("Use AsNativeArray(out Handle) instead! You can learn more in the project manual.")]
		public unsafe static NativeArray<T> AsNativeArray<T>(this T[] array) where T : unmanaged
		{
			NativeArray<T> result;
			fixed (T* ptr = array)
			{
				void* dataPointer = ptr;
				result = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>(dataPointer, array.Length, Allocator.None);
			}
			return result;
		}

		public unsafe static NativeArray<T> AsNativeArray<T>(this T[] array, out Handle handle) where T : unmanaged
		{
			ulong gcHandle;
			NativeArray<T> result = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>(UnsafeUtility.PinGCArrayAndGetDataAddress(array, out gcHandle), array.Length, Allocator.None);
			handle = new Handle(gcHandle);
			return result;
		}

		public static void Run(this Triangulator<float2> @this)
		{
			new TriangulationJob<float, float2, float, TransformFloat, FloatUtils>(@this).Run();
		}

		public static JobHandle Schedule(this Triangulator<float2> @this, JobHandle dependencies = default(JobHandle))
		{
			return new TriangulationJob<float, float2, float, TransformFloat, FloatUtils>(@this).Schedule(dependencies);
		}

		public static void Run(this Triangulator<Vector2> @this)
		{
			new TriangulationJob<float, float2, float, TransformFloat, FloatUtils>(new andywiecko.BurstTriangulator.LowLevel.Unsafe.InputData<float2>
			{
				Positions = @this.Input.Positions.Reinterpret<float2>(),
				ConstraintEdges = @this.Input.ConstraintEdges,
				ConstraintEdgeTypes = @this.Input.ConstraintEdgeTypes,
				HoleSeeds = @this.Input.HoleSeeds.Reinterpret<float2>()
			}, new andywiecko.BurstTriangulator.LowLevel.Unsafe.OutputData<float2>
			{
				Triangles = @this.triangles,
				Halfedges = @this.halfedges,
				Positions = UnsafeUtility.As<NativeList<Vector2>, NativeList<float2>>(ref @this.outputPositions),
				Status = @this.status,
				ConstrainedHalfedges = @this.constrainedHalfedges
			}, @this.Settings).Run();
		}

		public static JobHandle Schedule(this Triangulator<Vector2> @this, JobHandle dependencies = default(JobHandle))
		{
			return new TriangulationJob<float, float2, float, TransformFloat, FloatUtils>(new andywiecko.BurstTriangulator.LowLevel.Unsafe.InputData<float2>
			{
				Positions = @this.Input.Positions.Reinterpret<float2>(),
				ConstraintEdges = @this.Input.ConstraintEdges,
				ConstraintEdgeTypes = @this.Input.ConstraintEdgeTypes,
				HoleSeeds = @this.Input.HoleSeeds.Reinterpret<float2>()
			}, new andywiecko.BurstTriangulator.LowLevel.Unsafe.OutputData<float2>
			{
				Triangles = @this.triangles,
				Halfedges = @this.halfedges,
				Positions = UnsafeUtility.As<NativeList<Vector2>, NativeList<float2>>(ref @this.outputPositions),
				Status = @this.status,
				ConstrainedHalfedges = @this.constrainedHalfedges
			}, @this.Settings).Schedule(dependencies);
		}

		public static void Run(this Triangulator<double2> @this)
		{
			new TriangulationJob<double, double2, double, TransformDouble, DoubleUtils>(@this).Run();
		}

		public static JobHandle Schedule(this Triangulator<double2> @this, JobHandle dependencies = default(JobHandle))
		{
			return new TriangulationJob<double, double2, double, TransformDouble, DoubleUtils>(@this).Schedule(dependencies);
		}

		public static void Run(this Triangulator<int2> @this)
		{
			new TriangulationJob<int, int2, long, TransformInt, IntUtils>(@this).Run();
		}

		public static JobHandle Schedule(this Triangulator<int2> @this, JobHandle dependencies = default(JobHandle))
		{
			return new TriangulationJob<int, int2, long, TransformInt, IntUtils>(@this).Schedule(dependencies);
		}
	}
}
