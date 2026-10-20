using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_OutlineOnSelect : MonoBehaviour, ISelectHandler, IEventSystemHandler, ISubmitHandler, IDeselectHandler
{
	public Outline outline;

	private Color outlineColor;

	public Color selectColor;

	public Color submitColor;

	public Color deselectColor;

	private void Start()
	{
		if (outline == null)
		{
			outline = GetComponent<Outline>();
		}
		outlineColor = outline.effectColor;
	}

	public void OnSelect(BaseEventData eventData)
	{
		outline.effectColor = selectColor;
	}

	public void OnSubmit(BaseEventData eventData)
	{
		outline.effectColor = submitColor;
	}

	public void OnDeselect(BaseEventData eventData)
	{
		outline.effectColor = deselectColor;
	}

	private void SetOutlineAlpha(float alpha)
	{
		if (!(outline == null))
		{
			Color effectColor = outline.effectColor;
			effectColor.a = alpha;
			outline.effectColor = effectColor;
		}
	}
}
