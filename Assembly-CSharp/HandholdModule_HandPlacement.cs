using UnityEngine;

public class HandholdModule_HandPlacement : HandholdModule
{
	public Transform leftHandPlacement;

	public Transform rightHandPlacement;

	public override void OnGrab(ENT_Player p, ENT_Player.Hand hand, Clickable.InteractionInfo info = null)
	{
		base.OnGrab(p, hand, info);
	}

	public override void Update()
	{
		base.Update();
		if (!handhold.GetHolding())
		{
			return;
		}
		foreach (ENT_Player.Hand hand in handhold.hands)
		{
			if (hand.id == 0)
			{
				hand.SetWorldHoldPosition(leftHandPlacement.position);
			}
			else
			{
				hand.SetWorldHoldPosition(rightHandPlacement.position);
			}
		}
	}
}
