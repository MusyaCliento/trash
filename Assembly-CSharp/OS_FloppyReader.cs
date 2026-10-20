using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class OS_FloppyReader : MonoBehaviour, Clickable
{
	public bool active = true;

	public UnityEvent activeEvent;

	public OS_Computer_Interface computerInterface;

	[Range(0f, 1f)]
	public float audioVolume = 1f;

	public AudioClip insertStart;

	public AudioClip insertFinish;

	[HideInInspector]
	public bool hasBeenPressed;

	public void Interact()
	{
		activeEvent.Invoke();
		hasBeenPressed = true;
	}

	public void Interact(Clickable.InteractionInfo info)
	{
		Interact();
	}

	public void InsertFloppy(ENT_Player p, Item floppy)
	{
		Interact();
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
		computerInterface.GetComputer().LoadFloppy(floppy);
		AudioManager.PlaySound(insertFinish, base.transform.position, audioVolume);
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
