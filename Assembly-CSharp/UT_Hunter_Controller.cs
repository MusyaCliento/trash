using System;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_Hunter_Controller : MonoBehaviourGizmos
{
	public enum HunterCommand
	{
		none = 0,
		freeze = 1,
		kill = 2,
		detect = 3,
		doorBlock = 4,
		clampMotionToLinear = 5,
		spawn = 6,
		safety = 7
	}

	public bool active;

	public float hunterActivationRadius = 20f;

	public HunterCommand currentCommand;

	private List<DEN_Hunter> effectingHunters = new List<DEN_Hunter>();

	public UnityEvent<DEN_Hunter> onDetectHunter;

	public UnityEvent<DEN_Hunter> onLoseHunter;

	public DEN_Hunter hunterPrefab;

	public float doorBlockEventRate = 1f;

	public UnityEvent doorBlockEvent;

	public UnityEvent hunterEnterEvent;

	public UnityEvent deactivateEvent;

	public UnityEvent activateEvent;

	public Transform moveHunterTo;

	private float lastDoorBlockEventTime;

	private bool isBlocking;

	public Vector3 linearVector;

	public float linearForceMult = 10f;

	private static Action _StopHunter;

	private void OnEnable()
	{
		_StopHunter = (Action)Delegate.Combine(_StopHunter, new Action(StopAction));
	}

	private void OnDisable()
	{
		_StopHunter = (Action)Delegate.Remove(_StopHunter, new Action(StopAction));
	}

	private void Update()
	{
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Label2D(base.transform.position, "Hunter Controller Active: " + active, Color.cyan);
		}
		if (!active)
		{
			return;
		}
		int count = effectingHunters.Count;
		if (currentCommand == HunterCommand.freeze)
		{
			foreach (DEN_Hunter activeHunter in DEN_Hunter.activeHunters)
			{
				if (Vector3.Distance(activeHunter.transform.position, base.transform.position) <= hunterActivationRadius && !effectingHunters.Contains(activeHunter))
				{
					activeHunter.SetFrozen(f: true);
					effectingHunters.Add(activeHunter);
					onDetectHunter.Invoke(activeHunter);
				}
			}
		}
		else if (currentCommand == HunterCommand.kill)
		{
			foreach (DEN_Hunter activeHunter2 in DEN_Hunter.activeHunters)
			{
				if (Vector3.Distance(activeHunter2.transform.position, base.transform.position) <= hunterActivationRadius)
				{
					activeHunter2.Kill("", null);
					onDetectHunter.Invoke(activeHunter2);
				}
			}
		}
		else if (currentCommand == HunterCommand.detect)
		{
			foreach (DEN_Hunter activeHunter3 in DEN_Hunter.activeHunters)
			{
				float num = Vector3.Distance(activeHunter3.transform.position, base.transform.position);
				if (num <= hunterActivationRadius && !effectingHunters.Contains(activeHunter3))
				{
					effectingHunters.Add(activeHunter3);
					onDetectHunter.Invoke(activeHunter3);
				}
				else if (num > hunterActivationRadius && effectingHunters.Contains(activeHunter3))
				{
					onLoseHunter.Invoke(activeHunter3);
					effectingHunters.Remove(activeHunter3);
				}
			}
		}
		else if (currentCommand == HunterCommand.doorBlock)
		{
			foreach (DEN_Hunter activeHunter4 in DEN_Hunter.activeHunters)
			{
				if (Vector3.Distance(activeHunter4.transform.position, base.transform.position) <= hunterActivationRadius && !effectingHunters.Contains(activeHunter4))
				{
					activeHunter4.SetFrozen(f: true);
					effectingHunters.Add(activeHunter4);
					onDetectHunter.Invoke(activeHunter4);
					if (!isBlocking)
					{
						isBlocking = true;
						lastDoorBlockEventTime = Time.time;
					}
					if (moveHunterTo != null)
					{
						activeHunter4.transform.position = moveHunterTo.position;
						activeHunter4.transform.rotation = moveHunterTo.rotation;
					}
				}
			}
			if (isBlocking && Time.time - lastDoorBlockEventTime >= doorBlockEventRate)
			{
				doorBlockEvent.Invoke();
				lastDoorBlockEventTime = Time.time;
			}
		}
		else if (currentCommand == HunterCommand.clampMotionToLinear)
		{
			foreach (DEN_Hunter activeHunter5 in DEN_Hunter.activeHunters)
			{
				float num2 = Vector3.Distance(activeHunter5.transform.position, base.transform.position);
				if (num2 <= hunterActivationRadius && !effectingHunters.Contains(activeHunter5))
				{
					effectingHunters.Add(activeHunter5);
					onDetectHunter.Invoke(activeHunter5);
				}
				else if (num2 > hunterActivationRadius && effectingHunters.Contains(activeHunter5))
				{
					onLoseHunter.Invoke(activeHunter5);
					effectingHunters.Remove(activeHunter5);
					continue;
				}
				if (effectingHunters.Contains(activeHunter5))
				{
					Vector3 vector = ClampPositionAlongAxis(activeHunter5.transform.position);
					Vector3 vector2 = vector - activeHunter5.transform.position;
					if (CL_UIManager.debug)
					{
						CL_DebugView.draw.Arrow(activeHunter5.transform.position, vector, Color.green);
						CL_DebugView.draw.SolidCircle(vector, Vector3.up, 0.3f, Color.yellow);
					}
					activeHunter5.AddForce(vector2 * linearForceMult * Time.deltaTime);
				}
			}
		}
		else if (currentCommand == HunterCommand.safety)
		{
			foreach (DEN_Hunter activeHunter6 in DEN_Hunter.activeHunters)
			{
				float num3 = Vector3.Distance(activeHunter6.transform.position, base.transform.position);
				if (Vector3.Distance(ENT_Player.GetPlayer().transform.position, base.transform.position) < hunterActivationRadius && num3 < hunterActivationRadius)
				{
					activeHunter6.transform.position = Vector3.Lerp(activeHunter6.transform.position, base.transform.position + (activeHunter6.transform.position - base.transform.position).normalized * hunterActivationRadius, Time.deltaTime * 3f);
					activeHunter6.WipeTrackPositions();
				}
			}
		}
		if (effectingHunters.Count > count)
		{
			hunterEnterEvent.Invoke();
		}
	}

	public void Activate()
	{
		active = true;
		Debug.Log("Hunter Controller Activated");
		activateEvent.Invoke();
	}

	public void Deactivate()
	{
		active = false;
		Debug.Log("Hunter Controller Deactivated");
		if (effectingHunters != null)
		{
			deactivateEvent.Invoke();
			foreach (DEN_Hunter effectingHunter in effectingHunters)
			{
				if (!(effectingHunter == null) && (currentCommand == HunterCommand.freeze || currentCommand == HunterCommand.doorBlock))
				{
					effectingHunter.SetFrozen(f: false);
					Debug.Log("Hunter Unfrozen by Controller Deactivation");
				}
			}
			effectingHunters.Clear();
		}
		isBlocking = false;
	}

	public void StopAction()
	{
		if (effectingHunters != null && effectingHunters.Count > 0)
		{
			isBlocking = false;
		}
		effectingHunters = new List<DEN_Hunter>();
	}

	public void DestroyAllActiveHunters()
	{
		foreach (DEN_Hunter activeHunter in DEN_Hunter.activeHunters)
		{
			activeHunter.Kill("", null);
		}
	}

	public Vector3 ClampPositionAlongAxis(Vector3 position)
	{
		if (currentCommand != HunterCommand.clampMotionToLinear)
		{
			return position;
		}
		float num = Vector3.Dot(position - base.transform.position, base.transform.TransformVector(linearVector.normalized));
		return base.transform.position + base.transform.TransformVector(linearVector.normalized * num);
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		if (GizmoContext.InSelection(this))
		{
			Draw.WireSphere(base.transform.position, hunterActivationRadius, Color.cyan);
			if (currentCommand == HunterCommand.clampMotionToLinear)
			{
				Draw.Arrow(base.transform.position - base.transform.TransformVector(linearVector.normalized * hunterActivationRadius), base.transform.position + base.transform.TransformVector(linearVector.normalized * hunterActivationRadius), Color.yellow);
			}
		}
	}

	public void SpawnOrTeleportHunters(Transform target)
	{
		if (DEN_Hunter.HasActiveHunters())
		{
			DEN_Hunter.TeleportActiveHunters(target.position);
			_StopHunter?.Invoke();
		}
		else
		{
			UnityEngine.Object.Instantiate(hunterPrefab, target.position, Quaternion.identity);
		}
	}

	public void SetSpeedMult(float s)
	{
		foreach (DEN_Hunter activeHunter in DEN_Hunter.activeHunters)
		{
			activeHunter.SetSpeedMult(s);
		}
	}
}
