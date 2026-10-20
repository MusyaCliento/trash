using UnityEngine;
using UnityEngine.UI;

public class FX_ShaderVariableController : MonoBehaviour
{
	private RawImage rendererComponent;

	private void Start()
	{
		rendererComponent = GetComponent<RawImage>();
	}

	[ExecuteInEditMode]
	private void Update()
	{
		rendererComponent.material.SetVector("_ObjectWorldPosition", base.transform.position);
	}
}
