using System.IO;

namespace LibBSP
{
	public struct LumpInfo
	{
		public int ident;

		public int flags;

		public int version;

		public int offset;

		public int length;

		public FileInfo lumpFile;
	}
}
