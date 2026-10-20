using System;

[Serializable]
public class GamemodeModule
{
	internal M_Gamemode curGamemode;

	public virtual void Initialize(M_Gamemode m_Gamemode)
	{
		curGamemode = m_Gamemode;
	}

	public virtual void OnFinish(bool hasFinished)
	{
	}

	public virtual float GetScore(bool hasFinished = false)
	{
		return 0f;
	}

	public virtual float GetBaseScore()
	{
		return 0f;
	}

	public virtual void RunEvent(string e)
	{
	}
}
