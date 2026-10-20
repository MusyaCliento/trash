using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ENV_DenizenSecurityLockout_Display : MonoBehaviour
{
	public ENV_DenizenSecurityLockout lockout;

	public TMP_Text displayText;

	public UnityEvent onAllEntitiesKilled;

	private void Start()
	{
		ENV_DenizenSecurityLockout eNV_DenizenSecurityLockout = lockout;
		eNV_DenizenSecurityLockout._OnAllEntitiesKilled = (Action)Delegate.Combine(eNV_DenizenSecurityLockout._OnAllEntitiesKilled, new Action(OnAllEntitiesKilled));
		ENV_DenizenSecurityLockout eNV_DenizenSecurityLockout2 = lockout;
		eNV_DenizenSecurityLockout2._OnEntityDeath = (Action)Delegate.Combine(eNV_DenizenSecurityLockout2._OnEntityDeath, new Action(OnEntityDeath));
		displayText.text = $"{lockout.GetEntitiesRemaining()}";
	}

	private void OnAllEntitiesKilled()
	{
		displayText.text = "00";
		onAllEntitiesKilled.Invoke();
	}

	private void OnEntityDeath()
	{
		displayText.text = $"{lockout.GetEntitiesRemaining()}";
	}
}
