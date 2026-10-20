using System;
using Pathfinding.RVO;
using Unity.Entities;
using UnityEngine;

namespace Pathfinding.ECS.RVO
{
	[Serializable]
	public struct RVOAgent : IComponentData, IQueryTypeParameter
	{
		[Tooltip("How far into the future to look for collisions with other agents (in seconds)")]
		public float agentTimeHorizon;

		[Tooltip("How far into the future to look for collisions with obstacles (in seconds)")]
		public float obstacleTimeHorizon;

		[Tooltip("Max number of other agents to take into account.\nA smaller value can reduce CPU load, a higher value can lead to better local avoidance quality.")]
		public int maxNeighbours;

		public RVOLayer layer;

		[EnumFlag]
		public RVOLayer collidesWith;

		[Tooltip("How strongly other agents will avoid this agent")]
		[Range(0f, 1f)]
		public float priority;

		[NonSerialized]
		public float priorityMultiplier;

		[NonSerialized]
		public float flowFollowingStrength;

		public AgentDebugFlags debug;

		[Tooltip("A locked unit cannot move. Other units will still avoid it. But avoidance quality is not the best")]
		public bool locked;

		public static readonly RVOAgent Default = new RVOAgent
		{
			locked = false,
			agentTimeHorizon = 1f,
			obstacleTimeHorizon = 0.5f,
			maxNeighbours = 10,
			layer = RVOLayer.DefaultAgent,
			collidesWith = (RVOLayer)(-1),
			priority = 0.5f,
			priorityMultiplier = 1f,
			flowFollowingStrength = 0f,
			debug = AgentDebugFlags.Nothing
		};
	}
}
