using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandItem_Piton : HandItem
{
	public LayerMask hitMask;

	public GameObject pitonWorldObject;

	private RaycastHit hit;

	public float placeDistance = 2.5f;

	public string[] placementTags;

	public string[] blockTags;

	public float placeOffset = 0.3f;

	private Vector3 hitLocal;

	public bool autograbOnPlaceIfUsing;

	public bool canDamage = true;

	public float damage;

	public LayerMask damageMask;

	public GameObject damageEffect;

	public AudioClip damageAudio;

	public override void OnEnable()
	{
		base.OnEnable();
		used = false;
	}

	public override void Use()
	{
		base.Use();
		if (!used)
		{
			anim.SetTrigger("Use");
			CL_CameraControl.Shake(0.015f);
		}
	}

	public void PitonHit()
	{
		if (canDamage && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hitInfo, placeDistance, damageMask))
		{
			Damageable component = hitInfo.collider.gameObject.GetComponent<Damageable>();
			ObjectTagger component2 = hitInfo.collider.gameObject.GetComponent<ObjectTagger>();
			if (component != null)
			{
				CL_CameraControl.Shake(0.08f);
				Damageable.DamageInfo damageInfo = Damageable.DamageInfo.CreateDamageInfo(damage, "piton", new List<string>(), ENT_Player.playerObject);
				damageInfo.tags.Add("player");
				damageInfo.amount += ENT_Player.playerObject.curBuffs.GetBuff("addStrike");
				component.Damage(damageInfo);
				Object.Instantiate(damageEffect, hitInfo.point, Quaternion.identity);
				if (component2 != null && component2.HasTag("Denizen"))
				{
					CL_GameManager.gMan.FreezeForTime(0.2f, 0.1f);
				}
				AudioManager.PlaySound(damageAudio, hitInfo.point);
			}
		}
		CL_Handhold handhold;
		if (PitonRaycast())
		{
			Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);
			used = true;
			hand.lockHand = true;
			GameObject gameObject = Object.Instantiate(pitonWorldObject, hit.collider.transform.TransformPoint(hitLocal), Quaternion.LookRotation(hit.normal) * Quaternion.Euler(0f, 0f, Random.Range(-30, 30)));
			gameObject.transform.parent = WorldLoader.GetCurrentLevelParentRoot();
			gameObject.AddComponent<UT_SoftParent>().Initialize(hit.collider.transform);
			if (WorldLoader.initialized)
			{
				WorldLoader.instance.GetCurrentLevel().GetLevel().AddPlacedObject(gameObject);
			}
			UpdateStats();
			handhold = gameObject.GetComponent<CL_Handhold>();
			if (handhold != null && !handhold.secure)
			{
				StartCoroutine(SecurePiton());
			}
			hand.lockHand = false;
			CL_CameraControl.Shake(0.04f);
			if (autograbOnPlaceIfUsing && InputManager.GetButton(hand.fireButton).Pressed)
			{
				RemoveItem();
				hand.GrabHold(gameObject.transform, gameObject.transform.position + -gameObject.transform.forward * 0.15f);
			}
		}
		else
		{
			anim.SetTrigger("Fail");
		}
		IEnumerator SecurePiton()
		{
			float addPitonSecure = ENT_Player.playerObject.curBuffs.GetBuff("addPitonSecure");
			yield return null;
			if (addPitonSecure > 0f)
			{
				handhold.HammerIn(addPitonSecure);
			}
		}
	}

	private bool PitonRaycast()
	{
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, placeDistance, hitMask))
		{
			ObjectTagger component = hit.collider.GetComponent<ObjectTagger>();
			hitLocal = hit.collider.transform.InverseTransformPoint(hit.point + hit.normal * placeOffset);
			if (component != null)
			{
				if (placementTags != null && placementTags.Length != 0)
				{
					string[] array = placementTags;
					foreach (string t in array)
					{
						if (!component.HasTag(t))
						{
							return false;
						}
					}
				}
				if (blockTags != null && blockTags.Length != 0)
				{
					string[] array = blockTags;
					foreach (string t2 in array)
					{
						if (component.HasTag(t2))
						{
							return false;
						}
					}
				}
			}
			else if (placementTags != null && placementTags.Length != 0)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public override bool ShowAimCircle()
	{
		if (!useAimCircle)
		{
			return false;
		}
		return PitonRaycast();
	}

	public override RaycastHit GetAimCircleHit()
	{
		return hit;
	}

	public override bool CanDrop(bool pocket = false)
	{
		return !used;
	}
}
