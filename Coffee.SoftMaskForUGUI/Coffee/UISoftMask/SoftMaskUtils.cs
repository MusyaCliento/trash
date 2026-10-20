using System.Collections.Generic;
using Coffee.UISoftMaskInternal;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Coffee.UISoftMask
{
	internal static class SoftMaskUtils
	{
		public static readonly InternalObjectPool<CommandBuffer> commandBufferPool = new InternalObjectPool<CommandBuffer>(() => new CommandBuffer(), (CommandBuffer x) => x != null, delegate(CommandBuffer x)
		{
			x.Clear();
		});

		public static readonly InternalObjectPool<MaterialPropertyBlock> materialPropertyBlockPool = new InternalObjectPool<MaterialPropertyBlock>(() => new MaterialPropertyBlock(), (MaterialPropertyBlock x) => x != null, delegate(MaterialPropertyBlock x)
		{
			x.Clear();
		});

		private static Material s_SoftMaskingMaterialAdd;

		private static Material s_SoftMaskingMaterialSub;

		private static readonly int s_SoftMaskableStereo = Shader.PropertyToID("_SoftMaskableStereo");

		private static readonly int s_SoftMaskOutsideColor = Shader.PropertyToID("_SoftMaskOutsideColor");

		private static readonly int s_SoftMaskTex = Shader.PropertyToID("_SoftMaskTex");

		private static readonly int s_SoftMaskColor = Shader.PropertyToID("_SoftMaskColor");

		private static readonly int s_MainTex = Shader.PropertyToID("_MainTex");

		private static readonly int s_ColorMask = Shader.PropertyToID("_ColorMask");

		private static readonly int s_BlendOp = Shader.PropertyToID("_BlendOp");

		private static readonly int s_ThresholdMin = Shader.PropertyToID("_ThresholdMin");

		private static readonly int s_ThresholdMax = Shader.PropertyToID("_ThresholdMax");

		private static readonly int s_RenderScale = Shader.PropertyToID("_RenderScale");

		private static readonly int s_DynamicResolutionScale = Shader.PropertyToID("_DynamicResolutionScale");

		private static float s_CurrentRenderScale = 1f;

		private static Vector2 s_CurrentDynamicResolutionScale = Vector2.one;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeOnLoadMethod()
		{
			s_CurrentRenderScale = 1f;
			Shader.SetGlobalFloat(s_RenderScale, s_CurrentRenderScale);
			UIExtraCallbacks.onBeforeCanvasRebuild += delegate
			{
				Vector2 vector = new Vector2(ScalableBufferManager.widthScaleFactor, ScalableBufferManager.heightScaleFactor);
				vector.x = Mathf.Clamp((float)Mathf.CeilToInt(vector.x / 0.05f) * 0.05f, 0.25f, 1f);
				vector.y = Mathf.Clamp((float)Mathf.CeilToInt(vector.y / 0.05f) * 0.05f, 0.25f, 1f);
				if (s_CurrentDynamicResolutionScale != vector)
				{
					s_CurrentDynamicResolutionScale = vector;
					Shader.SetGlobalVector(s_DynamicResolutionScale, s_CurrentDynamicResolutionScale);
				}
			};
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(UpdateMeshUI);
		}

		public static void UpdateMeshUI(Object obj)
		{
			if (obj is TextMeshProUGUI textMeshProUGUI)
			{
				MaskingShape component2;
				if (textMeshProUGUI.TryGetComponent<SoftMask>(out var component))
				{
					UpdateSubMeshUI(textMeshProUGUI, component.enabled, component.showMaskGraphic, component.antiAliasingThreshold, component.softnessRange, MaskingShape.MaskingMethod.Additive);
				}
				else if (textMeshProUGUI.TryGetComponent<MaskingShape>(out component2))
				{
					component2.UpdateMesh(textMeshProUGUI.mesh);
					UpdateSubMeshUI(textMeshProUGUI, component2.enabled, component2.showMaskGraphic, component2.antiAliasingThreshold, component2.softnessRange, component2.maskingMethod);
				}
			}
		}

		private static void UpdateSubMeshUI(TextMeshProUGUI text, bool enabled, bool show, float aa, MinMax01 softness, MaskingShape.MaskingMethod method)
		{
			List<TMP_SubMeshUI> toRelease = InternalListPool<TMP_SubMeshUI>.Rent();
			text.GetComponentsInChildren(toRelease, 1);
			for (int i = 0; i < toRelease.Count; i++)
			{
				MaskingShape orAddComponent = toRelease[i].GetOrAddComponent<MaskingShape>();
				orAddComponent.hideFlags = HideFlags.NotEditable;
				orAddComponent.enabled = enabled;
				orAddComponent.maskingMethod = method;
				orAddComponent.antiAliasingThreshold = aa;
				orAddComponent.softnessRange = softness;
				orAddComponent.showMaskGraphic = show;
				orAddComponent.UpdateMesh(toRelease[i].mesh);
			}
			InternalListPool<TMP_SubMeshUI>.Return(ref toRelease);
		}

		public static void ApplyMaterialPropertyBlock(MaterialPropertyBlock mpb, int depth, Texture texture, MinMax01 threshold, float alpha)
		{
			Vector4 zero = Vector4.zero;
			zero[depth] = alpha;
			mpb.SetVector(s_ColorMask, zero);
			mpb.SetTexture(s_MainTex, texture ? texture : null);
			mpb.SetFloat(s_ThresholdMin, threshold.min);
			mpb.SetFloat(s_ThresholdMax, threshold.max);
		}

		public static Material GetSoftMaskingMaterial(MaskingShape.MaskingMethod method)
		{
			if (method != MaskingShape.MaskingMethod.Additive)
			{
				return GetSoftMaskingMaterial(ref s_SoftMaskingMaterialSub, BlendOp.ReverseSubtract);
			}
			return GetSoftMaskingMaterial(ref s_SoftMaskingMaterialAdd, BlendOp.Add);
		}

		private static Material GetSoftMaskingMaterial(ref Material mat, BlendOp op)
		{
			if ((bool)mat)
			{
				return mat;
			}
			mat = new Material(Shader.Find("Hidden/UI/SoftMask"))
			{
				hideFlags = (HideFlags.DontSave | HideFlags.NotEditable)
			};
			mat.SetInt(s_BlendOp, (int)op);
			return mat;
		}

		public static Material CreateSoftMaskable(Material baseMat, Texture softMaskBuffer, int softMaskDepth, int stencilBits, bool isStereo)
		{
			Material material = new Material(baseMat);
			material.shader = UISoftMaskProjectSettings.shaderRegistry.FindOptionalShader(baseMat.shader, "(SoftMaskable)", "Hidden/{0} (SoftMaskable)", "Hidden/UI/Default (SoftMaskable)");
			material.hideFlags = HideFlags.HideAndDontSave;
			material.SetTexture(s_SoftMaskTex, softMaskBuffer);
			material.SetInt(s_SoftMaskableStereo, isStereo ? 1 : 0);
			material.SetVector(s_SoftMaskColor, new Vector4((0 <= softMaskDepth) ? 1 : 0, (1 <= softMaskDepth) ? 1 : 0, (2 <= softMaskDepth) ? 1 : 0, (3 <= softMaskDepth) ? 1 : 0));
			material.EnableKeyword("SOFTMASKABLE");
			return material;
		}
	}
}
