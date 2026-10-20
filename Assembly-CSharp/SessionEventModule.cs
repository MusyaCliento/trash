using System;
using UnityEngine;

[Serializable]
public class SessionEventModule
{
	public string name;

	internal SessionEvent sessionEvent;

	internal SessionEventModule parentEvent;

	public virtual void Initialize(SessionEvent s)
	{
		sessionEvent = s;
		Debug.Log("Initialized Session event " + name);
	}

	public virtual void OnModuleStart()
	{
	}

	public virtual void OnModuleDestroy()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void LateUpdate()
	{
	}

	public virtual void OnCameraRender(Camera cam)
	{
	}

	public virtual void SetParentEvent(SessionEventModule m)
	{
		parentEvent = m;
	}

	public virtual void SendMessage(string m)
	{
	}

	public virtual void Activate()
	{
	}
}
