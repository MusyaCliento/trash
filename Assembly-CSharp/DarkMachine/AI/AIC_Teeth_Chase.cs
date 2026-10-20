using System.Collections;
using Drawing;
using UnityEngine;

namespace DarkMachine.AI
{
	public class AIC_Teeth_Chase : AIStateComponent
	{
		public DEN_Teeth teeth;

		private float attackTime = 1f;

		private bool canAttackTarget;

		private float timeSinceLastSawTarget;

		private float fearCheckTick;

		private float currentFear;

		private float maxFear = 4.5f;

		private bool hasKilledPlayer;

		private float stunTime;

		private float timeSinceSeenLight;

		public override string name => "chase";

		public override void Initialize(AIGameEntity e, AIStateVariable[] variables, string[] args = null)
		{
			base.Initialize(e, variables, args);
			teeth = e.GetComponent<DEN_Teeth>();
		}

		public override void Enter(AIGameEntity e, string[] args = null)
		{
			base.Enter(e, args);
			Debug.Log("Entered chase state for " + e.name);
			e.clipHandler.PlaySound("teeth:startChase");
			currentFear = 0f;
			teeth.locked = false;
			teeth.curBarkTime = Random.Range(teeth.barkTime / 2f, teeth.barkTime * 2f);
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
			if (hasKilledPlayer)
			{
				return;
			}
			if (e.target == null)
			{
				e.ChangeState("wander");
				return;
			}
			teeth.anim.SetBool("afraid", value: false);
			teeth.curBarkTime -= Time.deltaTime;
			timeSinceSeenLight += Time.deltaTime;
			if (teeth.curBarkTime <= 0f)
			{
				teeth.curBarkTime = Random.Range(teeth.barkTime / 2f, teeth.barkTime * 2f);
				e.clipHandler.PlaySound("teeth:bark");
			}
			teeth.SetCohesionEffect(currentFear * 0.1f + teeth.aggression * 0.1f);
			teeth.SetBurnEffect(currentFear - 1f);
			if (fearCheckTick <= 0f)
			{
				float highestEffectorFearRating = CL_Lamp.GetHighestEffectorFearRating(teeth.geoRoot.position);
				if (highestEffectorFearRating > 0f)
				{
					currentFear += highestEffectorFearRating / teeth.aggression;
					if (highestEffectorFearRating > 0.5f)
					{
						if (timeSinceSeenLight > 4f)
						{
							stunTime = 2f;
							e.clipHandler.PlaySound("teeth:reacttolight");
							CL_CameraControl.ShakeAtPosition(e.transform.position, 20f, 0.18f);
						}
						timeSinceSeenLight = 0f;
					}
					if (currentFear > maxFear)
					{
						Debug.Log("Feared!");
						e.clipHandler.PlaySound("teeth:bark");
						currentFear = 0f;
						teeth.speedMult = 2.3f / teeth.aggression;
						teeth.locked = false;
						teeth.anim.SetBool("afraid", value: false);
						e.ChangeState("retreat");
						return;
					}
				}
				else
				{
					currentFear = Mathf.Max(currentFear - 1f, 0f);
				}
				fearCheckTick = 1f;
			}
			else
			{
				fearCheckTick -= Time.deltaTime;
			}
			if (stunTime > 0f)
			{
				stunTime -= Time.deltaTime;
				teeth.anim.SetBool("afraid", value: true);
				teeth.locked = true;
				teeth.speedMult = 0f;
				return;
			}
			teeth.locked = false;
			teeth.anim.SetBool("afraid", value: false);
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Label2D(e.transform.position + Vector3.up * 0.6f, "Fear: " + currentFear, 8f, LabelAlignment.Center, Color.white);
			}
			teeth.speedMult = 1f - currentFear / maxFear * 0.25f;
			bool flag = e.sight.CanSeeTarget(e.target);
			if (flag)
			{
				if (timeSinceLastSawTarget > 4f)
				{
					e.clipHandler.PlaySound("teeth:locateTarget");
				}
				timeSinceLastSawTarget = 0f;
				if (e.targetPosition.y < teeth.transform.position.y - 5f)
				{
					teeth.speedMult *= 2f;
				}
				else if (e.targetPosition.y > teeth.transform.position.y + 15f)
				{
					teeth.speedMult *= 2f;
				}
			}
			else
			{
				timeSinceLastSawTarget += Time.deltaTime;
			}
			if (!flag && !e.sight.CanRemember())
			{
				e.clipHandler.PlaySound("teeth:endChase");
				teeth.charging = false;
				e.ChangeState("wander");
				return;
			}
			if (!flag && e.sight.CanRemember())
			{
				e.SetTargetPosition(e.sight.GetLastSeenPosition());
				if (CL_UIManager.debug)
				{
					CL_DebugView.draw.Cross(e.sight.GetLastSeenPosition(), 0.3f, new Color(0f, 1f, 0f, 1f));
					CL_DebugView.draw.Label2D(e.sight.GetLastSeenPosition() + Vector3.up * 0.3f, "Investigate Target", 8f, LabelAlignment.Center, Color.white);
				}
				teeth.charging = false;
				return;
			}
			e.SetTargetPosition(e.target.position);
			float num = Vector3.Distance(e.target.position, e.transform.position);
			if (num < 10f)
			{
				if (num < 3f)
				{
					teeth.locked = true;
					teeth.charging = true;
				}
				else
				{
					teeth.locked = false;
					teeth.speedMult = 1f;
					teeth.charging = false;
				}
				GameEntity component = e.target.GetComponent<GameEntity>();
				if (num < 3.75f)
				{
					if (!canAttackTarget)
					{
						canAttackTarget = true;
						attackTime = 1f;
					}
					if (component != null && attackTime <= 0f)
					{
						teeth.anim.SetTrigger("attack");
						teeth.clipHandler.PlaySound("teeth:attack");
						float num2 = teeth.attackDamage;
						if (CL_GameManager.IsHardmode())
						{
							num2 *= 2f;
						}
						if (component.Damage(Damageable.DamageInfo.CreateDamageInfo(num2, "teeth")))
						{
							hasKilledPlayer = true;
							e.StartCoroutine(KillPlayerAnimation());
						}
						attackTime = 0.5f;
						component.AddForce(-(e.transform.position - component.transform.position).normalized * 0.5f, "denizen");
					}
					component.AddForce((e.transform.position - component.transform.position).normalized * Time.deltaTime * 0.3f, "denizen");
				}
				if (!(component != null))
				{
				}
			}
			else
			{
				canAttackTarget = false;
			}
			if (attackTime > 0f)
			{
				attackTime -= Time.deltaTime;
			}
		}

