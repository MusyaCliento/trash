using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> nWbWGuqIoLDuQFPfMldZUlLLiPIG;

		private TEnum[] XnxoJGbpSNAIEGWmqJyPYlCYzber;

		private ReadOnlyCollection<TEnum> xqhQNWOPyzPEudSITeNNwInziNoJA;

		private string[] NFgfJISWmSSECaPcVqwsaLxiNOrp;

		private ReadOnlyCollection<string> ottrHFdltVlsoYkjHNMTNvTOnjeE;

		public static EnumValueHelper<TEnum> Default => nWbWGuqIoLDuQFPfMldZUlLLiPIG ?? (nWbWGuqIoLDuQFPfMldZUlLLiPIG = new EnumValueHelper<TEnum>());

		public IList<TEnum> values => xqhQNWOPyzPEudSITeNNwInziNoJA;

		public IList<string> names
		{
			get
			{
				if (ottrHFdltVlsoYkjHNMTNvTOnjeE == null)
				{
					NFgfJISWmSSECaPcVqwsaLxiNOrp = Enum.GetNames(typeof(TEnum));
					ottrHFdltVlsoYkjHNMTNvTOnjeE = new ReadOnlyCollection<string>(NFgfJISWmSSECaPcVqwsaLxiNOrp);
				}
				return ottrHFdltVlsoYkjHNMTNvTOnjeE;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			XnxoJGbpSNAIEGWmqJyPYlCYzber = (TEnum[])Enum.GetValues(typeof(TEnum));
			xqhQNWOPyzPEudSITeNNwInziNoJA = new ReadOnlyCollection<TEnum>(XnxoJGbpSNAIEGWmqJyPYlCYzber);
		}
	}
}
