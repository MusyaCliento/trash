using UnityEngine;

public class PerkModule_DamagePlayer : PerkModule
{
	public float damageAmount;

	public float damageGripAmount;

	public float minimumHealth;

	public float damageRate = 1f;

	private float damageTime;

	public string damageType;

	public float volume = 1f;

	public AudioClip damageSound;

	public string particleSystem;

	public int particleAmount = 10;

	public bool isLightDamage;

	public override void Update()
	{
		base.Update();
		damageTime -= Time.deltaTime;
		if (damageTime < 0f)
		{
			bool flag = false;
			if (perk.player.health > minimumHealth)
			{
				flag = true;
			}
			Damageable.DamageInfo damageInfo = Damageable.DamageInfo.CreateDamageInfo(flag ? damageAmount : 0f, damageType);
			damageInfo.isLight = isLightDamage;
			perk.player.Damage(damageInfo);
			if (flag)
			{
				perk.player.DamageGripStrength(damageGripAmount);
			}
			AudioManager.PlaySound(damageSound, perk.player.transform.position, volume);
			if (particleSystem != "")
			{
				FXManager.PlayParticleWithRadius(particleSystem, perk.player.transform.position, 0.5f, particleAmount);
			}
			damageTime = damageRate;
		}
	}
}
