using System;

namespace Rewired
{
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		private string qHcERMXtmAZSHlousqgGPatqhRtM;

		private int GqQNtLBvTBmTcKsQVzcebUqVLzAn;

		private ControllerType hMNHWLRzhVmFSVIvTKsPnzYOBCvh;

		public string name => qHcERMXtmAZSHlousqgGPatqhRtM;

		public int controllerId => GqQNtLBvTBmTcKsQVzcebUqVLzAn;

		public ControllerType controllerType => hMNHWLRzhVmFSVIvTKsPnzYOBCvh;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(hMNHWLRzhVmFSVIvTKsPnzYOBCvh, GqQNtLBvTBmTcKsQVzcebUqVLzAn);
			}
		}

		public ControllerStatusChangedEventArgs(string P_0, int P_1, ControllerType P_2)
		{
			qHcERMXtmAZSHlousqgGPatqhRtM = P_0;
			GqQNtLBvTBmTcKsQVzcebUqVLzAn = P_1;
			hMNHWLRzhVmFSVIvTKsPnzYOBCvh = P_2;
		}
	}
}
