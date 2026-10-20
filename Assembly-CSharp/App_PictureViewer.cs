using UnityEngine;
using UnityEngine.UI;

public class App_PictureViewer : MonoBehaviour
{
	private OS_Window window;

	private Sprite picture;

	public Image image;

	private RectTransform rectTransform;

	private void Start()
	{
		window = GetComponent<OS_Window>();
		if (window.file.fileInfo.imageAssetData == null)
		{
			picture = OS_Manager.activeComputer.resources.GetPicture(window.file.fileInfo.data);
		}
		else
		{
			picture = window.file.fileInfo.imageAssetData;
		}
		image.sprite = picture;
		rectTransform = GetComponent<RectTransform>();
		if (picture.rect.width > 100f)
		{
			rectTransform.sizeDelta = new Vector2(picture.rect.width, picture.rect.height);
		}
		else
		{
			rectTransform.sizeDelta = new Vector2(picture.rect.width * 2f, picture.rect.height * 2f);
		}
	}

	private void Update()
	{
	}
}
