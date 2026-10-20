using System.Collections;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class ENV_TickEggSack : MonoBehaviourGizmos, Damageable
{
	public DEN_Hopper_Tick tickEntityAsset;

	public float playerProximitySpawnRadius = 5f;

	public int ticksToSpawn = 1;

	public Transform spawnPoint;

	public float tickSpawnForce = 5f;

	public float tickSpawnUpwardForce = 2f;

	public float tickRandomForceMultiplier = 2f;

	private bool hasSpawned;

	public UnityEvent onSpawnStartEvent;

	public UnityEvent onSpawnEvent;

	public UnityEvent onDamageEvent;

	public bool canSpawn = true;

	public float burstDelay = 0.5f;

	public float velocityPredictAmount = 1f;

	private void Start()
	{
	}

	private void Update()
	{
		if (canSpawn && !hasSpawned && CheckForPlayer())
		{
			hasSpawned = true;
			StartCoroutine(SpawnCoroutine());
		}
		IEnumerator SpawnCoroutine()
		{
			yield return new WaitForSeconds(Random.Range(0f, burstDelay));
			onSpawnStartEvent.Invoke();
		}
	}

	public void SpawnTicks()
	{
		if (canSpawn)
		{
			onSpawnEvent.Invoke();
			canSpawn = false;
			for (int i = 0; i < ticksToSpawn; i++)
			{
				DEN_Hopper_Tick dEN_Hopper_Tick = Object.Instantiate(tickEntityAsset, spawnPoint.position, Quaternion.Euler(0f, Random.Range(0, 360), 0f));
				dEN_Hopper_Tick.Start();
				Vector3 vector = ENT_Player.GetPlayer().transform.position + ENT_Player.GetPlayer().cCon.velocity * velocityPredictAmount;
				dEN_Hopper_Tick.transform.rotation = Quaternion.LookRotation(vector - base.transform.position);
				Vector3 vector2 = vector - base.transform.position;
				dEN_Hopper_Tick.rigid.AddForce(vector2 * tickSpawnForce * Random.Range(1f, tickRandomForceMultiplier) + Vector3.up * tickSpawnUpwardForce * Random.Range(1f, tickRandomForceMultiplier), ForceMode.VelocityChange);
				dEN_Hopper_Tick.SetTarget(ENT_Player.GetPlayer().transform);
				dEN_Hopper_Tick.SetTargetPosition(vector);
				dEN_Hopper_Tick.StartHopAttack(force: true, leap: false);
			}
		}
	}

	public bool CheckForPlayer()
	{
		if (CL_GameManager.HasActiveFlag("pacifyroaches"))
		{
			return false;
		}
		if (Vector3.Distance(ENT_Player.GetPlayer().transform.position, base.transform.position) <= playerProximitySpawnRadius)
		{
			return true;
		}
		return false;
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.WireSphere(base.transform.position, playerProximitySpawnRadius, Color.green);
	}

	public bool Damage(Damageable.DamageInfo info)
	{
		if (!canSpawn)
		{
			return false;
		}
		canSpawn = false;
		onDamageEvent.Invoke();
		return true;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}
}
