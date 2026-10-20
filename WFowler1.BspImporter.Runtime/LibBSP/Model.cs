using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	public struct Model : ILumpObject
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

		public Node HeadNode => Parent.Bsp.Nodes[HeadNodeIndex];

		[Index("Nodes")]
		public int HeadNodeIndex
		{
			get
			{
				if (MapType == MapType.DMoMaM)
				{
					return BitConverter.ToInt32(Data, 40);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 36);
				}
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 24);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.DMoMaM)
				{
					bytes.CopyTo(Data, 40);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					bytes.CopyTo(Data, 36);
				}
				else if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 24);
				}
			}
		}

		public int HeadClipNode1Index
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToInt32(Data, 40);
				}
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 28);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					bytes.CopyTo(Data, 40);
				}
				else if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 28);
				}
			}
		}

		public int HeadClipNode2Index
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToInt32(Data, 44);
				}
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 32);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					bytes.CopyTo(Data, 44);
				}
				else if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 32);
				}
			}
		}

		public int HeadClipNode3Index
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToInt32(Data, 48);
				}
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 36);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					bytes.CopyTo(Data, 48);
				}
				else if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 36);
				}
			}
		}

		public IEnumerable<Leaf> Leaves
		{
			get
			{
				int i = 0;
				while (i < NumLeaves)
				{
					yield return Parent.Bsp.Leaves[FirstLeafIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("Leaves")]
		public int FirstLeafIndex
		{
			get
			{
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 40);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 40);
				}
			}
		}

		[Count("Leaves")]
		public int NumLeaves
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToInt32(Data, 52);
				}
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 44);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					bytes.CopyTo(Data, 52);
				}
				else if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 44);
				}
			}
		}

		public IEnumerable<Brush> Brushes
		{
			get
			{
				int i = 0;
				while (i < NumBrushes)
				{
					yield return Parent.Bsp.Brushes[FirstBrushIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("Brushes")]
		public int FirstBrushIndex
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					return BitConverter.ToInt32(Data, 40);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					return BitConverter.ToInt32(Data, 32);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					bytes.CopyTo(Data, 40);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					bytes.CopyTo(Data, 32);
				}
			}
		}

		[Count("Brushes")]
		public int NumBrushes
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					return BitConverter.ToInt32(Data, 44);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					return BitConverter.ToInt32(Data, 36);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					bytes.CopyTo(Data, 44);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					bytes.CopyTo(Data, 36);
				}
			}
		}

		public IEnumerable<Face> Faces
		{
			get
			{
				int i = 0;
				while (i < NumFaces)
				{
					yield return Parent.Bsp.Faces[FirstFaceIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("Faces")]
		public int FirstFaceIndex
		{
			get
			{
				if (MapType == MapType.CoD4)
				{
					return BitConverter.ToInt16(Data, 24);
				}
				if (MapType == MapType.DMoMaM)
				{
					return BitConverter.ToInt32(Data, 44);
				}
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 48);
				}
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToInt32(Data, 56);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 40);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Titanfall)
				{
					return BitConverter.ToInt32(Data, 24);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD4)
				{
					Data[24] = bytes[0];
					Data[25] = bytes[1];
				}
				else if (MapType == MapType.DMoMaM)
				{
					bytes.CopyTo(Data, 44);
				}
				else if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 48);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake))
				{
					bytes.CopyTo(Data, 56);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					bytes.CopyTo(Data, 40);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Titanfall)
				{
					bytes.CopyTo(Data, 24);
				}
			}
		}

		[Count("Faces")]
		public int NumFaces
		{
			get
			{
				if (MapType == MapType.CoD4)
				{
					return BitConverter.ToInt16(Data, 28);
				}
				if (MapType == MapType.DMoMaM)
				{
					return BitConverter.ToInt32(Data, 48);
				}
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 52);
				}
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToInt32(Data, 60);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 44);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Titanfall)
				{
					return BitConverter.ToInt32(Data, 28);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD4)
				{
					Data[28] = bytes[0];
					Data[29] = bytes[1];
				}
				else if (MapType == MapType.DMoMaM)
				{
					bytes.CopyTo(Data, 48);
				}
				else if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 52);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake))
				{
					bytes.CopyTo(Data, 60);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					bytes.CopyTo(Data, 44);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Titanfall)
				{
					bytes.CopyTo(Data, 28);
				}
			}
		}

		public IEnumerable<int> PatchIndices
		{
			get
			{
				int i = 0;
				while (i < NumPatchIndices)
				{
					yield return (int)Parent.Bsp.PatchIndices[FirstPatchIndicesIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("PatchIndices")]
		public int FirstPatchIndicesIndex
		{
			get
			{
				if (MapType == MapType.CoD || MapType == MapType.CoDDemo)
				{
					return BitConverter.ToInt32(Data, 32);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD || MapType == MapType.CoDDemo)
				{
					bytes.CopyTo(Data, 32);
				}
			}
		}

		[Count("PatchIndices")]
		public int NumPatchIndices
		{
			get
			{
				if (MapType == MapType.CoD || MapType == MapType.CoDDemo)
				{
					return BitConverter.ToInt32(Data, 36);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD || MapType == MapType.CoDDemo)
				{
					bytes.CopyTo(Data, 36);
				}
			}
		}

		public Vector3 Minimums
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Nightfire || MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					return Vector3Extensions.ToVector3(Data);
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Nightfire || MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					value.GetBytes().CopyTo(Data, 0);
				}
			}
		}

		public Vector3 Maximums
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Nightfire || MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					return Vector3Extensions.ToVector3(Data, 12);
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Nightfire || MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					value.GetBytes().CopyTo(Data, 12);
				}
			}
		}

		public Vector3 Origin
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return Vector3Extensions.ToVector3(Data, 24);
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					value.GetBytes().CopyTo(Data, 24);
				}
			}
		}

		public Model(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public Model(Model source, ILump parent = null)
		{
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
			HeadNodeIndex = source.HeadNodeIndex;
			HeadClipNode1Index = source.HeadClipNode1Index;
			HeadClipNode2Index = source.HeadClipNode2Index;
			HeadClipNode3Index = source.HeadClipNode3Index;
			FirstLeafIndex = source.FirstLeafIndex;
			NumLeaves = source.NumLeaves;
			FirstBrushIndex = source.FirstBrushIndex;
			NumBrushes = source.NumBrushes;
			FirstFaceIndex = source.FirstFaceIndex;
			NumFaces = source.NumFaces;
			FirstPatchIndicesIndex = source.FirstPatchIndicesIndex;
			NumPatchIndices = source.NumPatchIndices;
			Minimums = source.Minimums;
			Maximums = source.Maximums;
			Origin = source.Origin;
		}

		public static Lump<Model> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<Model>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			switch (mapType)
			{
			case MapType.DMoMaM:
				return 52;
			case MapType.Titanfall:
				return 32;
			default:
				if (mapType.IsSubtypeOf(MapType.Quake2) || mapType.IsSubtypeOf(MapType.CoD) || mapType.IsSubtypeOf(MapType.Source))
				{
					return 48;
				}
				if (mapType.IsSubtypeOf(MapType.Quake))
				{
					return 64;
				}
				if (mapType.IsSubtypeOf(MapType.Quake3))
				{
					return 40;
				}
				if (mapType == MapType.Nightfire)
				{
					return 56;
				}
				throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
			}
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Quake) || type.IsSubtypeOf(MapType.Source) || type == MapType.Nightfire || type == MapType.Titanfall || type == MapType.MOHAADemo)
			{
				return 14;
			}
			if (type.IsSubtypeOf(MapType.MOHAA) || type.IsSubtypeOf(MapType.FAKK2) || type.IsSubtypeOf(MapType.Quake2))
			{
				return 13;
			}
			if (type.IsSubtypeOf(MapType.STEF2))
			{
				return 15;
			}
			switch (type)
			{
			case MapType.CoD:
			case MapType.CoDDemo:
				return 27;
			case MapType.CoD2:
				return 35;
			case MapType.CoD4:
				return 37;
			default:
				if (type.IsSubtypeOf(MapType.Quake3))
				{
					return 7;
				}
				return -1;
			}
		}
	}
}
