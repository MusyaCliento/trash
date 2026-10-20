using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class ENV_DenizenSecurityLockout : MonoBehaviourGizmos
{
	public string[] targetTags = new string[1] { "Denizen" };

	public Bounds detectionBounds = new Bounds(Vector3.zero, Vector3.one);

	public LayerMask detectionMask;

	private int objectsInBounds;

	public bool findEntitiesInBounds = true;

	private List<GameEntity> entitiesInBounds = new List<GameEntity>();

	public List<GameEntity> startEntities;

	public UnityEvent onAllEntitiesKilled;

	public Action _OnAllEntitiesKilled;

	public Action _OnEntityDeath;

	public UnityEvent<Transform> onTargetAcquired;

	private bool hasFinished;

	private void OnEnable()
	{
		StartCoroutine(WaitOneSecond());
		IEnumerator WaitOneSecond()
		{
			yield return new WaitForSeconds(1f);
			GetTaggedObjectsInBounds();
		}
	}

	private void Start()
	{
		if (startEntities == null || startEntities.Count <= 0)
		{
			return;
		}
		entitiesInBounds = new List<GameEntity>();
		entitiesInBounds.AddRange(startEntities);
		foreach (GameEntity entitiesInBound in entitiesInBounds)
		{
			entitiesInBound._OnDeath = (Action<GameEntity>)Delegate.Combine(entitiesInBound._OnDeath, new Action<GameEntity>(OnGameEntityDeath));
			objectsInBounds++;
		}
	}

	private void Update()
	{
	}

	public void GetTaggedObjectsInBounds()
	{
		if (hasFinished)
		{
			return;
		}
		objectsInBounds = 0;
		if (findEntitiesInBounds)
		{
			entitiesInBounds.Clear();
			Collider[] array = Physics.OverlapBox(base.transform.position + base.transform.TransformVector(detectionBounds.center), detectionBounds.extents, base.transform.rotation, detectionMask);
			foreach (Collider collider in array)
			{
				ObjectTagger objectTagger = collider.GetComponent<ObjectTagger>();
				GameEntity gameEntity = null;
				Hitbox component = collider.GetComponent<Hitbox>();
				if (component != null)
				{
					objectTagger = component.GetGameEntity().GetTagger();
					gameEntity = component.GetGameEntity();
				}
				if (objectTagger != null && objectTagger.HasTagInList(targetTags))
				{
					if (gameEntity == null)
					{
						gameEntity = collider.GetComponent<GameEntity>();
					}
					if (gameEntity != null && !gameEntity.dead && !entitiesInBounds.Contains(gameEntity))
					{
						objectsInBounds++;
						entitiesInBounds.Add(gameEntity);
						GameEntity gameEntity2 = gameEntity;
						gameEntity2._OnDeath = (Action<GameEntity>)Delegate.Combine(gameEntity2._OnDeath, new Action<GameEntity>(OnGameEntityDeath));
					}
				}
			}
		}
		if (entitiesInBounds.Count > 0)
		{
			onTargetAcquired.Invoke(entitiesInBounds[0].transform);
		}
		else
		{
			onAllEntitiesKilled.Invoke();
			_OnAllEntitiesKilled?.Invoke();
			onTargetAcquired.Invoke(null);
			hasFinished = true;
		}
		_OnEntityDeath?.Invoke();
	}

	private void OnGameEntityDeath(GameEntity entity)
	{
		if (entitiesInBounds.Contains(entity))
		{
			objectsInBounds--;
			entitiesInBounds.Remove(entity);
		}
		GetTaggedObjectsInBounds();
	}

	public void AddDenizenToLockout(Denizen d)
	{
		if (!entitiesInBounds.Contains(d))
		{
			entitiesInBounds.Add(d);
			objectsInBounds++;
			d._OnDeath = (Action<GameEntity>)Delegate.Combine(d._OnDeath, new Action<GameEntity>(OnGameEntityDeath));
			onTargetAcquired.Invoke(entitiesInBounds[0].transform);
		}
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.WireBox(base.transform.position + detectionBounds.center, base.transform.rotation, detectionBounds.size, Color.red);
	}

	public int GetEntitiesRemaining()
	{
		return entitiesInBounds.Count;
	}
}
