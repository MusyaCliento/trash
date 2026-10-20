using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

[DefaultExecutionOrder(20)]
public class DEN_DeathFloor : GameEntity
{
	[Serializable]
	public class SaveData
	{
		public float relativeHeight;

		public bool active;

		public float speed;

		public float speedMult;
	}

	[Serializable]
	public class DistanceAudio
	{
		public string name = "spooky sound";

		public AudioClip clip;

		public float maxDistance = 10f;

		public AnimationCurve volumeCurve;

		public float volume = 1f;

		public float spatialBlend = 1f;

		public bool lerpVolume;

		public float lerpRate = 1f;

		[HideInInspector]
		public AudioSource audioSource;
	}

	public static DEN_DeathFloor instance;

	private ENT_Player player;

	public UT_AudioClipHandler clipHandler;

	public List<DistanceAudio> audiosets;

	public float maxDistanceMultiplier = 1f;

	public float globalVolume = 1f;

	public bool usePlayerStartHeight = true;

	public float playerStartHeight = 16f;

	public float speed = 1f;

	public float maxSpeed = 2f;

	public float speedIncreaseRate = 0.001f;

	private float speedIncreaseRateMultiplier = 1f;

	public float rubberbandMult = 1f;

	private bool rubberbandActive = true;

	public float playerEaseHeight = 150f;

	public AnimationCurve playerEaseCurve;

	public GameObject visualRoot;

	public MeshRenderer deathFloorRenderer;

	public Texture2D corruptionTexture;

	public float offsetScale = 10f;

	public bool setCorruptionHeight = true;

	public float closeScreenShake;

	public float closeShakeDistance = 10f;

	public AnimationCurve closeShakeCurve;

	public float roarShake = 0.06f;

	private float resetTime;

	private float playerDistance;

	private float speedMult = 1f;

	private float speedMultFrame = 1f;

	private float speedMultFrameStorage = 1f;

	private float currentVolume;

	private float volumeTarget = 1f;

	private AudioSource[] localAuds;

	private bool killedPlayer;

	private bool active = true;

	private bool canKill = true;

	private bool hasStarted;

	public static UT_GooVisualOverride currentGooVisualOverride;

	private bool isRecentering;

	private void Awake()
	{
		if (instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			instance = this;
		}
	}

	public override void Start()
	{
		base.transform.parent = null;
		if (!usePlayerStartHeight)
		{
			hasStarted = true;
		}
		volumeTarget = 1f;
		clipHandler = GetComponent<UT_AudioClipHandler>();
		localAuds = GetComponentsInChildren<AudioSource>();
		player = ENT_Player.playerObject;
		for (int i = 0; i < audiosets.Count; i++)
		{
			DistanceAudio distanceAudio = audiosets[i];
			distanceAudio.audioSource = base.gameObject.AddComponent<AudioSource>();
			distanceAudio.audioSource.volume = 0f;
			distanceAudio.audioSource.Stop();
			distanceAudio.audioSource.clip = audiosets[i].clip;
			distanceAudio.audioSource.loop = true;
			distanceAudio.audioSource.outputAudioMixerGroup = SettingsManager.instance.effectMixer.outputAudioMixerGroup;
		}
		playerDistance = float.PositiveInfinity;
		CommandConsole.BuildCommand("deathgoo-stop", DeathGooToggle).AutocompleteSingleBool().Description("(enabled=toggle)")
			.OverValue(() => (!(instance != null)) ? null : ((object)(!instance.active)));
		CommandConsole.BuildCommand("deathgoo-cankill", SetCanKill).AutocompleteSingleBool().Description("(enabled=toggle)")
			.OverValue(() => (!(instance != null)) ? null : ((object)instance.canKill));
		CommandConsole.BuildCommand("deathgoo-speed", SetSpeed).AutocompleteSingeFloat().Description("(speed = 0)")
			.OverValue(() => (!(instance != null)) ? null : ((object)instance.speed));
		CommandConsole.BuildCommand("deathgoo-height", SetHeight).AutocompleteSingeFloat().Description("(height relative to player = -10)")
			.OverValue(() => (!(instance != null)) ? null : ((object)(instance.transform.position.y - instance.player.transform.position.y)));
		CommandConsole.BuildCommand("deathgoo-goaway", DeathGooGoAway).Description("BEGONE");
		Shader.SetGlobalTexture("_CORRUPTTEXTURE", corruptionTexture);
		if (CL_GameManager.IsHardmode())
		{
			speed *= 2f;
		}
		base.transform.parent = WorldLoader.GetWorldLoaderNullParent();
		base.Start();
	}

