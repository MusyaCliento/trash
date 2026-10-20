using UnityEngine;

public class UT_SimpleModule : MonoBehaviour
{
	[SerializeReference]
	public SimpleModule module;

	public void ActivateModule()
	{
		if (module != null)
		{
			module.Activate();
		}
	}

	public void DeactivateModule()
	{
		if (module != null)
		{
			module.Deactivate();
		}
	}
}
