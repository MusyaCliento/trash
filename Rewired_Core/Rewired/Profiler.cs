using System.Diagnostics;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class Profiler
	{
		private const string qcSEaZCfNjHbvugIwmXVfuTKDTId = "ENABLE_PROFILER must be set in Rewired Core to use the profiler.";

		public static bool enableBinaryLog
		{
			get
			{
				eumIeMZepSSwZxvoxmjVsujevyEC();
				return false;
			}
			set
			{
				eumIeMZepSSwZxvoxmjVsujevyEC();
			}
		}

		public static bool enabled
		{
			get
			{
				eumIeMZepSSwZxvoxmjVsujevyEC();
				return false;
			}
			set
			{
				eumIeMZepSSwZxvoxmjVsujevyEC();
			}
		}

		public static string logFile
		{
			get
			{
				eumIeMZepSSwZxvoxmjVsujevyEC();
				return string.Empty;
			}
			set
			{
				eumIeMZepSSwZxvoxmjVsujevyEC();
			}
		}

		public static bool supported
		{
			get
			{
				eumIeMZepSSwZxvoxmjVsujevyEC();
				return false;
			}
		}

		public static uint usedHeapSize
		{
			get
			{
				eumIeMZepSSwZxvoxmjVsujevyEC();
				return 0u;
			}
		}

		public static long usedHeapSizeLong
		{
			get
			{
				eumIeMZepSSwZxvoxmjVsujevyEC();
				return 0L;
			}
		}

		private static void eumIeMZepSSwZxvoxmjVsujevyEC()
		{
			Logger.Log("ENABLE_PROFILER must be set in Rewired Core to use the profiler.");
		}

		[Conditional("ENABLE_PROFILER")]
		public static void AddFramesFromFile(string file)
		{
			eumIeMZepSSwZxvoxmjVsujevyEC();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
			eumIeMZepSSwZxvoxmjVsujevyEC();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name, Object targetObject)
		{
			eumIeMZepSSwZxvoxmjVsujevyEC();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
			eumIeMZepSSwZxvoxmjVsujevyEC();
		}

		public static uint GetMonoHeapSize()
		{
			eumIeMZepSSwZxvoxmjVsujevyEC();
			return 0u;
		}

		public static long GetMonoHeapSizeLong()
		{
			return 0L;
		}

		public static uint GetMonoUsedSize()
		{
			eumIeMZepSSwZxvoxmjVsujevyEC();
			return 0u;
		}

		public static long GetMonoUsedSizeLong()
		{
			return 0L;
		}

		public static int GetRuntimeMemorySize(Object o)
		{
			eumIeMZepSSwZxvoxmjVsujevyEC();
			return 0;
		}

		public static long GetRuntimeMemorySizeLong(Object o)
		{
			return 0L;
		}

		public static uint GetTotalAllocatedMemory()
		{
			eumIeMZepSSwZxvoxmjVsujevyEC();
			return 0u;
		}

		public static long GetTotalAllocatedMemoryLong()
		{
			return 0L;
		}

		public static uint GetTotalReservedMemory()
		{
			return 0u;
		}

		public static long GetTotalReservedMemoryLong()
		{
			return 0L;
		}

		public static uint GetTotalUnusedReservedMemory()
		{
			return 0u;
		}

		public static long GetTotalUnusedReservedMemoryLong()
		{
			return 0L;
		}
	}
}
