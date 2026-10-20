using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class UT_ChildArray : MonoBehaviourGizmos
{
	public Vector3 localArrayDirection;

	public float offset = 1f;

	public bool centered = true;

	public bool lerpPositions;

	public float lerpSpeed = 3f;

	private float lerpOffset;

	private List<Transform> childTransforms = new List<Transform>();

	private bool hasChildrenChanged;

	private void OnTransformChildrenChanged()
	{
		if (base.transform.childCount == 0)
		{
			return;
		}
		float num = (float)base.transform.childCount / 2f;
		for (int i = 0; i < base.transform.childCount; i++)
		{
			if (!childTransforms.Contains(base.transform.GetChild(i)))
			{
				float num2 = (float)i + 0.5f;
				Vector3 localPosition = localArrayDirection * num2 * offset - localArrayDirection * num * offset;
				base.transform.GetChild(i).localPosition = localPosition;
			}
		}
		hasChildrenChanged = true;
	}

	private void Update()
	{
		if (base.transform.childCount == 0)
		{
			return;
		}
		if (hasChildrenChanged)
		{
			childTransforms.Clear();
			for (int i = 0; i < base.transform.childCount; i++)
			{
				childTransforms.Add(base.transform.GetChild(i));
			}
			hasChildrenChanged = false;
		}
		float num = (float)base.transform.childCount / 2f;
		if (!centered)
		{
			num = 0f;
		}
		for (int j = 0; j < base.transform.childCount; j++)
		{
			float num2 = (float)j + 0.5f;
			if (lerpPositions)
			{
				Vector3 b = localArrayDirection * num2 * offset - localArrayDirection * num * offset;
				base.transform.GetChild(j).localPosition = Vector3.Lerp(base.transform.GetChild(j).localPosition, b, Time.deltaTime * lerpSpeed);
			}
			else
			{
				base.transform.GetChild(j).localPosition = localArrayDirection * num2 * offset - localArrayDirection * num * offset;
			}
		}
	}

	public override void DrawGizmos()
	{
		if (centered)
		{
			Draw.Arrow(base.transform.position, base.transform.position + base.transform.TransformDirection(localArrayDirection));
		}
		else
		{
			Draw.Arrow(base.transform.position - base.transform.TransformDirection(localArrayDirection), base.transform.position + base.transform.TransformDirection(localArrayDirection));
		}
	}
}
