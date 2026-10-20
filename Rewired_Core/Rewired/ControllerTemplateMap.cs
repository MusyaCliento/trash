using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int yUnQobmVGgJpOmgzmdOdBjCpbCgeb;

		private readonly int ESODAxFcwfpRgqgUawDjMTyJnDYr;

		private readonly Guid UZiYvIfykVGjUPiDYCDQjhGkzZoi;

		private readonly List<ControllerTemplateActionElementMap> ZOfWaLkwhLtxXVXdiTeirwXodVOE;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> KfsYqznWYlJPTKxbiaQCKRhnQezj;

		private bool uJwuhnuAcaRRnTeGTpPAtyCielbH;

		private int uenZaYTEdYnYdcdsjgKPBxrofEvd;

		private int ruvSROEfEdqnFRmsMcbpKyQUYJbuA;

		private int kPVKjbvGMorBtycHGrdGECHGoexN = -1;

		private static int KWMvRzWtKOLgfCOcsDQxjotKmmyg;

		public int id
		{
			get
			{
				if (ReInput._id != yUnQobmVGgJpOmgzmdOdBjCpbCgeb)
				{
					ReInput.CheckInitialized(yUnQobmVGgJpOmgzmdOdBjCpbCgeb);
					return -1;
				}
				return ESODAxFcwfpRgqgUawDjMTyJnDYr;
			}
		}

		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != yUnQobmVGgJpOmgzmdOdBjCpbCgeb)
				{
					ReInput.CheckInitialized(yUnQobmVGgJpOmgzmdOdBjCpbCgeb);
					return Guid.Empty;
				}
				return UZiYvIfykVGjUPiDYCDQjhGkzZoi;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != yUnQobmVGgJpOmgzmdOdBjCpbCgeb)
				{
					ReInput.CheckInitialized(yUnQobmVGgJpOmgzmdOdBjCpbCgeb);
					return false;
				}
				return uJwuhnuAcaRRnTeGTpPAtyCielbH;
			}
			set
			{
				uJwuhnuAcaRRnTeGTpPAtyCielbH = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != yUnQobmVGgJpOmgzmdOdBjCpbCgeb)
				{
					ReInput.CheckInitialized(yUnQobmVGgJpOmgzmdOdBjCpbCgeb);
					return -1;
				}
				return uenZaYTEdYnYdcdsjgKPBxrofEvd;
			}
			internal set
			{
				uenZaYTEdYnYdcdsjgKPBxrofEvd = num;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != yUnQobmVGgJpOmgzmdOdBjCpbCgeb)
				{
					ReInput.CheckInitialized(yUnQobmVGgJpOmgzmdOdBjCpbCgeb);
					return -1;
				}
				return ruvSROEfEdqnFRmsMcbpKyQUYJbuA;
			}
			internal set
			{
				ruvSROEfEdqnFRmsMcbpKyQUYJbuA = num;
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != yUnQobmVGgJpOmgzmdOdBjCpbCgeb)
				{
					ReInput.CheckInitialized(yUnQobmVGgJpOmgzmdOdBjCpbCgeb);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return KfsYqznWYlJPTKxbiaQCKRhnQezj;
			}
		}

		internal ControllerTemplateMap(Guid P_0)
		{
			ESODAxFcwfpRgqgUawDjMTyJnDYr = KWMvRzWtKOLgfCOcsDQxjotKmmyg++;
			yUnQobmVGgJpOmgzmdOdBjCpbCgeb = ReInput._id;
			UZiYvIfykVGjUPiDYCDQjhGkzZoi = P_0;
			ZOfWaLkwhLtxXVXdiTeirwXodVOE = new List<ControllerTemplateActionElementMap>();
			KfsYqznWYlJPTKxbiaQCKRhnQezj = new ReadOnlyCollection<ControllerTemplateActionElementMap>(ZOfWaLkwhLtxXVXdiTeirwXodVOE);
			uJwuhnuAcaRRnTeGTpPAtyCielbH = true;
		}

		internal ControllerTemplateMap(Guid P_0, int P_1, int P_2, int P_3)
			: this(P_0)
		{
			uenZaYTEdYnYdcdsjgKPBxrofEvd = P_1;
			ruvSROEfEdqnFRmsMcbpKyQUYJbuA = P_2;
			kPVKjbvGMorBtycHGrdGECHGoexN = P_3;
		}

		public string ToXmlString()
		{
			if (ReInput._id != yUnQobmVGgJpOmgzmdOdBjCpbCgeb)
			{
				ReInput.CheckInitialized(yUnQobmVGgJpOmgzmdOdBjCpbCgeb);
				return string.Empty;
			}
			try
			{
				return RlvunNuTVxuosvwUBbkzBjrDypdU().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != yUnQobmVGgJpOmgzmdOdBjCpbCgeb)
			{
				ReInput.CheckInitialized(yUnQobmVGgJpOmgzmdOdBjCpbCgeb);
				return string.Empty;
			}
			try
			{
				return RlvunNuTVxuosvwUBbkzBjrDypdU().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != yUnQobmVGgJpOmgzmdOdBjCpbCgeb)
			{
				ReInput.CheckInitialized(yUnQobmVGgJpOmgzmdOdBjCpbCgeb);
				return null;
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			IControllerTemplate template = controller.GetTemplate(UZiYvIfykVGjUPiDYCDQjhGkzZoi);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			ControllerMap controllerMap = ControllerMap.JEyMkYAwWgEipyvdoVluCMXeWMM(controller.type);
			controllerMap.categoryId = uenZaYTEdYnYdcdsjgKPBxrofEvd;
			controllerMap.layoutId = ruvSROEfEdqnFRmsMcbpKyQUYJbuA;
			if (kPVKjbvGMorBtycHGrdGECHGoexN >= 0)
			{
				controllerMap.sourceMapId = kPVKjbvGMorBtycHGrdGECHGoexN;
			}
			controllerMap.controllerId = controller.id;
			controllerMap.enabled = uJwuhnuAcaRRnTeGTpPAtyCielbH;
			controllerMap.hardwareGuid = controller.ZOYuKGMDLcxmBxqUbjaMwovvvKxG;
			using TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>();
			List<ActionElementMap> list = tList.list;
			for (int i = 0; i < ZOfWaLkwhLtxXVXdiTeirwXodVOE.Count; i++)
			{
				ZOfWaLkwhLtxXVXdiTeirwXodVOE[i].BmnqgdCjsDqUGFPMqNJWKvDqfLVL(template, list, false);
				for (int j = 0; j < list.Count; j++)
				{
					controllerMap.sDqHEWbyPiYMwKMUolFtvnYYDxDXA(list[j]);
				}
			}
			return controllerMap;
		}

		internal virtual void luqfDleQspexmsEIELLcfvnDOYZVA(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.zyMcqofvUObnbwctwMfJTHVAopqx
			{
				ErrnmJxSDTWdHuymqJxfqXJFoSMv = "dataVersion",
				LBGjqqZxEPBjvHqNhMVicOdoqakWA = 1.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.zyMcqofvUObnbwctwMfJTHVAopqx
			{
				ErrnmJxSDTWdHuymqJxfqXJFoSMv = "templateTypeGuid",
				LBGjqqZxEPBjvHqNhMVicOdoqakWA = UZiYvIfykVGjUPiDYCDQjhGkzZoi.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.zyMcqofvUObnbwctwMfJTHVAopqx
			{
				rIDwIrwPWptYvehlvTmbuztcaWmR = "xmlns",
				ErrnmJxSDTWdHuymqJxfqXJFoSMv = "xsi",
				oELDSJjGHqeiaFEdgDPOLYTSXoPLb = null,
				LBGjqqZxEPBjvHqNhMVicOdoqakWA = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.zyMcqofvUObnbwctwMfJTHVAopqx
			{
				rIDwIrwPWptYvehlvTmbuztcaWmR = "xsi",
				ErrnmJxSDTWdHuymqJxfqXJFoSMv = "schemaLocation",
				oELDSJjGHqeiaFEdgDPOLYTSXoPLb = null,
				LBGjqqZxEPBjvHqNhMVicOdoqakWA = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
			});
			P_0.Add("templateTypeGuid", UZiYvIfykVGjUPiDYCDQjhGkzZoi);
			P_0.Add("enabled", uJwuhnuAcaRRnTeGTpPAtyCielbH);
			P_0.Add("categoryId", uenZaYTEdYnYdcdsjgKPBxrofEvd);
			P_0.Add("layoutId", ruvSROEfEdqnFRmsMcbpKyQUYJbuA);
			P_0.Add("sourceMapId", kPVKjbvGMorBtycHGrdGECHGoexN);
			int count = ZOfWaLkwhLtxXVXdiTeirwXodVOE.Count;
			List<object> list = new List<object>();
			P_0.Add("elementMaps", list);
			for (int i = 0; i < count; i++)
			{
				if (ZOfWaLkwhLtxXVXdiTeirwXodVOE[i] != null)
				{
					list.Add(ZOfWaLkwhLtxXVXdiTeirwXodVOE[i].OImcUNmqdwgRUsdZOSsMiZIcXmug());
				}
			}
		}

		internal virtual void pxGgujTDOAFPEnJkxDMNSLeCqEug(SerializedObject P_0)
		{
			RkhFCzEwxoyOTeBMcAlSIfEbqifB();
			P_0.TryGetDeserializedValueByRef("enabled", ref uJwuhnuAcaRRnTeGTpPAtyCielbH);
			P_0.TryGetDeserializedValueByRef("categoryId", ref uenZaYTEdYnYdcdsjgKPBxrofEvd);
			P_0.TryGetDeserializedValueByRef("layoutId", ref ruvSROEfEdqnFRmsMcbpKyQUYJbuA);
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref kPVKjbvGMorBtycHGrdGECHGoexN);
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
			{
				return;
			}
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.bzNveXDnubQcbibylGHVBBPDROFH(value2);
					if (controllerTemplateActionElementMap != null)
					{
						WQMyWVPDWXhQcOeqMuDNvhgakVUs(controllerTemplateActionElementMap);
					}
				}
			}
		}

		private void RkhFCzEwxoyOTeBMcAlSIfEbqifB()
		{
			uJwuhnuAcaRRnTeGTpPAtyCielbH = true;
			uenZaYTEdYnYdcdsjgKPBxrofEvd = -1;
			ruvSROEfEdqnFRmsMcbpKyQUYJbuA = -1;
			kPVKjbvGMorBtycHGrdGECHGoexN = -1;
			ZOfWaLkwhLtxXVXdiTeirwXodVOE.Clear();
		}

		private SerializedObject RlvunNuTVxuosvwUBbkzBjrDypdU()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			luqfDleQspexmsEIELLcfvnDOYZVA(serializedObject);
			return serializedObject;
		}

		internal void WQMyWVPDWXhQcOeqMuDNvhgakVUs(ControllerTemplateActionElementMap P_0)
		{
			if (P_0 != null)
			{
				ZOfWaLkwhLtxXVXdiTeirwXodVOE.Add(P_0);
			}
		}

		internal static ControllerTemplateMap YYXtioexYoyfWsWVuvvZfObLhQbJ(IControllerTemplate P_0, ControllerMap P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			if (!ReInput.isReady)
			{
				throw new Exception("Rewired is not initialized.");
			}
			Controller controller = ReInput.controllers.GetController(P_1.controllerType, P_1.controllerId);
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
				return null;
			}
			if (!controller.ImplementsTemplate(P_0.typeGuid))
			{
				Logger.LogError("The Controller does not implement the Controller Template.", requiredThreadSafety: true);
				return null;
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(P_0.typeGuid);
			controllerTemplateMap.uJwuhnuAcaRRnTeGTpPAtyCielbH = P_1.enabled;
			controllerTemplateMap.uenZaYTEdYnYdcdsjgKPBxrofEvd = P_1.categoryId;
			controllerTemplateMap.ruvSROEfEdqnFRmsMcbpKyQUYJbuA = P_1.layoutId;
			controllerTemplateMap.kPVKjbvGMorBtycHGrdGECHGoexN = P_1.sourceMapId;
			using TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>();
			List<ControllerTemplateElementTarget> list = tList.list;
			foreach (ActionElementMap allMap in P_1.AllMaps)
			{
				if (P_0.GetElementTargets(allMap, list) > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						controllerTemplateMap.WQMyWVPDWXhQcOeqMuDNvhgakVUs(ControllerTemplateActionElementMap.rssAXCSBFTmFRjILJYeNVjjoEaVD(list[i], allMap));
					}
				}
			}
			return controllerTemplateMap;
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			try
			{
				return hMzCBzpSyJVOANIBbFPiKjUpFksg(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from XML! " + ex.Message);
				return null;
			}
		}

		public static ControllerTemplateMap FromJson(string jsonString)
		{
			try
			{
				return hMzCBzpSyJVOANIBbFPiKjUpFksg(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				return null;
			}
		}

		private static ControllerTemplateMap hMzCBzpSyJVOANIBbFPiKjUpFksg(SerializedObject P_0)
		{
			if (!P_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.pxGgujTDOAFPEnJkxDMNSLeCqEug(P_0);
			return controllerTemplateMap;
		}
	}
}
