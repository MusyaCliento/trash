using System;
using System.Runtime.CompilerServices;
using Pathfinding.Drawing;
using Pathfinding.ECS.RVO;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Profiling;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Jobs;

namespace Pathfinding.ECS
{
	[BurstCompile]
	[UpdateAfter(typeof(FollowerControlSystem))]
	[UpdateAfter(typeof(RVOSystem))]
	[UpdateAfter(typeof(FallbackResolveMovementSystem))]
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[RequireMatchingQueriesForUpdate]
	public struct AIMoveSystem : ISystem, ISystemCompilerGenerated
	{
		private struct TypeHandle
		{
			[ReadOnly]
			public ComponentLookup<SyncPositionWithTransform> __Pathfinding_ECS_SyncPositionWithTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SyncRotationWithTransform> __Pathfinding_ECS_SyncRotationWithTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<OrientationYAxisForward> __Pathfinding_ECS_OrientationYAxisForward_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MovementState> __Pathfinding_ECS_MovementState_RO_ComponentLookup;

			public JobAlignAgentWithMovementDirection.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobAlignAgentWithMovementDirection_WithDefaultQuery_JobEntityTypeHandle;

			public JobMoveAgent.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobMoveAgent_WithDefaultQuery_JobEntityTypeHandle;

			public JobPrepareAgentRaycasts.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobPrepareAgentRaycasts_WithoutDefaultQuery_JobEntityTypeHandle;

			public JobApplyGravity.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobApplyGravity_WithoutDefaultQuery_JobEntityTypeHandle;

			public JobManagedMovementOverrideBeforeMovement.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobManagedMovementOverrideBeforeMovement_WithoutDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Pathfinding_ECS_SyncPositionWithTransform_RO_ComponentLookup = state.GetComponentLookup<SyncPositionWithTransform>(isReadOnly: true);
				__Pathfinding_ECS_SyncRotationWithTransform_RO_ComponentLookup = state.GetComponentLookup<SyncRotationWithTransform>(isReadOnly: true);
				__Pathfinding_ECS_OrientationYAxisForward_RO_ComponentLookup = state.GetComponentLookup<OrientationYAxisForward>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
				__Pathfinding_ECS_MovementState_RO_ComponentLookup = state.GetComponentLookup<MovementState>(isReadOnly: true);
				__Pathfinding_ECS_JobAlignAgentWithMovementDirection_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pathfinding_ECS_JobMoveAgent_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pathfinding_ECS_JobPrepareAgentRaycasts_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__Pathfinding_ECS_JobApplyGravity_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__Pathfinding_ECS_JobManagedMovementOverrideBeforeMovement_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			}
		}

		private EntityQuery entityQueryPrepareMovement;

		private EntityQuery entityQueryWithGravity;

		private EntityQuery entityQueryGizmos;

		private EntityQuery entityQueryMovementOverride;

		private JobRepairPath.Scheduler jobRepairPathScheduler;

		private ComponentTypeHandle<MovementState> MovementStateTypeHandleRO;

		private ComponentTypeHandle<ResolvedMovement> ResolvedMovementHandleRO;

		private static readonly ProfilerMarker MarkerMovementOverride = new ProfilerMarker("MovementOverrideBeforeMovement");

		private TypeHandle __TypeHandle;

		public void OnCreate(ref SystemState state)
		{
			jobRepairPathScheduler = new JobRepairPath.Scheduler(ref state);
			MovementStateTypeHandleRO = state.GetComponentTypeHandle<MovementState>(isReadOnly: true);
			ResolvedMovementHandleRO = state.GetComponentTypeHandle<ResolvedMovement>(isReadOnly: true);
			entityQueryWithGravity = state.GetEntityQuery(ComponentType.ReadWrite<LocalTransform>(), ComponentType.ReadOnly<AgentCylinderShape>(), ComponentType.ReadWrite<AgentMovementPlane>(), ComponentType.ReadWrite<MovementState>(), ComponentType.ReadOnly<MovementSettings>(), ComponentType.ReadWrite<ResolvedMovement>(), ComponentType.ReadWrite<MovementStatistics>(), ComponentType.ReadOnly<MovementControl>(), ComponentType.ReadWrite<GravityState>(), ComponentType.ReadOnly<PhysicsSceneRef>(), ComponentType.Exclude<OrientationYAxisForward>(), ComponentType.ReadOnly<AgentMovementPlaneSource>(), ComponentType.ReadOnly<SimulateMovement>(), ComponentType.ReadOnly<SimulateMovementFinalize>());
			EntityQueryBuilder entityQueryBuilder = jobRepairPathScheduler.GetEntityQuery(Allocator.Temp);
			entityQueryBuilder = entityQueryBuilder.WithAll<SimulateMovement, SimulateMovementRepair>();
			entityQueryPrepareMovement = entityQueryBuilder.Build(ref state);
			entityQueryGizmos = state.GetEntityQuery(ComponentType.ReadOnly<LocalTransform>(), ComponentType.ReadOnly<AgentCylinderShape>(), ComponentType.ReadOnly<MovementSettings>(), ComponentType.ReadOnly<AgentMovementPlane>(), ComponentType.ReadOnly<ManagedState>(), ComponentType.ReadOnly<MovementState>(), ComponentType.ReadOnly<ResolvedMovement>(), ComponentType.ReadOnly<SimulateMovement>());
			entityQueryMovementOverride = state.GetEntityQuery(ComponentType.ReadWrite<ManagedMovementOverrideBeforeMovement>(), ComponentType.ReadWrite<LocalTransform>(), ComponentType.ReadWrite<AgentCylinderShape>(), ComponentType.ReadWrite<AgentMovementPlane>(), ComponentType.ReadWrite<DestinationPoint>(), ComponentType.ReadWrite<MovementState>(), ComponentType.ReadWrite<MovementStatistics>(), ComponentType.ReadWrite<ManagedState>(), ComponentType.ReadWrite<MovementSettings>(), ComponentType.ReadWrite<ResolvedMovement>(), ComponentType.ReadWrite<MovementControl>(), ComponentType.Exclude<AgentOffMeshLinkTraversal>(), ComponentType.ReadOnly<SimulateMovement>(), ComponentType.ReadOnly<SimulateMovementControl>());
		}

