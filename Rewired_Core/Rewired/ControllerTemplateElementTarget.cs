using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement iIamtDgYTzdstELqZSVRGLTpbKIF;

		private AxisRange oIQSUgIAPczNCqnqdIDympFMwnGv;

		public AxisRange axisRange
		{
			get
			{
				return oIQSUgIAPczNCqnqdIDympFMwnGv;
			}
			set
			{
				oIQSUgIAPczNCqnqdIDympFMwnGv = value;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (iIamtDgYTzdstELqZSVRGLTpbKIF == null)
				{
					return ControllerTemplateElementType.Axis;
				}
				return iIamtDgYTzdstELqZSVRGLTpbKIF.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (iIamtDgYTzdstELqZSVRGLTpbKIF == null)
				{
					return string.Empty;
				}
				return iIamtDgYTzdstELqZSVRGLTpbKIF.type switch
				{
					ControllerTemplateElementType.Axis => ((IControllerTemplateAxis)iIamtDgYTzdstELqZSVRGLTpbKIF).GetDescriptiveName(oIQSUgIAPczNCqnqdIDympFMwnGv), 
					ControllerTemplateElementType.Button => ((IControllerTemplateButton)iIamtDgYTzdstELqZSVRGLTpbKIF).descriptiveName, 
					_ => iIamtDgYTzdstELqZSVRGLTpbKIF.descriptiveName, 
				};
			}
		}

		public IControllerTemplateElement element
		{
			get
			{
				return iIamtDgYTzdstELqZSVRGLTpbKIF;
			}
			set
			{
				iIamtDgYTzdstELqZSVRGLTpbKIF = value;
			}
		}

		public IControllerTemplate template
		{
			get
			{
				if (iIamtDgYTzdstELqZSVRGLTpbKIF == null)
				{
					return null;
				}
				return (iIamtDgYTzdstELqZSVRGLTpbKIF as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget => iIamtDgYTzdstELqZSVRGLTpbKIF != null;

		internal ControllerTemplateElementTarget(IControllerTemplateElement P_0, AxisRange P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			iIamtDgYTzdstELqZSVRGLTpbKIF = P_0;
			oIQSUgIAPczNCqnqdIDympFMwnGv = P_1;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget P_0)
		{
			iIamtDgYTzdstELqZSVRGLTpbKIF = P_0.iIamtDgYTzdstELqZSVRGLTpbKIF;
			oIQSUgIAPczNCqnqdIDympFMwnGv = P_0.oIQSUgIAPczNCqnqdIDympFMwnGv;
		}
	}
}
