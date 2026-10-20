using Febucci.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Subtitle : MonoBehaviour
{
	[HideInInspector]
	public RectTransform rect;

	public TMP_Text text;

	public TextAnimator_TMP animator;

	public TypewriterByCharacter typewriter;

	[HideInInspector]
	public long subtitleGroupId;

	[HideInInspector]
	public int lineIndex;

	public TMP_Text leftArrow;

	public TMP_Text rightArrow;

	public Image backgroundImage;

	public float backgroundSizeX = 100f;

	public float backgroundSizeY = 64f;

	private void Awake()
	{
		rect = GetComponent<RectTransform>();
	}

	private void Update()
	{
		UpdateArrowPosition();
		if (text.fontSizeMax != 16f * SettingsManager.settings.subtitleFontScale)
		{
			text.fontSizeMax = 16f * SettingsManager.settings.subtitleFontScale;
			text.fontSizeMin = 10f * SettingsManager.settings.subtitleFontScale;
		}
		if (backgroundImage != null)
		{
			if (!SettingsManager.settings.showSubtitlesBacking)
			{
				backgroundImage.color = Color.clear;
				return;
			}
			backgroundImage.color = Color.Lerp(backgroundImage.color, Color.black * SettingsManager.settings.subtitleBackingOpacity, Time.unscaledDeltaTime * 6f);
			backgroundImage.rectTransform.sizeDelta = text.textBounds.size + new Vector3(backgroundSizeX, backgroundSizeY, backgroundSizeY);
		}
	}

	public void UpdateArrowPosition()
	{
		leftArrow.rectTransform.anchoredPosition = new Vector2(0f - text.textBounds.extents.x, 0f);
		rightArrow.rectTransform.anchoredPosition = new Vector2(text.textBounds.extents.x, 0f);
	}

	internal void OnShowText()
	{
		if (backgroundImage != null)
		{
			backgroundImage.color = Color.clear;
		}
	}
}
