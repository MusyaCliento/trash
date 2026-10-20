using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Rewired.Platforms.Custom.ControllerComponents
{
	public abstract class VibrationMotor : IVibrationMotor
	{
		private float XloHfMFIQFEsuekNJBMDPdRCJhbGb;

		private double mghHnOAjSrDbcZZqpvBZlxLBACxi;

		private bool JbQAOzTdbEPSpMFBtxNxAMNlAsXIA;

		private float RJPAFvkeOsfkKPJBHnMnAAaDdcfGB;

		private bool kIzyYUAgNCuTBlupyBKDDvJlKQlv;

		[CompilerGenerated]
		private Action gToGLdtnXztgufupMezyYvtlToFX;

		[CompilerGenerated]
		private Action nTCoQXVCxzwjsYGBPdIrynlmFEycA;

		public float duration
		{
			get
			{
				return XloHfMFIQFEsuekNJBMDPdRCJhbGb;
			}
			protected set
			{
				XloHfMFIQFEsuekNJBMDPdRCJhbGb = value;
			}
		}

		float IVibrationMotor.renewInterval
		{
			get
			{
				return RJPAFvkeOsfkKPJBHnMnAAaDdcfGB;
			}
			set
			{
				if (value < 0f)
				{
					value = 0f;
				}
				RJPAFvkeOsfkKPJBHnMnAAaDdcfGB = value;
			}
		}

		public event Action StartEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = gToGLdtnXztgufupMezyYvtlToFX;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref gToGLdtnXztgufupMezyYvtlToFX, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = gToGLdtnXztgufupMezyYvtlToFX;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref gToGLdtnXztgufupMezyYvtlToFX, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public event Action StopEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = nTCoQXVCxzwjsYGBPdIrynlmFEycA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref nTCoQXVCxzwjsYGBPdIrynlmFEycA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = nTCoQXVCxzwjsYGBPdIrynlmFEycA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref nTCoQXVCxzwjsYGBPdIrynlmFEycA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		internal virtual void wlhfYjtclfAEsMZSxJlYkaLDhgWgA()
		{
			if (!JbQAOzTdbEPSpMFBtxNxAMNlAsXIA)
			{
				Clear();
				JbQAOzTdbEPSpMFBtxNxAMNlAsXIA = true;
			}
		}

		public virtual void Update()
		{
			if (!kIzyYUAgNCuTBlupyBKDDvJlKQlv)
			{
				return;
			}
			if (XloHfMFIQFEsuekNJBMDPdRCJhbGb > 0f)
			{
				double unscaledTime = ReInput.time.unscaledTime;
				if (mghHnOAjSrDbcZZqpvBZlxLBACxi + (double)XloHfMFIQFEsuekNJBMDPdRCJhbGb >= unscaledTime)
				{
					Clear();
				}
			}
			if (kIzyYUAgNCuTBlupyBKDDvJlKQlv && RJPAFvkeOsfkKPJBHnMnAAaDdcfGB > 0f && ReInput.time.unscaledTime >= mghHnOAjSrDbcZZqpvBZlxLBACxi + (double)RJPAFvkeOsfkKPJBHnMnAAaDdcfGB)
			{
				Start();
			}
		}

		void IVibrationMotor.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		protected void Start()
		{
			mghHnOAjSrDbcZZqpvBZlxLBACxi = ReInput.time.unscaledTime;
			kIzyYUAgNCuTBlupyBKDDvJlKQlv = true;
			gToGLdtnXztgufupMezyYvtlToFX?.Invoke();
		}

		protected void SetDuration(float duration)
		{
			if (duration < 0f)
			{
				duration = 0f;
			}
			XloHfMFIQFEsuekNJBMDPdRCJhbGb = duration;
		}

		public virtual void Clear()
		{
			bool num = kIzyYUAgNCuTBlupyBKDDvJlKQlv;
			XloHfMFIQFEsuekNJBMDPdRCJhbGb = 0f;
			mghHnOAjSrDbcZZqpvBZlxLBACxi = 0.0;
			kIzyYUAgNCuTBlupyBKDDvJlKQlv = false;
			if (num)
			{
				nTCoQXVCxzwjsYGBPdIrynlmFEycA?.Invoke();
			}
		}

		void IVibrationMotor.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}
	}
	public abstract class VibrationMotor<TVibration> : VibrationMotor
	{
		private TVibration gXMLqEsAVITQGcgCKcuojpaFwyq;

		public TVibration vibration => gXMLqEsAVITQGcgCKcuojpaFwyq;

		public virtual TVibration GetVibration()
		{
			return gXMLqEsAVITQGcgCKcuojpaFwyq;
		}

		public virtual void SetVibration(TVibration vibration, float duration)
		{
			if (duration < 0f)
			{
				duration = 0f;
			}
			gXMLqEsAVITQGcgCKcuojpaFwyq = vibration;
			base.duration = duration;
			Start();
		}

		public override void Clear()
		{
			base.Clear();
			gXMLqEsAVITQGcgCKcuojpaFwyq = GetDefaultValue();
		}

		protected abstract TVibration GetDefaultValue();
	}
}
