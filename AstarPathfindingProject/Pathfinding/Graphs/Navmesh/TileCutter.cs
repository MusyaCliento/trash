using System;
using System.Collections.Generic;
using Pathfinding.Collections;
using Pathfinding.Sync;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	public struct TileCutter
	{
		public struct TileCutterOutput : IProgress, IDisposable
		{
			public TileMeshesUnsafe tileMeshes;

			public float Progress => 0f;

			public void Dispose()
			{
				tileMeshes.Dispose(Allocator.Persistent);
			}
		}

		[BurstCompile]
		private struct JobCutTiles : IJob
		{
			public UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices;

			public UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles;

			public UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags;

			public TileHandler.CutCollection cutCollection;

			public TileMeshesUnsafe inputTileMeshes;

			public NativeArray<TileMesh.TileMeshUnsafe> outputTileMeshes;

			public void Execute()
			{
				int length = inputTileMeshes.tileMeshes.Length;
				for (int i = 0; i < length; i++)
				{
					tileVertices[i].InsertRange(0, 1);
					tileTriangles[i].InsertRange(0, 1);
					tileTags[i].InsertRange(0, 1);
					tileVertices[i][0] = inputTileMeshes.tileMeshes[i].verticesInTileSpace;
					tileTriangles[i][0] = inputTileMeshes.tileMeshes[i].triangles;
					tileTags[i][0] = inputTileMeshes.tileMeshes[i].tags.Reinterpret<int>();
				}
				UnsafeSpan<TileMesh.TileMeshUnsafe> output = outputTileMeshes.AsUnsafeSpan();
				Vector2Int tileSize = new Vector2Int(Mathf.RoundToInt(inputTileMeshes.tileWorldSize.x * 1000f), Mathf.RoundToInt(inputTileMeshes.tileWorldSize.y * 1000f));
				TileHandler.CutTiles(ref tileVertices, ref tileTriangles, ref tileTags, ref tileSize, ref cutCollection, ref output, Allocator.Persistent);
				DisposeTileData(tileVertices, tileTriangles, tileTags, Allocator.Persistent, skipFirst: true);
				cutCollection.Dispose();
			}
		}

		private NavmeshBase graph;

		private GridLookup<NavmeshClipper> cuts;

		private TileLayout tileLayout;

		public TileCutter(NavmeshBase graph, GridLookup<NavmeshClipper> cuts, TileLayout tileLayout)
		{
			this.graph = graph;
			this.cuts = cuts;
			this.tileLayout = tileLayout;
		}

		private static void DisposeTileData(UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices, UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles, UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags, Allocator allocator, bool skipFirst)
		{
			for (int i = 0; i < tileVertices.Length; i++)
			{
				for (int j = (skipFirst ? 1 : 0); j < tileVertices[i].Length; j++)
				{
					tileVertices[i][j].Free(allocator);
					tileTriangles[i][j].Free(allocator);
					tileTags[i][j].Free(allocator);
				}
				tileVertices[i].Dispose();
				tileTriangles[i].Dispose();
				tileTags[i].Dispose();
			}
			tileVertices.Free(allocator);
			tileTriangles.Free(allocator);
			tileTags.Free(allocator);
		}

		public static void EnsurePreCutDataExists(NavmeshBase graph, NavmeshTile tile)
		{
			if (!tile.isCut)
			{
				tile.preCutTris = tile.tris.Clone(Allocator.Persistent);
				tile.preCutVertsInTileSpace = tile.vertsInGraphSpace.Clone(Allocator.Persistent);
				Int3 @int = (Int3)graph.GetTileBoundsInGraphSpace(tile.x, tile.z).min;
				for (int i = 0; i < tile.preCutVertsInTileSpace.Length; i++)
				{
					tile.preCutVertsInTileSpace[i] -= @int;
				}
				tile.preCutTags = new UnsafeSpan<uint>(Allocator.Persistent, tile.nodes.Length);
				for (int j = 0; j < tile.nodes.Length; j++)
				{
					tile.preCutTags[j] = tile.nodes[j].Tag;
				}
				tile.isCut = true;
			}
		}

		private static bool CheckVersion()
		{
			return true;
		}

		public Promise<TileCutterOutput> Schedule(List<Vector2Int> tileCoordinates)
		{
			if (cuts == null)
			{
				return new Promise<TileCutterOutput>(default(JobHandle), default(TileCutterOutput));
			}
			int count = tileCoordinates.Count;
			UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices = new UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>>(Allocator.Persistent, count);
			UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles = new UnsafeSpan<UnsafeList<UnsafeSpan<int>>>(Allocator.Persistent, count);
			UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags = new UnsafeSpan<UnsafeList<UnsafeSpan<int>>>(Allocator.Persistent, count);
			for (int i = 0; i < tileVertices.Length; i++)
			{
				tileVertices[i] = new UnsafeList<UnsafeSpan<Int3>>(1, Allocator.Persistent);
				tileTriangles[i] = new UnsafeList<UnsafeSpan<int>>(1, Allocator.Persistent);
				tileTags[i] = new UnsafeList<UnsafeSpan<int>>(1, Allocator.Persistent);
			}
			TileHandler.CutCollection cutCollection = TileHandler.CollectCuts(cuts, tileCoordinates, graph.NavmeshCuttingCharacterRadius, tileLayout, ref tileVertices, ref tileTriangles, ref tileTags);
			if (!cutCollection.cuttingRequired || !CheckVersion())
			{
				DisposeTileData(tileVertices, tileTriangles, tileTags, Allocator.Persistent, skipFirst: false);
				cutCollection.Dispose();
				return new Promise<TileCutterOutput>(default(JobHandle), default(TileCutterOutput));
			}
			NativeArray<TileMesh.TileMeshUnsafe> tileMeshes = new NativeArray<TileMesh.TileMeshUnsafe>(count, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			for (int j = 0; j < tileCoordinates.Count; j++)
			{
				NavmeshTile tile = graph.GetTile(tileCoordinates[j].x, tileCoordinates[j].y);
				EnsurePreCutDataExists(graph, tile);
				tileMeshes[j] = new TileMesh.TileMeshUnsafe
				{
					triangles = tile.preCutTris,
					verticesInTileSpace = tile.preCutVertsInTileSpace,
					tags = tile.preCutTags
				};
			}
			Vector2 tileWorldSize = new Vector2(graph.TileWorldSizeX, graph.TileWorldSizeZ);
			TileMeshesUnsafe inputTileMeshes = new TileMeshesUnsafe(tileMeshes, new IntRect(0, 0, -1, -1), tileWorldSize);
			NativeArray<TileMesh.TileMeshUnsafe> nativeArray = new NativeArray<TileMesh.TileMeshUnsafe>(count, Allocator.Persistent);
			TileMeshesUnsafe tileMeshes2 = new TileMeshesUnsafe(nativeArray, new IntRect(0, 0, -1, -1), tileWorldSize);
			TileCutterOutput result = new TileCutterOutput
			{
				tileMeshes = tileMeshes2
			};
			TileHandler.InitDelegates();
			JobHandle jobHandle = new JobCutTiles
			{
				tileVertices = tileVertices,
				tileTriangles = tileTriangles,
				tileTags = tileTags,
				cutCollection = cutCollection,
				inputTileMeshes = inputTileMeshes,
				outputTileMeshes = nativeArray
			}.Schedule();
			tileMeshes.Dispose(jobHandle);
			return new Promise<TileCutterOutput>(jobHandle, result);
		}

		public Promise<TileCutterOutput> Schedule(Promise<TileBuilder.TileBuilderOutput> builderOutput)
		{
			if (cuts == null)
			{
				return new Promise<TileCutterOutput>(builderOutput.handle, default(TileCutterOutput));
			}
			TileBuilder.TileBuilderOutput value = builderOutput.GetValue();
			IntRect tileRect = value.tileMeshes.tileRect;
			List<Vector2Int> innerCoordinates = tileRect.GetInnerCoordinates();
			int count = innerCoordinates.Count;
			UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices = new UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>>(Allocator.Persistent, count);
			UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles = new UnsafeSpan<UnsafeList<UnsafeSpan<int>>>(Allocator.Persistent, count);
			UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags = new UnsafeSpan<UnsafeList<UnsafeSpan<int>>>(Allocator.Persistent, count);
			for (int i = 0; i < tileVertices.Length; i++)
			{
				tileVertices[i] = new UnsafeList<UnsafeSpan<Int3>>(1, Allocator.Persistent);
				tileTriangles[i] = new UnsafeList<UnsafeSpan<int>>(1, Allocator.Persistent);
				tileTags[i] = new UnsafeList<UnsafeSpan<int>>(1, Allocator.Persistent);
			}
			TileHandler.CutCollection cutCollection = TileHandler.CollectCuts(cuts, innerCoordinates, graph.NavmeshCuttingCharacterRadius, tileLayout, ref tileVertices, ref tileTriangles, ref tileTags);
			if (!cutCollection.cuttingRequired || !CheckVersion())
			{
				DisposeTileData(tileVertices, tileTriangles, tileTags, Allocator.Persistent, skipFirst: false);
				cutCollection.Dispose();
				return new Promise<TileCutterOutput>(builderOutput.handle, default(TileCutterOutput));
			}
			NativeArray<TileMesh.TileMeshUnsafe> nativeArray = new NativeArray<TileMesh.TileMeshUnsafe>(value.tileMeshes.tileMeshes.Length, Allocator.Persistent);
			TileMeshesUnsafe tileMeshes = new TileMeshesUnsafe(nativeArray, value.tileMeshes.tileRect, value.tileMeshes.tileWorldSize);
			TileCutterOutput result = new TileCutterOutput
			{
				tileMeshes = tileMeshes
			};
			TileHandler.InitDelegates();
			return new Promise<TileCutterOutput>(new JobCutTiles
			{
				tileVertices = tileVertices,
				tileTriangles = tileTriangles,
				tileTags = tileTags,
				cutCollection = cutCollection,
				inputTileMeshes = value.tileMeshes,
				outputTileMeshes = nativeArray
			}.Schedule(builderOutput.handle), result);
		}
	}
}
