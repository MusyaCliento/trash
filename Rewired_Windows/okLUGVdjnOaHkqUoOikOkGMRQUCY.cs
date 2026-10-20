using Rewired.Utils.Classes.Data;

internal class okLUGVdjnOaHkqUoOikOkGMRQUCY : VJJORtyhxtIZFDAvjUdtXgBUbPYD
{
	public int XgjDPkOnnuEliPNibtGqUelQHORw;

	public double UnxAvgcpQDqSVXDsXlKgBnYOeypH;

	public readonly int JrmEBssZrQmlvhgnZhoRNSHxEmAaA;

	public readonly int EsrkysGoWurGGBmWsiVkuKwRPtWh;

	public readonly bool XhxZlxAmjboeHYUbJLUTVLlSMXke;

	public readonly int nKSLCgktxkuCkHGcmPRPUnyofELi;

	public readonly int oruObpetSikAudsGFOTMcsuucbaW;

	public readonly int qdRClMbcCaddRMtyiKAgVslhTiRRA;

	public okLUGVdjnOaHkqUoOikOkGMRQUCY(byte P_0, HIDInfo P_1, bool P_2, int P_3)
		: base(P_0, P_1)
	{
		JrmEBssZrQmlvhgnZhoRNSHxEmAaA = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		EsrkysGoWurGGBmWsiVkuKwRPtWh = P_1.dataIndex;
		XhxZlxAmjboeHYUbJLUTVLlSMXke = P_2;
		nKSLCgktxkuCkHGcmPRPUnyofELi = P_1.logicalMin;
		oruObpetSikAudsGFOTMcsuucbaW = P_1.logicalMax;
		qdRClMbcCaddRMtyiKAgVslhTiRRA = P_3;
	}

	public virtual void agnUsURsyUXIGejABAhDNaEDnHNh(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != vKgAOBqhKKHeEXCKnijETKCeeaEg)
		{
			return;
		}
		UnxAvgcpQDqSVXDsXlKgBnYOeypH = P_1;
		int num = 0;
		if (JrmEBssZrQmlvhgnZhoRNSHxEmAaA > 1)
		{
			for (int i = 0; i < JrmEBssZrQmlvhgnZhoRNSHxEmAaA; i++)
			{
				num |= P_0[EsrkysGoWurGGBmWsiVkuKwRPtWh + i] << 8 * i;
			}
		}
		else
		{
			num = P_0[EsrkysGoWurGGBmWsiVkuKwRPtWh];
		}
		XgjDPkOnnuEliPNibtGqUelQHORw = num;
	}
}
