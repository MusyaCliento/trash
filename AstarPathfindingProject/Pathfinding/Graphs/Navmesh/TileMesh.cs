using Pathfinding.Collections;
using Unity.Collections;

namespace Pathfinding.Graphs.Navmesh
{
	public struct TileMesh
	{
		public struct TileMeshUnsafe
		{
			public UnsafeSpan<int> triangles;

			public UnsafeSpan<Int3> verticesInTileSpace;

			public UnsafeSpan<uint> tags;

			public void Dispose(Allocator allocator)
			{
				triangles.Free(allocator);
				verticesInTileSpace.Free(allocator);
				tags.Free(allocator);
			}

			public TileMesh ToManaged()
			{
				return new TileMesh
				{
					triangles = triangles.ToArray(),
					verticesInTileSpace = verticesInTileSpace.ToArray(),
					tags = tags.ToArray()
				};
			}
		}

		public int[] triangles;

		public Int3[] verticesInTileSpace;

		public uint[] tags;
	}
}
