using LibBSP;
using UnityEngine;

namespace BSPImporter
{
	public static class TextureInfoExtensions
	{
		public static Matrix4x4 BuildTexMatrix(this TextureInfo textureInfo)
		{
			Vector3 lhs = textureInfo.UAxis.SwizzleYZ().ScaleInch2Meter();
			Vector3 rhs = textureInfo.VAxis.SwizzleYZ().ScaleInch2Meter();
			Vector3 vector = Vector3.Cross(lhs, rhs);
			Matrix4x4 identity = Matrix4x4.identity;
			identity[0, 0] = lhs.x;
			identity[0, 1] = rhs.x;
			identity[0, 2] = vector.x;
			identity[1, 0] = lhs.y;
			identity[1, 1] = rhs.y;
			identity[1, 2] = vector.y;
			identity[2, 0] = lhs.z;
			identity[2, 1] = rhs.z;
			identity[2, 2] = vector.z;
			return identity;
		}

		public static Vector2 CalculateUV(this TextureInfo textureInfo, Vector3 transformVertex, Vector2 dims)
		{
			return new Vector2((textureInfo.UAxis.sqrMagnitude * transformVertex.x + textureInfo.Translation.x) / dims.x, (textureInfo.VAxis.sqrMagnitude * transformVertex.y + textureInfo.Translation.y) / dims.y);
		}
	}
}
