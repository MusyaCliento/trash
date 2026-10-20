using System;
using Drawing;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AIC_Face_Dive : AIStateComponent
	{
		public float diveDistance = 20f;

		public float diveSeekMult = 0.5f;

		public float diveLength = 30f;

		private DEN_Face face;

		private Vector3 targetEnterStart;

		private float playerScore;

		private float stalkTime;

		private Vector3 stalkPoint;

		public override string name => "dive";

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
			stalkPoint = e.target.position;
			e.clipHandler.PlaySound("dive:start");
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
			if (CL_GameManager.GetBaseGamemode().HasTag("endless") && !CL_GameManager.IsIronKnuckle() && CL_GameManager.GetPlayerTravelDistance() > 10000f)
			{
				e.ChangeState("stalk");
				return;
			}
			playerScore = Vector3.Distance(targetEnterStart, e.target.position) / stalkTime;
			stalkTime += Time.deltaTime;
			face.movementModule.seekMult = diveSeekMult;
			_ = targetEnterStart - e.target.position;
			Vector3 vector = Vector3.down * diveDistance;
			vector = e.target.position + vector;
			stalkPoint = Vector3.Lerp(stalkPoint, vector, Time.deltaTime * 2f);
			e.SetTargetPosition(vector);
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Cross(targetEnterStart, 0.3f, new Color(0f, 1f, 0f, 1f));
				CL_DebugView.draw.Label2D(targetEnterStart + Vector3.up * 0.3f, "Player Start Target", 8f, LabelAlignment.Center, Color.red);
				CL_DebugView.draw.Cross(vector, 0.3f, new Color(0f, 1f, 0f, 1f));
				CL_DebugView.draw.Label2D(vector + Vector3.up * 0.3f, "Dive Target", 8f, LabelAlignment.Center, Color.red);
				CL_DebugView.draw.DashedLine(e.transform.position, vector, 0.2f, 0.2f, Color.red);
				CL_DebugView.draw.Label2D(e.transform.position + Vector3.up * 0.3f, "State: Diving", 8f, LabelAlignment.Center, Color.red);
			}
			if (stalkTime > diveLength)
			{
				e.ChangeState("hunt");
			}
		}

		public override void OnOffsetEntity(float amount)
		{
			base.OnOffsetEntity(amount);
			targetEnterStart.y += amount;
			stalkPoint.y += amount;
		}
	}
}
