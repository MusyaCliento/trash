using System;
using System.Collections.Generic;
using UnityEngine;

public class DEN_Tracker : DEN_SimpleChaseKiller
{
	private enum State
	{
		Tracking = 0,
		RunningAway = 1
	}

	private struct Handhold
	{
		public Vector3 pos;

		public Vector3 normal;

		public CL_Handhold handhold;
	}

	private struct History
	{
		public Vector3 origin;

		public Vector3 direction;

		public float maxDistance;

		public float distance;
	}

	public FX_DecalSplatterSetting handprint;

	public FX_DecalSplatterSetting footprint;

	public FXManager.FXData proximityEffect;

	private float proximityEffectBlend;

	public float proximityEffectBlendFadeRate = 0.2f;

	public float placePrintDistance = 0.5f;

	private float distanceTravelled;

	private Vector3 lastForward;

	public LayerMask hitMask;

	private State state;

	private float bored;

	public float boredTimer = 12f;

	public float boredTimerVariance = 5f;

	public float boredDistance = 15f;

	public float teleportToDistance = 6f;

	private float fulfilled;

	public float fulfilledTimer = 10f;

	public float fulfilledTimerVariance = 3f;

	public float fulfilledDistance = 6f;

	public float runAwaySpeed = 15f;

	public float runAwayPrintDistance = 0.2f;

	public float runAwayPrintPitch = 0.7f;

	public float runAwayPrintPitchVariance = 0.2f;

	public int maxHandholdsInMemory = 20;

	public float maxHandholdGrabDistance = 2f;

	private List<Handhold> handholdMemory = new List<Handhold>();

	private CL_Handhold[] handholdLastFrame = new CL_Handhold[0];

	private Vector3 printScale = Vector3.one;

	private int lowestRunningAway = 1;

	private List<History> history = new List<History>();

	public override void Start()
	{
		base.Start();
		bored = UnityEngine.Random.Range(boredTimer - boredTimerVariance, boredTimer + boredTimerVariance);
	}

	public override void Update()
	{
		if (CL_UIManager.debug)
		{
			for (int i = 0; i < this.history.Count; i++)
			{
				Color color = DarkMachineCrayons.crayons[i % this.history.Count];
				CL_DebugView.draw.PushColor(color);
				History history = this.history[i];
				CL_DebugView.draw.Arrow(history.origin, history.origin + history.direction * history.distance);
				CL_DebugView.draw.Line(history.origin, history.origin + history.direction * history.maxDistance);
				CL_DebugView.draw.PopColor();
			}
		}
		if (proximityEffectBlend > 0f)
		{
			FXManager.fxZones.Enqueue(new FXManager.FXZoneStore
			{
				blend = Mathf.Clamp01(proximityEffectBlend),
				priority = 15,
				data = proximityEffect
			}, 15);
		}
		if (!CL_GameManager.gMan.isPaused)
		{
			base.Update();
			UpdateSnapshots();
			proximityEffectBlend = Mathf.Clamp01(proximityEffectBlend - proximityEffectBlendFadeRate * Time.deltaTime);
			if (state == State.Tracking)
			{
				UpdatePlayerMemory();
				UpdateBored();
				UpdateFulfilled();
			}
		}
	}

	private void UpdateSnapshots()
	{
		Vector3 vector = GetTrueVelocity();
		distanceTravelled += vector.magnitude * Time.deltaTime;
		if (distanceTravelled < placePrintDistance)
		{
			return;
		}
		distanceTravelled = 0f;
		if (Mathf.Abs(vector.x) > 0.01f || Mathf.Abs(vector.y) > 0.01f)
		{
			lastForward = vector;
			lastForward.y = 0f;
			lastForward = lastForward.normalized;
		}
		bool num = Mathf.Abs(vector.x) + Mathf.Abs(vector.z) < vector.y;
		bool flag = num && vector.y > 0f;
		bool num2 = !num && (double)vector.y > -0.5;
		FX_DecalShared fX_DecalShared = null;
		Vector3 vector2 = Vector3.zero;
		Vector3 up = Vector3.zero;
		float num3 = 0f;
		string sound = "";
		if (num2)
		{
			fX_DecalShared = footprint.GetRandomDecal();
			vector2 = Vector3.down;
			up = lastForward;
			num3 = 2f;
			sound = "denizen:step";
		}
		if (flag)
		{
			fX_DecalShared = handprint.GetRandomDecal();
			vector2 = lastForward;
			up = Vector3.up;
			num3 = 8f;
			sound = "denizen:grab";
		}
		int num4 = -1;
		float num5 = maxHandholdGrabDistance;
		int num6 = 0;
		while (target != null && flag && num6 < handholdMemory.Count)
		{
			Handhold handhold = handholdMemory[num6];
			if (!(Vector3.Distance(handhold.pos, target.position) < stopAtDistance))
			{
				float num7 = Vector3.Distance(handhold.pos, base.transform.position);
				if (!(num7 > num5))
				{
					num4 = num6;
					num5 = num7;
				}
			}
			num6++;
		}
		if (num4 != -1 && UnityEngine.Random.value > 0.7f)
		{
			clipHandler.PlaySound(sound);
			Handhold handhold2 = handholdMemory[num4];
			Vector3 point = new Plane(handhold2.normal, handhold2.pos).ClosestPointOnPlane(handhold2.pos + UnityEngine.Random.insideUnitSphere * 0.333f);
			PlacePrint(handprint.GetRandomDecal(), point, handhold2.normal, Vector3.up, handhold2.handhold.transform);
			fX_DecalShared = null;
			handholdMemory.RemoveRange(0, num4 + 1);
		}
		Vector3 normalized = (vector2 * 4f + UnityEngine.Random.onUnitSphere).normalized;
		if (fX_DecalShared != null && Physics.SphereCast(base.transform.position, 0.5f, normalized, out var hitInfo, num3, hitMask))
		{
			clipHandler.PlaySound(sound);
			PlacePrint(fX_DecalShared, hitInfo.point, hitInfo.normal, up, (hitInfo.collider != null) ? hitInfo.collider.transform : null);
			history.Add(new History
			{
				origin = base.transform.position,
				direction = normalized,
				distance = (hitInfo.point - base.transform.position).magnitude,
				maxDistance = num3
			});
		}
		else
		{
			history.Add(new History
			{
				origin = base.transform.position,
				direction = normalized,
				distance = num3,
				maxDistance = num3
			});
		}
		if (history.Count >= 10)
		{
			history.RemoveAt(0);
		}
	}

