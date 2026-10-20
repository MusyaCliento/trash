using System;
using Unity.Entities;

namespace Pathfinding.ECS
{
	public ref struct ManagedMovementOverrides
	{
		private Entity entity;

		private World world;

		public ManagedMovementOverrides(Entity entity, World world)
		{
			this.entity = entity;
			this.world = world;
		}

		public void AddBeforeControlCallback(BeforeControlDelegate value)
		{
			AddCallback<ManagedMovementOverrideBeforeControl, BeforeControlDelegate>(value);
		}

		public void RemoveBeforeControlCallback(BeforeControlDelegate value)
		{
			RemoveCallback<ManagedMovementOverrideBeforeControl, BeforeControlDelegate>(value);
		}

		public void AddAfterControlCallback(AfterControlDelegate value)
		{
			AddCallback<ManagedMovementOverrideAfterControl, AfterControlDelegate>(value);
		}

		public void RemoveAfterControlCallback(AfterControlDelegate value)
		{
			RemoveCallback<ManagedMovementOverrideAfterControl, AfterControlDelegate>(value);
		}

		public void AddBeforeMovementCallback(BeforeMovementDelegate value)
		{
			AddCallback<ManagedMovementOverrideBeforeMovement, BeforeMovementDelegate>(value);
		}

		public void RemoveBeforeMovementCallback(BeforeMovementDelegate value)
		{
			RemoveCallback<ManagedMovementOverrideBeforeMovement, BeforeMovementDelegate>(value);
		}

		private void AddCallback<C, T>(T callback) where C : ManagedMovementOverride<T>, IComponentData, new() where T : Delegate
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			if (world == null || !world.EntityManager.Exists(entity))
			{
				throw new InvalidOperationException("The entity does not exist. You can only set a callback when the FollowerEntity is active and has been enabled. If you are trying to set this during Awake or OnEnable, try setting it during Start instead.");
			}
			if (!world.EntityManager.HasComponent<C>(entity))
			{
				EntityManagerManagedComponentExtensions.AddComponentData(world.EntityManager, entity, new C());
			}
			EntityManagerManagedComponentExtensions.GetComponentData<C>(world.EntityManager, entity).AddCallback(callback);
		}

		private void RemoveCallback<C, T>(T callback) where C : ManagedMovementOverride<T>, IComponentData, new() where T : Delegate
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			if (world != null && world.EntityManager.Exists(entity) && world.EntityManager.HasComponent<C>(entity) && !EntityManagerManagedComponentExtensions.GetComponentData<C>(world.EntityManager, entity).RemoveCallback(callback))
			{
				world.EntityManager.RemoveComponent<C>(entity);
			}
		}
	}
}
