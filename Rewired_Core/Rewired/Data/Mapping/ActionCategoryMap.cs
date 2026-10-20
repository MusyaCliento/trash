using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class ActionCategoryMap
	{
		[Serializable]
		public class Entry
		{
			private sealed class IyJspVXdkXmleKzbgRphJJoZgmQaA : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
			{
				private int NYqbjlIcwNHpBDdyowlaWApKWsUw;

				private int XkdgepZlSaHeEqOBbhCngZLOggNU;

				private int aDHpmMJUfAcIrzzcwraMAIgzWlFf;

				public Entry nQKZLnlXmHcwslLtqoNOvaPWYgeP;

				private int MxjjcPoCIDfVpIaHAOqhcPbGBhxz;

				int IEnumerator<int>.Current
				{
					[DebuggerHidden]
					get
					{
						return XkdgepZlSaHeEqOBbhCngZLOggNU;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return XkdgepZlSaHeEqOBbhCngZLOggNU;
					}
				}

				[DebuggerHidden]
				public IyJspVXdkXmleKzbgRphJJoZgmQaA(int P_0)
				{
					NYqbjlIcwNHpBDdyowlaWApKWsUw = P_0;
					aDHpmMJUfAcIrzzcwraMAIgzWlFf = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					NYqbjlIcwNHpBDdyowlaWApKWsUw = -2;
				}

				private bool MoveNext()
				{
					int nYqbjlIcwNHpBDdyowlaWApKWsUw = NYqbjlIcwNHpBDdyowlaWApKWsUw;
					Entry entry = nQKZLnlXmHcwslLtqoNOvaPWYgeP;
					switch (nYqbjlIcwNHpBDdyowlaWApKWsUw)
					{
					default:
						return false;
					case 0:
						NYqbjlIcwNHpBDdyowlaWApKWsUw = -1;
						if (entry.actionIds == null)
						{
							return false;
						}
						MxjjcPoCIDfVpIaHAOqhcPbGBhxz = 0;
						break;
					case 1:
						NYqbjlIcwNHpBDdyowlaWApKWsUw = -1;
						MxjjcPoCIDfVpIaHAOqhcPbGBhxz++;
						break;
					}
					if (MxjjcPoCIDfVpIaHAOqhcPbGBhxz < entry.actionIds.Count)
					{
						XkdgepZlSaHeEqOBbhCngZLOggNU = entry.actionIds[MxjjcPoCIDfVpIaHAOqhcPbGBhxz];
						NYqbjlIcwNHpBDdyowlaWApKWsUw = 1;
						return true;
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
				IEnumerator<int> IEnumerable<int>.GetEnumerator()
				{
					IyJspVXdkXmleKzbgRphJJoZgmQaA iyJspVXdkXmleKzbgRphJJoZgmQaA;
					if (NYqbjlIcwNHpBDdyowlaWApKWsUw == -2 && aDHpmMJUfAcIrzzcwraMAIgzWlFf == Environment.CurrentManagedThreadId)
					{
						NYqbjlIcwNHpBDdyowlaWApKWsUw = 0;
						iyJspVXdkXmleKzbgRphJJoZgmQaA = this;
					}
					else
					{
						iyJspVXdkXmleKzbgRphJJoZgmQaA = new IyJspVXdkXmleKzbgRphJJoZgmQaA(0);
						iyJspVXdkXmleKzbgRphJJoZgmQaA.nQKZLnlXmHcwslLtqoNOvaPWYgeP = nQKZLnlXmHcwslLtqoNOvaPWYgeP;
					}
					return iyJspVXdkXmleKzbgRphJJoZgmQaA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<int>)this).GetEnumerator();
				}
			}

			public int categoryId;

			public List<int> actionIds;

			public IEnumerable<int> ActionIds
			{
				[IteratorStateMachine(typeof(IyJspVXdkXmleKzbgRphJJoZgmQaA))]
				get
				{
					return new IyJspVXdkXmleKzbgRphJJoZgmQaA(-2)
					{
						nQKZLnlXmHcwslLtqoNOvaPWYgeP = this
					};
				}
			}

			public Entry()
			{
				actionIds = new List<int>();
			}

			public Entry(int P_0)
				: this()
			{
				categoryId = P_0;
			}

			public Entry(Entry P_0)
			{
				actionIds = ListTools.ShallowCopy(P_0.actionIds);
			}

			public void AddAction(int actionId)
			{
				if (!actionIds.Contains(actionId))
				{
					actionIds.Add(actionId);
				}
			}

			public bool InsertAction(int actionId, int index)
			{
				if (index < 0)
				{
					return false;
				}
				if (actionIds.Contains(actionId))
				{
					return true;
				}
				if (index >= actionIds.Count)
				{
					actionIds.Add(actionId);
				}
				else
				{
					actionIds.Insert(index, actionId);
				}
				return true;
			}

			public bool ReorderAction(int actionId, bool offsetDown, bool offsetNow)
			{
				int num = IndexOfAction(actionId);
				if (num < 0)
				{
					return false;
				}
				if (!offsetDown && num == 0)
				{
					return false;
				}
				if (offsetDown && num >= actionIds.Count - 1)
				{
					return false;
				}
				if (!offsetNow)
				{
					return true;
				}
				int value = actionIds[num];
				if (offsetDown)
				{
					actionIds[num] = actionIds[num + 1];
					actionIds[num + 1] = value;
				}
				else
				{
					actionIds[num] = actionIds[num - 1];
					actionIds[num - 1] = value;
				}
				return true;
			}

			public void RemoveAction(int actionId)
			{
				int num = IndexOfAction(actionId);
				if (num >= 0)
				{
					actionIds.RemoveAt(num);
				}
			}

			public int IndexOfAction(int id)
			{
				if (actionIds == null)
				{
					return -1;
				}
				for (int i = 0; i < actionIds.Count; i++)
				{
					if (actionIds[i] == id)
					{
						return i;
					}
				}
				return -1;
			}

			public bool ContainsAction(int id)
			{
				return IndexOfAction(id) >= 0;
			}

			public Entry Clone()
			{
				return new Entry(this);
			}
		}

		private sealed class CSKopvXpRHVfxKcFFhNyeOSkKbSGA : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int noZrXSDCENksKeyBDiDXMSrCuiBW;

			private int xHZfDgFcZeIxmFYZdhjlmrCchxiTe;

			private int PQCMMVpVGMJaHpowuLmVVMjxnHSM;

			public ActionCategoryMap cOsmnFCJJmbOBDRZgNfbjgNHiHyKb;

			private int wuGjWJeXNRAYRrbaBoKKWKAHuCBt;

			public int ZpQmiBilsWQZoBVuGKBRqXMBVIuA;

			private IEnumerator<int> iriZAEvKVOfCYRvYipsOqomabENb;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return xHZfDgFcZeIxmFYZdhjlmrCchxiTe;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return xHZfDgFcZeIxmFYZdhjlmrCchxiTe;
				}
			}

			[DebuggerHidden]
			public CSKopvXpRHVfxKcFFhNyeOSkKbSGA(int P_0)
			{
				noZrXSDCENksKeyBDiDXMSrCuiBW = P_0;
				PQCMMVpVGMJaHpowuLmVVMjxnHSM = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = noZrXSDCENksKeyBDiDXMSrCuiBW;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						JdIijLBUohocNZWHzsiWiXSVMQaEA();
					}
				}
				iriZAEvKVOfCYRvYipsOqomabENb = null;
				noZrXSDCENksKeyBDiDXMSrCuiBW = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = noZrXSDCENksKeyBDiDXMSrCuiBW;
					ActionCategoryMap actionCategoryMap = cOsmnFCJJmbOBDRZgNfbjgNHiHyKb;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						noZrXSDCENksKeyBDiDXMSrCuiBW = -1;
						if (actionCategoryMap.list == null)
						{
							return false;
						}
						int num2 = actionCategoryMap.IndexOfCategory(wuGjWJeXNRAYRrbaBoKKWKAHuCBt);
						if (num2 < 0)
						{
							return false;
						}
						iriZAEvKVOfCYRvYipsOqomabENb = actionCategoryMap.list[num2].ActionIds.GetEnumerator();
						noZrXSDCENksKeyBDiDXMSrCuiBW = -3;
						break;
					}
					case 1:
						noZrXSDCENksKeyBDiDXMSrCuiBW = -3;
						break;
					}
					if (iriZAEvKVOfCYRvYipsOqomabENb.MoveNext())
					{
						int current = iriZAEvKVOfCYRvYipsOqomabENb.Current;
						xHZfDgFcZeIxmFYZdhjlmrCchxiTe = current;
						noZrXSDCENksKeyBDiDXMSrCuiBW = 1;
						return true;
					}
					JdIijLBUohocNZWHzsiWiXSVMQaEA();
					iriZAEvKVOfCYRvYipsOqomabENb = null;
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

			private void JdIijLBUohocNZWHzsiWiXSVMQaEA()
			{
				noZrXSDCENksKeyBDiDXMSrCuiBW = -1;
				if (iriZAEvKVOfCYRvYipsOqomabENb != null)
				{
					iriZAEvKVOfCYRvYipsOqomabENb.Dispose();
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
				CSKopvXpRHVfxKcFFhNyeOSkKbSGA cSKopvXpRHVfxKcFFhNyeOSkKbSGA;
				if (noZrXSDCENksKeyBDiDXMSrCuiBW == -2 && PQCMMVpVGMJaHpowuLmVVMjxnHSM == Environment.CurrentManagedThreadId)
				{
					noZrXSDCENksKeyBDiDXMSrCuiBW = 0;
					cSKopvXpRHVfxKcFFhNyeOSkKbSGA = this;
				}
				else
				{
					cSKopvXpRHVfxKcFFhNyeOSkKbSGA = new CSKopvXpRHVfxKcFFhNyeOSkKbSGA(0);
					cSKopvXpRHVfxKcFFhNyeOSkKbSGA.cOsmnFCJJmbOBDRZgNfbjgNHiHyKb = cOsmnFCJJmbOBDRZgNfbjgNHiHyKb;
				}
				cSKopvXpRHVfxKcFFhNyeOSkKbSGA.wuGjWJeXNRAYRrbaBoKKWKAHuCBt = ZpQmiBilsWQZoBVuGKBRqXMBVIuA;
				return cSKopvXpRHVfxKcFFhNyeOSkKbSGA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Entry> list;

		[IteratorStateMachine(typeof(CSKopvXpRHVfxKcFFhNyeOSkKbSGA))]
		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			return new CSKopvXpRHVfxKcFFhNyeOSkKbSGA(-2)
			{
				cOsmnFCJJmbOBDRZgNfbjgNHiHyKb = this,
				ZpQmiBilsWQZoBVuGKBRqXMBVIuA = categoryId
			};
		}

		public ActionCategoryMap()
		{
			list = new List<Entry>();
		}

		public ActionCategoryMap(ActionCategoryMap P_0)
		{
			if (P_0.list != null)
			{
				list = new List<Entry>(P_0.list.Count);
				for (int i = 0; i < P_0.list.Count; i++)
				{
					list[i] = P_0.list[i].Clone();
				}
			}
		}

		public void AddCategory(int id)
		{
			list.Add(new Entry(id));
		}

		public void RemoveCategory(int id)
		{
			int num = IndexOfCategory(id);
			if (num >= 0)
			{
				list.RemoveAt(num);
			}
		}

		public bool ReorderCategory(int id, bool offsetDown)
		{
			int num = IndexOfCategory(id);
			if (num < 0)
			{
				return false;
			}
			if (!offsetDown && num == 0)
			{
				return false;
			}
			if (offsetDown && num >= list.Count - 1)
			{
				return false;
			}
			Entry value = list[num];
			if (offsetDown)
			{
				list[num] = list[num + 1];
				list[num + 1] = value;
			}
			else
			{
				list[num] = list[num - 1];
				list[num - 1] = value;
			}
			return true;
		}

		public bool ChangeCategory(int actionId, int newCategoryId)
		{
			if (list == null)
			{
				return false;
			}
			bool result = false;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].ContainsAction(actionId))
				{
					list[i].RemoveAction(actionId);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].categoryId == newCategoryId)
				{
					list[j].AddAction(actionId);
					result = true;
				}
			}
			return result;
		}

		public int IndexOfCategory(int id)
		{
			if (list == null)
			{
				return -1;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].categoryId == id)
				{
					return i;
				}
			}
			return -1;
		}

		public bool AddAction(int categoryId, int actionId)
		{
			if (list == null)
			{
				return false;
			}
			int num = IndexOfCategory(categoryId);
			if (num < 0)
			{
				return false;
			}
			list[num].AddAction(actionId);
			return true;
		}

		public bool InsertAction(int categoryId, int actionId, int index)
		{
			if (index < 0)
			{
				return false;
			}
			int num = IndexOfCategory(categoryId);
			if (num < 0)
			{
				return false;
			}
			return list[num].InsertAction(actionId, index);
		}

		public bool ReorderAction(int categoryId, int actionId, bool offsetDown, bool offsetNow)
		{
			int num = IndexOfCategory(categoryId);
			if (num < 0)
			{
				return false;
			}
			return list[num].ReorderAction(actionId, offsetDown, offsetNow);
		}

		public void RemoveAction(int categoryId, int actionId)
		{
			int num = IndexOfCategory(categoryId);
			if (num >= 0)
			{
				list[num].RemoveAction(actionId);
			}
		}

		public int IndexOfAction(int categoryId, int actionId)
		{
			int num = IndexOfCategory(categoryId);
			if (num < 0)
			{
				return -1;
			}
			return list[num].IndexOfAction(actionId);
		}

		public ActionCategoryMap Clone()
		{
			return new ActionCategoryMap(this);
		}
	}
}
