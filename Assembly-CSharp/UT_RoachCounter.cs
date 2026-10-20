using System.Collections.Generic;
using UnityEngine;

public class UT_RoachCounter : NumberCounter
{
	public Transform[] counters;

	private int lastRoaches;

	private int[] digits;

	public bool customInput;

	public bool negative;

	private void Update()
	{
		RollCounters();
	}

	private void RollCounters()
	{
		if (!customInput && lastRoaches != CL_GameManager.GetRoaches())
		{
			digits = GetDigits(CL_GameManager.GetRoaches());
			lastRoaches = CL_GameManager.GetRoaches();
		}
		if (digits == null)
		{
			digits = new int[3];
		}
		for (int i = 0; i < counters.Length; i++)
		{
			Transform obj = counters[i];
			int num = 0;
			if (digits.Length > i)
			{
				num = digits[i] * -36;
			}
			obj.localRotation = Quaternion.Lerp(obj.localRotation, Quaternion.Euler(num, 0f, 0f), Time.deltaTime * 8f);
		}
	}

	public override void SetDigits(int count)
	{
		if (negative)
		{
			count = -count;
		}
		digits = GetDigits(count);
	}

	public static int[] GetDigits(int number)
	{
		List<int> list = new List<int>();
		while (number > 0)
		{
			list.Add(number % 10);
			number /= 10;
		}
		return list.ToArray();
	}
}
