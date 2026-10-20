using System;
using TMPro;
using UnityEngine;

public class Event_HerDomain : MonoBehaviour
{
	public float timerLength = 1800f;

	public TMP_Text timerText;

	private float timer;

	private bool timerIsRunning;

	private float eventTimer;

	private void Start()
	{
		timer = timerLength;
	}

	private void Update()
	{
		if (timerIsRunning)
		{
			timer -= Time.deltaTime;
			TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
			timerText.text = timeSpan.ToString("mm\\:ss");
		}
	}

	public void RunTimer()
	{
		timerIsRunning = true;
	}
}
