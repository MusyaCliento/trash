using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DEN_GantryTurret : DEN_BasicDenizen
{
	public float moveSpeed;

	public Ease moveEase;

	public float repositionHeightAdvantage = 6f;

	public float repositionMaxHeightDifference = 10f;

	public float repositionTimerMin = 4f;

	public float repositionTimerMax = 8f;

	public List<Transform> eyes;

	public Ease eyeRotateEase;

	private Vector3 moveTargetPosition;

	private float repositionTimer;

	public List<Animator> dronePods;

	public float droneSpawnFrequency = 30f;

	private float droneSpawnTime;

	public List<Transform> spawnLocations;

	public Denizen drones;

	private Tweener dotMove;

	public override void Start()
	{
		base.Start();
		moveTargetPosition = base.transform.position;
	}

	public override void Update()
	{
		base.Update();
		if (targetComponent.HasTarget())
		{
			foreach (Transform eye in eyes)
			{
				if (!DOTween.IsTweening(eye))
				{
					eye.DOLocalRotate(new Vector3(0f, 0f, Random.Range(-90, 90)), Random.Range(0.5f, 1.5f)).SetEase(eyeRotateEase);
				}
			}
			if (Mathf.Abs(targetComponent.target.targetTransform.position.y - base.transform.position.y) > repositionMaxHeightDifference || repositionTimer < 0f)
			{
				moveTargetPosition = new Vector3(base.transform.position.x, targetComponent.target.targetTransform.position.y + repositionHeightAdvantage + Random.value, base.transform.position.z);
				repositionTimer = Random.Range(repositionTimerMin, repositionTimerMax);
			}
			repositionTimer -= Time.deltaTime;
		}
		base.transform.position = Vector3.MoveTowards(base.transform.position, moveTargetPosition, Time.deltaTime * moveSpeed * Mathf.Clamp01(Vector3.Distance(base.transform.position, moveTargetPosition)));
	}

	public void DroneCheck()
	{
		if (!targetComponent.HasTarget())
		{
			return;
		}
		droneSpawnTime -= Time.deltaTime;
		droneSpawnTime = droneSpawnFrequency;
		foreach (Animator dronePod in dronePods)
		{
			dronePod.SetTrigger("Spawn");
		}
		foreach (Transform spawnLocation in spawnLocations)
		{
			Transform t = spawnLocation;
			StartCoroutine(SpawnDrone());
			IEnumerator SpawnDrone()
			{
				yield return new WaitForSeconds(1f);
				Denizen spawnedDrone = Object.Instantiate(drones, t.position, t.rotation);
				yield return null;
				spawnedDrone.AddForce(Vector3.up * 90f);
			}
		}
	}
}
