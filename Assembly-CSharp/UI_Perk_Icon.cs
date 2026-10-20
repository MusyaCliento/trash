using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Perk_Icon : MonoBehaviour
{
	private Perk perk;

	private Material mat;

	public TMP_Text text;

	public TMP_Text counter;

	public GameObject imageObject;

	public OS_Tooltip tooltipComponent;

	public bool destroyIfNotOnPlayer = true;

	public bool worldPerkIcon = true;

	private string lastCounterText = "";

	public void SetPerk(Perk p)
	{
		perk = p;
		if (imageObject == null)
		{
			imageObject = base.gameObject;
		}
		SpriteRenderer component = imageObject.GetComponent<SpriteRenderer>();
		if (component != null)
		{
			if (perk.iconMat != null)
			{
				mat = Object.Instantiate(perk.iconMat);
			}
			else
			{
				mat = Object.Instantiate(component.material);
			}
			component.sprite = perk.icon;
			component.material = mat;
		}
		else
		{
			Image component2 = imageObject.GetComponent<Image>();
			mat = Object.Instantiate(component2.material);
			component2.sprite = perk.icon;
			component2.material = mat;
		}
		text.text = "";
		if (base.gameObject.activeInHierarchy)
		{
			base.transform.DOPunchScale(Vector3.one * 0.15f, 0.5f, 8, 0.7f).SetUpdate(isIndependentUpdate: true);
		}
		UpdateDescription();
	}

	private void Update()
	{
		if (perk == null || (destroyIfNotOnPlayer && (!perk.IsActive() || (destroyIfNotOnPlayer && ENT_Player.GetPlayer() != null && !ENT_Player.GetPlayer().HasPerk(perk.id)))))
		{
			Object.Destroy(base.gameObject);
			return;
		}
		mat.SetFloat("_Amount", perk.GetBarValue());
		Color color = Color.white;
		float value = 0f;
		if (perk.perkType == Perk.PerkType.orange)
		{
			ColorUtility.TryParseHtmlString("#f4cc56", out color);
			value = 3f;
		}
		else if (perk.perkType == Perk.PerkType.unstable)
		{
			ColorUtility.TryParseHtmlString("#ed8e8e", out color);
			value = 2f;
		}
		else if (perk.perkType == Perk.PerkType.delta)
		{
			ColorUtility.TryParseHtmlString("#54FFBD", out color);
			value = 5f;
		}
		else if (perk.perkType == Perk.PerkType.trinket)
		{
			ColorUtility.TryParseHtmlString("#FF8AFF", out color);
			value = 5f;
		}
		else
		{
			_ = perk.perkType;
			_ = 9;
		}
		mat.SetFloat("_Shimmer", value);
		mat.SetColor("_ShimmerColor", color);
		if (perk.GetStackAmount() > 1)
		{
			text.text = perk.GetStackAmount() + "x";
		}
		else
		{
			text.text = "";
		}
		if (counter != null)
		{
			string perkModuleCounterText = perk.GetPerkModuleCounterText();
			if (perkModuleCounterText != lastCounterText)
			{
				lastCounterText = perkModuleCounterText;
				counter.text = perkModuleCounterText;
			}
		}
		if (worldPerkIcon && ENT_Player.playerObject.camRoot.CanSeeTarget(base.transform, 3f))
		{
			UI_InventoryPerkText.SetText("<b>" + perk.GetTitle(includeColor: true) + "</b>\n" + perk.GetDescription(adjusted: true, total: true, includeFlavor: false));
		}
	}

	public void UpdateDescription()
	{
		if (tooltipComponent != null)
		{
			tooltipComponent.tip = "<b>" + perk.GetTitle(includeColor: true) + "</b>\n" + perk.GetDescription(adjusted: true, total: true, includeFlavor: false);
		}
	}
}
