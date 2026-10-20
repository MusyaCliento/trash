using UnityEngine;

public class UT_OpenURL : MonoBehaviour
{
	public string address;

	public void Open()
	{
		Application.OpenURL(address);
	}
}
