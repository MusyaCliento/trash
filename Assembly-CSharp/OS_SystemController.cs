using UnityEngine;

public class OS_SystemController : MonoBehaviour
{
	public void ExitComputer()
	{
		OS_Manager.GetCurrentOS().Deactivate();
	}
}
