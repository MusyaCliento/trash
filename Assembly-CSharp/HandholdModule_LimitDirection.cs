using UnityEngine;

public class HandholdModule_LimitDirection : HandholdModule
{
	public Vector3 normal = Vector3.up;

	public float maxAngle = 90f;

	public bool hideHandhold = true;

	public bool canDropHands;

	private Collider[] handholdColliders;

	public override void Initialize(CL_Handhold h)
	{
		base.Initialize(h);
		handholdColliders = h.GetComponents<Collider>();
	}

	private bool IsOverAngle(Transform transform)
	{
		if (Vector3.Angle(transform.TransformVector(normal), Vector3.up) > maxAngle)
		{
			return true;
		}
		return false;
	}

	public override void LateUpdate()
	{
		base.LateUpdate();
		if (hideHandhold && handholdColliders != null)
		{
			Collider[] array = handholdColliders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = !IsOverAngle(handhold.transform);
			}
		}
		if (canDropHands && handhold.GetHolding() && IsOverAngle(handhold.transform))
		{
			handhold.ForceDropHands();
		}
	}

	public override bool CanInteract(ENT_Player p, ENT_Player.Hand hand)
	{
		return !IsOverAngle(handhold.transform);
	}
}
