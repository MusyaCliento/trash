using System;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AIC_SimpleCreature_Wander_Patrol : AIStateComponent
	{
		public float wanderDistance = 1f;

		public float wanderTimeMin = 2f;

		public float wanderTimeMax = 5f;

		public bool setHomeOnEnter;

		public float homeDistance = 10f;

		public bool checkForTarget;

		public string stateOnSeeTarget = "hunt";

		public float targetHuntDistanceMod = 1f;

		private float wanderTime;

		public bool wanderRaycast;

		public LayerMask wanderRaycastMask;

		public float wanderRaycastOffset = 2f;

		public float wanderHeightMult = 1f;

		public float reachWaypointDistance = 1.5f;

		private Vector3 lookVector;

		private Vector3 wanderHome;

		public Action<AIC_SimpleCreature_Wander_Patrol> _OnReachWaypoint;

		private Denizen denizen;

		private Vector3 patrolPosition;

		private float patrolCheckTime;

		public override string name => "wander";

		public override void Initialize(AIGameEntity e, AIStateVariable[] variables, string[] args = null)
		{
			base.Initialize(e, variables, args);
			wanderHome = e.transform.position;
			if (e is Denizen)
			{
				denizen = e as Denizen;
			}
		}

		public override void Enter(AIGameEntity e, string[] args)
		{
			wanderTime = 0f;
			base.Enter(e, args);
			patrolPosition = e.transform.position;
			if (setHomeOnEnter)
			{
				wanderHome = patrolPosition;
			}
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
			float num = Vector3.Distance(e.transform.position, patrolPosition);
			patrolCheckTime += Time.deltaTime;
			if (num <= reachWaypointDistance || patrolCheckTime > 3f)
			{
				patrolCheckTime = 0f;
				Vector3 a = UnityEngine.Random.insideUnitSphere * wanderDistance;
				a = Vector3.Scale(a, new Vector3(1f, wanderHeightMult, 1f));
				if (wanderRaycast && Physics.Raycast(e.transform.position, a.normalized, out var hitInfo, a.magnitude, wanderRaycastMask))
				{
					a = a.normalized * (hitInfo.distance - wanderRaycastOffset);
				}
				patrolPosition = e.transform.position + a;
				e.SetTargetPosition(patrolPosition);
				lookVector = a;
				Vector3 vector = patrolPosition - wanderHome;
				if (vector.magnitude > homeDistance)
				{
					vector = Vector3.ClampMagnitude(vector, homeDistance);
					patrolPosition = wanderHome + vector;
					e.SetTargetPosition(patrolPosition);
				}
				_OnReachWaypoint?.Invoke(this);
			}
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

		public override void OnOffsetEntity(float amount)
		{
			base.OnOffsetEntity(amount);
			wanderHome.y += amount;
		}
	}
}
