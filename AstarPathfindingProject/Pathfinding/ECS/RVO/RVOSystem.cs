using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pathfinding.RVO;
using Pathfinding.Sync;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Pathfinding.ECS.RVO
{
	[BurstCompile]
	[UpdateAfter(typeof(FollowerControlSystem))]
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	public struct RVOSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		public struct JobCopyFromEntitiesToRVOSimulator : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentCylinderShape> __Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentIndex> __Pathfinding_ECS_RVO_AgentIndex_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<RVOAgent> __Pathfinding_ECS_RVO_RVOAgent_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<MovementControl> __Pathfinding_ECS_MovementControl_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
						__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentCylinderShape>(isReadOnly: true);
						__Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentMovementPlane>(isReadOnly: true);
						__Pathfinding_ECS_RVO_AgentIndex_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentIndex>(isReadOnly: true);
						__Pathfinding_ECS_RVO_RVOAgent_RO_ComponentTypeHandle = state.GetComponentTypeHandle<RVOAgent>(isReadOnly: true);
						__Pathfinding_ECS_MovementControl_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementControl>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_RVO_AgentIndex_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_RVO_RVOAgent_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_MovementControl_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<AgentCylinderShape>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<AgentMovementPlane>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<AgentIndex>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<RVOAgent>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<MovementControl>();
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
				public void Run(ref JobCopyFromEntitiesToRVOSimulator job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobCopyFromEntitiesToRVOSimulator job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobCopyFromEntitiesToRVOSimulator job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobCopyFromEntitiesToRVOSimulator job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobCopyFromEntitiesToRVOSimulator job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobCopyFromEntitiesToRVOSimulator job, EntityManager entityManager)
				{
				}
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[NativeDisableParallelForRestriction]
			public SimulatorBurst.AgentData agentData;

			[ReadOnly]
			public SimulatorBurst.AgentOutputData agentOutputData;

			public MovementPlane movementPlaneMode;

			[ReadOnly]
			public ComponentLookup<AgentOffMeshLinkTraversal> agentOffMeshLinkTraversalLookup;

			public float dt;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity entity, in LocalTransform transform, in AgentCylinderShape shape, in AgentMovementPlane movementPlane, in AgentIndex agentIndex, in RVOAgent controller, in MovementControl target)
			{
				float num = math.abs(transform.Scale);
				if (!agentIndex.TryGetIndex(ref agentData, out var index))
				{
					throw new InvalidOperationException("RVOAgent has an invalid entity index");
				}
				agentData.radius[index] = math.clamp(shape.radius * num, 0.001f, 100000f);
				agentData.agentTimeHorizon[index] = math.clamp(controller.agentTimeHorizon, 0f, 100000f);
				agentData.obstacleTimeHorizon[index] = math.clamp(controller.obstacleTimeHorizon, 0f, 100000f);
				agentData.locked[index] = controller.locked;
				agentData.maxNeighbours[index] = math.max(controller.maxNeighbours, 0);
				agentData.debugFlags[index] = controller.debug;
				agentData.layer[index] = controller.layer;
				agentData.collidesWith[index] = controller.collidesWith;
				agentData.targetPoint[index] = target.targetPoint;
				agentData.desiredSpeed[index] = math.clamp(target.speed, 0f, 100000f);
				agentData.maxSpeed[index] = math.clamp(target.maxSpeed, 0f, 100000f);
				agentData.manuallyControlled[index] = target.overrideLocalAvoidance;
				agentData.endOfPath[index] = target.endOfPath;
				agentData.hierarchicalNodeIndex[index] = target.hierarchicalNodeIndex;
				agentData.movementPlane[index] = movementPlane.value;
				float elevation;
				float2 p = movementPlane.value.ToPlane(transform.Position, out elevation);
				float num2 = 0.5f * shape.height;
				if (movementPlaneMode == MovementPlane.XY)
				{
					agentData.height[index] = 1f;
					agentData.position[index] = movementPlane.value.ToWorld(p);
				}
				else
				{
					agentData.height[index] = math.clamp(shape.height * num, 0f, 100000f);
					agentData.position[index] = movementPlane.value.ToWorld(p, elevation + (num2 - 0.5f * shape.height) * num);
				}
				ReachedEndOfPath reachedEndOfPath = agentOutputData.effectivelyReachedDestination[index];
				float num3 = math.clamp(controller.priority * controller.priorityMultiplier, 0f, 100000f);
				float value = math.clamp(controller.flowFollowingStrength, 0f, 1f);
				switch (reachedEndOfPath)
				{
				case ReachedEndOfPath.Reached:
					value = math.lerp(agentData.flowFollowingStrength[index], 1f, 6f * dt);
					num3 *= 0.3f;
					break;
				case ReachedEndOfPath.ReachedSoon:
					value = math.lerp(agentData.flowFollowingStrength[index], 1f, 6f * dt);
					num3 *= 0.45f;
					break;
				}
				agentData.priority[index] = num3;
				agentData.flowFollowingStrength[index] = value;
				if (agentOffMeshLinkTraversalLookup.HasComponent(entity))
				{
					agentData.manuallyControlled[index] = true;
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_RVO_AgentIndex_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_RVO_RVOAgent_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementControl_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentIndex>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RVOAgent>(nativeArrayPtr6, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr7, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentIndex>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RVOAgent>(nativeArrayPtr6, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr7, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentIndex>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RVOAgent>(nativeArrayPtr6, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr7, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentIndex>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RVOAgent>(nativeArrayPtr6, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr7, k));
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

		[BurstCompile]
		public struct JobCopyFromRVOSimulatorToEntities : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentCylinderShape> __Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentIndex> __Pathfinding_ECS_RVO_AgentIndex_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<RVOAgent> __Pathfinding_ECS_RVO_RVOAgent_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<MovementControl> __Pathfinding_ECS_MovementControl_RO_ComponentTypeHandle;

					public ComponentTypeHandle<ResolvedMovement> __Pathfinding_ECS_ResolvedMovement_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
						__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentCylinderShape>(isReadOnly: true);
						__Pathfinding_ECS_RVO_AgentIndex_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentIndex>(isReadOnly: true);
						__Pathfinding_ECS_RVO_RVOAgent_RO_ComponentTypeHandle = state.GetComponentTypeHandle<RVOAgent>(isReadOnly: true);
						__Pathfinding_ECS_MovementControl_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementControl>(isReadOnly: true);
						__Pathfinding_ECS_ResolvedMovement_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ResolvedMovement>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_RVO_AgentIndex_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_RVO_RVOAgent_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_MovementControl_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_ResolvedMovement_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<AgentCylinderShape>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<AgentIndex>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<RVOAgent>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<MovementControl>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ResolvedMovement>();
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
				public void Run(ref JobCopyFromRVOSimulatorToEntities job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobCopyFromRVOSimulatorToEntities job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobCopyFromRVOSimulatorToEntities job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobCopyFromRVOSimulatorToEntities job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobCopyFromRVOSimulatorToEntities job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobCopyFromRVOSimulatorToEntities job, EntityManager entityManager)
				{
				}
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[ReadOnly]
			public NativeArray<AgentIndex> agentDataVersions;

			[ReadOnly]
			public RVOQuadtreeBurst quadtree;

			[ReadOnly]
			public SimulatorBurst.AgentOutputData agentOutputData;

			private const float MaximumCirclePackingDensity = 0.9069f;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in LocalTransform transform, in AgentCylinderShape shape, in AgentIndex agentIndex, in RVOAgent controller, in MovementControl control, ref ResolvedMovement resolved)
			{
				if (agentIndex.TryGetIndex(ref agentDataVersions, out var index))
				{
					float num = math.abs(transform.Scale);
					float num2 = shape.radius * num * 3f;
					float num3 = quadtree.QueryArea(transform.Position, num2) / (2.8491104f * num2 * num2);
					resolved.targetPoint = agentOutputData.targetPoint[index];
					resolved.speed = agentOutputData.speed[index];
					float num4 = 1f;
					resolved.turningRadiusMultiplier = math.max(1f, math.pow(num3 * 2f, 4f) * num4);
					resolved.targetRotation = control.targetRotation;
					resolved.targetRotationHint = control.targetRotationHint;
					resolved.targetRotationOffset = control.targetRotationOffset;
					resolved.rotationSpeed = control.rotationSpeed;
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_RVO_AgentIndex_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_RVO_RVOAgent_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementControl_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_ResolvedMovement_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentIndex>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RVOAgent>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr5, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr6, i));
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
							Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentIndex>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RVOAgent>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr5, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr6, nextRangeBegin));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentIndex>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RVOAgent>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr5, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr6, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentIndex>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RVOAgent>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr5, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr6, k));
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

		private struct TypeHandle
		{
			public JobCopyFromEntitiesToRVOSimulator.InternalCompilerQueryAndHandleData __Pathfinding_ECS_RVO_RVOSystem_JobCopyFromEntitiesToRVOSimulator_WithDefaultQuery_JobEntityTypeHandle;

			public JobCopyFromRVOSimulatorToEntities.InternalCompilerQueryAndHandleData __Pathfinding_ECS_RVO_RVOSystem_JobCopyFromRVOSimulatorToEntities_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Pathfinding_ECS_RVO_RVOSystem_JobCopyFromEntitiesToRVOSimulator_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pathfinding_ECS_RVO_RVOSystem_JobCopyFromRVOSimulatorToEntities_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		private GCHandle lastSimulator;

		private EntityQuery withAgentIndex;

		private EntityQuery shouldBeAddedToSimulation;

		private EntityQuery shouldBeRemovedFromSimulation;

		private ComponentLookup<AgentOffMeshLinkTraversal> agentOffMeshLinkTraversalLookup;

		private TypeHandle __TypeHandle;

		public void OnCreate(ref SystemState state)
		{
			withAgentIndex = state.GetEntityQuery(ComponentType.ReadWrite<AgentIndex>());
			shouldBeAddedToSimulation = state.GetEntityQuery(ComponentType.ReadOnly<RVOAgent>(), ComponentType.Exclude<AgentIndex>());
			shouldBeRemovedFromSimulation = state.GetEntityQuery(ComponentType.ReadOnly<AgentIndex>(), ComponentType.Exclude<RVOAgent>());
			lastSimulator = GCHandle.Alloc(null, GCHandleType.Weak);
			agentOffMeshLinkTraversalLookup = state.GetComponentLookup<AgentOffMeshLinkTraversal>(isReadOnly: true);
		}

		public void OnDestroy(ref SystemState state)
		{
			lastSimulator.Free();
		}

		public void OnUpdate(ref SystemState systemState)
		{
			SimulatorBurst simulatorBurst = RVOSimulator.active?.GetSimulator();
			if (simulatorBurst != lastSimulator.Target)
			{
				RemoveAllAgentsFromSimulation(ref systemState);
				lastSimulator.Target = simulatorBurst;
			}
			if (simulatorBurst != null)
			{
				AddAndRemoveAgentsFromSimulation(ref systemState, simulatorBurst);
				if (!AIMovementSystemGroup.TimeScaledRateManager.CheapSimulationOnly)
				{
					CopyFromEntitiesToRVOSimulator(ref systemState, simulatorBurst, systemState.WorldUnmanaged.Time.DeltaTime);
					simulatorBurst.Update(systemState.Dependency, systemState.WorldUnmanaged.Time.DeltaTime, AIMovementSystemGroup.TimeScaledRateManager.IsLastSubstep, systemState.WorldUpdateAllocator);
					CopyFromRVOSimulatorToEntities(ref systemState, simulatorBurst);
				}
			}
		}

		private void RemoveAllAgentsFromSimulation(ref SystemState systemState)
		{
			EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
			NativeArray<Entity> entities = withAgentIndex.ToEntityArray(systemState.WorldUpdateAllocator);
			entityCommandBuffer.RemoveComponent<AgentIndex>(entities);
			entityCommandBuffer.Playback(systemState.EntityManager);
			entityCommandBuffer.Dispose();
		}

		private void AddAndRemoveAgentsFromSimulation(ref SystemState systemState, SimulatorBurst simulator)
		{
			NativeArray<AgentIndex> nativeArray = shouldBeRemovedFromSimulation.ToComponentDataArray<AgentIndex>(systemState.WorldUpdateAllocator);
			NativeArray<Entity> nativeArray2 = shouldBeAddedToSimulation.ToEntityArray(systemState.WorldUpdateAllocator);
			if (nativeArray.Length > 0 || nativeArray2.Length > 0)
			{
				EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
				entityCommandBuffer.RemoveComponent<AgentIndex>(shouldBeRemovedFromSimulation, EntityQueryCaptureMode.AtPlayback);
				for (int i = 0; i < nativeArray.Length; i++)
				{
					simulator.RemoveAgent(nativeArray[i]);
				}
				for (int j = 0; j < nativeArray2.Length; j++)
				{
					entityCommandBuffer.AddComponent(nativeArray2[j], simulator.AddAgentBurst(Vector3.zero));
				}
				entityCommandBuffer.Playback(systemState.EntityManager);
				entityCommandBuffer.Dispose();
			}
		}

		private void CopyFromEntitiesToRVOSimulator(ref SystemState systemState, SimulatorBurst simulator, float dt)
		{
			agentOffMeshLinkTraversalLookup.Update(ref systemState);
			RWLock.WriteLockAsync writeLockAsync = simulator.LockSimulationDataReadWrite();
			systemState.Dependency = __ScheduleViaJobChunkExtension_0(new JobCopyFromEntitiesToRVOSimulator
			{
				agentData = simulator.simulationData,
				agentOutputData = simulator.outputData,
				movementPlaneMode = simulator.movementPlane,
				agentOffMeshLinkTraversalLookup = agentOffMeshLinkTraversalLookup,
				dt = dt
			}, __TypeHandle.__Pathfinding_ECS_RVO_RVOSystem_JobCopyFromEntitiesToRVOSimulator_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, JobHandle.CombineDependencies(writeLockAsync.dependency, systemState.Dependency), ref systemState, hasUserDefinedQuery: false);
			writeLockAsync.UnlockAfter(systemState.Dependency);
		}

		private void CopyFromRVOSimulatorToEntities(ref SystemState systemState, SimulatorBurst simulator)
		{
			RWLock.WriteLockAsync writeLockAsync = simulator.LockSimulationDataReadWrite();
			systemState.Dependency = __ScheduleViaJobChunkExtension_1(new JobCopyFromRVOSimulatorToEntities
			{
				quadtree = simulator.quadtree,
				agentDataVersions = simulator.simulationData.version,
				agentOutputData = simulator.outputData
			}, __TypeHandle.__Pathfinding_ECS_RVO_RVOSystem_JobCopyFromRVOSimulatorToEntities_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, JobHandle.CombineDependencies(writeLockAsync.dependency, systemState.Dependency), ref systemState, hasUserDefinedQuery: false);
			writeLockAsync.UnlockAfter(systemState.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(JobCopyFromEntitiesToRVOSimulator job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pathfinding_ECS_RVO_RVOSystem_JobCopyFromEntitiesToRVOSimulator_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pathfinding_ECS_RVO_RVOSystem_JobCopyFromEntitiesToRVOSimulator_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_RVO_RVOSystem_JobCopyFromEntitiesToRVOSimulator_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pathfinding_ECS_RVO_RVOSystem_JobCopyFromEntitiesToRVOSimulator_WithDefaultQuery_JobEntityTypeHandle.ScheduleParallel(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(JobCopyFromRVOSimulatorToEntities job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pathfinding_ECS_RVO_RVOSystem_JobCopyFromRVOSimulatorToEntities_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pathfinding_ECS_RVO_RVOSystem_JobCopyFromRVOSimulatorToEntities_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_RVO_RVOSystem_JobCopyFromRVOSimulatorToEntities_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pathfinding_ECS_RVO_RVOSystem_JobCopyFromRVOSimulatorToEntities_WithDefaultQuery_JobEntityTypeHandle.ScheduleParallel(ref job, query, dependency);
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
			((RVOSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((RVOSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			((RVOSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((RVOSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}
	}
}
