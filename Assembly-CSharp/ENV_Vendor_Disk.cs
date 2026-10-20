using System.Collections;
using TMPro;
using UnityEngine;

public class ENV_Vendor_Disk : MonoBehaviour
{
	public Item_Object purchaseObject;

	public bool allowPurchases = true;

	public int cost;

	public string id;

	public bool allowMultiplePurchase;

	public SpriteRenderer purchaseSprite;

	public TMP_Text costText;

	private int lastRoaches;

	public CL_Button purchaseButton;

	private bool hasBeenBought;

	public Transform diskSpawn;

	public AudioClip floppyEject;

	private bool isBlocked;

	private void Start()
	{
		CheckRoaches();
	}

	private void Update()
	{
		CheckBlock();
		if (CL_GameManager.GetRoaches() != lastRoaches)
		{
			CheckRoaches();
		}
	}

	public void CheckBlock()
	{
		if (hasBeenBought)
		{
			return;
		}
		if (CL_GameManager.HasActiveFlag("blockshops"))
		{
			if (!isBlocked)
			{
				isBlocked = true;
				purchaseButton.SetInteractable(b: false);
				costText.text = "UNAVAILABLE";
			}
		}
		else if (isBlocked)
		{
			isBlocked = false;
			CheckRoaches();
		}
	}

	public void CheckRoaches()
	{
		if (!allowPurchases || isBlocked)
		{
			return;
		}
		if (id != "")
		{
			CL_GameManager.SessionFlag gameFlag = CL_GameManager.GetGameFlag("boughtdisk-" + id + "-station");
			if (!hasBeenBought && gameFlag != null && gameFlag.state)
			{
				hasBeenBought = true;
				costText.text = "THANK YOU FOR YOUR PURCHASE";
				purchaseSprite.gameObject.SetActive(value: false);
			}
		}
		if (hasBeenBought)
		{
			purchaseButton.SetInteractable(b: false);
			return;
		}
		lastRoaches = CL_GameManager.GetRoaches();
		costText.text = $"Cost:{cost} Bank:{CL_GameManager.GetRoaches().ToString()}";
		if (cost > CL_GameManager.GetRoaches())
		{
			purchaseButton.SetInteractable(b: false);
		}
		else
		{
			purchaseButton.SetInteractable(b: true);
		}
	}

	public void Purchase()
	{
		if (isBlocked)
		{
			return;
		}
		purchaseButton.SetInteractable(b: false);
		if (!hasBeenBought && cost <= CL_GameManager.GetRoaches())
		{
			CL_GameManager.AddRoaches(-cost);
			hasBeenBought = true;
			costText.text = "THANK YOU FOR YOUR PURCHASE";
			purchaseSprite.gameObject.SetActive(value: false);
			if (!allowMultiplePurchase && id != "")
			{
				CL_GameManager.SetGameFlag("boughtdisk-" + id + "-station", state: true);
			}
			SpawnDisk();
		}
	}

	public void SpawnDisk()
	{
		StartCoroutine(PurchaseSequence());
	}

	private IEnumerator PurchaseSequence()
	{
		float ejectTime = 0f;
		Item_Object item = Object.Instantiate(purchaseObject, diskSpawn.position, diskSpawn.rotation, base.transform.parent);
		item.GetComponent<Rigidbody>().isKinematic = true;
		AudioManager.PlaySound(floppyEject, base.transform.position);
		while (ejectTime < 1f)
		{
			ejectTime += Time.deltaTime;
			if (item.gameObject.activeInHierarchy)
			{
				item.transform.position = Vector3.Lerp(diskSpawn.position, diskSpawn.position + diskSpawn.forward * 0.5f, ejectTime);
				yield return null;
				continue;
			}
			break;
		}
	}
}
