namespace LibBSP
{
	public static class MapTypeExtensions
	{
		public static bool IsSubtypeOf(this MapType type, MapType other)
		{
			return (type & other) == other;
		}
	}
}
