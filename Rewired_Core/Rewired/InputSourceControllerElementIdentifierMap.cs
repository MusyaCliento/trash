namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal struct InputSourceControllerElementIdentifierMap
	{
		public int originalElementIdentifierId;

		public int remappedElementIdentifierId;

		public AxisRange originalElementAxisRange;

		public AxisRange remappedElementAxisRange;
	}
}
