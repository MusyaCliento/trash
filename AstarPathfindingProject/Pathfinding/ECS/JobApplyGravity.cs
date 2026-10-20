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
	public struct JobApplyGravity : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MovementSettings> __Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle;

				public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle;

				public ComponentTypeHandle<GravityState> __Pathfinding_ECS_GravityState_RW_ComponentTypeHandle;

				[ReadOnly]
				public SharedComponentTypeHandle<AgentMovementPlaneSource> __Pathfinding_ECS_AgentMovementPlaneSource_SharedComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
					__Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSettings>(isReadOnly: true);
					__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AgentMovementPlane>();
					__Pathfinding_ECS_GravityState_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GravityState>();
					__Pathfinding_ECS_AgentMovementPlaneSource_SharedComponentTypeHandle = state.GetSharedComponentTypeHandle<AgentMovementPlaneSource>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_GravityState_RW_ComponentTypeHandle.Update(ref state);
					__Pathfinding_ECS_AgentMovementPlaneSource_SharedComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MovementSettings>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AgentMovementPlaneSource>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AgentMovementPlane>();
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
			public void Run(ref JobApplyGravity job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref JobApplyGravity job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref JobApplyGravity job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return InternalCompilerInterface.JobChunkInterface.ScheduleParallelByRef(ref job, query, dependency, job.__ChunkBaseEntityIndices);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref JobApplyGravity job, EntityQuery query, ref SystemState state)
			{
				NativeArray<int> _ChunkBaseEntityIndices = query.CalculateBaseEntityIndexArray(state.WorldUpdateAllocator);
				job.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref JobApplyGravity job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				JobHandle outJobHandle;
				NativeArray<int> _ChunkBaseEntityIndices = query.CalculateBaseEntityIndexArrayAsync(state.WorldUpdateAllocator, dependency, out outJobHandle);
				job.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
				return outJobHandle;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref JobApplyGravity job, EntityManager entityManager)
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
		public NativeArray<RaycastHit> raycastHits;

		[ReadOnly]
		public NativeArray<RaycastCommand> raycastCommands;

		public CommandBuilder draw;

		public float dt;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		private void ResolveGravity(RaycastHit hit, bool grounded, ref LocalTransform transform, in AgentMovementPlane movementPlane, ref GravityState gravityState)
		{
			float elevation;
			float2 p = movementPlane.value.ToPlane(transform.Position, out elevation);
			if (grounded)
			{
				gravityState.verticalVelocity *= math.max(0f, 1f - 5f * dt);
				movementPlane.value.ToPlane(hit.point, out var elevation2);
				float num = gravityState.verticalVelocity * dt;
				elevation = ((!(elevation2 > elevation)) ? math.max(elevation2, elevation + num) : Mathf.MoveTowards(elevation, elevation2, 6f * math.sqrt(math.abs(elevation2 - elevation)) * dt));
			}
			else
			{
				float num2 = gravityState.verticalVelocity * dt;
				elevation += num2;
			}
			transform.Position = movementPlane.value.ToWorld(p, elevation);
		}

		public void Execute(ref LocalTransform transform, in MovementSettings movementSettings, ref AgentMovementPlane movementPlane, ref GravityState gravityState, in AgentMovementPlaneSource movementPlaneSource, [EntityIndexInQuery] int entityIndexInQuery)
		{
			RaycastHit hit = raycastHits[entityIndexInQuery];
			bool flag = math.any((float3)hit.normal != 0f);
			if (flag && movementPlaneSource.value == MovementPlaneSource.Raycast)
			{
				movementPlane.value = movementPlane.value.MatchUpDirection(hit.normal);
			}
			ResolveGravity(hit, flag, ref transform, in movementPlane, ref gravityState);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_GravityState_RW_ComponentTypeHandle);
			AgentMovementPlaneSource movementPlaneSource = chunk.GetSharedComponent(__TypeHandle.__Pathfinding_ECS_AgentMovementPlaneSource_SharedComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					ref LocalTransform transform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i);
					ref MovementSettings movementSettings = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr2, i);
					ref AgentMovementPlane movementPlane = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, i);
					ref GravityState gravityState = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GravityState>(nativeArrayPtr4, i);
					int entityIndexInQuery = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
					Execute(ref transform, in movementSettings, ref movementPlane, ref gravityState, in movementPlaneSource, entityIndexInQuery);
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
						ref MovementSettings movementSettings2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr2, nextRangeBegin);
						ref AgentMovementPlane movementPlane2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, nextRangeBegin);
						ref GravityState gravityState2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GravityState>(nativeArrayPtr4, nextRangeBegin);
						int entityIndexInQuery2 = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
						Execute(ref transform2, in movementSettings2, ref movementPlane2, ref gravityState2, in movementPlaneSource, entityIndexInQuery2);
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
					ref MovementSettings movementSettings3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr2, j);
					ref AgentMovementPlane movementPlane3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, j);
					ref GravityState gravityState3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GravityState>(nativeArrayPtr4, j);
					int entityIndexInQuery3 = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
					Execute(ref transform3, in movementSettings3, ref movementPlane3, ref gravityState3, in movementPlaneSource, entityIndexInQuery3);
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
					ref MovementSettings movementSettings4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSettings>(nativeArrayPtr2, k);
					ref AgentMovementPlane movementPlane4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr3, k);
					ref GravityState gravityState4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GravityState>(nativeArrayPtr4, k);
					int entityIndexInQuery4 = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
					Execute(ref transform4, in movementSettings4, ref movementPlane4, ref gravityState4, in movementPlaneSource, entityIndexInQuery4);
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
