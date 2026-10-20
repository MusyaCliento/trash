namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool PIRrVQWAlzSBHuPeptdAWvriOZsg;

		private int jIbVZvzHkZkOTIAhFvGTuTmTXJsf;

		private int TeafETEczRnlDHsChsJFuIOooSVsA;

		private string BOhXbnnNSAKiipBAFCKWquENeeib;

		private ControllerType ykrxgasRacITZVVyFbduHIoDktPnA;

		private ControllerElementType HgOSVlLEGQjCeJdryouzxemnBOReA;

		private int RFtcrpudcKWOllZXyMyYhbeElqBC;

		private Pole WVaiCwuIfaeoDiNmHHPDNGhCBGNuA;

		private string YjpZnvxLyqIzEDxeJqdNDglsNRtb;

		private int ckUGbQYrzNPhGCbkiUAZdirJhsgW;

		private KeyboardKeyCode YPlrlrmkzvefxusuERckUPwnGdDAA;

		public bool success
		{
			get
			{
				return PIRrVQWAlzSBHuPeptdAWvriOZsg;
			}
			internal set
			{
				PIRrVQWAlzSBHuPeptdAWvriOZsg = pIRrVQWAlzSBHuPeptdAWvriOZsg;
			}
		}

		public int playerId
		{
			get
			{
				return jIbVZvzHkZkOTIAhFvGTuTmTXJsf;
			}
			internal set
			{
				jIbVZvzHkZkOTIAhFvGTuTmTXJsf = num;
			}
		}

		public int controllerId
		{
			get
			{
				return TeafETEczRnlDHsChsJFuIOooSVsA;
			}
			internal set
			{
				TeafETEczRnlDHsChsJFuIOooSVsA = teafETEczRnlDHsChsJFuIOooSVsA;
			}
		}

		public string controllerName
		{
			get
			{
				return BOhXbnnNSAKiipBAFCKWquENeeib;
			}
			internal set
			{
				BOhXbnnNSAKiipBAFCKWquENeeib = bOhXbnnNSAKiipBAFCKWquENeeib;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return ykrxgasRacITZVVyFbduHIoDktPnA;
			}
			internal set
			{
				ykrxgasRacITZVVyFbduHIoDktPnA = controllerType;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return HgOSVlLEGQjCeJdryouzxemnBOReA;
			}
			internal set
			{
				HgOSVlLEGQjCeJdryouzxemnBOReA = hgOSVlLEGQjCeJdryouzxemnBOReA;
			}
		}

		public int elementIndex
		{
			get
			{
				return RFtcrpudcKWOllZXyMyYhbeElqBC;
			}
			internal set
			{
				RFtcrpudcKWOllZXyMyYhbeElqBC = rFtcrpudcKWOllZXyMyYhbeElqBC;
			}
		}

		public Pole axisPole
		{
			get
			{
				return WVaiCwuIfaeoDiNmHHPDNGhCBGNuA;
			}
			internal set
			{
				WVaiCwuIfaeoDiNmHHPDNGhCBGNuA = wVaiCwuIfaeoDiNmHHPDNGhCBGNuA;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return YjpZnvxLyqIzEDxeJqdNDglsNRtb;
			}
			internal set
			{
				YjpZnvxLyqIzEDxeJqdNDglsNRtb = yjpZnvxLyqIzEDxeJqdNDglsNRtb;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return ckUGbQYrzNPhGCbkiUAZdirJhsgW;
			}
			internal set
			{
				ckUGbQYrzNPhGCbkiUAZdirJhsgW = num;
			}
		}

		public KeyboardKeyCode keyboardKey
		{
			get
			{
				return YPlrlrmkzvefxusuERckUPwnGdDAA;
			}
			internal set
			{
				YPlrlrmkzvefxusuERckUPwnGdDAA = yPlrlrmkzvefxusuERckUPwnGdDAA;
			}
		}

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (!ReInput.kaDCuNAiSdnlkLeWRajALqrXMggab.rqEbmZfiudBJLjuixJxZtLgFiZOi(jIbVZvzHkZkOTIAhFvGTuTmTXJsf))
				{
					return null;
				}
				return ReInput.kaDCuNAiSdnlkLeWRajALqrXMggab.lDoHnmryxjmnpsBMkafFfmrvyKiB(jIbVZvzHkZkOTIAhFvGTuTmTXJsf);
			}
		}

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(ykrxgasRacITZVVyFbduHIoDktPnA, TeafETEczRnlDHsChsJFuIOooSVsA);
			}
		}

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return controller?.GetElementIdentifierById(ckUGbQYrzNPhGCbkiUAZdirJhsgW);
			}
		}

		internal ControllerPollingInfo(bool P_0, int P_1, int P_2, string P_3, ControllerType P_4, ControllerElementType P_5, int P_6, Pole P_7, string P_8, int P_9, KeyboardKeyCode P_10)
		{
			PIRrVQWAlzSBHuPeptdAWvriOZsg = P_0;
			jIbVZvzHkZkOTIAhFvGTuTmTXJsf = P_1;
			TeafETEczRnlDHsChsJFuIOooSVsA = P_2;
			BOhXbnnNSAKiipBAFCKWquENeeib = P_3;
			ykrxgasRacITZVVyFbduHIoDktPnA = P_4;
			HgOSVlLEGQjCeJdryouzxemnBOReA = P_5;
			RFtcrpudcKWOllZXyMyYhbeElqBC = P_6;
			WVaiCwuIfaeoDiNmHHPDNGhCBGNuA = P_7;
			YjpZnvxLyqIzEDxeJqdNDglsNRtb = P_8;
			ckUGbQYrzNPhGCbkiUAZdirJhsgW = P_9;
			YPlrlrmkzvefxusuERckUPwnGdDAA = P_10;
		}

		internal ControllerPollingInfo(ControllerPollingInfo P_0)
		{
			PIRrVQWAlzSBHuPeptdAWvriOZsg = P_0.PIRrVQWAlzSBHuPeptdAWvriOZsg;
			jIbVZvzHkZkOTIAhFvGTuTmTXJsf = P_0.jIbVZvzHkZkOTIAhFvGTuTmTXJsf;
			TeafETEczRnlDHsChsJFuIOooSVsA = P_0.TeafETEczRnlDHsChsJFuIOooSVsA;
			BOhXbnnNSAKiipBAFCKWquENeeib = P_0.BOhXbnnNSAKiipBAFCKWquENeeib;
			ykrxgasRacITZVVyFbduHIoDktPnA = P_0.ykrxgasRacITZVVyFbduHIoDktPnA;
			HgOSVlLEGQjCeJdryouzxemnBOReA = P_0.HgOSVlLEGQjCeJdryouzxemnBOReA;
			RFtcrpudcKWOllZXyMyYhbeElqBC = P_0.RFtcrpudcKWOllZXyMyYhbeElqBC;
			WVaiCwuIfaeoDiNmHHPDNGhCBGNuA = P_0.WVaiCwuIfaeoDiNmHHPDNGhCBGNuA;
			YjpZnvxLyqIzEDxeJqdNDglsNRtb = P_0.YjpZnvxLyqIzEDxeJqdNDglsNRtb;
			ckUGbQYrzNPhGCbkiUAZdirJhsgW = P_0.ckUGbQYrzNPhGCbkiUAZdirJhsgW;
			YPlrlrmkzvefxusuERckUPwnGdDAA = P_0.YPlrlrmkzvefxusuERckUPwnGdDAA;
		}

		internal static ControllerPollingInfo sibYIoxcdAWUVcmislmwgFvCUlnU()
		{
			return new ControllerPollingInfo(false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyboardKeyCode.None);
		}
	}
}
