using System.Collections.Generic;
using UnityEngine;

public class Projectile_Homing_Rocket : Projectile_Homing
{
	public List<GameObject> thrusters;

	public float thrusterScale = 1f;

	public float thrusterMinimumScale;

	private Vector3 thrusterStartingScale;

	public float minimumThrusterAlignmentRequirement;

	public float gravityDotMult;

	private float randomStart;

	public float thrusterRandomFlickerSpeed = 10f;

	public float thrusterPerlinScaleAdd = 0.25f;

	public float thrusterDeactivationRandomPerlinThreshold = 0.1f;

	public float thrusterActivationRandomPerlinThreshold = 0.1f;

	public override void Initialize(Vector3 direction, GameEntity ent = null, Item item = null)
	{
		base.Initialize(direction, ent, item);
		randomStart = Random.value * 5000f;
		thrusterStartingScale = thrusters[0].transform.localScale;
	}

	public override void Update()
	{
		base.Update();
		if (thrusters == null || thrusters.Count == 0)
		{
			return;
		}
		for (int i = 0; i < thrusters.Count; i++)
		{
			GameObject gameObject = thrusters[i];
			if (!(gameObject == null))
			{
				float num = Vector3.Dot(gameObject.transform.forward, alignmentVector.normalized);
				float num2 = Vector3.Dot(gameObject.transform.forward, Vector3.up);
				float num3 = Mathf.PerlinNoise(randomStart + Time.time * thrusterRandomFlickerSpeed + (float)i * 6.33f, base.transform.position.y);
				if (num + num2 * gravityDotMult > minimumThrusterAlignmentRequirement)
				{
					gameObject.SetActive(num3 > thrusterDeactivationRandomPerlinThreshold);
					gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, thrusterStartingScale * (thrusterScale + num3 * thrusterPerlinScaleAdd), Time.deltaTime * 10f);
				}
				else
				{
					gameObject.SetActive(num3 < thrusterActivationRandomPerlinThreshold);
					gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, thrusterStartingScale * (thrusterMinimumScale + num3 * thrusterPerlinScaleAdd), Time.deltaTime * 10f);
				}
			}
		}
	}
}
