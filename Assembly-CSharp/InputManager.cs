using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Data;
using Rewired.Glyphs.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	[Serializable]
	public class ButtonInput
	{
		public string name;

		public Rewired.InputAction action;

		public Rewired.InputAction altAction;

		public bool Pressed { get; set; }

		public bool Down { get; set; }

		public bool Up { get; set; }
	}

	[Serializable]
	public class VectorInput
	{
		public string name;

		public Rewired.InputAction horAction;

		public Rewired.InputAction verAction;

		public Vector2 vector;

		public float axis;

		public bool Pressed { get; set; }

		public bool Down { get; set; }

		public bool Up { get; set; }
	}

	[Serializable]
	public class SpriteIcon
	{
		public string controlScheme;

		public string bindingDisplayName;

		public string assetID;

		public string spriteid;
	}

	public List<SpriteIcon> buttonInputSprites;

	public static InputManager instance;

	private List<ButtonInput> buttonInputs;

	private Dictionary<string, ButtonInput> buttons;

	private List<VectorInput> vectorInputs;

	private Dictionary<string, VectorInput> vectors;

	public static List<string> controlSchemes = new List<string> { "KeyboardMouse", "Gamepad" };

	public AnimationCurve gamepadLookCurve;

	public float gamepadSpeedAdjust = 0.8f;

	public AnimationCurve gamepadLookAccelerationCurve;

	public float gamepadLookAcceleration = 1f;

	private static Vector2 lastGamepadLook;

	private static UnityEngine.InputSystem.Gyroscope gyroscope;

	private Player player;

	public Rewired.InputManager rewiredInputManager;

	public UserDataStore_File inputDataStore;

	public static ControllerMap defaultControllerMap;

	public static ControllerMap defaultKeyboardMap;

	public static ControllerMap defaultMouseMap;

	private static bool hasInitialized = false;

	public UnityTextMeshProGlyphHelper retrievalGlyphHelper;

	private TMP_Text retrievalGlyphText;

	public static Dictionary<string, string> actionDisplayStringDict;

	public Vector2 MoveInput { get; private set; }

	private void Awake()
	{
		player = ReInput.players.GetPlayer(0);
		if (player != null)
		{
			hasInitialized = true;
			ControllerIdentifier controllerIdentifier = new ControllerIdentifier
			{
				controllerId = -1,
				controllerType = ControllerType.Joystick,
				hardwareIdentifier = "WindowsWindowsGamingInputGamepad0b12045e",
				hardwareTypeGuid = new Guid("19002688-7406-4f4a-8340-8d25335406c8")
			};
			defaultControllerMap = player.controllers.maps.GetMap(ControllerType.Joystick, 0, "Default", "Default").Copy();
			if (defaultControllerMap == null)
			{
				defaultControllerMap = ReInput.mapping.GetJoystickMapInstanceSavedOrDefault(0, controllerIdentifier, 0, 0);
			}
			defaultKeyboardMap = player.controllers.maps.GetMap(ControllerType.Keyboard, 0, "Default", "Default").Copy();
			defaultMouseMap = player.controllers.maps.GetMap(ControllerType.Mouse, 0, "Default", "Default").Copy();
		}
		inputDataStore.Load();
		if (instance == null)
		{
			instance = this;
		}
		SetupActions();
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
		hasInitialized = false;
	}

	private void Update()
	{
		UpdateInputs();
		UpdateCursorVisibility();
	}

	public void SetupActions()
	{
		buttonInputs = new List<ButtonInput>();
		buttons = new Dictionary<string, ButtonInput>();
		vectorInputs = new List<VectorInput>();
		vectors = new Dictionary<string, VectorInput>();
		foreach (Rewired.InputAction action in ReInput.mapping.Actions)
		{
			if (action.type == Rewired.InputActionType.Button)
			{
				if (action.name.Contains(":alt"))
				{
					string key = action.name.Split(':')[0];
					if (buttons.TryGetValue(key, out var value))
					{
						value.altAction = action;
						continue;
					}
					value = new ButtonInput();
					value.name = key;
					value.action = action;
					value.altAction = action;
					buttonInputs.Add(value);
					buttons.Add(value.name, value);
				}
				else
				{
					ButtonInput buttonInput = new ButtonInput();
					if (buttons.ContainsKey(action.name))
					{
						buttonInput = buttons[action.name];
					}
					else
					{
						buttons.Add(action.name, buttonInput);
					}
					buttonInput.name = action.name;
					buttonInput.action = action;
					buttonInputs.Add(buttonInput);
				}
			}
			else
			{
				if (action.type != Rewired.InputActionType.Axis)
				{
					continue;
				}
				if (action.name.Contains(":horizontal") || action.name.Contains(":vertical"))
				{
					bool flag = action.name.Contains(":vertical");
					string key2 = action.name.Split(':')[0];
					if (vectors.TryGetValue(key2, out var value2))
					{
						if (flag)
						{
							value2.verAction = action;
						}
						else
						{
							value2.horAction = action;
						}
						continue;
					}
					value2 = new VectorInput();
					value2.name = key2;
					if (flag)
					{
						value2.verAction = action;
					}
					else
					{
						value2.horAction = action;
					}
					vectorInputs.Add(value2);
					vectors.Add(value2.name, value2);
				}
				else
				{
					VectorInput vectorInput = new VectorInput();
					vectorInput.name = action.name;
					vectorInput.horAction = action;
					vectorInputs.Add(vectorInput);
					vectors.Add(vectorInput.name, vectorInput);
				}
			}
		}
	}

	public void UpdateInputs()
	{
		if (buttonInputs == null)
		{
			return;
		}
		foreach (ButtonInput buttonInput in buttonInputs)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (buttonInput.altAction != null)
			{
				flag = player.GetButton(buttonInput.altAction.id) || player.GetNegativeButton(buttonInput.altAction.id);
				flag2 = player.GetButtonDown(buttonInput.altAction.id) || player.GetNegativeButtonDown(buttonInput.altAction.id);
				flag3 = player.GetButtonUp(buttonInput.altAction.id) || player.GetNegativeButtonUp(buttonInput.altAction.id);
			}
			if (SettingsManager.settings.toggleGrab && !CL_GameManager.gMan.isPaused && (buttonInput.name == "Hand-Left" || buttonInput.name == "Hand-Right"))
			{
				buttonInput.Down = player.GetButtonDown(buttonInput.action.id) || flag2 || player.GetNegativeButtonDown(buttonInput.action.id);
				if (buttonInput.Down && buttonInput.Pressed)
				{
					buttonInput.Up = true;
					buttonInput.Pressed = false;
				}
				else if (buttonInput.Down && !buttonInput.Pressed)
				{
					buttonInput.Up = false;
					buttonInput.Pressed = true;
				}
			}
			else
			{
				buttonInput.Down = player.GetButtonDown(buttonInput.action.id) || flag2 || player.GetNegativeButtonDown(buttonInput.action.id);
				buttonInput.Up = player.GetButtonUp(buttonInput.action.id) || flag3 || player.GetNegativeButtonUp(buttonInput.action.id);
				buttonInput.Pressed = player.GetButton(buttonInput.action.id) || flag || player.GetNegativeButton(buttonInput.action.id);
			}
		}
		foreach (VectorInput vectorInput in vectorInputs)
		{
			bool flag4 = vectorInput.horAction != null;
			bool flag5 = vectorInput.verAction != null;
			float x = (flag4 ? player.GetAxis(vectorInput.horAction.id) : 0f);
			float y = (flag5 ? player.GetAxis(vectorInput.verAction.id) : 0f);
			vectorInput.vector = new Vector2(x, y);
			vectorInput.Pressed = (flag4 && player.GetButton(vectorInput.horAction.id)) || (flag5 && player.GetButton(vectorInput.verAction.id));
			vectorInput.Down = (flag4 && player.GetButtonDown(vectorInput.horAction.id)) || (flag5 && player.GetButtonDown(vectorInput.verAction.id));
			vectorInput.Up = (flag4 && player.GetButtonUp(vectorInput.horAction.id)) || (flag5 && player.GetButtonDown(vectorInput.verAction.id));
		}
	}

	public static ButtonInput GetButton(string name)
	{
		if (instance.buttons.ContainsKey(name))
		{
			return instance.buttons[name];
		}
		Debug.LogWarning("Warning: No button " + name + " found in list. Suppling Fake");
		return new ButtonInput
		{
			Down = false,
			Up = false,
			Pressed = false,
			action = null
		};
	}

	public static VectorInput GetVector(string name)
	{
		if (instance.vectors.ContainsKey(name))
		{
			return instance.vectors[name];
		}
		Debug.LogError("Missing Vector Input: " + name);
		return null;
	}

	public static Player GetPlayerInput()
	{
		return instance.player;
	}

	public static void RefreshActionStringDict()
	{
		actionDisplayStringDict = new Dictionary<string, string>();
	}

	public static string QuickGetBindingDisplayString(string scheme, Rewired.InputAction action)
	{
		if (actionDisplayStringDict == null)
		{
			RefreshActionStringDict();
		}
		if (actionDisplayStringDict.ContainsKey(scheme + action.name))
		{
			return actionDisplayStringDict[scheme + action.name];
		}
		return "";
	}

	public static string GetBindingDisplayStringOrCompositeName(string scheme, Rewired.InputAction action)
	{
		return "NULL";
	}

	public static void SetControlScheme(string schemeName)
	{
		_ = instance == null;
	}

	public static void SetAutoSwitchControlSchemes(bool b)
	{
		_ = instance == null;
	}

	public static List<string> GetControlSchemes()
	{
		return controlSchemes;
	}

	public static AnimationCurve GetGamepadLookCurve()
	{
		return instance.gamepadLookCurve;
	}

	public static Vector2 GetLookVector()
	{
		Vector2 result = GetVector("Look").vector;
		if (IsGamepad())
		{
			result = result.normalized * GetGamepadLookCurve().Evaluate(result.magnitude) * Time.unscaledDeltaTime * 150f;
			result *= instance.gamepadSpeedAdjust;
			float num = (float)SettingsManager.settings.controllerXSensitivity * 2f;
			float num2 = (float)SettingsManager.settings.controllerYSensitivity * 2f;
			result.x *= num;
			result.y *= num2;
			float num3 = (1f - instance.gamepadLookAccelerationCurve.Evaluate((float)SettingsManager.settings.controllerAcceleration) + 0.01f) * 5f;
			result = (lastGamepadLook = Vector2.Lerp(lastGamepadLook, result, CL_GameManager.GetPlayerPerceivedDeltaTime() * (instance.gamepadLookAcceleration * num3)));
		}
		else
		{
			float num4 = (float)SettingsManager.settings.mouseSensitivityX * 2f;
			float num5 = (float)SettingsManager.settings.mouseSensitivityY * 2f;
			result.x *= num4;
			result.y *= num5;
		}
		return result;
	}

	public string GetTMPSpriteForButton(string buttonID, string scheme)
	{
		foreach (SpriteIcon buttonInputSprite in buttonInputSprites)
		{
			if (buttonInputSprite.bindingDisplayName == buttonID && buttonInputSprite.controlScheme == scheme)
			{
				return "<sprite=\"" + buttonInputSprite.assetID + "\" name=\"" + buttonInputSprite.spriteid + "\">";
			}
		}
		return buttonID;
	}

	public static bool IsGamepad()
	{
		if (instance.player == null || !instance.didAwake || !hasInitialized)
		{
			return false;
		}
		Controller lastActiveController = instance.player.controllers.GetLastActiveController();
		if (lastActiveController == null)
		{
			return false;
		}
		return lastActiveController.type == ControllerType.Joystick;
	}

	internal static void ActivateMap(int v)
	{
	}

	internal static void DeactivateMap(int v)
	{
	}

	internal static void UpdateCursorVisibility()
	{
		if (CL_GameManager.showCursor || CommandConsole.IsConsoleVisible())
		{
			if (IsGamepad() && !SettingsManager.settings.allowCombinedInput)
			{
				Cursor.visible = false;
			}
			else
			{
				Cursor.visible = true;
			}
		}
		else
		{
			Cursor.visible = false;
		}
	}

	public static UnityEngine.InputSystem.Gyroscope GetGyroscope()
	{
		if (gyroscope == null)
		{
			Debug.Log("Are we even fucking getting here " + UnityEngine.InputSystem.Gyroscope.current);
			Debug.Log("Are we even fucking getting here aaaa " + Input.gyro);
			if (UnityEngine.InputSystem.Gyroscope.current != null && !UnityEngine.InputSystem.Gyroscope.current.enabled)
			{
				Debug.Log("Are we even fucking getting here 2");
			}
			gyroscope = UnityEngine.InputSystem.Gyroscope.current;
		}
		return gyroscope;
	}

	public static void BindToAction()
	{
	}

	public void ResetAllBindings()
	{
		inputDataStore.ClearSaveData();
		player.controllers.maps.LoadDefaultMaps(ControllerType.Keyboard);
		player.controllers.maps.LoadDefaultMaps(ControllerType.Mouse);
		player.controllers.maps.LoadDefaultMaps(ControllerType.Joystick);
		SettingsManager.RefreshSettings("bindings");
	}

	public void ResetBindingToDefault(string actionName)
	{
	}

	public static string ProcessTextForGlyphs(string t)
	{
		if (instance != null && instance.retrievalGlyphHelper != null)
		{
			instance.retrievalGlyphHelper.text = t;
			return instance.retrievalGlyphText.text;
		}
		return t;
	}
}
