using System;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

[RequireComponent(typeof(ObjectTagger))]
public class GameEntity : MonoBehaviourGizmos, Damageable, Hitbox
{
	[Serializable]
	public class EntityBuff
	{
		public string name;

		public List<BuffContainer> currentBuffs;

		public GameEntity gameEntity;

		private Dictionary<string, BuffContainer.Buff> finalBuffs;

		private int buffVersion;

		public void Initialize()
		{
			finalBuffs = new Dictionary<string, BuffContainer.Buff>();
			currentBuffs = new List<BuffContainer>();
		}

		public void UpdateBuffs()
		{
			if (finalBuffs == null)
			{
				Initialize();
			}
			finalBuffs.Clear();
			for (int i = 0; i < currentBuffs.Count; i++)
			{
				bool flag = currentBuffs[i].Update();
				foreach (BuffContainer.Buff buff2 in currentBuffs[i].buffs)
				{
					if (!finalBuffs.ContainsKey(buff2.id))
					{
						BuffContainer.Buff buff = new BuffContainer.Buff();
						buff.id = buff2.id;
						buff.amount = 0f;
						finalBuffs.Add(buff2.id, buff);
					}
					finalBuffs[buff2.id].amount += buff2.amount * currentBuffs[i].GetMultiplier();
					DebugMenu.UpdateDebugText("buff" + buff2.id, "BUFF: " + buff2.id + " " + finalBuffs[buff2.id].amount);
				}
				if (flag)
				{
					currentBuffs.Remove(currentBuffs[i]);
					break;
				}
			}
		}

		public List<BuffContainer> GetBuffContainers(string id)
		{
			List<BuffContainer> list = new List<BuffContainer>();
			foreach (BuffContainer currentBuff in currentBuffs)
			{
				if (currentBuff.id == id)
				{
					list.Add(currentBuff);
				}
			}
			return list;
		}

		public BuffContainer GetBuffContainer(string id)
		{
			foreach (BuffContainer currentBuff in currentBuffs)
			{
				if (currentBuff.id == id)
				{
					return currentBuff;
				}
			}
			return null;
		}

		public void RemoveBuffContainer(string id)
		{
			bool flag = false;
			for (int num = currentBuffs.Count - 1; num >= 0; num--)
			{
				if (currentBuffs[num].id == id)
				{
					Debug.Log("Removing Buff: " + id);
					flag = true;
					buffVersion++;
					foreach (BuffContainer.Buff buff in currentBuffs[num].buffs)
					{
						if (buff != null)
						{
							DebugMenu.DeleteDebugText("buff" + buff.id);
						}
					}
					currentBuffs.RemoveAt(num);
				}
			}
			if (!flag)
			{
				Debug.Log("Attempted to find buff: " + id + ",  Buff not found.");
			}
		}

		public void RemoveBuffContainer(BuffContainer b)
		{
			if (!currentBuffs.Contains(b))
			{
				return;
			}
			foreach (BuffContainer.Buff buff in b.buffs)
			{
				DebugMenu.DeleteDebugText("buff" + buff.id);
			}
			currentBuffs.Remove(b);
			buffVersion++;
		}

		public bool HasBuffContainer(string id)
		{
			foreach (BuffContainer currentBuff in currentBuffs)
			{
				if (currentBuff.id == id)
				{
					return true;
				}
			}
			return false;
		}

		public float GetBuff(string id)
		{
			if (finalBuffs == null)
			{
				return 0f;
			}
			if (!finalBuffs.ContainsKey(id))
			{
				return 0f;
			}
			return finalBuffs[id].amount;
		}

		public int GetBuffVersion()
		{
			return buffVersion;
		}

		public void AddBuff(BuffContainer buffContainer)
		{
			if (gameEntity == null)
			{
				return;
			}
			currentBuffs.Add(buffContainer);
			buffVersion++;
			foreach (BuffContainer.Buff buff in buffContainer.buffs)
			{
				if (!gameEntity.OnGetBuff(buff) && !finalBuffs.ContainsKey(buff.id))
				{
					new BuffContainer.Buff
					{
						id = buff.id,
						amount = 0f
					};
				}
			}
		}

		public void AddOrResetBuff(BuffContainer buffContainer)
		{
			if (!string.IsNullOrEmpty(buffContainer.id))
			{
				foreach (BuffContainer currentBuff in currentBuffs)
				{
					if (currentBuff.id == buffContainer.id)
					{
						currentBuff.buffTime = 1f;
						currentBuff.loseRate = buffContainer.loseRate;
						return;
					}
				}
			}
			AddBuff(buffContainer);
			buffVersion++;
		}
	}

