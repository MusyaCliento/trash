using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Item_Object_Rewind : Item_Object
{
	internal class PlayerTimestream
	{
		public Vector3 pos;

		public Vector3 lastPos;

		public Vector3 rotation;
	}

	private float timer;

	private float maxTime;

	private int maxTimestreamBuffer;

	private bool rewinding;

	private float curRewindTime;

	public GameObject rewindEffectRoot;

	public ParticleSystem rewindEffectParticles;

	public FXManager.FXData rewindFX;

	private float rewindEffectLerp;

	public LayerMask rewindWorldMask;

	private bool timeLocked;

	private float cooldown;

	private float overcharge;

	private bool initialized;

	private List<PlayerTimestream> timestream;

	public override void Start()
	{
		maxTime = 30f;
		float.TryParse(itemData.GetFirstDataStringByType("maxtime"), NumberStyles.Float, CultureInfo.InvariantCulture, out maxTime);
		maxTimestreamBuffer = Mathf.RoundToInt(maxTime) * 25;
		timestream = new List<PlayerTimestream>();
		rewindEffectParticles.Stop();
		initialized = true;
		ENT_Player player = ENT_Player.GetPlayer();
		player._OnKill = (Action)Delegate.Combine(player._OnKill, new Action(OnDie));
		base.Start();
	}

	public void SetTimer(float f)
	{
		timer = f;
		itemData.SetFirstDataStringsofType("timer", timer.ToString(CultureInfo.InvariantCulture));
	}

	public float GetTimer()
	{
		float result = timer;
		float.TryParse(itemData.GetFirstDataStringByType("timer"), NumberStyles.Float, CultureInfo.InvariantCulture, out result);
		return result;
	}

	public void OnDie()
	{
		if (ENT_Player.playerObject.dead && GetTimer() < GetMaxTime() / 3f)
		{
			SetTimer(GetMaxTime() / 3f);
		}
	}

	public float GetMaxTime()
	{
		if (maxTime == 0f)
		{
			float.TryParse(itemData.GetFirstDataStringByType("maxtime"), NumberStyles.Float, CultureInfo.InvariantCulture, out maxTime);
		}
		return maxTime;
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(rewindEffectRoot);
		if (initialized && ENT_Player.GetPlayer() != null)
		{
			ENT_Player player = ENT_Player.GetPlayer();
			player._OnKill = (Action)Delegate.Remove(player._OnKill, new Action(OnDie));
		}
	}

	public void SetRewinding(bool b)
	{
		rewinding = b;
		if (rewinding)
		{
			rewindEffectParticles.Play();
			overcharge += 2f;
		}
		else
		{
			rewindEffectParticles.Stop();
		}
	}

	public override void Execute(Inventory inv)
	{
		base.Execute(inv);
		if (cooldown > 0f)
		{
			cooldown -= Time.deltaTime;
			timestream?.Clear();
			return;
		}
		if (maxTime == 0f)
		{
			float.TryParse(itemData.GetFirstDataStringByType("maxtime"), NumberStyles.Float, CultureInfo.InvariantCulture, out maxTime);
		}
		if (itemData.InInventory())
		{
			rewindEffectRoot.transform.parent = null;
			rewindEffectRoot.transform.position = ENT_Player.playerObject.transform.position;
		}
		if (itemData.data == null || itemData.data.Count == 0)
		{
			itemData.data = new List<string>(1);
		}
		if (rewindEffectLerp > 0f)
		{
			FXManager.FXZoneStore fXZoneStore = new FXManager.FXZoneStore();
			fXZoneStore.blend = rewindEffectLerp;
			fXZoneStore.priority = 20;
			fXZoneStore.data = rewindFX;
			if (!CanRewind())
			{
				fXZoneStore.data.hsv = new Vector3(0f, 0f, 1f);
				fXZoneStore.data.dustMult = 50f;
			}
			FXManager.fxZones.Enqueue(fXZoneStore, 15);
		}
		if (rewinding)
		{
			rewindEffectLerp = Mathf.Lerp(rewindEffectLerp, 1f, Time.deltaTime);
			if (timestream.Count != 0)
			{
				List<PlayerTimestream> list = timestream;
				PlayerTimestream playerTimestream = list[list.Count - 1];
				ENT_Player.playerObject.SetPlayerRotation(Vector3.Lerp(ENT_Player.playerObject.GetCurrentPlayerRotation(), playerTimestream.rotation, Time.deltaTime * 0.3f));
				CL_CameraControl.Shake(0.035f * Time.deltaTime);
				ENT_Player.playerObject.SetCrouched(v: true);
			}
		}
		else
		{
			rewindEffectLerp = Mathf.Lerp(rewindEffectLerp, 0f, Time.deltaTime);
		}
	}

	public override void FixedExecute(Inventory inv)
	{
		overcharge = Mathf.Max(overcharge - Time.fixedDeltaTime, 0f);
		if (cooldown > 0f)
		{
			return;
		}
		if (timestream == null)
		{
			timestream = new List<PlayerTimestream>();
		}
		if (maxTimestreamBuffer == 0)
		{
			maxTimestreamBuffer = Mathf.RoundToInt(maxTime) * 25;
		}
		if (!rewinding)
		{
			curRewindTime = 0f;
		}
		if (rewinding)
		{
			ENT_Player.playerObject.ClearGrapple();
			if (timestream.Count == 0)
			{
				ENT_Player.playerObject.MoveTo(ENT_Player.playerObject.transform.position, Time.fixedDeltaTime);
				curRewindTime += Time.fixedDeltaTime * 0.2f;
				return;
			}
			List<PlayerTimestream> list = timestream;
			PlayerTimestream playerTimestream = list[list.Count - 1];
			Vector3 vector = playerTimestream.pos - ENT_Player.playerObject.transform.position;
			Physics.queriesHitTriggers = false;
			if (Physics.SphereCast(ENT_Player.playerObject.GetControllerPosition(), ENT_Player.playerObject.cCon.radius * 0.5f, vector.normalized, out var _, vector.magnitude + 0.3f, rewindWorldMask))
			{
				timestream.Clear();
				Physics.queriesHitTriggers = true;
				return;
			}
			Physics.queriesHitTriggers = true;
			ENT_Player.playerObject.MoveTo(playerTimestream.pos, Time.fixedDeltaTime, 14f / (1f + overcharge));
			curRewindTime += Time.fixedDeltaTime;
			timestream.RemoveAt(timestream.Count - 1);
		}
		else if (CL_GameManager.fixedFrameCounter % 2 == 0)
		{
			PlayerTimestream playerTimestream2 = new PlayerTimestream();
			playerTimestream2.pos = ENT_Player.playerObject.transform.position + Vector3.up * 1f;
			playerTimestream2.rotation = ENT_Player.playerObject.GetCurrentPlayerRotation();
			if (timestream.Count > 0)
			{
				List<PlayerTimestream> list2 = timestream;
				playerTimestream2.lastPos = list2[list2.Count - 1].pos;
			}
			else
			{
				playerTimestream2.lastPos = playerTimestream2.pos;
			}
			timestream.Add(playerTimestream2);
			if (timestream.Count > maxTimestreamBuffer)
			{
				timestream.RemoveAt(0);
			}
		}
	}

	public bool CanRewind()
	{
		if (timestream == null || timestream.Count == 0)
		{
			return false;
		}
		return true;
	}

	internal void SetCooldown(float v)
	{
		cooldown = v;
	}

	public float GetCooldown()
	{
		return cooldown;
	}
}
