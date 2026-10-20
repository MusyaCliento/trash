using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UT_InsertableFloppy : MonoBehaviour, Clickable
{
	public bool active = true;

	public UnityEvent<Item> activeEvent;

	public UnityEvent<Item> insertFinishEvent;

	[Range(0f, 1f)]
	public float audioVolume = 1f;

	public AudioClip insertStart;

	public AudioClip insertFinish;

	[HideInInspector]
	public bool hasBeenPressed;

	public void Interact(Clickable.InteractionInfo info)
	{
		Item arg = null;
		if (info.hand != null && info.hand.GetHandItem() != null)
		{
			arg = info.hand.GetHandItem().item;
		}
		activeEvent.Invoke(arg);
		hasBeenPressed = true;
	}

	public void InsertFloppy(ENT_Player p, Item floppy)
	{
		activeEvent.Invoke(floppy);
		hasBeenPressed = true;
		StartCoroutine(InsertAnimation(floppy));
	}

	private IEnumerator InsertAnimation(Item floppy)
	{
		floppy.GetDropObject().GetComponent<Rigidbody>().isKinematic = true;
		floppy.GetDropObject().canPickup = false;
		floppy.GetDropObject().transform.position = base.transform.position;
		floppy.GetDropObject().transform.rotation = base.transform.rotation;
		yield return new WaitForSeconds(0.5f);
		AudioManager.PlaySound(insertStart, base.transform.position, audioVolume);
		float insertAmount = 0f;
		while (insertAmount < 1f)
		{
			insertAmount += Time.deltaTime;
			floppy.GetDropObject().transform.position += floppy.GetDropObject().transform.forward * Time.deltaTime * 0.2f;
			yield return null;
		}
		AudioManager.PlaySound(insertFinish, base.transform.position, audioVolume);
		insertFinishEvent.Invoke(floppy);
		Object.Destroy(floppy.GetDropObject().gameObject);
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
