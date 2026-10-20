using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Window : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public GameObject contents;

	private UI_Window_Title titlebar;

	public Sprite windowSprite;

	public Sprite flickerSprite;

	private Image image;

	public UnityEvent closeEvent;

	public UnityEvent moveEvent;

	public UnityEvent clickEvent;

	public string dragEndSound;

	private void Awake()
	{
		image = GetComponent<Image>();
		if (titlebar == null)
		{
			titlebar = base.transform.Find("Title Bar").GetComponent<UI_Window_Title>();
		}
	}

	private void Update()
	{
	}

	public UI_Window_Title GetTitleBar()
	{
		if (titlebar == null)
		{
			titlebar = base.transform.Find("Title Bar").GetComponent<UI_Window_Title>();
		}
		return titlebar;
	}

	public void HideContents()
	{
		contents.SetActive(value: false);
		image.sprite = flickerSprite;
	}

	public void ShowContents()
	{
		contents.SetActive(value: true);
		image.sprite = windowSprite;
	}

	public void MoveToTop()
	{
		base.transform.SetAsLastSibling();
	}

	public void OnMove()
	{
		moveEvent.Invoke();
	}

	public void OnClick()
	{
		clickEvent.Invoke();
	}

	private IEnumerator FlickerShow()
	{
		image.sprite = flickerSprite;
		contents.SetActive(value: true);
		titlebar.gameObject.SetActive(value: false);
		yield return new WaitForSeconds(0.025f);
		titlebar.gameObject.SetActive(value: true);
		contents.SetActive(value: false);
		yield return new WaitForSeconds(0.025f);
		contents.SetActive(value: true);
		image.sprite = windowSprite;
	}

	public void Close()
	{
		closeEvent.Invoke();
		base.gameObject.SetActive(value: false);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		MoveToTop();
		OnClick();
	}
}
