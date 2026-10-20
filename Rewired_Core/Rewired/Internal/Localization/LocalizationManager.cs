using System;
using System.Text;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

namespace Rewired.Internal.Localization
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class LocalizationManager
	{
		private sealed class bcCFWyIxTJsOtYiCZYacQktENwst
		{
			[Serializable]
			private sealed class bolSsbQwAPFhnSRqMVEnwNdjpzId
			{
				public static readonly bolSsbQwAPFhnSRqMVEnwNdjpzId _003C_003E9 = new bolSsbQwAPFhnSRqMVEnwNdjpzId();

				public static Action<ChutGPBICOllLFbDwaPETGCPjnpCA> _003C_003E9__7_0;

				internal void FtUwsypiThMuGKocHqcCYNscWkjf(ChutGPBICOllLFbDwaPETGCPjnpCA P_0)
				{
					P_0.Localize();
				}
			}

			private const float fSANzZBNoDWVhGcwGlLLJHMMiHAW = 60f;

			private readonly global::dKMHvtjnHwbrmeEpBMdCxcqKdkxz<ChutGPBICOllLFbDwaPETGCPjnpCA> qOrmEAhTIBbtqpdcmopnpsDntNkx;

			public bool JIIJbGvuuBBegIewPVIpmNkTgmheA;

			public ILocalizedStringProvider bFYelAPBgVpCXNBqpsKmCvKnjygN;

			public uint BwOTYArtuljGvQqzeWfOWKROvErQ;

			private Action<ChutGPBICOllLFbDwaPETGCPjnpCA> cIHJYlZnkbCfElPwcbzAvkBwsLyg = bolSsbQwAPFhnSRqMVEnwNdjpzId._003C_003E9.FtUwsypiThMuGKocHqcCYNscWkjf;

			private Id FERGxKgeGxlmAfdftOKajBQHgJKwB;

			public bcCFWyIxTJsOtYiCZYacQktENwst()
			{
				qOrmEAhTIBbtqpdcmopnpsDntNkx = new global::dKMHvtjnHwbrmeEpBMdCxcqKdkxz<ChutGPBICOllLFbDwaPETGCPjnpCA>(60f);
				BwOTYArtuljGvQqzeWfOWKROvErQ = 0u;
				FERGxKgeGxlmAfdftOKajBQHgJKwB = 1u;
			}

			public void CrAeFgsrYCiEUtBghwmJtHlQiScBA(ILocalizedStringProvider P_0)
			{
				bFYelAPBgVpCXNBqpsKmCvKnjygN = P_0;
				if (P_0 != null)
				{
					BwOTYArtuljGvQqzeWfOWKROvErQ = FERGxKgeGxlmAfdftOKajBQHgJKwB.id;
					FERGxKgeGxlmAfdftOKajBQHgJKwB.Increment();
				}
				else
				{
					BwOTYArtuljGvQqzeWfOWKROvErQ = 0u;
				}
				vqKFuciDLUSWstvoSbNmLKoDETsfb();
			}

			public void rSfIhAsbpdbmbuyhHYWtSLHsWSDf(bool P_0)
			{
				if (P_0 != JIIJbGvuuBBegIewPVIpmNkTgmheA)
				{
					JIIJbGvuuBBegIewPVIpmNkTgmheA = P_0;
					if (P_0)
					{
						srgQFJqARhSaAstJjZCRYUcyILxk();
					}
				}
			}

			public void srgQFJqARhSaAstJjZCRYUcyILxk()
			{
				if (bFYelAPBgVpCXNBqpsKmCvKnjygN != null)
				{
					qOrmEAhTIBbtqpdcmopnpsDntNkx.LqbEaGEnaEhHpJTCavQVpRSxylKt(cIHJYlZnkbCfElPwcbzAvkBwsLyg);
				}
			}

			public void OcOpkQGjdlRvVJHfGYLtVZZbkHaA()
			{
				if (bFYelAPBgVpCXNBqpsKmCvKnjygN != null)
				{
					BwOTYArtuljGvQqzeWfOWKROvErQ = FERGxKgeGxlmAfdftOKajBQHgJKwB.id;
					FERGxKgeGxlmAfdftOKajBQHgJKwB.Increment();
					if (JIIJbGvuuBBegIewPVIpmNkTgmheA)
					{
						srgQFJqARhSaAstJjZCRYUcyILxk();
					}
					else
					{
						vqKFuciDLUSWstvoSbNmLKoDETsfb();
					}
				}
			}

			public uint hqMSWYUujoWQoBsaTizWlyLEBZLn(ChutGPBICOllLFbDwaPETGCPjnpCA P_0)
			{
				return qOrmEAhTIBbtqpdcmopnpsDntNkx.OxSTHoscbMWZIVblFwqRXSsOejoG(P_0);
			}

			public bool wcqIQHUSzYSIdtKJLVSgCzQMadlA(uint P_0)
			{
				return qOrmEAhTIBbtqpdcmopnpsDntNkx.RjxcuGiHchffGTyZXnYuYpPwBJsJA(P_0);
			}

			public void vqKFuciDLUSWstvoSbNmLKoDETsfb()
			{
				qOrmEAhTIBbtqpdcmopnpsDntNkx.vgRWaCmXOzvjDsezgCKXJmOEJMjb();
			}
		}

		[CustomObfuscation(rename = false)]
		public enum GetAndUpdateLocalizedStringResultFlags
		{
			None = 0,
			Failed = 1,
			IsCachedValue = 2,
			Changed = 4,
			JustLocalized = 8
		}

		private const char hqXbUbfuGdBaiMDQkrRxgvwwZzlB = '_';

		private const char HCLwGiujxpLDoXbLxeCfkFXysOkX = '/';

		private const string gVwTNJhSrzVlsbOLQIxTzVjJlQtq = "/";

		internal const string hardwareTypeKey_universalKeyboard = "keyboard";

		internal const string hardwareTypeKey_universalMouse = "mouse";

		internal const string hardwareTypeKey_unknownController = "unknown_controller";

		internal const string localizationKeyAxisPoleSuffix_positive = "positive";

		internal const string localizationKeyAxisPoleSuffix_negative = "negative";

		internal const string localizationKeyAxisDirectionSuffix_horizontal = "horizontal";

		internal const string localizationKeyAxisDirectionSuffix_vertical = "vertical";

		internal const string localizationAndGlyphKeyCategory_controller = "controller";

		internal const string localizationAndGlyphKeyCategory_customController = "controller/custom";

		internal const string localizationAndGlyphKeyCategory_controllerTemplate = "controller/template";

		internal const string localizationAndGlyphKeyCategory_action = "action";

		internal const string localizationAndGlyphKeyCategory_inputActionCategory = "action/category";

		internal const string localizationAndGlyphKeyCategory_controllerMap = "controller_map";

		internal const string localizationAndGlyphKeyCategory_controllerMapCategory = "controller_map/category";

		internal const string localizationAndGlyphKeyCategory_layout = "controller_map/layout";

		internal const string localizationAndGlyphKeyCategory_player = "player";

		internal const string localizationAndGlyphKeyCategory_controllerElement = "controller/element";

		internal const string nonLocalizedDisplayNameAxisDirectionSuffix_horizontal = "Horizontal";

		internal const string nonLocalizedDisplayNameAxisDirectionSuffix_vertical = "Vertical";

		private static bcCFWyIxTJsOtYiCZYacQktENwst sDDOUaEyLGQXHaBcbWkerjayOEjQ;

		private static StringBuilder RBSpnSZnrcNKBKqBHgOfjTNfEHjRA;

		public static bool isEnabled
		{
			get
			{
				if (sDDOUaEyLGQXHaBcbWkerjayOEjQ == null)
				{
					return false;
				}
				return sDDOUaEyLGQXHaBcbWkerjayOEjQ.bFYelAPBgVpCXNBqpsKmCvKnjygN != null;
			}
		}

		public static uint version
		{
			get
			{
				KmgxgebwTdSSOEIQxjEkHfHekWpU();
				return sDDOUaEyLGQXHaBcbWkerjayOEjQ.BwOTYArtuljGvQqzeWfOWKROvErQ;
			}
		}

		public static ILocalizedStringProvider localizedStringProvider
		{
			get
			{
				KmgxgebwTdSSOEIQxjEkHfHekWpU();
				return sDDOUaEyLGQXHaBcbWkerjayOEjQ.bFYelAPBgVpCXNBqpsKmCvKnjygN;
			}
			set
			{
				KmgxgebwTdSSOEIQxjEkHfHekWpU();
				sDDOUaEyLGQXHaBcbWkerjayOEjQ.CrAeFgsrYCiEUtBghwmJtHlQiScBA(value);
			}
		}

		public static bool autoPrefetch
		{
			get
			{
				KmgxgebwTdSSOEIQxjEkHfHekWpU();
				return sDDOUaEyLGQXHaBcbWkerjayOEjQ.JIIJbGvuuBBegIewPVIpmNkTgmheA;
			}
			set
			{
				KmgxgebwTdSSOEIQxjEkHfHekWpU();
				sDDOUaEyLGQXHaBcbWkerjayOEjQ.rSfIhAsbpdbmbuyhHYWtSLHsWSDf(value);
			}
		}

		public static void Initialize()
		{
			if (sDDOUaEyLGQXHaBcbWkerjayOEjQ != null)
			{
				throw new Exception("Already initialized");
			}
			sDDOUaEyLGQXHaBcbWkerjayOEjQ = new bcCFWyIxTJsOtYiCZYacQktENwst();
		}

		public static void Deinitialize()
		{
			if (sDDOUaEyLGQXHaBcbWkerjayOEjQ != null)
			{
				sDDOUaEyLGQXHaBcbWkerjayOEjQ = null;
			}
		}

		public static void Add(ChutGPBICOllLFbDwaPETGCPjnpCA obj, ref Id id)
		{
			KmgxgebwTdSSOEIQxjEkHfHekWpU();
			id = sDDOUaEyLGQXHaBcbWkerjayOEjQ.hqMSWYUujoWQoBsaTizWlyLEBZLn(obj);
		}

		public static bool Remove(ref Id id)
		{
			KmgxgebwTdSSOEIQxjEkHfHekWpU();
			bool result = sDDOUaEyLGQXHaBcbWkerjayOEjQ.wcqIQHUSzYSIdtKJLVSgCzQMadlA(id);
			id = 0u;
			return result;
		}

		public static void Prefetch()
		{
			KmgxgebwTdSSOEIQxjEkHfHekWpU();
			sDDOUaEyLGQXHaBcbWkerjayOEjQ.srgQFJqARhSaAstJjZCRYUcyILxk();
		}

		public static void Reload()
		{
			KmgxgebwTdSSOEIQxjEkHfHekWpU();
			sDDOUaEyLGQXHaBcbWkerjayOEjQ.OcOpkQGjdlRvVJHfGYLtVZZbkHaA();
		}

		private static void KmgxgebwTdSSOEIQxjEkHfHekWpU()
		{
			if (sDDOUaEyLGQXHaBcbWkerjayOEjQ == null)
			{
				throw new Exception(typeof(LocalizationManager).Name + " is not initialized.");
			}
		}

		public static bool TryGetCachedLocalizedString(LocalizedString localizedString, string fallback, uint localizationVersion, uint dependenciesVersion, out bool localizationVersionChanged, out string result)
		{
			if (sDDOUaEyLGQXHaBcbWkerjayOEjQ.bFYelAPBgVpCXNBqpsKmCvKnjygN != null)
			{
				if (localizedString.TryGetLocalizedValue(null, sDDOUaEyLGQXHaBcbWkerjayOEjQ.bFYelAPBgVpCXNBqpsKmCvKnjygN, sDDOUaEyLGQXHaBcbWkerjayOEjQ.BwOTYArtuljGvQqzeWfOWKROvErQ, dependenciesVersion, out localizationVersionChanged, out result))
				{
					return true;
				}
				result = fallback;
				return false;
			}
			result = fallback;
			localizationVersionChanged = false;
			return false;
		}

		public static bool TryLocalizeString(LocalizedString localizedString, string key, uint localizationVersion, uint dependenciesVersion, out string result)
		{
			if (sDDOUaEyLGQXHaBcbWkerjayOEjQ.bFYelAPBgVpCXNBqpsKmCvKnjygN != null)
			{
				localizedString.Clear();
				bool versionChanged;
				return localizedString.TryGetLocalizedValue(key, sDDOUaEyLGQXHaBcbWkerjayOEjQ.bFYelAPBgVpCXNBqpsKmCvKnjygN, sDDOUaEyLGQXHaBcbWkerjayOEjQ.BwOTYArtuljGvQqzeWfOWKROvErQ, dependenciesVersion, out versionChanged, out result);
			}
			result = null;
			return false;
		}

		public static GetAndUpdateLocalizedStringResultFlags GetAndUpdateLocalizedString(LocalizedString localizedString, IReadOnlyList<string> parentKeys, string keyCategory, string fallback, out string result)
		{
			if (sDDOUaEyLGQXHaBcbWkerjayOEjQ.bFYelAPBgVpCXNBqpsKmCvKnjygN == null)
			{
				result = fallback;
				return GetAndUpdateLocalizedStringResultFlags.Failed;
			}
			GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = ((!TryGetCachedLocalizedString(localizedString, fallback, sDDOUaEyLGQXHaBcbWkerjayOEjQ.BwOTYArtuljGvQqzeWfOWKROvErQ, 0u, out var localizationVersionChanged, out result)) ? GetAndUpdateLocalizedStringResultFlags.Failed : GetAndUpdateLocalizedStringResultFlags.IsCachedValue);
			if (!localizedString.hasCachedValue || localizationVersionChanged)
			{
				getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Changed;
				if (dbywlmSYOBWQKDRknNIYBYzdggXd(localizedString, parentKeys, keyCategory, fallback, out result))
				{
					getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.JustLocalized;
					getAndUpdateLocalizedStringResultFlags &= (GetAndUpdateLocalizedStringResultFlags)(-2);
				}
				else
				{
					getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Failed;
				}
			}
			return getAndUpdateLocalizedStringResultFlags;
		}

		public static GetAndUpdateLocalizedStringResultFlags GetAndUpdateLocalizedString(LocalizedString localizedString, string key, string keyCategory, IReadOnlyList<string> parentKeys, string fallback, out string result)
		{
			if (sDDOUaEyLGQXHaBcbWkerjayOEjQ.bFYelAPBgVpCXNBqpsKmCvKnjygN == null)
			{
				result = fallback;
				return GetAndUpdateLocalizedStringResultFlags.Failed;
			}
			GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = ((!TryGetCachedLocalizedString(localizedString, fallback, sDDOUaEyLGQXHaBcbWkerjayOEjQ.BwOTYArtuljGvQqzeWfOWKROvErQ, 0u, out var localizationVersionChanged, out result)) ? GetAndUpdateLocalizedStringResultFlags.Failed : GetAndUpdateLocalizedStringResultFlags.IsCachedValue);
			if (!localizedString.hasCachedValue || localizationVersionChanged)
			{
				getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Changed;
				if (HVrWrvtWslbDttJrAIAMlulWnpEk(localizedString, key, keyCategory, fallback, parentKeys, out result))
				{
					getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.JustLocalized;
					getAndUpdateLocalizedStringResultFlags &= (GetAndUpdateLocalizedStringResultFlags)(-2);
				}
				else
				{
					getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Failed;
				}
			}
			return getAndUpdateLocalizedStringResultFlags;
		}

		private static bool dbywlmSYOBWQKDRknNIYBYzdggXd(LocalizedString P_0, IReadOnlyList<string> P_1, string P_2, string P_3, out string P_4)
		{
			if (P_1 == null)
			{
				P_4 = P_3;
				return false;
			}
			bool result = false;
			bool flag = !string.IsNullOrEmpty(P_2);
			StringBuilder sharedStringBuilder = GetSharedStringBuilder();
			int num = 0;
			while (true)
			{
				if (num < P_1.Count)
				{
					if (!string.IsNullOrEmpty(P_1[num]))
					{
						sharedStringBuilder.Length = 0;
						if (flag)
						{
							sharedStringBuilder.Append(P_2);
						}
						AppendToKeyAsPath(sharedStringBuilder, P_1[num]);
						if (TryLocalizeString(P_0, sharedStringBuilder.ToString(), sDDOUaEyLGQXHaBcbWkerjayOEjQ.BwOTYArtuljGvQqzeWfOWKROvErQ, 0u, out P_4))
						{
							result = true;
							break;
						}
					}
					num++;
					continue;
				}
				P_4 = P_3;
				break;
			}
			P_0.cachedValue = P_4;
			return result;
		}

		private static bool HVrWrvtWslbDttJrAIAMlulWnpEk(LocalizedString P_0, string P_1, string P_2, string P_3, IReadOnlyList<string> P_4, out string P_5)
		{
			if (string.IsNullOrEmpty(P_1))
			{
				P_5 = P_3;
				return false;
			}
			bool result = false;
			uint dependenciesVersion = 0u;
			bool flag = !string.IsNullOrEmpty(P_2);
			StringBuilder sharedStringBuilder = GetSharedStringBuilder();
			if (P_4 != null)
			{
				for (int i = 0; i < P_4.Count; i++)
				{
					if (string.IsNullOrEmpty(P_4[i]))
					{
						continue;
					}
					sharedStringBuilder.Length = 0;
					if (flag)
					{
						sharedStringBuilder.Append(P_2);
					}
					AppendToKeyAsPath(sharedStringBuilder, P_4[i]);
					AppendToKeyAsPath(sharedStringBuilder, P_1);
					if (!TryLocalizeString(P_0, sharedStringBuilder.ToString(), sDDOUaEyLGQXHaBcbWkerjayOEjQ.BwOTYArtuljGvQqzeWfOWKROvErQ, dependenciesVersion, out P_5))
					{
						continue;
					}
					goto IL_0080;
				}
			}
			if (P_4 == null || P_4.Count == 0)
			{
				sharedStringBuilder.Length = 0;
				if (flag)
				{
					sharedStringBuilder.Append(P_2);
				}
				AppendToKeyAsPath(sharedStringBuilder, P_1);
				if (TryLocalizeString(P_0, sharedStringBuilder.ToString(), sDDOUaEyLGQXHaBcbWkerjayOEjQ.BwOTYArtuljGvQqzeWfOWKROvErQ, dependenciesVersion, out P_5))
				{
					result = true;
					goto IL_00df;
				}
			}
			P_5 = P_3;
			goto IL_00df;
			IL_00df:
			P_0.cachedValue = P_5;
			return result;
			IL_0080:
			result = true;
			goto IL_00df;
		}

		public static string ConcatenateKeyStrings(string a, string b)
		{
			if (string.IsNullOrEmpty(a))
			{
				return b;
			}
			if (string.IsNullOrEmpty(b))
			{
				return a;
			}
			StringBuilder sharedStringBuilder = GetSharedStringBuilder();
			sharedStringBuilder.Append(a);
			sharedStringBuilder.Append('_');
			sharedStringBuilder.Append(b);
			return sharedStringBuilder.ToString();
		}

		public static string AppendToKeyAsPath(string a, string b)
		{
			if (string.IsNullOrEmpty(a))
			{
				return b;
			}
			if (string.IsNullOrEmpty(b))
			{
				return a;
			}
			StringBuilder sharedStringBuilder = GetSharedStringBuilder();
			sharedStringBuilder.Append(a);
			sharedStringBuilder.Append('/');
			sharedStringBuilder.Append(b);
			return sharedStringBuilder.ToString();
		}

		public static StringBuilder AppendToKeyAsPath(StringBuilder sb, string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return sb;
			}
			if (sb.Length > 0)
			{
				sb.Append('/');
			}
			sb.Append(value);
			return sb;
		}

		public static string AppendToKeyAxisPole(string a, Pole pole)
		{
			if (string.IsNullOrEmpty(a))
			{
				return string.Empty;
			}
			return AppendToKeyAsPath(a, (pole == Pole.Positive) ? "positive" : "negative");
		}

		public static string AppendToNameAxisPole(string text, Pole pole)
		{
			return pole switch
			{
				Pole.Positive => text + " +", 
				Pole.Negative => text + " -", 
				_ => text, 
			};
		}

		public static string AppendToKeyAxisDirection(string a, AxisDirection direction)
		{
			if (string.IsNullOrEmpty(a))
			{
				return string.Empty;
			}
			return AppendToKeyAsPath(a, (direction == AxisDirection.Vertical) ? "vertical" : "horizontal");
		}

		public static string AppendToNameAxisDirection(string a, AxisDirection direction)
		{
			if (string.IsNullOrEmpty(a))
			{
				return string.Empty;
			}
			return a + " " + ((direction == AxisDirection.Vertical) ? "Vertical" : "Horizontal");
		}

		public static string FormatKey(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			return StringTools.AddSpacesToCamelCase(text).Replace(' ', '_').ToLowerInvariant();
		}

		[CustomObfuscation(rename = false)]
		public static StringBuilder GetSharedStringBuilder()
		{
			if (RBSpnSZnrcNKBKqBHgOfjTNfEHjRA != null)
			{
				RBSpnSZnrcNKBKqBHgOfjTNfEHjRA.Length = 0;
				return RBSpnSZnrcNKBKqBHgOfjTNfEHjRA;
			}
			return RBSpnSZnrcNKBKqBHgOfjTNfEHjRA = new StringBuilder();
		}
	}
}
