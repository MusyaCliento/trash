using System.Runtime.InteropServices;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	public readonly struct Args
	{
		public readonly Preprocessor Preprocessor;

		public readonly int SloanMaxIters;

		[MarshalAs(UnmanagedType.U1)]
		public readonly bool AutoHolesAndBoundary;

		[MarshalAs(UnmanagedType.U1)]
		public readonly bool RefineMesh;

		[MarshalAs(UnmanagedType.U1)]
		public readonly bool RestoreBoundary;

		[MarshalAs(UnmanagedType.U1)]
		public readonly bool ValidateInput;

		[MarshalAs(UnmanagedType.U1)]
		public readonly bool Verbose;

		public readonly float RefinementThresholdAngle;

		public readonly float RefinementThresholdArea;

		public Args(Preprocessor preprocessor, int sloanMaxIters, bool autoHolesAndBoundary, bool refineMesh, bool restoreBoundary, bool validateInput, bool verbose, float refinementThresholdAngle, float refinementThresholdArea)
		{
			AutoHolesAndBoundary = autoHolesAndBoundary;
			Preprocessor = preprocessor;
			RefineMesh = refineMesh;
			RestoreBoundary = restoreBoundary;
			SloanMaxIters = sloanMaxIters;
			ValidateInput = validateInput;
			Verbose = verbose;
			RefinementThresholdAngle = refinementThresholdAngle;
			RefinementThresholdArea = refinementThresholdArea;
		}

		public static Args Default(Preprocessor preprocessor = Preprocessor.None, int sloanMaxIters = 1000000, bool autoHolesAndBoundary = false, bool refineMesh = false, bool restoreBoundary = false, bool validateInput = true, bool verbose = true, float refinementThresholdAngle = 0.08726646f, float refinementThresholdArea = 1f)
		{
			return new Args(preprocessor, sloanMaxIters, autoHolesAndBoundary, refineMesh, restoreBoundary, validateInput, verbose, refinementThresholdAngle, refinementThresholdArea);
		}

		public static implicit operator Args(TriangulationSettings settings)
		{
			bool autoHolesAndBoundary = settings.AutoHolesAndBoundary;
			return new Args(settings.Preprocessor, refineMesh: settings.RefineMesh, restoreBoundary: settings.RestoreBoundary, sloanMaxIters: settings.SloanMaxIters, autoHolesAndBoundary: autoHolesAndBoundary, validateInput: settings.ValidateInput, verbose: settings.Verbose, refinementThresholdAngle: settings.RefinementThresholds.Angle, refinementThresholdArea: settings.RefinementThresholds.Area);
		}

		public Args With(Preprocessor? preprocessor = null, int? sloanMaxIters = null, bool? autoHolesAndBoundary = null, bool? refineMesh = null, bool? restoreBoundary = null, bool? validateInput = null, bool? verbose = null, float? refinementThresholdAngle = null, float? refinementThresholdArea = null)
		{
			return new Args(preprocessor ?? Preprocessor, sloanMaxIters ?? SloanMaxIters, autoHolesAndBoundary ?? AutoHolesAndBoundary, refineMesh ?? RefineMesh, restoreBoundary ?? RestoreBoundary, validateInput ?? ValidateInput, verbose ?? Verbose, refinementThresholdAngle ?? RefinementThresholdAngle, refinementThresholdArea ?? RefinementThresholdArea);
		}
	}
}
