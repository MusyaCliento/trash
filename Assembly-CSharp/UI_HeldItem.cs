using UnityEngine;

public class UI_HeldItem : MonoBehaviour
{
	private void Start()
	{
	}

	private void OnEnable()
	{
		Vector3 position = OS_Manager.mousePosition;
		position.x = Mathf.Round(position.x / 2f) * 2f;
		position.y = Mathf.Round(position.y / 2f) * 2f;
		base.transform.position = position;
	}

	private void LateUpdate()
	{
		Vector3 position = Vector3.Lerp(base.transform.position, OS_Manager.mousePosition, Time.deltaTime * 10f);
		base.transform.position = position;
	}
}
