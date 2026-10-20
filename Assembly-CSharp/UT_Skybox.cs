using UnityEngine;

public class UT_Skybox : MonoBehaviour
{
	private void Start()
	{
		base.transform.parent = WorldLoader.GetWorldLoaderNullParent();
		WorldLoader.SkyboxManager.AddSkybox(base.gameObject);
	}
}
