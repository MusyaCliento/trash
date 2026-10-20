using UnityEngine;

public class UT_HandItem_ModuleInterface : MonoBehaviour
{
	public HandItem handItem;

	public void SendModuleMessage(string message)
	{
		foreach (ItemExecutionModule executionModule in handItem.item.executionModules)
		{
			executionModule.SendMessage(message);
		}
	}
}
