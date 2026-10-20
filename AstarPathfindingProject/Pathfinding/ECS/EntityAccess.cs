using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Pathfinding.ECS
{
	public struct EntityAccess<T> where T : unmanaged, IComponentData
	{
		public ComponentTypeHandle<T> handle;

		private uint lastSystemVersion;

		private ulong worldSequenceNumber;

		private bool readOnly;

		public unsafe ref T this[EntityStorageInfo storage]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (readOnly)
				{
					return ref *(T*)((byte*)storage.Chunk.GetRequiredComponentDataPtrRO(ref handle) + (nint)storage.IndexInChunk * (nint)sizeof(T));
				}
				return ref *(T*)((byte*)storage.Chunk.GetRequiredComponentDataPtrRW(ref handle) + (nint)storage.IndexInChunk * (nint)sizeof(T));
			}
		}

		public EntityAccess(bool readOnly)
		{
			handle = default(ComponentTypeHandle<T>);
			this.readOnly = readOnly;
			lastSystemVersion = 0u;
			worldSequenceNumber = 0uL;
		}

		public unsafe void Update(EntityManager entityManager)
		{
			uint globalSystemVersion = entityManager.GlobalSystemVersion;
			ulong sequenceNumber = entityManager.WorldUnmanaged.SequenceNumber;
			if (globalSystemVersion != lastSystemVersion || worldSequenceNumber != sequenceNumber)
			{
				if (lastSystemVersion == 0 || worldSequenceNumber != sequenceNumber)
				{
					handle = entityManager.GetComponentTypeHandle<T>(readOnly);
				}
				lastSystemVersion = globalSystemVersion;
				worldSequenceNumber = sequenceNumber;
				if (readOnly)
				{
					entityManager.CompleteDependencyBeforeRO<T>();
				}
				else
				{
					entityManager.CompleteDependencyBeforeRW<T>();
				}
			}
			byte* ptr = (byte*)UnsafeUtility.AddressOf(ref handle);
			*(uint*)(ptr + EntityAccessHelper.GlobalSystemVersionOffset) = globalSystemVersion;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool HasComponent(EntityStorageInfo storage)
		{
			return storage.Chunk.Has(ref handle);
		}
	}
}
