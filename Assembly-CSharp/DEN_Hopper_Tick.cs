using System.Collections.Generic;
using DarkMachine.AI;
using UnityEngine;
using UnityEngine.Events;

public class DEN_Hopper_Tick : DEN_Hopper
{
	private GameEntity attachTarget;

	private Vector3 relativeAttachPosition;

	public GameObject worldModel;

	public GameObject attachModel;

	public Animator attachAnimator;

	private bool isAttached;

	public BuffContainer drainDebuff;

	public float drainDamage = 0.1f;

	public float drainStaminaDamage = 0.2f;

	public float maxBloodDrain = 20f;

	private float currentBloodDrained;

	public string damageTag = "tick";

	public List<string> damageTaglist;

	public Transform bloodBone;

	private Vector3 bloodBoneStartScale;

	public float bloodBoneScaleMultiplier = 2f;

	private bool hasHalfDrained;

	public UnityEvent halfDrainEvent;

	public float attachDistance = 0.5f;

	public string suckSoundID = "tick:suck";

	public string releaseSoundID = "tick:release";

	public List<Sprite> bloodsackSprites;

	public SpriteRenderer bloodsackRenderer;

	private int curbloodsackSpriteId;

	private AIC_SimpleCreature_Hunt huntState;

	public override void Start()
	{
		base.Start();
		bloodBoneStartScale = bloodBone.localScale;
		if (GetState("hunt") is AIC_SimpleCreature_Hunt aIC_SimpleCreature_Hunt && aIC_SimpleCreature_Hunt != null)
		{
			huntState = aIC_SimpleCreature_Hunt;
		}
	}

	public void LateUpdate()
	{
		if (isAttached && attachTarget != null)
		{
			base.transform.position = ENT_Player.GetPlayer().cam.transform.position + relativeAttachPosition;
			attachModel.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
		}
		if (!isAttached)
		{
			return;
		}
		bloodBone.localScale = bloodBoneStartScale * (1f + currentBloodDrained / maxBloodDrain * bloodBoneScaleMultiplier);
		currentBloodDrained += Time.deltaTime;
		if (currentBloodDrained >= maxBloodDrain)
		{
			Damageable.DamageInfo damageInfo = new Damageable.DamageInfo();
			damageInfo.amount = drainDamage;
			damageInfo.sourceEntity = this;
			damageInfo.type = damageTag;
			damageInfo.tags = damageTaglist;
			ENT_Player.GetPlayer().Damage(damageInfo);
			Detach();
			return;
		}
		if (!hasHalfDrained && currentBloodDrained >= maxBloodDrain / 3f)
		{
			hasHalfDrained = true;
			halfDrainEvent.Invoke();
		}
		int num = Mathf.FloorToInt(((float)bloodsackSprites.Count - 1f) * (currentBloodDrained / maxBloodDrain));
		if (num != curbloodsackSpriteId)
		{
			curbloodsackSpriteId = num;
		}
	}

	public override void OnLeapHit(Collision collision, GameEntity gameEntity)
	{
		base.OnLeapHit(collision, gameEntity);
		if (!isAttached && gameEntity == ENT_Player.GetPlayer())
		{
			Attach(gameEntity);
		}
	}

	public void Attach(GameEntity gameEntity)
	{
		attachTarget = gameEntity;
		Vector3 vector = Vector3.Scale((base.transform.position - ENT_Player.GetPlayer().cam.transform.position).normalized, new Vector3(1f, 0.5f, 1f)).normalized * attachDistance;
		relativeAttachPosition = vector;
		worldModel.SetActive(value: false);
		attachModel.SetActive(value: true);
		isAttached = true;
		active = false;
		GetComponent<Rigidbody>().isKinematic = true;
		base.gameObject.layer = LayerMask.NameToLayer("CreaturePassthrough");
		attachAnimator.SetTrigger("Attach");
		attachAnimator.SetFloat("Speed", Random.Range(0.75f, 1f));
	}

	public void Detach()
	{
		active = true;
		if (huntState != null && currentBloodDrained > maxBloodDrain / 2f)
		{
			huntState.fear = true;
			huntState.canAttackTarget = false;
		}
		attachTarget = null;
		worldModel.SetActive(value: true);
		attachModel.SetActive(value: false);
		isAttached = false;
		GetComponent<Rigidbody>().isKinematic = false;
		base.gameObject.layer = LayerMask.NameToLayer("Creature");
		clipHandler.PlaySound(releaseSoundID);
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (isAttached)
		{
			info.amount /= 2f;
			Detach();
		}
		else if (health < 0f || currentBloodDrained > maxBloodDrain / 2f)
		{
			Gib();
			return true;
		}
		return base.Damage(info);
	}

	public void DrainBite()
	{
		if (isAttached)
		{
			Damageable.DamageInfo damageInfo = new Damageable.DamageInfo();
			damageInfo.amount = drainDamage;
			damageInfo.sourceEntity = this;
			damageInfo.type = damageTag;
			damageInfo.tags = damageTaglist;
			damageInfo.isLight = true;
			damageInfo.position = base.transform.position;
			ENT_Player.GetPlayer().Damage(damageInfo);
			ENT_Player.GetPlayer().DamageGripStrength(drainStaminaDamage);
			ENT_Player.GetPlayer().SplatterScreenBlood(2);
			clipHandler.PlaySound(suckSoundID);
			if (drainDebuff != null)
			{
				ENT_Player.GetPlayer().AddNewBuff(drainDebuff.CopyBuffContainer());
			}
		}
	}

	public void GrowBloodsack()
	{
		bloodsackRenderer.sprite = bloodsackSprites[curbloodsackSpriteId];
	}

	internal override void WaterUpdate()
	{
		base.WaterUpdate();
		if (isAttached)
		{
			Detach();
		}
	}
}
