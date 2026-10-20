using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-15)]
public class VEH_ControlSeat : MonoBehaviour
{
	public bool canTakeOverPlayerPosition;

	public bool canTakeOverPlayerRotation;

	public Transform playerTakeOverTransform;

	public Transform playerExitTransform;

	private bool isControlled;

	public UnityEvent OnControlStartEvent;

	public UnityEvent OnControlEndEvent;

	public List<string> interactWhitelist;

	private Quaternion lastRotation;

	public void StartControl()
	{
		if (!isControlled)
		{
			isControlled = true;
			OnControlStartEvent.Invoke();
			ENT_Player.GetPlayer().LockMovementInput();
			ENT_Player.GetPlayer().cCon.enabled = false;
			if (interactWhitelist != null && interactWhitelist.Count > 0)
			{
				ENT_Player.GetPlayer().SetInteractWhitelist(interactWhitelist);
			}
		}
	}

	public void EndControl()
	{
		if (isControlled)
		{
			isControlled = false;
			OnControlEndEvent.Invoke();
			ENT_Player.GetPlayer().UnLock();
			ENT_Player.GetPlayer().StopInteractWhitelist();
			ENT_Player.GetPlayer().cCon.enabled = true;
			ENT_Player.GetPlayer().transform.position = playerExitTransform.position;
			ENT_Player.GetPlayer().transform.rotation = Quaternion.identity;
		}
	}

	private void LateUpdate()
	{
		if (isControlled)
		{
			if (canTakeOverPlayerPosition)
			{
				ENT_Player.GetPlayer().MovePlayerToPosition(playerTakeOverTransform.position);
			}
			if (canTakeOverPlayerRotation)
			{
				Quaternion quaternion = playerTakeOverTransform.rotation * Quaternion.Inverse(lastRotation);
				ENT_Player.GetPlayer().transform.rotation *= quaternion;
				Quaternion rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(ENT_Player.GetPlayer().transform.forward, base.transform.up), base.transform.up);
				ENT_Player.GetPlayer().transform.rotation = rotation;
			}
		}
		lastRotation = playerTakeOverTransform.rotation;
	}
}
