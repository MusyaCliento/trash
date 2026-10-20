using System;

namespace LibBSP
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class IndexAttribute : Attribute
	{
		public string lumpName;

		public IndexAttribute(string lumpName)
		{
			this.lumpName = lumpName;
		}
	}
}
