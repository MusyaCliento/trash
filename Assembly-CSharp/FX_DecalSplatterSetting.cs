using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "White Knuckle/Effects/Decal Splatter Setting")]
public class FX_DecalSplatterSetting : ScriptableObject
{
	public List<FX_DecalShared> decals;

	public float radius;

	public float randomAngle = 180f;

	public LayerMask hitMask;

	public int amount = 5;

	public Color splatterColor = Color.white;

	private (float scale, float time)[] scaleEffect = new(float, float)[2]
	{
		(0.1f, 0f),
		(1f, 0.15f)
	};

	public void Spray(Vector3 position, Vector3 forward, float amountMult = 1f)
	{
		if (decals == null || decals.Count <= 0)
		{
			return;
		}
		for (int i = 0; (float)i < (float)amount * amountMult; i++)
		{
			FX_DecalShared shared = decals[Random.Range(0, decals.Count)];
			Vector3 up = Quaternion.Euler(Vector3.one * randomAngle) * forward;
			if (Physics.Raycast(position, (forward + Random.insideUnitSphere).normalized, out var hitInfo, radius, hitMask))
			{
				FXManager.DecalHandle handle = FXManager.DecalCreate(FXManager.DecalPriority.Low);
				FXManager.DecalSharedApply(handle, FXManager.DecalSharedData(shared));
				FXManager.DecalPointingFrom(handle, hitInfo.point, hitInfo.normal, up, (hitInfo.collider != null) ? hitInfo.collider.transform : null);
				FXManager.DecalScaleEffect(handle, scaleEffect);
				FXManager.DecalColor(handle, splatterColor);
			}
		}
	}

	public FX_DecalShared GetRandomDecal()
	{
		return decals[Random.Range(0, decals.Count)];
	}
}
