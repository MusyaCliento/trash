using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class App_SolarKnight : MonoBehaviour
{
	public OS_GameRenderer gameRendererAsset;

	public RawImage rendererImage;

	private OS_GameRenderer gameRenderer;

	private App_SolarKnight_World gameWorld;

	private int score;

	private int lives = 3;

	private float difficulty;

	private float gameTime;

	public TMP_Text scoreText;

	public TMP_Text livesText;

	public TMP_Text timeText;

	public GameObject gameOverScreen;

	public GameObject deathScreen;

	public GameObject pauseScreen;

	private OS_Window window;

	private bool isPaused;

	private bool isGameTimePaused;

	private bool isPlayerDead;

	public List<App_SolarKnight_Upgrade> availableUpgrades = new List<App_SolarKnight_Upgrade>();

	public float upgradeCostMultiplierPerLevel = 1.2f;

	public GameObject upgradeMenu;

	public List<Button> upgradeButtons;

	private void Start()
	{
		window = GetComponent<OS_Window>();
		CreateRenderer();
	}

	private void CreateRenderer()
	{
		if (gameRenderer == null)
		{
			gameRenderer = Object.Instantiate(gameRendererAsset);
			gameWorld = gameRenderer.GetComponent<App_SolarKnight_World>();
			gameWorld.Initialize(this);
			if (window != null && window.os != null)
			{
				window.os.HideCursor();
			}
		}
		rendererImage.texture = gameRenderer.GetRenderTexture();
	}

	private void OnEnable()
	{
		if (gameRenderer != null)
		{
			gameRenderer.gameObject.SetActive(value: true);
		}
	}

	private void OnDisable()
	{
		if (gameRenderer != null)
		{
			gameRenderer.gameObject.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		gameRenderer.Unload();
	}

	private void Update()
	{
		if (!isPaused && !isGameTimePaused)
		{
			gameTime += Time.deltaTime;
		}
		difficulty = Mathf.Min(1f, gameTime / 300f);
		timeText.text = "Time: " + Mathf.FloorToInt(gameTime);
		if ((InputManager.GetButton("Inventory").Down || InputManager.GetButton("Pause").Down) && !upgradeMenu.gameObject.activeSelf && !isPlayerDead)
		{
			if (isPaused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
	}

	public void PauseGame()
	{
		isPaused = true;
		pauseScreen.SetActive(value: true);
		App_SolarKnight_World.gameTimeScale = 0f;
		window.os.ShowCursor();
	}

	public void ResumeGame()
	{
		App_SolarKnight_World.gameTimeScale = 1f;
		isPaused = false;
		pauseScreen.SetActive(value: false);
		window.os.HideCursor();
	}

	public void AddScore(int points)
	{
		score += points;
		scoreText.text = "Score: " + score;
	}

	public void Reset()
	{
		score = 0;
		lives = 3;
		difficulty = 0f;
		gameTime = 0f;
		scoreText.text = "Score: " + score;
		livesText.text = "Lives: " + lives;
		gameWorld.ResetWorld();
	}

	public void LoseLife()
	{
		StartCoroutine(DeathAnimation());
		IEnumerator DeathAnimation()
		{
			yield return new WaitForSeconds(1f);
			lives--;
			livesText.text = "Lives: " + lives;
			isPlayerDead = true;
			isGameTimePaused = true;
			App_SolarKnight_World.gameTimeScale = 0f;
			if (lives <= 0)
			{
				gameOverScreen.SetActive(value: true);
			}
			else
			{
				deathScreen.SetActive(value: true);
			}
			while (!InputManager.GetButton("Jump").Pressed)
			{
				yield return null;
			}
			isPlayerDead = false;
			isGameTimePaused = false;
			App_SolarKnight_World.gameTimeScale = 1f;
			deathScreen.SetActive(value: false);
			gameOverScreen.SetActive(value: false);
			if (lives <= 0)
			{
				Reset();
			}
			else
			{
				gameWorld.RespawnPlayer();
			}
		}
	}

	public float GetGameTime()
	{
		return gameTime;
	}

	internal void PauseGameTime()
	{
		isGameTimePaused = true;
	}

	internal void ResumeGameTime()
	{
		isGameTimePaused = false;
	}

	public bool IsGameTimePaused()
	{
		return isGameTimePaused;
	}

	public bool IsPaused()
	{
		return isPaused;
	}

	public void ShowUpgradeMenu()
	{
		upgradeMenu.SetActive(value: true);
		gameWorld.SetGameTimeScale(0f);
		window?.os?.ShowCursor();
		List<App_SolarKnight_Player.Upgrade> list = new List<App_SolarKnight_Player.Upgrade>();
		while (list.Count < 3 && availableUpgrades.Count > 0)
		{
			App_SolarKnight_Player.Upgrade upgradeInfo = availableUpgrades[Random.Range(0, availableUpgrades.Count)].upgradeInfo;
			if (!list.Contains(upgradeInfo) && (upgradeInfo.canStack || !gameWorld.GetPlayer().HasUpgradeWithName(upgradeInfo.name)) && (string.IsNullOrEmpty(upgradeInfo.prerequisiteUpgradeName) || gameWorld.GetPlayer().HasUpgradeWithName(upgradeInfo.prerequisiteUpgradeName)))
			{
				list.Add(upgradeInfo);
			}
		}
		for (int i = 0; i < upgradeButtons.Count; i++)
		{
			if (i < list.Count)
			{
				App_SolarKnight_Player.Upgrade upgrade = list[i];
				float currentUpgradeCost = upgrade.cost;
				if (GetLevel() > 1)
				{
					currentUpgradeCost = Mathf.FloorToInt((float)upgrade.cost * Mathf.Pow(upgradeCostMultiplierPerLevel, GetLevel() - 1));
				}
				upgradeButtons[i].gameObject.SetActive(value: true);
				upgradeButtons[i].GetComponentInChildren<TMP_Text>().text = upgrade.upgradeName + "-<color=red>" + currentUpgradeCost;
				upgradeButtons[i].GetComponentInChildren<OS_Tooltip>().tip = upgrade.description;
				upgradeButtons[i].onClick.RemoveAllListeners();
				upgradeButtons[i].onClick.AddListener(delegate
				{
					ApplyUpgrade(upgrade);
					score -= Mathf.RoundToInt(currentUpgradeCost);
					HideUpgradeMenu();
				});
				if ((float)score < currentUpgradeCost)
				{
					upgradeButtons[i].interactable = false;
				}
				else
				{
					upgradeButtons[i].interactable = true;
				}
			}
			else
			{
				upgradeButtons[i].gameObject.SetActive(value: false);
			}
		}
	}

	public void HideUpgradeMenu()
	{
		upgradeMenu.SetActive(value: false);
		gameWorld.SetGameTimeScale(1f);
		window?.os?.HideCursor();
	}

	public void ApplyUpgrade(App_SolarKnight_Player.Upgrade upgrade)
	{
		gameWorld.GetPlayer().ApplyUpgrade(upgrade);
	}

	internal void AddLife()
	{
		lives++;
		livesText.text = "Lives: " + lives;
	}

	public int GetLevel()
	{
		return Mathf.Max((gameTime > 0f) ? Mathf.FloorToInt(gameTime / 60f) : 0, 1);
	}
}
