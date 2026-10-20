using UnityEngine;
using UnityEngine.Events;

public class UT_AIController : MonoBehaviour
{
	public enum Command
	{
		setNavigationTarget = 0,
		setState = 1,
		message = 2,
		enableAI = 3,
		disableAI = 4
	}

	public bool active = true;

	public AIGameEntity targetAI;

	public Command command;

	public string commandString;

	public UnityEvent<AIGameEntity> onReachDestination;

	public string changeStateOnReachDestination = "";

	public string setAnimationTriggerOnReachDestination = "";

	public float reachDestinationRadius = 1f;

	public void Activate(AIGameEntity aIGameEntity)
	{
		active = true;
		if (command == Command.setNavigationTarget)
		{
			aIGameEntity.SetNavigationTargetPosition(base.transform.position);
		}
		else if (command == Command.setState)
		{
			aIGameEntity.ChangeState(commandString);
		}
		else if (command == Command.message)
		{
			aIGameEntity.SendMessage(commandString);
		}
		else if (command == Command.enableAI)
		{
			aIGameEntity.disableAI = false;
			aIGameEntity.ChangeState(commandString);
		}
		else if (command == Command.disableAI)
		{
			aIGameEntity.disableAI = true;
			aIGameEntity.ChangeState("empty");
		}
	}

	public void Activate()
	{
		Activate(targetAI);
	}

	public void SetState(string s)
	{
		targetAI.ChangeState(s);
	}

	private void Update()
	{
		if (!(targetAI != null))
		{
			return;
		}
		float num = Vector3.Distance(targetAI.transform.position, base.transform.position);
		if (!active || !(num < reachDestinationRadius))
		{
			return;
		}
		active = false;
		if (changeStateOnReachDestination != "")
		{
			SetState(changeStateOnReachDestination);
			if (changeStateOnReachDestination == "empty")
			{
				targetAI.disableAI = true;
			}
			else
			{
				targetAI.disableAI = false;
			}
		}
		if (setAnimationTriggerOnReachDestination != "")
		{
			targetAI.SetAnimationTrigger(setAnimationTriggerOnReachDestination);
		}
		onReachDestination.Invoke(targetAI);
	}
}
