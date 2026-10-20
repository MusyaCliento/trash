using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrinketList_New", menuName = "White Knuckle/Trinket List")]
public class TrinketList : ScriptableObject
{
	public List<Trinket> trinkets;

	public List<Trinket> bindings;
}
