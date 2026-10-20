using System;
using System.Collections;
using System.Collections.Generic;

namespace LibBSP
{
	public class NumList : IList<long>, ICollection<long>, IEnumerable<long>, IEnumerable, IList, ICollection, ILump
	{
		public enum DataType
		{
			Invalid = 0,
			SByte = 1,
			Byte = 2,
			Int16 = 3,
			UInt16 = 4,
			Int32 = 5,
			UInt32 = 6,
			Int64 = 7
		}

		public BSP Bsp { get; protected set; }

		public LumpInfo LumpInfo { get; protected set; }

		public byte[] Data { get; private set; }

		public int Length => Data.Length;

		public DataType Type { get; private set; }

		public int StructLength
		{
			get
			{
				switch (Type)
				{
				case DataType.SByte:
				case DataType.Byte:
					return 1;
				case DataType.Int16:
				case DataType.UInt16:
					return 2;
				case DataType.Int32:
				case DataType.UInt32:
					return 4;
				case DataType.Int64:
					return 8;
				default:
					return 0;
				}
			}
		}

		public int Count => Data.Length / StructLength;

		public bool IsReadOnly => false;

		public object SyncRoot => Data.SyncRoot;

		public bool IsSynchronized => Data.IsSynchronized;

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				if (value is byte || value is sbyte || value is short || value is ushort || value is int || value is uint || value is long)
				{
					this[index] = (long)value;
				}
			}
		}

		public bool IsFixedSize => false;

		public long this[int index]
		{
			get
			{
				return Type switch
				{
					DataType.SByte => (sbyte)Data[index], 
					DataType.Byte => Data[index], 
					DataType.Int16 => BitConverter.ToInt16(Data, index * 2), 
					DataType.UInt16 => BitConverter.ToUInt16(Data, index * 2), 
					DataType.Int32 => BitConverter.ToInt32(Data, index * 4), 
					DataType.UInt32 => BitConverter.ToUInt32(Data, index * 4), 
					DataType.Int64 => BitConverter.ToInt64(Data, index * 8), 
					_ => 0L, 
				};
			}
			set
			{
				Array.Copy(BitConverter.GetBytes(value), 0, Data, index * StructLength, StructLength);
			}
		}

		public NumList(byte[] data, DataType type, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Bsp = bsp;
			LumpInfo = lumpInfo;
			Data = data;
			Type = type;
		}

		public NumList(NumList original, DataType type, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
		{
			Bsp = bsp;
			LumpInfo = lumpInfo;
			Type = type;
			Data = new byte[original.Count * StructLength];
			for (int i = 0; i < original.Count; i++)
			{
				this[i] = original[i];
			}
		}

		public NumList(DataType type)
		{
			Data = new byte[0];
			Type = type;
		}

		public static NumList LumpFactory(byte[] data, DataType type, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
		{
			return new NumList(data, type, bsp, lumpInfo);
		}

		public byte[] GetBytes()
		{
			return Data;
		}

		public static int GetIndexForLeafFacesLump(MapType version, out DataType dataType)
		{
			switch (version)
			{
			case MapType.Nightfire:
				dataType = DataType.UInt32;
				return 12;
			case MapType.Vindictus:
				dataType = DataType.UInt32;
				return 16;
			default:
				if (version.IsSubtypeOf(MapType.Quake))
				{
					dataType = DataType.UInt16;
					return 11;
				}
				if (version == MapType.CoD || version == MapType.CoDDemo)
				{
					dataType = DataType.UInt32;
					return 23;
				}
				if (version.IsSubtypeOf(MapType.Quake2))
				{
					dataType = DataType.UInt16;
					return 9;
				}
				if (version.IsSubtypeOf(MapType.STEF2))
				{
					dataType = DataType.UInt32;
					return 9;
				}
				if (version.IsSubtypeOf(MapType.FAKK2) || version.IsSubtypeOf(MapType.MOHAA))
				{
					dataType = DataType.Int32;
					return 7;
				}
				if (version.IsSubtypeOf(MapType.Source))
				{
					dataType = DataType.UInt16;
					return 16;
				}
				if (version.IsSubtypeOf(MapType.Quake3))
				{
					dataType = DataType.Int32;
					return 5;
				}
				dataType = DataType.Invalid;
				return -1;
			}
		}

		public static int GetIndexForFaceEdgesLump(MapType version, out DataType dataType)
		{
			if (version.IsSubtypeOf(MapType.Quake2))
			{
				dataType = DataType.Int32;
				return 12;
			}
			if (version.IsSubtypeOf(MapType.Quake) || version.IsSubtypeOf(MapType.Source))
			{
				dataType = DataType.Int32;
				return 13;
			}
			dataType = DataType.Invalid;
			return -1;
		}

		public static int GetIndexForLeafBrushesLump(MapType version, out DataType dataType)
		{
			if (version == MapType.Nightfire)
			{
				dataType = DataType.UInt32;
				return 13;
			}
			if (version.IsSubtypeOf(MapType.STEF2))
			{
				dataType = DataType.UInt32;
				return 8;
			}
			if (version.IsSubtypeOf(MapType.Quake2))
			{
				dataType = DataType.UInt16;
				return 10;
			}
			switch (version)
			{
			case MapType.Vindictus:
				dataType = DataType.UInt32;
				return 17;
			case MapType.CoD:
			case MapType.CoDDemo:
				dataType = DataType.UInt32;
				return 22;
			case MapType.CoD2:
				dataType = DataType.UInt32;
				return 27;
			case MapType.CoD4:
				dataType = DataType.UInt32;
				return 29;
			default:
				if (version.IsSubtypeOf(MapType.Source))
				{
					dataType = DataType.UInt16;
					return 17;
				}
				if (version.IsSubtypeOf(MapType.Quake3))
				{
					dataType = DataType.UInt32;
					return 6;
				}
				dataType = DataType.Invalid;
				return -1;
			}
		}

		public static int GetIndexForIndicesLump(MapType version, out DataType dataType)
		{
			switch (version)
			{
			case MapType.Nightfire:
				dataType = DataType.UInt32;
				return 6;
			case MapType.CoD:
			case MapType.CoDDemo:
				dataType = DataType.UInt16;
				return 8;
			case MapType.CoD2:
				dataType = DataType.UInt16;
				return 9;
			case MapType.CoD4:
				dataType = DataType.UInt16;
				return 11;
			default:
				if (version.IsSubtypeOf(MapType.FAKK2) || version.IsSubtypeOf(MapType.MOHAA))
				{
					dataType = DataType.UInt32;
					return 5;
				}
				if (version.IsSubtypeOf(MapType.STEF2))
				{
					dataType = DataType.UInt32;
					return 7;
				}
				if (version.IsSubtypeOf(MapType.Quake3))
				{
					dataType = DataType.UInt32;
					return 11;
				}
				dataType = DataType.Invalid;
				return -1;
			}
		}

		public static int GetIndexForPatchIndicesLump(MapType version, out DataType dataType)
		{
			if (version == MapType.CoD || version == MapType.CoDDemo)
			{
				dataType = DataType.UInt32;
				return 23;
			}
			dataType = DataType.Invalid;
			return -1;
		}

		public static int GetIndexForLeafPatchesLump(MapType version, out DataType dataType)
		{
			if (version == MapType.CoD || version == MapType.CoDDemo)
			{
				dataType = DataType.UInt32;
				return 26;
			}
			dataType = DataType.Invalid;
			return -1;
		}

		public static int GetIndexForLeafStaticModelsLump(MapType version, out DataType dataType)
		{
			if (version == MapType.MOHAADemo)
			{
				dataType = DataType.UInt16;
				return 27;
			}
			if (version.IsSubtypeOf(MapType.MOHAA))
			{
				dataType = DataType.UInt16;
				return 26;
			}
			dataType = DataType.Invalid;
			return -1;
		}

		public static int GetIndexForTexTableLump(MapType version, out DataType dataType)
		{
			if (version.IsSubtypeOf(MapType.Source) || version == MapType.Titanfall)
			{
				dataType = DataType.Int32;
				return 44;
			}
			dataType = DataType.Invalid;
			return -1;
		}

		public static int GetIndexForDisplacementTrianglesLump(MapType version, out DataType dataType)
		{
			if (version.IsSubtypeOf(MapType.Source))
			{
				dataType = DataType.UInt16;
				return 48;
			}
			dataType = DataType.Invalid;
			return -1;
		}

		public void Add(long value)
		{
			byte[] array = new byte[Data.Length + StructLength];
			Array.Copy(Data, 0, array, 0, Data.Length);
			Array.Copy(BitConverter.GetBytes(value), 0, array, Data.Length, StructLength);
			Data = array;
		}

		public void Clear()
		{
			Data = new byte[0];
		}

		public bool Contains(long value)
		{
			using (IEnumerator<long> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == value)
					{
						return true;
					}
				}
			}
			return false;
		}

		public void CopyTo(long[] array, int arrayIndex)
		{
			for (int i = 0; i < Count; i++)
			{
				array[i + arrayIndex] = this[i];
			}
		}

		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			for (int i = 0; i < Count; i++)
			{
				array.SetValue(this[i], i + arrayIndex);
			}
		}

		public bool Remove(long value)
		{
			for (int i = 0; i < Count; i++)
			{
				if (this[i] == value)
				{
					RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		public IEnumerator<long> GetEnumerator()
		{
			int i = 0;
			while (i < Count)
			{
				yield return this[i];
				int num = i + 1;
				i = num;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			int i = 0;
			while (i < Count)
			{
				yield return this[i];
				int num = i + 1;
				i = num;
			}
		}

		public int Add(object obj)
		{
			if (obj is byte || obj is sbyte || obj is short || obj is ushort || obj is int || obj is uint || obj is long)
			{
				Add((long)obj);
				return Count - 1;
			}
			return -1;
		}

		public bool Contains(object obj)
		{
			if (obj is byte || obj is sbyte || obj is short || obj is ushort || obj is int || obj is uint || obj is long)
			{
				return Contains((long)obj);
			}
			return false;
		}

		public int IndexOf(object obj)
		{
			if (obj is byte || obj is sbyte || obj is short || obj is ushort || obj is int || obj is uint || obj is long)
			{
				return IndexOf((long)obj);
			}
			return -1;
		}

		public void Insert(int index, object obj)
		{
			if (obj is byte || obj is sbyte || obj is short || obj is ushort || obj is int || obj is uint || obj is long)
			{
				Insert(index, (long)obj);
			}
		}

		public void Remove(object obj)
		{
			if (obj is byte || obj is sbyte || obj is short || obj is ushort || obj is int || obj is uint || obj is long)
			{
				Remove((long)obj);
			}
		}

		public int IndexOf(long value)
		{
			for (int i = 0; i < Count; i++)
			{
				if (this[i] == value)
				{
					return i;
				}
			}
			return -1;
		}

		public void Insert(int index, long value)
		{
			byte[] array = new byte[Data.Length + StructLength];
			Array.Copy(Data, 0, array, 0, StructLength * index);
			Array.Copy(BitConverter.GetBytes(value), 0, array, StructLength * index, StructLength);
			Array.Copy(Data, StructLength * index, array, StructLength * (index + 1), Data.Length - StructLength * index);
			Data = array;
		}

		public void RemoveAt(int index)
		{
			byte[] array = new byte[Data.Length - StructLength];
			Array.Copy(Data, 0, array, 0, StructLength * index);
			Array.Copy(Data, StructLength * (index + 1), array, StructLength * index, Data.Length - StructLength * (index + 1));
			Data = array;
		}

		public void RemoveAll()
		{
			Data = new byte[0];
		}
	}
}
