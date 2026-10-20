using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UT_HeightCheck : MonoBehaviour
{
	public bool relative;

	public float height;

	private float targetHeight;

	public bool triggerWhenAbove = true;

	private bool triggered;

	public UnityEvent triggerEvent;

	private void Start()
	{
		StartCoroutine(WaitToStart());
		IEnumerator WaitToStart()
		{
			triggered = true;
			yield return new WaitForSeconds(0.5f);
			ResetTarget();
		}
	}

	private void Update()
	{
		if (!triggered)
		{
			if (base.transform.position.y > targetHeight && triggerWhenAbove)
			{
				triggerEvent.Invoke();
				triggered = true;
			}
			else if (!triggerWhenAbove && base.transform.position.y < targetHeight)
			{
				triggerEvent.Invoke();
				triggered = true;
			}
		}
	}

	public void ResetTarget()
	{
		Debug.Log("Is this resetting?");
		triggered = false;
		if (relative)
		{
			targetHeight = base.transform.position.y + height;
		}
		else
		{
			targetHeight = height;
		}
	}
}
