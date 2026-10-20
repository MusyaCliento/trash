using UnityEngine;

public class UT_LerpBetween : MonoBehaviour
{
	public Transform o1;

	public Transform o2;

	public float lerp = 0.5f;

	private void Update()
	{
		if (!CL_GameManager.gMan.isPaused)
		{
			base.transform.position = Vector3.Lerp(o1.position, o2.position, lerp);
		}
	}
}
