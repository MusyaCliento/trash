using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	[BurstCompile]
	internal static class JobRepairPathHelpers
	{
		public struct PathTracerInfo
		{
			public float3 endPointOfFirstPart;

			public int partCount;

			private byte isStaleBacking;

			public bool isStale
			{
				get
				{
					return isStaleBacking != 0;
				}
				set
				{
					isStaleBacking = (byte)(value ? 1 : 0);
				}
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void UpdateReachedEndInfo_00000F39_0024PostfixBurstDelegate(ref UnsafeSpan<float3> nextCorners, ref MovementState state, ref AgentMovementPlane movementPlane, ref LocalTransform transform, ref AgentCylinderShape shape, ref DestinationPoint destination, float stopDistance, ref PathTracerInfo pathTracer);

		internal static class UpdateReachedEndInfo_00000F39_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<UpdateReachedEndInfo_00000F39_0024PostfixBurstDelegate>(UpdateReachedEndInfo).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref UnsafeSpan<float3> nextCorners, ref MovementState state, ref AgentMovementPlane movementPlane, ref LocalTransform transform, ref AgentCylinderShape shape, ref DestinationPoint destination, float stopDistance, ref PathTracerInfo pathTracer)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref UnsafeSpan<float3>, ref MovementState, ref AgentMovementPlane, ref LocalTransform, ref AgentCylinderShape, ref DestinationPoint, float, ref PathTracerInfo, void>)functionPointer)(ref nextCorners, ref state, ref movementPlane, ref transform, ref shape, ref destination, stopDistance, ref pathTracer);
						return;
					}
				}
				UpdateReachedEndInfo_0024BurstManaged(ref nextCorners, ref state, ref movementPlane, ref transform, ref shape, ref destination, stopDistance, ref pathTracer);
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Pathfinding_002EECS_002EUpdateReachedEndInfo_00000F39_0024PostfixBurstDelegate))]
		public static void UpdateReachedEndInfo(ref UnsafeSpan<float3> nextCorners, ref MovementState state, ref AgentMovementPlane movementPlane, ref LocalTransform transform, ref AgentCylinderShape shape, ref DestinationPoint destination, float stopDistance, ref PathTracerInfo pathTracer)
		{
			UpdateReachedEndInfo_00000F39_0024BurstDirectCall.Invoke(ref nextCorners, ref state, ref movementPlane, ref transform, ref shape, ref destination, stopDistance, ref pathTracer);
		}

		public static void UpdateReachedOrientation(ref MovementState state, ref LocalTransform transform, ref AgentMovementPlane movementPlane, ref DestinationPoint destination)
		{
			state.reachedEndOfPathAndOrientation = state.reachedEndOfPath;
			state.reachedDestinationAndOrientation = state.reachedDestination;
			if (state.reachedEndOfPathAndOrientation || state.reachedDestinationAndOrientation)
			{
				bool flag = ReachedDesiredOrientation(ref transform, ref movementPlane, ref destination);
				state.reachedEndOfPathAndOrientation &= flag;
				state.reachedDestinationAndOrientation &= flag;
			}
		}

		private static bool ReachedDesiredOrientation(ref LocalTransform transform, ref AgentMovementPlane movementPlane, ref DestinationPoint destination)
		{
			float2 float5 = math.normalizesafe(movementPlane.value.ToPlane(destination.facingDirection));
			if (math.all(float5 == 0f))
			{
				return true;
			}
			return math.dot(math.normalizesafe(movementPlane.value.ToPlane(transform.Forward())), float5) >= 0.9999f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void UpdateReachedEndInfo_0024BurstManaged(ref UnsafeSpan<float3> nextCorners, ref MovementState state, ref AgentMovementPlane movementPlane, ref LocalTransform transform, ref AgentCylinderShape shape, ref DestinationPoint destination, float stopDistance, ref PathTracerInfo pathTracer)
		{
			state.nextCorner = ((nextCorners.length > 1) ? nextCorners[1] : transform.Position);
			state.remainingDistanceToEndOfPart = PathTracer.RemainingDistanceLowerBound(in nextCorners, in pathTracer.endPointOfFirstPart, in movementPlane.value);
			movementPlane.value.ToPlane(pathTracer.endPointOfFirstPart - transform.Position, out var elevation);
			bool flag = elevation < shape.height && elevation > -0.5f * shape.height;
			movementPlane.value.ToPlane(destination.destination - transform.Position, out var elevation2);
			bool flag2 = elevation2 < shape.height && elevation2 > -0.5f * shape.height;
			float num = math.length(movementPlane.value.ToPlane(destination.destination - state.endOfPath));
			state.reachedEndOfPart = !pathTracer.isStale && flag && state.remainingDistanceToEndOfPart <= shape.radius * 1.1f;
			state.reachedEndOfPath = !pathTracer.isStale && flag && pathTracer.partCount == 1 && state.remainingDistanceToEndOfPart <= stopDistance;
			state.reachedDestination = !pathTracer.isStale && flag2 && pathTracer.partCount == 1 && state.remainingDistanceToEndOfPart + num <= stopDistance + (state.reachedEndOfPath ? 0.01f : 0f);
			state.traversingLastPart = pathTracer.partCount == 1;
			UpdateReachedOrientation(ref state, ref transform, ref movementPlane, ref destination);
		}
	}
}
