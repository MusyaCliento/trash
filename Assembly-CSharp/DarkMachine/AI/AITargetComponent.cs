using System;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AITargetComponent
	{
		[Serializable]
		public class AITarget
		{
			public Transform targetTransform;

			public ObjectTagger targetTagger;

			public GameEntity targetEntity;

			public Vector3 lastSighted;

			public bool isVisible;

			public float lastSightedTimer;

			public void Clear()
			{
				targetTransform = null;
				targetTagger = null;
				targetEntity = null;
				isVisible = false;
			}
		}

		public AITarget target = new AITarget();

		public LayerMask targetScanMask;

		public string[] targetScanTags;

		public string[] targetIgnoreTags;

		public Action _OnTargetFound;

		public bool clearTargetIfDead = true;

		public void Update()
		{
			if (target.targetTransform != null && target.targetEntity != null)
			{
				if (clearTargetIfDead && target.targetEntity.IsDead())
				{
					target.Clear();
				}
				else if (target.targetTagger != null && target.targetTagger.HasTagInList(targetIgnoreTags))
				{
					target.Clear();
				}
			}
		}

		public bool HasTarget()
		{
			if (target != null && target.targetEntity != null && target.targetEntity.IsDead())
			{
				target.Clear();
				return false;
			}
			return target.targetTransform != null;
		}

		public void CheckForTarget(Vector3 pos, float scanRadius, AISightComponent sightComponent = null, Transform self = null)
		{
			Collider[] array = Physics.OverlapSphere(pos, scanRadius, targetScanMask);
			foreach (Collider collider in array)
			{
				if ((self != null && (collider.transform == self || collider.transform.IsChildOf(self))) || !ObjectTagger.TagCheck(collider.gameObject, targetScanTags, out var tagger) || tagger.HasTagInList(targetIgnoreTags))
				{
					continue;
				}
				Hitbox component2;
				if (collider.TryGetComponent<GameEntity>(out var component))
				{
					if (component.dead)
					{
						continue;
					}
					target.targetEntity = component;
				}
				else if (collider.TryGetComponent<Hitbox>(out component2))
				{
					if (component2.GetGameEntity().dead)
					{
						continue;
					}
					target.targetEntity = component2.GetGameEntity();
				}
				if (!tagger.HasTag("Dead") && (sightComponent == null || sightComponent.CanSeeTarget(collider.transform, checkMemory: true)))
				{
					if (!HasTarget())
					{
						_OnTargetFound?.Invoke();
					}
					target.targetTagger = tagger;
					target.targetTransform = collider.transform;
					break;
				}
			}
		}

		internal void ClearTarget()
		{
			target.Clear();
		}

		public void SetTarget(Transform t)
		{
			ObjectTagger component = t.GetComponent<ObjectTagger>();
			target.targetTagger = component;
			target.targetTransform = t;
			target.targetEntity = t.GetComponent<GameEntity>();
			if (target.targetEntity == null && target.targetTransform.TryGetComponent<Hitbox>(out var component2))
			{
				target.targetEntity = component2.GetGameEntity();
			}
		}
	}
}
