using UnityEngine;

public class UT_ObjectSpawner : MonoBehaviour
{
	public GameObject spawnObject;

	public Transform spawnLocation;

	public void Spawn()
	{
		Object.Instantiate(spawnObject, spawnLocation.position, spawnLocation.rotation);
	}

	public void Spawn(GameObject o)
	{
		Object.Instantiate(o, spawnLocation.position, spawnLocation.rotation);
	}

	public void SpawnAtTransform(Transform t)
	{
		Object.Instantiate(spawnObject, t.position, t.rotation);
	}
}
