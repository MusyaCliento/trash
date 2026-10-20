using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class DarkMachineFunctions : MonoBehaviour
{
	internal interface IntrusiveGenArray
	{
		int generation { get; set; }

		int nextFree { get; set; }
	}

	internal struct GenArray<T> where T : struct, IntrusiveGenArray
	{
		public T[] elements;

		public int firstFree;

		public int count;

		public (int index, int generation) Add()
		{
			if (elements == null)
			{
				Clear();
			}
			if (firstFree == -1 && elements.Length == count)
			{
				Array.Resize(ref elements, count * 2);
			}
			int num;
			if (firstFree == -1)
			{
				num = count++;
			}
			else
			{
				num = firstFree;
				firstFree = elements[num].nextFree;
			}
			elements[num].generation++;
			return (index: num, generation: elements[num].generation);
		}

		public void Remove(int index, int generation)
		{
			if (IsValid(index, generation))
			{
				elements[index].generation++;
				elements[index].nextFree = firstFree;
				firstFree = index;
			}
		}

		public void Clear()
		{
			count = 0;
			firstFree = -1;
			elements = new T[128];
		}

		public readonly bool IsValid(int index, int generation)
		{
			if (elements != null && index >= 0 && index < count && elements[index].generation == generation)
			{
				return generation % 2 == 1;
			}
			return false;
		}
	}

	public struct RenderUnityEventDesc
	{
		public UnityEventBase ev;

		public string prependString;

		public Color color;
	}

	public static Action<float> offsetAction;

	private static readonly Plane[] frustrumPlanesCachedArray = new Plane[6];

	private static readonly byte[] Log2DeBruijn = new byte[32]
	{
		0, 9, 1, 10, 13, 21, 2, 29, 11, 14,
		16, 18, 22, 25, 3, 30, 8, 12, 20, 28,
		15, 17, 24, 7, 19, 27, 23, 6, 26, 5,
		4, 31
	};

	private static bool showUnityEvents = false;

	public static string SecondsToTimeString(float seconds, string format = "mm\\:ss")
	{
		return TimeSpan.FromSeconds(seconds).ToString(format);
	}

	public static string MemoryToString(long memory)
	{
		return $"{memory / 1073741824 % 1024}gb {memory / 1048576 % 1024}mb {memory / 1024 % 1024}kb {memory % 1024}b";
	}

	public static string SecondsToTimeLeaderboardString(float seconds)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		if (timeSpan.TotalHours < 1.0)
		{
			return string.Format($"M:{timeSpan.Minutes} S:{timeSpan.Seconds}.{timeSpan.Milliseconds}");
		}
		if (timeSpan.TotalDays < 1.0)
		{
			return string.Format($"H:{timeSpan.Hours} M:{timeSpan.Minutes} S:{timeSpan.Seconds}.{timeSpan.Milliseconds}");
		}
		return string.Format($"D:{timeSpan.Days} H:{timeSpan.Hours} M:{timeSpan.Minutes} S:{timeSpan.Seconds}.{timeSpan.Milliseconds}");
	}

	public static string GameObjectFullPath(GameObject obj)
	{
		string text = "";
		Transform transform = null;
		if (obj != null)
		{
			text = obj.name;
			transform = obj.transform.parent;
		}
		while (transform != null)
		{
			text = transform.name + "/" + text;
			transform = transform.parent;
		}
		return text;
	}

	public static Dictionary<string, string> ParseKeyValueString(string input)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (string.IsNullOrWhiteSpace(input))
		{
			return dictionary;
		}
		string[] array = input.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(':');
			if (array2.Length == 2)
			{
				string key = array2[0].Trim();
				string value = array2[1].Trim();
				if (!dictionary.ContainsKey(key))
				{
					dictionary[key] = value;
				}
			}
		}
		return dictionary;
	}

	public static List<string> ParseStringArray(string input, string splitString = "/")
	{
		List<string> list = new List<string>();
		list.AddRange(input.Split(splitString));
		return list;
	}

	public static string ProcessText(string input, bool repeat = true)
	{
		string text = FillData(input, delegate(string content)
		{
			string[] array = content.Split(":");
			string text2 = array[0];
			if (array.Length > 1)
			{
				switch (text2)
				{
				case "flagData":
				{
					CL_GameManager.SessionFlag gameFlag = CL_GameManager.GetGameFlag(array[1]);
					string text3 = null;
					if (gameFlag == null)
					{
						Debug.LogError("Exception: Could not find flag " + array[1] + "!");
						return "Missing value " + array[1] + " found! Report a bug!";
					}
					return gameFlag.data;
				}
				case "flag":
					if (!CL_GameManager.HasActiveFlag(array[1]))
					{
						return array[2];
					}
					return array[1];
				case "rand":
					return array[UnityEngine.Random.Range(1, array.Length)];
				case "lang":
					return CL_LocalizationManager.GetLocalization(array[1], array[2]);
				case "glyph":
					return "<rewiredElement type=\"glyphOrText\" playerId=0 actionName=\"" + array[1] + "\">";
				}
			}
			return content;
		});
		if (repeat)
		{
			text = ProcessText(text, repeat: false);
		}
		return text;
		static string FillData(string input2, Func<string, string> replacer)
		{
			return Regex.Replace(input2, "\\{(.*?)\\}", delegate(Match match)
			{
				string value = match.Groups[1].Value;
				return replacer(value);
			});
		}
	}

	public static int PackBools(bool[] values)
	{
		int num = 0;
		for (int i = 0; i < values.Length && i < 32; i++)
		{
			if (values[i])
			{
				num |= 1 << i;
			}
		}
		return num;
	}

	public static bool[] UnpackBools(int mask, int count)
	{
		bool[] array = new bool[count];
		for (int i = 0; i < count && i < 32; i++)
		{
			array[i] = (mask & (1 << i)) != 0;
		}
		return array;
	}

	public static (int, int) UlongToInts(ulong what)
	{
		return ((int)(what & 0xFFFFFFFFu), (int)(what >> 32));
	}

	public static ulong IntsToUlong(int a, int b)
	{
		return ((ulong)(uint)b << 32) | (uint)a;
	}

	public static void ShuffleList<T>(List<T> what)
	{
		for (int i = 0; i < what.Count; i++)
		{
			int num = UnityEngine.Random.Range(0, what.Count);
			int index = num;
			int index2 = i;
			T val = what[i];
			T val2 = what[num];
			T val3 = (what[index] = val);
			val3 = (what[index2] = val2);
		}
	}

	public static float GetManhattanDistance(Vector3 start, Vector3 end)
	{
		return Mathf.Max(Mathf.Max(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y)), Mathf.Abs(start.z - end.z));
	}

	public static Texture2D ResizeNearest(Texture2D src, int newW, int newH, bool sRGB, FilterMode filterMode, TextureWrapMode wrapMode, bool mipmap = false)
	{
		Texture2D texture2D = new Texture2D(newW, newH, TextureFormat.RGBA32, mipmap, !sRGB);
		texture2D.filterMode = filterMode;
		texture2D.wrapMode = wrapMode;
		Color32[] pixels = src.GetPixels32();
		Color32[] array = new Color32[newW * newH];
		int width = src.width;
		int height = src.height;
		for (int i = 0; i < newH; i++)
		{
			int num = Mathf.Clamp(Mathf.FloorToInt(((float)i + 0.5f) / (float)newH * (float)height), 0, height - 1) * width;
			for (int j = 0; j < newW; j++)
			{
				int num2 = Mathf.Clamp(Mathf.FloorToInt(((float)j + 0.5f) / (float)newW * (float)width), 0, width - 1);
				array[i * newW + j] = pixels[num + num2];
			}
		}
		texture2D.SetPixels32(array);
		texture2D.Apply(mipmap, makeNoLongerReadable: false);
		return texture2D;
	}

	public static bool SweepMoveAll(Rigidbody rb, Vector3 direction, float maxDistance, LayerMask mask)
	{
		direction.Normalize();
		RaycastHit[] array = rb.SweepTestAll(direction, maxDistance, QueryTriggerInteraction.Ignore);
		float num = maxDistance;
		bool result = false;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit raycastHit = array2[i];
			if (((1 << raycastHit.collider.gameObject.layer) & (int)mask) != 0 && raycastHit.distance < num)
			{
				num = raycastHit.distance;
				result = true;
			}
		}
		rb.MovePosition(rb.position + direction * num);
		return result;
	}

	public static bool IsBoundsInCameraFrustrum(Bounds bounds, Camera camera)
	{
		return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(camera), bounds);
	}

	public static bool IsPositionInCameraFrustrum(Vector3 position, Camera camera)
	{
		Vector3 vector = camera.WorldToViewportPoint(position);
		if (vector.x < 0f || vector.x > 1f || vector.y < 0f || vector.y > 1f || vector.z < 0f)
		{
			return true;
		}
		return false;
	}

	public static bool IsSphereInFrustrum(Plane[] frustrumPlanes, Vector3 pos, float radius)
	{
		for (int i = 0; i < frustrumPlanes.Length; i++)
		{
			if (!IsSphereInFrontOfPlane(frustrumPlanes[i], pos, radius))
			{
				return false;
			}
		}
		return true;
	}

	private static bool IsSphereInFrontOfPlane(Plane plane, Vector3 pos, float radius)
	{
		return plane.GetDistanceToPoint(pos) >= 0f - radius;
	}

	public static Vector3[] GenerateEquidistantVectors(int numPoints)
	{
		Vector3[] array = new Vector3[numPoints];
		float num = MathF.PI * (3f - Mathf.Sqrt(5f));
		for (int i = 0; i < numPoints; i++)
		{
			float num2 = 1f - (float)i / (float)(numPoints - 1) * 2f;
			float num3 = Mathf.Sqrt(1f - num2 * num2);
			float f = num * (float)i;
			float x = Mathf.Cos(f) * num3;
			float z = Mathf.Sin(f) * num3;
			array[i] = new Vector3(x, num2, z);
		}
		return array;
	}

	public static long HashString(ReadOnlySpan<char> str)
	{
		long num = 256L;
		for (int i = 0; i < str.Length; i++)
		{
			num ^= str[i];
			num *= 1111111111111111111L;
		}
		return num;
	}

	public static int Count1BitsFast(uint n)
	{
		int num = 0;
		while (n != 0)
		{
			n &= n - 1;
			num++;
		}
		return num;
	}

	public static int FirstOneBit(uint i)
	{
		int num = 0;
		ushort num2 = (ushort)i;
		if (num2 == 0)
		{
			num2 = (ushort)(i >> 16);
			num += 16;
		}
		byte b = (byte)num2;
		if (b == 0)
		{
			b = (byte)(num2 >> 8);
			num += 8;
		}
		for (int j = 0; j < 8; j++)
		{
			if ((b & (1 << j)) != 0)
			{
				return num;
			}
			num++;
		}
		return -1;
	}

	public static int Log2(uint value)
	{
		value |= value >> 1;
		value |= value >> 2;
		value |= value >> 4;
		value |= value >> 8;
		value |= value >> 16;
		return Log2DeBruijn[value * 130329821 >> 27];
	}

	public static string GetVersionName(string append)
	{
		return string.Concat("[" + Application.productName.ToLower() + "-" + Application.version + "] " + append, " [steam]");
	}

	public static void RenderUnityEvent(ref CommandBuilder builder, Transform origin, List<RenderUnityEventDesc> descs)
	{
		if (!showUnityEvents)
		{
			return;
		}
		Dictionary<Transform, List<(string, Color)>> dictionary = new Dictionary<Transform, List<(string, Color)>>();
		for (int i = 0; i < descs.Count; i++)
		{
			RenderUnityEventDesc renderUnityEventDesc = descs[i];
			int persistentEventCount = renderUnityEventDesc.ev.GetPersistentEventCount();
			for (int j = 0; j < persistentEventCount; j++)
			{
				UnityEngine.Object persistentTarget = renderUnityEventDesc.ev.GetPersistentTarget(j);
				string persistentMethodName = renderUnityEventDesc.ev.GetPersistentMethodName(j);
				object obj = UnityEventGetPersistentEventArg(renderUnityEventDesc.ev, j);
				Transform transform = null;
				if (persistentTarget is Component component)
				{
					transform = component.transform;
				}
				if (persistentTarget is GameObject gameObject)
				{
					transform = gameObject.transform;
				}
				if (!(transform == null))
				{
					if (obj is string)
					{
						obj = $"\"{obj}\"";
					}
					string item = $"{renderUnityEventDesc.prependString}{persistentTarget.GetType().Name}.{persistentMethodName}({obj})\n";
					if (!dictionary.TryGetValue(transform, out var value))
					{
						value = new List<(string, Color)>();
						dictionary.Add(transform, value);
					}
					value.Add((item, renderUnityEventDesc.color));
				}
			}
		}
		Vector3 position = origin.position;
		foreach (KeyValuePair<Transform, List<(string, Color)>> item2 in dictionary)
		{
			item2.Deconstruct(out var key, out var value2);
			Transform transform2 = key;
			List<(string, Color)> list = value2;
			Color? color = list[0].Item2;
			string text = list[0].Item1;
			for (int k = 1; k < list.Count; k++)
			{
				if (list[k].Item2 != color)
				{
					color = null;
				}
				text += list[k].Item1;
			}
			Color color2 = color ?? Color.purple;
			Vector3 position2 = transform2.position;
			builder.PushColor(color2);
			if (transform2 != origin)
			{
				builder.DashedLine(position, position2, 0.5f, 0.5f);
			}
			else
			{
				builder.Arc(position + new Vector3(1f, 1f, 1f), position, position);
			}
			builder.Label2D((position + position2) / 2f + Vector3.up, text);
			builder.PopColor();
		}
	}

	public static object UnityEventGetPersistentEventArg(UnityEventBase ev, int index)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
		try
		{
			object value = typeof(UnityEventBase).GetField("m_PersistentCalls", bindingAttr).GetValue(ev);
			object obj = (value.GetType().GetField("m_Calls", bindingAttr).GetValue(value) as IReadOnlyList<object>)[index];
			object value2 = obj.GetType().GetField("m_Arguments", bindingAttr).GetValue(obj);
			PersistentListenerMode persistentListenerMode = (PersistentListenerMode)obj.GetType().GetField("m_Mode", bindingAttr).GetValue(obj);
			object result = null;
			switch (persistentListenerMode)
			{
			case PersistentListenerMode.Object:
				result = value2.GetType().GetField("m_ObjectArgument", bindingAttr).GetValue(value2);
				break;
			case PersistentListenerMode.Int:
				result = value2.GetType().GetField("m_IntArgument", bindingAttr).GetValue(value2);
				break;
			case PersistentListenerMode.Float:
				result = value2.GetType().GetField("m_FloatArgument", bindingAttr).GetValue(value2);
				break;
			case PersistentListenerMode.String:
				result = value2.GetType().GetField("m_StringArgument", bindingAttr).GetValue(value2);
				break;
			case PersistentListenerMode.Bool:
				result = value2.GetType().GetField("m_BoolArgument", bindingAttr).GetValue(value2);
				break;
			}
			return result;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static bool IsNullOrDestroyed(object obj)
	{
		return obj?.Equals(null) ?? true;
	}

	public static bool IsNullOrDestroyedOrDisabled(object obj)
	{
		if (obj != null && !obj.Equals(null) && (!(obj is Component component) || component.gameObject.activeInHierarchy))
		{
			if (obj is GameObject gameObject)
			{
				return !gameObject.activeInHierarchy;
			}
			return false;
		}
		return true;
	}
}
