using System;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class ENV_DenizenWaveZone : MonoBehaviourGizmos
{
	[Serializable]
	public class DenizenSpawnInfo
	{
		public Denizen denizenPrefab;

		public float spawnChance;

		public string spawnPointTag;
	}

	[Serializable]
	public class DenizenSpawnPoint
	{
		public Transform spawnPoint;

		public float spawnChance;

		public List<string> spawnTags;
	}

	public bool active = true;

	public Bounds waveZoneBounds;

	public int maxDenizensInZone = 10;

	public int maxTotalSpawn = -1;

	private int totalSpawned;

	private bool canSpawn = true;

	public List<DenizenSpawnPoint> spawnPoints = new List<DenizenSpawnPoint>();

	public List<DenizenSpawnInfo> denizenSpawnInfos = new List<DenizenSpawnInfo>();

	private List<Denizen> denizensInZone = new List<Denizen>();

	public float minimumSpawnDistanceFromPlayer = 30f;

	public float spawnCheckInterval = 5f;

	private float spawnCheckTimer;

	public bool huntPlayer = true;

	public float huntPlayerDistanceThreshold = 10f;

	public int spawnDenizensOnFirstEnter;

	private bool hasPlayerEntered;

	private bool isPlayerInside;

	public UnityEvent<Denizen> DenizenSpawnEvent;

	private void Start()
	{
	}

	private void Update()
	{
		if (!active)
		{
			return;
		}
		if (IsPlayerInWaveZone())
		{
			if (!hasPlayerEntered)
			{
				OnFirstEnter();
				hasPlayerEntered = true;
			}
			isPlayerInside = true;
		}
		else
		{
			isPlayerInside = false;
		}
		SpawnRoutine();
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Label2D(base.transform.position, "Denizens in zone: " + denizensInZone.Count + " / " + maxDenizensInZone, Color.magenta);
		}
	}

	private void OnFirstEnter()
	{
		if (spawnDenizensOnFirstEnter > 0)
		{
			SpawnDenizens(spawnDenizensOnFirstEnter);
		}
	}

	public void SpawnRoutine()
	{
		spawnCheckTimer += Time.deltaTime;
		if (spawnCheckTimer < spawnCheckInterval)
		{
			return;
		}
		spawnCheckTimer = 0f;
		if (huntPlayer && IsPlayerInWaveZone())
		{
			foreach (Denizen item in denizensInZone)
			{
				if (DarkMachineFunctions.GetManhattanDistance(item.transform.position, ENT_Player.GetPlayer().transform.position) > huntPlayerDistanceThreshold)
				{
					item.SetNavigationTargetPosition(ENT_Player.GetPlayer().transform.position + UnityEngine.Random.onUnitSphere * 5f);
				}
			}
		}
		if (canSpawn && denizensInZone.Count < maxDenizensInZone && IsPlayerInWaveZone())
		{
			SpawnDenizens();
		}
	}

	private void SpawnDenizens(int count = 1)
	{
		if (!canSpawn)
		{
			return;
		}
		if (maxTotalSpawn > 0 && totalSpawned > maxTotalSpawn)
		{
			canSpawn = false;
			return;
		}
		for (int i = 0; i < count; i++)
		{
			float num = 0f;
			foreach (DenizenSpawnInfo denizenSpawnInfo in denizenSpawnInfos)
			{
				num += denizenSpawnInfo.spawnChance;
			}
			float num2 = UnityEngine.Random.Range(0f, num);
			float num3 = 0f;
			foreach (DenizenSpawnInfo denizenSpawnInfo2 in denizenSpawnInfos)
			{
				num3 += denizenSpawnInfo2.spawnChance;
				if (!(num2 <= num3))
				{
					continue;
				}
				DenizenSpawnPoint denizenSpawnPoint = null;
				List<DenizenSpawnPoint> list = new List<DenizenSpawnPoint>();
				foreach (DenizenSpawnPoint spawnPoint in spawnPoints)
				{
					bool flag = true;
					foreach (string spawnTag in spawnPoint.spawnTags)
					{
						if (!denizenSpawnInfo2.spawnPointTag.Contains(spawnTag))
						{
							flag = false;
							break;
						}
					}
					if (flag && GetManhattenDistanceFromPlayer(spawnPoint.spawnPoint.position) >= minimumSpawnDistanceFromPlayer)
					{
						list.Add(spawnPoint);
					}
				}
				if (list.Count > 0)
				{
					Vector3 position = list[UnityEngine.Random.Range(0, list.Count)]?.spawnPoint.position ?? base.transform.position;
					Denizen newDenizen = UnityEngine.Object.Instantiate(denizenSpawnInfo2.denizenPrefab, position, Quaternion.identity, base.transform);
					totalSpawned++;
					denizensInZone.Add(newDenizen);
					Denizen denizen = newDenizen;
					denizen._OnDeath = (Action<GameEntity>)Delegate.Combine(denizen._OnDeath, (Action<GameEntity>)delegate
					{
						denizensInZone.Remove(newDenizen);
					});
					DenizenSpawnEvent.Invoke(newDenizen);
				}
				break;
			}
		}
	}

	public bool IsPlayerInWaveZone()
	{
		Vector3 position = ENT_Player.GetPlayer().transform.position;
		return waveZoneBounds.Contains(base.transform.InverseTransformPoint(position));
	}

	public float GetManhattenDistanceFromPlayer(Vector3 position)
	{
		Vector3 position2 = ENT_Player.GetPlayer().transform.position;
		Vector3 vector = position - position2;
		return Mathf.Abs(vector.x) + Mathf.Abs(vector.y) + Mathf.Abs(vector.z);
	}

	public void ClearAllDenizens()
	{
		foreach (Denizen item in denizensInZone)
		{
			if (item != null)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}
		denizensInZone.Clear();
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.WireBox(base.transform.position + waveZoneBounds.center, base.transform.rotation, waveZoneBounds.size, Color.cyan);
		foreach (DenizenSpawnPoint spawnPoint in spawnPoints)
		{
			if (spawnPoint.spawnPoint != null)
			{
				Draw.WireSphere(spawnPoint.spawnPoint.position, 0.5f, Color.yellow);
			}
		}
	}

	public void FillSpawnListFromChildren()
	{
		spawnPoints.Clear();
		foreach (Transform item in base.transform)
		{
			DenizenSpawnPoint denizenSpawnPoint = new DenizenSpawnPoint();
			denizenSpawnPoint.spawnPoint = item;
			spawnPoints.Add(denizenSpawnPoint);
			denizenSpawnPoint.spawnChance = 1f;
		}
	}

	public void SetActive(bool value)
	{
		active = value;
	}
}
