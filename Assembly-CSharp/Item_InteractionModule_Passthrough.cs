using System.Collections.Generic;
using UnityEngine;

public class Item_InteractionModule_Passthrough : Item_InteractionModule
{
	public List<string> requiredTags;

	public bool allowGrabMemory;

	public override void Interact(Interaction interaction, ref bool interacting, ref InteractHit hit, out Sprite interactSprite)
	{
		if (!canInteract)
		{
			interacting = false;
			interactSprite = null;
		}
		else if (interaction.tagger.HasTagInList(requiredTags.ToArray()))
		{
			ENT_Player.playerObject.Interact(interaction, ref interacting, ref hit, out interactSprite);
		}
		else
		{
			interactSprite = null;
		}
	}

	public override bool CanInteractWithInteractable(Interaction interaction)
	{
		if (interaction.tagger.HasTagInList(requiredTags.ToArray()))
		{
			return true;
		}
		return false;
	}

	public override bool UseGrabMemory()
	{
		return allowGrabMemory;
	}
}
