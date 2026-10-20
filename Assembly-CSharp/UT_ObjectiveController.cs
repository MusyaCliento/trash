using UnityEngine;

public class UT_ObjectiveController : MonoBehaviour
{
	public bool createObjectiveOnStart;

	public string objectiveID;

	public string objectiveTitle;

	public string objectiveDesc;

	private void Start()
	{
		if (createObjectiveOnStart)
		{
			CreateObjective();
		}
	}

	public void CreateObjective()
	{
		UI_ObjectiveViewer.CreateOrUpdateObjective(objectiveID, objectiveTitle, objectiveDesc, punch: true);
	}

	public void UpdateObjectiveDescription(string s)
	{
		objectiveDesc = s;
		UI_ObjectiveViewer.CreateOrUpdateObjective(objectiveID, objectiveTitle, s, punch: true);
	}

	public void UpdateObjectiveTitle(string s)
	{
		objectiveTitle = s;
		UI_ObjectiveViewer.CreateOrUpdateObjective(objectiveID, s, objectiveDesc, punch: true);
	}

	public void PlayEarnSound()
	{
		UI_ObjectiveViewer.PlayEarnSound();
	}

	public void SetObjectiveViewerTitle(string s)
	{
		UI_ObjectiveViewer.SetTitle(s);
	}

	public void RemoveObjective(string s)
	{
		UI_ObjectiveViewer.RemoveObjective(s);
	}

	public void ClearAllObjectives()
	{
		UI_ObjectiveViewer.ClearAllObjectives();
	}
}
