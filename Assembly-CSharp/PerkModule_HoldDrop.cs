public class PerkModule_HoldDrop : PerkModule
{
	public string itemTagToRemove;

	public override void Update()
	{
		base.Update();
		ENT_Player.Hand[] hands = perk.player.hands;
		foreach (ENT_Player.Hand hand in hands)
		{
			if (hand.IsFree() && InputManager.GetButton(hand.fireButton).Pressed)
			{
				HoldDrop(hand);
			}
			UpdateHand(hand);
		}
	}

	public virtual void UpdateHand(ENT_Player.Hand hand)
	{
	}

	public virtual void HoldDrop(ENT_Player.Hand hand)
	{
	}
}
