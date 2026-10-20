using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_LookTrigger : MonoBehaviourGizmos
{
	public float maxAngle = 90f;

	[Tooltip("If you want it to detect if the player is looking away.")]
	public bool triggerIfPlayerLooksAway;

	public float minDistance;

	public float maxDistance = 10f;

	public bool checkOnUpdate = true;

	public bool runOnce;

	public UnityEvent onLookAt;

	public UnityEvent onLookAway;

	public UnityEvent onLookAwayWhileInZone;

	public UnityEvent<float> visibilityEvent;

	[Header("Facing Angle")]
	public bool useFacingAngle;

	public float facingAngle = 180f;

	[Header("Raycast")]
	public bool useRaycast;

	public LayerMask raycastMask;

	public bool hitBackface;

	private bool isLooking;

	private bool hasLooked;

	private float checkTime;

	[Header("Debug")]
	public bool showDebug;

	private float visibility = 1f;

	private float curVisibility;

	public float visibilityChangeRate = 1f;

	private bool hasLookedAwayWhileInZone;

	private void Update()
	{
		if (checkOnUpdate)
		{
			if (checkTime <= 0f)
			{
				checkTime = 0.05f;
				LookCheck();
			}
			checkTime -= Time.deltaTime;
		}
		if (showDebug && CL_UIManager.debug)
		{
			CL_DebugView.draw.Label2D(base.transform.position, (isLooking ? "Can See" : "Cannot See") + " :: " + base.name, 14f, LabelAlignment.Center, isLooking ? Color.green : Color.red);
		}
		curVisibility = Mathf.Lerp(curVisibility, visibility, Time.deltaTime * visibilityChangeRate);
		visibilityEvent.Invoke(curVisibility);
	}

	public void LookCheck()
	{
		if (runOnce && hasLooked)
		{
			return;
		}
		CL_CameraControl camRoot = ENT_Player.playerObject.camRoot;
		float num = Vector3.Distance(base.transform.position, ENT_Player.playerObject.camRoot.transform.position);
		visibility = 1f;
		if (useFacingAngle)
		{
			Vector3 normalized = (camRoot.transform.position - base.transform.position).normalized;
			float num2 = Vector3.Angle(base.transform.forward, normalized);
			if (showDebug && CL_UIManager.debug)
			{
				CL_DebugView.draw.Label2D(base.transform.position + Vector3.up * 0.5f, "Facing Angle" + num2 + " :: " + base.name, 14f, LabelAlignment.Center, isLooking ? Color.green : Color.red);
			}
			if (num2 > facingAngle)
			{
				if (isLooking)
				{
					isLooking = false;
					onLookAway.Invoke();
				}
				visibility = 0f;
				return;
			}
		}
		if (num < minDistance || num > maxDistance)
		{
			if (isLooking)
			{
				isLooking = false;
				onLookAway.Invoke();
			}
			visibility = 0f;
		}
		else if (ENT_Player.playerObject.camRoot.CanSeeTarget(base.transform, maxAngle))
		{
			if (useRaycast)
			{
				Physics.queriesHitBackfaces = hitBackface;
				if (Physics.Linecast(camRoot.transform.position, base.transform.position, out var hitInfo, raycastMask) && hitInfo.collider.transform != base.transform)
				{
					if (isLooking)
					{
						isLooking = false;
						onLookAway.Invoke();
					}
					visibility = 0f;
					return;
				}
				Physics.queriesHitBackfaces = false;
			}
			if (!isLooking)
			{
				isLooking = true;
				hasLookedAwayWhileInZone = false;
				onLookAt.Invoke();
				hasLooked = true;
			}
		}
		else
		{
			if (!hasLookedAwayWhileInZone)
			{
				onLookAwayWhileInZone.Invoke();
				hasLookedAwayWhileInZone = true;
			}
			if (isLooking)
			{
				isLooking = false;
				onLookAway.Invoke();
			}
			visibility = 0f;
		}
	}

	public void ResetState()
	{
		hasLooked = false;
		isLooking = false;
	}

	public bool isLookingAt()
	{
		return isLooking;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1f, 0f, 0f, 0.2f);
		Gizmos.DrawIcon(base.transform.position, "gizmo-eye");
		Gizmos.DrawWireSphere(base.transform.position, maxDistance);
		Gizmos.DrawWireSphere(base.transform.position, minDistance);
		if (useFacingAngle)
		{
			float num = Mathf.Cos(facingAngle * 2f * 0.00872665f);
			float num2 = Mathf.Sin(facingAngle * 2f * 0.00872665f);
			Gizmos.color = new Color(1f, 0.5f, 0f, 0.4f);
			Gizmos.DrawRay(base.transform.position, base.transform.forward * maxDistance);
			Gizmos.DrawRay(base.transform.position, (base.transform.right * num2 + base.transform.forward * num) * maxDistance);
			Gizmos.DrawRay(base.transform.position, (base.transform.right * (0f - num2) + base.transform.forward * num) * maxDistance);
			Gizmos.DrawRay(base.transform.position, (base.transform.up * (0f - num2) + base.transform.forward * num) * maxDistance);
			Gizmos.DrawRay(base.transform.position, (base.transform.up * num2 + base.transform.forward * num) * maxDistance);
		}
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		DarkMachineFunctions.RenderUnityEvent(ref Draw.editor, base.transform, new List<DarkMachineFunctions.RenderUnityEventDesc>
		{
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = onLookAt,
				prependString = "On Look At: ",
				color = Color.green
			},
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = onLookAway,
				prependString = "On Look Away: ",
				color = Color.red
			},
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = visibilityEvent,
				prependString = "When Visible: ",
				color = Color.yellow
			}
		});
	}
}
