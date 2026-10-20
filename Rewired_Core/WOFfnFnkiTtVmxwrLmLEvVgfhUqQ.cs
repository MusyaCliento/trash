using System;
using System.Runtime.CompilerServices;
using Rewired;

internal struct WOFfnFnkiTtVmxwrLmLEvVgfhUqQ : IEquatable<WOFfnFnkiTtVmxwrLmLEvVgfhUqQ>
{
	public KeyboardKeyCode upSMfgVdUsKlaZxdQuEFOeQzyAKO;

	public ModifierKey vSznVpsQIzlXURpiGMRGPcJUIuzA;

	public ModifierKey zVXlDcsdNOLDiLqjyVfXVxxujspv;

	public ModifierKey rTimOFWjjKWHOSmCwWhaXFWPyzYP;

	public WOFfnFnkiTtVmxwrLmLEvVgfhUqQ(KeyboardKeyCode P_0, ModifierKey P_1, ModifierKey P_2, ModifierKey P_3)
	{
		upSMfgVdUsKlaZxdQuEFOeQzyAKO = P_0;
		vSznVpsQIzlXURpiGMRGPcJUIuzA = P_1;
		zVXlDcsdNOLDiLqjyVfXVxxujspv = P_2;
		rTimOFWjjKWHOSmCwWhaXFWPyzYP = P_3;
	}

	public void ANHLDgGKiODrVEPpRFbOpEmkuzJbA()
	{
		if (upSMfgVdUsKlaZxdQuEFOeQzyAKO != KeyboardKeyCode.None)
		{
			upSMfgVdUsKlaZxdQuEFOeQzyAKO = KeyboardKeyCode.None;
		}
		if (vSznVpsQIzlXURpiGMRGPcJUIuzA != ModifierKey.None)
		{
			vSznVpsQIzlXURpiGMRGPcJUIuzA = ModifierKey.None;
		}
		if (zVXlDcsdNOLDiLqjyVfXVxxujspv != ModifierKey.None)
		{
			zVXlDcsdNOLDiLqjyVfXVxxujspv = ModifierKey.None;
		}
		if (rTimOFWjjKWHOSmCwWhaXFWPyzYP != ModifierKey.None)
		{
			rTimOFWjjKWHOSmCwWhaXFWPyzYP = ModifierKey.None;
		}
	}

	public bool Equals(WOFfnFnkiTtVmxwrLmLEvVgfhUqQ other)
	{
		if (upSMfgVdUsKlaZxdQuEFOeQzyAKO == other.upSMfgVdUsKlaZxdQuEFOeQzyAKO && vSznVpsQIzlXURpiGMRGPcJUIuzA == other.vSznVpsQIzlXURpiGMRGPcJUIuzA && zVXlDcsdNOLDiLqjyVfXVxxujspv == other.zVXlDcsdNOLDiLqjyVfXVxxujspv)
		{
			return rTimOFWjjKWHOSmCwWhaXFWPyzYP == other.rTimOFWjjKWHOSmCwWhaXFWPyzYP;
		}
		return false;
	}

	bool IEquatable<WOFfnFnkiTtVmxwrLmLEvVgfhUqQ>.Equals(WOFfnFnkiTtVmxwrLmLEvVgfhUqQ other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool LhJpemNlSERpAxAQtTOuVNRNkiQN(object P_0)
	{
		if (P_0 == null || !(P_0 is WOFfnFnkiTtVmxwrLmLEvVgfhUqQ))
		{
			return false;
		}
		return Equals((WOFfnFnkiTtVmxwrLmLEvVgfhUqQ)P_0);
	}

	public int MHvyIlHbobleMpFOIqvPkrHpJaHt()
	{
		return (((17 * 29 + upSMfgVdUsKlaZxdQuEFOeQzyAKO.GetHashCode()) * 29 + vSznVpsQIzlXURpiGMRGPcJUIuzA.GetHashCode()) * 29 + zVXlDcsdNOLDiLqjyVfXVxxujspv.GetHashCode()) * 29 + rTimOFWjjKWHOSmCwWhaXFWPyzYP.GetHashCode();
	}

	[SpecialName]
	public static bool CGFmXOxDoSdrwFUCUDvBKYdVehbD(WOFfnFnkiTtVmxwrLmLEvVgfhUqQ P_0, WOFfnFnkiTtVmxwrLmLEvVgfhUqQ P_1)
	{
		if (P_0.upSMfgVdUsKlaZxdQuEFOeQzyAKO == P_1.upSMfgVdUsKlaZxdQuEFOeQzyAKO && P_0.vSznVpsQIzlXURpiGMRGPcJUIuzA == P_1.vSznVpsQIzlXURpiGMRGPcJUIuzA && P_0.zVXlDcsdNOLDiLqjyVfXVxxujspv == P_1.zVXlDcsdNOLDiLqjyVfXVxxujspv)
		{
			return P_0.rTimOFWjjKWHOSmCwWhaXFWPyzYP == P_1.rTimOFWjjKWHOSmCwWhaXFWPyzYP;
		}
		return false;
	}

	[SpecialName]
	public static bool KprAnzhAVfduZvKjlXVEfYxZXGVAA(WOFfnFnkiTtVmxwrLmLEvVgfhUqQ P_0, WOFfnFnkiTtVmxwrLmLEvVgfhUqQ P_1)
	{
		return !CGFmXOxDoSdrwFUCUDvBKYdVehbD(P_0, P_1);
	}
}
