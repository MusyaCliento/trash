using UnityEngine;

public class UT_GooTakeover : MonoBehaviour
{
	public bool active;

	private void Update()
	{
		if (active && DEN_DeathFloor.instance != null)
		{
			DEN_DeathFloor.instance.transform.position = base.transform.position;
		}
	}
}
