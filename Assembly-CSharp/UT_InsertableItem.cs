using UnityEngine;
using UnityEngine.Events;

public class UT_InsertableItem : MonoBehaviour, Clickable
{
	public bool active = true;

	public UnityEvent activeEvent;

	[HideInInspector]
	public bool hasBeenPressed;

	public UnityEvent<string> interactEvent;

	public void Interact()
	{
		activeEvent.Invoke();
		interactEvent.Invoke("");
		hasBeenPressed = true;
	}

	public void Interact(Clickable.InteractionInfo info)
	{
		activeEvent.Invoke();
		interactEvent.Invoke(info.interactionString);
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
		if (currentItem != null && currentItem.interactType == Item.InteractType.usable)
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
