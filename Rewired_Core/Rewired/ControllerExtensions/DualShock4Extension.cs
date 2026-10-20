using System;
using Rewired.ControllerExtensions.Internal;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DualShock4Extension : Controller.Extension, IControllerVibrator, IDualShock4Extension, IHIDControllerExtension
	{
		private class hZTACsiYeDnAynzoqlkojIyamvdt : IControllerExtensionSource
		{
			public readonly IDualShock4ExtensionSource CzCWWfdNuFYAnIqCSpBekghliEId;

			public hZTACsiYeDnAynzoqlkojIyamvdt(IDualShock4ExtensionSource P_0)
			{
				CzCWWfdNuFYAnIqCSpBekghliEId = P_0;
			}
		}

		private const int KmEsNYMmUSmIuKGhCWNCdgrSIbae = 2;

		private hZTACsiYeDnAynzoqlkojIyamvdt FYifCMJVQTHfDjVprHSWGCfEuOXRB;

		private bool bZKCnBdvjDFEsPnJsLdDtMUFbFTA;

		private TimerAbs[] ENkNKyCLGwOJeObZTSeDkbscgMEb;

		private Joystick joystick => GetController<Joystick>();

		int IControllerVibrator.vibrationMotorCount => 2;

		public float lightColorRed
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				}
				if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled)
				{
					return 0f;
				}
				return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorR;
			}
			set
			{
				if (bZKCnBdvjDFEsPnJsLdDtMUFbFTA)
				{
					FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorR = value;
				}
			}
		}

		public float lightColorGreen
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				}
				if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled)
				{
					return 0f;
				}
				return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorG;
			}
			set
			{
				if (bZKCnBdvjDFEsPnJsLdDtMUFbFTA)
				{
					FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorG = value;
				}
			}
		}

		public float lightColorBlue
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				}
				if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled)
				{
					return 0f;
				}
				return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorB;
			}
			set
			{
				if (bZKCnBdvjDFEsPnJsLdDtMUFbFTA)
				{
					FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorB = value;
				}
			}
		}

		int IDualShock4Extension.maxTouches
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA)
				{
					return 0;
				}
				return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.maxTouches;
			}
		}

		int IDualShock4Extension.touchCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.GetTouchCount();
			}
		}

		public float batteryLevel
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				}
				if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA)
				{
					return 0f;
				}
				return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.batteryLevel;
			}
		}

		public bool batteryCharging
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA)
				{
					return false;
				}
				return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.batteryCharging;
			}
		}

		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!(FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId is IHIDControllerExtension iHIDControllerExtension))
				{
					return 0;
				}
				return iHIDControllerExtension.vendorId;
			}
		}

		ushort IHIDControllerExtension.productId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!(FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId is IHIDControllerExtension iHIDControllerExtension))
				{
					return 0;
				}
				return iHIDControllerExtension.productId;
			}
		}

		string IHIDControllerExtension.productName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!(FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId is IHIDControllerExtension iHIDControllerExtension))
				{
					return string.Empty;
				}
				return iHIDControllerExtension.productName;
			}
		}

		string IHIDControllerExtension.manufacturer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!(FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId is IHIDControllerExtension iHIDControllerExtension))
				{
					return string.Empty;
				}
				return iHIDControllerExtension.manufacturer;
			}
		}

		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!(FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId is IHIDControllerExtension iHIDControllerExtension))
				{
					return 0;
				}
				return iHIDControllerExtension.usagePage;
			}
		}

		ushort IHIDControllerExtension.usage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!(FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId is IHIDControllerExtension iHIDControllerExtension))
				{
					return 0;
				}
				return iHIDControllerExtension.usage;
			}
		}

		public DualShock4Extension(IDualShock4ExtensionSource P_0)
			: base(new hZTACsiYeDnAynzoqlkojIyamvdt(P_0))
		{
			ENkNKyCLGwOJeObZTSeDkbscgMEb = new TimerAbs[2];
			ArrayTools.Populate(ENkNKyCLGwOJeObZTSeDkbscgMEb, 0, ENkNKyCLGwOJeObZTSeDkbscgMEb.Length);
		}

		private DualShock4Extension(DualShock4Extension P_0)
			: base(P_0)
		{
			try
			{
				ENkNKyCLGwOJeObZTSeDkbscgMEb = new TimerAbs[P_0.Rewired_002EInterfaces_002EIControllerVibrator_002EvibrationMotorCount];
			}
			catch
			{
				ENkNKyCLGwOJeObZTSeDkbscgMEb = new TimerAbs[0];
			}
			ArrayTools.Populate(ENkNKyCLGwOJeObZTSeDkbscgMEb, 0, ENkNKyCLGwOJeObZTSeDkbscgMEb.Length);
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, motorLevel);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, motorLevel, duration);
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, motorLevel, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled)
				{
					return;
				}
				DualShock4MotorType motor;
				switch (motorIndex)
				{
				default:
					return;
				case 1:
					if (motorIndex == 1)
					{
						motor = DualShock4MotorType.RightMotor;
						break;
					}
					throw new NotImplementedException();
				case 0:
					motor = DualShock4MotorType.LeftMotor;
					break;
				}
				SetVibration(motor, motorLevel, duration, stopOtherMotors);
			}
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.leftMotor, 
				1 => FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.rightMotor, 
				_ => 0f, 
			};
		}

		float IControllerVibrator.GetVibration(int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetVibration
			return this.GetVibration(motorIndex);
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (bZKCnBdvjDFEsPnJsLdDtMUFbFTA && base.enabled)
			{
				for (int i = 0; i < ENkNKyCLGwOJeObZTSeDkbscgMEb.Length; i++)
				{
					ENkNKyCLGwOJeObZTSeDkbscgMEb[i].Clear();
				}
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.StopVibration();
			}
		}

		void IControllerVibrator.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.leftMotor, 
				1 => FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.rightMotor, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration)
		{
			SetVibration(motor, motorLevel, duration, stopOtherMotors: false);
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < ENkNKyCLGwOJeObZTSeDkbscgMEb.Length; i++)
					{
						ENkNKyCLGwOJeObZTSeDkbscgMEb[i].Clear();
					}
					FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.leftMotor = motorLevel;
					break;
				case 1:
					FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.rightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				HYzdJLkoTJignaepaHHjizsBpYaA(motor, motorLevel, duration);
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
		}

		void IDualShock4Extension.SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(leftMotorLevel, rightMotorLevel);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (bZKCnBdvjDFEsPnJsLdDtMUFbFTA && base.enabled)
			{
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.leftMotor = MathTools.Clamp01(leftMotorLevel);
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.rightMotor = MathTools.Clamp01(rightMotorLevel);
				HYzdJLkoTJignaepaHHjizsBpYaA(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				HYzdJLkoTJignaepaHHjizsBpYaA(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
			}
		}

		void IDualShock4Extension.SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(leftMotorLevel, rightMotorLevel, leftMotorDuration, rightMotorDuration);
		}

		public Color GetLightColor()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return default(Color);
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA)
			{
				return default(Color);
			}
			return new Color(FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorR, FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorG, FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (bZKCnBdvjDFEsPnJsLdDtMUFbFTA && base.enabled)
			{
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorR = color.r * color.a;
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorG = color.g * color.a;
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorB = color.b * color.a;
			}
		}

		void IDualShock4Extension.SetLightColor(Color color)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLightColor
			this.SetLightColor(color);
		}

		public void SetLightColor(float red, float green, float blue)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				SetLightColor(red, green, blue, 1f);
			}
		}

		void IDualShock4Extension.SetLightColor(float red, float green, float blue)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLightColor
			this.SetLightColor(red, green, blue);
		}

		public void SetLightColor(float red, float green, float blue, float intensity)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (bZKCnBdvjDFEsPnJsLdDtMUFbFTA && base.enabled)
			{
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorR = red * intensity;
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorG = green * intensity;
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightColorB = blue * intensity;
			}
		}

		void IDualShock4Extension.SetLightColor(float red, float green, float blue, float intensity)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLightColor
			this.SetLightColor(red, green, blue, intensity);
		}

		public void SetLightFlash(float onDuration, float offDuration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (bZKCnBdvjDFEsPnJsLdDtMUFbFTA && base.enabled)
			{
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightFlashOnDuration = onDuration;
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lightFlashOffDuration = offDuration;
			}
		}

		public void StopLightFlash()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (bZKCnBdvjDFEsPnJsLdDtMUFbFTA && base.enabled)
			{
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.StopLightFlash();
			}
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.accelerometerValueRaw;
		}

		Vector3 IDualShock4Extension.GetAccelerometerValueRaw()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAccelerometerValueRaw
			return this.GetAccelerometerValueRaw();
		}

		public Vector3 GetAccelerometerValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.accelerometerValue;
		}

		Vector3 IDualShock4Extension.GetAccelerometerValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAccelerometerValue
			return this.GetAccelerometerValue();
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.lastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.gyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.gyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.orientation;
		}

		Quaternion IDualShock4Extension.GetOrientation()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetOrientation
			return this.GetOrientation();
		}

		public void ResetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (bZKCnBdvjDFEsPnJsLdDtMUFbFTA)
			{
				FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.ResetOrientation();
			}
		}

		void IDualShock4Extension.ResetOrientation()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ResetOrientation
			this.ResetOrientation();
		}

		public int GetTouchId(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return -1;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.GetTouchIdAtIndex(index);
		}

		int IDualShock4Extension.GetTouchId(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchId
			return this.GetTouchId(index);
		}

		public bool GetTouchPosition(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.GetTouchPositionByIndex(index, out position);
		}

		bool IDualShock4Extension.GetTouchPosition(int index, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPosition
			return this.GetTouchPosition(index, out position);
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.GetTouchPositionByTouchId(touchId, out position);
		}

		bool IDualShock4Extension.GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByTouchId
			return this.GetTouchPositionByTouchId(touchId, out position);
		}

		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
			position = new Vector2(positionX, positionY);
			return touchPositionAbsoluteByIndex;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
			position = new Vector2(positionX, positionY);
			return touchPositionAbsoluteByTouchId;
		}

		public bool IsTouching(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.IsTouchingAtIndex(index);
		}

		bool IDualShock4Extension.IsTouching(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouching
			return this.IsTouching(index);
		}

		public bool IsTouchingByTouchId(int touchId)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId.IsTouchingAtTouchId(touchId);
		}

		bool IDualShock4Extension.IsTouchingByTouchId(int touchId)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingByTouchId
			return this.IsTouchingByTouchId(touchId);
		}

		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			return GetGyroscopeValue();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			return GetGyroscopeValueRaw();
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (bZKCnBdvjDFEsPnJsLdDtMUFbFTA && base.enabled)
			{
				XCXfFWbQCqZUzhkflvTVJGcMmomEA();
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			FYifCMJVQTHfDjVprHSWGCfEuOXRB = source as hZTACsiYeDnAynzoqlkojIyamvdt;
			bZKCnBdvjDFEsPnJsLdDtMUFbFTA = FYifCMJVQTHfDjVprHSWGCfEuOXRB != null && FYifCMJVQTHfDjVprHSWGCfEuOXRB.CzCWWfdNuFYAnIqCSpBekghliEId != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DualShock4Extension(this);
		}

		private void XCXfFWbQCqZUzhkflvTVJGcMmomEA()
		{
			if (!bZKCnBdvjDFEsPnJsLdDtMUFbFTA)
			{
				return;
			}
			for (int i = 0; i < ENkNKyCLGwOJeObZTSeDkbscgMEb.Length; i++)
			{
				if (ENkNKyCLGwOJeObZTSeDkbscgMEb[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void HYzdJLkoTJignaepaHHjizsBpYaA(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				ENkNKyCLGwOJeObZTSeDkbscgMEb[num].Clear();
			}
			else
			{
				ENkNKyCLGwOJeObZTSeDkbscgMEb[num].Start(P_2);
			}
		}
	}
}
