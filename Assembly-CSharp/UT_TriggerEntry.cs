using UnityEngine;

public interface UT_TriggerEntry
{
	GameObject gameObject { get; set; }

	bool FillFrom(GameObject gameObject);
}
