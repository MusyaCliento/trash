using System;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AIC_SimpleCreature_Stand : AIStateComponent
	{
		public float lookTimeMin = 2f;

		public float lookTimeMax = 5f;

		public bool checkForTarget;

		public string stateOnSeeTarget = "hunt";

		public float targetHuntDistanceMod = 1f;

		private float wanderTime;

		public float wanderHeightMult = 1f;

		private Vector3 lookVector;

		private Vector3 wanderHome;

		public Transform lookTransform;

		public override string name => "stand";

		public override void Initialize(AIGameEntity e, AIStateVariable[] variables, string[] args = null)
		{
			base.Initialize(e, variables, args);
			wanderHome = e.transform.position;
		}

		public override void Enter(AIGameEntity e, string[] args)
		{
			wanderTime = 0f;
			wanderHome = e.transform.position;
			if (lookTransform == null)
			{
				lookTransform = e.transform;
			}
			lookVector = lookTransform.forward;
			base.Enter(e, args);
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
			if (wanderTime <= 0f)
			{
				Vector3 onUnitSphere = UnityEngine.Random.onUnitSphere;
				onUnitSphere = Vector3.Scale(onUnitSphere, new Vector3(1f, wanderHeightMult, 1f));
				e.SetTargetPosition(wanderHome);
				lookVector = Vector3.Lerp(lookVector, onUnitSphere, 0.5f);
				wanderTime = UnityEngine.Random.Range(lookTimeMin, lookTimeMax);
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

		public override void OnOffsetEntity(float amount)
		{
			base.OnOffsetEntity(amount);
			wanderHome.y += amount;
		}
	}
}
