using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool eErfsGHFOYDrwGztHhEXPqGgDBbpD;

		private int cEOdrCCKCzsjVaGfLgzhsWdQmDkN;

		private Vector2 waQWuGmIKLQzqsqZbMFazjWaLsYN;

		private Vector2 AMBEYmtKYIyapnfabIdmHUSOgsE;

		private Vector2 fuQYHXnNeUEFUjUFkjbyncCiIAbWA;

		private Vector2 IyyXUJZQGKmKATmtMAvyXJQCUDCk;

		private float JuDCXBBGVTfbVvFXdOmtHxFUQAmrA;

		private int AvyYGltcsmJLCejoWtcJQEUqdqVu;

		public bool isValid
		{
			get
			{
				return eErfsGHFOYDrwGztHhEXPqGgDBbpD;
			}
			internal set
			{
				eErfsGHFOYDrwGztHhEXPqGgDBbpD = value;
			}
		}

		public int touchId
		{
			get
			{
				return cEOdrCCKCzsjVaGfLgzhsWdQmDkN;
			}
			internal set
			{
				cEOdrCCKCzsjVaGfLgzhsWdQmDkN = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return waQWuGmIKLQzqsqZbMFazjWaLsYN;
			}
			internal set
			{
				waQWuGmIKLQzqsqZbMFazjWaLsYN = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return AMBEYmtKYIyapnfabIdmHUSOgsE;
			}
			internal set
			{
				AMBEYmtKYIyapnfabIdmHUSOgsE = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return fuQYHXnNeUEFUjUFkjbyncCiIAbWA;
			}
			internal set
			{
				fuQYHXnNeUEFUjUFkjbyncCiIAbWA = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return IyyXUJZQGKmKATmtMAvyXJQCUDCk;
			}
			internal set
			{
				IyyXUJZQGKmKATmtMAvyXJQCUDCk = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return JuDCXBBGVTfbVvFXdOmtHxFUQAmrA;
			}
			internal set
			{
				JuDCXBBGVTfbVvFXdOmtHxFUQAmrA = value;
			}
		}

		public int tapCount
		{
			get
			{
				return AvyYGltcsmJLCejoWtcJQEUqdqVu;
			}
			internal set
			{
				AvyYGltcsmJLCejoWtcJQEUqdqVu = value;
			}
		}

		internal static TouchInfo Invalid => new TouchInfo
		{
			eErfsGHFOYDrwGztHhEXPqGgDBbpD = false
		};

		internal TouchInfo(bool P_0, int P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, Vector2 P_5, float P_6, int P_7)
		{
			eErfsGHFOYDrwGztHhEXPqGgDBbpD = P_0;
			cEOdrCCKCzsjVaGfLgzhsWdQmDkN = P_1;
			waQWuGmIKLQzqsqZbMFazjWaLsYN = P_2;
			AMBEYmtKYIyapnfabIdmHUSOgsE = P_3;
			fuQYHXnNeUEFUjUFkjbyncCiIAbWA = P_4;
			IyyXUJZQGKmKATmtMAvyXJQCUDCk = P_5;
			JuDCXBBGVTfbVvFXdOmtHxFUQAmrA = P_6;
			AvyYGltcsmJLCejoWtcJQEUqdqVu = P_7;
		}
	}
}
