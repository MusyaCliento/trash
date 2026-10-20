using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pathfinding.Drawing;
using Unity.Burst;
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
	[BurstCompile]
	public struct JobPrepareAgentRaycasts : IJobEntity, IJobChunk
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

				public ComponentTypeHandle<ResolvedMovement> __Pathfinding_ECS_ResolvedMovement_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MovementStatistics> __Pathfinding_ECS_MovementStatistics_RW_ComponentTypeHandle;

				public ComponentTypeHandle<GravityState> __Pathfinding_ECS_GravityState_RW_ComponentTypeHandle;

				[ReadOnly]
				public SharedComponentTypeHandle<PhysicsSceneRef> __Pathfinding_ECS_PhysicsSceneRef_SharedComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
					__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentCylinderShape>(isReadOnly: true);
					__Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentMovementPlane>(isReadOnly: true);
					__Pathfinding_ECS_MovementState_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MovementState>();
					__Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSettings>(isReadOnly: true);
					__Pathfinding_ECS_ResolvedMovement_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ResolvedMovement>();
					__Pathfinding_ECS_MovementStatistics_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MovementStatistics>();
					__Pathfinding_ECS_GravityState_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GravityState>();
					__Pathfinding_ECS_PhysicsSceneRef_SharedComponentTypeHandle = state.GetSharedComponentTypeHandle<PhysicsSceneRef>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_MovementState_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_ResolvedMovement_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_MovementStatistics_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_GravityState_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_PhysicsSceneRef_SharedComponentTypeHandle.Update(ref state);
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
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhysicsSceneRef>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MovementState>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ResolvedMovement>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MovementStatistics>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GravityState>();
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
			public void Run(ref JobPrepareAgentRaycasts job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref JobPrepareAgentRaycasts job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref JobPrepareAgentRaycasts job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return InternalCompilerInterface.JobChunkInterface.ScheduleParallelByRef(ref job, query, dependency, job.__ChunkBaseEntityIndices);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref JobPrepareAgentRaycasts job, EntityQuery query, ref SystemState state)
			{
				NativeArray<int> _ChunkBaseEntityIndices = query.CalculateBaseEntityIndexArray(state.WorldUpdateAllocator);
				job.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref JobPrepareAgentRaycasts job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				JobHandle outJobHandle;
				NativeArray<int> _ChunkBaseEntityIndices = query.CalculateBaseEntityIndexArrayAsync(state.WorldUpdateAllocator, dependency, out outJobHandle);
				job.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
				return outJobHandle;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref JobPrepareAgentRaycasts job, EntityManager entityManager)
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

		public NativeArray<RaycastCommand> raycastCommands;

		public QueryParameters raycastQueryParameters;

		public CommandBuilder draw;

		public float dt;

		public float gravity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		private void ApplyGravity(ref GravityState gravityState)
		{
			gravityState.verticalVelocity += gravity * dt;
		}

		private RaycastCommand CalculateRaycastCommands(ref LocalTransform transform, in AgentCylinderShape shape, in AgentMovementPlane movementPlane, in MovementSettings movementSettings, ref GravityState gravityState, PhysicsScene physicsScene)
		{
			movementPlane.value.ToPlane(transform.Position, out var elevation);
			float num = gravityState.verticalVelocity * dt;
			float elevation2;
			float2 p = movementPlane.value.ToPlane(transform.Position, out elevation2);
			float num2 = math.max(elevation2 + num, elevation) + shape.height * 0.5f;
			float num3 = math.min(elevation2 + num, elevation);
			float distance = num2 - num3;
			float3 float5 = movementPlane.value.ToWorld(0, -1f);
			raycastQueryParameters.layerMask = movementSettings.groundMask;
			return new RaycastCommand(physicsScene, movementPlane.value.ToWorld(p, num2), float5, raycastQueryParameters, distance);
		}

		public void Execute(ref LocalTransform transform, in AgentCylinderShape shape, in AgentMovementPlane movementPlane, ref MovementState state, in MovementSettings movementSettings, ref ResolvedMovement resolvedMovement, ref MovementStatistics movementStatistics, ref GravityState gravityState, in PhysicsSceneRef physicsWorldIndex, [EntityIndexInQuery] int entityIndexInQuery)
		{
			ApplyGravity(ref gravityState);
			raycastCommands[entityIndexInQuery] = CalculateRaycastCommands(ref transform, in shape, in movementPlane, in movementSettings, ref gravityState, physicsWorldIndex.physicsScene);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementState_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_ResolvedMovement_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementStatistics_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_GravityState_RW_ComponentTypeHandle);
			PhysicsSceneRef physicsWorldIndex = chunk.GetSharedComponent(__TypeHandle.__Pathfinding_ECS_PhysicsSceneRef_SharedComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					ref LocalTransform transform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i);
					ref AgentCylinderShape shape = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr2, i);
					ref AgentMovementPlane movementPlane = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, i);
					ref MovementState state = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr4, i);
					ref MovementSettings movementSettings = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr5, i);
					ref ResolvedMovement resolvedMovement = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr6, i);
					ref MovementStatistics movementStatistics = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementStatistics>(nativeArrayPtr7, i);
					ref GravityState gravityState = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GravityState>(nativeArrayPtr8, i);
					int entityIndexInQuery = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
					Execute(ref transform, in shape, in movementPlane, ref state, in movementSettings, ref resolvedMovement, ref movementStatistics, ref gravityState, in physicsWorldIndex, entityIndexInQuery);
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
						ref LocalTransform transform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, nextRangeBegin);
						ref AgentCylinderShape shape2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr2, nextRangeBegin);
						ref AgentMovementPlane movementPlane2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, nextRangeBegin);
						ref MovementState state2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr4, nextRangeBegin);
						ref MovementSettings movementSettings2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr5, nextRangeBegin);
						ref ResolvedMovement resolvedMovement2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr6, nextRangeBegin);
						ref MovementStatistics movementStatistics2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementStatistics>(nativeArrayPtr7, nextRangeBegin);
						ref GravityState gravityState2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GravityState>(nativeArrayPtr8, nextRangeBegin);
						int entityIndexInQuery2 = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
						Execute(ref transform2, in shape2, in movementPlane2, ref state2, in movementSettings2, ref resolvedMovement2, ref movementStatistics2, ref gravityState2, in physicsWorldIndex, entityIndexInQuery2);
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
					ref LocalTransform transform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j);
					ref AgentCylinderShape shape3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr2, j);
					ref AgentMovementPlane movementPlane3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, j);
					ref MovementState state3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr4, j);
					ref MovementSettings movementSettings3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr5, j);
					ref ResolvedMovement resolvedMovement3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr6, j);
					ref MovementStatistics movementStatistics3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementStatistics>(nativeArrayPtr7, j);
					ref GravityState gravityState3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GravityState>(nativeArrayPtr8, j);
					int entityIndexInQuery3 = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
					Execute(ref transform3, in shape3, in movementPlane3, ref state3, in movementSettings3, ref resolvedMovement3, ref movementStatistics3, ref gravityState3, in physicsWorldIndex, entityIndexInQuery3);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					ref LocalTransform transform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k);
					ref AgentCylinderShape shape4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr2, k);
					ref AgentMovementPlane movementPlane4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, k);
					ref MovementState state4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr4, k);
					ref MovementSettings movementSettings4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr5, k);
					ref ResolvedMovement resolvedMovement4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ResolvedMovement>(nativeArrayPtr6, k);
					ref MovementStatistics movementStatistics4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementStatistics>(nativeArrayPtr7, k);
					ref GravityState gravityState4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GravityState>(nativeArrayPtr8, k);
					int entityIndexInQuery4 = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
					Execute(ref transform4, in shape4, in movementPlane4, ref state4, in movementSettings4, ref resolvedMovement4, ref movementStatistics4, ref gravityState4, in physicsWorldIndex, entityIndexInQuery4);
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
