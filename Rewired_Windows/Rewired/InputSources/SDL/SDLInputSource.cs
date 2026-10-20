using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.InputSources.SDL
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class SDLInputSource : IInputSource, IDisposable
	{
		protected readonly bool handleJoysticks;

		protected readonly bool handleGamepads;

		private bool wlNMCYcOwzvBnbHhWdtzDsEhahTe;

		private readonly IndexedDictionary<int, YUhbQhiLFKRAUFwRWqBNoTItxqmB> byiHZVLuMVEIsmcOebZyciyLHdzEb;

		private NativeBuffer toxyCABqcHLHubcDZEuUitsdhAKc;

		private bool XzKdtdaUUERfDgfuhprsIFduYwaD;

		protected IndexedDictionary<int, YUhbQhiLFKRAUFwRWqBNoTItxqmB> joysticks => byiHZVLuMVEIsmcOebZyciyLHdzEb;

		protected NativeBuffer eventBuffer => toxyCABqcHLHubcDZEuUitsdhAKc;

		public bool initialized => wlNMCYcOwzvBnbHhWdtzDsEhahTe;

		public abstract event Action DeviceChangedEvent;

		public SDLInputSource(UpdateLoopSetting P_0, bool P_1, bool P_2, bool P_3, bool P_4)
		{
			handleJoysticks = P_1;
			handleGamepads = P_2;
			byiHZVLuMVEIsmcOebZyciyLHdzEb = new IndexedDictionary<int, YUhbQhiLFKRAUFwRWqBNoTItxqmB>();
		}

		protected virtual void PostConstructor()
		{
			try
			{
				if (!InitializeSDL())
				{
					throw new Exception("Failed to initialize SDL!");
				}
				wlNMCYcOwzvBnbHhWdtzDsEhahTe = true;
				if (handleGamepads)
				{
					LoadGamepadMappings();
				}
				PollForJoystickChanges(force: true);
				toxyCABqcHLHubcDZEuUitsdhAKc = new NativeBuffer(GetEventBufferSize());
			}
			catch
			{
				wlNMCYcOwzvBnbHhWdtzDsEhahTe = false;
				Dispose();
				throw;
			}
		}

		public void SystemDeviceConnected()
		{
			throw new NotImplementedException();
		}

		void IInputSource.SystemDeviceConnected()
		{
			//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceConnected
			this.SystemDeviceConnected();
		}

		public void SystemDeviceDisconnected()
		{
			throw new NotImplementedException();
		}

		void IInputSource.SystemDeviceDisconnected()
		{
			//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceDisconnected
			this.SystemDeviceDisconnected();
		}

		public virtual void Update()
		{
			_ = wlNMCYcOwzvBnbHhWdtzDsEhahTe;
		}

		void IInputSource.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public virtual void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (wlNMCYcOwzvBnbHhWdtzDsEhahTe)
			{
				ProcessEvents();
				PollForJoystickChanges(force: false);
			}
		}

		void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateDevices
			this.UpdateDevices(updateLoop);
		}

		public virtual void UpdateFinished()
		{
			_ = wlNMCYcOwzvBnbHhWdtzDsEhahTe;
		}

		void IInputSource.UpdateFinished()
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
			this.UpdateFinished();
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!wlNMCYcOwzvBnbHhWdtzDsEhahTe)
			{
				return null;
			}
			List<T> list = new List<T>();
			if (handleJoysticks || handleGamepads)
			{
				for (int i = 0; i < byiHZVLuMVEIsmcOebZyciyLHdzEb.Count; i++)
				{
					YUhbQhiLFKRAUFwRWqBNoTItxqmB yUhbQhiLFKRAUFwRWqBNoTItxqmB = byiHZVLuMVEIsmcOebZyciyLHdzEb[i];
					if (yUhbQhiLFKRAUFwRWqBNoTItxqmB.RrBntAiBLvYdWbroLqoTdBJylFRC && IsAllowed(yUhbQhiLFKRAUFwRWqBNoTItxqmB) && yUhbQhiLFKRAUFwRWqBNoTItxqmB is T item)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}

		IList<T> IInputSource.GetJoysticks<T>()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetJoysticks
			return this.GetJoysticks<T>();
		}

		protected YUhbQhiLFKRAUFwRWqBNoTItxqmB GetJoystickByInstanceId(int instanceId)
		{
			if (!joysticks.TryGetValue(instanceId, out var value))
			{
				return null;
			}
			return value;
		}

		protected int IndexOfJoystickWithInstanceId(int instanceId)
		{
			int count = byiHZVLuMVEIsmcOebZyciyLHdzEb.Count;
			for (int i = 0; i < count; i++)
			{
				if (byiHZVLuMVEIsmcOebZyciyLHdzEb[i].LLLVSyGEDzGKHJoApyvkQjXBgayhA == instanceId)
				{
					return i;
				}
			}
			return -1;
		}

		protected virtual void SendJoystickElementChangedEvent(int instanceId, LCUivSLtVZjfWgluNTVEMTZzAtrd elementType, byte elementIndex, short value, double timestamp)
		{
			YUhbQhiLFKRAUFwRWqBNoTItxqmB joystickByInstanceId = GetJoystickByInstanceId(instanceId);
			if (joystickByInstanceId != null && joystickByInstanceId.JoystickType == dHPpbhmiaqtelxmYmFpgoGAPMmoe.Joystick)
			{
				joystickByInstanceId.BXtMGusXZmJevKpyBFevOheNKlrI(elementType, elementIndex, value, timestamp);
			}
		}

		protected virtual void SendGamepadElementChangedEvent(int instanceId, LCUivSLtVZjfWgluNTVEMTZzAtrd elementType, byte gamepadElement, short value, double timestamp)
		{
			YUhbQhiLFKRAUFwRWqBNoTItxqmB joystickByInstanceId = GetJoystickByInstanceId(instanceId);
			if (joystickByInstanceId != null && joystickByInstanceId.JoystickType == dHPpbhmiaqtelxmYmFpgoGAPMmoe.Gamepad)
			{
				joystickByInstanceId.BXtMGusXZmJevKpyBFevOheNKlrI(elementType, gamepadElement, value, timestamp);
			}
		}

		protected abstract int GetEventBufferSize();

		protected abstract bool InitializeSDL();

		protected abstract void DeinitializeSDL();

		protected abstract int GetSDLJoystickCount();

		protected abstract int GetGamepadCount();

		protected abstract void PollForJoystickChanges(bool force);

		protected abstract void CloseJoysticks();

		protected abstract void ProcessEvents();

		protected abstract void LoadGamepadMappings();

		protected abstract bool IsAllowed(qsgekoIkSLKHNvSvhDyqzbhlTpKd device);

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~SDLInputSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (XzKdtdaUUERfDgfuhprsIFduYwaD)
			{
				return;
			}
			if (disposing)
			{
				if (toxyCABqcHLHubcDZEuUitsdhAKc != null)
				{
					toxyCABqcHLHubcDZEuUitsdhAKc.Dispose();
				}
				CloseJoysticks();
			}
			DeinitializeSDL();
			wlNMCYcOwzvBnbHhWdtzDsEhahTe = false;
			XzKdtdaUUERfDgfuhprsIFduYwaD = true;
		}
	}
}
