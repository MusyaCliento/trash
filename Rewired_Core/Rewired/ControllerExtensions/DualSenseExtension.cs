using System;
using Rewired.ControllerExtensions.Internal;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DualSenseExtension : Controller.Extension, IControllerVibrator, IDualShock4Extension, IDualSenseExtension, IHIDControllerExtension
	{
		private class xkpsMXMvfERTUNeaLbJEHSplfzQN : IControllerExtensionSource
		{
			public readonly IDualSenseExtensionSource xRRTnYfrQgGLGyaDGcJoZYohAFVe;

			public xkpsMXMvfERTUNeaLbJEHSplfzQN(IDualSenseExtensionSource P_0)
			{
				xRRTnYfrQgGLGyaDGcJoZYohAFVe = P_0;
			}
		}

		private const int MHMGkSftGnExNkkUQnxCerzyXFqPA = 2;

		private xkpsMXMvfERTUNeaLbJEHSplfzQN xkPgjTBThRJwZsxiMYPcmgFtdpDf;

		private bool dHrBgwXHnnKBuhbhNMhcIcYqMmG;

		private TimerAbs[] IKmVqHuHOlDnVQVJGYgXbPaobqqS;

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
				if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled)
				{
					return 0f;
				}
				return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorR;
			}
			set
			{
				if (dHrBgwXHnnKBuhbhNMhcIcYqMmG)
				{
					xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorR = value;
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
				if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled)
				{
					return 0f;
				}
				return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorG;
			}
			set
			{
				if (dHrBgwXHnnKBuhbhNMhcIcYqMmG)
				{
					xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorG = value;
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
				if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled)
				{
					return 0f;
				}
				return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorB;
			}
			set
			{
				if (dHrBgwXHnnKBuhbhNMhcIcYqMmG)
				{
					xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorB = value;
				}
			}
		}

		public DualSenseMicrophoneLightMode microphoneLightMode
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return DualSenseMicrophoneLightMode.Off;
				}
				if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled)
				{
					return DualSenseMicrophoneLightMode.Off;
				}
				return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.microphoneLightMode;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (dHrBgwXHnnKBuhbhNMhcIcYqMmG && base.enabled)
				{
					xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.microphoneLightMode = value;
				}
			}
		}

		public DualSenseOtherLightBrightness otherLightBrightness
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return DualSenseOtherLightBrightness.High;
				}
				if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled)
				{
					return DualSenseOtherLightBrightness.High;
				}
				return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.otherLightBrightness;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (dHrBgwXHnnKBuhbhNMhcIcYqMmG && base.enabled)
				{
					xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.otherLightBrightness = value;
				}
			}
		}

		public DualSensePlayerLightFlags playerLights
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return DualSensePlayerLightFlags.None;
				}
				if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled)
				{
					return DualSensePlayerLightFlags.None;
				}
				return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.playerLights;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (dHrBgwXHnnKBuhbhNMhcIcYqMmG && base.enabled)
				{
					xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.playerLights = value;
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
				if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG)
				{
					return 0;
				}
				return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.maxTouches;
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
				return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.GetTouchCount();
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
				if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG)
				{
					return 0f;
				}
				return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.batteryLevel;
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
				if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG)
				{
					return false;
				}
				return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.batteryCharging;
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
				if (!(xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe is IHIDControllerExtension iHIDControllerExtension))
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
				if (!(xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe is IHIDControllerExtension iHIDControllerExtension))
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
				if (!(xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe is IHIDControllerExtension iHIDControllerExtension))
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
				if (!(xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe is IHIDControllerExtension iHIDControllerExtension))
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
				if (!(xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe is IHIDControllerExtension iHIDControllerExtension))
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
				if (!(xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe is IHIDControllerExtension iHIDControllerExtension))
				{
					return 0;
				}
				return iHIDControllerExtension.usage;
			}
		}

		public DualSenseExtension(IDualSenseExtensionSource P_0)
			: base(new xkpsMXMvfERTUNeaLbJEHSplfzQN(P_0))
		{
			IKmVqHuHOlDnVQVJGYgXbPaobqqS = new TimerAbs[2];
			ArrayTools.Populate(IKmVqHuHOlDnVQVJGYgXbPaobqqS, 0, IKmVqHuHOlDnVQVJGYgXbPaobqqS.Length);
		}

		private DualSenseExtension(DualSenseExtension P_0)
			: base(P_0)
		{
			try
			{
				IKmVqHuHOlDnVQVJGYgXbPaobqqS = new TimerAbs[P_0.Rewired_002EInterfaces_002EIControllerVibrator_002EvibrationMotorCount];
			}
			catch
			{
				IKmVqHuHOlDnVQVJGYgXbPaobqqS = new TimerAbs[0];
			}
			ArrayTools.Populate(IKmVqHuHOlDnVQVJGYgXbPaobqqS, 0, IKmVqHuHOlDnVQVJGYgXbPaobqqS.Length);
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
				if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled)
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
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.leftMotor, 
				1 => xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.rightMotor, 
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
			else if (dHrBgwXHnnKBuhbhNMhcIcYqMmG && base.enabled)
			{
				for (int i = 0; i < IKmVqHuHOlDnVQVJGYgXbPaobqqS.Length; i++)
				{
					IKmVqHuHOlDnVQVJGYgXbPaobqqS[i].Clear();
				}
				xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.StopVibration();
			}
		}

		void IControllerVibrator.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public DualSenseVibrationMode GetVibrationMode()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return DualSenseVibrationMode.Compatible2;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.vibrationMode;
		}

		public void SetVibrationMode(DualSenseVibrationMode mode)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.vibrationMode = mode;
			}
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.leftMotor, 
				1 => xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.rightMotor, 
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
				if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < IKmVqHuHOlDnVQVJGYgXbPaobqqS.Length; i++)
					{
						IKmVqHuHOlDnVQVJGYgXbPaobqqS[i].Clear();
					}
					xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.leftMotor = motorLevel;
					break;
				case 1:
					xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.rightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				DIzGcwgSYVGHvNvxHVtslfMhANkz(motor, motorLevel, duration);
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
			else if (dHrBgwXHnnKBuhbhNMhcIcYqMmG && base.enabled)
			{
				xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.leftMotor = MathTools.Clamp01(leftMotorLevel);
				xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.rightMotor = MathTools.Clamp01(rightMotorLevel);
				DIzGcwgSYVGHvNvxHVtslfMhANkz(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				DIzGcwgSYVGHvNvxHVtslfMhANkz(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
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
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG)
			{
				return default(Color);
			}
			return new Color(xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorR, xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorG, xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (dHrBgwXHnnKBuhbhNMhcIcYqMmG && base.enabled)
			{
				xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorR = color.r * color.a;
				xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorG = color.g * color.a;
				xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorB = color.b * color.a;
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
			else if (dHrBgwXHnnKBuhbhNMhcIcYqMmG && base.enabled)
			{
				xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorR = red * intensity;
				xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorG = green * intensity;
				xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lightColorB = blue * intensity;
			}
		}

		void IDualShock4Extension.SetLightColor(float red, float green, float blue, float intensity)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLightColor
			this.SetLightColor(red, green, blue, intensity);
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.accelerometerValueRaw;
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
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.accelerometerValue;
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
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.lastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.gyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.gyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.orientation;
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
			else if (dHrBgwXHnnKBuhbhNMhcIcYqMmG)
			{
				xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.ResetOrientation();
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
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.GetTouchIdAtIndex(index);
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
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.GetTouchPositionByIndex(index, out position);
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
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.GetTouchPositionByTouchId(touchId, out position);
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
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.IsTouchingAtIndex(index);
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
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.IsTouchingAtTouchId(touchId);
		}

		bool IDualShock4Extension.IsTouchingByTouchId(int touchId)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingByTouchId
			return this.IsTouchingByTouchId(touchId);
		}

		public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.SetTriggerEffect(trigger, effect);
		}

		bool IDualSenseExtension.SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetTriggerEffect
			return this.SetTriggerEffect(trigger, effect);
		}

		public DualSenseTriggerEffectStates GetTriggerEffectStates()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return default(DualSenseTriggerEffectStates);
			}
			return xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe.GetTriggerEffectStates();
		}

		DualSenseTriggerEffectStates IDualSenseExtension.GetTriggerEffectStates()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTriggerEffectStates
			return this.GetTriggerEffectStates();
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
			if (dHrBgwXHnnKBuhbhNMhcIcYqMmG && base.enabled)
			{
				UsWEkqkwBiWROaZdMyIDRENhHojrA();
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			xkPgjTBThRJwZsxiMYPcmgFtdpDf = source as xkpsMXMvfERTUNeaLbJEHSplfzQN;
			dHrBgwXHnnKBuhbhNMhcIcYqMmG = xkPgjTBThRJwZsxiMYPcmgFtdpDf != null && xkPgjTBThRJwZsxiMYPcmgFtdpDf.xRRTnYfrQgGLGyaDGcJoZYohAFVe != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DualSenseExtension(this);
		}

		private void UsWEkqkwBiWROaZdMyIDRENhHojrA()
		{
			if (!dHrBgwXHnnKBuhbhNMhcIcYqMmG)
			{
				return;
			}
			for (int i = 0; i < IKmVqHuHOlDnVQVJGYgXbPaobqqS.Length; i++)
			{
				if (IKmVqHuHOlDnVQVJGYgXbPaobqqS[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void DIzGcwgSYVGHvNvxHVtslfMhANkz(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				IKmVqHuHOlDnVQVJGYgXbPaobqqS[num].Clear();
			}
			else
			{
				IKmVqHuHOlDnVQVJGYgXbPaobqqS[num].Start(P_2);
			}
		}
	}
}
