using System.Collections;
using System.Collections.Generic;
using Drawing;
using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class DEN_VentThing : AIGameEntity, AIGameEntity.Grappler
{
	public Transform hand;

	private Rigidbody handRigidbody;

	public GameObject handRenderer;

	public Animator handAnimator;

	private Animator bodyAnimator;

	public SpriteRenderer handSpriteRenderer;

	public Vector3 handOffset = new Vector3(0.5f, 0.5f, 0f);

	public Grappler.GrappleInfo grappleInfo;

	private Seeker seeker;

	private Path reachPath;

	private Path targetPath;

	private List<Vector3> chasePlayerPath;

	private bool isChasingPlayer;

	public float activationDistance = 50f;

	public float handSpeed = 1f;

	public float outOfRangeSpeedMult = 3f;

	public float finalStrikeSpeedMult = 2f;

	public float handRetreatSpeed = 7f;

	public float pullForce = 2f;

	private bool retreating;

	private bool repathing;

	public float handbobAmplitude = 0.5f;

	public float handbobFrequency = 1f;

	private Vector3 lastTargetPosition;

	private bool targetVisible;

	private GameEntity targetEntity;

	private float targetDistance;

	private float distanceFromBody;

	private bool aboutToGrabTarget;

	private float stuckTime;

	private float unstickTime;

	private Vector3 stuckPosition;

	private Vector3 lastHandPosition;

	public float waypointSwitchDistance = 0.5f;

	private int currentWaypoint;

	private int lastWaypoint;

	private int targetWaypointIndex;

	private int repathTargetIndex = -1;

	private bool reachedEndOfPath;

	private float pathCheckTime = 1f;

	private bool findingPath;

	private bool hasGrabbedTarget;

	private float grabTime;

	private float curHandStamina = 5f;

	public float handStamina = 5f;

	private float retreatTime;

	private Vector3 handShake = Vector3.zero;

	private float shakeTime = 0.1f;

	public float playerStaminaDrainMult = 1f;

	public float playerStaminaRecoveryMult = 0.3f;

	public GameObject armAsset;

	private List<Transform> arms;

	private List<MeshRenderer> armRenderers;

	private int lastArmID;

	private bool targetIsCloseToBody;

	private Vector3 navOffset;

	private static bool playerIsGrabbed;

	private static DEN_VentThing grabberVentThing;

	public UnityEvent onDeath;

	public override void OnDisable()
	{
		base.OnDisable();
		if (hasGrabbedTarget)
		{
			DropTarget();
		}
	}

	private void Awake()
	{
		if (grabberVentThing == null)
		{
			playerIsGrabbed = false;
		}
		seeker = base.gameObject.AddComponent<Seeker>();
		handRigidbody = hand.GetComponent<Rigidbody>();
		bodyAnimator = GetComponent<Animator>();
		SetTarget(ENT_Player.playerObject.transform);
		curHandStamina = handStamina;
		clipHandler.Initialize();
		clipHandler.GetGroup("hand").GetSet("fatigue").Play(0f);
		clipHandler.GetGroup("hand").GetSet("tension").Play(0f);
		arms = new List<Transform>();
		armRenderers = new List<MeshRenderer>();
		chasePlayerPath = new List<Vector3>();
		navOffset = Random.insideUnitSphere * 0.2f;
		if (base.transform.lossyScale.x < 0f || base.transform.lossyScale.y < 0f || base.transform.lossyScale.z < 0f)
		{
			base.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
	}

	public override void Update()
	{
		base.Update();
		handAnimator.SetBool("retreating", retreating);
		if (reachPath != null && reachPath.vectorPath != null && currentWaypoint >= reachPath.vectorPath.Count && currentWaypoint > 0)
		{
			currentWaypoint = reachPath.vectorPath.Count - 1;
		}
		if (!CL_UIManager.debug)
		{
			return;
		}
		CL_DebugView.draw.Label2D(hand.position, "Cur Waypoint: " + currentWaypoint + " Last: " + lastWaypoint + " Target Waypoint: " + targetWaypointIndex + " Can See Target: " + targetVisible);
		if (reachPath != null && reachPath.vectorPath.Count >= currentWaypoint - 1)
		{
			CL_DebugView.draw.Arrow(hand.position, reachPath.vectorPath[currentWaypoint]);
			for (int i = 0; i < reachPath.vectorPath.Count - 1; i++)
			{
				CL_DebugView.draw.Arrow(reachPath.vectorPath[i] + navOffset, reachPath.vectorPath[i + 1] + navOffset, Color.red);
				CL_DebugView.draw.Label2D(reachPath.vectorPath[i] + navOffset, "RP:" + i);
			}
			CL_DebugView.draw.Label2D(hand.position + Vector3.up, "Reachpath Count: " + reachPath.vectorPath.Count + " Repathing: " + repathing + " Retreating: " + retreating);
		}
		if (chasePlayerPath != null && chasePlayerPath.Count > 0)
		{
			for (int j = 0; j < chasePlayerPath.Count - 1; j++)
			{
				CL_DebugView.draw.Arrow(chasePlayerPath[j], chasePlayerPath[j + 1], Color.red);
				CL_DebugView.draw.Label2D(chasePlayerPath[j], "CP:" + j);
			}
		}
		if (targetPath != null && targetPath.vectorPath.Count >= currentWaypoint - 1)
		{
			for (int k = 0; k < targetPath.vectorPath.Count - 1; k++)
			{
				CL_DebugView.draw.Arrow(targetPath.vectorPath[k], targetPath.vectorPath[k + 1], Color.blue);
				CL_DebugView.draw.Label2D(targetPath.vectorPath[k] + Vector3.up, "TP:" + k, Color.blue);
			}
		}
	}

	private void LateUpdate()
	{
		CalculateArms();
		sight.Update();
		SetTargetPosition(target.position);
		targetDistance = Vector3.Distance(hand.position, target.position);
		distanceFromBody = Vector3.Distance(base.transform.position, target.position);
		if (Vector3.Distance(base.transform.position, hand.position) < 1f && retreating)
		{
			hand.position = base.transform.position;
		}
		if (distanceFromBody > activationDistance)
		{
			if (hasGrabbedTarget)
			{
				DropTarget();
			}
			retreatTime = 2f;
		}
		Vector3 vel = Vector3.zero;
		if (!hasGrabbedTarget)
		{
			curHandStamina = Mathf.Clamp(curHandStamina + Time.deltaTime, 0f, handStamina);
		}
		if (!hasGrabbedTarget)
		{
			if (Vector3.Distance(lastHandPosition, hand.position) < 0.2f * Time.deltaTime)
			{
				stuckTime += Time.deltaTime;
				if (stuckTime > 2f)
				{
					unstickTime = 1f;
				}
			}
			else
			{
				stuckTime = 0f;
			}
		}
		if ((unstickTime > 0f || retreating || repathing) && !hasGrabbedTarget)
		{
			unstickTime -= Time.deltaTime;
			handRigidbody.detectCollisions = false;
		}
		else
		{
			handRigidbody.detectCollisions = true;
		}
		lastHandPosition = hand.position;
		if (!targetIsCloseToBody && distanceFromBody < 15f)
		{
			targetIsCloseToBody = true;
			clipHandler.PlaySound("body:anger", base.transform.position);
		}
		else if (targetIsCloseToBody && distanceFromBody > 15f)
		{
			targetIsCloseToBody = false;
			clipHandler.PlaySound("body:targetescape", base.transform.position);
		}
		if (playerIsGrabbed && !hasGrabbedTarget)
		{
			retreatTime = 2.5f;
			retreating = true;
		}
		else if (targetDistance < 15f && distanceFromBody > 8f && !hasGrabbedTarget && !retreating && ENT_Player.playerObject.camRoot.CanSeeTarget(hand, 45f) && !retreating)
		{
			if (!targetVisible)
			{
				handRigidbody.linearVelocity = Vector3.zero;
				stuckTime = 0f;
				return;
			}
			retreatTime = 2.5f;
			retreating = true;
			if (targetWaypointIndex > 0)
			{
				targetWaypointIndex = 0;
			}
			if (targetDistance < 10f)
			{
				clipHandler.PlaySound("hand:fear", hand.position);
			}
			CL_CameraControl.ShakeAtPosition(hand.transform.position, 2.5f * Time.deltaTime, 20f);
		}
		handSpriteRenderer.color = Color.Lerp(Color.red, Color.white, curHandStamina / handStamina);
		UT_AudioClipHandler.AudioSet set = clipHandler.GetGroup("hand").GetSet("fatigue");
		set.SetVolume(Mathf.Lerp(set.GetCurrentVolume(), 1f - curHandStamina / handStamina, CL_GameManager.GetPlayerPerceivedDeltaTime() * 3f));
		if (playerIsGrabbed)
		{
			UT_AudioClipHandler.AudioSet set2 = clipHandler.GetGroup("hand").GetSet("tension");
			set2.SetVolume(Mathf.Lerp(set2.GetCurrentVolume(), set2.maxVolume, CL_GameManager.GetPlayerPerceivedDeltaTime() * 1f));
		}
		else
		{
			UT_AudioClipHandler.AudioSet set3 = clipHandler.GetGroup("hand").GetSet("tension");
			set3.SetVolume(Mathf.Lerp(set3.GetCurrentVolume(), 0f, CL_GameManager.GetPlayerPerceivedDeltaTime() * 1f));
		}
		if (repathing)
		{
			targetWaypointIndex = 0;
		}
		if (retreatTime > 0f)
		{
			if (!dead)
			{
				retreatTime -= Time.deltaTime;
			}
			retreating = true;
			targetWaypointIndex = 0;
			isChasingPlayer = false;
		}
		else if (retreating)
		{
			isChasingPlayer = false;
			retreating = false;
		}
		if ((!targetVisible && !hasGrabbedTarget) || retreating)
		{
			NavigationUpdate();
			vel = GetPathVector();
		}
		else if (!retreating)
		{
			isChasingPlayer = false;
			if (!hasGrabbedTarget && targetDistance < 5f && targetVisible && !aboutToGrabTarget)
			{
				aboutToGrabTarget = true;
				clipHandler.PlaySound("hand:reachfortarget", hand.position);
			}
			else if (targetDistance > 8f)
			{
				aboutToGrabTarget = false;
			}
			if (!hasGrabbedTarget && targetDistance < 1f && targetVisible && !CL_GameManager.noTarget)
			{
				hasGrabbedTarget = true;
				clipHandler.PlaySound("hand:grabplayer", hand.position);
				bodyAnimator.SetBool("chomping", value: true);
				playerIsGrabbed = true;
				grabberVentThing = this;
				if (targetEntity != null)
				{
					targetEntity.Damage(Damageable.DamageInfo.CreateDamageInfo(0f, objectType));
				}
			}
			if (hasGrabbedTarget)
			{
				targetWaypointIndex = 0;
				vel = GetPathVector();
				PullTarget(vel);
				return;
			}
			if (targetVisible)
			{
				isChasingPlayer = true;
			}
			else
			{
				isChasingPlayer = false;
			}
			vel = ChasePlayer();
		}
		HandLocomotion(vel);
	}

	private Vector3 ChasePlayer()
	{
		Vector3 normalized = (GetTargetPosition() - hand.position).normalized;
		if (chasePlayerPath.Count == 0)
		{
			chasePlayerPath.Add(hand.position);
		}
		if (Physics.Linecast(chasePlayerPath[chasePlayerPath.Count - 1], hand.position, out var hitInfo, sight.sightMask) && Vector3.Distance(hitInfo.point, chasePlayerPath[chasePlayerPath.Count - 1]) > 0.5f)
		{
			chasePlayerPath.Add(hitInfo.point + hitInfo.normal * 0.2f);
		}
		return normalized;
	}

	private void StopChasingPlayer()
	{
		chasePlayerPath = new List<Vector3>();
	}

	public new void SetTarget(Transform t)
	{
		target = t;
		targetEntity = t.GetComponent<GameEntity>();
	}

	public void NavigationUpdate()
	{
		if (pathCheckTime > 0f)
		{
			pathCheckTime -= Time.deltaTime;
			return;
		}
		float num = Vector3.Distance(lastTargetPosition, GetTargetPosition());
		pathCheckTime = 1f;
		if (num > 1f || targetPath == null)
		{
			_ = hand.position;
			lastTargetPosition = GetTargetPosition();
			targetPath = seeker.StartPath(base.transform.position, GetTargetPosition(), OnTargetPathComplete);
		}
		pathCheckTime = 1f;
	}

	public override void TickUpdate()
	{
		base.TickUpdate();
		if (sight.CanSeeTarget(sight.eyeObject.position, target, sight.sightDistance))
		{
			targetVisible = true;
		}
		else
		{
			targetVisible = false;
		}
	}

	public void OnTargetPathComplete(Path p)
	{
		if (!p.error)
		{
			targetPath = p;
			if (reachPath == null)
			{
				reachPath = targetPath;
			}
			if (targetPath != null && reachPath != null)
			{
				repathTargetIndex = GetLastCommonNodeIndexOnPath(reachPath, targetPath);
			}
		}
	}

	public int GetLastCommonNodeIndexOnPath(Path a, Path b)
	{
		for (int i = 0; i < a.path.Count; i++)
		{
			if (i >= b.path.Count)
			{
				return Mathf.Max(b.path.Count - 1, 0);
			}
			if (a.path[i].position == b.path[i].position)
			{
				if (i == a.path.Count - 1)
				{
					return i;
				}
				continue;
			}
			return Mathf.Max(i - 1, 0);
		}
		return 0;
	}

	public void HandLocomotion(Vector3 vel)
	{
		Vector3 forward = vel;
		if (reachPath != null && reachPath.vectorPath != null && reachPath.vectorPath.Count > currentWaypoint)
		{
			if (currentWaypoint >= 1)
			{
				forward = reachPath.vectorPath[currentWaypoint] - reachPath.vectorPath[currentWaypoint - 1];
			}
			else if (currentWaypoint == 0)
			{
				forward = hand.position - base.transform.position;
			}
		}
		if (!isChasingPlayer)
		{
			if (arms != null && arms.Count > 0)
			{
				lastArmID = Mathf.Min(lastArmID, arms.Count - 1);
				if ((hand.position - arms[lastArmID].position).sqrMagnitude != 0f)
				{
					hand.rotation = Quaternion.Lerp(hand.rotation, Quaternion.LookRotation(hand.position - arms[lastArmID].position, Vector3.up), Time.deltaTime * 3f);
				}
			}
			else
			{
				hand.rotation = Quaternion.Lerp(hand.rotation, Quaternion.LookRotation(forward, Vector3.up), Time.deltaTime * 3f);
			}
		}
		else
		{
			hand.rotation = Quaternion.Lerp(hand.rotation, Quaternion.LookRotation(target.position - hand.position, Vector3.up), Time.deltaTime * 3f);
		}
		Vector3 vector = (hand.up * Mathf.Sin(Time.time * handbobFrequency) + hand.right * Mathf.Cos(Time.time * handbobFrequency)) * handbobAmplitude;
		float num = (repathing ? handRetreatSpeed : handSpeed);
		if (CL_GameManager.IsHardmode())
		{
			num *= 1.5f;
		}
		if (!retreating && targetDistance > 20f)
		{
			num *= outOfRangeSpeedMult;
		}
		else if (!retreating && targetVisible && !ENT_Player.playerObject.camRoot.CanSeeTarget(hand) && targetDistance < 5f)
		{
			num *= finalStrikeSpeedMult;
		}
		handRigidbody.linearVelocity = vel * num + vector;
	}

	public Vector3 GetPathVector()
	{
		if (reachPath == null || currentWaypoint >= reachPath.vectorPath.Count)
		{
			return (base.transform.position - hand.position).normalized;
		}
		Vector3 normalized = (reachPath.vectorPath[currentWaypoint] + navOffset - hand.position).normalized;
		List<Vector3> list = new List<Vector3>();
		list.AddRange(reachPath.vectorPath);
		bool flag = false;
		if (chasePlayerPath.Count > 0)
		{
			list.AddRange(chasePlayerPath);
			flag = true;
		}
		if (flag)
		{
			float num = Vector3.Distance(hand.position, chasePlayerPath[chasePlayerPath.Count - 1]);
			normalized = chasePlayerPath[chasePlayerPath.Count - 1] - hand.position;
			if (num < waypointSwitchDistance * 1.5f)
			{
				chasePlayerPath.RemoveAt(chasePlayerPath.Count - 1);
			}
			return normalized;
		}
		reachedEndOfPath = false;
		if (repathTargetIndex >= 0)
		{
			targetWaypointIndex = repathTargetIndex;
		}
		bool flag2 = false;
		if ((targetWaypointIndex < currentWaypoint || retreating) && lastWaypoint <= currentWaypoint)
		{
			flag2 = true;
			normalized = (reachPath.vectorPath[currentWaypoint] + navOffset - hand.position).normalized;
		}
		float num2 = Vector3.Distance(hand.position, list[currentWaypoint]);
		float num3 = waypointSwitchDistance;
		if (hasGrabbedTarget)
		{
			num3 *= 1.5f;
		}
		if (num2 < num3 * 1f)
		{
			flag2 = true;
		}
		if (flag2)
		{
			if (currentWaypoint < targetWaypointIndex && !retreating)
			{
				if (currentWaypoint + 1 < reachPath.vectorPath.Count)
				{
					lastWaypoint = currentWaypoint;
					currentWaypoint++;
				}
				else
				{
					reachedEndOfPath = true;
				}
				if (!hasGrabbedTarget)
				{
					repathing = false;
				}
			}
			else if (currentWaypoint > targetWaypointIndex || retreating)
			{
				if (currentWaypoint > 0)
				{
					lastWaypoint = currentWaypoint;
					currentWaypoint--;
				}
				if (!hasGrabbedTarget)
				{
					repathing = true;
				}
				normalized = (reachPath.vectorPath[currentWaypoint] + navOffset - hand.position).normalized;
			}
			else if (currentWaypoint == targetWaypointIndex)
			{
				reachPath = targetPath;
				targetWaypointIndex = targetPath.path.Count - 1;
				repathTargetIndex = -1;
				lastWaypoint = currentWaypoint;
				if (!hasGrabbedTarget)
				{
					repathing = false;
				}
			}
		}
		return normalized;
	}

	public void PullTarget(Vector3 dir)
	{
		if (!hasGrabbedTarget)
		{
			return;
		}
		targetWaypointIndex = 0;
		Vector3 zero = Vector3.zero;
		zero = ((reachPath == null) ? (base.transform.position - hand.position) : dir);
		if (targetEntity != null)
		{
			hand.position = GetTargetPosition() + zero.normalized * 1f;
			targetEntity.AddForce(zero.normalized * Time.deltaTime * pullForce);
			if (targetEntity == ENT_Player.playerObject)
			{
				ENT_Player.playerObject.SetGrappled(b: true, this);
				ENT_Player.playerObject.SetGravity(b: false);
				ENT_Player.playerObject.SetGravityMult(0f);
				handSpriteRenderer.gameObject.SetActive(value: true);
				handRenderer.gameObject.SetActive(value: false);
				Transform transform = ENT_Player.playerObject.cam.transform;
				grabTime = Mathf.Lerp(grabTime, 1f, Time.deltaTime * 5f);
				shakeTime -= Time.deltaTime;
				if (shakeTime <= 0f)
				{
					shakeTime = 0.1f;
					handShake = Random.insideUnitSphere * (1f - curHandStamina / handStamina) * 0.02f;
				}
				Vector3 vector = transform.TransformPoint(handOffset);
				handSpriteRenderer.transform.position = Vector3.Lerp(vector + -transform.up, vector, grabTime) + handShake;
				handSpriteRenderer.transform.rotation = transform.rotation;
				Quaternion rotation = ENT_Player.playerObject.transform.rotation;
				if (distanceFromBody > 10f)
				{
					if (Vector3.Angle(-Vector3.Scale(zero, new Vector3(1f, 0f, 1f)), ENT_Player.playerObject.transform.forward) > 60f)
					{
						ENT_Player.playerObject.transform.rotation = Quaternion.Lerp(rotation, Quaternion.LookRotation(Vector3.Scale(-zero, new Vector3(1f, 0f, 1f)), Vector3.up), Time.deltaTime * 2f);
					}
				}
				else if (Vector3.Angle(Vector3.Scale(zero, new Vector3(1f, 0f, 1f)), ENT_Player.playerObject.transform.forward) > 10f)
				{
					ENT_Player.playerObject.transform.rotation = Quaternion.Lerp(rotation, Quaternion.LookRotation(Vector3.Scale(zero, new Vector3(1f, 0f, 1f)), Vector3.up), Time.deltaTime * 2f);
				}
				if (distanceFromBody < 2f)
				{
					DropTarget();
					targetEntity.Kill(objectType);
				}
				if (ENT_Player.playerObject.IsHanging())
				{
					float num = 1f;
					if (CL_GameManager.IsHardmode())
					{
						num = 1.5f;
					}
					ENT_Player.playerObject.DamageGripStrength(playerStaminaDrainMult * Time.deltaTime * num, onlyToGrabbingHands: true);
					CL_CameraControl.Shake(0.05f * Time.deltaTime);
					curHandStamina = Mathf.Clamp(curHandStamina - Time.deltaTime, 0f, handStamina);
					if (curHandStamina <= 0f)
					{
						DropTarget();
						return;
					}
					stuckPosition = hand.position;
				}
				else if (!ENT_Player.playerObject.IsHanging())
				{
					if (Vector3.Distance(stuckPosition, hand.position) < 1f)
					{
						stuckTime += Time.deltaTime;
						if (stuckTime > 5f)
						{
							DropTarget();
							stuckTime = 0f;
							return;
						}
					}
					else
					{
						stuckPosition = hand.position;
						stuckTime = 0f;
					}
					ENT_Player.playerObject.AddGripStrength(playerStaminaRecoveryMult * Time.deltaTime);
				}
				CL_UIManager.instance.SetVignetteTarget("bloodied", 0.8f);
				CL_UIManager.instance.SetVignetteTarget("fade", 0.5f);
				CL_UIManager.instance.SetVignetteTarget("hurt", 0.5f);
			}
			else
			{
				Debug.Log("Grabbed Something Other Than Player");
			}
		}
		else
		{
			target.position = hand.position + -zero.normalized * 1f;
		}
	}

	public void DropTarget(bool damage = true)
	{
		clipHandler.PlaySound("hand:dropplayer", hand.position);
		grabTime = 0f;
		retreatTime = 5f;
		handRenderer.gameObject.SetActive(value: true);
		bodyAnimator.SetBool("chomping", value: false);
		if (targetEntity != null)
		{
			if (targetEntity == ENT_Player.playerObject)
			{
				playerIsGrabbed = false;
				grabberVentThing = null;
				ENT_Player.playerObject.SetGravity(b: true);
				ENT_Player.playerObject.SetGrappled(b: false, this);
				ENT_Player.playerObject.SetGravityMult(1f);
				CL_UIManager.instance.SetVignetteTarget("bloodied", 0f);
				CL_UIManager.instance.SetVignetteTarget("fade", 0f);
				CL_UIManager.instance.SetVignetteTarget("hurt", 0f);
				if (base.gameObject != null)
				{
					StartCoroutine(DropHandSprite());
				}
			}
			if (damage && hasGrabbedTarget)
			{
				targetEntity.Damage(Damageable.DamageInfo.CreateDamageInfo(1f, objectType));
			}
		}
		hasGrabbedTarget = false;
	}

	private IEnumerator DropHandSprite()
	{
		Transform playerCamera = ENT_Player.playerObject.cam.transform;
		float dropTime = 1f;
		while (dropTime > 0f)
		{
			dropTime -= Time.deltaTime;
			Vector3 vector = playerCamera.TransformPoint(handOffset);
			handSpriteRenderer.transform.position = Vector3.Lerp(vector + -playerCamera.up, vector, dropTime);
			handSpriteRenderer.transform.rotation = playerCamera.rotation;
			yield return null;
		}
		handSpriteRenderer.gameObject.SetActive(value: false);
	}

	private void CalculateArms()
	{
		List<Vector3> list = new List<Vector3>();
		if (currentWaypoint > 0)
		{
			for (int i = 0; i <= currentWaypoint; i++)
			{
				list.Add(reachPath.vectorPath[i] + navOffset);
			}
		}
		if (lastWaypoint <= currentWaypoint && list.Count > currentWaypoint)
		{
			list.RemoveAt(currentWaypoint);
		}
		if (chasePlayerPath.Count > 0)
		{
			list.AddRange(chasePlayerPath);
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.SphereOutline(list[j], 1f, Color.magenta);
			}
		}
		int num = list.Count - 1;
		for (int k = 0; k < Mathf.Max(list.Count, Mathf.Max(arms.Count, 1)); k++)
		{
			if ((k >= arms.Count && arms.Count < 50) || arms.Count == 0)
			{
				arms.Add(Object.Instantiate(armAsset, base.transform).transform);
				armRenderers.Add(arms[arms.Count - 1].GetComponent<MeshRenderer>());
			}
			if (k == num)
			{
				lastArmID = k;
			}
			if (k > num && k > 0)
			{
				if (arms[k].gameObject.activeSelf)
				{
					arms[k].gameObject.SetActive(value: false);
				}
				continue;
			}
			if (!arms[k].gameObject.activeSelf)
			{
				arms[k].gameObject.SetActive(value: true);
			}
			bool flag = list != null && list.Count > num;
			Vector3 vector = ((!(k > 0 && flag)) ? base.transform.position : list[k]);
			Vector3 vector2 = ((!(num > k && flag)) ? hand.position : list[k + 1]);
			arms[k].position = vector;
			if (vector2 - vector != Vector3.zero)
			{
				arms[k].rotation = Quaternion.LookRotation(vector2 - vector, Vector3.up);
			}
			arms[k].localScale = new Vector3(1f, 1f, Vector3.Distance(vector2, vector));
			float num2 = Mathf.Clamp(arms[k].localScale.z, 0f, 1f);
			armRenderers[k].material.SetFloat("_Slack", num2 * 0.1f);
			armRenderers[k].material.SetFloat("_Wiggle", num2 * 0.1f);
		}
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (dead || !damageable)
		{
			return false;
		}
		DropTarget();
		clipHandler.PlaySound("body:anger", base.transform.position);
		retreatTime = 5f;
		retreating = true;
		if (info.type.Contains("explosion"))
		{
			dead = true;
			onDeath.Invoke();
			bodyAnimator.SetTrigger("die");
		}
		return false;
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.WireSphere(base.transform.position, activationDistance, Color.yellow);
		}
	}

	public void ReleaseGrapple()
	{
		Debug.Log("Releasing!");
		DropTarget(damage: false);
		retreatTime = 5f;
		retreating = true;
		handSpriteRenderer.gameObject.SetActive(value: false);
	}

	public override void OffsetEntity(float amount)
	{
		base.OffsetEntity(amount);
		for (int i = 0; i < chasePlayerPath.Count; i++)
		{
			chasePlayerPath[i] += Vector3.up * amount;
		}
		if (base.gameObject.activeInHierarchy)
		{
			StartCoroutine(WaitOneFrame());
		}
		else
		{
			currentWaypoint = 0;
			hand.position = base.transform.position;
		}
		lastHandPosition += Vector3.up * amount;
		IEnumerator WaitOneFrame()
		{
			currentWaypoint = 0;
			yield return null;
			targetPath = seeker.StartPath(base.transform.position, hand.position, OnTargetPathComplete);
			reachPath = targetPath;
			currentWaypoint = 0;
			hand.position = base.transform.position;
		}
	}

	public Grappler.GrappleInfo GetGrappleInfo()
	{
		return grappleInfo;
	}
}
