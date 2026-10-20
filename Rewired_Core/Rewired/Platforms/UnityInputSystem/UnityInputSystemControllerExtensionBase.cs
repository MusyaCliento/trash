using System.ComponentModel;
using Rewired.Interfaces;

namespace Rewired.Platforms.UnityInputSystem
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public abstract class UnityInputSystemControllerExtensionBase : Controller.Extension
	{
		protected abstract class Source : IControllerExtensionSource
		{
		}

		private bool ZinuSocnmfpoSOCRaZSIEjhqgFzhA;

		protected UnityInputSystemControllerExtensionBase(Source P_0)
			: base(P_0)
		{
		}

		protected UnityInputSystemControllerExtensionBase(UnityInputSystemControllerExtensionBase P_0)
			: base(P_0)
		{
		}

		protected virtual void OnUpdateData(UpdateLoopType updateLoop)
		{
		}

		protected virtual void OnSourceUpdated(IControllerExtensionSource source)
		{
		}

		protected new IControllerExtensionSource GetSource()
		{
			return base.GetSource();
		}

		public abstract Controller.Extension ShallowCopy();

		internal override Controller.Extension Clone()
		{
			return ShallowCopy();
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (ZinuSocnmfpoSOCRaZSIEjhqgFzhA && base.enabled)
			{
				OnUpdateData(updateLoop);
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			ZinuSocnmfpoSOCRaZSIEjhqgFzhA = source != null;
			OnSourceUpdated(source);
		}
	}
}
