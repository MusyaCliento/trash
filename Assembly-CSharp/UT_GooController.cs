using UnityEngine;

public class UT_GooController : MonoBehaviour
{
	public float raiseOverTimeMultiplier = 1f;

	public void ResetAffectors()
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.StopAllCoroutines();
		}
	}

	public void SetSpeedMult(float s = 1f)
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.SetSpeedMultiplier(s);
		}
	}

	public void SetSpeed(float s)
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.SetSpeed(s);
		}
	}

	public void SetHeightRelativeToController(float h)
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.SetHeightRelativeToTransform(h, base.transform);
		}
	}

	public void SetHeightRelativeToControllerIfAbove(float h)
	{
		if (!(DEN_DeathFloor.instance == null) && DEN_DeathFloor.instance.transform.position.y > base.transform.position.y + h)
		{
			DEN_DeathFloor.instance.SetHeightRelativeToTransform(h, base.transform);
		}
	}

	public void MoveToTransformHeight(Transform t)
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.MoveToHeightOfTransform(t);
		}
	}

	public void RaiseOverTime(float amount)
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.RaiseOverTime(amount * raiseOverTimeMultiplier);
		}
	}

	public void SetHeight(float h)
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.SetHeight(h);
		}
	}

	public void SetSpeedIncreaseMultiplier(float m)
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.SetSpeedIncreaseMultiplier(m);
		}
	}

	public void AdjustSpeed(float s)
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.AdjustSpeed(s);
		}
	}

	public void SetTargetVolume(float v)
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.SetTargetVolume(v);
		}
	}

	public void SetActive(bool b)
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.SetActive(b);
		}
	}

	public void SetRubberbandActive(bool b)
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.SetRubberbandActive(b);
		}
	}

	public void SetGooObjectActive(bool b)
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			DEN_DeathFloor.instance.gameObject.SetActive(b);
		}
	}

	public void DestroyMass()
	{
		if (!(DEN_DeathFloor.instance == null))
		{
			Object.Destroy(DEN_DeathFloor.instance.gameObject);
			DEN_DeathFloor.instance = null;
		}
	}
}
