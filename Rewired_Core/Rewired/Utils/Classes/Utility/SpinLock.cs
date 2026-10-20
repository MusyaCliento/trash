using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SpinLock : IDisposable
	{
		private const int BgJtgBjKEtAPWjNxKIkHZAttsizJ = 1;

		private const int zmGvHrbaaXgdxnfYFBqIEnndvrIs = 0;

		private int RotHIthhiIEFjUbVKqFGeBEFJDrl;

		void IDisposable.Dispose()
		{
			ldnMWsPcrSfaHHnFNhNdxgMLPGXw();
		}

		private void NaelgBNIjTjfOcUnrDFqQttpXuTg()
		{
			while (Interlocked.Exchange(ref RotHIthhiIEFjUbVKqFGeBEFJDrl, 1) != 0)
			{
				Thread.SpinWait(1);
			}
		}

		private void ldnMWsPcrSfaHHnFNhNdxgMLPGXw()
		{
			Interlocked.Exchange(ref RotHIthhiIEFjUbVKqFGeBEFJDrl, 0);
		}

		public SpinLock Lock()
		{
			NaelgBNIjTjfOcUnrDFqQttpXuTg();
			return this;
		}
	}
}
