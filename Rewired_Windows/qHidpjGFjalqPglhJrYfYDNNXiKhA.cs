using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Data;
using Rewired.Interfaces;

internal class qHidpjGFjalqPglhJrYfYDNNXiKhA : IInputSource, IDisposable
{
	private static ABRAMTFXAHCYdbLHDBkGAYIdpNTtA ARNDeBaUkgpUcNLrTFhNhPeVMVlB;

	private List<GYSwgkbaVYVjtqJQdbyLjufrdwPAA> anSeeGjgdIOLEREDCBblVcUEkhaz;

	private ReadOnlyCollection<GYSwgkbaVYVjtqJQdbyLjufrdwPAA> SUOGuLHhZBxsrJDrHMehijIUsJRf;

	private ConfigVars hAHDgrARKogRjnCnmTYnLxPVOtOaA;

	private readonly bool IQPzxahwVouCiBQUdcHJzGuBTMZt;

	private readonly bool VacqBUEXZVQgXefXIbtSRTQQXpYf;

	private readonly bool LbiziTIjTcNxHpZRSydaCRAqQDhl;

	private bool vYSVpwFHPPviPgnmWclxjollHtocb;

	[CompilerGenerated]
	private Action m_RfCgPbUDfXEUkQopPRWpJseBuVEB;

	private readonly bool BHwnrbtKcRPfxhxeWlDnIjqvfwEI;

	private readonly bool BtXIAtDvxFsOItLTgMYVEoawuKdr;

	private readonly bool UQRoYSClqjQOZVGJCdjIBVkbkNUhb;

	private bool gharTVDOeItZDsbStezJWbSmcNmI;

	private double lczrlgMDHcwtwYkAVOGqLuZcgDGR;

	private int EmlERATFSDfOIcXvKrXViboBhpRKA;

	private bool unEDGQHmpkIFuHfuCmyOKhXCXuny;

	private static readonly string zdRYOdrgxpLDmJLpFIIIsjvwJoEY = "Rewired Windows Gaming Input support is not available on this system.";

	private bool TDHyemRrelfULaQiZlrYbKCRVFpK;

	public IUnifiedKeyboardSource IYUlAHHdOrdATQMjbijocfecvrkP => null;

	public IUnifiedMouseSource ZCzNuxWaZFOsAYYAtIGcjJXYvIyD => null;

	private event Action RfCgPbUDfXEUkQopPRWpJseBuVEB
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_RfCgPbUDfXEUkQopPRWpJseBuVEB;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_RfCgPbUDfXEUkQopPRWpJseBuVEB, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_RfCgPbUDfXEUkQopPRWpJseBuVEB;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_RfCgPbUDfXEUkQopPRWpJseBuVEB, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	event Action IInputSource.DeviceChangedEvent
	{
		add
		{
			RfCgPbUDfXEUkQopPRWpJseBuVEB += value;
		}
		remove
		{
			RfCgPbUDfXEUkQopPRWpJseBuVEB -= value;
		}
	}

	public qHidpjGFjalqPglhJrYfYDNNXiKhA(ConfigVars P_0, bool P_1, bool P_2, bool P_3)
	{
		try
		{
			hAHDgrARKogRjnCnmTYnLxPVOtOaA = P_0;
			IQPzxahwVouCiBQUdcHJzGuBTMZt = P_1;
			VacqBUEXZVQgXefXIbtSRTQQXpYf = P_2;
			LbiziTIjTcNxHpZRSydaCRAqQDhl = P_3;
			if (P_2)
			{
				throw new NotImplementedException("WGI mouse input not implemented.");
			}
			if (P_3)
			{
				throw new NotImplementedException("WGI keyboard input not implemented.");
			}
			try
			{
				if (!udoDNkHycCgefDIWsbDcIfcDLILLB.zZlLOCYfcJXCdvDnxyvWswTWTdid())
				{
					Logger.LogWarning(zdRYOdrgxpLDmJLpFIIIsjvwJoEY + " Requires " + udoDNkHycCgefDIWsbDcIfcDLILLB.DiIPgOQxLrgkwnBgHYxaoPlmRcfn() + " or greater.");
					throw new Exception();
				}
			}
			catch (DllNotFoundException)
			{
				Logger.LogWarning(zdRYOdrgxpLDmJLpFIIIsjvwJoEY + " Either Rewired_WindowsGamingInput.dll is missing or this version of Windows does not meet the minimum version requirements for Windows Gaming Input support.");
				throw;
			}
			catch
			{
				Logger.LogWarning(zdRYOdrgxpLDmJLpFIIIsjvwJoEY);
				throw;
			}
			BHwnrbtKcRPfxhxeWlDnIjqvfwEI = true;
			if (UQRoYSClqjQOZVGJCdjIBVkbkNUhb)
			{
				BtXIAtDvxFsOItLTgMYVEoawuKdr = false;
			}
			if (BHwnrbtKcRPfxhxeWlDnIjqvfwEI)
			{
				ARNDeBaUkgpUcNLrTFhNhPeVMVlB = new ABRAMTFXAHCYdbLHDBkGAYIdpNTtA(uBbFKOvuIwhskYpkXtXkuxAPGaN);
			}
			anSeeGjgdIOLEREDCBblVcUEkhaz = new List<GYSwgkbaVYVjtqJQdbyLjufrdwPAA>();
			SUOGuLHhZBxsrJDrHMehijIUsJRf = new ReadOnlyCollection<GYSwgkbaVYVjtqJQdbyLjufrdwPAA>(anSeeGjgdIOLEREDCBblVcUEkhaz);
			if (BHwnrbtKcRPfxhxeWlDnIjqvfwEI)
			{
				ARNDeBaUkgpUcNLrTFhNhPeVMVlB.bHlGGmsBrHHKJcUGCWcKdobPaFcy += ejXdZfWHiBCaCBoqWOzmBEBmzbQX;
			}
			if (P_1)
			{
				UMUABuuPkthcyiIIGQKJIVYgOSIT(true);
			}
			ReInput.ApplicationFocusChangedEvent += pLNhtvdlmaWYpkkZBFjZpMZOrbjL;
		}
		catch (Exception)
		{
			Dispose();
			throw;
		}
	}

