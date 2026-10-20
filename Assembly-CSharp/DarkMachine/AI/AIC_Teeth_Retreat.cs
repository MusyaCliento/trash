using UnityEngine;

namespace DarkMachine.AI
{
	public class AIC_Teeth_Retreat : AIStateComponent
	{
		public float retreatLength = 9f;

		private float retreatTimer = 5f;

		private DEN_Teeth teeth;

		public override string name => "retreat";

		public override void Enter(AIGameEntity e, string[] args = null)
		{
			base.Enter(e, args);
			e.clipHandler.PlaySound("teeth:retreat");
			retreatTimer = retreatLength;
			teeth = e.GetComponent<DEN_Teeth>();
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
			teeth.SetCohesionEffect(0.6f);
			e.SetTargetPosition(e.transform.position - Vector3.up * ((e.target.position.y > e.transform.position.y) ? 20 : (-20)));
			retreatTimer -= Time.deltaTime;
			if (retreatTimer <= 0f)
			{
				e.ChangeState("burrow");
			}
		}
	}
}
