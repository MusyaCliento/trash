using System;
using UnityEngine;

[Serializable]
public class SessionEventModule_FXZone : SessionEventModule
{
	public FXManager.FXData fxData;

	public float blendTarget;

	private float blend;

	public byte priority = 10;

	public override void Update()
	{
		base.Update();
		blend = Mathf.Lerp(blend, blendTarget, 0.5f * Time.deltaTime);
		DataLerp();
	}

	private void DataLerp()
	{
		FXManager.FXZoneStore fXZoneStore = new FXManager.FXZoneStore();
		fXZoneStore.blend = blend;
		fXZoneStore.priority = priority;
		fXZoneStore.data = fxData;
		FXManager.fxZones.Enqueue(fXZoneStore, priority);
	}

	public override void SendMessage(string m)
	{
		base.SendMessage(m);
		if (m == "fadein")
		{
			blendTarget = 1f;
		}
		else if (m == "fadeout")
		{
			blendTarget = 0f;
		}
	}
}
