using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ENV_Vendor_Event : MonoBehaviour
{
	public bool allowPurchases = true;

	public int cost;

	public string id;

	public bool allowMultiplePurchase;

	public SpriteRenderer purchaseSprite;

	public TMP_Text costText;

	private int lastRoaches;

	public CL_Button purchaseButton;

	private bool hasBeenBought;

	public AudioClip purchaseSound;

	public UnityEvent purchaseEvent;

	private void Start()
	{
		CheckRoaches();
	}

	private void Update()
	{
		if (CL_GameManager.GetRoaches() != lastRoaches)
		{
			CheckRoaches();
		}
	}

	public void CheckRoaches()
	{
		if (!allowPurchases)
		{
			return;
		}
		if (id != "")
		{
			CL_GameManager.SessionFlag gameFlag = CL_GameManager.GetGameFlag("usedstation-" + id + "-station");
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
			AudioManager.PlaySound(purchaseSound, base.transform.position);
			purchaseEvent.Invoke();
		}
	}
}
