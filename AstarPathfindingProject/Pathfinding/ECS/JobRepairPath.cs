using System.Runtime.InteropServices;
using Pathfinding.Collections;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	public struct JobRepairPath : IJobChunk
	{
		public struct Scheduler
		{
			[ReadOnly]
			public ComponentTypeHandle<LocalTransform> LocalTransformTypeHandleRO;

			public ComponentTypeHandle<MovementState> MovementStateTypeHandleRW;

			[ReadOnly]
			public ComponentTypeHandle<AgentCylinderShape> AgentCylinderShapeTypeHandleRO;

			[NativeDisableContainerSafetyRestriction]
			public ComponentTypeHandle<ManagedState> ManagedStateTypeHandleRW;

			[ReadOnly]
			public ComponentTypeHandle<MovementSettings> MovementSettingsTypeHandleRO;

			[ReadOnly]
			public ComponentTypeHandle<DestinationPoint> DestinationPointTypeHandleRO;

			[ReadOnly]
			public ComponentTypeHandle<AgentMovementPlane> AgentMovementPlaneTypeHandleRO;

			public ComponentTypeHandle<ReadyToTraverseOffMeshLink> ReadyToTraverseOffMeshLinkTypeHandleRW;

			public GCHandle entityManagerHandle;

			public bool onlyApplyPendingPaths;

			public EntityQueryBuilder GetEntityQuery(Allocator allocator)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				entityQueryBuilder = entityQueryBuilder.WithAllRW<MovementState>();
				entityQueryBuilder = entityQueryBuilder.WithAllRW<ManagedState>();
				entityQueryBuilder = entityQueryBuilder.WithAllRW<LocalTransform>();
				entityQueryBuilder = entityQueryBuilder.WithAll<MovementSettings, DestinationPoint, AgentMovementPlane, AgentCylinderShape>();
				return entityQueryBuilder.WithAbsent<AgentOffMeshLinkTraversal>();
			}

			public Scheduler(ref SystemState systemState)
			{
				entityManagerHandle = GCHandle.Alloc(systemState.EntityManager);
				LocalTransformTypeHandleRO = systemState.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				MovementStateTypeHandleRW = systemState.GetComponentTypeHandle<MovementState>();
				AgentCylinderShapeTypeHandleRO = systemState.GetComponentTypeHandle<AgentCylinderShape>(isReadOnly: true);
				DestinationPointTypeHandleRO = systemState.GetComponentTypeHandle<DestinationPoint>(isReadOnly: true);
				AgentMovementPlaneTypeHandleRO = systemState.GetComponentTypeHandle<AgentMovementPlane>(isReadOnly: true);
				MovementSettingsTypeHandleRO = systemState.GetComponentTypeHandle<MovementSettings>(isReadOnly: true);
				ReadyToTraverseOffMeshLinkTypeHandleRW = systemState.GetComponentTypeHandle<ReadyToTraverseOffMeshLink>();
				ManagedStateTypeHandleRW = systemState.EntityManager.GetComponentTypeHandle<ManagedState>(isReadOnly: false);
				onlyApplyPendingPaths = false;
			}

			public void Dispose()
			{
				entityManagerHandle.Free();
			}

			private void Update(ref SystemState systemState)
			{
				LocalTransformTypeHandleRO.Update(ref systemState);
				MovementStateTypeHandleRW.Update(ref systemState);
				AgentCylinderShapeTypeHandleRO.Update(ref systemState);
				DestinationPointTypeHandleRO.Update(ref systemState);
				ManagedStateTypeHandleRW.Update(ref systemState);
				MovementSettingsTypeHandleRO.Update(ref systemState);
				AgentMovementPlaneTypeHandleRO.Update(ref systemState);
				ReadyToTraverseOffMeshLinkTypeHandleRW.Update(ref systemState);
			}

			public JobHandle ScheduleParallel(ref SystemState systemState, EntityQuery query, JobHandle dependency)
			{
				Update(ref systemState);
				return JobChunkExtensions.ScheduleParallel(new JobRepairPath
				{
					scheduler = this,
					onlyApplyPendingPaths = onlyApplyPendingPaths
				}, query, dependency);
			}
		}

		public Scheduler scheduler;

		[NativeDisableContainerSafetyRestriction]
		public NativeArray<int> indicesScratch;

		[NativeDisableContainerSafetyRestriction]
		public NativeList<float3> nextCornersScratch;

		public bool onlyApplyPendingPaths;

		private static readonly ProfilerMarker MarkerRepair = new ProfilerMarker("Repair");

		private static readonly ProfilerMarker MarkerGetNextCorners = new ProfilerMarker("GetNextCorners");

		private static readonly ProfilerMarker MarkerUpdateReachedEndInfo = new ProfilerMarker("UpdateReachedEndInfo");

		public unsafe void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			if (!indicesScratch.IsCreated)
			{
				nextCornersScratch = new NativeList<float3>(Allocator.Temp);
				indicesScratch = new NativeArray<int>(8, Allocator.Temp);
			}
			LocalTransform* unsafeReadOnlyPtr = (LocalTransform*)chunk.GetNativeArray(ref scheduler.LocalTransformTypeHandleRO).GetUnsafeReadOnlyPtr();
			MovementState* unsafePtr = (MovementState*)chunk.GetNativeArray(ref scheduler.MovementStateTypeHandleRW).GetUnsafePtr();
			AgentCylinderShape* unsafeReadOnlyPtr2 = (AgentCylinderShape*)chunk.GetNativeArray(ref scheduler.AgentCylinderShapeTypeHandleRO).GetUnsafeReadOnlyPtr();
			DestinationPoint* unsafeReadOnlyPtr3 = (DestinationPoint*)chunk.GetNativeArray(ref scheduler.DestinationPointTypeHandleRO).GetUnsafeReadOnlyPtr();
			MovementSettings* unsafeReadOnlyPtr4 = (MovementSettings*)chunk.GetNativeArray(ref scheduler.MovementSettingsTypeHandleRO).GetUnsafeReadOnlyPtr();
			AgentMovementPlane* unsafeReadOnlyPtr5 = (AgentMovementPlane*)chunk.GetNativeArray(ref scheduler.AgentMovementPlaneTypeHandleRO).GetUnsafeReadOnlyPtr();
			EnabledMask enabledMask = chunk.GetEnabledMask(ref scheduler.ReadyToTraverseOffMeshLinkTypeHandleRW);
			ManagedComponentAccessor<ManagedState> managedComponentAccessor = chunk.GetManagedComponentAccessor(ref scheduler.ManagedStateTypeHandleRW, (EntityManager)scheduler.entityManagerHandle.Target);
			for (int i = 0; i < chunk.Count; i++)
			{
				Execute(ref unsafeReadOnlyPtr[i], ref unsafePtr[i], ref unsafeReadOnlyPtr2[i], ref unsafeReadOnlyPtr5[i], ref unsafeReadOnlyPtr3[i], enabledMask.GetEnabledRefRW<ReadyToTraverseOffMeshLink>(i), managedComponentAccessor[i], in unsafeReadOnlyPtr4[i], nextCornersScratch, ref indicesScratch, Allocator.Temp, onlyApplyPendingPaths);
			}
		}

		public static void Execute(ref LocalTransform transform, ref MovementState state, ref AgentCylinderShape shape, ref AgentMovementPlane movementPlane, ref DestinationPoint destination, EnabledRefRW<ReadyToTraverseOffMeshLink> readyToTraverseOffMeshLink, ManagedState managedState, in MovementSettings settings, NativeList<float3> nextCornersScratch, ref NativeArray<int> indicesScratch, Allocator allocator, bool onlyApplyPendingPaths)
		{
			if (onlyApplyPendingPaths)
			{
				if (managedState.pendingPath == null || !managedState.pendingPath.IsDone())
				{
					return;
				}
				ManagedState.SetPath(managedState.pendingPath, managedState, in movementPlane, ref destination);
			}
			ref PathTracer pathTracer = ref managedState.pathTracer;
			if (pathTracer.hasPath)
			{
				state.closestOnNavmesh = pathTracer.UpdateStart(transform.Position, PathTracer.RepairQuality.High, movementPlane.value, managedState.pathfindingSettings.traversalProvider, managedState.activePath);
				state.endOfPath = pathTracer.UpdateEnd(destination.destination, PathTracer.RepairQuality.High, movementPlane.value, managedState.pathfindingSettings.traversalProvider, managedState.activePath);
				if (state.pathTracerVersion != pathTracer.version)
				{
					nextCornersScratch.Clear();
					bool lastCorner;
					int nextCornerIndices = pathTracer.GetNextCornerIndices(ref indicesScratch, pathTracer.desiredCornersForGoodSimplification, allocator, out lastCorner, managedState.pathfindingSettings.traversalProvider, managedState.activePath);
					pathTracer.ConvertCornerIndicesToPathProjected(indicesScratch, nextCornerIndices, lastCorner, nextCornersScratch, movementPlane.value.up);
					JobRepairPathHelpers.PathTracerInfo pathTracer2 = new JobRepairPathHelpers.PathTracerInfo
					{
						endPointOfFirstPart = pathTracer.endPointOfFirstPart,
						partCount = pathTracer.partCount,
						isStale = pathTracer.isStale
					};
					UnsafeSpan<float3> nextCorners = nextCornersScratch.AsUnsafeSpan();
					JobRepairPathHelpers.UpdateReachedEndInfo(ref nextCorners, ref state, ref movementPlane, ref transform, ref shape, ref destination, settings.stopDistance, ref pathTracer2);
					state.pathTracerVersion = pathTracer.version;
				}
				else
				{
					JobRepairPathHelpers.UpdateReachedOrientation(ref state, ref transform, ref movementPlane, ref destination);
				}
				if (pathTracer.startNode != null && !pathTracer.startNode.Destroyed && pathTracer.startNode.Walkable)
				{
					state.graphIndex = pathTracer.startNode.GraphIndex;
					state.hierarchicalNodeIndex = pathTracer.startNode.HierarchicalNodeIndex;
				}
				else
				{
					state.graphIndex = 255u;
					state.hierarchicalNodeIndex = -1;
				}
			}
			else
			{
				state.SetPathIsEmpty(transform.Position);
			}
			if (readyToTraverseOffMeshLink.IsValid)
			{
				readyToTraverseOffMeshLink.ValueRW = state.reachedEndOfPart && managedState.pathTracer.isNextPartValidLink;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}
}
