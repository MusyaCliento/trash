using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CH_ChallengeCounter : MonoBehaviour
{
	[Serializable]
	public class ObjectiveCounter
	{
		public string objectiveTitle;

		public string objectiveDesc;

		public string progressHeaderDesc;

		public string finishedHeaderDesc;

		public int targetAmount;

		public UnityEvent counterSuccessEvent;

		public UnityEvent counterProgressEvent;

		private bool hasCompleted;

		public int bonusScore;

		public int extraScore;

		private int currentCounter = -1;

		public bool CheckCompletion(int i)
		{
			string descString = GetDescString(objectiveDesc, i);
			string text = "yellow";
			if (i >= targetAmount && !hasCompleted)
			{
				hasCompleted = true;
				counterSuccessEvent.Invoke();
				text = "green";
				UI_ObjectiveViewer.CreateOrUpdateObjective(objectiveTitle, objectiveTitle ?? "", "<color=" + text + ">" + descString + "</color>", punch: true);
				if (finishedHeaderDesc != "")
				{
					string descString2 = GetDescString(finishedHeaderDesc, i);
					CL_UIManager.instance.ascentHeader.ShowText(descString2);
				}
				UI_ObjectiveViewer.PlayEarnSound();
			}
			if (!hasCompleted && i != currentCounter)
			{
				UI_ObjectiveViewer.CreateOrUpdateObjective(objectiveTitle, objectiveTitle ?? "", "<color=" + text + ">" + descString + "</color>", punch: true);
				if (i != 0)
				{
					if (progressHeaderDesc != "")
					{
						string descString3 = GetDescString(progressHeaderDesc, i);
						CL_UIManager.instance.ascentHeader.ShowText(descString3);
					}
					counterProgressEvent.Invoke();
				}
			}
			currentCounter = i;
			return hasCompleted;
		}

		public string GetDescString(string s, int i)
		{
			int num = targetAmount - i;
			s = s.Replace("{count}", i.ToString()).Replace("{goal}", targetAmount.ToString()).Replace("{remain}", num.ToString());
			return s;
		}
	}

	public int counter;

	public bool checkCounterOnStart = true;

	public List<ObjectiveCounter> objectives;

	private void Start()
	{
		if (checkCounterOnStart)
		{
			CheckCounter();
		}
	}

	public void AddToCounter(int i)
	{
		counter += i;
		CheckCounter();
	}

	public void CheckCounter()
	{
		using List<ObjectiveCounter>.Enumerator enumerator = objectives.GetEnumerator();
		while (enumerator.MoveNext() && enumerator.Current.CheckCompletion(counter))
		{
		}
	}
}
