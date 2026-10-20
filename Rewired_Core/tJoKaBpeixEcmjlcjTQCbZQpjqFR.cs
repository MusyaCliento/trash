using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class tJoKaBpeixEcmjlcjTQCbZQpjqFR
{
	private class nRNkTxeFvHSawwEGHgmldkndpvmU
	{
		public readonly InputAction tJWdeGEOMlDTlTzCQWThsqaVrxfmA;

		public readonly int mixwtpqdasfjZAnhyaDLZvPgLjaUA;

		public readonly int rktYIshMzUaJKKNQYTjEJmlmdwYFA;

		public nRNkTxeFvHSawwEGHgmldkndpvmU(InputAction P_0, int P_1)
		{
			tJWdeGEOMlDTlTzCQWThsqaVrxfmA = P_0;
			mixwtpqdasfjZAnhyaDLZvPgLjaUA = P_0.id;
			rktYIshMzUaJKKNQYTjEJmlmdwYFA = P_1;
		}
	}

	private InputAction[] ZRZyunWSqRgRvpWxZEHuLwXBFIpQ;

	private ADictionary<string, nRNkTxeFvHSawwEGHgmldkndpvmU> ytAEXwiAbDotPFDBgZauDgAsSDzNA;

	private nRNkTxeFvHSawwEGHgmldkndpvmU[] HovSvVPKXPqCegofGDuLwXeBIqkQ;

	private ReadOnlyCollection<InputAction> FPXfVEghGSAXGXMlhvJvOarxiVtiA;

	private int TYGRuqSWuRORCAjVhAaiAzQJngPi;

	private int kmXAXQdQqEkHzciAgZqsIbMSevdQ;

	private List<string> PTBszvsCDCalvGgBuesvVZYTpbLHA;

	private List<int> sjvZCSGeXFqqNNJSByGvqBhpcett;

	public IList<InputAction> ESPPucyzYlkSLFFzkQAwnJrIKGUm => FPXfVEghGSAXGXMlhvJvOarxiVtiA;

	public int WnFeyUIrIriYEMOToHgDIInXSDkM => TYGRuqSWuRORCAjVhAaiAzQJngPi;

	public int RPEdjbfyfPTpgjWtQupiJpegXCdV => kmXAXQdQqEkHzciAgZqsIbMSevdQ;

	public tJoKaBpeixEcmjlcjTQCbZQpjqFR(List<InputAction> P_0)
	{
		PTBszvsCDCalvGgBuesvVZYTpbLHA = new List<string>();
		sjvZCSGeXFqqNNJSByGvqBhpcett = new List<int>();
		ZRZyunWSqRgRvpWxZEHuLwXBFIpQ = P_0.ToArray();
		TYGRuqSWuRORCAjVhAaiAzQJngPi = ZRZyunWSqRgRvpWxZEHuLwXBFIpQ.Length;
		int num = -1;
		for (int i = 0; i < TYGRuqSWuRORCAjVhAaiAzQJngPi; i++)
		{
			int id = ZRZyunWSqRgRvpWxZEHuLwXBFIpQ[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		kmXAXQdQqEkHzciAgZqsIbMSevdQ = num;
		HovSvVPKXPqCegofGDuLwXeBIqkQ = new nRNkTxeFvHSawwEGHgmldkndpvmU[num + 1];
		for (int j = 0; j < TYGRuqSWuRORCAjVhAaiAzQJngPi; j++)
		{
			InputAction inputAction = ZRZyunWSqRgRvpWxZEHuLwXBFIpQ[j];
			HovSvVPKXPqCegofGDuLwXeBIqkQ[inputAction.id] = new nRNkTxeFvHSawwEGHgmldkndpvmU(inputAction, j);
		}
		ytAEXwiAbDotPFDBgZauDgAsSDzNA = new ADictionary<string, nRNkTxeFvHSawwEGHgmldkndpvmU>(TYGRuqSWuRORCAjVhAaiAzQJngPi, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < TYGRuqSWuRORCAjVhAaiAzQJngPi; k++)
		{
			InputAction inputAction2 = ZRZyunWSqRgRvpWxZEHuLwXBFIpQ[k];
			try
			{
				ytAEXwiAbDotPFDBgZauDgAsSDzNA.Add(inputAction2.name, HovSvVPKXPqCegofGDuLwXeBIqkQ[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		FPXfVEghGSAXGXMlhvJvOarxiVtiA = new ReadOnlyCollection<InputAction>(ZRZyunWSqRgRvpWxZEHuLwXBFIpQ);
	}

	public InputAction vMoFsVlrywxRswyFZUiwaCMiXuhJ(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!ytAEXwiAbDotPFDBgZauDgAsSDzNA.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				qyeiREGCnIfgiPGPDVhzBoWndyweA(P_0);
			}
			return null;
		}
		return value.tJWdeGEOMlDTlTzCQWThsqaVrxfmA;
	}

	public InputAction ZLbGDLzyWJoHSYYbHtqdaDwdeCFo(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > kmXAXQdQqEkHzciAgZqsIbMSevdQ)
		{
			return null;
		}
		if (HovSvVPKXPqCegofGDuLwXeBIqkQ[P_0] == null)
		{
			return null;
		}
		return HovSvVPKXPqCegofGDuLwXeBIqkQ[P_0].tJWdeGEOMlDTlTzCQWThsqaVrxfmA;
	}

	public InputAction TftdlthJgOgjdQtIjvcGvMqKVXpP(int P_0)
	{
		if (P_0 < 0 || P_0 >= TYGRuqSWuRORCAjVhAaiAzQJngPi)
		{
			return null;
		}
		return ZRZyunWSqRgRvpWxZEHuLwXBFIpQ[P_0];
	}

	public int dguDgqFQMSFVkESJOObLZIzdEYyzA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!ytAEXwiAbDotPFDBgZauDgAsSDzNA.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				qyeiREGCnIfgiPGPDVhzBoWndyweA(P_0);
			}
			return -1;
		}
		return value.rktYIshMzUaJKKNQYTjEJmlmdwYFA;
	}

	public int gwGPJXsVmpnHcrNmpYDODSJzdJJn(int P_0, bool P_1 = false)
	{
		if (P_0 < 0 || P_0 > kmXAXQdQqEkHzciAgZqsIbMSevdQ)
		{
			if (P_0 >= 0 && P_1)
			{
				nYFdYNhylLixhIgnCHIHOjRCeZKc(P_0);
			}
			return -1;
		}
		nRNkTxeFvHSawwEGHgmldkndpvmU nRNkTxeFvHSawwEGHgmldkndpvmU2 = HovSvVPKXPqCegofGDuLwXeBIqkQ[P_0];
		if (nRNkTxeFvHSawwEGHgmldkndpvmU2 == null)
		{
			if (P_1)
			{
				nYFdYNhylLixhIgnCHIHOjRCeZKc(P_0);
			}
			return -1;
		}
		return nRNkTxeFvHSawwEGHgmldkndpvmU2.rktYIshMzUaJKKNQYTjEJmlmdwYFA;
	}

	public bool BtUKDhGEQwQIVDBzidaRAaNSBiWB(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!ytAEXwiAbDotPFDBgZauDgAsSDzNA.ContainsKey(P_0))
		{
			if (P_1)
			{
				qyeiREGCnIfgiPGPDVhzBoWndyweA(P_0);
			}
			return false;
		}
		return true;
	}

	public bool voSbbuSAGHbopVjEStCZNQlxUFNC(int P_0)
	{
		if (P_0 < 0 || P_0 > kmXAXQdQqEkHzciAgZqsIbMSevdQ)
		{
			return false;
		}
		return HovSvVPKXPqCegofGDuLwXeBIqkQ[P_0] != null;
	}

	public int EztnLVitSeSeSlWCFMTQNjrSGAec(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!ytAEXwiAbDotPFDBgZauDgAsSDzNA.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				qyeiREGCnIfgiPGPDVhzBoWndyweA(P_0);
			}
			return -1;
		}
		return value.mixwtpqdasfjZAnhyaDLZvPgLjaUA;
	}

	private void qyeiREGCnIfgiPGPDVhzBoWndyweA(string P_0)
	{
		if (!PTBszvsCDCalvGgBuesvVZYTpbLHA.Contains(P_0))
		{
			PTBszvsCDCalvGgBuesvVZYTpbLHA.Add(P_0);
			Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
		}
	}

	private void nYFdYNhylLixhIgnCHIHOjRCeZKc(int P_0)
	{
		if (!sjvZCSGeXFqqNNJSByGvqBhpcett.Contains(P_0))
		{
			sjvZCSGeXFqqNNJSByGvqBhpcett.Add(P_0);
			Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
		}
	}
}
