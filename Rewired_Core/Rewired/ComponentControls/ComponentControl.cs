using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentControl : MonoBehaviour, IComponentControl
	{
		private sealed class VXmNvTELDjHCFeFAkMUAIYxBdADQA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int HSyrWWdJdrIiXdbqayCzyvQjyZib;

			private object kmRBxnybjHsFZYzzebWJFqKqIYuV;

			public ComponentControl tdgdPhbqxTkqRbeTgIAZILgkkIBsB;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return kmRBxnybjHsFZYzzebWJFqKqIYuV;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return kmRBxnybjHsFZYzzebWJFqKqIYuV;
				}
			}

			[DebuggerHidden]
			public VXmNvTELDjHCFeFAkMUAIYxBdADQA(int P_0)
			{
				HSyrWWdJdrIiXdbqayCzyvQjyZib = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				HSyrWWdJdrIiXdbqayCzyvQjyZib = -2;
			}

			private bool MoveNext()
			{
				int hSyrWWdJdrIiXdbqayCzyvQjyZib = HSyrWWdJdrIiXdbqayCzyvQjyZib;
				ComponentControl componentControl = tdgdPhbqxTkqRbeTgIAZILgkkIBsB;
				switch (hSyrWWdJdrIiXdbqayCzyvQjyZib)
				{
				default:
					return false;
				case 0:
					HSyrWWdJdrIiXdbqayCzyvQjyZib = -1;
					kmRBxnybjHsFZYzzebWJFqKqIYuV = null;
					HSyrWWdJdrIiXdbqayCzyvQjyZib = 1;
					return true;
				case 1:
					HSyrWWdJdrIiXdbqayCzyvQjyZib = -1;
					if (!componentControl.uJoHaltMSUUnfllDSTBAVKDBdyfiA())
					{
						return false;
					}
					componentControl.OnEnable();
					return false;
				}
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

		private IComponentController _controller;

		[NonSerialized]
		private bool sgQGKXBfFhnrSEoEfzTWUdZxbtkeb;

		[NonSerialized]
		private bool TIhKfFjKfqbQWKmLimiFOoteOAdN;

		private int _lastUpdateFrame = -1;

		internal abstract bool EtAcLDGWDFPgJjzEWQEywAqMgoOdb { get; }

		internal bool VuxFOLCyORNjXPqrjNuQvkTlJuirA => sgQGKXBfFhnrSEoEfzTWUdZxbtkeb;

		[CustomObfuscation(rename = false)]
		internal ComponentControl()
		{
		}

		public abstract void ClearValue();

		void IComponentControl.Update()
		{
			int frameCount = Time.frameCount;
			if (_lastUpdateFrame != frameCount)
			{
				_lastUpdateFrame = frameCount;
				epUjHrbOoOHMLLTrFTPJrNSFcfqc();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			TIhKfFjKfqbQWKmLimiFOoteOAdN = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!TIhKfFjKfqbQWKmLimiFOoteOAdN)
			{
				sgQGKXBfFhnrSEoEfzTWUdZxbtkeb = false;
				StartCoroutine(oiJWtEPIuBPRqWJCKhweSVYGQzUg());
				TIhKfFjKfqbQWKmLimiFOoteOAdN = true;
			}
			else if (Application.isPlaying)
			{
				uisIybSnApcvBkbWSdhVKBosRnyuA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (Application.isPlaying)
			{
				PwbCfJEqwjuifDZHgCUhMBYLtivu();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (sgQGKXBfFhnrSEoEfzTWUdZxbtkeb)
			{
				fmbiSIyavHaxPDKcXOmGbqJJkDrmB();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (sgQGKXBfFhnrSEoEfzTWUdZxbtkeb)
			{
				FZrhjUSFYZEBplKDBoXjCciArIzf(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (sgQGKXBfFhnrSEoEfzTWUdZxbtkeb)
			{
				FZrhjUSFYZEBplKDBoXjCciArIzf(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			_ = sgQGKXBfFhnrSEoEfzTWUdZxbtkeb;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			_ = sgQGKXBfFhnrSEoEfzTWUdZxbtkeb;
		}

		internal virtual void epUjHrbOoOHMLLTrFTPJrNSFcfqc()
		{
		}

		internal virtual bool FvfXOolhJLGULEPtTKRTbjTgMlRSb()
		{
			sgQGKXBfFhnrSEoEfzTWUdZxbtkeb = false;
			if (!FZrhjUSFYZEBplKDBoXjCciArIzf(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void PwbCfJEqwjuifDZHgCUhMBYLtivu()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			MdxaSMfhOArpNdCtVHGTbzUGCNznc();
			sgQGKXBfFhnrSEoEfzTWUdZxbtkeb = false;
		}

		internal virtual void mYSWVfEgwJbPOFSEdGEUUSojnJAhA()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				MdxaSMfhOArpNdCtVHGTbzUGCNznc();
			}
		}

		internal virtual void MdxaSMfhOArpNdCtVHGTbzUGCNznc()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void pUykrpNetTUYuDBqRmvvBYWqWEhe()
		{
			if (sgQGKXBfFhnrSEoEfzTWUdZxbtkeb)
			{
				fmbiSIyavHaxPDKcXOmGbqJJkDrmB();
			}
		}

		internal virtual void YzxKKOVrxwkgoHefBOYjLtxwJquq()
		{
			_ = sgQGKXBfFhnrSEoEfzTWUdZxbtkeb;
		}

		internal virtual void AvHSRnnBufZEJSmJWGXuDvuVmhQdb()
		{
		}

		internal bool uJoHaltMSUUnfllDSTBAVKDBdyfiA()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool HCExcUMQGOMpsAqpChWTbnkanwZBA()
		{
			return this == null;
		}

		internal IComponentController NoIazLsYSTwUBTYAJWqIMTXWTYWh()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		[IteratorStateMachine(typeof(VXmNvTELDjHCFeFAkMUAIYxBdADQA))]
		private IEnumerator oiJWtEPIuBPRqWJCKhweSVYGQzUg()
		{
			return new VXmNvTELDjHCFeFAkMUAIYxBdADQA(0)
			{
				tdgdPhbqxTkqRbeTgIAZILgkkIBsB = this
			};
		}

		private void uisIybSnApcvBkbWSdhVKBosRnyuA()
		{
			if (FvfXOolhJLGULEPtTKRTbjTgMlRSb())
			{
				AvHSRnnBufZEJSmJWGXuDvuVmhQdb();
				sgQGKXBfFhnrSEoEfzTWUdZxbtkeb = true;
				mYSWVfEgwJbPOFSEdGEUUSojnJAhA();
			}
		}

		private bool FZrhjUSFYZEBplKDBoXjCciArIzf(bool P_0, bool P_1)
		{
			bool flag = false;
			try
			{
				IComponentController componentController = FindController();
				if (!_controller.IsNullOrDestroyed() && _controller != componentController)
				{
					flag = true;
				}
				_controller = componentController;
				if (_controller == null)
				{
					Type type = GetRequiredControllerType();
					if (type == null)
					{
						type = typeof(IComponentController);
					}
					if (P_1)
					{
						Logger.LogError(type.Name + " could not be found. You must have a component that extends from " + type.Name + " on this or a parent GameObject.");
					}
					throw new Exception();
				}
				if (!P_0 && flag)
				{
					uisIybSnApcvBkbWSdhVKBosRnyuA();
				}
				return true;
			}
			catch
			{
				PwbCfJEqwjuifDZHgCUhMBYLtivu();
				return false;
			}
		}

		private void fmbiSIyavHaxPDKcXOmGbqJJkDrmB()
		{
			FZrhjUSFYZEBplKDBoXjCciArIzf(false, true);
		}

		private void dKiyrOFdiIovlRHFpbBNCjHRyjIC()
		{
			if (!HCExcUMQGOMpsAqpChWTbnkanwZBA() && uJoHaltMSUUnfllDSTBAVKDBdyfiA())
			{
				epUjHrbOoOHMLLTrFTPJrNSFcfqc();
			}
		}
	}
}
