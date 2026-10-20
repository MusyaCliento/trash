using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeBuffer : IDisposable
	{
		private IntPtr cUrQWrHsxNoObKyFFwLXAcljFpPAA;

		private int YqtYXZzEKiCeprgmFjmrcmEKbITgA;

		private bool DkJFndbOAEczsLOqyLCQLqGASOQjA;

		public IntPtr Pointer => cUrQWrHsxNoObKyFFwLXAcljFpPAA;

		public int Length => YqtYXZzEKiCeprgmFjmrcmEKbITgA;

		public byte this[int index]
		{
			get
			{
				if (index < 0 || index >= YqtYXZzEKiCeprgmFjmrcmEKbITgA)
				{
					throw new IndexOutOfRangeException();
				}
				return Marshal.ReadByte(cUrQWrHsxNoObKyFFwLXAcljFpPAA, index);
			}
			set
			{
				if (index < 0 || index >= YqtYXZzEKiCeprgmFjmrcmEKbITgA)
				{
					throw new IndexOutOfRangeException();
				}
				Marshal.WriteByte(cUrQWrHsxNoObKyFFwLXAcljFpPAA, index, value);
			}
		}

		public NativeBuffer(int P_0)
		{
			Resize(P_0, preserveData: false);
		}

		public IntPtr GetPointer(int offset = 0)
		{
			if (cUrQWrHsxNoObKyFFwLXAcljFpPAA == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			if (offset == 0)
			{
				return cUrQWrHsxNoObKyFFwLXAcljFpPAA;
			}
			if (offset < 0 || offset >= YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			return NativeTools.OffsetIntPtr(cUrQWrHsxNoObKyFFwLXAcljFpPAA, offset);
		}

		public string DumpToHexString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < YqtYXZzEKiCeprgmFjmrcmEKbITgA; i++)
			{
				stringBuilder.Append(ReadByte(i).ToString("x2"));
				stringBuilder.Append(" ");
			}
			return stringBuilder.ToString();
		}

		public bool ReadBit(int byteIndex, byte bit)
		{
			if (1 + byteIndex > Length || byteIndex < 0)
			{
				throw new ArgumentOutOfRangeException("byteIndex");
			}
			if (bit >= 8)
			{
				throw new ArgumentOutOfRangeException("bit");
			}
			return (Marshal.ReadByte(cUrQWrHsxNoObKyFFwLXAcljFpPAA, byteIndex) & (1 << (int)bit)) != 0;
		}

		public byte ReadByte(int startIndex)
		{
			if (1 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadByte(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex);
		}

		public short ReadShort(int startIndex)
		{
			if (2 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt16(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex);
		}

		public ushort ReadUShort(int startIndex)
		{
			if (2 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (ushort)Marshal.ReadInt16(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex);
		}

		public int ReadInt(int startIndex)
		{
			if (4 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt32(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex);
		}

		public uint ReadUInt(int startIndex)
		{
			if (4 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (uint)Marshal.ReadInt32(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex);
		}

		public long ReadLong(int startIndex)
		{
			if (8 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt64(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex);
		}

		public ulong ReadULong(int startIndex)
		{
			if (8 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (ulong)Marshal.ReadInt64(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex);
		}

		public float ReadFloat(int startIndex)
		{
			if (4 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return new QmFFArXNhUTHoISKdWgGnBiasQCf(Marshal.ReadInt32(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex)).JZRjhpiukwsanEiXeaIABjfiCiaGb;
		}

		public double ReadDouble(int startIndex)
		{
			if (8 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return new FznDwpSKoshvSflgKBaKFVEIVAqhA(Marshal.ReadInt64(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex)).pHRPwnQwPBlpeSQVCxYNOiIHTSeb;
		}

		public void Read(byte[] buffer, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = buffer.Length;
			if (num <= 0)
			{
				throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
			}
			if (numBytesToRead <= 0)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
			}
			if (numBytesToRead > num)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
			}
			if (numBytesToRead > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
			}
			if (writeStartIndex >= num)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
			}
			if (writeStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
			}
			if (readStartIndex >= YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
			}
			if (readStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
			}
			if (writeStartIndex + numBytesToRead > num)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
			}
			if (numBytesToRead + readStartIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(cUrQWrHsxNoObKyFFwLXAcljFpPAA, buffer, readStartIndex, writeStartIndex, numBytesToRead);
		}

		public void Read(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("bytes");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
			}
			if (numBytesToRead <= 0)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
			}
			if (numBytesToRead > bufferLength)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
			}
			if (numBytesToRead > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
			}
			if (writeStartIndex >= bufferLength)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
			}
			if (writeStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
			}
			if (readStartIndex >= YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
			}
			if (readStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
			}
			if (writeStartIndex + numBytesToRead > bufferLength)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
			}
			if (numBytesToRead + readStartIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(cUrQWrHsxNoObKyFFwLXAcljFpPAA, buffer, readStartIndex, writeStartIndex, numBytesToRead);
		}

		public int TryReadBytes(byte[] buffer, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == null || numBytesToRead <= 0)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num == 0)
			{
				return 0;
			}
			if (readStartIndex >= YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				return 0;
			}
			if (writeStartIndex >= num)
			{
				return 0;
			}
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (readStartIndex + numBytesToRead > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				numBytesToRead = YqtYXZzEKiCeprgmFjmrcmEKbITgA - readStartIndex;
			}
			if (writeStartIndex + numBytesToRead > num)
			{
				numBytesToRead = num - writeStartIndex;
			}
			if (numBytesToRead == 0)
			{
				return 0;
			}
			if (!NativeTools.CopyMemory(cUrQWrHsxNoObKyFFwLXAcljFpPAA, buffer, readStartIndex, writeStartIndex, numBytesToRead, throwOnError: false))
			{
				return 0;
			}
			return numBytesToRead;
		}

		public int TryReadBytes(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == IntPtr.Zero || numBytesToRead <= 0)
			{
				return 0;
			}
			if (readStartIndex >= YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				return 0;
			}
			if (writeStartIndex >= bufferLength)
			{
				return 0;
			}
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (readStartIndex + numBytesToRead > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				numBytesToRead = YqtYXZzEKiCeprgmFjmrcmEKbITgA - readStartIndex;
			}
			if (writeStartIndex + numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(cUrQWrHsxNoObKyFFwLXAcljFpPAA, buffer, readStartIndex, writeStartIndex, numBytesToRead, throwOnError: false))
			{
				return 0;
			}
			return numBytesToRead;
		}

		public void WriteBit(int byteIndex, byte bit, bool value)
		{
			if (1 + byteIndex > Length || byteIndex < 0)
			{
				throw new ArgumentOutOfRangeException("byteIndex");
			}
			if (bit >= 8)
			{
				throw new ArgumentOutOfRangeException("bit");
			}
			if (value)
			{
				Marshal.WriteByte(cUrQWrHsxNoObKyFFwLXAcljFpPAA, byteIndex, (byte)(Marshal.ReadByte(cUrQWrHsxNoObKyFFwLXAcljFpPAA, byteIndex) | (byte)(1 << (int)bit)));
			}
			else
			{
				Marshal.WriteByte(cUrQWrHsxNoObKyFFwLXAcljFpPAA, byteIndex, (byte)(Marshal.ReadByte(cUrQWrHsxNoObKyFFwLXAcljFpPAA, byteIndex) & (byte)(~(1 << (int)bit))));
			}
		}

		public void Write(byte @byte, int startIndex)
		{
			if (1 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteByte(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex, @byte);
		}

		public void Write(short bytes, int startIndex)
		{
			if (2 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt16(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex, bytes);
		}

		public void Write(ushort bytes, int startIndex)
		{
			if (2 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt16(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex, (short)bytes);
		}

		public void Write(int bytes, int startIndex)
		{
			if (4 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex, bytes);
		}

		public void Write(uint bytes, int startIndex)
		{
			if (4 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex, (int)bytes);
		}

		public void Write(long bytes, int startIndex)
		{
			if (8 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex, bytes);
		}

		public void Write(ulong bytes, int startIndex)
		{
			if (8 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex, (long)bytes);
		}

		public void Write(float bytes, int startIndex)
		{
			if (4 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex, new QmFFArXNhUTHoISKdWgGnBiasQCf(bytes).tdTDQfnvbUkOwJuHqLkgSMdzjCdV);
		}

		public void Write(double bytes, int startIndex)
		{
			if (8 + startIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(cUrQWrHsxNoObKyFFwLXAcljFpPAA, startIndex, new FznDwpSKoshvSflgKBaKFVEIVAqhA(bytes).luaiePPTlrsEQuIFZpbTIGKlrejO);
		}

		public void Write(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num <= 0)
			{
				throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
			}
			if (numBytesToWrite <= 0)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
			}
			if (numBytesToWrite > num)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
			}
			if (numBytesToWrite > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
			}
			if (readStartIndex >= num)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
			}
			if (readStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
			}
			if (writeStartIndex >= YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
			}
			if (writeStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
			}
			if (readStartIndex + numBytesToWrite > num)
			{
				throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
			}
			if (numBytesToWrite + writeStartIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(bytes, cUrQWrHsxNoObKyFFwLXAcljFpPAA, readStartIndex, writeStartIndex, numBytesToWrite);
		}

		public void Write(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == IntPtr.Zero)
			{
				throw new ArgumentNullException("bytes");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
			}
			if (numBytesToWrite <= 0)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
			}
			if (numBytesToWrite > bufferLength)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
			}
			if (numBytesToWrite > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
			}
			if (readStartIndex >= bufferLength)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
			}
			if (readStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
			}
			if (writeStartIndex >= YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
			}
			if (writeStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
			}
			if (readStartIndex + numBytesToWrite > bufferLength)
			{
				throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
			}
			if (numBytesToWrite + writeStartIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(bytes, cUrQWrHsxNoObKyFFwLXAcljFpPAA, readStartIndex, writeStartIndex, numBytesToWrite);
		}

		public int TryWriteBytes(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == null)
			{
				return 0;
			}
			int num = bytes.Length;
			if (num == 0 || numBytesToWrite <= 0 || readStartIndex >= num || writeStartIndex >= YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				return 0;
			}
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (readStartIndex + numBytesToWrite > num)
			{
				numBytesToWrite = num - readStartIndex;
			}
			if (numBytesToWrite + writeStartIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				numBytesToWrite = YqtYXZzEKiCeprgmFjmrcmEKbITgA - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(bytes, cUrQWrHsxNoObKyFFwLXAcljFpPAA, readStartIndex, writeStartIndex, numBytesToWrite, throwOnError: false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		public int TryWriteBytes(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0 || readStartIndex >= bufferLength || writeStartIndex >= YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				return 0;
			}
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (readStartIndex + numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength - readStartIndex;
			}
			if (numBytesToWrite + writeStartIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				numBytesToWrite = YqtYXZzEKiCeprgmFjmrcmEKbITgA - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(bytes, cUrQWrHsxNoObKyFFwLXAcljFpPAA, readStartIndex, writeStartIndex, numBytesToWrite, throwOnError: false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		public int TryFill(byte value, int numBytesToWrite, int writeStartIndex = 0)
		{
			if (numBytesToWrite <= 0 || writeStartIndex >= YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				return 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (numBytesToWrite + writeStartIndex > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
			{
				numBytesToWrite = YqtYXZzEKiCeprgmFjmrcmEKbITgA - writeStartIndex;
			}
			if (!NativeTools.FillMemory(cUrQWrHsxNoObKyFFwLXAcljFpPAA, writeStartIndex, numBytesToWrite, value, throwOnError: false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		public bool Resize(int size, bool preserveData)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			if (YqtYXZzEKiCeprgmFjmrcmEKbITgA == size)
			{
				return true;
			}
			if (size == 0)
			{
				Release();
				return true;
			}
			IntPtr intPtr;
			if (preserveData)
			{
				try
				{
					intPtr = Marshal.AllocHGlobal(size);
					if (intPtr == IntPtr.Zero)
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
				int bytesToCopy = MathTools.Min(size, YqtYXZzEKiCeprgmFjmrcmEKbITgA);
				if (!NativeTools.CopyMemory(cUrQWrHsxNoObKyFFwLXAcljFpPAA, intPtr, 0, 0, bytesToCopy, throwOnError: false))
				{
					Marshal.FreeHGlobal(intPtr);
					return false;
				}
				if (size > YqtYXZzEKiCeprgmFjmrcmEKbITgA)
				{
					NativeTools.FillMemory(intPtr, YqtYXZzEKiCeprgmFjmrcmEKbITgA, size - YqtYXZzEKiCeprgmFjmrcmEKbITgA, 0, throwOnError: false);
				}
				Release();
			}
			else
			{
				Release();
				try
				{
					intPtr = Marshal.AllocHGlobal(size);
					if (intPtr == IntPtr.Zero)
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
				NativeTools.ZeroFillMemory(intPtr, size);
			}
			cUrQWrHsxNoObKyFFwLXAcljFpPAA = intPtr;
			YqtYXZzEKiCeprgmFjmrcmEKbITgA = size;
			return true;
		}

		public void Clear()
		{
			if (YqtYXZzEKiCeprgmFjmrcmEKbITgA != 0)
			{
				NativeTools.ZeroFillMemory(cUrQWrHsxNoObKyFFwLXAcljFpPAA, YqtYXZzEKiCeprgmFjmrcmEKbITgA);
			}
		}

		public void Release()
		{
			if (cUrQWrHsxNoObKyFFwLXAcljFpPAA != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(Pointer);
				cUrQWrHsxNoObKyFFwLXAcljFpPAA = IntPtr.Zero;
			}
			YqtYXZzEKiCeprgmFjmrcmEKbITgA = 0;
		}

		public void CopyFrom(NativeBuffer other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (!(cUrQWrHsxNoObKyFFwLXAcljFpPAA == IntPtr.Zero) && !(other.Pointer == IntPtr.Zero))
			{
				int bytesToCopy = MathTools.Min(YqtYXZzEKiCeprgmFjmrcmEKbITgA, other.YqtYXZzEKiCeprgmFjmrcmEKbITgA);
				NativeTools.CopyMemory(other.cUrQWrHsxNoObKyFFwLXAcljFpPAA, cUrQWrHsxNoObKyFFwLXAcljFpPAA, 0, 0, bytesToCopy);
			}
		}

		public override string ToString()
		{
			return "Length = " + YqtYXZzEKiCeprgmFjmrcmEKbITgA + "\nPointer = " + cUrQWrHsxNoObKyFFwLXAcljFpPAA + "\n";
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~NativeBuffer()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!DkJFndbOAEczsLOqyLCQLqGASOQjA)
			{
				Release();
				DkJFndbOAEczsLOqyLCQLqGASOQjA = true;
			}
		}

		public static implicit operator IntPtr(NativeBuffer buffer)
		{
			return buffer?.cUrQWrHsxNoObKyFFwLXAcljFpPAA ?? IntPtr.Zero;
		}

		public static bool Copy(NativeBuffer source, NativeBuffer destination)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (source.YqtYXZzEKiCeprgmFjmrcmEKbITgA == 0)
			{
				destination.Release();
				return true;
			}
			if (destination.Resize(source.YqtYXZzEKiCeprgmFjmrcmEKbITgA, preserveData: false))
			{
				return NativeTools.CopyMemory(source.cUrQWrHsxNoObKyFFwLXAcljFpPAA, destination.cUrQWrHsxNoObKyFFwLXAcljFpPAA, 0, 0, source.YqtYXZzEKiCeprgmFjmrcmEKbITgA, throwOnError: false);
			}
			return false;
		}
	}
}
