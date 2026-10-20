using System;

namespace LibBSP
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class CountAttribute : Attribute
	{
		public string lumpName;

		public CountAttribute(string lumpName)
		{
			this.lumpName = lumpName;
		}
	}
}
