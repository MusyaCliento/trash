using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class SettingsManager : MonoBehaviour
{
	public class GameSettings
	{
		[Serializable]
		public class CompetitiveSettings
		{
			public List<string> lockerItems;

			public List<string> perks;
		}

		public int version = 2;

		public bool fullscreen = true;

		public int screenResX;

		public int screenResY;

		public float playerFOV = 90f;

		public double masterVolume = 0.75;

		public double musicVolume = 0.75;

		public double announcerVolume = 0.800000011920929;

		public double ambienceVolume = 1.0;

		public bool muteWhenNotFocused;

		public double mouseSensitivity = 0.5;

		public double mouseSensitivityX = 0.5;

		public double mouseSensitivityY = 0.5;

		public double controllerXSensitivity = 0.5;

		public double controllerYSensitivity = 0.5;

		public double controllerAcceleration = 0.20000000298023224;

		public bool useControllerGyro;

		public float controllerGyroSensitivity = 1f;

		public double brightness = 1.0;

		public string refreshRate;

		public bool toggleInventory;

		public bool toggleCrouch;

		public bool toggleFocus;

		public bool toggleGrab;

		public bool alwaysSprint;

		public bool directionalSwing = true;

		public bool inverseRopeSwing;

		public bool invertY;

		public bool vsync = true;

		public CompetitiveSettings competitiveSettings = new CompetitiveSettings
		{
			lockerItems = new List<string> { "Item_Injector", "Item_Pillbottle" }
		};

		public bool g_competitive;

		public bool g_iron;

		public bool g_hard;

		public bool g_timer;

		public bool g_runInfo;

		public bool g_skipDeathPopup;

		public bool g_skipScoreScreen;

		public bool postprocessing = true;

		public bool ditherEffect = true;

		public bool crtEffect = true;

		public bool vertexJitter = true;

		public bool forwardPlusRendering;

		public int controlScheme;

		public bool autoswitchControls = true;

		public bool forceKeyboard;

		public int voice;

		public double UIScale = 0.75;

		public double crosshairScale = 1.0;

		public int crosshair;

		public double handIconScale = 0.800000011920929;

		public bool showSubtitles;

		public bool showSubtitlesBacking;

		public bool showSubtitlesDirection;

		public bool showSubtitlesAmbient;

		public float subtitleBackingOpacity = 1f;

		public float subtitleFontScale = 1f;

		public bool disableSprintFov;

		public bool disableFOVChange;

		public bool disableSprintAnim;

		public bool epilepsy;

		public bool entomophobia;

		public bool hideSplatterOverlay;

		public bool unlockAll;

		public bool handholdHighVis;

		public bool itemHighVis;

		public bool extraHandholdShimmer;

		public bool freezeHandholdShimmer;

		public int cloudQuality = 2;

		public int effectQuality = 2;

		public float decalMult = 1f;

		public float screenShakeMultiplier = 1f;

		public float headbobMultiplier = 1f;

		public float handbobMultiplier = 1f;

		public bool lowQualityFog;

		public bool debugCamDepthDisable;

		public bool unlockFramerate;

		public int targetFramerate = 144;

		public bool allowCombinedInput;

		public bool experimentalFeatures;

		public string currentBaseColorSetting = "WKColor_Base";

		public CL_CosmeticManager.CosmeticSaveData cosmeticSaveData = new CL_CosmeticManager.CosmeticSaveData();
	}

	public enum BuildType
	{
		standard = 0,
		dev = 1
	}

	public static GameSettings settings;

	private string filePath;

	public AudioMixer musicMixer;

	public AudioMixer effectMixer;

	public static SettingsManager instance;

	public static Action _OnRefreshAllSettings;

	public static Action<string> _OnRefreshSetting;

	public static BuildType buildType;

	private static ColorSettingsSet colorSettingSet;

	private static ColorSetting currentColorSetting;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		filePath = Path.Combine(Application.persistentDataPath, "settings.json");
		if (settings == null)
		{
			LoadSettings();
		}
		buildType = BuildType.standard;
		settings.unlockAll = false;
		Debug.Log("ACK");
		if (colorSettingSet == null)
		{
			colorSettingSet = Resources.Load<ColorSettingsSet>("Settings/WKColor/WKColorSet_Base");
			if (currentColorSetting == null)
			{
				UpdateCurrentColorSetting();
			}
		}
	}

	public void UpdateSettings()
	{
		if (settings.version < 2)
		{
			settings.version = 2;
			UI_Popup_Alert.PopupData popupData = new UI_Popup_Alert.PopupData
			{
				title = "Notice",
				desc = "<color=red>Use New Sprinting Animation?</color>\nYou can change this in the settings.",
				leftButtonDesc = "Yes",
				rightButtonDesc = "No",
				rightButtonAction = delegate
				{
					settings.disableSprintAnim = true;
				},
				leftButtonAction = delegate
				{
					settings.disableSprintAnim = false;
				}
			};
			UT_Locator locator = UT_Locator.GetLocator("UI_Alert_Root");
			if (locator != null)
			{
				CL_UIManager.CreatePopup("Popup-Notice-Generic", popupData, locator.transform);
			}
			RefreshSettings();
		}
	}

	private void Start()
	{
		RefreshSettings();
	}

	private void OnDestroy()
	{
		SaveSettings();
	}

	public void SaveSettings()
	{
		string contents = JsonUtility.ToJson(settings, prettyPrint: true);
		File.WriteAllText(filePath, contents);
	}

	public static void WipeSettings()
	{
		File.Delete(Path.Combine(Application.persistentDataPath, "settings.json"));
		if (instance != null)
		{
			instance.LoadSettings();
		}
	}

	public void LoadSettings()
	{
		if (File.Exists(filePath))
		{
			string text = File.ReadAllText(filePath);
			if (text.Length > 0)
			{
				settings = JsonUtility.FromJson<GameSettings>(text);
			}
			else
			{
				settings = new GameSettings();
				float num = Screen.currentResolution.height;
				float num2 = Screen.currentResolution.width;
				SetSetting(new string[2]
				{
					"screenResX",
					num2.ToString()
				});
				SetSetting(new string[2]
				{
					"screenResY",
					num.ToString()
				});
			}
		}
		else
		{
			settings = new GameSettings();
			float num3 = Screen.currentResolution.height;
			float num4 = Screen.currentResolution.width;
			if (num3 >= 1000f)
			{
				settings.UIScale = 0.75;
			}
			SetSetting(new string[2]
			{
				"screenResX",
				num4.ToString()
			});
			SetSetting(new string[2]
			{
				"screenResY",
				num3.ToString()
			});
			SetSetting(new string[2]
			{
				"UIScale",
				settings.UIScale.ToString()
			});
		}
		if (settings.cosmeticSaveData == null)
		{
			settings.cosmeticSaveData = new CL_CosmeticManager.CosmeticSaveData();
		}
		AudioListener.volume = (float)settings.masterVolume;
		RefreshSettings();
	}

	public static void SetSetting(string[] args)
	{
		if (args.Length < 2)
		{
			Debug.LogError("Insufficient arguments provided. Expected format: [variableName, value]");
			return;
		}
		string text = args[0];
		string text2 = args[1];
		FieldInfo field = typeof(GameSettings).GetField(text, BindingFlags.Instance | BindingFlags.Public);
		if (field == null)
		{
			Debug.LogError("Setting '" + text + "' not found.");
			return;
		}
		try
		{
			object value = ConvertValue(text2, field.FieldType);
			field.SetValue(settings, value);
		}
		catch (Exception ex)
		{
			Debug.LogError("Failed to set setting '" + text + "' with value '" + text2 + "'. Error: " + ex.Message);
		}
	}

	private static object ConvertValue(string valueString, Type targetType)
	{
		if (targetType == typeof(bool))
		{
			if (bool.TryParse(valueString, out var result))
			{
				return result;
			}
			throw new ArgumentException("Cannot convert '" + valueString + "' to bool.");
		}
		if (targetType == typeof(float))
		{
			if (float.TryParse(valueString, out var result2))
			{
				return result2;
			}
			throw new ArgumentException("Cannot convert '" + valueString + "' to float.");
		}
		if (targetType == typeof(double))
		{
			if (double.TryParse(valueString, out var result3))
			{
				return result3;
			}
			throw new ArgumentException("Cannot convert '" + valueString + "' to float.");
		}
		if (targetType == typeof(int))
		{
			if (int.TryParse(valueString, out var result4))
			{
				return result4;
			}
			throw new ArgumentException("Cannot convert '" + valueString + "' to int.");
		}
		if (targetType == typeof(string))
		{
			return valueString;
		}
		throw new ArgumentException($"Unsupported target type '{targetType}'.");
	}

	public static string GetSetting(string variableName)
	{
		FieldInfo field = typeof(GameSettings).GetField(variableName, BindingFlags.Instance | BindingFlags.Public);
		if (field == null)
		{
			Debug.LogError("Setting '" + variableName + "' not found.");
			return null;
		}
		object value = field.GetValue(settings);
		if (value == null)
		{
			return "null";
		}
		return value.ToString();
	}

	public static void RefreshSettings(string setting = "")
	{
		bool flag = setting == "";
		if (settings == null)
		{
			return;
		}
		if (settings.itemHighVis)
		{
			Shader.SetGlobalFloat("_OUTLINEBRIGHT", 3f);
		}
		else
		{
			Shader.SetGlobalFloat("_OUTLINEBRIGHT", 1f);
		}
		Shader.SetGlobalFloat("_DITHEREFFECT", settings.ditherEffect ? 1 : 0);
		Shader.SetGlobalFloat("_USEJITTER", settings.vertexJitter ? 1 : 0);
		if (setting == "g_hard" || setting == "g_iron")
		{
			settings.g_competitive = false;
		}
		if (settings.g_competitive)
		{
			settings.g_hard = false;
			settings.g_iron = false;
		}
		if (CL_AchievementManager.instance != null && !CL_AchievementManager.GetAchievementValue("ACH_NEST"))
		{
			settings.g_hard = false;
			settings.g_competitive = false;
			settings.g_iron = false;
		}
		if (settings.masterVolume < 0.05)
		{
			settings.masterVolume = 0.0;
		}
		AudioListener.volume = (float)settings.masterVolume;
		if (settings.musicVolume > 0.0)
		{
			instance.musicMixer.SetFloat("MasterVolume", Mathf.Lerp(-30f, 0f, (float)settings.musicVolume));
		}
		else
		{
			instance.musicMixer.SetFloat("MasterVolume", -80f);
		}
		if (settings.announcerVolume > 0.0)
		{
			instance.effectMixer.SetFloat("AnnouncerVolume", Mathf.Lerp(-30f, 0f, (float)settings.announcerVolume));
		}
		else
		{
			instance.effectMixer.SetFloat("AnnouncerVolume", -80f);
		}
		if (settings.ambienceVolume > 0.0)
		{
			instance.effectMixer.SetFloat("AmbienceVolume", Mathf.Lerp(-30f, 0f, (float)settings.ambienceVolume));
		}
		else
		{
			instance.effectMixer.SetFloat("AmbienceVolume", -80f);
		}
		if (settings.vsync)
		{
			QualitySettings.vSyncCount = 1;
		}
		else
		{
			QualitySettings.vSyncCount = 0;
		}
		if (flag || setting == "allowCombinedInput")
		{
			PlayerInput.allowDeviceUnpairing = !settings.allowCombinedInput;
			if (!flag && !settings.allowCombinedInput)
			{
				PlayerInput.GetPlayerByIndex(0).user.UnpairDevices();
			}
		}
		instance.UpdateCurrentColorSetting();
		if (!flag)
		{
			switch (setting)
			{
			case "fullscreen":
			case "refreshRate":
			case "screenResX":
			case "screenRexY":
				break;
			default:
				goto IL_0321;
			}
		}
		Screen.fullScreen = settings.fullscreen;
		if (instance != null)
		{
			instance.StartCoroutine(SetResolutionWait());
		}
		else
		{
			ChangeResolution();
		}
		goto IL_0321;
		IL_0321:
		if (_OnRefreshAllSettings != null)
		{
			FXManager.UpdateHandholdMaterialSettings();
			_OnRefreshAllSettings();
		}
		if (_OnRefreshSetting != null)
		{
			_OnRefreshSetting(setting);
		}
		static void ChangeResolution()
		{
			FullScreenMode fullScreenMode = FullScreenMode.ExclusiveFullScreen;
			fullScreenMode = (settings.fullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
			RefreshRate preferredRefreshRate = default(RefreshRate);
			float result = (float)Screen.currentResolution.refreshRateRatio.value;
			float.TryParse(settings.refreshRate, out result);
			if (float.IsNaN(result) || result == 0f || result > (float)Screen.currentResolution.refreshRateRatio.value)
			{
				settings.refreshRate = Screen.currentResolution.refreshRateRatio.value.ToString();
			}
			preferredRefreshRate.numerator = (uint)Mathf.RoundToInt(result * 1000f);
			preferredRefreshRate.denominator = 1000u;
			if (Screen.fullScreen)
			{
				Screen.SetResolution(settings.screenResX, settings.screenResY, fullScreenMode, preferredRefreshRate);
			}
			settings.targetFramerate = (int)preferredRefreshRate.value;
			Application.targetFrameRate = GetTargetFramerate();
		}
		static IEnumerator SetResolutionWait()
		{
			yield return new WaitForSeconds(0.1f);
			ChangeResolution();
			yield return new WaitForSeconds(0.1f);
		}
	}

	public static int GetTargetFramerate()
	{
		if (settings.unlockFramerate)
		{
			return 1000;
		}
		return settings.targetFramerate;
	}

	public void UpdateCurrentColorSetting()
	{
		if (colorSettingSet == null)
		{
			return;
		}
		foreach (ColorSetting colorSetting in colorSettingSet.colorSettings)
		{
			if (colorSetting.name == settings.currentBaseColorSetting)
			{
				currentColorSetting = colorSetting;
				return;
			}
		}
		currentColorSetting = colorSettingSet.colorSettings[0];
	}

	public static ColorSetting GetCurrentColorSetting()
	{
		return currentColorSetting;
	}

	public static ColorSettingsSet GetColorSettingsSet()
	{
		return colorSettingSet;
	}
}
