using System;
using System.Runtime.InteropServices;
using Unity.Entities;

namespace Pathfinding.ECS
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ReadyToTraverseOffMeshLink : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
	}
}
