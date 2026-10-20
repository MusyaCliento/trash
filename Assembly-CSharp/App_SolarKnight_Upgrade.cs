using UnityEngine;

[CreateAssetMenu(fileName = "SK_Upgrade", menuName = "White Knuckle/Games/Solar Knight/Upgrade")]
public class App_SolarKnight_Upgrade : ScriptableObject
{
	[SerializeReference]
	public App_SolarKnight_Player.Upgrade upgradeInfo;
}
