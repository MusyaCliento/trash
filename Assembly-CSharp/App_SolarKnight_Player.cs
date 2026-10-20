using System;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class App_SolarKnight_Player : App_SolarKnight_Entity
{
	[Serializable]
	public class Upgrade
	{
		[Serializable]
		public class BuffInfo
		{
			public string statName;

			public float buffAmount;
		}

		public enum WeaponAddType
		{
			ToHardpointID = 0,
			ToHardpointTag = 1
		}

		public string name;

		public string upgradeName;

		public string description;

		public List<BuffInfo> buffs = new List<BuffInfo>();

		public App_SolarKnight_Weapon weaponToAdd;

		public WeaponAddType weaponAddType;

		public string hardpointIDToAddWeapon;

		public string hardpointTagToAddWeapon;

		public bool removeWeaponType;

		public string weaponTypeToRemove;

		public int cost = 250;

		private App_SolarKnight_Player player;

		public bool removeAfterApply;

		public string prerequisiteUpgradeName = "";

		public string removeUpgradeOnApply = "";

		public bool canStack = true;

		public virtual void InitializeUpgrade(App_SolarKnight_Player player)
		{
			this.player = player;
			if (HasBuff("extraLife"))
			{
				App_SolarKnight_World.instance.GetApp().AddLife();
			}
			if (removeWeaponType)
			{
				player.RemoveAllWeaponsWithId(weaponTypeToRemove);
			}
			if (removeUpgradeOnApply != "")
			{
				List<Upgrade> list = new List<Upgrade>();
				foreach (Upgrade appliedUpgrade in player.appliedUpgrades)
				{
					if (appliedUpgrade.name == removeUpgradeOnApply)
					{
						list.Add(appliedUpgrade);
					}
				}
				foreach (Upgrade item in list)
				{
					item.RemoveUpgrade();
				}
			}
			if (weaponToAdd != null)
			{
				if (weaponAddType == WeaponAddType.ToHardpointID)
				{
					player.AddWeaponToHardpoint(hardpointIDToAddWeapon, weaponToAdd.weaponInfo.GetCopy());
				}
				else if (weaponAddType == WeaponAddType.ToHardpointTag)
				{
					player.AddWeaponToHardpointsWithTag(hardpointTagToAddWeapon, weaponToAdd.weaponInfo.GetCopy());
				}
			}
			if (removeAfterApply)
			{
				RemoveUpgrade();
			}
		}

		public Upgrade GetCopy()
		{
			Upgrade upgrade = new Upgrade();
			upgrade.name = name;
			upgrade.upgradeName = upgradeName;
			upgrade.description = description;
			upgrade.cost = cost;
			upgrade.weaponToAdd = weaponToAdd;
			upgrade.weaponAddType = weaponAddType;
			upgrade.hardpointIDToAddWeapon = hardpointIDToAddWeapon;
			upgrade.hardpointTagToAddWeapon = hardpointTagToAddWeapon;
			upgrade.removeAfterApply = removeAfterApply;
			upgrade.canStack = canStack;
			upgrade.removeWeaponType = removeWeaponType;
			upgrade.weaponTypeToRemove = weaponTypeToRemove;
			foreach (BuffInfo buff in buffs)
			{
				BuffInfo buffInfo = new BuffInfo();
				buffInfo.statName = buff.statName;
				buffInfo.buffAmount = buff.buffAmount;
				upgrade.buffs.Add(buffInfo);
			}
			return upgrade;
		}

		public void RemoveUpgrade()
		{
			player.RemoveUpgrade(this);
		}

		public bool HasBuff(string statName)
		{
			foreach (BuffInfo buff in buffs)
			{
				if (buff.statName == statName)
				{
					return true;
				}
			}
			return false;
		}
	}

	[Serializable]
	public class HardpointInfo
	{
		public string id;

		public string tag;

		public List<Vector3> hardpointPositions;

		public Vector3 hardpointForward;

		public List<WeaponInfo> weaponInfo;

		private int currentPositionIndex;

		public float fireRateBuffBonus;

		public void Shoot(App_SolarKnight_Entity entity, App_SolarKnight_Player player)
		{
			Vector3 position = hardpointPositions[currentPositionIndex];
			foreach (WeaponInfo item in weaponInfo)
			{
				if (item.Shoot(entity, entity.transform.TransformPoint(position), entity.transform.TransformVector(hardpointForward).normalized, player, fireRateBuffBonus))
				{
					currentPositionIndex = (currentPositionIndex + 1) % hardpointPositions.Count;
				}
			}
		}

		public void ShootInDirection(App_SolarKnight_Entity entity, App_SolarKnight_Player player, Vector3 direction)
		{
			Vector3 position = hardpointPositions[currentPositionIndex];
			foreach (WeaponInfo item in weaponInfo)
			{
				if (item.Shoot(entity, entity.transform.TransformPoint(position), direction.normalized, player, fireRateBuffBonus))
				{
					currentPositionIndex = (currentPositionIndex + 1) % hardpointPositions.Count;
				}
			}
		}

		public void AddWeapon(WeaponInfo weapon)
		{
			weaponInfo.Add(weapon);
		}

		public void ClearAllWeapons()
		{
			weaponInfo.Clear();
		}

		public void RemoveWeapon(WeaponInfo weapon)
		{
			weaponInfo.Remove(weapon);
		}

		public void RemoveWeaponByID(string weaponID)
		{
			WeaponInfo weaponInfo = null;
			foreach (WeaponInfo item in this.weaponInfo)
			{
				if (item.id == weaponID)
				{
					weaponInfo = item;
					break;
				}
			}
			if (weaponInfo != null)
			{
				this.weaponInfo.Remove(weaponInfo);
			}
		}

		public WeaponInfo GetWeaponByID(string weaponID)
		{
			foreach (WeaponInfo item in weaponInfo)
			{
				if (item.id == weaponID)
				{
					return item;
				}
			}
			return null;
		}
	}

	[Serializable]
	public class WeaponInfo
	{
		public string id;

		public float shootCooldown = 0.2f;

		public float shootVelocity = 30f;

		public float shootVelocityVariance;

		public float shootSpread = 0.1f;

		private float lastShotTime;

		public float projectileLifetime = 1.5f;

		public int shotAmount = 1;

		public Color shootColor = Color.white;

		public App_SolarKnight_Entity bulletPrefab;

		public AudioClip shootSound;

		public string fireRateBuff = "";

		public virtual bool Shoot(App_SolarKnight_Entity entity, Vector3 spawnPoint, Vector3 forward, App_SolarKnight_Player player, float fireRateBuffBonus = 0f)
		{
			if (player != null)
			{
				float num = 0f;
				if (fireRateBuff != "")
				{
					num = player.GetStatBuff(fireRateBuff);
				}
				if (Time.time - lastShotTime < shootCooldown / (1f + player.GetStatBuff("fireRate") + num + fireRateBuffBonus))
				{
					return false;
				}
			}
			else if (Time.time - lastShotTime < shootCooldown / (1f + fireRateBuffBonus))
			{
				return false;
			}
			lastShotTime = Time.time;
			for (int i = 0; i < shotAmount; i++)
			{
				Vector3 vector = (Vector3)UnityEngine.Random.insideUnitCircle * shootSpread;
				Vector3 normalized = (forward.normalized + vector).normalized;
				App_SolarKnight_Entity app_SolarKnight_Entity = UnityEngine.Object.Instantiate(bulletPrefab, spawnPoint + forward * 0.5f, Quaternion.LookRotation(Vector3.forward, normalized), App_SolarKnight_World.instance.transform);
				float num2 = shootVelocity + UnityEngine.Random.Range(0f - shootVelocityVariance, shootVelocityVariance);
				app_SolarKnight_Entity.AddVelocity(normalized * num2);
				entity.AddIgnoreObject(app_SolarKnight_Entity.gameObject);
				app_SolarKnight_Entity.AddIgnoreObject(entity.gameObject);
				app_SolarKnight_Entity.tags.Add("bullet");
				app_SolarKnight_Entity.AddIgnoreTag("bullet");
				app_SolarKnight_Entity.sprite.color = shootColor;
				app_SolarKnight_Entity.lifeTime = projectileLifetime;
			}
			App_SolarKnight_World.instance.PlaySound(shootSound, 0.5f);
			return true;
		}

		public virtual WeaponInfo GetCopy()
		{
			return new WeaponInfo
			{
				id = id,
				shootCooldown = shootCooldown,
				shootVelocity = shootVelocity,
				shootSpread = shootSpread,
				bulletPrefab = bulletPrefab,
				shootSound = shootSound,
				shotAmount = shotAmount,
				shootVelocityVariance = shootVelocityVariance,
				shootColor = shootColor
			};
		}
	}

	public float moveSpeed = 10f;

	public float rotateSpeed = 5f;

	private float rotation;

	public List<HardpointInfo> hardpoints = new List<HardpointInfo>();

	public App_SolarKnight_Weapon defaultWeapon;

	public List<ParticleSystem> movementParticles;

	public ParticleSystem thrustParticle;

	public List<Transform> bulletSpawnPoints;

	private int currentBulletSpawnIndex;

	public AudioClip shootSound;

	private List<Upgrade> appliedUpgrades = new List<Upgrade>();

	private void Start()
	{
		InitializePlayer();
	}

	public void InitializePlayer()
	{
		foreach (HardpointInfo hardpoint in hardpoints)
		{
			hardpoint.ClearAllWeapons();
		}
		hardpoints[0].AddWeapon(defaultWeapon.weaponInfo.GetCopy());
	}

	private void Update()
	{
		if (!App_SolarKnight_World.instance.GetApp().IsPaused() && InputManager.GetButton("Jump").Pressed)
		{
			Shoot();
		}
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}

	public override void Movement()
	{
		if (App_SolarKnight_World.instance.GetApp().IsPaused())
		{
			return;
		}
		Vector3 vector = new Vector3(InputManager.GetVector("Move").vector.x, InputManager.GetVector("Move").vector.y, 0f);
		if (vector.y > 0f)
		{
			float num = moveSpeed + GetStatBuff("shipSpeed");
			velocity += base.transform.up * vector.y * num * App_SolarKnight_World.gameFixedDeltaTime;
			if (!thrustParticle.isPlaying)
			{
				thrustParticle.Play();
			}
		}
		else
		{
			thrustParticle.Stop();
		}
		rotation += rotateSpeed * (0f - vector.x) * App_SolarKnight_World.gameFixedDeltaTime;
		if (vector.y < 0f && velocity.magnitude > 0f)
		{
			float target = Mathf.Atan2(0f - velocity.y, 0f - velocity.x) * 57.29578f - 90f;
			float num2 = Mathf.DeltaAngle(rotation, target);
			rotation += num2 * 2f * App_SolarKnight_World.gameFixedDeltaTime;
		}
		base.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, rotation));
		base.Movement();
	}

	public void Shoot()
	{
		foreach (HardpointInfo hardpoint in hardpoints)
		{
			hardpoint.Shoot(this, this);
		}
	}

	public override void OnTeleport()
	{
		base.OnTeleport();
		foreach (ParticleSystem movementParticle in movementParticles)
		{
			movementParticle.Clear();
			movementParticle.Play();
		}
	}

	public override void Kill(bool spawnDrops = true)
	{
		App_SolarKnight_World.instance.GetApp().LoseLife();
		App_SolarKnight_World.instance.AddScore(destroyScore);
		if (destroySound != null)
		{
			App_SolarKnight_World.instance.PlaySound(destroySound, 0.5f);
		}
		if (deathParticle != "")
		{
			App_SolarKnight_World.instance.PlayParticle(deathParticle, base.transform.position, 7);
		}
		if (spawnDrops)
		{
			SpawnDrops();
		}
		base.gameObject.SetActive(value: false);
	}

	internal void ApplyUpgrade(Upgrade upgrade)
	{
		Upgrade copy = upgrade.GetCopy();
		appliedUpgrades.Add(copy);
		copy.InitializeUpgrade(this);
	}

	internal void RemoveUpgrade(Upgrade upgrade)
	{
		appliedUpgrades.Remove(upgrade);
	}

	public bool HasUpgradeWithName(string upgradeName)
	{
		foreach (Upgrade appliedUpgrade in appliedUpgrades)
		{
			if (appliedUpgrade.name == upgradeName)
			{
				return true;
			}
		}
		return false;
	}

	public void AddWeaponToHardpoint(string hardpointID, WeaponInfo weapon)
	{
		foreach (HardpointInfo hardpoint in hardpoints)
		{
			if (hardpoint.id == hardpointID)
			{
				hardpoint.AddWeapon(weapon);
				break;
			}
		}
	}

	public void AddWeaponToHardpointsWithTag(string hardpointTag, WeaponInfo weapon)
	{
		foreach (HardpointInfo hardpoint in hardpoints)
		{
			if (hardpoint.tag == hardpointTag)
			{
				hardpoint.AddWeapon(weapon);
			}
		}
	}

	public void RemoveAllWeaponsFromHardpointsWithTag(string hardpointTag, string weaponID)
	{
		foreach (HardpointInfo hardpoint in hardpoints)
		{
			if (hardpoint.tag == hardpointTag)
			{
				hardpoint.RemoveWeaponByID(weaponID);
			}
		}
	}

	public void RemoveAllWeaponsWithId(string weaponID)
	{
		foreach (HardpointInfo hardpoint in hardpoints)
		{
			hardpoint.RemoveWeaponByID(weaponID);
		}
	}

	public float GetStatBuff(string statName)
	{
		float num = 0f;
		foreach (Upgrade appliedUpgrade in appliedUpgrades)
		{
			foreach (Upgrade.BuffInfo buff in appliedUpgrade.buffs)
			{
				if (buff.statName == statName)
				{
					num += buff.buffAmount;
				}
			}
		}
		return num;
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		foreach (HardpointInfo hardpoint in hardpoints)
		{
			foreach (Vector3 hardpointPosition in hardpoint.hardpointPositions)
			{
				Vector3 vector = base.transform.TransformPoint(hardpointPosition);
				Draw.Arrow(vector, vector + base.transform.TransformVector(hardpoint.hardpointForward), Color.cyan);
			}
		}
	}
}