	private void PlacePrint(FX_DecalShared decal, Vector3 point, Vector3 normal, Vector3 up, Transform parent)
	{
		FXManager.DecalHandle handle = FXManager.DecalCreate(FXManager.DecalPriority.Low);
		FXManager.DecalSharedApply(handle, FXManager.DecalSharedData(decal));
		FXManager.DecalPointingFrom(handle, point, normal, up, parent, printScale);
		FXManager.DecalFadeout(handle, 5f, 5f);
		printScale.x *= -1f;
	}

	private void UpdatePlayerMemory()
	{
		ENT_Player player = ENT_Player.GetPlayer();
		if (player == null)
		{
			return;
		}
		if (player.hands.Length != handholdLastFrame.Length)
		{
			Array.Resize(ref handholdLastFrame, player.hands.Length);
		}
		for (int i = 0; i < player.hands.Length; i++)
		{
			ENT_Player.Hand hand = player.hands[i];
			ref CL_Handhold reference = ref handholdLastFrame[i];
			if (hand.handhold != reference && hand.handhold != null)
			{
				handholdMemory.Add(new Handhold
				{
					pos = hand.handhold.transform.position,
					normal = (player.transform.position - hand.handhold.transform.position).normalized,
					handhold = hand.handhold
				});
			}
			reference = hand.handhold;
		}
		if (handholdMemory.Count > maxHandholdsInMemory)
		{
			handholdMemory.RemoveRange(0, handholdMemory.Count - maxHandholdsInMemory);
		}
	}

	private void UpdateBored()
	{
		if (target == null)
		{
			return;
		}
		if (Vector3.Distance(target.position, base.transform.position) < boredDistance)
		{
			bored = UnityEngine.Random.Range(boredTimer - boredTimerVariance, boredTimer + boredTimerVariance);
			return;
		}
		bored -= Time.deltaTime;
		if (bored > 0f)
		{
			return;
		}
		bored = UnityEngine.Random.Range(boredTimer - boredTimerVariance, boredTimer + boredTimerVariance);
		Vector3? vector = null;
		Vector3 result;
		while (playerTrackPositions.TryDequeue(out result))
		{
			float num = Vector3.Distance(target.transform.position, result);
			if (num < stopAtDistance)
			{
				break;
			}
			if (num < teleportToDistance)
			{
				vector = result;
			}
		}
		if (vector.HasValue)
		{
			base.transform.position = vector.Value;
			playerTrackPositions.Clear();
		}
	}

	private void UpdateFulfilled()
	{
		if (target == null)
		{
			return;
		}
		if (Vector3.Distance(target.position, base.transform.position) > fulfilledDistance)
		{
			fulfilled = fulfilledTimer + UnityEngine.Random.Range(0f - fulfilledTimerVariance, fulfilledTimerVariance);
			return;
		}
		fulfilled -= Time.deltaTime;
		proximityEffectBlend = Mathf.Max(Mathf.Clamp01(1f - fulfilled / (fulfilledTimer - fulfilledTimerVariance)), proximityEffectBlend);
		if (!(fulfilled > 0f))
		{
			RunAway(target.transform);
		}
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		RunAway(info.sourceEntity.transform);
		return false;
	}

	private void RunAway(Transform from)
	{
		state = State.RunningAway;
		playerTrackPositions.Clear();
		Vector3 normalized = (base.transform.position - from.position).normalized;
		normalized.y = 0f;
		Vector3 item = base.transform.position + normalized * 100f;
		playerTrackPositions.Enqueue(item);
		target = null;
		distanceTravelled = 0f;
		speedMax = runAwaySpeed;
		curSpeed = runAwaySpeed;
		placePrintDistance = runAwayPrintDistance;
		UT_AudioClipHandler.AudioSet audioSet = clipHandler.GetGroup("denizen").audioDictionary["step"];
		audioSet.minPitch = runAwayPrintPitch - runAwayPrintPitchVariance;
		audioSet.maxPitch = runAwayPrintPitch + runAwayPrintPitchVariance;
		audioSet.spatialBlend = 0.8f;
		mood = "Scitterish";
	}
}