	public class EntityEffects
	{
		public float fire;

		public float wet;
	}

	[Serializable]
	public class BaseEntitySaveData
	{
		public string entityID;

		public Vector3 position;

		public Quaternion rotation;

		public string entityData;

		public SaveableInfo saveInfo;
	}

	public static List<GameEntity> entities = new List<GameEntity>();

	private int entityIndex = -1;

	public string objectType = "entity";

	public string entityPrefabID = "entity";

	public bool canSave = true;

	public float health = 10f;

	public float maxHealth = 10f;

	public List<Damageable.DamageEffect> damageEffects;

	public bool dead;

	public GameObject destroyObject;

	public GameObject gibAsset;

	public float entityRadius = 1f;

	public bool spawnWithBounds = true;

	public float movementRecordDelta = 0.5f;

	public bool skewerable;

	public bool onlySkewerOnKill = true;

	public string scoreTitleOnKill = "Kills";

	public float scoreBonusOnKill;

	[Header("Tick Rate")]
	public float tickRate = 0.1f;

	private float tickTime;

	public bool damageable = true;

	private Vector3 lastPosition = Vector3.zero;

	private ObjectTagger tagger;

	internal EntityEffects entityEffects = new EntityEffects();

	private float effectFireTime;

	public bool canCatchFire = true;

	public float fireTimeMult = 1f;

	public float fireDamageMult = 1f;

	public float fireEffectRadius = 1f;

	public float fireEffectParticleAmountMult = 1f;

	public float dryRate = 1f;

	public float sightVisibility = 1f;

	public EntityBuff curBuffs;

	public string hitParticle = "";

	public float hitParticleAmountMult = 1f;

	public FX_DecalSplatterSetting hitSplatter;

	public FX_DecalSplatterSetting killSplatter;

	public float splatterMult = 1f;

	public Action<Damageable.DamageInfo> _OnDamage;

	public Action<GameEntity> _OnDeath;

	private Vector3 lastUpdatePosition;

	private Vector3 trueVelocity;

	private static int curIdx = 0;

	internal Action _OnFireTick;

	internal float curVisibilityCoefficient = 1f;

	internal bool grappled;

	internal List<AIGameEntity.Grappler> grapplers = new List<AIGameEntity.Grappler>();

	private bool inWater;

	internal UT_SwimZone currentSwimZone;

	internal float enterWaterTime;

	public void Buff(BuffContainer buff)
	{
		curBuffs.AddOrResetBuff(buff);
	}

	public void ResetBuff(string id)
	{
		BuffContainer buffContainer = curBuffs.GetBuffContainer(id);
		if (buffContainer != null)
		{
			buffContainer.buffTime = 1f;
		}
	}

	public void AddNewBuff(BuffContainer buff)
	{
		curBuffs.AddOrResetBuff(buff);
	}

	public void RemoveBuff(string id)
	{
		curBuffs.RemoveBuffContainer(id);
	}

	public void RemoveBuff(BuffContainer buff)
	{
		curBuffs.RemoveBuffContainer(buff);
	}

	public void RemoveAllBuffs()
	{
		curBuffs.currentBuffs.Clear();
	}

	internal bool HasBuffContainer(string id)
	{
		return curBuffs.HasBuffContainer(id);
	}

	public virtual void OnEnable()
	{
		if (entities == null)
		{
			entities = new List<GameEntity>();
		}
		if (entityIndex == -1)
		{
			entityIndex = entities.Count;
			entities.Add(this);
		}
		CL_GameManager gMan = CL_GameManager.gMan;
		if (!(gMan != null))
		{
			return;
		}
		foreach (Action<GameEntity> item in gMan.gameEntityOnEnable)
		{
			item(this);
		}
		foreach (CL_GameManager.ReplaceInfo replacementScope in gMan.replacementScopes)
		{
			if (replacementScope.replaceOnEnable && replacementScope.ShouldReplace(this, useRandom: true))
			{
				replacementScope.Replace(this);
				break;
			}
		}
	}

	public virtual void OnDisable()
	{
		RemoveFromEntitiesList();
	}

