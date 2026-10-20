using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Jobs;

namespace Pathfinding.ECS
{
	[BurstCompile]
	internal struct JobSyncEntitiesToTransforms : IJobParallelForTransform
	{
		[ReadOnly]
		public NativeArray<Entity> entities;

		[ReadOnly]
		public ComponentLookup<LocalTransform> entityPositions;

		[ReadOnly]
		public ComponentLookup<MovementState> movementState;

		[ReadOnly]
		public ComponentLookup<SyncPositionWithTransform> syncPositionWithTransform;

		[ReadOnly]
		public ComponentLookup<SyncRotationWithTransform> syncRotationWithTransform;

		[ReadOnly]
		public ComponentLookup<OrientationYAxisForward> orientationYAxisForward;

		public void Execute(int index, TransformAccess transform)
		{
			Entity entity = entities[index];
			if (!entityPositions.HasComponent(entity))
			{
				return;
			}
			float3 float5 = float3.zero;
			if (movementState.TryGetComponent(entity, out var componentData))
			{
				float5 = componentData.positionOffset;
			}
			RefRO<LocalTransform> refRO = entityPositions.GetRefRO(entity);
			if (syncPositionWithTransform.HasComponent(entity))
			{
				transform.position = refRO.ValueRO.Position + float5;
			}
			if (syncRotationWithTransform.HasComponent(entity))
			{
				if (orientationYAxisForward.HasComponent(entity))
				{
					transform.rotation = math.mul(refRO.ValueRO.Rotation, SyncTransformsToEntitiesSystem.ZAxisForwardToYAxisForward);
				}
				else
				{
					transform.rotation = refRO.ValueRO.Rotation;
				}
			}
		}
	}
}
