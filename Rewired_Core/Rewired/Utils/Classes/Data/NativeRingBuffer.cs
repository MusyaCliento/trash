using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer uwICflBaOMypUMlPEDoZkLgCdrtEA;

		private readonly int XshRSIqfCTMSjymVMpJlHOyBAQnIA;

		private long XHTdTNIchhKRiyHJecatDQGHLEOMB;

		private long JjvNmDXLHrYQzflcQBnXDERdYuaR;

		private int psdadCgafARGkgnUadxkGRVyrXcGb;

		private bool JKZQaOKLGPKWbIhpYFvOOeLTONsx;

		private uint mZEYaVxinwFASNpxudzOhmSnDVqK;

		private bool ldQpFZAKXrClUNZfYHrXxLgvcQFs;

		public int Capacity => XshRSIqfCTMSjymVMpJlHOyBAQnIA;

		public int BytesInBuffer => psdadCgafARGkgnUadxkGRVyrXcGb;

		public bool BufferOverrun => JKZQaOKLGPKWbIhpYFvOOeLTONsx;

		public int ReadPosition => (int)JjvNmDXLHrYQzflcQBnXDERdYuaR;

		public long WritePosition => XHTdTNIchhKRiyHJecatDQGHLEOMB;

		public NativeRingBuffer(int P_0)
		{
			XshRSIqfCTMSjymVMpJlHOyBAQnIA = P_0;
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			uwICflBaOMypUMlPEDoZkLgCdrtEA = new NativeBuffer(P_0);
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = uwICflBaOMypUMlPEDoZkLgCdrtEA.GetPointer((int)XHTdTNIchhKRiyHJecatDQGHLEOMB);
			passId = mZEYaVxinwFASNpxudzOhmSnDVqK;
			if (zeroFill)
			{
				int num = 0;
				uwICflBaOMypUMlPEDoZkLgCdrtEA.TryFill(0, bufferLength, (int)XHTdTNIchhKRiyHJecatDQGHLEOMB);
				if (num == 0)
				{
					return IntPtr.Zero;
				}
				if (num < bufferLength)
				{
					num += uwICflBaOMypUMlPEDoZkLgCdrtEA.TryFill(0, bufferLength - num, num);
				}
			}
			KnSvihJMeVHvinDdnGHAAdZpOvbDA(bufferLength);
			return pointer;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)XHTdTNIchhKRiyHJecatDQGHLEOMB;
			passId = mZEYaVxinwFASNpxudzOhmSnDVqK;
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
			}
			int num = uwICflBaOMypUMlPEDoZkLgCdrtEA.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)XHTdTNIchhKRiyHJecatDQGHLEOMB);
			if (num == 0)
			{
				return 0;
			}
			if (num < numBytesToWrite)
			{
				num += uwICflBaOMypUMlPEDoZkLgCdrtEA.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
			}
			KnSvihJMeVHvinDdnGHAAdZpOvbDA(num);
			return num;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)XHTdTNIchhKRiyHJecatDQGHLEOMB;
			passId = mZEYaVxinwFASNpxudzOhmSnDVqK;
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > num)
			{
				numBytesToWrite = num;
			}
			int num2 = uwICflBaOMypUMlPEDoZkLgCdrtEA.TryWriteBytes(buffer, numBytesToWrite, (int)XHTdTNIchhKRiyHJecatDQGHLEOMB);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 < numBytesToWrite)
			{
				num2 += uwICflBaOMypUMlPEDoZkLgCdrtEA.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
			}
			KnSvihJMeVHvinDdnGHAAdZpOvbDA(num2);
			return num2;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite)
		{
			int startOffset;
			uint passId;
			return Write(buffer, bufferLength, numBytesToWrite, out startOffset, out passId);
		}

		public int Write(byte[] buffer, int numBytesToWrite)
		{
			int startOffset;
			uint passId;
			return Write(buffer, numBytesToWrite, out startOffset, out passId);
		}

		public int Read(IntPtr buffer, int bufferLength, int numBytesToRead)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || psdadCgafARGkgnUadxkGRVyrXcGb == 0)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > psdadCgafARGkgnUadxkGRVyrXcGb)
			{
				numBytesToRead = psdadCgafARGkgnUadxkGRVyrXcGb;
			}
			int num = uwICflBaOMypUMlPEDoZkLgCdrtEA.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)JjvNmDXLHrYQzflcQBnXDERdYuaR);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += uwICflBaOMypUMlPEDoZkLgCdrtEA.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			cinCWbhysBbCsBifWXBbuVZVcgnCA(num);
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || psdadCgafARGkgnUadxkGRVyrXcGb == 0)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > psdadCgafARGkgnUadxkGRVyrXcGb)
			{
				numBytesToRead = psdadCgafARGkgnUadxkGRVyrXcGb;
			}
			int num2 = uwICflBaOMypUMlPEDoZkLgCdrtEA.TryReadBytes(buffer, numBytesToRead, (int)JjvNmDXLHrYQzflcQBnXDERdYuaR);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += uwICflBaOMypUMlPEDoZkLgCdrtEA.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			cinCWbhysBbCsBifWXBbuVZVcgnCA(num2);
			return num2;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || psdadCgafARGkgnUadxkGRVyrXcGb == 0 || readStartIndex < 0 || readStartIndex >= XshRSIqfCTMSjymVMpJlHOyBAQnIA)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > psdadCgafARGkgnUadxkGRVyrXcGb)
			{
				numBytesToRead = psdadCgafARGkgnUadxkGRVyrXcGb;
			}
			int num = uwICflBaOMypUMlPEDoZkLgCdrtEA.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += uwICflBaOMypUMlPEDoZkLgCdrtEA.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			return num;
		}

		public int RandomRead(byte[] buffer, int numBytesToRead, int readStartIndex)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || psdadCgafARGkgnUadxkGRVyrXcGb == 0 || readStartIndex < 0 || readStartIndex >= XshRSIqfCTMSjymVMpJlHOyBAQnIA)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > psdadCgafARGkgnUadxkGRVyrXcGb)
			{
				numBytesToRead = psdadCgafARGkgnUadxkGRVyrXcGb;
			}
			int num2 = uwICflBaOMypUMlPEDoZkLgCdrtEA.TryReadBytes(buffer, numBytesToRead, readStartIndex);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += uwICflBaOMypUMlPEDoZkLgCdrtEA.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			return num2;
		}

		public IntPtr GetPointerFromReadPosition(int offset)
		{
			int offsetFromReadPosition = GetOffsetFromReadPosition(offset);
			if (offsetFromReadPosition < 0)
			{
				return IntPtr.Zero;
			}
			return uwICflBaOMypUMlPEDoZkLgCdrtEA.GetPointer(offsetFromReadPosition);
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)JjvNmDXLHrYQzflcQBnXDERdYuaR + offset;
			if (num >= XshRSIqfCTMSjymVMpJlHOyBAQnIA)
			{
				num -= XshRSIqfCTMSjymVMpJlHOyBAQnIA;
			}
			else if (num < 0)
			{
				num += XshRSIqfCTMSjymVMpJlHOyBAQnIA;
			}
			if (num < 0 || num >= XshRSIqfCTMSjymVMpJlHOyBAQnIA)
			{
				return -1;
			}
			return num;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex < 0 || startIndex >= XshRSIqfCTMSjymVMpJlHOyBAQnIA)
			{
				return false;
			}
			if (startIndex < XHTdTNIchhKRiyHJecatDQGHLEOMB)
			{
				if (passId == mZEYaVxinwFASNpxudzOhmSnDVqK)
				{
					return true;
				}
			}
			else if (startIndex >= XHTdTNIchhKRiyHJecatDQGHLEOMB)
			{
				if (mZEYaVxinwFASNpxudzOhmSnDVqK == 0)
				{
					return false;
				}
				if (mZEYaVxinwFASNpxudzOhmSnDVqK - 1 == passId)
				{
					return true;
				}
			}
			return false;
		}

		public void CopyFrom(NativeRingBuffer other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (XshRSIqfCTMSjymVMpJlHOyBAQnIA != other.XshRSIqfCTMSjymVMpJlHOyBAQnIA)
			{
				throw new Exception("Buffer does not have the same capacity. Cannot copy.");
			}
			XHTdTNIchhKRiyHJecatDQGHLEOMB = other.XHTdTNIchhKRiyHJecatDQGHLEOMB;
			JjvNmDXLHrYQzflcQBnXDERdYuaR = other.JjvNmDXLHrYQzflcQBnXDERdYuaR;
			psdadCgafARGkgnUadxkGRVyrXcGb = other.psdadCgafARGkgnUadxkGRVyrXcGb;
			JKZQaOKLGPKWbIhpYFvOOeLTONsx = other.JKZQaOKLGPKWbIhpYFvOOeLTONsx;
			mZEYaVxinwFASNpxudzOhmSnDVqK = other.mZEYaVxinwFASNpxudzOhmSnDVqK;
			uwICflBaOMypUMlPEDoZkLgCdrtEA.CopyFrom(other.uwICflBaOMypUMlPEDoZkLgCdrtEA);
		}

		public void Reset()
		{
			XHTdTNIchhKRiyHJecatDQGHLEOMB = 0L;
			JjvNmDXLHrYQzflcQBnXDERdYuaR = 0L;
			psdadCgafARGkgnUadxkGRVyrXcGb = 0;
			JKZQaOKLGPKWbIhpYFvOOeLTONsx = false;
			mZEYaVxinwFASNpxudzOhmSnDVqK = 0u;
		}

		private void KnSvihJMeVHvinDdnGHAAdZpOvbDA(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			int num = (int)XHTdTNIchhKRiyHJecatDQGHLEOMB;
			XHTdTNIchhKRiyHJecatDQGHLEOMB += P_0;
			bool flag = false;
			if (num < JjvNmDXLHrYQzflcQBnXDERdYuaR)
			{
				if (XHTdTNIchhKRiyHJecatDQGHLEOMB > JjvNmDXLHrYQzflcQBnXDERdYuaR)
				{
					flag = true;
				}
			}
			else if (num > JjvNmDXLHrYQzflcQBnXDERdYuaR)
			{
				if (XHTdTNIchhKRiyHJecatDQGHLEOMB - XshRSIqfCTMSjymVMpJlHOyBAQnIA > JjvNmDXLHrYQzflcQBnXDERdYuaR)
				{
					flag = true;
				}
			}
			else if (psdadCgafARGkgnUadxkGRVyrXcGb > 0)
			{
				flag = true;
			}
			if (flag)
			{
				JKZQaOKLGPKWbIhpYFvOOeLTONsx = true;
				JjvNmDXLHrYQzflcQBnXDERdYuaR = XHTdTNIchhKRiyHJecatDQGHLEOMB;
				if (JjvNmDXLHrYQzflcQBnXDERdYuaR >= XshRSIqfCTMSjymVMpJlHOyBAQnIA)
				{
					JjvNmDXLHrYQzflcQBnXDERdYuaR -= XshRSIqfCTMSjymVMpJlHOyBAQnIA;
				}
			}
			if (XHTdTNIchhKRiyHJecatDQGHLEOMB >= XshRSIqfCTMSjymVMpJlHOyBAQnIA)
			{
				XHTdTNIchhKRiyHJecatDQGHLEOMB -= XshRSIqfCTMSjymVMpJlHOyBAQnIA;
				PzLLioNeWvYzGdShLxFHMpBVwexm();
			}
			psdadCgafARGkgnUadxkGRVyrXcGb = (int)MathTools.Clamp((long)psdadCgafARGkgnUadxkGRVyrXcGb + (long)P_0, 0L, XshRSIqfCTMSjymVMpJlHOyBAQnIA);
		}

		private void cinCWbhysBbCsBifWXBbuVZVcgnCA(int P_0)
		{
			if (P_0 > 0)
			{
				if (JKZQaOKLGPKWbIhpYFvOOeLTONsx)
				{
					JKZQaOKLGPKWbIhpYFvOOeLTONsx = false;
				}
				JjvNmDXLHrYQzflcQBnXDERdYuaR += P_0;
				if (JjvNmDXLHrYQzflcQBnXDERdYuaR >= XshRSIqfCTMSjymVMpJlHOyBAQnIA)
				{
					JjvNmDXLHrYQzflcQBnXDERdYuaR -= XshRSIqfCTMSjymVMpJlHOyBAQnIA;
				}
				long num = (long)psdadCgafARGkgnUadxkGRVyrXcGb - (long)P_0;
				psdadCgafARGkgnUadxkGRVyrXcGb = (int)((num >= 0) ? num : 0);
			}
		}

		private void PzLLioNeWvYzGdShLxFHMpBVwexm()
		{
			if (mZEYaVxinwFASNpxudzOhmSnDVqK == uint.MaxValue)
			{
				mZEYaVxinwFASNpxudzOhmSnDVqK = 0u;
			}
			else
			{
				mZEYaVxinwFASNpxudzOhmSnDVqK++;
			}
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

		~NativeRingBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!ldQpFZAKXrClUNZfYHrXxLgvcQFs)
			{
				if (disposing && uwICflBaOMypUMlPEDoZkLgCdrtEA != null)
				{
					uwICflBaOMypUMlPEDoZkLgCdrtEA.Dispose();
				}
				ldQpFZAKXrClUNZfYHrXxLgvcQFs = true;
			}
		}
	}
}
