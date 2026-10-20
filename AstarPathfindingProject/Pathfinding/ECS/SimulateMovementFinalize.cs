using System.Runtime.InteropServices;
using Unity.Entities;

namespace Pathfinding.ECS
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct SimulateMovementFinalize : IComponentData, IQueryTypeParameter
	{
	}
}
