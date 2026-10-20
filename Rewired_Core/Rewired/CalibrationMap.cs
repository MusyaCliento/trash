using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public sealed class CalibrationMap
	{
		public struct InitOptions
		{
			[CompilerGenerated]
			private IList<AxisCalibration> gLVbpHLlfEzsoEpjMvpBdapRayvCA;

			[CompilerGenerated]
			private IList<Axis2DCalibration> fLFNDALQblqaDJkpREPjhCOdMwgMA;

			public IList<AxisCalibration> axisCalibrations
			{
				[CompilerGenerated]
				get
				{
					return gLVbpHLlfEzsoEpjMvpBdapRayvCA;
				}
				[CompilerGenerated]
				internal set
				{
					gLVbpHLlfEzsoEpjMvpBdapRayvCA = list;
				}
			}

			public IList<Axis2DCalibration> axis2DCalibrations
			{
				[CompilerGenerated]
				get
				{
					return fLFNDALQblqaDJkpREPjhCOdMwgMA;
				}
				[CompilerGenerated]
				internal set
				{
					fLFNDALQblqaDJkpREPjhCOdMwgMA = list;
				}
			}
		}

		private AxisCalibration[] zPMBxBhGdVntEkCWHKQQLBEiIKREA;

		private MappedArray<AxisCalibration> LdRpEojjqYKNOgclEoVTtDadCoaI;

		private Axis2DCalibration[] fXBSNBFdLaDWiJUolgySimBCLTjk;

		private IList<AxisCalibration> NFeuAMUJIJisdtGIOdBFGiJsmgovA;

		private IList<Axis2DCalibration> IdyJFrCPkIRgFjUUggfBiiAmSGoF;

		private readonly int cBTGiydQVoafiyayHYgsgQBHuorc;

		public IList<AxisCalibration> Axes => NFeuAMUJIJisdtGIOdBFGiJsmgovA;

		public int axisCount
		{
			get
			{
				if (zPMBxBhGdVntEkCWHKQQLBEiIKREA == null)
				{
					return 0;
				}
				return zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length;
			}
		}

		public IList<Axis2DCalibration> Axes2D => IdyJFrCPkIRgFjUUggfBiiAmSGoF;

		public int axis2DCount
		{
			get
			{
				if (fXBSNBFdLaDWiJUolgySimBCLTjk == null)
				{
					return 0;
				}
				return fXBSNBFdLaDWiJUolgySimBCLTjk.Length;
			}
		}

		private CalibrationMap()
		{
			cBTGiydQVoafiyayHYgsgQBHuorc = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] P_0, Axis2DCalibrationData[] P_1, Func<int, int> P_2)
			: this()
		{
			int num = ((P_0 != null) ? P_0.Length : 0);
			zPMBxBhGdVntEkCWHKQQLBEiIKREA = new AxisCalibration[num];
			LdRpEojjqYKNOgclEoVTtDadCoaI = new MappedArray<AxisCalibration>(zPMBxBhGdVntEkCWHKQQLBEiIKREA, P_2);
			for (int i = 0; i < num; i++)
			{
				zPMBxBhGdVntEkCWHKQQLBEiIKREA[i] = new AxisCalibration(P_0[i]);
			}
			NFeuAMUJIJisdtGIOdBFGiJsmgovA = new ReadOnlyCollection<AxisCalibration>(LdRpEojjqYKNOgclEoVTtDadCoaI);
			int num2 = ((P_1 != null) ? P_1.Length : 0);
			fXBSNBFdLaDWiJUolgySimBCLTjk = new Axis2DCalibration[num2];
			for (int j = 0; j < num2; j++)
			{
				fXBSNBFdLaDWiJUolgySimBCLTjk[j] = new Axis2DCalibration(P_1[j]);
			}
			IdyJFrCPkIRgFjUUggfBiiAmSGoF = new ReadOnlyCollection<Axis2DCalibration>(fXBSNBFdLaDWiJUolgySimBCLTjk);
		}

		[Obsolete("Use CalibrationMap(InitOptions) overload instead.", false)]
		public CalibrationMap(AxisCalibration[] P_0)
			: this()
		{
			zPMBxBhGdVntEkCWHKQQLBEiIKREA = P_0;
			LdRpEojjqYKNOgclEoVTtDadCoaI = new MappedArray<AxisCalibration>(zPMBxBhGdVntEkCWHKQQLBEiIKREA, null);
			NFeuAMUJIJisdtGIOdBFGiJsmgovA = new ReadOnlyCollection<AxisCalibration>(LdRpEojjqYKNOgclEoVTtDadCoaI);
		}

		public CalibrationMap(InitOptions P_0)
			: this()
		{
			zPMBxBhGdVntEkCWHKQQLBEiIKREA = ((P_0.axisCalibrations != null) ? new AxisCalibration[P_0.axisCalibrations.Count] : new AxisCalibration[0]);
			for (int i = 0; i < zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length; i++)
			{
				if (P_0.axisCalibrations[i] == null)
				{
					throw new ArgumentNullException("initOptions.axisCalibrations[" + i + "]");
				}
				zPMBxBhGdVntEkCWHKQQLBEiIKREA[i] = P_0.axisCalibrations[i];
			}
			fXBSNBFdLaDWiJUolgySimBCLTjk = ((P_0.axis2DCalibrations != null) ? new Axis2DCalibration[P_0.axis2DCalibrations.Count] : new Axis2DCalibration[0]);
			for (int j = 0; j < fXBSNBFdLaDWiJUolgySimBCLTjk.Length; j++)
			{
				if (P_0.axis2DCalibrations[j] == null)
				{
					throw new ArgumentNullException("initOptions.axis2DCalibrations[" + j + "]");
				}
				fXBSNBFdLaDWiJUolgySimBCLTjk[j] = P_0.axis2DCalibrations[j];
			}
		}

		public void Reset()
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return;
			}
			for (int i = 0; i < zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length; i++)
			{
				zPMBxBhGdVntEkCWHKQQLBEiIKREA[i].Reset();
			}
			for (int j = 0; j < fXBSNBFdLaDWiJUolgySimBCLTjk.Length; j++)
			{
				fXBSNBFdLaDWiJUolgySimBCLTjk[j].Reset();
			}
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return null;
			}
			if (index < 0 || index >= zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length)
			{
				return null;
			}
			return LdRpEojjqYKNOgclEoVTtDadCoaI[index];
		}

		public Axis2DCalibration GetAxis2D(int index)
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return null;
			}
			if (index < 0 || index >= fXBSNBFdLaDWiJUolgySimBCLTjk.Length)
			{
				return null;
			}
			return fXBSNBFdLaDWiJUolgySimBCLTjk[index];
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length)
			{
				return value;
			}
			return LdRpEojjqYKNOgclEoVTtDadCoaI[axisIndex].GetCalibratedValue(value);
		}

		public Vector2 GetCalibratedValue2D(int axis2DIndex, int xAxisIndex, int yAxisIndex, Vector2 value)
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return default(Vector2);
			}
			if ((uint)axis2DIndex >= (uint)fXBSNBFdLaDWiJUolgySimBCLTjk.Length)
			{
				return value;
			}
			return Axis2DCalibration.GetCalibratedValue(GetAxis2D(axis2DIndex), GetAxis(xAxisIndex), GetAxis(yAxisIndex), value.x, value.y);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return false;
			}
			if (index < 0 || index >= zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length)
			{
				return false;
			}
			LdRpEojjqYKNOgclEoVTtDadCoaI[index].SetData(data);
			return true;
		}

		public bool SetAxis2DData(int index, Axis2DCalibrationData data)
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return false;
			}
			if (index < 0 || index >= fXBSNBFdLaDWiJUolgySimBCLTjk.Length)
			{
				return false;
			}
			fXBSNBFdLaDWiJUolgySimBCLTjk[index].SetData(data);
			return true;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return default(AxisCalibrationData);
			}
			if (index < 0 || index >= zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length)
			{
				return default(AxisCalibrationData);
			}
			return LdRpEojjqYKNOgclEoVTtDadCoaI[index].GetData();
		}

		public Axis2DCalibrationData GetAxis2DData(int index)
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return default(Axis2DCalibrationData);
			}
			if (index < 0 || index >= zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length)
			{
				return default(Axis2DCalibrationData);
			}
			return fXBSNBFdLaDWiJUolgySimBCLTjk[index].GetData();
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			if (map.zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length != zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length || map.fXBSNBFdLaDWiJUolgySimBCLTjk.Length != fXBSNBFdLaDWiJUolgySimBCLTjk.Length)
			{
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				return;
			}
			for (int i = 0; i < zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length; i++)
			{
				zPMBxBhGdVntEkCWHKQQLBEiIKREA[i].CopyFrom(map.zPMBxBhGdVntEkCWHKQQLBEiIKREA[i], copyHardwareDeadzone);
			}
			for (int j = 0; j < fXBSNBFdLaDWiJUolgySimBCLTjk.Length; j++)
			{
				fXBSNBFdLaDWiJUolgySimBCLTjk[j].CopyFrom(map.fXBSNBFdLaDWiJUolgySimBCLTjk[j], copyHardwareDeadzone);
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return eMOCMrgxBqiSzLNsgBboTfQUYhXB().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return string.Empty;
			}
			try
			{
				return eMOCMrgxBqiSzLNsgBboTfQUYhXB().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				eESDbufjZHLFfHrqCChWlmRiIxCBC(SerializedObject.FromXml(GetType(), xmlString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from XML! " + ex.Message);
			}
			return false;
		}

		public bool ImportJsonString(string jsonString)
		{
			if (ReInput._id != cBTGiydQVoafiyayHYgsgQBHuorc)
			{
				ReInput.CheckInitialized(cBTGiydQVoafiyayHYgsgQBHuorc);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				eESDbufjZHLFfHrqCChWlmRiIxCBC(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject eMOCMrgxBqiSzLNsgBboTfQUYhXB()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 5, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.zyMcqofvUObnbwctwMfJTHVAopqx
			{
				ErrnmJxSDTWdHuymqJxfqXJFoSMv = "dataVersion",
				LBGjqqZxEPBjvHqNhMVicOdoqakWA = 5.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.zyMcqofvUObnbwctwMfJTHVAopqx
			{
				rIDwIrwPWptYvehlvTmbuztcaWmR = "xmlns",
				ErrnmJxSDTWdHuymqJxfqXJFoSMv = "xsi",
				oELDSJjGHqeiaFEdgDPOLYTSXoPLb = null,
				LBGjqqZxEPBjvHqNhMVicOdoqakWA = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.zyMcqofvUObnbwctwMfJTHVAopqx
			{
				rIDwIrwPWptYvehlvTmbuztcaWmR = "xsi",
				ErrnmJxSDTWdHuymqJxfqXJFoSMv = "schemaLocation",
				oELDSJjGHqeiaFEdgDPOLYTSXoPLb = null,
				LBGjqqZxEPBjvHqNhMVicOdoqakWA = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.4", "/", GetType().Name, ".xsd")
			});
			List<object> list = new List<object>();
			serializedObject.Add("axes", list);
			int num = ((zPMBxBhGdVntEkCWHKQQLBEiIKREA != null) ? zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if (zPMBxBhGdVntEkCWHKQQLBEiIKREA[i] != null)
				{
					list.Add(zPMBxBhGdVntEkCWHKQQLBEiIKREA[i].ExportData());
				}
			}
			List<object> list2 = new List<object>();
			serializedObject.Add("axes2d", list2);
			int num2 = ((fXBSNBFdLaDWiJUolgySimBCLTjk != null) ? fXBSNBFdLaDWiJUolgySimBCLTjk.Length : 0);
			for (int j = 0; j < num2; j++)
			{
				if (fXBSNBFdLaDWiJUolgySimBCLTjk[j] != null)
				{
					list2.Add(fXBSNBFdLaDWiJUolgySimBCLTjk[j].ExportData());
				}
			}
			return serializedObject;
		}

		private void eESDbufjZHLFfHrqCChWlmRiIxCBC(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				int num = MathTools.Min(value.count, zPMBxBhGdVntEkCWHKQQLBEiIKREA.Length);
				for (int i = 0; i < num; i++)
				{
					if (value[i].value is SerializedObject && zPMBxBhGdVntEkCWHKQQLBEiIKREA[i] != null)
					{
						zPMBxBhGdVntEkCWHKQQLBEiIKREA[i].Import((SerializedObject)value[i].value);
					}
				}
			}
			SerializedObject value2 = null;
			if (!P_0.TryGetDeserializedValueByRef("axes2d", ref value2))
			{
				return;
			}
			int num2 = MathTools.Min(value2.count, fXBSNBFdLaDWiJUolgySimBCLTjk.Length);
			for (int j = 0; j < num2; j++)
			{
				if (value2[j].value is SerializedObject && fXBSNBFdLaDWiJUolgySimBCLTjk[j] != null)
				{
					fXBSNBFdLaDWiJUolgySimBCLTjk[j].Import((SerializedObject)value2[j].value);
				}
			}
		}
	}
}
