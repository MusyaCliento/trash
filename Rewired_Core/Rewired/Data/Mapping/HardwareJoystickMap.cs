using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Platforms.UnityInputSystem;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class HardwareJoystickMap : ScriptableObject, IHardwareControllerMap, IHardwareControllerMap_Internal
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Platform : IDeepCloneable
		{
			private sealed class oRRgFEbcRtMLVInJiNwpSZAmuwYzA : IEnumerable<Platform>, IEnumerable, IEnumerator<Platform>, IEnumerator, IDisposable
			{
				private int rgrZprpUkJLCoOGbTCDVujdkdmBr;

				private Platform QaTubxxAjeLeZbeQqAudrzKAvzCJ;

				private int EznuGrvOsRYvZAnvUaqirLobpcsH;

				public Platform paYZDNtDYPuoJzBkXaaWiTgpRIJAA;

				private IList<Platform> anhFHADSPmuPpCNGHaSROTQUpWFBA;

				private int zlLnXGgVMwpnvtPTjCyOvwfGgSkS;

				Platform IEnumerator<Platform>.Current
				{
					[DebuggerHidden]
					get
					{
						return QaTubxxAjeLeZbeQqAudrzKAvzCJ;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return QaTubxxAjeLeZbeQqAudrzKAvzCJ;
					}
				}

				[DebuggerHidden]
				public oRRgFEbcRtMLVInJiNwpSZAmuwYzA(int P_0)
				{
					rgrZprpUkJLCoOGbTCDVujdkdmBr = P_0;
					EznuGrvOsRYvZAnvUaqirLobpcsH = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					anhFHADSPmuPpCNGHaSROTQUpWFBA = null;
					rgrZprpUkJLCoOGbTCDVujdkdmBr = -2;
				}

				private bool MoveNext()
				{
					int num = rgrZprpUkJLCoOGbTCDVujdkdmBr;
					Platform platform = paYZDNtDYPuoJzBkXaaWiTgpRIJAA;
					if (num != 0)
					{
						if (num != 1)
						{
							return false;
						}
						rgrZprpUkJLCoOGbTCDVujdkdmBr = -1;
						goto IL_0077;
					}
					rgrZprpUkJLCoOGbTCDVujdkdmBr = -1;
					anhFHADSPmuPpCNGHaSROTQUpWFBA = platform.GetVariants();
					if (anhFHADSPmuPpCNGHaSROTQUpWFBA == null)
					{
						return false;
					}
					zlLnXGgVMwpnvtPTjCyOvwfGgSkS = 0;
					goto IL_0087;
					IL_0087:
					if (zlLnXGgVMwpnvtPTjCyOvwfGgSkS < anhFHADSPmuPpCNGHaSROTQUpWFBA.Count)
					{
						if (anhFHADSPmuPpCNGHaSROTQUpWFBA[zlLnXGgVMwpnvtPTjCyOvwfGgSkS] != null)
						{
							QaTubxxAjeLeZbeQqAudrzKAvzCJ = anhFHADSPmuPpCNGHaSROTQUpWFBA[zlLnXGgVMwpnvtPTjCyOvwfGgSkS];
							rgrZprpUkJLCoOGbTCDVujdkdmBr = 1;
							return true;
						}
						goto IL_0077;
					}
					return false;
					IL_0077:
					zlLnXGgVMwpnvtPTjCyOvwfGgSkS++;
					goto IL_0087;
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
				IEnumerator<Platform> IEnumerable<Platform>.GetEnumerator()
				{
					oRRgFEbcRtMLVInJiNwpSZAmuwYzA oRRgFEbcRtMLVInJiNwpSZAmuwYzA2;
					if (rgrZprpUkJLCoOGbTCDVujdkdmBr == -2 && EznuGrvOsRYvZAnvUaqirLobpcsH == Environment.CurrentManagedThreadId)
					{
						rgrZprpUkJLCoOGbTCDVujdkdmBr = 0;
						oRRgFEbcRtMLVInJiNwpSZAmuwYzA2 = this;
					}
					else
					{
						oRRgFEbcRtMLVInJiNwpSZAmuwYzA2 = new oRRgFEbcRtMLVInJiNwpSZAmuwYzA(0);
						oRRgFEbcRtMLVInJiNwpSZAmuwYzA2.paYZDNtDYPuoJzBkXaaWiTgpRIJAA = paYZDNtDYPuoJzBkXaaWiTgpRIJAA;
					}
					return oRRgFEbcRtMLVInJiNwpSZAmuwYzA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform>)this).GetEnumerator();
				}
			}

			[Tooltip("A description of this platform map. For reference only.")]
			public string description;

			internal abstract InputPlatform platform { get; }

			public abstract int assignedButtonCount { get; }

			public abstract int assignedAxisCount { get; }

			public virtual string controllerNameOverride => null;

			internal abstract Elements_Base elements_base { get; }

			internal virtual bool isAllowed
			{
				get
				{
					if (!disabled)
					{
						if (assignedButtonCount <= 0)
						{
							return assignedAxisCount > 0;
						}
						return true;
					}
					return false;
				}
			}

			internal abstract bool hasData { get; }

			internal abstract bool disabled { get; }

			internal IEnumerable<Platform> Variants
			{
				[IteratorStateMachine(typeof(oRRgFEbcRtMLVInJiNwpSZAmuwYzA))]
				get
				{
					return new oRRgFEbcRtMLVInJiNwpSZAmuwYzA(-2)
					{
						paYZDNtDYPuoJzBkXaaWiTgpRIJAA = this
					};
				}
			}

			internal bool hasVariants => variantCount > 0;

			[CustomObfuscation(rename = false)]
			internal int variantCount
			{
				get
				{
					if (GetVariants() == null)
					{
						return 0;
					}
					return GetVariants().Count;
				}
			}

			internal bool selfOrVariantHasData
			{
				get
				{
					if (hasData)
					{
						return true;
					}
					foreach (Platform variant in Variants)
					{
						if (variant.hasData)
						{
							return true;
						}
					}
					return false;
				}
			}

			internal bool selfOrVariantIsValid
			{
				get
				{
					if (!selfOrVariantHasData)
					{
						return false;
					}
					if (isAllowed && hasData)
					{
						return true;
					}
					foreach (Platform variant in Variants)
					{
						if (variant.isAllowed && variant.hasData)
						{
							return true;
						}
					}
					return false;
				}
			}

			internal bool selfOrVariantIsAllowed
			{
				get
				{
					if (isAllowed)
					{
						return true;
					}
					foreach (Platform variant in Variants)
					{
						if (variant.isAllowed)
						{
							return true;
						}
					}
					return false;
				}
			}

			internal abstract bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap);

			internal abstract void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes);

			internal abstract bool IsElementIdentifierMapped(int elementIdentifierId);

			public abstract IList<Platform> GetVariants();

			internal Platform GetFirstValidPlatformMap(out int variantIndex)
			{
				variantIndex = -1;
				if (!selfOrVariantIsValid)
				{
					return null;
				}
				if (isAllowed && hasData)
				{
					variantIndex = -1;
					return this;
				}
				IList<Platform> variants = GetVariants();
				if (variants != null)
				{
					for (int i = 0; i < variants.Count; i++)
					{
						Platform platform = variants[i];
						if (platform != null && platform.isAllowed && platform.hasData)
						{
							variantIndex = i;
							return platform;
						}
					}
				}
				return null;
			}

			internal int IndexOfElementIdentifier(ControllerElementIdentifier[] elementIdentifiers, int id)
			{
				if (elementIdentifiers == null)
				{
					return -1;
				}
				for (int i = 0; i < elementIdentifiers.Length; i++)
				{
					if (elementIdentifiers[i].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid == id)
					{
						return i;
					}
				}
				return -1;
			}

			internal abstract AxisCalibrationData[] GetAxisCalibrationData();

			internal abstract void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos);

			internal abstract void GetButtonData(out HardwareButtonInfo[] buttonInfos);

			internal abstract ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier);

			internal abstract bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange);

			internal Platform GetPlatformMap(int variantIndex)
			{
				if (variantIndex < 0)
				{
					return this;
				}
				if (!hasVariants)
				{
					return null;
				}
				IList<Platform> variants = GetVariants();
				if (variantCount <= variantIndex)
				{
					return null;
				}
				return variants[variantIndex];
			}

			internal HardwareJoystickMap_InputManager ToHardwareJoystickMap_InputManager(HardwareJoystickMap hardwareJoystickMap, InputSource inputSource, InputPlatform actualInputPlatform, int variantIndex)
			{
				if (hardwareJoystickMap == null)
				{
					return null;
				}
				Platform platform = MiscTools.DeepClone(this);
				string controllerName = platform.controllerNameOverride;
				if (string.IsNullOrEmpty(controllerName))
				{
					controllerName = hardwareJoystickMap.controllerName;
				}
				List<Guid> list = new List<Guid>();
				hardwareJoystickMap.GetTemplateGuids(list);
				DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(ControllerType.Joystick, false, hardwareJoystickMap.Guid, new List<string> { hardwareJoystickMap.Key }, list);
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = new HardwareJoystickMap_InputManager(new HardwareControllerMapIdentifier(hardwareJoystickMap.Guid, inputSource, actualInputPlatform, variantIndex), hardwareJoystickMap.joystickTypes, deviceLocalizationInfo, platform, controllerName, platform.assignedButtonCount, platform.assignedAxisCount, hardwareJoystickMap.elementIdentifiers.Length, hardwareJoystickMap.compoundElements);
				ControllerElementIdentifier[] elementIdentifiers = hardwareJoystickMap.elementIdentifiers;
				int elementIdentifierCount = hardwareJoystickMap.elementIdentifierCount;
				for (int i = 0; i < elementIdentifierCount; i++)
				{
					hardwareJoystickMap_InputManager.elementIdentifiers[i] = new ControllerElementIdentifier(elementIdentifiers[i], hardwareJoystickMap_InputManager.map.IsElementIdentifierMapped(elementIdentifiers[i].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid), hardwareJoystickMap_InputManager.map.GetEffectiveElementIdentifierType(elementIdentifiers[i]));
				}
				if ((inputSource == InputSource.PS4 || this.platform == InputPlatform.PS4UnityInputSystem) && (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualShock4 || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController))
				{
					for (int j = 0; j < elementIdentifierCount; j++)
					{
						switch (elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
						case 0:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "left stick x";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName = "left stick right";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeName = "left stick left";
							break;
						case 1:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "left stick y";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName = "left stick up";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeName = "left stick down";
							break;
						case 2:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "right stick x";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName = "right stick right";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeName = "right stick left";
							break;
						case 3:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "right stick y";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName = "right stick up";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeName = "right stick down";
							break;
						case 4:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "L2 button";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName = "L2 button";
							break;
						case 5:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "R2 button";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName = "R2 button";
							break;
						case 6:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "cross button";
							break;
						case 7:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "circle button";
							break;
						case 8:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "square button";
							break;
						case 9:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "triangle button";
							break;
						case 10:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "L1 button";
							break;
						case 11:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "R1 button";
							break;
						case 12:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "SHARE button";
							break;
						case 13:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "OPTIONS button";
							break;
						case 14:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "PS button";
							break;
						case 15:
							if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController)
							{
								hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "pad button";
							}
							else
							{
								hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "touch pad button";
							}
							break;
						case 16:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "L3 button";
							break;
						case 17:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "R3 button";
							break;
						case 18:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "up button";
							break;
						case 19:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "right button";
							break;
						case 20:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "down button";
							break;
						case 21:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "left button";
							break;
						}
					}
				}
				if (inputSource == InputSource.PS5 || this.platform == InputPlatform.PS5UnityInputSystem)
				{
					if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualSense)
					{
						for (int k = 0; k < elementIdentifierCount; k++)
						{
							switch (elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
							{
							case 0:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "left stick x";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName = "left stick right";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeName = "left stick left";
								break;
							case 1:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "left stick y";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName = "left stick up";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeName = "left stick down";
								break;
							case 2:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "right stick x";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName = "right stick right";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeName = "right stick left";
								break;
							case 3:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "right stick y";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName = "right stick up";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeName = "right stick down";
								break;
							case 4:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "L2 button";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName = "L2 button";
								break;
							case 5:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "R2 button";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName = "R2 button";
								break;
							case 6:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "cross button";
								break;
							case 7:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "circle button";
								break;
							case 8:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "square button";
								break;
							case 9:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "triangle button";
								break;
							case 10:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "L1 button";
								break;
							case 11:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "R1 button";
								break;
							case 12:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "create button";
								break;
							case 13:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "options button";
								break;
							case 14:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "PS button";
								break;
							case 15:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "touch pad button";
								break;
							case 16:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "L3 button";
								break;
							case 17:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "R3 button";
								break;
							case 18:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "up button";
								break;
							case 19:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "right button";
								break;
							case 20:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "down button";
								break;
							case 21:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "left button";
								break;
							}
						}
					}
					else if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4Drums || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4Guitar || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4SteeringWheel)
					{
						for (int l = 0; l < elementIdentifierCount; l++)
						{
							switch (elementIdentifiers[l].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
							{
							case 19:
								hardwareJoystickMap_InputManager.elementIdentifiers[l].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "create button";
								break;
							case 20:
								hardwareJoystickMap_InputManager.elementIdentifiers[l].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "options button";
								break;
							}
						}
					}
					else if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4FlightStick)
					{
						for (int m = 0; m < elementIdentifierCount; m++)
						{
							switch (elementIdentifiers[m].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
							{
							case 21:
								hardwareJoystickMap_InputManager.elementIdentifiers[m].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "create button";
								break;
							case 22:
								hardwareJoystickMap_InputManager.elementIdentifiers[m].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = "options button";
								break;
							}
						}
					}
				}
				return hardwareJoystickMap_InputManager;
			}

			public abstract object DeepClone();

			internal abstract void CopyVars(Platform destination);
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Elements_Base : IDeepCloneable
		{
			public abstract int buttonCount { get; }

			public abstract int axisCount { get; }

			internal virtual void CopyVars(Elements_Base destination)
			{
			}

			internal abstract ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier);

			internal abstract bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange);

			public abstract object DeepClone();
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class MatchingCriteria_Base : IDeepCloneable
		{
			[Serializable]
			public class ElementCount_Base : IDeepCloneable
			{
				public int axisCount;

				public int buttonCount;

				public virtual object DeepClone()
				{
					ElementCount_Base elementCount_Base = new ElementCount_Base();
					HXqFlTmkJgbaqWaoLySOLJbfONWh(elementCount_Base);
					return elementCount_Base;
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
				}

				internal virtual void HXqFlTmkJgbaqWaoLySOLJbfONWh(ElementCount_Base P_0)
				{
					if (P_0 != null)
					{
						P_0.axisCount = axisCount;
						P_0.buttonCount = buttonCount;
					}
				}

				internal virtual bool iJhYiAkXCqAZNrwRvcAgXrMBxdoL(BridgedControllerHWInfo P_0)
				{
					if (P_0 == null)
					{
						return false;
					}
					if (axisCount < 0 || axisCount == P_0.hardwareAxisCount)
					{
						if (buttonCount >= 0)
						{
							return buttonCount == P_0.hardwareButtonCount;
						}
						return true;
					}
					return false;
				}
			}

			[Tooltip("The number of axes reported by the controller. If the value reported by the controller differs from this value, the controller is not a match. [-1 to match to any number of axes]")]
			public int axisCount;

			[Tooltip("The number of buttons reported by the controller. If the value reported by the controller differs from this value, the controller is not a match. [-1 to match to any number of buttons]")]
			public int buttonCount;

			[Tooltip("If checked, this entire platform map will be skipped and will not match to any controller.")]
			public bool disabled;

			[Tooltip("User-defined string. May have functionality on some input sources but not on others.")]
			public string tag;

			internal abstract bool hasData { get; }

			internal virtual bool isAllowed
			{
				get
				{
					if (disabled)
					{
						return false;
					}
					return true;
				}
			}

			internal abstract int alternateElementCount { get; }

			internal virtual bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch)
			{
				if (disabled)
				{
					return false;
				}
				if (!isAllowed)
				{
					return false;
				}
				if (!ElementCountsMatch(BridgedControllerHWInfo, out var _))
				{
					return false;
				}
				if (!string.IsNullOrEmpty(BridgedControllerHWInfo.definitionMatchTag) && !BridgedControllerHWInfo.definitionMatchTag.Equals(tag, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
				return true;
			}

			internal abstract ElementCount_Base GetAlternateElementCount(int index);

			internal virtual bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				alternateMatched = false;
				if (bridgedControllerHWInfo == null)
				{
					return false;
				}
				int num = alternateElementCount;
				for (int i = 0; i < num; i++)
				{
					ElementCount_Base elementCount_Base = GetAlternateElementCount(i);
					if (elementCount_Base != null && elementCount_Base.iJhYiAkXCqAZNrwRvcAgXrMBxdoL(bridgedControllerHWInfo))
					{
						alternateMatched = true;
						return true;
					}
				}
				if (axisCount < 0 || axisCount == bridgedControllerHWInfo.hardwareAxisCount)
				{
					if (buttonCount >= 0)
					{
						return buttonCount == bridgedControllerHWInfo.hardwareButtonCount;
					}
					return true;
				}
				return false;
			}

			internal virtual void CopyVars(MatchingCriteria_Base destination)
			{
				destination.axisCount = axisCount;
				destination.buttonCount = buttonCount;
				destination.disabled = disabled;
				destination.tag = tag;
			}

			internal static bool StringMatches(string searchIn, string searchFor, bool useRegex)
			{
				if (searchIn == null)
				{
					searchIn = string.Empty;
				}
				if (searchFor == null)
				{
					searchFor = string.Empty;
				}
				if (useRegex)
				{
					return Regex.IsMatch(searchIn, searchFor, RegexOptions.IgnoreCase);
				}
				return searchFor.Trim().Equals(searchIn.Trim(), StringComparison.OrdinalIgnoreCase);
			}

			public abstract object DeepClone();
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class CompoundElement : IDeepCloneable
		{
			public CompoundControllerElementType type;

			public int elementIdentifier = -1;

			public int[] componentElementIdentifiers = new int[0];

			public int intValue0;

			public int elementCount
			{
				get
				{
					if (componentElementIdentifiers == null)
					{
						return 0;
					}
					return componentElementIdentifiers.Length;
				}
			}

			private Axis2DClampType axis2DClampType => (Axis2DClampType)intValue0;

			public CompoundElement()
			{
				if (componentElementIdentifiers == null)
				{
					componentElementIdentifiers = new int[0];
				}
			}

			public CompoundElement(CompoundElement P_0)
			{
				ImportVars(P_0);
			}

			public int GetComponentElementIdentifierId(int index)
			{
				if (index < 0 || index >= elementCount)
				{
					return -1;
				}
				return componentElementIdentifiers[index];
			}

			public virtual object DeepClone()
			{
				return new CompoundElement(this);
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DeepClone
				return this.DeepClone();
			}

			protected virtual void ImportVars(CompoundElement source)
			{
				type = source.type;
				elementIdentifier = source.elementIdentifier;
				componentElementIdentifiers = ArrayTools.ShallowCopy(source.componentElementIdentifiers);
				intValue0 = source.intValue0;
			}

			internal virtual Axis2DCalibrationData GetAxis2DCalibrationData()
			{
				if (type != CompoundControllerElementType.Axis2D)
				{
					Logger.LogError("Compound element type mismatch. Expected " + type.ToString() + ", found " + CompoundControllerElementType.Axis2D.ToString() + ".");
					return default(Axis2DCalibrationData);
				}
				return new Axis2DCalibrationData((DeadZone2DType)(-1), (AxisSensitivity2DType)(-1), axis2DClampType);
			}

			internal static void SortHatElementsClockwise(CompoundElement element)
			{
				if (element != null && element.type == CompoundControllerElementType.Hat && element.componentElementIdentifiers != null && element.componentElementIdentifiers.Length == 8)
				{
					int[] array = new int[8]
					{
						element.componentElementIdentifiers[0],
						element.componentElementIdentifiers[4],
						element.componentElementIdentifiers[1],
						element.componentElementIdentifiers[5],
						element.componentElementIdentifiers[2],
						element.componentElementIdentifiers[6],
						element.componentElementIdentifiers[3],
						element.componentElementIdentifiers[7]
					};
					Array.Copy(array, element.componentElementIdentifiers, array.Length);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class VidPid
		{
			public int vendorId;

			public int productId;
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class AxisCalibrationInfoEntry : IDeepCloneable
		{
			[SerializeField]
			internal AlternateAxisCalibrationType key;

			[SerializeField]
			internal AxisCalibrationInfo calibration;

			public AxisCalibrationInfoEntry(AxisCalibrationInfoEntry P_0)
			{
				ImportVars(P_0);
			}

			public virtual object DeepClone()
			{
				return new AxisCalibrationInfoEntry(this);
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DeepClone
				return this.DeepClone();
			}

			protected virtual void ImportVars(AxisCalibrationInfoEntry source)
			{
				key = source.key;
				calibration = MiscTools.DeepClone(source.calibration);
			}

			public static Dictionary<int, AxisCalibrationInfo> ToDictionary(AxisCalibrationInfoEntry[] calibrations, bool deepClone)
			{
				if (calibrations == null)
				{
					return new Dictionary<int, AxisCalibrationInfo>();
				}
				Dictionary<int, AxisCalibrationInfo> dictionary = new Dictionary<int, AxisCalibrationInfo>();
				foreach (AxisCalibrationInfoEntry axisCalibrationInfoEntry in calibrations)
				{
					if (axisCalibrationInfoEntry != null && axisCalibrationInfoEntry.calibration != null && Enum.IsDefined(typeof(AlternateAxisCalibrationType), axisCalibrationInfoEntry.key))
					{
						if (dictionary.ContainsKey((int)axisCalibrationInfoEntry.key))
						{
							Logger.LogError("A duplicate key was found in AxisCalibrationInfoEntry array in HardwareJoystickMap. Skipping.");
						}
						else if (deepClone)
						{
							dictionary.Add((int)axisCalibrationInfoEntry.key, (AxisCalibrationInfo)axisCalibrationInfoEntry.calibration.DeepClone());
						}
						else
						{
							dictionary.Add((int)axisCalibrationInfoEntry.key, axisCalibrationInfoEntry.calibration);
						}
					}
				}
				return dictionary;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Platform_RawOrDirectInput : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						ElementCount elementCount = new ElementCount();
						HXqFlTmkJgbaqWaoLySOLJbfONWh(elementCount);
						return elementCount;
					}

					internal void XgZYTxtpyiYvLOYwdFMDwMqKkIcY(ElementCount_Base P_0)
					{
						base.HXqFlTmkJgbaqWaoLySOLJbfONWh(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool mhzLnpdUjOqHYhCssjEFoOlNnDVk(BridgedControllerHWInfo P_0)
					{
						if (!base.iJhYiAkXCqAZNrwRvcAgXrMBxdoL(P_0))
						{
							return false;
						}
						if (hatCount >= 0)
						{
							return hatCount == P_0.hardwareHatCount;
						}
						return true;
					}
				}

				public int hatCount;

				public ElementCount[] alternateElementCounts;

				public bool productName_useRegex;

				public string[] productName;

				public string[] productGUID;

				public int[] productId;

				public DeviceType deviceType;

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productGUID != null && productGUID.Length != 0)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				int MatchingCriteria_Base.alternateElementCount
				{
					get
					{
						if (alternateElementCounts == null)
						{
							return 0;
						}
						return alternateElementCounts.Length;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (strictMatch)
					{
						if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								return true;
							}
							if (productName == null || productName.Length == 0)
							{
								return true;
							}
							return ProductNameMatches(bridgedControllerHWInfo);
						}
						if (!ProductNameMatches(bridgedControllerHWInfo))
						{
							return false;
						}
						return true;
					}
					return ProductNameMatches(bridgedControllerHWInfo);
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
					{
						return null;
					}
					return alternateElementCounts[index];
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (alternateMatched)
					{
						return true;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
				}

				private bool ProductNameMatches(BridgedControllerHWInfo controller)
				{
					if (controller.hw_isBluetoothDevice && !string.IsNullOrEmpty(controller.hw_bluetoothDeviceName))
					{
						if (ProductNameMatches(controller.hw_productName) || ProductNameMatches(controller.hw_bluetoothDeviceName))
						{
							return true;
						}
						return false;
					}
					return ProductNameMatches(controller.hw_productName);
				}

				private bool ProductNameMatches(string name)
				{
					if (string.IsNullOrEmpty(name) || productName == null)
					{
						return false;
					}
					string searchIn = name.Trim();
					for (int i = 0; i < productName.Length; i++)
					{
						if (productName[i] != null && !(productName[i] == string.Empty) && MatchingCriteria_Base.StringMatches(searchIn, productName[i], productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.alternateElementCounts = ArrayTools.ShallowCopy(alternateElementCounts);
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
						matchingCriteria.productId = ArrayTools.ShallowCopy(productId);
						matchingCriteria.deviceType = deviceType;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Elements_Platform_Base : Elements_Base
			{
				internal abstract IEnumerable<Axis_Base> Axes { get; }

				internal abstract IEnumerable<Button_Base> Buttons { get; }

				internal abstract Axis_Base GetAxis(int axisIndex);
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class CustomCalculationSourceData : IDeepCloneable
			{
				public int sourceType;

				public int sourceAxis;

				public int sourceButton;

				public int sourceOtherAxis;

				public AxisRange sourceAxisRange;

				public float axisDeadZone;

				public float axisUpperDeadZone;

				public bool invert;

				public AxisCalibrationType axisCalibrationType;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public object DeepClone()
				{
					return new CustomCalculationSourceData
					{
						sourceType = sourceType,
						sourceAxis = sourceAxis,
						sourceButton = sourceButton,
						sourceOtherAxis = sourceOtherAxis,
						sourceAxisRange = sourceAxisRange,
						axisDeadZone = axisDeadZone,
						axisUpperDeadZone = axisUpperDeadZone,
						invert = invert,
						axisCalibrationType = axisCalibrationType,
						axisZero = axisZero,
						axisMin = axisMin,
						axisMax = axisMax
					};
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public CustomCalculation customCalculation;

				public CustomCalculationSourceData[] customCalculationSourceData;

				public abstract object DeepClone();

				protected void ImportVars(Element source)
				{
					customCalculation = source.customCalculation;
					customCalculationSourceData = ArrayTools.DeepClone(source.customCalculationSourceData);
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Button_Base : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceButton;

				public int sourceAxis;

				public Pole sourceAxisPole;

				public float axisDeadZone;

				public int sourceHat;

				public HatType sourceHatType;

				public HatDirection sourceHatDirection;

				public bool requireMultipleButtons;

				public int[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public int[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				public Button_Base()
				{
					sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				protected void ImportVars(Button_Base source)
				{
					ImportVars((Element)source);
					elementIdentifier = source.elementIdentifier;
					sourceType = source.sourceType;
					sourceButton = source.sourceButton;
					sourceAxis = source.sourceAxis;
					sourceAxisPole = source.sourceAxisPole;
					axisDeadZone = source.axisDeadZone;
					sourceHat = source.sourceHat;
					sourceHatType = source.sourceHatType;
					sourceHatDirection = source.sourceHatDirection;
					requireMultipleButtons = source.requireMultipleButtons;
					requiredButtons = ArrayTools.ShallowCopy(source.requiredButtons);
					ignoreIfButtonsActive = source.ignoreIfButtonsActive;
					ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(source.ignoreIfButtonsActiveButtons);
					buttonInfo = MiscTools.DeepClone(source.buttonInfo);
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Axis_Base : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceAxis;

				public AxisRange sourceAxisRange;

				public bool invert;

				public float axisDeadZone;

				public float axisUpperDeadZone;

				public BoolWithDefault calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public HardwareAxisInfo axisInfo;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public int sourceButton;

				public Pole buttonAxisContribution;

				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public AxisRange sourceHatRange;

				public Axis_Base()
				{
					sourceType = HardwareElementSourceTypeWithHat.Axis;
				}

				protected void ImportVars(Axis_Base source)
				{
					ImportVars((Element)source);
					elementIdentifier = source.elementIdentifier;
					sourceType = source.sourceType;
					sourceAxis = source.sourceAxis;
					sourceAxisRange = source.sourceAxisRange;
					invert = source.invert;
					axisDeadZone = source.axisDeadZone;
					axisUpperDeadZone = source.axisUpperDeadZone;
					calibrateAxis = source.calibrateAxis;
					axisZero = source.axisZero;
					axisMin = source.axisMin;
					axisMax = source.axisMax;
					axisInfo = MiscTools.DeepClone(source.axisInfo);
					sourceButton = source.sourceButton;
					buttonAxisContribution = source.buttonAxisContribution;
					sourceHat = source.sourceHat;
					sourceHatDirection = source.sourceHatDirection;
					sourceHatRange = source.sourceHatRange;
					alternateCalibrations = MiscTools.DeepClone(source.alternateCalibrations);
				}
			}

			public enum DeviceType
			{
				Any = 0,
				Device = 17,
				Mouse = 18,
				Keyboard = 19,
				Joystick = 20,
				Gamepad = 21,
				Driving = 22,
				Flight = 23,
				FirstPerson = 24,
				ControlDevice = 25,
				ScreenPointer = 26,
				Remote = 27,
				Supplemental = 28
			}

			public MatchingCriteria matchingCriteria;

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal abstract IEnumerable<Axis_Base> IterateAxes();

			internal abstract IEnumerable<Button_Base> IterateButtons();

			internal override void CopyVars(Platform destination)
			{
				if (destination is Platform_RawOrDirectInput platform_RawOrDirectInput)
				{
					platform_RawOrDirectInput.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_DirectInput_Base : Platform_RawOrDirectInput
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Platform_Base
			{
				private sealed class TKaglTDhafszwWmXVgLhINoyJoMh : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int YANbfeGnyDezshEYjPmvdrnbkYHjB;

					private Axis_Base smIGrugvJDqsQIbsARTuKzLuMPUpA;

					private int iOZBIYWIHEMWlxjSKJPjndcheKWD;

					public Elements YXPQfcqGoCvEmZCuMEtDnQEgBssr;

					private int zFziVKOZbhSLPDuAXvvDapmIctrjA;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return smIGrugvJDqsQIbsARTuKzLuMPUpA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return smIGrugvJDqsQIbsARTuKzLuMPUpA;
						}
					}

					[DebuggerHidden]
					public TKaglTDhafszwWmXVgLhINoyJoMh(int P_0)
					{
						YANbfeGnyDezshEYjPmvdrnbkYHjB = P_0;
						iOZBIYWIHEMWlxjSKJPjndcheKWD = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						YANbfeGnyDezshEYjPmvdrnbkYHjB = -2;
					}

					private bool MoveNext()
					{
						int yANbfeGnyDezshEYjPmvdrnbkYHjB = YANbfeGnyDezshEYjPmvdrnbkYHjB;
						Elements yXPQfcqGoCvEmZCuMEtDnQEgBssr = YXPQfcqGoCvEmZCuMEtDnQEgBssr;
						switch (yANbfeGnyDezshEYjPmvdrnbkYHjB)
						{
						default:
							return false;
						case 0:
							YANbfeGnyDezshEYjPmvdrnbkYHjB = -1;
							if (yXPQfcqGoCvEmZCuMEtDnQEgBssr.axes == null)
							{
								return false;
							}
							zFziVKOZbhSLPDuAXvvDapmIctrjA = 0;
							break;
						case 1:
							YANbfeGnyDezshEYjPmvdrnbkYHjB = -1;
							zFziVKOZbhSLPDuAXvvDapmIctrjA++;
							break;
						}
						if (zFziVKOZbhSLPDuAXvvDapmIctrjA < yXPQfcqGoCvEmZCuMEtDnQEgBssr.axes.Length)
						{
							smIGrugvJDqsQIbsARTuKzLuMPUpA = yXPQfcqGoCvEmZCuMEtDnQEgBssr.axes[zFziVKOZbhSLPDuAXvvDapmIctrjA];
							YANbfeGnyDezshEYjPmvdrnbkYHjB = 1;
							return true;
						}
						return false;
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
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						TKaglTDhafszwWmXVgLhINoyJoMh tKaglTDhafszwWmXVgLhINoyJoMh;
						if (YANbfeGnyDezshEYjPmvdrnbkYHjB == -2 && iOZBIYWIHEMWlxjSKJPjndcheKWD == Environment.CurrentManagedThreadId)
						{
							YANbfeGnyDezshEYjPmvdrnbkYHjB = 0;
							tKaglTDhafszwWmXVgLhINoyJoMh = this;
						}
						else
						{
							tKaglTDhafszwWmXVgLhINoyJoMh = new TKaglTDhafszwWmXVgLhINoyJoMh(0);
							tKaglTDhafszwWmXVgLhINoyJoMh.YXPQfcqGoCvEmZCuMEtDnQEgBssr = YXPQfcqGoCvEmZCuMEtDnQEgBssr;
						}
						return tKaglTDhafszwWmXVgLhINoyJoMh;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class CmMfmmBHBRKaTfFVaJrvUncRAzrMb : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int UjHGQJaAdXrFFviCFThXjIftVVyT;

					private Button_Base udZcKsTGnXgfvQyAbzKqjMnnKPCj;

					private int awtepXnpDvbhxJOtkhEhdcxfPQJuB;

					public Elements QIPaxQcaXfRnmjIUCmRIlYWgKgBV;

					private int kDLBFpdzEimVVInaOfSOEKEviLMK;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return udZcKsTGnXgfvQyAbzKqjMnnKPCj;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return udZcKsTGnXgfvQyAbzKqjMnnKPCj;
						}
					}

					[DebuggerHidden]
					public CmMfmmBHBRKaTfFVaJrvUncRAzrMb(int P_0)
					{
						UjHGQJaAdXrFFviCFThXjIftVVyT = P_0;
						awtepXnpDvbhxJOtkhEhdcxfPQJuB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						UjHGQJaAdXrFFviCFThXjIftVVyT = -2;
					}

					private bool MoveNext()
					{
						int ujHGQJaAdXrFFviCFThXjIftVVyT = UjHGQJaAdXrFFviCFThXjIftVVyT;
						Elements qIPaxQcaXfRnmjIUCmRIlYWgKgBV = QIPaxQcaXfRnmjIUCmRIlYWgKgBV;
						switch (ujHGQJaAdXrFFviCFThXjIftVVyT)
						{
						default:
							return false;
						case 0:
							UjHGQJaAdXrFFviCFThXjIftVVyT = -1;
							if (qIPaxQcaXfRnmjIUCmRIlYWgKgBV.buttons == null)
							{
								return false;
							}
							kDLBFpdzEimVVInaOfSOEKEviLMK = 0;
							break;
						case 1:
							UjHGQJaAdXrFFviCFThXjIftVVyT = -1;
							kDLBFpdzEimVVInaOfSOEKEviLMK++;
							break;
						}
						if (kDLBFpdzEimVVInaOfSOEKEviLMK < qIPaxQcaXfRnmjIUCmRIlYWgKgBV.buttons.Length)
						{
							udZcKsTGnXgfvQyAbzKqjMnnKPCj = qIPaxQcaXfRnmjIUCmRIlYWgKgBV.buttons[kDLBFpdzEimVVInaOfSOEKEviLMK];
							UjHGQJaAdXrFFviCFThXjIftVVyT = 1;
							return true;
						}
						return false;
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
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						CmMfmmBHBRKaTfFVaJrvUncRAzrMb cmMfmmBHBRKaTfFVaJrvUncRAzrMb;
						if (UjHGQJaAdXrFFviCFThXjIftVVyT == -2 && awtepXnpDvbhxJOtkhEhdcxfPQJuB == Environment.CurrentManagedThreadId)
						{
							UjHGQJaAdXrFFviCFThXjIftVVyT = 0;
							cmMfmmBHBRKaTfFVaJrvUncRAzrMb = this;
						}
						else
						{
							cmMfmmBHBRKaTfFVaJrvUncRAzrMb = new CmMfmmBHBRKaTfFVaJrvUncRAzrMb(0);
							cmMfmmBHBRKaTfFVaJrvUncRAzrMb.QIPaxQcaXfRnmjIUCmRIlYWgKgBV = QIPaxQcaXfRnmjIUCmRIlYWgKgBV;
						}
						return cmMfmmBHBRKaTfFVaJrvUncRAzrMb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				IEnumerable<Axis_Base> Elements_Platform_Base.Axes
				{
					[IteratorStateMachine(typeof(TKaglTDhafszwWmXVgLhINoyJoMh))]
					get
					{
						return new TKaglTDhafszwWmXVgLhINoyJoMh(-2)
						{
							YXPQfcqGoCvEmZCuMEtDnQEgBssr = this
						};
					}
				}

				IEnumerable<Button_Base> Elements_Platform_Base.Buttons
				{
					[IteratorStateMachine(typeof(CmMfmmBHBRKaTfFVaJrvUncRAzrMb))]
					get
					{
						return new CmMfmmBHBRKaTfFVaJrvUncRAzrMb(-2)
						{
							QIPaxQcaXfRnmjIUCmRIlYWgKgBV = this
						};
					}
				}

				internal override Axis_Base GetAxis(int axisIndex)
				{
					if (axes == null || axisIndex < 0 || axisIndex >= axes.Length)
					{
						return null;
					}
					return axes[axisIndex];
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Button : Button_Base
			{
				public override object DeepClone()
				{
					Button button = new Button();
					button.ImportVars(this);
					return button;
				}

				private void ImportVars(Button source)
				{
					ImportVars((Button_Base)source);
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Axis : Axis_Base
			{
				public override object DeepClone()
				{
					Axis axis = new Axis();
					axis.ImportVars(this);
					return axis;
				}

				private void ImportVars(Axis source)
				{
					ImportVars((Axis_Base)source);
				}
			}

			private sealed class dehrZVXMMNhmikpEmOoeWUXipaDq : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int tlMAJfIThNfeJStzJNKSrKBFxVMBA;

				private Axis_Base LpBDVFikUEyfCYXUhaYXkuJGSUvR;

				private int inVbRdvwJCJkFrgcaNtgBDMCKoEc;

				public Platform_DirectInput_Base CYueYWUcvvccDZNWdAgTGJJaCSZeb;

				private int LPAWUCcJpCXHxgNwPQEZcDHbRRsb;

				private int CWoeZWCOPIsXWBHSavcifiuaGXPO;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return LpBDVFikUEyfCYXUhaYXkuJGSUvR;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return LpBDVFikUEyfCYXUhaYXkuJGSUvR;
					}
				}

				[DebuggerHidden]
				public dehrZVXMMNhmikpEmOoeWUXipaDq(int P_0)
				{
					tlMAJfIThNfeJStzJNKSrKBFxVMBA = P_0;
					inVbRdvwJCJkFrgcaNtgBDMCKoEc = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					tlMAJfIThNfeJStzJNKSrKBFxVMBA = -2;
				}

				private bool MoveNext()
				{
					int num = tlMAJfIThNfeJStzJNKSrKBFxVMBA;
					Platform_DirectInput_Base cYueYWUcvvccDZNWdAgTGJJaCSZeb = CYueYWUcvvccDZNWdAgTGJJaCSZeb;
					switch (num)
					{
					default:
						return false;
					case 0:
						tlMAJfIThNfeJStzJNKSrKBFxVMBA = -1;
						if (cYueYWUcvvccDZNWdAgTGJJaCSZeb.elements == null || cYueYWUcvvccDZNWdAgTGJJaCSZeb.elements.axes == null)
						{
							return false;
						}
						LPAWUCcJpCXHxgNwPQEZcDHbRRsb = cYueYWUcvvccDZNWdAgTGJJaCSZeb.elements.axes.Length;
						CWoeZWCOPIsXWBHSavcifiuaGXPO = 0;
						break;
					case 1:
						tlMAJfIThNfeJStzJNKSrKBFxVMBA = -1;
						CWoeZWCOPIsXWBHSavcifiuaGXPO++;
						break;
					}
					if (CWoeZWCOPIsXWBHSavcifiuaGXPO < LPAWUCcJpCXHxgNwPQEZcDHbRRsb)
					{
						LpBDVFikUEyfCYXUhaYXkuJGSUvR = cYueYWUcvvccDZNWdAgTGJJaCSZeb.elements.axes[CWoeZWCOPIsXWBHSavcifiuaGXPO];
						tlMAJfIThNfeJStzJNKSrKBFxVMBA = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					dehrZVXMMNhmikpEmOoeWUXipaDq dehrZVXMMNhmikpEmOoeWUXipaDq2;
					if (tlMAJfIThNfeJStzJNKSrKBFxVMBA == -2 && inVbRdvwJCJkFrgcaNtgBDMCKoEc == Environment.CurrentManagedThreadId)
					{
						tlMAJfIThNfeJStzJNKSrKBFxVMBA = 0;
						dehrZVXMMNhmikpEmOoeWUXipaDq2 = this;
					}
					else
					{
						dehrZVXMMNhmikpEmOoeWUXipaDq2 = new dehrZVXMMNhmikpEmOoeWUXipaDq(0);
						dehrZVXMMNhmikpEmOoeWUXipaDq2.CYueYWUcvvccDZNWdAgTGJJaCSZeb = CYueYWUcvvccDZNWdAgTGJJaCSZeb;
					}
					return dehrZVXMMNhmikpEmOoeWUXipaDq2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class IwDWaelmqCjOnYDAWUUqgxxMZvhd : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int cxBlLLXXOpzhFVWzjRLLUPsTZRxA;

				private Button_Base jPsRkmwqFtWNYipDJnwjDKPWFRmu;

				private int oiFbHmizDAjhQTUixPOcCnavpEHO;

				public Platform_DirectInput_Base OvfaeCEtvSjNKxJEMqIPEpFoiYPi;

				private int FHVVnXurIdTUZnBVtJyGfVlfSMNr;

				private int BJWAOLouifceujtoIIumfWkGDfqRB;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return jPsRkmwqFtWNYipDJnwjDKPWFRmu;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return jPsRkmwqFtWNYipDJnwjDKPWFRmu;
					}
				}

				[DebuggerHidden]
				public IwDWaelmqCjOnYDAWUUqgxxMZvhd(int P_0)
				{
					cxBlLLXXOpzhFVWzjRLLUPsTZRxA = P_0;
					oiFbHmizDAjhQTUixPOcCnavpEHO = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					cxBlLLXXOpzhFVWzjRLLUPsTZRxA = -2;
				}

				private bool MoveNext()
				{
					int num = cxBlLLXXOpzhFVWzjRLLUPsTZRxA;
					Platform_DirectInput_Base ovfaeCEtvSjNKxJEMqIPEpFoiYPi = OvfaeCEtvSjNKxJEMqIPEpFoiYPi;
					switch (num)
					{
					default:
						return false;
					case 0:
						cxBlLLXXOpzhFVWzjRLLUPsTZRxA = -1;
						if (ovfaeCEtvSjNKxJEMqIPEpFoiYPi.elements == null || ovfaeCEtvSjNKxJEMqIPEpFoiYPi.elements.buttons == null)
						{
							return false;
						}
						FHVVnXurIdTUZnBVtJyGfVlfSMNr = ovfaeCEtvSjNKxJEMqIPEpFoiYPi.elements.buttons.Length;
						BJWAOLouifceujtoIIumfWkGDfqRB = 0;
						break;
					case 1:
						cxBlLLXXOpzhFVWzjRLLUPsTZRxA = -1;
						BJWAOLouifceujtoIIumfWkGDfqRB++;
						break;
					}
					if (BJWAOLouifceujtoIIumfWkGDfqRB < FHVVnXurIdTUZnBVtJyGfVlfSMNr)
					{
						jPsRkmwqFtWNYipDJnwjDKPWFRmu = ovfaeCEtvSjNKxJEMqIPEpFoiYPi.elements.buttons[BJWAOLouifceujtoIIumfWkGDfqRB];
						cxBlLLXXOpzhFVWzjRLLUPsTZRxA = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					IwDWaelmqCjOnYDAWUUqgxxMZvhd iwDWaelmqCjOnYDAWUUqgxxMZvhd;
					if (cxBlLLXXOpzhFVWzjRLLUPsTZRxA == -2 && oiFbHmizDAjhQTUixPOcCnavpEHO == Environment.CurrentManagedThreadId)
					{
						cxBlLLXXOpzhFVWzjRLLUPsTZRxA = 0;
						iwDWaelmqCjOnYDAWUUqgxxMZvhd = this;
					}
					else
					{
						iwDWaelmqCjOnYDAWUUqgxxMZvhd = new IwDWaelmqCjOnYDAWUUqgxxMZvhd(0);
						iwDWaelmqCjOnYDAWUUqgxxMZvhd.OvfaeCEtvSjNKxJEMqIPEpFoiYPi = OvfaeCEtvSjNKxJEMqIPEpFoiYPi;
					}
					return iwDWaelmqCjOnYDAWUUqgxxMZvhd;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}
			}

			public Elements elements;

			InputPlatform Platform.platform => InputPlatform.WindowsDirectInput;

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			[IteratorStateMachine(typeof(dehrZVXMMNhmikpEmOoeWUXipaDq))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new dehrZVXMMNhmikpEmOoeWUXipaDq(-2)
				{
					CYueYWUcvvccDZNWdAgTGJJaCSZeb = this
				};
			}

			[IteratorStateMachine(typeof(IwDWaelmqCjOnYDAWUUqgxxMZvhd))]
			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new IwDWaelmqCjOnYDAWUUqgxxMZvhd(-2)
				{
					OvfaeCEtvSjNKxJEMqIPEpFoiYPi = this
				};
			}

			public override object DeepClone()
			{
				Platform_DirectInput_Base platform_DirectInput_Base = new Platform_DirectInput_Base();
				CopyVars(platform_DirectInput_Base);
				return platform_DirectInput_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_DirectInput_Base platform_DirectInput_Base)
				{
					platform_DirectInput_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_DirectInput : Platform_DirectInput_Base
		{
			public Platform_DirectInput_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_DirectInput platform_DirectInput = new Platform_DirectInput();
				CopyVars(platform_DirectInput);
				return platform_DirectInput;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_DirectInput platform_DirectInput)
				{
					platform_DirectInput.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_RawInput_Base : Platform_RawOrDirectInput
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Platform_Base
			{
				private sealed class kptDLfgTbNscJsTeqaicSHNhJMzfb : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int BjEPKJXLvPAdhGJyaiWwRnRHDElLA;

					private Axis_Base IgemPnOEIlhsOyNcJkDcWAPYORxi;

					private int mSMcTrCVUmFccXTyNTnrenzSSBKQA;

					public Elements QxiFlXYubonPLNqcPMBzrLsKpNZE;

					private int MSsOyctLvmHBQlOGqfNrHACxLyqH;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return IgemPnOEIlhsOyNcJkDcWAPYORxi;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return IgemPnOEIlhsOyNcJkDcWAPYORxi;
						}
					}

					[DebuggerHidden]
					public kptDLfgTbNscJsTeqaicSHNhJMzfb(int P_0)
					{
						BjEPKJXLvPAdhGJyaiWwRnRHDElLA = P_0;
						mSMcTrCVUmFccXTyNTnrenzSSBKQA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						BjEPKJXLvPAdhGJyaiWwRnRHDElLA = -2;
					}

					private bool MoveNext()
					{
						int bjEPKJXLvPAdhGJyaiWwRnRHDElLA = BjEPKJXLvPAdhGJyaiWwRnRHDElLA;
						Elements qxiFlXYubonPLNqcPMBzrLsKpNZE = QxiFlXYubonPLNqcPMBzrLsKpNZE;
						switch (bjEPKJXLvPAdhGJyaiWwRnRHDElLA)
						{
						default:
							return false;
						case 0:
							BjEPKJXLvPAdhGJyaiWwRnRHDElLA = -1;
							if (qxiFlXYubonPLNqcPMBzrLsKpNZE.axes == null)
							{
								return false;
							}
							MSsOyctLvmHBQlOGqfNrHACxLyqH = 0;
							break;
						case 1:
							BjEPKJXLvPAdhGJyaiWwRnRHDElLA = -1;
							MSsOyctLvmHBQlOGqfNrHACxLyqH++;
							break;
						}
						if (MSsOyctLvmHBQlOGqfNrHACxLyqH < qxiFlXYubonPLNqcPMBzrLsKpNZE.axes.Length)
						{
							IgemPnOEIlhsOyNcJkDcWAPYORxi = qxiFlXYubonPLNqcPMBzrLsKpNZE.axes[MSsOyctLvmHBQlOGqfNrHACxLyqH];
							BjEPKJXLvPAdhGJyaiWwRnRHDElLA = 1;
							return true;
						}
						return false;
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
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						kptDLfgTbNscJsTeqaicSHNhJMzfb kptDLfgTbNscJsTeqaicSHNhJMzfb2;
						if (BjEPKJXLvPAdhGJyaiWwRnRHDElLA == -2 && mSMcTrCVUmFccXTyNTnrenzSSBKQA == Environment.CurrentManagedThreadId)
						{
							BjEPKJXLvPAdhGJyaiWwRnRHDElLA = 0;
							kptDLfgTbNscJsTeqaicSHNhJMzfb2 = this;
						}
						else
						{
							kptDLfgTbNscJsTeqaicSHNhJMzfb2 = new kptDLfgTbNscJsTeqaicSHNhJMzfb(0);
							kptDLfgTbNscJsTeqaicSHNhJMzfb2.QxiFlXYubonPLNqcPMBzrLsKpNZE = QxiFlXYubonPLNqcPMBzrLsKpNZE;
						}
						return kptDLfgTbNscJsTeqaicSHNhJMzfb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class VsJdKWkglWmpdHoEqUyeMuuUWuqp : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int GuPZAILdDOblhvIbgPgcABNrSoPt;

					private Button_Base wJNhAUylCwAmORJdgDVlijxpAAmZA;

					private int bXZhAJszjsDaqFDBpiJgbsrWxdkrA;

					public Elements zVTXMOunMVfLkVNwVrzmbDMNpOxq;

					private int PVemhFHGXLjaejPlNRRzaDGOXOTO;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return wJNhAUylCwAmORJdgDVlijxpAAmZA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return wJNhAUylCwAmORJdgDVlijxpAAmZA;
						}
					}

					[DebuggerHidden]
					public VsJdKWkglWmpdHoEqUyeMuuUWuqp(int P_0)
					{
						GuPZAILdDOblhvIbgPgcABNrSoPt = P_0;
						bXZhAJszjsDaqFDBpiJgbsrWxdkrA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						GuPZAILdDOblhvIbgPgcABNrSoPt = -2;
					}

					private bool MoveNext()
					{
						int guPZAILdDOblhvIbgPgcABNrSoPt = GuPZAILdDOblhvIbgPgcABNrSoPt;
						Elements elements = zVTXMOunMVfLkVNwVrzmbDMNpOxq;
						switch (guPZAILdDOblhvIbgPgcABNrSoPt)
						{
						default:
							return false;
						case 0:
							GuPZAILdDOblhvIbgPgcABNrSoPt = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							PVemhFHGXLjaejPlNRRzaDGOXOTO = 0;
							break;
						case 1:
							GuPZAILdDOblhvIbgPgcABNrSoPt = -1;
							PVemhFHGXLjaejPlNRRzaDGOXOTO++;
							break;
						}
						if (PVemhFHGXLjaejPlNRRzaDGOXOTO < elements.buttons.Length)
						{
							wJNhAUylCwAmORJdgDVlijxpAAmZA = elements.buttons[PVemhFHGXLjaejPlNRRzaDGOXOTO];
							GuPZAILdDOblhvIbgPgcABNrSoPt = 1;
							return true;
						}
						return false;
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
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						VsJdKWkglWmpdHoEqUyeMuuUWuqp vsJdKWkglWmpdHoEqUyeMuuUWuqp;
						if (GuPZAILdDOblhvIbgPgcABNrSoPt == -2 && bXZhAJszjsDaqFDBpiJgbsrWxdkrA == Environment.CurrentManagedThreadId)
						{
							GuPZAILdDOblhvIbgPgcABNrSoPt = 0;
							vsJdKWkglWmpdHoEqUyeMuuUWuqp = this;
						}
						else
						{
							vsJdKWkglWmpdHoEqUyeMuuUWuqp = new VsJdKWkglWmpdHoEqUyeMuuUWuqp(0);
							vsJdKWkglWmpdHoEqUyeMuuUWuqp.zVTXMOunMVfLkVNwVrzmbDMNpOxq = zVTXMOunMVfLkVNwVrzmbDMNpOxq;
						}
						return vsJdKWkglWmpdHoEqUyeMuuUWuqp;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				IEnumerable<Axis_Base> Elements_Platform_Base.Axes
				{
					[IteratorStateMachine(typeof(kptDLfgTbNscJsTeqaicSHNhJMzfb))]
					get
					{
						return new kptDLfgTbNscJsTeqaicSHNhJMzfb(-2)
						{
							QxiFlXYubonPLNqcPMBzrLsKpNZE = this
						};
					}
				}

				IEnumerable<Button_Base> Elements_Platform_Base.Buttons
				{
					[IteratorStateMachine(typeof(VsJdKWkglWmpdHoEqUyeMuuUWuqp))]
					get
					{
						return new VsJdKWkglWmpdHoEqUyeMuuUWuqp(-2)
						{
							zVTXMOunMVfLkVNwVrzmbDMNpOxq = this
						};
					}
				}

				internal override Axis_Base GetAxis(int axisIndex)
				{
					if (axes == null || axisIndex < 0 || axisIndex >= axes.Length)
					{
						return null;
					}
					return axes[axisIndex];
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
						case HardwareElementSourceTypeWithHat.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Button : Button_Base
			{
				public int sourceOtherAxis;

				public override object DeepClone()
				{
					Button button = new Button();
					button.ImportVars(this);
					return button;
				}

				private void ImportVars(Button source)
				{
					ImportVars((Button_Base)source);
					sourceOtherAxis = source.sourceOtherAxis;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Axis : Axis_Base
			{
				public int sourceOtherAxis;

				public override object DeepClone()
				{
					Axis axis = new Axis();
					axis.ImportVars(this);
					return axis;
				}

				private void ImportVars(Axis source)
				{
					ImportVars((Axis_Base)source);
					sourceOtherAxis = source.sourceOtherAxis;
				}
			}

			private sealed class gpyPGqMSxtKdTgmLwhrmGkTNrxLx : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int accFhshJUZqhUDnToKFjQRJuRvQL;

				private Axis_Base gaVbdwJIdgdEdbWsAxqIVxBLsGRpB;

				private int suYaOEzRayvRydMoIxueRphaYYyi;

				public Platform_RawInput_Base qbSGwKSDFhyYhGomCkYEOVvrBRMX;

				private int hPSyHhtCCBCXLYGBVUgDYLMDHTSw;

				private int NECjgPIBtATmKLFjIlXATSyhVQdtA;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return gaVbdwJIdgdEdbWsAxqIVxBLsGRpB;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return gaVbdwJIdgdEdbWsAxqIVxBLsGRpB;
					}
				}

				[DebuggerHidden]
				public gpyPGqMSxtKdTgmLwhrmGkTNrxLx(int P_0)
				{
					accFhshJUZqhUDnToKFjQRJuRvQL = P_0;
					suYaOEzRayvRydMoIxueRphaYYyi = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					accFhshJUZqhUDnToKFjQRJuRvQL = -2;
				}

				private bool MoveNext()
				{
					int num = accFhshJUZqhUDnToKFjQRJuRvQL;
					Platform_RawInput_Base platform_RawInput_Base = qbSGwKSDFhyYhGomCkYEOVvrBRMX;
					switch (num)
					{
					default:
						return false;
					case 0:
						accFhshJUZqhUDnToKFjQRJuRvQL = -1;
						if (platform_RawInput_Base.elements == null || platform_RawInput_Base.elements.axes == null)
						{
							return false;
						}
						hPSyHhtCCBCXLYGBVUgDYLMDHTSw = platform_RawInput_Base.elements.axes.Length;
						NECjgPIBtATmKLFjIlXATSyhVQdtA = 0;
						break;
					case 1:
						accFhshJUZqhUDnToKFjQRJuRvQL = -1;
						NECjgPIBtATmKLFjIlXATSyhVQdtA++;
						break;
					}
					if (NECjgPIBtATmKLFjIlXATSyhVQdtA < hPSyHhtCCBCXLYGBVUgDYLMDHTSw)
					{
						gaVbdwJIdgdEdbWsAxqIVxBLsGRpB = platform_RawInput_Base.elements.axes[NECjgPIBtATmKLFjIlXATSyhVQdtA];
						accFhshJUZqhUDnToKFjQRJuRvQL = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					gpyPGqMSxtKdTgmLwhrmGkTNrxLx gpyPGqMSxtKdTgmLwhrmGkTNrxLx2;
					if (accFhshJUZqhUDnToKFjQRJuRvQL == -2 && suYaOEzRayvRydMoIxueRphaYYyi == Environment.CurrentManagedThreadId)
					{
						accFhshJUZqhUDnToKFjQRJuRvQL = 0;
						gpyPGqMSxtKdTgmLwhrmGkTNrxLx2 = this;
					}
					else
					{
						gpyPGqMSxtKdTgmLwhrmGkTNrxLx2 = new gpyPGqMSxtKdTgmLwhrmGkTNrxLx(0);
						gpyPGqMSxtKdTgmLwhrmGkTNrxLx2.qbSGwKSDFhyYhGomCkYEOVvrBRMX = qbSGwKSDFhyYhGomCkYEOVvrBRMX;
					}
					return gpyPGqMSxtKdTgmLwhrmGkTNrxLx2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class mMybvrpyNDcTnnboJpLwlukjnmxd : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int AfHbHPBuEdByVJcNwTDbKxFjXSku;

				private Button_Base sypZSCSyNRuABFCprNZMOrQdiTTE;

				private int HjeDStCCHNcRiEcCDEvzVEDjIfeVB;

				public Platform_RawInput_Base IVLvohvnQDdpNAQAiiPudyVMBmJuA;

				private int nsucJuvNCHhqlPIYolskgXYZhhaF;

				private int zcrXtiRibeBfBOtcBdiAThAEjNqp;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return sypZSCSyNRuABFCprNZMOrQdiTTE;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return sypZSCSyNRuABFCprNZMOrQdiTTE;
					}
				}

				[DebuggerHidden]
				public mMybvrpyNDcTnnboJpLwlukjnmxd(int P_0)
				{
					AfHbHPBuEdByVJcNwTDbKxFjXSku = P_0;
					HjeDStCCHNcRiEcCDEvzVEDjIfeVB = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					AfHbHPBuEdByVJcNwTDbKxFjXSku = -2;
				}

				private bool MoveNext()
				{
					int afHbHPBuEdByVJcNwTDbKxFjXSku = AfHbHPBuEdByVJcNwTDbKxFjXSku;
					Platform_RawInput_Base iVLvohvnQDdpNAQAiiPudyVMBmJuA = IVLvohvnQDdpNAQAiiPudyVMBmJuA;
					switch (afHbHPBuEdByVJcNwTDbKxFjXSku)
					{
					default:
						return false;
					case 0:
						AfHbHPBuEdByVJcNwTDbKxFjXSku = -1;
						if (iVLvohvnQDdpNAQAiiPudyVMBmJuA.elements == null || iVLvohvnQDdpNAQAiiPudyVMBmJuA.elements.buttons == null)
						{
							return false;
						}
						nsucJuvNCHhqlPIYolskgXYZhhaF = iVLvohvnQDdpNAQAiiPudyVMBmJuA.elements.buttons.Length;
						zcrXtiRibeBfBOtcBdiAThAEjNqp = 0;
						break;
					case 1:
						AfHbHPBuEdByVJcNwTDbKxFjXSku = -1;
						zcrXtiRibeBfBOtcBdiAThAEjNqp++;
						break;
					}
					if (zcrXtiRibeBfBOtcBdiAThAEjNqp < nsucJuvNCHhqlPIYolskgXYZhhaF)
					{
						sypZSCSyNRuABFCprNZMOrQdiTTE = iVLvohvnQDdpNAQAiiPudyVMBmJuA.elements.buttons[zcrXtiRibeBfBOtcBdiAThAEjNqp];
						AfHbHPBuEdByVJcNwTDbKxFjXSku = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					mMybvrpyNDcTnnboJpLwlukjnmxd mMybvrpyNDcTnnboJpLwlukjnmxd2;
					if (AfHbHPBuEdByVJcNwTDbKxFjXSku == -2 && HjeDStCCHNcRiEcCDEvzVEDjIfeVB == Environment.CurrentManagedThreadId)
					{
						AfHbHPBuEdByVJcNwTDbKxFjXSku = 0;
						mMybvrpyNDcTnnboJpLwlukjnmxd2 = this;
					}
					else
					{
						mMybvrpyNDcTnnboJpLwlukjnmxd2 = new mMybvrpyNDcTnnboJpLwlukjnmxd(0);
						mMybvrpyNDcTnnboJpLwlukjnmxd2.IVLvohvnQDdpNAQAiiPudyVMBmJuA = IVLvohvnQDdpNAQAiiPudyVMBmJuA;
					}
					return mMybvrpyNDcTnnboJpLwlukjnmxd2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}
			}

			public Elements elements;

			InputPlatform Platform.platform => InputPlatform.WindowsRawInput;

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			[IteratorStateMachine(typeof(gpyPGqMSxtKdTgmLwhrmGkTNrxLx))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new gpyPGqMSxtKdTgmLwhrmGkTNrxLx(-2)
				{
					qbSGwKSDFhyYhGomCkYEOVvrBRMX = this
				};
			}

			[IteratorStateMachine(typeof(mMybvrpyNDcTnnboJpLwlukjnmxd))]
			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new mMybvrpyNDcTnnboJpLwlukjnmxd(-2)
				{
					IVLvohvnQDdpNAQAiiPudyVMBmJuA = this
				};
			}

			public override object DeepClone()
			{
				Platform_RawInput_Base platform_RawInput_Base = new Platform_RawInput_Base();
				CopyVars(platform_RawInput_Base);
				return platform_RawInput_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_RawInput_Base platform_RawInput_Base)
				{
					platform_RawInput_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_RawInput : Platform_RawInput_Base
		{
			public Platform_RawInput_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_RawInput platform_RawInput = new Platform_RawInput();
				CopyVars(platform_RawInput);
				return platform_RawInput;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_RawInput platform_RawInput)
				{
					platform_RawInput.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_XInput_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				public XInputDeviceSubType[] subType;

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (subType.Length == 0)
						{
							return false;
						}
						return true;
					}
				}

				bool MatchingCriteria_Base.isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				int MatchingCriteria_Base.alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (disabled)
					{
						return false;
					}
					if (!isAllowed)
					{
						return false;
					}
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					for (int i = 0; i < subType.Length; i++)
					{
						if (subType[i] == bridgedControllerHWInfo.hw_xInputSubType)
						{
							return true;
						}
					}
					return false;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.subType = ArrayTools.ShallowCopy(subType);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceType.Axis:
						case HardwareElementSourceType.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceType.Button:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public int elementIdentifier;

				public HardwareElementSourceType sourceType;

				public XInputButton sourceButton;

				public XInputAxis sourceAxis;

				public float axisDeadZone;

				public abstract object DeepClone();

				internal virtual void CopyVars(Element destination)
				{
					destination.elementIdentifier = elementIdentifier;
					destination.sourceType = sourceType;
					destination.sourceButton = sourceButton;
					destination.sourceAxis = sourceAxis;
					destination.axisDeadZone = axisDeadZone;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Button : Element
			{
				public Pole sourceAxisPole;

				public HardwareButtonInfo buttonInfo;

				public Button()
				{
					sourceType = HardwareElementSourceType.Button;
				}

				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Button button)
					{
						button.sourceAxisPole = sourceAxisPole;
						button.buttonInfo = MiscTools.DeepClone(buttonInfo);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Axis : Element
			{
				public bool invert;

				public Pole buttonAxisContribution;

				public AxisRange sourceAxisRange;

				public float axisUpperDeadZone;

				public BoolWithDefault calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				public Axis()
				{
					sourceType = HardwareElementSourceType.Axis;
				}

				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Axis axis)
					{
						axis.invert = invert;
						axis.buttonAxisContribution = buttonAxisContribution;
						axis.sourceAxisRange = sourceAxisRange;
						axis.axisUpperDeadZone = axisUpperDeadZone;
						axis.calibrateAxis = calibrateAxis;
						axis.axisZero = axisZero;
						axis.axisMin = axisMin;
						axis.axisMax = axisMax;
						axis.axisInfo = MiscTools.DeepClone(axisInfo);
						axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
					}
				}
			}

			private sealed class FUfAIPiaBkmCwbIqJxncVAsjSRBi : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int vPUaqHfYlrKkrmcArHFiomOJATFm;

				private Axis dAmDGkcBseDqJmYwzhIlFnbJJkgU;

				private int MwrZrUoDUWQtzGEwHSfpHlGgHlPiA;

				public Platform_XInput_Base gYjhaqqMGkCCsHniOdgqWUgUdCpIb;

				private int GUJcYrwZYSgiVqyGzxjDuBEsfVRA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return dAmDGkcBseDqJmYwzhIlFnbJJkgU;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return dAmDGkcBseDqJmYwzhIlFnbJJkgU;
					}
				}

				[DebuggerHidden]
				public FUfAIPiaBkmCwbIqJxncVAsjSRBi(int P_0)
				{
					vPUaqHfYlrKkrmcArHFiomOJATFm = P_0;
					MwrZrUoDUWQtzGEwHSfpHlGgHlPiA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					vPUaqHfYlrKkrmcArHFiomOJATFm = -2;
				}

				private bool MoveNext()
				{
					int num = vPUaqHfYlrKkrmcArHFiomOJATFm;
					Platform_XInput_Base platform_XInput_Base = gYjhaqqMGkCCsHniOdgqWUgUdCpIb;
					switch (num)
					{
					default:
						return false;
					case 0:
						vPUaqHfYlrKkrmcArHFiomOJATFm = -1;
						if (platform_XInput_Base.elements == null || platform_XInput_Base.elements.axes == null)
						{
							return false;
						}
						GUJcYrwZYSgiVqyGzxjDuBEsfVRA = 0;
						break;
					case 1:
						vPUaqHfYlrKkrmcArHFiomOJATFm = -1;
						GUJcYrwZYSgiVqyGzxjDuBEsfVRA++;
						break;
					}
					if (GUJcYrwZYSgiVqyGzxjDuBEsfVRA < platform_XInput_Base.elements.axes.Length)
					{
						dAmDGkcBseDqJmYwzhIlFnbJJkgU = platform_XInput_Base.elements.axes[GUJcYrwZYSgiVqyGzxjDuBEsfVRA];
						vPUaqHfYlrKkrmcArHFiomOJATFm = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					FUfAIPiaBkmCwbIqJxncVAsjSRBi fUfAIPiaBkmCwbIqJxncVAsjSRBi;
					if (vPUaqHfYlrKkrmcArHFiomOJATFm == -2 && MwrZrUoDUWQtzGEwHSfpHlGgHlPiA == Environment.CurrentManagedThreadId)
					{
						vPUaqHfYlrKkrmcArHFiomOJATFm = 0;
						fUfAIPiaBkmCwbIqJxncVAsjSRBi = this;
					}
					else
					{
						fUfAIPiaBkmCwbIqJxncVAsjSRBi = new FUfAIPiaBkmCwbIqJxncVAsjSRBi(0);
						fUfAIPiaBkmCwbIqJxncVAsjSRBi.gYjhaqqMGkCCsHniOdgqWUgUdCpIb = gYjhaqqMGkCCsHniOdgqWUgUdCpIb;
					}
					return fUfAIPiaBkmCwbIqJxncVAsjSRBi;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class hNKzbBKBPcppgECRUxLXksethxeh : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int nUDjlhlDuwZPyInzjZFTuRiGzLxL;

				private Button qsYFsxYAgrmCyjVxUjbmXdqOgiAT;

				private int xuofdrACZhAbJAqwqALnxnPGBTGeA;

				public Platform_XInput_Base hICuonmbCyOhDSNbFvyIfBkteRzq;

				private int cHewqeHVnMKEvxZLHSEqqptgDeWfA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return qsYFsxYAgrmCyjVxUjbmXdqOgiAT;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return qsYFsxYAgrmCyjVxUjbmXdqOgiAT;
					}
				}

				[DebuggerHidden]
				public hNKzbBKBPcppgECRUxLXksethxeh(int P_0)
				{
					nUDjlhlDuwZPyInzjZFTuRiGzLxL = P_0;
					xuofdrACZhAbJAqwqALnxnPGBTGeA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					nUDjlhlDuwZPyInzjZFTuRiGzLxL = -2;
				}

				private bool MoveNext()
				{
					int num = nUDjlhlDuwZPyInzjZFTuRiGzLxL;
					Platform_XInput_Base platform_XInput_Base = hICuonmbCyOhDSNbFvyIfBkteRzq;
					switch (num)
					{
					default:
						return false;
					case 0:
						nUDjlhlDuwZPyInzjZFTuRiGzLxL = -1;
						if (platform_XInput_Base.elements == null || platform_XInput_Base.elements.buttons == null)
						{
							return false;
						}
						cHewqeHVnMKEvxZLHSEqqptgDeWfA = 0;
						break;
					case 1:
						nUDjlhlDuwZPyInzjZFTuRiGzLxL = -1;
						cHewqeHVnMKEvxZLHSEqqptgDeWfA++;
						break;
					}
					if (cHewqeHVnMKEvxZLHSEqqptgDeWfA < platform_XInput_Base.elements.buttons.Length)
					{
						qsYFsxYAgrmCyjVxUjbmXdqOgiAT = platform_XInput_Base.elements.buttons[cHewqeHVnMKEvxZLHSEqqptgDeWfA];
						nUDjlhlDuwZPyInzjZFTuRiGzLxL = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					hNKzbBKBPcppgECRUxLXksethxeh hNKzbBKBPcppgECRUxLXksethxeh2;
					if (nUDjlhlDuwZPyInzjZFTuRiGzLxL == -2 && xuofdrACZhAbJAqwqALnxnPGBTGeA == Environment.CurrentManagedThreadId)
					{
						nUDjlhlDuwZPyInzjZFTuRiGzLxL = 0;
						hNKzbBKBPcppgECRUxLXksethxeh2 = this;
					}
					else
					{
						hNKzbBKBPcppgECRUxLXksethxeh2 = new hNKzbBKBPcppgECRUxLXksethxeh(0);
						hNKzbBKBPcppgECRUxLXksethxeh2.hICuonmbCyOhDSNbFvyIfBkteRzq = hICuonmbCyOhDSNbFvyIfBkteRzq;
					}
					return hNKzbBKBPcppgECRUxLXksethxeh2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			InputPlatform Platform.platform => InputPlatform.WindowsXInput;

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(FUfAIPiaBkmCwbIqJxncVAsjSRBi))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new FUfAIPiaBkmCwbIqJxncVAsjSRBi(-2)
				{
					gYjhaqqMGkCCsHniOdgqWUgUdCpIb = this
				};
			}

			[IteratorStateMachine(typeof(hNKzbBKBPcppgECRUxLXksethxeh))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new hNKzbBKBPcppgECRUxLXksethxeh(-2)
				{
					hICuonmbCyOhDSNbFvyIfBkteRzq = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceType.Axis || axes_orig[i].sourceType == HardwareElementSourceType.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceType.Button)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceType.Axis || Axes_orig[i].sourceType == HardwareElementSourceType.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceType.Button)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_XInput_Base platform_XInput_Base = new Platform_XInput_Base();
				CopyVars(platform_XInput_Base);
				return platform_XInput_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (destination is Platform_XInput_Base platform_XInput_Base)
				{
					platform_XInput_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_XInput_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_XInput : Platform_XInput_Base
		{
			public Platform_XInput_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_XInput platform_XInput = new Platform_XInput();
				CopyVars(platform_XInput);
				return platform_XInput;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_XInput platform_XInput)
				{
					platform_XInput.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_OSX_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						ElementCount elementCount = new ElementCount();
						HXqFlTmkJgbaqWaoLySOLJbfONWh(elementCount);
						return elementCount;
					}

					internal void RmdWVMjfZWcCmoGopFWxhxrzLJrP(ElementCount_Base P_0)
					{
						base.HXqFlTmkJgbaqWaoLySOLJbfONWh(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool nCHNwuDPpYXeHgvKVxsZpCoZeJKb(BridgedControllerHWInfo P_0)
					{
						if (!base.iJhYiAkXCqAZNrwRvcAgXrMBxdoL(P_0))
						{
							return false;
						}
						if (hatCount >= 0)
						{
							return hatCount == P_0.hardwareHatCount;
						}
						return true;
					}
				}

				public int hatCount;

				public ElementCount[] alternateElementCounts;

				public bool productName_useRegex;

				public string[] productName;

				public string[] manufacturer;

				public int[] productId;

				public int[] vendorId;

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						if (productId != null && productId.Length != 0 && vendorId != null && vendorId.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				int MatchingCriteria_Base.alternateElementCount
				{
					get
					{
						if (alternateElementCounts == null)
						{
							return 0;
						}
						return alternateElementCounts.Length;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (strictMatch)
					{
						bool flag = false;
						for (int i = 0; i < vendorId.Length; i++)
						{
							if (vendorId[i] == bridgedControllerHWInfo.hw_vendorId && i < productId.Length && productId[i] == bridgedControllerHWInfo.hw_productId)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							return false;
						}
						if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
						{
							string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
							if (!ProductNameMatches(name))
							{
								return false;
							}
						}
						return true;
					}
					string text = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
					text = text.Trim();
					if (!ProductNameMatches(text))
					{
						return false;
					}
					return true;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
					{
						return null;
					}
					return alternateElementCounts[index];
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (alternateMatched)
					{
						return true;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
				}

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						string text = ((productName[i] == null) ? string.Empty : productName[i]);
						text = text.Trim();
						if (MatchingCriteria_Base.StringMatches(name, text, productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.alternateElementCounts = ArrayTools.ShallowCopy(alternateElementCounts);
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
						matchingCriteria.productId = ArrayTools.ShallowCopy(productId);
						matchingCriteria.vendorId = ArrayTools.ShallowCopy(vendorId);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class ygPkXPUoKFTbYjRYtdOnUepceWKF : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int MxhPLeZGRRIFdmYoqaYktTRtXMTg;

					private Axis TZTYvduzQfAGhWCNXmHdUaeDLMAT;

					private int ISnNIpYOudAKfsUewNZLwmaLcnAp;

					public Elements mSYTpvLGoLnUxhZExFNMYGjBMumD;

					private Axis[] HaZQtJCCSoTXTXdUNwxGYOKPNyUd;

					private int MhyHIdRNcfQpfHMleoEdCMUKjeab;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return TZTYvduzQfAGhWCNXmHdUaeDLMAT;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return TZTYvduzQfAGhWCNXmHdUaeDLMAT;
						}
					}

					[DebuggerHidden]
					public ygPkXPUoKFTbYjRYtdOnUepceWKF(int P_0)
					{
						MxhPLeZGRRIFdmYoqaYktTRtXMTg = P_0;
						ISnNIpYOudAKfsUewNZLwmaLcnAp = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						HaZQtJCCSoTXTXdUNwxGYOKPNyUd = null;
						MxhPLeZGRRIFdmYoqaYktTRtXMTg = -2;
					}

					private bool MoveNext()
					{
						int mxhPLeZGRRIFdmYoqaYktTRtXMTg = MxhPLeZGRRIFdmYoqaYktTRtXMTg;
						Elements elements = mSYTpvLGoLnUxhZExFNMYGjBMumD;
						switch (mxhPLeZGRRIFdmYoqaYktTRtXMTg)
						{
						default:
							return false;
						case 0:
							MxhPLeZGRRIFdmYoqaYktTRtXMTg = -1;
							if (elements.axes == null)
							{
								return false;
							}
							HaZQtJCCSoTXTXdUNwxGYOKPNyUd = elements.axes;
							MhyHIdRNcfQpfHMleoEdCMUKjeab = 0;
							break;
						case 1:
							MxhPLeZGRRIFdmYoqaYktTRtXMTg = -1;
							MhyHIdRNcfQpfHMleoEdCMUKjeab++;
							break;
						}
						if (MhyHIdRNcfQpfHMleoEdCMUKjeab < HaZQtJCCSoTXTXdUNwxGYOKPNyUd.Length)
						{
							Axis tZTYvduzQfAGhWCNXmHdUaeDLMAT = HaZQtJCCSoTXTXdUNwxGYOKPNyUd[MhyHIdRNcfQpfHMleoEdCMUKjeab];
							TZTYvduzQfAGhWCNXmHdUaeDLMAT = tZTYvduzQfAGhWCNXmHdUaeDLMAT;
							MxhPLeZGRRIFdmYoqaYktTRtXMTg = 1;
							return true;
						}
						HaZQtJCCSoTXTXdUNwxGYOKPNyUd = null;
						return false;
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						ygPkXPUoKFTbYjRYtdOnUepceWKF ygPkXPUoKFTbYjRYtdOnUepceWKF2;
						if (MxhPLeZGRRIFdmYoqaYktTRtXMTg == -2 && ISnNIpYOudAKfsUewNZLwmaLcnAp == Environment.CurrentManagedThreadId)
						{
							MxhPLeZGRRIFdmYoqaYktTRtXMTg = 0;
							ygPkXPUoKFTbYjRYtdOnUepceWKF2 = this;
						}
						else
						{
							ygPkXPUoKFTbYjRYtdOnUepceWKF2 = new ygPkXPUoKFTbYjRYtdOnUepceWKF(0);
							ygPkXPUoKFTbYjRYtdOnUepceWKF2.mSYTpvLGoLnUxhZExFNMYGjBMumD = mSYTpvLGoLnUxhZExFNMYGjBMumD;
						}
						return ygPkXPUoKFTbYjRYtdOnUepceWKF2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class VaFhzxbJwsaMbTszuljzHUhcBpEIc : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int AllnhowhIUSYmiwiAaYFMVhXILss;

					private Button voaaCvfoSnoOGWgQIFCgBeUdBAiNB;

					private int SUOgAwIgRJQLvzbTRQoExrUXHDh;

					public Elements VWOpaxHePvTtNIrwiRPHykcuOcaw;

					private Button[] yQBVNuDkfPdnVxjuuMgfgKlgjGBu;

					private int JxKYFwOSMhhfruXYsBfEKgWTWuCG;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return voaaCvfoSnoOGWgQIFCgBeUdBAiNB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return voaaCvfoSnoOGWgQIFCgBeUdBAiNB;
						}
					}

					[DebuggerHidden]
					public VaFhzxbJwsaMbTszuljzHUhcBpEIc(int P_0)
					{
						AllnhowhIUSYmiwiAaYFMVhXILss = P_0;
						SUOgAwIgRJQLvzbTRQoExrUXHDh = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						yQBVNuDkfPdnVxjuuMgfgKlgjGBu = null;
						AllnhowhIUSYmiwiAaYFMVhXILss = -2;
					}

					private bool MoveNext()
					{
						int allnhowhIUSYmiwiAaYFMVhXILss = AllnhowhIUSYmiwiAaYFMVhXILss;
						Elements vWOpaxHePvTtNIrwiRPHykcuOcaw = VWOpaxHePvTtNIrwiRPHykcuOcaw;
						switch (allnhowhIUSYmiwiAaYFMVhXILss)
						{
						default:
							return false;
						case 0:
							AllnhowhIUSYmiwiAaYFMVhXILss = -1;
							if (vWOpaxHePvTtNIrwiRPHykcuOcaw.buttons == null)
							{
								return false;
							}
							yQBVNuDkfPdnVxjuuMgfgKlgjGBu = vWOpaxHePvTtNIrwiRPHykcuOcaw.buttons;
							JxKYFwOSMhhfruXYsBfEKgWTWuCG = 0;
							break;
						case 1:
							AllnhowhIUSYmiwiAaYFMVhXILss = -1;
							JxKYFwOSMhhfruXYsBfEKgWTWuCG++;
							break;
						}
						if (JxKYFwOSMhhfruXYsBfEKgWTWuCG < yQBVNuDkfPdnVxjuuMgfgKlgjGBu.Length)
						{
							Button button = yQBVNuDkfPdnVxjuuMgfgKlgjGBu[JxKYFwOSMhhfruXYsBfEKgWTWuCG];
							voaaCvfoSnoOGWgQIFCgBeUdBAiNB = button;
							AllnhowhIUSYmiwiAaYFMVhXILss = 1;
							return true;
						}
						yQBVNuDkfPdnVxjuuMgfgKlgjGBu = null;
						return false;
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						VaFhzxbJwsaMbTszuljzHUhcBpEIc vaFhzxbJwsaMbTszuljzHUhcBpEIc;
						if (AllnhowhIUSYmiwiAaYFMVhXILss == -2 && SUOgAwIgRJQLvzbTRQoExrUXHDh == Environment.CurrentManagedThreadId)
						{
							AllnhowhIUSYmiwiAaYFMVhXILss = 0;
							vaFhzxbJwsaMbTszuljzHUhcBpEIc = this;
						}
						else
						{
							vaFhzxbJwsaMbTszuljzHUhcBpEIc = new VaFhzxbJwsaMbTszuljzHUhcBpEIc(0);
							vaFhzxbJwsaMbTszuljzHUhcBpEIc.VWOpaxHePvTtNIrwiRPHykcuOcaw = VWOpaxHePvTtNIrwiRPHykcuOcaw;
						}
						return vaFhzxbJwsaMbTszuljzHUhcBpEIc;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				[IteratorStateMachine(typeof(ygPkXPUoKFTbYjRYtdOnUepceWKF))]
				public IEnumerable<Axis> IterateAxes()
				{
					return new ygPkXPUoKFTbYjRYtdOnUepceWKF(-2)
					{
						mSYTpvLGoLnUxhZExFNMYGjBMumD = this
					};
				}

				[IteratorStateMachine(typeof(VaFhzxbJwsaMbTszuljzHUhcBpEIc))]
				public IEnumerable<Button> IterateButtons()
				{
					return new VaFhzxbJwsaMbTszuljzHUhcBpEIc(-2)
					{
						VWOpaxHePvTtNIrwiRPHykcuOcaw = this
					};
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
						case HardwareElementSourceTypeWithHat.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public abstract object DeepClone();
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Button : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceButton;

				public int sourceStick;

				public OSXAxis sourceAxis;

				public int sourceOtherAxis;

				public Pole sourceAxisPole;

				public float axisDeadZone;

				public int sourceHat;

				public HatType sourceHatType;

				public HatDirection sourceHatDirection;

				public bool requireMultipleButtons;

				public int[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public int[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				public Button()
				{
					sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				public override object DeepClone()
				{
					return new Button
					{
						elementIdentifier = elementIdentifier,
						sourceType = sourceType,
						sourceButton = sourceButton,
						sourceStick = sourceStick,
						sourceAxis = sourceAxis,
						sourceOtherAxis = sourceOtherAxis,
						sourceAxisPole = sourceAxisPole,
						axisDeadZone = axisDeadZone,
						sourceHat = sourceHat,
						sourceHatType = sourceHatType,
						sourceHatDirection = sourceHatDirection,
						requireMultipleButtons = requireMultipleButtons,
						requiredButtons = ArrayTools.ShallowCopy(requiredButtons),
						ignoreIfButtonsActive = ignoreIfButtonsActive,
						ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons),
						buttonInfo = MiscTools.DeepClone(buttonInfo)
					};
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Axis : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceStick;

				public OSXAxis sourceAxis;

				public int sourceOtherAxis;

				public AxisRange sourceAxisRange;

				public bool invert;

				public float axisDeadZone;

				public float axisUpperDeadZone;

				public BoolWithDefault calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				public int sourceButton;

				public Pole buttonAxisContribution;

				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public AxisRange sourceHatRange;

				public Axis()
				{
					sourceType = HardwareElementSourceTypeWithHat.Axis;
					axisZero = 0f;
					axisMin = -1f;
					axisMax = 1f;
				}

				public override object DeepClone()
				{
					return new Axis
					{
						elementIdentifier = elementIdentifier,
						sourceType = sourceType,
						sourceStick = sourceStick,
						sourceAxis = sourceAxis,
						sourceOtherAxis = sourceOtherAxis,
						sourceAxisRange = sourceAxisRange,
						invert = invert,
						axisDeadZone = axisDeadZone,
						axisUpperDeadZone = axisUpperDeadZone,
						calibrateAxis = calibrateAxis,
						axisZero = axisZero,
						axisMin = axisMin,
						axisMax = axisMax,
						axisInfo = MiscTools.DeepClone(axisInfo),
						sourceButton = sourceButton,
						buttonAxisContribution = buttonAxisContribution,
						sourceHat = sourceHat,
						sourceHatDirection = sourceHatDirection,
						sourceHatRange = sourceHatRange,
						alternateCalibrations = MiscTools.DeepClone(alternateCalibrations)
					};
				}
			}

			private sealed class GqFHPBeIGNbppAMSxTnXOVAdzfwo : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int HzseOearcoNOQLWWgUVhhwOoeJLZ;

				private Axis vmJsbUjAHhRnKBKRSCZtBTGjbTHD;

				private int OSUKXgqUZRAVikyvXVWklavQYlii;

				public Platform_OSX_Base rqxHKOEGWKtbmbBOKWttHkTXqJdn;

				private int xsKBRpeTTUfOkTRacOvFcRgmOfLB;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vmJsbUjAHhRnKBKRSCZtBTGjbTHD;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vmJsbUjAHhRnKBKRSCZtBTGjbTHD;
					}
				}

				[DebuggerHidden]
				public GqFHPBeIGNbppAMSxTnXOVAdzfwo(int P_0)
				{
					HzseOearcoNOQLWWgUVhhwOoeJLZ = P_0;
					OSUKXgqUZRAVikyvXVWklavQYlii = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					HzseOearcoNOQLWWgUVhhwOoeJLZ = -2;
				}

				private bool MoveNext()
				{
					int hzseOearcoNOQLWWgUVhhwOoeJLZ = HzseOearcoNOQLWWgUVhhwOoeJLZ;
					Platform_OSX_Base platform_OSX_Base = rqxHKOEGWKtbmbBOKWttHkTXqJdn;
					switch (hzseOearcoNOQLWWgUVhhwOoeJLZ)
					{
					default:
						return false;
					case 0:
						HzseOearcoNOQLWWgUVhhwOoeJLZ = -1;
						if (platform_OSX_Base.elements == null || platform_OSX_Base.elements.axes == null)
						{
							return false;
						}
						xsKBRpeTTUfOkTRacOvFcRgmOfLB = 0;
						break;
					case 1:
						HzseOearcoNOQLWWgUVhhwOoeJLZ = -1;
						xsKBRpeTTUfOkTRacOvFcRgmOfLB++;
						break;
					}
					if (xsKBRpeTTUfOkTRacOvFcRgmOfLB < platform_OSX_Base.elements.axes.Length)
					{
						vmJsbUjAHhRnKBKRSCZtBTGjbTHD = platform_OSX_Base.elements.axes[xsKBRpeTTUfOkTRacOvFcRgmOfLB];
						HzseOearcoNOQLWWgUVhhwOoeJLZ = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					GqFHPBeIGNbppAMSxTnXOVAdzfwo gqFHPBeIGNbppAMSxTnXOVAdzfwo;
					if (HzseOearcoNOQLWWgUVhhwOoeJLZ == -2 && OSUKXgqUZRAVikyvXVWklavQYlii == Environment.CurrentManagedThreadId)
					{
						HzseOearcoNOQLWWgUVhhwOoeJLZ = 0;
						gqFHPBeIGNbppAMSxTnXOVAdzfwo = this;
					}
					else
					{
						gqFHPBeIGNbppAMSxTnXOVAdzfwo = new GqFHPBeIGNbppAMSxTnXOVAdzfwo(0);
						gqFHPBeIGNbppAMSxTnXOVAdzfwo.rqxHKOEGWKtbmbBOKWttHkTXqJdn = rqxHKOEGWKtbmbBOKWttHkTXqJdn;
					}
					return gqFHPBeIGNbppAMSxTnXOVAdzfwo;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class CqKVcMlYscivcGxUSbHRBeoiPGsk : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int aEKdNyLmYgMkWRTXgeSmbKfVuWcp;

				private Button RUrbKdgSkGcJKMFxceMWoVVZIqec;

				private int rEMYtNfSsJLzGpLhKiHmDNmRnIRF;

				public Platform_OSX_Base MPIEYFnzZCATLGOhWjRBubVEshxe;

				private int gkgzCvVhsCacOiUkUGDVbiBCbTSd;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return RUrbKdgSkGcJKMFxceMWoVVZIqec;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return RUrbKdgSkGcJKMFxceMWoVVZIqec;
					}
				}

				[DebuggerHidden]
				public CqKVcMlYscivcGxUSbHRBeoiPGsk(int P_0)
				{
					aEKdNyLmYgMkWRTXgeSmbKfVuWcp = P_0;
					rEMYtNfSsJLzGpLhKiHmDNmRnIRF = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					aEKdNyLmYgMkWRTXgeSmbKfVuWcp = -2;
				}

				private bool MoveNext()
				{
					int num = aEKdNyLmYgMkWRTXgeSmbKfVuWcp;
					Platform_OSX_Base mPIEYFnzZCATLGOhWjRBubVEshxe = MPIEYFnzZCATLGOhWjRBubVEshxe;
					switch (num)
					{
					default:
						return false;
					case 0:
						aEKdNyLmYgMkWRTXgeSmbKfVuWcp = -1;
						if (mPIEYFnzZCATLGOhWjRBubVEshxe.elements == null || mPIEYFnzZCATLGOhWjRBubVEshxe.elements.buttons == null)
						{
							return false;
						}
						gkgzCvVhsCacOiUkUGDVbiBCbTSd = 0;
						break;
					case 1:
						aEKdNyLmYgMkWRTXgeSmbKfVuWcp = -1;
						gkgzCvVhsCacOiUkUGDVbiBCbTSd++;
						break;
					}
					if (gkgzCvVhsCacOiUkUGDVbiBCbTSd < mPIEYFnzZCATLGOhWjRBubVEshxe.elements.buttons.Length)
					{
						RUrbKdgSkGcJKMFxceMWoVVZIqec = mPIEYFnzZCATLGOhWjRBubVEshxe.elements.buttons[gkgzCvVhsCacOiUkUGDVbiBCbTSd];
						aEKdNyLmYgMkWRTXgeSmbKfVuWcp = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					CqKVcMlYscivcGxUSbHRBeoiPGsk cqKVcMlYscivcGxUSbHRBeoiPGsk;
					if (aEKdNyLmYgMkWRTXgeSmbKfVuWcp == -2 && rEMYtNfSsJLzGpLhKiHmDNmRnIRF == Environment.CurrentManagedThreadId)
					{
						aEKdNyLmYgMkWRTXgeSmbKfVuWcp = 0;
						cqKVcMlYscivcGxUSbHRBeoiPGsk = this;
					}
					else
					{
						cqKVcMlYscivcGxUSbHRBeoiPGsk = new CqKVcMlYscivcGxUSbHRBeoiPGsk(0);
						cqKVcMlYscivcGxUSbHRBeoiPGsk.MPIEYFnzZCATLGOhWjRBubVEshxe = MPIEYFnzZCATLGOhWjRBubVEshxe;
					}
					return cqKVcMlYscivcGxUSbHRBeoiPGsk;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			InputPlatform Platform.platform => InputPlatform.OSXNative;

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(GqFHPBeIGNbppAMSxTnXOVAdzfwo))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new GqFHPBeIGNbppAMSxTnXOVAdzfwo(-2)
				{
					rqxHKOEGWKtbmbBOKWttHkTXqJdn = this
				};
			}

			[IteratorStateMachine(typeof(CqKVcMlYscivcGxUSbHRBeoiPGsk))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new CqKVcMlYscivcGxUSbHRBeoiPGsk(-2)
				{
					MPIEYFnzZCATLGOhWjRBubVEshxe = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_OSX_Base platform_OSX_Base = new Platform_OSX_Base();
				CopyVars(platform_OSX_Base);
				return platform_OSX_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (destination is Platform_OSX_Base platform_OSX_Base)
				{
					platform_OSX_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_OSX_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_OSX : Platform_OSX_Base
		{
			public Platform_OSX_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_OSX platform_OSX = new Platform_OSX();
				CopyVars(platform_OSX);
				return platform_OSX;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_OSX platform_OSX)
				{
					platform_OSX.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_Linux_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						ElementCount elementCount = new ElementCount();
						HXqFlTmkJgbaqWaoLySOLJbfONWh(elementCount);
						return elementCount;
					}

					internal void wLbPAWUJxRZuKtpLDcWYmkqWmcUo(ElementCount_Base P_0)
					{
						base.HXqFlTmkJgbaqWaoLySOLJbfONWh(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool kidwgFljiUobZOmicKkySkXfGAPJA(BridgedControllerHWInfo P_0)
					{
						if (!base.iJhYiAkXCqAZNrwRvcAgXrMBxdoL(P_0))
						{
							return false;
						}
						if (hatCount >= 0)
						{
							return hatCount == P_0.hardwareHatCount;
						}
						return true;
					}
				}

				public int hatCount;

				public ElementCount[] alternateElementCounts;

				public bool manufacturer_useRegex;

				public bool productName_useRegex;

				public bool systemName_useRegex;

				public string[] manufacturer;

				public string[] productName;

				public string[] systemName;

				public string[] productGUID;

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productGUID != null && productGUID.Length != 0)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				int MatchingCriteria_Base.alternateElementCount
				{
					get
					{
						if (alternateElementCounts == null)
						{
							return 0;
						}
						return alternateElementCounts.Length;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (strictMatch)
					{
						if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								return true;
							}
							if (productName == null || productName.Length == 0)
							{
								return true;
							}
						}
						if (!AnyNameMatches(bridgedControllerHWInfo))
						{
							return false;
						}
						return true;
					}
					return AnyNameMatches(bridgedControllerHWInfo);
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
					{
						return null;
					}
					return alternateElementCounts[index];
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (alternateMatched)
					{
						return true;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
				}

				private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					if (NameMatches(bridgedControllerHWInfo.hw_productName, productName, productName_useRegex))
					{
						return true;
					}
					if (NameMatches(bridgedControllerHWInfo.hw_systemDeviceName, systemName, systemName_useRegex))
					{
						return true;
					}
					return false;
				}

				private bool NameMatches(string name, string[] names, bool useRegex)
				{
					if (string.IsNullOrEmpty(name) || names == null)
					{
						return false;
					}
					string searchIn = name.Trim();
					for (int i = 0; i < names.Length; i++)
					{
						if (!string.IsNullOrEmpty(names[i]) && MatchingCriteria_Base.StringMatches(searchIn, names[i], useRegex))
						{
							return true;
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.alternateElementCounts = ArrayTools.ShallowCopy(alternateElementCounts);
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.systemName_useRegex = systemName_useRegex;
						matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.systemName = ArrayTools.ShallowCopy(systemName);
						matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class eItBJoJCPobABWgnkEwRjhAFJWxRA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int irjRpDqcJNEnRXnibieiIJBgkXiZ;

					private Axis ktlbNoguYEChekOiYabvBSkbcpArb;

					private int ONjgFsAnSuoZwUoKpkWfBARjbnrjc;

					public Elements lyoRbIYxBmUjBHnkANIkQOrWZcyH;

					private int DXaniDoDPfHcaJnHtyDksmnatKvtA;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return ktlbNoguYEChekOiYabvBSkbcpArb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ktlbNoguYEChekOiYabvBSkbcpArb;
						}
					}

					[DebuggerHidden]
					public eItBJoJCPobABWgnkEwRjhAFJWxRA(int P_0)
					{
						irjRpDqcJNEnRXnibieiIJBgkXiZ = P_0;
						ONjgFsAnSuoZwUoKpkWfBARjbnrjc = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						irjRpDqcJNEnRXnibieiIJBgkXiZ = -2;
					}

					private bool MoveNext()
					{
						int num = irjRpDqcJNEnRXnibieiIJBgkXiZ;
						Elements elements = lyoRbIYxBmUjBHnkANIkQOrWZcyH;
						switch (num)
						{
						default:
							return false;
						case 0:
							irjRpDqcJNEnRXnibieiIJBgkXiZ = -1;
							if (elements.axes == null)
							{
								return false;
							}
							DXaniDoDPfHcaJnHtyDksmnatKvtA = 0;
							break;
						case 1:
							irjRpDqcJNEnRXnibieiIJBgkXiZ = -1;
							DXaniDoDPfHcaJnHtyDksmnatKvtA++;
							break;
						}
						if (DXaniDoDPfHcaJnHtyDksmnatKvtA < elements.axes.Length)
						{
							ktlbNoguYEChekOiYabvBSkbcpArb = elements.axes[DXaniDoDPfHcaJnHtyDksmnatKvtA];
							irjRpDqcJNEnRXnibieiIJBgkXiZ = 1;
							return true;
						}
						return false;
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						eItBJoJCPobABWgnkEwRjhAFJWxRA eItBJoJCPobABWgnkEwRjhAFJWxRA2;
						if (irjRpDqcJNEnRXnibieiIJBgkXiZ == -2 && ONjgFsAnSuoZwUoKpkWfBARjbnrjc == Environment.CurrentManagedThreadId)
						{
							irjRpDqcJNEnRXnibieiIJBgkXiZ = 0;
							eItBJoJCPobABWgnkEwRjhAFJWxRA2 = this;
						}
						else
						{
							eItBJoJCPobABWgnkEwRjhAFJWxRA2 = new eItBJoJCPobABWgnkEwRjhAFJWxRA(0);
							eItBJoJCPobABWgnkEwRjhAFJWxRA2.lyoRbIYxBmUjBHnkANIkQOrWZcyH = lyoRbIYxBmUjBHnkANIkQOrWZcyH;
						}
						return eItBJoJCPobABWgnkEwRjhAFJWxRA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class RCWIdmMeEzDLEhifLcdbtEgQHUAhb : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int xdYyAAmfcQIzEkgwRhYvnQdXqUOj;

					private Button CqkvxXuqrSQhAjJKCLDzdIZBaChEA;

					private int mELDsVieLExYvHNDjIBgZtVRTiinA;

					public Elements GfAQiTfpJliXkXMXAZEgoisXiktx;

					private int ugrHzfMDaWfiFcPLbAebVkBDSwmgb;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return CqkvxXuqrSQhAjJKCLDzdIZBaChEA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return CqkvxXuqrSQhAjJKCLDzdIZBaChEA;
						}
					}

					[DebuggerHidden]
					public RCWIdmMeEzDLEhifLcdbtEgQHUAhb(int P_0)
					{
						xdYyAAmfcQIzEkgwRhYvnQdXqUOj = P_0;
						mELDsVieLExYvHNDjIBgZtVRTiinA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						xdYyAAmfcQIzEkgwRhYvnQdXqUOj = -2;
					}

					private bool MoveNext()
					{
						int num = xdYyAAmfcQIzEkgwRhYvnQdXqUOj;
						Elements gfAQiTfpJliXkXMXAZEgoisXiktx = GfAQiTfpJliXkXMXAZEgoisXiktx;
						switch (num)
						{
						default:
							return false;
						case 0:
							xdYyAAmfcQIzEkgwRhYvnQdXqUOj = -1;
							if (gfAQiTfpJliXkXMXAZEgoisXiktx.buttons == null)
							{
								return false;
							}
							ugrHzfMDaWfiFcPLbAebVkBDSwmgb = 0;
							break;
						case 1:
							xdYyAAmfcQIzEkgwRhYvnQdXqUOj = -1;
							ugrHzfMDaWfiFcPLbAebVkBDSwmgb++;
							break;
						}
						if (ugrHzfMDaWfiFcPLbAebVkBDSwmgb < gfAQiTfpJliXkXMXAZEgoisXiktx.buttons.Length)
						{
							CqkvxXuqrSQhAjJKCLDzdIZBaChEA = gfAQiTfpJliXkXMXAZEgoisXiktx.buttons[ugrHzfMDaWfiFcPLbAebVkBDSwmgb];
							xdYyAAmfcQIzEkgwRhYvnQdXqUOj = 1;
							return true;
						}
						return false;
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						RCWIdmMeEzDLEhifLcdbtEgQHUAhb rCWIdmMeEzDLEhifLcdbtEgQHUAhb;
						if (xdYyAAmfcQIzEkgwRhYvnQdXqUOj == -2 && mELDsVieLExYvHNDjIBgZtVRTiinA == Environment.CurrentManagedThreadId)
						{
							xdYyAAmfcQIzEkgwRhYvnQdXqUOj = 0;
							rCWIdmMeEzDLEhifLcdbtEgQHUAhb = this;
						}
						else
						{
							rCWIdmMeEzDLEhifLcdbtEgQHUAhb = new RCWIdmMeEzDLEhifLcdbtEgQHUAhb(0);
							rCWIdmMeEzDLEhifLcdbtEgQHUAhb.GfAQiTfpJliXkXMXAZEgoisXiktx = GfAQiTfpJliXkXMXAZEgoisXiktx;
						}
						return rCWIdmMeEzDLEhifLcdbtEgQHUAhb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal IEnumerable<Axis> Axes
				{
					[IteratorStateMachine(typeof(eItBJoJCPobABWgnkEwRjhAFJWxRA))]
					get
					{
						return new eItBJoJCPobABWgnkEwRjhAFJWxRA(-2)
						{
							lyoRbIYxBmUjBHnkANIkQOrWZcyH = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(RCWIdmMeEzDLEhifLcdbtEgQHUAhb))]
					get
					{
						return new RCWIdmMeEzDLEhifLcdbtEgQHUAhb(-2)
						{
							GfAQiTfpJliXkXMXAZEgoisXiktx = this
						};
					}
				}

				internal Axis GetAxis(int axisIndex)
				{
					if (axes == null || axisIndex < 0 || axisIndex >= axes.Length)
					{
						return null;
					}
					return axes[axisIndex];
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
						case HardwareElementSourceTypeWithHat.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public abstract object DeepClone();

				protected virtual void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class Button : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceButton;

				public int sourceAxis;

				public Pole sourceAxisPole;

				public float axisDeadZone;

				public int sourceHat;

				public HatType sourceHatType;

				public HatDirection sourceHatDirection;

				public bool requireMultipleButtons;

				public int[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public int[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				public Button()
				{
					sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				public override object DeepClone()
				{
					Button button = new Button();
					button.ImportVars(this);
					return button;
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					if (source is Button button)
					{
						elementIdentifier = button.elementIdentifier;
						sourceType = button.sourceType;
						sourceButton = button.sourceButton;
						sourceAxis = button.sourceAxis;
						sourceAxisPole = button.sourceAxisPole;
						axisDeadZone = button.axisDeadZone;
						sourceHat = button.sourceHat;
						sourceHatType = button.sourceHatType;
						sourceHatDirection = button.sourceHatDirection;
						requireMultipleButtons = button.requireMultipleButtons;
						requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
						ignoreIfButtonsActive = button.ignoreIfButtonsActive;
						ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
						buttonInfo = MiscTools.DeepClone(button.buttonInfo);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class Axis : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceAxis;

				public AxisRange sourceAxisRange;

				public bool invert;

				public float axisDeadZone;

				public float axisUpperDeadZone;

				public BoolWithDefault calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				public int sourceButton;

				public Pole buttonAxisContribution;

				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public AxisRange sourceHatRange;

				public Axis()
				{
					sourceType = HardwareElementSourceTypeWithHat.Axis;
				}

				public override object DeepClone()
				{
					Axis axis = new Axis();
					axis.ImportVars(this);
					return axis;
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					if (source is Axis axis)
					{
						elementIdentifier = axis.elementIdentifier;
						sourceType = axis.sourceType;
						sourceAxis = axis.sourceAxis;
						sourceAxisRange = axis.sourceAxisRange;
						invert = axis.invert;
						axisDeadZone = axis.axisDeadZone;
						axisUpperDeadZone = axis.axisUpperDeadZone;
						calibrateAxis = axis.calibrateAxis;
						axisZero = axis.axisZero;
						axisMin = axis.axisMin;
						axisMax = axis.axisMax;
						axisInfo = MiscTools.DeepClone(axis.axisInfo);
						sourceButton = axis.sourceButton;
						buttonAxisContribution = axis.buttonAxisContribution;
						sourceHat = axis.sourceHat;
						sourceHatDirection = axis.sourceHatDirection;
						sourceHatRange = axis.sourceHatRange;
						alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
					}
				}
			}

			private sealed class drVyQpqnHwmQZsVdFJKrAeTWnBLm : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int AFnHbaChpoabhOAHYLyAlXxDRcnfA;

				private Axis oeFHIOXnIKcQnfegVvjepwxwlrif;

				private int BGmzKHbZJAtsbidpdlTwOPAFdKMN;

				public Platform_Linux_Base OJYqfuceYdasFEssbAdMElZZnClsA;

				private int QnLbhVfJUMnOWiZWUNErNiNQuJxd;

				private int WnDxECSJKEqPqLOZtwAfwyYRccPr;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return oeFHIOXnIKcQnfegVvjepwxwlrif;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return oeFHIOXnIKcQnfegVvjepwxwlrif;
					}
				}

				[DebuggerHidden]
				public drVyQpqnHwmQZsVdFJKrAeTWnBLm(int P_0)
				{
					AFnHbaChpoabhOAHYLyAlXxDRcnfA = P_0;
					BGmzKHbZJAtsbidpdlTwOPAFdKMN = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					AFnHbaChpoabhOAHYLyAlXxDRcnfA = -2;
				}

				private bool MoveNext()
				{
					int aFnHbaChpoabhOAHYLyAlXxDRcnfA = AFnHbaChpoabhOAHYLyAlXxDRcnfA;
					Platform_Linux_Base oJYqfuceYdasFEssbAdMElZZnClsA = OJYqfuceYdasFEssbAdMElZZnClsA;
					switch (aFnHbaChpoabhOAHYLyAlXxDRcnfA)
					{
					default:
						return false;
					case 0:
						AFnHbaChpoabhOAHYLyAlXxDRcnfA = -1;
						if (oJYqfuceYdasFEssbAdMElZZnClsA.elements == null || oJYqfuceYdasFEssbAdMElZZnClsA.elements.axes == null)
						{
							return false;
						}
						QnLbhVfJUMnOWiZWUNErNiNQuJxd = oJYqfuceYdasFEssbAdMElZZnClsA.elements.axes.Length;
						WnDxECSJKEqPqLOZtwAfwyYRccPr = 0;
						break;
					case 1:
						AFnHbaChpoabhOAHYLyAlXxDRcnfA = -1;
						WnDxECSJKEqPqLOZtwAfwyYRccPr++;
						break;
					}
					if (WnDxECSJKEqPqLOZtwAfwyYRccPr < QnLbhVfJUMnOWiZWUNErNiNQuJxd)
					{
						oeFHIOXnIKcQnfegVvjepwxwlrif = oJYqfuceYdasFEssbAdMElZZnClsA.elements.axes[WnDxECSJKEqPqLOZtwAfwyYRccPr];
						AFnHbaChpoabhOAHYLyAlXxDRcnfA = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					drVyQpqnHwmQZsVdFJKrAeTWnBLm drVyQpqnHwmQZsVdFJKrAeTWnBLm2;
					if (AFnHbaChpoabhOAHYLyAlXxDRcnfA == -2 && BGmzKHbZJAtsbidpdlTwOPAFdKMN == Environment.CurrentManagedThreadId)
					{
						AFnHbaChpoabhOAHYLyAlXxDRcnfA = 0;
						drVyQpqnHwmQZsVdFJKrAeTWnBLm2 = this;
					}
					else
					{
						drVyQpqnHwmQZsVdFJKrAeTWnBLm2 = new drVyQpqnHwmQZsVdFJKrAeTWnBLm(0);
						drVyQpqnHwmQZsVdFJKrAeTWnBLm2.OJYqfuceYdasFEssbAdMElZZnClsA = OJYqfuceYdasFEssbAdMElZZnClsA;
					}
					return drVyQpqnHwmQZsVdFJKrAeTWnBLm2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class tWCdRvZvmmdomgXYNCZfmgLEtrARA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int RifwaTiAqYKTJNjgHdDoIoFoCqFo;

				private Button NevtFooczcobBHaOZWUWANzvAdYFA;

				private int UmJUPxQxOlWALWnfqOgVIkGioiCU;

				public Platform_Linux_Base jOBGmCiISCHaRJUYKLDUMsnjLvmfb;

				private int bYWifTiSHeJiHKjUAbJNbviiVKFm;

				private int wCVLmCmwaMWJLhpVIScXsfgwRgUi;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return NevtFooczcobBHaOZWUWANzvAdYFA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return NevtFooczcobBHaOZWUWANzvAdYFA;
					}
				}

				[DebuggerHidden]
				public tWCdRvZvmmdomgXYNCZfmgLEtrARA(int P_0)
				{
					RifwaTiAqYKTJNjgHdDoIoFoCqFo = P_0;
					UmJUPxQxOlWALWnfqOgVIkGioiCU = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					RifwaTiAqYKTJNjgHdDoIoFoCqFo = -2;
				}

				private bool MoveNext()
				{
					int rifwaTiAqYKTJNjgHdDoIoFoCqFo = RifwaTiAqYKTJNjgHdDoIoFoCqFo;
					Platform_Linux_Base platform_Linux_Base = jOBGmCiISCHaRJUYKLDUMsnjLvmfb;
					switch (rifwaTiAqYKTJNjgHdDoIoFoCqFo)
					{
					default:
						return false;
					case 0:
						RifwaTiAqYKTJNjgHdDoIoFoCqFo = -1;
						if (platform_Linux_Base.elements == null || platform_Linux_Base.elements.buttons == null)
						{
							return false;
						}
						bYWifTiSHeJiHKjUAbJNbviiVKFm = platform_Linux_Base.elements.buttons.Length;
						wCVLmCmwaMWJLhpVIScXsfgwRgUi = 0;
						break;
					case 1:
						RifwaTiAqYKTJNjgHdDoIoFoCqFo = -1;
						wCVLmCmwaMWJLhpVIScXsfgwRgUi++;
						break;
					}
					if (wCVLmCmwaMWJLhpVIScXsfgwRgUi < bYWifTiSHeJiHKjUAbJNbviiVKFm)
					{
						NevtFooczcobBHaOZWUWANzvAdYFA = platform_Linux_Base.elements.buttons[wCVLmCmwaMWJLhpVIScXsfgwRgUi];
						RifwaTiAqYKTJNjgHdDoIoFoCqFo = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					tWCdRvZvmmdomgXYNCZfmgLEtrARA tWCdRvZvmmdomgXYNCZfmgLEtrARA2;
					if (RifwaTiAqYKTJNjgHdDoIoFoCqFo == -2 && UmJUPxQxOlWALWnfqOgVIkGioiCU == Environment.CurrentManagedThreadId)
					{
						RifwaTiAqYKTJNjgHdDoIoFoCqFo = 0;
						tWCdRvZvmmdomgXYNCZfmgLEtrARA2 = this;
					}
					else
					{
						tWCdRvZvmmdomgXYNCZfmgLEtrARA2 = new tWCdRvZvmmdomgXYNCZfmgLEtrARA(0);
						tWCdRvZvmmdomgXYNCZfmgLEtrARA2.jOBGmCiISCHaRJUYKLDUMsnjLvmfb = jOBGmCiISCHaRJUYKLDUMsnjLvmfb;
					}
					return tWCdRvZvmmdomgXYNCZfmgLEtrARA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			InputPlatform Platform.platform => InputPlatform.LinuxNative;

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			[IteratorStateMachine(typeof(drVyQpqnHwmQZsVdFJKrAeTWnBLm))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new drVyQpqnHwmQZsVdFJKrAeTWnBLm(-2)
				{
					OJYqfuceYdasFEssbAdMElZZnClsA = this
				};
			}

			[IteratorStateMachine(typeof(tWCdRvZvmmdomgXYNCZfmgLEtrARA))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new tWCdRvZvmmdomgXYNCZfmgLEtrARA(-2)
				{
					jOBGmCiISCHaRJUYKLDUMsnjLvmfb = this
				};
			}

			public override object DeepClone()
			{
				Platform_Linux_Base platform_Linux_Base = new Platform_Linux_Base();
				CopyVars(platform_Linux_Base);
				return platform_Linux_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (destination is Platform_Linux_Base platform_Linux_Base)
				{
					platform_Linux_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Linux : Platform_Linux_Base
		{
			public Platform_Linux_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_Linux platform_Linux = new Platform_Linux();
				CopyVars(platform_Linux);
				return platform_Linux;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_Linux platform_Linux)
				{
					platform_Linux.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_WindowsUWP_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						ElementCount elementCount = new ElementCount();
						HXqFlTmkJgbaqWaoLySOLJbfONWh(elementCount);
						return elementCount;
					}

					internal void pLFfWzBJnATMgklDuDqJvWkDxTjL(ElementCount_Base P_0)
					{
						base.HXqFlTmkJgbaqWaoLySOLJbfONWh(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool eVPaxiMmIMcsLTqZngBiPnUUkOQL(BridgedControllerHWInfo P_0)
					{
						if (!base.iJhYiAkXCqAZNrwRvcAgXrMBxdoL(P_0))
						{
							return false;
						}
						if (hatCount >= 0)
						{
							return hatCount == P_0.hardwareHatCount;
						}
						return true;
					}
				}

				public int hatCount;

				public ElementCount[] alternateElementCounts;

				public bool manufacturer_useRegex;

				public bool productName_useRegex;

				public string[] manufacturer;

				public string[] productName;

				public string[] productGUID;

				public DeviceType deviceType;

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productGUID != null && productGUID.Length != 0)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				int MatchingCriteria_Base.alternateElementCount
				{
					get
					{
						if (alternateElementCounts == null)
						{
							return 0;
						}
						return alternateElementCounts.Length;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (deviceType != (DeviceType)bridgedControllerHWInfo.deviceType)
					{
						return false;
					}
					if (!HasProductName() && (productGUID == null || productGUID.Length == 0))
					{
						return true;
					}
					if (strictMatch)
					{
						if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								return true;
							}
							if (productName == null || productName.Length == 0)
							{
								return true;
							}
						}
						if (!AnyNameMatches(bridgedControllerHWInfo))
						{
							return false;
						}
						return true;
					}
					return AnyNameMatches(bridgedControllerHWInfo);
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
					{
						return null;
					}
					return alternateElementCounts[index];
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (alternateMatched)
					{
						return true;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
				}

				private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					if (NameMatches(bridgedControllerHWInfo.hw_productName, productName, productName_useRegex))
					{
						return true;
					}
					return false;
				}

				private bool NameMatches(string name, string[] names, bool useRegex)
				{
					if (string.IsNullOrEmpty(name) || names == null)
					{
						return false;
					}
					string searchIn = name.Trim();
					for (int i = 0; i < names.Length; i++)
					{
						if (!string.IsNullOrEmpty(names[i]) && MatchingCriteria_Base.StringMatches(searchIn, names[i], useRegex))
						{
							return true;
						}
					}
					return false;
				}

				private bool HasProductName()
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						if (!string.IsNullOrEmpty(productName[i]))
						{
							return true;
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.alternateElementCounts = ArrayTools.ShallowCopy(alternateElementCounts);
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
						matchingCriteria.deviceType = deviceType;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class lKSDPtKokKAqZoOusynhVFTecQeD : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int cJXrlgCBnjjRabYqdRRWWQGVDLvD;

					private Axis hsjEfxHjwSzfaWgoOkYlXAPVFqIqA;

					private int wHkftROwjKftgjdWpVYpfLJbITlG;

					public Elements mCQZbIGhkruYZMcVNHizFrQmAUsx;

					private int zPfWsZghlSTBwpqgHfVuSHGZNWdv;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return hsjEfxHjwSzfaWgoOkYlXAPVFqIqA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hsjEfxHjwSzfaWgoOkYlXAPVFqIqA;
						}
					}

					[DebuggerHidden]
					public lKSDPtKokKAqZoOusynhVFTecQeD(int P_0)
					{
						cJXrlgCBnjjRabYqdRRWWQGVDLvD = P_0;
						wHkftROwjKftgjdWpVYpfLJbITlG = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						cJXrlgCBnjjRabYqdRRWWQGVDLvD = -2;
					}

					private bool MoveNext()
					{
						int num = cJXrlgCBnjjRabYqdRRWWQGVDLvD;
						Elements elements = mCQZbIGhkruYZMcVNHizFrQmAUsx;
						switch (num)
						{
						default:
							return false;
						case 0:
							cJXrlgCBnjjRabYqdRRWWQGVDLvD = -1;
							if (elements.axes == null)
							{
								return false;
							}
							zPfWsZghlSTBwpqgHfVuSHGZNWdv = 0;
							break;
						case 1:
							cJXrlgCBnjjRabYqdRRWWQGVDLvD = -1;
							zPfWsZghlSTBwpqgHfVuSHGZNWdv++;
							break;
						}
						if (zPfWsZghlSTBwpqgHfVuSHGZNWdv < elements.axes.Length)
						{
							hsjEfxHjwSzfaWgoOkYlXAPVFqIqA = elements.axes[zPfWsZghlSTBwpqgHfVuSHGZNWdv];
							cJXrlgCBnjjRabYqdRRWWQGVDLvD = 1;
							return true;
						}
						return false;
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						lKSDPtKokKAqZoOusynhVFTecQeD lKSDPtKokKAqZoOusynhVFTecQeD2;
						if (cJXrlgCBnjjRabYqdRRWWQGVDLvD == -2 && wHkftROwjKftgjdWpVYpfLJbITlG == Environment.CurrentManagedThreadId)
						{
							cJXrlgCBnjjRabYqdRRWWQGVDLvD = 0;
							lKSDPtKokKAqZoOusynhVFTecQeD2 = this;
						}
						else
						{
							lKSDPtKokKAqZoOusynhVFTecQeD2 = new lKSDPtKokKAqZoOusynhVFTecQeD(0);
							lKSDPtKokKAqZoOusynhVFTecQeD2.mCQZbIGhkruYZMcVNHizFrQmAUsx = mCQZbIGhkruYZMcVNHizFrQmAUsx;
						}
						return lKSDPtKokKAqZoOusynhVFTecQeD2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class QoJqasiSigBcpJNIuWUleVrEALEK : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int XAOBsDWYbqljRiDPlFBVZtOsTAfE;

					private Button JvDibStjGmRETcvEogoOnFdtaciC;

					private int rYGTtPrqmRdWhYrsICMpCqzkgmll;

					public Elements gJGaDhjybeFbEhgAIUzPQgfgEeEAA;

					private int yRHlEYxodxSIChoJioDskbpZbTZbA;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return JvDibStjGmRETcvEogoOnFdtaciC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return JvDibStjGmRETcvEogoOnFdtaciC;
						}
					}

					[DebuggerHidden]
					public QoJqasiSigBcpJNIuWUleVrEALEK(int P_0)
					{
						XAOBsDWYbqljRiDPlFBVZtOsTAfE = P_0;
						rYGTtPrqmRdWhYrsICMpCqzkgmll = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						XAOBsDWYbqljRiDPlFBVZtOsTAfE = -2;
					}

					private bool MoveNext()
					{
						int xAOBsDWYbqljRiDPlFBVZtOsTAfE = XAOBsDWYbqljRiDPlFBVZtOsTAfE;
						Elements elements = gJGaDhjybeFbEhgAIUzPQgfgEeEAA;
						switch (xAOBsDWYbqljRiDPlFBVZtOsTAfE)
						{
						default:
							return false;
						case 0:
							XAOBsDWYbqljRiDPlFBVZtOsTAfE = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							yRHlEYxodxSIChoJioDskbpZbTZbA = 0;
							break;
						case 1:
							XAOBsDWYbqljRiDPlFBVZtOsTAfE = -1;
							yRHlEYxodxSIChoJioDskbpZbTZbA++;
							break;
						}
						if (yRHlEYxodxSIChoJioDskbpZbTZbA < elements.buttons.Length)
						{
							JvDibStjGmRETcvEogoOnFdtaciC = elements.buttons[yRHlEYxodxSIChoJioDskbpZbTZbA];
							XAOBsDWYbqljRiDPlFBVZtOsTAfE = 1;
							return true;
						}
						return false;
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						QoJqasiSigBcpJNIuWUleVrEALEK qoJqasiSigBcpJNIuWUleVrEALEK;
						if (XAOBsDWYbqljRiDPlFBVZtOsTAfE == -2 && rYGTtPrqmRdWhYrsICMpCqzkgmll == Environment.CurrentManagedThreadId)
						{
							XAOBsDWYbqljRiDPlFBVZtOsTAfE = 0;
							qoJqasiSigBcpJNIuWUleVrEALEK = this;
						}
						else
						{
							qoJqasiSigBcpJNIuWUleVrEALEK = new QoJqasiSigBcpJNIuWUleVrEALEK(0);
							qoJqasiSigBcpJNIuWUleVrEALEK.gJGaDhjybeFbEhgAIUzPQgfgEeEAA = gJGaDhjybeFbEhgAIUzPQgfgEeEAA;
						}
						return qoJqasiSigBcpJNIuWUleVrEALEK;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal IEnumerable<Axis> Axes
				{
					[IteratorStateMachine(typeof(lKSDPtKokKAqZoOusynhVFTecQeD))]
					get
					{
						return new lKSDPtKokKAqZoOusynhVFTecQeD(-2)
						{
							mCQZbIGhkruYZMcVNHizFrQmAUsx = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(QoJqasiSigBcpJNIuWUleVrEALEK))]
					get
					{
						return new QoJqasiSigBcpJNIuWUleVrEALEK(-2)
						{
							gJGaDhjybeFbEhgAIUzPQgfgEeEAA = this
						};
					}
				}

				internal Axis GetAxis(int axisIndex)
				{
					if (axes == null || axisIndex < 0 || axisIndex >= axes.Length)
					{
						return null;
					}
					return axes[axisIndex];
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
						case HardwareElementSourceTypeWithHat.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public abstract object DeepClone();

				protected virtual void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class Button : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceButton;

				public int sourceAxis;

				public Pole sourceAxisPole;

				public float axisDeadZone;

				public int sourceHat;

				public HatType sourceHatType;

				public HatDirection sourceHatDirection;

				public bool requireMultipleButtons;

				public int[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public int[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				public Button()
				{
					sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				public override object DeepClone()
				{
					Button button = new Button();
					button.ImportVars(this);
					return button;
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					if (source is Button button)
					{
						elementIdentifier = button.elementIdentifier;
						sourceType = button.sourceType;
						sourceButton = button.sourceButton;
						sourceAxis = button.sourceAxis;
						sourceAxisPole = button.sourceAxisPole;
						axisDeadZone = button.axisDeadZone;
						sourceHat = button.sourceHat;
						sourceHatType = button.sourceHatType;
						sourceHatDirection = button.sourceHatDirection;
						requireMultipleButtons = button.requireMultipleButtons;
						requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
						ignoreIfButtonsActive = button.ignoreIfButtonsActive;
						ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
						buttonInfo = MiscTools.DeepClone(button.buttonInfo);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class Axis : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceAxis;

				public AxisRange sourceAxisRange;

				public bool invert;

				public float axisDeadZone;

				public float axisUpperDeadZone;

				public BoolWithDefault calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				public int sourceButton;

				public Pole buttonAxisContribution;

				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public AxisRange sourceHatRange;

				public Axis()
				{
					sourceType = HardwareElementSourceTypeWithHat.Axis;
				}

				public override object DeepClone()
				{
					Axis axis = new Axis();
					axis.ImportVars(this);
					return axis;
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					if (source is Axis axis)
					{
						elementIdentifier = axis.elementIdentifier;
						sourceType = axis.sourceType;
						sourceAxis = axis.sourceAxis;
						sourceAxisRange = axis.sourceAxisRange;
						invert = axis.invert;
						axisDeadZone = axis.axisDeadZone;
						axisUpperDeadZone = axis.axisUpperDeadZone;
						calibrateAxis = axis.calibrateAxis;
						axisZero = axis.axisZero;
						axisMin = axis.axisMin;
						axisMax = axis.axisMax;
						axisInfo = MiscTools.DeepClone(axis.axisInfo);
						sourceButton = axis.sourceButton;
						buttonAxisContribution = axis.buttonAxisContribution;
						sourceHat = axis.sourceHat;
						sourceHatDirection = axis.sourceHatDirection;
						sourceHatRange = axis.sourceHatRange;
						alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
					}
				}
			}

			public enum DeviceType
			{
				HIDJoystick = 0,
				WGIGamepad = 1
			}

			private sealed class vOeSmlhSBUkazGSPEYcHfLukHdtl : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int mKLnmzPkPawbbBAmSHrIPXlzDyLdA;

				private Axis HDOPEqioEvhJCuSbnwBUrXOMSkgC;

				private int JjHHYZZrePkYXqFOLYAhQQSHmUNC;

				public Platform_WindowsUWP_Base PhZcEaIObjJsSQUDjkhzQQeTPnbYA;

				private int gxxCaYEMkyJylNbXyVEctajJjORIA;

				private int lHxbSHqhQLiGbcuDifpvQohheUzE;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return HDOPEqioEvhJCuSbnwBUrXOMSkgC;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return HDOPEqioEvhJCuSbnwBUrXOMSkgC;
					}
				}

				[DebuggerHidden]
				public vOeSmlhSBUkazGSPEYcHfLukHdtl(int P_0)
				{
					mKLnmzPkPawbbBAmSHrIPXlzDyLdA = P_0;
					JjHHYZZrePkYXqFOLYAhQQSHmUNC = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					mKLnmzPkPawbbBAmSHrIPXlzDyLdA = -2;
				}

				private bool MoveNext()
				{
					int num = mKLnmzPkPawbbBAmSHrIPXlzDyLdA;
					Platform_WindowsUWP_Base phZcEaIObjJsSQUDjkhzQQeTPnbYA = PhZcEaIObjJsSQUDjkhzQQeTPnbYA;
					switch (num)
					{
					default:
						return false;
					case 0:
						mKLnmzPkPawbbBAmSHrIPXlzDyLdA = -1;
						if (phZcEaIObjJsSQUDjkhzQQeTPnbYA.elements == null || phZcEaIObjJsSQUDjkhzQQeTPnbYA.elements.axes == null)
						{
							return false;
						}
						gxxCaYEMkyJylNbXyVEctajJjORIA = phZcEaIObjJsSQUDjkhzQQeTPnbYA.elements.axes.Length;
						lHxbSHqhQLiGbcuDifpvQohheUzE = 0;
						break;
					case 1:
						mKLnmzPkPawbbBAmSHrIPXlzDyLdA = -1;
						lHxbSHqhQLiGbcuDifpvQohheUzE++;
						break;
					}
					if (lHxbSHqhQLiGbcuDifpvQohheUzE < gxxCaYEMkyJylNbXyVEctajJjORIA)
					{
						HDOPEqioEvhJCuSbnwBUrXOMSkgC = phZcEaIObjJsSQUDjkhzQQeTPnbYA.elements.axes[lHxbSHqhQLiGbcuDifpvQohheUzE];
						mKLnmzPkPawbbBAmSHrIPXlzDyLdA = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					vOeSmlhSBUkazGSPEYcHfLukHdtl vOeSmlhSBUkazGSPEYcHfLukHdtl2;
					if (mKLnmzPkPawbbBAmSHrIPXlzDyLdA == -2 && JjHHYZZrePkYXqFOLYAhQQSHmUNC == Environment.CurrentManagedThreadId)
					{
						mKLnmzPkPawbbBAmSHrIPXlzDyLdA = 0;
						vOeSmlhSBUkazGSPEYcHfLukHdtl2 = this;
					}
					else
					{
						vOeSmlhSBUkazGSPEYcHfLukHdtl2 = new vOeSmlhSBUkazGSPEYcHfLukHdtl(0);
						vOeSmlhSBUkazGSPEYcHfLukHdtl2.PhZcEaIObjJsSQUDjkhzQQeTPnbYA = PhZcEaIObjJsSQUDjkhzQQeTPnbYA;
					}
					return vOeSmlhSBUkazGSPEYcHfLukHdtl2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class vyLzjHTwegVJqKYsMtbgTuNeGlwx : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int TGTSeMlGxjltJRMuAdOyJeIzEqkBb;

				private Button ziFrpFhgQgfnlTXcIfgPKYrpqllc;

				private int lZLSCYuiymiNKFwnBxoqvctrGtdF;

				public Platform_WindowsUWP_Base CBvROdfFODjPlqAPzfYwaTctNykAA;

				private int LiscBmfBFargnibggMwGkhVCKgmx;

				private int jKHULuyGBpDiSCpUHBSFIxQcDQrDA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ziFrpFhgQgfnlTXcIfgPKYrpqllc;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ziFrpFhgQgfnlTXcIfgPKYrpqllc;
					}
				}

				[DebuggerHidden]
				public vyLzjHTwegVJqKYsMtbgTuNeGlwx(int P_0)
				{
					TGTSeMlGxjltJRMuAdOyJeIzEqkBb = P_0;
					lZLSCYuiymiNKFwnBxoqvctrGtdF = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					TGTSeMlGxjltJRMuAdOyJeIzEqkBb = -2;
				}

				private bool MoveNext()
				{
					int tGTSeMlGxjltJRMuAdOyJeIzEqkBb = TGTSeMlGxjltJRMuAdOyJeIzEqkBb;
					Platform_WindowsUWP_Base cBvROdfFODjPlqAPzfYwaTctNykAA = CBvROdfFODjPlqAPzfYwaTctNykAA;
					switch (tGTSeMlGxjltJRMuAdOyJeIzEqkBb)
					{
					default:
						return false;
					case 0:
						TGTSeMlGxjltJRMuAdOyJeIzEqkBb = -1;
						if (cBvROdfFODjPlqAPzfYwaTctNykAA.elements == null || cBvROdfFODjPlqAPzfYwaTctNykAA.elements.buttons == null)
						{
							return false;
						}
						LiscBmfBFargnibggMwGkhVCKgmx = cBvROdfFODjPlqAPzfYwaTctNykAA.elements.buttons.Length;
						jKHULuyGBpDiSCpUHBSFIxQcDQrDA = 0;
						break;
					case 1:
						TGTSeMlGxjltJRMuAdOyJeIzEqkBb = -1;
						jKHULuyGBpDiSCpUHBSFIxQcDQrDA++;
						break;
					}
					if (jKHULuyGBpDiSCpUHBSFIxQcDQrDA < LiscBmfBFargnibggMwGkhVCKgmx)
					{
						ziFrpFhgQgfnlTXcIfgPKYrpqllc = cBvROdfFODjPlqAPzfYwaTctNykAA.elements.buttons[jKHULuyGBpDiSCpUHBSFIxQcDQrDA];
						TGTSeMlGxjltJRMuAdOyJeIzEqkBb = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					vyLzjHTwegVJqKYsMtbgTuNeGlwx vyLzjHTwegVJqKYsMtbgTuNeGlwx2;
					if (TGTSeMlGxjltJRMuAdOyJeIzEqkBb == -2 && lZLSCYuiymiNKFwnBxoqvctrGtdF == Environment.CurrentManagedThreadId)
					{
						TGTSeMlGxjltJRMuAdOyJeIzEqkBb = 0;
						vyLzjHTwegVJqKYsMtbgTuNeGlwx2 = this;
					}
					else
					{
						vyLzjHTwegVJqKYsMtbgTuNeGlwx2 = new vyLzjHTwegVJqKYsMtbgTuNeGlwx(0);
						vyLzjHTwegVJqKYsMtbgTuNeGlwx2.CBvROdfFODjPlqAPzfYwaTctNykAA = CBvROdfFODjPlqAPzfYwaTctNykAA;
					}
					return vyLzjHTwegVJqKYsMtbgTuNeGlwx2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			InputPlatform Platform.platform => InputPlatform.WindowsUWP;

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			[IteratorStateMachine(typeof(vOeSmlhSBUkazGSPEYcHfLukHdtl))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new vOeSmlhSBUkazGSPEYcHfLukHdtl(-2)
				{
					PhZcEaIObjJsSQUDjkhzQQeTPnbYA = this
				};
			}

			[IteratorStateMachine(typeof(vyLzjHTwegVJqKYsMtbgTuNeGlwx))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new vyLzjHTwegVJqKYsMtbgTuNeGlwx(-2)
				{
					CBvROdfFODjPlqAPzfYwaTctNykAA = this
				};
			}

			public override object DeepClone()
			{
				Platform_WindowsUWP_Base platform_WindowsUWP_Base = new Platform_WindowsUWP_Base();
				CopyVars(platform_WindowsUWP_Base);
				return platform_WindowsUWP_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (destination is Platform_WindowsUWP_Base platform_WindowsUWP_Base)
				{
					platform_WindowsUWP_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_WindowsUWP : Platform_WindowsUWP_Base
		{
			public Platform_WindowsUWP_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_WindowsUWP platform_WindowsUWP = new Platform_WindowsUWP();
				CopyVars(platform_WindowsUWP);
				return platform_WindowsUWP;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_WindowsUWP platform_WindowsUWP)
				{
					platform_WindowsUWP.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_Fallback_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				public bool alwaysMatch;

				public bool productName_useRegex;

				public string[] productName;

				public bool matchUnityVersion;

				public string matchUnityVersion_min;

				public string matchUnityVersion_max;

				public bool matchSysVersion;

				public string matchSysVersion_min;

				public string matchSysVersion_max;

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (alwaysMatch)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						if (matchUnityVersion && !UnityTools.IsUnityVersionInRange(matchUnityVersion_min, matchUnityVersion_max))
						{
							return false;
						}
						if (matchSysVersion && !PlatformTools.IsSysVersionInRange(matchSysVersion_min, matchSysVersion_max))
						{
							return false;
						}
						return true;
					}
				}

				int MatchingCriteria_Base.alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!isAllowed)
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (productName != null)
					{
						for (int i = 0; i < productName.Length; i++)
						{
							string searchFor = productName[i];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
						}
					}
					return false;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.alwaysMatch = alwaysMatch;
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.matchUnityVersion = matchUnityVersion;
						matchingCriteria.matchUnityVersion_min = matchUnityVersion_min;
						matchingCriteria.matchUnityVersion_max = matchUnityVersion_max;
						matchingCriteria.matchSysVersion = matchSysVersion;
						matchingCriteria.matchSysVersion_min = matchSysVersion_min;
						matchingCriteria.matchSysVersion_max = matchSysVersion_max;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
						case HardwareElementSourceTypeWithHat.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class CustomCalculationSourceData : IDeepCloneable
			{
				public int sourceType;

				public int sourceElement;

				public AxisRange sourceAxisRange;

				public float deadzone;

				public bool invert;

				public object DeepClone()
				{
					return new CustomCalculationSourceData
					{
						sourceType = sourceType,
						sourceElement = sourceElement,
						sourceAxisRange = sourceAxisRange,
						deadzone = deadzone,
						invert = invert
					};
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public UnityAxis sourceAxis;

				public float axisDeadZone;

				public UnityButton sourceButton;

				public KeyboardKeyCode sourceKeyCode;

				public CustomCalculation customCalculation;

				public CustomCalculationSourceData[] customCalculationSourceData;

				public abstract object DeepClone();

				internal virtual void CopyVars(Element destination)
				{
					if (destination != null)
					{
						destination.elementIdentifier = elementIdentifier;
						destination.sourceType = sourceType;
						destination.sourceAxis = sourceAxis;
						destination.axisDeadZone = axisDeadZone;
						destination.sourceButton = sourceButton;
						destination.sourceKeyCode = sourceKeyCode;
						destination.customCalculation = customCalculation;
						destination.customCalculationSourceData = ArrayTools.DeepClone(customCalculationSourceData);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Button : Element
			{
				public Pole sourceAxisPole;

				public UnityAxis unityHat_sourceAxis1;

				public UnityAxis unityHat_sourceAxis2;

				public Vector2 unityHat_isActiveAxisValues1;

				public Vector2 unityHat_isActiveAxisValues2;

				public Vector2 unityHat_isActiveAxisValues3;

				public Vector2 unityHat_zeroValues;

				public bool unityHat_checkNeverPressed;

				public Vector2 unityHat_neverPressedZeroValues;

				public bool requireMultipleButtons;

				public UnityButton[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public UnityButton[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Button button)
					{
						button.sourceAxisPole = sourceAxisPole;
						button.unityHat_sourceAxis1 = unityHat_sourceAxis1;
						button.unityHat_sourceAxis2 = unityHat_sourceAxis2;
						button.unityHat_isActiveAxisValues1 = unityHat_isActiveAxisValues1;
						button.unityHat_isActiveAxisValues2 = unityHat_isActiveAxisValues2;
						button.unityHat_isActiveAxisValues3 = unityHat_isActiveAxisValues3;
						button.unityHat_zeroValues = unityHat_zeroValues;
						button.unityHat_checkNeverPressed = unityHat_checkNeverPressed;
						button.unityHat_neverPressedZeroValues = unityHat_neverPressedZeroValues;
						button.requireMultipleButtons = requireMultipleButtons;
						button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
						button.ignoreIfButtonsActive = ignoreIfButtonsActive;
						button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
						button.buttonInfo = MiscTools.DeepClone(buttonInfo);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Axis : Element
			{
				public bool invert;

				public AxisRange sourceAxisRange;

				public Pole buttonAxisContribution;

				public float axisUpperDeadZone;

				public BoolWithDefault calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Axis axis)
					{
						axis.invert = invert;
						axis.sourceAxisRange = sourceAxisRange;
						axis.buttonAxisContribution = buttonAxisContribution;
						axis.axisUpperDeadZone = axisUpperDeadZone;
						axis.calibrateAxis = calibrateAxis;
						axis.axisZero = axisZero;
						axis.axisMin = axisMin;
						axis.axisMax = axisMax;
						axis.axisInfo = MiscTools.DeepClone(axisInfo);
						axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
					}
				}
			}

			private sealed class aeEhyXRFNuAzyhrMuvPivAYoMyPe : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int OBvwVCvuasxOgzXJYdoFcFcUVNVc;

				private Axis MAWKrqNqduOgNMEfCMbCEyQPactk;

				private int IzmWsXPjQeHFnmXzpuvbfJPbsWpq;

				public Platform_Fallback_Base VLINxXoqdSvOBFgFIpucSzNiwJwe;

				private int gmlZuhHmGlfiHJeWKNUwiMMkzmcw;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return MAWKrqNqduOgNMEfCMbCEyQPactk;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return MAWKrqNqduOgNMEfCMbCEyQPactk;
					}
				}

				[DebuggerHidden]
				public aeEhyXRFNuAzyhrMuvPivAYoMyPe(int P_0)
				{
					OBvwVCvuasxOgzXJYdoFcFcUVNVc = P_0;
					IzmWsXPjQeHFnmXzpuvbfJPbsWpq = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					OBvwVCvuasxOgzXJYdoFcFcUVNVc = -2;
				}

				private bool MoveNext()
				{
					int oBvwVCvuasxOgzXJYdoFcFcUVNVc = OBvwVCvuasxOgzXJYdoFcFcUVNVc;
					Platform_Fallback_Base vLINxXoqdSvOBFgFIpucSzNiwJwe = VLINxXoqdSvOBFgFIpucSzNiwJwe;
					switch (oBvwVCvuasxOgzXJYdoFcFcUVNVc)
					{
					default:
						return false;
					case 0:
						OBvwVCvuasxOgzXJYdoFcFcUVNVc = -1;
						if (vLINxXoqdSvOBFgFIpucSzNiwJwe.elements == null || vLINxXoqdSvOBFgFIpucSzNiwJwe.elements.axes == null)
						{
							return false;
						}
						gmlZuhHmGlfiHJeWKNUwiMMkzmcw = 0;
						break;
					case 1:
						OBvwVCvuasxOgzXJYdoFcFcUVNVc = -1;
						gmlZuhHmGlfiHJeWKNUwiMMkzmcw++;
						break;
					}
					if (gmlZuhHmGlfiHJeWKNUwiMMkzmcw < vLINxXoqdSvOBFgFIpucSzNiwJwe.elements.axes.Length)
					{
						MAWKrqNqduOgNMEfCMbCEyQPactk = vLINxXoqdSvOBFgFIpucSzNiwJwe.elements.axes[gmlZuhHmGlfiHJeWKNUwiMMkzmcw];
						OBvwVCvuasxOgzXJYdoFcFcUVNVc = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					aeEhyXRFNuAzyhrMuvPivAYoMyPe aeEhyXRFNuAzyhrMuvPivAYoMyPe2;
					if (OBvwVCvuasxOgzXJYdoFcFcUVNVc == -2 && IzmWsXPjQeHFnmXzpuvbfJPbsWpq == Environment.CurrentManagedThreadId)
					{
						OBvwVCvuasxOgzXJYdoFcFcUVNVc = 0;
						aeEhyXRFNuAzyhrMuvPivAYoMyPe2 = this;
					}
					else
					{
						aeEhyXRFNuAzyhrMuvPivAYoMyPe2 = new aeEhyXRFNuAzyhrMuvPivAYoMyPe(0);
						aeEhyXRFNuAzyhrMuvPivAYoMyPe2.VLINxXoqdSvOBFgFIpucSzNiwJwe = VLINxXoqdSvOBFgFIpucSzNiwJwe;
					}
					return aeEhyXRFNuAzyhrMuvPivAYoMyPe2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class CLYknpvcMehAdEZJVMqgyyyKiTQF : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int KdPpGagZNdraLZSgFviwkcmGLRYL;

				private Button JUTCLWdcfCsfrwQATpuEmrjjLWwhA;

				private int wmWNKYuzPgtsgraemFouvLzLjiyS;

				public Platform_Fallback_Base sKCJjjEEcHchcCQxpeSFJyvLdmUn;

				private int ZLqNvYpfdEdyrBLBMhnvNoFVppDGA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return JUTCLWdcfCsfrwQATpuEmrjjLWwhA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return JUTCLWdcfCsfrwQATpuEmrjjLWwhA;
					}
				}

				[DebuggerHidden]
				public CLYknpvcMehAdEZJVMqgyyyKiTQF(int P_0)
				{
					KdPpGagZNdraLZSgFviwkcmGLRYL = P_0;
					wmWNKYuzPgtsgraemFouvLzLjiyS = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					KdPpGagZNdraLZSgFviwkcmGLRYL = -2;
				}

				private bool MoveNext()
				{
					int kdPpGagZNdraLZSgFviwkcmGLRYL = KdPpGagZNdraLZSgFviwkcmGLRYL;
					Platform_Fallback_Base platform_Fallback_Base = sKCJjjEEcHchcCQxpeSFJyvLdmUn;
					switch (kdPpGagZNdraLZSgFviwkcmGLRYL)
					{
					default:
						return false;
					case 0:
						KdPpGagZNdraLZSgFviwkcmGLRYL = -1;
						if (platform_Fallback_Base.elements == null || platform_Fallback_Base.elements.buttons == null)
						{
							return false;
						}
						ZLqNvYpfdEdyrBLBMhnvNoFVppDGA = 0;
						break;
					case 1:
						KdPpGagZNdraLZSgFviwkcmGLRYL = -1;
						ZLqNvYpfdEdyrBLBMhnvNoFVppDGA++;
						break;
					}
					if (ZLqNvYpfdEdyrBLBMhnvNoFVppDGA < platform_Fallback_Base.elements.buttons.Length)
					{
						JUTCLWdcfCsfrwQATpuEmrjjLWwhA = platform_Fallback_Base.elements.buttons[ZLqNvYpfdEdyrBLBMhnvNoFVppDGA];
						KdPpGagZNdraLZSgFviwkcmGLRYL = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					CLYknpvcMehAdEZJVMqgyyyKiTQF cLYknpvcMehAdEZJVMqgyyyKiTQF;
					if (KdPpGagZNdraLZSgFviwkcmGLRYL == -2 && wmWNKYuzPgtsgraemFouvLzLjiyS == Environment.CurrentManagedThreadId)
					{
						KdPpGagZNdraLZSgFviwkcmGLRYL = 0;
						cLYknpvcMehAdEZJVMqgyyyKiTQF = this;
					}
					else
					{
						cLYknpvcMehAdEZJVMqgyyyKiTQF = new CLYknpvcMehAdEZJVMqgyyyKiTQF(0);
						cLYknpvcMehAdEZJVMqgyyyKiTQF.sKCJjjEEcHchcCQxpeSFJyvLdmUn = sKCJjjEEcHchcCQxpeSFJyvLdmUn;
					}
					return cLYknpvcMehAdEZJVMqgyyyKiTQF;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			InputPlatform Platform.platform => InputPlatform.Fallback;

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(aeEhyXRFNuAzyhrMuvPivAYoMyPe))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new aeEhyXRFNuAzyhrMuvPivAYoMyPe(-2)
				{
					VLINxXoqdSvOBFgFIpucSzNiwJwe = this
				};
			}

			[IteratorStateMachine(typeof(CLYknpvcMehAdEZJVMqgyyyKiTQF))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new CLYknpvcMehAdEZJVMqgyyyKiTQF(-2)
				{
					sKCJjjEEcHchcCQxpeSFJyvLdmUn = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_Fallback_Base platform_Fallback_Base = new Platform_Fallback_Base();
				CopyVars(platform_Fallback_Base);
				return platform_Fallback_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (destination is Platform_Fallback_Base platform_Fallback_Base)
				{
					platform_Fallback_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_Fallback_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Fallback : Platform_Fallback_Base
		{
			public Platform_Fallback_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_Fallback platform_Fallback = new Platform_Fallback();
				CopyVars(platform_Fallback);
				return platform_Fallback;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_Fallback platform_Fallback)
				{
					platform_Fallback.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Platform_Custom : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class MatchingCriteria : MatchingCriteria_Base
			{
				[Tooltip("If enabled, this will match to every controller regardless of other matching criteria.")]
				public bool alwaysMatch;

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (alwaysMatch)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				int MatchingCriteria_Base.alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (disabled)
					{
						return false;
					}
					if (!isAllowed)
					{
						return false;
					}
					_ = alwaysMatch;
					return true;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.alwaysMatch = alwaysMatch;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Elements : Elements_Base
			{
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class CustomCalculationSourceData : IDeepCloneable
			{
				public int sourceType;

				public int sourceAxis;

				public int sourceButton;

				public int sourceOtherAxis;

				public AxisRange sourceAxisRange;

				public float axisDeadZone;

				public float axisUpperDeadZone;

				public bool invert;

				public AxisCalibrationType axisCalibrationType;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public virtual object DeepClone()
				{
					return new CustomCalculationSourceData
					{
						sourceType = sourceType,
						sourceAxis = sourceAxis,
						sourceButton = sourceButton,
						sourceOtherAxis = sourceOtherAxis,
						sourceAxisRange = sourceAxisRange,
						axisDeadZone = axisDeadZone,
						axisUpperDeadZone = axisUpperDeadZone,
						invert = invert,
						axisCalibrationType = axisCalibrationType,
						axisZero = axisZero,
						axisMin = axisMin,
						axisMax = axisMax
					};
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public int elementIdentifier;

				public int sourceType;

				public int sourceAxis;

				public float axisDeadZone;

				public int sourceButton;

				public CustomCalculation customCalculation;

				public CustomCalculationSourceData[] customCalculationSourceData;

				internal virtual void CopyVars(Element destination)
				{
					destination.elementIdentifier = elementIdentifier;
					destination.sourceType = sourceType;
					destination.sourceAxis = sourceAxis;
					destination.axisDeadZone = axisDeadZone;
					destination.sourceButton = sourceButton;
					destination.customCalculation = customCalculation;
					destination.customCalculationSourceData = ArrayTools.DeepClone(customCalculationSourceData);
				}

				public abstract object DeepClone();
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Button : Element
			{
				public Pole sourceAxisPole;

				public bool requireMultipleButtons;

				public int[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public int[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Button button)
					{
						button.sourceAxisPole = sourceAxisPole;
						button.requireMultipleButtons = requireMultipleButtons;
						button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
						button.ignoreIfButtonsActive = ignoreIfButtonsActive;
						button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
						button.buttonInfo = MiscTools.DeepClone(buttonInfo);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Axis : Element
			{
				public bool invert;

				public AxisRange sourceAxisRange;

				public Pole buttonAxisContribution;

				public float axisUpperDeadZone;

				public BoolWithDefault calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Axis axis)
					{
						axis.invert = invert;
						axis.sourceAxisRange = sourceAxisRange;
						axis.buttonAxisContribution = buttonAxisContribution;
						axis.axisUpperDeadZone = axisUpperDeadZone;
						axis.calibrateAxis = calibrateAxis;
						axis.axisZero = axisZero;
						axis.axisMin = axisMin;
						axis.axisMax = axisMax;
						axis.axisInfo = MiscTools.DeepClone(axisInfo);
						axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
					}
				}
			}

			internal abstract Axis[] Axes { get; }

			internal abstract Button[] Buttons { get; }

			internal abstract IEnumerable<Axis> IterateAxes();

			internal abstract IEnumerable<Button> IterateButtons();

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_XboxOne_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (productName != null)
					{
						for (int i = 0; i < productName.Length; i++)
						{
							string searchFor = productName[i];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Button;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Axis;
				}
			}

			private sealed class nkTYSRKyAPbRNKeVNBZdxgiLqIeA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int NVgLyDNyFHAaOaJFcwCreXgqDEXH;

				private Platform_Custom.Axis VkrgMMebWZryqMylGAoextYMMFkL;

				private int MSGWZMhvWvnKLFjVLulVVJhOlLhu;

				public Platform_XboxOne_Base bgogLDRQTDSMLHkuaOEaMBqIFdHCA;

				private int DVIijLCKbWQtHktYOJZlcNoPVxzS;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return VkrgMMebWZryqMylGAoextYMMFkL;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return VkrgMMebWZryqMylGAoextYMMFkL;
					}
				}

				[DebuggerHidden]
				public nkTYSRKyAPbRNKeVNBZdxgiLqIeA(int P_0)
				{
					NVgLyDNyFHAaOaJFcwCreXgqDEXH = P_0;
					MSGWZMhvWvnKLFjVLulVVJhOlLhu = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					NVgLyDNyFHAaOaJFcwCreXgqDEXH = -2;
				}

				private bool MoveNext()
				{
					int nVgLyDNyFHAaOaJFcwCreXgqDEXH = NVgLyDNyFHAaOaJFcwCreXgqDEXH;
					Platform_XboxOne_Base platform_XboxOne_Base = bgogLDRQTDSMLHkuaOEaMBqIFdHCA;
					switch (nVgLyDNyFHAaOaJFcwCreXgqDEXH)
					{
					default:
						return false;
					case 0:
						NVgLyDNyFHAaOaJFcwCreXgqDEXH = -1;
						if (platform_XboxOne_Base.elements == null || platform_XboxOne_Base.elements.axes == null)
						{
							return false;
						}
						DVIijLCKbWQtHktYOJZlcNoPVxzS = 0;
						break;
					case 1:
						NVgLyDNyFHAaOaJFcwCreXgqDEXH = -1;
						DVIijLCKbWQtHktYOJZlcNoPVxzS++;
						break;
					}
					if (DVIijLCKbWQtHktYOJZlcNoPVxzS < platform_XboxOne_Base.elements.axes.Length)
					{
						VkrgMMebWZryqMylGAoextYMMFkL = platform_XboxOne_Base.elements.axes[DVIijLCKbWQtHktYOJZlcNoPVxzS];
						NVgLyDNyFHAaOaJFcwCreXgqDEXH = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					nkTYSRKyAPbRNKeVNBZdxgiLqIeA nkTYSRKyAPbRNKeVNBZdxgiLqIeA2;
					if (NVgLyDNyFHAaOaJFcwCreXgqDEXH == -2 && MSGWZMhvWvnKLFjVLulVVJhOlLhu == Environment.CurrentManagedThreadId)
					{
						NVgLyDNyFHAaOaJFcwCreXgqDEXH = 0;
						nkTYSRKyAPbRNKeVNBZdxgiLqIeA2 = this;
					}
					else
					{
						nkTYSRKyAPbRNKeVNBZdxgiLqIeA2 = new nkTYSRKyAPbRNKeVNBZdxgiLqIeA(0);
						nkTYSRKyAPbRNKeVNBZdxgiLqIeA2.bgogLDRQTDSMLHkuaOEaMBqIFdHCA = bgogLDRQTDSMLHkuaOEaMBqIFdHCA;
					}
					return nkTYSRKyAPbRNKeVNBZdxgiLqIeA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class TjFAkvgngsbcIBHygFsjexNRxOlh : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int oCrPmoRkMLcGXEQpeGMVtJaPBcFl;

				private Platform_Custom.Button bLaEXRkiynNlmhlPBDKagoxCoQRO;

				private int ifqbjghRZwfLfGTRsMEnJUvvbLRf;

				public Platform_XboxOne_Base CEcjsclEudDDPAhgPEsMzNAjlykAb;

				private int IcKnwSAgcYDaPfvLfjAfENgtIUYe;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return bLaEXRkiynNlmhlPBDKagoxCoQRO;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return bLaEXRkiynNlmhlPBDKagoxCoQRO;
					}
				}

				[DebuggerHidden]
				public TjFAkvgngsbcIBHygFsjexNRxOlh(int P_0)
				{
					oCrPmoRkMLcGXEQpeGMVtJaPBcFl = P_0;
					ifqbjghRZwfLfGTRsMEnJUvvbLRf = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					oCrPmoRkMLcGXEQpeGMVtJaPBcFl = -2;
				}

				private bool MoveNext()
				{
					int num = oCrPmoRkMLcGXEQpeGMVtJaPBcFl;
					Platform_XboxOne_Base cEcjsclEudDDPAhgPEsMzNAjlykAb = CEcjsclEudDDPAhgPEsMzNAjlykAb;
					switch (num)
					{
					default:
						return false;
					case 0:
						oCrPmoRkMLcGXEQpeGMVtJaPBcFl = -1;
						if (cEcjsclEudDDPAhgPEsMzNAjlykAb.elements == null || cEcjsclEudDDPAhgPEsMzNAjlykAb.elements.buttons == null)
						{
							return false;
						}
						IcKnwSAgcYDaPfvLfjAfENgtIUYe = 0;
						break;
					case 1:
						oCrPmoRkMLcGXEQpeGMVtJaPBcFl = -1;
						IcKnwSAgcYDaPfvLfjAfENgtIUYe++;
						break;
					}
					if (IcKnwSAgcYDaPfvLfjAfENgtIUYe < cEcjsclEudDDPAhgPEsMzNAjlykAb.elements.buttons.Length)
					{
						bLaEXRkiynNlmhlPBDKagoxCoQRO = cEcjsclEudDDPAhgPEsMzNAjlykAb.elements.buttons[IcKnwSAgcYDaPfvLfjAfENgtIUYe];
						oCrPmoRkMLcGXEQpeGMVtJaPBcFl = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					TjFAkvgngsbcIBHygFsjexNRxOlh tjFAkvgngsbcIBHygFsjexNRxOlh;
					if (oCrPmoRkMLcGXEQpeGMVtJaPBcFl == -2 && ifqbjghRZwfLfGTRsMEnJUvvbLRf == Environment.CurrentManagedThreadId)
					{
						oCrPmoRkMLcGXEQpeGMVtJaPBcFl = 0;
						tjFAkvgngsbcIBHygFsjexNRxOlh = this;
					}
					else
					{
						tjFAkvgngsbcIBHygFsjexNRxOlh = new TjFAkvgngsbcIBHygFsjexNRxOlh(0);
						tjFAkvgngsbcIBHygFsjexNRxOlh.CEcjsclEudDDPAhgPEsMzNAjlykAb = CEcjsclEudDDPAhgPEsMzNAjlykAb;
					}
					return tjFAkvgngsbcIBHygFsjexNRxOlh;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			InputPlatform Platform.platform => InputPlatform.XboxOne;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(nkTYSRKyAPbRNKeVNBZdxgiLqIeA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new nkTYSRKyAPbRNKeVNBZdxgiLqIeA(-2)
				{
					bgogLDRQTDSMLHkuaOEaMBqIFdHCA = this
				};
			}

			[IteratorStateMachine(typeof(TjFAkvgngsbcIBHygFsjexNRxOlh))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new TjFAkvgngsbcIBHygFsjexNRxOlh(-2)
				{
					CEcjsclEudDDPAhgPEsMzNAjlykAb = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_XboxOne_Base platform_XboxOne_Base = new Platform_XboxOne_Base();
				CopyVars(platform_XboxOne_Base);
				return platform_XboxOne_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_XboxOne_Base platform_XboxOne_Base)
				{
					platform_XboxOne_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_XboxOne_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_XboxOne : Platform_XboxOne_Base
		{
			public Platform_XboxOne_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_XboxOne platform_XboxOne = new Platform_XboxOne();
				CopyVars(platform_XboxOne);
				return platform_XboxOne;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_XboxOne platform_XboxOne)
				{
					platform_XboxOne.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_PS4_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (productName != null)
					{
						for (int i = 0; i < productName.Length; i++)
						{
							string searchFor = productName[i];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Button;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Axis;
				}
			}

			private sealed class bSFVWKDczsBdTHgASQHHtObCwvHy : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int MONiOcVFSLBmbekcjksCFLtqUnOhA;

				private Platform_Custom.Axis GwoMyFAlJbqUgFxeMNaYhZhQDCbs;

				private int RmCYodUFIQYIpHEnQxvnDlrhggCAA;

				public Platform_PS4_Base lUAMftHrhGscBqmcRbFAnnGGsirp;

				private int DzbzPPfGvlbQjMLWJPOaecCIiqox;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return GwoMyFAlJbqUgFxeMNaYhZhQDCbs;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return GwoMyFAlJbqUgFxeMNaYhZhQDCbs;
					}
				}

				[DebuggerHidden]
				public bSFVWKDczsBdTHgASQHHtObCwvHy(int P_0)
				{
					MONiOcVFSLBmbekcjksCFLtqUnOhA = P_0;
					RmCYodUFIQYIpHEnQxvnDlrhggCAA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					MONiOcVFSLBmbekcjksCFLtqUnOhA = -2;
				}

				private bool MoveNext()
				{
					int mONiOcVFSLBmbekcjksCFLtqUnOhA = MONiOcVFSLBmbekcjksCFLtqUnOhA;
					Platform_PS4_Base platform_PS4_Base = lUAMftHrhGscBqmcRbFAnnGGsirp;
					switch (mONiOcVFSLBmbekcjksCFLtqUnOhA)
					{
					default:
						return false;
					case 0:
						MONiOcVFSLBmbekcjksCFLtqUnOhA = -1;
						if (platform_PS4_Base.elements == null || platform_PS4_Base.elements.axes == null)
						{
							return false;
						}
						DzbzPPfGvlbQjMLWJPOaecCIiqox = 0;
						break;
					case 1:
						MONiOcVFSLBmbekcjksCFLtqUnOhA = -1;
						DzbzPPfGvlbQjMLWJPOaecCIiqox++;
						break;
					}
					if (DzbzPPfGvlbQjMLWJPOaecCIiqox < platform_PS4_Base.elements.axes.Length)
					{
						GwoMyFAlJbqUgFxeMNaYhZhQDCbs = platform_PS4_Base.elements.axes[DzbzPPfGvlbQjMLWJPOaecCIiqox];
						MONiOcVFSLBmbekcjksCFLtqUnOhA = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					bSFVWKDczsBdTHgASQHHtObCwvHy bSFVWKDczsBdTHgASQHHtObCwvHy2;
					if (MONiOcVFSLBmbekcjksCFLtqUnOhA == -2 && RmCYodUFIQYIpHEnQxvnDlrhggCAA == Environment.CurrentManagedThreadId)
					{
						MONiOcVFSLBmbekcjksCFLtqUnOhA = 0;
						bSFVWKDczsBdTHgASQHHtObCwvHy2 = this;
					}
					else
					{
						bSFVWKDczsBdTHgASQHHtObCwvHy2 = new bSFVWKDczsBdTHgASQHHtObCwvHy(0);
						bSFVWKDczsBdTHgASQHHtObCwvHy2.lUAMftHrhGscBqmcRbFAnnGGsirp = lUAMftHrhGscBqmcRbFAnnGGsirp;
					}
					return bSFVWKDczsBdTHgASQHHtObCwvHy2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class KyNOrYqERlXsrlqpcXrCOuOiuPwP : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int pFsNhzGVHheLllFlokcTfRoaBPZH;

				private Platform_Custom.Button uskASbCqzMKTKsBUhxoDPFLUTsioA;

				private int ehOvahuctWWJGUuRzlszfZPQveVH;

				public Platform_PS4_Base pCDaWjUipRDteYhCOQgIZuPNBCrV;

				private int fCRfOejefoNtFILKUlRVEgkfukglB;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return uskASbCqzMKTKsBUhxoDPFLUTsioA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return uskASbCqzMKTKsBUhxoDPFLUTsioA;
					}
				}

				[DebuggerHidden]
				public KyNOrYqERlXsrlqpcXrCOuOiuPwP(int P_0)
				{
					pFsNhzGVHheLllFlokcTfRoaBPZH = P_0;
					ehOvahuctWWJGUuRzlszfZPQveVH = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					pFsNhzGVHheLllFlokcTfRoaBPZH = -2;
				}

				private bool MoveNext()
				{
					int num = pFsNhzGVHheLllFlokcTfRoaBPZH;
					Platform_PS4_Base platform_PS4_Base = pCDaWjUipRDteYhCOQgIZuPNBCrV;
					switch (num)
					{
					default:
						return false;
					case 0:
						pFsNhzGVHheLllFlokcTfRoaBPZH = -1;
						if (platform_PS4_Base.elements == null || platform_PS4_Base.elements.buttons == null)
						{
							return false;
						}
						fCRfOejefoNtFILKUlRVEgkfukglB = 0;
						break;
					case 1:
						pFsNhzGVHheLllFlokcTfRoaBPZH = -1;
						fCRfOejefoNtFILKUlRVEgkfukglB++;
						break;
					}
					if (fCRfOejefoNtFILKUlRVEgkfukglB < platform_PS4_Base.elements.buttons.Length)
					{
						uskASbCqzMKTKsBUhxoDPFLUTsioA = platform_PS4_Base.elements.buttons[fCRfOejefoNtFILKUlRVEgkfukglB];
						pFsNhzGVHheLllFlokcTfRoaBPZH = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					KyNOrYqERlXsrlqpcXrCOuOiuPwP kyNOrYqERlXsrlqpcXrCOuOiuPwP;
					if (pFsNhzGVHheLllFlokcTfRoaBPZH == -2 && ehOvahuctWWJGUuRzlszfZPQveVH == Environment.CurrentManagedThreadId)
					{
						pFsNhzGVHheLllFlokcTfRoaBPZH = 0;
						kyNOrYqERlXsrlqpcXrCOuOiuPwP = this;
					}
					else
					{
						kyNOrYqERlXsrlqpcXrCOuOiuPwP = new KyNOrYqERlXsrlqpcXrCOuOiuPwP(0);
						kyNOrYqERlXsrlqpcXrCOuOiuPwP.pCDaWjUipRDteYhCOQgIZuPNBCrV = pCDaWjUipRDteYhCOQgIZuPNBCrV;
					}
					return kyNOrYqERlXsrlqpcXrCOuOiuPwP;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			InputPlatform Platform.platform => InputPlatform.PS4;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(bSFVWKDczsBdTHgASQHHtObCwvHy))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new bSFVWKDczsBdTHgASQHHtObCwvHy(-2)
				{
					lUAMftHrhGscBqmcRbFAnnGGsirp = this
				};
			}

			[IteratorStateMachine(typeof(KyNOrYqERlXsrlqpcXrCOuOiuPwP))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new KyNOrYqERlXsrlqpcXrCOuOiuPwP(-2)
				{
					pCDaWjUipRDteYhCOQgIZuPNBCrV = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_PS4_Base platform_PS4_Base = new Platform_PS4_Base();
				CopyVars(platform_PS4_Base);
				return platform_PS4_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_PS4_Base platform_PS4_Base)
				{
					platform_PS4_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_PS4_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_PS4 : Platform_PS4_Base
		{
			public Platform_PS4_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_PS4 platform_PS = new Platform_PS4();
				CopyVars(platform_PS);
				return platform_PS;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_PS4 platform_PS)
				{
					platform_PS.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_NintendoSwitch_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (productName != null)
					{
						for (int i = 0; i < productName.Length; i++)
						{
							string searchFor = productName[i];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Button;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Axis;
				}
			}

			private sealed class dvmeAMWaUHpdiogRBWtDHJsDrczp : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int yQRHPmcSOVGDbYfNjacLpuSiyWAf;

				private Platform_Custom.Axis WzYqVaFZuapnrBTbYGWNgUUDfsyk;

				private int ORaGJMBQcxTpIMrHTATKtBQTHgeoA;

				public Platform_NintendoSwitch_Base tDiFmgEMSAjwtbkRIvzGVcyIngkgB;

				private int wDLTLGMfzzKhGCHWUqLNnkRTMaal;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return WzYqVaFZuapnrBTbYGWNgUUDfsyk;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return WzYqVaFZuapnrBTbYGWNgUUDfsyk;
					}
				}

				[DebuggerHidden]
				public dvmeAMWaUHpdiogRBWtDHJsDrczp(int P_0)
				{
					yQRHPmcSOVGDbYfNjacLpuSiyWAf = P_0;
					ORaGJMBQcxTpIMrHTATKtBQTHgeoA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					yQRHPmcSOVGDbYfNjacLpuSiyWAf = -2;
				}

				private bool MoveNext()
				{
					int num = yQRHPmcSOVGDbYfNjacLpuSiyWAf;
					Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = tDiFmgEMSAjwtbkRIvzGVcyIngkgB;
					switch (num)
					{
					default:
						return false;
					case 0:
						yQRHPmcSOVGDbYfNjacLpuSiyWAf = -1;
						if (platform_NintendoSwitch_Base.elements == null || platform_NintendoSwitch_Base.elements.axes == null)
						{
							return false;
						}
						wDLTLGMfzzKhGCHWUqLNnkRTMaal = 0;
						break;
					case 1:
						yQRHPmcSOVGDbYfNjacLpuSiyWAf = -1;
						wDLTLGMfzzKhGCHWUqLNnkRTMaal++;
						break;
					}
					if (wDLTLGMfzzKhGCHWUqLNnkRTMaal < platform_NintendoSwitch_Base.elements.axes.Length)
					{
						WzYqVaFZuapnrBTbYGWNgUUDfsyk = platform_NintendoSwitch_Base.elements.axes[wDLTLGMfzzKhGCHWUqLNnkRTMaal];
						yQRHPmcSOVGDbYfNjacLpuSiyWAf = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					dvmeAMWaUHpdiogRBWtDHJsDrczp dvmeAMWaUHpdiogRBWtDHJsDrczp2;
					if (yQRHPmcSOVGDbYfNjacLpuSiyWAf == -2 && ORaGJMBQcxTpIMrHTATKtBQTHgeoA == Environment.CurrentManagedThreadId)
					{
						yQRHPmcSOVGDbYfNjacLpuSiyWAf = 0;
						dvmeAMWaUHpdiogRBWtDHJsDrczp2 = this;
					}
					else
					{
						dvmeAMWaUHpdiogRBWtDHJsDrczp2 = new dvmeAMWaUHpdiogRBWtDHJsDrczp(0);
						dvmeAMWaUHpdiogRBWtDHJsDrczp2.tDiFmgEMSAjwtbkRIvzGVcyIngkgB = tDiFmgEMSAjwtbkRIvzGVcyIngkgB;
					}
					return dvmeAMWaUHpdiogRBWtDHJsDrczp2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class qRcyCjqRDliRXjmXkfTIfKBLPdtt : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int dByvWzAshTbSmBdguYjVrgMlbimj;

				private Platform_Custom.Button qlwwrziPHCAMIHOOWTFjpucJqLCRA;

				private int KhCaecebPDktfUOWueoDQzXzDydRA;

				public Platform_NintendoSwitch_Base NlKXQypmYKEqWjHbXbMrKeGIsxEc;

				private int mVTaIDGGrGPSIKGhukOLLKviGOqL;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return qlwwrziPHCAMIHOOWTFjpucJqLCRA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return qlwwrziPHCAMIHOOWTFjpucJqLCRA;
					}
				}

				[DebuggerHidden]
				public qRcyCjqRDliRXjmXkfTIfKBLPdtt(int P_0)
				{
					dByvWzAshTbSmBdguYjVrgMlbimj = P_0;
					KhCaecebPDktfUOWueoDQzXzDydRA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					dByvWzAshTbSmBdguYjVrgMlbimj = -2;
				}

				private bool MoveNext()
				{
					int num = dByvWzAshTbSmBdguYjVrgMlbimj;
					Platform_NintendoSwitch_Base nlKXQypmYKEqWjHbXbMrKeGIsxEc = NlKXQypmYKEqWjHbXbMrKeGIsxEc;
					switch (num)
					{
					default:
						return false;
					case 0:
						dByvWzAshTbSmBdguYjVrgMlbimj = -1;
						if (nlKXQypmYKEqWjHbXbMrKeGIsxEc.elements == null || nlKXQypmYKEqWjHbXbMrKeGIsxEc.elements.buttons == null)
						{
							return false;
						}
						mVTaIDGGrGPSIKGhukOLLKviGOqL = 0;
						break;
					case 1:
						dByvWzAshTbSmBdguYjVrgMlbimj = -1;
						mVTaIDGGrGPSIKGhukOLLKviGOqL++;
						break;
					}
					if (mVTaIDGGrGPSIKGhukOLLKviGOqL < nlKXQypmYKEqWjHbXbMrKeGIsxEc.elements.buttons.Length)
					{
						qlwwrziPHCAMIHOOWTFjpucJqLCRA = nlKXQypmYKEqWjHbXbMrKeGIsxEc.elements.buttons[mVTaIDGGrGPSIKGhukOLLKviGOqL];
						dByvWzAshTbSmBdguYjVrgMlbimj = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					qRcyCjqRDliRXjmXkfTIfKBLPdtt qRcyCjqRDliRXjmXkfTIfKBLPdtt2;
					if (dByvWzAshTbSmBdguYjVrgMlbimj == -2 && KhCaecebPDktfUOWueoDQzXzDydRA == Environment.CurrentManagedThreadId)
					{
						dByvWzAshTbSmBdguYjVrgMlbimj = 0;
						qRcyCjqRDliRXjmXkfTIfKBLPdtt2 = this;
					}
					else
					{
						qRcyCjqRDliRXjmXkfTIfKBLPdtt2 = new qRcyCjqRDliRXjmXkfTIfKBLPdtt(0);
						qRcyCjqRDliRXjmXkfTIfKBLPdtt2.NlKXQypmYKEqWjHbXbMrKeGIsxEc = NlKXQypmYKEqWjHbXbMrKeGIsxEc;
					}
					return qRcyCjqRDliRXjmXkfTIfKBLPdtt2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			InputPlatform Platform.platform => InputPlatform.NintendoSwitch;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(dvmeAMWaUHpdiogRBWtDHJsDrczp))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new dvmeAMWaUHpdiogRBWtDHJsDrczp(-2)
				{
					tDiFmgEMSAjwtbkRIvzGVcyIngkgB = this
				};
			}

			[IteratorStateMachine(typeof(qRcyCjqRDliRXjmXkfTIfKBLPdtt))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new qRcyCjqRDliRXjmXkfTIfKBLPdtt(-2)
				{
					NlKXQypmYKEqWjHbXbMrKeGIsxEc = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = new Platform_NintendoSwitch_Base();
				CopyVars(platform_NintendoSwitch_Base);
				return platform_NintendoSwitch_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_NintendoSwitch_Base platform_NintendoSwitch_Base)
				{
					platform_NintendoSwitch_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_NintendoSwitch_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_NintendoSwitch : Platform_NintendoSwitch_Base
		{
			public Platform_NintendoSwitch_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_NintendoSwitch platform_NintendoSwitch = new Platform_NintendoSwitch();
				CopyVars(platform_NintendoSwitch);
				return platform_NintendoSwitch;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_NintendoSwitch platform_NintendoSwitch)
				{
					platform_NintendoSwitch.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_NintendoSwitch2 : Platform_NintendoSwitch
		{
			InputPlatform Platform_NintendoSwitch_Base.platform => InputPlatform.NintendoSwitch2;
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_GameCore_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				public VidPid[] vidPid;

				public DeviceType deviceType;

				public GamepadSubType gamepadSubType;

				public int hatCount;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						if (deviceType != DeviceType.None)
						{
							return true;
						}
						if (vidPid != null && vidPid.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (hatCount >= 0)
					{
						return hatCount == bridgedControllerHWInfo.hardwareHatCount;
					}
					return true;
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (alwaysMatch)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
					{
						return false;
					}
					if (deviceType != DeviceType.None)
					{
						if (deviceType != (DeviceType)bridgedControllerHWInfo.deviceType)
						{
							return false;
						}
						if (deviceType == DeviceType.Gamepad && gamepadSubType != GamepadSubType.None && gamepadSubType != (GamepadSubType)bridgedControllerHWInfo.hw_xInputSubType)
						{
							return false;
						}
						if (!HasProductName() && (vidPid == null || vidPid.Length == 0))
						{
							return true;
						}
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (strictMatch)
					{
						if (vidPid != null)
						{
							for (int i = 0; i < vidPid.Length; i++)
							{
								int vendorId = vidPid[i].vendorId;
								int productId = vidPid[i].productId;
								if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
								{
									string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
									if (!ProductNameMatches(name))
									{
										return false;
									}
								}
								if (bridgedControllerHWInfo.hw_vendorId == vendorId && bridgedControllerHWInfo.hw_productId == productId)
								{
									return true;
								}
							}
						}
						return false;
					}
					return ProductNameMatches(text);
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.deviceType = deviceType;
						matchingCriteria.gamepadSubType = gamepadSubType;
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
					}
				}

				private bool HasProductName()
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						if (!string.IsNullOrEmpty(productName[i]))
						{
							return true;
						}
					}
					return false;
				}

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						case 2:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public int sourceHat;

				public HatDirection sourceHatDirection;

				public HatType sourceHatType;

				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Button button)
					{
						button.sourceHat = sourceHat;
						button.sourceHatDirection = sourceHatDirection;
						button.sourceHatType = sourceHatType;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public HatType sourceHatType;

				public AxisRange sourceHatRange;

				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Axis axis)
					{
						axis.sourceHat = sourceHat;
						axis.sourceHatDirection = sourceHatDirection;
						axis.sourceHatType = sourceHatType;
						axis.sourceHatRange = sourceHatRange;
					}
				}
			}

			public enum DeviceType
			{
				None = 0,
				Gamepad = 1,
				ArcadeStick = 2,
				FlightStick = 3,
				RacingWheel = 4,
				Generic = 6
			}

			public enum GamepadSubType
			{
				None = 0,
				Xbox360 = 1,
				XboxOne = 2,
				DualShock = 3,
				NintendoProController = 4,
				Unknown = 1000
			}

			private sealed class FuvMCLOdkClrhshUSOCjQgAxGSIu : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int SYRTNBjeJsHSaXneqCeqwDiIYgYB;

				private Platform_Custom.Axis PUBCIixDIlvWKNLUxmWUiKfLCWhf;

				private int zjlNqnGBGnRXInHUCaCgpUIbWgEO;

				public Platform_GameCore_Base hYWgpaKYsJDOeZTYqskPjkXTIjAfA;

				private int EtgjdPzSandhyLWJLGLvpoNhuFsf;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return PUBCIixDIlvWKNLUxmWUiKfLCWhf;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return PUBCIixDIlvWKNLUxmWUiKfLCWhf;
					}
				}

				[DebuggerHidden]
				public FuvMCLOdkClrhshUSOCjQgAxGSIu(int P_0)
				{
					SYRTNBjeJsHSaXneqCeqwDiIYgYB = P_0;
					zjlNqnGBGnRXInHUCaCgpUIbWgEO = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					SYRTNBjeJsHSaXneqCeqwDiIYgYB = -2;
				}

				private bool MoveNext()
				{
					int sYRTNBjeJsHSaXneqCeqwDiIYgYB = SYRTNBjeJsHSaXneqCeqwDiIYgYB;
					Platform_GameCore_Base platform_GameCore_Base = hYWgpaKYsJDOeZTYqskPjkXTIjAfA;
					switch (sYRTNBjeJsHSaXneqCeqwDiIYgYB)
					{
					default:
						return false;
					case 0:
						SYRTNBjeJsHSaXneqCeqwDiIYgYB = -1;
						if (platform_GameCore_Base.elements == null || platform_GameCore_Base.elements.axes == null)
						{
							return false;
						}
						EtgjdPzSandhyLWJLGLvpoNhuFsf = 0;
						break;
					case 1:
						SYRTNBjeJsHSaXneqCeqwDiIYgYB = -1;
						EtgjdPzSandhyLWJLGLvpoNhuFsf++;
						break;
					}
					if (EtgjdPzSandhyLWJLGLvpoNhuFsf < platform_GameCore_Base.elements.axes.Length)
					{
						PUBCIixDIlvWKNLUxmWUiKfLCWhf = platform_GameCore_Base.elements.axes[EtgjdPzSandhyLWJLGLvpoNhuFsf];
						SYRTNBjeJsHSaXneqCeqwDiIYgYB = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					FuvMCLOdkClrhshUSOCjQgAxGSIu fuvMCLOdkClrhshUSOCjQgAxGSIu;
					if (SYRTNBjeJsHSaXneqCeqwDiIYgYB == -2 && zjlNqnGBGnRXInHUCaCgpUIbWgEO == Environment.CurrentManagedThreadId)
					{
						SYRTNBjeJsHSaXneqCeqwDiIYgYB = 0;
						fuvMCLOdkClrhshUSOCjQgAxGSIu = this;
					}
					else
					{
						fuvMCLOdkClrhshUSOCjQgAxGSIu = new FuvMCLOdkClrhshUSOCjQgAxGSIu(0);
						fuvMCLOdkClrhshUSOCjQgAxGSIu.hYWgpaKYsJDOeZTYqskPjkXTIjAfA = hYWgpaKYsJDOeZTYqskPjkXTIjAfA;
					}
					return fuvMCLOdkClrhshUSOCjQgAxGSIu;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class qzPQjIqcgwSnplCHJJYonFfHgFST : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int tuvprFAuRjkWsFAtYulClWYemCjT;

				private Platform_Custom.Button xiWybIJYOQDJRGVBEroUKCAmlnId;

				private int UYvAVxDgMukwIBXweIVqEADDsYrQ;

				public Platform_GameCore_Base oKYHPYyLmXrWavfmmgLhApHRBCnB;

				private int QbomuvVelxIMLFJMyamyiPPtoBGxA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return xiWybIJYOQDJRGVBEroUKCAmlnId;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return xiWybIJYOQDJRGVBEroUKCAmlnId;
					}
				}

				[DebuggerHidden]
				public qzPQjIqcgwSnplCHJJYonFfHgFST(int P_0)
				{
					tuvprFAuRjkWsFAtYulClWYemCjT = P_0;
					UYvAVxDgMukwIBXweIVqEADDsYrQ = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					tuvprFAuRjkWsFAtYulClWYemCjT = -2;
				}

				private bool MoveNext()
				{
					int num = tuvprFAuRjkWsFAtYulClWYemCjT;
					Platform_GameCore_Base platform_GameCore_Base = oKYHPYyLmXrWavfmmgLhApHRBCnB;
					switch (num)
					{
					default:
						return false;
					case 0:
						tuvprFAuRjkWsFAtYulClWYemCjT = -1;
						if (platform_GameCore_Base.elements == null || platform_GameCore_Base.elements.buttons == null)
						{
							return false;
						}
						QbomuvVelxIMLFJMyamyiPPtoBGxA = 0;
						break;
					case 1:
						tuvprFAuRjkWsFAtYulClWYemCjT = -1;
						QbomuvVelxIMLFJMyamyiPPtoBGxA++;
						break;
					}
					if (QbomuvVelxIMLFJMyamyiPPtoBGxA < platform_GameCore_Base.elements.buttons.Length)
					{
						xiWybIJYOQDJRGVBEroUKCAmlnId = platform_GameCore_Base.elements.buttons[QbomuvVelxIMLFJMyamyiPPtoBGxA];
						tuvprFAuRjkWsFAtYulClWYemCjT = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					qzPQjIqcgwSnplCHJJYonFfHgFST qzPQjIqcgwSnplCHJJYonFfHgFST2;
					if (tuvprFAuRjkWsFAtYulClWYemCjT == -2 && UYvAVxDgMukwIBXweIVqEADDsYrQ == Environment.CurrentManagedThreadId)
					{
						tuvprFAuRjkWsFAtYulClWYemCjT = 0;
						qzPQjIqcgwSnplCHJJYonFfHgFST2 = this;
					}
					else
					{
						qzPQjIqcgwSnplCHJJYonFfHgFST2 = new qzPQjIqcgwSnplCHJJYonFfHgFST(0);
						qzPQjIqcgwSnplCHJJYonFfHgFST2.oKYHPYyLmXrWavfmmgLhApHRBCnB = oKYHPYyLmXrWavfmmgLhApHRBCnB;
					}
					return qzPQjIqcgwSnplCHJJYonFfHgFST2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			string Platform.controllerNameOverride => controllerName;

			InputPlatform Platform.platform => InputPlatform.GameCore;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(FuvMCLOdkClrhshUSOCjQgAxGSIu))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new FuvMCLOdkClrhshUSOCjQgAxGSIu(-2)
				{
					hYWgpaKYsJDOeZTYqskPjkXTIjAfA = this
				};
			}

			[IteratorStateMachine(typeof(qzPQjIqcgwSnplCHJJYonFfHgFST))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new qzPQjIqcgwSnplCHJJYonFfHgFST(-2)
				{
					oKYHPYyLmXrWavfmmgLhApHRBCnB = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0 && axes_orig[i].sourceType != 2)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0 || Axes_orig[i].sourceType == 2)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_GameCore_Base platform_GameCore_Base = new Platform_GameCore_Base();
				CopyVars(platform_GameCore_Base);
				return platform_GameCore_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_GameCore_Base platform_GameCore_Base)
				{
					platform_GameCore_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_GameCore_Base.elements = MiscTools.DeepClone(elements);
					platform_GameCore_Base.controllerName = controllerName;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_GameCore : Platform_GameCore_Base
		{
			public Platform_GameCore_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_GameCore platform_GameCore = new Platform_GameCore();
				CopyVars(platform_GameCore);
				return platform_GameCore;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_GameCore platform_GameCore)
				{
					platform_GameCore.variants = MiscTools.DeepClone(variants);
				}
			}

			internal static Platform_GameCore CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				Platform_GameCore platform_GameCore = new Platform_GameCore();
				_ = Consts.unknownJoystickElementIdentifiers_orig;
				platform_GameCore.controllerName = "Unknown Controller";
				platform_GameCore.description = "";
				Elements elements = (platform_GameCore.elements = new Elements());
				int num = 32;
				elements.axes = new Axis[num];
				for (int i = 0; i < num; i++)
				{
					Axis axis = new Axis();
					elements.axes[i] = axis;
					axis.axisDeadZone = 0.1f;
					axis.axisUpperDeadZone = 0f;
					axis.axisInfo = HardwareAxisInfo.Default;
					axis.axisMin = -1f;
					axis.axisMax = 1f;
					axis.axisZero = 0f;
					axis.calibrateAxis = BoolWithDefault.Default;
					axis.buttonAxisContribution = Pole.Positive;
					axis.elementIdentifier = i;
					axis.invert = false;
					axis.sourceAxis = i;
					axis.sourceAxisRange = AxisRange.Full;
					axis.sourceType = 1;
				}
				int num2 = 128;
				int num3 = 2 * 8;
				elements.buttons = new Button[num2 + num3];
				for (int j = 0; j < num2; j++)
				{
					Button button = new Button();
					elements.buttons[j] = button;
					button.buttonInfo = new HardwareButtonInfo(false, false);
					button.elementIdentifier = 32 + j;
					button.sourceButton = j;
					button.sourceType = 0;
				}
				int num4 = num2;
				int num5 = 160;
				int num6 = 224;
				for (int k = 0; k < 2; k++)
				{
					for (int l = 0; l < 8; l++)
					{
						bool flag = l % 2 == 0;
						Button button2 = new Button();
						elements.buttons[num4++] = button2;
						button2.buttonInfo = new HardwareButtonInfo(false, false);
						button2.elementIdentifier = (flag ? num5++ : num6++);
						button2.sourceHat = k;
						button2.sourceType = 2;
						button2.sourceHatDirection = (HatDirection)(flag ? (l / 2) : (4 + l / 2));
					}
				}
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				platform_GameCore.matchingCriteria = matchingCriteria;
				platform_GameCore.variants = new Platform_GameCore_Base[0];
				return platform_GameCore;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_PS5_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (productName != null)
					{
						for (int i = 0; i < productName.Length; i++)
						{
							string searchFor = productName[i];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Button;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Axis;
				}
			}

			private sealed class UKMKKiRTYSjojUWiHfCbwxBdhtfF : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int zKLfqyKMeNuRJtCIFyQAJPwWCZcM;

				private Platform_Custom.Axis ZObFPpDGAOOYWmiCSmhuRRciUkmB;

				private int xSYGHVyPFAkRlANXdYhJXORxBHDY;

				public Platform_PS5_Base LHjKdoYveOejrgBbbaEPQCxHATEg;

				private int ghofatwEjojGbBpYvIMtASKvkoGP;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ZObFPpDGAOOYWmiCSmhuRRciUkmB;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ZObFPpDGAOOYWmiCSmhuRRciUkmB;
					}
				}

				[DebuggerHidden]
				public UKMKKiRTYSjojUWiHfCbwxBdhtfF(int P_0)
				{
					zKLfqyKMeNuRJtCIFyQAJPwWCZcM = P_0;
					xSYGHVyPFAkRlANXdYhJXORxBHDY = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					zKLfqyKMeNuRJtCIFyQAJPwWCZcM = -2;
				}

				private bool MoveNext()
				{
					int num = zKLfqyKMeNuRJtCIFyQAJPwWCZcM;
					Platform_PS5_Base lHjKdoYveOejrgBbbaEPQCxHATEg = LHjKdoYveOejrgBbbaEPQCxHATEg;
					switch (num)
					{
					default:
						return false;
					case 0:
						zKLfqyKMeNuRJtCIFyQAJPwWCZcM = -1;
						if (lHjKdoYveOejrgBbbaEPQCxHATEg.elements == null || lHjKdoYveOejrgBbbaEPQCxHATEg.elements.axes == null)
						{
							return false;
						}
						ghofatwEjojGbBpYvIMtASKvkoGP = 0;
						break;
					case 1:
						zKLfqyKMeNuRJtCIFyQAJPwWCZcM = -1;
						ghofatwEjojGbBpYvIMtASKvkoGP++;
						break;
					}
					if (ghofatwEjojGbBpYvIMtASKvkoGP < lHjKdoYveOejrgBbbaEPQCxHATEg.elements.axes.Length)
					{
						ZObFPpDGAOOYWmiCSmhuRRciUkmB = lHjKdoYveOejrgBbbaEPQCxHATEg.elements.axes[ghofatwEjojGbBpYvIMtASKvkoGP];
						zKLfqyKMeNuRJtCIFyQAJPwWCZcM = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					UKMKKiRTYSjojUWiHfCbwxBdhtfF uKMKKiRTYSjojUWiHfCbwxBdhtfF;
					if (zKLfqyKMeNuRJtCIFyQAJPwWCZcM == -2 && xSYGHVyPFAkRlANXdYhJXORxBHDY == Environment.CurrentManagedThreadId)
					{
						zKLfqyKMeNuRJtCIFyQAJPwWCZcM = 0;
						uKMKKiRTYSjojUWiHfCbwxBdhtfF = this;
					}
					else
					{
						uKMKKiRTYSjojUWiHfCbwxBdhtfF = new UKMKKiRTYSjojUWiHfCbwxBdhtfF(0);
						uKMKKiRTYSjojUWiHfCbwxBdhtfF.LHjKdoYveOejrgBbbaEPQCxHATEg = LHjKdoYveOejrgBbbaEPQCxHATEg;
					}
					return uKMKKiRTYSjojUWiHfCbwxBdhtfF;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class fOdxTQHeTEWPEgNjxYKAwwKSBNsU : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int OASuUJVbNPYgUxFyxNnhzjjAazNAA;

				private Platform_Custom.Button FmZTDrlhpDTrdDkaBBqAbyNNWJPuA;

				private int WmyuKsSFqQpzSSGOxwYGXJSkpyXv;

				public Platform_PS5_Base batRHgtGCMLORqzrjkUqPpnraPYS;

				private int MkximZtXDiRGoKvOOlZihYAXiBVK;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return FmZTDrlhpDTrdDkaBBqAbyNNWJPuA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return FmZTDrlhpDTrdDkaBBqAbyNNWJPuA;
					}
				}

				[DebuggerHidden]
				public fOdxTQHeTEWPEgNjxYKAwwKSBNsU(int P_0)
				{
					OASuUJVbNPYgUxFyxNnhzjjAazNAA = P_0;
					WmyuKsSFqQpzSSGOxwYGXJSkpyXv = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					OASuUJVbNPYgUxFyxNnhzjjAazNAA = -2;
				}

				private bool MoveNext()
				{
					int oASuUJVbNPYgUxFyxNnhzjjAazNAA = OASuUJVbNPYgUxFyxNnhzjjAazNAA;
					Platform_PS5_Base platform_PS5_Base = batRHgtGCMLORqzrjkUqPpnraPYS;
					switch (oASuUJVbNPYgUxFyxNnhzjjAazNAA)
					{
					default:
						return false;
					case 0:
						OASuUJVbNPYgUxFyxNnhzjjAazNAA = -1;
						if (platform_PS5_Base.elements == null || platform_PS5_Base.elements.buttons == null)
						{
							return false;
						}
						MkximZtXDiRGoKvOOlZihYAXiBVK = 0;
						break;
					case 1:
						OASuUJVbNPYgUxFyxNnhzjjAazNAA = -1;
						MkximZtXDiRGoKvOOlZihYAXiBVK++;
						break;
					}
					if (MkximZtXDiRGoKvOOlZihYAXiBVK < platform_PS5_Base.elements.buttons.Length)
					{
						FmZTDrlhpDTrdDkaBBqAbyNNWJPuA = platform_PS5_Base.elements.buttons[MkximZtXDiRGoKvOOlZihYAXiBVK];
						OASuUJVbNPYgUxFyxNnhzjjAazNAA = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					fOdxTQHeTEWPEgNjxYKAwwKSBNsU fOdxTQHeTEWPEgNjxYKAwwKSBNsU2;
					if (OASuUJVbNPYgUxFyxNnhzjjAazNAA == -2 && WmyuKsSFqQpzSSGOxwYGXJSkpyXv == Environment.CurrentManagedThreadId)
					{
						OASuUJVbNPYgUxFyxNnhzjjAazNAA = 0;
						fOdxTQHeTEWPEgNjxYKAwwKSBNsU2 = this;
					}
					else
					{
						fOdxTQHeTEWPEgNjxYKAwwKSBNsU2 = new fOdxTQHeTEWPEgNjxYKAwwKSBNsU(0);
						fOdxTQHeTEWPEgNjxYKAwwKSBNsU2.batRHgtGCMLORqzrjkUqPpnraPYS = batRHgtGCMLORqzrjkUqPpnraPYS;
					}
					return fOdxTQHeTEWPEgNjxYKAwwKSBNsU2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			string Platform.controllerNameOverride => controllerName;

			InputPlatform Platform.platform => InputPlatform.PS5;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(UKMKKiRTYSjojUWiHfCbwxBdhtfF))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new UKMKKiRTYSjojUWiHfCbwxBdhtfF(-2)
				{
					LHjKdoYveOejrgBbbaEPQCxHATEg = this
				};
			}

			[IteratorStateMachine(typeof(fOdxTQHeTEWPEgNjxYKAwwKSBNsU))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new fOdxTQHeTEWPEgNjxYKAwwKSBNsU(-2)
				{
					batRHgtGCMLORqzrjkUqPpnraPYS = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_PS5_Base platform_PS5_Base = new Platform_PS5_Base();
				CopyVars(platform_PS5_Base);
				return platform_PS5_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_PS5_Base platform_PS5_Base)
				{
					platform_PS5_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_PS5_Base.elements = MiscTools.DeepClone(elements);
					platform_PS5_Base.controllerName = controllerName;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_PS5 : Platform_PS5_Base
		{
			public Platform_PS5_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_PS5 platform_PS = new Platform_PS5();
				CopyVars(platform_PS);
				return platform_PS;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_PS5 platform_PS)
				{
					platform_PS.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_InternalDriver_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				public VidPid[] vidPid;

				public int hatCount;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						if (vidPid != null && vidPid.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
					{
						return false;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (strictMatch)
					{
						if (vidPid != null)
						{
							for (int i = 0; i < vidPid.Length; i++)
							{
								int vendorId = vidPid[i].vendorId;
								int productId = vidPid[i].productId;
								if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
								{
									string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
									if (!ProductNameMatches(name))
									{
										return false;
									}
								}
								if (bridgedControllerHWInfo.hw_vendorId == vendorId && bridgedControllerHWInfo.hw_productId == productId)
								{
									return true;
								}
							}
						}
						return false;
					}
					return ProductNameMatches(text);
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (alternateMatched)
					{
						return true;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
						matchingCriteria.hatCount = hatCount;
					}
				}

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						case 2:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public int sourceHat;

				public HatDirection sourceHatDirection;

				public HatType sourceHatType;

				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Button button)
					{
						button.sourceHat = sourceHat;
						button.sourceHatDirection = sourceHatDirection;
						button.sourceHatType = sourceHatType;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public HatType sourceHatType;

				public AxisRange sourceHatRange;

				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Axis axis)
					{
						axis.sourceHat = sourceHat;
						axis.sourceHatDirection = sourceHatDirection;
						axis.sourceHatType = sourceHatType;
						axis.sourceHatRange = sourceHatRange;
					}
				}
			}

			private sealed class ooxOnJdXaacILZlTkXdcILFZrooU : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int lrWHlEBLMKakbWZqClVMVySNSTht;

				private Platform_Custom.Axis LjQLbkliVyGhqnVEoIuMIOaRTSrL;

				private int mXxdpQhfuDyVzOfEXkJoDHMxOGtr;

				public Platform_InternalDriver_Base HLYFRDdvCFtCpmqGueoSuiAevLLI;

				private int WtFQRMDootyLyLfWjdsjHLnZdWqB;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return LjQLbkliVyGhqnVEoIuMIOaRTSrL;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return LjQLbkliVyGhqnVEoIuMIOaRTSrL;
					}
				}

				[DebuggerHidden]
				public ooxOnJdXaacILZlTkXdcILFZrooU(int P_0)
				{
					lrWHlEBLMKakbWZqClVMVySNSTht = P_0;
					mXxdpQhfuDyVzOfEXkJoDHMxOGtr = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					lrWHlEBLMKakbWZqClVMVySNSTht = -2;
				}

				private bool MoveNext()
				{
					int num = lrWHlEBLMKakbWZqClVMVySNSTht;
					Platform_InternalDriver_Base hLYFRDdvCFtCpmqGueoSuiAevLLI = HLYFRDdvCFtCpmqGueoSuiAevLLI;
					switch (num)
					{
					default:
						return false;
					case 0:
						lrWHlEBLMKakbWZqClVMVySNSTht = -1;
						if (hLYFRDdvCFtCpmqGueoSuiAevLLI.elements == null || hLYFRDdvCFtCpmqGueoSuiAevLLI.elements.axes == null)
						{
							return false;
						}
						WtFQRMDootyLyLfWjdsjHLnZdWqB = 0;
						break;
					case 1:
						lrWHlEBLMKakbWZqClVMVySNSTht = -1;
						WtFQRMDootyLyLfWjdsjHLnZdWqB++;
						break;
					}
					if (WtFQRMDootyLyLfWjdsjHLnZdWqB < hLYFRDdvCFtCpmqGueoSuiAevLLI.elements.axes.Length)
					{
						LjQLbkliVyGhqnVEoIuMIOaRTSrL = hLYFRDdvCFtCpmqGueoSuiAevLLI.elements.axes[WtFQRMDootyLyLfWjdsjHLnZdWqB];
						lrWHlEBLMKakbWZqClVMVySNSTht = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					ooxOnJdXaacILZlTkXdcILFZrooU ooxOnJdXaacILZlTkXdcILFZrooU2;
					if (lrWHlEBLMKakbWZqClVMVySNSTht == -2 && mXxdpQhfuDyVzOfEXkJoDHMxOGtr == Environment.CurrentManagedThreadId)
					{
						lrWHlEBLMKakbWZqClVMVySNSTht = 0;
						ooxOnJdXaacILZlTkXdcILFZrooU2 = this;
					}
					else
					{
						ooxOnJdXaacILZlTkXdcILFZrooU2 = new ooxOnJdXaacILZlTkXdcILFZrooU(0);
						ooxOnJdXaacILZlTkXdcILFZrooU2.HLYFRDdvCFtCpmqGueoSuiAevLLI = HLYFRDdvCFtCpmqGueoSuiAevLLI;
					}
					return ooxOnJdXaacILZlTkXdcILFZrooU2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class apWDyXLlqeaRrQicIhzndlpbblQn : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int aauIMNKpogmqabERiOLrlftMMfxvb;

				private Platform_Custom.Button yQJaNclCSmigUFrCDTdJdaxBQlxA;

				private int SRvmwTwtayDiioKUwdpwqnePiMMi;

				public Platform_InternalDriver_Base eLpkWupqCNFocFOPIbUJehtSDiGFA;

				private int YfZVTaZeWJUVborMMUgCGYMxJIAu;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return yQJaNclCSmigUFrCDTdJdaxBQlxA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return yQJaNclCSmigUFrCDTdJdaxBQlxA;
					}
				}

				[DebuggerHidden]
				public apWDyXLlqeaRrQicIhzndlpbblQn(int P_0)
				{
					aauIMNKpogmqabERiOLrlftMMfxvb = P_0;
					SRvmwTwtayDiioKUwdpwqnePiMMi = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					aauIMNKpogmqabERiOLrlftMMfxvb = -2;
				}

				private bool MoveNext()
				{
					int num = aauIMNKpogmqabERiOLrlftMMfxvb;
					Platform_InternalDriver_Base platform_InternalDriver_Base = eLpkWupqCNFocFOPIbUJehtSDiGFA;
					switch (num)
					{
					default:
						return false;
					case 0:
						aauIMNKpogmqabERiOLrlftMMfxvb = -1;
						if (platform_InternalDriver_Base.elements == null || platform_InternalDriver_Base.elements.buttons == null)
						{
							return false;
						}
						YfZVTaZeWJUVborMMUgCGYMxJIAu = 0;
						break;
					case 1:
						aauIMNKpogmqabERiOLrlftMMfxvb = -1;
						YfZVTaZeWJUVborMMUgCGYMxJIAu++;
						break;
					}
					if (YfZVTaZeWJUVborMMUgCGYMxJIAu < platform_InternalDriver_Base.elements.buttons.Length)
					{
						yQJaNclCSmigUFrCDTdJdaxBQlxA = platform_InternalDriver_Base.elements.buttons[YfZVTaZeWJUVborMMUgCGYMxJIAu];
						aauIMNKpogmqabERiOLrlftMMfxvb = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					apWDyXLlqeaRrQicIhzndlpbblQn apWDyXLlqeaRrQicIhzndlpbblQn2;
					if (aauIMNKpogmqabERiOLrlftMMfxvb == -2 && SRvmwTwtayDiioKUwdpwqnePiMMi == Environment.CurrentManagedThreadId)
					{
						aauIMNKpogmqabERiOLrlftMMfxvb = 0;
						apWDyXLlqeaRrQicIhzndlpbblQn2 = this;
					}
					else
					{
						apWDyXLlqeaRrQicIhzndlpbblQn2 = new apWDyXLlqeaRrQicIhzndlpbblQn(0);
						apWDyXLlqeaRrQicIhzndlpbblQn2.eLpkWupqCNFocFOPIbUJehtSDiGFA = eLpkWupqCNFocFOPIbUJehtSDiGFA;
					}
					return apWDyXLlqeaRrQicIhzndlpbblQn2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			InputPlatform Platform.platform => InputPlatform.InternalDriver;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(ooxOnJdXaacILZlTkXdcILFZrooU))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new ooxOnJdXaacILZlTkXdcILFZrooU(-2)
				{
					HLYFRDdvCFtCpmqGueoSuiAevLLI = this
				};
			}

			[IteratorStateMachine(typeof(apWDyXLlqeaRrQicIhzndlpbblQn))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new apWDyXLlqeaRrQicIhzndlpbblQn(-2)
				{
					eLpkWupqCNFocFOPIbUJehtSDiGFA = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0 && axes_orig[i].sourceType != 2)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0 || Axes_orig[i].sourceType == 2)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_InternalDriver_Base platform_InternalDriver_Base = new Platform_InternalDriver_Base();
				CopyVars(platform_InternalDriver_Base);
				return platform_InternalDriver_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_InternalDriver_Base platform_InternalDriver_Base)
				{
					platform_InternalDriver_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_InternalDriver_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_InternalDriver : Platform_InternalDriver_Base
		{
			public Platform_InternalDriver_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_InternalDriver platform_InternalDriver = new Platform_InternalDriver();
				CopyVars(platform_InternalDriver);
				return platform_InternalDriver;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_InternalDriver platform_InternalDriver)
				{
					platform_InternalDriver.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_SDL_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						ElementCount elementCount = new ElementCount();
						HXqFlTmkJgbaqWaoLySOLJbfONWh(elementCount);
						return elementCount;
					}

					internal void umGNPUjdbEElRtxDfGSYDvdwBRuY(ElementCount_Base P_0)
					{
						base.HXqFlTmkJgbaqWaoLySOLJbfONWh(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool dGatQVpIzhCekYWKHutSsbZVXrrR(BridgedControllerHWInfo P_0)
					{
						if (!base.iJhYiAkXCqAZNrwRvcAgXrMBxdoL(P_0))
						{
							return false;
						}
						if (hatCount >= 0)
						{
							return hatCount == P_0.hardwareHatCount;
						}
						return true;
					}
				}

				[CustomObfuscation(rename = false)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				internal enum SDLDeviceType
				{
					[CustomObfuscation(rename = false)]
					Any = 0,
					[CustomObfuscation(rename = false)]
					Joystick = 1,
					[CustomObfuscation(rename = false)]
					Gamepad = 2
				}

				[Flags]
				public enum SDLVersionFlags
				{
					None = 0,
					SDL2 = 1,
					SDL3 = 2
				}

				[CustomObfuscation(rename = false)]
				[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				internal class SDLDeviceMatchingProperties
				{
					public int deviceType;
				}

				public int hatCount;

				public bool productName_useRegex;

				public string[] productName;

				public string[] productGUID;

				public ElementCount[] alternateElementCounts;

				public Rewired.Platforms.Platform[] includePlatforms;

				public Rewired.Platforms.Platform[] excludePlatforms;

				public SDLVersionFlags includeSDLVersions;

				public SDLVersionFlags excludeSDLVersions;

				public int deviceType;

				public VidPid[] vidPid;

				private const int deviceTypeAny = 0;

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (includePlatforms != null && includePlatforms.Length != 0)
						{
							return true;
						}
						if (includeSDLVersions != SDLVersionFlags.None)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						if (vidPid != null && vidPid.Length != 0)
						{
							return true;
						}
						if (deviceType != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				int MatchingCriteria_Base.alternateElementCount
				{
					get
					{
						if (alternateElementCounts == null)
						{
							return 0;
						}
						return alternateElementCounts.Length;
					}
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
					{
						return null;
					}
					return alternateElementCounts[index];
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (alternateMatched)
					{
						return true;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (!SupportsPlatform(bridgedControllerHWInfo.workingPlatform))
					{
						return false;
					}
					if (!SupportsVersion(bridgedControllerHWInfo.inputSource))
					{
						return false;
					}
					if (!hasData)
					{
						return false;
					}
					if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
					{
						return false;
					}
					if (!(bridgedControllerHWInfo.userCustomIdentifier is SDLDeviceMatchingProperties sDLDeviceMatchingProperties))
					{
						return false;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					bool flag = false;
					if (deviceType != 0)
					{
						SDLDeviceType sDLDeviceType = (SDLDeviceType)(deviceType - 1);
						if (sDLDeviceMatchingProperties.deviceType != (int)sDLDeviceType)
						{
							return false;
						}
						flag = true;
					}
					bool num = vidPid != null && vidPid.Length != 0;
					bool flag2 = productName != null && productName.Length != 0;
					bool flag3 = num || flag2;
					if (num && (bridgedControllerHWInfo.hw_pidVid.vendorId != 0 || bridgedControllerHWInfo.hw_pidVid.productId != 0) && vidPid != null)
					{
						for (int i = 0; i < vidPid.Length; i++)
						{
							int vendorId = vidPid[i].vendorId;
							int productId = vidPid[i].productId;
							if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_pidVid.vendorId))
							{
								string name = ((text == null) ? string.Empty : text);
								if (!ProductNameMatches(name))
								{
									continue;
								}
							}
							if (bridgedControllerHWInfo.hw_pidVid.vendorId == vendorId && bridgedControllerHWInfo.hw_pidVid.productId == productId)
							{
								return true;
							}
						}
					}
					if (flag2 && ProductNameMatches(text))
					{
						return true;
					}
					if (flag3)
					{
						return false;
					}
					if (flag)
					{
						return true;
					}
					return false;
				}

				internal bool SupportsPlatform(Rewired.Platforms.Platform platform)
				{
					Rewired.Platforms.Platform currentPlatform = ReInput.currentPlatform;
					if (excludePlatforms != null)
					{
						for (int i = 0; i < excludePlatforms.Length; i++)
						{
							if (excludePlatforms[i] == platform || excludePlatforms[i] == currentPlatform)
							{
								return false;
							}
						}
					}
					if (includePlatforms == null || includePlatforms.Length == 0)
					{
						return true;
					}
					for (int j = 0; j < includePlatforms.Length; j++)
					{
						if (includePlatforms[j] == platform)
						{
							return true;
						}
					}
					return false;
				}

				internal bool SupportsVersion(InputSource inputSource)
				{
					SDLVersionFlags sDLVersionFlags = inputSource switch
					{
						InputSource.SDL2 => SDLVersionFlags.SDL2, 
						InputSource.SDL3 => SDLVersionFlags.SDL3, 
						_ => throw new NotImplementedException(), 
					};
					if (excludeSDLVersions != SDLVersionFlags.None && (excludeSDLVersions & sDLVersionFlags) != SDLVersionFlags.None)
					{
						return false;
					}
					if (includeSDLVersions == SDLVersionFlags.None)
					{
						return true;
					}
					if ((includeSDLVersions & sDLVersionFlags) != SDLVersionFlags.None)
					{
						return true;
					}
					return false;
				}

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
						matchingCriteria.alternateElementCounts = ArrayTools.ShallowCopy(alternateElementCounts);
						matchingCriteria.includePlatforms = ArrayTools.ShallowCopy(includePlatforms);
						matchingCriteria.excludePlatforms = ArrayTools.ShallowCopy(excludePlatforms);
						matchingCriteria.deviceType = deviceType;
						matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class SUWCgxnAzROxzuItYoPQBveSvLWM : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int CzQJuNVpRykhRklGDCGEdkvIDRhmA;

					private Axis bmExqpGuFJqGlqeqBzAhnchCoMpu;

					private int ReTeKMhLFcjPfalocwsIoSglQYNY;

					public Elements GzHcPuHuqIUzuTaYDultSTqeoaELA;

					private int hTEREWXgxZbPjYtSiTigllgvHBSR;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return bmExqpGuFJqGlqeqBzAhnchCoMpu;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return bmExqpGuFJqGlqeqBzAhnchCoMpu;
						}
					}

					[DebuggerHidden]
					public SUWCgxnAzROxzuItYoPQBveSvLWM(int P_0)
					{
						CzQJuNVpRykhRklGDCGEdkvIDRhmA = P_0;
						ReTeKMhLFcjPfalocwsIoSglQYNY = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						CzQJuNVpRykhRklGDCGEdkvIDRhmA = -2;
					}

					private bool MoveNext()
					{
						int czQJuNVpRykhRklGDCGEdkvIDRhmA = CzQJuNVpRykhRklGDCGEdkvIDRhmA;
						Elements gzHcPuHuqIUzuTaYDultSTqeoaELA = GzHcPuHuqIUzuTaYDultSTqeoaELA;
						switch (czQJuNVpRykhRklGDCGEdkvIDRhmA)
						{
						default:
							return false;
						case 0:
							CzQJuNVpRykhRklGDCGEdkvIDRhmA = -1;
							if (gzHcPuHuqIUzuTaYDultSTqeoaELA.axes == null)
							{
								return false;
							}
							hTEREWXgxZbPjYtSiTigllgvHBSR = 0;
							break;
						case 1:
							CzQJuNVpRykhRklGDCGEdkvIDRhmA = -1;
							hTEREWXgxZbPjYtSiTigllgvHBSR++;
							break;
						}
						if (hTEREWXgxZbPjYtSiTigllgvHBSR < gzHcPuHuqIUzuTaYDultSTqeoaELA.axes.Length)
						{
							bmExqpGuFJqGlqeqBzAhnchCoMpu = gzHcPuHuqIUzuTaYDultSTqeoaELA.axes[hTEREWXgxZbPjYtSiTigllgvHBSR];
							CzQJuNVpRykhRklGDCGEdkvIDRhmA = 1;
							return true;
						}
						return false;
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						SUWCgxnAzROxzuItYoPQBveSvLWM sUWCgxnAzROxzuItYoPQBveSvLWM;
						if (CzQJuNVpRykhRklGDCGEdkvIDRhmA == -2 && ReTeKMhLFcjPfalocwsIoSglQYNY == Environment.CurrentManagedThreadId)
						{
							CzQJuNVpRykhRklGDCGEdkvIDRhmA = 0;
							sUWCgxnAzROxzuItYoPQBveSvLWM = this;
						}
						else
						{
							sUWCgxnAzROxzuItYoPQBveSvLWM = new SUWCgxnAzROxzuItYoPQBveSvLWM(0);
							sUWCgxnAzROxzuItYoPQBveSvLWM.GzHcPuHuqIUzuTaYDultSTqeoaELA = GzHcPuHuqIUzuTaYDultSTqeoaELA;
						}
						return sUWCgxnAzROxzuItYoPQBveSvLWM;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class YVgRxeuCVSCHcGALNzlRMuVruGyFA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int uQyrZxSrvpUVzIxulUIUUGqgkwTg;

					private Button nMmpUWgcEvGvtCpYQAoJEfqUCHJJA;

					private int GbWfyqtswFnlcboezIEaqiOCfert;

					public Elements IXQHYcBXElcubczpibkEinOsXSsA;

					private int xGRIruBDiWRPVmFTaahyBNvUDyaF;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return nMmpUWgcEvGvtCpYQAoJEfqUCHJJA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return nMmpUWgcEvGvtCpYQAoJEfqUCHJJA;
						}
					}

					[DebuggerHidden]
					public YVgRxeuCVSCHcGALNzlRMuVruGyFA(int P_0)
					{
						uQyrZxSrvpUVzIxulUIUUGqgkwTg = P_0;
						GbWfyqtswFnlcboezIEaqiOCfert = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						uQyrZxSrvpUVzIxulUIUUGqgkwTg = -2;
					}

					private bool MoveNext()
					{
						int num = uQyrZxSrvpUVzIxulUIUUGqgkwTg;
						Elements iXQHYcBXElcubczpibkEinOsXSsA = IXQHYcBXElcubczpibkEinOsXSsA;
						switch (num)
						{
						default:
							return false;
						case 0:
							uQyrZxSrvpUVzIxulUIUUGqgkwTg = -1;
							if (iXQHYcBXElcubczpibkEinOsXSsA.buttons == null)
							{
								return false;
							}
							xGRIruBDiWRPVmFTaahyBNvUDyaF = 0;
							break;
						case 1:
							uQyrZxSrvpUVzIxulUIUUGqgkwTg = -1;
							xGRIruBDiWRPVmFTaahyBNvUDyaF++;
							break;
						}
						if (xGRIruBDiWRPVmFTaahyBNvUDyaF < iXQHYcBXElcubczpibkEinOsXSsA.buttons.Length)
						{
							nMmpUWgcEvGvtCpYQAoJEfqUCHJJA = iXQHYcBXElcubczpibkEinOsXSsA.buttons[xGRIruBDiWRPVmFTaahyBNvUDyaF];
							uQyrZxSrvpUVzIxulUIUUGqgkwTg = 1;
							return true;
						}
						return false;
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						YVgRxeuCVSCHcGALNzlRMuVruGyFA yVgRxeuCVSCHcGALNzlRMuVruGyFA;
						if (uQyrZxSrvpUVzIxulUIUUGqgkwTg == -2 && GbWfyqtswFnlcboezIEaqiOCfert == Environment.CurrentManagedThreadId)
						{
							uQyrZxSrvpUVzIxulUIUUGqgkwTg = 0;
							yVgRxeuCVSCHcGALNzlRMuVruGyFA = this;
						}
						else
						{
							yVgRxeuCVSCHcGALNzlRMuVruGyFA = new YVgRxeuCVSCHcGALNzlRMuVruGyFA(0);
							yVgRxeuCVSCHcGALNzlRMuVruGyFA.IXQHYcBXElcubczpibkEinOsXSsA = IXQHYcBXElcubczpibkEinOsXSsA;
						}
						return yVgRxeuCVSCHcGALNzlRMuVruGyFA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal IEnumerable<Axis> Axes
				{
					[IteratorStateMachine(typeof(SUWCgxnAzROxzuItYoPQBveSvLWM))]
					get
					{
						return new SUWCgxnAzROxzuItYoPQBveSvLWM(-2)
						{
							GzHcPuHuqIUzuTaYDultSTqeoaELA = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(YVgRxeuCVSCHcGALNzlRMuVruGyFA))]
					get
					{
						return new YVgRxeuCVSCHcGALNzlRMuVruGyFA(-2)
						{
							IXQHYcBXElcubczpibkEinOsXSsA = this
						};
					}
				}

				internal Axis GetAxis(int axisIndex)
				{
					if (axes == null || axisIndex < 0 || axisIndex >= axes.Length)
					{
						return null;
					}
					return axes[axisIndex];
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
						case HardwareElementSourceTypeWithHat.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public abstract object DeepClone();

				protected virtual void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class Button : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceButton;

				public int sourceAxis;

				public Pole sourceAxisPole;

				public float axisDeadZone;

				public int sourceHat;

				public HatType sourceHatType;

				public HatDirection sourceHatDirection;

				public bool requireMultipleButtons;

				public int[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public int[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				public Button()
				{
					sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				public override object DeepClone()
				{
					Button button = new Button();
					button.ImportVars(this);
					return button;
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					if (source is Button button)
					{
						elementIdentifier = button.elementIdentifier;
						sourceType = button.sourceType;
						sourceButton = button.sourceButton;
						sourceAxis = button.sourceAxis;
						sourceAxisPole = button.sourceAxisPole;
						axisDeadZone = button.axisDeadZone;
						sourceHat = button.sourceHat;
						sourceHatType = button.sourceHatType;
						sourceHatDirection = button.sourceHatDirection;
						requireMultipleButtons = button.requireMultipleButtons;
						requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
						ignoreIfButtonsActive = button.ignoreIfButtonsActive;
						ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
						buttonInfo = MiscTools.DeepClone(button.buttonInfo);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class Axis : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceAxis;

				public AxisRange sourceAxisRange;

				public bool invert;

				public float axisDeadZone;

				public float axisUpperDeadZone;

				public BoolWithDefault calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				public int sourceButton;

				public Pole buttonAxisContribution;

				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public AxisRange sourceHatRange;

				public Axis()
				{
					sourceType = HardwareElementSourceTypeWithHat.Axis;
				}

				public override object DeepClone()
				{
					Axis axis = new Axis();
					axis.ImportVars(this);
					return axis;
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					if (source is Axis axis)
					{
						elementIdentifier = axis.elementIdentifier;
						sourceType = axis.sourceType;
						sourceAxis = axis.sourceAxis;
						sourceAxisRange = axis.sourceAxisRange;
						invert = axis.invert;
						axisDeadZone = axis.axisDeadZone;
						axisUpperDeadZone = axis.axisUpperDeadZone;
						calibrateAxis = axis.calibrateAxis;
						axisZero = axis.axisZero;
						axisMin = axis.axisMin;
						axisMax = axis.axisMax;
						axisInfo = MiscTools.DeepClone(axis.axisInfo);
						sourceButton = axis.sourceButton;
						buttonAxisContribution = axis.buttonAxisContribution;
						sourceHat = axis.sourceHat;
						sourceHatDirection = axis.sourceHatDirection;
						sourceHatRange = axis.sourceHatRange;
						alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
					}
				}
			}

			private sealed class vAwIIZoavtCFFJOPxWpYILlwjyUlA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int TTasghrrAuPMEWaggwRLDVBHijpT;

				private Axis qwTXUVEAyiSzFAUojowgaDiIVLsX;

				private int itIiUMLIZsrFTIulxaMeIDkpUeMS;

				public Platform_SDL_Base HhMvUjLJvIqDtUpHqkfGVCJdxlF;

				private int jcSiprATgHCGdimREtBVmMXeyAOEb;

				private int TRhExmAUTZKiVUfWVmqQxxWgPHOp;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return qwTXUVEAyiSzFAUojowgaDiIVLsX;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return qwTXUVEAyiSzFAUojowgaDiIVLsX;
					}
				}

				[DebuggerHidden]
				public vAwIIZoavtCFFJOPxWpYILlwjyUlA(int P_0)
				{
					TTasghrrAuPMEWaggwRLDVBHijpT = P_0;
					itIiUMLIZsrFTIulxaMeIDkpUeMS = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					TTasghrrAuPMEWaggwRLDVBHijpT = -2;
				}

				private bool MoveNext()
				{
					int tTasghrrAuPMEWaggwRLDVBHijpT = TTasghrrAuPMEWaggwRLDVBHijpT;
					Platform_SDL_Base hhMvUjLJvIqDtUpHqkfGVCJdxlF = HhMvUjLJvIqDtUpHqkfGVCJdxlF;
					switch (tTasghrrAuPMEWaggwRLDVBHijpT)
					{
					default:
						return false;
					case 0:
						TTasghrrAuPMEWaggwRLDVBHijpT = -1;
						if (hhMvUjLJvIqDtUpHqkfGVCJdxlF.elements == null || hhMvUjLJvIqDtUpHqkfGVCJdxlF.elements.axes == null)
						{
							return false;
						}
						jcSiprATgHCGdimREtBVmMXeyAOEb = hhMvUjLJvIqDtUpHqkfGVCJdxlF.elements.axes.Length;
						TRhExmAUTZKiVUfWVmqQxxWgPHOp = 0;
						break;
					case 1:
						TTasghrrAuPMEWaggwRLDVBHijpT = -1;
						TRhExmAUTZKiVUfWVmqQxxWgPHOp++;
						break;
					}
					if (TRhExmAUTZKiVUfWVmqQxxWgPHOp < jcSiprATgHCGdimREtBVmMXeyAOEb)
					{
						qwTXUVEAyiSzFAUojowgaDiIVLsX = hhMvUjLJvIqDtUpHqkfGVCJdxlF.elements.axes[TRhExmAUTZKiVUfWVmqQxxWgPHOp];
						TTasghrrAuPMEWaggwRLDVBHijpT = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					vAwIIZoavtCFFJOPxWpYILlwjyUlA vAwIIZoavtCFFJOPxWpYILlwjyUlA2;
					if (TTasghrrAuPMEWaggwRLDVBHijpT == -2 && itIiUMLIZsrFTIulxaMeIDkpUeMS == Environment.CurrentManagedThreadId)
					{
						TTasghrrAuPMEWaggwRLDVBHijpT = 0;
						vAwIIZoavtCFFJOPxWpYILlwjyUlA2 = this;
					}
					else
					{
						vAwIIZoavtCFFJOPxWpYILlwjyUlA2 = new vAwIIZoavtCFFJOPxWpYILlwjyUlA(0);
						vAwIIZoavtCFFJOPxWpYILlwjyUlA2.HhMvUjLJvIqDtUpHqkfGVCJdxlF = HhMvUjLJvIqDtUpHqkfGVCJdxlF;
					}
					return vAwIIZoavtCFFJOPxWpYILlwjyUlA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class hzmgmEobLsywdEvVGZnxsJrfrUQg : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int ceDfZVFYQBMfJVsiMoCeLerUubxCA;

				private Button sABpszsifuDRkInfNaEHThbFmPEAA;

				private int ItwJNprqgDaNGGEcIwkbrXNDKiuS;

				public Platform_SDL_Base APEZndehOBZqjkNWNoMjxKpXtFTQ;

				private int tzkCkZFgQAPDlrAsFkSsVfLoQHIB;

				private int vZGKPZbLasRtPwaKwkzLVaVSUvPG;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return sABpszsifuDRkInfNaEHThbFmPEAA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return sABpszsifuDRkInfNaEHThbFmPEAA;
					}
				}

				[DebuggerHidden]
				public hzmgmEobLsywdEvVGZnxsJrfrUQg(int P_0)
				{
					ceDfZVFYQBMfJVsiMoCeLerUubxCA = P_0;
					ItwJNprqgDaNGGEcIwkbrXNDKiuS = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ceDfZVFYQBMfJVsiMoCeLerUubxCA = -2;
				}

				private bool MoveNext()
				{
					int num = ceDfZVFYQBMfJVsiMoCeLerUubxCA;
					Platform_SDL_Base aPEZndehOBZqjkNWNoMjxKpXtFTQ = APEZndehOBZqjkNWNoMjxKpXtFTQ;
					switch (num)
					{
					default:
						return false;
					case 0:
						ceDfZVFYQBMfJVsiMoCeLerUubxCA = -1;
						if (aPEZndehOBZqjkNWNoMjxKpXtFTQ.elements == null || aPEZndehOBZqjkNWNoMjxKpXtFTQ.elements.buttons == null)
						{
							return false;
						}
						tzkCkZFgQAPDlrAsFkSsVfLoQHIB = aPEZndehOBZqjkNWNoMjxKpXtFTQ.elements.buttons.Length;
						vZGKPZbLasRtPwaKwkzLVaVSUvPG = 0;
						break;
					case 1:
						ceDfZVFYQBMfJVsiMoCeLerUubxCA = -1;
						vZGKPZbLasRtPwaKwkzLVaVSUvPG++;
						break;
					}
					if (vZGKPZbLasRtPwaKwkzLVaVSUvPG < tzkCkZFgQAPDlrAsFkSsVfLoQHIB)
					{
						sABpszsifuDRkInfNaEHThbFmPEAA = aPEZndehOBZqjkNWNoMjxKpXtFTQ.elements.buttons[vZGKPZbLasRtPwaKwkzLVaVSUvPG];
						ceDfZVFYQBMfJVsiMoCeLerUubxCA = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					hzmgmEobLsywdEvVGZnxsJrfrUQg hzmgmEobLsywdEvVGZnxsJrfrUQg2;
					if (ceDfZVFYQBMfJVsiMoCeLerUubxCA == -2 && ItwJNprqgDaNGGEcIwkbrXNDKiuS == Environment.CurrentManagedThreadId)
					{
						ceDfZVFYQBMfJVsiMoCeLerUubxCA = 0;
						hzmgmEobLsywdEvVGZnxsJrfrUQg2 = this;
					}
					else
					{
						hzmgmEobLsywdEvVGZnxsJrfrUQg2 = new hzmgmEobLsywdEvVGZnxsJrfrUQg(0);
						hzmgmEobLsywdEvVGZnxsJrfrUQg2.APEZndehOBZqjkNWNoMjxKpXtFTQ = APEZndehOBZqjkNWNoMjxKpXtFTQ;
					}
					return hzmgmEobLsywdEvVGZnxsJrfrUQg2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			InputPlatform Platform.platform => InputPlatform.SDL;

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			[IteratorStateMachine(typeof(vAwIIZoavtCFFJOPxWpYILlwjyUlA))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new vAwIIZoavtCFFJOPxWpYILlwjyUlA(-2)
				{
					HhMvUjLJvIqDtUpHqkfGVCJdxlF = this
				};
			}

			[IteratorStateMachine(typeof(hzmgmEobLsywdEvVGZnxsJrfrUQg))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new hzmgmEobLsywdEvVGZnxsJrfrUQg(-2)
				{
					APEZndehOBZqjkNWNoMjxKpXtFTQ = this
				};
			}

			public override object DeepClone()
			{
				Platform_SDL_Base platform_SDL_Base = new Platform_SDL_Base();
				CopyVars(platform_SDL_Base);
				return platform_SDL_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (destination is Platform_SDL_Base platform_SDL_Base)
				{
					platform_SDL_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_SDL : Platform_SDL_Base
		{
			public Platform_SDL_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_SDL platform_SDL = new Platform_SDL();
				CopyVars(platform_SDL);
				return platform_SDL;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_SDL platform_SDL)
				{
					platform_SDL.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_Steam_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				bool MatchingCriteria_Base.hasData => true;

				bool MatchingCriteria_Base.isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				int MatchingCriteria_Base.alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (disabled)
					{
						return false;
					}
					if (!isAllowed)
					{
						return false;
					}
					return true;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					_ = destination is MatchingCriteria;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				int Elements_Base.buttonCount => 0;

				int Elements_Base.axisCount => 0;

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					_ = destination is Elements;
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = AxisRange.Full;
					return false;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			InputPlatform Platform.platform => InputPlatform.Steam;

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[0];
				axes = new int[0];
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return new AxisCalibrationData[0];
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = new AxisRange[0];
				axisInfos = new HardwareAxisInfo[0];
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = new HardwareButtonInfo[0];
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_Steam_Base platform_Steam_Base = new Platform_Steam_Base();
				CopyVars(platform_Steam_Base);
				return platform_Steam_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (destination is Platform_Steam_Base platform_Steam_Base)
				{
					platform_Steam_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_Steam_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Steam : Platform_Steam_Base
		{
			public Platform_Steam_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_Steam platform_Steam = new Platform_Steam();
				CopyVars(platform_Steam);
				return platform_Steam;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_Steam platform_Steam)
				{
					platform_Steam.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_WebGL_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				[Serializable]
				public sealed class ClientInfo : IDeepCloneable
				{
					public int browser;

					public string browserVersionMin;

					public string browserVersionMax;

					public int os;

					public string osVersionMin;

					public string osVersionMax;

					public object DeepClone()
					{
						return new ClientInfo
						{
							browser = browser,
							browserVersionMin = browserVersionMin,
							browserVersionMax = browserVersionMax,
							os = os,
							osVersionMin = osVersionMin,
							osVersionMax = osVersionMax
						};
					}

					object IDeepCloneable.DeepClone()
					{
						//ILSpy generated this explicit interface implementation from .override directive in DeepClone
						return this.DeepClone();
					}
				}

				public bool productName_useRegex;

				public string[] productName;

				public string[] productGUID;

				public int[] mapping;

				public ElementCount_Base[] elementCount;

				public ClientInfo[] clientInfo;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						if (mapping != null && mapping.Length != 0)
						{
							return true;
						}
						if (productGUID != null && productGUID.Length != 0)
						{
							return true;
						}
						if (elementCount != null && elementCount.Length != 0)
						{
							return true;
						}
						if (clientInfo != null && clientInfo.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					bool result = false;
					string text = StringTools.Trim(tag);
					if (!string.IsNullOrEmpty(text) && !string.Equals(bridgedControllerHWInfo.definitionMatchTag, text, StringComparison.OrdinalIgnoreCase))
					{
						return false;
					}
					if (this.clientInfo != null && this.clientInfo.Length != 0)
					{
						bool flag = false;
						for (int i = 0; i < this.clientInfo.Length; i++)
						{
							ClientInfo clientInfo = this.clientInfo[i];
							if (clientInfo == null)
							{
								continue;
							}
							if (clientInfo.browser != 0)
							{
								if (clientInfo.browser != (int)bridgedControllerHWInfo.webGL_webBrowserType)
								{
									continue;
								}
								if (!CheckBrowserVersion(clientInfo.browser, clientInfo.browserVersionMin, clientInfo.browserVersionMax, bridgedControllerHWInfo.webGL_webBrowserVersionSplit))
								{
									return false;
								}
							}
							if (clientInfo.os != 0)
							{
								if (clientInfo.os != (int)bridgedControllerHWInfo.webGL_osType)
								{
									continue;
								}
								if (!CheckOSVersion(clientInfo.osVersionMin, clientInfo.osVersionMax, bridgedControllerHWInfo.webGL_osVersionSplit))
								{
									return false;
								}
							}
							flag = true;
							break;
						}
						if (!flag)
						{
							return false;
						}
						result = true;
					}
					if (elementCount != null && elementCount.Length != 0)
					{
						bool flag2 = false;
						for (int j = 0; j < elementCount.Length; j++)
						{
							ElementCount_Base elementCount_Base = elementCount[j];
							if (elementCount_Base != null && (elementCount_Base.buttonCount < 0 || elementCount_Base.buttonCount == bridgedControllerHWInfo.hardwareButtonCount) && (elementCount_Base.axisCount < 0 || elementCount_Base.axisCount == bridgedControllerHWInfo.hardwareAxisCount))
							{
								flag2 = true;
							}
						}
						if (!flag2)
						{
							return false;
						}
						result = true;
					}
					if (mapping != null && mapping.Length != 0)
					{
						bool flag3 = false;
						for (int k = 0; k < mapping.Length; k++)
						{
							if (mapping[k] == (int)bridgedControllerHWInfo.webGL_mappingType)
							{
								flag3 = true;
							}
						}
						if (!flag3)
						{
							return false;
						}
						result = true;
					}
					bool flag4 = false;
					bool flag5 = false;
					if (productGUID != null && productGUID.Length != 0 && !ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
					{
						flag5 = true;
						for (int l = 0; l < productGUID.Length; l++)
						{
							if (bridgedControllerHWInfo.hw_pidVid.Equals(productGUID[l]))
							{
								flag4 = true;
								break;
							}
						}
					}
					if (flag4)
					{
						return true;
					}
					string text2 = StringTools.Trim(bridgedControllerHWInfo.hw_productName);
					if (text2 == null)
					{
						text2 = string.Empty;
					}
					if (productName != null && productName.Length != 0)
					{
						flag5 = true;
						for (int m = 0; m < productName.Length; m++)
						{
							string searchFor = productName[m];
							if (MatchingCriteria_Base.StringMatches(text2, searchFor, productName_useRegex))
							{
								flag4 = true;
								break;
							}
						}
					}
					if (flag4)
					{
						return true;
					}
					if (flag5)
					{
						return false;
					}
					return result;
				}

				private static bool CheckBrowserVersion(int browser, string versionMin, string versionMax, string[] currentVersion)
				{
					versionMin = StringTools.Trim(versionMin);
					versionMax = StringTools.Trim(versionMax);
					bool flag = !string.IsNullOrEmpty(versionMin);
					bool flag2 = !string.IsNullOrEmpty(versionMax);
					if (!flag && !flag2)
					{
						return true;
					}
					if (currentVersion == null || currentVersion.Length == 0)
					{
						return false;
					}
					switch (browser)
					{
					case -1:
					case 0:
						return true;
					default:
						if (flag)
						{
							string[] array = versionMin.Split('.');
							int num = MathTools.Min(array.Length, currentVersion.Length);
							bool flag3 = false;
							for (int i = 0; i < num; i++)
							{
								int result;
								bool flag4 = int.TryParse(array[i], out result);
								int result2;
								bool flag5 = int.TryParse(currentVersion[i], out result2);
								if (flag4 && !flag5)
								{
									return false;
								}
								if (!flag4)
								{
									break;
								}
								if (result2 < result)
								{
									return false;
								}
								flag3 = true;
							}
							if (!flag3)
							{
								return false;
							}
						}
						if (flag2)
						{
							string[] array2 = versionMax.Split('.');
							int num2 = MathTools.Min(array2.Length, currentVersion.Length);
							bool flag6 = false;
							for (int j = 0; j < num2; j++)
							{
								int result3;
								bool flag7 = int.TryParse(array2[j], out result3);
								int result4;
								bool flag8 = int.TryParse(currentVersion[j], out result4);
								if (flag7 && !flag8)
								{
									return false;
								}
								if (!flag7)
								{
									break;
								}
								if (result4 > result3)
								{
									return false;
								}
								flag6 = true;
							}
							if (!flag6)
							{
								return false;
							}
						}
						return true;
					}
				}

				private static bool CheckOSVersion(string versionMin, string versionMax, string[] currentVersion)
				{
					versionMin = StringTools.Trim(versionMin);
					versionMax = StringTools.Trim(versionMax);
					bool flag = !string.IsNullOrEmpty(versionMin);
					bool flag2 = !string.IsNullOrEmpty(versionMax);
					if (!flag && !flag2)
					{
						return true;
					}
					if (currentVersion == null || currentVersion.Length == 0)
					{
						return false;
					}
					if (flag)
					{
						string[] array = versionMin.Split('.');
						int num = MathTools.Min(array.Length, currentVersion.Length);
						bool flag3 = false;
						for (int i = 0; i < num; i++)
						{
							int result;
							bool flag4 = int.TryParse(array[i], out result);
							int result2;
							bool flag5 = int.TryParse(currentVersion[i], out result2);
							if (flag4 && !flag5)
							{
								return false;
							}
							if (!flag4)
							{
								break;
							}
							if (result2 < result)
							{
								return false;
							}
							flag3 = true;
						}
						if (!flag3)
						{
							return false;
						}
					}
					if (flag2)
					{
						string[] array2 = versionMax.Split('.');
						int num2 = MathTools.Min(array2.Length, currentVersion.Length);
						bool flag6 = false;
						for (int j = 0; j < num2; j++)
						{
							int result3;
							bool flag7 = int.TryParse(array2[j], out result3);
							int result4;
							bool flag8 = int.TryParse(currentVersion[j], out result4);
							if (flag7 && !flag8)
							{
								return false;
							}
							if (!flag7)
							{
								break;
							}
							if (result4 > result3)
							{
								return false;
							}
							flag6 = true;
						}
						if (!flag6)
						{
							return false;
						}
					}
					return true;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
						matchingCriteria.mapping = ArrayTools.ShallowCopy(mapping);
						matchingCriteria.elementCount = ArrayTools.DeepClone(elementCount);
						matchingCriteria.clientInfo = ArrayTools.DeepClone(clientInfo);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Button;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Axis;
				}
			}

			private sealed class uVCTmwvUZoGeOrecSMOknJpgYpJM : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int ECYSoFpNeWFYbimTGWeufXltNxsPA;

				private Platform_Custom.Axis sURFRgrEoaHTweibtCIBXnFwdKFNA;

				private int bKLFGRvvuDaBVmhGpIGgYirfZvZf;

				public Platform_WebGL_Base eXwGVxbfCKqokgQNABtfSkpLCbTwB;

				private int aIWfHlouIphyrDSVynGlilZbpSOBB;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return sURFRgrEoaHTweibtCIBXnFwdKFNA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return sURFRgrEoaHTweibtCIBXnFwdKFNA;
					}
				}

				[DebuggerHidden]
				public uVCTmwvUZoGeOrecSMOknJpgYpJM(int P_0)
				{
					ECYSoFpNeWFYbimTGWeufXltNxsPA = P_0;
					bKLFGRvvuDaBVmhGpIGgYirfZvZf = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ECYSoFpNeWFYbimTGWeufXltNxsPA = -2;
				}

				private bool MoveNext()
				{
					int eCYSoFpNeWFYbimTGWeufXltNxsPA = ECYSoFpNeWFYbimTGWeufXltNxsPA;
					Platform_WebGL_Base platform_WebGL_Base = eXwGVxbfCKqokgQNABtfSkpLCbTwB;
					switch (eCYSoFpNeWFYbimTGWeufXltNxsPA)
					{
					default:
						return false;
					case 0:
						ECYSoFpNeWFYbimTGWeufXltNxsPA = -1;
						if (platform_WebGL_Base.elements == null || platform_WebGL_Base.elements.axes == null)
						{
							return false;
						}
						aIWfHlouIphyrDSVynGlilZbpSOBB = 0;
						break;
					case 1:
						ECYSoFpNeWFYbimTGWeufXltNxsPA = -1;
						aIWfHlouIphyrDSVynGlilZbpSOBB++;
						break;
					}
					if (aIWfHlouIphyrDSVynGlilZbpSOBB < platform_WebGL_Base.elements.axes.Length)
					{
						sURFRgrEoaHTweibtCIBXnFwdKFNA = platform_WebGL_Base.elements.axes[aIWfHlouIphyrDSVynGlilZbpSOBB];
						ECYSoFpNeWFYbimTGWeufXltNxsPA = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					uVCTmwvUZoGeOrecSMOknJpgYpJM uVCTmwvUZoGeOrecSMOknJpgYpJM2;
					if (ECYSoFpNeWFYbimTGWeufXltNxsPA == -2 && bKLFGRvvuDaBVmhGpIGgYirfZvZf == Environment.CurrentManagedThreadId)
					{
						ECYSoFpNeWFYbimTGWeufXltNxsPA = 0;
						uVCTmwvUZoGeOrecSMOknJpgYpJM2 = this;
					}
					else
					{
						uVCTmwvUZoGeOrecSMOknJpgYpJM2 = new uVCTmwvUZoGeOrecSMOknJpgYpJM(0);
						uVCTmwvUZoGeOrecSMOknJpgYpJM2.eXwGVxbfCKqokgQNABtfSkpLCbTwB = eXwGVxbfCKqokgQNABtfSkpLCbTwB;
					}
					return uVCTmwvUZoGeOrecSMOknJpgYpJM2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class PRVLUkcOpOEjCHPAhJvJBRNTsHwAb : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int EjNGqrwgHyqLulHREWdoakGNAVveA;

				private Platform_Custom.Button ApFpkLAAWenUZTDqpkWozKMyBjxh;

				private int ZNpsSsoNvgBAuqPitFPORlueunSf;

				public Platform_WebGL_Base tMDQvhHLpgVzKuOGFjtLkIcnWLPU;

				private int nSPZytEcRIsnGABfpxrTZBHuVGvP;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ApFpkLAAWenUZTDqpkWozKMyBjxh;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ApFpkLAAWenUZTDqpkWozKMyBjxh;
					}
				}

				[DebuggerHidden]
				public PRVLUkcOpOEjCHPAhJvJBRNTsHwAb(int P_0)
				{
					EjNGqrwgHyqLulHREWdoakGNAVveA = P_0;
					ZNpsSsoNvgBAuqPitFPORlueunSf = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					EjNGqrwgHyqLulHREWdoakGNAVveA = -2;
				}

				private bool MoveNext()
				{
					int ejNGqrwgHyqLulHREWdoakGNAVveA = EjNGqrwgHyqLulHREWdoakGNAVveA;
					Platform_WebGL_Base platform_WebGL_Base = tMDQvhHLpgVzKuOGFjtLkIcnWLPU;
					switch (ejNGqrwgHyqLulHREWdoakGNAVveA)
					{
					default:
						return false;
					case 0:
						EjNGqrwgHyqLulHREWdoakGNAVveA = -1;
						if (platform_WebGL_Base.elements == null || platform_WebGL_Base.elements.buttons == null)
						{
							return false;
						}
						nSPZytEcRIsnGABfpxrTZBHuVGvP = 0;
						break;
					case 1:
						EjNGqrwgHyqLulHREWdoakGNAVveA = -1;
						nSPZytEcRIsnGABfpxrTZBHuVGvP++;
						break;
					}
					if (nSPZytEcRIsnGABfpxrTZBHuVGvP < platform_WebGL_Base.elements.buttons.Length)
					{
						ApFpkLAAWenUZTDqpkWozKMyBjxh = platform_WebGL_Base.elements.buttons[nSPZytEcRIsnGABfpxrTZBHuVGvP];
						EjNGqrwgHyqLulHREWdoakGNAVveA = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					PRVLUkcOpOEjCHPAhJvJBRNTsHwAb pRVLUkcOpOEjCHPAhJvJBRNTsHwAb;
					if (EjNGqrwgHyqLulHREWdoakGNAVveA == -2 && ZNpsSsoNvgBAuqPitFPORlueunSf == Environment.CurrentManagedThreadId)
					{
						EjNGqrwgHyqLulHREWdoakGNAVveA = 0;
						pRVLUkcOpOEjCHPAhJvJBRNTsHwAb = this;
					}
					else
					{
						pRVLUkcOpOEjCHPAhJvJBRNTsHwAb = new PRVLUkcOpOEjCHPAhJvJBRNTsHwAb(0);
						pRVLUkcOpOEjCHPAhJvJBRNTsHwAb.tMDQvhHLpgVzKuOGFjtLkIcnWLPU = tMDQvhHLpgVzKuOGFjtLkIcnWLPU;
					}
					return pRVLUkcOpOEjCHPAhJvJBRNTsHwAb;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			InputPlatform Platform.platform => InputPlatform.WebGL;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(uVCTmwvUZoGeOrecSMOknJpgYpJM))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new uVCTmwvUZoGeOrecSMOknJpgYpJM(-2)
				{
					eXwGVxbfCKqokgQNABtfSkpLCbTwB = this
				};
			}

			[IteratorStateMachine(typeof(PRVLUkcOpOEjCHPAhJvJBRNTsHwAb))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new PRVLUkcOpOEjCHPAhJvJBRNTsHwAb(-2)
				{
					tMDQvhHLpgVzKuOGFjtLkIcnWLPU = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_WebGL_Base platform_WebGL_Base = new Platform_WebGL_Base();
				CopyVars(platform_WebGL_Base);
				return platform_WebGL_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_WebGL_Base platform_WebGL_Base)
				{
					platform_WebGL_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_WebGL_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_WebGL : Platform_WebGL_Base
		{
			public Platform_WebGL_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_WebGL platform_WebGL = new Platform_WebGL();
				CopyVars(platform_WebGL);
				return platform_WebGL;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_WebGL platform_WebGL)
				{
					platform_WebGL.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_AppleGCController_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				[Serializable]
				public class ProfileTypeSet
				{
					public AppleGCControllerProfileTypeFlags primaryProfileTypes;

					public AppleGCControllerProfileSubType[] profileSubTypes;
				}

				public bool productCategory_useRegex;

				public string[] productCategory;

				public bool productName_useRegex;

				public string[] productName;

				public ProfileTypeSet[] includeProfileTypeSets;

				public AppleGCControllerPlatform[] includePlatforms;

				public AppleGCControllerPlatform[] excludePlatforms;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productCategory != null && productCategory.Length != 0)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						if (includeProfileTypeSets != null && includeProfileTypeSets.Length != 0)
						{
							return true;
						}
						if (includePlatforms != null && includePlatforms.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!SupportsPlatform(bridgedControllerHWInfo.workingPlatform))
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
					{
						return false;
					}
					bool flag = HasProductName();
					bool flag2 = HasProductCategory();
					bool result = false;
					if (includeProfileTypeSets != null)
					{
						for (int i = 0; i < includeProfileTypeSets.Length; i++)
						{
							if (Matches(includeProfileTypeSets[i], bridgedControllerHWInfo))
							{
								result = true;
								break;
							}
						}
					}
					bool flag3 = false;
					if (flag2)
					{
						flag3 = true;
						if (!string.IsNullOrEmpty(bridgedControllerHWInfo.hw_systemDeviceName) && ProductCategoryMatches(bridgedControllerHWInfo.hw_systemDeviceName.Trim()))
						{
							return true;
						}
					}
					if (flag)
					{
						flag3 = true;
						if (!string.IsNullOrEmpty(bridgedControllerHWInfo.hw_productName) && ProductNameMatches(bridgedControllerHWInfo.hw_productName.Trim()))
						{
							return true;
						}
					}
					if (flag3)
					{
						return false;
					}
					return result;
				}

				private static bool Matches(ProfileTypeSet set, BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					bool result = false;
					if (set.primaryProfileTypes != AppleGCControllerProfileTypeFlags.None)
					{
						bool flag = false;
						for (int i = 0; i < 32; i++)
						{
							if (((uint)set.primaryProfileTypes & (uint)(1 << i) & (uint)bridgedControllerHWInfo.deviceType) != 0)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							return false;
						}
						result = true;
					}
					if (set.profileSubTypes != null && set.profileSubTypes.Length != 0)
					{
						bool flag2 = false;
						for (int j = 0; j < set.profileSubTypes.Length; j++)
						{
							if (set.profileSubTypes[j] == (AppleGCControllerProfileSubType)bridgedControllerHWInfo.hw_xInputSubType)
							{
								flag2 = true;
								break;
							}
						}
						if (!flag2)
						{
							return false;
						}
						result = true;
					}
					return result;
				}

				private bool SupportsPlatform(Rewired.Platforms.Platform platform)
				{
					AppleGCControllerPlatform currentPlatform = (AppleGCControllerPlatform)ReInput.currentPlatform;
					if (excludePlatforms != null)
					{
						for (int i = 0; i < excludePlatforms.Length; i++)
						{
							if (excludePlatforms[i] == (AppleGCControllerPlatform)platform || excludePlatforms[i] == currentPlatform)
							{
								return false;
							}
						}
					}
					if (includePlatforms == null || includePlatforms.Length == 0)
					{
						return true;
					}
					for (int j = 0; j < includePlatforms.Length; j++)
					{
						if (includePlatforms[j] == (AppleGCControllerPlatform)platform)
						{
							return true;
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productCategory_useRegex = productCategory_useRegex;
						matchingCriteria.productCategory = ArrayTools.ShallowCopy(productCategory);
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.includeProfileTypeSets = ArrayTools.ShallowCopy(includeProfileTypeSets);
						matchingCriteria.includePlatforms = ArrayTools.ShallowCopy(includePlatforms);
						matchingCriteria.excludePlatforms = ArrayTools.ShallowCopy(excludePlatforms);
					}
				}

				private bool HasProductCategory()
				{
					if (productCategory == null)
					{
						return false;
					}
					for (int i = 0; i < productCategory.Length; i++)
					{
						if (!string.IsNullOrEmpty(productCategory[i]))
						{
							return true;
						}
					}
					return false;
				}

				private bool ProductCategoryMatches(string name)
				{
					if (productCategory == null)
					{
						return false;
					}
					for (int i = 0; i < productCategory.Length; i++)
					{
						string searchFor = productCategory[i];
						if (MatchingCriteria_Base.StringMatches(name, searchFor, productCategory_useRegex))
						{
							return true;
						}
					}
					return false;
				}

				private bool HasProductName()
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						if (!string.IsNullOrEmpty(productName[i]))
						{
							return true;
						}
					}
					return false;
				}

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public CompoundElement[] compoundElements;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				public int compoundElementCount
				{
					get
					{
						if (compoundElements == null)
						{
							return 0;
						}
						return compoundElements.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
						elements.compoundElements = ArrayTools.DeepClone(compoundElements);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public AppleGCControllerElementIdentifier sourceElementId;

				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Button button)
					{
						button.sourceElementId = sourceElementId;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public AppleGCControllerElementIdentifier sourceElementId;

				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Axis axis)
					{
						axis.sourceElementId = sourceElementId;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class CompoundElement : IDeepCloneable
			{
				public int elementIdentifier;

				public int sourceElementIndex;

				public AppleGCControllerElementIdentifierCompoundElements sourceElementId;

				internal void CopyVars(CompoundElement destination)
				{
					destination.elementIdentifier = elementIdentifier;
					destination.sourceElementIndex = sourceElementIndex;
					destination.sourceElementId = sourceElementId;
				}

				public object DeepClone()
				{
					CompoundElement compoundElement = new CompoundElement();
					CopyVars(compoundElement);
					return compoundElement;
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerProfileTypeFlags
			{
				None = 0,
				Generic = 1,
				ExtendedGamepad = 2,
				MicroGamepad = 4,
				Unknown = int.MinValue
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerProfileSubType
			{
				None = 0,
				XboxController = 1,
				SonyDualShock4 = 2,
				SonyDualSense = 3,
				NintendoSwitchJoyConL = 4,
				NintendoSwitchJoyConR = 5,
				NintendoSwitchJoyConDual = 6,
				NintendoSwitchProController = 7,
				ArcadeStick = 100,
				DirectionalGamepad = 150,
				SiriRemoteGen1 = 151,
				SiriRemoteGen2 = 152,
				ControlCenterRemote = 153,
				UniversalElectronicsRemote = 154,
				CoalescedRemote = 155,
				SpatialController = 200,
				SpatialStylus = 201,
				Keyboard = 300,
				Mouse = 301,
				MFi = 500,
				HID = 501,
				Unknown = -1
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerElementIdentifier
			{
				None = 0,
				A = 1,
				B = 2,
				X = 3,
				Y = 4,
				LeftShoulder = 5,
				RightShoulder = 6,
				Menu = 7,
				Options = 8,
				Home = 9,
				LeftStickButton = 10,
				RightStickButton = 11,
				DPadUp = 12,
				DPadRight = 13,
				DPadDown = 14,
				DPadLeft = 15,
				LeftStickX = 16,
				LeftStickY = 17,
				RightStickX = 18,
				RightStickY = 19,
				LeftTrigger = 20,
				RightTrigger = 21,
				DPadVertical = 22,
				DPadHorizontal = 23,
				TouchpadButton = 24,
				Paddle1 = 25,
				Paddle2 = 26,
				Paddle3 = 27,
				Paddle4 = 28,
				IndexedButton = 29,
				IndexedAxis = 30,
				LeftBumper = 36,
				RightBumper = 37,
				LeftBackIndexedButton = 38,
				RightBackIndexedButton = 39,
				Share = 40,
				CardinalDPadUp = 43,
				CardinalDPadDown = 44,
				CardinalDPadRight = 45,
				CardinalDPadLeft = 46,
				CardinalDPadHorizontal = 47,
				CardinalDPadVertical = 48,
				DPadCenterButton = 49,
				GripButton = 50,
				Trigger = 51,
				ThumbStickX = 53,
				ThumbStickY = 54,
				ThumbStickButton = 55,
				LeftSideButton = 56,
				RightSideButton = 57,
				StylusTip = 58,
				StylusButton1 = 59,
				StylusButton2 = 60,
				AccelerationX = 1000001,
				AccelerationY = 1000002,
				AccelerationZ = 1000003,
				UserAccelerationX = 1000004,
				UserAccelerationY = 1000005,
				UserAccelerationZ = 1000006,
				GravityX = 1000007,
				GravityY = 1000008,
				GravityZ = 1000009,
				RotationRateX = 1000010,
				RotationRateY = 1000011,
				RotationRateZ = 1000012,
				AttitudeX = 1000013,
				AttitudeY = 1000014,
				AttitudeZ = 1000015,
				AttitudeW = 1000016,
				Pitch = 1000017,
				Roll = 1000018
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerElementIdentifierCompoundElements
			{
				None = 0,
				LeftStick = 33,
				RightStick = 34,
				DPad = 35,
				CardinalDPad = 41,
				ThumbStick = 51
			}

			[CustomObfuscation(rename = false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal enum AppleGCControllerElementIdentifierAxes
			{
				[CustomObfuscation(rename = false)]
				None = 0,
				[CustomObfuscation(rename = false)]
				LeftStickX = 16,
				[CustomObfuscation(rename = false)]
				LeftStickY = 17,
				[CustomObfuscation(rename = false)]
				RightStickX = 18,
				[CustomObfuscation(rename = false)]
				RightStickY = 19,
				[CustomObfuscation(rename = false)]
				DPadVertical = 22,
				[CustomObfuscation(rename = false)]
				DPadHorizontal = 23,
				[CustomObfuscation(rename = false)]
				CardinalDPadHorizontal = 47,
				[CustomObfuscation(rename = false)]
				CardinalDPadVertical = 48,
				[CustomObfuscation(rename = false)]
				Trigger = 51,
				[CustomObfuscation(rename = false)]
				ThumbStickX = 53,
				[CustomObfuscation(rename = false)]
				ThumbStickY = 54,
				[CustomObfuscation(rename = false)]
				AccelerationX = 1000001,
				[CustomObfuscation(rename = false)]
				AccelerationY = 1000002,
				[CustomObfuscation(rename = false)]
				AccelerationZ = 1000003,
				[CustomObfuscation(rename = false)]
				UserAccelerationX = 1000004,
				[CustomObfuscation(rename = false)]
				UserAccelerationY = 1000005,
				[CustomObfuscation(rename = false)]
				UserAccelerationZ = 1000006,
				[CustomObfuscation(rename = false)]
				GravityX = 1000007,
				[CustomObfuscation(rename = false)]
				GravityY = 1000008,
				[CustomObfuscation(rename = false)]
				GravityZ = 1000009,
				[CustomObfuscation(rename = false)]
				RotationRateX = 1000010,
				[CustomObfuscation(rename = false)]
				RotationRateY = 1000011,
				[CustomObfuscation(rename = false)]
				RotationRateZ = 1000012,
				[CustomObfuscation(rename = false)]
				AttitudeX = 1000013,
				[CustomObfuscation(rename = false)]
				AttitudeY = 1000014,
				[CustomObfuscation(rename = false)]
				AttitudeZ = 1000015,
				[CustomObfuscation(rename = false)]
				AttitudeW = 1000016,
				[CustomObfuscation(rename = false)]
				Pitch = 1000017,
				[CustomObfuscation(rename = false)]
				Roll = 1000018
			}

			[CustomObfuscation(rename = false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal enum AppleGCControllerElementIdentifierButtons
			{
				[CustomObfuscation(rename = false)]
				None = 0,
				[CustomObfuscation(rename = false)]
				A = 1,
				[CustomObfuscation(rename = false)]
				B = 2,
				[CustomObfuscation(rename = false)]
				X = 3,
				[CustomObfuscation(rename = false)]
				Y = 4,
				[CustomObfuscation(rename = false)]
				LeftShoulder = 5,
				[CustomObfuscation(rename = false)]
				RightShoulder = 6,
				[CustomObfuscation(rename = false)]
				Menu = 7,
				[CustomObfuscation(rename = false)]
				Options = 8,
				[CustomObfuscation(rename = false)]
				Home = 9,
				[CustomObfuscation(rename = false)]
				LeftStickButton = 10,
				[CustomObfuscation(rename = false)]
				RightStickButton = 11,
				[CustomObfuscation(rename = false)]
				DPadUp = 12,
				[CustomObfuscation(rename = false)]
				DPadRight = 13,
				[CustomObfuscation(rename = false)]
				DPadDown = 14,
				[CustomObfuscation(rename = false)]
				DPadLeft = 15,
				[CustomObfuscation(rename = false)]
				LeftTrigger = 20,
				[CustomObfuscation(rename = false)]
				RightTrigger = 21,
				[CustomObfuscation(rename = false)]
				TouchpadButton = 24,
				[CustomObfuscation(rename = false)]
				Paddle1 = 25,
				[CustomObfuscation(rename = false)]
				Paddle2 = 26,
				[CustomObfuscation(rename = false)]
				Paddle3 = 27,
				[CustomObfuscation(rename = false)]
				Paddle4 = 28,
				[CustomObfuscation(rename = false)]
				LeftBumper = 36,
				[CustomObfuscation(rename = false)]
				RightBumper = 37,
				[CustomObfuscation(rename = false)]
				LeftBackIndexedButton = 38,
				[CustomObfuscation(rename = false)]
				RightBackIndexedButton = 39,
				[CustomObfuscation(rename = false)]
				Share = 40,
				[CustomObfuscation(rename = false)]
				CardinalDPadUp = 43,
				[CustomObfuscation(rename = false)]
				CardinalDPadDown = 44,
				[CustomObfuscation(rename = false)]
				CardinalDPadRight = 45,
				[CustomObfuscation(rename = false)]
				CardinalDPadLeft = 46,
				[CustomObfuscation(rename = false)]
				DPadCenterButton = 49,
				[CustomObfuscation(rename = false)]
				GripButton = 50,
				[CustomObfuscation(rename = false)]
				ThumbStickButton = 55,
				[CustomObfuscation(rename = false)]
				LeftSideButton = 56,
				[CustomObfuscation(rename = false)]
				RightSideButton = 57,
				[CustomObfuscation(rename = false)]
				StylusTip = 58,
				[CustomObfuscation(rename = false)]
				StylusButton1 = 59,
				[CustomObfuscation(rename = false)]
				StylusButton2 = 60
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerPlatform
			{
				MacOS = 4,
				iOS = 5,
				tvOS = 28,
				VisionOS = 107
			}

			private sealed class mixknfCFdrhFvyEcChDeBLSzmRyj : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int HUHlsCwFRSyjDskOWUcUOFnPjqTY;

				private Platform_Custom.Axis lbjEvCFEXlEHCUgxOgVZPMAFOAoEA;

				private int nxqhhyKWFzJXuTlkocJHRDljGUtFA;

				public Platform_AppleGCController_Base DwQWXavFQoaGdABwYzTBCeBFRrcgb;

				private int VJzuTCMflJmNclMrBvgRPWhtvOqL;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return lbjEvCFEXlEHCUgxOgVZPMAFOAoEA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return lbjEvCFEXlEHCUgxOgVZPMAFOAoEA;
					}
				}

				[DebuggerHidden]
				public mixknfCFdrhFvyEcChDeBLSzmRyj(int P_0)
				{
					HUHlsCwFRSyjDskOWUcUOFnPjqTY = P_0;
					nxqhhyKWFzJXuTlkocJHRDljGUtFA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					HUHlsCwFRSyjDskOWUcUOFnPjqTY = -2;
				}

				private bool MoveNext()
				{
					int hUHlsCwFRSyjDskOWUcUOFnPjqTY = HUHlsCwFRSyjDskOWUcUOFnPjqTY;
					Platform_AppleGCController_Base dwQWXavFQoaGdABwYzTBCeBFRrcgb = DwQWXavFQoaGdABwYzTBCeBFRrcgb;
					switch (hUHlsCwFRSyjDskOWUcUOFnPjqTY)
					{
					default:
						return false;
					case 0:
						HUHlsCwFRSyjDskOWUcUOFnPjqTY = -1;
						if (dwQWXavFQoaGdABwYzTBCeBFRrcgb.elements == null || dwQWXavFQoaGdABwYzTBCeBFRrcgb.elements.axes == null)
						{
							return false;
						}
						VJzuTCMflJmNclMrBvgRPWhtvOqL = 0;
						break;
					case 1:
						HUHlsCwFRSyjDskOWUcUOFnPjqTY = -1;
						VJzuTCMflJmNclMrBvgRPWhtvOqL++;
						break;
					}
					if (VJzuTCMflJmNclMrBvgRPWhtvOqL < dwQWXavFQoaGdABwYzTBCeBFRrcgb.elements.axes.Length)
					{
						lbjEvCFEXlEHCUgxOgVZPMAFOAoEA = dwQWXavFQoaGdABwYzTBCeBFRrcgb.elements.axes[VJzuTCMflJmNclMrBvgRPWhtvOqL];
						HUHlsCwFRSyjDskOWUcUOFnPjqTY = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					mixknfCFdrhFvyEcChDeBLSzmRyj mixknfCFdrhFvyEcChDeBLSzmRyj2;
					if (HUHlsCwFRSyjDskOWUcUOFnPjqTY == -2 && nxqhhyKWFzJXuTlkocJHRDljGUtFA == Environment.CurrentManagedThreadId)
					{
						HUHlsCwFRSyjDskOWUcUOFnPjqTY = 0;
						mixknfCFdrhFvyEcChDeBLSzmRyj2 = this;
					}
					else
					{
						mixknfCFdrhFvyEcChDeBLSzmRyj2 = new mixknfCFdrhFvyEcChDeBLSzmRyj(0);
						mixknfCFdrhFvyEcChDeBLSzmRyj2.DwQWXavFQoaGdABwYzTBCeBFRrcgb = DwQWXavFQoaGdABwYzTBCeBFRrcgb;
					}
					return mixknfCFdrhFvyEcChDeBLSzmRyj2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class jpDkiAYBZFkONKIpsyQFDaSNknqe : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int cikGWBKioQYEZEnrybEeIMModesK;

				private Platform_Custom.Button TfBHSmlqjvNhsEDyElmqcFMyJIkt;

				private int ktmDsFzPuahSdxUEKAKahsmKFNBs;

				public Platform_AppleGCController_Base IyNBMNWcLoFLDKSTjGkfaiPKOlpkA;

				private int gGhIjqpSXNSMKacPZgYuNKHEITtd;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return TfBHSmlqjvNhsEDyElmqcFMyJIkt;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return TfBHSmlqjvNhsEDyElmqcFMyJIkt;
					}
				}

				[DebuggerHidden]
				public jpDkiAYBZFkONKIpsyQFDaSNknqe(int P_0)
				{
					cikGWBKioQYEZEnrybEeIMModesK = P_0;
					ktmDsFzPuahSdxUEKAKahsmKFNBs = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					cikGWBKioQYEZEnrybEeIMModesK = -2;
				}

				private bool MoveNext()
				{
					int num = cikGWBKioQYEZEnrybEeIMModesK;
					Platform_AppleGCController_Base iyNBMNWcLoFLDKSTjGkfaiPKOlpkA = IyNBMNWcLoFLDKSTjGkfaiPKOlpkA;
					switch (num)
					{
					default:
						return false;
					case 0:
						cikGWBKioQYEZEnrybEeIMModesK = -1;
						if (iyNBMNWcLoFLDKSTjGkfaiPKOlpkA.elements == null || iyNBMNWcLoFLDKSTjGkfaiPKOlpkA.elements.buttons == null)
						{
							return false;
						}
						gGhIjqpSXNSMKacPZgYuNKHEITtd = 0;
						break;
					case 1:
						cikGWBKioQYEZEnrybEeIMModesK = -1;
						gGhIjqpSXNSMKacPZgYuNKHEITtd++;
						break;
					}
					if (gGhIjqpSXNSMKacPZgYuNKHEITtd < iyNBMNWcLoFLDKSTjGkfaiPKOlpkA.elements.buttons.Length)
					{
						TfBHSmlqjvNhsEDyElmqcFMyJIkt = iyNBMNWcLoFLDKSTjGkfaiPKOlpkA.elements.buttons[gGhIjqpSXNSMKacPZgYuNKHEITtd];
						cikGWBKioQYEZEnrybEeIMModesK = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					jpDkiAYBZFkONKIpsyQFDaSNknqe jpDkiAYBZFkONKIpsyQFDaSNknqe2;
					if (cikGWBKioQYEZEnrybEeIMModesK == -2 && ktmDsFzPuahSdxUEKAKahsmKFNBs == Environment.CurrentManagedThreadId)
					{
						cikGWBKioQYEZEnrybEeIMModesK = 0;
						jpDkiAYBZFkONKIpsyQFDaSNknqe2 = this;
					}
					else
					{
						jpDkiAYBZFkONKIpsyQFDaSNknqe2 = new jpDkiAYBZFkONKIpsyQFDaSNknqe(0);
						jpDkiAYBZFkONKIpsyQFDaSNknqe2.IyNBMNWcLoFLDKSTjGkfaiPKOlpkA = IyNBMNWcLoFLDKSTjGkfaiPKOlpkA;
					}
					return jpDkiAYBZFkONKIpsyQFDaSNknqe2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			private CompoundElement[] _compoundElementsOrigGame;

			private const int specialElementsValueStart = 1000000;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			string Platform.controllerNameOverride => controllerName;

			InputPlatform Platform.platform => InputPlatform.AppleGameController;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal CompoundElement[] CompoundElements
			{
				get
				{
					if (_compoundElementsOrigGame == null)
					{
						CompoundElement[] compoundElements_orig = CompoundElements_orig;
						if (compoundElements_orig != null)
						{
							_compoundElementsOrigGame = new CompoundElement[compoundElements_orig.Length];
							for (int i = 0; i < compoundElements_orig.Length; i++)
							{
								_compoundElementsOrigGame[i] = compoundElements_orig[i];
							}
						}
					}
					return _compoundElementsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal CompoundElement[] CompoundElements_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.compoundElements;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(mixknfCFdrhFvyEcChDeBLSzmRyj))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new mixknfCFdrhFvyEcChDeBLSzmRyj(-2)
				{
					DwQWXavFQoaGdABwYzTBCeBFRrcgb = this
				};
			}

			[IteratorStateMachine(typeof(jpDkiAYBZFkONKIpsyQFDaSNknqe))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new jpDkiAYBZFkONKIpsyQFDaSNknqe(-2)
				{
					IyNBMNWcLoFLDKSTjGkfaiPKOlpkA = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_AppleGCController_Base platform_AppleGCController_Base = new Platform_AppleGCController_Base();
				CopyVars(platform_AppleGCController_Base);
				return platform_AppleGCController_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_AppleGCController_Base platform_AppleGCController_Base)
				{
					platform_AppleGCController_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_AppleGCController_Base.elements = MiscTools.DeepClone(elements);
					platform_AppleGCController_Base.controllerName = controllerName;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_AppleGCController : Platform_AppleGCController_Base
		{
			public Platform_AppleGCController_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_AppleGCController platform_AppleGCController = new Platform_AppleGCController();
				CopyVars(platform_AppleGCController);
				return platform_AppleGCController;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_AppleGCController platform_AppleGCController)
				{
					platform_AppleGCController.variants = MiscTools.DeepClone(variants);
				}
			}

			internal static Platform_AppleGCController CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				Platform_AppleGCController platform_AppleGCController = new Platform_AppleGCController();
				_ = Consts.unknownJoystickElementIdentifiers_orig;
				platform_AppleGCController.controllerName = "Unknown Controller";
				platform_AppleGCController.description = "";
				Elements elements = (platform_AppleGCController.elements = new Elements());
				int num = 32;
				elements.axes = new Axis[num];
				for (int i = 0; i < num; i++)
				{
					Axis axis = new Axis();
					elements.axes[i] = axis;
					axis.axisDeadZone = 0.1f;
					axis.axisUpperDeadZone = 0f;
					axis.axisInfo = HardwareAxisInfo.Default;
					axis.axisMin = -1f;
					axis.axisMax = 1f;
					axis.axisZero = 0f;
					axis.calibrateAxis = BoolWithDefault.Default;
					axis.buttonAxisContribution = Pole.Positive;
					axis.elementIdentifier = i;
					axis.invert = false;
					axis.sourceAxis = i;
					axis.sourceAxisRange = AxisRange.Full;
					axis.sourceType = 1;
				}
				int num2 = 128;
				elements.buttons = new Button[num2];
				for (int j = 0; j < num2; j++)
				{
					Button button = new Button();
					elements.buttons[j] = button;
					button.buttonInfo = new HardwareButtonInfo(false, false);
					button.elementIdentifier = 32 + j;
					button.sourceButton = j;
					button.sourceType = 0;
				}
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				platform_AppleGCController.matchingCriteria = matchingCriteria;
				platform_AppleGCController.variants = new Platform_AppleGCController_Base[0];
				return platform_AppleGCController;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_WindowsWGI_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				public VidPid[] vidPid;

				public DeviceType deviceType;

				public int hatCount;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						if (deviceType != DeviceType.None)
						{
							return true;
						}
						if (vidPid != null && vidPid.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (hatCount >= 0)
					{
						return hatCount == bridgedControllerHWInfo.hardwareHatCount;
					}
					return true;
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (alwaysMatch)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
					{
						return false;
					}
					if ((!string.IsNullOrEmpty(bridgedControllerHWInfo.definitionMatchTag) || !string.IsNullOrEmpty(tag)) && !string.Equals(bridgedControllerHWInfo.definitionMatchTag, tag, StringComparison.OrdinalIgnoreCase))
					{
						return false;
					}
					if (deviceType != DeviceType.None)
					{
						if (deviceType != (DeviceType)bridgedControllerHWInfo.deviceType)
						{
							return false;
						}
						if (!HasProductName() && (vidPid == null || vidPid.Length == 0))
						{
							return true;
						}
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (strictMatch)
					{
						if (vidPid != null)
						{
							for (int i = 0; i < vidPid.Length; i++)
							{
								int vendorId = vidPid[i].vendorId;
								int productId = vidPid[i].productId;
								if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_pidVid.vendorId))
								{
									string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
									if (!ProductNameMatches(name))
									{
										return false;
									}
								}
								if ((vendorId < 0 || bridgedControllerHWInfo.hw_pidVid.vendorId == vendorId) && (productId < 0 || bridgedControllerHWInfo.hw_pidVid.productId == productId))
								{
									return true;
								}
							}
						}
						return false;
					}
					return ProductNameMatches(text);
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.deviceType = deviceType;
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
					}
				}

				private bool HasProductName()
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						if (!string.IsNullOrEmpty(productName[i]))
						{
							return true;
						}
					}
					return false;
				}

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						case 2:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public int sourceHat;

				public HatDirection sourceHatDirection;

				public HatType sourceHatType;

				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Button button)
					{
						button.sourceHat = sourceHat;
						button.sourceHatDirection = sourceHatDirection;
						button.sourceHatType = sourceHatType;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public HatType sourceHatType;

				public AxisRange sourceHatRange;

				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Axis axis)
					{
						axis.sourceHat = sourceHat;
						axis.sourceHatDirection = sourceHatDirection;
						axis.sourceHatType = sourceHatType;
						axis.sourceHatRange = sourceHatRange;
					}
				}
			}

			public enum DeviceType
			{
				None = 0,
				Gamepad = 1
			}

			private sealed class qkPdwVZyMPDGujVLxLOsDApIDTiw : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int ckyIvoKKXMUsZZEeBdxEqbgUMGpg;

				private Platform_Custom.Axis wGwYpfydDsyaQLtuAJEqfuVOCNqc;

				private int ivprpbFClwoGIGYQniQioJbNeBpr;

				public Platform_WindowsWGI_Base pmltEKsnTkMvloplFHrZuXvkeFks;

				private int NhHVeNuhJOWABhdiwuGDQbgMDrFCA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return wGwYpfydDsyaQLtuAJEqfuVOCNqc;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return wGwYpfydDsyaQLtuAJEqfuVOCNqc;
					}
				}

				[DebuggerHidden]
				public qkPdwVZyMPDGujVLxLOsDApIDTiw(int P_0)
				{
					ckyIvoKKXMUsZZEeBdxEqbgUMGpg = P_0;
					ivprpbFClwoGIGYQniQioJbNeBpr = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ckyIvoKKXMUsZZEeBdxEqbgUMGpg = -2;
				}

				private bool MoveNext()
				{
					int num = ckyIvoKKXMUsZZEeBdxEqbgUMGpg;
					Platform_WindowsWGI_Base platform_WindowsWGI_Base = pmltEKsnTkMvloplFHrZuXvkeFks;
					switch (num)
					{
					default:
						return false;
					case 0:
						ckyIvoKKXMUsZZEeBdxEqbgUMGpg = -1;
						if (platform_WindowsWGI_Base.elements == null || platform_WindowsWGI_Base.elements.axes == null)
						{
							return false;
						}
						NhHVeNuhJOWABhdiwuGDQbgMDrFCA = 0;
						break;
					case 1:
						ckyIvoKKXMUsZZEeBdxEqbgUMGpg = -1;
						NhHVeNuhJOWABhdiwuGDQbgMDrFCA++;
						break;
					}
					if (NhHVeNuhJOWABhdiwuGDQbgMDrFCA < platform_WindowsWGI_Base.elements.axes.Length)
					{
						wGwYpfydDsyaQLtuAJEqfuVOCNqc = platform_WindowsWGI_Base.elements.axes[NhHVeNuhJOWABhdiwuGDQbgMDrFCA];
						ckyIvoKKXMUsZZEeBdxEqbgUMGpg = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					qkPdwVZyMPDGujVLxLOsDApIDTiw qkPdwVZyMPDGujVLxLOsDApIDTiw2;
					if (ckyIvoKKXMUsZZEeBdxEqbgUMGpg == -2 && ivprpbFClwoGIGYQniQioJbNeBpr == Environment.CurrentManagedThreadId)
					{
						ckyIvoKKXMUsZZEeBdxEqbgUMGpg = 0;
						qkPdwVZyMPDGujVLxLOsDApIDTiw2 = this;
					}
					else
					{
						qkPdwVZyMPDGujVLxLOsDApIDTiw2 = new qkPdwVZyMPDGujVLxLOsDApIDTiw(0);
						qkPdwVZyMPDGujVLxLOsDApIDTiw2.pmltEKsnTkMvloplFHrZuXvkeFks = pmltEKsnTkMvloplFHrZuXvkeFks;
					}
					return qkPdwVZyMPDGujVLxLOsDApIDTiw2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class oVLogWKtYtLCaoOXucyoDQWDZAnGA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int WkIQYYmYyufHrAkxgdobwWkXEriY;

				private Platform_Custom.Button NKfUgfeYftrcZPZGgpPibGmlPJxo;

				private int MddqnaQaUZMzNQlfvjlxGdANgTbF;

				public Platform_WindowsWGI_Base ypBTbWZUcDSfUDeWDbLhohHdfQG;

				private int VoofATpCGaXzFcSPhfgaWETUKmxM;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return NKfUgfeYftrcZPZGgpPibGmlPJxo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return NKfUgfeYftrcZPZGgpPibGmlPJxo;
					}
				}

				[DebuggerHidden]
				public oVLogWKtYtLCaoOXucyoDQWDZAnGA(int P_0)
				{
					WkIQYYmYyufHrAkxgdobwWkXEriY = P_0;
					MddqnaQaUZMzNQlfvjlxGdANgTbF = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					WkIQYYmYyufHrAkxgdobwWkXEriY = -2;
				}

				private bool MoveNext()
				{
					int wkIQYYmYyufHrAkxgdobwWkXEriY = WkIQYYmYyufHrAkxgdobwWkXEriY;
					Platform_WindowsWGI_Base platform_WindowsWGI_Base = ypBTbWZUcDSfUDeWDbLhohHdfQG;
					switch (wkIQYYmYyufHrAkxgdobwWkXEriY)
					{
					default:
						return false;
					case 0:
						WkIQYYmYyufHrAkxgdobwWkXEriY = -1;
						if (platform_WindowsWGI_Base.elements == null || platform_WindowsWGI_Base.elements.buttons == null)
						{
							return false;
						}
						VoofATpCGaXzFcSPhfgaWETUKmxM = 0;
						break;
					case 1:
						WkIQYYmYyufHrAkxgdobwWkXEriY = -1;
						VoofATpCGaXzFcSPhfgaWETUKmxM++;
						break;
					}
					if (VoofATpCGaXzFcSPhfgaWETUKmxM < platform_WindowsWGI_Base.elements.buttons.Length)
					{
						NKfUgfeYftrcZPZGgpPibGmlPJxo = platform_WindowsWGI_Base.elements.buttons[VoofATpCGaXzFcSPhfgaWETUKmxM];
						WkIQYYmYyufHrAkxgdobwWkXEriY = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					oVLogWKtYtLCaoOXucyoDQWDZAnGA oVLogWKtYtLCaoOXucyoDQWDZAnGA2;
					if (WkIQYYmYyufHrAkxgdobwWkXEriY == -2 && MddqnaQaUZMzNQlfvjlxGdANgTbF == Environment.CurrentManagedThreadId)
					{
						WkIQYYmYyufHrAkxgdobwWkXEriY = 0;
						oVLogWKtYtLCaoOXucyoDQWDZAnGA2 = this;
					}
					else
					{
						oVLogWKtYtLCaoOXucyoDQWDZAnGA2 = new oVLogWKtYtLCaoOXucyoDQWDZAnGA(0);
						oVLogWKtYtLCaoOXucyoDQWDZAnGA2.ypBTbWZUcDSfUDeWDbLhohHdfQG = ypBTbWZUcDSfUDeWDbLhohHdfQG;
					}
					return oVLogWKtYtLCaoOXucyoDQWDZAnGA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			string Platform.controllerNameOverride => controllerName;

			InputPlatform Platform.platform => InputPlatform.WindowsWGI;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(qkPdwVZyMPDGujVLxLOsDApIDTiw))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new qkPdwVZyMPDGujVLxLOsDApIDTiw(-2)
				{
					pmltEKsnTkMvloplFHrZuXvkeFks = this
				};
			}

			[IteratorStateMachine(typeof(oVLogWKtYtLCaoOXucyoDQWDZAnGA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new oVLogWKtYtLCaoOXucyoDQWDZAnGA(-2)
				{
					ypBTbWZUcDSfUDeWDbLhohHdfQG = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0 && axes_orig[i].sourceType != 2)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0 || Axes_orig[i].sourceType == 2)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_WindowsWGI_Base platform_WindowsWGI_Base = new Platform_WindowsWGI_Base();
				CopyVars(platform_WindowsWGI_Base);
				return platform_WindowsWGI_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_WindowsWGI_Base platform_WindowsWGI_Base)
				{
					platform_WindowsWGI_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_WindowsWGI_Base.elements = MiscTools.DeepClone(elements);
					platform_WindowsWGI_Base.controllerName = controllerName;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_WindowsWGI : Platform_WindowsWGI_Base
		{
			public Platform_WindowsWGI_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_WindowsWGI platform_WindowsWGI = new Platform_WindowsWGI();
				CopyVars(platform_WindowsWGI);
				return platform_WindowsWGI;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_WindowsWGI platform_WindowsWGI)
				{
					platform_WindowsWGI.variants = MiscTools.DeepClone(variants);
				}
			}

			internal static Platform_WindowsWGI CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				Platform_WindowsWGI platform_WindowsWGI = new Platform_WindowsWGI();
				_ = Consts.unknownJoystickElementIdentifiers_orig;
				platform_WindowsWGI.controllerName = "Unknown Controller";
				platform_WindowsWGI.description = "";
				Elements elements = (platform_WindowsWGI.elements = new Elements());
				int num = 32;
				elements.axes = new Axis[num];
				for (int i = 0; i < num; i++)
				{
					Axis axis = new Axis();
					elements.axes[i] = axis;
					axis.axisDeadZone = 0.1f;
					axis.axisUpperDeadZone = 0f;
					axis.axisInfo = HardwareAxisInfo.Default;
					axis.axisMin = -1f;
					axis.axisMax = 1f;
					axis.axisZero = 0f;
					axis.calibrateAxis = BoolWithDefault.Default;
					axis.buttonAxisContribution = Pole.Positive;
					axis.elementIdentifier = i;
					axis.invert = false;
					axis.sourceAxis = i;
					axis.sourceAxisRange = AxisRange.Full;
					axis.sourceType = 1;
				}
				int num2 = 128;
				int num3 = 16 * 8;
				elements.buttons = new Button[num2 + num3];
				for (int j = 0; j < num2; j++)
				{
					Button button = new Button();
					elements.buttons[j] = button;
					button.buttonInfo = new HardwareButtonInfo(false, false);
					button.elementIdentifier = 32 + j;
					button.sourceButton = j;
					button.sourceType = 0;
				}
				int num4 = num2;
				int num5 = 160;
				int num6 = 224;
				for (int k = 0; k < 16; k++)
				{
					for (int l = 0; l < 8; l++)
					{
						bool flag = l % 2 == 0;
						Button button2 = new Button();
						elements.buttons[num4++] = button2;
						button2.buttonInfo = new HardwareButtonInfo(false, false);
						button2.elementIdentifier = (flag ? num5++ : num6++);
						button2.sourceHat = k;
						button2.sourceType = 2;
						button2.sourceHatDirection = (HatDirection)(flag ? (l / 2) : (4 + l / 2));
					}
				}
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				platform_WindowsWGI.matchingCriteria = matchingCriteria;
				platform_WindowsWGI.variants = new Platform_WindowsWGI_Base[0];
				return platform_WindowsWGI;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_UnityInputSystem_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				[CustomObfuscation(rename = false)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				internal enum UnityInputSystemDeviceType
				{
					[CustomObfuscation(rename = false)]
					Any = 0,
					[CustomObfuscation(rename = false)]
					Unknown = 1,
					[CustomObfuscation(rename = false)]
					GenericJoystick = 4,
					[CustomObfuscation(rename = false)]
					Gamepad = 5,
					[CustomObfuscation(rename = false)]
					OtherJoystick = 6,
					[CustomObfuscation(rename = false)]
					TrackedDevice = 7
				}

				public ElementCount_Base[] alternateElementCounts;

				public Rewired.Platforms.Platform[] platforms;

				public Rewired.Platforms.Platform[] excludedPlatforms;

				public int deviceType;

				public string[] tags;

				public bool productName_useRegex;

				public string[] productName;

				public VidPid[] vidPid;

				private const int deviceTypeAny = 0;

				private const int deviceSubTypeAny = 0;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (platforms != null && platforms.Length != 0)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						if (vidPid != null && vidPid.Length != 0)
						{
							return true;
						}
						if (tags != null && tags.Length != 0)
						{
							return true;
						}
						if (deviceType != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				int Platform_Custom.MatchingCriteria.alternateElementCount
				{
					get
					{
						if (alternateElementCounts == null)
						{
							return 0;
						}
						return alternateElementCounts.Length;
					}
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
					{
						return null;
					}
					return alternateElementCounts[index];
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (!SupportsPlatform(bridgedControllerHWInfo.workingPlatform))
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					if (!hasData)
					{
						return false;
					}
					if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
					{
						return false;
					}
					if (!(bridgedControllerHWInfo.userCustomIdentifier is UnityInputSystemDeviceMatchingProperties { deviceName: var text } unityInputSystemDeviceMatchingProperties))
					{
						return false;
					}
					if (text == null)
					{
						text = string.Empty;
					}
					string name = text.Trim();
					bool flag = false;
					bool flag2 = false;
					if (deviceType != 0)
					{
						Rewired.Platforms.UnityInputSystem.UnityInputSystemDeviceType unityInputSystemDeviceType = (Rewired.Platforms.UnityInputSystem.UnityInputSystemDeviceType)(deviceType - 1);
						if (unityInputSystemDeviceMatchingProperties.unityDeviceType != unityInputSystemDeviceType)
						{
							return false;
						}
						flag = true;
					}
					if (tags != null && tags.Length != 0)
					{
						bool flag3 = false;
						IList<string> list = bridgedControllerHWInfo.tags;
						if (list != null)
						{
							int count = list.Count;
							bool flag4 = false;
							bool flag5 = false;
							bool flag6 = false;
							for (int i = 0; i < tags.Length; i++)
							{
								if (string.IsNullOrEmpty(tags[i]))
								{
									continue;
								}
								if (tags[i][0] == '+')
								{
									flag4 = true;
									string a = tags[i].Substring(1);
									for (int j = 0; j < count; j++)
									{
										bool flag7 = false;
										if (string.Equals(a, list[j], StringComparison.Ordinal))
										{
											flag7 = true;
											flag6 = true;
										}
										if (!flag7)
										{
											return false;
										}
									}
									continue;
								}
								if (tags[i][0] == '-')
								{
									string a2 = tags[i].Substring(1);
									for (int j = 0; j < count; j++)
									{
										if (string.Equals(a2, list[j], StringComparison.Ordinal))
										{
											return false;
										}
									}
									continue;
								}
								flag5 = true;
								for (int j = 0; j < count; j++)
								{
									if (string.Equals(tags[i], list[j], StringComparison.Ordinal))
									{
										flag3 = true;
									}
								}
							}
							if (flag4 && !flag5 && flag6)
							{
								flag3 = true;
							}
						}
						if (!flag3)
						{
							return false;
						}
						flag2 = true;
					}
					bool num = vidPid != null && vidPid.Length != 0;
					bool flag8 = productName != null && productName.Length != 0;
					bool flag9 = num || flag8;
					if (num && unityInputSystemDeviceMatchingProperties.productId.HasValue && unityInputSystemDeviceMatchingProperties.vendorId.HasValue && vidPid != null)
					{
						for (int k = 0; k < vidPid.Length; k++)
						{
							int vendorId = vidPid[k].vendorId;
							int productId = vidPid[k].productId;
							if (ArrayTools.Contains(Consts.questionableVIDs, unityInputSystemDeviceMatchingProperties.vendorId.Value))
							{
								string name2 = ((unityInputSystemDeviceMatchingProperties.deviceName == null) ? string.Empty : unityInputSystemDeviceMatchingProperties.deviceName);
								if (!ProductNameMatches(name2))
								{
									continue;
								}
							}
							if (unityInputSystemDeviceMatchingProperties.vendorId.Value == vendorId && unityInputSystemDeviceMatchingProperties.productId.Value == productId)
							{
								return true;
							}
						}
					}
					if (flag8 && ProductNameMatches(name))
					{
						return true;
					}
					if (flag9)
					{
						return false;
					}
					if (flag || flag2)
					{
						return true;
					}
					return false;
				}

				internal bool SupportsPlatform(Rewired.Platforms.Platform platform)
				{
					Rewired.Platforms.Platform currentPlatform = ReInput.currentPlatform;
					if (excludedPlatforms != null)
					{
						for (int i = 0; i < excludedPlatforms.Length; i++)
						{
							if (excludedPlatforms[i] == platform || excludedPlatforms[i] == currentPlatform)
							{
								return false;
							}
						}
					}
					if (platforms == null || platforms.Length == 0)
					{
						return true;
					}
					for (int j = 0; j < platforms.Length; j++)
					{
						if (platforms[j] == platform)
						{
							return true;
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.alternateElementCounts = ArrayTools.ShallowCopy(alternateElementCounts);
						matchingCriteria.platforms = ArrayTools.ShallowCopy(platforms);
						matchingCriteria.excludedPlatforms = ArrayTools.ShallowCopy(excludedPlatforms);
						matchingCriteria.deviceType = deviceType;
						matchingCriteria.tags = ArrayTools.ShallowCopy(tags);
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
					}
				}

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				int Elements_Base.axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public string sourcePath;

				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Button button)
					{
						button.sourcePath = sourcePath;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public string sourcePath;

				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Axis axis)
					{
						axis.sourcePath = sourcePath;
					}
				}
			}

			private sealed class HyFVNnRIGLXtzUhrAgirFbNIUeTOA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int AMuDEOjEeuJtZNGsUVTJiDSPOBcjA;

				private Platform_Custom.Axis mfGCzUIIONdrGAPyRpmZdVOjTUtfA;

				private int TdnqvaYYPDUkjSzzuFHSMTWPQkzR;

				public Platform_UnityInputSystem_Base fkiBMRezWHegIcscBzmHEOyFhbvj;

				private int nappWFyFBJhApXOmznwhZLCcQMdx;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return mfGCzUIIONdrGAPyRpmZdVOjTUtfA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return mfGCzUIIONdrGAPyRpmZdVOjTUtfA;
					}
				}

				[DebuggerHidden]
				public HyFVNnRIGLXtzUhrAgirFbNIUeTOA(int P_0)
				{
					AMuDEOjEeuJtZNGsUVTJiDSPOBcjA = P_0;
					TdnqvaYYPDUkjSzzuFHSMTWPQkzR = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					AMuDEOjEeuJtZNGsUVTJiDSPOBcjA = -2;
				}

				private bool MoveNext()
				{
					int aMuDEOjEeuJtZNGsUVTJiDSPOBcjA = AMuDEOjEeuJtZNGsUVTJiDSPOBcjA;
					Platform_UnityInputSystem_Base platform_UnityInputSystem_Base = fkiBMRezWHegIcscBzmHEOyFhbvj;
					switch (aMuDEOjEeuJtZNGsUVTJiDSPOBcjA)
					{
					default:
						return false;
					case 0:
						AMuDEOjEeuJtZNGsUVTJiDSPOBcjA = -1;
						if (platform_UnityInputSystem_Base.elements == null || platform_UnityInputSystem_Base.elements.axes == null)
						{
							return false;
						}
						nappWFyFBJhApXOmznwhZLCcQMdx = 0;
						break;
					case 1:
						AMuDEOjEeuJtZNGsUVTJiDSPOBcjA = -1;
						nappWFyFBJhApXOmznwhZLCcQMdx++;
						break;
					}
					if (nappWFyFBJhApXOmznwhZLCcQMdx < platform_UnityInputSystem_Base.elements.axes.Length)
					{
						mfGCzUIIONdrGAPyRpmZdVOjTUtfA = platform_UnityInputSystem_Base.elements.axes[nappWFyFBJhApXOmznwhZLCcQMdx];
						AMuDEOjEeuJtZNGsUVTJiDSPOBcjA = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					HyFVNnRIGLXtzUhrAgirFbNIUeTOA hyFVNnRIGLXtzUhrAgirFbNIUeTOA;
					if (AMuDEOjEeuJtZNGsUVTJiDSPOBcjA == -2 && TdnqvaYYPDUkjSzzuFHSMTWPQkzR == Environment.CurrentManagedThreadId)
					{
						AMuDEOjEeuJtZNGsUVTJiDSPOBcjA = 0;
						hyFVNnRIGLXtzUhrAgirFbNIUeTOA = this;
					}
					else
					{
						hyFVNnRIGLXtzUhrAgirFbNIUeTOA = new HyFVNnRIGLXtzUhrAgirFbNIUeTOA(0);
						hyFVNnRIGLXtzUhrAgirFbNIUeTOA.fkiBMRezWHegIcscBzmHEOyFhbvj = fkiBMRezWHegIcscBzmHEOyFhbvj;
					}
					return hyFVNnRIGLXtzUhrAgirFbNIUeTOA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class vyeUOdXLCPoFtgtnPnriztsZiRUy : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int BoTzloznCdCIhtdQoRDwLHSIMQyx;

				private Platform_Custom.Button yXIFgcdjQhPrDvFsjjdLuHZIexOqA;

				private int AXhQJcmqQwZOvWuWjjjnvdMfWiUe;

				public Platform_UnityInputSystem_Base yMslhwGmRCjMjuCRoPkdDhVvKRnd;

				private int uIQGOJHIlaGaULrAdPvJEQZdvLEWB;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return yXIFgcdjQhPrDvFsjjdLuHZIexOqA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return yXIFgcdjQhPrDvFsjjdLuHZIexOqA;
					}
				}

				[DebuggerHidden]
				public vyeUOdXLCPoFtgtnPnriztsZiRUy(int P_0)
				{
					BoTzloznCdCIhtdQoRDwLHSIMQyx = P_0;
					AXhQJcmqQwZOvWuWjjjnvdMfWiUe = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					BoTzloznCdCIhtdQoRDwLHSIMQyx = -2;
				}

				private bool MoveNext()
				{
					int boTzloznCdCIhtdQoRDwLHSIMQyx = BoTzloznCdCIhtdQoRDwLHSIMQyx;
					Platform_UnityInputSystem_Base platform_UnityInputSystem_Base = yMslhwGmRCjMjuCRoPkdDhVvKRnd;
					switch (boTzloznCdCIhtdQoRDwLHSIMQyx)
					{
					default:
						return false;
					case 0:
						BoTzloznCdCIhtdQoRDwLHSIMQyx = -1;
						if (platform_UnityInputSystem_Base.elements == null || platform_UnityInputSystem_Base.elements.buttons == null)
						{
							return false;
						}
						uIQGOJHIlaGaULrAdPvJEQZdvLEWB = 0;
						break;
					case 1:
						BoTzloznCdCIhtdQoRDwLHSIMQyx = -1;
						uIQGOJHIlaGaULrAdPvJEQZdvLEWB++;
						break;
					}
					if (uIQGOJHIlaGaULrAdPvJEQZdvLEWB < platform_UnityInputSystem_Base.elements.buttons.Length)
					{
						yXIFgcdjQhPrDvFsjjdLuHZIexOqA = platform_UnityInputSystem_Base.elements.buttons[uIQGOJHIlaGaULrAdPvJEQZdvLEWB];
						BoTzloznCdCIhtdQoRDwLHSIMQyx = 1;
						return true;
					}
					return false;
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					vyeUOdXLCPoFtgtnPnriztsZiRUy vyeUOdXLCPoFtgtnPnriztsZiRUy2;
					if (BoTzloznCdCIhtdQoRDwLHSIMQyx == -2 && AXhQJcmqQwZOvWuWjjjnvdMfWiUe == Environment.CurrentManagedThreadId)
					{
						BoTzloznCdCIhtdQoRDwLHSIMQyx = 0;
						vyeUOdXLCPoFtgtnPnriztsZiRUy2 = this;
					}
					else
					{
						vyeUOdXLCPoFtgtnPnriztsZiRUy2 = new vyeUOdXLCPoFtgtnPnriztsZiRUy(0);
						vyeUOdXLCPoFtgtnPnriztsZiRUy2.yMslhwGmRCjMjuCRoPkdDhVvKRnd = yMslhwGmRCjMjuCRoPkdDhVvKRnd;
					}
					return vyeUOdXLCPoFtgtnPnriztsZiRUy2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			int Platform.assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			InputPlatform Platform.platform => GetCurrentUnityInputSystemInputPlatform();

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			bool Platform.hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			bool Platform.disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			bool Platform.isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			Elements_Base Platform.elements_base => elements;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			[IteratorStateMachine(typeof(HyFVNnRIGLXtzUhrAgirFbNIUeTOA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new HyFVNnRIGLXtzUhrAgirFbNIUeTOA(-2)
				{
					fkiBMRezWHegIcscBzmHEOyFhbvj = this
				};
			}

			[IteratorStateMachine(typeof(vyeUOdXLCPoFtgtnPnriztsZiRUy))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new vyeUOdXLCPoFtgtnPnriztsZiRUy(-2)
				{
					yMslhwGmRCjMjuCRoPkdDhVvKRnd = this
				};
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (axes_orig[i].calibrateAxis != BoolWithDefault.Default || axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = CalibrateAxisOptionToBool(axes_orig[i].calibrateAxis, axes_orig[i].axisInfo.dataFormat);
						}
						if (axes_orig[i].calibrateAxis == BoolWithDefault.True)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_UnityInputSystem_Base platform_UnityInputSystem_Base = new Platform_UnityInputSystem_Base();
				CopyVars(platform_UnityInputSystem_Base);
				return platform_UnityInputSystem_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_UnityInputSystem_Base platform_UnityInputSystem_Base)
				{
					platform_UnityInputSystem_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_UnityInputSystem_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_UnityInputSystem : Platform_UnityInputSystem_Base
		{
			public Platform_UnityInputSystem_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_UnityInputSystem platform_UnityInputSystem = new Platform_UnityInputSystem();
				CopyVars(platform_UnityInputSystem);
				return platform_UnityInputSystem;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_UnityInputSystem platform_UnityInputSystem)
				{
					platform_UnityInputSystem.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		private sealed class JnmcLFrOaXAXLnNalBURAeMykymo : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
		{
			private int CEgScSNqwPmuHHfLRDdkzxiQXLc;

			private IControllerElementIdentifierCommon_Internal yjQcSmxQJhgNEalAmcBEDEUOaCav;

			private int yqLMBoHmUzFxIxOwTBtfOAopEHMfA;

			public HardwareJoystickMap VbpGJdBHZtGdatJJtJpZasrPPasRA;

			private int kxHdOgCvdTKOtvAUhiljhUxVAjVf;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
			{
				[DebuggerHidden]
				get
				{
					return yjQcSmxQJhgNEalAmcBEDEUOaCav;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return yjQcSmxQJhgNEalAmcBEDEUOaCav;
				}
			}

			[DebuggerHidden]
			public JnmcLFrOaXAXLnNalBURAeMykymo(int P_0)
			{
				CEgScSNqwPmuHHfLRDdkzxiQXLc = P_0;
				yqLMBoHmUzFxIxOwTBtfOAopEHMfA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				CEgScSNqwPmuHHfLRDdkzxiQXLc = -2;
			}

			private bool MoveNext()
			{
				int cEgScSNqwPmuHHfLRDdkzxiQXLc = CEgScSNqwPmuHHfLRDdkzxiQXLc;
				HardwareJoystickMap vbpGJdBHZtGdatJJtJpZasrPPasRA = VbpGJdBHZtGdatJJtJpZasrPPasRA;
				switch (cEgScSNqwPmuHHfLRDdkzxiQXLc)
				{
				default:
					return false;
				case 0:
					CEgScSNqwPmuHHfLRDdkzxiQXLc = -1;
					if (vbpGJdBHZtGdatJJtJpZasrPPasRA.elementIdentifiers == null)
					{
						return false;
					}
					kxHdOgCvdTKOtvAUhiljhUxVAjVf = 0;
					break;
				case 1:
					CEgScSNqwPmuHHfLRDdkzxiQXLc = -1;
					kxHdOgCvdTKOtvAUhiljhUxVAjVf++;
					break;
				}
				if (kxHdOgCvdTKOtvAUhiljhUxVAjVf < vbpGJdBHZtGdatJJtJpZasrPPasRA.elementIdentifiers.Length)
				{
					yjQcSmxQJhgNEalAmcBEDEUOaCav = vbpGJdBHZtGdatJJtJpZasrPPasRA.elementIdentifiers[kxHdOgCvdTKOtvAUhiljhUxVAjVf];
					CEgScSNqwPmuHHfLRDdkzxiQXLc = 1;
					return true;
				}
				return false;
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
			IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
			{
				JnmcLFrOaXAXLnNalBURAeMykymo jnmcLFrOaXAXLnNalBURAeMykymo;
				if (CEgScSNqwPmuHHfLRDdkzxiQXLc == -2 && yqLMBoHmUzFxIxOwTBtfOAopEHMfA == Environment.CurrentManagedThreadId)
				{
					CEgScSNqwPmuHHfLRDdkzxiQXLc = 0;
					jnmcLFrOaXAXLnNalBURAeMykymo = this;
				}
				else
				{
					jnmcLFrOaXAXLnNalBURAeMykymo = new JnmcLFrOaXAXLnNalBURAeMykymo(0);
					jnmcLFrOaXAXLnNalBURAeMykymo.VbpGJdBHZtGdatJJtJpZasrPPasRA = VbpGJdBHZtGdatJJtJpZasrPPasRA;
				}
				return jnmcLFrOaXAXLnNalBURAeMykymo;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}
		}

		private sealed class RrCOhIVvbqPqurVyKrIEAFBZXzDw : IEnumerable<ControllerElementIdentifier>, IEnumerable, IEnumerator<ControllerElementIdentifier>, IEnumerator, IDisposable
		{
			private int dIeREjgErYCjcbUFwrXQguhJQIREA;

			private ControllerElementIdentifier YJaLtiPqRisDgPJCDGWHTkTEXTaN;

			private int PqdphqCExWqImthzkaFOZMMgdOZg;

			public HardwareJoystickMap LUjyDFETOsEAAHsixtbEHTPhnzAd;

			private int BdrbCyLybbbkvfQwePDMRiBjpcDA;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return YJaLtiPqRisDgPJCDGWHTkTEXTaN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return YJaLtiPqRisDgPJCDGWHTkTEXTaN;
				}
			}

			[DebuggerHidden]
			public RrCOhIVvbqPqurVyKrIEAFBZXzDw(int P_0)
			{
				dIeREjgErYCjcbUFwrXQguhJQIREA = P_0;
				PqdphqCExWqImthzkaFOZMMgdOZg = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				dIeREjgErYCjcbUFwrXQguhJQIREA = -2;
			}

			private bool MoveNext()
			{
				int num = dIeREjgErYCjcbUFwrXQguhJQIREA;
				HardwareJoystickMap lUjyDFETOsEAAHsixtbEHTPhnzAd = LUjyDFETOsEAAHsixtbEHTPhnzAd;
				switch (num)
				{
				default:
					return false;
				case 0:
					dIeREjgErYCjcbUFwrXQguhJQIREA = -1;
					if (lUjyDFETOsEAAHsixtbEHTPhnzAd.elementIdentifiers == null)
					{
						return false;
					}
					BdrbCyLybbbkvfQwePDMRiBjpcDA = 0;
					break;
				case 1:
					dIeREjgErYCjcbUFwrXQguhJQIREA = -1;
					BdrbCyLybbbkvfQwePDMRiBjpcDA++;
					break;
				}
				if (BdrbCyLybbbkvfQwePDMRiBjpcDA < lUjyDFETOsEAAHsixtbEHTPhnzAd.elementIdentifiers.Length)
				{
					YJaLtiPqRisDgPJCDGWHTkTEXTaN = lUjyDFETOsEAAHsixtbEHTPhnzAd.elementIdentifiers[BdrbCyLybbbkvfQwePDMRiBjpcDA];
					dIeREjgErYCjcbUFwrXQguhJQIREA = 1;
					return true;
				}
				return false;
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
			IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
			{
				RrCOhIVvbqPqurVyKrIEAFBZXzDw rrCOhIVvbqPqurVyKrIEAFBZXzDw;
				if (dIeREjgErYCjcbUFwrXQguhJQIREA == -2 && PqdphqCExWqImthzkaFOZMMgdOZg == Environment.CurrentManagedThreadId)
				{
					dIeREjgErYCjcbUFwrXQguhJQIREA = 0;
					rrCOhIVvbqPqurVyKrIEAFBZXzDw = this;
				}
				else
				{
					rrCOhIVvbqPqurVyKrIEAFBZXzDw = new RrCOhIVvbqPqurVyKrIEAFBZXzDw(0);
					rrCOhIVvbqPqurVyKrIEAFBZXzDw.LUjyDFETOsEAAHsixtbEHTPhnzAd = LUjyDFETOsEAAHsixtbEHTPhnzAd;
				}
				return rrCOhIVvbqPqurVyKrIEAFBZXzDw;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}
		}

		private sealed class WioFLaYpnmuFtTBNIUYWWxiedaMS : IEnumerable<JoystickType>, IEnumerable, IEnumerator<JoystickType>, IEnumerator, IDisposable
		{
			private int yXUahuepcFPLTUCZWSqGWzIjZLCwA;

			private JoystickType uZIaxGsNpEcIioJuibkdEnpoiQrbb;

			private int ksJehWmgeuTjsnfvWHwNhbHqEBpx;

			public HardwareJoystickMap VXWGOCUenhCOGUbYTBLaGXmqnuIN;

			private int GNKHcFQkiXdWchWyaJwhrYOYHctD;

			JoystickType IEnumerator<JoystickType>.Current
			{
				[DebuggerHidden]
				get
				{
					return uZIaxGsNpEcIioJuibkdEnpoiQrbb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return uZIaxGsNpEcIioJuibkdEnpoiQrbb;
				}
			}

			[DebuggerHidden]
			public WioFLaYpnmuFtTBNIUYWWxiedaMS(int P_0)
			{
				yXUahuepcFPLTUCZWSqGWzIjZLCwA = P_0;
				ksJehWmgeuTjsnfvWHwNhbHqEBpx = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				yXUahuepcFPLTUCZWSqGWzIjZLCwA = -2;
			}

			private bool MoveNext()
			{
				int num = yXUahuepcFPLTUCZWSqGWzIjZLCwA;
				HardwareJoystickMap vXWGOCUenhCOGUbYTBLaGXmqnuIN = VXWGOCUenhCOGUbYTBLaGXmqnuIN;
				switch (num)
				{
				default:
					return false;
				case 0:
					yXUahuepcFPLTUCZWSqGWzIjZLCwA = -1;
					if (vXWGOCUenhCOGUbYTBLaGXmqnuIN.joystickTypes == null)
					{
						return false;
					}
					GNKHcFQkiXdWchWyaJwhrYOYHctD = 0;
					break;
				case 1:
					yXUahuepcFPLTUCZWSqGWzIjZLCwA = -1;
					GNKHcFQkiXdWchWyaJwhrYOYHctD++;
					break;
				}
				if (GNKHcFQkiXdWchWyaJwhrYOYHctD < vXWGOCUenhCOGUbYTBLaGXmqnuIN.joystickTypes.Length)
				{
					uZIaxGsNpEcIioJuibkdEnpoiQrbb = vXWGOCUenhCOGUbYTBLaGXmqnuIN.joystickTypes[GNKHcFQkiXdWchWyaJwhrYOYHctD];
					yXUahuepcFPLTUCZWSqGWzIjZLCwA = 1;
					return true;
				}
				return false;
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
			IEnumerator<JoystickType> IEnumerable<JoystickType>.GetEnumerator()
			{
				WioFLaYpnmuFtTBNIUYWWxiedaMS wioFLaYpnmuFtTBNIUYWWxiedaMS;
				if (yXUahuepcFPLTUCZWSqGWzIjZLCwA == -2 && ksJehWmgeuTjsnfvWHwNhbHqEBpx == Environment.CurrentManagedThreadId)
				{
					yXUahuepcFPLTUCZWSqGWzIjZLCwA = 0;
					wioFLaYpnmuFtTBNIUYWWxiedaMS = this;
				}
				else
				{
					wioFLaYpnmuFtTBNIUYWWxiedaMS = new WioFLaYpnmuFtTBNIUYWWxiedaMS(0);
					wioFLaYpnmuFtTBNIUYWWxiedaMS.VXWGOCUenhCOGUbYTBLaGXmqnuIN = VXWGOCUenhCOGUbYTBLaGXmqnuIN;
				}
				return wioFLaYpnmuFtTBNIUYWWxiedaMS;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JoystickType>)this).GetEnumerator();
			}
		}

		private sealed class cFrEYcSsjisrHzqovUaMaLRyBPIe : IEnumerable<Guid>, IEnumerable, IEnumerator<Guid>, IEnumerator, IDisposable
		{
			private int aZiuLneROYzbXXecsXdlQILthVuw;

			private Guid cJESbZGPdIaMhhLjzQMadrmUxlaRA;

			private int dHNAwrEGhPdLEHUcHKoLIPutgcvBA;

			public HardwareJoystickMap tFkltmMXZJTRyCFNffsqgsSqEhgEA;

			private Guid[] lRqDAEeJrDbMbKgXRFRgahYaSdbxb;

			private int bFkSdYumOYVCarIegZhCcBFraGTk;

			Guid IEnumerator<Guid>.Current
			{
				[DebuggerHidden]
				get
				{
					return cJESbZGPdIaMhhLjzQMadrmUxlaRA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return cJESbZGPdIaMhhLjzQMadrmUxlaRA;
				}
			}

			[DebuggerHidden]
			public cFrEYcSsjisrHzqovUaMaLRyBPIe(int P_0)
			{
				aZiuLneROYzbXXecsXdlQILthVuw = P_0;
				dHNAwrEGhPdLEHUcHKoLIPutgcvBA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				lRqDAEeJrDbMbKgXRFRgahYaSdbxb = null;
				aZiuLneROYzbXXecsXdlQILthVuw = -2;
			}

			private bool MoveNext()
			{
				int num = aZiuLneROYzbXXecsXdlQILthVuw;
				HardwareJoystickMap hardwareJoystickMap = tFkltmMXZJTRyCFNffsqgsSqEhgEA;
				switch (num)
				{
				default:
					return false;
				case 0:
					aZiuLneROYzbXXecsXdlQILthVuw = -1;
					if (ReInput.isReady)
					{
						lRqDAEeJrDbMbKgXRFRgahYaSdbxb = hardwareJoystickMap.runtimeTemplateGuids;
						if (lRqDAEeJrDbMbKgXRFRgahYaSdbxb == null)
						{
							return false;
						}
						bFkSdYumOYVCarIegZhCcBFraGTk = 0;
						goto IL_0086;
					}
					if (hardwareJoystickMap.templateGuids == null)
					{
						return false;
					}
					bFkSdYumOYVCarIegZhCcBFraGTk = 0;
					goto IL_00ea;
				case 1:
					aZiuLneROYzbXXecsXdlQILthVuw = -1;
					bFkSdYumOYVCarIegZhCcBFraGTk++;
					goto IL_0086;
				case 2:
					{
						aZiuLneROYzbXXecsXdlQILthVuw = -1;
						bFkSdYumOYVCarIegZhCcBFraGTk++;
						goto IL_00ea;
					}
					IL_0086:
					if (bFkSdYumOYVCarIegZhCcBFraGTk < lRqDAEeJrDbMbKgXRFRgahYaSdbxb.Length)
					{
						cJESbZGPdIaMhhLjzQMadrmUxlaRA = lRqDAEeJrDbMbKgXRFRgahYaSdbxb[bFkSdYumOYVCarIegZhCcBFraGTk];
						aZiuLneROYzbXXecsXdlQILthVuw = 1;
						return true;
					}
					lRqDAEeJrDbMbKgXRFRgahYaSdbxb = null;
					break;
					IL_00ea:
					if (bFkSdYumOYVCarIegZhCcBFraGTk < hardwareJoystickMap.templateGuids.Length)
					{
						cJESbZGPdIaMhhLjzQMadrmUxlaRA = StringTools.ToGuid(hardwareJoystickMap.templateGuids[bFkSdYumOYVCarIegZhCcBFraGTk]);
						aZiuLneROYzbXXecsXdlQILthVuw = 2;
						return true;
					}
					break;
				}
				return false;
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
			IEnumerator<Guid> IEnumerable<Guid>.GetEnumerator()
			{
				cFrEYcSsjisrHzqovUaMaLRyBPIe cFrEYcSsjisrHzqovUaMaLRyBPIe2;
				if (aZiuLneROYzbXXecsXdlQILthVuw == -2 && dHNAwrEGhPdLEHUcHKoLIPutgcvBA == Environment.CurrentManagedThreadId)
				{
					aZiuLneROYzbXXecsXdlQILthVuw = 0;
					cFrEYcSsjisrHzqovUaMaLRyBPIe2 = this;
				}
				else
				{
					cFrEYcSsjisrHzqovUaMaLRyBPIe2 = new cFrEYcSsjisrHzqovUaMaLRyBPIe(0);
					cFrEYcSsjisrHzqovUaMaLRyBPIe2.tFkltmMXZJTRyCFNffsqgsSqEhgEA = tFkltmMXZJTRyCFNffsqgsSqEhgEA;
				}
				return cFrEYcSsjisrHzqovUaMaLRyBPIe2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Guid>)this).GetEnumerator();
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string editorControllerName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string description;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerGuid;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string[] templateGuids;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool hideInLists;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private JoystickType[] joystickTypes;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerElementIdentifier[] elementIdentifiers;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CompoundElement[] compoundElements;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_DirectInput directInput;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_RawInput rawInput;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_XInput xInput;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_WindowsWGI windowsWGI;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_OSX osx;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Linux linux;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_WindowsUWP windowsUWP;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Windows;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_OSX;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Linux;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Linux_PreConfigured;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Android;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_iOS;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_PS5 ps5;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_AmazonFireTV;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_WebGL webGL;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_XboxOne xboxOne;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_GameCore gameCore;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_PS4 ps4;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_NintendoSwitch nintendoSwitch;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_NintendoSwitch2 nintendoSwitch2;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_InternalDriver internalDriver;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_SDL sdl;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_AppleGCController appleGCController;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_UnityInputSystem unityInputSystem;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int elementIdentifierIdCounter;

		[NonSerialized]
		private Guid? __runtimeControllerGuidCache;

		[NonSerialized]
		private Guid[] __runtimeTemplateGuidCache;

		private Guid runtimeControllerGuid
		{
			get
			{
				if (!__runtimeControllerGuidCache.HasValue || !__runtimeControllerGuidCache.HasValue)
				{
					__runtimeControllerGuidCache = StringTools.ToGuid(controllerGuid);
				}
				return __runtimeControllerGuidCache.Value;
			}
		}

		private Guid[] runtimeTemplateGuids
		{
			get
			{
				if (__runtimeTemplateGuidCache == null && templateGuids != null)
				{
					__runtimeTemplateGuidCache = new Guid[templateGuids.Length];
					for (int i = 0; i < templateGuids.Length; i++)
					{
						__runtimeTemplateGuidCache[i] = StringTools.ToGuid(templateGuids[i]);
					}
				}
				return __runtimeTemplateGuidCache;
			}
		}

		public string ControllerName => controllerName;

		public string EditorControllerName => editorControllerName;

		public Guid Guid
		{
			get
			{
				if (!ReInput.isReady)
				{
					return StringTools.ToGuid(controllerGuid);
				}
				return runtimeControllerGuid;
			}
		}

		public string Key => controllerKey;

		public IEnumerable<Guid> TemplateGuids
		{
			[IteratorStateMachine(typeof(cFrEYcSsjisrHzqovUaMaLRyBPIe))]
			get
			{
				return new cFrEYcSsjisrHzqovUaMaLRyBPIe(-2)
				{
					tFkltmMXZJTRyCFNffsqgsSqEhgEA = this
				};
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			[IteratorStateMachine(typeof(RrCOhIVvbqPqurVyKrIEAFBZXzDw))]
			get
			{
				return new RrCOhIVvbqPqurVyKrIEAFBZXzDw(-2)
				{
					LUjyDFETOsEAAHsixtbEHTPhnzAd = this
				};
			}
		}

		public int elementIdentifierCount
		{
			get
			{
				if (elementIdentifiers == null)
				{
					return 0;
				}
				return elementIdentifiers.Length;
			}
		}

		public bool HideInLists => hideInLists;

		internal IEnumerable<JoystickType> JoystickTypes
		{
			[IteratorStateMachine(typeof(WioFLaYpnmuFtTBNIUYWWxiedaMS))]
			get
			{
				return new WioFLaYpnmuFtTBNIUYWWxiedaMS(-2)
				{
					VXWGOCUenhCOGUbYTBLaGXmqnuIN = this
				};
			}
		}

		Guid IHardwareControllerMap_Internal.typeGuid => Guid;

		string IHardwareControllerMap_Internal.typeKey => controllerKey;

		ControllerType IHardwareControllerMap_Internal.controllerType => ControllerType.Joystick;

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			[IteratorStateMachine(typeof(JnmcLFrOaXAXLnNalBURAeMykymo))]
			get
			{
				return new JnmcLFrOaXAXLnNalBURAeMykymo(-2)
				{
					VbpGJdBHZtGdatJJtJpZasrPPasRA = this
				};
			}
		}

		string IHardwareControllerMap_Internal.name => base.name;

		public HardwareJoystickMap()
		{
			if (joystickTypes == null || joystickTypes.Length == 0)
			{
				joystickTypes = new JoystickType[1];
			}
			if (directInput == null)
			{
				directInput = new Platform_DirectInput();
			}
			if (rawInput == null)
			{
				rawInput = new Platform_RawInput();
			}
			if (xInput == null)
			{
				xInput = new Platform_XInput();
			}
			if (windowsWGI == null)
			{
				windowsWGI = new Platform_WindowsWGI();
			}
			if (osx == null)
			{
				osx = new Platform_OSX();
			}
			if (appleGCController == null)
			{
				appleGCController = new Platform_AppleGCController();
			}
			if (linux == null)
			{
				linux = new Platform_Linux();
			}
			if (windowsUWP == null)
			{
				windowsUWP = new Platform_WindowsUWP();
			}
			if (fallback_Android == null)
			{
				fallback_Android = new Platform_Fallback();
			}
			if (fallback_iOS == null)
			{
				fallback_iOS = new Platform_Fallback();
			}
			if (fallback_Linux == null)
			{
				fallback_Linux = new Platform_Fallback();
			}
			if (fallback_Linux_PreConfigured == null)
			{
				fallback_Linux_PreConfigured = new Platform_Fallback();
			}
			if (fallback_OSX == null)
			{
				fallback_OSX = new Platform_Fallback();
			}
			if (fallback_Windows == null)
			{
				fallback_Windows = new Platform_Fallback();
			}
			if (fallback_AmazonFireTV == null)
			{
				fallback_AmazonFireTV = new Platform_Fallback();
			}
			if (unityInputSystem == null)
			{
				unityInputSystem = new Platform_UnityInputSystem();
			}
			if (webGL == null)
			{
				webGL = new Platform_WebGL();
			}
			if (xboxOne == null)
			{
				xboxOne = new Platform_XboxOne();
			}
			if (gameCore == null)
			{
				gameCore = new Platform_GameCore();
			}
			if (ps4 == null)
			{
				ps4 = new Platform_PS4();
			}
			if (ps5 == null)
			{
				ps5 = new Platform_PS5();
			}
			if (nintendoSwitch == null)
			{
				nintendoSwitch = new Platform_NintendoSwitch();
			}
			if (nintendoSwitch2 == null)
			{
				nintendoSwitch2 = new Platform_NintendoSwitch2();
			}
			if (internalDriver == null)
			{
				internalDriver = new Platform_InternalDriver();
			}
			if (sdl == null)
			{
				sdl = new Platform_SDL();
			}
		}

		public HardwareJoystickMap(HardwareJoystickMap P_0)
			: this()
		{
			controllerGuid = P_0.controllerGuid;
			if (P_0.templateGuids != null)
			{
				int num = P_0.templateGuids.Length;
				templateGuids = new string[num];
				for (int i = 0; i < num; i++)
				{
					templateGuids[i] = templateGuids[i];
				}
			}
			if (P_0.elementIdentifiers != null)
			{
				int num2 = P_0.elementIdentifiers.Length;
				elementIdentifiers = new ControllerElementIdentifier[num2];
				for (int j = 0; j < num2; j++)
				{
					elementIdentifiers[j] = elementIdentifiers[j].Clone();
				}
			}
			elementIdentifierIdCounter = P_0.elementIdentifierIdCounter;
			if (P_0.compoundElements != null)
			{
				int num3 = P_0.compoundElements.Length;
				compoundElements = new CompoundElement[num3];
				for (int k = 0; k < num3; k++)
				{
					compoundElements[k] = P_0.compoundElements[k].DeepClone() as CompoundElement;
				}
			}
			joystickTypes = ArrayTools.ShallowCopy(P_0.joystickTypes);
			if (P_0.directInput != null)
			{
				directInput = MiscTools.DeepClone(P_0.directInput);
			}
			if (P_0.rawInput != null)
			{
				rawInput = MiscTools.DeepClone(rawInput);
			}
			if (P_0.xInput != null)
			{
				xInput = MiscTools.DeepClone(P_0.xInput);
			}
			if (P_0.windowsWGI != null)
			{
				windowsWGI = MiscTools.DeepClone(P_0.windowsWGI);
			}
			if (P_0.osx != null)
			{
				osx = MiscTools.DeepClone(P_0.osx);
			}
			if (P_0.appleGCController != null)
			{
				appleGCController = MiscTools.DeepClone(P_0.appleGCController);
			}
			if (P_0.linux != null)
			{
				linux = MiscTools.DeepClone(P_0.linux);
			}
			if (P_0.windowsUWP != null)
			{
				windowsUWP = MiscTools.DeepClone(P_0.windowsUWP);
			}
			if (P_0.fallback_Windows != null)
			{
				fallback_Windows = MiscTools.DeepClone(fallback_Windows);
			}
			if (P_0.fallback_OSX != null)
			{
				fallback_OSX = MiscTools.DeepClone(fallback_OSX);
			}
			if (P_0.fallback_Android != null)
			{
				fallback_Android = MiscTools.DeepClone(fallback_Android);
			}
			if (P_0.fallback_iOS != null)
			{
				fallback_iOS = MiscTools.DeepClone(fallback_iOS);
			}
			if (P_0.fallback_Linux != null)
			{
				fallback_Linux = MiscTools.DeepClone(fallback_Linux);
			}
			if (P_0.fallback_Linux_PreConfigured != null)
			{
				fallback_Linux_PreConfigured = MiscTools.DeepClone(fallback_Linux_PreConfigured);
			}
			if (P_0.nintendoSwitch != null)
			{
				nintendoSwitch = MiscTools.DeepClone(P_0.nintendoSwitch);
			}
			if (P_0.nintendoSwitch2 != null)
			{
				nintendoSwitch2 = MiscTools.DeepClone(P_0.nintendoSwitch2);
			}
			if (P_0.fallback_AmazonFireTV != null)
			{
				fallback_AmazonFireTV = MiscTools.DeepClone(fallback_AmazonFireTV);
			}
			if (P_0.unityInputSystem != null)
			{
				unityInputSystem = MiscTools.DeepClone(unityInputSystem);
			}
			if (P_0.webGL != null)
			{
				webGL = MiscTools.DeepClone(P_0.webGL);
			}
			if (P_0.xboxOne != null)
			{
				xboxOne = MiscTools.DeepClone(P_0.xboxOne);
			}
			if (P_0.gameCore != null)
			{
				gameCore = MiscTools.DeepClone(P_0.gameCore);
			}
			if (P_0.ps4 != null)
			{
				ps4 = MiscTools.DeepClone(P_0.ps4);
			}
			if (P_0.ps5 != null)
			{
				ps5 = MiscTools.DeepClone(P_0.ps5);
			}
			if (P_0.internalDriver != null)
			{
				internalDriver = MiscTools.DeepClone(P_0.internalDriver);
			}
			if (P_0.sdl != null)
			{
				sdl = MiscTools.DeepClone(P_0.sdl);
			}
		}

		public int GetTemplateGuids(IList<Guid> results)
		{
			int num = 0;
			if (ReInput.isReady)
			{
				Guid[] array = runtimeTemplateGuids;
				if (array == null)
				{
					return 0;
				}
				int num2 = array.Length;
				for (int i = 0; i < num2; i++)
				{
					results.Add(array[i]);
					num++;
				}
			}
			else
			{
				if (templateGuids == null)
				{
					return 0;
				}
				for (int j = 0; j < templateGuids.Length; j++)
				{
					results.Add(StringTools.ToGuid(templateGuids[j]));
					num++;
				}
			}
			return num;
		}

		public bool ContainsTemplateGuid(Guid guid)
		{
			if (ReInput.isReady)
			{
				Guid[] array = runtimeTemplateGuids;
				if (array == null)
				{
					return false;
				}
				int num = array.Length;
				for (int i = 0; i < num; i++)
				{
					if (guid == array[i])
					{
						return true;
					}
				}
			}
			else
			{
				if (templateGuids == null)
				{
					return false;
				}
				for (int j = 0; j < templateGuids.Length; j++)
				{
					if (guid == StringTools.ToGuid(templateGuids[j]))
					{
						return true;
					}
				}
			}
			return false;
		}

		[CustomObfuscation(rename = false)]
		public string[] GetElementIdentifierNames()
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				return null;
			}
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = elementIdentifiers[i].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename;
			}
			return array;
		}

		string[] IHardwareControllerMap.GetElementIdentifierNames()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetElementIdentifierNames
			return this.GetElementIdentifierNames();
		}

		[CustomObfuscation(rename = false)]
		public int[] GetElementIdentifierIds()
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				return null;
			}
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = elementIdentifiers[i].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid;
			}
			return array;
		}

		int[] IHardwareControllerMap.GetElementIdentifierIds()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetElementIdentifierIds
			return this.GetElementIdentifierIds();
		}

		[CustomObfuscation(rename = false)]
		public ControllerElementIdentifier GetElementIdentifier(int id)
		{
			int num = IndexOfElementIdentifier(id);
			if (num < 0 || num >= elementIdentifiers.Length)
			{
				return null;
			}
			return elementIdentifiers[num];
		}

		[CustomObfuscation(rename = false)]
		public ControllerElementIdentifier GetElementIdentifierAtIndex(int index)
		{
			if (index < 0 || index >= elementIdentifiers.Length)
			{
				return null;
			}
			return elementIdentifiers[index];
		}

		[CustomObfuscation(rename = false)]
		public bool ContainsElementIdentifier(int id)
		{
			return IndexOfElementIdentifier(id) >= 0;
		}

		bool IHardwareControllerMap.ContainsElementIdentifier(int id)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ContainsElementIdentifier
			return this.ContainsElementIdentifier(id);
		}

		[CustomObfuscation(rename = false)]
		public int GetElementIdentifierInfo(ControllerElementType type, out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				return 0;
			}
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
			for (int i = 0; i < num; i++)
			{
				if (elementIdentifiers[i] != null && elementIdentifiers[i].elementType == type)
				{
					list.Add(elementIdentifiers[i]);
				}
			}
			int count = list.Count;
			if (count == 0)
			{
				return 0;
			}
			names = new string[count];
			ids = new int[count];
			for (int j = 0; j < count; j++)
			{
				names[j] = list[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename;
				ids[j] = list[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid;
			}
			return count;
		}

		[CustomObfuscation(rename = false)]
		public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				return 0;
			}
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
			for (int i = 0; i < num; i++)
			{
				if (elementIdentifiers[i] != null && InputTools.IsMappableType(elementIdentifiers[i].elementType))
				{
					list.Add(elementIdentifiers[i]);
				}
			}
			int count = list.Count;
			if (count == 0)
			{
				return 0;
			}
			names = new string[count];
			ids = new int[count];
			for (int j = 0; j < count; j++)
			{
				names[j] = list[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename;
				ids[j] = list[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid;
			}
			return count;
		}

		int IHardwareControllerMap.GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetMappableElementIdentifierInfo
			return this.GetMappableElementIdentifierInfo(out names, out ids);
		}

		internal HardwareJoystickMap Clone()
		{
			return new HardwareJoystickMap(this);
		}

		internal int IndexOfElementIdentifier(int id)
		{
			if (elementIdentifiers == null)
			{
				return -1;
			}
			for (int i = 0; i < elementIdentifiers.Length; i++)
			{
				if (elementIdentifiers[i].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid == id)
				{
					return i;
				}
			}
			return -1;
		}

		internal ControllerElementType GetEffectiveElementIdentifierType(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap)
		{
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				return ControllerElementType.Axis;
			}
			return GetSpecificPlatformMap(hardwareMapIdentifier)?.GetEffectiveElementIdentifierType(elementIdentifier) ?? ControllerElementType.Axis;
		}

		internal bool GetEffectiveAxisRange(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap, out AxisRange axisRange)
		{
			axisRange = AxisRange.Full;
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				return false;
			}
			return GetSpecificPlatformMap(hardwareMapIdentifier)?.GetEffectiveAxisRange(elementIdentifier, out axisRange) ?? false;
		}

		internal void GetElementIdentifiersForControllerElements(HardwareControllerMapIdentifier hardwareMapIdentifier, bool isDefaultMap, out int[] buttons, out int[] axes)
		{
			buttons = null;
			axes = null;
			Platform specificPlatformMap = GetSpecificPlatformMap(hardwareMapIdentifier);
			if (specificPlatformMap != null && specificPlatformMap.assignedButtonCount > 0)
			{
				specificPlatformMap.GetGameElementIdentifierIdMappings(out buttons, out axes);
			}
		}

		internal static bool Matches(Platform platform, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (platform == null)
			{
				variantIndex = -1;
				platformMap = null;
				return false;
			}
			return platform.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		}

		internal bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex, out Platform platformMap)
		{
			actualInputPlatform = InputPlatform.Unknown;
			variantIndex = -1;
			platformMap = null;
			if (bridgedControllerHWInfo == null)
			{
				return false;
			}
			switch (bridgedControllerHWInfo.inputSource)
			{
			case InputSource.DirectInput:
				if (Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.WindowsDirectInput;
					return true;
				}
				if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.WindowsRawInput;
					return true;
				}
				return false;
			case InputSource.RawInput:
				if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.WindowsRawInput;
					return true;
				}
				if (Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.WindowsDirectInput;
					return true;
				}
				return false;
			case InputSource.XInput:
				if (xInput == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.WindowsXInput;
				return xInput.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.WindowsGamingInput:
				if (windowsWGI == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.WindowsWGI;
				return windowsWGI.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.OSX:
				if (osx == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.OSXNative;
				return osx.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.AppleGameController:
			{
				Platform_AppleGCController platform_AppleGCController = appleGCController;
				if (platform_AppleGCController == null)
				{
					return false;
				}
				actualInputPlatform = GetCurrentAppleGCControllerInputPlatform(out var platform2);
				bridgedControllerHWInfo.workingPlatform = platform2;
				return platform_AppleGCController.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			}
			case InputSource.Linux:
				if (linux == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.LinuxNative;
				return linux.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.WindowsUWP:
				if (windowsUWP == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.WindowsUWP;
				return windowsUWP.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.Fallback:
			case InputSource.Fallback_PreConfigured:
				platformMap = FindFallbackMatch(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
				return platformMap != null;
			case InputSource.UnityInputSystem:
			{
				Platform_UnityInputSystem platform_UnityInputSystem = unityInputSystem;
				if (platform_UnityInputSystem == null)
				{
					return false;
				}
				actualInputPlatform = GetCurrentUnityInputSystemInputPlatform(out var platform3);
				bridgedControllerHWInfo.workingPlatform = platform3;
				bool flag = platform_UnityInputSystem.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
				if (!flag && UnityTools.isAndroidPlatform && UnityTools.platform != Rewired.Platforms.Platform.Android)
				{
					actualInputPlatform = InputPlatform.AndroidUnityInputSystem;
					bridgedControllerHWInfo.workingPlatform = Rewired.Platforms.Platform.Android;
					flag = platform_UnityInputSystem.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
				}
				return flag;
			}
			case InputSource.WebGL:
				if (webGL == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.WebGL;
				return webGL.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.XboxOne:
				if (xboxOne == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.XboxOne;
				return xboxOne.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.GameCoreXboxOne:
			case InputSource.GameCoreScarlett:
				if (gameCore == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.GameCore;
				return gameCore.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.PS4:
				if (ps4 == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.PS4;
				return ps4.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.PS5:
				if (ps5 == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.PS5;
				return ps5.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.NintendoSwitch:
				if (nintendoSwitch == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.NintendoSwitch;
				return nintendoSwitch.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.NintendoSwitch2:
				if (nintendoSwitch2 == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.NintendoSwitch2;
				return nintendoSwitch2.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.InternalDriver:
				if (internalDriver == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.InternalDriver;
				return internalDriver.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.SDL2:
			case InputSource.SDL3:
			{
				Platform_SDL platform_SDL = sdl;
				if (platform_SDL == null)
				{
					return false;
				}
				actualInputPlatform = GetCurrentSDLInputPlatform(out var platform, bridgedControllerHWInfo.inputSource switch
				{
					InputSource.SDL2 => 2, 
					InputSource.SDL3 => 3, 
					_ => throw new NotImplementedException(), 
				});
				bridgedControllerHWInfo.workingPlatform = platform;
				return platform_SDL.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			}
			case InputSource.Steam:
				actualInputPlatform = InputPlatform.Steam;
				return false;
			case InputSource.Custom:
				if (!XKZBcbGtoHHVfKdsghmQDHfhSpIfA.uiJzvtjjXxeMafDzRvVcrucZLjqaA)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.Custom;
				platformMap = XKZBcbGtoHHVfKdsghmQDHfhSpIfA.SwAlnjjHJrFDtTkaIMvdIjFIphik().GetPlatformMap(XKZBcbGtoHHVfKdsghmQDHfhSpIfA.sxzxGgFFdLpgJcYxojKdunKbzLov, Guid);
				if (platformMap != null)
				{
					return platformMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
				}
				return false;
			default:
				throw new NotImplementedException();
			}
		}

		internal HardwareJoystickMap_InputManager GetDefaultHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			InputSource inputSource = bridgedController.inputSource;
			InputPlatform actualInputPlatform;
			Platform platform;
			switch (inputSource)
			{
			case InputSource.DirectInput:
				actualInputPlatform = InputPlatform.WindowsDirectInput;
				platform = directInput;
				break;
			case InputSource.RawInput:
				actualInputPlatform = InputPlatform.WindowsRawInput;
				platform = rawInput;
				break;
			case InputSource.XInput:
				actualInputPlatform = InputPlatform.WindowsXInput;
				platform = xInput;
				break;
			case InputSource.WindowsGamingInput:
				actualInputPlatform = InputPlatform.WindowsWGI;
				platform = windowsWGI;
				break;
			case InputSource.OSX:
				actualInputPlatform = InputPlatform.OSXNative;
				platform = osx;
				break;
			case InputSource.AppleGameController:
				actualInputPlatform = GetCurrentAppleGCControllerInputPlatform();
				platform = appleGCController;
				break;
			case InputSource.Linux:
				actualInputPlatform = InputPlatform.LinuxNative;
				platform = linux;
				break;
			case InputSource.WindowsUWP:
				actualInputPlatform = InputPlatform.WindowsUWP;
				platform = windowsUWP;
				break;
			case InputSource.Fallback:
			case InputSource.Fallback_PreConfigured:
			{
				platform = FindFallbackMap(inputSource, isDefaultMap: true, out actualInputPlatform, out var _);
				break;
			}
			case InputSource.UnityInputSystem:
				actualInputPlatform = GetCurrentUnityInputSystemInputPlatform();
				platform = unityInputSystem;
				break;
			case InputSource.WebGL:
				actualInputPlatform = InputPlatform.WebGL;
				platform = webGL;
				break;
			case InputSource.XboxOne:
				actualInputPlatform = InputPlatform.XboxOne;
				platform = xboxOne;
				break;
			case InputSource.GameCoreXboxOne:
			case InputSource.GameCoreScarlett:
				actualInputPlatform = InputPlatform.GameCore;
				platform = gameCore;
				if (!gameCore.hasData)
				{
					platform = Platform_GameCore.CreateDefaultMap(bridgedController);
				}
				break;
			case InputSource.PS4:
				actualInputPlatform = InputPlatform.PS4;
				platform = ps4;
				break;
			case InputSource.PS5:
				actualInputPlatform = InputPlatform.PS5;
				platform = ps5;
				break;
			case InputSource.NintendoSwitch:
				actualInputPlatform = InputPlatform.NintendoSwitch;
				platform = nintendoSwitch;
				break;
			case InputSource.NintendoSwitch2:
				actualInputPlatform = InputPlatform.NintendoSwitch2;
				platform = nintendoSwitch2;
				break;
			case InputSource.InternalDriver:
				actualInputPlatform = InputPlatform.InternalDriver;
				platform = internalDriver;
				break;
			case InputSource.SDL2:
				actualInputPlatform = GetCurrentSDLInputPlatform(2);
				platform = sdl;
				break;
			case InputSource.SDL3:
				actualInputPlatform = GetCurrentSDLInputPlatform(3);
				platform = sdl;
				break;
			case InputSource.Custom:
				if (!XKZBcbGtoHHVfKdsghmQDHfhSpIfA.uiJzvtjjXxeMafDzRvVcrucZLjqaA)
				{
					return null;
				}
				actualInputPlatform = InputPlatform.Custom;
				platform = XKZBcbGtoHHVfKdsghmQDHfhSpIfA.SwAlnjjHJrFDtTkaIMvdIjFIphik().GetPlatformMap(XKZBcbGtoHHVfKdsghmQDHfhSpIfA.sxzxGgFFdLpgJcYxojKdunKbzLov, Guid);
				break;
			case InputSource.None:
				return null;
			case InputSource.Steam:
			case InputSource.UnityKeyboardAndMouse:
				throw new NotImplementedException();
			default:
				throw new NotImplementedException();
			}
			return platform?.ToHardwareJoystickMap_InputManager(this, inputSource, actualInputPlatform, -1);
		}

		internal string[] GetTemplateGuidsOrig()
		{
			return templateGuids;
		}

		IControllerElementIdentifierCommon_Internal IHardwareControllerMap_Internal.GetElementIdentifier(int id)
		{
			return GetElementIdentifier(id);
		}

		private Platform_Fallback_Base FindFallbackMatch(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			InputSource inputSource = bridgedControllerHWInfo.inputSource;
			Rewired.Platforms.Platform platform = UnityTools.platform;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			}
			switch (platform)
			{
			case Rewired.Platforms.Platform.Windows:
			case Rewired.Platforms.Platform.WindowsAppStore:
			{
				Platform_Fallback_Base mainMap = fallback_Windows;
				actualInputPlatform = InputPlatform.WindowsFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.OSX:
			{
				Platform_Fallback_Base mainMap = fallback_OSX;
				actualInputPlatform = InputPlatform.OSXFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Linux:
			{
				Platform_Fallback_Base mainMap;
				if (inputSource == InputSource.Fallback_PreConfigured)
				{
					mainMap = fallback_Linux_PreConfigured;
					actualInputPlatform = InputPlatform.LinuxFallback_PreConfigured;
					mainMap = TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.LinuxFallback_PreConfigured)
					{
						mainMap = null;
					}
					if (mainMap != null)
					{
						return mainMap;
					}
				}
				mainMap = fallback_Linux;
				actualInputPlatform = InputPlatform.LinuxFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Android:
			{
				Platform_Fallback_Base mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.AndroidFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.iOS:
			case Rewired.Platforms.Platform.tvOS:
			{
				Platform_Fallback_Base mainMap = fallback_iOS;
				actualInputPlatform = InputPlatform.iOSFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.AmazonFireTV:
			{
				Platform_Fallback_Base mainMap = fallback_AmazonFireTV;
				actualInputPlatform = InputPlatform.AmazonFireTVFallback;
				mainMap = TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.AmazonFireTVFallback)
				{
					mainMap = null;
				}
				if (mainMap != null)
				{
					return mainMap;
				}
				mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.AndroidFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Webplayer:
				if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
				{
					Platform_Fallback_Base mainMap = fallback_Windows;
					actualInputPlatform = InputPlatform.WindowsFallback;
					return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
				{
					Platform_Fallback_Base mainMap = fallback_OSX;
					actualInputPlatform = InputPlatform.OSXFallback;
					return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				break;
			}
			if (isDefaultMap)
			{
				return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
			}
			variantIndex = -1;
			actualInputPlatform = InputPlatform.Unknown;
			return null;
		}

		private Platform_Fallback_Base FindFallbackMap(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			}
			switch (platform)
			{
			case Rewired.Platforms.Platform.Windows:
			case Rewired.Platforms.Platform.WindowsAppStore:
			{
				Platform_Fallback_Base mainMap = fallback_Windows;
				actualInputPlatform = InputPlatform.WindowsFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.OSX:
			{
				Platform_Fallback_Base mainMap = fallback_OSX;
				actualInputPlatform = InputPlatform.OSXFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Linux:
			{
				Platform_Fallback_Base mainMap;
				if (inputSource == InputSource.Fallback_PreConfigured)
				{
					mainMap = fallback_Linux_PreConfigured;
					actualInputPlatform = InputPlatform.LinuxFallback_PreConfigured;
					mainMap = TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.LinuxFallback_PreConfigured)
					{
						mainMap = null;
					}
					if (mainMap != null)
					{
						return mainMap;
					}
				}
				mainMap = fallback_Linux;
				actualInputPlatform = InputPlatform.LinuxFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Android:
			{
				Platform_Fallback_Base mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.AndroidFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.iOS:
			case Rewired.Platforms.Platform.tvOS:
			{
				Platform_Fallback_Base mainMap = fallback_iOS;
				actualInputPlatform = InputPlatform.iOSFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.AmazonFireTV:
			{
				Platform_Fallback_Base mainMap = fallback_AmazonFireTV;
				actualInputPlatform = InputPlatform.AmazonFireTVFallback;
				mainMap = TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.AmazonFireTVFallback)
				{
					mainMap = null;
				}
				if (mainMap != null)
				{
					return mainMap;
				}
				mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.AndroidFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Webplayer:
				if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
				{
					Platform_Fallback_Base mainMap = fallback_Windows;
					actualInputPlatform = InputPlatform.WindowsFallback;
					return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
				{
					Platform_Fallback_Base mainMap = fallback_OSX;
					actualInputPlatform = InputPlatform.OSXFallback;
					return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				break;
			}
			if (isDefaultMap)
			{
				return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
			}
			variantIndex = -1;
			actualInputPlatform = InputPlatform.Unknown;
			return null;
		}

		private static InputPlatform GetCurrentUnityInputSystemInputPlatform()
		{
			Rewired.Platforms.Platform platform;
			return GetCurrentUnityInputSystemInputPlatform(out platform);
		}

		private static InputPlatform GetCurrentUnityInputSystemInputPlatform(out Rewired.Platforms.Platform platform)
		{
			platform = UnityTools.platform;
			bool flag = false;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			default:
				flag = UnityTools.isAndroidPlatform;
				break;
			}
			switch (platform)
			{
			case Rewired.Platforms.Platform.Windows:
				return InputPlatform.WindowsUnityInputSystem;
			case Rewired.Platforms.Platform.OSX:
				return InputPlatform.OSXUnityInputSystem;
			case Rewired.Platforms.Platform.Linux:
				return InputPlatform.LinuxUnityInputSystem;
			case Rewired.Platforms.Platform.WindowsUWP:
				return InputPlatform.WindowsUWPUnityInputSystem;
			case Rewired.Platforms.Platform.iOS:
				return InputPlatform.iOSUnityInputSystem;
			case Rewired.Platforms.Platform.tvOS:
				return InputPlatform.tvOSUnityInputSystem;
			case Rewired.Platforms.Platform.VisionOS:
				return InputPlatform.VisionOSUnityInputSystem;
			case Rewired.Platforms.Platform.PS4:
				return InputPlatform.PS4UnityInputSystem;
			case Rewired.Platforms.Platform.PS5:
				return InputPlatform.PS5UnityInputSystem;
			case Rewired.Platforms.Platform.AmazonFireTV:
				return InputPlatform.AmazonFireTVUnityInputSystem;
			default:
				if (flag)
				{
					return InputPlatform.AndroidUnityInputSystem;
				}
				return InputPlatform.Unknown;
			}
		}

		private static InputPlatform GetCurrentSDLInputPlatform(byte sdlVersion)
		{
			Rewired.Platforms.Platform platform;
			return GetCurrentSDLInputPlatform(out platform, sdlVersion);
		}

		private static InputPlatform GetCurrentSDLInputPlatform(out Rewired.Platforms.Platform platform, byte sdlVersion)
		{
			platform = UnityTools.platform;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			default:
				_ = UnityTools.isAndroidPlatform;
				break;
			}
			return platform switch
			{
				Rewired.Platforms.Platform.Windows => sdlVersion switch
				{
					2 => InputPlatform.WindowsSDL2, 
					3 => InputPlatform.WindowsSDL3, 
					_ => throw new NotImplementedException(), 
				}, 
				Rewired.Platforms.Platform.OSX => sdlVersion switch
				{
					2 => InputPlatform.OSXSDL2, 
					3 => InputPlatform.OSXSDL3, 
					_ => throw new NotImplementedException(), 
				}, 
				Rewired.Platforms.Platform.Linux => sdlVersion switch
				{
					2 => InputPlatform.LinuxSDL2, 
					3 => InputPlatform.LinuxSDL3, 
					_ => throw new NotImplementedException(), 
				}, 
				_ => InputPlatform.Unknown, 
			};
		}

		private static InputPlatform GetCurrentAppleGCControllerInputPlatform()
		{
			Rewired.Platforms.Platform platform;
			return GetCurrentAppleGCControllerInputPlatform(out platform);
		}

		private static InputPlatform GetCurrentAppleGCControllerInputPlatform(out Rewired.Platforms.Platform platform)
		{
			platform = UnityTools.platform;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			}
			return platform switch
			{
				Rewired.Platforms.Platform.OSX => InputPlatform.OSXAppleGameController, 
				Rewired.Platforms.Platform.iOS => InputPlatform.iOSAppleGameController, 
				Rewired.Platforms.Platform.tvOS => InputPlatform.tvOSAppleGameController, 
				Rewired.Platforms.Platform.VisionOS => InputPlatform.VisionOSAppleGameController, 
				_ => InputPlatform.Unknown, 
			};
		}

		private T TryGetFirstValidMap<T>(T mainMap, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			if (isDefaultMap)
			{
				if (mainMap == null || !mainMap.selfOrVariantIsAllowed)
				{
					return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
				}
				if (mainMap.isAllowed)
				{
					variantIndex = -1;
					return mainMap;
				}
				IList<Platform> variants = mainMap.GetVariants();
				if (variants != null)
				{
					for (int i = 0; i < variants.Count; i++)
					{
						Platform platform = variants[i];
						if (platform != null && platform.isAllowed)
						{
							variantIndex = i;
							return platform as T;
						}
					}
				}
				return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
			}
			if (mainMap == null || !mainMap.selfOrVariantIsValid)
			{
				variantIndex = -1;
				return null;
			}
			return mainMap.GetFirstValidPlatformMap(out variantIndex) as T;
		}

		private T TryGetFirstMatchingMap<T>(T mainMap, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			Platform platformMap;
			if (isDefaultMap)
			{
				if (mainMap == null)
				{
					return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
				}
				if (mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return platformMap as T;
				}
				return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
			}
			if (mainMap == null)
			{
				variantIndex = -1;
				return null;
			}
			if (mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return platformMap as T;
			}
			variantIndex = -1;
			return null;
		}

		private T GetUniversalDefaultMap<T>(out InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			T universalDefaultMapRoot = GetUniversalDefaultMapRoot<T>(typeof(T), out actualInputPlatform);
			actualInputPlatform = InputPlatform.WindowsFallback;
			variantIndex = -1;
			if (universalDefaultMapRoot == null || !universalDefaultMapRoot.selfOrVariantIsAllowed)
			{
				return null;
			}
			if (universalDefaultMapRoot.isAllowed)
			{
				return universalDefaultMapRoot;
			}
			IList<Platform> variants = universalDefaultMapRoot.GetVariants();
			if (variants != null)
			{
				for (int i = 0; i < variants.Count; i++)
				{
					if (variants[i] != null && variants[i].isAllowed)
					{
						variantIndex = i;
						return variants[i] as T;
					}
				}
			}
			return null;
		}

		private T GetUniversalDefaultMapRoot<T>(Type type, out InputPlatform actualInputPlatform) where T : Platform
		{
			if ((object)type == typeof(Platform_Fallback_Base))
			{
				actualInputPlatform = InputPlatform.WindowsFallback;
				return fallback_Windows as T;
			}
			throw new NotImplementedException();
		}

		private Platform GetSpecificPlatformMap(HardwareControllerMapIdentifier hardwareMapIdentifier)
		{
			return GetSpecificPlatformRoot(hardwareMapIdentifier.actualInputPlatform)?.GetPlatformMap(hardwareMapIdentifier.variantIndex);
		}

		private Platform GetSpecificPlatformRoot(InputPlatform exactInputPlatform)
		{
			switch (exactInputPlatform)
			{
			case InputPlatform.WindowsDirectInput:
				return directInput;
			case InputPlatform.WindowsRawInput:
				return rawInput;
			case InputPlatform.WindowsXInput:
				return xInput;
			case InputPlatform.WindowsWGI:
				return windowsWGI;
			case InputPlatform.WindowsFallback:
				return fallback_Windows;
			case InputPlatform.WindowsUWP:
				return windowsUWP;
			case InputPlatform.OSXNative:
				return osx;
			case InputPlatform.OSXAppleGameController:
			case InputPlatform.iOSAppleGameController:
			case InputPlatform.tvOSAppleGameController:
			case InputPlatform.VisionOSAppleGameController:
			case InputPlatform.AppleGameController:
				return appleGCController;
			case InputPlatform.OSXFallback:
				return fallback_OSX;
			case InputPlatform.LinuxNative:
				return linux;
			case InputPlatform.LinuxFallback:
				return fallback_Linux;
			case InputPlatform.LinuxFallback_PreConfigured:
				return fallback_Linux_PreConfigured;
			case InputPlatform.AndroidFallback:
				return fallback_Android;
			case InputPlatform.AmazonFireTVFallback:
				return fallback_AmazonFireTV;
			case InputPlatform.iOSFallback:
				return fallback_iOS;
			case InputPlatform.NintendoSwitch:
				return nintendoSwitch;
			case InputPlatform.NintendoSwitch2:
				return nintendoSwitch2;
			case InputPlatform.Fallback:
				throw new NotImplementedException();
			case InputPlatform.WindowsUnityInputSystem:
			case InputPlatform.WindowsUWPUnityInputSystem:
			case InputPlatform.OSXUnityInputSystem:
			case InputPlatform.LinuxUnityInputSystem:
			case InputPlatform.AndroidUnityInputSystem:
			case InputPlatform.AmazonFireTVUnityInputSystem:
			case InputPlatform.iOSUnityInputSystem:
			case InputPlatform.tvOSUnityInputSystem:
			case InputPlatform.VisionOSUnityInputSystem:
			case InputPlatform.PS4UnityInputSystem:
			case InputPlatform.PS5UnityInputSystem:
				return unityInputSystem;
			case InputPlatform.WebGL:
				return webGL;
			case InputPlatform.XboxOne:
				return xboxOne;
			case InputPlatform.GameCore:
				return gameCore;
			case InputPlatform.PS4:
				return ps4;
			case InputPlatform.PS5:
				return ps5;
			case InputPlatform.Custom:
				if (!XKZBcbGtoHHVfKdsghmQDHfhSpIfA.uiJzvtjjXxeMafDzRvVcrucZLjqaA)
				{
					throw new Exception("Custom Platform is not set.");
				}
				try
				{
					return XKZBcbGtoHHVfKdsghmQDHfhSpIfA.SwAlnjjHJrFDtTkaIMvdIjFIphik().GetPlatformMap(XKZBcbGtoHHVfKdsghmQDHfhSpIfA.sxzxGgFFdLpgJcYxojKdunKbzLov, Guid);
				}
				catch (Exception msg)
				{
					Logger.LogError(msg);
					return null;
				}
			case InputPlatform.InternalDriver:
				return internalDriver;
			case InputPlatform.WindowsSDL2:
			case InputPlatform.WindowsSDL3:
			case InputPlatform.OSXSDL2:
			case InputPlatform.OSXSDL3:
			case InputPlatform.LinuxSDL2:
			case InputPlatform.LinuxSDL3:
			case InputPlatform.SDL:
				return sdl;
			case InputPlatform.Unknown:
			case InputPlatform.Steam:
				throw new NotImplementedException();
			default:
				throw new NotImplementedException();
			}
		}

		internal static bool CalibrateAxisOptionToBool(BoolWithDefault value, AxisCoordinateMode axisCoordinateMode)
		{
			return value switch
			{
				BoolWithDefault.Default => axisCoordinateMode switch
				{
					AxisCoordinateMode.Absolute => true, 
					AxisCoordinateMode.Relative => false, 
					_ => throw new NotImplementedException(), 
				}, 
				BoolWithDefault.True => true, 
				BoolWithDefault.False => false, 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
