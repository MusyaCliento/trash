using System;
using System.Collections.Generic;
using Pathfinding.Collections;
using Pathfinding.Drawing;
using Pathfinding.ECS;
using Pathfinding.ECS.RVO;
using Pathfinding.PID;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Transforms;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/AI/Follower Entity (2D,3D)")]
	[UniqueComponent(tag = "ai")]
	[UniqueComponent(tag = "rvo")]
	[DisallowMultipleComponent]
	public sealed class FollowerEntity : VersionedMonoBehaviour, IAstarAI, ISerializationCallbackReceiver
	{
		[Flags]
		private enum FollowerEntityMigrations
		{
			MigratePathfindingSettings = 1,
			MigrateMovementPlaneSource = 2,
			MigrateAutoRepathPolicy = 4
		}

		[SerializeField]
		private AgentCylinderShape shape = new AgentCylinderShape
		{
			height = 2f,
			radius = 0.5f
		};

		[SerializeField]
		private MovementSettings movement = new MovementSettings
		{
			follower = new PIDMovement
			{
				rotationSpeed = 600f,
				speed = 5f,
				maxRotationSpeed = 720f,
				maxOnSpotRotationSpeed = 720f,
				slowdownTime = 0.5f,
				desiredWallDistance = 0.5f,
				allowRotatingOnSpot = true,
				leadInRadiusWhenApproachingDestination = 1f
			},
			stopDistance = 0.2f,
			rotationSmoothing = 0f,
			groundMask = -1,
			isStopped = false
		};

		[SerializeField]
		private ManagedState managedState = new ManagedState
		{
			enableLocalAvoidance = false,
			pathfindingSettings = PathRequestSettings.Default
		};

		[SerializeField]
		private Pathfinding.ECS.AutoRepathPolicy autoRepathBacking = Pathfinding.ECS.AutoRepathPolicy.Default;

		[SerializeField]
		private OrientationMode orientationBacking;

		[SerializeField]
		private MovementPlaneSource movementPlaneSourceBacking;

		[SerializeField]
		private bool syncPosition = true;

		[SerializeField]
		private bool syncRotation = true;

		private Transform tr;

		private static EntityAccess<DestinationPoint> destinationPointAccessRW = new EntityAccess<DestinationPoint>(readOnly: false);

		private static EntityAccess<DestinationPoint> destinationPointAccessRO = new EntityAccess<DestinationPoint>(readOnly: true);

		private static EntityAccess<AgentMovementPlane> movementPlaneAccessRW = new EntityAccess<AgentMovementPlane>(readOnly: false);

		private static EntityAccess<AgentMovementPlane> movementPlaneAccessRO = new EntityAccess<AgentMovementPlane>(readOnly: false);

		private static EntityAccess<MovementState> movementStateAccessRW = new EntityAccess<MovementState>(readOnly: false);

		private static EntityAccess<MovementState> movementStateAccessRO = new EntityAccess<MovementState>(readOnly: true);

		private static EntityAccess<MovementStatistics> movementOutputAccessRW = new EntityAccess<MovementStatistics>(readOnly: false);

		private static EntityAccess<ResolvedMovement> resolvedMovementAccessRO = new EntityAccess<ResolvedMovement>(readOnly: true);

		private static EntityAccess<ResolvedMovement> resolvedMovementAccessRW = new EntityAccess<ResolvedMovement>(readOnly: false);

		private static EntityAccess<MovementControl> movementControlAccessRO = new EntityAccess<MovementControl>(readOnly: true);

		private static EntityAccess<MovementControl> movementControlAccessRW = new EntityAccess<MovementControl>(readOnly: false);

		private static EntityAccess<MovementStatistics> movementStatisticsAccessRW = new EntityAccess<MovementStatistics>(readOnly: false);

		private static ManagedEntityAccess<ManagedState> managedStateAccessRO = new ManagedEntityAccess<ManagedState>(readOnly: true);

		private static ManagedEntityAccess<ManagedState> managedStateAccessRW = new ManagedEntityAccess<ManagedState>(readOnly: false);

		private static EntityAccess<Pathfinding.ECS.AutoRepathPolicy> autoRepathPolicyRW = new EntityAccess<Pathfinding.ECS.AutoRepathPolicy>(readOnly: false);

		private static EntityAccess<LocalTransform> localTransformAccessRO = new EntityAccess<LocalTransform>(readOnly: true);

		private static EntityAccess<LocalTransform> localTransformAccessRW = new EntityAccess<LocalTransform>(readOnly: false);

		private static EntityAccess<AgentCylinderShape> agentCylinderShapeAccessRO = new EntityAccess<AgentCylinderShape>(readOnly: true);

		private static EntityAccess<AgentCylinderShape> agentCylinderShapeAccessRW = new EntityAccess<AgentCylinderShape>(readOnly: false);

		private static EntityAccess<MovementSettings> movementSettingsAccessRO = new EntityAccess<MovementSettings>(readOnly: true);

		private static EntityAccess<MovementSettings> movementSettingsAccessRW = new EntityAccess<MovementSettings>(readOnly: false);

		private static EntityAccess<AgentOffMeshLinkTraversal> agentOffMeshLinkTraversalRO = new EntityAccess<AgentOffMeshLinkTraversal>(readOnly: true);

		private static EntityAccess<ReadyToTraverseOffMeshLink> readyToTraverseOffMeshLinkRW = new EntityAccess<ReadyToTraverseOffMeshLink>(readOnly: false);

		private static EntityStorageCache entityStorageCache;

		private static EntityArchetype archetype;

		private static World achetypeWorld;

		private static NNConstraint ScratchNNConstraint = NNConstraint.Walkable;

		private static NativeList<float3> nextCornersScratch;

		private static NativeArray<int> indicesScratch;

		private static int scratchReferenceCount = 0;

		private static readonly Color ShapeGizmoColor = new Color(0.9411765f, 71f / 85f, 0.11764706f);

		public Entity entity
		{
			[IgnoredByDeepProfiler]
			get;
			private set; }

		public float radius
		{
			get
			{
				return shape.radius;
			}
			set
			{
				shape.radius = value;
				if (entityStorageCache.GetComponentData(entity, ref agentCylinderShapeAccessRW, out var value2))
				{
					value2.value.radius = value;
				}
			}
		}

		public float height
		{
			get
			{
				return shape.height;
			}
			set
			{
				shape.height = value;
				if (entityStorageCache.GetComponentData(entity, ref agentCylinderShapeAccessRW, out var value2))
				{
					value2.value.height = value;
				}
			}
		}

		public ref PathRequestSettings pathfindingSettings
		{
			get
			{
				entityStorageCache.GetComponentData(entity, ref movementStateAccessRW, out var _);
				return ref managedState.pathfindingSettings;
			}
		}

		public ref RVOAgent rvoSettings
		{
			get
			{
				entityStorageCache.GetComponentData(entity, ref movementStateAccessRW, out var _);
				return ref managedState.rvoSettings;
			}
		}

		public Vector3 position
		{
			get
			{
				if (entityStorageCache.GetComponentData(entity, ref localTransformAccessRO, out var value))
				{
					return value.value.Position;
				}
				return base.transform.position;
			}
			set
			{
				if (entityStorageCache.Update(World.DefaultGameObjectInjectionWorld, entity, out var entityManager, out var storage))
				{
					if (entityManager.HasComponent<SyncPositionWithTransform>(entity))
					{
						base.transform.position = value;
					}
					movementStateAccessRW.Update(entityManager);
					managedStateAccessRW.Update(entityManager);
					agentCylinderShapeAccessRO.Update(entityManager);
					movementSettingsAccessRO.Update(entityManager);
					destinationPointAccessRO.Update(entityManager);
					movementPlaneAccessRO.Update(entityManager);
					localTransformAccessRW.Update(entityManager);
					readyToTraverseOffMeshLinkRW.Update(entityManager);
					ref LocalTransform reference = ref localTransformAccessRW[storage];
					reference.Position = value;
					ref MovementState reference2 = ref movementStateAccessRW[storage];
					reference2.positionOffset = float3.zero;
					if (!managedState.pathTracer.hasPath)
					{
						return;
					}
					ref AgentMovementPlane reference3 = ref movementPlaneAccessRO[storage];
					ushort num = managedState.pathTracer.version;
					managedState.pathTracer.UpdateStart(value, PathTracer.RepairQuality.High, reference3.value, managedState.pathfindingSettings.traversalProvider, managedState.activePath);
					if (managedState.pathTracer.version != num)
					{
						ref AgentCylinderShape reference4 = ref agentCylinderShapeAccessRO[storage];
						ref MovementSettings settings = ref movementSettingsAccessRO[storage];
						ref DestinationPoint reference5 = ref destinationPointAccessRO[storage];
						EnabledRefRW<ReadyToTraverseOffMeshLink> enabledRefRW = storage.Chunk.GetEnabledMask(ref readyToTraverseOffMeshLinkRW.handle).GetEnabledRefRW<ReadyToTraverseOffMeshLink>(storage.IndexInChunk);
						if (!nextCornersScratch.IsCreated)
						{
							nextCornersScratch = new NativeList<float3>(4, Allocator.Persistent);
						}
						JobRepairPath.Execute(ref reference, ref reference2, ref reference4, ref reference3, ref reference5, enabledRefRW, managedState, in settings, nextCornersScratch, ref indicesScratch, Allocator.Persistent, onlyApplyPendingPaths: false);
					}
				}
				else
				{
					base.transform.position = value;
				}
			}
		}

		public bool isTraversingOffMeshLink
		{
			get
			{
				if (!entityExists)
				{
					return false;
				}
				return World.DefaultGameObjectInjectionWorld.EntityManager.HasComponent<AgentOffMeshLinkTraversal>(entity);
			}
		}

		public OffMeshLinks.OffMeshLinkTracer offMeshLink
		{
			get
			{
				if (entityStorageCache.Update(World.DefaultGameObjectInjectionWorld, entity, out var entityManager, out var storage) && entityManager.HasComponent<AgentOffMeshLinkTraversal>(entity))
				{
					agentOffMeshLinkTraversalRO.Update(entityManager);
					AgentOffMeshLinkTraversal agentOffMeshLinkTraversal = agentOffMeshLinkTraversalRO[storage];
					return new OffMeshLinks.OffMeshLinkTracer(EntityManagerManagedComponentExtensions.GetComponentData<ManagedAgentOffMeshLinkTraversal>(entityManager, entity).context.concreteLink, agentOffMeshLinkTraversal.relativeStart, agentOffMeshLinkTraversal.relativeEnd, agentOffMeshLinkTraversal.isReverse);
				}
				return default(OffMeshLinks.OffMeshLinkTracer);
			}
		}

		public IOffMeshLinkHandler onTraverseOffMeshLink
		{
			get
			{
				return managedState.onTraverseOffMeshLink;
			}
			set
			{
				entityStorageCache.GetComponentData(entity, ref movementStateAccessRW, out var _);
				managedState.onTraverseOffMeshLink = value;
			}
		}

		public GraphNode currentNode
		{
			get
			{
				if (!entityExists)
				{
					return null;
				}
				EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
				managedStateAccessRO.Update(entityManager);
				GraphNode startNode = managedState.pathTracer.startNode;
				if (startNode == null || startNode.Destroyed)
				{
					return null;
				}
				return startNode;
			}
		}

		public Quaternion rotation
		{
			get
			{
				if (entityStorageCache.GetComponentData(entity, ref localTransformAccessRO, out var value))
				{
					quaternion quaternion2 = value.value.Rotation;
					if (orientation == OrientationMode.YAxisForward)
					{
						quaternion2 = math.mul(quaternion2, SyncTransformsToEntitiesSystem.ZAxisForwardToYAxisForward);
					}
					return quaternion2;
				}
				return base.transform.rotation;
			}
			set
			{
				if (entityStorageCache.Update(World.DefaultGameObjectInjectionWorld, entity, out var entityManager, out var storage))
				{
					if (entityManager.HasComponent<SyncRotationWithTransform>(entity))
					{
						base.transform.rotation = value;
					}
					if (orientation == OrientationMode.YAxisForward)
					{
						value = math.mul(value, SyncTransformsToEntitiesSystem.YAxisForwardToZAxisForward);
					}
					localTransformAccessRW.Update(entityManager);
					localTransformAccessRW[storage].Rotation = value;
				}
				else if (updateRotation)
				{
					base.transform.rotation = value;
				}
				else
				{
					Debug.LogWarning("Cannot set agent rotation because updateRotation is false and the FollowerEntity component has not been enabled yet. Therefore, the internal entity does not exist, and there's no rotation to set.", this);
				}
			}
		}

		public MovementPlaneSource movementPlaneSource
		{
			get
			{
				return movementPlaneSourceBacking;
			}
			set
			{
				movementPlaneSourceBacking = value;
				if (entityExists)
				{
					World.DefaultGameObjectInjectionWorld.EntityManager.SetSharedComponent(entity, new AgentMovementPlaneSource
					{
						value = value
					});
				}
			}
		}

		public LayerMask groundMask
		{
			get
			{
				return movement.groundMask;
			}
			set
			{
				movement.groundMask = value;
				if (entityStorageCache.GetComponentData(entity, ref movementSettingsAccessRW, out var value2))
				{
					value2.value.groundMask = value;
				}
			}
		}

		public PIDMovement.DebugFlags debugFlags
		{
			get
			{
				return movement.debugFlags;
			}
			set
			{
				movement.debugFlags = value;
				if (entityStorageCache.GetComponentData(entity, ref movementSettingsAccessRW, out var value2))
				{
					value2.value.debugFlags = value;
				}
			}
		}

		public float maxSpeed
		{
			get
			{
				return movement.follower.speed;
			}
			set
			{
				movement.follower.speed = value;
				if (entityStorageCache.GetComponentData(entity, ref movementSettingsAccessRW, out var value2))
				{
					value2.value.follower.speed = value;
				}
			}
		}

		public float rotationSpeed
		{
			get
			{
				return movement.follower.rotationSpeed;
			}
			set
			{
				movement.follower.rotationSpeed = value;
				if (entityStorageCache.GetComponentData(entity, ref movementSettingsAccessRW, out var value2))
				{
					value2.value.follower.rotationSpeed = value;
				}
			}
		}

		public float maxRotationSpeed
		{
			get
			{
				return movement.follower.maxRotationSpeed;
			}
			set
			{
				movement.follower.maxRotationSpeed = value;
				if (entityStorageCache.GetComponentData(entity, ref movementSettingsAccessRW, out var value2))
				{
					value2.value.follower.maxRotationSpeed = value;
				}
			}
		}

		public Vector3 velocity
		{
			get
			{
				if (!entityExists)
				{
					return Vector3.zero;
				}
				return World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<MovementStatistics>(entity).estimatedVelocity;
			}
			set
			{
				if (entityStorageCache.GetComponentData(entity, ref movementStatisticsAccessRW, out var value2))
				{
					value2.value.estimatedVelocity = value;
				}
			}
		}

		public Vector3 desiredVelocity
		{
			get
			{
				if (entityStorageCache.GetComponentData(entity, ref resolvedMovementAccessRO, out var value))
				{
					float num = Mathf.Max(Time.deltaTime, 0.0001f);
					return Vector3.ClampMagnitude((Vector3)value.value.targetPoint - position, num * value.value.speed) / num;
				}
				return Vector3.zero;
			}
		}

		public Vector3 desiredVelocityWithoutLocalAvoidance
		{
			get
			{
				if (entityStorageCache.GetComponentData(entity, ref movementControlAccessRO, out var value))
				{
					float num = Mathf.Max(Time.deltaTime, 0.0001f);
					return Vector3.ClampMagnitude((Vector3)value.value.targetPoint - position, num * value.value.speed) / num;
				}
				return Vector3.zero;
			}
			set
			{
				throw new NotImplementedException("The FollowerEntity does not support setting this property. If you want to override the movement, you'll need to write a custom entity component system.");
			}
		}

		public float remainingDistance
		{
			get
			{
				if (!entityStorageCache.Update(World.DefaultGameObjectInjectionWorld, entity, out var entityManager, out var storage))
				{
					return float.PositiveInfinity;
				}
				movementStateAccessRO.Update(entityManager);
				managedStateAccessRO.Update(entityManager);
				if (managedState.pathTracer.hasPath && !managedState.pathTracer.isStale)
				{
					return movementStateAccessRO[storage].remainingDistanceToEndOfPart + Vector3.Distance(managedState.pathTracer.endPointOfFirstPart, managedState.pathTracer.endPoint);
				}
				return float.PositiveInfinity;
			}
		}

		public float stopDistance
		{
			get
			{
				return movement.stopDistance;
			}
			set
			{
				if (movement.stopDistance != value)
				{
					movement.stopDistance = value;
					if (entityStorageCache.GetComponentData(entity, ref movementSettingsAccessRW, out var value2))
					{
						value2.value.stopDistance = value;
					}
				}
			}
		}

		public float positionSmoothing
		{
			get
			{
				return movement.positionSmoothing;
			}
			set
			{
				if (movement.positionSmoothing != value)
				{
					movement.positionSmoothing = value;
					if (entityStorageCache.GetComponentData(entity, ref movementSettingsAccessRW, out var value2))
					{
						value2.value.positionSmoothing = value;
					}
				}
			}
		}

		public float rotationSmoothing
		{
			get
			{
				return movement.rotationSmoothing;
			}
			set
			{
				if (movement.rotationSmoothing != value)
				{
					movement.rotationSmoothing = value;
					if (entityStorageCache.GetComponentData(entity, ref movementSettingsAccessRW, out var value2))
					{
						value2.value.rotationSmoothing = value;
					}
				}
			}
		}

		public bool reachedDestination
		{
			get
			{
				if (!entityStorageCache.GetComponentData(entity, ref movementStateAccessRW, out var value))
				{
					return false;
				}
				return value.value.reachedDestinationAndOrientation;
			}
		}

		public bool reachedEndOfPath
		{
			get
			{
				if (!entityStorageCache.GetComponentData(entity, ref movementStateAccessRW, out var value))
				{
					return false;
				}
				return value.value.reachedEndOfPathAndOrientation;
			}
		}

		public Vector3 endOfPath
		{
			get
			{
				if (entityExists)
				{
					managedStateAccessRO.Update(World.DefaultGameObjectInjectionWorld.EntityManager);
					if (hasPath)
					{
						return managedState.pathTracer.endPoint;
					}
					Vector3 result = destination;
					if (float.IsFinite(result.x))
					{
						return result;
					}
				}
				return position;
			}
		}

		public Vector3 destination
		{
			get
			{
				if (!entityStorageCache.GetComponentData(entity, ref destinationPointAccessRO, out var value))
				{
					return Vector3.positiveInfinity;
				}
				return value.value.destination;
			}
			set
			{
				SetDestination(value);
			}
		}

		private Vector3 destinationFacingDirection
		{
			get
			{
				if (!entityStorageCache.GetComponentData(entity, ref destinationPointAccessRO, out var value))
				{
					return Vector3.zero;
				}
				return value.value.facingDirection;
			}
		}

		public Pathfinding.ECS.AutoRepathPolicy autoRepath
		{
			get
			{
				return autoRepathBacking;
			}
			set
			{
				autoRepathBacking = value;
				if (entityStorageCache.GetComponentData(entity, ref autoRepathPolicyRW, out var value2))
				{
					value2.value = value;
				}
			}
		}

		[Obsolete("This has been superseded by autoRepath.mode")]
		public bool canSearch
		{
			get
			{
				return autoRepathBacking.mode != AutoRepathPolicy.Mode.Never;
			}
			set
			{
				if (value)
				{
					if (autoRepathBacking.mode == AutoRepathPolicy.Mode.Never)
					{
						autoRepathBacking.mode = AutoRepathPolicy.Mode.EveryNSeconds;
					}
				}
				else
				{
					autoRepathBacking.mode = AutoRepathPolicy.Mode.Never;
				}
				autoRepath = autoRepathBacking;
			}
		}

		public bool canMove
		{
			get
			{
				if (!entityExists)
				{
					return true;
				}
				return World.DefaultGameObjectInjectionWorld.EntityManager.HasComponent<SimulateMovement>(entity);
			}
			set
			{
				ToggleComponent<SimulateMovement>(entity, value, mustExist: true);
			}
		}

		public NativeMovementPlane movementPlane
		{
			get
			{
				if (!entityStorageCache.GetComponentData(entity, ref movementPlaneAccessRO, out var value))
				{
					return new NativeMovementPlane(rotation);
				}
				return value.value.value;
			}
		}

		public bool enableGravity
		{
			get
			{
				if (!entityExists)
				{
					return managedState.enableGravity;
				}
				return World.DefaultGameObjectInjectionWorld.EntityManager.HasComponent<GravityState>(entity);
			}
			set
			{
				if (managedState.enableGravity != value)
				{
					managedState.enableGravity = value;
					ToggleComponentEnabled<GravityState>(entity, value, mustExist: false);
				}
			}
		}

		public bool enableLocalAvoidance
		{
			get
			{
				return managedState.enableLocalAvoidance;
			}
			set
			{
				managedState.enableLocalAvoidance = value;
			}
		}

		public bool updatePosition
		{
			get
			{
				return syncPosition;
			}
			set
			{
				syncPosition = value;
				ToggleComponent<SyncPositionWithTransform>(entity, value, mustExist: false);
			}
		}

		public bool updateRotation
		{
			get
			{
				return syncRotation;
			}
			set
			{
				syncRotation = value;
				ToggleComponent<SyncRotationWithTransform>(entity, value, mustExist: false);
			}
		}

		public OrientationMode orientation
		{
			get
			{
				return orientationBacking;
			}
			set
			{
				if (orientationBacking != value)
				{
					orientationBacking = value;
					ToggleComponent<OrientationYAxisForward>(entity, value == OrientationMode.YAxisForward, mustExist: false);
				}
			}
		}

		public bool hasPath
		{
			get
			{
				if (entityExists)
				{
					managedStateAccessRO.Update(World.DefaultGameObjectInjectionWorld.EntityManager);
				}
				return !managedState.pathTracer.isStale;
			}
		}

		public bool pathPending
		{
			get
			{
				if (!entityExists)
				{
					return false;
				}
				EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
				managedStateAccessRO.Update(entityManager);
				return managedState.pendingPath != null;
			}
		}

		public bool isStopped
		{
			get
			{
				return movement.isStopped;
			}
			set
			{
				if (movement.isStopped != value)
				{
					movement.isStopped = value;
					if (entityStorageCache.GetComponentData(entity, ref movementSettingsAccessRW, out var value2))
					{
						value2.value.isStopped = value;
					}
				}
			}
		}

		public MovementSettings movementSettings
		{
			get
			{
				return movement;
			}
			set
			{
				movement = value;
				if (entityStorageCache.GetComponentData(entity, ref movementSettingsAccessRW, out var value2))
				{
					value2.value = value;
				}
			}
		}

		public Vector3 steeringTarget
		{
			get
			{
				if (!entityStorageCache.GetComponentData(entity, ref movementStateAccessRO, out var value))
				{
					return position;
				}
				return value.value.nextCorner;
			}
		}

		Action IAstarAI.onSearchPath
		{
			get
			{
				return null;
			}
			set
			{
				throw new NotImplementedException("The FollowerEntity does not support this property.");
			}
		}

		public ManagedMovementOverrides movementOverrides => new ManagedMovementOverrides(entity, World.DefaultGameObjectInjectionWorld);

		public bool entityExists
		{
			get
			{
				if (World.DefaultGameObjectInjectionWorld != null)
				{
					return World.DefaultGameObjectInjectionWorld.EntityManager.Exists(entity);
				}
				return false;
			}
		}

		private void OnEnable()
		{
			scratchReferenceCount++;
			FindComponents();
			entity = CreateEntity(tr.position, tr.rotation, tr.localScale.x, ref shape, ref movement, ref autoRepathBacking, managedState, orientationBacking, movementPlaneSourceBacking, syncPosition, syncRotation, base.gameObject.scene.GetPhysicsScene());
			BatchedEvents.Add(this, BatchedEvents.Event.None, (Action<FollowerEntity[], int>)delegate
			{
			}, 0);
			IRuntimeBaker[] components = GetComponents<IRuntimeBaker>();
			for (int num = 0; num < components.Length; num++)
			{
				if (((MonoBehaviour)components[num]).enabled)
				{
					components[num].OnCreatedEntity(World.DefaultGameObjectInjectionWorld, entity);
				}
			}
			if (base.didStart)
			{
				Start();
			}
		}

		public static Entity CreateEntity(float3 position, quaternion rotation, float scale, ref AgentCylinderShape shape, ref MovementSettings movement, ref Pathfinding.ECS.AutoRepathPolicy autoRepath, ManagedState managedState, OrientationMode orientation, MovementPlaneSource movementPlaneSource, bool updatePosition, bool updateRotation, PhysicsScene physicsScene)
		{
			World defaultGameObjectInjectionWorld = World.DefaultGameObjectInjectionWorld;
			if (!archetype.Valid || achetypeWorld != defaultGameObjectInjectionWorld)
			{
				if (defaultGameObjectInjectionWorld == null)
				{
					throw new Exception("World.DefaultGameObjectInjectionWorld is null. Has the world been destroyed?");
				}
				achetypeWorld = defaultGameObjectInjectionWorld;
				archetype = defaultGameObjectInjectionWorld.EntityManager.CreateArchetype(typeof(LocalTransform), typeof(MovementState), typeof(MovementSettings), typeof(Pathfinding.ECS.AutoRepathPolicy), typeof(MovementControl), typeof(ManagedState), typeof(SearchState), typeof(MovementStatistics), typeof(AgentCylinderShape), typeof(ResolvedMovement), typeof(DestinationPoint), typeof(AgentMovementPlane), typeof(GravityState), typeof(SimulateMovement), typeof(SimulateMovementRepair), typeof(SimulateMovementControl), typeof(SimulateMovementFinalize), typeof(SyncPositionWithTransform), typeof(SyncRotationWithTransform), typeof(ReadyToTraverseOffMeshLink), typeof(AgentMovementPlaneSource), typeof(PhysicsSceneRef));
			}
			if (orientation == OrientationMode.YAxisForward)
			{
				rotation = math.mul(rotation, SyncTransformsToEntitiesSystem.YAxisForwardToZAxisForward);
			}
			EntityManager entityManager = defaultGameObjectInjectionWorld.EntityManager;
			Entity result = entityManager.CreateEntity(archetype);
			entityManager.SetComponentData(result, LocalTransform.FromPositionRotationScale(position, rotation, scale));
			entityManager.SetComponentData(result, new MovementState(position));
			entityManager.SetComponentData(result, new DestinationPoint
			{
				destination = new float3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity)
			});
			autoRepath.Reset();
			entityManager.SetComponentData(result, autoRepath);
			entityManager.SetComponentData(result, movement);
			if (!managedState.pathTracer.isCreated)
			{
				managedState.pathTracer = new PathTracer(Allocator.Persistent);
			}
			EntityManagerManagedComponentExtensions.SetComponentData(entityManager, result, managedState);
			entityManager.SetComponentData(result, new MovementStatistics
			{
				estimatedVelocity = float3.zero,
				lastPosition = position
			});
			entityManager.SetComponentData(result, shape);
			entityManager.SetComponentEnabled<GravityState>(result, managedState.enableGravity);
			if (orientation == OrientationMode.YAxisForward)
			{
				entityManager.AddComponent<OrientationYAxisForward>(result);
			}
			entityManager.SetComponentEnabled<ReadyToTraverseOffMeshLink>(result, value: false);
			entityManager.SetSharedComponent(result, new AgentMovementPlaneSource
			{
				value = movementPlaneSource
			});
			entityManager.SetSharedComponent(result, new PhysicsSceneRef
			{
				physicsScene = physicsScene
			});
			ToggleComponent<SyncPositionWithTransform>(result, updatePosition, mustExist: true);
			ToggleComponent<SyncRotationWithTransform>(result, updateRotation, mustExist: true);
			ResolvedMovement resolvedMovement = default(ResolvedMovement);
			MovementControl controlOutput = default(MovementControl);
			AgentMovementPlane componentData = new AgentMovementPlane(rotation);
			ResetControl(ref resolvedMovement, ref controlOutput, ref componentData, position, rotation, position);
			entityManager.SetComponentData(result, componentData);
			entityManager.SetComponentData(result, resolvedMovement);
			entityManager.SetComponentData(result, controlOutput);
			return result;
		}

		internal void RegisterRuntimeBaker(IRuntimeBaker baker)
		{
			if (entityExists)
			{
				baker.OnCreatedEntity(World.DefaultGameObjectInjectionWorld, entity);
			}
		}

		private void Start()
		{
			EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
			managedStateAccessRW.Update(entityManager);
			movementPlaneAccessRW.Update(entityManager);
			resolvedMovementAccessRW.Update(entityManager);
			movementControlAccessRW.Update(entityManager);
			if (managedState.pathTracer.hasPath || !(AstarPath.active != null))
			{
				return;
			}
			ScratchNNConstraint.UseSettings(managedState.pathfindingSettings);
			NNInfo nearest = AstarPath.active.GetNearest(position, ScratchNNConstraint);
			if (nearest.node != null)
			{
				EntityStorageInfo storageInfo = entityManager.GetStorageInfo(entity);
				ref AgentMovementPlane reference = ref movementPlaneAccessRW[storageInfo];
				ref ResolvedMovement reference2 = ref resolvedMovementAccessRW[storageInfo];
				ref MovementControl reference3 = ref movementControlAccessRW[storageInfo];
				if (movementPlaneSource == MovementPlaneSource.Graph)
				{
					quaternion quaternion2 = reference.value.ToWorldRotation(reference2.targetRotation);
					quaternion quaternion3 = reference.value.ToWorldRotation(reference2.targetRotationHint);
					quaternion quaternion4 = reference.value.ToWorldRotation(reference3.targetRotation);
					quaternion quaternion5 = reference.value.ToWorldRotation(reference3.targetRotationHint);
					reference = new AgentMovementPlane(MovementPlaneFromGraphSystem.MovementPlaneFromGraph(nearest.node.Graph));
					reference2.targetRotation = reference.value.ToPlane(quaternion2);
					reference2.targetRotationHint = reference.value.ToPlane(quaternion3);
					reference3.targetRotation = reference.value.ToPlane(quaternion4);
					reference3.targetRotationHint = reference.value.ToPlane(quaternion5);
				}
				managedState.pathTracer.SetFromSingleNode(nearest.node, nearest.position, reference.value, managedState.pathfindingSettings);
				managedState.pathTracer.UpdateEnd(Vector3.positiveInfinity, PathTracer.RepairQuality.High, reference.value, null, null);
			}
		}

		private void OnDisable()
		{
			scratchReferenceCount--;
			if (scratchReferenceCount == 0)
			{
				if (indicesScratch.IsCreated)
				{
					indicesScratch.Dispose();
				}
				if (nextCornersScratch.IsCreated)
				{
					nextCornersScratch.Dispose();
				}
			}
			BatchedEvents.Remove(this);
			CancelCurrentPathRequest();
			if (World.DefaultGameObjectInjectionWorld != null && World.DefaultGameObjectInjectionWorld.IsCreated)
			{
				World.DefaultGameObjectInjectionWorld.EntityManager.DestroyEntity(entity);
			}
			managedState.Dispose();
			entity = default(Entity);
		}

		public void SetDestination(float3 destination, float3 facingDirection = default(float3))
		{
			AssertEntityExists();
			EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
			movementStateAccessRW.Update(entityManager);
			managedStateAccessRW.Update(entityManager);
			agentCylinderShapeAccessRO.Update(entityManager);
			movementSettingsAccessRO.Update(entityManager);
			localTransformAccessRO.Update(entityManager);
			destinationPointAccessRW.Update(entityManager);
			movementPlaneAccessRO.Update(entityManager);
			readyToTraverseOffMeshLinkRW.Update(entityManager);
			EntityStorageInfo storageInfo = entityManager.GetStorageInfo(entity);
			destinationPointAccessRW[storageInfo] = new DestinationPoint
			{
				destination = destination,
				facingDirection = facingDirection
			};
			if (!managedState.pathTracer.hasPath)
			{
				return;
			}
			ref AgentMovementPlane reference = ref movementPlaneAccessRO[storageInfo];
			managedState.pathTracer.UpdateEnd(destination, PathTracer.RepairQuality.High, reference.value, managedState.pathfindingSettings.traversalProvider, managedState.activePath);
			ref MovementState reference2 = ref movementStateAccessRW[storageInfo];
			if (reference2.pathTracerVersion != managedState.pathTracer.version)
			{
				ref AgentCylinderShape reference3 = ref agentCylinderShapeAccessRO[storageInfo];
				ref MovementSettings settings = ref movementSettingsAccessRO[storageInfo];
				ref LocalTransform reference4 = ref localTransformAccessRO[storageInfo];
				ref DestinationPoint reference5 = ref destinationPointAccessRW[storageInfo];
				EnabledRefRW<ReadyToTraverseOffMeshLink> enabledRefRW = storageInfo.Chunk.GetEnabledMask(ref readyToTraverseOffMeshLinkRW.handle).GetEnabledRefRW<ReadyToTraverseOffMeshLink>(storageInfo.IndexInChunk);
				if (!nextCornersScratch.IsCreated)
				{
					nextCornersScratch = new NativeList<float3>(4, Allocator.Persistent);
				}
				JobRepairPath.Execute(ref reference4, ref reference2, ref reference3, ref reference, ref reference5, enabledRefRW, managedState, in settings, nextCornersScratch, ref indicesScratch, Allocator.Persistent, onlyApplyPendingPaths: false);
			}
		}

		private static void ToggleComponent<T>(Entity entity, bool enabled, bool mustExist) where T : struct, IComponentData
		{
			World defaultGameObjectInjectionWorld = World.DefaultGameObjectInjectionWorld;
			if (defaultGameObjectInjectionWorld == null || !defaultGameObjectInjectionWorld.EntityManager.Exists(entity))
			{
				if (!mustExist)
				{
					throw new InvalidOperationException("Entity does not exist. You can only access this if the component is active and enabled.");
				}
			}
			else if (enabled)
			{
				defaultGameObjectInjectionWorld.EntityManager.AddComponent<T>(entity);
			}
			else
			{
				defaultGameObjectInjectionWorld.EntityManager.RemoveComponent<T>(entity);
			}
		}

		private static void ToggleComponentEnabled<T>(Entity entity, bool enabled, bool mustExist) where T : struct, IComponentData, IEnableableComponent
		{
			World defaultGameObjectInjectionWorld = World.DefaultGameObjectInjectionWorld;
			if (defaultGameObjectInjectionWorld == null || !defaultGameObjectInjectionWorld.EntityManager.Exists(entity))
			{
				if (!mustExist)
				{
					throw new InvalidOperationException("Entity does not exist. You can only access this if the component is active and enabled.");
				}
			}
			else
			{
				defaultGameObjectInjectionWorld.EntityManager.SetComponentEnabled<T>(entity, enabled);
			}
		}

		void IAstarAI.FinalizeMovement(Vector3 nextPosition, Quaternion nextRotation)
		{
			throw new InvalidOperationException("The FollowerEntity component does not support FinalizeMovement. Use an ECS system to override movement instead, or use the movementOverrides property. If you just want to move the agent to a position, set ai.position or call ai.Teleport.");
		}

		public void GetRemainingPath(List<Vector3> buffer, out bool stale)
		{
			GetRemainingPath(buffer, null, out stale);
		}

		public void GetRemainingPath(List<Vector3> buffer, List<PathPartWithLinkInfo> partsBuffer, out bool stale)
		{
			buffer.Clear();
			partsBuffer?.Clear();
			if (!entityExists)
			{
				buffer.Add(position);
				partsBuffer?.Add(new PathPartWithLinkInfo
				{
					startIndex = 0,
					endIndex = 0
				});
				stale = true;
				return;
			}
			ManagedState componentData = EntityManagerManagedComponentExtensions.GetComponentData<ManagedState>(World.DefaultGameObjectInjectionWorld.EntityManager, entity);
			stale = false;
			if (componentData.pathTracer.hasPath)
			{
				NativeList<float3> nativeList = new NativeList<float3>(Allocator.Temp);
				NativeArray<int> scratchArray = new NativeArray<int>(8, Allocator.Temp);
				componentData.pathTracer.GetNextCorners(nativeList, int.MaxValue, ref scratchArray, Allocator.Temp, componentData.pathfindingSettings.traversalProvider, componentData.activePath);
				partsBuffer?.Add(new PathPartWithLinkInfo(0, nativeList.Length - 1));
				if (componentData.pathTracer.partCount > 1)
				{
					PathTracer pathTracer = componentData.pathTracer.Clone();
					while (pathTracer.partCount > 1)
					{
						pathTracer.PopParts(1, componentData.pathfindingSettings.traversalProvider, componentData.activePath);
						int length = nativeList.Length;
						if (pathTracer.GetPartType() == Funnel.PartType.NodeSequence)
						{
							pathTracer.GetNextCorners(nativeList, int.MaxValue, ref scratchArray, Allocator.Temp, componentData.pathfindingSettings.traversalProvider, componentData.activePath);
							partsBuffer?.Add(new PathPartWithLinkInfo(length, nativeList.Length - 1));
						}
						else
						{
							if (pathTracer.PartContainsDestroyedNodes())
							{
								stale = true;
								break;
							}
							partsBuffer?.Add(new PathPartWithLinkInfo(length - 1, length, pathTracer.GetLinkInfo()));
						}
						stale |= pathTracer.isStale;
					}
				}
				nativeList.AsUnsafeSpan().Reinterpret<Vector3>().CopyTo(buffer);
			}
			else
			{
				buffer.Add(position);
				partsBuffer?.Add(new PathPartWithLinkInfo
				{
					startIndex = 0,
					endIndex = 0
				});
			}
			stale |= componentData.pathTracer.isStale;
		}

		public void Move(Vector3 deltaPosition)
		{
			position += deltaPosition;
		}

		void IAstarAI.MovementUpdate(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			throw new InvalidOperationException("The FollowerEntity component does not support MovementUpdate. Use an ECS system to override movement instead, or use the movementOverrides property");
		}

		public void SearchPath()
		{
			Vector3 end = destination;
			if (float.IsFinite(end.x))
			{
				_ = movementPlane;
				ABPath aBPath = ABPath.Construct(position, end);
				aBPath.UseSettings(managedState.pathfindingSettings);
				SetPath(aBPath, updateDestinationFromPath: false);
			}
		}

		private void AssertEntityExists()
		{
			if (World.DefaultGameObjectInjectionWorld == null || !World.DefaultGameObjectInjectionWorld.EntityManager.Exists(entity))
			{
				throw new InvalidOperationException("Entity does not exist. You can only access this if the component is active and enabled.");
			}
		}

		private void CancelCurrentPathRequest()
		{
			if (entityExists)
			{
				EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
				managedStateAccessRW.Update(entityManager);
				managedState.CancelCurrentPathRequest();
			}
		}

		private void ClearPath()
		{
			ClearPath(entity);
		}

		private static void ClearPath(Entity entity)
		{
			if (!entityStorageCache.Update(World.DefaultGameObjectInjectionWorld, entity, out var entityManager, out var storage))
			{
				return;
			}
			agentOffMeshLinkTraversalRO.Update(entityManager);
			if (agentOffMeshLinkTraversalRO.HasComponent(storage))
			{
				ManagedAgentOffMeshLinkTraversal componentData = EntityManagerManagedComponentExtensions.GetComponentData<ManagedAgentOffMeshLinkTraversal>(entityManager, entity);
				if (componentData.stateMachine != null)
				{
					componentData.stateMachine.OnAbortTraversingOffMeshLink();
				}
				componentData.context.Restore();
				entityManager.RemoveComponent<AgentOffMeshLinkTraversal>(entity);
				entityManager.RemoveComponent<ManagedAgentOffMeshLinkTraversal>(entity);
				entityStorageCache.Update(World.DefaultGameObjectInjectionWorld, entity, out entityManager, out storage);
			}
			entityManager.SetComponentEnabled<ReadyToTraverseOffMeshLink>(entity, value: false);
			managedStateAccessRW.Update(entityManager);
			movementStateAccessRW.Update(entityManager);
			localTransformAccessRO.Update(entityManager);
			movementPlaneAccessRO.Update(entityManager);
			resolvedMovementAccessRW.Update(entityManager);
			movementControlAccessRW.Update(entityManager);
			ref MovementState reference = ref movementStateAccessRW[storage];
			ref LocalTransform reference2 = ref localTransformAccessRO[storage];
			ref AgentMovementPlane reference3 = ref movementPlaneAccessRO[storage];
			ref ResolvedMovement resolvedMovement = ref resolvedMovementAccessRW[storage];
			ref MovementControl controlOutput = ref movementControlAccessRW[storage];
			ManagedState obj = managedStateAccessRW[storage];
			obj.ClearPath();
			obj.CancelCurrentPathRequest();
			reference.SetPathIsEmpty(reference2.Position);
			ResetControl(ref resolvedMovement, ref controlOutput, ref reference3, reference2.Position, reference2.Rotation, reference.endOfPath);
		}

		private static void ResetControl(ref ResolvedMovement resolvedMovement, ref MovementControl controlOutput, ref AgentMovementPlane movementPlane, float3 position, quaternion rotation, float3 endOfPath)
		{
			resolvedMovement.targetPoint = position;
			resolvedMovement.speed = 0f;
			resolvedMovement.targetRotation = (resolvedMovement.targetRotationHint = (controlOutput.targetRotation = (controlOutput.targetRotationHint = movementPlane.value.ToPlane(rotation))));
			controlOutput.endOfPath = endOfPath;
			controlOutput.speed = 0f;
			controlOutput.targetPoint = position;
		}

		public void SetPath(Path path, bool updateDestinationFromPath = true)
		{
			SetPath(entity, path, updateDestinationFromPath);
		}

		public static void SetPath(Entity entity, Path path, bool updateDestinationFromPath = true)
		{
			EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
			if (!entityManager.Exists(entity))
			{
				throw new InvalidOperationException("Entity does not exist. You can only assign a path if the component is active and enabled.");
			}
			managedStateAccessRW.Update(entityManager);
			movementPlaneAccessRO.Update(entityManager);
			agentOffMeshLinkTraversalRO.Update(entityManager);
			movementStateAccessRW.Update(entityManager);
			localTransformAccessRO.Update(entityManager);
			destinationPointAccessRW.Update(entityManager);
			autoRepathPolicyRW.Update(entityManager);
			EntityStorageInfo storageInfo = entityManager.GetStorageInfo(entity);
			if (agentOffMeshLinkTraversalRO.HasComponent(storageInfo))
			{
				return;
			}
			if (path == null)
			{
				ClearPath(entity);
				return;
			}
			ManagedState managedState = managedStateAccessRW[storageInfo];
			ref AgentMovementPlane reference = ref movementPlaneAccessRO[storageInfo];
			ref MovementState reference2 = ref movementStateAccessRW[storageInfo];
			ref LocalTransform reference3 = ref localTransformAccessRO[storageInfo];
			ref DestinationPoint reference4 = ref destinationPointAccessRW[storageInfo];
			ref Pathfinding.ECS.AutoRepathPolicy reference5 = ref autoRepathPolicyRW[storageInfo];
			if (updateDestinationFromPath && path is ABPath aBPath)
			{
				if (aBPath.endPointKnownBeforeCalculation)
				{
					reference4 = new DestinationPoint
					{
						destination = aBPath.originalEndPoint,
						facingDirection = default(float3)
					};
				}
				else
				{
					reference4 = new DestinationPoint
					{
						destination = Vector3.positiveInfinity,
						facingDirection = default(float3)
					};
				}
			}
			path.nnConstraint.distanceMetric = DistanceMetric.ClosestAsSeenFromAboveSoft(reference.value.up);
			ManagedState.SetPath(path, managedState, in reference, ref reference4);
			reference5.DidRecalculatePath(reference4.destination, (float)World.DefaultGameObjectInjectionWorld.Time.ElapsedTime);
			if (!path.IsDone())
			{
				return;
			}
			agentCylinderShapeAccessRO.Update(entityManager);
			movementSettingsAccessRO.Update(entityManager);
			readyToTraverseOffMeshLinkRW.Update(entityManager);
			managedState.pathTracer.UpdateStart(reference3.Position, PathTracer.RepairQuality.High, reference.value, managedState.pathfindingSettings.traversalProvider, managedState.activePath);
			managedState.pathTracer.UpdateEnd(reference4.destination, PathTracer.RepairQuality.High, reference.value, managedState.pathfindingSettings.traversalProvider, managedState.activePath);
			if (reference2.pathTracerVersion != managedState.pathTracer.version)
			{
				if (!nextCornersScratch.IsCreated)
				{
					nextCornersScratch = new NativeList<float3>(4, Allocator.Persistent);
				}
				ref AgentCylinderShape reference6 = ref agentCylinderShapeAccessRO[storageInfo];
				ref MovementSettings settings = ref movementSettingsAccessRO[storageInfo];
				EnabledRefRW<ReadyToTraverseOffMeshLink> enabledRefRW = storageInfo.Chunk.GetEnabledMask(ref readyToTraverseOffMeshLinkRW.handle).GetEnabledRefRW<ReadyToTraverseOffMeshLink>(storageInfo.IndexInChunk);
				JobRepairPath.Execute(ref reference3, ref reference2, ref reference6, ref reference, ref reference4, enabledRefRW, managedState, in settings, nextCornersScratch, ref indicesScratch, Allocator.Persistent, onlyApplyPendingPaths: false);
			}
		}

		public void Teleport(Vector3 newPosition, bool clearPath = true)
		{
			if (clearPath)
			{
				ClearPath();
			}
			if (entityExists)
			{
				EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
				movementOutputAccessRW.Update(entityManager);
				managedStateAccessRW.Update(entityManager);
				movementPlaneAccessRO.Update(entityManager);
				EntityStorageInfo storageInfo = entityManager.GetStorageInfo(entity);
				movementOutputAccessRW[storageInfo].lastPosition = newPosition;
				managedState.CancelCurrentPathRequest();
				if (AstarPath.active != null)
				{
					ScratchNNConstraint.UseSettings(managedState.pathfindingSettings);
					NNInfo nearest = AstarPath.active.GetNearest(newPosition, ScratchNNConstraint);
					if (nearest.node != null)
					{
						AgentMovementPlane agentMovementPlane = movementPlaneAccessRO[storageInfo];
						managedState.pathTracer.SetFromSingleNode(nearest.node, nearest.position, agentMovementPlane.value, managedState.pathfindingSettings);
					}
				}
				position = newPosition;
			}
			else
			{
				position = newPosition;
			}
		}

		private void FindComponents()
		{
			tr = base.transform;
		}

		public override void DrawGizmos()
		{
			if (tr == null)
			{
				FindComponents();
			}
			Color shapeGizmoColor = ShapeGizmoColor;
			Vector3 vector = destination;
			Quaternion quaternion2 = rotation;
			Vector3 localScale = tr.localScale;
			float num = shape.radius * math.abs(localScale.x);
			if (orientation == OrientationMode.YAxisForward)
			{
				Draw.Circle(position, quaternion2 * Vector3.forward, num, shapeGizmoColor);
			}
			else
			{
				Draw.WireCylinder(position, quaternion2 * Vector3.up, localScale.y * shape.height, num, shapeGizmoColor);
			}
			if (!updateRotation)
			{
				Draw.ArrowheadArc(position, quaternion2 * Vector3.forward, num * 1.05f, shapeGizmoColor);
			}
			if (!float.IsPositiveInfinity(vector.x) && Application.isPlaying)
			{
				Vector3 vector2 = destinationFacingDirection;
				if (vector2 != Vector3.zero)
				{
					Draw.xz.ArrowheadArc(vector, vector2, 0.25f, Color.blue);
				}
				Draw.xz.Circle(vector, 0.2f, Color.blue);
			}
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
			if (migrations.TryMigrateFromLegacyFormat(out var _) && pathfindingSettings.tagPenalties.Length != 0)
			{
				migrations.MarkMigrationFinished(1);
			}
			if (migrations.AddAndMaybeRunMigration(1, unityThread))
			{
				if (TryGetComponent<Seeker>(out var component))
				{
					pathfindingSettings = new PathRequestSettings
					{
						graphMask = component.graphMask,
						traversableTags = component.traversableTags,
						tagPenalties = component.tagPenalties
					};
					UnityEngine.Object.DestroyImmediate(component);
				}
				else
				{
					pathfindingSettings = PathRequestSettings.Default;
				}
			}
			migrations.AddAndMaybeRunMigration(2);
			migrations.AddAndMaybeRunMigration(4);
		}
	}
}
