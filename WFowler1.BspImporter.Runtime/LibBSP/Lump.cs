using System;
using System.Collections.Generic;
using UnityEngine;

namespace LibBSP
{
	public class Lump<T> : List<T>, ILump
	{
		public BSP Bsp { get; protected set; }

		public LumpInfo LumpInfo { get; protected set; }

		public virtual int Length
		{
			get
			{
				if (base.Count > 0)
				{
					if (typeof(ILumpObject).IsAssignableFrom(typeof(T)))
					{
						return ((ILumpObject)(object)base[0]).Data.Length * base.Count;
					}
					if (typeof(T) == typeof(UIVertex))
					{
						return VertexExtensions.GetStructLength(Bsp.MapType, LumpInfo.version) * base.Count;
					}
					if (typeof(T) == typeof(Plane))
					{
						return PlaneExtensions.GetStructLength(Bsp.MapType, LumpInfo.version) * base.Count;
					}
					if (typeof(T) == typeof(Vector2))
					{
						return 8 * base.Count;
					}
					if (typeof(T) == typeof(Vector3))
					{
						return 12 * base.Count;
					}
					if (typeof(T) == typeof(Vector4))
					{
						return 16 * base.Count;
					}
				}
				return 0;
			}
		}

		public Lump(BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
		{
			Bsp = bsp;
			LumpInfo = lumpInfo;
		}

		public Lump(IEnumerable<T> items, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(items)
		{
			Bsp = bsp;
			LumpInfo = lumpInfo;
		}

		public Lump(int capacity, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(capacity)
		{
			Bsp = bsp;
			LumpInfo = lumpInfo;
		}

		public Lump(byte[] data, int structLength, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(data.Length / structLength)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			if (structLength <= 0)
			{
				throw new NotSupportedException("Cannot use the base Lump constructor for variable length lumps (structLength was negative). Create a derived class with a new constructor instead.");
			}
			Bsp = bsp;
			LumpInfo = lumpInfo;
			for (int i = 0; i < data.Length / structLength; i++)
			{
				byte[] array = new byte[structLength];
				Array.Copy(data, i * structLength, array, 0, structLength);
				Add((T)Activator.CreateInstance(typeof(T), array, this));
			}
		}

		public virtual byte[] GetBytes()
		{
			byte[] array;
			if (base.Count > 0)
			{
				if (typeof(ILumpObject).IsAssignableFrom(typeof(T)))
				{
					int num = ((ILumpObject)(object)base[0]).Data.Length;
					array = new byte[num * base.Count];
					for (int i = 0; i < base.Count; i++)
					{
						((ILumpObject)(object)base[i]).Data.CopyTo(array, num * i);
					}
				}
				else if (typeof(T) == typeof(UIVertex))
				{
					int structLength = VertexExtensions.GetStructLength(Bsp.MapType, LumpInfo.version);
					array = new byte[structLength * base.Count];
					for (int j = 0; j < base.Count; j++)
					{
						((UIVertex)(object)base[j]).GetBytes(Bsp.MapType, LumpInfo.version).CopyTo(array, structLength * j);
					}
				}
				else if (typeof(T) == typeof(Plane))
				{
					int structLength2 = PlaneExtensions.GetStructLength(Bsp.MapType, LumpInfo.version);
					array = new byte[structLength2 * base.Count];
					for (int k = 0; k < base.Count; k++)
					{
						((Plane)(object)base[k]).GetBytes(Bsp.MapType, LumpInfo.version).CopyTo(array, structLength2 * k);
					}
				}
				else if (typeof(T) == typeof(Vector2))
				{
					array = new byte[8 * base.Count];
					for (int l = 0; l < base.Count; l++)
					{
						((Vector2)(object)base[l]).GetBytes().CopyTo(array, 8 * l);
					}
				}
				else if (typeof(T) == typeof(Vector3))
				{
					array = new byte[12 * base.Count];
					for (int m = 0; m < base.Count; m++)
					{
						((Vector3)(object)base[m]).GetBytes().CopyTo(array, 12 * m);
					}
				}
				else if (typeof(T) == typeof(Vector4))
				{
					array = new byte[16 * base.Count];
					for (int n = 0; n < base.Count; n++)
					{
						((Vector4)(object)base[n]).GetBytes().CopyTo(array, 16 * n);
					}
				}
				else
				{
					array = new byte[0];
				}
			}
			else
			{
				array = new byte[0];
			}
			return array;
		}
	}
}
