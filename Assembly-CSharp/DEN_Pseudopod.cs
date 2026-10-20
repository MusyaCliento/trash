using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(FX_MetaballSystem))]
[DefaultExecutionOrder(100)]
public class DEN_Pseudopod : Denizen
{
	[Serializable]
	public class Node
	{
		public FX_MetaballManager.Ball metaball;

		public float aggression;

		public float radius = 1f;

		public float radiusRerollWeight;

		public Transform transform;

		public Vector3 offsetFromParent;

		public List<Node> childNodes = new List<Node>();

		[HideInInspector]
		public Node parentNode;
	}

	private struct NodeProcInfo
	{
		public Node node;

		public Vector3 worldPos;
	}

	public bool active;

	public LayerMask sightMask;

	public float collisionDamage = 1f;

	public string damageTag = "pseudopod";

	public float collisionDamageRate = 0.1f;

	private float damageTime;

	public float maxAggression = 200f;

	public float minAggression = -30f;

	public float saturatedAgression = 150f;

	public float atrophyThreshold = -10f;

	public float aggresssionGainMult = 60f;

	public float aggresssionLossMult = 20f;

	public float radiusRerollBase = 0.2f;

	public float radiusRerollVariance = 0.2f;

	public float radiusRerollThreshold = 1f;

	public float radiusBase = 1f;

	public float radiusVariance = 0.2f;

	public int onMaxKillCount = 10;

	public float updateRate = 0.1f;

	private float updateStep;

	public List<Node> originNodes;

	private List<NodeProcInfo> processedNodes = new List<NodeProcInfo>();

	private List<NodeProcInfo> processedNodesTemp = new List<NodeProcInfo>();

	private FX_MetaballSystem system;

	private bool debugPause;

	private int lastCalculatedDepth;

	private int calculatingDepth;

	private Node growNode;

	private Vector3 growNodeWorldPos;

	private Node atrophyNode;

	private Vector3 atrophyNodeWorldPos;

	private Node deepestNode;

	private int autokillDeepest;

	private float closestToTargetDistanceFrame = float.PositiveInfinity;

	private void Awake()
	{
		system = GetComponent<FX_MetaballSystem>();
	}

	public override void Start()
	{
		base.Start();
		CommandConsole.BuildVariableBool(() => ref debugPause, "pseudopod_pause", "Pause pseudopod processing");
		SetTarget(ENT_Player.GetPlayer().transform);
	}

	private Vector3 ApplyTransform(Node node, Vector3 worldPos)
	{
		return ((node.transform != null) ? node.transform.position : worldPos) + node.offsetFromParent;
	}

	public override void OnEnable()
	{
		base.OnEnable();
		foreach (Node originNode in originNodes)
		{
			Process(originNode, ApplyTransform(originNode, Vector3.zero));
		}
		void Process(Node node, Vector3 worldPos)
		{
			node.metaball = FX_MetaballManager.BallCreate(system.system);
			FX_MetaballManager.BallXForm(system.system, node.metaball, node.transform, worldPos);
			FX_MetaballManager.BallRadius(system.system, node.metaball, node.radius);
			foreach (Node childNode in node.childNodes)
			{
				Process(childNode, ApplyTransform(childNode, worldPos));
			}
		}
	}

