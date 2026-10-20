using System.Collections;
using TMPro;
using UnityEngine;

public class UI_RebindOverlay : MonoBehaviour
{
	public static UI_RebindOverlay rebindOverlayInstance;

	public TMP_Text rebindText;

	private void Awake()
	{
		rebindOverlayInstance = this;
		base.gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		rebindOverlayInstance = null;
	}

	private void Update()
	{
		_ = InputManager.GetButton("Cancel").Up;
	}

	public void Hide()
	{
		StartCoroutine(Hide());
		IEnumerator Hide()
		{
			yield return new WaitForSecondsRealtime(0.1f);
			base.gameObject.SetActive(value: false);
		}
	}
}
