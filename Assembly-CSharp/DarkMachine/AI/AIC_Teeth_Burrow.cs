using System.Collections;
using UnityEngine;

namespace DarkMachine.AI
{
	public class AIC_Teeth_Burrow : AIStateComponent
	{
		private DEN_Teeth teeth;

		public override string name => "burrow";

		public override void Initialize(AIGameEntity e, AIStateVariable[] variables, string[] args = null)
		{
			base.Initialize(e, variables, args);
			teeth = e.GetComponent<DEN_Teeth>();
		}

		public override void Enter(AIGameEntity e, string[] args = null)
		{
			base.Enter(e, args);
			e.StartCoroutine(BurrowAnimation(e));
		}

		private IEnumerator BurrowAnimation(AIGameEntity e)
		{
			teeth.locked = true;
			teeth.anim.SetTrigger("burrowstart");
			teeth.clipHandler.PlaySound("teeth:burrowstart");
			teeth.handParticle.Stop();
			teeth.screenHandEffect.Stop();
			CL_CameraControl.ShakeAtPosition(teeth.transform.position, 0.2f, 15f);
			yield return new WaitForSeconds(5f);
			teeth.geoRoot.gameObject.SetActive(value: false);
			yield return new WaitForSeconds(4f);
			float closestBurrowDistance = float.PositiveInfinity;
			while (closestBurrowDistance > 15f)
			{
				if (AI_NavigationManager.burrowManager != null)
				{
					AI_Burrow closestBurrowToPosition = AI_NavigationManager.burrowManager.GetClosestBurrowToPosition(e.target.transform.position);
					float num = Vector3.Distance(e.target.transform.position, closestBurrowToPosition.transform.position);
					if (num < closestBurrowDistance)
					{
						closestBurrowDistance = num;
						if (num < 15f)
						{
							e.transform.position = closestBurrowToPosition.transform.position + -closestBurrowToPosition.transform.forward * 0.5f;
							teeth.geoRoot.transform.position = closestBurrowToPosition.transform.position + -closestBurrowToPosition.transform.forward * 0.5f;
							teeth.geoRoot.transform.rotation = closestBurrowToPosition.transform.rotation;
							teeth.fxZone.blend = 0f;
							yield return new WaitForSeconds(5f);
							break;
						}
					}
				}
				yield return new WaitForSeconds(1f);
			}
			teeth.geoRoot.gameObject.SetActive(value: true);
			teeth.anim.SetTrigger("burrowend");
			teeth.clipHandler.PlaySound("teeth:burrowend");
			CL_CameraControl.ShakeAtPosition(teeth.transform.position, 0.2f, 15f);
			yield return new WaitForSeconds(4f);
			teeth.handParticle.Play();
			teeth.screenHandEffect.Play();
			teeth.locked = false;
			e.ChangeState("wander");
		}

		public override void Execute(AIGameEntity e, string[] args = null)
		{
			base.Execute(e, args);
		}

		public override void Exit(AIGameEntity e, string[] args = null)
		{
			base.Exit(e, args);
		}
	}
}