		private IEnumerator KillPlayerAnimation()
		{
			teeth.clipHandler.PlaySound("teeth:killplayer");
			teeth.speedMult = 0f;
			bool value = 0f < Vector3.Dot((teeth.transform.position - ENT_Player.playerObject.cam.transform.position).normalized, ENT_Player.playerObject.cam.transform.forward);
			teeth.anim.SetBool("playerfacing", value);
			teeth.anim.SetTrigger("killplayer");
			ENT_Player.playerObject.DropEverything();
			ENT_Player.playerObject.Lock();
			CL_GameManager.gMan.lockPlayer = true;
			teeth.locked = true;
			Camera playerCam = ENT_Player.playerObject.cam;
			ENT_Player.playerObject.DropEverything();
			float anim = 0f;
			ParticleSystem.EmissionModule emission = teeth.screenHandEffect.emission;
			emission.rateOverTimeMultiplier = 15f;
			Vector3 camStartPos = playerCam.transform.position;
			Quaternion camStartRot = playerCam.transform.rotation;
			while (anim < 1f)
			{
				ENT_Player.playerObject.Lock();
				anim += Time.deltaTime / 2f;
				playerCam.transform.position = Vector3.Lerp(camStartPos, teeth.cameraTakeover.position, anim);
				playerCam.transform.rotation = Quaternion.Lerp(camStartRot, teeth.cameraTakeover.rotation, anim);
				yield return null;
			}
			anim = 0f;
			CL_CameraControl.Shake(0.1f);
			while (anim < 2.8f)
			{
				ENT_Player.playerObject.Lock();
				anim += Time.deltaTime;
				playerCam.transform.position = teeth.cameraTakeover.position;
				playerCam.transform.rotation = teeth.cameraTakeover.rotation;
				yield return null;
			}
			teeth.clipHandler.PlaySound("teeth:killchomp");
			ENT_Player.playerObject.Kill("teeth");
		}

		public override void Exit(AIGameEntity e, string[] args = null)
		{
			base.Exit(e, args);
		}
	}
}
