using UnityEngine;

public class UT_DrainingCounter : UT_Counter
{
	private float curCount;

	public float drainSpeed = 1f;

	public bool lockAtMax = true;

	private bool locked;

	public bool resetAtMax;

	private void Update()
	{
		count = Mathf.RoundToInt(curCount);
		if (curCount > 0f)
		{
			curCount -= Time.deltaTime * drainSpeed;
		}
	}

	public override void AddCount(int i)
	{
		base.AddCount(i);
		if (count >= maxCount)
		{
			if (lockAtMax)
			{
				locked = true;
			}
			if (resetAtMax)
			{
				curCount = 0f;
				Reset();
			}
		}
		curCount = count;
	}
}
