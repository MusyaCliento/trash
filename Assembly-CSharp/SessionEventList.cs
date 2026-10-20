using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event List", menuName = "White Knuckle/Events/Event List")]
public class SessionEventList : ScriptableObject
{
	public string id;

	public List<SessionEvent> events;
}
