using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool NrNlbwPYbvZSWBbSfBLGsRrJjvNm;

		private int wIDFIJbNFWnBFqFtmKJrlxfyFvkF;

		private int HlkLVBxENXXWjaxVoEMHjEtPDdZT;

		private ControllerType ymeuBGmmoPvIHMDqnkMwLzTsHRJE;

		public bool state => NrNlbwPYbvZSWBbSfBLGsRrJjvNm;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(ymeuBGmmoPvIHMDqnkMwLzTsHRJE, HlkLVBxENXXWjaxVoEMHjEtPDdZT);
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
				return ReInput.players.GetPlayer(wIDFIJbNFWnBFqFtmKJrlxfyFvkF);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int P_0, int P_1, ControllerType P_2, bool P_3)
		{
			NrNlbwPYbvZSWBbSfBLGsRrJjvNm = P_3;
			wIDFIJbNFWnBFqFtmKJrlxfyFvkF = P_0;
			HlkLVBxENXXWjaxVoEMHjEtPDdZT = P_1;
			ymeuBGmmoPvIHMDqnkMwLzTsHRJE = P_2;
		}
	}
}
