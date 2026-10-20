using System.Collections.Generic;
using UnityEngine;

public class Steering
{
	public class SteeringEntity
	{
		public string id;

		public List<string> tags;

		private Vector3 position;

		public float radius = 1f;

		public Vector3 GetPosition()
		{
			return position;
		}

		public void SetPosition(Vector3 p)
		{
			position = p;
		}
	}

	public static Steering steering;

	private static Dictionary<string, SteeringEntity> steeringDict;

	public static List<SteeringEntity> steeringEntities;

	public static void Initialize()
	{
		if (steering == null)
		{
			steering = new Steering();
		}
	}

	public static SteeringEntity AddSteeringEntity(string id, List<string> tags, Vector3 position, float radius)
	{
		SteeringEntity steeringEntity = new SteeringEntity();
		steeringEntity.id = id;
		steeringEntity.tags = tags;
		steeringEntity.SetPosition(position);
		steeringEntity.radius = radius;
		if (steeringEntities == null)
		{
			steeringEntities = new List<SteeringEntity>();
		}
		steeringEntities.Add(steeringEntity);
		if (steeringDict == null)
		{
			steeringDict = new Dictionary<string, SteeringEntity>();
		}
		steeringDict.Add(id, steeringEntity);
		return steeringEntity;
	}

	public static void RemoveSteeringEntity(string id)
	{
		if (steeringDict != null)
		{
			SteeringEntity value = null;
			if (steeringDict.TryGetValue(id, out value))
			{
				steeringEntities.Remove(value);
				steeringDict.Remove(id);
			}
		}
	}

	public static List<SteeringEntity> GetEntitiesByTag(string tag, string ignoreID)
	{
		List<SteeringEntity> list = new List<SteeringEntity>();
		if (steeringEntities == null)
		{
			return null;
		}
		foreach (SteeringEntity steeringEntity in steeringEntities)
		{
			if (!(steeringEntity.id == ignoreID) && (steeringEntity.tags.Contains(tag) || tag == ""))
			{
				list.Add(steeringEntity);
			}
		}
		return list;
	}

	public static Vector3 Seek(Vector3 startPos, Vector3 targetPos, float maxSpeed, Vector3 velocity)
	{
		return (targetPos - startPos).normalized * maxSpeed - velocity;
	}

	public static Vector3 Flee(Vector3 startPos, float maxSpeed, Vector3 velocity, List<string> fleeTags, float fleeRadius = 1f, string thisID = "")
	{
		Vector3 zero = Vector3.zero;
		foreach (string fleeTag in fleeTags)
		{
			List<SteeringEntity> entitiesByTag = GetEntitiesByTag(fleeTag, thisID);
			if (entitiesByTag == null || entitiesByTag.Count <= 0)
			{
				continue;
			}
			foreach (SteeringEntity item in entitiesByTag)
			{
				if (Vector3.Distance(startPos, item.GetPosition()) < fleeRadius + item.radius)
				{
					Vector3 vector = (startPos - item.GetPosition()).normalized * maxSpeed;
					zero += vector;
				}
			}
		}
		return zero;
	}

	public static Vector3 Wander(Vector3 startPos, float maxSpeed, Vector3 velocity, float wanderRadius, float wanderDistance, float wanderJitter)
	{
		Vector3 normalized = (Random.insideUnitSphere * wanderJitter).normalized;
		normalized *= wanderRadius;
		return normalized + velocity * wanderDistance;
	}
}
