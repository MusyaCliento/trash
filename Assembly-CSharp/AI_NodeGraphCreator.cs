using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using Pathfinding;
using UnityEngine;

public class AI_NodeGraphCreator : MonoBehaviourGizmos
{
	public Transform parentNode;

	public float maxNodeConnectDistance = 10f;

	public LayerMask layerMask;

	public Transform createdNodeParent;

	private List<Transform> routingNodes = new List<Transform>();

	public bool showNodes = true;

	public bool showScanDistance = true;

	public PointGraph pointGraph;

	public PathfindingTag defaultNodeTag = 0u;

	private bool hasGenerated;

	public static AI_NodeGraphCreator activeNodeTree;

	private void Initialize()
	{
		activeNodeTree = this;
	}

	private void OnEnable()
	{
		StopAllCoroutines();
		routingNodes = new List<Transform>();
		StartCoroutine(WaitForAstar());
	}

	private IEnumerator WaitForAstar()
	{
		while ((UnityEngine.Object)(object)AstarPath.active == null)
		{
			yield return null;
		}
		foreach (Transform item in parentNode)
		{
			routingNodes.Add(item);
		}
		pointGraph = AstarPath.active.data.AddGraph(typeof(PointGraph)) as PointGraph;
		pointGraph.name = "PGraph:" + Time.time;
		pointGraph.mask = layerMask;
		pointGraph.maxDistance = maxNodeConnectDistance;
		pointGraph.root = base.transform;
		AstarPath.active.Scan(pointGraph);
		AstarPath.active.AddWorkItem((Action)delegate
		{
			for (int i = 0; i < routingNodes.Count; i++)
			{
				pointGraph.AddNode((Int3)routingNodes[i].position);
			}
			pointGraph.ConnectNodes();
		});
		AstarPath.active.FlushWorkItems();
		Initialize();
	}

	private void OnDisable()
	{
		if ((UnityEngine.Object)(object)AstarPath.active != null && AstarPath.active.data != null)
		{
			AstarPath.active.data.RemoveGraph(pointGraph);
		}
	}

	public static Transform GetRandomNode()
	{
		if (activeNodeTree == null)
		{
			return null;
		}
		return activeNodeTree.routingNodes[UnityEngine.Random.Range(0, activeNodeTree.routingNodes.Count)];
	}

	private void DrawLines()
	{
		foreach (Transform routingNode in routingNodes)
		{
			if (routingNode != null)
			{
				Draw.SphereOutline(routingNode.position, 0.2f, Color.green);
				Draw.SphereOutline(routingNode.position, 0.1f, Color.green);
			}
		}
	}

	public override void DrawGizmos()
	{
		DrawLines();
	}
}
