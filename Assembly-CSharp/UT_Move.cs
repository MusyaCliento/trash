using UnityEngine;

public class UT_Move : MonoBehaviour
{
	public Vector3 velocity;

	private void Update()
	{
		if (!CL_GameManager.gMan.isPaused)
		{
			base.transform.position += velocity * Time.deltaTime;
		}
	}
}
