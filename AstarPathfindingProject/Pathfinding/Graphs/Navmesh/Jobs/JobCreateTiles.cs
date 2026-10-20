using System.Runtime.InteropServices;
using Pathfinding.Collections;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	public struct JobCreateTiles : IJob
	{
		[ReadOnly]
		[NativeDisableContainerSafetyRestriction]
		public NativeArray<TileMesh.TileMeshUnsafe> preCutTileMeshes;

		[ReadOnly]
		public NativeArray<TileMesh.TileMeshUnsafe> tileMeshes;

		public GCHandle tiles;

		public uint graphIndex;

		public Vector2Int graphTileCount;

		public IntRect tileRect;

		public uint initialPenalty;

		public bool recalculateNormals;

		public Vector2 tileWorldSize;

		public Matrix4x4 graphToWorldSpace;

		public void Execute()
		{
			NavmeshTile[] array = (NavmeshTile[])tiles.Target;
			int width = tileRect.Width;
			int height = tileRect.Height;
			bool isCreated = preCutTileMeshes.IsCreated;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					int num = i * width + j;
					int tileIndex = (i + tileRect.ymin) * graphTileCount.x + (j + tileRect.xmin);
					TileMesh.TileMeshUnsafe tileMeshUnsafe = tileMeshes[num];
					UnsafeSpan<Int3> unsafeSpan = tileMeshUnsafe.verticesInTileSpace.Clone(Allocator.Persistent);
					UnsafeSpan<Int3> verts = unsafeSpan.Clone(Allocator.Persistent);
					Int3 @int = (Int3)new Vector3(tileWorldSize.x * (float)(j + tileRect.xmin), 0f, tileWorldSize.y * (float)(i + tileRect.ymin));
					for (int k = 0; k < unsafeSpan.Length; k++)
					{
						Int3 int2 = unsafeSpan[k] + @int;
						unsafeSpan[k] = int2;
						verts[k] = (Int3)graphToWorldSpace.MultiplyPoint3x4((Vector3)int2);
					}
					UnsafeSpan<int> unsafeSpan2 = tileMeshUnsafe.triangles.Clone(Allocator.Persistent);
					NavmeshTile navmeshTile = new NavmeshTile
					{
						x = j + tileRect.xmin,
						z = i + tileRect.ymin,
						w = 1,
						d = 1,
						tris = unsafeSpan2,
						vertsInGraphSpace = unsafeSpan,
						verts = verts,
						bbTree = new BBTree(unsafeSpan2, unsafeSpan),
						nodes = new TriangleMeshNode[unsafeSpan2.Length / 3],
						graph = null,
						isCut = false
					};
					if (isCreated)
					{
						TileMesh.TileMeshUnsafe tileMeshUnsafe2 = preCutTileMeshes[num];
						navmeshTile.preCutVertsInTileSpace = tileMeshUnsafe2.verticesInTileSpace.Clone(Allocator.Persistent);
						navmeshTile.preCutTris = tileMeshUnsafe2.triangles.Clone(Allocator.Persistent);
						navmeshTile.preCutTags = tileMeshUnsafe2.tags.Clone(Allocator.Persistent);
						navmeshTile.isCut = true;
					}
					NavmeshBase.CreateNodes(navmeshTile, navmeshTile.tris, tileIndex, graphIndex, tileMeshUnsafe.tags, initializeNodes: false, null, initialPenalty, tryPreserveExistingTagsAndPenalties: false);
					array[num] = navmeshTile;
				}
			}
		}
	}
}
