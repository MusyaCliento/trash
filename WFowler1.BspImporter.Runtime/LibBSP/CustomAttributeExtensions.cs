using System;
using System.Reflection;

namespace LibBSP
{
	public static class CustomAttributeExtensions
	{
		public static T GetCustomAttribute<T>(this MemberInfo element) where T : Attribute
		{
			return Attribute.GetCustomAttribute(element, typeof(T)) as T;
		}
	}
}
