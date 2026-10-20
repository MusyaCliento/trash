using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_GooTrigger : MonoBehaviourGizmos
{
	public enum Trigger
	{
		above = 0,
		below = 1
	}

	public bool active = true;

	public Trigger trigger;

	public UnityEvent outputEvent;

	public UnityEvent failEvent;

	public bool runOnce = true;

	public bool checkEveryFrame = true;

	public bool triggerEveryCheck;

	private bool triggered;

	private void Update()
	{
		if (checkEveryFrame)
		{
			Check();
		}
	}

	public void Check()
	{
		if (!active || (runOnce && triggered))
		{
			return;
		}
		bool flag = false;
		if (DEN_DeathFloor.instance != null)
		{
			switch (trigger)
			{
			case Trigger.above:
				flag = ((DEN_DeathFloor.instance.transform.position.y > base.transform.position.y) ? true : false);
				break;
			case Trigger.below:
				flag = ((DEN_DeathFloor.instance.transform.position.y < base.transform.position.y) ? true : false);
				break;
			}
		}
		else if (!checkEveryFrame)
		{
			flag = true;
		}
		if (flag)
		{
			if (!triggered || triggerEveryCheck)
			{
				triggered = true;
				outputEvent.Invoke();
			}
			return;
		}
		if (triggered)
		{
			triggered = false;
		}
		if (!checkEveryFrame)
		{
			failEvent.Invoke();
		}
	}

	public void SetActive(bool b)
	{
		active = b;
	}

	public override void DrawGizmos()
	{
		Draw.Label2D(base.transform.position + Vector3.up * 0.1f, base.name + ": " + active + "\nTYPE: " + trigger.ToString() + " : " + ((!checkEveryFrame) ? "ON CALL" : "EVERY FRAME"), Color.red);
	}
}
