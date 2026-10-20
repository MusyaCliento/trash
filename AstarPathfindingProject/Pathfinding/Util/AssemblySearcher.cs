using System;
using System.Collections.Generic;
using System.Reflection;

namespace Pathfinding.Util
{
	internal static class AssemblySearcher
	{
		public static List<Type> FindTypesInheritingFrom<T>()
		{
			List<Type> list = new List<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				string name = assembly.GetName().Name;
				if (name.StartsWith("Unity.") || name.StartsWith("UnityEngine.") || name == "UnityEngine" || name.StartsWith("UnityEditor.") || name == "UnityEditor" || name.StartsWith("Mono.") || name.StartsWith("System.") || name == "System" || name.StartsWith("mscorlib") || name.StartsWith("I18N") || name == "netstandard" || name == "nunit.framework")
				{
					continue;
				}
				Type[] array = null;
				try
				{
					array = assembly.GetTypes();
				}
				catch
				{
					continue;
				}
				Type[] array2 = array;
				foreach (Type type in array2)
				{
					Type baseType = type.BaseType;
					while (baseType != null)
					{
						if (object.Equals(baseType, typeof(T)))
						{
							list.Add(type);
							break;
						}
						baseType = baseType.BaseType;
					}
				}
			}
			return list;
		}
	}
}
