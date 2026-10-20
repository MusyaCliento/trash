using UnityEngine;

public class ETAS_Manager : MonoBehaviour
{
	private static bool onTop;

	public static bool isOnTop => onTop;

	private void Start()
	{
	}

	private void Update()
	{
		onTop = IsOnTop();
	}

	private bool IsOnTop()
	{
		if (base.transform.parent != null)
		{
			return base.transform.GetSiblingIndex() == base.transform.parent.childCount - 1;
		}
		return true;
	}
}
