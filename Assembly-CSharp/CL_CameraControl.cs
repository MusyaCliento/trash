using System;
using UnityEngine;

public class CL_CameraControl : MonoBehaviour
{
	private Vector3 localRoot;

	private float shakeAmount;

	private float shakeTime = 0.01f;

	public float swayAmount;

	public float swaySpeed = 1f;

	private float swayTime;

	private float curSway;

	public static Action<float> Shake;

	public static Action<Vector3, float, float> ShakeAtPosition;

	public Camera camera;

	private void Start()
	{
		localRoot = base.transform.localPosition;
	}

	private void OnEnable()
	{
		Shake = (Action<float>)Delegate.Combine(Shake, new Action<float>(ShakeCamera));
		ShakeAtPosition = (Action<Vector3, float, float>)Delegate.Combine(ShakeAtPosition, new Action<Vector3, float, float>(ShakeCamera));
	}

	private void OnDisable()
	{
		Shake = (Action<float>)Delegate.Remove(Shake, new Action<float>(ShakeCamera));
		ShakeAtPosition = (Action<Vector3, float, float>)Delegate.Remove(ShakeAtPosition, new Action<Vector3, float, float>(ShakeCamera));
	}

	private void LateUpdate()
	{
		shakeAmount = Mathf.Lerp(shakeAmount, 0f, Time.unscaledDeltaTime * 6f);
		shakeTime -= Time.unscaledDeltaTime * 0.4f;
		swayTime += Time.deltaTime * swaySpeed * 3f;
		curSway = Mathf.Lerp(curSway, swayAmount, Time.unscaledDeltaTime * 2f);
		Quaternion quaternion = Quaternion.identity;
		Quaternion quaternion2 = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Sin(swayTime)) * curSway);
		if (shakeTime <= 0f && shakeAmount > 0.001f)
		{
			shakeTime = 0.01f;
			base.transform.GetChild(0).localPosition = Vector3.ClampMagnitude(UnityEngine.Random.insideUnitSphere * shakeAmount * SettingsManager.settings.screenShakeMultiplier, 0.5f);
			float num = 1f;
			quaternion = Quaternion.Euler(Vector3.ClampMagnitude(UnityEngine.Random.insideUnitSphere * shakeAmount * 30f * num * SettingsManager.settings.screenShakeMultiplier, 20.5f));
		}
		base.transform.GetChild(0).localRotation = quaternion * quaternion2;
	}

	public void UpdateLocalPosition(Vector3 newPos)
	{
		localRoot = newPos;
	}

	public Vector3 GetLocalPosition()
	{
		return localRoot;
	}

	public void ShakeCamera(float amount)
	{
		shakeAmount += amount;
	}

	public void ShakeCamera(Vector3 position, float amount, float distance)
	{
		float num = 1f - Mathf.Clamp01(Vector3.Distance(position, base.transform.position) / distance);
		ShakeCamera(amount * num);
	}

	public void SetCameraSway(float amount, float speed = 1f)
	{
		swayAmount = amount;
		swaySpeed = speed;
	}

	public static void CalculateShake(Vector3 position, float amount, float distance)
	{
		if (ShakeAtPosition != null)
		{
			ShakeAtPosition(position, amount, distance);
		}
	}

	public bool CanSeeTarget(Transform target, float maxAngle = 90f)
	{
		float num = ((!(camera != null)) ? Vector3.Angle(base.transform.forward, (target.position - base.transform.position).normalized) : Vector3.Angle(camera.transform.forward, (target.position - camera.transform.position).normalized));
		if (num < maxAngle)
		{
			return true;
		}
		return false;
	}
}
