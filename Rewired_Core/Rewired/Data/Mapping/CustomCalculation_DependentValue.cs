using System;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class CustomCalculation_DependentValue : CustomCalculation
	{
		public enum Condition
		{
			Exclusive = 0,
			InclusiveAll = 1,
			InclusiveAny = 2
		}

		private const TypeWrapper.DataType resultType = TypeWrapper.DataType.Single;

		[SerializeField]
		private Condition _condition;

		[SerializeField]
		private float _threshold;

		[SerializeField]
		private float _failValue;

		TypeWrapper.DataType SerializedMethod.ResultType => TypeWrapper.DataType.Single;

		internal bool NyFyswRUkThPNPHPDkGRrWgalVkF()
		{
			bool flag = false;
			ClearResult();
			if (base.DataCount >= 1)
			{
				_result = PwHBLlmvGYsQEPwxIoKOCagmfFJh();
				flag = true;
			}
			ClearData();
			_resultIsValid = flag;
			return flag;
		}

		private float PwHBLlmvGYsQEPwxIoKOCagmfFJh()
		{
			int dataCount = base.DataCount;
			if (dataCount == 0)
			{
				return _failValue;
			}
			float result = _data[0];
			bool flag = false;
			float num = MathTools.Abs(_threshold);
			for (int i = 1; i < dataCount; i++)
			{
				if (_data[i].type != TypeWrapper.DataType.Single)
				{
					throw new Exception("Data type must be the same on all data fields!");
				}
				float num2 = MathTools.Abs((float)_data[i]);
				switch (_condition)
				{
				case Condition.Exclusive:
					if (!MathTools.Approximately(MathTools.Abs(num2), num) && num2 > num)
					{
						return _failValue;
					}
					break;
				case Condition.InclusiveAll:
					if (MathTools.Approximately(num2, num) || num2 < num)
					{
						return _failValue;
					}
					break;
				case Condition.InclusiveAny:
					flag = true;
					if (!MathTools.Approximately(num2, num) && num2 > num)
					{
						return result;
					}
					break;
				default:
					throw new NotImplementedException();
				}
			}
			if (flag)
			{
				return _failValue;
			}
			return result;
		}
	}
}
