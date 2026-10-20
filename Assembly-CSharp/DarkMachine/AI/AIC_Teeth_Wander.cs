using Drawing;
using UnityEngine;

namespace DarkMachine.AI
{
	public class AIC_Teeth_Wander : AIStateComponent
	{
		public float wanderTime = 5f;

		public float wanderWaitTime = 2f;

		public float wanderDistance = 5f;

		private bool isWaiting;

		private float currentTimer = 1f;

		private Vector3 wanderTarget;

		public float burrowDistance = 50f;

		private float timeSinceWanderStarted;

		public DEN_Teeth teeth;

		private Vector3 lastWanderPosition;

		private float stuckDetection;

		public override string name => "wander";

		public override void Enter(AIGameEntity e, string[] args)
		{
			base.Enter(e, args);
			timeSinceWanderStarted = 0f;
			if (teeth == null)
			{
				teeth = e.GetComponent<DEN_Teeth>();
			}
			teeth.locked = false;
			teeth.curBarkTime = Random.Range(teeth.barkTime / 2f, teeth.barkTime * 2f);
			stuckDetection = 0f;
			Debug.Log("Entered wander state for " + e.name);
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
			timeSinceWanderStarted += Time.deltaTime;
			float num = Vector3.Distance(lastWanderPosition, e.transform.position);
			teeth.curBarkTime -= Time.deltaTime;
			if (teeth.curBarkTime <= 0f)
			{
				teeth.curBarkTime = Random.Range(teeth.barkTime / 2f, teeth.barkTime * 2f);
				e.clipHandler.PlaySound("teeth:bark");
			}
			float num2 = Vector3.Distance(e.target.position, e.transform.position);
			if (num < 0.3f * Time.deltaTime && num2 > 15f)
			{
				stuckDetection += Time.deltaTime;
				if (stuckDetection > 1f)
				{
					e.ChangeState("burrow");
					return;
				}
			}
			else
			{
				stuckDetection = 0f;
			}
			lastWanderPosition = e.transform.position;
			if (currentTimer <= 0f)
			{
				isWaiting = !isWaiting;
				currentTimer = (isWaiting ? wanderWaitTime : wanderTime);
				wanderTarget = Vector3.Lerp(e.transform.position, e.target.position, 0.5f) + Random.insideUnitSphere * wanderDistance;
				e.SetTargetPosition(isWaiting ? Vector3.Lerp(e.transform.position, e.target.position, 0.5f) : wanderTarget);
			}
			currentTimer -= Time.deltaTime;
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Cross(wanderTarget, 0.3f, new Color(0f, 1f, 0f, 1f));
				CL_DebugView.draw.Label2D(wanderTarget + Vector3.up * 0.3f, "Wandertarget", 8f, LabelAlignment.Center, Color.white);
			}
			if (e.sight.CanSeeTarget(e.target))
			{
				e.ChangeState("chase");
			}
			if (num2 > 15f && timeSinceWanderStarted > 15f)
			{
				e.ChangeState("burrow");
			}
			else if (num2 > burrowDistance)
			{
				e.ChangeState("burrow");
			}
		}

		public override void OnOffsetEntity(float amount)
		{
			base.OnOffsetEntity(amount);
			wanderTarget.y += amount;
		}
	}
}
