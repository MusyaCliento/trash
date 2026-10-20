using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SessionEventModule_ModuleSequencer : SessionEventModule
{
	[Serializable]
	public class SequenceEvent
	{
		public enum SequenceEventType
		{
			addModule = 0,
			messageModule = 1,
			deleteModule = 2
		}

		public string name;

		public float time;

		public SequenceEventType type;

		[SerializeReference]
		public List<SessionEventModule> modules;

		public string sequenceIDTarget;

		public string message;

		internal bool hasBeenPlayed;
	}

	public List<SequenceEvent> sequenceEvents;

	private Dictionary<string, SequenceEvent> eventDict;

	private float timer;

	private List<SessionEventModule> submodules;

	public override void Initialize(SessionEvent s)
	{
		submodules = new List<SessionEventModule>();
		eventDict = new Dictionary<string, SequenceEvent>();
		foreach (SequenceEvent sequenceEvent in sequenceEvents)
		{
			if (!eventDict.ContainsKey(sequenceEvent.name))
			{
				eventDict.Add(sequenceEvent.name, sequenceEvent);
			}
		}
		timer = 0f;
		base.Initialize(s);
	}

	public override void Update()
	{
		timer += Time.deltaTime;
		base.Update();
		foreach (SequenceEvent sequenceEvent in sequenceEvents)
		{
			if (sequenceEvent.hasBeenPlayed || !(timer > sequenceEvent.time))
			{
				continue;
			}
			sequenceEvent.hasBeenPlayed = true;
			if (sequenceEvent.type == SequenceEvent.SequenceEventType.addModule)
			{
				foreach (SessionEventModule module in sequenceEvent.modules)
				{
					module.Initialize(sessionEvent);
					module.OnModuleStart();
					module.SetParentEvent(this);
					submodules.Add(module);
				}
			}
			else if (sequenceEvent.type == SequenceEvent.SequenceEventType.messageModule)
			{
				foreach (SessionEventModule module2 in eventDict[sequenceEvent.sequenceIDTarget].modules)
				{
					module2.SendMessage(sequenceEvent.message);
				}
			}
			else
			{
				if (sequenceEvent.type != SequenceEvent.SequenceEventType.deleteModule)
				{
					continue;
				}
				foreach (SessionEventModule module3 in eventDict[sequenceEvent.sequenceIDTarget].modules)
				{
					DestroyModule(module3);
				}
			}
		}
		foreach (SessionEventModule submodule in submodules)
		{
			submodule.Update();
		}
	}

	public void DestroyModule(SessionEventModule m)
	{
		submodules.Remove(m);
		m.OnModuleDestroy();
	}
}
