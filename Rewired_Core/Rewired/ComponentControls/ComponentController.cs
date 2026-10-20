using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentController : MonoBehaviour, IComponentController, IRegistrar<IComponentControl>
	{
		private sealed class PSWgayctpcBnnJLnsIWhDkCJVUeJc : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int irTfysECfjcuzkhiMFIAhWvesTFOA;

			private object ijBQGsRBJmOlhzVnrpPBOQPDMnjL;

			public ComponentController kltJIoybUhcOTIyxxDhTHRoWuAwS;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return ijBQGsRBJmOlhzVnrpPBOQPDMnjL;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ijBQGsRBJmOlhzVnrpPBOQPDMnjL;
				}
			}

			[DebuggerHidden]
			public PSWgayctpcBnnJLnsIWhDkCJVUeJc(int P_0)
			{
				irTfysECfjcuzkhiMFIAhWvesTFOA = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				irTfysECfjcuzkhiMFIAhWvesTFOA = -2;
			}

			private bool MoveNext()
			{
				int num = irTfysECfjcuzkhiMFIAhWvesTFOA;
				ComponentController componentController = kltJIoybUhcOTIyxxDhTHRoWuAwS;
				switch (num)
				{
				default:
					return false;
				case 0:
					irTfysECfjcuzkhiMFIAhWvesTFOA = -1;
					ijBQGsRBJmOlhzVnrpPBOQPDMnjL = null;
					irTfysECfjcuzkhiMFIAhWvesTFOA = 1;
					return true;
				case 1:
					irTfysECfjcuzkhiMFIAhWvesTFOA = -1;
					componentController.CKbGrniajwqkZGzlvxIHPjKaSYjm();
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

		[NonSerialized]
		private bool wpUkLFHTOVLwkvJUjlnJmuuwiIhn;

		[NonSerialized]
		private bool EyDSNPvvfjxDLXPfKPSszKRvSjKu;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool GaxIohhUVZNACrwzhrjQthaitTfBA => wpUkLFHTOVLwkvJUjlnJmuuwiIhn;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			EyDSNPvvfjxDLXPfKPSszKRvSjKu = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!wpUkLFHTOVLwkvJUjlnJmuuwiIhn)
			{
				return;
			}
			for (int num = _controls.Count - 1; num >= 0; num--)
			{
				IComponentControl componentControl = _controls[num];
				if (componentControl.IsNullOrDestroyed())
				{
					_controls.RemoveAt(num);
				}
				else
				{
					componentControl.Update();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!EyDSNPvvfjxDLXPfKPSszKRvSjKu)
			{
				StartCoroutine(MqESifCCCZoTscZXBWkEbfleYyui());
				EyDSNPvvfjxDLXPfKPSszKRvSjKu = true;
			}
			else
			{
				CKbGrniajwqkZGzlvxIHPjKaSYjm();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (wpUkLFHTOVLwkvJUjlnJmuuwiIhn)
			{
				awcyIgQnkxPAqNBXuFNFjzwlOOVPA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (wpUkLFHTOVLwkvJUjlnJmuuwiIhn)
			{
				WfDVuGWbLbMdRjxwKyADMaLJKFfY();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool BfWeEFFhAXFHPAoqVQipyZoWlWTEA()
		{
			return true;
		}

		internal virtual void kEVIhdaZeWkcqewUOSzLgRhVTjju()
		{
			awcyIgQnkxPAqNBXuFNFjzwlOOVPA();
		}

		internal virtual void awcyIgQnkxPAqNBXuFNFjzwlOOVPA()
		{
		}

		void IRegistrar<IComponentControl>.Register(IComponentControl control)
		{
			if (!control.IsNullOrDestroyed())
			{
				ListTools.AddIfUnique(_controls, control);
			}
		}

		void IRegistrar<IComponentControl>.Deregister(IComponentControl control)
		{
			if (!control.IsNullOrDestroyed())
			{
				_controls.Remove(control);
			}
		}

		public virtual void ClearControlValues()
		{
			if (!wpUkLFHTOVLwkvJUjlnJmuuwiIhn)
			{
				return;
			}
			for (int num = _controls.Count - 1; num >= 0; num--)
			{
				if (_controls[num].IsNullOrDestroyed())
				{
					_controls.RemoveAt(num);
				}
				else
				{
					_controls[num].ClearValue();
				}
			}
		}

		void IComponentController.ClearControlValues()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ClearControlValues
			this.ClearControlValues();
		}

		private void CKbGrniajwqkZGzlvxIHPjKaSYjm()
		{
			if (BfWeEFFhAXFHPAoqVQipyZoWlWTEA())
			{
				wpUkLFHTOVLwkvJUjlnJmuuwiIhn = true;
				kEVIhdaZeWkcqewUOSzLgRhVTjju();
			}
		}

		private void WfDVuGWbLbMdRjxwKyADMaLJKFfY()
		{
			_ = GaxIohhUVZNACrwzhrjQthaitTfBA;
		}

		[IteratorStateMachine(typeof(PSWgayctpcBnnJLnsIWhDkCJVUeJc))]
		private IEnumerator MqESifCCCZoTscZXBWkEbfleYyui()
		{
			return new PSWgayctpcBnnJLnsIWhDkCJVUeJc(0)
			{
				kltJIoybUhcOTIyxxDhTHRoWuAwS = this
			};
		}
	}
}
