using System;
using System.Runtime.InteropServices;
using Pathfinding.Collections;
using Pathfinding.Drawing;
using Pathfinding.PID;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	public struct JobDrawFollowerGizmos : IJobChunk
	{
		public CommandBuilder draw;

		public GCHandle entityManagerHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> LocalTransformTypeHandleRO;

		[ReadOnly]
		public ComponentTypeHandle<AgentCylinderShape> AgentCylinderShapeHandleRO;

		[ReadOnly]
		public ComponentTypeHandle<MovementSettings> MovementSettingsHandleRO;

		[ReadOnly]
		public ComponentTypeHandle<AgentMovementPlane> AgentMovementPlaneHandleRO;

		[NativeDisableContainerSafetyRestriction]
		public ComponentTypeHandle<ManagedState> ManagedStateHandleRW;

		[ReadOnly]
		public ComponentTypeHandle<MovementState> MovementStateHandleRO;

		[ReadOnly]
		public ComponentTypeHandle<ResolvedMovement> ResolvedMovementHandleRO;

		[NativeDisableContainerSafetyRestriction]
		public NativeList<float3> scratchBuffer1;

		[NativeDisableContainerSafetyRestriction]
		public NativeArray<int> scratchBuffer2;

		public unsafe void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			if (!scratchBuffer1.IsCreated)
			{
				scratchBuffer1 = new NativeList<float3>(32, Allocator.Temp);
			}
			if (!scratchBuffer2.IsCreated)
			{
				scratchBuffer2 = new NativeArray<int>(32, Allocator.Temp);
			}
			LocalTransform* unsafeReadOnlyPtr = (LocalTransform*)chunk.GetNativeArray(ref LocalTransformTypeHandleRO).GetUnsafeReadOnlyPtr();
			AgentCylinderShape* unsafeReadOnlyPtr2 = (AgentCylinderShape*)chunk.GetNativeArray(ref AgentCylinderShapeHandleRO).GetUnsafeReadOnlyPtr();
			MovementSettings* unsafeReadOnlyPtr3 = (MovementSettings*)chunk.GetNativeArray(ref MovementSettingsHandleRO).GetUnsafeReadOnlyPtr();
			AgentMovementPlane* unsafeReadOnlyPtr4 = (AgentMovementPlane*)chunk.GetNativeArray(ref AgentMovementPlaneHandleRO).GetUnsafeReadOnlyPtr();
			ManagedComponentAccessor<ManagedState> managedComponentAccessor = chunk.GetManagedComponentAccessor(ref ManagedStateHandleRW, (EntityManager)entityManagerHandle.Target);
			MovementState* unsafeReadOnlyPtr5 = (MovementState*)chunk.GetNativeArray(ref MovementStateHandleRO).GetUnsafeReadOnlyPtr();
			ResolvedMovement* unsafeReadOnlyPtr6 = (ResolvedMovement*)chunk.GetNativeArray(ref ResolvedMovementHandleRO).GetUnsafeReadOnlyPtr();
			for (int i = 0; i < chunk.Count; i++)
			{
				Execute(ref unsafeReadOnlyPtr[i], ref unsafeReadOnlyPtr4[i], ref unsafeReadOnlyPtr2[i], managedComponentAccessor[i], ref unsafeReadOnlyPtr3[i], ref unsafeReadOnlyPtr5[i], ref unsafeReadOnlyPtr6[i]);
			}
		}

		public void Execute(ref LocalTransform transform, ref AgentMovementPlane movementPlane, ref AgentCylinderShape shape, ManagedState managedState, ref MovementSettings settings, ref MovementState movementState, ref ResolvedMovement resolvedMovement)
		{
			if ((settings.debugFlags & PIDMovement.DebugFlags.Funnel) != PIDMovement.DebugFlags.Nothing)
			{
				managedState.pathTracer.DrawFunnel(draw, movementPlane.value);
			}
			if ((settings.debugFlags & PIDMovement.DebugFlags.Rotation) != PIDMovement.DebugFlags.Nothing)
			{
				float elevation;
				float2 origin = movementPlane.value.ToPlane(transform.Position, out elevation);
				draw.PushMatrix(math.mul(new float4x4(movementPlane.value.rotation, float3.zero), float4x4.Translate(new float3(0f, elevation, 0f))));
				float num = movementPlane.value.ToPlane(transform.Rotation);
				float num2 = num - movementState.rotationOffset2;
				float z = num2 - movementState.rotationOffset;
				float targetRotation = resolvedMovement.targetRotation;
				float targetRotationHint = resolvedMovement.targetRotationHint;
				math.sincos(MathF.PI / 2f + new float3(num, num2, z), out var s, out var c);
				draw.xz.ArrowheadArc(origin, new float2(c.x, s.x), shape.radius * 1.1f, Palette.Colorbrewer.Set1.Blue);
				draw.xz.ArrowheadArc(origin, new float2(c.y, s.y), shape.radius * 1.1f, Palette.Colorbrewer.Set1.Purple);
				draw.xz.ArrowheadArc(origin, new float2(c.z, s.z), shape.radius * 1.1f, Palette.Colorbrewer.Set1.Orange);
				math.sincos(MathF.PI / 2f + new float2(targetRotation, targetRotationHint), out var s2, out var c2);
				draw.xz.ArrowheadArc(origin, new float2(c2.x, s2.x), shape.radius * 1.2f, Palette.Colorbrewer.Set1.Yellow);
				draw.xz.ArrowheadArc(origin, new float2(c2.y, s2.y), shape.radius * 1.2f, Palette.Colorbrewer.Set1.Pink);
				draw.PopMatrix();
			}
			if ((settings.debugFlags & PIDMovement.DebugFlags.Path) != PIDMovement.DebugFlags.Nothing && managedState.pathTracer.hasPath)
			{
				scratchBuffer1.Clear();
				managedState.pathTracer.GetNextCorners(scratchBuffer1, int.MaxValue, ref scratchBuffer2, Allocator.Temp, managedState.pathfindingSettings.traversalProvider, managedState.activePath);
				UnsafeSpan<float3> vertices = scratchBuffer1.AsUnsafeSpan();
				DrawGizmosJobUtils.DrawPath(ref draw, ref vertices, ref shape);
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}
}
