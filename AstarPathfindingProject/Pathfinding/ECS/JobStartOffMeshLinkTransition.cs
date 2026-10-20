using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

namespace Pathfinding.ECS
{
	public struct JobStartOffMeshLinkTransition
	{
		public EntityCommandBuffer commandBuffer;

		public static IEnumerable<object> DefaultOnTraverseOffMeshLink(AgentOffMeshLinkTraversalContext ctx)
		{
			OffMeshLinks.OffMeshLinkTracer linkInfo = ctx.link;
			float3 up = ctx.movementPlane.ToWorld(float2.zero, 1f);
			float3 forward = ctx.movementPlane.ToWorld(ctx.movementPlane.ToPlane(linkInfo.relativeEnd - linkInfo.relativeStart));
			quaternion rot = quaternion.LookRotationSafe(forward, up);
			while (!ctx.MoveTowards(linkInfo.relativeStart, rot, gravity: true, slowdown: false).reached)
			{
				yield return null;
			}
			ctx.DisableLocalAvoidance();
			while (!ctx.MoveTowards(linkInfo.relativeEnd, rot, gravity: true, slowdown: false).reached)
			{
				yield return null;
			}
		}
	}
}
