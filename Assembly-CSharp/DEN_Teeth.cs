using System;
using System.Collections;
using System.Collections.Generic;
using DarkMachine.AI;
using Drawing;
using Pathfinding;
using UnityEngine;

public class DEN_Teeth : AIGameEntity
{
	public enum AIMoveStates
	{
		normal = 0,
		leaping = 1,
		climbing = 2,
		crawling = 3,
		falling = 4
	}

	public static DEN_Teeth instance;

	public Transform geoRoot;

	public Animator anim;

	public IK_Controller ik;

	public Transform modelCenter;

	public ParticleSystem handParticle;

	public Transform handParticleLocator;

	public ParticleSystem screenHandEffect;

	private Transform screenHandEffectParent;

	public SkinnedMeshRenderer meshRenderer;

	private Material bodyMaterial;

	public float cohesionEffectMultiplier = 1f;

	public float cohesionColorMultiplier = 5f;

	public FX_Zone fxZone;

	public Transform cameraTakeover;

	public float baseSpeed = 3f;

	public float chargeSpeed = 5f;

	public float walkSpeed = 1f;

	public float stopDistance = 3f;

	public float jumpSpeed = 5f;

	public float jumpArcHeight = 3f;

	private float curSpeed = 1f;

	internal float speedMult;

	internal bool charging;

	internal bool locked;

	private Vector3 facingDir;

	private bool climbing = true;

	public LayerMask levelMask;

	public float attackDamage = 1f;

	public float aggression = 1f;

	public float aggressionMult = 1f;

	public float aggressionRate = 0.01f;

	public float aggressionOutOfRangeModifier = 3f;

	public float barkTime = 10f;

	internal float curBarkTime;

	private float pathCheckTime = 1f;

	private bool findingPath;

	private Seeker seeker;

	private Path path;

	private float nextWaypointDistance = 3f;

	private int currentWaypoint;

	private bool reachedEndOfPath;

	private float distanceToPlayer;

	public new bool disableAI;

	private Vector3 velocity;

	private Vector3 realVelocity;

	private Vector3 lastObjectPosition;

	private Vector3 seperationVelocity;

	private Vector3 surfaceDir;

	private Vector3 closestSurface;

	private bool snapGeo = true;

	private bool leaping;

	public float stunDamage = 3f;

	private float curStunDamage;

	private bool lockAI;

	private float cohesionEffect = 0.01f;

	private float burnEffect;

	private new void OnEnable()
	{
		base.transform.parent.parent = null;
		if (instance != null)
		{
			Despawn();
		}
		else
		{
			instance = this;
		}
		CommandConsole.AddCommand("teeth-toggleailock", SetTeethAILock);
	}

	private new void OnDisable()
	{
		if (instance == this)
		{
			instance = null;
		}
		CommandConsole.RemoveCommand("teeth-toggleailock");
	}

	private void Awake()
	{
		clipHandler.Initialize();
		clipHandler.PlaySound("teeth:spawn");
		CL_CameraControl.Shake(0.15f);
		anim.keepAnimatorStateOnDisable = true;
		seeker = GetComponent<Seeker>();
		lastObjectPosition = geoRoot.transform.position;
		screenHandEffectParent = screenHandEffect.transform.parent;
		if (target == null)
		{
			target = ENT_Player.GetPlayer().transform;
		}
		aiStates = new List<AIStateComponent>
		{
			new AIC_Teeth_Wander(),
			new AIC_Teeth_Chase(),
			new AIC_Teeth_Burrow(),
			new AIC_Teeth_Wait(),
			new AIC_Teeth_Retreat()
		};
		foreach (AIStateComponent aiState in aiStates)
		{
			aiState.Initialize(this, stateVariables);
		}
		currentState = aiStates[0];
		currentState.Enter(this);
		baseSpeed *= Mathf.Clamp(CL_GameManager.gMan.GetPlayerTravelSpeed(), 0.85f, 2f);
		bodyMaterial = meshRenderer.material;
		if (CL_GameManager.IsHardmode())
		{
			baseSpeed += 1f;
			aggression *= 2f;
		}
	}

