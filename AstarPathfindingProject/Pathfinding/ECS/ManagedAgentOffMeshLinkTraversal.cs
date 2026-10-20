using System;
using System.Collections;
using Unity.Entities;
using UnityEngine.Scripting;

namespace Pathfinding.ECS
{
	public class ManagedAgentOffMeshLinkTraversal : IComponentData, IQueryTypeParameter, ICloneable, ICleanupComponentData
	{
		public AgentOffMeshLinkTraversalContext context;

		public IEnumerator coroutine;

		public IOffMeshLinkHandler handler;

		public IOffMeshLinkStateMachine stateMachine;

		[Preserve]
		public ManagedAgentOffMeshLinkTraversal()
		{
		}

		public ManagedAgentOffMeshLinkTraversal(AgentOffMeshLinkTraversalContext context, IOffMeshLinkHandler handler)
		{
			this.context = context;
			this.handler = handler;
			coroutine = null;
			stateMachine = null;
		}

		public object Clone()
		{
			return new ManagedAgentOffMeshLinkTraversal((AgentOffMeshLinkTraversalContext)context.Clone(), handler);
		}
	}
}
