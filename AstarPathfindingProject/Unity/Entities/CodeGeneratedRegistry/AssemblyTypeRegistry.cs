using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pathfinding;
using Pathfinding.ECS;
using Pathfinding.ECS.RVO;
using Pathfinding.Examples;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.RVO;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Core;
using Unity.Transforms;
using UnityEngine.Scripting;

namespace Unity.Entities.CodeGeneratedRegistry
{
	[UnityEngine.Scripting.Preserve]
	public class AssemblyTypeRegistry
	{
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 7904)]
		public struct ConstantData0
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 320)]
		public struct ConstantData1
		{
		}

		public unsafe static readonly TypeRegistry TypeRegistry = new TypeRegistry
		{
			AssemblyName = "AstarPathfindingProject",
			HasAssemblyWideDisableAutoCreation = false,
			TypeInfosPtr = (TypeManager.TypeInfo*)Unsafe.AsPointer(ref Value0),
			TypeInfosCount = 76,
			Types = new Type[76]
			{
				typeof(AstarPath),
				typeof(AIDestinationSetter),
				typeof(AIPathAlignedToSurface),
				typeof(MoveInCircle),
				typeof(Patrol),
				typeof(AIBase),
				typeof(AILerp),
				typeof(AIPath),
				typeof(FollowerEntity),
				typeof(RichAI),
				typeof(Seeker),
				typeof(GraphUpdateScene),
				typeof(AnimationLink),
				typeof(AstarDebugger),
				typeof(GraphModifier),
				typeof(LocalSpaceGraph),
				typeof(NavmeshPrefab),
				typeof(NodeLink),
				typeof(NodeLink2),
				typeof(NodeLink3),
				typeof(RecastNavmeshModifier),
				typeof(AdvancedSmooth),
				typeof(AlternativePath),
				typeof(FunnelModifier),
				typeof(MonoModifier),
				typeof(RadiusModifier),
				typeof(RaycastModifier),
				typeof(SimpleSmoothModifier),
				typeof(NavmeshAdd),
				typeof(NavmeshClipper),
				typeof(NavmeshCut),
				typeof(BlockManager),
				typeof(SingleNodeBlocker),
				typeof(DynamicObstacle),
				typeof(ProceduralGraphMover),
				typeof(UnityReferenceHelper),
				typeof(RelevantGraphSurface),
				typeof(AgentCylinderShape),
				typeof(AgentMovementPlane),
				typeof(AgentMovementPlaneSource),
				typeof(AgentOffMeshLinkMovementDisabled),
				typeof(AgentOffMeshLinkTraversal),
				typeof(ManagedAgentOffMeshLinkTraversal),
				typeof(Pathfinding.ECS.AutoRepathPolicy),
				typeof(DestinationPoint),
				typeof(GravityState),
				typeof(ManagedMovementOverrideBeforeControl),
				typeof(ManagedMovementOverrideAfterControl),
				typeof(ManagedMovementOverrideBeforeMovement),
				typeof(ManagedState),
				typeof(MovementControl),
				typeof(MovementSettings),
				typeof(MovementState),
				typeof(MovementStatistics),
				typeof(PhysicsSceneRef),
				typeof(ReadyToTraverseOffMeshLink),
				typeof(ResolvedMovement),
				typeof(SearchState),
				typeof(SimulateMovement),
				typeof(SimulateMovementRepair),
				typeof(SimulateMovementControl),
				typeof(SimulateMovementFinalize),
				typeof(SyncPositionWithTransform),
				typeof(SyncRotationWithTransform),
				typeof(OrientationYAxisForward),
				typeof(AgentIndex),
				typeof(RVOAgent),
				typeof(BatchedEvents),
				typeof(RVOController),
				typeof(RVONavmesh),
				typeof(RVOObstacle),
				typeof(RVOSimulator),
				typeof(RVOSquareObstacle),
				typeof(LocalSpaceRichAI),
				typeof(TurnBasedAI),
				typeof(AnimationLinkTraverser)
			},
			TypeNames = new string[76]
			{
				"AstarPath", "Pathfinding.AIDestinationSetter", "Pathfinding.AIPathAlignedToSurface", "Pathfinding.MoveInCircle", "Pathfinding.Patrol", "Pathfinding.AIBase", "Pathfinding.AILerp", "Pathfinding.AIPath", "Pathfinding.FollowerEntity", "Pathfinding.RichAI",
				"Pathfinding.Seeker", "Pathfinding.GraphUpdateScene", "Pathfinding.AnimationLink", "Pathfinding.AstarDebugger", "Pathfinding.GraphModifier", "Pathfinding.LocalSpaceGraph", "Pathfinding.NavmeshPrefab", "Pathfinding.NodeLink", "Pathfinding.NodeLink2", "Pathfinding.NodeLink3",
				"Pathfinding.RecastNavmeshModifier", "Pathfinding.AdvancedSmooth", "Pathfinding.AlternativePath", "Pathfinding.FunnelModifier", "Pathfinding.MonoModifier", "Pathfinding.RadiusModifier", "Pathfinding.RaycastModifier", "Pathfinding.SimpleSmoothModifier", "Pathfinding.NavmeshAdd", "Pathfinding.NavmeshClipper",
				"Pathfinding.NavmeshCut", "Pathfinding.BlockManager", "Pathfinding.SingleNodeBlocker", "Pathfinding.DynamicObstacle", "Pathfinding.ProceduralGraphMover", "Pathfinding.UnityReferenceHelper", "Pathfinding.Graphs.Navmesh.RelevantGraphSurface", "Pathfinding.ECS.AgentCylinderShape", "Pathfinding.ECS.AgentMovementPlane", "Pathfinding.ECS.AgentMovementPlaneSource",
				"Pathfinding.ECS.AgentOffMeshLinkMovementDisabled", "Pathfinding.ECS.AgentOffMeshLinkTraversal", "Pathfinding.ECS.ManagedAgentOffMeshLinkTraversal", "Pathfinding.ECS.AutoRepathPolicy", "Pathfinding.ECS.DestinationPoint", "Pathfinding.ECS.GravityState", "Pathfinding.ECS.ManagedMovementOverrideBeforeControl", "Pathfinding.ECS.ManagedMovementOverrideAfterControl", "Pathfinding.ECS.ManagedMovementOverrideBeforeMovement", "Pathfinding.ECS.ManagedState",
				"Pathfinding.ECS.MovementControl", "Pathfinding.ECS.MovementSettings", "Pathfinding.ECS.MovementState", "Pathfinding.ECS.MovementStatistics", "Pathfinding.ECS.PhysicsSceneRef", "Pathfinding.ECS.ReadyToTraverseOffMeshLink", "Pathfinding.ECS.ResolvedMovement", "Pathfinding.ECS.SearchState", "Pathfinding.ECS.SimulateMovement", "Pathfinding.ECS.SimulateMovementRepair",
				"Pathfinding.ECS.SimulateMovementControl", "Pathfinding.ECS.SimulateMovementFinalize", "Pathfinding.ECS.SyncPositionWithTransform", "Pathfinding.ECS.SyncRotationWithTransform", "Pathfinding.ECS.OrientationYAxisForward", "Pathfinding.ECS.RVO.AgentIndex", "Pathfinding.ECS.RVO.RVOAgent", "Pathfinding.Util.BatchedEvents", "Pathfinding.RVO.RVOController", "Pathfinding.RVO.RVONavmesh",
				"Pathfinding.RVO.RVOObstacle", "Pathfinding.RVO.RVOSimulator", "Pathfinding.RVO.RVOSquareObstacle", "Pathfinding.Examples.LocalSpaceRichAI", "Pathfinding.Examples.TurnBasedAI", "Pathfinding.Examples.AnimationLinkTraverser"
			},
			EntityOffsetsPtr = null,
			EntityOffsetsCount = 0,
			BlobAssetReferenceOffsetsPtr = null,
			BlobAssetReferenceOffsetsCount = 0,
			UnityObjectReferenceOffsetsPtr = null,
			UnityObjectReferenceOffsetsCount = 0,
			WeakAssetReferenceOffsetsPtr = null,
			WeakAssetReferenceOffsetsCount = 0,
			WriteGroups = new Type[1] { typeof(ResolvedMovement) },
			SystemTypeInfosPtr = (TypeManager.SystemTypeInfo*)Unsafe.AsPointer(ref Value1),
			SystemAttributes = new TypeRegistry.SystemAttributeWithType[24]
			{
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateAfter,
					TargetSystemType = typeof(TransformSystemGroup),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateAfter,
					TargetSystemType = typeof(FollowerControlSystem),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateAfter,
					TargetSystemType = typeof(RVOSystem),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateAfter,
					TargetSystemType = typeof(FallbackResolveMovementSystem),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateInGroup,
					TargetSystemType = typeof(AIMovementSystemGroup),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.RequireMatchingQueriesForUpdate,
					TargetSystemType = null,
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateAfter,
					TargetSystemType = typeof(FollowerControlSystem),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateAfter,
					TargetSystemType = typeof(RVOSystem),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateInGroup,
					TargetSystemType = typeof(AIMovementSystemGroup),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.RequireMatchingQueriesForUpdate,
					TargetSystemType = null,
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateInGroup,
					TargetSystemType = typeof(AIMovementSystemGroup),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateBefore,
					TargetSystemType = typeof(RepairPathSystem),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateInGroup,
					TargetSystemType = typeof(AIMovementSystemGroup),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.RequireMatchingQueriesForUpdate,
					TargetSystemType = null,
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateInGroup,
					TargetSystemType = typeof(AIMovementSystemGroup),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateBefore,
					TargetSystemType = typeof(FollowerControlSystem),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateBefore,
					TargetSystemType = typeof(RepairPathSystem),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateInGroup,
					TargetSystemType = typeof(AIMovementSystemGroup),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.RequireMatchingQueriesForUpdate,
					TargetSystemType = null,
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateBefore,
					TargetSystemType = typeof(TransformSystemGroup),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateBefore,
					TargetSystemType = typeof(AIMovementSystemGroup),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateInGroup,
					TargetSystemType = typeof(SimulationSystemGroup),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateAfter,
					TargetSystemType = typeof(FollowerControlSystem),
					Flags = 0
				},
				new TypeRegistry.SystemAttributeWithType
				{
					Kind = TypeManager.SystemAttributeKind.UpdateInGroup,
					TargetSystemType = typeof(AIMovementSystemGroup),
					Flags = 0
				}
			},
			SystemTypes = new Type[10]
			{
				typeof(AIMovementSystemGroup),
				typeof(AIMoveSystem),
				typeof(FallbackResolveMovementSystem),
				typeof(FollowerControlSystem),
				typeof(MovementPlaneFromGraphSystem),
				typeof(PollPendingPathsSystem),
				typeof(RepairPathSystem),
				typeof(SyncDestinationTransformSystem),
				typeof(SyncTransformsToEntitiesSystem),
				typeof(RVOSystem)
			},
			SystemTypeNames = new string[10] { "Pathfinding.ECS.AIMovementSystemGroup", "Pathfinding.ECS.AIMoveSystem", "Pathfinding.ECS.FallbackResolveMovementSystem", "Pathfinding.ECS.FollowerControlSystem", "Pathfinding.ECS.MovementPlaneFromGraphSystem", "Pathfinding.ECS.PollPendingPathsSystem", "Pathfinding.ECS.RepairPathSystem", "Pathfinding.ECS.SyncDestinationTransformSystem", "Pathfinding.ECS.SyncTransformsToEntitiesSystem", "Pathfinding.ECS.RVO.RVOSystem" },
			SystemTypeSizes = new int[10] { 8, 2176, 96, 1024, 312, 416, 1424, 104, 200, 616 },
			SystemTypeHashes = new long[10]
			{
				BurstRuntime.GetHashCode64<AIMovementSystemGroup>(),
				BurstRuntime.GetHashCode64<AIMoveSystem>(),
				BurstRuntime.GetHashCode64<FallbackResolveMovementSystem>(),
				BurstRuntime.GetHashCode64<FollowerControlSystem>(),
				BurstRuntime.GetHashCode64<MovementPlaneFromGraphSystem>(),
				BurstRuntime.GetHashCode64<PollPendingPathsSystem>(),
				BurstRuntime.GetHashCode64<RepairPathSystem>(),
				BurstRuntime.GetHashCode64<SyncDestinationTransformSystem>(),
				BurstRuntime.GetHashCode64<SyncTransformsToEntitiesSystem>(),
				BurstRuntime.GetHashCode64<RVOSystem>()
			},
			SetSharedTypeIndices = SetSharedStaticTypeIndices
		};

		private static readonly ConstantData0 Value0/* Not supported: data(00 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF FF 94 20 A4 56 3A A8 92 FF 94 20 A4 56 3A A8 92 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 01 00 00 10 04 00 00 00 04 00 00 00 FF FF FF FF 17 AC D7 C1 17 54 F4 C4 17 AC D7 C1 17 54 F4 C4 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 02 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 31 B1 78 55 8E BE 80 5E 31 B1 78 55 8E BE 80 5E 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 03 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 8A DE 9F 38 7C 98 BF 0C 8A DE 9F 38 7C 98 BF 0C 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 04 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 5A C2 5E 62 AC 43 D8 6B 5A C2 5E 62 AC 43 D8 6B 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 05 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 3F EB B0 63 A0 C6 F4 39 3F EB B0 63 A0 C6 F4 39 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 06 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 45 D6 3E C3 BD E5 1D 86 45 D6 3E C3 BD E5 1D 86 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 07 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 1F BD 68 C1 59 02 F5 78 1F BD 68 C1 59 02 F5 78 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 08 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 57 83 21 26 2E 43 60 EA 57 83 21 26 2E 43 60 EA 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 09 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF F6 CA 19 82 1F 06 2C B8 F6 CA 19 82 1F 06 2C B8 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 0A 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 91 AB 7C 79 F2 28 75 A9 91 AB 7C 79 F2 28 75 A9 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 0B 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 75 59 6D 8E DD A3 B2 AD 75 59 6D 8E DD A3 B2 AD 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 0C 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 0C 8C 53 EF 44 96 D6 14 0C 8C 53 EF 44 96 D6 14 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 0D 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF EA 91 E5 9F 46 52 0C 6F EA 91 E5 9F 46 52 0C 6F 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 0E 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 9D CC E0 25 6F A4 50 AA 9D CC E0 25 6F A4 50 AA 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 0F 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 97 A6 8D 07 CD 23 76 0D 97 A6 8D 07 CD 23 76 0D 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 10 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 76 ED C9 F9 9E FA B4 FA 76 ED C9 F9 9E FA B4 FA 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 11 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 5E B8 BA 8A 97 71 4D AF 5E B8 BA 8A 97 71 4D AF 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 12 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF B8 4B AD 94 45 DA 1E C3 B8 4B AD 94 45 DA 1E C3 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 13 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF A5 A9 0A FB EB 43 6C E8 A5 A9 0A FB EB 43 6C E8 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 14 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 59 98 41 6C 75 5F 36 85 59 98 41 6C 75 5F 36 85 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 15 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 8A 7E 50 9C 0D 48 DA 81 8A 7E 50 9C 0D 48 DA 81 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 16 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF A0 E3 23 0B 3E 04 CD 8A A0 E3 23 0B 3E 04 CD 8A 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 17 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 17 E7 3C F3 71 B6 B5 70 17 E7 3C F3 71 B6 B5 70 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 18 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 1A 63 C4 CE B2 F0 2B F5 1A 63 C4 CE B2 F0 2B F5 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 19 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 01 61 A8 E9 7B ED 98 05 01 61 A8 E9 7B ED 98 05 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 1A 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 26 E3 E3 60 47 55 E2 5F 26 E3 E3 60 47 55 E2 5F 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 1B 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF E5 E2 0D FD 7C B3 D2 12 E5 E2 0D FD 7C B3 D2 12 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 1C 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 5D 8C 2C 01 C9 08 DB DF 5D 8C 2C 01 C9 08 DB DF 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 1D 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF E5 C6 11 53 DC D7 66 54 E5 C6 11 53 DC D7 66 54 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 1E 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 56 A2 7B 64 6C D4 09 99 56 A2 7B 64 6C D4 09 99 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 1F 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 90 CC 4E 8B BE 2C 21 56 90 CC 4E 8B BE 2C 21 56 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 20 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 22 76 FB 01 E3 A8 10 29 22 76 FB 01 E3 A8 10 29 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 21 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 4A 82 74 EB A4 E7 21 89 4A 82 74 EB A4 E7 21 89 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 22 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 98 29 69 E4 82 AE 17 76 98 29 69 E4 82 AE 17 76 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 23 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 90 15 EE 0A DE AF 2A F3 90 15 EE 0A DE AF 2A F3 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 24 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF B7 56 BB 90 F1 41 BD 1F B7 56 BB 90 F1 41 BD 1F 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 25 00 02 00 08 00 00 00 08 00 00 00 FF FF FF FF 7F AF 2B E7 37 E1 DB F1 7F AF 2B E7 37 E1 DB F1 00 00 00 00 00 00 00 00 08 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 08 00 00 00 26 00 02 00 10 00 00 00 10 00 00 00 FF FF FF FF 66 48 73 60 B7 6B 12 C5 66 48 73 60 B7 6B 12 C5 00 00 00 00 00 00 00 00 10 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 10 00 00 00 27 00 02 48 00 00 00 00 00 00 00 00 FF FF FF FF FC 83 CF F6 95 A7 4C DA FC 83 CF F6 95 A7 4C DA 00 00 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 01 00 00 00 28 00 02 41 00 00 00 00 00 00 00 00 FF FF FF FF E9 EC 70 44 96 0F 54 17 E9 EC 70 44 96 0F 54 17 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 01 00 00 00 29 00 02 00 1C 00 00 00 1C 00 00 00 FF FF FF FF 24 E7 EA F3 30 66 5E 10 24 E7 EA F3 30 66 5E 10 00 00 00 00 00 00 00 00 10 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 1C 00 00 00 2A 00 02 12 04 00 00 00 04 00 00 00 FF FF FF FF 01 C6 0F 06 D2 88 46 BB 01 C6 0F 06 D2 88 46 BB 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 2B 00 02 00 18 00 00 00 18 00 00 00 FF FF FF FF 74 C7 B0 B8 16 0B 66 92 74 C7 B0 B8 16 0B 66 92 00 00 00 00 00 00 00 00 10 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 18 00 00 00 2C 00 02 00 18 00 00 00 18 00 00 00 FF FF FF FF B5 24 6B 2B C8 B6 58 E0 B5 24 6B 2B C8 B6 58 E0 00 00 00 00 00 00 00 00 10 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 18 00 00 00 2D 00 02 01 04 00 00 00 04 00 00 00 FF FF FF FF E8 8C B3 6E 4D 73 3B 29 E8 8C B3 6E 4D 73 3B 29 00 00 00 00 00 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 04 00 00 00 2E 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF E7 72 03 9B 3E 9E 29 49 E7 72 03 9B 3E 9E 29 49 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 2F 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 9E 8F 29 40 BA 7C FC EF 9E 8F 29 40 BA 7C FC EF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 30 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 43 94 BF 20 F9 51 54 28 43 94 BF 20 F9 51 54 28 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 31 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF DD B4 C2 01 FB 1D 8E B3 DD B4 C2 01 FB 1D 8E B3 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 32 00 02 00 38 00 00 00 38 00 00 00 FF FF FF FF 7F DF 3B 1B 3E 77 BA 4F 7F DF 3B 1B 3E 77 BA 4F 00 00 00 00 00 00 00 00 10 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 38 00 00 00 33 00 02 00 3C 00 00 00 3C 00 00 00 FF FF FF FF D8 28 15 1A EE 96 A8 BC D8 28 15 1A EE 96 A8 BC 00 00 00 00 00 00 00 00 10 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 3C 00 00 00 34 00 02 00 48 00 00 00 48 00 00 00 FF FF FF FF B3 3B F8 74 18 B2 07 7E B3 3B F8 74 18 B2 07 7E 00 00 00 00 00 00 00 00 10 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 48 00 00 00 35 00 02 00 18 00 00 00 18 00 00 00 FF FF FF FF E3 0D E7 CD BD FA D0 7A E3 0D E7 CD BD FA D0 7A 00 00 00 00 00 00 00 00 10 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 18 00 00 00 36 00 82 48 00 00 00 00 00 00 00 00 FF FF FF FF 9A C2 4F E9 9C 6A DA B9 9A C2 4F E9 9C 6A DA B9 00 00 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 08 00 00 00 37 00 02 41 00 00 00 00 00 00 00 00 FF FF FF FF 77 01 E9 AF 61 F1 26 74 77 01 E9 AF 61 F1 26 74 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 01 00 00 00 38 00 02 00 24 00 00 00 24 00 00 00 FF FF FF FF ED DD 2D E2 39 8D 52 94 ED DD 2D E2 39 8D 52 94 00 00 00 00 00 00 00 00 10 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 24 00 00 00 39 00 02 40 00 00 00 00 00 00 00 00 FF FF FF FF 6E 9D 2A 16 12 BA 27 AC 6E 9D 2A 16 12 BA 27 AC 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 01 00 00 00 3A 00 02 40 00 00 00 00 00 00 00 00 FF FF FF FF D2 A4 43 54 2B F1 55 8B D2 A4 43 54 2B F1 55 8B 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 01 00 00 00 3B 00 02 40 00 00 00 00 00 00 00 00 FF FF FF FF E3 F6 E1 7D CF 2B 63 01 E3 F6 E1 7D CF 2B 63 01 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 01 00 00 00 3C 00 02 40 00 00 00 00 00 00 00 00 FF FF FF FF 1D EA 02 F3 DA 86 2D 54 1D EA 02 F3 DA 86 2D 54 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 01 00 00 00 3D 00 02 40 00 00 00 00 00 00 00 00 FF FF FF FF 3C 61 39 07 F6 36 88 1A 3C 61 39 07 F6 36 88 1A 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 01 00 00 00 3E 00 02 40 00 00 00 00 00 00 00 00 FF FF FF FF D3 17 ED 06 B0 0F AA EC D3 17 ED 06 B0 0F AA EC 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 01 00 00 00 3F 00 02 40 00 00 00 00 00 00 00 00 FF FF FF FF 6A 7C 47 51 C0 5B 6E 13 6A 7C 47 51 C0 5B 6E 13 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 01 00 00 00 40 00 02 40 00 00 00 00 00 00 00 00 FF FF FF FF 34 EA 83 70 26 45 BE 72 34 EA 83 70 26 45 BE 72 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 01 00 00 00 41 00 02 02 04 00 00 00 04 00 00 00 FF FF FF FF 07 D3 52 11 6D 3C 55 31 07 D3 52 11 6D 3C 55 31 00 00 00 00 00 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 80 00 00 00 04 00 00 00 42 00 02 00 24 00 00 00 24 00 00 00 FF FF FF FF D1 A4 EC A5 2B B1 2F 28 D1 A4 EC A5 2B B1 2F 28 00 00 00 00 00 00 00 00 10 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 24 00 00 00 43 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 52 88 A1 9C BE 14 E6 8F 52 88 A1 9C BE 14 E6 8F 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 44 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 9E 18 8E 48 BD 99 10 25 9E 18 8E 48 BD 99 10 25 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 45 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF FC 4D 43 19 EE 78 43 DA FC 4D 43 19 EE 78 43 DA 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 46 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF C7 B8 D0 78 AF 60 9C 21 C7 B8 D0 78 AF 60 9C 21 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 47 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 48 58 1B 14 26 08 79 6E 48 58 1B 14 26 08 79 6E 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 48 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF 42 E7 AD 12 1D 90 9D B4 42 E7 AD 12 1D 90 9D B4 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 49 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF FC 46 1E 64 68 60 B2 36 FC 46 1E 64 68 60 B2 36 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 4A 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF CD C6 C9 81 11 D5 C7 D1 CD C6 C9 81 11 D5 C7 D1 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 4B 00 02 10 04 00 00 00 04 00 00 00 FF FF FF FF CD D3 55 27 1A A5 2F D5 CD D3 55 27 1A A5 2F D5 00 00 00 00 00 00 00 00 04 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00) */;

		private static readonly ConstantData1 Value1/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 60 00 07 00 00 00 00 00 00 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 07 00 00 01 00 00 00 05 00 00 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 07 00 00 06 00 00 00 04 00 00 00 03 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 07 00 00 0A 00 00 00 01 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 07 00 00 0B 00 00 00 03 00 00 00 05 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 07 00 00 0E 00 00 00 00 00 00 00 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 07 00 00 0E 00 00 00 02 00 00 00 07 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 07 00 00 10 00 00 00 03 00 00 00 08 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 07 00 00 13 00 00 00 03 00 00 00 09 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 07 00 00 16 00 00 00 02 00 00 00) */;

		public unsafe static bool Equals(object lhs, object rhs, int typeIndex)
		{
			return typeIndex switch
			{
				0 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AstarPath)lhs), Unsafe.AsPointer(ref (AstarPath)rhs), 0L) == 0, 
				1 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AIDestinationSetter)lhs), Unsafe.AsPointer(ref (AIDestinationSetter)rhs), 0L) == 0, 
				2 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AIPathAlignedToSurface)lhs), Unsafe.AsPointer(ref (AIPathAlignedToSurface)rhs), 0L) == 0, 
				3 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (MoveInCircle)lhs), Unsafe.AsPointer(ref (MoveInCircle)rhs), 0L) == 0, 
				4 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (Patrol)lhs), Unsafe.AsPointer(ref (Patrol)rhs), 0L) == 0, 
				5 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AIBase)lhs), Unsafe.AsPointer(ref (AIBase)rhs), 0L) == 0, 
				6 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AILerp)lhs), Unsafe.AsPointer(ref (AILerp)rhs), 0L) == 0, 
				7 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AIPath)lhs), Unsafe.AsPointer(ref (AIPath)rhs), 0L) == 0, 
				8 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (FollowerEntity)lhs), Unsafe.AsPointer(ref (FollowerEntity)rhs), 0L) == 0, 
				9 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RichAI)lhs), Unsafe.AsPointer(ref (RichAI)rhs), 0L) == 0, 
				10 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (Seeker)lhs), Unsafe.AsPointer(ref (Seeker)rhs), 0L) == 0, 
				11 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (GraphUpdateScene)lhs), Unsafe.AsPointer(ref (GraphUpdateScene)rhs), 0L) == 0, 
				12 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AnimationLink)lhs), Unsafe.AsPointer(ref (AnimationLink)rhs), 0L) == 0, 
				13 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AstarDebugger)lhs), Unsafe.AsPointer(ref (AstarDebugger)rhs), 0L) == 0, 
				14 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (GraphModifier)lhs), Unsafe.AsPointer(ref (GraphModifier)rhs), 0L) == 0, 
				15 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (LocalSpaceGraph)lhs), Unsafe.AsPointer(ref (LocalSpaceGraph)rhs), 0L) == 0, 
				16 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NavmeshPrefab)lhs), Unsafe.AsPointer(ref (NavmeshPrefab)rhs), 0L) == 0, 
				17 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NodeLink)lhs), Unsafe.AsPointer(ref (NodeLink)rhs), 0L) == 0, 
				18 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NodeLink2)lhs), Unsafe.AsPointer(ref (NodeLink2)rhs), 0L) == 0, 
				19 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NodeLink3)lhs), Unsafe.AsPointer(ref (NodeLink3)rhs), 0L) == 0, 
				20 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RecastNavmeshModifier)lhs), Unsafe.AsPointer(ref (RecastNavmeshModifier)rhs), 0L) == 0, 
				21 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AdvancedSmooth)lhs), Unsafe.AsPointer(ref (AdvancedSmooth)rhs), 0L) == 0, 
				22 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AlternativePath)lhs), Unsafe.AsPointer(ref (AlternativePath)rhs), 0L) == 0, 
				23 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (FunnelModifier)lhs), Unsafe.AsPointer(ref (FunnelModifier)rhs), 0L) == 0, 
				24 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (MonoModifier)lhs), Unsafe.AsPointer(ref (MonoModifier)rhs), 0L) == 0, 
				25 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RadiusModifier)lhs), Unsafe.AsPointer(ref (RadiusModifier)rhs), 0L) == 0, 
				26 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RaycastModifier)lhs), Unsafe.AsPointer(ref (RaycastModifier)rhs), 0L) == 0, 
				27 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SimpleSmoothModifier)lhs), Unsafe.AsPointer(ref (SimpleSmoothModifier)rhs), 0L) == 0, 
				28 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NavmeshAdd)lhs), Unsafe.AsPointer(ref (NavmeshAdd)rhs), 0L) == 0, 
				29 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NavmeshClipper)lhs), Unsafe.AsPointer(ref (NavmeshClipper)rhs), 0L) == 0, 
				30 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NavmeshCut)lhs), Unsafe.AsPointer(ref (NavmeshCut)rhs), 0L) == 0, 
				31 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (BlockManager)lhs), Unsafe.AsPointer(ref (BlockManager)rhs), 0L) == 0, 
				32 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SingleNodeBlocker)lhs), Unsafe.AsPointer(ref (SingleNodeBlocker)rhs), 0L) == 0, 
				33 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (DynamicObstacle)lhs), Unsafe.AsPointer(ref (DynamicObstacle)rhs), 0L) == 0, 
				34 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ProceduralGraphMover)lhs), Unsafe.AsPointer(ref (ProceduralGraphMover)rhs), 0L) == 0, 
				35 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (UnityReferenceHelper)lhs), Unsafe.AsPointer(ref (UnityReferenceHelper)rhs), 0L) == 0, 
				36 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RelevantGraphSurface)lhs), Unsafe.AsPointer(ref (RelevantGraphSurface)rhs), 0L) == 0, 
				37 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AgentCylinderShape)lhs), Unsafe.AsPointer(ref (AgentCylinderShape)rhs), 8L) == 0, 
				38 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AgentMovementPlane)lhs), Unsafe.AsPointer(ref (AgentMovementPlane)rhs), 16L) == 0, 
				39 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AgentMovementPlaneSource)lhs), Unsafe.AsPointer(ref (AgentMovementPlaneSource)rhs), 1L) == 0, 
				40 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AgentOffMeshLinkMovementDisabled)lhs), Unsafe.AsPointer(ref (AgentOffMeshLinkMovementDisabled)rhs), 1L) == 0, 
				41 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AgentOffMeshLinkTraversal)lhs), Unsafe.AsPointer(ref (AgentOffMeshLinkTraversal)rhs), 28L) == 0, 
				42 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ManagedAgentOffMeshLinkTraversal)lhs), Unsafe.AsPointer(ref (ManagedAgentOffMeshLinkTraversal)rhs), 0L) == 0, 
				43 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (Pathfinding.ECS.AutoRepathPolicy)lhs), Unsafe.AsPointer(ref (Pathfinding.ECS.AutoRepathPolicy)rhs), 24L) == 0, 
				44 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (DestinationPoint)lhs), Unsafe.AsPointer(ref (DestinationPoint)rhs), 24L) == 0, 
				45 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (GravityState)lhs), Unsafe.AsPointer(ref (GravityState)rhs), 4L) == 0, 
				46 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ManagedMovementOverrideBeforeControl)lhs), Unsafe.AsPointer(ref (ManagedMovementOverrideBeforeControl)rhs), 0L) == 0, 
				47 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ManagedMovementOverrideAfterControl)lhs), Unsafe.AsPointer(ref (ManagedMovementOverrideAfterControl)rhs), 0L) == 0, 
				48 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ManagedMovementOverrideBeforeMovement)lhs), Unsafe.AsPointer(ref (ManagedMovementOverrideBeforeMovement)rhs), 0L) == 0, 
				49 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ManagedState)lhs), Unsafe.AsPointer(ref (ManagedState)rhs), 0L) == 0, 
				50 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (MovementControl)lhs), Unsafe.AsPointer(ref (MovementControl)rhs), 56L) == 0, 
				51 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (MovementSettings)lhs), Unsafe.AsPointer(ref (MovementSettings)rhs), 60L) == 0, 
				52 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (MovementState)lhs), Unsafe.AsPointer(ref (MovementState)rhs), 72L) == 0, 
				53 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (MovementStatistics)lhs), Unsafe.AsPointer(ref (MovementStatistics)rhs), 24L) == 0, 
				54 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (PhysicsSceneRef)lhs), Unsafe.AsPointer(ref (PhysicsSceneRef)rhs), 8L) == 0, 
				55 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ReadyToTraverseOffMeshLink)lhs), Unsafe.AsPointer(ref (ReadyToTraverseOffMeshLink)rhs), 1L) == 0, 
				56 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ResolvedMovement)lhs), Unsafe.AsPointer(ref (ResolvedMovement)rhs), 36L) == 0, 
				57 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SearchState)lhs), Unsafe.AsPointer(ref (SearchState)rhs), 1L) == 0, 
				58 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SimulateMovement)lhs), Unsafe.AsPointer(ref (SimulateMovement)rhs), 1L) == 0, 
				59 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SimulateMovementRepair)lhs), Unsafe.AsPointer(ref (SimulateMovementRepair)rhs), 1L) == 0, 
				60 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SimulateMovementControl)lhs), Unsafe.AsPointer(ref (SimulateMovementControl)rhs), 1L) == 0, 
				61 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SimulateMovementFinalize)lhs), Unsafe.AsPointer(ref (SimulateMovementFinalize)rhs), 1L) == 0, 
				62 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SyncPositionWithTransform)lhs), Unsafe.AsPointer(ref (SyncPositionWithTransform)rhs), 1L) == 0, 
				63 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SyncRotationWithTransform)lhs), Unsafe.AsPointer(ref (SyncRotationWithTransform)rhs), 1L) == 0, 
				64 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (OrientationYAxisForward)lhs), Unsafe.AsPointer(ref (OrientationYAxisForward)rhs), 1L) == 0, 
				65 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AgentIndex)lhs), Unsafe.AsPointer(ref (AgentIndex)rhs), 4L) == 0, 
				66 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RVOAgent)lhs), Unsafe.AsPointer(ref (RVOAgent)rhs), 36L) == 0, 
				67 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (BatchedEvents)lhs), Unsafe.AsPointer(ref (BatchedEvents)rhs), 0L) == 0, 
				68 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RVOController)lhs), Unsafe.AsPointer(ref (RVOController)rhs), 0L) == 0, 
				69 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RVONavmesh)lhs), Unsafe.AsPointer(ref (RVONavmesh)rhs), 0L) == 0, 
				70 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RVOObstacle)lhs), Unsafe.AsPointer(ref (RVOObstacle)rhs), 0L) == 0, 
				71 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RVOSimulator)lhs), Unsafe.AsPointer(ref (RVOSimulator)rhs), 0L) == 0, 
				72 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RVOSquareObstacle)lhs), Unsafe.AsPointer(ref (RVOSquareObstacle)rhs), 0L) == 0, 
				73 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (LocalSpaceRichAI)lhs), Unsafe.AsPointer(ref (LocalSpaceRichAI)rhs), 0L) == 0, 
				74 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (TurnBasedAI)lhs), Unsafe.AsPointer(ref (TurnBasedAI)rhs), 0L) == 0, 
				75 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AnimationLinkTraverser)lhs), Unsafe.AsPointer(ref (AnimationLinkTraverser)rhs), 0L) == 0, 
				_ => throw new NotSupportedException("FATAL: Tried to call TypeManager.Equals() for a component type unknown to the static TypeRegistry"), 
			};
		}

		public unsafe static bool Equals(object lhs, void* rhs, int typeIndex)
		{
			return typeIndex switch
			{
				0 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AstarPath)lhs), rhs, 0L) == 0, 
				1 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AIDestinationSetter)lhs), rhs, 0L) == 0, 
				2 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AIPathAlignedToSurface)lhs), rhs, 0L) == 0, 
				3 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (MoveInCircle)lhs), rhs, 0L) == 0, 
				4 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (Patrol)lhs), rhs, 0L) == 0, 
				5 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AIBase)lhs), rhs, 0L) == 0, 
				6 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AILerp)lhs), rhs, 0L) == 0, 
				7 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AIPath)lhs), rhs, 0L) == 0, 
				8 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (FollowerEntity)lhs), rhs, 0L) == 0, 
				9 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RichAI)lhs), rhs, 0L) == 0, 
				10 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (Seeker)lhs), rhs, 0L) == 0, 
				11 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (GraphUpdateScene)lhs), rhs, 0L) == 0, 
				12 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AnimationLink)lhs), rhs, 0L) == 0, 
				13 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AstarDebugger)lhs), rhs, 0L) == 0, 
				14 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (GraphModifier)lhs), rhs, 0L) == 0, 
				15 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (LocalSpaceGraph)lhs), rhs, 0L) == 0, 
				16 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NavmeshPrefab)lhs), rhs, 0L) == 0, 
				17 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NodeLink)lhs), rhs, 0L) == 0, 
				18 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NodeLink2)lhs), rhs, 0L) == 0, 
				19 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NodeLink3)lhs), rhs, 0L) == 0, 
				20 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RecastNavmeshModifier)lhs), rhs, 0L) == 0, 
				21 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AdvancedSmooth)lhs), rhs, 0L) == 0, 
				22 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AlternativePath)lhs), rhs, 0L) == 0, 
				23 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (FunnelModifier)lhs), rhs, 0L) == 0, 
				24 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (MonoModifier)lhs), rhs, 0L) == 0, 
				25 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RadiusModifier)lhs), rhs, 0L) == 0, 
				26 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RaycastModifier)lhs), rhs, 0L) == 0, 
				27 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SimpleSmoothModifier)lhs), rhs, 0L) == 0, 
				28 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NavmeshAdd)lhs), rhs, 0L) == 0, 
				29 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NavmeshClipper)lhs), rhs, 0L) == 0, 
				30 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (NavmeshCut)lhs), rhs, 0L) == 0, 
				31 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (BlockManager)lhs), rhs, 0L) == 0, 
				32 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SingleNodeBlocker)lhs), rhs, 0L) == 0, 
				33 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (DynamicObstacle)lhs), rhs, 0L) == 0, 
				34 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ProceduralGraphMover)lhs), rhs, 0L) == 0, 
				35 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (UnityReferenceHelper)lhs), rhs, 0L) == 0, 
				36 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RelevantGraphSurface)lhs), rhs, 0L) == 0, 
				37 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AgentCylinderShape)lhs), rhs, 8L) == 0, 
				38 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AgentMovementPlane)lhs), rhs, 16L) == 0, 
				39 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AgentMovementPlaneSource)lhs), rhs, 1L) == 0, 
				40 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AgentOffMeshLinkMovementDisabled)lhs), rhs, 1L) == 0, 
				41 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AgentOffMeshLinkTraversal)lhs), rhs, 28L) == 0, 
				42 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ManagedAgentOffMeshLinkTraversal)lhs), rhs, 0L) == 0, 
				43 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (Pathfinding.ECS.AutoRepathPolicy)lhs), rhs, 24L) == 0, 
				44 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (DestinationPoint)lhs), rhs, 24L) == 0, 
				45 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (GravityState)lhs), rhs, 4L) == 0, 
				46 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ManagedMovementOverrideBeforeControl)lhs), rhs, 0L) == 0, 
				47 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ManagedMovementOverrideAfterControl)lhs), rhs, 0L) == 0, 
				48 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ManagedMovementOverrideBeforeMovement)lhs), rhs, 0L) == 0, 
				49 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ManagedState)lhs), rhs, 0L) == 0, 
				50 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (MovementControl)lhs), rhs, 56L) == 0, 
				51 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (MovementSettings)lhs), rhs, 60L) == 0, 
				52 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (MovementState)lhs), rhs, 72L) == 0, 
				53 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (MovementStatistics)lhs), rhs, 24L) == 0, 
				54 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (PhysicsSceneRef)lhs), rhs, 8L) == 0, 
				55 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ReadyToTraverseOffMeshLink)lhs), rhs, 1L) == 0, 
				56 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (ResolvedMovement)lhs), rhs, 36L) == 0, 
				57 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SearchState)lhs), rhs, 1L) == 0, 
				58 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SimulateMovement)lhs), rhs, 1L) == 0, 
				59 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SimulateMovementRepair)lhs), rhs, 1L) == 0, 
				60 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SimulateMovementControl)lhs), rhs, 1L) == 0, 
				61 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SimulateMovementFinalize)lhs), rhs, 1L) == 0, 
				62 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SyncPositionWithTransform)lhs), rhs, 1L) == 0, 
				63 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (SyncRotationWithTransform)lhs), rhs, 1L) == 0, 
				64 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (OrientationYAxisForward)lhs), rhs, 1L) == 0, 
				65 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AgentIndex)lhs), rhs, 4L) == 0, 
				66 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RVOAgent)lhs), rhs, 36L) == 0, 
				67 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (BatchedEvents)lhs), rhs, 0L) == 0, 
				68 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RVOController)lhs), rhs, 0L) == 0, 
				69 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RVONavmesh)lhs), rhs, 0L) == 0, 
				70 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RVOObstacle)lhs), rhs, 0L) == 0, 
				71 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RVOSimulator)lhs), rhs, 0L) == 0, 
				72 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (RVOSquareObstacle)lhs), rhs, 0L) == 0, 
				73 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (LocalSpaceRichAI)lhs), rhs, 0L) == 0, 
				74 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (TurnBasedAI)lhs), rhs, 0L) == 0, 
				75 => UnsafeUtility.MemCmp(Unsafe.AsPointer(ref (AnimationLinkTraverser)lhs), rhs, 0L) == 0, 
				_ => throw new NotSupportedException("FATAL: Tried to call TypeManager.Equals() for a component type unknown to the static TypeRegistry"), 
			};
		}

		public unsafe static int BoxedGetHashCode(object val, int typeIndex)
		{
			return typeIndex switch
			{
				0 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AstarPath)val), 0), 
				1 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AIDestinationSetter)val), 0), 
				2 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AIPathAlignedToSurface)val), 0), 
				3 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (MoveInCircle)val), 0), 
				4 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (Patrol)val), 0), 
				5 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AIBase)val), 0), 
				6 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AILerp)val), 0), 
				7 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AIPath)val), 0), 
				8 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (FollowerEntity)val), 0), 
				9 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (RichAI)val), 0), 
				10 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (Seeker)val), 0), 
				11 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (GraphUpdateScene)val), 0), 
				12 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AnimationLink)val), 0), 
				13 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AstarDebugger)val), 0), 
				14 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (GraphModifier)val), 0), 
				15 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (LocalSpaceGraph)val), 0), 
				16 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (NavmeshPrefab)val), 0), 
				17 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (NodeLink)val), 0), 
				18 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (NodeLink2)val), 0), 
				19 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (NodeLink3)val), 0), 
				20 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (RecastNavmeshModifier)val), 0), 
				21 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AdvancedSmooth)val), 0), 
				22 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AlternativePath)val), 0), 
				23 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (FunnelModifier)val), 0), 
				24 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (MonoModifier)val), 0), 
				25 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (RadiusModifier)val), 0), 
				26 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (RaycastModifier)val), 0), 
				27 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (SimpleSmoothModifier)val), 0), 
				28 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (NavmeshAdd)val), 0), 
				29 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (NavmeshClipper)val), 0), 
				30 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (NavmeshCut)val), 0), 
				31 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (BlockManager)val), 0), 
				32 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (SingleNodeBlocker)val), 0), 
				33 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (DynamicObstacle)val), 0), 
				34 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (ProceduralGraphMover)val), 0), 
				35 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (UnityReferenceHelper)val), 0), 
				36 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (RelevantGraphSurface)val), 0), 
				37 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AgentCylinderShape)val), 8), 
				38 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AgentMovementPlane)val), 16), 
				39 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AgentMovementPlaneSource)val), 1), 
				40 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AgentOffMeshLinkMovementDisabled)val), 1), 
				41 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AgentOffMeshLinkTraversal)val), 28), 
				42 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (ManagedAgentOffMeshLinkTraversal)val), 0), 
				43 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (Pathfinding.ECS.AutoRepathPolicy)val), 24), 
				44 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (DestinationPoint)val), 24), 
				45 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (GravityState)val), 4), 
				46 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (ManagedMovementOverrideBeforeControl)val), 0), 
				47 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (ManagedMovementOverrideAfterControl)val), 0), 
				48 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (ManagedMovementOverrideBeforeMovement)val), 0), 
				49 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (ManagedState)val), 0), 
				50 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (MovementControl)val), 56), 
				51 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (MovementSettings)val), 60), 
				52 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (MovementState)val), 72), 
				53 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (MovementStatistics)val), 24), 
				54 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (PhysicsSceneRef)val), 8), 
				55 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (ReadyToTraverseOffMeshLink)val), 1), 
				56 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (ResolvedMovement)val), 36), 
				57 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (SearchState)val), 1), 
				58 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (SimulateMovement)val), 1), 
				59 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (SimulateMovementRepair)val), 1), 
				60 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (SimulateMovementControl)val), 1), 
				61 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (SimulateMovementFinalize)val), 1), 
				62 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (SyncPositionWithTransform)val), 1), 
				63 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (SyncRotationWithTransform)val), 1), 
				64 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (OrientationYAxisForward)val), 1), 
				65 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AgentIndex)val), 4), 
				66 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (RVOAgent)val), 36), 
				67 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (BatchedEvents)val), 0), 
				68 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (RVOController)val), 0), 
				69 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (RVONavmesh)val), 0), 
				70 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (RVOObstacle)val), 0), 
				71 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (RVOSimulator)val), 0), 
				72 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (RVOSquareObstacle)val), 0), 
				73 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (LocalSpaceRichAI)val), 0), 
				74 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (TurnBasedAI)val), 0), 
				75 => (int)XXHash.Hash32((byte*)Unsafe.AsPointer(ref (AnimationLinkTraverser)val), 0), 
				_ => throw new NotSupportedException("FATAL: Tried to call TypeManager.GetHashCode() for a component type unknown to the static TypeRegistry"), 
			};
		}

		public unsafe static void SetSharedStaticTypeIndices(int* pTypeInfos, int count)
		{
			if (count != 76)
			{
				throw new ArgumentException("The passed in 'count' does not match the expected count of '76' component types");
			}
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AstarPath>.Ref.Data) = *(int*)((byte*)pTypeInfos + 0 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AIDestinationSetter>.Ref.Data) = *(int*)((byte*)pTypeInfos + 1 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AIPathAlignedToSurface>.Ref.Data) = *(int*)((byte*)pTypeInfos + 2 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<MoveInCircle>.Ref.Data) = *(int*)((byte*)pTypeInfos + 3 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<Patrol>.Ref.Data) = *(int*)((byte*)pTypeInfos + 4 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AIBase>.Ref.Data) = *(int*)((byte*)pTypeInfos + 5 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AILerp>.Ref.Data) = *(int*)((byte*)pTypeInfos + 6 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AIPath>.Ref.Data) = *(int*)((byte*)pTypeInfos + 7 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<FollowerEntity>.Ref.Data) = *(int*)((byte*)pTypeInfos + 8 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<RichAI>.Ref.Data) = *(int*)((byte*)pTypeInfos + 9 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<Seeker>.Ref.Data) = *(int*)((byte*)pTypeInfos + 10 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<GraphUpdateScene>.Ref.Data) = *(int*)((byte*)pTypeInfos + 11 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AnimationLink>.Ref.Data) = *(int*)((byte*)pTypeInfos + 12 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AstarDebugger>.Ref.Data) = *(int*)((byte*)pTypeInfos + 13 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<GraphModifier>.Ref.Data) = *(int*)((byte*)pTypeInfos + 14 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<LocalSpaceGraph>.Ref.Data) = *(int*)((byte*)pTypeInfos + 15 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<NavmeshPrefab>.Ref.Data) = *(int*)((byte*)pTypeInfos + 16 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<NodeLink>.Ref.Data) = *(int*)((byte*)pTypeInfos + 17 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<NodeLink2>.Ref.Data) = *(int*)((byte*)pTypeInfos + 18 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<NodeLink3>.Ref.Data) = *(int*)((byte*)pTypeInfos + 19 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<RecastNavmeshModifier>.Ref.Data) = *(int*)((byte*)pTypeInfos + 20 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AdvancedSmooth>.Ref.Data) = *(int*)((byte*)pTypeInfos + 21 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AlternativePath>.Ref.Data) = *(int*)((byte*)pTypeInfos + 22 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<FunnelModifier>.Ref.Data) = *(int*)((byte*)pTypeInfos + 23 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<MonoModifier>.Ref.Data) = *(int*)((byte*)pTypeInfos + 24 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<RadiusModifier>.Ref.Data) = *(int*)((byte*)pTypeInfos + 25 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<RaycastModifier>.Ref.Data) = *(int*)((byte*)pTypeInfos + 26 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<SimpleSmoothModifier>.Ref.Data) = *(int*)((byte*)pTypeInfos + 27 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<NavmeshAdd>.Ref.Data) = *(int*)((byte*)pTypeInfos + 28 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<NavmeshClipper>.Ref.Data) = *(int*)((byte*)pTypeInfos + 29 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<NavmeshCut>.Ref.Data) = *(int*)((byte*)pTypeInfos + 30 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<BlockManager>.Ref.Data) = *(int*)((byte*)pTypeInfos + 31 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<SingleNodeBlocker>.Ref.Data) = *(int*)((byte*)pTypeInfos + 32 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<DynamicObstacle>.Ref.Data) = *(int*)((byte*)pTypeInfos + 33 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<ProceduralGraphMover>.Ref.Data) = *(int*)((byte*)pTypeInfos + 34 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<UnityReferenceHelper>.Ref.Data) = *(int*)((byte*)pTypeInfos + 35 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<RelevantGraphSurface>.Ref.Data) = *(int*)((byte*)pTypeInfos + 36 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AgentCylinderShape>.Ref.Data) = *(int*)((byte*)pTypeInfos + 37 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AgentMovementPlane>.Ref.Data) = *(int*)((byte*)pTypeInfos + 38 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AgentMovementPlaneSource>.Ref.Data) = *(int*)((byte*)pTypeInfos + 39 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AgentOffMeshLinkMovementDisabled>.Ref.Data) = *(int*)((byte*)pTypeInfos + 40 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AgentOffMeshLinkTraversal>.Ref.Data) = *(int*)((byte*)pTypeInfos + 41 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<ManagedAgentOffMeshLinkTraversal>.Ref.Data) = *(int*)((byte*)pTypeInfos + 42 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<Pathfinding.ECS.AutoRepathPolicy>.Ref.Data) = *(int*)((byte*)pTypeInfos + 43 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<DestinationPoint>.Ref.Data) = *(int*)((byte*)pTypeInfos + 44 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<GravityState>.Ref.Data) = *(int*)((byte*)pTypeInfos + 45 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<ManagedMovementOverrideBeforeControl>.Ref.Data) = *(int*)((byte*)pTypeInfos + 46 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<ManagedMovementOverrideAfterControl>.Ref.Data) = *(int*)((byte*)pTypeInfos + 47 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<ManagedMovementOverrideBeforeMovement>.Ref.Data) = *(int*)((byte*)pTypeInfos + 48 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<ManagedState>.Ref.Data) = *(int*)((byte*)pTypeInfos + 49 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<MovementControl>.Ref.Data) = *(int*)((byte*)pTypeInfos + 50 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<MovementSettings>.Ref.Data) = *(int*)((byte*)pTypeInfos + 51 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<MovementState>.Ref.Data) = *(int*)((byte*)pTypeInfos + 52 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<MovementStatistics>.Ref.Data) = *(int*)((byte*)pTypeInfos + 53 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<PhysicsSceneRef>.Ref.Data) = *(int*)((byte*)pTypeInfos + 54 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<ReadyToTraverseOffMeshLink>.Ref.Data) = *(int*)((byte*)pTypeInfos + 55 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<ResolvedMovement>.Ref.Data) = *(int*)((byte*)pTypeInfos + 56 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<SearchState>.Ref.Data) = *(int*)((byte*)pTypeInfos + 57 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<SimulateMovement>.Ref.Data) = *(int*)((byte*)pTypeInfos + 58 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<SimulateMovementRepair>.Ref.Data) = *(int*)((byte*)pTypeInfos + 59 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<SimulateMovementControl>.Ref.Data) = *(int*)((byte*)pTypeInfos + 60 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<SimulateMovementFinalize>.Ref.Data) = *(int*)((byte*)pTypeInfos + 61 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<SyncPositionWithTransform>.Ref.Data) = *(int*)((byte*)pTypeInfos + 62 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<SyncRotationWithTransform>.Ref.Data) = *(int*)((byte*)pTypeInfos + 63 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<OrientationYAxisForward>.Ref.Data) = *(int*)((byte*)pTypeInfos + 64 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AgentIndex>.Ref.Data) = *(int*)((byte*)pTypeInfos + 65 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<RVOAgent>.Ref.Data) = *(int*)((byte*)pTypeInfos + 66 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<BatchedEvents>.Ref.Data) = *(int*)((byte*)pTypeInfos + 67 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<RVOController>.Ref.Data) = *(int*)((byte*)pTypeInfos + 68 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<RVONavmesh>.Ref.Data) = *(int*)((byte*)pTypeInfos + 69 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<RVOObstacle>.Ref.Data) = *(int*)((byte*)pTypeInfos + 70 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<RVOSimulator>.Ref.Data) = *(int*)((byte*)pTypeInfos + 71 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<RVOSquareObstacle>.Ref.Data) = *(int*)((byte*)pTypeInfos + 72 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<LocalSpaceRichAI>.Ref.Data) = *(int*)((byte*)pTypeInfos + 73 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<TurnBasedAI>.Ref.Data) = *(int*)((byte*)pTypeInfos + 74 * 4);
			Unsafe.As<TypeIndex, int>(ref TypeManager.SharedTypeIndex<AnimationLinkTraverser>.Ref.Data) = *(int*)((byte*)pTypeInfos + 75 * 4);
		}
	}
}
