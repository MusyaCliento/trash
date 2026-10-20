using UnityEngine;
using UnityEngine.Events;

public class UT_StatChecker : MonoBehaviour
{
	public enum Evaluation
	{
		equals = 0,
		lesserThan = 1,
		greaterThan = 2
	}

	public string statName;

	public bool session = true;

	public Evaluation evaluation;

	public int evaluationInteger;

	public UnityEvent trueEvent;

	public UnityEvent falseEvent;

	public void Check()
	{
		int num = 0;
		num = ((!session) ? StatManager.GetTotalStatisticInt(statName) : StatManager.GetStatisticInt(StatManager.sessionStats, statName));
		if (evaluation == Evaluation.equals)
		{
			if (num == evaluationInteger)
			{
				trueEvent.Invoke();
			}
			else
			{
				falseEvent.Invoke();
			}
		}
		else if (evaluation == Evaluation.greaterThan)
		{
			if (num > evaluationInteger)
			{
				trueEvent.Invoke();
			}
			else
			{
				falseEvent.Invoke();
			}
		}
		else if (evaluation == Evaluation.lesserThan)
		{
			if (num < evaluationInteger)
			{
				trueEvent.Invoke();
			}
			else
			{
				falseEvent.Invoke();
			}
		}
	}
}
