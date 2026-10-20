using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal static class VpydvvgAmkTUcjFPOCjeqVyqydEE
{
	private const bool VjDjXwFNfXNZwrDmfjxptExjFxeP = false;

	private static int iJjcepknvFWtXrXTDaGHHWCEcnPGB;

	private static ThreadHelper dbCeESsFseJabEhntKlIEHFuQHoM;

	private static ThreadHelper ToyuXcJLkxrJNdGkKqJBOyJbkdKf;

	public static int FouUkwuOnOhmqjkVSnyhOgtAiHCbA => iJjcepknvFWtXrXTDaGHHWCEcnPGB;

	public static ThreadHelper qHssteSLebTuuLaEVEHsdsskEpkPA => dbCeESsFseJabEhntKlIEHFuQHoM;

	public static ThreadHelper TzVGRtiJxyQZUmPydxVTsVNVehmD => ToyuXcJLkxrJNdGkKqJBOyJbkdKf;

	public static ThreadHelper hnQVuLpGsuJSzHbTZzTrIVUjPmfM => dbCeESsFseJabEhntKlIEHFuQHoM;

	public static ThreadHelper ehOnSWgRdmIwRYhdEneGjxefKKyo => ToyuXcJLkxrJNdGkKqJBOyJbkdKf;

	public static ThreadHelper UFsKTTbypApMYXXMIGSKmyqjWZSi => dbCeESsFseJabEhntKlIEHFuQHoM;

	public static ThreadHelper NEVPpBpyDDNvIyuxBuXxBKYziFus => dbCeESsFseJabEhntKlIEHFuQHoM;

	public static bool ouXdrNgYbpcqjYXNFFqZLvcJuILS
	{
		get
		{
			if (dbCeESsFseJabEhntKlIEHFuQHoM != null)
			{
				return dbCeESsFseJabEhntKlIEHFuQHoM.isRunning;
			}
			return false;
		}
	}

	public static void AQkHUHjpPPBQCDvHBizLHvPUSPqGA(bool P_0)
	{
		iJjcepknvFWtXrXTDaGHHWCEcnPGB = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (dbCeESsFseJabEhntKlIEHFuQHoM != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		dbCeESsFseJabEhntKlIEHFuQHoM = ThreadHelper.CreateFixedTimeStep(iJjcepknvFWtXrXTDaGHHWCEcnPGB);
		dbCeESsFseJabEhntKlIEHFuQHoM.Start(wait: true);
		if (P_0)
		{
			ToyuXcJLkxrJNdGkKqJBOyJbkdKf = ThreadHelper.CreateFixedTimeStep(100);
			ToyuXcJLkxrJNdGkKqJBOyJbkdKf.Start(wait: true);
		}
		ReInput.UpdateStartedEvent += ngdZTFOgJaZMqFdjNytaSsBPMnwp;
	}

	private static void ngdZTFOgJaZMqFdjNytaSsBPMnwp(UpdateLoopType P_0)
	{
		if (P_0 == UpdateLoopType.Update)
		{
			int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
			if (iJjcepknvFWtXrXTDaGHHWCEcnPGB != platformVar_joystickRefreshRate)
			{
				iJjcepknvFWtXrXTDaGHHWCEcnPGB = platformVar_joystickRefreshRate;
				dbCeESsFseJabEhntKlIEHFuQHoM.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			}
		}
	}

	public static void endZyayddGujVRbbIrpfJSPrqGio()
	{
		ReInput.UpdateStartedEvent -= ngdZTFOgJaZMqFdjNytaSsBPMnwp;
		if (dbCeESsFseJabEhntKlIEHFuQHoM != null)
		{
			dbCeESsFseJabEhntKlIEHFuQHoM.WaitForActionQueueToFinish();
			dbCeESsFseJabEhntKlIEHFuQHoM.Dispose();
			dbCeESsFseJabEhntKlIEHFuQHoM = null;
		}
		if (ToyuXcJLkxrJNdGkKqJBOyJbkdKf != null)
		{
			ToyuXcJLkxrJNdGkKqJBOyJbkdKf.WaitForActionQueueToFinish();
			ToyuXcJLkxrJNdGkKqJBOyJbkdKf.Dispose();
			ToyuXcJLkxrJNdGkKqJBOyJbkdKf = null;
		}
	}
}
