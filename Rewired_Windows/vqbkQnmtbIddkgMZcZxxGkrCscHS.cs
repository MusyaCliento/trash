using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

internal static class vqbkQnmtbIddkgMZcZxxGkrCscHS
{
	private static Dictionary<IntPtr, List<iUOKRFlvAwYOJXRXDuDkDcalHVyA>> ZYAQSkowYuQHOnOiWhsUkGSkErNmA;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<iUOKRFlvAwYOJXRXDuDkDcalHVyA>> VpBXTFUDgQCesZiJFWYlqSgbVVZb;

	[CompilerGenerated]
	private static EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> m_DXxVsvlNbyNTyCRlAzmuqGmQiFuy;

	[CompilerGenerated]
	private static EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> m_AxdolJjAqQoFLVDqKmzmdzlDJmvI;

	private static Dictionary<IntPtr, List<iUOKRFlvAwYOJXRXDuDkDcalHVyA>> ELUqEsiCsqiDfMOXveuKaEedEZen
	{
		get
		{
			if (zbltnTmJrHLXSQFTwYJlZDBKJmVi.nyXqKJNHcTILwMFxOgswRBiFARmu)
			{
				if (VpBXTFUDgQCesZiJFWYlqSgbVVZb == null)
				{
					VpBXTFUDgQCesZiJFWYlqSgbVVZb = new Dictionary<IntPtr, List<iUOKRFlvAwYOJXRXDuDkDcalHVyA>>(KjLNFKfozEtdZTEpdywnuajaeQjGA.xYbKRzhekPUpXRBZadfWEpvxcCyM);
				}
				return VpBXTFUDgQCesZiJFWYlqSgbVVZb;
			}
			if (ZYAQSkowYuQHOnOiWhsUkGSkErNmA == null)
			{
				ZYAQSkowYuQHOnOiWhsUkGSkErNmA = new Dictionary<IntPtr, List<iUOKRFlvAwYOJXRXDuDkDcalHVyA>>(KjLNFKfozEtdZTEpdywnuajaeQjGA.xYbKRzhekPUpXRBZadfWEpvxcCyM);
			}
			return ZYAQSkowYuQHOnOiWhsUkGSkErNmA;
		}
	}

