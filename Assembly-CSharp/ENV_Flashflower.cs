using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UT_LookTrigger))]
public class ENV_Flashflower : MonoBehaviour
{
	private Animator animator;

	private UT_LookTrigger lookTrigger;

	public bool active = true;

	public float flashRate = 3f;

	public float flashRecoveryRate = 2f;

	private float flashTimer;

	public List<AudioClip> flashSounds;

	public AudioClip deathSound;

	public FXManager.FXData flashFX;

	public float flashFXDecay = 1f;

	private void Start()
	{
		animator = GetComponent<Animator>();
		lookTrigger = GetComponent<UT_LookTrigger>();
		flashTimer = flashRate + Random.Range((0f - flashRate) * 0.25f, flashRate * 0.25f);
	}

	private void Update()
	{
		if (active && lookTrigger.isLookingAt())
		{
			flashTimer -= Time.deltaTime;
			if (flashTimer <= 0f)
			{
				flashTimer = flashRate;
				StartFlash();
			}
		}
	}

	public void StartFlash()
	{
		if (active)
		{
			animator.SetTrigger("Flash");
			flashTimer = flashRate + Random.Range((0f - flashRate) * 0.25f, flashRate * 0.25f) + flashRecoveryRate;
		}
	}

	public void Flash()
	{
		AudioManager.PlaySound(flashSounds[Random.Range(0, flashSounds.Count)], base.transform.position);
		CL_UIManager.SubtitleSimpleCreate(CL_LocalizationManager.GetLocalization("sound:hazard_flashflower"), "", CL_UIManager.SubtitleFlags.Ambient, base.transform);
		if (lookTrigger.isLookingAt() && !ENT_Player.GetPlayer().noclip && !CL_GameManager.noTarget)
		{
			ENT_Player.GetPlayer().Damage(Damageable.DamageInfo.CreateDamageInfo(0.1f, "flashflower"));
			ENT_Player.GetPlayer().DamageGripStrength(3f);
			StartCoroutine(FlashFXDecay());
		}
		IEnumerator FlashFXDecay()
		{
			float elapsed = 0f;
			while (elapsed < flashFXDecay)
			{
				elapsed += Time.deltaTime;
				FXManager.FXZoneStore element = new FXManager.FXZoneStore
				{
					blend = 1f - elapsed / flashFXDecay,
					priority = 30,
					data = flashFX
				};
				FXManager.fxZones.Enqueue(element, 30);
				yield return null;
			}
		}
	}

	public void Kill()
	{
		animator.SetTrigger("Die");
		AudioManager.PlaySound(deathSound, base.transform.position);
		active = false;
	}
}
