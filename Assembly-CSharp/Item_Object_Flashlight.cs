using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Item_Object_Flashlight : Item_Object
{
	public CL_Lamp lamp;

	private float charge;

	private float maxCharge;

	private HandItem_Flashlight flashlightHand;

	public AnimationCurve flashlightBrightnessCurve;

	public float chargeLossRate = 1f;

	public bool useHandFlashlight = true;

	public override void Start()
	{
		base.Start();
		maxCharge = 30f;
		float.TryParse(itemData.GetFirstDataStringByType("maxcharge"), NumberStyles.Float, CultureInfo.InvariantCulture, out maxCharge);
	}

	public override void Execute(Inventory inv)
	{
		base.Execute(inv);
		if (maxCharge == 0f)
		{
			float.TryParse(itemData.GetFirstDataStringByType("maxcharge"), NumberStyles.Float, CultureInfo.InvariantCulture, out maxCharge);
		}
		float num = 1f;
		if (itemData.InInventory())
		{
			if (itemData.GetHandItem() != null)
			{
				_ = lamp.gameObject.activeSelf;
				if (useHandFlashlight)
				{
					if (flashlightHand == null)
					{
						flashlightHand = (HandItem_Flashlight)itemData.GetHandItem();
					}
					else
					{
						lamp.transform.parent = null;
						lamp.transform.position = flashlightHand.lightPosition.position;
						lamp.transform.rotation = Quaternion.Lerp(lamp.transform.rotation, flashlightHand.lightPosition.rotation, Time.deltaTime * 25f);
						lamp.MoveToFrontOfQueue();
					}
				}
				else
				{
					lamp.transform.parent = null;
					lamp.transform.position = ENT_Player.GetPlayer().transform.position;
					lamp.transform.rotation = Quaternion.Lerp(lamp.transform.rotation, ENT_Player.GetPlayer().transform.rotation, Time.deltaTime * 25f);
					lamp.MoveToFrontOfQueue();
				}
			}
			else
			{
				if (!lamp.gameObject.activeSelf)
				{
					lamp.gameObject.SetActive(value: true);
				}
				lamp.transform.parent = null;
				lamp.transform.position = Camera.main.transform.position;
				lamp.transform.rotation = Quaternion.Lerp(lamp.transform.rotation, Camera.main.transform.rotation, Time.deltaTime * 8f);
				lamp.MoveToFrontOfQueue();
				num = 0.96f;
			}
		}
		else
		{
			if (!lamp.gameObject.activeSelf)
			{
				lamp.gameObject.SetActive(value: true);
			}
			lamp.transform.parent = base.transform.GetChild(0);
			lamp.transform.localPosition = Vector3.zero;
			lamp.transform.localRotation = Quaternion.identity;
		}
		float.TryParse(itemData.GetFirstDataStringByType("charge"), NumberStyles.Float, CultureInfo.InvariantCulture, out charge);
		if (charge > 0f && chargeLossRate > 0f)
		{
			charge -= Time.deltaTime * chargeLossRate;
			if (ENT_Player.GetPlayer() != null)
			{
				float buff = ENT_Player.GetPlayer().curBuffs.GetBuff("drainLight");
				charge -= Time.deltaTime * buff;
			}
		}
		if (itemData.data == null || itemData.data.Count == 0)
		{
			itemData.data = new List<string>(1);
		}
		itemData.data[0] = "charge:" + charge.ToString(CultureInfo.InvariantCulture);
		if (maxCharge > 0f)
		{
			lamp.intensity = flashlightBrightnessCurve.Evaluate(charge / maxCharge) * 1.22f * num;
			if (charge < maxCharge / 2f)
			{
				lamp.animAmplitude = Mathf.Lerp(2f, 0f, charge / (maxCharge / 2f));
				lamp.animSpeed = Mathf.Lerp(5f, 1f, charge / (maxCharge / 2f));
			}
			else
			{
				lamp.animAmplitude = 0f;
				lamp.animSpeed = 0f;
			}
		}
		else
		{
			lamp.animAmplitude = 0f;
			lamp.animSpeed = 0f;
			lamp.intensity = 0f;
		}
	}

	private void OnDestroy()
	{
		if (lamp != null)
		{
			Object.Destroy(lamp.gameObject);
		}
	}
}
