using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_SPT_Spawner : MonoBehaviourGizmos
{
	public bool spawnOnStart = true;

	[Header("Table and Spawning Settings")]
	public SpawnTable spawnTable;

	public bool scaleUp = true;

	public bool forceSpawnIfNoSpaceFound;

	public float searchRadius = 5f;

	public int maxAttempts = 10;

	[Range(0f, 10f)]
	public int minSpawnAmount = 1;

	[Range(0f, 10f)]
	public int maxSpawnAmount = 1;

	public Vector3 startForce;

	public float spherizedForce;

	public float randomOffset;

	[Header("Placement Options")]
	public bool placeBottomAtSpawner;

	public bool setParentToCurrentLevel = true;

	public bool randomRotation;

	[Header("Debug Options")]
	public bool debugDraw;

	public UnityEvent<string> OnSpawnEvent;

	private void Start()
	{
		if (spawnOnStart)
		{
			Spawn();
		}
	}

	public void Spawn()
	{
		Spawn("");
	}

	public void Spawn(string spawnID)
	{
		if (spawnTable == null)
		{
			Debug.LogWarning("No spawn table assigned to spawner.");
			return;
		}
		int num = Random.Range(minSpawnAmount, maxSpawnAmount + 1);
		for (int i = 0; i < num; i++)
		{
			Vector3 vector = Random.insideUnitSphere * randomOffset;
			SpawnTable.SpawnTableAsset spawnTableAsset = spawnTable.GetRandomSpawnObject();
			if (!string.IsNullOrEmpty(spawnID))
			{
				spawnTableAsset = spawnTable.GetSpawnObject(spawnID);
			}
			if (spawnTableAsset == null || spawnTableAsset.prefabs == null)
			{
				Debug.LogWarning("No valid object chosen or prefab missing in the table.");
				break;
			}
			Quaternion rotation = base.transform.rotation;
			if (randomRotation)
			{
				rotation = Quaternion.Euler(Random.value * 20f, Random.value * 180f, Random.value * 20f) * base.transform.rotation;
			}
			GameObject gameObject = Object.Instantiate(spawnTableAsset.GetRandomPrefab(), base.transform.position + vector, rotation);
			if (spawnTableAsset.data != null && spawnTableAsset.data.Count > 0 && gameObject.TryGetComponent<Item_Object>(out var component))
			{
				component.itemData.data = new List<string>();
				component.itemData.data.AddRange(spawnTableAsset.data);
			}
			OnSpawnEvent.Invoke(spawnTableAsset.name);
			if (spherizedForce > 0f)
			{
				gameObject.GetComponent<GameEntity>()?.AddForce(Random.onUnitSphere * spherizedForce + startForce);
			}
			if (setParentToCurrentLevel && WorldLoader.initialized)
			{
				gameObject.transform.parent = WorldLoader.instance.GetCurrentLevel().GetLevel().transform;
			}
			if (scaleUp)
			{
				StartCoroutine(SpawnScale(gameObject.transform));
			}
		}
	}

	public bool TryGetSpawnPosition(GameObject prefab, out Vector3 spawnPos, out Bounds spawnBounds, bool dryRun = false)
	{
		spawnPos = base.transform.position;
		spawnBounds = default(Bounds);
		if (prefab == null)
		{
			return false;
		}
		MeshFilter[] componentsInChildren = prefab.GetComponentsInChildren<MeshFilter>();
		if (componentsInChildren == null || componentsInChildren.Length == 0)
		{
			Draw.Cross(base.transform.position, 0.5f, Color.yellow);
			spawnBounds = new Bounds(base.transform.position, Vector3.zero);
			spawnPos = AdjustForBottom(base.transform.position, spawnBounds.extents);
			if (dryRun)
			{
				return true;
			}
			if (!IsOverlapping(spawnPos, spawnBounds.extents))
			{
				return true;
			}
			return false;
		}
		spawnBounds = componentsInChildren[0].sharedMesh.bounds;
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			spawnBounds.Encapsulate(componentsInChildren[i].sharedMesh.bounds);
		}
		Draw.WireBox(base.transform.position, spawnBounds.extents, Color.yellow);
		Vector3 extents = spawnBounds.extents;
		spawnBounds.size.Scale(prefab.transform.localScale);
		Vector3 position = base.transform.position;
		if (dryRun)
		{
			spawnPos = AdjustForBottom(position, extents);
			return true;
		}
		Vector3 vector = AdjustForBottom(position, extents);
		if (!IsOverlapping(vector, extents))
		{
			spawnPos = vector;
			return true;
		}
		for (int j = 0; j < maxAttempts; j++)
		{
			Vector3 vector2 = Random.insideUnitSphere * searchRadius;
			Vector3 candidatePos = position + vector2;
			candidatePos = AdjustForBottom(candidatePos, extents);
			if (!IsOverlapping(candidatePos, extents))
			{
				spawnPos = candidatePos;
				return true;
			}
		}
		return false;
	}

	private IEnumerator SpawnScale(Transform targetObject)
	{
		Vector3 scaleTarget = Vector3.one;
		if (targetObject != null)
		{
			scaleTarget = targetObject.localScale;
			targetObject.localScale = scaleTarget * 0.1f;
		}
		while (targetObject != null && Vector3.Distance(targetObject.localScale, scaleTarget) > 0.01f)
		{
			if (!targetObject.gameObject.activeSelf)
			{
				targetObject.localScale = scaleTarget;
				yield break;
			}
			targetObject.localScale = Vector3.Lerp(targetObject.localScale, scaleTarget, Time.deltaTime * 5f);
			yield return 0;
		}
		if (targetObject != null)
		{
			targetObject.localScale = scaleTarget;
		}
	}

	private Vector3 AdjustForBottom(Vector3 candidatePos, Vector3 halfExtents)
	{
		if (placeBottomAtSpawner)
		{
			candidatePos.y = base.transform.position.y + halfExtents.y;
		}
		return candidatePos;
	}

	private bool IsOverlapping(Vector3 position, Vector3 halfExtents)
	{
		return Physics.OverlapBox(position, halfExtents, Quaternion.identity).Length != 0;
	}

	public override void DrawGizmos()
	{
		if (debugDraw && !(spawnTable == null))
		{
			DrawDebugCube();
		}
	}

	private void DrawDebugCube()
	{
	}
}
