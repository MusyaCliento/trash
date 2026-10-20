using UnityEngine;

public class UT_DestroyChildren : MonoBehaviour
{
	public void DestroyAllChildren()
	{
		foreach (Transform item in base.transform)
		{
			Object.Destroy(item.gameObject);
		}
	}
}
