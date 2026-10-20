using System;
using System.Collections.Generic;
using UnityEngine;

public class PerkModule_RemovalTimer : PerkModule
{
	public enum RemovalTimerDisplayType
	{
		minutes = 0,
		seconds = 1,
		fuzzy = 2,
		rough = 3,
		none = 4
	}

	private float startTime;

	public float removeTime;

	private bool halfWayTick;

	private bool hasRemoved;

	public bool playHalfTimerSound = true;

	public AudioClip halfTimerSound;

	public bool playRemovalSound = true;

	public AudioClip removalSound;

	public RemovalTimerDisplayType removalTimerDisplayType;

	public string removalTimerPrefix = "<size=1.0><color=#9c372f>";

	private bool hasLoaded;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		if (!hasLoaded)
		{
			startTime = removeTime;
		}
	}

	public override void Update()
	{
		base.Update();
		if (CL_GameManager.gMan.isPaused)
		{
			return;
		}
		removeTime -= Time.deltaTime;
		DebugMenu.UpdateDebugText("perkremoval:" + perk.id, "Removing Perk - " + perk.id + " :" + removeTime);
		perk.SetBarValue(removeTime / startTime);
		if (removeTime <= startTime / 2f && !halfWayTick)
		{
			halfWayTick = true;
			if (playHalfTimerSound)
			{
				if (halfTimerSound == null)
				{
					ENT_Player.playerObject.clipHandler.PlaySound("perk:timerhalf");
				}
				else
				{
					AudioManager.PlayUISound(halfTimerSound);
				}
			}
		}
		if (!(removeTime <= 0f) || hasRemoved)
		{
			return;
		}
		hasRemoved = true;
		if (playRemovalSound)
		{
			if (removalSound == null)
			{
				ENT_Player.playerObject.clipHandler.PlaySound("perk:loss");
			}
			else
			{
				AudioManager.PlayUISound(removalSound);
			}
		}
		perk.RemoveFromPlayer();
		DebugMenu.DeleteDebugText("perkremoval:" + perk.id);
	}

	public override void AddModule(int amount = 1, bool firstTime = true)
	{
		base.AddModule(amount, firstTime);
		removeTime = startTime;
	}

	public override void LoadSaveData(PerkModuleSaveInfo m)
	{
		base.LoadSaveData(m);
		if (m.data != null && m.data.Count > 0)
		{
			float.TryParse(m.data[0], out removeTime);
			hasLoaded = true;
		}
	}

	public override List<string> GetSaveData()
	{
		return new List<string> { removeTime.ToString() };
	}

	public void AddTime(float f)
	{
		removeTime += f;
	}

	public override string GetCounterString()
	{
		if (removalTimerDisplayType == RemovalTimerDisplayType.minutes)
		{
			return removalTimerPrefix + TimeSpan.FromSeconds(removeTime).ToString("mm\\:ss");
		}
		if (removalTimerDisplayType == RemovalTimerDisplayType.seconds)
		{
			return removalTimerPrefix + Mathf.Ceil(removeTime);
		}
		if (removalTimerDisplayType == RemovalTimerDisplayType.fuzzy)
		{
			if (removeTime < 10f)
			{
				return removalTimerPrefix + "<10";
			}
			if (removeTime < 30f)
			{
				return removalTimerPrefix + "<30";
			}
			if (removeTime < 60f)
			{
				return removalTimerPrefix + "<60";
			}
			return removalTimerPrefix + ">60";
		}
		if (removalTimerDisplayType == RemovalTimerDisplayType.rough)
		{
			if (removeTime < 10f)
			{
				return removalTimerPrefix + "Soon";
			}
			if (removeTime < 30f)
			{
				return removalTimerPrefix + "A Bit";
			}
			if (removeTime < 60f)
			{
				return removalTimerPrefix + "A While";
			}
			return removalTimerPrefix + "A Long Time";
		}
		return "";
	}
}
