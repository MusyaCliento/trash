namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] FmOKJGmgdxBwXhgNMizVvoTWMzr;

		public int Length
		{
			get
			{
				if (FmOKJGmgdxBwXhgNMizVvoTWMzr == null)
				{
					return 0;
				}
				return FmOKJGmgdxBwXhgNMizVvoTWMzr.Length;
			}
		}

		public T this[int index] => FmOKJGmgdxBwXhgNMizVvoTWMzr[index];

		public ReadOnlyArrayStruct(T[] P_0)
		{
			FmOKJGmgdxBwXhgNMizVvoTWMzr = P_0;
		}
	}
}
