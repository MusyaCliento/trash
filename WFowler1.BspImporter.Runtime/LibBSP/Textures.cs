using System;
using System.Collections.Generic;
using System.Text;

namespace LibBSP
{
	public class Textures : Lump<Texture>
	{
		public override int Length
		{
			get
			{
				if (base.Bsp.MapType.IsSubtypeOf(MapType.Quake2) || base.Bsp.MapType.IsSubtypeOf(MapType.Quake3) || base.Bsp.MapType == MapType.Nightfire)
				{
					return base.Length;
				}
				if (base.Bsp.MapType.IsSubtypeOf(MapType.Source))
				{
					int num = 0;
					for (int i = 0; i < base.Count; i++)
					{
						num += base[i].Name.Length + 1;
					}
					return num;
				}
				if (base.Bsp.MapType.IsSubtypeOf(MapType.Quake))
				{
					int num2 = 4 + base.Count * 40;
					for (int j = 0; j < base.Count; j++)
					{
						Texture texture = base[j];
						if (texture.MipmapFullOffset <= 0)
						{
							continue;
						}
						int num3 = 0;
						num3 += (int)(texture.Dimensions.X() * texture.Dimensions.Y());
						num3 += (int)(texture.Dimensions.X() * texture.Dimensions.Y() / 4f);
						num3 += (int)(texture.Dimensions.X() * texture.Dimensions.Y() / 16f);
						num3 += (int)(texture.Dimensions.X() * texture.Dimensions.Y() / 64f);
						if (base.Bsp.MapType.IsSubtypeOf(MapType.GoldSrc))
						{
							int k;
							for (k = texture.Palette.Length + 2; k % 4 != 0; k++)
							{
							}
							num3 += k;
						}
						num2 += num3;
					}
					return num2;
				}
				return 0;
			}
		}

