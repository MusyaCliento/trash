namespace Rewired.ControllerExtensions
{
	public enum TrackedDeviceTrackedValueFlags
	{
		None = 0,
		Position = 1,
		Rotation = 2,
		Velocity = 4,
		AngularVelocity = 8,
		Acceleration = 16,
		AngularAcceleration = 32,
		All = -1
	}
}
