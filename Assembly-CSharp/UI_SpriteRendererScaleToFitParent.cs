using UnityEngine;

public class UI_SpriteRendererScaleToFitParent : MonoBehaviour
{
	public bool updateEveryFrame = true;

	private void Start()
	{
		MatchParentScale();
	}

	private void Update()
	{
		if (updateEveryFrame)
		{
			MatchParentScale();
		}
	}

	public void MatchParentScale()
	{
		RectTransform component = base.transform.parent.GetComponent<RectTransform>();
		if (component != null)
		{
			Vector3 lossyScale = component.lossyScale;
			lossyScale.x = Mathf.Abs(1f / lossyScale.x);
			lossyScale.y = Mathf.Abs(1f / lossyScale.y);
			lossyScale.z = Mathf.Abs(1f / lossyScale.z);
			base.transform.localScale = lossyScale;
		}
	}
}