	private void RemoveFromEntitiesList()
	{
		if (entityIndex != -1 && entities[entityIndex] != this)
		{
			Debug.LogError("Exception: Index of destroyed entity does not match up with me!");
		}
		if (entityIndex != -1)
		{
			List<GameEntity> list = entities;
			GameEntity gameEntity = list[list.Count - 1];
			gameEntity.entityIndex = entityIndex;
			entities[entityIndex] = gameEntity;
			entities.RemoveAt(entities.Count - 1);
			entityIndex = -1;
		}
	}

	public virtual void Start()
	{
		curBuffs = new EntityBuff();
		curBuffs.Initialize();
		curBuffs.gameEntity = this;
		CL_GameTracker.AddEventToSession(CL_GameTracker.CreateEvent(base.name, base.gameObject.GetInstanceID().ToString(), objectType, CL_GameTracker.Session.Tick.Event.EventType.spawn, base.transform.position));
		CL_GameTracker.EventUpdate = (Action)Delegate.Combine(CL_GameTracker.EventUpdate, new Action(SessionUpdate));
		lastPosition = base.transform.position;
		CL_GameManager gMan = CL_GameManager.gMan;
		if (!(gMan != null))
		{
			return;
		}
		foreach (Action<GameEntity> item in CL_GameManager.gMan.gameEntityOnStart)
		{
			item(this);
		}
		foreach (CL_GameManager.ReplaceInfo replacementScope in gMan.replacementScopes)
		{
			if (!replacementScope.replaceOnEnable && replacementScope.ShouldReplace(this, useRandom: true))
			{
				replacementScope.Replace(this);
			}
		}
	}

	public static void GameEntityListGc(int stopAfterLive = 4)
	{
		if (curIdx >= entities.Count)
		{
			curIdx = 0;
		}
		int num = 0;
		while (curIdx < entities.Count)
		{
			GameEntity gameEntity = entities[curIdx];
			bool num2 = gameEntity != null;
			if (!num2)
			{
				Debug.LogError("Exception: Detected entity of type " + gameEntity.GetType().FullName + " has not destroyed itself from entities list. This indicates issue in type's code. Cleaning up now.");
				gameEntity.RemoveFromEntitiesList();
				curIdx--;
				num = 0;
			}
			if (num2)
			{
				num++;
			}
			if (num2 && gameEntity.entityIndex != curIdx)
			{
				Debug.LogError($"Exception: Detected entity {gameEntity.name} with invalid index ({gameEntity.entityIndex} instead of {curIdx}). This indicates issue in list removal. Fixing now.");
				gameEntity.entityIndex = curIdx;
			}
			if (stopAfterLive < 0 || num != stopAfterLive)
			{
				curIdx++;
				continue;
			}
			break;
		}
	}

	public virtual void Update()
	{
		tickTime -= Time.deltaTime;
		if (tickTime < 0f)
		{
			tickTime = tickRate;
			TickUpdate();
		}
		curBuffs.UpdateBuffs();
		UpdateEntityEffects();
		curVisibilityCoefficient = 1f;
		WaterCheck();
		if (inWater)
		{
			WaterUpdate();
		}
	}

	public virtual void TickUpdate()
	{
	}

	public virtual void FixedUpdate()
	{
		trueVelocity = (base.transform.position - lastUpdatePosition) / Time.fixedDeltaTime;
		lastUpdatePosition = base.transform.position;
	}

	private void OnDestroy()
	{
		if (CL_GameTracker.session != null)
		{
			CL_GameTracker.AddEventToSession(CL_GameTracker.CreateEvent(base.name, base.gameObject.GetInstanceID().ToString(), objectType, CL_GameTracker.Session.Tick.Event.EventType.destroy, base.transform.position));
			CL_GameTracker.EventUpdate = (Action)Delegate.Remove(CL_GameTracker.EventUpdate, new Action(SessionUpdate));
		}
	}

	public virtual bool Damage(Damageable.DamageInfo info)
	{
		if (!damageable)
		{
			return false;
		}
		info = ProcessDamageInfo(info);
		health -= info.amount;
		_OnDamage?.Invoke(info);
		if (hitParticle != "")
		{
			_ = info.position;
			FXManager.PlayParticle(hitParticle, info.position, Mathf.CeilToInt(25f * info.amount));
		}
		if (hitSplatter != null)
		{
			hitSplatter.Spray(base.transform.position, -base.transform.up, splatterMult);
		}
		if (dead)
		{
			return false;
		}
		if (info.onKill != null)
		{
			info.onKill();
		}
		if (health <= 0f)
		{
			Kill(info.type, info);
			info.hasKilled = true;
			return true;
		}
		return false;
	}

