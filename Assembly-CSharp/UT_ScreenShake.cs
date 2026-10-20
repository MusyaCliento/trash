using System.Collections;
using UnityEngine;

public class UT_ScreenShake : MonoBehaviour
{
	public bool globalShake;

	public float radius = 10f;

	public float intensity = 0.2f;

	public bool constantShake;

	public bool shakeOverTime;

	public AnimationCurve shakeOverTimeCurve;

	public float shakeOverTimeLength = 1f;

	public void ShakeScreen()
	{
		if (shakeOverTime)
		{
			StartCoroutine(ShakeOverTime());
		}
		else if (!globalShake)
		{
			CL_CameraControl.CalculateShake(base.transform.position, intensity, radius);
		}
		else
		{
			CL_CameraControl.Shake(intensity);
		}
	}

	public void ShakeAmount(float f)
	{
		CL_CameraControl.Shake(f);
	}

	public void ShakeLocalAmount(float f)
	{
		CL_CameraControl.CalculateShake(base.transform.position, f, radius);
	}

	private IEnumerator ShakeOverTime()
	{
		float shakeTime = 0f;
		while (shakeTime < shakeOverTimeLength)
		{
			shakeTime += Time.deltaTime;
			float num = shakeOverTimeCurve.Evaluate(shakeTime / shakeOverTimeLength);
			if (!globalShake)
			{
				CL_CameraControl.CalculateShake(base.transform.position, intensity * num * Time.deltaTime, radius);
			}
			else
			{
				CL_CameraControl.Shake(intensity * Time.deltaTime);
			}
			yield return null;
		}
	}

	private void FixedUpdate()
	{
		if (constantShake)
		{
			CL_CameraControl.CalculateShake(base.transform.position, intensity * Time.fixedDeltaTime, radius);
		}
	}
}
