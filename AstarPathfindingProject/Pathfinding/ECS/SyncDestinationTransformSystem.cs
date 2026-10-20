using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using UnityEngine;

namespace Pathfinding.ECS
{
	[UpdateBefore(typeof(RepairPathSystem))]
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[RequireMatchingQueriesForUpdate]
	public struct SyncDestinationTransformSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_315116516_0
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public ManagedComponentAccessor<AIDestinationSetter> item2_ManagedComponentAccessor;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public (InternalCompilerInterface.UncheckedRefRW<DestinationPoint>, AIDestinationSetter) Get(int index)
				{
					return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<DestinationPoint>(item1_IntPtr, index), item2_ManagedComponentAccessor[index]);
				}
			}

			public struct TypeHandle
			{
				public EntityManager _entityManager;

				private ComponentTypeHandle<DestinationPoint> item1_ComponentTypeHandle_RW;

				[ReadOnly]
				private ComponentTypeHandle<AIDestinationSetter> item2_ManagedComponentTypeHandle_RO;

				public TypeHandle(ref SystemState systemState)
				{
					_entityManager = systemState.EntityManager;
					item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<DestinationPoint>();
					item2_ManagedComponentTypeHandle_RO = systemState.EntityManager.GetComponentTypeHandle<AIDestinationSetter>(isReadOnly: false);
				}

				public void Update(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RW.Update(ref systemState);
					item2_ManagedComponentTypeHandle_RO.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
						item2_ManagedComponentAccessor = archetypeChunk.GetManagedComponentAccessor(ref item2_ManagedComponentTypeHandle_RO, _entityManager)
					};
				}
			}

			public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<DestinationPoint>, AIDestinationSetter)>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public (InternalCompilerInterface.UncheckedRefRW<DestinationPoint>, AIDestinationSetter) Current => _resolvedChunk.Get(_currentEntityIndex);

				object IEnumerator.Current
				{
					get
					{
						throw new NotImplementedException();
					}
				}

				public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
				{
					if (!entityQuery.IsEmptyIgnoreFilter)
					{
						CompleteDependencies(ref state);
						typeHandle.Update(ref state);
					}
					_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
					_currentEntityIndex = -1;
					_endEntityIndex = -1;
					_typeHandle = typeHandle;
					_resolvedChunk = default(ResolvedChunk);
				}

				public void Dispose()
				{
					_entityQueryEnumerator.Dispose();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public bool MoveNext()
				{
					_currentEntityIndex++;
					if (_currentEntityIndex >= _endEntityIndex)
					{
						if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
						{
							if (movedToNewChunk)
							{
								_resolvedChunk = _typeHandle.Resolve(chunk);
							}
							_currentEntityIndex = entityStartIndex;
							_endEntityIndex = entityEndIndex;
							return true;
						}
						return false;
					}
					return true;
				}

				public Enumerator GetEnumerator()
				{
					return this;
				}

				public void Reset()
				{
					throw new NotImplementedException();
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				return new Enumerator(entityQuery, typeHandle, ref state);
			}

			public static void CompleteDependencies(ref SystemState state)
			{
				state.EntityManager.CompleteDependencyBeforeRW<DestinationPoint>();
				state.EntityManager.CompleteDependencyBeforeRW<AIDestinationSetter>();
			}
		}

		private struct TypeHandle
		{
			public IFE_315116516_0.TypeHandle __IFE_315116516_0_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_315116516_0_TypeHandle = new IFE_315116516_0.TypeHandle(ref state);
			}
		}

		private TypeHandle __TypeHandle;

		private EntityQuery __query_315116516_0;

		public void OnUpdate(ref SystemState systemState)
		{
			foreach (var (uncheckedRefRW, aIDestinationSetter) in IFE_315116516_0.Query(__query_315116516_0, __TypeHandle.__IFE_315116516_0_TypeHandle, ref systemState))
			{
				if (aIDestinationSetter.target != null)
				{
					uncheckedRefRW.ValueRW = new DestinationPoint
					{
						destination = aIDestinationSetter.target.position,
						facingDirection = (aIDestinationSetter.useRotation ? aIDestinationSetter.target.forward : Vector3.zero)
					};
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<DestinationPoint>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AIDestinationSetter>();
			__query_315116516_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((SyncDestinationTransformSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((SyncDestinationTransformSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}
	}
}
