using System;
using System.Collections.Generic;
using UnityEngine;

public class PacketEncoder
{
	public byte[] EmptyArray()
	{
		return BitConverter.GetBytes(value: false);
	}

	public byte[] SoloByte(byte s)
	{
		return BitConverter.GetBytes(s);
	}

	public byte[] Bool2Byte(bool i)
	{
		return BitConverter.GetBytes(i);
	}

	public byte[] Float2Bytes(float i)
	{
		return BitConverter.GetBytes(i);
	}

	public byte[] Int2Bytes(int i)
	{
		return BitConverter.GetBytes(i);
	}

	public byte[] Vector32Bytes(Vector3 i)
	{
		List<byte> list = new List<byte>();
		list.AddRange(BitConverter.GetBytes(i.x));
		list.AddRange(BitConverter.GetBytes(i.y));
		list.AddRange(BitConverter.GetBytes(i.z));
		return list.ToArray();
	}

	public bool Bytes2Bool(byte[] b, int s = 0)
	{
		return BitConverter.ToBoolean(b, s);
	}

	public Vector3 Bytes2Vector3(byte[] b, int s = 0)
	{
		if (b.Length < 12)
		{
			Debug.Log("Byte array not long enough " + b.Length);
			return Vector3.zero;
		}
		return new Vector3
		{
			x = BitConverter.ToSingle(b, s),
			y = BitConverter.ToSingle(b, 4 + s),
			z = BitConverter.ToSingle(b, 8 + s)
		};
	}

	public byte[] Quaternion2Bytes(Quaternion q)
	{
		return new List<byte>
		{
			(byte)((q.w + 1f) / 2f * 255f),
			(byte)((q.x + 1f) / 2f * 255f),
			(byte)((q.y + 1f) / 2f * 255f),
			(byte)((q.z + 1f) / 2f * 255f)
		}.ToArray();
	}

	public Quaternion Bytes2Quaternion(byte[] b, int s = 0)
	{
		if (b.Length < 4)
		{
			Debug.Log("Byte array not long enough " + b.Length);
			return Quaternion.identity;
		}
		return new Quaternion
		{
			w = (float)(int)b[s] / 255f * 2f - 1f,
			x = (float)(int)b[1 + s] / 255f * 2f - 1f,
			y = (float)(int)b[2 + s] / 255f * 2f - 1f,
			z = (float)(int)b[3 + s] / 255f * 2f - 1f
		};
	}

	public byte[] Dir2Bytes(Vector3 d)
	{
		return new List<byte>
		{
			(byte)((d.x + 1f) / 2f * 255f),
			(byte)((d.y + 1f) / 2f * 255f),
			(byte)((d.z + 1f) / 2f * 255f)
		}.ToArray();
	}

	public Vector3 Bytes2Dir(byte[] b, int s = 0)
	{
		if (b.Length < 3)
		{
			Debug.Log("Byte array not long enough " + b.Length);
			return Vector3.zero;
		}
		return new Vector3
		{
			x = (float)(int)b[s] / 255f * 2f - 1f,
			y = (float)(int)b[1 + s] / 255f * 2f - 1f,
			z = (float)(int)b[2 + s] / 255f * 2f - 1f
		};
	}

	public byte[] PackByte(byte x, ushort y, byte command, byte[] z)
	{
		List<byte> list = new List<byte> { x };
		list.AddRange(BitConverter.GetBytes(y));
		list.Add(command);
		list.AddRange(z);
		list.InsertRange(1, BitConverter.GetBytes(Convert.ToUInt16(list.Count + 2)));
		return list.ToArray();
	}
}
