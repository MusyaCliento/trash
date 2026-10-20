using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Interfaces;

namespace Rewired
{
	public sealed class Keyboard : ControllerWithMap
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class ModifierKeyInfo
		{
			public readonly string shortName;

			public readonly string longName;

			public readonly string shortKey;

			public readonly string longKey;

			public ModifierKeyInfo(string P_0, string P_1, string P_2, string P_3)
			{
				shortName = P_0;
				longName = P_1;
				shortKey = P_2;
				longKey = P_3;
			}

			public string GetName(bool useShort)
			{
				if (!useShort)
				{
					return longName;
				}
				return shortName;
			}

			public string GetKey(bool useShort)
			{
				if (!useShort)
				{
					return longKey;
				}
				return shortKey;
			}
		}

		private class PpBMpbvQRBWNzLSeEUIvuOInxrwy
		{
			public readonly ZIXYiaFgfZnhCqGtSbSIACCDfuEA YmHekTMDQDLfzyZMFybuwcZHDnJS;

			public readonly ZIXYiaFgfZnhCqGtSbSIACCDfuEA QMrDYCXHckcvWTvkRDkupabaaqjKA;

			public PpBMpbvQRBWNzLSeEUIvuOInxrwy(string P_0, string P_1)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					YmHekTMDQDLfzyZMFybuwcZHDnJS = new ZIXYiaFgfZnhCqGtSbSIACCDfuEA(new LocalizedString());
				}
				if (!string.IsNullOrEmpty(P_1))
				{
					QMrDYCXHckcvWTvkRDkupabaaqjKA = new ZIXYiaFgfZnhCqGtSbSIACCDfuEA(new LocalizedString());
				}
			}
		}

		private sealed class ZIXYiaFgfZnhCqGtSbSIACCDfuEA
		{
			public readonly LocalizedString JcBlqZqLfkpwXaZJTHPRnVSiEUry;

			public bool mDEPVtvWExotJnCBLSNMoBoNrsmH;

			public ZIXYiaFgfZnhCqGtSbSIACCDfuEA(LocalizedString P_0)
			{
				JcBlqZqLfkpwXaZJTHPRnVSiEUry = P_0;
			}
		}

		private sealed class iIAHOEbrEvhAgdDaDnoHaPdBgchI
		{
			public readonly KeyedGlyph GsKUjOKkocOCSiIKNkAwezXkHBBD;

			public bool yePeTIIAYEfvNEBrikBacnzGNbBwd;

			public iIAHOEbrEvhAgdDaDnoHaPdBgchI(KeyedGlyph P_0)
			{
				GsKUjOKkocOCSiIKNkAwezXkHBBD = P_0;
			}
		}

		private class wBWoflCgpAzhGjEZiRoeuwiaLFaS
		{
			private readonly ModifierKeyInfo UbggcpEQOEeBdGjwiyxjcjedwKeTd;

			private string VrUUfrgkGbdgLpJSLUvaYmfGAdJu;

			private string VXiMQXJuojmUsLbdpmMrsmaFAgb;

			public string sPdTCTuttJMBOHgDFNINFXhtpcut => UbggcpEQOEeBdGjwiyxjcjedwKeTd.shortKey;

			public string PbeEoygRXrIRGFiLEinskiuxrGArb => UbggcpEQOEeBdGjwiyxjcjedwKeTd.longKey;

			public string XCZtPSQFsdmVLmOptuSofIxBzWFe
			{
				get
				{
					if (string.IsNullOrEmpty(VrUUfrgkGbdgLpJSLUvaYmfGAdJu))
					{
						return UbggcpEQOEeBdGjwiyxjcjedwKeTd.shortName;
					}
					return VrUUfrgkGbdgLpJSLUvaYmfGAdJu;
				}
				set
				{
					VrUUfrgkGbdgLpJSLUvaYmfGAdJu = vrUUfrgkGbdgLpJSLUvaYmfGAdJu;
				}
			}

			public string CXWSPjpPMIumMaXftubDLPKMFMiU
			{
				get
				{
					if (string.IsNullOrEmpty(VXiMQXJuojmUsLbdpmMrsmaFAgb))
					{
						return UbggcpEQOEeBdGjwiyxjcjedwKeTd.longName;
					}
					return VXiMQXJuojmUsLbdpmMrsmaFAgb;
				}
				set
				{
					VXiMQXJuojmUsLbdpmMrsmaFAgb = vXiMQXJuojmUsLbdpmMrsmaFAgb;
				}
			}

			public wBWoflCgpAzhGjEZiRoeuwiaLFaS(ModifierKeyInfo P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("modifierKeyInfo");
				}
				UbggcpEQOEeBdGjwiyxjcjedwKeTd = P_0;
			}
		}

		private sealed class wPuIhtBRoVcufyGmtVoUFceEXZrD : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int PIFoLahhVVCtsZOjGSBPQybbbkmw;

			private ControllerPollingInfo sgYCBvfJYrobmCAskEQZFqfAttGnE;

			private int xEBkSczQRvUffwPMzfpYfliVTKIN;

			public Keyboard KGKbtPdyKHhGchDsyewMqdPakOOm;

			private int VXRwgfbKgwpgHFXnppOVCkagPvwC;

			private int myzSWnJCZPMiXmTdINfAxWKNGdPF;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return sgYCBvfJYrobmCAskEQZFqfAttGnE;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return sgYCBvfJYrobmCAskEQZFqfAttGnE;
				}
			}

			[DebuggerHidden]
			public wPuIhtBRoVcufyGmtVoUFceEXZrD(int P_0)
			{
				PIFoLahhVVCtsZOjGSBPQybbbkmw = P_0;
				xEBkSczQRvUffwPMzfpYfliVTKIN = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				PIFoLahhVVCtsZOjGSBPQybbbkmw = -2;
			}

			private bool MoveNext()
			{
				int pIFoLahhVVCtsZOjGSBPQybbbkmw = PIFoLahhVVCtsZOjGSBPQybbbkmw;
				Keyboard kGKbtPdyKHhGchDsyewMqdPakOOm = KGKbtPdyKHhGchDsyewMqdPakOOm;
				if (pIFoLahhVVCtsZOjGSBPQybbbkmw != 0)
				{
					if (pIFoLahhVVCtsZOjGSBPQybbbkmw != 1)
					{
						return false;
					}
					PIFoLahhVVCtsZOjGSBPQybbbkmw = -1;
					goto IL_00bf;
				}
				PIFoLahhVVCtsZOjGSBPQybbbkmw = -1;
				if (ReInput._id != kGKbtPdyKHhGchDsyewMqdPakOOm.sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(kGKbtPdyKHhGchDsyewMqdPakOOm.sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return false;
				}
				VXRwgfbKgwpgHFXnppOVCkagPvwC = Consts.keyboardKeyValues.Count;
				myzSWnJCZPMiXmTdINfAxWKNGdPF = 0;
				goto IL_00cf;
				IL_00cf:
				if (myzSWnJCZPMiXmTdINfAxWKNGdPF < VXRwgfbKgwpgHFXnppOVCkagPvwC)
				{
					KeyboardKeyCode keyboardKeyCode = (KeyboardKeyCode)Consts.keyboardKeyValues[myzSWnJCZPMiXmTdINfAxWKNGdPF];
					if (kGKbtPdyKHhGchDsyewMqdPakOOm.GetKey(keyboardKeyCode))
					{
						sgYCBvfJYrobmCAskEQZFqfAttGnE = new ControllerPollingInfo(true, -1, kGKbtPdyKHhGchDsyewMqdPakOOm.id, kGKbtPdyKHhGchDsyewMqdPakOOm._name, kGKbtPdyKHhGchDsyewMqdPakOOm._type, ControllerElementType.Button, myzSWnJCZPMiXmTdINfAxWKNGdPF, Pole.Positive, GetKeyName(keyboardKeyCode), kGKbtPdyKHhGchDsyewMqdPakOOm.asJEgTisjEcLUALQMOtkJoREArlC.buttonElementIdentifierIds[myzSWnJCZPMiXmTdINfAxWKNGdPF], keyboardKeyCode);
						PIFoLahhVVCtsZOjGSBPQybbbkmw = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				myzSWnJCZPMiXmTdINfAxWKNGdPF++;
				goto IL_00cf;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				wPuIhtBRoVcufyGmtVoUFceEXZrD wPuIhtBRoVcufyGmtVoUFceEXZrD2;
				if (PIFoLahhVVCtsZOjGSBPQybbbkmw == -2 && xEBkSczQRvUffwPMzfpYfliVTKIN == Environment.CurrentManagedThreadId)
				{
					PIFoLahhVVCtsZOjGSBPQybbbkmw = 0;
					wPuIhtBRoVcufyGmtVoUFceEXZrD2 = this;
				}
				else
				{
					wPuIhtBRoVcufyGmtVoUFceEXZrD2 = new wPuIhtBRoVcufyGmtVoUFceEXZrD(0);
					wPuIhtBRoVcufyGmtVoUFceEXZrD2.KGKbtPdyKHhGchDsyewMqdPakOOm = KGKbtPdyKHhGchDsyewMqdPakOOm;
				}
				return wPuIhtBRoVcufyGmtVoUFceEXZrD2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class htQbTInaRRBokdmjxIAXrfSEBOFkA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int dRPfQsqDZiOcfMaqUMmYKnrrFrAb;

			private ControllerPollingInfo dPXtQCIQTCzqQxlFrDZoxjHyzsuX;

			private int mVGjdeVBwQaOtgFxgyXsoqVmawrXA;

			public Keyboard zOcRzCgmGWlfGKatzvKdAsTRHaBB;

			private int wkFVrKnjCtrTDPWfrvhwelBZzFS;

			private int SKQdQDcfqjJewBokNVFMvwQsBExHb;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return dPXtQCIQTCzqQxlFrDZoxjHyzsuX;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return dPXtQCIQTCzqQxlFrDZoxjHyzsuX;
				}
			}

			[DebuggerHidden]
			public htQbTInaRRBokdmjxIAXrfSEBOFkA(int P_0)
			{
				dRPfQsqDZiOcfMaqUMmYKnrrFrAb = P_0;
				mVGjdeVBwQaOtgFxgyXsoqVmawrXA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				dRPfQsqDZiOcfMaqUMmYKnrrFrAb = -2;
			}

			private bool MoveNext()
			{
				int num = dRPfQsqDZiOcfMaqUMmYKnrrFrAb;
				Keyboard keyboard = zOcRzCgmGWlfGKatzvKdAsTRHaBB;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					dRPfQsqDZiOcfMaqUMmYKnrrFrAb = -1;
					goto IL_00bf;
				}
				dRPfQsqDZiOcfMaqUMmYKnrrFrAb = -1;
				if (ReInput._id != keyboard.sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(keyboard.sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return false;
				}
				wkFVrKnjCtrTDPWfrvhwelBZzFS = Consts.keyboardKeyValues.Count;
				SKQdQDcfqjJewBokNVFMvwQsBExHb = 0;
				goto IL_00cf;
				IL_00cf:
				if (SKQdQDcfqjJewBokNVFMvwQsBExHb < wkFVrKnjCtrTDPWfrvhwelBZzFS)
				{
					KeyboardKeyCode keyboardKeyCode = (KeyboardKeyCode)Consts.keyboardKeyValues[SKQdQDcfqjJewBokNVFMvwQsBExHb];
					if (keyboard.GetKeyDown(keyboardKeyCode))
					{
						dPXtQCIQTCzqQxlFrDZoxjHyzsuX = new ControllerPollingInfo(true, -1, keyboard.id, keyboard._name, keyboard._type, ControllerElementType.Button, SKQdQDcfqjJewBokNVFMvwQsBExHb, Pole.Positive, GetKeyName(keyboardKeyCode), keyboard.asJEgTisjEcLUALQMOtkJoREArlC.buttonElementIdentifierIds[SKQdQDcfqjJewBokNVFMvwQsBExHb], keyboardKeyCode);
						dRPfQsqDZiOcfMaqUMmYKnrrFrAb = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				SKQdQDcfqjJewBokNVFMvwQsBExHb++;
				goto IL_00cf;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				htQbTInaRRBokdmjxIAXrfSEBOFkA htQbTInaRRBokdmjxIAXrfSEBOFkA2;
				if (dRPfQsqDZiOcfMaqUMmYKnrrFrAb == -2 && mVGjdeVBwQaOtgFxgyXsoqVmawrXA == Environment.CurrentManagedThreadId)
				{
					dRPfQsqDZiOcfMaqUMmYKnrrFrAb = 0;
					htQbTInaRRBokdmjxIAXrfSEBOFkA2 = this;
				}
				else
				{
					htQbTInaRRBokdmjxIAXrfSEBOFkA2 = new htQbTInaRRBokdmjxIAXrfSEBOFkA(0);
					htQbTInaRRBokdmjxIAXrfSEBOFkA2.zOcRzCgmGWlfGKatzvKdAsTRHaBB = zOcRzCgmGWlfGKatzvKdAsTRHaBB;
				}
				return htQbTInaRRBokdmjxIAXrfSEBOFkA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private const string KBbCjkZCCSfgdgpPLckvAXWvaIsdA = " + ";

		private static Keyboard goGaBaPuWYGVNDdJcZoZhiAumFzXA;

		private static readonly KeyboardKeyCode[] kHzTpPSElZihSrJLTaRkgVjubkfhA;

		private static Guid qZqDMyersvyeOsJUgYGMBkgmXSti;

		private readonly IUnifiedKeyboardSource zbhICiGixroVetEJbRsNGxzgFGjAA;

		private ModifierKeyFlags dcfDsBItnyGUlJxJWLgrHOHaLWCd;

		private ModifierKeyFlags WbxBRpBmnGEBxshmUzGlQASpAaouA;

		private readonly int[] xLbPgmSGpGePIpSTjaEDReDxQNIJ;

		private readonly int RgDJyAaTncuPMnGXeAfzKmUcEfhX;

		private readonly XrjMaBYihmCVuHIhKxfdMqrzBSpBb kdZtFDRABxbfyiObmnmnpLqFFegXA;

		private readonly ReQicKsCJPGaIeiwqvuVFhkTNBLH klDHNsGCGoXtaxgLkcFMKceWAQIbA;

		private Dictionary<int, PpBMpbvQRBWNzLSeEUIvuOInxrwy> vRoHQVkxmkwNcKLEfuvTWZCGQECO;

		private Dictionary<int, iIAHOEbrEvhAgdDaDnoHaPdBgchI> rFYZScBZuuDRVBGDCaXJYIyYfchv;

		private Dictionary<int, wBWoflCgpAzhGjEZiRoeuwiaLFaS> XHPKBxflglEwuGrAXAVHBrSpKbEw;

		private Dictionary<int, PpBMpbvQRBWNzLSeEUIvuOInxrwy> kwjwmWjskFrFaSImnjOkFIXzubxM
		{
			get
			{
				if (vRoHQVkxmkwNcKLEfuvTWZCGQECO == null)
				{
					Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, PpBMpbvQRBWNzLSeEUIvuOInxrwy> dictionary = new Dictionary<int, PpBMpbvQRBWNzLSeEUIvuOInxrwy>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
					{
						if (item.Key != 0)
						{
							dictionary.Add(item.Key, new PpBMpbvQRBWNzLSeEUIvuOInxrwy(item.Value.shortKey, item.Value.longKey));
						}
					}
					vRoHQVkxmkwNcKLEfuvTWZCGQECO = dictionary;
				}
				return vRoHQVkxmkwNcKLEfuvTWZCGQECO;
			}
		}

		private Dictionary<int, iIAHOEbrEvhAgdDaDnoHaPdBgchI> uTnsRRoHcbUbHhgkaFxIYuGLaUGdA
		{
			get
			{
				if (rFYZScBZuuDRVBGDCaXJYIyYfchv == null)
				{
					Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, iIAHOEbrEvhAgdDaDnoHaPdBgchI> dictionary = new Dictionary<int, iIAHOEbrEvhAgdDaDnoHaPdBgchI>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
					{
						if (item.Key != 0)
						{
							iIAHOEbrEvhAgdDaDnoHaPdBgchI value = new iIAHOEbrEvhAgdDaDnoHaPdBgchI(new KeyedGlyph());
							dictionary.Add(item.Key, value);
						}
					}
					rFYZScBZuuDRVBGDCaXJYIyYfchv = dictionary;
				}
				return rFYZScBZuuDRVBGDCaXJYIyYfchv;
			}
		}

		private Dictionary<int, wBWoflCgpAzhGjEZiRoeuwiaLFaS> fuJMxpctlesCnabDPrkqMXyDYjDc
		{
			get
			{
				if (XHPKBxflglEwuGrAXAVHBrSpKbEw == null)
				{
					XHPKBxflglEwuGrAXAVHBrSpKbEw = new Dictionary<int, wBWoflCgpAzhGjEZiRoeuwiaLFaS>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in Consts.modifierKeyInfo)
					{
						XHPKBxflglEwuGrAXAVHBrSpKbEw.Add(item.Key, new wBWoflCgpAzhGjEZiRoeuwiaLFaS(item.Value));
					}
				}
				return XHPKBxflglEwuGrAXAVHBrSpKbEw;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return Guid.Empty;
				}
				return qZqDMyersvyeOsJUgYGMBkgmXSti;
			}
		}

		static Keyboard()
		{
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			kHzTpPSElZihSrJLTaRkgVjubkfhA = new KeyboardKeyCode[num];
			for (int i = 0; i < num; i++)
			{
				kHzTpPSElZihSrJLTaRkgVjubkfhA[i] = (KeyboardKeyCode)keyboardKeyValues[i];
			}
		}

		internal Keyboard(string P_0, IUnifiedKeyboardSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.hardwareMap, 132, (P_1 == null) ? null : ((P_1.controllerExtension == null) ? null : new Extension[1] { P_1.controllerExtension }), new ControllerDataUpdater(P_1.inputSource, 0, 132, null))
		{
			qZqDMyersvyeOsJUgYGMBkgmXSti = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			kdZtFDRABxbfyiObmnmnpLqFFegXA = new XrjMaBYihmCVuHIhKxfdMqrzBSpBb(delegate
			{
				IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
				for (int i = 0; i < values.Count; i++)
				{
					DZmdQJgXixfapzHvEhNEdMwMDpTV(values[i], true);
					DZmdQJgXixfapzHvEhNEdMwMDpTV(values[i], false);
				}
			});
			klDHNsGCGoXtaxgLkcFMKceWAQIbA = new ReQicKsCJPGaIeiwqvuVFhkTNBLH(delegate
			{
				IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
				for (int i = 0; i < values.Count; i++)
				{
					fzHuXhDDNVIVwvgkZsQjhRdddOGA(values[i]);
				}
			});
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int num2 = 0; num2 < num; num2++)
			{
				if (keyboardKeyValues[num2] > RgDJyAaTncuPMnGXeAfzKmUcEfhX)
				{
					RgDJyAaTncuPMnGXeAfzKmUcEfhX = keyboardKeyValues[num2];
				}
			}
			xLbPgmSGpGePIpSTjaEDReDxQNIJ = new int[RgDJyAaTncuPMnGXeAfzKmUcEfhX + 1];
			ArrayTools.Fill(xLbPgmSGpGePIpSTjaEDReDxQNIJ, -1);
			for (int num3 = 0; num3 < num; num3++)
			{
				xLbPgmSGpGePIpSTjaEDReDxQNIJ[keyboardKeyValues[num3]] = num3;
			}
			zbhICiGixroVetEJbRsNGxzgFGjAA = P_1;
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((ChutGPBICOllLFbDwaPETGCPjnpCA)kdZtFDRABxbfyiObmnmnpLqFFegXA).Localize();
			}
			if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
			{
				((IPrefetch)klDHNsGCGoXtaxgLkcFMKceWAQIbA).Prefetch();
			}
			EPRdHvMTqwabaKQBybJMATOxbzNDb();
		}

		private Keyboard(int P_0, InputSource P_1, string P_2, string P_3, HardwareControllerMap_Game P_4, int P_5, IList<Extension> P_6, ControllerDataUpdater P_7)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, P_5, null, P_4, P_6, P_7)
		{
			goGaBaPuWYGVNDdJcZoZhiAumFzXA = this;
		}

		public bool GetKey(KeyboardKeyCode keyCode)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return false;
			}
			int num = xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		public bool GetKeyDown(KeyboardKeyCode keyCode)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return false;
			}
			int num = xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justPressed;
		}

		public bool GetKeyUp(KeyboardKeyCode keyCode)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return false;
			}
			int num = xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyboardKeyCode keyCode, float speed)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return false;
			}
			int num = xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(speed);
		}

		public bool GetKeyDoublePressHold(KeyboardKeyCode keyCode)
		{
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return false;
			}
			int num = xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyboardKeyCode keyCode, float speed)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return false;
			}
			int num = xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(speed);
		}

		public bool GetKeyDoublePressDown(KeyboardKeyCode keyCode)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return false;
			}
			int num = xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyboardKeyCode keyCode)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return false;
			}
			int num = xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		public double GetKeyTimePressed(KeyboardKeyCode keyCode)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return 0.0;
			}
			int num = xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timePressed;
		}

		public double GetKeyTimeUnpressed(KeyboardKeyCode keyCode)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return 0.0;
			}
			int num = xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if (!IHjcJMUgWiVIBsQDvhyjhPEHFbTWA(out var button, out var button2, key))
			{
				return false;
			}
			if (button.value || button2.value)
			{
				return true;
			}
			return false;
		}

		public bool GetModifierKeyDown(ModifierKey key)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if (!IHjcJMUgWiVIBsQDvhyjhPEHFbTWA(out var button, out var button2, key))
			{
				return false;
			}
			if (!button.value && !button2.value)
			{
				return false;
			}
			if (button.valuePrev || button2.valuePrev)
			{
				return false;
			}
			return true;
		}

		public bool GetModifierKeyUp(ModifierKey key)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if (!IHjcJMUgWiVIBsQDvhyjhPEHFbTWA(out var button, out var button2, key))
			{
				return false;
			}
			if (button.value || button2.value)
			{
				return false;
			}
			if (!button.valuePrev && !button2.valuePrev)
			{
				return false;
			}
			return true;
		}

		public bool GetModifierKeyPrev(ModifierKey key)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if (!IHjcJMUgWiVIBsQDvhyjhPEHFbTWA(out var button, out var button2, key))
			{
				return false;
			}
			if (button.valuePrev || button2.valuePrev)
			{
				return true;
			}
			return false;
		}

		public double GetModifierKeyTimePressed(ModifierKey key)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (!IHjcJMUgWiVIBsQDvhyjhPEHFbTWA(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Max(button.timePressed, button2.timePressed);
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (!IHjcJMUgWiVIBsQDvhyjhPEHFbTWA(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
		}

		public KeyboardKeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return KeyboardKeyCode.None;
			}
			return GetKeyboardKeyCodeByButtonIndex(buttonIndex);
		}

		public KeyboardKeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return KeyboardKeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyboardKeyCode keyCode)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return -1;
			}
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return -1;
			}
			return xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyboardKeyCode keyCode)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return null;
			}
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return null;
			}
			int num = xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
			if (num < 0)
			{
				return null;
			}
			return asJEgTisjEcLUALQMOtkJoREArlC.buttonElementIdentifiers_cache[num];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyboardKeyCode keyboardKeyCode = (KeyboardKeyCode)Consts.keyboardKeyValues[i];
				if (GetKey(keyboardKeyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyboardKeyCode), asJEgTisjEcLUALQMOtkJoREArlC.buttonElementIdentifierIds[i], keyboardKeyCode);
				}
			}
			return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
		}

		[IteratorStateMachine(typeof(wPuIhtBRoVcufyGmtVoUFceEXZrD))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			return new wPuIhtBRoVcufyGmtVoUFceEXZrD(-2)
			{
				KGKbtPdyKHhGchDsyewMqdPakOOm = this
			};
		}

		[IteratorStateMachine(typeof(htQbTInaRRBokdmjxIAXrfSEBOFkA))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			return new htQbTInaRRBokdmjxIAXrfSEBOFkA(-2)
			{
				zOcRzCgmGWlfGKatzvKdAsTRHaBB = this
			};
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyboardKeyCode keyboardKeyCode = (KeyboardKeyCode)Consts.keyboardKeyValues[i];
				if (GetKeyDown(keyboardKeyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyboardKeyCode), asJEgTisjEcLUALQMOtkJoREArlC.buttonElementIdentifierIds[i], keyboardKeyCode);
				}
			}
			return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
		}

		public override ControllerPollingInfo PollForFirstButton()
		{
			return PollForFirstKey();
		}

		public override ControllerPollingInfo PollForFirstButtonDown()
		{
			return PollForFirstKeyDown();
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return PollForAllKeys();
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return PollForAllKeysDown();
		}

		public static bool IsModifierKey(KeyboardKeyCode key)
		{
			switch (key)
			{
			case KeyboardKeyCode.None:
				return false;
			case KeyboardKeyCode.RightShift:
			case KeyboardKeyCode.LeftShift:
			case KeyboardKeyCode.RightControl:
			case KeyboardKeyCode.LeftControl:
			case KeyboardKeyCode.RightAlt:
			case KeyboardKeyCode.LeftAlt:
			case KeyboardKeyCode.RightCommand:
			case KeyboardKeyCode.LeftCommand:
				return true;
			default:
				return false;
			}
		}

		public static ModifierKey KeyCodeToModifierKey(KeyboardKeyCode key)
		{
			switch (key)
			{
			case KeyboardKeyCode.None:
				return ModifierKey.None;
			case KeyboardKeyCode.RightControl:
			case KeyboardKeyCode.LeftControl:
				return ModifierKey.Control;
			case KeyboardKeyCode.RightAlt:
			case KeyboardKeyCode.LeftAlt:
				return ModifierKey.Alt;
			case KeyboardKeyCode.RightCommand:
			case KeyboardKeyCode.LeftCommand:
				return ModifierKey.Command;
			case KeyboardKeyCode.RightShift:
			case KeyboardKeyCode.LeftShift:
				return ModifierKey.Shift;
			default:
				return ModifierKey.None;
			}
		}

		public static ModifierKeyFlags KeyCodeToModifierKeyFlags(KeyboardKeyCode key)
		{
			return key switch
			{
				KeyboardKeyCode.LeftControl => ModifierKeyFlags.LeftControl, 
				KeyboardKeyCode.RightControl => ModifierKeyFlags.RightControl, 
				KeyboardKeyCode.LeftAlt => ModifierKeyFlags.LeftAlt, 
				KeyboardKeyCode.RightAlt => ModifierKeyFlags.RightAlt, 
				KeyboardKeyCode.LeftShift => ModifierKeyFlags.LeftShift, 
				KeyboardKeyCode.RightShift => ModifierKeyFlags.RightShift, 
				KeyboardKeyCode.LeftCommand => ModifierKeyFlags.LeftCommand, 
				KeyboardKeyCode.RightCommand => ModifierKeyFlags.RightCommand, 
				_ => ModifierKeyFlags.None, 
			};
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, ModifierKey key)
		{
			switch (key)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
				{
					return true;
				}
				return false;
			case ModifierKey.Alt:
				if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
				{
					return true;
				}
				return false;
			case ModifierKey.Shift:
				if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
				{
					return true;
				}
				return false;
			case ModifierKey.Command:
				if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
				{
					return true;
				}
				return false;
			default:
				return false;
			}
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, KeyboardKeyCode key)
		{
			switch (key)
			{
			case KeyboardKeyCode.None:
				return false;
			case KeyboardKeyCode.LeftControl:
				if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
				{
					return true;
				}
				return false;
			case KeyboardKeyCode.RightControl:
				if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
				{
					return true;
				}
				return false;
			case KeyboardKeyCode.LeftAlt:
				if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
				{
					return true;
				}
				return false;
			case KeyboardKeyCode.RightAlt:
				if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
				{
					return true;
				}
				return false;
			case KeyboardKeyCode.LeftShift:
				if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
				{
					return true;
				}
				return false;
			case KeyboardKeyCode.RightShift:
				if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
				{
					return true;
				}
				return false;
			case KeyboardKeyCode.LeftCommand:
				if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
				{
					return true;
				}
				return false;
			case KeyboardKeyCode.RightCommand:
				if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
				{
					return true;
				}
				return false;
			default:
				return false;
			}
		}

		public static ModifierKey ModifierKeyFlagsToModifierKey(ModifierKeyFlags flags)
		{
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				return ModifierKey.Control;
			}
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				return ModifierKey.Control;
			}
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				return ModifierKey.Alt;
			}
			if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				return ModifierKey.Alt;
			}
			if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				return ModifierKey.Shift;
			}
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				return ModifierKey.Shift;
			}
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				return ModifierKey.Command;
			}
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				return ModifierKey.Command;
			}
			return ModifierKey.None;
		}

		public static KeyboardKeyCode ModifierKeyFlagsToKeyCode(ModifierKeyFlags flags)
		{
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				return KeyboardKeyCode.LeftControl;
			}
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				return KeyboardKeyCode.RightControl;
			}
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				return KeyboardKeyCode.LeftAlt;
			}
			if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				return KeyboardKeyCode.RightAlt;
			}
			if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				return KeyboardKeyCode.LeftShift;
			}
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				return KeyboardKeyCode.RightShift;
			}
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				return KeyboardKeyCode.LeftCommand;
			}
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				return KeyboardKeyCode.RightCommand;
			}
			return KeyboardKeyCode.None;
		}

		public static ModifierKeyFlags ModifierKeyToModifierKeyFlags(ModifierKey key)
		{
			return key switch
			{
				ModifierKey.None => ModifierKeyFlags.None, 
				ModifierKey.Control => ModifierKeyFlags.LeftControl | ModifierKeyFlags.RightControl, 
				ModifierKey.Alt => ModifierKeyFlags.LeftAlt | ModifierKeyFlags.RightAlt, 
				ModifierKey.Shift => ModifierKeyFlags.LeftShift | ModifierKeyFlags.RightShift, 
				ModifierKey.Command => ModifierKeyFlags.LeftCommand | ModifierKeyFlags.RightCommand, 
				_ => ModifierKeyFlags.None, 
			};
		}

		public static string GetKeyName(KeyboardKeyCode key)
		{
			if (goGaBaPuWYGVNDdJcZoZhiAumFzXA == null)
			{
				return string.Empty;
			}
			int buttonIndex = goGaBaPuWYGVNDdJcZoZhiAumFzXA.GetButtonIndex(key);
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return goGaBaPuWYGVNDdJcZoZhiAumFzXA.ButtonElementIdentifiers[buttonIndex].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename;
		}

		public static string GetKeyName(KeyboardKeyCode key, ModifierKeyFlags flags)
		{
			string text = GetKeyName(key);
			if (flags != ModifierKeyFlags.None)
			{
				StringBuilder stringBuilder = new StringBuilder(text);
				stringBuilder.Append(" + ");
				stringBuilder.Append(ModifierKeyFlagsToString(flags));
				text = stringBuilder.ToString();
			}
			return text;
		}

		[CustomObfuscation(rename = false)]
		internal static bool SetKeyName(KeyboardKeyCode key, string name)
		{
			if (goGaBaPuWYGVNDdJcZoZhiAumFzXA == null)
			{
				return false;
			}
			if (!goGaBaPuWYGVNDdJcZoZhiAumFzXA.asJEgTisjEcLUALQMOtkJoREArlC.elementIdentifiers.TryGetValue(mQMkjPXWtGWyjRpbKRmLuvOKBwRF(key), out var value))
			{
				return false;
			}
			if (string.IsNullOrEmpty(name))
			{
				int buttonIndex = goGaBaPuWYGVNDdJcZoZhiAumFzXA.GetButtonIndex(key);
				if (buttonIndex < 0)
				{
					return false;
				}
				name = Consts.keyboardKeyNames[buttonIndex];
			}
			value.nonLocalizedName = name;
			return true;
		}

		public static string GetModifierKeyName(ModifierKey modifierKey)
		{
			if (goGaBaPuWYGVNDdJcZoZhiAumFzXA == null)
			{
				return string.Empty;
			}
			return goGaBaPuWYGVNDdJcZoZhiAumFzXA.DZmdQJgXixfapzHvEhNEdMwMDpTV(modifierKey, false);
		}

		public static string GetModifierKeyName(ModifierKey modifierKey, bool getShortName)
		{
			if (goGaBaPuWYGVNDdJcZoZhiAumFzXA == null)
			{
				return string.Empty;
			}
			return goGaBaPuWYGVNDdJcZoZhiAumFzXA.DZmdQJgXixfapzHvEhNEdMwMDpTV(modifierKey, getShortName);
		}

		[CustomObfuscation(rename = false)]
		internal static void SetModifierKeyName(ModifierKey modifierKey, string shortName, string longName)
		{
			if (goGaBaPuWYGVNDdJcZoZhiAumFzXA != null)
			{
				goGaBaPuWYGVNDdJcZoZhiAumFzXA.bAqyhCcuKmishKOgmHiacyjilYEF(modifierKey, shortName, longName);
			}
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags, bool getShortName)
		{
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			if (ModifierKeyFlagsContain(flags, ModifierKey.Control))
			{
				stringBuilder.Append(GetModifierKeyName(ModifierKey.Control, getShortName));
				num++;
			}
			if (ModifierKeyFlagsContain(flags, ModifierKey.Command))
			{
				if (num > 0)
				{
					stringBuilder.Append(" + ");
				}
				stringBuilder.Append(GetModifierKeyName(ModifierKey.Command, getShortName));
				num++;
			}
			if (ModifierKeyFlagsContain(flags, ModifierKey.Alt))
			{
				if (num > 0)
				{
					stringBuilder.Append(" + ");
				}
				stringBuilder.Append(GetModifierKeyName(ModifierKey.Alt, getShortName));
				num++;
			}
			if (num >= 3)
			{
				return stringBuilder.ToString();
			}
			if (ModifierKeyFlagsContain(flags, ModifierKey.Shift))
			{
				if (num > 0)
				{
					stringBuilder.Append(" + ");
				}
				stringBuilder.Append(GetModifierKeyName(ModifierKey.Shift, getShortName));
				num++;
			}
			return stringBuilder.ToString();
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags)
		{
			return ModifierKeyFlagsToString(flags, getShortName: false);
		}

		public static object GetModifierKeyGlyph(ModifierKey modifierKey)
		{
			if (goGaBaPuWYGVNDdJcZoZhiAumFzXA == null)
			{
				return null;
			}
			return goGaBaPuWYGVNDdJcZoZhiAumFzXA.fzHuXhDDNVIVwvgkZsQjhRdddOGA(modifierKey);
		}

		internal static string vnSFsQhJxBktFJOFsQsPyumlpSmp(ModifierKey P_0)
		{
			if (goGaBaPuWYGVNDdJcZoZhiAumFzXA == null)
			{
				return string.Empty;
			}
			return goGaBaPuWYGVNDdJcZoZhiAumFzXA.dTkBozMtqnQtPedmCkapKsHYNhJu(P_0);
		}

		internal static ModifierKeyFlags kgOKmukpCaNEFGPFbfWJGvQJdzeG(ModifierKeyFlags P_0)
		{
			if ((P_0 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				P_0 |= ModifierKeyFlags.RightControl;
			}
			if ((P_0 & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				P_0 |= ModifierKeyFlags.LeftControl;
			}
			if ((P_0 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				P_0 |= ModifierKeyFlags.RightCommand;
			}
			if ((P_0 & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				P_0 |= ModifierKeyFlags.LeftCommand;
			}
			if ((P_0 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				P_0 |= ModifierKeyFlags.RightAlt;
			}
			if ((P_0 & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				P_0 |= ModifierKeyFlags.LeftAlt;
			}
			if ((P_0 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				P_0 |= ModifierKeyFlags.RightShift;
			}
			if ((P_0 & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				P_0 |= ModifierKeyFlags.LeftShift;
			}
			return P_0;
		}

		internal static int IspoSnqwSTsuvDseaGQtnpDNPYTL(ModifierKeyFlags P_0)
		{
			if (P_0 == ModifierKeyFlags.None)
			{
				return 0;
			}
			int num = 0;
			if ((P_0 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				num++;
			}
			else if ((P_0 & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				num++;
			}
			if ((P_0 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				num++;
			}
			else if ((P_0 & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				num++;
			}
			if ((P_0 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				num++;
			}
			else if ((P_0 & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				num++;
			}
			if ((P_0 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				num++;
			}
			else if ((P_0 & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				num++;
			}
			return num;
		}

		[CustomObfuscation(rename = false)]
		internal static KeyboardKeyCode GetKeyboardKeyCodeByButtonIndex(int buttonIndex)
		{
			if ((uint)buttonIndex > 132u)
			{
				return KeyboardKeyCode.None;
			}
			return kHzTpPSElZihSrJLTaRkgVjubkfhA[buttonIndex];
		}

		internal static int mQMkjPXWtGWyjRpbKRmLuvOKBwRF(KeyboardKeyCode P_0)
		{
			int buttonIndex = goGaBaPuWYGVNDdJcZoZhiAumFzXA.GetButtonIndex(P_0);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return goGaBaPuWYGVNDdJcZoZhiAumFzXA.ButtonElementIdentifiers[buttonIndex].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid;
		}

		internal static void obvPPlbCkQRkCeHBEthsFUqbJGvK(ref int P_0, ref KeyboardKeyCode P_1)
		{
			if (P_1 != KeyboardKeyCode.None)
			{
				P_0 = mQMkjPXWtGWyjRpbKRmLuvOKBwRF(P_1);
			}
			else
			{
				P_1 = ReInput.jFidDAJTYMYSSrBGXbdjHWSiLLLfB.dqlVbgwiwbhfyZlhzyrqssSByBAe.GetKeyCodeById(P_0);
			}
		}

		internal void LsalRMsFjNitZDvQMLRggJIJbjgGb(UpdateLoopType P_0)
		{
			zbhICiGixroVetEJbRsNGxzgFGjAA.UpdateInputData(ONcPOmEPPyOeIZfvFoSEEYgzfzdq);
			base.fGrfHqFKGdZHGoihFnGZOueFayKBb(P_0);
			NnOzFwUxsBHKVqKiLFQDdUpclQvm();
		}

		internal void yZoZqbIcmDkBeWpbYEsSspMtNThW(UpdateLoopType P_0)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].ATotgcxEhwOfqwnIKjpCkFpDQrTgb(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, ONcPOmEPPyOeIZfvFoSEEYgzfzdq);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].ATotgcxEhwOfqwnIKjpCkFpDQrTgb(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, ONcPOmEPPyOeIZfvFoSEEYgzfzdq);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].ATotgcxEhwOfqwnIKjpCkFpDQrTgb(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, ONcPOmEPPyOeIZfvFoSEEYgzfzdq);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].ATotgcxEhwOfqwnIKjpCkFpDQrTgb(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, ONcPOmEPPyOeIZfvFoSEEYgzfzdq);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].ATotgcxEhwOfqwnIKjpCkFpDQrTgb(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, ONcPOmEPPyOeIZfvFoSEEYgzfzdq);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].ATotgcxEhwOfqwnIKjpCkFpDQrTgb(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, ONcPOmEPPyOeIZfvFoSEEYgzfzdq);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].ATotgcxEhwOfqwnIKjpCkFpDQrTgb(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, ONcPOmEPPyOeIZfvFoSEEYgzfzdq);
		}

		internal bool PdKAJaicAwdctwWcWxcaCpJYUmyK(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (!GetKey(P_0))
			{
				return false;
			}
			if (P_1 == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((P_1 & WbxBRpBmnGEBxshmUzGlQASpAaouA) != P_1)
			{
				return false;
			}
			double keyTimePressed = GetKeyTimePressed(P_0);
			if ((P_1 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Control))
			{
				return false;
			}
			if ((P_1 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Command))
			{
				return false;
			}
			if ((P_1 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Alt))
			{
				return false;
			}
			if ((P_1 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Shift))
			{
				return false;
			}
			return true;
		}

		internal bool pIWaZJKzoCVyIEjMzHXYGsXdjgnO(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (GetKey(P_0))
			{
				return true;
			}
			if (GetModifierKey(ModifierKeyFlagsToModifierKey(P_1)))
			{
				return true;
			}
			return false;
		}

		[CustomObfuscation(rename = false)]
		internal int GetButtonIndex(KeyboardKeyCode keyCode)
		{
			if ((uint)keyCode > (uint)RgDJyAaTncuPMnGXeAfzKmUcEfhX)
			{
				return -1;
			}
			return xLbPgmSGpGePIpSTjaEDReDxQNIJ[(int)keyCode];
		}

		[CustomObfuscation(rename = false)]
		internal void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap != null)
			{
				IList<ActionElementMap> list = controllerMap.hHYkHiBucOeDZcWyVzqWCcJcDXyr;
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					duSGjNZdSxSjezvmjyDBFGtlyxPL(controllerMap, list[i]);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			map?.ycFFstKtkKsMsNxRhfBwJdLUnnwbA(controllerMap);
		}

		internal void iPIVOfOPUraeyAaUWuiJbOaBNCnC()
		{
			base.DupAFRZPigDCXHzKZjcpbnZzkuAX();
			dcfDsBItnyGUlJxJWLgrHOHaLWCd = ModifierKeyFlags.None;
			WbxBRpBmnGEBxshmUzGlQASpAaouA = ModifierKeyFlags.None;
		}

		internal bool bqSRypNOQsKXnzfQukZFaOMkMNOo(bool P_0)
		{
			if (!base.cTAoJOVqPUVvaYThibiPDfgKvVps(P_0))
			{
				return false;
			}
			if (zbhICiGixroVetEJbRsNGxzgFGjAA is IGetSetEnabled)
			{
				(zbhICiGixroVetEJbRsNGxzgFGjAA as IGetSetEnabled).enabled = P_0;
			}
			return true;
		}

		private bool IHjcJMUgWiVIBsQDvhyjhPEHFbTWA(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			switch (P_2)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				P_0 = buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[306]];
				P_1 = buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[305]];
				return true;
			case ModifierKey.Alt:
				P_0 = buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[308]];
				P_1 = buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[307]];
				return true;
			case ModifierKey.Command:
				P_0 = buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[310]];
				P_1 = buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[309]];
				return true;
			case ModifierKey.Shift:
				P_0 = buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[304]];
				P_1 = buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[303]];
				return true;
			default:
				return false;
			}
		}

		private void NnOzFwUxsBHKVqKiLFQDdUpclQvm()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[306]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
			}
			if (buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[305]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightControl;
			}
			if (buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[310]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
			}
			if (buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[309]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightCommand;
			}
			if (buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[308]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
			}
			if (buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[307]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightAlt;
			}
			if (buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[304]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftShift;
			}
			if (buttons[xLbPgmSGpGePIpSTjaEDReDxQNIJ[303]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightShift;
			}
			dcfDsBItnyGUlJxJWLgrHOHaLWCd = modifierKeyFlags;
			WbxBRpBmnGEBxshmUzGlQASpAaouA = kgOKmukpCaNEFGPFbfWJGvQJdzeG(modifierKeyFlags);
		}

		private string DZmdQJgXixfapzHvEhNEdMwMDpTV(ModifierKey P_0, bool P_1)
		{
			if (P_0 == ModifierKey.None)
			{
				return string.Empty;
			}
			wBWoflCgpAzhGjEZiRoeuwiaLFaS wBWoflCgpAzhGjEZiRoeuwiaLFaS2 = fuJMxpctlesCnabDPrkqMXyDYjDc[(int)P_0];
			string result = (P_1 ? wBWoflCgpAzhGjEZiRoeuwiaLFaS2.XCZtPSQFsdmVLmOptuSofIxBzWFe : wBWoflCgpAzhGjEZiRoeuwiaLFaS2.CXWSPjpPMIumMaXftubDLPKMFMiU);
			if (!LocalizationManager.isEnabled)
			{
				return result;
			}
			if (!kwjwmWjskFrFaSImnjOkFIXzubxM.TryGetValue((int)P_0, out var value))
			{
				return result;
			}
			string result2;
			if (P_1)
			{
				if (value.YmHekTMDQDLfzyZMFybuwcZHDnJS != null && eZNgfNtdMZibPymgyWLkukPpivLaA(value.YmHekTMDQDLfzyZMFybuwcZHDnJS, wBWoflCgpAzhGjEZiRoeuwiaLFaS2.sPdTCTuttJMBOHgDFNINFXhtpcut, wBWoflCgpAzhGjEZiRoeuwiaLFaS2.XCZtPSQFsdmVLmOptuSofIxBzWFe, asJEgTisjEcLUALQMOtkJoREArlC.deviceLocalizationInfo, out result2))
				{
					return result2;
				}
				if (value.QMrDYCXHckcvWTvkRDkupabaaqjKA != null && eZNgfNtdMZibPymgyWLkukPpivLaA(value.QMrDYCXHckcvWTvkRDkupabaaqjKA, wBWoflCgpAzhGjEZiRoeuwiaLFaS2.PbeEoygRXrIRGFiLEinskiuxrGArb, wBWoflCgpAzhGjEZiRoeuwiaLFaS2.CXWSPjpPMIumMaXftubDLPKMFMiU, asJEgTisjEcLUALQMOtkJoREArlC.deviceLocalizationInfo, out result2))
				{
					return result2;
				}
				return result;
			}
			if (value.QMrDYCXHckcvWTvkRDkupabaaqjKA == null)
			{
				return result;
			}
			eZNgfNtdMZibPymgyWLkukPpivLaA(value.QMrDYCXHckcvWTvkRDkupabaaqjKA, wBWoflCgpAzhGjEZiRoeuwiaLFaS2.PbeEoygRXrIRGFiLEinskiuxrGArb, wBWoflCgpAzhGjEZiRoeuwiaLFaS2.CXWSPjpPMIumMaXftubDLPKMFMiU, asJEgTisjEcLUALQMOtkJoREArlC.deviceLocalizationInfo, out result2);
			return result2;
		}

		private static bool eZNgfNtdMZibPymgyWLkukPpivLaA(ZIXYiaFgfZnhCqGtSbSIACCDfuEA P_0, string P_1, string P_2, DeviceLocalizationInfo P_3, out string P_4)
		{
			LocalizationManager.GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = DTXBHoWlhfJgnmlLPGnqIDrGONgbA.oRWaUPgaSROISkCeakNywtomWkTx(P_0.JcBlqZqLfkpwXaZJTHPRnVSiEUry, P_1, "controller", P_2, P_3, QYJjXxsVdyEaAjTsqvDHkTMqFyjf.Keyboard, -1, AxisRange.Full, -1, out P_4);
			if ((getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				P_0.mDEPVtvWExotJnCBLSNMoBoNrsmH = (getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.JustLocalized) != 0;
			}
			return P_0.mDEPVtvWExotJnCBLSNMoBoNrsmH;
		}

		private void bAqyhCcuKmishKOgmHiacyjilYEF(ModifierKey P_0, string P_1, string P_2)
		{
			if (fuJMxpctlesCnabDPrkqMXyDYjDc.TryGetValue((int)P_0, out var value))
			{
				value.XCZtPSQFsdmVLmOptuSofIxBzWFe = P_1;
				value.CXWSPjpPMIumMaXftubDLPKMFMiU = P_2;
			}
		}

		private object fzHuXhDDNVIVwvgkZsQjhRdddOGA(ModifierKey P_0)
		{
			if (P_0 == ModifierKey.None)
			{
				return null;
			}
			ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)P_0];
			if (!GlyphManager.isEnabled)
			{
				return null;
			}
			if (!uTnsRRoHcbUbHhgkaFxIYuGLaUGdA.TryGetValue((int)P_0, out var value))
			{
				return null;
			}
			if (OTjrqOBYDAbnwqbqlokmxcIMrzhl(value, modifierKeyInfo.longKey, asJEgTisjEcLUALQMOtkJoREArlC.deviceLocalizationInfo, out var result))
			{
				return result;
			}
			return null;
		}

		private string dTkBozMtqnQtPedmCkapKsHYNhJu(ModifierKey P_0)
		{
			if (P_0 == ModifierKey.None)
			{
				return null;
			}
			ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)P_0];
			if (!GlyphManager.isEnabled)
			{
				return null;
			}
			if (!uTnsRRoHcbUbHhgkaFxIYuGLaUGdA.TryGetValue((int)P_0, out var value))
			{
				return null;
			}
			if (UFLQkBPpFEtIRfnBZNyHnEqMMuOf(value, modifierKeyInfo.longKey, asJEgTisjEcLUALQMOtkJoREArlC.deviceLocalizationInfo, out var result))
			{
				return result;
			}
			return null;
		}

		private static bool OTjrqOBYDAbnwqbqlokmxcIMrzhl(iIAHOEbrEvhAgdDaDnoHaPdBgchI P_0, string P_1, DeviceLocalizationInfo P_2, out object P_3)
		{
			GlyphManager.GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = rKLqTAJWyWpsRTZPJBCmeCVZWFqw.ExQCcugZGncMnHCaRMMIquvGTVVbA(P_0.GsKUjOKkocOCSiIKNkAwezXkHBBD, P_1, "controller", P_2, QYJjXxsVdyEaAjTsqvDHkTMqFyjf.Keyboard, -1, AxisRange.Full, -1, out P_3);
			if ((getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.Changed) != GlyphManager.GetAndUpdateGlyphResultFlags.None)
			{
				P_0.yePeTIIAYEfvNEBrikBacnzGNbBwd = (getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.JustGot) != 0;
			}
			return P_0.yePeTIIAYEfvNEBrikBacnzGNbBwd;
		}

		private static bool UFLQkBPpFEtIRfnBZNyHnEqMMuOf(iIAHOEbrEvhAgdDaDnoHaPdBgchI P_0, string P_1, DeviceLocalizationInfo P_2, out string P_3)
		{
			object obj;
			bool result = OTjrqOBYDAbnwqbqlokmxcIMrzhl(P_0, P_1, P_2, out obj);
			P_3 = P_0.GsKUjOKkocOCSiIKNkAwezXkHBBD.cachedKey;
			return result;
		}

		[CompilerGenerated]
		private void bQNBsbZvzSfNyxoocTgLVSpiskyc()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				DZmdQJgXixfapzHvEhNEdMwMDpTV(values[i], true);
				DZmdQJgXixfapzHvEhNEdMwMDpTV(values[i], false);
			}
		}

		[CompilerGenerated]
		private void wUqjRDbUZAyWzTbsOXuphvpZRMpG()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				fzHuXhDDNVIVwvgkZsQjhRdddOGA(values[i]);
			}
		}
	}
}
