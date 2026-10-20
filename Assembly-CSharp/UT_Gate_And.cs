using UnityEngine;
using UnityEngine.Events;

public class UT_Gate_And : MonoBehaviour
{
	public bool inputA;

	public bool inputB;

	[Header("Settings")]
	public bool nand;

	public UnityEvent trueEvent;

	public UnityEvent falseEvent;

	public void SetA(bool b)
	{
		inputA = b;
		Check();
	}

	public void SetB(bool b)
	{
		inputB = b;
		Check();
	}

	public void Check()
	{
		if (!nand)
		{
			if (inputA && inputB)
			{
				trueEvent.Invoke();
			}
			else
			{
				falseEvent.Invoke();
			}
		}
		else if (!inputA || !inputB)
		{
			trueEvent.Invoke();
		}
		else
		{
			falseEvent.Invoke();
		}
	}
}
