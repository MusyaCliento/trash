using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gamemode Setting", menuName = "White Knuckle/Gamemode/Gamemode Setting")]
public class GamemodeSetting : ScriptableObject
{
	public string id;

	public string title;

	public string description;

	public Color color;

	public ProgressionUnlock unlock;

	public List<string> exclusiveSettings;

	public string nameAppend;

	public string leaderboardAppendID;

	public bool allowDownstream;

	public string downstreamId;

	public UI_GamemodeSetting gamemodeButtonAsset;
}
