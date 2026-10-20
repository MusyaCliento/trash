using UnityEngine;

[DefaultExecutionOrder(150)]
public class Hand_Base : MonoBehaviour
{
	private bool climbing;

	[HideInInspector]
	public ENT_Player.Hand hand;

	internal Hand_SpriteController[] handSprites;

	public virtual void OnEnable()
	{
		handSprites = base.gameObject.GetComponentsInChildren<Hand_SpriteController>();
	}

	public virtual bool CanClimb()
	{
		return true;
	}

	public virtual void SetClimbing(bool b)
	{
		climbing = b;
	}

	public virtual void LateUpdate()
	{
		ProcessCosmetics();
		if (handSprites != null && handSprites.Length != 0)
		{
			Hand_SpriteController[] array = handSprites;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetStaminaInfo(hand.GetStaminaDrainColor(), hand.GetStaminaDrainOutlineColor(), hand.GetHandOutlineMaskColor(), 1f - hand.gripStrength / hand.GetPlayer().gripStrengthTimer);
			}
		}
	}

	public virtual void ProcessCosmetics()
	{
		if (hand == null || hand.currentCosmetics == null || hand.currentCosmetics.Count <= 0)
		{
			return;
		}
		foreach (Cosmetic_HandItem currentCosmetic in hand.currentCosmetics)
		{
			currentCosmetic.SpriteSwap(base.gameObject, hand);
		}
	}
}
