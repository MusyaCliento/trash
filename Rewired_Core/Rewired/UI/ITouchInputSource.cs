namespace Rewired.UI
{
	public interface ITouchInputSource
	{
		int playerId { get; }

		bool touchSupported { get; }

		int touchCount { get; }

		UnityTouch GetTouch(int index);
	}
}
