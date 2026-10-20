using Unity.Collections;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	public struct OutputData<T2> where T2 : unmanaged
	{
		public NativeList<T2> Positions;

		public NativeList<int> Triangles;

		public NativeReference<Status> Status;

		public NativeList<int> Halfedges;

		public NativeList<HalfedgeState> ConstrainedHalfedges;
	}
}
