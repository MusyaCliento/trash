using UnityEngine;

public class PerkModule_LoopingAudioEffect : PerkModule
{
	public enum EffectSource
	{
		LowStamina = 0
	}

	public EffectSource effectSource;

	public AudioClip audioLoop;

	public float audioLoopVolume = 0.5f;

	public AnimationCurve audioLoopCurve;

	private AudioSource audioSourceObject;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		if (ENT_Player.GetPlayer() != null && audioLoop != null)
		{
			GameObject gameObject = new GameObject(perk.id + "-LoopingAudioEffect");
			audioSourceObject = gameObject.AddComponent<AudioSource>();
			audioSourceObject.clip = audioLoop;
			audioSourceObject.volume = 0f;
			audioSourceObject.loop = true;
			audioSourceObject.Play();
		}
	}

	public override void OnDestroy(Perk p)
	{
		base.OnDestroy(p);
		if (audioSourceObject != null)
		{
			Object.Destroy(audioSourceObject.gameObject);
		}
	}

	public override void Update()
	{
		base.Update();
		if (!(audioSourceObject != null))
		{
			return;
		}
		float num = 0f;
		if (effectSource == EffectSource.LowStamina)
		{
			num = audioLoopCurve.Evaluate(ENT_Player.GetPlayer().GetLowestGripStrength() / ENT_Player.GetPlayer().GetCurrentGripStrengthTimer());
			if (!ENT_Player.GetPlayer().IsHanging())
			{
				num = 0f;
			}
		}
		audioSourceObject.volume = Mathf.Lerp(audioSourceObject.volume, num * audioLoopVolume, CL_GameManager.GetPlayerPerceivedDeltaTime() * 2f);
	}
}
