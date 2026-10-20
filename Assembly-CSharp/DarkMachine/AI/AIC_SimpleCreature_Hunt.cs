using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AIC_SimpleCreature_Hunt : AIStateComponent
	{
		[Flags]
		public enum FearType
		{
			alwaysFear = 0,
			fearByTargetTag = 2,
			fearWhenLowHealth = 4,
			fearWhenFlag = 8
		}

		public enum HuntMovementType
		{
			moveToTarget = 0,
			stayInPlace = 1,
			stayNearHome = 2,
			moveToNearestLocator = 3,
			moveToNearestLocatorToTarget = 4,
			moveToFarthestLocatorToTarget = 64
		}

		public bool checkForTarget;

		public string stateOnLoseTarget = "wander";

		public bool canAttackTarget = true;

		public float attackDistance = 10f;

		public float attackRate = 0.5f;

		private float attackTime;

		public bool fear;

		public FearType fearType;

		public bool fearInAnyDirection;

		public float fearDistance = 5f;

		public List<string> fearTargetTags;

		public string fearSessionFlag;

		public float fearHealthValue;

		private float fearTimer;

		private float stuckTime;

		private bool isStuck;

		public float fearStuckMinVelocity;

		public float fearStuckPanicTimer = 4f;

		private Vector3 fearEscapeDirection;

		public float fearEscapeDistance = 2f;

		public bool useFearEscapeRaycast;

		public LayerMask fearRaycastLayer;

		public HuntMovementType huntMovementType;

		public string huntHomeLocatorID = "";

		public bool seperateTargetDistanceFromLocator;

		public float maxLocatorDistance = 20f;

		public float minLocatorDistance;

		public bool prioritizeUnvisitedLocators;

		public float locatorVisitWeightMult = 1f;

		private Dictionary<UT_Locator, float> visitedLocatorWeights;

		private UT_Locator currentLocatorTarget;

		public Vector3 huntOffset;

		public bool huntMoveToTarget = true;

		public float huntHoldDistance = 1f;

		public Vector3 huntPositionScale = Vector3.one;

		public bool alwaysFaceTarget;

		public float minimumFaceDistance;

		public float lookVectorLerpSpeed = 16f;

		public Action _OnAttackCheck;

		private Vector3 lookVector;

		private AIGameEntity entity;

		private Denizen denizen;

		private Vector3 homePosition;

		internal bool canSeeTarget;

		private Vector3 enterPosition;

		public override string name => "hunt";

		public override void Initialize(AIGameEntity e, AIStateVariable[] variables, string[] args = null)
		{
			entity = e;
			base.Initialize(e, variables, args);
			if (e is Denizen)
			{
				denizen = e as Denizen;
			}
			homePosition = e.transform.position;
		}

		public override void Enter(AIGameEntity e, string[] args)
		{
			base.Enter(e, args);
			attackTime = attackRate;
			enterPosition = e.transform.position;
			stuckTime = 0f;
			isStuck = false;
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
			float num = 100f;
			if (e.target != null)
			{
				num = Vector3.Distance(e.target.position, e.transform.position);
			}
			bool flag = false;
			if (e.target == null)
			{
				e.ChangeState(stateOnLoseTarget);
				return;
			}
			if (fear)
			{
				flag = true;
				if (fearType.HasFlag(FearType.alwaysFear))
				{
					flag = true;
				}
				else
				{
					if (fearType.HasFlag(FearType.fearByTargetTag) && fearTargetTags != null && e.GetTargetEntity() != null && ObjectTagger.TagCheck(e.GetTargetEntity().gameObject, fearTargetTags.ToArray()))
					{
						flag = true;
					}
					if (fearType.HasFlag(FearType.fearWhenLowHealth) && e.health <= fearHealthValue)
					{
						flag = true;
					}
					if (fearType.HasFlag(FearType.fearWhenFlag) && CL_GameManager.HasActiveFlag(fearSessionFlag))
					{
						flag = true;
					}
				}
				if (flag && num < fearDistance)
				{
					if (!isStuck)
					{
						fearEscapeDirection = e.transform.position - e.target.position;
						if (!fearInAnyDirection)
						{
							fearEscapeDirection = Vector3.ProjectOnPlane(fearEscapeDirection, Vector3.up);
						}
						if (useFearEscapeRaycast && Physics.Raycast(e.transform.position, fearEscapeDirection, out var hitInfo, fearEscapeDistance, fearRaycastLayer))
						{
							fearEscapeDirection = (UnityEngine.Random.onUnitSphere + hitInfo.normal * 0.5f).normalized;
							stuckTime = 2f;
							isStuck = true;
						}
					}
					e.SetTargetPosition(e.transform.position + fearEscapeDirection.normalized * fearEscapeDistance);
				}
				else
				{
					flag = false;
				}
				fearTimer += Time.deltaTime;
				if (isStuck)
				{
					stuckTime -= Time.deltaTime;
					if (stuckTime <= 0f)
					{
						isStuck = false;
					}
				}
				else if (fearStuckMinVelocity > 0f && e.GetTrueVelocity().magnitude < fearStuckMinVelocity)
				{
					stuckTime += Time.deltaTime;
					if (stuckTime > fearStuckPanicTimer && !isStuck)
					{
						isStuck = true;
						fearEscapeDirection = UnityEngine.Random.onUnitSphere;
					}
				}
			}
			Vector3 vector = lookVector;
			canSeeTarget = false;
			if (checkForTarget)
			{
				if (!(e.target != null))
				{
					e.ChangeState(stateOnLoseTarget);
					return;
				}
				canSeeTarget = e.sight.CanSeeTarget(e.target);
				if (!canSeeTarget && !e.sight.CanRemember())
				{
					e.ChangeState(stateOnLoseTarget);
					return;
				}
				if (canAttackTarget && !flag && canSeeTarget)
				{
					attackTime -= Time.deltaTime;
					if (attackTime <= 0f)
					{
						if (num < attackDistance)
						{
							AttackCheck();
						}
						attackTime = attackRate;
					}
				}
			}
			if (!flag)
			{
				if (huntMovementType == HuntMovementType.moveToTarget)
				{
					e.SetTargetPosition(GetHuntChasePosition(e));
				}
				else if (huntMovementType == HuntMovementType.stayNearHome)
				{
					e.SetTargetPosition(homePosition);
				}
				else if (huntMovementType == HuntMovementType.moveToNearestLocator || huntMovementType == HuntMovementType.moveToNearestLocatorToTarget)
				{
					Vector3 position = e.transform.position;
					if (huntMovementType == HuntMovementType.moveToNearestLocatorToTarget)
					{
						position = e.target.position;
					}
					List<UT_Locator> list = null;
					list = ((!seperateTargetDistanceFromLocator) ? UT_Locator.GetClosestLocatorsWithinRange(huntHomeLocatorID, position, position, minLocatorDistance, maxLocatorDistance) : UT_Locator.GetClosestLocatorsWithinRange(huntHomeLocatorID, e.transform.position, position, minLocatorDistance, maxLocatorDistance));
					if (list != null && list.Count > 0)
					{
						if (prioritizeUnvisitedLocators)
						{
							if (visitedLocatorWeights == null)
							{
								visitedLocatorWeights = new Dictionary<UT_Locator, float>();
							}
							bool flag2 = false;
							if (list.Contains(currentLocatorTarget))
							{
								flag2 = true;
							}
							if (!flag2)
							{
								float num2 = float.PositiveInfinity;
								UT_Locator uT_Locator = null;
								foreach (UT_Locator item in list)
								{
									float num3 = DarkMachineFunctions.GetManhattanDistance(item.transform.position, e.transform.position);
									if (visitedLocatorWeights.ContainsKey(item))
									{
										num3 += visitedLocatorWeights[item] * locatorVisitWeightMult;
									}
									else
									{
										visitedLocatorWeights.Add(item, 0f);
									}
									if (num3 < num2)
									{
										num2 = num3;
										uT_Locator = item;
									}
								}
								if (uT_Locator != null)
								{
									currentLocatorTarget = uT_Locator;
									visitedLocatorWeights[uT_Locator] += 1f;
								}
							}
						}
						else
						{
							currentLocatorTarget = list[0];
						}
						Vector3 position2 = currentLocatorTarget.transform.position;
						if (huntMovementType == HuntMovementType.moveToNearestLocatorToTarget)
						{
							float num4 = Vector3.Distance(homePosition, position);
							float num5 = Vector3.Distance(position2, position);
							if (num4 > maxLocatorDistance && num5 > maxLocatorDistance)
							{
								e.SetTargetPosition(GetHuntChasePosition(e));
							}
							else if (num5 < maxLocatorDistance)
							{
								e.SetTargetPosition(position2);
							}
							else if (num4 < maxLocatorDistance)
							{
								e.SetTargetPosition(homePosition);
							}
							else
							{
								e.SetTargetPosition(position2);
								homePosition = position2;
							}
						}
						else
						{
							e.SetTargetPosition(position2);
							homePosition = position2;
						}
					}
					else
					{
						e.SetTargetPosition(GetHuntChasePosition(e));
					}
				}
			}
			if (alwaysFaceTarget)
			{
				if (num < minimumFaceDistance)
				{
					vector = Vector3.Slerp(e.transform.forward, Vector3.Scale((e.sight.GetLastSeenPosition() - e.transform.position).normalized, new Vector3(1f, 0.02f, 1f)), Time.deltaTime * lookVectorLerpSpeed * 2f);
					e.SetTargetPosition(homePosition);
				}
				else
				{
					vector = e.sight.GetLastSeenPosition() - e.transform.position;
				}
			}
			else
			{
				vector = e.targetPosition - e.transform.position;
			}
			lookVector = Vector3.Slerp(lookVector, vector.normalized, Time.deltaTime * lookVectorLerpSpeed * 10f);
		}

		private Vector3 GetHuntChasePosition(AIGameEntity e)
		{
			Vector3 a = e.sight.GetLastSeenPosition() - e.transform.position;
			a = Vector3.Scale(a, huntPositionScale);
			return e.sight.GetLastSeenPosition() + huntOffset + huntHoldDistance * -a.normalized;
		}

		public void AttackCheck()
		{
			if (_OnAttackCheck != null)
			{
				_OnAttackCheck();
			}
			if (denizen != null)
			{
				denizen.AttackCheck();
			}
		}

		public override Vector3 GetLookVector()
		{
			return lookVector;
		}

		public override bool CanEnterState()
		{
			if (entity != null && fear && (entity.target == null || Vector3.Distance(entity.target.position, entity.transform.position) > fearDistance))
			{
				return false;
			}
			return base.CanEnterState();
		}

		public bool IsInAttackRange()
		{
			if (entity == null || entity.target == null)
			{
				return false;
			}
			return Vector3.Distance(entity.transform.position, entity.target.position) < attackDistance;
		}
	}
}
