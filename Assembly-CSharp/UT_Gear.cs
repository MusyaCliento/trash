using UnityEngine;

public class UT_Gear : MonoBehaviour
{
	public Vector3 rotateSpeed = Vector3.zero;

	private void Update()
	{
		if (!CL_GameManager.gMan.isPaused)
		{
			base.transform.Rotate(rotateSpeed * Time.deltaTime);
		}
	}
}
