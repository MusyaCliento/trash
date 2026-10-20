using System.Collections.Generic;
using UnityEngine;

namespace DarkMachine.AI
{
	public class AI_BurrowManager
	{
		public List<AI_Burrow> burrows;

		public void AddBurrow(AI_Burrow t)
		{
			if (!burrows.Contains(t))
			{
				burrows.Add(t);
			}
		}

		public void RemoveBurrow(AI_Burrow t)
		{
			if (burrows.Contains(t))
			{
				burrows.Remove(t);
			}
		}

		public AI_Burrow GetClosestBurrowToPosition(Vector3 pos)
		{
			if (burrows == null || burrows.Count == 0)
			{
				return null;
			}
			AI_Burrow result = null;
			float num = float.PositiveInfinity;
			for (int i = 0; i < burrows.Count; i++)
			{
				float num2 = Vector3.Distance(burrows[i].transform.position, pos);
				if (num2 < num)
				{
					result = burrows[i];
					num = num2;
				}
			}
			return result;
		}

		internal void Initialize()
		{
			burrows = new List<AI_Burrow>();
		}
	}
}
