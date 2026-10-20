using System;
using DarkMachine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CosmeticInfoPanel : MonoBehaviour
{
	public UI_CosmeticsMenu menu;

	public UI_CosmeticButton cosmeticButton;

	public Cosmetic_Base selectedCosmetic;

	public Sprite defaultHandSprite;

	public Sprite activeHandSprite;

	public Material defaultHandMaterial;

	public Image handIcon;

	public TMP_Text nameText;

	public TMP_Text authorText;

	public TMP_Text descText;

	public TMP_Text debugText;

	public GameObject settingRoot;

	public GameObject paletteRoot;

	public Image paletteTexture;

	public SubmitSlider accessorySlider;

	public SubmitSlider hueSlider;

	public SubmitSlider saturationSlider;

	public SubmitSlider valueSlider;

	public Action OnCloseMenu;

	public CanvasGroup parentGroup;

	public Material handMaterial;

	private bool isPressed;

	public void Open(Cosmetic_Base cosmetic)
	{
		parentGroup.interactable = false;
		base.gameObject.SetActive(value: true);
		paletteRoot.SetActive(value: false);
		cosmeticButton?.Initialize(cosmetic, menu);
		selectedCosmetic = cosmetic;
		if (cosmetic.GetInfoSprite() == null)
		{
			handIcon.sprite = defaultHandSprite;
		}
		else
		{
			handIcon.sprite = cosmetic.GetInfoSprite();
		}
		if (handMaterial != null)
		{
			UnityEngine.Object.Destroy(handMaterial);
		}
		handMaterial = UnityEngine.Object.Instantiate(defaultHandMaterial);
		handMaterial.CopyPropertiesFromMaterial(defaultHandMaterial);
		handIcon.material = handMaterial;
		handIcon.material.CopyPropertiesFromMaterial(defaultHandMaterial);
		nameText.text = cosmetic.cosmeticInfo.cosmeticName;
		authorText.text = cosmetic.cosmeticInfo.author;
		descText.text = cosmetic.cosmeticInfo.description;
		UpdateSprite();
		handIcon.material.SetFloat("_IgnoreWorld", 1f);
	}

	private void Update()
	{
		if (!(selectedCosmetic.cosmeticInfo.tag == "hand"))
		{
			return;
		}
		if (InputManager.GetButton("Hand-Left").Pressed)
		{
			if (!isPressed)
			{
				handIcon.sprite = activeHandSprite;
				UpdateSprite();
				isPressed = true;
			}
		}
		else if (isPressed)
		{
			handIcon.sprite = defaultHandSprite;
			UpdateSprite();
			isPressed = false;
		}
		Cosmetic_HandItem cosmetic_HandItem = selectedCosmetic as Cosmetic_HandItem;
		if (handIcon.material != null && cosmetic_HandItem != null)
		{
			if (handIcon.material.HasFloat("_StaminaAmount"))
			{
				handIcon.material.SetFloat("_StaminaAmount", Mathf.Sin(Time.unscaledTime * 1.5f) * 4f - 3f);
			}
			if (cosmetic_HandItem.cosmeticData.useCustomStaminaColor && handIcon.material.HasColor("_StaminaColor"))
			{
				handIcon.material.SetColor("_StaminaColor", cosmetic_HandItem.cosmeticData.customStaminaColor);
			}
			if (cosmetic_HandItem.cosmeticData.useCustomStaminaOutlineColor && handIcon.material.HasColor("_StaminaOutlineColor"))
			{
				handIcon.material.SetColor("_StaminaOutlineColor", cosmetic_HandItem.cosmeticData.customStaminaOutlineColor);
			}
		}
	}

	public void UpdateSprite()
	{
		bool active = false;
		if (selectedCosmetic.cosmeticInfo.tag == "hand")
		{
			Cosmetic_HandItem cosmetic_HandItem = selectedCosmetic as Cosmetic_HandItem;
			cosmetic_HandItem.SwapUISprite(handIcon);
			handIcon.material.SetFloat("_IgnoreWorld", 1f);
			if (cosmetic_HandItem.cosmeticData.palettes != null && cosmetic_HandItem.cosmeticData.palettes.Count > 0)
			{
				debugText.text = cosmetic_HandItem.cosmeticData.palettes[cosmetic_HandItem.currentPaletteId].title + $" ({cosmetic_HandItem.currentPaletteId + 1}/{cosmetic_HandItem.cosmeticData.palettes.Count})";
				paletteTexture.material.SetTexture("_OverlayMult", cosmetic_HandItem.cosmeticData.palettes[cosmetic_HandItem.currentPaletteId].texture);
				paletteRoot.SetActive(value: true);
			}
			else
			{
				paletteRoot.SetActive(value: false);
			}
			if (selectedCosmetic.cosmeticInfo.flags != null && selectedCosmetic.cosmeticInfo.flags.Contains("setting-hsv"))
			{
				active = true;
				hueSlider.transform.parent.gameObject.SetActive(value: true);
				hueSlider.value = cosmetic_HandItem.cosmeticData.hsv.x;
				saturationSlider.value = cosmetic_HandItem.cosmeticData.hsv.y;
				valueSlider.value = cosmetic_HandItem.cosmeticData.hsv.z;
			}
			else
			{
				hueSlider.transform.parent.gameObject.SetActive(value: false);
			}
		}
		if (paletteRoot.activeSelf)
		{
			active = true;
		}
		if (selectedCosmetic.cosmeticInfo.flags != null && selectedCosmetic.cosmeticInfo.flags.Contains("accessories"))
		{
			active = true;
			accessorySlider.transform.parent.gameObject.SetActive(value: true);
			accessorySlider.value = selectedCosmetic.accessoryOpacity;
		}
		else
		{
			accessorySlider.transform.parent.gameObject.SetActive(value: false);
		}
		settingRoot.gameObject.SetActive(active);
	}

	public void Close()
	{
		parentGroup.interactable = true;
		base.gameObject.SetActive(value: false);
	}

	public void ChangePalette()
	{
		if (selectedCosmetic.cosmeticInfo.tag == "hand")
		{
			Cosmetic_HandItem cosmetic_HandItem = selectedCosmetic as Cosmetic_HandItem;
			cosmetic_HandItem.SwapPalette();
			UpdateCosmeticSaveData();
			debugText.text = "Palette: " + cosmetic_HandItem.currentPaletteId;
			cosmetic_HandItem.SwapUISprite(handIcon);
			if (cosmetic_HandItem.cosmeticData.palettes != null && cosmetic_HandItem.cosmeticData.palettes.Count > 0)
			{
				debugText.text = cosmetic_HandItem.cosmeticData.palettes[cosmetic_HandItem.currentPaletteId].title + $" ({cosmetic_HandItem.currentPaletteId + 1}/{cosmetic_HandItem.cosmeticData.palettes.Count})";
				paletteTexture.material.SetTexture("_OverlayMult", cosmetic_HandItem.cosmeticData.palettes[cosmetic_HandItem.currentPaletteId].texture);
			}
			handIcon.material.SetFloat("_IgnoreWorld", 1f);
		}
	}

	public void SetOpacity(float o)
	{
		if (selectedCosmetic.cosmeticInfo.tag == "hand")
		{
			(selectedCosmetic as Cosmetic_HandItem).accessoryOpacity = o;
			UpdateCosmeticSaveData();
		}
	}

	public void SetHue(float h)
	{
		if (selectedCosmetic.cosmeticInfo.tag == "hand")
		{
			Cosmetic_HandItem cosmetic_HandItem = selectedCosmetic as Cosmetic_HandItem;
			cosmetic_HandItem.cosmeticData.hsv.x = h;
			UpdateCosmeticSaveData();
			handIcon.material.SetVector("_HSV", cosmetic_HandItem.cosmeticData.hsv);
		}
	}

	public void SetSaturation(float v)
	{
		if (selectedCosmetic.cosmeticInfo.tag == "hand")
		{
			Cosmetic_HandItem cosmetic_HandItem = selectedCosmetic as Cosmetic_HandItem;
			cosmetic_HandItem.cosmeticData.hsv.y = v;
			UpdateCosmeticSaveData();
			handIcon.material.SetVector("_HSV", cosmetic_HandItem.cosmeticData.hsv);
		}
	}

	public void SetValue(float v)
	{
		if (selectedCosmetic.cosmeticInfo.tag == "hand")
		{
			Cosmetic_HandItem cosmetic_HandItem = selectedCosmetic as Cosmetic_HandItem;
			cosmetic_HandItem.cosmeticData.hsv.z = v;
			UpdateCosmeticSaveData();
			handIcon.material.SetVector("_HSV", cosmetic_HandItem.cosmeticData.hsv);
		}
	}

	private void UpdateCosmeticSaveData()
	{
		CL_CosmeticManager.CosmeticSaveData.GetCosmeticSaveData().UpdateCosmeticData(selectedCosmetic, selectedCosmetic.GetCosmeticSaveData());
	}
}
