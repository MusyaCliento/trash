using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ENV_VendingMachine : MonoBehaviour, Damageable, Seedable, SaveableObject
{
	[Serializable]
	public class Purchase
	{
		public string name;

		public float chance = 1f;

		public SpawnTable.SpawnSettings spawnSettings;

		public Item_Object itemObject;

		public List<GameObject> spawnAssets;

		public int price;

		public Sprite purchaseSprite;

		public string requiredItemTag;

		public bool competitive = true;

		public bool ignoreUnlocked;
	}

	[Serializable]
	public class VendingButton
	{
		public SpriteRenderer sprite;

		public TMP_Text text;

		public Purchase purchase;

		public bool available;
	}

	[Serializable]
	public class VendingPurchaseData
	{
		public bool available;

		public string name;
	}

	[Serializable]
	public class VendorSaveData
	{
		public bool isDead;

		public VendingPurchaseData[] purchaseData;
	}

	public string vendorId;

	public Transform spawnSpot;

	public bool singlePurchase = true;

	public bool randomGeneration = true;

	public bool fillFromPurchaseListInOrder;

	public bool ignoreRequirements;

	public List<Purchase> purchaseList;

	public Transform[] counters;

	public VendingButton[] buttons;

	public Color availableColor;

	public Color outColor;

	public Color unaffordableColor;

	public Renderer meshRenderer;

	public Material destroyedMaterial;

	public int destroyedMaterialIndex;

	public Sprite destroyedButtonSprite;

	private int lastRoaches;

	private int[] digits;

	private UT_AudioClipHandler clipHandler;

	private int localSeed;

	private bool hasGenerated;

	public UnityEvent onDestroy;

	private bool dead;

	private bool isBlocked;

	public void Start()
	{
		if (base.transform.lossyScale.x < 0f)
		{
			base.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		clipHandler = GetComponent<UT_AudioClipHandler>();
		lastRoaches = 0;
		if (!hasGenerated)
		{
			if (randomGeneration)
			{
				GenerateOptions();
			}
			UpdateButtons();
		}
	}

	private void OnEnable()
	{
		digits = GetDigits(CL_GameManager.GetRoaches());
		UpdateButtons();
	}

	public void Update()
	{
		if (CL_GameManager.HasActiveFlag("blockshops"))
		{
			if (!isBlocked)
			{
				isBlocked = true;
				UpdateButtons();
			}
		}
		else if (isBlocked)
		{
			isBlocked = false;
			UpdateButtons();
		}
		if (lastRoaches != CL_GameManager.GetRoaches())
		{
			digits = GetDigits(CL_GameManager.GetRoaches());
			UpdateButtons();
			lastRoaches = CL_GameManager.GetRoaches();
		}
		RollCounters();
	}

	private void RegenerateOptions()
	{
		GenerateOptions();
		UpdateButtons();
	}

	private void GenerateOptions()
	{
		List<Purchase> list = new List<Purchase>();
		if (!ignoreRequirements)
		{
			for (int num = purchaseList.Count - 1; num > 0; num--)
			{
				if (purchaseList[num].itemObject != null)
				{
					if (purchaseList[num].requiredItemTag != "" && !Inventory.instance.HasItemWithTag(purchaseList[num].requiredItemTag))
					{
						purchaseList.RemoveAt(num);
					}
					else if (!CL_GameManager.GetCurrentGamemode().IsCompetitive() && !purchaseList[num].itemObject.itemData.IsUnlocked())
					{
						purchaseList.RemoveAt(num);
					}
					else if (CL_GameManager.GetCurrentGamemode().IsCompetitive() && !purchaseList[num].competitive)
					{
						purchaseList.RemoveAt(num);
					}
				}
			}
		}
		int num2 = 0;
		while (list.Count < buttons.Length)
		{
			Purchase purchase = null;
			if (fillFromPurchaseListInOrder)
			{
				purchase = purchaseList[num2];
				num2++;
				if (num2 >= purchaseList.Count)
				{
					num2 = 0;
				}
			}
			else
			{
				purchase = purchaseList[UnityEngine.Random.Range(0, purchaseList.Count)];
			}
			if (fillFromPurchaseListInOrder || UnityEngine.Random.value < purchase.chance * purchase.spawnSettings.GetEffectiveSpawnChance())
			{
				list.Add(purchase);
				buttons[list.Count - 1].purchase = purchase;
			}
		}
		hasGenerated = true;
	}

	private void UpdateButtons()
	{
		VendingButton[] array = buttons;
		foreach (VendingButton vendingButton in array)
		{
			if (dead || isBlocked)
			{
				vendingButton.sprite.sprite = destroyedButtonSprite;
				vendingButton.sprite.color = unaffordableColor;
				continue;
			}
			vendingButton.sprite.sprite = vendingButton.purchase.purchaseSprite;
			if (!vendingButton.available)
			{
				vendingButton.sprite.color = outColor;
			}
			else if (vendingButton.purchase.price > CL_GameManager.GetRoaches())
			{
				vendingButton.sprite.color = unaffordableColor;
			}
			else
			{
				vendingButton.sprite.color = availableColor;
			}
			string text = "";
			for (int j = 0; j < vendingButton.purchase.price; j++)
			{
				text += ".";
			}
			vendingButton.text.text = text;
		}
	}

	public void AddRoaches(int i)
	{
		CL_GameManager.AddRoaches(i);
		clipHandler.PlaySound("vending:kaching");
		digits = GetDigits(CL_GameManager.GetRoaches());
		UpdateButtons();
	}

	private void RollCounters()
	{
		if (Time.timeScale < 0.8f)
		{
			return;
		}
		if (digits == null)
		{
			digits = new int[3];
		}
		for (int i = 0; i < counters.Length; i++)
		{
			Transform transform = counters[i];
			int num = 0;
			if (digits.Length > i)
			{
				num = digits[i] * -36;
			}
			if (Quaternion.Angle(Quaternion.Euler(num, 0f, 0f), transform.localRotation) > 10f)
			{
				clipHandler.PlaySound("vending:ticker");
			}
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(num, 0f, 0f), Time.deltaTime * 8f);
		}
	}

	private int[] GetDigits(int number)
	{
		List<int> list = new List<int>();
		while (number > 0)
		{
			list.Add(number % 10);
			number /= 10;
		}
		return list.ToArray();
	}

	public void Buy(int i)
	{
		Buy(i, false, false);
	}

	public void Buy(int i, bool force = false, bool free = false)
	{
		if (!force)
		{
			if (dead || isBlocked)
			{
				clipHandler.PlaySound("vending:broken");
				return;
			}
			if (!buttons[i].available || buttons[i].purchase.price > CL_GameManager.GetRoaches())
			{
				clipHandler.PlaySound("vending:deny");
				return;
			}
		}
		if (singlePurchase && !force)
		{
			buttons[i].available = false;
		}
		List<GameObject> list = new List<GameObject>();
		if (buttons[i].purchase.spawnAssets == null || buttons[i].purchase.spawnAssets.Count == 0)
		{
			list.Add(buttons[i].purchase.itemObject.gameObject);
		}
		else
		{
			list = buttons[i].purchase.spawnAssets;
		}
		foreach (GameObject item in list)
		{
			GameObject obj = UnityEngine.Object.Instantiate(item, spawnSpot.position, spawnSpot.rotation, base.transform.parent);
			ObjectTagger component = obj.GetComponent<ObjectTagger>();
			if (component != null)
			{
				component.AddTag("Vended");
			}
			Rigidbody component2 = obj.GetComponent<Rigidbody>();
			if (component2 != null)
			{
				component2.isKinematic = false;
				component2.linearVelocity = spawnSpot.forward * 5f;
			}
		}
		if (!free)
		{
			AddRoaches(-buttons[i].purchase.price);
		}
		clipHandler.PlaySound("vending:approve");
		UpdateButtons();
	}

	public void SetSeed(int seed)
	{
		localSeed = seed;
	}

	public bool CanSave(string[] flags = null)
	{
		if (flags != null)
		{
			Debug.Log("Vendor Flag: " + flags[0]);
			if (flags[0] == "savetype:disk")
			{
				return false;
			}
		}
		return vendorId != "";
	}

	public SaveableInfo GetSaveInfo()
	{
		SaveableInfo saveableInfo = new SaveableInfo();
		saveableInfo.id = vendorId;
		VendorSaveData vendorSaveData = new VendorSaveData();
		vendorSaveData.isDead = dead;
		vendorSaveData.purchaseData = new VendingPurchaseData[buttons.Length];
		for (int i = 0; i < buttons.Length; i++)
		{
			vendorSaveData.purchaseData[i] = new VendingPurchaseData();
			vendorSaveData.purchaseData[i].available = buttons[i].available;
			vendorSaveData.purchaseData[i].name = buttons[i].purchase.name;
		}
		saveableInfo.data = JsonUtility.ToJson(vendorSaveData);
		return saveableInfo;
	}

	public void SetSaveInfo(SaveableInfo info, List<string> flags)
	{
		VendorSaveData vendorSaveData = JsonUtility.FromJson<VendorSaveData>(info.data);
		VendingPurchaseData[] purchaseData = vendorSaveData.purchaseData;
		if (vendorSaveData.purchaseData.Length != buttons.Length)
		{
			return;
		}
		for (int i = 0; i < buttons.Length; i++)
		{
			foreach (Purchase purchase in purchaseList)
			{
				if (purchase.name == purchaseData[i].name)
				{
					buttons[i].purchase = purchase;
					break;
				}
			}
			buttons[i].available = purchaseData[i].available;
		}
		if (vendorSaveData.isDead)
		{
			Material[] materials = meshRenderer.materials;
			materials[destroyedMaterialIndex] = destroyedMaterial;
			meshRenderer.SetMaterials(materials.ToList());
			dead = true;
			onDestroy?.Invoke();
			UpdateButtons();
		}
		hasGenerated = true;
		UpdateButtons();
	}

	public string GetSaveID()
	{
		return vendorId;
	}

	public bool Damage(Damageable.DamageInfo info)
	{
		Debug.Log("Vendor damaged!");
		if (dead)
		{
			return false;
		}
		if (!info.type.Contains("explosion"))
		{
			return false;
		}
		Kill();
		return true;
	}

	public void Kill(string type = "")
	{
		dead = true;
		Debug.Log("Vendor Destroyed!");
		onDestroy.Invoke();
		clipHandler.PlaySound("vending:destroy");
		UpdateButtons();
		StartCoroutine(DeadBuy());
		IEnumerator DeadBuy()
		{
			yield return new WaitForSeconds(0.3f);
			CL_CameraControl.ShakeAtPosition(base.transform.position, 0.2f, 30f);
			Material[] materials = meshRenderer.materials;
			materials[destroyedMaterialIndex] = destroyedMaterial;
			meshRenderer.SetMaterials(materials.ToList());
			Buy(UnityEngine.Random.Range(0, buttons.Length), force: true, free: true);
			yield return new WaitForSeconds(0.8f);
			CL_CameraControl.ShakeAtPosition(base.transform.position, 0.1f, 30f);
			Buy(UnityEngine.Random.Range(0, buttons.Length), force: true, free: true);
			UpdateButtons();
		}
	}

	public GameObject GetGameObject()
	{
		throw new NotImplementedException();
	}
}
