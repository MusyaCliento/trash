using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class qnqzZLZhakeRwCCuCZvuuXAZJOrN : IDisposable
{
	public delegate void iLNLNReMKNBijekNFKldqoxJAabZ(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private const int RodMiztnYsTFzGMCqFbkwPQollbq = 512;

	private const int rFZmWFoaRhXcAfrJPctdPxOCFymhA = 250;

	private readonly iLNLNReMKNBijekNFKldqoxJAabZ kwtjcdchYdCNyGhpWoHvtQsLfwrDb;

	private readonly oXhUBdScogwrDwEwyyfvbQcRuDUt aofYLtnGLMBEMnfEeiipIVqZbGzfA;

	private readonly ThreadHelper LNzfRNdoSsYJNgnQXbTqCyuOMQac;

	private readonly int nfAFHwUkDBJhRjIjwtBGmwJGgezv;

	private readonly int QkbEoFzxKWsjujnZMqGtmkJmOBbB;

	private readonly string JEUZuPAZHbASdhVkTphvIFWremlQ;

	private readonly byte[] JgSyiJhiSnbcEPWxnHuJklXvDbCk;

	private readonly byte[] eVFGQyHhJnMkxQTHEDDovmQVsKbbA;

	private int KXOatXQiDDyNOYZpmoYjIpVYuNcI;

	private NtFLRVDnENYMXbtywMQbIfXwjuwG TAzJVtzuLRxlNRgxFhnOVxjYnxip;

	private NtFLRVDnENYMXbtywMQbIfXwjuwG kAbkLwaheZhUWDxYTxYNLpMQiJLPA;

	private bool IRVRJHhKiHMRfaLiiBXbmIpPGQrH;

	public qnqzZLZhakeRwCCuCZvuuXAZJOrN(string P_0, int P_1, string P_2, iLNLNReMKNBijekNFKldqoxJAabZ P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		QkbEoFzxKWsjujnZMqGtmkJmOBbB = P_1;
		if (QkbEoFzxKWsjujnZMqGtmkJmOBbB <= 0)
		{
			QkbEoFzxKWsjujnZMqGtmkJmOBbB = 512;
		}
		nfAFHwUkDBJhRjIjwtBGmwJGgezv = P_1 + 8;
		JEUZuPAZHbASdhVkTphvIFWremlQ = P_2;
		kwtjcdchYdCNyGhpWoHvtQsLfwrDb = P_3;
		int num = nfAFHwUkDBJhRjIjwtBGmwJGgezv * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + P_2 + "\" will not function.");
			throw new Exception();
		}
		try
		{
			aofYLtnGLMBEMnfEeiipIVqZbGzfA = new oXhUBdScogwrDwEwyyfvbQcRuDUt(P_0, P_1, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			TAzJVtzuLRxlNRgxFhnOVxjYnxip = new NtFLRVDnENYMXbtywMQbIfXwjuwG(num);
			kAbkLwaheZhUWDxYTxYNLpMQiJLPA = new NtFLRVDnENYMXbtywMQbIfXwjuwG(num);
			JgSyiJhiSnbcEPWxnHuJklXvDbCk = new byte[nfAFHwUkDBJhRjIjwtBGmwJGgezv];
			eVFGQyHhJnMkxQTHEDDovmQVsKbbA = new byte[nfAFHwUkDBJhRjIjwtBGmwJGgezv];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			LNzfRNdoSsYJNgnQXbTqCyuOMQac = ThreadHelper.Create();
			LNzfRNdoSsYJNgnQXbTqCyuOMQac.ThreadUpdateEvent += prtDrSGXQyEMsDRXQOptFsdbhjKnb;
			LNzfRNdoSsYJNgnQXbTqCyuOMQac.Start(wait: false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + P_2 + "\" will not function.");
			throw;
		}
	}

	public unsafe void eSrxUCulwIOOuuWhIPcNSXNYJgEl()
	{
		try
		{
			if (kJvWUNLYMrUESfeQqjYilKSodmGT())
			{
				return;
			}
			IAwKwMLrTABEzXHDKbvKGAFgAbwgb();
			int num = 0;
			byte[] jgSyiJhiSnbcEPWxnHuJklXvDbCk = JgSyiJhiSnbcEPWxnHuJklXvDbCk;
			fixed (byte* ptr = jgSyiJhiSnbcEPWxnHuJklXvDbCk)
			{
				while (TAzJVtzuLRxlNRgxFhnOVxjYnxip.qjVodHYpJRiskeBlUtqNAmgUjzZR(jgSyiJhiSnbcEPWxnHuJklXvDbCk, nfAFHwUkDBJhRjIjwtBGmwJGgezv) > 0)
				{
					kwtjcdchYdCNyGhpWoHvtQsLfwrDb((IntPtr)ptr, QkbEoFzxKWsjujnZMqGtmkJmOBbB, 1, *(double*)(ptr + QkbEoFzxKWsjujnZMqGtmkJmOBbB));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void IAwKwMLrTABEzXHDKbvKGAFgAbwgb()
	{
		lock (TAzJVtzuLRxlNRgxFhnOVxjYnxip)
		{
			lock (kAbkLwaheZhUWDxYTxYNLpMQiJLPA)
			{
				MiscTools.Swap(ref TAzJVtzuLRxlNRgxFhnOVxjYnxip, ref kAbkLwaheZhUWDxYTxYNLpMQiJLPA);
			}
		}
	}

	private void prtDrSGXQyEMsDRXQOptFsdbhjKnb()
	{
		if (KXOatXQiDDyNOYZpmoYjIpVYuNcI != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] array = eVFGQyHhJnMkxQTHEDDovmQVsKbbA;
			if (!qeujhwjKmDLcPfMuwKdTgACksuSWb(array))
			{
				return;
			}
			lock (kAbkLwaheZhUWDxYTxYNLpMQiJLPA)
			{
				kAbkLwaheZhUWDxYTxYNLpMQiJLPA.njZihpIlvDquKjaAfjaaBkPTSiSVA(array, array.Length);
			}
		}
		catch
		{
		}
	}

	private bool qeujhwjKmDLcPfMuwKdTgACksuSWb(byte[] P_0)
	{
		switch (aofYLtnGLMBEMnfEeiipIVqZbGzfA.FEHkrtOoqutsJzLxemZHmNyMDlWO(P_0))
		{
		case oXhUBdScogwrDwEwyyfvbQcRuDUt.VfGDlJqfZHFaHSivGsQQqsGfgDfu.Success:
			return true;
		case oXhUBdScogwrDwEwyyfvbQcRuDUt.VfGDlJqfZHFaHSivGsQQqsGfgDfu.Error:
			Thread.Sleep(500);
			break;
		case oXhUBdScogwrDwEwyyfvbQcRuDUt.VfGDlJqfZHFaHSivGsQQqsGfgDfu.CriticalError:
			KXOatXQiDDyNOYZpmoYjIpVYuNcI = 1;
			break;
		}
		return false;
	}

	private bool kJvWUNLYMrUESfeQqjYilKSodmGT()
	{
		if (KXOatXQiDDyNOYZpmoYjIpVYuNcI != 0)
		{
			if (KXOatXQiDDyNOYZpmoYjIpVYuNcI == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + JEUZuPAZHbASdhVkTphvIFWremlQ + "\" will not function.");
				KXOatXQiDDyNOYZpmoYjIpVYuNcI = 2;
				try
				{
					LNzfRNdoSsYJNgnQXbTqCyuOMQac.Stop(wait: false);
				}
				catch
				{
				}
			}
			return true;
		}
		return false;
	}

	public void Dispose()
	{
		NeRoVEFjRtAOshFbPMRyCMkYuqKRA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void ABonHJDmfZvPlLZeOOISlKqgPWVm()
	{
		try
		{
			NeRoVEFjRtAOshFbPMRyCMkYuqKRA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void NeRoVEFjRtAOshFbPMRyCMkYuqKRA(bool P_0)
	{
		if (IRVRJHhKiHMRfaLiiBXbmIpPGQrH)
		{
			return;
		}
		if (P_0)
		{
			if (LNzfRNdoSsYJNgnQXbTqCyuOMQac != null)
			{
				LNzfRNdoSsYJNgnQXbTqCyuOMQac.Dispose();
			}
			if (aofYLtnGLMBEMnfEeiipIVqZbGzfA != null)
			{
				aofYLtnGLMBEMnfEeiipIVqZbGzfA.Dispose();
			}
		}
		IRVRJHhKiHMRfaLiiBXbmIpPGQrH = true;
	}
}
