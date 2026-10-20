using System;
using Drawing;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AIC_Face_Block : AIStateComponent
	{
		public float blockDistance = 20f;

		public float blockSeekMult = 0.5f;

		private DEN_Face face;

		private Vector3 targetEnterStart;

		private float playerScore;

		private float stalkTime;

		private Vector3 stalkPoint;

		public override string name => "block";

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
			e.clipHandler.PlaySound("block:start");
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
			playerScore = Vector3.Distance(targetEnterStart, e.target.position) / stalkTime;
			stalkTime += Time.deltaTime;
			face.movementModule.seekMult = blockSeekMult;
			Vector3 vector = targetEnterStart - e.target.position;
			Vector3 vector2 = ((e.transform.position - e.target.position).normalized - vector.normalized).normalized * blockDistance;
			vector2 = e.target.position + vector2;
			stalkPoint = Vector3.Lerp(stalkPoint, vector2, Time.deltaTime * 2f);
			e.SetTargetPosition(vector2);
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Cross(targetEnterStart, 0.3f, new Color(0f, 1f, 0f, 1f));
				CL_DebugView.draw.Label2D(targetEnterStart + Vector3.up * 0.3f, "Player Start Target", 8f, LabelAlignment.Center, Color.red);
				CL_DebugView.draw.Cross(vector2, 0.3f, new Color(0f, 1f, 0f, 1f));
				CL_DebugView.draw.Label2D(vector2 + Vector3.up * 0.3f, "Block Target", 8f, LabelAlignment.Center, Color.red);
				CL_DebugView.draw.DashedLine(e.transform.position, vector2, 0.2f, 0.2f, Color.red);
				CL_DebugView.draw.Label2D(e.transform.position + Vector3.up * 0.3f, "State: Blocking", 8f, LabelAlignment.Center, Color.red);
			}
			if (stalkTime > 10f && (stalkTime > 45f || playerScore > 5f))
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
