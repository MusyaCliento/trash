using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class ENV_RadioEmitter : MonoBehaviourGizmos
{
	public static List<ENV_RadioEmitter> activeEmitters;

	public float radius;

	public AnimationCurve qualityRadius = AnimationCurve.Linear(1f, 1f, 0f, 0f);

	private bool isInRange;

	private float checkTime;

	public ENV_RadioStation station;

	public bool force;

	private float currentPlayerDistance = float.PositiveInfinity;

	private void OnEnable()
	{
		if (activeEmitters == null)
		{
			activeEmitters = new List<ENV_RadioEmitter>();
		}
	}

	private void OnDisable()
	{
		if (activeEmitters.Contains(this))
		{
			activeEmitters.Remove(this);
		}
	}

	private void Update()
	{
		if (checkTime <= 0f)
		{
			checkTime = Random.value * 0.5f + 0.5f;
			currentPlayerDistance = Vector3.Distance(base.transform.position, ENT_Player.GetPlayer().transform.position);
			if (currentPlayerDistance < radius)
			{
				if (!isInRange && !activeEmitters.Contains(this))
				{
					activeEmitters.Add(this);
				}
				isInRange = true;
				station.curQuality = GetCurrentQuality();
			}
			else if (isInRange)
			{
				isInRange = false;
				if (activeEmitters.Contains(this))
				{
					activeEmitters.Remove(this);
				}
			}
		}
		checkTime -= Time.deltaTime;
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.WireSphere(base.transform.position, radius);
			CL_DebugView.draw.Label2D(base.transform.position, station.stationName + " :: " + isInRange + " :: " + GetCurrentQuality(), 12f, Color.white);
		}
	}

	public static List<ENV_RadioEmitter> GetActiveEmitters()
	{
		return activeEmitters;
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.WireSphere(base.transform.position, radius, Color.white);
		}
		else
		{
			Draw.WireSphere(base.transform.position, radius, new Color(0.5f, 0.5f, 0.5f, 0.5f));
		}
	}

	public float GetCurrentQuality()
	{
		return qualityRadius.Evaluate(Mathf.Clamp01(currentPlayerDistance / radius));
	}
}
