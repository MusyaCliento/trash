using UnityEngine;

public class UT_TeethController : MonoBehaviour
{
	public void RemoveTeeth()
	{
		if (DEN_Teeth.instance != null)
		{
			DEN_Teeth.instance.Despawn();
		}
	}
}
