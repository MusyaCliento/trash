using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorValue<T>
	{
		private T lfszfQOyCyhBwOMPNfWgeScBDHxk;

		private bool DinCjILkEzNsrNyGbwTvPbFFJfnV;

		public bool isSet => DinCjILkEzNsrNyGbwTvPbFFJfnV;

		public T value
		{
			get
			{
				return lfszfQOyCyhBwOMPNfWgeScBDHxk;
			}
			set
			{
				lfszfQOyCyhBwOMPNfWgeScBDHxk = value;
				DinCjILkEzNsrNyGbwTvPbFFJfnV = true;
			}
		}

		public bool SetIfChanged(T value)
		{
			if (!DinCjILkEzNsrNyGbwTvPbFFJfnV)
			{
				this.value = value;
				return false;
			}
			if (!EqualityComparer<T>.Default.Equals(lfszfQOyCyhBwOMPNfWgeScBDHxk, value))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			DinCjILkEzNsrNyGbwTvPbFFJfnV = false;
			lfszfQOyCyhBwOMPNfWgeScBDHxk = default(T);
		}
	}
}
