using Pathfinding.PID;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding.ECS
{
	public struct MovementState : IComponentData, IQueryTypeParameter
	{
		public PIDMovement.PersistentState followerState;

		public float3 nextCorner;

		public float3 endOfPath;

		public float3 closestOnNavmesh;

		public float3 positionOffset;

		public int hierarchicalNodeIndex;

		public float remainingDistanceToEndOfPart;

		public float rotationOffset;

		public float rotationOffset2;

		public ushort pathTracerVersion;

		private ushort flags;

		private const int ReachedDestinationFlag = 1;

		private const int reachedDestinationAndOrientationFlag = 2;

		private const int ReachedEndOfPathFlag = 4;

		private const int reachedEndOfPathAndOrientationFlag = 8;

		private const int ReachedEndOfPartFlag = 16;

		private const int TraversingLastPartFlag = 32;

		public bool reachedDestination
		{
			[IgnoredByDeepProfiler]
			get
			{
				return (flags & 1) != 0;
			}
			[IgnoredByDeepProfiler]
			set
			{
				flags = (ushort)((flags & -2) | (value ? 1 : 0));
			}
		}

		public bool reachedDestinationAndOrientation
		{
			[IgnoredByDeepProfiler]
			get
			{
				return (flags & 2) != 0;
			}
			[IgnoredByDeepProfiler]
			set
			{
				flags = (ushort)((flags & -3) | (value ? 2 : 0));
			}
		}

		public bool reachedEndOfPath
		{
			[IgnoredByDeepProfiler]
			get
			{
				return (flags & 4) != 0;
			}
			[IgnoredByDeepProfiler]
			set
			{
				flags = (ushort)((flags & -5) | (value ? 4 : 0));
			}
		}

		public bool reachedEndOfPathAndOrientation
		{
			[IgnoredByDeepProfiler]
			get
			{
				return (flags & 8) != 0;
			}
			[IgnoredByDeepProfiler]
			set
			{
				flags = (ushort)((flags & -9) | (value ? 8 : 0));
			}
		}

		public bool reachedEndOfPart
		{
			[IgnoredByDeepProfiler]
			get
			{
				return (flags & 0x10) != 0;
			}
			[IgnoredByDeepProfiler]
			set
			{
				flags = (ushort)((flags & -17) | (value ? 16 : 0));
			}
		}

		public bool traversingLastPart
		{
			[IgnoredByDeepProfiler]
			get
			{
				return (flags & 0x20) != 0;
			}
			[IgnoredByDeepProfiler]
			set
			{
				flags = (ushort)((flags & -33) | (value ? 32 : 0));
			}
		}

		public uint graphIndex
		{
			[IgnoredByDeepProfiler]
			get
			{
				return (uint)(flags >> 8);
			}
			[IgnoredByDeepProfiler]
			internal set
			{
				flags = (ushort)((flags & 0xFF) | (ushort)(value << 8));
			}
		}

		public bool isOnValidNode => hierarchicalNodeIndex != -1;

		public MovementState(Vector3 agentPosition)
		{
			this = default(MovementState);
			SetPathIsEmpty(agentPosition);
		}

		public void SetPathIsEmpty(Vector3 agentPosition)
		{
			nextCorner = agentPosition;
			endOfPath = agentPosition;
			closestOnNavmesh = agentPosition;
			hierarchicalNodeIndex = -1;
			remainingDistanceToEndOfPart = float.PositiveInfinity;
			reachedEndOfPath = false;
			reachedDestination = false;
			reachedEndOfPart = false;
			reachedDestinationAndOrientation = false;
			reachedEndOfPathAndOrientation = false;
			traversingLastPart = true;
			graphIndex = 255u;
		}
	}
}
