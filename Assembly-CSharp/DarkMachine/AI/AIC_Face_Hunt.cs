using System;
using Drawing;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AIC_Face_Hunt : AIStateComponent
	{
		public float huntSpeedMult = 2f;

		public float huntSeekAggressionBonus = 2f;

		public float huntLength = 15f;

		public float huntRoarShake = 0.1f;

		private DEN_Face face;

		private float huntTime;

		public float targetAlertRoarDistance = 15f;

		private bool hasRoared;

		private float timeSinceRoar = 10f;

		private float timeSinceChomp = 10f;

		public override string name => "hunt";

		public override void Enter(AIGameEntity e, string[] args)
		{
			base.Enter(e, args);
			face = (DEN_Face)e;
			e.clipHandler.PlaySound("hunt:start");
			CL_CameraControl.Shake(huntRoarShake);
			timeSinceRoar = 10f;
			huntTime = 0f;
			timeSinceChomp = 10f;
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
			if (CL_GameManager.noTarget)
			{
				e.ChangeState("stalk");
				return;
			}
			e.SetTargetPosition(e.target.position);
			float num = Vector3.Distance(e.transform.position, e.target.position);
			if (num < 25f)
			{
				huntTime += Time.deltaTime;
			}
			timeSinceChomp += Time.deltaTime;
			float num2 = huntTime / huntLength;
			float seekMult = huntSpeedMult + num2 * huntSeekAggressionBonus;
			face.movementModule.seekMult = seekMult;
			if (!hasRoared && num < targetAlertRoarDistance)
			{
				hasRoared = true;
				e.clipHandler.PlaySound("hunt:roar");
				CL_CameraControl.Shake(huntRoarShake);
			}
			else if (hasRoared && num > targetAlertRoarDistance + 20f)
			{
				hasRoared = false;
			}
			if (num < 3f && timeSinceChomp > 8f)
			{
				e.clipHandler.PlaySound("hunt:chomp");
				timeSinceChomp = 0f;
			}
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Label2D(e.transform.position + Vector3.up * 0.3f, "State: Hunting", 8f, LabelAlignment.Center, Color.red);
				CL_DebugView.draw.Label2D(e.transform.position + Vector3.up * 0.8f, $"Aggro: {num2 * 100f}%", 8f, LabelAlignment.Center, Color.red);
			}
			if (huntTime > huntLength)
			{
				e.ChangeState("stalk");
			}
		}

		public void AddHuntTime(float f)
		{
			huntTime += f;
		}
	}
}
