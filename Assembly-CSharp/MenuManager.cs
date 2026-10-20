using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	[Serializable]
	public class BackgroundScene
	{
		public string name;

		public string unlockFlagID;

		public GameObject asset;

		public AssetReferenceGameObject assetReference;

		public bool force;
	}

	public List<BackgroundScene> backgroundScenes;

	public UI_Menu menu;

	public GameObject seedWindow;

	public UI_MenuScreen saveUpgradeMenu;

	public UI_MenuScreen updatePopup;

	private void Awake()
	{
		CL_GameManager.gMan.isPaused = false;
		CL_GameManager.showCursor = true;
		CL_GameManager.SetTimescale(1f);
		CL_GameManager.SetTimescaleMult(1f);
		AudioListener.pause = false;
		SettingsManager.settings.g_competitive = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		CommandConsole.hasCheated = false;
		SelectMenuBackground();
	}

	private void Start()
	{
		if (StatManager.showUpdateDialogue)
		{
			updatePopup.Initialize(null, menu);
			Debug.Log("Showing Update Dialogue!");
			menu.DisableMenus(null);
			updatePopup.Open();
			StatManager.showUpgradeDialogue = false;
		}
		else if (StatManager.showUpgradeDialogue)
		{
			saveUpgradeMenu.Initialize(null, menu);
			Debug.Log("Showing Upgrade Dialogue!");
			menu.DisableMenus(null);
			saveUpgradeMenu.Open();
			StatManager.showUpgradeDialogue = false;
		}
		ChallengeMode.CheckChallengeAchievements();
		SettingsManager.instance.UpdateSettings();
		CL_AssetManager.UnloadAllLevels();
	}

	private void Update()
	{
		if (!seedWindow.activeSelf && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftControl))
		{
			seedWindow.SetActive(value: true);
		}
	}

	public void SelectMenuBackground()
	{
		if (!StatManager.initialized)
		{
			LoadBackgroundAsset(backgroundScenes[0].assetReference);
			return;
		}
		List<GameObject> list = new List<GameObject>();
		foreach (BackgroundScene backgroundScene in backgroundScenes)
		{
			if (backgroundScene.unlockFlagID == "" || StatManager.saveData.GetFlagState(backgroundScene.unlockFlagID))
			{
				list.Add(backgroundScene.asset);
			}
			if (backgroundScene.force)
			{
				LoadBackgroundPrefab(backgroundScene.asset);
				return;
			}
		}
		LoadBackgroundPrefab(list[UnityEngine.Random.Range(0, list.Count)]);
	}

	public void LoadBackgroundPrefab(GameObject asset)
	{
		UnityEngine.Object.Instantiate(asset, base.transform);
	}

	public void LoadBackgroundAsset(AssetReferenceGameObject asset)
	{
		asset.LoadAssetAsync();
		StartCoroutine(LoadAsset());
		IEnumerator LoadAsset()
		{
			while (asset.Asset == null)
			{
				yield return null;
			}
			UnityEngine.Object.Instantiate(asset.Asset, base.transform);
		}
	}

	public void LoadScene(string s)
	{
		SceneManager.LoadScene(s);
	}

	public void Quit()
	{
		CL_GameManager.safeExit = true;
		SteamManager.Shutdown();
		Application.Quit();
	}
}
