using Drawing;
using Pathfinding;
using UnityEngine;

public class AI_ControlNode : MonoBehaviourGizmos
{
	public enum NodeType
	{
		normal = 0,
		farLeap = 1,
		shortLeap = 2,
		burrow = 3
	}

	public NodeType aiNodeType;

	private NodeLink2 link;

	private void Start()
	{
		link = GetComponent<NodeLink2>();
	}

	public NodeLink2 GetLinkNode()
	{
		return link;
	}

	public Transform GetEndNode()
	{
		return link.end;
	}

	public override void DrawGizmos()
	{
		if (DebugCore.showNav)
		{
			if ((Object)(object)link == null)
			{
				link = GetComponent<NodeLink2>();
			}
			Color color = Color.green;
			string text = "AI " + aiNodeType;
			if (aiNodeType == NodeType.shortLeap)
			{
				color = new Color(0f, 1f, 1f, 0.5f);
			}
			Draw.Label2D(base.transform.position, text, 12f, LabelAlignment.Center, color * new Color(1f, 1f, 1f, 0.1f));
			if ((Object)(object)link != null)
			{
				Draw.DashedLine(base.transform.position, link.end.position, 0.5f, 0.5f, color * new Color(1f, 1f, 1f, 0.5f));
				Draw.DashedLine(base.transform.position + base.transform.right, link.end.position + link.end.right, 0.5f, 0.5f, color * new Color(1f, 1f, 1f, 0.25f));
				Draw.DashedLine(base.transform.position - base.transform.right, link.end.position - link.end.right, 0.5f, 0.5f, color * new Color(1f, 1f, 1f, 0.25f));
				Draw.Arrow(base.transform.position, base.transform.position + base.transform.up, Color.white);
				Draw.Arrow(base.transform.position, base.transform.position + base.transform.forward, Color.blue);
				Draw.WireHexagon(base.transform.position, Quaternion.LookRotation(base.transform.up, base.transform.forward), 1f, color);
				Draw.Arrow(link.end.position, link.end.position + link.end.up, Color.white);
				Draw.WireHexagon(link.end.position, Quaternion.LookRotation(link.end.up, link.end.forward), 1f, color);
				Draw.Arrow(link.end.position, link.end.position + link.end.forward, new Color(0f, 1f, 1f, 0.3f));
			}
		}
	}
}
