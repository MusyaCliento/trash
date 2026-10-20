using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	public sealed class UserData
	{
		[CustomObfuscation(rename = false)]
		internal enum DefaultUnityInputSource
		{
			None = 0,
			InputManager = 1,
			SupportsInputSystem = 2,
			RequiresInputSystem = 3
		}

		private static class zdTZDxDBONHdkKlunuIKoLayrsRx
		{
			[DefaultMember("Item")]
			private class UPTLxJFPtKXKTKZJySlCihDrnxXA
			{
				public enum gGyiESGhWdbBFlhLwqrBTsVspnNo
				{
					origId = 0,
					otherId = 1,
					finalId = 2
				}

				public int UTmeIbhyaCuFRXXiRoKszObxcsKv;

				public int HRxJMUtoHMSSeUumJGmaMTqMpwBA;

				public int KhjXjIFGzYqBlLYCRvpUDjwjckYL;

				public int aiFjQFhannbkgadbYHXZzUaBexFV
				{
					get
					{
						return P_0 switch
						{
							gGyiESGhWdbBFlhLwqrBTsVspnNo.origId => UTmeIbhyaCuFRXXiRoKszObxcsKv, 
							gGyiESGhWdbBFlhLwqrBTsVspnNo.otherId => HRxJMUtoHMSSeUumJGmaMTqMpwBA, 
							gGyiESGhWdbBFlhLwqrBTsVspnNo.finalId => KhjXjIFGzYqBlLYCRvpUDjwjckYL, 
							_ => throw new NotImplementedException(), 
						};
					}
					set
					{
						switch (gGyiESGhWdbBFlhLwqrBTsVspnNo2)
						{
						case gGyiESGhWdbBFlhLwqrBTsVspnNo.origId:
							UTmeIbhyaCuFRXXiRoKszObxcsKv = num;
							break;
						case gGyiESGhWdbBFlhLwqrBTsVspnNo.otherId:
							HRxJMUtoHMSSeUumJGmaMTqMpwBA = num;
							break;
						case gGyiESGhWdbBFlhLwqrBTsVspnNo.finalId:
							KhjXjIFGzYqBlLYCRvpUDjwjckYL = num;
							break;
						default:
							throw new NotImplementedException();
						}
					}
				}

				public UPTLxJFPtKXKTKZJySlCihDrnxXA(int P_0, int P_1, int P_2)
				{
					UTmeIbhyaCuFRXXiRoKszObxcsKv = P_0;
					HRxJMUtoHMSSeUumJGmaMTqMpwBA = P_1;
					KhjXjIFGzYqBlLYCRvpUDjwjckYL = P_2;
				}

				public virtual string zyGMkUUqWTpZOuuxgIsFFxvOnqNf()
				{
					return string.Concat(string.Concat("" + StringTools.WriteVar("origId", UTmeIbhyaCuFRXXiRoKszObxcsKv), StringTools.WriteVar("otherId", HRxJMUtoHMSSeUumJGmaMTqMpwBA)), StringTools.WriteVar("finalId", KhjXjIFGzYqBlLYCRvpUDjwjckYL));
				}
			}

			private class AxQBEgzGEbstlAcznxVIEiaFYoVT<_0001>
			{
				public _0001 vjJtMYgopUUpzRWKvUTtGYhAqNLR;

				public _0001 DOCVWQZommvdFdxrPjaSiBDULMUf;

				public UPTLxJFPtKXKTKZJySlCihDrnxXA.gGyiESGhWdbBFlhLwqrBTsVspnNo tLOAQiyKqcGONKeupvHBxMjoQIjwA;

				public IList<_0001> LBVfdjcljocFgyxrlEpssKydqpiA;

				public bool PfswXQrONjtCuAHjZKRabwQBCfIr;

				public AxQBEgzGEbstlAcznxVIEiaFYoVT(_0001 P_0, _0001 P_1, UPTLxJFPtKXKTKZJySlCihDrnxXA.gGyiESGhWdbBFlhLwqrBTsVspnNo P_2, IList<_0001> P_3, bool P_4)
				{
					vjJtMYgopUUpzRWKvUTtGYhAqNLR = P_0;
					DOCVWQZommvdFdxrPjaSiBDULMUf = P_1;
					tLOAQiyKqcGONKeupvHBxMjoQIjwA = P_2;
					LBVfdjcljocFgyxrlEpssKydqpiA = P_3;
					PfswXQrONjtCuAHjZKRabwQBCfIr = P_4;
				}
			}

			[Serializable]
			private sealed class GiuqcIVhtMZudtBYsPfnAMGoyKUn
			{
				public static readonly GiuqcIVhtMZudtBYsPfnAMGoyKUn _003C_003E9 = new GiuqcIVhtMZudtBYsPfnAMGoyKUn();

				public static Func<InputActionCategory, int> _003C_003E9__0_0;

				public static Func<InputActionCategory, string> _003C_003E9__0_1;

				public static Func<InputActionCategory, IList<InputActionCategory>, int> _003C_003E9__0_2;

				public static Func<InputBehavior, int> _003C_003E9__0_4;

				public static Func<InputBehavior, string> _003C_003E9__0_5;

				public static Func<InputBehavior, IList<InputBehavior>, int> _003C_003E9__0_6;

				public static Func<InputAction, int> _003C_003E9__0_8;

				public static Func<InputAction, string> _003C_003E9__0_9;

				public static Func<InputAction, IList<InputAction>, int> _003C_003E9__0_10;

				public static Func<InputMapCategory, int> _003C_003E9__0_47;

				public static Func<InputMapCategory, string> _003C_003E9__0_48;

				public static Func<InputMapCategory, IList<InputMapCategory>, int> _003C_003E9__0_49;

				public static Func<InputLayout, int> _003C_003E9__0_12;

				public static Func<InputLayout, string> _003C_003E9__0_13;

				public static Func<InputLayout, IList<InputLayout>, int> _003C_003E9__0_14;

				public static Func<InputLayout, int> _003C_003E9__0_16;

				public static Func<InputLayout, string> _003C_003E9__0_17;

				public static Func<InputLayout, IList<InputLayout>, int> _003C_003E9__0_18;

				public static Func<InputLayout, int> _003C_003E9__0_20;

				public static Func<InputLayout, string> _003C_003E9__0_21;

				public static Func<InputLayout, IList<InputLayout>, int> _003C_003E9__0_22;

				public static Func<InputLayout, int> _003C_003E9__0_24;

				public static Func<InputLayout, string> _003C_003E9__0_25;

				public static Func<InputLayout, IList<InputLayout>, int> _003C_003E9__0_26;

				public static Func<CustomController_Editor, int> _003C_003E9__0_29;

				public static Func<CustomController_Editor, string> _003C_003E9__0_30;

				public static Func<CustomController_Editor, IList<CustomController_Editor>, int> _003C_003E9__0_31;

				public static Func<ControllerMapLayoutManager_RuleSet_Editor, int> _003C_003E9__0_33;

				public static Func<ControllerMapLayoutManager_RuleSet_Editor, string> _003C_003E9__0_34;

				public static Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int> _003C_003E9__0_35;

				public static Func<ControllerMapEnabler_RuleSet_Editor, int> _003C_003E9__0_37;

				public static Func<ControllerMapEnabler_RuleSet_Editor, string> _003C_003E9__0_38;

				public static Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int> _003C_003E9__0_39;

				public static Func<Player_Editor, int> _003C_003E9__0_41;

				public static Func<Player_Editor, string> _003C_003E9__0_42;

				public static Func<Player_Editor, IList<Player_Editor>, int> _003C_003E9__0_43;

				public static Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> _003C_003E9__0_64;

				public static Func<Player_Editor.CreateControllerInfo, IList<Player_Editor.CreateControllerInfo>, int> _003C_003E9__0_65;

				public static Func<ControllerMap_Editor, int> _003C_003E9__0_66;

				public static Func<ControllerMap_Editor, string> _003C_003E9__0_67;

				public static Func<ActionElementMap, IList<ActionElementMap>, int> _003C_003E9__0_75;

				public static Func<ControllerMap_Editor, int> _003C_003E9__0_76;

				public static Func<ControllerMap_Editor, string> _003C_003E9__0_77;

				public static Func<ActionElementMap, IList<ActionElementMap>, int> _003C_003E9__0_85;

				public static Func<ControllerMap_Editor, int> _003C_003E9__0_86;

				public static Func<ControllerMap_Editor, string> _003C_003E9__0_87;

				public static Func<ActionElementMap, IList<ActionElementMap>, int> _003C_003E9__0_95;

				public static Func<ControllerMap_Editor, int> _003C_003E9__0_96;

				public static Func<ControllerMap_Editor, string> _003C_003E9__0_97;

				public static Func<ActionElementMap, IList<ActionElementMap>, int> _003C_003E9__0_107;

				internal int XApdrQoiGghhrGeoKkNiKBsTFboB(InputActionCategory P_0)
				{
					return P_0.id;
				}

				internal string cIaYSSXJQndmspAabPAyZbcdkEdm(InputActionCategory P_0)
				{
					return P_0.name;
				}

				internal int RXdELvKLsYDsVAkOhkjibBQQzNhQA(InputActionCategory P_0, IList<InputActionCategory> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int NfDRbfYeZMCIYfkkfbdDyHvrDppNA(InputBehavior P_0)
				{
					return P_0.id;
				}

				internal string lHUdnamIcSMQshKnQPKnATbSbJyH(InputBehavior P_0)
				{
					return P_0.name;
				}

				internal int gbuIZxEFKgUyRdwOuKchXOiAwnRI(InputBehavior P_0, IList<InputBehavior> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int YjBfZqaBEKoWpkqRPPwAesGmNCuI(InputAction P_0)
				{
					return P_0.id;
				}

				internal string tCQWsdThxTQumUWEokFwKAMdhyUo(InputAction P_0)
				{
					return P_0.name;
				}

				internal int oEHUZLKSkgPpIYIcOdOmzKrbeEGDA(InputAction P_0, IList<InputAction> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int LTblZPgyosrKNegMuHOLIHArrCeMA(InputMapCategory P_0)
				{
					return P_0.id;
				}

				internal string VzCcjsRIRpRjrBThTQMxSUZOFcag(InputMapCategory P_0)
				{
					return P_0.name;
				}

				internal int EuAgRixkLSJwDSVCdhHuIxqfTnbP(InputMapCategory P_0, IList<InputMapCategory> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int oYrCnqDTAUHIvwijQczgWFBlNlECA(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string qKxpCBPumLQmMuZhusxlMrJjugit(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int tUhQNEHQjXQzYmePRGzMYhxAuBYm(InputLayout P_0, IList<InputLayout> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int EaSCtwWhhMrHhwvTCTGzQNjFuRqU(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string YDvIEdOfMzvlrPezrnZjjNmLJbWW(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int aIAoQXlqgQerSZwtBRniGlAJsflS(InputLayout P_0, IList<InputLayout> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int NFOdLMqgmiUsHRhsjUHOcwueoSOU(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string ZFsBqQAgbDMeXgTIwetJqweNBPFeA(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int sBFNgnyEkcSNDYJMpjaLKnHOYMoFA(InputLayout P_0, IList<InputLayout> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int fGrchXyJKUYQpLITqtfNohNkhkyL(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string HkaCwIDPaogJNemcAFOFaayBvXFUE(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int DZBerIjwBIbDlEUrlRBVHHwLorCbA(InputLayout P_0, IList<InputLayout> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int NdisSiYNRKnSdtdnDJvTvFaWKjZs(CustomController_Editor P_0)
				{
					return P_0.id;
				}

				internal string QCwjNQSlAfeqfTjnSLJeVOodYUcs(CustomController_Editor P_0)
				{
					return P_0.name;
				}

				internal int VNCMRHpzXqNXZeBeIsVLrwDhxqei(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int yiliKZHYnlKTHWoKUzAFVpFjwfME(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string CBfVVcNQjPFYaglkiSANSEoCoNfXA(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int yZwahZCRUUmNmimXDptNZoMeoxfDB(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int bEolsIvHCwuJxreIHsiBKkwsEKKo(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string ZJCuZTwTVDDlzxwXgfuuQrwArXUN(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int IzfegtKGSgueuaihtcSnaQLjxhZHB(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int KPCahghKZCBjGXkxhzRZbyUxvvaC(Player_Editor P_0)
				{
					return P_0.id;
				}

				internal string mQXcfJsizvBSmEYshuYMjIRmZJSx(Player_Editor P_0)
				{
					return P_0.name;
				}

				internal int bFwjCvVWCfqVWcwbvhiqAIuMGFAY(Player_Editor P_0, IList<Player_Editor> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int vJYaXzBrvLijOterEReCJoPBanYN(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i].categoryId == P_0.categoryId && P_1[i].layoutId == P_0.layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal int YUfcFsbqoGGgqbybbcbFwLOLUvgjB(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i].sourceId == P_0.sourceId)
						{
							return i;
						}
					}
					return -1;
				}

				internal int utQTRcxDXGGOBddPOEVDftzgnHrvb(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string YeDRpTYihGklzSayFjIruCYmOqjt(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int CTOmkFLttEQUWdlchqWbPQCIucaX(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i]._keyboardKeyCode == P_0._keyboardKeyCode && P_1[i]._modifierKey1 == P_0._modifierKey1 && P_1[i]._modifierKey2 == P_0._modifierKey2 && P_1[i]._modifierKey3 == P_0._modifierKey3 && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
						{
							return i;
						}
					}
					return -1;
				}

				internal int MttCZGDmsNeNwdBGAFovyAdnVizzb(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string tCZAllFttnlfqNoSwXwQCwMFjAmS(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int JkRfiZekdaWEXhDMryehoKsfhikV(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i]._elementIdentifierId == P_0._elementIdentifierId && P_1[i]._axisRange == P_0._axisRange && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
						{
							return i;
						}
					}
					return -1;
				}

				internal int UtztSjqiVWLNPYXMxqeKMdFErKvQ(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string BRDAUiMtejDtSGEEXQsTvBuqvYYBA(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int iVwyLCJlxUfZwEQQbpCNBXCFgAyIA(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i]._elementIdentifierId == P_0._elementIdentifierId && P_1[i]._axisRange == P_0._axisRange && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
						{
							return i;
						}
					}
					return -1;
				}

				internal int hetxyHyTajuseraDZQPdxECJDyjO(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string HUBkNzDxXDfvqXjginTzqdihwZNj(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int sVJcOoifWPWNWdgMMfKDPxuiNMrmA(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i]._elementIdentifierId == P_0._elementIdentifierId && P_1[i]._axisRange == P_0._axisRange && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
						{
							return i;
						}
					}
					return -1;
				}
			}

			private sealed class FSaPiKwOgGIHvgTAgfWfQvEkELLrA
			{
				public UserData rfuZeftMcJIRNKzElBWdCwYEPOccB;

				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> TEzgvGkSjOcJZzTYLxWXRbwOwwBk;

				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> rArRupacbakiDlKsJEsVHvlgUXFPA;

				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> yiDfpbDBwReSOobbdoJMjjEdmEebA;

				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> VzBUARGIjLXharPidqnPprATjuWJ;

				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> xpnibmKtgyPwaKMgbxBImipLXsB;

				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> lVFObkhSbZINMNXXsmuOopgaYvHD;

				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> CvHGdpixazlqJIEeerHebZldRPnRb;

				public Func<ControllerType, List<UPTLxJFPtKXKTKZJySlCihDrnxXA>> yrDzUoAUGJbKDLEWLjmIrhwVxFfV;

				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> pktQslGYMXhxcpmwOOCDlWZmdSPj;

				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> RswAbxJHVQvXSUIYNzHLcGykXplb;

				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> bRfCRUANIiyYrEmHYMQeMsKCZsMPA;

				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> mklBSEYptpWNCvbKGOCHXGlSGoVk;

				internal InputActionCategory IiPpGeJkIWIwAlvwsNilzUDCejXu(AxQBEgzGEbstlAcznxVIEiaFYoVT<InputActionCategory> P_0)
				{
					InputActionCategory inputActionCategory = JsonTools.Clone(P_0.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					InputActionCategory inputActionCategory2;
					if (P_0.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						inputActionCategory2 = P_0.DOCVWQZommvdFdxrPjaSiBDULMUf;
					}
					else
					{
						rfuZeftMcJIRNKzElBWdCwYEPOccB.AddActionCategory();
						inputActionCategory2 = P_0.LBVfdjcljocFgyxrlEpssKydqpiA[P_0.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					inputActionCategory.id = inputActionCategory2.id;
					int index = P_0.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(inputActionCategory2);
					P_0.LBVfdjcljocFgyxrlEpssKydqpiA[index] = inputActionCategory;
					return inputActionCategory;
				}

				internal InputBehavior CMGGjfuDtdaCwFQSMJqqUgTCHAukA(AxQBEgzGEbstlAcznxVIEiaFYoVT<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					InputBehavior inputBehavior2;
					if (P_0.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						inputBehavior2 = P_0.DOCVWQZommvdFdxrPjaSiBDULMUf;
					}
					else
					{
						rfuZeftMcJIRNKzElBWdCwYEPOccB.AddInputBehavior();
						inputBehavior2 = P_0.LBVfdjcljocFgyxrlEpssKydqpiA[P_0.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					inputBehavior.id = inputBehavior2.id;
					int index = P_0.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(inputBehavior2);
					P_0.LBVfdjcljocFgyxrlEpssKydqpiA[index] = inputBehavior;
					return inputBehavior;
				}

				internal InputAction npnYGjpmoRwYBRUJHxMNYqBnMQKJ(AxQBEgzGEbstlAcznxVIEiaFYoVT<InputAction> P_0)
				{
					hydcatHLHbhoSIzruEzwtkmOqyaN hydcatHLHbhoSIzruEzwtkmOqyaN2 = new hydcatHLHbhoSIzruEzwtkmOqyaN();
					hydcatHLHbhoSIzruEzwtkmOqyaN2.cFUsxymLuqIVEzQRbVqSJJBVJnmq = P_0;
					InputAction inputAction = JsonTools.Clone(hydcatHLHbhoSIzruEzwtkmOqyaN2.cFUsxymLuqIVEzQRbVqSJJBVJnmq.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					int num = TEzgvGkSjOcJZzTYLxWXRbwOwwBk.Find(hydcatHLHbhoSIzruEzwtkmOqyaN2.PKAgffnbXfhIHCphQhYTvAZjQYlj)?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? 0;
					InputAction inputAction2;
					if (hydcatHLHbhoSIzruEzwtkmOqyaN2.cFUsxymLuqIVEzQRbVqSJJBVJnmq.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						inputAction2 = hydcatHLHbhoSIzruEzwtkmOqyaN2.cFUsxymLuqIVEzQRbVqSJJBVJnmq.DOCVWQZommvdFdxrPjaSiBDULMUf;
					}
					else
					{
						rfuZeftMcJIRNKzElBWdCwYEPOccB.AddAction(num);
						inputAction2 = hydcatHLHbhoSIzruEzwtkmOqyaN2.cFUsxymLuqIVEzQRbVqSJJBVJnmq.LBVfdjcljocFgyxrlEpssKydqpiA[hydcatHLHbhoSIzruEzwtkmOqyaN2.cFUsxymLuqIVEzQRbVqSJJBVJnmq.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					int num2 = rArRupacbakiDlKsJEsVHvlgUXFPA.Find(hydcatHLHbhoSIzruEzwtkmOqyaN2.cyaPBRNXCstaIVEwveKuJKqiTMrc)?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? 0;
					inputAction.id = inputAction2.id;
					if (num != inputAction2.categoryId)
					{
						rfuZeftMcJIRNKzElBWdCwYEPOccB.ChangeActionCategory(inputAction2.id, num);
					}
					inputAction.categoryId = num;
					inputAction.behaviorId = num2;
					int index = hydcatHLHbhoSIzruEzwtkmOqyaN2.cFUsxymLuqIVEzQRbVqSJJBVJnmq.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(inputAction2);
					hydcatHLHbhoSIzruEzwtkmOqyaN2.cFUsxymLuqIVEzQRbVqSJJBVJnmq.LBVfdjcljocFgyxrlEpssKydqpiA[index] = inputAction;
					return inputAction;
				}

				internal InputLayout UKlzHvhCbbtqaSMXyglDJbYBNeBdb(AxQBEgzGEbstlAcznxVIEiaFYoVT<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					InputLayout inputLayout2;
					if (P_0.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						inputLayout2 = P_0.DOCVWQZommvdFdxrPjaSiBDULMUf;
					}
					else
					{
						rfuZeftMcJIRNKzElBWdCwYEPOccB.AddKeyboardLayout();
						inputLayout2 = P_0.LBVfdjcljocFgyxrlEpssKydqpiA[P_0.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(inputLayout2);
					P_0.LBVfdjcljocFgyxrlEpssKydqpiA[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout kAIiQRMtuorcxOPLbipAqLDowCEb(AxQBEgzGEbstlAcznxVIEiaFYoVT<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					InputLayout inputLayout2;
					if (P_0.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						inputLayout2 = P_0.DOCVWQZommvdFdxrPjaSiBDULMUf;
					}
					else
					{
						rfuZeftMcJIRNKzElBWdCwYEPOccB.AddMouseLayout();
						inputLayout2 = P_0.LBVfdjcljocFgyxrlEpssKydqpiA[P_0.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(inputLayout2);
					P_0.LBVfdjcljocFgyxrlEpssKydqpiA[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout eikcKtQCpEfmpSKQLIlARRFAPFfO(AxQBEgzGEbstlAcznxVIEiaFYoVT<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					InputLayout inputLayout2;
					if (P_0.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						inputLayout2 = P_0.DOCVWQZommvdFdxrPjaSiBDULMUf;
					}
					else
					{
						rfuZeftMcJIRNKzElBWdCwYEPOccB.AddJoystickLayout();
						inputLayout2 = P_0.LBVfdjcljocFgyxrlEpssKydqpiA[P_0.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(inputLayout2);
					P_0.LBVfdjcljocFgyxrlEpssKydqpiA[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout SJlFHrsnzdgfznapjYETVolKGiFy(AxQBEgzGEbstlAcznxVIEiaFYoVT<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					InputLayout inputLayout2;
					if (P_0.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						inputLayout2 = P_0.DOCVWQZommvdFdxrPjaSiBDULMUf;
					}
					else
					{
						rfuZeftMcJIRNKzElBWdCwYEPOccB.AddCustomControllerLayout();
						inputLayout2 = P_0.LBVfdjcljocFgyxrlEpssKydqpiA[P_0.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(inputLayout2);
					P_0.LBVfdjcljocFgyxrlEpssKydqpiA[index] = inputLayout;
					return inputLayout;
				}

				internal List<UPTLxJFPtKXKTKZJySlCihDrnxXA> GNuADyAzZiqKNjtlBVAsUVNHcewD(ControllerType P_0)
				{
					return P_0 switch
					{
						ControllerType.Keyboard => yiDfpbDBwReSOobbdoJMjjEdmEebA, 
						ControllerType.Mouse => VzBUARGIjLXharPidqnPprATjuWJ, 
						ControllerType.Joystick => xpnibmKtgyPwaKMgbxBImipLXsB, 
						ControllerType.Custom => lVFObkhSbZINMNXXsmuOopgaYvHD, 
						_ => throw new NotImplementedException(), 
					};
				}

				internal CustomController_Editor SJRGsMvIqgCkJmAKpVOXkDAtaTqq(AxQBEgzGEbstlAcznxVIEiaFYoVT<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					CustomController_Editor customController_Editor2;
					if (P_0.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						customController_Editor2 = P_0.DOCVWQZommvdFdxrPjaSiBDULMUf;
					}
					else
					{
						rfuZeftMcJIRNKzElBWdCwYEPOccB.AddCustomController(Guid.Empty);
						customController_Editor2 = P_0.LBVfdjcljocFgyxrlEpssKydqpiA[P_0.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					customController_Editor.id = customController_Editor2.id;
					int index = P_0.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(customController_Editor2);
					P_0.LBVfdjcljocFgyxrlEpssKydqpiA[index] = customController_Editor;
					return customController_Editor;
				}

				internal ControllerMapLayoutManager_RuleSet_Editor EIflEzjFqbakGWWtnBYMgsXwhWYAb(AxQBEgzGEbstlAcznxVIEiaFYoVT<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					SHpIngwCXZnelGKhqJxXFDlhhyEq sHpIngwCXZnelGKhqJxXFDlhhyEq = new SHpIngwCXZnelGKhqJxXFDlhhyEq();
					sHpIngwCXZnelGKhqJxXFDlhhyEq.SGzXMJBBYbPPJDcivHpkmxfQLyUk = P_0;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(sHpIngwCXZnelGKhqJxXFDlhhyEq.SGzXMJBBYbPPJDcivHpkmxfQLyUk.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					int num = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int i = 0; i < num; i++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor = controllerMapLayoutManager_RuleSet_Editor.rules[i];
						if (controllerMapLayoutManager_Rule_Editor == null || controllerMapLayoutManager_Rule_Editor.categoryIds == null)
						{
							continue;
						}
						List<int> list = new List<int>();
						int num2 = ((controllerMapLayoutManager_Rule_Editor.categoryIds != null) ? controllerMapLayoutManager_Rule_Editor.categoryIds.Count : 0);
						for (int j = 0; j < num2; j++)
						{
							fLCbsfmbffKZOyJlxDbtdcQeInhs fLCbsfmbffKZOyJlxDbtdcQeInhs2 = new fLCbsfmbffKZOyJlxDbtdcQeInhs();
							fLCbsfmbffKZOyJlxDbtdcQeInhs2.vcCxQFgrubDVlnxnOnStFxRGpArU = sHpIngwCXZnelGKhqJxXFDlhhyEq;
							fLCbsfmbffKZOyJlxDbtdcQeInhs2.ZLRqVAJGEywyfcvvGHMVnbxlFOMIA = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
							UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = CvHGdpixazlqJIEeerHebZldRPnRb.Find(fLCbsfmbffKZOyJlxDbtdcQeInhs2.NxtiSdgRpCAIgBfyTdqXiNKPpWES);
							if (uPTLxJFPtKXKTKZJySlCihDrnxXA == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + fLCbsfmbffKZOyJlxDbtdcQeInhs2.ZLRqVAJGEywyfcvvGHMVnbxlFOMIA);
							}
							else
							{
								list.Add(uPTLxJFPtKXKTKZJySlCihDrnxXA.KhjXjIFGzYqBlLYCRvpUDjwjckYL);
							}
						}
						controllerMapLayoutManager_Rule_Editor.categoryIds = list;
					}
					int num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num3; k++)
					{
						XCCBKFBBlCZiGNIpmBtKcvLXvLkjb xCCBKFBBlCZiGNIpmBtKcvLXvLkjb = new XCCBKFBBlCZiGNIpmBtKcvLXvLkjb();
						xCCBKFBBlCZiGNIpmBtKcvLXvLkjb.GemWDMKHfHoCKcvtErBREcgffvaBA = sHpIngwCXZnelGKhqJxXFDlhhyEq;
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
						if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
						{
							ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
							List<UPTLxJFPtKXKTKZJySlCihDrnxXA> list2 = yrDzUoAUGJbKDLEWLjmIrhwVxFfV(controllerType);
							xCCBKFBBlCZiGNIpmBtKcvLXvLkjb.DobBMhjANUVNdmNmiKqhFoboQpxsA = controllerMapLayoutManager_Rule_Editor2.layoutId;
							UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA2 = list2.Find(xCCBKFBBlCZiGNIpmBtKcvLXvLkjb.uIZnQzAlMojyfqrTQyvWgowtSssF);
							if (uPTLxJFPtKXKTKZJySlCihDrnxXA2 == null)
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + xCCBKFBBlCZiGNIpmBtKcvLXvLkjb.DobBMhjANUVNdmNmiKqhFoboQpxsA);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = uPTLxJFPtKXKTKZJySlCihDrnxXA2.KhjXjIFGzYqBlLYCRvpUDjwjckYL;
							}
						}
					}
					int num4 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int l = 0; l < num4; l++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[l];
						if (controllerMapLayoutManager_Rule_Editor3 != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							QVZRRLJtkgvcGVcNFcYsxltUuEHT qVZRRLJtkgvcGVcNFcYsxltUuEHT = new QVZRRLJtkgvcGVcNFcYsxltUuEHT();
							qVZRRLJtkgvcGVcNFcYsxltUuEHT.CfacMQRvCpInKdlXUSBqvikytEgS = sHpIngwCXZnelGKhqJxXFDlhhyEq;
							List<UPTLxJFPtKXKTKZJySlCihDrnxXA> list3 = pktQslGYMXhxcpmwOOCDlWZmdSPj;
							qVZRRLJtkgvcGVcNFcYsxltUuEHT.wUHaNKfiXkVmkKOOADlDOUJKHadE = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA3 = list3.Find(qVZRRLJtkgvcGVcNFcYsxltUuEHT.HjNtLieNKEkAWAFzKEElypBgHmZS);
							if (uPTLxJFPtKXKTKZJySlCihDrnxXA3 == null)
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + qVZRRLJtkgvcGVcNFcYsxltUuEHT.wUHaNKfiXkVmkKOOADlDOUJKHadE);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = uPTLxJFPtKXKTKZJySlCihDrnxXA3.KhjXjIFGzYqBlLYCRvpUDjwjckYL;
							}
						}
					}
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
					if (sHpIngwCXZnelGKhqJxXFDlhhyEq.SGzXMJBBYbPPJDcivHpkmxfQLyUk.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						controllerMapLayoutManager_RuleSet_Editor2 = sHpIngwCXZnelGKhqJxXFDlhhyEq.SGzXMJBBYbPPJDcivHpkmxfQLyUk.DOCVWQZommvdFdxrPjaSiBDULMUf;
					}
					else
					{
						rfuZeftMcJIRNKzElBWdCwYEPOccB.AddControllerMapLayoutManagerRuleSet();
						controllerMapLayoutManager_RuleSet_Editor2 = sHpIngwCXZnelGKhqJxXFDlhhyEq.SGzXMJBBYbPPJDcivHpkmxfQLyUk.LBVfdjcljocFgyxrlEpssKydqpiA[sHpIngwCXZnelGKhqJxXFDlhhyEq.SGzXMJBBYbPPJDcivHpkmxfQLyUk.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
					int index = sHpIngwCXZnelGKhqJxXFDlhhyEq.SGzXMJBBYbPPJDcivHpkmxfQLyUk.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
					sHpIngwCXZnelGKhqJxXFDlhhyEq.SGzXMJBBYbPPJDcivHpkmxfQLyUk.LBVfdjcljocFgyxrlEpssKydqpiA[index] = controllerMapLayoutManager_RuleSet_Editor;
					return controllerMapLayoutManager_RuleSet_Editor;
				}

				internal ControllerMapEnabler_RuleSet_Editor iQyXZPjGpboxEoZeipplTUgFvlti(AxQBEgzGEbstlAcznxVIEiaFYoVT<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					JWZbdssgcIRVSoqDPsLyJhWOSOpm jWZbdssgcIRVSoqDPsLyJhWOSOpm = new JWZbdssgcIRVSoqDPsLyJhWOSOpm();
					jWZbdssgcIRVSoqDPsLyJhWOSOpm.cmlRpyDVelLgASMnZiPDbJOgbPufA = P_0;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(jWZbdssgcIRVSoqDPsLyJhWOSOpm.cmlRpyDVelLgASMnZiPDbJOgbPufA.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					int num = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
					for (int i = 0; i < num; i++)
					{
						ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor = controllerMapEnabler_RuleSet_Editor.rules[i];
						if (controllerMapEnabler_Rule_Editor == null || controllerMapEnabler_Rule_Editor.categoryIds == null)
						{
							continue;
						}
						List<int> list = new List<int>();
						for (int j = 0; j < controllerMapEnabler_Rule_Editor.categoryIds.Count; j++)
						{
							xIYcsUpNqueAxfCPfOQgBhRRRTug xIYcsUpNqueAxfCPfOQgBhRRRTug2 = new xIYcsUpNqueAxfCPfOQgBhRRRTug();
							xIYcsUpNqueAxfCPfOQgBhRRRTug2.OogFqBGYzIWxXrwhWJCgFfbEbbyYA = jWZbdssgcIRVSoqDPsLyJhWOSOpm;
							xIYcsUpNqueAxfCPfOQgBhRRRTug2.fLOeUhseWpVCauQJdSuSeZvlbRMA = controllerMapEnabler_Rule_Editor.categoryIds[j];
							UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = CvHGdpixazlqJIEeerHebZldRPnRb.Find(xIYcsUpNqueAxfCPfOQgBhRRRTug2.XgMHkRINXzalQimomcNKDSmFcaqHB);
							if (uPTLxJFPtKXKTKZJySlCihDrnxXA == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + xIYcsUpNqueAxfCPfOQgBhRRRTug2.fLOeUhseWpVCauQJdSuSeZvlbRMA);
							}
							else
							{
								list.Add(uPTLxJFPtKXKTKZJySlCihDrnxXA.KhjXjIFGzYqBlLYCRvpUDjwjckYL);
							}
						}
						controllerMapEnabler_Rule_Editor.categoryIds = list;
					}
					int num2 = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num2; k++)
					{
						ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor2 = controllerMapEnabler_RuleSet_Editor.rules[k];
						if (controllerMapEnabler_Rule_Editor2 == null || controllerMapEnabler_Rule_Editor2.layoutIds == null)
						{
							continue;
						}
						ControllerType controllerType = controllerMapEnabler_Rule_Editor2.controllerSetSelector.controllerType;
						List<UPTLxJFPtKXKTKZJySlCihDrnxXA> list2 = yrDzUoAUGJbKDLEWLjmIrhwVxFfV(controllerType);
						List<int> list3 = new List<int>();
						int num3 = ((controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0);
						for (int l = 0; l < num3; l++)
						{
							VhGwzkeIeixrOaEHjQuWnopOOktA vhGwzkeIeixrOaEHjQuWnopOOktA = new VhGwzkeIeixrOaEHjQuWnopOOktA();
							vhGwzkeIeixrOaEHjQuWnopOOktA.HEuKjzcwPlnYpVVpteXkcPJctqdt = jWZbdssgcIRVSoqDPsLyJhWOSOpm;
							vhGwzkeIeixrOaEHjQuWnopOOktA.UNNaFpKqEuYXTULbfKqVusdsrsKR = controllerMapEnabler_Rule_Editor2.layoutIds[l];
							UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA2 = list2.Find(vhGwzkeIeixrOaEHjQuWnopOOktA.bYmWYGNuWMFFkRYJUaJTuzCVizmt);
							if (uPTLxJFPtKXKTKZJySlCihDrnxXA2 == null)
							{
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + vhGwzkeIeixrOaEHjQuWnopOOktA.UNNaFpKqEuYXTULbfKqVusdsrsKR);
							}
							else
							{
								list3.Add(uPTLxJFPtKXKTKZJySlCihDrnxXA2.KhjXjIFGzYqBlLYCRvpUDjwjckYL);
							}
						}
						controllerMapEnabler_Rule_Editor2.layoutIds = list3;
					}
					int num4 = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
					for (int m = 0; m < num4; m++)
					{
						ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor3 = controllerMapEnabler_RuleSet_Editor.rules[m];
						if (controllerMapEnabler_Rule_Editor3 != null && controllerMapEnabler_Rule_Editor3.controllerSetSelector != null && controllerMapEnabler_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							UeWjxSdiPIdnvrGDHsIqeCCbceYKB ueWjxSdiPIdnvrGDHsIqeCCbceYKB = new UeWjxSdiPIdnvrGDHsIqeCCbceYKB();
							ueWjxSdiPIdnvrGDHsIqeCCbceYKB.bSLQHvccXQVVueQvSfrbPIJJviFr = jWZbdssgcIRVSoqDPsLyJhWOSOpm;
							List<UPTLxJFPtKXKTKZJySlCihDrnxXA> list4 = pktQslGYMXhxcpmwOOCDlWZmdSPj;
							ueWjxSdiPIdnvrGDHsIqeCCbceYKB.eOPkMREASXdDlqvCICLWJQeWZEIy = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA3 = list4.Find(ueWjxSdiPIdnvrGDHsIqeCCbceYKB.UIuGHayHLLaASJbkUwZMfdepojVNA);
							if (uPTLxJFPtKXKTKZJySlCihDrnxXA3 == null)
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + ueWjxSdiPIdnvrGDHsIqeCCbceYKB.eOPkMREASXdDlqvCICLWJQeWZEIy);
							}
							else
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = uPTLxJFPtKXKTKZJySlCihDrnxXA3.KhjXjIFGzYqBlLYCRvpUDjwjckYL;
							}
						}
					}
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
					if (jWZbdssgcIRVSoqDPsLyJhWOSOpm.cmlRpyDVelLgASMnZiPDbJOgbPufA.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						controllerMapEnabler_RuleSet_Editor2 = jWZbdssgcIRVSoqDPsLyJhWOSOpm.cmlRpyDVelLgASMnZiPDbJOgbPufA.DOCVWQZommvdFdxrPjaSiBDULMUf;
					}
					else
					{
						rfuZeftMcJIRNKzElBWdCwYEPOccB.AddControllerMapEnablerRuleSet();
						controllerMapEnabler_RuleSet_Editor2 = jWZbdssgcIRVSoqDPsLyJhWOSOpm.cmlRpyDVelLgASMnZiPDbJOgbPufA.LBVfdjcljocFgyxrlEpssKydqpiA[jWZbdssgcIRVSoqDPsLyJhWOSOpm.cmlRpyDVelLgASMnZiPDbJOgbPufA.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
					int index = jWZbdssgcIRVSoqDPsLyJhWOSOpm.cmlRpyDVelLgASMnZiPDbJOgbPufA.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(controllerMapEnabler_RuleSet_Editor2);
					jWZbdssgcIRVSoqDPsLyJhWOSOpm.cmlRpyDVelLgASMnZiPDbJOgbPufA.LBVfdjcljocFgyxrlEpssKydqpiA[index] = controllerMapEnabler_RuleSet_Editor;
					return controllerMapEnabler_RuleSet_Editor;
				}

				internal Player_Editor JgbcylATbpJpVXDPxfryJxNhtVNdA(AxQBEgzGEbstlAcznxVIEiaFYoVT<Player_Editor> P_0)
				{
					kkvvrRbHfAcNpjVADutvgoQlBRWV kkvvrRbHfAcNpjVADutvgoQlBRWV2 = new kkvvrRbHfAcNpjVADutvgoQlBRWV();
					kkvvrRbHfAcNpjVADutvgoQlBRWV2.gQhwEbWWQacvzimJxXctTfKwVAXO = this;
					kkvvrRbHfAcNpjVADutvgoQlBRWV2.OBOZTZihcYUzKNMLcIaUgwNuFlMC = P_0;
					Player_Editor player_Editor = JsonTools.Clone(kkvvrRbHfAcNpjVADutvgoQlBRWV2.OBOZTZihcYUzKNMLcIaUgwNuFlMC.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					Action<List<Player_Editor.Mapping>, List<UPTLxJFPtKXKTKZJySlCihDrnxXA>> action = kkvvrRbHfAcNpjVADutvgoQlBRWV2.CMptaxMpJfCBiFZiRPTJKKwRAvJfA;
					action(player_Editor.defaultKeyboardMaps, yiDfpbDBwReSOobbdoJMjjEdmEebA);
					action(player_Editor.defaultMouseMaps, VzBUARGIjLXharPidqnPprATjuWJ);
					action(player_Editor.defaultJoystickMaps, xpnibmKtgyPwaKMgbxBImipLXsB);
					action(player_Editor.defaultCustomControllerMaps, lVFObkhSbZINMNXXsmuOopgaYvHD);
					for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
					{
						VvYcjwPirIieoKjGNLYnyMdboAny vvYcjwPirIieoKjGNLYnyMdboAny = new VvYcjwPirIieoKjGNLYnyMdboAny();
						vvYcjwPirIieoKjGNLYnyMdboAny.wvnmIIHqgBkXDQTdKlaxktKhsqIo = kkvvrRbHfAcNpjVADutvgoQlBRWV2;
						vvYcjwPirIieoKjGNLYnyMdboAny.huNydbZyTjgYUslWdasdMOzNRfeP = player_Editor.startingCustomControllers[i];
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = pktQslGYMXhxcpmwOOCDlWZmdSPj.Find(vvYcjwPirIieoKjGNLYnyMdboAny.yCYeknCHBuHYTpwvMIGWmYRyFiBA);
						vvYcjwPirIieoKjGNLYnyMdboAny.huNydbZyTjgYUslWdasdMOzNRfeP.sourceId = uPTLxJFPtKXKTKZJySlCihDrnxXA?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
					}
					List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					for (int j = 0; j < ruleSets.Count; j++)
					{
						BhDnDqohPUAeyhRsHfYiirHrtYDD bhDnDqohPUAeyhRsHfYiirHrtYDD = new BhDnDqohPUAeyhRsHfYiirHrtYDD();
						bhDnDqohPUAeyhRsHfYiirHrtYDD.OXVFdNxwbMehNaRnbefJPouPFGgLA = kkvvrRbHfAcNpjVADutvgoQlBRWV2;
						Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
						if (ruleSetMapping != null)
						{
							bhDnDqohPUAeyhRsHfYiirHrtYDD.vnTYRofvzyioObLWBAwNcYxkLbtNA = ruleSetMapping.id;
							UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA2 = RswAbxJHVQvXSUIYNzHLcGykXplb.Find(bhDnDqohPUAeyhRsHfYiirHrtYDD.JRFKEGGLbpKSZQddsAbnKhvNvyhHA);
							if (uPTLxJFPtKXKTKZJySlCihDrnxXA2 == null)
							{
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + bhDnDqohPUAeyhRsHfYiirHrtYDD.vnTYRofvzyioObLWBAwNcYxkLbtNA);
								continue;
							}
							ruleSetMapping = ruleSetMapping.Clone();
							ruleSetMapping.id = uPTLxJFPtKXKTKZJySlCihDrnxXA2.KhjXjIFGzYqBlLYCRvpUDjwjckYL;
							list.Add(ruleSetMapping);
						}
					}
					player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
					List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
					for (int k = 0; k < ruleSets2.Count; k++)
					{
						WRwqhADOSBgYIXqKWQbiKtpGDzHF wRwqhADOSBgYIXqKWQbiKtpGDzHF = new WRwqhADOSBgYIXqKWQbiKtpGDzHF();
						wRwqhADOSBgYIXqKWQbiKtpGDzHF.jOETlOZZejraBhnGVSmKrelCnHJl = kkvvrRbHfAcNpjVADutvgoQlBRWV2;
						Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
						if (ruleSetMapping2 != null)
						{
							wRwqhADOSBgYIXqKWQbiKtpGDzHF.qEzAvjbRcGfWrpYBOTScbzDAcRkmA = ruleSetMapping2.id;
							UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA3 = bRfCRUANIiyYrEmHYMQeMsKCZsMPA.Find(wRwqhADOSBgYIXqKWQbiKtpGDzHF.TocUTKPhvKSRJULkmpbylTqSVNDK);
							if (uPTLxJFPtKXKTKZJySlCihDrnxXA3 == null)
							{
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + wRwqhADOSBgYIXqKWQbiKtpGDzHF.qEzAvjbRcGfWrpYBOTScbzDAcRkmA);
								continue;
							}
							ruleSetMapping2 = ruleSetMapping2.Clone();
							ruleSetMapping2.id = uPTLxJFPtKXKTKZJySlCihDrnxXA3.KhjXjIFGzYqBlLYCRvpUDjwjckYL;
							list2.Add(ruleSetMapping2);
						}
					}
					player_Editor.controllerMapEnablerSettings.ruleSets = list2;
					Player_Editor player_Editor2;
					if (kkvvrRbHfAcNpjVADutvgoQlBRWV2.OBOZTZihcYUzKNMLcIaUgwNuFlMC.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						player_Editor2 = kkvvrRbHfAcNpjVADutvgoQlBRWV2.OBOZTZihcYUzKNMLcIaUgwNuFlMC.DOCVWQZommvdFdxrPjaSiBDULMUf;
						Player_Editor player_Editor3 = JsonTools.Clone(player_Editor);
						player_Editor3.defaultKeyboardMaps.Clear();
						player_Editor3.defaultMouseMaps.Clear();
						player_Editor3.defaultJoystickMaps.Clear();
						player_Editor3.defaultCustomControllerMaps.Clear();
						player_Editor3.startingCustomControllers.Clear();
						Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.vJYaXzBrvLijOterEReCJoPBanYN;
						AfOnCEEhiyXLFqwsvnNLrOujTfVi(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
						AfOnCEEhiyXLFqwsvnNLrOujTfVi(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
						AfOnCEEhiyXLFqwsvnNLrOujTfVi(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
						AfOnCEEhiyXLFqwsvnNLrOujTfVi(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
						AfOnCEEhiyXLFqwsvnNLrOujTfVi(player_Editor2.startingCustomControllers, player_Editor.startingCustomControllers, player_Editor3.startingCustomControllers, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.YUfcFsbqoGGgqbybbcbFwLOLUvgjB);
						player_Editor = player_Editor3;
					}
					else
					{
						rfuZeftMcJIRNKzElBWdCwYEPOccB.AddPlayer();
						player_Editor2 = kkvvrRbHfAcNpjVADutvgoQlBRWV2.OBOZTZihcYUzKNMLcIaUgwNuFlMC.LBVfdjcljocFgyxrlEpssKydqpiA[kkvvrRbHfAcNpjVADutvgoQlBRWV2.OBOZTZihcYUzKNMLcIaUgwNuFlMC.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					player_Editor.id = player_Editor2.id;
					int index = kkvvrRbHfAcNpjVADutvgoQlBRWV2.OBOZTZihcYUzKNMLcIaUgwNuFlMC.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(player_Editor2);
					kkvvrRbHfAcNpjVADutvgoQlBRWV2.OBOZTZihcYUzKNMLcIaUgwNuFlMC.LBVfdjcljocFgyxrlEpssKydqpiA[index] = player_Editor;
					return player_Editor;
				}
			}

			private sealed class hydcatHLHbhoSIzruEzwtkmOqyaN
			{
				public AxQBEgzGEbstlAcznxVIEiaFYoVT<InputAction> cFUsxymLuqIVEzQRbVqSJJBVJnmq;

				internal bool PKAgffnbXfhIHCphQhYTvAZjQYlj(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(cFUsxymLuqIVEzQRbVqSJJBVJnmq.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == cFUsxymLuqIVEzQRbVqSJJBVJnmq.vjJtMYgopUUpzRWKvUTtGYhAqNLR.categoryId;
				}

				internal bool cyaPBRNXCstaIVEwveKuJKqiTMrc(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(cFUsxymLuqIVEzQRbVqSJJBVJnmq.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == cFUsxymLuqIVEzQRbVqSJJBVJnmq.vjJtMYgopUUpzRWKvUTtGYhAqNLR.behaviorId;
				}
			}

			private sealed class VhGwzkeIeixrOaEHjQuWnopOOktA
			{
				public int UNNaFpKqEuYXTULbfKqVusdsrsKR;

				public JWZbdssgcIRVSoqDPsLyJhWOSOpm HEuKjzcwPlnYpVVpteXkcPJctqdt;

				internal bool bYmWYGNuWMFFkRYJUaJTuzCVizmt(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(HEuKjzcwPlnYpVVpteXkcPJctqdt.cmlRpyDVelLgASMnZiPDbJOgbPufA.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == UNNaFpKqEuYXTULbfKqVusdsrsKR;
				}
			}

			private sealed class UeWjxSdiPIdnvrGDHsIqeCCbceYKB
			{
				public int eOPkMREASXdDlqvCICLWJQeWZEIy;

				public JWZbdssgcIRVSoqDPsLyJhWOSOpm bSLQHvccXQVVueQvSfrbPIJJviFr;

				internal bool UIuGHayHLLaASJbkUwZMfdepojVNA(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(bSLQHvccXQVVueQvSfrbPIJJviFr.cmlRpyDVelLgASMnZiPDbJOgbPufA.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == eOPkMREASXdDlqvCICLWJQeWZEIy;
				}
			}

			private sealed class kkvvrRbHfAcNpjVADutvgoQlBRWV
			{
				public AxQBEgzGEbstlAcznxVIEiaFYoVT<Player_Editor> OBOZTZihcYUzKNMLcIaUgwNuFlMC;

				public FSaPiKwOgGIHvgTAgfWfQvEkELLrA gQhwEbWWQacvzimJxXctTfKwVAXO;

				internal void CMptaxMpJfCBiFZiRPTJKKwRAvJfA(List<Player_Editor.Mapping> P_0, List<UPTLxJFPtKXKTKZJySlCihDrnxXA> P_1)
				{
					for (int i = 0; i < P_0.Count; i++)
					{
						pfAUmGBAXbvZdfBvmvFTMcoBcEUA pfAUmGBAXbvZdfBvmvFTMcoBcEUA2 = new pfAUmGBAXbvZdfBvmvFTMcoBcEUA();
						pfAUmGBAXbvZdfBvmvFTMcoBcEUA2.nKbHTMgACCmqoKlPuyQdeVEbReTR = this;
						pfAUmGBAXbvZdfBvmvFTMcoBcEUA2.zIiteRAsTYuRIeDMzbsRaCplhUPF = P_0[i];
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = gQhwEbWWQacvzimJxXctTfKwVAXO.CvHGdpixazlqJIEeerHebZldRPnRb.Find(pfAUmGBAXbvZdfBvmvFTMcoBcEUA2.aMWdbCPcLlYDCOOEiHzfFtsUmaII);
						pfAUmGBAXbvZdfBvmvFTMcoBcEUA2.zIiteRAsTYuRIeDMzbsRaCplhUPF.categoryId = uPTLxJFPtKXKTKZJySlCihDrnxXA?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
						uPTLxJFPtKXKTKZJySlCihDrnxXA = P_1.Find(pfAUmGBAXbvZdfBvmvFTMcoBcEUA2.yiHndUiGhlaOCjwGHdmSEPrFuyGOA);
						pfAUmGBAXbvZdfBvmvFTMcoBcEUA2.zIiteRAsTYuRIeDMzbsRaCplhUPF.layoutId = uPTLxJFPtKXKTKZJySlCihDrnxXA?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
					}
				}
			}

			private sealed class pfAUmGBAXbvZdfBvmvFTMcoBcEUA
			{
				public Player_Editor.Mapping zIiteRAsTYuRIeDMzbsRaCplhUPF;

				public kkvvrRbHfAcNpjVADutvgoQlBRWV nKbHTMgACCmqoKlPuyQdeVEbReTR;

				internal bool aMWdbCPcLlYDCOOEiHzfFtsUmaII(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(nKbHTMgACCmqoKlPuyQdeVEbReTR.OBOZTZihcYUzKNMLcIaUgwNuFlMC.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == zIiteRAsTYuRIeDMzbsRaCplhUPF.categoryId;
				}

				internal bool yiHndUiGhlaOCjwGHdmSEPrFuyGOA(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(nKbHTMgACCmqoKlPuyQdeVEbReTR.OBOZTZihcYUzKNMLcIaUgwNuFlMC.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == zIiteRAsTYuRIeDMzbsRaCplhUPF.layoutId;
				}
			}

			private sealed class VvYcjwPirIieoKjGNLYnyMdboAny
			{
				public Player_Editor.CreateControllerInfo huNydbZyTjgYUslWdasdMOzNRfeP;

				public kkvvrRbHfAcNpjVADutvgoQlBRWV wvnmIIHqgBkXDQTdKlaxktKhsqIo;

				internal bool yCYeknCHBuHYTpwvMIGWmYRyFiBA(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(wvnmIIHqgBkXDQTdKlaxktKhsqIo.OBOZTZihcYUzKNMLcIaUgwNuFlMC.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == huNydbZyTjgYUslWdasdMOzNRfeP.sourceId;
				}
			}

			private sealed class BhDnDqohPUAeyhRsHfYiirHrtYDD
			{
				public int vnTYRofvzyioObLWBAwNcYxkLbtNA;

				public kkvvrRbHfAcNpjVADutvgoQlBRWV OXVFdNxwbMehNaRnbefJPouPFGgLA;

				internal bool JRFKEGGLbpKSZQddsAbnKhvNvyhHA(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(OXVFdNxwbMehNaRnbefJPouPFGgLA.OBOZTZihcYUzKNMLcIaUgwNuFlMC.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == vnTYRofvzyioObLWBAwNcYxkLbtNA;
				}
			}

			private sealed class WRwqhADOSBgYIXqKWQbiKtpGDzHF
			{
				public int qEzAvjbRcGfWrpYBOTScbzDAcRkmA;

				public kkvvrRbHfAcNpjVADutvgoQlBRWV jOETlOZZejraBhnGVSmKrelCnHJl;

				internal bool TocUTKPhvKSRJULkmpbylTqSVNDK(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(jOETlOZZejraBhnGVSmKrelCnHJl.OBOZTZihcYUzKNMLcIaUgwNuFlMC.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == qEzAvjbRcGfWrpYBOTScbzDAcRkmA;
				}
			}

			private sealed class dCwOuBhFvNGybrOLnIIjLDiIvfoE
			{
				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> iFOOTQGaVQdRkjSDuEvpDhdaqEiFb;

				public FSaPiKwOgGIHvgTAgfWfQvEkELLrA xisASpriIinsEiPveuuCnrjSVSHV;

				internal int OUGYQDyJIcBTMINquKqQzZjGwGlU(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					UztdbeOmJzHMeiSWgASKXqHquPjRA uztdbeOmJzHMeiSWgASKXqHquPjRA = new UztdbeOmJzHMeiSWgASKXqHquPjRA();
					uztdbeOmJzHMeiSWgASKXqHquPjRA.EmXKCaoCoNqnRrpICizuABwVIjWk = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = xisASpriIinsEiPveuuCnrjSVSHV.CvHGdpixazlqJIEeerHebZldRPnRb.Find(uztdbeOmJzHMeiSWgASKXqHquPjRA.rtCehQuowoROEZMzCxcgvCpYjaCY);
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA2 = iFOOTQGaVQdRkjSDuEvpDhdaqEiFb.Find(uztdbeOmJzHMeiSWgASKXqHquPjRA.vBSEgbSaDuArbIcVqPXhjwaobgTW);
						if (uPTLxJFPtKXKTKZJySlCihDrnxXA != null && uPTLxJFPtKXKTKZJySlCihDrnxXA.KhjXjIFGzYqBlLYCRvpUDjwjckYL == P_1[i].categoryId && uPTLxJFPtKXKTKZJySlCihDrnxXA2 != null && uPTLxJFPtKXKTKZJySlCihDrnxXA2.KhjXjIFGzYqBlLYCRvpUDjwjckYL == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor SecDbkVkwWoyeowPjIQRscMPXsOO(AxQBEgzGEbstlAcznxVIEiaFYoVT<ControllerMap_Editor> P_0)
				{
					lDvCGFvZRswTicQpqkqpToCXZMKy lDvCGFvZRswTicQpqkqpToCXZMKy2 = new lDvCGFvZRswTicQpqkqpToCXZMKy();
					lDvCGFvZRswTicQpqkqpToCXZMKy2.IjjRwxAOHHQkXTddWvcPskrmsdUV = P_0;
					lDvCGFvZRswTicQpqkqpToCXZMKy2.JATdeZivyOiLwVHiFEXzJgeffoMD = JsonTools.Clone(lDvCGFvZRswTicQpqkqpToCXZMKy2.IjjRwxAOHHQkXTddWvcPskrmsdUV.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = xisASpriIinsEiPveuuCnrjSVSHV.CvHGdpixazlqJIEeerHebZldRPnRb.Find(lDvCGFvZRswTicQpqkqpToCXZMKy2.EGkbykLUvnqvDIjokvNDOtJlAPBH);
					UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA2 = iFOOTQGaVQdRkjSDuEvpDhdaqEiFb.Find(lDvCGFvZRswTicQpqkqpToCXZMKy2.LLZQOptTHpVGIJIaTMVOktAxmOlQ);
					lDvCGFvZRswTicQpqkqpToCXZMKy2.JATdeZivyOiLwVHiFEXzJgeffoMD.categoryId = uPTLxJFPtKXKTKZJySlCihDrnxXA?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
					lDvCGFvZRswTicQpqkqpToCXZMKy2.JATdeZivyOiLwVHiFEXzJgeffoMD.layoutId = uPTLxJFPtKXKTKZJySlCihDrnxXA2?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
					for (int i = 0; i < lDvCGFvZRswTicQpqkqpToCXZMKy2.JATdeZivyOiLwVHiFEXzJgeffoMD.actionElementMaps.Count; i++)
					{
						IzuUESylzFYQlxZaePLrmyWhQVDO izuUESylzFYQlxZaePLrmyWhQVDO = new IzuUESylzFYQlxZaePLrmyWhQVDO();
						izuUESylzFYQlxZaePLrmyWhQVDO.vwZgnqvqZTCmsfPbSfpRVuFfKJRB = lDvCGFvZRswTicQpqkqpToCXZMKy2;
						izuUESylzFYQlxZaePLrmyWhQVDO.FneveJxsTjfoqVGgWxRKifxmlkvI = izuUESylzFYQlxZaePLrmyWhQVDO.vwZgnqvqZTCmsfPbSfpRVuFfKJRB.JATdeZivyOiLwVHiFEXzJgeffoMD.actionElementMaps[i];
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA3 = xisASpriIinsEiPveuuCnrjSVSHV.mklBSEYptpWNCvbKGOCHXGlSGoVk.Find(izuUESylzFYQlxZaePLrmyWhQVDO.TSEMXeAPUbMZfIhjgEHfgojIdpww);
						izuUESylzFYQlxZaePLrmyWhQVDO.FneveJxsTjfoqVGgWxRKifxmlkvI._actionId = uPTLxJFPtKXKTKZJySlCihDrnxXA3?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
						izuUESylzFYQlxZaePLrmyWhQVDO.FneveJxsTjfoqVGgWxRKifxmlkvI._actionCategoryId = ((xisASpriIinsEiPveuuCnrjSVSHV.rfuZeftMcJIRNKzElBWdCwYEPOccB.GetActionById(izuUESylzFYQlxZaePLrmyWhQVDO.FneveJxsTjfoqVGgWxRKifxmlkvI._actionId) != null) ? xisASpriIinsEiPveuuCnrjSVSHV.rfuZeftMcJIRNKzElBWdCwYEPOccB.GetActionById(izuUESylzFYQlxZaePLrmyWhQVDO.FneveJxsTjfoqVGgWxRKifxmlkvI._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (lDvCGFvZRswTicQpqkqpToCXZMKy2.IjjRwxAOHHQkXTddWvcPskrmsdUV.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						controllerMap_Editor = lDvCGFvZRswTicQpqkqpToCXZMKy2.IjjRwxAOHHQkXTddWvcPskrmsdUV.DOCVWQZommvdFdxrPjaSiBDULMUf;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(lDvCGFvZRswTicQpqkqpToCXZMKy2.JATdeZivyOiLwVHiFEXzJgeffoMD);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.CTOmkFLttEQUWdlchqWbPQCIucaX;
						AfOnCEEhiyXLFqwsvnNLrOujTfVi(controllerMap_Editor.actionElementMaps, lDvCGFvZRswTicQpqkqpToCXZMKy2.JATdeZivyOiLwVHiFEXzJgeffoMD.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						lDvCGFvZRswTicQpqkqpToCXZMKy2.JATdeZivyOiLwVHiFEXzJgeffoMD = controllerMap_Editor2;
					}
					else
					{
						xisASpriIinsEiPveuuCnrjSVSHV.rfuZeftMcJIRNKzElBWdCwYEPOccB.CreateKeyboardMap(lDvCGFvZRswTicQpqkqpToCXZMKy2.JATdeZivyOiLwVHiFEXzJgeffoMD.categoryId, lDvCGFvZRswTicQpqkqpToCXZMKy2.JATdeZivyOiLwVHiFEXzJgeffoMD.layoutId);
						controllerMap_Editor = lDvCGFvZRswTicQpqkqpToCXZMKy2.IjjRwxAOHHQkXTddWvcPskrmsdUV.LBVfdjcljocFgyxrlEpssKydqpiA[lDvCGFvZRswTicQpqkqpToCXZMKy2.IjjRwxAOHHQkXTddWvcPskrmsdUV.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					lDvCGFvZRswTicQpqkqpToCXZMKy2.JATdeZivyOiLwVHiFEXzJgeffoMD.id = controllerMap_Editor.id;
					int index = lDvCGFvZRswTicQpqkqpToCXZMKy2.IjjRwxAOHHQkXTddWvcPskrmsdUV.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(controllerMap_Editor);
					lDvCGFvZRswTicQpqkqpToCXZMKy2.IjjRwxAOHHQkXTddWvcPskrmsdUV.LBVfdjcljocFgyxrlEpssKydqpiA[index] = lDvCGFvZRswTicQpqkqpToCXZMKy2.JATdeZivyOiLwVHiFEXzJgeffoMD;
					return lDvCGFvZRswTicQpqkqpToCXZMKy2.JATdeZivyOiLwVHiFEXzJgeffoMD;
				}
			}

			private sealed class UztdbeOmJzHMeiSWgASKXqHquPjRA
			{
				public ControllerMap_Editor EmXKCaoCoNqnRrpICizuABwVIjWk;

				public Predicate<UPTLxJFPtKXKTKZJySlCihDrnxXA> WpiDNOjfxICQnwtZiViSbnzKEeMX;

				public Predicate<UPTLxJFPtKXKTKZJySlCihDrnxXA> zNoiYnDdNUrNAslCYsmusqdyEqcw;

				internal bool rtCehQuowoROEZMzCxcgvCpYjaCY(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.HRxJMUtoHMSSeUumJGmaMTqMpwBA == EmXKCaoCoNqnRrpICizuABwVIjWk.categoryId;
				}

				internal bool vBSEgbSaDuArbIcVqPXhjwaobgTW(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.HRxJMUtoHMSSeUumJGmaMTqMpwBA == EmXKCaoCoNqnRrpICizuABwVIjWk.layoutId;
				}
			}

			private sealed class lDvCGFvZRswTicQpqkqpToCXZMKy
			{
				public AxQBEgzGEbstlAcznxVIEiaFYoVT<ControllerMap_Editor> IjjRwxAOHHQkXTddWvcPskrmsdUV;

				public ControllerMap_Editor JATdeZivyOiLwVHiFEXzJgeffoMD;

				internal bool EGkbykLUvnqvDIjokvNDOtJlAPBH(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(IjjRwxAOHHQkXTddWvcPskrmsdUV.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == JATdeZivyOiLwVHiFEXzJgeffoMD.categoryId;
				}

				internal bool LLZQOptTHpVGIJIaTMVOktAxmOlQ(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(IjjRwxAOHHQkXTddWvcPskrmsdUV.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == JATdeZivyOiLwVHiFEXzJgeffoMD.layoutId;
				}
			}

			private sealed class rPoKfyqLtaWecgRJRcdsuUMvyehc
			{
				public List<int> uFbkJljObQkBhqKuyPNUxhxHsAqx;

				public FSaPiKwOgGIHvgTAgfWfQvEkELLrA rHUzNzDocgYDnbeQLazQsRUYrlMb;

				internal InputMapCategory NquMhrwQPXKhFYKlLWagnSKbCCbX(AxQBEgzGEbstlAcznxVIEiaFYoVT<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					InputMapCategory inputMapCategory2;
					if (P_0.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						inputMapCategory2 = P_0.DOCVWQZommvdFdxrPjaSiBDULMUf;
					}
					else
					{
						rHUzNzDocgYDnbeQLazQsRUYrlMb.rfuZeftMcJIRNKzElBWdCwYEPOccB.AddMapCategory();
						inputMapCategory2 = P_0.LBVfdjcljocFgyxrlEpssKydqpiA[P_0.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					int num = P_0.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(inputMapCategory2);
					if (P_0.tLOAQiyKqcGONKeupvHBxMjoQIjwA == UPTLxJFPtKXKTKZJySlCihDrnxXA.gGyiESGhWdbBFlhLwqrBTsVspnNo.otherId)
					{
						uFbkJljObQkBhqKuyPNUxhxHsAqx.Add(num);
					}
					inputMapCategory.id = inputMapCategory2.id;
					P_0.LBVfdjcljocFgyxrlEpssKydqpiA[num] = inputMapCategory;
					return inputMapCategory;
				}
			}

			private sealed class IzuUESylzFYQlxZaePLrmyWhQVDO
			{
				public ActionElementMap FneveJxsTjfoqVGgWxRKifxmlkvI;

				public lDvCGFvZRswTicQpqkqpToCXZMKy vwZgnqvqZTCmsfPbSfpRVuFfKJRB;

				internal bool TSEMXeAPUbMZfIhjgEHfgojIdpww(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(vwZgnqvqZTCmsfPbSfpRVuFfKJRB.IjjRwxAOHHQkXTddWvcPskrmsdUV.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == FneveJxsTjfoqVGgWxRKifxmlkvI._actionId;
				}
			}

			private sealed class UtRuOcZPZaNEXVNNIIkvgAITbFrd
			{
				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> wkFOCCplnIsvAEZqMVnbFQEtgtek;

				public FSaPiKwOgGIHvgTAgfWfQvEkELLrA fDKbZcuWQVkobnXNGnyhVpVQPFuJ;

				internal int QeBeiYjpoxfYresSKlDYQpKpCCaSb(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					PaHzKEqgeOeSBAPreiXkDdEBxpfjA paHzKEqgeOeSBAPreiXkDdEBxpfjA = new PaHzKEqgeOeSBAPreiXkDdEBxpfjA();
					paHzKEqgeOeSBAPreiXkDdEBxpfjA.xTCUxvqhBRqsUDQyxRmFzkqIvrGi = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = fDKbZcuWQVkobnXNGnyhVpVQPFuJ.CvHGdpixazlqJIEeerHebZldRPnRb.Find(paHzKEqgeOeSBAPreiXkDdEBxpfjA.XjStbilbBaiXEDTwQxKfPWizUgsc);
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA2 = wkFOCCplnIsvAEZqMVnbFQEtgtek.Find(paHzKEqgeOeSBAPreiXkDdEBxpfjA.jLHKHtRTnbEDXuNVHrqVGcgkvCEr);
						if (uPTLxJFPtKXKTKZJySlCihDrnxXA != null && uPTLxJFPtKXKTKZJySlCihDrnxXA.KhjXjIFGzYqBlLYCRvpUDjwjckYL == P_1[i].categoryId && uPTLxJFPtKXKTKZJySlCihDrnxXA2 != null && uPTLxJFPtKXKTKZJySlCihDrnxXA2.KhjXjIFGzYqBlLYCRvpUDjwjckYL == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor BujvKhuKALAkBIkjlPxlsDxMAsqJ(AxQBEgzGEbstlAcznxVIEiaFYoVT<ControllerMap_Editor> P_0)
				{
					pBqJEZYIpDYOhJluleGqGzJKuvJBA pBqJEZYIpDYOhJluleGqGzJKuvJBA2 = new pBqJEZYIpDYOhJluleGqGzJKuvJBA();
					pBqJEZYIpDYOhJluleGqGzJKuvJBA2.zxfjLZbAmtiTmuSrXzgVdiMGRdog = P_0;
					pBqJEZYIpDYOhJluleGqGzJKuvJBA2.gUWBLuwSkYuMIsUIfeJXTsLaXsOj = JsonTools.Clone(pBqJEZYIpDYOhJluleGqGzJKuvJBA2.zxfjLZbAmtiTmuSrXzgVdiMGRdog.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = fDKbZcuWQVkobnXNGnyhVpVQPFuJ.CvHGdpixazlqJIEeerHebZldRPnRb.Find(pBqJEZYIpDYOhJluleGqGzJKuvJBA2.PKsbZDdNmCOAufAmTMkXgbvPbBLEA);
					UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA2 = wkFOCCplnIsvAEZqMVnbFQEtgtek.Find(pBqJEZYIpDYOhJluleGqGzJKuvJBA2.awehLuJnCsuykFUwDtyXvTzWTnXl);
					pBqJEZYIpDYOhJluleGqGzJKuvJBA2.gUWBLuwSkYuMIsUIfeJXTsLaXsOj.categoryId = uPTLxJFPtKXKTKZJySlCihDrnxXA?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
					pBqJEZYIpDYOhJluleGqGzJKuvJBA2.gUWBLuwSkYuMIsUIfeJXTsLaXsOj.layoutId = uPTLxJFPtKXKTKZJySlCihDrnxXA2?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
					for (int i = 0; i < pBqJEZYIpDYOhJluleGqGzJKuvJBA2.gUWBLuwSkYuMIsUIfeJXTsLaXsOj.actionElementMaps.Count; i++)
					{
						hcgUZXARvLkEWXsdXPYCOGEeOKRG hcgUZXARvLkEWXsdXPYCOGEeOKRG2 = new hcgUZXARvLkEWXsdXPYCOGEeOKRG();
						hcgUZXARvLkEWXsdXPYCOGEeOKRG2.EyUCwgqWGrkPJATawlZCXoosmSQL = pBqJEZYIpDYOhJluleGqGzJKuvJBA2;
						hcgUZXARvLkEWXsdXPYCOGEeOKRG2.AiyluwrfvwqZGKwQCmvxQBAsMGMu = hcgUZXARvLkEWXsdXPYCOGEeOKRG2.EyUCwgqWGrkPJATawlZCXoosmSQL.gUWBLuwSkYuMIsUIfeJXTsLaXsOj.actionElementMaps[i];
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA3 = fDKbZcuWQVkobnXNGnyhVpVQPFuJ.mklBSEYptpWNCvbKGOCHXGlSGoVk.Find(hcgUZXARvLkEWXsdXPYCOGEeOKRG2.LvjAmRTLcqomSbKBgEUstIEAYuAK);
						hcgUZXARvLkEWXsdXPYCOGEeOKRG2.AiyluwrfvwqZGKwQCmvxQBAsMGMu._actionId = uPTLxJFPtKXKTKZJySlCihDrnxXA3?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
						hcgUZXARvLkEWXsdXPYCOGEeOKRG2.AiyluwrfvwqZGKwQCmvxQBAsMGMu._actionCategoryId = ((fDKbZcuWQVkobnXNGnyhVpVQPFuJ.rfuZeftMcJIRNKzElBWdCwYEPOccB.GetActionById(hcgUZXARvLkEWXsdXPYCOGEeOKRG2.AiyluwrfvwqZGKwQCmvxQBAsMGMu._actionId) != null) ? fDKbZcuWQVkobnXNGnyhVpVQPFuJ.rfuZeftMcJIRNKzElBWdCwYEPOccB.GetActionById(hcgUZXARvLkEWXsdXPYCOGEeOKRG2.AiyluwrfvwqZGKwQCmvxQBAsMGMu._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (pBqJEZYIpDYOhJluleGqGzJKuvJBA2.zxfjLZbAmtiTmuSrXzgVdiMGRdog.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						controllerMap_Editor = pBqJEZYIpDYOhJluleGqGzJKuvJBA2.zxfjLZbAmtiTmuSrXzgVdiMGRdog.DOCVWQZommvdFdxrPjaSiBDULMUf;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(pBqJEZYIpDYOhJluleGqGzJKuvJBA2.gUWBLuwSkYuMIsUIfeJXTsLaXsOj);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.JkRfiZekdaWEXhDMryehoKsfhikV;
						AfOnCEEhiyXLFqwsvnNLrOujTfVi(controllerMap_Editor.actionElementMaps, pBqJEZYIpDYOhJluleGqGzJKuvJBA2.gUWBLuwSkYuMIsUIfeJXTsLaXsOj.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						pBqJEZYIpDYOhJluleGqGzJKuvJBA2.gUWBLuwSkYuMIsUIfeJXTsLaXsOj = controllerMap_Editor2;
					}
					else
					{
						fDKbZcuWQVkobnXNGnyhVpVQPFuJ.rfuZeftMcJIRNKzElBWdCwYEPOccB.CreateMouseMap(pBqJEZYIpDYOhJluleGqGzJKuvJBA2.gUWBLuwSkYuMIsUIfeJXTsLaXsOj.categoryId, pBqJEZYIpDYOhJluleGqGzJKuvJBA2.gUWBLuwSkYuMIsUIfeJXTsLaXsOj.layoutId);
						controllerMap_Editor = pBqJEZYIpDYOhJluleGqGzJKuvJBA2.zxfjLZbAmtiTmuSrXzgVdiMGRdog.LBVfdjcljocFgyxrlEpssKydqpiA[pBqJEZYIpDYOhJluleGqGzJKuvJBA2.zxfjLZbAmtiTmuSrXzgVdiMGRdog.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					pBqJEZYIpDYOhJluleGqGzJKuvJBA2.gUWBLuwSkYuMIsUIfeJXTsLaXsOj.id = controllerMap_Editor.id;
					int index = pBqJEZYIpDYOhJluleGqGzJKuvJBA2.zxfjLZbAmtiTmuSrXzgVdiMGRdog.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(controllerMap_Editor);
					pBqJEZYIpDYOhJluleGqGzJKuvJBA2.zxfjLZbAmtiTmuSrXzgVdiMGRdog.LBVfdjcljocFgyxrlEpssKydqpiA[index] = pBqJEZYIpDYOhJluleGqGzJKuvJBA2.gUWBLuwSkYuMIsUIfeJXTsLaXsOj;
					return pBqJEZYIpDYOhJluleGqGzJKuvJBA2.gUWBLuwSkYuMIsUIfeJXTsLaXsOj;
				}
			}

			private sealed class PaHzKEqgeOeSBAPreiXkDdEBxpfjA
			{
				public ControllerMap_Editor xTCUxvqhBRqsUDQyxRmFzkqIvrGi;

				public Predicate<UPTLxJFPtKXKTKZJySlCihDrnxXA> JEvLyYjqoWQWBxdhMiJaXiMEsBJf;

				public Predicate<UPTLxJFPtKXKTKZJySlCihDrnxXA> pPlAtugJuHPTxIVRITBXBaVmIbsmA;

				internal bool XjStbilbBaiXEDTwQxKfPWizUgsc(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.HRxJMUtoHMSSeUumJGmaMTqMpwBA == xTCUxvqhBRqsUDQyxRmFzkqIvrGi.categoryId;
				}

				internal bool jLHKHtRTnbEDXuNVHrqVGcgkvCEr(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.HRxJMUtoHMSSeUumJGmaMTqMpwBA == xTCUxvqhBRqsUDQyxRmFzkqIvrGi.layoutId;
				}
			}

			private sealed class pBqJEZYIpDYOhJluleGqGzJKuvJBA
			{
				public AxQBEgzGEbstlAcznxVIEiaFYoVT<ControllerMap_Editor> zxfjLZbAmtiTmuSrXzgVdiMGRdog;

				public ControllerMap_Editor gUWBLuwSkYuMIsUIfeJXTsLaXsOj;

				internal bool PKsbZDdNmCOAufAmTMkXgbvPbBLEA(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(zxfjLZbAmtiTmuSrXzgVdiMGRdog.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == gUWBLuwSkYuMIsUIfeJXTsLaXsOj.categoryId;
				}

				internal bool awehLuJnCsuykFUwDtyXvTzWTnXl(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(zxfjLZbAmtiTmuSrXzgVdiMGRdog.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == gUWBLuwSkYuMIsUIfeJXTsLaXsOj.layoutId;
				}
			}

			private sealed class hcgUZXARvLkEWXsdXPYCOGEeOKRG
			{
				public ActionElementMap AiyluwrfvwqZGKwQCmvxQBAsMGMu;

				public pBqJEZYIpDYOhJluleGqGzJKuvJBA EyUCwgqWGrkPJATawlZCXoosmSQL;

				internal bool LvjAmRTLcqomSbKBgEUstIEAYuAK(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(EyUCwgqWGrkPJATawlZCXoosmSQL.zxfjLZbAmtiTmuSrXzgVdiMGRdog.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == AiyluwrfvwqZGKwQCmvxQBAsMGMu._actionId;
				}
			}

			private sealed class bMmFRXuGMAWKDRwwgOhvxOppqpcX
			{
				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> YPQLaeuTOoXsuRLSlhpPFgJyratB;

				public FSaPiKwOgGIHvgTAgfWfQvEkELLrA BMqfQjaLcpnkqQzUkowRtNvowBaO;

				internal int naRuBaKcnrMCRZPUFglceaUyQJgbA(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					sQxqUJyWkmYiepHpqcedxqUyBjwf sQxqUJyWkmYiepHpqcedxqUyBjwf2 = new sQxqUJyWkmYiepHpqcedxqUyBjwf();
					sQxqUJyWkmYiepHpqcedxqUyBjwf2.mjWPYUcOBGHqdaXuzgIUheoUaGVm = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = BMqfQjaLcpnkqQzUkowRtNvowBaO.CvHGdpixazlqJIEeerHebZldRPnRb.Find(sQxqUJyWkmYiepHpqcedxqUyBjwf2.UPkUTVGKRSFfAsckhWfBWqhbFIiz);
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA2 = YPQLaeuTOoXsuRLSlhpPFgJyratB.Find(sQxqUJyWkmYiepHpqcedxqUyBjwf2.cfjbWiRoYNGupbtvreObCPyMZMedA);
						if (sQxqUJyWkmYiepHpqcedxqUyBjwf2.mjWPYUcOBGHqdaXuzgIUheoUaGVm.hardwareGuid == P_1[i].hardwareGuid && uPTLxJFPtKXKTKZJySlCihDrnxXA != null && uPTLxJFPtKXKTKZJySlCihDrnxXA.KhjXjIFGzYqBlLYCRvpUDjwjckYL == P_1[i].categoryId && uPTLxJFPtKXKTKZJySlCihDrnxXA2 != null && uPTLxJFPtKXKTKZJySlCihDrnxXA2.KhjXjIFGzYqBlLYCRvpUDjwjckYL == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor VIfZZskVJIfloojCeqNfgBVxIBDk(AxQBEgzGEbstlAcznxVIEiaFYoVT<ControllerMap_Editor> P_0)
				{
					gbgZYkXaemLCSQPPyvxGKxPcYDaD gbgZYkXaemLCSQPPyvxGKxPcYDaD2 = new gbgZYkXaemLCSQPPyvxGKxPcYDaD();
					gbgZYkXaemLCSQPPyvxGKxPcYDaD2.LofeLjAkrNbmCDjfALOJfJsOVEiwA = P_0;
					gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU = JsonTools.Clone(gbgZYkXaemLCSQPPyvxGKxPcYDaD2.LofeLjAkrNbmCDjfALOJfJsOVEiwA.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = BMqfQjaLcpnkqQzUkowRtNvowBaO.CvHGdpixazlqJIEeerHebZldRPnRb.Find(gbgZYkXaemLCSQPPyvxGKxPcYDaD2.BsegGAHxgiGKpuhgOUfIaGhQfCkM);
					UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA2 = YPQLaeuTOoXsuRLSlhpPFgJyratB.Find(gbgZYkXaemLCSQPPyvxGKxPcYDaD2.DRJSgbFEAUWvnScHfcFAozLdoenp);
					gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU.categoryId = uPTLxJFPtKXKTKZJySlCihDrnxXA?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
					gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU.layoutId = uPTLxJFPtKXKTKZJySlCihDrnxXA2?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
					for (int i = 0; i < gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU.actionElementMaps.Count; i++)
					{
						yLrCjiEkemenpdoeFGxiZhzbHKQqB yLrCjiEkemenpdoeFGxiZhzbHKQqB2 = new yLrCjiEkemenpdoeFGxiZhzbHKQqB();
						yLrCjiEkemenpdoeFGxiZhzbHKQqB2.fqaFhIpeSxpcTWewqibHhHfrWFqI = gbgZYkXaemLCSQPPyvxGKxPcYDaD2;
						yLrCjiEkemenpdoeFGxiZhzbHKQqB2.gqldTShUlfKhjZUtMZoqXipQElEKA = yLrCjiEkemenpdoeFGxiZhzbHKQqB2.fqaFhIpeSxpcTWewqibHhHfrWFqI.ciovspZbfPYtVRFjboxWhZexUPUU.actionElementMaps[i];
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA3 = BMqfQjaLcpnkqQzUkowRtNvowBaO.mklBSEYptpWNCvbKGOCHXGlSGoVk.Find(yLrCjiEkemenpdoeFGxiZhzbHKQqB2.valByTGtmnAbKqNGaxgmtJMfLQQz);
						yLrCjiEkemenpdoeFGxiZhzbHKQqB2.gqldTShUlfKhjZUtMZoqXipQElEKA._actionId = uPTLxJFPtKXKTKZJySlCihDrnxXA3?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
						yLrCjiEkemenpdoeFGxiZhzbHKQqB2.gqldTShUlfKhjZUtMZoqXipQElEKA._actionCategoryId = ((BMqfQjaLcpnkqQzUkowRtNvowBaO.rfuZeftMcJIRNKzElBWdCwYEPOccB.GetActionById(yLrCjiEkemenpdoeFGxiZhzbHKQqB2.gqldTShUlfKhjZUtMZoqXipQElEKA._actionId) != null) ? BMqfQjaLcpnkqQzUkowRtNvowBaO.rfuZeftMcJIRNKzElBWdCwYEPOccB.GetActionById(yLrCjiEkemenpdoeFGxiZhzbHKQqB2.gqldTShUlfKhjZUtMZoqXipQElEKA._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (gbgZYkXaemLCSQPPyvxGKxPcYDaD2.LofeLjAkrNbmCDjfALOJfJsOVEiwA.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						controllerMap_Editor = gbgZYkXaemLCSQPPyvxGKxPcYDaD2.LofeLjAkrNbmCDjfALOJfJsOVEiwA.DOCVWQZommvdFdxrPjaSiBDULMUf;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.iVwyLCJlxUfZwEQQbpCNBXCFgAyIA;
						AfOnCEEhiyXLFqwsvnNLrOujTfVi(controllerMap_Editor.actionElementMaps, gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU = controllerMap_Editor2;
					}
					else
					{
						BMqfQjaLcpnkqQzUkowRtNvowBaO.rfuZeftMcJIRNKzElBWdCwYEPOccB.CreateJoystickMap(gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU.categoryId, gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU.hardwareGuid, gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU.layoutId);
						controllerMap_Editor = gbgZYkXaemLCSQPPyvxGKxPcYDaD2.LofeLjAkrNbmCDjfALOJfJsOVEiwA.LBVfdjcljocFgyxrlEpssKydqpiA[gbgZYkXaemLCSQPPyvxGKxPcYDaD2.LofeLjAkrNbmCDjfALOJfJsOVEiwA.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU.id = controllerMap_Editor.id;
					int index = gbgZYkXaemLCSQPPyvxGKxPcYDaD2.LofeLjAkrNbmCDjfALOJfJsOVEiwA.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(controllerMap_Editor);
					gbgZYkXaemLCSQPPyvxGKxPcYDaD2.LofeLjAkrNbmCDjfALOJfJsOVEiwA.LBVfdjcljocFgyxrlEpssKydqpiA[index] = gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU;
					return gbgZYkXaemLCSQPPyvxGKxPcYDaD2.ciovspZbfPYtVRFjboxWhZexUPUU;
				}
			}

			private sealed class sQxqUJyWkmYiepHpqcedxqUyBjwf
			{
				public ControllerMap_Editor mjWPYUcOBGHqdaXuzgIUheoUaGVm;

				public Predicate<UPTLxJFPtKXKTKZJySlCihDrnxXA> sQcGWFDYLMajraojjuQcNDURWuaib;

				public Predicate<UPTLxJFPtKXKTKZJySlCihDrnxXA> acWbnxpRcYCyqdhhIKdlsYpJhqQmA;

				internal bool UPkUTVGKRSFfAsckhWfBWqhbFIiz(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.HRxJMUtoHMSSeUumJGmaMTqMpwBA == mjWPYUcOBGHqdaXuzgIUheoUaGVm.categoryId;
				}

				internal bool cfjbWiRoYNGupbtvreObCPyMZMedA(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.HRxJMUtoHMSSeUumJGmaMTqMpwBA == mjWPYUcOBGHqdaXuzgIUheoUaGVm.layoutId;
				}
			}

			private sealed class gbgZYkXaemLCSQPPyvxGKxPcYDaD
			{
				public AxQBEgzGEbstlAcznxVIEiaFYoVT<ControllerMap_Editor> LofeLjAkrNbmCDjfALOJfJsOVEiwA;

				public ControllerMap_Editor ciovspZbfPYtVRFjboxWhZexUPUU;

				internal bool BsegGAHxgiGKpuhgOUfIaGhQfCkM(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(LofeLjAkrNbmCDjfALOJfJsOVEiwA.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == ciovspZbfPYtVRFjboxWhZexUPUU.categoryId;
				}

				internal bool DRJSgbFEAUWvnScHfcFAozLdoenp(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(LofeLjAkrNbmCDjfALOJfJsOVEiwA.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == ciovspZbfPYtVRFjboxWhZexUPUU.layoutId;
				}
			}

			private sealed class yLrCjiEkemenpdoeFGxiZhzbHKQqB
			{
				public ActionElementMap gqldTShUlfKhjZUtMZoqXipQElEKA;

				public gbgZYkXaemLCSQPPyvxGKxPcYDaD fqaFhIpeSxpcTWewqibHhHfrWFqI;

				internal bool valByTGtmnAbKqNGaxgmtJMfLQQz(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(fqaFhIpeSxpcTWewqibHhHfrWFqI.LofeLjAkrNbmCDjfALOJfJsOVEiwA.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == gqldTShUlfKhjZUtMZoqXipQElEKA._actionId;
				}
			}

			private sealed class cfQYKstUSfShGigGdyGbrXhZqdOO
			{
				public List<UPTLxJFPtKXKTKZJySlCihDrnxXA> yLBNTtkibQRBrUysOjGHzCWPqdjt;

				public FSaPiKwOgGIHvgTAgfWfQvEkELLrA AHXIQMKDxdkrmuqPkghRHANcEgPnA;

				internal int DBUANCjUCTUgJEzfOjLdiFtbZfCo(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					CyCQVZxBNbrHdmyvJahjUdnpmUEX cyCQVZxBNbrHdmyvJahjUdnpmUEX = new CyCQVZxBNbrHdmyvJahjUdnpmUEX();
					cyCQVZxBNbrHdmyvJahjUdnpmUEX.kEdGRxwXKFWNAdLKmgPgjfJswuut = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = AHXIQMKDxdkrmuqPkghRHANcEgPnA.pktQslGYMXhxcpmwOOCDlWZmdSPj.Find(cyCQVZxBNbrHdmyvJahjUdnpmUEX.kssoMJqEGVKBIjFxoBMEcyGjVhDTA);
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA2 = AHXIQMKDxdkrmuqPkghRHANcEgPnA.CvHGdpixazlqJIEeerHebZldRPnRb.Find(cyCQVZxBNbrHdmyvJahjUdnpmUEX.EgBIVeDOqEhVNOqmWhEVVcRUnUlzA);
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA3 = yLBNTtkibQRBrUysOjGHzCWPqdjt.Find(cyCQVZxBNbrHdmyvJahjUdnpmUEX.LjJchXBKJuVAVCPEZFmbBYYmKpQdb);
						if (uPTLxJFPtKXKTKZJySlCihDrnxXA != null && uPTLxJFPtKXKTKZJySlCihDrnxXA.KhjXjIFGzYqBlLYCRvpUDjwjckYL == P_1[i].customControllerUid && uPTLxJFPtKXKTKZJySlCihDrnxXA2 != null && uPTLxJFPtKXKTKZJySlCihDrnxXA2.KhjXjIFGzYqBlLYCRvpUDjwjckYL == P_1[i].categoryId && uPTLxJFPtKXKTKZJySlCihDrnxXA3 != null && uPTLxJFPtKXKTKZJySlCihDrnxXA3.KhjXjIFGzYqBlLYCRvpUDjwjckYL == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor dzozHskWOSaNUGdlfCqaQkOUBztFA(AxQBEgzGEbstlAcznxVIEiaFYoVT<ControllerMap_Editor> P_0)
				{
					fvAmYBnzRZsnxwGPviFNIOrkUFQL fvAmYBnzRZsnxwGPviFNIOrkUFQL2 = new fvAmYBnzRZsnxwGPviFNIOrkUFQL();
					fvAmYBnzRZsnxwGPviFNIOrkUFQL2.BFritFkseYwgwoqBPvIbUwRWNBIFA = P_0;
					fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA = JsonTools.Clone(fvAmYBnzRZsnxwGPviFNIOrkUFQL2.BFritFkseYwgwoqBPvIbUwRWNBIFA.vjJtMYgopUUpzRWKvUTtGYhAqNLR);
					UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = AHXIQMKDxdkrmuqPkghRHANcEgPnA.pktQslGYMXhxcpmwOOCDlWZmdSPj.Find(fvAmYBnzRZsnxwGPviFNIOrkUFQL2.TTmVBjgSzvPsUCPthzaVBdrOLCps);
					UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA2 = AHXIQMKDxdkrmuqPkghRHANcEgPnA.CvHGdpixazlqJIEeerHebZldRPnRb.Find(fvAmYBnzRZsnxwGPviFNIOrkUFQL2.TwAaosHJJhBDHJKnesOLCjENctgPA);
					UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA3 = yLBNTtkibQRBrUysOjGHzCWPqdjt.Find(fvAmYBnzRZsnxwGPviFNIOrkUFQL2.DcZcGCJZQbaFPOdKWrKWOCbLshmBA);
					fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA.customControllerUid = uPTLxJFPtKXKTKZJySlCihDrnxXA?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
					fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA.categoryId = uPTLxJFPtKXKTKZJySlCihDrnxXA2?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
					fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA.layoutId = uPTLxJFPtKXKTKZJySlCihDrnxXA3?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
					for (int i = 0; i < fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA.actionElementMaps.Count; i++)
					{
						sudhebgHhHEkmgOEHZjEmZEtZNdEB sudhebgHhHEkmgOEHZjEmZEtZNdEB2 = new sudhebgHhHEkmgOEHZjEmZEtZNdEB();
						sudhebgHhHEkmgOEHZjEmZEtZNdEB2.xWwCwvhAnpCCISrKTJQgzkGVQoGMA = fvAmYBnzRZsnxwGPviFNIOrkUFQL2;
						sudhebgHhHEkmgOEHZjEmZEtZNdEB2.GprMLNlPnVEiXpWdfRhjLOYRFlxD = sudhebgHhHEkmgOEHZjEmZEtZNdEB2.xWwCwvhAnpCCISrKTJQgzkGVQoGMA.OnkfPiJNybTvNDFfOjJZYLYxzLoAA.actionElementMaps[i];
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA4 = AHXIQMKDxdkrmuqPkghRHANcEgPnA.mklBSEYptpWNCvbKGOCHXGlSGoVk.Find(sudhebgHhHEkmgOEHZjEmZEtZNdEB2.gQrEPRVziyLfrQNUhNDkzedwmPPI);
						sudhebgHhHEkmgOEHZjEmZEtZNdEB2.GprMLNlPnVEiXpWdfRhjLOYRFlxD._actionId = uPTLxJFPtKXKTKZJySlCihDrnxXA4?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
						sudhebgHhHEkmgOEHZjEmZEtZNdEB2.GprMLNlPnVEiXpWdfRhjLOYRFlxD._actionCategoryId = ((AHXIQMKDxdkrmuqPkghRHANcEgPnA.rfuZeftMcJIRNKzElBWdCwYEPOccB.GetActionById(sudhebgHhHEkmgOEHZjEmZEtZNdEB2.GprMLNlPnVEiXpWdfRhjLOYRFlxD._actionId) != null) ? AHXIQMKDxdkrmuqPkghRHANcEgPnA.rfuZeftMcJIRNKzElBWdCwYEPOccB.GetActionById(sudhebgHhHEkmgOEHZjEmZEtZNdEB2.GprMLNlPnVEiXpWdfRhjLOYRFlxD._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (fvAmYBnzRZsnxwGPviFNIOrkUFQL2.BFritFkseYwgwoqBPvIbUwRWNBIFA.PfswXQrONjtCuAHjZKRabwQBCfIr)
					{
						controllerMap_Editor = fvAmYBnzRZsnxwGPviFNIOrkUFQL2.BFritFkseYwgwoqBPvIbUwRWNBIFA.DOCVWQZommvdFdxrPjaSiBDULMUf;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.sVJcOoifWPWNWdgMMfKDPxuiNMrmA;
						AfOnCEEhiyXLFqwsvnNLrOujTfVi(controllerMap_Editor.actionElementMaps, fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA = controllerMap_Editor2;
					}
					else
					{
						AHXIQMKDxdkrmuqPkghRHANcEgPnA.rfuZeftMcJIRNKzElBWdCwYEPOccB.CreateCustomControllerMap(fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA.categoryId, fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA.customControllerUid, fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA.layoutId);
						controllerMap_Editor = fvAmYBnzRZsnxwGPviFNIOrkUFQL2.BFritFkseYwgwoqBPvIbUwRWNBIFA.LBVfdjcljocFgyxrlEpssKydqpiA[fvAmYBnzRZsnxwGPviFNIOrkUFQL2.BFritFkseYwgwoqBPvIbUwRWNBIFA.LBVfdjcljocFgyxrlEpssKydqpiA.Count - 1];
					}
					fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA.id = controllerMap_Editor.id;
					int index = fvAmYBnzRZsnxwGPviFNIOrkUFQL2.BFritFkseYwgwoqBPvIbUwRWNBIFA.LBVfdjcljocFgyxrlEpssKydqpiA.IndexOf(controllerMap_Editor);
					fvAmYBnzRZsnxwGPviFNIOrkUFQL2.BFritFkseYwgwoqBPvIbUwRWNBIFA.LBVfdjcljocFgyxrlEpssKydqpiA[index] = fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA;
					return fvAmYBnzRZsnxwGPviFNIOrkUFQL2.OnkfPiJNybTvNDFfOjJZYLYxzLoAA;
				}
			}

			private sealed class WrHgjzNNkaPPSgidwjXwvIRhgdJ
			{
				public int ogzgtWGAeTRMiUlHNiuMXWtrgDvBA;

				internal bool DRcfpKXnZfAsdcWogmOwBpwGlmwJ(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.HRxJMUtoHMSSeUumJGmaMTqMpwBA == ogzgtWGAeTRMiUlHNiuMXWtrgDvBA;
				}
			}

			private sealed class CyCQVZxBNbrHdmyvJahjUdnpmUEX
			{
				public ControllerMap_Editor kEdGRxwXKFWNAdLKmgPgjfJswuut;

				public Predicate<UPTLxJFPtKXKTKZJySlCihDrnxXA> UCsggdborgnHZbsbMVdUPTBUBDkOA;

				public Predicate<UPTLxJFPtKXKTKZJySlCihDrnxXA> WJRCiuOClhYatFdUZqPTIXxZfuTw;

				public Predicate<UPTLxJFPtKXKTKZJySlCihDrnxXA> KSZfXyRfrGDidzWYzDQQuxtJDOhIA;

				internal bool kssoMJqEGVKBIjFxoBMEcyGjVhDTA(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.HRxJMUtoHMSSeUumJGmaMTqMpwBA == kEdGRxwXKFWNAdLKmgPgjfJswuut.customControllerUid;
				}

				internal bool EgBIVeDOqEhVNOqmWhEVVcRUnUlzA(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.HRxJMUtoHMSSeUumJGmaMTqMpwBA == kEdGRxwXKFWNAdLKmgPgjfJswuut.categoryId;
				}

				internal bool LjJchXBKJuVAVCPEZFmbBYYmKpQdb(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.HRxJMUtoHMSSeUumJGmaMTqMpwBA == kEdGRxwXKFWNAdLKmgPgjfJswuut.layoutId;
				}
			}

			private sealed class fvAmYBnzRZsnxwGPviFNIOrkUFQL
			{
				public AxQBEgzGEbstlAcznxVIEiaFYoVT<ControllerMap_Editor> BFritFkseYwgwoqBPvIbUwRWNBIFA;

				public ControllerMap_Editor OnkfPiJNybTvNDFfOjJZYLYxzLoAA;

				internal bool TTmVBjgSzvPsUCPthzaVBdrOLCps(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(BFritFkseYwgwoqBPvIbUwRWNBIFA.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == OnkfPiJNybTvNDFfOjJZYLYxzLoAA.customControllerUid;
				}

				internal bool TwAaosHJJhBDHJKnesOLCjENctgPA(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(BFritFkseYwgwoqBPvIbUwRWNBIFA.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == OnkfPiJNybTvNDFfOjJZYLYxzLoAA.categoryId;
				}

				internal bool DcZcGCJZQbaFPOdKWrKWOCbLshmBA(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(BFritFkseYwgwoqBPvIbUwRWNBIFA.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == OnkfPiJNybTvNDFfOjJZYLYxzLoAA.layoutId;
				}
			}

			private sealed class sudhebgHhHEkmgOEHZjEmZEtZNdEB
			{
				public ActionElementMap GprMLNlPnVEiXpWdfRhjLOYRFlxD;

				public fvAmYBnzRZsnxwGPviFNIOrkUFQL xWwCwvhAnpCCISrKTJQgzkGVQoGMA;

				internal bool gQrEPRVziyLfrQNUhNDkzedwmPPI(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(xWwCwvhAnpCCISrKTJQgzkGVQoGMA.BFritFkseYwgwoqBPvIbUwRWNBIFA.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == GprMLNlPnVEiXpWdfRhjLOYRFlxD._actionId;
				}
			}

			private sealed class SHpIngwCXZnelGKhqJxXFDlhhyEq
			{
				public AxQBEgzGEbstlAcznxVIEiaFYoVT<ControllerMapLayoutManager_RuleSet_Editor> SGzXMJBBYbPPJDcivHpkmxfQLyUk;
			}

			private sealed class fLCbsfmbffKZOyJlxDbtdcQeInhs
			{
				public int ZLRqVAJGEywyfcvvGHMVnbxlFOMIA;

				public SHpIngwCXZnelGKhqJxXFDlhhyEq vcCxQFgrubDVlnxnOnStFxRGpArU;

				internal bool NxtiSdgRpCAIgBfyTdqXiNKPpWES(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(vcCxQFgrubDVlnxnOnStFxRGpArU.SGzXMJBBYbPPJDcivHpkmxfQLyUk.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == ZLRqVAJGEywyfcvvGHMVnbxlFOMIA;
				}
			}

			private sealed class XCCBKFBBlCZiGNIpmBtKcvLXvLkjb
			{
				public int DobBMhjANUVNdmNmiKqhFoboQpxsA;

				public SHpIngwCXZnelGKhqJxXFDlhhyEq GemWDMKHfHoCKcvtErBREcgffvaBA;

				internal bool uIZnQzAlMojyfqrTQyvWgowtSssF(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(GemWDMKHfHoCKcvtErBREcgffvaBA.SGzXMJBBYbPPJDcivHpkmxfQLyUk.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == DobBMhjANUVNdmNmiKqhFoboQpxsA;
				}
			}

			private sealed class QVZRRLJtkgvcGVcNFcYsxltUuEHT
			{
				public int wUHaNKfiXkVmkKOOADlDOUJKHadE;

				public SHpIngwCXZnelGKhqJxXFDlhhyEq CfacMQRvCpInKdlXUSBqvikytEgS;

				internal bool HjNtLieNKEkAWAFzKEElypBgHmZS(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(CfacMQRvCpInKdlXUSBqvikytEgS.SGzXMJBBYbPPJDcivHpkmxfQLyUk.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == wUHaNKfiXkVmkKOOADlDOUJKHadE;
				}
			}

			private sealed class JWZbdssgcIRVSoqDPsLyJhWOSOpm
			{
				public AxQBEgzGEbstlAcznxVIEiaFYoVT<ControllerMapEnabler_RuleSet_Editor> cmlRpyDVelLgASMnZiPDbJOgbPufA;
			}

			private sealed class xIYcsUpNqueAxfCPfOQgBhRRRTug
			{
				public int fLOeUhseWpVCauQJdSuSeZvlbRMA;

				public JWZbdssgcIRVSoqDPsLyJhWOSOpm OogFqBGYzIWxXrwhWJCgFfbEbbyYA;

				internal bool XgMHkRINXzalQimomcNKDSmFcaqHB(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.BkycQhhWlioOCwwIVfgSBNdalGMOA(OogFqBGYzIWxXrwhWJCgFfbEbbyYA.cmlRpyDVelLgASMnZiPDbJOgbPufA.tLOAQiyKqcGONKeupvHBxMjoQIjwA) == fLOeUhseWpVCauQJdSuSeZvlbRMA;
				}
			}

			private sealed class qdNSaWlHoZniQKxoKEvfZaYSRsqS<_0001> where _0001 : class
			{
				public Func<_0001, int> wChYVyoSavceGDoIKvSiMjXOrgAc;
			}

			private sealed class QefzQPPXsRumRpbIniEBFESXCQoxA<_0001> where _0001 : class
			{
				public _0001 YpxiWbpfGyTHiqbFRqJgLPTPFmREA;

				public qdNSaWlHoZniQKxoKEvfZaYSRsqS<_0001> vUBxphkyaVDakwiIRWvHaPSQsTNV;

				internal bool xmMyodlwEyLfoPZKqnbeniqcebGaA(UPTLxJFPtKXKTKZJySlCihDrnxXA P_0)
				{
					return P_0.KhjXjIFGzYqBlLYCRvpUDjwjckYL == vUBxphkyaVDakwiIRWvHaPSQsTNV.wChYVyoSavceGDoIKvSiMjXOrgAc(YpxiWbpfGyTHiqbFRqJgLPTPFmREA);
				}
			}

			public static UserData bxNYzESqrxQDlhZUtRAXJBrCAYmdA(UserData P_0, UserData P_1, bool P_2)
			{
				FSaPiKwOgGIHvgTAgfWfQvEkELLrA fSaPiKwOgGIHvgTAgfWfQvEkELLrA = new FSaPiKwOgGIHvgTAgfWfQvEkELLrA();
				if (P_0 == null)
				{
					throw new ArgumentNullException("orig");
				}
				P_0 = JsonTools.Clone(P_0);
				P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB = (P_2 ? P_0 : new UserData(false));
				if (P_1 != null)
				{
					fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.configVars = JsonTools.Clone(P_1.configVars);
				}
				else
				{
					fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.configVars = JsonTools.Clone(P_0.configVars);
				}
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.TEzgvGkSjOcJZzTYLxWXRbwOwwBk = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				SBBdcdCEoybAGbRatdzcggNrtCNe("Action Category", P_0.actionCategories, P_1?.actionCategories, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.actionCategories, P_2, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.TEzgvGkSjOcJZzTYLxWXRbwOwwBk, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.XApdrQoiGghhrGeoKkNiKBsTFboB, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.cIaYSSXJQndmspAabPAyZbcdkEdm, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.RXdELvKLsYDsVAkOhkjibBQQzNhQA, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.IiPpGeJkIWIwAlvwsNilzUDCejXu);
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rArRupacbakiDlKsJEsVHvlgUXFPA = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				SBBdcdCEoybAGbRatdzcggNrtCNe("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.inputBehaviors, P_2, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rArRupacbakiDlKsJEsVHvlgUXFPA, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.NfDRbfYeZMCIYfkkfbdDyHvrDppNA, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.lHUdnamIcSMQshKnQPKnATbSbJyH, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.gbuIZxEFKgUyRdwOuKchXOiAwnRI, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.CMGGjfuDtdaCwFQSMJqqUgTCHAukA);
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.mklBSEYptpWNCvbKGOCHXGlSGoVk = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				SBBdcdCEoybAGbRatdzcggNrtCNe("Action", P_0.KjpBhkIfmcTdvqlYyhEYCGfoYYtV, P_1?.KjpBhkIfmcTdvqlYyhEYCGfoYYtV, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.KjpBhkIfmcTdvqlYyhEYCGfoYYtV, P_2, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.mklBSEYptpWNCvbKGOCHXGlSGoVk, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.YjBfZqaBEKoWpkqRPPwAesGmNCuI, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.tCQWsdThxTQumUWEokFwKAMdhyUo, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.oEHUZLKSkgPpIYIcOdOmzKrbeEGDA, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.npnYGjpmoRwYBRUJHxMNYqBnMQKJ);
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.CvHGdpixazlqJIEeerHebZldRPnRb = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				rPoKfyqLtaWecgRJRcdsuUMvyehc rPoKfyqLtaWecgRJRcdsuUMvyehc2 = new rPoKfyqLtaWecgRJRcdsuUMvyehc();
				rPoKfyqLtaWecgRJRcdsuUMvyehc2.rHUzNzDocgYDnbeQLazQsRUYrlMb = fSaPiKwOgGIHvgTAgfWfQvEkELLrA;
				rPoKfyqLtaWecgRJRcdsuUMvyehc2.uFbkJljObQkBhqKuyPNUxhxHsAqx = new List<int>();
				SBBdcdCEoybAGbRatdzcggNrtCNe("Map Category", P_0.mapCategories, P_1?.mapCategories, rPoKfyqLtaWecgRJRcdsuUMvyehc2.rHUzNzDocgYDnbeQLazQsRUYrlMb.rfuZeftMcJIRNKzElBWdCwYEPOccB.mapCategories, P_2, rPoKfyqLtaWecgRJRcdsuUMvyehc2.rHUzNzDocgYDnbeQLazQsRUYrlMb.CvHGdpixazlqJIEeerHebZldRPnRb, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.LTblZPgyosrKNegMuHOLIHArrCeMA, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.VzCcjsRIRpRjrBThTQMxSUZOFcag, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.EuAgRixkLSJwDSVCdhHuIxqfTnbP, rPoKfyqLtaWecgRJRcdsuUMvyehc2.NquMhrwQPXKhFYKlLWagnSKbCCbX);
				for (int i = 0; i < rPoKfyqLtaWecgRJRcdsuUMvyehc2.uFbkJljObQkBhqKuyPNUxhxHsAqx.Count; i++)
				{
					int index = rPoKfyqLtaWecgRJRcdsuUMvyehc2.uFbkJljObQkBhqKuyPNUxhxHsAqx[i];
					InputMapCategory inputMapCategory = rPoKfyqLtaWecgRJRcdsuUMvyehc2.rHUzNzDocgYDnbeQLazQsRUYrlMb.rfuZeftMcJIRNKzElBWdCwYEPOccB.mapCategories[index];
					for (int j = 0; j < inputMapCategory.ahaEQUJRDKVVdhOVOgvEhxsZfpaIA.Count; j++)
					{
						WrHgjzNNkaPPSgidwjXwvIRhgdJ wrHgjzNNkaPPSgidwjXwvIRhgdJ = new WrHgjzNNkaPPSgidwjXwvIRhgdJ();
						wrHgjzNNkaPPSgidwjXwvIRhgdJ.ogzgtWGAeTRMiUlHNiuMXWtrgDvBA = inputMapCategory.ahaEQUJRDKVVdhOVOgvEhxsZfpaIA[j];
						UPTLxJFPtKXKTKZJySlCihDrnxXA uPTLxJFPtKXKTKZJySlCihDrnxXA = rPoKfyqLtaWecgRJRcdsuUMvyehc2.rHUzNzDocgYDnbeQLazQsRUYrlMb.CvHGdpixazlqJIEeerHebZldRPnRb.Find(wrHgjzNNkaPPSgidwjXwvIRhgdJ.DRcfpKXnZfAsdcWogmOwBpwGlmwJ);
						inputMapCategory.ahaEQUJRDKVVdhOVOgvEhxsZfpaIA[j] = uPTLxJFPtKXKTKZJySlCihDrnxXA?.KhjXjIFGzYqBlLYCRvpUDjwjckYL ?? (-1);
					}
				}
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.yiDfpbDBwReSOobbdoJMjjEdmEebA = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				SBBdcdCEoybAGbRatdzcggNrtCNe("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.keyboardLayouts, P_2, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.yiDfpbDBwReSOobbdoJMjjEdmEebA, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.oYrCnqDTAUHIvwijQczgWFBlNlECA, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.qKxpCBPumLQmMuZhusxlMrJjugit, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.tUhQNEHQjXQzYmePRGzMYhxAuBYm, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.UKlzHvhCbbtqaSMXyglDJbYBNeBdb);
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.VzBUARGIjLXharPidqnPprATjuWJ = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				SBBdcdCEoybAGbRatdzcggNrtCNe("Mouse Layout", P_0.mouseLayouts, P_1?.mouseLayouts, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.mouseLayouts, P_2, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.VzBUARGIjLXharPidqnPprATjuWJ, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.EaSCtwWhhMrHhwvTCTGzQNjFuRqU, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.YDvIEdOfMzvlrPezrnZjjNmLJbWW, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.aIAoQXlqgQerSZwtBRniGlAJsflS, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.kAIiQRMtuorcxOPLbipAqLDowCEb);
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.xpnibmKtgyPwaKMgbxBImipLXsB = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				SBBdcdCEoybAGbRatdzcggNrtCNe("Joystick Layout", P_0.joystickLayouts, P_1?.joystickLayouts, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.joystickLayouts, P_2, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.xpnibmKtgyPwaKMgbxBImipLXsB, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.NFOdLMqgmiUsHRhsjUHOcwueoSOU, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.ZFsBqQAgbDMeXgTIwetJqweNBPFeA, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.sBFNgnyEkcSNDYJMpjaLKnHOYMoFA, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.eikcKtQCpEfmpSKQLIlARRFAPFfO);
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.lVFObkhSbZINMNXXsmuOopgaYvHD = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				SBBdcdCEoybAGbRatdzcggNrtCNe("Custom Controller Layout", P_0.customControllerLayouts, P_1?.customControllerLayouts, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.customControllerLayouts, P_2, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.lVFObkhSbZINMNXXsmuOopgaYvHD, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.fGrchXyJKUYQpLITqtfNohNkhkyL, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.HkaCwIDPaogJNemcAFOFaayBvXFUE, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.DZBerIjwBIbDlEUrlRBVHHwLorCbA, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.SJlFHrsnzdgfznapjYETVolKGiFy);
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.yrDzUoAUGJbKDLEWLjmIrhwVxFfV = fSaPiKwOgGIHvgTAgfWfQvEkELLrA.GNuADyAzZiqKNjtlBVAsUVNHcewD;
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.pktQslGYMXhxcpmwOOCDlWZmdSPj = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				SBBdcdCEoybAGbRatdzcggNrtCNe("Custom Controller", P_0.customControllers, P_1?.customControllers, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.customControllers, P_2, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.pktQslGYMXhxcpmwOOCDlWZmdSPj, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.NdisSiYNRKnSdtdnDJvTvFaWKjZs, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.QCwjNQSlAfeqfTjnSLJeVOodYUcs, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.VNCMRHpzXqNXZeBeIsVLrwDhxqei, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.SJRGsMvIqgCkJmAKpVOXkDAtaTqq);
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.RswAbxJHVQvXSUIYNzHLcGykXplb = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				SBBdcdCEoybAGbRatdzcggNrtCNe("Layout Manager Set", P_0.controllerMapLayoutManagerRuleSets, P_1?.controllerMapLayoutManagerRuleSets, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.controllerMapLayoutManagerRuleSets, P_2, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.RswAbxJHVQvXSUIYNzHLcGykXplb, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.yiliKZHYnlKTHWoKUzAFVpFjwfME, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.CBfVVcNQjPFYaglkiSANSEoCoNfXA, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.yZwahZCRUUmNmimXDptNZoMeoxfDB, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.EIflEzjFqbakGWWtnBYMgsXwhWYAb);
				fSaPiKwOgGIHvgTAgfWfQvEkELLrA.bRfCRUANIiyYrEmHYMQeMsKCZsMPA = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				SBBdcdCEoybAGbRatdzcggNrtCNe("Controller Map Enabler Set", P_0.controllerMapEnablerRuleSets, P_1?.controllerMapEnablerRuleSets, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.controllerMapEnablerRuleSets, P_2, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.bRfCRUANIiyYrEmHYMQeMsKCZsMPA, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.bEolsIvHCwuJxreIHsiBKkwsEKKo, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.ZJCuZTwTVDDlzxwXgfuuQrwArXUN, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.IzfegtKGSgueuaihtcSnaQLjxhZHB, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.iQyXZPjGpboxEoZeipplTUgFvlti);
				List<UPTLxJFPtKXKTKZJySlCihDrnxXA> list = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				SBBdcdCEoybAGbRatdzcggNrtCNe("Player", P_0.players, P_1?.players, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB.players, P_2, list, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.KPCahghKZCBjGXkxhzRZbyUxvvaC, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.mQXcfJsizvBSmEYshuYMjIRmZJSx, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.bFwjCvVWCfqVWcwbvhiqAIuMGFAY, fSaPiKwOgGIHvgTAgfWfQvEkELLrA.JgbcylATbpJpVXDPxfryJxNhtVNdA);
				List<UPTLxJFPtKXKTKZJySlCihDrnxXA> list2 = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				dCwOuBhFvNGybrOLnIIjLDiIvfoE dCwOuBhFvNGybrOLnIIjLDiIvfoE2 = new dCwOuBhFvNGybrOLnIIjLDiIvfoE();
				dCwOuBhFvNGybrOLnIIjLDiIvfoE2.xisASpriIinsEiPveuuCnrjSVSHV = fSaPiKwOgGIHvgTAgfWfQvEkELLrA;
				dCwOuBhFvNGybrOLnIIjLDiIvfoE2.iFOOTQGaVQdRkjSDuEvpDhdaqEiFb = dCwOuBhFvNGybrOLnIIjLDiIvfoE2.xisASpriIinsEiPveuuCnrjSVSHV.yiDfpbDBwReSOobbdoJMjjEdmEebA;
				SBBdcdCEoybAGbRatdzcggNrtCNe("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, dCwOuBhFvNGybrOLnIIjLDiIvfoE2.xisASpriIinsEiPveuuCnrjSVSHV.rfuZeftMcJIRNKzElBWdCwYEPOccB.keyboardMaps, P_2, list2, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.utQTRcxDXGGOBddPOEVDftzgnHrvb, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.YeDRpTYihGklzSayFjIruCYmOqjt, dCwOuBhFvNGybrOLnIIjLDiIvfoE2.OUGYQDyJIcBTMINquKqQzZjGwGlU, dCwOuBhFvNGybrOLnIIjLDiIvfoE2.SecDbkVkwWoyeowPjIQRscMPXsOO);
				List<UPTLxJFPtKXKTKZJySlCihDrnxXA> list3 = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				UtRuOcZPZaNEXVNNIIkvgAITbFrd utRuOcZPZaNEXVNNIIkvgAITbFrd = new UtRuOcZPZaNEXVNNIIkvgAITbFrd();
				utRuOcZPZaNEXVNNIIkvgAITbFrd.fDKbZcuWQVkobnXNGnyhVpVQPFuJ = fSaPiKwOgGIHvgTAgfWfQvEkELLrA;
				utRuOcZPZaNEXVNNIIkvgAITbFrd.wkFOCCplnIsvAEZqMVnbFQEtgtek = utRuOcZPZaNEXVNNIIkvgAITbFrd.fDKbZcuWQVkobnXNGnyhVpVQPFuJ.VzBUARGIjLXharPidqnPprATjuWJ;
				SBBdcdCEoybAGbRatdzcggNrtCNe("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, utRuOcZPZaNEXVNNIIkvgAITbFrd.fDKbZcuWQVkobnXNGnyhVpVQPFuJ.rfuZeftMcJIRNKzElBWdCwYEPOccB.mouseMaps, P_2, list3, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.MttCZGDmsNeNwdBGAFovyAdnVizzb, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.tCZAllFttnlfqNoSwXwQCwMFjAmS, utRuOcZPZaNEXVNNIIkvgAITbFrd.QeBeiYjpoxfYresSKlDYQpKpCCaSb, utRuOcZPZaNEXVNNIIkvgAITbFrd.BujvKhuKALAkBIkjlPxlsDxMAsqJ);
				List<UPTLxJFPtKXKTKZJySlCihDrnxXA> list4 = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				bMmFRXuGMAWKDRwwgOhvxOppqpcX bMmFRXuGMAWKDRwwgOhvxOppqpcX2 = new bMmFRXuGMAWKDRwwgOhvxOppqpcX();
				bMmFRXuGMAWKDRwwgOhvxOppqpcX2.BMqfQjaLcpnkqQzUkowRtNvowBaO = fSaPiKwOgGIHvgTAgfWfQvEkELLrA;
				bMmFRXuGMAWKDRwwgOhvxOppqpcX2.YPQLaeuTOoXsuRLSlhpPFgJyratB = bMmFRXuGMAWKDRwwgOhvxOppqpcX2.BMqfQjaLcpnkqQzUkowRtNvowBaO.xpnibmKtgyPwaKMgbxBImipLXsB;
				SBBdcdCEoybAGbRatdzcggNrtCNe("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, bMmFRXuGMAWKDRwwgOhvxOppqpcX2.BMqfQjaLcpnkqQzUkowRtNvowBaO.rfuZeftMcJIRNKzElBWdCwYEPOccB.joystickMaps, P_2, list4, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.UtztSjqiVWLNPYXMxqeKMdFErKvQ, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.BRDAUiMtejDtSGEEXQsTvBuqvYYBA, bMmFRXuGMAWKDRwwgOhvxOppqpcX2.naRuBaKcnrMCRZPUFglceaUyQJgbA, bMmFRXuGMAWKDRwwgOhvxOppqpcX2.VIfZZskVJIfloojCeqNfgBVxIBDk);
				List<UPTLxJFPtKXKTKZJySlCihDrnxXA> list5 = new List<UPTLxJFPtKXKTKZJySlCihDrnxXA>();
				cfQYKstUSfShGigGdyGbrXhZqdOO cfQYKstUSfShGigGdyGbrXhZqdOO2 = new cfQYKstUSfShGigGdyGbrXhZqdOO();
				cfQYKstUSfShGigGdyGbrXhZqdOO2.AHXIQMKDxdkrmuqPkghRHANcEgPnA = fSaPiKwOgGIHvgTAgfWfQvEkELLrA;
				cfQYKstUSfShGigGdyGbrXhZqdOO2.yLBNTtkibQRBrUysOjGHzCWPqdjt = cfQYKstUSfShGigGdyGbrXhZqdOO2.AHXIQMKDxdkrmuqPkghRHANcEgPnA.lVFObkhSbZINMNXXsmuOopgaYvHD;
				SBBdcdCEoybAGbRatdzcggNrtCNe("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, cfQYKstUSfShGigGdyGbrXhZqdOO2.AHXIQMKDxdkrmuqPkghRHANcEgPnA.rfuZeftMcJIRNKzElBWdCwYEPOccB.customControllerMaps, P_2, list5, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.hetxyHyTajuseraDZQPdxECJDyjO, GiuqcIVhtMZudtBYsPfnAMGoyKUn._003C_003E9.HUBkNzDxXDfvqXjginTzqdihwZNj, cfQYKstUSfShGigGdyGbrXhZqdOO2.DBUANCjUCTUgJEzfOjLdiFtbZfCo, cfQYKstUSfShGigGdyGbrXhZqdOO2.dzozHskWOSaNUGdlfCqaQkOUBztFA);
				return fSaPiKwOgGIHvgTAgfWfQvEkELLrA.rfuZeftMcJIRNKzElBWdCwYEPOccB;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void iwIpjuOadssymETsBZXpmOiEqBbf(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void AfOnCEEhiyXLFqwsvnNLrOujTfVi<_0001>(IList<_0001> P_0, IList<_0001> P_1, IList<_0001> P_2, Func<_0001, IList<_0001>, int> P_3)
			{
				for (int i = 0; i < P_0.Count; i++)
				{
					P_2.Add(P_0[i]);
				}
				if (P_1 == null)
				{
					return;
				}
				for (int j = 0; j < P_1.Count; j++)
				{
					_0001 val = P_1[j];
					int num = P_3(val, P_2);
					if (num >= 0)
					{
						P_2[num] = val;
					}
					else
					{
						P_2.Add(val);
					}
				}
			}

			private static void SBBdcdCEoybAGbRatdzcggNrtCNe<_0001>(string P_0, IList<_0001> P_1, IList<_0001> P_2, IList<_0001> P_3, bool P_4, List<UPTLxJFPtKXKTKZJySlCihDrnxXA> P_5, Func<_0001, int> P_6, Func<_0001, string> P_7, Func<_0001, IList<_0001>, int> P_8, Func<AxQBEgzGEbstlAcznxVIEiaFYoVT<_0001>, _0001> P_9) where _0001 : class
			{
				qdNSaWlHoZniQKxoKEvfZaYSRsqS<_0001> qdNSaWlHoZniQKxoKEvfZaYSRsqS2 = new qdNSaWlHoZniQKxoKEvfZaYSRsqS<_0001>();
				qdNSaWlHoZniQKxoKEvfZaYSRsqS2.wChYVyoSavceGDoIKvSiMjXOrgAc = P_6;
				for (int i = 0; i < P_1.Count; i++)
				{
					_0001 val = P_1[i];
					if (P_4)
					{
						P_5.Add(new UPTLxJFPtKXKTKZJySlCihDrnxXA(qdNSaWlHoZniQKxoKEvfZaYSRsqS2.wChYVyoSavceGDoIKvSiMjXOrgAc(val), -1, qdNSaWlHoZniQKxoKEvfZaYSRsqS2.wChYVyoSavceGDoIKvSiMjXOrgAc(val)));
						continue;
					}
					_0001 arg = P_9(new AxQBEgzGEbstlAcznxVIEiaFYoVT<_0001>(val, null, UPTLxJFPtKXKTKZJySlCihDrnxXA.gGyiESGhWdbBFlhLwqrBTsVspnNo.origId, P_3, false));
					P_5.Add(new UPTLxJFPtKXKTKZJySlCihDrnxXA(qdNSaWlHoZniQKxoKEvfZaYSRsqS2.wChYVyoSavceGDoIKvSiMjXOrgAc(val), -1, qdNSaWlHoZniQKxoKEvfZaYSRsqS2.wChYVyoSavceGDoIKvSiMjXOrgAc(arg)));
				}
				if (P_2 == null)
				{
					return;
				}
				for (int j = 0; j < P_2.Count; j++)
				{
					_0001 val2 = P_2[j];
					int num = P_8(val2, P_3);
					if (num >= 0)
					{
						QefzQPPXsRumRpbIniEBFESXCQoxA<_0001> qefzQPPXsRumRpbIniEBFESXCQoxA = new QefzQPPXsRumRpbIniEBFESXCQoxA<_0001>();
						qefzQPPXsRumRpbIniEBFESXCQoxA.vUBxphkyaVDakwiIRWvHaPSQsTNV = qdNSaWlHoZniQKxoKEvfZaYSRsqS2;
						_0001 val3 = P_3[num];
						qefzQPPXsRumRpbIniEBFESXCQoxA.YpxiWbpfGyTHiqbFRqJgLPTPFmREA = P_9(new AxQBEgzGEbstlAcznxVIEiaFYoVT<_0001>(val2, val3, UPTLxJFPtKXKTKZJySlCihDrnxXA.gGyiESGhWdbBFlhLwqrBTsVspnNo.otherId, P_3, true));
						P_5.Find(qefzQPPXsRumRpbIniEBFESXCQoxA.xmMyodlwEyLfoPZKqnbeniqcebGaA).HRxJMUtoHMSSeUumJGmaMTqMpwBA = qefzQPPXsRumRpbIniEBFESXCQoxA.vUBxphkyaVDakwiIRWvHaPSQsTNV.wChYVyoSavceGDoIKvSiMjXOrgAc(val2);
						string text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
					}
					else
					{
						_0001 arg2 = P_9(new AxQBEgzGEbstlAcznxVIEiaFYoVT<_0001>(val2, null, UPTLxJFPtKXKTKZJySlCihDrnxXA.gGyiESGhWdbBFlhLwqrBTsVspnNo.otherId, P_3, false));
						P_5.Add(new UPTLxJFPtKXKTKZJySlCihDrnxXA(-1, qdNSaWlHoZniQKxoKEvfZaYSRsqS2.wChYVyoSavceGDoIKvSiMjXOrgAc(val2), qdNSaWlHoZniQKxoKEvfZaYSRsqS2.wChYVyoSavceGDoIKvSiMjXOrgAc(arg2)));
						string text2 = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
					}
				}
			}
		}

		[Serializable]
		private sealed class vDvDegJIJiwlWkDfeCWBEawlTwaAb
		{
			public static readonly vDvDegJIJiwlWkDfeCWBEawlTwaAb _003C_003E9 = new vDvDegJIJiwlWkDfeCWBEawlTwaAb();

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__200_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__218_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__234_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__250_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__266_0;

			internal void icNPwWqajOPwTdaeVStnLiZfumPJ(List<Player_Editor.Mapping> P_0, int P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				for (int num = P_0.Count - 1; num >= 0; num--)
				{
					if (P_0[num] == null || P_0[num].categoryId == P_1)
					{
						P_0.RemoveAt(num);
					}
				}
			}

			internal void NikGVXCynkaOVKBvijCBujNFkYvDA(List<Player_Editor.Mapping> P_0, int P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				for (int num = P_0.Count - 1; num >= 0; num--)
				{
					if (P_0[num] == null || P_0[num].layoutId == P_1)
					{
						P_0.RemoveAt(num);
					}
				}
			}

			internal void EkpSkHEiBqiyAzpGdCqzWJlWQmjA(List<Player_Editor.Mapping> P_0, int P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				for (int num = P_0.Count - 1; num >= 0; num--)
				{
					if (P_0[num] == null || P_0[num].layoutId == P_1)
					{
						P_0.RemoveAt(num);
					}
				}
			}

			internal void SIBWhTRTjEvsFVRzTpAEnYXGIggr(List<Player_Editor.Mapping> P_0, int P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				for (int num = P_0.Count - 1; num >= 0; num--)
				{
					if (P_0[num] == null || P_0[num].layoutId == P_1)
					{
						P_0.RemoveAt(num);
					}
				}
			}

			internal void omoaYeBiXjseGtVTOGCcjNyGvzrJB(List<Player_Editor.Mapping> P_0, int P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				for (int num = P_0.Count - 1; num >= 0; num--)
				{
					if (P_0[num] == null || P_0[num].layoutId == P_1)
					{
						P_0.RemoveAt(num);
					}
				}
			}
		}

		private sealed class qgCczfcpIYlyjTEwwnfjUGbgcqqi
		{
			public List<InputLayout> rqdXceoTCWrkdvvCDjRLCZKZMWlv;

			internal int dFAdVkAfqRkhvxwbYbalbrBfecjCA(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				EmdPIKCHGqBhZXamqWpXhNokWXqm emdPIKCHGqBhZXamqWpXhNokWXqm = new EmdPIKCHGqBhZXamqWpXhNokWXqm();
				emdPIKCHGqBhZXamqWpXhNokWXqm.zMJtZocZYsjHCBnzLHwxgEpUfZlI = P_0;
				emdPIKCHGqBhZXamqWpXhNokWXqm.xKWidABbnksZZFblBzIuiDgobLrw = P_1;
				int num = rqdXceoTCWrkdvvCDjRLCZKZMWlv.FindIndex(emdPIKCHGqBhZXamqWpXhNokWXqm.gbiEpeidCdgRdWRJuiQcpOPNPvGrA);
				int num2 = rqdXceoTCWrkdvvCDjRLCZKZMWlv.FindIndex(emdPIKCHGqBhZXamqWpXhNokWXqm.EhAAMVbRwQFOzVbvcuDCvJQWfFkHA);
				if (num > num2)
				{
					return 1;
				}
				if (num < num2)
				{
					return -1;
				}
				return 0;
			}
		}

		private sealed class EmdPIKCHGqBhZXamqWpXhNokWXqm
		{
			public ControllerMap_Editor zMJtZocZYsjHCBnzLHwxgEpUfZlI;

			public ControllerMap_Editor xKWidABbnksZZFblBzIuiDgobLrw;

			internal bool gbiEpeidCdgRdWRJuiQcpOPNPvGrA(InputLayout P_0)
			{
				return P_0.id == zMJtZocZYsjHCBnzLHwxgEpUfZlI.id;
			}

			internal bool EhAAMVbRwQFOzVbvcuDCvJQWfFkHA(InputLayout P_0)
			{
				return P_0.id == xKWidABbnksZZFblBzIuiDgobLrw.id;
			}
		}

		private sealed class QOnZkZZdjTEwUDAkgzpofHhaOYtB : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int cVCCNuWdWysOKQwPBdrYIUEMRozC;

			private InputCategory uVPkwjFMpvUnpBZANjtMXPzuQEpi;

			private int trAqMBVlpoEBEbcokpSiohEDFebk;

			private string fCEEagcOoITmHyhHnicreWasNjCpA;

			public string skeGTWQvwewwpzdShaUpXqTTTcZo;

			public UserData rRLAzljvDFevygXcxRhYRGUMxDpH;

			private int TNviWvSZwketMGSYLIjJAZsKZkWB;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return uVPkwjFMpvUnpBZANjtMXPzuQEpi;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return uVPkwjFMpvUnpBZANjtMXPzuQEpi;
				}
			}

			[DebuggerHidden]
			public QOnZkZZdjTEwUDAkgzpofHhaOYtB(int P_0)
			{
				cVCCNuWdWysOKQwPBdrYIUEMRozC = P_0;
				trAqMBVlpoEBEbcokpSiohEDFebk = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				cVCCNuWdWysOKQwPBdrYIUEMRozC = -2;
			}

			private bool MoveNext()
			{
				int num = cVCCNuWdWysOKQwPBdrYIUEMRozC;
				UserData userData = rRLAzljvDFevygXcxRhYRGUMxDpH;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					cVCCNuWdWysOKQwPBdrYIUEMRozC = -1;
					goto IL_0098;
				}
				cVCCNuWdWysOKQwPBdrYIUEMRozC = -1;
				if (fCEEagcOoITmHyhHnicreWasNjCpA == null || fCEEagcOoITmHyhHnicreWasNjCpA == string.Empty)
				{
					return false;
				}
				if (userData.actionCategories == null)
				{
					return false;
				}
				TNviWvSZwketMGSYLIjJAZsKZkWB = 0;
				goto IL_00a8;
				IL_00a8:
				if (TNviWvSZwketMGSYLIjJAZsKZkWB < userData.actionCategories.Count)
				{
					if (userData.actionCategories[TNviWvSZwketMGSYLIjJAZsKZkWB].tag.Equals(fCEEagcOoITmHyhHnicreWasNjCpA, StringComparison.OrdinalIgnoreCase))
					{
						uVPkwjFMpvUnpBZANjtMXPzuQEpi = userData.actionCategories[TNviWvSZwketMGSYLIjJAZsKZkWB];
						cVCCNuWdWysOKQwPBdrYIUEMRozC = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				TNviWvSZwketMGSYLIjJAZsKZkWB++;
				goto IL_00a8;
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

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				QOnZkZZdjTEwUDAkgzpofHhaOYtB qOnZkZZdjTEwUDAkgzpofHhaOYtB;
				if (cVCCNuWdWysOKQwPBdrYIUEMRozC == -2 && trAqMBVlpoEBEbcokpSiohEDFebk == Environment.CurrentManagedThreadId)
				{
					cVCCNuWdWysOKQwPBdrYIUEMRozC = 0;
					qOnZkZZdjTEwUDAkgzpofHhaOYtB = this;
				}
				else
				{
					qOnZkZZdjTEwUDAkgzpofHhaOYtB = new QOnZkZZdjTEwUDAkgzpofHhaOYtB(0);
					qOnZkZZdjTEwUDAkgzpofHhaOYtB.rRLAzljvDFevygXcxRhYRGUMxDpH = rRLAzljvDFevygXcxRhYRGUMxDpH;
				}
				qOnZkZZdjTEwUDAkgzpofHhaOYtB.fCEEagcOoITmHyhHnicreWasNjCpA = skeGTWQvwewwpzdShaUpXqTTTcZo;
				return qOnZkZZdjTEwUDAkgzpofHhaOYtB;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class lILEdFisyGosFpUiUkQajpDZKMPOA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int TPavowNerRaGmhFgNjbAAkDfinMK;

			private InputAction vPzWxowiHXRjpOHWvazMHvVlfMhD;

			private int eTATcQSKwkKbyCigVieVEFnzFDUxA;

			public UserData TuhSXrRxPDDyVNjvysSPdseaGXsN;

			private string WkDbBJBGkmhkAsRbQZppjYTldFqA;

			public string IjMazwQMVZspPEbmIYqhdxMwHbOh;

			private int WWnGJcbjJmcfsELazsnBbbqKqGWbb;

			private int CmvGQuhyxaTtCNUmMZchFOmGLtcQ;

			private InputCategory kOJdZRcdDKbiXHpYvPOQFdZppUdzA;

			private int ZNymcwOLmvhTQiCJYPLRVQrJUXel;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return vPzWxowiHXRjpOHWvazMHvVlfMhD;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vPzWxowiHXRjpOHWvazMHvVlfMhD;
				}
			}

			[DebuggerHidden]
			public lILEdFisyGosFpUiUkQajpDZKMPOA(int P_0)
			{
				TPavowNerRaGmhFgNjbAAkDfinMK = P_0;
				eTATcQSKwkKbyCigVieVEFnzFDUxA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				kOJdZRcdDKbiXHpYvPOQFdZppUdzA = null;
				TPavowNerRaGmhFgNjbAAkDfinMK = -2;
			}

			private bool MoveNext()
			{
				int tPavowNerRaGmhFgNjbAAkDfinMK = TPavowNerRaGmhFgNjbAAkDfinMK;
				UserData tuhSXrRxPDDyVNjvysSPdseaGXsN = TuhSXrRxPDDyVNjvysSPdseaGXsN;
				if (tPavowNerRaGmhFgNjbAAkDfinMK != 0)
				{
					if (tPavowNerRaGmhFgNjbAAkDfinMK != 1)
					{
						return false;
					}
					TPavowNerRaGmhFgNjbAAkDfinMK = -1;
					goto IL_00fd;
				}
				TPavowNerRaGmhFgNjbAAkDfinMK = -1;
				if (tuhSXrRxPDDyVNjvysSPdseaGXsN.KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null || tuhSXrRxPDDyVNjvysSPdseaGXsN.actionCategories == null)
				{
					return false;
				}
				if (WkDbBJBGkmhkAsRbQZppjYTldFqA == null || WkDbBJBGkmhkAsRbQZppjYTldFqA == string.Empty)
				{
					return false;
				}
				WWnGJcbjJmcfsELazsnBbbqKqGWbb = tuhSXrRxPDDyVNjvysSPdseaGXsN.KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count;
				CmvGQuhyxaTtCNUmMZchFOmGLtcQ = 0;
				goto IL_0132;
				IL_0122:
				CmvGQuhyxaTtCNUmMZchFOmGLtcQ++;
				goto IL_0132;
				IL_00fd:
				ZNymcwOLmvhTQiCJYPLRVQrJUXel++;
				goto IL_010d;
				IL_010d:
				if (ZNymcwOLmvhTQiCJYPLRVQrJUXel < WWnGJcbjJmcfsELazsnBbbqKqGWbb)
				{
					if (kOJdZRcdDKbiXHpYvPOQFdZppUdzA.id == tuhSXrRxPDDyVNjvysSPdseaGXsN.KjpBhkIfmcTdvqlYyhEYCGfoYYtV[ZNymcwOLmvhTQiCJYPLRVQrJUXel].categoryId)
					{
						vPzWxowiHXRjpOHWvazMHvVlfMhD = tuhSXrRxPDDyVNjvysSPdseaGXsN.KjpBhkIfmcTdvqlYyhEYCGfoYYtV[ZNymcwOLmvhTQiCJYPLRVQrJUXel];
						TPavowNerRaGmhFgNjbAAkDfinMK = 1;
						return true;
					}
					goto IL_00fd;
				}
				kOJdZRcdDKbiXHpYvPOQFdZppUdzA = null;
				goto IL_0122;
				IL_0132:
				if (CmvGQuhyxaTtCNUmMZchFOmGLtcQ < tuhSXrRxPDDyVNjvysSPdseaGXsN.actionCategories.Count)
				{
					if (tuhSXrRxPDDyVNjvysSPdseaGXsN.actionCategories[CmvGQuhyxaTtCNUmMZchFOmGLtcQ].tag.Equals(WkDbBJBGkmhkAsRbQZppjYTldFqA, StringComparison.OrdinalIgnoreCase))
					{
						kOJdZRcdDKbiXHpYvPOQFdZppUdzA = tuhSXrRxPDDyVNjvysSPdseaGXsN.actionCategories[CmvGQuhyxaTtCNUmMZchFOmGLtcQ];
						ZNymcwOLmvhTQiCJYPLRVQrJUXel = 0;
						goto IL_010d;
					}
					goto IL_0122;
				}
				return false;
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

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				lILEdFisyGosFpUiUkQajpDZKMPOA lILEdFisyGosFpUiUkQajpDZKMPOA2;
				if (TPavowNerRaGmhFgNjbAAkDfinMK == -2 && eTATcQSKwkKbyCigVieVEFnzFDUxA == Environment.CurrentManagedThreadId)
				{
					TPavowNerRaGmhFgNjbAAkDfinMK = 0;
					lILEdFisyGosFpUiUkQajpDZKMPOA2 = this;
				}
				else
				{
					lILEdFisyGosFpUiUkQajpDZKMPOA2 = new lILEdFisyGosFpUiUkQajpDZKMPOA(0);
					lILEdFisyGosFpUiUkQajpDZKMPOA2.TuhSXrRxPDDyVNjvysSPdseaGXsN = TuhSXrRxPDDyVNjvysSPdseaGXsN;
				}
				lILEdFisyGosFpUiUkQajpDZKMPOA2.WkDbBJBGkmhkAsRbQZppjYTldFqA = IjMazwQMVZspPEbmIYqhdxMwHbOh;
				return lILEdFisyGosFpUiUkQajpDZKMPOA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class TPqzpQMTHQdCzWnyWtClcDSyeeEO : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int zamhBWcLJggKhppyBcyEfaBjOzEr;

			private InputAction aEoKVUDHbUeWryHvOstmcNYXpQOO;

			private int BhsZOOPbDvexZTCwamZwVcHiPoiw;

			public UserData hhBGFMHYvCOXzorQzfESKpQUHNpVA;

			private bool QnsDenEZQJVQLFuSFDDASMdwELsB;

			public bool kkmUKVbeJtMhPYQPnojAwgYOTaQq;

			private int AZrFmZTAEMIjJJkbDQzyPldQKIUC;

			public int MzPVVzPnbcaGoljMJtJklNAnHBFeA;

			private IEnumerator<int> iJYfgscNaGvfyHyevWKxofLqQjAdA;

			private int NYUdxSIMvRIgBmMIXBFBHQKvzXfbA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return aEoKVUDHbUeWryHvOstmcNYXpQOO;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aEoKVUDHbUeWryHvOstmcNYXpQOO;
				}
			}

			[DebuggerHidden]
			public TPqzpQMTHQdCzWnyWtClcDSyeeEO(int P_0)
			{
				zamhBWcLJggKhppyBcyEfaBjOzEr = P_0;
				BhsZOOPbDvexZTCwamZwVcHiPoiw = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = zamhBWcLJggKhppyBcyEfaBjOzEr;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						yjviNaKwZNtnHrkLTkeLnBbOKblE();
					}
				}
				iJYfgscNaGvfyHyevWKxofLqQjAdA = null;
				zamhBWcLJggKhppyBcyEfaBjOzEr = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = zamhBWcLJggKhppyBcyEfaBjOzEr;
					UserData userData = hhBGFMHYvCOXzorQzfESKpQUHNpVA;
					switch (num)
					{
					default:
						return false;
					case 0:
						zamhBWcLJggKhppyBcyEfaBjOzEr = -1;
						if (userData.KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null || userData.actionCategories == null)
						{
							return false;
						}
						if (QnsDenEZQJVQLFuSFDDASMdwELsB)
						{
							iJYfgscNaGvfyHyevWKxofLqQjAdA = userData.SortedActionIdsInCategory(AZrFmZTAEMIjJJkbDQzyPldQKIUC).GetEnumerator();
							zamhBWcLJggKhppyBcyEfaBjOzEr = -3;
							goto IL_00a5;
						}
						NYUdxSIMvRIgBmMIXBFBHQKvzXfbA = 0;
						goto IL_0123;
					case 1:
						zamhBWcLJggKhppyBcyEfaBjOzEr = -3;
						goto IL_00a5;
					case 2:
						{
							zamhBWcLJggKhppyBcyEfaBjOzEr = -1;
							goto IL_0111;
						}
						IL_0123:
						if (NYUdxSIMvRIgBmMIXBFBHQKvzXfbA >= userData.KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count)
						{
							break;
						}
						if (userData.KjpBhkIfmcTdvqlYyhEYCGfoYYtV[NYUdxSIMvRIgBmMIXBFBHQKvzXfbA].categoryId == AZrFmZTAEMIjJJkbDQzyPldQKIUC)
						{
							aEoKVUDHbUeWryHvOstmcNYXpQOO = userData.KjpBhkIfmcTdvqlYyhEYCGfoYYtV[NYUdxSIMvRIgBmMIXBFBHQKvzXfbA];
							zamhBWcLJggKhppyBcyEfaBjOzEr = 2;
							return true;
						}
						goto IL_0111;
						IL_0111:
						NYUdxSIMvRIgBmMIXBFBHQKvzXfbA++;
						goto IL_0123;
						IL_00a5:
						while (iJYfgscNaGvfyHyevWKxofLqQjAdA.MoveNext())
						{
							int current = iJYfgscNaGvfyHyevWKxofLqQjAdA.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null)
							{
								aEoKVUDHbUeWryHvOstmcNYXpQOO = actionById;
								zamhBWcLJggKhppyBcyEfaBjOzEr = 1;
								return true;
							}
						}
						yjviNaKwZNtnHrkLTkeLnBbOKblE();
						iJYfgscNaGvfyHyevWKxofLqQjAdA = null;
						break;
					}
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void yjviNaKwZNtnHrkLTkeLnBbOKblE()
			{
				zamhBWcLJggKhppyBcyEfaBjOzEr = -1;
				if (iJYfgscNaGvfyHyevWKxofLqQjAdA != null)
				{
					iJYfgscNaGvfyHyevWKxofLqQjAdA.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				TPqzpQMTHQdCzWnyWtClcDSyeeEO tPqzpQMTHQdCzWnyWtClcDSyeeEO;
				if (zamhBWcLJggKhppyBcyEfaBjOzEr == -2 && BhsZOOPbDvexZTCwamZwVcHiPoiw == Environment.CurrentManagedThreadId)
				{
					zamhBWcLJggKhppyBcyEfaBjOzEr = 0;
					tPqzpQMTHQdCzWnyWtClcDSyeeEO = this;
				}
				else
				{
					tPqzpQMTHQdCzWnyWtClcDSyeeEO = new TPqzpQMTHQdCzWnyWtClcDSyeeEO(0);
					tPqzpQMTHQdCzWnyWtClcDSyeeEO.hhBGFMHYvCOXzorQzfESKpQUHNpVA = hhBGFMHYvCOXzorQzfESKpQUHNpVA;
				}
				tPqzpQMTHQdCzWnyWtClcDSyeeEO.AZrFmZTAEMIjJJkbDQzyPldQKIUC = MzPVVzPnbcaGoljMJtJklNAnHBFeA;
				tPqzpQMTHQdCzWnyWtClcDSyeeEO.QnsDenEZQJVQLFuSFDDASMdwELsB = kkmUKVbeJtMhPYQPnojAwgYOTaQq;
				return tPqzpQMTHQdCzWnyWtClcDSyeeEO;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class aHKOhRNZPSELPyMsHEvQsKaWeZOP : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int tDbhIMhwpaHLevpUVBkudWVJwOIjA;

			private InputAction gUhCyfbviHgKZAUSMnGhBvxqeuSaA;

			private int dXmmXZHwPXwIxeSkwmzuqRvTpZbM;

			public UserData uwaEGfgqIQQRGxOSKaDCsvHgHSdl;

			private string bhgclIPSRQasgKwzpAKEZLzJdMJbb;

			public string JPqPatDHaDlQxsimTBZnyxroDGYB;

			private bool EDwQmhbBeqwFiEoUnwZqeUuZBmWc;

			public bool nOxpklUdXvBywSTXXfDERQuGVqAv;

			private InputCategory npCpiSagoNOOfiEzbxvkykMRdCLN;

			private IEnumerator<int> EgNkzGJerSxpycMwGGZIkSahmUYv;

			private int DOhHhizkisEPrcMENYYKHyymRgAF;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return gUhCyfbviHgKZAUSMnGhBvxqeuSaA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return gUhCyfbviHgKZAUSMnGhBvxqeuSaA;
				}
			}

			[DebuggerHidden]
			public aHKOhRNZPSELPyMsHEvQsKaWeZOP(int P_0)
			{
				tDbhIMhwpaHLevpUVBkudWVJwOIjA = P_0;
				dXmmXZHwPXwIxeSkwmzuqRvTpZbM = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = tDbhIMhwpaHLevpUVBkudWVJwOIjA;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						GOQUOrhNQhVvPZkvdRKOrwfAKFqi();
					}
				}
				npCpiSagoNOOfiEzbxvkykMRdCLN = null;
				EgNkzGJerSxpycMwGGZIkSahmUYv = null;
				tDbhIMhwpaHLevpUVBkudWVJwOIjA = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = tDbhIMhwpaHLevpUVBkudWVJwOIjA;
					UserData userData = uwaEGfgqIQQRGxOSKaDCsvHgHSdl;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						tDbhIMhwpaHLevpUVBkudWVJwOIjA = -1;
						if (userData.KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null || userData.actionCategories == null)
						{
							return false;
						}
						if (bhgclIPSRQasgKwzpAKEZLzJdMJbb == null || bhgclIPSRQasgKwzpAKEZLzJdMJbb == string.Empty)
						{
							return false;
						}
						int num2 = userData.IndexOfActionCategory(bhgclIPSRQasgKwzpAKEZLzJdMJbb);
						if (num2 < 0)
						{
							return false;
						}
						npCpiSagoNOOfiEzbxvkykMRdCLN = userData.GetActionCategory(num2);
						if (EDwQmhbBeqwFiEoUnwZqeUuZBmWc)
						{
							EgNkzGJerSxpycMwGGZIkSahmUYv = userData.SortedActionIdsInCategory(npCpiSagoNOOfiEzbxvkykMRdCLN.id).GetEnumerator();
							tDbhIMhwpaHLevpUVBkudWVJwOIjA = -3;
							goto IL_00f2;
						}
						DOhHhizkisEPrcMENYYKHyymRgAF = 0;
						goto IL_0175;
					}
					case 1:
						tDbhIMhwpaHLevpUVBkudWVJwOIjA = -3;
						goto IL_00f2;
					case 2:
						{
							tDbhIMhwpaHLevpUVBkudWVJwOIjA = -1;
							goto IL_0163;
						}
						IL_0175:
						if (DOhHhizkisEPrcMENYYKHyymRgAF >= userData.KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count)
						{
							break;
						}
						if (userData.KjpBhkIfmcTdvqlYyhEYCGfoYYtV[DOhHhizkisEPrcMENYYKHyymRgAF].categoryId == npCpiSagoNOOfiEzbxvkykMRdCLN.id)
						{
							gUhCyfbviHgKZAUSMnGhBvxqeuSaA = userData.KjpBhkIfmcTdvqlYyhEYCGfoYYtV[DOhHhizkisEPrcMENYYKHyymRgAF];
							tDbhIMhwpaHLevpUVBkudWVJwOIjA = 2;
							return true;
						}
						goto IL_0163;
						IL_00f2:
						while (EgNkzGJerSxpycMwGGZIkSahmUYv.MoveNext())
						{
							int current = EgNkzGJerSxpycMwGGZIkSahmUYv.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null)
							{
								gUhCyfbviHgKZAUSMnGhBvxqeuSaA = actionById;
								tDbhIMhwpaHLevpUVBkudWVJwOIjA = 1;
								return true;
							}
						}
						GOQUOrhNQhVvPZkvdRKOrwfAKFqi();
						EgNkzGJerSxpycMwGGZIkSahmUYv = null;
						break;
						IL_0163:
						DOhHhizkisEPrcMENYYKHyymRgAF++;
						goto IL_0175;
					}
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void GOQUOrhNQhVvPZkvdRKOrwfAKFqi()
			{
				tDbhIMhwpaHLevpUVBkudWVJwOIjA = -1;
				if (EgNkzGJerSxpycMwGGZIkSahmUYv != null)
				{
					EgNkzGJerSxpycMwGGZIkSahmUYv.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				aHKOhRNZPSELPyMsHEvQsKaWeZOP aHKOhRNZPSELPyMsHEvQsKaWeZOP2;
				if (tDbhIMhwpaHLevpUVBkudWVJwOIjA == -2 && dXmmXZHwPXwIxeSkwmzuqRvTpZbM == Environment.CurrentManagedThreadId)
				{
					tDbhIMhwpaHLevpUVBkudWVJwOIjA = 0;
					aHKOhRNZPSELPyMsHEvQsKaWeZOP2 = this;
				}
				else
				{
					aHKOhRNZPSELPyMsHEvQsKaWeZOP2 = new aHKOhRNZPSELPyMsHEvQsKaWeZOP(0);
					aHKOhRNZPSELPyMsHEvQsKaWeZOP2.uwaEGfgqIQQRGxOSKaDCsvHgHSdl = uwaEGfgqIQQRGxOSKaDCsvHgHSdl;
				}
				aHKOhRNZPSELPyMsHEvQsKaWeZOP2.bhgclIPSRQasgKwzpAKEZLzJdMJbb = JPqPatDHaDlQxsimTBZnyxroDGYB;
				aHKOhRNZPSELPyMsHEvQsKaWeZOP2.EDwQmhbBeqwFiEoUnwZqeUuZBmWc = nOxpklUdXvBywSTXXfDERQuGVqAv;
				return aHKOhRNZPSELPyMsHEvQsKaWeZOP2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class HrPqkiCYEQCUqMstNGgiWwJwmRAe : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int sPZWHXklLiVeGuNiJHRXaIhlzMaC;

			private InputMapCategory SlNecZZiCwqdQFPFfHsmianXpVMK;

			private int hICIKdOFlEnryupIKzNMVoiyXkSe;

			private string UOCEkYICbrTIGoVZwiqUnznIAlyv;

			public string nhNguaAQZieTWdgwSOOCFPzipYlAb;

			public UserData xocGbyptnrfjRLoVAqShiiIGrGSA;

			private int pckAMeeAcIDcjFwmofocpEfbaUGFA;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return SlNecZZiCwqdQFPFfHsmianXpVMK;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return SlNecZZiCwqdQFPFfHsmianXpVMK;
				}
			}

			[DebuggerHidden]
			public HrPqkiCYEQCUqMstNGgiWwJwmRAe(int P_0)
			{
				sPZWHXklLiVeGuNiJHRXaIhlzMaC = P_0;
				hICIKdOFlEnryupIKzNMVoiyXkSe = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				sPZWHXklLiVeGuNiJHRXaIhlzMaC = -2;
			}

			private bool MoveNext()
			{
				int num = sPZWHXklLiVeGuNiJHRXaIhlzMaC;
				UserData userData = xocGbyptnrfjRLoVAqShiiIGrGSA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					sPZWHXklLiVeGuNiJHRXaIhlzMaC = -1;
					goto IL_0098;
				}
				sPZWHXklLiVeGuNiJHRXaIhlzMaC = -1;
				if (UOCEkYICbrTIGoVZwiqUnznIAlyv == null || UOCEkYICbrTIGoVZwiqUnznIAlyv == string.Empty)
				{
					return false;
				}
				if (userData.mapCategories == null)
				{
					return false;
				}
				pckAMeeAcIDcjFwmofocpEfbaUGFA = 0;
				goto IL_00a8;
				IL_00a8:
				if (pckAMeeAcIDcjFwmofocpEfbaUGFA < userData.mapCategories.Count)
				{
					if (userData.mapCategories[pckAMeeAcIDcjFwmofocpEfbaUGFA].tag.Equals(UOCEkYICbrTIGoVZwiqUnznIAlyv, StringComparison.OrdinalIgnoreCase))
					{
						SlNecZZiCwqdQFPFfHsmianXpVMK = userData.mapCategories[pckAMeeAcIDcjFwmofocpEfbaUGFA];
						sPZWHXklLiVeGuNiJHRXaIhlzMaC = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				pckAMeeAcIDcjFwmofocpEfbaUGFA++;
				goto IL_00a8;
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

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				HrPqkiCYEQCUqMstNGgiWwJwmRAe hrPqkiCYEQCUqMstNGgiWwJwmRAe;
				if (sPZWHXklLiVeGuNiJHRXaIhlzMaC == -2 && hICIKdOFlEnryupIKzNMVoiyXkSe == Environment.CurrentManagedThreadId)
				{
					sPZWHXklLiVeGuNiJHRXaIhlzMaC = 0;
					hrPqkiCYEQCUqMstNGgiWwJwmRAe = this;
				}
				else
				{
					hrPqkiCYEQCUqMstNGgiWwJwmRAe = new HrPqkiCYEQCUqMstNGgiWwJwmRAe(0);
					hrPqkiCYEQCUqMstNGgiWwJwmRAe.xocGbyptnrfjRLoVAqShiiIGrGSA = xocGbyptnrfjRLoVAqShiiIGrGSA;
				}
				hrPqkiCYEQCUqMstNGgiWwJwmRAe.UOCEkYICbrTIGoVZwiqUnznIAlyv = nhNguaAQZieTWdgwSOOCFPzipYlAb;
				return hrPqkiCYEQCUqMstNGgiWwJwmRAe;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class JoshFKZksUTJnIEtHuqDiqsSfTgw : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int LIhNhOjqldzFoIQHgLWjDwrYldOV;

			private string tmuwBeDcgeCGkGkDjWkLDHUlRDvO;

			private int jOCXobSPZKwrmWitbyWsWBtZDbhJ;

			public UserData KKuKrldKSDHJqSExOUXCsfkuNLtJ;

			private int SyXdmecbJujWkLOHaPLmIgVQKteE;

			public int jfyvDdNXYYHqdSYekGiqBLXlnjpX;

			private IEnumerator<int> ghEOgKjgsTbxsphwrwoimufkPAaK;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return tmuwBeDcgeCGkGkDjWkLDHUlRDvO;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return tmuwBeDcgeCGkGkDjWkLDHUlRDvO;
				}
			}

			[DebuggerHidden]
			public JoshFKZksUTJnIEtHuqDiqsSfTgw(int P_0)
			{
				LIhNhOjqldzFoIQHgLWjDwrYldOV = P_0;
				jOCXobSPZKwrmWitbyWsWBtZDbhJ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int lIhNhOjqldzFoIQHgLWjDwrYldOV = LIhNhOjqldzFoIQHgLWjDwrYldOV;
				if (lIhNhOjqldzFoIQHgLWjDwrYldOV == -3 || lIhNhOjqldzFoIQHgLWjDwrYldOV == 1)
				{
					try
					{
					}
					finally
					{
						OVdvCPoACHqYynXQQtcgnRdewGFk();
					}
				}
				ghEOgKjgsTbxsphwrwoimufkPAaK = null;
				LIhNhOjqldzFoIQHgLWjDwrYldOV = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int lIhNhOjqldzFoIQHgLWjDwrYldOV = LIhNhOjqldzFoIQHgLWjDwrYldOV;
					UserData kKuKrldKSDHJqSExOUXCsfkuNLtJ = KKuKrldKSDHJqSExOUXCsfkuNLtJ;
					switch (lIhNhOjqldzFoIQHgLWjDwrYldOV)
					{
					default:
						return false;
					case 0:
						LIhNhOjqldzFoIQHgLWjDwrYldOV = -1;
						if (kKuKrldKSDHJqSExOUXCsfkuNLtJ.actionCategories == null || kKuKrldKSDHJqSExOUXCsfkuNLtJ.KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
						{
							return false;
						}
						ghEOgKjgsTbxsphwrwoimufkPAaK = kKuKrldKSDHJqSExOUXCsfkuNLtJ.actionCategoryMap.ActionIdsInCategory(SyXdmecbJujWkLOHaPLmIgVQKteE).GetEnumerator();
						LIhNhOjqldzFoIQHgLWjDwrYldOV = -3;
						break;
					case 1:
						LIhNhOjqldzFoIQHgLWjDwrYldOV = -3;
						break;
					}
					while (ghEOgKjgsTbxsphwrwoimufkPAaK.MoveNext())
					{
						int current = ghEOgKjgsTbxsphwrwoimufkPAaK.Current;
						InputAction actionById = kKuKrldKSDHJqSExOUXCsfkuNLtJ.GetActionById(current);
						if (actionById != null)
						{
							tmuwBeDcgeCGkGkDjWkLDHUlRDvO = actionById.descriptiveName;
							LIhNhOjqldzFoIQHgLWjDwrYldOV = 1;
							return true;
						}
					}
					OVdvCPoACHqYynXQQtcgnRdewGFk();
					ghEOgKjgsTbxsphwrwoimufkPAaK = null;
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void OVdvCPoACHqYynXQQtcgnRdewGFk()
			{
				LIhNhOjqldzFoIQHgLWjDwrYldOV = -1;
				if (ghEOgKjgsTbxsphwrwoimufkPAaK != null)
				{
					ghEOgKjgsTbxsphwrwoimufkPAaK.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				JoshFKZksUTJnIEtHuqDiqsSfTgw joshFKZksUTJnIEtHuqDiqsSfTgw;
				if (LIhNhOjqldzFoIQHgLWjDwrYldOV == -2 && jOCXobSPZKwrmWitbyWsWBtZDbhJ == Environment.CurrentManagedThreadId)
				{
					LIhNhOjqldzFoIQHgLWjDwrYldOV = 0;
					joshFKZksUTJnIEtHuqDiqsSfTgw = this;
				}
				else
				{
					joshFKZksUTJnIEtHuqDiqsSfTgw = new JoshFKZksUTJnIEtHuqDiqsSfTgw(0);
					joshFKZksUTJnIEtHuqDiqsSfTgw.KKuKrldKSDHJqSExOUXCsfkuNLtJ = KKuKrldKSDHJqSExOUXCsfkuNLtJ;
				}
				joshFKZksUTJnIEtHuqDiqsSfTgw.SyXdmecbJujWkLOHaPLmIgVQKteE = jfyvDdNXYYHqdSYekGiqBLXlnjpX;
				return joshFKZksUTJnIEtHuqDiqsSfTgw;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class spETIJfkTdwMWybOjGXRnGyRGFFE : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int tYNrrHnqKZnvelwxNAauzZeGpqem;

			private int FPUCNfGpYjUFGNXqBVWlanMCAcnmA;

			private int vuBSOZwAEZDfQaYNwOdGoViRGkogb;

			public UserData KFxksjqWahDLabyQaNgrkesYpzZl;

			private int dmCovXONutWSlJuwhLXvNWyaDHUq;

			public int XVJSURPogqPfnEPIzHzzxzrDndBr;

			private IEnumerator<int> IkFsiUiYhHhIgiHfJymeLNyLgbwkA;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return FPUCNfGpYjUFGNXqBVWlanMCAcnmA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return FPUCNfGpYjUFGNXqBVWlanMCAcnmA;
				}
			}

			[DebuggerHidden]
			public spETIJfkTdwMWybOjGXRnGyRGFFE(int P_0)
			{
				tYNrrHnqKZnvelwxNAauzZeGpqem = P_0;
				vuBSOZwAEZDfQaYNwOdGoViRGkogb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = tYNrrHnqKZnvelwxNAauzZeGpqem;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						WnMqFiKwZfiQCkggCNgXGgFBljHo();
					}
				}
				IkFsiUiYhHhIgiHfJymeLNyLgbwkA = null;
				tYNrrHnqKZnvelwxNAauzZeGpqem = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = tYNrrHnqKZnvelwxNAauzZeGpqem;
					UserData kFxksjqWahDLabyQaNgrkesYpzZl = KFxksjqWahDLabyQaNgrkesYpzZl;
					switch (num)
					{
					default:
						return false;
					case 0:
						tYNrrHnqKZnvelwxNAauzZeGpqem = -1;
						if (kFxksjqWahDLabyQaNgrkesYpzZl.actionCategories == null || kFxksjqWahDLabyQaNgrkesYpzZl.KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
						{
							return false;
						}
						IkFsiUiYhHhIgiHfJymeLNyLgbwkA = kFxksjqWahDLabyQaNgrkesYpzZl.actionCategoryMap.ActionIdsInCategory(dmCovXONutWSlJuwhLXvNWyaDHUq).GetEnumerator();
						tYNrrHnqKZnvelwxNAauzZeGpqem = -3;
						break;
					case 1:
						tYNrrHnqKZnvelwxNAauzZeGpqem = -3;
						break;
					}
					if (IkFsiUiYhHhIgiHfJymeLNyLgbwkA.MoveNext())
					{
						int current = IkFsiUiYhHhIgiHfJymeLNyLgbwkA.Current;
						FPUCNfGpYjUFGNXqBVWlanMCAcnmA = current;
						tYNrrHnqKZnvelwxNAauzZeGpqem = 1;
						return true;
					}
					WnMqFiKwZfiQCkggCNgXGgFBljHo();
					IkFsiUiYhHhIgiHfJymeLNyLgbwkA = null;
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void WnMqFiKwZfiQCkggCNgXGgFBljHo()
			{
				tYNrrHnqKZnvelwxNAauzZeGpqem = -1;
				if (IkFsiUiYhHhIgiHfJymeLNyLgbwkA != null)
				{
					IkFsiUiYhHhIgiHfJymeLNyLgbwkA.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				spETIJfkTdwMWybOjGXRnGyRGFFE spETIJfkTdwMWybOjGXRnGyRGFFE2;
				if (tYNrrHnqKZnvelwxNAauzZeGpqem == -2 && vuBSOZwAEZDfQaYNwOdGoViRGkogb == Environment.CurrentManagedThreadId)
				{
					tYNrrHnqKZnvelwxNAauzZeGpqem = 0;
					spETIJfkTdwMWybOjGXRnGyRGFFE2 = this;
				}
				else
				{
					spETIJfkTdwMWybOjGXRnGyRGFFE2 = new spETIJfkTdwMWybOjGXRnGyRGFFE(0);
					spETIJfkTdwMWybOjGXRnGyRGFFE2.KFxksjqWahDLabyQaNgrkesYpzZl = KFxksjqWahDLabyQaNgrkesYpzZl;
				}
				spETIJfkTdwMWybOjGXRnGyRGFFE2.dmCovXONutWSlJuwhLXvNWyaDHUq = XVJSURPogqPfnEPIzHzzxzrDndBr;
				return spETIJfkTdwMWybOjGXRnGyRGFFE2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}
		}

		private sealed class fLpzVTLIKDsJTUZZKTaQKlgGHywEA : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int sqUDIhHtwXDDkXgudKaeFJKgxjtsB;

			private string ZzyGQeIOaFGyiCRghlnMDFTHcewmB;

			private int wAUqSZXcvqXfzEXzlDTpUJcqyGzE;

			public UserData kDOiyHBwVEakOqbfUiaJpkzjNfqZ;

			private int LgYblckHYSsFukyNXuNkJyFeDMEj;

			public int UJDkGvRdJSQkuGXHMllikshHvxfA;

			private IEnumerator<int> CWVPUuqwbXIzIMzzwDmQEEpNtPrt;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return ZzyGQeIOaFGyiCRghlnMDFTHcewmB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ZzyGQeIOaFGyiCRghlnMDFTHcewmB;
				}
			}

			[DebuggerHidden]
			public fLpzVTLIKDsJTUZZKTaQKlgGHywEA(int P_0)
			{
				sqUDIhHtwXDDkXgudKaeFJKgxjtsB = P_0;
				wAUqSZXcvqXfzEXzlDTpUJcqyGzE = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = sqUDIhHtwXDDkXgudKaeFJKgxjtsB;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						HcSXbfIduqyATLfYIahEgslyiidd();
					}
				}
				CWVPUuqwbXIzIMzzwDmQEEpNtPrt = null;
				sqUDIhHtwXDDkXgudKaeFJKgxjtsB = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = sqUDIhHtwXDDkXgudKaeFJKgxjtsB;
					UserData userData = kDOiyHBwVEakOqbfUiaJpkzjNfqZ;
					switch (num)
					{
					default:
						return false;
					case 0:
						sqUDIhHtwXDDkXgudKaeFJKgxjtsB = -1;
						if (userData.actionCategories == null || userData.KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
						{
							return false;
						}
						CWVPUuqwbXIzIMzzwDmQEEpNtPrt = userData.actionCategoryMap.ActionIdsInCategory(LgYblckHYSsFukyNXuNkJyFeDMEj).GetEnumerator();
						sqUDIhHtwXDDkXgudKaeFJKgxjtsB = -3;
						break;
					case 1:
						sqUDIhHtwXDDkXgudKaeFJKgxjtsB = -3;
						break;
					}
					while (CWVPUuqwbXIzIMzzwDmQEEpNtPrt.MoveNext())
					{
						int current = CWVPUuqwbXIzIMzzwDmQEEpNtPrt.Current;
						InputAction actionById = userData.GetActionById(current);
						if (actionById != null)
						{
							ZzyGQeIOaFGyiCRghlnMDFTHcewmB = actionById.name;
							sqUDIhHtwXDDkXgudKaeFJKgxjtsB = 1;
							return true;
						}
					}
					HcSXbfIduqyATLfYIahEgslyiidd();
					CWVPUuqwbXIzIMzzwDmQEEpNtPrt = null;
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void HcSXbfIduqyATLfYIahEgslyiidd()
			{
				sqUDIhHtwXDDkXgudKaeFJKgxjtsB = -1;
				if (CWVPUuqwbXIzIMzzwDmQEEpNtPrt != null)
				{
					CWVPUuqwbXIzIMzzwDmQEEpNtPrt.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				fLpzVTLIKDsJTUZZKTaQKlgGHywEA fLpzVTLIKDsJTUZZKTaQKlgGHywEA2;
				if (sqUDIhHtwXDDkXgudKaeFJKgxjtsB == -2 && wAUqSZXcvqXfzEXzlDTpUJcqyGzE == Environment.CurrentManagedThreadId)
				{
					sqUDIhHtwXDDkXgudKaeFJKgxjtsB = 0;
					fLpzVTLIKDsJTUZZKTaQKlgGHywEA2 = this;
				}
				else
				{
					fLpzVTLIKDsJTUZZKTaQKlgGHywEA2 = new fLpzVTLIKDsJTUZZKTaQKlgGHywEA(0);
					fLpzVTLIKDsJTUZZKTaQKlgGHywEA2.kDOiyHBwVEakOqbfUiaJpkzjNfqZ = kDOiyHBwVEakOqbfUiaJpkzjNfqZ;
				}
				fLpzVTLIKDsJTUZZKTaQKlgGHywEA2.LgYblckHYSsFukyNXuNkJyFeDMEj = UJDkGvRdJSQkuGXHMllikshHvxfA;
				return fLpzVTLIKDsJTUZZKTaQKlgGHywEA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class QCmpSZsOOYxgdtfpypvixZSNUpYe : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int lvoiPiTeSZAiyaplZYETWffaEdFSA;

			private InputCategory YkjjDdAzlIIhwwwYXuYMiCxZTQSA;

			private int qAxhVXeKyEPGrNfSpSejduWTWXLHA;

			private string BYoTaGUdvNOehvFycGSWfSuiTKTVA;

			public string lbEVfVIpAeadPCtkzRwRsctQOHoIA;

			public UserData dVVTtiMhySIMdDHLodNcvvofOESj;

			private int hkJzygbPjNnsaVUmEDOwSGkIWQsw;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return YkjjDdAzlIIhwwwYXuYMiCxZTQSA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return YkjjDdAzlIIhwwwYXuYMiCxZTQSA;
				}
			}

			[DebuggerHidden]
			public QCmpSZsOOYxgdtfpypvixZSNUpYe(int P_0)
			{
				lvoiPiTeSZAiyaplZYETWffaEdFSA = P_0;
				qAxhVXeKyEPGrNfSpSejduWTWXLHA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				lvoiPiTeSZAiyaplZYETWffaEdFSA = -2;
			}

			private bool MoveNext()
			{
				int num = lvoiPiTeSZAiyaplZYETWffaEdFSA;
				UserData userData = dVVTtiMhySIMdDHLodNcvvofOESj;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					lvoiPiTeSZAiyaplZYETWffaEdFSA = -1;
					goto IL_00b3;
				}
				lvoiPiTeSZAiyaplZYETWffaEdFSA = -1;
				if (BYoTaGUdvNOehvFycGSWfSuiTKTVA == null || BYoTaGUdvNOehvFycGSWfSuiTKTVA == string.Empty)
				{
					return false;
				}
				if (userData.actionCategories == null)
				{
					return false;
				}
				hkJzygbPjNnsaVUmEDOwSGkIWQsw = 0;
				goto IL_00c3;
				IL_00c3:
				if (hkJzygbPjNnsaVUmEDOwSGkIWQsw < userData.actionCategories.Count)
				{
					if (userData.actionCategories[hkJzygbPjNnsaVUmEDOwSGkIWQsw].userAssignable && userData.actionCategories[hkJzygbPjNnsaVUmEDOwSGkIWQsw].tag.Equals(BYoTaGUdvNOehvFycGSWfSuiTKTVA, StringComparison.OrdinalIgnoreCase))
					{
						YkjjDdAzlIIhwwwYXuYMiCxZTQSA = userData.actionCategories[hkJzygbPjNnsaVUmEDOwSGkIWQsw];
						lvoiPiTeSZAiyaplZYETWffaEdFSA = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				hkJzygbPjNnsaVUmEDOwSGkIWQsw++;
				goto IL_00c3;
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

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				QCmpSZsOOYxgdtfpypvixZSNUpYe qCmpSZsOOYxgdtfpypvixZSNUpYe;
				if (lvoiPiTeSZAiyaplZYETWffaEdFSA == -2 && qAxhVXeKyEPGrNfSpSejduWTWXLHA == Environment.CurrentManagedThreadId)
				{
					lvoiPiTeSZAiyaplZYETWffaEdFSA = 0;
					qCmpSZsOOYxgdtfpypvixZSNUpYe = this;
				}
				else
				{
					qCmpSZsOOYxgdtfpypvixZSNUpYe = new QCmpSZsOOYxgdtfpypvixZSNUpYe(0);
					qCmpSZsOOYxgdtfpypvixZSNUpYe.dVVTtiMhySIMdDHLodNcvvofOESj = dVVTtiMhySIMdDHLodNcvvofOESj;
				}
				qCmpSZsOOYxgdtfpypvixZSNUpYe.BYoTaGUdvNOehvFycGSWfSuiTKTVA = lbEVfVIpAeadPCtkzRwRsctQOHoIA;
				return qCmpSZsOOYxgdtfpypvixZSNUpYe;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class nGHawdHrJojxsbwZNnyvocVXNFDib : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int OFCtbOWMaMBdmPdwXvNEfpreDfzZ;

			private InputAction dwTWvfvkgqIymhvpaPcdPCMqJqjHA;

			private int eqhDulFTHbWEOMLgxVIXORGNuGLX;

			public UserData IDqbEbIStrjahAffsWTpPJsKHOqab;

			private int vpxGYDcolDvbafBhzLZZQFPKWgKO;

			public int fFkAcozyACBWAmVxJpDYYWnhLTVh;

			private bool bumbtDAgPbBTndRbGoeattFNkKDCc;

			public bool HLgTDFyRbDJrOoIgflpSlbaOljBD;

			private InputCategory TCBiuLFvVPVlOvzgYXPuKoUrsOdVA;

			private IEnumerator<int> bQBhNyasfNshZjDaJxboIuZegPDK;

			private int NpwTNJZEyMpvTyREumbtAroGhXiH;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return dwTWvfvkgqIymhvpaPcdPCMqJqjHA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return dwTWvfvkgqIymhvpaPcdPCMqJqjHA;
				}
			}

			[DebuggerHidden]
			public nGHawdHrJojxsbwZNnyvocVXNFDib(int P_0)
			{
				OFCtbOWMaMBdmPdwXvNEfpreDfzZ = P_0;
				eqhDulFTHbWEOMLgxVIXORGNuGLX = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int oFCtbOWMaMBdmPdwXvNEfpreDfzZ = OFCtbOWMaMBdmPdwXvNEfpreDfzZ;
				if (oFCtbOWMaMBdmPdwXvNEfpreDfzZ == -3 || oFCtbOWMaMBdmPdwXvNEfpreDfzZ == 1)
				{
					try
					{
					}
					finally
					{
						bTUzFYnSlYWSvnWVjqsYJqrHZbue();
					}
				}
				TCBiuLFvVPVlOvzgYXPuKoUrsOdVA = null;
				bQBhNyasfNshZjDaJxboIuZegPDK = null;
				OFCtbOWMaMBdmPdwXvNEfpreDfzZ = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int oFCtbOWMaMBdmPdwXvNEfpreDfzZ = OFCtbOWMaMBdmPdwXvNEfpreDfzZ;
					UserData iDqbEbIStrjahAffsWTpPJsKHOqab = IDqbEbIStrjahAffsWTpPJsKHOqab;
					InputAction inputAction;
					switch (oFCtbOWMaMBdmPdwXvNEfpreDfzZ)
					{
					default:
						return false;
					case 0:
						OFCtbOWMaMBdmPdwXvNEfpreDfzZ = -1;
						if (iDqbEbIStrjahAffsWTpPJsKHOqab.KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null || iDqbEbIStrjahAffsWTpPJsKHOqab.actionCategories == null)
						{
							return false;
						}
						TCBiuLFvVPVlOvzgYXPuKoUrsOdVA = iDqbEbIStrjahAffsWTpPJsKHOqab.GetActionCategoryById(vpxGYDcolDvbafBhzLZZQFPKWgKO);
						if (TCBiuLFvVPVlOvzgYXPuKoUrsOdVA == null || !TCBiuLFvVPVlOvzgYXPuKoUrsOdVA.userAssignable)
						{
							return false;
						}
						if (bumbtDAgPbBTndRbGoeattFNkKDCc)
						{
							bQBhNyasfNshZjDaJxboIuZegPDK = iDqbEbIStrjahAffsWTpPJsKHOqab.SortedActionIdsInCategory(TCBiuLFvVPVlOvzgYXPuKoUrsOdVA.id).GetEnumerator();
							OFCtbOWMaMBdmPdwXvNEfpreDfzZ = -3;
							goto IL_00e4;
						}
						NpwTNJZEyMpvTyREumbtAroGhXiH = 0;
						goto IL_0165;
					case 1:
						OFCtbOWMaMBdmPdwXvNEfpreDfzZ = -3;
						goto IL_00e4;
					case 2:
						{
							OFCtbOWMaMBdmPdwXvNEfpreDfzZ = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (bQBhNyasfNshZjDaJxboIuZegPDK.MoveNext())
						{
							int current = bQBhNyasfNshZjDaJxboIuZegPDK.Current;
							InputAction actionById = iDqbEbIStrjahAffsWTpPJsKHOqab.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								dwTWvfvkgqIymhvpaPcdPCMqJqjHA = actionById;
								OFCtbOWMaMBdmPdwXvNEfpreDfzZ = 1;
								return true;
							}
						}
						bTUzFYnSlYWSvnWVjqsYJqrHZbue();
						bQBhNyasfNshZjDaJxboIuZegPDK = null;
						break;
						IL_0153:
						NpwTNJZEyMpvTyREumbtAroGhXiH++;
						goto IL_0165;
						IL_0165:
						if (NpwTNJZEyMpvTyREumbtAroGhXiH >= iDqbEbIStrjahAffsWTpPJsKHOqab.KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count)
						{
							break;
						}
						inputAction = iDqbEbIStrjahAffsWTpPJsKHOqab.KjpBhkIfmcTdvqlYyhEYCGfoYYtV[NpwTNJZEyMpvTyREumbtAroGhXiH];
						if (inputAction.categoryId == TCBiuLFvVPVlOvzgYXPuKoUrsOdVA.id && inputAction.userAssignable)
						{
							dwTWvfvkgqIymhvpaPcdPCMqJqjHA = inputAction;
							OFCtbOWMaMBdmPdwXvNEfpreDfzZ = 2;
							return true;
						}
						goto IL_0153;
					}
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void bTUzFYnSlYWSvnWVjqsYJqrHZbue()
			{
				OFCtbOWMaMBdmPdwXvNEfpreDfzZ = -1;
				if (bQBhNyasfNshZjDaJxboIuZegPDK != null)
				{
					bQBhNyasfNshZjDaJxboIuZegPDK.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				nGHawdHrJojxsbwZNnyvocVXNFDib nGHawdHrJojxsbwZNnyvocVXNFDib2;
				if (OFCtbOWMaMBdmPdwXvNEfpreDfzZ == -2 && eqhDulFTHbWEOMLgxVIXORGNuGLX == Environment.CurrentManagedThreadId)
				{
					OFCtbOWMaMBdmPdwXvNEfpreDfzZ = 0;
					nGHawdHrJojxsbwZNnyvocVXNFDib2 = this;
				}
				else
				{
					nGHawdHrJojxsbwZNnyvocVXNFDib2 = new nGHawdHrJojxsbwZNnyvocVXNFDib(0);
					nGHawdHrJojxsbwZNnyvocVXNFDib2.IDqbEbIStrjahAffsWTpPJsKHOqab = IDqbEbIStrjahAffsWTpPJsKHOqab;
				}
				nGHawdHrJojxsbwZNnyvocVXNFDib2.vpxGYDcolDvbafBhzLZZQFPKWgKO = fFkAcozyACBWAmVxJpDYYWnhLTVh;
				nGHawdHrJojxsbwZNnyvocVXNFDib2.bumbtDAgPbBTndRbGoeattFNkKDCc = HLgTDFyRbDJrOoIgflpSlbaOljBD;
				return nGHawdHrJojxsbwZNnyvocVXNFDib2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class uhRpAUYlSybsqkbsKkOzKYjgjAoSA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int XAbuUDWGEHtocdrxsmAHpakLcEZS;

			private InputAction RlqawIyMWEMKPGFgtGkjhlcMeoXZ;

			private int scslqCgtJCqQlVKiivEglSZUDJBB;

			public UserData ZbOrWciWslDJODySQcaqppcIbZot;

			private string zSxuBdQcVTgingftmfOWNYdsAprSA;

			public string gVmcOkeQPhhMXsHLEuGGRRkEjKOeb;

			private bool PbxVeMMBZWQjiycVDIhtebuGDvLEA;

			public bool SCHOErUIfLqyuIeWjHUiVinHvLsi;

			private InputCategory hkmCVNOaEdMAuzlLLRPfXmYYsMAy;

			private IEnumerator<int> eajDyxddHNJEBPsPEBaehgMCyLaTA;

			private int UAyjkAUQyKrmsRyPgqcvfQoswRtw;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return RlqawIyMWEMKPGFgtGkjhlcMeoXZ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RlqawIyMWEMKPGFgtGkjhlcMeoXZ;
				}
			}

			[DebuggerHidden]
			public uhRpAUYlSybsqkbsKkOzKYjgjAoSA(int P_0)
			{
				XAbuUDWGEHtocdrxsmAHpakLcEZS = P_0;
				scslqCgtJCqQlVKiivEglSZUDJBB = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int xAbuUDWGEHtocdrxsmAHpakLcEZS = XAbuUDWGEHtocdrxsmAHpakLcEZS;
				if (xAbuUDWGEHtocdrxsmAHpakLcEZS == -3 || xAbuUDWGEHtocdrxsmAHpakLcEZS == 1)
				{
					try
					{
					}
					finally
					{
						OigfUmHNVFYoUrCQllBThiqnAQZuA();
					}
				}
				hkmCVNOaEdMAuzlLLRPfXmYYsMAy = null;
				eajDyxddHNJEBPsPEBaehgMCyLaTA = null;
				XAbuUDWGEHtocdrxsmAHpakLcEZS = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int xAbuUDWGEHtocdrxsmAHpakLcEZS = XAbuUDWGEHtocdrxsmAHpakLcEZS;
					UserData zbOrWciWslDJODySQcaqppcIbZot = ZbOrWciWslDJODySQcaqppcIbZot;
					InputAction inputAction;
					switch (xAbuUDWGEHtocdrxsmAHpakLcEZS)
					{
					default:
						return false;
					case 0:
						XAbuUDWGEHtocdrxsmAHpakLcEZS = -1;
						if (zbOrWciWslDJODySQcaqppcIbZot.KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null || zbOrWciWslDJODySQcaqppcIbZot.actionCategories == null)
						{
							return false;
						}
						hkmCVNOaEdMAuzlLLRPfXmYYsMAy = zbOrWciWslDJODySQcaqppcIbZot.GetActionCategory(zSxuBdQcVTgingftmfOWNYdsAprSA);
						if (hkmCVNOaEdMAuzlLLRPfXmYYsMAy == null || !hkmCVNOaEdMAuzlLLRPfXmYYsMAy.userAssignable)
						{
							return false;
						}
						if (PbxVeMMBZWQjiycVDIhtebuGDvLEA)
						{
							eajDyxddHNJEBPsPEBaehgMCyLaTA = zbOrWciWslDJODySQcaqppcIbZot.SortedActionIdsInCategory(hkmCVNOaEdMAuzlLLRPfXmYYsMAy.id).GetEnumerator();
							XAbuUDWGEHtocdrxsmAHpakLcEZS = -3;
							goto IL_00e4;
						}
						UAyjkAUQyKrmsRyPgqcvfQoswRtw = 0;
						goto IL_0165;
					case 1:
						XAbuUDWGEHtocdrxsmAHpakLcEZS = -3;
						goto IL_00e4;
					case 2:
						{
							XAbuUDWGEHtocdrxsmAHpakLcEZS = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (eajDyxddHNJEBPsPEBaehgMCyLaTA.MoveNext())
						{
							int current = eajDyxddHNJEBPsPEBaehgMCyLaTA.Current;
							InputAction actionById = zbOrWciWslDJODySQcaqppcIbZot.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								RlqawIyMWEMKPGFgtGkjhlcMeoXZ = actionById;
								XAbuUDWGEHtocdrxsmAHpakLcEZS = 1;
								return true;
							}
						}
						OigfUmHNVFYoUrCQllBThiqnAQZuA();
						eajDyxddHNJEBPsPEBaehgMCyLaTA = null;
						break;
						IL_0153:
						UAyjkAUQyKrmsRyPgqcvfQoswRtw++;
						goto IL_0165;
						IL_0165:
						if (UAyjkAUQyKrmsRyPgqcvfQoswRtw >= zbOrWciWslDJODySQcaqppcIbZot.KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count)
						{
							break;
						}
						inputAction = zbOrWciWslDJODySQcaqppcIbZot.KjpBhkIfmcTdvqlYyhEYCGfoYYtV[UAyjkAUQyKrmsRyPgqcvfQoswRtw];
						if (inputAction.categoryId == hkmCVNOaEdMAuzlLLRPfXmYYsMAy.id && inputAction.userAssignable)
						{
							RlqawIyMWEMKPGFgtGkjhlcMeoXZ = inputAction;
							XAbuUDWGEHtocdrxsmAHpakLcEZS = 2;
							return true;
						}
						goto IL_0153;
					}
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void OigfUmHNVFYoUrCQllBThiqnAQZuA()
			{
				XAbuUDWGEHtocdrxsmAHpakLcEZS = -1;
				if (eajDyxddHNJEBPsPEBaehgMCyLaTA != null)
				{
					eajDyxddHNJEBPsPEBaehgMCyLaTA.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				uhRpAUYlSybsqkbsKkOzKYjgjAoSA uhRpAUYlSybsqkbsKkOzKYjgjAoSA2;
				if (XAbuUDWGEHtocdrxsmAHpakLcEZS == -2 && scslqCgtJCqQlVKiivEglSZUDJBB == Environment.CurrentManagedThreadId)
				{
					XAbuUDWGEHtocdrxsmAHpakLcEZS = 0;
					uhRpAUYlSybsqkbsKkOzKYjgjAoSA2 = this;
				}
				else
				{
					uhRpAUYlSybsqkbsKkOzKYjgjAoSA2 = new uhRpAUYlSybsqkbsKkOzKYjgjAoSA(0);
					uhRpAUYlSybsqkbsKkOzKYjgjAoSA2.ZbOrWciWslDJODySQcaqppcIbZot = ZbOrWciWslDJODySQcaqppcIbZot;
				}
				uhRpAUYlSybsqkbsKkOzKYjgjAoSA2.zSxuBdQcVTgingftmfOWNYdsAprSA = gVmcOkeQPhhMXsHLEuGGRRkEjKOeb;
				uhRpAUYlSybsqkbsKkOzKYjgjAoSA2.PbxVeMMBZWQjiycVDIhtebuGDvLEA = SCHOErUIfLqyuIeWjHUiVinHvLsi;
				return uhRpAUYlSybsqkbsKkOzKYjgjAoSA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class QXcEJKiVvfqMmcWXVuPRrGkFinMSA : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int BqvrWSKjyOhcCaNnMADSbGEpiAaj;

			private InputMapCategory RGkyWJLTEBkoCkMOlEhshtwZiZlO;

			private int wdAfkbcmprHwGtMqXaLxhybkmnOm;

			private string AlVmonzQqqAsGsjCGTCQyQzoixDj;

			public string OLqhuIaTeMCuAjKjZETiddiPskVJA;

			public UserData QsfyHFFvmMTpciUcQMriaZmvcdrT;

			private int EPjMyJWmyGthnWGOUaVPInvLJeoJ;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return RGkyWJLTEBkoCkMOlEhshtwZiZlO;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RGkyWJLTEBkoCkMOlEhshtwZiZlO;
				}
			}

			[DebuggerHidden]
			public QXcEJKiVvfqMmcWXVuPRrGkFinMSA(int P_0)
			{
				BqvrWSKjyOhcCaNnMADSbGEpiAaj = P_0;
				wdAfkbcmprHwGtMqXaLxhybkmnOm = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				BqvrWSKjyOhcCaNnMADSbGEpiAaj = -2;
			}

			private bool MoveNext()
			{
				int bqvrWSKjyOhcCaNnMADSbGEpiAaj = BqvrWSKjyOhcCaNnMADSbGEpiAaj;
				UserData qsfyHFFvmMTpciUcQMriaZmvcdrT = QsfyHFFvmMTpciUcQMriaZmvcdrT;
				if (bqvrWSKjyOhcCaNnMADSbGEpiAaj != 0)
				{
					if (bqvrWSKjyOhcCaNnMADSbGEpiAaj != 1)
					{
						return false;
					}
					BqvrWSKjyOhcCaNnMADSbGEpiAaj = -1;
					goto IL_00b3;
				}
				BqvrWSKjyOhcCaNnMADSbGEpiAaj = -1;
				if (AlVmonzQqqAsGsjCGTCQyQzoixDj == null || AlVmonzQqqAsGsjCGTCQyQzoixDj == string.Empty)
				{
					return false;
				}
				if (qsfyHFFvmMTpciUcQMriaZmvcdrT.mapCategories == null)
				{
					return false;
				}
				EPjMyJWmyGthnWGOUaVPInvLJeoJ = 0;
				goto IL_00c3;
				IL_00c3:
				if (EPjMyJWmyGthnWGOUaVPInvLJeoJ < qsfyHFFvmMTpciUcQMriaZmvcdrT.mapCategories.Count)
				{
					if (qsfyHFFvmMTpciUcQMriaZmvcdrT.mapCategories[EPjMyJWmyGthnWGOUaVPInvLJeoJ].userAssignable && qsfyHFFvmMTpciUcQMriaZmvcdrT.mapCategories[EPjMyJWmyGthnWGOUaVPInvLJeoJ].tag.Equals(AlVmonzQqqAsGsjCGTCQyQzoixDj, StringComparison.OrdinalIgnoreCase))
					{
						RGkyWJLTEBkoCkMOlEhshtwZiZlO = qsfyHFFvmMTpciUcQMriaZmvcdrT.mapCategories[EPjMyJWmyGthnWGOUaVPInvLJeoJ];
						BqvrWSKjyOhcCaNnMADSbGEpiAaj = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				EPjMyJWmyGthnWGOUaVPInvLJeoJ++;
				goto IL_00c3;
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

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				QXcEJKiVvfqMmcWXVuPRrGkFinMSA qXcEJKiVvfqMmcWXVuPRrGkFinMSA;
				if (BqvrWSKjyOhcCaNnMADSbGEpiAaj == -2 && wdAfkbcmprHwGtMqXaLxhybkmnOm == Environment.CurrentManagedThreadId)
				{
					BqvrWSKjyOhcCaNnMADSbGEpiAaj = 0;
					qXcEJKiVvfqMmcWXVuPRrGkFinMSA = this;
				}
				else
				{
					qXcEJKiVvfqMmcWXVuPRrGkFinMSA = new QXcEJKiVvfqMmcWXVuPRrGkFinMSA(0);
					qXcEJKiVvfqMmcWXVuPRrGkFinMSA.QsfyHFFvmMTpciUcQMriaZmvcdrT = QsfyHFFvmMTpciUcQMriaZmvcdrT;
				}
				qXcEJKiVvfqMmcWXVuPRrGkFinMSA.AlVmonzQqqAsGsjCGTCQyQzoixDj = OLqhuIaTeMCuAjKjZETiddiPskVJA;
				return qXcEJKiVvfqMmcWXVuPRrGkFinMSA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class vPPsXeMpJXcVJrPwbawtkPngsvNS : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int OTjbttcuwxwMTEJGsykTVcCdsUSd;

			private InputCategory YlHJHPkykVfaAIsbpSrRNKynpBnV;

			private int QKqjtWcADrmfYdDNuElWeGLsAiDF;

			public UserData nwhCSkSsyUIqRHfBNJJcTNwgyCmt;

			private int kSdNtBBLpzXgQIIgSIYAHOpIICrt;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return YlHJHPkykVfaAIsbpSrRNKynpBnV;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return YlHJHPkykVfaAIsbpSrRNKynpBnV;
				}
			}

			[DebuggerHidden]
			public vPPsXeMpJXcVJrPwbawtkPngsvNS(int P_0)
			{
				OTjbttcuwxwMTEJGsykTVcCdsUSd = P_0;
				QKqjtWcADrmfYdDNuElWeGLsAiDF = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				OTjbttcuwxwMTEJGsykTVcCdsUSd = -2;
			}

			private bool MoveNext()
			{
				int oTjbttcuwxwMTEJGsykTVcCdsUSd = OTjbttcuwxwMTEJGsykTVcCdsUSd;
				UserData userData = nwhCSkSsyUIqRHfBNJJcTNwgyCmt;
				if (oTjbttcuwxwMTEJGsykTVcCdsUSd != 0)
				{
					if (oTjbttcuwxwMTEJGsykTVcCdsUSd != 1)
					{
						return false;
					}
					OTjbttcuwxwMTEJGsykTVcCdsUSd = -1;
					goto IL_0070;
				}
				OTjbttcuwxwMTEJGsykTVcCdsUSd = -1;
				if (userData.actionCategories == null)
				{
					return false;
				}
				kSdNtBBLpzXgQIIgSIYAHOpIICrt = 0;
				goto IL_0080;
				IL_0080:
				if (kSdNtBBLpzXgQIIgSIYAHOpIICrt < userData.actionCategories.Count)
				{
					if (userData.actionCategories[kSdNtBBLpzXgQIIgSIYAHOpIICrt].userAssignable)
					{
						YlHJHPkykVfaAIsbpSrRNKynpBnV = userData.actionCategories[kSdNtBBLpzXgQIIgSIYAHOpIICrt];
						OTjbttcuwxwMTEJGsykTVcCdsUSd = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				kSdNtBBLpzXgQIIgSIYAHOpIICrt++;
				goto IL_0080;
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

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				vPPsXeMpJXcVJrPwbawtkPngsvNS vPPsXeMpJXcVJrPwbawtkPngsvNS2;
				if (OTjbttcuwxwMTEJGsykTVcCdsUSd == -2 && QKqjtWcADrmfYdDNuElWeGLsAiDF == Environment.CurrentManagedThreadId)
				{
					OTjbttcuwxwMTEJGsykTVcCdsUSd = 0;
					vPPsXeMpJXcVJrPwbawtkPngsvNS2 = this;
				}
				else
				{
					vPPsXeMpJXcVJrPwbawtkPngsvNS2 = new vPPsXeMpJXcVJrPwbawtkPngsvNS(0);
					vPPsXeMpJXcVJrPwbawtkPngsvNS2.nwhCSkSsyUIqRHfBNJJcTNwgyCmt = nwhCSkSsyUIqRHfBNJJcTNwgyCmt;
				}
				return vPPsXeMpJXcVJrPwbawtkPngsvNS2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class WLDrFbyKmQGetEtVzZwnbPCcbyzF : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int WEtinldQmIetsWoMhdgvKMzmNYXe;

			private InputAction hKXNAEaszVfsmIOUZeAUmnSctloVA;

			private int BuPeNvWGrwqWlcAwQvrJujYrSZGh;

			public UserData TnDcSqNibSMQTgNPVEpCYxDwXYFG;

			private int FaLbtUoqOBZmlWqSalvUnhXdyUIl;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return hKXNAEaszVfsmIOUZeAUmnSctloVA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return hKXNAEaszVfsmIOUZeAUmnSctloVA;
				}
			}

			[DebuggerHidden]
			public WLDrFbyKmQGetEtVzZwnbPCcbyzF(int P_0)
			{
				WEtinldQmIetsWoMhdgvKMzmNYXe = P_0;
				BuPeNvWGrwqWlcAwQvrJujYrSZGh = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				WEtinldQmIetsWoMhdgvKMzmNYXe = -2;
			}

			private bool MoveNext()
			{
				int wEtinldQmIetsWoMhdgvKMzmNYXe = WEtinldQmIetsWoMhdgvKMzmNYXe;
				UserData tnDcSqNibSMQTgNPVEpCYxDwXYFG = TnDcSqNibSMQTgNPVEpCYxDwXYFG;
				if (wEtinldQmIetsWoMhdgvKMzmNYXe != 0)
				{
					if (wEtinldQmIetsWoMhdgvKMzmNYXe != 1)
					{
						return false;
					}
					WEtinldQmIetsWoMhdgvKMzmNYXe = -1;
					goto IL_007a;
				}
				WEtinldQmIetsWoMhdgvKMzmNYXe = -1;
				if (tnDcSqNibSMQTgNPVEpCYxDwXYFG.KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
				{
					return false;
				}
				FaLbtUoqOBZmlWqSalvUnhXdyUIl = 0;
				goto IL_008c;
				IL_008c:
				if (FaLbtUoqOBZmlWqSalvUnhXdyUIl < tnDcSqNibSMQTgNPVEpCYxDwXYFG.KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count)
				{
					InputAction inputAction = tnDcSqNibSMQTgNPVEpCYxDwXYFG.KjpBhkIfmcTdvqlYyhEYCGfoYYtV[FaLbtUoqOBZmlWqSalvUnhXdyUIl];
					InputCategory actionCategoryById = tnDcSqNibSMQTgNPVEpCYxDwXYFG.GetActionCategoryById(inputAction.categoryId);
					if (actionCategoryById != null && actionCategoryById.userAssignable && inputAction.userAssignable)
					{
						hKXNAEaszVfsmIOUZeAUmnSctloVA = inputAction;
						WEtinldQmIetsWoMhdgvKMzmNYXe = 1;
						return true;
					}
					goto IL_007a;
				}
				return false;
				IL_007a:
				FaLbtUoqOBZmlWqSalvUnhXdyUIl++;
				goto IL_008c;
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

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				WLDrFbyKmQGetEtVzZwnbPCcbyzF wLDrFbyKmQGetEtVzZwnbPCcbyzF;
				if (WEtinldQmIetsWoMhdgvKMzmNYXe == -2 && BuPeNvWGrwqWlcAwQvrJujYrSZGh == Environment.CurrentManagedThreadId)
				{
					WEtinldQmIetsWoMhdgvKMzmNYXe = 0;
					wLDrFbyKmQGetEtVzZwnbPCcbyzF = this;
				}
				else
				{
					wLDrFbyKmQGetEtVzZwnbPCcbyzF = new WLDrFbyKmQGetEtVzZwnbPCcbyzF(0);
					wLDrFbyKmQGetEtVzZwnbPCcbyzF.TnDcSqNibSMQTgNPVEpCYxDwXYFG = TnDcSqNibSMQTgNPVEpCYxDwXYFG;
				}
				return wLDrFbyKmQGetEtVzZwnbPCcbyzF;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class EgEIxTUWqisiihZDRcLHPoEBfCkX : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int jhfmUajvFunXiAKXtdZnzdNlciFJA;

			private InputMapCategory EVbnOXVqUChJSssbTfcRQNdiegDl;

			private int IJLgKSdoSKvLhAFIEZCNvysSPRhZ;

			public UserData HflEVtawJkCJCEOvCUVQDdvpoolU;

			private int owZglMHOYXQCqMGIdGtvRsGnokPV;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return EVbnOXVqUChJSssbTfcRQNdiegDl;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return EVbnOXVqUChJSssbTfcRQNdiegDl;
				}
			}

			[DebuggerHidden]
			public EgEIxTUWqisiihZDRcLHPoEBfCkX(int P_0)
			{
				jhfmUajvFunXiAKXtdZnzdNlciFJA = P_0;
				IJLgKSdoSKvLhAFIEZCNvysSPRhZ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				jhfmUajvFunXiAKXtdZnzdNlciFJA = -2;
			}

			private bool MoveNext()
			{
				int num = jhfmUajvFunXiAKXtdZnzdNlciFJA;
				UserData hflEVtawJkCJCEOvCUVQDdvpoolU = HflEVtawJkCJCEOvCUVQDdvpoolU;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					jhfmUajvFunXiAKXtdZnzdNlciFJA = -1;
					goto IL_0070;
				}
				jhfmUajvFunXiAKXtdZnzdNlciFJA = -1;
				if (hflEVtawJkCJCEOvCUVQDdvpoolU.mapCategories == null)
				{
					return false;
				}
				owZglMHOYXQCqMGIdGtvRsGnokPV = 0;
				goto IL_0080;
				IL_0080:
				if (owZglMHOYXQCqMGIdGtvRsGnokPV < hflEVtawJkCJCEOvCUVQDdvpoolU.mapCategories.Count)
				{
					if (hflEVtawJkCJCEOvCUVQDdvpoolU.mapCategories[owZglMHOYXQCqMGIdGtvRsGnokPV].userAssignable)
					{
						EVbnOXVqUChJSssbTfcRQNdiegDl = hflEVtawJkCJCEOvCUVQDdvpoolU.mapCategories[owZglMHOYXQCqMGIdGtvRsGnokPV];
						jhfmUajvFunXiAKXtdZnzdNlciFJA = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				owZglMHOYXQCqMGIdGtvRsGnokPV++;
				goto IL_0080;
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

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				EgEIxTUWqisiihZDRcLHPoEBfCkX egEIxTUWqisiihZDRcLHPoEBfCkX;
				if (jhfmUajvFunXiAKXtdZnzdNlciFJA == -2 && IJLgKSdoSKvLhAFIEZCNvysSPRhZ == Environment.CurrentManagedThreadId)
				{
					jhfmUajvFunXiAKXtdZnzdNlciFJA = 0;
					egEIxTUWqisiihZDRcLHPoEBfCkX = this;
				}
				else
				{
					egEIxTUWqisiihZDRcLHPoEBfCkX = new EgEIxTUWqisiihZDRcLHPoEBfCkX(0);
					egEIxTUWqisiihZDRcLHPoEBfCkX.HflEVtawJkCJCEOvCUVQDdvpoolU = HflEVtawJkCJCEOvCUVQDdvpoolU;
				}
				return egEIxTUWqisiihZDRcLHPoEBfCkX;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ConfigVars configVars = new ConfigVars();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Player_Editor> players = new List<Player_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputAction> actions = new List<InputAction>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputActionCategory> actionCategories = new List<InputActionCategory>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ActionCategoryMap actionCategoryMap = new ActionCategoryMap();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputBehavior> inputBehaviors = new List<InputBehavior>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputMapCategory> mapCategories = new List<InputMapCategory>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> joystickLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> keyboardLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> mouseLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> customControllerLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> joystickMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> keyboardMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> mouseMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> customControllerMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<CustomController_Editor> customControllers = new List<CustomController_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets = new List<ControllerMapLayoutManager_RuleSet_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets = new List<ControllerMapEnabler_RuleSet_Editor>();

		[NonSerialized]
		private List<InputAction> OLwcduRTTyRMeswkSeDckvmFIKzr;

		[NonSerialized]
		private bool MAOQfwotRlxeTlyjOrxROWhoPHqN;

		[CompilerGenerated]
		private IList<Player_Editor> _003CPlayers_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputAction> _003CActions_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputCategory> _003CActionCategories_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputBehavior> _003CInputBehaviors_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputMapCategory> _003CMapCategories_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputLayout> _003CJoystickLayouts_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputLayout> _003CKeyboardLayouts_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputLayout> _003CMouseLayouts_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputLayout> _003CCustomControllerLayouts_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ControllerMap_Editor> _003CJoystickMaps_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ControllerMap_Editor> _003CKeyboardMaps_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ControllerMap_Editor> _003CMouseMaps_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ControllerMap_Editor> _003CCustomControllerMaps_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ControllerMapLayoutManager_RuleSet_Editor> _003CControllerMapLayoutManagerRuleSets_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ControllerMapEnabler_RuleSet_Editor> _003CControllerMapEnablerRuleSets_readOnly_003Ek__BackingField;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int playerIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int actionIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int actionCategoryIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int inputBehaviorIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int mapCategoryIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int joystickLayoutIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int keyboardLayoutIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int mouseLayoutIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int customControllerLayoutIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int joystickMapIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int keyboardMapIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int mouseMapIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int customControllerMapIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int customControllerIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int controllerMapLayoutManagerSetIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int controllerMapEnablerSetIdCounter;

		private Func<int, bool> containsActionDelegate;

		internal IList<Player_Editor> vdPnOLKbJBrenRKPKDLPhLsjfLpuA
		{
			[CompilerGenerated]
			get
			{
				return _003CPlayers_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CPlayers_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputAction> qLmGgelEtCFIrcKQogHVHNKgxRHbb
		{
			[CompilerGenerated]
			get
			{
				return _003CActions_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CActions_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputCategory> ebzZGJKfJpNnscyRdhoBrwNEjaYL
		{
			[CompilerGenerated]
			get
			{
				return _003CActionCategories_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CActionCategories_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputBehavior> nzDQYgGGbqRtIGyQvGGLWGneidUl
		{
			[CompilerGenerated]
			get
			{
				return _003CInputBehaviors_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CInputBehaviors_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputMapCategory> FipgqCjMcjkrijvORJhmaWVzOZIgA
		{
			[CompilerGenerated]
			get
			{
				return _003CMapCategories_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CMapCategories_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputLayout> LIJrEcSiTrDdQDDpsrujKIBwYXsgA
		{
			[CompilerGenerated]
			get
			{
				return _003CJoystickLayouts_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CJoystickLayouts_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputLayout> rGaQuyGlgbwHmSYClPgheHLQLOTj
		{
			[CompilerGenerated]
			get
			{
				return _003CKeyboardLayouts_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CKeyboardLayouts_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputLayout> iNexhKoDOWOSnTaVoYisPmtBBadgA
		{
			[CompilerGenerated]
			get
			{
				return _003CMouseLayouts_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CMouseLayouts_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputLayout> hMnwghkSDlwrrbGKxMUJewpksrtW
		{
			[CompilerGenerated]
			get
			{
				return _003CCustomControllerLayouts_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CCustomControllerLayouts_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<ControllerMap_Editor> iZGtgBfOZuUkqQqnHesOdySruPlhA
		{
			[CompilerGenerated]
			get
			{
				return _003CJoystickMaps_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CJoystickMaps_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<ControllerMap_Editor> MaBnHxvkNraKgaYflNYPoCdMfgnIA
		{
			[CompilerGenerated]
			get
			{
				return _003CKeyboardMaps_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CKeyboardMaps_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<ControllerMap_Editor> xStBDbeetOwShCFLpfectRvBvzzNA
		{
			[CompilerGenerated]
			get
			{
				return _003CMouseMaps_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CMouseMaps_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<ControllerMap_Editor> dhPsUrwObpzEafbxDAriwyUlNur
		{
			[CompilerGenerated]
			get
			{
				return _003CCustomControllerMaps_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CCustomControllerMaps_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> PlTGRdFlQtpIWqoZoeURGwdGYPijB
		{
			[CompilerGenerated]
			get
			{
				return _003CControllerMapLayoutManagerRuleSets_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CControllerMapLayoutManagerRuleSets_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<ControllerMapEnabler_RuleSet_Editor> yXIpFSmRGXrLjiDGmiUQefIyVlnk
		{
			[CompilerGenerated]
			get
			{
				return _003CControllerMapEnablerRuleSets_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CControllerMapEnablerRuleSets_readOnly_003Ek__BackingField = list;
			}
		}

		public ConfigVars ConfigVars => configVars;

		internal IEnumerable<InputMapCategory> VhchGLDYgLpBjEvGYpWVEuVqLyZEA
		{
			[IteratorStateMachine(typeof(EgEIxTUWqisiihZDRcLHPoEBfCkX))]
			get
			{
				return new EgEIxTUWqisiihZDRcLHPoEBfCkX(-2)
				{
					HflEVtawJkCJCEOvCUVQDdvpoolU = this
				};
			}
		}

		internal IEnumerable<InputCategory> fOHoEpKqqDEmCjmzSgOYowxYcdyJA
		{
			[IteratorStateMachine(typeof(vPPsXeMpJXcVJrPwbawtkPngsvNS))]
			get
			{
				return new vPPsXeMpJXcVJrPwbawtkPngsvNS(-2)
				{
					nwhCSkSsyUIqRHfBNJJcTNwgyCmt = this
				};
			}
		}

		internal IEnumerable<InputAction> pGqkstGwieuWePYeuoZnjhFNgpJU
		{
			[IteratorStateMachine(typeof(WLDrFbyKmQGetEtVzZwnbPCcbyzF))]
			get
			{
				return new WLDrFbyKmQGetEtVzZwnbPCcbyzF(-2)
				{
					TnDcSqNibSMQTgNPVEpCYxDwXYFG = this
				};
			}
		}

		public int playerCount
		{
			get
			{
				if (players == null)
				{
					return 0;
				}
				return players.Count;
			}
		}

		private List<InputAction> KjpBhkIfmcTdvqlYyhEYCGfoYYtV
		{
			get
			{
				if (!ReInput.isReady)
				{
					return actions;
				}
				return OLwcduRTTyRMeswkSeDckvmFIKzr;
			}
		}

		[IteratorStateMachine(typeof(HrPqkiCYEQCUqMstNGgiWwJwmRAe))]
		internal IEnumerable<InputMapCategory> TEvJvtXzUfCzEWBPTmZwhGxRogLP(string P_0)
		{
			return new HrPqkiCYEQCUqMstNGgiWwJwmRAe(-2)
			{
				xocGbyptnrfjRLoVAqShiiIGrGSA = this,
				nhNguaAQZieTWdgwSOOCFPzipYlAb = P_0
			};
		}

		[IteratorStateMachine(typeof(QXcEJKiVvfqMmcWXVuPRrGkFinMSA))]
		internal IEnumerable<InputMapCategory> UpQXFELjWgodNZTdCXTWeBrQbTfb(string P_0)
		{
			return new QXcEJKiVvfqMmcWXVuPRrGkFinMSA(-2)
			{
				QsfyHFFvmMTpciUcQMriaZmvcdrT = this,
				OLqhuIaTeMCuAjKjZETiddiPskVJA = P_0
			};
		}

		[IteratorStateMachine(typeof(QOnZkZZdjTEwUDAkgzpofHhaOYtB))]
		internal IEnumerable<InputCategory> iSRGfsuUescbOEJZQuAnYjnaYcrn(string P_0)
		{
			return new QOnZkZZdjTEwUDAkgzpofHhaOYtB(-2)
			{
				rRLAzljvDFevygXcxRhYRGUMxDpH = this,
				skeGTWQvwewwpzdShaUpXqTTTcZo = P_0
			};
		}

		[IteratorStateMachine(typeof(QCmpSZsOOYxgdtfpypvixZSNUpYe))]
		internal IEnumerable<InputCategory> MzaieyWaCFVNxxCagpPRtsQluncN(string P_0)
		{
			return new QCmpSZsOOYxgdtfpypvixZSNUpYe(-2)
			{
				dVVTtiMhySIMdDHLodNcvvofOESj = this,
				lbEVfVIpAeadPCtkzRwRsctQOHoIA = P_0
			};
		}

		[IteratorStateMachine(typeof(TPqzpQMTHQdCzWnyWtClcDSyeeEO))]
		internal IEnumerable<InputAction> UCocuAHZHWdgDRYkXKlGOYHARrUqA(int P_0, bool P_1)
		{
			return new TPqzpQMTHQdCzWnyWtClcDSyeeEO(-2)
			{
				hhBGFMHYvCOXzorQzfESKpQUHNpVA = this,
				MzPVVzPnbcaGoljMJtJklNAnHBFeA = P_0,
				kkmUKVbeJtMhPYQPnojAwgYOTaQq = P_1
			};
		}

		[IteratorStateMachine(typeof(aHKOhRNZPSELPyMsHEvQsKaWeZOP))]
		internal IEnumerable<InputAction> ktgmVGxmbchNMSKNAUarccGYGegt(string P_0, bool P_1)
		{
			return new aHKOhRNZPSELPyMsHEvQsKaWeZOP(-2)
			{
				uwaEGfgqIQQRGxOSKaDCsvHgHSdl = this,
				JPqPatDHaDlQxsimTBZnyxroDGYB = P_0,
				nOxpklUdXvBywSTXXfDERQuGVqAv = P_1
			};
		}

		[IteratorStateMachine(typeof(lILEdFisyGosFpUiUkQajpDZKMPOA))]
		internal IEnumerable<InputAction> LRKfvogtfHJPYmZRxfaymrqqFwil(string P_0)
		{
			return new lILEdFisyGosFpUiUkQajpDZKMPOA(-2)
			{
				TuhSXrRxPDDyVNjvysSPdseaGXsN = this,
				IjMazwQMVZspPEbmIYqhdxMwHbOh = P_0
			};
		}

		[IteratorStateMachine(typeof(nGHawdHrJojxsbwZNnyvocVXNFDib))]
		internal IEnumerable<InputAction> psAJubqSNLDlpAkwbkaZWjbOHFKHb(int P_0, bool P_1)
		{
			return new nGHawdHrJojxsbwZNnyvocVXNFDib(-2)
			{
				IDqbEbIStrjahAffsWTpPJsKHOqab = this,
				fFkAcozyACBWAmVxJpDYYWnhLTVh = P_0,
				HLgTDFyRbDJrOoIgflpSlbaOljBD = P_1
			};
		}

		[IteratorStateMachine(typeof(uhRpAUYlSybsqkbsKkOzKYjgjAoSA))]
		internal IEnumerable<InputAction> KqYnWXGqujzZytgDvyaJqhzuBQXM(string P_0, bool P_1)
		{
			return new uhRpAUYlSybsqkbsKkOzKYjgjAoSA(-2)
			{
				ZbOrWciWslDJODySQcaqppcIbZot = this,
				gVmcOkeQPhhMXsHLEuGGRRkEjKOeb = P_0,
				SCHOErUIfLqyuIeWjHUiVinHvLsi = P_1
			};
		}

		public UserData()
			: this(true)
		{
		}

		private UserData(bool P_0)
		{
			if (P_0)
			{
				configVars.updateLoop = UpdateLoopSetting.Update;
				configVars.defaultJoystickAxis2DDeadZoneType = DeadZone2DType.Radial;
				configVars.defaultJoystickAxis2DSensitivityType = AxisSensitivity2DType.Radial;
				Player_Editor player_Editor = KfttDDqTOyZUSGOgXjBltZfjymVH();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.key = "system_player";
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputActionCategory inputActionCategory = qFkqDgmDKCzHJYpiaoycizhBrbIk();
				inputActionCategory.name = "Default";
				inputActionCategory.descriptiveName = inputActionCategory.name;
				actionCategories.Add(inputActionCategory);
				actionCategoryMap.AddCategory(inputActionCategory.id);
				InputBehavior inputBehavior = XvwNxTkAVgweplswpUiIszOHpsP();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = WonvcyyEZvPtpOOqTfffCAMCEIflA();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = qoAAQsBOyZSBWAUUdenRucjjQvUI();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = vPWWMZPrYODRyDgOmFtDYaKeuqvD();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = DClLeISLfIMsZONjBCvWGAvhqujB();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = BeRZuPzUSLvOyuKVXhMkKrBXVaDl();
				inputLayout4.name = "Default";
				inputLayout4.descriptiveName = inputLayout4.name;
				customControllerLayouts.Add(inputLayout3);
			}
		}

		[CustomObfuscation(rename = false)]
		internal void SetDefaultValuesOnCreation(DefaultUnityInputSource defaultUnityInputSource, bool isUnityInputManagerEnabled, bool areUnityInputManagerEntriesInstalled, bool isUnityInputSystemAvailable, bool isIMUsePhysicalKeysEnabled)
		{
			configVars.platformVars_osxStandalone = new ConfigVars.PlatformVars_OSXStandalone();
			configVars.platformVars_osxStandalone.useAppleGameController = true;
			configVars.ios_primaryInputSource = IOSPrimaryInputSource.Native;
			configVars.tvos_primaryInputSource = TVOSPrimaryInputSource.Native;
			configVars.platformVars_windowsStandalone = new ConfigVars.PlatformVars_WindowsStandalone();
			configVars.platformVars_windowsStandalone.useWindowsGamingInput = true;
			configVars.keyCombinationOverrideMode = KeyCombinationOverrideMode.Cancel;
			configVars.generateKeyEventsOnKeyCombinationOverride = true;
			UnityInputSourceType unityInputSourceType = ((UnityTools.supportsUnityInputSystem && isUnityInputSystemAvailable && (!isUnityInputManagerEnabled || !areUnityInputManagerEntriesInstalled)) ? UnityInputSourceType.InputSystem : UnityInputSourceType.InputManager);
			if (unityInputSourceType == UnityInputSourceType.InputSystem)
			{
				configVars.fallbackInputSource = UnityInputSourceType.InputSystem;
				configVars.showSystemKeyLabels = true;
			}
			if (UnityTools.supportsPhysicalKeys)
			{
				configVars.unityUsePhysicalKeys = isIMUsePhysicalKeysEnabled;
				if (unityInputSourceType == UnityInputSourceType.InputSystem)
				{
					configVars.unityUsePhysicalKeys = true;
				}
			}
			if (UnityTools.supportsUnityInputSystem)
			{
				if (unityInputSourceType == UnityInputSourceType.InputSystem)
				{
					configVars.ps4_primaryInputSource = PS4PrimaryInputSource.PS4UnityInputSystem;
					configVars.ps5_primaryInputSource = PS5PrimaryInputSource.PS5UnityInputSystem;
				}
				configVars.android_primaryInputSource = (AndroidPrimaryInputSource)102;
			}
		}

		public List<InputAction> GetActions_Copy()
		{
			List<InputAction> list = new List<InputAction>();
			for (int i = 0; i < KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count; i++)
			{
				list.Add(KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i]);
			}
			return list;
		}

		public List<InputBehavior> GetInputBehaviors_Copy()
		{
			List<InputBehavior> list = new List<InputBehavior>();
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				list.Add(inputBehaviors[i].Clone());
			}
			return list;
		}

		public List<KeyboardMap> GetKeyboardMaps_Copy()
		{
			List<KeyboardMap> list = new List<KeyboardMap>();
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				KeyboardMap item = keyboardMaps[i].iDMbWIadQzhnIVNiAEQYqNaUhfVhb(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				MouseMap item = mouseMaps[i].cYbPSLFvkvTdPbdflbNEwDbMURiO(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public void AddPlayer()
		{
			players.Add(KfttDDqTOyZUSGOgXjBltZfjymVH());
		}

		public void InsertPlayer(int index)
		{
			if (index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.Insert(index, KfttDDqTOyZUSGOgXjBltZfjymVH());
		}

		public void DeletePlayer(int index)
		{
			if (players == null || index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.RemoveAt(index);
		}

		public bool ReorderPlayer(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(players, index, offsetDown, offsetNow);
		}

		public void DuplicatePlayer(int index)
		{
			if (players == null || index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			Player_Editor player_Editor = players[index].Clone();
			player_Editor.id = GetNewPlayerId();
			player_Editor.name = StringTools.IterateName(player_Editor.name, -1, GetPlayerNames());
			player_Editor.assignMouseOnStart = false;
			if (index == players.Count - 1)
			{
				players.Add(player_Editor);
			}
			else
			{
				players.Insert(index + 1, player_Editor);
			}
		}

		public string[] GetPlayerNames()
		{
			if (players == null)
			{
				return null;
			}
			string[] array = new string[players.Count];
			for (int i = 0; i < players.Count; i++)
			{
				array[i] = players[i].name;
			}
			return array;
		}

		public int GetPlayerNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (players == null)
			{
				return 0;
			}
			for (int i = 0; i < players.Count; i++)
			{
				results.Add(players[i].name);
			}
			return results.Count;
		}

		public int[] GetPlayerIds()
		{
			if (players == null)
			{
				return null;
			}
			int[] array = new int[players.Count];
			for (int i = 0; i < players.Count; i++)
			{
				array[i] = players[i].id;
			}
			return array;
		}

		public int[] GetPlayerRuntimeIds()
		{
			if (players == null)
			{
				return null;
			}
			int[] array = new int[players.Count];
			for (int i = 0; i < players.Count; i++)
			{
				if (i == 0)
				{
					array[i] = 9999999;
				}
				else
				{
					array[i] = i - 1;
				}
			}
			return array;
		}

		public int GetPlayerRuntimeIds(IList<int> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (players == null)
			{
				return 0;
			}
			for (int i = 0; i < players.Count; i++)
			{
				if (i == 0)
				{
					results.Add(9999999);
				}
				else
				{
					results.Add(i - 1);
				}
			}
			return results.Count;
		}

		public string GetPlayerNameById(int id)
		{
			if (players == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < players.Count; i++)
			{
				if (players[i].id == id)
				{
					return players[i].name;
				}
			}
			return string.Empty;
		}

		public Player_Editor GetPlayer(int index)
		{
			if (players == null || index < 0 || index >= players.Count)
			{
				return null;
			}
			return players[index];
		}

		public int GetPlayerId(string name)
		{
			if (players == null)
			{
				return -1;
			}
			for (int i = 0; i < players.Count; i++)
			{
				if (players[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return players[i].id;
				}
			}
			return -1;
		}

		public bool IsMouseAssigned()
		{
			if (players == null)
			{
				return false;
			}
			int count = players.Count;
			for (int i = 0; i < count; i++)
			{
				if (players[i].assignMouseOnStart)
				{
					return true;
				}
			}
			return false;
		}

		public void ClearMouseAssignments()
		{
			if (players != null)
			{
				int count = players.Count;
				for (int i = 0; i < count; i++)
				{
					players[i].assignMouseOnStart = false;
				}
			}
		}

		public bool IsKeyboardAssigned()
		{
			if (players == null)
			{
				return false;
			}
			int count = players.Count;
			for (int i = 0; i < count; i++)
			{
				if (players[i].assignKeyboardOnStart)
				{
					return true;
				}
			}
			return false;
		}

		public void ClearKeyboardAssignments()
		{
			if (players != null)
			{
				int count = players.Count;
				for (int i = 0; i < count; i++)
				{
					players[i].assignKeyboardOnStart = false;
				}
			}
		}

		public void AddAction(int categoryId)
		{
			InputAction inputAction = lnKuEhozdWIXtrmaOtKLXmZldmbK();
			inputAction.categoryId = categoryId;
			KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV != null)
			{
				InputAction inputAction = lnKuEhozdWIXtrmaOtKLXmZldmbK();
				inputAction.categoryId = categoryId;
				KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Add(inputAction);
				int index = actionCategoryMap.IndexOfAction(categoryId, actionId);
				actionCategoryMap.InsertAction(categoryId, inputAction.id, index);
			}
		}

		public void DeleteAction(int categoryId, int actionId)
		{
			if (IndexOfActionCategory(categoryId) >= 0)
			{
				int num = IndexOfAction(actionId);
				if (num >= 0)
				{
					KjpBhkIfmcTdvqlYyhEYCGfoYYtV.RemoveAt(num);
					actionCategoryMap.RemoveAction(categoryId, actionId);
				}
			}
		}

		public bool ReorderAction(int categoryId, int actionId, bool offsetDown, bool offsetNow)
		{
			return actionCategoryMap.ReorderAction(categoryId, actionId, offsetDown, offsetNow);
		}

		public int DuplicateAction_FromButton(int categoryId, int actionId)
		{
			if (IndexOfActionCategory(categoryId) < 0)
			{
				return -1;
			}
			int num = IndexOfAction(actionId);
			if (num < 0)
			{
				return -1;
			}
			InputAction actionById = GetActionById(actionId);
			if (actionById == null)
			{
				return -1;
			}
			InputAction inputAction = actionById.Clone();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
			if (num == KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count - 1)
			{
				KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Add(inputAction);
				actionCategoryMap.AddAction(categoryId, inputAction.id);
				return KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count - 1;
			}
			KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Insert(num + 1, inputAction);
			int num2 = actionCategoryMap.IndexOfAction(categoryId, actionId);
			actionCategoryMap.InsertAction(categoryId, inputAction.id, num2 + 1);
			return num + 1;
		}

		private int GtKwrmqccsXXExhLhSOAVVhcdwfF(int P_0, InputAction P_1)
		{
			if (IndexOfActionCategory(P_0) < 0)
			{
				return -1;
			}
			InputAction inputAction = P_1.Clone();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
			KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Add(inputAction);
			return KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count - 1;
		}

		public string[] GetActionNames()
		{
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return null;
			}
			string[] array = new string[KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count];
			for (int i = 0; i < KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count; i++)
			{
				array[i] = KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].name;
			}
			return array;
		}

		public int GetActionNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return 0;
			}
			for (int i = 0; i < KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count; i++)
			{
				results.Add(KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].name);
			}
			return results.Count;
		}

		public int[] GetActionIds()
		{
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return null;
			}
			int[] array = new int[KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count];
			for (int i = 0; i < KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count; i++)
			{
				array[i] = KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].id;
			}
			return array;
		}

		public int GetActionIds(IList<int> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return 0;
			}
			for (int i = 0; i < KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count; i++)
			{
				results.Add(KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].id);
			}
			return results.Count;
		}

		public string GetActionNameById(int id)
		{
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count; i++)
			{
				if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].id == id)
				{
					return KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].name;
				}
			}
			return string.Empty;
		}

		public InputAction GetAction(int index)
		{
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null || index < 0 || index >= KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count)
			{
				return null;
			}
			return KjpBhkIfmcTdvqlYyhEYCGfoYYtV[index];
		}

		public InputAction GetAction(string name)
		{
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return null;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return null;
			}
			return KjpBhkIfmcTdvqlYyhEYCGfoYYtV[num];
		}

		public InputAction GetActionById(int id)
		{
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return null;
			}
			for (int i = 0; i < KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count; i++)
			{
				if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].id == id)
				{
					return KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i];
				}
			}
			return null;
		}

		public int GetActionId(string name)
		{
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return -1;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return -1;
			}
			return KjpBhkIfmcTdvqlYyhEYCGfoYYtV[num].id;
		}

		public string[] GetSortedActionNamesInCategory(int id)
		{
			if (actionCategories == null || KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			foreach (int item in actionCategoryMap.ActionIdsInCategory(id))
			{
				InputAction actionById = GetActionById(item);
				if (actionById != null)
				{
					list.Add(actionById.name);
				}
			}
			return list.ToArray();
		}

		[IteratorStateMachine(typeof(fLpzVTLIKDsJTUZZKTaQKlgGHywEA))]
		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			return new fLpzVTLIKDsJTUZZKTaQKlgGHywEA(-2)
			{
				kDOiyHBwVEakOqbfUiaJpkzjNfqZ = this,
				UJDkGvRdJSQkuGXHMllikshHvxfA = id
			};
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			if (actionCategories == null || KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			foreach (int item in actionCategoryMap.ActionIdsInCategory(id))
			{
				InputAction actionById = GetActionById(item);
				if (actionById != null)
				{
					list.Add(actionById.descriptiveName);
				}
			}
			return list.ToArray();
		}

		[IteratorStateMachine(typeof(JoshFKZksUTJnIEtHuqDiqsSfTgw))]
		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			return new JoshFKZksUTJnIEtHuqDiqsSfTgw(-2)
			{
				KKuKrldKSDHJqSExOUXCsfkuNLtJ = this,
				jfyvDdNXYYHqdSYekGiqBLXlnjpX = id
			};
		}

		public int[] GetSortedActionIdsInCategory(int id)
		{
			if (actionCategories == null || KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return null;
			}
			List<int> list = new List<int>();
			foreach (int item in actionCategoryMap.ActionIdsInCategory(id))
			{
				list.Add(item);
			}
			return list.ToArray();
		}

		[IteratorStateMachine(typeof(spETIJfkTdwMWybOjGXRnGyRGFFE))]
		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			return new spETIJfkTdwMWybOjGXRnGyRGFFE(-2)
			{
				KFxksjqWahDLabyQaNgrkesYpzZl = this,
				XVJSURPogqPfnEPIzHzzxzrDndBr = id
			};
		}

		public bool ContainsAction(int id)
		{
			return IndexOfAction(id) >= 0;
		}

		public int IndexOfAction(int id)
		{
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return -1;
			}
			for (int i = 0; i < KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count; i++)
			{
				if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfAction(string name)
		{
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return -1;
			}
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count; i++)
			{
				if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public void AddActionCategory()
		{
			InputActionCategory inputActionCategory = qFkqDgmDKCzHJYpiaoycizhBrbIk();
			actionCategories.Add(inputActionCategory);
			actionCategoryMap.AddCategory(inputActionCategory.id);
		}

		public void InsertActionCategory(int index)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputActionCategory inputActionCategory = qFkqDgmDKCzHJYpiaoycizhBrbIk();
			actionCategories.Insert(index, inputActionCategory);
			actionCategoryMap.AddCategory(inputActionCategory.id);
		}

		public void DeleteActionCategory(int index)
		{
			if (actionCategories == null || index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = actionCategories[index].id;
			actionCategoryMap.RemoveCategory(id);
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV != null)
			{
				for (int num = KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count - 1; num >= 0; num--)
				{
					if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV[num].categoryId == id)
					{
						KjpBhkIfmcTdvqlYyhEYCGfoYYtV.RemoveAt(num);
					}
				}
			}
			actionCategories.RemoveAt(index);
		}

		public bool ReorderActionCategory(int index, bool offsetDown, bool offsetNow)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				return false;
			}
			return ListTools.OffsetAtIndex(actionCategories, index, offsetDown, offsetNow);
		}

		public void DuplicateActionCategory(int index, bool duplicateActions)
		{
			if (actionCategories == null || index < 0 || index >= actionCategories.Count)
			{
				return;
			}
			InputActionCategory inputActionCategory = new InputActionCategory(actionCategories[index]);
			inputActionCategory.id = GetNewActionCategoryId();
			inputActionCategory.name = StringTools.IterateName(inputActionCategory.name, -1, GetActionCategoryNames());
			if (index == actionCategories.Count - 1)
			{
				actionCategories.Add(inputActionCategory);
			}
			else
			{
				actionCategories.Insert(index + 1, inputActionCategory);
			}
			actionCategoryMap.AddCategory(inputActionCategory.id);
			if (!duplicateActions || KjpBhkIfmcTdvqlYyhEYCGfoYYtV == null)
			{
				return;
			}
			int id = inputActionCategory.id;
			int id2 = actionCategories[index].id;
			List<int> list = new List<int>();
			for (int i = 0; i < KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count; i++)
			{
				if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].categoryId == id2)
				{
					list.Add(i);
				}
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>(list.Count);
			for (int j = 0; j < list.Count; j++)
			{
				InputAction inputAction = KjpBhkIfmcTdvqlYyhEYCGfoYYtV[list[j]];
				int num = GtKwrmqccsXXExhLhSOAVVhcdwfF(id2, inputAction);
				if (num >= 0)
				{
					InputAction inputAction2 = KjpBhkIfmcTdvqlYyhEYCGfoYYtV[num];
					inputAction2.categoryId = id;
					dictionary.Add(inputAction.id, inputAction2.id);
				}
			}
			foreach (int item in actionCategoryMap.ActionIdsInCategory(id2))
			{
				if (dictionary.TryGetValue(item, out var value))
				{
					actionCategoryMap.AddAction(id, value);
				}
			}
		}

		public void ChangeActionCategory(int actionId, int newCategoryId)
		{
			int num = IndexOfAction(actionId);
			if (num >= 0 && KjpBhkIfmcTdvqlYyhEYCGfoYYtV[num].categoryId != newCategoryId)
			{
				actionCategoryMap.ChangeCategory(actionId, newCategoryId);
				KjpBhkIfmcTdvqlYyhEYCGfoYYtV[num].categoryId = newCategoryId;
			}
		}

		public int GetActionCategoryCount(int id)
		{
			if (actionCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV != null)
			{
				for (int i = 0; i < KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count; i++)
				{
					if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].categoryId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetActionCategoryIndex(int id)
		{
			if (actionCategories == null)
			{
				return 0;
			}
			for (int i = 0; i < actionCategories.Count; i++)
			{
				if (actionCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetActionCategoryNames()
		{
			if (actionCategories == null)
			{
				return null;
			}
			string[] array = new string[actionCategories.Count];
			for (int i = 0; i < actionCategories.Count; i++)
			{
				array[i] = actionCategories[i].name;
			}
			return array;
		}

		public int[] GetActionCategoryIds()
		{
			if (actionCategories == null)
			{
				return null;
			}
			int[] array = new int[actionCategories.Count];
			for (int i = 0; i < actionCategories.Count; i++)
			{
				array[i] = actionCategories[i].id;
			}
			return array;
		}

		public InputCategory GetActionCategory(int index)
		{
			if (actionCategories == null || index < 0 || index >= actionCategories.Count)
			{
				return null;
			}
			return actionCategories[index];
		}

		public InputCategory GetActionCategory(string name)
		{
			if (actionCategories == null)
			{
				return null;
			}
			int num = IndexOfActionCategory(name);
			if (num < 0)
			{
				return null;
			}
			return actionCategories[num];
		}

		public InputCategory GetActionCategoryById(int id)
		{
			int num = IndexOfActionCategory(id);
			if (num < 0)
			{
				return null;
			}
			return actionCategories[num];
		}

		public int GetActionCategoryId(string name)
		{
			if (actionCategories == null)
			{
				return -1;
			}
			int num = IndexOfActionCategory(name);
			if (num < 0)
			{
				return -1;
			}
			return actionCategories[num].id;
		}

		public string GetActionCategoryNameById(int id)
		{
			if (actionCategories == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < actionCategories.Count; i++)
			{
				if (actionCategories[i].id == id)
				{
					return actionCategories[i].name;
				}
			}
			return string.Empty;
		}

		public int IndexOfActionCategory(int id)
		{
			if (actionCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < actionCategories.Count; i++)
			{
				if (actionCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfActionCategory(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (actionCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < actionCategories.Count; i++)
			{
				if (actionCategories[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public int GetActionCategoryCount()
		{
			if (actionCategories == null)
			{
				return 0;
			}
			return actionCategories.Count;
		}

		public void AddInputBehavior()
		{
			inputBehaviors.Add(XvwNxTkAVgweplswpUiIszOHpsP());
		}

		public void InsertInputBehavior(int index)
		{
			if (index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			inputBehaviors.Insert(index, XvwNxTkAVgweplswpUiIszOHpsP());
		}

		public void DeleteInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = inputBehaviors[index].id;
			if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV != null)
			{
				for (int i = 0; i < KjpBhkIfmcTdvqlYyhEYCGfoYYtV.Count; i++)
				{
					if (KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].behaviorId == id)
					{
						KjpBhkIfmcTdvqlYyhEYCGfoYYtV[i].behaviorId = 0;
					}
				}
			}
			inputBehaviors.RemoveAt(index);
		}

		public bool ReorderInputBehavior(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(inputBehaviors, index, offsetDown, offsetNow);
		}

		public void DuplicateInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputBehavior inputBehavior = inputBehaviors[index].Clone();
			inputBehavior.id = GetNewInputBehaviorId();
			inputBehavior.name = StringTools.IterateName(inputBehavior.name, -1, GetInputBehaviorNames());
			if (index == inputBehaviors.Count - 1)
			{
				inputBehaviors.Add(inputBehavior);
			}
			else
			{
				inputBehaviors.Insert(index + 1, inputBehavior);
			}
		}

		public string[] GetInputBehaviorNames()
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			string[] array = new string[inputBehaviors.Count];
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				array[i] = inputBehaviors[i].name;
			}
			return array;
		}

		public int[] GetInputBehaviorIds()
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			int[] array = new int[inputBehaviors.Count];
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				array[i] = inputBehaviors[i].id;
			}
			return array;
		}

		public InputBehavior GetInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				return null;
			}
			return inputBehaviors[index];
		}

		public InputBehavior GetInputBehavior(string name)
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			int num = IndexOfInputBehavior(name);
			if (num < 0)
			{
				return null;
			}
			return inputBehaviors[num];
		}

		public InputBehavior GetInputBehaviorById(int id)
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				if (inputBehaviors[i].id == id)
				{
					return inputBehaviors[i];
				}
			}
			return null;
		}

		public int GetInputBehaviorId(string name)
		{
			if (inputBehaviors == null)
			{
				return -1;
			}
			int num = IndexOfInputBehavior(name);
			if (num < 0)
			{
				return -1;
			}
			return inputBehaviors[num].id;
		}

		public int IndexOfInputBehavior(int id)
		{
			if (inputBehaviors == null)
			{
				return -1;
			}
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				if (inputBehaviors[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfInputBehavior(string name)
		{
			if (inputBehaviors == null)
			{
				return -1;
			}
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				if (inputBehaviors[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public void AddMapCategory()
		{
			mapCategories.Add(WonvcyyEZvPtpOOqTfffCAMCEIflA());
		}

		public void InsertMapCategory(int index)
		{
			if (index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mapCategories.Insert(index, WonvcyyEZvPtpOOqTfffCAMCEIflA());
		}

		public void DeleteMapCategory(int index)
		{
			if (mapCategories == null || index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = mapCategories[index].id;
			if (joystickMaps != null)
			{
				for (int num = joystickMaps.Count - 1; num >= 0; num--)
				{
					if (joystickMaps[num].categoryId == id)
					{
						joystickMaps.RemoveAt(num);
					}
				}
			}
			if (keyboardMaps != null)
			{
				for (int num2 = keyboardMaps.Count - 1; num2 >= 0; num2--)
				{
					if (keyboardMaps[num2].categoryId == id)
					{
						keyboardMaps.RemoveAt(num2);
					}
				}
			}
			if (mouseMaps != null)
			{
				for (int num3 = mouseMaps.Count - 1; num3 >= 0; num3--)
				{
					if (mouseMaps[num3].categoryId == id)
					{
						mouseMaps.RemoveAt(num3);
					}
				}
			}
			if (customControllerMaps != null)
			{
				for (int num4 = customControllerMaps.Count - 1; num4 >= 0; num4--)
				{
					if (customControllerMaps[num4].categoryId == id)
					{
						customControllerMaps.RemoveAt(num4);
					}
				}
			}
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					InputMapCategory inputMapCategory = mapCategories[i];
					if (inputMapCategory.checkConflictsCategoryIds == null)
					{
						continue;
					}
					for (int j = 0; j < inputMapCategory.checkConflictsCategoryIds.Count; j++)
					{
						if (inputMapCategory.checkConflictsCategoryIds[j] == id)
						{
							inputMapCategory.checkConflictsCategoryIds.RemoveAt(j);
						}
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = vDvDegJIJiwlWkDfeCWBEawlTwaAb._003C_003E9.icNPwWqajOPwTdaeVStnLiZfumPJ;
				for (int k = 0; k < players.Count; k++)
				{
					Player_Editor player_Editor = players[k];
					if (player_Editor != null)
					{
						action(player_Editor.defaultKeyboardMaps, id);
						action(player_Editor.defaultMouseMaps, id);
						action(player_Editor.defaultJoystickMaps, id);
						action(player_Editor.defaultCustomControllerMaps, id);
					}
				}
			}
			mapCategories.RemoveAt(index);
		}

		public bool ReorderMapCategory(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(mapCategories, index, offsetDown, offsetNow);
		}

		public void DuplicateMapCategory(int index, bool duplicateMaps)
		{
			if (mapCategories == null || index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputMapCategory inputMapCategory = new InputMapCategory(mapCategories[index]);
			inputMapCategory.id = GetNewMapCategoryId();
			inputMapCategory.name = StringTools.IterateName(inputMapCategory.name, -1, GetMapCategoryNames());
			if (index == mapCategories.Count - 1)
			{
				mapCategories.Add(inputMapCategory);
			}
			else
			{
				mapCategories.Insert(index + 1, inputMapCategory);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputMapCategory.id;
			int id2 = mapCategories[index].id;
			if (joystickMaps != null)
			{
				for (int num = joystickMaps.Count - 1; num >= 0; num--)
				{
					if (joystickMaps[num].categoryId == id2)
					{
						int num2 = DuplicateJoystickMap(num);
						if (num2 >= 0)
						{
							joystickMaps[num2].categoryId = id;
						}
					}
				}
			}
			if (keyboardMaps != null)
			{
				for (int num3 = keyboardMaps.Count - 1; num3 >= 0; num3--)
				{
					if (keyboardMaps[num3].categoryId == id2)
					{
						int num4 = DuplicateKeyboardMap(num3);
						if (num4 >= 0)
						{
							keyboardMaps[num4].categoryId = id;
						}
					}
				}
			}
			if (mouseMaps != null)
			{
				for (int num5 = mouseMaps.Count - 1; num5 >= 0; num5--)
				{
					if (mouseMaps[num5].categoryId == id2)
					{
						int num6 = DuplicateMouseMap(num5);
						if (num6 >= 0)
						{
							mouseMaps[num6].categoryId = id;
						}
					}
				}
			}
			if (customControllerMaps == null)
			{
				return;
			}
			for (int num7 = customControllerMaps.Count - 1; num7 >= 0; num7--)
			{
				if (customControllerMaps[num7].categoryId == id2)
				{
					int num8 = DuplicateCustomControllerMap(num7);
					if (num8 >= 0)
					{
						customControllerMaps[num8].categoryId = id;
					}
				}
			}
		}

		public int GetMapCategoryMapCount(int id)
		{
			if (mapCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (joystickMaps != null)
			{
				for (int i = 0; i < joystickMaps.Count; i++)
				{
					if (joystickMaps[i].categoryId == id)
					{
						num++;
					}
				}
			}
			if (keyboardMaps != null)
			{
				for (int j = 0; j < keyboardMaps.Count; j++)
				{
					if (keyboardMaps[j].categoryId == id)
					{
						num++;
					}
				}
			}
			if (mouseMaps != null)
			{
				for (int k = 0; k < mouseMaps.Count; k++)
				{
					if (mouseMaps[k].categoryId == id)
					{
						num++;
					}
				}
			}
			if (customControllerMaps != null)
			{
				for (int l = 0; l < customControllerMaps.Count; l++)
				{
					if (customControllerMaps[l].categoryId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetMapCategoryIndex(int id)
		{
			if (mapCategories == null)
			{
				return 0;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetMapCategoryNames()
		{
			if (mapCategories == null)
			{
				return null;
			}
			string[] array = new string[mapCategories.Count];
			for (int i = 0; i < mapCategories.Count; i++)
			{
				array[i] = mapCategories[i].name;
			}
			return array;
		}

		public int[] GetMapCategoryIds()
		{
			if (mapCategories == null)
			{
				return null;
			}
			int[] array = new int[mapCategories.Count];
			for (int i = 0; i < mapCategories.Count; i++)
			{
				array[i] = mapCategories[i].id;
			}
			return array;
		}

		public InputMapCategory GetMapCategory(int index)
		{
			if (mapCategories == null || index < 0 || index >= mapCategories.Count)
			{
				return null;
			}
			return mapCategories[index];
		}

		public InputMapCategory GetMapCategory(string name)
		{
			if (mapCategories == null)
			{
				return null;
			}
			int num = IndexOfMapCategory(name);
			if (num < 0)
			{
				return null;
			}
			return mapCategories[num];
		}

		public InputMapCategory GetMapCategoryById(int id)
		{
			if (mapCategories == null)
			{
				return null;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].id == id)
				{
					return mapCategories[i];
				}
			}
			return null;
		}

		public int GetMapCategoryId(string name)
		{
			if (mapCategories == null)
			{
				return -1;
			}
			int num = IndexOfMapCategory(name);
			if (num < 0)
			{
				return -1;
			}
			return mapCategories[num].id;
		}

		public string GetMapCategoryNameById(int id)
		{
			if (mapCategories == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].id == id)
				{
					return mapCategories[i].name;
				}
			}
			return string.Empty;
		}

		public int IndexOfMapCategory(int id)
		{
			if (mapCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfMapCategory(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (mapCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetLayoutNames(ControllerType controllerType)
		{
			return controllerType switch
			{
				ControllerType.Keyboard => GetKeyboardLayoutNames(), 
				ControllerType.Mouse => GetMouseLayoutNames(), 
				ControllerType.Joystick => GetJoystickLayoutNames(), 
				ControllerType.Custom => GetCustomControllerLayoutNames(), 
				_ => throw new NotImplementedException(), 
			};
		}

		public int[] GetLayoutIds(ControllerType controllerType)
		{
			return controllerType switch
			{
				ControllerType.Keyboard => GetKeyboardLayoutIds(), 
				ControllerType.Mouse => GetMouseLayoutIds(), 
				ControllerType.Joystick => GetJoystickLayoutIds(), 
				ControllerType.Custom => GetCustomControllerLayoutIds(), 
				_ => throw new NotImplementedException(), 
			};
		}

		public void AddJoystickLayout()
		{
			joystickLayouts.Add(qoAAQsBOyZSBWAUUdenRucjjQvUI());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			joystickLayouts.Insert(index, qoAAQsBOyZSBWAUUdenRucjjQvUI());
		}

		public void DeleteJoystickLayout(int index)
		{
			if (joystickLayouts == null || index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = joystickLayouts[index].id;
			if (joystickMaps != null)
			{
				for (int num = joystickMaps.Count - 1; num >= 0; num--)
				{
					if (joystickMaps[num].layoutId == id)
					{
						joystickMaps.RemoveAt(num);
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = vDvDegJIJiwlWkDfeCWBEawlTwaAb._003C_003E9.NikGVXCynkaOVKBvijCBujNFkYvDA;
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor != null)
					{
						action(player_Editor.defaultJoystickMaps, id);
					}
				}
			}
			joystickLayouts.RemoveAt(index);
		}

		public bool ReorderJoystickLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(joystickLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateJoystickLayout(int index, bool duplicateMaps)
		{
			if (joystickLayouts == null || index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = joystickLayouts[index].Clone();
			inputLayout.id = GetNewJoystickLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetJoystickLayoutNames());
			if (index == joystickLayouts.Count - 1)
			{
				joystickLayouts.Add(inputLayout);
			}
			else
			{
				joystickLayouts.Insert(index + 1, inputLayout);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputLayout.id;
			int id2 = joystickLayouts[index].id;
			if (joystickMaps == null)
			{
				return;
			}
			for (int num = joystickMaps.Count - 1; num >= 0; num--)
			{
				if (joystickMaps[num].layoutId == id2)
				{
					int num2 = DuplicateJoystickMap(num);
					if (num2 >= 0)
					{
						joystickMaps[num2].layoutId = id;
					}
				}
			}
		}

		public int GetJoystickLayoutMapCount(int id)
		{
			if (joystickLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (joystickMaps != null)
			{
				for (int i = 0; i < joystickMaps.Count; i++)
				{
					if (joystickMaps[i].layoutId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetJoystickLayoutIndex(int id)
		{
			if (joystickLayouts == null)
			{
				return 0;
			}
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				if (joystickLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetJoystickLayoutNames()
		{
			if (joystickLayouts == null)
			{
				return null;
			}
			string[] array = new string[joystickLayouts.Count];
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				array[i] = joystickLayouts[i].name;
			}
			return array;
		}

		public int[] GetJoystickLayoutIds()
		{
			if (joystickLayouts == null)
			{
				return null;
			}
			int[] array = new int[joystickLayouts.Count];
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				array[i] = joystickLayouts[i].id;
			}
			return array;
		}

		public InputLayout GetJoystickLayout(int index)
		{
			if (joystickLayouts == null || index < 0 || index >= joystickLayouts.Count)
			{
				return null;
			}
			return joystickLayouts[index];
		}

		public InputLayout GetJoystickLayout(string name)
		{
			if (joystickLayouts == null)
			{
				return null;
			}
			int num = IndexOfJoystickLayout(name);
			if (num < 0)
			{
				return null;
			}
			return joystickLayouts[num];
		}

		public InputLayout GetJoystickLayoutById(int id)
		{
			if (joystickLayouts == null)
			{
				return null;
			}
			int num = IndexOfJoystickLayout(id);
			if (num < 0)
			{
				return null;
			}
			return joystickLayouts[num];
		}

		public int GetJoystickLayoutId(string name)
		{
			if (joystickLayouts == null)
			{
				return -1;
			}
			int num = IndexOfJoystickLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return joystickLayouts[num].id;
		}

		public int IndexOfJoystickLayout(int id)
		{
			if (joystickLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				if (joystickLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfJoystickLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (joystickLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				if (joystickLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetJoystickLayoutNameById(int id)
		{
			if (joystickLayouts != null)
			{
				for (int i = 0; i < joystickLayouts.Count; i++)
				{
					if (joystickLayouts[i].id == id)
					{
						return joystickLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		public void AddKeyboardLayout()
		{
			keyboardLayouts.Add(vPWWMZPrYODRyDgOmFtDYaKeuqvD());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			keyboardLayouts.Insert(index, vPWWMZPrYODRyDgOmFtDYaKeuqvD());
		}

		public void DeleteKeyboardLayout(int index)
		{
			if (keyboardLayouts == null || index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = keyboardLayouts[index].id;
			if (keyboardMaps != null)
			{
				for (int num = keyboardMaps.Count - 1; num >= 0; num--)
				{
					if (keyboardMaps[num].layoutId == id)
					{
						keyboardMaps.RemoveAt(num);
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = vDvDegJIJiwlWkDfeCWBEawlTwaAb._003C_003E9.EkpSkHEiBqiyAzpGdCqzWJlWQmjA;
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor != null)
					{
						action(player_Editor.defaultKeyboardMaps, id);
					}
				}
			}
			keyboardLayouts.RemoveAt(index);
		}

		public bool ReorderKeyboardLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(keyboardLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateKeyboardLayout(int index, bool duplicateMaps)
		{
			if (keyboardLayouts == null || index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = keyboardLayouts[index].Clone();
			inputLayout.id = GetNewKeyboardLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetKeyboardLayoutNames());
			if (index == keyboardLayouts.Count - 1)
			{
				keyboardLayouts.Add(inputLayout);
			}
			else
			{
				keyboardLayouts.Insert(index + 1, inputLayout);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputLayout.id;
			int id2 = keyboardLayouts[index].id;
			if (keyboardMaps == null)
			{
				return;
			}
			for (int num = keyboardMaps.Count - 1; num >= 0; num--)
			{
				if (keyboardMaps[num].layoutId == id2)
				{
					int num2 = DuplicateKeyboardMap(num);
					if (num2 >= 0)
					{
						keyboardMaps[num2].layoutId = id;
					}
				}
			}
		}

		public int GetKeyboardLayoutMapCount(int id)
		{
			if (keyboardLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (keyboardMaps != null)
			{
				for (int i = 0; i < keyboardMaps.Count; i++)
				{
					if (keyboardMaps[i].layoutId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetKeyboardLayoutIndex(int id)
		{
			if (keyboardLayouts == null)
			{
				return 0;
			}
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				if (keyboardLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetKeyboardLayoutNames()
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			string[] array = new string[keyboardLayouts.Count];
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				array[i] = keyboardLayouts[i].name;
			}
			return array;
		}

		public int[] GetKeyboardLayoutIds()
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			int[] array = new int[keyboardLayouts.Count];
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				array[i] = keyboardLayouts[i].id;
			}
			return array;
		}

		public InputLayout GetKeyboardLayout(int index)
		{
			if (keyboardLayouts == null || index < 0 || index >= keyboardLayouts.Count)
			{
				return null;
			}
			return keyboardLayouts[index];
		}

		public InputLayout GetKeyboardLayout(string name)
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			int num = IndexOfKeyboardLayout(name);
			if (num < 0)
			{
				return null;
			}
			return keyboardLayouts[num];
		}

		public InputLayout GetKeyboardLayoutById(int id)
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			int num = IndexOfKeyboardLayout(id);
			if (num < 0)
			{
				return null;
			}
			return keyboardLayouts[num];
		}

		public int GetKeyboardLayoutId(string name)
		{
			if (keyboardLayouts == null)
			{
				return -1;
			}
			int num = IndexOfKeyboardLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return keyboardLayouts[num].id;
		}

		public int IndexOfKeyboardLayout(int id)
		{
			if (keyboardLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				if (keyboardLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfKeyboardLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (keyboardLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				if (keyboardLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetKeyboardLayoutNameById(int id)
		{
			if (keyboardLayouts != null)
			{
				for (int i = 0; i < keyboardLayouts.Count; i++)
				{
					if (keyboardLayouts[i].id == id)
					{
						return keyboardLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		public void AddMouseLayout()
		{
			mouseLayouts.Add(DClLeISLfIMsZONjBCvWGAvhqujB());
		}

		public void InsertMouseLayout(int index)
		{
			if (index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mouseLayouts.Insert(index, DClLeISLfIMsZONjBCvWGAvhqujB());
		}

		public void DeleteMouseLayout(int index)
		{
			if (mouseLayouts == null || index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = mouseLayouts[index].id;
			if (mouseMaps != null)
			{
				for (int num = mouseMaps.Count - 1; num >= 0; num--)
				{
					if (mouseMaps[num].layoutId == id)
					{
						mouseMaps.RemoveAt(num);
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = vDvDegJIJiwlWkDfeCWBEawlTwaAb._003C_003E9.SIBWhTRTjEvsFVRzTpAEnYXGIggr;
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor != null)
					{
						action(player_Editor.defaultMouseMaps, id);
					}
				}
			}
			mouseLayouts.RemoveAt(index);
		}

		public bool ReorderMouseLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(mouseLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateMouseLayout(int index, bool duplicateMaps)
		{
			if (mouseLayouts == null || index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = mouseLayouts[index].Clone();
			inputLayout.id = GetNewMouseLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetMouseLayoutNames());
			if (index == mouseLayouts.Count - 1)
			{
				mouseLayouts.Add(inputLayout);
			}
			else
			{
				mouseLayouts.Insert(index + 1, inputLayout);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputLayout.id;
			int id2 = mouseLayouts[index].id;
			if (mouseMaps == null)
			{
				return;
			}
			for (int num = mouseMaps.Count - 1; num >= 0; num--)
			{
				if (mouseMaps[num].layoutId == id2)
				{
					int num2 = DuplicateMouseMap(num);
					if (num2 >= 0)
					{
						mouseMaps[num2].layoutId = id;
					}
				}
			}
		}

		public int GetMouseLayoutMapCount(int id)
		{
			if (mouseLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (mouseMaps != null)
			{
				for (int i = 0; i < mouseMaps.Count; i++)
				{
					if (mouseMaps[i].layoutId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetMouseLayoutIndex(int id)
		{
			if (mouseLayouts == null)
			{
				return 0;
			}
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				if (mouseLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetMouseLayoutNames()
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			string[] array = new string[mouseLayouts.Count];
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				array[i] = mouseLayouts[i].name;
			}
			return array;
		}

		public int[] GetMouseLayoutIds()
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			int[] array = new int[mouseLayouts.Count];
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				array[i] = mouseLayouts[i].id;
			}
			return array;
		}

		public InputLayout GetMouseLayout(int index)
		{
			if (mouseLayouts == null || index < 0 || index >= mouseLayouts.Count)
			{
				return null;
			}
			return mouseLayouts[index];
		}

		public InputLayout GetMouseLayout(string name)
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			int num = IndexOfMouseLayout(name);
			if (num < 0)
			{
				return null;
			}
			return mouseLayouts[num];
		}

		public InputLayout GetMouseLayoutById(int id)
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			int num = IndexOfMouseLayout(id);
			if (num < 0)
			{
				return null;
			}
			return mouseLayouts[num];
		}

		public int GetMouseLayoutId(string name)
		{
			if (mouseLayouts == null)
			{
				return -1;
			}
			int num = IndexOfMouseLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return mouseLayouts[num].id;
		}

		public int IndexOfMouseLayout(int id)
		{
			if (mouseLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				if (mouseLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfMouseLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (mouseLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				if (mouseLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetMouseLayoutNameById(int id)
		{
			if (mouseLayouts != null)
			{
				for (int i = 0; i < mouseLayouts.Count; i++)
				{
					if (mouseLayouts[i].id == id)
					{
						return mouseLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		public void AddCustomControllerLayout()
		{
			customControllerLayouts.Add(BeRZuPzUSLvOyuKVXhMkKrBXVaDl());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllerLayouts.Insert(index, BeRZuPzUSLvOyuKVXhMkKrBXVaDl());
		}

		public void DeleteCustomControllerLayout(int index)
		{
			if (customControllerLayouts == null || index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = customControllerLayouts[index].id;
			if (customControllerMaps != null)
			{
				for (int num = customControllerMaps.Count - 1; num >= 0; num--)
				{
					if (customControllerMaps[num].layoutId == id)
					{
						customControllerMaps.RemoveAt(num);
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = vDvDegJIJiwlWkDfeCWBEawlTwaAb._003C_003E9.omoaYeBiXjseGtVTOGCcjNyGvzrJB;
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor != null)
					{
						action(player_Editor.defaultCustomControllerMaps, id);
					}
				}
			}
			customControllerLayouts.RemoveAt(index);
		}

		public bool ReorderCustomControllerLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(customControllerLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateCustomControllerLayout(int index, bool duplicateMaps)
		{
			if (customControllerLayouts == null || index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = customControllerLayouts[index].Clone();
			inputLayout.id = GetNewCustomControllerLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetCustomControllerLayoutNames());
			if (index == customControllerLayouts.Count - 1)
			{
				customControllerLayouts.Add(inputLayout);
			}
			else
			{
				customControllerLayouts.Insert(index + 1, inputLayout);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputLayout.id;
			int id2 = customControllerLayouts[index].id;
			if (customControllerMaps == null)
			{
				return;
			}
			for (int num = customControllerMaps.Count - 1; num >= 0; num--)
			{
				if (customControllerMaps[num].layoutId == id2)
				{
					int num2 = DuplicateCustomControllerMap(num);
					if (num2 >= 0)
					{
						customControllerMaps[num2].layoutId = id;
					}
				}
			}
		}

		public int GetCustomControllerLayoutMapCount(int id)
		{
			if (customControllerLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (customControllerMaps != null)
			{
				for (int i = 0; i < customControllerMaps.Count; i++)
				{
					if (customControllerMaps[i].layoutId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetCustomControllerLayoutIndex(int id)
		{
			if (customControllerLayouts == null)
			{
				return 0;
			}
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				if (customControllerLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetCustomControllerLayoutNames()
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			string[] array = new string[customControllerLayouts.Count];
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				array[i] = customControllerLayouts[i].name;
			}
			return array;
		}

		public int[] GetCustomControllerLayoutIds()
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			int[] array = new int[customControllerLayouts.Count];
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				array[i] = customControllerLayouts[i].id;
			}
			return array;
		}

		public InputLayout GetCustomControllerLayout(int index)
		{
			if (customControllerLayouts == null || index < 0 || index >= customControllerLayouts.Count)
			{
				return null;
			}
			return customControllerLayouts[index];
		}

		public InputLayout GetCustomControllerLayout(string name)
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			int num = IndexOfCustomControllerLayout(name);
			if (num < 0)
			{
				return null;
			}
			return customControllerLayouts[num];
		}

		public InputLayout GetCustomControllerLayoutById(int id)
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			int num = IndexOfCustomControllerLayout(id);
			if (num < 0)
			{
				return null;
			}
			return customControllerLayouts[num];
		}

		public int GetCustomControllerLayoutId(string name)
		{
			if (customControllerLayouts == null)
			{
				return -1;
			}
			int num = IndexOfCustomControllerLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return customControllerLayouts[num].id;
		}

		public int IndexOfCustomControllerLayout(int id)
		{
			if (customControllerLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				if (customControllerLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfCustomControllerLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (customControllerLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				if (customControllerLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetCustomControllerLayoutNameById(int id)
		{
			if (customControllerLayouts != null)
			{
				for (int i = 0; i < customControllerLayouts.Count; i++)
				{
					if (customControllerLayouts[i].id == id)
					{
						return customControllerLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		public string GetLayoutNameById(ControllerType controllerType, int id)
		{
			return controllerType switch
			{
				ControllerType.Joystick => GetJoystickLayoutNameById(id), 
				ControllerType.Keyboard => GetKeyboardLayoutNameById(id), 
				ControllerType.Mouse => GetMouseLayoutNameById(id), 
				ControllerType.Custom => GetCustomControllerLayoutNameById(id), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal ControllerMap ScJIWgmKdhdnDAaTcyxOrBDAtCamA(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Joystick => TMFORpelFDlBYkjQHYfeVwSIdqrR((Joystick)P_0, P_1, P_2), 
				ControllerType.Keyboard => FindKeyboardMap_Game((Keyboard)P_0, P_1, P_2), 
				ControllerType.Mouse => FindMouseMap_Game((Mouse)P_0, P_1, P_2), 
				ControllerType.Custom => kTOdclpIebPuPOcvLBmyBSJyAHcAA(P_1, ((CustomController)P_0).sourceControllerId, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public ControllerMap_Editor GetJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				return null;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].categoryId == categoryId && joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return joystickMaps[i];
				}
			}
			return null;
		}

		public ControllerMap_Editor GetJoystickMapById(int id, out int joystickMapIndex)
		{
			joystickMapIndex = -1;
			if (joystickMaps == null)
			{
				return null;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].id == id)
				{
					joystickMapIndex = i;
					return joystickMaps[i];
				}
			}
			return null;
		}

		public List<ControllerMap_Editor> GetJoystickMaps(Guid hardwareGuid)
		{
			if (joystickMaps == null)
			{
				return null;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					list.Add(joystickMaps[i]);
				}
			}
			return list;
		}

		public int GetJoystickMapId(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].categoryId == categoryId && joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return joystickMaps[i].id;
				}
			}
			return -1;
		}

		public bool HasJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				return false;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].categoryId == categoryId && joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasJoystickMap(Guid hardwareGuid)
		{
			if (joystickMaps == null)
			{
				return false;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasJoystickMapInCategory(Guid hardwareGuid, int categoryId)
		{
			if (joystickMaps == null)
			{
				return false;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid && joystickMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		public bool CreateJoystickMap(int categoryId, Guid joystickOrTemplateGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				joystickMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewJoystickMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			controllerMap_Editor.hardwareGuidString = joystickOrTemplateGuid.ToString();
			joystickMaps.Add(controllerMap_Editor);
			return false;
		}

		public void DeleteJoystickMap(int id)
		{
			if (joystickMaps == null)
			{
				return;
			}
			for (int num = joystickMaps.Count - 1; num >= 0; num--)
			{
				if (joystickMaps[num].id == id)
				{
					joystickMaps.RemoveAt(num);
				}
			}
		}

		public int DuplicateJoystickMap(int index)
		{
			if (joystickMaps == null || index < 0 || index >= joystickMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = joystickMaps[index].Clone();
			controllerMap_Editor.id = GetNewJoystickMapId();
			joystickMaps.Add(controllerMap_Editor);
			return joystickMaps.Count - 1;
		}

		internal JoystickMap hHeEJnNucycDHDNXPcMfzPtZQcAlA(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return epTOeHhYDHIyuLCDEfzZaTvZjHVAb(P_0, P_1, P_2);
		}

		internal JoystickMap TMFORpelFDlBYkjQHYfeVwSIdqrR(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return epTOeHhYDHIyuLCDEfzZaTvZjHVAb(P_0.trkFeqtQSKtLWQOFenXapoJUVIFe, P_1, P_2);
		}

		private JoystickMap epTOeHhYDHIyuLCDEfzZaTvZjHVAb(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.QkBdsatCynGRQxrtNpstMBAHtFjP(guid);
			ControllerMap_Editor controllerMap_Editor = CnwvCfjaaLZHUcvTPiPfauZYOwnl(P_1, guid, P_2, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.xdWEnirdheAUGCXTOGxdcQEEJPVc(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.bxjzdgmVJtCUQslSmyUEfoUYexxU(guid, P_1, P_2);
				return joystickMap;
			}
			if (hardwareJoystickMap != null)
			{
				foreach (Guid templateGuid in hardwareJoystickMap.TemplateGuids)
				{
					if (templateGuid == Guid.Empty)
					{
						continue;
					}
					HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.YpzVZXqiKvBsMXgoepwiqXNIYxGb(templateGuid);
					if (!(hardwareJoystickTemplateMap != null))
					{
						continue;
					}
					controllerMap_Editor = CnwvCfjaaLZHUcvTPiPfauZYOwnl(P_1, templateGuid, P_2, false);
					if (controllerMap_Editor != null)
					{
						JoystickMap joystickMap = NUEizgpptDsjJxKbDQmqBeXqHqOB(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
						if (joystickMap != null)
						{
							joystickMap.bxjzdgmVJtCUQslSmyUEfoUYexxU(guid, P_1, P_2);
							return joystickMap;
						}
					}
				}
			}
			if (guid == Guid.Empty)
			{
				controllerMap_Editor = CnwvCfjaaLZHUcvTPiPfauZYOwnl(P_1, Guid.Empty, P_2, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = controllerMap_Editor.xdWEnirdheAUGCXTOGxdcQEEJPVc(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.bxjzdgmVJtCUQslSmyUEfoUYexxU(guid, P_1, P_2);
					if (joystickMap != null)
					{
						return joystickMap;
					}
				}
			}
			return JoystickMap.xUbaCbIBivOhfJHPSRGOnyonQDpiA(guid, P_1, P_2);
		}

		private ControllerMap_Editor CnwvCfjaaLZHUcvTPiPfauZYOwnl(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
			if (P_3)
			{
				joystickMap = fLgOzQkHZmKczUrMnJGdFXGCxACV(P_0, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor fLgOzQkHZmKczUrMnJGdFXGCxACV(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			if (list != null && list.Count > 0)
			{
				AgutcKzpYAwIRFobXcOiHLvYWBCKA(list, joystickLayouts);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].categoryId == P_0)
					{
						return list[i];
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].categoryId == 0)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		private JoystickMap NUEizgpptDsjJxKbDQmqBeXqHqOB(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			if (!P_2.QoQeivJdIsSQQHEpunlDubmpmHVfb(controllerMap_Editor, P_3, P_0.guid, out var text))
			{
				Logger.LogError("Error remapping joystick template " + P_2.Guid.ToString() + " to joystick " + P_0.guid.ToString() + "\nReason: " + text);
				return null;
			}
			return controllerMap_Editor.xdWEnirdheAUGCXTOGxdcQEEJPVc(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		private JoystickMap lNYEKgcIkTfBFfRCEaVrPoRFfKcPd(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.QkBdsatCynGRQxrtNpstMBAHtFjP(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.QkBdsatCynGRQxrtNpstMBAHtFjP(Guid.Empty);
			if (hardwareJoystickMap2 == null)
			{
				return null;
			}
			hardwareJoystickMap.GetElementIdentifiersForControllerElements(P_1, isDefaultMap: false, out var buttons, out var axes);
			if (buttons == null && axes == null)
			{
				return null;
			}
			bool flag = false;
			List<int> list = new List<int>();
			foreach (ActionElementMap allMap in P_0.AllMaps)
			{
				ControllerElementIdentifier elementIdentifier = hardwareJoystickMap2.GetElementIdentifier(allMap._elementIdentifierId);
				if (elementIdentifier != null)
				{
					string text = elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename;
					if (!string.IsNullOrEmpty(text))
					{
						int num = 0;
						int num2 = text.IndexOf("button", 0, StringComparison.OrdinalIgnoreCase);
						if (num2 < 0)
						{
							num2 = text.IndexOf("axis", 0, StringComparison.OrdinalIgnoreCase);
							num = 1;
						}
						if (num2 >= 0 && (num != 0 || buttons != null) && (num != 1 || axes != null))
						{
							string text2 = Regex.Replace(text, "[^0-9]+", "");
							Logger.Log(text2);
							if (int.TryParse(text2, out var result))
							{
								if (num == 0)
								{
									if (result < buttons.Length)
									{
										allMap._elementIdentifierId = buttons[result];
										goto IL_011f;
									}
								}
								else if (result < axes.Length)
								{
									allMap._elementIdentifierId = axes[result];
									goto IL_011f;
								}
							}
						}
					}
				}
				list.Add(allMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc);
				continue;
				IL_011f:
				flag = true;
			}
			for (int i = 0; i < list.Count; i++)
			{
				P_0.DeleteElementMap(list[i]);
			}
			if (!flag)
			{
				return null;
			}
			return P_0;
		}

		public ControllerMap_Editor GetKeyboardMap(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return null;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId)
				{
					return keyboardMaps[i];
				}
			}
			return null;
		}

		public int GetKeyboardMapId(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId)
				{
					return keyboardMaps[i].id;
				}
			}
			return -1;
		}

		public bool HasKeyboardMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return false;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId && StringTools.ToGuid(keyboardMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool CreateKeyboardMap(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				keyboardMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewKeyboardMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			keyboardMaps.Add(controllerMap_Editor);
			return false;
		}

		public void DeleteKeyboardMap(int id)
		{
			if (keyboardMaps == null)
			{
				return;
			}
			for (int num = keyboardMaps.Count - 1; num >= 0; num--)
			{
				if (keyboardMaps[num].id == id)
				{
					keyboardMaps.RemoveAt(num);
				}
			}
		}

		public int DuplicateKeyboardMap(int index)
		{
			if (keyboardMaps == null || index < 0 || index >= keyboardMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = keyboardMaps[index].Clone();
			controllerMap_Editor.id = GetNewKeyboardMapId();
			keyboardMaps.Add(controllerMap_Editor);
			return keyboardMaps.Count - 1;
		}

		public ControllerMap_Editor GetKeyboardMapById(int id, out int keyboardMapIndex)
		{
			keyboardMapIndex = -1;
			if (keyboardMaps == null)
			{
				return null;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].id == id)
				{
					keyboardMapIndex = i;
					return keyboardMaps[i];
				}
			}
			return null;
		}

		public KeyboardMap FindKeyboardMap_Game(Keyboard keyboard, int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = BjYbapjpypnYoVAkWCiRqOVbwBBS(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.iDMbWIadQzhnIVNiAEQYqNaUhfVhb(containsActionDelegate);
				keyboardMap.OfSNrfPwZrWqJqNgLkQcOBVNLgyb(keyboard.ZOYuKGMDLcxmBxqUbjaMwovvvKxG, categoryId, layoutId);
			}
			else
			{
				keyboardMap = KeyboardMap.jVEWWCHzhLiHJGXxrFWjdHOMwbmr(keyboard.ZOYuKGMDLcxmBxqUbjaMwovvvKxG, categoryId, layoutId);
			}
			return keyboardMap;
		}

		public bool HasKeyboardMapInCategory(int categoryId)
		{
			if (keyboardMaps == null)
			{
				return false;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasKeyboardMapInLayout(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return false;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId)
				{
					return true;
				}
			}
			return false;
		}

		public ControllerMap_Editor GetMouseMap(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return null;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId)
				{
					return mouseMaps[i];
				}
			}
			return null;
		}

		public int GetMouseMapId(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId)
				{
					return mouseMaps[i].id;
				}
			}
			return -1;
		}

		public bool HasMouseMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (mouseMaps == null)
			{
				return false;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId && StringTools.ToGuid(mouseMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool CreateMouseMap(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				mouseMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewMouseMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			mouseMaps.Add(controllerMap_Editor);
			return false;
		}

		public void DeleteMouseMap(int id)
		{
			if (mouseMaps == null)
			{
				return;
			}
			for (int num = mouseMaps.Count - 1; num >= 0; num--)
			{
				if (mouseMaps[num].id == id)
				{
					mouseMaps.RemoveAt(num);
				}
			}
		}

		public int DuplicateMouseMap(int index)
		{
			if (mouseMaps == null || index < 0 || index >= mouseMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = mouseMaps[index].Clone();
			controllerMap_Editor.id = GetNewMouseMapId();
			mouseMaps.Add(controllerMap_Editor);
			return mouseMaps.Count - 1;
		}

		public ControllerMap_Editor GetMouseMapById(int id, out int mouseMapIndex)
		{
			mouseMapIndex = -1;
			if (mouseMaps == null)
			{
				return null;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].id == id)
				{
					mouseMapIndex = i;
					return mouseMaps[i];
				}
			}
			return null;
		}

		public MouseMap FindMouseMap_Game(Mouse mouse, int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = BjYbapjpypnYoVAkWCiRqOVbwBBS(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.cYbPSLFvkvTdPbdflbNEwDbMURiO(containsActionDelegate);
				mouseMap.twYgisgyBycBbvCZlvQMcGCtyRS(mouse.ZOYuKGMDLcxmBxqUbjaMwovvvKxG, categoryId, layoutId);
			}
			else
			{
				mouseMap = MouseMap.vYSpCjXbylhiPqMqIhAsPjENAnFX(mouse.ZOYuKGMDLcxmBxqUbjaMwovvvKxG, categoryId, layoutId);
			}
			return mouseMap;
		}

		public bool HasMouseMapInCategory(int categoryId)
		{
			if (mouseMaps == null)
			{
				return false;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasMouseMapInLayout(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return false;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId)
				{
					return true;
				}
			}
			return false;
		}

		public ControllerMap_Editor GetCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				return null;
			}
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].categoryId == categoryId && customControllerMaps[i].layoutId == layoutId && customControllerMaps[i].customControllerUid == controllerUid)
				{
					return customControllerMaps[i];
				}
			}
			return null;
		}

		public ControllerMap_Editor GetCustomControllerMapById(int mapId, out int customControllerMapIndex)
		{
			customControllerMapIndex = -1;
			if (customControllerMaps == null)
			{
				return null;
			}
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].id == mapId)
				{
					customControllerMapIndex = i;
					return customControllerMaps[i];
				}
			}
			return null;
		}

		public List<ControllerMap_Editor> GetCustomControllerMaps(int controllerUid)
		{
			if (customControllerMaps == null)
			{
				return null;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].customControllerUid == controllerUid)
				{
					list.Add(customControllerMaps[i]);
				}
			}
			return list;
		}

		public int GetCustomControllerMapId(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].categoryId == categoryId && customControllerMaps[i].layoutId == layoutId && customControllerMaps[i].customControllerUid == controllerUid)
				{
					return customControllerMaps[i].id;
				}
			}
			return -1;
		}

		public bool HasCustomControllerMap(int mapId, int categoryId, int layoutId)
		{
			if (customControllerMaps == null)
			{
				return false;
			}
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].categoryId == categoryId && customControllerMaps[i].layoutId == layoutId && customControllerMaps[i].id == mapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasCustomControllerMap(int mapId)
		{
			if (customControllerMaps == null)
			{
				return false;
			}
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].id == mapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasCustomControllerMapInCategory(int controllerUid, int categoryId)
		{
			if (customControllerMaps == null)
			{
				return false;
			}
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].customControllerUid == controllerUid && customControllerMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		public bool CreateCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				customControllerMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewCustomControllerMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			controllerMap_Editor.hardwareGuidString = string.Empty;
			controllerMap_Editor.customControllerUid = controllerUid;
			customControllerMaps.Add(controllerMap_Editor);
			return false;
		}

		public void DeleteCustomControllerMap(int mapId)
		{
			if (customControllerMaps == null)
			{
				return;
			}
			for (int num = customControllerMaps.Count - 1; num >= 0; num--)
			{
				if (customControllerMaps[num].id == mapId)
				{
					customControllerMaps.RemoveAt(num);
				}
			}
		}

		public int DuplicateCustomControllerMap(int index)
		{
			if (customControllerMaps == null || index < 0 || index >= customControllerMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = customControllerMaps[index].Clone();
			controllerMap_Editor.id = GetNewCustomControllerMapId();
			customControllerMaps.Add(controllerMap_Editor);
			return customControllerMaps.Count - 1;
		}

		internal CustomControllerMap tbQBIHPgvhvSTFBGHEHOdHvdMnsC(Guid P_0, int P_1, int P_2)
		{
			return kOxZrShHecWJshdGVvAbEXNZgeCf(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap kTOdclpIebPuPOcvLBmyBSJyAHcAA(int P_0, int P_1, int P_2)
		{
			return kOxZrShHecWJshdGVvAbEXNZgeCf(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap kOxZrShHecWJshdGVvAbEXNZgeCf(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = ZOhWeKooGkQJdYlLVNUVLcaDOEMi(P_1, id, P_2, false);
			if (controllerMap_Editor != null)
			{
				CustomControllerMap customControllerMap = controllerMap_Editor.oscswFKsMHoeMLqJZYlBPjpJuGOL(ContainsAction, P_0);
				customControllerMap.zLwFUjAqAiMOJGAGoHoujpPiJqVLA(P_0.typeGuid, id, P_1, P_2);
				return customControllerMap;
			}
			CustomControllerMap customControllerMap2 = CustomControllerMap.yYPdeDaWFrpDakaAECckYYKAjEwp(P_0.typeGuid, id, P_1, P_2);
			customControllerMap2.zLwFUjAqAiMOJGAGoHoujpPiJqVLA(P_0.typeGuid, id, P_1, P_2);
			return customControllerMap2;
		}

		private ControllerMap_Editor ZOhWeKooGkQJdYlLVNUVLcaDOEMi(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = rjGreSFbBwchiaPiXPdQYItQXBGdA(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor rjGreSFbBwchiaPiXPdQYItQXBGdA(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				AgutcKzpYAwIRFobXcOiHLvYWBCKA(list, customControllerLayouts);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].categoryId == P_0)
					{
						return list[i];
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].categoryId == 0)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		public void DeleteControllerMap(ControllerType controllerType, int id)
		{
			switch (controllerType)
			{
			case ControllerType.Joystick:
				DeleteJoystickMap(id);
				break;
			case ControllerType.Keyboard:
				DeleteKeyboardMap(id);
				break;
			case ControllerType.Mouse:
				DeleteMouseMap(id);
				break;
			case ControllerType.Custom:
				DeleteCustomControllerMap(id);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public ControllerMap_Editor GetControllerMapByIndex(ControllerType controllerType, int index)
		{
			switch (controllerType)
			{
			case ControllerType.Joystick:
				if (joystickMaps == null)
				{
					return null;
				}
				return joystickMaps[index];
			case ControllerType.Keyboard:
				if (keyboardMaps == null)
				{
					return null;
				}
				return keyboardMaps[index];
			case ControllerType.Mouse:
				if (mouseMaps == null)
				{
					return null;
				}
				return mouseMaps[index];
			case ControllerType.Custom:
				if (customControllerMaps == null)
				{
					return null;
				}
				return customControllerMaps[index];
			default:
				throw new NotImplementedException();
			}
		}

		public ControllerMap_Editor GetControllerMapById(ControllerType controllerType, int id, out int controllerMapIndex)
		{
			return controllerType switch
			{
				ControllerType.Joystick => GetJoystickMapById(id, out controllerMapIndex), 
				ControllerType.Keyboard => GetKeyboardMapById(id, out controllerMapIndex), 
				ControllerType.Mouse => GetMouseMapById(id, out controllerMapIndex), 
				ControllerType.Custom => GetCustomControllerMapById(id, out controllerMapIndex), 
				_ => throw new NotImplementedException(), 
			};
		}

		public int DuplicateControllerMap(ControllerType controllerType, int index)
		{
			return controllerType switch
			{
				ControllerType.Joystick => DuplicateJoystickMap(index), 
				ControllerType.Keyboard => DuplicateKeyboardMap(index), 
				ControllerType.Mouse => DuplicateMouseMap(index), 
				ControllerType.Custom => DuplicateCustomControllerMap(index), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal ControllerTemplateMap zovzSzSMHKbKfrDUdqiTHmiHgMUgA(Guid P_0, int P_1, int P_2)
		{
			return GetJoystickMap(P_1, P_0, P_2)?.vFUBrAMVSDzcIddkXaBKTGVkqPaq();
		}

		[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
		public void AddCustomController()
		{
			AddCustomController(Guid.NewGuid());
		}

		public void AddCustomController(Guid typeGuid)
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
			}
			customControllers.Add(YKQmoFLOlpEorIYNAeVejMUXQciy(typeGuid));
		}

		[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
		public void InsertCustomController(int index)
		{
			InsertCustomController(index, Guid.NewGuid());
		}

		public void InsertCustomController(int index, Guid typeGuid)
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
			}
			if (index < 0 || index >= customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllers.Insert(index, YKQmoFLOlpEorIYNAeVejMUXQciy(typeGuid));
		}

		public void DeleteCustomController(int index)
		{
			if (customControllers == null || index < 0 || index >= customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = customControllers[index].id;
			if (customControllerMaps != null)
			{
				for (int num = customControllerMaps.Count - 1; num >= 0; num--)
				{
					if (customControllerMaps[num].customControllerUid == id)
					{
						customControllerMaps.RemoveAt(num);
					}
				}
			}
			customControllers.RemoveAt(index);
		}

		public bool ReorderCustomController(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(customControllers, index, offsetDown, offsetNow);
		}

		[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
		public void DuplicateCustomController(int index, bool duplicateMaps)
		{
			DuplicateCustomController(index, duplicateMaps, Guid.NewGuid());
		}

		public void DuplicateCustomController(int index, bool duplicateMaps, Guid typeGuid)
		{
			if (customControllers == null || index < 0 || index >= customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			CustomController_Editor customController_Editor = customControllers[index].Clone();
			customController_Editor.id = GetNewCustomControllerId();
			customController_Editor.typeGuid = typeGuid;
			customController_Editor.name = StringTools.IterateName(customController_Editor.name, -1, GetCustomControllerNames());
			if (index == customControllers.Count - 1)
			{
				customControllers.Add(customController_Editor);
			}
			else
			{
				customControllers.Insert(index + 1, customController_Editor);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = customController_Editor.id;
			int id2 = customControllers[index].id;
			if (customControllerMaps == null)
			{
				return;
			}
			for (int num = customControllerMaps.Count - 1; num >= 0; num--)
			{
				if (customControllerMaps[num].customControllerUid == id2)
				{
					int num2 = DuplicateCustomControllerMap(num);
					if (num2 >= 0)
					{
						customControllerMaps[num2].customControllerUid = id;
					}
				}
			}
		}

		public int GetCustomControllerMapCount(int controllerUid)
		{
			if (customControllers == null)
			{
				return 0;
			}
			int num = 0;
			if (customControllerMaps != null)
			{
				for (int i = 0; i < customControllerMaps.Count; i++)
				{
					if (customControllerMaps[i].customControllerUid == controllerUid)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetCustomControllerIndex(int id)
		{
			if (customControllers == null)
			{
				return 0;
			}
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetCustomControllerNames()
		{
			if (customControllers == null)
			{
				return null;
			}
			string[] array = new string[customControllers.Count];
			for (int i = 0; i < customControllers.Count; i++)
			{
				array[i] = customControllers[i].name;
			}
			return array;
		}

		public int[] GetCustomControllerIds()
		{
			if (customControllers == null)
			{
				return null;
			}
			int[] array = new int[customControllers.Count];
			for (int i = 0; i < customControllers.Count; i++)
			{
				array[i] = customControllers[i].id;
			}
			return array;
		}

		public Guid[] GetCustomControllerGuids()
		{
			if (customControllers == null)
			{
				return null;
			}
			Guid[] array = new Guid[customControllers.Count];
			for (int i = 0; i < customControllers.Count; i++)
			{
				array[i] = customControllers[i].typeGuid;
			}
			return array;
		}

		public CustomController_Editor GetCustomController(int index)
		{
			if (customControllers == null || index < 0 || index >= customControllers.Count)
			{
				return null;
			}
			return customControllers[index];
		}

		public CustomController_Editor GetCustomController(string name)
		{
			if (customControllers == null)
			{
				return null;
			}
			int num = IndexOfCustomController(name);
			if (num < 0)
			{
				return null;
			}
			return customControllers[num];
		}

		public CustomController_Editor GetCustomControllerById(int id)
		{
			if (customControllers == null)
			{
				return null;
			}
			int num = IndexOfCustomController(id);
			if (num < 0)
			{
				return null;
			}
			return customControllers[num];
		}

		public CustomController_Editor GetCustomControllerByHardwareTypeGuid(Guid hardwareTypeGuid)
		{
			if (customControllers == null)
			{
				return null;
			}
			int num = IndexOfCustomController(hardwareTypeGuid);
			if (num < 0)
			{
				return null;
			}
			return customControllers[num];
		}

		public int GetCustomControllerId(string name)
		{
			if (customControllers == null)
			{
				return -1;
			}
			int num = IndexOfCustomController(name);
			if (num < 0)
			{
				return -1;
			}
			return customControllers[num].id;
		}

		public int IndexOfCustomController(int id)
		{
			if (customControllers == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfCustomController(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (customControllers == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfCustomController(Guid hardwareTypeGuid)
		{
			if (customControllers == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].typeGuid == hardwareTypeGuid)
				{
					return i;
				}
			}
			return -1;
		}

		public string GetCustomControllerNameById(int id)
		{
			if (customControllers != null)
			{
				for (int i = 0; i < customControllers.Count; i++)
				{
					if (customControllers[i].id == id)
					{
						return customControllers[i].name;
					}
				}
			}
			return "Unknown";
		}

		public void AddControllerMapLayoutManagerRuleSet()
		{
			controllerMapLayoutManagerRuleSets.Add(zYcfQiGHpdOoDQuezMrzKeouPIRL());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapLayoutManagerRuleSets.Insert(index, zYcfQiGHpdOoDQuezMrzKeouPIRL());
		}

		public void DeleteControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets == null || index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = controllerMapLayoutManagerRuleSets[index].id;
			if (players != null)
			{
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor == null)
					{
						continue;
					}
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					if (ruleSets == null)
					{
						continue;
					}
					for (int num = ruleSets.Count - 1; num >= 0; num--)
					{
						if (ruleSets[num] != null && ruleSets[num].id == id)
						{
							ruleSets.RemoveAt(num);
						}
					}
				}
			}
			controllerMapLayoutManagerRuleSets.RemoveAt(index);
		}

		public bool ReorderControllerMapLayoutManagerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(controllerMapLayoutManagerRuleSets, index, offsetDown, offsetNow);
		}

		public void DuplicateControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets == null || index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = controllerMapLayoutManagerRuleSets[index].Clone();
			controllerMapLayoutManager_RuleSet_Editor.id = GetNewControllerMapLayoutManagerRuleSetId();
			controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName(controllerMapLayoutManager_RuleSet_Editor.name, -1, GetControllerMapLayoutManagerRuleSetNames());
			if (index == controllerMapLayoutManagerRuleSets.Count - 1)
			{
				controllerMapLayoutManagerRuleSets.Add(controllerMapLayoutManager_RuleSet_Editor);
			}
			else
			{
				controllerMapLayoutManagerRuleSets.Insert(index + 1, controllerMapLayoutManager_RuleSet_Editor);
			}
		}

		public int GetControllerMapLayoutManagerRuleSetUsedCount(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			if (players != null)
			{
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor == null)
					{
						continue;
					}
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					if (ruleSets == null)
					{
						continue;
					}
					for (int num2 = ruleSets.Count - 1; num2 >= 0; num2--)
					{
						if (ruleSets[num2] != null && ruleSets[num2].id == id)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		public int GetControllerMapLayoutManagerRuleSetIndex(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (controllerMapLayoutManagerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetControllerMapLayoutManagerRuleSetNames()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			string[] array = new string[controllerMapLayoutManagerRuleSets.Count];
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				array[i] = controllerMapLayoutManagerRuleSets[i].name;
			}
			return array;
		}

		public int[] GetControllerMapLayoutManagerRuleSetIds()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int[] array = new int[controllerMapLayoutManagerRuleSets.Count];
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				array[i] = controllerMapLayoutManagerRuleSets[i].id;
			}
			return array;
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets == null || index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				return null;
			}
			return controllerMapLayoutManagerRuleSets[index];
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(string name)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapLayoutManagerRuleSet(name);
			if (num < 0)
			{
				return null;
			}
			return controllerMapLayoutManagerRuleSets[num];
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSetById(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapLayoutManagerRuleSet(id);
			if (num < 0)
			{
				return null;
			}
			return controllerMapLayoutManagerRuleSets[num];
		}

		public int GetControllerMapLayoutManagerRuleSetId(string name)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return -1;
			}
			int num = IndexOfControllerMapLayoutManagerRuleSet(name);
			if (num < 0)
			{
				return -1;
			}
			return controllerMapLayoutManagerRuleSets[num].id;
		}

		public int IndexOfControllerMapLayoutManagerRuleSet(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (controllerMapLayoutManagerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfControllerMapLayoutManagerRuleSet(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (controllerMapLayoutManagerRuleSets[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetControllerMapLayoutManagerRuleSetNameById(int id)
		{
			if (controllerMapLayoutManagerRuleSets != null)
			{
				for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
				{
					if (controllerMapLayoutManagerRuleSets[i].id == id)
					{
						return controllerMapLayoutManagerRuleSets[i].name;
					}
				}
			}
			return "Unknown";
		}

		public int GetControllerMapLayoutManagerRuleSetCount()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			return controllerMapLayoutManagerRuleSets.Count;
		}

		public void AddControllerMapEnablerRuleSet()
		{
			controllerMapEnablerRuleSets.Add(afQMJgFxxZUWuvaOJdPbApVcHwTI());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapEnablerRuleSets.Insert(index, afQMJgFxxZUWuvaOJdPbApVcHwTI());
		}

		public void DeleteControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = controllerMapEnablerRuleSets[index].id;
			if (players != null)
			{
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor == null)
					{
						continue;
					}
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
					if (ruleSets == null)
					{
						continue;
					}
					for (int num = ruleSets.Count - 1; num >= 0; num--)
					{
						if (ruleSets[num] != null && ruleSets[num].id == id)
						{
							ruleSets.RemoveAt(num);
						}
					}
				}
			}
			controllerMapEnablerRuleSets.RemoveAt(index);
		}

		public bool ReorderControllerMapEnablerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(controllerMapEnablerRuleSets, index, offsetDown, offsetNow);
		}

		public void DuplicateControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = controllerMapEnablerRuleSets[index].Clone();
			controllerMapEnabler_RuleSet_Editor.id = GetNewControllerMapEnablerRuleSetId();
			controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName(controllerMapEnabler_RuleSet_Editor.name, -1, GetControllerMapEnablerRuleSetNames());
			if (index == controllerMapEnablerRuleSets.Count - 1)
			{
				controllerMapEnablerRuleSets.Add(controllerMapEnabler_RuleSet_Editor);
			}
			else
			{
				controllerMapEnablerRuleSets.Insert(index + 1, controllerMapEnabler_RuleSet_Editor);
			}
		}

		public int GetControllerMapEnablerRuleSetUsedCount(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			if (players != null)
			{
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor == null)
					{
						continue;
					}
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
					if (ruleSets == null)
					{
						continue;
					}
					for (int num2 = ruleSets.Count - 1; num2 >= 0; num2--)
					{
						if (ruleSets[num2] != null && ruleSets[num2].id == id)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		public int GetControllerMapEnablerRuleSetIndex(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				if (controllerMapEnablerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetControllerMapEnablerRuleSetNames()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			string[] array = new string[controllerMapEnablerRuleSets.Count];
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				array[i] = controllerMapEnablerRuleSets[i].name;
			}
			return array;
		}

		public int[] GetControllerMapEnablerRuleSetIds()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			int[] array = new int[controllerMapEnablerRuleSets.Count];
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				array[i] = controllerMapEnablerRuleSets[i].id;
			}
			return array;
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				return null;
			}
			return controllerMapEnablerRuleSets[index];
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(string name)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapEnablerRuleSet(name);
			if (num < 0)
			{
				return null;
			}
			return controllerMapEnablerRuleSets[num];
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSetById(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapEnablerRuleSet(id);
			if (num < 0)
			{
				return null;
			}
			return controllerMapEnablerRuleSets[num];
		}

		public int GetControllerMapEnablerRuleSetId(string name)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return -1;
			}
			int num = IndexOfControllerMapEnablerRuleSet(name);
			if (num < 0)
			{
				return -1;
			}
			return controllerMapEnablerRuleSets[num].id;
		}

		public int IndexOfControllerMapEnablerRuleSet(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				if (controllerMapEnablerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfControllerMapEnablerRuleSet(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (controllerMapEnablerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				if (controllerMapEnablerRuleSets[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetControllerMapEnablerRuleSetNameById(int id)
		{
			if (controllerMapEnablerRuleSets != null)
			{
				for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
				{
					if (controllerMapEnablerRuleSets[i].id == id)
					{
						return controllerMapEnablerRuleSets[i].name;
					}
				}
			}
			return "Unknown";
		}

		public int GetControllerMapEnablerRuleSetCount()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			return controllerMapEnablerRuleSets.Count;
		}

		public int GetNewPlayerId()
		{
			int result = playerIdCounter;
			playerIdCounter++;
			return result;
		}

		public int GetNewActionId()
		{
			int result = actionIdCounter;
			actionIdCounter++;
			return result;
		}

		public int GetNewActionCategoryId()
		{
			int result = actionCategoryIdCounter;
			actionCategoryIdCounter++;
			return result;
		}

		public int GetNewInputBehaviorId()
		{
			int result = inputBehaviorIdCounter;
			inputBehaviorIdCounter++;
			return result;
		}

		public int GetNewMapCategoryId()
		{
			int result = mapCategoryIdCounter;
			mapCategoryIdCounter++;
			return result;
		}

		public int GetNewJoystickLayoutId()
		{
			int result = joystickLayoutIdCounter;
			joystickLayoutIdCounter++;
			return result;
		}

		public int GetNewKeyboardLayoutId()
		{
			int result = keyboardLayoutIdCounter;
			keyboardLayoutIdCounter++;
			return result;
		}

		public int GetNewMouseLayoutId()
		{
			int result = mouseLayoutIdCounter;
			mouseLayoutIdCounter++;
			return result;
		}

		public int GetNewCustomControllerLayoutId()
		{
			int result = customControllerLayoutIdCounter;
			customControllerLayoutIdCounter++;
			return result;
		}

		public int GetNewJoystickMapId()
		{
			int result = joystickMapIdCounter;
			joystickMapIdCounter++;
			return result;
		}

		public int GetNewKeyboardMapId()
		{
			int result = keyboardMapIdCounter;
			keyboardMapIdCounter++;
			return result;
		}

		public int GetNewMouseMapId()
		{
			int result = mouseMapIdCounter;
			mouseMapIdCounter++;
			return result;
		}

		public int GetNewCustomControllerMapId()
		{
			int result = customControllerMapIdCounter;
			customControllerMapIdCounter++;
			return result;
		}

		public int GetNewCustomControllerId()
		{
			int result = customControllerIdCounter;
			customControllerIdCounter++;
			return result;
		}

		public int GetNewControllerMapLayoutManagerRuleSetId()
		{
			int result = controllerMapLayoutManagerSetIdCounter;
			controllerMapLayoutManagerSetIdCounter++;
			return result;
		}

		public int GetNewControllerMapEnablerRuleSetId()
		{
			int result = controllerMapEnablerSetIdCounter;
			controllerMapEnablerSetIdCounter++;
			return result;
		}

		private Player_Editor KfttDDqTOyZUSGOgXjBltZfjymVH()
		{
			Player_Editor player_Editor = new Player_Editor();
			player_Editor.id = GetNewPlayerId();
			player_Editor.name = StringTools.IterateName("Player", -1, GetPlayerNames());
			player_Editor.descriptiveName = player_Editor.name;
			player_Editor.startPlaying = true;
			if (players.Count == 1)
			{
				player_Editor.assignMouseOnStart = true;
			}
			player_Editor.assignKeyboardOnStart = true;
			player_Editor.controllerMapEnablerSettings = new Player_Editor.ControllerMapEnablerSettings();
			player_Editor.controllerMapLayoutManagerSettings = new Player_Editor.ControllerMapLayoutManagerSettings();
			return player_Editor;
		}

		private InputAction lnKuEhozdWIXtrmaOtKLXmZldmbK()
		{
			InputAction obj = new InputAction
			{
				id = GetNewActionId(),
				name = StringTools.IterateName("Action", -1, GetActionNames())
			};
			obj.descriptiveName = obj.name;
			obj.type = InputActionType.Button;
			obj.userAssignable = true;
			obj.behaviorId = 0;
			return obj;
		}

		private InputActionCategory qFkqDgmDKCzHJYpiaoycizhBrbIk()
		{
			InputActionCategory obj = new InputActionCategory
			{
				id = GetNewActionCategoryId(),
				name = StringTools.IterateName("Category", -1, GetActionCategoryNames())
			};
			obj.descriptiveName = obj.name;
			obj.userAssignable = true;
			return obj;
		}

		private InputBehavior XvwNxTkAVgweplswpUiIszOHpsP()
		{
			return new InputBehavior
			{
				id = GetNewInputBehaviorId(),
				name = StringTools.IterateName("Behavior", -1, GetInputBehaviorNames()),
				digitalAxisSimulation = false,
				digitalAxisSnap = true,
				digitalAxisInstantReverse = false,
				digitalAxisGravity = 3f,
				digitalAxisSensitivity = 3f,
				mouseXYAxisMode = MouseXYAxisMode.MouseAxis,
				mouseXYAxisSensitivity = 1f,
				mouseOtherAxisMode = MouseOtherAxisMode.MouseAxis,
				mouseOtherAxisSensitivity = 1f,
				buttonDoublePressSpeed = 0.3f,
				buttonShortPressTime = 0.25f,
				buttonShortPressExpiresIn = 0f,
				buttonLongPressTime = 1f,
				buttonLongPressExpiresIn = 0f,
				buttonDeadZone = 0.5f,
				buttonDownBuffer = 0f
			};
		}

		private InputMapCategory WonvcyyEZvPtpOOqTfffCAMCEIflA()
		{
			InputMapCategory obj = new InputMapCategory
			{
				id = GetNewMapCategoryId(),
				name = StringTools.IterateName("Category", -1, GetMapCategoryNames())
			};
			obj.descriptiveName = obj.name;
			obj.userAssignable = true;
			obj.checkConflictsWithAllCategories = true;
			return obj;
		}

		private InputLayout qoAAQsBOyZSBWAUUdenRucjjQvUI()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewJoystickLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout vPWWMZPrYODRyDgOmFtDYaKeuqvD()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewKeyboardLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout DClLeISLfIMsZONjBCvWGAvhqujB()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewMouseLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout BeRZuPzUSLvOyuKVXhMkKrBXVaDl()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewCustomControllerLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private CustomController_Editor YKQmoFLOlpEorIYNAeVejMUXQciy(Guid P_0)
		{
			CustomController_Editor obj = new CustomController_Editor
			{
				id = GetNewCustomControllerId(),
				typeGuid = P_0,
				name = StringTools.IterateName("CustomController", -1, GetCustomControllerNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private ControllerMapLayoutManager_RuleSet_Editor zYcfQiGHpdOoDQuezMrzKeouPIRL()
		{
			return new ControllerMapLayoutManager_RuleSet_Editor
			{
				id = GetNewControllerMapLayoutManagerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames())
			};
		}

		private ControllerMapEnabler_RuleSet_Editor afQMJgFxxZUWuvaOJdPbApVcHwTI()
		{
			return new ControllerMapEnabler_RuleSet_Editor
			{
				id = GetNewControllerMapEnablerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames())
			};
		}

		private ControllerMap_Editor ITmxzJUknqLOhketdIMQbeqfQVuq(List<ControllerMap_Editor> P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].categoryId == P_1 && P_0[i].layoutId == P_2)
				{
					return P_0[i];
				}
			}
			return null;
		}

		private ControllerMap_Editor BjYbapjpypnYoVAkWCiRqOVbwBBS(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = ITmxzJUknqLOhketdIMQbeqfQVuq(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = aIcHbwWfWzdUXkUzMXTrFGOqlLdI(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor aIcHbwWfWzdUXkUzMXTrFGOqlLdI(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null && list.Count > 0)
			{
				AgutcKzpYAwIRFobXcOiHLvYWBCKA(list, P_1);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].categoryId == P_2)
					{
						return list[i];
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].categoryId == 0)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		private void AgutcKzpYAwIRFobXcOiHLvYWBCKA(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			qgCczfcpIYlyjTEwwnfjUGbgcqqi qgCczfcpIYlyjTEwwnfjUGbgcqqi2 = new qgCczfcpIYlyjTEwwnfjUGbgcqqi();
			qgCczfcpIYlyjTEwwnfjUGbgcqqi2.rqdXceoTCWrkdvvCDjRLCZKZMWlv = P_1;
			if (P_0 != null && qgCczfcpIYlyjTEwwnfjUGbgcqqi2.rqdXceoTCWrkdvvCDjRLCZKZMWlv != null)
			{
				P_0.Sort(qgCczfcpIYlyjTEwwnfjUGbgcqqi2.dFAdVkAfqRkhvxwbYbalbrBfecjCA);
			}
		}

		internal void MOejVWshIoocysdUmWMQAUxOgKHH()
		{
			if (MAOQfwotRlxeTlyjOrxROWhoPHqN)
			{
				return;
			}
			OLwcduRTTyRMeswkSeDckvmFIKzr = new List<InputAction>(actions.Count);
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i] == null)
				{
					OLwcduRTTyRMeswkSeDckvmFIKzr.Add(null);
				}
				OLwcduRTTyRMeswkSeDckvmFIKzr.Add(new InputAction(actions[i]));
			}
			vdPnOLKbJBrenRKPKDLPhLsjfLpuA = new ReadOnlyCollection<Player_Editor>(players);
			qLmGgelEtCFIrcKQogHVHNKgxRHbb = new ReadOnlyCollection<InputAction>(OLwcduRTTyRMeswkSeDckvmFIKzr);
			List<InputCategory> list = new List<InputCategory>((actionCategories != null) ? actionCategories.Count : 0);
			for (int j = 0; j < actionCategories.Count; j++)
			{
				list.Add(actionCategories[j]);
			}
			ebzZGJKfJpNnscyRdhoBrwNEjaYL = new ReadOnlyCollection<InputCategory>(list);
			nzDQYgGGbqRtIGyQvGGLWGneidUl = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
			FipgqCjMcjkrijvORJhmaWVzOZIgA = new ReadOnlyCollection<InputMapCategory>(mapCategories);
			LIJrEcSiTrDdQDDpsrujKIBwYXsgA = new ReadOnlyCollection<InputLayout>(joystickLayouts);
			rGaQuyGlgbwHmSYClPgheHLQLOTj = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
			iNexhKoDOWOSnTaVoYisPmtBBadgA = new ReadOnlyCollection<InputLayout>(mouseLayouts);
			hMnwghkSDlwrrbGKxMUJewpksrtW = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
			iZGtgBfOZuUkqQqnHesOdySruPlhA = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
			MaBnHxvkNraKgaYflNYPoCdMfgnIA = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
			xStBDbeetOwShCFLpfectRvBvzzNA = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
			dhPsUrwObpzEafbxDAriwyUlNur = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
			PlTGRdFlQtpIWqoZoeURGwdGYPijB = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
			yXIpFSmRGXrLjiDGmiUQefIyVlnk = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
			if (mapCategories != null)
			{
				for (int k = 0; k < mapCategories.Count; k++)
				{
					if (mapCategories[k] != null)
					{
						mapCategories[k].eoLqHcEdrpynynhBRrrdzJywRkKc();
					}
				}
			}
			if (actionCategories != null)
			{
				for (int l = 0; l < actionCategories.Count; l++)
				{
					if (actionCategories[l] != null)
					{
						actionCategories[l].eoLqHcEdrpynynhBRrrdzJywRkKc();
					}
				}
			}
			if (joystickLayouts != null)
			{
				for (int m = 0; m < joystickLayouts.Count; m++)
				{
					if (joystickLayouts[m] != null)
					{
						joystickLayouts[m].YxzGpBkUyIHoZFMeHWxDUOFArcfac();
					}
				}
			}
			if (keyboardLayouts != null)
			{
				for (int n = 0; n < keyboardLayouts.Count; n++)
				{
					if (keyboardLayouts[n] != null)
					{
						keyboardLayouts[n].YxzGpBkUyIHoZFMeHWxDUOFArcfac();
					}
				}
			}
			if (mouseLayouts != null)
			{
				for (int num = 0; num < mouseLayouts.Count; num++)
				{
					if (mouseLayouts[num] != null)
					{
						mouseLayouts[num].YxzGpBkUyIHoZFMeHWxDUOFArcfac();
					}
				}
			}
			if (customControllerLayouts != null)
			{
				for (int num2 = 0; num2 < customControllerLayouts.Count; num2++)
				{
					if (customControllerLayouts[num2] != null)
					{
						customControllerLayouts[num2].YxzGpBkUyIHoZFMeHWxDUOFArcfac();
					}
				}
			}
			if (OLwcduRTTyRMeswkSeDckvmFIKzr != null)
			{
				for (int num3 = 0; num3 < OLwcduRTTyRMeswkSeDckvmFIKzr.Count; num3++)
				{
					if (OLwcduRTTyRMeswkSeDckvmFIKzr[num3] != null)
					{
						OLwcduRTTyRMeswkSeDckvmFIKzr[num3].gfqCcGFaAfhdLvBVmDOatxfcZLpN();
					}
				}
			}
			containsActionDelegate = ContainsAction;
			MAOQfwotRlxeTlyjOrxROWhoPHqN = true;
		}

		internal void pyvHPwLnFHfhhhwUFaEhejWamAyac()
		{
			if (!MAOQfwotRlxeTlyjOrxROWhoPHqN)
			{
				return;
			}
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					if (mapCategories[i] != null)
					{
						mapCategories[i].OquTyXhrmRwkjrBkpYqnzOGVgjVd();
					}
				}
			}
			if (OLwcduRTTyRMeswkSeDckvmFIKzr != null)
			{
				for (int j = 0; j < OLwcduRTTyRMeswkSeDckvmFIKzr.Count; j++)
				{
					if (OLwcduRTTyRMeswkSeDckvmFIKzr[j] != null)
					{
						OLwcduRTTyRMeswkSeDckvmFIKzr[j].BUYsjprDzPbdOufUlKOYpCwprWoC();
					}
				}
			}
			MAOQfwotRlxeTlyjOrxROWhoPHqN = false;
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return zdTZDxDBONHdkKlunuIKoLayrsRx.bxNYzESqrxQDlhZUtRAXJBrCAYmdA(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return zdTZDxDBONHdkKlunuIKoLayrsRx.bxNYzESqrxQDlhZUtRAXJBrCAYmdA(orig, null, false);
		}
	}
}