	public static event EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> DXxVsvlNbyNTyCRlAzmuqGmQiFuy
	{
		[CompilerGenerated]
		add
		{
			EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> eventHandler = vqbkQnmtbIddkgMZcZxxGkrCscHS.m_DXxVsvlNbyNTyCRlAzmuqGmQiFuy;
			EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> value2 = (EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref vqbkQnmtbIddkgMZcZxxGkrCscHS.m_DXxVsvlNbyNTyCRlAzmuqGmQiFuy, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> eventHandler = vqbkQnmtbIddkgMZcZxxGkrCscHS.m_DXxVsvlNbyNTyCRlAzmuqGmQiFuy;
			EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> value2 = (EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref vqbkQnmtbIddkgMZcZxxGkrCscHS.m_DXxVsvlNbyNTyCRlAzmuqGmQiFuy, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> AxdolJjAqQoFLVDqKmzmdzlDJmvI
	{
		[CompilerGenerated]
		add
		{
			EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> eventHandler = vqbkQnmtbIddkgMZcZxxGkrCscHS.m_AxdolJjAqQoFLVDqKmzmdzlDJmvI;
			EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> value2 = (EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref vqbkQnmtbIddkgMZcZxxGkrCscHS.m_AxdolJjAqQoFLVDqKmzmdzlDJmvI, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> eventHandler = vqbkQnmtbIddkgMZcZxxGkrCscHS.m_AxdolJjAqQoFLVDqKmzmdzlDJmvI;
			EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm> value2 = (EventHandler<AuSGnSoumzBWGVlXmWeUqzDZhDKm>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref vqbkQnmtbIddkgMZcZxxGkrCscHS.m_AxdolJjAqQoFLVDqKmzmdzlDJmvI, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	static vqbkQnmtbIddkgMZcZxxGkrCscHS()
	{
		AppDomain.CurrentDomain.DomainUnload += fWKUFBJpncsQtmZTCgdraGzcSUmj;
		AppDomain.CurrentDomain.ProcessExit += fWKUFBJpncsQtmZTCgdraGzcSUmj;
	}

	private static void fWKUFBJpncsQtmZTCgdraGzcSUmj(object P_0, EventArgs P_1)
	{
		if (zbltnTmJrHLXSQFTwYJlZDBKJmVi.GxUIToeWdwsidtqBkQWInvhPJqaY)
		{
			string value = jTnbEYkOcIlYZAVmhlfjErIbPEWc();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	public static void YwvgmQCNQTAPIDeaPdZgzCLPYAVJA(JEPfEYCraEjyIblcOXJPfjvhhVibb P_0)
	{
		if (P_0 == null || P_0.jZMLhMmNWgZQKiIdvGxNhEuSjsYr == IntPtr.Zero)
		{
			return;
		}
		lock (ELUqEsiCsqiDfMOXveuKaEedEZen)
		{
			if (!ELUqEsiCsqiDfMOXveuKaEedEZen.TryGetValue(P_0.jZMLhMmNWgZQKiIdvGxNhEuSjsYr, out var value))
			{
				value = new List<iUOKRFlvAwYOJXRXDuDkDcalHVyA>();
				ELUqEsiCsqiDfMOXveuKaEedEZen.Add(P_0.jZMLhMmNWgZQKiIdvGxNhEuSjsYr, value);
			}
			StringBuilder stringBuilder = new StringBuilder();
			StackFrame[] frames = new StackTrace(3, fNeedFileInfo: true).GetFrames();
			foreach (StackFrame stackFrame in frames)
			{
				if (stackFrame.GetFileLineNumber() != 0)
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "\t{0}({1},{2}) : {3}", stackFrame.GetFileName(), stackFrame.GetFileLineNumber(), stackFrame.GetFileColumnNumber(), stackFrame.GetMethod()).AppendLine();
				}
			}
			value.Add(new iUOKRFlvAwYOJXRXDuDkDcalHVyA(DateTime.Now, P_0, stringBuilder.ToString()));
			fthDXGdjOPrZStUvnSEVOQxFejUOA(P_0);
		}
	}

	public static List<iUOKRFlvAwYOJXRXDuDkDcalHVyA> GAkDWRhMlgeXEVzuvdSPIXIsWRHbA(IntPtr P_0)
	{
		lock (ELUqEsiCsqiDfMOXveuKaEedEZen)
		{
			if (ELUqEsiCsqiDfMOXveuKaEedEZen.TryGetValue(P_0, out var value))
			{
				return new List<iUOKRFlvAwYOJXRXDuDkDcalHVyA>(value);
			}
		}
		return new List<iUOKRFlvAwYOJXRXDuDkDcalHVyA>();
	}

	public static iUOKRFlvAwYOJXRXDuDkDcalHVyA kwChcJECoJSnsrWmRVuySWzcOiRSA(JEPfEYCraEjyIblcOXJPfjvhhVibb P_0)
	{
		lock (ELUqEsiCsqiDfMOXveuKaEedEZen)
		{
			if (ELUqEsiCsqiDfMOXveuKaEedEZen.TryGetValue(P_0.jZMLhMmNWgZQKiIdvGxNhEuSjsYr, out var value))
			{
				foreach (iUOKRFlvAwYOJXRXDuDkDcalHVyA item in value)
				{
					if (item.sDJdNtjQBmHruHMouZZyMUcIyxWdA.Target == P_0)
					{
						return item;
					}
				}
			}
		}
		return null;
	}

	public static void YtLURWlUuZDKgYbTVxwwJpzleJaq(JEPfEYCraEjyIblcOXJPfjvhhVibb P_0)
	{
		if (P_0 == null || P_0.jZMLhMmNWgZQKiIdvGxNhEuSjsYr == IntPtr.Zero)
		{
			return;
		}
		lock (ELUqEsiCsqiDfMOXveuKaEedEZen)
		{
			if (!ELUqEsiCsqiDfMOXveuKaEedEZen.TryGetValue(P_0.jZMLhMmNWgZQKiIdvGxNhEuSjsYr, out var value))
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				iUOKRFlvAwYOJXRXDuDkDcalHVyA iUOKRFlvAwYOJXRXDuDkDcalHVyA2 = value[num];
				if (iUOKRFlvAwYOJXRXDuDkDcalHVyA2.sDJdNtjQBmHruHMouZZyMUcIyxWdA.Target == P_0)
				{
					value.RemoveAt(num);
				}
				else if (!iUOKRFlvAwYOJXRXDuDkDcalHVyA2.rIzYTfZOXAgiADKrQNcdvBnBePyx)
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				ELUqEsiCsqiDfMOXveuKaEedEZen.Remove(P_0.jZMLhMmNWgZQKiIdvGxNhEuSjsYr);
			}
			wVqiGCbMeXGWCfqaEjzDsKkhVtPhA(P_0);
		}
	}

	public static List<iUOKRFlvAwYOJXRXDuDkDcalHVyA> zcXrsapKakFgTwvuRlAgmYMJblXs()
	{
		List<iUOKRFlvAwYOJXRXDuDkDcalHVyA> list = new List<iUOKRFlvAwYOJXRXDuDkDcalHVyA>();
		lock (ELUqEsiCsqiDfMOXveuKaEedEZen)
		{
			foreach (List<iUOKRFlvAwYOJXRXDuDkDcalHVyA> value in ELUqEsiCsqiDfMOXveuKaEedEZen.Values)
			{
				foreach (iUOKRFlvAwYOJXRXDuDkDcalHVyA item in value)
				{
					if (item.rIzYTfZOXAgiADKrQNcdvBnBePyx)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
	}

	public static string jTnbEYkOcIlYZAVmhlfjErIbPEWc()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (iUOKRFlvAwYOJXRXDuDkDcalHVyA item in zcXrsapKakFgTwvuRlAgmYMJblXs())
		{
			string text = item.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendFormat("[{0}]: {1}", num, text);
				object target = item.sDJdNtjQBmHruHMouZZyMUcIyxWdA.Target;
				if (target != null)
				{
					string name = target.GetType().Name;
					if (!dictionary.TryGetValue(name, out var value))
					{
						dictionary[name] = 0;
					}
					dictionary[name] = value + 1;
				}
			}
			num++;
		}
		List<string> list = new List<string>(dictionary.Keys);
		list.Sort();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Count per Type:");
		foreach (string item2 in list)
		{
			stringBuilder.AppendFormat("{0} : {1}", item2, dictionary[item2]);
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	private static void fthDXGdjOPrZStUvnSEVOQxFejUOA(JEPfEYCraEjyIblcOXJPfjvhhVibb P_0)
	{
		vqbkQnmtbIddkgMZcZxxGkrCscHS.DXxVsvlNbyNTyCRlAzmuqGmQiFuy?.Invoke(null, new AuSGnSoumzBWGVlXmWeUqzDZhDKm(P_0));
	}

	private static void wVqiGCbMeXGWCfqaEjzDsKkhVtPhA(JEPfEYCraEjyIblcOXJPfjvhhVibb P_0)
	{
		vqbkQnmtbIddkgMZcZxxGkrCscHS.AxdolJjAqQoFLVDqKmzmdzlDJmvI?.Invoke(null, new AuSGnSoumzBWGVlXmWeUqzDZhDKm(P_0));
	}
}
