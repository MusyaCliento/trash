using System;
using Unity.Collections;

namespace andywiecko.BurstTriangulator
{
	public class OutputData<T2> where T2 : unmanaged
	{
		private readonly Triangulator<T2> owner;

		public NativeList<T2> Positions => owner.outputPositions;

		public NativeList<int> Triangles => owner.triangles;

		public NativeReference<Status> Status => owner.status;

		public NativeList<int> Halfedges => owner.halfedges;

		public NativeList<HalfedgeState> ConstrainedHalfedges => owner.constrainedHalfedges;

		[Obsolete("This will be converted into internal ctor.")]
		public OutputData(Triangulator<T2> owner)
		{
			this.owner = owner;
		}
	}
}
