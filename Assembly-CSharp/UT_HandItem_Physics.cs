using System;
using UnityEngine;

public class UT_HandItem_Physics : MonoBehaviour
{
	[Range(0f, 1f)]
	public float blend = 1f;

	public float velocityDisplaceAmount = 1f;

	public float wiggleSpeed = 0.2f;

	public float wiggleAmount = 0.2f;

	public float wiggleFrequency = 3f;

	public float velocityAdjust = 1f;

	public float displaceMax = 5f;

	public float velocitySmoothSpeed = 3f;

	public float velocitySpinAmount;

	public float velocitySpinMax = 60f;

	private Vector3 lastPos;

	private Vector3 smoothedVel;

	private Vector3 startPos;

	public float viewBobAmount;

	public float viewBobFrequency = 1f;

	private void Start()
	{
		lastPos = base.transform.parent.position;
		startPos = base.transform.localPosition;
	}

	private void OnEnable()
	{
		ENT_Player player = ENT_Player.GetPlayer();
		player._OnTeleport = (Action)Delegate.Combine(player._OnTeleport, new Action(OnTeleport));
	}

	private void OnDisable()
	{
		ENT_Player player = ENT_Player.GetPlayer();
		player._OnTeleport = (Action)Delegate.Remove(player._OnTeleport, new Action(OnTeleport));
	}

	private void LateUpdate()
	{
		Vector3 vector = (lastPos - base.transform.parent.position) / Time.unscaledDeltaTime;
		vector = base.transform.InverseTransformVector(vector);
		smoothedVel = Vector3.Lerp(smoothedVel, vector, Time.unscaledDeltaTime * velocitySmoothSpeed);
		lastPos = base.transform.parent.position;
		Vector3 vector2 = new Vector3(Mathf.PerlinNoise(wiggleFrequency + Time.time * wiggleSpeed, wiggleFrequency), Mathf.PerlinNoise(wiggleFrequency + 22.5f, wiggleFrequency + 55.55f + Time.time * wiggleSpeed), 0f);
		vector2.x -= 0.5f;
		vector2.y -= 0.5f;
		vector2 *= wiggleAmount;
		vector2.x += smoothedVel.x * velocityAdjust * velocityDisplaceAmount;
		vector2.y += smoothedVel.y * velocityAdjust * velocityDisplaceAmount;
		vector2 = Vector3.ClampMagnitude(vector2, displaceMax);
		base.transform.localPosition = startPos + vector2 * blend;
		float num = Mathf.Clamp(smoothedVel.x * velocitySpinAmount, 0f - velocitySpinMax, velocitySpinMax);
		Quaternion localRotation = Quaternion.Euler(0f, 0f, num * blend);
		if (localRotation.x != float.NaN)
		{
			base.transform.localRotation = localRotation;
		}
		float num2 = Mathf.Sin(Time.time * viewBobFrequency) * viewBobAmount * smoothedVel.magnitude;
		base.transform.localPosition += Vector3.up * num2;
	}

	private void OnTeleport()
	{
		lastPos = base.transform.parent.position;
	}
}
