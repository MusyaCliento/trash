using UnityEngine;
using UnityEngine.Events;

public class UT_CustomCommand : MonoBehaviour
{
	public string commandName = "customcommand";

	public bool cheat = true;

	public bool devOnly;

	public bool addCommandOnEnable = true;

	public UnityEvent commandEvent;

	private void OnEnable()
	{
		if (addCommandOnEnable && !devOnly)
		{
			AddCommand();
		}
	}

	private void OnDisable()
	{
		if (!devOnly)
		{
			RemoveCommand();
		}
	}

	public void AddCommand()
	{
		CommandConsole.AddCommand(commandName, CustomCommand, cheat);
	}

	public void RemoveCommand()
	{
		CommandConsole.RemoveCommand(commandName);
	}

	public void CustomCommand(string[] args)
	{
		commandEvent.Invoke();
	}
}