	public override void Update()
	{
		DistanceSounds();
		if (player == null)
		{
			player = ENT_Player.playerObject;
			return;
		}
		if (!base.transform.position.IsFiniteAll())
		{
			Vector3 position = player.transform.position;
			position.y -= speed * 10f;
			Debug.LogError($"Detected non-finite mass position {base.transform.position}. Resetting to {position}...");
			base.transform.position = position;
		}
		playerDistance = Mathf.Abs(base.transform.position.y - player.transform.position.y);
		if (resetTime > 0f)
		{
			resetTime -= Time.deltaTime;
			return;
		}
		currentVolume = Mathf.Lerp(currentVolume, volumeTarget, CL_GameManager.GetPlayerPerceivedDeltaTime());
		if (setCorruptionHeight)
		{
			FXManager.fxMan.corruptionHeight = base.transform.position.y;
		}
		if (!active || CL_GameManager.gMan.isPaused)
		{
			return;
		}
		if (canKill && player.transform.position.y < base.transform.position.y - 1f)
		{
			CL_GameManager.gMan.localPlayer.Kill(objectType);
			killedPlayer = true;
		}
		if (speedMult <= 0.01f)
		{
			return;
		}
		_ = Vector3.up;
		Vector3 position2 = base.transform.position;
		if (!hasStarted && CL_GameManager.GetPlayerTravelDistance() > playerStartHeight)
		{
			hasStarted = true;
			clipHandler.PlaySound("goo:roar");
			CL_CameraControl.Shake(roarShake);
		}
		if (playerDistance < closeShakeDistance)
		{
			CL_CameraControl.Shake(closeScreenShake * (1f - playerDistance / closeShakeDistance) * Time.deltaTime);
		}
		float num = 1f;
		float num2 = 1f;
		if (CL_GameManager.gamemode != null)
		{
			num = CL_GameManager.gamemode.gooSpeedIncreaseMult;
			num2 = CL_GameManager.gamemode.gooSpeedMult;
		}
		if (CL_GameManager.IsHardmode())
		{
			num2 *= 2f;
		}
		float num3 = speedMult * num2 * speedMultFrameStorage;
		if (ENT_Player.GetPlayer() != null)
		{
			num3 /= 1f + ENT_Player.GetPlayer().curBuffs.GetBuff("massResist");
		}
		float buff = ENT_Player.GetPlayer().curBuffs.GetBuff("massSpeedMult");
		float buff2 = ENT_Player.GetPlayer().curBuffs.GetBuff("massSlow");
		num3 *= 1f + buff;
		num3 /= 1f + buff2;
		if (WorldLoader.initialized && WorldLoader.isLoaded && WorldLoader.instance.GetCurrentLevel() != null)
		{
			num3 *= WorldLoader.instance.GetCurrentLevel().GetLevel().massSpeedMult;
			if (WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion != null)
			{
				num3 *= WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion.massSpeedMult;
			}
		}
		float num4 = playerDistance * 0.07f * rubberbandMult;
		if (!rubberbandActive)
		{
			num4 = 1f;
		}
		float num5 = Mathf.Max(speed * num4, speed) * num3;
		if (playerDistance > 300f)
		{
			num5 *= 4f;
		}
		if (!float.IsFinite(num5))
		{
			Debug.LogError($"Detected non-finite speed {num5}. Resetting to 0.");
			num5 = 0f;
		}
		if (hasStarted)
		{
			position2.x = player.transform.position.x;
			position2.z = player.transform.position.z;
			position2.y += Time.deltaTime * num5;
		}
		base.transform.position = position2;
		float num6 = 1f;
		if (CL_GameManager.GetPlayerTravelDistance() > playerEaseHeight)
		{
			float num7 = maxSpeed;
			float num8 = 1f;
			if (CL_GameManager.GetBaseGamemode().HasTag("endless"))
			{
				if (CL_GameManager.gMan.GetPlayerBestTravelDistance() > 10000f)
				{
					num7 = maxSpeed * 100f;
					num8 = 5f;
				}
				else if (CL_GameManager.gMan.GetPlayerBestTravelDistance() > 5000f)
				{
					num7 = (maxSpeed *= 1.5f);
					num8 = 1.3f;
				}
			}
			if (speed < num7)
			{
				if (num3 < 0.5f)
				{
					num6 *= num3;
				}
				speed += Time.deltaTime * speedIncreaseRate * speedIncreaseRateMultiplier * num * num6 * num8;
			}
		}
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Label2D(base.transform.position, $"Speed Mult: {num3} - {speedMult} {num2} {speedMultFrameStorage} || Adjust: {num6} \n Natural Speed: {speed}\nCurrent Speed: {num5}\nDistance: {playerDistance}", 8f, LabelAlignment.Center, Color.red);
		}
		if (CL_GameManager.HasActiveFlag("masshuntplayer") && player.transform.position.y - base.transform.position.y > 40f)
		{
			base.transform.position = player.transform.position - Vector3.up * 40f;
		}
		deathFloorRenderer.material.SetTextureOffset("_MainTex", new Vector2(position2.z, position2.x) / offsetScale);
	}

	private void LateUpdate()
	{
		speedMultFrameStorage = speedMultFrame;
		speedMultFrame = 1f;
	}

	public override void OnDisable()
	{
		base.OnDisable();
		FXManager.fxMan.corruptionHeight = -10000f;
	}

	private void DistanceSounds()
	{
		for (int i = 0; i < audiosets.Count; i++)
		{
			DistanceAudio distanceAudio = audiosets[i];
			float num = distanceAudio.maxDistance * maxDistanceMultiplier;
			if (playerDistance > num * 2f)
			{
				distanceAudio.audioSource.volume = 0f;
				distanceAudio.audioSource.Stop();
				continue;
			}
			if (ENT_Player.playerObject.IsDead())
			{
				distanceAudio.audioSource.volume = Mathf.Lerp(distanceAudio.audioSource.volume, 0f, CL_GameManager.GetPlayerPerceivedDeltaTime() * 8f);
				continue;
			}
			distanceAudio.audioSource.spatialBlend = distanceAudio.spatialBlend;
			if (!distanceAudio.audioSource.isPlaying)
			{
				distanceAudio.audioSource.Play();
			}
			float time = playerDistance / num;
			float num2 = distanceAudio.volumeCurve.Evaluate(time) * distanceAudio.volume;
			if (distanceAudio.lerpVolume)
			{
				distanceAudio.audioSource.volume = Mathf.Lerp(distanceAudio.audioSource.volume, num2 * currentVolume * globalVolume, CL_GameManager.GetPlayerPerceivedDeltaTime() * distanceAudio.lerpRate);
			}
			else
			{
				distanceAudio.audioSource.volume = num2 * currentVolume * globalVolume;
			}
		}
	}

	public void DeathGooToggle(string[] args)
	{
		if (args.Length == 0)
		{
			active = !active;
		}
		else if (!bool.TryParse(args[0], out active))
		{
			CommandConsole.Log("Unable to parse " + args[0] + " arg needs to be a boolean (true/false).");
			return;
		}
		CommandConsole.Log("Death Goo Activity set to " + active);
	}

	public void DeathGooGoAway(string[] args)
	{
		active = false;
		base.transform.position = Vector3.up * -100000f;
		CommandConsole.Log("Bye Bye Mass");
	}

	public void SetHeight(string[] args)
	{
		if (args.Length == 0)
		{
			base.transform.position = player.transform.position - Vector3.up * 10f;
			CommandConsole.Log("Relative Goo Height set to -10");
		}
		else
		{
			base.transform.position = player.transform.position + Vector3.up * float.Parse(args[0]);
			CommandConsole.Log("Relative Goo Height set to " + args[0]);
		}
	}

	public void SetHeight(float h)
	{
		Vector3 position = player.transform.position;
		position.y = h;
		base.transform.position = position;
		FXManager.fxMan.corruptionHeight = base.transform.position.y;
	}

	public void MoveToHeightOfTransform(Transform t)
	{
		StartCoroutine(MoveToHeightSequence(t.position.y));
	}

	public void RaiseOverTime(float amount)
	{
		StartCoroutine(RaiseOverTimeRoutine(amount));
	}

	private IEnumerator RaiseOverTimeRoutine(float amount)
	{
		float time = 1f;
		while (time > 0f)
		{
			time -= Time.deltaTime;
			base.transform.position += Vector3.up * Time.deltaTime * amount;
			yield return null;
		}
	}

	private IEnumerator MoveToHeightSequence(float h)
	{
		while (Mathf.Abs(base.transform.position.y - h) > 0.1f)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(base.transform.position.x, h, base.transform.position.z), Time.deltaTime * 1f);
			yield return null;
		}
	}

	public void SetHeightRelativeToTransform(float h, Transform t)
	{
		Vector3 position = t.position;
		position.y = t.position.y + h;
		base.transform.position = position;
	}

	public void AdjustSpeed(float amount)
	{
		speed = Mathf.Max(speed + amount, 0f);
	}

	public void SetSpeedIncreaseMultiplier(float amount)
	{
		speedIncreaseRateMultiplier = amount;
	}

	public void SetSpeed(string[] args)
	{
		if (args.Length == 0)
		{
			speed = 0f;
			CommandConsole.Log("Goo Speed set to 0");
		}
		else
		{
			SetSpeed(float.Parse(args[0]));
			CommandConsole.Log("Goo Speed set to " + args[0]);
		}
	}

	public void SetSpeed(float s)
	{
		speed = s;
	}

	public void SetCanKill(string[] args)
	{
		if (args.Length == 0)
		{
			canKill = !canKill;
			CommandConsole.Log("Goo Kill set to " + canKill);
		}
		else
		{
			canKill = Convert.ToBoolean(args[0]);
			CommandConsole.Log("Goo Kill set to " + canKill);
		}
	}

	public override void DrawGizmos()
	{
		if (!GizmoContext.InSelection(this))
		{
			return;
		}
		foreach (DistanceAudio audioset in audiosets)
		{
			if (audioset != null)
			{
				Draw.Cross(base.transform.position + Vector3.up * audioset.maxDistance * maxDistanceMultiplier, Color.white);
				Draw.Label2D(base.transform.position + Vector3.up * audioset.maxDistance * maxDistanceMultiplier + Vector3.up * 0.1f, audioset.name, Color.white);
			}
		}
	}

	public void SetUpdateSpeedMultiplier(float s)
	{
		if (base.gameObject.activeInHierarchy)
		{
			speedMultFrame *= s;
		}
	}

	public void SetSpeedMultiplier(float s)
	{
		speedMult = s;
	}

	public void SetRubberbandActive(bool b)
	{
		rubberbandActive = b;
	}

	public void SetTargetVolume(float v)
	{
		volumeTarget = v;
	}

	public void SetActive(bool b)
	{
		active = b;
	}

	public SaveData GetSaveData()
	{
		return new SaveData
		{
			relativeHeight = base.transform.position.y - ENT_Player.playerObject.transform.position.y,
			speed = speed,
			speedMult = speedMult,
			active = active
		};
	}

	public void LoadDataFromSave(SaveData gooData)
	{
		base.transform.position = ENT_Player.playerObject.transform.position + Vector3.up * gooData.relativeHeight;
		speed = gooData.speed;
		speedMult = gooData.speedMult;
		active = gooData.active;
	}

	public float GetCurrentSpeed()
	{
		return speed;
	}

	public float GetCurrentSpeedMult()
	{
		return speedMult * speedMultFrame;
	}

	public bool IsActive()
	{
		return active;
	}

	public bool IsActiveAndMoving()
	{
		if (active)
		{
			return GetCurrentSpeedMult() > 0f;
		}
		return false;
	}

	public void SetVisualActive(bool b)
	{
		visualRoot.SetActive(b);
		if (b && currentGooVisualOverride != null)
		{
			UnityEngine.Object.Destroy(currentGooVisualOverride.gameObject);
			currentGooVisualOverride = null;
		}
	}

	public override void OffsetEntity(float amount)
	{
		base.OffsetEntity(amount);
		if (!isRecentering)
		{
			StartCoroutine(WaitToHarm());
		}
		Debug.Log("Mass Recentered by " + amount);
		if (setCorruptionHeight)
		{
			FXManager.fxMan.corruptionHeight = -10000f;
		}
		IEnumerator WaitToHarm()
		{
			bool wasActive = active;
			isRecentering = true;
			active = false;
			yield return new WaitForSeconds(1f);
			active = wasActive;
			isRecentering = false;
			FXManager.fxMan.corruptionHeight = -10000f;
		}
	}

	public static float GetHeight()
	{
		if (instance != null)
		{
			if (!instance.active || !instance.canKill)
			{
				return -100000f;
			}
			return instance.transform.position.y;
		}
		return -100000f;
	}
}
