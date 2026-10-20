using System.Collections.Generic;
using Coffee.UISoftMaskInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

namespace Coffee.UISoftMask
{
	public class UISoftMaskProjectSettings : PreloadedProjectSettings<UISoftMaskProjectSettings>
	{
		private static bool s_UseStereoMock;

		[Header("Setting")]
		[Tooltip("Enable SoftMask globally.")]
		[SerializeField]
		internal bool m_SoftMaskEnabled = true;

		[Tooltip("Enable stereo rendering for VR devices.")]
		[SerializeField]
		private bool m_StereoEnabled = true;

		[Tooltip("Sensitivity of transform that automatically rebuilds the soft mask buffer.")]
		[SerializeField]
		private TransformSensitivity m_TransformSensitivity = TransformSensitivity.Medium;

		[Header("Editor")]
		[Tooltip("Hide the automatically generated components.\n  - MaskingShapeContainer\n  - TerminalMaskingShape")]
		[SerializeField]
		private bool m_HideGeneratedComponents = true;

		[HideInInspector]
		[SerializeField]
		private ShaderVariantRegistry m_ShaderVariantRegistry = new ShaderVariantRegistry();

		public static ShaderVariantRegistry shaderRegistry => PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_ShaderVariantRegistry;

		public static ShaderVariantCollection shaderVariantCollection => shaderRegistry.shaderVariantCollection;

		public static bool softMaskEnabled => PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_SoftMaskEnabled;

		public static bool useStencilOutsideScreen => true;

		public static bool stereoEnabled
		{
			get
			{
				if (softMaskEnabled && PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_StereoEnabled)
				{
					return XRSettings.enabled;
				}
				return false;
			}
		}

		public static HideFlags hideFlagsForTemp
		{
			get
			{
				if (!PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_HideGeneratedComponents)
				{
					return HideFlags.DontSave | HideFlags.NotEditable;
				}
				return HideFlags.HideAndDontSave | HideFlags.HideInInspector;
			}
		}

		public static TransformSensitivity transformSensitivity
		{
			get
			{
				return PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_TransformSensitivity;
			}
			set
			{
				PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_TransformSensitivity = value;
			}
		}

		public static bool useStereoMock
		{
			get
			{
				return s_UseStereoMock;
			}
			set
			{
				if (s_UseStereoMock != value)
				{
					s_UseStereoMock = value;
					ResetAllSoftMasks();
				}
			}
		}

		private static void ResetAllSoftMasks()
		{
			List<SoftMask> toRelease = InternalListPool<SoftMask>.Rent();
			List<IMaskable> toRelease2 = InternalListPool<IMaskable>.Rent();
			SoftMask[] array = Misc.FindObjectsOfType<SoftMask>();
			foreach (SoftMask softMask in array)
			{
				if (!softMask.gameObject.scene.isLoaded)
				{
					continue;
				}
				softMask.GetComponentsInParent(includeInactive: true, toRelease);
				if (1 >= toRelease.Count)
				{
					softMask.GetComponentsInChildren(includeInactive: true, toRelease2);
					toRelease2.ForEach(delegate(IMaskable c)
					{
						c.RecalculateMasking();
					});
				}
			}
			InternalListPool<IMaskable>.Return(ref toRelease2);
			InternalListPool<SoftMask>.Return(ref toRelease);
		}
	}
}
