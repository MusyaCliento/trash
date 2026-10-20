using UnityEngine;

public class ItemExecutionModule_Lamp : ItemExecutionModule
{
	public CL_Lamp lampObject;

	public bool showWhenInHand = true;

	public bool showWhenInBag = true;

	public bool showWhenOutsideInventory = true;

	public float rotateRate = 5f;

	public override void Initialize(Item i)
	{
		base.Initialize(i);
		if (lampObject != null)
		{
			lampObject.transform.parent = null;
		}
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		if (lampObject != null)
		{
			Object.Destroy(lampObject.gameObject);
		}
	}

	public override ItemExecutionModule GetCopy()
	{
		return new ItemExecutionModule_Lamp
		{
			rotateRate = rotateRate,
			showWhenInHand = showWhenInHand,
			showWhenInBag = showWhenInBag,
			showWhenOutsideInventory = showWhenOutsideInventory
		};
	}

	public override void Execute()
	{
		base.Execute();
		if (lampObject == null)
		{
			if (item.GetDropObject() != null)
			{
				lampObject = item.GetDropObject().GetComponentInChildren<CL_Lamp>();
				if (lampObject != null)
				{
					lampObject.transform.parent = null;
				}
			}
			return;
		}
		if (ENT_Player.GetPlayer() != null)
		{
			float buff = ENT_Player.GetPlayer().curBuffs.GetBuff("dimlight");
			lampObject.SetIntensityMultiplier(Mathf.Max(1f - buff, 0f));
		}
		if (showWhenInBag && item.InBag())
		{
			if (!lampObject.gameObject.activeSelf)
			{
				lampObject.gameObject.SetActive(value: true);
			}
			lampObject.transform.position = ENT_Player.GetPlayer().camRoot.transform.position;
			lampObject.transform.rotation = Quaternion.Lerp(lampObject.transform.rotation, ENT_Player.GetPlayer().camTransform.transform.rotation, Time.deltaTime * rotateRate);
		}
		else if (showWhenInHand && item.InHand())
		{
			if (!lampObject.gameObject.activeSelf)
			{
				lampObject.gameObject.SetActive(value: true);
			}
			lampObject.transform.position = ENT_Player.GetPlayer().camRoot.transform.position;
			lampObject.transform.rotation = Quaternion.Lerp(lampObject.transform.rotation, ENT_Player.GetPlayer().camTransform.transform.rotation, Time.deltaTime * rotateRate * 5f);
		}
		else if (showWhenOutsideInventory && !item.InInventory())
		{
			if (!lampObject.gameObject.activeSelf)
			{
				lampObject.gameObject.SetActive(value: true);
			}
			lampObject.transform.position = item.GetDropObject().transform.position;
			lampObject.transform.rotation = item.GetDropObject().transform.rotation;
		}
		else if (lampObject.gameObject.activeSelf)
		{
			lampObject.gameObject.SetActive(value: false);
		}
	}
}
