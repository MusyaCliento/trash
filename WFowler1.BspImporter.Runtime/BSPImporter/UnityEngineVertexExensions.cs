using LibBSP;
using UnityEngine;

namespace BSPImporter
{
	public static class UnityEngineVertexExensions
	{
		public static UIVertex NegateVs(this UIVertex vertex)
		{
			Vector2 vector = vertex.uv0;
			vector.y = 0f - vector.y;
			vertex.uv0 = vector;
			Vector2 vector2 = vertex.uv1;
			vector2.y = 0f - vector2.y;
			vertex.uv1 = vector2;
			Vector2 vector3 = vertex.uv2;
			vector3.y = 0f - vector3.y;
			vertex.uv2 = vector3;
			Vector2 vector4 = vertex.uv3;
			vector4.y = 0f - vector4.y;
			vertex.uv3 = vector4;
			return vertex;
		}

		public static UIVertex ScaleInch2Meter(this UIVertex v)
		{
			v.position = v.position.ScaleInch2Meter();
			return v;
		}

		public static UIVertex CalcUV(this UIVertex vertex, TextureInfo texInfo, Vector2 dims)
		{
			Vector3 vector = texInfo.BuildTexMatrix().inverse.MultiplyPoint3x4(vertex.position);
			vertex.uv0 = new Vector2((texInfo.UAxis.sqrMagnitude * vector.x + texInfo.Translation.x) / dims.x, (texInfo.VAxis.sqrMagnitude * vector.y + texInfo.Translation.y) / dims.y);
			return vertex;
		}

		public static UIVertex SwizzleYZ(this UIVertex vertex)
		{
			vertex.position = vertex.position.SwizzleYZ();
			vertex.normal = vertex.normal.SwizzleYZ();
			return vertex;
		}
	}
}
