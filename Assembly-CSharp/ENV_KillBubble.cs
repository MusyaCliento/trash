using System.Collections;
using UnityEngine;

public class ENV_KillBubble : MonoBehaviour
{
	public bool active;

	public float growSpeed = 1f;

	public float sizeChecker = 1f;

	private float scale = 1f;

	public Transform bubbleTransform;

	public Transform effectTransform;

	private void Start()
	{
		scale = bubbleTransform.localScale.x;
		base.transform.parent = null;
	}

	private void Update()
	{
		if ((bool)effectTransform)
		{
			effectTransform.position = base.transform.position + (ENT_Player.playerObject.transform.position - base.transform.position).normalized * scale;
		}
		bubbleTransform.localScale = Vector3.one * scale;
		if (Vector3.Distance(base.transform.position, ENT_Player.playerObject.transform.position) < scale)
		{
			ENT_Player.playerObject.Kill("", null);
			Debug.Log("KillPlayer");
		}
	}

	public void GrowTo(float f)
	{
		StopAllCoroutines();
		StartCoroutine(ScaleTo(f));
	}

	private IEnumerator ScaleTo(float f)
	{
		float startScale = scale;
		float scaleTime = Mathf.Abs(f - startScale);
		float curScaleTime = scaleTime;
		while (curScaleTime > 0f)
		{
			curScaleTime -= Time.deltaTime * growSpeed;
			scale = Mathf.Lerp(f, startScale, curScaleTime / scaleTime);
			yield return null;
		}
	}
}
