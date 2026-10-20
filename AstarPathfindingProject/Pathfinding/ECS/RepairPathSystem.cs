using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pathfinding.ECS.RVO;
using Pathfinding.RVO;
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
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[UpdateBefore(typeof(FollowerControlSystem))]
	[BurstCompile]
	public struct RepairPathSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAbsent(new Type[] { typeof(ManagedAgentOffMeshLinkTraversal) })]
		private struct JobShouldRecalculatePaths : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<AutoRepathPolicy> __Pathfinding_ECS_AutoRepathPolicy_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentCylinderShape> __Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<DestinationPoint> __Pathfinding_ECS_DestinationPoint_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pathfinding_ECS_AutoRepathPolicy_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AutoRepathPolicy>();
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
						__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentCylinderShape>(isReadOnly: true);
						__Pathfinding_ECS_DestinationPoint_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DestinationPoint>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Pathfinding_ECS_AutoRepathPolicy_RW_ComponentTypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_DestinationPoint_RO_ComponentTypeHandle.Update(ref state);
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
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<DestinationPoint>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AutoRepathPolicy>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAbsent<ManagedAgentOffMeshLinkTraversal>();
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
				public void Run(ref JobShouldRecalculatePaths job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobShouldRecalculatePaths job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobShouldRecalculatePaths job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobShouldRecalculatePaths job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobShouldRecalculatePaths job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobShouldRecalculatePaths job, EntityManager entityManager)
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

			public float time;

			public NativeBitArray shouldRecalculatePath;

			private int index;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(ref AutoRepathPolicy autoRepathPolicy, in LocalTransform transform, in AgentCylinderShape shape, in DestinationPoint destination)
			{
				if (index >= shouldRecalculatePath.Length)
				{
					shouldRecalculatePath.Resize(shouldRecalculatePath.Length * 2, NativeArrayOptions.ClearMemory);
				}
				shouldRecalculatePath.Set(index++, autoRepathPolicy.ShouldRecalculatePath(transform.Position, shape.radius, destination.destination, time));
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AutoRepathPolicy_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_DestinationPoint_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoRepathPolicy>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestinationPoint>(nativeArrayPtr4, i));
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
							Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoRepathPolicy>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestinationPoint>(nativeArrayPtr4, nextRangeBegin));
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoRepathPolicy>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestinationPoint>(nativeArrayPtr4, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoRepathPolicy>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestinationPoint>(nativeArrayPtr4, k));
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

		[WithAbsent(new Type[] { typeof(ManagedAgentOffMeshLinkTraversal) })]
		public struct JobRecalculatePaths : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<ManagedState> __Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle;

					public ComponentTypeHandle<AutoRepathPolicy> __Pathfinding_ECS_AutoRepathPolicy_RW_ComponentTypeHandle;

					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

					public ComponentTypeHandle<DestinationPoint> __Pathfinding_ECS_DestinationPoint_RW_ComponentTypeHandle;

					public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle = state.EntityManager.GetComponentTypeHandle<ManagedState>(isReadOnly: false);
						__Pathfinding_ECS_AutoRepathPolicy_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AutoRepathPolicy>();
						__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
						__Pathfinding_ECS_DestinationPoint_RW_ComponentTypeHandle = state.GetComponentTypeHandle<DestinationPoint>();
						__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AgentMovementPlane>();
					}

					public void Update(ref SystemState state)
					{
						__Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_AutoRepathPolicy_RW_ComponentTypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_DestinationPoint_RW_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ManagedState>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AutoRepathPolicy>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DestinationPoint>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AgentMovementPlane>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAbsent<ManagedAgentOffMeshLinkTraversal>();
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
				public void Run(ref JobRecalculatePaths job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					InternalCompilerInterface.JobChunkInterface.RunByRefWithoutJobs(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobRecalculatePaths job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobRecalculatePaths job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobRecalculatePaths job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobRecalculatePaths job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobRecalculatePaths job, EntityManager entityManager)
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

			public float time;

			public NativeBitArray shouldRecalculatePath;

			private int index;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public EntityManager __EntityManager;

			public void Execute(ManagedState state, ref AutoRepathPolicy autoRepathPolicy, ref LocalTransform transform, ref DestinationPoint destination, ref AgentMovementPlane movementPlane)
			{
				MaybeRecalculatePath(state, ref autoRepathPolicy, ref transform, ref destination, ref movementPlane, time, shouldRecalculatePath.IsSet(index++));
			}

			public static void MaybeRecalculatePath(ManagedState state, ref AutoRepathPolicy autoRepathPolicy, ref LocalTransform transform, ref DestinationPoint destination, ref AgentMovementPlane movementPlane, float time, bool wantsToRecalculatePath)
			{
				if ((state.pathTracer.isStale || wantsToRecalculatePath) && state.pendingPath == null && autoRepathPolicy.mode != Pathfinding.AutoRepathPolicy.Mode.Never && float.IsFinite(destination.destination.x))
				{
					ABPath aBPath = ABPath.Construct(transform.Position, destination.destination);
					aBPath.UseSettings(state.pathfindingSettings);
					aBPath.nnConstraint.distanceMetric = DistanceMetric.ClosestAsSeenFromAboveSoft(movementPlane.value.up);
					ManagedState.SetPath(aBPath, state, in movementPlane, ref destination);
					autoRepathPolicy.DidRecalculatePath(destination.destination, time);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				ManagedComponentAccessor<ManagedState> managedComponentAccessor = chunk.GetManagedComponentAccessor(ref __TypeHandle.__Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle, __EntityManager);
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AutoRepathPolicy_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_DestinationPoint_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						ManagedState state = managedComponentAccessor[i];
						Execute(state, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoRepathPolicy>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestinationPoint>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr4, i));
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
							ManagedState state2 = managedComponentAccessor[nextRangeBegin];
							Execute(state2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoRepathPolicy>(nativeArrayPtr, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestinationPoint>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr4, nextRangeBegin));
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
						ManagedState state3 = managedComponentAccessor[j];
						Execute(state3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoRepathPolicy>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestinationPoint>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr4, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						ManagedState state4 = managedComponentAccessor[k];
						Execute(state4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoRepathPolicy>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestinationPoint>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr4, k));
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

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_943785564_0
		{
			public struct ResolvedChunk
			{
				public ManagedComponentAccessor<ManagedState> item1_ManagedComponentAccessor;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<ManagedState> Get(int index)
				{
					return new QueryEnumerableWithEntity<ManagedState>(item1_ManagedComponentAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				public EntityManager _entityManager;

				[ReadOnly]
				private ComponentTypeHandle<ManagedState> item1_ManagedComponentTypeHandle_RO;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					_entityManager = systemState.EntityManager;
					item1_ManagedComponentTypeHandle_RO = systemState.EntityManager.GetComponentTypeHandle<ManagedState>(isReadOnly: false);
					Entity_TypeHandle = systemState.GetEntityTypeHandle();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ManagedComponentTypeHandle_RO.Update(ref systemState);
					Entity_TypeHandle.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_ManagedComponentAccessor = archetypeChunk.GetManagedComponentAccessor(ref item1_ManagedComponentTypeHandle_RO, _entityManager),
						Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
					};
				}
			}

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<ManagedState>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<ManagedState> Current => _resolvedChunk.Get(_currentEntityIndex);

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

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_943785564_1
		{
			public struct ResolvedChunk
			{
				public ManagedComponentAccessor<ManagedState> item1_ManagedComponentAccessor;

				public IntPtr item2_IntPtr;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<ManagedState, InternalCompilerInterface.UncheckedRefRW<RVOAgent>> Get(int index)
				{
					return new QueryEnumerableWithEntity<ManagedState, InternalCompilerInterface.UncheckedRefRW<RVOAgent>>(item1_ManagedComponentAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<RVOAgent>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				public EntityManager _entityManager;

				[ReadOnly]
				private ComponentTypeHandle<ManagedState> item1_ManagedComponentTypeHandle_RO;

				private ComponentTypeHandle<RVOAgent> item2_ComponentTypeHandle_RW;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					_entityManager = systemState.EntityManager;
					item1_ManagedComponentTypeHandle_RO = systemState.EntityManager.GetComponentTypeHandle<ManagedState>(isReadOnly: false);
					item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<RVOAgent>();
					Entity_TypeHandle = systemState.GetEntityTypeHandle();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ManagedComponentTypeHandle_RO.Update(ref systemState);
					item2_ComponentTypeHandle_RW.Update(ref systemState);
					Entity_TypeHandle.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_ManagedComponentAccessor = archetypeChunk.GetManagedComponentAccessor(ref item1_ManagedComponentTypeHandle_RO, _entityManager),
						item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RW),
						Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
					};
				}
			}

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<ManagedState, InternalCompilerInterface.UncheckedRefRW<RVOAgent>>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<ManagedState, InternalCompilerInterface.UncheckedRefRW<RVOAgent>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRW<RVOAgent>();
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_943785564_2
		{
			public struct ResolvedChunk
			{
				public ManagedComponentAccessor<ManagedState> item1_ManagedComponentAccessor;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<ManagedState> Get(int index)
				{
					return new QueryEnumerableWithEntity<ManagedState>(item1_ManagedComponentAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				public EntityManager _entityManager;

				[ReadOnly]
				private ComponentTypeHandle<ManagedState> item1_ManagedComponentTypeHandle_RO;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					_entityManager = systemState.EntityManager;
					item1_ManagedComponentTypeHandle_RO = systemState.EntityManager.GetComponentTypeHandle<ManagedState>(isReadOnly: false);
					Entity_TypeHandle = systemState.GetEntityTypeHandle();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ManagedComponentTypeHandle_RO.Update(ref systemState);
					Entity_TypeHandle.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_ManagedComponentAccessor = archetypeChunk.GetManagedComponentAccessor(ref item1_ManagedComponentTypeHandle_RO, _entityManager),
						Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
					};
				}
			}

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<ManagedState>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<ManagedState> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			public IFE_943785564_0.TypeHandle __IFE_943785564_0_TypeHandle;

			public IFE_943785564_1.TypeHandle __IFE_943785564_1_TypeHandle;

			public IFE_943785564_2.TypeHandle __IFE_943785564_2_TypeHandle;

			public JobShouldRecalculatePaths.InternalCompilerQueryAndHandleData __Pathfinding_ECS_RepairPathSystem_JobShouldRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle;

			public JobRecalculatePaths.InternalCompilerQueryAndHandleData __Pathfinding_ECS_RepairPathSystem_JobRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle;

			public JobManagedOffMeshLinkTransition.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobManagedOffMeshLinkTransition_WithDefaultQuery_JobEntityTypeHandle;

			public JobManagedOffMeshLinkTransitionCleanup.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobManagedOffMeshLinkTransitionCleanup_WithoutDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_943785564_0_TypeHandle = new IFE_943785564_0.TypeHandle(ref state);
				__IFE_943785564_1_TypeHandle = new IFE_943785564_1.TypeHandle(ref state);
				__IFE_943785564_2_TypeHandle = new IFE_943785564_2.TypeHandle(ref state);
				__Pathfinding_ECS_RepairPathSystem_JobShouldRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pathfinding_ECS_RepairPathSystem_JobRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pathfinding_ECS_JobManagedOffMeshLinkTransition_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pathfinding_ECS_JobManagedOffMeshLinkTransitionCleanup_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			}
		}

		private EntityQuery entityQueryPrepare;

		private EntityQuery entityQueryOffMeshLink;

		private EntityQuery entityQueryOffMeshLinkCleanup;

		public JobRepairPath.Scheduler jobRepairPathScheduler;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_943785564_0;

		private EntityQuery __query_943785564_1;

		private EntityQuery __query_943785564_2;

		public void OnCreate(ref SystemState state)
		{
			jobRepairPathScheduler = new JobRepairPath.Scheduler(ref state);
			EntityQueryBuilder entityQueryBuilder = jobRepairPathScheduler.GetEntityQuery(Allocator.Temp);
			entityQueryBuilder = entityQueryBuilder.WithAll<SimulateMovement, SimulateMovementRepair>();
			entityQueryPrepare = entityQueryBuilder.Build(ref state);
			entityQueryOffMeshLink = state.GetEntityQuery(new EntityQueryDesc
			{
				All = new ComponentType[13]
				{
					ComponentType.ReadWrite<LocalTransform>(),
					ComponentType.ReadOnly<AgentCylinderShape>(),
					ComponentType.ReadWrite<AgentMovementPlane>(),
					ComponentType.ReadOnly<DestinationPoint>(),
					ComponentType.ReadWrite<MovementState>(),
					ComponentType.ReadOnly<MovementStatistics>(),
					ComponentType.ReadWrite<ManagedState>(),
					ComponentType.ReadWrite<MovementSettings>(),
					ComponentType.ReadOnly<ResolvedMovement>(),
					ComponentType.ReadWrite<MovementControl>(),
					ComponentType.ReadWrite<AgentOffMeshLinkTraversal>(),
					ComponentType.ReadWrite<ManagedAgentOffMeshLinkTraversal>(),
					ComponentType.ReadOnly<SimulateMovement>()
				},
				Present = new ComponentType[1] { ComponentType.ReadWrite<AgentOffMeshLinkMovementDisabled>() }
			});
			entityQueryOffMeshLinkCleanup = state.GetEntityQuery(ComponentType.ReadWrite<ManagedAgentOffMeshLinkTraversal>(), ComponentType.Exclude<AgentOffMeshLinkTraversal>());
		}

		public void OnDestroy(ref SystemState state)
		{
			jobRepairPathScheduler.Dispose();
		}

		public void OnUpdate(ref SystemState systemState)
		{
			if (!(AstarPath.active == null))
			{
				EntityCommandBuffer commandBuffer = new EntityCommandBuffer(systemState.WorldUpdateAllocator);
				SyncLocalAvoidanceComponents(ref systemState, commandBuffer);
				SchedulePaths(ref systemState);
				StartOffMeshLinkTraversal(ref systemState, commandBuffer);
				commandBuffer.Playback(systemState.EntityManager);
				commandBuffer.Dispose();
				ProcessActiveOffMeshLinkTraversal(ref systemState);
				RepairPaths(ref systemState);
			}
		}

		private void SyncLocalAvoidanceComponents(ref SystemState systemState, EntityCommandBuffer commandBuffer)
		{
			if (RVOSimulator.active?.GetSimulator() == null)
			{
				return;
			}
			ManagedState item;
			Entity entity;
			foreach (QueryEnumerableWithEntity<ManagedState> item3 in IFE_943785564_0.Query(__query_943785564_0, __TypeHandle.__IFE_943785564_0_TypeHandle, ref systemState))
			{
				item3.Deconstruct(out item, out entity);
				ManagedState managedState = item;
				Entity e = entity;
				if (managedState.enableLocalAvoidance)
				{
					commandBuffer.AddComponent(e, managedState.rvoSettings);
				}
			}
			foreach (QueryEnumerableWithEntity<ManagedState, InternalCompilerInterface.UncheckedRefRW<RVOAgent>> item4 in IFE_943785564_1.Query(__query_943785564_1, __TypeHandle.__IFE_943785564_1_TypeHandle, ref systemState))
			{
				item4.Deconstruct(out item, out var item2, out entity);
				ManagedState managedState2 = item;
				InternalCompilerInterface.UncheckedRefRW<RVOAgent> uncheckedRefRW = item2;
				Entity e2 = entity;
				uncheckedRefRW.ValueRW = managedState2.rvoSettings;
				if (!managedState2.enableLocalAvoidance)
				{
					commandBuffer.RemoveComponent<RVOAgent>(e2);
				}
			}
		}

		private void RepairPaths(ref SystemState systemState)
		{
			systemState.Dependency = jobRepairPathScheduler.ScheduleParallel(ref systemState, entityQueryPrepare, systemState.Dependency);
		}

		private void SchedulePaths(ref SystemState systemState)
		{
			NativeBitArray shouldRecalculatePath = new NativeBitArray(512, Allocator.TempJob);
			systemState.CompleteDependency();
			PathProcessor.GraphUpdateLock graphUpdateLock = AstarPath.active.PausePathfindingSoon();
			__ScheduleViaJobChunkExtension_0(new JobShouldRecalculatePaths
			{
				time = (float)systemState.WorldUnmanaged.Time.ElapsedTime,
				shouldRecalculatePath = shouldRecalculatePath
			}, __TypeHandle.__Pathfinding_ECS_RepairPathSystem_JobShouldRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, systemState.Dependency, ref systemState, hasUserDefinedQuery: false);
			__ScheduleViaJobChunkExtension_1(new JobRecalculatePaths
			{
				time = (float)systemState.WorldUnmanaged.Time.ElapsedTime,
				shouldRecalculatePath = shouldRecalculatePath
			}, __TypeHandle.__Pathfinding_ECS_RepairPathSystem_JobRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, systemState.Dependency, ref systemState, hasUserDefinedQuery: false);
			graphUpdateLock.Release();
			shouldRecalculatePath.Dispose();
		}

		private void StartOffMeshLinkTraversal(ref SystemState systemState, EntityCommandBuffer commandBuffer)
		{
			foreach (QueryEnumerableWithEntity<ManagedState> item2 in IFE_943785564_2.Query(__query_943785564_2, __TypeHandle.__IFE_943785564_2_TypeHandle, ref systemState))
			{
				item2.Deconstruct(out var item, out var entity);
				ManagedState state = item;
				Entity e = entity;
				OffMeshLinks.OffMeshLinkTracer linkInfo = NextLinkToTraverse(state);
				AgentOffMeshLinkTraversalContext agentOffMeshLinkTraversalContext = new AgentOffMeshLinkTraversalContext(linkInfo.link);
				commandBuffer.AddComponent(e, new AgentOffMeshLinkTraversal(linkInfo));
				EntityCommandBufferManagedComponentExtensions.AddComponent(commandBuffer, e, new ManagedAgentOffMeshLinkTraversal(agentOffMeshLinkTraversalContext, ResolveOffMeshLinkHandler(state, agentOffMeshLinkTraversalContext)));
				commandBuffer.AddComponent(e, default(AgentOffMeshLinkMovementDisabled));
			}
		}

		public static OffMeshLinks.OffMeshLinkTracer NextLinkToTraverse(ManagedState state)
		{
			return state.pathTracer.GetLinkInfo(1);
		}

		public static IOffMeshLinkHandler ResolveOffMeshLinkHandler(ManagedState state, AgentOffMeshLinkTraversalContext ctx)
		{
			return state.onTraverseOffMeshLink ?? ctx.concreteLink.handler;
		}

		private void ProcessActiveOffMeshLinkTraversal(ref SystemState systemState)
		{
			EntityCommandBuffer commandBuffer = new EntityCommandBuffer(systemState.WorldUpdateAllocator);
			systemState.CompleteDependency();
			__ScheduleViaJobChunkExtension_2(new JobManagedOffMeshLinkTransition
			{
				commandBuffer = commandBuffer,
				deltaTime = AIMovementSystemGroup.TimeScaledRateManager.CheapStepDeltaTime
			}, __TypeHandle.__Pathfinding_ECS_JobManagedOffMeshLinkTransition_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, systemState.Dependency, ref systemState, hasUserDefinedQuery: false);
			__ScheduleViaJobChunkExtension_3(default(JobManagedOffMeshLinkTransitionCleanup), entityQueryOffMeshLinkCleanup, systemState.Dependency, ref systemState, hasUserDefinedQuery: true);
			commandBuffer.RemoveComponent<ManagedAgentOffMeshLinkTraversal>(entityQueryOffMeshLinkCleanup, EntityQueryCaptureMode.AtPlayback);
			commandBuffer.RemoveComponent<AgentOffMeshLinkMovementDisabled>(entityQueryOffMeshLinkCleanup, EntityQueryCaptureMode.AtPlayback);
			commandBuffer.Playback(systemState.EntityManager);
			commandBuffer.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_0(JobShouldRecalculatePaths job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			__TypeHandle.__Pathfinding_ECS_RepairPathSystem_JobShouldRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
			__TypeHandle.__Pathfinding_ECS_RepairPathSystem_JobShouldRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_RepairPathSystem_JobShouldRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			__TypeHandle.__Pathfinding_ECS_RepairPathSystem_JobShouldRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_1(JobRecalculatePaths job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			__TypeHandle.__Pathfinding_ECS_RepairPathSystem_JobRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
			__TypeHandle.__Pathfinding_ECS_RepairPathSystem_JobRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_RepairPathSystem_JobRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			__TypeHandle.__Pathfinding_ECS_RepairPathSystem_JobRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_2(JobManagedOffMeshLinkTransition job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			__TypeHandle.__Pathfinding_ECS_JobManagedOffMeshLinkTransition_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
			__TypeHandle.__Pathfinding_ECS_JobManagedOffMeshLinkTransition_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_JobManagedOffMeshLinkTransition_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			__TypeHandle.__Pathfinding_ECS_JobManagedOffMeshLinkTransition_WithDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_3(JobManagedOffMeshLinkTransitionCleanup job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			__TypeHandle.__Pathfinding_ECS_JobManagedOffMeshLinkTransitionCleanup_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
			__TypeHandle.__Pathfinding_ECS_JobManagedOffMeshLinkTransitionCleanup_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_JobManagedOffMeshLinkTransitionCleanup_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			__TypeHandle.__Pathfinding_ECS_JobManagedOffMeshLinkTransitionCleanup_WithoutDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ManagedState>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<RVOAgent>();
			__query_943785564_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ManagedState>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RVOAgent>();
			__query_943785564_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ReadyToTraverseOffMeshLink>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ManagedState>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<AgentOffMeshLinkTraversal>();
			__query_943785564_2 = entityQueryBuilder2.Build(ref state);
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
			((RepairPathSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((RepairPathSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			((RepairPathSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((RepairPathSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}
	}
}
