using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.ECS
{
	[Serializable]
	public struct AutoRepathPolicy : IComponentData, IQueryTypeParameter
	{
		public const float Sensitivity = 10f;

		public Pathfinding.AutoRepathPolicy.Mode mode;

		public float period;

		private float3 lastDestination;

		private float lastRepathTime;

		public static AutoRepathPolicy Default => new AutoRepathPolicy
		{
			mode = Pathfinding.AutoRepathPolicy.Mode.Dynamic,
			period = 2f,
			lastDestination = float.PositiveInfinity,
			lastRepathTime = float.NegativeInfinity
		};

		public AutoRepathPolicy(Pathfinding.AutoRepathPolicy policy)
		{
			mode = policy.mode;
			period = ((policy.mode == Pathfinding.AutoRepathPolicy.Mode.Dynamic) ? policy.maximumPeriod : policy.period);
			lastDestination = float.PositiveInfinity;
			lastRepathTime = float.NegativeInfinity;
		}

		public bool ShouldRecalculatePath(float3 position, float radius, float3 destination, float time)
		{
			if (mode == Pathfinding.AutoRepathPolicy.Mode.Never || float.IsPositiveInfinity(destination.x))
			{
				return false;
			}
			float num = time - lastRepathTime;
			if (mode == Pathfinding.AutoRepathPolicy.Mode.EveryNSeconds)
			{
				return num >= period;
			}
			float num2 = math.lengthsq(destination - lastDestination) / math.max(math.lengthsq(position - lastDestination), radius * radius) * 100f;
			if (float.IsNaN(num2))
			{
				num2 = 0f;
			}
			return num >= period * (1f - math.sqrt(num2));
		}

		public void Reset()
		{
			lastDestination = float.PositiveInfinity;
			lastRepathTime = float.NegativeInfinity;
		}

		public void DidRecalculatePath(float3 destination, float time)
		{
			lastRepathTime = time;
			lastDestination = destination;
			lastRepathTime -= (UnityEngine.Random.value - 0.5f) * 0.3f * period;
		}
	}
}
