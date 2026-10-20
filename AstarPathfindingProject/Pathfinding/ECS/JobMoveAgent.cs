using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(SimulateMovement),
		typeof(SimulateMovementFinalize)
	})]
	[WithNone(new Type[] { typeof(AgentOffMeshLinkMovementDisabled) })]
	public struct JobMoveAgent : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<AgentCylinderShape> __Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle;

				public ComponentTypeHandle<MovementState> __Pathfinding_ECS_MovementState_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MovementSettings> __Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ResolvedMovement> __Pathfinding_ECS_ResolvedMovement_RO_ComponentTypeHandle;

				public ComponentTypeHandle<MovementStatistics> __Pathfinding_ECS_MovementStatistics_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
					__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentCylinderShape>(isReadOnly: true);
					__Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentMovementPlane>(isReadOnly: true);
					__Pathfinding_ECS_MovementState_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MovementState>();
					__Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSettings>(isReadOnly: true);
					__Pathfinding_ECS_ResolvedMovement_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ResolvedMovement>(isReadOnly: true);
					__Pathfinding_ECS_MovementStatistics_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MovementStatistics>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_MovementState_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_ResolvedMovement_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_MovementStatistics_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<AgentCylinderShape>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AgentMovementPlane>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MovementSettings>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ResolvedMovement>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SimulateMovement>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SimulateMovementFinalize>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MovementState>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MovementStatistics>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<AgentOffMeshLinkMovementDisabled>();
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
			public void Run(ref JobMoveAgent job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref JobMoveAgent job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref JobMoveAgent job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref JobMoveAgent job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref JobMoveAgent job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref JobMoveAgent job, EntityManager entityManager)
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

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private static void UpdateVelocityEstimate(ref LocalTransform transform, ref MovementStatistics movementStatistics, float dt)
		{
			if (dt > 1E-06f)
			{
				movementStatistics.estimatedVelocity = (transform.Position - movementStatistics.lastPosition) / dt;
			}
		}

		private static void ResolveRotation(ref LocalTransform transform, ref MovementState state, in ResolvedMovement resolvedMovement, in MovementSettings movementSettings, in AgentMovementPlane movementPlane, float dt)
		{
			float num = movementPlane.value.ToPlane(transform.Rotation);
			float num2 = num - state.rotationOffset - state.rotationOffset2;
			float num3 = math.clamp(AstarMath.DeltaAngle(num2, resolvedMovement.targetRotation), (0f - resolvedMovement.rotationSpeed) * dt, resolvedMovement.rotationSpeed * dt);
			float num4 = math.radians(movementSettings.follower.maxRotationSpeed) * 0.5f;
			float num5 = math.clamp(AstarMath.DeltaAngle(state.rotationOffset, resolvedMovement.targetRotationOffset), (0f - num4) * dt, num4 * dt);
			float num6 = num2 + state.rotationOffset;
			float num7 = num2 + num3;
			state.rotationOffset += num5;
			state.rotationOffset = AstarMath.DeltaAngle(0f, state.rotationOffset);
			float num8 = num7 + state.rotationOffset;
			if (movementSettings.rotationSmoothing > 0f)
			{
				state.rotationOffset2 += num6 - num8;
				state.rotationOffset2 = AstarMath.DeltaAngle(0f, state.rotationOffset2);
				float num9 = math.abs(AstarMath.DeltaAngle(num, resolvedMovement.targetRotationHint)) / movementSettings.rotationSmoothing * dt;
				float num10 = 0.1f / movementSettings.rotationSmoothing * dt;
				if (math.abs(state.rotationOffset2) > 0f)
				{
					state.rotationOffset2 *= math.max(0f, 1f - num9 - num10 / math.abs(state.rotationOffset2));
				}
			}
			else if (state.rotationOffset2 != 0f)
			{
				state.rotationOffset2 += math.clamp(0f - state.rotationOffset2, (0f - num4) * dt, num4 * dt);
			}
			transform.Rotation = movementPlane.value.ToWorldRotation(num7 + state.rotationOffset + state.rotationOffset2);
		}

		public static float3 MoveWithoutGravity(ref LocalTransform transform, in ResolvedMovement resolvedMovement, in AgentMovementPlane movementPlane, float dt)
		{
			float2 obj = movementPlane.value.ToPlane(resolvedMovement.targetPoint - transform.Position);
			float num = math.length(obj);
			float2 p = math.select(obj, obj * math.clamp(resolvedMovement.speed * dt / num, 0f, 1f), num > 0.0001f);
			return movementPlane.value.ToWorld(p);
		}

		public static void ResolvePositionSmoothing(float3 movementDelta, ref MovementState state, in MovementSettings movementSettings, float dt)
		{
			if (movementSettings.positionSmoothing > 0f)
			{
				state.positionOffset -= movementDelta;
				float num = 1f / movementSettings.positionSmoothing * dt;
				float num2 = 0.1f / movementSettings.positionSmoothing * dt;
				float num3 = math.length(state.positionOffset);
				if (num3 > 0f)
				{
					state.positionOffset *= math.max(0f, 1f - num - num2 / num3);
				}
			}
			else
			{
				state.positionOffset = float3.zero;
			}
		}

		public void Execute(ref LocalTransform transform, in AgentCylinderShape shape, in AgentMovementPlane movementPlane, ref MovementState state, in MovementSettings movementSettings, in ResolvedMovement resolvedMovement, ref MovementStatistics movementStatistics)
		{
			MoveAgent(ref transform, in shape, in movementPlane, ref state, in movementSettings, in resolvedMovement, ref movementStatistics, dt);
		}

		public static void MoveAgent(ref LocalTransform transform, in AgentCylinderShape shape, in AgentMovementPlane movementPlane, ref MovementState state, in MovementSettings movementSettings, in ResolvedMovement resolvedMovement, ref MovementStatistics movementStatistics, float dt)
		{
			float3 float5 = MoveWithoutGravity(ref transform, in resolvedMovement, in movementPlane, dt);
			transform.Position += float5;
			if (math.abs(transform.Position.z) < 1E-05f)
			{
				transform.Position.z = 0f;
			}
			ResolvePositionSmoothing(float5, ref state, in movementSettings, dt);
			ResolveRotation(ref transform, ref state, in resolvedMovement, in movementSettings, in movementPlane, dt);
			UpdateVelocityEstimate(ref transform, ref movementStatistics, dt);
			movementStatistics.lastPosition = transform.Position;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementState_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_ResolvedMovement_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementStatistics_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr6, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementStatistics>(nativeArrayPtr7, i));
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr6, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementStatistics>(nativeArrayPtr7, nextRangeBegin));
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
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr6, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementStatistics>(nativeArrayPtr7, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr6, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementStatistics>(nativeArrayPtr7, k));
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
