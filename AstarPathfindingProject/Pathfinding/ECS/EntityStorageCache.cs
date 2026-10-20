using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Pathfinding.ECS
{
	public struct EntityStorageCache
	{
		private EntityStorageInfo storage;

		private Entity entity;

		private int lastWorldHash;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Update(World world, Entity entity, out EntityManager entityManager, out EntityStorageInfo storage)
		{
			entityManager = default(EntityManager);
			storage = this.storage;
			if (world == null)
			{
				return false;
			}
			entityManager = world.EntityManager;
			int num = entityManager.EntityOrderVersion ^ ((int)world.SequenceNumber << 8);
			if (num != lastWorldHash || entity != this.entity)
			{
				if (!entityManager.Exists(entity))
				{
					return false;
				}
				this.storage = (storage = entityManager.GetStorageInfo(entity));
				this.entity = entity;
				lastWorldHash = num;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe bool GetComponentData<A>(Entity entity, ref EntityAccess<A> access, out ComponentRef<A> value) where A : unmanaged, IComponentData
		{
			if (Update(World.DefaultGameObjectInjectionWorld, entity, out var entityManager, out var entityStorageInfo))
			{
				access.Update(entityManager);
				value = new ComponentRef<A>((byte*)UnsafeUtility.AddressOf(ref access[entityStorageInfo]));
				return true;
			}
			value = default(ComponentRef<A>);
			return false;
		}
	}
}
