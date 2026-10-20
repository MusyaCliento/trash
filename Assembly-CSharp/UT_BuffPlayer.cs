using UnityEngine;

public class UT_BuffPlayer : MonoBehaviour
{
	public BuffContainer buff;

	public void GiveBuff()
	{
		ENT_Player.GetPlayer().Buff(buff.CopyBuffContainer());
	}
}
