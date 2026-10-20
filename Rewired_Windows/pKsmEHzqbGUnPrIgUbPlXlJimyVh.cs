using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Libraries.SharpDX.RawInput;
using Rewired.Libraries.SharpDX.Windows.Forms;
using Rewired.Platforms.Windows.RawInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class pKsmEHzqbGUnPrIgUbPlXlJimyVh : IUnifiedKeyboardSource, IGetSetEnabled, IDisposable
{
	[CustomObfuscation(rename = false)]
	private enum KeyEventType
	{
		Real = 0,
		Fake = 1,
		FakeVKeyOnly = 2
	}

	private class WmbCRDqATJqILkefpgtxDdlFOsuM
	{
		private enum xRFdtWeFSePcPEiPbTkvlhMpVjjV
		{
			None = 0,
			Down = 1,
			Up = 2
		}

		private const int QxpOvQCfKEUUNVczwAgZgjbXUrYZ = 2;

		private static readonly KeyboardKeyCode[] kPqmnzPNyOjJpyaYPgJKkckpHmsaA = new KeyboardKeyCode[2];

		private readonly UpdateLoopType kcBddZHGngovlAuImxEJNaOCMkOYA;

		private bool[] irzeYaDcBuyHtwapfdqlqDtTNHHh;

		private bool[] rpMxgzaelpvKbEkcxiKIHqTAOSffb;

		private uint xBncZcnNCBDDqCRCbRJojCBwPftib;

		public WmbCRDqATJqILkefpgtxDdlFOsuM(UpdateLoopType P_0)
		{
			kcBddZHGngovlAuImxEJNaOCMkOYA = P_0;
			irzeYaDcBuyHtwapfdqlqDtTNHHh = new bool[132];
			rpMxgzaelpvKbEkcxiKIHqTAOSffb = new bool[132];
		}

		public void fkoEVHctgzQaDfvlBlRHPblWMsrn(bool P_0, Keys P_1, int P_2, ScanCodeFlags P_3, KeyState P_4, KeyboardLayout P_5)
		{
			int num = ((!P_0) ? MKccxkYhcEoGZnfVhEXmomexOJtS(P_1, P_3, kPqmnzPNyOjJpyaYPgJKkckpHmsaA, P_5) : vWZsmJWaCWErxdCVMdRzyrlgGLAQA(P_2, P_3, kPqmnzPNyOjJpyaYPgJKkckpHmsaA, P_5));
			for (int i = 0; i < num; i++)
			{
				int num2 = (int)kPqmnzPNyOjJpyaYPgJKkckpHmsaA[i];
				if (num2 >= 0 && num2 < KcgCWZDbKGIZxfoGETyTBunfAUKfA.Length)
				{
					bool flag = ((P_4 == KeyState.KeyFirst || P_4 == KeyState.SystemKeyDown) ? true : false);
					int num3 = KcgCWZDbKGIZxfoGETyTBunfAUKfA[num2];
					bool num4 = irzeYaDcBuyHtwapfdqlqDtTNHHh[num3];
					irzeYaDcBuyHtwapfdqlqDtTNHHh[num3] = flag;
					if (!num4 && flag)
					{
						rpMxgzaelpvKbEkcxiKIHqTAOSffb[num3] = true;
					}
				}
			}
		}

		public void MwkpCtAuVLNthLGvAncPPhUtDDNJA(ControllerDataUpdater P_0)
		{
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 132; i++)
			{
				buttonValues[i] = irzeYaDcBuyHtwapfdqlqDtTNHHh[i] || rpMxgzaelpvKbEkcxiKIHqTAOSffb[i];
			}
			CCXAAMGhhqfRyhMZQKXhDLDaiBdic();
		}

		public void VSspQoHMSNBsYdrpUslgTougHoNQA()
		{
			CCXAAMGhhqfRyhMZQKXhDLDaiBdic();
		}

		private void CCXAAMGhhqfRyhMZQKXhDLDaiBdic()
		{
			if (xBncZcnNCBDDqCRCbRJojCBwPftib != ReInput.absFrame)
			{
				kkXoQOXoMkQUaZpCFbjVYNNWbxABA();
				xBncZcnNCBDDqCRCbRJojCBwPftib = ReInput.absFrame;
			}
		}

		public void kkXoQOXoMkQUaZpCFbjVYNNWbxABA()
		{
			Array.Clear(rpMxgzaelpvKbEkcxiKIHqTAOSffb, 0, 132);
		}

		public void tmlPrYnYgHDDXfgiDZADfXqxgoEI()
		{
			Array.Clear(irzeYaDcBuyHtwapfdqlqDtTNHHh, 0, 132);
			Array.Clear(rpMxgzaelpvKbEkcxiKIHqTAOSffb, 0, 132);
		}
	}

	[DefaultMember("Item")]
	private abstract class zygiggvvAqrjDLpoajmjYJDuCRos
	{
		public abstract int PXPWvCbCOCHTqtibNAGzqgScAlVP { get; }

		public abstract MutpnMKLQSoCxYVEIbAoEZbVPMPP bBSBxCTpxyChKGPplSQyhMwyqFRFA { get; }
	}

	[DefaultMember("Item")]
	private class MutpnMKLQSoCxYVEIbAoEZbVPMPP : zygiggvvAqrjDLpoajmjYJDuCRos
	{
		public readonly int IBCRebEcAYeDwHxlzbXDOuAgUKcD;

		public readonly int MiaiILsHODRzujanRDSfjEUWZswhA;

		public readonly ScanCodeFlags BcFWYlJUSrPAKLQmsoouwzMqVqSh;

		public readonly int swwSAmQUYPxEMqqwcbQkGGcoFpZg;

		int zygiggvvAqrjDLpoajmjYJDuCRos.PXPWvCbCOCHTqtibNAGzqgScAlVP => 1;

		MutpnMKLQSoCxYVEIbAoEZbVPMPP zygiggvvAqrjDLpoajmjYJDuCRos.bBSBxCTpxyChKGPplSQyhMwyqFRFA => this;

		public MutpnMKLQSoCxYVEIbAoEZbVPMPP(int P_0, int P_1, ScanCodeFlags P_2, int P_3)
		{
			IBCRebEcAYeDwHxlzbXDOuAgUKcD = P_0;
			MiaiILsHODRzujanRDSfjEUWZswhA = P_1;
			BcFWYlJUSrPAKLQmsoouwzMqVqSh = P_2;
			swwSAmQUYPxEMqqwcbQkGGcoFpZg = P_3;
		}
	}

	[DefaultMember("Item")]
	private class ANoONvinhNDGyHcLLNGPAQBZSGIfb : zygiggvvAqrjDLpoajmjYJDuCRos
	{
		private readonly MutpnMKLQSoCxYVEIbAoEZbVPMPP[] xHkYZODdEgwKkGIioBsnohdQYcmF;

		int zygiggvvAqrjDLpoajmjYJDuCRos.PXPWvCbCOCHTqtibNAGzqgScAlVP => xHkYZODdEgwKkGIioBsnohdQYcmF.Length;

		MutpnMKLQSoCxYVEIbAoEZbVPMPP zygiggvvAqrjDLpoajmjYJDuCRos.bBSBxCTpxyChKGPplSQyhMwyqFRFA => xHkYZODdEgwKkGIioBsnohdQYcmF[P_0];

		public ANoONvinhNDGyHcLLNGPAQBZSGIfb(params MutpnMKLQSoCxYVEIbAoEZbVPMPP[] P_0)
		{
			xHkYZODdEgwKkGIioBsnohdQYcmF = P_0;
		}
	}

	private class OlOsnPhylXBKinhIIXFjabHVFFRI
	{
		public readonly KeyboardKeyCode EsfkAZJbvFPaCVSzQnHfRlSMgCDB;

		public readonly zygiggvvAqrjDLpoajmjYJDuCRos xnoPGxMdabFxbhuQTILzdLqhxImMb;

		public OlOsnPhylXBKinhIIXFjabHVFFRI(KeyboardKeyCode P_0, zygiggvvAqrjDLpoajmjYJDuCRos P_1)
		{
			EsfkAZJbvFPaCVSzQnHfRlSMgCDB = P_0;
			xnoPGxMdabFxbhuQTILzdLqhxImMb = P_1;
		}
	}

	private class pwuATmqElQgeQfUQzxJqpNfTxXIHA
	{
		public string YHjBSwVHEYnlHliLnLKHpsozBIm;
	}

	private struct ZIqZQWSXxlLdOSBAJcoJLKPyznyG
	{
		public const int RXeFnoKBFhCHUFpDbtugbbcaeLZeA = 256;

		public int wqlmIOqjrSVvgbcPTYPcvcVuBFxw;

		public ScanCodeFlags EvsjlaVrUcdQjesOPYMtRcOtMPahA;

		public uint RwXDIfkigKxMoOyYCiRCsENDMMUn
		{
			get
			{
				return vAHxLMscLZDaBiMpHJJYBnKFlIKFA(wqlmIOqjrSVvgbcPTYPcvcVuBFxw, EvsjlaVrUcdQjesOPYMtRcOtMPahA);
			}
			set
			{
				KyJXVMIGvSTKfqTdaQQkKXlPqZWv(num, out wqlmIOqjrSVvgbcPTYPcvcVuBFxw, out EvsjlaVrUcdQjesOPYMtRcOtMPahA);
			}
		}

		public ZIqZQWSXxlLdOSBAJcoJLKPyznyG(int P_0, ScanCodeFlags P_1)
		{
			wqlmIOqjrSVvgbcPTYPcvcVuBFxw = P_0;
			EvsjlaVrUcdQjesOPYMtRcOtMPahA = P_1;
		}

		public Keys DZdJcKEktkaHRyNDkyQKgNYQGdcFA()
		{
			uint num = AmOfVgHMXtIpYGmFoUHcniSRkMulA.OTeBDvHwSkqKKXoWWaOAfYDogfbsA(RwXDIfkigKxMoOyYCiRCsENDMMUn, eWeEhNdWXFKKoUYVUXekPSNqerKDA.PkKemwxWmiFBBZfeyEyTbbNsarcD);
			if (num == 0 || num >= 256)
			{
				return Keys.None;
			}
			return (Keys)num;
		}

		public static ZIqZQWSXxlLdOSBAJcoJLKPyznyG KxFgGqgCFSULPoXvZbzRYYhogzrSA(uint P_0)
		{
			return new ZIqZQWSXxlLdOSBAJcoJLKPyznyG
			{
				RwXDIfkigKxMoOyYCiRCsENDMMUn = P_0
			};
		}

		public static ZIqZQWSXxlLdOSBAJcoJLKPyznyG jAGkWSFgFHohJRjTmwwyAEZUkPWv(Keys P_0)
		{
			ZIqZQWSXxlLdOSBAJcoJLKPyznyG result = default(ZIqZQWSXxlLdOSBAJcoJLKPyznyG);
			KyJXVMIGvSTKfqTdaQQkKXlPqZWv(AmOfVgHMXtIpYGmFoUHcniSRkMulA.OTeBDvHwSkqKKXoWWaOAfYDogfbsA((uint)P_0, eWeEhNdWXFKKoUYVUXekPSNqerKDA.UkWgfGgWIOCXpypivISmScgwIGjC), out result.wqlmIOqjrSVvgbcPTYPcvcVuBFxw, out result.EvsjlaVrUcdQjesOPYMtRcOtMPahA);
			return result;
		}

		public static uint vAHxLMscLZDaBiMpHJJYBnKFlIKFA(int P_0, ScanCodeFlags P_1)
		{
			int num = P_0;
			if ((P_1 & ScanCodeFlags.E0) != ScanCodeFlags.Make)
			{
				num = (num & -65281) | 0xE000;
			}
			if ((P_1 & ScanCodeFlags.E1) != ScanCodeFlags.Make)
			{
				num = (num & -65281) | 0xE100;
			}
			return (uint)num;
		}

		public static void KyJXVMIGvSTKfqTdaQQkKXlPqZWv(uint P_0, out int P_1, out ScanCodeFlags P_2)
		{
			byte b = (byte)(P_0 & 0xFF);
			if (b <= 121)
			{
				P_2 = ScanCodeFlags.Make;
				P_1 = b;
			}
			else
			{
				P_2 = ScanCodeFlags.Break;
				P_1 = b - 128;
			}
			byte num = (byte)((P_0 >> 8) & 0xFF);
			if (num == 224)
			{
				P_2 |= ScanCodeFlags.E0;
			}
			if (num == 225)
			{
				P_2 |= ScanCodeFlags.E1;
			}
		}
	}

	private const int TmzxBkfMfbynbXhBCiGheKFNeLoBb = 132;

	private const int BmjoPBOJSjKGOwnZEiaFcoLOnRzv = 256;

	private static readonly int[] KcgCWZDbKGIZxfoGETyTBunfAUKfA;

	private static readonly int tRbEeAaJaUESsZtYwXNDkkCeCYKBb;

	private static IntPtr QEmirJqZXNguxJLOHFxyCHwQJuvG;

	public static KeyboardLayout ZSArZfxxxRNTIlcdkHZxhiRSbmZg;

	private static readonly int[] GHmJQqClQQRYQpbSTKGXdApsIoQN;

	private readonly object btUBkPeBXKcGROEOcQEATUSunuPCA = new object();

	private UpdateLoopDataSet<WmbCRDqATJqILkefpgtxDdlFOsuM> DaOrvqrjTXPBhylmQkCcyEKlyIJd;

	private HardwareControllerMap_Game mWfQVolyyTHNTLzvrZhhIPilWrCi;

	private bool bBqCzzheiunJtHBYFkDxiyEcOpJD;

	private int GKpajfazGOlGQiwfDqzaDnkcMjmU;

	private bool[] PLtLloBQVleKAkVABLxtAMjIfdVac = new bool[256];

	private readonly caEnGEkhndjxEAVryFuHaGNZPRpeb xzGqpNTzReuJHQIqFAOLoXFZaJphA = new caEnGEkhndjxEAVryFuHaGNZPRpeb();

	private bool vkdHrqXQTmcdYIQhlcrDblfTRMgX;

	private readonly bool KFdpjRiHjMDAzyLZAfIlklTDcWDH;

	private bool SbwRlzIgdLVQtCMBajeMherqvjjsA;

	private RawInputUnifiedKeyboardExtension lWRcnmziUGFhfmzEfQtTBgPBckBv;

	private static readonly char[] vUsFwLpGGNwtZpZtNMdpTcHTNsYA;

	private static readonly IndexedDictionary<int, List<OlOsnPhylXBKinhIIXFjabHVFFRI>> SEUDEZaATQkAYSqtsAfBoLyFfcqfb;

	private static readonly IndexedDictionary<int, zygiggvvAqrjDLpoajmjYJDuCRos> rhWRrtajDHEbNrQekvHKfubWQnll;

	private static readonly IndexedDictionary<int, pwuATmqElQgeQfUQzxJqpNfTxXIHA> kQXzmUFWoaxViKNQgXwnQuPJTlZL;

	private static readonly int[] CVwDohyXIMzXrlRmoeAWFGzhPvvm;

	private bool ltZZCfdxiKZvgncXNguSyLKFPkZl;

	private static Dictionary<int, Dictionary<int, KeyboardKeyCode>> ifZmjdqkePozuXlkumYRsimHxhcK;

	private static readonly int[] AsYabDjcgUnSpLyaTdTocYvDUEvmc;

	public KeyboardLayout hqaiRKzHwcGEWHVuyUwHUpmfIOwH => ZSArZfxxxRNTIlcdkHZxhiRSbmZg;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return vkdHrqXQTmcdYIQhlcrDblfTRMgX;
		}
		set
		{
			if (vkdHrqXQTmcdYIQhlcrDblfTRMgX != value)
			{
				vkdHrqXQTmcdYIQhlcrDblfTRMgX = value;
			}
		}
	}

	InputSource IUnifiedKeyboardSource.inputSource => InputSource.RawInput;

	HardwareControllerMap_Game IUnifiedKeyboardSource.hardwareMap
	{
		get
		{
			if (mWfQVolyyTHNTLzvrZhhIPilWrCi == null)
			{
				mWfQVolyyTHNTLzvrZhhIPilWrCi = frCcopJkgqeuCAyDprsQUJxhNYcFb();
			}
			return mWfQVolyyTHNTLzvrZhhIPilWrCi;
		}
	}

	int IUnifiedKeyboardSource.buttonCount => 132;

	Controller.Extension IUnifiedKeyboardSource.controllerExtension => lWRcnmziUGFhfmzEfQtTBgPBckBv;

	static pKsmEHzqbGUnPrIgUbPlXlJimyVh()
	{
		ZSArZfxxxRNTIlcdkHZxhiRSbmZg = KeyboardLayout.US;
		GHmJQqClQQRYQpbSTKGXdApsIoQN = (int[])Enum.GetValues(typeof(KeyboardLayout));
		vUsFwLpGGNwtZpZtNMdpTcHTNsYA = new char[128];
		rhWRrtajDHEbNrQekvHKfubWQnll = new IndexedDictionary<int, zygiggvvAqrjDLpoajmjYJDuCRos>
		{
			{
				97,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(31, 30, ScanCodeFlags.Make, 4)
			},
			{
				98,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(50, 48, ScanCodeFlags.Make, 5)
			},
			{
				99,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(48, 46, ScanCodeFlags.Make, 6)
			},
			{
				100,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(33, 32, ScanCodeFlags.Make, 7)
			},
			{
				101,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(19, 18, ScanCodeFlags.Make, 8)
			},
			{
				102,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(34, 33, ScanCodeFlags.Make, 9)
			},
			{
				103,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(35, 34, ScanCodeFlags.Make, 10)
			},
			{
				104,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(36, 35, ScanCodeFlags.Make, 11)
			},
			{
				105,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(24, 23, ScanCodeFlags.Make, 12)
			},
			{
				106,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(37, 36, ScanCodeFlags.Make, 13)
			},
			{
				107,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(38, 37, ScanCodeFlags.Make, 14)
			},
			{
				108,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(39, 38, ScanCodeFlags.Make, 15)
			},
			{
				109,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(52, 50, ScanCodeFlags.Make, 16)
			},
			{
				110,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(51, 49, ScanCodeFlags.Make, 17)
			},
			{
				111,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(25, 24, ScanCodeFlags.Make, 18)
			},
			{
				112,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(26, 25, ScanCodeFlags.Make, 19)
			},
			{
				113,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(17, 16, ScanCodeFlags.Make, 20)
			},
			{
				114,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(20, 19, ScanCodeFlags.Make, 21)
			},
			{
				115,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(32, 31, ScanCodeFlags.Make, 22)
			},
			{
				116,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(21, 20, ScanCodeFlags.Make, 23)
			},
			{
				117,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(23, 22, ScanCodeFlags.Make, 24)
			},
			{
				118,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(49, 47, ScanCodeFlags.Make, 25)
			},
			{
				119,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(18, 17, ScanCodeFlags.Make, 26)
			},
			{
				120,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(47, 45, ScanCodeFlags.Make, 27)
			},
			{
				121,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(22, 21, ScanCodeFlags.Make, 28)
			},
			{
				122,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(46, 44, ScanCodeFlags.Make, 29)
			},
			{
				48,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(11, 11, ScanCodeFlags.Make, 39)
			},
			{
				49,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(2, 2, ScanCodeFlags.Make, 30)
			},
			{
				50,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(3, 3, ScanCodeFlags.Make, 31)
			},
			{
				51,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(4, 4, ScanCodeFlags.Make, 32)
			},
			{
				52,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(5, 5, ScanCodeFlags.Make, 33)
			},
			{
				53,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(6, 6, ScanCodeFlags.Make, 34)
			},
			{
				54,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(7, 7, ScanCodeFlags.Make, 35)
			},
			{
				55,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(8, 8, ScanCodeFlags.Make, 36)
			},
			{
				56,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(9, 9, ScanCodeFlags.Make, 37)
			},
			{
				57,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(10, 10, ScanCodeFlags.Make, 38)
			},
			{
				256,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(99, 82, ScanCodeFlags.Make, 98)
			},
			{
				257,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(93, 79, ScanCodeFlags.Make, 89)
			},
			{
				258,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(98, 80, ScanCodeFlags.Make, 90)
			},
			{
				259,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(103, 81, ScanCodeFlags.Make, 91)
			},
			{
				260,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(92, 75, ScanCodeFlags.Make, 92)
			},
			{
				261,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(97, 76, ScanCodeFlags.Make, 93)
			},
			{
				262,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(102, 77, ScanCodeFlags.Make, 94)
			},
			{
				263,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(91, 71, ScanCodeFlags.Make, 95)
			},
			{
				264,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(96, 72, ScanCodeFlags.Make, 96)
			},
			{
				265,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(101, 73, ScanCodeFlags.Make, 97)
			},
			{
				266,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(104, 83, ScanCodeFlags.Make, 99)
			},
			{
				267,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(95, 53, ScanCodeFlags.E0, 84)
			},
			{
				268,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(100, 55, ScanCodeFlags.Make, 85)
			},
			{
				269,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(105, 74, ScanCodeFlags.Make, 86)
			},
			{
				270,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(106, 78, ScanCodeFlags.Make, 87)
			},
			{
				271,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(108, 28, ScanCodeFlags.E0, 88)
			},
			{
				272,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(-1, -1, ScanCodeFlags.Make, 103)
			},
			{
				8,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(15, 14, ScanCodeFlags.Make, 42)
			},
			{
				9,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(16, 15, ScanCodeFlags.Make, 43)
			},
			{
				12,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(-1, -1, ScanCodeFlags.Make, 156)
			},
			{
				13,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(43, 28, ScanCodeFlags.Make, 40)
			},
			{
				19,
				new ANoONvinhNDGyHcLLNGPAQBZSGIfb(new MutpnMKLQSoCxYVEIbAoEZbVPMPP(126, 29, ScanCodeFlags.E1, 72), new MutpnMKLQSoCxYVEIbAoEZbVPMPP(-1, 70, ScanCodeFlags.E0, 155))
			},
			{
				27,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(110, 1, ScanCodeFlags.Make, 41)
			},
			{
				32,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(61, 57, ScanCodeFlags.Make, 44)
			},
			{
				35,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(-1, -1, ScanCodeFlags.Make, 50)
			},
			{
				39,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(41, 40, ScanCodeFlags.Make, 52)
			},
			{
				44,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(53, 51, ScanCodeFlags.Make, 54)
			},
			{
				45,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(12, 12, ScanCodeFlags.Make, 45)
			},
			{
				46,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(54, 52, ScanCodeFlags.Make, 55)
			},
			{
				47,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(55, 53, ScanCodeFlags.Make, 56)
			},
			{
				59,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(40, 39, ScanCodeFlags.Make, 51)
			},
			{
				61,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(13, 13, ScanCodeFlags.Make, 46)
			},
			{
				91,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(27, 26, ScanCodeFlags.Make, 48)
			},
			{
				92,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(29, 43, ScanCodeFlags.Make, 49)
			},
			{
				93,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(28, 27, ScanCodeFlags.Make, 47)
			},
			{
				96,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(1, 41, ScanCodeFlags.Make, 53)
			},
			{
				127,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(76, 83, ScanCodeFlags.E0, 76)
			},
			{
				273,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(83, 72, ScanCodeFlags.E0, 82)
			},
			{
				274,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(84, 80, ScanCodeFlags.E0, 81)
			},
			{
				275,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(89, 77, ScanCodeFlags.E0, 79)
			},
			{
				276,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(79, 75, ScanCodeFlags.E0, 80)
			},
			{
				277,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(75, 82, ScanCodeFlags.E0, 73)
			},
			{
				278,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(80, 71, ScanCodeFlags.E0, 74)
			},
			{
				279,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(81, 79, ScanCodeFlags.E0, 77)
			},
			{
				280,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(85, 73, ScanCodeFlags.E0, 75)
			},
			{
				281,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(86, 81, ScanCodeFlags.E0, 78)
			},
			{
				282,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(112, 59, ScanCodeFlags.Make, 58)
			},
			{
				283,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(113, 60, ScanCodeFlags.Make, 59)
			},
			{
				284,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(114, 61, ScanCodeFlags.Make, 60)
			},
			{
				285,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(115, 62, ScanCodeFlags.Make, 61)
			},
			{
				286,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(116, 63, ScanCodeFlags.Make, 62)
			},
			{
				287,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(117, 64, ScanCodeFlags.Make, 63)
			},
			{
				288,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(118, 65, ScanCodeFlags.Make, 64)
			},
			{
				289,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(119, 66, ScanCodeFlags.Make, 65)
			},
			{
				290,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(120, 67, ScanCodeFlags.Make, 66)
			},
			{
				291,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(121, 68, ScanCodeFlags.Make, 67)
			},
			{
				292,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(122, 87, ScanCodeFlags.Make, 68)
			},
			{
				293,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(123, 88, ScanCodeFlags.Make, 69)
			},
			{
				294,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(-1, -1, ScanCodeFlags.Make, 104)
			},
			{
				295,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(-1, -1, ScanCodeFlags.Make, 105)
			},
			{
				296,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(-1, -1, ScanCodeFlags.Make, 106)
			},
			{
				300,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(90, 69, ScanCodeFlags.Make, 83)
			},
			{
				301,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(30, 58, ScanCodeFlags.Make, 57)
			},
			{
				302,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(125, 70, ScanCodeFlags.Make, 71)
			},
			{
				303,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(57, 54, ScanCodeFlags.Make, 229)
			},
			{
				304,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(44, 42, ScanCodeFlags.Make, 225)
			},
			{
				305,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(64, 29, ScanCodeFlags.E0, 228)
			},
			{
				306,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(58, 29, ScanCodeFlags.Make, 224)
			},
			{
				307,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(62, 56, ScanCodeFlags.E0, 230)
			},
			{
				308,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(60, 56, ScanCodeFlags.Make, 226)
			},
			{
				311,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(-1, 91, ScanCodeFlags.E0, 227)
			},
			{
				312,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(-1, 92, ScanCodeFlags.E0, 231)
			},
			{
				313,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(62, 56, ScanCodeFlags.E0, 230)
			},
			{
				315,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(-1, -1, ScanCodeFlags.Make, 117)
			},
			{
				316,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(124, 55, ScanCodeFlags.E0, 70)
			},
			{
				317,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(-1, -1, ScanCodeFlags.Make, 154)
			},
			{
				319,
				new MutpnMKLQSoCxYVEIbAoEZbVPMPP(129, 93, ScanCodeFlags.E0, 118)
			}
		};
		kQXzmUFWoaxViKNQgXwnQuPJTlZL = new IndexedDictionary<int, pwuATmqElQgeQfUQzxJqpNfTxXIHA>
		{
			{
				3,
				new pwuATmqElQgeQfUQzxJqpNfTxXIHA()
			},
			{
				2,
				new pwuATmqElQgeQfUQzxJqpNfTxXIHA()
			},
			{
				1,
				new pwuATmqElQgeQfUQzxJqpNfTxXIHA()
			},
			{
				4,
				new pwuATmqElQgeQfUQzxJqpNfTxXIHA()
			}
		};
		CVwDohyXIMzXrlRmoeAWFGzhPvvm = new int[26]
		{
			30, 48, 46, 32, 18, 33, 34, 35, 23, 36,
			37, 38, 50, 49, 24, 25, 16, 19, 31, 20,
			22, 47, 17, 45, 21, 44
		};
		ifZmjdqkePozuXlkumYRsimHxhcK = new Dictionary<int, Dictionary<int, KeyboardKeyCode>>
		{
			{
				1033,
				new Dictionary<int, KeyboardKeyCode>
				{
					{
						222,
						KeyboardKeyCode.Quote
					},
					{
						188,
						KeyboardKeyCode.Comma
					},
					{
						189,
						KeyboardKeyCode.Minus
					},
					{
						190,
						KeyboardKeyCode.Period
					},
					{
						191,
						KeyboardKeyCode.Slash
					},
					{
						186,
						KeyboardKeyCode.Semicolon
					},
					{
						187,
						KeyboardKeyCode.Equals
					},
					{
						219,
						KeyboardKeyCode.LeftBracket
					},
					{
						220,
						KeyboardKeyCode.Backslash
					},
					{
						221,
						KeyboardKeyCode.RightBracket
					},
					{
						192,
						KeyboardKeyCode.BackQuote
					},
					{
						223,
						KeyboardKeyCode.BackQuote
					}
				}
			},
			{
				2057,
				new Dictionary<int, KeyboardKeyCode>
				{
					{
						223,
						KeyboardKeyCode.BackQuote
					},
					{
						192,
						KeyboardKeyCode.Quote
					}
				}
			},
			{
				1106,
				new Dictionary<int, KeyboardKeyCode>
				{
					{
						223,
						KeyboardKeyCode.BackQuote
					},
					{
						192,
						KeyboardKeyCode.Quote
					}
				}
			},
			{
				1031,
				new Dictionary<int, KeyboardKeyCode>
				{
					{
						219,
						KeyboardKeyCode.Backslash
					},
					{
						221,
						KeyboardKeyCode.BackQuote
					}
				}
			}
		};
		AsYabDjcgUnSpLyaTdTocYvDUEvmc = new int[22]
		{
			186, 191, 192, 219, 220, 221, 222, 223, 226, 226,
			254, 221, 188, 189, 219, 190, 220, 187, 191, 222,
			186, 192
		};
		int[] keyboardKeyValues = Consts._keyboardKeyValues;
		int num = keyboardKeyValues.Length;
		for (int i = 0; i < num; i++)
		{
			if (keyboardKeyValues[i] > tRbEeAaJaUESsZtYwXNDkkCeCYKBb)
			{
				tRbEeAaJaUESsZtYwXNDkkCeCYKBb = keyboardKeyValues[i];
			}
		}
		KcgCWZDbKGIZxfoGETyTBunfAUKfA = new int[tRbEeAaJaUESsZtYwXNDkkCeCYKBb + 1];
		ArrayTools.Fill(KcgCWZDbKGIZxfoGETyTBunfAUKfA, -1);
		for (int j = 0; j < num; j++)
		{
			KcgCWZDbKGIZxfoGETyTBunfAUKfA[keyboardKeyValues[j]] = j;
		}
		SEUDEZaATQkAYSqtsAfBoLyFfcqfb = new IndexedDictionary<int, List<OlOsnPhylXBKinhIIXFjabHVFFRI>>();
		for (int k = 0; k < rhWRrtajDHEbNrQekvHKfubWQnll.Count; k++)
		{
			for (int l = 0; l < rhWRrtajDHEbNrQekvHKfubWQnll[k].PXPWvCbCOCHTqtibNAGzqgScAlVP; l++)
			{
				int key = JUhsccFNJkIEPKvOOsGUIpCeBmrf(rhWRrtajDHEbNrQekvHKfubWQnll[k].WURpDAKCtVnuPCIKtEvSAYfnpBVUA(l).MiaiILsHODRzujanRDSfjEUWZswhA, rhWRrtajDHEbNrQekvHKfubWQnll[k].WURpDAKCtVnuPCIKtEvSAYfnpBVUA(l).BcFWYlJUSrPAKLQmsoouwzMqVqSh);
				if (!SEUDEZaATQkAYSqtsAfBoLyFfcqfb.TryGetValue(key, out var value))
				{
					value = new List<OlOsnPhylXBKinhIIXFjabHVFFRI>();
					SEUDEZaATQkAYSqtsAfBoLyFfcqfb.Add(key, value);
				}
				value.Add(new OlOsnPhylXBKinhIIXFjabHVFFRI((KeyboardKeyCode)rhWRrtajDHEbNrQekvHKfubWQnll.GetKeyAt(k), rhWRrtajDHEbNrQekvHKfubWQnll[k]));
			}
		}
	}

	public pKsmEHzqbGUnPrIgUbPlXlJimyVh(UpdateLoopSetting P_0, bool P_1, bool P_2)
	{
		KFdpjRiHjMDAzyLZAfIlklTDcWDH = P_1;
		SbwRlzIgdLVQtCMBajeMherqvjjsA = P_2;
		tLOXxogMJbTGcboXlQfUVskahFxL();
		DaOrvqrjTXPBhylmQkCcyEKlyIJd = new UpdateLoopDataSet<WmbCRDqATJqILkefpgtxDdlFOsuM>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				DaOrvqrjTXPBhylmQkCcyEKlyIJd[i] = new WmbCRDqATJqILkefpgtxDdlFOsuM(list[i]);
			}
		}
		bBqCzzheiunJtHBYFkDxiyEcOpJD = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lWRcnmziUGFhfmzEfQtTBgPBckBv = new RawInputUnifiedKeyboardExtension(this);
		Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
		ReInput.ApplicationFocusChangedEvent += qqudZdNxnfSVIicXfyLEjrjJoWAA;
		ReInput.ApplicationPauseChangedEvent += MTDAMKrjcrklNtfpqpdOYfyBGsLQ;
		ReInput.EditorPauseChangedEvent += zdZJhmixzxoxrudeBDiVCHyPBHnDA;
		ReInput.UpdateEndedEvent += KtUfKwVYhJHXJNoOZkoLLJSVytGL;
		ReInput.TimeScalePauseChangedEvent += RTQWBHslHxjDUEZckuRXVrerDQCv;
	}

	public void kQwCANfCxdbbtGpnbdtMjJPSCeEEb()
	{
		CsJsGKMcXCnYqAHIlUmDHEFLmeYi();
	}

	public void FiGoaASIaWRCNZZpNFpfHRIhAXdx(UpdateLoopType P_0)
	{
		DaOrvqrjTXPBhylmQkCcyEKlyIJd.SetUpdateLoop(P_0);
		bBqCzzheiunJtHBYFkDxiyEcOpJD = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (btUBkPeBXKcGROEOcQEATUSunuPCA)
		{
			bool flag = false;
			if (SbwRlzIgdLVQtCMBajeMherqvjjsA != ReInput.configuration.showSystemKeyLabels)
			{
				SbwRlzIgdLVQtCMBajeMherqvjjsA = !SbwRlzIgdLVQtCMBajeMherqvjjsA;
				flag = true;
			}
			KeyboardLayout zSArZfxxxRNTIlcdkHZxhiRSbmZg = ZSArZfxxxRNTIlcdkHZxhiRSbmZg;
			KeyboardLayout keyboardLayout = YrDbVrGODLKjVNhNzhhNaEjdkxMoB();
			if (zSArZfxxxRNTIlcdkHZxhiRSbmZg != keyboardLayout)
			{
				flag = true;
			}
			if (flag)
			{
				CsJsGKMcXCnYqAHIlUmDHEFLmeYi();
			}
			XukubFpJmPvoTUmcYZmRVAfDxHQQ();
		}
	}

	private unsafe void XukubFpJmPvoTUmcYZmRVAfDxHQQ()
	{
		try
		{
			byte* ptr = stackalloc byte[256];
			if (!AmOfVgHMXtIpYGmFoUHcniSRkMulA.RuacZBejzVfrGPgvTDfXiYxAJHhsb((IntPtr)ptr))
			{
				return;
			}
			for (int i = 0; i < 256; i++)
			{
				int num = i;
				Keys keys = (Keys)i;
				switch (keys)
				{
				case Keys.LButton:
				case Keys.RButton:
				case Keys.MButton:
				case Keys.XButton1:
				case Keys.XButton2:
				case Keys.ShiftKey:
				case Keys.ControlKey:
				case Keys.Menu:
				case Keys.Shift:
				case Keys.Control:
					continue;
				}
				uint num2 = AmOfVgHMXtIpYGmFoUHcniSRkMulA.OTeBDvHwSkqKKXoWWaOAfYDogfbsA((uint)i, eWeEhNdWXFKKoUYVUXekPSNqerKDA.UkWgfGgWIOCXpypivISmScgwIGjC);
				if (num2 == 0)
				{
					continue;
				}
				ZIqZQWSXxlLdOSBAJcoJLKPyznyG zIqZQWSXxlLdOSBAJcoJLKPyznyG = ZIqZQWSXxlLdOSBAJcoJLKPyznyG.KxFgGqgCFSULPoXvZbzRYYhogzrSA(num2);
				if ((ptr[num] & 0x80) == 0)
				{
					if (PLtLloBQVleKAkVABLxtAMjIfdVac[num])
					{
						xzGqpNTzReuJHQIqFAOLoXFZaJphA.GijQDBXFRYACVftbepJHbJMhuBCuA();
						xzGqpNTzReuJHQIqFAOLoXFZaJphA.pZXlOgGfndHoMOWUCzJjTLItTvOl = ReInput.realTime;
						xzGqpNTzReuJHQIqFAOLoXFZaJphA.IbBQvVaTnWNYkuSUYtOKqgYUKebu = IntPtr.Zero;
						xzGqpNTzReuJHQIqFAOLoXFZaJphA.SrWnJgTOhnxibZaQyEQDlmzmbPncA = keys;
						xzGqpNTzReuJHQIqFAOLoXFZaJphA.uqKigSprnCCwtGIYDlPSIrLaQPpe = zIqZQWSXxlLdOSBAJcoJLKPyznyG.wqlmIOqjrSVvgbcPTYPcvcVuBFxw;
						xzGqpNTzReuJHQIqFAOLoXFZaJphA.dSMOcGvLQZogpUNSuBaaAqBTYRTx = ScanCodeFlags.Break | gqyungYpVdJQyqksCjRRkJmkFABiA(zIqZQWSXxlLdOSBAJcoJLKPyznyG.EvsjlaVrUcdQjesOPYMtRcOtMPahA);
						xzGqpNTzReuJHQIqFAOLoXFZaJphA.ZtWSSMboOAjDsBxeVKaLzgtDsGnO = KeyState.KeyUp;
						xzGqpNTzReuJHQIqFAOLoXFZaJphA.zDVHrdewGBnufDyAUfkAnxvmYMFo = 0;
						dEdPfPzBlRQONIneuHCqkqgAoHsc(xzGqpNTzReuJHQIqFAOLoXFZaJphA, KeyEventType.Fake);
					}
				}
				else if (!PLtLloBQVleKAkVABLxtAMjIfdVac[num])
				{
					xzGqpNTzReuJHQIqFAOLoXFZaJphA.GijQDBXFRYACVftbepJHbJMhuBCuA();
					xzGqpNTzReuJHQIqFAOLoXFZaJphA.pZXlOgGfndHoMOWUCzJjTLItTvOl = ReInput.realTime;
					xzGqpNTzReuJHQIqFAOLoXFZaJphA.IbBQvVaTnWNYkuSUYtOKqgYUKebu = IntPtr.Zero;
					xzGqpNTzReuJHQIqFAOLoXFZaJphA.SrWnJgTOhnxibZaQyEQDlmzmbPncA = keys;
					xzGqpNTzReuJHQIqFAOLoXFZaJphA.uqKigSprnCCwtGIYDlPSIrLaQPpe = zIqZQWSXxlLdOSBAJcoJLKPyznyG.wqlmIOqjrSVvgbcPTYPcvcVuBFxw;
					xzGqpNTzReuJHQIqFAOLoXFZaJphA.dSMOcGvLQZogpUNSuBaaAqBTYRTx = ScanCodeFlags.Make | gqyungYpVdJQyqksCjRRkJmkFABiA(zIqZQWSXxlLdOSBAJcoJLKPyznyG.EvsjlaVrUcdQjesOPYMtRcOtMPahA);
					xzGqpNTzReuJHQIqFAOLoXFZaJphA.ZtWSSMboOAjDsBxeVKaLzgtDsGnO = KeyState.KeyFirst;
					xzGqpNTzReuJHQIqFAOLoXFZaJphA.zDVHrdewGBnufDyAUfkAnxvmYMFo = 0;
					dEdPfPzBlRQONIneuHCqkqgAoHsc(xzGqpNTzReuJHQIqFAOLoXFZaJphA, KeyEventType.Fake);
				}
			}
		}
		catch
		{
		}
	}

	public void jLMAKvOUWVmfinWCJymafBmdpGhA(caEnGEkhndjxEAVryFuHaGNZPRpeb P_0)
	{
		dEdPfPzBlRQONIneuHCqkqgAoHsc(P_0, KeyEventType.Real);
	}

	private void dEdPfPzBlRQONIneuHCqkqgAoHsc(caEnGEkhndjxEAVryFuHaGNZPRpeb P_0, KeyEventType P_1)
	{
		if (!bBqCzzheiunJtHBYFkDxiyEcOpJD || P_0.SrWnJgTOhnxibZaQyEQDlmzmbPncA == (Keys)255)
		{
			return;
		}
		bool flag = P_1 == KeyEventType.FakeVKeyOnly;
		if (xTXaBVHWlSHcuMEQqaZbyOAojwCfA(P_0.SrWnJgTOhnxibZaQyEQDlmzmbPncA) && iykVmOdhdlShnRqGrbnVbZHjkjas(P_0.SrWnJgTOhnxibZaQyEQDlmzmbPncA, out var keys, out var keys2))
		{
			Keys keys3 = new ZIqZQWSXxlLdOSBAJcoJLKPyznyG(P_0.uqKigSprnCCwtGIYDlPSIrLaQPpe, P_0.dSMOcGvLQZogpUNSuBaaAqBTYRTx).DZdJcKEktkaHRyNDkyQKgNYQGdcFA();
			Keys keys4;
			Keys keys5;
			if (keys3 == keys || keys3 == keys2)
			{
				P_0.SrWnJgTOhnxibZaQyEQDlmzmbPncA = keys3;
			}
			else if (knuxtAlgVBVSQrWjVJBPvNAGxaTU(P_0.ZtWSSMboOAjDsBxeVKaLzgtDsGnO, keys, keys2, out keys4, out keys5))
			{
				KeyEventType keyEventType = ((!KFdpjRiHjMDAzyLZAfIlklTDcWDH) ? KeyEventType.Fake : KeyEventType.FakeVKeyOnly);
				if (keys4 != Keys.None)
				{
					P_0.SrWnJgTOhnxibZaQyEQDlmzmbPncA = keys4;
					dEdPfPzBlRQONIneuHCqkqgAoHsc(P_0, keyEventType);
				}
				if (keys5 != Keys.None)
				{
					P_0.SrWnJgTOhnxibZaQyEQDlmzmbPncA = keys5;
					dEdPfPzBlRQONIneuHCqkqgAoHsc(P_0, keyEventType);
				}
				return;
			}
		}
		int srWnJgTOhnxibZaQyEQDlmzmbPncA = (int)P_0.SrWnJgTOhnxibZaQyEQDlmzmbPncA;
		if (srWnJgTOhnxibZaQyEQDlmzmbPncA < 0 || srWnJgTOhnxibZaQyEQDlmzmbPncA >= PLtLloBQVleKAkVABLxtAMjIfdVac.Length)
		{
			return;
		}
		lock (btUBkPeBXKcGROEOcQEATUSunuPCA)
		{
			KeyState ztWSSMboOAjDsBxeVKaLzgtDsGnO = P_0.ZtWSSMboOAjDsBxeVKaLzgtDsGnO;
			if (ztWSSMboOAjDsBxeVKaLzgtDsGnO == KeyState.KeyFirst || ztWSSMboOAjDsBxeVKaLzgtDsGnO == KeyState.SystemKeyDown)
			{
				PLtLloBQVleKAkVABLxtAMjIfdVac[srWnJgTOhnxibZaQyEQDlmzmbPncA] = true;
			}
			else
			{
				PLtLloBQVleKAkVABLxtAMjIfdVac[srWnJgTOhnxibZaQyEQDlmzmbPncA] = false;
			}
			if (!flag)
			{
				int count = DaOrvqrjTXPBhylmQkCcyEKlyIJd.Count;
				for (int i = 0; i < count; i++)
				{
					DaOrvqrjTXPBhylmQkCcyEKlyIJd[i].fkoEVHctgzQaDfvlBlRHPblWMsrn(KFdpjRiHjMDAzyLZAfIlklTDcWDH, P_0.SrWnJgTOhnxibZaQyEQDlmzmbPncA, P_0.uqKigSprnCCwtGIYDlPSIrLaQPpe, P_0.dSMOcGvLQZogpUNSuBaaAqBTYRTx, P_0.ZtWSSMboOAjDsBxeVKaLzgtDsGnO, ZSArZfxxxRNTIlcdkHZxhiRSbmZg);
				}
			}
		}
	}

	public void wKSkalTBHircCgScLxJHizXjxune(bool P_0)
	{
		mjksJvSLzzNqPSfEmMMnACjdiKr();
	}

	public void ugOdhIQrMajicQdNVXSzKDHRrbZf(bool P_0)
	{
		if (tLOXxogMJbTGcboXlQfUVskahFxL() < 0)
		{
			mjksJvSLzzNqPSfEmMMnACjdiKr();
		}
	}

	private int tLOXxogMJbTGcboXlQfUVskahFxL()
	{
		int gKpajfazGOlGQiwfDqzaDnkcMjmU = GKpajfazGOlGQiwfDqzaDnkcMjmU;
		if (CAMKjWWITLmVKNQaIYUpYBAnWcXD.vuAZHbZIAJZwCKAMyAtnNbsadYDgA(mPOQOSVPBoHEVSsvmRnefPJMUbqp.Keyboard, out var gKpajfazGOlGQiwfDqzaDnkcMjmU2))
		{
			GKpajfazGOlGQiwfDqzaDnkcMjmU = gKpajfazGOlGQiwfDqzaDnkcMjmU2;
		}
		else
		{
			GKpajfazGOlGQiwfDqzaDnkcMjmU = 1;
		}
		return GKpajfazGOlGQiwfDqzaDnkcMjmU - gKpajfazGOlGQiwfDqzaDnkcMjmU;
	}

	private void qqudZdNxnfSVIicXfyLEjrjJoWAA(bool P_0)
	{
		bBqCzzheiunJtHBYFkDxiyEcOpJD = ReInput.IsInputAllowed(ControllerType.Keyboard);
		if (!P_0 && !bBqCzzheiunJtHBYFkDxiyEcOpJD)
		{
			mjksJvSLzzNqPSfEmMMnACjdiKr();
		}
	}

	private void MTDAMKrjcrklNtfpqpdOYfyBGsLQ(bool P_0)
	{
		bBqCzzheiunJtHBYFkDxiyEcOpJD = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!bBqCzzheiunJtHBYFkDxiyEcOpJD)
		{
			mjksJvSLzzNqPSfEmMMnACjdiKr();
		}
	}

	private void zdZJhmixzxoxrudeBDiVCHyPBHnDA(bool P_0)
	{
	}

	private void RTQWBHslHxjDUEZckuRXVrerDQCv(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		bBqCzzheiunJtHBYFkDxiyEcOpJD = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (btUBkPeBXKcGROEOcQEATUSunuPCA)
		{
			DaOrvqrjTXPBhylmQkCcyEKlyIJd[DaOrvqrjTXPBhylmQkCcyEKlyIJd.fixedUpdateSetIndex].kkXoQOXoMkQUaZpCFbjVYNNWbxABA();
		}
	}

	private void KtUfKwVYhJHXJNoOZkoLLJSVytGL(UpdateLoopType P_0)
	{
		lock (btUBkPeBXKcGROEOcQEATUSunuPCA)
		{
			DaOrvqrjTXPBhylmQkCcyEKlyIJd.Get(P_0).VSspQoHMSNBsYdrpUslgTougHoNQA();
		}
	}

	private void CsJsGKMcXCnYqAHIlUmDHEFLmeYi()
	{
		OjeDMfaWaTROEPQSPuywvFXRxSBI();
	}

	private void mjksJvSLzzNqPSfEmMMnACjdiKr()
	{
		lock (btUBkPeBXKcGROEOcQEATUSunuPCA)
		{
			int count = DaOrvqrjTXPBhylmQkCcyEKlyIJd.Count;
			for (int i = 0; i < count; i++)
			{
				DaOrvqrjTXPBhylmQkCcyEKlyIJd[i].tmlPrYnYgHDDXfgiDZADfXqxgoEI();
			}
		}
	}

	public void OjeDMfaWaTROEPQSPuywvFXRxSBI()
	{
		int count = rhWRrtajDHEbNrQekvHKfubWQnll.Count;
		for (int i = 0; i < count; i++)
		{
			KeyboardKeyCode keyAt = (KeyboardKeyCode)rhWRrtajDHEbNrQekvHKfubWQnll.GetKeyAt(i);
			string name = (SbwRlzIgdLVQtCMBajeMherqvjjsA ? icCiUHDWvNhWwGqpPbzrbCmmwvJlA(keyAt, rhWRrtajDHEbNrQekvHKfubWQnll[i], KFdpjRiHjMDAzyLZAfIlklTDcWDH) : null);
			Keyboard.SetKeyName(keyAt, name);
		}
		if (SbwRlzIgdLVQtCMBajeMherqvjjsA)
		{
			string text = ievOeWtNjPQQePxelifHqaoycrEKA(ModifierKey.Shift, false, KFdpjRiHjMDAzyLZAfIlklTDcWDH);
			Keyboard.SetModifierKeyName(ModifierKey.Shift, text, text);
			Keyboard.SetModifierKeyName(ModifierKey.Control, ievOeWtNjPQQePxelifHqaoycrEKA(ModifierKey.Control, true, KFdpjRiHjMDAzyLZAfIlklTDcWDH), ievOeWtNjPQQePxelifHqaoycrEKA(ModifierKey.Control, false, KFdpjRiHjMDAzyLZAfIlklTDcWDH));
			text = ievOeWtNjPQQePxelifHqaoycrEKA(ModifierKey.Alt, false, KFdpjRiHjMDAzyLZAfIlklTDcWDH);
			Keyboard.SetModifierKeyName(ModifierKey.Alt, text, text);
		}
		else
		{
			Keyboard.SetModifierKeyName(ModifierKey.Shift, null, null);
			Keyboard.SetModifierKeyName(ModifierKey.Control, null, null);
			Keyboard.SetModifierKeyName(ModifierKey.Alt, null, null);
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		DaOrvqrjTXPBhylmQkCcyEKlyIJd.Current.MwkpCtAuVLNthLGvAncPPhUtDDNJA(dataUpdater);
	}

	void IUnifiedKeyboardSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		mjksJvSLzzNqPSfEmMMnACjdiKr();
	}

	void IUnifiedKeyboardSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private static HardwareControllerMap_Game frCcopJkgqeuCAyDprsQUJxhNYcFb()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(i, Consts.keyboardKeyNames[i], Consts.keyboardKeyNames[i], string.Empty, ControllerElementType.Button, true);
		}
		int[] array2 = new int[132];
		for (int j = 0; j < 132; j++)
		{
			array2[j] = array[j].id;
		}
		HardwareButtonInfo[] array3 = new HardwareButtonInfo[132];
		for (int k = 0; k < 132; k++)
		{
			array3[k] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Keyboard", default(HardwareControllerMapIdentifier), array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
	}

	private static string icCiUHDWvNhWwGqpPbzrbCmmwvJlA(KeyboardKeyCode P_0, zygiggvvAqrjDLpoajmjYJDuCRos P_1, bool P_2)
	{
		if (P_1.WURpDAKCtVnuPCIKtEvSAYfnpBVUA(0).MiaiILsHODRzujanRDSfjEUWZswhA >= 0)
		{
			return TfwItJhjYvZTIAAcLOXpfVcBmXJGc(P_1.WURpDAKCtVnuPCIKtEvSAYfnpBVUA(0).MiaiILsHODRzujanRDSfjEUWZswhA, P_1.WURpDAKCtVnuPCIKtEvSAYfnpBVUA(0).BcFWYlJUSrPAKLQmsoouwzMqVqSh, P_2);
		}
		return KxFJJmbqgezaYvRZFAYPBDlnOhFU(P_0);
	}

	private static string TfwItJhjYvZTIAAcLOXpfVcBmXJGc(int P_0, ScanCodeFlags P_1, bool P_2)
	{
		ZIqZQWSXxlLdOSBAJcoJLKPyznyG zIqZQWSXxlLdOSBAJcoJLKPyznyG = new ZIqZQWSXxlLdOSBAJcoJLKPyznyG(P_0, P_1);
		uint num = zIqZQWSXxlLdOSBAJcoJLKPyznyG.RwXDIfkigKxMoOyYCiRCsENDMMUn;
		string text;
		if (ArrayTools.Contains(CVwDohyXIMzXrlRmoeAWFGzhPvvm, P_0))
		{
			text = rSrgCyldfGtwslldOkdxnDvdGoQM(P_0, P_1);
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
		}
		else
		{
			int num2 = (int)(num << 16);
			if ((P_1 & ScanCodeFlags.E0) != ScanCodeFlags.Make || (P_1 & ScanCodeFlags.E1) != ScanCodeFlags.Make)
			{
				num2 |= 0x1000000;
			}
			if (P_2)
			{
				if (P_0 == 69 && P_1 == ScanCodeFlags.Make)
				{
					num2 = 21299201;
				}
				else if (P_0 == 29 && (P_1 & ScanCodeFlags.E1) != ScanCodeFlags.Make)
				{
					num2 = 4521985;
				}
			}
			else
			{
				switch (zIqZQWSXxlLdOSBAJcoJLKPyznyG.DZdJcKEktkaHRyNDkyQKgNYQGdcFA())
				{
				case Keys.NumLock:
					num2 = 21299201;
					break;
				case Keys.Pause:
					num2 = 4521985;
					break;
				}
			}
			int num3 = AmOfVgHMXtIpYGmFoUHcniSRkMulA.TNzDEEQTwJwzDpGThdZoZdbvBfzI(num2, vUsFwLpGGNwtZpZtNMdpTcHTNsYA, vUsFwLpGGNwtZpZtNMdpTcHTNsYA.Length);
			if (num3 <= 0)
			{
				return null;
			}
			text = new string(vUsFwLpGGNwtZpZtNMdpTcHTNsYA, 0, num3);
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
		}
		TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
		string text2 = textInfo.ToLower(text);
		if (!string.IsNullOrEmpty(text2))
		{
			text = textInfo.ToTitleCase(text2);
		}
		return text;
	}

	private unsafe static string rSrgCyldfGtwslldOkdxnDvdGoQM(int P_0, ScanCodeFlags P_1)
	{
		ZIqZQWSXxlLdOSBAJcoJLKPyznyG zIqZQWSXxlLdOSBAJcoJLKPyznyG = new ZIqZQWSXxlLdOSBAJcoJLKPyznyG(P_0, P_1);
		Keys keys = zIqZQWSXxlLdOSBAJcoJLKPyznyG.DZdJcKEktkaHRyNDkyQKgNYQGdcFA();
		if (keys == Keys.None)
		{
			return null;
		}
		byte* ptr = stackalloc byte[256];
		XtGMeZGVawiSiXBiWNwsFFHEKjXt.oSiUCYIqBigyjDdAORRwEeuGhUBkB(ptr, 256);
		ptr[(int)keys] = 128;
		int num = AmOfVgHMXtIpYGmFoUHcniSRkMulA.KWsHKorpjypxMJfxnFzPurnFJovQ((uint)keys, zIqZQWSXxlLdOSBAJcoJLKPyznyG.RwXDIfkigKxMoOyYCiRCsENDMMUn, (IntPtr)ptr, vUsFwLpGGNwtZpZtNMdpTcHTNsYA, vUsFwLpGGNwtZpZtNMdpTcHTNsYA.Length, 4u);
		if (num < 0)
		{
			if (vUsFwLpGGNwtZpZtNMdpTcHTNsYA[0] == '\0' || char.IsControl(vUsFwLpGGNwtZpZtNMdpTcHTNsYA[0]))
			{
				return null;
			}
			num = -num;
		}
		if (num <= 0 || (num == 1 && char.IsControl(vUsFwLpGGNwtZpZtNMdpTcHTNsYA[0])))
		{
			return null;
		}
		return new string(vUsFwLpGGNwtZpZtNMdpTcHTNsYA, 0, num);
	}

	private static string ievOeWtNjPQQePxelifHqaoycrEKA(ModifierKey P_0, bool P_1, bool P_2)
	{
		string text = null;
		ZIqZQWSXxlLdOSBAJcoJLKPyznyG zIqZQWSXxlLdOSBAJcoJLKPyznyG = default(ZIqZQWSXxlLdOSBAJcoJLKPyznyG);
		if (P_2)
		{
			switch (P_0)
			{
			case ModifierKey.Shift:
				zIqZQWSXxlLdOSBAJcoJLKPyznyG.wqlmIOqjrSVvgbcPTYPcvcVuBFxw = 42;
				break;
			case ModifierKey.Control:
				zIqZQWSXxlLdOSBAJcoJLKPyznyG.wqlmIOqjrSVvgbcPTYPcvcVuBFxw = 29;
				break;
			case ModifierKey.Alt:
				zIqZQWSXxlLdOSBAJcoJLKPyznyG.wqlmIOqjrSVvgbcPTYPcvcVuBFxw = 56;
				break;
			default:
				text = null;
				break;
			}
		}
		else
		{
			Keys keys;
			switch (P_0)
			{
			case ModifierKey.Shift:
				keys = Keys.Shift;
				break;
			case ModifierKey.Control:
				keys = Keys.Control;
				break;
			case ModifierKey.Alt:
				keys = Keys.Alt;
				break;
			default:
				keys = Keys.None;
				text = null;
				break;
			}
			if (keys != Keys.None)
			{
				zIqZQWSXxlLdOSBAJcoJLKPyznyG = ZIqZQWSXxlLdOSBAJcoJLKPyznyG.jAGkWSFgFHohJRjTmwwyAEZUkPWv(keys);
			}
		}
		if (zIqZQWSXxlLdOSBAJcoJLKPyznyG.wqlmIOqjrSVvgbcPTYPcvcVuBFxw != 0)
		{
			text = TfwItJhjYvZTIAAcLOXpfVcBmXJGc(zIqZQWSXxlLdOSBAJcoJLKPyznyG.wqlmIOqjrSVvgbcPTYPcvcVuBFxw, zIqZQWSXxlLdOSBAJcoJLKPyznyG.EvsjlaVrUcdQjesOPYMtRcOtMPahA, P_2);
			if (P_1 && !string.IsNullOrEmpty(text) && string.Equals(text, "control", StringComparison.OrdinalIgnoreCase))
			{
				return rtabTutpWdGgSGkYbKnSVtAllFge(P_0, P_1);
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			text = rtabTutpWdGgSGkYbKnSVtAllFge(P_0, P_1);
		}
		return text;
	}

	private static string KxFJJmbqgezaYvRZFAYPBDlnOhFU(KeyboardKeyCode P_0)
	{
		int num = Consts.keyboardKeyValues.IndexOf((int)P_0);
		if (num < 0)
		{
			return null;
		}
		return Consts.keyboardKeyNames[num];
	}

	private static string rtabTutpWdGgSGkYbKnSVtAllFge(ModifierKey P_0, bool P_1)
	{
		if (!Consts.modifierKeyInfo.TryGetValue((int)P_0, out var value))
		{
			if (!P_1)
			{
				return value.longName;
			}
			return value.shortName;
		}
		return null;
	}

	private static int JUhsccFNJkIEPKvOOsGUIpCeBmrf(int P_0, ScanCodeFlags P_1)
	{
		if ((P_1 & ScanCodeFlags.E0) != ScanCodeFlags.Make)
		{
			P_0 |= 0x100;
		}
		if ((P_1 & ScanCodeFlags.E1) != ScanCodeFlags.Make)
		{
			P_0 |= 0x200;
		}
		return P_0;
	}

	public static ScanCodeFlags gqyungYpVdJQyqksCjRRkJmkFABiA(ScanCodeFlags P_0)
	{
		ScanCodeFlags scanCodeFlags = ScanCodeFlags.Make;
		if ((P_0 & ScanCodeFlags.E0) != ScanCodeFlags.Make)
		{
			scanCodeFlags |= ScanCodeFlags.E0;
		}
		if ((P_0 & ScanCodeFlags.E1) != ScanCodeFlags.Make)
		{
			scanCodeFlags |= ScanCodeFlags.E1;
		}
		return scanCodeFlags;
	}

	private static bool hBhzpLCGnjLUVkYpbJRSkNahCAXH(KeyState P_0)
	{
		if (P_0 == KeyState.KeyFirst || P_0 == KeyState.SystemKeyDown || P_0 == KeyState.KeyLast)
		{
			return true;
		}
		return false;
	}

	private static bool knuxtAlgVBVSQrWjVJBPvNAGxaTU(KeyState P_0, Keys P_1, Keys P_2, out Keys P_3, out Keys P_4)
	{
		P_3 = Keys.None;
		P_4 = Keys.None;
		bool flag = (AmOfVgHMXtIpYGmFoUHcniSRkMulA.fYdDcnKbmXhXoLGKaoALTcdQJbVI((int)P_1) & 0x8000) != 0;
		bool flag2 = (AmOfVgHMXtIpYGmFoUHcniSRkMulA.fYdDcnKbmXhXoLGKaoALTcdQJbVI((int)P_2) & 0x8000) != 0;
		if (hBhzpLCGnjLUVkYpbJRSkNahCAXH(P_0))
		{
			if (flag && (AmOfVgHMXtIpYGmFoUHcniSRkMulA.aJxqguVXLbHSJMoClFOZHMnXCeQK((int)P_1) & 0x8000) == 0)
			{
				P_3 = P_1;
			}
			if (flag2 && (AmOfVgHMXtIpYGmFoUHcniSRkMulA.aJxqguVXLbHSJMoClFOZHMnXCeQK((int)P_2) & 0x8000) == 0)
			{
				if (P_3 == Keys.None)
				{
					P_3 = P_2;
				}
				else
				{
					P_4 = P_2;
				}
			}
		}
		else
		{
			if (!flag && (AmOfVgHMXtIpYGmFoUHcniSRkMulA.aJxqguVXLbHSJMoClFOZHMnXCeQK((int)P_1) & 0x8000) != 0)
			{
				P_3 = P_1;
			}
			if (!flag2 && (AmOfVgHMXtIpYGmFoUHcniSRkMulA.aJxqguVXLbHSJMoClFOZHMnXCeQK((int)P_2) & 0x8000) != 0)
			{
				if (P_3 == Keys.None)
				{
					P_3 = P_2;
				}
				else
				{
					P_4 = P_2;
				}
			}
		}
		return P_3 != Keys.None;
	}

	private static bool iykVmOdhdlShnRqGrbnVbZHjkjas(Keys P_0, out Keys P_1, out Keys P_2)
	{
		switch (P_0)
		{
		case Keys.ControlKey:
			P_1 = Keys.LControlKey;
			P_2 = Keys.RControlKey;
			return true;
		case Keys.Menu:
			P_1 = Keys.LMenu;
			P_2 = Keys.RMenu;
			return true;
		case Keys.ShiftKey:
			P_1 = Keys.LShiftKey;
			P_2 = Keys.RShiftKey;
			return true;
		default:
			P_1 = Keys.None;
			P_2 = Keys.None;
			return false;
		}
	}

	private static bool xTXaBVHWlSHcuMEQqaZbyOAojwCfA(Keys P_0)
	{
		if ((uint)(P_0 - 16) <= 2u)
		{
			return true;
		}
		return false;
	}

	private static bool bhsHhXrWeefwbGQpKYKnkzpgLfKC(Keys P_0)
	{
		if ((uint)(P_0 - 16) <= 2u || (uint)(P_0 - 91) <= 1u || (uint)(P_0 - 160) <= 5u)
		{
			return true;
		}
		return false;
	}

	private static bool EOJxVDPPWbRWCKdlZzwLIyHHdUlX(Keys P_0)
	{
		switch (P_0)
		{
		case Keys.Prior:
		case Keys.Next:
		case Keys.End:
		case Keys.Home:
		case Keys.Left:
		case Keys.Up:
		case Keys.Right:
		case Keys.Down:
		case Keys.Insert:
		case Keys.Delete:
		case Keys.Divide:
		case Keys.NumLock:
			return true;
		default:
			return false;
		}
	}

	public void Dispose()
	{
		ccTORprIyPqnYoUiYiXVtEItJiSq(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void ZGGKZqXNuyrZPaxjaWFjKqHiTDXD()
	{
		try
		{
			ccTORprIyPqnYoUiYiXVtEItJiSq(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void ccTORprIyPqnYoUiYiXVtEItJiSq(bool P_0)
	{
		if (!ltZZCfdxiKZvgncXNguSyLKFPkZl)
		{
			ReInput.ApplicationFocusChangedEvent -= qqudZdNxnfSVIicXfyLEjrjJoWAA;
			ReInput.ApplicationPauseChangedEvent -= MTDAMKrjcrklNtfpqpdOYfyBGsLQ;
			ReInput.EditorPauseChangedEvent -= zdZJhmixzxoxrudeBDiVCHyPBHnDA;
			ReInput.UpdateEndedEvent -= KtUfKwVYhJHXJNoOZkoLLJSVytGL;
			ReInput.TimeScalePauseChangedEvent -= RTQWBHslHxjDUEZckuRXVrerDQCv;
			ltZZCfdxiKZvgncXNguSyLKFPkZl = true;
		}
	}

	public static int MKccxkYhcEoGZnfVhEXmomexOJtS(Keys P_0, ScanCodeFlags P_1, KeyboardKeyCode[] P_2, KeyboardLayout P_3)
	{
		int result = 0;
		_ = QEmirJqZXNguxJLOHFxyCHwQJuvG;
		if (BUccuZHLAQOTXJYfCFpxFXrKONusA(P_0))
		{
			if (VhldsPBCWMhtYkWUqnyrRTlmvgUHA(P_0, P_3, out var keyboardKeyCode))
			{
				P_2[result++] = keyboardKeyCode;
			}
		}
		else
		{
			switch (P_0)
			{
			case Keys.None:
				P_2[result++] = KeyboardKeyCode.None;
				break;
			case Keys.A:
				P_2[result++] = KeyboardKeyCode.A;
				break;
			case Keys.B:
				P_2[result++] = KeyboardKeyCode.B;
				break;
			case Keys.C:
				P_2[result++] = KeyboardKeyCode.C;
				break;
			case Keys.D:
				P_2[result++] = KeyboardKeyCode.D;
				break;
			case Keys.E:
				P_2[result++] = KeyboardKeyCode.E;
				break;
			case Keys.F:
				P_2[result++] = KeyboardKeyCode.F;
				break;
			case Keys.G:
				P_2[result++] = KeyboardKeyCode.G;
				break;
			case Keys.H:
				P_2[result++] = KeyboardKeyCode.H;
				break;
			case Keys.I:
				P_2[result++] = KeyboardKeyCode.I;
				break;
			case Keys.J:
				P_2[result++] = KeyboardKeyCode.J;
				break;
			case Keys.K:
				P_2[result++] = KeyboardKeyCode.K;
				break;
			case Keys.L:
				P_2[result++] = KeyboardKeyCode.L;
				break;
			case Keys.M:
				P_2[result++] = KeyboardKeyCode.M;
				break;
			case Keys.N:
				P_2[result++] = KeyboardKeyCode.N;
				break;
			case Keys.O:
				P_2[result++] = KeyboardKeyCode.O;
				break;
			case Keys.P:
				P_2[result++] = KeyboardKeyCode.P;
				break;
			case Keys.Q:
				P_2[result++] = KeyboardKeyCode.Q;
				break;
			case Keys.R:
				P_2[result++] = KeyboardKeyCode.R;
				break;
			case Keys.S:
				P_2[result++] = KeyboardKeyCode.S;
				break;
			case Keys.T:
				P_2[result++] = KeyboardKeyCode.T;
				break;
			case Keys.U:
				P_2[result++] = KeyboardKeyCode.U;
				break;
			case Keys.V:
				P_2[result++] = KeyboardKeyCode.V;
				break;
			case Keys.W:
				P_2[result++] = KeyboardKeyCode.W;
				break;
			case Keys.X:
				P_2[result++] = KeyboardKeyCode.X;
				break;
			case Keys.Y:
				P_2[result++] = KeyboardKeyCode.Y;
				break;
			case Keys.Z:
				P_2[result++] = KeyboardKeyCode.Z;
				break;
			case Keys.D0:
				P_2[result++] = KeyboardKeyCode.Alpha0;
				break;
			case Keys.D1:
				P_2[result++] = KeyboardKeyCode.Alpha1;
				break;
			case Keys.D2:
				P_2[result++] = KeyboardKeyCode.Alpha2;
				break;
			case Keys.D3:
				P_2[result++] = KeyboardKeyCode.Alpha3;
				break;
			case Keys.D4:
				P_2[result++] = KeyboardKeyCode.Alpha4;
				break;
			case Keys.D5:
				P_2[result++] = KeyboardKeyCode.Alpha5;
				break;
			case Keys.D6:
				P_2[result++] = KeyboardKeyCode.Alpha6;
				break;
			case Keys.D7:
				P_2[result++] = KeyboardKeyCode.Alpha7;
				break;
			case Keys.D8:
				P_2[result++] = KeyboardKeyCode.Alpha8;
				break;
			case Keys.D9:
				P_2[result++] = KeyboardKeyCode.Alpha9;
				break;
			case Keys.NumPad0:
				P_2[result++] = KeyboardKeyCode.Keypad0;
				break;
			case Keys.NumPad1:
				P_2[result++] = KeyboardKeyCode.Keypad1;
				break;
			case Keys.NumPad2:
				P_2[result++] = KeyboardKeyCode.Keypad2;
				break;
			case Keys.NumPad3:
				P_2[result++] = KeyboardKeyCode.Keypad3;
				break;
			case Keys.NumPad4:
				P_2[result++] = KeyboardKeyCode.Keypad4;
				break;
			case Keys.NumPad5:
				P_2[result++] = KeyboardKeyCode.Keypad5;
				break;
			case Keys.NumPad6:
				P_2[result++] = KeyboardKeyCode.Keypad6;
				break;
			case Keys.NumPad7:
				P_2[result++] = KeyboardKeyCode.Keypad7;
				break;
			case Keys.NumPad8:
				P_2[result++] = KeyboardKeyCode.Keypad8;
				break;
			case Keys.NumPad9:
				P_2[result++] = KeyboardKeyCode.Keypad9;
				break;
			case Keys.Decimal:
				P_2[result++] = KeyboardKeyCode.KeypadPeriod;
				break;
			case Keys.Divide:
				P_2[result++] = KeyboardKeyCode.KeypadDivide;
				break;
			case Keys.Multiply:
				P_2[result++] = KeyboardKeyCode.KeypadMultiply;
				break;
			case Keys.Subtract:
				P_2[result++] = KeyboardKeyCode.KeypadMinus;
				break;
			case Keys.Add:
				P_2[result++] = KeyboardKeyCode.KeypadPlus;
				break;
			case Keys.Return:
				if ((P_1 & ScanCodeFlags.E0) != ScanCodeFlags.Make)
				{
					P_2[result++] = KeyboardKeyCode.KeypadEnter;
				}
				else
				{
					P_2[result++] = KeyboardKeyCode.Return;
				}
				break;
			case Keys.Back:
				P_2[result++] = KeyboardKeyCode.Backspace;
				break;
			case Keys.Tab:
				P_2[result++] = KeyboardKeyCode.Tab;
				break;
			case Keys.Clear:
				P_2[result++] = KeyboardKeyCode.Clear;
				break;
			case Keys.Cancel:
			case Keys.Pause:
				P_2[result++] = KeyboardKeyCode.Pause;
				break;
			case Keys.Escape:
				P_2[result++] = KeyboardKeyCode.Escape;
				break;
			case Keys.Space:
				P_2[result++] = KeyboardKeyCode.Space;
				break;
			case Keys.Delete:
				P_2[result++] = KeyboardKeyCode.Delete;
				break;
			case Keys.Up:
				P_2[result++] = KeyboardKeyCode.UpArrow;
				break;
			case Keys.Down:
				P_2[result++] = KeyboardKeyCode.DownArrow;
				break;
			case Keys.Right:
				P_2[result++] = KeyboardKeyCode.RightArrow;
				break;
			case Keys.Left:
				P_2[result++] = KeyboardKeyCode.LeftArrow;
				break;
			case Keys.Insert:
				P_2[result++] = KeyboardKeyCode.Insert;
				break;
			case Keys.Home:
				P_2[result++] = KeyboardKeyCode.Home;
				break;
			case Keys.End:
				P_2[result++] = KeyboardKeyCode.End;
				break;
			case Keys.Prior:
				P_2[result++] = KeyboardKeyCode.PageUp;
				break;
			case Keys.Next:
				P_2[result++] = KeyboardKeyCode.PageDown;
				break;
			case Keys.F1:
				P_2[result++] = KeyboardKeyCode.F1;
				break;
			case Keys.F2:
				P_2[result++] = KeyboardKeyCode.F2;
				break;
			case Keys.F3:
				P_2[result++] = KeyboardKeyCode.F3;
				break;
			case Keys.F4:
				P_2[result++] = KeyboardKeyCode.F4;
				break;
			case Keys.F5:
				P_2[result++] = KeyboardKeyCode.F5;
				break;
			case Keys.F6:
				P_2[result++] = KeyboardKeyCode.F6;
				break;
			case Keys.F7:
				P_2[result++] = KeyboardKeyCode.F7;
				break;
			case Keys.F8:
				P_2[result++] = KeyboardKeyCode.F8;
				break;
			case Keys.F9:
				P_2[result++] = KeyboardKeyCode.F9;
				break;
			case Keys.F10:
				P_2[result++] = KeyboardKeyCode.F10;
				break;
			case Keys.F11:
				P_2[result++] = KeyboardKeyCode.F11;
				break;
			case Keys.F12:
				P_2[result++] = KeyboardKeyCode.F12;
				break;
			case Keys.F13:
				P_2[result++] = KeyboardKeyCode.F13;
				break;
			case Keys.F14:
				P_2[result++] = KeyboardKeyCode.F14;
				break;
			case Keys.F15:
				P_2[result++] = KeyboardKeyCode.F15;
				break;
			case Keys.NumLock:
				P_2[result++] = KeyboardKeyCode.Numlock;
				break;
			case Keys.Capital:
				P_2[result++] = KeyboardKeyCode.CapsLock;
				break;
			case Keys.Scroll:
				P_2[result++] = KeyboardKeyCode.ScrollLock;
				break;
			case Keys.RShiftKey:
				P_2[result++] = KeyboardKeyCode.RightShift;
				break;
			case Keys.LShiftKey:
				P_2[result++] = KeyboardKeyCode.LeftShift;
				break;
			case Keys.RControlKey:
				P_2[result++] = KeyboardKeyCode.RightControl;
				break;
			case Keys.LControlKey:
				P_2[result++] = KeyboardKeyCode.LeftControl;
				break;
			case Keys.RMenu:
				P_2[result++] = KeyboardKeyCode.AltGr;
				P_2[result++] = KeyboardKeyCode.RightAlt;
				break;
			case Keys.LMenu:
				P_2[result++] = KeyboardKeyCode.LeftAlt;
				break;
			case Keys.RWin:
				P_2[result++] = KeyboardKeyCode.RightCommand;
				break;
			case Keys.LWin:
				P_2[result++] = KeyboardKeyCode.LeftCommand;
				break;
			case Keys.Help:
				P_2[result++] = KeyboardKeyCode.Help;
				break;
			case Keys.Snapshot:
				P_2[result++] = KeyboardKeyCode.Print;
				break;
			case Keys.Apps:
				P_2[result++] = KeyboardKeyCode.Menu;
				break;
			}
		}
		return result;
	}

	public static int vWZsmJWaCWErxdCVMdRzyrlgGLAQA(int P_0, ScanCodeFlags P_1, KeyboardKeyCode[] P_2, KeyboardLayout P_3)
	{
		if (!SEUDEZaATQkAYSqtsAfBoLyFfcqfb.TryGetEntry(JUhsccFNJkIEPKvOOsGUIpCeBmrf(P_0, P_1), out var entry))
		{
			return 0;
		}
		List<OlOsnPhylXBKinhIIXFjabHVFFRI> value = entry.Value;
		int num = value.Count;
		if (num >= P_2.Length)
		{
			num = P_2.Length;
		}
		for (int i = 0; i < num; i++)
		{
			P_2[i] = value[i].EsfkAZJbvFPaCVSzQnHfRlSMgCDB;
		}
		return num;
	}

	private unsafe static KeyboardLayout YrDbVrGODLKjVNhNzhhNaEjdkxMoB()
	{
		IntPtr intPtr = AmOfVgHMXtIpYGmFoUHcniSRkMulA.RvFcKNgbGCBEVFiyhkIlpgtGKWlI(0u);
		if (intPtr == QEmirJqZXNguxJLOHFxyCHwQJuvG)
		{
			return ZSArZfxxxRNTIlcdkHZxhiRSbmZg;
		}
		KeyboardLayout keyboardLayout = KeyboardLayout.US;
		byte* intPtr2 = stackalloc byte[128];
		AmOfVgHMXtIpYGmFoUHcniSRkMulA.fTFkjlzBHPppmMwoIBmrVoljTlOL((IntPtr)intPtr2);
		if (int.TryParse(Marshal.PtrToStringUni((IntPtr)intPtr2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
		{
			int num = ArrayTools.IndexOf(GHmJQqClQQRYQpbSTKGXdApsIoQN, result);
			keyboardLayout = (KeyboardLayout)((num < 0) ? result : GHmJQqClQQRYQpbSTKGXdApsIoQN[num]);
		}
		QEmirJqZXNguxJLOHFxyCHwQJuvG = intPtr;
		ZSArZfxxxRNTIlcdkHZxhiRSbmZg = keyboardLayout;
		return keyboardLayout;
	}

	private static bool VhldsPBCWMhtYkWUqnyrRTlmvgUHA(Keys P_0, KeyboardLayout P_1, out KeyboardKeyCode P_2)
	{
		P_2 = KeyboardKeyCode.None;
		if (!ifZmjdqkePozuXlkumYRsimHxhcK.TryGetValue((int)P_1, out var value))
		{
			value = ifZmjdqkePozuXlkumYRsimHxhcK[1033];
		}
		bool flag = value.TryGetValue((int)P_0, out P_2);
		if (!flag && P_1 != KeyboardLayout.US)
		{
			value = ifZmjdqkePozuXlkumYRsimHxhcK[1033];
			flag = value.TryGetValue((int)P_0, out P_2);
		}
		return flag;
	}

	private static bool BUccuZHLAQOTXJYfCFpxFXrKONusA(Keys P_0)
	{
		return ArrayTools.Contains(AsYabDjcgUnSpLyaTdTocYvDUEvmc, (int)P_0);
	}
}
