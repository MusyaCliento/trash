using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(20)]
public class UT_CheckpointController : MonoBehaviour
{
	private M_Level parentLevel;

	private M_Level.SaveData levelSaveData;

	private M_Level.SaveData currentLevelSaveData;

	private ENT_Player.SaveData currentPlayerSaveData;

	public bool restoreAllStamina = true;

	public UnityEvent restoreEvent;

	private void Start()
	{
		parentLevel = GetComponentInParent<M_Level>();
		levelSaveData = M_Level.SaveData.GetSave(parentLevel);
		currentLevelSaveData = levelSaveData;
		currentPlayerSaveData = new ENT_Player.SaveData();
		currentPlayerSaveData.SaveDataIntoClass(ENT_Player.GetPlayer());
	}

	public void RestoreToBaseLevelSave()
	{
		if (levelSaveData != null)
		{
			M_Level.SaveData.LoadDataIntoLevel(levelSaveData, parentLevel, setPlayerPosition: false, loadEntities: true);
			parentLevel.DestroyPlacedObjects();
		}
		restoreEvent.Invoke();
	}

	public void UpdateCurrentLevelSave()
	{
		currentLevelSaveData = M_Level.SaveData.GetSave(parentLevel);
		currentPlayerSaveData.SaveDataIntoClass(ENT_Player.GetPlayer());
	}

	public void RestoreToCurrentLevelSave()
	{
		if (currentLevelSaveData != null)
		{
			M_Level.SaveData.LoadDataIntoLevel(currentLevelSaveData, parentLevel, setPlayerPosition: false, loadEntities: true);
			parentLevel.DestroyPlacedObjects();
			currentPlayerSaveData.LoadDataIntoPlayer(ENT_Player.GetPlayer());
			ENT_Player.GetPlayer().AddGripStrength(100f);
		}
		restoreEvent.Invoke();
	}
}
