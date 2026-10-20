using UnityEngine;
using UnityEngine.Events;

public class UT_SaveChecker : MonoBehaviour
{
	public CL_SaveManager.SaveState.SaveType saveType;

	public string saveId;

	public UnityEvent trueEvent;

	public UnityEvent falseEvent;

	public bool CheckEverySecond;

	private float checkTime;

	private void Update()
	{
		if (checkTime <= 0f)
		{
			checkTime = 1f;
			Check();
		}
		checkTime -= Time.deltaTime;
	}

	public void Check()
	{
		if (CL_SaveManager.GetSaveStateByID(saveId, saveType) != null)
		{
			trueEvent.Invoke();
		}
		else
		{
			falseEvent.Invoke();
		}
	}
}
