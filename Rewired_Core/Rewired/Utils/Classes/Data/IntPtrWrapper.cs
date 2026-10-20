using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IntPtrWrapper
	{
		private IntPtr iwNKXMxUXXcuBpgAjEtXkLDUQJaYA;

		public IntPtr pointer => iwNKXMxUXXcuBpgAjEtXkLDUQJaYA;

		public bool IsValid => iwNKXMxUXXcuBpgAjEtXkLDUQJaYA != IntPtr.Zero;

		public IntPtrWrapper(IntPtr P_0)
		{
			iwNKXMxUXXcuBpgAjEtXkLDUQJaYA = P_0;
		}

		public void Clear()
		{
			iwNKXMxUXXcuBpgAjEtXkLDUQJaYA = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return obj?.iwNKXMxUXXcuBpgAjEtXkLDUQJaYA ?? IntPtr.Zero;
		}
	}
}
