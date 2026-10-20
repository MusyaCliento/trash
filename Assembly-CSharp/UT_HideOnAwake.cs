using UnityEngine;

public class UT_HideOnAwake : MonoBehaviour
{
	private void Awake()
	{
		base.gameObject.SetActive(value: false);
	}
}
