using Unity.Collections;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator
{
	public struct Status
	{
		private int value1;

		private int value2;

		private int value3;

		private int value4;

		public TriangulatorErrorType type;

		public bool IsError => type != TriangulatorErrorType.Ok;

		public static Status Ok => new Status
		{
			type = TriangulatorErrorType.Ok
		};

		public static Status DegenerateInput => new Status
		{
			type = TriangulatorErrorType.DegenerateInput
		};

		public static Status SloanMaxItersExceeded => new Status
		{
			type = TriangulatorErrorType.SloanMaxItersExceeded
		};

		public static Status IntegersDoNotSupportMeshRefinement => new Status
		{
			type = TriangulatorErrorType.IntegersDoNotSupportMeshRefinement
		};

		public static Status RedudantHolesArray => new Status
		{
			type = TriangulatorErrorType.RedudantHolesArray
		};

		public static Status ConstraintEdgesMissingForAutoHolesAndBoundary => new Status
		{
			type = TriangulatorErrorType.ConstraintEdgesMissingForAutoHolesAndBoundary
		};

		public static Status ConstraintEdgesMissingForRestoreBoundary => new Status
		{
			type = TriangulatorErrorType.ConstraintEdgesMissingForRestoreBoundary
		};

		public static Status RefinementNotSupportedForCoordinateType => new Status
		{
			type = TriangulatorErrorType.RefinementNotSupportedForCoordinateType
		};

		public static Status RefinementThresholdAreaMustBePositive => new Status
		{
			type = TriangulatorErrorType.RefinementThresholdAreaMustBePositive
		};

		public static Status RefinementThresholdAngleOutOfRange => new Status
		{
			type = TriangulatorErrorType.RefinementThresholdAngleOutOfRange
		};

		public static Status PositionsLengthLessThan3(int length)
		{
			return new Status
			{
				value1 = length,
				type = TriangulatorErrorType.PositionsLengthLessThan3
			};
		}

		public static Status PositionsMustBeFinite(int index)
		{
			return new Status
			{
				value1 = index,
				type = TriangulatorErrorType.PositionsMustBeFinite
			};
		}

		public static Status ConstraintsLengthNotDivisibleBy2(int length)
		{
			return new Status
			{
				value1 = length,
				type = TriangulatorErrorType.ConstraintsLengthNotDivisibleBy2
			};
		}

		public static Status DuplicatePosition(int index)
		{
			return new Status
			{
				value1 = index,
				type = TriangulatorErrorType.DuplicatePosition
			};
		}

		public static Status DuplicateConstraint(int index1, int index2)
		{
			return new Status
			{
				value1 = index1,
				value2 = index2,
				type = TriangulatorErrorType.DuplicateConstraint
			};
		}

		public static Status ConstraintOutOfBounds(int index, int2 constraint, int positionLength)
		{
			return new Status
			{
				value1 = index,
				value2 = constraint.x,
				value3 = constraint.y,
				value4 = positionLength,
				type = TriangulatorErrorType.ConstraintOutOfBounds
			};
		}

		public static Status ConstraintSelfLoop(int index, int2 constraint)
		{
			return new Status
			{
				value1 = index,
				value2 = constraint.x,
				value3 = constraint.y,
				type = TriangulatorErrorType.ConstraintSelfLoop
			};
		}

		public static Status ConstraintIntersection(int index1, int index2)
		{
			return new Status
			{
				value1 = index1,
				value2 = index2,
				type = TriangulatorErrorType.ConstraintIntersection
			};
		}

		public static Status ConstraintArrayLengthMismatch(int constraintLength, int constraintTypeLength)
		{
			return new Status
			{
				value1 = constraintLength,
				value2 = constraintTypeLength,
				type = TriangulatorErrorType.ConstraintArrayLengthMismatch
			};
		}

		public static Status HoleMustBeFinite(int index)
		{
			return new Status
			{
				value1 = index,
				type = TriangulatorErrorType.HoleMustBeFinite
			};
		}

		public static Status SloanMaxItersMustBePositive(int sloanMaxIters)
		{
			return new Status
			{
				type = TriangulatorErrorType.SloanMaxItersMustBePositive,
				value1 = sloanMaxIters
			};
		}

		internal FixedString64Bytes ToFixedString()
		{
			return "Triangulation error. Run in editor for more info.";
		}

		public override string ToString()
		{
			return ToFixedString().ToString();
		}
	}
}
