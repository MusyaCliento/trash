using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

[DefaultMember("Item")]
internal class QyUiPtqXzERMCitvkvmASunMBhUj<_0001> : WGvdQBSFFmOFtknppwsUZyZsJbiL, ICollection<_0001>, IEnumerable<_0001>, IEnumerable, global::eCODwsXFSXdNupemQbSCbbUlhgQX<_0001>, global::bcJerXMYJjDTtInkIgCKLpTxdWYl<_0001> where _0001 : BoKegJHjPtbaGRdWPIRHjwIEXczVA
{
	public struct cQVdvKgXRzitcgKqeNQlgktBqrHLA : IEnumerator<_0001>, IEnumerator, IDisposable
	{
		private global::QyUiPtqXzERMCitvkvmASunMBhUj<_0001> ilAQOeWDgniZRQnDMazqhhGFYrgtA;

		private int VbuDtmvfwyRieOAySTsbjabcFjcF;

		private _0001 OgKbvvKAGGFKpBtOiVdfkofJCrFtA;

		_0001 IEnumerator<_0001>.Current => OgKbvvKAGGFKpBtOiVdfkofJCrFtA;

		object IEnumerator.Current
		{
			get
			{
				if (VbuDtmvfwyRieOAySTsbjabcFjcF == 0 || VbuDtmvfwyRieOAySTsbjabcFjcF == ilAQOeWDgniZRQnDMazqhhGFYrgtA.Count + 1)
				{
					throw new InvalidOperationException();
				}
				return this.Current;
			}
		}

		internal cQVdvKgXRzitcgKqeNQlgktBqrHLA(global::QyUiPtqXzERMCitvkvmASunMBhUj<_0001> P_0)
		{
			ilAQOeWDgniZRQnDMazqhhGFYrgtA = P_0;
			VbuDtmvfwyRieOAySTsbjabcFjcF = 0;
			OgKbvvKAGGFKpBtOiVdfkofJCrFtA = default(_0001);
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
			global::QyUiPtqXzERMCitvkvmASunMBhUj<_0001> qyUiPtqXzERMCitvkvmASunMBhUj = ilAQOeWDgniZRQnDMazqhhGFYrgtA;
			if ((uint)VbuDtmvfwyRieOAySTsbjabcFjcF < (uint)qyUiPtqXzERMCitvkvmASunMBhUj.Count)
			{
				OgKbvvKAGGFKpBtOiVdfkofJCrFtA = qyUiPtqXzERMCitvkvmASunMBhUj.kROxuukoNoDPUteUiyZrXrgvFdkc(VbuDtmvfwyRieOAySTsbjabcFjcF);
				VbuDtmvfwyRieOAySTsbjabcFjcF++;
				return true;
			}
			return rUCDtJLrVoDDWuRTXjBoQKJfdxkhA();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private bool rUCDtJLrVoDDWuRTXjBoQKJfdxkhA()
		{
			VbuDtmvfwyRieOAySTsbjabcFjcF = ilAQOeWDgniZRQnDMazqhhGFYrgtA.Count + 1;
			OgKbvvKAGGFKpBtOiVdfkofJCrFtA = default(_0001);
			return false;
		}

		void IEnumerator.Reset()
		{
			VbuDtmvfwyRieOAySTsbjabcFjcF = 0;
			OgKbvvKAGGFKpBtOiVdfkofJCrFtA = default(_0001);
		}
	}

	private Func<IntPtr, uint> JEDdnYrfneyVTObEMJYhwhQzCvgu;

	private Func<IntPtr, uint, _0001> ChpxkuFhwMRhloBdieXfYQqOPwIM;

	int global::bcJerXMYJjDTtInkIgCKLpTxdWYl<_0001>.Count
	{
		get
		{
			if (!txqxGWvgbIFBXSvhVfsjWiujImUh.IxUxRwOiJoafdfFhKIRVDBneDEiwA)
			{
				return 0;
			}
			return (int)JEDdnYrfneyVTObEMJYhwhQzCvgu(txqxGWvgbIFBXSvhVfsjWiujImUh.HyhCCFmSVaXfWiePWFGKValCXKcm);
		}
	}

	bool ICollection<_0001>.IsReadOnly => true;

	_0001 global::eCODwsXFSXdNupemQbSCbbUlhgQX<_0001>.UKUhauTDgZiYahdlrUGdngTykOVqA
	{
		get
		{
			if (P_0 < 0 || P_0 >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (!txqxGWvgbIFBXSvhVfsjWiujImUh.IxUxRwOiJoafdfFhKIRVDBneDEiwA)
			{
				return default(_0001);
			}
			return ChpxkuFhwMRhloBdieXfYQqOPwIM(txqxGWvgbIFBXSvhVfsjWiujImUh.HyhCCFmSVaXfWiePWFGKValCXKcm, (uint)P_0);
		}
		set
		{
			throw new NotImplementedException("Collection is read-only!");
		}
	}

	public QyUiPtqXzERMCitvkvmASunMBhUj(sBjgzLwqPhprfslfghRWQAGrbkct P_0, Func<IntPtr, uint> P_1, Func<IntPtr, uint, _0001> P_2)
		: base(P_0)
	{
		JEDdnYrfneyVTObEMJYhwhQzCvgu = P_1;
		ChpxkuFhwMRhloBdieXfYQqOPwIM = P_2;
	}

	public int XVFfrtGOMIvHeWzpkKfCPPyuDcEjA(_0001 P_0)
	{
		int count = this.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 x = this.kROxuukoNoDPUteUiyZrXrgvFdkc(i);
			bool num = EqualityComparer<_0001>.Default.Equals(x, P_0);
			x.keQIIDyPbblqAlAdcGQFTVBTOtzV();
			if (num)
			{
				return i;
			}
		}
		return -1;
	}

	public void Add(_0001 item)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	void ICollection<_0001>.Add(_0001 item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Add
		this.Add(item);
	}

	public void Clear()
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	void ICollection<_0001>.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	public bool Contains(_0001 item)
	{
		return XVFfrtGOMIvHeWzpkKfCPPyuDcEjA(item) >= 0;
	}

	bool ICollection<_0001>.Contains(_0001 item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Contains
		return this.Contains(item);
	}

	public void CopyTo(_0001[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex < 0 || arrayIndex >= array.Length)
		{
			throw new ArgumentOutOfRangeException("arrayIndex");
		}
		int count = this.Count;
		for (int i = 0; i < count; i++)
		{
			array[i + arrayIndex] = this.kROxuukoNoDPUteUiyZrXrgvFdkc(i);
		}
	}

	void ICollection<_0001>.CopyTo(_0001[] array, int arrayIndex)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CopyTo
		this.CopyTo(array, arrayIndex);
	}

	public bool Remove(_0001 item)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	bool ICollection<_0001>.Remove(_0001 item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Remove
		return this.Remove(item);
	}

	public IEnumerator<_0001> GetEnumerator()
	{
		return new cQVdvKgXRzitcgKqeNQlgktBqrHLA(this);
	}

	IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void kymafSVHZOTNzFxwoDpcuxHUvgVb(int P_0, _0001 P_1)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	public void NbVJdfwBcTmKmHDmIEueFCIDiBxEA(int P_0)
	{
		throw new NotImplementedException("Collection is read-only!");
	}
}
