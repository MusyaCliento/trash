using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using UnityEngine;

namespace LibBSP
{
	[Serializable]
	public class Entity : Dictionary<string, string>, IComparable, IComparable<Entity>, ISerializable, ILumpObject
	{
		[Serializable]
		public struct EntityConnection
		{
			public string name;

			public string target;

			public string action;

			public string param;

			public float delay;

			public int fireOnce;

			public string unknown0;

			public string unknown1;

			public override string ToString()
			{
				return ToString(MapType.Undefined);
			}

			public string ToString(MapType mapType)
			{
				if (mapType == MapType.DMoMaM)
				{
					return $"\"{name}\" \"{target},{action},{param},{delay.ToString(_format)},{fireOnce},{unknown0},{unknown1}\"";
				}
				return $"\"{name}\" \"{target},{action},{param},{delay.ToString(_format)},{fireOnce}\"";
			}
		}

		private static IFormatProvider _format = CultureInfo.CreateSpecificCulture("en-US");

		public const char ConnectionMemberSeparater = '\u001b';

		public List<EntityConnection> connections = new List<EntityConnection>();

		public List<MAPBrush> brushes = new List<MAPBrush>();

		public ILump Parent { get; private set; }

		public byte[] Data
		{
			get
			{
				return Encoding.ASCII.GetBytes(ToString());
			}
			set
			{
				ParseString(Encoding.ASCII.GetString(value));
			}
		}

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

		public bool IsBrushBased
		{
			get
			{
				if (brushes.Count <= 0)
				{
					return ModelNumber >= 0;
				}
				return true;
			}
		}

		public uint Spawnflags
		{
			get
			{
				try
				{
					if (ContainsKey("spawnflags"))
					{
						return uint.Parse(this["spawnflags"]);
					}
					return 0u;
				}
				catch
				{
					return 0u;
				}
			}
			set
			{
				this["spawnflags"] = value.ToString();
			}
		}

		public Vector3 Origin
		{
			get
			{
				Vector4 vector = GetVector("origin");
				return new Vector3(vector.X(), vector.Y(), vector.Z());
			}
			set
			{
				this["origin"] = value.X() + " " + value.Y() + " " + value.Z();
			}
		}

		public Vector3 Angles
		{
			get
			{
				Vector4 vector = GetVector("angles");
				return new Vector3(vector.X(), vector.Y(), vector.Z());
			}
			set
			{
				this["angles"] = value.X() + " " + value.Y() + " " + value.Z();
			}
		}

		public string Name
		{
			get
			{
				if (ContainsKey("targetname"))
				{
					return this["targetname"];
				}
				if (ContainsKey("name"))
				{
					return this["name"];
				}
				return "";
			}
			set
			{
				this["targetname"] = value;
			}
		}

		public string ClassName
		{
			get
			{
				if (ContainsKey("classname"))
				{
					return this["classname"];
				}
				return "";
			}
			set
			{
				this["classname"] = value;
			}
		}

		public string Model
		{
			get
			{
				if (ContainsKey("model"))
				{
					return this["model"];
				}
				return null;
			}
			set
			{
				this["model"] = value;
			}
		}

		public int ModelNumber
		{
			get
			{
				try
				{
					if (this["classname"] == "worldspawn")
					{
						return 0;
					}
					if (ContainsKey("model"))
					{
						string text = this["model"];
						if (text[0] == '*')
						{
							int result = -1;
							if (int.TryParse(text.Substring(1), out result))
							{
								return result;
							}
							return -1;
						}
						return -1;
					}
					return -1;
				}
				catch
				{
					return -1;
				}
			}
		}

		public new string this[string key]
		{
			get
			{
				if (ContainsKey(key))
				{
					return base[key];
				}
				return "";
			}
			set
			{
				base[key] = value;
			}
		}

		public Entity(ILump parent = null)
			: base((IEqualityComparer<string>)StringComparer.InvariantCultureIgnoreCase)
		{
			Parent = parent;
		}

		public Entity(byte[] data, ILump parent = null)
			: this(parent)
		{
			Data = data;
		}

		public Entity(string className, ILump parent = null)
			: this(parent)
		{
			Add("classname", className);
		}

