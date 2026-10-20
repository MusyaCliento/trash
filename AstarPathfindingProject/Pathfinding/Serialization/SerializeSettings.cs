namespace Pathfinding.Serialization
{
	public class SerializeSettings
	{
		public bool nodes = true;

		public static SerializeSettings Settings => new SerializeSettings
		{
			nodes = false
		};

		public static SerializeSettings NodesAndSettings => new SerializeSettings();
	}
}