	public override void Update()
	{
		base.Update();
		float deltaTime = Time.deltaTime;
		Vector3 vector = ((target != null) ? target.position : Vector3.zero);
		bool flag = active && !CL_GameManager.gMan.isPaused && !debugPause;
		float num = updateRate / (float)Mathf.Max(1, lastCalculatedDepth);
		if (flag)
		{
			closestToTargetDistanceFrame = float.PositiveInfinity;
			updateStep += deltaTime;
		}
		while (flag && updateStep > updateRate)
		{
			calculatingDepth++;
			Node node = null;
			float num2 = float.PositiveInfinity;
			Vector3 vector2 = default(Vector3);
			foreach (NodeProcInfo processedNode in processedNodes)
			{
				deepestNode = processedNode.node;
				foreach (Node childNode in processedNode.node.childNodes)
				{
					processedNodesTemp.Add(new NodeProcInfo
					{
						node = childNode,
						worldPos = ApplyTransform(childNode, processedNode.worldPos)
					});
				}
				processedNode.node.radiusRerollWeight += radiusRerollBase + UnityEngine.Random.Range(0f - radiusRerollVariance, radiusRerollVariance);
				if (processedNode.node.radiusRerollWeight > radiusRerollThreshold)
				{
					Node node2 = processedNode.node;
					processedNode.node.radiusRerollWeight = 0f;
					float endValue = UnityEngine.Random.Range(radiusBase - radiusVariance, radiusBase + radiusVariance);
					DOTween.To(() => node2.radius, delegate(float val)
					{
						node2.radius = val;
					}, endValue, 1f).OnUpdate(delegate
					{
						FX_MetaballManager.BallRadius(system.system, node2.metaball, node2.radius);
					}).SetEase(Ease.InOutCubic);
				}
				RaycastHit hitInfo;
				bool num3 = true && !Physics.Raycast(processedNode.worldPos, vector, out hitInfo, 30f, sightMask);
				float sqrMagnitude = (processedNode.worldPos - vector).sqrMagnitude;
				if (num3 && sqrMagnitude < num2)
				{
					node = processedNode.node;
					num2 = sqrMagnitude;
					vector2 = processedNode.worldPos;
				}
				if (damageTime <= 0f && sqrMagnitude < processedNode.node.radius * processedNode.node.radius && target.TryGetComponent<GameEntity>(out var component))
				{
					component.Damage(Damageable.DamageInfo.CreateDamageInfo(collisionDamage, damageTag));
					component.AddForce((vector - processedNode.worldPos).normalized, "denizen");
					damageTime = collisionDamageRate;
				}
			}
			foreach (NodeProcInfo processedNode2 in processedNodes)
			{
				if (processedNode2.node != node)
				{
					float num4 = (processedNode2.worldPos - vector).sqrMagnitude * aggresssionLossMult;
					processedNode2.node.aggression = Mathf.Max(processedNode2.node.aggression - num4, minAggression);
					if (processedNode2.node.childNodes.Count == 0 && processedNode2.node.parentNode != null && processedNode2.node.aggression < atrophyThreshold && (atrophyNode == null || processedNode2.node.aggression < atrophyNode.aggression))
					{
						atrophyNode = processedNode2.node;
						atrophyNodeWorldPos = processedNode2.worldPos;
					}
				}
			}
			if (node != null)
			{
				float num5 = 1f / (num2 * num2) * aggresssionGainMult;
				node.aggression = Mathf.Min(node.aggression + num5, maxAggression);
				if (growNode == null || growNode.aggression <= node.aggression)
				{
					growNode = node;
					growNodeWorldPos = vector2;
				}
			}
			closestToTargetDistanceFrame = Mathf.Min(closestToTargetDistanceFrame, num2);
			List<NodeProcInfo> list = processedNodesTemp;
			List<NodeProcInfo> list2 = processedNodes;
			processedNodes = list;
			processedNodesTemp = list2;
			processedNodesTemp.Clear();
			if (processedNodes.Count == 0)
			{
				int num6 = FX_MetaballManager.SystemBallCount(system.system);
				int num7 = FX_MetaballManager.SystemBallCapacity(system.system);
				if (num6 == num7)
				{
					autokillDeepest = onMaxKillCount;
				}
				if (autokillDeepest > 0)
				{
					growNode = null;
					atrophyNode = deepestNode;
					autokillDeepest--;
				}
				for (Node parentNode = growNode; parentNode != null; parentNode = parentNode.parentNode)
				{
					parentNode.aggression = Mathf.Min(parentNode.aggression, saturatedAgression);
				}
				if (growNode != null)
				{
					Vector3 growParentPos = growNodeWorldPos;
					float endValue2 = UnityEngine.Random.Range(radiusBase - radiusVariance, radiusBase + radiusVariance);
					Vector3 endValue3 = (vector - growNodeWorldPos).normalized * (radiusBase - radiusVariance);
					FX_MetaballManager.Ball ball = FX_MetaballManager.BallCreate(system.system);
					Node node3 = new Node
					{
						metaball = ball,
						aggression = growNode.aggression,
						radius = 0f,
						offsetFromParent = Vector3.zero,
						parentNode = growNode
					};
					DOTween.To(() => node3.offsetFromParent, delegate(Vector3 val)
					{
						node3.offsetFromParent = val;
					}, endValue3, updateRate).OnUpdate(delegate
					{
						FX_MetaballManager.BallXForm(system.system, ball, null, growParentPos + node3.offsetFromParent);
					});
					DOTween.To(() => node3.radius, delegate(float val)
					{
						node3.radius = val;
					}, endValue2, updateRate).OnUpdate(delegate
					{
						FX_MetaballManager.BallRadius(system.system, ball, node3.radius);
					});
					growNode.childNodes.Add(node3);
				}
				if (atrophyNode != null && atrophyNode != growNode)
				{
					Node atrophyed = atrophyNode;
					Vector3 parentWorldPos = atrophyNodeWorldPos - atrophyed.offsetFromParent;
					DOTween.To(() => atrophyed.radius, delegate(float val)
					{
						atrophyed.radius = val;
					}, 0f, updateRate).OnUpdate(delegate
					{
						FX_MetaballManager.BallRadius(system.system, atrophyed.metaball, atrophyed.radius);
					});
					DOTween.To(() => atrophyed.offsetFromParent, delegate(Vector3 val)
					{
						atrophyed.offsetFromParent = val;
					}, Vector3.zero, updateRate).OnUpdate(delegate
					{
						FX_MetaballManager.BallXForm(system.system, atrophyed.metaball, null, parentWorldPos + atrophyed.offsetFromParent);
					}).OnComplete(delegate
					{
						FX_MetaballManager.BallDestroy(system.system, atrophyed.metaball);
					});
					atrophyNode.parentNode.childNodes.Remove(atrophyNode);
				}
				foreach (Node originNode in originNodes)
				{
					processedNodes.Add(new NodeProcInfo
					{
						node = originNode,
						worldPos = ApplyTransform(originNode, Vector3.zero)
					});
				}
				growNode = null;
				atrophyNode = null;
				deepestNode = null;
				lastCalculatedDepth = calculatingDepth;
				calculatingDepth = 0;
			}
			updateStep -= num;
			damageTime = Mathf.Max(damageTime - num, 0f);
		}
		if (closestToTargetDistanceFrame < 25f)
		{
			FXManager.fxMan.OverrideCorruptionHeightFrame(vector.y);
		}
		if (!CL_UIManager.debug)
		{
			return;
		}
		foreach (Node originNode2 in originNodes)
		{
			Process(originNode2, ApplyTransform(originNode2, Vector3.zero));
		}
		void Process(Node node4, Vector3 worldPos)
		{
			bool flag2 = false;
			foreach (NodeProcInfo processedNode3 in processedNodes)
			{
				flag2 |= processedNode3.node == node4;
			}
			if (flag2)
			{
				CL_DebugView.draw.PushColor(Color.Lerp(Color.red, Color.green, updateStep / updateRate));
			}
			CL_DebugView.draw.WireSphere(worldPos, node4.radius);
			if (flag2)
			{
				CL_DebugView.draw.PopColor();
			}
			CL_DebugView.draw.Label2D(worldPos, $"{node4.aggression}\n{node4.radiusRerollWeight / radiusRerollThreshold}");
			foreach (Node childNode2 in node4.childNodes)
			{
				Process(childNode2, ApplyTransform(childNode2, worldPos));
			}
		}
	}
}
