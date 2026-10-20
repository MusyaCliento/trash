using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_CosmeticsMenu : MonoBehaviour
{
	[Serializable]
	public class CosmeticPage
	{
		public string name;

		public string cosmeticType;

		public UI_PageHolder pageHolder;

		internal List<Cosmetic_Base> cosmetics;

		internal List<UI_Page> pages = new List<UI_Page>();
	}

	public UI_CosmeticButton cosmeticTemplate;

	public Transform buttonHolder;

	private List<UI_CosmeticButton> cosmeticButtons;

	public UI_CosmeticInfoPanel cosmeticInfoPanel;

	public List<CosmeticPage> cosmeticPages;

	public UI_Page pageTemplate;

	public int maxPerPage = 12;

	private void Start()
	{
		cosmeticInfoPanel.gameObject.SetActive(value: false);
		UI_CosmeticInfoPanel uI_CosmeticInfoPanel = cosmeticInfoPanel;
		uI_CosmeticInfoPanel.OnCloseMenu = (Action)Delegate.Combine(uI_CosmeticInfoPanel.OnCloseMenu, new Action(OnCloseInfoMenu));
		foreach (Cosmetic_Base allLoadedCosmetic in CL_CosmeticManager.GetAllLoadedCosmetics())
		{
			if (!allLoadedCosmetic.showInCosmeticsWindow)
			{
				continue;
			}
			foreach (CosmeticPage cosmeticPage in cosmeticPages)
			{
				if (allLoadedCosmetic.GetCosmeticType() == cosmeticPage.cosmeticType)
				{
					if (cosmeticPage.cosmetics == null)
					{
						cosmeticPage.cosmetics = new List<Cosmetic_Base>();
					}
					cosmeticPage.cosmetics.Add(allLoadedCosmetic);
				}
			}
		}
		foreach (CosmeticPage cosmeticPage2 in cosmeticPages)
		{
			FillCosmeticPage(cosmeticPage2.cosmetics, cosmeticPage2.name, cosmeticPage2);
		}
	}

	public void FillCosmeticPage(List<Cosmetic_Base> cosmeticList, string pageName, CosmeticPage cosmeticPage)
	{
		if (cosmeticList == null || cosmeticList.Count <= 0)
		{
			return;
		}
		UI_Page uI_Page = null;
		for (int i = 0; i < cosmeticList.Count; i++)
		{
			Cosmetic_Base handCosmetic = cosmeticList[i];
			if (cosmeticPage.pages.Count == 0 || Mathf.Floor(i / maxPerPage) >= (float)cosmeticPage.pages.Count)
			{
				UI_Page uI_Page2 = UnityEngine.Object.Instantiate(pageTemplate, cosmeticPage.pageHolder.transform);
				uI_Page2.title = pageName;
				cosmeticPage.pages.Add(uI_Page2);
				uI_Page2.gameObject.name = "Page " + cosmeticPage.pages.Count;
				cosmeticPage.pageHolder.pages.Add(uI_Page2);
				uI_Page = uI_Page2;
				cosmeticPage.pageHolder.UpdatePage();
			}
			UnityEngine.Object.Instantiate(cosmeticTemplate, uI_Page.transform).Initialize(handCosmetic, this);
		}
	}

	private void Update()
	{
	}

	internal void OpenInfoMenu(Cosmetic_Base cosmetic)
	{
		cosmeticInfoPanel.Open(cosmetic);
	}

	public void CloseInfoMenu()
	{
		cosmeticInfoPanel.Close();
	}

	public void OnCloseInfoMenu()
	{
	}
}
