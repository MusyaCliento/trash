using System;
using System.Text;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

namespace Rewired.Internal.Glyphs
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class GlyphManager
	{
		private sealed class sNSQhEscydZKTCcSwDnaKlOuUKZl
		{
			[Serializable]
			private sealed class KMSmBLAGMicqIgDGlxqPZTmcayfk
			{
				public static readonly KMSmBLAGMicqIgDGlxqPZTmcayfk _003C_003E9 = new KMSmBLAGMicqIgDGlxqPZTmcayfk();

				public static Action<IPrefetch> _003C_003E9__7_0;

				internal void UxUmdRGlVdAROJbKzIfQDEBcaDtOA(IPrefetch P_0)
				{
					P_0.Prefetch();
				}
			}

			private const float DToqVexYwtAiHqCYSzusjOYJzqUW = 60f;

			private readonly global::dKMHvtjnHwbrmeEpBMdCxcqKdkxz<IPrefetch> EuEdrAWTVTVUqiOqhOOsPRaFbvcy;

			public bool GYnfnSEjmAJFpAfsdqvnbgaoVUOHB;

			public IGlyphProvider lOeNBObJwXszsUuHYKqWCMkwwyzF;

			public uint DKDpJwveNQULcZkwwDqZwXMSelrGA;

			private Action<IPrefetch> gspvgnTbCgoTtjgzltjMlAvcHiKI = KMSmBLAGMicqIgDGlxqPZTmcayfk._003C_003E9.UxUmdRGlVdAROJbKzIfQDEBcaDtOA;

			private Id mBtoBZpdLZGyGrLCpRVBMzJoKCel;

			public sNSQhEscydZKTCcSwDnaKlOuUKZl()
			{
				EuEdrAWTVTVUqiOqhOOsPRaFbvcy = new global::dKMHvtjnHwbrmeEpBMdCxcqKdkxz<IPrefetch>(60f);
				DKDpJwveNQULcZkwwDqZwXMSelrGA = 0u;
				mBtoBZpdLZGyGrLCpRVBMzJoKCel = 1u;
			}

			public void KVLuvqOrdxAITGUWVAFcholKNhoj(IGlyphProvider P_0)
			{
				lOeNBObJwXszsUuHYKqWCMkwwyzF = P_0;
				if (P_0 != null)
				{
					DKDpJwveNQULcZkwwDqZwXMSelrGA = mBtoBZpdLZGyGrLCpRVBMzJoKCel.id;
					mBtoBZpdLZGyGrLCpRVBMzJoKCel.Increment();
				}
				else
				{
					DKDpJwveNQULcZkwwDqZwXMSelrGA = 0u;
				}
				LMHdUFqDXrEpclQJLnMHMAAMqUxv();
			}

			public void jnLhtGBzPEqUcGCfXbILakzwVIymA(bool P_0)
			{
				if (P_0 != GYnfnSEjmAJFpAfsdqvnbgaoVUOHB)
				{
					GYnfnSEjmAJFpAfsdqvnbgaoVUOHB = P_0;
					if (P_0)
					{
						RKcXfwieosXEAjpGVJCLPGfxPenC();
					}
				}
			}

			public void RKcXfwieosXEAjpGVJCLPGfxPenC()
			{
				if (lOeNBObJwXszsUuHYKqWCMkwwyzF != null)
				{
					EuEdrAWTVTVUqiOqhOOsPRaFbvcy.LqbEaGEnaEhHpJTCavQVpRSxylKt(gspvgnTbCgoTtjgzltjMlAvcHiKI);
				}
			}

			public void EJhHRqVxqBLDMlmTIAFYidVpEcBzA()
			{
				if (lOeNBObJwXszsUuHYKqWCMkwwyzF != null)
				{
					DKDpJwveNQULcZkwwDqZwXMSelrGA = mBtoBZpdLZGyGrLCpRVBMzJoKCel.id;
					mBtoBZpdLZGyGrLCpRVBMzJoKCel.Increment();
					if (GYnfnSEjmAJFpAfsdqvnbgaoVUOHB)
					{
						RKcXfwieosXEAjpGVJCLPGfxPenC();
					}
					else
					{
						LMHdUFqDXrEpclQJLnMHMAAMqUxv();
					}
				}
			}

			public uint ZTHCjpTWVcFYCHvmTjpCRrplATvLA(IPrefetch P_0)
			{
				return EuEdrAWTVTVUqiOqhOOsPRaFbvcy.OxSTHoscbMWZIVblFwqRXSsOejoG(P_0);
			}

			public bool DlxfhQoKPSLGvsLSjdxfOfJMtxBv(uint P_0)
			{
				return EuEdrAWTVTVUqiOqhOOsPRaFbvcy.RjxcuGiHchffGTyZXnYuYpPwBJsJA(P_0);
			}

			public void LMHdUFqDXrEpclQJLnMHMAAMqUxv()
			{
				EuEdrAWTVTVUqiOqhOOsPRaFbvcy.vgRWaCmXOzvjDsezgCKXJmOEJMjb();
			}
		}

		[CustomObfuscation(rename = false)]
		public enum GetAndUpdateGlyphResultFlags
		{
			None = 0,
			Failed = 1,
			IsCachedValue = 2,
			Changed = 4,
			JustGot = 8
		}

		private static sNSQhEscydZKTCcSwDnaKlOuUKZl CqDrSsYWskejBbMluiJGyJnKBUgAA;

		private static StringBuilder BLJDtOXgLXZVVJUwxbKRilTdBEWhA;

		public static bool isEnabled
		{
			get
			{
				if (CqDrSsYWskejBbMluiJGyJnKBUgAA == null)
				{
					return false;
				}
				return CqDrSsYWskejBbMluiJGyJnKBUgAA.lOeNBObJwXszsUuHYKqWCMkwwyzF != null;
			}
		}

		public static uint version
		{
			get
			{
				UilWKkAfymlgGEJZOmLPpGaebkyy();
				return CqDrSsYWskejBbMluiJGyJnKBUgAA.DKDpJwveNQULcZkwwDqZwXMSelrGA;
			}
		}

		public static IGlyphProvider glyphProvider
		{
			get
			{
				UilWKkAfymlgGEJZOmLPpGaebkyy();
				return CqDrSsYWskejBbMluiJGyJnKBUgAA.lOeNBObJwXszsUuHYKqWCMkwwyzF;
			}
			set
			{
				UilWKkAfymlgGEJZOmLPpGaebkyy();
				CqDrSsYWskejBbMluiJGyJnKBUgAA.KVLuvqOrdxAITGUWVAFcholKNhoj(value);
			}
		}

		public static bool autoPrefetch
		{
			get
			{
				UilWKkAfymlgGEJZOmLPpGaebkyy();
				return CqDrSsYWskejBbMluiJGyJnKBUgAA.GYnfnSEjmAJFpAfsdqvnbgaoVUOHB;
			}
			set
			{
				UilWKkAfymlgGEJZOmLPpGaebkyy();
				CqDrSsYWskejBbMluiJGyJnKBUgAA.jnLhtGBzPEqUcGCfXbILakzwVIymA(value);
			}
		}

		public static void Initialize()
		{
			if (CqDrSsYWskejBbMluiJGyJnKBUgAA != null)
			{
				throw new Exception("Already initialized");
			}
			CqDrSsYWskejBbMluiJGyJnKBUgAA = new sNSQhEscydZKTCcSwDnaKlOuUKZl();
		}

		public static void Deinitialize()
		{
			if (CqDrSsYWskejBbMluiJGyJnKBUgAA != null)
			{
				CqDrSsYWskejBbMluiJGyJnKBUgAA = null;
			}
		}

		public static void Add(IPrefetch obj, ref Id id)
		{
			UilWKkAfymlgGEJZOmLPpGaebkyy();
			id = CqDrSsYWskejBbMluiJGyJnKBUgAA.ZTHCjpTWVcFYCHvmTjpCRrplATvLA(obj);
		}

		public static bool Remove(ref Id id)
		{
			UilWKkAfymlgGEJZOmLPpGaebkyy();
			bool result = CqDrSsYWskejBbMluiJGyJnKBUgAA.DlxfhQoKPSLGvsLSjdxfOfJMtxBv(id);
			id = 0u;
			return result;
		}

		public static void Prefetch()
		{
			UilWKkAfymlgGEJZOmLPpGaebkyy();
			CqDrSsYWskejBbMluiJGyJnKBUgAA.RKcXfwieosXEAjpGVJCLPGfxPenC();
		}

		public static void Reload()
		{
			UilWKkAfymlgGEJZOmLPpGaebkyy();
			CqDrSsYWskejBbMluiJGyJnKBUgAA.EJhHRqVxqBLDMlmTIAFYidVpEcBzA();
		}

		private static void UilWKkAfymlgGEJZOmLPpGaebkyy()
		{
			if (CqDrSsYWskejBbMluiJGyJnKBUgAA == null)
			{
				throw new Exception(typeof(GlyphManager).Name + " is not initialized.");
			}
		}

		public static bool TryGetCachedGlyph(KeyedGlyph keyedGlyph, uint glyphProviderVersion, uint dependenciesVersion, out bool glyphProviderVersionChanged, out object result)
		{
			if (CqDrSsYWskejBbMluiJGyJnKBUgAA.lOeNBObJwXszsUuHYKqWCMkwwyzF != null)
			{
				return keyedGlyph.TryGetValue(null, CqDrSsYWskejBbMluiJGyJnKBUgAA.lOeNBObJwXszsUuHYKqWCMkwwyzF, CqDrSsYWskejBbMluiJGyJnKBUgAA.DKDpJwveNQULcZkwwDqZwXMSelrGA, dependenciesVersion, out glyphProviderVersionChanged, out result);
			}
			result = null;
			glyphProviderVersionChanged = false;
			return false;
		}

		public static bool TryGetGlyph(KeyedGlyph keyedGlyph, string key, uint glyphProviderVersion, uint dependenciesVersion, out object result)
		{
			if (CqDrSsYWskejBbMluiJGyJnKBUgAA.lOeNBObJwXszsUuHYKqWCMkwwyzF != null)
			{
				keyedGlyph.Clear();
				bool versionChanged;
				return keyedGlyph.TryGetValue(key, CqDrSsYWskejBbMluiJGyJnKBUgAA.lOeNBObJwXszsUuHYKqWCMkwwyzF, CqDrSsYWskejBbMluiJGyJnKBUgAA.DKDpJwveNQULcZkwwDqZwXMSelrGA, dependenciesVersion, out versionChanged, out result);
			}
			result = null;
			return false;
		}

		public static GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, IReadOnlyList<string> parentKeys, string keyCategory, out object result)
		{
			if (CqDrSsYWskejBbMluiJGyJnKBUgAA.lOeNBObJwXszsUuHYKqWCMkwwyzF == null)
			{
				result = null;
				return GetAndUpdateGlyphResultFlags.Failed;
			}
			GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ((!TryGetCachedGlyph(keyedGlyph, CqDrSsYWskejBbMluiJGyJnKBUgAA.DKDpJwveNQULcZkwwDqZwXMSelrGA, 0u, out var glyphProviderVersionChanged, out result)) ? GetAndUpdateGlyphResultFlags.Failed : GetAndUpdateGlyphResultFlags.IsCachedValue);
			if (!keyedGlyph.hasCachedValue || glyphProviderVersionChanged)
			{
				getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Changed;
				if (hYjQUhTMKNCMopVBwVStCtpXJZkH(keyedGlyph, parentKeys, keyCategory, out result))
				{
					getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.JustGot;
					getAndUpdateGlyphResultFlags &= (GetAndUpdateGlyphResultFlags)(-2);
				}
				else
				{
					getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Failed;
				}
			}
			return getAndUpdateGlyphResultFlags;
		}

		public static GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, string key, string keyCategory, IReadOnlyList<string> parentKeys, out object result)
		{
			if (CqDrSsYWskejBbMluiJGyJnKBUgAA.lOeNBObJwXszsUuHYKqWCMkwwyzF == null)
			{
				result = null;
				return GetAndUpdateGlyphResultFlags.Failed;
			}
			GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ((!TryGetCachedGlyph(keyedGlyph, CqDrSsYWskejBbMluiJGyJnKBUgAA.DKDpJwveNQULcZkwwDqZwXMSelrGA, 0u, out var glyphProviderVersionChanged, out result)) ? GetAndUpdateGlyphResultFlags.Failed : GetAndUpdateGlyphResultFlags.IsCachedValue);
			if (!keyedGlyph.hasCachedValue || glyphProviderVersionChanged)
			{
				getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Changed;
				if (FCdZpFVwfcGqJCwbtePllPJqEdxz(keyedGlyph, key, keyCategory, parentKeys, out result))
				{
					getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.JustGot;
					getAndUpdateGlyphResultFlags &= (GetAndUpdateGlyphResultFlags)(-2);
				}
				else
				{
					getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Failed;
				}
			}
			return getAndUpdateGlyphResultFlags;
		}

		private static bool hYjQUhTMKNCMopVBwVStCtpXJZkH(KeyedGlyph P_0, IReadOnlyList<string> P_1, string P_2, out object P_3)
		{
			if (P_1 == null)
			{
				P_3 = null;
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
						LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, P_1[num]);
						if (TryGetGlyph(P_0, sharedStringBuilder.ToString(), CqDrSsYWskejBbMluiJGyJnKBUgAA.DKDpJwveNQULcZkwwDqZwXMSelrGA, 0u, out P_3))
						{
							result = true;
							break;
						}
					}
					num++;
					continue;
				}
				P_3 = null;
				break;
			}
			P_0.cachedValue = P_3;
			return result;
		}

		private static bool FCdZpFVwfcGqJCwbtePllPJqEdxz(KeyedGlyph P_0, string P_1, string P_2, IReadOnlyList<string> P_3, out object P_4)
		{
			if (string.IsNullOrEmpty(P_1))
			{
				P_4 = null;
				return false;
			}
			bool result = false;
			uint dependenciesVersion = 0u;
			bool flag = !string.IsNullOrEmpty(P_2);
			StringBuilder sharedStringBuilder = GetSharedStringBuilder();
			if (P_3 != null)
			{
				for (int i = 0; i < P_3.Count; i++)
				{
					if (string.IsNullOrEmpty(P_3[i]))
					{
						continue;
					}
					sharedStringBuilder.Length = 0;
					if (flag)
					{
						sharedStringBuilder.Append(P_2);
					}
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, P_3[i]);
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, P_1);
					if (!TryGetGlyph(P_0, sharedStringBuilder.ToString(), CqDrSsYWskejBbMluiJGyJnKBUgAA.DKDpJwveNQULcZkwwDqZwXMSelrGA, dependenciesVersion, out P_4))
					{
						continue;
					}
					goto IL_007d;
				}
			}
			if (P_3 == null || P_3.Count == 0)
			{
				sharedStringBuilder.Length = 0;
				if (flag)
				{
					sharedStringBuilder.Append(P_2);
				}
				LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, P_1);
				if (TryGetGlyph(P_0, sharedStringBuilder.ToString(), CqDrSsYWskejBbMluiJGyJnKBUgAA.DKDpJwveNQULcZkwwDqZwXMSelrGA, dependenciesVersion, out P_4))
				{
					result = true;
					goto IL_00d9;
				}
			}
			P_4 = null;
			goto IL_00d9;
			IL_00d9:
			P_0.cachedValue = P_4;
			return result;
			IL_007d:
			result = true;
			goto IL_00d9;
		}

		[CustomObfuscation(rename = false)]
		public static StringBuilder GetSharedStringBuilder()
		{
			if (BLJDtOXgLXZVVJUwxbKRilTdBEWhA != null)
			{
				BLJDtOXgLXZVVJUwxbKRilTdBEWhA.Length = 0;
				return BLJDtOXgLXZVVJUwxbKRilTdBEWhA;
			}
			return BLJDtOXgLXZVVJUwxbKRilTdBEWhA = new StringBuilder();
		}
	}
}
