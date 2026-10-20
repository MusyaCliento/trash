namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool mgLLaJITFOdkGomLKGpXEaMiXkGR;

		private bool ibLFFEoESiBicfDwMKdVrrYrFIVuA;

		private int UxgDuyHkzBippSMhPsgMjJKytEvc;

		private ControllerType pfQHseKPAMryvqAuxevODOngCJStb;

		private int svDfqRzcTyZUNIfgNbsSdvjTapAXA;

		private int XylcjLUftWZHAKucgtwLaDQgRyym;

		private int ECjXuNykTeXocriCMfJOiXkjGsHLA;

		private ControllerElementType JSppyupQqItjPnyzICZnLYhdtHyI;

		private int GfnlReAXyKUapmyCVAQClSqpmTLg;

		private KeyboardKeyCode ZmeyjEoiGcDGzGxdDiQGaXpJuhnC;

		private ModifierKeyFlags JKKcmKDoWPeRXfLpdrgllwYdfKEje;

		private int PeplldkVeaQzOwuZTnOUmiNVgKYj;

		public bool isConflict
		{
			get
			{
				return mgLLaJITFOdkGomLKGpXEaMiXkGR;
			}
			internal set
			{
				mgLLaJITFOdkGomLKGpXEaMiXkGR = flag;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return ibLFFEoESiBicfDwMKdVrrYrFIVuA;
			}
			internal set
			{
				ibLFFEoESiBicfDwMKdVrrYrFIVuA = flag;
			}
		}

		public int playerId
		{
			get
			{
				return UxgDuyHkzBippSMhPsgMjJKytEvc;
			}
			internal set
			{
				UxgDuyHkzBippSMhPsgMjJKytEvc = uxgDuyHkzBippSMhPsgMjJKytEvc;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return pfQHseKPAMryvqAuxevODOngCJStb;
			}
			internal set
			{
				pfQHseKPAMryvqAuxevODOngCJStb = controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				return svDfqRzcTyZUNIfgNbsSdvjTapAXA;
			}
			internal set
			{
				svDfqRzcTyZUNIfgNbsSdvjTapAXA = num;
			}
		}

		public int controllerMapId
		{
			get
			{
				return XylcjLUftWZHAKucgtwLaDQgRyym;
			}
			internal set
			{
				XylcjLUftWZHAKucgtwLaDQgRyym = xylcjLUftWZHAKucgtwLaDQgRyym;
			}
		}

		public int elementMapId
		{
			get
			{
				return ECjXuNykTeXocriCMfJOiXkjGsHLA;
			}
			internal set
			{
				ECjXuNykTeXocriCMfJOiXkjGsHLA = eCjXuNykTeXocriCMfJOiXkjGsHLA;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return JSppyupQqItjPnyzICZnLYhdtHyI;
			}
			internal set
			{
				JSppyupQqItjPnyzICZnLYhdtHyI = jSppyupQqItjPnyzICZnLYhdtHyI;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return GfnlReAXyKUapmyCVAQClSqpmTLg;
			}
			internal set
			{
				GfnlReAXyKUapmyCVAQClSqpmTLg = gfnlReAXyKUapmyCVAQClSqpmTLg;
			}
		}

		public KeyboardKeyCode keyCode
		{
			get
			{
				return ZmeyjEoiGcDGzGxdDiQGaXpJuhnC;
			}
			internal set
			{
				ZmeyjEoiGcDGzGxdDiQGaXpJuhnC = zmeyjEoiGcDGzGxdDiQGaXpJuhnC;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return JKKcmKDoWPeRXfLpdrgllwYdfKEje;
			}
			internal set
			{
				JKKcmKDoWPeRXfLpdrgllwYdfKEje = jKKcmKDoWPeRXfLpdrgllwYdfKEje;
			}
		}

		public int actionId
		{
			get
			{
				return PeplldkVeaQzOwuZTnOUmiNVgKYj;
			}
			internal set
			{
				PeplldkVeaQzOwuZTnOUmiNVgKYj = peplldkVeaQzOwuZTnOUmiNVgKYj;
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
				return ReInput.players.GetPlayer(UxgDuyHkzBippSMhPsgMjJKytEvc);
			}
		}

		public InputAction action
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.mapping.GetAction(PeplldkVeaQzOwuZTnOUmiNVgKYj);
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
				return ReInput.controllers.GetController(pfQHseKPAMryvqAuxevODOngCJStb, svDfqRzcTyZUNIfgNbsSdvjTapAXA);
			}
		}

		public ControllerMap controllerMap
		{
			get
			{
				if (player == null)
				{
					return null;
				}
				return player.controllers.maps.GetMap(pfQHseKPAMryvqAuxevODOngCJStb, svDfqRzcTyZUNIfgNbsSdvjTapAXA, XylcjLUftWZHAKucgtwLaDQgRyym);
			}
		}

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(GfnlReAXyKUapmyCVAQClSqpmTLg);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (controllerMap == null)
				{
					return null;
				}
				return controllerMap.GetElementMap(ECjXuNykTeXocriCMfJOiXkjGsHLA);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (pfQHseKPAMryvqAuxevODOngCJStb == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(ZmeyjEoiGcDGzGxdDiQGaXpJuhnC, JKKcmKDoWPeRXfLpdrgllwYdfKEje);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(GfnlReAXyKUapmyCVAQClSqpmTLg);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename;
			}
		}

		public ElementAssignmentConflictInfo(bool P_0, bool P_1, int P_2, ControllerType P_3, int P_4, int P_5, int P_6, int P_7, ControllerElementType P_8, int P_9, KeyboardKeyCode P_10, ModifierKeyFlags P_11)
		{
			mgLLaJITFOdkGomLKGpXEaMiXkGR = P_0;
			ibLFFEoESiBicfDwMKdVrrYrFIVuA = P_1;
			UxgDuyHkzBippSMhPsgMjJKytEvc = P_2;
			pfQHseKPAMryvqAuxevODOngCJStb = P_3;
			svDfqRzcTyZUNIfgNbsSdvjTapAXA = P_4;
			XylcjLUftWZHAKucgtwLaDQgRyym = P_5;
			ECjXuNykTeXocriCMfJOiXkjGsHLA = P_6;
			PeplldkVeaQzOwuZTnOUmiNVgKYj = P_7;
			JSppyupQqItjPnyzICZnLYhdtHyI = P_8;
			GfnlReAXyKUapmyCVAQClSqpmTLg = P_9;
			ZmeyjEoiGcDGzGxdDiQGaXpJuhnC = P_10;
			JKKcmKDoWPeRXfLpdrgllwYdfKEje = P_11;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo P_0)
		{
			mgLLaJITFOdkGomLKGpXEaMiXkGR = P_0.mgLLaJITFOdkGomLKGpXEaMiXkGR;
			ibLFFEoESiBicfDwMKdVrrYrFIVuA = P_0.ibLFFEoESiBicfDwMKdVrrYrFIVuA;
			UxgDuyHkzBippSMhPsgMjJKytEvc = P_0.UxgDuyHkzBippSMhPsgMjJKytEvc;
			pfQHseKPAMryvqAuxevODOngCJStb = P_0.pfQHseKPAMryvqAuxevODOngCJStb;
			svDfqRzcTyZUNIfgNbsSdvjTapAXA = P_0.svDfqRzcTyZUNIfgNbsSdvjTapAXA;
			XylcjLUftWZHAKucgtwLaDQgRyym = P_0.XylcjLUftWZHAKucgtwLaDQgRyym;
			ECjXuNykTeXocriCMfJOiXkjGsHLA = P_0.ECjXuNykTeXocriCMfJOiXkjGsHLA;
			PeplldkVeaQzOwuZTnOUmiNVgKYj = P_0.PeplldkVeaQzOwuZTnOUmiNVgKYj;
			JSppyupQqItjPnyzICZnLYhdtHyI = P_0.JSppyupQqItjPnyzICZnLYhdtHyI;
			GfnlReAXyKUapmyCVAQClSqpmTLg = P_0.GfnlReAXyKUapmyCVAQClSqpmTLg;
			ZmeyjEoiGcDGzGxdDiQGaXpJuhnC = P_0.ZmeyjEoiGcDGzGxdDiQGaXpJuhnC;
			JKKcmKDoWPeRXfLpdrgllwYdfKEje = P_0.JKKcmKDoWPeRXfLpdrgllwYdfKEje;
		}
	}
}
