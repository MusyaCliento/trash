using System;
using UnityEngine;

[Serializable]
public class ItemExecutionModule_Grenade : ItemExecutionModule
{
	public bool active = true;

	public float timer = 5f;

	public GameObject explosionAsset;

	public AudioClip beepClip;

	private float beepTimer;

	private FX_RunningLightFlare runningLight;

	public override void Initialize(Item i)
	{
		base.Initialize(i);
		if (bool.TryParse(item.GetFirstDataStringByType("active"), out var result))
		{
			active = result;
		}
		if (float.TryParse(item.GetFirstDataStringByType("timer"), out var result2))
		{
			timer = result2;
		}
		runningLight = item.GetDropObject().GetComponentInChildren<FX_RunningLightFlare>();
		runningLight.onTime = 2f;
		runningLight.offTime = 2f;
	}

	public override void OnDrop()
	{
		base.OnDrop();
	}

	public override void Execute()
	{
		if (item.hasBeenDestroyed)
		{
			return;
		}
		item.SetFirstDataStringsofType("active", active.ToString());
		if (!active)
		{
			runningLight.onTime = 0f;
			runningLight.ResetBlinkTimer();
			return;
		}
		timer -= Time.deltaTime;
		item.SetFirstDataStringsofType("timer", timer.ToString());
		Vector3 position = item.GetDropObject().transform.position;
		if (item.GetHandItem() != null)
		{
			position = item.GetHandItem().transform.position + Vector3.down;
		}
		else if (item.InBag() && !Inventory.IsShowingInventory())
		{
			position = ENT_Player.GetPlayer().transform.position + Vector3.down * 0.25f + -ENT_Player.GetPlayer().transform.forward * 0.25f;
		}
		if (timer <= 0f)
		{
			UnityEngine.Object.Instantiate(explosionAsset, position, item.GetDropObject().transform.rotation);
			item.Destroy();
			return;
		}
		beepTimer -= Time.deltaTime;
		bool flag = false;
		if (beepTimer <= 0f)
		{
			AudioManager.PlaySound(beepClip, position);
			if (timer <= 1f)
			{
				beepTimer = 0.1f;
			}
			else if (timer <= 3f)
			{
				beepTimer = 0.25f;
			}
			else
			{
				beepTimer = 1f;
			}
			flag = true;
		}
		if ((bool)runningLight)
		{
			runningLight.onTime = 2f;
			runningLight.offTime = 2f;
			if (flag)
			{
				runningLight.ResetBlinkTimer();
			}
		}
		base.Execute();
	}

	public FX_RunningLightFlare GetRunningLightFlare()
	{
		return runningLight;
	}

	public void SetActive(bool b)
	{
		active = b;
		item.SetFirstDataStringsofType("active", active.ToString());
	}

	public override ItemExecutionModule GetCopy()
	{
		return new ItemExecutionModule_Grenade
		{
			active = active,
			timer = timer,
			explosionAsset = explosionAsset,
			beepClip = beepClip
		};
	}
}
