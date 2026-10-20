using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class UT_TriggerSpawner : MonoBehaviourGizmos, SaveableObject
{
	public float playerVicinity = 10f;

	public float spawnRange = 1f;

	public SpawnTable spawnTable;

	public List<GameObject> spawnObjects;

	public int minSpawnAmount = 1;

	public int maxSpawnAmount = 5;

	public bool useRays;

	public LayerMask spawnLayerMask;

	public bool spawnOnStart;

	public bool saveState;

	public string saveStateID = "";

	public bool useSeed;

	public int seed;

	private GameObject objectToSpawn;

	private Mesh gizmoMesh;

	public SpawnTable.SpawnSettings spawnSettings;

	public bool hasUpdated;

	private float startTime;

	private void Start()
	{
		startTime = Time.time + 0.2f;
		if (spawnOnStart)
		{
			Spawn();
		}
	}

	private void FixedUpdate()
	{
		if (!(startTime > Time.time) && !(CL_GameManager.gMan == null) && CL_GameManager.gMan.localPlayer != null && !(CL_GameManager.gMan.PlayerDistance(base.transform.position) > playerVicinity))
		{
			Spawn();
		}
	}

	public void Spawn()
	{
		if (!spawnSettings.RandomCheck())
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		Random.State state = Random.state;
		if (useSeed)
		{
			Random.InitState(seed);
		}
		int num = Random.Range(minSpawnAmount, maxSpawnAmount);
		for (int i = 0; i < num; i++)
		{
			if (useRays)
			{
				for (int j = 0; j < 5; j++)
				{
					if (Physics.Raycast(base.transform.position, Random.onUnitSphere, out var hitInfo, spawnRange, spawnLayerMask))
					{
						if (spawnTable != null)
						{
							Object.Instantiate(spawnTable.GetRandomSpawnObject().GetRandomPrefab(), hitInfo.point + hitInfo.normal * 0.05f, Quaternion.LookRotation(hitInfo.normal), base.transform.parent);
						}
						else
						{
							Object.Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], hitInfo.point + hitInfo.normal * 0.05f, Quaternion.LookRotation(hitInfo.normal), base.transform.parent);
						}
						break;
					}
					if (j == 5)
					{
						if (spawnTable != null)
						{
							Object.Instantiate(spawnTable.GetRandomSpawnObject().GetRandomPrefab(), base.transform.position + Random.insideUnitSphere * spawnRange, base.transform.rotation, base.transform.parent);
						}
						else
						{
							Object.Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], base.transform.position + Random.insideUnitSphere * spawnRange, base.transform.rotation, base.transform.parent);
						}
						break;
					}
				}
			}
			else if (spawnTable != null)
			{
				Object.Instantiate(spawnTable.GetRandomSpawnObject().GetRandomPrefab(), base.transform.position + Random.insideUnitSphere * spawnRange, base.transform.rotation, base.transform.parent);
			}
			else
			{
				Object.Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], base.transform.position + Random.insideUnitSphere * spawnRange, base.transform.rotation, base.transform.parent);
			}
		}
		base.gameObject.SetActive(value: false);
		if (useSeed)
		{
			Random.state = state;
		}
	}

	public void RefreshGizmo()
	{
		objectToSpawn = spawnObjects[0];
		if (objectToSpawn == null)
		{
			gizmoMesh = null;
			return;
		}
		if (objectToSpawn.GetComponentInChildren<MeshFilter>() != null)
		{
			gizmoMesh = objectToSpawn.GetComponentInChildren<MeshFilter>().sharedMesh;
			return;
		}
		SkinnedMeshRenderer componentInChildren = objectToSpawn.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			gizmoMesh = componentInChildren.sharedMesh;
		}
		else
		{
			gizmoMesh = null;
		}
	}

	private void OnDrawGizmos()
	{
		if ((object)gizmoMesh == null)
		{
			gizmoMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
		}
		Gizmos.color = Color.red;
		Gizmos.DrawMesh(gizmoMesh, base.transform.position, base.transform.rotation);
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.SphereOutline(base.transform.position, playerVicinity, new Color(1f, 0.561f, 0f, 0.25f));
			Draw.SphereOutline(base.transform.position, spawnRange, Color.red);
		}
		else
		{
			Draw.SphereOutline(base.transform.position, playerVicinity, new Color(1f, 0.561f, 0f, 0.003f));
		}
		if (GizmoContext.InSelection(this) || DebugCore.showSpawnChances)
		{
			ColorUtility.TryParseHtmlString("#fc8403", out var color);
			Draw.Label2D(base.transform.position + -Camera.current.transform.up * 0.5f, $"{spawnSettings.spawnChance * 100f}%", 16f, LabelAlignment.TopCenter, color);
		}
	}

	public bool CanSave(string[] flags = null)
	{
		return saveState;
	}

	public string GetSaveID()
	{
		return saveStateID;
	}

	public SaveableInfo GetSaveInfo()
	{
		return new SaveableInfo
		{
			id = saveStateID,
			data = base.gameObject.activeSelf.ToString()
		};
	}

	public void SetSaveInfo(SaveableInfo info, List<string> flags)
	{
		if (!bool.Parse(info.data))
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
