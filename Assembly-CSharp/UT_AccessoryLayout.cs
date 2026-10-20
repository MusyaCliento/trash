using UnityEngine;

public class UT_AccessoryLayout : MonoBehaviour
{
	public Camera cam;

	public Vector3 position = new Vector3(0.5f, 0.5f, 1f);

	public Vector3 offset = Vector3.zero;

	private void Start()
	{
		if (cam == null)
		{
			cam = GetComponentInParent<Camera>();
		}
	}

	private void Update()
	{
		Place();
	}

	public void Place()
	{
		if (cam == null)
		{
			cam = GetComponentInParent<Camera>();
		}
		Vector3 vector = position;
		Vector3 vector2 = offset;
		if (base.transform.parent.localScale.x < 0f)
		{
			vector.x = 1f - vector.x;
			vector2.x = 0f - vector2.x;
		}
		vector.x *= cam.pixelWidth;
		vector.y *= cam.pixelHeight;
		Vector3 vector3 = cam.ScreenToWorldPoint(vector);
		base.transform.position = vector3 + cam.transform.TransformVector(vector2);
	}
}
