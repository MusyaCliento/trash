using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Camera : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Camera cam;

	public Vector3 mousePos;

	private OS_Manager osMan;

	public static bool mouseOver;

	private void Start()
	{
		osMan = GameObject.Find("OSManager").GetComponent<OS_Manager>();
	}

	private void Update()
	{
		MouseOverGame();
	}

	public bool MouseOverGame()
	{
		return mouseOver;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		osMan.SetCursorImage(OS_Manager.cursorType.crosshairs);
		mouseOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		osMan.SetCursorImage(OS_Manager.cursorType.pointer);
		mouseOver = false;
	}
}
