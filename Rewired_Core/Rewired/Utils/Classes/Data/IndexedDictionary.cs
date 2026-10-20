using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IndexedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
	{
		private struct vUteQeByfFJWPQVBTYChvRQZZYPsA
		{
			public TKey oUTkExmIZkdXixquGPZflJKoPxGM;

			public TValue iZqRcHlJgsgAqjcmKuDCRRipFPFIb;

			public vUteQeByfFJWPQVBTYChvRQZZYPsA(TKey P_0, TValue P_1)
			{
				oUTkExmIZkdXixquGPZflJKoPxGM = P_0;
				iZqRcHlJgsgAqjcmKuDCRRipFPFIb = P_1;
			}

			public KeyValuePair<TKey, TValue> QimQFmSCTSbKAUUlBGUEfjoNHbMpA()
			{
				return new KeyValuePair<TKey, TValue>(oUTkExmIZkdXixquGPZflJKoPxGM, iZqRcHlJgsgAqjcmKuDCRRipFPFIb);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private IndexedDictionary<TKey, TValue> WeLAmWSCzJCTjBUPzoihAHHovtsSA;

			private int uuExZTZkoILHlSlpIgFnRTJLWSAM;

			private int ovfQCZGScxjFzKdGQQkLcmddwtk;

			private KeyValuePair<TKey, TValue> gFZfQDDXJdmgZWBXjfbAvtfRDffy;

			private int cwPpoPMGcWrzQwKhQRgnqSVrKxbm;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => gFZfQDDXJdmgZWBXjfbAvtfRDffy;

			object IEnumerator.Current
			{
				get
				{
					if (ovfQCZGScxjFzKdGQQkLcmddwtk == 0 || ovfQCZGScxjFzKdGQQkLcmddwtk == WeLAmWSCzJCTjBUPzoihAHHovtsSA.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count + 1)
					{
						throw new Exception();
					}
					if (cwPpoPMGcWrzQwKhQRgnqSVrKxbm == 1)
					{
						return new DictionaryEntry(gFZfQDDXJdmgZWBXjfbAvtfRDffy.Key, gFZfQDDXJdmgZWBXjfbAvtfRDffy.Value);
					}
					return new KeyValuePair<TKey, TValue>(gFZfQDDXJdmgZWBXjfbAvtfRDffy.Key, gFZfQDDXJdmgZWBXjfbAvtfRDffy.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (ovfQCZGScxjFzKdGQQkLcmddwtk == 0 || ovfQCZGScxjFzKdGQQkLcmddwtk == WeLAmWSCzJCTjBUPzoihAHHovtsSA.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(gFZfQDDXJdmgZWBXjfbAvtfRDffy.Key, gFZfQDDXJdmgZWBXjfbAvtfRDffy.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (ovfQCZGScxjFzKdGQQkLcmddwtk == 0 || ovfQCZGScxjFzKdGQQkLcmddwtk == WeLAmWSCzJCTjBUPzoihAHHovtsSA.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count + 1)
					{
						throw new Exception();
					}
					return gFZfQDDXJdmgZWBXjfbAvtfRDffy.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (ovfQCZGScxjFzKdGQQkLcmddwtk == 0 || ovfQCZGScxjFzKdGQQkLcmddwtk == WeLAmWSCzJCTjBUPzoihAHHovtsSA.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count + 1)
					{
						throw new Exception();
					}
					return gFZfQDDXJdmgZWBXjfbAvtfRDffy.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				WeLAmWSCzJCTjBUPzoihAHHovtsSA = P_0;
				uuExZTZkoILHlSlpIgFnRTJLWSAM = P_0.dKpuueEYzwYzxMaZxsbfSCuPGoVO.Version;
				ovfQCZGScxjFzKdGQQkLcmddwtk = 0;
				cwPpoPMGcWrzQwKhQRgnqSVrKxbm = P_1;
				gFZfQDDXJdmgZWBXjfbAvtfRDffy = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (uuExZTZkoILHlSlpIgFnRTJLWSAM != WeLAmWSCzJCTjBUPzoihAHHovtsSA.dKpuueEYzwYzxMaZxsbfSCuPGoVO.Version)
				{
					throw new Exception();
				}
				if ((uint)ovfQCZGScxjFzKdGQQkLcmddwtk < (uint)WeLAmWSCzJCTjBUPzoihAHHovtsSA.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count)
				{
					gFZfQDDXJdmgZWBXjfbAvtfRDffy = new KeyValuePair<TKey, TValue>(WeLAmWSCzJCTjBUPzoihAHHovtsSA.dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[ovfQCZGScxjFzKdGQQkLcmddwtk].oUTkExmIZkdXixquGPZflJKoPxGM, WeLAmWSCzJCTjBUPzoihAHHovtsSA.dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[ovfQCZGScxjFzKdGQQkLcmddwtk].iZqRcHlJgsgAqjcmKuDCRRipFPFIb);
					ovfQCZGScxjFzKdGQQkLcmddwtk++;
					return true;
				}
				ovfQCZGScxjFzKdGQQkLcmddwtk = WeLAmWSCzJCTjBUPzoihAHHovtsSA.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count + 1;
				gFZfQDDXJdmgZWBXjfbAvtfRDffy = default(KeyValuePair<TKey, TValue>);
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
				if (uuExZTZkoILHlSlpIgFnRTJLWSAM != WeLAmWSCzJCTjBUPzoihAHHovtsSA.dKpuueEYzwYzxMaZxsbfSCuPGoVO.Version)
				{
					throw new Exception();
				}
				ovfQCZGScxjFzKdGQQkLcmddwtk = 0;
				gFZfQDDXJdmgZWBXjfbAvtfRDffy = default(KeyValuePair<TKey, TValue>);
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
				private IndexedDictionary<TKey, TValue> XLjIJEXCZxgZaSIfRfKfiFUdzLjj;

				private int CGugInmkSsFVZPodvFWaIbUdrYgT;

				private int lCbIMHOspNumZcPJxjGzDPpLGUvz;

				private TKey IIABTFliXxSqrEeffGsYFCIJpDKHb;

				TKey IEnumerator<TKey>.Current => IIABTFliXxSqrEeffGsYFCIJpDKHb;

				object IEnumerator.Current
				{
					get
					{
						if (CGugInmkSsFVZPodvFWaIbUdrYgT == 0 || CGugInmkSsFVZPodvFWaIbUdrYgT == XLjIJEXCZxgZaSIfRfKfiFUdzLjj.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count + 1)
						{
							throw new Exception();
						}
						return IIABTFliXxSqrEeffGsYFCIJpDKHb;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					XLjIJEXCZxgZaSIfRfKfiFUdzLjj = P_0;
					lCbIMHOspNumZcPJxjGzDPpLGUvz = P_0.dKpuueEYzwYzxMaZxsbfSCuPGoVO.Version;
					CGugInmkSsFVZPodvFWaIbUdrYgT = 0;
					IIABTFliXxSqrEeffGsYFCIJpDKHb = default(TKey);
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
					if (lCbIMHOspNumZcPJxjGzDPpLGUvz != XLjIJEXCZxgZaSIfRfKfiFUdzLjj.dKpuueEYzwYzxMaZxsbfSCuPGoVO.Version)
					{
						throw new Exception();
					}
					if ((uint)CGugInmkSsFVZPodvFWaIbUdrYgT < (uint)XLjIJEXCZxgZaSIfRfKfiFUdzLjj.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count)
					{
						IIABTFliXxSqrEeffGsYFCIJpDKHb = XLjIJEXCZxgZaSIfRfKfiFUdzLjj.dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[CGugInmkSsFVZPodvFWaIbUdrYgT].oUTkExmIZkdXixquGPZflJKoPxGM;
						CGugInmkSsFVZPodvFWaIbUdrYgT++;
						return true;
					}
					CGugInmkSsFVZPodvFWaIbUdrYgT = XLjIJEXCZxgZaSIfRfKfiFUdzLjj.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count + 1;
					IIABTFliXxSqrEeffGsYFCIJpDKHb = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (lCbIMHOspNumZcPJxjGzDPpLGUvz != XLjIJEXCZxgZaSIfRfKfiFUdzLjj.dKpuueEYzwYzxMaZxsbfSCuPGoVO.Version)
					{
						throw new Exception();
					}
					CGugInmkSsFVZPodvFWaIbUdrYgT = 0;
					IIABTFliXxSqrEeffGsYFCIJpDKHb = default(TKey);
				}
			}

			private IndexedDictionary<TKey, TValue> emqsvLrytTETkZJYKocYGgjuBgmeA;

			int ICollection<TKey>.Count => emqsvLrytTETkZJYKocYGgjuBgmeA.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)emqsvLrytTETkZJYKocYGgjuBgmeA).SyncRoot;

			public KeyCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				emqsvLrytTETkZJYKocYGgjuBgmeA = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(emqsvLrytTETkZJYKocYGgjuBgmeA);
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
				if (array.Length - index < emqsvLrytTETkZJYKocYGgjuBgmeA.Count)
				{
					throw new Exception();
				}
				int count = emqsvLrytTETkZJYKocYGgjuBgmeA.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count;
				vUteQeByfFJWPQVBTYChvRQZZYPsA[] items = emqsvLrytTETkZJYKocYGgjuBgmeA.dKpuueEYzwYzxMaZxsbfSCuPGoVO._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].oUTkExmIZkdXixquGPZflJKoPxGM;
				}
			}

			void ICollection<TKey>.CopyTo(TKey[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void EeOHmCjGNlkudghOSHBasgxPTmVB(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in EeOHmCjGNlkudghOSHBasgxPTmVB
				this.EeOHmCjGNlkudghOSHBasgxPTmVB(P_0);
			}

			private void uNxZlirMUDAZOdDsBXlpfSxHkdqQA()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in uNxZlirMUDAZOdDsBXlpfSxHkdqQA
				this.uNxZlirMUDAZOdDsBXlpfSxHkdqQA();
			}

			private bool YfAsktYHMFETrDlawHTdLDdUrCun(TKey P_0)
			{
				return emqsvLrytTETkZJYKocYGgjuBgmeA.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in YfAsktYHMFETrDlawHTdLDdUrCun
				return this.YfAsktYHMFETrDlawHTdLDdUrCun(P_0);
			}

			private bool THZnhbyaoAdRfRDnnxojxTatkmdK(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in THZnhbyaoAdRfRDnnxojxTatkmdK
				return this.THZnhbyaoAdRfRDnnxojxTatkmdK(P_0);
			}

			private IEnumerator<TKey> hFwrDNYrjloGkcvJXEevwwBeoxAM()
			{
				return new Enumerator(emqsvLrytTETkZJYKocYGgjuBgmeA);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in hFwrDNYrjloGkcvJXEevwwBeoxAM
				return this.hFwrDNYrjloGkcvJXEevwwBeoxAM();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(emqsvLrytTETkZJYKocYGgjuBgmeA);
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
				if (array.Length - index < emqsvLrytTETkZJYKocYGgjuBgmeA.Count)
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
				int count = emqsvLrytTETkZJYKocYGgjuBgmeA.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count;
				vUteQeByfFJWPQVBTYChvRQZZYPsA[] items = emqsvLrytTETkZJYKocYGgjuBgmeA.dKpuueEYzwYzxMaZxsbfSCuPGoVO._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].oUTkExmIZkdXixquGPZflJKoPxGM;
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
				private IndexedDictionary<TKey, TValue> EVQmkvLyYOMUqLnrpnIRiRvirdu;

				private int XvOppLzcxpcSvxQTnrVnSlPYbGAp;

				private int wXknibgsNFJDywuvonVDcOXNBVXI;

				private TValue VUKlEJOHroAtAbCJBjoCrIHbnptbA;

				TValue IEnumerator<TValue>.Current => VUKlEJOHroAtAbCJBjoCrIHbnptbA;

				object IEnumerator.Current
				{
					get
					{
						if (XvOppLzcxpcSvxQTnrVnSlPYbGAp == 0 || XvOppLzcxpcSvxQTnrVnSlPYbGAp == EVQmkvLyYOMUqLnrpnIRiRvirdu.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count + 1)
						{
							throw new Exception();
						}
						return VUKlEJOHroAtAbCJBjoCrIHbnptbA;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					EVQmkvLyYOMUqLnrpnIRiRvirdu = P_0;
					wXknibgsNFJDywuvonVDcOXNBVXI = P_0.dKpuueEYzwYzxMaZxsbfSCuPGoVO.Version;
					XvOppLzcxpcSvxQTnrVnSlPYbGAp = 0;
					VUKlEJOHroAtAbCJBjoCrIHbnptbA = default(TValue);
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
					if (wXknibgsNFJDywuvonVDcOXNBVXI != EVQmkvLyYOMUqLnrpnIRiRvirdu.dKpuueEYzwYzxMaZxsbfSCuPGoVO.Version)
					{
						throw new Exception();
					}
					if ((uint)XvOppLzcxpcSvxQTnrVnSlPYbGAp < (uint)EVQmkvLyYOMUqLnrpnIRiRvirdu.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count)
					{
						VUKlEJOHroAtAbCJBjoCrIHbnptbA = EVQmkvLyYOMUqLnrpnIRiRvirdu.dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[XvOppLzcxpcSvxQTnrVnSlPYbGAp].iZqRcHlJgsgAqjcmKuDCRRipFPFIb;
						XvOppLzcxpcSvxQTnrVnSlPYbGAp++;
						return true;
					}
					XvOppLzcxpcSvxQTnrVnSlPYbGAp = EVQmkvLyYOMUqLnrpnIRiRvirdu.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count + 1;
					VUKlEJOHroAtAbCJBjoCrIHbnptbA = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (wXknibgsNFJDywuvonVDcOXNBVXI != EVQmkvLyYOMUqLnrpnIRiRvirdu.dKpuueEYzwYzxMaZxsbfSCuPGoVO.Version)
					{
						throw new Exception();
					}
					XvOppLzcxpcSvxQTnrVnSlPYbGAp = 0;
					VUKlEJOHroAtAbCJBjoCrIHbnptbA = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> PPOwDlxJMyLhgFiKkYUmuwrMcNYr;

			int ICollection<TValue>.Count => PPOwDlxJMyLhgFiKkYUmuwrMcNYr.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)PPOwDlxJMyLhgFiKkYUmuwrMcNYr).SyncRoot;

			public ValueCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				PPOwDlxJMyLhgFiKkYUmuwrMcNYr = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(PPOwDlxJMyLhgFiKkYUmuwrMcNYr);
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
				if (array.Length - index < PPOwDlxJMyLhgFiKkYUmuwrMcNYr.Count)
				{
					throw new Exception();
				}
				int count = PPOwDlxJMyLhgFiKkYUmuwrMcNYr.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count;
				vUteQeByfFJWPQVBTYChvRQZZYPsA[] items = PPOwDlxJMyLhgFiKkYUmuwrMcNYr.dKpuueEYzwYzxMaZxsbfSCuPGoVO._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].iZqRcHlJgsgAqjcmKuDCRRipFPFIb;
				}
			}

			void ICollection<TValue>.CopyTo(TValue[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void hZpETSHmzrUJvUZlAaBrSElAhkBOA(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in hZpETSHmzrUJvUZlAaBrSElAhkBOA
				this.hZpETSHmzrUJvUZlAaBrSElAhkBOA(P_0);
			}

			private bool kipdBikOEgTAYUlBPMfEnbyyCTmab(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in kipdBikOEgTAYUlBPMfEnbyyCTmab
				return this.kipdBikOEgTAYUlBPMfEnbyyCTmab(P_0);
			}

			private void wPbcOGTjiEIjxUsFJRYsXNohgqIu()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in wPbcOGTjiEIjxUsFJRYsXNohgqIu
				this.wPbcOGTjiEIjxUsFJRYsXNohgqIu();
			}

			private bool DXOlTBVGvVaqkObwmrSxqckSCPNt(TValue P_0)
			{
				return PPOwDlxJMyLhgFiKkYUmuwrMcNYr.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in DXOlTBVGvVaqkObwmrSxqckSCPNt
				return this.DXOlTBVGvVaqkObwmrSxqckSCPNt(P_0);
			}

			private IEnumerator<TValue> TxrAlDtKvSqzuSakNJoRUivXKOTN()
			{
				return new Enumerator(PPOwDlxJMyLhgFiKkYUmuwrMcNYr);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in TxrAlDtKvSqzuSakNJoRUivXKOTN
				return this.TxrAlDtKvSqzuSakNJoRUivXKOTN();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(PPOwDlxJMyLhgFiKkYUmuwrMcNYr);
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
				if (array.Length - index < PPOwDlxJMyLhgFiKkYUmuwrMcNYr.Count)
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
				int count = PPOwDlxJMyLhgFiKkYUmuwrMcNYr.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count;
				vUteQeByfFJWPQVBTYChvRQZZYPsA[] items = PPOwDlxJMyLhgFiKkYUmuwrMcNYr.dKpuueEYzwYzxMaZxsbfSCuPGoVO._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].iZqRcHlJgsgAqjcmKuDCRRipFPFIb;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private static readonly bool eISaRFPONILtNueEwafSujUQFKIM = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool UgMLRNKEtzFCLDndJhlHLxaKPgYbA = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> ZUpCASrwEUtLjAeMYbJTUFYfNysJ = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> vVukEKZnmnehnEuVvOSpESpFcUlhB = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<vUteQeByfFJWPQVBTYChvRQZZYPsA> dKpuueEYzwYzxMaZxsbfSCuPGoVO;

		private readonly ADictionary<TKey, int> RWUfrdJTGxkoQjlcjCAxmeCCzFRNA;

		private bool nrJBJfoheAsAjdcbkIfkliFigcKE;

		int ICollection<KeyValuePair<TKey, TValue>>.Count => dKpuueEYzwYzxMaZxsbfSCuPGoVO._count;

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!nrJBJfoheAsAjdcbkIfkliFigcKE)
				{
					return false;
				}
				return RWUfrdJTGxkoQjlcjCAxmeCCzFRNA._count < dKpuueEYzwYzxMaZxsbfSCuPGoVO._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return nrJBJfoheAsAjdcbkIfkliFigcKE;
			}
			set
			{
				if (nrJBJfoheAsAjdcbkIfkliFigcKE != value)
				{
					nrJBJfoheAsAjdcbkIfkliFigcKE = value;
					if (!value && ContainsDuplicateKeys)
					{
						throw new Exception("The dictionary contains duplicate keys and cannot be changed unless the keys are removed.");
					}
				}
			}
		}

		public TValue this[int index]
		{
			get
			{
				if ((uint)index >= (uint)dKpuueEYzwYzxMaZxsbfSCuPGoVO._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[index].iZqRcHlJgsgAqjcmKuDCRRipFPFIb;
			}
			set
			{
				if ((uint)index >= (uint)dKpuueEYzwYzxMaZxsbfSCuPGoVO._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[index].iZqRcHlJgsgAqjcmKuDCRRipFPFIb = value;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return ZUpCASrwEUtLjAeMYbJTUFYfNysJ;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				ZUpCASrwEUtLjAeMYbJTUFYfNysJ = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return vVukEKZnmnehnEuVvOSpESpFcUlhB;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				vVukEKZnmnehnEuVvOSpESpFcUlhB = value;
			}
		}

		ICollection<TKey> IDictionary<TKey, TValue>.Keys => new KeyCollection(this);

		ICollection<TValue> IDictionary<TKey, TValue>.Values => new ValueCollection(this);

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		TValue IDictionary<TKey, TValue>.this[TKey P_0]
		{
			get
			{
				int num = IndexOfKey(P_0);
				if (num < 0)
				{
					TKey val = P_0;
					throw new KeyNotFoundException("Key \"" + val?.ToString() + "\" does not exist.");
				}
				return dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[num].iZqRcHlJgsgAqjcmKuDCRRipFPFIb;
			}
			set
			{
				SetValue(key, value2);
			}
		}

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => new KeyCollection(this);

		ICollection IDictionary.Values => new ValueCollection(this);

		object IDictionary.this[object key]
		{
			get
			{
				return ((IDictionary<TKey, TValue>)this)[(TKey)key];
			}
			set
			{
				((IDictionary<TKey, TValue>)this)[(TKey)key] = (TValue)value;
			}
		}

		bool ICollection.IsSynchronized => ((ICollection)dKpuueEYzwYzxMaZxsbfSCuPGoVO).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)dKpuueEYzwYzxMaZxsbfSCuPGoVO).SyncRoot;

		TValue Rewired.Utils.Interfaces.IReadOnlyList<TValue>.this[int P_0] => this[P_0];

		int IReadOnlyList.Count => this.Count;

		object IReadOnlyList.this[int P_0] => this[P_0];

		public IndexedDictionary()
			: this(0, false)
		{
		}

		public IndexedDictionary(int P_0)
			: this(P_0, false)
		{
		}

		public IndexedDictionary(bool P_0)
			: this(0, P_0)
		{
		}

		public IndexedDictionary(int P_0, bool P_1)
		{
			if (P_0 < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			nrJBJfoheAsAjdcbkIfkliFigcKE = P_1;
			dKpuueEYzwYzxMaZxsbfSCuPGoVO = new AList<vUteQeByfFJWPQVBTYChvRQZZYPsA>(P_0);
			RWUfrdJTGxkoQjlcjCAxmeCCzFRNA = new ADictionary<TKey, int>(P_0);
		}

		public IndexedDictionary(IDictionary<TKey, TValue> P_0)
			: this(P_0, false)
		{
		}

		public IndexedDictionary(IDictionary<TKey, TValue> P_0, bool P_1)
			: this(0, P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			if (ReflectionTools.DoesTypeImplement(P_0.GetType(), typeof(IndexedDictionary<TKey, TValue>)))
			{
				IndexedDictionary<TKey, TValue> indexedDictionary = (IndexedDictionary<TKey, TValue>)P_0;
				for (int i = 0; i < indexedDictionary.dKpuueEYzwYzxMaZxsbfSCuPGoVO._count; i++)
				{
					Add(indexedDictionary.dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[i].oUTkExmIZkdXixquGPZflJKoPxGM, indexedDictionary.dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[i].iZqRcHlJgsgAqjcmKuDCRRipFPFIb);
				}
				return;
			}
			foreach (KeyValuePair<TKey, TValue> item in P_0)
			{
				Add(item.Key, item.Value);
			}
		}

		public TValue GetValue(TKey key)
		{
			return dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[RWUfrdJTGxkoQjlcjCAxmeCCzFRNA[key]].iZqRcHlJgsgAqjcmKuDCRRipFPFIb;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!RWUfrdJTGxkoQjlcjCAxmeCCzFRNA.TryGetValue(key, out var value2))
			{
				value = default(TValue);
				return false;
			}
			value = dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[value2].iZqRcHlJgsgAqjcmKuDCRRipFPFIb;
			return true;
		}

		bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
			return this.TryGetValue(key, out value);
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)dKpuueEYzwYzxMaZxsbfSCuPGoVO._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<vUteQeByfFJWPQVBTYChvRQZZYPsA, _003F>.vUteQeByfFJWPQVBTYChvRQZZYPsA>)(object)dKpuueEYzwYzxMaZxsbfSCuPGoVO)[index].oUTkExmIZkdXixquGPZflJKoPxGM;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return ((AList<IndexedDictionary<vUteQeByfFJWPQVBTYChvRQZZYPsA, _003F>.vUteQeByfFJWPQVBTYChvRQZZYPsA>)(object)dKpuueEYzwYzxMaZxsbfSCuPGoVO)[RWUfrdJTGxkoQjlcjCAxmeCCzFRNA[key]].QimQFmSCTSbKAUUlBGUEfjoNHbMpA();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)dKpuueEYzwYzxMaZxsbfSCuPGoVO._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<vUteQeByfFJWPQVBTYChvRQZZYPsA, _003F>.vUteQeByfFJWPQVBTYChvRQZZYPsA>)(object)dKpuueEYzwYzxMaZxsbfSCuPGoVO)[index].QimQFmSCTSbKAUUlBGUEfjoNHbMpA();
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			if (!RWUfrdJTGxkoQjlcjCAxmeCCzFRNA.TryGetValue(key, out var value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = ((AList<IndexedDictionary<vUteQeByfFJWPQVBTYChvRQZZYPsA, _003F>.vUteQeByfFJWPQVBTYChvRQZZYPsA>)(object)dKpuueEYzwYzxMaZxsbfSCuPGoVO)[value].QimQFmSCTSbKAUUlBGUEfjoNHbMpA();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool num = RWUfrdJTGxkoQjlcjCAxmeCCzFRNA.ContainsKey(key);
			if (num && !nrJBJfoheAsAjdcbkIfkliFigcKE)
			{
				TKey val = key;
				throw new ArgumentException("Key \"" + val?.ToString() + "\" is already in use.");
			}
			int num2 = dKpuueEYzwYzxMaZxsbfSCuPGoVO.Add(new vUteQeByfFJWPQVBTYChvRQZZYPsA(key, value));
			if (num)
			{
				RWUfrdJTGxkoQjlcjCAxmeCCzFRNA[key] = num2;
			}
			else
			{
				RWUfrdJTGxkoQjlcjCAxmeCCzFRNA.Add(key, num2);
			}
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(key, value);
		}

		public void SetValue(TKey key, TValue value)
		{
			if (RWUfrdJTGxkoQjlcjCAxmeCCzFRNA.TryGetValue(key, out var value2))
			{
				dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[value2].iZqRcHlJgsgAqjcmKuDCRRipFPFIb = value;
				RWUfrdJTGxkoQjlcjCAxmeCCzFRNA[key] = value2;
			}
			else
			{
				Add(key, value);
			}
		}

		public bool Remove(TKey key)
		{
			RWUfrdJTGxkoQjlcjCAxmeCCzFRNA.Remove(key);
			if (nrJBJfoheAsAjdcbkIfkliFigcKE)
			{
				bool result = false;
				for (int num = dKpuueEYzwYzxMaZxsbfSCuPGoVO._count - 1; num >= 0; num--)
				{
					if (ZUpCASrwEUtLjAeMYbJTUFYfNysJ.Equals(dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[num].oUTkExmIZkdXixquGPZflJKoPxGM, key))
					{
						dKpuueEYzwYzxMaZxsbfSCuPGoVO.RemoveAt(num);
						result = true;
					}
				}
				return result;
			}
			int num2 = IndexOfKey(key);
			if (num2 < 0)
			{
				return false;
			}
			RemoveAt(num2);
			return true;
		}

		bool IDictionary<TKey, TValue>.Remove(TKey key)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Remove
			return this.Remove(key);
		}

		public void RemoveAt(int index)
		{
			if ((uint)index >= (uint)dKpuueEYzwYzxMaZxsbfSCuPGoVO._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey oUTkExmIZkdXixquGPZflJKoPxGM = dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[index].oUTkExmIZkdXixquGPZflJKoPxGM;
			if (index < dKpuueEYzwYzxMaZxsbfSCuPGoVO._count - 1)
			{
				for (int i = index + 1; i < ((AList<IndexedDictionary<vUteQeByfFJWPQVBTYChvRQZZYPsA, _003F>.vUteQeByfFJWPQVBTYChvRQZZYPsA>)(object)dKpuueEYzwYzxMaZxsbfSCuPGoVO).Count; i++)
				{
					RWUfrdJTGxkoQjlcjCAxmeCCzFRNA[dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[i].oUTkExmIZkdXixquGPZflJKoPxGM] = i - 1;
				}
			}
			dKpuueEYzwYzxMaZxsbfSCuPGoVO.RemoveAt(index);
			RWUfrdJTGxkoQjlcjCAxmeCCzFRNA.Remove(oUTkExmIZkdXixquGPZflJKoPxGM);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			if (num >= 0)
			{
				_ = ref dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[num];
				RemoveAt(num);
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			for (int num2 = dKpuueEYzwYzxMaZxsbfSCuPGoVO._count - 1; num2 >= 0; num2--)
			{
				_ = ref dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[num2];
				if (vVukEKZnmnehnEuVvOSpESpFcUlhB.Equals(dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[num2].iZqRcHlJgsgAqjcmKuDCRRipFPFIb, value))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public int IndexOfKey(TKey key)
		{
			if (!eISaRFPONILtNueEwafSujUQFKIM && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int count = dKpuueEYzwYzxMaZxsbfSCuPGoVO._count;
			for (int i = 0; i < count; i++)
			{
				if (ZUpCASrwEUtLjAeMYbJTUFYfNysJ.Equals(dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[i].oUTkExmIZkdXixquGPZflJKoPxGM, key))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			int count = dKpuueEYzwYzxMaZxsbfSCuPGoVO._count;
			for (int i = 0; i < count; i++)
			{
				if (vVukEKZnmnehnEuVvOSpESpFcUlhB.Equals(dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[i].iZqRcHlJgsgAqjcmKuDCRRipFPFIb, value))
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsKey(TKey key)
		{
			return RWUfrdJTGxkoQjlcjCAxmeCCzFRNA.ContainsKey(key);
		}

		bool IDictionary<TKey, TValue>.ContainsKey(TKey key)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ContainsKey
			return this.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return IndexOfValue(value) >= 0;
		}

		public void Clear()
		{
			dKpuueEYzwYzxMaZxsbfSCuPGoVO.Clear();
			RWUfrdJTGxkoQjlcjCAxmeCCzFRNA.Clear();
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

		public void TrimExcess()
		{
			dKpuueEYzwYzxMaZxsbfSCuPGoVO.TrimExcess();
		}

		private void rcdiBmzmwsdecFdRKsKqESPjnUdEb(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in rcdiBmzmwsdecFdRKsKqESPjnUdEb
			this.rcdiBmzmwsdecFdRKsKqESPjnUdEb(P_0);
		}

		private bool DfWupQhuLzJfXnqsCWAAtkFuMazk(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num < 0)
			{
				return false;
			}
			vUteQeByfFJWPQVBTYChvRQZZYPsA vUteQeByfFJWPQVBTYChvRQZZYPsA2 = dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[num];
			return vVukEKZnmnehnEuVvOSpESpFcUlhB.Equals(P_0.Value, vUteQeByfFJWPQVBTYChvRQZZYPsA2.iZqRcHlJgsgAqjcmKuDCRRipFPFIb);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DfWupQhuLzJfXnqsCWAAtkFuMazk
			return this.DfWupQhuLzJfXnqsCWAAtkFuMazk(P_0);
		}

		private void iEbbAEnbNEzpvAVBSPtpnFSBlIOe(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("array");
			}
			if (P_1 < 0 || P_1 > P_0.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (P_0.Length - P_1 < this.Count)
			{
				throw new Exception();
			}
			int count = dKpuueEYzwYzxMaZxsbfSCuPGoVO._count;
			for (int i = 0; i < count; i++)
			{
				P_0[P_1++] = new KeyValuePair<TKey, TValue>(dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[i].oUTkExmIZkdXixquGPZflJKoPxGM, dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[i].iZqRcHlJgsgAqjcmKuDCRRipFPFIb);
			}
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in iEbbAEnbNEzpvAVBSPtpnFSBlIOe
			this.iEbbAEnbNEzpvAVBSPtpnFSBlIOe(P_0, P_1);
		}

		private bool MkjalfhdqJTJfEYrQQlBPNfFGKMBb(KeyValuePair<TKey, TValue> P_0)
		{
			if (nrJBJfoheAsAjdcbkIfkliFigcKE)
			{
				bool result = false;
				for (int num = dKpuueEYzwYzxMaZxsbfSCuPGoVO._count - 1; num >= 0; num--)
				{
					vUteQeByfFJWPQVBTYChvRQZZYPsA vUteQeByfFJWPQVBTYChvRQZZYPsA2 = dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[num];
					if (vVukEKZnmnehnEuVvOSpESpFcUlhB.Equals(P_0.Value, vUteQeByfFJWPQVBTYChvRQZZYPsA2.iZqRcHlJgsgAqjcmKuDCRRipFPFIb))
					{
						dKpuueEYzwYzxMaZxsbfSCuPGoVO.RemoveAt(num);
						result = true;
					}
				}
				return result;
			}
			int num2 = IndexOfKey(P_0.Key);
			if (num2 < 0)
			{
				return false;
			}
			vUteQeByfFJWPQVBTYChvRQZZYPsA vUteQeByfFJWPQVBTYChvRQZZYPsA3 = dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[num2];
			if (!vVukEKZnmnehnEuVvOSpESpFcUlhB.Equals(P_0.Value, vUteQeByfFJWPQVBTYChvRQZZYPsA3.iZqRcHlJgsgAqjcmKuDCRRipFPFIb))
			{
				return false;
			}
			RemoveAt(num2);
			return true;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MkjalfhdqJTJfEYrQQlBPNfFGKMBb
			return this.MkjalfhdqJTJfEYrQQlBPNfFGKMBb(P_0);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return new Enumerator(this, 1);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this, 1);
		}

		void IDictionary.Add(object key, object value)
		{
			Add((TKey)key, (TValue)value);
		}

		bool IDictionary.Contains(object key)
		{
			return ContainsKey((TKey)key);
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new Enumerator(this, 2);
		}

		void IDictionary.Remove(object key)
		{
			Remove((TKey)key);
		}

		void ICollection.CopyTo(Array array, int index)
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
			int count = dKpuueEYzwYzxMaZxsbfSCuPGoVO._count;
			for (int i = 0; i < count; i++)
			{
				array.SetValue(new KeyValuePair<TKey, TValue>(dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[i].oUTkExmIZkdXixquGPZflJKoPxGM, dKpuueEYzwYzxMaZxsbfSCuPGoVO._items[i].iZqRcHlJgsgAqjcmKuDCRRipFPFIb), index++);
			}
		}

		private int ViRCJEvZUABbvrylkDzoBSsTtDON(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ViRCJEvZUABbvrylkDzoBSsTtDON
			return this.ViRCJEvZUABbvrylkDzoBSsTtDON(P_0);
		}

		private bool EdJmETbzMluwoQYhkdRORUFMlrtC(TValue P_0)
		{
			return ContainsValue(P_0);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in EdJmETbzMluwoQYhkdRORUFMlrtC
			return this.EdJmETbzMluwoQYhkdRORUFMlrtC(P_0);
		}

		private int DggKDLzgvAAczcRmOyjtDJCSoFcEb(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DggKDLzgvAAczcRmOyjtDJCSoFcEb
			return this.DggKDLzgvAAczcRmOyjtDJCSoFcEb(P_0);
		}

		private bool dwTAGBikwcpQsdazFMFgdqaDIjIOc(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in dwTAGBikwcpQsdazFMFgdqaDIjIOc
			return this.dwTAGBikwcpQsdazFMFgdqaDIjIOc(P_0);
		}
	}
}
