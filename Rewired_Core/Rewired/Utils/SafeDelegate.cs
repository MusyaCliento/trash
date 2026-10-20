using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> kMANSQDpbmeyFDQcQnMNmuAgBjBJb;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return kMANSQDpbmeyFDQcQnMNmuAgBjBJb;
			}
			set
			{
				kMANSQDpbmeyFDQcQnMNmuAgBjBJb = value;
			}
		}

		internal abstract void RemoveDelegateOrAllDelegatesFromAnObject(object obj);

		internal abstract void Clear();

		public abstract object Clone();
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate<T> : SafeDelegate where T : class
	{
		private class JiAfLwRccrVBVKnXmsHLtwxyDpNh
		{
			public readonly T FofkCWQZqcjkBmcHKHKHJeSlfpFxA;

			public readonly object LPzdYkLrhSsICNNlVaRlHCLumAoB;

			public readonly object ebLyRuQdvpRYnXBjKCzCchiVlYME;

			public readonly bool BVpRvoLWSelXJKlJrkPgDogBbnqK;

			public JiAfLwRccrVBVKnXmsHLtwxyDpNh(T P_0)
			{
				FofkCWQZqcjkBmcHKHKHJeSlfpFxA = P_0;
				LPzdYkLrhSsICNNlVaRlHCLumAoB = ((Delegate)(object)P_0).Target;
				try
				{
					ebLyRuQdvpRYnXBjKCzCchiVlYME = ReflectionTools.GetMethodInfo((Delegate)(object)P_0);
				}
				catch
				{
					ebLyRuQdvpRYnXBjKCzCchiVlYME = null;
				}
				BVpRvoLWSelXJKlJrkPgDogBbnqK = LPzdYkLrhSsICNNlVaRlHCLumAoB != null && LPzdYkLrhSsICNNlVaRlHCLumAoB is UnityEngine.Object;
			}

			public JiAfLwRccrVBVKnXmsHLtwxyDpNh(JiAfLwRccrVBVKnXmsHLtwxyDpNh P_0)
				: this(MiscTools.Clone((object)P_0.FofkCWQZqcjkBmcHKHKHJeSlfpFxA) as T)
			{
			}

			public bool fNreHCVvxbyztNNXfkjfbafrpcSj()
			{
				if (LPzdYkLrhSsICNNlVaRlHCLumAoB != null)
				{
					if (LPzdYkLrhSsICNNlVaRlHCLumAoB is UnityEngine.Object)
					{
						return (UnityEngine.Object)LPzdYkLrhSsICNNlVaRlHCLumAoB == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> CYSQGHsIDKeJlaGAajyMypwlLKtqA;

		private readonly List<JiAfLwRccrVBVKnXmsHLtwxyDpNh> xiCWpKazfjgqOotcLUZxNAOmUpIC;

		private readonly List<JiAfLwRccrVBVKnXmsHLtwxyDpNh> dLocfQcSTHbnkwjnXnViMqoRJeSeA;

		int SafeDelegate.Count => xiCWpKazfjgqOotcLUZxNAOmUpIC.Count;

		Action<Exception> SafeDelegate.ExceptionHandler
		{
			get
			{
				return CYSQGHsIDKeJlaGAajyMypwlLKtqA;
			}
			set
			{
				CYSQGHsIDKeJlaGAajyMypwlLKtqA = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			xiCWpKazfjgqOotcLUZxNAOmUpIC = new List<JiAfLwRccrVBVKnXmsHLtwxyDpNh>();
			dLocfQcSTHbnkwjnXnViMqoRJeSeA = new List<JiAfLwRccrVBVKnXmsHLtwxyDpNh>();
			if (CYSQGHsIDKeJlaGAajyMypwlLKtqA == null)
			{
				CYSQGHsIDKeJlaGAajyMypwlLKtqA = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			CYSQGHsIDKeJlaGAajyMypwlLKtqA = P_0;
		}

		protected SafeDelegate(SafeDelegate<T> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (P_0.CYSQGHsIDKeJlaGAajyMypwlLKtqA != null)
			{
				CYSQGHsIDKeJlaGAajyMypwlLKtqA = P_0.CYSQGHsIDKeJlaGAajyMypwlLKtqA;
			}
			for (int i = 0; i < P_0.xiCWpKazfjgqOotcLUZxNAOmUpIC.Count; i++)
			{
				xiCWpKazfjgqOotcLUZxNAOmUpIC.Add(new JiAfLwRccrVBVKnXmsHLtwxyDpNh(P_0.xiCWpKazfjgqOotcLUZxNAOmUpIC[i]));
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = FOSpuhATuoMaygvJUGsdyafogqxf((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				T val = (T)(object)list[i];
				if (!xlClgycJSbnFEkHmUIZpCqxxwWLjA(val))
				{
					xiCWpKazfjgqOotcLUZxNAOmUpIC.Add(new JiAfLwRccrVBVKnXmsHLtwxyDpNh(val));
				}
			}
		}

		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = FOSpuhATuoMaygvJUGsdyafogqxf((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = xiCWpKazfjgqOotcLUZxNAOmUpIC.Count;
			for (int i = 0; i < list.Count; i++)
			{
				for (int num = count - 1; num >= 0; num--)
				{
					if (EqualityComparer<T>.Default.Equals(xiCWpKazfjgqOotcLUZxNAOmUpIC[num].FofkCWQZqcjkBmcHKHKHJeSlfpFxA, (T)(object)list[i]))
					{
						xiCWpKazfjgqOotcLUZxNAOmUpIC.RemoveAt(num);
					}
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			for (int num = xiCWpKazfjgqOotcLUZxNAOmUpIC.Count - 1; num >= 0; num--)
			{
				Delegate obj2 = WVWWOwQlUNLUWZHFnHQyiaNcdjtnA(obj, (Delegate)(object)xiCWpKazfjgqOotcLUZxNAOmUpIC[num].FofkCWQZqcjkBmcHKHKHJeSlfpFxA);
				if (RUMCpUoDiruivdKqzCAOekKVlebB(obj2) == 0)
				{
					xiCWpKazfjgqOotcLUZxNAOmUpIC.RemoveAt(num);
				}
				else
				{
					xiCWpKazfjgqOotcLUZxNAOmUpIC[num] = new JiAfLwRccrVBVKnXmsHLtwxyDpNh((T)(object)obj2);
				}
			}
		}

		internal override void Clear()
		{
			xiCWpKazfjgqOotcLUZxNAOmUpIC.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			int count = xiCWpKazfjgqOotcLUZxNAOmUpIC.Count;
			if (count == 0)
			{
				return;
			}
			dLocfQcSTHbnkwjnXnViMqoRJeSeA.Clear();
			for (int i = 0; i < count; i++)
			{
				dLocfQcSTHbnkwjnXnViMqoRJeSeA.Add(xiCWpKazfjgqOotcLUZxNAOmUpIC[i]);
			}
			List<int> list = null;
			for (int j = 0; j < count; j++)
			{
				JiAfLwRccrVBVKnXmsHLtwxyDpNh jiAfLwRccrVBVKnXmsHLtwxyDpNh = dLocfQcSTHbnkwjnXnViMqoRJeSeA[j];
				if (jiAfLwRccrVBVKnXmsHLtwxyDpNh.BVpRvoLWSelXJKlJrkPgDogBbnqK && jiAfLwRccrVBVKnXmsHLtwxyDpNh.fNreHCVvxbyztNNXfkjfbafrpcSj())
				{
					if (list == null)
					{
						list = TempListPool.Get<int>();
					}
					list.Add(j);
					continue;
				}
				try
				{
					invokeCallback(this, jiAfLwRccrVBVKnXmsHLtwxyDpNh.FofkCWQZqcjkBmcHKHKHJeSlfpFxA);
				}
				catch (Exception ex)
				{
					if (CYSQGHsIDKeJlaGAajyMypwlLKtqA != null)
					{
						CYSQGHsIDKeJlaGAajyMypwlLKtqA(ex);
					}
					else if (ex.InnerException != null)
					{
						Logger.LogError(ex.InnerException, requiredThreadSafety: true);
					}
					if (list == null)
					{
						list = TempListPool.Get<int>();
					}
					list.Add(j);
				}
			}
			if (list != null)
			{
				for (int num = list.Count - 1; num >= 0; num--)
				{
					xiCWpKazfjgqOotcLUZxNAOmUpIC.RemoveAt(list[num]);
				}
				TempListPool.Return(list);
			}
			if (count > 0)
			{
				dLocfQcSTHbnkwjnXnViMqoRJeSeA.Clear();
			}
		}

		protected T GetCombinedDelegate()
		{
			if (xiCWpKazfjgqOotcLUZxNAOmUpIC == null)
			{
				return null;
			}
			T val = null;
			for (int i = 0; i < xiCWpKazfjgqOotcLUZxNAOmUpIC.Count; i++)
			{
				T fofkCWQZqcjkBmcHKHKHJeSlfpFxA = xiCWpKazfjgqOotcLUZxNAOmUpIC[i].FofkCWQZqcjkBmcHKHKHJeSlfpFxA;
				if (val == null)
				{
					val = fofkCWQZqcjkBmcHKHKHJeSlfpFxA;
					continue;
				}
				try
				{
					val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)fofkCWQZqcjkBmcHKHKHJeSlfpFxA);
				}
				catch
				{
				}
			}
			return val;
		}

		private bool xlClgycJSbnFEkHmUIZpCqxxwWLjA(T P_0)
		{
			return yHMcSykvSoCtzHisJsScnCaKmkDoA(P_0) >= 0;
		}

		private int yHMcSykvSoCtzHisJsScnCaKmkDoA(T P_0)
		{
			int count = xiCWpKazfjgqOotcLUZxNAOmUpIC.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(xiCWpKazfjgqOotcLUZxNAOmUpIC[i].FofkCWQZqcjkBmcHKHKHJeSlfpFxA, P_0))
				{
					return i;
				}
			}
			return -1;
		}

		private static Delegate WVWWOwQlUNLUWZHFnHQyiaNcdjtnA(object P_0, Delegate P_1)
		{
			if ((object)P_1 == null || P_0 == null)
			{
				return P_1;
			}
			if (P_0 is Delegate)
			{
				return XkckmxznQUIvURqyZibMxattLDlS((Delegate)P_0, P_1);
			}
			try
			{
				Delegate[] invocationList = P_1.GetInvocationList();
				for (int i = 0; i < invocationList.Length; i++)
				{
					if (invocationList[i].Target == P_0 || ReflectionTools.GetMethodInfo(invocationList[i]) == P_0)
					{
						if ((object)P_1 == null)
						{
							return P_1;
						}
						P_1 = Delegate.RemoveAll(P_1, invocationList[i]);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("Exception caught while removing delegates from list (1):\n" + ex);
			}
			return P_1;
		}

		private static Delegate XkckmxznQUIvURqyZibMxattLDlS(Delegate P_0, Delegate P_1)
		{
			if ((object)P_0 == null || (object)P_1 == null)
			{
				return P_1;
			}
			if ((object)P_0.GetType() != P_0.GetType())
			{
				return P_1;
			}
			try
			{
				Delegate[] invocationList = P_0.GetInvocationList();
				Delegate[] invocationList2 = P_1.GetInvocationList();
				for (int i = 0; i < invocationList.Length; i++)
				{
					object methodInfo = ReflectionTools.GetMethodInfo(invocationList[i]);
					foreach (Delegate obj in invocationList2)
					{
						object methodInfo2 = ReflectionTools.GetMethodInfo(obj);
						if (methodInfo == methodInfo2)
						{
							if ((object)P_1 == null)
							{
								return P_1;
							}
							P_1 = Delegate.RemoveAll(P_1, obj);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("Exception caught while removing delegates from list (2):\n" + ex);
			}
			return P_1;
		}

		private static int RUMCpUoDiruivdKqzCAOekKVlebB(Delegate P_0)
		{
			if ((object)P_0 == null)
			{
				return 0;
			}
			Delegate[] invocationList = P_0.GetInvocationList();
			if (invocationList == null)
			{
				return 0;
			}
			return invocationList.Length;
		}

		private static List<Delegate> FOSpuhATuoMaygvJUGsdyafogqxf(Delegate P_0)
		{
			if ((object)P_0 == null)
			{
				return null;
			}
			Delegate[] invocationList = P_0.GetInvocationList();
			if (invocationList == null)
			{
				return null;
			}
			List<Delegate> list = new List<Delegate>(invocationList.Length);
			for (int i = 0; i < invocationList.Length; i++)
			{
				list.Add(invocationList[i]);
			}
			return list;
		}
	}
}
