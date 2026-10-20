using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.XInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XInputControllerExtension : Controller.Extension
	{
		private class HiOSviGAiBLNUlpSCucKdswhAzXM : IControllerExtensionSource
		{
			private BdmVZBfayIRaEoZyauttTYQvabrH.EdAdrvqVjdvmYwSrfMeUtepFgJWn nzbDRAEgGAEeMENLcfshJDRzyLZnb;

			public BdmVZBfayIRaEoZyauttTYQvabrH.EdAdrvqVjdvmYwSrfMeUtepFgJWn mYKJDmYrcKmNxoiZYGQyfgLaFGLe => nzbDRAEgGAEeMENLcfshJDRzyLZnb;

			public HiOSviGAiBLNUlpSCucKdswhAzXM(BdmVZBfayIRaEoZyauttTYQvabrH.EdAdrvqVjdvmYwSrfMeUtepFgJWn P_0)
			{
				nzbDRAEgGAEeMENLcfshJDRzyLZnb = P_0;
			}
		}

		private HiOSviGAiBLNUlpSCucKdswhAzXM UUPItPxhSuKYZuVyJAOAJNBNbczbA;

		private bool qCWtYTntjJDugxiMpeuvLtrvBATT;

		private Joystick joystick => GetController<Joystick>();

		public int userIndex
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!qCWtYTntjJDugxiMpeuvLtrvBATT || !base.enabled)
				{
					return 0;
				}
				if (UUPItPxhSuKYZuVyJAOAJNBNbczbA.mYKJDmYrcKmNxoiZYGQyfgLaFGLe == null)
				{
					return 0;
				}
				return (int)UUPItPxhSuKYZuVyJAOAJNBNbczbA.mYKJDmYrcKmNxoiZYGQyfgLaFGLe.oBzNpRuvBnfNMUuIdImMpXSxHOTj.ZZwtaAHjVrnEOsmESDlQkewpcHVBA;
			}
		}

		public CapabilityFlags capabilityFlags
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return CapabilityFlags.None;
				}
				if (!qCWtYTntjJDugxiMpeuvLtrvBATT || !base.enabled)
				{
					return CapabilityFlags.None;
				}
				if (UUPItPxhSuKYZuVyJAOAJNBNbczbA.mYKJDmYrcKmNxoiZYGQyfgLaFGLe == null)
				{
					return CapabilityFlags.None;
				}
				UUPItPxhSuKYZuVyJAOAJNBNbczbA.mYKJDmYrcKmNxoiZYGQyfgLaFGLe.oBzNpRuvBnfNMUuIdImMpXSxHOTj.DFtDzqqRfmASKQzEZlEQuyAPUsME(HTmUSdjjloDLLeXwWcZCmgewsKtR.Any, out var kLVKSgSTPAtymWLTsHpBaWkOwOnI2);
				return (CapabilityFlags)kLVKSgSTPAtymWLTsHpBaWkOwOnI2.doaFUVijJNeyFOVlXNUwdWDtFkSwA;
			}
		}

		public DeviceType deviceType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return (DeviceType)0;
				}
				if (!qCWtYTntjJDugxiMpeuvLtrvBATT || !base.enabled)
				{
					return (DeviceType)0;
				}
				if (UUPItPxhSuKYZuVyJAOAJNBNbczbA.mYKJDmYrcKmNxoiZYGQyfgLaFGLe == null)
				{
					return (DeviceType)0;
				}
				UUPItPxhSuKYZuVyJAOAJNBNbczbA.mYKJDmYrcKmNxoiZYGQyfgLaFGLe.oBzNpRuvBnfNMUuIdImMpXSxHOTj.DFtDzqqRfmASKQzEZlEQuyAPUsME(HTmUSdjjloDLLeXwWcZCmgewsKtR.Any, out var kLVKSgSTPAtymWLTsHpBaWkOwOnI2);
				return (DeviceType)kLVKSgSTPAtymWLTsHpBaWkOwOnI2.ZxUschgOBYxJjoqutgZCgxRHDONIA;
			}
		}

		public DeviceSubType deviceSubType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return (DeviceSubType)0;
				}
				if (!qCWtYTntjJDugxiMpeuvLtrvBATT || !base.enabled)
				{
					return (DeviceSubType)0;
				}
				if (UUPItPxhSuKYZuVyJAOAJNBNbczbA.mYKJDmYrcKmNxoiZYGQyfgLaFGLe == null)
				{
					return (DeviceSubType)0;
				}
				UUPItPxhSuKYZuVyJAOAJNBNbczbA.mYKJDmYrcKmNxoiZYGQyfgLaFGLe.oBzNpRuvBnfNMUuIdImMpXSxHOTj.DFtDzqqRfmASKQzEZlEQuyAPUsME(HTmUSdjjloDLLeXwWcZCmgewsKtR.Any, out var kLVKSgSTPAtymWLTsHpBaWkOwOnI2);
				return (DeviceSubType)kLVKSgSTPAtymWLTsHpBaWkOwOnI2.oczyOVIGQzCnKAvekzEGfHsnQeCh;
			}
		}

		internal XInputControllerExtension(BdmVZBfayIRaEoZyauttTYQvabrH.EdAdrvqVjdvmYwSrfMeUtepFgJWn P_0)
			: base(new HiOSviGAiBLNUlpSCucKdswhAzXM(P_0))
		{
		}

		private XInputControllerExtension(XInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (qCWtYTntjJDugxiMpeuvLtrvBATT)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			UUPItPxhSuKYZuVyJAOAJNBNbczbA = source as HiOSviGAiBLNUlpSCucKdswhAzXM;
			qCWtYTntjJDugxiMpeuvLtrvBATT = UUPItPxhSuKYZuVyJAOAJNBNbczbA != null;
		}

		internal override Controller.Extension Clone()
		{
			return new XInputControllerExtension(this);
		}
	}
}
