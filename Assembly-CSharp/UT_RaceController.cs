using UnityEngine;

public class UT_RaceController : MonoBehaviour
{
	private M_Level parentLevel;

	private M_Level.SaveData levelSaveData;

	private void Start()
	{
		parentLevel = GetComponentInParent<M_Level>();
		levelSaveData = M_Level.SaveData.GetSave(parentLevel);
	}

	public void RaceTrackerStart()
	{
		if (!(parentLevel == null))
		{
			parentLevel.TimeTrackerStart();
			AudioManager.PlayUISound("tick1");
			Inventory.instance.ClearInventoryExceptTag("hammer");
			ENT_Player.playerObject.AddGripStrength(10f);
			if (levelSaveData != null)
			{
				M_Level.SaveData.LoadDataIntoLevel(levelSaveData, parentLevel, setPlayerPosition: false, loadEntities: true);
				parentLevel.DestroyPlacedObjects();
			}
		}
	}

	public void RaceTrackerEnd()
	{
		if (!(parentLevel == null))
		{
			parentLevel.TimeTrackerEnd();
			Inventory.instance.ClearInventoryExceptTag("hammer");
			if (levelSaveData != null)
			{
				M_Level.SaveData.LoadDataIntoLevel(levelSaveData, parentLevel, setPlayerPosition: false, loadEntities: true);
				parentLevel.DestroyPlacedObjects();
			}
		}
	}
}
