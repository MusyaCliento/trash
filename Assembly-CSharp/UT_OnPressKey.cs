using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UT_OnPressKey : MonoBehaviour
{
	[Serializable]
	public class KeyEvent
	{
		public bool useKeycode = true;

		public string key;

		public int tapsRequired;

		public UnityEvent keyDownEvent;

		public UnityEvent keyUpEvent;

		private int taps;

		private float lastPressTime;

		public void CheckPress()
		{
			bool flag = false;
			if (useKeycode)
			{
				if (Input.GetKeyDown(key))
				{
					flag = true;
					if (tapsRequired <= taps)
					{
						keyDownEvent.Invoke();
					}
				}
				if (Input.GetKeyUp(key) && tapsRequired <= taps)
				{
					keyUpEvent.Invoke();
				}
			}
			else
			{
				if (InputManager.GetButton(key).Down)
				{
					flag = true;
					lastPressTime = Time.time;
					if (tapsRequired <= taps)
					{
						keyDownEvent.Invoke();
					}
				}
				if (InputManager.GetButton(key).Up && tapsRequired <= taps)
				{
					keyUpEvent.Invoke();
				}
			}
			if (!flag)
			{
				return;
			}
			if (Time.time - lastPressTime < 0.4f)
			{
				if (taps > tapsRequired)
				{
					taps = 0;
				}
				else
				{
					taps++;
				}
			}
			else
			{
				taps = 0;
			}
			lastPressTime = Time.time;
		}
	}

	public List<KeyEvent> events;

	private void Update()
	{
		foreach (KeyEvent @event in events)
		{
			@event.CheckPress();
		}
	}
}
