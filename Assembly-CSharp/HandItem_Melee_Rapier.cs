using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandItem_Melee_Rapier : HandItem_Melee
{
	public float dashForce;

	public float swimmingDashForceMult = 3f;

	public float skateForce;

	public float pogoForce = 3f;

	public float minimumPogoVelocity = 1f;

	public GameObject pogoHitEffect;

	public float pogoDistance = 2f;

	public float pogoTime = 3f;

	public float pogoShake = 0.1f;

	public float pogoSlowTime = 0.1f;

	private float dashTime;

	private Vector3 dashDirection;

	private float pogoWait;

	public UnityEvent dashReadyEvent;

	public UnityEvent dashStartEvent;

	public UnityEvent dashHitEvent;

	public UnityEvent dashStopEvent;

	public UnityEvent pogoEvent;

	public float strainOnCharge = 2f;

	private float currentStrain;

	private float maxStrain;

	public List<SpriteRenderer> spriteRenderers;

	public LayerMask pogoMask;

	private float chargeEffect;

	private bool drained;

	public float drainThreshhold = 1f;

	public string pogoAudioName = "melee:pogo";

	public string skateAudioName = "melee:skate";

	private static float lastDashTime;

	public override void Start()
	{
		base.Start();
		float.TryParse(item.GetFirstDataStringByType("strain"), out currentStrain);
		float.TryParse(item.GetFirstDataStringByType("maxStrain"), out maxStrain);
		bool.TryParse(item.GetFirstDataStringByType("drained"), out drained);
		if (anim != null)
		{
			anim.Update(0f);
		}
	}

	public override void Update()
	{
		base.Update();
		dashTime -= Time.deltaTime;
		pogoWait -= Time.deltaTime;
		if (dashTime > 0f && hand.GetPlayer().cCon.velocity.magnitude > minimumPogoVelocity && pogoWait <= 0f)
		{
			PogoCheck(hand.GetPlayer().cCon.velocity.normalized);
		}
		else
		{
			dashTime = 0f;
		}
		foreach (SpriteRenderer spriteRenderer in spriteRenderers)
		{
			if (!(spriteRenderer == null))
			{
				spriteRenderer.color = Color.Lerp(Color.red, Color.white, (float)((!drained) ? 1 : 0) + (1f - Mathf.Clamp01(Mathf.Sin(Time.time * 10f))));
				spriteRenderer.material.SetFloat("_Shimmer", 500f * chargeEffect);
			}
		}
		if (hasChargedEnough)
		{
			chargeEffect = Mathf.Lerp(chargeEffect, 1f, Time.deltaTime * 2f);
		}
		else
		{
			chargeEffect = Mathf.Lerp(chargeEffect, 0f, Time.deltaTime * 2f);
		}
		float.TryParse(item.GetFirstDataStringByType("strain"), out currentStrain);
		if (drained && currentStrain > drainThreshhold)
		{
			drained = false;
			item.SetFirstDataStringsofType("drained", "false");
		}
	}

	public override void OnChargeReady()
	{
		base.OnChargeReady();
		dashReadyEvent.Invoke();
	}

	public override void OnChargeStop()
	{
		base.OnChargeStop();
		dashStopEvent.Invoke();
	}

	public override void OnChargeAttack()
	{
		base.OnChargeAttack();
		dashStopEvent.Invoke();
		dashTime = pogoTime;
		dashStartEvent.Invoke();
		hand.GetPlayer().FOVShock(15f, slow: true);
		pogoWait = 0f;
		float num = dashForce * (float)((!drained) ? 1 : 0);
		num *= (hand.GetPlayer().IsSwimming() ? swimmingDashForceMult : 1f);
		Vector3 a = hand.GetPlayer().cam.transform.forward * num;
		a = Vector3.Scale(a, new Vector3(0.6f, 1f, 0.6f));
		if (ENT_Player.GetPlayer().IsSwimming())
		{
			a *= 3f;
		}
		hand.GetPlayer().AddForce(a);
		PogoCheck(hand.GetPlayer().cam.transform.forward);
		SetStrain(currentStrain - strainOnCharge);
	}

	public bool PogoCheck(Vector3 direction)
	{
		if (Vector3.Dot(direction, hand.GetPlayer().cam.transform.forward) > 0.1f && Physics.SphereCast(hand.GetPlayer().cam.transform.position, 0.2f, hand.GetPlayer().cam.transform.forward, out var hitInfo, pogoDistance, pogoMask))
		{
			Vector3 vector = hit.normal;
			for (int i = 0; i < 8; i++)
			{
				if (Physics.Raycast(hand.GetPlayer().cam.transform.position, hand.GetPlayer().cam.transform.forward + Random.onUnitSphere * 0.05f, out var hitInfo2, pogoDistance + 0.25f, pogoMask))
				{
					vector = Vector3.Lerp(vector, hitInfo2.normal, 0.125f);
				}
			}
			HitCast();
			bool flag = hitInfo.collider.GetComponent<Hitbox>() != null;
			hit = hitInfo;
			hitTagger = hit.collider.GetComponent<ObjectTagger>();
			hasHit = true;
			isChargedAttack = true;
			if (!flag && hitTagger != null)
			{
				flag = hitTagger.HasTag("Creature");
			}
			Hit();
			isCharging = false;
			anim.SetBool("Charging", value: false);
			anim.SetBool("Charged", value: false);
			used = false;
			hasChargedEnough = false;
			isChargedAttack = false;
			Vector3 vector2 = vector;
			float num = Vector3.Dot(vector2, Vector3.up);
			float num2 = Vector3.Dot(vector2, hand.GetPlayer().GetVelocity());
			Vector3.Dot(vector2, hand.GetPlayer().cam.transform.forward);
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = true;
			if (Vector3.Dot(Vector3.up, hand.GetPlayer().cam.transform.forward) > 0f && LayerMask.LayerToName(hit.collider.gameObject.layer).Contains("Interactable"))
			{
				flag4 = false;
			}
			if (flag)
			{
				flag3 = true;
			}
			if (flag4)
			{
				if (!flag)
				{
					HitFreeze(pogoSlowTime, 0.01f, 0.3f);
					if (num < 0.6f && num > -0.6f && !flag3 && Vector3.Dot(vector2, hand.GetPlayer().cam.transform.up) > 0.93f)
					{
						aud.PlaySound(skateAudioName);
						HitFreeze(0.15f, 0.01f, 0.3f);
						flag2 = true;
					}
					if ((double)num > 0.25 || flag3)
					{
						vector2 = Vector3.up;
						if (num2 < 0f && (lastDashTime > Time.time || Time.time - lastDashTime > 0.1f))
						{
							hand.GetPlayer().ReflectPlayerVelocity(vector2);
						}
						if (lastDashTime > Time.time || Time.time - lastDashTime > 0.1f)
						{
							hand.GetPlayer().ScaleVelocity(new Vector3(1.5f, 1.1f, 1.5f));
						}
						else
						{
							hand.GetPlayer().AddForce(vector2 * pogoForce * 0.5f);
						}
						if (drained)
						{
							hand.GetPlayer().AddForce(vector2 * pogoForce * 0.3f);
						}
						else
						{
							hand.GetPlayer().AddForce(vector2 * pogoForce);
						}
					}
					else
					{
						if (lastDashTime > Time.time || Time.time - lastDashTime > 0.1f)
						{
							if (num2 < 0f)
							{
								hand.GetPlayer().ReflectPlayerVelocity(vector2);
							}
							hand.GetPlayer().ScaleVelocityMagnitude(1.5f);
						}
						if (flag2)
						{
							hand.GetPlayer().AddForce(hand.GetPlayer().cam.transform.forward * skateForce);
							hand.GetPlayer().SetDirectionalForce(vector2 * 0.01f);
						}
					}
				}
				else
				{
					HitFreeze(0.2f, 0.01f, 0.1f);
					hand.GetPlayer().ClearGrapple();
					hand.GetPlayer().SetDirectionalForce(Vector3.up * pogoForce);
				}
				aud.PlaySound(pogoAudioName);
			}
			Object.Instantiate(pogoHitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
			if (!flag2)
			{
				hand.GetPlayer().DropHang(0.2f);
			}
			anim.SetTrigger("Bounce");
			CL_CameraControl.Shake(pogoShake);
			dashTime = 0f;
			pogoEvent.Invoke();
			lastDashTime = Time.time;
			return true;
		}
		return false;
	}

	public void SetStrain(float s)
	{
		currentStrain = Mathf.Clamp(s, 0f, maxStrain);
		if (currentStrain <= 0f)
		{
			drained = true;
			item.SetFirstDataStringsofType("drained", "true");
		}
		item.SetFirstDataStringsofType("strain", currentStrain.ToString());
	}
}
