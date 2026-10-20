using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms.Custom;
using Rewired.Platforms.Custom.ControllerComponents;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.Platforms.UnityInputSystem
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class UnityInputSystemInputSourceBase : CustomInputSource
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract class InputDeviceInfoComponent : Controller.Component
		{
			public abstract object inputDevice { get; }

			public abstract string product { get; }

			public abstract string capabilities { get; }

			public abstract string deviceClass { get; }

			public abstract string interfaceName { get; }

			public abstract string manufacturer { get; }

			public abstract string serial { get; }

			public abstract string version { get; }

			public abstract string path { get; }

			public abstract string layout { get; }

			public abstract string variants { get; }

			public abstract bool noisy { get; }

			public abstract bool synthetic { get; }

			public abstract Type valueType { get; }

			public abstract int valueSizeInBytes { get; }

			public abstract float magnitude { get; }

			public abstract string shortDisplayName { get; }

			public abstract string name { get; }

			public abstract string displayName { get; }

			public abstract bool canRunInBackground { get; }

			public abstract bool added { get; }

			public abstract int GetAliases(IList<string> results);

			public abstract int GetUsages(IList<string> results);

			protected InputDeviceInfoComponent(Controller P_0)
				: base(P_0)
			{
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract class IntensityVibrationComponent : VibrationComponent, IIntensityVibrationComponent, IVibrationComponent
		{
			protected IntensityVibrationComponent(int P_0, Controller P_1)
				: base(P_1)
			{
				for (int i = 0; i < P_0; i++)
				{
					AddMotor(new IntensityVibrationMotor());
				}
			}

			protected IntensityVibrationComponent(Controller P_0)
				: this(0, P_0)
			{
			}

			public virtual IntensityVibration GetVibration(int motorIndex)
			{
				if ((uint)motorIndex >= (uint)base.Rewired_002EPlatforms_002ECustom_002EControllerComponents_002EIVibrationComponent_002EmotorCount)
				{
					return default(IntensityVibration);
				}
				if (!(GetMotor(motorIndex) is IIntensityVibrationMotor intensityVibrationMotor))
				{
					return default(IntensityVibration);
				}
				return intensityVibrationMotor.GetVibration();
			}

			IntensityVibration IIntensityVibrationComponent.GetVibration(int motorIndex)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GetVibration
				return this.GetVibration(motorIndex);
			}

			public virtual void SetVibration(IntensityVibrationCommand vibration)
			{
				if ((uint)vibration.motorIndex < base.Rewired_002EPlatforms_002ECustom_002EControllerComponents_002EIVibrationComponent_002EmotorCount)
				{
					if (vibration.stopOtherMotors)
					{
						ClearMotorValues();
					}
					if (GetMotor(vibration.motorIndex) is IIntensityVibrationMotor intensityVibrationMotor)
					{
						intensityVibrationMotor.SetVibration(vibration.vibration, vibration.duration);
						bvBvbMTnkPqVPBdJKkMRLJRtDFFIA();
					}
				}
			}

			void IIntensityVibrationComponent.SetVibration(IntensityVibrationCommand vibration)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetVibration
				this.SetVibration(vibration);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract class VibrationComponent : Controller.Component, IVibrationComponent
		{
			private readonly AList<IVibrationMotor> dffjEeZLlkjrmbCSoLyYuMKCXciA;

			private bool StLpJBiRKlASzDbdrLfuAJiIiFNwB;

			private bool QxnATzkVumpNJbeaKXkkgmoInCUvB;

			int IVibrationComponent.motorCount => dffjEeZLlkjrmbCSoLyYuMKCXciA._count;

			protected VibrationComponent(Controller P_0)
				: base(P_0)
			{
				dffjEeZLlkjrmbCSoLyYuMKCXciA = new AList<IVibrationMotor>();
			}

			protected override void OnInitialize()
			{
				base.OnInitialize();
				StLpJBiRKlASzDbdrLfuAJiIiFNwB = true;
			}

			protected bool AddMotor(IVibrationMotor motor)
			{
				vKZecJFfthsLEVcGKbvtAlbiboiBA();
				if (motor == null)
				{
					return false;
				}
				if (dffjEeZLlkjrmbCSoLyYuMKCXciA.Contains(motor))
				{
					return false;
				}
				dffjEeZLlkjrmbCSoLyYuMKCXciA.Add(motor);
				if (motor is VibrationMotor)
				{
					VibrationMotor obj = (VibrationMotor)motor;
					obj.StartEvent += APoRWhsqNhZmpcjFyhaHiAukrBFI;
					obj.StopEvent += APoRWhsqNhZmpcjFyhaHiAukrBFI;
					obj.wlhfYjtclfAEsMZSxJlYkaLDhgWgA();
				}
				return true;
			}

			protected IVibrationMotor GetMotor(int motorIndex)
			{
				if ((uint)motorIndex >= (uint)dffjEeZLlkjrmbCSoLyYuMKCXciA._count)
				{
					return null;
				}
				return dffjEeZLlkjrmbCSoLyYuMKCXciA._items[motorIndex];
			}

			public void StopVibration()
			{
				ClearMotorValues();
				OnStopVibration();
				bvBvbMTnkPqVPBdJKkMRLJRtDFFIA();
			}

			void IVibrationComponent.StopVibration()
			{
				//ILSpy generated this explicit interface implementation from .override directive in StopVibration
				this.StopVibration();
			}

			public void StopVibration(int motorIndex)
			{
				if ((uint)motorIndex < (uint)dffjEeZLlkjrmbCSoLyYuMKCXciA._count)
				{
					dffjEeZLlkjrmbCSoLyYuMKCXciA._items[motorIndex].Clear();
					bvBvbMTnkPqVPBdJKkMRLJRtDFFIA();
				}
			}

			void IVibrationComponent.StopVibration(int motorIndex)
			{
				//ILSpy generated this explicit interface implementation from .override directive in StopVibration
				this.StopVibration(motorIndex);
			}

			protected virtual void OnStopVibration()
			{
			}

			protected abstract void OnCommitVibration();

			protected override void OnUpdate()
			{
				base.OnUpdate();
				for (int i = 0; i < dffjEeZLlkjrmbCSoLyYuMKCXciA._count; i++)
				{
					dffjEeZLlkjrmbCSoLyYuMKCXciA._items[i].Update();
				}
				if (QxnATzkVumpNJbeaKXkkgmoInCUvB)
				{
					bvBvbMTnkPqVPBdJKkMRLJRtDFFIA();
				}
			}

			internal void bvBvbMTnkPqVPBdJKkMRLJRtDFFIA()
			{
				QxnATzkVumpNJbeaKXkkgmoInCUvB = false;
				OnCommitVibration();
			}

			protected virtual void ClearMotorValues()
			{
				for (int i = 0; i < dffjEeZLlkjrmbCSoLyYuMKCXciA._count; i++)
				{
					dffjEeZLlkjrmbCSoLyYuMKCXciA._items[i].Clear();
				}
			}

			protected override void OnDisposed()
			{
				base.OnDisposed();
				StopVibration();
			}

			private void APoRWhsqNhZmpcjFyhaHiAukrBFI()
			{
				QxnATzkVumpNJbeaKXkkgmoInCUvB = true;
			}

			private void vKZecJFfthsLEVcGKbvtAlbiboiBA()
			{
				if (StLpJBiRKlASzDbdrLfuAJiIiFNwB)
				{
					throw new NotSupportedException(typeof(VibrationComponent).Name + " is already initialized.");
				}
			}
		}

		public abstract class ElementIdentifierTool : IElementIdentifierTool
		{
			private Rewired.Internal.GUIText ztBGYZZatnVcarrLOwDmdMmUDICI;

			protected string text
			{
				get
				{
					return ztBGYZZatnVcarrLOwDmdMmUDICI.text;
				}
				set
				{
					ztBGYZZatnVcarrLOwDmdMmUDICI.text = value;
				}
			}

			protected abstract int selectedDeviceIndex { get; set; }

			protected abstract void OnInitialize();

			protected abstract void OnDeinitialize();

			protected abstract void OnUpdate();

			protected abstract void OnDeviceConnected();

			protected abstract void OnDeviceDisconnected();

			void IElementIdentifierTool.Initialize(Rewired.Internal.GUIText guiText)
			{
				ztBGYZZatnVcarrLOwDmdMmUDICI = guiText;
				OnInitialize();
			}

			void IElementIdentifierTool.OnDestroy()
			{
				OnDeinitialize();
			}

			void IElementIdentifierTool.Start()
			{
				ReInput.primaryInputManager.SystemDeviceConnectedEvent += OnDeviceConnected;
				ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += OnDeviceDisconnected;
			}

			void IElementIdentifierTool.Update()
			{
				if (UnityInputHelper.GetKeyDown(KeyboardKeyCode.Equals) || UnityInputHelper.GetKeyDown(KeyboardKeyCode.Plus) || UnityInputHelper.GetKeyDown(KeyboardKeyCode.KeypadPlus))
				{
					selectedDeviceIndex++;
				}
				if (UnityInputHelper.GetKeyDown(KeyboardKeyCode.KeypadMinus) || UnityInputHelper.GetKeyDown(KeyboardKeyCode.Minus))
				{
					selectedDeviceIndex--;
				}
				OnUpdate();
			}
		}

		public new abstract class Joystick : CustomInputSource.Joystick
		{
			public new class InitOptions : CustomInputSource.Joystick.InitOptions
			{
				[CompilerGenerated]
				private UnityInputSystemDeviceType oXscimBBazcmtKAhixCGeNDeiKjk;

				public UnityInputSystemDeviceType unityDeviceType
				{
					[CompilerGenerated]
					get
					{
						return oXscimBBazcmtKAhixCGeNDeiKjk;
					}
					[CompilerGenerated]
					set
					{
						oXscimBBazcmtKAhixCGeNDeiKjk = value;
					}
				}

				public InitOptions(UnityInputSystemDeviceType P_0)
				{
					unityDeviceType = P_0;
				}
			}

			private readonly UnityInputSystemDeviceType whHTJAWdTFivoONRrYcqXYeYWQqI;

			private readonly IList<ControllerElementInfo> XvsbOUezZqjMkidLIfnrQUSiePVcA;

			private readonly ReadOnlyCollection<ControllerElementInfo> TXzKrCRqUfGLNBeKhCAsikGtxtvl;

			private readonly BklRNFbORupRonQijSGBRJPUzxPG fKGUzHxpkJarWlHqGGgaSKnoWBBV;

			public UnityInputSystemDeviceType unityDeviceType => whHTJAWdTFivoONRrYcqXYeYWQqI;

			internal IList<ControllerElementInfo> WFhvoVMMEHLwIIbtYiLPyFvXEPdj => TXzKrCRqUfGLNBeKhCAsikGtxtvl;

			protected Joystick(InitOptions P_0)
				: base(P_0)
			{
				whHTJAWdTFivoONRrYcqXYeYWQqI = P_0.unityDeviceType;
				_isConnected = true;
				XvsbOUezZqjMkidLIfnrQUSiePVcA = new List<ControllerElementInfo>();
				TXzKrCRqUfGLNBeKhCAsikGtxtvl = new ReadOnlyCollection<ControllerElementInfo>(XvsbOUezZqjMkidLIfnrQUSiePVcA);
				fKGUzHxpkJarWlHqGGgaSKnoWBBV = new BklRNFbORupRonQijSGBRJPUzxPG();
			}

			protected override void OnInitializationFinished()
			{
				base.OnInitializationFinished();
				GetElementInfo(XvsbOUezZqjMkidLIfnrQUSiePVcA);
				using TempListPool.TList<Element> tList = TempListPool.GetTList<Element>();
				GetElements(tList.list);
				fKGUzHxpkJarWlHqGGgaSKnoWBBV.BUTamjSgLDEzZdLuFZEYyUQEgsCb(ReInput.configVars, tList.list);
			}

			protected override void OnBeforeUpdate()
			{
				base.OnBeforeUpdate();
				fKGUzHxpkJarWlHqGGgaSKnoWBBV.uEsMFUXWwQCEEvXfKAAfekihVkWu(ReInput.currentUpdateLoop);
			}

			protected override void OnAfterUpdate()
			{
				base.OnAfterUpdate();
				fKGUzHxpkJarWlHqGGgaSKnoWBBV.izcBVXBJtrkORRocFJVUexnRyHIE();
			}

			public override float GetAxisValue(int index)
			{
				return fKGUzHxpkJarWlHqGGgaSKnoWBBV.vIYiDaSJFefqqPlVXhKEsLWLypcO(index);
			}

			public override bool GetButtonValue(int index)
			{
				return fKGUzHxpkJarWlHqGGgaSKnoWBBV.cRTpbfUCOExkDEjedNwvMGdMalrx(index).boolValue;
			}

			public override float GetButtonFloatValue(int index)
			{
				return fKGUzHxpkJarWlHqGGgaSKnoWBBV.cRTpbfUCOExkDEjedNwvMGdMalrx(index).floatValue;
			}

			internal virtual void mjwwqDnAnNKTrcNdMXhsLjXwpGwh(int P_0, out bool P_1, out float P_2)
			{
				Button.Value value = fKGUzHxpkJarWlHqGGgaSKnoWBBV.cRTpbfUCOExkDEjedNwvMGdMalrx(P_0);
				P_1 = value.boolValue;
				P_2 = value.floatValue;
			}

			public override void Clear()
			{
				base.Clear();
				fKGUzHxpkJarWlHqGGgaSKnoWBBV.oorAsgLEjyEWEiJknKbUGbsCaRmpb();
			}

			protected abstract int GetElementInfo(IList<ControllerElementInfo> results);

			public abstract UnityInputSystemDeviceMatchingProperties GetDeviceMatchingProperties();

			public abstract bool GetKey(KeyboardKeyCode keyCode);

			internal void xyvlLUUBjpBMPEWJHIxqQWjranefA(string P_0)
			{
				_customName = P_0;
			}
		}

		public new abstract class UnifiedKeyboard : CustomInputSource.UnifiedKeyboard
		{
			public new class InitOptions : CustomInputSource.UnifiedKeyboard.InitOptions
			{
			}

			private readonly IList<ControllerElementInfo> bLDRnZUFHytAmxqCLuECWPzXDTpz;

			private readonly ReadOnlyCollection<ControllerElementInfo> KMIrQbTmcufqiNareZIdpuGVAMjI;

			private readonly BklRNFbORupRonQijSGBRJPUzxPG uODSyPWDPUYQXBagQVMyWhrbaPdD;

			public UnityInputSystemDeviceType unityDeviceType => UnityInputSystemDeviceType.Keyboard;

			internal IList<ControllerElementInfo> HEhIjDpxVJcHdAGVIeacZMClpsKzA => KMIrQbTmcufqiNareZIdpuGVAMjI;

			protected UnifiedKeyboard(InitOptions P_0)
				: base(P_0)
			{
				_isConnected = true;
				bLDRnZUFHytAmxqCLuECWPzXDTpz = new List<ControllerElementInfo>();
				KMIrQbTmcufqiNareZIdpuGVAMjI = new ReadOnlyCollection<ControllerElementInfo>(bLDRnZUFHytAmxqCLuECWPzXDTpz);
				uODSyPWDPUYQXBagQVMyWhrbaPdD = new BklRNFbORupRonQijSGBRJPUzxPG();
			}

			protected override void OnInitializationFinished()
			{
				base.OnInitializationFinished();
				GetElementInfo(bLDRnZUFHytAmxqCLuECWPzXDTpz);
				using TempListPool.TList<Element> tList = TempListPool.GetTList<Element>();
				GetElements(tList.list);
				uODSyPWDPUYQXBagQVMyWhrbaPdD.BUTamjSgLDEzZdLuFZEYyUQEgsCb(ReInput.configVars, tList.list);
			}

			protected override void OnBeforeUpdate()
			{
				base.OnBeforeUpdate();
				uODSyPWDPUYQXBagQVMyWhrbaPdD.uEsMFUXWwQCEEvXfKAAfekihVkWu(ReInput.currentUpdateLoop);
			}

			protected override void OnAfterUpdate()
			{
				base.OnAfterUpdate();
				uODSyPWDPUYQXBagQVMyWhrbaPdD.izcBVXBJtrkORRocFJVUexnRyHIE();
			}

			public override float GetAxisValue(int index)
			{
				return uODSyPWDPUYQXBagQVMyWhrbaPdD.vIYiDaSJFefqqPlVXhKEsLWLypcO(index);
			}

			public override bool GetButtonValue(int index)
			{
				return uODSyPWDPUYQXBagQVMyWhrbaPdD.cRTpbfUCOExkDEjedNwvMGdMalrx(index).boolValue;
			}

			public override float GetButtonFloatValue(int index)
			{
				return uODSyPWDPUYQXBagQVMyWhrbaPdD.cRTpbfUCOExkDEjedNwvMGdMalrx(index).floatValue;
			}

			public override void Clear()
			{
				base.Clear();
				uODSyPWDPUYQXBagQVMyWhrbaPdD.oorAsgLEjyEWEiJknKbUGbsCaRmpb();
			}

			protected abstract int GetElementInfo(IList<ControllerElementInfo> results);
		}

		public new abstract class UnifiedMouse : CustomInputSource.UnifiedMouse
		{
			public new class InitOptions : CustomInputSource.UnifiedMouse.InitOptions
			{
			}

			private readonly IList<ControllerElementInfo> RvjSPeCfcmRbrUsMbrOBRGTyMxJn;

			private readonly ReadOnlyCollection<ControllerElementInfo> YjDtdHtDkNipRECuoAKaITqBICYHc;

			private readonly BklRNFbORupRonQijSGBRJPUzxPG JBrkNMLshZmtqHFreEEXvkHFBuZBA;

			public UnityInputSystemDeviceType unityDeviceType => UnityInputSystemDeviceType.Mouse;

			internal IList<ControllerElementInfo> XhpNzwcFYGsMhCxtikTYZCPzgBMFA => YjDtdHtDkNipRECuoAKaITqBICYHc;

			protected UnifiedMouse(InitOptions P_0)
				: base(P_0)
			{
				_isConnected = true;
				RvjSPeCfcmRbrUsMbrOBRGTyMxJn = new List<ControllerElementInfo>();
				YjDtdHtDkNipRECuoAKaITqBICYHc = new ReadOnlyCollection<ControllerElementInfo>(RvjSPeCfcmRbrUsMbrOBRGTyMxJn);
				JBrkNMLshZmtqHFreEEXvkHFBuZBA = new BklRNFbORupRonQijSGBRJPUzxPG();
			}

			protected override void OnInitializationFinished()
			{
				base.OnInitializationFinished();
				GetElementInfo(RvjSPeCfcmRbrUsMbrOBRGTyMxJn);
				using TempListPool.TList<Element> tList = TempListPool.GetTList<Element>();
				GetElements(tList.list);
				JBrkNMLshZmtqHFreEEXvkHFBuZBA.BUTamjSgLDEzZdLuFZEYyUQEgsCb(ReInput.configVars, tList.list);
			}

			protected override void OnBeforeUpdate()
			{
				base.OnBeforeUpdate();
				JBrkNMLshZmtqHFreEEXvkHFBuZBA.uEsMFUXWwQCEEvXfKAAfekihVkWu(ReInput.currentUpdateLoop);
			}

			protected override void OnAfterUpdate()
			{
				base.OnAfterUpdate();
				JBrkNMLshZmtqHFreEEXvkHFBuZBA.izcBVXBJtrkORRocFJVUexnRyHIE();
			}

			public override float GetAxisValue(int index)
			{
				return JBrkNMLshZmtqHFreEEXvkHFBuZBA.vIYiDaSJFefqqPlVXhKEsLWLypcO(index);
			}

			public override bool GetButtonValue(int index)
			{
				return JBrkNMLshZmtqHFreEEXvkHFBuZBA.cRTpbfUCOExkDEjedNwvMGdMalrx(index).boolValue;
			}

			public override float GetButtonFloatValue(int index)
			{
				return JBrkNMLshZmtqHFreEEXvkHFBuZBA.cRTpbfUCOExkDEjedNwvMGdMalrx(index).floatValue;
			}

			public override void Clear()
			{
				base.Clear();
				JBrkNMLshZmtqHFreEEXvkHFBuZBA.oorAsgLEjyEWEiJknKbUGbsCaRmpb();
			}

			protected abstract int GetElementInfo(IList<ControllerElementInfo> results);
		}

		public struct ControllerElementInfo
		{
			public Element element;

			public string path;
		}

		internal class BklRNFbORupRonQijSGBRJPUzxPG
		{
			private class xVOILQkAzLhktBVpTGeRXYzlNWdH
			{
				private readonly Button.Value[] SFQuqBmviyiOhzYubJdIPkophjGl;

				private readonly float[] VoMNJzQiFEZvCRxuhIGznqMsgnUx;

				private readonly Button[] SQgsmYQGpObWAiglEuCGHGmCjAXgb;

				private readonly Axis[] pMmrahFGPDjfpJpTXNTufayBxapO;

				private readonly Button[] eSuttqlHjJwpgBAhvntUGNOUbwWr;

				private readonly Axis[] jumcIVKumUBAiEqnKfRHAzKjJsVjB;

				private readonly bool pzfDZbbAoOMniCOPgYhKDltQdeZQA;

				private int qywpIcDcnHGRbYUEnZfVlVunXSDf = -1;

				public xVOILQkAzLhktBVpTGeRXYzlNWdH(List<Element> P_0, bool P_1)
				{
					pzfDZbbAoOMniCOPgYhKDltQdeZQA = P_1;
					List<Button> list = new List<Button>();
					List<Axis> list2 = new List<Axis>();
					for (int i = 0; i < P_0.Count; i++)
					{
						if (P_0[i] is Button)
						{
							list.Add(P_0[i] as Button);
						}
						else if (P_0[i] is Axis)
						{
							list2.Add(P_0[i] as Axis);
						}
					}
					eSuttqlHjJwpgBAhvntUGNOUbwWr = list.ToArray();
					jumcIVKumUBAiEqnKfRHAzKjJsVjB = list2.ToArray();
					SFQuqBmviyiOhzYubJdIPkophjGl = new Button.Value[eSuttqlHjJwpgBAhvntUGNOUbwWr.Length];
					VoMNJzQiFEZvCRxuhIGznqMsgnUx = new float[jumcIVKumUBAiEqnKfRHAzKjJsVjB.Length];
					SQgsmYQGpObWAiglEuCGHGmCjAXgb = new Button[eSuttqlHjJwpgBAhvntUGNOUbwWr.Length];
					pMmrahFGPDjfpJpTXNTufayBxapO = new Axis[jumcIVKumUBAiEqnKfRHAzKjJsVjB.Length];
					for (int j = 0; j < SFQuqBmviyiOhzYubJdIPkophjGl.Length; j++)
					{
						SFQuqBmviyiOhzYubJdIPkophjGl[j] = eSuttqlHjJwpgBAhvntUGNOUbwWr[j].defaultValue;
						SQgsmYQGpObWAiglEuCGHGmCjAXgb[j] = new Button(eSuttqlHjJwpgBAhvntUGNOUbwWr[j]);
					}
					for (int k = 0; k < VoMNJzQiFEZvCRxuhIGznqMsgnUx.Length; k++)
					{
						VoMNJzQiFEZvCRxuhIGznqMsgnUx[k] = jumcIVKumUBAiEqnKfRHAzKjJsVjB[k].defaultValue;
						pMmrahFGPDjfpJpTXNTufayBxapO[k] = new Axis(jumcIVKumUBAiEqnKfRHAzKjJsVjB[k]);
					}
				}

				public void MFssywqNxnDMEFNrdcrfBfGYnNgMA()
				{
					int frameCount = Time.frameCount;
					for (int i = 0; i < SQgsmYQGpObWAiglEuCGHGmCjAXgb.Length; i++)
					{
						SQgsmYQGpObWAiglEuCGHGmCjAXgb[i].SetValue(new Button.Value(eSuttqlHjJwpgBAhvntUGNOUbwWr[i].sbbQipmxsrosWJdLPBcCAmtRxbLWA, eSuttqlHjJwpgBAhvntUGNOUbwWr[i].floatValue), eSuttqlHjJwpgBAhvntUGNOUbwWr[i].lastModifiedTime);
					}
					for (int j = 0; j < pMmrahFGPDjfpJpTXNTufayBxapO.Length; j++)
					{
						if (pMmrahFGPDjfpJpTXNTufayBxapO[j].coordinateMode == AxisCoordinateMode.Relative)
						{
							if (pzfDZbbAoOMniCOPgYhKDltQdeZQA || frameCount != qywpIcDcnHGRbYUEnZfVlVunXSDf)
							{
								pMmrahFGPDjfpJpTXNTufayBxapO[j].SetValue(pMmrahFGPDjfpJpTXNTufayBxapO[j].value + jumcIVKumUBAiEqnKfRHAzKjJsVjB[j].value, jumcIVKumUBAiEqnKfRHAzKjJsVjB[j].lastModifiedTime);
							}
						}
						else
						{
							pMmrahFGPDjfpJpTXNTufayBxapO[j].SetValue(jumcIVKumUBAiEqnKfRHAzKjJsVjB[j].value, jumcIVKumUBAiEqnKfRHAzKjJsVjB[j].lastModifiedTime);
						}
					}
					if (qywpIcDcnHGRbYUEnZfVlVunXSDf != frameCount)
					{
						qywpIcDcnHGRbYUEnZfVlVunXSDf = frameCount;
					}
				}

				public void TleYbjsjnrDEWCyTanHWvPjCZcUgA()
				{
					for (int i = 0; i < SQgsmYQGpObWAiglEuCGHGmCjAXgb.Length; i++)
					{
						SFQuqBmviyiOhzYubJdIPkophjGl[i].boolValue = SQgsmYQGpObWAiglEuCGHGmCjAXgb[i].sbbQipmxsrosWJdLPBcCAmtRxbLWA;
						SFQuqBmviyiOhzYubJdIPkophjGl[i].floatValue = SQgsmYQGpObWAiglEuCGHGmCjAXgb[i].floatValue;
					}
					for (int j = 0; j < pMmrahFGPDjfpJpTXNTufayBxapO.Length; j++)
					{
						VoMNJzQiFEZvCRxuhIGznqMsgnUx[j] = pMmrahFGPDjfpJpTXNTufayBxapO[j].value;
					}
					knMZsZdyHtFfUsGEUyASUYqkEPYy();
				}

				public float WyFNAUBSklbkWFyRKezqLMLTECIO(int P_0)
				{
					if ((uint)P_0 >= (uint)VoMNJzQiFEZvCRxuhIGznqMsgnUx.Length)
					{
						return 0f;
					}
					return VoMNJzQiFEZvCRxuhIGznqMsgnUx[P_0];
				}

				public Button.Value ZBMrPZuKdBDNrCJUdJyMbUpdjPhlb(int P_0)
				{
					if ((uint)P_0 >= (uint)SFQuqBmviyiOhzYubJdIPkophjGl.Length)
					{
						return default(Button.Value);
					}
					return SFQuqBmviyiOhzYubJdIPkophjGl[P_0];
				}

				public void ZlhHhQWRDjtTPYUlDuYZFHUltKgv()
				{
					for (int i = 0; i < SQgsmYQGpObWAiglEuCGHGmCjAXgb.Length; i++)
					{
						SQgsmYQGpObWAiglEuCGHGmCjAXgb[i].Clear();
						SFQuqBmviyiOhzYubJdIPkophjGl[i] = SQgsmYQGpObWAiglEuCGHGmCjAXgb[i].defaultValue;
					}
					for (int j = 0; j < pMmrahFGPDjfpJpTXNTufayBxapO.Length; j++)
					{
						pMmrahFGPDjfpJpTXNTufayBxapO[j].Clear();
						VoMNJzQiFEZvCRxuhIGznqMsgnUx[j] = pMmrahFGPDjfpJpTXNTufayBxapO[j].defaultValue;
					}
				}

				private void knMZsZdyHtFfUsGEUyASUYqkEPYy()
				{
					for (int i = 0; i < SQgsmYQGpObWAiglEuCGHGmCjAXgb.Length; i++)
					{
						SQgsmYQGpObWAiglEuCGHGmCjAXgb[i].docDaJHQfMeBmgQMJdFNDlwVsSxzb();
					}
					for (int j = 0; j < pMmrahFGPDjfpJpTXNTufayBxapO.Length; j++)
					{
						pMmrahFGPDjfpJpTXNTufayBxapO[j].docDaJHQfMeBmgQMJdFNDlwVsSxzb();
						if (pMmrahFGPDjfpJpTXNTufayBxapO[j].coordinateMode == AxisCoordinateMode.Relative)
						{
							pMmrahFGPDjfpJpTXNTufayBxapO[j].Clear();
						}
					}
				}
			}

			private readonly IndexedDictionary<int, xVOILQkAzLhktBVpTGeRXYzlNWdH> JsaCdhhmlgtgDJAKLNDSUzJZepgtA;

			private UpdateLoopType IcmGPBFqeWNMAjIObKQoEJMEbySEA;

			private xVOILQkAzLhktBVpTGeRXYzlNWdH zasobZCdNWRnZnOPSMKMtWgkKezh => JsaCdhhmlgtgDJAKLNDSUzJZepgtA.GetValue((int)IcmGPBFqeWNMAjIObKQoEJMEbySEA);

			public BklRNFbORupRonQijSGBRJPUzxPG()
			{
				JsaCdhhmlgtgDJAKLNDSUzJZepgtA = new IndexedDictionary<int, xVOILQkAzLhktBVpTGeRXYzlNWdH>();
			}

			public void BUTamjSgLDEzZdLuFZEYyUQEgsCb(ConfigVars P_0, List<Element> P_1)
			{
				new List<Button>();
				new List<Axis>();
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list = tList.list;
					EnumConverter.ToUpdateLoopTypes(P_0.updateLoop, list);
					for (int i = 0; i < list.Count; i++)
					{
						JsaCdhhmlgtgDJAKLNDSUzJZepgtA.Add((int)list[i], new xVOILQkAzLhktBVpTGeRXYzlNWdH(P_1, P_0.updateMode == UpdateMode.Manual));
					}
				}
				IcmGPBFqeWNMAjIObKQoEJMEbySEA = UpdateLoopType.Update;
			}

			public void uEsMFUXWwQCEEvXfKAAfekihVkWu(UpdateLoopType P_0)
			{
				IcmGPBFqeWNMAjIObKQoEJMEbySEA = P_0;
			}

			public void izcBVXBJtrkORRocFJVUexnRyHIE()
			{
				for (int i = 0; i < JsaCdhhmlgtgDJAKLNDSUzJZepgtA.Count; i++)
				{
					JsaCdhhmlgtgDJAKLNDSUzJZepgtA[i].MFssywqNxnDMEFNrdcrfBfGYnNgMA();
				}
				zasobZCdNWRnZnOPSMKMtWgkKezh.TleYbjsjnrDEWCyTanHWvPjCZcUgA();
			}

			public float vIYiDaSJFefqqPlVXhKEsLWLypcO(int P_0)
			{
				return zasobZCdNWRnZnOPSMKMtWgkKezh.WyFNAUBSklbkWFyRKezqLMLTECIO(P_0);
			}

			public Button.Value cRTpbfUCOExkDEjedNwvMGdMalrx(int P_0)
			{
				return zasobZCdNWRnZnOPSMKMtWgkKezh.ZBMrPZuKdBDNrCJUdJyMbUpdjPhlb(P_0);
			}

			public void oorAsgLEjyEWEiJknKbUGbsCaRmpb()
			{
				for (int i = 0; i < JsaCdhhmlgtgDJAKLNDSUzJZepgtA.Count; i++)
				{
					JsaCdhhmlgtgDJAKLNDSUzJZepgtA[i].ZlhHhQWRDjtTPYUlDuYZFHUltKgv();
				}
			}
		}

		private readonly UnityInputSystemInputSourceInitOptions taLNIkQLOwdeYdEGIsRrOCldJjJe;

		private bool tQCAxjKDQmKZAiBjvlrDHBCQVzsn;

		bool CustomInputSource.isReady => true;

		public UnityInputSystemInputSourceBase(UnityInputSystemInputSourceInitOptions P_0)
			: base(10)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initOptions");
			}
			taLNIkQLOwdeYdEGIsRrOCldJjJe = P_0;
		}

		public override void Update()
		{
			IList<Controller> controllers = GetControllers();
			int count = controllers.Count;
			for (int i = 0; i < count; i++)
			{
				try
				{
					controllers[i].Update2();
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred during source controller update.\n" + ex);
				}
			}
			OnUpdate();
		}

		protected virtual void OnUpdate()
		{
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (!tQCAxjKDQmKZAiBjvlrDHBCQVzsn)
			{
				tQCAxjKDQmKZAiBjvlrDHBCQVzsn = true;
			}
		}
	}
}
