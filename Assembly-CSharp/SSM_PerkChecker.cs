using UnityEngine;

public class SSM_PerkChecker : SpawnSettingModule
{
	public string perkID;

	public float trueValue = 1f;

	public float falseValue;

	public AudioClip onSpawnAudio;

	public float onSpawnAudioVolume = 0.3f;

	public override float Check()
	{
		if (ENT_Player.GetPlayer() != null && ENT_Player.GetPlayer().HasPerk(perkID))
		{
			return trueValue;
		}
		return falseValue;
	}

	public override void OnSpawn()
	{
		base.OnSpawn();
		if (ENT_Player.GetPlayer().HasPerk(perkID) && onSpawnAudio != null)
		{
			AudioManager.PlayUISound(onSpawnAudio, onSpawnAudioVolume);
		}
	}
}
