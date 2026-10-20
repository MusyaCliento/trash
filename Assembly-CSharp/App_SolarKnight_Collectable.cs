using UnityEngine;

public class App_SolarKnight_Collectable : App_SolarKnight_Entity
{
	public enum CollectableType
	{
		Score = 0,
		Powerup = 1
	}

	public float grabRadius = 1.5f;

	public CollectableType collectableType;

	public int scoreValue = 10;

	public override void FixedUpdate()
	{
		float statBuff = App_SolarKnight_World.instance.GetPlayer().GetStatBuff("addTractor");
		Vector3 normalized = (App_SolarKnight_World.instance.GetPlayer().transform.localPosition - base.transform.localPosition).normalized;
		velocity = Vector3.Lerp(velocity, normalized * statBuff, App_SolarKnight_World.gameFixedDeltaTime * statBuff);
		base.FixedUpdate();
	}

	public override void PhysicsCheck()
	{
		float num = Vector3.Distance(base.transform.position, App_SolarKnight_World.instance.GetPlayer().transform.position);
		if ((bool)App_SolarKnight_World.instance.GetPlayer() && num < grabRadius + App_SolarKnight_World.instance.GetPlayer().GetStatBuff("addScoop"))
		{
			Collect();
			Kill();
		}
	}

	public virtual void Collect()
	{
		if (collectableType == CollectableType.Score)
		{
			App_SolarKnight_World.instance.AddScore(scoreValue);
		}
	}
}
