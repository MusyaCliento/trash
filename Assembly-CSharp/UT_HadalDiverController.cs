using UnityEngine;

public class UT_HadalDiverController : MonoBehaviour
{
	public void ToggleSoftParentZones(bool b)
	{
		if (DEN_HadalDiver.instance != null)
		{
			DEN_HadalDiver.instance.ToggleSoftParentZones(b);
		}
	}

	public void DisableBodyBlockers()
	{
		DEN_HadalDiver.instance.DisableBodySkipBlockers();
	}

	public void ExitDiver()
	{
		DEN_HadalDiver.instance.ExitDiver();
	}
}
