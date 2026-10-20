using System;
using Pathfinding.Collections;
using Pathfinding.Sync;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	[BurstCompile(FloatMode = FloatMode.Default)]
	public struct JobBuildTileMeshFromVertices : IJob
	{
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public struct JobTransformTileCoordinates : IJob
		{
			public NativeArray<Vector3> vertices;

			public NativeArray<Int3> outputVertices;

			public Matrix4x4 matrix;

			public void Execute()
			{
				if (vertices.Length != outputVertices.Length)
				{
					throw new ArgumentException("Input and output arrays must have the same length");
				}
				for (int i = 0; i < vertices.Length; i++)
				{
					outputVertices[i] = (Int3)matrix.MultiplyPoint3x4(vertices[i]);
				}
			}
		}

		public NativeArray<Vector3> vertices;

		public NativeArray<int> indices;

		public Matrix4x4 meshToGraph;

		public NativeArray<TileMesh.TileMeshUnsafe> outputBuffers;

		public bool recalculateNormals;

		public static Promise<TileBuilder.TileBuilderOutput> Schedule(NativeArray<Vector3> vertices, NativeArray<int> indices, Matrix4x4 meshToGraph, bool recalculateNormals)
		{
			if (vertices.Length > 4095)
			{
				throw new ArgumentException("Too many vertices in the navmesh graph. Provided " + vertices.Length + ", but the maximum number of vertices per tile is " + 4095 + ". You can raise this limit by enabling ASTAR_RECAST_LARGER_TILES in the A* Inspector Optimizations tab");
			}
			NativeArray<TileMesh.TileMeshUnsafe> tileMeshes = new NativeArray<TileMesh.TileMeshUnsafe>(1, Allocator.Persistent);
			return new Promise<TileBuilder.TileBuilderOutput>(new JobBuildTileMeshFromVertices
			{
				vertices = vertices,
				indices = indices,
				meshToGraph = meshToGraph,
				outputBuffers = tileMeshes,
				recalculateNormals = recalculateNormals
			}.Schedule(), new TileBuilder.TileBuilderOutput
			{
				tileMeshes = new TileMeshesUnsafe(tileMeshes, new IntRect(0, 0, 0, 0), new Vector2(100000f, 100000f))
			});
		}

		public unsafe void Execute()
		{
			NativeList<Int3> list = new NativeList<Int3>(vertices.Length, Allocator.Temp);
			list.Length = vertices.Length;
			NativeList<int> nativeList = new NativeList<int>(indices.Length / 3, Allocator.Temp);
			nativeList.Length = indices.Length / 3;
			NativeList<int> nativeList2 = new NativeList<int>(indices.Length, Allocator.Temp);
			nativeList2.AddRange(indices);
			JobTransformTileCoordinates jobTransformTileCoordinates = default(JobTransformTileCoordinates);
			jobTransformTileCoordinates.vertices = vertices;
			jobTransformTileCoordinates.outputVertices = list.AsArray();
			jobTransformTileCoordinates.matrix = meshToGraph;
			jobTransformTileCoordinates.Execute();
			TileMesh.TileMeshUnsafe* unsafePtr = (TileMesh.TileMeshUnsafe*)outputBuffers.GetUnsafePtr();
			MeshUtility.JobRemoveDuplicateVertices jobRemoveDuplicateVertices = default(MeshUtility.JobRemoveDuplicateVertices);
			jobRemoveDuplicateVertices.vertices = list;
			jobRemoveDuplicateVertices.triangles = nativeList2;
			jobRemoveDuplicateVertices.tags = nativeList;
			jobRemoveDuplicateVertices.Execute();
			unsafePtr->verticesInTileSpace = list.AsUnsafeSpan().Clone(Allocator.Persistent);
			unsafePtr->triangles = nativeList2.AsUnsafeSpan().Clone(Allocator.Persistent);
			unsafePtr->tags = nativeList.AsUnsafeSpan().Reinterpret<uint>().Clone(Allocator.Persistent);
			if (recalculateNormals)
			{
				MeshUtility.MakeTrianglesClockwise(ref unsafePtr->verticesInTileSpace, ref unsafePtr->triangles);
			}
			list.Dispose();
		}
	}
}
