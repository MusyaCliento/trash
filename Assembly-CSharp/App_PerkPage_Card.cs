using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class App_PerkPage_Card : MonoBehaviour, ISelectHandler, IEventSystemHandler, ISubmitHandler, IPointerClickHandler
{
	public Perk perk;

	private Button button;

	private App_PerkPage perkPage;

	private OS_Tooltip tooltip;

	public TMP_Text titleText;

	public TMP_Text costText;

	public Transform costRoot;

	public Transform purchasedText;

	private bool active = true;

	private bool locked;

	public Image cardArt;

	public Image frameArt;

	public Outline outline;

	private void Update()
	{
	}

	public void Initialize(App_PerkPage page, Perk p)
	{
		button = GetComponent<Button>();
		tooltip = GetComponent<OS_Tooltip>();
		purchasedText.gameObject.SetActive(value: false);
		perkPage = page;
		this.perk = p;
		string text = "";
		Perk perk = ENT_Player.playerObject.GetPerk(this.perk.id);
		if (perk != null)
		{
			text = $"<color=\"grey\"> ({perk.stackAmount + 1})";
		}
		tooltip.tip = this.perk.GetTitle(includeColor: true) + text + "\n<color=#C7C7C7>" + this.perk.GetDescription(adjusted: true) + "</color>";
		cardArt.sprite = this.perk.perkCard;
		frameArt.sprite = this.perk.perkFrame;
		titleText.text = this.perk.title;
		UpdateCard();
	}

	public void CheckCost()
	{
		if (!locked && active)
		{
			if (perk.cost > 0)
			{
				costText.text = perk.cost.ToString();
			}
			else
			{
				costRoot.gameObject.SetActive(value: false);
			}
		}
	}

	void ISubmitHandler.OnSubmit(BaseEventData eventData)
	{
		if (!locked && active && CanAfford())
		{
			Submit();
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		if (!locked && active && CanAfford())
		{
			Select();
		}
	}

	public void Select()
	{
		if (!locked && active && CanAfford())
		{
			OS_Manager.activeComputer.audioClipHandler.PlaySound("perk:highlight");
			perkPage.SelectCard(this);
		}
	}

	public void Submit()
	{
		if (!locked && active && CanAfford())
		{
			OS_Manager.activeComputer.audioClipHandler.PlaySound("perk:select");
			perkPage.SubmitCard(this);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!locked && active && CanAfford())
		{
			Submit();
		}
	}

	public void SubmitCard()
	{
		if (!locked && active && CanAfford())
		{
			cardArt.color = Color.white;
			frameArt.color = Color.white;
			titleText.color = Color.red;
			outline.effectColor = Color.red;
			DOTween.Complete(base.transform);
			base.transform.DOScale(1f, 0.2f);
			base.transform.DOPunchRotation(new Vector3(0f, 0f, 1f), 0.5f);
			base.transform.DOPunchScale(Vector3.one * 0.05f, 0.2f);
		}
	}

	public void SelectCard()
	{
		if (!locked && active && CanAfford())
		{
			cardArt.color = Color.white;
			frameArt.color = Color.white;
			titleText.color = Color.white;
			outline.effectColor = Color.clear;
			DOTween.Complete(base.transform);
			base.transform.DOScale(1f, 0.2f);
			base.transform.DOPunchRotation(new Vector3(0f, 0f, 1f), 0.5f);
		}
	}

	public void DeselectCard()
	{
		if (!locked && active && CanAfford())
		{
			cardArt.color = Color.grey;
			frameArt.color = Color.grey;
			outline.effectColor = Color.clear;
			DOTween.Complete(base.transform);
			titleText.color = Color.grey;
			base.transform.DOScale(0.95f, 0.2f);
		}
	}

	public void DisableCard()
	{
		active = false;
		titleText.color = Color.red;
		DOTween.Complete(base.transform);
		cardArt.color = Color.red;
		frameArt.color = Color.red;
	}

	public void LockCard()
	{
		locked = true;
		DOTween.Complete(base.transform);
		base.transform.DOScale(1f, 0.2f);
	}

	public void BuyCard()
	{
		purchasedText.gameObject.SetActive(value: true);
		purchasedText.localScale = Vector3.zero;
		DOTween.Complete(base.transform);
		purchasedText.DOScale(1f, 0.5f);
		base.transform.DOPunchRotation(new Vector3(0f, 0f, 2f), 0.5f);
		CL_GameManager.AddRoaches(-perk.cost);
	}

	public void UpdateCard()
	{
		CheckCost();
		if (active && !locked && CL_GameManager.GetRoaches() < perk.cost)
		{
			cardArt.color = Color.red;
			frameArt.color = Color.red;
			titleText.color = Color.red;
		}
	}

	public bool CanAfford()
	{
		return CL_GameManager.GetRoaches() >= perk.cost;
	}
}