	public virtual void Heal(float amount)
	{
		health = Mathf.Min(health + amount, maxHealth);
	}

	internal Damageable.DamageInfo ProcessDamageInfo(Damageable.DamageInfo info)
	{
		Damageable.DamageEffect damageEffectFromList = GetDamageEffectFromList(info);
		if (damageEffectFromList != null)
		{
			info.amount *= damageEffectFromList.damageMultiplier;
			damageEffectFromList.damageEvent.Invoke();
		}
		if (info.hitBuffContainer != null)
		{
			Buff(info.hitBuffContainer);
		}
		if (info.HasTag("incendiary"))
		{
			AddEffect("fire", 2f);
		}
		else if (info.HasTag("incendiary-long"))
		{
			AddEffect("fire", 5f);
		}
		return info;
	}

	internal Damageable.DamageEffect GetDamageEffectFromList(Damageable.DamageInfo info)
	{
		if (damageEffects == null || damageEffects.Count == 0)
		{
			return null;
		}
		foreach (Damageable.DamageEffect damageEffect in damageEffects)
		{
			if (damageEffect.HasTag(info.tags))
			{
				return damageEffect;
			}
		}
		return null;
	}

	public virtual void Teleport(Vector3 pos)
	{
		base.transform.position = pos;
	}

	public virtual void Teleport(Vector3 pos, Quaternion rot, bool keepVelocity = false)
	{
		Teleport(pos);
		base.transform.rotation = rot;
	}

	public virtual void OnKilledByPlayer(Damageable.DamageInfo damageInfo)
	{
		if (scoreBonusOnKill != 0f)
		{
			CL_ScoreManager.sessionScore.AddScore(scoreTitleOnKill, scoreTitleOnKill, scoreBonusOnKill, 0f, 1);
		}
	}

	public virtual void Kill(string type, Damageable.DamageInfo damageInfo)
	{
		if (!dead && killSplatter != null)
		{
			killSplatter.Spray(base.transform.position, -base.transform.up, splatterMult);
		}
		dead = true;
		if (tagger != null)
		{
			tagger.AddTag("Dead");
		}
		if (type == "gib" && gibAsset != null)
		{
			Gib();
		}
		else if ((bool)destroyObject)
		{
			UnityEngine.Object.Instantiate(destroyObject, base.transform.position, base.transform.rotation, base.transform.parent);
		}
		if (damageInfo != null && damageInfo.sourceEntity != null && damageInfo.sourceEntity == ENT_Player.GetPlayer())
		{
			OnKilledByPlayer(damageInfo);
		}
		health = 0f;
		_OnDeath?.Invoke(this);
	}

	public void Kill(string type)
	{
		Kill(type, null);
	}

