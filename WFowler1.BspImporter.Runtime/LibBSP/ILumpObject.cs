namespace LibBSP
{
	public interface ILumpObject
	{
		ILump Parent { get; }

		byte[] Data { get; }

		MapType MapType { get; }

		int LumpVersion { get; }
	}
}
