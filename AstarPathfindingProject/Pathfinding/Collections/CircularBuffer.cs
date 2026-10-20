using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pathfinding.Pooling;
using Unity.Profiling;

namespace Pathfinding.Collections
{
	public struct CircularBuffer<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
	{
		internal T[] data;

		internal int head;

		private int length;

		public readonly int Length
		{
			[IgnoredByDeepProfiler]
			get
			{
				return length;
			}
		}

		public readonly int AbsoluteStartIndex => head;

		public readonly int AbsoluteEndIndex => head + length - 1;

		public readonly ref T First
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			get
			{
				return ref data[head & (data.Length - 1)];
			}
		}

		public readonly ref T Last
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			get
			{
				return ref data[(head + length - 1) & (data.Length - 1)];
			}
		}

		readonly int IReadOnlyCollection<T>.Count
		{
			[IgnoredByDeepProfiler]
			get
			{
				return length;
			}
		}

		public T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			readonly get
			{
				return data[(index + head) & (data.Length - 1)];
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			set
			{
				data[(index + head) & (data.Length - 1)] = value;
			}
		}

		public CircularBuffer(int initialCapacity)
		{
			data = ArrayPool<T>.Claim(initialCapacity);
			head = 0;
			length = 0;
		}

		public CircularBuffer(T[] backingArray)
		{
			data = backingArray;
			head = 0;
			length = 0;
		}

		public void Clear()
		{
			length = 0;
			head = 0;
		}

		public void AddRange(List<T> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				PushEnd(items[i]);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		public void PushStart(T item)
		{
			if (data == null || length >= data.Length)
			{
				Grow();
			}
			length++;
			head--;
			this[0] = item;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		public void PushEnd(T item)
		{
			if (data == null || length >= data.Length)
			{
				Grow();
			}
			length++;
			this[length - 1] = item;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		public void Push(bool toStart, T item)
		{
			if (toStart)
			{
				PushStart(item);
			}
			else
			{
				PushEnd(item);
			}
		}

		[IgnoredByDeepProfiler]
		public T PopStart()
		{
			if (length == 0)
			{
				throw new InvalidOperationException();
			}
			T result = this[0];
			head++;
			length--;
			return result;
		}

		[IgnoredByDeepProfiler]
		public T PopEnd()
		{
			if (length == 0)
			{
				throw new InvalidOperationException();
			}
			T result = this[length - 1];
			length--;
			return result;
		}

		[IgnoredByDeepProfiler]
		public T Pop(bool fromStart)
		{
			if (fromStart)
			{
				return PopStart();
			}
			return PopEnd();
		}

		public readonly T GetBoundaryValue(bool start)
		{
			return GetAbsolute(start ? AbsoluteStartIndex : AbsoluteEndIndex);
		}

		public void InsertAbsolute(int index, T item)
		{
			SpliceUninitializedAbsolute(index, 0, 1);
			data[index & (data.Length - 1)] = item;
		}

		public void Splice(int startIndex, int toRemove, List<T> toInsert)
		{
			SpliceAbsolute(startIndex + head, toRemove, toInsert);
		}

		public void SpliceAbsolute(int startIndex, int toRemove, List<T> toInsert)
		{
			if (toInsert == null)
			{
				SpliceUninitializedAbsolute(startIndex, toRemove, 0);
				return;
			}
			SpliceUninitializedAbsolute(startIndex, toRemove, toInsert.Count);
			for (int i = 0; i < toInsert.Count; i++)
			{
				data[(startIndex + i) & (data.Length - 1)] = toInsert[i];
			}
		}

		public void SpliceUninitialized(int startIndex, int toRemove, int toInsert)
		{
			SpliceUninitializedAbsolute(startIndex + head, toRemove, toInsert);
		}

		public void SpliceUninitializedAbsolute(int startIndex, int toRemove, int toInsert)
		{
			int num = toInsert - toRemove;
			while (length + num > data.Length)
			{
				Grow();
			}
			MoveAbsolute(startIndex + toRemove, AbsoluteEndIndex, num);
			length += num;
		}

		private void MoveAbsolute(int startIndex, int endIndex, int deltaIndex)
		{
			if (deltaIndex > 0)
			{
				for (int num = endIndex; num >= startIndex; num--)
				{
					data[(num + deltaIndex) & (data.Length - 1)] = data[num & (data.Length - 1)];
				}
			}
			else if (deltaIndex < 0)
			{
				for (int i = startIndex; i <= endIndex; i++)
				{
					data[(i + deltaIndex) & (data.Length - 1)] = data[i & (data.Length - 1)];
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		public readonly T GetAbsolute(int index)
		{
			return data[index & (data.Length - 1)];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		public readonly void SetAbsolute(int index, T value)
		{
			data[index & (data.Length - 1)] = value;
		}

		private void Grow()
		{
			T[] array = ArrayPool<T>.Claim(Math.Max(4, (data != null) ? (data.Length * 2) : 0));
			if (data != null)
			{
				int num = data.Length - (head & (data.Length - 1));
				Array.Copy(data, head & (data.Length - 1), array, head & (array.Length - 1), num);
				int num2 = length - num;
				if (num2 > 0)
				{
					Array.Copy(data, 0, array, (head + num) & (array.Length - 1), num2);
				}
				Array.Fill(data, default(T));
				ArrayPool<T>.Release(ref data);
			}
			data = array;
		}

		public void Pool()
		{
			Array.Fill(data, default(T));
			ArrayPool<T>.Release(ref data);
			length = 0;
			head = 0;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < length; i++)
			{
				yield return this[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			for (int i = 0; i < length; i++)
			{
				yield return this[i];
			}
		}

		public CircularBuffer<T> Clone()
		{
			return new CircularBuffer<T>
			{
				data = ((data != null) ? ((T[])data.Clone()) : null),
				length = length,
				head = head
			};
		}
	}
}
