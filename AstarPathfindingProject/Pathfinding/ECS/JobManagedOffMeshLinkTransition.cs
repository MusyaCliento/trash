using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Pathfinding.ECS
{
	[WithOptions(EntityQueryOptions.IgnoreComponentEnabledState)]
	public struct JobManagedOffMeshLinkTransition : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<ManagedState> __Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle;

				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MovementControl> __Pathfinding_ECS_MovementControl_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MovementSettings> __Pathfinding_ECS_MovementSettings_RW_ComponentTypeHandle;

				public ComponentTypeHandle<AgentOffMeshLinkTraversal> __Pathfinding_ECS_AgentOffMeshLinkTraversal_RW_ComponentTypeHandle;

				public ComponentTypeHandle<ManagedAgentOffMeshLinkTraversal> __Pathfinding_ECS_ManagedAgentOffMeshLinkTraversal_RW_ComponentTypeHandle;

				public ComponentTypeHandle<AgentOffMeshLinkMovementDisabled> __Pathfinding_ECS_AgentOffMeshLinkMovementDisabled_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle = state.EntityManager.GetComponentTypeHandle<ManagedState>(isReadOnly: false);
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
					__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AgentMovementPlane>();
					__Pathfinding_ECS_MovementControl_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MovementControl>();
					__Pathfinding_ECS_MovementSettings_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSettings>();
					__Pathfinding_ECS_AgentOffMeshLinkTraversal_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AgentOffMeshLinkTraversal>();
					__Pathfinding_ECS_ManagedAgentOffMeshLinkTraversal_RW_ComponentTypeHandle = state.EntityManager.GetComponentTypeHandle<ManagedAgentOffMeshLinkTraversal>(isReadOnly: false);
					__Pathfinding_ECS_AgentOffMeshLinkMovementDisabled_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AgentOffMeshLinkMovementDisabled>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_MovementControl_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_MovementSettings_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_AgentOffMeshLinkTraversal_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_ManagedAgentOffMeshLinkTraversal_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_AgentOffMeshLinkMovementDisabled_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ManagedState>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AgentMovementPlane>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MovementControl>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MovementSettings>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AgentOffMeshLinkTraversal>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ManagedAgentOffMeshLinkTraversal>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AgentOffMeshLinkMovementDisabled>();
				entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IgnoreComponentEnabledState);
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref JobManagedOffMeshLinkTransition job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				InternalCompilerInterface.JobChunkInterface.RunByRefWithoutJobs(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref JobManagedOffMeshLinkTransition job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref JobManagedOffMeshLinkTransition job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref JobManagedOffMeshLinkTransition job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref JobManagedOffMeshLinkTransition job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref JobManagedOffMeshLinkTransition job, EntityManager entityManager)
			{
				job.__EntityManager = entityManager;
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
				if (scheduleType == 2)
				{
					throw new InvalidOperationException("Tried to ScheduleParallel a job with a managed execute signature. Please use .Run or .Schedule instead.");
				}
			}
		}

		public EntityCommandBuffer commandBuffer;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public EntityManager __EntityManager;

		public void Execute(Entity entity, ManagedState state, ref LocalTransform transform, ref AgentMovementPlane movementPlane, ref MovementControl movementControl, ref MovementSettings movementSettings, ref AgentOffMeshLinkTraversal linkInfo, ManagedAgentOffMeshLinkTraversal managedLinkInfo, EnabledRefRW<AgentOffMeshLinkMovementDisabled> movementDisabled)
		{
			if (!MoveNext(entity, state, ref transform, ref movementPlane, ref movementControl, ref movementSettings, ref linkInfo, managedLinkInfo, movementDisabled, deltaTime))
			{
				commandBuffer.RemoveComponent<AgentOffMeshLinkTraversal>(entity);
				commandBuffer.RemoveComponent<ManagedAgentOffMeshLinkTraversal>(entity);
				commandBuffer.RemoveComponent<AgentOffMeshLinkMovementDisabled>(entity);
			}
		}

		public static bool MoveNext(Entity entity, ManagedState state, ref LocalTransform transform, ref AgentMovementPlane movementPlane, ref MovementControl movementControl, ref MovementSettings movementSettings, ref AgentOffMeshLinkTraversal linkInfo, ManagedAgentOffMeshLinkTraversal managedLinkInfo, EnabledRefRW<AgentOffMeshLinkMovementDisabled> movementDisabled, float deltaTime)
		{
			managedLinkInfo.context.SetInternalData(entity, ref transform, ref movementPlane, ref movementControl, ref movementSettings, ref linkInfo, movementDisabled, state, deltaTime);
			if (managedLinkInfo.coroutine == null)
			{
				state.CancelCurrentPathRequest();
				if (managedLinkInfo.stateMachine == null)
				{
					managedLinkInfo.stateMachine = ((managedLinkInfo.handler != null) ? managedLinkInfo.handler.GetOffMeshLinkStateMachine(managedLinkInfo.context) : null);
				}
				IEnumerator coroutine;
				if (managedLinkInfo.stateMachine == null)
				{
					IEnumerator enumerator = JobStartOffMeshLinkTransition.DefaultOnTraverseOffMeshLink(managedLinkInfo.context).GetEnumerator();
					coroutine = enumerator;
				}
				else
				{
					coroutine = managedLinkInfo.stateMachine.OnTraverseOffMeshLink(managedLinkInfo.context).GetEnumerator();
				}
				managedLinkInfo.coroutine = coroutine;
			}
			bool flag = false;
			bool flag2 = true;
			movementDisabled.ValueRW = true;
			bool flag3;
			try
			{
				flag3 = !managedLinkInfo.coroutine.MoveNext();
			}
			catch (AgentOffMeshLinkTraversalContext.AbortOffMeshLinkTraversal)
			{
				flag = true;
				flag3 = true;
				flag2 = false;
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception, managedLinkInfo.context.gameObject);
				managedLinkInfo.context.Teleport(managedLinkInfo.context.link.relativeEnd);
				flag3 = true;
				flag = true;
			}
			if (flag3)
			{
				try
				{
					if (managedLinkInfo.stateMachine != null)
					{
						if (flag)
						{
							managedLinkInfo.stateMachine.OnAbortTraversingOffMeshLink();
						}
						else
						{
							managedLinkInfo.stateMachine.OnFinishTraversingOffMeshLink(managedLinkInfo.context);
						}
					}
				}
				catch (Exception exception2)
				{
					UnityEngine.Debug.LogException(exception2, managedLinkInfo.context.gameObject);
				}
				managedLinkInfo.context.Restore();
				if (flag2)
				{
					state.PopNextLinkFromPath();
				}
			}
			return !flag3;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			ManagedComponentAccessor<ManagedState> managedComponentAccessor = chunk.GetManagedComponentAccessor(ref __TypeHandle.__Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle, __EntityManager);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementControl_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementSettings_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentOffMeshLinkTraversal_RW_ComponentTypeHandle);
			ManagedComponentAccessor<ManagedAgentOffMeshLinkTraversal> managedComponentAccessor2 = chunk.GetManagedComponentAccessor(ref __TypeHandle.__Pathfinding_ECS_ManagedAgentOffMeshLinkTraversal_RW_ComponentTypeHandle, __EntityManager);
			EnabledMask enabledMask = chunk.GetEnabledMask(ref __TypeHandle.__Pathfinding_ECS_AgentOffMeshLinkMovementDisabled_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ManagedState state = managedComponentAccessor[i];
					ref LocalTransform transform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i);
					ref AgentMovementPlane movementPlane = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, i);
					ref MovementControl movementControl = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr4, i);
					ref MovementSettings movementSettings = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr5, i);
					ref AgentOffMeshLinkTraversal linkInfo = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentOffMeshLinkTraversal>(nativeArrayPtr6, i);
					ManagedAgentOffMeshLinkTraversal managedLinkInfo = managedComponentAccessor2[i];
					Execute(entity, state, ref transform, ref movementPlane, ref movementControl, ref movementSettings, ref linkInfo, managedLinkInfo, enabledMask.GetEnabledRefRW<AgentOffMeshLinkMovementDisabled>(i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						ManagedState state2 = managedComponentAccessor[nextRangeBegin];
						ref LocalTransform transform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin);
						ref AgentMovementPlane movementPlane2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, nextRangeBegin);
						ref MovementControl movementControl2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr4, nextRangeBegin);
						ref MovementSettings movementSettings2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr5, nextRangeBegin);
						ref AgentOffMeshLinkTraversal linkInfo2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentOffMeshLinkTraversal>(nativeArrayPtr6, nextRangeBegin);
						ManagedAgentOffMeshLinkTraversal managedLinkInfo2 = managedComponentAccessor2[nextRangeBegin];
						Execute(entity2, state2, ref transform2, ref movementPlane2, ref movementControl2, ref movementSettings2, ref linkInfo2, managedLinkInfo2, enabledMask.GetEnabledRefRW<AgentOffMeshLinkMovementDisabled>(nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					ManagedState state3 = managedComponentAccessor[j];
					ref LocalTransform transform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j);
					ref AgentMovementPlane movementPlane3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, j);
					ref MovementControl movementControl3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr4, j);
					ref MovementSettings movementSettings3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr5, j);
					ref AgentOffMeshLinkTraversal linkInfo3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentOffMeshLinkTraversal>(nativeArrayPtr6, j);
					ManagedAgentOffMeshLinkTraversal managedLinkInfo3 = managedComponentAccessor2[j];
					Execute(entity3, state3, ref transform3, ref movementPlane3, ref movementControl3, ref movementSettings3, ref linkInfo3, managedLinkInfo3, enabledMask.GetEnabledRefRW<AgentOffMeshLinkMovementDisabled>(j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					ManagedState state4 = managedComponentAccessor[k];
					ref LocalTransform transform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k);
					ref AgentMovementPlane movementPlane4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, k);
					ref MovementControl movementControl4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr4, k);
					ref MovementSettings movementSettings4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr5, k);
					ref AgentOffMeshLinkTraversal linkInfo4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentOffMeshLinkTraversal>(nativeArrayPtr6, k);
					ManagedAgentOffMeshLinkTraversal managedLinkInfo4 = managedComponentAccessor2[k];
					Execute(entity4, state4, ref transform4, ref movementPlane4, ref movementControl4, ref movementSettings4, ref linkInfo4, managedLinkInfo4, enabledMask.GetEnabledRefRW<AgentOffMeshLinkMovementDisabled>(k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}
}
