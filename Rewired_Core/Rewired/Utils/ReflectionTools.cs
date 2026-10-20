using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public static class ReflectionTools
	{
		[Flags]
		public enum BindingFlags
		{
			IgnoreCase = 1,
			DeclaredOnly = 2,
			Instance = 4,
			Static = 8,
			Public = 0x10,
			NonPublic = 0x20,
			FlattenHierarchy = 0x40,
			InvokeMethod = 0x100
		}

		private const string avueBdKFvAUbLUBvqCxzVTmyMstxA = "Rewired.Utils.ExternalTools+Static";

		public static bool IsValueType(Type type)
		{
			return type.IsValueType;
		}

		public static bool IsEnum(Type type)
		{
			if (type == null)
			{
				return false;
			}
			return type.IsEnum;
		}

		public static Type GetUnderlyingEnumType(Type enumType)
		{
			if (enumType == null)
			{
				return null;
			}
			if (!IsEnum(enumType))
			{
				return null;
			}
			return Enum.GetUnderlyingType(enumType);
		}

		public static bool IsClass(Type type)
		{
			return type.IsClass;
		}

		public static bool IsPrimitive(Type type)
		{
			return type.IsPrimitive;
		}

		public static bool IsArray(Type type)
		{
			return type.IsArray;
		}

		public static bool DoesTypeImplement(Type type, Type baseOrInterfaceType)
		{
			return baseOrInterfaceType.IsAssignableFrom(type);
		}

		public static bool IsGenericType(Type type)
		{
			if (type == null)
			{
				return false;
			}
			return type.IsGenericType;
		}

		public static Type[] GetGenericArguments(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetGenericArguments();
		}

		public static IEnumerable<FieldInfo> GetFields(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetFields();
		}

		public static IEnumerable<FieldInfo> GetFields(Type type, BindingFlags bindingFlags)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetFields((System.Reflection.BindingFlags)bindingFlags);
		}

		public static IEnumerable<PropertyInfo> GetProperties(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetProperties();
		}

		public static IEnumerable<PropertyInfo> GetProperties(Type type, BindingFlags bindingFlags)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetProperties((System.Reflection.BindingFlags)bindingFlags);
		}

		public static IEnumerable<MethodInfo> GetMethods(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetMethods();
		}

		public static IEnumerable<MethodInfo> GetMethods(Type type, BindingFlags bindingFlags)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetMethods((System.Reflection.BindingFlags)bindingFlags);
		}

		public static bool IsDefined(Type type, Type attributeType, bool inherit)
		{
			if (type == null || attributeType == null)
			{
				return false;
			}
			return type.IsDefined(attributeType, inherit);
		}

		public static T GetAttribute<T>(Type type, bool inherit) where T : Attribute
		{
			if (type == null)
			{
				return null;
			}
			try
			{
				object[] customAttributes = type.GetCustomAttributes(typeof(T), inherit);
				if (customAttributes == null || customAttributes.Length == 0)
				{
					return null;
				}
				return customAttributes[0] as T;
			}
			catch
			{
				return null;
			}
		}

		internal static bool IsAssemblyLoaded(string assemblyName, bool useShortName, bool ignoreCase)
		{
			if (string.IsNullOrEmpty(assemblyName))
			{
				return false;
			}
			IList<Assembly> currentAssemblies = UnityTools.GetCurrentAssemblies();
			if (currentAssemblies == null)
			{
				return false;
			}
			for (int i = 0; i < currentAssemblies.Count; i++)
			{
				if (ignoreCase)
				{
					if (useShortName)
					{
						if (currentAssemblies[i].GetName().Name.Equals(assemblyName, StringComparison.OrdinalIgnoreCase))
						{
							return true;
						}
					}
					else if (currentAssemblies[i].FullName.Equals(assemblyName, StringComparison.OrdinalIgnoreCase))
					{
						return true;
					}
				}
				else if (useShortName)
				{
					if (currentAssemblies[i].GetName().Name.Equals(assemblyName))
					{
						return true;
					}
				}
				else if (currentAssemblies[i].FullName.Equals(assemblyName))
				{
					return true;
				}
			}
			return false;
		}

		private static Assembly PyStRVsAOtEpOaJduzIVfnuqcbROA(string P_0, bool P_1 = false)
		{
			foreach (Assembly currentAssembly in UnityTools.GetCurrentAssemblies())
			{
				if (currentAssembly.GetType(P_0, throwOnError: false, P_1) != null)
				{
					return currentAssembly;
				}
			}
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal static Assembly GetAssembly(string assemblyShortName)
		{
			IList<Assembly> currentAssemblies = UnityTools.GetCurrentAssemblies();
			if (currentAssemblies == null)
			{
				return null;
			}
			for (int i = 0; i < currentAssemblies.Count; i++)
			{
				if (currentAssemblies[i].GetName().Name.Equals(assemblyShortName, StringComparison.OrdinalIgnoreCase))
				{
					return currentAssemblies[i];
				}
			}
			return null;
		}

		internal static Type GetTypeInUnityEditorAssembly(string classPath, bool ignoreCase = false)
		{
			return SsjQirtSfRcVsqJHBHqYTRPgjtdbA(classPath, true, ignoreCase);
		}

		internal static Type GetTypeInUnityBuildAssembly(string classPath, bool ignoreCase = false)
		{
			return SsjQirtSfRcVsqJHBHqYTRPgjtdbA(classPath, false, ignoreCase);
		}

		internal static Type GetTypeInAnyAssembly(string classPath, bool ignoreCase = false)
		{
			return SsjQirtSfRcVsqJHBHqYTRPgjtdbA(classPath, true, ignoreCase);
		}

		private static Type SsjQirtSfRcVsqJHBHqYTRPgjtdbA(string P_0, bool P_1, bool P_2 = false)
		{
			foreach (Assembly currentAssembly in UnityTools.GetCurrentAssemblies())
			{
				Type type = currentAssembly.GetType(P_0, throwOnError: false, P_2);
				if (type != null)
				{
					return type;
				}
			}
			return null;
		}

		internal static Type GetTypeInAssembly(string classPath, string assemblyName, bool ignoreCase = false)
		{
			return Type.GetType(classPath + ", " + assemblyName + ", Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", throwOnError: false, ignoreCase);
		}

		public static TRet GetPrivateField<T, TRet>(T obj, string name)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			return (TRet)typeof(T).GetField(name, (System.Reflection.BindingFlags)bindingAttr).GetValue(obj);
		}

		public static TRet GetPrivateProperty<T, TRet>(T obj, string name)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			return (TRet)typeof(T).GetProperty(name, (System.Reflection.BindingFlags)bindingAttr).GetValue(obj, null);
		}

		public static void SetPrivateField<T>(T obj, string name, object value)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			typeof(T).GetField(name, (System.Reflection.BindingFlags)bindingAttr).SetValue(obj, value);
		}

		public static void SetPrivateProperty<T>(T obj, string name, object value)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			typeof(T).GetProperty(name, (System.Reflection.BindingFlags)bindingAttr).SetValue(obj, value, null);
		}

		public static TRet CallPrivateMethod<T, TRet>(T obj, string name, params object[] param)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			return (TRet)typeof(T).GetMethod(name, (System.Reflection.BindingFlags)bindingAttr).Invoke(obj, param);
		}

		public static bool TryInvokeMethod<T>(Assembly assembly, string fullyQualifiedTypeName, string methodName, BindingFlags bindingFlags, object[] args, out T result, bool silent = true)
		{
			bindingFlags |= BindingFlags.InvokeMethod;
			Type type = assembly.GetType(fullyQualifiedTypeName);
			if (type == null)
			{
				if (!silent)
				{
					Logger.LogError("Cannot find access " + fullyQualifiedTypeName + " class.", requiredThreadSafety: true);
				}
				result = default(T);
				return false;
			}
			try
			{
				object obj = type.InvokeMember(methodName, (System.Reflection.BindingFlags)bindingFlags, null, null, args);
				if (!(obj is T))
				{
					throw new Exception("Unexpected return type.");
				}
				result = (T)obj;
				return true;
			}
			catch (Exception ex)
			{
				if (!silent)
				{
					Logger.LogError("Error invoking " + fullyQualifiedTypeName + "." + methodName + "\n" + ex, requiredThreadSafety: true);
				}
				result = default(T);
				return false;
			}
		}

		public static bool TryInvokeMethod(Assembly assembly, string fullyQualifiedTypeName, string methodName, BindingFlags bindingFlags, object[] args, bool silent = true)
		{
			bindingFlags |= BindingFlags.InvokeMethod;
			Type type = assembly.GetType(fullyQualifiedTypeName);
			if (type == null)
			{
				if (!silent)
				{
					Logger.LogError("Cannot find access " + fullyQualifiedTypeName + " class.", requiredThreadSafety: true);
				}
				return false;
			}
			try
			{
				type.InvokeMember(methodName, (System.Reflection.BindingFlags)bindingFlags, null, null, args);
				return true;
			}
			catch (Exception ex)
			{
				if (!silent)
				{
					Logger.LogError("Error invoking " + fullyQualifiedTypeName + "." + methodName + "\n" + ex, requiredThreadSafety: true);
				}
				return false;
			}
		}

		private static Assembly eeObXrHyUNhkIfEpwtCEFGKLdBeqA()
		{
			return PyStRVsAOtEpOaJduzIVfnuqcbROA("Rewired.Utils.ExternalTools+Static");
		}

		private static bool qMnXReZfzVtjSOnYoDnWtKNkrVgr(string P_0)
		{
			Assembly assembly = PyStRVsAOtEpOaJduzIVfnuqcbROA("UnityEditor.EditorUserBuildSettings");
			if (assembly == null)
			{
				return false;
			}
			Type type = assembly.GetType("UnityEditor.EditorUserBuildSettings", throwOnError: false, ignoreCase: false);
			if (type != null)
			{
				PropertyInfo property = type.GetProperty("activeScriptCompilationDefines", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.GetProperty);
				if (property != null)
				{
					string[] array = (string[])property.GetValue(null, null);
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].Equals(P_0, StringComparison.Ordinal))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		internal static bool IsUnityInputManagerEnabled()
		{
			string fullyQualifiedTypeName = "Rewired.Utils.ExternalTools+Static";
			Assembly assembly = eeObXrHyUNhkIfEpwtCEFGKLdBeqA();
			if (Application.isEditor && assembly == null)
			{
				try
				{
					if (assembly == null)
					{
						return qMnXReZfzVtjSOnYoDnWtKNkrVgr("ENABLE_LEGACY_INPUT_MANAGER");
					}
				}
				catch
				{
					return false;
				}
			}
			if (assembly == null)
			{
				return false;
			}
			TryInvokeMethod<bool>(assembly, fullyQualifiedTypeName, "IsUnityInputManagerEnabled", BindingFlags.Static | BindingFlags.Public, null, out var result, silent: false);
			return result;
		}

		internal static bool IsUnityInputSystemEnabled()
		{
			string fullyQualifiedTypeName = "Rewired.Utils.ExternalTools+Static";
			Assembly assembly = eeObXrHyUNhkIfEpwtCEFGKLdBeqA();
			if (Application.isEditor && assembly == null)
			{
				try
				{
					if (assembly == null)
					{
						return qMnXReZfzVtjSOnYoDnWtKNkrVgr("ENABLE_INPUT_SYSTEM");
					}
				}
				catch
				{
					return false;
				}
			}
			if (assembly == null)
			{
				return false;
			}
			TryInvokeMethod<bool>(assembly, fullyQualifiedTypeName, "IsUnityInputSystemEnabled", BindingFlags.Static | BindingFlags.Public, null, out var result, silent: false);
			return result;
		}

		public static MethodInfo GetMethodInfo(Delegate @delegate)
		{
			return @delegate?.Method;
		}
	}
}