		public void OnDestroy(ref SystemState state)
		{
			jobRepairPathScheduler.Dispose();
		}

		public void OnUpdate(ref SystemState systemState)
		{
			CommandBuilder builder = DrawingManager.GetBuilder();
			float cheapStepDeltaTime = AIMovementSystemGroup.TimeScaledRateManager.CheapStepDeltaTime;
			systemState.Dependency = __ScheduleViaJobChunkExtension_0(new JobAlignAgentWithMovementDirection
			{
				dt = cheapStepDeltaTime
			}, __TypeHandle.__Pathfinding_ECS_JobAlignAgentWithMovementDirection_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, systemState.Dependency, ref systemState, hasUserDefinedQuery: false);
			RunMovementOverrideBeforeMovement(ref systemState, cheapStepDeltaTime);
			systemState.Dependency = __ScheduleViaJobChunkExtension_1(new JobMoveAgent
			{
				dt = cheapStepDeltaTime
			}, __TypeHandle.__Pathfinding_ECS_JobMoveAgent_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, systemState.Dependency, ref systemState, hasUserDefinedQuery: false);
			ScheduleApplyGravity(ref systemState, builder, cheapStepDeltaTime);
			JobHandle jobHandle = systemState.Dependency;
			UpdateTypeHandles(ref systemState);
			systemState.Dependency = ScheduleRepairPaths(ref systemState, systemState.Dependency);
			if (Application.isEditor && AIMovementSystemGroup.TimeScaledRateManager.IsLastSubstep)
			{
				jobHandle = ScheduleDrawGizmos(builder, systemState.Dependency);
			}
			builder.DisposeAfter(jobHandle);
			systemState.Dependency = ScheduleSyncEntitiesToTransforms(ref systemState, systemState.Dependency);
			systemState.Dependency = JobHandle.CombineDependencies(systemState.Dependency, jobHandle);
		}

		private void ScheduleApplyGravity(ref SystemState systemState, CommandBuilder draw, float dt)
		{
			int length = entityQueryWithGravity.CalculateEntityCount();
			NativeArray<RaycastCommand> nativeArray = CollectionHelper.CreateNativeArray<RaycastCommand>(length, systemState.WorldUpdateAllocator, NativeArrayOptions.UninitializedMemory);
			NativeArray<RaycastHit> nativeArray2 = CollectionHelper.CreateNativeArray<RaycastHit>(length, systemState.WorldUpdateAllocator, NativeArrayOptions.UninitializedMemory);
			systemState.Dependency = __ScheduleViaJobChunkExtension_2(new JobPrepareAgentRaycasts
			{
				raycastQueryParameters = new QueryParameters(-1, hitMultipleFaces: false, QueryTriggerInteraction.Ignore),
				raycastCommands = nativeArray,
				draw = draw,
				dt = dt,
				gravity = Physics.gravity.y
			}, entityQueryWithGravity, systemState.Dependency, ref systemState, hasUserDefinedQuery: true);
			JobHandle job = RaycastCommand.ScheduleBatch(nativeArray, nativeArray2, 32, 1, systemState.Dependency);
			systemState.Dependency = __ScheduleViaJobChunkExtension_3(new JobApplyGravity
			{
				raycastHits = nativeArray2,
				raycastCommands = nativeArray,
				draw = draw,
				dt = dt
			}, entityQueryWithGravity, JobHandle.CombineDependencies(systemState.Dependency, job), ref systemState, hasUserDefinedQuery: true);
		}

