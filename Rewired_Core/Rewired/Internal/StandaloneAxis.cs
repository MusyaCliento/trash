using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Internal
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class StandaloneAxis
	{
		[CustomObfuscation(rename = false)]
		public delegate void AxisValueChangedEventHandler(float value);

		[CustomObfuscation(rename = false)]
		public delegate void ButtonValueChangedEventHandler(bool value);

		[CustomObfuscation(rename = false)]
		public delegate void ButtonDownEventHandler();

		[CustomObfuscation(rename = false)]
		public delegate void ButtonUpEventHandler();

		[Tooltip("The axis value at or above which the buttonValue property will return True. This will also return true for negative values below the inverse of this threshold.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 1f)]
		private float _buttonActivationThreshold = 0.5f;

		[Tooltip("Contains calibration settings for the axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisCalibration _calibration = new AxisCalibration();

		[CustomObfuscation(rename = false)]
		private float _valueRaw;

		[CustomObfuscation(rename = false)]
		private float _valueRawPrev;

		[CompilerGenerated]
		private AxisValueChangedEventHandler guJGHOJhPofRjHaUZloqyfqKSZYX;

		[CompilerGenerated]
		private AxisValueChangedEventHandler nOadHdFCarjpssJEFILUdZeTZqDi;

		[CompilerGenerated]
		private ButtonDownEventHandler MQxDCCGCqHhgQDFFFniBrbqjtkTvB;

		[CompilerGenerated]
		private ButtonUpEventHandler outKREkykRiagXNuYCCNAFtjDwlnA;

		[CompilerGenerated]
		private ButtonValueChangedEventHandler ZJJFcJBifEGsynWsFcWCsCKJDTCQ;

		[CompilerGenerated]
		private ButtonDownEventHandler HKLbVGLfPjevBUspfnKGXGpmXXhj;

		[CompilerGenerated]
		private ButtonUpEventHandler VSGPBvmrhhKbmoURyrOCkLuwdsoKA;

		[CompilerGenerated]
		private ButtonValueChangedEventHandler KfaxDWIEVcWMMEjIgUMCcpNPcKfEA;

		public float buttonActivationThreshold
		{
			get
			{
				return _buttonActivationThreshold;
			}
			set
			{
				if (value != _buttonActivationThreshold)
				{
					_buttonActivationThreshold = MathTools.Abs(value);
				}
			}
		}

		public AxisCalibration calibration
		{
			get
			{
				return _calibration;
			}
			private set
			{
				if (axisCalibration != _calibration)
				{
					_calibration = axisCalibration;
				}
			}
		}

		public float valueRaw
		{
			get
			{
				return _valueRaw;
			}
			private set
			{
				if (num != _valueRaw)
				{
					_valueRaw = num;
				}
			}
		}

		public float valueRawPrev
		{
			get
			{
				return _valueRawPrev;
			}
			private set
			{
				if (num != _valueRawPrev)
				{
					_valueRawPrev = num;
				}
			}
		}

		public float valueRawDelta => _valueRaw - _valueRawPrev;

		public float value
		{
			get
			{
				if (_calibration == null)
				{
					return _valueRaw;
				}
				return _calibration.GetCalibratedValue(_valueRaw);
			}
		}

		public float valuePrev
		{
			get
			{
				if (_calibration == null)
				{
					return _valueRawPrev;
				}
				return _calibration.GetCalibratedValue(_valueRawPrev);
			}
		}

		public float valueDelta
		{
			get
			{
				if (_calibration == null)
				{
					return valueRawDelta;
				}
				return _calibration.GetCalibratedValue(_valueRaw) - _calibration.GetCalibratedValue(_valueRawPrev);
			}
		}

		public bool rawButtonValue => _valueRaw >= _buttonActivationThreshold;

		public bool rawButtonValuePrev => _valueRawPrev >= _buttonActivationThreshold;

		public bool buttonValue => MathTools.Abs(_calibration.GetCalibratedValue(value)) >= _buttonActivationThreshold;

		public bool buttonValuePrev => MathTools.Abs(_calibration.GetCalibratedValue(valuePrev)) >= _buttonActivationThreshold;

		internal float rawMin
		{
			get
			{
				if (_calibration == null)
				{
					return -1f;
				}
				if (!_calibration.applyRangeCalibration)
				{
					return float.NegativeInfinity;
				}
				return _calibration.calibratedMin;
			}
		}

		internal float rawMax
		{
			get
			{
				if (_calibration == null)
				{
					return 1f;
				}
				if (!_calibration.applyRangeCalibration)
				{
					return float.PositiveInfinity;
				}
				return _calibration.calibratedMax;
			}
		}

		internal float rawZero
		{
			get
			{
				if (_calibration == null)
				{
					return 0f;
				}
				if (!_calibration.applyRangeCalibration)
				{
					return 0f;
				}
				return _calibration.calibratedZero;
			}
		}

		private event AxisValueChangedEventHandler _AxisValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = guJGHOJhPofRjHaUZloqyfqKSZYX;
				AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler2, b);
					axisValueChangedEventHandler = Interlocked.CompareExchange(ref guJGHOJhPofRjHaUZloqyfqKSZYX, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
				}
				while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = guJGHOJhPofRjHaUZloqyfqKSZYX;
				AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler2, axisValueChangedEventHandler4);
					axisValueChangedEventHandler = Interlocked.CompareExchange(ref guJGHOJhPofRjHaUZloqyfqKSZYX, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
				}
				while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
			}
		}

		public event AxisValueChangedEventHandler AxisValueChangedEvent
		{
			add
			{
				_AxisValueChangedEvent += value;
			}
			remove
			{
				_AxisValueChangedEvent -= value;
			}
		}

		private event AxisValueChangedEventHandler _RawAxisValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = nOadHdFCarjpssJEFILUdZeTZqDi;
				AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler2, b);
					axisValueChangedEventHandler = Interlocked.CompareExchange(ref nOadHdFCarjpssJEFILUdZeTZqDi, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
				}
				while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = nOadHdFCarjpssJEFILUdZeTZqDi;
				AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler2, axisValueChangedEventHandler4);
					axisValueChangedEventHandler = Interlocked.CompareExchange(ref nOadHdFCarjpssJEFILUdZeTZqDi, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
				}
				while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
			}
		}

		public event AxisValueChangedEventHandler RawAxisValueChangedEvent
		{
			add
			{
				_RawAxisValueChangedEvent += value;
			}
			remove
			{
				_RawAxisValueChangedEvent -= value;
			}
		}

		private event ButtonDownEventHandler _ButtonDownEvent
		{
			[CompilerGenerated]
			add
			{
				ButtonDownEventHandler buttonDownEventHandler = MQxDCCGCqHhgQDFFFniBrbqjtkTvB;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, b);
					buttonDownEventHandler = Interlocked.CompareExchange(ref MQxDCCGCqHhgQDFFFniBrbqjtkTvB, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ButtonDownEventHandler buttonDownEventHandler = MQxDCCGCqHhgQDFFFniBrbqjtkTvB;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, buttonDownEventHandler4);
					buttonDownEventHandler = Interlocked.CompareExchange(ref MQxDCCGCqHhgQDFFFniBrbqjtkTvB, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
		}

		public event ButtonDownEventHandler ButtonDownEvent
		{
			add
			{
				_ButtonDownEvent += value;
			}
			remove
			{
				_ButtonDownEvent -= value;
			}
		}

		private event ButtonUpEventHandler _ButtonUpEvent
		{
			[CompilerGenerated]
			add
			{
				ButtonUpEventHandler buttonUpEventHandler = outKREkykRiagXNuYCCNAFtjDwlnA;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, b);
					buttonUpEventHandler = Interlocked.CompareExchange(ref outKREkykRiagXNuYCCNAFtjDwlnA, buttonUpEventHandler3, buttonUpEventHandler2);
				}
				while ((object)buttonUpEventHandler != buttonUpEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ButtonUpEventHandler buttonUpEventHandler = outKREkykRiagXNuYCCNAFtjDwlnA;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, buttonUpEventHandler4);
					buttonUpEventHandler = Interlocked.CompareExchange(ref outKREkykRiagXNuYCCNAFtjDwlnA, buttonUpEventHandler3, buttonUpEventHandler2);
				}
				while ((object)buttonUpEventHandler != buttonUpEventHandler2);
			}
		}

		public event ButtonUpEventHandler ButtonUpEvent
		{
			add
			{
				_ButtonUpEvent += value;
			}
			remove
			{
				_ButtonUpEvent -= value;
			}
		}

		private event ButtonValueChangedEventHandler _ButtonValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = ZJJFcJBifEGsynWsFcWCsCKJDTCQ;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, b);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref ZJJFcJBifEGsynWsFcWCsCKJDTCQ, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
				}
				while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = ZJJFcJBifEGsynWsFcWCsCKJDTCQ;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, buttonValueChangedEventHandler4);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref ZJJFcJBifEGsynWsFcWCsCKJDTCQ, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
				}
				while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
		}

		public event ButtonValueChangedEventHandler ButtonValueChangedEvent
		{
			add
			{
				_ButtonValueChangedEvent += value;
			}
			remove
			{
				_ButtonValueChangedEvent -= value;
			}
		}

		private event ButtonDownEventHandler _RawButtonDownEvent
		{
			[CompilerGenerated]
			add
			{
				ButtonDownEventHandler buttonDownEventHandler = HKLbVGLfPjevBUspfnKGXGpmXXhj;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, b);
					buttonDownEventHandler = Interlocked.CompareExchange(ref HKLbVGLfPjevBUspfnKGXGpmXXhj, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ButtonDownEventHandler buttonDownEventHandler = HKLbVGLfPjevBUspfnKGXGpmXXhj;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, buttonDownEventHandler4);
					buttonDownEventHandler = Interlocked.CompareExchange(ref HKLbVGLfPjevBUspfnKGXGpmXXhj, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
		}

		public event ButtonDownEventHandler RawButtonDownEvent
		{
			add
			{
				_RawButtonDownEvent += value;
			}
			remove
			{
				_RawButtonDownEvent -= value;
			}
		}

		private event ButtonUpEventHandler _RawButtonUpEvent
		{
			[CompilerGenerated]
			add
			{
				ButtonUpEventHandler buttonUpEventHandler = VSGPBvmrhhKbmoURyrOCkLuwdsoKA;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, b);
					buttonUpEventHandler = Interlocked.CompareExchange(ref VSGPBvmrhhKbmoURyrOCkLuwdsoKA, buttonUpEventHandler3, buttonUpEventHandler2);
				}
				while ((object)buttonUpEventHandler != buttonUpEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ButtonUpEventHandler buttonUpEventHandler = VSGPBvmrhhKbmoURyrOCkLuwdsoKA;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, buttonUpEventHandler4);
					buttonUpEventHandler = Interlocked.CompareExchange(ref VSGPBvmrhhKbmoURyrOCkLuwdsoKA, buttonUpEventHandler3, buttonUpEventHandler2);
				}
				while ((object)buttonUpEventHandler != buttonUpEventHandler2);
			}
		}

		public event ButtonUpEventHandler RawButtonUpEvent
		{
			add
			{
				_RawButtonUpEvent += value;
			}
			remove
			{
				_RawButtonUpEvent -= value;
			}
		}

		private event ButtonValueChangedEventHandler _RawButtonValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = KfaxDWIEVcWMMEjIgUMCcpNPcKfEA;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, b);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref KfaxDWIEVcWMMEjIgUMCcpNPcKfEA, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
				}
				while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = KfaxDWIEVcWMMEjIgUMCcpNPcKfEA;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, buttonValueChangedEventHandler4);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref KfaxDWIEVcWMMEjIgUMCcpNPcKfEA, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
				}
				while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
		}

		public event ButtonValueChangedEventHandler RawButtonValueChangedEvent
		{
			add
			{
				_RawButtonValueChangedEvent += value;
			}
			remove
			{
				_RawButtonValueChangedEvent -= value;
			}
		}

		internal StandaloneAxis()
		{
		}

		internal void StoreDefaultValues()
		{
			if (_calibration != null)
			{
				_calibration.StoreDefaultValues();
			}
		}

		public void SetRawValue(float value)
		{
			_valueRawPrev = _valueRaw;
			_valueRaw = value;
			if (value == _valueRawPrev)
			{
				return;
			}
			if (nOadHdFCarjpssJEFILUdZeTZqDi != null && _valueRaw != _valueRawPrev)
			{
				nOadHdFCarjpssJEFILUdZeTZqDi(_valueRaw);
			}
			if (guJGHOJhPofRjHaUZloqyfqKSZYX != null)
			{
				float num = this.value;
				if (num != valuePrev)
				{
					guJGHOJhPofRjHaUZloqyfqKSZYX(num);
				}
			}
			if (KfaxDWIEVcWMMEjIgUMCcpNPcKfEA != null)
			{
				bool flag = rawButtonValue;
				if (flag != rawButtonValuePrev)
				{
					KfaxDWIEVcWMMEjIgUMCcpNPcKfEA(flag);
				}
			}
			if (HKLbVGLfPjevBUspfnKGXGpmXXhj != null && rawButtonValue && !rawButtonValuePrev)
			{
				HKLbVGLfPjevBUspfnKGXGpmXXhj();
			}
			if (VSGPBvmrhhKbmoURyrOCkLuwdsoKA != null && !rawButtonValue && rawButtonValuePrev)
			{
				VSGPBvmrhhKbmoURyrOCkLuwdsoKA();
			}
			if (ZJJFcJBifEGsynWsFcWCsCKJDTCQ != null)
			{
				bool flag2 = buttonValue;
				if (flag2 != buttonValuePrev)
				{
					ZJJFcJBifEGsynWsFcWCsCKJDTCQ(flag2);
				}
			}
			if (MQxDCCGCqHhgQDFFFniBrbqjtkTvB != null && buttonValue && !buttonValuePrev)
			{
				MQxDCCGCqHhgQDFFFniBrbqjtkTvB();
			}
			if (outKREkykRiagXNuYCCNAFtjDwlnA != null && !buttonValue && buttonValuePrev)
			{
				outKREkykRiagXNuYCCNAFtjDwlnA();
			}
		}

		public void Clear()
		{
			SetRawValue(rawZero);
		}

		[CustomObfuscation(rename = false)]
		internal static StandaloneAxis CreateRelative()
		{
			return new StandaloneAxis
			{
				_calibration = AxisCalibration.CreateRelative()
			};
		}
	}
}
