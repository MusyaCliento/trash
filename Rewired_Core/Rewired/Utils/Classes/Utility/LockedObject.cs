using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object JlhrguWIqbuLvtefKpExceghRgoe;

		private bool gcASfIBJESagiYfRMPiOJlPbVPVe;

		public LockedObject()
		{
			JlhrguWIqbuLvtefKpExceghRgoe = new object();
		}

		public LockedObject(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("lockObject");
			}
			JlhrguWIqbuLvtefKpExceghRgoe = P_0;
		}

		public void Lock()
		{
			if (gcASfIBJESagiYfRMPiOJlPbVPVe)
			{
				throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
			}
			Monitor.Enter(JlhrguWIqbuLvtefKpExceghRgoe);
			gcASfIBJESagiYfRMPiOJlPbVPVe = true;
		}

		public void Unlock()
		{
			if (!gcASfIBJESagiYfRMPiOJlPbVPVe)
			{
				throw new Exception("Not locked. Lock must be called before Dispose.");
			}
			Monitor.Exit(JlhrguWIqbuLvtefKpExceghRgoe);
			gcASfIBJESagiYfRMPiOJlPbVPVe = false;
		}

		void IDisposable.Dispose()
		{
			Unlock();
		}
	}
}
