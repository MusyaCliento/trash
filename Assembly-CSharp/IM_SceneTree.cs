using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IM_SceneTree : MonoBehaviour
{
	private class SceneTreeWindow
	{
		public Rect rect;

		public Vector2 pos;

		public string searchContent = "";

		public List<GameObject> roots = new List<GameObject>();

		public HashSet<int> expandedThings = new HashSet<int>();
	}

	private class PropertyWindow
	{
		public string name;

		public Rect rect;

		public Vector2 pos;

		public GameObject root;

		public HashSet<int> expandedThings = new HashSet<int>();

		public Dictionary<int, Blackboard[]> perFieldData = new Dictionary<int, Blackboard[]>();

		public List<Action> commitQueue = new List<Action>();
	}

	private class Blackboard
	{
		private Dictionary<string, object> backing = new Dictionary<string, object>();

		public void Set<T>(string name, T value)
		{
			backing[name] = value;
		}

		public T Get<T>(string name, T def)
		{
			return (T)backing.GetValueOrDefault(name, def);
		}
	}

	private class TypeInfo
	{
		public Type type;

		public List<Field> fields = new List<Field>();
	}

	private class Field
	{
		public Type type;

		public string name;

		public Func<object, object> get;

		public Action<object, object> set;
	}

	private struct Optional
	{
		public bool hasValue;

		public object value;
	}

	private delegate bool TryParse<T>(string content, out T val);

	private bool sceneTreeEnabled;

	private readonly List<SceneTreeWindow> sceneWindows = new List<SceneTreeWindow>();

	private readonly List<PropertyWindow> propertyWindows = new List<PropertyWindow>();

	private Dictionary<Type, TypeInfo> cachedTypeInfos = new Dictionary<Type, TypeInfo>();

	private void Start()
	{
	}

	private void OnGUI()
	{
		if (!sceneTreeEnabled)
		{
			return;
		}
		if (sceneWindows.Count == 0)
		{
			sceneWindows.Add(new SceneTreeWindow
			{
				rect = new Rect(20f, 20f, 300f, 400f),
				roots = (from i in Enumerable.Range(0, SceneManager.sceneCount)
					select SceneManager.GetSceneAt(i)).SelectMany((Scene s) => s.GetRootGameObjects()).ToList()
			});
		}
		GUI.skin = CL_UIManager.instance.defaultSkin;
		for (int num = 0; num < sceneWindows.Count; num++)
		{
			SceneTreeWindow window = sceneWindows[num];
			window.rect = GUILayout.Window(window.GetHashCode(), window.rect, delegate
			{
				RenderSceneTreeWindow(window);
			}, $"Scene Window {num}");
		}
		for (int num2 = 0; num2 < propertyWindows.Count; num2++)
		{
			PropertyWindow window2 = propertyWindows[num2];
			window2.rect = GUILayout.Window(window2.GetHashCode(), window2.rect, delegate
			{
				RenderPropertyWindow(window2);
			}, "Property Window " + window2.name);
		}
	}

	private void RenderSceneTreeWindow(SceneTreeWindow window)
	{
		GUILayout.BeginVertical();
		window.pos = GUILayout.BeginScrollView(window.pos);
		for (int i = 0; i < window.roots.Count; i++)
		{
			RenderGameObject(window, window.roots[i].transform, 0);
		}
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
	}

	private void RenderGameObject(SceneTreeWindow window, Transform cur, int indent)
	{
		int hashCode = cur.GetHashCode();
		bool flag = window.expandedThings.Contains(hashCode);
		GUILayoutOption[] options = new GUILayoutOption[2]
		{
			GUILayout.Width(30f),
			GUILayout.Height(10f)
		};
		GUILayout.BeginHorizontal();
		GUILayout.Space(indent * 12);
		GUILayout.Label(cur.name);
		int childCount = cur.childCount;
		if (childCount > 0 && GUILayout.Button(flag ? "\\/" : ">", options))
		{
			if (flag)
			{
				window.expandedThings.Remove(hashCode);
			}
			else
			{
				window.expandedThings.Add(hashCode);
			}
		}
		if (GUILayout.Button("O", options))
		{
			PropertyWindow propertyWindow;
			if (propertyWindows.Count > 0)
			{
				propertyWindow = propertyWindows[0];
			}
			else
			{
				propertyWindow = new PropertyWindow();
				propertyWindow.rect = new Rect(30f, 30f, 400f, 600f);
				propertyWindows.Add(propertyWindow);
			}
			propertyWindow.root = cur.gameObject;
			propertyWindow.name = cur.name;
			propertyWindow.pos = Vector2.zero;
			propertyWindow.expandedThings.Clear();
		}
		bool activeSelf = cur.gameObject.activeSelf;
		bool flag2 = GUILayout.Toggle(activeSelf, "", options);
		if (activeSelf != flag2)
		{
			cur.gameObject.SetActive(flag2);
		}
		GUILayout.EndHorizontal();
		if (flag)
		{
			for (int i = 0; i < childCount; i++)
			{
				RenderGameObject(window, cur.GetChild(i), indent + 1);
			}
		}
	}

	private void RenderPropertyWindow(PropertyWindow window)
	{
		if (window.root == null)
		{
			GUILayout.Label("Game Object Destroyed");
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
			return;
		}
		bool flag = window.commitQueue.Count > 0;
		if (GUILayout.Button(flag ? "Commit" : "<color=grey>Commit</color>") && flag)
		{
			foreach (Action item in window.commitQueue)
			{
				item();
			}
			window.commitQueue.Clear();
			window.perFieldData.Clear();
		}
		window.pos = GUILayout.BeginScrollView(window.pos);
		GUILayout.BeginVertical();
		Component[] components = window.root.GetComponents<Component>();
		GUILayoutOption[] options = new GUILayoutOption[2]
		{
			GUILayout.Width(30f),
			GUILayout.Height(10f)
		};
		for (int i = 0; i < components.Length; i++)
		{
			GUILayout.BeginHorizontal();
			Component comp = components[i];
			Type type = comp.GetType();
			GUILayout.Label(type.Name);
			int hashCode = comp.GetHashCode();
			bool flag2 = window.expandedThings.Contains(hashCode);
			if (GUILayout.Button(flag2 ? "\\/" : ">", options))
			{
				if (flag2)
				{
					window.expandedThings.Remove(hashCode);
				}
				else
				{
					window.expandedThings.Add(hashCode);
				}
				flag2 = !flag2;
			}
			if (comp is Behaviour behaviour)
			{
				bool num = behaviour.enabled;
				bool flag3 = GUILayout.Toggle(num, "", options);
				if (num != flag3)
				{
					behaviour.enabled = flag3;
				}
			}
			GUILayout.EndHorizontal();
			if (!flag2)
			{
				continue;
			}
			TypeInfo typeInfo = GetTypeInfo(type);
			if (!window.perFieldData.TryGetValue(hashCode, out var value))
			{
				value = (from _ in Enumerable.Range(0, typeInfo.fields.Count)
					select new Blackboard()).ToArray();
				window.perFieldData[hashCode] = value;
			}
			for (int num2 = 0; num2 < typeInfo.fields.Count; num2++)
			{
				GUILayout.BeginHorizontal();
				GUILayout.Space(12f);
				Field field = typeInfo.fields[num2];
				GUILayout.Label(field.name);
				Func<object, Blackboard, Optional> func = FieldRender(field);
				Optional commit = func(field.get(comp), value[num2]);
				if (commit.hasValue)
				{
					window.commitQueue.Add(delegate
					{
						field.set(comp, commit.value);
					});
				}
				GUILayout.EndHorizontal();
			}
		}
		GUILayout.EndVertical();
		GUILayout.EndScrollView();
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
	}

	private TypeInfo GetTypeInfo(Type of)
	{
		TypeInfo typeInfo = new TypeInfo();
		FieldInfo[] fields = of.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (!(fieldInfo.DeclaringType == typeof(Component)) && !(fieldInfo.DeclaringType == typeof(MonoBehaviour)))
			{
				typeInfo.fields.Add(new Field
				{
					type = fieldInfo.FieldType,
					name = fieldInfo.Name,
					get = fieldInfo.GetValue,
					set = fieldInfo.SetValue
				});
			}
		}
		PropertyInfo[] properties = of.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (!(propertyInfo.DeclaringType == typeof(Component)) && !(propertyInfo.DeclaringType == typeof(MonoBehaviour)) && propertyInfo.CanRead)
			{
				typeInfo.fields.Add(new Field
				{
					type = propertyInfo.PropertyType,
					name = propertyInfo.Name,
					get = propertyInfo.GetValue,
					set = (propertyInfo.CanWrite ? new Action<object, object>(propertyInfo.SetValue) : ((Action<object, object>)delegate
					{
					}))
				});
			}
		}
		return typeInfo;
	}

	private Optional None()
	{
		return default(Optional);
	}

	private Optional Some(object val)
	{
		return new Optional
		{
			hasValue = true,
			value = val
		};
	}

	private Func<object, Blackboard, Optional> FieldRender(Field field)
	{
		float num = 150f;
		GUILayoutOption[] singleFieldOptions = new GUILayoutOption[1] { GUILayout.Width(num) };
		GUILayoutOption[] halfFieldOptions = new GUILayoutOption[1] { GUILayout.Width(num / 2f) };
		GUILayoutOption[] thirdFieldOptions = new GUILayoutOption[1] { GUILayout.Width(num / 3f) };
		GUILayoutOption[] quarterFieldOptions = new GUILayoutOption[1] { GUILayout.Width(num / 4f) };
		if (field.type == typeof(bool))
		{
			return delegate(object objBool, Blackboard _)
			{
				Optional result = None();
				bool flag = (bool)objBool;
				if (GUILayout.Button(flag ? "[X]" : "[ ]", singleFieldOptions))
				{
					result = Some(!flag);
				}
				return result;
			};
		}
		if (field.type == typeof(string))
		{
			return delegate(object obj, Blackboard blackboard)
			{
				string text = Field(blackboard, "i", (string)obj, singleFieldOptions);
				return (text == null) ? None() : Some(text);
			};
		}
		if (field.type == typeof(long))
		{
			return (object objInt, Blackboard blackboard) => FieldT<long>(blackboard, "i", objInt, long.TryParse, singleFieldOptions);
		}
		if (field.type == typeof(ulong))
		{
			return (object objInt, Blackboard blackboard) => FieldT<ulong>(blackboard, "i", objInt, ulong.TryParse, singleFieldOptions);
		}
		if (field.type == typeof(int))
		{
			return (object objInt, Blackboard blackboard) => FieldT<int>(blackboard, "i", objInt, int.TryParse, singleFieldOptions);
		}
		if (field.type == typeof(uint))
		{
			return (object objInt, Blackboard blackboard) => FieldT<uint>(blackboard, "i", objInt, uint.TryParse, singleFieldOptions);
		}
		if (field.type == typeof(short))
		{
			return (object objInt, Blackboard blackboard) => FieldT<short>(blackboard, "i", objInt, short.TryParse, singleFieldOptions);
		}
		if (field.type == typeof(ushort))
		{
			return (object objInt, Blackboard blackboard) => FieldT<ushort>(blackboard, "i", objInt, ushort.TryParse, singleFieldOptions);
		}
		if (field.type == typeof(sbyte))
		{
			return (object objInt, Blackboard blackboard) => FieldT<sbyte>(blackboard, "i", objInt, sbyte.TryParse, singleFieldOptions);
		}
		if (field.type == typeof(byte))
		{
			return (object objInt, Blackboard blackboard) => FieldT<byte>(blackboard, "i", objInt, byte.TryParse, singleFieldOptions);
		}
		if (field.type == typeof(float))
		{
			return (object objInt, Blackboard blackboard) => FieldT<float>(blackboard, "i", objInt, float.TryParse, singleFieldOptions);
		}
		if (field.type == typeof(double))
		{
			return (object objInt, Blackboard blackboard) => FieldT<double>(blackboard, "i", objInt, double.TryParse, singleFieldOptions);
		}
		if (field.type == typeof(Vector2))
		{
			return (object objVec, Blackboard blackboard) => VecT<Vector2, float>(blackboard, "i", objVec, (Vector2 v, int i) => v[i], delegate(Vector2 t, int idx, float v)
			{
				t[idx] = v;
				return t;
			}, 2, float.TryParse, halfFieldOptions);
		}
		if (field.type == typeof(Vector3))
		{
			return (object objVec, Blackboard blackboard) => VecT<Vector3, float>(blackboard, "i", objVec, (Vector3 v, int i) => v[i], delegate(Vector3 t, int idx, float v)
			{
				t[idx] = v;
				return t;
			}, 3, float.TryParse, thirdFieldOptions);
		}
		if (field.type == typeof(Vector4))
		{
			return (object objVec, Blackboard blackboard) => VecT<Vector4, float>(blackboard, "i", objVec, (Vector4 v, int i) => v[i], delegate(Vector4 t, int idx, float v)
			{
				t[idx] = v;
				return t;
			}, 4, float.TryParse, quarterFieldOptions);
		}
		if (field.type == typeof(Vector2Int))
		{
			return (object objVec, Blackboard blackboard) => VecT<Vector2Int, int>(blackboard, "i", objVec, (Vector2Int v, int i) => v[i], delegate(Vector2Int t, int idx, int v)
			{
				t[idx] = v;
				return t;
			}, 2, int.TryParse, halfFieldOptions);
		}
		if (field.type == typeof(Vector3Int))
		{
			return (object objVec, Blackboard blackboard) => VecT<Vector3Int, int>(blackboard, "i", objVec, (Vector3Int v, int i) => v[i], delegate(Vector3Int t, int idx, int v)
			{
				t[idx] = v;
				return t;
			}, 3, int.TryParse, thirdFieldOptions);
		}
		if (field.type == typeof(Quaternion))
		{
			return (object objVec, Blackboard blackboard) => VecT<Quaternion, float>(blackboard, "i", objVec, (Quaternion v, int i) => v[i], delegate(Quaternion t, int idx, float v)
			{
				t[idx] = v;
				return t;
			}, 4, float.TryParse, quarterFieldOptions);
		}
		if (field.type == typeof(Matrix4x4))
		{
			return delegate(object objMat, Blackboard blackboard)
			{
				Optional result = None();
				Matrix4x4 matrix4x = (Matrix4x4)objMat;
				GUILayout.BeginVertical();
				for (int i = 0; i < 4; i++)
				{
					GUILayout.BeginHorizontal();
					for (int j = 0; j < 4; j++)
					{
						string text = Field(blackboard, $"{i} {j}", matrix4x[i, j].ToString(), quarterFieldOptions);
						if (text != null && float.TryParse(text, out var result2))
						{
							matrix4x[i, j] = result2;
							result = Some(matrix4x[i, j]);
						}
					}
					GUILayout.EndHorizontal();
				}
				GUILayout.EndVertical();
				return result;
			};
		}
		typeof(Enum).IsAssignableFrom(field.type);
		return delegate
		{
			GUILayout.Label("Unknown type: " + field.type.Name);
			return None();
		};
		static string Field(Blackboard blackboard, string id, string value, GUILayoutOption[] options)
		{
			id = "__entered_" + id;
			string text = blackboard.Get<string>(id, null);
			string obj = text ?? value;
			string text2 = GUILayout.TextField(obj, options);
			if (obj != text2)
			{
				blackboard.Set(id, text2);
				return text2;
			}
			if (!(value != text2))
			{
				return null;
			}
			return text;
		}
		Optional FieldT<T>(Blackboard blackboard, string id, object obj, TryParse<T> tryParse, GUILayoutOption[] options)
		{
			Optional result = None();
			string text = Field(blackboard, id, ((T)obj/*cast due to .constrained prefix*/).ToString(), options);
			if (text != null && tryParse(text, out var val))
			{
				result = Some(val);
			}
			return result;
		}
		Optional VecT<T, F>(Blackboard blackboard, string id, object value, Func<T, int, F> get, Func<T, int, F, T> set, int componentCount, TryParse<F> tryParse, GUILayoutOption[] options)
		{
			Optional result = None();
			T val = (T)value;
			for (int i = 0; i < componentCount; i++)
			{
				string text = get(val, i).ToString();
				string text2 = Field(blackboard, i.ToString(), text.ToString(), options);
				if (text2 != null && tryParse(text2, out var val2))
				{
					val = set(val, i, val2);
					result = Some(val);
				}
			}
			return result;
		}
	}
}
