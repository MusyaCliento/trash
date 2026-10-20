using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pathfinding.Drawing;
using Pathfinding.PID;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Transforms;
using UnityEngine;

namespace Pathfinding.ECS
{
	[BurstCompile]
	[WithNone(new Type[] { typeof(AgentOffMeshLinkTraversal) })]
	[WithAll(new Type[]
	{
		typeof(SimulateMovement),
		typeof(SimulateMovementControl)
	})]
	public struct JobControl : IJobEntity, IJobEntityChunkBeginEnd, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MovementState> __Pathfinding_ECS_MovementState_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DestinationPoint> __Pathfinding_ECS_DestinationPoint_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<AgentCylinderShape> __Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MovementSettings> __Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ResolvedMovement> __Pathfinding_ECS_ResolvedMovement_RO_ComponentTypeHandle;

				public ComponentTypeHandle<MovementControl> __Pathfinding_ECS_MovementControl_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
					__Pathfinding_ECS_MovementState_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MovementState>();
					__Pathfinding_ECS_DestinationPoint_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DestinationPoint>(isReadOnly: true);
					__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentCylinderShape>(isReadOnly: true);
					__Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentMovementPlane>(isReadOnly: true);
					__Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSettings>(isReadOnly: true);
					__Pathfinding_ECS_ResolvedMovement_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ResolvedMovement>(isReadOnly: true);
					__Pathfinding_ECS_MovementControl_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MovementControl>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_MovementState_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_DestinationPoint_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_ResolvedMovement_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_MovementControl_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DestinationPoint>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AgentCylinderShape>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AgentMovementPlane>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MovementSettings>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ResolvedMovement>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SimulateMovement>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SimulateMovementControl>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MovementState>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MovementControl>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<AgentOffMeshLinkTraversal>();
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
			public void Run(ref JobControl job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref JobControl job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref JobControl job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref JobControl job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref JobControl job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref JobControl job, EntityManager entityManager)
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

		public float dt;

		public CommandBuilder draw;

		[ReadOnly]
		[NativeDisableContainerSafetyRestriction]
		public NavmeshEdges.NavmeshBorderData navmeshEdgeData;

		[NativeDisableContainerSafetyRestriction]
		public NativeList<float2> edgesScratch;

		private static readonly ProfilerMarker MarkerConvertObstacles = new ProfilerMarker("ConvertObstacles");

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public static float3 ClampToNavmesh(float3 position, float3 closestOnNavmesh, in AgentCylinderShape shape, in AgentMovementPlane movementPlane)
		{
			float elevation;
			float2 p = movementPlane.value.ToPlane(closestOnNavmesh, out elevation);
			movementPlane.value.ToPlane(position, out var elevation2);
			elevation2 = math.max(elevation2, elevation - shape.height * 0.4f);
			position = movementPlane.value.ToWorld(p, elevation2);
			return position;
		}

		public bool OnChunkBegin(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			if (!edgesScratch.IsCreated)
			{
				edgesScratch = new NativeList<float2>(64, Allocator.Temp);
			}
			return true;
		}

		public void OnChunkEnd(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask, bool chunkWasExecuted)
		{
		}

