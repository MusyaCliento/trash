using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SessionEventModule_CameraDirectionCheck : SessionEventModule
{
	public Vector3 direction;

	public bool relativeToCameraAtInitialize = true;

	public float maxAngle;

	private Vector3 startDirection;

	private Vector3 targetDirection;

	[SerializeReference]
	public List<SessionEventModule> modulesOnCheck;

	private bool hasTriggered;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		hasTriggered = false;
		Transform transform = ENT_Player.playerObject.cam.transform;
		startDirection = transform.forward;
		if (relativeToCameraAtInitialize)
		{
			targetDirection = transform.TransformVector(direction);
		}
		else
		{
			targetDirection = direction;
		}
	}

	public override void Update()
	{
		base.Update();
		if (hasTriggered || !(Vector3.Angle(ENT_Player.playerObject.cam.transform.forward, targetDirection) < maxAngle))
		{
			return;
		}
		hasTriggered = true;
		foreach (SessionEventModule item in modulesOnCheck)
		{
			sessionEvent.AddModule(item);
		}
	}
}
