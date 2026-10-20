using System;
using UnityEngine;

public class UT_FaceCamera : MonoBehaviour
{
	public float verticalMult = 1f;

	public bool keepConsistentScale;

	public float scaleFactor = 1f;

	public bool consistentScaleOverDistance;

	public AnimationCurve distanceScaleCurve;

	public float maxScaleDistance = 100f;

	public bool alignToCameraFacing;

	public bool useParentForward;

	private void OnEnable()
	{
		Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(OnPreRenderCallback));
	}

	private void OnPreRenderCallback(Camera cam)
	{
		Vector3 position = cam.transform.position;
		Vector3 forward = cam.transform.forward;
		position.y *= verticalMult;
		Vector3 position2 = base.transform.position;
		position2.y *= verticalMult;
		forward.y *= verticalMult;
		base.transform.rotation = Quaternion.LookRotation(position2 - (position + forward * -1f), Vector3.up);
		if (alignToCameraFacing)
		{
			base.transform.rotation = Quaternion.LookRotation(-forward, cam.transform.up);
		}
		if (useParentForward && base.transform.parent != null)
		{
			base.transform.rotation = Quaternion.LookRotation(base.transform.parent.forward, cam.transform.up);
		}
		if (keepConsistentScale)
		{
			float num = Vector3.Distance(base.transform.position, cam.transform.position);
			float num2 = 1f;
			if (consistentScaleOverDistance)
			{
				num2 = distanceScaleCurve.Evaluate(num / maxScaleDistance);
			}
			base.transform.localScale = Vector3.one * num * scaleFactor * num2;
		}
	}

	private void OnDisable()
	{
		Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(OnPreRenderCallback));
	}
}
