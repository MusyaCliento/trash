using UnityEngine;

public class UT_TriggerComponent<T> : UT_TriggerEntry
{
	public T other;

	public GameObject gameObject { get; set; }

	public bool FillFrom(GameObject gameObject)
	{
		this.gameObject = gameObject;
		other = gameObject.GetComponent<T>();
		return other != null;
	}
}
