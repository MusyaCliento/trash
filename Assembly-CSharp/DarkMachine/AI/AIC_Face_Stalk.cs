using System;
using Drawing;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AIC_Face_Stalk : AIStateComponent
	{
		public float stalkDistance = 20f;

		public float stalkSeekMult = 0.5f;

		public float barkFrequency = 10f;

		private float barkTime;

		public float stalkFrequencyMult = 1f;

		private DEN_Face face;

		private Vector3 targetEnterStart;

		private Vector3 stalkStartPosition;

		private float playerScore;

		private float stalkTime;

		private Vector3 stalkPoint;

		private float stalkTarget = 45f;

		public override string name => "stalk";

		public override void Initialize(AIGameEntity e, AIStateVariable[] variables, string[] args = null)
		{
			base.Initialize(e, variables, args);
			face = (DEN_Face)e;
			targetEnterStart = e.target.position;
		}

		public override void Enter(AIGameEntity e, string[] args)
		{
			base.Enter(e, args);
			playerScore = 0f;
			stalkTime = 0f;
			stalkTarget = 45f + UnityEngine.Random.Range(-10f, 10f);
			stalkStartPosition = e.target.position;
			stalkPoint = e.target.position;
			e.clipHandler.PlaySound("stalk:start");
			barkTime = barkFrequency * (UnityEngine.Random.value + 0.5f);
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
			playerScore = Vector3.Distance(stalkStartPosition, e.target.position) / stalkTime * face.GetAggression();
			stalkTime += Time.deltaTime;
			face.movementModule.seekMult = stalkSeekMult;
			Vector3 planeNormal = targetEnterStart - e.target.position;
			Vector3 vector = Vector3.ProjectOnPlane(e.transform.position - e.target.position, planeNormal).normalized * stalkDistance;
			vector = e.target.position + vector;
			stalkPoint = Vector3.Lerp(stalkPoint, vector, Time.deltaTime * 2f);
			e.SetTargetPosition(vector);
			barkTime -= Time.deltaTime;
			if (barkTime <= 0f)
			{
				barkTime = barkFrequency * (UnityEngine.Random.value + 0.5f);
				e.clipHandler.PlaySound("face:bark");
			}
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Cross(targetEnterStart, 0.3f, new Color(0f, 1f, 0f, 1f));
				CL_DebugView.draw.Label2D(targetEnterStart + Vector3.up * 0.3f, "Player Start Target", 8f, LabelAlignment.Center, Color.red);
				CL_DebugView.draw.Cross(vector, 0.3f, new Color(0f, 1f, 0f, 1f));
				CL_DebugView.draw.Label2D(vector + Vector3.up * 0.3f, "Stalk Target", 8f, LabelAlignment.Center, Color.red);
				CL_DebugView.draw.DashedLine(e.transform.position, vector, 0.2f, 0.2f, Color.red);
				CL_DebugView.draw.Label2D(e.transform.position + Vector3.up * 0.3f, "State: Stalking", 8f, LabelAlignment.Center, Color.red);
			}
			if (stalkTime > 10f && !face.avoidPlayer && ENT_Player.GetPlayer().curBuffs.GetBuff("massResist") < 1f && (stalkTime > stalkTarget / stalkFrequencyMult || playerScore * stalkFrequencyMult > 5f))
			{
				if (UnityEngine.Random.value > 0.25f)
				{
					e.ChangeState("hunt");
				}
				else
				{
					e.ChangeState("block");
				}
			}
		}

		public override void OnOffsetEntity(float amount)
		{
			base.OnOffsetEntity(amount);
			targetEnterStart.y += amount;
			stalkStartPosition.y += amount;
			stalkPoint.y += amount;
		}
	}
}
