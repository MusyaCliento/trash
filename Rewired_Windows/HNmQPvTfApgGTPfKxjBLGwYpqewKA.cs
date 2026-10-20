using System;

internal class HNmQPvTfApgGTPfKxjBLGwYpqewKA : YiwcomZCvMgfXhGkTHKiDqEgfOmd, nWNBBmFzZefBwJgPFMfDcAdtQEeF, YUhbQhiLFKRAUFwRWqBNoTItxqmB, qsgekoIkSLKHNvSvhDyqzbhlTpKd, IDisposable
{
	public HNmQPvTfApgGTPfKxjBLGwYpqewKA(zDbEpgAbmSQSqdROmaGAcBeJJIpLA P_0, GdElFSEOhuyCrFfZjnsSYHuwFWAO P_1)
		: base(P_0, P_1, dHPpbhmiaqtelxmYmFpgoGAPMmoe.Gamepad, 26, 6, 0, 0)
	{
	}

	public virtual bool jfuPKbiNFClUCUgFCTLnwqkwIxNh()
	{
		if (fnNOhmKjUQqFLmthSwtwsQbWFnkM == null || !fnNOhmKjUQqFLmthSwtwsQbWFnkM.IsValid)
		{
			return false;
		}
		return pxmGIZLDmjeWcctuwsIuvAjQwjgDA.JaZWQkUkaodWehrPpTLHlSyozRuNA(fnNOhmKjUQqFLmthSwtwsQbWFnkM);
	}

	protected virtual void htMIgyUqjKfXtvyqTPTAHQvrCmdDA()
	{
		if (base.RrBntAiBLvYdWbroLqoTdBJylFRC)
		{
			uint num = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.QnkXtIFugNtCgLIcJGAPhpPOazbRA(fnNOhmKjUQqFLmthSwtwsQbWFnkM);
			bool flag = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.OTTnGmEKMPzlKLQIyAxoZhbSlUjU(num, "SDL.joystick.cap.rumble", false);
			bool flag2 = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.OTTnGmEKMPzlKLQIyAxoZhbSlUjU(num, "SDL.joystick.cap.trigger_rumble", false);
			if (flag || flag2)
			{
				ceAXDruLwNygLdikwypuLYCHxiLW(flag, flag2);
			}
			else
			{
				cRlrdYrcNCxaVBhxYVKZpMHdEWqEA();
			}
		}
	}

	private void ceAXDruLwNygLdikwypuLYCHxiLW(bool P_0, bool P_1)
	{
		int num = 0;
		XUAqDfNckUTARXJyRKNOaatjlCke xUAqDfNckUTARXJyRKNOaatjlCke = XUAqDfNckUTARXJyRKNOaatjlCke.None;
		if (P_0)
		{
			xUAqDfNckUTARXJyRKNOaatjlCke |= XUAqDfNckUTARXJyRKNOaatjlCke.GamepadRumble;
			num = 2;
		}
		if (P_1)
		{
			xUAqDfNckUTARXJyRKNOaatjlCke |= XUAqDfNckUTARXJyRKNOaatjlCke.GamepadRumbleTriggers;
			num = 4;
		}
		RUhoylDiEQWleSHdCUayqDehGVoB(xUAqDfNckUTARXJyRKNOaatjlCke, num);
	}

	protected virtual void kfCeLgWkNQSaZvMGNxMQFvAkREvS()
	{
		if (fnNOhmKjUQqFLmthSwtwsQbWFnkM != null && fnNOhmKjUQqFLmthSwtwsQbWFnkM.IsValid)
		{
			if (!rEybbyoLWHwQTcvIdpCuAsswrlWx())
			{
				fnNOhmKjUQqFLmthSwtwsQbWFnkM.Clear();
				return;
			}
			pxmGIZLDmjeWcctuwsIuvAjQwjgDA.wxhQaGkxJXymCefWIsCgvpnnElEC(fnNOhmKjUQqFLmthSwtwsQbWFnkM);
			fnNOhmKjUQqFLmthSwtwsQbWFnkM.Clear();
		}
	}
}
