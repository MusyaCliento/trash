using System.Collections.Generic;
using UnityEngine;

public class ENV_Electrifier_System : MonoBehaviour
{
	public class ElectrifierConnection
	{
		public (ENV_Electrifier a, ENV_Electrifier b) electrifiers;

		public (FX_BeamManager.BeamPoint a, FX_BeamManager.BeamPoint b) beamPoints;

		public bool hasActiveBeam;

		public FX_BeamManager.Beam activeBeam;
	}

	public List<ENV_Electrifier> electrifiers;

	public FX_BeamShared electrifierBeam;

	public List<ElectrifierConnection> connections = new List<ElectrifierConnection>();

	public Dictionary<(ENV_Electrifier a, ENV_Electrifier b), ElectrifierConnection> electrifierConnectionDict = new Dictionary<(ENV_Electrifier, ENV_Electrifier), ElectrifierConnection>();

	private void Start()
	{
		GenerateConnections();
	}

	private void Update()
	{
		foreach (ElectrifierConnection connection in connections)
		{
			if (connection.electrifiers.a.active && connection.electrifiers.b.active)
			{
				if (!connection.hasActiveBeam)
				{
					if (connection.electrifiers.a.showConnectionBeams && connection.electrifiers.b.showConnectionBeams)
					{
						GenerateBeam(connection);
					}
					connection.hasActiveBeam = true;
				}
			}
			else if (connection.hasActiveBeam)
			{
				if (connection.electrifiers.a.showConnectionBeams && connection.electrifiers.b.showConnectionBeams)
				{
					FX_BeamManager.BeamDestroy(connection.activeBeam);
				}
				connection.hasActiveBeam = false;
			}
		}
	}

	private void GenerateBeam(ElectrifierConnection connection)
	{
		connection.activeBeam = FX_BeamManager.BeamCreate(default(FX_BeamManager.System));
		FX_BeamManager.BeamApplyShared(connection.activeBeam, electrifierBeam);
		connection.beamPoints.a = FX_BeamManager.BeamPointAdd(connection.activeBeam, default(FX_BeamManager.Surface));
		FX_BeamManager.BeamPointXForm(connection.beamPoints.a, connection.electrifiers.a.transform, connection.electrifiers.a.GetBeamTargetPosition());
		connection.beamPoints.b = FX_BeamManager.BeamPointAdd(connection.activeBeam, default(FX_BeamManager.Surface));
		FX_BeamManager.BeamPointXForm(connection.beamPoints.b, connection.electrifiers.b.transform, connection.electrifiers.b.GetBeamTargetPosition());
	}

	public void GenerateConnections()
	{
		connections.Clear();
		electrifierConnectionDict.Clear();
		foreach (ENV_Electrifier electrifier in electrifiers)
		{
			foreach (ENV_Electrifier connectedElectrifier in electrifier.connectedElectrifiers)
			{
				if (!electrifierConnectionDict.ContainsKey((electrifier, connectedElectrifier)) && !electrifierConnectionDict.ContainsKey((connectedElectrifier, electrifier)))
				{
					ElectrifierConnection electrifierConnection = new ElectrifierConnection
					{
						electrifiers = (a: electrifier, b: connectedElectrifier)
					};
					if (electrifier.showConnectionBeams && connectedElectrifier.showConnectionBeams)
					{
						electrifierConnectionDict.Add((electrifier, connectedElectrifier), electrifierConnection);
						connections.Add(electrifierConnection);
					}
				}
			}
		}
	}
}
