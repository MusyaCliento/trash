using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UT_MaterialController : MonoBehaviour
{
	public List<Renderer> renderers;

	private List<Material> materials;

	public int targetIndex;

	private void Start()
	{
		materials = new List<Material>();
		foreach (Renderer renderer in renderers)
		{
			materials.Add(renderer.material);
		}
		if (materials == null || materials.Count == 0)
		{
			materials = new List<Material>();
			materials.Add(GetComponent<Renderer>().material);
		}
	}

	private void Update()
	{
	}

	public void SetFloat(string f)
	{
		if (materials == null || materials.Count == 0)
		{
			materials = new List<Material>();
			materials.Add(GetComponent<Renderer>().material);
		}
		string[] array = f.Split(":");
		foreach (Material material in materials)
		{
			if (material != null)
			{
				material.SetFloat(array[0], float.Parse(array[1]));
			}
		}
	}

	public void SetColor(string f)
	{
		if (materials == null || materials.Count == 0)
		{
			materials = new List<Material>();
			materials.Add(GetComponent<Renderer>().material);
		}
		string[] array = f.Split(":");
		if (array.Length <= 2)
		{
			Color color = Color.white;
			ColorUtility.TryParseHtmlString(array[1], out color);
			{
				foreach (Material material in materials)
				{
					if (material != null)
					{
						material.SetColor(array[0], color);
					}
				}
				return;
			}
		}
		int num = int.Parse(array[0]);
		Material obj = GetComponent<Renderer>().materials[num];
		Color color2 = Color.white;
		ColorUtility.TryParseHtmlString(array[2], out color2);
		obj.SetColor(array[1], color2);
	}

	public void SetMaterial(Material m)
	{
		foreach (Renderer renderer in renderers)
		{
			Material[] array = renderer.materials;
			array[targetIndex] = m;
			renderer.SetMaterials(array.ToList());
		}
	}
}