		public void Execute(ref LocalTransform transform, ref MovementState state, in DestinationPoint destination, in AgentCylinderShape shape, in AgentMovementPlane movementPlane, in MovementSettings settings, in ResolvedMovement resolvedMovement, ref MovementControl controlOutput)
		{
			float3 float5 = ClampToNavmesh(transform.Position, state.closestOnNavmesh, in shape, in movementPlane);
			edgesScratch.Clear();
			float agentScale = math.abs(transform.Scale);
			PIDMovement settings2 = settings.follower;
			settings2.ScaleByAgentScale(agentScale);
			settings2.desiredWallDistance *= resolvedMovement.turningRadiusMultiplier;
			if (state.isOnValidNode)
			{
				Bounds localBounds = PIDMovement.InterestingEdgeBounds(ref settings2, float5, state.nextCorner, shape.height, movementPlane.value);
				navmeshEdgeData.GetEdgesInRange(state.hierarchicalNodeIndex, localBounds, edgesScratch, movementPlane.value);
			}
			float num = (state.traversingLastPart ? math.max(0f, settings.stopDistance - 0.005f) : 0f);
			float num2 = math.max(0f, state.remainingDistanceToEndOfPart - num);
			float num3 = movementPlane.value.ToPlane(transform.Rotation) - state.rotationOffset - state.rotationOffset2;
			transform.Position = float5;
			if (dt > 1E-06f)
			{
				if (!math.isfinite(num2))
				{
					controlOutput = new MovementControl
					{
						targetPoint = float5,
						speed = 0f,
						endOfPath = float5,
						maxSpeed = settings.follower.speed,
						overrideLocalAvoidance = false,
						hierarchicalNodeIndex = state.hierarchicalNodeIndex,
						targetRotation = resolvedMovement.targetRotation,
						targetRotationHint = resolvedMovement.targetRotation,
						rotationSpeed = settings.follower.maxRotationSpeed,
						targetRotationOffset = state.rotationOffset
					};
					return;
				}
				if (settings.isStopped)
				{
					controlOutput = new MovementControl
					{
						targetPoint = float5 + math.normalizesafe(resolvedMovement.targetPoint - float5) * 10f,
						speed = settings.follower.Accelerate(resolvedMovement.speed, settings.follower.slowdownTime, 0f - dt),
						endOfPath = state.endOfPath,
						maxSpeed = settings.follower.speed,
						overrideLocalAvoidance = false,
						hierarchicalNodeIndex = state.hierarchicalNodeIndex,
						targetRotation = resolvedMovement.targetRotation,
						targetRotationHint = resolvedMovement.targetRotation,
						rotationSpeed = settings.follower.maxRotationSpeed,
						targetRotationOffset = state.rotationOffset
					};
					return;
				}
				PIDMovement.ControlParams controlParams = new PIDMovement.ControlParams
				{
					edges = edgesScratch.AsArray(),
					nextCorner = state.nextCorner,
					agentRadius = shape.radius,
					facingDirectionAtEndOfPath = destination.facingDirection,
					endOfPath = state.endOfPath,
					remainingDistance = num2,
					closestOnNavmesh = state.closestOnNavmesh,
					debugFlags = PIDMovement.DebugFlags.Nothing,
					p = float5,
					rotation = num3,
					maxDesiredWallDistance = state.followerState.maxDesiredWallDistance,
					speed = controlOutput.speed,
					movementPlane = movementPlane.value
				};
				AnglePIDControlOutput2D anglePIDControlOutput2D = PIDMovement.Control(ref settings2, dt, ref controlParams, ref draw, out state.followerState.maxDesiredWallDistance);
				float3 x = movementPlane.value.ToWorld(anglePIDControlOutput2D.positionDelta);
				float speed = math.length(x) / dt;
				controlOutput = new MovementControl
				{
					targetPoint = float5 + math.normalizesafe(x) * num2,
					speed = speed,
					endOfPath = state.endOfPath,
					maxSpeed = settings2.speed * 1.1f,
					overrideLocalAvoidance = false,
					hierarchicalNodeIndex = state.hierarchicalNodeIndex,
					targetRotation = num3 + anglePIDControlOutput2D.rotationDelta,
					targetRotationHint = num3 + AstarMath.DeltaAngle(num3, anglePIDControlOutput2D.targetRotation),
					rotationSpeed = math.abs(anglePIDControlOutput2D.rotationDelta / dt),
					targetRotationOffset = state.rotationOffset
				};
			}
			else
			{
				controlOutput.hierarchicalNodeIndex = -1;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			bool flag = OnChunkBegin(in chunk, chunkIndexInQuery, useEnabledMask, in chunkEnabledMask);
			if (flag)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementState_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_DestinationPoint_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_ResolvedMovement_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementControl_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestinationPoint>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr6, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr7, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr8, i));
						num++;
					}
				}
				else if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
				{
					int nextRangeBegin = 0;
					int nextRangeEnd = 0;
					while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
					{
						while (nextRangeBegin < nextRangeEnd)
						{
							Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestinationPoint>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr6, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr7, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr8, nextRangeBegin));
							nextRangeBegin++;
							num++;
						}
					}
				}
				else
				{
					ulong num2 = chunkEnabledMask.ULong0;
					int num3 = math.min(64, count);
					for (int j = 0; j < num3; j++)
					{
						if ((num2 & 1) != 0L)
						{
							Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestinationPoint>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr6, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr7, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr8, j));
							num++;
						}
						num2 >>= 1;
					}
					num2 = chunkEnabledMask.ULong1;
					for (int k = 64; k < count; k++)
					{
						if ((num2 & 1) != 0L)
						{
							Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestinationPoint>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr6, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr7, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementControl>(nativeArrayPtr8, k));
							num++;
						}
						num2 >>= 1;
					}
				}
			}
			OnChunkEnd(in chunk, chunkIndexInQuery, useEnabledMask, in chunkEnabledMask, flag);
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

		bool IJobEntityChunkBeginEnd.OnChunkBegin(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			return OnChunkBegin(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		void IJobEntityChunkBeginEnd.OnChunkEnd(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask, bool chunkWasExecuted)
		{
			OnChunkEnd(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask, chunkWasExecuted);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}
}
