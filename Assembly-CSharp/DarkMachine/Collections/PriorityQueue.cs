using System;
using System.Collections.Generic;

namespace DarkMachine.Collections
{
	public class PriorityQueue<TElement, TPriority>
	{
		private readonly List<(TElement Element, TPriority Priority)> _heap;

		private readonly IComparer<TPriority> _comparer;

		public int Count => _heap.Count;

		public PriorityQueue()
			: this((IComparer<TPriority>)null)
		{
		}

		public PriorityQueue(IComparer<TPriority> comparer)
		{
			_comparer = comparer ?? Comparer<TPriority>.Default;
			_heap = new List<(TElement, TPriority)>();
		}

		public void Enqueue(TElement element, TPriority priority)
		{
			_heap.Add((element, priority));
			HeapifyUp(_heap.Count - 1);
		}

		public TElement Dequeue()
		{
			if (_heap.Count == 0)
			{
				throw new InvalidOperationException("The priority queue is empty.");
			}
			TElement item = _heap[0].Element;
			Swap(0, _heap.Count - 1);
			_heap.RemoveAt(_heap.Count - 1);
			if (_heap.Count > 0)
			{
				HeapifyDown(0);
			}
			return item;
		}

		public TElement Peek()
		{
			if (_heap.Count == 0)
			{
				throw new InvalidOperationException("The priority queue is empty.");
			}
			return _heap[0].Element;
		}

		private void HeapifyUp(int index)
		{
			if (index != 0)
			{
				int num = (index - 1) / 2;
				if (_comparer.Compare(_heap[index].Priority, _heap[num].Priority) < 0)
				{
					Swap(index, num);
					HeapifyUp(num);
				}
			}
		}

		private void HeapifyDown(int index)
		{
			int num = index;
			int num2 = 2 * index + 1;
			int num3 = 2 * index + 2;
			if (num2 < _heap.Count && _comparer.Compare(_heap[num2].Priority, _heap[num].Priority) < 0)
			{
				num = num2;
			}
			if (num3 < _heap.Count && _comparer.Compare(_heap[num3].Priority, _heap[num].Priority) < 0)
			{
				num = num3;
			}
			if (num != index)
			{
				Swap(index, num);
				HeapifyDown(num);
			}
		}

		private void Swap(int i, int j)
		{
			(TElement, TPriority) value = _heap[i];
			_heap[i] = _heap[j];
			_heap[j] = value;
		}
	}
}
