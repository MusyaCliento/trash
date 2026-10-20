using UnityEngine;

public class UT_DamagePlayer : MonoBehaviour
{
	public string type;

	public void DamagePlayer(float amount)
	{
		ENT_Player.GetPlayer().Damage(Damageable.DamageInfo.CreateDamageInfo(amount));
	}
}
