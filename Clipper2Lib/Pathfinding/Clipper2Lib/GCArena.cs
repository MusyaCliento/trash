using System;
using System.Collections.Generic;

namespace Pathfinding.Clipper2Lib
{
	internal class GCArena<T> where T : class, IDisposable, new()
	{
		private List<T> arena = new List<T>();

		private int index;

		public void Reclaim()
		{
			index = 0;
			foreach (T item in arena)
			{
				item.Dispose();
			}
		}

		public T Get()
		{
			if (index < arena.Count)
			{
				return arena[index++];
			}
			T val = new T();
			arena.Add(val);
			index++;
			return val;
		}
	}
}
