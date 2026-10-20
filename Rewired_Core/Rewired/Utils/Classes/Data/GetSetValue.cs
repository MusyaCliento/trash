using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class GetSetValue<T> : IGetSetValue<T>, IGetValue<T>, ISetValue<T>
	{
		private Func<T> JYmIsjyEBomBBeEDFCpBwNpnzemE;

		private Action<T> OZNdsAhTMzBXeFLmgiHezMhaYvvXb;

		public Func<T> getValueDelegate
		{
			get
			{
				return JYmIsjyEBomBBeEDFCpBwNpnzemE;
			}
			set
			{
				JYmIsjyEBomBBeEDFCpBwNpnzemE = value;
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return OZNdsAhTMzBXeFLmgiHezMhaYvvXb;
			}
			set
			{
				OZNdsAhTMzBXeFLmgiHezMhaYvvXb = value;
			}
		}

		public GetSetValue(Func<T> P_0, Action<T> P_1)
		{
			JYmIsjyEBomBBeEDFCpBwNpnzemE = P_0;
			OZNdsAhTMzBXeFLmgiHezMhaYvvXb = P_1;
		}

		public T GetValue()
		{
			if (JYmIsjyEBomBBeEDFCpBwNpnzemE == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return JYmIsjyEBomBBeEDFCpBwNpnzemE();
		}

		T IGetValue<T>.GetValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetValue
			return this.GetValue();
		}

		public void SetValue(T value)
		{
			if (OZNdsAhTMzBXeFLmgiHezMhaYvvXb == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			OZNdsAhTMzBXeFLmgiHezMhaYvvXb(value);
		}

		void ISetValue<T>.SetValue(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetValue
			this.SetValue(value);
		}
	}
}
