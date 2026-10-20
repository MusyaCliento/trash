using UnityEngine;

public class UT_HoverInfo : MonoBehaviour
{
	[TextArea]
	public string infoText;

	public void OnHover()
	{
		CL_UIManager.instance.SetDescription(infoText);
	}
}
