using System;
using System.Collections.Generic;
using Coffee.UISoftMaskInternal;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	[ExecuteAlways]
	public class SoftMaskable : MonoBehaviour, IMaterialModifier, IMaskable
	{
		private static readonly int s_AllowDynamicResolution = Shader.PropertyToID("_AllowDynamicResolution");

		private static readonly int s_AllowRenderScale = Shader.PropertyToID("_AllowRenderScale");

		private static readonly int s_SoftMaskingPower = Shader.PropertyToID("_SoftMaskingPower");

		private const float k_PowerMin = 1f;

		private const float k_PowerMax = 5f;

		[Tooltip("The graphic is ignored when soft-masking.")]
		[SerializeField]
		private bool m_IgnoreSelf;

		[Tooltip("The child graphics are ignored when soft-masking.")]
		[SerializeField]
		private bool m_IgnoreChildren;

		[Tooltip("Soft masking power.\nThe higher this value, the faster it becomes transparent.\nIf overlapping objects appear see-through, please adjust this value.")]
		[SerializeField]
		[Range(1f, 5f)]
		private float m_Power = 1f;

		private Action _checkGraphic;

		private MaskableGraphic _graphic;

		private Material _maskableMaterial;

		private bool _shouldRecalculateStencil;

		private Mask _mask;

		private SoftMask _softMask;

		private int _softMaskDepth;

		private int _stencilBits;

		public bool ignoreSelf
		{
			get
			{
				return m_IgnoreSelf;
			}
			set
			{
				if (m_IgnoreSelf != value)
				{
					m_IgnoreSelf = value;
					UpdateHideFlags();
					SetMaterialDirty();
				}
			}
		}

		public bool ignoreChildren
		{
			get
			{
				return m_IgnoreChildren;
			}
			set
			{
				if (m_IgnoreChildren != value)
				{
					m_IgnoreChildren = value;
					UpdateHideFlags();
					SetMaterialDirtyForChildren();
				}
			}
		}

		public bool ignored
		{
			get
			{
				if (m_IgnoreSelf)
				{
					return true;
				}
				RecalculateStencilIfNeeded();
				if (!_softMask || !_softMask.isActiveAndEnabled)
				{
					return true;
				}
				Transform parent = base.transform.parent;
				while ((bool)parent)
				{
					if (parent.TryGetComponent<SoftMaskable>(out var component) && component.ignoreChildren)
					{
						return true;
					}
					parent = parent.parent;
				}
				return false;
			}
		}

		public float power
		{
			get
			{
				return m_Power;
			}
			set
			{
				value = Mathf.Clamp(value, 1f, 5f);
				if (!Mathf.Approximately(m_Power, value))
				{
					m_Power = value;
					SetMaterialDirty();
				}
			}
		}

		private bool isTerminal => _graphic is TerminalMaskingShape;

		private void OnEnable()
		{
			UpdateHideFlags();
			this.AddComponentOnChildren<SoftMaskable>(includeSelf: false);
			_shouldRecalculateStencil = true;
			if (TryGetComponent<MaskableGraphic>(out _graphic))
			{
				List<Component> toRelease = InternalListPool<Component>.Rent();
				GetComponents(toRelease);
				int num = toRelease.IndexOf(_graphic);
				int num2 = toRelease.IndexOf(this);
				InternalListPool<Component>.Return(ref toRelease);
				if (num2 < num)
				{
					base.gameObject.AddComponent<SoftMaskable>();
					Misc.Destroy(this);
				}
				else
				{
					_graphic.SetMaterialDirty();
				}
			}
			else
			{
				UIExtraCallbacks.onBeforeCanvasRebuild += CheckGraphic;
			}
		}

		private void OnDisable()
		{
			UIExtraCallbacks.onBeforeCanvasRebuild -= CheckGraphic;
			if ((bool)_graphic)
			{
				_graphic.SetMaterialDirty();
			}
			_graphic = null;
			_mask = null;
			_softMask = null;
			MaterialRepository.Release(ref _maskableMaterial);
		}

		private void OnDestroy()
		{
			_graphic = null;
			_maskableMaterial = null;
			_mask = null;
			_softMask = null;
			_checkGraphic = null;
		}

		private void OnTransformChildrenChanged()
		{
			this.AddComponentOnChildren<SoftMaskable>(includeSelf: false);
		}

		private void OnTransformParentChanged()
		{
			_shouldRecalculateStencil = true;
		}

		void IMaskable.RecalculateMasking()
		{
			_shouldRecalculateStencil = true;
		}

		Material IMaterialModifier.GetModifiedMaterial(Material baseMaterial)
		{
			if (!UISoftMaskProjectSettings.softMaskEnabled)
			{
				MaterialRepository.Release(ref _maskableMaterial);
				return baseMaterial;
			}
			if (!base.isActiveAndEnabled || !_graphic || !_graphic.canvas || !_graphic.maskable || isTerminal || baseMaterial == null || ignored)
			{
				MaterialRepository.Release(ref _maskableMaterial);
				return baseMaterial;
			}
			RecalculateStencilIfNeeded();
			int num = (_softMask ? _softMask.softMaskDepth : (-1));
			if (num < 0 || 4 <= num)
			{
				_softMaskDepth = -1;
				MaterialRepository.Release(ref _maskableMaterial);
				return baseMaterial;
			}
			_softMaskDepth = num;
			if (0 <= _softMaskDepth && _softMask == _mask && _softMask.SoftMaskingEnabled() && TryGetComponent<MaskingShape>(out var component) && component.isActiveAndEnabled && component.maskingMethod == MaskingShape.MaskingMethod.Subtract)
			{
				_softMaskDepth--;
			}
			bool flag = UISoftMaskProjectSettings.stereoEnabled && _graphic.canvas.IsStereoCanvas();
			bool useStencilOutsideScreen = UISoftMaskProjectSettings.useStencilOutsideScreen;
			uint u32_ = (uint)(Mathf.InverseLerp(1f, 5f, power) * 1024f);
			MaterialRepository.Get(new Hash128((uint)baseMaterial.GetInstanceID(), (uint)_softMask.softMaskBuffer.GetInstanceID(), (uint)(_stencilBits + (flag ? 256 : 0) + (useStencilOutsideScreen ? 512 : 0) + (_softMaskDepth << 10)), u32_), ref _maskableMaterial, ((Material baseMaterial, RenderTexture softMaskBuffer, int _softMaskDepth, int _stencilBits, bool isStereo) x) => SoftMaskUtils.CreateSoftMaskable(x.baseMaterial, x.softMaskBuffer, x._softMaskDepth, x._stencilBits, x.isStereo), (baseMaterial, _softMask.softMaskBuffer, _softMaskDepth, _stencilBits, flag));
			_maskableMaterial.SetInt(s_AllowDynamicResolution, _softMask.allowDynamicResolution ? 1 : 0);
			_maskableMaterial.SetInt(s_AllowRenderScale, _softMask.allowRenderScale ? 1 : 0);
			_maskableMaterial.SetFloat(s_SoftMaskingPower, power);
			return _maskableMaterial;
		}

		private void RecalculateStencilIfNeeded()
		{
			if (!base.isActiveAndEnabled)
			{
				_softMask = null;
				_stencilBits = 0;
			}
			else if (_shouldRecalculateStencil)
			{
				_shouldRecalculateStencil = false;
				bool useStencilOutsideScreen = UISoftMaskProjectSettings.useStencilOutsideScreen;
				_stencilBits = Utils.GetStencilBits(base.transform, includeSelf: false, useStencilOutsideScreen, out _mask, out _softMask);
			}
		}

		private void CheckGraphic()
		{
			if (!_graphic && TryGetComponent<MaskableGraphic>(out _graphic))
			{
				UIExtraCallbacks.onBeforeCanvasRebuild -= CheckGraphic;
				base.gameObject.AddComponent<SoftMaskable>();
				Misc.Destroy(this);
			}
		}

		public void SetMaterialDirty()
		{
			if (base.isActiveAndEnabled && (bool)_graphic)
			{
				_graphic.SetMaterialDirty();
			}
		}

		public void SetMaterialDirtyForChildren()
		{
			if (!base.isActiveAndEnabled || !_graphic)
			{
				return;
			}
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				if (base.transform.GetChild(i).TryGetComponent<SoftMaskable>(out var component))
				{
					component.SetMaterialDirty();
					component.SetMaterialDirtyForChildren();
				}
			}
		}

		private void UpdateHideFlags()
		{
			base.hideFlags = ((!ignoreSelf && !ignoreChildren && Mathf.Approximately(power, 1f)) ? HideFlags.DontSave : HideFlags.None);
		}
	}
}
