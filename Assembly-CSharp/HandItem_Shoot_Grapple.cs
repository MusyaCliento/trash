using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandItem_Shoot_Grapple : HandItem_Shoot
{
	private float currentStrain;

	private Projectile_Grapple grappleProjectile;

	private bool hasHit;

	public float pullforce = 5f;

	public bool recalling;

	public float maxProjectileRange = 20f;

	public AudioSource grappleAudio;

	public Transform tetherPosition;

	public float hookMeshLerpSpeed = 5f;

	private float hookWiggle;

	public float hookWiggleSpeed = 5f;

	public float reachWiggleAmount = 1f;

	public float yoinkWiggleAmount = 1f;

	public List<SpriteRenderer> renderers;

	public Color inRangeColor = Color.yellow;

	public Color outRangeColor = Color.red;

	private Color curRangeColor;

	public string rangeBuff = "addGrapplePitonRange";

	private float grappleTime;

	private Vector3 grappleStartPosition;

	private Projectile projectileAsset;

	public override void Initialize(Item i, ENT_Player.Hand h)
	{
		base.Initialize(i, h);
		projectileAsset = projectile.GetComponent<Projectile>();
	}

	public override void Update()
	{
		base.Update();
		float buff = ENT_Player.GetPlayer().curBuffs.GetBuff(rangeBuff);
		if (Physics.Raycast(base.transform.position, base.transform.forward, out var _, maxProjectileRange + buff, projectileAsset.hitMask))
		{
			curRangeColor = Color.Lerp(curRangeColor, inRangeColor, Time.deltaTime * 12f);
			if (renderers.Count > 0)
			{
				foreach (SpriteRenderer renderer in renderers)
				{
					renderer.material.SetColor("_EmissiveTexColor", curRangeColor);
				}
			}
		}
		else
		{
			curRangeColor = Color.Lerp(curRangeColor, outRangeColor, Time.deltaTime * 12f);
			if (renderers.Count > 0)
			{
				foreach (SpriteRenderer renderer2 in renderers)
				{
					renderer2.material.SetColor("_EmissiveTexColor", curRangeColor);
				}
			}
		}
		if (hasHit && grappleProjectile != null)
		{
			Vector3 vector = grappleProjectile.transform.position - base.transform.position;
			hand.GetPlayer().AddForce(vector.normalized * pullforce * Time.deltaTime);
			hand.GetPlayer().SetTempGravityMult(0.1f);
			hand.GetOtherHand().DropHand();
			if (!InputManager.GetButton(hand.fireButton).Pressed)
			{
				hasHit = false;
				anim.SetBool("Grappling", value: false);
				clipHandler.PlaySound("grapple:letgo");
				RemoveItem();
				grappleProjectile = null;
				return;
			}
			if (vector.magnitude < 2f)
			{
				hasHit = false;
				if (grappleProjectile.TryGetComponent<CL_Handhold>(out var component))
				{
					clipHandler.PlaySound("grapple:arrive");
					RemoveItem();
					hand.GrabHold(component.transform, component.transform.position + -component.transform.forward * 0.15f);
				}
				grappleProjectile = null;
			}
			if (!grappleAudio.isPlaying)
			{
				grappleAudio.Play();
			}
			grappleAudio.volume = Mathf.Lerp(grappleAudio.volume, 0.8f, Time.deltaTime * 2f);
		}
		else if (hasHit && grappleProjectile == null)
		{
			hasHit = false;
		}
		else
		{
			grappleAudio.volume = Mathf.Lerp(grappleAudio.volume, 0f, Time.deltaTime * 4f);
		}
		if (!(grappleProjectile != null))
		{
			return;
		}
		grappleTime += Time.deltaTime;
		Vector3 vector2 = grappleProjectile.transform.position - base.transform.position;
		if (vector2.magnitude > maxProjectileRange * 3f)
		{
			clipHandler.PlaySound("grapple:letgo");
			RemoveItem();
			return;
		}
		float num = Vector3.Distance(grappleProjectile.transform.position, grappleStartPosition);
		if ((!recalling && vector2.magnitude > maxProjectileRange * 2f) || num > maxProjectileRange + buff)
		{
			recalling = true;
			grappleProjectile.hitMask = default(LayerMask);
			hookWiggle = yoinkWiggleAmount;
		}
		if (recalling)
		{
			grappleProjectile.velocity = -vector2.normalized * grappleProjectile.speed * shootSpeed;
			if (vector2.magnitude < 1f)
			{
				clipHandler.PlaySound("grapple:catch");
				recalling = false;
				UnityEngine.Object.Destroy(grappleProjectile.gameObject);
				anim.SetBool("Grappling", value: false);
				Recharge();
			}
		}
		hookWiggle = Mathf.Lerp(hookWiggle, 0f, Time.deltaTime * hookWiggleSpeed);
		grappleProjectile.hookMesh.material.SetFloat("_Wiggle", hookWiggle);
		grappleProjectile.ScaleTetherTo(tetherPosition.position);
	}

	public override void StartShoot()
	{
		if (!(grappleProjectile != null))
		{
			base.StartShoot();
		}
	}

	public override void Shoot()
	{
		base.Shoot();
	}

	public override void OnDisable()
	{
		base.OnDisable();
		if (grappleProjectile != null)
		{
			Projectile_Grapple projectile_Grapple = grappleProjectile;
			projectile_Grapple._OnProjectileHit = (Action<Projectile, RaycastHit, ObjectTagger>)Delegate.Remove(projectile_Grapple._OnProjectileHit, new Action<Projectile, RaycastHit, ObjectTagger>(OnGrappleHit));
		}
	}

	internal override Projectile CreateProjectile(RaycastHit hit, Vector3 startPos)
	{
		grappleProjectile = base.CreateProjectile(hit, startPos) as Projectile_Grapple;
		grappleProjectile.destroyOnHit = false;
		Projectile_Grapple projectile_Grapple = grappleProjectile;
		projectile_Grapple._OnProjectileHit = (Action<Projectile, RaycastHit, ObjectTagger>)Delegate.Combine(projectile_Grapple._OnProjectileHit, new Action<Projectile, RaycastHit, ObjectTagger>(OnGrappleHit));
		grappleProjectile.SetLifetime(float.PositiveInfinity);
		hasHit = false;
		anim.SetBool("Grappling", value: true);
		grappleTime = 0f;
		hookWiggle = reachWiggleAmount;
		grappleStartPosition = grappleProjectile.transform.position;
		return grappleProjectile;
	}

	private void OnGrappleHit(Projectile projectile, RaycastHit hit, ObjectTagger tagger)
	{
		StartCoroutine(WaitOneFrame());
		IEnumerator WaitOneFrame()
		{
			yield return null;
			if (!(projectile == null) && projectile.HasHitSurface())
			{
				hasHit = true;
				if (base.gameObject != null)
				{
					clipHandler.PlaySound("grapple:latch");
					hand.GetPlayer().ScaleVelocityMagnitude(0.3f);
					CL_GameManager.gMan.FreezeForTime(0.1f, 0.2f);
					hand.GetPlayer().camRoot.ShakeCamera(0.15f);
					hand.GetPlayer().SetFOVShock(30f, slow: true);
				}
			}
		}
	}

	public override void OnDrop()
	{
		if (grappleProjectile != null)
		{
			item.Destroy();
		}
		base.OnDrop();
	}
}
