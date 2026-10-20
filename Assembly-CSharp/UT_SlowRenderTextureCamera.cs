using UnityEngine;

[DefaultExecutionOrder(20)]
public class UT_SlowRenderTextureCamera : MonoBehaviour
{
	public float frameRate = 10f;

	private float frameTime;

	public float randomFrameRate;

	private Camera cam;

	private void Start()
	{
		cam = GetComponent<Camera>();
		cam.enabled = false;
	}

	private void LateUpdate()
	{
		frameTime -= Time.deltaTime;
		if (frameTime <= 0f)
		{
			frameTime = 1f / (frameRate + Random.value * randomFrameRate);
			cam.Render();
		}
	}
}
