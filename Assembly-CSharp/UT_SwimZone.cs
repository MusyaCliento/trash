using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Audio;

public class UT_SwimZone : MonoBehaviourGizmos
{
	private class Shared
	{
		public List<UT_SwimZone> activeSwimZones = new List<UT_SwimZone>();

		public HashSet<UT_SwimZone> activeBreathZones = new HashSet<UT_SwimZone>();

		public List<UT_SwimZone> swimZones = new List<UT_SwimZone>();

		public float globalAudioBlend;

		public UT_SwimZone primaryAudioZone;
	}

	public Bounds swimBounds;

	public FXManager.FXData swimFX;

	private bool isPlayerFeetInZone;

	public AudioClip splashSound;

	public AudioClip leaveSound;

	public ParticleSystem splashFXPrefab;

	private ParticleSystem splashFX;

	public float blendDistance = 0.1f;

	private AudioMixer audioMixer;

	public float drag = 5f;

	public float swimSpeedMult = 1f;

	public bool buffPlayer;

	public BuffContainer swimBuff;

	private void OnEnable()
	{
		CL_GameManager.GetPerRunData<Shared>().swimZones.Add(this);
	}

	private void OnDisable()
	{
		Shared perRunData = CL_GameManager.GetPerRunData<Shared>();
		if (perRunData.swimZones != null)
		{
			perRunData.swimZones.Remove(this);
		}
		if (perRunData.activeBreathZones != null && perRunData.activeBreathZones.Contains(this))
		{
			perRunData.activeBreathZones.Remove(this);
		}
		if (perRunData.activeSwimZones != null)
		{
			perRunData.activeSwimZones.Remove(this);
		}
	}

	private void Start()
	{
		if (splashFXPrefab != null)
		{
			splashFX = Object.Instantiate(splashFXPrefab, base.transform);
			splashFX.Stop();
		}
		audioMixer = AudioManager.instance.mixer;
	}

	private void Update()
	{
		Shared perRunData = CL_GameManager.GetPerRunData<Shared>();
		if (perRunData.activeSwimZones == null)
		{
			perRunData.activeSwimZones = new List<UT_SwimZone>();
		}
		if (perRunData.activeBreathZones == null)
		{
			perRunData.activeBreathZones = new HashSet<UT_SwimZone>();
		}
		CheckForPlayer();
	}

	private void CheckForPlayer()
	{
		Shared perRunData = CL_GameManager.GetPerRunData<Shared>();
		if (ENT_Player.playerObject == null)
		{
			return;
		}
		if (IsPositionInSwimZone(ENT_Player.GetPlayer().transform.position))
		{
			if (!perRunData.activeSwimZones.Contains(this))
			{
				perRunData.activeSwimZones.Add(this);
			}
			ENT_Player.GetPlayer().SetSwimming(swim: true);
			if (buffPlayer && swimBuff != null)
			{
				swimBuff.buffTime = 1f;
				ENT_Player.GetPlayer().Buff(swimBuff);
			}
		}
		else if (perRunData.activeSwimZones.Contains(this))
		{
			perRunData.activeSwimZones.Remove(this);
			if (perRunData.activeSwimZones.Count == 0)
			{
				ENT_Player.GetPlayer().SetSwimming(swim: false);
			}
		}
		float num = Mathf.Sqrt(swimBounds.SqrDistance(base.transform.InverseTransformPoint(ENT_Player.GetPlayer().cam.transform.position))) + blendDistance / 2f;
		float blend = 1f - Mathf.Clamp01(num / blendDistance);
		FXManager.FXZoneStore fXZoneStore = new FXManager.FXZoneStore();
		fXZoneStore.blend = blend;
		fXZoneStore.priority = 15;
		fXZoneStore.data = swimFX;
		FXManager.fxZones.Enqueue(fXZoneStore, 50);
		if (IsPositionInSwimZone(ENT_Player.GetPlayer().cam.transform.position))
		{
			if (!perRunData.activeBreathZones.Contains(this))
			{
				perRunData.activeBreathZones.Add(this);
				ENT_Player.GetPlayer().SetHasOxygen(oxy: false);
			}
		}
		else
		{
			if (perRunData.activeBreathZones.Contains(this))
			{
				perRunData.activeBreathZones.Remove(this);
			}
			if (perRunData.activeBreathZones.Count == 0)
			{
				ENT_Player.GetPlayer().SetHasOxygen(oxy: true);
			}
		}
		Vector3 position = ENT_Player.GetPlayer().transform.position - new Vector3(0f, ENT_Player.GetPlayer().cCon.height / 2f, 0f);
		if (!isPlayerFeetInZone && IsPositionInSwimZone(position))
		{
			isPlayerFeetInZone = true;
			Splash(position);
		}
		else if (isPlayerFeetInZone && !IsPositionInSwimZone(position))
		{
			isPlayerFeetInZone = false;
			AudioManager.PlaySound(leaveSound, position, 0.6f);
			if (splashFX != null)
			{
				splashFX.transform.position = position;
				splashFX.Play();
			}
		}
	}

	public bool IsPositionInSwimZone(Vector3 position)
	{
		return swimBounds.Contains(base.transform.InverseTransformPoint(position));
	}

	public void Splash(Vector3 position)
	{
		AudioManager.PlaySound(splashSound, position, 0.6f);
		if (splashFX != null)
		{
			splashFX.transform.position = position;
			splashFX.Play();
		}
	}

	private void OnDestroy()
	{
		Shared perRunData = CL_GameManager.GetPerRunData<Shared>();
		if (perRunData.activeSwimZones != null && perRunData.activeSwimZones.Count > 0 && perRunData.activeSwimZones.Contains(this))
		{
			perRunData.activeSwimZones.Remove(this);
		}
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.WireBox(base.transform.position + swimBounds.center, base.transform.rotation, swimBounds.size, Color.blue);
		Draw.SolidBox(base.transform.position + swimBounds.center, base.transform.rotation, swimBounds.size, new Color(0f, 0f, 1f, 0.01f));
	}

	public Vector3 ClampPositionToSwimZone(Vector3 position)
	{
		return base.transform.TransformPoint(swimBounds.ClosestPoint(base.transform.InverseTransformPoint(position)));
	}

	public static UT_SwimZone GetTargetSwimZone(Vector3 position)
	{
		Shared perRunData = CL_GameManager.GetPerRunData<Shared>();
		if (perRunData.swimZones == null)
		{
			return null;
		}
		foreach (UT_SwimZone swimZone in perRunData.swimZones)
		{
			if (swimZone.IsPositionInSwimZone(position))
			{
				return swimZone;
			}
		}
		return null;
	}

	public static bool IsPositionInAnySwimZone(Vector3 position, out UT_SwimZone swimZone)
	{
		Shared perRunData = CL_GameManager.GetPerRunData<Shared>();
		swimZone = null;
		if (perRunData.swimZones == null)
		{
			return false;
		}
		foreach (UT_SwimZone swimZone2 in perRunData.swimZones)
		{
			if (swimZone2.IsPositionInSwimZone(position))
			{
				swimZone = swimZone2;
				return true;
			}
		}
		return false;
	}

	internal float GetDepth(Vector3 position)
	{
		Vector3 vector = base.transform.InverseTransformPoint(position);
		return swimBounds.max.y - vector.y;
	}
}
