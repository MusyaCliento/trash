using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class ControllerElementIdentifier : IControllerElementIdentifierCommon_Internal, DzzQrjVWSCjbqegfjedxfSiuYAafA, BMeYXymsuXMDMyjfaaClzmryYLZG, JuFkXsalDOaAKOpTxQgcsoqPQLtO, hxyHkVRkANnbOzerwOAYbNkvukwJ, DDLiMrEdceQRXQSrNifvymIZIsut, OVWyLszztvvrzKClxAtUJKzpOUTc, XAukkdYkRkAZDxUWBprlnhBlowWG
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class VXmmTGAAzomJKBrXugkdiHgqkBUP
		{
			public int id;

			public string name;

			public string positiveName;

			public string negativeName;

			public string key;

			public string positiveKey;

			public string negativeKey;

			public ControllerElementType elementType;

			public CompoundControllerElementType compoundElementType;

			public string role;
		}

		private class VfaeNppcYVIYaHbJDUjcHImQuOjy
		{
			private string cKkdxgfkympUUECsLchndkwjbgIsA;

			private string wuJaluhgXBIBGfUdezxxJZFfAFaF;

			public string yLJWVHwKWiicqxjssHZMsfaZsxeF
			{
				get
				{
					return cKkdxgfkympUUECsLchndkwjbgIsA;
				}
				set
				{
					cKkdxgfkympUUECsLchndkwjbgIsA = text;
				}
			}

			public string EEtkNtjQiufpwmLJhEGFCFOXveOs
			{
				get
				{
					return wuJaluhgXBIBGfUdezxxJZFfAFaF;
				}
				set
				{
					wuJaluhgXBIBGfUdezxxJZFfAFaF = text;
				}
			}

			public VfaeNppcYVIYaHbJDUjcHImQuOjy()
			{
			}

			public VfaeNppcYVIYaHbJDUjcHImQuOjy(VfaeNppcYVIYaHbJDUjcHImQuOjy P_0)
			{
				cKkdxgfkympUUECsLchndkwjbgIsA = P_0.cKkdxgfkympUUECsLchndkwjbgIsA;
				wuJaluhgXBIBGfUdezxxJZFfAFaF = P_0.wuJaluhgXBIBGfUdezxxJZFfAFaF;
			}

			public WJefibNqrccTygrUvaUoQgilVyHX HAyxNamEMaRExGdMGCSBhTBceDyGA()
			{
				return new WJefibNqrccTygrUvaUoQgilVyHX(cKkdxgfkympUUECsLchndkwjbgIsA, wuJaluhgXBIBGfUdezxxJZFfAFaF);
			}
		}

		internal struct WJefibNqrccTygrUvaUoQgilVyHX
		{
			public string nzvzzwwBeYgYgCccXimstaeWFEmx;

			public string panLyNtdZlPWKBghGLnnroZiDoCC;

			public WJefibNqrccTygrUvaUoQgilVyHX(string P_0, string P_1)
			{
				nzvzzwwBeYgYgCccXimstaeWFEmx = P_0;
				panLyNtdZlPWKBghGLnnroZiDoCC = P_1;
			}
		}

		private class UBAUrqWjChDmiEpoEIrfYdabeKvBA
		{
			private enum WsWaNsmPtehBoWBeFdddEqTuRXbEA
			{
				Name = 0,
				NonLocalizedName = 1,
				Key = 2,
				Glyph = 3,
				FinalGlyphKey = 4,
				GetCompoundElementSpecialName = 5,
				GetCompoundElementSpecialGlyph = 6,
				GetCompoundElementSpecialFinalGlyphKey = 7
			}

			private class ZMyrGxDzLOKrvuxqDkbFqgjFGVaN<_0001>
			{
				public readonly Func<XAukkdYkRkAZDxUWBprlnhBlowWG, _0001> PFeurIdDctByiGGELbyenJEeVFAG;

				public readonly Func<XAukkdYkRkAZDxUWBprlnhBlowWG, _0001> YDdsXbMSBVephPeaDXuHbDGimBpo;

				public readonly Func<XAukkdYkRkAZDxUWBprlnhBlowWG, _0001> ccZwNERMVOtWeNojIumxxAstFceo;

				public ZMyrGxDzLOKrvuxqDkbFqgjFGVaN(Func<XAukkdYkRkAZDxUWBprlnhBlowWG, _0001> P_0, Func<XAukkdYkRkAZDxUWBprlnhBlowWG, _0001> P_1, Func<XAukkdYkRkAZDxUWBprlnhBlowWG, _0001> P_2)
				{
					PFeurIdDctByiGGELbyenJEeVFAG = P_0;
					YDdsXbMSBVephPeaDXuHbDGimBpo = P_1;
					ccZwNERMVOtWeNojIumxxAstFceo = P_2;
				}

				public _0001 fwEeGYLsEaDPvjUOpEdxTfKHcZMEA(XAukkdYkRkAZDxUWBprlnhBlowWG P_0, AxisRange P_1)
				{
					return P_1 switch
					{
						AxisRange.Full => PFeurIdDctByiGGELbyenJEeVFAG(P_0), 
						AxisRange.Positive => YDdsXbMSBVephPeaDXuHbDGimBpo(P_0), 
						AxisRange.Negative => ccZwNERMVOtWeNojIumxxAstFceo(P_0), 
						_ => throw new NotImplementedException(), 
					};
				}
			}

			[Serializable]
			private sealed class AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>
			{
				public static readonly AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001> _003C_003E9 = new AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>();

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, string> _003C_003E9__55_0;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, string> _003C_003E9__55_1;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, string> _003C_003E9__55_2;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, string> _003C_003E9__55_3;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, string> _003C_003E9__55_4;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, string> _003C_003E9__55_5;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, string> _003C_003E9__55_6;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, string> _003C_003E9__55_7;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, string> _003C_003E9__55_8;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, object> _003C_003E9__55_9;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, object> _003C_003E9__55_10;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, object> _003C_003E9__55_11;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, string> _003C_003E9__55_12;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, string> _003C_003E9__55_13;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, string> _003C_003E9__55_14;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, int, string> _003C_003E9__55_15;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, int, object> _003C_003E9__55_16;

				public static Func<XAukkdYkRkAZDxUWBprlnhBlowWG, int, string> _003C_003E9__55_17;

				internal string foSHXoJkdbtwaIalFzNAIyuAJJiW(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.name;
				}

				internal string fkAgjtofGTDZgfDzQWahttqdPacr(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.positiveName;
				}

				internal string smheTObRrPjnEyfcuXmVsMbZtKWaA(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.negativeName;
				}

				internal string OMMSswArcPCfycZupCtkzMgJVoch(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.nonLocalizedName;
				}

				internal string CHWsgkncVmGZcRhIlvROmEqyRFfv(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.nonLocalizedPositiveName;
				}

				internal string bfbOxeSDEGKaKBDOtGYdmZSeiUji(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.nonLocalizedNegativeName;
				}

				internal string rqLsDfPJvwCeDAOoFyVYNeLfcNpI(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.key;
				}

				internal string IXYytZfgpJAPKGhzMdaKIWzTFogbA(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.positiveKey;
				}

				internal string DccKOoAOXECyUGTvlmcXWsrPFZBH(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.negativeKey;
				}

				internal object WPZFxaeIwsDNsFSNlKNrKoKpZYwRA(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.glyph;
				}

				internal object hqMwTnzhMEkugvtFgvbnxHdTocxd(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.positiveGlyph;
				}

				internal object ekITFSCPClenhzDADhTcrVgERAXe(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.negativeGlyph;
				}

				internal string IslErvhMaYZdgQdjHLHShlecTjjjB(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.finalGlyphKey;
				}

				internal string gwrEtDHvkreBrrsgVQeJCfyGoThBA(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.finalPositiveGlyphKey;
				}

				internal string qQShYVDiUqHSTVmQbnUfXxWbkato(XAukkdYkRkAZDxUWBprlnhBlowWG P_0)
				{
					return P_0.finalNegativeGlyphKey;
				}

				internal string qAMFoLCZwkLxxskPuJkjBdAzcTIO(XAukkdYkRkAZDxUWBprlnhBlowWG P_0, int P_1)
				{
					return P_0.GetCompoundElementSpecialName(P_1);
				}

				internal object TTVlpotvVTDVIUFLUZOQryIfzfmL(XAukkdYkRkAZDxUWBprlnhBlowWG P_0, int P_1)
				{
					return P_0.GetCompoundElementSpecialGlyph(P_1);
				}

				internal string uxzyPBrHXnjlYDkgOrxDvsKxYehF(XAukkdYkRkAZDxUWBprlnhBlowWG P_0, int P_1)
				{
					return P_0.GetCompoundElementSpecialFinalGlyphKey(P_1);
				}
			}

			private readonly ControllerElementIdentifier TWpnozzKJAeuNFpStaUKYMwDMLYq;

			private readonly Dictionary<int, tkciRsKzPisEDUffwbHSifgWVYvQA> qqMLJEmcTzsqIvceGnYjuLHVcSVW;

			private bool GrxZCWHjExYupsIzsEsaKbdTCdUY;

			private bool inSnaUcrDawXLLajCWknYCuOhPDY;

			private static Dictionary<int, object> ZkTmFpTOkesoYvIFecHyAlNKUnueA;

			public int YyptttAZFAqIvsveyIPzrvVWPqVg => qqMLJEmcTzsqIvceGnYjuLHVcSVW.Count;

			public bool CTHXiZqbVcGFpcRhxbcTgriFhyUk
			{
				get
				{
					return inSnaUcrDawXLLajCWknYCuOhPDY;
				}
				set
				{
					inSnaUcrDawXLLajCWknYCuOhPDY = flag;
				}
			}

			public bool DoLSVRaCLuYZcDrsjMmwfpcGAPGHA
			{
				get
				{
					if (inSnaUcrDawXLLajCWknYCuOhPDY)
					{
						return GrxZCWHjExYupsIzsEsaKbdTCdUY;
					}
					return false;
				}
			}

			public string MPUHqttqxtBSAkKXLfAohxDsaFzkA
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<string>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.Name, AxisRange.Full);
				}
			}

			public string ZjiENyGMlVemsRoSlAOtAzVbfgGWB
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<string>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.Name, AxisRange.Positive);
				}
			}

			public string YLroLrsXOMJxHigOiDOTfhENkzihA
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeName;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<string>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.Name, AxisRange.Negative);
				}
			}

			public string SjDrwHAZKbQdbLYdXtwAQfOndxAd
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.nonLocalizedName;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<string>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.NonLocalizedName, AxisRange.Full);
				}
			}

			public string cfPPZEcejuzfggKbCezWghfiAsGgb
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.nonLocalizedPositiveName;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<string>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.NonLocalizedName, AxisRange.Positive);
				}
			}

			public string nYzttpNKeJUzNMXJBspafTrtakWe
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.nonLocalizedNegativeName;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<string>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.NonLocalizedName, AxisRange.Negative);
				}
			}

			public string MnUARxaSuNJTrLaDqdZbLCAWJYiZ
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ekey;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<string>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.Key, AxisRange.Full);
				}
			}

			public string tmRqROUdcJsbJKbizdhahnurLTmfb
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveKey;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<string>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.Key, AxisRange.Positive);
				}
			}

			public string CqPwEmjoxDUJlmauoBEyeKJhtbxMA
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeKey;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<string>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.Key, AxisRange.Negative);
				}
			}

			public object fFdZQucrsVNQWGxZamVCdZPBAJ
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eglyph;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<object>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.Glyph, AxisRange.Full);
				}
			}

			public object UmULIGtSoRHYcpuFNGYHyRQYxZeC
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveGlyph;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<object>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.Glyph, AxisRange.Positive);
				}
			}

			public object MAUACSAHHNklTNVRmxGzGoyTgxomA
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeGlyph;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<object>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.Glyph, AxisRange.Negative);
				}
			}

			public string LlhLqCTDWPJFlHGxOSkLhpVMCgCKA
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.finalGlyphKey;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<string>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.FinalGlyphKey, AxisRange.Full);
				}
			}

			public string jqqaKuDtmfnlaawVYJkryOKCdaKB
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.finalPositiveGlyphKey;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<string>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.FinalGlyphKey, AxisRange.Positive);
				}
			}

			public string vfrPTfxCuvvSohsKCCYHxyTngkge
			{
				get
				{
					if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
					{
						return TWpnozzKJAeuNFpStaUKYMwDMLYq.finalNegativeGlyphKey;
					}
					return GYHrtLelCbzSBkxuVnKHaUEtRaNu<string>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.FinalGlyphKey, AxisRange.Negative);
				}
			}

			public UBAUrqWjChDmiEpoEIrfYdabeKvBA(ControllerElementIdentifier P_0)
			{
				TWpnozzKJAeuNFpStaUKYMwDMLYq = P_0;
				qqMLJEmcTzsqIvceGnYjuLHVcSVW = new Dictionary<int, tkciRsKzPisEDUffwbHSifgWVYvQA>();
				inSnaUcrDawXLLajCWknYCuOhPDY = true;
			}

			private bool cgJcRKaGTSUpiGFqvxxJPNIFmgVMA(AxisRange P_0, out tkciRsKzPisEDUffwbHSifgWVYvQA P_1)
			{
				if (qqMLJEmcTzsqIvceGnYjuLHVcSVW.Count == 0)
				{
					P_1 = default(tkciRsKzPisEDUffwbHSifgWVYvQA);
					return false;
				}
				return qqMLJEmcTzsqIvceGnYjuLHVcSVW.TryGetValue((int)P_0, out P_1);
			}

			public void xOLwhwURnCenaPOfEfxmiPRMCkVLA(tkciRsKzPisEDUffwbHSifgWVYvQA P_0)
			{
				if (P_0.AIdDFEvqktCieFMRUYESmBSRpezEA)
				{
					qqMLJEmcTzsqIvceGnYjuLHVcSVW[(int)P_0.TUSFZTmHSENpGBKyMTWHqKBIcOWO] = P_0;
					GrxZCWHjExYupsIzsEsaKbdTCdUY = true;
				}
			}

			public void vTfutrBueHUSpqEOuiPNJUjqYQtAA(tkciRsKzPisEDUffwbHSifgWVYvQA P_0)
			{
				qqMLJEmcTzsqIvceGnYjuLHVcSVW.Remove((int)P_0.TUSFZTmHSENpGBKyMTWHqKBIcOWO);
				if (qqMLJEmcTzsqIvceGnYjuLHVcSVW.Count == 0)
				{
					GrxZCWHjExYupsIzsEsaKbdTCdUY = false;
				}
			}

			public bool BEFCZTkZKCnsbVwPAjGLyxcshWxP(AxisRange P_0, bool P_1)
			{
				if ((!P_1 && !inSnaUcrDawXLLajCWknYCuOhPDY) || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
				{
					return false;
				}
				return qqMLJEmcTzsqIvceGnYjuLHVcSVW.ContainsKey((int)P_0);
			}

			public bool wMkdGiqgbffnxyuijIuBEZWlCQoAA(AxisRange P_0, out tkciRsKzPisEDUffwbHSifgWVYvQA P_1, bool P_2)
			{
				if ((!P_2 && !inSnaUcrDawXLLajCWknYCuOhPDY) || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
				{
					P_1 = default(tkciRsKzPisEDUffwbHSifgWVYvQA);
					return false;
				}
				return qqMLJEmcTzsqIvceGnYjuLHVcSVW.TryGetValue((int)P_0, out P_1);
			}

			public void uEvEDcvfKWsaEOepOmeEWctHgVfW()
			{
				qqMLJEmcTzsqIvceGnYjuLHVcSVW.Clear();
				GrxZCWHjExYupsIzsEsaKbdTCdUY = false;
			}

			public string HNHQZRgeVUbNicikRUFUCDgRvRNX(int P_0)
			{
				if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
				{
					return TWpnozzKJAeuNFpStaUKYMwDMLYq.GetCompoundElementSpecialName(P_0);
				}
				return FxbEeCGfcTDoRAARhlcdQwLSTabbB(ewQkkIhVBLWyaBQpWtnQDcVfbhjW<Func<XAukkdYkRkAZDxUWBprlnhBlowWG, int, string>>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.GetCompoundElementSpecialName), AxisRange.Full, P_0);
			}

			public object kMNlgsfkqgMEUOeGfgjtPbxvdSPGA(int P_0)
			{
				if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
				{
					return TWpnozzKJAeuNFpStaUKYMwDMLYq.GetCompoundElementSpecialGlyph(P_0);
				}
				return FxbEeCGfcTDoRAARhlcdQwLSTabbB(ewQkkIhVBLWyaBQpWtnQDcVfbhjW<Func<XAukkdYkRkAZDxUWBprlnhBlowWG, int, object>>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.GetCompoundElementSpecialGlyph), AxisRange.Full, P_0);
			}

			public string CZFAfhuXVidCKQGsBBfbIptEwCxOA(int P_0)
			{
				if (!inSnaUcrDawXLLajCWknYCuOhPDY || !GrxZCWHjExYupsIzsEsaKbdTCdUY)
				{
					return TWpnozzKJAeuNFpStaUKYMwDMLYq.GetCompoundElementSpecialFinalGlyphKey(P_0);
				}
				return FxbEeCGfcTDoRAARhlcdQwLSTabbB(ewQkkIhVBLWyaBQpWtnQDcVfbhjW<Func<XAukkdYkRkAZDxUWBprlnhBlowWG, int, string>>(WsWaNsmPtehBoWBeFdddEqTuRXbEA.GetCompoundElementSpecialFinalGlyphKey), AxisRange.Full, P_0);
			}

			private _0002 FxbEeCGfcTDoRAARhlcdQwLSTabbB<_0001, _0002>(Func<XAukkdYkRkAZDxUWBprlnhBlowWG, _0001, _0002> P_0, AxisRange P_1, _0001 P_2)
			{
				try
				{
					inSnaUcrDawXLLajCWknYCuOhPDY = false;
					if (!cgJcRKaGTSUpiGFqvxxJPNIFmgVMA(P_1, out var tkciRsKzPisEDUffwbHSifgWVYvQA2))
					{
						return P_0(TWpnozzKJAeuNFpStaUKYMwDMLYq, P_2);
					}
					bool enabled = tkciRsKzPisEDUffwbHSifgWVYvQA2.EXGUsIYQfxBlwEAvwQrZouLmKPnU.enabled;
					tkciRsKzPisEDUffwbHSifgWVYvQA2.EXGUsIYQfxBlwEAvwQrZouLmKPnU.enabled = false;
					_0002 result = P_0(tkciRsKzPisEDUffwbHSifgWVYvQA2.EXGUsIYQfxBlwEAvwQrZouLmKPnU, P_2);
					tkciRsKzPisEDUffwbHSifgWVYvQA2.EXGUsIYQfxBlwEAvwQrZouLmKPnU.enabled = enabled;
					return result;
				}
				finally
				{
					inSnaUcrDawXLLajCWknYCuOhPDY = true;
				}
			}

			private _0001 GYHrtLelCbzSBkxuVnKHaUEtRaNu<_0001>(WsWaNsmPtehBoWBeFdddEqTuRXbEA P_0, AxisRange P_1)
			{
				try
				{
					inSnaUcrDawXLLajCWknYCuOhPDY = false;
					ZMyrGxDzLOKrvuxqDkbFqgjFGVaN<_0001> zMyrGxDzLOKrvuxqDkbFqgjFGVaN = ewQkkIhVBLWyaBQpWtnQDcVfbhjW<ZMyrGxDzLOKrvuxqDkbFqgjFGVaN<_0001>>(P_0);
					if (!cgJcRKaGTSUpiGFqvxxJPNIFmgVMA(P_1, out var tkciRsKzPisEDUffwbHSifgWVYvQA2))
					{
						return zMyrGxDzLOKrvuxqDkbFqgjFGVaN.fwEeGYLsEaDPvjUOpEdxTfKHcZMEA(TWpnozzKJAeuNFpStaUKYMwDMLYq, P_1);
					}
					return ZHolIPvAqympAmGpQPuJENRqVqCM(tkciRsKzPisEDUffwbHSifgWVYvQA2.EXGUsIYQfxBlwEAvwQrZouLmKPnU, tkciRsKzPisEDUffwbHSifgWVYvQA2.gMwzGNvlXLhGtbespFTLVcQUHtvh, zMyrGxDzLOKrvuxqDkbFqgjFGVaN);
				}
				finally
				{
					inSnaUcrDawXLLajCWknYCuOhPDY = true;
				}
			}

			private static _0001 ZHolIPvAqympAmGpQPuJENRqVqCM<_0001>(XAukkdYkRkAZDxUWBprlnhBlowWG P_0, AxisRange P_1, ZMyrGxDzLOKrvuxqDkbFqgjFGVaN<_0001> P_2)
			{
				bool enabled = P_0.enabled;
				P_0.enabled = false;
				_0001 result = P_2.fwEeGYLsEaDPvjUOpEdxTfKHcZMEA(P_0, P_1);
				P_0.enabled = enabled;
				return result;
			}

			private static _0001 ewQkkIhVBLWyaBQpWtnQDcVfbhjW<_0001>(WsWaNsmPtehBoWBeFdddEqTuRXbEA P_0)
			{
				if (ZkTmFpTOkesoYvIFecHyAlNKUnueA == null)
				{
					ZkTmFpTOkesoYvIFecHyAlNKUnueA = new Dictionary<int, object>
					{
						{
							0,
							new ZMyrGxDzLOKrvuxqDkbFqgjFGVaN<string>(AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.foSHXoJkdbtwaIalFzNAIyuAJJiW, AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.fkAgjtofGTDZgfDzQWahttqdPacr, AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.smheTObRrPjnEyfcuXmVsMbZtKWaA)
						},
						{
							1,
							new ZMyrGxDzLOKrvuxqDkbFqgjFGVaN<string>(AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.OMMSswArcPCfycZupCtkzMgJVoch, AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.CHWsgkncVmGZcRhIlvROmEqyRFfv, AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.bfbOxeSDEGKaKBDOtGYdmZSeiUji)
						},
						{
							2,
							new ZMyrGxDzLOKrvuxqDkbFqgjFGVaN<string>(AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.rqLsDfPJvwCeDAOoFyVYNeLfcNpI, AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.IXYytZfgpJAPKGhzMdaKIWzTFogbA, AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.DccKOoAOXECyUGTvlmcXWsrPFZBH)
						},
						{
							3,
							new ZMyrGxDzLOKrvuxqDkbFqgjFGVaN<object>(AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.WPZFxaeIwsDNsFSNlKNrKoKpZYwRA, AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.hqMwTnzhMEkugvtFgvbnxHdTocxd, AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.ekITFSCPClenhzDADhTcrVgERAXe)
						},
						{
							4,
							new ZMyrGxDzLOKrvuxqDkbFqgjFGVaN<string>(AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.IslErvhMaYZdgQdjHLHShlecTjjjB, AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.gwrEtDHvkreBrrsgVQeJCfyGoThBA, AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.qQShYVDiUqHSTVmQbnUfXxWbkato)
						},
						{
							5,
							new Func<XAukkdYkRkAZDxUWBprlnhBlowWG, int, string>(AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.qAMFoLCZwkLxxskPuJkjBdAzcTIO)
						},
						{
							6,
							new Func<XAukkdYkRkAZDxUWBprlnhBlowWG, int, object>(AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.TTVlpotvVTDVIUFLUZOQryIfzfmL)
						},
						{
							7,
							new Func<XAukkdYkRkAZDxUWBprlnhBlowWG, int, string>(AGGVjMGkFnxQVFpJjEyCNxpfgFigA<_0001>._003C_003E9.uxzyPBrHXnjlYDkgOrxDvsKxYehF)
						}
					};
				}
				return (_0001)ZkTmFpTOkesoYvIFecHyAlNKUnueA[(int)P_0];
			}
		}

		internal struct tkciRsKzPisEDUffwbHSifgWVYvQA : IEquatable<tkciRsKzPisEDUffwbHSifgWVYvQA>
		{
			public XAukkdYkRkAZDxUWBprlnhBlowWG EXGUsIYQfxBlwEAvwQrZouLmKPnU;

			public AxisRange TUSFZTmHSENpGBKyMTWHqKBIcOWO;

			public AxisRange gMwzGNvlXLhGtbespFTLVcQUHtvh;

			public bool AIdDFEvqktCieFMRUYESmBSRpezEA => EXGUsIYQfxBlwEAvwQrZouLmKPnU != null;

			public tkciRsKzPisEDUffwbHSifgWVYvQA(XAukkdYkRkAZDxUWBprlnhBlowWG P_0, AxisRange P_1, AxisRange P_2)
			{
				EXGUsIYQfxBlwEAvwQrZouLmKPnU = P_0;
				TUSFZTmHSENpGBKyMTWHqKBIcOWO = P_1;
				gMwzGNvlXLhGtbespFTLVcQUHtvh = P_2;
			}

			public bool Equals(tkciRsKzPisEDUffwbHSifgWVYvQA other)
			{
				if (EXGUsIYQfxBlwEAvwQrZouLmKPnU == other.EXGUsIYQfxBlwEAvwQrZouLmKPnU && TUSFZTmHSENpGBKyMTWHqKBIcOWO == other.TUSFZTmHSENpGBKyMTWHqKBIcOWO)
				{
					return gMwzGNvlXLhGtbespFTLVcQUHtvh == other.gMwzGNvlXLhGtbespFTLVcQUHtvh;
				}
				return false;
			}

			bool IEquatable<tkciRsKzPisEDUffwbHSifgWVYvQA>.Equals(tkciRsKzPisEDUffwbHSifgWVYvQA other)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Equals
				return this.Equals(other);
			}

			public bool jYfhqpsTMMFfypCzfIEFXgfaCqhV(object P_0)
			{
				if (P_0 == null || !(P_0 is tkciRsKzPisEDUffwbHSifgWVYvQA))
				{
					return false;
				}
				return Equals((tkciRsKzPisEDUffwbHSifgWVYvQA)P_0);
			}

			public int YJGJGpwqsJTywPyuvnpQxdGsNLcG()
			{
				return ((17 * 29 + EXGUsIYQfxBlwEAvwQrZouLmKPnU.GetHashCode()) * 29 + TUSFZTmHSENpGBKyMTWHqKBIcOWO.GetHashCode()) * 29 + gMwzGNvlXLhGtbespFTLVcQUHtvh.GetHashCode();
			}

			[SpecialName]
			public static bool dnYJgzkxoZfzdMisXIiTXuavDpqR(tkciRsKzPisEDUffwbHSifgWVYvQA P_0, tkciRsKzPisEDUffwbHSifgWVYvQA P_1)
			{
				if (P_0.EXGUsIYQfxBlwEAvwQrZouLmKPnU == P_1.EXGUsIYQfxBlwEAvwQrZouLmKPnU && P_0.TUSFZTmHSENpGBKyMTWHqKBIcOWO == P_1.TUSFZTmHSENpGBKyMTWHqKBIcOWO)
				{
					return P_0.gMwzGNvlXLhGtbespFTLVcQUHtvh == P_1.gMwzGNvlXLhGtbespFTLVcQUHtvh;
				}
				return false;
			}

			[SpecialName]
			public static bool PCvhJlNvjSZxWsrawgvDKNbGiUJi(tkciRsKzPisEDUffwbHSifgWVYvQA P_0, tkciRsKzPisEDUffwbHSifgWVYvQA P_1)
			{
				return !dnYJgzkxoZfzdMisXIiTXuavDpqR(P_0, P_1);
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _key;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerElementType _elementType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CompoundControllerElementType _compoundElementType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _role;

		[NonSerialized]
		private bool qlPxopXRkKCQgpoCYQrwmHXpoLsp;

		[NonSerialized]
		private HMtLwHHjltZtNIbnthVxPUFsBHUt sQRJkNgINrkHPKuXVmNfXjYveqhjA;

		[NonSerialized]
		private kdCbPgNHzwxhSYFkXdphdJmXawOiA qIjKREKHyhbHiIFiTDmVIBWCycQIA;

		[NonSerialized]
		private qmMKYKokLjiebkvHxJRGIKsndxpJ zxvSuUWczCbFeMRgacVpezIDXQzwA;

		[NonSerialized]
		private ovKidfwQWZSKcpUFWfOyBvtrdXiC YniWkWTcskcmIxgwqVyrygXbhOrs;

		[NonSerialized]
		private DeviceLocalizationInfo VvHxpFPndANZGjhVuumgzUmnDtDD;

		[NonSerialized]
		private int iLQNbGQFjGkIRvZsjCGAKPLAEWPY;

		[NonSerialized]
		private List<VfaeNppcYVIYaHbJDUjcHImQuOjy> xisaitghnqNnSrgeTLlKHGKAKouXb;

		[NonSerialized]
		private ControllerType YzOLTbnwvyDYNTwIRNXsiSpFGDln;

		[NonSerialized]
		private readonly UBAUrqWjChDmiEpoEIrfYdabeKvBA fAGrDNsEUkokJHBSsJnuIGxfmajr;

		private static ControllerElementIdentifier HmJYhyBgEkeBQadJQEfENrjtfHjg;

		int IControllerElementIdentifierCommon_Internal.id => _id;

		string IControllerElementIdentifierCommon_Internal.name
		{
			get
			{
				if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return fAGrDNsEUkokJHBSsJnuIGxfmajr.MPUHqttqxtBSAkKXLfAohxDsaFzkA;
				}
				if (!ReInput.isReady || sQRJkNgINrkHPKuXVmNfXjYveqhjA == null || !LocalizationManager.isEnabled)
				{
					return _name;
				}
				return sQRJkNgINrkHPKuXVmNfXjYveqhjA.aWxJJrCnpmeqmclTDPTQjepbcypsA;
			}
			internal set
			{
				nonLocalizedName = value;
			}
		}

		string IControllerElementIdentifierCommon_Internal.positiveName
		{
			get
			{
				if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return fAGrDNsEUkokJHBSsJnuIGxfmajr.ZjiENyGMlVemsRoSlAOtAzVbfgGWB;
				}
				if (!ReInput.isReady || sQRJkNgINrkHPKuXVmNfXjYveqhjA == null || !LocalizationManager.isEnabled)
				{
					return _positiveName;
				}
				return sQRJkNgINrkHPKuXVmNfXjYveqhjA.EEuoRgtKImedZPiNQVMolgeLffPDA;
			}
			internal set
			{
				nonLocalizedPositiveName = value;
			}
		}

		string IControllerElementIdentifierCommon_Internal.negativeName
		{
			get
			{
				if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return fAGrDNsEUkokJHBSsJnuIGxfmajr.YLroLrsXOMJxHigOiDOTfhENkzihA;
				}
				if (!ReInput.isReady || sQRJkNgINrkHPKuXVmNfXjYveqhjA == null || !LocalizationManager.isEnabled)
				{
					return _negativeName;
				}
				return sQRJkNgINrkHPKuXVmNfXjYveqhjA.kxSnSpIstDFbCpDAiIvuXMlhjOQS;
			}
			internal set
			{
				nonLocalizedNegativeName = value;
			}
		}

		public ControllerElementType elementType => _elementType;

		public CompoundControllerElementType compoundElementType => _compoundElementType;

		object XAukkdYkRkAZDxUWBprlnhBlowWG.glyph
		{
			get
			{
				if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return fAGrDNsEUkokJHBSsJnuIGxfmajr.fFdZQucrsVNQWGxZamVCdZPBAJ;
				}
				if (!ReInput.isReady || zxvSuUWczCbFeMRgacVpezIDXQzwA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return zxvSuUWczCbFeMRgacVpezIDXQzwA.bhSBkAGjBkwrSuotBdJqikBDACFz;
			}
		}

		object XAukkdYkRkAZDxUWBprlnhBlowWG.positiveGlyph
		{
			get
			{
				if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return fAGrDNsEUkokJHBSsJnuIGxfmajr.UmULIGtSoRHYcpuFNGYHyRQYxZeC;
				}
				if (!ReInput.isReady || zxvSuUWczCbFeMRgacVpezIDXQzwA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return zxvSuUWczCbFeMRgacVpezIDXQzwA.ADoOuWufrjYrDGSlORWdVoeMHdak;
			}
		}

		object XAukkdYkRkAZDxUWBprlnhBlowWG.negativeGlyph
		{
			get
			{
				if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return fAGrDNsEUkokJHBSsJnuIGxfmajr.MAUACSAHHNklTNVRmxGzGoyTgxomA;
				}
				if (!ReInput.isReady || zxvSuUWczCbFeMRgacVpezIDXQzwA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return zxvSuUWczCbFeMRgacVpezIDXQzwA.OTOMVMINJVAJOKlxRDIdsAusLkRf;
			}
		}

		private string finalGlyphKey
		{
			get
			{
				if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return fAGrDNsEUkokJHBSsJnuIGxfmajr.LlhLqCTDWPJFlHGxOSkLhpVMCgCKA;
				}
				if (!ReInput.isReady || zxvSuUWczCbFeMRgacVpezIDXQzwA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return zxvSuUWczCbFeMRgacVpezIDXQzwA.uqOSJTjgWeByxITpQQGTxpnSBQrr;
			}
		}

		private string finalPositiveGlyphKey
		{
			get
			{
				if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return fAGrDNsEUkokJHBSsJnuIGxfmajr.jqqaKuDtmfnlaawVYJkryOKCdaKB;
				}
				if (!ReInput.isReady || zxvSuUWczCbFeMRgacVpezIDXQzwA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return zxvSuUWczCbFeMRgacVpezIDXQzwA.gZFChBwzudLPJLdrMbaXcfNOIyLdb;
			}
		}

		private string finalNegativeGlyphKey
		{
			get
			{
				if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return fAGrDNsEUkokJHBSsJnuIGxfmajr.vfrPTfxCuvvSohsKCCYHxyTngkge;
				}
				if (!ReInput.isReady || zxvSuUWczCbFeMRgacVpezIDXQzwA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return zxvSuUWczCbFeMRgacVpezIDXQzwA.vfFEAsamvNlmREKhRLVMKqRMWwCGA;
			}
		}

		internal string nonLocalizedName
		{
			get
			{
				if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return fAGrDNsEUkokJHBSsJnuIGxfmajr.SjDrwHAZKbQdbLYdXtwAQfOndxAd;
				}
				return _name;
			}
			set
			{
				_name = value;
				if (ReInput.isReady)
				{
					RfTFOySkAZTvZjNaEXRpRARiADOC();
					if (sQRJkNgINrkHPKuXVmNfXjYveqhjA != null)
					{
						sQRJkNgINrkHPKuXVmNfXjYveqhjA.cwUahnpqwmWpOYgoibmoVeKGCqrw();
					}
				}
			}
		}

		internal string nonLocalizedPositiveName
		{
			get
			{
				if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return fAGrDNsEUkokJHBSsJnuIGxfmajr.cfPPZEcejuzfggKbCezWghfiAsGgb;
				}
				return _positiveName;
			}
			set
			{
				_positiveName = value;
				if (ReInput.isReady)
				{
					RfTFOySkAZTvZjNaEXRpRARiADOC();
					if (sQRJkNgINrkHPKuXVmNfXjYveqhjA != null)
					{
						sQRJkNgINrkHPKuXVmNfXjYveqhjA.RudRXeYiHFFjXzgHKxPoIxXTmRYr();
					}
				}
			}
		}

		internal string nonLocalizedNegativeName
		{
			get
			{
				if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return fAGrDNsEUkokJHBSsJnuIGxfmajr.nYzttpNKeJUzNMXJBspafTrtakWe;
				}
				return _negativeName;
			}
			set
			{
				_negativeName = value;
				if (ReInput.isReady)
				{
					RfTFOySkAZTvZjNaEXRpRARiADOC();
					if (sQRJkNgINrkHPKuXVmNfXjYveqhjA != null)
					{
						sQRJkNgINrkHPKuXVmNfXjYveqhjA.excdINExMQaKmgmHUZjbMKMBvKbkA();
					}
				}
			}
		}

		string XAukkdYkRkAZDxUWBprlnhBlowWG.key
		{
			get
			{
				if (!fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return _key;
				}
				return fAGrDNsEUkokJHBSsJnuIGxfmajr.MnUARxaSuNJTrLaDqdZbLCAWJYiZ;
			}
		}

		string XAukkdYkRkAZDxUWBprlnhBlowWG.positiveKey
		{
			get
			{
				if (!fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return _positiveKey;
				}
				return fAGrDNsEUkokJHBSsJnuIGxfmajr.tmRqROUdcJsbJKbizdhahnurLTmfb;
			}
		}

		string XAukkdYkRkAZDxUWBprlnhBlowWG.negativeKey
		{
			get
			{
				if (!fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
				{
					return _negativeKey;
				}
				return fAGrDNsEUkokJHBSsJnuIGxfmajr.CqPwEmjoxDUJlmauoBEyeKJhtbxMA;
			}
		}

		public string role => _role;

		internal bool isCompoundElement => _elementType == ControllerElementType.CompoundElement;

		internal bool isDisplayOverridden => fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA;

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => false;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => _elementType;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedName => nonLocalizedName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedPositiveName => nonLocalizedPositiveName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedNegativeName => nonLocalizedNegativeName;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (iLQNbGQFjGkIRvZsjCGAKPLAEWPY & 2) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (iLQNbGQFjGkIRvZsjCGAKPLAEWPY & 4) != 0;

		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (iLQNbGQFjGkIRvZsjCGAKPLAEWPY & 8) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (iLQNbGQFjGkIRvZsjCGAKPLAEWPY & 0x10) != 0;

		string IControllerElementIdentifierCommon_Internal.key => _key;

		string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

		string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => VvHxpFPndANZGjhVuumgzUmnDtDD;

		string BMeYXymsuXMDMyjfaaClzmryYLZG.keyCategory => "controller/template";

		string BMeYXymsuXMDMyjfaaClzmryYLZG.scriptingName => _name;

		string BMeYXymsuXMDMyjfaaClzmryYLZG.nonLocalizedDescriptiveName
		{
			get
			{
				return _name;
			}
			set
			{
				RfTFOySkAZTvZjNaEXRpRARiADOC();
				_name = value;
			}
		}

		string DzzQrjVWSCjbqegfjedxfSiuYAafA.nonLocalizedPositiveDescriptiveName
		{
			get
			{
				return _positiveName;
			}
			set
			{
				RfTFOySkAZTvZjNaEXRpRARiADOC();
				_positiveName = value;
			}
		}

		string DzzQrjVWSCjbqegfjedxfSiuYAafA.nonLocalizedNegativeDescriptiveName
		{
			get
			{
				return _negativeName;
			}
			set
			{
				RfTFOySkAZTvZjNaEXRpRARiADOC();
				_negativeName = value;
			}
		}

		string BMeYXymsuXMDMyjfaaClzmryYLZG.key => _key;

		string DzzQrjVWSCjbqegfjedxfSiuYAafA.positiveKey
		{
			get
			{
				return _positiveKey;
			}
			set
			{
				RfTFOySkAZTvZjNaEXRpRARiADOC();
				_positiveKey = value;
			}
		}

		string DzzQrjVWSCjbqegfjedxfSiuYAafA.negativeKey
		{
			get
			{
				return _negativeKey;
			}
			set
			{
				RfTFOySkAZTvZjNaEXRpRARiADOC();
				_negativeKey = value;
			}
		}

		int BMeYXymsuXMDMyjfaaClzmryYLZG.autoGeneratedValueFlags
		{
			get
			{
				return iLQNbGQFjGkIRvZsjCGAKPLAEWPY;
			}
			set
			{
				iLQNbGQFjGkIRvZsjCGAKPLAEWPY = value;
			}
		}

		string hxyHkVRkANnbOzerwOAYbNkvukwJ.keyCategory => DTXBHoWlhfJgnmlLPGnqIDrGONgbA.jVcwLPFQfPrdeRZPNvwGoILxIRKu(YzOLTbnwvyDYNTwIRNXsiSpFGDln);

		string hxyHkVRkANnbOzerwOAYbNkvukwJ.key => _key;

		int hxyHkVRkANnbOzerwOAYbNkvukwJ.autoGeneratedValueFlags
		{
			get
			{
				return iLQNbGQFjGkIRvZsjCGAKPLAEWPY;
			}
			set
			{
				iLQNbGQFjGkIRvZsjCGAKPLAEWPY = value;
			}
		}

		string JuFkXsalDOaAKOpTxQgcsoqPQLtO.positiveKey
		{
			get
			{
				return _positiveKey;
			}
			set
			{
				RfTFOySkAZTvZjNaEXRpRARiADOC();
				_positiveKey = value;
			}
		}

		string JuFkXsalDOaAKOpTxQgcsoqPQLtO.negativeKey
		{
			get
			{
				return _negativeKey;
			}
			set
			{
				RfTFOySkAZTvZjNaEXRpRARiADOC();
				_negativeKey = value;
			}
		}

		bool XAukkdYkRkAZDxUWBprlnhBlowWG.enabled
		{
			get
			{
				return fAGrDNsEUkokJHBSsJnuIGxfmajr.CTHXiZqbVcGFpcRhxbcTgriFhyUk;
			}
			set
			{
				fAGrDNsEUkokJHBSsJnuIGxfmajr.CTHXiZqbVcGFpcRhxbcTgriFhyUk = value;
			}
		}

		string XAukkdYkRkAZDxUWBprlnhBlowWG.nonLocalizedName => nonLocalizedName;

		string XAukkdYkRkAZDxUWBprlnhBlowWG.nonLocalizedPositiveName => nonLocalizedPositiveName;

		string XAukkdYkRkAZDxUWBprlnhBlowWG.nonLocalizedNegativeName => nonLocalizedNegativeName;

		string XAukkdYkRkAZDxUWBprlnhBlowWG.finalGlyphKey => finalGlyphKey;

		string XAukkdYkRkAZDxUWBprlnhBlowWG.finalPositiveGlyphKey => finalPositiveGlyphKey;

		string XAukkdYkRkAZDxUWBprlnhBlowWG.finalNegativeGlyphKey => finalNegativeGlyphKey;

		internal static ControllerElementIdentifier BlankReadOnly
		{
			get
			{
				if (HmJYhyBgEkeBQadJQEfENrjtfHjg == null)
				{
					ControllerElementIdentifier obj = new ControllerElementIdentifier
					{
						_id = -1,
						qlPxopXRkKCQgpoCYQrwmHXpoLsp = true
					};
					HmJYhyBgEkeBQadJQEfENrjtfHjg = obj;
					return obj;
				}
				return HmJYhyBgEkeBQadJQEfENrjtfHjg;
			}
		}

		internal string GetCompoundElementSpecialName(int index)
		{
			if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
			{
				return fAGrDNsEUkokJHBSsJnuIGxfmajr.HNHQZRgeVUbNicikRUFUCDgRvRNX(index);
			}
			if (!ReInput.isReady || !LocalizationManager.isEnabled || xisaitghnqNnSrgeTLlKHGKAKouXb == null || qIjKREKHyhbHiIFiTDmVIBWCycQIA == null)
			{
				return string.Empty;
			}
			return qIjKREKHyhbHiIFiTDmVIBWCycQIA.kFzfybRGnaUscpxnrbLobRBoNEQE(index);
		}

		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
			{
				return fAGrDNsEUkokJHBSsJnuIGxfmajr.kMNlgsfkqgMEUOeGfgjtPbxvdSPGA(index);
			}
			if (!ReInput.isReady || !GlyphManager.isEnabled || xisaitghnqNnSrgeTLlKHGKAKouXb == null || YniWkWTcskcmIxgwqVyrygXbhOrs == null)
			{
				return null;
			}
			return YniWkWTcskcmIxgwqVyrygXbhOrs.pHbwkHqjdrxbcNvqfQCHRdZGBIoW(index);
		}

		internal string GetCompoundElementSpecialFinalGlyphKey(int index)
		{
			if (fAGrDNsEUkokJHBSsJnuIGxfmajr.DoLSVRaCLuYZcDrsjMmwfpcGAPGHA)
			{
				return fAGrDNsEUkokJHBSsJnuIGxfmajr.CZFAfhuXVidCKQGsBBfbIptEwCxOA(index);
			}
			if (!ReInput.isReady || !GlyphManager.isEnabled || xisaitghnqNnSrgeTLlKHGKAKouXb == null || YniWkWTcskcmIxgwqVyrygXbhOrs == null)
			{
				return null;
			}
			return YniWkWTcskcmIxgwqVyrygXbhOrs.lREmzhGvRPvWiRHYjjhyRtIoGDxU(index);
		}

		public ControllerElementIdentifier()
		{
			fAGrDNsEUkokJHBSsJnuIGxfmajr = new UBAUrqWjChDmiEpoEIrfYdabeKvBA(this);
		}

		public ControllerElementIdentifier(ControllerElementIdentifier P_0)
			: this()
		{
			_id = P_0._id;
			_name = P_0._name;
			_positiveName = P_0._positiveName;
			_negativeName = P_0._negativeName;
			_key = P_0._key;
			_positiveKey = P_0._positiveKey;
			_negativeKey = P_0._negativeKey;
			_elementType = P_0._elementType;
			_compoundElementType = P_0._compoundElementType;
			_role = P_0._role;
			if (P_0.xisaitghnqNnSrgeTLlKHGKAKouXb != null)
			{
				int count = P_0.xisaitghnqNnSrgeTLlKHGKAKouXb.Count;
				xisaitghnqNnSrgeTLlKHGKAKouXb = new List<VfaeNppcYVIYaHbJDUjcHImQuOjy>(count);
				for (int i = 0; i < count; i++)
				{
					if (P_0.xisaitghnqNnSrgeTLlKHGKAKouXb[i] != null)
					{
						xisaitghnqNnSrgeTLlKHGKAKouXb.Add(new VfaeNppcYVIYaHbJDUjcHImQuOjy(P_0.xisaitghnqNnSrgeTLlKHGKAKouXb[i]));
					}
				}
			}
			iLQNbGQFjGkIRvZsjCGAKPLAEWPY = P_0.iLQNbGQFjGkIRvZsjCGAKPLAEWPY;
			YzOLTbnwvyDYNTwIRNXsiSpFGDln = P_0.YzOLTbnwvyDYNTwIRNXsiSpFGDln;
		}

		internal ControllerElementIdentifier(VXmmTGAAzomJKBrXugkdiHgqkBUP P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initOptions");
			}
			_id = P_0.id;
			_name = P_0.name;
			_positiveName = P_0.positiveName;
			_negativeName = P_0.negativeName;
			_key = P_0.key;
			_positiveKey = P_0.positiveKey;
			_negativeKey = P_0.negativeKey;
			_elementType = P_0.elementType;
			_compoundElementType = P_0.compoundElementType;
			_role = P_0.role;
		}

		[Obsolete("Used by plugins for mouse controllers. Left for plugin compatibility. Do not use.", false)]
		internal ControllerElementIdentifier(int P_0, string P_1, string P_2, string P_3, ControllerElementType P_4, CompoundControllerElementType P_5, bool P_6)
			: this()
		{
			_id = P_0;
			_name = P_1;
			_positiveName = P_2;
			_negativeName = P_3;
			if (P_0 < Consts.commonMouseElementIdentifierInitOptions.Length && string.Equals(Consts.commonMouseElementIdentifierInitOptions[P_0].name, P_1, StringComparison.Ordinal))
			{
				_key = Consts.commonMouseElementIdentifierInitOptions[P_0].key;
				_positiveKey = Consts.commonMouseElementIdentifierInitOptions[P_0].key;
				_negativeKey = Consts.commonMouseElementIdentifierInitOptions[P_0].key;
			}
			_elementType = P_4;
			_compoundElementType = P_5;
		}

		[Obsolete("Used by UnifiedKeyboardSource. Left for plugin compatibility. Do not use.", false)]
		internal ControllerElementIdentifier(int P_0, string P_1, string P_2, string P_3, ControllerElementType P_4, bool P_5)
			: this()
		{
			_id = P_0;
			_name = P_1;
			_positiveName = P_2;
			_negativeName = P_3;
			if (P_4 == ControllerElementType.Button && P_0 < Consts.keyboardKeyNames.Count && string.Equals(Consts.keyboardKeyNames[P_0], P_1, StringComparison.Ordinal))
			{
				_key = Consts.keyboardKeyKeys[P_0];
			}
			_elementType = P_4;
			_compoundElementType = CompoundControllerElementType.Axis2D;
		}

		internal ControllerElementIdentifier(ControllerElementIdentifier P_0, bool P_1, ControllerElementType P_2)
			: this(P_0)
		{
			_elementType = P_2;
		}

		public ControllerElementIdentifier Clone()
		{
			return new ControllerElementIdentifier(this);
		}

		public string GetDisplayName(ControllerElementType actualElementType, AxisRange axisRange)
		{
			return actualElementType switch
			{
				ControllerElementType.Axis => axisRange switch
				{
					AxisRange.Full => XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename, 
					AxisRange.Positive => XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName, 
					AxisRange.Negative => XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeName, 
					_ => throw new NotImplementedException(), 
				}, 
				ControllerElementType.Button => XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename, 
				ControllerElementType.CompoundElement => XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename, 
				_ => throw new NotImplementedException(), 
			};
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return GetDisplayName(_elementType, axisRange);
		}

		public object GetGlyph(ControllerElementType actualElementType, AxisRange axisRange)
		{
			return actualElementType switch
			{
				ControllerElementType.Axis => axisRange switch
				{
					AxisRange.Full => ((XAukkdYkRkAZDxUWBprlnhBlowWG)this).glyph, 
					AxisRange.Positive => ((XAukkdYkRkAZDxUWBprlnhBlowWG)this).positiveGlyph, 
					AxisRange.Negative => ((XAukkdYkRkAZDxUWBprlnhBlowWG)this).negativeGlyph, 
					_ => throw new NotImplementedException(), 
				}, 
				ControllerElementType.Button => ((XAukkdYkRkAZDxUWBprlnhBlowWG)this).glyph, 
				ControllerElementType.CompoundElement => ((XAukkdYkRkAZDxUWBprlnhBlowWG)this).glyph, 
				_ => throw new NotImplementedException(), 
			};
		}

		public object GetGlyph(AxisRange axisRange)
		{
			return GetGlyph(_elementType, axisRange);
		}

		public string GetFinalGlyphKey(ControllerElementType actualElementType, AxisRange axisRange)
		{
			return actualElementType switch
			{
				ControllerElementType.Axis => axisRange switch
				{
					AxisRange.Full => finalGlyphKey, 
					AxisRange.Positive => finalPositiveGlyphKey, 
					AxisRange.Negative => finalNegativeGlyphKey, 
					_ => throw new NotImplementedException(), 
				}, 
				ControllerElementType.Button => finalGlyphKey, 
				ControllerElementType.CompoundElement => finalGlyphKey, 
				_ => throw new NotImplementedException(), 
			};
		}

		public string GetFinalGlyphKey(AxisRange axisRange)
		{
			return GetFinalGlyphKey(_elementType, axisRange);
		}

		private void RfTFOySkAZTvZjNaEXRpRARiADOC()
		{
			if (qlPxopXRkKCQgpoCYQrwmHXpoLsp)
			{
				throw new Exception("The object is marked readonly and you are trying to modify its values.");
			}
		}

		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo, ControllerType controllerType)
		{
			YzOLTbnwvyDYNTwIRNXsiSpFGDln = controllerType;
			ToElementNameLocalizerTypes(_elementType, _compoundElementType, out var resultElementType, out var resultCompoundElementType);
			int num = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.pKmJnPnIjYFsvlVnstcPJZTOEgjA(resultElementType, resultCompoundElementType);
			if (num > 0)
			{
				xisaitghnqNnSrgeTLlKHGKAKouXb = new List<VfaeNppcYVIYaHbJDUjcHImQuOjy>(num);
				for (int i = 0; i < num; i++)
				{
					xisaitghnqNnSrgeTLlKHGKAKouXb.Add(new VfaeNppcYVIYaHbJDUjcHImQuOjy());
				}
			}
			VvHxpFPndANZGjhVuumgzUmnDtDD = deviceLocalizationInfo;
			sQRJkNgINrkHPKuXVmNfXjYveqhjA = HMtLwHHjltZtNIbnthVxPUFsBHUt.MEBHftAWTUvgXkAIHhPxhIWnVeDh(this, WxStMCYcNiNtNUkfwzeMmKKPWxSR.ksLCXPCRRURrTfuHEFqedRnKmFmkB(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			zxvSuUWczCbFeMRgacVpezIDXQzwA = qmMKYKokLjiebkvHxJRGIKsndxpJ.aSGXEgcwBJwTSnAcigXqjNAyzIyF(this, WxStMCYcNiNtNUkfwzeMmKKPWxSR.ksLCXPCRRURrTfuHEFqedRnKmFmkB(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			if (_elementType == ControllerElementType.CompoundElement)
			{
				qIjKREKHyhbHiIFiTDmVIBWCycQIA = kdCbPgNHzwxhSYFkXdphdJmXawOiA.RezTTLveYwLxiDxrlApgcqZRzhfd(this, WxStMCYcNiNtNUkfwzeMmKKPWxSR.ksLCXPCRRURrTfuHEFqedRnKmFmkB(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
				YniWkWTcskcmIxgwqVyrygXbhOrs = ovKidfwQWZSKcpUFWfOyBvtrdXiC.ccKrWFeyLoOwNJADBiaRxMsrxFVy(this, WxStMCYcNiNtNUkfwzeMmKKPWxSR.ksLCXPCRRURrTfuHEFqedRnKmFmkB(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			}
		}

		internal int GetSpecialElementData(IList<WJefibNqrccTygrUvaUoQgilVyHX> results)
		{
			if (xisaitghnqNnSrgeTLlKHGKAKouXb == null)
			{
				return 0;
			}
			int count = results.Count;
			int count2 = xisaitghnqNnSrgeTLlKHGKAKouXb.Count;
			for (int i = 0; i < count2; i++)
			{
				results.Add(xisaitghnqNnSrgeTLlKHGKAKouXb[i].HAyxNamEMaRExGdMGCSBhTBceDyGA());
			}
			return results.Count - count;
		}

		internal void AddDisplayOverride(tkciRsKzPisEDUffwbHSifgWVYvQA @override)
		{
			if (@override.AIdDFEvqktCieFMRUYESmBSRpezEA && @override.EXGUsIYQfxBlwEAvwQrZouLmKPnU != this)
			{
				fAGrDNsEUkokJHBSsJnuIGxfmajr.xOLwhwURnCenaPOfEfxmiPRMCkVLA(@override);
			}
		}

		internal bool TryGetDisplayOverride(AxisRange axisRange, out tkciRsKzPisEDUffwbHSifgWVYvQA value, bool ignoreEnabled)
		{
			return fAGrDNsEUkokJHBSsJnuIGxfmajr.wMkdGiqgbffnxyuijIuBEZWlCQoAA(axisRange, out value, ignoreEnabled);
		}

		internal bool IsDisplayOverridden(AxisRange axisRange, bool ignoreEnabled)
		{
			return fAGrDNsEUkokJHBSsJnuIGxfmajr.BEFCZTkZKCnsbVwPAjGLyxcshWxP(axisRange, ignoreEnabled);
		}

		internal void ClearDisplayOverrides()
		{
			fAGrDNsEUkokJHBSsJnuIGxfmajr.uEvEDcvfKWsaEOepOmeEWctHgVfW();
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (xisaitghnqNnSrgeTLlKHGKAKouXb == null || (uint)index >= (uint)xisaitghnqNnSrgeTLlKHGKAKouXb.Count)
			{
				return null;
			}
			return xisaitghnqNnSrgeTLlKHGKAKouXb[index].EEtkNtjQiufpwmLJhEGFCFOXveOs;
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (xisaitghnqNnSrgeTLlKHGKAKouXb == null || (uint)index >= (uint)xisaitghnqNnSrgeTLlKHGKAKouXb.Count)
			{
				return null;
			}
			return xisaitghnqNnSrgeTLlKHGKAKouXb[index].yLJWVHwKWiicqxjssHZMsfaZsxeF;
		}

		string DDLiMrEdceQRXQSrNifvymIZIsut.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (xisaitghnqNnSrgeTLlKHGKAKouXb == null || index >= xisaitghnqNnSrgeTLlKHGKAKouXb.Count)
			{
				return null;
			}
			return xisaitghnqNnSrgeTLlKHGKAKouXb[index].EEtkNtjQiufpwmLJhEGFCFOXveOs;
		}

		void DDLiMrEdceQRXQSrNifvymIZIsut.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (xisaitghnqNnSrgeTLlKHGKAKouXb != null && index < xisaitghnqNnSrgeTLlKHGKAKouXb.Count)
			{
				xisaitghnqNnSrgeTLlKHGKAKouXb[index].EEtkNtjQiufpwmLJhEGFCFOXveOs = value;
			}
		}

		string DDLiMrEdceQRXQSrNifvymIZIsut.GetSpecialElementKey(int index)
		{
			if (xisaitghnqNnSrgeTLlKHGKAKouXb == null || index >= xisaitghnqNnSrgeTLlKHGKAKouXb.Count)
			{
				return null;
			}
			return xisaitghnqNnSrgeTLlKHGKAKouXb[index].yLJWVHwKWiicqxjssHZMsfaZsxeF;
		}

		void DDLiMrEdceQRXQSrNifvymIZIsut.SetSpecialElementKey(int index, string value)
		{
			if (xisaitghnqNnSrgeTLlKHGKAKouXb != null && index < xisaitghnqNnSrgeTLlKHGKAKouXb.Count)
			{
				xisaitghnqNnSrgeTLlKHGKAKouXb[index].yLJWVHwKWiicqxjssHZMsfaZsxeF = value;
			}
		}

		string OVWyLszztvvrzKClxAtUJKzpOUTc.GetSpecialElementKey(int index)
		{
			if (xisaitghnqNnSrgeTLlKHGKAKouXb == null || index >= xisaitghnqNnSrgeTLlKHGKAKouXb.Count)
			{
				return null;
			}
			return xisaitghnqNnSrgeTLlKHGKAKouXb[index].yLJWVHwKWiicqxjssHZMsfaZsxeF;
		}

		void OVWyLszztvvrzKClxAtUJKzpOUTc.SetSpecialElementKey(int index, string value)
		{
			if (xisaitghnqNnSrgeTLlKHGKAKouXb != null && index < xisaitghnqNnSrgeTLlKHGKAKouXb.Count)
			{
				xisaitghnqNnSrgeTLlKHGKAKouXb[index].yLJWVHwKWiicqxjssHZMsfaZsxeF = value;
			}
		}

		string XAukkdYkRkAZDxUWBprlnhBlowWG.GetCompoundElementSpecialName(int index)
		{
			return GetCompoundElementSpecialName(index);
		}

		object XAukkdYkRkAZDxUWBprlnhBlowWG.GetCompoundElementSpecialGlyph(int index)
		{
			return GetCompoundElementSpecialGlyph(index);
		}

		string XAukkdYkRkAZDxUWBprlnhBlowWG.GetCompoundElementSpecialFinalGlyphKey(int index)
		{
			return GetCompoundElementSpecialFinalGlyphKey(index);
		}

		internal static void ToElementNameLocalizerTypes(ControllerElementType type, CompoundControllerElementType compoundType, out rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh resultElementType, out rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS resultCompoundElementType)
		{
			resultCompoundElementType = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.None;
			switch (type)
			{
			case ControllerElementType.Axis:
				resultElementType = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Axis;
				break;
			case ControllerElementType.Button:
				resultElementType = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Button;
				break;
			case ControllerElementType.CompoundElement:
				resultElementType = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.CompoundElement;
				switch (compoundType)
				{
				case CompoundControllerElementType.Axis2D:
					resultCompoundElementType = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.Axis2D;
					break;
				case CompoundControllerElementType.Hat:
					resultCompoundElementType = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.Hat;
					break;
				case CompoundControllerElementType.DPad:
					resultCompoundElementType = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.DPad;
					break;
				default:
					resultElementType = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Unknown;
					break;
				}
				break;
			default:
				resultElementType = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Unknown;
				break;
			}
		}
	}
}