		private void RunMovementOverrideBeforeMovement(ref SystemState systemState, float dt)
		{
			if (!entityQueryMovementOverride.IsEmptyIgnoreFilter)
			{
				systemState.CompleteDependency();
				__ScheduleViaJobChunkExtension_4(new JobManagedMovementOverrideBeforeMovement
				{
					dt = dt
				}, entityQueryMovementOverride, systemState.Dependency, ref systemState, hasUserDefinedQuery: true);
			}
		}

		private void UpdateTypeHandles(ref SystemState systemState)
		{
			MovementStateTypeHandleRO.Update(ref systemState);
			ResolvedMovementHandleRO.Update(ref systemState);
		}

		private JobHandle ScheduleRepairPaths(ref SystemState systemState, JobHandle dependency)
		{
			dependency = jobRepairPathScheduler.ScheduleParallel(ref systemState, entityQueryPrepareMovement, dependency);
			return dependency;
		}

		private JobHandle ScheduleDrawGizmos(CommandBuilder commandBuilder, JobHandle dependency)
		{
			return JobChunkExtensions.ScheduleParallel(new JobDrawFollowerGizmos
			{
				draw = commandBuilder,
				entityManagerHandle = jobRepairPathScheduler.entityManagerHandle,
				LocalTransformTypeHandleRO = jobRepairPathScheduler.LocalTransformTypeHandleRO,
				AgentCylinderShapeHandleRO = jobRepairPathScheduler.AgentCylinderShapeTypeHandleRO,
				MovementSettingsHandleRO = jobRepairPathScheduler.MovementSettingsTypeHandleRO,
				AgentMovementPlaneHandleRO = jobRepairPathScheduler.AgentMovementPlaneTypeHandleRO,
				ManagedStateHandleRW = jobRepairPathScheduler.ManagedStateTypeHandleRW,
				MovementStateHandleRO = MovementStateTypeHandleRO,
				ResolvedMovementHandleRO = ResolvedMovementHandleRO
			}, entityQueryGizmos, dependency);
		}

		private JobHandle ScheduleSyncEntitiesToTransforms(ref SystemState systemState, JobHandle dependency)
		{
			TransformAccessArray transforms;
			FollowerEntity[] components2;
			int components = BatchedEvents.GetComponents<FollowerEntity>(BatchedEvents.Event.None, out transforms, out components2);
			if (components == 0)
			{
				return dependency;
			}
			NativeArray<Entity> entities = CollectionHelper.CreateNativeArray<Entity>(components, systemState.WorldUpdateAllocator);
			for (int i = 0; i < components; i++)
			{
				entities[i] = components2[i].entity;
			}
			dependency = new JobSyncEntitiesToTransforms
			{
				entities = entities,
				syncPositionWithTransform = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pathfinding_ECS_SyncPositionWithTransform_RO_ComponentLookup, ref systemState),
				syncRotationWithTransform = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pathfinding_ECS_SyncRotationWithTransform_RO_ComponentLookup, ref systemState),
				orientationYAxisForward = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pathfinding_ECS_OrientationYAxisForward_RO_ComponentLookup, ref systemState),
				entityPositions = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref systemState),
				movementState = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pathfinding_ECS_MovementState_RO_ComponentLookup, ref systemState)
			}.Schedule(transforms, dependency);
			return dependency;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(JobAlignAgentWithMovementDirection job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pathfinding_ECS_JobAlignAgentWithMovementDirection_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pathfinding_ECS_JobAlignAgentWithMovementDirection_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_JobAlignAgentWithMovementDirection_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pathfinding_ECS_JobAlignAgentWithMovementDirection_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(JobMoveAgent job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pathfinding_ECS_JobMoveAgent_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pathfinding_ECS_JobMoveAgent_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_JobMoveAgent_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pathfinding_ECS_JobMoveAgent_WithDefaultQuery_JobEntityTypeHandle.ScheduleParallel(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_2(JobPrepareAgentRaycasts job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pathfinding_ECS_JobPrepareAgentRaycasts_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pathfinding_ECS_JobPrepareAgentRaycasts_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_JobPrepareAgentRaycasts_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pathfinding_ECS_JobPrepareAgentRaycasts_WithoutDefaultQuery_JobEntityTypeHandle.ScheduleParallel(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_3(JobApplyGravity job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pathfinding_ECS_JobApplyGravity_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pathfinding_ECS_JobApplyGravity_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_JobApplyGravity_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pathfinding_ECS_JobApplyGravity_WithoutDefaultQuery_JobEntityTypeHandle.ScheduleParallel(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_4(JobManagedMovementOverrideBeforeMovement job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			__TypeHandle.__Pathfinding_ECS_JobManagedMovementOverrideBeforeMovement_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
			__TypeHandle.__Pathfinding_ECS_JobManagedMovementOverrideBeforeMovement_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_JobManagedMovementOverrideBeforeMovement_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			__TypeHandle.__Pathfinding_ECS_JobManagedMovementOverrideBeforeMovement_WithoutDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			new EntityQueryBuilder(Allocator.Temp).Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((AIMoveSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((AIMoveSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			((AIMoveSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((AIMoveSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}
	}
}
