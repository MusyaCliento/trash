using UnityEngine;

public class Item_InteractionModule_Floppy : Item_InteractionModule
{
	public override void Interact(Interaction interaction, ref bool interacting, ref InteractHit hit, out Sprite interactSprite)
	{
		if (interaction.tagger.HasTag(interactionTag))
		{
			interactSprite = interactionSprite;
			OS_FloppyReader component = interaction.clickable.GetGameObject().GetComponent<OS_FloppyReader>();
			UT_InsertableFloppy component2 = interaction.clickable.GetGameObject().GetComponent<UT_InsertableFloppy>();
			UT_InsertableItem uT_InsertableItem = null;
			if (component == null)
			{
				uT_InsertableItem = interaction.clickable.GetGameObject().GetComponent<UT_InsertableItem>();
			}
			if ((!(component != null) || !component.CanInteract(interaction)) && (!(component2 != null) || !component2.CanInteract(interaction)) && (!(uT_InsertableItem != null) || !uT_InsertableItem.CanInteract(interaction)))
			{
				interactSprite = null;
			}
			InputManager.ButtonInput button = InputManager.GetButton(interaction.fireButton);
			if ((button.Down || (interaction.interactSettings != null && interaction.interactSettings.allowPressHoldInteract && button.Pressed)) && !interacting)
			{
				if (component != null)
				{
					interaction.curhand.DropItem(component.transform.position);
					component.InsertFloppy(interaction.curhand.GetPlayer(), interaction.item);
				}
				else if (component2 != null)
				{
					interaction.curhand.DropItem(component2.transform.position);
					component2.InsertFloppy(interaction.curhand.GetPlayer(), interaction.item);
				}
				else if (uT_InsertableItem != null && uT_InsertableItem.CanInteract(interaction))
				{
					interaction.curhand.DestroyItem();
					uT_InsertableItem.Interact();
				}
			}
		}
		else
		{
			interactSprite = null;
		}
	}
}
