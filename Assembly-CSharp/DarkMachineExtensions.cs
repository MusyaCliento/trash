using System;
using UnityEngine;

public static class DarkMachineExtensions
{
	public static bool IsFiniteAll(this Vector3 vec)
	{
		if (float.IsFinite(vec.x) && float.IsFinite(vec.y))
		{
			return float.IsFinite(vec.z);
		}
		return false;
	}

	public static ReadOnlySpan<char> AsSpan(this string s)
	{
		return MemoryExtensions.AsSpan(s);
	}
}
