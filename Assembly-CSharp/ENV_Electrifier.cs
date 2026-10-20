using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class ENV_Electrifier : MonoBehaviourGizmos, Activatable
{
	public class CurrentActivationTask
	{
		public ActivationConnectionCommand activationConnectionCommand;

		public float remainingDelay;
	}

	public class ActivationConnectionCommand
	{
		public List<ENV_Electrifier> activatedElectrifiers;

		public float delay;

		public bool targetState;

		public int startFrame;
	}

	public bool active = true;

	public bool canElectrify = true;

	public float timer;

	public ParticleSystem sparkParticles;

	public List<ENV_Electrifier> connectedElectrifiers;

	public GameObject activeGameObject;

	public UnityEvent activationEvent;

	public UnityEvent deactivationEvent;

	public bool showConnectionBeams = true;

	private List<CurrentActivationTask> currentActivationTasks = new List<CurrentActivationTask>();

	public float defaultActivationSpreadDelay;

	public bool createBeamOnActivation;

	public float connectionBeamLifetime = 1f;

	public FX_BeamShared connectionBeam;

	public Transform beamSourcePosition;

	public Transform beamTargetPosition;

	private List<ENV_Electrifier> activeNeighbors = new List<ENV_Electrifier>();

	private void Start()
	{
		if (active)
		{
			Activate();
		}
		else
		{
			Deactivate();
		}
	}

	private void Update()
	{
		if (currentActivationTasks.Count > 0)
		{
			for (int num = currentActivationTasks.Count - 1; num >= 0; num--)
			{
				RunTask(currentActivationTasks[num]);
			}
		}
	}

	public void Activate()
	{
		active = true;
		if (sparkParticles != null && !sparkParticles.isPlaying)
		{
			sparkParticles.Play();
		}
		activationEvent.Invoke();
	}

	public void Deactivate()
	{
		if (sparkParticles != null && sparkParticles.isPlaying)
		{
			sparkParticles.Stop();
		}
		active = false;
		deactivationEvent.Invoke();
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public void ToggleActivated()
	{
		active = !active;
	}

	public void ToggleConnections()
	{
		active = !active;
		ActivateConnections(active, defaultActivationSpreadDelay);
	}

	public void ActivateConnections(bool state)
	{
		active = state;
		ActivateConnections(state, defaultActivationSpreadDelay);
	}

	public void ActivateConnections(bool state, float delay)
	{
		ActivationConnectionCommand activationConnectionCommand = new ActivationConnectionCommand
		{
			targetState = state,
			activatedElectrifiers = new List<ENV_Electrifier>(),
			delay = delay,
			startFrame = Time.frameCount
		};
		SetConnectedActivation(ref activationConnectionCommand);
	}

	public void SetConnectedActivation(ref ActivationConnectionCommand activationConnectionCommand)
	{
		if (canElectrify)
		{
			if (activationConnectionCommand.targetState)
			{
				Activate();
			}
			else
			{
				Deactivate();
			}
			activationConnectionCommand.activatedElectrifiers.Add(this);
			CurrentActivationTask currentActivationTask = new CurrentActivationTask();
			currentActivationTask.activationConnectionCommand = activationConnectionCommand;
			currentActivationTask.remainingDelay = activationConnectionCommand.delay;
			currentActivationTasks.Add(currentActivationTask);
			if (currentActivationTask.remainingDelay == 0f)
			{
				RunTask(currentActivationTask);
			}
		}
	}

	private void RunTask(CurrentActivationTask activationTask)
	{
		if (activationTask.remainingDelay <= 0f)
		{
			if (connectedElectrifiers != null && connectedElectrifiers.Count > 0)
			{
				foreach (ENV_Electrifier connectedElectrifier in connectedElectrifiers)
				{
					if (!(connectedElectrifier != null))
					{
						continue;
					}
					Debug.Log("Activated" + activationTask.activationConnectionCommand.activatedElectrifiers.Count);
					if (!activationTask.activationConnectionCommand.activatedElectrifiers.Contains(connectedElectrifier))
					{
						connectedElectrifier.SetConnectedActivation(ref activationTask.activationConnectionCommand);
						if (showConnectionBeams && createBeamOnActivation && activationTask.activationConnectionCommand.targetState && connectedElectrifier.showConnectionBeams)
						{
							CreateBeam(connectedElectrifier);
						}
					}
				}
			}
			currentActivationTasks.Remove(activationTask);
		}
		else
		{
			activationTask.remainingDelay -= Time.deltaTime;
		}
	}

	public void CreateBeam(ENV_Electrifier targetElectrifier)
	{
		FX_BeamManager.Beam beam = FX_BeamManager.BeamCreate(default(FX_BeamManager.System));
		FX_BeamManager.BeamApplyShared(beam, connectionBeam);
		FX_BeamManager.BeamLifetime(beam, connectionBeamLifetime);
		FX_BeamManager.BeamPointXForm(FX_BeamManager.BeamPointAdd(beam, default(FX_BeamManager.Surface)), null, GetBeamSourcePosition());
		FX_BeamManager.BeamPointXForm(FX_BeamManager.BeamPointAdd(beam, default(FX_BeamManager.Surface)), null, targetElectrifier.GetBeamTargetPosition());
	}

	public override void DrawGizmos()
	{
		GizmoContext.InSelection(this);
		if (connectedElectrifiers == null || connectedElectrifiers.Count <= 0)
		{
			return;
		}
		foreach (ENV_Electrifier connectedElectrifier in connectedElectrifiers)
		{
			if (connectedElectrifier != null)
			{
				Draw.Arrow(base.transform.position, connectedElectrifier.transform.position, Color.teal);
			}
		}
	}

	public Vector3 GetBeamTargetPosition()
	{
		if (beamTargetPosition != null)
		{
			return beamTargetPosition.position;
		}
		return base.transform.position;
	}

	public Vector3 GetBeamSourcePosition()
	{
		if (beamSourcePosition != null)
		{
			return beamSourcePosition.position;
		}
		return base.transform.position;
	}
}
