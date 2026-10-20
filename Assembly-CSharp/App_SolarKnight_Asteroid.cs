using System;
using System.Collections.Generic;
using UnityEngine;

public class App_SolarKnight_Asteroid : App_SolarKnight_Entity
{
	public int size = 4;

	public List<Sprite> asteroidSprites;

	public int fragmentCount = 2;

	public float spriteScale = 2f;

	private void Start()
	{
		sprite.sprite = asteroidSprites[UnityEngine.Random.Range(0, asteroidSprites.Count)];
		health = size;
		mass = size * 2;
		GetCollider().radius = (float)size / 8f - 0.1f;
		sprite.transform.localScale = Vector3.one * ((float)size * spriteScale);
		mass = size * 2;
		App_SolarKnight_World.instance.curAsteroidCount++;
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		if (velocity.magnitude < 0.001f)
		{
			AddVelocity(new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0f).normalized * 0.1f);
		}
	}

	public override void Kill(bool spawnDrops = true)
	{
		if (size > 1 && App_SolarKnight_World.instance.curAsteroidCount < 40 && !IsDestroyed() && spawnDrops)
		{
			float num = MathF.PI * (3f - Mathf.Sqrt(5f));
			float num2 = GetCollider().radius * 0.5f * 3.05f;
			for (int i = 0; i < fragmentCount; i++)
			{
				float f = (float)i * num;
				float num3 = num2 * Mathf.Sqrt(i);
				Vector3 vector = new Vector3(Mathf.Cos(f), Mathf.Sin(f), 0f) * num3;
				App_SolarKnight_Asteroid app_SolarKnight_Asteroid = UnityEngine.Object.Instantiate(this, base.transform.position + vector, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0, 360)), base.transform.parent);
				app_SolarKnight_Asteroid.size = size - 1;
				app_SolarKnight_Asteroid.health = app_SolarKnight_Asteroid.size;
				app_SolarKnight_Asteroid.mass /= 2f;
				GetCollider().radius = (float)size / 8f - 0.1f;
				app_SolarKnight_Asteroid.sprite.transform.localScale = Vector3.one * ((float)size * spriteScale);
				app_SolarKnight_Asteroid.angularVelocity = angularVelocity + UnityEngine.Random.Range(-10f, 10f);
				app_SolarKnight_Asteroid.AddVelocity(velocity + vector.normalized * UnityEngine.Random.Range(2f, 5f));
				app_SolarKnight_Asteroid.enabled = true;
			}
		}
		base.Kill(spawnDrops);
	}

	public override void SpawnDrops()
	{
		if (size <= 1)
		{
			base.SpawnDrops();
		}
	}

	public override void OnDestroy()
	{
		App_SolarKnight_World.instance.curAsteroidCount--;
		base.OnDestroy();
	}
}
