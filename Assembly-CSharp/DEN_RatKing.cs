using System.Collections.Generic;
using DarkMachine.AI;
using UnityEngine;
using UnityEngine.Events;

public class DEN_RatKing : Denizen
{
	public AITargetComponent targetComponent;

	public AIN_Standard navigator = new AIN_Standard();

	public float speed;

	private Vector3 moveTarget;

	private Rigidbody rigid;

	public float minimumSlamVelocity = 3f;

	public ParticleSystem particleSparks;

	public ParticleSystem particleSlam;

	public UnityEvent slamEvent;

	public float collideShakeAmount = 0.1f;

	private float randomSearchTimer;

	public float randomSearchDistance = 20f;

	public static List<DEN_RatKing> activeRatKings;

	private static bool active = true;

	private static bool ratKingHasSpawned;

	private float curSpinupTimer;

	public float spinupTime = 1f;

	private float lastSpinupTime;

	public UnityEvent spinupEvent;

	private void Awake()
	{
		navigator.Initialize(this);
		rigid = GetComponent<Rigidbody>();
		if (!ratKingHasSpawned)
		{
			ratKingHasSpawned = true;
			CommandConsole.BuildVariableBool(() => ref active, "ratking-setactive", null);
		}
	}

	public override void OnEnable()
	{
		base.OnEnable();
		if (activeRatKings == null)
		{
			activeRatKings = new List<DEN_RatKing>();
		}
		activeRatKings.Add(this);
	}

	public override void OnDisable()
	{
		base.OnDisable();
		if (activeRatKings == null)
		{
			activeRatKings = new List<DEN_RatKing>();
		}
		if (activeRatKings.Contains(this))
		{
			activeRatKings.Remove(this);
		}
	}

	public override void Update()
	{
		if (!active)
		{
			return;
		}
		base.Update();
		target = ENT_Player.GetPlayer().transform;
		if (sight.CanSeeTarget(base.transform.position, target, sight.sightDistance, null, checkMemory: true))
		{
			SetTargetPosition(ENT_Player.GetPlayer().transform.position);
			randomSearchTimer = 10f;
		}
		else
		{
			if (randomSearchTimer <= 0f)
			{
				SetTargetPosition(ENT_Player.GetPlayer().transform.position + Random.insideUnitSphere * randomSearchDistance);
				randomSearchTimer = 10f;
			}
			randomSearchTimer -= Time.deltaTime;
		}
		target = ENT_Player.GetPlayer().transform;
		Movement();
		SetNavigationTargetPosition(GetTargetPosition());
		DebugDraw();
	}

	public void Movement()
	{
		moveTarget = navigator.GetMovementTarget(sight, GetTargetPosition(), useSight: false);
		if (sight.CanSeeTarget(target, checkMemory: true))
		{
			moveTarget = target.position;
			if (Time.time - lastSpinupTime > 15f)
			{
				curSpinupTimer = spinupTime;
				lastSpinupTime = Time.time;
				clipHandler.PlaySound("denizen:chase-spinup");
				spinupEvent.Invoke();
			}
		}
		if (curSpinupTimer > 0f)
		{
			curSpinupTimer -= Time.deltaTime;
		}
		else if (CL_GameManager.IsHardmode())
		{
			rigid.AddForce(Vector3.ClampMagnitude(moveTarget - base.transform.position, 1f) * Time.deltaTime * speed * 1.5f);
		}
		else
		{
			rigid.AddForce(Vector3.ClampMagnitude(moveTarget - base.transform.position, 1f) * Time.deltaTime * speed);
		}
		if (rigid.linearVelocity.magnitude > 1f)
		{
			if (!particleSparks.isPlaying)
			{
				particleSparks.Play();
			}
		}
		else if (particleSparks.isPlaying)
		{
			particleSparks.Stop();
		}
	}

	internal override void OnCollisionEnter(Collision collision)
	{
		base.OnCollisionEnter(collision);
		CL_CameraControl.ShakeAtPosition(base.transform.position, collideShakeAmount * collision.impulse.magnitude, 30f);
		if (collision.impulse.magnitude > minimumSlamVelocity)
		{
			particleSlam.Play();
			slamEvent.Invoke();
		}
	}

	public override void SetNavigationTargetPosition(Vector3 position)
	{
		navigator.UpdatePath(base.transform.position, position, null);
	}

	public void OverrideNavigationTargetPosition(Vector3 position)
	{
		SetTargetPosition(position);
		navigator.UpdatePath(base.transform.position, position, null);
		randomSearchTimer = 8f;
	}

	private void DebugDraw()
	{
		if (!CL_UIManager.debug || !CommandConsole.hasCheated)
		{
			return;
		}
		if (navigator.GetLastPath() != null && navigator.GetLastPath().vectorPath.Count > 0)
		{
			for (int i = 0; i < navigator.GetLastPath().vectorPath.Count; i++)
			{
				if (i < navigator.GetLastPath().vectorPath.Count - 1)
				{
					CL_DebugView.draw.Arrow(navigator.GetLastPath().vectorPath[i], navigator.GetLastPath().vectorPath[i + 1], Color.yellow);
				}
				CL_DebugView.draw.Label2D(navigator.GetLastPath().vectorPath[i], "PH:" + i + " / Can See: " + sight.CanSeeToPosition(navigator.GetLastPath().vectorPath[i]));
			}
			CL_DebugView.draw.Arrow(base.transform.position + Vector3.up * 0.1f, navigator.GetLastPath().vectorPath[0] + Vector3.up * 0.1f, Color.green);
		}
		CL_DebugView.draw.Label2D(base.transform.position, (navigator.GetLastPath() != null) ? "Path: Found" : "Path: Null", Color.white);
		CL_DebugView.draw.Arrow(base.transform.position, targetPosition, Color.white);
	}
}
