using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PageHolder : MonoBehaviour
{
	public int currentPage;

	public List<UI_Page> pages;

	public TMP_Text pageTitle;

	public GameObject controlRoot;

	public bool showPageCountWhenOnePage = true;

	private void Start()
	{
		UpdatePage();
	}

	public void UpdatePage()
	{
		for (int i = 0; i < pages.Count; i++)
		{
			if (currentPage == i)
			{
				pages[i].gameObject.SetActive(value: true);
			}
			else
			{
				pages[i].gameObject.SetActive(value: false);
			}
		}
		if (pageTitle != null && pages.Count > 0)
		{
			pageTitle.text = pages[currentPage].title + $" ({currentPage + 1}/{pages.Count})";
		}
		if (!showPageCountWhenOnePage)
		{
			if (pages.Count == 1)
			{
				controlRoot.SetActive(value: false);
			}
			else
			{
				controlRoot.SetActive(value: true);
			}
		}
	}

	public void NextPage()
	{
		currentPage++;
		if (currentPage >= pages.Count)
		{
			currentPage = 0;
		}
		UpdatePage();
	}

	public void PreviousPage()
	{
		currentPage--;
		if (currentPage < 0)
		{
			currentPage = pages.Count - 1;
		}
		UpdatePage();
	}

	public void SetPage(int i)
	{
		currentPage = i;
		UpdatePage();
	}
}
