using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibBSP
{
	public static class StringExtensions
	{
		public static string[] SplitUnlessInContainer(this string st, char separator, char container, StringSplitOptions options = StringSplitOptions.None)
		{
			if (st.IndexOf(separator) < 0)
			{
				return new string[1] { st };
			}
			if (st.IndexOf(container) < 0)
			{
				return st.Split(new char[1] { separator }, options);
			}
			List<string> list = new List<string>();
			bool flag = false;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in st)
			{
				if (c == container)
				{
					flag = !flag;
					stringBuilder.Append(c);
				}
				else if (!flag)
				{
					if (c == separator)
					{
						switch (options)
						{
						case StringSplitOptions.RemoveEmptyEntries:
							if (stringBuilder.Length > 0)
							{
								list.Add(stringBuilder.ToString());
							}
							stringBuilder.Length = 0;
							break;
						case StringSplitOptions.None:
							list.Add(stringBuilder.ToString());
							stringBuilder.Length = 0;
							break;
						}
					}
					else
					{
						stringBuilder.Append(c);
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			if (stringBuilder.Length > 0)
			{
				list.Add(stringBuilder.ToString());
			}
			return Enumerable.ToArray(list);
		}

		public static string[] SplitUnlessBetweenDelimiters(this string st, char separator, char start, char end, StringSplitOptions options = StringSplitOptions.None)
		{
			List<string> list = new List<string>();
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in st)
			{
				if (c == start)
				{
					num++;
					if (num == 1)
					{
						continue;
					}
				}
				if (c == end)
				{
					num--;
					if (num == 0)
					{
						continue;
					}
				}
				if (num == 0)
				{
					if (c == separator)
					{
						switch (options)
						{
						case StringSplitOptions.RemoveEmptyEntries:
							if (stringBuilder.Length > 0)
							{
								list.Add(stringBuilder.ToString());
							}
							stringBuilder.Length = 0;
							break;
						case StringSplitOptions.None:
							list.Add(stringBuilder.ToString());
							stringBuilder.Length = 0;
							break;
						}
					}
					else
					{
						stringBuilder.Append(c);
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			if (stringBuilder.Length > 0)
			{
				list.Add(stringBuilder.ToString());
			}
			return Enumerable.ToArray(list);
		}

		public static string ToNullTerminatedString(this byte[] bytes, int offset = 0, int length = -1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < bytes.Length && (i <= length || length < 0) && bytes[i + offset] != 0; i++)
			{
				stringBuilder.Append((char)bytes[i + offset]);
			}
			return stringBuilder.ToString();
		}

		public static string ToRawString(this byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < bytes.Length; i++)
			{
				stringBuilder.Append((char)bytes[i]);
			}
			return stringBuilder.ToString();
		}
	}
}
