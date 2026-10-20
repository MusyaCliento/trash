using UnityEngine;

public class UT_ScaleToFull : MonoBehaviour
{
	private float scaleTime;

	public float scaleSpeed = 1f;

	private void Start()
	{
		base.transform.localScale = Vector3.one * 0.01f;
	}

	private void Update()
	{
		if (scaleTime < 1f)
		{
			scaleTime += Time.deltaTime * scaleSpeed;
			base.transform.localScale = Vector3.Lerp(Vector3.one * 0.01f, Vector3.one, scaleTime);
		}
	}
}