	public virtual void Gib()
	{
		UnityEngine.Object.Instantiate(gibAsset, base.transform.position, base.transform.rotation, base.transform.parent);
		dead = true;
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public virtual bool IsDead()
	{
		return dead;
	}

	public virtual void SetForce(Vector3 v)
	{
		AddForce(v);
	}

	public virtual void AddForce(Vector3 v, string source = "")
	{
	}

	public virtual void AddForceAtPosition(Vector3 v, Vector3 p, string source = "")
	{
		AddForce(v);
	}

	public virtual void AddForce(Vector3 v, float maxVel, string source = "", float maxVelScale = 0f)
	{
		AddForce(v);
	}

	public virtual void SetDirectionalForce(Vector3 v)
	{
		AddForce(v);
	}

	public virtual void TonguePull(Vector3 v)
	{
	}

	public virtual void AddAcceleration(Vector3 v)
	{
	}

	public virtual ObjectTagger GetTagger()
	{
		if (tagger == null && base.gameObject != null)
		{
			tagger = GetComponent<ObjectTagger>();
		}
		return tagger;
	}

	public virtual void SessionUpdate()
	{
		if (Vector3.Distance(base.transform.position, lastPosition) > movementRecordDelta)
		{
			lastPosition = base.transform.position;
			CL_GameTracker.AddEventToSession(CL_GameTracker.CreateEvent(base.name, base.gameObject.GetInstanceID().ToString(), objectType, CL_GameTracker.Session.Tick.Event.EventType.move, base.transform.position));
		}
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	internal virtual void ClampVelocityToAxis(Vector3 up)
	{
		throw new NotImplementedException();
	}

	public void LoadEntitySaveData(BaseEntitySaveData entitySaveData)
	{
		GetComponent<SaveableObject>()?.SetSaveInfo(JsonUtility.FromJson<SaveableInfo>(entitySaveData.entityData), null);
		UT_SpawnChance component = GetComponent<UT_SpawnChance>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public virtual BaseEntitySaveData GetEntitySaveData()
	{
		BaseEntitySaveData baseEntitySaveData = new BaseEntitySaveData();
		baseEntitySaveData.entityID = entityPrefabID;
		SaveableObject component = GetComponent<SaveableObject>();
		if (component != null)
		{
			baseEntitySaveData.entityData = JsonUtility.ToJson(component.GetSaveInfo());
		}
		return baseEntitySaveData;
	}

	public static void OffsetEntities(float amount)
	{
		if (entities != null)
		{
			foreach (GameEntity entity in entities)
			{
				if (entity != null)
				{
					entity.OffsetEntity(amount);
				}
			}
		}
		FXManager.fxMan.corruptionHeight = -10000f;
	}

	public virtual void OffsetEntity(float amount)
	{
		if (base.transform != null && (base.transform.parent == null || base.transform.parent == WorldLoader.GetWorldLoaderNullParent()))
		{
			base.transform.position += Vector3.up * amount;
		}
	}

	public static GameEntity GetGameEntity(GameObject g)
	{
		GameEntity component = g.GetComponent<GameEntity>();
		if ((bool)component)
		{
			return component;
		}
		ENT_Hitbox component2 = g.GetComponent<ENT_Hitbox>();
		if ((bool)component2)
		{
			return component2.GetGameEntity();
		}
		return null;
	}

	public virtual void AddEffect(string effect, float amount)
	{
		if (effect == "fire" && canCatchFire && maxHealth > 0f)
		{
			entityEffects.fire = Mathf.Max(entityEffects.fire, amount * fireTimeMult);
			if (effectFireTime == 0f)
			{
				PlayFireEffect();
			}
		}
		if (effect == "wet")
		{
			entityEffects.wet = Mathf.Max(entityEffects.wet, amount);
		}
	}

	public bool HasEffect(string effect)
	{
		if (effect == "fire")
		{
			return entityEffects.fire > 0f;
		}
		if (effect == "wet")
		{
			return entityEffects.wet > 0f;
		}
		return false;
	}

	internal virtual void UpdateEntityEffects()
	{
		if (entityEffects.fire > 0f && canCatchFire && maxHealth > 0f)
		{
			entityEffects.fire -= Time.deltaTime;
			if (effectFireTime > 0f)
			{
				effectFireTime -= Time.deltaTime;
			}
			else
			{
				PlayFireEffect();
			}
		}
		else
		{
			effectFireTime = 0f;
		}
		if (entityEffects.wet > 0f)
		{
			entityEffects.wet -= Time.deltaTime * dryRate;
		}
	}

	internal virtual void PlayFireEffect()
	{
		Damage(Damageable.DamageInfo.CreateDamageInfo(0.5f * fireDamageMult, "fire"));
		if (!dead)
		{
			AudioManager.PlaySound(AudioManager.GetAudioClipFromList("fire"), base.transform.position);
			CL_UIManager.SubtitleId id = CL_UIManager.SubtitleCreate(CL_LocalizationManager.currentLocalization.GetLine("sound", "effect-fire"), "");
			CL_UIManager.SubtitleFlagsSet(id, CL_UIManager.SubtitleFlags.Default | CL_UIManager.SubtitleFlags.Ambient);
			CL_UIManager.SubtitleSpace(id, base.transform, Vector3.zero, 10f);
		}
		FXManager.PlayParticleWithRadius("fire-small", base.transform.position, fireEffectRadius, Mathf.CeilToInt(4f * fireEffectParticleAmountMult));
		effectFireTime = 0.5f;
		_OnFireTick?.Invoke();
	}

	public virtual float GetVisibility()
	{
		return sightVisibility * curVisibilityCoefficient;
	}

	public virtual void AdjustFrameVisibilityCoefficient(float f)
	{
		curVisibilityCoefficient = Mathf.Min(curVisibilityCoefficient, f);
	}

	public GameEntity GetGameEntity()
	{
		return this;
	}

	public virtual bool OnGetBuff(BuffContainer.Buff buff)
	{
		return false;
	}

	public virtual void SetSkewer(bool s)
	{
	}

	public virtual void SetGrappled(bool b, AIGameEntity.Grappler grappler = null)
	{
		if (grappler != null)
		{
			if (b && !grapplers.Contains(grappler))
			{
				grapplers.Add(grappler);
			}
			else if (!b && grapplers.Contains(grappler))
			{
				grapplers.Remove(grappler);
			}
		}
		if (!grappled || grapplers.Count == 0)
		{
			grappled = b;
		}
	}

	public void ClearGrapple()
	{
		for (int num = grapplers.Count - 1; num >= 0; num--)
		{
			if (DarkMachineFunctions.IsNullOrDestroyedOrDisabled(grapplers[num]))
			{
				grapplers.RemoveAt(num);
			}
			else
			{
				grapplers[num].ReleaseGrapple();
			}
		}
	}

	public AIGameEntity.Grappler.GrappleInfo GetAverageGrappleInfo()
	{
		if (grapplers.Count == 0)
		{
			return new AIGameEntity.Grappler.GrappleInfo();
		}
		AIGameEntity.Grappler.GrappleInfo grappleInfo = new AIGameEntity.Grappler.GrappleInfo();
		grappleInfo.forcePlayerCrouched = false;
		grappleInfo.forcePlayerGrounded = false;
		for (int i = 0; i < grapplers.Count; i++)
		{
			AIGameEntity.Grappler grappler = grapplers[i];
			if (DarkMachineFunctions.IsNullOrDestroyedOrDisabled(grappler))
			{
				grapplers.RemoveAt(i--);
				continue;
			}
			if (grappler is GameEntity gameEntity && gameEntity.IsDead())
			{
				grapplers.RemoveAt(i--);
				continue;
			}
			AIGameEntity.Grappler.GrappleInfo grappleInfo2 = grappler.GetGrappleInfo();
			grappleInfo.forcePlayerCrouched |= grappleInfo2.forcePlayerCrouched;
			grappleInfo.forcePlayerGrounded |= grappleInfo2.forcePlayerGrounded;
			grappleInfo.playerGrappleSpeedMod += grappleInfo2.playerGrappleSpeedMod;
			grappleInfo.frictionMultiplier += grappleInfo2.frictionMultiplier;
			grappleInfo.airbornFrictionMultiplier += grappleInfo2.airbornFrictionMultiplier;
			grappleInfo.gravityMultiplier += grappleInfo2.gravityMultiplier;
			grappleInfo.forceLeaveGrounded |= grappleInfo2.forceLeaveGrounded;
		}
		grappleInfo.playerGrappleSpeedMod /= grapplers.Count;
		grappleInfo.frictionMultiplier /= grapplers.Count;
		grappleInfo.airbornFrictionMultiplier /= grapplers.Count;
		grappleInfo.gravityMultiplier /= grapplers.Count;
		return grappleInfo;
	}

	internal virtual void WaterCheck()
	{
		if (UT_SwimZone.IsPositionInAnySwimZone(base.transform.position, out var swimZone))
		{
			if (!inWater)
			{
				inWater = true;
				enterWaterTime = Time.time;
				EnterSwimZone(swimZone);
			}
		}
		else if (inWater)
		{
			inWater = false;
			ExitSwimZone(currentSwimZone);
			currentSwimZone = null;
		}
		currentSwimZone = swimZone;
	}

	internal virtual void EnterSwimZone(UT_SwimZone zone)
	{
	}

	internal virtual void ExitSwimZone(UT_SwimZone zone)
	{
	}

	internal virtual void WaterUpdate()
	{
	}

	public bool IsInWater()
	{
		return inWater;
	}

	public Vector3 GetTrueVelocity()
	{
		return trueVelocity;
	}

	public GameEntity ReplaceWith(GameEntity newEntity, bool disableOld)
	{
		GameEntity gameEntity = null;
		if (newEntity != null)
		{
			gameEntity = UnityEngine.Object.Instantiate(newEntity, base.transform.position, base.transform.rotation);
			gameEntity.transform.parent = base.transform.parent;
			Rigidbody component = GetComponent<Rigidbody>();
			Rigidbody component2 = gameEntity.GetComponent<Rigidbody>();
			if (component != null && component2 != null)
			{
				component2.isKinematic = component.isKinematic;
				component2.linearVelocity = component.linearVelocity;
				component2.angularVelocity = component.angularVelocity;
			}
		}
		if (disableOld)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		return gameEntity;
	}

	public virtual float GetRadius()
	{
		return entityRadius;
	}
}
