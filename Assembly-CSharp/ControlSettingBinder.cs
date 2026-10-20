using System;
using System.Collections;
using Rewired;
using Rewired.Glyphs.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlSettingBinder : MonoBehaviour
{
	private struct TargetMapping
	{
		public ControllerMap controllerMap;

		public int actionElementMapId;
	}

	private const string category = "Default";

	private const string layout = "Default";

	private const string uiCategory = "UI";

	private InputMapper inputMapper_keyboard = new InputMapper();

	private InputMapper inputMapper_mouse = new InputMapper();

	private InputMapper inputMapper_joystick = new InputMapper();

	public bool isJoystick;

	public string actionName;

	private InputAction action;

	public AxisRange actionRange;

	public Button button;

	public UnityUIControllerElementGlyph glyph;

	private TargetMapping _replaceTargetMapping;

	public TMP_Text rebindText;

	private int actionElementMapId = -1;

	private ActionElementMap curActionElementMap;

	private Controller lastActiveController;

	private Player player => ReInput.players.GetPlayer(0);

	private void Awake()
	{
	}

	private void Start()
	{
		lastActiveController = player.controllers.GetLastActiveController();
		action = ReInput.mapping.GetAction(actionName);
		if (action != null)
		{
			ResetActionMap();
			button.onClick.AddListener(delegate
			{
				OnInputFieldClicked();
			});
		}
	}

	private void OnEnable()
	{
		if (ReInput.isReady)
		{
			if (isJoystick)
			{
				inputMapper_joystick.options.timeout = 5f;
				inputMapper_joystick.options.ignoreMouseXAxis = true;
				inputMapper_joystick.options.ignoreMouseYAxis = true;
				inputMapper_joystick.options.allowButtonsOnFullAxisAssignment = true;
				inputMapper_joystick.options.checkForConflicts = false;
				inputMapper_joystick.InputMappedEvent += OnInputMapped;
				inputMapper_joystick.StoppedEvent += OnStopped;
			}
			else
			{
				inputMapper_keyboard.options.timeout = 5f;
				inputMapper_mouse.options.timeout = 5f;
				inputMapper_mouse.options.ignoreMouseXAxis = true;
				inputMapper_mouse.options.ignoreMouseYAxis = true;
				inputMapper_keyboard.options.allowButtonsOnFullAxisAssignment = true;
				inputMapper_mouse.options.allowButtonsOnFullAxisAssignment = true;
				inputMapper_keyboard.options.checkForConflicts = false;
				inputMapper_mouse.options.checkForConflicts = false;
				inputMapper_keyboard.options.allowKeyboardModifierKeyAsPrimary = true;
				inputMapper_keyboard.options.holdDurationToMapKeyboardModifierKeyAsPrimary = 0f;
				inputMapper_keyboard.InputMappedEvent += OnInputMapped;
				inputMapper_keyboard.StoppedEvent += OnStopped;
				inputMapper_keyboard.ErrorEvent += OnError;
				inputMapper_mouse.InputMappedEvent += OnInputMapped;
				inputMapper_mouse.StoppedEvent += OnStopped;
			}
			SettingsManager._OnRefreshSetting = (Action<string>)Delegate.Combine(SettingsManager._OnRefreshSetting, new Action<string>(OnSettingsChange));
		}
	}

	private void OnSettingsChange(string obj)
	{
		if (obj == "bindings")
		{
			ResetActionMap();
		}
	}

	private void OnError(InputMapper.ErrorEventData data)
	{
		Debug.Log(data);
	}

	private void OnDisable()
	{
		SettingsManager._OnRefreshSetting = (Action<string>)Delegate.Remove(SettingsManager._OnRefreshSetting, new Action<string>(OnSettingsChange));
		inputMapper_keyboard.Stop();
		inputMapper_mouse.Stop();
		inputMapper_joystick.Stop();
		inputMapper_keyboard.RemoveAllEventListeners();
		inputMapper_mouse.RemoveAllEventListeners();
		inputMapper_joystick.RemoveAllEventListeners();
	}

	private void Update()
	{
		if (lastActiveController == null)
		{
			lastActiveController = player.controllers.GetLastActiveController();
		}
		else if (player.controllers.GetLastActiveController() != lastActiveController)
		{
			lastActiveController = player.controllers.GetLastActiveController();
			action = ReInput.mapping.GetAction(actionName);
			if (action != null)
			{
				ResetActionMap();
			}
		}
	}

	public void ClearBinds()
	{
		if (action != null)
		{
			if (isJoystick)
			{
				player.controllers.maps.GetMap(ControllerType.Joystick, lastActiveController.id, "Default", "Default").DeleteElementMap(actionElementMapId);
			}
			else
			{
				ControllerMap map = player.controllers.maps.GetMap(ControllerType.Keyboard, lastActiveController.id, "Default", "Default");
				ControllerMap map2 = player.controllers.maps.GetMap(ControllerType.Mouse, lastActiveController.id, "Default", "Default");
				map.DeleteElementMap(actionElementMapId);
				map2.DeleteElementMap(actionElementMapId);
			}
			curActionElementMap.controllerMap.DeleteButtonMapsWithAction(action.id);
			curActionElementMap.keyCode = KeyboardKeyCode.None;
			curActionElementMap.keyboardKeyCode = KeyboardKeyCode.None;
			ResetActionMap();
			ReInput.userDataStore.Save();
		}
	}

	public void ResetToDefaultBind()
	{
		if (action != null)
		{
			InputManager.instance.ResetBindingToDefault(action.name);
			if (isJoystick)
			{
				ControllerMap map = player.controllers.maps.GetMap(ControllerType.Joystick, lastActiveController.id, "Default", "Default");
				ResetAction(map, InputManager.defaultControllerMap, action.id);
			}
			else
			{
				ControllerMap map2 = player.controllers.maps.GetMap(ControllerType.Keyboard, 0, "Default", "Default");
				ControllerMap map3 = player.controllers.maps.GetMap(ControllerType.Mouse, 0, "Default", "Default");
				ResetAction(map3, InputManager.defaultMouseMap, action.id);
				ResetAction(map2, InputManager.defaultKeyboardMap, action.id);
			}
			ResetActionMap();
			ReInput.userDataStore.Save();
		}
	}

	public void ResetAction(ControllerMap currentMap, ControllerMap defaultMap, int actionId)
	{
		currentMap.DeleteElementMapsWithAction(actionId);
		foreach (ActionElementMap item in defaultMap.ElementMapsWithAction(actionId))
		{
			currentMap.CreateElementMap(action.id, item.axisContribution, item.elementIdentifierId, item.elementType, item.axisRange, item.invert);
		}
	}

	private void OnInputFieldClicked()
	{
		if (!isJoystick)
		{
			ControllerMap map = player.controllers.maps.GetMap(ControllerType.Keyboard, 0, "Default", "Default");
			ControllerMap map2 = player.controllers.maps.GetMap(ControllerType.Mouse, 0, "Default", "Default");
			ControllerMap controllerMap = (map.ContainsElementMap(actionElementMapId) ? map : ((!map2.ContainsElementMap(actionElementMapId)) ? null : map2));
			_replaceTargetMapping = new TargetMapping
			{
				actionElementMapId = actionElementMapId,
				controllerMap = controllerMap
			};
			StopAllCoroutines();
			StartCoroutine(StartListeningDelayed(map, map2));
		}
		else
		{
			ControllerMap map3 = player.controllers.maps.GetMap(ControllerType.Joystick, lastActiveController.id, "Default", "Default");
			StopAllCoroutines();
			StartCoroutine(StartListeningDelayed(map3));
		}
	}

	private IEnumerator StartListeningDelayed(ControllerMap keyboardMap, ControllerMap mouseMap = null)
	{
		yield return new WaitForSecondsRealtime(0.1f);
		if (isJoystick)
		{
			inputMapper_joystick.Start(new InputMapper.Context
			{
				actionId = action.id,
				controllerMap = keyboardMap,
				actionRange = actionRange,
				actionElementMapToReplace = keyboardMap.GetElementMap(actionElementMapId)
			});
		}
		else
		{
			inputMapper_keyboard.Start(new InputMapper.Context
			{
				actionId = action.id,
				controllerMap = keyboardMap,
				actionRange = actionRange,
				actionElementMapToReplace = keyboardMap.GetElementMap(actionElementMapId)
			});
			if (mouseMap != null)
			{
				inputMapper_mouse.Start(new InputMapper.Context
				{
					actionId = action.id,
					controllerMap = mouseMap,
					actionRange = actionRange,
					actionElementMapToReplace = mouseMap.GetElementMap(actionElementMapId)
				});
			}
		}
		player.controllers.maps.SetMapsEnabled(state: false, "UI");
		if (UI_RebindOverlay.rebindOverlayInstance != null)
		{
			UI_RebindOverlay.rebindOverlayInstance.gameObject.SetActive(value: true);
			UI_RebindOverlay.rebindOverlayInstance.rebindText.text = "Listening...";
		}
		yield return new WaitForSecondsRealtime(5f);
		inputMapper_keyboard.Stop();
		inputMapper_mouse.Stop();
		inputMapper_joystick.Stop();
	}

	private void OnInputMapped(InputMapper.InputMappedEventData data)
	{
		StopAllCoroutines();
		if (!isJoystick)
		{
			inputMapper_keyboard.Stop();
			inputMapper_mouse.Stop();
			if (_replaceTargetMapping.controllerMap != null && data.actionElementMap.controllerMap != _replaceTargetMapping.controllerMap)
			{
				_replaceTargetMapping.controllerMap.DeleteElementMap(_replaceTargetMapping.actionElementMapId);
			}
		}
		else
		{
			inputMapper_joystick.Stop();
		}
		if (UI_RebindOverlay.rebindOverlayInstance != null)
		{
			UI_RebindOverlay.rebindOverlayInstance.Hide();
		}
		ReInput.userDataStore.Save();
		ResetActionMap();
	}

	private void OnStopped(InputMapper.StoppedEventData data)
	{
		if (UI_RebindOverlay.rebindOverlayInstance != null)
		{
			UI_RebindOverlay.rebindOverlayInstance.Hide();
		}
		player.controllers.maps.SetMapsEnabled(state: true, "UI");
	}

	private void ResetActionMap()
	{
		if (action == null)
		{
			glyph.actionElementMap = null;
			return;
		}
		actionElementMapId = -1;
		if (isJoystick && player.controllers.joystickCount > 0 && lastActiveController != null)
		{
			ControllerMap controllerMap = player.controllers.maps.GetMap(ControllerType.Joystick, lastActiveController.id, "Default", "Default");
			if (controllerMap == null)
			{
				controllerMap = InputManager.defaultControllerMap;
			}
			foreach (ActionElementMap item in controllerMap.ElementMapsWithAction(action.id))
			{
				if (item.ShowInField(actionRange))
				{
					base.name = item.elementIdentifierName;
					actionElementMapId = item.id;
					curActionElementMap = item;
					break;
				}
			}
		}
		else
		{
			for (int i = 0; i < 2; i++)
			{
				ControllerType controllerType = ((i != 0) ? ControllerType.Mouse : ControllerType.Keyboard);
				foreach (ActionElementMap item2 in player.controllers.maps.GetMap(controllerType, 0, "Default", "Default").ElementMapsWithAction(action.id))
				{
					if (item2.ShowInField(actionRange))
					{
						base.name = item2.elementIdentifierName;
						actionElementMapId = item2.id;
						curActionElementMap = item2;
						break;
					}
				}
				if (actionElementMapId >= 0)
				{
					break;
				}
			}
		}
		if (actionElementMapId == -1)
		{
			glyph.actionElementMap = null;
		}
		else
		{
			glyph.actionElementMap = curActionElementMap;
		}
	}

	private void OnSettingsChange()
	{
		ResetActionMap();
	}
}
