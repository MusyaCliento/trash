using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Window_Title : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler
{
	public Image sprite;

	private Color target = Color.white;

	private Vector3 offset;

	public UI_Window window;

	public Sprite normalSprite;

	public Sprite dragSprite;

	public Sprite unfocusedSprite;

	public Text titleText;

	public bool canDrag = true;

	public bool hideContentsOnDrag;

	private void Awake()
	{
		sprite = GetComponent<Image>();
	}

	private void Update()
	{
		if ((bool)sprite)
		{
			sprite.color = Vector4.MoveTowards(sprite.color, target, Time.deltaTime * 10f);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		sprite.sprite = normalSprite;
		window.MoveToTop();
		window.OnClick();
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (canDrag)
		{
			window.transform.position = OS_Manager.mousePosition + (Vector2)offset;
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (hideContentsOnDrag)
		{
			window.HideContents();
		}
		offset = (Vector2)window.transform.position - OS_Manager.mousePosition;
		sprite.sprite = dragSprite;
		OS_Manager.soundPlayer.PlaySound("os:drag-start");
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (hideContentsOnDrag)
		{
			window.ShowContents();
		}
		target = Color.white;
		sprite.sprite = normalSprite;
		window.MoveToTop();
		window.OnMove();
		OS_Manager.soundPlayer.PlaySound("os:drag-end");
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void SetTitle(string text)
	{
		if (titleText != null)
		{
			titleText.text = text;
		}
	}
}
