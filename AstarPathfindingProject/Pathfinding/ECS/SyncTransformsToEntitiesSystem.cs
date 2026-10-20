using System;
using System.Runtime.CompilerServices;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Jobs;

namespace Pathfinding.ECS
{
	[UpdateBefore(typeof(TransformSystemGroup))]
	[UpdateBefore(typeof(AIMovementSystemGroup))]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public struct SyncTransformsToEntitiesSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		private struct SyncTransformsToEntitiesJob : IJobParallelForTransform
		{
			[ReadOnly]
			[DeallocateOnJobCompletion]
			public NativeArray<Entity> entities;

			[NativeDisableParallelForRestriction]
			public ComponentLookup<LocalTransform> entityPositions;

			[ReadOnly]
			public ComponentLookup<SyncPositionWithTransform> syncPositionWithTransform;

			[ReadOnly]
			public ComponentLookup<SyncRotationWithTransform> syncRotationWithTransform;

			[ReadOnly]
			public ComponentLookup<OrientationYAxisForward> orientationYAxisForward;

			[ReadOnly]
			public ComponentLookup<MovementState> movementState;

			public void Execute(int index, TransformAccess transform)
			{
				Entity entity = entities[index];
				if (!entityPositions.HasComponent(entity))
				{
					return;
				}
				ref LocalTransform valueRW = ref entityPositions.GetRefRW(entity).ValueRW;
				float3 float5 = float3.zero;
				if (movementState.TryGetComponent(entity, out var componentData))
				{
					float5 = componentData.positionOffset;
				}
				if (syncPositionWithTransform.HasComponent(entity))
				{
					valueRW.Position = (float3)transform.position - float5;
				}
				if (syncRotationWithTransform.HasComponent(entity))
				{
					if (orientationYAxisForward.HasComponent(entity))
					{
						valueRW.Rotation = math.mul(transform.rotation, YAxisForwardToZAxisForward);
					}
					else
					{
						valueRW.Rotation = transform.rotation;
					}
				}
				valueRW.Scale = transform.localScale.y;
			}
		}

		private struct TypeHandle
		{
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SyncPositionWithTransform> __Pathfinding_ECS_SyncPositionWithTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SyncRotationWithTransform> __Pathfinding_ECS_SyncRotationWithTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<OrientationYAxisForward> __Pathfinding_ECS_OrientationYAxisForward_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MovementState> __Pathfinding_ECS_MovementState_RO_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
				__Pathfinding_ECS_SyncPositionWithTransform_RO_ComponentLookup = state.GetComponentLookup<SyncPositionWithTransform>(isReadOnly: true);
				__Pathfinding_ECS_SyncRotationWithTransform_RO_ComponentLookup = state.GetComponentLookup<SyncRotationWithTransform>(isReadOnly: true);
				__Pathfinding_ECS_OrientationYAxisForward_RO_ComponentLookup = state.GetComponentLookup<OrientationYAxisForward>(isReadOnly: true);
				__Pathfinding_ECS_MovementState_RO_ComponentLookup = state.GetComponentLookup<MovementState>(isReadOnly: true);
			}
		}

		public static readonly quaternion ZAxisForwardToYAxisForward = quaternion.Euler(MathF.PI / 2f, 0f, 0f);

		public static readonly quaternion YAxisForwardToZAxisForward = quaternion.Euler(-MathF.PI / 2f, 0f, 0f);

		private TypeHandle __TypeHandle;

		public void OnUpdate(ref SystemState systemState)
		{
			TransformAccessArray transforms;
			FollowerEntity[] components2;
			int components = BatchedEvents.GetComponents<FollowerEntity>(BatchedEvents.Event.None, out transforms, out components2);
			if (components > 0)
			{
				NativeArray<Entity> entities = new NativeArray<Entity>(components, Allocator.TempJob);
				for (int i = 0; i < components; i++)
				{
					entities[i] = components2[i].entity;
				}
				systemState.Dependency = new SyncTransformsToEntitiesJob
				{
					entities = entities,
					entityPositions = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref systemState),
					syncPositionWithTransform = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pathfinding_ECS_SyncPositionWithTransform_RO_ComponentLookup, ref systemState),
					syncRotationWithTransform = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pathfinding_ECS_SyncRotationWithTransform_RO_ComponentLookup, ref systemState),
					orientationYAxisForward = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pathfinding_ECS_OrientationYAxisForward_RO_ComponentLookup, ref systemState),
					movementState = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pathfinding_ECS_MovementState_RO_ComponentLookup, ref systemState)
				}.Schedule(transforms, systemState.Dependency);
			}
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
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((SyncTransformsToEntitiesSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((SyncTransformsToEntitiesSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}
	}
}
