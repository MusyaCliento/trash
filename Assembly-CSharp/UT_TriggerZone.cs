using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_TriggerZone : MonoBehaviourGizmos, SaveableObject
{
	public bool runOnce;

	private bool hasRun;

	private bool hasRunExit;

	public string[] entityTags;

	public UnityEvent<Transform> onEnter;

	public UnityEvent<Transform> onExit;

	public bool saveState;

	public string saveStateID = "";

	private void OnTriggerEnter(Collider other)
	{
		if (!runOnce || !hasRun)
		{
			ObjectTagger component = other.GetComponent<ObjectTagger>();
			if (component != null && component.HasTagInList(entityTags))
			{
				hasRun = true;
				onEnter.Invoke(other.transform);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!runOnce || !hasRunExit)
		{
			ObjectTagger component = other.GetComponent<ObjectTagger>();
			if (component != null && component.HasTagInList(entityTags))
			{
				hasRunExit = true;
				onExit.Invoke(other.transform);
			}
		}
	}

	public override void DrawGizmos()
	{
		Draw.Label2D(base.transform.position + Vector3.up * 0.2f, base.name, new Color(0f, 1f, 1f, 0.1f));
		DarkMachineFunctions.RenderUnityEvent(ref Draw.editor, base.transform, new List<DarkMachineFunctions.RenderUnityEventDesc>
		{
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = onEnter,
				prependString = "On Enter: ",
				color = Color.green
			},
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = onExit,
				prependString = "On Exit: ",
				color = Color.red
			}
		});
	}

	public void Reset()
	{
		hasRun = false;
		hasRunExit = false;
	}

	public bool CanSave(string[] flags = null)
	{
		return saveState;
	}

	public string GetSaveID()
	{
		return saveStateID;
	}

	public SaveableInfo GetSaveInfo()
	{
		return new SaveableInfo
		{
			id = saveStateID,
			data = hasRun.ToString()
		};
	}

	public void SetSaveInfo(SaveableInfo info, List<string> flags)
	{
		bool.TryParse(info.data, out hasRun);
	}
}
