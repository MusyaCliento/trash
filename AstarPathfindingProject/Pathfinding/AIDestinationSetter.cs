using System;
using Pathfinding.Util;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

namespace Pathfinding
{
	[UniqueComponent(tag = "ai.destination")]
	[AddComponentMenu("Pathfinding/AI/Behaviors/AIDestinationSetter")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/aidestinationsetter.html")]
	public class AIDestinationSetter : VersionedMonoBehaviour, IComponentData, IQueryTypeParameter, IRuntimeBaker
	{
		public Transform target;

		public bool useRotation;

		private IAstarAI ai;

		private Entity entity;

		private World world;

		private void OnEnable()
		{
			ai = GetComponent<IAstarAI>();
			if (ai is FollowerEntity followerEntity)
			{
				followerEntity.RegisterRuntimeBaker(this);
				return;
			}
			if (ai != null)
			{
				IAstarAI astarAI = ai;
				astarAI.onSearchPath = (Action)Delegate.Combine(astarAI.onSearchPath, new Action(UpdateDestination));
			}
			BatchedEvents.Add(this, BatchedEvents.Event.Update, OnUpdate);
		}

		private void OnDisable()
		{
			if (world != null && world.IsCreated && world.EntityManager.Exists(entity))
			{
				world.EntityManager.RemoveComponent<AIDestinationSetter>(entity);
			}
			if (ai != null && !(ai is FollowerEntity))
			{
				IAstarAI astarAI = ai;
				astarAI.onSearchPath = (Action)Delegate.Remove(astarAI.onSearchPath, new Action(UpdateDestination));
			}
			BatchedEvents.Remove(this);
		}

		void IRuntimeBaker.OnCreatedEntity(World world, Entity entity)
		{
			this.entity = entity;
			this.world = world;
			EntityManagerManagedComponentExtensions.AddComponentData(world.EntityManager, entity, this);
		}

		private static void OnUpdate(AIDestinationSetter[] components, int count)
		{
			for (int i = 0; i < count; i++)
			{
				components[i].UpdateDestination();
			}
		}

		private void UpdateDestination()
		{
			if (target != null && ai != null)
			{
				ai.destination = target.position;
			}
		}

		[UnityEngine.Scripting.Preserve]
		public AIDestinationSetter()
		{
		}
	}
}
