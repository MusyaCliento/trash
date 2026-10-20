using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	public struct Patch : ILumpObject
	{
		public ILump Parent { get; private set; }

		public byte[] Data { get; private set; }

		public MapType MapType
		{
			get
			{
				if (Parent == null || Parent.Bsp == null)
				{
					return MapType.Undefined;
				}
				return Parent.Bsp.MapType;
			}
		}

		public int LumpVersion
		{
			get
			{
				if (Parent == null)
				{
					return 0;
				}
				return Parent.LumpInfo.version;
			}
		}

		public Texture Shader => Parent.Bsp.Textures[ShaderIndex];

		public int ShaderIndex
		{
			get
			{
				if (MapType == MapType.CoD)
				{
					return BitConverter.ToInt16(Data, 0);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD)
				{
					bytes.CopyTo(Data, 0);
				}
			}
		}

		public short Type
		{
			get
			{
				if (MapType == MapType.CoD)
				{
					return BitConverter.ToInt16(Data, 2);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD)
				{
					bytes.CopyTo(Data, 2);
				}
			}
		}

		public Vector2 Dimensions
		{
			get
			{
				if (MapType == MapType.CoD)
				{
					if (Type == 0)
					{
						return new Vector2(BitConverter.ToInt16(Data, 4), BitConverter.ToInt16(Data, 6));
					}
					return new Vector2(0f, 0f);
				}
				return new Vector2(0f, 0f);
			}
			set
			{
				if (MapType == MapType.CoD && Type == 0)
				{
					BitConverter.GetBytes((short)value.X()).CopyTo(Data, 4);
					BitConverter.GetBytes((short)value.Y()).CopyTo(Data, 6);
				}
			}
		}

		public int Flags
		{
			get
			{
				if (MapType == MapType.CoD)
				{
					if (Type == 0)
					{
						return BitConverter.ToInt32(Data, 8);
					}
					return -1;
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD && Type == 0)
				{
					bytes.CopyTo(Data, 8);
				}
			}
		}

		public IEnumerable<Vector3> Vertices
		{
			get
			{
				int i = 0;
				while (i < NumVertices)
				{
					yield return Parent.Bsp.PatchVertices[FirstVertex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("PatchVertices")]
		public int FirstVertex
		{
			get
			{
				if (MapType == MapType.CoD)
				{
					if (Type == 0)
					{
						return BitConverter.ToInt32(Data, 12);
					}
					if (Type == 1)
					{
						return BitConverter.ToInt32(Data, 8);
					}
					return -1;
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD)
				{
					if (Type == 0)
					{
						bytes.CopyTo(Data, 12);
					}
					else if (Type == 1)
					{
						bytes.CopyTo(Data, 8);
					}
				}
			}
		}

		[Count("PatchVertices")]
		public int NumVertices
		{
			get
			{
				if (MapType == MapType.CoD)
				{
					if (Type == 0)
					{
						return BitConverter.ToInt16(Data, 4) * BitConverter.ToInt16(Data, 6);
					}
					if (Type == 1)
					{
						return BitConverter.ToInt16(Data, 4);
					}
					return -1;
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD)
				{
					if (Type != 1)
					{
						throw new NotSupportedException("Cannot set count of Patch Vertices on a pure patch. Set Patch.Dimensions instead.");
					}
					Data[4] = bytes[0];
					Data[5] = bytes[1];
				}
			}
		}

		public IEnumerable<short> VertexIndices
		{
			get
			{
				int i = 0;
				while (i < NumVertexIndices)
				{
					yield return (short)Parent.Bsp.PatchIndices[FirstVertexIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Count("PatchIndices")]
		public int NumVertexIndices
		{
			get
			{
				if (MapType == MapType.CoD)
				{
					if (Type == 1)
					{
						return BitConverter.ToInt16(Data, 6);
					}
					return -1;
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD && Type == 1)
				{
					Data[6] = bytes[0];
					Data[7] = bytes[1];
				}
			}
		}

		[Index("PatchIndices")]
		public int FirstVertexIndex
		{
			get
			{
				if (MapType == MapType.CoD)
				{
					if (Type == 1)
					{
						return BitConverter.ToInt32(Data, 12);
					}
					return -1;
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD && Type == 1)
				{
					bytes.CopyTo(Data, 12);
				}
			}
		}

		public Patch(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public Patch(Patch source, ILump parent)
		{
			this = default(Patch);
			Parent = parent;
			if (parent != null && parent.Bsp != null)
			{
				if (source.Parent != null && source.Parent.Bsp != null && source.Parent.Bsp.MapType == parent.Bsp.MapType && source.LumpVersion == parent.LumpInfo.version)
				{
					Data = new byte[source.Data.Length];
					Array.Copy(source.Data, Data, source.Data.Length);
					return;
				}
				Data = new byte[GetStructLength(parent.Bsp.MapType, parent.LumpInfo.version)];
			}
			else if (source.Parent != null && source.Parent.Bsp != null)
			{
				Data = new byte[GetStructLength(source.Parent.Bsp.MapType, source.Parent.LumpInfo.version)];
			}
			else
			{
				Data = new byte[GetStructLength(MapType.Undefined)];
			}
			ShaderIndex = source.ShaderIndex;
			Type = source.Type;
			if (Type == 0)
			{
				Dimensions = source.Dimensions;
				Flags = source.Flags;
			}
			else if (Type == 1)
			{
				NumVertices = source.NumVertices;
				NumVertexIndices = source.NumVertexIndices;
				FirstVertexIndex = source.FirstVertexIndex;
			}
			FirstVertex = source.FirstVertex;
		}

		public static Lump<Patch> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<Patch>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			if (mapType == MapType.CoD)
			{
				return 16;
			}
			throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type == MapType.CoD)
			{
				return 24;
			}
			return -1;
		}
	}
}
