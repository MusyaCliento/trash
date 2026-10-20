using System.Collections;
using UnityEngine;

[DefaultExecutionOrder(-100000)]
[ExecuteInEditMode]
public class CL_Initializer : MonoBehaviour
{
	public WKAssetDatabase baseDatabase;

	private void Awake()
	{
		CL_AssetManager.baseDatabase = baseDatabase;
		CL_AssetManager.InitializeAssetManager();
	}

	private IEnumerator AwaitLoad()
	{
		yield return null;
	}
}
