using UnityEngine;

public class UT_Spin : MonoBehaviour, Flippable
{
	public bool local;

	public Vector3 rotate;

	public bool spinning = true;

	private Vector3 curRotate = Vector3.zero;

	private int dir = 1;

	public float acceleration = 1f;

	private Quaternion initialRotation;

	public float multiplier = 1f;

	[Header("Audio")]
	public AudioSource audioSource;

	public float audioVolume = 1f;

	public float audioPitch = 1f;

	private void Start()
	{
		if (local)
		{
			initialRotation = base.transform.localRotation;
		}
		else
		{
			initialRotation = base.transform.rotation;
		}
		if (spinning)
		{
			curRotate = rotate * multiplier;
		}
	}

	private void Update()
	{
		if (!CL_GameManager.gMan.isPaused)
		{
			if (!spinning)
			{
				curRotate = Vector3.Lerp(curRotate, Vector3.zero, Time.deltaTime * acceleration);
			}
			else
			{
				curRotate = Vector3.Lerp(curRotate, rotate * multiplier, Time.deltaTime * acceleration);
			}
			if (local)
			{
				base.transform.localRotation *= Quaternion.Euler(curRotate * Time.deltaTime * dir);
			}
			else
			{
				base.transform.rotation *= Quaternion.Euler(curRotate * Time.deltaTime * dir);
			}
			if (audioSource != null)
			{
				audioSource.pitch = curRotate.magnitude / rotate.magnitude * audioPitch;
				audioSource.volume = curRotate.magnitude / rotate.magnitude * audioVolume;
			}
		}
	}

	public void SetSpin(Vector3 s)
	{
		rotate = s;
	}

	public void SetSpinning(bool b)
	{
		spinning = b;
		if ((bool)audioSource)
		{
			if (spinning)
			{
				audioSource.Play();
			}
			else
			{
				audioSource.Stop();
			}
		}
	}

	public void ToggleSpin()
	{
		SetSpinning(!spinning);
	}

	public void Revert()
	{
		if (local)
		{
			base.transform.localRotation = initialRotation;
		}
		else
		{
			base.transform.rotation = initialRotation;
		}
	}

	public void SetMultiplier(float f)
	{
		multiplier = f;
	}

	public void Reverse()
	{
		multiplier = 0f - multiplier;
	}

	public void OnFlip(bool flipped)
	{
		if (flipped)
		{
			dir = -1;
		}
	}
}
