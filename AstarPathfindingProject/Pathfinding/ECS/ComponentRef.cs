using System.Runtime.CompilerServices;

namespace Pathfinding.ECS
{
	public ref struct ComponentRef<T> where T : unmanaged
	{
		private unsafe byte* ptr;

		public unsafe ref T value
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return ref *(T*)ptr;
			}
		}

		public unsafe ComponentRef(byte* ptr)
		{
			this.ptr = ptr;
		}
	}
}
