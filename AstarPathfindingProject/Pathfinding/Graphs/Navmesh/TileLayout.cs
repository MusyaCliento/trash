using System;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	public struct TileLayout
	{
		public Vector2Int tileCount;

		public GraphTransform transform;

		public Vector2Int tileSizeInVoxels;

		public Vector3 graphSpaceSize;

		public float cellSize;

		public float CellHeight => Mathf.Max(graphSpaceSize.y / 64000f, 0.001f);

		public Vector2 TileWorldSize => new Vector2(TileWorldSizeX, TileWorldSizeZ);

		public float TileWorldSizeX => (float)tileSizeInVoxels.x * cellSize;

		public float TileWorldSizeZ => (float)tileSizeInVoxels.y * cellSize;

		public Bounds GetTileBoundsInGraphSpace(int x, int z, int width = 1, int depth = 1)
		{
			Bounds result = default(Bounds);
			result.SetMinMax(new Vector3((float)x * TileWorldSizeX, 0f, (float)z * TileWorldSizeZ), new Vector3((float)(x + width) * TileWorldSizeX, graphSpaceSize.y, (float)(z + depth) * TileWorldSizeZ));
			return result;
		}

		public IntRect GetTouchingTiles(Bounds bounds, float margin = 0f)
		{
			bounds = transform.InverseTransform(bounds);
			return new IntRect(Mathf.FloorToInt((bounds.min.x - margin) / TileWorldSizeX), Mathf.FloorToInt((bounds.min.z - margin) / TileWorldSizeZ), Mathf.FloorToInt((bounds.max.x + margin) / TileWorldSizeX), Mathf.FloorToInt((bounds.max.z + margin) / TileWorldSizeZ));
		}

		public IntRect GetTouchingTilesInGraphSpace(Rect rect)
		{
			return IntRect.Intersection(new IntRect(Mathf.FloorToInt(rect.xMin / TileWorldSizeX), Mathf.FloorToInt(rect.yMin / TileWorldSizeZ), Mathf.FloorToInt(rect.xMax / TileWorldSizeX), Mathf.FloorToInt(rect.yMax / TileWorldSizeZ)), new IntRect(0, 0, tileCount.x - 1, tileCount.y - 1));
		}

		public TileLayout(RecastGraph graph)
			: this(new Bounds(graph.forcedBoundsCenter, graph.forcedBoundsSize), Quaternion.Euler(graph.rotation), graph.cellSize, graph.editorTileSize, graph.useTiles)
		{
		}

		public TileLayout(NavMeshGraph graph)
			: this(new Bounds(graph.transform.Transform(graph.forcedBoundsSize * 0.5f), graph.forcedBoundsSize), Quaternion.Euler(graph.rotation), 0.001f, 0, useTiles: false)
		{
		}

		public TileLayout(Bounds bounds, Quaternion rotation, float cellSize, int tileSizeInVoxels, bool useTiles)
		{
			transform = RecastGraph.CalculateTransform(bounds, rotation);
			this.cellSize = cellSize;
			Vector3 vector = (graphSpaceSize = bounds.size);
			int num = (int)(vector.x / cellSize + 0.5f);
			int num2 = (int)(vector.z / cellSize + 0.5f);
			if (!useTiles)
			{
				this.tileSizeInVoxels = new Vector2Int(num, num2);
				tileCount = new Vector2Int(1, 1);
			}
			else
			{
				this.tileSizeInVoxels = new Vector2Int(tileSizeInVoxels, tileSizeInVoxels);
				tileCount = new Vector2Int(Mathf.Max(0, (num + this.tileSizeInVoxels.x - 1) / this.tileSizeInVoxels.x), Mathf.Max(0, (num2 + this.tileSizeInVoxels.y - 1) / this.tileSizeInVoxels.y));
			}
			if (tileCount.x * tileCount.y > 524288)
			{
				throw new Exception("Too many tiles (" + tileCount.x * tileCount.y + ") maximum is " + 524288 + "\nTry disabling ASTAR_RECAST_LARGER_TILES under the 'Optimizations' tab in the A* inspector.");
			}
		}
	}
}
