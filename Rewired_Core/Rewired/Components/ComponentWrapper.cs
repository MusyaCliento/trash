using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T jYcZwyOSNdHPmEsxVNcpFUKCKYIj;

		[NonSerialized]
		private bool lUwDTTmFNfwrblGjDiyVyEUJzWZn;

		protected T source => jYcZwyOSNdHPmEsxVNcpFUKCKYIj;

		protected bool initialized => lUwDTTmFNfwrblGjDiyVyEUJzWZn;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			OnAwake();
			OnAwakeFinished();
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			OnStart();
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			OnEnabled();
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			OnDisabled();
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			OnDestroyed();
		}

		[CustomObfuscation(rename = false)]
		private void Reset()
		{
			OnReset();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			OnValidated();
		}

		protected virtual void OnAwake()
		{
			ReInput.InitializedEvent += gcziYhaJEDABpfIZdXJuerMoxRcDb;
			Initialize();
		}

		protected virtual void OnAwakeFinished()
		{
		}

		protected virtual void OnStart()
		{
		}

		protected virtual void OnEnabled()
		{
		}

		protected virtual void OnDisabled()
		{
		}

		protected virtual void OnDestroyed()
		{
			Unsubscribe();
			ReInput.InitializedEvent -= gcziYhaJEDABpfIZdXJuerMoxRcDb;
		}

		protected virtual void OnReset()
		{
		}

		protected virtual void OnValidated()
		{
		}

		protected virtual void Initialize()
		{
			if (TryInitialize())
			{
				lUwDTTmFNfwrblGjDiyVyEUJzWZn = true;
				PostInitialize();
			}
		}

		protected virtual bool TryInitialize()
		{
			if (lUwDTTmFNfwrblGjDiyVyEUJzWZn)
			{
				return false;
			}
			jYcZwyOSNdHPmEsxVNcpFUKCKYIj = CreateSource(GetCreateSourceArgs());
			if (jYcZwyOSNdHPmEsxVNcpFUKCKYIj == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			lUwDTTmFNfwrblGjDiyVyEUJzWZn = true;
			return true;
		}

		protected abstract T CreateSource(object args);

		protected abstract object GetCreateSourceArgs();

		protected virtual void PostInitialize()
		{
			Subscribe();
		}

		protected virtual void Deinitialize()
		{
			lUwDTTmFNfwrblGjDiyVyEUJzWZn = false;
			Unsubscribe();
			jYcZwyOSNdHPmEsxVNcpFUKCKYIj = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += SwCcINuaisbsWJaJDAoyjCdqfKMI;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= SwCcINuaisbsWJaJDAoyjCdqfKMI;
		}

		private void SwCcINuaisbsWJaJDAoyjCdqfKMI()
		{
			Deinitialize();
		}

		private void gcziYhaJEDABpfIZdXJuerMoxRcDb()
		{
			Initialize();
		}
	}
}
