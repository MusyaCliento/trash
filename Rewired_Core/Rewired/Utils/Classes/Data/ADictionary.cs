using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[DefaultMember("Item")]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ADictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>
	{
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		internal struct Entry
		{
			public int hashCode;

			public int next;

			public TKey key;

			public TValue value;
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private ADictionary<TKey, TValue> gGoSAMaAUmSPpXTnaeyUFatBrtzy;

			private int nPDFtBLqEjYLwAcIzWxAUSLxbaGD;

			private int ntqgKmixJsXySeziEMCZTnniWBglA;

			private KeyValuePair<TKey, TValue> qWrzhEOANVLAEuEnhxtSBpOqnciR;

			private int nRByEfxIWzgyNEAlcijEjEIMMADt;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => qWrzhEOANVLAEuEnhxtSBpOqnciR;

			object IEnumerator.Current
			{
				get
				{
					if (ntqgKmixJsXySeziEMCZTnniWBglA == 0 || ntqgKmixJsXySeziEMCZTnniWBglA == gGoSAMaAUmSPpXTnaeyUFatBrtzy._count + 1)
					{
						throw new Exception();
					}
					if (nRByEfxIWzgyNEAlcijEjEIMMADt == 1)
					{
						return new DictionaryEntry(qWrzhEOANVLAEuEnhxtSBpOqnciR.Key, qWrzhEOANVLAEuEnhxtSBpOqnciR.Value);
					}
					return new KeyValuePair<TKey, TValue>(qWrzhEOANVLAEuEnhxtSBpOqnciR.Key, qWrzhEOANVLAEuEnhxtSBpOqnciR.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (ntqgKmixJsXySeziEMCZTnniWBglA == 0 || ntqgKmixJsXySeziEMCZTnniWBglA == gGoSAMaAUmSPpXTnaeyUFatBrtzy._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(qWrzhEOANVLAEuEnhxtSBpOqnciR.Key, qWrzhEOANVLAEuEnhxtSBpOqnciR.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (ntqgKmixJsXySeziEMCZTnniWBglA == 0 || ntqgKmixJsXySeziEMCZTnniWBglA == gGoSAMaAUmSPpXTnaeyUFatBrtzy._count + 1)
					{
						throw new Exception();
					}
					return qWrzhEOANVLAEuEnhxtSBpOqnciR.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (ntqgKmixJsXySeziEMCZTnniWBglA == 0 || ntqgKmixJsXySeziEMCZTnniWBglA == gGoSAMaAUmSPpXTnaeyUFatBrtzy._count + 1)
					{
						throw new Exception();
					}
					return qWrzhEOANVLAEuEnhxtSBpOqnciR.Value;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> P_0, int P_1)
			{
				gGoSAMaAUmSPpXTnaeyUFatBrtzy = P_0;
				nPDFtBLqEjYLwAcIzWxAUSLxbaGD = P_0.TuyHWqAhRfLkHNKUzwtBuAtFfdew;
				ntqgKmixJsXySeziEMCZTnniWBglA = 0;
				nRByEfxIWzgyNEAlcijEjEIMMADt = P_1;
				qWrzhEOANVLAEuEnhxtSBpOqnciR = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (nPDFtBLqEjYLwAcIzWxAUSLxbaGD != gGoSAMaAUmSPpXTnaeyUFatBrtzy.TuyHWqAhRfLkHNKUzwtBuAtFfdew)
				{
					throw new Exception();
				}
				while ((uint)ntqgKmixJsXySeziEMCZTnniWBglA < (uint)gGoSAMaAUmSPpXTnaeyUFatBrtzy._count)
				{
					if (gGoSAMaAUmSPpXTnaeyUFatBrtzy._entries[ntqgKmixJsXySeziEMCZTnniWBglA].hashCode >= 0)
					{
						qWrzhEOANVLAEuEnhxtSBpOqnciR = new KeyValuePair<TKey, TValue>(gGoSAMaAUmSPpXTnaeyUFatBrtzy._entries[ntqgKmixJsXySeziEMCZTnniWBglA].key, gGoSAMaAUmSPpXTnaeyUFatBrtzy._entries[ntqgKmixJsXySeziEMCZTnniWBglA].value);
						ntqgKmixJsXySeziEMCZTnniWBglA++;
						return true;
					}
					ntqgKmixJsXySeziEMCZTnniWBglA++;
				}
				ntqgKmixJsXySeziEMCZTnniWBglA = gGoSAMaAUmSPpXTnaeyUFatBrtzy._count + 1;
				qWrzhEOANVLAEuEnhxtSBpOqnciR = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			public void Dispose()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			void IEnumerator.Reset()
			{
				if (nPDFtBLqEjYLwAcIzWxAUSLxbaGD != gGoSAMaAUmSPpXTnaeyUFatBrtzy.TuyHWqAhRfLkHNKUzwtBuAtFfdew)
				{
					throw new Exception();
				}
				ntqgKmixJsXySeziEMCZTnniWBglA = 0;
				qWrzhEOANVLAEuEnhxtSBpOqnciR = default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, ICollection
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			public struct Enumerator : IEnumerator<TKey>, IEnumerator, IDisposable
			{
				private ADictionary<TKey, TValue> boYhMspBuAuDLPpiFfYbFOEABhQL;

				private int jCUbKRuPUyIgIuuewWajMcGNOQPV;

				private int YnvZUiJPgaBltdaKSFIlfWpgayjec;

				private TKey ltuYRhMVLQqzqOqlhSodfUIWlQhb;

				TKey IEnumerator<TKey>.Current => ltuYRhMVLQqzqOqlhSodfUIWlQhb;

				object IEnumerator.Current
				{
					get
					{
						if (jCUbKRuPUyIgIuuewWajMcGNOQPV == 0 || jCUbKRuPUyIgIuuewWajMcGNOQPV == boYhMspBuAuDLPpiFfYbFOEABhQL._count + 1)
						{
							throw new Exception();
						}
						return ltuYRhMVLQqzqOqlhSodfUIWlQhb;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					boYhMspBuAuDLPpiFfYbFOEABhQL = P_0;
					YnvZUiJPgaBltdaKSFIlfWpgayjec = P_0.TuyHWqAhRfLkHNKUzwtBuAtFfdew;
					jCUbKRuPUyIgIuuewWajMcGNOQPV = 0;
					ltuYRhMVLQqzqOqlhSodfUIWlQhb = default(TKey);
				}

				public void Dispose()
				{
				}

				void IDisposable.Dispose()
				{
					//ILSpy generated this explicit interface implementation from .override directive in Dispose
					this.Dispose();
				}

				public bool MoveNext()
				{
					if (YnvZUiJPgaBltdaKSFIlfWpgayjec != boYhMspBuAuDLPpiFfYbFOEABhQL.TuyHWqAhRfLkHNKUzwtBuAtFfdew)
					{
						throw new Exception();
					}
					while ((uint)jCUbKRuPUyIgIuuewWajMcGNOQPV < (uint)boYhMspBuAuDLPpiFfYbFOEABhQL._count)
					{
						if (boYhMspBuAuDLPpiFfYbFOEABhQL._entries[jCUbKRuPUyIgIuuewWajMcGNOQPV].hashCode >= 0)
						{
							ltuYRhMVLQqzqOqlhSodfUIWlQhb = boYhMspBuAuDLPpiFfYbFOEABhQL._entries[jCUbKRuPUyIgIuuewWajMcGNOQPV].key;
							jCUbKRuPUyIgIuuewWajMcGNOQPV++;
							return true;
						}
						jCUbKRuPUyIgIuuewWajMcGNOQPV++;
					}
					jCUbKRuPUyIgIuuewWajMcGNOQPV = boYhMspBuAuDLPpiFfYbFOEABhQL._count + 1;
					ltuYRhMVLQqzqOqlhSodfUIWlQhb = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (YnvZUiJPgaBltdaKSFIlfWpgayjec != boYhMspBuAuDLPpiFfYbFOEABhQL.TuyHWqAhRfLkHNKUzwtBuAtFfdew)
					{
						throw new Exception();
					}
					jCUbKRuPUyIgIuuewWajMcGNOQPV = 0;
					ltuYRhMVLQqzqOqlhSodfUIWlQhb = default(TKey);
				}
			}

			private ADictionary<TKey, TValue> AcktOtjRWJEKLBMpXrkEBOBnyfvp;

			int ICollection<TKey>.Count => AcktOtjRWJEKLBMpXrkEBOBnyfvp.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)AcktOtjRWJEKLBMpXrkEBOBnyfvp).SyncRoot;

			public KeyCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				AcktOtjRWJEKLBMpXrkEBOBnyfvp = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(AcktOtjRWJEKLBMpXrkEBOBnyfvp);
			}

			public void CopyTo(TKey[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (index < 0 || index > array.Length)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				if (array.Length - index < AcktOtjRWJEKLBMpXrkEBOBnyfvp.Count)
				{
					throw new Exception();
				}
				int count = AcktOtjRWJEKLBMpXrkEBOBnyfvp._count;
				Entry[] entries = AcktOtjRWJEKLBMpXrkEBOBnyfvp._entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].key;
					}
				}
			}

			void ICollection<TKey>.CopyTo(TKey[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void YgjbQJmNqMRwrdlXCTmNviedfmtl(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in YgjbQJmNqMRwrdlXCTmNviedfmtl
				this.YgjbQJmNqMRwrdlXCTmNviedfmtl(P_0);
			}

			private void PgyaRqiwpkJsUBWTqShvpPQvgVHrA()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in PgyaRqiwpkJsUBWTqShvpPQvgVHrA
				this.PgyaRqiwpkJsUBWTqShvpPQvgVHrA();
			}

			private bool NaMadOEEMKaIjNODFAxWwZoLHMrd(TKey P_0)
			{
				return AcktOtjRWJEKLBMpXrkEBOBnyfvp.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in NaMadOEEMKaIjNODFAxWwZoLHMrd
				return this.NaMadOEEMKaIjNODFAxWwZoLHMrd(P_0);
			}

			private bool UjNIEHTdYkAlLDtQMtWgwEtJcdNc(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in UjNIEHTdYkAlLDtQMtWgwEtJcdNc
				return this.UjNIEHTdYkAlLDtQMtWgwEtJcdNc(P_0);
			}

			private IEnumerator<TKey> bQgwVPZRjPfWQmYIHKqsToZFxHgN()
			{
				return new Enumerator(AcktOtjRWJEKLBMpXrkEBOBnyfvp);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in bQgwVPZRjPfWQmYIHKqsToZFxHgN
				return this.bQgwVPZRjPfWQmYIHKqsToZFxHgN();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(AcktOtjRWJEKLBMpXrkEBOBnyfvp);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (array.Rank != 1)
				{
					throw new Exception();
				}
				if (array.GetLowerBound(0) != 0)
				{
					throw new Exception();
				}
				if (index < 0 || index > array.Length)
				{
					throw new Exception();
				}
				if (array.Length - index < AcktOtjRWJEKLBMpXrkEBOBnyfvp.Count)
				{
					throw new Exception();
				}
				if (array is TKey[] array2)
				{
					CopyTo(array2, index);
					return;
				}
				if (!(array is object[] array3))
				{
					throw new Exception();
				}
				int count = AcktOtjRWJEKLBMpXrkEBOBnyfvp._count;
				Entry[] entries = AcktOtjRWJEKLBMpXrkEBOBnyfvp._entries;
				try
				{
					for (int i = 0; i < count; i++)
					{
						if (entries[i].hashCode >= 0)
						{
							array3[index++] = entries[i].key;
						}
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
			{
				private ADictionary<TKey, TValue> wuCqEOxSlsIhhJfMscxPdttDUGJJA;

				private int nYTlWEvdcAEjwEZGYaZYVhCzclbH;

				private int KgERimRRnVPNuqcPkFNimGtMltNd;

				private TValue SoQQebaIIjunSMmSamBGkIVHCsXE;

				TValue IEnumerator<TValue>.Current => SoQQebaIIjunSMmSamBGkIVHCsXE;

				object IEnumerator.Current
				{
					get
					{
						if (nYTlWEvdcAEjwEZGYaZYVhCzclbH == 0 || nYTlWEvdcAEjwEZGYaZYVhCzclbH == wuCqEOxSlsIhhJfMscxPdttDUGJJA._count + 1)
						{
							throw new Exception();
						}
						return SoQQebaIIjunSMmSamBGkIVHCsXE;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					wuCqEOxSlsIhhJfMscxPdttDUGJJA = P_0;
					KgERimRRnVPNuqcPkFNimGtMltNd = P_0.TuyHWqAhRfLkHNKUzwtBuAtFfdew;
					nYTlWEvdcAEjwEZGYaZYVhCzclbH = 0;
					SoQQebaIIjunSMmSamBGkIVHCsXE = default(TValue);
				}

				public void Dispose()
				{
				}

				void IDisposable.Dispose()
				{
					//ILSpy generated this explicit interface implementation from .override directive in Dispose
					this.Dispose();
				}

				public bool MoveNext()
				{
					if (KgERimRRnVPNuqcPkFNimGtMltNd != wuCqEOxSlsIhhJfMscxPdttDUGJJA.TuyHWqAhRfLkHNKUzwtBuAtFfdew)
					{
						throw new Exception();
					}
					while ((uint)nYTlWEvdcAEjwEZGYaZYVhCzclbH < (uint)wuCqEOxSlsIhhJfMscxPdttDUGJJA._count)
					{
						if (wuCqEOxSlsIhhJfMscxPdttDUGJJA._entries[nYTlWEvdcAEjwEZGYaZYVhCzclbH].hashCode >= 0)
						{
							SoQQebaIIjunSMmSamBGkIVHCsXE = wuCqEOxSlsIhhJfMscxPdttDUGJJA._entries[nYTlWEvdcAEjwEZGYaZYVhCzclbH].value;
							nYTlWEvdcAEjwEZGYaZYVhCzclbH++;
							return true;
						}
						nYTlWEvdcAEjwEZGYaZYVhCzclbH++;
					}
					nYTlWEvdcAEjwEZGYaZYVhCzclbH = wuCqEOxSlsIhhJfMscxPdttDUGJJA._count + 1;
					SoQQebaIIjunSMmSamBGkIVHCsXE = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (KgERimRRnVPNuqcPkFNimGtMltNd != wuCqEOxSlsIhhJfMscxPdttDUGJJA.TuyHWqAhRfLkHNKUzwtBuAtFfdew)
					{
						throw new Exception();
					}
					nYTlWEvdcAEjwEZGYaZYVhCzclbH = 0;
					SoQQebaIIjunSMmSamBGkIVHCsXE = default(TValue);
				}
			}

			private ADictionary<TKey, TValue> RBOEQdizvvvTcqyudXEgZlSKUubg;

			int ICollection.Count => RBOEQdizvvvTcqyudXEgZlSKUubg.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)RBOEQdizvvvTcqyudXEgZlSKUubg).SyncRoot;

			public ValueCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				RBOEQdizvvvTcqyudXEgZlSKUubg = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(RBOEQdizvvvTcqyudXEgZlSKUubg);
			}

			public void CopyTo(TValue[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (index < 0 || index > array.Length)
				{
					throw new Exception();
				}
				if (array.Length - index < RBOEQdizvvvTcqyudXEgZlSKUubg.Count)
				{
					throw new Exception();
				}
				int count = RBOEQdizvvvTcqyudXEgZlSKUubg._count;
				Entry[] entries = RBOEQdizvvvTcqyudXEgZlSKUubg._entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].value;
					}
				}
			}

			void ICollection<TValue>.CopyTo(TValue[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void wRtZhjLComKkwdooNUABfnzmNaif(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in wRtZhjLComKkwdooNUABfnzmNaif
				this.wRtZhjLComKkwdooNUABfnzmNaif(P_0);
			}

			private bool rdZAiFUMqZdFTZTNkNyPvDElaFru(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in rdZAiFUMqZdFTZTNkNyPvDElaFru
				return this.rdZAiFUMqZdFTZTNkNyPvDElaFru(P_0);
			}

			private void JIpJVzLBCWKtrsKSGYEVFGcJmMqc()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in JIpJVzLBCWKtrsKSGYEVFGcJmMqc
				this.JIpJVzLBCWKtrsKSGYEVFGcJmMqc();
			}

			private bool pSLxPqxFVpbITYinMaNAdhWijGHN(TValue P_0)
			{
				return RBOEQdizvvvTcqyudXEgZlSKUubg.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in pSLxPqxFVpbITYinMaNAdhWijGHN
				return this.pSLxPqxFVpbITYinMaNAdhWijGHN(P_0);
			}

			private IEnumerator<TValue> rLxtrPSaFZIUfnHRvMkgGVLIGEif()
			{
				return new Enumerator(RBOEQdizvvvTcqyudXEgZlSKUubg);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in rLxtrPSaFZIUfnHRvMkgGVLIGEif
				return this.rLxtrPSaFZIUfnHRvMkgGVLIGEif();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(RBOEQdizvvvTcqyudXEgZlSKUubg);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (array.Rank != 1)
				{
					throw new Exception();
				}
				if (array.GetLowerBound(0) != 0)
				{
					throw new Exception();
				}
				if (index < 0 || index > array.Length)
				{
					throw new Exception();
				}
				if (array.Length - index < RBOEQdizvvvTcqyudXEgZlSKUubg.Count)
				{
					throw new Exception();
				}
				if (array is TValue[] array2)
				{
					CopyTo(array2, index);
					return;
				}
				if (!(array is object[] array3))
				{
					throw new Exception();
				}
				int count = RBOEQdizvvvTcqyudXEgZlSKUubg._count;
				Entry[] entries = RBOEQdizvvvTcqyudXEgZlSKUubg._entries;
				try
				{
					for (int i = 0; i < count; i++)
					{
						if (entries[i].hashCode >= 0)
						{
							array3[index++] = entries[i].value;
						}
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private int[] PigvmRcBKVdmYVsFoRTmDCOlvEVD;

		internal Entry[] _entries;

		internal int _count;

		private int TuyHWqAhRfLkHNKUzwtBuAtFfdew;

		private int SQrAyFiCBrUbHkJxuKGAxKEkSpDD;

		private int EIUGhtfRftUUAkJIkPXbDiKdyprwb;

		private int OWNgdyiVhCVOvFKychejwFcCkulh;

		private IEqualityComparer<TKey> NKnHjqACKgnOhoBSglvWXhlwSnRC;

		private IEqualityComparer<TValue> fFkeGMtAwwgZAdcrWJzFCRgsMNywA;

		private KeyCollection pJFpCZnUyLdqZjHttJhqeCSCFMGn;

		private ValueCollection gSWEkCCTiqcQVYUjFtUgZNuliYQh;

		private readonly object vwydkCNwfdexKcvvsLrpsBxMBgucA = new object();

		private static readonly bool vuwIRMpBrJRgRjEoOaTHDCPJcaKW = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool RwpHMmUsSNSJwsHwPFwVVFYbCxNE = ReflectionTools.IsValueType(typeof(TValue));

		private const string ilMabrtpoLjOoxOinyUwcdvjeSls = "Version";

		private const string ezpVLBWCpDQgdDkzeueGeZbsnIGW = "HashSize";

		private const string vsAAUxAtIdUCpFvgyQWVXoGtHZSG = "KeyValuePairs";

		private const string TuHGxnriCHaiGcaVOwFEwoOeXhrZ = "Comparer";

		int ICollection<KeyValuePair<TKey, TValue>>.Count => _count - OWNgdyiVhCVOvFKychejwFcCkulh;

		public int TotalCount => _count;

		public KeyCollection Keys
		{
			get
			{
				if (pJFpCZnUyLdqZjHttJhqeCSCFMGn == null)
				{
					pJFpCZnUyLdqZjHttJhqeCSCFMGn = new KeyCollection(this);
				}
				return pJFpCZnUyLdqZjHttJhqeCSCFMGn;
			}
		}

		public ValueCollection Values
		{
			get
			{
				if (gSWEkCCTiqcQVYUjFtUgZNuliYQh == null)
				{
					gSWEkCCTiqcQVYUjFtUgZNuliYQh = new ValueCollection(this);
				}
				return gSWEkCCTiqcQVYUjFtUgZNuliYQh;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return NKnHjqACKgnOhoBSglvWXhlwSnRC;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				NKnHjqACKgnOhoBSglvWXhlwSnRC = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return fFkeGMtAwwgZAdcrWJzFCRgsMNywA;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				fFkeGMtAwwgZAdcrWJzFCRgsMNywA = value;
			}
		}

		TValue IDictionary<TKey, TValue>.this[TKey key]
		{
			get
			{
				int num = IndexOfKey(key);
				if (num < 0)
				{
					TKey val = key;
					throw new KeyNotFoundException("Key \"" + val?.ToString() + " does not exist.");
				}
				return _entries[num].value;
			}
			set
			{
				fbYInSnIjhBvrdeFoAJkWLjugntS(key, value, false);
			}
		}

		public int IndexOfFirst
		{
			get
			{
				for (int i = 0; i < _count; i++)
				{
					if (_entries[i].hashCode >= 0)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public int IndexOfLast
		{
			get
			{
				for (int num = _count - 1; num >= 0; num--)
				{
					if (_entries[num].hashCode >= 0)
					{
						return num;
					}
				}
				return -1;
			}
		}

		ICollection<TKey> IDictionary<TKey, TValue>.Keys
		{
			get
			{
				if (pJFpCZnUyLdqZjHttJhqeCSCFMGn == null)
				{
					pJFpCZnUyLdqZjHttJhqeCSCFMGn = new KeyCollection(this);
				}
				return pJFpCZnUyLdqZjHttJhqeCSCFMGn;
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				if (gSWEkCCTiqcQVYUjFtUgZNuliYQh == null)
				{
					gSWEkCCTiqcQVYUjFtUgZNuliYQh = new ValueCollection(this);
				}
				return gSWEkCCTiqcQVYUjFtUgZNuliYQh;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => vwydkCNwfdexKcvvsLrpsBxMBgucA;

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => Keys;

		ICollection IDictionary.Values => Values;

		object IDictionary.this[object key]
		{
			get
			{
				if (LGqQlIRhChFRecsCxDdJEUvFCJAq(key))
				{
					int num = IndexOfKey((TKey)key);
					if (num >= 0)
					{
						return _entries[num].value;
					}
				}
				return null;
			}
			set
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				BAXBkTBCEOoYZBIjdPnqFNEdISkDc<TValue>(value, "value");
				try
				{
					TKey val = (TKey)key;
					try
					{
						this[val] = (TValue)value;
					}
					catch (InvalidCastException)
					{
						throw new Exception();
					}
				}
				catch (InvalidCastException)
				{
					throw new Exception();
				}
			}
		}

		ICollection<TKey> Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

		ICollection<TValue> Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.Values => Values;

		public ADictionary()
			: this(0, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IEqualityComparer<TKey> P_0)
			: this(0, P_0, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IEqualityComparer<TKey> P_0, IEqualityComparer<TValue> P_1)
			: this(0, P_0, P_1)
		{
		}

		public ADictionary(int P_0)
			: this(P_0, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(int P_0, IEqualityComparer<TKey> P_1)
			: this(P_0, P_1, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(int P_0, IEqualityComparer<TKey> P_1, IEqualityComparer<TValue> P_2)
		{
			if (P_0 < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			if (P_0 > 0)
			{
				kShqHxsMiealeDcZLufDObiBrcc(P_0);
			}
			NKnHjqACKgnOhoBSglvWXhlwSnRC = P_1 ?? EqualityComparerNoAlloc<TKey>.Default;
			fFkeGMtAwwgZAdcrWJzFCRgsMNywA = P_2 ?? EqualityComparerNoAlloc<TValue>.Default;
		}

		public ADictionary(IDictionary<TKey, TValue> P_0)
			: this(P_0, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> P_0, IEqualityComparer<TKey> P_1)
			: this(P_0, P_1, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> P_0, IEqualityComparer<TKey> P_1, IEqualityComparer<TValue> P_2)
			: this(P_0?.Count ?? 0, P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			foreach (KeyValuePair<TKey, TValue> item in P_0)
			{
				Add(item.Key, item.Value);
			}
		}

		public void Add(TKey key, TValue value)
		{
			fbYInSnIjhBvrdeFoAJkWLjugntS(key, value, true);
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(key, value);
		}

		public void Clear()
		{
			if (_count > 0)
			{
				for (int i = 0; i < PigvmRcBKVdmYVsFoRTmDCOlvEVD.Length; i++)
				{
					PigvmRcBKVdmYVsFoRTmDCOlvEVD[i] = -1;
				}
				Array.Clear(_entries, 0, _count);
				EIUGhtfRftUUAkJIkPXbDiKdyprwb = -1;
				_count = 0;
				OWNgdyiVhCVOvFKychejwFcCkulh = 0;
				TuyHWqAhRfLkHNKUzwtBuAtFfdew++;
				SQrAyFiCBrUbHkJxuKGAxKEkSpDD++;
			}
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		void IDictionary.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		public bool ContainsKey(TKey key)
		{
			return IndexOfKey(key) >= 0;
		}

		bool IDictionary<TKey, TValue>.ContainsKey(TKey key)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ContainsKey
			return this.ContainsKey(key);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.ContainsKey(TKey key)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ContainsKey
			return this.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return IndexOfValue(value) >= 0;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this, 2);
		}

		public bool Remove(TKey key)
		{
			if (!vuwIRMpBrJRgRjEoOaTHDCPJcaKW && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (PigvmRcBKVdmYVsFoRTmDCOlvEVD != null)
			{
				int num = NKnHjqACKgnOhoBSglvWXhlwSnRC.GetHashCode(key) & 0x7FFFFFFF;
				int num2 = num % PigvmRcBKVdmYVsFoRTmDCOlvEVD.Length;
				int num3 = -1;
				for (int num4 = PigvmRcBKVdmYVsFoRTmDCOlvEVD[num2]; num4 >= 0; num4 = _entries[num4].next)
				{
					if (_entries[num4].hashCode == num && NKnHjqACKgnOhoBSglvWXhlwSnRC.Equals(_entries[num4].key, key))
					{
						if (num3 < 0)
						{
							PigvmRcBKVdmYVsFoRTmDCOlvEVD[num2] = _entries[num4].next;
						}
						else
						{
							_entries[num3].next = _entries[num4].next;
						}
						_entries[num4].hashCode = -1;
						_entries[num4].next = EIUGhtfRftUUAkJIkPXbDiKdyprwb;
						_entries[num4].key = default(TKey);
						_entries[num4].value = default(TValue);
						EIUGhtfRftUUAkJIkPXbDiKdyprwb = num4;
						OWNgdyiVhCVOvFKychejwFcCkulh++;
						TuyHWqAhRfLkHNKUzwtBuAtFfdew++;
						return true;
					}
					num3 = num4;
				}
			}
			return false;
		}

		bool IDictionary<TKey, TValue>.Remove(TKey key)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Remove
			return this.Remove(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			int num = IndexOfKey(key);
			if (num >= 0)
			{
				value = _entries[num].value;
				return true;
			}
			value = default(TValue);
			return false;
		}

		bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
			return this.TryGetValue(key, out value);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
			return this.TryGetValue(key, out value);
		}

		public TValue GetValueSafe(TKey key)
		{
			int num = IndexOfKey(key);
			if (num >= 0)
			{
				return _entries[num].value;
			}
			return default(TValue);
		}

		public int IndexOfKey(TKey key)
		{
			if (!vuwIRMpBrJRgRjEoOaTHDCPJcaKW && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (PigvmRcBKVdmYVsFoRTmDCOlvEVD != null)
			{
				int num = NKnHjqACKgnOhoBSglvWXhlwSnRC.GetHashCode(key) & 0x7FFFFFFF;
				for (int num2 = PigvmRcBKVdmYVsFoRTmDCOlvEVD[num % PigvmRcBKVdmYVsFoRTmDCOlvEVD.Length]; num2 >= 0; num2 = _entries[num2].next)
				{
					if (_entries[num2].hashCode == num && NKnHjqACKgnOhoBSglvWXhlwSnRC.Equals(_entries[num2].key, key))
					{
						return num2;
					}
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			Entry[] entries = _entries;
			if (!RwpHMmUsSNSJwsHwPFwVVFYbCxNE && value == null)
			{
				for (int i = 0; i < _count; i++)
				{
					if (entries[i].hashCode >= 0 && entries[i].value == null)
					{
						return i;
					}
				}
			}
			else
			{
				IEqualityComparer<TValue> equalityComparer = fFkeGMtAwwgZAdcrWJzFCRgsMNywA;
				for (int j = 0; j < _count; j++)
				{
					if (entries[j].hashCode >= 0 && equalityComparer.Equals(entries[j].value, value))
					{
						return j;
					}
				}
			}
			return -1;
		}

		public bool IsValidAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				return false;
			}
			return _entries[index].hashCode >= 0;
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			return _entries[index].key;
		}

		public TValue GetValueAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			return _entries[index].value;
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			return new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
		}

		public bool TryGetKeyAt(int index, out TKey key)
		{
			if ((uint)index >= (uint)_count || _entries[index].hashCode < 0)
			{
				key = default(TKey);
				return false;
			}
			key = _entries[index].key;
			return true;
		}

		public bool TryGetValueAt(int index, out TValue value)
		{
			if ((uint)index >= (uint)_count || _entries[index].hashCode < 0)
			{
				value = default(TValue);
				return false;
			}
			value = _entries[index].value;
			return true;
		}

		public bool TryGetEntryAt(int index, out KeyValuePair<TKey, TValue> entry)
		{
			if ((uint)index >= (uint)_count || _entries[index].hashCode < 0)
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
			return true;
		}

		public bool GetNextIndex(ref int index)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				return false;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					return true;
				}
				index++;
			}
			return false;
		}

		public int GetNextIndex(int index)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				return -1;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					return index;
				}
				index++;
			}
			return -1;
		}

		public bool GetNextKey(ref int index, out TKey key)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				key = default(TKey);
				return false;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					key = _entries[index].key;
					return true;
				}
				index++;
			}
			key = default(TKey);
			return false;
		}

		public bool GetNextValue(ref int index, out TValue value)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				value = default(TValue);
				return false;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					value = _entries[index].value;
					return true;
				}
				index++;
			}
			value = default(TValue);
			return false;
		}

		public bool GetNextEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
					return true;
				}
				index++;
			}
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public bool GetPreviousIndex(ref int index)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				return false;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					return true;
				}
				index--;
			}
			return false;
		}

		public int GetPreviousIndex(int index)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				return -1;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					return index;
				}
				index--;
			}
			return -1;
		}

		public bool GetPreviousKey(ref int index, out TKey key)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				key = default(TKey);
				return false;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					key = _entries[index].key;
					return true;
				}
				index--;
			}
			key = default(TKey);
			return false;
		}

		public bool GetPreviousValue(ref int index, out TValue value)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				value = default(TValue);
				return false;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					value = _entries[index].value;
					return true;
				}
				index--;
			}
			value = default(TValue);
			return false;
		}

		public bool GetPreviousEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
					return true;
				}
				index--;
			}
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public bool RemoveAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_entries[index].hashCode < 0)
			{
				return false;
			}
			Remove(_entries[index].key);
			return true;
		}

		private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (array.Length - index < this.Count)
			{
				throw new Exception();
			}
			int count = _count;
			Entry[] entries = _entries;
			for (int i = 0; i < count; i++)
			{
				if (entries[i].hashCode >= 0)
				{
					array[index++] = new KeyValuePair<TKey, TValue>(entries[i].key, entries[i].value);
				}
			}
		}

		private void kShqHxsMiealeDcZLufDObiBrcc(int P_0)
		{
			int num = nIBSeJMOBspBUIQEdwONqcsGBAnbA.uTuzgouanUAtlDFBPrUXgdQLedBrA(P_0);
			PigvmRcBKVdmYVsFoRTmDCOlvEVD = new int[num];
			for (int i = 0; i < PigvmRcBKVdmYVsFoRTmDCOlvEVD.Length; i++)
			{
				PigvmRcBKVdmYVsFoRTmDCOlvEVD[i] = -1;
			}
			_entries = new Entry[num];
			EIUGhtfRftUUAkJIkPXbDiKdyprwb = -1;
		}

		private void fbYInSnIjhBvrdeFoAJkWLjugntS(TKey P_0, TValue P_1, bool P_2)
		{
			if (!vuwIRMpBrJRgRjEoOaTHDCPJcaKW && P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			if (PigvmRcBKVdmYVsFoRTmDCOlvEVD == null)
			{
				kShqHxsMiealeDcZLufDObiBrcc(0);
			}
			int num = NKnHjqACKgnOhoBSglvWXhlwSnRC.GetHashCode(P_0) & 0x7FFFFFFF;
			int num2 = num % PigvmRcBKVdmYVsFoRTmDCOlvEVD.Length;
			for (int num3 = PigvmRcBKVdmYVsFoRTmDCOlvEVD[num2]; num3 >= 0; num3 = _entries[num3].next)
			{
				if (_entries[num3].hashCode == num && NKnHjqACKgnOhoBSglvWXhlwSnRC.Equals(_entries[num3].key, P_0))
				{
					if (P_2)
					{
						throw new ArgumentException("An element with the same key already exists in the dictionary.");
					}
					_entries[num3].value = P_1;
					TuyHWqAhRfLkHNKUzwtBuAtFfdew++;
					return;
				}
			}
			int num4;
			if (OWNgdyiVhCVOvFKychejwFcCkulh > 0)
			{
				num4 = EIUGhtfRftUUAkJIkPXbDiKdyprwb;
				EIUGhtfRftUUAkJIkPXbDiKdyprwb = _entries[num4].next;
				OWNgdyiVhCVOvFKychejwFcCkulh--;
			}
			else
			{
				if (_count == _entries.Length)
				{
					jCUpuInvmUGeqgvsUtTUsCfidqaL();
					num2 = num % PigvmRcBKVdmYVsFoRTmDCOlvEVD.Length;
				}
				num4 = _count;
				_count++;
			}
			_entries[num4].hashCode = num;
			_entries[num4].next = PigvmRcBKVdmYVsFoRTmDCOlvEVD[num2];
			_entries[num4].key = P_0;
			_entries[num4].value = P_1;
			PigvmRcBKVdmYVsFoRTmDCOlvEVD[num2] = num4;
			TuyHWqAhRfLkHNKUzwtBuAtFfdew++;
			SQrAyFiCBrUbHkJxuKGAxKEkSpDD++;
		}

		private void jCUpuInvmUGeqgvsUtTUsCfidqaL()
		{
			rJnGtsJsPHVavtQwhlUdvUcCtgFn(nIBSeJMOBspBUIQEdwONqcsGBAnbA.AfBmIYGNJBDTmcTNuRecgITtJIZmA(_count), false);
		}

		private void rJnGtsJsPHVavtQwhlUdvUcCtgFn(int P_0, bool P_1)
		{
			int[] array = new int[P_0];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			Entry[] array2 = new Entry[P_0];
			Array.Copy(_entries, 0, array2, 0, _count);
			if (P_1)
			{
				for (int j = 0; j < _count; j++)
				{
					if (array2[j].hashCode != -1)
					{
						array2[j].hashCode = NKnHjqACKgnOhoBSglvWXhlwSnRC.GetHashCode(array2[j].key) & 0x7FFFFFFF;
					}
				}
			}
			for (int k = 0; k < _count; k++)
			{
				if (array2[k].hashCode >= 0)
				{
					int num = array2[k].hashCode % P_0;
					array2[k].next = array[num];
					array[num] = k;
				}
			}
			PigvmRcBKVdmYVsFoRTmDCOlvEVD = array;
			_entries = array2;
		}

		private IEnumerator<KeyValuePair<TKey, TValue>> xRnExKJiZWdJBbvLtPvIajkClkkKB()
		{
			return new Enumerator(this, 2);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in xRnExKJiZWdJBbvLtPvIajkClkkKB
			return this.xRnExKJiZWdJBbvLtPvIajkClkkKB();
		}

		private void jdTQxyyXuwqpMGVqsayBaZAgONiW(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in jdTQxyyXuwqpMGVqsayBaZAgONiW
			this.jdTQxyyXuwqpMGVqsayBaZAgONiW(P_0);
		}

		private bool bUgXVJbyHkJQcnPFCEgkKuKMjyAYA(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && fFkeGMtAwwgZAdcrWJzFCRgsMNywA.Equals(_entries[num].value, P_0.Value))
			{
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in bUgXVJbyHkJQcnPFCEgkKuKMjyAYA
			return this.bUgXVJbyHkJQcnPFCEgkKuKMjyAYA(P_0);
		}

		private bool lfpXCOElZHkabYbgVDtxAwpfmpiz(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && fFkeGMtAwwgZAdcrWJzFCRgsMNywA.Equals(_entries[num].value, P_0.Value))
			{
				Remove(P_0.Key);
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in lfpXCOElZHkabYbgVDtxAwpfmpiz
			return this.lfpXCOElZHkabYbgVDtxAwpfmpiz(P_0);
		}

		private void WaTUlgsPzbVsJSlgDUZhfrSJfEwh(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in WaTUlgsPzbVsJSlgDUZhfrSJfEwh
			this.WaTUlgsPzbVsJSlgDUZhfrSJfEwh(P_0, P_1);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new Exception();
			}
			if (array.GetLowerBound(0) != 0)
			{
				throw new Exception();
			}
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (array.Length - index < this.Count)
			{
				throw new Exception();
			}
			if (array is KeyValuePair<TKey, TValue>[] array2)
			{
				CopyTo(array2, index);
				return;
			}
			if (array is DictionaryEntry[])
			{
				DictionaryEntry[] array3 = array as DictionaryEntry[];
				Entry[] entries = _entries;
				for (int i = 0; i < _count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array3[index++] = new DictionaryEntry(entries[i].key, entries[i].value);
					}
				}
				return;
			}
			if (!(array is object[] array4))
			{
				throw new Exception();
			}
			try
			{
				int count = _count;
				Entry[] entries2 = _entries;
				for (int j = 0; j < count; j++)
				{
					if (entries2[j].hashCode >= 0)
					{
						array4[index++] = new KeyValuePair<TKey, TValue>(entries2[j].key, entries2[j].value);
					}
				}
			}
			catch (ArrayTypeMismatchException)
			{
				throw new Exception();
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this, 2);
		}

		void IDictionary.Add(object key, object value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			BAXBkTBCEOoYZBIjdPnqFNEdISkDc<TValue>(value, "value");
			try
			{
				TKey key2 = (TKey)key;
				try
				{
					Add(key2, (TValue)value);
				}
				catch (InvalidCastException)
				{
					throw new Exception();
				}
			}
			catch (InvalidCastException)
			{
				throw new Exception();
			}
		}

		bool IDictionary.Contains(object key)
		{
			if (LGqQlIRhChFRecsCxDdJEUvFCJAq(key))
			{
				return ContainsKey((TKey)key);
			}
			return false;
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new Enumerator(this, 1);
		}

		void IDictionary.Remove(object key)
		{
			if (LGqQlIRhChFRecsCxDdJEUvFCJAq(key))
			{
				Remove((TKey)key);
			}
		}

		private static bool LGqQlIRhChFRecsCxDdJEUvFCJAq(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			return P_0 is TKey;
		}

		private static void BAXBkTBCEOoYZBIjdPnqFNEdISkDc<_0001>(object P_0, string P_1)
		{
			if (P_0 == null && default(_0001) != null)
			{
				throw new ArgumentNullException(P_1);
			}
		}
	}
}
