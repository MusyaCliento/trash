using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ObjectInstanceTracker : IDisposable
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public class Wrapper<T> : IDisposable where T : class
		{
			public readonly T instance;

			public readonly uint instanceId;

			private readonly ObjectInstanceTracker ncsqAWpaNhFkhzPkmhTwFgyhGJFV;

			private bool bntMtacHftyFLzYvVQQSkphmEQbiA;

			public Wrapper(T P_0)
				: this(P_0, Default)
			{
			}

			public Wrapper(T P_0, ObjectInstanceTracker P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("instance");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("tracker");
				}
				instance = P_0;
				ncsqAWpaNhFkhzPkmhTwFgyhGJFV = P_1;
				instanceId = P_1.Register(P_0);
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

			~Wrapper()
			{
				Dispose(disposing: false);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (!bntMtacHftyFLzYvVQQSkphmEQbiA)
				{
					if (ncsqAWpaNhFkhzPkmhTwFgyhGJFV != null)
					{
						ncsqAWpaNhFkhzPkmhTwFgyhGJFV.Unregister(instanceId);
					}
					bntMtacHftyFLzYvVQQSkphmEQbiA = true;
				}
			}
		}

		private static ObjectInstanceTracker PicfzbcrOfNejqItAIpEaRqitFIK;

		private readonly Dictionary<ulong, object> xEdBvAXBLUsUvibQtEGRBFejCKVTA = new Dictionary<ulong, object>();

		private readonly object puXYyIvyHDRAbVAHMWiEeEzIaet = new object();

		private uint MJBFIuoekizAfomxjrECCgNDQQnt;

		private int xFCptlilaAAEuhbKNkVDuJoCMWmP;

		private bool XUwYghQrUxbjZMVhrsAYbEbPOhKV;

		public static ObjectInstanceTracker Default => PicfzbcrOfNejqItAIpEaRqitFIK ?? (PicfzbcrOfNejqItAIpEaRqitFIK = new ObjectInstanceTracker());

		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			xFCptlilaAAEuhbKNkVDuJoCMWmP++;
			uint num = MJBFIuoekizAfomxjrECCgNDQQnt++;
			xEdBvAXBLUsUvibQtEGRBFejCKVTA.Add(num, instance);
			return num;
		}

		public void Unregister(uint instanceId)
		{
			xFCptlilaAAEuhbKNkVDuJoCMWmP--;
			if (xFCptlilaAAEuhbKNkVDuJoCMWmP < 0)
			{
				xFCptlilaAAEuhbKNkVDuJoCMWmP = 0;
			}
			lock (puXYyIvyHDRAbVAHMWiEeEzIaet)
			{
				xEdBvAXBLUsUvibQtEGRBFejCKVTA.Remove(instanceId);
			}
		}

		public bool TryGetInstance<T>(ulong instanceId, out T instance) where T : class
		{
			lock (puXYyIvyHDRAbVAHMWiEeEzIaet)
			{
				if (!xEdBvAXBLUsUvibQtEGRBFejCKVTA.TryGetValue(instanceId, out var value))
				{
					instance = null;
					return false;
				}
				if (value is T)
				{
					instance = (T)value;
					return true;
				}
				instance = null;
				return false;
			}
		}

		public void Dispose()
		{
			MOoAfrrWogNKUmJCqLEfoKfSUNtD(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		private void MOoAfrrWogNKUmJCqLEfoKfSUNtD(bool P_0)
		{
			if (!XUwYghQrUxbjZMVhrsAYbEbPOhKV)
			{
				if (this == PicfzbcrOfNejqItAIpEaRqitFIK)
				{
					PicfzbcrOfNejqItAIpEaRqitFIK = null;
				}
				XUwYghQrUxbjZMVhrsAYbEbPOhKV = true;
			}
		}

		~ObjectInstanceTracker()
		{
			MOoAfrrWogNKUmJCqLEfoKfSUNtD(false);
		}
	}
}
