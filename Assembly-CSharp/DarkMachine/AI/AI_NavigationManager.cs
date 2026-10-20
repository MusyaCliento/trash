using UnityEngine;

namespace DarkMachine.AI
{
	public class AI_NavigationManager : MonoBehaviour
	{
		public static AI_BurrowManager burrowManager;

		private void Awake()
		{
			burrowManager = new AI_BurrowManager();
			burrowManager.Initialize();
		}
	}
}
