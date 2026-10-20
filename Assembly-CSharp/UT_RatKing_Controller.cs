using UnityEngine;

public class UT_RatKing_Controller : MonoBehaviour
{
	public DEN_RatKing targetRatKing;

	public void MoveRatKingToTransform(Transform t)
	{
		targetRatKing.OverrideNavigationTargetPosition(t.position);
	}
}
