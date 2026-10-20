using UnityEngine;

public class ANB_Randomizer : StateMachineBehaviour
{
	public int randomMin;

	public int randomMax;

	public string randomParameter = "random";

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetInteger(randomParameter, Random.Range(0, randomMax + 1));
	}

	public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
	{
		animator.SetInteger(randomParameter, Random.Range(0, randomMax + 1));
	}
}
