using System;
using System.Runtime.CompilerServices;
using Pathfinding.Drawing;
using Pathfinding.Sync;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Profiling;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[BurstCompile]
	public struct FollowerControlSystem : ISystem, ISystemCompilerGenerated
	{
		private struct TypeHandle
		{
			public JobManagedMovementOverrideBeforeControl.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobManagedMovementOverrideBeforeControl_WithoutDefaultQuery_JobEntityTypeHandle;

			public JobControl.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobControl_WithDefaultQuery_JobEntityTypeHandle;

			public JobManagedMovementOverrideAfterControl.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobManagedMovementOverrideAfterControl_WithoutDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Pathfinding_ECS_JobManagedMovementOverrideBeforeControl_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__Pathfinding_ECS_JobControl_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pathfinding_ECS_JobManagedMovementOverrideAfterControl_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			}
		}

		private EntityQuery entityQueryControlManaged;

		private EntityQuery entityQueryControlManaged2;

		private RedrawScope redrawScope;

		private static readonly ProfilerMarker MarkerMovementOverrideBeforeControl = new ProfilerMarker("MovementOverrideBeforeControl");

		private static readonly ProfilerMarker MarkerMovementOverrideAfterControl = new ProfilerMarker("MovementOverrideAfterControl");

		private TypeHandle __TypeHandle;

		public void OnCreate(ref SystemState state)
		{
			redrawScope = DrawingManager.GetRedrawScope();
			entityQueryControlManaged = state.GetEntityQuery(ComponentType.ReadWrite<ManagedMovementOverrideBeforeControl>(), ComponentType.ReadWrite<LocalTransform>(), ComponentType.ReadWrite<AgentCylinderShape>(), ComponentType.ReadWrite<AgentMovementPlane>(), ComponentType.ReadWrite<DestinationPoint>(), ComponentType.ReadWrite<MovementState>(), ComponentType.ReadWrite<MovementStatistics>(), ComponentType.ReadWrite<ManagedState>(), ComponentType.ReadWrite<MovementSettings>(), ComponentType.ReadWrite<ResolvedMovement>(), ComponentType.ReadWrite<MovementControl>(), ComponentType.Exclude<AgentOffMeshLinkTraversal>(), ComponentType.ReadOnly<SimulateMovement>(), ComponentType.ReadOnly<SimulateMovementControl>());
			entityQueryControlManaged2 = state.GetEntityQuery(ComponentType.ReadWrite<ManagedMovementOverrideAfterControl>(), ComponentType.ReadWrite<LocalTransform>(), ComponentType.ReadWrite<AgentCylinderShape>(), ComponentType.ReadWrite<AgentMovementPlane>(), ComponentType.ReadWrite<DestinationPoint>(), ComponentType.ReadWrite<MovementState>(), ComponentType.ReadWrite<MovementStatistics>(), ComponentType.ReadWrite<ManagedState>(), ComponentType.ReadWrite<MovementSettings>(), ComponentType.ReadWrite<ResolvedMovement>(), ComponentType.ReadWrite<MovementControl>(), ComponentType.Exclude<AgentOffMeshLinkTraversal>(), ComponentType.ReadOnly<SimulateMovement>(), ComponentType.ReadOnly<SimulateMovementControl>());
		}

		public void OnDestroy(ref SystemState state)
		{
			redrawScope.Dispose();
		}

		public void OnUpdate(ref SystemState systemState)
		{
			if (AstarPath.active != null && !AIMovementSystemGroup.TimeScaledRateManager.CheapSimulationOnly)
			{
				ProcessControlLoop(ref systemState, systemState.WorldUnmanaged.Time.DeltaTime);
			}
		}

		private void ProcessControlLoop(ref SystemState systemState, float dt)
		{
			if (!entityQueryControlManaged.IsEmpty)
			{
				systemState.Dependency.Complete();
				__ScheduleViaJobChunkExtension_0(new JobManagedMovementOverrideBeforeControl
				{
					dt = dt
				}, entityQueryControlManaged, systemState.Dependency, ref systemState, hasUserDefinedQuery: true);
			}
			redrawScope.Rewind();
			CommandBuilder builder = DrawingManager.GetBuilder(redrawScope);
			RWLock.CombinedReadLockAsync readLock;
			NavmeshEdges.NavmeshBorderData navmeshBorderData = AstarPath.active.GetNavmeshBorderData(out readLock);
			systemState.Dependency = __ScheduleViaJobChunkExtension_1(new JobControl
			{
				navmeshEdgeData = navmeshBorderData,
				draw = builder,
				dt = dt
			}, __TypeHandle.__Pathfinding_ECS_JobControl_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, JobHandle.CombineDependencies(systemState.Dependency, readLock.dependency), ref systemState, hasUserDefinedQuery: false);
			readLock.UnlockAfter(systemState.Dependency);
			builder.DisposeAfter(systemState.Dependency);
			if (!entityQueryControlManaged2.IsEmpty)
			{
				systemState.Dependency.Complete();
				__ScheduleViaJobChunkExtension_2(new JobManagedMovementOverrideAfterControl
				{
					dt = dt
				}, entityQueryControlManaged2, systemState.Dependency, ref systemState, hasUserDefinedQuery: true);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_0(JobManagedMovementOverrideBeforeControl job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			__TypeHandle.__Pathfinding_ECS_JobManagedMovementOverrideBeforeControl_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
			__TypeHandle.__Pathfinding_ECS_JobManagedMovementOverrideBeforeControl_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_JobManagedMovementOverrideBeforeControl_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			__TypeHandle.__Pathfinding_ECS_JobManagedMovementOverrideBeforeControl_WithoutDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(JobControl job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pathfinding_ECS_JobControl_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pathfinding_ECS_JobControl_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_JobControl_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pathfinding_ECS_JobControl_WithDefaultQuery_JobEntityTypeHandle.ScheduleParallel(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_2(JobManagedMovementOverrideAfterControl job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			__TypeHandle.__Pathfinding_ECS_JobManagedMovementOverrideAfterControl_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
			__TypeHandle.__Pathfinding_ECS_JobManagedMovementOverrideAfterControl_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_JobManagedMovementOverrideAfterControl_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			__TypeHandle.__Pathfinding_ECS_JobManagedMovementOverrideAfterControl_WithoutDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
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
			((FollowerControlSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((FollowerControlSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			((FollowerControlSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((FollowerControlSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}
	}
}
