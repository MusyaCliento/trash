using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UT_ButtonAudio : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, ISelectHandler
{
	public bool onSubmit;

	public AudioClip clickSound;

	public AudioClip hoverSound;

	[Range(0f, 1f)]
	public float volume = 1f;

	private Button button;

	private Toggle toggle;

	private void Awake()
	{
		button = GetComponent<Button>();
		toggle = GetComponent<Toggle>();
		if (onSubmit)
		{
			button?.onClick?.AddListener(OnSubmit);
			toggle?.onValueChanged?.AddListener(delegate
			{
				OnSubmit();
			});
		}
	}

	public void OnSubmit()
	{
		if (toggle != null && toggle.IsInteractable())
		{
			AudioManager.PlayUISound(clickSound, volume);
		}
		else if (!(button == null))
		{
			AudioManager.PlayUISound(clickSound, volume);
		}
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (!onSubmit && toggle != null && toggle.IsInteractable())
		{
			AudioManager.PlayUISound(clickSound, volume);
		}
		else if (!onSubmit && (!(button == null) || !(toggle == null)) && (!(button != null) || button.IsInteractable()))
		{
			AudioManager.PlayUISound(clickSound, volume);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (toggle != null && toggle.IsInteractable())
		{
			AudioManager.PlayUISound(hoverSound, volume);
		}
		else if (!(button == null) && button.IsInteractable())
		{
			AudioManager.PlayUISound(hoverSound, volume);
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		if (onSubmit && toggle != null && toggle.IsInteractable())
		{
			AudioManager.PlayUISound(hoverSound, volume);
		}
		else if (onSubmit && !(button == null) && button.IsInteractable())
		{
			AudioManager.PlayUISound(hoverSound, volume);
		}
	}
}
