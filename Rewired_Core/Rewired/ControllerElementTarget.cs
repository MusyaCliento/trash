using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element dkoLhfVTQlamBjeMgPGFYfhtFjAf;

		private AxisRange bjeHrgwDBdmOKPMtbiNkNXatWxUJ;

		public int elementIdentifierId
		{
			get
			{
				if (dkoLhfVTQlamBjeMgPGFYfhtFjAf == null)
				{
					return -1;
				}
				return dkoLhfVTQlamBjeMgPGFYfhtFjAf.id;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return bjeHrgwDBdmOKPMtbiNkNXatWxUJ;
			}
			set
			{
				bjeHrgwDBdmOKPMtbiNkNXatWxUJ = value;
			}
		}

		public bool hasTarget => dkoLhfVTQlamBjeMgPGFYfhtFjAf != null;

		public ControllerElementType elementType
		{
			get
			{
				if (dkoLhfVTQlamBjeMgPGFYfhtFjAf == null)
				{
					return ControllerElementType.Axis;
				}
				return dkoLhfVTQlamBjeMgPGFYfhtFjAf.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (dkoLhfVTQlamBjeMgPGFYfhtFjAf == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = dkoLhfVTQlamBjeMgPGFYfhtFjAf.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(dkoLhfVTQlamBjeMgPGFYfhtFjAf.type, bjeHrgwDBdmOKPMtbiNkNXatWxUJ);
			}
		}

		public Controller controller
		{
			get
			{
				if (dkoLhfVTQlamBjeMgPGFYfhtFjAf == null)
				{
					return null;
				}
				return dkoLhfVTQlamBjeMgPGFYfhtFjAf.ljxPApcqfhIyNhfYjBdoZjzSrymA;
			}
		}

		public Controller.Element element
		{
			get
			{
				return dkoLhfVTQlamBjeMgPGFYfhtFjAf;
			}
			set
			{
				dkoLhfVTQlamBjeMgPGFYfhtFjAf = value;
			}
		}

		public ControllerElementTarget(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (P_0.dyhfJlmijlECGVoGpAVoCuWQhZpGb != null)
			{
				Controller controller = ReInput.jFidDAJTYMYSSrBGXbdjHWSiLLLfB.uNJmTUUZIgxCnlFgJshQMfTyrJwA(P_0.dyhfJlmijlECGVoGpAVoCuWQhZpGb.controllerType, P_0.dyhfJlmijlECGVoGpAVoCuWQhZpGb.controllerId);
				dkoLhfVTQlamBjeMgPGFYfhtFjAf = controller.GetElementById(P_0._elementIdentifierId);
			}
			else
			{
				dkoLhfVTQlamBjeMgPGFYfhtFjAf = null;
			}
			bjeHrgwDBdmOKPMtbiNkNXatWxUJ = P_0._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget P_0)
		{
			dkoLhfVTQlamBjeMgPGFYfhtFjAf = P_0.dkoLhfVTQlamBjeMgPGFYfhtFjAf;
			bjeHrgwDBdmOKPMtbiNkNXatWxUJ = P_0.bjeHrgwDBdmOKPMtbiNkNXatWxUJ;
		}

		public ControllerElementTarget(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("other");
			}
			dkoLhfVTQlamBjeMgPGFYfhtFjAf = P_0.element;
			bjeHrgwDBdmOKPMtbiNkNXatWxUJ = P_0.axisRange;
		}

		public static implicit operator ControllerElementTarget(ActionElementMap actionElementMap)
		{
			if (actionElementMap == null)
			{
				return default(ControllerElementTarget);
			}
			return new ControllerElementTarget(actionElementMap);
		}
	}
}
