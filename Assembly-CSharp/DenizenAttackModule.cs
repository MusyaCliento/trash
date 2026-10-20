using UnityEngine;

public class DenizenAttackModule
{
	internal Denizen denizen;

	public virtual void Initialize(Denizen denizen)
	{
		this.denizen = denizen;
	}

	public virtual void AttackCheck(GameEntity targetEntity)
	{
	}

	public virtual void Attack(GameEntity targetEntity, string attackID = "")
	{
	}

	public virtual void StopAllAttacks()
	{
	}

	public virtual void StopAttack(string id)
	{
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
	}

	public virtual bool IsAttacking()
	{
		return false;
	}

	public virtual bool CanAttack()
	{
		return true;
	}

	public virtual void StartAttackEvent(string eventName)
	{
	}

	public virtual void DrawGizmos(Transform entityTransform)
	{
	}

	public virtual void RecieveCommand(string message)
	{
	}
}
