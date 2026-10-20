using UnityEngine;

public class FX_FadeFlareHit : MonoBehaviour
{
	private CL_Lamp lamp;

	public float lifeTime = 15f;

	private float curLifeTime;

	private float startIntensity = 1f;

	public AnimationCurve intensityDropoff;

	private void Start()
	{
		lamp = GetComponent<CL_Lamp>();
		startIntensity = lamp.intensity;
	}

	private void Update()
	{
		curLifeTime += Time.deltaTime;
		lamp.intensity = startIntensity * intensityDropoff.Evaluate(Mathf.Lerp(1f, 0f, curLifeTime / lifeTime));
		if (curLifeTime >= lifeTime)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
