using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pathfinding.Sync;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;

namespace Pathfinding.ECS
{
	[BurstCompile]
	public struct PollPendingPathsSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_1964892062_0
		{
			public struct ResolvedChunk
			{
				public ManagedComponentAccessor<ManagedState> item1_ManagedComponentAccessor;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ManagedState Get(int index)
				{
					return item1_ManagedComponentAccessor[index];
				}
			}

			public struct TypeHandle
			{
				public EntityManager _entityManager;

				[ReadOnly]
				private ComponentTypeHandle<ManagedState> item1_ManagedComponentTypeHandle_RO;

				public TypeHandle(ref SystemState systemState)
				{
					_entityManager = systemState.EntityManager;
					item1_ManagedComponentTypeHandle_RO = systemState.EntityManager.GetComponentTypeHandle<ManagedState>(isReadOnly: false);
				}

				public void Update(ref SystemState systemState)
				{
					item1_ManagedComponentTypeHandle_RO.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_ManagedComponentAccessor = archetypeChunk.GetManagedComponentAccessor(ref item1_ManagedComponentTypeHandle_RO, _entityManager)
					};
				}
			}

			public struct Enumerator : IEnumerator<ManagedState>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public ManagedState Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRW<ManagedState>();
			}
		}

		private struct TypeHandle
		{
			public IFE_1964892062_0.TypeHandle __IFE_1964892062_0_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_1964892062_0_TypeHandle = new IFE_1964892062_0.TypeHandle(ref state);
			}
		}

		private GCHandle onPathsCalculated;

		private static bool anyPendingPaths;

		private JobRepairPath.Scheduler jobRepairPathScheduler;

		private EntityQuery entityQueryPrepare;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1964892062_0;

		public void OnCreate(ref SystemState state)
		{
			jobRepairPathScheduler = new JobRepairPath.Scheduler(ref state)
			{
				onlyApplyPendingPaths = true
			};
			entityQueryPrepare = jobRepairPathScheduler.GetEntityQuery(Allocator.Temp).Build(ref state);
			WorldUnmanaged world = state.WorldUnmanaged;
			Action action = delegate
			{
				anyPendingPaths = true;
				try
				{
					world.GetExistingUnmanagedSystem<PollPendingPathsSystem>().Update(world);
				}
				finally
				{
					anyPendingPaths = false;
				}
			};
			AstarPath.OnPathsCalculated = (Action)Delegate.Combine(AstarPath.OnPathsCalculated, action);
			onPathsCalculated = GCHandle.Alloc(action);
		}

		public void OnDestroy(ref SystemState state)
		{
			AstarPath.OnPathsCalculated = (Action)Delegate.Remove(AstarPath.OnPathsCalculated, (Action)onPathsCalculated.Target);
			onPathsCalculated.Free();
			jobRepairPathScheduler.Dispose();
		}

		private void OnUpdate(ref SystemState systemState)
		{
			if (!anyPendingPaths)
			{
				return;
			}
			foreach (ManagedState item in IFE_1964892062_0.Query(__query_1964892062_0, __TypeHandle.__IFE_1964892062_0_TypeHandle, ref systemState))
			{
				item.CancelCurrentPathRequest();
			}
			RWLock.ReadLockAsync readLockAsync = AstarPath.active.LockGraphDataForReading();
			systemState.Dependency = jobRepairPathScheduler.ScheduleParallel(ref systemState, entityQueryPrepare, systemState.Dependency);
			readLockAsync.UnlockAfter(systemState.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<AgentOffMeshLinkTraversal>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ManagedState>();
			__query_1964892062_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((PollPendingPathsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((PollPendingPathsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			((PollPendingPathsSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((PollPendingPathsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}
	}
}
