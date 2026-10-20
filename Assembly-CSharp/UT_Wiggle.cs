using UnityEngine;

public class UT_Wiggle : MonoBehaviour
{
	public float wiggleAmplitude = 1f;

	public float wiggleSpeed = 1f;

	public float wiggleOffset = 1f;

	public float wiggleRot;

	public float randomOffset;

	public float randomSpeed;

	private Vector3 startPos;

	private Quaternion startRot;

	public bool useUnscaledTime;

	private void Start()
	{
		startPos = base.transform.localPosition;
		startRot = base.transform.localRotation;
		randomOffset = Random.value * randomOffset;
		wiggleSpeed += Random.value * randomSpeed;
	}

	private void Update()
	{
		float num = Time.time;
		if (useUnscaledTime)
		{
			num = Time.unscaledTime;
		}
		base.transform.localPosition = startPos + base.transform.right * Mathf.Sin(num * wiggleSpeed + randomOffset) * wiggleAmplitude + base.transform.up * Mathf.Cos(num * wiggleSpeed + wiggleOffset) * wiggleAmplitude;
		base.transform.localRotation = startRot * Quaternion.Euler(0f, 0f, Mathf.Sin(num * wiggleSpeed + randomOffset) * wiggleRot * 1f);
	}
}
