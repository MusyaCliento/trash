using System;
using System.Text;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public struct Bytes32 : IEquatable<Bytes32>
	{
		public long value0;

		public long value1;

		public long value2;

		public long value3;

		public Bytes32(byte[] P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			if (P_0.Length < 32)
			{
				throw new ArgumentException("bytes must be at least 32 bytes");
			}
			value0 = BitConverter.ToInt64(P_0, 0);
			value1 = BitConverter.ToInt64(P_0, 8);
			value2 = BitConverter.ToInt64(P_0, 16);
			value3 = BitConverter.ToInt64(P_0, 24);
		}

		public byte[] GetBytes()
		{
			byte[] array = new byte[32];
			Array.Copy(BitConverter.GetBytes(value0), 0, array, 0, 8);
			Array.Copy(BitConverter.GetBytes(value1), 0, array, 8, 8);
			Array.Copy(BitConverter.GetBytes(value2), 0, array, 16, 8);
			Array.Copy(BitConverter.GetBytes(value3), 0, array, 24, 8);
			return array;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Bytes32 bytes))
			{
				return false;
			}
			if (bytes.value0 == value0 && bytes.value1 == value1 && bytes.value2 == value2)
			{
				return bytes.value3 == value3;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((17 * 29 + value0.GetHashCode()) * 29 + value1.GetHashCode()) * 29 + value2.GetHashCode()) * 29 + value3.GetHashCode();
		}

		public bool Equals(Bytes32 other)
		{
			if (value0 == other.value0 && value1 == other.value1 && value2 == other.value2)
			{
				return value3 == other.value3;
			}
			return false;
		}

		bool IEquatable<Bytes32>.Equals(Bytes32 other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		public static bool operator ==(Bytes32 a, Bytes32 b)
		{
			if (a.value0 == b.value0 && a.value1 == b.value1 && a.value2 == b.value2)
			{
				return a.value3 == b.value3;
			}
			return false;
		}

		public static bool operator !=(Bytes32 a, Bytes32 b)
		{
			return !(a == b);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			byte[] bytes = GetBytes();
			for (int i = 0; i < bytes.Length; i++)
			{
				stringBuilder.Append(bytes[i].ToString("X2"));
			}
			return stringBuilder.ToString();
		}
	}
}
