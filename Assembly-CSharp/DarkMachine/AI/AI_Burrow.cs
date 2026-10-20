using Drawing;
using UnityEngine;

namespace DarkMachine.AI
{
	public class AI_Burrow : MonoBehaviourGizmos
	{
		private void OnEnable()
		{
			if (AI_NavigationManager.burrowManager != null)
			{
				AI_NavigationManager.burrowManager.AddBurrow(this);
			}
		}

		private void OnDisable()
		{
			if (AI_NavigationManager.burrowManager != null)
			{
				AI_NavigationManager.burrowManager.RemoveBurrow(this);
			}
		}

		private void Update()
		{
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Label2D(base.transform.position, "AI Burrow", 12f, LabelAlignment.Center, Color.red);
				CL_DebugView.draw.WireHexagon(base.transform.position, Quaternion.LookRotation(base.transform.up, base.transform.forward), 1f, Color.red);
			}
		}

		public override void DrawGizmos()
		{
			if (DebugCore.showNav)
			{
				Draw.Label2D(base.transform.position, "AI Burrow", 12f, LabelAlignment.Center, Color.red);
				if (GizmoContext.InSelection(this))
				{
					Draw.Arrow(base.transform.position, base.transform.position + base.transform.up, Color.white);
					Draw.Arrow(base.transform.position, base.transform.position + base.transform.forward, Color.grey);
					Draw.WireHexagon(base.transform.position, Quaternion.LookRotation(base.transform.up, base.transform.forward), 1f, Color.red);
				}
				else
				{
					Draw.Arrow(base.transform.position, base.transform.position + base.transform.up, new Color(1f, 1f, 1f, 0.3f));
					Draw.Arrow(base.transform.position, base.transform.position + base.transform.forward, Color.grey);
					Draw.WireHexagon(base.transform.position, Quaternion.LookRotation(base.transform.up, base.transform.forward), 1f, new Color(1f, 0f, 0f, 0.2f));
				}
			}
		}
	}
}
