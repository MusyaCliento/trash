using UnityEngine;

public class UT_TriggerGameObject : UT_TriggerEntry
{
	public GameObject gameObject { get; set; }

	public bool FillFrom(GameObject gameObject)
	{
		this.gameObject = gameObject;
		return true;
	}
}
