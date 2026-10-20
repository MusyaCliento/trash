using System;
using System.Collections.Generic;

[Serializable]
public class LevelStat
{
	public string levelId;

	public float bestTime;

	public List<float> times;

	public void AddTime(float t)
	{
		if (times == null)
		{
			times = new List<float>();
		}
		times.Add(t);
	}
}
