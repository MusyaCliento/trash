using System.Globalization;
using UnityEngine;

public class HandItem_Flashlight : HandItem
{
	public CL_Lamp lamp;

	public SpriteRenderer[] flareSprites;

	private float maxCharge = 20f;

	private float charge = 1f;

	private float chargeRate = 5f;

	public Transform lightPosition;

	private bool inUse;

	public override void Initialize(Item i, ENT_Player.Hand h)
	{
		base.Initialize(i, h);
		if (item.data[0].Contains("charge:"))
		{
			charge = float.Parse(item.data[0].Split(':')[1], NumberStyles.Float, CultureInfo.InvariantCulture);
			maxCharge = float.Parse(item.data[1].Split(':')[1], NumberStyles.Float, CultureInfo.InvariantCulture);
			chargeRate = float.Parse(item.GetFirstDataStringByType("chargerate"), NumberStyles.Float, CultureInfo.InvariantCulture);
		}
	}

	public override void Use()
	{
		base.Use();
		if (!inUse)
		{
			anim.SetTrigger("pump");
			inUse = true;
		}
	}

	public void Finish()
	{
		charge = Mathf.Clamp(chargeRate + charge, maxCharge / 2f, maxCharge);
		item.data[0] = $"charge:{charge}";
		CL_CameraControl.Shake(0.02f);
		inUse = false;
	}

	public override void Update()
	{
		base.Update();
		charge = float.Parse(item.data[0].Split(':')[1]);
		SpriteRenderer[] array = flareSprites;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].color = new Color(1f, 1f, 1f, charge / maxCharge);
		}
	}

	public override bool CanDrop(bool pocket = false)
	{
		return true;
	}
}
