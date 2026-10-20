using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkModule_HandEffect : PerkModule
{
	public bool active = true;

	public float effectChance = 1f;

	public ParticleSystem handParticleEffect;

	public int particlesToEmit = 5;

	public bool followHand;

	private List<ParticleSystem> spawnedEffects;

	public float minimumPlayerVelocity;

	public bool onlyWhenGrounded;

	public bool onlyWhenInAir;

	public bool onGrab = true;

	public bool onLetGo;

	public bool onlyOnLongReach;

	public float audioVolume = 1f;

	public float audioPitchVariance;

	public List<AudioClip> grabSounds;

	public List<AudioClip> letGoSounds;

	private float lastActivationTime;

	public float activationCooldown = 0.1f;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		ENT_Player player = ENT_Player.GetPlayer();
		player._OnHandGrab = (Action<ENT_Player.Hand>)Delegate.Combine(player._OnHandGrab, new Action<ENT_Player.Hand>(OnGrab));
		ENT_Player player2 = ENT_Player.GetPlayer();
		player2._OnHandRelease = (Action<ENT_Player.Hand>)Delegate.Combine(player2._OnHandRelease, new Action<ENT_Player.Hand>(OnLetGo));
		spawnedEffects = new List<ParticleSystem>();
		if (followHand && ENT_Player.GetPlayer() != null)
		{
			ENT_Player.Hand[] hands = ENT_Player.GetPlayer().hands;
			for (int i = 0; i < hands.Length; i++)
			{
				_ = hands[i];
				ParticleSystem item = UnityEngine.Object.Instantiate(handParticleEffect, null);
				spawnedEffects.Add(item);
			}
		}
		else if (handParticleEffect != null)
		{
			spawnedEffects.Add(UnityEngine.Object.Instantiate(handParticleEffect, null));
		}
	}

	public override void OnDestroy(Perk p)
	{
		base.OnDestroy(p);
		if (spawnedEffects != null)
		{
			foreach (ParticleSystem spawnedEffect in spawnedEffects)
			{
				if (spawnedEffect != null)
				{
					UnityEngine.Object.Destroy(spawnedEffect.gameObject);
				}
			}
			spawnedEffects.Clear();
		}
		if (ENT_Player.GetPlayer() != null)
		{
			ENT_Player player = ENT_Player.GetPlayer();
			player._OnHandGrab = (Action<ENT_Player.Hand>)Delegate.Remove(player._OnHandGrab, new Action<ENT_Player.Hand>(OnGrab));
			ENT_Player player2 = ENT_Player.GetPlayer();
			player2._OnHandRelease = (Action<ENT_Player.Hand>)Delegate.Remove(player2._OnHandRelease, new Action<ENT_Player.Hand>(OnLetGo));
		}
	}

	public override void Update()
	{
		base.Update();
		if (!followHand || spawnedEffects == null)
		{
			return;
		}
		bool flag = CanPlay();
		for (int i = 0; i < spawnedEffects.Count; i++)
		{
			if (ENT_Player.GetPlayer() != null)
			{
				spawnedEffects[i].transform.position = ENT_Player.GetPlayer().hands[i].handModel.position;
			}
			if (flag)
			{
				PlayParticleSystem(spawnedEffects[i]);
			}
			else
			{
				StopParticleSystem(spawnedEffects[i]);
			}
		}
	}

	private bool CanPlay()
	{
		bool result = active;
		if (onlyWhenGrounded && !ENT_Player.GetPlayer().IsGrounded())
		{
			result = false;
		}
		if (onlyWhenInAir && ENT_Player.GetPlayer().IsGrounded())
		{
			result = false;
		}
		if (minimumPlayerVelocity > 0f && ENT_Player.GetPlayer().cCon.velocity.magnitude < minimumPlayerVelocity)
		{
			result = false;
		}
		return result;
	}

	private void StopParticleSystem(ParticleSystem ps)
	{
		if (ps.isPlaying)
		{
			ps.Stop();
		}
	}

	private void PlayParticleSystem(ParticleSystem ps)
	{
		if (!ps.isPlaying)
		{
			ps.Play();
		}
	}

	public void OnGrab(ENT_Player.Hand hand)
	{
		if (onGrab && !(UnityEngine.Random.value > effectChance) && (!onlyOnLongReach || !(hand.GetDistanceFromCamera() < ENT_Player.GetPlayer().GetBaseInteractDistance())) && !(Time.time - lastActivationTime < activationCooldown))
		{
			lastActivationTime = Time.time;
			Debug.Log("Hand Effect Triggered");
			if (spawnedEffects != null && spawnedEffects.Count > 0)
			{
				perk.player.StartCoroutine(WaitOneFrame(hand));
			}
			if (grabSounds != null && grabSounds.Count > 0)
			{
				AudioManager.PlaySound(grabSounds[UnityEngine.Random.Range(0, grabSounds.Count)], hand.handModel.position, audioVolume, 1f + UnityEngine.Random.Range(0f - audioPitchVariance, audioPitchVariance));
			}
		}
	}

	public void OnLetGo(ENT_Player.Hand hand)
	{
		if (onLetGo && !(UnityEngine.Random.value > effectChance) && !(Time.time - lastActivationTime < activationCooldown))
		{
			lastActivationTime = Time.time;
			if (spawnedEffects != null && spawnedEffects.Count > 0)
			{
				perk.player.StartCoroutine(WaitOneFrame(hand));
			}
			if (letGoSounds != null && letGoSounds.Count > 0)
			{
				AudioManager.PlaySound(letGoSounds[UnityEngine.Random.Range(0, letGoSounds.Count)], hand.handModel.position, audioVolume, 1f + UnityEngine.Random.Range(0f - audioPitchVariance, audioPitchVariance));
			}
		}
	}

	public IEnumerator WaitOneFrame(ENT_Player.Hand hand)
	{
		yield return null;
		if (spawnedEffects != null && spawnedEffects.Count != 0)
		{
			ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
			{
				position = hand.handModel.position,
				applyShapeToPosition = true
			};
			spawnedEffects[0].Emit(emitParams, particlesToEmit);
		}
	}
}
