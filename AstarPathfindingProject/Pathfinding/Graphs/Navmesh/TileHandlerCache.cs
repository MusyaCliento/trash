using Pathfinding.Clipper2Lib;
using Unity.Jobs.LowLevel.Unsafe;

namespace Pathfinding.Graphs.Navmesh
{
	internal static class TileHandlerCache
	{
		internal static Clipper64[] cachedClippers = new Clipper64[JobsUtility.ThreadIndexCount];
	}
}
