using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AssetDatabase", menuName = "White Knuckle/Asset Database")]
public class WKAssetDatabase : ScriptableObject
{
	public string id = "untitleddatabase";

	[Tooltip("All Prefabs in the project that have an M_Level on their root.")]
	public List<GameObject> itemPrefabs = new List<GameObject>();

	public List<GameObject> entityPrefabs = new List<GameObject>();

	public List<GameObject> denizenPrefabs = new List<GameObject>();

	public List<M_Level.LevelAssetHolder> levelAssets = new List<M_Level.LevelAssetHolder>();

	public List<M_Region> regionAssets = new List<M_Region>();

	public List<M_Subregion> subRegionAssets = new List<M_Subregion>();

	public List<M_Gamemode> gamemodeAssets = new List<M_Gamemode>();

	public List<Perk> perkAssets = new List<Perk>();

	public List<Trinket> trinketAssets = new List<Trinket>();

	public List<OS_DiskData> diskData = new List<OS_DiskData>();

	public List<SessionEvent> sessionEvents = new List<SessionEvent>();

	public List<Sprite> spriteAssets = new List<Sprite>();

	public List<Cosmetic_HandItem> cosmeticHands = new List<Cosmetic_HandItem>();

	public List<Cosmetic_Item> cosmeticItems = new List<Cosmetic_Item>();

	public List<Cosmetic_Voice> cosmeticVoices = new List<Cosmetic_Voice>();

	public List<Facility> facilityAssets = new List<Facility>();

	public GameObject nullItemObject;
}
