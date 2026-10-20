using Pathfinding.ECS;
using Pathfinding.ECS.RVO;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[BurstCompile]
[Preserve]
internal class __UnmanagedPostProcessorOutput__10569589673291187727
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(AIMoveSystem), BurstRuntime.GetHashCode64<AIMoveSystem>(), AIMoveSystem.__codegen__OnCreate, AIMoveSystem.__codegen__OnUpdate, AIMoveSystem.__codegen__OnDestroy, null, null, AIMoveSystem.__codegen__OnCreateForCompiler, "Pathfinding.ECS.AIMoveSystem", 0);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(FallbackResolveMovementSystem), BurstRuntime.GetHashCode64<FallbackResolveMovementSystem>(), null, FallbackResolveMovementSystem.__codegen__OnUpdate, null, null, null, FallbackResolveMovementSystem.__codegen__OnCreateForCompiler, "Pathfinding.ECS.FallbackResolveMovementSystem", 0);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(FollowerControlSystem), BurstRuntime.GetHashCode64<FollowerControlSystem>(), FollowerControlSystem.__codegen__OnCreate, FollowerControlSystem.__codegen__OnUpdate, FollowerControlSystem.__codegen__OnDestroy, null, null, FollowerControlSystem.__codegen__OnCreateForCompiler, "Pathfinding.ECS.FollowerControlSystem", 0);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(MovementPlaneFromGraphSystem), BurstRuntime.GetHashCode64<MovementPlaneFromGraphSystem>(), MovementPlaneFromGraphSystem.__codegen__OnCreate, MovementPlaneFromGraphSystem.__codegen__OnUpdate, MovementPlaneFromGraphSystem.__codegen__OnDestroy, null, null, MovementPlaneFromGraphSystem.__codegen__OnCreateForCompiler, "Pathfinding.ECS.MovementPlaneFromGraphSystem", 0);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(PollPendingPathsSystem), BurstRuntime.GetHashCode64<PollPendingPathsSystem>(), PollPendingPathsSystem.__codegen__OnCreate, PollPendingPathsSystem.__codegen__OnUpdate, PollPendingPathsSystem.__codegen__OnDestroy, null, null, PollPendingPathsSystem.__codegen__OnCreateForCompiler, "Pathfinding.ECS.PollPendingPathsSystem", 0);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(RepairPathSystem), BurstRuntime.GetHashCode64<RepairPathSystem>(), RepairPathSystem.__codegen__OnCreate, RepairPathSystem.__codegen__OnUpdate, RepairPathSystem.__codegen__OnDestroy, null, null, RepairPathSystem.__codegen__OnCreateForCompiler, "Pathfinding.ECS.RepairPathSystem", 0);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(SyncDestinationTransformSystem), BurstRuntime.GetHashCode64<SyncDestinationTransformSystem>(), null, SyncDestinationTransformSystem.__codegen__OnUpdate, null, null, null, SyncDestinationTransformSystem.__codegen__OnCreateForCompiler, "Pathfinding.ECS.SyncDestinationTransformSystem", 0);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(SyncTransformsToEntitiesSystem), BurstRuntime.GetHashCode64<SyncTransformsToEntitiesSystem>(), null, SyncTransformsToEntitiesSystem.__codegen__OnUpdate, null, null, null, SyncTransformsToEntitiesSystem.__codegen__OnCreateForCompiler, "Pathfinding.ECS.SyncTransformsToEntitiesSystem", 0);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(RVOSystem), BurstRuntime.GetHashCode64<RVOSystem>(), RVOSystem.__codegen__OnCreate, RVOSystem.__codegen__OnUpdate, RVOSystem.__codegen__OnDestroy, null, null, RVOSystem.__codegen__OnCreateForCompiler, "Pathfinding.ECS.RVO.RVOSystem", 0);
	}
}
