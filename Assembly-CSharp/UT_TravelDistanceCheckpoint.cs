using UnityEngine;

public class UT_TravelDistanceCheckpoint : MonoBehaviour
{
	public float spacewarp = 1f;

	public void SetCheckpoint()
	{
		CL_GameManager.gMan.SetPlayerDistanceCheckPosition(ENT_Player.playerObject.transform.position, spacewarp);
	}
}
