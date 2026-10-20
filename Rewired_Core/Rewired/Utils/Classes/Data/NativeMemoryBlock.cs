using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int NipuIidJPxHpYqWXWMFAWMXKdgYK;

		private uint hDWzLOcZQbcfpxSqbycJiFHvcsTF;

		private IntPtr TmytrNwSHNoLdzqAFXutEDGYukTg;

		private bool TckcGSSxEfGDqAkrHNBEBLruBYALA;

		public uint size => hDWzLOcZQbcfpxSqbycJiFHvcsTF;

		public NativeMemoryBlock(uint P_0)
		{
			if (P_0 == 0)
			{
				throw new Exception("size must be > 0!");
			}
			hDWzLOcZQbcfpxSqbycJiFHvcsTF = P_0;
			NipuIidJPxHpYqWXWMFAWMXKdgYK = 0;
			try
			{
				TmytrNwSHNoLdzqAFXutEDGYukTg = Marshal.AllocHGlobal((int)P_0);
				if (TmytrNwSHNoLdzqAFXutEDGYukTg == IntPtr.Zero)
				{
					throw new Exception("Could not allocate native memory.");
				}
			}
			catch
			{
				throw;
			}
		}

		public IntPtr Allocate(uint bytes, IntPtr ptrToData)
		{
			if (TckcGSSxEfGDqAkrHNBEBLruBYALA)
			{
				return IntPtr.Zero;
			}
			if (bytes == 0)
			{
				return IntPtr.Zero;
			}
			if (bytes > hDWzLOcZQbcfpxSqbycJiFHvcsTF)
			{
				return IntPtr.Zero;
			}
			if (NipuIidJPxHpYqWXWMFAWMXKdgYK + bytes >= hDWzLOcZQbcfpxSqbycJiFHvcsTF)
			{
				NipuIidJPxHpYqWXWMFAWMXKdgYK = 0;
			}
			IntPtr intPtr = new IntPtr(TmytrNwSHNoLdzqAFXutEDGYukTg.ToInt64() + NipuIidJPxHpYqWXWMFAWMXKdgYK);
			if (ptrToData != IntPtr.Zero)
			{
				NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
			}
			NipuIidJPxHpYqWXWMFAWMXKdgYK += (int)bytes;
			return intPtr;
		}

		public IntPtr Allocate(uint bytes)
		{
			return Allocate(bytes, IntPtr.Zero);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~NativeMemoryBlock()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!TckcGSSxEfGDqAkrHNBEBLruBYALA)
			{
				TckcGSSxEfGDqAkrHNBEBLruBYALA = true;
				if (TmytrNwSHNoLdzqAFXutEDGYukTg != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(TmytrNwSHNoLdzqAFXutEDGYukTg);
					TmytrNwSHNoLdzqAFXutEDGYukTg = IntPtr.Zero;
				}
			}
		}
	}
}
