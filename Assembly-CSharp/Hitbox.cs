using UnityEngine;

public interface Hitbox
{
	GameEntity GetGameEntity();

	GameObject GetGameObject();

	bool Damage(Damageable.DamageInfo info);
}
