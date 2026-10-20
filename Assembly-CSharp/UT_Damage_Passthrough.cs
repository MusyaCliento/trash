using UnityEngine;

public class UT_Damage_Passthrough : MonoBehaviour, Damageable
{
	public UT_Damage damageable;

	public bool Damage(Damageable.DamageInfo info)
	{
		return damageable.Damage(info);
	}

	public GameObject GetGameObject()
	{
		return damageable.gameObject;
	}
}
