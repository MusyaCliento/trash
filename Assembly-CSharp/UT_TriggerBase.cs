using System.Collections.Generic;
using Drawing;
using UnityEngine;

public abstract class UT_TriggerBase<T> : MonoBehaviourGizmos where T : UT_TriggerEntry, new()
{
	public string[] triggerTags = new string[1] { "Player" };

	internal List<T> triggerObjects = new List<T>();

	private int stillInsideCheckCounter;

	private int tickFrame = 5;

	private Collider triggerCollider;

	internal virtual void Start()
	{
		tickFrame = Random.Range(0, 10);
		triggerCollider = GetComponent<Collider>();
	}

	internal virtual void TriggerTick()
	{
		tickFrame--;
		if (tickFrame <= 0)
		{
			tickFrame = 5;
			TickBoundsCheck();
		}
	}

	protected virtual void OnTriggerEnter(Collider other)
	{
		if (!ObjectTagger.TagCheck(other.gameObject, triggerTags))
		{
			return;
		}
		for (int i = 0; i < triggerObjects.Count; i++)
		{
			if (triggerObjects[i].gameObject == other.gameObject)
			{
				return;
			}
		}
		AddTriggerObjectFromCollider(other);
	}

	protected void AddTriggerObjectFromCollider(Collider collider)
	{
		T item = new T();
		if (item.FillFrom(collider.gameObject))
		{
			triggerObjects.Add(item);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!ObjectTagger.TagCheck(other.gameObject, triggerTags))
		{
			return;
		}
		for (int i = 0; i < triggerObjects.Count; i++)
		{
			if (triggerObjects[i].gameObject == other.gameObject)
			{
				triggerObjects.RemoveAt(i--);
			}
		}
	}

	internal virtual void TickBoundsCheck()
	{
		if (!(triggerCollider == null) && triggerObjects.Count > 0)
		{
			if (stillInsideCheckCounter >= triggerObjects.Count)
			{
				stillInsideCheckCounter = 0;
			}
			Bounds bounds = triggerCollider.bounds;
			bounds.Expand(2f);
			T val = triggerObjects[stillInsideCheckCounter];
			if (val == null || val.gameObject == null || val.gameObject.transform == null || !bounds.Contains(val.gameObject.transform.position))
			{
				triggerObjects.RemoveAt(stillInsideCheckCounter);
			}
			stillInsideCheckCounter++;
		}
	}

	internal virtual void FixedUpdate()
	{
		TickBoundsCheck();
	}
}
