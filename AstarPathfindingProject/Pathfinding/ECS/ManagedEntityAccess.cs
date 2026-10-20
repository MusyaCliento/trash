using System.Runtime.CompilerServices;
using Unity.Entities;

namespace Pathfinding.ECS
{
	public struct ManagedEntityAccess<T> where T : class, IComponentData
	{
		private EntityManager entityManager;

		private ComponentTypeHandle<T> handle;

		private bool readOnly;

		public T this[EntityStorageInfo storage]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return storage.Chunk.GetManagedComponentAccessor(ref handle, entityManager)[storage.IndexInChunk];
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				ManagedComponentAccessor<T> managedComponentAccessor = storage.Chunk.GetManagedComponentAccessor(ref handle, entityManager);
				managedComponentAccessor[storage.IndexInChunk] = value;
			}
		}

		public ManagedEntityAccess(bool readOnly)
		{
			entityManager = default(EntityManager);
			handle = default(ComponentTypeHandle<T>);
			this.readOnly = readOnly;
		}

		public ManagedEntityAccess(EntityManager entityManager, bool readOnly)
			: this(readOnly)
		{
			Update(entityManager);
		}

		public void Update(EntityManager entityManager)
		{
			if (readOnly)
			{
				entityManager.CompleteDependencyBeforeRO<T>();
			}
			else
			{
				entityManager.CompleteDependencyBeforeRW<T>();
			}
			handle = entityManager.GetComponentTypeHandle<T>(readOnly);
			this.entityManager = entityManager;
		}
	}
}
