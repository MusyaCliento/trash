using UnityEngine;

public class UT_LadderNightmare_Controller : MonoBehaviour
{
	public void SetNightmareDistance(float f)
	{
		DEN_LadderNightmare.SetPlayerOffset(f);
	}

	public void SetNightmareCanPeek(bool b)
	{
		DEN_LadderNightmare.SetCanPeek(b);
	}

	public void SetNightmareCanAttack(bool b)
	{
		DEN_LadderNightmare.SetCanAttack(b);
	}

	public void SetNightmareBreathing(bool b)
	{
		DEN_LadderNightmare.SetBreathing(b);
	}
}
