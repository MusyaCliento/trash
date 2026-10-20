using UnityEngine;

public class UT_PhageController : MonoBehaviour
{
	public void SendDistantPhagesToPlayer()
	{
		if (DEN_Phage.activePhages == null)
		{
			return;
		}
		foreach (DEN_Phage activePhage in DEN_Phage.activePhages)
		{
			if (Vector3.Distance(activePhage.transform.position, ENT_Player.GetPlayer().transform.position) > 50f)
			{
				activePhage.SetNavigationTarget(ENT_Player.GetPlayer().transform.position + Random.insideUnitSphere * 30f);
			}
		}
	}
}
