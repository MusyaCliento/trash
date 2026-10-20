using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[DefaultMember("Item")]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class MappedArray<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
	{
		[Serializable]
		public struct GbLwucfBpRMWOwsDewgBLtgqtAcX : IEnumerator<T>, IEnumerator, IDisposable
		{
			private MappedArray<T> array;

			private int index;

			private int version;

			private T current;

			T IEnumerator<T>.Current => current;

			object IEnumerator.Current
			{
				get
				{
					if (index == 0 || index == array.Length + 1)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			internal GbLwucfBpRMWOwsDewgBLtgqtAcX(MappedArray<T> P_0)
			{
				array = P_0;
				index = 0;
				version = P_0.WIChfJMLmECRBYKohEuodifjlVPi;
				current = default(T);
			}

			public void Dispose()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			public bool MoveNext()
			{
				MappedArray<T> mappedArray = array;
				if (version == mappedArray.WIChfJMLmECRBYKohEuodifjlVPi && (uint)index < (uint)mappedArray.Length)
				{
					current = mappedArray.sGwmDwzHfQyfFjQyEgFojhjfgMztA[mappedArray.JzwjDsLyPngMPLLBWUsAvYKnCGOF(index)];
					index++;
					return true;
				}
				return lyILLtpmltXSWZmkfiUagtNCkSNsA();
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private bool lyILLtpmltXSWZmkfiUagtNCkSNsA()
			{
				if (version != array.WIChfJMLmECRBYKohEuodifjlVPi)
				{
					throw new InvalidOperationException("List was changed.");
				}
				index = array.Length + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != array.WIChfJMLmECRBYKohEuodifjlVPi)
				{
					throw new InvalidOperationException("List was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private T[] sGwmDwzHfQyfFjQyEgFojhjfgMztA;

		private int WIChfJMLmECRBYKohEuodifjlVPi;

		private Func<int, int> kEERnhASWZqaZXIJjjALbCEVaZgz;

		public Func<int, int> indexMap
		{
			get
			{
				return kEERnhASWZqaZXIJjjALbCEVaZgz;
			}
			set
			{
				kEERnhASWZqaZXIJjjALbCEVaZgz = value;
				WIChfJMLmECRBYKohEuodifjlVPi++;
			}
		}

		T IList<T>.this[int index]
		{
			get
			{
				return sGwmDwzHfQyfFjQyEgFojhjfgMztA[JzwjDsLyPngMPLLBWUsAvYKnCGOF(index)];
			}
			set
			{
				sGwmDwzHfQyfFjQyEgFojhjfgMztA[JzwjDsLyPngMPLLBWUsAvYKnCGOF(index)] = value;
			}
		}

		public int Length => sGwmDwzHfQyfFjQyEgFojhjfgMztA.Length;

		int ICollection<T>.Count => sGwmDwzHfQyfFjQyEgFojhjfgMztA.Length;

		bool ICollection<T>.IsReadOnly => ((ICollection<T>)sGwmDwzHfQyfFjQyEgFojhjfgMztA).IsReadOnly;

		object IList.this[int index]
		{
			get
			{
				return ((IList)sGwmDwzHfQyfFjQyEgFojhjfgMztA)[JzwjDsLyPngMPLLBWUsAvYKnCGOF(index)];
			}
			set
			{
				((IList)sGwmDwzHfQyfFjQyEgFojhjfgMztA)[JzwjDsLyPngMPLLBWUsAvYKnCGOF(index)] = value;
			}
		}

		int ICollection.Count => sGwmDwzHfQyfFjQyEgFojhjfgMztA.Length;

		bool IList.IsFixedSize => ((IList)sGwmDwzHfQyfFjQyEgFojhjfgMztA).IsFixedSize;

		object ICollection.SyncRoot => ((ICollection)sGwmDwzHfQyfFjQyEgFojhjfgMztA).SyncRoot;

		bool ICollection.IsSynchronized => ((ICollection)sGwmDwzHfQyfFjQyEgFojhjfgMztA).IsSynchronized;

		public MappedArray(T[] P_0, Func<int, int> P_1)
		{
			sGwmDwzHfQyfFjQyEgFojhjfgMztA = P_0;
			kEERnhASWZqaZXIJjjALbCEVaZgz = P_1;
		}

		public void Add(T item)
		{
			throw new NotImplementedException();
		}

		void ICollection<T>.Add(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(item);
		}

		public void Clear()
		{
			Array.Clear(sGwmDwzHfQyfFjQyEgFojhjfgMztA, 0, sGwmDwzHfQyfFjQyEgFojhjfgMztA.Length);
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		void IList.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		public bool Contains(T item)
		{
			return sGwmDwzHfQyfFjQyEgFojhjfgMztA.Contains(item);
		}

		bool ICollection<T>.Contains(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Contains
			return this.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			sGwmDwzHfQyfFjQyEgFojhjfgMztA.CopyTo(array, arrayIndex);
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CopyTo
			this.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new GbLwucfBpRMWOwsDewgBLtgqtAcX(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		public int IndexOf(T item)
		{
			return JzwjDsLyPngMPLLBWUsAvYKnCGOF(((IList<T>)sGwmDwzHfQyfFjQyEgFojhjfgMztA).IndexOf(item));
		}

		int IList<T>.IndexOf(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IndexOf
			return this.IndexOf(item);
		}

		private void nfuwQskCfwjgQApoXOUiPGtpfRsA(int P_0, T P_1)
		{
			throw new NotImplementedException();
		}

		void IList<T>.Insert(int P_0, T P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nfuwQskCfwjgQApoXOUiPGtpfRsA
			this.nfuwQskCfwjgQApoXOUiPGtpfRsA(P_0, P_1);
		}

		private bool AhzGkLJhWeHcNbYOGkjIWnkaowYhb(T P_0)
		{
			throw new NotImplementedException();
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in AhzGkLJhWeHcNbYOGkjIWnkaowYhb
			return this.AhzGkLJhWeHcNbYOGkjIWnkaowYhb(P_0);
		}

		private void LalBRMGwbYTbailqRkSLNxbrRBFK(int P_0)
		{
			throw new NotImplementedException();
		}

		void IList<T>.RemoveAt(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in LalBRMGwbYTbailqRkSLNxbrRBFK
			this.LalBRMGwbYTbailqRkSLNxbrRBFK(P_0);
		}

		int IList.Add(object value)
		{
			throw new NotImplementedException();
		}

		bool IList.Contains(object value)
		{
			return ((IList)sGwmDwzHfQyfFjQyEgFojhjfgMztA).Contains(value);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			sGwmDwzHfQyfFjQyEgFojhjfgMztA.CopyTo(array, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new GbLwucfBpRMWOwsDewgBLtgqtAcX(this);
		}

		int IList.IndexOf(object value)
		{
			return ((IList)sGwmDwzHfQyfFjQyEgFojhjfgMztA).IndexOf(value);
		}

		void IList.Insert(int index, object value)
		{
			throw new NotImplementedException();
		}

		void IList.Remove(object value)
		{
			throw new NotImplementedException();
		}

		void IList.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		private int JzwjDsLyPngMPLLBWUsAvYKnCGOF(int P_0)
		{
			if (kEERnhASWZqaZXIJjjALbCEVaZgz == null)
			{
				return P_0;
			}
			if (P_0 < 0 || P_0 >= sGwmDwzHfQyfFjQyEgFojhjfgMztA.Length)
			{
				return P_0;
			}
			return kEERnhASWZqaZXIJjjALbCEVaZgz(P_0);
		}
	}
}
