using UnityEngine;

public class UT_SpeedrunLogger : MonoBehaviour
{
	public string logString;

	public void Log()
	{
		SpeedrunManager.AddEvent(logString);
	}

	public void SaveLog()
	{
		SpeedrunManager.SaveLog();
	}
}
