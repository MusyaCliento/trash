using System.Collections.Generic;

namespace Rewired.Utils.Interfaces
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IGetValues<T>
	{
		int GetValues(IList<T> results);
	}
}
