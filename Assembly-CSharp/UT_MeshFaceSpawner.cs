using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class UT_MeshFaceSpawner : MonoBehaviourGizmos
{
	public SpawnTable spawnTable;

	public List<GameObject> spawnObjects;

	public int minSpawnAmount = 1;

	public int maxSpawnAmount = 5;

	public bool spawnOnStart;

	public Transform parentObject;

	public bool checkTargetParentForSpawnReduction;

	private List<Vector3> testSamples;

	public bool useSeed;

	public int seed;

	private void Start()
	{
		if (spawnOnStart)
		{
			Spawn();
		}
	}

	public void Spawn()
	{
		if (useSeed)
		{
			Random.InitState(seed++);
		}
		int num = Random.Range(minSpawnAmount, maxSpawnAmount);
		Transform parent;
		if (parentObject != null)
		{
			if (checkTargetParentForSpawnReduction)
			{
				int num2 = parentObject.childCount;
				for (int num3 = num2 - 1; num3 >= 0; num3--)
				{
					Transform child = parentObject.GetChild(num3);
					if (!child.gameObject.activeSelf)
					{
						Object.Destroy(child.gameObject);
						num2--;
					}
				}
				num = Mathf.Min(num, num - num2);
			}
			parent = parentObject;
		}
		else
		{
			parent = base.transform.parent;
		}
		if (useSeed)
		{
			Random.InitState(seed++);
		}
		num = Mathf.Max(num, 0);
		if (num == 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			if (spawnTable != null)
			{
				Object.Instantiate(spawnTable.GetRandomSpawnObject().GetRandomPrefab(), RandomMeshPointSampler.SamplePointWorld(GetComponent<MeshFilter>().sharedMesh, base.transform), base.transform.rotation, parent);
			}
			else
			{
				Object.Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], RandomMeshPointSampler.SamplePointWorld(GetComponent<MeshFilter>().sharedMesh, base.transform), base.transform.rotation, parent);
			}
		}
	}

	public override void DrawGizmos()
	{
		if (testSamples == null)
		{
			testSamples = new List<Vector3>();
		}
		if (!GizmoContext.InSelection(this))
		{
			return;
		}
		if (testSamples.Count != maxSpawnAmount)
		{
			testSamples.Clear();
			for (int i = 0; i < maxSpawnAmount; i++)
			{
				testSamples.Add(RandomMeshPointSampler.SamplePointWorld(GetComponent<MeshFilter>().sharedMesh, base.transform));
			}
		}
		for (int j = 0; j < maxSpawnAmount; j++)
		{
			Draw.SphereOutline(testSamples[j], 0.2f, Color.yellow);
		}
	}
}
