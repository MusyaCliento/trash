using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int xERUInlzhwlbGLbMjbhsBSgFlZMFb;

		private readonly int nbCwPFVEJXgBFcvDGPxXeWIALIAs;

		private readonly int TmMydhIXjLEPqgYdIlHUrzxQPwJJ;

		private readonly bool zUYklTHHUXghNGhAPKyNbsqkxbYJB;

		private ThreadHelper nwOZqFXWeBHNrtyFQUNNLOobBOEb;

		private Queue<T> txmCHWRFnHDhPZphxfcJcHGqPgsXA;

		private Queue<T> tLEZZQGHiQjXfuHOWPQPdKSRjxTC;

		private bool xXakoNeAXNLrGEoNVKzmFWKhJTOL;

		private bool btxAjMePdhsOBhirRUfLDmpUZuBCA;

		private Action<T> UjWzVsoifyHmlgnVCQaHSmwgmzHAA;

		private bool FvvLqKVUepaXMTpjFScekeQOZLZK;

		public ThreadedMessageQueue(int P_0, int P_1, int P_2, bool P_3, Action<T> P_4)
		{
			if (P_4 == null)
			{
				throw new ArgumentNullException("messageReceiverDelegate");
			}
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_1 < 0)
			{
				P_1 = 0;
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			xERUInlzhwlbGLbMjbhsBSgFlZMFb = P_0;
			nbCwPFVEJXgBFcvDGPxXeWIALIAs = P_1;
			TmMydhIXjLEPqgYdIlHUrzxQPwJJ = P_2;
			zUYklTHHUXghNGhAPKyNbsqkxbYJB = P_3;
			UjWzVsoifyHmlgnVCQaHSmwgmzHAA = P_4;
			txmCHWRFnHDhPZphxfcJcHGqPgsXA = new Queue<T>(P_0);
			tLEZZQGHiQjXfuHOWPQPdKSRjxTC = new Queue<T>(P_0);
		}

		public void Enqueue(T message)
		{
			if (!WMQKwyOghEVVClYfuouBNfTNqSXN())
			{
				return;
			}
			lock (txmCHWRFnHDhPZphxfcJcHGqPgsXA)
			{
				if (xERUInlzhwlbGLbMjbhsBSgFlZMFb > 0)
				{
					while (txmCHWRFnHDhPZphxfcJcHGqPgsXA.Count >= xERUInlzhwlbGLbMjbhsBSgFlZMFb)
					{
						txmCHWRFnHDhPZphxfcJcHGqPgsXA.Dequeue();
					}
				}
				txmCHWRFnHDhPZphxfcJcHGqPgsXA.Enqueue(message);
			}
		}

		private bool WMQKwyOghEVVClYfuouBNfTNqSXN()
		{
			if (xXakoNeAXNLrGEoNVKzmFWKhJTOL)
			{
				return false;
			}
			if (!koqrfNNBeSzotvKCirAeoKjBEomP())
			{
				return false;
			}
			if (btxAjMePdhsOBhirRUfLDmpUZuBCA)
			{
				return true;
			}
			btxAjMePdhsOBhirRUfLDmpUZuBCA = true;
			return true;
		}

		private bool koqrfNNBeSzotvKCirAeoKjBEomP()
		{
			if (xXakoNeAXNLrGEoNVKzmFWKhJTOL)
			{
				return false;
			}
			if (nwOZqFXWeBHNrtyFQUNNLOobBOEb == null)
			{
				try
				{
					nwOZqFXWeBHNrtyFQUNNLOobBOEb = ThreadHelper.CreateFixedTimeStep(nbCwPFVEJXgBFcvDGPxXeWIALIAs, TmMydhIXjLEPqgYdIlHUrzxQPwJJ);
					nwOZqFXWeBHNrtyFQUNNLOobBOEb.ThreadUpdateEvent += mTXVvyrNRevGqqwzyPPIItWJZvRE;
					nwOZqFXWeBHNrtyFQUNNLOobBOEb.Start(zUYklTHHUXghNGhAPKyNbsqkxbYJB);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (nwOZqFXWeBHNrtyFQUNNLOobBOEb != null)
					{
						nwOZqFXWeBHNrtyFQUNNLOobBOEb.Stop(zUYklTHHUXghNGhAPKyNbsqkxbYJB);
					}
					xXakoNeAXNLrGEoNVKzmFWKhJTOL = true;
					return false;
				}
			}
			if (!nwOZqFXWeBHNrtyFQUNNLOobBOEb.isRunning)
			{
				nwOZqFXWeBHNrtyFQUNNLOobBOEb.Start(zUYklTHHUXghNGhAPKyNbsqkxbYJB);
			}
			else if (TmMydhIXjLEPqgYdIlHUrzxQPwJJ > 0)
			{
				nwOZqFXWeBHNrtyFQUNNLOobBOEb.ResetTimeout();
			}
			return true;
		}

		private void mvZEldhaMAZfWiaCWtHyJKGkiQxV()
		{
			lock (txmCHWRFnHDhPZphxfcJcHGqPgsXA)
			{
				lock (tLEZZQGHiQjXfuHOWPQPdKSRjxTC)
				{
					MiscTools.Swap(ref txmCHWRFnHDhPZphxfcJcHGqPgsXA, ref tLEZZQGHiQjXfuHOWPQPdKSRjxTC);
				}
			}
		}

		private void mTXVvyrNRevGqqwzyPPIItWJZvRE()
		{
			mvZEldhaMAZfWiaCWtHyJKGkiQxV();
			lock (tLEZZQGHiQjXfuHOWPQPdKSRjxTC)
			{
				while (tLEZZQGHiQjXfuHOWPQPdKSRjxTC.Count > 0)
				{
					try
					{
						UjWzVsoifyHmlgnVCQaHSmwgmzHAA(tLEZZQGHiQjXfuHOWPQPdKSRjxTC.Dequeue());
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred while sending message.\nMessage: " + ex.Message, requiredThreadSafety: true);
					}
				}
			}
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

		~ThreadedMessageQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (FvvLqKVUepaXMTpjFScekeQOZLZK)
			{
				return;
			}
			if (disposing)
			{
				if (txmCHWRFnHDhPZphxfcJcHGqPgsXA != null)
				{
					if (tLEZZQGHiQjXfuHOWPQPdKSRjxTC != null)
					{
						lock (txmCHWRFnHDhPZphxfcJcHGqPgsXA)
						{
							lock (tLEZZQGHiQjXfuHOWPQPdKSRjxTC)
							{
								txmCHWRFnHDhPZphxfcJcHGqPgsXA.Clear();
								tLEZZQGHiQjXfuHOWPQPdKSRjxTC.Clear();
							}
						}
					}
					else
					{
						lock (txmCHWRFnHDhPZphxfcJcHGqPgsXA)
						{
							txmCHWRFnHDhPZphxfcJcHGqPgsXA.Clear();
						}
					}
				}
				else if (tLEZZQGHiQjXfuHOWPQPdKSRjxTC != null)
				{
					lock (tLEZZQGHiQjXfuHOWPQPdKSRjxTC)
					{
						tLEZZQGHiQjXfuHOWPQPdKSRjxTC.Clear();
					}
				}
				if (nwOZqFXWeBHNrtyFQUNNLOobBOEb != null)
				{
					nwOZqFXWeBHNrtyFQUNNLOobBOEb.Dispose();
				}
			}
			FvvLqKVUepaXMTpjFScekeQOZLZK = true;
		}
	}
}