	public override void Update()
	{
		if (lockAI)
		{
			return;
		}
		realVelocity = (geoRoot.transform.position - lastObjectPosition) / Time.deltaTime;
		lastObjectPosition = geoRoot.transform.position;
		base.Update();
		if (CL_GameManager.gMan.isPaused)
		{
			return;
		}
		cohesionEffect = Mathf.Max(cohesionEffect - Time.deltaTime, 0f);
		bodyMaterial.SetFloat("_Wiggle", cohesionEffect * cohesionEffectMultiplier);
		burnEffect = Mathf.Max(burnEffect - Time.deltaTime * 0.5f, 0f);
		Color value = Color.Lerp(Color.black, Color.red, burnEffect);
		bodyMaterial.SetColor("_ShimmerColor", value);
		bodyMaterial.SetColor("_EmissionColor", value);
		if (!disableAI)
		{
			distanceToPlayer = CL_GameManager.gMan.PlayerDistance(base.transform.position);
			sight.Update();
			currentState.Execute(this);
			Navigation();
			ClimbTowardsTarget();
			if (!locked)
			{
				float num = aggressionRate;
				if (CL_GameManager.IsHardmode())
				{
					num *= 2f;
				}
				else
				{
					aggression = Mathf.Clamp(aggression, 0f, 1.35f);
				}
				if (distanceToPlayer > 15f)
				{
					aggression += num * Time.deltaTime * aggressionOutOfRangeModifier;
				}
				else
				{
					aggression += num * Time.deltaTime;
				}
			}
		}
		Animation();
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.SphereOutline(base.transform.position, 0.3f, new Color(1f, 0f, 0f, 0.6f));
			CL_DebugView.draw.Label2D(base.transform.position + Vector3.up, "State: " + currentState.name + " Vel: " + realVelocity, 8f, LabelAlignment.Center, Color.white);
			CL_DebugView.draw.Label2D(base.transform.position + Vector3.up * 1.5f, "Aggression: " + aggression * aggressionMult, 8f, LabelAlignment.Center, Color.red);
		}
	}

	private void LateUpdate()
	{
		screenHandEffectParent.transform.position = Camera.main.transform.position;
		screenHandEffectParent.transform.rotation = Camera.main.transform.rotation;
	}

	private void Navigation()
	{
		if (!leaping)
		{
			if (pathCheckTime > 0f)
			{
				pathCheckTime -= Time.deltaTime;
			}
			else if (!findingPath)
			{
				findingPath = true;
				path = seeker.StartPath(base.transform.position, targetPosition, OnPathComplete);
				currentWaypoint = 0;
			}
			else
			{
				pathCheckTime = 1f;
				findingPath = false;
			}
		}
	}

	public void OnPathComplete(Path p)
	{
		findingPath = false;
		pathCheckTime = 1f;
		if (!p.error)
		{
			path = p;
			currentWaypoint = 0;
		}
	}

	private void Animation()
	{
		if (geoRoot.gameObject.activeSelf)
		{
			fxZone.blend = Mathf.Lerp(fxZone.blend, 1f, Time.deltaTime);
		}
		else
		{
			fxZone.blend = Mathf.Lerp(fxZone.blend, 0f, Time.deltaTime);
		}
		if (realVelocity.magnitude <= 0.3f)
		{
			anim.SetBool("idle", value: true);
		}
		else
		{
			anim.SetBool("idle", value: false);
		}
		anim.SetFloat("speedmult", speedMult * aggression * aggressionMult);
		handParticle.transform.position = handParticleLocator.position;
		handParticle.transform.rotation = Quaternion.Lerp(handParticle.transform.rotation, handParticleLocator.rotation, Time.deltaTime);
		ParticleSystem.EmissionModule emission = handParticle.emission;
		emission.rateOverTimeMultiplier = Mathf.Lerp(25f, 0f, distanceToPlayer / 10f);
		if (locked)
		{
			return;
		}
		ParticleSystem.ShapeModule shape = screenHandEffect.shape;
		if (distanceToPlayer < 10f)
		{
			if (!screenHandEffect.isPlaying)
			{
				screenHandEffect.Play();
			}
		}
		else if (screenHandEffect.isPlaying)
		{
			screenHandEffect.Stop();
		}
		shape.radius = Mathf.Lerp(2f, 3f, distanceToPlayer / 10f);
		ParticleSystem.EmissionModule emission2 = screenHandEffect.emission;
		emission2.rateOverTimeMultiplier = Mathf.Lerp(9f, 0f, distanceToPlayer / 10f);
		if (!snapGeo)
		{
			return;
		}
		Vector3 vector = velocity;
		facingDir = Vector3.Lerp(facingDir, GetFacingNormal().normalized, Time.deltaTime * 4f);
		if (Vector3.Dot(facingDir, Vector3.up) > 0.4f)
		{
			if (climbing)
			{
				climbing = false;
			}
		}
		else if (!climbing)
		{
			climbing = true;
		}
		if (climbing)
		{
			Quaternion b = Quaternion.LookRotation(-facingDir, vector.normalized);
			Vector3 vector2 = facingDir;
			geoRoot.transform.rotation = Quaternion.Lerp(geoRoot.transform.rotation, b, Time.deltaTime * 8f);
			geoRoot.transform.position = Vector3.Lerp(geoRoot.transform.position, closestSurface + vector2, Time.deltaTime * 2f);
			anim.SetBool("climbing", value: true);
			return;
		}
		Quaternion b2 = ((!(vector.normalized != Vector3.zero)) ? Quaternion.LookRotation(Vector3.forward, Vector3.up) : Quaternion.LookRotation(vector.normalized, Vector3.up));
		Vector3 point = closestSurface;
		if (Physics.Raycast(modelCenter.position, Vector3.down, out var hitInfo, 3f, levelMask))
		{
			point = hitInfo.point;
		}
		geoRoot.transform.rotation = Quaternion.Lerp(geoRoot.transform.rotation, b2, Time.deltaTime * 4f);
		geoRoot.transform.position = Vector3.Lerp(geoRoot.transform.position, point + Vector3.up * 1.4f, Time.deltaTime * 4f);
		anim.SetBool("climbing", value: false);
		ik.DeactivateAllIK();
	}

	private Vector3 GetFacingNormal()
	{
		int num = 16;
		Vector3[] array = GenerateEquidistantVectors(num);
		Vector3 zero = Vector3.zero;
		zero = velocity.normalized * 0.5f;
		float num2 = 3f;
		closestSurface = modelCenter.position;
		float num3 = float.PositiveInfinity;
		seperationVelocity = Vector3.zero;
		for (int i = 0; i < num; i++)
		{
			Vector3 vector = array[i] - Vector3.ClampMagnitude(velocity * 0.25f, 0.9f);
			if (Physics.Raycast(modelCenter.position, vector, out var hitInfo, num2, levelMask))
			{
				zero += hitInfo.normal;
				if (hitInfo.distance < num3)
				{
					num3 = hitInfo.distance;
					closestSurface = hitInfo.point;
				}
				seperationVelocity += hitInfo.normal * ((num2 - hitInfo.distance) / num2) / num * 0.15f;
				if (CL_UIManager.debug)
				{
					CL_DebugView.draw.Line(modelCenter.position, hitInfo.point, new Color(1f, 0f, 0f, 0.1f));
					CL_DebugView.draw.Cross(hitInfo.point, 0.3f, new Color(1f, 0f, 0f, 0.1f));
				}
			}
			else if (CL_UIManager.debug)
			{
				CL_DebugView.draw.DashedLine(modelCenter.position, modelCenter.position + vector * 3f, 0.1f, 0.1f, new Color(0f, 1f, 0f, 0.02f));
			}
		}
		surfaceDir = Vector3.Lerp(surfaceDir, zero, Time.deltaTime * 10f);
		return surfaceDir;
	}

	private void ClimbTowardsTarget()
	{
		if (locked || leaping || path == null || currentWaypoint >= path.path.Count || currentWaypoint >= path.vectorPath.Count)
		{
			return;
		}
		Vector3 vector = targetPosition - base.transform.position;
		reachedEndOfPath = false;
		vector = (path.vectorPath[currentWaypoint] - base.transform.position).normalized;
		NodeLink2 nodeLink = NodeLink2.GetNodeLink(path.path[currentWaypoint]);
		if ((UnityEngine.Object)(object)nodeLink != null)
		{
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Label2D(base.transform.position, "Link Node: " + ((Component)(object)nodeLink).gameObject.name, 8f, LabelAlignment.Center, Color.white);
			}
			AI_ControlNode component = ((Component)(object)nodeLink).GetComponent<AI_ControlNode>();
			if (component != null)
			{
				if (component.aiNodeType == AI_ControlNode.NodeType.farLeap || component.aiNodeType == AI_ControlNode.NodeType.shortLeap)
				{
					StartLeap(component);
				}
				Debug.Log("Found a link node: " + ((Component)(object)nodeLink).gameObject.name);
				return;
			}
		}
		if (!climbing)
		{
			curSpeed = Mathf.Lerp(curSpeed, walkSpeed, Time.deltaTime * 5f);
		}
		else if (charging)
		{
			curSpeed = Mathf.Lerp(curSpeed, chargeSpeed, Time.deltaTime * 5f);
		}
		else
		{
			curSpeed = Mathf.Lerp(curSpeed, baseSpeed, Time.deltaTime * 5f);
		}
		float num = aggression * aggressionMult;
		if (!climbing)
		{
			num = 1f;
		}
		velocity = Vector3.Lerp(velocity, vector * curSpeed * speedMult * num, Time.deltaTime * 5f) + seperationVelocity;
		base.transform.position += velocity * Time.deltaTime;
		while (Vector3.Distance(base.transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance * 1f)
		{
			if (currentWaypoint + 1 < path.vectorPath.Count)
			{
				currentWaypoint++;
				continue;
			}
			reachedEndOfPath = true;
			break;
		}
	}

	public void StartLeap(AI_ControlNode controlNode)
	{
		if (!leaping)
		{
			NodeLink2 linkNode = controlNode.GetLinkNode();
			float num = Vector3.Distance(base.transform.position, linkNode.StartTransform.position);
			float num2 = Vector3.Distance(base.transform.position, linkNode.EndTransform.position);
			Transform leapEnd = ((num < num2) ? linkNode.EndTransform : linkNode.StartTransform);
			Transform leapStart = ((num > num2) ? linkNode.EndTransform : linkNode.StartTransform);
			StartCoroutine(Leap(leapEnd, leapStart, controlNode));
		}
	}

	public IEnumerator Leap(Transform leapEnd, Transform leapStart, AI_ControlNode controlNode)
	{
		curBarkTime = barkTime;
		leaping = true;
		seeker.traversableTags ^= 2;
		snapGeo = false;
		float leapAnimTimer = 2.13f;
		float jumpSpeedMult = 1f;
		if (controlNode.aiNodeType == AI_ControlNode.NodeType.shortLeap)
		{
			leapAnimTimer = 1f;
			jumpSpeedMult = 1.2f;
			anim.SetBool("shortleap", value: true);
		}
		else
		{
			anim.SetBool("shortleap", value: false);
		}
		anim.SetBool("leaping", value: true);
		anim.SetTrigger("leap");
		bool num = Vector3.Dot(leapEnd.position - base.transform.position, Vector3.up) > 0f;
		clipHandler.PlaySound("teeth:grunt");
		Quaternion startRotation;
		Quaternion endRotation;
		if (num)
		{
			startRotation = Quaternion.LookRotation(-leapStart.forward, leapStart.up);
			endRotation = Quaternion.LookRotation(-leapEnd.forward, leapEnd.up);
		}
		else
		{
			startRotation = Quaternion.LookRotation(-leapStart.forward, -leapStart.up);
			endRotation = Quaternion.LookRotation(-leapEnd.forward, -leapEnd.up);
		}
		float animTime = 0f;
		while (animTime < leapAnimTimer)
		{
			animTime += Time.deltaTime;
			geoRoot.transform.position = Vector3.Lerp(geoRoot.transform.position, leapStart.position, Time.deltaTime * 2f);
			geoRoot.transform.rotation = Quaternion.Lerp(geoRoot.transform.rotation, startRotation, Time.deltaTime * 2f);
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Arrow(geoRoot.transform.position, geoRoot.transform.position + geoRoot.transform.up, Color.magenta);
				CL_DebugView.draw.Arrow(geoRoot.transform.position, geoRoot.transform.position + geoRoot.transform.forward, Color.blue);
			}
			yield return null;
		}
		clipHandler.PlaySound("teeth:leap");
		anim.SetBool("leaping", value: false);
		ik.DeactivateAllIK();
		geoRoot.transform.position = base.transform.position;
		float jumpTime = 0f;
		Vector3 startPosition = base.transform.position;
		float leapDistance = Vector3.Distance(base.transform.position, leapEnd.position);
		while (jumpTime < 1f)
		{
			jumpTime += Time.deltaTime / leapDistance * jumpSpeed * jumpSpeedMult;
			float num2 = 0f - Mathf.Pow(2f * jumpTime - 1f, 2f) + 1f;
			base.transform.position = Vector3.Lerp(startPosition, leapEnd.position + leapEnd.forward * 0.5f, jumpTime) + Vector3.up * num2 * jumpArcHeight;
			geoRoot.transform.position = base.transform.position;
			geoRoot.transform.rotation = Quaternion.Lerp(startRotation, endRotation, jumpTime);
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Arrow(geoRoot.transform.position, geoRoot.transform.position + geoRoot.transform.up, Color.magenta);
				CL_DebugView.draw.Arrow(geoRoot.transform.position, geoRoot.transform.position + geoRoot.transform.forward, Color.blue);
			}
			yield return null;
		}
		_ = endRotation;
		geoRoot.transform.rotation = endRotation;
		geoRoot.transform.position = Vector3.Lerp(geoRoot.transform.position, leapEnd.position + leapEnd.forward * 0.5f, Time.deltaTime * 2f);
		anim.SetBool("leaping", value: false);
		path = seeker.StartPath(base.transform.position, targetPosition, OnPathComplete);
		CL_CameraControl.CalculateShake(base.transform.position, 0.15f, 15f);
		snapGeo = true;
		facingDir = GetFacingNormal().normalized;
		clipHandler.PlaySound("teeth:land");
		yield return new WaitForSeconds(0.5f);
		facingDir = GetFacingNormal().normalized;
		geoRoot.transform.rotation = endRotation;
		leaping = false;
		yield return new WaitForSeconds(2f);
		seeker.traversableTags |= 2;
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		info = ProcessDamageInfo(info);
		if (currentState.name == "retreat")
		{
			return false;
		}
		clipHandler.PlaySound("teeth:hurt");
		if (info.HasTag("hammer"))
		{
			info.amount /= 8f;
		}
		curStunDamage += info.amount;
		curBarkTime = barkTime;
		Debug.Log("Taken Damage!");
		if (curStunDamage >= stunDamage || info.type == "flare")
		{
			curStunDamage = 0f;
			ChangeState("retreat");
		}
		return false;
	}

	private Vector3[] GenerateEquidistantVectors(int numPoints)
	{
		Vector3[] array = new Vector3[numPoints];
		float num = MathF.PI * (3f - Mathf.Sqrt(5f));
		for (int i = 0; i < numPoints; i++)
		{
			float num2 = 1f - (float)i / (float)(numPoints - 1) * 2f;
			float num3 = Mathf.Sqrt(1f - num2 * num2);
			float f = num * (float)i;
			float x = Mathf.Cos(f) * num3;
			float z = Mathf.Sin(f) * num3;
			array[i] = new Vector3(x, num2, z);
		}
		return array;
	}

	public void Despawn()
	{
		UnityEngine.Object.Destroy(base.transform.parent.gameObject);
	}

	public void SetTeethAILock(string[] args)
	{
		if (args.Length == 0)
		{
			lockAI = !lockAI;
			CommandConsole.Log("Teeth AI set to " + lockAI);
		}
		else
		{
			lockAI = Convert.ToBoolean(args[0]);
			CommandConsole.Log("Teeth AI set to " + lockAI);
		}
	}

	public void SetCohesionEffect(float f)
	{
		cohesionEffect = f;
	}

	public void SetBurnEffect(float f)
	{
		burnEffect = f;
	}

	public override void OffsetEntity(float amount)
	{
		if (base.transform.parent.parent == null)
		{
			base.transform.parent.position += Vector3.up * amount;
		}
	}
}
