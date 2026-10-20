using System;
using TMPro;
using UnityEngine;

public class UT_StatText : MonoBehaviour
{
	public enum StatSource
	{
		gamemode = 0,
		baseGamemode = 1,
		session = 2,
		global = 3,
		custom = 4,
		modeHolder = 5
	}

	public StatSource source;

	public string gamemode;

	public GameObject modeHolder;

	private GamemodeHolder holder;

	public string statistic;

	public string defaultText = "";

	public string textPrefix;

	private TMP_Text text;

	public bool roundToInt;

	public bool useGamemodeOptions;

	private void Awake()
	{
		if (text == null)
		{
			text = GetComponent<TMP_Text>();
		}
		if (holder == null && modeHolder != null)
		{
			holder = modeHolder.GetComponent<GamemodeHolder>();
		}
	}

	private void OnEnable()
	{
		RefreshText();
		StatManager.refreshStatText = (Action)Delegate.Combine(StatManager.refreshStatText, new Action(Refresh));
	}

	private void OnDisable()
	{
		StatManager.refreshStatText = (Action)Delegate.Remove(StatManager.refreshStatText, new Action(Refresh));
	}

	public void Refresh()
	{
		RefreshText(gamemode);
	}

	public void RefreshText(string customGameMode = "")
	{
		StatManager.GameStats gameStats = null;
		if (source == StatSource.global)
		{
			gameStats = StatManager.saveData.gameStats;
		}
		else if (source == StatSource.gamemode || source == StatSource.custom || source == StatSource.modeHolder)
		{
			if (source == StatSource.custom)
			{
				if (!(customGameMode != ""))
				{
					this.text.text = defaultText;
					return;
				}
				gamemode = customGameMode;
			}
			else if (source == StatSource.modeHolder && holder != null)
			{
				if (useGamemodeOptions)
				{
					gamemode = holder.GetGamemode().GetGamemodeName();
				}
				else
				{
					gamemode = holder.GetGamemode().GetGamemodeName(includeOptions: false);
				}
			}
			if (StatManager.saveData.GetGameMode(gamemode) != null)
			{
				gameStats = StatManager.saveData.GetGameMode(gamemode).stats;
			}
		}
		else if (source == StatSource.baseGamemode)
		{
			if (StatManager.saveData.GetGameMode(CL_GameManager.GetGamemodeName()) != null)
			{
				gameStats = StatManager.saveData.GetGameMode(CL_GameManager.GetGamemodeName()).stats;
			}
		}
		else if (source == StatSource.session)
		{
			gameStats = StatManager.sessionStats;
		}
		else if (gameStats == null)
		{
			this.text.text = defaultText;
		}
		if (gameStats != null)
		{
			StatManager.Statistic statistic = gameStats.GetStatistic(this.statistic);
			string text = statistic.GetString();
			if (roundToInt && statistic.type == StatManager.Statistic.DataType.Float && statistic.displayType == StatManager.Statistic.DisplayType.Default)
			{
				text = Mathf.RoundToInt((float)gameStats.GetStatistic(this.statistic).GetValue()).ToString();
			}
			if (text == "")
			{
				this.text.text = defaultText;
			}
			else
			{
				this.text.text = textPrefix + text;
			}
		}
		else
		{
			this.text.text = defaultText;
		}
	}

	public void SetHolder(GamemodeHolder h)
	{
		holder = h;
	}
}
