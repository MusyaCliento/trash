using UnityEngine;

public class Denizen : AIGameEntity, Blinkable
{
	public int fixedTickRate = 5;

	private int tickCounter;

	private bool tickFrame;

	public bool canBlinkFrag = true;

	public bool canListen;

	internal Listener_Core listener = new Listener_Core();

	internal Collision lastCollision;

	public bool diesInMass = true;

	public int denizenKillScoreValue = 50;

	public override void OnEnable()
	{
		base.OnEnable();
		if (canListen)
		{
			listener.Activate();
			listener.GetPosition = GetThisPosition;
		}
		Vector3 GetThisPosition()
		{
			if (base.transform == null)
			{
				return Vector3.zero;
			}
			return base.transform.position;
		}
	}

	public override void OnDisable()
	{
		base.OnDisable();
		if (canListen)
		{
			listener.Deactivate();
		}
	}

	private void OnDestroy()
	{
		if (canListen)
		{
			listener.Deactivate();
		}
	}

	public override void Start()
	{
		tickCounter = Random.Range(-10, 0);
		Initialize();
		base.Start();
	}

	public virtual void Initialize()
	{
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		tickCounter++;
		if (tickCounter == fixedTickRate)
		{
			tickFrame = true;
			tickCounter = 0;
		}
		else
		{
			tickFrame = false;
		}
	}

	public override void Update()
	{
		base.Update();
		MassDrownCheck();
	}

	public virtual void MassDrownCheck()
	{
		if (!dead && diesInMass && DEN_DeathFloor.instance != null && DEN_DeathFloor.instance.gameObject.activeInHierarchy && DEN_DeathFloor.GetHeight() > base.transform.position.y)
		{
			Kill("", null);
		}
	}

	public bool CanSeeTarget(Transform t, float dist = 10f)
	{
		return sight.CanSeeTarget(base.transform.position, t, dist);
	}

	public override void OnKilledByPlayer(Damageable.DamageInfo damageInfo)
	{
		base.OnKilledByPlayer(damageInfo);
		if (denizenKillScoreValue != 0)
		{
			CL_ScoreManager.sessionScore.AddScore("Kills", "Kills", denizenKillScoreValue, 0f, 1);
			StatManager.sessionStats.UpdateStatistic("Kills", 1, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
		}
		ENT_Player.GetPlayer().OnKillDenizen(this, damageInfo);
	}

	public override void Kill(string type = "", Damageable.DamageInfo info = null)
	{
		base.Kill(type, info);
		CL_GameTracker.AddEventToSession(CL_GameTracker.CreateEvent(base.name, base.gameObject.GetInstanceID().ToString(), objectType, CL_GameTracker.Session.Tick.Event.EventType.kill, base.transform.position));
	}

	public bool IsTickFrame()
	{
		return tickFrame;
	}

	public override void SessionUpdate()
	{
		base.SessionUpdate();
	}

	public virtual void OnBlinkStart()
	{
	}

	public virtual void OnBlinkEnd()
	{
	}

	public virtual void OnBlinkTeleport()
	{
	}

	public virtual bool CanBlinkFrag()
	{
		return canBlinkFrag;
	}

	public virtual GameObject GetBlinkableGameObject()
	{
		return base.gameObject;
	}

	internal virtual void AttackCheck()
	{
	}

	internal virtual void OnAttackHit(GameEntity hitEntity, bool hasKilled)
	{
	}

	internal virtual void OnCollisionEnter(Collision collision)
	{
		lastCollision = collision;
	}

	public virtual DenizenMovementModule GetMovementModule()
	{
		return null;
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		sight.OnDrawGizmos(base.transform);
	}
}
