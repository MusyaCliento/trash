using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(10)]
public class CH_RoachCollector : MonoBehaviour
{
	public bool useBankTarget = true;

	private int currentRoaches;

	private int totalBanked;

	public int bankTarget = 40;

	public string successText;

	private bool hasFinished;

	public UnityEvent finishEvent;

	public bool bankAddsExtraScore = true;

	public bool allowScoreReduction;

	public float roachAddedScoreMultiplier = 100f;

	private void Start()
	{
		if (useBankTarget)
		{
			StartCoroutine(WaitForText($"BANK {bankTarget} ROACHES", 0.5f));
			UI_ObjectiveViewer.CreateOrUpdateObjective("roachcollector", $"BANK {bankTarget} ROACHES", $"{totalBanked} / {bankTarget}");
		}
	}

	private void Update()
	{
		if (currentRoaches == CL_GameManager.GetRoaches())
		{
			return;
		}
		int num = CL_GameManager.GetRoaches() - currentRoaches;
		if (num > 0)
		{
			totalBanked += num;
			if (useBankTarget)
			{
				if (!hasFinished)
				{
					if (totalBanked >= bankTarget)
					{
						hasFinished = true;
						StopAllCoroutines();
						CL_UIManager.instance.ascentHeader.ShowText(successText);
						UI_ObjectiveViewer.CreateOrUpdateObjective("roachcollector", $"BANK {bankTarget} ROACHES", $"<color=green>{totalBanked} / {bankTarget}</color>", punch: true);
						UI_ObjectiveViewer.PlayEarnSound();
						finishEvent.Invoke();
					}
					else
					{
						StopAllCoroutines();
						StartCoroutine(WaitToShowPrintout());
						UI_ObjectiveViewer.CreateOrUpdateObjective("roachcollector", $"BANK {bankTarget} ROACHES", $"{totalBanked} / {bankTarget}", punch: true);
					}
				}
				else
				{
					UI_ObjectiveViewer.CreateOrUpdateObjective("roachcollector", $"BANK {bankTarget} ROACHES", $"<color=green>{totalBanked} / {bankTarget}</color>", punch: true);
				}
			}
			if (bankAddsExtraScore && totalBanked >= bankTarget)
			{
				GamemodeModule_Challenge.AddBonusScore((float)num * roachAddedScoreMultiplier);
				UI_ObjectiveViewer.CreateOrUpdateObjective("scorebonus", "<color=red>SCORE BONUS", $"{Mathf.RoundToInt((float)(totalBanked - bankTarget) * roachAddedScoreMultiplier)}", punch: true);
			}
		}
		else
		{
			if (allowScoreReduction)
			{
				totalBanked += num;
			}
			if (bankAddsExtraScore && allowScoreReduction)
			{
				GamemodeModule_Challenge.AddBonusScore((float)num * roachAddedScoreMultiplier);
				UI_ObjectiveViewer.CreateOrUpdateObjective("scorebonus", "<color=red>SCORE BONUS", $"{Mathf.RoundToInt((float)(totalBanked - bankTarget) * roachAddedScoreMultiplier)}", punch: true);
			}
		}
		currentRoaches = CL_GameManager.GetRoaches();
	}

	public IEnumerator WaitForText(string text, float time)
	{
		yield return new WaitForSeconds(time);
		CL_UIManager.instance.ascentHeader.ShowText(text);
	}

	public IEnumerator WaitToShowPrintout()
	{
		yield return new WaitForSeconds(4f);
		int a = bankTarget - totalBanked;
		a = Mathf.Max(a, 0);
		CL_UIManager.instance.ascentHeader.ShowText($"{totalBanked} roaches banked. {a} remain.");
	}
}
