using System;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

namespace Pathfinding.ECS
{
	public struct PhysicsSceneRef : ISharedComponentData, IQueryTypeParameter, IEquatable<PhysicsSceneRef>
	{
		public PhysicsScene physicsScene;

		public bool Equals(PhysicsSceneRef other)
		{
			return physicsScene == other.physicsScene;
		}

		public override int GetHashCode()
		{
			return physicsScene.GetHashCode();
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Preserve]
		public unsafe static bool __codegen__Equals(void* self, void* P_1)
		{
			return ((PhysicsSceneRef*)self)->Equals(*(PhysicsSceneRef*)P_1);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Preserve]
		public unsafe static int __codegen__GetHashCode(void* self)
		{
			return ((PhysicsSceneRef*)self)->GetHashCode();
		}
	}
}
