using UnityEngine;
using UnityEngine.Events;

public class UT_RandomTimer : MonoBehaviour
{
	public float randomMin;

	public float randomMax = 1f;

	private float timer;

	public bool runOnAwake;

	public bool repeat = true;

	private bool running;

	public UnityEvent runEvent;

	private void Awake()
	{
		if (runOnAwake)
		{
			running = true;
		}
		timer = Random.Range(randomMin, randomMax);
	}

	private void Update()
	{
		if (CL_GameManager.gMan.isPaused || !running)
		{
			return;
		}
		timer -= Time.deltaTime;
		if (timer <= 0f)
		{
			if (repeat)
			{
				Play(reset: true);
			}
			else
			{
				running = false;
			}
			runEvent.Invoke();
		}
	}

	public void Play(bool reset = false)
	{
		running = true;
		if (reset)
		{
			Reset();
		}
	}

	public void Pause()
	{
		running = false;
	}

	public void Reset()
	{
		timer = Random.Range(randomMin, randomMax);
	}
}
