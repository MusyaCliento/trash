using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int qSlJmSSQnkreohMCtlCjPfWNrXuT;

		private readonly ControllerTemplateElementType NbpHIIjyzysPiVOCuhRrWNupjSLBA;

		private bool EfASCYzUMoqWwwRszOZwJHlroiHx;

		private int YstdejuioaYGjgkjFuBXNZCauCPV;

		private int kQeYrJGJNBSssHPLEbQjKhFFlhyH;

		private static int OVIeiwoWxvHeyJvuqKpfUoSSLPfQ;

		public int id => qSlJmSSQnkreohMCtlCjPfWNrXuT;

		public ControllerTemplateElementType elementType => NbpHIIjyzysPiVOCuhRrWNupjSLBA;

		public bool enabled
		{
			get
			{
				return EfASCYzUMoqWwwRszOZwJHlroiHx;
			}
			set
			{
				EfASCYzUMoqWwwRszOZwJHlroiHx = value;
			}
		}

		public int actionId
		{
			get
			{
				return YstdejuioaYGjgkjFuBXNZCauCPV;
			}
			set
			{
				YstdejuioaYGjgkjFuBXNZCauCPV = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return kQeYrJGJNBSssHPLEbQjKhFFlhyH;
			}
			set
			{
				kQeYrJGJNBSssHPLEbQjKhFFlhyH = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0)
		{
			if (!InputTools.IsMappableType(P_0))
			{
				throw new ArgumentException(P_0.ToString() + " is not a supported mappable Controller Template element type.");
			}
			NbpHIIjyzysPiVOCuhRrWNupjSLBA = P_0;
			qSlJmSSQnkreohMCtlCjPfWNrXuT = OVIeiwoWxvHeyJvuqKpfUoSSLPfQ++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, ActionElementMap P_2)
			: this(P_0)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			YstdejuioaYGjgkjFuBXNZCauCPV = P_2._actionId;
			kQeYrJGJNBSssHPLEbQjKhFFlhyH = P_1;
			EfASCYzUMoqWwwRszOZwJHlroiHx = P_2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, int P_2, bool P_3)
			: this(P_0)
		{
			YstdejuioaYGjgkjFuBXNZCauCPV = P_2;
			kQeYrJGJNBSssHPLEbQjKhFFlhyH = P_1;
			EfASCYzUMoqWwwRszOZwJHlroiHx = P_3;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap P_0)
		{
		}

		internal int BmnqgdCjsDqUGFPMqNJWKvDqfLVL(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			int num = vLZGnawLBkbnxXxZKvCtNpymIsWX(P_0, P_1, P_2);
			if (num == 0)
			{
				return 0;
			}
			int num2 = P_1.Count - num;
			for (int i = 0; i < num; i++)
			{
				int index = num2 + i;
				P_1[index].KDuOcDwQLQHhwDRrYdOMFXnFZITxA = EfASCYzUMoqWwwRszOZwJHlroiHx;
				P_1[index]._actionId = YstdejuioaYGjgkjFuBXNZCauCPV;
			}
			return num;
		}

		internal SerializedObject OImcUNmqdwgRUsdZOSsMiZIcXmug()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			APszwVRoJikjUzBlrOWsRSAvNeGC(serializedObject);
			return serializedObject;
		}

		internal virtual void APszwVRoJikjUzBlrOWsRSAvNeGC(SerializedObject P_0)
		{
			P_0.Add("elementType", NbpHIIjyzysPiVOCuhRrWNupjSLBA);
			P_0.Add("enabled", EfASCYzUMoqWwwRszOZwJHlroiHx);
			P_0.Add("elementIdentifierId", kQeYrJGJNBSssHPLEbQjKhFFlhyH);
			P_0.Add("actionId", YstdejuioaYGjgkjFuBXNZCauCPV);
		}

		internal virtual void LvHIAqbyQiGoBdmcAtOdFbpkTPqX(SerializedObject P_0)
		{
			IerGlOPlXiKwfJwjSOZDBbzSMZgV();
			P_0.TryGetDeserializedValueByRef("enabled", ref EfASCYzUMoqWwwRszOZwJHlroiHx);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref kQeYrJGJNBSssHPLEbQjKhFFlhyH);
			P_0.TryGetDeserializedValueByRef("actionId", ref YstdejuioaYGjgkjFuBXNZCauCPV);
		}

		internal virtual void IerGlOPlXiKwfJwjSOZDBbzSMZgV()
		{
			EfASCYzUMoqWwwRszOZwJHlroiHx = true;
			kQeYrJGJNBSssHPLEbQjKhFFlhyH = -1;
			YstdejuioaYGjgkjFuBXNZCauCPV = -1;
		}

		internal abstract int gtYwfdvezWmySfiAkHqPIsdbQuvB(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int vLZGnawLBkbnxXxZKvCtNpymIsWX(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			IControllerTemplateElement element = P_0.GetElement(kQeYrJGJNBSssHPLEbQjKhFFlhyH);
			if (element == null)
			{
				return 0;
			}
			IControllerTemplateElementSource source = element.source;
			if (source == null)
			{
				return 0;
			}
			return gtYwfdvezWmySfiAkHqPIsdbQuvB(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap bzNveXDnubQcbibylGHVBBPDROFH(SerializedObject P_0)
		{
			if (P_0 == null)
			{
				return null;
			}
			if (!P_0.TryGetDeserializedValue<ControllerTemplateElementType>("elementType", out var value))
			{
				return null;
			}
			return value switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal static ControllerTemplateActionElementMap rssAXCSBFTmFRjILJYeNVjjoEaVD(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (P_0.elementType == ControllerTemplateElementType.Axis)
			{
				return new ControllerTemplateActionAxisMap(P_0.element.id, P_0.axisRange, P_1);
			}
			if (P_0.elementType == ControllerTemplateElementType.Button)
			{
				return new ControllerTemplateActionButtonMap(P_0.element.id, P_1);
			}
			throw new NotImplementedException();
		}

		internal static ControllerTemplateActionElementMap LjPKHYWxhGqKJrnmjMajsfZkShzV(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ControllerTemplateElementType controllerTemplateElementType = GHPcAvLGyrhUIIuLWeQoyFTYgunBA.yYgDEStnsoCmjxiqpgmNRhypUcCO(P_0._elementType, false);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			return controllerTemplateElementType switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.KDuOcDwQLQHhwDRrYdOMFXnFZITxA), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.KDuOcDwQLQHhwDRrYdOMFXnFZITxA), 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
