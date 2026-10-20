namespace Rewired
{
	public struct Axis2DCalibrationData
	{
		private DeadZone2DType qPkPsnOALApQKgiqnaIhkvyBuAqq;

		private AxisSensitivity2DType YyRdmOEHeXlLmNZfqibQvTGRWpNeA;

		private Axis2DClampType lHtFiNtGAUnfJKaNWaPfsBVvFReu;

		public DeadZone2DType deadZoneType
		{
			get
			{
				return qPkPsnOALApQKgiqnaIhkvyBuAqq;
			}
			set
			{
				qPkPsnOALApQKgiqnaIhkvyBuAqq = value;
			}
		}

		public AxisSensitivity2DType sensitivityType
		{
			get
			{
				return YyRdmOEHeXlLmNZfqibQvTGRWpNeA;
			}
			set
			{
				YyRdmOEHeXlLmNZfqibQvTGRWpNeA = value;
			}
		}

		public Axis2DClampType clampType
		{
			get
			{
				return lHtFiNtGAUnfJKaNWaPfsBVvFReu;
			}
			set
			{
				lHtFiNtGAUnfJKaNWaPfsBVvFReu = value;
			}
		}

		internal Axis2DCalibrationData(DeadZone2DType P_0, AxisSensitivity2DType P_1, Axis2DClampType P_2)
		{
			qPkPsnOALApQKgiqnaIhkvyBuAqq = P_0;
			YyRdmOEHeXlLmNZfqibQvTGRWpNeA = P_1;
			lHtFiNtGAUnfJKaNWaPfsBVvFReu = P_2;
		}
	}
}
