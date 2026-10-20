using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibBSP
{
	public class StaticProps : Lump<StaticProp>
	{
		public const int ModelNameLength = 128;

		public string[] ModelDictionary { get; set; }

		public short[] LeafIndices { get; set; }

		public override int Length => 12 + ModelDictionary.Length * 128 + LeafIndices.Length * 2 + base.Count * base[0].Data.Length;

		public StaticProps(BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(bsp, lumpInfo)
		{
			ModelDictionary = new string[0];
		}

		public StaticProps(IEnumerable<StaticProp> items, IList<string> dictionary, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(items, bsp, lumpInfo)
		{
			ModelDictionary = dictionary.ToArray();
		}

		public StaticProps(int capacity, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(capacity, bsp, lumpInfo)
		{
			ModelDictionary = new string[0];
		}

		public StaticProps(byte[] data, int structLength, BSP bsp, LumpInfo lumpInfo = default(LumpInfo))
			: base(bsp, lumpInfo)
		{
			if (data == null || bsp == null)
			{
				throw new ArgumentNullException();
			}
			if (data.Length != 0)
			{
				int num = 0;
				ModelDictionary = new string[BitConverter.ToInt32(data, 0)];
				num += 4;
				for (int i = 0; i < ModelDictionary.Length; i++)
				{
					ModelDictionary[i] = data.ToNullTerminatedString(num, 128);
					num += 128;
				}
				LeafIndices = new short[BitConverter.ToInt32(data, num)];
				num += 4;
				for (int j = 0; j < LeafIndices.Length; j++)
				{
					LeafIndices[j] = BitConverter.ToInt16(data, num);
					num += 2;
				}
				if (base.Bsp.MapType == MapType.Vindictus && lumpInfo.version == 6)
				{
					int num2 = BitConverter.ToInt32(data, num);
					num += 4 + num2 * 16;
				}
				int num3 = BitConverter.ToInt32(data, num);
				num = ((lumpInfo.version != 12) ? (num + 4) : (num + 12));
				if (num3 > 0)
				{
					structLength = (data.Length - num) / num3;
					for (int k = 0; k < num3; k++)
					{
						byte[] array = new byte[structLength];
						Array.Copy(data, num, array, 0, structLength);
						Add(new StaticProp(array, this));
						num += structLength;
					}
				}
			}
			else
			{
				ModelDictionary = new string[0];
			}
		}

		public override byte[] GetBytes()
		{
			if (base.Count == 0)
			{
				return new byte[12];
			}
			byte[] array = new byte[Length];
			int num = 0;
			BitConverter.GetBytes(ModelDictionary.Length).CopyTo(array, num);
			num += 4;
			for (int i = 0; i < ModelDictionary.Length; i++)
			{
				string text = ModelDictionary[i];
				if (text.Length > 128)
				{
					text = text.Substring(0, 128);
				}
				Encoding.ASCII.GetBytes(text).CopyTo(array, num);
				num += 128;
			}
			BitConverter.GetBytes(LeafIndices.Length).CopyTo(array, num);
			num += 4;
			for (int j = 0; j < LeafIndices.Length; j++)
			{
				BitConverter.GetBytes(LeafIndices[j]).CopyTo(array, num);
				num += 2;
			}
			BitConverter.GetBytes(base.Count).CopyTo(array, num);
			num += 4;
			base.GetBytes().CopyTo(array, num);
			return array;
		}
	}
}
