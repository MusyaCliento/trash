using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	public struct Face : ILumpObject
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

		public Plane Plane => Parent.Bsp.Planes[PlaneIndex];

		public int PlaneIndex
		{
			get
			{
				if (MapType == MapType.Nightfire || MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 0);
				}
				if (MapType == MapType.Source17)
				{
					return BitConverter.ToUInt16(Data, 32);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToUInt16(Data, 0);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Nightfire || MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 0);
				}
				else if (MapType == MapType.Source17)
				{
					Data[32] = bytes[0];
					Data[33] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[0] = bytes[0];
					Data[1] = bytes[1];
				}
			}
		}

		public bool PlaneSide
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2))
				{
					return BitConverter.ToUInt16(Data, 2) > 0;
				}
				if (MapType == MapType.Vindictus)
				{
					return Data[4] > 0;
				}
				if (MapType == MapType.Source17)
				{
					return Data[34] > 0;
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return Data[2] > 0;
				}
				return true;
			}
			set
			{
				if (MapType == MapType.Vindictus)
				{
					Data[4] = (byte)(value ? 1u : 0u);
				}
				else if (MapType == MapType.Source17)
				{
					Data[34] = (byte)(value ? 1u : 0u);
				}
				else if (MapType.IsSubtypeOf(MapType.Source) || MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2))
				{
					Data[2] = (byte)(value ? 1u : 0u);
				}
			}
		}

		public bool IsOnNode
		{
			get
			{
				if (MapType == MapType.Source17)
				{
					return Data[35] > 0;
				}
				if (MapType == MapType.Vindictus)
				{
					return Data[5] > 0;
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return Data[3] > 0;
				}
				return false;
			}
			set
			{
				if (MapType == MapType.Source17)
				{
					Data[35] = (byte)(value ? 1u : 0u);
				}
				else if (MapType == MapType.Vindictus)
				{
					Data[5] = (byte)(value ? 1u : 0u);
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					Data[3] = (byte)(value ? 1u : 0u);
				}
			}
		}

		public IEnumerable<int> EdgeIndices
		{
			get
			{
				int i = 0;
				while (i < NumEdgeIndices)
				{
					yield return (int)Parent.Bsp.FaceEdges[FirstEdgeIndexIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("Edges")]
		public int FirstEdgeIndexIndex
		{
			get
			{
				if (MapType == MapType.Source17)
				{
					return BitConverter.ToInt32(Data, 36);
				}
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 8);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 4);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Source17)
				{
					bytes.CopyTo(Data, 36);
				}
				else if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 8);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					bytes.CopyTo(Data, 4);
				}
			}
		}

		[Count("Edges")]
		public int NumEdgeIndices
		{
			get
			{
				if (MapType == MapType.Source17)
				{
					return BitConverter.ToUInt16(Data, 40);
				}
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 12);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToUInt16(Data, 8);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Source17)
				{
					Data[40] = bytes[0];
					Data[41] = bytes[1];
				}
				else if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 12);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[8] = bytes[0];
					Data[9] = bytes[1];
				}
			}
		}

		public Texture Texture => Parent.Bsp.Textures[TextureIndex];

		public int TextureIndex
		{
			get
			{
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 24);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2))
				{
					return BitConverter.ToUInt16(Data, 10);
				}
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					return BitConverter.ToInt16(Data, 0);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					return BitConverter.ToInt32(Data, 0);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 24);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2))
				{
					Data[10] = bytes[0];
					Data[11] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.CoD))
				{
					Data[0] = bytes[0];
					Data[1] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					bytes.CopyTo(Data, 0);
				}
			}
		}

		public IEnumerable<UIVertex> Vertices
		{
			get
			{
				int i = 0;
				while (i < NumVertices)
				{
					yield return Parent.Bsp.Vertices[FirstVertexIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("Vertices")]
		public int FirstVertexIndex
		{
			get
			{
				if (MapType == MapType.Nightfire || MapType == MapType.CoD || MapType == MapType.CoDDemo || MapType == MapType.CoD2)
				{
					return BitConverter.ToInt32(Data, 4);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					return BitConverter.ToInt32(Data, 12);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Nightfire || MapType == MapType.CoD || MapType == MapType.CoDDemo || MapType == MapType.CoD2)
				{
					bytes.CopyTo(Data, 4);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					bytes.CopyTo(Data, 12);
				}
			}
		}

		[Count("Vertices")]
		public int NumVertices
		{
			get
			{
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 8);
				}
				if (MapType == MapType.CoD4)
				{
					return BitConverter.ToInt16(Data, 16);
				}
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					return BitConverter.ToInt16(Data, 8);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					return BitConverter.ToInt32(Data, 16);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 8);
				}
				else if (MapType == MapType.CoD4)
				{
					Data[16] = bytes[0];
					Data[17] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.CoD))
				{
					Data[8] = bytes[0];
					Data[9] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					bytes.CopyTo(Data, 16);
				}
			}
		}

		public Texture Material => Parent.Bsp.Materials[TextureIndex];

		public int MaterialIndex
		{
			get
			{
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 28);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 28);
				}
			}
		}

		public TextureInfo TextureInfo => Parent.Bsp.TextureInfo[TextureInfoIndex];

		public int TextureInfoIndex
		{
			get
			{
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 32);
				}
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 16);
				}
				if (MapType == MapType.Source17)
				{
					return BitConverter.ToUInt16(Data, 42);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToUInt16(Data, 10);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 32);
				}
				else if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 16);
				}
				else if (MapType == MapType.Source17)
				{
					Data[42] = bytes[0];
					Data[43] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[10] = bytes[0];
					Data[11] = bytes[1];
				}
			}
		}

		public TextureInfo LightmapTextureInfo => Parent.Bsp.TextureInfo[LightmapTextureInfoIndex];

		public int LightmapTextureInfoIndex
		{
			get
			{
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 36);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 36);
				}
			}
		}

		public int DisplacementIndex
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 20);
				}
				if (MapType == MapType.Source17)
				{
					return BitConverter.ToInt16(Data, 44);
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt16(Data, 12);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 20);
				}
				else if (MapType == MapType.Source17)
				{
					Data[44] = bytes[0];
					Data[45] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					Data[12] = bytes[0];
					Data[13] = bytes[1];
				}
			}
		}

		public int SurfaceFogVolumeID
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 24);
				}
				if (MapType == MapType.Source17)
				{
					return BitConverter.ToInt16(Data, 46);
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt16(Data, 14);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 24);
				}
				else if (MapType == MapType.Source17)
				{
					Data[46] = bytes[0];
					Data[47] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					Data[14] = bytes[0];
					Data[15] = bytes[1];
				}
			}
		}

		public Face OriginalFace => Parent.Bsp.OriginalFaces[OriginalFaceIndex];

		public int OriginalFaceIndex
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						return BitConverter.ToInt32(Data, 60);
					}
					return BitConverter.ToInt32(Data, 56);
				}
				if (MapType == MapType.Source17)
				{
					return BitConverter.ToInt32(Data, 96);
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 44);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						bytes.CopyTo(Data, 60);
					}
					else
					{
						bytes.CopyTo(Data, 56);
					}
				}
				else if (MapType == MapType.Source17)
				{
					bytes.CopyTo(Data, 96);
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					bytes.CopyTo(Data, 44);
				}
			}
		}

		public int Type
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					return BitConverter.ToInt32(Data, 8);
				}
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 20);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					bytes.CopyTo(Data, 8);
				}
				else if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 20);
				}
			}
		}

		public int Effect
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					return BitConverter.ToInt32(Data, 4);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					bytes.CopyTo(Data, 4);
				}
			}
		}

		public IEnumerable<int> Indices
		{
			get
			{
				int i = 0;
				while (i < NumIndices)
				{
					yield return (int)Parent.Bsp.Indices[FirstIndexIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("Indices")]
		public int FirstIndexIndex
		{
			get
			{
				if (MapType == MapType.Nightfire || MapType == MapType.CoD || MapType == MapType.CoDDemo || MapType == MapType.CoD2)
				{
					return BitConverter.ToInt32(Data, 12);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					return BitConverter.ToInt32(Data, 20);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Nightfire || MapType == MapType.CoD || MapType == MapType.CoDDemo || MapType == MapType.CoD2)
				{
					bytes.CopyTo(Data, 12);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					bytes.CopyTo(Data, 20);
				}
			}
		}

		[Count("Indices")]
		public int NumIndices
		{
			get
			{
				if (MapType == MapType.CoD4)
				{
					return BitConverter.ToInt16(Data, 18);
				}
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					return BitConverter.ToInt16(Data, 10);
				}
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 16);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3))
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
					Data[18] = bytes[0];
					Data[19] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.CoD))
				{
					Data[10] = bytes[0];
					Data[11] = bytes[1];
				}
				else if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 16);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					bytes.CopyTo(Data, 24);
				}
			}
		}

		public Color32[] AverageLightColors
		{
			get
			{
				if (MapType == MapType.Source17)
				{
					Color32[] array = new Color32[8];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = ColorExtensions.FromArgb(Data[i * 4 + 3], Data[i * 4], Data[i * 4 + 1], Data[i * 4 + 2]);
					}
					return array;
				}
				return new Color32[0];
			}
			set
			{
				if (MapType == MapType.Source17)
				{
					for (int i = 0; i < value.Length; i++)
					{
						value[i].GetBytes().CopyTo(Data, i * 4);
					}
				}
			}
		}

		public byte[] LightmapStyles
		{
			get
			{
				if (MapType == MapType.SiN)
				{
					byte[] array = new byte[16];
					Array.Copy(Data, 12, array, 0, array.Length);
					return array;
				}
				if (MapType == MapType.SoF)
				{
					byte[] array2 = new byte[4];
					Array.Copy(Data, 22, array2, 0, array2.Length);
					return array2;
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2))
				{
					byte[] array3 = new byte[4];
					Array.Copy(Data, 12, array3, 0, array3.Length);
					return array3;
				}
				if (MapType == MapType.Vindictus)
				{
					byte[] array4 = new byte[8];
					if (LumpVersion == 2)
					{
						Array.Copy(Data, 28, array4, 0, array4.Length);
					}
					else
					{
						Array.Copy(Data, 24, array4, 0, array4.Length);
					}
					return array4;
				}
				if (MapType == MapType.Source17)
				{
					byte[] array5 = new byte[8];
					Array.Copy(Data, 48, array5, 0, array5.Length);
					return array5;
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					byte[] array6 = new byte[4];
					Array.Copy(Data, 16, array6, 0, array6.Length);
					return array6;
				}
				if (MapType == MapType.Nightfire)
				{
					byte[] array7 = new byte[4];
					Array.Copy(Data, 40, array7, 0, array7.Length);
					return array7;
				}
				return new byte[0];
			}
			set
			{
				if (MapType == MapType.SiN)
				{
					Array.Copy(value, 0, Data, 12, Math.Min(value.Length, 16));
				}
				else if (MapType == MapType.SoF)
				{
					Array.Copy(value, 0, Data, 22, Math.Min(value.Length, 4));
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2))
				{
					Array.Copy(value, 0, Data, 12, Math.Min(value.Length, 4));
				}
				else if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						Array.Copy(value, 0, Data, 28, Math.Min(value.Length, 8));
					}
					else
					{
						Array.Copy(value, 0, Data, 24, Math.Min(value.Length, 8));
					}
				}
				else if (MapType == MapType.Source17)
				{
					Array.Copy(value, 0, Data, 48, Math.Min(value.Length, 8));
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					Array.Copy(value, 0, Data, 16, Math.Min(value.Length, 4));
				}
				else if (MapType == MapType.Nightfire)
				{
					Array.Copy(value, 0, Data, 40, Math.Min(value.Length, 4));
				}
			}
		}

		public byte[] DayLightStyle
		{
			get
			{
				if (MapType == MapType.Source17)
				{
					byte[] array = new byte[8];
					Array.Copy(Data, 56, array, 0, array.Length);
					return array;
				}
				return new byte[0];
			}
			set
			{
				if (MapType == MapType.Source17)
				{
					Array.Copy(value, 0, Data, 56, Math.Min(value.Length, 8));
				}
			}
		}

		public byte[] NightLightStyle
		{
			get
			{
				if (MapType == MapType.Source17)
				{
					byte[] array = new byte[8];
					Array.Copy(Data, 64, array, 0, array.Length);
					return array;
				}
				return new byte[0];
			}
			set
			{
				if (MapType == MapType.Source17)
				{
					Array.Copy(value, 0, Data, 64, Math.Min(value.Length, 8));
				}
			}
		}

		public int Lightmap
		{
			get
			{
				if (MapType == MapType.Raven)
				{
					return BitConverter.ToInt32(Data, 36);
				}
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 44);
				}
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						return BitConverter.ToInt32(Data, 36);
					}
					return BitConverter.ToInt32(Data, 32);
				}
				if (MapType == MapType.Source17)
				{
					return BitConverter.ToInt32(Data, 72);
				}
				if (MapType.IsSubtypeOf(MapType.CoD) && MapType != MapType.CoD4)
				{
					return BitConverter.ToInt16(Data, 2);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.SiN || MapType == MapType.SoF)
				{
					return BitConverter.ToInt32(Data, 28);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2))
				{
					return BitConverter.ToInt32(Data, 16);
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 20);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Raven)
				{
					bytes.CopyTo(Data, 36);
				}
				else if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 44);
				}
				else if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						bytes.CopyTo(Data, 36);
					}
					else
					{
						bytes.CopyTo(Data, 32);
					}
				}
				else if (MapType == MapType.Source17)
				{
					bytes.CopyTo(Data, 72);
				}
				else if (MapType.IsSubtypeOf(MapType.CoD) && MapType != MapType.CoD4)
				{
					Data[2] = bytes[0];
					Data[3] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.SiN || MapType == MapType.SoF)
				{
					bytes.CopyTo(Data, 28);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2))
				{
					bytes.CopyTo(Data, 16);
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					bytes.CopyTo(Data, 20);
				}
			}
		}

		public int Lightmap2
		{
			get
			{
				if (MapType == MapType.Raven)
				{
					return BitConverter.ToInt32(Data, 40);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Raven)
				{
					bytes.CopyTo(Data, 40);
				}
			}
		}

		public int Lightmap3
		{
			get
			{
				if (MapType == MapType.Raven)
				{
					return BitConverter.ToInt32(Data, 44);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Raven)
				{
					bytes.CopyTo(Data, 44);
				}
			}
		}

		public int Lightmap4
		{
			get
			{
				if (MapType == MapType.Raven)
				{
					return BitConverter.ToInt32(Data, 48);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Raven)
				{
					bytes.CopyTo(Data, 48);
				}
			}
		}

		public float Area
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						return BitConverter.ToSingle(Data, 40);
					}
					return BitConverter.ToSingle(Data, 36);
				}
				if (MapType == MapType.Source17)
				{
					return BitConverter.ToSingle(Data, 76);
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToSingle(Data, 24);
				}
				return -1f;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						bytes.CopyTo(Data, 40);
					}
					else
					{
						bytes.CopyTo(Data, 36);
					}
				}
				else if (MapType == MapType.Source17)
				{
					bytes.CopyTo(Data, 76);
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					bytes.CopyTo(Data, 24);
				}
			}
		}

		public Vector2 LightmapStart
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						return new Vector2(BitConverter.ToInt32(Data, 44), BitConverter.ToInt32(Data, 48));
					}
					return new Vector2(BitConverter.ToInt32(Data, 40), BitConverter.ToInt32(Data, 44));
				}
				if (MapType == MapType.Raven)
				{
					return new Vector2(BitConverter.ToInt32(Data, 52), BitConverter.ToInt32(Data, 56));
				}
				if (MapType == MapType.Source17)
				{
					return new Vector2(BitConverter.ToInt32(Data, 80), BitConverter.ToInt32(Data, 84));
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					return new Vector2(BitConverter.ToInt32(Data, 32), BitConverter.ToInt32(Data, 36));
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return new Vector2(BitConverter.ToInt32(Data, 28), BitConverter.ToInt32(Data, 32));
				}
				return new Vector2(0f, 0f);
			}
			set
			{
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						value.GetBytes().CopyTo(Data, 44);
					}
					else
					{
						value.GetBytes().CopyTo(Data, 40);
					}
				}
				else if (MapType == MapType.Raven)
				{
					value.GetBytes().CopyTo(Data, 52);
				}
				else if (MapType == MapType.Source17)
				{
					value.GetBytes().CopyTo(Data, 80);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					value.GetBytes().CopyTo(Data, 32);
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					value.GetBytes().CopyTo(Data, 28);
				}
			}
		}

		public Vector2 Lightmap2Start
		{
			get
			{
				if (MapType == MapType.Raven)
				{
					return new Vector2(BitConverter.ToInt32(Data, 60), BitConverter.ToInt32(Data, 64));
				}
				return new Vector2(0f, 0f);
			}
			set
			{
				if (MapType == MapType.Raven)
				{
					value.GetBytes().CopyTo(Data, 60);
				}
			}
		}

		public Vector2 Lightmap3Start
		{
			get
			{
				if (MapType == MapType.Raven)
				{
					return new Vector2(BitConverter.ToInt32(Data, 68), BitConverter.ToInt32(Data, 72));
				}
				return new Vector2(0f, 0f);
			}
			set
			{
				if (MapType == MapType.Raven)
				{
					value.GetBytes().CopyTo(Data, 68);
				}
			}
		}

		public Vector2 Lightmap4Start
		{
			get
			{
				if (MapType == MapType.Raven)
				{
					return new Vector2(BitConverter.ToInt32(Data, 76), BitConverter.ToInt32(Data, 80));
				}
				return new Vector2(0f, 0f);
			}
			set
			{
				if (MapType == MapType.Raven)
				{
					value.GetBytes().CopyTo(Data, 76);
				}
			}
		}

		public Vector2 LightmapSize
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						return new Vector2(BitConverter.ToInt32(Data, 52), BitConverter.ToInt32(Data, 56));
					}
					return new Vector2(BitConverter.ToInt32(Data, 48), BitConverter.ToInt32(Data, 52));
				}
				if (MapType == MapType.Raven)
				{
					return new Vector2(BitConverter.ToInt32(Data, 84), BitConverter.ToInt32(Data, 88));
				}
				if (MapType == MapType.Source17)
				{
					return new Vector2(BitConverter.ToInt32(Data, 88), BitConverter.ToInt32(Data, 92));
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					return new Vector2(BitConverter.ToInt32(Data, 40), BitConverter.ToInt32(Data, 44));
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return new Vector2(BitConverter.ToInt32(Data, 36), BitConverter.ToInt32(Data, 40));
				}
				return new Vector2(0f, 0f);
			}
			set
			{
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						value.GetBytes().CopyTo(Data, 52);
					}
					else
					{
						value.GetBytes().CopyTo(Data, 48);
					}
				}
				else if (MapType == MapType.Raven)
				{
					value.GetBytes().CopyTo(Data, 84);
				}
				else if (MapType == MapType.Source17)
				{
					value.GetBytes().CopyTo(Data, 88);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					value.GetBytes().CopyTo(Data, 40);
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					value.GetBytes().CopyTo(Data, 36);
				}
			}
		}

		public Vector3 LightmapOrigin
		{
			get
			{
				if (MapType == MapType.Raven)
				{
					return Vector3Extensions.ToVector3(Data, 92);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					return Vector3Extensions.ToVector3(Data, 48);
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType == MapType.Raven)
				{
					value.GetBytes().CopyTo(Data, 92);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					value.GetBytes().CopyTo(Data, 48);
				}
			}
		}

		public Vector3 LightmapUAxis
		{
			get
			{
				if (MapType == MapType.Raven)
				{
					return Vector3Extensions.ToVector3(Data, 104);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					return Vector3Extensions.ToVector3(Data, 60);
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType == MapType.Raven)
				{
					value.GetBytes().CopyTo(Data, 104);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					value.GetBytes().CopyTo(Data, 60);
				}
			}
		}

		public Vector3 LightmapVAxis
		{
			get
			{
				if (MapType == MapType.Raven)
				{
					return Vector3Extensions.ToVector3(Data, 116);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					return Vector3Extensions.ToVector3(Data, 72);
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType == MapType.Raven)
				{
					value.GetBytes().CopyTo(Data, 116);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					value.GetBytes().CopyTo(Data, 72);
				}
			}
		}

		public Vector3 Normal
		{
			get
			{
				if (MapType == MapType.Raven)
				{
					return Vector3Extensions.ToVector3(Data, 128);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					return Vector3Extensions.ToVector3(Data, 84);
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType == MapType.Raven)
				{
					value.GetBytes().CopyTo(Data, 128);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					value.GetBytes().CopyTo(Data, 84);
				}
			}
		}

		public Vector2 PatchSize
		{
			get
			{
				if (MapType == MapType.Raven)
				{
					return new Vector2(BitConverter.ToInt32(Data, 140), BitConverter.ToInt32(Data, 144));
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					return new Vector2(BitConverter.ToInt32(Data, 96), BitConverter.ToInt32(Data, 100));
				}
				return new Vector2(0f, 0f);
			}
			set
			{
				if (MapType == MapType.Raven)
				{
					value.GetBytes().CopyTo(Data, 140);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					value.GetBytes().CopyTo(Data, 96);
				}
			}
		}

		public int NumPrimitives
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						return BitConverter.ToInt32(Data, 64);
					}
					return BitConverter.ToInt32(Data, 60);
				}
				if (MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Source17)
				{
					return BitConverter.ToInt16(Data, 48);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						bytes.CopyTo(Data, 64);
					}
					else
					{
						bytes.CopyTo(Data, 60);
					}
				}
				else if (MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Source17)
				{
					Data[48] = bytes[0];
					Data[49] = bytes[1];
				}
			}
		}

		public int FirstPrimitive
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						return BitConverter.ToInt32(Data, 68);
					}
					return BitConverter.ToInt32(Data, 64);
				}
				if (MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Source17)
				{
					return BitConverter.ToInt16(Data, 50);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						bytes.CopyTo(Data, 68);
					}
					else
					{
						bytes.CopyTo(Data, 64);
					}
				}
				else if (MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Source17)
				{
					Data[50] = bytes[0];
					Data[51] = bytes[1];
				}
			}
		}

		public int SmoothingGroups
		{
			get
			{
				if (MapType == MapType.Source17)
				{
					return BitConverter.ToInt32(Data, 100);
				}
				if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						return BitConverter.ToInt32(Data, 72);
					}
					return BitConverter.ToInt32(Data, 68);
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt16(Data, 52);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Source17)
				{
					bytes.CopyTo(Data, 100);
				}
				else if (MapType == MapType.Vindictus)
				{
					if (LumpVersion == 2)
					{
						bytes.CopyTo(Data, 72);
					}
					else
					{
						bytes.CopyTo(Data, 68);
					}
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					Data[52] = bytes[0];
					Data[53] = bytes[1];
				}
			}
		}

		public Face(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public Face(Face source, ILump parent)
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
			PlaneIndex = source.PlaneIndex;
			PlaneSide = source.PlaneSide;
			IsOnNode = source.IsOnNode;
			FirstEdgeIndexIndex = source.FirstEdgeIndexIndex;
			NumEdgeIndices = source.NumEdgeIndices;
			TextureIndex = source.TextureIndex;
			FirstVertexIndex = source.FirstVertexIndex;
			NumVertices = source.NumVertices;
			MaterialIndex = source.MaterialIndex;
			TextureInfoIndex = source.TextureInfoIndex;
			LightmapTextureInfoIndex = source.LightmapTextureInfoIndex;
			DisplacementIndex = source.DisplacementIndex;
			SurfaceFogVolumeID = source.SurfaceFogVolumeID;
			OriginalFaceIndex = source.OriginalFaceIndex;
			Type = source.Type;
			Effect = source.Effect;
			FirstIndexIndex = source.FirstIndexIndex;
			NumIndices = source.NumIndices;
			AverageLightColors = source.AverageLightColors;
			LightmapStyles = source.LightmapStyles;
			DayLightStyle = source.DayLightStyle;
			NightLightStyle = source.NightLightStyle;
			Lightmap = source.Lightmap;
			Lightmap2 = source.Lightmap2;
			Lightmap3 = source.Lightmap3;
			Lightmap4 = source.Lightmap4;
			Area = source.Area;
			LightmapStart = source.LightmapStart;
			Lightmap2Start = source.Lightmap2Start;
			Lightmap3Start = source.Lightmap3Start;
			Lightmap4Start = source.Lightmap4Start;
			LightmapSize = source.LightmapSize;
			LightmapOrigin = source.LightmapOrigin;
			LightmapUAxis = source.LightmapUAxis;
			LightmapVAxis = source.LightmapVAxis;
			Normal = source.Normal;
			PatchSize = source.PatchSize;
			NumPrimitives = source.NumPrimitives;
			FirstPrimitive = source.FirstPrimitive;
			SmoothingGroups = source.SmoothingGroups;
		}

		public static Lump<Face> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<Face>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			switch (mapType)
			{
			case MapType.CoD4:
				return 24;
			case MapType.SiN:
				return 36;
			case MapType.SoF:
				return 40;
			case MapType.Nightfire:
				return 48;
			case MapType.Source17:
				return 104;
			case MapType.Vindictus:
				if (lumpVersion == 2)
				{
					return 76;
				}
				return 72;
			case MapType.Raven:
				return 148;
			default:
				if (mapType.IsSubtypeOf(MapType.FAKK2) || mapType.IsSubtypeOf(MapType.MOHAA))
				{
					return 108;
				}
				if (mapType.IsSubtypeOf(MapType.STEF2))
				{
					return 132;
				}
				if (mapType.IsSubtypeOf(MapType.CoD))
				{
					return 16;
				}
				if (mapType.IsSubtypeOf(MapType.Quake) || mapType.IsSubtypeOf(MapType.Quake2))
				{
					return 20;
				}
				if (mapType.IsSubtypeOf(MapType.Quake3))
				{
					return 104;
				}
				if (mapType.IsSubtypeOf(MapType.Source))
				{
					return 56;
				}
				throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
			}
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.FAKK2) || type.IsSubtypeOf(MapType.MOHAA))
			{
				return 3;
			}
			if (type.IsSubtypeOf(MapType.STEF2))
			{
				return 5;
			}
			if (!type.IsSubtypeOf(MapType.Quake2))
			{
				switch (type)
				{
				case MapType.CoD:
				case MapType.CoDDemo:
					break;
				case MapType.CoD4:
				case MapType.Nightfire:
					return 9;
				case MapType.Quake3:
				case MapType.ET:
				case MapType.Raven:
					return 13;
				default:
					if (type.IsSubtypeOf(MapType.Source) || type.IsSubtypeOf(MapType.Quake) || type == MapType.CoD2)
					{
						return 7;
					}
					return -1;
				}
			}
			return 6;
		}

		public static int GetIndexForOriginalFacesLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Source))
			{
				return 27;
			}
			if (type == MapType.CoD4)
			{
				return 47;
			}
			return -1;
		}
	}
}
