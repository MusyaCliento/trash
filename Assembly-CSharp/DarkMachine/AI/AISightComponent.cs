using System;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AISightComponent
	{
		public class SightTarget
		{
			public Transform target;

			public float lastSeenTime;

			public float firstSeenTime;

			public bool canSee;

			public void UpdateTarget(bool b)
			{
				if (!canSee && b)
				{
					firstSeenTime = Time.time;
				}
				if (b)
				{
					lastSeenTime = Time.time;
				}
				canSee = b;
			}

			public float GetTimeSinceFirstSeen()
			{
				return Time.time - firstSeenTime;
			}

			public float GetTimeSinceLastSeen()
			{
				return Time.time - lastSeenTime;
			}
		}

		public bool active = true;

		public float sightDistance = 10f;

		public Transform eyeObject;

		public bool seeBackface;

		[HideInInspector]
		public bool infiniteMemory;

		public bool useMemory;

		public float memoryLength = 10f;

		private float memoryTime;

		public LayerMask sightMask;

		private Vector3 lastSeenPosition = Vector3.zero;

		public float spotTime;

		public float visibilityBlend = 1f;

		public float rememberVisibilityBlendMult = 1f;

		public bool useVisionCone;

		public float visionConeAngle = 45f;

		private Dictionary<Transform, SightTarget> sightHistory;

		public virtual void Update()
		{
		}

		public bool CanRemember()
		{
			if (!useMemory || !active)
			{
				return false;
			}
			if (!infiniteMemory)
			{
				return memoryTime > Time.time;
			}
			return true;
		}

		public bool IsPositionInVisionCone(Vector3 position)
		{
			if (!useVisionCone)
			{
				return true;
			}
			Vector3 to = position - eyeObject.position;
			return Vector3.Angle(eyeObject.forward, to) <= visionConeAngle;
		}

		public virtual bool CanSeeTarget(Vector3 origin, Transform target, float dist, Transform customAimTarget = null, bool checkMemory = false, bool useVisibility = true)
		{
			if (CL_GameManager.noTarget || !active)
			{
				return false;
			}
			if (sightHistory == null)
			{
				sightHistory = new Dictionary<Transform, SightTarget>();
			}
			if (useVisionCone && !IsPositionInVisionCone(target.position))
			{
				if (checkMemory)
				{
					return CanRemember();
				}
				return false;
			}
			SightTarget sightTarget = GetSightTarget(target);
			bool flag = false;
			float num = Vector3.Distance(origin, target.position) / dist;
			float num2 = spotTime * num;
			if (spotTime == 0f)
			{
				flag = true;
			}
			else if (sightTarget.GetTimeSinceFirstSeen() >= num2 && sightTarget.GetTimeSinceLastSeen() < spotTime * 2f)
			{
				flag = true;
			}
			float num3 = dist;
			GameEntity component = target.GetComponent<GameEntity>();
			if (component != null)
			{
				num3 *= Mathf.Lerp(1f, component.GetVisibility(), visibilityBlend * (CanRemember() ? rememberVisibilityBlendMult : 1f));
			}
			if (seeBackface)
			{
				Physics.queriesHitBackfaces = true;
			}
			bool flag2 = false;
			if (Physics.Raycast(origin, ((customAimTarget == null) ? target.position : customAimTarget.position) - origin, out var hitInfo, num3, sightMask))
			{
				if (seeBackface)
				{
					Physics.queriesHitBackfaces = false;
				}
				if (!(hitInfo.collider.transform == target))
				{
					flag2 = useMemory && checkMemory && CanRemember();
				}
				else
				{
					lastSeenPosition = hitInfo.point;
					if (flag)
					{
						memoryTime = Time.time + memoryLength;
					}
					flag2 = true;
				}
			}
			else
			{
				if (seeBackface)
				{
					Physics.queriesHitBackfaces = false;
				}
				flag2 = useMemory && checkMemory && CanRemember();
			}
			sightTarget.UpdateTarget(flag2);
			if (flag2)
			{
				flag2 = (flag ? true : false);
			}
			return flag2;
		}

		public virtual bool CanSeeTarget(Transform target, bool checkMemory = false)
		{
			if (target == null)
			{
				return false;
			}
			if (eyeObject == null)
			{
				return false;
			}
			return CanSeeTarget(eyeObject.position, target, sightDistance, null, checkMemory);
		}

		public virtual bool CanSeeToPosition(Vector3 targetPosition)
		{
			if (Physics.Linecast(eyeObject.position, targetPosition, out var _, sightMask))
			{
				return false;
			}
			return true;
		}

		public Vector3 GetLastSeenPosition()
		{
			return lastSeenPosition;
		}

		public void SetTargetAsVisible(Transform target, float memoryDuration = -1f)
		{
			lastSeenPosition = target.position;
			memoryTime = Time.time + ((memoryDuration > 0f) ? memoryDuration : memoryLength);
			CreateOrUpdateSightTarget(target, canSee: true);
		}

		private SightTarget CreateOrUpdateSightTarget(Transform transform, bool canSee)
		{
			if (sightHistory == null)
			{
				sightHistory = new Dictionary<Transform, SightTarget>();
			}
			if (sightHistory.ContainsKey(transform))
			{
				sightHistory[transform].UpdateTarget(canSee);
				return sightHistory[transform];
			}
			SightTarget sightTarget = new SightTarget();
			sightTarget.target = transform;
			sightTarget.UpdateTarget(canSee);
			sightHistory.Add(transform, sightTarget);
			return sightTarget;
		}

		private SightTarget GetSightTarget(Transform transform)
		{
			if (sightHistory.ContainsKey(transform))
			{
				return sightHistory[transform];
			}
			SightTarget sightTarget = new SightTarget();
			sightTarget.target = transform;
			sightTarget.UpdateTarget(b: false);
			sightHistory.Add(transform, sightTarget);
			return sightTarget;
		}

		public void ClearMemory()
		{
			memoryTime = 0f;
		}

		public void ClearSight()
		{
			ClearMemory();
			sightHistory = new Dictionary<Transform, SightTarget>();
		}

		public virtual void OnDrawGizmos(Transform transform)
		{
			if (eyeObject != null)
			{
				Draw.Circle(eyeObject.position, eyeObject.up, sightDistance, Color.red);
				if (useVisionCone)
				{
					Draw.Arrow(eyeObject.position, eyeObject.position + eyeObject.forward * sightDistance, Color.blue);
					Vector3 forward = eyeObject.forward;
					Vector3 vector = Quaternion.AngleAxis(visionConeAngle, eyeObject.up) * forward;
					Vector3 vector2 = Quaternion.AngleAxis(0f - visionConeAngle, eyeObject.up) * forward;
					Draw.Line(eyeObject.position, eyeObject.position + vector * sightDistance, Color.cyan);
					Draw.Line(eyeObject.position, eyeObject.position + vector2 * sightDistance, Color.cyan);
				}
			}
		}
	}
}
