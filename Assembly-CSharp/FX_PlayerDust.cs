using UnityEngine;

public class FX_PlayerDust : MonoBehaviour
{
	private static FX_PlayerDust instance;

	private ParticleSystem particles;

	private void OnEnable()
	{
		if (instance == null)
		{
			instance = this;
			particles = GetComponent<ParticleSystem>();
		}
	}

	private void OnDisable()
	{
		if (instance == this)
		{
			instance = null;
		}
	}

	public static void SetDustAmount(float rate = 1f)
	{
		if (instance != null)
		{
			ParticleSystem.EmissionModule emission = instance.particles.emission;
			rate *= 100f;
			if (SettingsManager.settings.effectQuality == 1)
			{
				rate *= 0.5f;
				rate = Mathf.Clamp(rate, 0f, 100f);
			}
			else if (SettingsManager.settings.effectQuality == 0)
			{
				rate = 0f;
			}
			emission.rateOverTime = rate;
			emission.rateOverDistance = rate * 0.1f;
		}
	}

	public static void SetDustColor(Color c)
	{
		if (instance != null)
		{
			ParticleSystem.MainModule main = instance.particles.main;
			main.startColor = c;
		}
	}

	public static void SetDustWind(Vector3 w, float n)
	{
		if (instance != null)
		{
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = instance.particles.velocityOverLifetime;
			velocityOverLifetime.x = w.x;
			velocityOverLifetime.y = w.y;
			velocityOverLifetime.z = w.z;
			ParticleSystem.NoiseModule noise = instance.particles.noise;
			noise.strengthMultiplier = n * 0.1f;
		}
	}
}
