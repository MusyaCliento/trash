using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public class PlayerController : IPlayerController
	{
		public class Definition
		{
			public bool enabled = true;

			public int playerId = -1;

			public ICollection<Element.Definition> elements;
		}

		public static class Factory
		{
			public static PlayerController Create(Definition definition)
			{
				return new PlayerController(definition);
			}
		}

		public enum AbsoluteToRelativeScalingMode
		{
			None = 0,
			ScreenWidth = 1,
			ScreenHeight = 2,
			MaxScreenDimension = 3,
			MinScreenDimension = 4,
			ViewportWidth = 5,
			ViewportHeight = 6,
			MaxViewportDimension = 7,
			MinViewportDimension = 8
		}

		public class Axis : ElementWithSource
		{
			public new class Definition : ElementWithSource.Definition
			{
				public AxisCoordinateMode coordinateMode;

				public float absoluteToRelativeSensitivity;

				public AbsoluteToRelativeScalingMode absoluteToRelativeScalingMode;

				public Definition()
				{
					coordinateMode = AxisCoordinateMode.Absolute;
					absoluteToRelativeSensitivity = 1f;
					absoluteToRelativeScalingMode = AbsoluteToRelativeScalingMode.None;
				}

				internal virtual Element QorEeTKYHiGYSxSwccuAqvdWGeAKA(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float IyGYaIvZahqxttCOqeBrpCDeKKgk = 1f;

			internal const AbsoluteToRelativeScalingMode JBmvkUYKEIEQaTgICMcBhgrGBCSK = AbsoluteToRelativeScalingMode.None;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float kBAQwACvNZMKgCfkueRbapenbXqBb = 1f;

			private AxisCoordinateMode ZjczqzqCiTdFOHszWNFtUCDtfYcYA;

			private AbsoluteToRelativeScalingMode aubfzLVFHsPmwMpIPnIqBaWBfrNy;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return kBAQwACvNZMKgCfkueRbapenbXqBb;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					kBAQwACvNZMKgCfkueRbapenbXqBb = value;
				}
			}

			public AbsoluteToRelativeScalingMode absoluteToRelativeScalingMode
			{
				get
				{
					return aubfzLVFHsPmwMpIPnIqBaWBfrNy;
				}
				set
				{
					aubfzLVFHsPmwMpIPnIqBaWBfrNy = value;
				}
			}

			public AxisCoordinateMode coordinateMode => ZjczqzqCiTdFOHszWNFtUCDtfYcYA;

			public virtual float value
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return 0f;
					}
					float num = base.player.GetAxis(base.actionId);
					switch (base.player.GetAxisCoordinateMode(base.actionId))
					{
					case AxisCoordinateMode.Relative:
						if (ZjczqzqCiTdFOHszWNFtUCDtfYcYA == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
						break;
					case AxisCoordinateMode.Absolute:
						if (ZjczqzqCiTdFOHszWNFtUCDtfYcYA == AxisCoordinateMode.Relative)
						{
							switch (aubfzLVFHsPmwMpIPnIqBaWBfrNy)
							{
							case AbsoluteToRelativeScalingMode.ScreenHeight:
								num *= (float)Screen.currentResolution.height / absoluteToRelativeScalingReferenceResolution.y;
								break;
							case AbsoluteToRelativeScalingMode.ScreenWidth:
								num *= (float)Screen.currentResolution.width / absoluteToRelativeScalingReferenceResolution.x;
								break;
							case AbsoluteToRelativeScalingMode.ViewportHeight:
								num *= (float)Screen.height / absoluteToRelativeScalingReferenceResolution.y;
								break;
							case AbsoluteToRelativeScalingMode.ViewportWidth:
								num *= (float)Screen.width / absoluteToRelativeScalingReferenceResolution.x;
								break;
							case AbsoluteToRelativeScalingMode.MaxScreenDimension:
								num = ((Screen.currentResolution.width < Screen.currentResolution.height) ? (num * ((float)Screen.currentResolution.height / absoluteToRelativeScalingReferenceResolution.y)) : (num * ((float)Screen.currentResolution.width / absoluteToRelativeScalingReferenceResolution.x)));
								break;
							case AbsoluteToRelativeScalingMode.MinScreenDimension:
								num = ((Screen.currentResolution.width > Screen.currentResolution.height) ? (num * ((float)Screen.currentResolution.height / absoluteToRelativeScalingReferenceResolution.y)) : (num * ((float)Screen.currentResolution.width / absoluteToRelativeScalingReferenceResolution.x)));
								break;
							case AbsoluteToRelativeScalingMode.MaxViewportDimension:
								num = ((Screen.width < Screen.height) ? (num * ((float)Screen.height / absoluteToRelativeScalingReferenceResolution.y)) : (num * ((float)Screen.width / absoluteToRelativeScalingReferenceResolution.x)));
								break;
							case AbsoluteToRelativeScalingMode.MinViewportDimension:
								num = ((Screen.width > Screen.height) ? (num * ((float)Screen.height / absoluteToRelativeScalingReferenceResolution.y)) : (num * ((float)Screen.width / absoluteToRelativeScalingReferenceResolution.x)));
								break;
							}
							num *= (float)ReInput.unscaledDeltaTime * kBAQwACvNZMKgCfkueRbapenbXqBb;
						}
						break;
					}
					return num;
				}
			}

			public virtual float valueRaw
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return 0f;
					}
					return base.player.GetAxisRaw(base.actionId);
				}
			}

			internal Axis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				kBAQwACvNZMKgCfkueRbapenbXqBb = P_1.absoluteToRelativeSensitivity;
				ZjczqzqCiTdFOHszWNFtUCDtfYcYA = P_1.coordinateMode;
				aubfzLVFHsPmwMpIPnIqBaWBfrNy = P_1.absoluteToRelativeScalingMode;
			}
		}

		public class MouseAxis : Axis
		{
			public new class Definition : Axis.Definition
			{
				public Definition()
				{
					coordinateMode = AxisCoordinateMode.Relative;
					absoluteToRelativeSensitivity = 600f;
					absoluteToRelativeScalingMode = AbsoluteToRelativeScalingMode.ScreenWidth;
				}

				internal virtual Element GAAiPBQbTikEIVJiwLZyjruXmPpO(PlayerController P_0)
				{
					return new MouseAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			[CustomObfuscation(rename = false)]
			internal const float defaultAbsoluteToRelativeSensitivity = 600f;

			[CustomObfuscation(rename = false)]
			internal const AbsoluteToRelativeScalingMode defaultAbsoluteToRelativeScalingMode = AbsoluteToRelativeScalingMode.ScreenWidth;

			internal MouseAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
			}
		}

		public class Axis2D : CompoundElement
		{
			public new class Definition : CompoundElement.Definition
			{
				private Axis.Definition yJqgiThiMwWjTdXqOtNgXSStElWe;

				private Axis.Definition HIvPqfLlzPGfAIJCNfvDvLOneEdBb;

				public Axis.Definition xAxis
				{
					get
					{
						return yJqgiThiMwWjTdXqOtNgXSStElWe;
					}
					set
					{
						yJqgiThiMwWjTdXqOtNgXSStElWe = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return HIvPqfLlzPGfAIJCNfvDvLOneEdBb;
					}
					set
					{
						HIvPqfLlzPGfAIJCNfvDvLOneEdBb = value;
					}
				}

				internal virtual Element WCwipfkBJdITpBUFDwDsEGkiNsiKb(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int RZKGrboFdmuAkBevfHZUtElJPklA = 0;

			internal const int UgXGuAlUDPIuaGntUCPQLGUFcjaoA = 1;

			internal const int LCiGzSgsVfStAINGQtONuOuFnZNoA = 2;

			public Axis xAxis => cbkiOTkGIGcTnTfAEjEdONyHalGx<Axis>(0);

			public Axis yAxis => cbkiOTkGIGcTnTfAEjEdONyHalGx<Axis>(1);

			public virtual Vector2 value => new Vector2(cbkiOTkGIGcTnTfAEjEdONyHalGx<Axis>(0).value, cbkiOTkGIGcTnTfAEjEdONyHalGx<Axis>(1).value);

			public virtual Vector2 valueRaw => new Vector2(cbkiOTkGIGcTnTfAEjEdONyHalGx<Axis>(0).valueRaw, cbkiOTkGIGcTnTfAEjEdONyHalGx<Axis>(1).valueRaw);

			internal Axis2D(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(P_0, P_1, P_2)
			{
			}

			internal Axis2D(PlayerController P_0, Definition P_1)
				: base(P_0, P_1, (P_1 == null) ? null : new Element.Definition[2]
				{
					(P_1.xAxis != null) ? P_1.xAxis : new Axis.Definition(),
					(P_1.yAxis != null) ? P_1.yAxis : new Axis.Definition()
				})
			{
			}
		}

		public sealed class MouseAxis2D : Axis2D
		{
			public new class Definition : Axis2D.Definition
			{
				public new MouseAxis.Definition xAxis
				{
					get
					{
						return base.xAxis as MouseAxis.Definition;
					}
					set
					{
						base.xAxis = value;
					}
				}

				public new MouseAxis.Definition yAxis
				{
					get
					{
						return base.yAxis as MouseAxis.Definition;
					}
					set
					{
						base.yAxis = value;
					}
				}

				internal virtual Element WbezEmiVNjJIpvLvvyqNEVnCradH(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis => cbkiOTkGIGcTnTfAEjEdONyHalGx<MouseAxis>(0);

			public new MouseAxis yAxis => cbkiOTkGIGcTnTfAEjEdONyHalGx<MouseAxis>(1);

			internal MouseAxis2D(PlayerController P_0, Definition P_1)
				: base(P_0, P_1, (P_1 == null) ? null : new Element.Definition[2]
				{
					(P_1.xAxis != null) ? P_1.xAxis : new MouseAxis.Definition(),
					(P_1.yAxis != null) ? P_1.yAxis : new MouseAxis.Definition()
				})
			{
			}
		}

		public sealed class Button : ElementWithSource
		{
			public new class Definition : ElementWithSource.Definition
			{
				internal virtual Element zRhyCpiORtwgPlfZqUtgFrnakhSX(PlayerController P_0)
				{
					return new Button(P_0, this);
				}
			}

			public bool value
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return false;
					}
					return base.player.GetButton(base.actionId);
				}
			}

			public bool valuePrev
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return false;
					}
					return base.player.GetButtonPrev(base.actionId);
				}
			}

			public bool justPressed
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return false;
					}
					return base.player.GetButtonDown(base.actionId);
				}
			}

			public bool justReleased
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return false;
					}
					return base.player.GetButtonUp(base.actionId);
				}
			}

			internal Button(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
			}
		}

		public abstract class CompoundElement : Element
		{
			public new abstract class Definition : Element.Definition
			{
				public Definition()
				{
				}
			}

			private readonly List<Element> eGqvsiwHSsvRsOvPMLvuXLUjXDkO;

			internal int sBZzacnQzfKJayrtjDSfcyJcQvPE => eGqvsiwHSsvRsOvPMLvuXLUjXDkO.Count;

			internal CompoundElement(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(P_0, P_1)
			{
				eGqvsiwHSsvRsOvPMLvuXLUjXDkO = new List<Element>();
				if (P_2 == null)
				{
					return;
				}
				for (int i = 0; i < P_2.Length; i++)
				{
					if (P_2[i] != null)
					{
						ShDGCzCEOwWhDGDdlniCsvrmVnED(P_2[i].GvCIORqnGAPkjIeHqjOSdbeWmKqn(P_0));
					}
				}
			}

			internal _0001 cbkiOTkGIGcTnTfAEjEdONyHalGx<_0001>(int P_0) where _0001 : Element
			{
				if ((uint)P_0 >= (uint)eGqvsiwHSsvRsOvPMLvuXLUjXDkO.Count)
				{
					return null;
				}
				return eGqvsiwHSsvRsOvPMLvuXLUjXDkO[P_0] as _0001;
			}

			internal void nVbiVjbSdaTZBzuQysXrKnwRsOck(List<Element> P_0)
			{
				for (int i = 0; i < eGqvsiwHSsvRsOvPMLvuXLUjXDkO.Count; i++)
				{
					if (eGqvsiwHSsvRsOvPMLvuXLUjXDkO[i] is CompoundElement)
					{
						(eGqvsiwHSsvRsOvPMLvuXLUjXDkO[i] as CompoundElement).nVbiVjbSdaTZBzuQysXrKnwRsOck(P_0);
					}
					else
					{
						P_0.Add(eGqvsiwHSsvRsOvPMLvuXLUjXDkO[i]);
					}
				}
			}

			internal void ShDGCzCEOwWhDGDdlniCsvrmVnED(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				eGqvsiwHSsvRsOvPMLvuXLUjXDkO.Add(P_0);
				P_0.witGigCupAMPlWQDDorgBZKeIMHA = true;
			}
		}

		public abstract class Element
		{
			[CustomObfuscation(rename = false)]
			internal enum Type
			{
				[CustomObfuscation(rename = false)]
				Button = 0,
				[CustomObfuscation(rename = false)]
				Axis = 1,
				[CustomObfuscation(rename = false)]
				MouseAxis = 2,
				[CustomObfuscation(rename = false)]
				MouseWheelAxis = 3,
				[CustomObfuscation(rename = false)]
				Axis2D = 100,
				[CustomObfuscation(rename = false)]
				MouseAxis2D = 101,
				[CustomObfuscation(rename = false)]
				MouseWheel = 102
			}

			[CustomObfuscation(rename = false)]
			internal enum TypeWithSource
			{
				[CustomObfuscation(rename = false)]
				Button = 0,
				[CustomObfuscation(rename = false)]
				Axis = 1,
				[CustomObfuscation(rename = false)]
				MouseAxis = 2,
				[CustomObfuscation(rename = false)]
				MouseWheelAxis = 3
			}

			[CustomObfuscation(rename = false)]
			internal enum CompoundTypes
			{
				[CustomObfuscation(rename = false)]
				Axis2D = 100,
				[CustomObfuscation(rename = false)]
				MouseAxis2D = 101,
				[CustomObfuscation(rename = false)]
				MouseWheel = 102
			}

			public abstract class Definition
			{
				public bool enabled;

				public string name;

				public Definition()
				{
					enabled = true;
					name = null;
				}

				internal abstract Element GvCIORqnGAPkjIeHqjOSdbeWmKqn(PlayerController P_0);
			}

			internal struct pvBbFOcmNfKEHBCNPWlJTLccMcUgb
			{
				public ControllerElementType droLMyjeWcBbQFkQTyaNlEcZNGYFA;

				public int OOzhqANSoRaohqhJBonDnXdtfZsD;

				public float QPNuVuOoZZYpzdQvMRAkODqRjWHc;

				public pvBbFOcmNfKEHBCNPWlJTLccMcUgb(ControllerElementType P_0, int P_1, float P_2)
				{
					droLMyjeWcBbQFkQTyaNlEcZNGYFA = P_0;
					OOzhqANSoRaohqhJBonDnXdtfZsD = P_1;
					QPNuVuOoZZYpzdQvMRAkODqRjWHc = P_2;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController OlUDlouXxMidbfgkETRQPMQcXPYy;

			private bool zwgXUumVrNcAVvdAMSHpZnyZFfrIA;

			private bool mbAMDAFfCJgTVadXWRtRoZioERvN = true;

			private string pGNGRmVcBclffCoZZrPYQYiiWeUE;

			private static int[] kpGclztPgMZQQuhaDTuVPaufDCdgA;

			private static int[] ooDDuaIQEzUlhXPYMJjRsqcJBIpF;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(OlUDlouXxMidbfgkETRQPMQcXPYy.psdmxnSlvUTdOjviRrFezlTyKoTp);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (mbAMDAFfCJgTVadXWRtRoZioERvN)
					{
						return OlUDlouXxMidbfgkETRQPMQcXPYy.RjJaKLTNSYKUbOPyoeKFbWvEtUpgA;
					}
					return false;
				}
			}

			internal bool witGigCupAMPlWQDDorgBZKeIMHA
			{
				get
				{
					return zwgXUumVrNcAVvdAMSHpZnyZFfrIA;
				}
				set
				{
					zwgXUumVrNcAVvdAMSHpZnyZFfrIA = true;
				}
			}

			public bool enabled
			{
				get
				{
					return mbAMDAFfCJgTVadXWRtRoZioERvN;
				}
				set
				{
					if (mbAMDAFfCJgTVadXWRtRoZioERvN != value)
					{
						mbAMDAFfCJgTVadXWRtRoZioERvN = value;
						EnabledStateChanged(value);
					}
				}
			}

			public string name
			{
				get
				{
					return pGNGRmVcBclffCoZZrPYQYiiWeUE;
				}
				set
				{
					pGNGRmVcBclffCoZZrPYQYiiWeUE = value;
				}
			}

			internal Element(PlayerController P_0, Definition P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("definition");
				}
				OlUDlouXxMidbfgkETRQPMQcXPYy = P_0;
				mbAMDAFfCJgTVadXWRtRoZioERvN = P_1.enabled;
				pGNGRmVcBclffCoZZrPYQYiiWeUE = P_1.name;
			}

			internal virtual void sKWWGpbggpVHinsymSnLJPXSWYAp()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				if (kpGclztPgMZQQuhaDTuVPaufDCdgA == null)
				{
					kpGclztPgMZQQuhaDTuVPaufDCdgA = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(kpGclztPgMZQQuhaDTuVPaufDCdgA, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (ooDDuaIQEzUlhXPYMJjRsqcJBIpF == null)
				{
					ooDDuaIQEzUlhXPYMJjRsqcJBIpF = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(ooDDuaIQEzUlhXPYMJjRsqcJBIpF, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static int GetMaxElementCount(Type type)
			{
				if (IsTypeWithSource(type))
				{
					return 1;
				}
				if (IsCompoundType(type))
				{
					return type switch
					{
						Type.Axis2D => 2, 
						Type.MouseAxis2D => 2, 
						Type.MouseWheel => 2, 
						_ => throw new NotImplementedException(), 
					};
				}
				throw new NotImplementedException();
			}

			[CustomObfuscation(rename = false)]
			internal static string GetElementTitle(Type type, int index)
			{
				if (index < 0 || index > GetMaxElementCount(type))
				{
					return null;
				}
				if (IsTypeWithSource(type))
				{
					return null;
				}
				if (IsCompoundType(type))
				{
					if ((uint)(type - 100) <= 2u)
					{
						if (index != 0)
						{
							return "Y Axis";
						}
						return "X Axis";
					}
					throw new NotImplementedException();
				}
				throw new NotImplementedException();
			}

			[CustomObfuscation(rename = false)]
			internal static Definition CreateDefinition(Type type)
			{
				return type switch
				{
					Type.Axis => new Axis.Definition(), 
					Type.Button => new Button.Definition(), 
					Type.MouseAxis => new MouseAxis.Definition(), 
					Type.MouseWheelAxis => new MouseWheelAxis.Definition(), 
					Type.Axis2D => new Axis2D.Definition(), 
					Type.MouseAxis2D => new MouseAxis2D.Definition(), 
					Type.MouseWheel => new MouseWheel.Definition(), 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		public abstract class ElementWithSource : Element
		{
			public new abstract class Definition : Element.Definition
			{
				private int JkUEPXAbMuTOTeIOvurqhOYjUSLx;

				public int actionId
				{
					get
					{
						return JkUEPXAbMuTOTeIOvurqhOYjUSLx;
					}
					set
					{
						JkUEPXAbMuTOTeIOvurqhOYjUSLx = value;
					}
				}

				public string actionName
				{
					get
					{
						if (!ReInput.isReady || JkUEPXAbMuTOTeIOvurqhOYjUSLx < 0)
						{
							return null;
						}
						return ReInput.mapping.GetAction(JkUEPXAbMuTOTeIOvurqhOYjUSLx)?.name;
					}
					set
					{
						if (!ReInput.isReady)
						{
							Logger.LogError("You cannot set an Action Name because Rewired has not been intialized.");
							return;
						}
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							JkUEPXAbMuTOTeIOvurqhOYjUSLx = -1;
						}
						else
						{
							JkUEPXAbMuTOTeIOvurqhOYjUSLx = action.id;
						}
					}
				}

				public Definition()
				{
					JkUEPXAbMuTOTeIOvurqhOYjUSLx = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int oOTeBwDzsiJSyGTTUlaFYjgmeixi = -1;

			public int actionId
			{
				get
				{
					return oOTeBwDzsiJSyGTTUlaFYjgmeixi;
				}
				set
				{
					oOTeBwDzsiJSyGTTUlaFYjgmeixi = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || oOTeBwDzsiJSyGTTUlaFYjgmeixi < 0)
					{
						return null;
					}
					return ReInput.mapping.GetAction(oOTeBwDzsiJSyGTTUlaFYjgmeixi)?.name;
				}
				set
				{
					if (ReInput.isReady)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							oOTeBwDzsiJSyGTTUlaFYjgmeixi = -1;
						}
						else
						{
							oOTeBwDzsiJSyGTTUlaFYjgmeixi = action.id;
						}
					}
				}
			}

			internal ElementWithSource(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				oOTeBwDzsiJSyGTTUlaFYjgmeixi = P_1.actionId;
			}
		}

		public sealed class MouseWheel : Axis2D
		{
			public new class Definition : Axis2D.Definition
			{
				public new MouseWheelAxis.Definition xAxis
				{
					get
					{
						return base.xAxis as MouseWheelAxis.Definition;
					}
					set
					{
						base.xAxis = value;
					}
				}

				public new MouseWheelAxis.Definition yAxis
				{
					get
					{
						return base.yAxis as MouseWheelAxis.Definition;
					}
					set
					{
						base.yAxis = value;
					}
				}

				internal virtual Element EBoXfUNHMcTokRWzKXvPrKQYTpJh(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis => cbkiOTkGIGcTnTfAEjEdONyHalGx<MouseWheelAxis>(0);

			public new MouseWheelAxis yAxis => cbkiOTkGIGcTnTfAEjEdONyHalGx<MouseWheelAxis>(1);

			internal MouseWheel(PlayerController P_0, Definition P_1)
				: base(P_0, P_1, (P_1 == null) ? null : new Element.Definition[2]
				{
					(P_1.xAxis != null) ? P_1.xAxis : new MouseWheelAxis.Definition(),
					(P_1.yAxis != null) ? P_1.yAxis : new MouseWheelAxis.Definition()
				})
			{
			}
		}

		public sealed class MouseWheelAxis : Axis
		{
			public new class Definition : Axis.Definition
			{
				public float repeatRate;

				public Definition()
				{
					coordinateMode = AxisCoordinateMode.Relative;
					repeatRate = 4f;
				}

				internal virtual Element oRurmUhUdcACTURSvvLrIZQHyUYb(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float JaHPnbSAuoCbaxQSyLMRadTnajTb = 0.01f;

			private float MVuznHJuKufUBzyuwmOIRxuoDUJC = 0.25f;

			private double hHgZZxOtibZFKbgJzwPduUkyNbhG;

			private float gnACpTHwYetoenbMzWzqKirZgfmYA;

			public float repeatRate
			{
				get
				{
					if (MVuznHJuKufUBzyuwmOIRxuoDUJC == 0f)
					{
						return 0f;
					}
					return 1f / MVuznHJuKufUBzyuwmOIRxuoDUJC;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (value == 0f)
					{
						MVuznHJuKufUBzyuwmOIRxuoDUJC = 0f;
					}
					else
					{
						MVuznHJuKufUBzyuwmOIRxuoDUJC = 1f / value;
					}
				}
			}

			float Axis.value
			{
				get
				{
					if (!base.selfAndParentEnabled)
					{
						return 0f;
					}
					return gnACpTHwYetoenbMzWzqKirZgfmYA;
				}
			}

			internal MouseWheelAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				repeatRate = P_1.repeatRate;
			}

			internal void cGaoGLRAkEsvbFJIuFGsgASnmovaA()
			{
				base.sKWWGpbggpVHinsymSnLJPXSWYAp();
				if (base.selfAndParentEnabled)
				{
					gnACpTHwYetoenbMzWzqKirZgfmYA = uDnsKZHeAxiJChLMOqxJMNUDjEks();
				}
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					FKLsjSlqGlgFuouCZIOgUjkJaWQG();
				}
			}

			private float uDnsKZHeAxiJChLMOqxJMNUDjEks()
			{
				if (base.player == null)
				{
					return 0f;
				}
				float num = base.player.GetAxis(base.actionId);
				switch (base.player.GetAxisCoordinateMode(base.actionId))
				{
				case AxisCoordinateMode.Absolute:
				{
					bool flag = false;
					if (base.player.GetButtonDown(base.actionId))
					{
						flag = true;
						num = 1f;
					}
					if (base.player.GetNegativeButtonDown(base.actionId))
					{
						flag = true;
						num = -1f;
					}
					if (!flag && ReInput.unscaledTime < hHgZZxOtibZFKbgJzwPduUkyNbhG + (double)MVuznHJuKufUBzyuwmOIRxuoDUJC)
					{
						return 0f;
					}
					if (Mathf.Abs(num) <= 0.01f)
					{
						return 0f;
					}
					num = Mathf.Sign(num);
					num *= base.absoluteToRelativeSensitivity;
					hHgZZxOtibZFKbgJzwPduUkyNbhG = ReInput.unscaledTime;
					break;
				}
				}
				return num;
			}

			private void FKLsjSlqGlgFuouCZIOgUjkJaWQG()
			{
				gnACpTHwYetoenbMzWzqKirZgfmYA = 0f;
				hHgZZxOtibZFKbgJzwPduUkyNbhG = 0.0;
			}
		}

		internal readonly int gOVUDrtcXNqvkQTIYRMOHbOuODPg;

		private bool RjJaKLTNSYKUbOPyoeKFbWvEtUpgA;

		private int psdmxnSlvUTdOjviRrFezlTyKoTp;

		private readonly AList<Element> QMKQgDebBffRWvvKPpyHQVcrPnKc;

		private readonly AList<Button> EaOPFBDXtJKJpTErbykCLGiXhUEK;

		private readonly AList<Axis> xVoUZYivvGXoRgheNCagwJfTsAAg;

		private readonly ReadOnlyCollection<Element> ImLdUACfvoXtkslrmEdGGNPhHUOLc;

		private readonly ReadOnlyCollection<Button> MGPrTyVqwtFXJAfVphGDfWLjVpABb;

		private readonly ReadOnlyCollection<Axis> iFhngfoAxJHDJTOKhdvPtVAPHlJAA;

		private readonly List<Element.pvBbFOcmNfKEHBCNPWlJTLccMcUgb> RWkRRlsGPrizJIlNBhhhNnkWcMEFA;

		private Action<int, bool> ucbvMaxaNihgXSHehFQkAkJugCEHb;

		private Action<int, float> HLYeLHvjEqWLgzzfBfztMdyseJtZ;

		private Action<bool> CUJihPOyCfkidMcjbsKYfOddhXDP;

		private static Vector2 ABugysQQDqIsiyhjQsinHOUiDysz = new Vector2(1920f, 1080f);

		bool IPlayerController.enabled
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return false;
				}
				return RjJaKLTNSYKUbOPyoeKFbWvEtUpgA;
			}
			set
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
				}
				else
				{
					if (RjJaKLTNSYKUbOPyoeKFbWvEtUpgA == value)
					{
						return;
					}
					if (!value)
					{
						ClearVars();
					}
					RjJaKLTNSYKUbOPyoeKFbWvEtUpgA = value;
					for (int i = 0; i < QMKQgDebBffRWvvKPpyHQVcrPnKc._count; i++)
					{
						QMKQgDebBffRWvvKPpyHQVcrPnKc[i].enabled = value;
					}
					if (CUJihPOyCfkidMcjbsKYfOddhXDP != null)
					{
						try
						{
							CUJihPOyCfkidMcjbsKYfOddhXDP(value);
						}
						catch (Exception ex)
						{
							Logger.LogError("An exception occurred in a listener of EnabledStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
						}
					}
				}
			}
		}

		int IPlayerController.playerId
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return -1;
				}
				return psdmxnSlvUTdOjviRrFezlTyKoTp;
			}
			set
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
				}
				else if (psdmxnSlvUTdOjviRrFezlTyKoTp != value)
				{
					psdmxnSlvUTdOjviRrFezlTyKoTp = value;
					ClearVars();
				}
			}
		}

		IList<Button> IPlayerController.buttons
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return null;
				}
				return MGPrTyVqwtFXJAfVphGDfWLjVpABb;
			}
		}

		IList<Axis> IPlayerController.axes
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return null;
				}
				return iFhngfoAxJHDJTOKhdvPtVAPHlJAA;
			}
		}

		IList<Element> IPlayerController.elements
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return null;
				}
				return ImLdUACfvoXtkslrmEdGGNPhHUOLc;
			}
		}

		int IPlayerController.buttonCount
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return 0;
				}
				if (EaOPFBDXtJKJpTErbykCLGiXhUEK == null)
				{
					return 0;
				}
				return EaOPFBDXtJKJpTErbykCLGiXhUEK._count;
			}
		}

		int IPlayerController.axisCount
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return 0;
				}
				if (xVoUZYivvGXoRgheNCagwJfTsAAg == null)
				{
					return 0;
				}
				return xVoUZYivvGXoRgheNCagwJfTsAAg._count;
			}
		}

		int IPlayerController.elementCount
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return 0;
				}
				if (QMKQgDebBffRWvvKPpyHQVcrPnKc == null)
				{
					return 0;
				}
				return QMKQgDebBffRWvvKPpyHQVcrPnKc._count;
			}
		}

		internal Player uRHlXwXpyQnNeDKkeJiaPfQPdYgbA
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(Rewired_002EIPlayerController_002EplayerId);
			}
		}

		public static Vector2 absoluteToRelativeScalingReferenceResolution
		{
			get
			{
				return ABugysQQDqIsiyhjQsinHOUiDysz;
			}
			set
			{
				if (value.x < 1f)
				{
					value.x = 1f;
				}
				if (value.y < 1f)
				{
					value.y = 1f;
				}
				ABugysQQDqIsiyhjQsinHOUiDysz = value;
			}
		}

		event Action<int, bool> IPlayerController.ButtonStateChangedEvent
		{
			add
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
				}
				else
				{
					ucbvMaxaNihgXSHehFQkAkJugCEHb = (Action<int, bool>)Delegate.Combine(ucbvMaxaNihgXSHehFQkAkJugCEHb, value);
				}
			}
			remove
			{
				ucbvMaxaNihgXSHehFQkAkJugCEHb = (Action<int, bool>)Delegate.Remove(ucbvMaxaNihgXSHehFQkAkJugCEHb, value);
			}
		}

		event Action<int, float> IPlayerController.AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
				}
				else
				{
					HLYeLHvjEqWLgzzfBfztMdyseJtZ = (Action<int, float>)Delegate.Combine(HLYeLHvjEqWLgzzfBfztMdyseJtZ, value);
				}
			}
			remove
			{
				HLYeLHvjEqWLgzzfBfztMdyseJtZ = (Action<int, float>)Delegate.Remove(HLYeLHvjEqWLgzzfBfztMdyseJtZ, value);
			}
		}

		event Action<bool> IPlayerController.EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
				}
				else
				{
					CUJihPOyCfkidMcjbsKYfOddhXDP = (Action<bool>)Delegate.Combine(CUJihPOyCfkidMcjbsKYfOddhXDP, value);
				}
			}
			remove
			{
				CUJihPOyCfkidMcjbsKYfOddhXDP = (Action<bool>)Delegate.Remove(CUJihPOyCfkidMcjbsKYfOddhXDP, value);
			}
		}

		internal PlayerController(Definition P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("definition");
			}
			if (P_0.elements == null)
			{
				throw new ArgumentNullException("definition.elements");
			}
			gOVUDrtcXNqvkQTIYRMOHbOuODPg = ReInput._id;
			psdmxnSlvUTdOjviRrFezlTyKoTp = P_0.playerId;
			RjJaKLTNSYKUbOPyoeKFbWvEtUpgA = P_0.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in P_0.elements)
			{
				ofjOmHUvrybPVorjGoNyBpfUlrsq(element.GvCIORqnGAPkjIeHqjOSdbeWmKqn(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			QMKQgDebBffRWvvKPpyHQVcrPnKc = new AList<Element>(list);
			EaOPFBDXtJKJpTErbykCLGiXhUEK = new AList<Button>(list3);
			xVoUZYivvGXoRgheNCagwJfTsAAg = new AList<Axis>(list4);
			ImLdUACfvoXtkslrmEdGGNPhHUOLc = new ReadOnlyCollection<Element>(QMKQgDebBffRWvvKPpyHQVcrPnKc);
			MGPrTyVqwtFXJAfVphGDfWLjVpABb = new ReadOnlyCollection<Button>(EaOPFBDXtJKJpTErbykCLGiXhUEK);
			iFhngfoAxJHDJTOKhdvPtVAPHlJAA = new ReadOnlyCollection<Axis>(xVoUZYivvGXoRgheNCagwJfTsAAg);
			RWkRRlsGPrizJIlNBhhhNnkWcMEFA = new List<Element.pvBbFOcmNfKEHBCNPWlJTLccMcUgb>();
			ReInput.UpdateEndedEvent += ECTszUJpkPKeeHJSteaXfkpTjaqS;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= ECTszUJpkPKeeHJSteaXfkpTjaqS;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
			{
				ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
				return false;
			}
			if ((uint)index >= (uint)EaOPFBDXtJKJpTErbykCLGiXhUEK._count)
			{
				return false;
			}
			return EaOPFBDXtJKJpTErbykCLGiXhUEK[index].value;
		}

		bool IPlayerController.GetButton(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButton
			return this.GetButton(index);
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
			{
				ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
				return false;
			}
			if ((uint)index >= (uint)EaOPFBDXtJKJpTErbykCLGiXhUEK._count)
			{
				return false;
			}
			return EaOPFBDXtJKJpTErbykCLGiXhUEK[index].justPressed;
		}

		bool IPlayerController.GetButtonDown(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonDown
			return this.GetButtonDown(index);
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
			{
				ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
				return false;
			}
			if ((uint)index >= (uint)EaOPFBDXtJKJpTErbykCLGiXhUEK._count)
			{
				return false;
			}
			return EaOPFBDXtJKJpTErbykCLGiXhUEK[index].justReleased;
		}

		bool IPlayerController.GetButtonUp(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonUp
			return this.GetButtonUp(index);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
			{
				ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
				return 0f;
			}
			if ((uint)index >= (uint)xVoUZYivvGXoRgheNCagwJfTsAAg._count)
			{
				return 0f;
			}
			return xVoUZYivvGXoRgheNCagwJfTsAAg[index].value;
		}

		float IPlayerController.GetAxis(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxis
			return this.GetAxis(index);
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
			{
				ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
				return 0f;
			}
			if ((uint)index >= (uint)xVoUZYivvGXoRgheNCagwJfTsAAg._count)
			{
				return 0f;
			}
			return xVoUZYivvGXoRgheNCagwJfTsAAg[index].valueRaw;
		}

		float IPlayerController.GetAxisRaw(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxisRaw
			return this.GetAxisRaw(index);
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
			{
				ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
				return null;
			}
			if ((uint)index >= (uint)QMKQgDebBffRWvvKPpyHQVcrPnKc._count)
			{
				return null;
			}
			return QMKQgDebBffRWvvKPpyHQVcrPnKc[index];
		}

		Element IPlayerController.GetElement(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetElement
			return this.GetElement(index);
		}

		public T GetElement<T>(int index) where T : Element
		{
			return GetElement(index) as T;
		}

		T IPlayerController.GetElement<T>(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetElement
			return this.GetElement<T>(index);
		}

		private void ECTszUJpkPKeeHJSteaXfkpTjaqS(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!RjJaKLTNSYKUbOPyoeKFbWvEtUpgA)
			{
				return false;
			}
			bool flag = HLYeLHvjEqWLgzzfBfztMdyseJtZ != null;
			bool flag2 = ucbvMaxaNihgXSHehFQkAkJugCEHb != null;
			for (int i = 0; i < QMKQgDebBffRWvvKPpyHQVcrPnKc._count; i++)
			{
				float num = 0f;
				if (flag && QMKQgDebBffRWvvKPpyHQVcrPnKc[i] is Axis)
				{
					Axis axis = QMKQgDebBffRWvvKPpyHQVcrPnKc[i] as Axis;
					num = ((axis.coordinateMode != AxisCoordinateMode.Absolute) ? 0f : axis.value);
				}
				QMKQgDebBffRWvvKPpyHQVcrPnKc[i].sKWWGpbggpVHinsymSnLJPXSWYAp();
				if (flag2 && QMKQgDebBffRWvvKPpyHQVcrPnKc[i] is Button)
				{
					Button button = QMKQgDebBffRWvvKPpyHQVcrPnKc[i] as Button;
					if (button.justPressed && button.value)
					{
						RWkRRlsGPrizJIlNBhhhNnkWcMEFA.Add(new Element.pvBbFOcmNfKEHBCNPWlJTLccMcUgb(ControllerElementType.Button, i, 1f));
					}
					else if (button.justReleased && !button.value)
					{
						RWkRRlsGPrizJIlNBhhhNnkWcMEFA.Add(new Element.pvBbFOcmNfKEHBCNPWlJTLccMcUgb(ControllerElementType.Button, i, 0f));
					}
				}
				else if (flag && QMKQgDebBffRWvvKPpyHQVcrPnKc[i] is Axis)
				{
					RWkRRlsGPrizJIlNBhhhNnkWcMEFA.Add(new Element.pvBbFOcmNfKEHBCNPWlJTLccMcUgb(ControllerElementType.Axis, i, (QMKQgDebBffRWvvKPpyHQVcrPnKc[i] as Axis).value - num));
				}
			}
			return true;
		}

		protected virtual void UpdateFinished()
		{
			int count = RWkRRlsGPrizJIlNBhhhNnkWcMEFA.Count;
			if (count <= 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				Element.pvBbFOcmNfKEHBCNPWlJTLccMcUgb pvBbFOcmNfKEHBCNPWlJTLccMcUgb = RWkRRlsGPrizJIlNBhhhNnkWcMEFA[i];
				if (pvBbFOcmNfKEHBCNPWlJTLccMcUgb.droLMyjeWcBbQFkQTyaNlEcZNGYFA == ControllerElementType.Button)
				{
					try
					{
						ucbvMaxaNihgXSHehFQkAkJugCEHb(pvBbFOcmNfKEHBCNPWlJTLccMcUgb.OOzhqANSoRaohqhJBonDnXdtfZsD, pvBbFOcmNfKEHBCNPWlJTLccMcUgb.QPNuVuOoZZYpzdQvMRAkODqRjWHc > 0f);
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
					}
				}
				else if (pvBbFOcmNfKEHBCNPWlJTLccMcUgb.droLMyjeWcBbQFkQTyaNlEcZNGYFA == ControllerElementType.Axis)
				{
					try
					{
						HLYeLHvjEqWLgzzfBfztMdyseJtZ(pvBbFOcmNfKEHBCNPWlJTLccMcUgb.OOzhqANSoRaohqhJBonDnXdtfZsD, pvBbFOcmNfKEHBCNPWlJTLccMcUgb.QPNuVuOoZZYpzdQvMRAkODqRjWHc);
					}
					catch (Exception ex2)
					{
						Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
					}
				}
			}
			RWkRRlsGPrizJIlNBhhhNnkWcMEFA.Clear();
		}

		protected virtual void ClearVars()
		{
			RWkRRlsGPrizJIlNBhhhNnkWcMEFA.Clear();
		}

		internal void AgFYxPwvfNmkvXsiOVykSvfpowRr(Element P_0)
		{
			if (P_0 != null)
			{
				if (P_0 is Axis)
				{
					xVoUZYivvGXoRgheNCagwJfTsAAg.Add(P_0 as Axis);
				}
				else if (P_0 is Button)
				{
					EaOPFBDXtJKJpTErbykCLGiXhUEK.Add(P_0 as Button);
				}
				QMKQgDebBffRWvvKPpyHQVcrPnKc.Add(P_0);
			}
		}

		private void ofjOmHUvrybPVorjGoNyBpfUlrsq(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
		{
			if (P_0 == null)
			{
				return;
			}
			P_0.GetType();
			if (P_0 is ElementWithSource)
			{
				if (P_0 is Button)
				{
					P_3.Add((Button)P_0);
				}
				else
				{
					if (!(P_0 is Axis))
					{
						Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
						return;
					}
					P_4.Add((Axis)P_0);
				}
				P_1.Add(P_0);
			}
			else if (P_0 is CompoundElement)
			{
				using (TempListPool.TList<Element> tList = TempListPool.GetTList<Element>())
				{
					List<Element> list = tList.list;
					(P_0 as CompoundElement).nVbiVjbSdaTZBzuQysXrKnwRsOck(list);
					for (int i = 0; i < list.Count; i++)
					{
						ofjOmHUvrybPVorjGoNyBpfUlrsq(list[i], P_1, P_2, P_3, P_4);
					}
				}
				P_2.Add(P_0);
			}
			else
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
			}
		}

		internal static int KBRKboVVekChYIfgWzbAJQdQRsFn<_0001>(IList<_0001> P_0, Predicate<_0001> P_1, int P_2) where _0001 : Element
		{
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_1(P_0[i]))
				{
					num++;
				}
				if (num == P_2)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
