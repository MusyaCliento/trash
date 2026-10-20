using System.Collections;
using UnityEngine;

public class DEN_Ravelin : DEN_BasicDenizen
{
	private Coroutine quickSwivelCoroutine;

	private bool isProtecting;

	public string animWeakpointHurtTrigger = "Hurt";

	private bool isStunned;

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (isProtecting)
		{
			info.amount /= 2f;
		}
		if (quickSwivelCoroutine != null)
		{
			StopCoroutine(quickSwivelCoroutine);
		}
		quickSwivelCoroutine = StartCoroutine(QuickSwivel());
		if (info.HasTag("weakpoint") || info.amount >= 2f)
		{
			animator.SetTrigger(animWeakpointHurtTrigger);
		}
		return base.Damage(info);
		IEnumerator QuickSwivel()
		{
			isProtecting = true;
			animator.SetBool("OpenFlaps", value: false);
			movementModule.SetSpeedMult(0f);
			yield return new WaitForSeconds(1f);
			movementModule.SetSpeedMult(5f);
			yield return new WaitForSeconds(3f);
			isProtecting = false;
			animator.SetBool("OpenFlaps", value: true);
			movementModule.SetSpeedMult(1f);
		}
	}

	public void Stun()
	{
		if (quickSwivelCoroutine != null)
		{
			StopCoroutine(quickSwivelCoroutine);
		}
	}
}
