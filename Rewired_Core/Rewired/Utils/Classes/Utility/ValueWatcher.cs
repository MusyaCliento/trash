using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ValueWatcher
	{
		public enum FgfyAkaDEBfCZkwuXGodUSeYwXZZ
		{
			ValueChanged = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(FgfyAkaDEBfCZkwuXGodUSeYwXZZ eventType, Delegate listener);

		public abstract void RemoveEventListener(FgfyAkaDEBfCZkwuXGodUSeYwXZZ eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> qxAhoOwaYPvVmWneShCDqNsbrBlV = EqualityComparerNoAlloc<T>.Default;

		private bool kNkGIumDEqZKyUtEbpbfwjzLcdTt;

		private T ilGANbryjEnAtfmXBsStHItsfSdGA;

		private bool agVkMadSRJunjYjccpIgrftDZIaV;

		private Func<T> vQRBDXAGnuguyOIfxsFioXcWfWOAA;

		private Action<T> zRLKaRXCwfmGKYLgElkBSOvoEnn;

		bool ValueWatcher.changed => kNkGIumDEqZKyUtEbpbfwjzLcdTt;

		bool ValueWatcher.autoTriggerEvent
		{
			get
			{
				return agVkMadSRJunjYjccpIgrftDZIaV;
			}
			set
			{
				agVkMadSRJunjYjccpIgrftDZIaV = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return vQRBDXAGnuguyOIfxsFioXcWfWOAA;
			}
			set
			{
				vQRBDXAGnuguyOIfxsFioXcWfWOAA = value;
			}
		}

		public T value => ilGANbryjEnAtfmXBsStHItsfSdGA;

		public event Action<T> ChangedEvent
		{
			add
			{
				zRLKaRXCwfmGKYLgElkBSOvoEnn = (Action<T>)Delegate.Combine(zRLKaRXCwfmGKYLgElkBSOvoEnn, value);
			}
			remove
			{
				zRLKaRXCwfmGKYLgElkBSOvoEnn = (Action<T>)Delegate.Remove(zRLKaRXCwfmGKYLgElkBSOvoEnn, value);
			}
		}

		public ValueWatcher(T P_0, bool P_1)
		{
			ilGANbryjEnAtfmXBsStHItsfSdGA = P_0;
			agVkMadSRJunjYjccpIgrftDZIaV = P_1;
		}

		public ValueWatcher(T P_0, Func<T> P_1, bool P_2)
			: this(P_0, P_2)
		{
			vQRBDXAGnuguyOIfxsFioXcWfWOAA = P_1;
		}

		public override bool Update()
		{
			if (vQRBDXAGnuguyOIfxsFioXcWfWOAA == null)
			{
				return false;
			}
			try
			{
				return Set(vQRBDXAGnuguyOIfxsFioXcWfWOAA());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!kNkGIumDEqZKyUtEbpbfwjzLcdTt)
			{
				return false;
			}
			kNkGIumDEqZKyUtEbpbfwjzLcdTt = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!kNkGIumDEqZKyUtEbpbfwjzLcdTt)
			{
				return false;
			}
			if (zRLKaRXCwfmGKYLgElkBSOvoEnn == null)
			{
				return true;
			}
			try
			{
				Use();
				zRLKaRXCwfmGKYLgElkBSOvoEnn(ilGANbryjEnAtfmXBsStHItsfSdGA);
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by ValueChangedEvent handler.\n" + ex);
				return false;
			}
		}

		public bool Set(T value)
		{
			if (qxAhoOwaYPvVmWneShCDqNsbrBlV.Equals(ilGANbryjEnAtfmXBsStHItsfSdGA, value))
			{
				return false;
			}
			ilGANbryjEnAtfmXBsStHItsfSdGA = value;
			kNkGIumDEqZKyUtEbpbfwjzLcdTt = true;
			if (agVkMadSRJunjYjccpIgrftDZIaV)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(FgfyAkaDEBfCZkwuXGodUSeYwXZZ eventType, Delegate listener)
		{
			if (eventType == FgfyAkaDEBfCZkwuXGodUSeYwXZZ.ValueChanged)
			{
				if (!(listener is Action<T>))
				{
					throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
				}
				ChangedEvent += (Action<T>)listener;
				return;
			}
			throw new NotImplementedException();
		}

		public override void RemoveEventListener(FgfyAkaDEBfCZkwuXGodUSeYwXZZ eventType, Delegate listener)
		{
			if (eventType == FgfyAkaDEBfCZkwuXGodUSeYwXZZ.ValueChanged)
			{
				if (!(listener is Action<T>))
				{
					throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
				}
				ChangedEvent -= (Action<T>)listener;
				return;
			}
			throw new NotImplementedException();
		}
	}
}
