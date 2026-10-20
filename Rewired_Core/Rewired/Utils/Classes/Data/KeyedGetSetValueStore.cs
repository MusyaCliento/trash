using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal sealed class KeyedGetSetValueStore<TKey> : IDictionary<TKey, object>, ICollection<KeyValuePair<TKey, object>>, IEnumerable<KeyValuePair<TKey, object>>, IEnumerable
	{
		private readonly Dictionary<TKey, object> AhflBnFEPxhpCqnhzGTMZAnejxau;

		private readonly bool TQmbEaCeMLCvvLLtjsIDVewumFpqA;

		public int Count => AhflBnFEPxhpCqnhzGTMZAnejxau.Count;

		public bool isReadOnlyCollection => TQmbEaCeMLCvvLLtjsIDVewumFpqA;

		ICollection<TKey> IDictionary<TKey, object>.Keys => AhflBnFEPxhpCqnhzGTMZAnejxau.Keys;

		ICollection<object> IDictionary<TKey, object>.Values => AhflBnFEPxhpCqnhzGTMZAnejxau.Values;

		object IDictionary<TKey, object>.this[TKey P_0]
		{
			get
			{
				return AhflBnFEPxhpCqnhzGTMZAnejxau[P_0];
			}
			set
			{
				KRGqwkrdDvHUSaLbNkkyOJyURXOI();
				AhflBnFEPxhpCqnhzGTMZAnejxau[key] = value2;
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => AhflBnFEPxhpCqnhzGTMZAnejxau.Count;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => TQmbEaCeMLCvvLLtjsIDVewumFpqA;

		public KeyedGetSetValueStore(Dictionary<TKey, object> P_0, bool P_1)
		{
			AhflBnFEPxhpCqnhzGTMZAnejxau = P_0;
			TQmbEaCeMLCvvLLtjsIDVewumFpqA = P_1;
		}

		public KeyedGetSetValueStore(bool P_0)
		{
			TQmbEaCeMLCvvLLtjsIDVewumFpqA = P_0;
			AhflBnFEPxhpCqnhzGTMZAnejxau = new Dictionary<TKey, object>();
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			KRGqwkrdDvHUSaLbNkkyOJyURXOI();
			AhflBnFEPxhpCqnhzGTMZAnejxau.Add(key, item);
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			if (!AhflBnFEPxhpCqnhzGTMZAnejxau.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
			{
				ckiFzqsSZBpvLbUBRrFREMggxOPb(key, typeof(TValue));
				return null;
			}
			return result;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			KRGqwkrdDvHUSaLbNkkyOJyURXOI();
			return AhflBnFEPxhpCqnhzGTMZAnejxau.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return AhflBnFEPxhpCqnhzGTMZAnejxau.ContainsKey(key);
		}

		public void Clear()
		{
			KRGqwkrdDvHUSaLbNkkyOJyURXOI();
			AhflBnFEPxhpCqnhzGTMZAnejxau.Clear();
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			if (AhflBnFEPxhpCqnhzGTMZAnejxau.TryGetValue(key, out var value))
			{
				return value is IGetSetValue<TValue>;
			}
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			if (!TryGetValue<TValue>(key, out var value))
			{
				ckiFzqsSZBpvLbUBRrFREMggxOPb(key, typeof(TValue));
			}
			return value;
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (!TrySetValue(key, value))
			{
				ckiFzqsSZBpvLbUBRrFREMggxOPb(key, typeof(TValue));
			}
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			if (!AhflBnFEPxhpCqnhzGTMZAnejxau.TryGetValue(key, out var value2) || !(value2 is IGetValue<TValue> getValue))
			{
				value = default(TValue);
				Logger.LogError(ngqWhBOkoZaMtdxMznXyIvvpTIYbA(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			value = getValue.GetValue();
			return true;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			ISetValue<TValue> setValue;
			if (!AhflBnFEPxhpCqnhzGTMZAnejxau.TryGetValue(key, out var value2) || (setValue = value2 as GetSetValue<TValue>) == null)
			{
				Logger.LogError(ngqWhBOkoZaMtdxMznXyIvvpTIYbA(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			setValue.SetValue(value);
			return true;
		}

		private void KRGqwkrdDvHUSaLbNkkyOJyURXOI()
		{
			if (TQmbEaCeMLCvvLLtjsIDVewumFpqA)
			{
				throw new Exception("The collection is read-only.");
			}
		}

		private static void ckiFzqsSZBpvLbUBRrFREMggxOPb(TKey P_0, Type P_1)
		{
			throw new Exception(ngqWhBOkoZaMtdxMznXyIvvpTIYbA(P_0, P_1));
		}

		private static string ngqWhBOkoZaMtdxMznXyIvvpTIYbA(TKey P_0, Type P_1)
		{
			string[] obj = new string[5] { "Value with key ", null, null, null, null };
			TKey val = P_0;
			obj[1] = val?.ToString();
			obj[2] = " of type ";
			obj[3] = P_1?.ToString();
			obj[4] = " not found.";
			return string.Concat(obj);
		}

		private void tKTtRbShUEScgYJWmOVLnlRUfYuG(TKey P_0, object P_1)
		{
			KRGqwkrdDvHUSaLbNkkyOJyURXOI();
			AhflBnFEPxhpCqnhzGTMZAnejxau.Add(P_0, P_1);
		}

		void IDictionary<TKey, object>.Add(TKey P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in tKTtRbShUEScgYJWmOVLnlRUfYuG
			this.tKTtRbShUEScgYJWmOVLnlRUfYuG(P_0, P_1);
		}

		private bool IEXkdePNZFXXXlHSaRpjAdvRFXjQ(TKey P_0)
		{
			return ContainsKey(P_0);
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IEXkdePNZFXXXlHSaRpjAdvRFXjQ
			return this.IEXkdePNZFXXXlHSaRpjAdvRFXjQ(P_0);
		}

		private bool RYhcBNGjRlmvqgMwLvFvxIajGHitA(TKey P_0)
		{
			KRGqwkrdDvHUSaLbNkkyOJyURXOI();
			return AhflBnFEPxhpCqnhzGTMZAnejxau.Remove(P_0);
		}

		bool IDictionary<TKey, object>.Remove(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RYhcBNGjRlmvqgMwLvFvxIajGHitA
			return this.RYhcBNGjRlmvqgMwLvFvxIajGHitA(P_0);
		}

		private bool ZpraOrgJzZdGnRIVbrewJbvIpjbRA(TKey P_0, out object P_1)
		{
			return AhflBnFEPxhpCqnhzGTMZAnejxau.TryGetValue(P_0, out P_1);
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ZpraOrgJzZdGnRIVbrewJbvIpjbRA
			return this.ZpraOrgJzZdGnRIVbrewJbvIpjbRA(P_0, out P_1);
		}

		private void NfCLDGxdbXvFnoiEEuAPiAojbzKS(KeyValuePair<TKey, object> P_0)
		{
			KRGqwkrdDvHUSaLbNkkyOJyURXOI();
			((ICollection<KeyValuePair<TKey, object>>)AhflBnFEPxhpCqnhzGTMZAnejxau).Add(P_0);
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NfCLDGxdbXvFnoiEEuAPiAojbzKS
			this.NfCLDGxdbXvFnoiEEuAPiAojbzKS(P_0);
		}

		private void bQMfTbAGFKpFAOkmpqOnkTZPwnog()
		{
			KRGqwkrdDvHUSaLbNkkyOJyURXOI();
			((ICollection<KeyValuePair<TKey, object>>)AhflBnFEPxhpCqnhzGTMZAnejxau).Clear();
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in bQMfTbAGFKpFAOkmpqOnkTZPwnog
			this.bQMfTbAGFKpFAOkmpqOnkTZPwnog();
		}

		private bool YALfiTbTUJDbVMnrVgMycaPCVMBBA(KeyValuePair<TKey, object> P_0)
		{
			return ((ICollection<KeyValuePair<TKey, object>>)AhflBnFEPxhpCqnhzGTMZAnejxau).Contains(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in YALfiTbTUJDbVMnrVgMycaPCVMBBA
			return this.YALfiTbTUJDbVMnrVgMycaPCVMBBA(P_0);
		}

		private void tUSPGHcRQiWTdZTWNBzqKHuXkCSh(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			((ICollection<KeyValuePair<TKey, object>>)AhflBnFEPxhpCqnhzGTMZAnejxau).CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in tUSPGHcRQiWTdZTWNBzqKHuXkCSh
			this.tUSPGHcRQiWTdZTWNBzqKHuXkCSh(P_0, P_1);
		}

		private bool mqpFOtQjVWklTlUuIxkFrCgZRAtF(KeyValuePair<TKey, object> P_0)
		{
			KRGqwkrdDvHUSaLbNkkyOJyURXOI();
			return ((ICollection<KeyValuePair<TKey, object>>)AhflBnFEPxhpCqnhzGTMZAnejxau).Remove(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in mqpFOtQjVWklTlUuIxkFrCgZRAtF
			return this.mqpFOtQjVWklTlUuIxkFrCgZRAtF(P_0);
		}

		private IEnumerator<KeyValuePair<TKey, object>> duxTnlAzGAeAyaQrCZJawqQdyqNS()
		{
			return AhflBnFEPxhpCqnhzGTMZAnejxau.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in duxTnlAzGAeAyaQrCZJawqQdyqNS
			return this.duxTnlAzGAeAyaQrCZJawqQdyqNS();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return AhflBnFEPxhpCqnhzGTMZAnejxau.GetEnumerator();
		}
	}
}
