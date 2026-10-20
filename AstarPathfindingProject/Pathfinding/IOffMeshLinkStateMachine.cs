using System.Collections;
using Pathfinding.ECS;

namespace Pathfinding
{
	public interface IOffMeshLinkStateMachine
	{
		IEnumerable OnTraverseOffMeshLink(AgentOffMeshLinkTraversalContext context)
		{
			return JobStartOffMeshLinkTransition.DefaultOnTraverseOffMeshLink(context);
		}

		void OnFinishTraversingOffMeshLink(AgentOffMeshLinkTraversalContext context)
		{
		}

		void OnAbortTraversingOffMeshLink()
		{
		}
	}
}
