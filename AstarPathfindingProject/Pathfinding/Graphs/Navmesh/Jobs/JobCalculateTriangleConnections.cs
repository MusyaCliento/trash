using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	[BurstCompile]
	public struct JobCalculateTriangleConnections : IJob
	{
		public struct TileNodeConnectionsUnsafe
		{
			public UnsafeAppendBuffer neighbours;

			public UnsafeAppendBuffer neighbourCounts;
		}

		[ReadOnly]
		public NativeArray<TileMesh.TileMeshUnsafe> tileMeshes;

		[WriteOnly]
		public NativeArray<TileNodeConnectionsUnsafe> nodeConnections;

		public unsafe void Execute()
		{
			NativeParallelHashMap<int2, uint> nativeParallelHashMap = new NativeParallelHashMap<int2, uint>(128, Allocator.Temp);
			bool flag = false;
			for (int i = 0; i < tileMeshes.Length; i++)
			{
				nativeParallelHashMap.Clear();
				TileMesh.TileMeshUnsafe tileMeshUnsafe = tileMeshes[i];
				int length = tileMeshUnsafe.triangles.Length;
				UnsafeAppendBuffer neighbours = new UnsafeAppendBuffer(length * 2 * 4, 4, Allocator.Persistent);
				UnsafeAppendBuffer neighbourCounts = new UnsafeAppendBuffer(length * 4, 4, Allocator.Persistent);
				int* ptr = tileMeshUnsafe.triangles.ptr;
				int num = 0;
				int num2 = 0;
				while (num < length)
				{
					flag |= !nativeParallelHashMap.TryAdd(new int2(ptr[num], ptr[num + 1]), (uint)(num2 | 0));
					flag |= !nativeParallelHashMap.TryAdd(new int2(ptr[num + 1], ptr[num + 2]), (uint)(num2 | 0x10000000));
					flag |= !nativeParallelHashMap.TryAdd(new int2(ptr[num + 2], ptr[num]), (uint)(num2 | 0x20000000));
					num += 3;
					num2++;
				}
				for (int j = 0; j < length; j += 3)
				{
					int num3 = 0;
					for (int k = 0; k < 3; k++)
					{
						if (nativeParallelHashMap.TryGetValue(new int2(ptr[j + (k + 1) % 3], ptr[j + k]), out var item))
						{
							uint value = item & 0xFFFFFFF;
							int num4 = (int)(item >> 28);
							neighbours.Add(value);
							byte value2 = Connection.PackShapeEdgeInfo((byte)k, (byte)num4, areEdgesIdentical: true, isOutgoing: true, isIncoming: true);
							neighbours.Add((int)value2);
							num3++;
						}
					}
					neighbourCounts.Add(num3);
				}
				nodeConnections[i] = new TileNodeConnectionsUnsafe
				{
					neighbours = neighbours,
					neighbourCounts = neighbourCounts
				};
			}
			if (flag)
			{
				Debug.LogWarning("Duplicate triangle edges were found in the input mesh. These have been removed. Are you sure your mesh is suitable for being used as a navmesh directly?\nThis could be caused by the mesh's normals not being consistent.");
			}
		}
	}
}
