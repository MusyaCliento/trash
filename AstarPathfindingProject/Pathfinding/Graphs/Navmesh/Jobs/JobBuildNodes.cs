using System;
using System.Runtime.InteropServices;
using Pathfinding.Jobs;
using Pathfinding.Sync;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	public struct JobBuildNodes
	{
		public class BuildNodeTilesOutput : IProgress, IDisposable
		{
			public TileBuilder.TileBuilderOutput progressSource;

			public NavmeshTile[] tiles;

			public float Progress => progressSource.Progress;

			public void Dispose()
			{
			}
		}

		private uint graphIndex;

		public uint initialPenalty;

		public bool recalculateNormals;

		public float maxTileConnectionEdgeDistance;

		private Matrix4x4 graphToWorldSpace;

		private TileLayout tileLayout;

		internal JobBuildNodes(RecastGraph graph, TileLayout tileLayout)
		{
			this.tileLayout = tileLayout;
			graphIndex = graph.graphIndex;
			initialPenalty = graph.initialPenalty;
			recalculateNormals = graph.RecalculateNormals;
			maxTileConnectionEdgeDistance = graph.MaxTileConnectionEdgeDistance;
			graphToWorldSpace = tileLayout.transform.matrix;
		}

		public Promise<BuildNodeTilesOutput> Schedule(DisposeArena arena, Promise<TileBuilder.TileBuilderOutput> preCutDependency, Promise<TileCutter.TileCutterOutput> postCutDependency)
		{
			TileCutter.TileCutterOutput value = postCutDependency.GetValue();
			TileBuilder.TileBuilderOutput value2 = preCutDependency.GetValue();
			IntRect tileRect = value2.tileMeshes.tileRect;
			NativeArray<TileMesh.TileMeshUnsafe> tileMeshes = ((!value.tileMeshes.tileMeshes.IsCreated) ? value2.tileMeshes.tileMeshes : value.tileMeshes.tileMeshes);
			NavmeshTile[] array = new NavmeshTile[tileRect.Area];
			GCHandle gCHandle = GCHandle.Alloc(array);
			NativeArray<JobCalculateTriangleConnections.TileNodeConnectionsUnsafe> nativeArray = new NativeArray<JobCalculateTriangleConnections.TileNodeConnectionsUnsafe>(tileRect.Area, Allocator.Persistent);
			JobHandle job = new JobCalculateTriangleConnections
			{
				tileMeshes = tileMeshes,
				nodeConnections = nativeArray
			}.Schedule(postCutDependency.handle);
			Vector2 tileWorldSize = new Vector2(tileLayout.TileWorldSizeX, tileLayout.TileWorldSizeZ);
			JobHandle job2 = new JobCreateTiles
			{
				preCutTileMeshes = (value.tileMeshes.tileMeshes.IsCreated ? value2.tileMeshes.tileMeshes : default(NativeArray<TileMesh.TileMeshUnsafe>)),
				tileMeshes = tileMeshes,
				tiles = gCHandle,
				tileRect = tileRect,
				graphTileCount = tileLayout.tileCount,
				graphIndex = graphIndex,
				initialPenalty = initialPenalty,
				recalculateNormals = recalculateNormals,
				graphToWorldSpace = graphToWorldSpace,
				tileWorldSize = tileWorldSize
			}.Schedule(postCutDependency.handle);
			JobHandle dependency = new JobWriteNodeConnections
			{
				nodeConnections = nativeArray,
				tiles = gCHandle
			}.Schedule(JobHandle.CombineDependencies(job, job2));
			JobHandle handle = JobConnectTiles.ScheduleBatch(gCHandle, dependency, tileRect, tileWorldSize, maxTileConnectionEdgeDistance);
			arena.Add(gCHandle);
			arena.Add(nativeArray);
			return new Promise<BuildNodeTilesOutput>(handle, new BuildNodeTilesOutput
			{
				progressSource = value2,
				tiles = array
			});
		}
	}
}
