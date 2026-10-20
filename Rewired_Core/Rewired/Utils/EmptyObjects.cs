using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] lziELkNRvRVRwMVfrNirJRJmzoQj;

		private static IList<T> meLEYsHQhdtTogpdMGKCKThFQOLFA;

		public static T[] array => lziELkNRvRVRwMVfrNirJRJmzoQj ?? (lziELkNRvRVRwMVfrNirJRJmzoQj = new T[0]);

		public static IList<T> EmptyReadOnlyIListT => meLEYsHQhdtTogpdMGKCKThFQOLFA ?? (meLEYsHQhdtTogpdMGKCKThFQOLFA = new ReadOnlyCollection<T>(new List<T>()));
	}
}
