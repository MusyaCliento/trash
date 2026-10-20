using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandItem : Hand_Base
{
	[HideInInspector]
	public Item item;

	public bool active;

	public bool used;

	public Animator anim;

	public bool canUseWhileHanging = true;

	public bool canUseInCutscene;

	public bool useSprintViewSway = true;

	public bool useAimCircle;

	public List<string> useStats;

	[SerializeReference]
	public List<Item_InteractionModule> interactionModules;

	private Item_InteractionModule defaultModule;

	public List<Cosmetic_Item> itemCosmetics;

	internal ViewSway sway;

	internal bool allowInteract = true;

	public bool allowSprintAnimations;

	public string firstGrabFlag = "";

	public UnityEvent firstGrabEvent;

	[SerializeReference]
	public List<SimpleModule> simpleUseModules;

	public UnityEvent itemUseEvent;

	private bool isCurrentlyInteracting;

	public virtual void Initialize(Item i, ENT_Player.Hand h)
	{
		item = i;
		used = i.used;
		hand = h;
		handSprites = base.gameObject.GetComponentsInChildren<Hand_SpriteController>();
		sway = GetComponent<ViewSway>();
		sway.handBase = this;
		UT_AudioClipHandler component = GetComponent<UT_AudioClipHandler>();
		if (component != null)
		{
			component.softParent = h.GetPlayer().cam.transform;
		}
		Item_InteractionModule item_InteractionModule = new Item_InteractionModule();
		item_InteractionModule.interactionTag = "ItemInteractor";
		interactionModules.Add(item_InteractionModule);
		Cosmetic_Item activeItemCosmetic = CL_CosmeticManager.GetActiveItemCosmetic(item.prefabName);
		if (activeItemCosmetic != null)
		{
			itemCosmetics.Add(activeItemCosmetic);
			activeItemCosmetic.SetupHandItem(this);
		}
	}

	public void TryUse()
	{
		if (!isCurrentlyInteracting && !item.HasTag("unpurchased") && (!ENT_Player.GetPlayer().IsInCutsceneMode() || canUseInCutscene))
		{
			Use();
		}
	}

	public virtual void Start()
	{
		if (firstGrabFlag != "" && !CL_GameManager.HasActiveFlag(firstGrabFlag))
		{
			CL_GameManager.SetGameFlag(firstGrabFlag, state: true);
			firstGrabEvent.Invoke();
		}
	}

	public virtual void Use()
	{
		if (canUseWhileHanging || !hand.GetPlayer().IsHanging())
		{
			itemUseEvent.Invoke();
		}
	}

	public virtual void StopUse()
	{
		if (!canUseWhileHanging)
		{
			hand.GetPlayer().IsHanging();
		}
	}

	public virtual void Update()
	{
		if (item.HasTag("unpurchased"))
		{
			CL_UIManager.instance.SetDescription("<color=red>SHOP ITEM");
		}
		isCurrentlyInteracting = false;
		if (!ENT_Player.CanHoldItems())
		{
			ENT_Player.GetPlayer().StashItemsInHand(force: true);
		}
		if (ENT_Player.GetPlayer().IsInFullSprint() && useSprintViewSway)
		{
			if (sway != null)
			{
				sway.SetCustomParameters(ENT_Player.GetPlayer().itemViewSwayParameters);
			}
		}
		else if (sway != null)
		{
			sway.UnsetCustomParameters();
		}
		if (hand.GetHandItem() != null && hand.GetHandItem() != this)
		{
			Object.Destroy(base.gameObject);
		}
	}

	public override void LateUpdate()
	{
		if (itemCosmetics != null && itemCosmetics.Count > 0)
		{
			foreach (Cosmetic_Item itemCosmetic in itemCosmetics)
			{
				if (!(itemCosmetic == null) && itemCosmetic.handItemCosmetic != null)
				{
					itemCosmetic.handItemCosmetic.SpriteSwap(base.gameObject, hand);
				}
			}
		}
		base.LateUpdate();
	}

	internal virtual void UpdateStats()
	{
		item.IsUnlocked();
		foreach (string useStat in useStats)
		{
			StatManager.sessionStats.UpdateStatistic(useStat, 1, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
		}
		item.UpdateProgressionStat();
		CL_ProgressionManager.UpdateUnlocks(showPopups: true);
	}

	public virtual bool ShowAimCircle()
	{
		return useAimCircle;
	}

	public virtual RaycastHit GetAimCircleHit()
	{
		return default(RaycastHit);
	}

	public void SetHandColor(Color c)
	{
		if (handSprites.Length != 0)
		{
			Hand_SpriteController[] array = handSprites;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetColor(c);
			}
		}
	}

	public void SetHandStaminaVisualAmount(float f)
	{
		_ = handSprites.LongLength;
	}

	public override void OnEnable()
	{
	}

	public virtual void Refresh()
	{
	}

	public virtual void OnDrop()
	{
	}

	public virtual bool CanDrop(bool pocket = false)
	{
		return true;
	}

	public virtual void OnTryPocket()
	{
	}

	public virtual void OnTryDrop()
	{
	}

	public virtual void PocketHandItem()
	{
		Inventory.instance.TryPocketItemInHand(hand.id);
	}

	public virtual void RemoveItem()
	{
		item.inventory.DestroyItemInHand(hand.id);
	}

	public virtual void DestroyItemWithoutRemovingFromHand()
	{
		item.ClearCurrentHandItem();
		item.Destroy();
	}

	public virtual void DropItemWithoutRemovingFromHand()
	{
		item.ClearCurrentHandItem();
		item.Drop(base.transform.position, removeFromHand: false);
	}

	public virtual void DestroyOnlyHandItem()
	{
		hand.interactState = ENT_Player.InteractType.none;
		hand.inventoryHand.handModel.targetOffset = Vector3.zero;
		hand.inventoryHand.currentItem = null;
		Object.Destroy(base.gameObject);
	}

	public virtual void Activate()
	{
	}

	internal void Execute(Inventory inventory)
	{
	}

	public int GetDirection()
	{
		if (hand.id <= 0)
		{
			return -1;
		}
		return 1;
	}

	public override bool CanClimb()
	{
		return false;
	}

	public bool HasInteractor()
	{
		if (interactionModules != null)
		{
			return interactionModules.Count > 0;
		}
		return false;
	}

	public virtual bool IsCurrentlyInteracting()
	{
		return isCurrentlyInteracting;
	}

	public virtual bool AllowJump()
	{
		return true;
	}

	public virtual void Interact(Interaction interaction, ref bool interacting, ref InteractHit hit, out Sprite interactSprite)
	{
		if (!allowInteract)
		{
			interacting = false;
			interactSprite = null;
			return;
		}
		Item_InteractionModule item_InteractionModule = null;
		foreach (Item_InteractionModule interactionModule in interactionModules)
		{
			if (interactionModule.CanInteractWithInteractable(interaction))
			{
				item_InteractionModule = interactionModule;
				break;
			}
		}
		if (item_InteractionModule != null)
		{
			item_InteractionModule.Interact(interaction, ref interacting, ref hit, out interactSprite);
			isCurrentlyInteracting = true;
		}
		else
		{
			interactSprite = null;
		}
	}

	public virtual bool UseGrabMemory()
	{
		foreach (Item_InteractionModule interactionModule in interactionModules)
		{
			if (interactionModule.UseGrabMemory())
			{
				return true;
			}
		}
		return false;
	}
}
