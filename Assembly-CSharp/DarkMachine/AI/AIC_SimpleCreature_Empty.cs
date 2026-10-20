using System;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AIC_SimpleCreature_Empty : AIStateComponent
	{
		public Vector3 lookVector;

		public override string name => "empty";

		public override void Initialize(AIGameEntity e, AIStateVariable[] variables, string[] args = null)
		{
			base.Initialize(e, variables, args);
			lookVector = e.transform.forward;
		}

		public override Vector3 GetLookVector()
		{
			return base.GetLookVector();
		}
	}
}
