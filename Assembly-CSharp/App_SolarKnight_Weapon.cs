using UnityEngine;

[CreateAssetMenu(fileName = "SK_Weapon", menuName = "White Knuckle/Games/Solar Knight/Weapon")]
public class App_SolarKnight_Weapon : ScriptableObject
{
	[SerializeReference]
	public App_SolarKnight_Player.WeaponInfo weaponInfo;
}
