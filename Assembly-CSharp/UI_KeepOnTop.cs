using UnityEngine;

public class UI_KeepOnTop : MonoBehaviour
{
	private void Update()
	{
		base.transform.SetAsLastSibling();
	}
}
