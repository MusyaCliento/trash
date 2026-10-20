using System;
using System.Runtime.CompilerServices;

namespace Pathfinding.Clipper2Lib
{
	internal readonly struct SpanCompat<T> where T : unmanaged
	{
		internal unsafe readonly T* ptr;

		internal readonly uint length;

		public int Length => (int)length;

		public unsafe ref T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if ((uint)index >= length)
				{
					throw new IndexOutOfRangeException();
				}
				return ref ptr[index];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe SpanCompat(void* ptr, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (length > 0 && ptr == null)
			{
				throw new ArgumentNullException();
			}
			this.ptr = (T*)ptr;
			this.length = (uint)length;
		}
	}
}
