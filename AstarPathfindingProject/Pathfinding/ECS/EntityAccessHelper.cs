using System.Reflection;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Pathfinding.ECS
{
	internal static class EntityAccessHelper
	{
		public static readonly int GlobalSystemVersionOffset = UnsafeUtility.GetFieldOffset(typeof(ComponentTypeHandle<int>).GetField("m_GlobalSystemVersion", BindingFlags.Instance | BindingFlags.NonPublic));
	}
}
