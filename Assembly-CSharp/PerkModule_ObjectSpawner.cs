using System.Collections;
using UnityEngine;

public class PerkModule_ObjectSpawner : PerkModule
{
	public GameObject asset;

	public float spawnFrequency = 60f;

	private float spawnTimer;

	private float spawnAttemptTimer;

	private bool hasSpawned;

	public int numberToSpawn;

	private int currentSpawned;

	public float minimumDistance = 5f;

	public float checkStepDistance = 10f;

	public LayerMask hitMask;

	public float hitOffset = 0.5f;

	public Vector3 spawnRotation;

	public bool useLocators;

	public string locatorGroupID;

	public override void Update()
	{
		base.Update();
		if (CL_GameManager.gMan.isPaused)
		{
			return;
		}
		if (spawnTimer <= 0f)
		{
			spawnAttemptTimer -= Time.deltaTime;
			if (spawnAttemptTimer <= 0f)
			{
				if (Spawn())
				{
					spawnTimer = spawnFrequency;
				}
				else
				{
					spawnAttemptTimer = 2f;
				}
			}
		}
		else
		{
			spawnTimer -= Time.deltaTime;
		}
	}

	public bool Spawn()
	{
		Vector3 vector = Vector3.up + Random.insideUnitSphere * 0.8f;
		Vector3 vector2 = ENT_Player.playerObject.transform.position;
		if (useLocators)
		{
			Transform closestLocatorInGroupToPosition = UT_Locator.GetClosestLocatorInGroupToPosition(locatorGroupID, vector2 + Vector3.up * 25f);
			if (closestLocatorInGroupToPosition != null && closestLocatorInGroupToPosition.position.y > vector2.y && closestLocatorInGroupToPosition.position.y - vector2.y > minimumDistance)
			{
				SpawnObject(closestLocatorInGroupToPosition.position);
				return true;
			}
		}
		RaycastHit hitInfo;
		for (int i = 0; i < 3; i++)
		{
			Vector3 vector3 = ((!Physics.Raycast(vector2, vector, out hitInfo, checkStepDistance, hitMask)) ? (vector2 + vector * checkStepDistance) : hitInfo.point);
			vector2 = vector3;
			vector = Vector3.up + Random.insideUnitSphere * 1f;
		}
		if (Physics.Raycast(vector2, Vector3.down, out hitInfo, 20f, hitMask))
		{
			if (Vector3.Distance(hitInfo.point, ENT_Player.playerObject.transform.position) < minimumDistance)
			{
				return false;
			}
			Vector3 spawnPos = hitInfo.point + hitInfo.normal * hitOffset;
			SpawnObject(spawnPos);
			return true;
		}
		return false;
		void SpawnObject(Vector3 position)
		{
			Transform parent = null;
			if (WorldLoader.initialized)
			{
				parent = WorldLoader.instance.GetCurrentLevel().GetLevel().transform;
			}
			GameObject spawnObject = Object.Instantiate(asset, position, Quaternion.Euler(spawnRotation), parent);
			ENT_Player.playerObject.StartCoroutine(ScaleUpObject());
			IEnumerator ScaleUpObject()
			{
				float scaleTime = 0f;
				while (scaleTime < 1f)
				{
					scaleTime += Time.deltaTime;
					spawnObject.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, scaleTime);
					yield return null;
				}
			}
		}
	}
}
