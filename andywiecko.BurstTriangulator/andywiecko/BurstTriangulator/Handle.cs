using Unity.Collections.LowLevel.Unsafe;

namespace andywiecko.BurstTriangulator
{
	public readonly struct Handle
	{
		private readonly ulong gcHandle;

		public Handle(ulong gcHandle)
		{
			this.gcHandle = gcHandle;
		}

		public void Free()
		{
			UnsafeUtility.ReleaseGCObject(gcHandle);
		}
	}
}
