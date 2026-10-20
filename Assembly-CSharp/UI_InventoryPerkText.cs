using TMPro;
using UnityEngine;

public class UI_InventoryPerkText : MonoBehaviour
{
	private TMP_Text textComponent;

	private static UI_InventoryPerkText instance;

	private string lastTextShown;

	private float timeUntilHide;

	private void Start()
	{
		textComponent = GetComponent<TMP_Text>();
		instance = this;
		instance.textComponent.text = "";
	}

	private void OnDisable()
	{
		if (textComponent != null)
		{
			textComponent.text = "";
		}
	}

	private void Update()
	{
		if (timeUntilHide > 0f)
		{
			timeUntilHide -= CL_GameManager.GetPlayerPerceivedDeltaTime();
		}
		if (timeUntilHide <= 0f && textComponent.text != "")
		{
			textComponent.text = "";
		}
	}

	public static void SetText(string text)
	{
		if (text == instance.lastTextShown && !string.IsNullOrEmpty(instance.textComponent.text))
		{
			instance.timeUntilHide = 0.3f;
			return;
		}
		instance.lastTextShown = text;
		instance.textComponent.text = text;
		instance.timeUntilHide = 0.3f;
	}
}
