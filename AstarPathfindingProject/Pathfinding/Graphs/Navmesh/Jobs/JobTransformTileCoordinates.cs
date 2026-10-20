using Pathfinding.Collections;
using Unity.Burst;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	public struct JobTransformTileCoordinates : IJob
	{
		public UnsafeSpan<Int3> vertices;

		public Matrix4x4 matrix;

		public void Execute()
		{
			for (uint num = 0u; num < vertices.length; num++)
			{
				Int3 @int = vertices[num];
				vertices[num] = (Int3)matrix.MultiplyPoint3x4(new Vector3(@int.x, @int.y, @int.z));
			}
		}
	}
}
