using UnityEngine;

public class UT_GamemodeEventController : MonoBehaviour
{
	public void RunEvent(string s)
	{
		CL_GameManager.GetCurrentGamemode().gamemodeModule.RunEvent(s);
	}
}
