using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CopyColor : MonoBehaviour
{
	public Image targetImage;

	private Image curImage;

	private TMP_Text curText;

	private void Start()
	{
		curImage = GetComponent<Image>();
		curText = GetComponent<TMP_Text>();
	}

	private void Update()
	{
		if (curImage != null)
		{
			curImage.color = targetImage.color;
		}
		if (curText != null)
		{
			curText.color = targetImage.color;
		}
	}
}
