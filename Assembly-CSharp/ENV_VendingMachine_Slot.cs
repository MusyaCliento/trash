using UnityEngine;
using UnityEngine.Events;

public class ENV_VendingMachine_Slot : MonoBehaviour, Clickable
{
	public bool active = true;

	public UnityEvent activeEvent;

	public UnityEvent<float> activeEventWithAmount;

	public ENV_VendingMachine vendingMachine;

	[HideInInspector]
	public bool hasBeenPressed;

	public void Interact()
	{
		activeEvent.Invoke();
		hasBeenPressed = true;
	}

	public void Interact(Clickable.InteractionInfo info)
	{
		int num = int.Parse(info.interactionString);
		activeEvent.Invoke();
		activeEventWithAmount.Invoke(num);
		if (vendingMachine != null)
		{
			vendingMachine.AddRoaches(num);
		}
		else
		{
			CL_GameManager.AddRoaches(num);
		}
		CL_ScoreManager.sessionScore.AddScore("Roaches Banked", "Roaches Banked", num * 20, 0f, num);
		hasBeenPressed = true;
	}

	public void Reset()
	{
		hasBeenPressed = false;
	}

	public bool CanInteract(Interaction info)
	{
		if (!active)
		{
			return false;
		}
		Item currentItem = info.curhand.inventoryHand.currentItem;
		if (currentItem != null && currentItem.interactType == Item.InteractType.roach)
		{
			return true;
		}
		return false;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public ObjectTagger GetTagger()
	{
		return base.gameObject.GetComponent<ObjectTagger>();
	}

	public void SetInteractable(bool b)
	{
		active = b;
	}
}
