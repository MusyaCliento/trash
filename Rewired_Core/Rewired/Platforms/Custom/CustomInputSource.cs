using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Interfaces;
using Rewired.Platforms.Custom.ControllerComponents;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomInputSource : IDisposable, IInputSource
	{
		public abstract class Controller : IController_Internal, IDisposable
		{
			public abstract class InitOptions
			{
				private ControllerType qBeLzVbKAQjpJeBjfUEGtbuhaqiY;

				private string GmcvEiqfJtbciEvuxcmSkFFBAzhEA;

				private string qUeGrTvPtpoPXeLlDolscldFDUCe;

				private long? XYuLuyemtmqfmVqdgmujxKctWTxM;

				public ControllerType controllerType => qBeLzVbKAQjpJeBjfUEGtbuhaqiY;

				public string deviceName
				{
					get
					{
						return GmcvEiqfJtbciEvuxcmSkFFBAzhEA;
					}
					set
					{
						GmcvEiqfJtbciEvuxcmSkFFBAzhEA = value;
					}
				}

				public string displayName
				{
					get
					{
						return qUeGrTvPtpoPXeLlDolscldFDUCe;
					}
					set
					{
						qUeGrTvPtpoPXeLlDolscldFDUCe = value;
					}
				}

				public long? systemId
				{
					get
					{
						return XYuLuyemtmqfmVqdgmujxKctWTxM;
					}
					set
					{
						XYuLuyemtmqfmVqdgmujxKctWTxM = value;
					}
				}

				protected InitOptions(ControllerType P_0)
				{
					qBeLzVbKAQjpJeBjfUEGtbuhaqiY = P_0;
				}
			}

			public abstract class Component : IDisposable
			{
				private readonly Controller MiiRWoTZeOPMLIYLiGaQLHVIiwlf;

				private bool fsNDnjqrehQBLanNMtKaKiWaSbAq;

				public Controller controller => MiiRWoTZeOPMLIYLiGaQLHVIiwlf;

				protected Component(Controller P_0)
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("controller");
					}
					MiiRWoTZeOPMLIYLiGaQLHVIiwlf = P_0;
				}

				internal void tQsUvjqOoVEQmwuKAyQGXCDktplr()
				{
					OnInitialize();
				}

				internal void JFQkYuWcjvcAhXBdaOokBSseevPu()
				{
					OnUpdate();
				}

				protected virtual void OnInitialize()
				{
				}

				protected virtual void OnUpdate()
				{
				}

				protected virtual void OnDisposed()
				{
				}

				protected virtual void Dispose(bool disposing)
				{
					if (!fsNDnjqrehQBLanNMtKaKiWaSbAq)
					{
						if (disposing)
						{
							OnDisposed();
						}
						fsNDnjqrehQBLanNMtKaKiWaSbAq = true;
					}
				}

				void IDisposable.Dispose()
				{
					Dispose(disposing: true);
					GC.SuppressFinalize(this);
				}
			}

			private readonly int cxgpNjDiHoqZUAkBKtrghHtTckSfA;

			protected bool _isConnected;

			protected string _deviceName;

			protected string _customName;

			protected object _customIdentifier;

			protected Guid _persistentGuid;

			private readonly ControllerType xMcAAxgWVFwoYuzHqcCckUhUKqqW;

			private long? JWKMgwESUOJiJkPTgsruczsZFMkr;

			private Axis[] VWdcdmiSQKMcwgsdPOygFurKgNoV;

			private Button[] TCulqAwArqESvuOSgtVQtCDYrEx;

			private ReadOnlyCollection<Axis> HcngIbctmHjgFDoEYuYVNfuIebvl;

			private ReadOnlyCollection<Button> gjoeKNSeOmXrlAKrqZvXnlEfHbsDA;

			private ReadOnlyCollection<Element> PkgiBigaeazUuOxjAstCZYlsqKxW;

			private bool WUlECXJXBMLMhmfEUkREHgfGRBBCb;

			private readonly List<Rewired.Controller.Extension> oebvosUhYbOgWHqrVaJFweoWjoIE;

			private readonly ReadOnlyCollection<Rewired.Controller.Extension> fNVwdAumThiVMhDqOCsyiPdXGtRI;

			private readonly OdJqGDClzvhlCmnswHcatrKErHSt<Element> LmRiRGExBaPVOdYEVvGJwCYgfmUV;

			private Dictionary<int, Element> RNhiTvMlvJLtyicdxhFkeGJdTvfRA;

			private Element[] fCnCCVJHRpAaSWySsgketjtpCrXQA;

			private readonly AList<Component> laRiKQMZWjAHtqKbEOHFqaEdgytO;

			private readonly ReadOnlyCollection<Component> OdszlBfzLLkggGcuVDYPRtWjaIbs;

			private Action<bool> ohNVnXFDDKHyHpMsZsHJRDfaeBkIA;

			private bool OAEHePEgGGiqFluDAJrzCoIBrtHZb;

			private bool HFHpqGRMzZglzAwWLstapIjqpBy;

			private readonly bool tskQdOBAoYAnyFBltzXKnLQbKilVA;

			private readonly int QglgdtShddfoMtCEMsPlVJHZCxJY;

			private readonly int vFSRSyUqDrHYuacWHtVqcBKlWRAn;

			private readonly AList<string> yUrKCViGBUMJdDcVdrBJjexKWfow;

			private readonly ReadOnlyCollection<string> CBzcsxymYXkjOCkidtFqNqwcXCMn;

			private bool kFlMltlajMldVfQlZgwxYKBytMKd;

			private static int WhSHzAUPoHKdnPDKLVaJbvQQlJwn;

			public int id => cxgpNjDiHoqZUAkBKtrghHtTckSfA;

			public ControllerType type => xMcAAxgWVFwoYuzHqcCckUhUKqqW;

			public long? systemId
			{
				get
				{
					return JWKMgwESUOJiJkPTgsruczsZFMkr;
				}
				protected set
				{
					JWKMgwESUOJiJkPTgsruczsZFMkr = value;
				}
			}

			public string customName => _customName;

			public bool isConnected
			{
				get
				{
					return _isConnected;
				}
				set
				{
					if (value == _isConnected)
					{
						return;
					}
					_isConnected = value;
					if (!value)
					{
						Clear();
					}
					Action<bool> action = ohNVnXFDDKHyHpMsZsHJRDfaeBkIA;
					if (action == null)
					{
						return;
					}
					try
					{
						action(value);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("CustomInputSource.Controller.ConnectedStateChangedEvent", exception);
					}
				}
			}

			public string deviceName => _deviceName;

			public object customIdentifier
			{
				get
				{
					return _customIdentifier;
				}
				set
				{
					_customIdentifier = value;
				}
			}

			public Guid deviceInstanceGuid
			{
				get
				{
					return _persistentGuid;
				}
				set
				{
					_persistentGuid = value;
				}
			}

			public int buttonCount => TCulqAwArqESvuOSgtVQtCDYrEx.Length;

			public int axisCount => VWdcdmiSQKMcwgsdPOygFurKgNoV.Length;

			public IList<Element> Elements => PkgiBigaeazUuOxjAstCZYlsqKxW;

			public IList<Axis> Axes => HcngIbctmHjgFDoEYuYVNfuIebvl;

			public IList<Button> Buttons => gjoeKNSeOmXrlAKrqZvXnlEfHbsDA;

			public IList<Rewired.Controller.Extension> Extensions => fNVwdAumThiVMhDqOCsyiPdXGtRI;

			public bool supportsVibration
			{
				get
				{
					return WUlECXJXBMLMhmfEUkREHgfGRBBCb;
				}
				set
				{
					WUlECXJXBMLMhmfEUkREHgfGRBBCb = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					if (oebvosUhYbOgWHqrVaJFweoWjoIE.Count <= 0)
					{
						return null;
					}
					return oebvosUhYbOgWHqrVaJFweoWjoIE[0];
				}
				set
				{
					GYMMbZASgAVxCtftVfbqrVdrknwE();
					if (value == null)
					{
						if (oebvosUhYbOgWHqrVaJFweoWjoIE.Count != 0)
						{
							oebvosUhYbOgWHqrVaJFweoWjoIE.RemoveAt(0);
						}
					}
					else if (!oebvosUhYbOgWHqrVaJFweoWjoIE.Contains(value))
					{
						if (oebvosUhYbOgWHqrVaJFweoWjoIE.Count == 0)
						{
							AddExtension(value);
						}
						else
						{
							oebvosUhYbOgWHqrVaJFweoWjoIE[0] = value;
						}
					}
				}
			}

			public IList<Component> Components => OdszlBfzLLkggGcuVDYPRtWjaIbs;

			bool IController_Internal.active
			{
				get
				{
					return HFHpqGRMzZglzAwWLstapIjqpBy;
				}
				set
				{
					if (value != HFHpqGRMzZglzAwWLstapIjqpBy)
					{
						qhqBpkfHPcbjnwGqEftQjFFfdcnhb(value);
					}
				}
			}

			[CustomObfuscation(rename = false)]
			internal IList<string> MatchingTags => CBzcsxymYXkjOCkidtFqNqwcXCMn;

			public event Action<bool> ConnectedStateChangedEvent
			{
				add
				{
					ohNVnXFDDKHyHpMsZsHJRDfaeBkIA = (Action<bool>)Delegate.Combine(ohNVnXFDDKHyHpMsZsHJRDfaeBkIA, value);
				}
				remove
				{
					ohNVnXFDDKHyHpMsZsHJRDfaeBkIA = (Action<bool>)Delegate.Remove(ohNVnXFDDKHyHpMsZsHJRDfaeBkIA, value);
				}
			}

			[Obsolete("Deprecated", true)]
			protected Controller(string P_0)
			{
				_deviceName = P_0;
				LmRiRGExBaPVOdYEVvGJwCYgfmUV = new OdJqGDClzvhlCmnswHcatrKErHSt<Element>();
				oebvosUhYbOgWHqrVaJFweoWjoIE = new List<Rewired.Controller.Extension>();
				fNVwdAumThiVMhDqOCsyiPdXGtRI = new ReadOnlyCollection<Rewired.Controller.Extension>(oebvosUhYbOgWHqrVaJFweoWjoIE);
				laRiKQMZWjAHtqKbEOHFqaEdgytO = new AList<Component>();
				OdszlBfzLLkggGcuVDYPRtWjaIbs = new ReadOnlyCollection<Component>(laRiKQMZWjAHtqKbEOHFqaEdgytO);
				yUrKCViGBUMJdDcVdrBJjexKWfow = new AList<string>();
				CBzcsxymYXkjOCkidtFqNqwcXCMn = new ReadOnlyCollection<string>(yUrKCViGBUMJdDcVdrBJjexKWfow);
				cxgpNjDiHoqZUAkBKtrghHtTckSfA = NPDQGLAhVChqAtDrdUSaScbyXHUD();
			}

			protected Controller(InitOptions P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("initOptions");
				}
				xMcAAxgWVFwoYuzHqcCckUhUKqqW = P_0.controllerType;
				JWKMgwESUOJiJkPTgsruczsZFMkr = P_0.systemId;
				_deviceName = P_0.deviceName;
				_customName = P_0.displayName;
				LmRiRGExBaPVOdYEVvGJwCYgfmUV = new OdJqGDClzvhlCmnswHcatrKErHSt<Element>();
				oebvosUhYbOgWHqrVaJFweoWjoIE = new List<Rewired.Controller.Extension>();
				fNVwdAumThiVMhDqOCsyiPdXGtRI = new ReadOnlyCollection<Rewired.Controller.Extension>(oebvosUhYbOgWHqrVaJFweoWjoIE);
				laRiKQMZWjAHtqKbEOHFqaEdgytO = new AList<Component>();
				OdszlBfzLLkggGcuVDYPRtWjaIbs = new ReadOnlyCollection<Component>(laRiKQMZWjAHtqKbEOHFqaEdgytO);
				yUrKCViGBUMJdDcVdrBJjexKWfow = new AList<string>();
				CBzcsxymYXkjOCkidtFqNqwcXCMn = new ReadOnlyCollection<string>(yUrKCViGBUMJdDcVdrBJjexKWfow);
				cxgpNjDiHoqZUAkBKtrghHtTckSfA = NPDQGLAhVChqAtDrdUSaScbyXHUD();
			}

			internal Controller(InitOptions P_0, int P_1, int P_2)
				: this(P_0)
			{
				if (P_1 < 0)
				{
					P_1 = 0;
				}
				if (P_2 < 0)
				{
					P_2 = 0;
				}
				tskQdOBAoYAnyFBltzXKnLQbKilVA = true;
				QglgdtShddfoMtCEMsPlVJHZCxJY = P_1;
				vFSRSyUqDrHYuacWHtVqcBKlWRAn = P_2;
			}

			private void JiiCBiKgWzfJzzXjGjRHEXUjsnTT()
			{
				if (OAEHePEgGGiqFluDAJrzCoIBrtHZb)
				{
					throw new Exception("Initialize can only be called once.");
				}
				OnInitialize();
				AyvkpTxzSqTSLTGrkNQxbzTzTmQO();
				OocnKyapBUYnEdyWonUjqRmwdMkj();
				VKiDsCCQWiOPqeaGKagTTqBoZpFj();
				OAEHePEgGGiqFluDAJrzCoIBrtHZb = true;
				OnInitializationFinished();
			}

			private void AyvkpTxzSqTSLTGrkNQxbzTzTmQO()
			{
				if (fCnCCVJHRpAaSWySsgketjtpCrXQA != null)
				{
					throw new Exception("Elements can only be created once.");
				}
				IList<Element> list = new List<Element>();
				if (tskQdOBAoYAnyFBltzXKnLQbKilVA)
				{
					for (int i = 0; i < QglgdtShddfoMtCEMsPlVJHZCxJY; i++)
					{
						list.Add(new Axis());
					}
					for (int j = 0; j < vFSRSyUqDrHYuacWHtVqcBKlWRAn; j++)
					{
						list.Add(new Button());
					}
				}
				OnCreateElements(list);
				RNhiTvMlvJLtyicdxhFkeGJdTvfRA = new Dictionary<int, Element>();
				fCnCCVJHRpAaSWySsgketjtpCrXQA = new Element[list.Count];
				for (int k = 0; k < fCnCCVJHRpAaSWySsgketjtpCrXQA.Length; k++)
				{
					if (list[k] == null)
					{
						throw new ArgumentNullException("elements contains a null value.");
					}
					fCnCCVJHRpAaSWySsgketjtpCrXQA[k] = list[k];
					RNhiTvMlvJLtyicdxhFkeGJdTvfRA.Add(list[k].id, list[k]);
				}
				int count = list.Count;
				for (int l = 0; l < count; l++)
				{
					LmRiRGExBaPVOdYEVvGJwCYgfmUV.KOucDFtLofMJWjoeAMqGlTDxjOsv(list[l]);
				}
				List<Axis> list2 = new List<Axis>();
				LmRiRGExBaPVOdYEVvGJwCYgfmUV.OHEHlXZPJCgERQSnmAhWJtAoRypO(list2);
				VWdcdmiSQKMcwgsdPOygFurKgNoV = list2.ToArray();
				HcngIbctmHjgFDoEYuYVNfuIebvl = new ReadOnlyCollection<Axis>(VWdcdmiSQKMcwgsdPOygFurKgNoV);
				List<Button> list3 = new List<Button>();
				LmRiRGExBaPVOdYEVvGJwCYgfmUV.OHEHlXZPJCgERQSnmAhWJtAoRypO(list3);
				TCulqAwArqESvuOSgtVQtCDYrEx = list3.ToArray();
				gjoeKNSeOmXrlAKrqZvXnlEfHbsDA = new ReadOnlyCollection<Button>(TCulqAwArqESvuOSgtVQtCDYrEx);
				PkgiBigaeazUuOxjAstCZYlsqKxW = new ReadOnlyCollection<Element>(fCnCCVJHRpAaSWySsgketjtpCrXQA);
				for (int m = 0; m < fCnCCVJHRpAaSWySsgketjtpCrXQA.Length; m++)
				{
					fCnCCVJHRpAaSWySsgketjtpCrXQA[m].HVsmEDQAYEmcHUVfEBgRfTpZueqg();
				}
			}

			private void OocnKyapBUYnEdyWonUjqRmwdMkj()
			{
				List<Component> list = new List<Component>();
				OnCreateComponents(list);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i] != null)
					{
						if (list[i] is IVibrationComponent)
						{
							WUlECXJXBMLMhmfEUkREHgfGRBBCb = true;
						}
						if (!laRiKQMZWjAHtqKbEOHFqaEdgytO.Contains(list[i]))
						{
							laRiKQMZWjAHtqKbEOHFqaEdgytO.Add(list[i]);
							list[i].tQsUvjqOoVEQmwuKAyQGXCDktplr();
						}
					}
				}
			}

			private void VKiDsCCQWiOPqeaGKagTTqBoZpFj()
			{
				List<Rewired.Controller.Extension> list = new List<Rewired.Controller.Extension>();
				OnCreateExtensions(list);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i] != null)
					{
						AddExtension(list[i]);
					}
				}
			}

			public void Disconnect()
			{
				if (_isConnected)
				{
					isConnected = false;
				}
			}

			public void Connect()
			{
				if (!_isConnected)
				{
					isConnected = true;
				}
			}

			public abstract void Update();

			[CustomObfuscation(rename = false)]
			internal void Update2()
			{
				if (!OAEHePEgGGiqFluDAJrzCoIBrtHZb)
				{
					throw new Exception("Not initialized.");
				}
				if (_isConnected)
				{
					seWGLQaPDqYMmVtRAybEHfhgSgUI();
					Update();
					zxebZrsAHAascyhyofkUkPibFBetA();
				}
			}

			private void seWGLQaPDqYMmVtRAybEHfhgSgUI()
			{
				for (int i = 0; i < fCnCCVJHRpAaSWySsgketjtpCrXQA.Length; i++)
				{
					if (fCnCCVJHRpAaSWySsgketjtpCrXQA[i] != null)
					{
						fCnCCVJHRpAaSWySsgketjtpCrXQA[i].docDaJHQfMeBmgQMJdFNDlwVsSxzb();
					}
				}
				OnBeforeUpdate();
			}

			private void zxebZrsAHAascyhyofkUkPibFBetA()
			{
				for (int i = 0; i < laRiKQMZWjAHtqKbEOHFqaEdgytO._count; i++)
				{
					if (laRiKQMZWjAHtqKbEOHFqaEdgytO._items[i] != null)
					{
						laRiKQMZWjAHtqKbEOHFqaEdgytO._items[i].JFQkYuWcjvcAhXBdaOokBSseevPu();
					}
				}
				OnAfterUpdate();
			}

			public TElement GetElement<TElement>(int elementIndex) where TElement : class
			{
				if (!LmRiRGExBaPVOdYEVvGJwCYgfmUV.mfEBRtIIjVnfWYkuHSKXWZLsVFHq<TElement>(elementIndex, out var result))
				{
					return null;
				}
				return result;
			}

			public Element GetElementById(int elementId)
			{
				if (RNhiTvMlvJLtyicdxhFkeGJdTvfRA.TryGetValue(elementId, out var value))
				{
					return value;
				}
				return null;
			}

			public TElement GetElementById<TElement>(int elementId) where TElement : class
			{
				return GetElementById(elementId) as TElement;
			}

			public int GetElementCount<TElement>() where TElement : class
			{
				return LmRiRGExBaPVOdYEVvGJwCYgfmUV.EaTCbzYLAxiLJNIHvpiCkaSvEbPBA<TElement>();
			}

			public int GetElements<TElement>(IList<TElement> results) where TElement : class
			{
				return LmRiRGExBaPVOdYEVvGJwCYgfmUV.OHEHlXZPJCgERQSnmAhWJtAoRypO(results);
			}

			public T GetComponent<T>() where T : class
			{
				for (int i = 0; i < laRiKQMZWjAHtqKbEOHFqaEdgytO._count; i++)
				{
					if (laRiKQMZWjAHtqKbEOHFqaEdgytO._items[i] is T result)
					{
						return result;
					}
				}
				return null;
			}

			public int GetComponents<T>(IList<T> results) where T : class
			{
				if (results == null)
				{
					throw new ArgumentNullException("results");
				}
				int count = results.Count;
				for (int i = 0; i < laRiKQMZWjAHtqKbEOHFqaEdgytO._count; i++)
				{
					if (laRiKQMZWjAHtqKbEOHFqaEdgytO._items[i] is T item)
					{
						results.Add(item);
					}
				}
				return results.Count - count;
			}

			public virtual void Clear()
			{
				for (int i = 0; i < fCnCCVJHRpAaSWySsgketjtpCrXQA.Length; i++)
				{
					fCnCCVJHRpAaSWySsgketjtpCrXQA[i].Clear();
				}
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= VWdcdmiSQKMcwgsdPOygFurKgNoV.Length)
				{
					return 0f;
				}
				return VWdcdmiSQKMcwgsdPOygFurKgNoV[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= TCulqAwArqESvuOSgtVQtCDYrEx.Length)
				{
					return false;
				}
				return TCulqAwArqESvuOSgtVQtCDYrEx[index].boolValue;
			}

			public virtual float GetButtonFloatValue(int index)
			{
				if (index < 0 || index >= TCulqAwArqESvuOSgtVQtCDYrEx.Length)
				{
					return 0f;
				}
				return TCulqAwArqESvuOSgtVQtCDYrEx[index].floatValue;
			}

			public virtual void SetAxisValue(int index, float value)
			{
				if (index >= 0 && index < VWdcdmiSQKMcwgsdPOygFurKgNoV.Length)
				{
					VWdcdmiSQKMcwgsdPOygFurKgNoV[index].SetValue(value);
				}
			}

			public virtual void SetButtonValue(int index, bool value)
			{
				if (index >= 0 && index < TCulqAwArqESvuOSgtVQtCDYrEx.Length)
				{
					TCulqAwArqESvuOSgtVQtCDYrEx[index].boolValue = value;
				}
			}

			public virtual void SetButtonFloatValue(int index, float value)
			{
				if (index >= 0 && index < TCulqAwArqESvuOSgtVQtCDYrEx.Length)
				{
					TCulqAwArqESvuOSgtVQtCDYrEx[index].floatValue = value;
				}
			}

			internal virtual void DTOFtSrBjOzJoQqGgxAfQNpcOszS(int P_0, out bool P_1, out float P_2)
			{
				if (P_0 < 0 || P_0 >= TCulqAwArqESvuOSgtVQtCDYrEx.Length)
				{
					P_1 = false;
					P_2 = 0f;
				}
				else
				{
					P_1 = TCulqAwArqESvuOSgtVQtCDYrEx[P_0].sbbQipmxsrosWJdLPBcCAmtRxbLWA;
					P_2 = TCulqAwArqESvuOSgtVQtCDYrEx[P_0].floatValue;
				}
			}

			public bool AddExtension(Rewired.Controller.Extension extension)
			{
				if (extension == null)
				{
					throw new ArgumentNullException("extension");
				}
				GYMMbZASgAVxCtftVfbqrVdrknwE();
				if (oebvosUhYbOgWHqrVaJFweoWjoIE.Contains(extension))
				{
					return false;
				}
				oebvosUhYbOgWHqrVaJFweoWjoIE.Add(extension);
				uFuRQCkClijZomWIrESsuZIxCJWL();
				return true;
			}

			protected virtual bool AddMatchingTag(string tag)
			{
				if (string.IsNullOrEmpty(tag))
				{
					return false;
				}
				if (yUrKCViGBUMJdDcVdrBJjexKWfow.Contains(tag))
				{
					return false;
				}
				yUrKCViGBUMJdDcVdrBJjexKWfow.Add(tag);
				return true;
			}

			protected virtual void OnInitialize()
			{
			}

			protected virtual void OnDeinitialize()
			{
			}

			protected virtual void OnInitializationFinished()
			{
			}

			protected virtual void OnCreateElements(IList<Element> elements)
			{
			}

			protected virtual void OnCreateComponents(IList<Component> components)
			{
			}

			protected virtual void OnCreateExtensions(IList<Rewired.Controller.Extension> extensions)
			{
			}

			protected virtual void OnBeforeUpdate()
			{
			}

			protected virtual void OnAfterUpdate()
			{
			}

			private void qhqBpkfHPcbjnwGqEftQjFFfdcnhb(bool P_0)
			{
				if (P_0 && !OAEHePEgGGiqFluDAJrzCoIBrtHZb)
				{
					JiiCBiKgWzfJzzXjGjRHEXUjsnTT();
				}
				HFHpqGRMzZglzAwWLstapIjqpBy = P_0;
			}

			private void uFuRQCkClijZomWIrESsuZIxCJWL()
			{
				if (WUlECXJXBMLMhmfEUkREHgfGRBBCb)
				{
					return;
				}
				for (int i = 0; i < oebvosUhYbOgWHqrVaJFweoWjoIE.Count; i++)
				{
					if (oebvosUhYbOgWHqrVaJFweoWjoIE[i] is IControllerVibrator)
					{
						WUlECXJXBMLMhmfEUkREHgfGRBBCb = true;
						break;
					}
				}
			}

			private void GYMMbZASgAVxCtftVfbqrVdrknwE()
			{
				if (OAEHePEgGGiqFluDAJrzCoIBrtHZb)
				{
					throw new NotSupportedException("Controller is already initialized.");
				}
			}

			protected virtual void Dispose(bool disposing)
			{
				if (kFlMltlajMldVfQlZgwxYKBytMKd)
				{
					return;
				}
				if (disposing)
				{
					for (int i = 0; i < laRiKQMZWjAHtqKbEOHFqaEdgytO._count; i++)
					{
						((IDisposable)laRiKQMZWjAHtqKbEOHFqaEdgytO._items[i]).Dispose();
					}
					OnDeinitialize();
				}
				kFlMltlajMldVfQlZgwxYKBytMKd = true;
			}

			void IDisposable.Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}

			private static int NPDQGLAhVChqAtDrdUSaScbyXHUD()
			{
				return WhSHzAUPoHKdnPDKLVaJbvQQlJwn++;
			}
		}

		public abstract class Joystick : Controller
		{
			public new class InitOptions : Controller.InitOptions
			{
				public InitOptions()
					: base(ControllerType.Joystick)
				{
				}
			}

			private int PlJEsuBOkSmmiixJMadIuYmFnJu;

			public int unityId
			{
				get
				{
					return PlJEsuBOkSmmiixJMadIuYmFnJu;
				}
				protected set
				{
					PlJEsuBOkSmmiixJMadIuYmFnJu = value;
				}
			}

			protected Joystick(string P_0, long P_1, int P_2, int P_3)
				: this(P_0, P_1, 0, P_2, P_3)
			{
			}

			public Joystick(string P_0, long? P_1, int P_2, int P_3, int P_4)
				: base(new InitOptions
				{
					deviceName = P_0,
					systemId = P_1
				}, P_3, P_4)
			{
				PlJEsuBOkSmmiixJMadIuYmFnJu = P_2;
			}

			public Joystick(InitOptions P_0)
				: base(P_0)
			{
			}
		}

		public abstract class UnifiedKeyboard : Controller
		{
			public new class InitOptions : Controller.InitOptions
			{
				public InitOptions()
					: base(ControllerType.Keyboard)
				{
				}
			}

			public const int fixedKeyCount = 132;

			protected UnifiedKeyboard()
				: this(new InitOptions
				{
					deviceName = "Keyboard"
				})
			{
			}

			protected UnifiedKeyboard(InitOptions P_0)
				: base(P_0)
			{
			}

			protected override void OnCreateElements(IList<Element> elements)
			{
				base.OnCreateElements(elements);
				for (int i = 0; i < 132; i++)
				{
					elements.Add(new Button());
				}
			}

			protected virtual void SetKeyLabel(KeyboardKeyCode keycode, string label)
			{
				Keyboard.SetKeyName(keycode, label);
			}

			protected virtual void SetKeyLabel(ModifierKey modifierKey, string shortLabel, string longLabel)
			{
				Keyboard.SetModifierKeyName(modifierKey, shortLabel, longLabel);
			}
		}

		public abstract class UnifiedMouse : Controller
		{
			public new class InitOptions : Controller.InitOptions
			{
				public InitOptions()
					: base(ControllerType.Mouse)
				{
				}
			}

			public const int fixedButtonCount = 7;

			public const int fixedAxisCount = 4;

			public const int axisIndex_x = 0;

			public const int axisIndex_y = 1;

			public const int axisIndex_wheelY = 2;

			public const int axisIndex_wheelX = 3;

			public const int buttonIndex_left = 0;

			public const int buttonIndex_right = 1;

			public const int buttonIndex_middle = 2;

			public const int buttonIndex_back = 3;

			public const int buttonIndex_forward = 4;

			public const int vector2Index_screenPosition = 0;

			protected UnifiedMouse()
				: this(new InitOptions
				{
					deviceName = "Mouse"
				})
			{
			}

			protected UnifiedMouse(InitOptions P_0)
				: base(P_0)
			{
			}

			protected override void OnCreateElements(IList<Element> elements)
			{
				base.OnCreateElements(elements);
				for (int i = 0; i < 4; i++)
				{
					elements.Add(new Axis(new Axis.InitOptions
					{
						coordinateMode = AxisCoordinateMode.Relative
					}));
				}
				for (int j = 0; j < 7; j++)
				{
					elements.Add(new Button());
				}
				elements.Add(new Vector2Element());
			}
		}

		public abstract class Element
		{
			public abstract class InitOptions
			{
			}

			private int FpdkdHiICGNTIdGxlbIHgGfWNuseA;

			private double hBmVQpQuwYnalPndiflvEAodppux;

			private bool bYBWwMdYcvMtNwSurObVQhPdGXbw;

			private bool lObuDrNEhqGYFPgToNKKDRnxzzpA;

			private static int SRmXfNydZbMatJGkUkciLqrydQfP = 0;

			private static readonly Type[] xXACUVhbSxkAYYULFPDGCqTJtRJMA = new Type[3]
			{
				typeof(Button),
				typeof(Axis),
				typeof(Vector2Element)
			};

			public int id => FpdkdHiICGNTIdGxlbIHgGfWNuseA;

			public double lastModifiedTime => hBmVQpQuwYnalPndiflvEAodppux;

			public bool excludeFromPolling
			{
				get
				{
					return lObuDrNEhqGYFPgToNKKDRnxzzpA;
				}
				set
				{
					lObuDrNEhqGYFPgToNKKDRnxzzpA = value;
				}
			}

			protected Element()
			{
				FpdkdHiICGNTIdGxlbIHgGfWNuseA = XnIbndUZJNShukMibmdMDhAEYNuQ();
			}

			protected Element(InitOptions P_0)
				: this()
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("options");
				}
			}

			internal Element(Element P_0)
				: this()
			{
				bYBWwMdYcvMtNwSurObVQhPdGXbw = P_0.bYBWwMdYcvMtNwSurObVQhPdGXbw;
				hBmVQpQuwYnalPndiflvEAodppux = P_0.hBmVQpQuwYnalPndiflvEAodppux;
				lObuDrNEhqGYFPgToNKKDRnxzzpA = P_0.lObuDrNEhqGYFPgToNKKDRnxzzpA;
			}

			public virtual void Clear()
			{
				kqWANTEpoIJdjYpSnWDWVbTeIJiz();
			}

			internal virtual void docDaJHQfMeBmgQMJdFNDlwVsSxzb()
			{
			}

			internal void kqWANTEpoIJdjYpSnWDWVbTeIJiz()
			{
				hBmVQpQuwYnalPndiflvEAodppux = ReInput.time.unscaledTime;
			}

			internal void bDByxulouiMDwrRnNZttrLTjDBHH(double P_0)
			{
				hBmVQpQuwYnalPndiflvEAodppux = P_0;
			}

			internal void HVsmEDQAYEmcHUVfEBgRfTpZueqg()
			{
				if (!bYBWwMdYcvMtNwSurObVQhPdGXbw)
				{
					bYBWwMdYcvMtNwSurObVQhPdGXbw = true;
					Clear();
				}
			}

			private static int XnIbndUZJNShukMibmdMDhAEYNuQ()
			{
				return SRmXfNydZbMatJGkUkciLqrydQfP++;
			}

			internal static Type tWRyUGzzpQkGoFNmfVIRPJcICkro(Type P_0)
			{
				for (int i = 0; i < xXACUVhbSxkAYYULFPDGCqTJtRJMA.Length; i++)
				{
					if (ReflectionTools.DoesTypeImplement(P_0, xXACUVhbSxkAYYULFPDGCqTJtRJMA[i]))
					{
						return xXACUVhbSxkAYYULFPDGCqTJtRJMA[i];
					}
				}
				return P_0;
			}
		}

		public abstract class Element<TValue> : Element
		{
			public new class InitOptions : Element.InitOptions
			{
				private TValue rzlXDFJFuBZWjTfnNAOkNDQnScxF;

				public virtual TValue defaultValue
				{
					get
					{
						return rzlXDFJFuBZWjTfnNAOkNDQnScxF;
					}
					set
					{
						rzlXDFJFuBZWjTfnNAOkNDQnScxF = value;
					}
				}

				public InitOptions()
				{
					rzlXDFJFuBZWjTfnNAOkNDQnScxF = default(TValue);
				}
			}

			private TValue HJWdIWbLyzFuPCQsKMrvokeyJAXE;

			private TValue DHBkoblQUEmebnJJavzIALqBvPwN;

			public TValue defaultValue => DHBkoblQUEmebnJJavzIALqBvPwN;

			protected Element()
			{
			}

			protected Element(InitOptions P_0)
				: base(P_0)
			{
				DHBkoblQUEmebnJJavzIALqBvPwN = P_0.defaultValue;
			}

			internal Element(Element<TValue> P_0)
				: base(P_0)
			{
				HJWdIWbLyzFuPCQsKMrvokeyJAXE = P_0.HJWdIWbLyzFuPCQsKMrvokeyJAXE;
				DHBkoblQUEmebnJJavzIALqBvPwN = P_0.DHBkoblQUEmebnJJavzIALqBvPwN;
			}

			internal virtual TValue RthfpedDiRsBEvUPHXEgMdHsFzBsA()
			{
				return HJWdIWbLyzFuPCQsKMrvokeyJAXE;
			}

			public virtual void SetValue(TValue value)
			{
				HJWdIWbLyzFuPCQsKMrvokeyJAXE = value;
				kqWANTEpoIJdjYpSnWDWVbTeIJiz();
			}

			public virtual void SetValue(TValue value, double timestamp)
			{
				HJWdIWbLyzFuPCQsKMrvokeyJAXE = value;
				bDByxulouiMDwrRnNZttrLTjDBHH(timestamp);
			}

			public override void Clear()
			{
				base.Clear();
				SetValue(DHBkoblQUEmebnJJavzIALqBvPwN);
			}
		}

		public class Axis : Element<float>
		{
			public new class InitOptions : Element<float>.InitOptions
			{
				private AxisCoordinateMode FcKkmobYZEhsdBWkvgFuNMIolgWA;

				public AxisCoordinateMode coordinateMode
				{
					get
					{
						return FcKkmobYZEhsdBWkvgFuNMIolgWA;
					}
					set
					{
						FcKkmobYZEhsdBWkvgFuNMIolgWA = value;
					}
				}

				public InitOptions()
				{
					FcKkmobYZEhsdBWkvgFuNMIolgWA = AxisCoordinateMode.Absolute;
				}
			}

			public float value;

			private AxisCoordinateMode uzSLbvFhQHglOBBZooRlTVyAhjTf;

			public AxisCoordinateMode coordinateMode => uzSLbvFhQHglOBBZooRlTVyAhjTf;

			public Axis()
			{
			}

			public Axis(InitOptions P_0)
				: base((Element<float>.InitOptions)P_0)
			{
				uzSLbvFhQHglOBBZooRlTVyAhjTf = P_0.coordinateMode;
			}

			internal Axis(Axis P_0)
				: base((Element<float>)P_0)
			{
				uzSLbvFhQHglOBBZooRlTVyAhjTf = P_0.uzSLbvFhQHglOBBZooRlTVyAhjTf;
			}

			public override void SetValue(float value)
			{
				base.SetValue(value);
				this.value = value;
			}

			public override void SetValue(float value, double timestamp)
			{
				base.SetValue(value, timestamp);
				this.value = value;
			}
		}

		public class Button : Element<Button.Value>
		{
			public struct Value
			{
				public bool boolValue;

				public float floatValue;

				public Value(bool P_0, float P_1)
				{
					boolValue = P_0;
					floatValue = P_1;
				}
			}

			public new class InitOptions : Element<Value>.InitOptions
			{
				private bool mMZHSYftCUntqEQNcpDNSeOfZJpP;

				public bool isPressureSensitive
				{
					get
					{
						return mMZHSYftCUntqEQNcpDNSeOfZJpP;
					}
					set
					{
						mMZHSYftCUntqEQNcpDNSeOfZJpP = value;
					}
				}
			}

			[Obsolete("Deprecated. Use boolValue instead.", false)]
			public bool value;

			private bool fnzcgCBTOdMycZhoINbYBLjScsOR;

			private bool WDmjPgNMnVxbvjTnVwPrmokZjsXL;

			public virtual bool boolValue
			{
				get
				{
					return value;
				}
				set
				{
					SetValue(new Value(value, RthfpedDiRsBEvUPHXEgMdHsFzBsA().floatValue));
				}
			}

			public virtual float floatValue
			{
				get
				{
					return RthfpedDiRsBEvUPHXEgMdHsFzBsA().floatValue;
				}
				set
				{
					SetValue(new Value(this.value, value));
				}
			}

			public virtual bool isPressureSensitive => WDmjPgNMnVxbvjTnVwPrmokZjsXL;

			internal bool sbbQipmxsrosWJdLPBcCAmtRxbLWA
			{
				get
				{
					if (!value)
					{
						return fnzcgCBTOdMycZhoINbYBLjScsOR;
					}
					return true;
				}
			}

			public Button()
			{
			}

			public Button(InitOptions P_0)
				: base((Element<Value>.InitOptions)P_0)
			{
				WDmjPgNMnVxbvjTnVwPrmokZjsXL = P_0.isPressureSensitive;
			}

			internal Button(Button P_0)
				: base((Element<Value>)P_0)
			{
				value = P_0.value;
				fnzcgCBTOdMycZhoINbYBLjScsOR = P_0.fnzcgCBTOdMycZhoINbYBLjScsOR;
				WDmjPgNMnVxbvjTnVwPrmokZjsXL = P_0.isPressureSensitive;
			}

			public override void SetValue(Value value)
			{
				vyjkvUTuWLzSuYtQZWNbpbzkdehH(value.boolValue);
				base.SetValue(value);
				this.value = value.boolValue;
			}

			public override void SetValue(Value value, double timestamp)
			{
				vyjkvUTuWLzSuYtQZWNbpbzkdehH(value.boolValue);
				base.SetValue(value, timestamp);
				this.value = value.boolValue;
			}

			private void vyjkvUTuWLzSuYtQZWNbpbzkdehH(bool P_0)
			{
				if (!fnzcgCBTOdMycZhoINbYBLjScsOR && !value && P_0)
				{
					fnzcgCBTOdMycZhoINbYBLjScsOR = true;
				}
			}

			public override void Clear()
			{
				base.Clear();
				fnzcgCBTOdMycZhoINbYBLjScsOR = false;
			}

			internal virtual void deoCrpSTMTAcCfFSidnchoxMROVBA()
			{
				fnzcgCBTOdMycZhoINbYBLjScsOR = false;
			}
		}

		public class Vector2Element : Element<Vector2>
		{
			public new class InitOptions : Element<Vector2>.InitOptions
			{
				private AxisCoordinateMode QAnMKPIqIWrGSdKpahITFxDVYWbiA;

				public AxisCoordinateMode coordinateMode
				{
					get
					{
						return QAnMKPIqIWrGSdKpahITFxDVYWbiA;
					}
					set
					{
						QAnMKPIqIWrGSdKpahITFxDVYWbiA = value;
					}
				}

				public InitOptions()
				{
					QAnMKPIqIWrGSdKpahITFxDVYWbiA = AxisCoordinateMode.Absolute;
				}
			}

			private AxisCoordinateMode bLjBcnrMxfeBbDmWGXmcdTayLqinA;

			public AxisCoordinateMode coordinateMode => bLjBcnrMxfeBbDmWGXmcdTayLqinA;

			public Vector2Element()
			{
			}

			public Vector2Element(InitOptions P_0)
				: base((Element<Vector2>.InitOptions)P_0)
			{
				bLjBcnrMxfeBbDmWGXmcdTayLqinA = P_0.coordinateMode;
			}

			internal Vector2Element(Vector2Element P_0)
				: base((Element<Vector2>)P_0)
			{
				bLjBcnrMxfeBbDmWGXmcdTayLqinA = P_0.coordinateMode;
			}
		}

		public class Vector3Element : Element<Vector3>
		{
			public new class InitOptions : Element<Vector3>.InitOptions
			{
				private AxisCoordinateMode lBFZpfMutHSiiDevkUVVsaQbtglw;

				public AxisCoordinateMode coordinateMode
				{
					get
					{
						return lBFZpfMutHSiiDevkUVVsaQbtglw;
					}
					set
					{
						lBFZpfMutHSiiDevkUVVsaQbtglw = value;
					}
				}

				public InitOptions()
				{
					lBFZpfMutHSiiDevkUVVsaQbtglw = AxisCoordinateMode.Absolute;
				}
			}

			private AxisCoordinateMode AuEsQlaQjSTFchZcbFaXUYzDzvaE;

			public AxisCoordinateMode coordinateMode => AuEsQlaQjSTFchZcbFaXUYzDzvaE;

			public Vector3Element()
			{
			}

			public Vector3Element(InitOptions P_0)
				: base((Element<Vector3>.InitOptions)P_0)
			{
				AuEsQlaQjSTFchZcbFaXUYzDzvaE = P_0.coordinateMode;
			}

			internal Vector3Element(Vector3Element P_0)
				: base((Element<Vector3>)P_0)
			{
				AuEsQlaQjSTFchZcbFaXUYzDzvaE = P_0.coordinateMode;
			}
		}

		public class QuaternionElement : Element<Quaternion>
		{
			public new class InitOptions : Element<Quaternion>.InitOptions
			{
			}

			public QuaternionElement()
			{
			}

			public QuaternionElement(InitOptions P_0)
				: base((Element<Quaternion>.InitOptions)P_0)
			{
			}

			internal QuaternionElement(QuaternionElement P_0)
				: base((Element<Quaternion>)P_0)
			{
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		internal interface IController_Internal
		{
			bool active { get; set; }
		}

		private abstract class jWtbGAdvUkDAmIeIaGpvOatkiAqM
		{
			public readonly Controller VtyoYxflPjSuTDJxSIijpJHjZKXW;

			public readonly InputSource GzoDcMFMKJRqieoAiMoxLqdwLYMSA;

			public readonly HardwareControllerMap_Game nBjFsBTUSUnuBnoFynJqGWOhWdzC;

			public jWtbGAdvUkDAmIeIaGpvOatkiAqM(Controller P_0, InputSource P_1, HardwareControllerMap_Game P_2)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("controller");
				}
				VtyoYxflPjSuTDJxSIijpJHjZKXW = P_0;
				GzoDcMFMKJRqieoAiMoxLqdwLYMSA = P_1;
				nBjFsBTUSUnuBnoFynJqGWOhWdzC = P_2;
				if (P_0.buttonCount != P_2.buttonCount)
				{
					string[] obj = new string[5] { "Incorrect button count in controller. Expected ", null, null, null, null };
					int buttonCount = P_2.buttonCount;
					obj[1] = buttonCount.ToString();
					obj[2] = " buttons. Found ";
					obj[3] = P_0.buttonCount.ToString();
					obj[4] = ".";
					throw new Exception(string.Concat(obj));
				}
				if (P_0.axisCount != P_2.axisCount)
				{
					string[] obj2 = new string[5] { "Incorrect axis count in controller. Expected ", null, null, null, null };
					int buttonCount = P_2.axisCount;
					obj2[1] = buttonCount.ToString();
					obj2[2] = " axes. Found ";
					obj2[3] = P_0.axisCount.ToString();
					obj2[4] = ".";
					throw new Exception(string.Concat(obj2));
				}
			}
		}

		private class FFcHwkAKhRqzwCCsEfTxjunRgWvc : jWtbGAdvUkDAmIeIaGpvOatkiAqM, IUnifiedKeyboardSource
		{
			InputSource IUnifiedKeyboardSource.inputSource => GzoDcMFMKJRqieoAiMoxLqdwLYMSA;

			HardwareControllerMap_Game IUnifiedKeyboardSource.hardwareMap => nBjFsBTUSUnuBnoFynJqGWOhWdzC;

			int IUnifiedKeyboardSource.buttonCount => VtyoYxflPjSuTDJxSIijpJHjZKXW.buttonCount;

			Rewired.Controller.Extension IUnifiedKeyboardSource.controllerExtension => VtyoYxflPjSuTDJxSIijpJHjZKXW.extension;

			public FFcHwkAKhRqzwCCsEfTxjunRgWvc(UnifiedKeyboard P_0, InputSource P_1)
				: base(P_0, P_1, UnityUnifiedKeyboardSource.CreateHardwareMap())
			{
			}

			void IUnifiedKeyboardSource.Clear()
			{
				VtyoYxflPjSuTDJxSIijpJHjZKXW.Clear();
			}

			void IUnifiedKeyboardSource.UpdateInputData(ControllerDataUpdater dataUpdater)
			{
				int buttonCount = VtyoYxflPjSuTDJxSIijpJHjZKXW.buttonCount;
				for (int i = 0; i < buttonCount; i++)
				{
					dataUpdater.buttonValues[i] = VtyoYxflPjSuTDJxSIijpJHjZKXW.GetButtonValue(i);
				}
			}
		}

		private class DTdZebRpVprdUFXUfivVNqVkbpeM : jWtbGAdvUkDAmIeIaGpvOatkiAqM, IUnifiedMouseSource
		{
			InputSource IUnifiedMouseSource.inputSource => GzoDcMFMKJRqieoAiMoxLqdwLYMSA;

			HardwareControllerMap_Game IUnifiedMouseSource.hardwareMap => nBjFsBTUSUnuBnoFynJqGWOhWdzC;

			int IUnifiedMouseSource.axisCount => VtyoYxflPjSuTDJxSIijpJHjZKXW.axisCount;

			int IUnifiedMouseSource.buttonCount => VtyoYxflPjSuTDJxSIijpJHjZKXW.buttonCount;

			Vector2 IUnifiedMouseSource.mousePosition => VtyoYxflPjSuTDJxSIijpJHjZKXW.GetElement<Vector2Element>(0).RthfpedDiRsBEvUPHXEgMdHsFzBsA();

			Rewired.Controller.Extension IUnifiedMouseSource.controllerExtension => VtyoYxflPjSuTDJxSIijpJHjZKXW.extension;

			public DTdZebRpVprdUFXUfivVNqVkbpeM(UnifiedMouse P_0, InputSource P_1)
				: base(P_0, P_1, UnityUnifiedMouseSource.CreateHardwareMap())
			{
			}

			void IUnifiedMouseSource.Clear()
			{
				VtyoYxflPjSuTDJxSIijpJHjZKXW.Clear();
			}

			void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
			{
				int buttonCount = VtyoYxflPjSuTDJxSIijpJHjZKXW.buttonCount;
				int axisCount = VtyoYxflPjSuTDJxSIijpJHjZKXW.axisCount;
				for (int i = 0; i < buttonCount; i++)
				{
					dataUpdater.buttonValues[i] = VtyoYxflPjSuTDJxSIijpJHjZKXW.GetButtonValue(i);
				}
				for (int j = 0; j < axisCount; j++)
				{
					dataUpdater.axisValues[j] = VtyoYxflPjSuTDJxSIijpJHjZKXW.GetAxisValue(j);
				}
			}
		}

		private sealed class OdJqGDClzvhlCmnswHcatrKErHSt<_0001> where _0001 : class
		{
			private readonly ADictionary<Type, AList<_0001>> KnfOGXCvhZwKanQYVzzyrCHRaxTHA;

			private readonly AList<Type> FyDUShmShLOqkLlIbAkiguZIaOCV;

			public OdJqGDClzvhlCmnswHcatrKErHSt()
			{
				KnfOGXCvhZwKanQYVzzyrCHRaxTHA = new ADictionary<Type, AList<_0001>>();
				FyDUShmShLOqkLlIbAkiguZIaOCV = new AList<Type>();
			}

			public void KOucDFtLofMJWjoeAMqGlTDxjOsv(_0001 P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("value");
				}
				Type type = P_0.GetType();
				LieEXZLNONvWgeXxHFtTQjKqgyQe(type, true).Add(P_0);
				for (int i = 0; i < FyDUShmShLOqkLlIbAkiguZIaOCV._count; i++)
				{
					if ((object)type != FyDUShmShLOqkLlIbAkiguZIaOCV[i] && ReflectionTools.DoesTypeImplement(type, FyDUShmShLOqkLlIbAkiguZIaOCV._items[i]))
					{
						((ADictionary<Type, AList<Type>>)(object)KnfOGXCvhZwKanQYVzzyrCHRaxTHA)[FyDUShmShLOqkLlIbAkiguZIaOCV[i]].Add(P_0);
					}
				}
			}

			public bool PSEjNeNceXGpJMtdgFEGdRarUUGRA(_0001 P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("value");
				}
				bool flag = false;
				for (int i = 0; i < FyDUShmShLOqkLlIbAkiguZIaOCV._count; i++)
				{
					AList<_0001> aList = ((ADictionary<Type, AList<Type>>)(object)KnfOGXCvhZwKanQYVzzyrCHRaxTHA)[FyDUShmShLOqkLlIbAkiguZIaOCV._items[i]];
					flag |= aList.Remove(P_0);
				}
				return flag;
			}

			public bool vFphbpnXdsbLmaBfwiyPrTmrxSWCA(Type P_0, int P_1, out _0001 P_2)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("type");
				}
				if (P_1 < 0)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				AList<_0001> aList = LieEXZLNONvWgeXxHFtTQjKqgyQe(P_0, false);
				if (aList == null)
				{
					P_2 = null;
					return false;
				}
				if (P_1 < aList._count)
				{
					P_2 = aList._items[P_1];
					return true;
				}
				P_2 = null;
				return false;
			}

			public bool mfEBRtIIjVnfWYkuHSKXWZLsVFHq<_0001>(int P_0, out _0001 P_1) where _0001 : class
			{
				if (vFphbpnXdsbLmaBfwiyPrTmrxSWCA(typeof(_0001), P_0, out var val))
				{
					P_1 = val as _0001;
					return P_1 != null;
				}
				P_1 = null;
				return false;
			}

			public int UJgxKFRpbBHoXZsqqixAgdxPZIAL(Type P_0, IList<_0001> P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("type");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("results");
				}
				int count = P_1.Count;
				AList<_0001> aList = LieEXZLNONvWgeXxHFtTQjKqgyQe(P_0, false);
				if (aList != null)
				{
					for (int i = 0; i < aList._count; i++)
					{
						P_1.Add(aList._items[i]);
					}
				}
				return P_1.Count - count;
			}

			public int OHEHlXZPJCgERQSnmAhWJtAoRypO<_0001>(IList<_0001> P_0) where _0001 : class
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("results");
				}
				int count = P_0.Count;
				AList<_0001> aList = LieEXZLNONvWgeXxHFtTQjKqgyQe(typeof(_0001), false);
				if (aList != null)
				{
					for (int i = 0; i < aList._count; i++)
					{
						if (aList._items[i] is _0001 item)
						{
							P_0.Add(item);
						}
					}
				}
				return P_0.Count - count;
			}

			public int fJboKObHqYfPqgMfkBUruNcGlsmP(Type P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("type");
				}
				int num = 0;
				AList<_0001> aList = LieEXZLNONvWgeXxHFtTQjKqgyQe(P_0, false);
				if (aList != null)
				{
					for (int i = 0; i < aList._count; i++)
					{
						num++;
					}
				}
				return num;
			}

			public int EaTCbzYLAxiLJNIHvpiCkaSvEbPBA<_0001>() where _0001 : class
			{
				int num = 0;
				AList<_0001> aList = LieEXZLNONvWgeXxHFtTQjKqgyQe(typeof(_0001), false);
				if (aList != null)
				{
					for (int i = 0; i < aList._count; i++)
					{
						if (aList._items[i] as _0001 != null)
						{
							num++;
						}
					}
				}
				return num;
			}

			private AList<_0001> LieEXZLNONvWgeXxHFtTQjKqgyQe(Type P_0, bool P_1)
			{
				if (KnfOGXCvhZwKanQYVzzyrCHRaxTHA.TryGetValue(P_0, out var value))
				{
					return value;
				}
				AList<_0001> aList = (P_1 ? new AList<_0001>() : null);
				for (int i = 0; i < FyDUShmShLOqkLlIbAkiguZIaOCV._count; i++)
				{
					if (ReflectionTools.DoesTypeImplement(FyDUShmShLOqkLlIbAkiguZIaOCV._items[i], P_0))
					{
						value = ((ADictionary<Type, AList<Type>>)(object)KnfOGXCvhZwKanQYVzzyrCHRaxTHA)[FyDUShmShLOqkLlIbAkiguZIaOCV._items[i]];
						if (value._count > 0 && aList == null)
						{
							aList = new AList<_0001>(value._count);
						}
						for (int j = 0; j < value._count; j++)
						{
							aList.Add(value[j]);
						}
					}
				}
				value = aList;
				if (value != null)
				{
					KnfOGXCvhZwKanQYVzzyrCHRaxTHA.Add(P_0, value);
					FyDUShmShLOqkLlIbAkiguZIaOCV.Add(P_0);
				}
				return value;
			}
		}

		private sealed class zkEuydBWBHVvQqmBjJvBUpsAixqH
		{
			public CustomInputSource NWsxTUIGETLcgHIhtdJxsrYMdOnq;

			public Controller jAzHZUfEIQuDOMFBIJQckNiwJKsbb;

			internal void yYDJqpQbDcVKCrDAvYWnhsMtGwpM(bool P_0)
			{
				NWsxTUIGETLcgHIhtdJxsrYMdOnq.awOsqKlITwsClsbAXIthQsxXCEae(jAzHZUfEIQuDOMFBIJQckNiwJKsbb, P_0);
			}
		}

		private readonly InputSource AiXGMvPQNrHqqgAfJTFKCSyJAEvib;

		private readonly List<Joystick> wsvssCHYgZEYaSwrnjssYKZrdaaHA;

		private readonly ReadOnlyCollection<Joystick> PRxyAaxkvJfFrfiwFaouDNDgCGbGA;

		private readonly AList<Controller> WXYTGbCgBPUlXQMVCGZxGTPYLSWk;

		private readonly ReadOnlyCollection<Controller> tsSxIapgnGYokVoFSodTuPGVsPND;

		private bool zkKRLbvePtFJHdgPzTyEZsXekpvn = true;

		private IUnifiedKeyboardSource HAYMURJmkhDvFXqqPgnmuQhogXLz;

		private IUnifiedMouseSource bEQPkIvLQFwjTCSmAFrrILPvIhhX;

		private readonly Dictionary<int, Action<bool>> cECRvkyRQwuVahgsaxIRrzANJFjG;

		[CompilerGenerated]
		private Action m_nUUmfeBOUVaBzZFiOdhNhThcIDsq;

		[CompilerGenerated]
		private Action m_lGFbqPgfxEkbDJPlTTcGtAWGoKeHA;

		private bool PRGwtqQegtMEcCYForQYhuGpmKpd;

		public bool useApproximateMatching
		{
			get
			{
				return zkKRLbvePtFJHdgPzTyEZsXekpvn;
			}
			protected set
			{
				zkKRLbvePtFJHdgPzTyEZsXekpvn = value;
			}
		}

		internal InputSource GaOvguNDPSzOuoeCWEAmXpkVOoKq => AiXGMvPQNrHqqgAfJTFKCSyJAEvib;

		public abstract bool isReady { get; }

		private event Action nUUmfeBOUVaBzZFiOdhNhThcIDsq
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_nUUmfeBOUVaBzZFiOdhNhThcIDsq;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_nUUmfeBOUVaBzZFiOdhNhThcIDsq, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_nUUmfeBOUVaBzZFiOdhNhThcIDsq;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_nUUmfeBOUVaBzZFiOdhNhThcIDsq, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		private event Action lGFbqPgfxEkbDJPlTTcGtAWGoKeHA
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_lGFbqPgfxEkbDJPlTTcGtAWGoKeHA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_lGFbqPgfxEkbDJPlTTcGtAWGoKeHA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_lGFbqPgfxEkbDJPlTTcGtAWGoKeHA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_lGFbqPgfxEkbDJPlTTcGtAWGoKeHA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		internal event Action eneFMtGrXzTfoFfYJWiijkYpdOIGA
		{
			add
			{
				nUUmfeBOUVaBzZFiOdhNhThcIDsq += action;
			}
			remove
			{
				nUUmfeBOUVaBzZFiOdhNhThcIDsq -= action;
			}
		}

		internal event Action EcvITUCCieqPtwuoqVbDhkSIWhql
		{
			add
			{
				lGFbqPgfxEkbDJPlTTcGtAWGoKeHA += action;
			}
			remove
			{
				lGFbqPgfxEkbDJPlTTcGtAWGoKeHA -= action;
			}
		}

		event Action IInputSource.DeviceChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		internal IUnifiedKeyboardSource kNkiwkCGFNGsPxUIStjGksYSXuwC()
		{
			return HAYMURJmkhDvFXqqPgnmuQhogXLz;
		}

		internal IUnifiedMouseSource fzeVNVbjdoenzXBHzdVDVEiBmWjg()
		{
			return bEQPkIvLQFwjTCSmAFrrILPvIhhX;
		}

		public CustomInputSource(int P_0)
		{
			if (!Enum.IsDefined(typeof(InputSource), P_0))
			{
				Logger.LogError("Unknown InputSource (" + P_0 + ")!");
			}
			AiXGMvPQNrHqqgAfJTFKCSyJAEvib = (InputSource)P_0;
			wsvssCHYgZEYaSwrnjssYKZrdaaHA = new List<Joystick>();
			PRxyAaxkvJfFrfiwFaouDNDgCGbGA = new ReadOnlyCollection<Joystick>(wsvssCHYgZEYaSwrnjssYKZrdaaHA);
			WXYTGbCgBPUlXQMVCGZxGTPYLSWk = new AList<Controller>();
			tsSxIapgnGYokVoFSodTuPGVsPND = new ReadOnlyCollection<Controller>(WXYTGbCgBPUlXQMVCGZxGTPYLSWk);
			cECRvkyRQwuVahgsaxIRrzANJFjG = new Dictionary<int, Action<bool>>();
		}

		internal CustomInputSource(int P_0, IUnifiedKeyboardSource P_1, IUnifiedMouseSource P_2)
			: this(P_0)
		{
			if (P_1 is UnifiedKeyboard)
			{
				AddController(P_1 as UnifiedKeyboard);
			}
			else
			{
				HAYMURJmkhDvFXqqPgnmuQhogXLz = P_1;
				if (P_1 is Controller)
				{
					AddController(P_1 as Controller);
				}
			}
			if (P_2 is UnifiedMouse)
			{
				AddController(P_2 as UnifiedMouse);
				return;
			}
			bEQPkIvLQFwjTCSmAFrrILPvIhhX = P_2;
			if (P_2 is Controller)
			{
				AddController(P_2 as Controller);
			}
		}

		internal virtual void xwgFJSCCAtKsEYtsyekkPgdVaXbwA()
		{
			OnInitialize();
		}

		protected virtual void OnInitialize()
		{
		}

		protected virtual void OnDeinitialize()
		{
		}

		public void AddController(Controller controller)
		{
			zkEuydBWBHVvQqmBjJvBUpsAixqH zkEuydBWBHVvQqmBjJvBUpsAixqH2 = new zkEuydBWBHVvQqmBjJvBUpsAixqH();
			zkEuydBWBHVvQqmBjJvBUpsAixqH2.NWsxTUIGETLcgHIhtdJxsrYMdOnq = this;
			zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb = controller;
			if (zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb == null)
			{
				return;
			}
			if (WXYTGbCgBPUlXQMVCGZxGTPYLSWk.Contains(zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb))
			{
				Logger.LogWarning("The controller is already in the list. Cannot add again.");
				return;
			}
			((IController_Internal)zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb).active = true;
			if (zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb is Joystick)
			{
				wsvssCHYgZEYaSwrnjssYKZrdaaHA.Add((Joystick)zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb);
			}
			else if (zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb is UnifiedKeyboard)
			{
				HAYMURJmkhDvFXqqPgnmuQhogXLz = new FFcHwkAKhRqzwCCsEfTxjunRgWvc(zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb as UnifiedKeyboard, AiXGMvPQNrHqqgAfJTFKCSyJAEvib);
			}
			else if (zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb is UnifiedMouse)
			{
				bEQPkIvLQFwjTCSmAFrrILPvIhhX = new DTdZebRpVprdUFXUfivVNqVkbpeM(zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb as UnifiedMouse, AiXGMvPQNrHqqgAfJTFKCSyJAEvib);
			}
			WXYTGbCgBPUlXQMVCGZxGTPYLSWk.Add(zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb);
			cECRvkyRQwuVahgsaxIRrzANJFjG[zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb.id] = zkEuydBWBHVvQqmBjJvBUpsAixqH2.yYDJqpQbDcVKCrDAvYWnhsMtGwpM;
			zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb.ConnectedStateChangedEvent += cECRvkyRQwuVahgsaxIRrzANJFjG[zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb.id];
			if (zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb.isConnected && zkEuydBWBHVvQqmBjJvBUpsAixqH2.jAzHZUfEIQuDOMFBIJQckNiwJKsbb is Joystick)
			{
				OnJoystickConnected();
			}
		}

		public bool RemoveController(Controller controller)
		{
			if (controller == null)
			{
				return false;
			}
			if (!WXYTGbCgBPUlXQMVCGZxGTPYLSWk.Contains(controller))
			{
				Logger.LogWarning("The controller was not found in the list. Cannot remove.");
				return false;
			}
			((IController_Internal)controller).active = false;
			if (controller is Joystick)
			{
				wsvssCHYgZEYaSwrnjssYKZrdaaHA.Remove((Joystick)controller);
			}
			else if (controller is UnifiedKeyboard)
			{
				if (HAYMURJmkhDvFXqqPgnmuQhogXLz == controller || (HAYMURJmkhDvFXqqPgnmuQhogXLz is FFcHwkAKhRqzwCCsEfTxjunRgWvc && ((FFcHwkAKhRqzwCCsEfTxjunRgWvc)HAYMURJmkhDvFXqqPgnmuQhogXLz).VtyoYxflPjSuTDJxSIijpJHjZKXW == controller))
				{
					HAYMURJmkhDvFXqqPgnmuQhogXLz = null;
				}
			}
			else if (controller is UnifiedMouse && (bEQPkIvLQFwjTCSmAFrrILPvIhhX == controller || (bEQPkIvLQFwjTCSmAFrrILPvIhhX is DTdZebRpVprdUFXUfivVNqVkbpeM && ((DTdZebRpVprdUFXUfivVNqVkbpeM)bEQPkIvLQFwjTCSmAFrrILPvIhhX).VtyoYxflPjSuTDJxSIijpJHjZKXW == controller)))
			{
				bEQPkIvLQFwjTCSmAFrrILPvIhhX = null;
			}
			WXYTGbCgBPUlXQMVCGZxGTPYLSWk.Remove(controller);
			controller.ConnectedStateChangedEvent -= cECRvkyRQwuVahgsaxIRrzANJFjG[controller.id];
			cECRvkyRQwuVahgsaxIRrzANJFjG.Remove(controller.id);
			if (controller.isConnected && controller is Joystick)
			{
				OnJoystickDisconnected();
			}
			return true;
		}

		public void AddJoystick(Joystick joystick)
		{
			AddController(joystick);
		}

		public void RemoveJoystick(Joystick joystick)
		{
			RemoveController(joystick);
		}

		public IList<Controller> GetControllers()
		{
			return tsSxIapgnGYokVoFSodTuPGVsPND;
		}

		public int GetControllers<T>(IList<T> results) where T : class
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = results.Count;
			for (int i = 0; i < WXYTGbCgBPUlXQMVCGZxGTPYLSWk._count; i++)
			{
				if (WXYTGbCgBPUlXQMVCGZxGTPYLSWk[i] is T item)
				{
					results.Add(item);
				}
			}
			return results.Count - count;
		}

		public IList<Joystick> GetJoysticks()
		{
			return PRxyAaxkvJfFrfiwFaouDNDgCGbGA;
		}

		protected virtual void OnJoystickConnected()
		{
			this.nUUmfeBOUVaBzZFiOdhNhThcIDsq?.Invoke();
		}

		protected virtual void OnJoystickDisconnected()
		{
			this.lGFbqPgfxEkbDJPlTTcGtAWGoKeHA?.Invoke();
		}

		private void awOsqKlITwsClsbAXIthQsxXCEae(Controller P_0, bool P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			if (P_1)
			{
				if (P_0.type == ControllerType.Joystick)
				{
					OnJoystickConnected();
				}
			}
			else if (P_0.type == ControllerType.Joystick)
			{
				OnJoystickDisconnected();
			}
		}

		internal Joystick[] mosvsSxQCYQKCtUYwtjJKdPSAIxP()
		{
			List<Joystick> list = new List<Joystick>(wsvssCHYgZEYaSwrnjssYKZrdaaHA.Count);
			for (int i = 0; i < wsvssCHYgZEYaSwrnjssYKZrdaaHA.Count; i++)
			{
				Joystick joystick = wsvssCHYgZEYaSwrnjssYKZrdaaHA[i];
				if (joystick != null && joystick.isConnected)
				{
					list.Add(joystick);
				}
			}
			return list.ToArray();
		}

		internal void YlwcWyFkDedgcqrVQCGbFDnSyMsU()
		{
			OnBeforeUpdate();
		}

		internal void TvmBXyQxUFceAUiYBUGpNotNkQRK()
		{
			OnAfterUpdate();
		}

		protected virtual void OnBeforeUpdate()
		{
		}

		protected virtual void OnAfterUpdate()
		{
		}

		public virtual void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~CustomInputSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (PRGwtqQegtMEcCYForQYhuGpmKpd)
			{
				return;
			}
			if (disposing)
			{
				if (HAYMURJmkhDvFXqqPgnmuQhogXLz is IDisposable)
				{
					try
					{
						(HAYMURJmkhDvFXqqPgnmuQhogXLz as IDisposable).Dispose();
					}
					catch (Exception msg)
					{
						Logger.LogError(msg);
					}
				}
				if (bEQPkIvLQFwjTCSmAFrrILPvIhhX is IDisposable)
				{
					try
					{
						(bEQPkIvLQFwjTCSmAFrrILPvIhhX as IDisposable).Dispose();
					}
					catch (Exception msg2)
					{
						Logger.LogError(msg2);
					}
				}
				for (int i = 0; i < WXYTGbCgBPUlXQMVCGZxGTPYLSWk._count; i++)
				{
					((IDisposable)WXYTGbCgBPUlXQMVCGZxGTPYLSWk[i]).Dispose();
				}
				OnDeinitialize();
			}
			PRGwtqQegtMEcCYForQYhuGpmKpd = true;
		}

		void IInputSource.SystemDeviceConnected()
		{
		}

		void IInputSource.SystemDeviceDisconnected()
		{
		}

		void IInputSource.Update()
		{
		}

		void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
		{
		}

		void IInputSource.UpdateFinished()
		{
		}

		IList<TJoy> IInputSource.GetJoysticks<TJoy>()
		{
			return null;
		}

		public abstract void Update();
	}
}
