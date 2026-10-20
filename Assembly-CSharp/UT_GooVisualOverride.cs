using UnityEngine;

public class UT_GooVisualOverride : MonoBehaviour
{
	private void OnEnable()
	{
		if (!(DEN_DeathFloor.currentGooVisualOverride != null) || !(DEN_DeathFloor.currentGooVisualOverride != this))
		{
			DEN_DeathFloor.currentGooVisualOverride = this;
			if (DEN_DeathFloor.instance != null)
			{
				DEN_DeathFloor.instance.SetVisualActive(b: false);
			}
		}
	}

	private void OnDisable()
	{
		if (DEN_DeathFloor.currentGooVisualOverride != null && DEN_DeathFloor.currentGooVisualOverride == this)
		{
			DEN_DeathFloor.currentGooVisualOverride = null;
			if (DEN_DeathFloor.instance != null)
			{
				DEN_DeathFloor.instance.SetVisualActive(b: true);
			}
		}
	}

	private void LateUpdate()
	{
		if (DEN_DeathFloor.instance != null)
		{
			Vector3 position = DEN_DeathFloor.instance.transform.position;
			position.x = base.transform.position.x;
			position.z = base.transform.position.z;
			base.transform.position = position;
		}
	}
}
