using System;

namespace Rewired
{
	public sealed class CustomControllerMap : ControllerMapWithAxes
	{
		private int TbKsDowyiQABXNriqJgzJTzFhJbD;

		public int sourceControllerId
		{
			get
			{
				return TbKsDowyiQABXNriqJgzJTzFhJbD;
			}
			set
			{
				TbKsDowyiQABXNriqJgzJTzFhJbD = value;
			}
		}

		public CustomControllerMap()
		{
			_controllerType = ControllerType.Custom;
		}

		public CustomControllerMap(CustomControllerMap P_0)
			: base(P_0)
		{
			TbKsDowyiQABXNriqJgzJTzFhJbD = P_0.TbKsDowyiQABXNriqJgzJTzFhJbD;
		}

		internal void zLwFUjAqAiMOJGAGoHoujpPiJqVLA(Guid P_0, int P_1, int P_2, int P_3)
		{
			_hardwareGuid = P_0;
			TbKsDowyiQABXNriqJgzJTzFhJbD = P_1;
			_categoryId = P_2;
			_layoutId = P_3;
		}

		internal static CustomControllerMap yYPdeDaWFrpDakaAECckYYKAjEwp(Guid P_0, int P_1, int P_2, int P_3)
		{
			return new CustomControllerMap
			{
				_hardwareGuid = P_0,
				TbKsDowyiQABXNriqJgzJTzFhJbD = P_1,
				_sourceMapId = -1,
				_categoryId = P_2,
				_layoutId = P_3
			};
		}
	}
}
