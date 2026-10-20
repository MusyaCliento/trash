using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using DG.Tweening;
using Febucci.UI;
using Febucci.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CL_UIManager : MonoBehaviour
{
	[Serializable]
	public class Vignette
	{
		public string name;

		public Image image;

		public Color color;

		private float lerpTarget;

		private float lerpAmount;

		public float fadeSpeed = 1f;

		public IEnumerator currentCoroutine;

		public void SetColor(Color c)
		{
			color = c;
		}

		public Color GetColorTarget()
		{
			return color;
		}

		internal void SetLerpAmount(float value)
		{
			lerpAmount = value;
			image.color = Color.Lerp(Color.clear, color, value);
		}

		public void SetLerpTarget(float t)
		{
			lerpTarget = t;
		}

		internal void Update()
		{
			SetLerpAmount(Mathf.Lerp(lerpAmount, lerpTarget, fadeSpeed * Time.unscaledDeltaTime));
		}

		public float GetAmount()
		{
			return lerpAmount;
		}
	}

	public struct SubtitleId
	{
		internal int index;

		internal int generation;
	}

	[Flags]
	public enum SubtitleFlags
	{
		Kill = 1,
		Saturate = 2,
		Overflow = 4,
		Autofill = 0x40,
		Directionality = 0x80,
		Ambient = 0x100,
		Default = 0xC1
	}

	private class SubtitleInfo : IComparable<SubtitleInfo>
	{
		public int version;

		public int index;

		public int generation;

		public int nextFree;

		public int priority;

		public Transform parent;

		public Vector3 offset;

		public float radius;

		public SubtitleFlags flags;

		public string originalText = "";

		public long groupId;

		public List<(string line, float delay)> lines = new List<(string, float)>();

		public string style;

		public float timeRemainingInLine;

		public int lineIndex;

		public float timeGrace;

		public float timeGraceTotal;

		public float lastDistSqr;

		public int CompareTo(SubtitleInfo other)
		{
			if (priority != other.priority)
			{
				return -priority.CompareTo(other.priority);
			}
			bool flag = groupId != 0L && other.groupId != 0;
			if (flag && groupId != other.groupId)
			{
				return groupId.CompareTo(other.groupId);
			}
			float num = timeGrace / timeGraceTotal;
			float num2 = other.timeGrace / other.timeGraceTotal;
			if (flag && num != num2)
			{
				return -num.CompareTo(num2);
			}
			if (version != other.version)
			{
				return version.CompareTo(other.version);
			}
			return lastDistSqr.CompareTo(other.lastDistSqr);
		}
	}

	public bool inGame = true;

	public Transform canvas;

	public UI_CrosshairController crosshairController;

	public GameObject loadingPopup;

	public GameObject standardInputModule;

	public DebugMenu debugMenu;

	public static bool debug;

	public static int debugState;

	public Transform uiMeterLayoutRoot;

	public Transform customElementLayoutGroup;

	private Dictionary<string, HUD_CustomElement> customElementDict;

	public CanvasGroup reviveGroup;

	public GameObject vignetteParent;

	public List<Vignette> vignettes;

	private Dictionary<string, Vignette> vignetteDict = new Dictionary<string, Vignette>();

	public List<Image> damageDirectionIndicators;

	public UT_TextScrawl header;

	public UT_TextScrawl ascentHeader;

	public UT_TextScrawl highscoreHeader;

	public UT_TextScrawl tipHeader;

	public TMP_Text descriptorText;

	public Transform subtitleParent;

	public Transform subtitlePoolRoot;

	public Image subtitleBacking;

	public UI_Subtitle subtitleObject;

	public int subtitleObjectPoolInitialSize = 10;

	public UI_LerpOpen safeAreaText;

	public TMP_Text scoreTitle;

	public TMP_Text timer;

	public TMP_Text ascentTracker;

	public TMP_Text ascentRateTracker;

	public TMP_Text scoreTracker;

	public TMP_Text highScoreTracker;

	public GameObject runInfoRoot;

	public GameObject cheatTracker;

	public TMP_Text achievementText;

	public TypewriterCore achievementTypewriter;

	public static CL_UIManager instance;

	public Image[] interactImages;

	public Image[] interactOverlays;

	public static bool ascentTrackerActive;

	private bool subtitlesDebug;

	public GUISkin defaultSkin;

	private int subtitleVersion;

	private HashSet<long> subtitlesHistory = new HashSet<long>();

	private List<SubtitleInfo> subtitlesActive = new List<SubtitleInfo>();

	private int subtitleFirstFree = -1;

	private Stack<UI_Subtitle> subtitleObjectPool = new Stack<UI_Subtitle>();

	private List<SubtitleInfo> subtitlesCollecting = new List<SubtitleInfo>();

	private List<int> subtitlesPlaying = new List<int>();

	private string[][] subtitleArrowCache = new string[2][]
	{
		Array.Empty<string>(),
		Array.Empty<string>()
	};

	private SubtitleId globalSubtitles;

	private void Awake()
	{
		foreach (Vignette vignette in vignettes)
		{
			vignetteDict.Add(vignette.name, vignette);
			vignette.SetLerpTarget(0f);
		}
		instance = this;
		CommandConsole.BuildCommand("subtitle", ShowSubtitle).NotCheat().Description("[subtitle text]: Play arbitrary subtitles");
		CommandConsole.BuildVariableBool(() => ref subtitlesDebug, "subtitle_debug", "Shows subtitle areas in world.");
		for (int num = 0; num < subtitleObjectPoolInitialSize; num++)
		{
			UI_Subtitle uI_Subtitle = UnityEngine.Object.Instantiate(subtitleObject, subtitleParent);
			uI_Subtitle.gameObject.SetActive(value: false);
			subtitleObjectPool.Push(uI_Subtitle);
		}
		CommandConsole.BuildVariableBool(() => ref SettingsManager.settings.showSubtitlesAmbient, "subtitles_ambient", "Whether or not to show ambient subtitles");
	}

	private static void ShowSubtitle(string[] args)
	{
		ShowSubtitle(string.Join(' ', args));
	}

	private void OnEnable()
	{
		SettingsManager._OnRefreshSetting = (Action<string>)Delegate.Combine(SettingsManager._OnRefreshSetting, new Action<string>(RefreshSetting));
	}

	private void OnDisable()
	{
		SettingsManager._OnRefreshSetting = (Action<string>)Delegate.Remove(SettingsManager._OnRefreshSetting, new Action<string>(RefreshSetting));
	}

	private void RefreshSetting(string setting)
	{
		if (setting == "g_timer")
		{
			timer.gameObject.SetActive(SettingsManager.settings.g_timer);
		}
		else if (setting == "g_runInfo")
		{
			ascentTrackerActive = SettingsManager.settings.g_runInfo;
		}
	}

	private void Start()
	{
		timer.gameObject.SetActive(SettingsManager.settings.g_timer);
		ascentTrackerActive = SettingsManager.settings.g_runInfo;
		if (debugState == 0)
		{
			DebugMenu.visible = false;
			debugMenu.gameObject.SetActive(value: false);
			debugState = 0;
			debug = false;
		}
		else if (debugState == 2)
		{
			DebugMenu.visible = true;
			debugMenu.gameObject.SetActive(value: true);
			debug = true;
		}
		else
		{
			DebugMenu.visible = true;
			debugMenu.gameObject.SetActive(value: true);
			debug = false;
		}
	}

	private void Update()
	{
		if (inGame)
		{
			foreach (Vignette vignette in vignettes)
			{
				vignette.Update();
			}
			if (Input.GetKeyDown(KeyCode.F5))
			{
				debugState++;
				if (debugState > 2)
				{
					DebugMenu.visible = false;
					debugMenu.gameObject.SetActive(value: false);
					debugState = 0;
					debug = false;
				}
				else if (debugState == 2)
				{
					DebugMenu.visible = true;
					debug = true;
				}
				else
				{
					DebugMenu.visible = true;
					debugMenu.gameObject.SetActive(value: true);
				}
			}
			if (Input.GetKeyDown(KeyCode.F1))
			{
				timer.gameObject.SetActive(!timer.gameObject.activeSelf);
			}
			if (ascentTrackerActive != ascentTracker.transform.parent.gameObject.activeSelf)
			{
				ascentTracker.transform.parent.gameObject.SetActive(ascentTrackerActive);
			}
			TimeSpan timeSpan = TimeSpan.FromSeconds(CL_GameManager.gMan.GetGameTime());
			if (timeSpan.TotalHours >= 1.0)
			{
				string text = timeSpan.ToString("hh\\:mm\\:ss\\:ff");
				timer.text = text;
			}
			else
			{
				string text2 = timeSpan.ToString("mm\\:ss\\:ff");
				timer.text = text2;
			}
			foreach (Image damageDirectionIndicator in damageDirectionIndicators)
			{
				if (damageDirectionIndicator.color.a > 0f)
				{
					Color color = damageDirectionIndicator.color;
					color.a -= Time.deltaTime * 1.25f;
					damageDirectionIndicator.color = color;
				}
			}
		}
		UpdateVisibleSubtitles();
	}

	public void SetDescription(string t)
	{
		descriptorText.text = t;
		DOTween.Kill("uiDescriptor");
		descriptorText.color = Color.white;
		descriptorText.DOColor(Color.clear, 0.5f).SetId("uiDescriptor").SetUpdate(isIndependentUpdate: true);
	}

	public void Hurt(Vector2 direction, float amount = 0.6f)
	{
		SetVignette("hurt", Mathf.Max(amount, vignetteDict["hurt"].GetAmount()));
		damageDirectionIndicators[0].color = new Color(1f, 0f, 0f, Mathf.Clamp01(0f - direction.x));
		damageDirectionIndicators[1].color = new Color(1f, 0f, 0f, Mathf.Clamp01(direction.y));
		damageDirectionIndicators[2].color = new Color(1f, 0f, 0f, Mathf.Clamp01(direction.x));
		damageDirectionIndicators[3].color = new Color(1f, 0f, 0f, Mathf.Clamp01(0f - direction.y));
	}

	public void SetVignetteTarget(string name, float value)
	{
		vignetteDict[name].SetLerpTarget(value);
	}

	public void SetVignette(string name, float value)
	{
		vignetteDict[name].SetLerpAmount(value);
		vignetteDict[name].SetLerpTarget(value);
	}

	public void SetVignetteImage(string name, Sprite s)
	{
		vignetteDict[name].image.sprite = s;
	}

	public void FadeOut()
	{
		SetVignetteTarget("fade", 1f);
	}

	public void FadeIn()
	{
		SetVignetteTarget("fade", 0f);
	}

	public void SetFadeAmount(float a)
	{
		SetVignette("fade", a);
	}

	public void SetFadeTarget(float a)
	{
		SetVignetteTarget("fade", a);
	}

	public void SetVignetteColor(string n, Color c)
	{
		if (vignetteDict.ContainsKey(n))
		{
			vignetteDict[n].SetColor(c);
		}
	}

	public void FlashVignette(string n)
	{
		if (vignetteDict[n].currentCoroutine != null)
		{
			StopCoroutine(vignetteDict[n].currentCoroutine);
		}
		vignetteDict[n].currentCoroutine = Flash();
		StartCoroutine(vignetteDict[n].currentCoroutine);
		IEnumerator Flash(float flashWait = 1f)
		{
			SetVignette(n, 1f);
			yield return new WaitForSeconds(flashWait);
			SetVignetteTarget(n, 0f);
		}
	}

	public void QuickFlashVignette(string n)
	{
		if (vignetteDict[n].currentCoroutine != null)
		{
			StopCoroutine(vignetteDict[n].currentCoroutine);
		}
		vignetteDict[n].currentCoroutine = Flash();
		StartCoroutine(vignetteDict[n].currentCoroutine);
		IEnumerator Flash()
		{
			SetVignette(n, 1f);
			yield return new WaitForSeconds(0.1f);
			SetVignetteTarget(n, 0f);
		}
	}

	public void FlashVignetteImage(string n, Sprite s)
	{
		StartCoroutine(Flash());
		IEnumerator Flash()
		{
			SetVignette(n, 1f);
			yield return new WaitForSeconds(0.1f);
			SetVignetteTarget(n, 0f);
		}
	}

	public static void SetLoading(bool b)
	{
		if (!(instance == null))
		{
			instance.loadingPopup.SetActive(b);
		}
	}

	internal void ResetVignettes()
	{
		foreach (Vignette vignette in vignettes)
		{
			vignette.SetLerpTarget(0f);
		}
	}

	public static SubtitleId SubtitleSimpleCreate(string text, string style, SubtitleFlags subtitleFlags = SubtitleFlags.Ambient, Transform targetTransform = null, float subtitleRadius = 15f)
	{
		SubtitleId subtitleId = SubtitleCreate(text, style);
		SubtitleFlagsSet(subtitleId, subtitleFlags);
		if (targetTransform != null)
		{
			SubtitleSpace(subtitleId, targetTransform, Vector3.zero, subtitleRadius);
		}
		return subtitleId;
	}

	public static SubtitleId SubtitleCreate(string text, string style)
	{
		CL_UIManager uiMan = CL_GameManager.gMan.uiMan;
		if (uiMan == null || !SettingsManager.settings.showSubtitles || string.IsNullOrEmpty(text))
		{
			return default(SubtitleId);
		}
		string[] array = text.Split("<br>");
		if (array.Length == 0)
		{
			return default(SubtitleId);
		}
		SubtitleId result = default(SubtitleId);
		SubtitleInfo subtitleInfo;
		if (uiMan.subtitleFirstFree != -1)
		{
			result.index = uiMan.subtitleFirstFree;
			subtitleInfo = uiMan.subtitlesActive[result.index];
			result.generation = ++subtitleInfo.generation;
			uiMan.subtitleFirstFree = subtitleInfo.nextFree;
		}
		else
		{
			subtitleInfo = new SubtitleInfo();
			result.generation = (subtitleInfo.generation = 1);
			result.index = uiMan.subtitlesActive.Count;
			uiMan.subtitlesActive.Add(subtitleInfo);
		}
		subtitleInfo.lines.Clear();
		for (int i = 0; i < array.Length; i++)
		{
			(string, float) tuple = GetDelay(array[i]);
			string item = tuple.Item1;
			float item2 = tuple.Item2;
			item = style + DarkMachineFunctions.ProcessText(item);
			subtitleInfo.lines.Add((item, item2));
		}
		subtitleInfo.parent = instance.subtitlePoolRoot;
		subtitleInfo.offset = Vector3.zero;
		subtitleInfo.style = style;
		subtitleInfo.originalText = text;
		subtitleInfo.groupId = DarkMachineFunctions.HashString(text);
		subtitleInfo.flags = SubtitleFlags.Default;
		subtitleInfo.radius = float.PositiveInfinity;
		subtitleInfo.priority = 0;
		subtitleInfo.timeGrace = 0f;
		subtitleInfo.timeGraceTotal = 0.5f;
		subtitleInfo.timeRemainingInLine = subtitleInfo.lines[0].delay;
		subtitleInfo.lineIndex = 0;
		subtitleInfo.index = result.index;
		subtitleInfo.version = uiMan.subtitleVersion++;
		return result;
		static (string, float) GetDelay(string text2)
		{
			float num = 0f;
			Match match = Regex.Match(text2, "<delay\\s*=\\s*([+-]?\\d*(?:\\.\\d+)?|\\d+)>", RegexOptions.IgnoreCase);
			if (match.Success)
			{
				if (float.TryParse(match.Groups[1].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result2))
				{
					num = result2;
				}
				text2 = text2.Remove(match.Index, match.Length);
			}
			return (text2, (float)text2.Length * 0.1f + 0.8f + num);
		}
	}

	public static void SubtitleGroupId(SubtitleId id, long groupId)
	{
		CL_UIManager uiMan = CL_GameManager.gMan.uiMan;
		if (!(uiMan == null) && uiMan.subtitlesActive != null && uiMan.subtitlesActive.Count != 0)
		{
			SubtitleInfo subtitleInfo = uiMan.subtitlesActive[id.index];
			if (subtitleInfo.generation == id.generation)
			{
				subtitleInfo.groupId = groupId;
			}
		}
	}

	public static void SubtitleSpace(SubtitleId id, Transform parent, Vector3 localPos, float radius)
	{
		CL_UIManager uiMan = CL_GameManager.gMan.uiMan;
		if (!(uiMan == null) && uiMan.subtitlesActive != null && uiMan.subtitlesActive.Count != 0)
		{
			SubtitleInfo subtitleInfo = uiMan.subtitlesActive[id.index];
			if (subtitleInfo.generation == id.generation)
			{
				subtitleInfo.parent = parent;
				subtitleInfo.offset = localPos;
				subtitleInfo.radius = radius;
			}
		}
	}

	public static void SubtitlePriority(SubtitleId id, int priority)
	{
		CL_UIManager uiMan = CL_GameManager.gMan.uiMan;
		if (!(uiMan == null) && uiMan.subtitlesActive != null && uiMan.subtitlesActive.Count != 0)
		{
			SubtitleInfo subtitleInfo = uiMan.subtitlesActive[id.index];
			if (subtitleInfo.generation == id.generation)
			{
				subtitleInfo.priority = priority;
			}
		}
	}

	public static void SubtitleFlagsSet(SubtitleId id, SubtitleFlags overflow)
	{
		CL_UIManager uiMan = CL_GameManager.gMan.uiMan;
		if (!(uiMan == null) && uiMan.subtitlesActive != null && uiMan.subtitlesActive.Count != 0)
		{
			SubtitleInfo subtitleInfo = uiMan.subtitlesActive[id.index];
			if (subtitleInfo.generation == id.generation)
			{
				subtitleInfo.flags = overflow;
			}
		}
	}

	public static void SubtitleFadeTime(SubtitleId id, float time)
	{
		CL_UIManager uiMan = CL_GameManager.gMan.uiMan;
		if (!(uiMan == null) && uiMan.subtitlesActive != null && uiMan.subtitlesActive.Count != 0)
		{
			SubtitleInfo subtitleInfo = uiMan.subtitlesActive[id.index];
			if (subtitleInfo.generation == id.generation)
			{
				subtitleInfo.timeGraceTotal = time;
			}
		}
	}

	public static void SubtitleDestroy(SubtitleId id, bool instant)
	{
		CL_UIManager uiMan = CL_GameManager.gMan.uiMan;
		if (uiMan != null && id.index < uiMan.subtitlesActive.Count && uiMan.subtitlesActive[id.index].generation == id.generation)
		{
			if (instant)
			{
				uiMan.subtitlesActive[id.index].nextFree = uiMan.subtitleFirstFree;
				uiMan.subtitleFirstFree = id.index;
				uiMan.subtitlesActive[id.index].generation++;
			}
			else
			{
				uiMan.subtitlesActive[id.index].parent = instance.subtitlePoolRoot;
				uiMan.subtitlesActive[id.index].offset = Vector3.zero;
				uiMan.subtitlesActive[id.index].radius = float.NegativeInfinity;
			}
		}
	}

	private void UpdateVisibleSubtitles()
	{
		if (CL_GameManager.gMan.isPaused)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		ENT_Player player = ENT_Player.GetPlayer();
		Vector3 vector = Vector3.zero;
		Vector3 forward = Vector3.forward;
		Vector3 right = Vector3.right;
		if (player != null)
		{
			vector = player.transform.position;
			forward = player.transform.forward;
			right = player.transform.right;
		}
		subtitlesPlaying.Clear();
		subtitlesCollecting.Clear();
		int num = 4;
		for (int i = 0; i < subtitleArrowCache.Length; i++)
		{
			char c = ((i == 0) ? '<' : '>');
			if (subtitleArrowCache[i].Length < num)
			{
				subtitleArrowCache[i] = new string[num];
				for (int j = 0; j < num; j++)
				{
					subtitleArrowCache[i][j] = new string(c, j);
				}
			}
		}
		bool showSubtitlesDirection = SettingsManager.settings.showSubtitlesDirection;
		bool showSubtitlesAmbient = SettingsManager.settings.showSubtitlesAmbient;
		for (int k = 0; k < subtitlesActive.Count; k++)
		{
			SubtitleInfo subtitleInfo = subtitlesActive[k];
			if (subtitleInfo.generation % 2 == 0)
			{
				continue;
			}
			subtitleInfo.timeRemainingInLine -= deltaTime;
			bool flag = false;
			if (subtitleInfo.timeRemainingInLine <= 0f)
			{
				subtitleInfo.lineIndex++;
				if ((subtitleInfo.flags & (SubtitleFlags.Kill | SubtitleFlags.Saturate | SubtitleFlags.Overflow)) == 0)
				{
					subtitleInfo.flags |= SubtitleFlags.Kill;
				}
				if (subtitleInfo.lineIndex < subtitleInfo.lines.Count)
				{
					subtitleInfo.timeRemainingInLine += subtitleInfo.lines[subtitleInfo.lineIndex].delay;
				}
				else if ((subtitleInfo.flags & SubtitleFlags.Saturate) != 0)
				{
					subtitleInfo.flags |= SubtitleFlags.Autofill;
					subtitleInfo.lineIndex--;
				}
				else if ((subtitleInfo.flags & SubtitleFlags.Overflow) != 0)
				{
					subtitleInfo.lineIndex = 0;
					subtitleInfo.timeRemainingInLine += subtitleInfo.lines[subtitleInfo.lineIndex].delay;
				}
				else if ((subtitleInfo.flags & SubtitleFlags.Kill) != 0)
				{
					subtitleInfo.lineIndex--;
					flag = true;
					bool flag2 = subtitleInfo.timeGrace <= 0f;
					SubtitleDestroy(new SubtitleId
					{
						generation = subtitleInfo.generation,
						index = k
					}, flag2);
					if (flag2)
					{
						continue;
					}
				}
			}
			bool flag3 = false;
			if (subtitleInfo.timeGrace > 0f)
			{
				flag3 = true;
			}
			Vector3 vector2 = subtitleInfo.offset;
			if (subtitleInfo.parent != null)
			{
				vector2 = subtitleInfo.parent.transform.localToWorldMatrix.MultiplyPoint(vector2);
			}
			float sqrMagnitude = (vector - vector2).sqrMagnitude;
			bool flag4 = sqrMagnitude < subtitleInfo.radius * subtitleInfo.radius;
			if (flag4)
			{
				flag3 = true;
			}
			if ((subtitleInfo.flags & SubtitleFlags.Ambient) != 0 && !showSubtitlesAmbient)
			{
				flag3 = false;
			}
			if (flag3 && flag4 && !flag && (subtitleInfo.flags & SubtitleFlags.Autofill) != 0)
			{
				subtitleInfo.timeGrace = Mathf.Min(subtitleInfo.timeGrace + deltaTime * 2f, subtitleInfo.timeGraceTotal);
			}
			if (flag3 && flag4 && !flag && (subtitleInfo.flags & SubtitleFlags.Autofill) == 0)
			{
				subtitleInfo.timeGrace = subtitleInfo.timeGraceTotal;
			}
			if (flag3)
			{
				subtitleInfo.lastDistSqr = sqrMagnitude;
				subtitlesCollecting.Add(subtitleInfo);
			}
			if (subtitlesDebug)
			{
				Color color = DarkMachineCrayons.crayons[k % DarkMachineCrayons.crayons.Length];
				CL_DebugView.draw.PushColor(color);
				float radius = subtitleInfo.radius;
				List<string> list = new List<string>();
				list.Add($"Pos: {vector2}, Radius: {radius}");
				list.Add($"{subtitleInfo.timeRemainingInLine}");
				list.Add(subtitleInfo.lines[subtitleInfo.lineIndex].line);
				CL_DebugView.draw.WireSphere(vector2, radius);
				CL_DebugView.draw.Label2D(vector2, string.Join('\n', list));
				CL_DebugView.draw.PopColor();
			}
		}
		subtitlesCollecting.Sort();
		if (subtitlesCollecting.Count > 0)
		{
			subtitlesCollecting[0].timeGrace = Mathf.Max(subtitlesCollecting[0].timeGrace - deltaTime, 0f);
			subtitlesPlaying.Add(0);
		}
		for (int l = 1; l < subtitlesCollecting.Count; l++)
		{
			subtitlesCollecting[l].timeGrace = Mathf.Max(subtitlesCollecting[l].timeGrace - deltaTime, 0f);
			if (subtitlesCollecting[l - 1].groupId != subtitlesCollecting[l].groupId || subtitlesCollecting[l - 1].groupId == 0L)
			{
				subtitlesPlaying.Add(l);
			}
		}
		int num2 = 4;
		if (subtitlesPlaying.Count > num2)
		{
			subtitlesPlaying.RemoveRange(num2, subtitlesPlaying.Count - num2);
		}
		for (int m = 0; m < subtitlesPlaying.Count; m++)
		{
			SubtitleInfo subtitleInfo2 = subtitlesCollecting[subtitlesPlaying[m]];
			int num3 = -1;
			for (int n = 0; n < subtitleParent.childCount; n++)
			{
				if (subtitleParent.GetChild(n).GetComponent<UI_Subtitle>().subtitleGroupId == subtitleInfo2.groupId)
				{
					num3 = n;
					break;
				}
			}
			UI_Subtitle result = null;
			if (num3 != -1)
			{
				result = subtitleParent.GetChild(num3).GetComponent<UI_Subtitle>();
			}
			if (num3 != -1 && m != num3)
			{
				subtitleParent.GetChild(num3).transform.SetSiblingIndex(m);
			}
			if (num3 == -1 && subtitleInfo2.lines != null && subtitleInfo2.lines.Count > subtitleInfo2.lineIndex)
			{
				if (!subtitleObjectPool.TryPop(out result))
				{
					result = UnityEngine.Object.Instantiate(subtitleObject);
				}
				result.transform.parent = subtitleParent;
				result.gameObject.SetActive(value: true);
				result.subtitleGroupId = subtitleInfo2.groupId;
				result.lineIndex = subtitleInfo2.lineIndex;
				result.typewriter.ShowText(subtitleInfo2.lines[subtitleInfo2.lineIndex].line);
				result.transform.SetSiblingIndex(m);
				if ((subtitleInfo2.flags & SubtitleFlags.Autofill) != 0)
				{
					TypewriterCore typewriter = result.typewriter;
					StartCoroutine(EnqueueProcessDt(delegate
					{
						typewriter.SkipTypewriter();
					}));
				}
				else
				{
					TextAnimator_TMP anim = result.animator;
					float textDt = subtitleInfo2.lines[subtitleInfo2.lineIndex].delay - subtitleInfo2.timeRemainingInLine;
					StartCoroutine(EnqueueProcessDt(delegate
					{
						anim.Animate(textDt);
					}));
				}
			}
			if (result == null)
			{
				Debug.LogError("Subby was null!");
			}
			if (result != null && result.lineIndex != subtitleInfo2.lineIndex && subtitleInfo2.lines != null && subtitleInfo2.lines.Count > subtitleInfo2.lineIndex)
			{
				result.typewriter.ShowText(subtitleInfo2.lines[subtitleInfo2.lineIndex].line);
				result.lineIndex = subtitleInfo2.lineIndex;
			}
			result.animator.Animate(Time.unscaledDeltaTime);
			float num4 = 0f;
			float num5 = 0f;
			if (showSubtitlesDirection & ((subtitleInfo2.flags & SubtitleFlags.Directionality) != 0) & float.IsFinite(subtitleInfo2.radius))
			{
				int num6 = subtitlesPlaying[m];
				while (true)
				{
					SubtitleInfo subtitleInfo3 = subtitlesCollecting[num6];
					Vector3 vector3 = subtitleInfo3.offset;
					if (subtitleInfo3.parent != null)
					{
						vector3 = subtitleInfo3.parent.transform.localToWorldMatrix.MultiplyPoint(vector3);
					}
					Vector3 normalized = (vector3 - vector).normalized;
					int num7 = ((!(Vector3.Dot(right, normalized) > 0f)) ? 1 : 2);
					float num8 = (Vector3.Dot(-forward, normalized) + 1f) * 0.5f;
					if (num8 > 0.9f)
					{
						num7 = 3;
					}
					if ((num7 & 2) != 0)
					{
						num5 = Mathf.Max(num5, num8);
					}
					if ((num7 & 1) != 0)
					{
						num4 = Mathf.Max(num4, num8);
					}
					if (num6 >= subtitlesCollecting.Count - 1 || subtitlesCollecting[num6].groupId != subtitlesCollecting[num6 + 1].groupId || subtitlesCollecting[num6 + 1].groupId == 0)
					{
						break;
					}
					num6++;
				}
			}
			if (result != null)
			{
				result.leftArrow.text = subtitleArrowCache[0][Mathf.FloorToInt(num4 * (float)num)];
				result.rightArrow.text = subtitleArrowCache[1][Mathf.FloorToInt(num5 * (float)num)];
				Color color2 = new Color(1f, 1f, 1f, subtitleInfo2.timeGrace / subtitleInfo2.timeGraceTotal);
				result.text.color = color2;
				result.leftArrow.color = color2 * Color.grey;
				result.rightArrow.color = color2 * Color.grey;
			}
		}
		int childCount = subtitleParent.childCount;
		for (int num9 = subtitlesPlaying.Count; num9 < childCount; num9++)
		{
			Transform child = subtitleParent.GetChild(subtitlesPlaying.Count);
			child.parent = subtitlePoolRoot;
			subtitleObjectPool.Push(child.GetComponent<UI_Subtitle>());
		}
		static IEnumerator EnqueueProcessDt(Action what)
		{
			yield return null;
			what();
		}
	}

	public static void ShowSubtitle(string text, string style = "")
	{
		CL_UIManager uiMan = CL_GameManager.gMan.uiMan;
		SubtitleDestroy(uiMan.globalSubtitles, instant: true);
		uiMan.globalSubtitles = SubtitleCreate(text, style);
		SubtitleFlagsSet(uiMan.globalSubtitles, SubtitleFlags.Kill);
		SubtitlePriority(uiMan.globalSubtitles, 10000);
	}

	public static UI_Popup_Alert CreatePopup(string id, UI_Popup_Alert.PopupData popupData, Transform parent)
	{
		UI_Popup_Alert uI_Popup_Alert = Resources.Load<UI_Popup_Alert>("UI/Popups/" + id);
		if (uI_Popup_Alert == null)
		{
			Debug.LogError("No Popup ID Found: " + id + " :: Cancelling Request.");
			return null;
		}
		UI_Popup_Alert uI_Popup_Alert2 = UnityEngine.Object.Instantiate(uI_Popup_Alert, parent);
		uI_Popup_Alert2.SetData(popupData);
		return uI_Popup_Alert2;
	}

	public HUD_CustomElement AddCustomHudElement(HUD_CustomElement customElement)
	{
		if (customElementDict == null)
		{
			customElementDict = new Dictionary<string, HUD_CustomElement>();
		}
		if (customElementDict.ContainsKey(customElement.id))
		{
			return customElementDict[customElement.id];
		}
		HUD_CustomElement hUD_CustomElement = UnityEngine.Object.Instantiate(customElement, customElementLayoutGroup);
		customElementDict.Add(hUD_CustomElement.id, hUD_CustomElement);
		return hUD_CustomElement;
	}

	public void RemoveCustomHudElement(string id)
	{
		if (customElementDict == null)
		{
			customElementDict = new Dictionary<string, HUD_CustomElement>();
		}
		if (customElementDict.ContainsKey(id))
		{
			customElementDict[id].Remove();
			customElementDict.Remove(id);
		}
	}
}
