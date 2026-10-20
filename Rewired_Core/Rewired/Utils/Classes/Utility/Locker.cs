using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct Locker : IDisposable
	{
		private object ACsRklDYTtisNYiJczrkdxHEkkhC;

		public Locker(object P_0)
		{
			ACsRklDYTtisNYiJczrkdxHEkkhC = P_0;
			if (P_0 != null)
			{
				Monitor.Enter(P_0);
			}
		}

		public void Dispose()
		{
			if (ACsRklDYTtisNYiJczrkdxHEkkhC != null)
			{
				Monitor.Exit(ACsRklDYTtisNYiJczrkdxHEkkhC);
				ACsRklDYTtisNYiJczrkdxHEkkhC = null;
			}
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}
	}
}