		public Textures(BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(bsp, lumpInfo)
		{
		}

		public Textures(IEnumerable<Texture> items, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(items, bsp, lumpInfo)
		{
		}

		public Textures(int capacity, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(capacity, bsp, lumpInfo)
		{
		}

		public Textures(byte[] data, int structLength, BSP bsp, LumpInfo lumpInfo = default(LumpInfo))
			: base(bsp, lumpInfo)
		{
			if (data == null || bsp == null)
			{
				throw new ArgumentNullException();
			}
			if (bsp.MapType.IsSubtypeOf(MapType.Quake))
			{
				int num = BitConverter.ToInt32(data, 0);
				structLength = 40;
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					byte[] array = new byte[structLength];
					byte[][] array2 = new byte[4][];
					byte[] array3 = new byte[0];
					int num3 = BitConverter.ToInt32(data, (i + 1) * 4);
					if (num3 >= 0)
					{
						Array.Copy(data, num3, array, 0, structLength);
						int num4 = BitConverter.ToInt32(array, 16);
						int num5 = BitConverter.ToInt32(array, 20);
						int num6 = 1;
						for (int j = 0; j < array2.Length; j++)
						{
							num2 = BitConverter.ToInt32(array, 24 + 4 * j);
							if (num2 > 0)
							{
								array2[j] = new byte[num4 / num6 * (num5 / num6)];
								Array.Copy(data, num3 + num2, array2[j], 0, array2[j].Length);
							}
							num6 *= 2;
						}
						if (bsp.MapType.IsSubtypeOf(MapType.GoldSrc) && num2 > 0)
						{
							int num7 = num2 + num4 * num5 / 64;
							array3 = new byte[BitConverter.ToInt16(data, num3 + num7) * 3];
							Array.Copy(data, num3 + num7, array3, 0, array3.Length);
						}
					}
					Add(new Texture(array, this, array2, array3));
				}
			}
			else if (bsp.MapType.IsSubtypeOf(MapType.Source))
			{
				int num8 = 0;
				for (int k = 0; k < data.Length; k++)
				{
					if (data[k] == 0)
					{
						byte[] array4 = new byte[k - num8];
						Array.Copy(data, num8, array4, 0, k - num8);
						Add(new Texture(array4, this));
						num8 = k + 1;
					}
				}
			}
			else
			{
				if (bsp.MapType == MapType.Nightfire)
				{
					structLength = 64;
				}
				else if (bsp.MapType == MapType.SiN)
				{
					structLength = 180;
				}
				else if (bsp.MapType.IsSubtypeOf(MapType.Quake2) || bsp.MapType.IsSubtypeOf(MapType.STEF2) || bsp.MapType.IsSubtypeOf(MapType.FAKK2))
				{
					structLength = 76;
				}
				else if (bsp.MapType.IsSubtypeOf(MapType.MOHAA))
				{
					structLength = 140;
				}
				else if (bsp.MapType.IsSubtypeOf(MapType.Quake3))
				{
					structLength = 72;
				}
				int num9 = data.Length / structLength;
				for (int l = 0; l < num9; l++)
				{
					byte[] array5 = new byte[structLength];
					Array.Copy(data, l * structLength, array5, 0, structLength);
					Add(new Texture(array5, this));
				}
			}
		}

		public string GetTextureAtOffset(uint offset)
		{
			int num = 0;
			for (int i = 0; i < base.Count; i++)
			{
				if (num < offset)
				{
					num += base[i].Name.Length + 1;
					continue;
				}
				return base[i].Name;
			}
			return null;
		}

		public int GetOffsetOf(string name)
		{
			int num = 0;
			for (int i = 0; i < base.Count; i++)
			{
				if (base[i].Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
				{
					return num;
				}
				num += base[i].Name.Length + 1;
			}
			return -1;
		}

		public override byte[] GetBytes()
		{
			if (base.Bsp.MapType.IsSubtypeOf(MapType.Quake2) || base.Bsp.MapType.IsSubtypeOf(MapType.Quake3) || base.Bsp.MapType == MapType.Nightfire)
			{
				return base.GetBytes();
			}
			if (base.Bsp.MapType.IsSubtypeOf(MapType.Source))
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (base.Count == 0)
				{
					return new byte[1];
				}
				for (int i = 0; i < base.Count; i++)
				{
					stringBuilder.Append(base[i].Name).Append('\0');
				}
				return Encoding.ASCII.GetBytes(stringBuilder.ToString());
			}
			if (base.Bsp.MapType.IsSubtypeOf(MapType.Quake))
			{
				byte[][] array = new byte[base.Count][];
				int num = 0;
				for (int j = 0; j < base.Count; j++)
				{
					Texture texture = base[j];
					if (texture.MipmapFullOffset > 0)
					{
						num = (texture.MipmapFullOffset = 40);
						num += (int)(texture.Dimensions.X() * texture.Dimensions.Y());
					}
					if (texture.MipmapHalfOffset > 0)
					{
						texture.MipmapHalfOffset = num;
						num += (int)(texture.Dimensions.X() * texture.Dimensions.Y() / 4f);
					}
					if (texture.MipmapQuarterOffset > 0)
					{
						texture.MipmapQuarterOffset = num;
						num += (int)(texture.Dimensions.X() * texture.Dimensions.Y() / 16f);
					}
					if (texture.MipmapEighthOffset > 0)
					{
						texture.MipmapEighthOffset = num;
						num += (int)(texture.Dimensions.X() * texture.Dimensions.Y() / 64f);
					}
					if (texture.MipmapFullOffset > 0 || texture.MipmapHalfOffset > 0 || texture.MipmapQuarterOffset > 0 || texture.MipmapEighthOffset > 0)
					{
						if (base.Bsp.MapType.IsSubtypeOf(MapType.GoldSrc))
						{
							int k;
							for (k = texture.Palette.Length + 2; k % 4 != 0; k++)
							{
							}
							num += k;
						}
						byte[] array2 = new byte[num];
						num = 0;
						texture.Data.CopyTo(array2, 0);
						num += 40;
						texture.Mipmaps[0].CopyTo(array2, num);
						num += (int)(texture.Dimensions.X() * texture.Dimensions.Y());
						texture.Mipmaps[1].CopyTo(array2, num);
						num += (int)(texture.Dimensions.X() * texture.Dimensions.Y() / 4f);
						texture.Mipmaps[2].CopyTo(array2, num);
						num += (int)(texture.Dimensions.X() * texture.Dimensions.Y() / 16f);
						texture.Mipmaps[3].CopyTo(array2, num);
						if (base.Bsp.MapType.IsSubtypeOf(MapType.GoldSrc))
						{
							num += (int)(texture.Dimensions.X() * texture.Dimensions.Y() / 64f);
							BitConverter.GetBytes((short)texture.Palette.Length).CopyTo(array2, num);
							num += 2;
							texture.Palette.CopyTo(array2, num);
						}
						array[j] = array2;
					}
					else
					{
						array[j] = texture.Data;
					}
				}
				byte[] array3 = new byte[(base.Count + 1) * 4];
				BitConverter.GetBytes(base.Count).CopyTo(array3, 0);
				num = array3.Length;
				for (int l = 0; l < base.Count; l++)
				{
					if (base[l].Name.Length == 0 && base[l].MipmapFullOffset == 0)
					{
						BitConverter.GetBytes(-1).CopyTo(array3, (l + 1) * 4);
						continue;
					}
					BitConverter.GetBytes(num).CopyTo(array3, (l + 1) * 4);
					byte[] array4 = new byte[num + array[l].Length];
					array3.CopyTo(array4, 0);
					array[l].CopyTo(array4, num);
					num = array4.Length;
					array3 = array4;
				}
				return array3;
			}
			return new byte[0];
		}
	}
}
