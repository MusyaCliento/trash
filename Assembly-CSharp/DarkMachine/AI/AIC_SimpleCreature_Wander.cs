using System;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AIC_SimpleCreature_Wander : AIStateComponent
	{
		public enum WanderLook
		{
			setLookOnDestinationSet = 0,
			setLookHalfOnDestinationSet = 1,
			alwaysFaceDestination = 2
		}

		public enum WanderType
		{
			moveToRandomLocation = 0,
			moveToNearestLocator = 1,
			moveToNearestLocatorToRandomLocation = 2
		}

		public float wanderDistance = 5f;

		public float wanderTimeMin = 2f;

		public float wanderTimeMax = 5f;

		public bool stayNearHome;

		public float homeDistance = 10f;

		public bool checkForTarget;

		public string stateOnSeeTarget = "hunt";

		public float targetHuntDistanceMod = 1f;

		private float wanderTime;

		public bool wanderRaycast;

		public LayerMask wanderRaycastMask;

		public float wanderRaycastOffset = 2f;

		public float wanderHeightMult = 1f;

		public WanderLook wanderLook;

		private Vector3 lookVector;

		private Vector3 wanderHome;

		public WanderType wanderType;

		public string searchLocatorID = "";

		public float maxLocatorDistance = 10f;

		public override string name => "wander";

		public override void Initialize(AIGameEntity e, AIStateVariable[] variables, string[] args = null)
		{
			base.Initialize(e, variables, args);
			wanderHome = e.transform.position;
		}

		public override void Enter(AIGameEntity e, string[] args)
		{
			wanderTime = 0f;
			base.Enter(e, args);
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
			if (wanderTime <= 0f)
			{
				Vector3 a = UnityEngine.Random.insideUnitSphere * wanderDistance;
				a = Vector3.Scale(a, new Vector3(1f, wanderHeightMult, 1f));
				if (wanderRaycast && Physics.Raycast(e.transform.position, a.normalized, out var hitInfo, a.magnitude, wanderRaycastMask))
				{
					a = a.normalized * (hitInfo.distance - wanderRaycastOffset);
				}
				Vector3 vector = e.transform.position + a;
				if (wanderType == WanderType.moveToNearestLocator || wanderType == WanderType.moveToNearestLocatorToRandomLocation)
				{
					Vector3 position = e.transform.position;
					if (wanderType == WanderType.moveToNearestLocatorToRandomLocation)
					{
						position = vector;
					}
					Transform closestLocatorInGroupToPosition = UT_Locator.GetClosestLocatorInGroupToPosition(searchLocatorID, position);
					if (closestLocatorInGroupToPosition != null)
					{
						float num = Vector3.Distance(closestLocatorInGroupToPosition.position, e.transform.position);
						if (maxLocatorDistance > 0f && num < maxLocatorDistance)
						{
							if (wanderType == WanderType.moveToNearestLocatorToRandomLocation)
							{
								float num2 = Vector3.Distance(wanderHome, closestLocatorInGroupToPosition.position);
								if (stayNearHome && num < homeDistance)
								{
									vector = closestLocatorInGroupToPosition.position + a;
								}
								else if (stayNearHome && homeDistance < num2)
								{
									vector = wanderHome + a;
								}
								else
								{
									vector = closestLocatorInGroupToPosition.position + a;
									wanderHome = closestLocatorInGroupToPosition.position;
								}
							}
							else
							{
								vector = closestLocatorInGroupToPosition.position;
								wanderHome = closestLocatorInGroupToPosition.position;
							}
						}
					}
				}
				e.SetTargetPosition(vector);
				if (stayNearHome)
				{
					Vector3 vector2 = e.targetPosition - wanderHome;
					if (vector2.magnitude > homeDistance)
					{
						vector2 = Vector3.ClampMagnitude(vector2, homeDistance);
						e.SetTargetPosition(wanderHome + vector2);
					}
				}
				if (wanderLook == WanderLook.setLookOnDestinationSet)
				{
					lookVector = a;
				}
				else if (wanderLook == WanderLook.setLookHalfOnDestinationSet)
				{
					lookVector = Vector3.Lerp(lookVector, a, 0.5f);
				}
				wanderTime = UnityEngine.Random.Range(wanderTimeMin, wanderTimeMax);
			}
			if (wanderLook == WanderLook.alwaysFaceDestination)
			{
				lookVector = Vector3.Lerp(lookVector, e.GetTargetPosition() - e.transform.position, Time.deltaTime * 3f);
			}
			wanderTime -= Time.deltaTime;
			if (checkForTarget && e.target != null && e.sight.CanSeeTarget(e.transform.position, e.target, e.sight.sightDistance * targetHuntDistanceMod))
			{
				e.ChangeState(stateOnSeeTarget);
			}
		}

		public override Vector3 GetLookVector()
		{
			return lookVector;
		}

		public void SetHomePosition(Vector3 h)
		{
			wanderHome = h;
		}

		public override void SetTarget(Vector3 v)
		{
			base.SetTarget(v);
			wanderHome = v;
		}

		public override void OnOffsetEntity(float amount)
		{
			base.OnOffsetEntity(amount);
			wanderHome.y += amount;
		}
	}
}
