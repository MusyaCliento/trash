using System.Collections;
using DG.Tweening;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class DEN_Remains_Active : Denizen
{
	public bool active = true;

	public Animator animator;

	public CapsuleCollider capsuleCollider;

	public SkinnedMeshRenderer meshRenderer;

	private Rigidbody rigid;

	public float viewRadius;

	public float moveSpeed = 0.5f;

	public float moveSpeedRand = 0.1f;

	private bool canBeSeen;

	public float scanDistance = 4f;

	public int scanCount = 24;

	public LayerMask scanLayerMask;

	private static int curClimbState;

	private static int curFloatState;

	public int animClimbStateCount = 6;

	public int animFloatStateCount = 4;

	public float randomWalkMult = 1f;

	public float moveSoundRate = 0.5f;

	public float proximityRadius = 10f;

	public float proximityHazardBuildRate = 1f;

	private float proximityHazardCount;

	public float proximityBlend;

	public FXManager.FXData dangerFX;

	public FXManager.FXData killFX;

	public float proximityPerlinSpeed = 1f;

	public float proximityKillTime = 2f;

	public UnityEvent onStartKill;

	public float neckSnapDuration = 0.5f;

	public Vector3 neckSnapRotation = new Vector3(0f, 50f, -30f);

	public AnimationCurve neckSnapCurve;

	public float climbSoundRate = 0.3f;

	private float climbSoundTimer = 1f;

	private bool isKillingPlayer;

	public AudioSource proximityLoop;

	public override void Start()
	{
		base.Start();
		rigid = GetComponent<Rigidbody>();
		moveSpeed += Random.value * moveSpeedRand;
		if (CL_GameManager.IsHardmode())
		{
			moveSpeed *= 2f;
		}
		proximityLoop.volume = 0f;
	}

	public override void Update()
	{
		if (!active)
		{
			return;
		}
		base.Update();
		if (!isKillingPlayer)
		{
			if (meshRenderer.isVisible)
			{
				if (!canBeSeen)
				{
					canBeSeen = true;
					rigid.isKinematic = true;
					OnBecomeVisible();
				}
			}
			else
			{
				if (canBeSeen)
				{
					canBeSeen = false;
					rigid.isKinematic = false;
				}
				climbSoundTimer -= Time.deltaTime;
				if (climbSoundTimer < 0f)
				{
					climbSoundTimer = climbSoundRate + Random.value * 0.1f;
					clipHandler.PlaySound("denizen:climb");
				}
			}
		}
		else
		{
			FXManager.FXZoneStore fXZoneStore = new FXManager.FXZoneStore();
			fXZoneStore.blend = proximityBlend;
			fXZoneStore.priority = 30;
			fXZoneStore.data = killFX;
			FXManager.fxZones.Enqueue(fXZoneStore, 30);
		}
		float num = Vector3.Distance(base.transform.position, ENT_Player.GetPlayer().transform.position);
		if (num < proximityRadius)
		{
			float num2 = num / proximityRadius;
			proximityHazardCount = Mathf.Clamp01(proximityHazardCount + Time.deltaTime * proximityHazardBuildRate * (1f - num2));
			if (proximityHazardCount >= 1f)
			{
				proximityKillTime += Time.deltaTime;
				if (proximityKillTime > 2f && !ENT_Player.GetPlayer().IsDead() && !ENT_Player.GetPlayer().IsLocked() && !ENT_Player.GetPlayer().GetGodmode())
				{
					ENT_Player.GetPlayer().Lock();
					StartCoroutine(NeckSnap());
				}
			}
			else if (proximityKillTime > 0f)
			{
				proximityKillTime -= Time.deltaTime * 2f;
			}
		}
		else
		{
			proximityHazardCount = Mathf.Clamp01(proximityHazardCount - Time.deltaTime * proximityHazardBuildRate);
		}
		proximityLoop.volume = proximityHazardCount * 0.2f;
		proximityBlend = Mathf.Lerp(proximityBlend, Mathf.PerlinNoise1D(Time.time * proximityPerlinSpeed) * 0.5f * proximityHazardCount + 0.5f * proximityHazardCount, Time.deltaTime * 10f);
		DataLerp();
		IEnumerator NeckSnap()
		{
			isKillingPlayer = true;
			clipHandler.PlaySound("denizen:murder-activate");
			onStartKill.Invoke();
			animator.Play("Float_0" + 1);
			CL_UIManager.instance.QuickFlashVignette("fade");
			CL_CameraControl.Shake(0.5f);
			proximityBlend = 1f;
			ENT_Player.GetPlayer().AddEffect("wet", 1f);
			base.transform.position = ENT_Player.GetPlayer().cam.transform.position + -ENT_Player.GetPlayer().cam.transform.forward * 0.5f;
			base.transform.rotation = Quaternion.LookRotation(ENT_Player.GetPlayer().cam.transform.position - base.transform.position);
			base.transform.position += -base.transform.up;
			yield return new WaitForSeconds(0.4f);
			clipHandler.PlaySound("denizen:murder-start");
			CL_CameraControl.Shake(0.15f);
			yield return new WaitForSeconds(0.4f);
			clipHandler.PlaySound("denizen:murder");
			CL_CameraControl.Shake(0.15f);
			_ = ENT_Player.GetPlayer().cam.transform.rotation;
			yield return ENT_Player.GetPlayer().cam.transform.DOLocalRotate(neckSnapRotation, neckSnapDuration).SetEase(neckSnapCurve).WaitForCompletion();
			ENT_Player.GetPlayer().Kill("remains");
			CL_UIManager.instance.SetVignette("fade", 1f);
		}
	}

	public override void TickUpdate()
	{
		base.TickUpdate();
		if (active && !canBeSeen && !isKillingPlayer)
		{
			Vector3 vector = Random.insideUnitSphere * randomWalkMult;
			rigid.MovePosition(base.transform.position + (ENT_Player.GetPlayer().transform.position - base.transform.position + vector) * moveSpeed * tickRate);
		}
	}

	private void OnBecomeVisible()
	{
		(bool, RaycastHit) tuple = SearchForRestLocation();
		if (tuple.Item1)
		{
			if ((double)Vector3.Dot(tuple.Item2.normal, Vector3.up) < 0.45)
			{
				base.transform.rotation = Quaternion.LookRotation(-tuple.Item2.normal, Vector3.ProjectOnPlane(ENT_Player.GetPlayer().transform.position - base.transform.position, tuple.Item2.normal));
				base.transform.position = tuple.Item2.point + tuple.Item2.normal * 0.2f;
				animator.Play("Climb_0" + curClimbState);
				curClimbState++;
				if (curClimbState > animClimbStateCount)
				{
					curClimbState = 1;
				}
			}
			else
			{
				base.transform.rotation = Quaternion.LookRotation(Vector3.Scale(ENT_Player.GetPlayer().transform.position - base.transform.position, new Vector3(1f, 0f, 1f)));
				base.transform.position = tuple.Item2.point + tuple.Item2.normal * 1.5f;
				animator.Play("Float_0" + curFloatState);
				curFloatState++;
				if (curFloatState > animFloatStateCount)
				{
					curFloatState = 1;
				}
			}
		}
		else
		{
			base.transform.rotation = Quaternion.LookRotation(Vector3.Scale(ENT_Player.GetPlayer().transform.position - base.transform.position, new Vector3(1f, 0f, 1f)));
			animator.Play("Float_0" + curFloatState);
			curFloatState++;
			if (curFloatState > animFloatStateCount)
			{
				curFloatState = 1;
			}
		}
	}

	private void DataLerp()
	{
		FXManager.FXZoneStore fXZoneStore = new FXManager.FXZoneStore();
		fXZoneStore.blend = proximityBlend;
		fXZoneStore.priority = 15;
		fXZoneStore.data = dangerFX;
		FXManager.fxZones.Enqueue(fXZoneStore, 15);
	}

	private (bool hasFoundSpot, RaycastHit hit) SearchForRestLocation()
	{
		Vector3[] array = DarkMachineFunctions.GenerateEquidistantVectors(scanCount);
		for (int i = 0; i < scanCount; i++)
		{
			RaycastHit hitInfo = default(RaycastHit);
			Vector3 direction = base.transform.TransformVector(Quaternion.Euler(90f, 0f, 0f) * array[i]);
			if (Physics.Raycast(base.transform.position, direction, out hitInfo, scanDistance, scanLayerMask))
			{
				return (hasFoundSpot: true, hit: hitInfo);
			}
		}
		return (hasFoundSpot: false, hit: default(RaycastHit));
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.SphereOutline(base.transform.position, viewRadius);
		Vector3[] array = DarkMachineFunctions.GenerateEquidistantVectors(scanCount);
		for (int i = 0; i < scanCount; i++)
		{
			Vector3 vector = base.transform.position + base.transform.TransformVector(Quaternion.Euler(90f, 0f, 0f) * array[i]) * scanDistance;
			Draw.Label2D(vector, "P: " + i);
			Draw.Line(base.transform.position, vector, Color.Lerp(DarkMachineCrayons.red, DarkMachineCrayons.green, (float)i / (float)scanCount));
		}
	}
}
