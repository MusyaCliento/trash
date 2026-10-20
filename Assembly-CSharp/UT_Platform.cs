using Drawing;
using UnityEngine;

public class UT_Platform : MonoBehaviourGizmos
{
	public Transform startPoint;

	public Transform endPoint;

	public float speedMult = 1f;

	public float curPosition;

	private float moveSpeed;

	public UT_AudioEffects audioEffects;

	private void Update()
	{
		float num = Vector3.Distance(startPoint.position, endPoint.position);
		curPosition += moveSpeed * Time.deltaTime * speedMult;
		curPosition = Mathf.Clamp(curPosition, 0f, num);
		base.transform.position = Vector3.Lerp(startPoint.position, endPoint.position, curPosition / num);
		base.transform.rotation = Quaternion.Lerp(startPoint.rotation, endPoint.rotation, curPosition / num);
		if (audioEffects != null)
		{
			if (curPosition > 0f && curPosition < num && Mathf.Abs(moveSpeed) > 0f)
			{
				audioEffects.FadeIn();
			}
			else
			{
				audioEffects.FadeOut();
			}
		}
	}

	public void SetMoveSpeed(float m)
	{
		moveSpeed = m;
	}

	public override void DrawGizmos()
	{
		if (!(startPoint == null) && !(endPoint == null))
		{
			float num = Vector3.Distance(startPoint.position, endPoint.position);
			Draw.Arrow(startPoint.position, endPoint.position, base.transform.up, 0.5f, Color.green);
			Draw.WireBox(Vector3.Lerp(startPoint.position, endPoint.position, curPosition / num), Vector3.one, Color.white);
		}
	}
}
