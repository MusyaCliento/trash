using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;

internal sealed class vAozFiksHjVahBCkGkhFXvKKLJmo : IElementIdentifierTool
{
	private GUIText bXlntsuRerMpRDRKAgVvjPwhYmOh;

	private string imCuxEWtDTeCGmPfauEJpiAwBhCU;

	private int bmFuSwMPPzAnyEYKoBDRXjYIabpab;

	private CAMKjWWITLmVKNQaIYUpYBAnWcXD BDjnbkhvpUQPALdSWaTltuyffSYBA;

	private VANUTLsVUcepnrrsTIUZlnrrdggd XmgyPRdTTGFIkldvJmBJCxFlDQYc;

	private Guid ZHuCSGrYaFjqYhlDyiNGWGhrmfls;

	private IList<VANUTLsVUcepnrrsTIUZlnrrdggd> UQOMGoDVCHfmEcdZcsItgxnHVzkB;

	private bool AOiRyjsQGiHItbBYWuxCMXqLDHTk;

	private bool GpagTkROcsDcfdJrBebQhfDPomjP;

	private bool SbhOLmDFmLPYZCcymCIyYuQWEvjm;

	private string[] SbwgfbKVIgksTyATGCQyhAGntRyiA;

	private int[] fvPMvcJkoMjBdKWylFXHoCCHkJXGb;

	public void Initialize(GUIText text)
	{
		bXlntsuRerMpRDRKAgVvjPwhYmOh = text;
		SbwgfbKVIgksTyATGCQyhAGntRyiA = Enum.GetNames(typeof(RawInputAxis));
		fvPMvcJkoMjBdKWylFXHoCCHkJXGb = (int[])Enum.GetValues(typeof(RawInputAxis));
	}

