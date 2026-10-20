using System;
using UnityEngine;

[Serializable]
public class Item_InteractionModule
{
	public enum InteractionType
	{
		normal = 0,
		destroyItem = 1,
		swapItem = 2
	}

	public string interactorName;

	public string interactionTag;

	public Sprite interactionSprite;

	public string interactData = "";

	internal bool canInteract = true;

	public bool canFocusFastInteract;

	public InteractionType interactionType;

	public virtual void Interact(Interaction interaction, ref bool interacting, ref InteractHit hit, out Sprite interactSprite)
	{
		if (!canInteract)
		{
			interacting = false;
			interactSprite = null;
		}
		if (interaction.tagger.HasTag(interactionTag))
		{
			interactSprite = interactionSprite;
			if (interaction.clickable != null && interaction.clickable.GetSprite() != null)
			{
				interactSprite = interaction.clickable.GetSprite();
			}
			InputManager.ButtonInput button = InputManager.GetButton(interaction.fireButton);
			if ((!button.Down && (!button.Pressed || interaction.interactSettings == null || !interaction.interactSettings.allowPressHoldInteract || !canFocusFastInteract)) || interacting)
			{
				return;
			}
			Clickable.InteractionInfo interactionInfo = Clickable.InteractionInfo.CreateNewInfo(interaction.curhand.GetPlayer(), interaction.curhand, interactData);
			if (interaction.item.data != null && interaction.item.data.Count > 0)
			{
				interactionInfo.interactionData = interaction.item.data;
			}
			switch (interactionType)
			{
			case InteractionType.normal:
				if (interaction.item.data != null && interaction.item.data.Count > 0)
				{
					interaction.clickable.Interact(interactionInfo);
				}
				else
				{
					interaction.clickable.Interact(interactionInfo);
				}
				break;
			case InteractionType.destroyItem:
				if (interaction.item.data != null && interaction.item.data.Count > 0)
				{
					interaction.clickable.Interact(interactionInfo);
				}
				else
				{
					interaction.clickable.Interact(interactionInfo);
				}
				interaction.curhand.DestroyItem();
				break;
			}
		}
		else
		{
			interactSprite = null;
		}
	}

	public virtual bool CanInteractWithInteractable(Interaction interaction)
	{
		if (interaction.tagger != null)
		{
			bool flag = interaction.tagger.HasTag(interactionTag);
			if (flag)
			{
				flag = interaction.clickable.CanInteract(interaction);
			}
			return flag;
		}
		return false;
	}

	public virtual bool UseGrabMemory()
	{
		return false;
	}
}
