using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(FX_Zone))]
public class FX_ZoneAnim_Lightning : MonoBehaviour
{
	private FX_Zone zone;

	public bool active = true;

	public float cooldownRate = 0.3f;

	public float lightningSpeed;

	public List<AudioClip> thunder;

	public float thunderVolumeMin = 1f;

	public float thunderVolumeMax = 1f;

	public float thunderDelay;

	private float flickerTime;

	public List<Sprite> lightningSprites;

	public List<SpriteRenderer> lightningRenderers;

	public Color lightningSpriteColor = Color.white;

	private void Start()
	{
		zone = GetComponent<FX_Zone>();
	}

	private void Update()
	{
		zone.blend = Mathf.Lerp(zone.blend, 0f, Time.deltaTime * cooldownRate);
		if (Application.isPlaying && lightningRenderers != null && lightningRenderers.Count > 0)
		{
			foreach (SpriteRenderer lightningRenderer in lightningRenderers)
			{
				lightningRenderer.color -= Color.white * 0.1f * Time.deltaTime * cooldownRate * 8f;
			}
		}
		if (!active)
		{
			return;
		}
		flickerTime -= Time.deltaTime;
		if (Random.value < lightningSpeed * Time.deltaTime / 100f && flickerTime <= 0f)
		{
			zone.blend = 1f;
			flickerTime = 0.1f;
			FlashLightningSprite();
			if (Application.isPlaying && thunder != null && thunder.Count > 0)
			{
				StartCoroutine(DelaySound());
			}
		}
		IEnumerator DelaySound()
		{
			yield return new WaitForSeconds(Random.Range(thunderDelay, thunderDelay * 2f));
			AudioManager.PlaySound(thunder[Random.Range(0, thunder.Count)], base.transform.position, Random.Range(thunderVolumeMin, thunderVolumeMax), 1f, 1f, bypass: false, 1f, null, "distant");
		}
	}

	private void FlashLightningSprite()
	{
		if (Application.isPlaying && lightningRenderers != null && lightningRenderers.Count != 0)
		{
			SpriteRenderer spriteRenderer = lightningRenderers[Random.Range(0, lightningRenderers.Count)];
			spriteRenderer.sprite = lightningSprites[Random.Range(0, lightningSprites.Count)];
			spriteRenderer.color = lightningSpriteColor;
		}
	}

	public void SetState(bool b)
	{
		active = b;
	}
}
