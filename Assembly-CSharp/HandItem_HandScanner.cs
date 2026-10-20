using System.Globalization;
using UnityEngine;

[DefaultExecutionOrder(10)]
public class HandItem_HandScanner : HandItem
{
	public CL_Lamp lamp;

	public SpriteRenderer[] flareSprites;

	private float maxCharge = 20f;

	private float charge = 1f;

	private float chargeRate = 5f;

	public Transform lightPosition;

	private bool inUse;

	public GameObject showOnFlipped;

	private UT_AudioClipHandler clipHandler;

	public GameObject detailPrefab;

	private static GameObject spawnedDetails;

	private bool flipped;

	public override void Initialize(Item i, ENT_Player.Hand h)
	{
		base.Initialize(i, h);
		clipHandler = GetComponent<UT_AudioClipHandler>();
		clipHandler.Initialize();
		if (item.data[0].Contains("charge:"))
		{
			charge = float.Parse(item.data[0].Split(':')[1], NumberStyles.Float, CultureInfo.InvariantCulture);
			maxCharge = float.Parse(item.data[1].Split(':')[1], NumberStyles.Float, CultureInfo.InvariantCulture);
			chargeRate = float.Parse(item.GetFirstDataStringByType("chargerate"), NumberStyles.Float, CultureInfo.InvariantCulture);
		}
		flipped = bool.Parse(item.GetFirstDataStringByType("flipped"));
		anim.SetBool("flipped", flipped);
		if (flipped)
		{
			clipHandler.PlaySound("scanner:flip-light");
		}
		else
		{
			clipHandler.PlaySound("scanner:flip-scan");
		}
		Finish();
		if (spawnedDetails == null && detailPrefab != null)
		{
			spawnedDetails = Object.Instantiate(detailPrefab);
		}
	}

	public override void Use()
	{
		base.Use();
		if (!inUse)
		{
			flipped = !flipped;
			anim.SetBool("flipped", flipped);
			inUse = true;
			if (flipped)
			{
				clipHandler.PlaySound("scanner:flip-light");
			}
			else
			{
				clipHandler.PlaySound("scanner:flip-scan");
			}
		}
	}

	public void Finish()
	{
		if (flipped)
		{
			charge = maxCharge * 0.75f;
		}
		else
		{
			charge = maxCharge * 0.75f;
		}
		showOnFlipped.SetActive(flipped);
		item.data[0] = $"charge:{charge}";
		item.SetFirstDataStringsofType("flipped", flipped.ToString());
		CL_CameraControl.Shake(0.005f);
		inUse = false;
	}

	public override void LateUpdate()
	{
		base.LateUpdate();
		charge = float.Parse(item.data[0].Split(':')[1]);
		if (spawnedDetails != null)
		{
			spawnedDetails.transform.position = base.transform.position;
		}
	}

	public override bool CanDrop(bool pocket = false)
	{
		return true;
	}
}
