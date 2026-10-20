namespace LibBSP
{
	public interface ILump
	{
		BSP Bsp { get; }

		LumpInfo LumpInfo { get; }

		int Length { get; }

		byte[] GetBytes();
	}
}
