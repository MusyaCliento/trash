using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorListValue<T>
	{
		private IList<T> oZunFabiXsKSrhvZHAqZWHLJohvP;

		private readonly List<T> DnNEzCellFOTqFhvqLyLZfwgwTQp = new List<T>();

		private bool tdBlaxJijTmcPrPPQHAnaFyhByCgA;

		public bool isSet => tdBlaxJijTmcPrPPQHAnaFyhByCgA;

		public IList<T> value
		{
			get
			{
				return oZunFabiXsKSrhvZHAqZWHLJohvP;
			}
			set
			{
				oZunFabiXsKSrhvZHAqZWHLJohvP = value;
				tdBlaxJijTmcPrPPQHAnaFyhByCgA = true;
				DnNEzCellFOTqFhvqLyLZfwgwTQp.Clear();
				if (oZunFabiXsKSrhvZHAqZWHLJohvP != null)
				{
					DnNEzCellFOTqFhvqLyLZfwgwTQp.AddRange(oZunFabiXsKSrhvZHAqZWHLJohvP);
				}
			}
		}

		public bool SetIfChanged(IList<T> value)
		{
			if (!tdBlaxJijTmcPrPPQHAnaFyhByCgA)
			{
				this.value = value;
				return false;
			}
			if (oZunFabiXsKSrhvZHAqZWHLJohvP != value)
			{
				this.value = value;
				return true;
			}
			if (!VBwPxTbIkugKNhfecudjSBMWZdv(value, DnNEzCellFOTqFhvqLyLZfwgwTQp))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			tdBlaxJijTmcPrPPQHAnaFyhByCgA = false;
			oZunFabiXsKSrhvZHAqZWHLJohvP = null;
			DnNEzCellFOTqFhvqLyLZfwgwTQp.Clear();
		}

		private static bool VBwPxTbIkugKNhfecudjSBMWZdv(IList<T> P_0, IList<T> P_1)
		{
			if (P_0 == P_1)
			{
				return true;
			}
			if (P_0 == null != (P_1 == null))
			{
				return false;
			}
			if (P_0.Count != P_1.Count)
			{
				return false;
			}
			for (int i = 0; i < P_0.Count; i++)
			{
				if (!EqualityComparer<T>.Default.Equals(P_0[i], P_1[i]))
				{
					return false;
				}
			}
			return true;
		}
	}
}
