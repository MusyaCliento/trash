using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AIC_SimpleCreature_PathFollow : AIStateComponent
	{
		public Transform pathRoot;

		internal List<Transform> pathNodes;

		public float nodeSwitchDistance = 3f;

		private int currentNode;

		private Vector3 lookVector;

		public override string name => "wander";

		public override void Initialize(AIGameEntity e, AIStateVariable[] variables, string[] args = null)
		{
			base.Initialize(e, variables, args);
			CalculatePaths();
		}

		public override void Enter(AIGameEntity e, string[] args)
		{
			base.Enter(e, args);
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
			if (pathNodes == null || pathNodes.Count == 0)
			{
				e.SetTargetPosition(Vector3.zero);
				return;
			}
			if (currentNode >= pathNodes.Count)
			{
				currentNode = 0;
			}
			float num = Vector3.Distance(e.transform.position, pathNodes[currentNode].position);
			e.SetTargetPosition(pathNodes[currentNode].position);
			if (num < nodeSwitchDistance)
			{
				currentNode++;
			}
			lookVector = e.targetPosition - e.transform.position;
		}

		public void CalculatePaths()
		{
			pathNodes = new List<Transform>();
			Transform[] componentsInChildren = pathRoot.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				if (!(transform == pathRoot))
				{
					pathNodes.Add(transform);
				}
			}
		}

		public override Vector3 GetLookVector()
		{
			return lookVector;
		}
	}
}
