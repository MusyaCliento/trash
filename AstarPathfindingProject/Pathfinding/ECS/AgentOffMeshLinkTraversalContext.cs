using System;
using Pathfinding.Util;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Properties;
using Unity.Transforms;
using UnityEngine;

namespace Pathfinding.ECS
{
	public class AgentOffMeshLinkTraversalContext : ICloneable
	{
		public class AbortOffMeshLinkTraversal : Exception
		{
		}

		internal unsafe AgentOffMeshLinkTraversal* linkInfoPtr;

		internal unsafe MovementControl* movementControlPtr;

		internal unsafe MovementSettings* movementSettingsPtr;

		internal unsafe LocalTransform* transformPtr;

		internal unsafe AgentMovementPlane* movementPlanePtr;

		internal EnabledRefRW<AgentOffMeshLinkMovementDisabled> movementDisabled;

		public Entity entity;

		[DontCreateProperty]
		public ManagedState managedState;

		[DontCreateProperty]
		internal OffMeshLinks.OffMeshLinkConcrete concreteLink;

		protected bool disabledRVO;

		protected float backupRotationSmoothing = float.NaN;

		public float deltaTime;

		protected GameObject gameObjectCache;

		public virtual GameObject gameObject
		{
			get
			{
				if (gameObjectCache == null)
				{
					FollowerEntity followerEntity = BatchedEvents.Find(entity, (FollowerEntity follower, Entity entity) => follower.entity == entity);
					if (followerEntity != null)
					{
						gameObjectCache = followerEntity.gameObject;
					}
				}
				return gameObjectCache;
			}
		}

		public unsafe ref LocalTransform transform => ref *transformPtr;

		public unsafe ref MovementSettings movementSettings => ref *movementSettingsPtr;

		public unsafe ref MovementControl movementControl => ref *movementControlPtr;

		public unsafe OffMeshLinks.OffMeshLinkTracer link => new OffMeshLinks.OffMeshLinkTracer(concreteLink, linkInfoPtr->relativeStart, linkInfoPtr->relativeEnd, linkInfoPtr->isReverse);

		[Obsolete("Use the link property instead")]
		public unsafe AgentOffMeshLinkTraversal linkInfo => *linkInfoPtr;

		public unsafe ref NativeMovementPlane movementPlane => ref movementPlanePtr->value;

		public bool enableBuiltInMovement
		{
			get
			{
				return !movementDisabled.ValueRW;
			}
			set
			{
				movementDisabled.ValueRW = !value;
			}
		}

		public AgentOffMeshLinkTraversalContext(OffMeshLinks.OffMeshLinkConcrete link)
		{
			concreteLink = link;
		}

		public unsafe virtual void SetInternalData(Entity entity, ref LocalTransform transform, ref AgentMovementPlane movementPlane, ref MovementControl movementControl, ref MovementSettings movementSettings, ref AgentOffMeshLinkTraversal linkInfo, EnabledRefRW<AgentOffMeshLinkMovementDisabled> movementDisabled, ManagedState state, float deltaTime)
		{
			linkInfoPtr = (AgentOffMeshLinkTraversal*)UnsafeUtility.AddressOf(ref linkInfo);
			movementControlPtr = (MovementControl*)UnsafeUtility.AddressOf(ref movementControl);
			movementSettingsPtr = (MovementSettings*)UnsafeUtility.AddressOf(ref movementSettings);
			transformPtr = (LocalTransform*)UnsafeUtility.AddressOf(ref transform);
			movementPlanePtr = (AgentMovementPlane*)UnsafeUtility.AddressOf(ref movementPlane);
			this.movementDisabled = movementDisabled;
			managedState = state;
			this.deltaTime = deltaTime;
			this.entity = entity;
		}

		public void DisableLocalAvoidance()
		{
			if (managedState.enableLocalAvoidance)
			{
				disabledRVO = true;
				managedState.enableLocalAvoidance = false;
			}
		}

		public void DisableRotationSmoothing()
		{
			if (float.IsNaN(backupRotationSmoothing) && movementSettings.rotationSmoothing > 0f)
			{
				backupRotationSmoothing = movementSettings.rotationSmoothing;
				movementSettings.rotationSmoothing = 0f;
			}
		}

		public virtual void Restore()
		{
			if (disabledRVO)
			{
				managedState.enableLocalAvoidance = true;
				disabledRVO = false;
			}
			if (!float.IsNaN(backupRotationSmoothing))
			{
				movementSettings.rotationSmoothing = backupRotationSmoothing;
				backupRotationSmoothing = float.NaN;
			}
		}

		public virtual void Teleport(float3 position)
		{
			transform.Position = position;
		}

		public virtual void Abort(bool teleportToStart = true)
		{
			if (teleportToStart)
			{
				Teleport(link.relativeStart);
			}
			managedState.pathTracer.RemoveAllButFirstNode(movementPlane, managedState.pathfindingSettings.traversalProvider);
			throw new AbortOffMeshLinkTraversal();
		}

		public virtual MovementTarget MoveTowards(float3 position, quaternion rotation, bool gravity, bool slowdown)
		{
			DisableRotationSmoothing();
			enableBuiltInMovement = true;
			float num = math.length(movementPlane.ToPlane(position - transform.Position));
			float y = movementSettings.follower.Speed(slowdown ? num : float.PositiveInfinity);
			float x = movementSettings.follower.Accelerate(movementControl.speed, movementSettings.follower.slowdownTime, deltaTime);
			x = math.min(x, y);
			float num2 = movementPlane.ToPlane(rotation);
			float num3 = Mathf.Abs(AstarMath.DeltaAngle(movementPlane.ToPlane(transform.Rotation), num2));
			movementControl = new MovementControl
			{
				targetPoint = position,
				endOfPath = position,
				speed = x,
				maxSpeed = x * 1.1f,
				hierarchicalNodeIndex = -1,
				overrideLocalAvoidance = true,
				targetRotation = num2,
				targetRotationHint = num2,
				targetRotationOffset = 0f,
				rotationSpeed = math.radians(movementSettings.follower.rotationSpeed)
			};
			return new MovementTarget
			{
				isReached = (num <= (slowdown ? 0.01f : (x * (1f / 30f))) && num3 < math.radians(1f))
			};
		}

		public unsafe virtual object Clone()
		{
			AgentOffMeshLinkTraversalContext obj = (AgentOffMeshLinkTraversalContext)MemberwiseClone();
			obj.entity = Entity.Null;
			obj.gameObjectCache = null;
			obj.managedState = null;
			obj.movementDisabled = default(EnabledRefRW<AgentOffMeshLinkMovementDisabled>);
			obj.linkInfoPtr = null;
			obj.movementControlPtr = null;
			obj.movementSettingsPtr = null;
			obj.transformPtr = null;
			obj.movementPlanePtr = null;
			return obj;
		}
	}
}
