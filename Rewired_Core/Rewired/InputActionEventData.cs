using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private ULWotIhqUFBdhwlfsIksjyZhzzXLA xubLZISywiTQcFEPPTpWBLcTwqcU;

		private InputActionEventType DcJNjXnBJhwiyNefJjIwIcCvUQbE;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return DcJNjXnBJhwiyNefJjIwIcCvUQbE;
			}
			internal set
			{
				DcJNjXnBJhwiyNefJjIwIcCvUQbE = dcJNjXnBJhwiyNefJjIwIcCvUQbE;
			}
		}

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(playerId);
			}
		}

		public string actionName
		{
			get
			{
				if (!ReInput.isReady)
				{
					return string.Empty;
				}
				return ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.ZLbGDLzyWJoHSYYbHtqdaDwdeCFo(actionId).name;
			}
		}

		public string actionDescriptiveName
		{
			get
			{
				if (!ReInput.isReady)
				{
					return string.Empty;
				}
				return ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.ZLbGDLzyWJoHSYYbHtqdaDwdeCFo(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.vEPVoQqEOgbOhOGSJBikhSYMLdUiA();
		}

		public float GetAxisPrev()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.NpyCDcSwegLArthAMKSGhuXhkFop();
		}

		public float GetAxisDelta()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.nnUukRDClTvjtVHilqoEFawpkjxH();
		}

		public double GetAxisTimeActive()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.cWfCnZVHEdQjaWhMBAgewfNvJoCL();
		}

		public double GetAxisTimeInactive()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.mijqNPtAOYiOZHWwhIlwfzuSGzWH();
		}

		public float GetAxisRaw()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.gQdCFfFDgtrNHvBHCVyIGNeWpcHOA();
		}

		public float GetAxisRawDelta()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.yRRQzoykJlGlPXlaScpkkNhQqklw();
		}

		public float GetAxisRawPrev()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.lvZydZRdNFBODAntQjlArfmnHsfu();
		}

		public double GetAxisRawTimeActive()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.jREmhbbNuOZvJIQdOnErHHkvtwot();
		}

		public double GetAxisRawTimeInactive()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.YAgCIbYjNfOsCRfUgepbbGhjtHTk();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.sdRlwsRLwFnOjXwxxIrdSGwYltQD();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.yHzpllAfcqdWadizBLzCEiSTGGZs();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.MrXHpsmIauxPutwZxNYjzqAgdIvq();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.GZUiQQFRngGWEfLnOmWnfQIrTtJk();
		}

		public bool GetButton()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.bboVUHBkbaSOWIdiLlywxyMWUUnP();
		}

		public bool GetButtonPrev()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.CQCGDxvIRQaxxsKVThUacYtWsqMg();
		}

		public bool GetButtonDown()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.MVRdnxXGZCsBJEWZdnMOyOTlrrdu();
		}

		public bool GetButtonUp()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.UfRoNrLsJHhqSsAsVeuTJufLfJRFA();
		}

		public bool GetButtonSinglePressHold()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.jDEDYlcVsDKQOgLXoPHwjvssMsLx();
		}

		public bool GetButtonSinglePressDown()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.lGFalaDqLWAcEovncHQOYVhwYsDh();
		}

		public bool GetButtonSinglePressUp()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.tuXKlFxzwhWBmtiDmoXKHFdhhbgy();
		}

		public bool GetButtonDoublePressDown()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.diDejSPMmguAzBMuUYtWYDGapaGG();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.DJzBbBuISPamiJudWtFJCaoGdPnJ(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.GPxdTPnKvZPPFeghmFSjJxeRkWLPA();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.ApZadUCrymGHNuAoYDoAgNoCOZeMA(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.dpkVxWjtbnhnZwbBEuvqvtYRNtDo();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.tpXRjTJLkVEZEdTZpjFKkWSvzIHfA(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.NaPCjdrIJcSfkZiikNdrmJAwjLAHA(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.NaPCjdrIJcSfkZiikNdrmJAwjLAHA(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.QLEKrtklSFifzxsxWvEETkrPBuAb(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.dXQEAMKAEsFutkqBjFbRclxBVvdJ(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.dXQEAMKAEsFutkqBjFbRclxBVvdJ(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.zraMvrVyidNbGhjFGwgZujuZuXaU();
		}

		public bool GetButtonShortPressDown()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.dEQGvKELxDgVpXQGVhPDfgZSZMSU();
		}

		public bool GetButtonShortPressUp()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.DJeBsuTLpsCVTRdNwinlenTthwUuA();
		}

		public bool GetButtonLongPress()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.giTXpMnAgicGmuBsPYIRxdDrTham();
		}

		public bool GetButtonLongPressDown()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.UDfVaJDtQrhGOKciQpwVOCFQeTHE();
		}

		public bool GetButtonLongPressUp()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.BiYEsqBWejuYrZgXseujMSiWCjnM();
		}

		public bool GetButtonRepeating()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.XMDvGyhgdKGQIdcjGhtGyaBkOPiG();
		}

		public double GetButtonTimePressed()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.QdAcIunoOckgdoMPrhwHOoNNfSUO();
		}

		public double GetButtonTimeUnpressed()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.horbMJjoDewyvjBMwrtIjASukmRA();
		}

		public bool GetNegativeButton()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.xGqLYAhmrlKApcDsGylXNoGhsHKJ();
		}

		public bool GetNegativeButtonPrev()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.LYHnxgyyuAPbCHIZzEjJDWjwOENI();
		}

		public bool GetNegativeButtonDown()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.zQqegsuPBZQcPDbgYgCvXbzrMSjA();
		}

		public bool GetNegativeButtonUp()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.uYGNTCcasDFipFwcGgdlFErqqgJJ();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.WUJMhQZeuqzfgCKfWsXMFupPmxfm();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.eeXJZJVPbpcuVHGWOaKCSebvHxBCA();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.mpdpbqFKATJtDTxpatBaDNKMCbMo();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.taSTdYtdrWHGJPVVtichjbYjEImhA();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.vSyntcCkHSgbfGmhBzBEOsmJGqnX(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.YHrAPlINtXLSjQwXwclbiWYexrsP();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.heyGfqAPgFxDrCgfAbGoKLgXBHhFb(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.KSgZtuZrhBuSEQWNTpEacIXdDxjc();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.RpzRrNGkLingEfckjyDKwxtspnaM(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.dYGtIpGbSsflWejomAvoduwnMjChA(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.dYGtIpGbSsflWejomAvoduwnMjChA(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.AHrgyVdSLVlvnNQDoRnHGYJJpNNN(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.vXonRjPEkrVikgyzgdXEYTvbdPWx(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.vXonRjPEkrVikgyzgdXEYTvbdPWx(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.MpAFpCpNFUaOLyHVQiFYqaRwGzoe();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.CVtupeQxjEDuzxsvZVOrRmOvXdzG();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.jWOqYvLJMLNeLLOzCODqOXPPFAnE();
		}

		public bool GetNegativeButtonLongPress()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.myrlYebIerlIodVAiRhvRbLatyOD();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.UyimVoRwJsWgnMHvTcHJxZwEHMmW();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.zsBxRASPJkUYKCmFixqRgRgzShLM();
		}

		public bool GetNegativeButtonRepeating()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.KneBRatlfpcdHGsuxqXiuYPYithsA();
		}

		public double GetNegativeButtonTimePressed()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.QbRAtpgoFNDflvgdtpbgXUlHTxRuA();
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return xubLZISywiTQcFEPPTpWBLcTwqcU.iwQkjDHgkVNHIsCqLKiHuVYAjVif();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return ReInput.jFidDAJTYMYSSrBGXbdjHWSiLLLfB.zUiRzVjDrtXdtCfESwaiFcTXGjlK(playerId, actionId, true)?.VnbCPJercdswrBMdncGxCZajfOsb();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return ReInput.jFidDAJTYMYSSrBGXbdjHWSiLLLfB.zUiRzVjDrtXdtCfESwaiFcTXGjlK(playerId, actionId, true)?.WRrtgpyUumnwVrDvtBIZfZUmiYeeA(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return ReInput.jFidDAJTYMYSSrBGXbdjHWSiLLLfB.zUiRzVjDrtXdtCfESwaiFcTXGjlK(playerId, actionId, true)?.CyjoBakWIHmjrgYSgUmzeIyDVYVr(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return ReInput.jFidDAJTYMYSSrBGXbdjHWSiLLLfB.zUiRzVjDrtXdtCfESwaiFcTXGjlK(playerId, actionId, true)?.VQItsXmFlydCXeUuNurzfpGUvmlgA(controller) ?? false;
		}

		internal InputActionEventData(ULWotIhqUFBdhwlfsIksjyZhzzXLA P_0, int P_1, int P_2, UpdateLoopType P_3)
		{
			DcJNjXnBJhwiyNefJjIwIcCvUQbE = InputActionEventType.Update;
			xubLZISywiTQcFEPPTpWBLcTwqcU = P_0;
			playerId = P_1;
			actionId = P_2;
			updateLoop = P_3;
		}
	}
}
