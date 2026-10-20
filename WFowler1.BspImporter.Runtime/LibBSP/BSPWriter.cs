using System.IO;

namespace LibBSP
{
	public class BSPWriter
	{
		private BSP _bsp;

		private int _numLumps;

		public BSPWriter(BSP bsp)
		{
			_bsp = bsp;
			_numLumps = BSP.GetNumLumps(_bsp.MapType);
		}

		public void WriteBSP(string path)
		{
			BSPHeader newHeader = _bsp.Header.Regenerate();
			byte[][] lumpsBytes = GetLumpsBytes();
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			WriteAllData(path, newHeader.Data, lumpsBytes);
			_bsp.MapName = Path.GetFileNameWithoutExtension(path);
			_bsp.UpdateHeader(newHeader);
			_bsp.Reader.BspFile = new FileInfo(path);
		}

		private byte[][] GetLumpsBytes()
		{
			byte[][] array = new byte[_numLumps][];
			for (int i = 0; i < _numLumps; i++)
			{
				ILump loadedLump = _bsp.GetLoadedLump(i);
				byte[] array2 = ((loadedLump == null) ? _bsp.Reader.ReadLump(_bsp.Header.GetLumpInfo(i)) : loadedLump.GetBytes());
				array[i] = array2;
			}
			return array;
		}

		private void WriteAllData(string path, byte[] header, byte[][] lumpBytes)
		{
			using FileStream fileStream = File.OpenWrite(path);
			fileStream.Seek(0L, SeekOrigin.Begin);
			fileStream.Write(header, 0, header.Length);
			int num = header.Length;
			for (int i = 0; i < _numLumps; i++)
			{
				fileStream.Write(lumpBytes[i], 0, lumpBytes[i].Length);
				num += lumpBytes[i].Length;
			}
		}
	}
}
