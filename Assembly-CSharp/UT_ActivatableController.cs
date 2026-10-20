using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_ActivatableController : MonoBehaviourGizmos, Activatable
{
	[Serializable]
	public class ActivatableGroup
	{
		public string name;

		public List<GameObject> activatables;

		public Color color;

		public float stateChangeStartDelay;

		public float perActivateableDelay;

		public bool currentState;
	}

	public List<ActivatableGroup> activatableGroups;

	public bool active;

	public bool locked;

	public UnityEvent activateEvent;

	public UnityEvent deactivateEvent;

	public void ActivateGroups(string groupName)
	{
		SetGroupStates(groupName, b: true);
	}

	public void DeactivateGroups(string groupName)
	{
		SetGroupStates(groupName, b: false);
	}

	public void SoloActivateGroups(string groupName)
	{
		SetGroupStates(groupName, b: true, deactivateOthers: true);
	}

	public void DeactivateAllGroups()
	{
		SetGroupStates("all", b: false, deactivateOthers: true);
	}

	public void ActivateAllGroups()
	{
		if (locked)
		{
			return;
		}
		foreach (ActivatableGroup activatableGroup in activatableGroups)
		{
			SetGroupState(activatableGroup, state: true);
		}
	}

	public void ToggleGroup(string groupName)
	{
		foreach (ActivatableGroup activatableGroup in activatableGroups)
		{
			if (activatableGroup.name == groupName)
			{
				SetGroupState(activatableGroup, !activatableGroup.currentState);
			}
		}
	}

	public void ToggleAllGroups()
	{
		foreach (ActivatableGroup activatableGroup in activatableGroups)
		{
			SetGroupState(activatableGroup, !activatableGroup.currentState);
		}
	}

	public void SetGroupState(ActivatableGroup group, bool state)
	{
		group.currentState = state;
		StartCoroutine(ToggleGroup());
		IEnumerator ToggleGroup()
		{
			foreach (GameObject activatable in group.activatables)
			{
				if (group.stateChangeStartDelay > 0f)
				{
					yield return new WaitForSeconds(group.stateChangeStartDelay);
				}
				if (state)
				{
					activatable.GetComponent<Activatable>().Activate();
				}
				else
				{
					activatable.GetComponent<Activatable>().Deactivate();
				}
				if (group.perActivateableDelay > 0f)
				{
					yield return new WaitForSeconds(group.perActivateableDelay);
				}
			}
		}
	}

	public void SetGroupStates(string groupName, bool b, bool deactivateOthers = false)
	{
		if (locked)
		{
			return;
		}
		foreach (ActivatableGroup activatableGroup in activatableGroups)
		{
			if (activatableGroup.name.Contains(groupName))
			{
				SetGroupState(activatableGroup, b);
			}
			else if (deactivateOthers)
			{
				SetGroupState(activatableGroup, state: false);
			}
		}
	}

	public override void DrawGizmos()
	{
		if (!GizmoContext.InSelection(this))
		{
			return;
		}
		float num = 0.25f;
		foreach (ActivatableGroup activatableGroup in activatableGroups)
		{
			foreach (GameObject activatable in activatableGroup.activatables)
			{
				Draw.DashedLine(base.transform.position, activatable.transform.position, num, num, activatableGroup.color);
			}
		}
	}

	public void Deactivate()
	{
		deactivateEvent.Invoke();
		active = false;
	}

	public void Activate()
	{
		activateEvent.Invoke();
		active = true;
	}

	public void ToggleActivated()
	{
		if (active)
		{
			Deactivate();
		}
		else
		{
			Activate();
		}
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public void SetLocked(bool l)
	{
		locked = l;
	}
}
