using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Touch Region")]
	public sealed class TouchRegion : TouchInteractable
	{
		[Serializable]
		private class axdibikgcPCyfgLMyyZbIDsXKnFV : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class xoqUXETNfxoLMMRGmkNLJfnykMpf : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class OUjENDCMJGZgHSTaLymgGpJWoNXf : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class utVELedEwtOzZPnZUhJpvxPAokee : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class jtZnQaKwaupNBrBacaTUpOtHULKE : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class PbBKWcsatGuuFAXIJpxvNdkPLRzi : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class EPvTiCCAUKAjjfurHTxygdzbrsdRA : UnityEvent<PointerEventData>
		{
		}

		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime = true;

		private axdibikgcPCyfgLMyyZbIDsXKnFV _onPointerDown = new axdibikgcPCyfgLMyyZbIDsXKnFV();

		private xoqUXETNfxoLMMRGmkNLJfnykMpf _onPointerUp = new xoqUXETNfxoLMMRGmkNLJfnykMpf();

		private OUjENDCMJGZgHSTaLymgGpJWoNXf _onPointerEnter = new OUjENDCMJGZgHSTaLymgGpJWoNXf();

		private utVELedEwtOzZPnZUhJpvxPAokee _onPointerExit = new utVELedEwtOzZPnZUhJpvxPAokee();

		private jtZnQaKwaupNBrBacaTUpOtHULKE _onBeginDrag = new jtZnQaKwaupNBrBacaTUpOtHULKE();

		private PbBKWcsatGuuFAXIJpxvNdkPLRzi _onDrag = new PbBKWcsatGuuFAXIJpxvNdkPLRzi();

		private EPvTiCCAUKAjjfurHTxygdzbrsdRA _onEndDrag = new EPvTiCCAUKAjjfurHTxygdzbrsdRA();

		public bool hideAtRuntime
		{
			get
			{
				return _hideAtRuntime;
			}
			set
			{
				if (!(_hideAtRuntime = value))
				{
					_hideAtRuntime = true;
					pUykrpNetTUYuDBqRmvvBYWqWEhe();
				}
			}
		}

		public event UnityAction<PointerEventData> PointerDownEvent
		{
			add
			{
				_onPointerDown.AddListener(value);
			}
			remove
			{
				_onPointerDown.RemoveListener(value);
			}
		}

		public event UnityAction<PointerEventData> PointerUpEvent
		{
			add
			{
				_onPointerUp.AddListener(value);
			}
			remove
			{
				_onPointerUp.RemoveListener(value);
			}
		}

		public event UnityAction<PointerEventData> PointerEnterEvent
		{
			add
			{
				_onPointerEnter.AddListener(value);
			}
			remove
			{
				_onPointerEnter.RemoveListener(value);
			}
		}

		public event UnityAction<PointerEventData> PointerExitEvent
		{
			add
			{
				_onPointerExit.AddListener(value);
			}
			remove
			{
				_onPointerExit.RemoveListener(value);
			}
		}

		public event UnityAction<PointerEventData> BeginDragEvent
		{
			add
			{
				_onBeginDrag.AddListener(value);
			}
			remove
			{
				_onBeginDrag.RemoveListener(value);
			}
		}

		public event UnityAction<PointerEventData> DragEvent
		{
			add
			{
				_onDrag.AddListener(value);
			}
			remove
			{
				_onDrag.RemoveListener(value);
			}
		}

		public event UnityAction<PointerEventData> EndDragEvent
		{
			add
			{
				_onEndDrag.AddListener(value);
			}
			remove
			{
				_onEndDrag.RemoveListener(value);
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchRegion()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (Application.isPlaying && _hideAtRuntime)
			{
				base.visible = false;
			}
		}

		public override void ClearValue()
		{
		}

		internal void xEHpCTaMhjWDQaGwDmrFNuzLgIPd()
		{
		}

		internal void IYhgjWJdAevcTFhcnhmEEhhdXCQiB(PointerEventData P_0)
		{
			base.OnPointerDown(P_0);
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && uJoHaltMSUUnfllDSTBAVKDBdyfiA() && IsInteractable() && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && _onPointerDown != null)
			{
				_onPointerDown.Invoke(P_0);
			}
		}

		internal void onOQXRYBwLJBRZotCkReerIoKHVe(PointerEventData P_0)
		{
			base.OnPointerUp(P_0);
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && uJoHaltMSUUnfllDSTBAVKDBdyfiA() && IsInteractable() && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && _onPointerUp != null)
			{
				_onPointerUp.Invoke(P_0);
			}
		}

		internal void TEWnYjNSCCUfyvdCLYEAHRMonHVJ(PointerEventData P_0)
		{
			base.OnPointerEnter(P_0);
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && uJoHaltMSUUnfllDSTBAVKDBdyfiA() && IsInteractable() && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && _onPointerEnter != null)
			{
				_onPointerEnter.Invoke(P_0);
			}
		}

		internal void nrscHvUeiROBigpUoqpBEpqWzMcU(PointerEventData P_0)
		{
			base.OnPointerExit(P_0);
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && uJoHaltMSUUnfllDSTBAVKDBdyfiA() && IsInteractable() && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && _onPointerExit != null)
			{
				_onPointerExit.Invoke(P_0);
			}
		}

		internal void jtEgHxFvFWVrZFPulMmKBLEUYbfqA(PointerEventData P_0)
		{
			base.OnBeginDrag(P_0);
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && uJoHaltMSUUnfllDSTBAVKDBdyfiA() && IsInteractable() && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && _onBeginDrag != null)
			{
				_onBeginDrag.Invoke(P_0);
			}
		}

		internal void HlPGRCwvwcfsHxbIvWTiERwkbFMH(PointerEventData P_0)
		{
			base.OnDrag(P_0);
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && uJoHaltMSUUnfllDSTBAVKDBdyfiA() && IsInteractable() && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && _onDrag != null)
			{
				_onDrag.Invoke(P_0);
			}
		}

		internal void jYTbLnHAGqpHgEOECxEipyixHUZaA(PointerEventData P_0)
		{
			base.OnEndDrag(P_0);
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA && uJoHaltMSUUnfllDSTBAVKDBdyfiA() && IsInteractable() && TouchInteractable.spiXVMFIlBSTcziexAbPyTVYaaFU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && _onEndDrag != null)
			{
				_onEndDrag.Invoke(P_0);
			}
		}
	}
}