		public Entity(Entity copy, ILump parent = null)
			: base((IDictionary<string, string>)copy, (IEqualityComparer<string>)StringComparer.InvariantCultureIgnoreCase)
		{
			connections = new List<EntityConnection>(copy.connections);
			brushes = new List<MAPBrush>(copy.brushes);
			Parent = parent;
		}

		protected Entity(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			connections = (List<EntityConnection>)info.GetValue("connections", typeof(List<EntityConnection>));
			brushes = (List<MAPBrush>)info.GetValue("brushes", typeof(List<MAPBrush>));
			Parent = (ILump)info.GetValue("Parent", typeof(ILump));
		}

		public void ParseString(string st)
		{
			Clear();
			brushes = new List<MAPBrush>();
			connections = new List<EntityConnection>();
			string[] array = st.SplitUnlessInContainer('\n', '"');
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			List<string> list = new List<string>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i].Trim(' ', '\t', '\r');
				bool flag3 = false;
				for (int j = 0; j < text.Length; j++)
				{
					if (text[j] == '"')
					{
						if (j == 0)
						{
							flag3 = !flag3;
						}
						else if (text[j - 1] != '\\')
						{
							if (flag3 && (j + 1 >= text.Length || text[j + 1] == '\n' || text[j + 1] == '\r'))
							{
								flag3 = false;
							}
						}
						else
						{
							flag3 = !flag3;
						}
					}
					if (!flag3 && text[j] == '/' && j != 0 && text[j - 1] == '/')
					{
						text = text.Substring(0, j - 1);
					}
				}
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				if (text[0] == '{')
				{
					if (num == 1 && !flag2 && !flag)
					{
						flag2 = true;
					}
					num++;
				}
				else
				{
					if (text[0] == '}')
					{
						num--;
						if (num == 1)
						{
							if (flag2)
							{
								list.Add(text);
								brushes.Add(new MAPBrush(list));
								list = new List<string>();
							}
							flag2 = false;
							flag = false;
						}
						else
						{
							list.Add(text);
						}
						continue;
					}
					if (text.Length >= 5 && text.Substring(0, 5) == "solid")
					{
						flag2 = true;
						continue;
					}
					if (text.Length >= 11 && text.Substring(0, 11) == "connections")
					{
						flag = true;
						continue;
					}
				}
				if (flag2)
				{
					list.Add(text);
				}
				else
				{
					Add(text);
				}
			}
		}

		public void RenameKey(string oldName, string newName)
		{
			if (ContainsKey(oldName))
			{
				string value = this[oldName];
				Remove(oldName);
				if (ContainsKey(newName))
				{
					Remove(newName);
				}
				Add(newName, value);
			}
		}

		public void Add(string st)
		{
			string text = "";
			string text2 = "";
			bool flag = false;
			bool flag2 = false;
			int num = 0;
			st.Trim('\r', '\n', '\t');
			for (int i = 0; i < st.Length; i++)
			{
				if (st[i] == '"' && (i == 0 || i == st.Length - 1 || st[i - 1] != '\\'))
				{
					if (flag)
					{
						if (flag2)
						{
							break;
						}
						flag2 = true;
					}
					flag = !flag;
				}
				else
				{
					if (!flag)
					{
						continue;
					}
					if (!flag2)
					{
						text += st[i];
						continue;
					}
					text2 += st[i];
					if (st[i] == ',' || st[i] == '\u001b')
					{
						num++;
					}
				}
			}
			text2.Replace("\\\"", "\"");
			if (!(text != null && flag2))
			{
				return;
			}
			if (num == 4 || num == 6)
			{
				st = st.Replace(',', '\u001b');
				string[] array = text2.Split(',');
				if (array.Length < 5)
				{
					array = text2.Split('\u001b');
				}
				if (array.Length != 5 && array.Length != 7)
				{
					return;
				}
				try
				{
					connections.Add(new EntityConnection
					{
						name = text,
						target = array[0],
						action = array[1],
						param = array[2],
						delay = float.Parse(array[3], _format),
						fireOnce = int.Parse(array[4]),
						unknown0 = ((array.Length > 5) ? array[5] : ""),
						unknown1 = ((array.Length > 6) ? array[6] : "")
					});
					return;
				}
				catch (FormatException)
				{
					if (!ContainsKey(text))
					{
						this[text] = text2;
					}
					return;
				}
			}
			if (!ContainsKey(text))
			{
				this[text] = text2;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\n");
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> current = enumerator.Current;
					stringBuilder.Append($"\"{current.Key}\" \"{current.Value}\"\n");
				}
			}
			if (connections.Count > 0)
			{
				foreach (EntityConnection connection in connections)
				{
					stringBuilder.Append(connection.ToString(MapType)).Append('\n');
				}
			}
			return stringBuilder.Append("}\n").ToString();
		}

		public bool ValueIs(string key, string value)
		{
			return value.Equals(this[key], StringComparison.InvariantCultureIgnoreCase);
		}

		public bool SpawnflagsSet(uint bits)
		{
			return (Spawnflags & bits) == bits;
		}

		public void ToggleSpawnflags(uint bits)
		{
			this["spawnflags"] = (Spawnflags ^ bits).ToString();
		}

		public void ClearSpawnflags(uint bits)
		{
			ToggleSpawnflags(Spawnflags & bits);
		}

		public void SetSpawnflags(uint bits)
		{
			this["spawnflags"] = (Spawnflags | bits).ToString();
		}

		public float GetFloat(string key, float? failDefault = null)
		{
			try
			{
				return float.Parse(this[key], _format);
			}
			catch (Exception ex)
			{
				if (!failDefault.HasValue)
				{
					throw ex;
				}
				return failDefault.Value;
			}
		}

		public int GetInt(string key, int? failDefault = null)
		{
			try
			{
				return int.Parse(this[key], _format);
			}
			catch (Exception ex)
			{
				if (!failDefault.HasValue)
				{
					throw ex;
				}
				return failDefault.Value;
			}
		}

		public Vector4 GetVector(string key)
		{
			float[] array = new float[4];
			if (ContainsKey(key) && !string.IsNullOrEmpty(this[key]))
			{
				string[] array2 = this[key].Split(' ');
				for (int i = 0; i < array.Length && i < array2.Length; i++)
				{
					try
					{
						array[i] = float.Parse(array2[i], _format);
					}
					catch
					{
						array[i] = 0f;
					}
				}
			}
			return new Vector4(array[0], array[1], array[2], array[3]);
		}

		public int CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			if (!(obj is Entity entity))
			{
				throw new ArgumentException("Object is not an Entity");
			}
			int num = ClassName.CompareTo(entity.ClassName);
			if (num == 0)
			{
				return Name.CompareTo(entity.Name);
			}
			return num;
		}

		public int CompareTo(Entity other)
		{
			if (other == null)
			{
				return 1;
			}
			int num = ClassName.CompareTo(other.ClassName);
			if (num == 0)
			{
				return Name.CompareTo(other.Name);
			}
			return num;
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("connections", connections, typeof(List<EntityConnection>));
			info.AddValue("brushes", brushes, typeof(List<MAPBrush>));
		}

		public static Entities LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Entities(data, bsp, lumpInfo);
		}

		public static int GetIndexForLump(MapType type)
		{
			switch (type)
			{
			case MapType.BlueShift:
				return 1;
			case MapType.MOHAADemo:
				return 15;
			default:
				if (type.IsSubtypeOf(MapType.Source) || type.IsSubtypeOf(MapType.Quake) || type.IsSubtypeOf(MapType.Quake2))
				{
					return 0;
				}
				if (type.IsSubtypeOf(MapType.STEF2))
				{
					return 16;
				}
				if (type.IsSubtypeOf(MapType.FAKK2) || type.IsSubtypeOf(MapType.MOHAA))
				{
					return 14;
				}
				switch (type)
				{
				case MapType.CoD:
				case MapType.CoDDemo:
					return 29;
				case MapType.CoD2:
					return 37;
				case MapType.CoD4:
					return 39;
				default:
					if (type.IsSubtypeOf(MapType.Quake3) || type == MapType.Nightfire)
					{
						return 0;
					}
					return -1;
				}
			}
		}
	}
}
