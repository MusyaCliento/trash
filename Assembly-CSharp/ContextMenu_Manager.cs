using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ContextMenu_Manager : MonoBehaviour
{
	public Text tipText;

	public RectTransform contextMenu;

	public static Action<string, Vector2, List<ContextMenu.ContextOption>> OnClick;

	public Button contextOptionPrefab;

	private void OnEnable()
	{
		OnClick = (Action<string, Vector2, List<ContextMenu.ContextOption>>)Delegate.Combine(OnClick, new Action<string, Vector2, List<ContextMenu.ContextOption>>(ShowMenu));
	}

	private void OnDisable()
	{
		OnClick = (Action<string, Vector2, List<ContextMenu.ContextOption>>)Delegate.Remove(OnClick, new Action<string, Vector2, List<ContextMenu.ContextOption>>(ShowMenu));
	}

	private void Start()
	{
		contextMenu.gameObject.SetActive(value: false);
	}

	private void ShowMenu(string tip, Vector2 mousePos, List<ContextMenu.ContextOption> options)
	{
		contextMenu.gameObject.SetActive(value: true);
		OS_Manager.soundPlayer.PlaySound("tap");
		foreach (Transform item in contextMenu)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		for (int i = 0; i < options.Count; i++)
		{
			ContextMenu.ContextOption option = options[i];
			Button button = UnityEngine.Object.Instantiate(contextOptionPrefab, contextMenu.position, Quaternion.identity, contextMenu.transform);
			button.transform.localPosition = new Vector3(0f, i * -19, 0f);
			button.transform.GetChild(0).GetComponent<Text>().text = option.text;
			button.onClick.AddListener(delegate
			{
				option.clickEvent?.Invoke();
			});
			UnityAction call = HideMenu;
			button.onClick.AddListener(call);
		}
		contextMenu.gameObject.SetActive(value: true);
		Vector3 position = new Vector2(mousePos.x, mousePos.y);
		if (OS_Manager.mousePosition.x > 512f - contextMenu.sizeDelta.x)
		{
			position.x -= contextMenu.sizeDelta.x * 0.7f;
		}
		if (OS_Manager.mousePosition.y < contextMenu.sizeDelta.y / 2f)
		{
			position.y += contextMenu.sizeDelta.y / 2f;
		}
		contextMenu.transform.position = position;
	}

	private void HideMenu()
	{
		OS_Manager.soundPlayer.PlaySound("click");
		contextMenu.gameObject.SetActive(value: false);
	}
}
