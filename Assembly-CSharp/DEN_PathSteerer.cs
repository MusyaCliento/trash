using System.Collections.Generic;
using DarkMachine.AI;
using Drawing;
using UnityEngine;

public class DEN_PathSteerer : Denizen
{
	public AIC_SimpleCreature_PathFollow wanderState;

	public DenizenMovement_SteeringVehicle movementModule;

	public Animator animator;

	private Rigidbody rigid;

	public float barkRate;

	private float barkTime;

	public float animatorMoveDirMultiplier = 1f;

	private float moveDir;

	public override void Start()
	{
		base.Start();
		rigid = GetComponent<Rigidbody>();
		target = ENT_Player.playerObject.transform;
		movementModule.Initialize(this);
		movementModule.Start();
		aiStates = new List<AIStateComponent> { wanderState };
		foreach (AIStateComponent aiState in aiStates)
		{
			aiState.Initialize(this, stateVariables);
		}
		if (base.transform.lossyScale.x < 0f)
		{
			base.transform.localScale = Vector3.Scale(base.transform.localScale, new Vector3(-1f, 1f, 1f));
		}
		ChangeState("wander");
	}

	public override void Update()
	{
		base.Update();
		if (!dead)
		{
			barkTime -= Time.deltaTime;
			if (barkTime <= 0f)
			{
				barkTime = Random.Range(barkRate, barkRate * 2f);
				clipHandler.PlaySound("denizen:bark");
			}
			currentState.Execute(this);
			movementModule.targetPosition = GetTargetPosition();
			movementModule.currentPosition = base.transform.position;
			movementModule.Update();
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(movementModule.GetVelocity()), Time.deltaTime * 0.5f);
			float num = Vector3.Dot(base.transform.right, (GetTargetPosition() - base.transform.position).normalized);
			num *= animatorMoveDirMultiplier;
			num = num * 0.5f + 0.5f;
			moveDir = Mathf.Lerp(moveDir, num, Time.deltaTime * 3f);
			animator.SetFloat("MoveDir", moveDir);
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Label2D(base.transform.position + Vector3.up, "State:" + currentState.name, Color.yellow);
				CL_DebugView.draw.Arrow(base.transform.position, GetTargetPosition(), Color.red);
				CL_DebugView.draw.Label2D(base.transform.position + Vector3.up * 2f, "MoveDir:" + moveDir, Color.yellow);
			}
		}
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		clipHandler.PlaySound("denizen:hurt");
		if (info.HasTag("hammer"))
		{
			rigid.AddForce(Vector3.up * 5f, ForceMode.VelocityChange);
		}
		barkTime = barkRate * 2f;
		info.amount = 0f;
		return base.Damage(info);
	}

	public override void Kill(string type = "", Damageable.DamageInfo info = null)
	{
		if (!dead)
		{
			base.Kill(type, info);
			barkTime = barkRate * 2f;
			animator.SetTrigger("Die");
			clipHandler.PlaySound("denizen:die");
		}
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		base.AddForce(v);
		rigid.AddForce(v * 10f);
	}

	private new void OnCollisionEnter(Collision collision)
	{
		_ = dead;
	}

	public override void ChangeState(string state)
	{
		base.ChangeState(state);
	}

	public void CalculatePaths()
	{
		wanderState.CalculatePaths();
	}

	public override void DrawGizmos()
	{
		if (wanderState.pathRoot == null || wanderState.pathNodes == null)
		{
			return;
		}
		for (int i = 0; i < wanderState.pathNodes.Count; i++)
		{
			Transform obj = wanderState.pathNodes[i];
			int num = i + 1;
			if (num >= wanderState.pathNodes.Count)
			{
				num = 0;
			}
			Transform transform = wanderState.pathNodes[num];
			Draw.WireSphere(wanderState.pathNodes[i].position, 0.5f);
			Draw.Arrow(obj.position, transform.position, Color.green);
		}
	}
}
