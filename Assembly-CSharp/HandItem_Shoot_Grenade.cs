using UnityEngine;

public class HandItem_Shoot_Grenade : HandItem_Shoot
{
	private ItemExecutionModule_Grenade grenadeModule;

	public float grenadeBoostStartThreshhold = 1f;

	public float grenadeBoostThreshhold = 0.3f;

	public SpriteRenderer flare;

	public override void Initialize(Item i, ENT_Player.Hand h)
	{
		base.Initialize(i, h);
		foreach (ItemExecutionModule executionModule in i.executionModules)
		{
			if (executionModule is ItemExecutionModule_Grenade)
			{
				grenadeModule = executionModule as ItemExecutionModule_Grenade;
				break;
			}
		}
	}

	public override void Use()
	{
		base.Use();
		grenadeModule.SetActive(b: true);
	}

	public override void StartShoot()
	{
		base.StartShoot();
		grenadeModule.SetActive(b: false);
	}

	public override void Update()
	{
		base.Update();
		if (grenadeModule != null)
		{
			grenadeModule.GetRunningLightFlare().UpdateBlinkState();
			flare.color = Color.Lerp(flare.color, grenadeModule.GetRunningLightFlare().GetBlinkState() ? Color.red : Color.clear, Time.deltaTime * 16f);
		}
	}

	internal override Projectile CreateProjectile(RaycastHit hit, Vector3 startPos)
	{
		grenadeModule.SetActive(b: true);
		float num = Vector3.Dot(ENT_Player.GetPlayer().cam.transform.forward, Vector3.up);
		if (grenadeModule.timer < grenadeBoostStartThreshhold)
		{
			if (num < -0.75f)
			{
				grenadeModule.timer = grenadeBoostThreshhold;
			}
			else if (grenadeModule.timer < 0.5f)
			{
				grenadeModule.timer = 0.5f;
			}
			else
			{
				grenadeModule.timer += 0.2f;
			}
		}
		return base.CreateProjectile(hit, startPos);
	}
}
