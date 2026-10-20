using System.ComponentModel;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Internal
{
	[AddComponentMenu("")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GUIText : MonoBehaviour
	{
		private string lHQqjdgitIcRGsMimBalYjUTMSrc;

		private GUIStyle uTENTWYFXpWDNOnmZPUQXGOtlrwN;

		private TextAnchor LXhaRReIchcMzILvVMaSgqWolOvK;

		private TextAlignment KkZCwMtxItUuaAcKnbYKbdpVZwOMA;

		private float ubQRZTfKZfkdWaeMkQcwmhWNFXUbA;

		private Font KBdvlOnjUPFcJZIRuRPNRNDguuGh;

		private int pFhTjjThqpLHNKZGfsRnCLMgkkRK = -1;

		private FontStyle diexbpuasLNfKSEzaoqhBQuphZJP;

		private Color yfitdfNruuueGzLCpeCAfLsRlRPm = Color.white;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Vector2 _pixelOffset;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useUnityUI;

		private bool kewKuNFLlxyIgNOrgrbgLuEeUkvU;

		private bool nuogcUVYNoSaBOtyryUUlNugtLLc;

		private bool FJhwdphZaqdDkMFmcRdZOFUVnWIG;

		private bool PwOwXuPgnBGbQvkBxzWQNxSgXAqe;

		private bool YlrtssUYpOqtFCPaciCeTuaNPAiu;

		private Text lKulGuoqDnICTmvbetDFZRTDOvXq;

		private bool zwGkloOejkdrmdiqMruZocjIiHhK;

		private bool ZvKfOseMpQjFkdkIBMtKCdSSLGh;

		public string text
		{
			get
			{
				return lHQqjdgitIcRGsMimBalYjUTMSrc;
			}
			set
			{
				lHQqjdgitIcRGsMimBalYjUTMSrc = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return LXhaRReIchcMzILvVMaSgqWolOvK;
			}
			set
			{
				LXhaRReIchcMzILvVMaSgqWolOvK = value;
				kewKuNFLlxyIgNOrgrbgLuEeUkvU = true;
				if (uTENTWYFXpWDNOnmZPUQXGOtlrwN != null)
				{
					uTENTWYFXpWDNOnmZPUQXGOtlrwN.alignment = value;
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return KkZCwMtxItUuaAcKnbYKbdpVZwOMA;
			}
			set
			{
				KkZCwMtxItUuaAcKnbYKbdpVZwOMA = value;
			}
		}

		public float lineSpacing
		{
			get
			{
				return ubQRZTfKZfkdWaeMkQcwmhWNFXUbA;
			}
			set
			{
				ubQRZTfKZfkdWaeMkQcwmhWNFXUbA = value;
				_ = uTENTWYFXpWDNOnmZPUQXGOtlrwN;
			}
		}

		public Font font
		{
			get
			{
				return KBdvlOnjUPFcJZIRuRPNRNDguuGh;
			}
			set
			{
				nuogcUVYNoSaBOtyryUUlNugtLLc = true;
				KBdvlOnjUPFcJZIRuRPNRNDguuGh = value;
				if (uTENTWYFXpWDNOnmZPUQXGOtlrwN != null)
				{
					uTENTWYFXpWDNOnmZPUQXGOtlrwN.font = value;
				}
			}
		}

		public int fontSize
		{
			get
			{
				return pFhTjjThqpLHNKZGfsRnCLMgkkRK;
			}
			set
			{
				pFhTjjThqpLHNKZGfsRnCLMgkkRK = value;
				FJhwdphZaqdDkMFmcRdZOFUVnWIG = true;
				if (uTENTWYFXpWDNOnmZPUQXGOtlrwN != null)
				{
					uTENTWYFXpWDNOnmZPUQXGOtlrwN.fontSize = value;
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return diexbpuasLNfKSEzaoqhBQuphZJP;
			}
			set
			{
				diexbpuasLNfKSEzaoqhBQuphZJP = value;
				PwOwXuPgnBGbQvkBxzWQNxSgXAqe = true;
				if (uTENTWYFXpWDNOnmZPUQXGOtlrwN != null)
				{
					uTENTWYFXpWDNOnmZPUQXGOtlrwN.fontStyle = value;
				}
			}
		}

		public Color color
		{
			get
			{
				return yfitdfNruuueGzLCpeCAfLsRlRPm;
			}
			set
			{
				yfitdfNruuueGzLCpeCAfLsRlRPm = value;
				YlrtssUYpOqtFCPaciCeTuaNPAiu = true;
				if (uTENTWYFXpWDNOnmZPUQXGOtlrwN != null)
				{
					uTENTWYFXpWDNOnmZPUQXGOtlrwN.normal.textColor = value;
				}
			}
		}

		public Vector2 pixelOffset
		{
			get
			{
				return _pixelOffset;
			}
			set
			{
				_pixelOffset = value;
			}
		}

		public bool useUnityUI
		{
			get
			{
				return _useUnityUI;
			}
			set
			{
				if (_useUnityUI != value)
				{
					_useUnityUI = value;
					zwGkloOejkdrmdiqMruZocjIiHhK = value;
					if (value)
					{
						DZAcbwkXRuzUzlenyPQwEoRkhUXz();
					}
					else
					{
						YbCmyCOLHfPJDFSlkvJOTZCMGqNq();
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			ZvKfOseMpQjFkdkIBMtKCdSSLGh = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			zwGkloOejkdrmdiqMruZocjIiHhK = _useUnityUI;
			if (_useUnityUI)
			{
				DZAcbwkXRuzUzlenyPQwEoRkhUXz();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!_useUnityUI)
			{
				if (uTENTWYFXpWDNOnmZPUQXGOtlrwN == null)
				{
					HAqwhjtxBnEiBwSGbPkjZJTnwZKC();
				}
				if (!string.IsNullOrEmpty(lHQqjdgitIcRGsMimBalYjUTMSrc))
				{
					Vector2 vector = base.transform.localPosition;
					GUI.Label(new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue)), lHQqjdgitIcRGsMimBalYjUTMSrc, uTENTWYFXpWDNOnmZPUQXGOtlrwN);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			if (!_useUnityUI)
			{
				return;
			}
			if (lKulGuoqDnICTmvbetDFZRTDOvXq == null)
			{
				Logger.LogError("Text component has been deleted.");
				return;
			}
			RectTransform component = lKulGuoqDnICTmvbetDFZRTDOvXq.GetComponent<RectTransform>();
			if (component.anchoredPosition != _pixelOffset)
			{
				component.anchoredPosition = _pixelOffset;
			}
			lKulGuoqDnICTmvbetDFZRTDOvXq.text = lHQqjdgitIcRGsMimBalYjUTMSrc;
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (ZvKfOseMpQjFkdkIBMtKCdSSLGh && _useUnityUI != zwGkloOejkdrmdiqMruZocjIiHhK)
			{
				zwGkloOejkdrmdiqMruZocjIiHhK = _useUnityUI;
				if (_useUnityUI)
				{
					DZAcbwkXRuzUzlenyPQwEoRkhUXz();
				}
				else
				{
					YbCmyCOLHfPJDFSlkvJOTZCMGqNq();
				}
			}
		}

		private void DZAcbwkXRuzUzlenyPQwEoRkhUXz()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (UnityTools.GetComponentInSelfOrParents<Canvas>(base.transform) == null)
			{
				GameObject gameObject;
				if (base.transform.root == base.transform)
				{
					gameObject = new GameObject("Canvas");
					base.transform.SetParent(gameObject.transform, worldPositionStays: true);
				}
				else
				{
					gameObject = base.transform.root.gameObject;
				}
				gameObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
				if (!(gameObject.GetComponent<CanvasScaler>() != null))
				{
					gameObject.AddComponent<CanvasScaler>();
				}
				else
				{
					gameObject.GetComponent<CanvasScaler>();
				}
			}
			lKulGuoqDnICTmvbetDFZRTDOvXq = GetComponent<Text>();
			if (!(lKulGuoqDnICTmvbetDFZRTDOvXq == null))
			{
				return;
			}
			RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
			rectTransform.anchorMax = new Vector2(1f, 1f);
			rectTransform.anchorMin = new Vector2(0f, 0f);
			rectTransform.localPosition = Vector2.zero;
			rectTransform.anchoredPosition = Vector2.zero;
			rectTransform.sizeDelta = Vector3.zero;
			lKulGuoqDnICTmvbetDFZRTDOvXq = base.gameObject.AddComponent<Text>();
			lKulGuoqDnICTmvbetDFZRTDOvXq.color = Color.white;
			if (_useUnityUI)
			{
				try
				{
					lKulGuoqDnICTmvbetDFZRTDOvXq.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				}
				catch
				{
					try
					{
						lKulGuoqDnICTmvbetDFZRTDOvXq.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
					}
					catch
					{
						Logger.LogError("No default font found for GUIText.");
					}
				}
			}
			lKulGuoqDnICTmvbetDFZRTDOvXq.fontSize = 13;
			if (kewKuNFLlxyIgNOrgrbgLuEeUkvU)
			{
				lKulGuoqDnICTmvbetDFZRTDOvXq.alignment = LXhaRReIchcMzILvVMaSgqWolOvK;
			}
			else
			{
				LXhaRReIchcMzILvVMaSgqWolOvK = lKulGuoqDnICTmvbetDFZRTDOvXq.alignment;
			}
			if (nuogcUVYNoSaBOtyryUUlNugtLLc)
			{
				lKulGuoqDnICTmvbetDFZRTDOvXq.font = KBdvlOnjUPFcJZIRuRPNRNDguuGh;
			}
			else
			{
				KBdvlOnjUPFcJZIRuRPNRNDguuGh = lKulGuoqDnICTmvbetDFZRTDOvXq.font;
			}
			if (FJhwdphZaqdDkMFmcRdZOFUVnWIG)
			{
				lKulGuoqDnICTmvbetDFZRTDOvXq.fontSize = pFhTjjThqpLHNKZGfsRnCLMgkkRK;
			}
			else
			{
				pFhTjjThqpLHNKZGfsRnCLMgkkRK = lKulGuoqDnICTmvbetDFZRTDOvXq.fontSize;
			}
			if (PwOwXuPgnBGbQvkBxzWQNxSgXAqe)
			{
				lKulGuoqDnICTmvbetDFZRTDOvXq.fontStyle = diexbpuasLNfKSEzaoqhBQuphZJP;
			}
			else
			{
				diexbpuasLNfKSEzaoqhBQuphZJP = lKulGuoqDnICTmvbetDFZRTDOvXq.fontStyle;
			}
			if (YlrtssUYpOqtFCPaciCeTuaNPAiu)
			{
				lKulGuoqDnICTmvbetDFZRTDOvXq.color = yfitdfNruuueGzLCpeCAfLsRlRPm;
			}
			else
			{
				yfitdfNruuueGzLCpeCAfLsRlRPm = lKulGuoqDnICTmvbetDFZRTDOvXq.color;
			}
		}

		private void YbCmyCOLHfPJDFSlkvJOTZCMGqNq()
		{
			if (Application.isPlaying)
			{
				if (lKulGuoqDnICTmvbetDFZRTDOvXq != null)
				{
					lKulGuoqDnICTmvbetDFZRTDOvXq.text = string.Empty;
				}
				lKulGuoqDnICTmvbetDFZRTDOvXq = null;
			}
		}

		private void HAqwhjtxBnEiBwSGbPkjZJTnwZKC()
		{
			uTENTWYFXpWDNOnmZPUQXGOtlrwN = new GUIStyle(GUI.skin.label);
			if (kewKuNFLlxyIgNOrgrbgLuEeUkvU)
			{
				uTENTWYFXpWDNOnmZPUQXGOtlrwN.alignment = LXhaRReIchcMzILvVMaSgqWolOvK;
			}
			else
			{
				LXhaRReIchcMzILvVMaSgqWolOvK = uTENTWYFXpWDNOnmZPUQXGOtlrwN.alignment;
			}
			if (nuogcUVYNoSaBOtyryUUlNugtLLc)
			{
				uTENTWYFXpWDNOnmZPUQXGOtlrwN.font = KBdvlOnjUPFcJZIRuRPNRNDguuGh;
			}
			else
			{
				KBdvlOnjUPFcJZIRuRPNRNDguuGh = uTENTWYFXpWDNOnmZPUQXGOtlrwN.font;
			}
			if (FJhwdphZaqdDkMFmcRdZOFUVnWIG)
			{
				uTENTWYFXpWDNOnmZPUQXGOtlrwN.fontSize = pFhTjjThqpLHNKZGfsRnCLMgkkRK;
			}
			else
			{
				pFhTjjThqpLHNKZGfsRnCLMgkkRK = uTENTWYFXpWDNOnmZPUQXGOtlrwN.fontSize;
			}
			if (PwOwXuPgnBGbQvkBxzWQNxSgXAqe)
			{
				uTENTWYFXpWDNOnmZPUQXGOtlrwN.fontStyle = diexbpuasLNfKSEzaoqhBQuphZJP;
			}
			else
			{
				diexbpuasLNfKSEzaoqhBQuphZJP = uTENTWYFXpWDNOnmZPUQXGOtlrwN.fontStyle;
			}
			if (YlrtssUYpOqtFCPaciCeTuaNPAiu)
			{
				uTENTWYFXpWDNOnmZPUQXGOtlrwN.normal.textColor = yfitdfNruuueGzLCpeCAfLsRlRPm;
			}
			else
			{
				yfitdfNruuueGzLCpeCAfLsRlRPm = uTENTWYFXpWDNOnmZPUQXGOtlrwN.normal.textColor;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static GUIText GetOrAddComponent(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return null;
			}
			GUIText gUIText = gameObject.GetComponent<GUIText>();
			if (gUIText == null)
			{
				gUIText = gameObject.AddComponent<GUIText>();
			}
			return gUIText;
		}

		[CustomObfuscation(rename = false)]
		internal static GUIText CreateLogger(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return null;
			}
			GUIText orAddComponent = GetOrAddComponent(gameObject);
			orAddComponent.anchor = TextAnchor.LowerLeft;
			return orAddComponent;
		}
	}
}
