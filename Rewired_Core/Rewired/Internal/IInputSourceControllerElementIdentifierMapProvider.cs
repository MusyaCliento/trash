using System;
using System.Collections.Generic;

namespace Rewired.Internal
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IInputSourceControllerElementIdentifierMapProvider
	{
		event Action RemappedEvent;

		int GetMaps(IList<InputSourceControllerElementIdentifierMap> results);
	}
}
