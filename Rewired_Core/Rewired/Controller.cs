using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class Controller
	{
		public abstract class Element
		{
			internal abstract class BiamJaAfYocdDSetqLxfXbuFKTJM
			{
				public abstract class WxnItCfMhFgVCdOwmpyjzzWxODQQ
				{
					public abstract void koJPeJxKfqRDTcPxDxnNwGFRYgYj();
				}

				protected readonly int gZqcJOfSKjJxMXzAKMMFwihjpjCUA;

				protected readonly int[] nvhHlsDjmyKgFSauRwzWnevBgkTbA;

				protected WxnItCfMhFgVCdOwmpyjzzWxODQQ[] yEDOYNZLXmuWgRBIyRVbboCXfkcA;

				public WxnItCfMhFgVCdOwmpyjzzWxODQQ mMObKzjxWzLrRGchPSzOLZhwxHRFA;

				private int EPXLnaMHcTSKwnwbifMlSHsKzjnf;

				public int FBXdLjkhbWONBMiUtjQofwaDDbPNc = -1;

				protected ReadOnlyCollection<WxnItCfMhFgVCdOwmpyjzzWxODQQ> HiYrNXtQaRnVmOXPmhNNRahhiGdY;

				public IList<WxnItCfMhFgVCdOwmpyjzzWxODQQ> AMkDherrlxMqaqNxwDUgYhRMCHei => HiYrNXtQaRnVmOXPmhNNRahhiGdY;

				public UpdateLoopType NtqLMAmaTBtROVfZyGidctldNGRJA
				{
					set
					{
						if (FBXdLjkhbWONBMiUtjQofwaDDbPNc != (int)updateLoopType)
						{
							FBXdLjkhbWONBMiUtjQofwaDDbPNc = (int)updateLoopType;
							EPXLnaMHcTSKwnwbifMlSHsKzjnf = nvhHlsDjmyKgFSauRwzWnevBgkTbA[(int)updateLoopType];
							mMObKzjxWzLrRGchPSzOLZhwxHRFA = yEDOYNZLXmuWgRBIyRVbboCXfkcA[EPXLnaMHcTSKwnwbifMlSHsKzjnf];
						}
					}
				}

				public BiamJaAfYocdDSetqLxfXbuFKTJM(UpdateLoopSetting P_0)
				{
					nvhHlsDjmyKgFSauRwzWnevBgkTbA = new int[3];
					gZqcJOfSKjJxMXzAKMMFwihjpjCUA = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(P_0, list);
						for (int i = 0; i < list.Count; i++)
						{
							nvhHlsDjmyKgFSauRwzWnevBgkTbA[(int)list[i]] = gZqcJOfSKjJxMXzAKMMFwihjpjCUA;
							gZqcJOfSKjJxMXzAKMMFwihjpjCUA++;
						}
					}
					yEDOYNZLXmuWgRBIyRVbboCXfkcA = new WxnItCfMhFgVCdOwmpyjzzWxODQQ[gZqcJOfSKjJxMXzAKMMFwihjpjCUA];
					HiYrNXtQaRnVmOXPmhNNRahhiGdY = new ReadOnlyCollection<WxnItCfMhFgVCdOwmpyjzzWxODQQ>(yEDOYNZLXmuWgRBIyRVbboCXfkcA);
				}

				public void qcSUBIUkZSdELTVLwlDuqgPxjgagA()
				{
					for (int i = 0; i < gZqcJOfSKjJxMXzAKMMFwihjpjCUA; i++)
					{
						yEDOYNZLXmuWgRBIyRVbboCXfkcA[i].koJPeJxKfqRDTcPxDxnNwGFRYgYj();
					}
				}

				public WxnItCfMhFgVCdOwmpyjzzWxODQQ voScHlClzYqFRXKTRfdwBkgqOdmoA(UpdateLoopType P_0)
				{
					return yEDOYNZLXmuWgRBIyRVbboCXfkcA[nvhHlsDjmyKgFSauRwzWnevBgkTbA[(int)P_0]];
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal BiamJaAfYocdDSetqLxfXbuFKTJM JABYaOdLAeKwiUINKsbcHDFXlUQd;

			internal int XKFTILODBvJFQuGAVPNSRJKpCJQfA;

			internal Controller ljxPApcqfhIyNhfYjBdoZjzSrymA;

			internal readonly int GHhGDdjvhvwoetKZDFjOXTsFDlXFb;

			private CompoundElement xlMhDRRnXnhbwhFxqKdRycBiXmpE;

			private bool DLtxsCZrdBHsGhCaErbJnNkxEKUQA;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = ljxPApcqfhIyNhfYjBdoZjzSrymA.GetElementIdentifierById(id);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			public virtual bool excludeFromPolling
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return false;
					}
					return DLtxsCZrdBHsGhCaErbJnNkxEKUQA;
				}
				set
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
					}
					else
					{
						DLtxsCZrdBHsGhCaErbJnNkxEKUQA = value;
					}
				}
			}

			public bool isMemberElement
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return false;
					}
					return XKFTILODBvJFQuGAVPNSRJKpCJQfA > 0;
				}
			}

			public CompoundElement compoundElement => xlMhDRRnXnhbwhFxqKdRycBiXmpE;

			internal Element(Controller P_0, int P_1, string P_2, ControllerElementType P_3)
			{
				ljxPApcqfhIyNhfYjBdoZjzSrymA = P_0;
				id = P_1;
				name = P_2;
				type = P_3;
				GHhGDdjvhvwoetKZDFjOXTsFDlXFb = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
				{
					ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
				}
				else if (JABYaOdLAeKwiUINKsbcHDFXlUQd != null)
				{
					JABYaOdLAeKwiUINKsbcHDFXlUQd.qcSUBIUkZSdELTVLwlDuqgPxjgagA();
				}
			}

			internal void GVbescAXFqCfDvUADaPblTSVkfTl(CompoundElement P_0)
			{
				if (XKFTILODBvJFQuGAVPNSRJKpCJQfA > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				XKFTILODBvJFQuGAVPNSRJKpCJQfA++;
				if (xlMhDRRnXnhbwhFxqKdRycBiXmpE == null)
				{
					xlMhDRRnXnhbwhFxqKdRycBiXmpE = P_0;
				}
			}

			internal void NBWDsIbAYcPbMYKUjvuCIkbKMiQDA(CompoundElement P_0)
			{
				if (XKFTILODBvJFQuGAVPNSRJKpCJQfA == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					XKFTILODBvJFQuGAVPNSRJKpCJQfA = 0;
					return;
				}
				XKFTILODBvJFQuGAVPNSRJKpCJQfA--;
				if (xlMhDRRnXnhbwhFxqKdRycBiXmpE == P_0)
				{
					xlMhDRRnXnhbwhFxqKdRycBiXmpE = null;
				}
			}
		}

		public sealed class Axis : Element
		{
			internal class QosCbvCDNgSRXACAQUZQGSYxfuwK : BiamJaAfYocdDSetqLxfXbuFKTJM
			{
				public class VuycwBLgXEXFKDoIRAejoRgVwAcJ : WxnItCfMhFgVCdOwmpyjzzWxODQQ
				{
					private const float DGxDQvCkGDGyftjczJVOaxEQHMgBb = 0.001f;

					public float VnMCzsvWNATCyOODffgljQznSWVdA;

					public float hZgLZClraxBmIsnLEQmaSjALDniM;

					public float UbNbIHAPewuQQJOuznHLoglCEilu;

					public float fvvYPkCxisIEflumsIKIGaKBBpVaA;

					public float qGGceUJqnMsKEiUbVSYDSRZEOFvtA;

					public float HqHejVKiLISWLdmZoFjSrclGwIhu;

					public double toMnbQKOtzCwkWUVEeZljQVnIsG;

					public double XTLMVAeLwkREhAzchdTNPFJzCkEE;

					public double YwlSYHcshdhWmZFAPbyFoJxFwFsD;

					public double yrfIxQdVpZvvCCLvbLusJPXShCSb;

					public double cHypxmUycbAapJBUFSjkIRQhOymF;

					public double RYpESjjCEzZPopixQHQXhEfzindI;

					public double mutICfLbglmlllggVIqOUDQTGnaz
					{
						get
						{
							if ((double)VnMCzsvWNATCyOODffgljQznSWVdA == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - YwlSYHcshdhWmZFAPbyFoJxFwFsD;
						}
					}

					public double ztfrFBxjvAKUZAehMPgcPpMRYfjt
					{
						get
						{
							if ((double)UbNbIHAPewuQQJOuznHLoglCEilu == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - yrfIxQdVpZvvCCLvbLusJPXShCSb;
						}
					}

					public double EJsLQfktxvJzDNLOGIFJWvuZAHhf
					{
						get
						{
							if (VnMCzsvWNATCyOODffgljQznSWVdA != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - toMnbQKOtzCwkWUVEeZljQVnIsG;
						}
					}

					public double arsbWPBWyrnrlwgxoQEtpEyqRttQA
					{
						get
						{
							if ((double)UbNbIHAPewuQQJOuznHLoglCEilu != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - XTLMVAeLwkREhAzchdTNPFJzCkEE;
						}
					}

					public void yrvrhcITwUodVMGMXaYkqekkMWFc(bool P_0)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (!MathTools.Approximately(qGGceUJqnMsKEiUbVSYDSRZEOFvtA, 0f))
							{
								toMnbQKOtzCwkWUVEeZljQVnIsG = unscaledTime;
							}
							else
							{
								YwlSYHcshdhWmZFAPbyFoJxFwFsD = unscaledTime;
							}
							if (!MathTools.IsNear(qGGceUJqnMsKEiUbVSYDSRZEOFvtA, HqHejVKiLISWLdmZoFjSrclGwIhu, 0.001f))
							{
								cHypxmUycbAapJBUFSjkIRQhOymF = unscaledTime;
							}
						}
						else
						{
							if (!MathTools.Approximately(VnMCzsvWNATCyOODffgljQznSWVdA, 0f))
							{
								toMnbQKOtzCwkWUVEeZljQVnIsG = unscaledTime;
							}
							else
							{
								YwlSYHcshdhWmZFAPbyFoJxFwFsD = unscaledTime;
							}
							if (!MathTools.IsNear(VnMCzsvWNATCyOODffgljQznSWVdA, hZgLZClraxBmIsnLEQmaSjALDniM, 0.001f))
							{
								cHypxmUycbAapJBUFSjkIRQhOymF = unscaledTime;
							}
						}
						if (!MathTools.Approximately(UbNbIHAPewuQQJOuznHLoglCEilu, 0f))
						{
							XTLMVAeLwkREhAzchdTNPFJzCkEE = unscaledTime;
						}
						else
						{
							yrfIxQdVpZvvCCLvbLusJPXShCSb = unscaledTime;
						}
						if (!MathTools.IsNear(UbNbIHAPewuQQJOuznHLoglCEilu, fvvYPkCxisIEflumsIKIGaKBBpVaA, 0.001f))
						{
							RYpESjjCEzZPopixQHQXhEfzindI = unscaledTime;
						}
					}

					public void WOnjxiPzBjnuQqBOebVkcyuCFyTL(float P_0)
					{
						if (fvvYPkCxisIEflumsIKIGaKBBpVaA != UbNbIHAPewuQQJOuznHLoglCEilu)
						{
							fvvYPkCxisIEflumsIKIGaKBBpVaA = UbNbIHAPewuQQJOuznHLoglCEilu;
						}
						if (UbNbIHAPewuQQJOuznHLoglCEilu != P_0)
						{
							UbNbIHAPewuQQJOuznHLoglCEilu = P_0;
						}
					}

					public virtual void NuzfOjvDVofzMETqQzvCKSKxgMPM()
					{
						VnMCzsvWNATCyOODffgljQznSWVdA = 0f;
						hZgLZClraxBmIsnLEQmaSjALDniM = 0f;
						UbNbIHAPewuQQJOuznHLoglCEilu = 0f;
						fvvYPkCxisIEflumsIKIGaKBBpVaA = 0f;
						toMnbQKOtzCwkWUVEeZljQVnIsG = 0.0;
						XTLMVAeLwkREhAzchdTNPFJzCkEE = 0.0;
						YwlSYHcshdhWmZFAPbyFoJxFwFsD = 0.0;
						yrfIxQdVpZvvCCLvbLusJPXShCSb = 0.0;
						cHypxmUycbAapJBUFSjkIRQhOymF = 0.0;
						RYpESjjCEzZPopixQHQXhEfzindI = 0.0;
					}
				}

				public QosCbvCDNgSRXACAQUZQGSYxfuwK(UpdateLoopSetting P_0)
					: base(P_0)
				{
					for (int i = 0; i < gZqcJOfSKjJxMXzAKMMFwihjpjCUA; i++)
					{
						yEDOYNZLXmuWgRBIyRVbboCXfkcA[i] = new VuycwBLgXEXFKDoIRAejoRgVwAcJ();
					}
					mMObKzjxWzLrRGchPSzOLZhwxHRFA = yEDOYNZLXmuWgRBIyRVbboCXfkcA[0];
				}
			}

			internal readonly AxisRange AFqHxIWJMKgjUyliCDJJNqVuyDRr;

			internal readonly HardwareAxisInfo VjHSioMESUvcoZNTLZGzLmnuVlxf;

			public float value
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).qGGceUJqnMsKEiUbVSYDSRZEOFvtA;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).VnMCzsvWNATCyOODffgljQznSWVdA;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).HqHejVKiLISWLdmZoFjSrclGwIhu;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).hZgLZClraxBmIsnLEQmaSjALDniM;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0f;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).UbNbIHAPewuQQJOuznHLoglCEilu;
				}
				internal set
				{
					((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).WOnjxiPzBjnuQqBOebVkcyuCFyTL(num);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0f;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).fvvYPkCxisIEflumsIKIGaKBBpVaA;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0f;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).UbNbIHAPewuQQJOuznHLoglCEilu - ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).fvvYPkCxisIEflumsIKIGaKBBpVaA;
				}
			}

			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).toMnbQKOtzCwkWUVEeZljQVnIsG;
				}
			}

			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).XTLMVAeLwkREhAzchdTNPFJzCkEE;
				}
			}

			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).YwlSYHcshdhWmZFAPbyFoJxFwFsD;
				}
			}

			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).yrfIxQdVpZvvCCLvbLusJPXShCSb;
				}
			}

			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).cHypxmUycbAapJBUFSjkIRQhOymF;
				}
			}

			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).RYpESjjCEzZPopixQHQXhEfzindI;
				}
			}

			public double timeActive
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).mutICfLbglmlllggVIqOUDQTGnaz;
				}
			}

			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).mutICfLbglmlllggVIqOUDQTGnaz;
				}
			}

			public double timeInactive
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).EJsLQfktxvJzDNLOGIFJWvuZAHhf;
				}
			}

			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).arsbWPBWyrnrlwgxoQEtpEyqRttQA;
				}
			}

			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0f;
					}
					if (VjHSioMESUvcoZNTLZGzLmnuVlxf == null)
					{
						return -1f;
					}
					return VjHSioMESUvcoZNTLZGzLmnuVlxf._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return;
					}
					if (value < 0f)
					{
						value = -1f;
					}
					if (VjHSioMESUvcoZNTLZGzLmnuVlxf != null)
					{
						VjHSioMESUvcoZNTLZGzLmnuVlxf._pollingDeadZone = value;
					}
				}
			}

			public AxisCoordinateMode axisCoordinateMode
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return AxisCoordinateMode.Absolute;
					}
					if (VjHSioMESUvcoZNTLZGzLmnuVlxf == null)
					{
						return AxisCoordinateMode.Absolute;
					}
					return VjHSioMESUvcoZNTLZGzLmnuVlxf.dataFormat;
				}
			}

			bool Element.excludeFromPolling
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return false;
					}
					if (VjHSioMESUvcoZNTLZGzLmnuVlxf == null)
					{
						return base.excludeFromPolling;
					}
					return VjHSioMESUvcoZNTLZGzLmnuVlxf._excludeFromPolling;
				}
				set
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return;
					}
					if (VjHSioMESUvcoZNTLZGzLmnuVlxf != null)
					{
						VjHSioMESUvcoZNTLZGzLmnuVlxf._excludeFromPolling = value;
					}
					base.excludeFromPolling = value;
				}
			}

			internal float nJyTiBwJjrwIWHlnpYHQIvzxvlBF => ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).VnMCzsvWNATCyOODffgljQznSWVdA;

			internal float qdsbeMnQkKksVcnsvPKVofZxhIZn => ((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).hZgLZClraxBmIsnLEQmaSjALDniM;

			internal float zAQaZHyHWtIpzmySIDEsIphBotfe
			{
				get
				{
					if (VjHSioMESUvcoZNTLZGzLmnuVlxf == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (VjHSioMESUvcoZNTLZGzLmnuVlxf._pollingDeadZone >= 0f)
					{
						return VjHSioMESUvcoZNTLZGzLmnuVlxf._pollingDeadZone;
					}
					return VjHSioMESUvcoZNTLZGzLmnuVlxf._dataFormat switch
					{
						AxisCoordinateMode.Absolute => ReInput.configuration.defaultAbsoluteAxisPollingDeadZone, 
						AxisCoordinateMode.Relative => ReInput.configuration.defaultRelativeAxisPollingDeadZone, 
						_ => throw new NotImplementedException(), 
					};
				}
			}

			internal void wvEbVJFdPFgnobUPlIBJKVEULhtL(float P_0)
			{
				QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ obj = (QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA;
				obj.HqHejVKiLISWLdmZoFjSrclGwIhu = obj.qGGceUJqnMsKEiUbVSYDSRZEOFvtA;
				obj.qGGceUJqnMsKEiUbVSYDSRZEOFvtA = P_0;
			}

			internal Axis(Controller P_0, int P_1, string P_2, AxisRange P_3, HardwareAxisInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Axis)
			{
				JABYaOdLAeKwiUINKsbcHDFXlUQd = new QosCbvCDNgSRXACAQUZQGSYxfuwK(ReInput.configVars.updateLoop);
				AFqHxIWJMKgjUyliCDJJNqVuyDRr = P_3;
				VjHSioMESUvcoZNTLZGzLmnuVlxf = P_4;
				if (P_4 != null)
				{
					base.excludeFromPolling = P_4._excludeFromPolling;
				}
			}

			internal void NyVWQPUHaAuuRbPyueCITNrYwQMF(UpdateLoopType P_0)
			{
				if (JABYaOdLAeKwiUINKsbcHDFXlUQd != null && JABYaOdLAeKwiUINKsbcHDFXlUQd.FBXdLjkhbWONBMiUtjQofwaDDbPNc != (int)P_0)
				{
					JABYaOdLAeKwiUINKsbcHDFXlUQd.NtqLMAmaTBtROVfZyGidctldNGRJA = P_0;
				}
			}

			internal void rTFjSZVDHbNtSWEEBDvmVKKUfcDV(AxisCalibration P_0)
			{
				QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ vuycwBLgXEXFKDoIRAejoRgVwAcJ = (QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA;
				vuycwBLgXEXFKDoIRAejoRgVwAcJ.hZgLZClraxBmIsnLEQmaSjALDniM = vuycwBLgXEXFKDoIRAejoRgVwAcJ.VnMCzsvWNATCyOODffgljQznSWVdA;
				float vnMCzsvWNATCyOODffgljQznSWVdA = P_0.GetCalibratedValue(vuycwBLgXEXFKDoIRAejoRgVwAcJ.UbNbIHAPewuQQJOuznHLoglCEilu, AFqHxIWJMKgjUyliCDJJNqVuyDRr);
				if (P_0.applyRangeCalibration)
				{
					vnMCzsvWNATCyOODffgljQznSWVdA = MathTools.Clamp(vnMCzsvWNATCyOODffgljQznSWVdA, -1f, 1f);
				}
				vuycwBLgXEXFKDoIRAejoRgVwAcJ.VnMCzsvWNATCyOODffgljQznSWVdA = vnMCzsvWNATCyOODffgljQznSWVdA;
			}

			internal void sprhmFXvaEpsQneCiMUrnITiCNkfA()
			{
				QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ obj = (QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA;
				obj.hZgLZClraxBmIsnLEQmaSjALDniM = obj.VnMCzsvWNATCyOODffgljQznSWVdA;
				obj.VnMCzsvWNATCyOODffgljQznSWVdA = obj.UbNbIHAPewuQQJOuznHLoglCEilu;
			}

			internal void wWlBDqxgNscdugUMonRQYErsRuJf()
			{
				QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ obj = (QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA;
				obj.hZgLZClraxBmIsnLEQmaSjALDniM = obj.VnMCzsvWNATCyOODffgljQznSWVdA;
				obj.VnMCzsvWNATCyOODffgljQznSWVdA = 0f;
			}

			internal void LZbFcegdfzdLiDjISqACDquEWAiA()
			{
				((QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).yrvrhcITwUodVMGMXaYkqekkMWFc(base.isMemberElement);
			}

			internal void spWwkEicNkNEJsHUrHgSABflAJBg(float P_0)
			{
				for (int i = 0; i < JABYaOdLAeKwiUINKsbcHDFXlUQd.AMkDherrlxMqaqNxwDUgYhRMCHei.Count; i++)
				{
					if (JABYaOdLAeKwiUINKsbcHDFXlUQd.AMkDherrlxMqaqNxwDUgYhRMCHei[i] is QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ vuycwBLgXEXFKDoIRAejoRgVwAcJ)
					{
						vuycwBLgXEXFKDoIRAejoRgVwAcJ.WOnjxiPzBjnuQqBOebVkcyuCFyTL(P_0);
						vuycwBLgXEXFKDoIRAejoRgVwAcJ.hZgLZClraxBmIsnLEQmaSjALDniM = vuycwBLgXEXFKDoIRAejoRgVwAcJ.VnMCzsvWNATCyOODffgljQznSWVdA;
						vuycwBLgXEXFKDoIRAejoRgVwAcJ.VnMCzsvWNATCyOODffgljQznSWVdA = 0f;
						vuycwBLgXEXFKDoIRAejoRgVwAcJ.yrvrhcITwUodVMGMXaYkqekkMWFc(base.isMemberElement);
					}
				}
			}

			internal float ceUsqmJJOrovtSaINrqXOOvWsTWO(UpdateLoopType P_0, AxisCalibration P_1)
			{
				QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ vuycwBLgXEXFKDoIRAejoRgVwAcJ = (QosCbvCDNgSRXACAQUZQGSYxfuwK.VuycwBLgXEXFKDoIRAejoRgVwAcJ)JABYaOdLAeKwiUINKsbcHDFXlUQd.voScHlClzYqFRXKTRfdwBkgqOdmoA(P_0);
				float result = P_1.GetCalibratedValue(vuycwBLgXEXFKDoIRAejoRgVwAcJ.UbNbIHAPewuQQJOuznHLoglCEilu, AFqHxIWJMKgjUyliCDJJNqVuyDRr, P_1.deadZone, P_1.upperDeadZone, applySensitivity: false, applyInversion: true);
				if (P_1.applyRangeCalibration)
				{
					result = MathTools.Clamp(result, -1f, 1f);
				}
				return result;
			}
		}

		public sealed class Button : Element
		{
			internal class ZsjXiviSPcxLiedAeHBiEQTomByXA : BiamJaAfYocdDSetqLxfXbuFKTJM
			{
				public class xKLgbGXfDOuyWRXbXulDwJslsIqs : WxnItCfMhFgVCdOwmpyjzzWxODQQ
				{
					public bool MEtdnoBupyknFHlMWGvlFdSHFtCwb;

					public bool HrlmpUOuYrDmTxjAaddJfYxzQWAB;

					public ButtonStateRecorder wzdsseLSqnCDPRzRHDDSjAHaDNbW;

					public YhJGPoGtZZWrDZpMuEbJbxJbdbSZA LgzEKCctOtKIhWsOukocgtqTzbiV;

					public xKLgbGXfDOuyWRXbXulDwJslsIqs()
					{
						wzdsseLSqnCDPRzRHDDSjAHaDNbW = new ButtonStateRecorder();
						LgzEKCctOtKIhWsOukocgtqTzbiV = new YhJGPoGtZZWrDZpMuEbJbxJbdbSZA(0.3f);
					}

					public void xKOGfJnSkdhHfExKrzyhgrCKXSKr(bool P_0)
					{
						if (HrlmpUOuYrDmTxjAaddJfYxzQWAB != MEtdnoBupyknFHlMWGvlFdSHFtCwb)
						{
							HrlmpUOuYrDmTxjAaddJfYxzQWAB = MEtdnoBupyknFHlMWGvlFdSHFtCwb;
						}
						if (MEtdnoBupyknFHlMWGvlFdSHFtCwb != P_0)
						{
							MEtdnoBupyknFHlMWGvlFdSHFtCwb = P_0;
						}
						wzdsseLSqnCDPRzRHDDSjAHaDNbW.mcqYcNSWYXNoCvZYtCCIeXnSNvYM(P_0 && !HrlmpUOuYrDmTxjAaddJfYxzQWAB, P_0, ReInput.unscaledTime);
						LgzEKCctOtKIhWsOukocgtqTzbiV.WcPMNbOeGxSbXfeNbpeeVEaucDoK(0.3f, P_0 && !HrlmpUOuYrDmTxjAaddJfYxzQWAB, P_0);
					}

					public virtual void sKmhfUbPhdqEzXzdHeStxKkOPqLN()
					{
						MEtdnoBupyknFHlMWGvlFdSHFtCwb = false;
						HrlmpUOuYrDmTxjAaddJfYxzQWAB = false;
						wzdsseLSqnCDPRzRHDDSjAHaDNbW.CgYFOVgparhedovyjqaaJjHjEPsE();
						LgzEKCctOtKIhWsOukocgtqTzbiV.lATzQBooAZRGUxSLGYwvbdsxtSWD();
					}
				}

				public class wmAqusXEOisYPDYIcubsfoGuDPLDA : xKLgbGXfDOuyWRXbXulDwJslsIqs
				{
					public float aVLFUrAJYDCAPzXEmQjfiCUqFceKA;

					public float YiwxZtIPvOFBVxnLJCPABRzjWxQJ;

					public void exqNCVNEcLQKkmAlfiBuemjLmgQV(float P_0)
					{
						if (YiwxZtIPvOFBVxnLJCPABRzjWxQJ != aVLFUrAJYDCAPzXEmQjfiCUqFceKA)
						{
							YiwxZtIPvOFBVxnLJCPABRzjWxQJ = aVLFUrAJYDCAPzXEmQjfiCUqFceKA;
						}
						if (aVLFUrAJYDCAPzXEmQjfiCUqFceKA != P_0)
						{
							aVLFUrAJYDCAPzXEmQjfiCUqFceKA = ((P_0 > 0.001f) ? P_0 : 0f);
						}
						xKOGfJnSkdhHfExKrzyhgrCKXSKr(aVLFUrAJYDCAPzXEmQjfiCUqFceKA > 0f);
					}

					public virtual void oRURSxFfsUJDUZFffpgdnlmSKHiS()
					{
						sKmhfUbPhdqEzXzdHeStxKkOPqLN();
						aVLFUrAJYDCAPzXEmQjfiCUqFceKA = 0f;
						YiwxZtIPvOFBVxnLJCPABRzjWxQJ = 0f;
					}
				}

				public ZsjXiviSPcxLiedAeHBiEQTomByXA(UpdateLoopSetting P_0, bool P_1)
					: base(P_0)
				{
					for (int i = 0; i < gZqcJOfSKjJxMXzAKMMFwihjpjCUA; i++)
					{
						if (P_1)
						{
							yEDOYNZLXmuWgRBIyRVbboCXfkcA[i] = new wmAqusXEOisYPDYIcubsfoGuDPLDA();
						}
						else
						{
							yEDOYNZLXmuWgRBIyRVbboCXfkcA[i] = new xKLgbGXfDOuyWRXbXulDwJslsIqs();
						}
					}
					mMObKzjxWzLrRGchPSzOLZhwxHRFA = yEDOYNZLXmuWgRBIyRVbboCXfkcA[0];
				}

				public void hrOYQiPXmmbTiShcUKEjDGoVmWKj(float P_0)
				{
					for (int i = 0; i < yEDOYNZLXmuWgRBIyRVbboCXfkcA.Length; i++)
					{
						((xKLgbGXfDOuyWRXbXulDwJslsIqs)yEDOYNZLXmuWgRBIyRVbboCXfkcA[i]).LgzEKCctOtKIhWsOukocgtqTzbiV.sKvuiTrljNWzvFcUiWrozsecUSwE(P_0);
					}
				}

				public void SGyLNLtqVCHOkjRkQWzljPdjKDol()
				{
					for (int i = 0; i < yEDOYNZLXmuWgRBIyRVbboCXfkcA.Length; i++)
					{
						((xKLgbGXfDOuyWRXbXulDwJslsIqs)yEDOYNZLXmuWgRBIyRVbboCXfkcA[i]).LgzEKCctOtKIhWsOukocgtqTzbiV.sKvuiTrljNWzvFcUiWrozsecUSwE(0.3f);
					}
				}
			}

			internal readonly bool OKUzYcRerasUaNizMfRHlSACKwHQ;

			internal readonly HardwareButtonInfo BjdlHFTQJrxhMIisKGkRlDTqVcOt;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return false;
					}
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).HrlmpUOuYrDmTxjAaddJfYxzQWAB;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return false;
					}
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).MEtdnoBupyknFHlMWGvlFdSHFtCwb;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0f;
					}
					if (!OKUzYcRerasUaNizMfRHlSACKwHQ)
					{
						if (!((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).MEtdnoBupyknFHlMWGvlFdSHFtCwb)
						{
							return 0f;
						}
						return 1f;
					}
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.wmAqusXEOisYPDYIcubsfoGuDPLDA)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).aVLFUrAJYDCAPzXEmQjfiCUqFceKA;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0f;
					}
					if (!OKUzYcRerasUaNizMfRHlSACKwHQ)
					{
						if (!((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).HrlmpUOuYrDmTxjAaddJfYxzQWAB)
						{
							return 0f;
						}
						return 1f;
					}
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.wmAqusXEOisYPDYIcubsfoGuDPLDA)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).YiwxZtIPvOFBVxnLJCPABRzjWxQJ;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return false;
					}
					return OKUzYcRerasUaNizMfRHlSACKwHQ;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return false;
					}
					if (!((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).HrlmpUOuYrDmTxjAaddJfYxzQWAB && ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).MEtdnoBupyknFHlMWGvlFdSHFtCwb)
					{
						return true;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return false;
					}
					if (((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).HrlmpUOuYrDmTxjAaddJfYxzQWAB && !((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).MEtdnoBupyknFHlMWGvlFdSHFtCwb)
					{
						return true;
					}
					return false;
				}
			}

			public bool justChangedState
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return false;
					}
					if (((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).HrlmpUOuYrDmTxjAaddJfYxzQWAB != ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).MEtdnoBupyknFHlMWGvlFdSHFtCwb)
					{
						return true;
					}
					return false;
				}
			}

			public bool doublePressedAndHeld
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return false;
					}
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).LgzEKCctOtKIhWsOukocgtqTzbiV.NdciJmlFKGsPWAYTqfPWpCgclixD;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).LgzEKCctOtKIhWsOukocgtqTzbiV.NdciJmlFKGsPWAYTqfPWpCgclixD;
				}
			}

			public double timePressed
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).wzdsseLSqnCDPRzRHDDSjAHaDNbW.ENyAlpnAuOxkuGMnehFpSFaSnqbQ;
				}
			}

			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).wzdsseLSqnCDPRzRHDDSjAHaDNbW.eeeSNGskRUCozEZeDGZxCPrXeGCT;
				}
			}

			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).wzdsseLSqnCDPRzRHDDSjAHaDNbW.sYVEtIlLdMQMftOVfWpmCZyOnMw;
				}
			}

			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).wzdsseLSqnCDPRzRHDDSjAHaDNbW.stHMMJarDgDwhbqLJnIgavFGgLLQ;
				}
			}

			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
					{
						ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
						return 0.0;
					}
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).wzdsseLSqnCDPRzRHDDSjAHaDNbW.cXQbmfJsvVfukRhIrwhUtJbshEdR;
				}
			}

			internal ButtonStateFlags blYrwHjcWGpIqexNxMwIzJxuScdM
			{
				get
				{
					ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs xKLgbGXfDOuyWRXbXulDwJslsIqs = (ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
					if (xKLgbGXfDOuyWRXbXulDwJslsIqs.MEtdnoBupyknFHlMWGvlFdSHFtCwb)
					{
						buttonStateFlags |= ButtonStateFlags.On;
						if (!xKLgbGXfDOuyWRXbXulDwJslsIqs.HrlmpUOuYrDmTxjAaddJfYxzQWAB)
						{
							buttonStateFlags |= ButtonStateFlags.Down;
						}
					}
					else if (xKLgbGXfDOuyWRXbXulDwJslsIqs.HrlmpUOuYrDmTxjAaddJfYxzQWAB)
					{
						buttonStateFlags |= ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
			}

			internal Button(Controller P_0, int P_1, string P_2, HardwareButtonInfo P_3)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				BjdlHFTQJrxhMIisKGkRlDTqVcOt = P_3;
				JABYaOdLAeKwiUINKsbcHDFXlUQd = new ZsjXiviSPcxLiedAeHBiEQTomByXA(ReInput.configVars.updateLoop, false);
			}

			internal Button(Controller P_0, int P_1, string P_2, bool P_3, HardwareButtonInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				BjdlHFTQJrxhMIisKGkRlDTqVcOt = P_4;
				OKUzYcRerasUaNizMfRHlSACKwHQ = P_3;
				JABYaOdLAeKwiUINKsbcHDFXlUQd = new ZsjXiviSPcxLiedAeHBiEQTomByXA(ReInput.configVars.updateLoop, P_3);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
				{
					ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
					return false;
				}
				if (speed <= 0f)
				{
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).LgzEKCctOtKIhWsOukocgtqTzbiV.NdciJmlFKGsPWAYTqfPWpCgclixD;
				}
				return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).wzdsseLSqnCDPRzRHDDSjAHaDNbW.NrqsbRXgdyChYzTGZPHCtbdqfYqT(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != GHhGDdjvhvwoetKZDFjOXTsFDlXFb)
				{
					ReInput.CheckInitialized(GHhGDdjvhvwoetKZDFjOXTsFDlXFb);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).LgzEKCctOtKIhWsOukocgtqTzbiV.NdciJmlFKGsPWAYTqfPWpCgclixD;
				}
				return ((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).wzdsseLSqnCDPRzRHDDSjAHaDNbW.NrqsbRXgdyChYzTGZPHCtbdqfYqT(speed);
			}

			internal void ATotgcxEhwOfqwnIKjpCkFpDQrTgb(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (JABYaOdLAeKwiUINKsbcHDFXlUQd != null && JABYaOdLAeKwiUINKsbcHDFXlUQd.FBXdLjkhbWONBMiUtjQofwaDDbPNc != (int)P_0)
				{
					JABYaOdLAeKwiUINKsbcHDFXlUQd.NtqLMAmaTBtROVfZyGidctldNGRJA = P_0;
				}
				if (OKUzYcRerasUaNizMfRHlSACKwHQ)
				{
					((ZsjXiviSPcxLiedAeHBiEQTomByXA.wmAqusXEOisYPDYIcubsfoGuDPLDA)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).exqNCVNEcLQKkmAlfiBuemjLmgQV(P_2.buttonPressureValues[P_1]);
				}
				else
				{
					((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).xKOGfJnSkdhHfExKrzyhgrCKXSKr(P_2.buttonValues[P_1]);
				}
			}

			internal void kuUKprDRyxDzWbelkjpDTcAAqxb(UpdateLoopType P_0)
			{
				if (JABYaOdLAeKwiUINKsbcHDFXlUQd != null && JABYaOdLAeKwiUINKsbcHDFXlUQd.FBXdLjkhbWONBMiUtjQofwaDDbPNc != (int)P_0)
				{
					JABYaOdLAeKwiUINKsbcHDFXlUQd.NtqLMAmaTBtROVfZyGidctldNGRJA = P_0;
				}
				if (OKUzYcRerasUaNizMfRHlSACKwHQ)
				{
					((ZsjXiviSPcxLiedAeHBiEQTomByXA.wmAqusXEOisYPDYIcubsfoGuDPLDA)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).exqNCVNEcLQKkmAlfiBuemjLmgQV(0f);
				}
				else
				{
					((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)JABYaOdLAeKwiUINKsbcHDFXlUQd.mMObKzjxWzLrRGchPSzOLZhwxHRFA).xKOGfJnSkdhHfExKrzyhgrCKXSKr(false);
				}
			}

			internal void ashdZfbxsCHfoLHlZQCLrMCOqCbB()
			{
				for (int i = 0; i < JABYaOdLAeKwiUINKsbcHDFXlUQd.AMkDherrlxMqaqNxwDUgYhRMCHei.Count; i++)
				{
					BiamJaAfYocdDSetqLxfXbuFKTJM.WxnItCfMhFgVCdOwmpyjzzWxODQQ wxnItCfMhFgVCdOwmpyjzzWxODQQ = JABYaOdLAeKwiUINKsbcHDFXlUQd.AMkDherrlxMqaqNxwDUgYhRMCHei[i];
					if (wxnItCfMhFgVCdOwmpyjzzWxODQQ != null)
					{
						if (OKUzYcRerasUaNizMfRHlSACKwHQ)
						{
							((ZsjXiviSPcxLiedAeHBiEQTomByXA.wmAqusXEOisYPDYIcubsfoGuDPLDA)wxnItCfMhFgVCdOwmpyjzzWxODQQ).exqNCVNEcLQKkmAlfiBuemjLmgQV(0f);
						}
						else
						{
							((ZsjXiviSPcxLiedAeHBiEQTomByXA.xKLgbGXfDOuyWRXbXulDwJslsIqs)wxnItCfMhFgVCdOwmpyjzzWxODQQ).xKOGfJnSkdhHfExKrzyhgrCKXSKr(false);
						}
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class AQQwXfjeKBDcbHwxUgBnCVEJuWmLA
			{
				public readonly Element MllWbALNbCjfJARRfYfaaKhuYxge;

				public readonly int lKLIJQtzZxtqKAOicHUWsLkWjCjaA;

				public AQQwXfjeKBDcbHwxUgBnCVEJuWmLA(Element P_0, int P_1)
				{
					MllWbALNbCjfJARRfYfaaKhuYxge = P_0;
					lKLIJQtzZxtqKAOicHUWsLkWjCjaA = P_1;
				}
			}

			private int EynHcKaeVCfwAGbZKSkviKuwfoit;

			private string WXoUzFyjGXHmSvUomqXQzkEUhVgL;

			private CompoundControllerElementType WmHfgejNMYShwOtEwHkThUdAJZRDA;

			private int DwLdjMcjQzGkaVhcYfYuqKgNMUTbA;

			private AQQwXfjeKBDcbHwxUgBnCVEJuWmLA[] lchmruzLsHoiqrJqsedBdxaLBRiDA;

			private Controller davovIpGdAFcLfzrjecYFfDHygCTA;

			internal readonly int FlxBxvbaVLsUKQmWHedWGLPaElcnc;

			public int id
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return -1;
					}
					return EynHcKaeVCfwAGbZKSkviKuwfoit;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return string.Empty;
					}
					return WXoUzFyjGXHmSvUomqXQzkEUhVgL;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return CompoundControllerElementType.Axis2D;
					}
					return WmHfgejNMYShwOtEwHkThUdAJZRDA;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return false;
					}
					return DwLdjMcjQzGkaVhcYfYuqKgNMUTbA > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return 0;
					}
					return DwLdjMcjQzGkaVhcYfYuqKgNMUTbA;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = davovIpGdAFcLfzrjecYFfDHygCTA.GetElementIdentifierById(EynHcKaeVCfwAGbZKSkviKuwfoit);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			internal CompoundElement(Controller P_0, int P_1, string P_2, CompoundControllerElementType P_3)
			{
				davovIpGdAFcLfzrjecYFfDHygCTA = P_0;
				EynHcKaeVCfwAGbZKSkviKuwfoit = P_1;
				WXoUzFyjGXHmSvUomqXQzkEUhVgL = P_2;
				WmHfgejNMYShwOtEwHkThUdAJZRDA = P_3;
				lchmruzLsHoiqrJqsedBdxaLBRiDA = new AQQwXfjeKBDcbHwxUgBnCVEJuWmLA[elementCapacity];
				FlxBxvbaVLsUKQmWHedWGLPaElcnc = ReInput.id;
			}

			internal Element LastCFISoTLhfYdyncnYDLRMdTjfA(int P_0)
			{
				if (P_0 < 0 || P_0 >= lchmruzLsHoiqrJqsedBdxaLBRiDA.Length)
				{
					return null;
				}
				if (lchmruzLsHoiqrJqsedBdxaLBRiDA[P_0] == null)
				{
					return null;
				}
				return lchmruzLsHoiqrJqsedBdxaLBRiDA[P_0].MllWbALNbCjfJARRfYfaaKhuYxge;
			}

			internal _0001 LastCFISoTLhfYdyncnYDLRMdTjfA<_0001>(int P_0) where _0001 : Element
			{
				if (P_0 < 0 || P_0 >= lchmruzLsHoiqrJqsedBdxaLBRiDA.Length)
				{
					return null;
				}
				if (lchmruzLsHoiqrJqsedBdxaLBRiDA[P_0] == null)
				{
					return null;
				}
				return lchmruzLsHoiqrJqsedBdxaLBRiDA[P_0].MllWbALNbCjfJARRfYfaaKhuYxge as _0001;
			}

			internal _0001 WoDfRzCokiDSMQCearoOaOyiIDbrA<_0001>(int P_0, out int P_1) where _0001 : Element
			{
				P_1 = -1;
				if (P_0 < 0 || P_0 >= lchmruzLsHoiqrJqsedBdxaLBRiDA.Length)
				{
					return null;
				}
				if (lchmruzLsHoiqrJqsedBdxaLBRiDA[P_0] == null)
				{
					return null;
				}
				P_1 = lchmruzLsHoiqrJqsedBdxaLBRiDA[P_0].lKLIJQtzZxtqKAOicHUWsLkWjCjaA;
				return lchmruzLsHoiqrJqsedBdxaLBRiDA[P_0].MllWbALNbCjfJARRfYfaaKhuYxge as _0001;
			}

			internal bool wMybGuTtUBUADlHFlfWDCmJGbNzHA(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (DwLdjMcjQzGkaVhcYfYuqKgNMUTbA >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (ChOBNyOnzEdFYQezLMRePBRfVigQ(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = etjuTxtePwDkIDSUsXlBPRWjEjUiA();
				if (num < 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				return LJCpDTXeBisPCgdeaYmclaldNRsT(P_0, P_1, num);
			}

			internal bool weBKAAdCJxuDgzmfGldpAMFPrZQG(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (DwLdjMcjQzGkaVhcYfYuqKgNMUTbA == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = ChOBNyOnzEdFYQezLMRePBRfVigQ(P_0);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return fgMbpvOxxZaVddPAgeumRzAXMoXjA(num);
			}

			internal void LAgPARRCDJletVZzgUKAocmOIgvEA()
			{
				for (int i = 0; i < lchmruzLsHoiqrJqsedBdxaLBRiDA.Length; i++)
				{
					fgMbpvOxxZaVddPAgeumRzAXMoXjA(i);
				}
				DwLdjMcjQzGkaVhcYfYuqKgNMUTbA = 0;
			}

			private int ChOBNyOnzEdFYQezLMRePBRfVigQ(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				for (int i = 0; i < lchmruzLsHoiqrJqsedBdxaLBRiDA.Length; i++)
				{
					if (lchmruzLsHoiqrJqsedBdxaLBRiDA[i] != null && lchmruzLsHoiqrJqsedBdxaLBRiDA[i].MllWbALNbCjfJARRfYfaaKhuYxge == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private bool LJCpDTXeBisPCgdeaYmclaldNRsT(Element P_0, int P_1, int P_2)
			{
				if (P_2 < 0 || P_2 >= lchmruzLsHoiqrJqsedBdxaLBRiDA.Length)
				{
					return false;
				}
				if (lchmruzLsHoiqrJqsedBdxaLBRiDA[P_2] != null)
				{
					return false;
				}
				lchmruzLsHoiqrJqsedBdxaLBRiDA[P_2] = new AQQwXfjeKBDcbHwxUgBnCVEJuWmLA(P_0, P_1);
				P_0.GVbescAXFqCfDvUADaPblTSVkfTl(this);
				DwLdjMcjQzGkaVhcYfYuqKgNMUTbA++;
				return true;
			}

			private bool fgMbpvOxxZaVddPAgeumRzAXMoXjA(int P_0)
			{
				if (P_0 < 0 || P_0 >= lchmruzLsHoiqrJqsedBdxaLBRiDA.Length)
				{
					return false;
				}
				if (lchmruzLsHoiqrJqsedBdxaLBRiDA[P_0] == null)
				{
					return false;
				}
				if (lchmruzLsHoiqrJqsedBdxaLBRiDA[P_0].MllWbALNbCjfJARRfYfaaKhuYxge != null)
				{
					lchmruzLsHoiqrJqsedBdxaLBRiDA[P_0].MllWbALNbCjfJARRfYfaaKhuYxge.NBWDsIbAYcPbMYKUjvuCIkbKMiQDA(this);
				}
				lchmruzLsHoiqrJqsedBdxaLBRiDA[P_0] = null;
				DwLdjMcjQzGkaVhcYfYuqKgNMUTbA--;
				return true;
			}

			private int etjuTxtePwDkIDSUsXlBPRWjEjUiA()
			{
				for (int i = 0; i < lchmruzLsHoiqrJqsedBdxaLBRiDA.Length; i++)
				{
					if (lchmruzLsHoiqrJqsedBdxaLBRiDA[i] == null)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int FqXfFGLTYKEwGGYobvGSKqTiTCBE = 2;

			private CalibrationMap UFwkGFmABTrHRBUZwvzSLgHEAsU;

			private readonly int eTIYGJWUhnGibySgCZcjWrljiuQP;

			int CompoundElement.elementCapacity => 2;

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return Vector2.zero;
					}
					return AHkMpkFsEpwOVsRTTpZubcdFedsCA();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return Vector2.zero;
					}
					return zEEGHElmUjRULFAWBtZTOXLBqrUD();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller P_0, int P_1, string P_2, Axis P_3, Axis P_4, int P_5, int P_6, int P_7, CalibrationMap P_8)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Axis2D)
			{
				wMybGuTtUBUADlHFlfWDCmJGbNzHA(P_3, P_5);
				wMybGuTtUBUADlHFlfWDCmJGbNzHA(P_4, P_6);
				eTIYGJWUhnGibySgCZcjWrljiuQP = P_7;
				UFwkGFmABTrHRBUZwvzSLgHEAsU = P_8;
			}

			internal void PmvFtRfUsCAPQopdePVDYwnwTaeH()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.wvEbVJFdPFgnobUPlIBJKVEULhtL(vector.x);
				}
				if (yAxis != null)
				{
					yAxis.wvEbVJFdPFgnobUPlIBJKVEULhtL(vector.y);
				}
			}

			private Vector2 AHkMpkFsEpwOVsRTTpZubcdFedsCA()
			{
				if (UFwkGFmABTrHRBUZwvzSLgHEAsU == null)
				{
					return default(Vector2);
				}
				int index;
				Axis axis = WoDfRzCokiDSMQCearoOaOyiIDbrA<Axis>(0, out index);
				int index2;
				Axis axis2 = WoDfRzCokiDSMQCearoOaOyiIDbrA<Axis>(1, out index2);
				float valueRawX = axis?.valueRaw ?? 0f;
				float valueRawY = axis2?.valueRaw ?? 0f;
				return Axis2DCalibration.GetCalibratedValue(UFwkGFmABTrHRBUZwvzSLgHEAsU.GetAxis2D(eTIYGJWUhnGibySgCZcjWrljiuQP), UFwkGFmABTrHRBUZwvzSLgHEAsU.GetAxis(index), UFwkGFmABTrHRBUZwvzSLgHEAsU.GetAxis(index2), valueRawX, valueRawY);
			}

			private Vector2 zEEGHElmUjRULFAWBtZTOXLBqrUD()
			{
				if (UFwkGFmABTrHRBUZwvzSLgHEAsU == null)
				{
					return default(Vector2);
				}
				int index;
				Axis axis = WoDfRzCokiDSMQCearoOaOyiIDbrA<Axis>(0, out index);
				int index2;
				Axis axis2 = WoDfRzCokiDSMQCearoOaOyiIDbrA<Axis>(1, out index2);
				float valueRawX = axis?.valueRawPrev ?? 0f;
				float valueRawY = axis2?.valueRawPrev ?? 0f;
				return Axis2DCalibration.GetCalibratedValue(UFwkGFmABTrHRBUZwvzSLgHEAsU.GetAxis2D(eTIYGJWUhnGibySgCZcjWrljiuQP), UFwkGFmABTrHRBUZwvzSLgHEAsU.GetAxis(index), UFwkGFmABTrHRBUZwvzSLgHEAsU.GetAxis(index2), valueRawX, valueRawY);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int izELNTSoeBiWvqXBISmvVKwjpfVq = 8;

			private const int zbJkwuGRYffLNXQqvdjhwvCrEEcM = 0;

			private const int SHobaFguLiUIKTeeObsOUlEtWEjNA = 1;

			private const int wugQMbxxXEwBsqbDjvvqpcdMTwHc = 2;

			private const int IGgzBzrPIPFJPbCSuKTdzqAaoLBu = 3;

			private const int pzCDtVfbSvRQursBfwmQwDqYNZgSA = 4;

			private const int zAQaaidfQjtAlMMsqDnnpkSVWZFp = 5;

			private const int cvrbsaEpoLebhUjNWtWIMuRqJIkEA = 6;

			private const int QuLcrvCqwyGVSejlIKDXntzIqGAtb = 7;

			private readonly int hBfifRKNeULdYhcScYxOTvoGynqQA;

			private readonly Button[] BdPGUKRKweXoPMeYMglsHjNTrUYy;

			private readonly ReadOnlyCollection<Button> kcmXtqWtpvUXedLqwArznKuEOxyj;

			private readonly int[] aofUzdSRyXJlzgpWDtoekeRoNpGw;

			private bool qQfCaeEQOAZAumBkhehkTHbDmryDb;

			int CompoundElement.elementCapacity => 8;

			public bool force4Way
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return false;
					}
					return qQfCaeEQOAZAumBkhehkTHbDmryDb;
				}
				set
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
					}
					else
					{
						qQfCaeEQOAZAumBkhehkTHbDmryDb = value;
					}
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return 0;
					}
					return hBfifRKNeULdYhcScYxOTvoGynqQA;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return kcmXtqWtpvUXedLqwArznKuEOxyj;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Button>(7);
				}
			}

			internal Hat(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Hat)
			{
				int num = ((P_3 != null) ? P_3.Length : 0);
				if (num != ((P_4 != null) ? P_4.Length : 0))
				{
					throw new ArgumentException("buttons.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4 && num != 8)
				{
					throw new ArgumentException("buttons.Length must be 0, 4, or 8! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					wMybGuTtUBUADlHFlfWDCmJGbNzHA(P_3[i], P_4[i]);
				}
				BdPGUKRKweXoPMeYMglsHjNTrUYy = P_3;
				aofUzdSRyXJlzgpWDtoekeRoNpGw = P_4;
				hBfifRKNeULdYhcScYxOTvoGynqQA = num;
				kcmXtqWtpvUXedLqwArznKuEOxyj = new ReadOnlyCollection<Button>(P_3);
			}

			internal void lOYNaCTGvSrVPAfZUmLzMozHGezQ(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (hBfifRKNeULdYhcScYxOTvoGynqQA == 0)
				{
					return;
				}
				if (hBfifRKNeULdYhcScYxOTvoGynqQA == 8 && (qQfCaeEQOAZAumBkhehkTHbDmryDb || ReInput.configVars.force4WayHats))
				{
					pwAjyvkENMaHUHGgZMNcaoSMBrRk(BdPGUKRKweXoPMeYMglsHjNTrUYy[0], aofUzdSRyXJlzgpWDtoekeRoNpGw[0], aofUzdSRyXJlzgpWDtoekeRoNpGw[7], aofUzdSRyXJlzgpWDtoekeRoNpGw[1], P_0, P_1);
					pwAjyvkENMaHUHGgZMNcaoSMBrRk(BdPGUKRKweXoPMeYMglsHjNTrUYy[2], aofUzdSRyXJlzgpWDtoekeRoNpGw[2], aofUzdSRyXJlzgpWDtoekeRoNpGw[1], aofUzdSRyXJlzgpWDtoekeRoNpGw[3], P_0, P_1);
					pwAjyvkENMaHUHGgZMNcaoSMBrRk(BdPGUKRKweXoPMeYMglsHjNTrUYy[4], aofUzdSRyXJlzgpWDtoekeRoNpGw[4], aofUzdSRyXJlzgpWDtoekeRoNpGw[5], aofUzdSRyXJlzgpWDtoekeRoNpGw[3], P_0, P_1);
					pwAjyvkENMaHUHGgZMNcaoSMBrRk(BdPGUKRKweXoPMeYMglsHjNTrUYy[6], aofUzdSRyXJlzgpWDtoekeRoNpGw[6], aofUzdSRyXJlzgpWDtoekeRoNpGw[5], aofUzdSRyXJlzgpWDtoekeRoNpGw[7], P_0, P_1);
					KILboxtOLuBHXIhfNEBNEBzeUAiWb(BdPGUKRKweXoPMeYMglsHjNTrUYy[1], aofUzdSRyXJlzgpWDtoekeRoNpGw[1], P_0, P_1);
					KILboxtOLuBHXIhfNEBNEBzeUAiWb(BdPGUKRKweXoPMeYMglsHjNTrUYy[3], aofUzdSRyXJlzgpWDtoekeRoNpGw[3], P_0, P_1);
					KILboxtOLuBHXIhfNEBNEBzeUAiWb(BdPGUKRKweXoPMeYMglsHjNTrUYy[5], aofUzdSRyXJlzgpWDtoekeRoNpGw[5], P_0, P_1);
					KILboxtOLuBHXIhfNEBNEBzeUAiWb(BdPGUKRKweXoPMeYMglsHjNTrUYy[7], aofUzdSRyXJlzgpWDtoekeRoNpGw[7], P_0, P_1);
					return;
				}
				for (int i = 0; i < BdPGUKRKweXoPMeYMglsHjNTrUYy.Length; i++)
				{
					if (BdPGUKRKweXoPMeYMglsHjNTrUYy[i] != null)
					{
						BdPGUKRKweXoPMeYMglsHjNTrUYy[i].ATotgcxEhwOfqwnIKjpCkFpDQrTgb(P_0, aofUzdSRyXJlzgpWDtoekeRoNpGw[i], P_1);
					}
				}
			}

			internal void jNvXwprFbKLhkxVRAaCbaOtXGejA(UpdateLoopType P_0)
			{
				if (hBfifRKNeULdYhcScYxOTvoGynqQA == 0)
				{
					return;
				}
				for (int i = 0; i < BdPGUKRKweXoPMeYMglsHjNTrUYy.Length; i++)
				{
					if (BdPGUKRKweXoPMeYMglsHjNTrUYy[i] != null)
					{
						BdPGUKRKweXoPMeYMglsHjNTrUYy[i].kuUKprDRyxDzWbelkjpDTcAAqxb(P_0);
					}
				}
			}

			private void pwAjyvkENMaHUHGgZMNcaoSMBrRk(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
			{
				if (P_0 == null || P_1 < 0 || P_1 >= P_5.buttonCount)
				{
					return;
				}
				if (!P_0.isPressureSensitive)
				{
					if (P_2 >= 0 && P_2 < P_5.buttonCount)
					{
						ref bool reference = ref P_5.buttonValues[P_1];
						reference |= P_5.buttonValues[P_2];
					}
					if (P_3 >= 0 && P_3 < P_5.buttonCount)
					{
						ref bool reference2 = ref P_5.buttonValues[P_1];
						reference2 |= P_5.buttonValues[P_3];
					}
				}
				else
				{
					P_5.buttonPressureValues[P_1] = MathTools.MaxMagnitude(P_5.buttonPressureValues[P_1], MathTools.MaxMagnitude((P_2 >= 0 && P_2 < P_5.buttonCount) ? P_5.buttonPressureValues[P_2] : 0f, (P_3 >= 0 && P_3 < P_5.buttonCount) ? P_5.buttonPressureValues[P_3] : 0f));
				}
				P_0.ATotgcxEhwOfqwnIKjpCkFpDQrTgb(P_4, P_1, P_5);
			}

			private void KILboxtOLuBHXIhfNEBNEBzeUAiWb(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
			{
				if (P_0 != null && P_1 >= 0 && P_1 < P_3.buttonCount)
				{
					if (!P_0.isPressureSensitive)
					{
						P_3.buttonValues[P_1] = false;
					}
					else
					{
						P_3.buttonPressureValues[P_1] = 0f;
					}
					P_0.ATotgcxEhwOfqwnIKjpCkFpDQrTgb(P_2, P_1, P_3);
				}
			}
		}

		public sealed class DirectionalPad : CompoundElement
		{
			private const int NOxTdoMjnIcdubcSDnfSdJimzHkw = 4;

			private const int rBghgkqXtwpebzlTNhBZKgNhjxyn = 0;

			private const int eumLWPHaClBFqxJlQbWFwaMMiVi = 1;

			private const int QTEBKlwkRlGiEENRKEScdJwfnKWcb = 2;

			private const int hVpZDnOVyIrsZVBWOlZLGxczIsgP = 3;

			private readonly int RsGuPdcGSJkhfbvfjEoVpBaiHHkc;

			private readonly Button[] fJiJUuSAygDsBjsbFwmIdugRvjz;

			private readonly ReadOnlyCollection<Button> HdOAVxLIMgfMJBImnkmPQOxOeqRl;

			private readonly int[] myUvXocboeCNupkDqXnZRbJhmjsr;

			int CompoundElement.elementCapacity => 4;

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return HdOAVxLIMgfMJBImnkmPQOxOeqRl;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Button>(1);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Button>(2);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != FlxBxvbaVLsUKQmWHedWGLPaElcnc)
					{
						ReInput.CheckInitialized(FlxBxvbaVLsUKQmWHedWGLPaElcnc);
						return null;
					}
					return LastCFISoTLhfYdyncnYDLRMdTjfA<Button>(3);
				}
			}

			internal DirectionalPad(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
				: base(P_0, P_1, P_2, CompoundControllerElementType.DPad)
			{
				int num = ((P_3 != null) ? P_3.Length : 0);
				if (num != ((P_4 != null) ? P_4.Length : 0))
				{
					throw new ArgumentException("buttons.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4)
				{
					throw new ArgumentException("buttons.Length must be 0 or 4! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					wMybGuTtUBUADlHFlfWDCmJGbNzHA(P_3[i], P_4[i]);
				}
				fJiJUuSAygDsBjsbFwmIdugRvjz = P_3;
				myUvXocboeCNupkDqXnZRbJhmjsr = P_4;
				RsGuPdcGSJkhfbvfjEoVpBaiHHkc = num;
				HdOAVxLIMgfMJBImnkmPQOxOeqRl = new ReadOnlyCollection<Button>(P_3);
			}

			internal void FjkewxXfIeWToiObnfBdwgnZNpTV(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (RsGuPdcGSJkhfbvfjEoVpBaiHHkc == 0)
				{
					return;
				}
				for (int i = 0; i < fJiJUuSAygDsBjsbFwmIdugRvjz.Length; i++)
				{
					if (fJiJUuSAygDsBjsbFwmIdugRvjz[i] != null)
					{
						fJiJUuSAygDsBjsbFwmIdugRvjz[i].ATotgcxEhwOfqwnIKjpCkFpDQrTgb(P_0, myUvXocboeCNupkDqXnZRbJhmjsr[i], P_1);
					}
				}
			}

			internal void fMwmcLeRsfPJGDwoHMTKZPELLhhH(UpdateLoopType P_0)
			{
				if (RsGuPdcGSJkhfbvfjEoVpBaiHHkc == 0)
				{
					return;
				}
				for (int i = 0; i < fJiJUuSAygDsBjsbFwmIdugRvjz.Length; i++)
				{
					if (fJiJUuSAygDsBjsbFwmIdugRvjz[i] != null)
					{
						fJiJUuSAygDsBjsbFwmIdugRvjz[i].kuUKprDRyxDzWbelkjpDTcAAqxb(P_0);
					}
				}
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller SbiUAFWnRmpjAFAoZDqeINfnfeym;

			private IControllerExtensionSource UbPEUzNPchDLKDiHsbqcxLchuCAnA;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (SbiUAFWnRmpjAFAoZDqeINfnfeym == null)
					{
						return false;
					}
					return SbiUAFWnRmpjAFAoZDqeINfnfeym._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (SbiUAFWnRmpjAFAoZDqeINfnfeym == null)
					{
						return false;
					}
					return SbiUAFWnRmpjAFAoZDqeINfnfeym.enabled;
				}
			}

			public Controller controller => SbiUAFWnRmpjAFAoZDqeINfnfeym;

			internal Extension(IControllerExtensionSource P_0)
			{
				_reInputId = ReInput.id;
				chOFlNaznpzGmphgIheSqSuLPxUx(P_0);
			}

			internal Extension(Extension P_0)
				: this(P_0.UbPEUzNPchDLKDiHsbqcxLchuCAnA)
			{
				SbiUAFWnRmpjAFAoZDqeINfnfeym = P_0.SbiUAFWnRmpjAFAoZDqeINfnfeym;
			}

			internal T GetController<T>() where T : Controller
			{
				if (SbiUAFWnRmpjAFAoZDqeINfnfeym == null)
				{
					return null;
				}
				return SbiUAFWnRmpjAFAoZDqeINfnfeym as T;
			}

			internal void SetController(Controller controller)
			{
				SbiUAFWnRmpjAFAoZDqeINfnfeym = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return UbPEUzNPchDLKDiHsbqcxLchuCAnA;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					chOFlNaznpzGmphgIheSqSuLPxUx(null);
				}
				else
				{
					chOFlNaznpzGmphgIheSqSuLPxUx(extension.UbPEUzNPchDLKDiHsbqcxLchuCAnA);
				}
			}

			private void chOFlNaznpzGmphgIheSqSuLPxUx(IControllerExtensionSource P_0)
			{
				UbPEUzNPchDLKDiHsbqcxLchuCAnA = P_0;
				SourceUpdated(UbPEUzNPchDLKDiHsbqcxLchuCAnA);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		[Serializable]
		private sealed class pfBEUAhjoCnSLWcNSTHXjBLDGzUYA
		{
			public static readonly pfBEUAhjoCnSLWcNSTHXjBLDGzUYA _003C_003E9 = new pfBEUAhjoCnSLWcNSTHXjBLDGzUYA();

			public static Func<Controller, Guid, bool> _003C_003E9__171_0;

			public static Func<Controller, Type, bool> _003C_003E9__174_0;

			internal bool SkMPBEqdhSHPPfQGQhPSSqwJqtRYA(Controller P_0, Guid P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}

			internal bool XJFDmpSwDhZnzTGAJVvOHFjtKFTm(Controller P_0, Type P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}
		}

		private sealed class pKlqTqUKPteKISFfIbouJWRGPEKJA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int AtSUBTclNYkkBBataoEUwsgxHYct;

			private ControllerPollingInfo MpBvtCZFtagtXCrcUNvkgNvfFvNvB;

			private int LJkdjZIbguOXmktaGwmmLpFgTbBBA;

			public Controller eDwCSOgoZRTHVQoekpuvpcxoBSvJA;

			private int vPnNrUyAyfxaOOWdjwNzENZoiIpP;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return MpBvtCZFtagtXCrcUNvkgNvfFvNvB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return MpBvtCZFtagtXCrcUNvkgNvfFvNvB;
				}
			}

			[DebuggerHidden]
			public pKlqTqUKPteKISFfIbouJWRGPEKJA(int P_0)
			{
				AtSUBTclNYkkBBataoEUwsgxHYct = P_0;
				LJkdjZIbguOXmktaGwmmLpFgTbBBA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				AtSUBTclNYkkBBataoEUwsgxHYct = -2;
			}

			private bool MoveNext()
			{
				int atSUBTclNYkkBBataoEUwsgxHYct = AtSUBTclNYkkBBataoEUwsgxHYct;
				Controller controller = eDwCSOgoZRTHVQoekpuvpcxoBSvJA;
				if (atSUBTclNYkkBBataoEUwsgxHYct != 0)
				{
					if (atSUBTclNYkkBBataoEUwsgxHYct != 1)
					{
						return false;
					}
					AtSUBTclNYkkBBataoEUwsgxHYct = -1;
					goto IL_00a0;
				}
				AtSUBTclNYkkBBataoEUwsgxHYct = -1;
				if (ReInput._id != controller.sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(controller.sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return false;
				}
				controller.UpdatePollingFrameTracking();
				vPnNrUyAyfxaOOWdjwNzENZoiIpP = 0;
				goto IL_00b0;
				IL_00b0:
				if (vPnNrUyAyfxaOOWdjwNzENZoiIpP < controller._buttonCount)
				{
					if (controller.HqEWVEHgQsOLNBhxnynvOxUJtEiN(vPnNrUyAyfxaOOWdjwNzENZoiIpP, out var num))
					{
						MpBvtCZFtagtXCrcUNvkgNvfFvNvB = new ControllerPollingInfo(true, -1, controller.id, controller._name, controller._type, ControllerElementType.Button, vPnNrUyAyfxaOOWdjwNzENZoiIpP, Pole.Positive, controller.asJEgTisjEcLUALQMOtkJoREArlC.GetElementIdentifierName(num), num, KeyboardKeyCode.None);
						AtSUBTclNYkkBBataoEUwsgxHYct = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				vPnNrUyAyfxaOOWdjwNzENZoiIpP++;
				goto IL_00b0;
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
				pKlqTqUKPteKISFfIbouJWRGPEKJA pKlqTqUKPteKISFfIbouJWRGPEKJA2;
				if (AtSUBTclNYkkBBataoEUwsgxHYct == -2 && LJkdjZIbguOXmktaGwmmLpFgTbBBA == Environment.CurrentManagedThreadId)
				{
					AtSUBTclNYkkBBataoEUwsgxHYct = 0;
					pKlqTqUKPteKISFfIbouJWRGPEKJA2 = this;
				}
				else
				{
					pKlqTqUKPteKISFfIbouJWRGPEKJA2 = new pKlqTqUKPteKISFfIbouJWRGPEKJA(0);
					pKlqTqUKPteKISFfIbouJWRGPEKJA2.eDwCSOgoZRTHVQoekpuvpcxoBSvJA = eDwCSOgoZRTHVQoekpuvpcxoBSvJA;
				}
				return pKlqTqUKPteKISFfIbouJWRGPEKJA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class EjyudnoNCrsviMDPpHxRvGagpBzP : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int nRPrcaujNfcNVkgXjDuzhWwQlgDs;

			private ControllerPollingInfo coLFYmGanDMljgNiCLHKfDLSkFfRB;

			private int JywjMOjEEUUHyVpExRLjxZzlOVhu;

			public Controller rFWNcWTbJiHJREcAwKqdEKwhutXxb;

			private int dNsfScKUvGTwKsJGuBnAJNBaVOuI;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return coLFYmGanDMljgNiCLHKfDLSkFfRB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return coLFYmGanDMljgNiCLHKfDLSkFfRB;
				}
			}

			[DebuggerHidden]
			public EjyudnoNCrsviMDPpHxRvGagpBzP(int P_0)
			{
				nRPrcaujNfcNVkgXjDuzhWwQlgDs = P_0;
				JywjMOjEEUUHyVpExRLjxZzlOVhu = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				nRPrcaujNfcNVkgXjDuzhWwQlgDs = -2;
			}

			private bool MoveNext()
			{
				int num = nRPrcaujNfcNVkgXjDuzhWwQlgDs;
				Controller controller = rFWNcWTbJiHJREcAwKqdEKwhutXxb;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					nRPrcaujNfcNVkgXjDuzhWwQlgDs = -1;
					goto IL_00a0;
				}
				nRPrcaujNfcNVkgXjDuzhWwQlgDs = -1;
				if (ReInput._id != controller.sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(controller.sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return false;
				}
				controller.UpdatePollingFrameTracking();
				dNsfScKUvGTwKsJGuBnAJNBaVOuI = 0;
				goto IL_00b0;
				IL_00b0:
				if (dNsfScKUvGTwKsJGuBnAJNBaVOuI < controller._buttonCount)
				{
					if (controller.fjvmRqFwBYejQhzLSKQryHsqpoFu(dNsfScKUvGTwKsJGuBnAJNBaVOuI, out var num2))
					{
						coLFYmGanDMljgNiCLHKfDLSkFfRB = new ControllerPollingInfo(true, -1, controller.id, controller._name, controller._type, ControllerElementType.Button, dNsfScKUvGTwKsJGuBnAJNBaVOuI, Pole.Positive, controller.asJEgTisjEcLUALQMOtkJoREArlC.GetElementIdentifierName(num2), num2, KeyboardKeyCode.None);
						nRPrcaujNfcNVkgXjDuzhWwQlgDs = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				dNsfScKUvGTwKsJGuBnAJNBaVOuI++;
				goto IL_00b0;
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
				EjyudnoNCrsviMDPpHxRvGagpBzP ejyudnoNCrsviMDPpHxRvGagpBzP;
				if (nRPrcaujNfcNVkgXjDuzhWwQlgDs == -2 && JywjMOjEEUUHyVpExRLjxZzlOVhu == Environment.CurrentManagedThreadId)
				{
					nRPrcaujNfcNVkgXjDuzhWwQlgDs = 0;
					ejyudnoNCrsviMDPpHxRvGagpBzP = this;
				}
				else
				{
					ejyudnoNCrsviMDPpHxRvGagpBzP = new EjyudnoNCrsviMDPpHxRvGagpBzP(0);
					ejyudnoNCrsviMDPpHxRvGagpBzP.rFWNcWTbJiHJREcAwKqdEKwhutXxb = rFWNcWTbJiHJREcAwKqdEKwhutXxb;
				}
				return ejyudnoNCrsviMDPpHxRvGagpBzP;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		public readonly int id;

		protected string _tag;

		protected string _name;

		private readonly DeviceLocalizationInfo AVveFjnIppvxrHQtccMVZHjQcylU;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid ZOYuKGMDLcxmBxqUbjaMwovvvKxG;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private readonly AList<Extension> nMWCJGFjnOfcXRQduBjSYVJYdwYjA;

		private readonly ReadOnlyCollection<Extension> vktYKJfBCabGzMrxHVIVCxbNVGFM;

		private bool kOpPOcxPEQJMutlNdxksmlTRkufw;

		private ControllerIdentifier CEVQivLFifdavUlhuGRpgzTKridwA;

		internal int sYoYcnbgceNmZCFbjxQoahCmBDVAA;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> EqUFAZeOHZsuHRmLJvzJpOGsEXQYA;

		private readonly ReadOnlyCollection<Element> OgRgjWJpyfvfziLhIarpzVcXxbIe;

		private readonly IList<CompoundElement> hrQoRMnKzvRhqxoQtBnjbZouUcMpA;

		private readonly ReadOnlyCollection<CompoundElement> TfdICBMtzCCWnqsLsJOzZHvOIFPr;

		[CustomObfuscation(rename = false)]
		internal readonly InputSource inputSource;

		internal readonly ControllerDataUpdater ONcPOmEPPyOeIZfvFoSEEYgzfzdq;

		internal readonly HardwareControllerMap_Game asJEgTisjEcLUALQMOtkJoREArlC;

		internal uint wmyEcDvlYTFxLcUQeWvNSsYNfIPj;

		private uint RAeIFohrltJBtdcnZbnwNZkocBkW;

		private uint frxSexbCyqecYblcwElOhJhkoCRKb;

		private ITryGetLocalizedName yGxajGIoWpeOYKStnpSNyRJmERCv;

		private readonly LocalizedString CsbpGUFniduTGbulTmuaXcMPImQl;

		private readonly XrjMaBYihmCVuHIhKxfdMqrzBSpBb mpXAZOGAXEVwEdgarAayotQaCnNd;

		private Action<bool> gLDXyYJZmTpUDMrXOwpLFnEGCLAHA;

		private IControllerTemplate[] bXMrvXuBAcJheQfsLwCmEBCeEsjU;

		private ReadOnlyCollection<IControllerTemplate> NEcnQawEhuqeQfQNEszUkoaImJPU;

		private static Func<Controller, Guid, bool> oeKeXPoBidlGRDPUTgZgdEgQZEqPA;

		private static Func<Controller, Type, bool> CsPVhRNxMkgQXzFqMmeZdELbzMXd;

		internal bool tubcdmauUlnJvKGCmrrEIOReOUTeA => RAeIFohrltJBtdcnZbnwNZkocBkW == ReInput.previousFrame;

		public bool enabled
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return false;
				}
				return kOpPOcxPEQJMutlNdxksmlTRkufw;
			}
			set
			{
				cTAoJOVqPUVvaYThibiPDfgKvVps(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return _name;
				}
				if (sApafBrlPvfITKLsYRODdywwCjxq != null && sApafBrlPvfITKLsYRODdywwCjxq.TryGetLocalizedName(out var value))
				{
					return value;
				}
				if (_type == ControllerType.Joystick && ZOYuKGMDLcxmBxqUbjaMwovvvKxG == Consts.joystickGuid_unknownController)
				{
					return _name;
				}
				if (AVveFjnIppvxrHQtccMVZHjQcylU == null || AVveFjnIppvxrHQtccMVZHjQcylU.parentKeys == null)
				{
					return _name;
				}
				LocalizationManager.GetAndUpdateLocalizedString(CsbpGUFniduTGbulTmuaXcMPImQl, (AVveFjnIppvxrHQtccMVZHjQcylU != null) ? AVveFjnIppvxrHQtccMVZHjQcylU.parentKeys : null, DTXBHoWlhfJgnmlLPGnqIDrGONgbA.jVcwLPFQfPrdeRZPNvwGoILxIRKu(_type), _name, out value);
				return value;
			}
			internal set
			{
				_name = text;
			}
		}

		public string tag
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				}
				else
				{
					_tag = value;
				}
			}
		}

		public string hardwareName
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return Guid.Empty;
				}
				return ZOYuKGMDLcxmBxqUbjaMwovvvKxG;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => CEVQivLFifdavUlhuGRpgzTKridwA;

		public bool isConnected
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				}
				else if (!flag)
				{
					Disconnected();
				}
				else
				{
					Connected();
				}
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return string.Empty;
				}
				return _hardwareIdentifier;
			}
		}

		public string mapTypeString => _type.ToString() + "Map";

		public int elementCount
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return 0;
				}
				return EqUFAZeOHZsuHRmLJvzJpOGsEXQYA.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return OgRgjWJpyfvfziLhIarpzVcXxbIe;
			}
		}

		public IList<CompoundElement> CompoundElements
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return EmptyObjects<CompoundElement>.EmptyReadOnlyIListT;
				}
				return TfdICBMtzCCWnqsLsJOzZHvOIFPr;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return null;
				}
				if (nMWCJGFjnOfcXRQduBjSYVJYdwYjA._count <= 0)
				{
					return null;
				}
				return nMWCJGFjnOfcXRQduBjSYVJYdwYjA._items[0];
			}
		}

		public IList<Extension> Extensions
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return null;
				}
				return vktYKJfBCabGzMrxHVIVCxbNVGFM;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return asJEgTisjEcLUALQMOtkJoREArlC.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return asJEgTisjEcLUALQMOtkJoREArlC.buttonElementIdentifiers_readOnly;
			}
		}

		internal ITryGetLocalizedName sApafBrlPvfITKLsYRODdywwCjxq
		{
			get
			{
				return yGxajGIoWpeOYKStnpSNyRJmERCv;
			}
			set
			{
				yGxajGIoWpeOYKStnpSNyRJmERCv = tryGetLocalizedName;
			}
		}

		internal DeviceLocalizationInfo YYqhJQBTSIjePzgqweWKYFRbFPQK => AVveFjnIppvxrHQtccMVZHjQcylU;

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return NEcnQawEhuqeQfQNEszUkoaImJPU;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return 0;
				}
				return bXMrvXuBAcJheQfsLwCmEBCeEsjU.Length;
			}
		}

		internal static Func<Controller, Guid, bool> jZUOBFvBIMVRtLTJXmRUKUzOItjN => pfBEUAhjoCnSLWcNSTHXjBLDGzUYA._003C_003E9.SkMPBEqdhSHPPfQGQhPSSqwJqtRYA;

		internal static Func<Controller, Type, bool> AuGsDAmpqetvxCgGqHfuTNlLHQWcA => pfBEUAhjoCnSLWcNSTHXjBLDGzUYA._003C_003E9.XJFDmpSwDhZnzTGAJVvOHFjtKFTm;

		internal event Action<bool> yMSMQOKECkxSEBpSrBiIfzDePoGuA
		{
			add
			{
				gLDXyYJZmTpUDMrXOwpLFnEGCLAHA = (Action<bool>)Delegate.Combine(gLDXyYJZmTpUDMrXOwpLFnEGCLAHA, b);
			}
			remove
			{
				gLDXyYJZmTpUDMrXOwpLFnEGCLAHA = (Action<bool>)Delegate.Remove(gLDXyYJZmTpUDMrXOwpLFnEGCLAHA, value2);
			}
		}

		internal Controller(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, bool[] P_8, HardwareButtonInfo[] P_9, HardwareControllerMap_Game P_10, IList<Extension> P_11, ControllerDataUpdater P_12)
		{
			id = P_0;
			inputSource = P_1;
			_type = P_5;
			ZOYuKGMDLcxmBxqUbjaMwovvvKxG = P_6;
			_buttonCount = P_7;
			_name = P_2;
			_hardwareName = P_3;
			_hardwareIdentifier = P_4;
			ONcPOmEPPyOeIZfvFoSEEYgzfzdq = P_12;
			asJEgTisjEcLUALQMOtkJoREArlC = P_10;
			AVveFjnIppvxrHQtccMVZHjQcylU = P_10.deviceLocalizationInfo;
			kOpPOcxPEQJMutlNdxksmlTRkufw = true;
			sYoYcnbgceNmZCFbjxQoahCmBDVAA = ReInput.id;
			CsbpGUFniduTGbulTmuaXcMPImQl = new LocalizedString();
			mpXAZOGAXEVwEdgarAayotQaCnNd = new XrjMaBYihmCVuHIhKxfdMqrzBSpBb(delegate
			{
				_ = name;
			});
			nMWCJGFjnOfcXRQduBjSYVJYdwYjA = new AList<Extension>();
			vktYKJfBCabGzMrxHVIVCxbNVGFM = new ReadOnlyCollection<Extension>(nMWCJGFjnOfcXRQduBjSYVJYdwYjA);
			if (P_11 != null)
			{
				List<Extension> list = new List<Extension>();
				for (int num = 0; num < P_11.Count; num++)
				{
					if (P_11[num] != null)
					{
						list.Add(P_11[num]);
					}
				}
				NsVRlEgogDQiygIylErHOFEGOius(list);
			}
			EqUFAZeOHZsuHRmLJvzJpOGsEXQYA = new List<Element>(P_7);
			OgRgjWJpyfvfziLhIarpzVcXxbIe = new ReadOnlyCollection<Element>(EqUFAZeOHZsuHRmLJvzJpOGsEXQYA);
			hrQoRMnKzvRhqxoQtBnjbZouUcMpA = new List<CompoundElement>();
			TfdICBMtzCCWnqsLsJOzZHvOIFPr = new ReadOnlyCollection<CompoundElement>(hrQoRMnKzvRhqxoQtBnjbZouUcMpA);
			buttons = new Button[P_7];
			if (P_8 == null || P_8.Length < P_7)
			{
				for (int num2 = 0; num2 < P_7; num2++)
				{
					buttons[num2] = new Button(this, P_10.buttonElementIdentifierIds[num2], "Button " + num2, false, (P_9 != null) ? P_9[num2] : new HardwareButtonInfo());
					jbFNagqnoAaxdDTrNPdAIsxqeCudA(buttons[num2]);
				}
			}
			else
			{
				for (int num3 = 0; num3 < P_7; num3++)
				{
					buttons[num3] = new Button(this, P_10.buttonElementIdentifierIds[num3], "Button " + num3, P_8[num3], (P_9 != null) ? P_9[num3] : new HardwareButtonInfo());
					jbFNagqnoAaxdDTrNPdAIsxqeCudA(buttons[num3]);
				}
			}
			buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
			bXMrvXuBAcJheQfsLwCmEBCeEsjU = EmptyObjects<IControllerTemplate>.array;
			NEcnQawEhuqeQfQNEszUkoaImJPU = new ReadOnlyCollection<IControllerTemplate>(bXMrvXuBAcJheQfsLwCmEBCeEsjU);
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((ChutGPBICOllLFbDwaPETGCPjnpCA)mpXAZOGAXEVwEdgarAayotQaCnNd).Localize();
			}
			Connected();
		}

		internal virtual void EPRdHvMTqwabaKQBybJMATOxbzNDb()
		{
			CEVQivLFifdavUlhuGRpgzTKridwA = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return null;
			}
			if (asJEgTisjEcLUALQMOtkJoREArlC == null)
			{
				return null;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return buttons[buttonIndex];
		}

		public virtual CompoundElement GetCompoundElementById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return null;
			}
			int count = hrQoRMnKzvRhqxoQtBnjbZouUcMpA.Count;
			for (int i = 0; i < count; i++)
			{
				if (hrQoRMnKzvRhqxoQtBnjbZouUcMpA[i] != null && hrQoRMnKzvRhqxoQtBnjbZouUcMpA[i].id == elementIdentifierId)
				{
					return hrQoRMnKzvRhqxoQtBnjbZouUcMpA[i];
				}
			}
			return null;
		}

		[Obsolete("This method is deprecated. Use GetCompoundElementById instead.", false)]
		public virtual CompoundElement GetCompundElementById(int elementIdentifierId)
		{
			return GetCompoundElementById(elementIdentifierId);
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return -1;
			}
			return asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return null;
			}
			return asJEgTisjEcLUALQMOtkJoREArlC.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].value;
		}

		public virtual bool GetButtonDown(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].justPressed;
		}

		public virtual bool GetButtonUp(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].justReleased;
		}

		public virtual bool GetButtonChanged(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].value != buttons[index].valuePrev;
		}

		public virtual bool GetButtonPrev(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].valuePrev;
		}

		public virtual bool GetButtonDoublePressHold(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDown(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].JustDoublePressed(speed);
		}

		public virtual double GetButtonTimePressed(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].timePressed;
		}

		public virtual double GetButtonTimeUnpressed(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressed(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressed(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].lastTimeUnpressed;
		}

		public virtual bool GetAnyButton()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].value)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonDown()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justPressed)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonUp()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justReleased)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonPrev()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].valuePrev)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonChanged()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justChangedState)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetButtonById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].value;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justReleased;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].JustDoublePressed(speed);
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].valuePrev;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimeUnpressed;
		}

		public virtual ControllerPollingInfo PollForFirstElement()
		{
			return PollForFirstButton();
		}

		public virtual ControllerPollingInfo PollForFirstElementDown()
		{
			return PollForFirstButtonDown();
		}

		public virtual ControllerPollingInfo PollForFirstButton()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (HqEWVEHgQsOLNBhxnynvOxUJtEiN(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, asJEgTisjEcLUALQMOtkJoREArlC.GetElementIdentifierName(num), num, KeyboardKeyCode.None);
				}
			}
			return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (fjvmRqFwBYejQhzLSKQryHsqpoFu(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, asJEgTisjEcLUALQMOtkJoREArlC.GetElementIdentifierName(num), num, KeyboardKeyCode.None);
				}
			}
			return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return PollForAllButtons();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return PollForAllButtonsDown();
		}

		[IteratorStateMachine(typeof(pKlqTqUKPteKISFfIbouJWRGPEKJA))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return new pKlqTqUKPteKISFfIbouJWRGPEKJA(-2)
			{
				eDwCSOgoZRTHVQoekpuvpcxoBSvJA = this
			};
		}

		[IteratorStateMachine(typeof(EjyudnoNCrsviMDPpHxRvGagpBzP))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return new EjyudnoNCrsviMDPpHxRvGagpBzP(-2)
			{
				rFWNcWTbJiHJREcAwKqdEKwhutXxb = this
			};
		}

		private bool HqEWVEHgQsOLNBhxnynvOxUJtEiN(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].BjdlHFTQJrxhMIisKGkRlDTqVcOt._excludeFromPolling)
			{
				return false;
			}
			P_1 = asJEgTisjEcLUALQMOtkJoREArlC.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool fjvmRqFwBYejQhzLSKQryHsqpoFu(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].BjdlHFTQJrxhMIisKGkRlDTqVcOt._excludeFromPolling)
			{
				return false;
			}
			P_1 = asJEgTisjEcLUALQMOtkJoREArlC.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (frxSexbCyqecYblcwElOhJhkoCRKb == ReInput.currentFrame)
			{
				return;
			}
			RAeIFohrltJBtdcnZbnwNZkocBkW = frxSexbCyqecYblcwElOhJhkoCRKb;
			frxSexbCyqecYblcwElOhJhkoCRKb = ReInput.currentFrame;
			if (!tubcdmauUlnJvKGCmrrEIOReOUTeA)
			{
				if (wmyEcDvlYTFxLcUQeWvNSsYNfIPj == uint.MaxValue)
				{
					wmyEcDvlYTFxLcUQeWvNSsYNfIPj = 0u;
				}
				else
				{
					wmyEcDvlYTFxLcUQeWvNSsYNfIPj++;
				}
			}
		}

		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (buttons == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < buttons.Length; i++)
			{
				double lastTimePressed = buttons[i].lastTimePressed;
				if (lastTimePressed > num)
				{
					num = lastTimePressed;
				}
			}
			return num;
		}

		public double GetLastTimeAnyButtonChanged()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (buttons == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < buttons.Length; i++)
			{
				double lastTimeStateChanged = buttons[i].lastTimeStateChanged;
				if (lastTimeStateChanged > num)
				{
					num = lastTimeStateChanged;
				}
			}
			return num;
		}

		public T GetExtension<T>() where T : class
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return null;
			}
			for (int i = 0; i < nMWCJGFjnOfcXRQduBjSYVJYdwYjA._count; i++)
			{
				if (nMWCJGFjnOfcXRQduBjSYVJYdwYjA._items[i] is T result)
				{
					return result;
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return null;
			}
			for (int i = 0; i < bXMrvXuBAcJheQfsLwCmEBCeEsjU.Length; i++)
			{
				if (bXMrvXuBAcJheQfsLwCmEBCeEsjU[i].typeGuid == typeGuid)
				{
					return bXMrvXuBAcJheQfsLwCmEBCeEsjU[i];
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return null;
			}
			for (int i = 0; i < bXMrvXuBAcJheQfsLwCmEBCeEsjU.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(bXMrvXuBAcJheQfsLwCmEBCeEsjU[i].GetType(), type))
				{
					return bXMrvXuBAcJheQfsLwCmEBCeEsjU[i];
				}
			}
			return null;
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return null;
			}
			for (int i = 0; i < bXMrvXuBAcJheQfsLwCmEBCeEsjU.Length; i++)
			{
				if (bXMrvXuBAcJheQfsLwCmEBCeEsjU[i] as T != null)
				{
					return bXMrvXuBAcJheQfsLwCmEBCeEsjU[i] as T;
				}
			}
			return null;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			for (int i = 0; i < bXMrvXuBAcJheQfsLwCmEBCeEsjU.Length; i++)
			{
				if (bXMrvXuBAcJheQfsLwCmEBCeEsjU[i].typeGuid == typeGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			for (int i = 0; i < bXMrvXuBAcJheQfsLwCmEBCeEsjU.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(bXMrvXuBAcJheQfsLwCmEBCeEsjU[i].GetType(), type))
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate<T>() where T : class
		{
			return ImplementsTemplate(typeof(T));
		}

		internal void aryxSEpAavcsYgmumKNcLtLkYTys(IControllerTemplate[] P_0)
		{
			if (P_0 != null)
			{
				bXMrvXuBAcJheQfsLwCmEBCeEsjU = P_0;
				NEcnQawEhuqeQfQNEszUkoaImJPU = new ReadOnlyCollection<IControllerTemplate>(bXMrvXuBAcJheQfsLwCmEBCeEsjU);
			}
		}

		internal virtual void fGrfHqFKGdZHGoihFnGZOueFayKBb(UpdateLoopType P_0)
		{
			bool num = ReInput.IsInputAllowed(_type);
			int num2 = _buttonCount;
			if (num)
			{
				for (int i = 0; i < num2; i++)
				{
					if (buttons[i].XKFTILODBvJFQuGAVPNSRJKpCJQfA <= 0)
					{
						buttons[i].ATotgcxEhwOfqwnIKjpCkFpDQrTgb(P_0, i, ONcPOmEPPyOeIZfvFoSEEYgzfzdq);
					}
				}
			}
			else
			{
				for (int j = 0; j < num2; j++)
				{
					if (buttons[j].XKFTILODBvJFQuGAVPNSRJKpCJQfA <= 0)
					{
						buttons[j].kuUKprDRyxDzWbelkjpDTcAAqxb(P_0);
					}
				}
			}
			for (int k = 0; k < nMWCJGFjnOfcXRQduBjSYVJYdwYjA._count; k++)
			{
				nMWCJGFjnOfcXRQduBjSYVJYdwYjA._items[k].UpdateData(P_0);
			}
		}

		internal virtual ButtonStateFlags TnONrQsOBfOBjJPGMiYehCJcLhfqA(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.Off;
			}
			return buttons[P_0].blYrwHjcWGpIqexNxMwIzJxuScdM;
		}

		internal void NsVRlEgogDQiygIylErHOFEGOius(IList<Extension> P_0)
		{
			if (P_0 == null || P_0.Count == 0)
			{
				nMWCJGFjnOfcXRQduBjSYVJYdwYjA.Clear();
				return;
			}
			if (nMWCJGFjnOfcXRQduBjSYVJYdwYjA._count > 0)
			{
				gmnIKmidQStVhXOPJVyNNFFBiTnA(P_0);
				return;
			}
			nMWCJGFjnOfcXRQduBjSYVJYdwYjA.Clear();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i] != null)
				{
					P_0[i].SetController(this);
					Extension extension = P_0[i].Clone();
					extension.SetController(this);
					nMWCJGFjnOfcXRQduBjSYVJYdwYjA.Add(extension);
				}
			}
		}

		internal void gmnIKmidQStVhXOPJVyNNFFBiTnA(IList<Extension> P_0)
		{
			if (P_0 == null || P_0.Count == 0)
			{
				NsVRlEgogDQiygIylErHOFEGOius(null);
			}
			else if (nMWCJGFjnOfcXRQduBjSYVJYdwYjA._count > 0)
			{
				List<Extension> list = new List<Extension>(P_0.Count);
				for (int i = 0; i < P_0.Count; i++)
				{
					if (P_0[i] == null)
					{
						continue;
					}
					P_0[i].SetController(this);
					if (i < nMWCJGFjnOfcXRQduBjSYVJYdwYjA._count)
					{
						if ((object)nMWCJGFjnOfcXRQduBjSYVJYdwYjA._items[i].GetType() == P_0[i].GetType())
						{
							Extension extension = nMWCJGFjnOfcXRQduBjSYVJYdwYjA._items[i];
							extension = nMWCJGFjnOfcXRQduBjSYVJYdwYjA._items[i];
							extension.SetSource(P_0[i]);
							extension.SetController(this);
							list.Add(extension);
						}
						else
						{
							Logger.LogError("Controller extension type mismatch.");
							Extension extension2 = P_0[i].Clone();
							extension2.SetController(this);
							list.Add(extension2);
						}
					}
					else
					{
						Extension extension3 = P_0[i].Clone();
						extension3.SetController(this);
						list.Add(extension3);
					}
				}
				nMWCJGFjnOfcXRQduBjSYVJYdwYjA.Clear();
				if (list.Count > 0)
				{
					for (int j = 0; j < list.Count; j++)
					{
						nMWCJGFjnOfcXRQduBjSYVJYdwYjA.Add(list[j]);
					}
				}
			}
			else
			{
				NsVRlEgogDQiygIylErHOFEGOius(P_0);
			}
		}

		internal virtual void DupAFRZPigDCXHzKZjcpbnZzkuAX()
		{
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i] != null)
				{
					buttons[i].Reset();
				}
			}
			if (ONcPOmEPPyOeIZfvFoSEEYgzfzdq != null)
			{
				ONcPOmEPPyOeIZfvFoSEEYgzfzdq.ClearData();
			}
			for (int j = 0; j < nMWCJGFjnOfcXRQduBjSYVJYdwYjA._count; j++)
			{
				nMWCJGFjnOfcXRQduBjSYVJYdwYjA[j].Clear();
			}
		}

		internal virtual bool cTAoJOVqPUVvaYThibiPDfgKvVps(bool P_0)
		{
			if (kOpPOcxPEQJMutlNdxksmlTRkufw == P_0)
			{
				return false;
			}
			if (!P_0)
			{
				DupAFRZPigDCXHzKZjcpbnZzkuAX();
			}
			kOpPOcxPEQJMutlNdxksmlTRkufw = P_0;
			if (gLDXyYJZmTpUDMrXOwpLFnEGCLAHA != null)
			{
				gLDXyYJZmTpUDMrXOwpLFnEGCLAHA(P_0);
			}
			return true;
		}

		internal virtual void fsGAmSubJncncJCvyCKmjBAMAvWb(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			try
			{
				ControllerMap.lRmYCoCSmOckdAxZaAzbXHOzxRbC();
				P_0.controllerId = id;
				IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
				for (int i = 0; i < buttonMaps.Count; i++)
				{
					duSGjNZdSxSjezvmjyDBFGtlyxPL(P_0, buttonMaps[i]);
				}
				for (int num = buttonMaps.Count - 1; num >= 0; num--)
				{
					if (buttonMaps[num].elementIndex < 0)
					{
						P_0.DeleteElementMap(buttonMaps[num].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc);
					}
				}
			}
			finally
			{
				ControllerMap.GHMgTTbTNZrCoRvrTvpOrmMMxTwr();
			}
		}

		internal virtual void duSGjNZdSxSjezvmjyDBFGtlyxPL(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null && P_1._elementType == ControllerElementType.Button)
			{
				P_1.ycFFstKtkKsMsNxRhfBwJdLUnnwbA(P_0);
			}
		}

		internal bool dAxaRiAAocDAlfxZGDsyWKSLbPxA(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int qCgFyaezumPcbmlbbJQsmzAMuLVpA = P_0.QCgFyaezumPcbmlbbJQsmzAMuLVpA;
			if (qCgFyaezumPcbmlbbJQsmzAMuLVpA < 0 || qCgFyaezumPcbmlbbJQsmzAMuLVpA >= _buttonCount)
			{
				return false;
			}
			P_3 = buttons[qCgFyaezumPcbmlbbJQsmzAMuLVpA].OKUzYcRerasUaNizMfRHlSACKwHQ;
			float num = ((!P_3) ? (buttons[qCgFyaezumPcbmlbbJQsmzAMuLVpA].value ? 1f : 0f) : buttons[qCgFyaezumPcbmlbbJQsmzAMuLVpA].pressure);
			if (num > 0f)
			{
				if (P_0._elementType == ControllerElementType.Button)
				{
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (P_0._elementType == ControllerElementType.Axis)
				{
					if (P_0._axisRange == AxisRange.Full)
					{
						if (P_0._invert)
						{
							num *= -1f;
						}
					}
					else if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
			}
			P_2 = num;
			return true;
		}

		internal bool FlTlruFcIfzQAHqgsXlUuWRqAJzc(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
		{
			P_3 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			float num = (P_2 ? 1f : 0f);
			if (num > 0f)
			{
				if (P_0._elementType == ControllerElementType.Button)
				{
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (P_0._elementType == ControllerElementType.Axis)
				{
					if (P_0._axisRange == AxisRange.Full)
					{
						if (P_0._invert)
						{
							num *= -1f;
						}
					}
					else if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
			}
			P_3 = num;
			return true;
		}

		internal void jbFNagqnoAaxdDTrNPdAIsxqeCudA(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(EqUFAZeOHZsuHRmLJvzJpOGsEXQYA, P_0);
			}
		}

		internal void QgistLJPkUBZJFNHMQHUkrpJtswfA(CompoundElement P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(hrQoRMnKzvRhqxoQtBnjbZouUcMpA, P_0);
			}
		}

		internal virtual Guid EIiVfzclkAphbnlIsIOpdSIroQcxA()
		{
			return Guid.Empty;
		}

		internal virtual void XcWhcMJqTFZzVMdmfmExVlrEKelfb(bool P_0)
		{
			if (!P_0 && !ReInput.IsInputAllowed(_type))
			{
				for (int i = 0; i < nMWCJGFjnOfcXRQduBjSYVJYdwYjA._count; i++)
				{
					nMWCJGFjnOfcXRQduBjSYVJYdwYjA._items[i].Clear();
				}
			}
		}

		protected virtual void Connected()
		{
			_isConnected = true;
		}

		protected virtual void Disconnected()
		{
			_isConnected = false;
			if (ONcPOmEPPyOeIZfvFoSEEYgzfzdq != null)
			{
				ONcPOmEPPyOeIZfvFoSEEYgzfzdq.ClearData();
			}
		}

		internal static void aDLiogQIHBJlBPBxqAjcLNigUgpx(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
			try
			{
				ControllerMap.lRmYCoCSmOckdAxZaAzbXHOzxRbC();
				XzLbAEtxLCUfuNtSsrNvhyZGTluw(P_0, P_1);
				foreach (ActionElementMap allMap in P_0.AllMaps)
				{
					allMap.KLfhzjPvIfhnxSyFcsESXqYtgsXEA(P_0, P_1);
				}
				AList<ActionElementMap> aList = P_0.hHYkHiBucOeDZcWyVzqWCcJcDXyr;
				for (int num = aList.Count - 1; num >= 0; num--)
				{
					if (aList[num].elementIndex < 0)
					{
						P_0.DeleteElementMap(aList[num].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc);
					}
				}
				if (!(P_0 is ControllerMapWithAxes { VIwCRfOqTkHNlTBczwmjQPsfbVkv: var aList2 }))
				{
					return;
				}
				for (int num2 = aList2.Count - 1; num2 >= 0; num2--)
				{
					if (aList2[num2].elementIndex < 0)
					{
						P_0.DeleteElementMap(aList2[num2].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc);
					}
				}
			}
			finally
			{
				ControllerMap.GHMgTTbTNZrCoRvrTvpOrmMMxTwr();
			}
		}

		internal static void XzLbAEtxLCUfuNtSsrNvhyZGTluw(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
			IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
			for (int i = 0; i < buttonMaps.Count; i++)
			{
				int elementIdentifierId = buttonMaps[i].elementIdentifierId;
				if (P_1.GetButtonIndex(elementIdentifierId) < 0 && P_1.GetAxisIndex(elementIdentifierId) >= 0)
				{
					P_0.lSVtRFqqPHdHEwrQYYNUzAfHnTgK(buttonMaps[i].id, ControllerElementType.Axis);
					buttonMaps[i]._axisRange = AxisRange.Positive;
					buttonMaps[i]._invert = false;
					i--;
				}
			}
			if (!(P_0 is ControllerMapWithAxes { AxisMaps: var axisMaps }))
			{
				return;
			}
			for (int j = 0; j < axisMaps.Count; j++)
			{
				int elementIdentifierId = axisMaps[j].elementIdentifierId;
				if (P_1.GetAxisIndex(elementIdentifierId) < 0 && P_1.GetButtonIndex(elementIdentifierId) >= 0)
				{
					P_0.lSVtRFqqPHdHEwrQYYNUzAfHnTgK(axisMaps[j].id, ControllerElementType.Button);
					j--;
				}
			}
		}

		[CompilerGenerated]
		private void pMVopbYTbQELxeIIobkixmihLNMx()
		{
			_ = name;
		}
	}
}
