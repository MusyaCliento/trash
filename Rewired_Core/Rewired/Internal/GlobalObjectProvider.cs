using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Internal
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class GlobalObjectProvider
	{
		public delegate bool ObjectProvider(object arg1, object arg2, out object result);

		private class vCvgMzEkwWpyWTemFxEizTEZFZgDA
		{
			private readonly Dictionary<string, List<ObjectProvider>> HGeVLLfxnywvypBiraPjkjkLaZqVA;

			public vCvgMzEkwWpyWTemFxEizTEZFZgDA()
			{
				HGeVLLfxnywvypBiraPjkjkLaZqVA = new Dictionary<string, List<ObjectProvider>>();
			}

			public bool UzLhlhmVLkvMjrZFhosKYtCLFem(string P_0, ObjectProvider P_1)
			{
				if (string.IsNullOrEmpty(P_0))
				{
					throw new ArgumentNullException("key");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("objectProvider");
				}
				if (!HGeVLLfxnywvypBiraPjkjkLaZqVA.TryGetValue(P_0, out var value))
				{
					value = new List<ObjectProvider>();
					HGeVLLfxnywvypBiraPjkjkLaZqVA.Add(P_0, value);
				}
				if (value.Contains(P_1))
				{
					return false;
				}
				value.Add(P_1);
				return true;
			}

			public bool nsSKrAntTPrUDhShgBngHfcSnsaYA(string P_0, ObjectProvider P_1)
			{
				if (string.IsNullOrEmpty(P_0))
				{
					return false;
				}
				if (P_1 == null)
				{
					return false;
				}
				if (!HGeVLLfxnywvypBiraPjkjkLaZqVA.TryGetValue(P_0, out var value))
				{
					return false;
				}
				return value.Remove(P_1);
			}

			public bool XerERSgciTGNiuLCUOtsmirSJmgt<_0001>(string P_0, object P_1, object P_2, out _0001 P_3) where _0001 : class
			{
				P_3 = null;
				if (!HGeVLLfxnywvypBiraPjkjkLaZqVA.TryGetValue(P_0, out var value))
				{
					return false;
				}
				int count = value.Count;
				for (int i = 0; i < count; i++)
				{
					try
					{
						if (value[i](P_1, P_2, out var result))
						{
							P_3 = result as _0001;
							return P_3 != null;
						}
					}
					catch (Exception ex)
					{
						Logger.LogError("Exception thrown in object provider callback.\n" + ex);
					}
				}
				return false;
			}
		}

		public const string key_createUnityInputManagerProxy = "createUnityInputManagerProxy";

		public const string key_createInputSource = "createInputSource";

		public const string key_createElementIdentifierTool = "createElementIdentifierTool";

		private static vCvgMzEkwWpyWTemFxEizTEZFZgDA hEOZayHuMeTnkOQPaiJjzVyYLgyc;

		private static vCvgMzEkwWpyWTemFxEizTEZFZgDA DHrCJYUmqybbPjMtyiKNFjqlmGLS
		{
			get
			{
				if (hEOZayHuMeTnkOQPaiJjzVyYLgyc == null)
				{
					hEOZayHuMeTnkOQPaiJjzVyYLgyc = new vCvgMzEkwWpyWTemFxEizTEZFZgDA();
				}
				return hEOZayHuMeTnkOQPaiJjzVyYLgyc;
			}
		}

		public static bool Register(string key, ObjectProvider provider)
		{
			return DHrCJYUmqybbPjMtyiKNFjqlmGLS.UzLhlhmVLkvMjrZFhosKYtCLFem(key, provider);
		}

		public static bool Unregister(string key, ObjectProvider provider)
		{
			return DHrCJYUmqybbPjMtyiKNFjqlmGLS.nsSKrAntTPrUDhShgBngHfcSnsaYA(key, provider);
		}

		public static bool TryGetObject<T>(string key, object arg1, object arg2, out T result) where T : class
		{
			return DHrCJYUmqybbPjMtyiKNFjqlmGLS.XerERSgciTGNiuLCUOtsmirSJmgt<T>(key, arg1, arg2, out result);
		}
	}
}
