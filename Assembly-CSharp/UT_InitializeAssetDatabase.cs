using UnityEngine;

public class UT_InitializeAssetDatabase : MonoBehaviour
{
	public WKAssetDatabase database;

	private void Awake()
	{
		CL_AssetManager.AddNewDatabase(database.id, database);
	}
}
