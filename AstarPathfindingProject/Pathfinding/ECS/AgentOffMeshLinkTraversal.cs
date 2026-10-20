using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Pathfinding.ECS
{
	public struct AgentOffMeshLinkTraversal : IComponentData, IQueryTypeParameter
	{
		public float3 relativeStart;

		public float3 relativeEnd;

		public bool isReverse;

		[Obsolete("Use relativeStart instead")]
		public float3 firstPosition => relativeStart;

		[Obsolete("Use relativeEnd instead")]
		public float3 secondPosition => relativeEnd;

		public AgentOffMeshLinkTraversal(OffMeshLinks.OffMeshLinkTracer linkInfo)
		{
			relativeStart = linkInfo.relativeStart;
			relativeEnd = linkInfo.relativeEnd;
			isReverse = linkInfo.isReverse;
		}
	}
}
