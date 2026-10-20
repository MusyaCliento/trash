using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float ecFDqffgNgyjnidjuAogrFkJOpbzA;

		private float xoeDIxjBpWBWIPKgJzQntmyhZwcy;

		private int EoxCAeNkeMlgMMczPPikMBNThKiu;

		private int yBsFELdvwbChUjznBirEulsDaTMMB;

		public float minFloat => ecFDqffgNgyjnidjuAogrFkJOpbzA;

		public float maxFloat => xoeDIxjBpWBWIPKgJzQntmyhZwcy;

		public int minInt => EoxCAeNkeMlgMMczPPikMBNThKiu;

		public int maxInt => yBsFELdvwbChUjznBirEulsDaTMMB;

		public FieldRangeAttribute(float P_0, float P_1)
		{
			ecFDqffgNgyjnidjuAogrFkJOpbzA = P_0;
			xoeDIxjBpWBWIPKgJzQntmyhZwcy = P_1;
			EoxCAeNkeMlgMMczPPikMBNThKiu = (int)P_0;
			yBsFELdvwbChUjznBirEulsDaTMMB = (int)P_1;
		}

		public FieldRangeAttribute(int P_0, int P_1)
		{
			EoxCAeNkeMlgMMczPPikMBNThKiu = P_0;
			yBsFELdvwbChUjznBirEulsDaTMMB = P_1;
			ecFDqffgNgyjnidjuAogrFkJOpbzA = P_0;
			xoeDIxjBpWBWIPKgJzQntmyhZwcy = P_1;
		}
	}
}
