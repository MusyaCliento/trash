using Discord.Sdk;
using UnityEngine;

public class DiscordManager : MonoBehaviour
{
	public ulong clientId;

	private Client client;

	public static DiscordManager instance;

	private int richPresenceVersion;

	private void Start()
	{
		if (instance != null && instance != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Object.DontDestroyOnLoad(base.gameObject);
		instance = this;
		client = new Client();
		client.SetApplicationId(clientId);
		client.Connect();
	}

	private void Update()
	{
		UpdateRichPresence();
	}

	private void OnDestroy()
	{
		if (client != null)
		{
			client.ClearRichPresence();
			client.Disconnect();
		}
	}

	private void UpdateRichPresence()
	{
		int num = CL_GameManager.RichPresenceVersion();
		if (richPresenceVersion != num)
		{
			richPresenceVersion = num;
			string details = CL_GameManager.RichPresenceStringifyEn(CL_GameManager.RichPresencePeek());
			Activity activity = new Activity();
			activity.SetDetails(details);
			ActivityTimestamps activityTimestamps = new ActivityTimestamps();
			activityTimestamps.SetStart((ulong)CL_GameManager.RichPresenceStartTime());
			activity.SetTimestamps(activityTimestamps);
			client.UpdateRichPresence(activity, OnRichPresenceUpdated);
		}
	}

	private void OnRichPresenceUpdated(ClientResult result)
	{
		if (!result.Successful())
		{
			Debug.LogError("Failed to update rich presence");
		}
	}
}
