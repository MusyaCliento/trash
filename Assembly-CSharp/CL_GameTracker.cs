using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CL_GameTracker : MonoBehaviour
{
	[Serializable]
	public class Session
	{
		[Serializable]
		public class Tick
		{
			[Serializable]
			public class Event
			{
				[Serializable]
				public enum EventType
				{
					none = 0,
					move = 1,
					teleport = 2,
					destroy = 3,
					kill = 4,
					use = 5,
					spawn = 6,
					special = 7
				}

				public string id;

				public string objectType;

				public EventType type;

				public string data;
			}

			public float timeStamp;

			public List<Event> events = new List<Event>();
		}

		public List<Tick> ticks;

		private float startTime;

		public float maxHeight;

		public void Initialize()
		{
			startTime = Time.time;
			ticks = new List<Tick>();
			AddNewTick();
		}

		public float GetSessionTime()
		{
			return Time.time - startTime;
		}

		public void AddNewTick()
		{
			Tick tick = new Tick();
			tick.timeStamp = GetSessionTime();
			tick.events = new List<Tick.Event>();
			ticks.Add(tick);
		}

		public void AddEventToCurrentTick(Tick.Event newEvent)
		{
		}

		public Tick GetLastTick()
		{
			return ticks[ticks.Count - 1];
		}

		public bool CompareEvents(Tick.Event e1, Tick.Event e2)
		{
			if (e1.id == e2.id && e1.type == e2.type)
			{
				return true;
			}
			return false;
		}
	}

	public static Session session;

	public static Action EventUpdate;

	private string filePath;

	public Session testSession;

	public static CL_GameTracker instance;

	private float tickCounter;

	private float tickRate = 0.5f;

	private void Awake()
	{
		InitializeSession();
		instance = this;
		filePath = Application.persistentDataPath + "/gameData.dat";
	}

	private static void InitializeSession()
	{
		if (session == null)
		{
			session = new Session();
			session.Initialize();
		}
	}

	private void Update()
	{
		if (tickCounter <= 0f)
		{
			session.AddNewTick();
			tickCounter = tickRate;
			EventUpdate();
			if (CL_GameManager.gMan.localPlayer != null)
			{
				session.maxHeight = CL_GameManager.gMan.localPlayer.transform.position.y;
			}
		}
		tickCounter -= Time.deltaTime;
	}

	public static void AddEventToSession(Session.Tick.Event e)
	{
		if (session == null)
		{
			InitializeSession();
		}
		session.AddEventToCurrentTick(e);
	}

	public static Session.Tick.Event CreateEvent(string name, string id, string objectType, Session.Tick.Event.EventType type, string data)
	{
		return new Session.Tick.Event
		{
			id = name + ":" + id,
			type = type,
			data = data,
			objectType = objectType
		};
	}

	public static Session.Tick.Event CreateEvent(string name, string id, string objectType, Session.Tick.Event.EventType type, Vector3 data)
	{
		return CreateEvent(name, id, objectType, type, ConvertVector3ToString(data));
	}

	public static string ConvertVector3ToString(Vector3 vector)
	{
		return vector.x + "," + vector.y + "," + vector.z;
	}

	public static object DecomposeData(Session.Tick.Event e)
	{
		if (e.type == Session.Tick.Event.EventType.move || e.type == Session.Tick.Event.EventType.teleport || e.type == Session.Tick.Event.EventType.spawn || e.type == Session.Tick.Event.EventType.destroy || e.type == Session.Tick.Event.EventType.kill)
		{
			string[] array = e.data.Split(",");
			if (array.Length < 3)
			{
				CommandConsole.LogError("WARNING: Tried to decompose data of insufficient type. Vector is not assigned correctly.");
				return null;
			}
			return new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
		}
		return e.data;
	}

	public static string ComposeData(Session.Tick.Event.EventType type, object data)
	{
		if (type == Session.Tick.Event.EventType.move || type == Session.Tick.Event.EventType.teleport || type == Session.Tick.Event.EventType.spawn || type == Session.Tick.Event.EventType.destroy)
		{
			Vector3 vector = (Vector3)data;
			return vector.x + ":" + vector.y + ":" + vector.z;
		}
		return (string)data;
	}

	public static void SaveSession()
	{
		instance.SerializeData(session);
	}

	public static Session LoadData()
	{
		return instance.DeserializeData();
	}

	private void SerializeData(Session data)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		using FileStream serializationStream = new FileStream(filePath, FileMode.Create);
		binaryFormatter.Serialize(serializationStream, data);
		Debug.Log("Data serialized to " + filePath);
	}

	private Session DeserializeData()
	{
		if (File.Exists(filePath))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using FileStream serializationStream = new FileStream(filePath, FileMode.Open);
			Session result = binaryFormatter.Deserialize(serializationStream) as Session;
			Debug.Log("Data deserialized from " + filePath);
			return result;
		}
		Debug.LogError("File not found at " + filePath);
		return null;
	}
}
