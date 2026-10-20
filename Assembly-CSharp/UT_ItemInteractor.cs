using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UT_ItemInteractor : MonoBehaviour, Clickable
{
	private bool canInteract;

	public Sprite interactSprite;

	public bool destroyItemOnInteract;

	public bool dropItemOnInteract;

	public bool disableOnInteract;

	public Transform dropPlacer;

	public bool parentToPlacer;

	public UnityEvent<Item> interactEvent;

	private bool playerHasItemInHand;

	public UnityEvent EventOnPlayerHasItem;

	public UnityEvent EventOnPlayerHasNoItem;

	public bool onlyActivateOnHandInteractionStep;

	public bool useInventoryScaleOnDrop;

	public bool useLockboxScaleOnDrop;

	public List<string> interactBlockList;

	public List<string> interactWhiteList;

	public bool allowBlockedInteraction;

	public UnityEvent onBlockInteraction;

	public Sprite interactBlockSprite;

	private void Start()
	{
		ENT_Player.Hand[] hands = ENT_Player.GetPlayer().hands;
		foreach (ENT_Player.Hand obj in hands)
		{
			obj._OnStartHandInteraction = (Action<ENT_Player.Hand>)Delegate.Combine(obj._OnStartHandInteraction, new Action<ENT_Player.Hand>(OnHandInteractionPhaseEnter));
			obj._OnEndHandInteraction = (Action<ENT_Player.Hand>)Delegate.Combine(obj._OnEndHandInteraction, new Action<ENT_Player.Hand>(OnHandInteractionPhaseExit));
		}
		if (onlyActivateOnHandInteractionStep)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (playerHasItemInHand && !ENT_Player.GetPlayer().HasItemInAnyHand())
		{
			playerHasItemInHand = false;
			EventOnPlayerHasNoItem.Invoke();
		}
		else if (!playerHasItemInHand && ENT_Player.GetPlayer().HasItemInAnyHand())
		{
			playerHasItemInHand = true;
			EventOnPlayerHasItem.Invoke();
		}
	}

	private void OnHandInteractionPhaseEnter(ENT_Player.Hand hand)
	{
		if (onlyActivateOnHandInteractionStep && hand.inventoryHand.HasItem())
		{
			base.gameObject.SetActive(value: true);
		}
	}

	private void OnHandInteractionPhaseExit(ENT_Player.Hand hand)
	{
		if (onlyActivateOnHandInteractionStep)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		if (!(ENT_Player.GetPlayer() == null))
		{
			ENT_Player.Hand[] hands = ENT_Player.GetPlayer().hands;
			foreach (ENT_Player.Hand obj in hands)
			{
				obj._OnStartHandInteraction = (Action<ENT_Player.Hand>)Delegate.Remove(obj._OnStartHandInteraction, new Action<ENT_Player.Hand>(OnHandInteractionPhaseEnter));
				obj._OnEndHandInteraction = (Action<ENT_Player.Hand>)Delegate.Remove(obj._OnEndHandInteraction, new Action<ENT_Player.Hand>(OnHandInteractionPhaseExit));
			}
		}
	}

	public void Interact(Clickable.InteractionInfo info)
	{
		Item item = info.hand.GetHandItem().item;
		if (item != null)
		{
			if (allowBlockedInteraction)
			{
				if (interactWhiteList != null && interactWhiteList.Count > 0 && !item.HasTagInList(interactWhiteList))
				{
					onBlockInteraction.Invoke();
					return;
				}
				if (interactBlockList != null && interactBlockList.Count > 0 && item.HasTagInList(interactBlockList))
				{
					onBlockInteraction.Invoke();
					return;
				}
			}
			if (!info.hand.GetHandItem().CanDrop())
			{
				return;
			}
			if (destroyItemOnInteract)
			{
				interactEvent.Invoke(item);
				item.Destroy();
				return;
			}
			if (dropItemOnInteract)
			{
				info.hand.DropItem();
				info.hand.SetHandWait(0.25f);
				if (dropPlacer != null)
				{
					item.GetDropObject().transform.position = dropPlacer.transform.position;
					item.GetDropObject().transform.rotation = dropPlacer.transform.rotation;
					if (parentToPlacer)
					{
						item.GetDropObject().transform.parent = dropPlacer;
					}
				}
				DEN_BasicDenizen component = item.GetDropObject().GetComponent<DEN_BasicDenizen>();
				if (component != null && component.sight != null)
				{
					component.sight.useMemory = true;
					component.sight.infiniteMemory = true;
				}
				if (useInventoryScaleOnDrop || useLockboxScaleOnDrop)
				{
					item.GetDropObject().StopAllCoroutines();
					float num = 1f;
					if (useInventoryScaleOnDrop)
					{
						num *= item.inventoryScale;
					}
					if (useLockboxScaleOnDrop)
					{
						num *= item.lockboxScale;
					}
					item.GetDropObject().transform.localScale = Vector3.one * num;
				}
			}
			if (disableOnInteract)
			{
				DisableObject();
			}
		}
		interactEvent.Invoke(item);
	}

	public void Reset()
	{
	}

	public bool CanInteract(Interaction info)
	{
		if (info.curhand.GetHandItem() != null)
		{
			if (!allowBlockedInteraction)
			{
				if (interactWhiteList != null && interactWhiteList.Count > 0 && info.item != null && !info.item.HasTagInList(interactWhiteList))
				{
					return false;
				}
				if (interactBlockList != null && interactBlockList.Count > 0 && info.item != null && info.item.HasTagInList(interactBlockList))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public void DisableObject()
	{
		if (!(ENT_Player.GetPlayer() == null))
		{
			ENT_Player.Hand[] hands = ENT_Player.GetPlayer().hands;
			foreach (ENT_Player.Hand obj in hands)
			{
				obj._OnStartHandInteraction = (Action<ENT_Player.Hand>)Delegate.Remove(obj._OnStartHandInteraction, new Action<ENT_Player.Hand>(OnHandInteractionPhaseEnter));
				obj._OnEndHandInteraction = (Action<ENT_Player.Hand>)Delegate.Remove(obj._OnEndHandInteraction, new Action<ENT_Player.Hand>(OnHandInteractionPhaseExit));
			}
			base.gameObject.SetActive(value: false);
		}
	}

	public Sprite GetSprite()
	{
		return interactSprite;
	}
}
