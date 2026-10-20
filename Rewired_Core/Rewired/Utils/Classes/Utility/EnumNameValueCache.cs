using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> oOZLYduaSxBsJGkHSrRiPPVdUUQj;

		private readonly ADictionary<string, TEnum> PSziLPeBddOfLkiJEUxMDXbQXgOE;

		private readonly string[] VlCbekFQnhiOtybPjwPGPzUpaGSbA;

		private readonly long[] yLPbxTPqtdAWMcBbHOPNuiySgSwd;

		public static EnumNameValueCache<TEnum> Default => oOZLYduaSxBsJGkHSrRiPPVdUUQj ?? (oOZLYduaSxBsJGkHSrRiPPVdUUQj = new EnumNameValueCache<TEnum>());

		public int Count => yLPbxTPqtdAWMcBbHOPNuiySgSwd.Length;

		public static void Free()
		{
			oOZLYduaSxBsJGkHSrRiPPVdUUQj = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			VlCbekFQnhiOtybPjwPGPzUpaGSbA = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			PSziLPeBddOfLkiJEUxMDXbQXgOE = new ADictionary<string, TEnum>();
			yLPbxTPqtdAWMcBbHOPNuiySgSwd = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				yLPbxTPqtdAWMcBbHOPNuiySgSwd[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				PSziLPeBddOfLkiJEUxMDXbQXgOE.Add(VlCbekFQnhiOtybPjwPGPzUpaGSbA[i], array[i]);
			}
		}

		public TEnum GetValue(string name)
		{
			return ((ADictionary<string, string>)(object)PSziLPeBddOfLkiJEUxMDXbQXgOE)[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return PSziLPeBddOfLkiJEUxMDXbQXgOE.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return VlCbekFQnhiOtybPjwPGPzUpaGSbA[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = VlCbekFQnhiOtybPjwPGPzUpaGSbA[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)yLPbxTPqtdAWMcBbHOPNuiySgSwd.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((ADictionary<string, string>)(object)PSziLPeBddOfLkiJEUxMDXbQXgOE)[VlCbekFQnhiOtybPjwPGPzUpaGSbA[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)yLPbxTPqtdAWMcBbHOPNuiySgSwd.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return VlCbekFQnhiOtybPjwPGPzUpaGSbA[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(VlCbekFQnhiOtybPjwPGPzUpaGSbA, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(yLPbxTPqtdAWMcBbHOPNuiySgSwd, value);
		}

		public bool Contains(string name)
		{
			return PSziLPeBddOfLkiJEUxMDXbQXgOE.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
