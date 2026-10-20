using UnityEngine;

namespace DitzelGames.FastIK
{
	public class FastIKLook : MonoBehaviour
	{
		public Transform Target;

		protected Vector3 StartDirection;

		protected Quaternion StartRotation;

		private void Awake()
		{
			if (!(Target == null))
			{
				StartDirection = Target.position - base.transform.position;
				StartRotation = base.transform.rotation;
			}
		}

		private void Update()
		{
			if (!(Target == null))
			{
				base.transform.rotation = Quaternion.FromToRotation(StartDirection, Target.position - base.transform.position) * StartRotation;
			}
		}
	}
}
