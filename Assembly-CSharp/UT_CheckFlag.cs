using UnityEngine;
using UnityEngine.Events;

public class UT_CheckFlag : MonoBehaviour
{
	public string flagName;

	public bool active = true;

	public bool checkOnEnable;

	public bool checkOnStart;

	public bool checkOnTick;

	public bool outputIfFlagIsNull;

	public bool runOnce;

	public bool forceOnUnlockAll;

	private bool hasRun;

	private int checkFrame;

	public bool useGlobalFlagInsteadOfSession;

	public UnityEvent flagFalseEvent;

	public UnityEvent flagTrueEvent;

	private void Start()
	{
		checkFrame = Random.Range(0, 20);
		if (checkOnStart)
		{
			CheckFlag();
		}
	}

	private void OnEnable()
	{
		if (active && checkOnEnable)
		{
			CheckFlag();
		}
	}

	private void Update()
	{
		if (active && checkOnTick)
		{
			checkFrame--;
			if (checkFrame <= 0)
			{
				CheckFlag();
				checkFrame = 10;
			}
		}
	}

	public void CheckFlag(bool forced = false)
	{
		if ((!active && !forced) || (runOnce && hasRun))
		{
			return;
		}
		hasRun = true;
		if (forceOnUnlockAll && (CL_GameManager.GetCurrentGamemode().IsCompetitive() || SettingsManager.settings.unlockAll))
		{
			hasRun = true;
			flagTrueEvent.Invoke();
			return;
		}
		CL_GameManager.SessionFlag gameFlag = CL_GameManager.GetGameFlag(flagName);
		if (useGlobalFlagInsteadOfSession)
		{
			if (CL_GameManager.HasActiveFlag(flagName))
			{
				flagTrueEvent.Invoke();
			}
			else
			{
				flagFalseEvent.Invoke();
			}
		}
		else if (gameFlag == null)
		{
			if (outputIfFlagIsNull)
			{
				flagFalseEvent.Invoke();
			}
		}
		else if (gameFlag.state)
		{
			flagTrueEvent.Invoke();
		}
		else
		{
			flagFalseEvent.Invoke();
		}
	}

	public void SetFlag(string dat)
	{
		string[] array = dat.Split(":");
		CL_GameManager.SetGameFlag(array[0], bool.Parse(array[1]));
	}

	public void SetSaveFlag(string dat)
	{
		string[] array = dat.Split(":");
		CL_GameManager.SetGameFlag(array[0], bool.Parse(array[1]), "", save: true);
	}

	public void CheckPlayerInventoryForTag(string tag)
	{
		if (ENT_Player.playerObject == null)
		{
			flagFalseEvent.Invoke();
		}
		if (Inventory.instance.GetItemByTag(tag) != null)
		{
			flagTrueEvent.Invoke();
		}
		else
		{
			flagFalseEvent.Invoke();
		}
	}

	public void SetPresessionFlag(string dat)
	{
		string[] array = dat.Split(":");
		CL_GameManager.SetGameFlag(array[0], bool.Parse(array[1]), "", save: false, presession: true);
	}
}
