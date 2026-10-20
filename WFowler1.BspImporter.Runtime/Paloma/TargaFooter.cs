namespace Paloma
{
	public class TargaFooter
	{
		private int intExtensionAreaOffset;

		private int intDeveloperDirectoryOffset;

		private string strSignature = string.Empty;

		private string strReservedCharacter = string.Empty;

		public int ExtensionAreaOffset => intExtensionAreaOffset;

		public int DeveloperDirectoryOffset => intDeveloperDirectoryOffset;

		public string Signature => strSignature;

		public string ReservedCharacter => strReservedCharacter;

		protected internal void SetExtensionAreaOffset(int intExtensionAreaOffset)
		{
			this.intExtensionAreaOffset = intExtensionAreaOffset;
		}

		protected internal void SetDeveloperDirectoryOffset(int intDeveloperDirectoryOffset)
		{
			this.intDeveloperDirectoryOffset = intDeveloperDirectoryOffset;
		}

		protected internal void SetSignature(string strSignature)
		{
			this.strSignature = strSignature;
		}

		protected internal void SetReservedCharacter(string strReservedCharacter)
		{
			this.strReservedCharacter = strReservedCharacter;
		}
	}
}
