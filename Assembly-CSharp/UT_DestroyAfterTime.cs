using UnityEngine;

public class UT_DestroyAfterTime : MonoBehaviour
{
	public float destroyTime = 10f;

	public GameObject deathObject;

	public bool disableAfterTime;

	private float time;

	private void Start()
	{
		time = destroyTime;
	}

	private void Update()
	{
		if (CL_GameManager.gMan.isPaused)
		{
			return;
		}
		time -= Time.deltaTime;
		if (time <= 0f)
		{
			if ((bool)deathObject)
			{
				Object.Instantiate(deathObject, base.transform.position, base.transform.rotation, base.transform.parent);
			}
			if (!disableAfterTime)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}

	public void ResetTimer()
	{
		time = destroyTime;
	}
}
