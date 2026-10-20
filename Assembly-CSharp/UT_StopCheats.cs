using UnityEngine;

public class UT_StopCheats : MonoBehaviour
{
	public void StopCheats()
	{
		ENT_Player.playerObject.noclip = false;
		ENT_Player.playerObject.SetGodMode(b: false);
		FXManager.fullBright = false;
	}
}
