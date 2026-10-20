using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class uNUJNNadqmDFujCsBrlAGsjEbLTu
{
	public class TLvAsxXXuLwkcAhTuCdGuWTKOPLp
	{
		public readonly Action<InputActionEventData> ZmOWbSEoKmjSNbDPTHRmCqVeLbcjB;

		public readonly UpdateLoopType vPMgdLyqwzXiBPwfwMlTrOtzwkYS;

		public readonly InputActionEventType hqxzfELvcUxrIufdojstdPNWqfqO;

		public readonly int QSwfBuWMyCqhVFLpqZLELpSXOMDn;

		public readonly bool DsSsdhDkRHQLCyrMNEnnnjmObcvdA;

		public float[] NxGxtsfQWYepYlUtRyFQzZhRwyng;

		public TLvAsxXXuLwkcAhTuCdGuWTKOPLp(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
		{
			vPMgdLyqwzXiBPwfwMlTrOtzwkYS = P_1;
			hqxzfELvcUxrIufdojstdPNWqfqO = P_2;
			QSwfBuWMyCqhVFLpqZLELpSXOMDn = P_3;
			ZmOWbSEoKmjSNbDPTHRmCqVeLbcjB = P_0;
			igKVsJqOntZvpZevCxLGjWxjQctK(P_4);
			switch (P_2)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				DsSsdhDkRHQLCyrMNEnnnjmObcvdA = true;
				break;
			}
		}

		public bool VfQSlQAzSKqThmdQFJFoMHhaDSEJ(int P_0, out float P_1)
		{
			if (NxGxtsfQWYepYlUtRyFQzZhRwyng == null || NxGxtsfQWYepYlUtRyFQzZhRwyng.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = NxGxtsfQWYepYlUtRyFQzZhRwyng[P_0];
			return true;
		}

		private void igKVsJqOntZvpZevCxLGjWxjQctK(object[] P_0)
		{
			switch (hqxzfELvcUxrIufdojstdPNWqfqO)
			{
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + hqxzfELvcUxrIufdojstdPNWqfqO.ToString() + "\". 1 required argument: time [float], 1 optional argument: expireIn [float]");
				}
				NxGxtsfQWYepYlUtRyFQzZhRwyng = new float[2];
				if (P_0[0] is float)
				{
					NxGxtsfQWYepYlUtRyFQzZhRwyng[0] = (float)P_0[0];
				}
				else
				{
					if (!(P_0[0] is int))
					{
						throw new Exception("Wrong argument type passed for Input event type \"" + hqxzfELvcUxrIufdojstdPNWqfqO.ToString() + "\". Argument 0: time [float]");
					}
					NxGxtsfQWYepYlUtRyFQzZhRwyng[0] = (int)P_0[0];
				}
				if (P_0.Length <= 1)
				{
					break;
				}
				if (P_0[1] is float)
				{
					NxGxtsfQWYepYlUtRyFQzZhRwyng[1] = (float)P_0[1];
					break;
				}
				if (P_0[1] is int)
				{
					NxGxtsfQWYepYlUtRyFQzZhRwyng[1] = (int)P_0[1];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + hqxzfELvcUxrIufdojstdPNWqfqO.ToString() + "\". Argument 1 (optional): expireIn [float]");
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + hqxzfELvcUxrIufdojstdPNWqfqO.ToString() + "\". Requires 1 argument: time [float]");
				}
				NxGxtsfQWYepYlUtRyFQzZhRwyng = new float[1];
				if (P_0[0] is float)
				{
					NxGxtsfQWYepYlUtRyFQzZhRwyng[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					NxGxtsfQWYepYlUtRyFQzZhRwyng[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + hqxzfELvcUxrIufdojstdPNWqfqO.ToString() + "\". Argument 0: time [float]");
			case InputActionEventType.ButtonDoublePressed:
			case InputActionEventType.ButtonJustDoublePressed:
			case InputActionEventType.NegativeButtonDoublePressed:
			case InputActionEventType.NegativeButtonJustDoublePressed:
			case InputActionEventType.ButtonDoublePressJustReleased:
			case InputActionEventType.NegativeButtonDoublePressJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					break;
				}
				NxGxtsfQWYepYlUtRyFQzZhRwyng = new float[1];
				if (P_0[0] is float)
				{
					NxGxtsfQWYepYlUtRyFQzZhRwyng[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					NxGxtsfQWYepYlUtRyFQzZhRwyng[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + hqxzfELvcUxrIufdojstdPNWqfqO.ToString() + "\". Argument 0 (optional): time [float]");
			}
		}
	}

	[Serializable]
	private sealed class SgYZlIppUrHwxliejxXDStLxiNur
	{
		public static readonly SgYZlIppUrHwxliejxXDStLxiNur _003C_003E9 = new SgYZlIppUrHwxliejxXDStLxiNur();

		public static Func<AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>> _003C_003E9__8_0;

		internal AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp> RXdSENpycbBGqwacwjQbjMgvgoll()
		{
			return new AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>();
		}
	}

	private sealed class RlPntGVJuTqkTKGDhzHIMbdRpMgb
	{
		public Action<InputActionEventData> KqmarGbzMiTtgdKJHccoaFQOXKev;

		public Predicate<TLvAsxXXuLwkcAhTuCdGuWTKOPLp> lcMXyQcUdilLQkIxxDiJBwDSgSsh;

		internal bool fiuYzCLeYzMuUEqMcIBvcrOvHCVmA(TLvAsxXXuLwkcAhTuCdGuWTKOPLp P_0)
		{
			return P_0.ZmOWbSEoKmjSNbDPTHRmCqVeLbcjB == KqmarGbzMiTtgdKJHccoaFQOXKev;
		}
	}

	private sealed class sksSyOYzJtFhNBHViVTSviUpVrht
	{
		public Action<InputActionEventData> LekUGnwcUxPlxieRTAErvJsICBWIA;

		public int BivExyVweRIcIVsTHoTpUXWCJuLS;

		public Predicate<TLvAsxXXuLwkcAhTuCdGuWTKOPLp> bWoFVfAZRCoPZltpOHcDoxfOGHZUA;

		internal bool MvRGiEalhLWRGUdemZsjcSejAniw(TLvAsxXXuLwkcAhTuCdGuWTKOPLp P_0)
		{
			if (P_0.ZmOWbSEoKmjSNbDPTHRmCqVeLbcjB == LekUGnwcUxPlxieRTAErvJsICBWIA)
			{
				return P_0.QSwfBuWMyCqhVFLpqZLELpSXOMDn == BivExyVweRIcIVsTHoTpUXWCJuLS;
			}
			return false;
		}
	}

	private sealed class PCJnUaCktuEhafOpKapSARiTYicLA
	{
		public Action<InputActionEventData> tjWkfCBudDvNGCvDpwJzBYMbowgL;

		public UpdateLoopType rmsXExaQjYGNLtQICNsSNHMyrJhN;

		public Predicate<TLvAsxXXuLwkcAhTuCdGuWTKOPLp> ekXiYIfVqILowpGZZewyoXrHAMDL;

		internal bool TgcDFndgORcgsoJQlLxodrNlkudEA(TLvAsxXXuLwkcAhTuCdGuWTKOPLp P_0)
		{
			if (P_0.ZmOWbSEoKmjSNbDPTHRmCqVeLbcjB == tjWkfCBudDvNGCvDpwJzBYMbowgL)
			{
				return P_0.vPMgdLyqwzXiBPwfwMlTrOtzwkYS == rmsXExaQjYGNLtQICNsSNHMyrJhN;
			}
			return false;
		}
	}

	private sealed class ZnHPReEKrSjeDiSVLuQLIblNVZu
	{
		public Action<InputActionEventData> WXVEoJyNEKBzGFcCBCSzfjsGKKiS;

		public InputActionEventType aYnvNHoIPszpQpUFoDlftebgClHZ;

		public Predicate<TLvAsxXXuLwkcAhTuCdGuWTKOPLp> rVBpJimTTUHcgdLVMKRvxKenIXIw;

		internal bool hdQpeFtMmIbogQSBhJwezRaUjpIN(TLvAsxXXuLwkcAhTuCdGuWTKOPLp P_0)
		{
			if (P_0.ZmOWbSEoKmjSNbDPTHRmCqVeLbcjB == WXVEoJyNEKBzGFcCBCSzfjsGKKiS)
			{
				return P_0.hqxzfELvcUxrIufdojstdPNWqfqO == aYnvNHoIPszpQpUFoDlftebgClHZ;
			}
			return false;
		}
	}

	private sealed class PhihWjkJxZgLQUqqIBEriIzseipQA
	{
		public Action<InputActionEventData> PjDIGSvZZfUNGgnhrNmTXbKfhucaA;

		public UpdateLoopType sZPeRNKsFlFptBbOhqJfjzpghMTrA;

		public int sEWwhSskWqGBKfeSHwYdVUZRdrMP;

		public Predicate<TLvAsxXXuLwkcAhTuCdGuWTKOPLp> mkHjUrwjVidIAWJLrcswAXmAKDoO;

		internal bool uKFbMScXqabcYcnvGOnswjQFnTrMb(TLvAsxXXuLwkcAhTuCdGuWTKOPLp P_0)
		{
			if (P_0.ZmOWbSEoKmjSNbDPTHRmCqVeLbcjB == PjDIGSvZZfUNGgnhrNmTXbKfhucaA && P_0.vPMgdLyqwzXiBPwfwMlTrOtzwkYS == sZPeRNKsFlFptBbOhqJfjzpghMTrA)
			{
				return P_0.QSwfBuWMyCqhVFLpqZLELpSXOMDn == sEWwhSskWqGBKfeSHwYdVUZRdrMP;
			}
			return false;
		}
	}

	private sealed class CWhsFZQLSuBRTGeFiJLFzdCNkCcH
	{
		public Action<InputActionEventData> WnfNQTQkynrgIdXWrqPRtiuEtVQD;

		public UpdateLoopType DFnRkwCHFuPPcYhoiHpHJtKohCLIA;

		public int xzXXUFFcSGDPmdUPTcKcRhzxDvQwA;

		public InputActionEventType YHwHNdZBLujvBRNPAJAWpzzjCOdi;

		public Predicate<TLvAsxXXuLwkcAhTuCdGuWTKOPLp> svTUGlstdFTaeItOtDdpDCQWTFuH;

		internal bool YRsKuujRylPdZiqJJLfyOzIOGVRD(TLvAsxXXuLwkcAhTuCdGuWTKOPLp P_0)
		{
			if (P_0.ZmOWbSEoKmjSNbDPTHRmCqVeLbcjB == WnfNQTQkynrgIdXWrqPRtiuEtVQD && P_0.vPMgdLyqwzXiBPwfwMlTrOtzwkYS == DFnRkwCHFuPPcYhoiHpHJtKohCLIA && P_0.QSwfBuWMyCqhVFLpqZLELpSXOMDn == xzXXUFFcSGDPmdUPTcKcRhzxDvQwA)
			{
				return P_0.hqxzfELvcUxrIufdojstdPNWqfqO == YHwHNdZBLujvBRNPAJAWpzzjCOdi;
			}
			return false;
		}
	}

	private sealed class hULxIuOjkMhoHTmRETlunOqGlMkE
	{
		public Action<InputActionEventData> SdfkLUfbUTJEzcWIQKAIGKMKoGrI;

		public UpdateLoopType bvKyBYZKQDOJiCvPqowQftzAfLoQ;

		public InputActionEventType WkDIOWHWNTcqLamivIySEmnxaAEBA;

		public Predicate<TLvAsxXXuLwkcAhTuCdGuWTKOPLp> VyqizVioLkNVEebrgGDNaMuxRHzfA;

		internal bool dnREKWdUqcLcOFEYDDTzMZIPAshO(TLvAsxXXuLwkcAhTuCdGuWTKOPLp P_0)
		{
			if (P_0.ZmOWbSEoKmjSNbDPTHRmCqVeLbcjB == SdfkLUfbUTJEzcWIQKAIGKMKoGrI && P_0.vPMgdLyqwzXiBPwfwMlTrOtzwkYS == bvKyBYZKQDOJiCvPqowQftzAfLoQ)
			{
				return P_0.hqxzfELvcUxrIufdojstdPNWqfqO == WkDIOWHWNTcqLamivIySEmnxaAEBA;
			}
			return false;
		}
	}

	private sealed class IZCDCmjOWUDeMzbJOpJWcznlBdNlA
	{
		public Action<InputActionEventData> fkLNBmstAtXWkLxiWqXMZyAxtMS;

		public int HnzwoLHCOvGzQZFZiKlLZkfPSkIO;

		public InputActionEventType UgERYrBPsnqkPtXAKyOhwmvIXulB;

		public Predicate<TLvAsxXXuLwkcAhTuCdGuWTKOPLp> RTUKDzYxrJwNqDAatlgnDIlwKWjr;

		internal bool NKaJSQmuEEePnwDbtVQqGirUpkIy(TLvAsxXXuLwkcAhTuCdGuWTKOPLp P_0)
		{
			if (P_0.ZmOWbSEoKmjSNbDPTHRmCqVeLbcjB == fkLNBmstAtXWkLxiWqXMZyAxtMS && P_0.QSwfBuWMyCqhVFLpqZLELpSXOMDn == HnzwoLHCOvGzQZFZiKlLZkfPSkIO)
			{
				return P_0.hqxzfELvcUxrIufdojstdPNWqfqO == UgERYrBPsnqkPtXAKyOhwmvIXulB;
			}
			return false;
		}
	}

	private static TLvAsxXXuLwkcAhTuCdGuWTKOPLp[] FNwabXxOQgWekUgUagffflRvNmGn;

	private bool GoPOHhCuSCUSYnYhgahIgfjjgHzaA;

	private AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>[] MKUvrIkOkPLLOUkTnKTTJbRsfdqbA;

	private int[] UCVhYFBOxAAjDnQFvDKEAbIjboxlb;

	private int aIqWCdeedTGtTcckrttVwtEabxSq;

	public int TfLmHoQfTGnihrPObIBtbLImFktSA;

	static uNUJNNadqmDFujCsBrlAGsjEbLTu()
	{
		FNwabXxOQgWekUgUagffflRvNmGn = new TLvAsxXXuLwkcAhTuCdGuWTKOPLp[100];
	}

	private void khpdILvTaVDrvJHYfmVFxFqULzgF()
	{
		if (!GoPOHhCuSCUSYnYhgahIgfjjgHzaA)
		{
			IList<InputAction> list = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.ESPPucyzYlkSLFFzkQAwnJrIKGUm;
			int num = list?.Count ?? 0;
			MKUvrIkOkPLLOUkTnKTTJbRsfdqbA = new AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>[num + 1];
			UCVhYFBOxAAjDnQFvDKEAbIjboxlb = new int[ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.RPEdjbfyfPTpgjWtQupiJpegXCdV + 1];
			ArrayTools.Populate(MKUvrIkOkPLLOUkTnKTTJbRsfdqbA, 0, MKUvrIkOkPLLOUkTnKTTJbRsfdqbA.Length, SgYZlIppUrHwxliejxXDStLxiNur._003C_003E9.RXdSENpycbBGqwacwjQbjMgvgoll);
			for (int i = 0; i < num; i++)
			{
				UCVhYFBOxAAjDnQFvDKEAbIjboxlb[list[i].id] = i;
			}
			aIqWCdeedTGtTcckrttVwtEabxSq = num;
			GoPOHhCuSCUSYnYhgahIgfjjgHzaA = true;
		}
	}

	public void YURXkFoEwxFUUbtcyndZmPHgxQcTA(ULWotIhqUFBdhwlfsIksjyZhzzXLA P_0, UpdateLoopType P_1)
	{
		AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp> aList = MKUvrIkOkPLLOUkTnKTTJbRsfdqbA[UCVhYFBOxAAjDnQFvDKEAbIjboxlb[P_0.NbRmxdFYZoEWbZwIvPTkxVUiVMEJ]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				aList = MKUvrIkOkPLLOUkTnKTTJbRsfdqbA[aIqWCdeedTGtTcckrttVwtEabxSq];
			}
			int count = aList._count;
			if (FNwabXxOQgWekUgUagffflRvNmGn.Length < count)
			{
				FNwabXxOQgWekUgUagffflRvNmGn = new TLvAsxXXuLwkcAhTuCdGuWTKOPLp[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(aList._items, FNwabXxOQgWekUgUagffflRvNmGn, count);
			}
			for (int j = 0; j < count; j++)
			{
				TLvAsxXXuLwkcAhTuCdGuWTKOPLp tLvAsxXXuLwkcAhTuCdGuWTKOPLp = FNwabXxOQgWekUgUagffflRvNmGn[j];
				if (tLvAsxXXuLwkcAhTuCdGuWTKOPLp == null || (!P_0.vDuEWpwmyTspXxyQjAFUNHRQgojiA && !tLvAsxXXuLwkcAhTuCdGuWTKOPLp.DsSsdhDkRHQLCyrMNEnnnjmObcvdA) || tLvAsxXXuLwkcAhTuCdGuWTKOPLp.vPMgdLyqwzXiBPwfwMlTrOtzwkYS != P_1 || (tLvAsxXXuLwkcAhTuCdGuWTKOPLp.QSwfBuWMyCqhVFLpqZLELpSXOMDn >= 0 && tLvAsxXXuLwkcAhTuCdGuWTKOPLp.QSwfBuWMyCqhVFLpqZLELpSXOMDn != P_0.NbRmxdFYZoEWbZwIvPTkxVUiVMEJ))
				{
					continue;
				}
				bool flag = false;
				switch (tLvAsxXXuLwkcAhTuCdGuWTKOPLp.hqxzfELvcUxrIufdojstdPNWqfqO)
				{
				case InputActionEventType.Update:
					flag = true;
					break;
				case InputActionEventType.ButtonPressed:
					if (P_0.bboVUHBkbaSOWIdiLlywxyMWUUnP())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonUnpressed:
					if (!P_0.bboVUHBkbaSOWIdiLlywxyMWUUnP())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonDoublePressed:
				{
					tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(0, out var num5);
					if (P_0.ApZadUCrymGHNuAoYDoAgNoCOZeMA(num5))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonPressedForTime:
				{
					if (!tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(0, out var num11))
					{
						continue;
					}
					tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(1, out var num12);
					if (P_0.NaPCjdrIJcSfkZiikNdrmJAwjLAHA(num11, num12))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressed:
					if (P_0.zraMvrVyidNbGhjFGwgZujuZuXaU())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressed:
					if (P_0.giTXpMnAgicGmuBsPYIRxdDrTham())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustPressed:
					if (P_0.MVRdnxXGZCsBJEWZdnMOyOTlrrdu())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustReleased:
					if (P_0.UfRoNrLsJHhqSsAsVeuTJufLfJRFA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustDoublePressed:
				{
					tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(0, out var num9);
					if (P_0.DJzBbBuISPamiJudWtFJCaoGdPnJ(num9))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonDoublePressJustReleased:
				{
					tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(0, out var num6);
					if (P_0.tpXRjTJLkVEZEdTZpjFKkWSvzIHfA(num6))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustPressedForTime:
				{
					if (!tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(0, out var num4))
					{
						continue;
					}
					if (P_0.QLEKrtklSFifzxsxWvEETkrPBuAb(num4))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustShortPressed:
					if (P_0.dEQGvKELxDgVpXQGVhPDfgZSZMSU())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustLongPressed:
					if (P_0.UDfVaJDtQrhGOKciQpwVOCFQeTHE())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				{
					if (!tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(0, out var num15))
					{
						continue;
					}
					tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(1, out var num16);
					if (P_0.dXQEAMKAEsFutkqBjFbRclxBVvdJ(num15, num16))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressJustReleased:
					if (P_0.DJeBsuTLpsCVTRdNwinlenTthwUuA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressJustReleased:
					if (P_0.BiYEsqBWejuYrZgXseujMSiWCjnM())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonRepeating:
					if (P_0.XMDvGyhgdKGQIdcjGhtGyaBkOPiG())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressed:
					if (P_0.jDEDYlcVsDKQOgLXoPHwjvssMsLx())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustSinglePressed:
					if (P_0.lGFalaDqLWAcEovncHQOYVhwYsDh())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressJustReleased:
					if (P_0.tuXKlFxzwhWBmtiDmoXKHFdhhbgy())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressed:
					if (P_0.xGqLYAhmrlKApcDsGylXNoGhsHKJ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonUnpressed:
					if (!P_0.xGqLYAhmrlKApcDsGylXNoGhsHKJ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonDoublePressed:
				{
					tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(0, out var num3);
					if (P_0.heyGfqAPgFxDrCgfAbGoKLgXBHhFb(num3))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonPressedForTime:
				{
					if (!tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(0, out var num))
					{
						continue;
					}
					tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(1, out var num2);
					if (P_0.dYGtIpGbSsflWejomAvoduwnMjChA(num, num2))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressed:
					if (P_0.MpAFpCpNFUaOLyHVQiFYqaRwGzoe())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressed:
					if (P_0.myrlYebIerlIodVAiRhvRbLatyOD())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustPressed:
					if (P_0.zQqegsuPBZQcPDbgYgCvXbzrMSjA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustReleased:
					if (P_0.uYGNTCcasDFipFwcGgdlFErqqgJJ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustDoublePressed:
				{
					tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(0, out var num14);
					if (P_0.vSyntcCkHSgbfGmhBzBEOsmJGqnX(num14))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonDoublePressJustReleased:
				{
					tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(0, out var num13);
					if (P_0.RpzRrNGkLingEfckjyDKwxtspnaM(num13))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustPressedForTime:
				{
					if (!tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(0, out var num10))
					{
						continue;
					}
					if (P_0.AHrgyVdSLVlvnNQDoRnHGYJJpNNN(num10))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustShortPressed:
					if (P_0.CVtupeQxjEDuzxsvZVOrRmOvXdzG())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustLongPressed:
					if (P_0.UyimVoRwJsWgnMHvTcHJxZwEHMmW())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				{
					if (!tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(0, out var num7))
					{
						continue;
					}
					tLvAsxXXuLwkcAhTuCdGuWTKOPLp.VfQSlQAzSKqThmdQFJFoMHhaDSEJ(1, out var num8);
					if (P_0.vXonRjPEkrVikgyzgdXEYTvbdPWx(num7, num8))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressJustReleased:
					if (P_0.jWOqYvLJMLNeLLOzCODqOXPPFAnE())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressJustReleased:
					if (P_0.zsBxRASPJkUYKCmFixqRgRgzShLM())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonRepeating:
					if (P_0.KneBRatlfpcdHGsuxqXiuYPYithsA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressed:
					if (P_0.WUJMhQZeuqzfgCKfWsXMFupPmxfm())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustSinglePressed:
					if (P_0.eeXJZJVPbpcuVHGWOaKCSebvHxBCA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressJustReleased:
					if (P_0.mpdpbqFKATJtDTxpatBaDNKMCbMo())
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActive:
					if (!MathTools.ApproximatelyZero(P_0.vEPVoQqEOgbOhOGSJBikhSYMLdUiA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisInactive:
					if (MathTools.ApproximatelyZero(P_0.vEPVoQqEOgbOhOGSJBikhSYMLdUiA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActive:
					if (!MathTools.ApproximatelyZero(P_0.gQdCFfFDgtrNHvBHCVyIGNeWpcHOA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawInactive:
					if (MathTools.ApproximatelyZero(P_0.gQdCFfFDgtrNHvBHCVyIGNeWpcHOA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.vEPVoQqEOgbOhOGSJBikhSYMLdUiA()) || !MathTools.ApproximatelyZero(P_0.NpyCDcSwegLArthAMKSGhuXhkFop()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.gQdCFfFDgtrNHvBHCVyIGNeWpcHOA()) || !MathTools.ApproximatelyZero(P_0.lvZydZRdNFBODAntQjlArfmnHsfu()))
					{
						flag = true;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				try
				{
					if (flag)
					{
						InputActionEventData obj = P_0.rNDsHDXRuRsnCrxsuhKlcvIwMjqs(P_1);
						obj.eventType = tLvAsxXXuLwkcAhTuCdGuWTKOPLp.hqxzfELvcUxrIufdojstdPNWqfqO;
						tLvAsxXXuLwkcAhTuCdGuWTKOPLp.ZmOWbSEoKmjSNbDPTHRmCqVeLbcjB(obj);
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("Player input event callback", exception);
				}
			}
		}
	}

	public void dslcdUZyuborPJTKPkbaHctgVEOu(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!GoPOHhCuSCUSYnYhgahIgfjjgHzaA)
		{
			khpdILvTaVDrvJHYfmVFxFqULzgF();
		}
		TLvAsxXXuLwkcAhTuCdGuWTKOPLp item;
		try
		{
			if (P_3 > ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.RPEdjbfyfPTpgjWtQupiJpegXCdV)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new TLvAsxXXuLwkcAhTuCdGuWTKOPLp(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			MKUvrIkOkPLLOUkTnKTTJbRsfdqbA[aIqWCdeedTGtTcckrttVwtEabxSq].Add(item);
		}
		else
		{
			MKUvrIkOkPLLOUkTnKTTJbRsfdqbA[UCVhYFBOxAAjDnQFvDKEAbIjboxlb[P_3]].Add(item);
		}
		fnKztslLonfPOvDOoAvhGXPhTbZj();
	}

	public void FXRPNsAxptiUuekqvkJSTDgJsDyH(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!GoPOHhCuSCUSYnYhgahIgfjjgHzaA)
		{
			khpdILvTaVDrvJHYfmVFxFqULzgF();
		}
		TLvAsxXXuLwkcAhTuCdGuWTKOPLp item;
		try
		{
			item = new TLvAsxXXuLwkcAhTuCdGuWTKOPLp(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		MKUvrIkOkPLLOUkTnKTTJbRsfdqbA[aIqWCdeedTGtTcckrttVwtEabxSq].Add(item);
		fnKztslLonfPOvDOoAvhGXPhTbZj();
	}

	public void OvJdZelufiYiJTBHZZqEfUStzHvI(Action<InputActionEventData> P_0)
	{
		RlPntGVJuTqkTKGDhzHIMbdRpMgb rlPntGVJuTqkTKGDhzHIMbdRpMgb = new RlPntGVJuTqkTKGDhzHIMbdRpMgb();
		rlPntGVJuTqkTKGDhzHIMbdRpMgb.KqmarGbzMiTtgdKJHccoaFQOXKev = P_0;
		if (GoPOHhCuSCUSYnYhgahIgfjjgHzaA)
		{
			AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>[] mKUvrIkOkPLLOUkTnKTTJbRsfdqbA = MKUvrIkOkPLLOUkTnKTTJbRsfdqbA;
			for (int i = 0; i < mKUvrIkOkPLLOUkTnKTTJbRsfdqbA.Length; i++)
			{
				mKUvrIkOkPLLOUkTnKTTJbRsfdqbA[i].RemoveAll(rlPntGVJuTqkTKGDhzHIMbdRpMgb.fiuYzCLeYzMuUEqMcIBvcrOvHCVmA);
			}
			fnKztslLonfPOvDOoAvhGXPhTbZj();
		}
	}

	public void EnscmpHpZDiusYrPxENEcWoVHvPgb(Action<InputActionEventData> P_0, int P_1)
	{
		sksSyOYzJtFhNBHViVTSviUpVrht sksSyOYzJtFhNBHViVTSviUpVrht2 = new sksSyOYzJtFhNBHViVTSviUpVrht();
		sksSyOYzJtFhNBHViVTSviUpVrht2.LekUGnwcUxPlxieRTAErvJsICBWIA = P_0;
		sksSyOYzJtFhNBHViVTSviUpVrht2.BivExyVweRIcIVsTHoTpUXWCJuLS = P_1;
		if (GoPOHhCuSCUSYnYhgahIgfjjgHzaA && sksSyOYzJtFhNBHViVTSviUpVrht2.BivExyVweRIcIVsTHoTpUXWCJuLS <= ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.RPEdjbfyfPTpgjWtQupiJpegXCdV)
		{
			AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>[] mKUvrIkOkPLLOUkTnKTTJbRsfdqbA = MKUvrIkOkPLLOUkTnKTTJbRsfdqbA;
			for (int i = 0; i < mKUvrIkOkPLLOUkTnKTTJbRsfdqbA.Length; i++)
			{
				mKUvrIkOkPLLOUkTnKTTJbRsfdqbA[i].RemoveAll(sksSyOYzJtFhNBHViVTSviUpVrht2.MvRGiEalhLWRGUdemZsjcSejAniw);
			}
			fnKztslLonfPOvDOoAvhGXPhTbZj();
		}
	}

	public void KsuuHsKGJFymjEhHjpbFfXMQggji(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		PCJnUaCktuEhafOpKapSARiTYicLA pCJnUaCktuEhafOpKapSARiTYicLA = new PCJnUaCktuEhafOpKapSARiTYicLA();
		pCJnUaCktuEhafOpKapSARiTYicLA.tjWkfCBudDvNGCvDpwJzBYMbowgL = P_0;
		pCJnUaCktuEhafOpKapSARiTYicLA.rmsXExaQjYGNLtQICNsSNHMyrJhN = P_1;
		if (GoPOHhCuSCUSYnYhgahIgfjjgHzaA)
		{
			AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>[] mKUvrIkOkPLLOUkTnKTTJbRsfdqbA = MKUvrIkOkPLLOUkTnKTTJbRsfdqbA;
			for (int i = 0; i < mKUvrIkOkPLLOUkTnKTTJbRsfdqbA.Length; i++)
			{
				mKUvrIkOkPLLOUkTnKTTJbRsfdqbA[i].RemoveAll(pCJnUaCktuEhafOpKapSARiTYicLA.TgcDFndgORcgsoJQlLxodrNlkudEA);
			}
			fnKztslLonfPOvDOoAvhGXPhTbZj();
		}
	}

	public void RcEbJKEOEERJCKDGbLLzTkHkYqIiA(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		ZnHPReEKrSjeDiSVLuQLIblNVZu znHPReEKrSjeDiSVLuQLIblNVZu = new ZnHPReEKrSjeDiSVLuQLIblNVZu();
		znHPReEKrSjeDiSVLuQLIblNVZu.WXVEoJyNEKBzGFcCBCSzfjsGKKiS = P_0;
		znHPReEKrSjeDiSVLuQLIblNVZu.aYnvNHoIPszpQpUFoDlftebgClHZ = P_1;
		if (GoPOHhCuSCUSYnYhgahIgfjjgHzaA)
		{
			AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>[] mKUvrIkOkPLLOUkTnKTTJbRsfdqbA = MKUvrIkOkPLLOUkTnKTTJbRsfdqbA;
			for (int i = 0; i < mKUvrIkOkPLLOUkTnKTTJbRsfdqbA.Length; i++)
			{
				mKUvrIkOkPLLOUkTnKTTJbRsfdqbA[i].RemoveAll(znHPReEKrSjeDiSVLuQLIblNVZu.hdQpeFtMmIbogQSBhJwezRaUjpIN);
			}
			fnKztslLonfPOvDOoAvhGXPhTbZj();
		}
	}

	public void PmCfvqOBJUvQVZeByCFBKCjrJZNo(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		PhihWjkJxZgLQUqqIBEriIzseipQA phihWjkJxZgLQUqqIBEriIzseipQA = new PhihWjkJxZgLQUqqIBEriIzseipQA();
		phihWjkJxZgLQUqqIBEriIzseipQA.PjDIGSvZZfUNGgnhrNmTXbKfhucaA = P_0;
		phihWjkJxZgLQUqqIBEriIzseipQA.sZPeRNKsFlFptBbOhqJfjzpghMTrA = P_1;
		phihWjkJxZgLQUqqIBEriIzseipQA.sEWwhSskWqGBKfeSHwYdVUZRdrMP = P_2;
		if (GoPOHhCuSCUSYnYhgahIgfjjgHzaA && phihWjkJxZgLQUqqIBEriIzseipQA.sEWwhSskWqGBKfeSHwYdVUZRdrMP <= ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.RPEdjbfyfPTpgjWtQupiJpegXCdV)
		{
			AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>[] mKUvrIkOkPLLOUkTnKTTJbRsfdqbA = MKUvrIkOkPLLOUkTnKTTJbRsfdqbA;
			for (int i = 0; i < mKUvrIkOkPLLOUkTnKTTJbRsfdqbA.Length; i++)
			{
				mKUvrIkOkPLLOUkTnKTTJbRsfdqbA[i].RemoveAll(phihWjkJxZgLQUqqIBEriIzseipQA.uKFbMScXqabcYcnvGOnswjQFnTrMb);
			}
			fnKztslLonfPOvDOoAvhGXPhTbZj();
		}
	}

	public void RDotrlKdYSTNQcqtLuGpoyenksom(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		CWhsFZQLSuBRTGeFiJLFzdCNkCcH cWhsFZQLSuBRTGeFiJLFzdCNkCcH = new CWhsFZQLSuBRTGeFiJLFzdCNkCcH();
		cWhsFZQLSuBRTGeFiJLFzdCNkCcH.WnfNQTQkynrgIdXWrqPRtiuEtVQD = P_0;
		cWhsFZQLSuBRTGeFiJLFzdCNkCcH.DFnRkwCHFuPPcYhoiHpHJtKohCLIA = P_1;
		cWhsFZQLSuBRTGeFiJLFzdCNkCcH.xzXXUFFcSGDPmdUPTcKcRhzxDvQwA = P_3;
		cWhsFZQLSuBRTGeFiJLFzdCNkCcH.YHwHNdZBLujvBRNPAJAWpzzjCOdi = P_2;
		if (GoPOHhCuSCUSYnYhgahIgfjjgHzaA && cWhsFZQLSuBRTGeFiJLFzdCNkCcH.xzXXUFFcSGDPmdUPTcKcRhzxDvQwA <= ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.RPEdjbfyfPTpgjWtQupiJpegXCdV)
		{
			AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>[] mKUvrIkOkPLLOUkTnKTTJbRsfdqbA = MKUvrIkOkPLLOUkTnKTTJbRsfdqbA;
			for (int i = 0; i < mKUvrIkOkPLLOUkTnKTTJbRsfdqbA.Length; i++)
			{
				mKUvrIkOkPLLOUkTnKTTJbRsfdqbA[i].RemoveAll(cWhsFZQLSuBRTGeFiJLFzdCNkCcH.YRsKuujRylPdZiqJJLfyOzIOGVRD);
			}
			fnKztslLonfPOvDOoAvhGXPhTbZj();
		}
	}

	public void xiGrBvfurvjsERbymFdIgSkLrHJG(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		hULxIuOjkMhoHTmRETlunOqGlMkE hULxIuOjkMhoHTmRETlunOqGlMkE2 = new hULxIuOjkMhoHTmRETlunOqGlMkE();
		hULxIuOjkMhoHTmRETlunOqGlMkE2.SdfkLUfbUTJEzcWIQKAIGKMKoGrI = P_0;
		hULxIuOjkMhoHTmRETlunOqGlMkE2.bvKyBYZKQDOJiCvPqowQftzAfLoQ = P_1;
		hULxIuOjkMhoHTmRETlunOqGlMkE2.WkDIOWHWNTcqLamivIySEmnxaAEBA = P_2;
		if (GoPOHhCuSCUSYnYhgahIgfjjgHzaA)
		{
			AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>[] mKUvrIkOkPLLOUkTnKTTJbRsfdqbA = MKUvrIkOkPLLOUkTnKTTJbRsfdqbA;
			for (int i = 0; i < mKUvrIkOkPLLOUkTnKTTJbRsfdqbA.Length; i++)
			{
				mKUvrIkOkPLLOUkTnKTTJbRsfdqbA[i].RemoveAll(hULxIuOjkMhoHTmRETlunOqGlMkE2.dnREKWdUqcLcOFEYDDTzMZIPAshO);
			}
			fnKztslLonfPOvDOoAvhGXPhTbZj();
		}
	}

	public void nxvezEElFlvFkPIZstyupISlwvMt(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		IZCDCmjOWUDeMzbJOpJWcznlBdNlA iZCDCmjOWUDeMzbJOpJWcznlBdNlA = new IZCDCmjOWUDeMzbJOpJWcznlBdNlA();
		iZCDCmjOWUDeMzbJOpJWcznlBdNlA.fkLNBmstAtXWkLxiWqXMZyAxtMS = P_0;
		iZCDCmjOWUDeMzbJOpJWcznlBdNlA.HnzwoLHCOvGzQZFZiKlLZkfPSkIO = P_2;
		iZCDCmjOWUDeMzbJOpJWcznlBdNlA.UgERYrBPsnqkPtXAKyOhwmvIXulB = P_1;
		if (GoPOHhCuSCUSYnYhgahIgfjjgHzaA && iZCDCmjOWUDeMzbJOpJWcznlBdNlA.HnzwoLHCOvGzQZFZiKlLZkfPSkIO <= ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.RPEdjbfyfPTpgjWtQupiJpegXCdV)
		{
			AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>[] mKUvrIkOkPLLOUkTnKTTJbRsfdqbA = MKUvrIkOkPLLOUkTnKTTJbRsfdqbA;
			for (int i = 0; i < mKUvrIkOkPLLOUkTnKTTJbRsfdqbA.Length; i++)
			{
				mKUvrIkOkPLLOUkTnKTTJbRsfdqbA[i].RemoveAll(iZCDCmjOWUDeMzbJOpJWcznlBdNlA.NKaJSQmuEEePnwDbtVQqGirUpkIy);
			}
			fnKztslLonfPOvDOoAvhGXPhTbZj();
		}
	}

	public void sdFsKaMZIOqdefFgqdFZojKujCMU()
	{
		if (GoPOHhCuSCUSYnYhgahIgfjjgHzaA)
		{
			AList<TLvAsxXXuLwkcAhTuCdGuWTKOPLp>[] mKUvrIkOkPLLOUkTnKTTJbRsfdqbA = MKUvrIkOkPLLOUkTnKTTJbRsfdqbA;
			for (int i = 0; i < mKUvrIkOkPLLOUkTnKTTJbRsfdqbA.Length; i++)
			{
				mKUvrIkOkPLLOUkTnKTTJbRsfdqbA[i].Clear();
			}
			fnKztslLonfPOvDOoAvhGXPhTbZj();
		}
	}

	private void fnKztslLonfPOvDOoAvhGXPhTbZj()
	{
		int num = 0;
		for (int i = 0; i < MKUvrIkOkPLLOUkTnKTTJbRsfdqbA.Length; i++)
		{
			num += MKUvrIkOkPLLOUkTnKTTJbRsfdqbA[i]._count;
		}
		TfLmHoQfTGnihrPObIBtbLImFktSA = num;
	}
}
