using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_ProgressionUnlockList : MonoBehaviour
{
	public UI_ProgressionPopup unlockPopupAsset;

	public Transform unlockListRoot;

	public int numOfCardsToGenerate = 8;

	private UI_LerpOpen lerpOpen;

	private List<UI_ProgressionPopup> popupCards;

	public UnityEvent onShow;

	public UnityEvent onHide;

	private bool hasShownUnlocks;

	private void Start()
	{
		lerpOpen = GetComponent<UI_LerpOpen>();
		Initialize();
	}

	private void Initialize()
	{
		popupCards = new List<UI_ProgressionPopup>();
		for (int i = 0; i < numOfCardsToGenerate; i++)
		{
			UI_ProgressionPopup item = Object.Instantiate(unlockPopupAsset, unlockListRoot);
			popupCards.Add(item);
		}
	}

	public void ShowMenu()
	{
		lerpOpen.Show();
		for (int i = 0; i < popupCards.Count; i++)
		{
			if (CL_ProgressionManager.sessionPopups.Count > i)
			{
				popupCards[i].gameObject.SetActive(value: true);
				popupCards[i].UpdateInformation(CL_ProgressionManager.sessionPopups[i].icon, CL_ProgressionManager.sessionPopups[i].title, CL_ProgressionManager.sessionPopups[i].desc);
			}
			else
			{
				popupCards[i].gameObject.SetActive(value: false);
			}
		}
		onShow.Invoke();
	}

	public void HideMenu()
	{
		lerpOpen.Hide();
		onHide.Invoke();
	}

	internal void Check()
	{
		if (CL_ProgressionManager.sessionPopups.Count > 0 && !hasShownUnlocks)
		{
			hasShownUnlocks = true;
			ShowMenu();
		}
	}
}
