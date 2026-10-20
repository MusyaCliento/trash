using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibBSP
{
	[Serializable]
	public class Entities : Lump<Entity>
	{
		public override int Length
		{
			get
			{
				int num = 1;
				using Enumerator enumerator = GetEnumerator();
				while (enumerator.MoveNext())
				{
					Entity current = enumerator.Current;
					num += current.ToString().Length;
				}
				return num;
			}
		}

		public Entities()
			: base((BSP)null, default(LumpInfo))
		{
		}

		public Entities(IEnumerable<Entity> entities, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(entities, bsp, lumpInfo)
		{
		}

		public Entities(int initialCapacity, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(initialCapacity, bsp, lumpInfo)
		{
		}

		public Entities(BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(bsp, lumpInfo)
		{
		}

		public Entities(FileInfo file)
			: this(File.ReadAllBytes(file.FullName))
		{
		}

		public Entities(byte[] data, BSP bsp = null, LumpInfo lumpInfo = default(LumpInfo))
			: base(bsp, lumpInfo)
		{
			bool flag = false;
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < data.Length; i++)
			{
				char c = (char)data[i];
				if (c == '"')
				{
					if (i == 0)
					{
						flag = !flag;
					}
					else if (data[i - 1] != 92)
					{
						if (flag && (i + 1 >= data.Length || data[i + 1] == 10 || data[i + 1] == 13))
						{
							flag = false;
						}
					}
					else
					{
						flag = !flag;
					}
				}
				if (!flag && c == '{' && (i == 0 || data[i - 1] == 10 || data[i - 1] == 9 || data[i - 1] == 32 || data[i - 1] == 13))
				{
					num++;
				}
				if (num > 0)
				{
					stringBuilder.Append(c);
				}
				if (!flag && c == '}' && (i == 0 || data[i - 1] == 10 || data[i - 1] == 9 || data[i - 1] == 32 || data[i - 1] == 13))
				{
					num--;
					if (num == 0)
					{
						Entity entity = new Entity(this);
						entity.ParseString(stringBuilder.ToString());
						Add(entity);
						stringBuilder.Length = 0;
					}
				}
			}
			if (num != 0)
			{
				throw new ArgumentException($"Brace mismatch when parsing entities! Entity: {base.Count} Brace level: {num}");
			}
		}

		public void RemoveAllWithAttribute(string key, string value)
		{
			RemoveAll((Entity entity) => entity[key].Equals(value, StringComparison.InvariantCultureIgnoreCase));
		}

		public List<Entity> GetAllWithAttribute(string key, string value)
		{
			return FindAll((Entity entity) => entity[key].Equals(value, StringComparison.InvariantCultureIgnoreCase));
		}

		public List<Entity> GetAllWithName(string targetname)
		{
			return FindAll((Entity entity) => entity.Name.Equals(targetname, StringComparison.InvariantCultureIgnoreCase));
		}

		public Entity GetWithAttribute(string key, string value)
		{
			return Find((Entity entity) => entity[key].Equals(value, StringComparison.InvariantCultureIgnoreCase));
		}

		public Entity GetWithName(string targetname)
		{
			return Find((Entity entity) => entity.Name.Equals(targetname, StringComparison.InvariantCultureIgnoreCase));
		}

		public override byte[] GetBytes()
		{
			if (base.Count == 0)
			{
				return new byte[1];
			}
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Entity current = enumerator.Current;
					stringBuilder.Append(current.ToString());
				}
			}
			stringBuilder.Append('\0');
			return Encoding.ASCII.GetBytes(stringBuilder.ToString());
		}
	}
}
