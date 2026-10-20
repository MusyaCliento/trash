using UnityEngine;

public class HandItem_Shoot_Spear : HandItem_Shoot
{
	private float currentStrain;

	public SpriteRenderer spearSprite;

	public override void Initialize(Item i, ENT_Player.Hand h)
	{
		base.Initialize(i, h);
	}

	public override void StartShoot()
	{
		float.TryParse(item.GetFirstDataStringByType("strain"), out currentStrain);
		currentStrain = Mathf.Clamp01(currentStrain - 0.2f);
		item.SetFirstDataStringsofType("strain", currentStrain.ToString());
		hand.GetPlayer().ClearGrapple();
		base.StartShoot();
	}

	public override void Update()
	{
		base.Update();
		float.TryParse(item.GetFirstDataStringByType("strain"), out currentStrain);
		spearSprite.material.SetFloat("_StaminaAmount", 1f - currentStrain);
	}
}
