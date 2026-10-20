using UnityEngine;
using UnityEngine.Events;

public class Item_InteractionModule_Recharger : Item_InteractionModule
{
	public string rechargeDataName = "uses";

	public string rechargeMaxDataName = "maxuses";

	public float rechargeMaxAmount;

	public UnityEvent rechargeEvent;

	public override void Interact(Interaction interaction, ref bool interacting, ref InteractHit hit, out Sprite interactSprite)
	{
		if (interaction.tagger.HasTag(interactionTag))
		{
			UT_ItemRecharger component = interaction.hitCollider.GetComponent<UT_ItemRecharger>();
			if (component != null)
			{
				if (component.CanRecharge())
				{
					if (InputManager.GetButton(interaction.fireButton).Down && !interacting)
					{
						component.Recharge(interaction.item, rechargeDataName, rechargeMaxDataName);
						rechargeEvent.Invoke();
					}
					interactSprite = interactionSprite;
					interacting = true;
				}
				else
				{
					interactSprite = null;
				}
				return;
			}
		}
		interactSprite = null;
	}

	public override bool CanInteractWithInteractable(Interaction interaction)
	{
		UT_ItemRecharger component = interaction.hitCollider.GetComponent<UT_ItemRecharger>();
		if (component == null || !component.CanRecharge())
		{
			return false;
		}
		return base.CanInteractWithInteractable(interaction);
	}
}
