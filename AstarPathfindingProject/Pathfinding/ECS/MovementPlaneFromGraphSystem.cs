using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Pathfinding.Util;
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
	[UpdateBefore(typeof(RepairPathSystem))]
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[RequireMatchingQueriesForUpdate]
	[BurstCompile]
	public struct MovementPlaneFromGraphSystem : ISystem, ISystemCompilerGenerated
	{
		private struct JobMovementPlaneFromNavmeshNormal : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<ManagedState> __Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentCylinderShape> __Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle = state.EntityManager.GetComponentTypeHandle<ManagedState>(isReadOnly: false);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
						__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AgentMovementPlane>();
						__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AgentCylinderShape>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle.Update(ref state);
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
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ManagedState>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AgentMovementPlane>();
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
				public void Run(ref JobMovementPlaneFromNavmeshNormal job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					InternalCompilerInterface.JobChunkInterface.RunByRefWithoutJobs(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobMovementPlaneFromNavmeshNormal job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobMovementPlaneFromNavmeshNormal job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobMovementPlaneFromNavmeshNormal job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobMovementPlaneFromNavmeshNormal job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobMovementPlaneFromNavmeshNormal job, EntityManager entityManager)
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

			public float dt;

			public NativeList<Int3> vertices;

			public List<GraphNode> que;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public EntityManager __EntityManager;

			public void Execute(ManagedState managedState, in LocalTransform localTransform, ref AgentMovementPlane agentMovementPlane, in AgentCylinderShape shape)
			{
				if (managedState.pathTracer.startNode is TriangleMeshNode node)
				{
					float agentRadius = math.max(0.01f, shape.radius);
					SampleSmoothNavmeshNormal(node, que, vertices, localTransform.Position, agentRadius, ref agentMovementPlane, dt * 20f);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				ManagedComponentAccessor<ManagedState> managedComponentAccessor = chunk.GetManagedComponentAccessor(ref __TypeHandle.__Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle, __EntityManager);
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						ManagedState managedState = managedComponentAccessor[i];
						Execute(managedState, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr3, i));
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
							ManagedState managedState2 = managedComponentAccessor[nextRangeBegin];
							Execute(managedState2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr3, nextRangeBegin));
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
						ManagedState managedState3 = managedComponentAccessor[j];
						Execute(managedState3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr3, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						ManagedState managedState4 = managedComponentAccessor[k];
						Execute(managedState4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentCylinderShape>(nativeArrayPtr3, k));
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
		private struct JobMovementPlaneFromGraph : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<MovementState> __Pathfinding_ECS_MovementState_RO_ComponentTypeHandle;

					public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pathfinding_ECS_MovementState_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementState>(isReadOnly: true);
						__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AgentMovementPlane>();
					}

					public void Update(ref SystemState state)
					{
						__Pathfinding_ECS_MovementState_RO_ComponentTypeHandle.Update(ref state);
						__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MovementState>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AgentMovementPlane>();
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
				public void Run(ref JobMovementPlaneFromGraph job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobMovementPlaneFromGraph job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobMovementPlaneFromGraph job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobMovementPlaneFromGraph job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobMovementPlaneFromGraph job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobMovementPlaneFromGraph job, EntityManager entityManager)
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
			public NativeArray<AgentMovementPlane> movementPlanes;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in MovementState movementState, ref AgentMovementPlane movementPlane)
			{
				if (movementState.graphIndex < (uint)movementPlanes.Length)
				{
					movementPlane = movementPlanes[(int)movementState.graphIndex];
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_MovementState_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr2, i));
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
							Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr2, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementState>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AgentMovementPlane>(nativeArrayPtr2, k));
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
			public JobMovementPlaneFromNavmeshNormal.InternalCompilerQueryAndHandleData __Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromNavmeshNormal_WithoutDefaultQuery_JobEntityTypeHandle;

			public JobMovementPlaneFromGraph.InternalCompilerQueryAndHandleData __Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromGraph_WithoutDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromNavmeshNormal_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromGraph_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void SampleSmoothTriangleNormal_00000FAC_0024PostfixBurstDelegate(ref float3 position, ref UnsafeSpan<Int3> _triangleVertices, ref AgentMovementPlane agentMovementPlane, float agentRadius, float alpha);

		internal static class SampleSmoothTriangleNormal_00000FAC_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<SampleSmoothTriangleNormal_00000FAC_0024PostfixBurstDelegate>(SampleSmoothTriangleNormal).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref float3 position, ref UnsafeSpan<Int3> _triangleVertices, ref AgentMovementPlane agentMovementPlane, float agentRadius, float alpha)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref float3, ref UnsafeSpan<Int3>, ref AgentMovementPlane, float, float, void>)functionPointer)(ref position, ref _triangleVertices, ref agentMovementPlane, agentRadius, alpha);
						return;
					}
				}
				SampleSmoothTriangleNormal_0024BurstManaged(ref position, ref _triangleVertices, ref agentMovementPlane, agentRadius, alpha);
			}
		}

		public EntityQuery entityQueryGraph;

		public EntityQuery entityQueryNormal;

		private GCHandle graphNodeQueue;

		private TypeHandle __TypeHandle;

		public void OnCreate(ref SystemState state)
		{
			entityQueryGraph = state.GetEntityQuery(ComponentType.ReadOnly<MovementState>(), ComponentType.ReadWrite<AgentMovementPlane>(), ComponentType.ReadOnly<AgentMovementPlaneSource>());
			entityQueryGraph.SetSharedComponentFilter(new AgentMovementPlaneSource
			{
				value = MovementPlaneSource.Graph
			});
			entityQueryNormal = state.GetEntityQuery(ComponentType.ReadWrite<ManagedState>(), ComponentType.ReadOnly<LocalTransform>(), ComponentType.ReadWrite<AgentMovementPlane>(), ComponentType.ReadOnly<AgentCylinderShape>(), ComponentType.ReadOnly<AgentMovementPlaneSource>());
			entityQueryNormal.AddSharedComponentFilter(new AgentMovementPlaneSource
			{
				value = MovementPlaneSource.NavmeshNormal
			});
			graphNodeQueue = GCHandle.Alloc(new List<GraphNode>(32));
		}

		public void OnDestroy(ref SystemState state)
		{
			graphNodeQueue.Free();
		}

		public void OnUpdate(ref SystemState systemState)
		{
			NavGraph[] array = AstarPath.active?.data.graphs;
			if (array != null)
			{
				NativeArray<AgentMovementPlane> movementPlanes = CollectionHelper.CreateNativeArray<AgentMovementPlane>(array.Length, systemState.WorldUpdateAllocator, NativeArrayOptions.UninitializedMemory);
				for (int i = 0; i < array.Length; i++)
				{
					movementPlanes[i] = new AgentMovementPlane(MovementPlaneFromGraph(array[i]));
				}
				if (!entityQueryNormal.IsEmpty)
				{
					systemState.CompleteDependency();
					NativeList<Int3> vertices = new NativeList<Int3>(16, Allocator.Temp);
					__ScheduleViaJobChunkExtension_0(new JobMovementPlaneFromNavmeshNormal
					{
						dt = AIMovementSystemGroup.TimeScaledRateManager.CheapStepDeltaTime,
						vertices = vertices,
						que = (List<GraphNode>)graphNodeQueue.Target
					}, entityQueryNormal, systemState.Dependency, ref systemState, hasUserDefinedQuery: true);
				}
				systemState.Dependency = __ScheduleViaJobChunkExtension_1(new JobMovementPlaneFromGraph
				{
					movementPlanes = movementPlanes
				}, entityQueryGraph, systemState.Dependency, ref systemState, hasUserDefinedQuery: true);
			}
		}

		public static NativeMovementPlane MovementPlaneFromGraph(NavGraph graph)
		{
			if (graph is NavmeshBase navmeshBase)
			{
				return new NativeMovementPlane(navmeshBase.transform.rotation);
			}
			if (graph is GridGraph gridGraph)
			{
				return new NativeMovementPlane(gridGraph.transform.rotation);
			}
			return new NativeMovementPlane(quaternion.identity);
		}

		public static void SampleSmoothNavmeshNormal(TriangleMeshNode node, List<GraphNode> scratchList, NativeList<Int3> scratchBuffer, float3 position, float agentRadius, ref AgentMovementPlane agentMovementPlane, float alpha)
		{
			NativeList<Int3> list = scratchBuffer;
			List<GraphNode> data = scratchList;
			list.Clear();
			data.Clear();
			int num = 0;
			node.TemporaryFlag1 = true;
			data.Add(node);
			int v257 = node.v0;
			int v258 = node.v1;
			int v259 = node.v2;
			while (num < data.Count)
			{
				if (!(data[num++] is TriangleMeshNode triangleMeshNode) || !((triangleMeshNode.v0 == v257) | (triangleMeshNode.v1 == v257) | (triangleMeshNode.v2 == v257) | (triangleMeshNode.v0 == v258) | (triangleMeshNode.v1 == v258) | (triangleMeshNode.v2 == v258) | (triangleMeshNode.v0 == v259) | (triangleMeshNode.v1 == v259) | (triangleMeshNode.v2 == v259)))
				{
					continue;
				}
				triangleMeshNode.GetVertices(out var v260, out var v261, out var v262);
				list.Add(in v260);
				list.Add(in v261);
				list.Add(in v262);
				triangleMeshNode.GetConnections(delegate(GraphNode con, ref List<GraphNode> que)
				{
					if (!con.TemporaryFlag1)
					{
						con.TemporaryFlag1 = true;
						que.Add(con);
					}
				}, ref data);
			}
			for (int num2 = 0; num2 < data.Count; num2++)
			{
				data[num2].TemporaryFlag1 = false;
			}
			UnsafeSpan<Int3> _triangleVertices = list.AsUnsafeSpan();
			SampleSmoothTriangleNormal(ref position, ref _triangleVertices, ref agentMovementPlane, agentRadius, alpha);
		}

		private static float Square(float x)
		{
			return x * x;
		}

		private static float SinAngle(float3 a, float3 b, float3 c)
		{
			return math.sqrt(1f - Square(math.dot(math.normalizesafe(a - b), math.normalizesafe(c - b))));
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		[MonoPInvokeCallback(typeof(Pathfinding_002EECS_002ESampleSmoothTriangleNormal_00000FAC_0024PostfixBurstDelegate))]
		private static void SampleSmoothTriangleNormal(ref float3 position, ref UnsafeSpan<Int3> _triangleVertices, ref AgentMovementPlane agentMovementPlane, float agentRadius, float alpha)
		{
			SampleSmoothTriangleNormal_00000FAC_0024BurstDirectCall.Invoke(ref position, ref _triangleVertices, ref agentMovementPlane, agentRadius, alpha);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_0(JobMovementPlaneFromNavmeshNormal job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			__TypeHandle.__Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromNavmeshNormal_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
			__TypeHandle.__Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromNavmeshNormal_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromNavmeshNormal_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			__TypeHandle.__Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromNavmeshNormal_WithoutDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(JobMovementPlaneFromGraph job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromGraph_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromGraph_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromGraph_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromGraph_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
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
			((MovementPlaneFromGraphSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((MovementPlaneFromGraphSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			((MovementPlaneFromGraphSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((MovementPlaneFromGraphSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile(FloatMode = FloatMode.Fast)]
		internal unsafe static void SampleSmoothTriangleNormal_0024BurstManaged(ref float3 position, ref UnsafeSpan<Int3> _triangleVertices, ref AgentMovementPlane agentMovementPlane, float agentRadius, float alpha)
		{
			UnsafeSpan<int3> unsafeSpan = _triangleVertices.Reinterpret<int3>();
			if (unsafeSpan.Length < 3)
			{
				throw new ArgumentException("triangleVertices.Length < 3");
			}
			int3* ptr = unsafeSpan.ptr;
			float3* ptr2 = stackalloc float3[3];
			float* ptr3 = stackalloc float[3];
			*ptr2 = (ptr2[1] = (ptr2[2] = float3.zero));
			*ptr3 = (ptr3[1] = (ptr3[2] = 0f));
			float3 up = agentMovementPlane.value.up;
			for (uint num = 0u; num < unsafeSpan.length; num += 3)
			{
				int3 int5 = unsafeSpan[num];
				int3 int6 = unsafeSpan[num + 1];
				int3 int7 = unsafeSpan[num + 2];
				float3 a = (float3)int5 * 0.001f;
				float3 b = (float3)int6 * 0.001f;
				float3 c = (float3)int7 * 0.001f;
				float3 float5 = math.normalizesafe(math.cross(b - a, c - a));
				float num2 = 1f;
				float num3 = math.dot(float5, up);
				if (num3 < 0.86f)
				{
					Polygon.ClosestPointOnTriangleByRef(in a, in b, in c, in position, out var output);
					float num4 = math.lengthsq(output - position) / Square(1.5f * agentRadius);
					float end = math.max(0.1f, 1f - num4);
					float t = (0.86f - math.max(0f, num3)) / 0.86f;
					num2 = math.lerp(1f, end, t);
				}
				for (int i = 0; i < 3; i++)
				{
					if (math.all(int5 == ptr[i]))
					{
						float num5 = num2 * SinAngle(int7, int5, int6);
						ptr3[i] += num5;
						ptr2[i] += num5 * float5;
					}
				}
				for (int j = 0; j < 3; j++)
				{
					if (math.all(int6 == ptr[j]))
					{
						float num6 = num2 * SinAngle(int5, int6, int7);
						ptr3[j] += num6;
						ptr2[j] += num6 * float5;
					}
				}
				for (int k = 0; k < 3; k++)
				{
					if (math.all(int7 == ptr[k]))
					{
						float num7 = num2 * SinAngle(int6, int7, int5);
						ptr3[k] += num7;
						ptr2[k] += num7 * float5;
					}
				}
			}
			for (int l = 0; l < 3; l++)
			{
				if (ptr3[l] > 0f)
				{
					ptr2[l] /= ptr3[l];
				}
			}
			float3 a2 = (float3)(*ptr) * 0.001f;
			float3 b2 = (float3)ptr[1] * 0.001f;
			float3 c2 = (float3)ptr[2] * 0.001f;
			float3 float6 = Polygon.ClosestPointOnTriangleBarycentric(a2, b2, c2, position);
			float3 end2 = math.normalizesafe(*ptr2 * float6.x + ptr2[1] * float6.y + ptr2[2] * float6.z);
			float3 up2 = math.lerp(up, end2, math.clamp(alpha, 0f, 1f));
			agentMovementPlane.value = agentMovementPlane.value.MatchUpDirection(up2);
		}
	}
}
