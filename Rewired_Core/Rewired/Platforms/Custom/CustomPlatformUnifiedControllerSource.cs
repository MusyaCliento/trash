using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformUnifiedControllerSource : IDisposable
	{
		private readonly int vUweTQWpoKsNmbLwIriRwefnbTnw;

		private readonly int oiMBOHoYITcoNcnrfEPmAcLrdupLA;

		private readonly bool[] qoPqofnmSXTwdqvjLwhWdDNYZhgh;

		private readonly bool[] VcrEmKFmvXzyGcLEgZbQJtolTnfpA;

		private readonly float[] lxMbgSKMdbrKRefpCYSIFNtrtJOKB;

		private bool dLUkeOspYVhkRPHWIwSVpZjeLRCS;

		public int axisCount => vUweTQWpoKsNmbLwIriRwefnbTnw;

		public int buttonCount => oiMBOHoYITcoNcnrfEPmAcLrdupLA;

		public virtual Controller.Extension controllerExtension => null;

		public CustomPlatformUnifiedControllerSource(int P_0, int P_1)
		{
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_1 < 0)
			{
				P_1 = 0;
			}
			vUweTQWpoKsNmbLwIriRwefnbTnw = P_0;
			oiMBOHoYITcoNcnrfEPmAcLrdupLA = P_1;
			lxMbgSKMdbrKRefpCYSIFNtrtJOKB = new float[P_0];
			qoPqofnmSXTwdqvjLwhWdDNYZhgh = new bool[P_1];
			VcrEmKFmvXzyGcLEgZbQJtolTnfpA = new bool[P_1];
		}

		protected abstract void Update();

		internal virtual void BwXxQVCcuUbHwQlFMldfyFIxjspfA()
		{
		}

		protected virtual void OnInitialize()
		{
		}

		protected virtual void Clear()
		{
			Array.Clear(lxMbgSKMdbrKRefpCYSIFNtrtJOKB, 0, vUweTQWpoKsNmbLwIriRwefnbTnw);
			Array.Clear(qoPqofnmSXTwdqvjLwhWdDNYZhgh, 0, oiMBOHoYITcoNcnrfEPmAcLrdupLA);
			Array.Clear(VcrEmKFmvXzyGcLEgZbQJtolTnfpA, 0, oiMBOHoYITcoNcnrfEPmAcLrdupLA);
		}

		protected float GetAxisValue(int index)
		{
			if ((uint)index >= (uint)axisCount)
			{
				return 0f;
			}
			return lxMbgSKMdbrKRefpCYSIFNtrtJOKB[index];
		}

		protected bool GetButtonValue(int index)
		{
			if ((uint)index >= (uint)buttonCount)
			{
				return false;
			}
			return qoPqofnmSXTwdqvjLwhWdDNYZhgh[index];
		}

		protected void SetAxisValue(int index, float value)
		{
			if ((uint)index < (uint)axisCount)
			{
				lxMbgSKMdbrKRefpCYSIFNtrtJOKB[index] = value;
			}
		}

		protected void SetAxisValues(IList<float> values)
		{
			if (values == null)
			{
				return;
			}
			int num = MathTools.Min(values.Count, axisCount);
			if (values is float[])
			{
				Array.Copy(values as float[], lxMbgSKMdbrKRefpCYSIFNtrtJOKB, num);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				lxMbgSKMdbrKRefpCYSIFNtrtJOKB[i] = values[i];
			}
		}

		protected void SetButtonValue(int index, bool value)
		{
			if ((uint)index < (uint)buttonCount)
			{
				if (!qoPqofnmSXTwdqvjLwhWdDNYZhgh[index] && value)
				{
					VcrEmKFmvXzyGcLEgZbQJtolTnfpA[index] = true;
				}
				qoPqofnmSXTwdqvjLwhWdDNYZhgh[index] = value;
			}
		}

		protected void SetButtonValues(IList<bool> values)
		{
			if (values == null)
			{
				return;
			}
			int num = MathTools.Min(values.Count, buttonCount);
			if (values is bool[])
			{
				for (int i = 0; i < num; i++)
				{
					if (!qoPqofnmSXTwdqvjLwhWdDNYZhgh[i] && values[i])
					{
						VcrEmKFmvXzyGcLEgZbQJtolTnfpA[i] = true;
					}
				}
				Array.Copy(values as bool[], qoPqofnmSXTwdqvjLwhWdDNYZhgh, num);
				return;
			}
			for (int j = 0; j < num; j++)
			{
				bool flag = values[j];
				if (!qoPqofnmSXTwdqvjLwhWdDNYZhgh[j] && flag)
				{
					VcrEmKFmvXzyGcLEgZbQJtolTnfpA[j] = true;
				}
				qoPqofnmSXTwdqvjLwhWdDNYZhgh[j] = flag;
			}
		}

		internal void PfkBaPDVMyRtqEQbRKeFNCPeCxIaA()
		{
			OnInitialize();
		}

		internal void EzGdavrwXRDGejzHKLZyKHleVOWU()
		{
			Clear();
		}

		internal void dyMKNzRtxHDYgJqCxtnUUKsUKIIF(ControllerDataUpdater P_0)
		{
			gycJUwQfrcEQGJltarQkqSBOywiq();
			Update();
			BwXxQVCcuUbHwQlFMldfyFIxjspfA();
			Array.Copy(lxMbgSKMdbrKRefpCYSIFNtrtJOKB, P_0.axisValues, vUweTQWpoKsNmbLwIriRwefnbTnw);
			for (int i = 0; i < vUweTQWpoKsNmbLwIriRwefnbTnw; i++)
			{
				if (lxMbgSKMdbrKRefpCYSIFNtrtJOKB[i] != 0f && !P_0.hasReceivedInput)
				{
					P_0.hasReceivedInput = true;
				}
			}
			Array.Copy(qoPqofnmSXTwdqvjLwhWdDNYZhgh, P_0.buttonValues, oiMBOHoYITcoNcnrfEPmAcLrdupLA);
			for (int j = 0; j < oiMBOHoYITcoNcnrfEPmAcLrdupLA; j++)
			{
				if (qoPqofnmSXTwdqvjLwhWdDNYZhgh[j] && !P_0.hasReceivedInput)
				{
					P_0.hasReceivedInput = true;
				}
				if (VcrEmKFmvXzyGcLEgZbQJtolTnfpA[j] && !qoPqofnmSXTwdqvjLwhWdDNYZhgh[j])
				{
					qoPqofnmSXTwdqvjLwhWdDNYZhgh[j] = true;
				}
			}
		}

		private void gycJUwQfrcEQGJltarQkqSBOywiq()
		{
			Array.Clear(VcrEmKFmvXzyGcLEgZbQJtolTnfpA, 0, VcrEmKFmvXzyGcLEgZbQJtolTnfpA.Length);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!dLUkeOspYVhkRPHWIwSVpZjeLRCS)
			{
				dLUkeOspYVhkRPHWIwSVpZjeLRCS = true;
			}
		}

		void IDisposable.Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