	public void buaArESrHYuVyvPGpGrGBtjGigOOA()
	{
		vYSVpwFHPPviPgnmWclxjollHtocb = false;
		UMUABuuPkthcyiIIGQKJIVYgOSIT(false);
	}

	public bool sQkobKNrzRsrPKnosfduVcivELGdA(PidVid P_0)
	{
		if (BHwnrbtKcRPfxhxeWlDnIjqvfwEI && VgwvWxNdcHfXWFTgEsEQLMdlOXEy.RuNhmcJnbFzucuwBRqwkPhNWEDRl(P_0.vendorId, P_0.productId))
		{
			return true;
		}
		return false;
	}

	public void SystemDeviceDisconnected()
	{
		ejXdZfWHiBCaCBoqWOzmBEBmzbQX();
	}

	void IInputSource.SystemDeviceDisconnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceDisconnected
		this.SystemDeviceDisconnected();
	}

	public void SystemDeviceConnected()
	{
		ejXdZfWHiBCaCBoqWOzmBEBmzbQX();
	}

	void IInputSource.SystemDeviceConnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceConnected
		this.SystemDeviceConnected();
	}

	public void Update()
	{
		if (unEDGQHmpkIFuHfuCmyOKhXCXuny)
		{
			ejXdZfWHiBCaCBoqWOzmBEBmzbQX();
		}
		if (BHwnrbtKcRPfxhxeWlDnIjqvfwEI)
		{
			ARNDeBaUkgpUcNLrTFhNhPeVMVlB.FtbLzmJsYVITlrxtpNKOHNQWbPew();
		}
	}

	void IInputSource.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (IQPzxahwVouCiBQUdcHJzGuBTMZt)
		{
			for (int i = 0; i < anSeeGjgdIOLEREDCBblVcUEkhaz.Count; i++)
			{
				anSeeGjgdIOLEREDCBblVcUEkhaz[i]?.jeGCHlAchlujjoFsrPznrqqtcLZr(updateLoop);
			}
			if (BHwnrbtKcRPfxhxeWlDnIjqvfwEI)
			{
				ARNDeBaUkgpUcNLrTFhNhPeVMVlB.ZeoZBOhhPBdtSIUsVqnbEloTqbivA();
			}
		}
	}

	void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateDevices
		this.UpdateDevices(updateLoop);
	}

	public void UpdateFinished()
	{
		for (int i = 0; i < anSeeGjgdIOLEREDCBblVcUEkhaz.Count; i++)
		{
			anSeeGjgdIOLEREDCBblVcUEkhaz[i]?.vqThqhuVCpSBUcauafwjASjUTjsi();
		}
	}

	void IInputSource.UpdateFinished()
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
		this.UpdateFinished();
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		return SUOGuLHhZBxsrJDrHMehijIUsJRf as IList<T>;
	}

	IList<T> IInputSource.GetJoysticks<T>()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetJoysticks
		return this.GetJoysticks<T>();
	}

	private void UMUABuuPkthcyiIIGQKJIVYgOSIT(bool P_0)
	{
		if (unEDGQHmpkIFuHfuCmyOKhXCXuny)
		{
			unEDGQHmpkIFuHfuCmyOKhXCXuny = false;
		}
		List<GYSwgkbaVYVjtqJQdbyLjufrdwPAA> list = new List<GYSwgkbaVYVjtqJQdbyLjufrdwPAA>();
		int num = 0;
		if (BHwnrbtKcRPfxhxeWlDnIjqvfwEI)
		{
			IList<oWjRNvMCqhpxHRZjgbtVgtKPLuXu> list2 = ARNDeBaUkgpUcNLrTFhNhPeVMVlB.OnemwQvmWWpKnWGcZTHDxCCkLjDe();
			for (int i = 0; i < list2.Count; i++)
			{
				oWjRNvMCqhpxHRZjgbtVgtKPLuXu oWjRNvMCqhpxHRZjgbtVgtKPLuXu2 = list2[i];
				if (oWjRNvMCqhpxHRZjgbtVgtKPLuXu2 != null)
				{
					list.Add(oWjRNvMCqhpxHRZjgbtVgtKPLuXu2);
					num++;
				}
			}
		}
		if (list.Count == 0)
		{
			anSeeGjgdIOLEREDCBblVcUEkhaz.Clear();
			return;
		}
		int count = list.Count;
		int count2 = anSeeGjgdIOLEREDCBblVcUEkhaz.Count;
		GYSwgkbaVYVjtqJQdbyLjufrdwPAA[] array = new GYSwgkbaVYVjtqJQdbyLjufrdwPAA[count];
		for (int j = 0; j < count; j++)
		{
			bool flag = false;
			for (int k = 0; k < count2; k++)
			{
				if (list[j] != null && anSeeGjgdIOLEREDCBblVcUEkhaz[k] != null && list[j].UczRmMphKIjxibxeycGOHPLgBLhWB == anSeeGjgdIOLEREDCBblVcUEkhaz[k].UczRmMphKIjxibxeycGOHPLgBLhWB)
				{
					array[j] = anSeeGjgdIOLEREDCBblVcUEkhaz[k];
					array[j].EgVccKkUrQzJnKdIqlzmsvDbDxwF(list[j]);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				array[j] = list[j];
			}
		}
		anSeeGjgdIOLEREDCBblVcUEkhaz.Clear();
		for (int l = 0; l < count; l++)
		{
			if (array[l] != null)
			{
				anSeeGjgdIOLEREDCBblVcUEkhaz.Add(array[l]);
			}
		}
	}

	private void ejXdZfWHiBCaCBoqWOzmBEBmzbQX()
	{
		if (IQPzxahwVouCiBQUdcHJzGuBTMZt)
		{
			vYSVpwFHPPviPgnmWclxjollHtocb = true;
		}
		if (this.RfCgPbUDfXEUkQopPRWpJseBuVEB != null)
		{
			this.RfCgPbUDfXEUkQopPRWpJseBuVEB();
		}
	}

	private int uBbFKOvuIwhskYpkXtXkuxAPGaN()
	{
		int emlERATFSDfOIcXvKrXViboBhpRKA = EmlERATFSDfOIcXvKrXViboBhpRKA;
		if (EmlERATFSDfOIcXvKrXViboBhpRKA == int.MaxValue)
		{
			EmlERATFSDfOIcXvKrXViboBhpRKA = 0;
			return emlERATFSDfOIcXvKrXViboBhpRKA;
		}
		EmlERATFSDfOIcXvKrXViboBhpRKA++;
		return emlERATFSDfOIcXvKrXViboBhpRKA;
	}

	private void pLNhtvdlmaWYpkkZBFjZpMZOrbjL(bool P_0)
	{
		if (IQPzxahwVouCiBQUdcHJzGuBTMZt && P_0)
		{
			unEDGQHmpkIFuHfuCmyOKhXCXuny = true;
		}
	}

	public void Dispose()
	{
		rPaUmUgzKUeJAAIHJAyhssSfpkDR(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void XNgpDbzImJbEckJApiYyTxUljosjA()
	{
		try
		{
			rPaUmUgzKUeJAAIHJAyhssSfpkDR(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void rPaUmUgzKUeJAAIHJAyhssSfpkDR(bool P_0)
	{
		if (TDHyemRrelfULaQiZlrYbKCRVFpK)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= pLNhtvdlmaWYpkkZBFjZpMZOrbjL;
			if (ARNDeBaUkgpUcNLrTFhNhPeVMVlB != null)
			{
				ARNDeBaUkgpUcNLrTFhNhPeVMVlB.Dispose();
			}
			if (anSeeGjgdIOLEREDCBblVcUEkhaz != null)
			{
				for (int i = 0; i < anSeeGjgdIOLEREDCBblVcUEkhaz.Count; i++)
				{
					if (anSeeGjgdIOLEREDCBblVcUEkhaz[i] != null)
					{
						anSeeGjgdIOLEREDCBblVcUEkhaz[i].Dispose();
					}
				}
			}
		}
		TDHyemRrelfULaQiZlrYbKCRVFpK = true;
	}
}
