using UnityEngine;

public class App_SolarKnight_Station : App_SolarKnight_Entity
{
	public float dockRadius = 1.5f;

	public float centeringForce = 5f;

	public float stayTime = 10f;

	private float stayTimer;

	private bool hasDocked;

	private void Start()
	{
		stayTimer = stayTime;
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		App_SolarKnight_World.instance.PauseGameTime();
		if (stayTimer > 0f)
		{
			stayTimer -= App_SolarKnight_World.gameFixedDeltaTime;
		}
		if (stayTimer > 0f)
		{
			AddVelocity(base.transform.localPosition.normalized * (0f - centeringForce) * App_SolarKnight_World.gameFixedDeltaTime);
			return;
		}
		AddVelocity(base.transform.localPosition.normalized * centeringForce * App_SolarKnight_World.gameFixedDeltaTime);
		if (App_SolarKnight_World.instance.IsInBoundaryZone(base.transform.localPosition))
		{
			App_SolarKnight_World.instance.ResumeGameTime();
			Kill();
		}
	}

	public override void PhysicsCheck()
	{
		float num = Vector3.Distance(base.transform.position, App_SolarKnight_World.instance.GetPlayer().transform.position);
		if (!hasDocked && num < dockRadius)
		{
			hasDocked = true;
			App_SolarKnight_World.instance.GetApp().ShowUpgradeMenu();
		}
	}
}
