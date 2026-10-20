using System;
using System.Collections.Generic;
using DarkMachine.AI;
using Pathfinding;
using UnityEngine;

[Serializable]
public class AIN_Standard
{
	public Seeker seeker;

	private GameEntity gameEntity;

	private Path path;

	public PathModifier pathModifier;

	private float pathLength;

	public float pathSwitchDistanceMult = 1f;

	private List<Vector3> nearPath = new List<Vector3>();

	private bool hasVisitedFirst;

	private Vector3 lastMovementNode;

	private Vector3 nextMovementNode;

	public void Initialize(GameEntity gE)
	{
		gameEntity = gE;
		if ((UnityEngine.Object)(object)seeker == null)
		{
			seeker = gameEntity.gameObject.AddComponent<Seeker>();
		}
	}

	public void UpdatePath(Vector3 startPos, Vector3 targetPos, OnPathDelegate OnPathComplete)
	{
		OnPathComplete = (OnPathDelegate)Delegate.Combine(OnPathComplete, new OnPathDelegate(OnTargetPathComplete));
		seeker.StartPath(startPos, targetPos, OnPathComplete);
	}

	public void ClearFirstPathnode()
	{
		if (path != null && path.vectorPath.Count > 0)
		{
			path.vectorPath.RemoveAt(0);
		}
	}

	public Path GetLastPath()
	{
		return path;
	}

	public void OnTargetPathComplete(Path p)
	{
		if (!p.error)
		{
			path = p;
			pathLength = p.GetTotalLength();
		}
	}

	public Vector3 GetMovementTarget(AISightComponent sight, Vector3 targetPosition, bool useSight = true, float pathSwitchDistance = 0.2f, float maximumSightSwitchNodeDistance = 100f)
	{
		if (path == null)
		{
			UpdatePath(gameEntity.transform.position, targetPosition, null);
		}
		Vector3 result = nextMovementNode;
		if (GetLastPath() != null && GetLastPath().vectorPath.Count > 0)
		{
			if (nearPath == null)
			{
				nearPath = new List<Vector3>();
			}
			if (nearPath == null || nearPath.Count == 0)
			{
				nearPath.AddRange(GetLastPath().vectorPath);
			}
			int count = GetLastPath().vectorPath.Count;
			int count2 = nearPath.Count;
			float num = Vector3.Distance(GetLastPath().vectorPath[0], gameEntity.transform.position);
			if (count > 1 && count2 > 1 && (GetLastPath().vectorPath[0] != nearPath[0] || GetLastPath().vectorPath[1] != nearPath[1]) && GetLastPath().vectorPath[1] != nearPath[0])
			{
				nearPath.Clear();
				nearPath.AddRange(GetLastPath().vectorPath);
				hasVisitedFirst = false;
			}
			bool flag = seeker.startEndModifier.exactEndPoint == StartEndModifier.Exactness.NodeConnection;
			if (count2 > 1 && ((useSight && sight.CanSeeToPosition(nearPath[1]) && num < maximumSightSwitchNodeDistance) || num < pathSwitchDistance * pathSwitchDistanceMult))
			{
				hasVisitedFirst = true;
				if (count2 == 3 && flag)
				{
					result = nearPath[2];
				}
				else
				{
					result = nearPath[1];
					nextMovementNode = nearPath[1];
					lastMovementNode = nearPath[0];
				}
			}
			else if (!hasVisitedFirst)
			{
				result = GetLastPath().vectorPath[0];
			}
		}
		return result;
	}

	public Vector3 GetPathEndPosition()
	{
		if (path != null && path.vectorPath.Count > 0)
		{
			return path.vectorPath[path.vectorPath.Count - 1];
		}
		return gameEntity.transform.position;
	}

	public float GetPathLength()
	{
		return pathLength;
	}
}
