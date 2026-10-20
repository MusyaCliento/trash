using UnityEngine;

public class CL_Handhold_Rope : CL_Handhold
{
	private ENV_Rope rope;

	private ENV_Rope_Node node;

	public float swingSpeed = 4f;

	public float swingDrag = 20f;

	public float swingClimb;

	private bool swinging;

	public void InitializeRope(ENV_Rope r, ENV_Rope_Node n)
	{
		rope = r;
		node = n;
	}

	private void FixedUpdate()
	{
		if (!GetHolding())
		{
			return;
		}
		Vector3 zero = Vector3.zero;
		bool flag = false;
		if ((InputManager.GetButton("Sprint").Pressed && !SettingsManager.settings.inverseRopeSwing) || (SettingsManager.settings.inverseRopeSwing && !InputManager.GetButton("Sprint").Pressed))
		{
			flag = true;
		}
		if (SettingsManager.settings.directionalSwing)
		{
			flag = false;
			if (Mathf.Abs(Vector3.Dot(GetPlayer().cam.transform.forward, Vector3.up)) < 0.5f)
			{
				flag = true;
			}
		}
		if (flag)
		{
			swinging = true;
			zero += GetPlayer().transform.forward * InputManager.GetVector("Move").vector.y * swingSpeed * 2.5f;
			zero += GetPlayer().transform.right * InputManager.GetVector("Move").vector.x * swingSpeed * 2.5f;
			foreach (ENT_Player.Hand hand in hands)
			{
				hand.dragMult = swingDrag;
			}
			rope.SetCollision(b: false);
		}
		else
		{
			swinging = false;
			foreach (ENT_Player.Hand hand2 in hands)
			{
				hand2.dragMult = dragMult;
			}
			rope.SetCollision(b: true);
		}
		CalculateFacingValue(base.transform.position, zero.normalized, rope.transform.position);
		rope.lastGrabTime = Time.time;
		rope.AddVelocity(zero);
	}

	private float CalculateFacingValue(Vector3 sourcePosition, Vector3 sourceForward, Vector3 targetPosition)
	{
		sourcePosition.y = 0f;
		targetPosition.y = 0f;
		sourceForward.y = 0f;
		Vector3 normalized = (targetPosition - sourcePosition).normalized;
		return Mathf.Clamp01(Vector3.Dot(sourceForward.normalized, normalized));
	}

	public override void StopInteract(ENT_Player p, ENT_Player.Hand dropHand, string s = "")
	{
		if (s == "jump")
		{
			p.AddForce(rope.GetTargetRigidbody().linearVelocity * 0.02f);
			rope.DropRope();
		}
		base.StopInteract(p, dropHand, s);
	}

	public override void Interact(Clickable.InteractionInfo info)
	{
		Vector3 vector = AddVectorsWithLimit(info.hand.GetPlayer().cCon.velocity * rope.grabVelocityMult, rope.GetTargetRigidbody().linearVelocity);
		Debug.Log("Is Rope in Use: " + GetInUse());
		if (!GetInUse() && Time.time - rope.lastGrabTime > 2f)
		{
			rope.AddVelocity(vector * rope.grabVelocityTransfer);
		}
		rope.lastGrabTime = Time.time;
		rope.GrabRope();
		base.Interact(info);
	}

	private Vector3 AddVectorsWithLimit(Vector3 vector1, Vector3 vector2)
	{
		Vector3 normalized = vector1.normalized;
		float magnitude = vector1.magnitude;
		float num = Vector3.Dot(vector2, normalized);
		float num2 = magnitude;
		float num3 = num + num2;
		if (Mathf.Sign(num) == Mathf.Sign(num2) && num != 0f)
		{
			if (Mathf.Abs(num) >= magnitude)
			{
				num3 = num;
			}
			else if (Mathf.Abs(num3) > magnitude)
			{
				num3 = magnitude * Mathf.Sign(num3);
			}
		}
		else if (Mathf.Abs(num3) > magnitude)
		{
			num3 = (0f - magnitude) * Mathf.Sign(num3);
		}
		return vector2 - normalized * num + normalized * num3;
	}

	public override float GetClimbMult()
	{
		if (swinging)
		{
			return swingClimb;
		}
		return climbMult;
	}
}
