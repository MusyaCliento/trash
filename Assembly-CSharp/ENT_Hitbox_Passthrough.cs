using UnityEngine;

[RequireComponent(typeof(ObjectTagger))]
public class ENT_Hitbox_Passthrough : MonoBehaviour, Damageable, Hitbox, Blinkable
{
	public ENT_Hitbox targetHitbox;

	public float amountMultiplier = 1f;

	private bool isDead;

	public bool Damage(Damageable.DamageInfo info)
	{
		info.amount *= amountMultiplier;
		return targetHitbox.Damage(info);
	}

	public GameEntity GetGameEntity()
	{
		return targetHitbox.GetGameEntity();
	}

	public GameObject GetGameObject()
	{
		return targetHitbox.GetGameObject();
	}

	private void Update()
	{
		if (!isDead && targetHitbox.GetGameEntity().dead)
		{
			if (TryGetComponent<ObjectTagger>(out var component))
			{
				component.AddTag("Dead");
			}
			isDead = true;
		}
	}
}
