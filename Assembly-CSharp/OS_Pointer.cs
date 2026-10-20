using UnityEngine;
using UnityEngine.UI;

public class OS_Pointer : MonoBehaviour
{
	private OS_Manager os;

	public Vector2 maxPosition;

	public Vector2 minPosition;

	private RectTransform rectTransform;

	private Image cursorImage;

	public void Initialize(OS_Manager o)
	{
		os = o;
		rectTransform = GetComponent<RectTransform>();
		cursorImage = GetComponent<Image>();
	}

	private void Update()
	{
		if (os.canControl)
		{
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, minPosition.x, maxPosition.x);
			anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, minPosition.y, maxPosition.y);
			rectTransform.anchoredPosition = anchoredPosition;
		}
	}

	public void SetSprite(Sprite s)
	{
		cursorImage.sprite = s;
	}

	public Image GetImage()
	{
		return cursorImage;
	}
}
