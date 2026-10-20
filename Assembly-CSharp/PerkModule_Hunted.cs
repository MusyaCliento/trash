using UnityEngine;

public class PerkModule_Hunted : PerkModule
{
	public Denizen huntEntity;

	private Denizen spawnedEntity;

	public Vector3 spawnOffset;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
	}

	public void RespawnEntity()
	{
		if (spawnedEntity != null)
		{
			Object.Destroy(spawnedEntity.gameObject);
		}
		spawnedEntity = Object.Instantiate(huntEntity, ENT_Player.GetPlayer().transform.position + spawnOffset, Quaternion.identity);
	}

	public override void Update()
	{
		if (spawnedEntity == null || spawnedEntity.IsDead())
		{
			RespawnEntity();
		}
		base.Update();
	}
}
