using UnityEngine;

public class UT_RotateToFaceDirection : MonoBehaviour
{
	public bool faceAtStart;

	private bool facing;

	public Vector3 direction = Vector3.forward;

	public Vector3 upDirection = Vector3.forward;

	private void Start()
	{
		if (faceAtStart)
		{
			facing = true;
		}
	}

	private void Update()
	{
		if (facing)
		{
			Vector3 upwards = base.transform.TransformDirection(upDirection);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(direction, upwards), Time.deltaTime * 5f);
		}
	}

	public void FaceDirection()
	{
		facing = true;
	}
}
