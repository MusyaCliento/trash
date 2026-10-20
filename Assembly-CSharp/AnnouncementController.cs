using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncementController : MonoBehaviour
{
	[Serializable]
	public class AnnouncementClip
	{
		public AudioClip clip;

		public string subtitle;

		public float chance = 1f;

		public List<string> onPlayEvents;
	}

	[Serializable]
	public class AnnouncementCategory
	{
		public string name;

		public AudioClip tone;

		public List<AudioClip> clips;

		public List<AnnouncementClip> announcements;

		public void CreateAnnouncementListFromClips()
		{
			announcements = new List<AnnouncementClip>();
			foreach (AudioClip clip in clips)
			{
				AnnouncementClip announcementClip = new AnnouncementClip();
				announcementClip.clip = clip;
				announcementClip.subtitle = clip.name;
				announcementClip.chance = 1f;
				announcements.Add(announcementClip);
			}
		}
	}

	public static AnnouncementController instance;

	public bool active = true;

	public List<AnnouncementCategory> announcementCategories = new List<AnnouncementCategory>();

	public float announcementTimeMin = 60f;

	public float announcementTimeMax = 200f;

	private float announcementTimer;

	public float announcementVolume = 1f;

	public List<AnnouncementSource> announcers;

	public List<AudioClip> eventClips;

	private Dictionary<string, AudioClip> eventClipDict;

	internal static AnnouncementSource currentAnnouncerSource;

	private Coroutine currentAnnouncementRoutine;

	private void Awake()
	{
		announcementTimer = UnityEngine.Random.Range(announcementTimeMin, announcementTimeMax);
		instance = this;
		eventClipDict = new Dictionary<string, AudioClip>();
		CommandConsole.BuildVariableBool(() => ref active, "announcements_enabled", "Whether or not announcements are enabled");
		foreach (AudioClip eventClip in eventClips)
		{
			eventClipDict.Add(eventClip.name, eventClip);
		}
	}

	private void Update()
	{
		if (active)
		{
			announcementTimer -= Time.deltaTime;
			if (announcementTimer <= 0f)
			{
				StartAnnouncement();
			}
		}
	}

	public void StartAnnouncement(AudioClip announcementClip = null, AudioClip toneClip = null, bool force = false)
	{
		if (announcers.Count != 0)
		{
			float num = 1f;
			if (WorldLoader.initialized && WorldLoader.instance.GetCurrentLevel() != null && WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion != null)
			{
				num *= WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion.announcementTimerMult;
			}
			announcementTimer = UnityEngine.Random.Range(announcementTimeMin, announcementTimeMax) * num;
			if (currentAnnouncementRoutine != null)
			{
				StopAnnouncement();
			}
			currentAnnouncementRoutine = StartCoroutine(PlayAnnouncement(announcementClip, toneClip, force));
		}
	}

	public void StopAnnouncement()
	{
		if (currentAnnouncementRoutine != null)
		{
			StopCoroutine(currentAnnouncementRoutine);
		}
		if (currentAnnouncerSource != null)
		{
			currentAnnouncerSource.StopAnnouncement();
		}
	}

	public void GetClipAndCategoryFromCategoryList(List<AnnouncementCategory> categories, out AnnouncementClip outClip, out AnnouncementCategory outCat)
	{
		List<AnnouncementClip> list = new List<AnnouncementClip>();
		Dictionary<AnnouncementClip, AnnouncementCategory> dictionary = new Dictionary<AnnouncementClip, AnnouncementCategory>();
		foreach (AnnouncementCategory category in categories)
		{
			foreach (AnnouncementClip announcement in category.announcements)
			{
				if (UnityEngine.Random.value < announcement.chance)
				{
					list.Add(announcement);
					if (!dictionary.ContainsKey(announcement))
					{
						dictionary.Add(announcement, category);
					}
				}
			}
		}
		outCat = dictionary[outClip = list[UnityEngine.Random.Range(0, list.Count)]];
	}

	public IEnumerator PlayAnnouncement(AudioClip announcementClip = null, AudioClip toneClip = null, bool force = false)
	{
		if (CL_GameManager.gMan.localPlayer == null)
		{
			yield break;
		}
		AnnouncementClip outClip = null;
		AudioClip clip;
		AudioClip tone;
		if (announcementClip == null)
		{
			AnnouncementCategory outCat = null;
			if (WorldLoader.initialized)
			{
				AnnouncementGroup announcementGroup = null;
				if (WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion != null)
				{
					announcementGroup = WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion.GetRandomAnnouncementGroup();
				}
				if (announcementGroup != null)
				{
					List<AnnouncementCategory> announcements = announcementGroup.announcements;
					GetClipAndCategoryFromCategoryList(announcements, out outClip, out outCat);
				}
				else
				{
					GetClipAndCategoryFromCategoryList(announcementCategories, out outClip, out outCat);
				}
			}
			else
			{
				GetClipAndCategoryFromCategoryList(announcementCategories, out outClip, out outCat);
			}
			clip = outClip.clip;
			tone = outCat.tone;
		}
		else
		{
			clip = announcementClip;
			tone = toneClip;
		}
		List<StringVariableExtractor.StringVariable> postAnnouncementEvents = new List<StringVariableExtractor.StringVariable>();
		bool startFillingPostEvents = false;
		if (outClip != null && outClip.onPlayEvents != null && outClip.onPlayEvents.Count > 0)
		{
			foreach (string onPlayEvent in outClip.onPlayEvents)
			{
				List<StringVariableExtractor.StringVariable> list = StringVariableExtractor.ExtractVariables(onPlayEvent);
				if (list == null)
				{
					continue;
				}
				foreach (StringVariableExtractor.StringVariable item in list)
				{
					if (startFillingPostEvents)
					{
						postAnnouncementEvents.Add(item);
					}
					else
					{
						yield return EventInterpreter(item);
					}
				}
			}
		}
		AnnouncementSource closestAnnouncer = FindClosestAnnouncer(CL_GameManager.gMan.localPlayer.transform.position);
		if (tone != null)
		{
			closestAnnouncer.PlayAnnouncement(tone, announcementVolume, showSubtitle: false, force);
			yield return new WaitForSeconds(tone.length + 0.5f);
		}
		closestAnnouncer.PlayAnnouncement(clip, announcementVolume, showSubtitle: true, force);
		foreach (StringVariableExtractor.StringVariable item2 in postAnnouncementEvents)
		{
			yield return EventInterpreter(item2);
		}
		IEnumerator EventInterpreter(StringVariableExtractor.StringVariable extractedVar)
		{
			if (extractedVar.name == "wait")
			{
				yield return new WaitForSeconds(float.Parse(extractedVar.value));
			}
			else if (extractedVar.name == "shake")
			{
				CL_CameraControl.Shake(float.Parse(extractedVar.value));
			}
			else if (extractedVar.name == "sound")
			{
				if (eventClipDict.TryGetValue(extractedVar.value, out var value))
				{
					AudioManager.PlaySound(value, Vector3.zero, 0.6f, 1f, 0f);
				}
				else
				{
					Debug.LogError("Could not find " + extractedVar.value + " among clips!");
				}
			}
			else if (extractedVar.name == "after")
			{
				startFillingPostEvents = true;
			}
		}
	}

	public void AddAnnouncer(AnnouncementSource ann)
	{
		announcers.Add(ann);
	}

	public void RemoveAnnouncer(AnnouncementSource ann)
	{
		if (announcers.Contains(ann))
		{
			announcers.Remove(ann);
		}
	}

	public AnnouncementSource FindClosestAnnouncer(Vector3 pos)
	{
		float num = float.PositiveInfinity;
		AnnouncementSource result = null;
		foreach (AnnouncementSource announcer in announcers)
		{
			if (!(announcer == null) && announcer.gameObject.activeInHierarchy)
			{
				float num2 = Vector3.Distance(announcer.transform.position, pos);
				if (num2 < num)
				{
					num = num2;
					result = announcer;
				}
			}
		}
		return result;
	}

	public void ResetAnnouncementTimer()
	{
		float num = 1f;
		if (WorldLoader.initialized && WorldLoader.instance.GetCurrentLevel() != null && WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion != null)
		{
			num *= WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion.announcementTimerMult;
		}
		announcementTimer = UnityEngine.Random.Range(announcementTimeMin, announcementTimeMax) * num;
	}

	public void ZeroAnnouncementTimer()
	{
		announcementTimer = 0f;
	}
}
