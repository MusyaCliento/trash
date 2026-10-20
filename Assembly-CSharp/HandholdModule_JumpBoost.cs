using System.Collections;
using UnityEngine;

public class HandholdModule_JumpBoost : HandholdModule
{
	public float jumpBoost;

	[Range(0f, 1f)]
	public float boostInLookDir;

	public bool doubleHandBoost;

	public float fovAdjust = 10f;

	public override void OnJump(ENT_Player p, ENT_Player.Hand hand, bool hasJumped)
	{
		base.OnJump(p, hand);
		Vector3 boostVel;
		if (!hasJumped || doubleHandBoost)
		{
			boostVel = Vector3.Lerp(Vector3.up, p.camTransform.transform.forward, boostInLookDir);
			boostVel *= jumpBoost;
			p.StartCoroutine(WaitToBoost());
			p.FOVShock(fovAdjust, slow: true);
		}
		IEnumerator WaitToBoost()
		{
			yield return null;
			p.AddForce(boostVel);
		}
	}
}
