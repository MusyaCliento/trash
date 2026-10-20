using UnityEngine;

public class DenizenAttackModule_Barnacle : DenizenAttackModule
{
	public DEN_Barnacle barnacle;

	private bool attacking;

	public float attackRate = 5f;

	private float attackTime;

	[Tooltip("Sound played when the attack begins.")]
	public string attackSoundID = "denizen:attack-start";

	public override void AttackCheck(GameEntity targetEntity)
	{
		base.AttackCheck(targetEntity);
		if (!(attackTime + attackRate > Time.time))
		{
			if (Vector3.Angle(targetEntity.transform.position - denizen.transform.position, denizen.transform.forward) < 70f)
			{
				Debug.Log("Barnacle attack check passed, attacking!");
				barnacle.ReachTongues(targetEntity.transform);
				denizen.clipHandler?.PlaySound(attackSoundID);
				attackTime = Time.time;
			}
			else
			{
				Debug.Log("Barnacle attack check failed angle check. " + Vector3.Angle(targetEntity.transform.position - denizen.transform.position, denizen.transform.forward));
			}
		}
	}
}
