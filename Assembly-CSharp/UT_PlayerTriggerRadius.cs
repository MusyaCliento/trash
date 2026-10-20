using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_PlayerTriggerRadius : MonoBehaviourGizmos
{
	public float playerVicinity = 10f;

	public UnityEvent enterEvent;

	public UnityEvent exitEvent;

	public bool runOnce = true;

	private bool hasRun;

	private bool isInside;

	private void FixedUpdate()
	{
		if ((runOnce && hasRun) || CL_GameManager.gMan == null || !(CL_GameManager.gMan.localPlayer != null))
		{
			return;
		}
		if (CL_GameManager.gMan.PlayerDistance(base.transform.position) > playerVicinity)
		{
			if (isInside)
			{
				isInside = false;
				exitEvent.Invoke();
			}
		}
		else if (!isInside)
		{
			isInside = true;
			RunEvent();
		}
	}

	private void RunEvent()
	{
		hasRun = true;
		enterEvent.Invoke();
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.SphereOutline(base.transform.position, playerVicinity, new Color(1f, 0.561f, 0f, 0.25f));
		}
		else
		{
			Draw.SphereOutline(base.transform.position, playerVicinity, new Color(1f, 0.561f, 0f, 0.003f));
		}
		DarkMachineFunctions.RenderUnityEvent(ref Draw.editor, base.transform, new List<DarkMachineFunctions.RenderUnityEventDesc>
		{
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = enterEvent,
				prependString = "On Enter: ",
				color = Color.green
			},
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = exitEvent,
				prependString = "On Exit: ",
				color = Color.red
			}
		});
	}
}
