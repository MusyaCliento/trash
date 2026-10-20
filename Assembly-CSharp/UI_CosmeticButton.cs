using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_CosmeticButton : MonoBehaviour
{
	public Image buttonOutline;

	public Image cardImage;

	public Image foregroundImage;

	public TMP_Text authorText;

	public GameObject handButtonRoot;

	public Button mainButton;

	public Image leftHandButton;

	public Image rightHandButton;

	public Image settingsButtonImage;

	public Button settingsButton;

	public GameObject settingsPressHint;

	public Button playSoundButton;

	public Sprite defaultBackground;

	public Sprite defaultForeground;

	private bool leftHand;

	private bool rightHand;

	private bool isSelected;

	public bool selectAnimation = true;

	private UI_CosmeticsMenu cosmeticsMenu;

	private Cosmetic_Base cosmetic;

	public GameObject lockRoot;

	public TMP_Text lockText;

	public UnityEvent OnActivate;

	public UnityEvent OnDeactivate;

	public bool showAuthor = true;

	private void Awake()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
	}

	private void OnDestroy()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
	}

	public void Initialize(Cosmetic_Base handCosmetic, UI_CosmeticsMenu cM)
	{
		cosmetic = handCosmetic;
		cosmeticsMenu = cM;
		ProgressionUnlock unlock = cosmetic.GetUnlock();
		bool flag = cosmetic.IsUnlocked() || unlock == null;
		if (unlock != null)
		{
			lockText.text = unlock.unlockHint;
		}
		if (unlock == null && !flag)
		{
			Debug.LogError("Cosmetic Error: No Unlock Condition Found: " + cosmetic.cosmeticInfo.unlock);
		}
		lockRoot.SetActive(!flag);
		handButtonRoot.gameObject.SetActive(flag);
		mainButton.interactable = flag;
		if (cardImage != null)
		{
			if (handCosmetic.cosmeticInfo.cardBackground == null)
			{
				cardImage.color = Color.black;
				foregroundImage.sprite = null;
				cardImage.sprite = defaultBackground;
			}
			else
			{
				cardImage.sprite = handCosmetic.cosmeticInfo.cardBackground;
				cardImage.color = Color.white;
			}
			if (handCosmetic.cosmeticInfo.cardForeground == null)
			{
				foregroundImage.color = Color.black;
				authorText.text = cosmetic.cosmeticInfo.id;
				foregroundImage.sprite = defaultForeground;
			}
			else
			{
				if (showAuthor)
				{
					authorText.text = handCosmetic.cosmeticInfo.author;
				}
				else
				{
					authorText.text = "";
				}
				foregroundImage.sprite = handCosmetic.cosmeticInfo.cardForeground;
			}
		}
		if (cosmetic.GetCosmeticType() == "voice")
		{
			settingsButton.gameObject.SetActive(value: false);
			playSoundButton.gameObject.SetActive(value: true);
			settingsPressHint.SetActive(value: false);
		}
		if (cosmetic.GetCosmeticType() != "hand")
		{
			leftHandButton.gameObject.SetActive(value: false);
			rightHandButton.gameObject.SetActive(value: false);
		}
		else
		{
			leftHandButton.gameObject.SetActive(value: true);
			rightHandButton.gameObject.SetActive(value: true);
		}
		Refresh();
	}

	private void OnEnable()
	{
		Refresh();
	}

	private void Update()
	{
		if (cosmetic != null && cosmetic.IsUnlocked() == lockRoot.activeSelf)
		{
			Initialize(cosmetic, cosmeticsMenu);
		}
		if (!(foregroundImage != null))
		{
			return;
		}
		if (isSelected)
		{
			if (cosmetic.GetCosmeticType() == "hand" && (cosmetic as Cosmetic_HandItem).cosmeticData.useCustomStaminaColor)
			{
				foregroundImage.color = Color.Lerp(Color.white, (cosmetic as Cosmetic_HandItem).cosmeticData.customStaminaColor, Mathf.Sin(Time.time * 2f));
			}
			else
			{
				foregroundImage.color = Color.Lerp(Color.white, Color.red, Mathf.Sin(Time.time * 2f) * 0.5f + 0.5f);
			}
			if (settingsButton != null)
			{
				settingsButtonImage.color = Color.Lerp(settingsButtonImage.color, Color.white, Time.deltaTime * 5f);
				settingsPressHint.SetActive(value: true);
				settingsButton.interactable = true;
			}
		}
		else
		{
			foregroundImage.color = Color.white;
			if (settingsButton != null)
			{
				settingsButtonImage.color = Color.clear;
				settingsPressHint.SetActive(value: false);
				settingsButton.interactable = false;
			}
		}
	}

	public void Select(int hand)
	{
		if (cosmetic.GetCosmeticType() == "hand")
		{
			SettingsManager.settings.cosmeticSaveData.ToggleHandCosmetic(cosmetic as Cosmetic_HandItem, hand);
		}
		SettingsManager.RefreshSettings();
		DOTween.Complete(base.transform);
		if (selectAnimation)
		{
			base.transform.DOPunchScale(Vector3.one * 0.05f, 0.4f, 6);
		}
		if (settingsButton != null)
		{
			settingsButtonImage.color = Color.clear;
		}
	}

	public void Select()
	{
		if (cosmetic.GetCosmeticType() == "hand")
		{
			SettingsManager.settings.cosmeticSaveData.ActivateHandCosmetic(cosmetic as Cosmetic_HandItem, 0, !leftHand || !rightHand);
			SettingsManager.settings.cosmeticSaveData.ActivateHandCosmetic(cosmetic as Cosmetic_HandItem, 1, !leftHand || !rightHand);
		}
		else
		{
			SettingsManager.settings.cosmeticSaveData.ActivateCosmetic(cosmetic, !isSelected);
		}
		SettingsManager.RefreshSettings();
		DOTween.Complete(base.transform);
		if (selectAnimation)
		{
			base.transform.DOPunchScale(Vector3.one * 0.05f, 0.4f, 6);
		}
		if (settingsButton != null)
		{
			settingsButtonImage.color = Color.clear;
		}
	}

	private void Refresh()
	{
		if (cosmetic == null)
		{
			return;
		}
		if (settingsButton != null)
		{
			settingsButton.interactable = false;
			settingsButtonImage.raycastTarget = false;
			settingsButton.gameObject.SetActive(value: false);
		}
		bool flag = isSelected;
		if (cosmetic.GetCosmeticType() == "hand")
		{
			if (SettingsManager.settings.cosmeticSaveData.leftHandCosmetic.id == cosmetic.cosmeticInfo.id)
			{
				leftHandButton.color = Color.red;
				leftHand = true;
			}
			else
			{
				leftHandButton.color = Color.white;
				leftHand = false;
			}
			if (SettingsManager.settings.cosmeticSaveData.rightHandCosmetic.id == cosmetic.cosmeticInfo.id)
			{
				rightHandButton.color = Color.red;
				rightHand = true;
			}
			else
			{
				rightHandButton.color = Color.white;
				rightHand = false;
			}
			if (leftHand || rightHand)
			{
				isSelected = true;
			}
			else
			{
				isSelected = false;
			}
		}
		else if (SettingsManager.settings.cosmeticSaveData.CosmeticIsActive(cosmetic.cosmeticInfo.id))
		{
			isSelected = true;
		}
		else
		{
			isSelected = false;
		}
		if (buttonOutline != null)
		{
			if (isSelected)
			{
				buttonOutline.color = new Color(1f, 0f, 0f, 0.8f);
			}
			else
			{
				buttonOutline.color = Color.clear;
			}
		}
		if (flag && !isSelected)
		{
			OnDeactivate.Invoke();
		}
		else if (!flag && isSelected)
		{
			OnActivate.Invoke();
		}
		if (isSelected)
		{
			if (settingsButton != null && cosmetic.GetCosmeticType() != "voice")
			{
				settingsButton.interactable = true;
				settingsButtonImage.raycastTarget = true;
				settingsPressHint.SetActive(value: true);
				settingsButton.gameObject.SetActive(value: true);
			}
		}
		else if (settingsButton != null && cosmetic.GetCosmeticType() != "voice")
		{
			settingsButton.interactable = false;
			settingsButtonImage.raycastTarget = false;
			if (settingsButton != null)
			{
				settingsButtonImage.color = Color.clear;
			}
			settingsPressHint.SetActive(value: false);
			settingsButton.gameObject.SetActive(value: false);
		}
	}

	public void OpenInfo()
	{
		cosmeticsMenu.OpenInfoMenu(cosmetic);
	}

	public void PlaySound()
	{
		if (!(cosmetic != null))
		{
			return;
		}
		Cosmetic_Voice cosmetic_Voice = cosmetic as Cosmetic_Voice;
		if (cosmetic_Voice != null)
		{
			if (cosmetic_Voice.sampleClips != null && cosmetic_Voice.sampleClips.Count > 0)
			{
				AudioManager.PlayUISound(cosmetic_Voice.sampleClips[UnityEngine.Random.Range(0, cosmetic_Voice.sampleClips.Count)]);
			}
			else
			{
				AudioManager.PlayUISound(cosmetic_Voice.cosmeticData.clipHandlerOverride.GetRandomSound(), 0.8f);
			}
		}
	}
}
