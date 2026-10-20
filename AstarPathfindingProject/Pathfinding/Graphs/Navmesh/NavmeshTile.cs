using System;
using Pathfinding.Collections;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Profiling;

namespace Pathfinding.Graphs.Navmesh
{
	public class NavmeshTile : INavmeshHolder, ITransformedGraph
	{
		public UnsafeSpan<Int3> vertsInGraphSpace;

		public UnsafeSpan<Int3> verts;

		public UnsafeSpan<int> tris;

		public bool isCut;

		public UnsafeSpan<Int3> preCutVertsInTileSpace;

		public UnsafeSpan<int> preCutTris;

		public UnsafeSpan<uint> preCutTags;

		public int x;

		public int z;

		public int w;

		public int d;

		public TriangleMeshNode[] nodes;

		public BBTree bbTree;

		public bool flag;

		public NavmeshBase graph;

		public GraphTransform transform => graph.transform;

		public void GetTileCoordinates(int tileIndex, out int x, out int z)
		{
			x = this.x;
			z = this.z;
		}

		public int GetVertexArrayIndex(int index)
		{
			return index & 0xFFF;
		}

		public Int3 GetVertex(int index)
		{
			int index2 = index & 0xFFF;
			return verts[index2];
		}

		[IgnoredByDeepProfiler]
		public Int3 GetVertexInGraphSpace(int index)
		{
			return vertsInGraphSpace[index & 0xFFF];
		}

		public void GetNodes(Action<GraphNode> action)
		{
			if (nodes != null)
			{
				for (int i = 0; i < nodes.Length; i++)
				{
					action(nodes[i]);
				}
			}
		}

		public void Dispose()
		{
			bbTree.Dispose();
			vertsInGraphSpace.Free(Allocator.Persistent);
			verts.Free(Allocator.Persistent);
			tris.Free(Allocator.Persistent);
			preCutTags.Free(Allocator.Persistent);
			preCutVertsInTileSpace.Free(Allocator.Persistent);
			preCutTris.Free(Allocator.Persistent);
			vertsInGraphSpace = default(UnsafeSpan<Int3>);
			verts = default(UnsafeSpan<Int3>);
			tris = default(UnsafeSpan<int>);
			preCutTags = default(UnsafeSpan<uint>);
			preCutVertsInTileSpace = default(UnsafeSpan<Int3>);
			preCutTris = default(UnsafeSpan<int>);
			isCut = false;
		}
	}
}
