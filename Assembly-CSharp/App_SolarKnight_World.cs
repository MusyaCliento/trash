using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class App_SolarKnight_World : MonoBehaviourGizmos
{
	[Serializable]
	public class App_SolarKnight_GameEvent
	{
		public string eventID;

		public float minimumTime;

		public float maximumTime;

		public float timeBetweenSpawns = 30f;

		private float lastSpawnTime;

		public Action eventAction;

		public UnityEvent unityEventAction;

		public float eventChance = 1f;

		public bool oneTimeEvent;

		public bool hasOccurred;

		public bool isRunning;

		public bool canSpawnWhileRunning = true;

		public List<App_SolarKnight_Entity> spawnEntities = new List<App_SolarKnight_Entity>();

		private List<App_SolarKnight_Entity> spawnedEntities = new List<App_SolarKnight_Entity>();

		public bool clearScreenOnInvoke;

		public void InvokeEvent()
		{
			if ((oneTimeEvent && hasOccurred) || (instance.GetGameTime() - lastSpawnTime < timeBetweenSpawns && lastSpawnTime > 0f))
			{
				Debug.Log("SK -- Failed To Spawn: " + eventID + " :: " + lastSpawnTime + " :: " + instance.GetGameTime() + " :: " + oneTimeEvent + " :: " + hasOccurred);
				return;
			}
			Debug.Log("SK -- Spawning: " + eventID);
			if (clearScreenOnInvoke)
			{
				foreach (App_SolarKnight_Entity entity in instance.entities)
				{
					if (entity != instance.GetPlayer() && !entity.IsDestroyed())
					{
						entity.Kill(spawnDrops: false);
					}
				}
			}
			lastSpawnTime = instance.GetGameTime();
			eventAction?.Invoke();
			unityEventAction?.Invoke();
			hasOccurred = true;
			foreach (App_SolarKnight_Entity spawnEntity in spawnEntities)
			{
				spawnedEntities.Add(instance.SpawnEntity(spawnEntity, instance.transform.TransformPoint(instance.GetRandomBoundaryPosition()), Quaternion.identity));
			}
			isRunning = true;
		}

		public void EndEvent()
		{
			foreach (App_SolarKnight_Entity spawnedEntity in spawnedEntities)
			{
				if (spawnedEntity != null && !spawnedEntity.IsDestroyed())
				{
					spawnedEntity.Kill();
				}
			}
			spawnedEntities.Clear();
			isRunning = false;
		}

		public void ResetEvent()
		{
			hasOccurred = false;
			isRunning = false;
			lastSpawnTime = 0f;
		}
	}

	[Serializable]
	public class ParticleAsset
	{
		public string id;

		public ParticleSystem particleAsset;

		private ParticleSystem particleSystem;

		public void PlayParticle(Vector3 pos, int amount)
		{
			if (particleSystem == null)
			{
				particleSystem = UnityEngine.Object.Instantiate(particleAsset, FXManager.fxParticleParent);
			}
			ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
			{
				applyShapeToPosition = true,
				position = pos
			};
			particleSystem.Emit(emitParams, amount);
		}
	}

	public static App_SolarKnight_World instance;

	private App_SolarKnight app;

	public static float gameTimeScale = 1f;

	public static float gameFixedDeltaTime = 0.02f;

	public static float gameDeltaTime;

	public int width;

	public int height;

	public float boundaryWidth = 1f;

	public float boundaryForce = 10f;

	public int startAsteroidCount = 5;

	public App_SolarKnight_Player playerPrefab;

	public App_SolarKnight_Asteroid asteroidPrefab;

	private App_SolarKnight_Player playerInstance;

	private List<App_SolarKnight_Entity> entities = new List<App_SolarKnight_Entity>();

	public float asteroidSpawnRate = 5f;

	private float asteroidSpawnTimer;

	internal int curAsteroidCount;

	public List<App_SolarKnight_GameEvent> gameEvents;

	private float eventCheckTimer;

	private Dictionary<AudioClip, float> soundCooldowns = new Dictionary<AudioClip, float>();

	public static Transform fxParticleParent;

	public List<ParticleAsset> particleAssets;

	private Dictionary<string, ParticleAsset> particleDict;

	public void Initialize(App_SolarKnight game)
	{
		app = game;
	}

	private void Awake()
	{
		gameTimeScale = 1f;
		instance = this;
		Setup();
	}

	public void ResetWorld()
	{
		StartCoroutine(Reset());
		IEnumerator Reset()
		{
			foreach (App_SolarKnight_Entity entity in entities)
			{
				if (entity != null)
				{
					UnityEngine.Object.Destroy(entity.gameObject);
				}
			}
			entities.Clear();
			yield return null;
			ResetAllGameEvents();
			Setup();
		}
	}

	public void Setup()
	{
		Vector3 vector = new Vector3(0f, 0f, 0f);
		playerInstance = SpawnEntity(playerPrefab, vector, Quaternion.identity) as App_SolarKnight_Player;
		playerInstance.transform.localPosition = Vector3.zero;
		int num = startAsteroidCount;
		for (int i = 0; i < num; i++)
		{
			Vector3 vector2 = new Vector3(UnityEngine.Random.Range((float)(-width) / 2f, (float)width / 2f), UnityEngine.Random.Range((float)(-height) / 2f, (float)height / 2f), 0f);
			while (Vector3.Distance(vector2, vector) < 5f)
			{
				vector2 = new Vector3(UnityEngine.Random.Range((float)(-width) / 2f, (float)width / 2f), UnityEngine.Random.Range((float)(-height) / 2f, (float)height / 2f), 0f);
			}
			SpawnEntity(asteroidPrefab, vector2, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0, 360)));
		}
	}

	private void Update()
	{
		gameDeltaTime = Time.deltaTime * gameTimeScale;
		if (app.IsGameTimePaused())
		{
			return;
		}
		asteroidSpawnTimer -= Time.deltaTime;
		if (asteroidSpawnTimer <= 0f)
		{
			asteroidSpawnTimer = asteroidSpawnRate;
			if ((float)curAsteroidCount <= 8f)
			{
				Vector3 vector = Vector3.zero;
				bool flag = false;
				while (!flag)
				{
					float num = UnityEngine.Random.Range(0f, 4f);
					vector = ((num < 1f) ? new Vector3((float)(-width) / 2f, UnityEngine.Random.Range((float)(-height) / 2f, (float)height / 2f), 0f) : ((num < 2f) ? new Vector3((float)width / 2f, UnityEngine.Random.Range((float)(-height) / 2f, (float)height / 2f), 0f) : ((!(num < 3f)) ? new Vector3(UnityEngine.Random.Range((float)(-width) / 2f, (float)width / 2f), (float)height / 2f, 0f) : new Vector3(UnityEngine.Random.Range((float)(-width) / 2f, (float)width / 2f), (float)(-height) / 2f, 0f))));
					if (Vector3.Distance(vector, playerInstance.transform.position) > 5f)
					{
						flag = true;
					}
				}
				SpawnNewAsteroid(vector, UnityEngine.Random.Range(3, 6));
			}
		}
		CheckEvent();
	}

	private void CheckEvent()
	{
		eventCheckTimer -= Time.deltaTime;
		if (eventCheckTimer > 0f)
		{
			return;
		}
		float gameTime = GetGameTime();
		foreach (App_SolarKnight_GameEvent gameEvent in gameEvents)
		{
			if ((!gameEvent.isRunning || gameEvent.canSpawnWhileRunning) && gameTime >= gameEvent.minimumTime && (gameTime <= gameEvent.maximumTime || gameEvent.maximumTime == 0f) && UnityEngine.Random.Range(0f, 1f) <= gameEvent.eventChance)
			{
				gameEvent.InvokeEvent();
			}
		}
		eventCheckTimer = 5f;
	}

	private void PushEntitiesTowardsPlayArea()
	{
		foreach (App_SolarKnight_Entity entity in entities)
		{
			if (!entity.IsDestroyed())
			{
				Vector3 localPosition = entity.transform.localPosition;
				Vector3 zero = Vector3.zero;
				if (localPosition.x < (float)(-width / 2) + boundaryWidth)
				{
					zero.x = boundaryForce;
				}
				else if (localPosition.x > (float)(width / 2) - boundaryWidth)
				{
					zero.x = 0f - boundaryForce;
				}
				if (localPosition.y < (float)(-height / 2) + boundaryWidth)
				{
					zero.y = boundaryForce;
				}
				else if (localPosition.y > (float)(height / 2) - boundaryWidth)
				{
					zero.y = 0f - boundaryForce;
				}
				entity.velocity += zero * gameFixedDeltaTime;
			}
		}
	}

	public bool IsInBoundaryZone(Vector3 position)
	{
		if (Mathf.Abs(position.x) > (float)(width / 2) - boundaryWidth || Mathf.Abs(position.y) > (float)(height / 2) - boundaryWidth)
		{
			return true;
		}
		return false;
	}

	private void FixedUpdate()
	{
		gameFixedDeltaTime = Time.fixedDeltaTime * gameTimeScale;
		PushEntitiesTowardsPlayArea();
	}

	public App_SolarKnight_Entity SpawnEntity(App_SolarKnight_Entity entityPrefab, Vector3 position, Quaternion rotation)
	{
		App_SolarKnight_Entity app_SolarKnight_Entity = UnityEngine.Object.Instantiate(entityPrefab, position, rotation, base.transform);
		entities.Add(app_SolarKnight_Entity);
		return app_SolarKnight_Entity;
	}

	public void SpawnNewAsteroid(Vector3 position, int size)
	{
		App_SolarKnight_Asteroid obj = SpawnEntity(asteroidPrefab, base.transform.position + position, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0, 360))) as App_SolarKnight_Asteroid;
		obj.size = size;
		obj.velocity = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0f).normalized * UnityEngine.Random.Range(5f, 10f);
		obj.AddVelocity(-obj.transform.localPosition.normalized * UnityEngine.Random.Range(30f, 100f));
		obj.angularVelocity = UnityEngine.Random.Range(-30f, 30f);
	}

	public Vector3 CalculatePosition(Vector3 pos, App_SolarKnight_Entity entity = null)
	{
		bool flag = false;
		if (Mathf.Abs(pos.x) > (float)(width / 2))
		{
			pos.x = 0f - pos.x;
			flag = true;
		}
		if (Mathf.Abs(pos.y) > (float)(height / 2))
		{
			pos.y = 0f - pos.y;
			flag = true;
		}
		pos.x = Mathf.Clamp(pos.x, -width / 2, width / 2);
		pos.y = Mathf.Clamp(pos.y, -height / 2, height / 2);
		if (flag && entity != null)
		{
			entity.OnTeleport();
		}
		return pos;
	}

	public Vector3 GetRandomBoundaryPosition()
	{
		float num = UnityEngine.Random.Range(0f, 4f);
		Vector3 zero = Vector3.zero;
		return (num < 1f) ? new Vector3((float)(-width) / 2f, UnityEngine.Random.Range((float)(-height) / 2f, (float)height / 2f), 0f) : ((num < 2f) ? new Vector3((float)width / 2f, UnityEngine.Random.Range((float)(-height) / 2f, (float)height / 2f), 0f) : ((!(num < 3f)) ? new Vector3(UnityEngine.Random.Range((float)(-width) / 2f, (float)width / 2f), (float)height / 2f, 0f) : new Vector3(UnityEngine.Random.Range((float)(-width) / 2f, (float)width / 2f), (float)(-height) / 2f, 0f)));
	}

	public void AddScore(int points)
	{
		app.AddScore(points);
	}

	public App_SolarKnight GetApp()
	{
		return app;
	}

	public void RespawnPlayer()
	{
		playerInstance.transform.localPosition = Vector3.zero;
		playerInstance.velocity = Vector3.zero;
		playerInstance.angularVelocity = 0f;
		playerInstance.gameObject.SetActive(value: true);
		playerInstance.health = 1f;
		DestroyEntitiesInRadius(playerInstance.transform.position, 5f, playerInstance);
	}

	public List<App_SolarKnight_Entity> GetEntitiesInRadius(Vector3 position, float radius, App_SolarKnight_Entity excludeEntity = null)
	{
		List<App_SolarKnight_Entity> list = new List<App_SolarKnight_Entity>();
		foreach (App_SolarKnight_Entity entity in entities)
		{
			if (entity != excludeEntity && !entity.IsDestroyed() && Vector3.Distance(position, entity.transform.position) <= radius)
			{
				list.Add(entity);
			}
		}
		return list;
	}

	public void DestroyEntitiesInRadius(Vector3 position, float radius, App_SolarKnight_Entity excludeEntity = null, bool spawnDrops = false)
	{
		foreach (App_SolarKnight_Entity item in GetEntitiesInRadius(position, radius, excludeEntity))
		{
			item.Kill(spawnDrops);
		}
	}

	internal void RegisterEntity(App_SolarKnight_Entity app_SolarKnight_Entity)
	{
		if (!entities.Contains(app_SolarKnight_Entity))
		{
			entities.Add(app_SolarKnight_Entity);
		}
		app_SolarKnight_Entity.transform.parent = base.transform;
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.WireBox(base.transform.position, new Vector3(width, height, 1f));
		Draw.WireBox(base.transform.position, new Vector3((float)width - boundaryWidth * 2f, (float)height - boundaryWidth * 2f, 1f), Color.red);
	}

	public void PlaySound(AudioClip clip, float volume = 1f)
	{
		if (!soundCooldowns.ContainsKey(clip))
		{
			soundCooldowns[clip] = -10f;
		}
		soundCooldowns.TryGetValue(clip, out var value);
		if (Time.time - value > 0.15f)
		{
			AudioManager.PlayUISound(clip, volume);
			soundCooldowns[clip] = Time.time;
		}
	}

	public void PlayParticle(string id, Vector3 pos, int amount)
	{
		if (particleDict == null)
		{
			particleDict = new Dictionary<string, ParticleAsset>();
			foreach (ParticleAsset particleAsset in particleAssets)
			{
				particleDict[particleAsset.id] = particleAsset;
			}
		}
		if (particleDict.ContainsKey(id))
		{
			particleDict[id].PlayParticle(pos, amount);
		}
	}

	internal App_SolarKnight_Player GetPlayer()
	{
		return playerInstance;
	}

	public float GetGameTime()
	{
		return app.GetGameTime();
	}

	public void PauseGameTime()
	{
		app.PauseGameTime();
	}

	public void ResumeGameTime()
	{
		app.ResumeGameTime();
	}

	public void SetGameTimeScale(float scale)
	{
		gameTimeScale = scale;
	}

	public void ResetAllGameEvents()
	{
		foreach (App_SolarKnight_GameEvent gameEvent in gameEvents)
		{
			if (gameEvent.isRunning)
			{
				gameEvent.EndEvent();
			}
			gameEvent.ResetEvent();
		}
	}

	internal List<App_SolarKnight_Entity> GetEntitiesWithTag(string tag)
	{
		List<App_SolarKnight_Entity> list = new List<App_SolarKnight_Entity>();
		foreach (App_SolarKnight_Entity entity in entities)
		{
			if (entity.HasTag(tag))
			{
				list.Add(entity);
			}
		}
		return list;
	}
}
