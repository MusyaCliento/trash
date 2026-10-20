using UnityEngine;

public class Crosshair : MonoBehaviour
{
	private void Update()
	{
		base.transform.position = Input.mousePosition;
	}
}
