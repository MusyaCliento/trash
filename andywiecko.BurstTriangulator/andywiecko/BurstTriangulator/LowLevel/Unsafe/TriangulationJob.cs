using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	[BurstCompile]
	internal struct TriangulationJob<T, T2, TBig, TTransform, TUtils> : IJob where T : unmanaged, IComparable<T> where T2 : unmanaged where TBig : unmanaged, IComparable<TBig> where TTransform : unmanaged, ITransform<TTransform, T, T2> where TUtils : unmanaged, IUtils<T, T2, TBig>
	{
		private NativeArray<T2> inputPositions;

		[NativeDisableContainerSafetyRestriction]
		private NativeArray<int> constraints;

		[NativeDisableContainerSafetyRestriction]
		private NativeArray<ConstraintType> constraintTypes;

		[NativeDisableContainerSafetyRestriction]
		private NativeArray<T2> holeSeeds;

		private NativeList<T2> outputPositions;

		private NativeList<int> triangles;

		private NativeList<int> halfedges;

		private NativeList<HalfedgeState> constrainedHalfedges;

		private NativeReference<Status> status;

		private readonly Args args;

		public TriangulationJob(InputData<T2> input, OutputData<T2> output, Args args)
		{
			inputPositions = input.Positions;
			constraints = input.ConstraintEdges;
			constraintTypes = input.ConstraintEdgeTypes;
			holeSeeds = input.HoleSeeds;
			outputPositions = output.Positions;
			triangles = output.Triangles;
			halfedges = output.Halfedges;
			constrainedHalfedges = output.ConstrainedHalfedges;
			status = output.Status;
			this.args = args;
		}

		public TriangulationJob(Triangulator<T2> @this)
		{
			inputPositions = @this.Input.Positions;
			constraints = @this.Input.ConstraintEdges;
			constraintTypes = @this.Input.ConstraintEdgeTypes;
			holeSeeds = @this.Input.HoleSeeds;
			outputPositions = @this.Output.Positions;
			triangles = @this.Output.Triangles;
			halfedges = @this.Output.Halfedges;
			constrainedHalfedges = @this.Output.ConstrainedHalfedges;
			status = @this.Output.Status;
			args = @this.Settings;
		}

		public void Execute()
		{
			default(UnsafeTriangulator<T, T2, TBig, TTransform, TUtils>).Triangulate(new InputData<T2>
			{
				Positions = inputPositions,
				ConstraintEdges = constraints,
				ConstraintEdgeTypes = constraintTypes,
				HoleSeeds = holeSeeds
			}, new OutputData<T2>
			{
				Positions = outputPositions,
				Triangles = triangles,
				Halfedges = halfedges,
				ConstrainedHalfedges = constrainedHalfedges,
				Status = status
			}, args, Allocator.Temp);
		}
	}
}
