using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[DefaultMember("Item")]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class RingBuffer<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>
	{
		[Serializable]
		public struct CJMehhTjTntXGhscKKVXScigrhNp : IEnumerator<T>, IEnumerator, IDisposable
		{
			private RingBuffer<T> buffer;

			private int index;

			private int version;

			private T current;

			T IEnumerator<T>.Current => current;

			object IEnumerator.Current
			{
				get
				{
					if (index == 0 || index == buffer.vpSqQwWhrwuNSXGgnGSybUBMQXhg + 1)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			internal CJMehhTjTntXGhscKKVXScigrhNp(RingBuffer<T> P_0)
			{
				buffer = P_0;
				index = 0;
				version = P_0.DIWQDEoSwyldjjTpygGqplLZxWFQ;
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
				if (version == buffer.DIWQDEoSwyldjjTpygGqplLZxWFQ && (uint)index < (uint)buffer.vpSqQwWhrwuNSXGgnGSybUBMQXhg)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return EdHAJUhpHvmzvrBsJoBFHosaozedA();
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private bool EdHAJUhpHvmzvrBsJoBFHosaozedA()
			{
				if (version != buffer.DIWQDEoSwyldjjTpygGqplLZxWFQ)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = buffer.vpSqQwWhrwuNSXGgnGSybUBMQXhg + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.DIWQDEoSwyldjjTpygGqplLZxWFQ)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private T[] jGdAKerLneBDpkLzbrxaFgZgBohr;

		private readonly bool pgPfFBhqEbrbwXLWDmBzPtFCssBab;

		private readonly int uqmyvjOaNMRfWVbkpDiiyAojoRGR;

		private int afejvRWrpblNcPWysTWTFcPlGhNX;

		private int TWDdOJfITHhSUxJeEqIrsoKTLrMfb;

		private int fMQwXUXbqDmJUunZmNDddAcfTnQe;

		private int vpSqQwWhrwuNSXGgnGSybUBMQXhg;

		private int BmnFdZrWHJCvXYaQBsmRaYSYZrZb;

		private int DIWQDEoSwyldjjTpygGqplLZxWFQ;

		private Action<T> NtpTCgYwVUGewqOKFoHVdOVtDheIA;

		private Action<T> zIOAdnjxOPDCDgDfNdvseqcsqUIM;

		private IEqualityComparer<T> wcTFDVPejYGVQqJtGdbsrBPDuqYX = EqualityComparerNoAlloc<T>.Default;

		public int Count => vpSqQwWhrwuNSXGgnGSybUBMQXhg;

		public int Capacity => uqmyvjOaNMRfWVbkpDiiyAojoRGR;

		public int OverrunCount => BmnFdZrWHJCvXYaQBsmRaYSYZrZb;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return wcTFDVPejYGVQqJtGdbsrBPDuqYX;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				wcTFDVPejYGVQqJtGdbsrBPDuqYX = value;
			}
		}

		T IList<T>.this[int index]
		{
			get
			{
				int num = DMyHAyPCKeHjLCYpueDnneisicqpA(index);
				if (!qldhNDyeXvxXzjeSkvqNphFqYlrv(num))
				{
					throw new IndexOutOfRangeException();
				}
				return jGdAKerLneBDpkLzbrxaFgZgBohr[num];
			}
			set
			{
				int num = DMyHAyPCKeHjLCYpueDnneisicqpA(index);
				if (!qldhNDyeXvxXzjeSkvqNphFqYlrv(num))
				{
					throw new IndexOutOfRangeException();
				}
				jGdAKerLneBDpkLzbrxaFgZgBohr[num] = value;
			}
		}

		int ICollection<T>.Count => Count;

		bool ICollection<T>.IsReadOnly => false;

		public event Action<T> RemovedEvent
		{
			add
			{
				NtpTCgYwVUGewqOKFoHVdOVtDheIA = (Action<T>)Delegate.Combine(NtpTCgYwVUGewqOKFoHVdOVtDheIA, value);
			}
			remove
			{
				NtpTCgYwVUGewqOKFoHVdOVtDheIA = (Action<T>)Delegate.Remove(NtpTCgYwVUGewqOKFoHVdOVtDheIA, value);
			}
		}

		public event Action<T> BufferOverrunEvent
		{
			add
			{
				zIOAdnjxOPDCDgDfNdvseqcsqUIM = (Action<T>)Delegate.Combine(zIOAdnjxOPDCDgDfNdvseqcsqUIM, value);
			}
			remove
			{
				zIOAdnjxOPDCDgDfNdvseqcsqUIM = (Action<T>)Delegate.Remove(zIOAdnjxOPDCDgDfNdvseqcsqUIM, value);
			}
		}

		public RingBuffer(int P_0)
			: this(P_0, P_0)
		{
			pgPfFBhqEbrbwXLWDmBzPtFCssBab = true;
		}

		public RingBuffer(int P_0, int P_1)
		{
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("startingCapacity must be > 0.");
			}
			if (P_1 <= 0)
			{
				throw new ArgumentOutOfRangeException("maxCapacity must be > 0.");
			}
			if (P_0 > P_1)
			{
				throw new ArgumentOutOfRangeException("startingCapacity must be <= maxCapacity.");
			}
			jGdAKerLneBDpkLzbrxaFgZgBohr = new T[P_0];
			afejvRWrpblNcPWysTWTFcPlGhNX = P_0;
			uqmyvjOaNMRfWVbkpDiiyAojoRGR = P_1;
			pgPfFBhqEbrbwXLWDmBzPtFCssBab = false;
			Clear();
		}

		public void Enqueue(T item)
		{
			if (!pgPfFBhqEbrbwXLWDmBzPtFCssBab && TWDdOJfITHhSUxJeEqIrsoKTLrMfb >= afejvRWrpblNcPWysTWTFcPlGhNX - 1)
			{
				UPdLFCQLxnkAjnxjTNJRhScYmaDY();
			}
			TWDdOJfITHhSUxJeEqIrsoKTLrMfb = ((TWDdOJfITHhSUxJeEqIrsoKTLrMfb < afejvRWrpblNcPWysTWTFcPlGhNX - 1) ? (TWDdOJfITHhSUxJeEqIrsoKTLrMfb + 1) : 0);
			if (vpSqQwWhrwuNSXGgnGSybUBMQXhg == 0)
			{
				fMQwXUXbqDmJUunZmNDddAcfTnQe = 0;
			}
			else if (TWDdOJfITHhSUxJeEqIrsoKTLrMfb == fMQwXUXbqDmJUunZmNDddAcfTnQe)
			{
				fMQwXUXbqDmJUunZmNDddAcfTnQe = ((fMQwXUXbqDmJUunZmNDddAcfTnQe < afejvRWrpblNcPWysTWTFcPlGhNX - 1) ? (fMQwXUXbqDmJUunZmNDddAcfTnQe + 1) : 0);
				BmnFdZrWHJCvXYaQBsmRaYSYZrZb++;
				zIOAdnjxOPDCDgDfNdvseqcsqUIM?.Invoke(jGdAKerLneBDpkLzbrxaFgZgBohr[TWDdOJfITHhSUxJeEqIrsoKTLrMfb]);
				NtpTCgYwVUGewqOKFoHVdOVtDheIA?.Invoke(jGdAKerLneBDpkLzbrxaFgZgBohr[TWDdOJfITHhSUxJeEqIrsoKTLrMfb]);
			}
			jGdAKerLneBDpkLzbrxaFgZgBohr[TWDdOJfITHhSUxJeEqIrsoKTLrMfb] = item;
			if (vpSqQwWhrwuNSXGgnGSybUBMQXhg < afejvRWrpblNcPWysTWTFcPlGhNX)
			{
				vpSqQwWhrwuNSXGgnGSybUBMQXhg++;
			}
		}

		public bool EnqueueIfUnique(T item)
		{
			if (Contains(item))
			{
				return false;
			}
			Enqueue(item);
			return true;
		}

		public T Dequeue()
		{
			if (vpSqQwWhrwuNSXGgnGSybUBMQXhg == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			T val = jGdAKerLneBDpkLzbrxaFgZgBohr[fMQwXUXbqDmJUunZmNDddAcfTnQe];
			if (fMQwXUXbqDmJUunZmNDddAcfTnQe == TWDdOJfITHhSUxJeEqIrsoKTLrMfb)
			{
				Clear();
			}
			else
			{
				jGdAKerLneBDpkLzbrxaFgZgBohr[fMQwXUXbqDmJUunZmNDddAcfTnQe] = default(T);
				fMQwXUXbqDmJUunZmNDddAcfTnQe = ((fMQwXUXbqDmJUunZmNDddAcfTnQe < afejvRWrpblNcPWysTWTFcPlGhNX - 1) ? (fMQwXUXbqDmJUunZmNDddAcfTnQe + 1) : 0);
				BmnFdZrWHJCvXYaQBsmRaYSYZrZb = 0;
				vpSqQwWhrwuNSXGgnGSybUBMQXhg--;
				DIWQDEoSwyldjjTpygGqplLZxWFQ++;
			}
			NtpTCgYwVUGewqOKFoHVdOVtDheIA?.Invoke(val);
			return val;
		}

		public T Peek()
		{
			if (TWDdOJfITHhSUxJeEqIrsoKTLrMfb < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return jGdAKerLneBDpkLzbrxaFgZgBohr[fMQwXUXbqDmJUunZmNDddAcfTnQe];
		}

		public bool Contains(T item)
		{
			return UzjHXbNwrbsJeKwNNmcIBepCPhgb(item, wcTFDVPejYGVQqJtGdbsrBPDuqYX) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return UzjHXbNwrbsJeKwNNmcIBepCPhgb(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, wcTFDVPejYGVQqJtGdbsrBPDuqYX);
		}

		int IList<T>.IndexOf(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IndexOf
			return this.IndexOf(item);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return ZTqkbOASEoMfYaAYguGZgxGdNQad(UzjHXbNwrbsJeKwNNmcIBepCPhgb(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, wcTFDVPejYGVQqJtGdbsrBPDuqYX);
		}

		public bool Remove(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (Count == 0)
			{
				return false;
			}
			int num = UzjHXbNwrbsJeKwNNmcIBepCPhgb(item, comparer);
			if (num < 0)
			{
				return false;
			}
			sUeARiAQVTWdROlnTDvZMoJrJCuq(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			sUeARiAQVTWdROlnTDvZMoJrJCuq(DMyHAyPCKeHjLCYpueDnneisicqpA(index));
		}

		void IList<T>.RemoveAt(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RemoveAt
			this.RemoveAt(index);
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, wcTFDVPejYGVQqJtGdbsrBPDuqYX);
		}

		public int RemoveAll(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			int num = 0;
			for (int num2 = Count - 1; num2 >= 0; num2--)
			{
				if (comparer.Equals(this[num2], item))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public int CopyTo(IList<T> destination, int startIndex, int count)
		{
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (vpSqQwWhrwuNSXGgnGSybUBMQXhg == 0)
			{
				return 0;
			}
			if (startIndex < 0 || startIndex >= vpSqQwWhrwuNSXGgnGSybUBMQXhg)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			if (count <= 0 || count > vpSqQwWhrwuNSXGgnGSybUBMQXhg - startIndex)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			int count2 = destination.Count;
			for (int i = 0; i < vpSqQwWhrwuNSXGgnGSybUBMQXhg; i++)
			{
				destination.Add(this[startIndex + i]);
			}
			return destination.Count - count2;
		}

		public int CopyTo(IList<T> destination, int startIndex)
		{
			return CopyTo(destination, startIndex, vpSqQwWhrwuNSXGgnGSybUBMQXhg);
		}

		public int CopyTo(IList<T> destination)
		{
			return CopyTo(destination, 0, vpSqQwWhrwuNSXGgnGSybUBMQXhg);
		}

		public void Clear()
		{
			if (vpSqQwWhrwuNSXGgnGSybUBMQXhg > 0)
			{
				if (TWDdOJfITHhSUxJeEqIrsoKTLrMfb >= fMQwXUXbqDmJUunZmNDddAcfTnQe)
				{
					Action<T> ntpTCgYwVUGewqOKFoHVdOVtDheIA = NtpTCgYwVUGewqOKFoHVdOVtDheIA;
					if (ntpTCgYwVUGewqOKFoHVdOVtDheIA != null)
					{
						for (int i = fMQwXUXbqDmJUunZmNDddAcfTnQe; i < TWDdOJfITHhSUxJeEqIrsoKTLrMfb - fMQwXUXbqDmJUunZmNDddAcfTnQe + 1; i++)
						{
							ntpTCgYwVUGewqOKFoHVdOVtDheIA(jGdAKerLneBDpkLzbrxaFgZgBohr[i]);
						}
					}
					Array.Clear(jGdAKerLneBDpkLzbrxaFgZgBohr, fMQwXUXbqDmJUunZmNDddAcfTnQe, TWDdOJfITHhSUxJeEqIrsoKTLrMfb - fMQwXUXbqDmJUunZmNDddAcfTnQe + 1);
				}
				else
				{
					Action<T> ntpTCgYwVUGewqOKFoHVdOVtDheIA2 = NtpTCgYwVUGewqOKFoHVdOVtDheIA;
					if (ntpTCgYwVUGewqOKFoHVdOVtDheIA2 != null)
					{
						for (int j = 0; j < TWDdOJfITHhSUxJeEqIrsoKTLrMfb + 1; j++)
						{
							ntpTCgYwVUGewqOKFoHVdOVtDheIA2(jGdAKerLneBDpkLzbrxaFgZgBohr[j]);
						}
						for (int k = fMQwXUXbqDmJUunZmNDddAcfTnQe; k < afejvRWrpblNcPWysTWTFcPlGhNX - fMQwXUXbqDmJUunZmNDddAcfTnQe; k++)
						{
							ntpTCgYwVUGewqOKFoHVdOVtDheIA2(jGdAKerLneBDpkLzbrxaFgZgBohr[k]);
						}
					}
					Array.Clear(jGdAKerLneBDpkLzbrxaFgZgBohr, 0, TWDdOJfITHhSUxJeEqIrsoKTLrMfb + 1);
					Array.Clear(jGdAKerLneBDpkLzbrxaFgZgBohr, fMQwXUXbqDmJUunZmNDddAcfTnQe, afejvRWrpblNcPWysTWTFcPlGhNX - fMQwXUXbqDmJUunZmNDddAcfTnQe);
				}
				vpSqQwWhrwuNSXGgnGSybUBMQXhg = 0;
			}
			TWDdOJfITHhSUxJeEqIrsoKTLrMfb = -1;
			fMQwXUXbqDmJUunZmNDddAcfTnQe = -1;
			BmnFdZrWHJCvXYaQBsmRaYSYZrZb = 0;
			DIWQDEoSwyldjjTpygGqplLZxWFQ++;
		}

		private int IStVfWmPkTOGHLvLqemoDzdJZZlh(T P_0)
		{
			return UzjHXbNwrbsJeKwNNmcIBepCPhgb(P_0, wcTFDVPejYGVQqJtGdbsrBPDuqYX);
		}

		private int UzjHXbNwrbsJeKwNNmcIBepCPhgb(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (vpSqQwWhrwuNSXGgnGSybUBMQXhg == 0)
			{
				return -1;
			}
			if (TWDdOJfITHhSUxJeEqIrsoKTLrMfb >= fMQwXUXbqDmJUunZmNDddAcfTnQe)
			{
				for (int i = fMQwXUXbqDmJUunZmNDddAcfTnQe; i <= TWDdOJfITHhSUxJeEqIrsoKTLrMfb; i++)
				{
					if (P_1.Equals(jGdAKerLneBDpkLzbrxaFgZgBohr[i], P_0))
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j <= TWDdOJfITHhSUxJeEqIrsoKTLrMfb; j++)
				{
					if (P_1.Equals(jGdAKerLneBDpkLzbrxaFgZgBohr[j], P_0))
					{
						return j;
					}
				}
				for (int k = fMQwXUXbqDmJUunZmNDddAcfTnQe; k < afejvRWrpblNcPWysTWTFcPlGhNX; k++)
				{
					if (P_1.Equals(jGdAKerLneBDpkLzbrxaFgZgBohr[k], P_0))
					{
						return k;
					}
				}
			}
			return -1;
		}

		private void sUeARiAQVTWdROlnTDvZMoJrJCuq(int P_0)
		{
			if (!qldhNDyeXvxXzjeSkvqNphFqYlrv(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			if (P_0 == fMQwXUXbqDmJUunZmNDddAcfTnQe)
			{
				Dequeue();
				return;
			}
			if (P_0 != TWDdOJfITHhSUxJeEqIrsoKTLrMfb)
			{
				if (TWDdOJfITHhSUxJeEqIrsoKTLrMfb > fMQwXUXbqDmJUunZmNDddAcfTnQe)
				{
					Array.Copy(jGdAKerLneBDpkLzbrxaFgZgBohr, P_0 + 1, jGdAKerLneBDpkLzbrxaFgZgBohr, P_0, TWDdOJfITHhSUxJeEqIrsoKTLrMfb - P_0);
				}
				else if (P_0 < TWDdOJfITHhSUxJeEqIrsoKTLrMfb)
				{
					Array.Copy(jGdAKerLneBDpkLzbrxaFgZgBohr, P_0 + 1, jGdAKerLneBDpkLzbrxaFgZgBohr, P_0, TWDdOJfITHhSUxJeEqIrsoKTLrMfb - P_0);
				}
				else
				{
					Array.Copy(jGdAKerLneBDpkLzbrxaFgZgBohr, P_0 + 1, jGdAKerLneBDpkLzbrxaFgZgBohr, P_0, afejvRWrpblNcPWysTWTFcPlGhNX - P_0 - 1);
					jGdAKerLneBDpkLzbrxaFgZgBohr[afejvRWrpblNcPWysTWTFcPlGhNX - 1] = jGdAKerLneBDpkLzbrxaFgZgBohr[0];
					if (TWDdOJfITHhSUxJeEqIrsoKTLrMfb > 0)
					{
						Array.Copy(jGdAKerLneBDpkLzbrxaFgZgBohr, 1, jGdAKerLneBDpkLzbrxaFgZgBohr, 0, TWDdOJfITHhSUxJeEqIrsoKTLrMfb);
					}
				}
			}
			jGdAKerLneBDpkLzbrxaFgZgBohr[TWDdOJfITHhSUxJeEqIrsoKTLrMfb] = default(T);
			TWDdOJfITHhSUxJeEqIrsoKTLrMfb = ((TWDdOJfITHhSUxJeEqIrsoKTLrMfb > 0) ? (TWDdOJfITHhSUxJeEqIrsoKTLrMfb - 1) : (afejvRWrpblNcPWysTWTFcPlGhNX - 1));
			DIWQDEoSwyldjjTpygGqplLZxWFQ++;
			vpSqQwWhrwuNSXGgnGSybUBMQXhg--;
		}

		private bool qldhNDyeXvxXzjeSkvqNphFqYlrv(int P_0)
		{
			if (vpSqQwWhrwuNSXGgnGSybUBMQXhg == 0)
			{
				return false;
			}
			if (TWDdOJfITHhSUxJeEqIrsoKTLrMfb >= fMQwXUXbqDmJUunZmNDddAcfTnQe)
			{
				if (P_0 >= fMQwXUXbqDmJUunZmNDddAcfTnQe)
				{
					return P_0 <= TWDdOJfITHhSUxJeEqIrsoKTLrMfb;
				}
				return false;
			}
			if (P_0 < fMQwXUXbqDmJUunZmNDddAcfTnQe)
			{
				return P_0 <= TWDdOJfITHhSUxJeEqIrsoKTLrMfb;
			}
			return true;
		}

		private int ZTqkbOASEoMfYaAYguGZgxGdNQad(int P_0)
		{
			if ((uint)P_0 >= (uint)afejvRWrpblNcPWysTWTFcPlGhNX)
			{
				return -1;
			}
			if (!qldhNDyeXvxXzjeSkvqNphFqYlrv(P_0))
			{
				return -1;
			}
			if (P_0 >= fMQwXUXbqDmJUunZmNDddAcfTnQe)
			{
				return P_0 - fMQwXUXbqDmJUunZmNDddAcfTnQe;
			}
			return P_0 + afejvRWrpblNcPWysTWTFcPlGhNX - fMQwXUXbqDmJUunZmNDddAcfTnQe;
		}

		private int DMyHAyPCKeHjLCYpueDnneisicqpA(int P_0)
		{
			if ((uint)P_0 >= (uint)vpSqQwWhrwuNSXGgnGSybUBMQXhg)
			{
				return -1;
			}
			P_0 = fMQwXUXbqDmJUunZmNDddAcfTnQe + P_0;
			if (P_0 >= afejvRWrpblNcPWysTWTFcPlGhNX)
			{
				P_0 -= afejvRWrpblNcPWysTWTFcPlGhNX;
			}
			return P_0;
		}

		private bool UPdLFCQLxnkAjnxjTNJRhScYmaDY()
		{
			if (afejvRWrpblNcPWysTWTFcPlGhNX >= uqmyvjOaNMRfWVbkpDiiyAojoRGR)
			{
				return false;
			}
			int num = afejvRWrpblNcPWysTWTFcPlGhNX;
			afejvRWrpblNcPWysTWTFcPlGhNX = num * 2;
			if (afejvRWrpblNcPWysTWTFcPlGhNX > uqmyvjOaNMRfWVbkpDiiyAojoRGR)
			{
				afejvRWrpblNcPWysTWTFcPlGhNX = uqmyvjOaNMRfWVbkpDiiyAojoRGR;
			}
			else if (afejvRWrpblNcPWysTWTFcPlGhNX < uqmyvjOaNMRfWVbkpDiiyAojoRGR && uqmyvjOaNMRfWVbkpDiiyAojoRGR - afejvRWrpblNcPWysTWTFcPlGhNX <= num / 2)
			{
				afejvRWrpblNcPWysTWTFcPlGhNX = uqmyvjOaNMRfWVbkpDiiyAojoRGR;
			}
			T[] destinationArray = new T[afejvRWrpblNcPWysTWTFcPlGhNX];
			Array.Copy(jGdAKerLneBDpkLzbrxaFgZgBohr, destinationArray, jGdAKerLneBDpkLzbrxaFgZgBohr.Length);
			jGdAKerLneBDpkLzbrxaFgZgBohr = destinationArray;
			return true;
		}

		private void ZRsyXvsStQJRYVwDwbcJTMNDSYEo(T P_0)
		{
			Enqueue(P_0);
		}

		void ICollection<T>.Add(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ZRsyXvsStQJRYVwDwbcJTMNDSYEo
			this.ZRsyXvsStQJRYVwDwbcJTMNDSYEo(P_0);
		}

		private void fOyFXofjtPzTAhGoODniLJdiepPdb()
		{
			Clear();
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in fOyFXofjtPzTAhGoODniLJdiepPdb
			this.fOyFXofjtPzTAhGoODniLJdiepPdb();
		}

		private bool hlAmPPGCeIlehZnKGwewVmhEhNXS(T P_0)
		{
			return Contains(P_0);
		}

		bool ICollection<T>.Contains(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hlAmPPGCeIlehZnKGwewVmhEhNXS
			return this.hlAmPPGCeIlehZnKGwewVmhEhNXS(P_0);
		}

		private void HeYkKDTJpHwcMavStvqVQJBRxzrJ(T[] P_0, int P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("array");
			}
			if (P_1 < 0 || P_1 + Count > P_0.Length)
			{
				throw new ArgumentException("array is too small to hold the collection.");
			}
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				P_0[P_1 + i] = this[i];
			}
		}

		void ICollection<T>.CopyTo(T[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in HeYkKDTJpHwcMavStvqVQJBRxzrJ
			this.HeYkKDTJpHwcMavStvqVQJBRxzrJ(P_0, P_1);
		}

		private bool EnsyQAVlYHCLgCAengWkWqzVgBfZA(T P_0)
		{
			return Remove(P_0);
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in EnsyQAVlYHCLgCAengWkWqzVgBfZA
			return this.EnsyQAVlYHCLgCAengWkWqzVgBfZA(P_0);
		}

		private IEnumerator<T> JwxRigdggiceSbmyGZVWbpWqjyHkA()
		{
			return new CJMehhTjTntXGhscKKVXScigrhNp(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in JwxRigdggiceSbmyGZVWbpWqjyHkA
			return this.JwxRigdggiceSbmyGZVWbpWqjyHkA();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new CJMehhTjTntXGhscKKVXScigrhNp(this);
		}

		private void HFDmlEPkzRlzkpGXHyNQwFwtlSkL(int P_0, T P_1)
		{
			throw new NotImplementedException();
		}

		void IList<T>.Insert(int P_0, T P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in HFDmlEPkzRlzkpGXHyNQwFwtlSkL
			this.HFDmlEPkzRlzkpGXHyNQwFwtlSkL(P_0, P_1);
		}
	}
}
