using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile_ReturnRebar : Projectile
{
	public bool returning;

	private bool hasHitSurface;

	public float returnSpeed = 10f;

	public float returnRotate = 2f;

	public float returnHitForce = 1f;

	public float returnHitUpForce = 1f;

	public Item_Object returnItem;

	public GameObject recoveryRootObject;

	public GameObject recoveryPrimeRootObject;

	public GameObject hitRootObject;

	public UnityEvent eventOnHit;

	public UnityEvent eventOnReturn;

	public Sprite interactSprite;

	public List<AudioClip> recallSound;

	public List<AudioClip> recoverySound;

	public AudioSource loopAudio;

	private int returningToHand;

	private UT_SoftParent softParent;

	private static bool hasBeenGrabbedThisFrame;

	private float currentStrain = 1f;

	private void Awake()
	{
		softParent = GetComponent<UT_SoftParent>();
		UT_SoftParent uT_SoftParent = softParent;
		uT_SoftParent._OnLoseParent = (Action)Delegate.Combine(uT_SoftParent._OnLoseParent, new Action(StartReturn));
	}

	public override void Update()
	{
		if (!CL_GameManager.gMan.isPaused)
		{
			if (sourceItem != null)
			{
				float.TryParse(sourceItem.GetFirstDataStringByType("strain"), out currentStrain);
			}
			ProjectilePhysics();
			ReturnUpdate();
			loopAudio.volume = Mathf.Lerp(loopAudio.volume, Mathf.Clamp01(velocity.magnitude), Time.deltaTime * 5f);
		}
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		hasBeenGrabbedThisFrame = false;
	}

	public override void ProjectilePhysics()
	{
		if (!hasHitSurface)
		{
			base.ProjectilePhysics();
		}
	}

	private void ReturnUpdate()
	{
		ENT_Player playerObject = ENT_Player.playerObject;
		float num = Vector3.Distance(playerObject.transform.position, base.transform.position);
		float num2 = Vector3.Dot((playerObject.transform.position - base.transform.position).normalized, Vector3.up);
		if (!returning && (hasHitSurface || timer > 2f) && (num > 8f || playerObject.IsCrouching() || ((double)num2 > 0.8 && num > 4f)))
		{
			if (Vector3.Dot(ENT_Player.playerObject.camTransform.forward, (base.transform.position - ENT_Player.playerObject.camTransform.position).normalized) > 0.95f)
			{
				bool flag = false;
				ENT_Player.Hand[] hands = ENT_Player.playerObject.hands;
				foreach (ENT_Player.Hand hand in hands)
				{
					if (!hand.IsFree() || hasBeenGrabbedThisFrame)
					{
						continue;
					}
					flag = true;
					hand.ShowCustomInteractionSprite(interactSprite, 0.05f);
					if (InputManager.GetButton(hand.fireButton).Up)
					{
						hasBeenGrabbedThisFrame = true;
						StartReturn();
						returningToHand = hand.id;
						recoveryRootObject.gameObject.SetActive(value: false);
						recoveryPrimeRootObject.gameObject.SetActive(value: false);
						return;
					}
					if (InputManager.GetButton(hand.fireButton).Pressed)
					{
						if (!recoveryPrimeRootObject.gameObject.activeSelf)
						{
							recoveryPrimeRootObject.gameObject.SetActive(value: true);
						}
						CL_CameraControl.Shake(0.03f * Time.deltaTime);
					}
				}
				if (flag && !recoveryRootObject.gameObject.activeSelf)
				{
					recoveryRootObject.gameObject.SetActive(value: true);
				}
			}
			else if (recoveryRootObject.gameObject.activeSelf)
			{
				recoveryRootObject.gameObject.SetActive(value: false);
				recoveryPrimeRootObject.gameObject.SetActive(value: false);
			}
		}
		else if (recoveryRootObject.gameObject.activeSelf)
		{
			recoveryRootObject.gameObject.SetActive(value: false);
			recoveryPrimeRootObject.gameObject.SetActive(value: false);
		}
		if (!returning && num > 100f)
		{
			StartReturn();
			returningToHand = 0;
			recoveryRootObject.gameObject.SetActive(value: false);
			recoveryPrimeRootObject.gameObject.SetActive(value: false);
		}
		else
		{
			if (!returning)
			{
				return;
			}
			float num3 = 1f;
			if (returning)
			{
				if (sourceItem != null)
				{
					float.TryParse(sourceItem.GetFirstDataStringByType("strain"), out currentStrain);
					num3 = Mathf.Clamp01(currentStrain * 1f + 0.5f);
				}
				if (num < 1.5f)
				{
					AudioManager.PlaySound(recoverySound[UnityEngine.Random.Range(0, recoverySound.Count)], base.transform.position);
					float num4 = 1f;
					Item item = null;
					if (sourceItem != null)
					{
						if (currentStrain < 0.5f)
						{
							num4 = currentStrain * 2f;
						}
						num3 = Mathf.Clamp01(currentStrain * 1f);
						item = sourceItem.GetClone();
						sourceItem.Destroy();
					}
					else
					{
						item = returnItem.itemData.GetClone();
					}
					if (playerObject.IsGrounded() || playerObject.IsCrouching())
					{
						playerObject.AddForce((velocity.normalized * returnHitForce + Vector3.up * returnHitUpForce) * 0.3f * num4, "returnrebar");
					}
					else
					{
						playerObject.AddForce(velocity.normalized * returnHitForce + Vector3.up * returnHitUpForce * num4, "returnrebar");
					}
					if (currentStrain < 0.5f)
					{
						playerObject.AddEffect("fire", (0.5f - currentStrain) * 2f);
					}
					item.bagPosition = new Vector3(0f, 0f, 1f) + UnityEngine.Random.insideUnitSphere * 0.01f;
					item.bagRotation = Quaternion.LookRotation(item.upDirection);
					if (playerObject.hands[returningToHand].GetHandItem() != null || playerObject.hands[returningToHand].interactState == ENT_Player.InteractType.hanging || playerObject.IsMoveLocked())
					{
						Inventory.instance.AddItemToInventoryCenter(item);
					}
					else
					{
						playerObject.hands[returningToHand].DropHand();
						Inventory.instance.AddItemToHand(item, returningToHand);
					}
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
			velocity = Vector3.Lerp(velocity.normalized, (ENT_Player.playerObject.transform.position - base.transform.position).normalized, Time.deltaTime * returnRotate).normalized * returnSpeed * num3;
		}
	}

	private void StartReturn()
	{
		velocity = -base.transform.forward * returnSpeed;
		base.transform.position += velocity.normalized * Time.deltaTime * 0.5f;
		hasHitSurface = false;
		returning = true;
		recoveryRootObject.gameObject.SetActive(value: false);
		recoveryPrimeRootObject.gameObject.SetActive(value: false);
		AudioManager.PlaySound(recallSound[UnityEngine.Random.Range(0, recallSound.Count)], base.transform.position, 0.5f, 1f, 0.5f);
		hitRootObject.SetActive(value: false);
		foreach (GameEntity skeweredEntity in skeweredEntities)
		{
			if (skeweredEntity != null && skeweredEntity.TryGetComponent<Rigidbody>(out var component))
			{
				component.useGravity = true;
				component.isKinematic = false;
			}
		}
		skeweredEntities.Clear();
		softParent.ClearParent();
	}

	internal override void OnCollisionHit(RaycastHit hit, ObjectTagger tagger, bool hasHitThis, bool hasKilled = false)
	{
		if (!hasHitSurface)
		{
			base.OnCollisionHit(hit, tagger, hasHitThis, hasKilled);
		}
	}

	internal override bool OnDamage(Damageable damageable, Damageable.DamageInfo damageInfo)
	{
		if (currentStrain < 0.5f)
		{
			damageInfo.tags.Add("incendiary");
		}
		return base.OnDamage(damageable, damageInfo);
	}

	internal override bool RicochetCheck(RaycastHit hit)
	{
		if (Vector3.Angle(velocity, -hit.normal) > bounceAngle || returning)
		{
			velocity = Vector3.Reflect(velocity, -hit.normal) * 0.8f * bounceDampen;
			if (reflectSound != null && reflectSound.Count > 0)
			{
				AudioSource.PlayClipAtPoint(reflectSound[UnityEngine.Random.Range(0, reflectSound.Count)], hit.point, 1f);
			}
			bounces++;
			if (maxBounces != 0 && maxBounces <= bounces && !useHitEffects && !destroyOnHit)
			{
				velocity = Vector3.zero;
				stopped = true;
			}
			OnRichochet();
			return true;
		}
		return false;
	}

	internal override void CreateHitEffect(RaycastHit hit, HitEffect effect)
	{
		if (!returning && !hasHitSurface)
		{
			if (hitSound != null && hitSound.Count > 0)
			{
				AudioManager.PlaySound(hitSound[UnityEngine.Random.Range(0, hitSound.Count)], base.transform.position);
			}
			base.transform.localScale = Vector3.one;
			CreateSurfaceDecal(hit, effect);
			hasHitSurface = true;
			velocity = Vector3.zero;
			hitRootObject.SetActive(value: true);
			base.transform.position = hit.point;
			softParent.Initialize(hit.collider.transform);
		}
	}
}
