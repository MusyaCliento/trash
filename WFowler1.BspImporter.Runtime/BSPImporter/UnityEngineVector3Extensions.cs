using UnityEngine;

namespace BSPImporter
{
	public static class UnityEngineVector3Extensions
	{
		public static Vector3 SwizzleYZ(this Vector3 v)
		{
			return new Vector3(v.x, v.z, v.y);
		}

		public static Vector3 ScaleInch2Meter(this Vector3 v)
		{
			return v * 0.0254f;
		}
	}
}
