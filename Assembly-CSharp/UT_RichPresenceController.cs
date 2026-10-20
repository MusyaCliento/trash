using System.Collections.Generic;
using UnityEngine;

public class UT_RichPresenceController : MonoBehaviour
{
	public int capacity = 1;

	private List<CL_GameManager.RichPresenceMarker> markers = new List<CL_GameManager.RichPresenceMarker>();

	private void OnDisable()
	{
		foreach (CL_GameManager.RichPresenceMarker marker in markers)
		{
			CL_GameManager.RichPresencePop(marker);
		}
		markers.Clear();
	}

	public void PushAndSet(string keyValue)
	{
		Push();
		Set(keyValue);
	}

	public void Push()
	{
		if (capacity == -1 || markers.Count < capacity)
		{
			Debug.Log("Pushing rich presence context");
			markers.Add(CL_GameManager.RichPresencePush());
		}
		else
		{
			Debug.Log($"Cannot push rich presence update due to capacity {capacity}, {markers.Count}");
		}
	}

	public void Pop()
	{
		if (markers.Count > 0)
		{
			Debug.Log("Popping top marker");
			List<CL_GameManager.RichPresenceMarker> list = markers;
			CL_GameManager.RichPresencePop(list[list.Count - 1]);
			markers.RemoveAt(markers.Count - 1);
		}
		else
		{
			Debug.Log("Cannot pop top marker as this controller is empty");
		}
	}

	public void Set(string key, string value)
	{
		string text = "none";
		CL_GameManager.RichPresenceMarker marker = default(CL_GameManager.RichPresenceMarker);
		if (CL_GameManager.gMan != null)
		{
			marker = CL_GameManager.gMan.richPresenceBase;
			text = "root";
		}
		if (markers.Count > 0)
		{
			List<CL_GameManager.RichPresenceMarker> list = markers;
			marker = list[list.Count - 1];
			text = $"marker {markers.Count}";
		}
		Debug.Log("Setting KV pair " + key + ": " + value + " on " + text);
		CL_GameManager.RichPresenceSet(marker, key, value);
	}

	public void Set(string keyValue)
	{
		string[] array = keyValue.Split(':');
		if (array.Length == 2)
		{
			Set(array[0], array[1]);
		}
		else
		{
			Debug.LogError("Got invalid keyValue pair " + keyValue);
		}
	}
}
