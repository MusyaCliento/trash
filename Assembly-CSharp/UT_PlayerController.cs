using UnityEngine;

public class UT_PlayerController : MonoBehaviour
{
	public void SetPlayerSpeedMult(float s)
	{
		ENT_Player.GetPlayer().SetSpeedMult(s);
	}

	public void SetPlayerCanUseItems(bool b)
	{
		if (!b)
		{
			ENT_Player.GetPlayer().LockInteraction();
		}
		else
		{
			ENT_Player.GetPlayer().UnlockInteraction();
		}
	}

	public void SetPlayerCutsceneMode(bool b)
	{
		ENT_Player.GetPlayer().SetCutsceneMode(b);
	}
}
