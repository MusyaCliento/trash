using System;
using UnityEngine;

public class Listener_Core
{
	public class ListenEvent
	{
		public string tag;

		public Vector3 position;

		public float distance;

		public float volume = 1f;
	}

	public Func<Vector3> GetPosition;

	public Action<ListenEvent> _OnCatchSound;

	public void Activate()
	{
		AudioManager.AddListener(this);
	}

	public void Deactivate()
	{
		AudioManager.RemoveListener(this);
	}

	public virtual void CatchSound(ListenEvent listenEvent)
	{
		_OnCatchSound(listenEvent);
	}
}
