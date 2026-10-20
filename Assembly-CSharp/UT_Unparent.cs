using UnityEngine;

public class UT_Unparent : MonoBehaviour
{
	public bool onStart;

	private void Start()
	{
		if (onStart)
		{
			UnParent();
		}
	}

	public void UnParent()
	{
		base.transform.parent = null;
	}
}
