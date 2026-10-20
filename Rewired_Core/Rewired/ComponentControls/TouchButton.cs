using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[AddComponentMenu("Rewired/Touch Controls/Touch Button")]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum WRGeuWfUZCpPKMSgkElQFBwdcbcdc
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum WuQZFQFgQZhdCDygleGdZYLzbLcu
		{
			Local = 0,
			TouchRegion = 1
		}

		[Serializable]
		public class AxisValueChangedEventHandler : UnityEvent<float>
		{
		}

		[Serializable]
		public class ButtonValueChangedEventHandler : UnityEvent<bool>
		{
		}

		[Serializable]
		public class ButtonDownEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class ButtonUpEventHandler : UnityEvent
		{
		}

		private sealed class IhGNUOnScNicjtEynUnRHINFfsON : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int CAbVGkrLsuEdDgvtpCawqxSoZgVkA;

			private object iRERpHJeBkBuivdJsdjONMuUSjng;

			public float hkKTwmDpknkPDexWvJZPgcmcmbHb;

			public TouchButton umTtAYvCLdaCxdmYllwBDyLHCYFAA;

			public PositionType moYRPjuzqxbLGIrWVKorlLYCyfoe;

			public Vector2 stxOaTOFveASxEarFrsbreUAwGbU;

			public WRGeuWfUZCpPKMSgkElQFBwdcbcdc TxLoHLEpsmENTkbTdkMISoIAbCBvA;

			private RectTransform oSEMVTXdVsbXVhNTEoGNlUIrKJhu;

			private Vector2 CuSjtlbjXhLfQRCAoBBXkNhmeHRL;

			private float qphoeiSPOCosiepQauPXpdHWIhsjA;

			private float lXukXtSHYnCRJyKbzJFCEeEkhcQiA;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return iRERpHJeBkBuivdJsdjONMuUSjng;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return iRERpHJeBkBuivdJsdjONMuUSjng;
				}
			}

			[DebuggerHidden]
			public IhGNUOnScNicjtEynUnRHINFfsON(int P_0)
			{
				CAbVGkrLsuEdDgvtpCawqxSoZgVkA = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				oSEMVTXdVsbXVhNTEoGNlUIrKJhu = null;
				CAbVGkrLsuEdDgvtpCawqxSoZgVkA = -2;
			}

			private bool MoveNext()
			{
				int cAbVGkrLsuEdDgvtpCawqxSoZgVkA = CAbVGkrLsuEdDgvtpCawqxSoZgVkA;
				TouchButton touchButton = umTtAYvCLdaCxdmYllwBDyLHCYFAA;
				if (cAbVGkrLsuEdDgvtpCawqxSoZgVkA != 0)
				{
					if (cAbVGkrLsuEdDgvtpCawqxSoZgVkA != 1)
					{
						return false;
					}
					CAbVGkrLsuEdDgvtpCawqxSoZgVkA = -1;
					goto IL_010c;
				}
				CAbVGkrLsuEdDgvtpCawqxSoZgVkA = -1;
				if (!(hkKTwmDpknkPDexWvJZPgcmcmbHb <= 0f))
				{
					oSEMVTXdVsbXVhNTEoGNlUIrKJhu = touchButton.dSTzJICOhDURqXqgBtAzmiWIpcKb;
					CuSjtlbjXhLfQRCAoBBXkNhmeHRL = cbWCNMtlHNhVkewTKiBiCNVvIFiiA.vWgSGNkHqzXuLxjEokvVZyawuraY(oSEMVTXdVsbXVhNTEoGNlUIrKJhu, moYRPjuzqxbLGIrWVKorlLYCyfoe);
					float magnitude = (stxOaTOFveASxEarFrsbreUAwGbU - CuSjtlbjXhLfQRCAoBBXkNhmeHRL).magnitude;
					if (!(magnitude < 0.01f))
					{
						touchButton.nhtOEYfGpFDooyBnqgylaFJxCeGH = true;
						qphoeiSPOCosiepQauPXpdHWIhsjA = magnitude / hkKTwmDpknkPDexWvJZPgcmcmbHb;
						lXukXtSHYnCRJyKbzJFCEeEkhcQiA = 0f;
						goto IL_010c;
					}
				}
				goto IL_0119;
				IL_0119:
				touchButton.EdbLcyLjxmgLQwgPaLkCjQZAErzv(TxLoHLEpsmENTkbTdkMISoIAbCBvA, stxOaTOFveASxEarFrsbreUAwGbU, moYRPjuzqxbLGIrWVKorlLYCyfoe);
				return false;
				IL_010c:
				if (lXukXtSHYnCRJyKbzJFCEeEkhcQiA <= 1f)
				{
					lXukXtSHYnCRJyKbzJFCEeEkhcQiA += Time.unscaledDeltaTime / qphoeiSPOCosiepQauPXpdHWIhsjA;
					cbWCNMtlHNhVkewTKiBiCNVvIFiiA.iLmCtZouQvHcYSqOWpVBiUGBnQK(oSEMVTXdVsbXVhNTEoGNlUIrKJhu, Vector2.Lerp(CuSjtlbjXhLfQRCAoBBXkNhmeHRL, stxOaTOFveASxEarFrsbreUAwGbU, Mathf.SmoothStep(0f, 1f, lXukXtSHYnCRJyKbzJFCEeEkhcQiA)), moYRPjuzqxbLGIrWVKorlLYCyfoe);
					iRERpHJeBkBuivdJsdjONMuUSjng = null;
					CAbVGkrLsuEdDgvtpCawqxSoZgVkA = 1;
					return true;
				}
				goto IL_0119;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private const float ZnMfyFGnwZXImKjuVVWvlAcnVJT = 20f;

		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		}));

		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonType _buttonType;

		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useDigitalAxisSimulation;

		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisGravity = 3f;

		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisSensitivity = 3f;

		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _axis = new StandaloneAxis();

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchRegion _touchRegion;

		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly = true;

		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease = true;

		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _followTouchPosition;

		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnMoveToTouch = true;

		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _moveToTouchSpeed = 2f;

		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnReturn = true;

		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _returnSpeed = 2f;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting = true;

		private float VCsESWuVnwNnwoxttIDypJeBrUoP;

		private float YFhrvNCgfvXbRnFTtbIMkOfworMt;

		private TouchRegion igUvhtvpmigfiCPinjUkXIwookgIA;

		private Vector2 sxjrTRbNtTtfQmqFdJCvYnxFmdMF;

		private bool nhtOEYfGpFDooyBnqgylaFJxCeGH;

		private bool FcuINlNMKsQnXXxAMtvvWMFqrnVF;

		private WRGeuWfUZCpPKMSgkElQFBwdcbcdc VGxCVLHPGYZWBbEgzsADcupYscxr;

		private int SKtPMnWHxpaISgXMcqJeiLkdXalPA = int.MinValue;

		private int tytwpzBfLKRABjcUyTpCdoMTVMig = int.MinValue;

		[NonSerialized]
		private bool bVBoXxlwqvHZshYxJGrUpBhAysIp;

		[NonSerialized]
		private bool LTStQVbguSfoGWLitCkRBlczeuiMA;

		private IEnumerator uXeSJtdIhOkOYQazAroUFmJfrazg;

		private yrszVxuLvatDSjHVoyWAHBfCxxwH YMnXgKsAAIMpawAGTuyPIaXtCSlI = new yrszVxuLvatDSjHVoyWAHBfCxxwH();

		private Action<WRGeuWfUZCpPKMSgkElQFBwdcbcdc> nnooNqNDedAjhTJiksiFIvzMNHhk;

		private Action<WRGeuWfUZCpPKMSgkElQFBwdcbcdc> tyRvlehCDnIjFCyZBBQiFqvKRYToc;

		[Tooltip("Event sent when the axis value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisValueChangedEventHandler _onAxisValueChanged = new AxisValueChangedEventHandler();

		[Tooltip("Event sent when the button value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonValueChangedEventHandler _onButtonValueChanged = new ButtonValueChangedEventHandler();

		[Tooltip("Event sent when the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonDownEventHandler _onButtonDown = new ButtonDownEventHandler();

		[Tooltip("Event sent when the button is released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

		private Dictionary<int, PointerEventData> MXSjvNPyXHbvCXKSVDmhcLTTyJaQA;

		public CustomControllerElementTargetSetForFloat targetCustomControllerElement => _targetCustomControllerElement;

		public ButtonType buttonType
		{
			get
			{
				return _buttonType;
			}
			set
			{
				if (_buttonType != value)
				{
					_buttonType = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public bool activateOnSwipeIn
		{
			get
			{
				return _activateOnSwipeIn;
			}
			set
			{
				if (_activateOnSwipeIn != value)
				{
					_activateOnSwipeIn = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (ipyorRSemQeoHsLWAxKduhOvGvPG())
				{
					return true;
				}
				return _stayActiveOnSwipeOut;
			}
			set
			{
				if (_stayActiveOnSwipeOut != value)
				{
					_stayActiveOnSwipeOut = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public bool useDigitalAxisSimulation
		{
			get
			{
				return _useDigitalAxisSimulation;
			}
			set
			{
				if (_useDigitalAxisSimulation != value)
				{
					_useDigitalAxisSimulation = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public float digitalAxisGravity
		{
			get
			{
				return _digitalAxisGravity;
			}
			set
			{
				if (_digitalAxisGravity != value)
				{
					_digitalAxisGravity = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public float digitalAxisSensitivity
		{
			get
			{
				return _digitalAxisSensitivity;
			}
			set
			{
				if (_digitalAxisSensitivity != value)
				{
					_digitalAxisSensitivity = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public TouchRegion touchRegion
		{
			get
			{
				return _touchRegion;
			}
			set
			{
				if (!(_touchRegion == value))
				{
					_touchRegion = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public bool useTouchRegionOnly
		{
			get
			{
				return _useTouchRegionOnly;
			}
			set
			{
				if (_useTouchRegionOnly != value)
				{
					_useTouchRegionOnly = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public bool moveToTouchPosition
		{
			get
			{
				return _moveToTouchPosition;
			}
			set
			{
				if (_moveToTouchPosition != value)
				{
					_moveToTouchPosition = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public bool returnOnRelease
		{
			get
			{
				return _returnOnRelease;
			}
			set
			{
				if (_returnOnRelease != value)
				{
					_returnOnRelease = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public bool followTouchPosition
		{
			get
			{
				return _followTouchPosition;
			}
			set
			{
				if (_followTouchPosition != value)
				{
					_followTouchPosition = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public bool animateOnMoveToTouch
		{
			get
			{
				return _animateOnMoveToTouch;
			}
			set
			{
				if (_animateOnMoveToTouch != value)
				{
					_animateOnMoveToTouch = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public float moveToTouchSpeed
		{
			get
			{
				return _moveToTouchSpeed;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 20f);
				if (_moveToTouchSpeed != value)
				{
					_moveToTouchSpeed = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public bool animateOnReturn
		{
			get
			{
				return _animateOnReturn;
			}
			set
			{
				if (_animateOnReturn != value)
				{
					_animateOnReturn = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public float returnSpeed
		{
			get
			{
				return _returnSpeed;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 20f);
				if (_returnSpeed != value)
				{
					_returnSpeed = value;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public bool manageRaycasting
		{
			get
			{
				return _manageRaycasting;
			}
			set
			{
				if (_manageRaycasting != value)
				{
					_manageRaycasting = value;
					if (value)
					{
						waLASvWxnvmqIybuPIjudicWjGhE();
					}
					else
					{
						YMnXgKsAAIMpawAGTuyPIaXtCSlI.qycJsgxamcLeWpFuAXBFFVqsWjiy();
					}
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public int pointerId
		{
			get
			{
				return SKtPMnWHxpaISgXMcqJeiLkdXalPA;
			}
			set
			{
				SKtPMnWHxpaISgXMcqJeiLkdXalPA = value;
			}
		}

		public bool hasPointer => SKtPMnWHxpaISgXMcqJeiLkdXalPA != int.MinValue;

		internal StandaloneAxis axis => _axis;

		private Action<WRGeuWfUZCpPKMSgkElQFBwdcbcdc> moveStartedDelegate
		{
			get
			{
				if (nnooNqNDedAjhTJiksiFIvzMNHhk == null)
				{
					return nnooNqNDedAjhTJiksiFIvzMNHhk = bzDLZMogGKMMpUsqkVubMgrECwAeA;
				}
				return nnooNqNDedAjhTJiksiFIvzMNHhk;
			}
		}

		private Action<WRGeuWfUZCpPKMSgkElQFBwdcbcdc> moveEndedDelegate
		{
			get
			{
				if (tyRvlehCDnIjFCyZBBQiFqvKRYToc == null)
				{
					return tyRvlehCDnIjFCyZBBQiFqvKRYToc = bocAZMiauFGOFjbLbaEBLRwwQNecb;
				}
				return tyRvlehCDnIjFCyZBBQiFqvKRYToc;
			}
		}

		private float axisValue
		{
			get
			{
				if (!_useDigitalAxisSimulation)
				{
					return _axis.value;
				}
				return VCsESWuVnwNnwoxttIDypJeBrUoP;
			}
		}

		private float axisValuePrev
		{
			get
			{
				if (!_useDigitalAxisSimulation)
				{
					return _axis.valuePrev;
				}
				return YFhrvNCgfvXbRnFTtbIMkOfworMt;
			}
		}

		private bool buttonValue => _axis.buttonValue;

		private bool buttonValuePrev => _axis.buttonValuePrev;

		private int effectivePointerId
		{
			get
			{
				if (SKtPMnWHxpaISgXMcqJeiLkdXalPA == int.MinValue)
				{
					return int.MinValue;
				}
				if (tytwpzBfLKRABjcUyTpCdoMTVMig != int.MinValue)
				{
					return tytwpzBfLKRABjcUyTpCdoMTVMig;
				}
				return SKtPMnWHxpaISgXMcqJeiLkdXalPA;
			}
		}

		public event UnityAction<float> AxisValueChangedEvent
		{
			add
			{
				_onAxisValueChanged.AddListener(value);
			}
			remove
			{
				_onAxisValueChanged.RemoveListener(value);
			}
		}

		public event UnityAction<bool> ButtonValueChangedEvent
		{
			add
			{
				_onButtonValueChanged.AddListener(value);
			}
			remove
			{
				_onButtonValueChanged.RemoveListener(value);
			}
		}

		public event UnityAction ButtonDownEvent
		{
			add
			{
				_onButtonDown.AddListener(value);
			}
			remove
			{
				_onButtonDown.RemoveListener(value);
			}
		}

		public event UnityAction ButtonUpEvent
		{
			add
			{
				_onButtonUp.AddListener(value);
			}
			remove
			{
				_onButtonUp.RemoveListener(value);
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchButton()
		{
		}

		public void SetRawValue(float value)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				_axis.SetRawValue(value);
			}
		}

		public void SetDefaultPosition()
		{
			OcueaHkYoCPBVbuyDJDcYsfJxKFm(base.dSTzJICOhDURqXqgBtAzmiWIpcKb.anchoredPosition);
		}

		private void OcueaHkYoCPBVbuyDJDcYsfJxKFm(Vector2 P_0)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				sxjrTRbNtTtfQmqFdJCvYnxFmdMF = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				bYKreiALxdKJvIdcdhIRjJGoDAnUA(sxjrTRbNtTtfQmqFdJCvYnxFmdMF, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, WRGeuWfUZCpPKMSgkElQFBwdcbcdc.TowardHome);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				ReturnToDefaultPosition(instant: false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (Application.isPlaying)
			{
				sxjrTRbNtTtfQmqFdJCvYnxFmdMF = base.dSTzJICOhDURqXqgBtAzmiWIpcKb.anchoredPosition;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				QCbavbHFGQHcdRpMbFMHqxXXXxqMA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				YzxKKOVrxwkgoHefBOYjLtxwJquq();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				QCbavbHFGQHcdRpMbFMHqxXXXxqMA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
			base.Reset();
			base.transitionType = TransitionTypeFlags.ColorTint;
		}

		internal void OnUpdate()
		{
			base.epUjHrbOoOHMLLTrFTPJrNSFcfqc();
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				iVtbhcpYbgwahJGUvTOkMurRqfC();
				QgqCKDRhHJIvLdIuiLsiRSSndyMsA();
				ZBxIRMCuFKZeDukYVapJwTquEFnD();
				if (_followTouchPosition)
				{
					HgpRqyqpSTCupcvRZSmsQUeQqNSUA(effectivePointerId);
				}
			}
		}

		internal bool OnInitialize()
		{
			if (!PuElCCKuVaOGHYLUTJDmtdWXnchF())
			{
				return false;
			}
			return true;
		}

		internal void OnCustomControllerUpdate()
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && EtAcLDGWDFPgJjzEWQEywAqMgoOdb)
			{
				aTgxJvlgQxwfYLitbUKLdLsSojGo(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			}
		}

		internal void OnSubscribeEvents()
		{
			scFZVoRXKcUSJpCFfpIlakUmeEGk();
			_axis.AxisValueChangedEvent += EtpZwZVAMqPLnuaJMwtezQKDGnEaA;
			_axis.ButtonValueChangedEvent += QCeUrAraHksWQUGsGrxsApnEsIFm;
			_axis.ButtonDownEvent += nlnhUaNmOsZfDVpZDJUHIRFYwOMX;
			_axis.ButtonUpEvent += BowTFmEbuCqJDjEtIKzpSUpSrCsd;
		}

		internal void OnUnsubscribeEvents()
		{
			DTnKGQgKgaazsEdVklBcohcrZsSQ();
			_axis.AxisValueChangedEvent -= EtpZwZVAMqPLnuaJMwtezQKDGnEaA;
			_axis.ButtonValueChangedEvent -= QCeUrAraHksWQUGsGrxsApnEsIFm;
			_axis.ButtonDownEvent -= nlnhUaNmOsZfDVpZDJUHIRFYwOMX;
			_axis.ButtonUpEvent -= BowTFmEbuCqJDjEtIKzpSUpSrCsd;
		}

		internal void OnSetProperty()
		{
			dSVELKvKXyagHdfmFilldKJbtaUs();
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				QCbavbHFGQHcdRpMbFMHqxXXXxqMA();
			}
		}

		internal void OnClear()
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				SKtPMnWHxpaISgXMcqJeiLkdXalPA = int.MinValue;
				tytwpzBfLKRABjcUyTpCdoMTVMig = int.MinValue;
				bVBoXxlwqvHZshYxJGrUpBhAysIp = false;
				LTStQVbguSfoGWLitCkRBlczeuiMA = false;
				if (_returnOnRelease && FcuINlNMKsQnXXxAMtvvWMFqrnVF && (_moveToTouchPosition || _followTouchPosition))
				{
					ReturnToDefaultPosition(instant: true);
				}
				FcuINlNMKsQnXXxAMtvvWMFqrnVF = false;
				nhtOEYfGpFDooyBnqgylaFJxCeGH = false;
				VGxCVLHPGYZWBbEgzsADcupYscxr = WRGeuWfUZCpPKMSgkElQFBwdcbcdc.None;
				HDbykdQqgQfQiAmGJhUqKbFNxWvKA();
				_axis.Clear();
				VCsESWuVnwNnwoxttIDypJeBrUoP = 0f;
				YFhrvNCgfvXbRnFTtbIMkOfworMt = 0f;
				QCbavbHFGQHcdRpMbFMHqxXXXxqMA();
			}
		}

		public override void ClearValue()
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				_axis.Clear();
				VCsESWuVnwNnwoxttIDypJeBrUoP = 0f;
				if (EtAcLDGWDFPgJjzEWQEywAqMgoOdb)
				{
					base.sdcQQalKpHJXfgxZpoogPfzaHIRB.ClearElementValue(_targetCustomControllerElement);
				}
			}
		}

		internal bool IsPressed()
		{
			if (!base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				return false;
			}
			if (!uJoHaltMSUUnfllDSTBAVKDBdyfiA())
			{
				return false;
			}
			if (!_axis.buttonValue)
			{
				return _axis.value != 0f;
			}
			return true;
		}

		internal bool IsThisOrTouchRegionGameObject(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return false;
			}
			if (base.WNOydoUHTsucXUCxILgLheNFylXk(gameObject))
			{
				return true;
			}
			if (igUvhtvpmigfiCPinjUkXIwookgIA != null)
			{
				return igUvhtvpmigfiCPinjUkXIwookgIA.gameObject == gameObject;
			}
			return false;
		}

		private void ZBxIRMCuFKZeDukYVapJwTquEFnD()
		{
			if (_useDigitalAxisSimulation)
			{
				if (_axis.buttonValue)
				{
					ExoRJCTYyMkLNSTsJbPAkhTjCqbhA();
				}
				else
				{
					JmbcxOwKitEpsbZLeNIiOxIqCMaoA();
				}
			}
		}

		private void ExoRJCTYyMkLNSTsJbPAkhTjCqbhA()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			float num2 = MathTools.Abs(_digitalAxisSensitivity);
			num *= num2 * Time.unscaledDeltaTime;
			num += VCsESWuVnwNnwoxttIDypJeBrUoP;
			num = MathTools.Clamp(num, -1f, 1f);
			aEOomSLQgcIvSzUaSFrEFJPwdIYR(num, true);
		}

		private void JmbcxOwKitEpsbZLeNIiOxIqCMaoA()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				return;
			}
			float vCsESWuVnwNnwoxttIDypJeBrUoP = VCsESWuVnwNnwoxttIDypJeBrUoP;
			if (vCsESWuVnwNnwoxttIDypJeBrUoP != 0f)
			{
				float num2 = num * Time.unscaledDeltaTime;
				float num3;
				if (MathTools.Abs(num2) >= MathTools.Abs(vCsESWuVnwNnwoxttIDypJeBrUoP))
				{
					num3 = 0f;
				}
				else
				{
					float num4 = ((vCsESWuVnwNnwoxttIDypJeBrUoP > 0f) ? (-1f) : 1f);
					num3 = vCsESWuVnwNnwoxttIDypJeBrUoP + num4 * num2;
				}
				aEOomSLQgcIvSzUaSFrEFJPwdIYR(num3, true);
			}
		}

		private void aEOomSLQgcIvSzUaSFrEFJPwdIYR(float P_0, bool P_1)
		{
			YFhrvNCgfvXbRnFTtbIMkOfworMt = VCsESWuVnwNnwoxttIDypJeBrUoP;
			VCsESWuVnwNnwoxttIDypJeBrUoP = P_0;
			if (P_0 != YFhrvNCgfvXbRnFTtbIMkOfworMt)
			{
				XfXRqBujLQOCeNQMVYFaZbAADoCm(null);
			}
			if (P_1 && P_0 != YFhrvNCgfvXbRnFTtbIMkOfworMt)
			{
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void IatNevcAXijJfJTZdTDFZhCxeoGKA()
		{
			if (_buttonType == ButtonType.ToggleSwitch)
			{
				if (buttonValue)
				{
					_axis.SetRawValue(_axis.rawZero);
				}
				else
				{
					_axis.SetRawValue(_axis.rawMax);
				}
			}
			else if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawMax);
			}
		}

		private void cvdBnTHJvoQIdDyUgJTaelYpgDog()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void QCbavbHFGQHcdRpMbFMHqxXXXxqMA()
		{
			_targetCustomControllerElement.ClearElementCaches();
			QgqCKDRhHJIvLdIuiLsiRSSndyMsA();
			waLASvWxnvmqIybuPIjudicWjGhE();
		}

		private void waLASvWxnvmqIybuPIjudicWjGhE()
		{
			if (_manageRaycasting)
			{
				YMnXgKsAAIMpawAGTuyPIaXtCSlI.PWwmpVscPWxZbNbZbLHtHYwunjoM(base.transform, iKlIETinzthTJPZHeMPiptoYqHbc());
			}
		}

		private bool iKlIETinzthTJPZHeMPiptoYqHbc()
		{
			if (igUvhtvpmigfiCPinjUkXIwookgIA != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void RFtuEPOsPxNuCOPZNagaIVLgsVxhA(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				MdKsLWSWDVCnJKhgZWtqvPqhitcy(P_0);
				P_0.PointerDownEvent += eBDPvewcjpOFcygvEVuoNMkACmSM;
				P_0.PointerUpEvent += WkqKtTrjWMPJfIiWjZYPwpSPuXXi;
				P_0.PointerEnterEvent += zcuyaLeAQkbKiYAeLTKnwvlinijl;
				P_0.PointerExitEvent += XwykkJVfwRaZAEGyYijOHvNCBZyGc;
			}
		}

		private void MdKsLWSWDVCnJKhgZWtqvPqhitcy(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= eBDPvewcjpOFcygvEVuoNMkACmSM;
				P_0.PointerUpEvent -= WkqKtTrjWMPJfIiWjZYPwpSPuXXi;
				P_0.PointerEnterEvent -= zcuyaLeAQkbKiYAeLTKnwvlinijl;
				P_0.PointerExitEvent -= XwykkJVfwRaZAEGyYijOHvNCBZyGc;
			}
		}

		private void QgqCKDRhHJIvLdIuiLsiRSSndyMsA()
		{
			if (!(igUvhtvpmigfiCPinjUkXIwookgIA == _touchRegion))
			{
				MdKsLWSWDVCnJKhgZWtqvPqhitcy(igUvhtvpmigfiCPinjUkXIwookgIA);
				igUvhtvpmigfiCPinjUkXIwookgIA = _touchRegion;
				RFtuEPOsPxNuCOPZNagaIVLgsVxhA(igUvhtvpmigfiCPinjUkXIwookgIA);
			}
		}

		private void KbTsxNtwRqcpGEMPeacitCvXgnPL(Vector2 P_0, bool P_1, float P_2, WRGeuWfUZCpPKMSgkElQFBwdcbcdc P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = cbWCNMtlHNhVkewTKiBiCNVvIFiiA.eBlqBEhCxecNcKIrxmsQWJaTahJE(base.RAMbMCVDZNAfRShilkKJyPAzfaiFA, rectTransform, P_0);
			Vector2 pivot = base.dSTzJICOhDURqXqgBtAzmiWIpcKb.pivot;
			Vector2 sizeDelta = base.dSTzJICOhDURqXqgBtAzmiWIpcKb.sizeDelta;
			Vector3 localScale = base.dSTzJICOhDURqXqgBtAzmiWIpcKb.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			bYKreiALxdKJvIdcdhIRjJGoDAnUA(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void bYKreiALxdKJvIdcdhIRjJGoDAnUA(Vector2 P_0, PositionType P_1, bool P_2, float P_3, WRGeuWfUZCpPKMSgkElQFBwdcbcdc P_4)
		{
			if (nhtOEYfGpFDooyBnqgylaFJxCeGH && P_2 && VGxCVLHPGYZWBbEgzsADcupYscxr == P_4)
			{
				return;
			}
			if (nhtOEYfGpFDooyBnqgylaFJxCeGH && uXeSJtdIhOkOYQazAroUFmJfrazg != null)
			{
				HDbykdQqgQfQiAmGJhUqKbFNxWvKA();
				nhtOEYfGpFDooyBnqgylaFJxCeGH = false;
				VGxCVLHPGYZWBbEgzsADcupYscxr = WRGeuWfUZCpPKMSgkElQFBwdcbcdc.None;
			}
			if (base.RAMbMCVDZNAfRShilkKJyPAzfaiFA == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.RAMbMCVDZNAfRShilkKJyPAzfaiFA.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.UfmIGZThEbWVxpoddgwxllLrghpl;
				Vector2 one = Vector2.one;
				while ((parent = parent.parent) != rectTransform && !(parent == null))
				{
					one.x *= parent.localScale.x;
					one.y *= parent.localScale.y;
				}
				Vector2 sizeDelta = rectTransform.sizeDelta;
				bool num = sizeDelta.x < sizeDelta.y;
				float num2 = MathTools.Max(sizeDelta.x, sizeDelta.y);
				float num3 = (num ? one.y : one.x);
				if (num3 == 0f)
				{
					num3 = 0.0001f;
				}
				P_3 = P_3 / num3 * num2;
				uXeSJtdIhOkOYQazAroUFmJfrazg = CkHjgdTQpSUrpvykAyUvIpvRhagK(P_0, P_1, P_3, P_4);
				StartCoroutine(uXeSJtdIhOkOYQazAroUFmJfrazg);
				VGxCVLHPGYZWBbEgzsADcupYscxr = P_4;
				FcuINlNMKsQnXXxAMtvvWMFqrnVF = true;
				moveStartedDelegate(P_4);
			}
			else
			{
				moveStartedDelegate(P_4);
				EdbLcyLjxmgLQwgPaLkCjQZAErzv(P_4, P_0, P_1);
			}
		}

		[IteratorStateMachine(typeof(IhGNUOnScNicjtEynUnRHINFfsON))]
		private IEnumerator CkHjgdTQpSUrpvykAyUvIpvRhagK(Vector2 P_0, PositionType P_1, float P_2, WRGeuWfUZCpPKMSgkElQFBwdcbcdc P_3)
		{
			return new IhGNUOnScNicjtEynUnRHINFfsON(0)
			{
				umTtAYvCLdaCxdmYllwBDyLHCYFAA = this,
				stxOaTOFveASxEarFrsbreUAwGbU = P_0,
				moYRPjuzqxbLGIrWVKorlLYCyfoe = P_1,
				hkKTwmDpknkPDexWvJZPgcmcmbHb = P_2,
				TxLoHLEpsmENTkbTdkMISoIAbCBvA = P_3
			};
		}

		private void EdbLcyLjxmgLQwgPaLkCjQZAErzv(WRGeuWfUZCpPKMSgkElQFBwdcbcdc P_0, Vector2 P_1, PositionType P_2)
		{
			cbWCNMtlHNhVkewTKiBiCNVvIFiiA.iLmCtZouQvHcYSqOWpVBiUGBnQK(base.dSTzJICOhDURqXqgBtAzmiWIpcKb, P_1, P_2);
			nhtOEYfGpFDooyBnqgylaFJxCeGH = false;
			VGxCVLHPGYZWBbEgzsADcupYscxr = WRGeuWfUZCpPKMSgkElQFBwdcbcdc.None;
			switch (P_0)
			{
			case WRGeuWfUZCpPKMSgkElQFBwdcbcdc.TowardHome:
				FcuINlNMKsQnXXxAMtvvWMFqrnVF = false;
				break;
			case WRGeuWfUZCpPKMSgkElQFBwdcbcdc.TowardTouch:
				FcuINlNMKsQnXXxAMtvvWMFqrnVF = true;
				break;
			}
			HDbykdQqgQfQiAmGJhUqKbFNxWvKA();
			moveEndedDelegate(P_0);
		}

		private void bzDLZMogGKMMpUsqkVubMgrECwAeA(WRGeuWfUZCpPKMSgkElQFBwdcbcdc P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && igUvhtvpmigfiCPinjUkXIwookgIA != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == WRGeuWfUZCpPKMSgkElQFBwdcbcdc.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					YMnXgKsAAIMpawAGTuyPIaXtCSlI.PWwmpVscPWxZbNbZbLHtHYwunjoM(base.transform, flag2);
				}
			}
		}

		private void bocAZMiauFGOFjbLbaEBLRwwQNecb(WRGeuWfUZCpPKMSgkElQFBwdcbcdc P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && igUvhtvpmigfiCPinjUkXIwookgIA != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == WRGeuWfUZCpPKMSgkElQFBwdcbcdc.TowardHome)
				{
					flag = true;
					flag2 = iKlIETinzthTJPZHeMPiptoYqHbc();
				}
				if (flag)
				{
					YMnXgKsAAIMpawAGTuyPIaXtCSlI.PWwmpVscPWxZbNbZbLHtHYwunjoM(base.transform, flag2);
				}
			}
		}

		private void HgpRqyqpSTCupcvRZSmsQUeQqNSUA(int P_0)
		{
			if (TouchInteractable.eQOtidJsScHPAhNKsoQjfKOmxGus(P_0))
			{
				KbTsxNtwRqcpGEMPeacitCvXgnPL(TouchInteractable.zFFIzzYZhXeFYivmeeMhZaETyum(P_0), false, 0f, WRGeuWfUZCpPKMSgkElQFBwdcbcdc.TowardTouch);
			}
		}

		private void HDbykdQqgQfQiAmGJhUqKbFNxWvKA()
		{
			if (uXeSJtdIhOkOYQazAroUFmJfrazg != null)
			{
				try
				{
					StopCoroutine(uXeSJtdIhOkOYQazAroUFmJfrazg);
				}
				catch
				{
				}
				uXeSJtdIhOkOYQazAroUFmJfrazg = null;
			}
		}

		private void iVtbhcpYbgwahJGUvTOkMurRqfC()
		{
			if (hasPointer && !TouchInteractable.eQOtidJsScHPAhNKsoQjfKOmxGus(effectivePointerId))
			{
				PointerEventData pointerEventData = OXDbryUSVmSmoDHJklYNJkRqpBod(effectivePointerId);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					pHNAgBdTOQrbwExdJJBTcFPtYIOd(pointerEventData);
				}
				else
				{
					loVCAvHiVkTywenZxOyDfoYeChtX();
				}
			}
		}

		private bool ipyorRSemQeoHsLWAxKduhOvGvPG()
		{
			if (!_followTouchPosition)
			{
				return false;
			}
			if (_touchRegion != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void aOMXPnfKTRZehpffYgwhAheAUMLy()
		{
			SKtPMnWHxpaISgXMcqJeiLkdXalPA = int.MinValue;
			tytwpzBfLKRABjcUyTpCdoMTVMig = int.MinValue;
		}

		private bool nxZEOXZKKqOJaJHQzBVuQRfLvtVx(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (SKtPMnWHxpaISgXMcqJeiLkdXalPA == int.MinValue)
			{
				return false;
			}
			if (SKtPMnWHxpaISgXMcqJeiLkdXalPA == P_0)
			{
				return true;
			}
			if (TouchInteractable.AkmvdAybnWttxqqkoBPwYmwyZvFm(P_0) && tytwpzBfLKRABjcUyTpCdoMTVMig != int.MinValue && P_0 == tytwpzBfLKRABjcUyTpCdoMTVMig)
			{
				return true;
			}
			return false;
		}

		private PointerEventData srMPeQJxVzmllDOkFpHpPRbksmFU(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = OXDbryUSVmSmoDHJklYNJkRqpBod(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.zFFIzzYZhXeFYivmeeMhZaETyum(P_0);
			if (TouchInteractable.fABgWzLRmoejOnwFMAwBognAmafI(P_0))
			{
				pointerEventData.eligibleForClick = true;
				pointerEventData.delta = Vector2.zero;
				pointerEventData.dragging = false;
				pointerEventData.useDragThreshold = true;
				pointerEventData.pressPosition = pointerEventData.position;
				pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
				if (pointerEventData.pointerEnter != P_1)
				{
					pointerEventData.pointerEnter = P_1;
				}
				float unscaledTime = Time.unscaledTime;
				if (P_1 == pointerEventData.lastPress)
				{
					if (unscaledTime - pointerEventData.clickTime < 0.3f)
					{
						int clickCount = pointerEventData.clickCount + 1;
						pointerEventData.clickCount = clickCount;
					}
					else
					{
						pointerEventData.clickCount = 1;
					}
					pointerEventData.clickTime = unscaledTime;
				}
				else
				{
					pointerEventData.clickCount = 1;
				}
				pointerEventData.pointerPress = P_1;
				pointerEventData.rawPointerPress = P_1;
				pointerEventData.clickTime = unscaledTime;
				pointerEventData.pointerDrag = P_1;
			}
			else
			{
				if (!TouchInteractable.AkmvdAybnWttxqqkoBPwYmwyZvFm(P_0))
				{
					Logger.LogWarning("Unsupported pointerId: " + P_0);
					return null;
				}
				pointerEventData.eligibleForClick = true;
				pointerEventData.delta = Vector2.zero;
				pointerEventData.dragging = false;
				pointerEventData.useDragThreshold = true;
				pointerEventData.pressPosition = pointerEventData.position;
				pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
				float unscaledTime2 = Time.unscaledTime;
				if (P_1 == pointerEventData.lastPress)
				{
					if (unscaledTime2 - pointerEventData.clickTime < 0.3f)
					{
						int clickCount = pointerEventData.clickCount + 1;
						pointerEventData.clickCount = clickCount;
					}
					else
					{
						pointerEventData.clickCount = 1;
					}
					pointerEventData.clickTime = unscaledTime2;
				}
				else
				{
					pointerEventData.clickCount = 1;
				}
				pointerEventData.pointerPress = P_1;
				pointerEventData.rawPointerPress = P_1;
				pointerEventData.clickTime = unscaledTime2;
				pointerEventData.pointerDrag = P_1;
			}
			return pointerEventData;
		}

		private PointerEventData rXmcyFbxWpDUWPugMFqZRMyIFKuqA(int P_0)
		{
			PointerEventData pointerEventData = OXDbryUSVmSmoDHJklYNJkRqpBod(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.fABgWzLRmoejOnwFMAwBognAmafI(P_0))
			{
				pointerEventData.eligibleForClick = false;
				pointerEventData.pointerPress = null;
				pointerEventData.rawPointerPress = null;
				pointerEventData.dragging = false;
				pointerEventData.pointerDrag = null;
				pointerEventData.pointerEnter = null;
			}
			else
			{
				if (!TouchInteractable.AkmvdAybnWttxqqkoBPwYmwyZvFm(P_0))
				{
					Logger.LogWarning("Unsupported pointerId: " + P_0);
					return null;
				}
				pointerEventData.eligibleForClick = false;
				pointerEventData.pointerPress = null;
				pointerEventData.rawPointerPress = null;
				pointerEventData.dragging = false;
				pointerEventData.pointerDrag = null;
			}
			return pointerEventData;
		}

		private void pHNAgBdTOQrbwExdJJBTcFPtYIOd(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				rXmcyFbxWpDUWPugMFqZRMyIFKuqA(effectivePointerId);
			}
		}

		private PointerEventData OXDbryUSVmSmoDHJklYNJkRqpBod(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (MXSjvNPyXHbvCXKSVDmhcLTTyJaQA == null)
			{
				MXSjvNPyXHbvCXKSVDmhcLTTyJaQA = new Dictionary<int, PointerEventData>();
			}
			if (!MXSjvNPyXHbvCXKSVDmhcLTTyJaQA.TryGetValue(P_0, out var value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				MXSjvNPyXHbvCXKSVDmhcLTTyJaQA.Add(P_0, value);
				if (TouchInteractable.AkmvdAybnWttxqqkoBPwYmwyZvFm(P_0))
				{
					PointerEventData.InputButton button = P_0 switch
					{
						-1 => PointerEventData.InputButton.Left, 
						-2 => PointerEventData.InputButton.Right, 
						-3 => PointerEventData.InputButton.Middle, 
						_ => throw new NotImplementedException(), 
					};
					value.button = button;
				}
			}
			return value;
		}

		private void aIwncBmcXuZYYUbRzPHYIBfWftHDA(PointerEventData P_0, WuQZFQFgQZhdCDygleGdZYLzbLcu P_1)
		{
			if (!hasPointer || nxZEOXZKKqOJaJHQzBVuQRfLvtVx(P_0.pointerId))
			{
				if (uJoHaltMSUUnfllDSTBAVKDBdyfiA() && IsInteractable())
				{
					EfohzTbCKSzFXOZvddkiifUHKNJAc(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void rnYtAjqFQWbOtkkdaZKPQvkgoHGx(PointerEventData P_0, WuQZFQFgQZhdCDygleGdZYLzbLcu P_1)
		{
			if ((!hasPointer || nxZEOXZKKqOJaJHQzBVuQRfLvtVx(P_0.pointerId)) && !TouchInteractable.eQOtidJsScHPAhNKsoQjfKOmxGus(effectivePointerId))
			{
				loVCAvHiVkTywenZxOyDfoYeChtX();
				base.OnPointerUp(P_0);
			}
		}

		private void DrWCKcHTNlwkPaqXmdaJeTroKLYBA(PointerEventData P_0, WuQZFQFgQZhdCDygleGdZYLzbLcu P_1)
		{
			if (hasPointer && !nxZEOXZKKqOJaJHQzBVuQRfLvtVx(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.AkmvdAybnWttxqqkoBPwYmwyZvFm(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				WuQZFQFgQZhdCDygleGdZYLzbLcu.Local => base.allowedMouseButtons, 
				WuQZFQFgQZhdCDygleGdZYLzbLcu.TouchRegion => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && uJoHaltMSUUnfllDSTBAVKDBdyfiA() && IsInteractable() && (!flag || TouchInteractable.UvWKEEWTqGsSgVxePLrQswFrMNzi(mouseButtonFlags)) && !bVBoXxlwqvHZshYxJGrUpBhAysIp)
			{
				if (flag)
				{
					if (TouchInteractable.VFELkaVJSqiXAasbDVxrSoRnbWzM(mouseButtonFlags, out var num))
					{
						tytwpzBfLKRABjcUyTpCdoMTVMig = num;
					}
					else
					{
						tytwpzBfLKRABjcUyTpCdoMTVMig = P_0.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(P_0);
			if (flag2)
			{
				GameObject gameObject = P_1 switch
				{
					WuQZFQFgQZhdCDygleGdZYLzbLcu.Local => base.gameObject, 
					WuQZFQFgQZhdCDygleGdZYLzbLcu.TouchRegion => igUvhtvpmigfiCPinjUkXIwookgIA.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = srMPeQJxVzmllDOkFpHpPRbksmFU((tytwpzBfLKRABjcUyTpCdoMTVMig != int.MinValue) ? tytwpzBfLKRABjcUyTpCdoMTVMig : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					aIwncBmcXuZYYUbRzPHYIBfWftHDA(pointerEventData, P_1);
				}
			}
			LTStQVbguSfoGWLitCkRBlczeuiMA = true;
		}

		private void MWNaqqfJiMTIzqqdLVEfruLTnYCJA(PointerEventData P_0, WuQZFQFgQZhdCDygleGdZYLzbLcu P_1)
		{
			if (hasPointer && !nxZEOXZKKqOJaJHQzBVuQRfLvtVx(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && bVBoXxlwqvHZshYxJGrUpBhAysIp)
			{
				loVCAvHiVkTywenZxOyDfoYeChtX();
			}
			base.OnPointerExit(P_0);
			LTStQVbguSfoGWLitCkRBlczeuiMA = false;
		}

		private void EfohzTbCKSzFXOZvddkiifUHKNJAc(int P_0, Vector2 P_1, WuQZFQFgQZhdCDygleGdZYLzbLcu P_2)
		{
			SKtPMnWHxpaISgXMcqJeiLkdXalPA = P_0;
			bVBoXxlwqvHZshYxJGrUpBhAysIp = true;
			if (_followTouchPosition)
			{
				HgpRqyqpSTCupcvRZSmsQUeQqNSUA(P_0);
			}
			else if (P_2 == WuQZFQFgQZhdCDygleGdZYLzbLcu.TouchRegion && _moveToTouchPosition)
			{
				KbTsxNtwRqcpGEMPeacitCvXgnPL(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, WRGeuWfUZCpPKMSgkElQFBwdcbcdc.TowardTouch);
			}
			IatNevcAXijJfJTZdTDFZhCxeoGKA();
		}

		private void loVCAvHiVkTywenZxOyDfoYeChtX()
		{
			aOMXPnfKTRZehpffYgwhAheAUMLy();
			bVBoXxlwqvHZshYxJGrUpBhAysIp = false;
			if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && FcuINlNMKsQnXXxAMtvvWMFqrnVF)
			{
				ReturnToDefaultPosition();
			}
			cvdBnTHJvoQIdDyUgJTaelYpgDog();
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(igUvhtvpmigfiCPinjUkXIwookgIA != null) || !_useTouchRegionOnly))
			{
				aIwncBmcXuZYYUbRzPHYIBfWftHDA(eventData, WuQZFQFgQZhdCDygleGdZYLzbLcu.Local);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(igUvhtvpmigfiCPinjUkXIwookgIA != null) || !_useTouchRegionOnly))
			{
				rnYtAjqFQWbOtkkdaZKPQvkgoHGx(eventData, WuQZFQFgQZhdCDygleGdZYLzbLcu.Local);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(igUvhtvpmigfiCPinjUkXIwookgIA != null) || !_useTouchRegionOnly))
			{
				DrWCKcHTNlwkPaqXmdaJeTroKLYBA(eventData, WuQZFQFgQZhdCDygleGdZYLzbLcu.Local);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(igUvhtvpmigfiCPinjUkXIwookgIA != null) || !_useTouchRegionOnly))
			{
				MWNaqqfJiMTIzqqdLVEfruLTnYCJA(eventData, WuQZFQFgQZhdCDygleGdZYLzbLcu.Local);
			}
		}

		private void eBDPvewcjpOFcygvEVuoNMkACmSM(PointerEventData P_0)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				aIwncBmcXuZYYUbRzPHYIBfWftHDA(P_0, WuQZFQFgQZhdCDygleGdZYLzbLcu.TouchRegion);
			}
		}

		private void WkqKtTrjWMPJfIiWjZYPwpSPuXXi(PointerEventData P_0)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				rnYtAjqFQWbOtkkdaZKPQvkgoHGx(P_0, WuQZFQFgQZhdCDygleGdZYLzbLcu.TouchRegion);
			}
		}

		private void zcuyaLeAQkbKiYAeLTKnwvlinijl(PointerEventData P_0)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				DrWCKcHTNlwkPaqXmdaJeTroKLYBA(P_0, WuQZFQFgQZhdCDygleGdZYLzbLcu.TouchRegion);
			}
		}

		private void XwykkJVfwRaZAEGyYijOHvNCBZyGc(PointerEventData P_0)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				MWNaqqfJiMTIzqqdLVEfruLTnYCJA(P_0, WuQZFQFgQZhdCDygleGdZYLzbLcu.TouchRegion);
			}
		}

		private void EtpZwZVAMqPLnuaJMwtezQKDGnEaA(float P_0)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && !_useDigitalAxisSimulation)
			{
				XfXRqBujLQOCeNQMVYFaZbAADoCm(null);
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void QCeUrAraHksWQUGsGrxsApnEsIFm(bool P_0)
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				XfXRqBujLQOCeNQMVYFaZbAADoCm(null);
				_onButtonValueChanged.Invoke(P_0);
			}
		}

		private void nlnhUaNmOsZfDVpZDJUHIRFYwOMX()
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				XfXRqBujLQOCeNQMVYFaZbAADoCm(null);
				_onButtonDown.Invoke();
			}
		}

		private void BowTFmEbuCqJDjEtIKzpSUpSrCsd()
		{
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				XfXRqBujLQOCeNQMVYFaZbAADoCm(null);
				_onButtonUp.Invoke();
			}
		}
	}
}