	void IElementIdentifierTool.Initialize(GUIText text)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Initialize
		this.Initialize(text);
	}

	public void Start()
	{
		if (ReInput.isEditor && ReInput.editorPlatform != EditorPlatform.Windows)
		{
			Logger.LogError("Raw Input cannot be run on this platform. You must be running the editor in Windows.");
			return;
		}
		if (ReInput.currentPlatform != Platform.Windows)
		{
			Logger.LogError("Raw Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
			return;
		}
		BDjnbkhvpUQPALdSWaTltuyffSYBA = ReInput.primaryInputManager.inputSource as CAMKjWWITLmVKNQaIYUpYBAnWcXD;
		if (BDjnbkhvpUQPALdSWaTltuyffSYBA == null)
		{
			Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += ONhHdABGfvClDiFlrmzSsKdRubKuA;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += ZfnVfcqrHDVDmMvPbMAPnKvLiatR;
		hncILjqHxZJyrchQVHlEPJcexhhQ();
		SbhOLmDFmLPYZCcymCIyYuQWEvjm = true;
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!SbhOLmDFmLPYZCcymCIyYuQWEvjm)
		{
			return;
		}
		imCuxEWtDTeCGmPfauEJpiAwBhCU = "Raw Input Joystick Element Identifier\n\n";
		bXlntsuRerMpRDRKAgVvjPwhYmOh.text = imCuxEWtDTeCGmPfauEJpiAwBhCU;
		int num = bmFuSwMPPzAnyEYKoBDRXjYIabpab;
		Guid zHuCSGrYaFjqYhlDyiNGWGhrmfls = ZHuCSGrYaFjqYhlDyiNGWGhrmfls;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.KeypadPlus))
		{
			bmFuSwMPPzAnyEYKoBDRXjYIabpab++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.Minus))
		{
			bmFuSwMPPzAnyEYKoBDRXjYIabpab--;
		}
		if (GpagTkROcsDcfdJrBebQhfDPomjP)
		{
			hncILjqHxZJyrchQVHlEPJcexhhQ();
			GpagTkROcsDcfdJrBebQhfDPomjP = false;
		}
		int num2 = ((UQOMGoDVCHfmEcdZcsItgxnHVzkB != null) ? UQOMGoDVCHfmEcdZcsItgxnHVzkB.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (bmFuSwMPPzAnyEYKoBDRXjYIabpab < 0)
		{
			bmFuSwMPPzAnyEYKoBDRXjYIabpab = num2 - 1;
		}
		else if (bmFuSwMPPzAnyEYKoBDRXjYIabpab >= num2)
		{
			bmFuSwMPPzAnyEYKoBDRXjYIabpab = 0;
		}
		ZHuCSGrYaFjqYhlDyiNGWGhrmfls = UQOMGoDVCHfmEcdZcsItgxnHVzkB[bmFuSwMPPzAnyEYKoBDRXjYIabpab].cJZeqceByQzQXVQhxbGYpsxUkUdnA;
		bool flag = false;
		if (num != bmFuSwMPPzAnyEYKoBDRXjYIabpab || zHuCSGrYaFjqYhlDyiNGWGhrmfls != ZHuCSGrYaFjqYhlDyiNGWGhrmfls)
		{
			flag = true;
		}
		if (XmgyPRdTTGFIkldvJmBJCxFlDQYc == null || flag)
		{
			if (XmgyPRdTTGFIkldvJmBJCxFlDQYc != null)
			{
				XmgyPRdTTGFIkldvJmBJCxFlDQYc.AKMehlDMgtqaPNuADIJLcXEPnOcRA();
			}
			XmgyPRdTTGFIkldvJmBJCxFlDQYc = UQOMGoDVCHfmEcdZcsItgxnHVzkB[bmFuSwMPPzAnyEYKoBDRXjYIabpab];
			if (XmgyPRdTTGFIkldvJmBJCxFlDQYc == null)
			{
				return;
			}
			XmgyPRdTTGFIkldvJmBJCxFlDQYc.smaQhtTrUqNmDWDQEApJkjZTEhYx();
		}
		bool flag2 = false;
		if (XmgyPRdTTGFIkldvJmBJCxFlDQYc.qGuNfawbLaSlQvsGELkPmHLTaxkk is tZexCHiMmKRLendpReaoTFICTkIx)
		{
			flag2 = true;
		}
		else if (!(XmgyPRdTTGFIkldvJmBJCxFlDQYc.qGuNfawbLaSlQvsGELkPmHLTaxkk is sgKnzlYAugAxgEuazGbXddXYpjfPA))
		{
			return;
		}
		if (num2 > 0)
		{
			imCuxEWtDTeCGmPfauEJpiAwBhCU = imCuxEWtDTeCGmPfauEJpiAwBhCU + num2 + " connected devices:\n";
		}
		for (int i = 0; i < num2; i++)
		{
			imCuxEWtDTeCGmPfauEJpiAwBhCU = imCuxEWtDTeCGmPfauEJpiAwBhCU + UQOMGoDVCHfmEcdZcsItgxnHVzkB[i].MJCEwRBVuVKSGDFqTrsuJVtjFKBab + "\n";
		}
		imCuxEWtDTeCGmPfauEJpiAwBhCU += "\n";
		imCuxEWtDTeCGmPfauEJpiAwBhCU = imCuxEWtDTeCGmPfauEJpiAwBhCU + "Current RI device " + bmFuSwMPPzAnyEYKoBDRXjYIabpab + ": \"" + XmgyPRdTTGFIkldvJmBJCxFlDQYc.MJCEwRBVuVKSGDFqTrsuJVtjFKBab + "\"\n";
		imCuxEWtDTeCGmPfauEJpiAwBhCU += "(Press + or - to change monitored device id.)\n\n";
		EsERMkLYeleEAbNcFSsBXIfghbKI("Product Name", "\"" + XmgyPRdTTGFIkldvJmBJCxFlDQYc.MJCEwRBVuVKSGDFqTrsuJVtjFKBab + "\"");
		EsERMkLYeleEAbNcFSsBXIfghbKI("Is Bluetooth Device", XmgyPRdTTGFIkldvJmBJCxFlDQYc.CDIlMCeJNcMdbbkgVhwkeOlHCOww);
		if (XmgyPRdTTGFIkldvJmBJCxFlDQYc.CDIlMCeJNcMdbbkgVhwkeOlHCOww)
		{
			EsERMkLYeleEAbNcFSsBXIfghbKI("Bluetooth Device Name", "\"" + XmgyPRdTTGFIkldvJmBJCxFlDQYc.VQoWzcAGPoQlIieOrWohGPvFaMtI + "\"");
		}
		if (flag2)
		{
			EsERMkLYeleEAbNcFSsBXIfghbKI("Using Custom Driver", "TRUE");
		}
		EsERMkLYeleEAbNcFSsBXIfghbKI("Device Type", XmgyPRdTTGFIkldvJmBJCxFlDQYc.vjwGglosJzWDxTNkOWbLuahYiiijA.ToString());
		EsERMkLYeleEAbNcFSsBXIfghbKI("Identifier", new PidVid(XmgyPRdTTGFIkldvJmBJCxFlDQYc.ivpdrYRhLgwLyrtsRFoaeEevvzRJ));
		EsERMkLYeleEAbNcFSsBXIfghbKI("Product Id", XmgyPRdTTGFIkldvJmBJCxFlDQYc.QhSgzIhvKfsJeIaXJhbIxtnlJSzmA);
		EsERMkLYeleEAbNcFSsBXIfghbKI("Vendor Id", XmgyPRdTTGFIkldvJmBJCxFlDQYc.UIDBCQFGvhtUWvgAxequFCQKjHjA);
		EsERMkLYeleEAbNcFSsBXIfghbKI("Serial", XmgyPRdTTGFIkldvJmBJCxFlDQYc.MuZFTeZVMoSmFqZrrsLCDXSSLaDf);
		imCuxEWtDTeCGmPfauEJpiAwBhCU += "\n";
		EsERMkLYeleEAbNcFSsBXIfghbKI("Axis Count", XmgyPRdTTGFIkldvJmBJCxFlDQYc.pRsRmQMbpTFETkGFBFDUnwCubcGDA);
		EsERMkLYeleEAbNcFSsBXIfghbKI("Button Count", XmgyPRdTTGFIkldvJmBJCxFlDQYc.FVhFeZFkcSgtaZJQFwZiHyBPSKzJA);
		EsERMkLYeleEAbNcFSsBXIfghbKI("Hat Count", XmgyPRdTTGFIkldvJmBJCxFlDQYc.jOAqLcdfStbmayoeZfLkKOCzAdWgb);
		imCuxEWtDTeCGmPfauEJpiAwBhCU += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + UQOMGoDVCHfmEcdZcsItgxnHVzkB[bmFuSwMPPzAnyEYKoBDRXjYIabpab].MJCEwRBVuVKSGDFqTrsuJVtjFKBab + "\"\n";
			if (XmgyPRdTTGFIkldvJmBJCxFlDQYc.CDIlMCeJNcMdbbkgVhwkeOlHCOww)
			{
				text = text + "Bluetooth Device Name: \"" + XmgyPRdTTGFIkldvJmBJCxFlDQYc.VQoWzcAGPoQlIieOrWohGPvFaMtI + "\"\n";
			}
			text = text + "Identifier: " + new PidVid(XmgyPRdTTGFIkldvJmBJCxFlDQYc.ivpdrYRhLgwLyrtsRFoaeEevvzRJ).ToString() + "\n";
			Logger.Log(text);
		}
		if (!flag2)
		{
			sgKnzlYAugAxgEuazGbXddXYpjfPA sgKnzlYAugAxgEuazGbXddXYpjfPA2 = XmgyPRdTTGFIkldvJmBJCxFlDQYc.qGuNfawbLaSlQvsGELkPmHLTaxkk as sgKnzlYAugAxgEuazGbXddXYpjfPA;
			for (int j = 1; j < SbwgfbKVIgksTyATGCQyhAGntRyiA.Length - 1; j++)
			{
				int num3 = SLLhUvEXsHmVPDZxTbyFQYewxhuF((RawInputAxis)fvPMvcJkoMjBdKWylFXHoCCHkJXGb[j], 0, sgKnzlYAugAxgEuazGbXddXYpjfPA2);
				string text2 = SbwgfbKVIgksTyATGCQyhAGntRyiA[j];
				try
				{
					EsERMkLYeleEAbNcFSsBXIfghbKI(text2, num3 + " (" + cjimVYZsZBeNlfjFqaaCNfJzCyFHA(num3) + ")");
				}
				catch
				{
					EsERMkLYeleEAbNcFSsBXIfghbKI(text2, "FAILED! Axis value = " + num3);
				}
			}
			if (sgKnzlYAugAxgEuazGbXddXYpjfPA2.MMkFDwkWiAKjKIadtuFtPzmjarTab > 0)
			{
				for (int k = 0; k < sgKnzlYAugAxgEuazGbXddXYpjfPA2.MMkFDwkWiAKjKIadtuFtPzmjarTab; k++)
				{
					int num4 = SLLhUvEXsHmVPDZxTbyFQYewxhuF(RawInputAxis.Other, k, sgKnzlYAugAxgEuazGbXddXYpjfPA2);
					string text3 = "Other Axis " + k;
					try
					{
						EsERMkLYeleEAbNcFSsBXIfghbKI(text3, num4 + " (" + cjimVYZsZBeNlfjFqaaCNfJzCyFHA(num4) + ")");
					}
					catch
					{
						EsERMkLYeleEAbNcFSsBXIfghbKI(text3, "FAILED! Axis value = " + num4);
					}
				}
			}
			int[] array = XmgyPRdTTGFIkldvJmBJCxFlDQYc.rljFnhZACKuRSqZtwsojLdAPPLML;
			for (int l = 0; l < array.Length; l++)
			{
				int num5 = array[l];
				string text4 = "Hat " + l;
				EsERMkLYeleEAbNcFSsBXIfghbKI(text4, num5);
			}
			bool[] array2 = XmgyPRdTTGFIkldvJmBJCxFlDQYc.gXBEEafTFlCbrgyNkDahyGkHfdwM;
			string text5 = "";
			for (int m = 0; m < array2.Length; m++)
			{
				if (array2[m])
				{
					if (text5 != "")
					{
						text5 += ", ";
					}
					text5 += m;
				}
			}
			EsERMkLYeleEAbNcFSsBXIfghbKI("Buttons ", text5);
		}
		else
		{
			tZexCHiMmKRLendpReaoTFICTkIx tZexCHiMmKRLendpReaoTFICTkIx2 = XmgyPRdTTGFIkldvJmBJCxFlDQYc.qGuNfawbLaSlQvsGELkPmHLTaxkk as tZexCHiMmKRLendpReaoTFICTkIx;
			for (int n = 0; n < XmgyPRdTTGFIkldvJmBJCxFlDQYc.pRsRmQMbpTFETkGFBFDUnwCubcGDA; n++)
			{
				float num6 = tZexCHiMmKRLendpReaoTFICTkIx2.QjGFqvUpJysGPNpweKGAkRnYetOf(n);
				string text6 = n.ToString();
				try
				{
					EsERMkLYeleEAbNcFSsBXIfghbKI(text6, num6 + " (" + tZexCHiMmKRLendpReaoTFICTkIx2.fkqpteCWHcvxYVDRpxSyWoZYwAmu(n) + ")");
				}
				catch
				{
					EsERMkLYeleEAbNcFSsBXIfghbKI(text6, "FAILED! Axis value = " + num6);
				}
			}
			int[] array3 = XmgyPRdTTGFIkldvJmBJCxFlDQYc.rljFnhZACKuRSqZtwsojLdAPPLML;
			for (int num7 = 0; num7 < XmgyPRdTTGFIkldvJmBJCxFlDQYc.jOAqLcdfStbmayoeZfLkKOCzAdWgb; num7++)
			{
				int num8 = array3[num7];
				string text7 = "Hat " + num7;
				EsERMkLYeleEAbNcFSsBXIfghbKI(text7, num8);
			}
			for (int num9 = 0; num9 < XmgyPRdTTGFIkldvJmBJCxFlDQYc.VWSXLNJpPZpyLvVWAebHbsdTMCEo.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EGyroscopeCount; num9++)
			{
				int kcxNEcfpizsnjtyDvoYNbrYJnrar = XmgyPRdTTGFIkldvJmBJCxFlDQYc.VWSXLNJpPZpyLvVWAebHbsdTMCEo.gyroscopes[num9].kcxNEcfpizsnjtyDvoYNbrYJnrar;
				string text8 = "";
				for (int num10 = 0; num10 < kcxNEcfpizsnjtyDvoYNbrYJnrar; num10++)
				{
					float num11 = XmgyPRdTTGFIkldvJmBJCxFlDQYc.VWSXLNJpPZpyLvVWAebHbsdTMCEo.gyroscopes[num9].YZhnygGArvWYHTgbFoiNYQuaNTyS[num10];
					text8 = text8 + "[" + num10 + "]: " + num11.ToString("f3");
					if (num10 < kcxNEcfpizsnjtyDvoYNbrYJnrar - 1)
					{
						text8 += " ";
					}
				}
				EsERMkLYeleEAbNcFSsBXIfghbKI("Gyro " + num9, text8);
			}
			for (int num12 = 0; num12 < XmgyPRdTTGFIkldvJmBJCxFlDQYc.VWSXLNJpPZpyLvVWAebHbsdTMCEo.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EAccelerometerCount; num12++)
			{
				int xLQqfQnSYLtjziJzACIRzDPlXBhT = XmgyPRdTTGFIkldvJmBJCxFlDQYc.VWSXLNJpPZpyLvVWAebHbsdTMCEo.accelerometers[num12].XLQqfQnSYLtjziJzACIRzDPlXBhT;
				string text9 = "";
				for (int num13 = 0; num13 < xLQqfQnSYLtjziJzACIRzDPlXBhT; num13++)
				{
					float num14 = XmgyPRdTTGFIkldvJmBJCxFlDQYc.VWSXLNJpPZpyLvVWAebHbsdTMCEo.accelerometers[num12].WuxcudBBVzHNVwoaaucXfPaFfSOU[num13];
					text9 = text9 + "[" + num13 + "]: " + num14.ToString("f3");
					if (num13 < xLQqfQnSYLtjziJzACIRzDPlXBhT - 1)
					{
						text9 += " ";
					}
				}
				EsERMkLYeleEAbNcFSsBXIfghbKI("Accelerometer " + num12, text9);
			}
			for (int num15 = 0; num15 < XmgyPRdTTGFIkldvJmBJCxFlDQYc.VWSXLNJpPZpyLvVWAebHbsdTMCEo.Rewired_002EHID_002EDrivers_002EIControllerDriver_002ETouchpadCount; num15++)
			{
				NaCRucjlkvXgCSkUJCtQCAeoSdInA naCRucjlkvXgCSkUJCtQCAeoSdInA = XmgyPRdTTGFIkldvJmBJCxFlDQYc.VWSXLNJpPZpyLvVWAebHbsdTMCEo.touchpads[num15];
				int num16 = naCRucjlkvXgCSkUJCtQCAeoSdInA.KUQBOGfLZVeZToGzEycJtsYzolPab.Length;
				string text10 = "";
				for (int num17 = 0; num17 < num16; num17++)
				{
					NaCRucjlkvXgCSkUJCtQCAeoSdInA.TouchData touchData = naCRucjlkvXgCSkUJCtQCAeoSdInA.KUQBOGfLZVeZToGzEycJtsYzolPab[num17];
					text10 = text10 + "Touch " + num17 + ": Is Touching = " + touchData.isTouching + "\n";
					text10 = text10 + "Touch " + num17 + ": Touch Id = " + touchData.touchId + "\n";
					text10 = text10 + "Touch " + num17 + ": Position = " + touchData.positionX + ", " + touchData.positionY + "\n";
					text10 = text10 + "Touch " + num17 + ": Abs Position = " + touchData.positionAbsX + ", " + touchData.positionAbsY + " (" + touchData.positionRawX + ", " + touchData.positionRawY + ")\n";
				}
				krkJwERCVqoBhwcTCFDLwZryMrCy("Touchpad " + num15, text10);
			}
			bool[] array4 = XmgyPRdTTGFIkldvJmBJCxFlDQYc.gXBEEafTFlCbrgyNkDahyGkHfdwM;
			string text11 = "";
			for (int num18 = 0; num18 < array4.Length; num18++)
			{
				if (array4[num18])
				{
					if (text11 != "")
					{
						text11 += ", ";
					}
					text11 += num18;
				}
			}
			EsERMkLYeleEAbNcFSsBXIfghbKI("Buttons ", text11);
		}
		bXlntsuRerMpRDRKAgVvjPwhYmOh.text = imCuxEWtDTeCGmPfauEJpiAwBhCU;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void OnDestroy()
	{
		if (XmgyPRdTTGFIkldvJmBJCxFlDQYc != null)
		{
			XmgyPRdTTGFIkldvJmBJCxFlDQYc.AKMehlDMgtqaPNuADIJLcXEPnOcRA();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}

	private void hncILjqHxZJyrchQVHlEPJcexhhQ()
	{
		UQOMGoDVCHfmEcdZcsItgxnHVzkB = BDjnbkhvpUQPALdSWaTltuyffSYBA.GetJoysticks<VANUTLsVUcepnrrsTIUZlnrrdggd>();
	}

	private void ONhHdABGfvClDiFlrmzSsKdRubKuA()
	{
		qiWkjlbyjDCCJjlgMrONZqcarIjR();
	}

	private void ZfnVfcqrHDVDmMvPbMAPnKvLiatR()
	{
		qiWkjlbyjDCCJjlgMrONZqcarIjR();
	}

	private void qiWkjlbyjDCCJjlgMrONZqcarIjR()
	{
		sttaDYALfXCymCsFmLHbGMMlSJON();
		GpagTkROcsDcfdJrBebQhfDPomjP = true;
	}

	private void sttaDYALfXCymCsFmLHbGMMlSJON()
	{
		bmFuSwMPPzAnyEYKoBDRXjYIabpab = 0;
		XmgyPRdTTGFIkldvJmBJCxFlDQYc = null;
		ZHuCSGrYaFjqYhlDyiNGWGhrmfls = Guid.Empty;
		UQOMGoDVCHfmEcdZcsItgxnHVzkB = null;
		AOiRyjsQGiHItbBYWuxCMXqLDHTk = false;
		GpagTkROcsDcfdJrBebQhfDPomjP = false;
	}

	private void EsERMkLYeleEAbNcFSsBXIfghbKI(string P_0, object P_1)
	{
		imCuxEWtDTeCGmPfauEJpiAwBhCU = imCuxEWtDTeCGmPfauEJpiAwBhCU + P_0 + " = " + P_1.ToString() + "\n";
	}

	private void krkJwERCVqoBhwcTCFDLwZryMrCy(string P_0, object P_1)
	{
		imCuxEWtDTeCGmPfauEJpiAwBhCU = imCuxEWtDTeCGmPfauEJpiAwBhCU + P_0 + ":\n" + P_1.ToString() + "\n";
	}

	private int SLLhUvEXsHmVPDZxTbyFQYewxhuF(RawInputAxis P_0, int P_1, sgKnzlYAugAxgEuazGbXddXYpjfPA P_2)
	{
		return P_2.qmOgenmGDMjdedDNpLMaocOGaNYnA(P_0, P_1);
	}

	private float cjimVYZsZBeNlfjFqaaCNfJzCyFHA(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
