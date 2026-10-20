using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal static class tgqynBNYAnPNLErShOOCGJUqEsYh
{
	[CustomObfuscation(rename = false)]
	public delegate void EventFunction<T, TArgs>(T handler, TArgs value) where T : class;

	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public class HierarchyEventHelper<THandler, TValue> where THandler : class
	{
		[Flags]
		public enum fNrDQWJTTFkSLGaCunMyHVBCVYZbc
		{
			None = 0,
			Self = 1,
			Children = 4,
			Parents = 8,
			All = -1
		}

		private readonly EventFunction<THandler, TValue> BsfExaurMWYupRjxewapjnzteHTI;

		private readonly List<THandler> SaoTNrtcMaupPnstDAQQgMOnaGKB;

		private readonly fNrDQWJTTFkSLGaCunMyHVBCVYZbc VtGOqaSMsXhNrsnDMqYlUseAGSey;

		public HierarchyEventHelper(EventFunction<THandler, TValue> P_0)
			: this(P_0, fNrDQWJTTFkSLGaCunMyHVBCVYZbc.Self | fNrDQWJTTFkSLGaCunMyHVBCVYZbc.Children)
		{
		}

		public HierarchyEventHelper(EventFunction<THandler, TValue> P_0, fNrDQWJTTFkSLGaCunMyHVBCVYZbc P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("delegate");
			}
			BsfExaurMWYupRjxewapjnzteHTI = P_0;
			SaoTNrtcMaupPnstDAQQgMOnaGKB = new List<THandler>();
			VtGOqaSMsXhNrsnDMqYlUseAGSey = P_1;
		}

		public void ExecuteOnAll(TValue value)
		{
			IhZuKakgUySHisEhydMIjeRxBSzHA(SaoTNrtcMaupPnstDAQQgMOnaGKB, value, BsfExaurMWYupRjxewapjnzteHTI, true);
		}

		public void GetHandlers(Transform transform)
		{
			if ((VtGOqaSMsXhNrsnDMqYlUseAGSey & fNrDQWJTTFkSLGaCunMyHVBCVYZbc.Self) != fNrDQWJTTFkSLGaCunMyHVBCVYZbc.None && (VtGOqaSMsXhNrsnDMqYlUseAGSey & fNrDQWJTTFkSLGaCunMyHVBCVYZbc.Children) != fNrDQWJTTFkSLGaCunMyHVBCVYZbc.None && (VtGOqaSMsXhNrsnDMqYlUseAGSey & fNrDQWJTTFkSLGaCunMyHVBCVYZbc.Parents) != fNrDQWJTTFkSLGaCunMyHVBCVYZbc.None)
			{
				UnityTools.GetComponentsInSelfAndChildren(transform.root, SaoTNrtcMaupPnstDAQQgMOnaGKB, append: false);
				return;
			}
			if ((VtGOqaSMsXhNrsnDMqYlUseAGSey & fNrDQWJTTFkSLGaCunMyHVBCVYZbc.Children) != fNrDQWJTTFkSLGaCunMyHVBCVYZbc.None)
			{
				if ((VtGOqaSMsXhNrsnDMqYlUseAGSey & fNrDQWJTTFkSLGaCunMyHVBCVYZbc.Self) != fNrDQWJTTFkSLGaCunMyHVBCVYZbc.None)
				{
					UnityTools.GetComponentsInSelfAndChildren(transform, SaoTNrtcMaupPnstDAQQgMOnaGKB, append: true);
				}
				else
				{
					UnityTools.GetComponents(transform, SaoTNrtcMaupPnstDAQQgMOnaGKB, append: true);
				}
			}
			if ((VtGOqaSMsXhNrsnDMqYlUseAGSey & fNrDQWJTTFkSLGaCunMyHVBCVYZbc.Parents) != fNrDQWJTTFkSLGaCunMyHVBCVYZbc.None)
			{
				UnityTools.GetComponentsInParents(transform, SaoTNrtcMaupPnstDAQQgMOnaGKB, append: true);
			}
		}
	}

	public static void YywLxPBkBOQErJYKpbZPyGphwBQW<_0001, _0002>(_0001 P_0, _0002 P_1, EventFunction<_0001, _0002> P_2) where _0001 : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("handler");
		}
		try
		{
			P_2(P_0, P_1);
		}
		catch (Exception ex)
		{
			Rewired.Logger.LogError("Caught exception in event handler:\n" + ex);
		}
	}

	public static void oNdUAyKNxbROoqqlspdChnHGqSZw<_0001, _0002>(IList<_0001> P_0, _0002 P_1, EventFunction<_0001, _0002> P_2) where _0001 : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("handlers");
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null)
			{
				try
				{
					P_2(val, P_1);
				}
				catch (Exception ex)
				{
					Rewired.Logger.LogError("Caught exception in event handler:\n" + ex);
				}
			}
		}
	}

	public static void IhZuKakgUySHisEhydMIjeRxBSzHA<_0001, _0002>(IList<_0001> P_0, _0002 P_1, EventFunction<_0001, _0002> P_2, bool P_3) where _0001 : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("handlers");
		}
		int num = P_0.Count;
		for (int i = 0; i < num; i++)
		{
			_0001 val = P_0[i];
			if (val as Component == null)
			{
				if (P_3)
				{
					P_0.RemoveAt(i);
					i--;
					num--;
				}
			}
			else
			{
				try
				{
					P_2(val, P_1);
				}
				catch (Exception ex)
				{
					Rewired.Logger.LogError("Caught exception in event handler:\n" + ex);
				}
			}
		}
	}
}
