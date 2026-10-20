using UnityEngine;

public class FX_HandItem_Cryogun : MonoBehaviour
{
	public HandItem_Shoot shootHandItem;

	private SpriteRenderer spriteRenderer;

	private float targetIceAmount;

	public float iceCreepSpeed = 0.4f;

	public float curEmissive;

	public ParticleSystem frostParticles;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		targetIceAmount = shootHandItem.GetAmmoPercent();
	}

	private void Update()
	{
		targetIceAmount = Mathf.Lerp(targetIceAmount, shootHandItem.GetAmmoPercent(), Time.deltaTime * iceCreepSpeed);
		spriteRenderer.material.SetFloat("_IceAmount", targetIceAmount);
		spriteRenderer.material.SetFloat("_Emissive", curEmissive);
		curEmissive = Mathf.Lerp(curEmissive, Mathf.Min(shootHandItem.GetPrimeLength(), 1f), Time.deltaTime);
		if (frostParticles != null)
		{
			ParticleSystem.EmissionModule emission = frostParticles.emission;
			emission.rateOverTimeMultiplier = targetIceAmount * 20f;
		}
	}

	public void SetEmissive(float f)
	{
		curEmissive = f;
	}
}
