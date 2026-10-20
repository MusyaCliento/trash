using System;
using System.Collections.Generic;
using UnityEngine;

public class DEN_Buddy : MonoBehaviour
{
	[Serializable]
	public class BuddyEvent
	{
		public string id;

		public float chance = 1f;

		[SerializeReference]
		public BuddyModule module;
	}

	private UT_AudioClipHandler clipHandler;

	private DEN_Drone drone;

	public float barkFrequency;

	private float barkTime;

	public float eventFrequency = 60f;

	private float eventTimer;

	private bool canSeeTarget;

	private float lastSightedTimer;

	private bool hasFoundPlayer;

	public List<BuddyEvent> buddyEvents;

	private BuddyEvent currentEvent;

	private bool hasDied;

	private bool hangingOut;

	private Vector3 hangoutPos;

	private Vector3 hangoutWanderTarget;

	private void Start()
	{
		clipHandler = GetComponent<UT_AudioClipHandler>();
		drone = GetComponent<DEN_Drone>();
		barkTime = barkFrequency * 0.5f + UnityEngine.Random.Range(0f, barkFrequency);
		eventTimer = eventFrequency * 0.5f + UnityEngine.Random.Range(0f, eventFrequency);
	}

	private void Update()
	{
		if (drone.dead && !hasDied)
		{
			hasDied = true;
			CL_GameManager.SetGameFlag("buddy-i1", state: false);
			if (currentEvent != null)
			{
				currentEvent = null;
				StopAllCoroutines();
			}
		}
		else
		{
			if (drone.dead)
			{
				return;
			}
			if (currentEvent == null)
			{
				if (canSeeTarget || hangingOut)
				{
					barkTime -= Time.deltaTime;
					if (barkTime <= 0f && hasFoundPlayer)
					{
						barkTime = barkFrequency * 0.5f + UnityEngine.Random.Range(0f, barkFrequency);
						clipHandler.PlaySound("buddy:bark");
					}
				}
				if (drone.GetTarget().isVisible)
				{
					if (!canSeeTarget)
					{
						canSeeTarget = true;
						SightTarget();
					}
					lastSightedTimer = 0f;
				}
				else
				{
					if (canSeeTarget)
					{
						LoseTarget();
					}
					lastSightedTimer += Time.deltaTime;
				}
			}
			RunEvents();
			Hangout();
		}
	}

	private void Hangout()
	{
		if (hangingOut)
		{
			float num = Vector3.Distance(base.transform.position, hangoutPos);
			if (num > 20f)
			{
				hangingOut = false;
				drone.lookForTarget = true;
			}
			else if (num > 10f)
			{
				drone.targetPosition = hangoutPos + UnityEngine.Random.insideUnitSphere;
			}
		}
	}

	private void SightTarget()
	{
		if (!hasFoundPlayer)
		{
			hasFoundPlayer = true;
			clipHandler.PlaySound("buddy:foundplayer");
		}
		else if (drone.GetTarget().lastSightedTimer > 5f)
		{
			clipHandler.PlaySound("buddy:relocateplayer");
		}
	}

	private void LoseTarget()
	{
		if (lastSightedTimer > 5f)
		{
			canSeeTarget = false;
			clipHandler.PlaySound("buddy:lostplayer");
		}
	}

	private void RunEvents()
	{
		if (currentEvent != null || !canSeeTarget)
		{
			return;
		}
		eventTimer -= Time.deltaTime;
		if (eventTimer <= 0f)
		{
			BuddyEvent buddyEvent = buddyEvents[UnityEngine.Random.Range(0, buddyEvents.Count)];
			if (UnityEngine.Random.value < buddyEvent.chance)
			{
				PlayEvent(buddyEvent);
			}
			else
			{
				eventTimer = 1f;
			}
		}
	}

	public void StopEvents()
	{
		StopAllCoroutines();
		currentEvent = null;
	}

	public void PlayEvent(BuddyEvent bE)
	{
		currentEvent = bE;
		currentEvent.module.Initialize(this);
		eventTimer = eventFrequency * 0.5f + UnityEngine.Random.Range(0f, eventFrequency);
	}

	public void ClearEvent()
	{
		currentEvent = null;
	}

	public void PlaySound(AudioClip c)
	{
		clipHandler.GetGroup("buddy").GetSet("event").PlaySound(1f, c);
	}

	public void SetTarget(Transform t)
	{
		if (drone == null)
		{
			drone = GetComponent<DEN_Drone>();
		}
		drone.target = t;
		drone.targetPosition = t.position;
	}

	public void SetLookForTarget(bool b)
	{
		if (drone == null)
		{
			drone = GetComponent<DEN_Drone>();
		}
		drone.lookForTarget = b;
	}

	public void SetHangoutSpot(Vector3 pos)
	{
		hangingOut = true;
		hangoutPos = pos;
		SetHangoutState(b: true);
	}

	public void SetHangoutState(bool b)
	{
		hangingOut = b;
		if (hangingOut)
		{
			drone.targetPosition = hangoutPos;
			drone.lookForTarget = false;
		}
	}

	public bool IsHanging()
	{
		return hangingOut;
	}
}
