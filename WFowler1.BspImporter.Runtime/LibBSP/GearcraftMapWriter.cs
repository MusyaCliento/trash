using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LibBSP
{
	public class GearcraftMapWriter
	{
		private Entities _entities;

		private IFormatProvider _format = CultureInfo.CreateSpecificCulture("en-US");

		public GearcraftMapWriter(Entities from)
		{
			_entities = from;
		}

		public string ParseMap()
		{
			StringBuilder stringBuilder = new StringBuilder(524288);
			for (int i = 0; i < _entities.Count; i++)
			{
				ParseEntity(_entities[i], i, stringBuilder);
			}
			return stringBuilder.ToString();
		}

		private void ParseEntity(Entity entity, int index, StringBuilder sb)
		{
			sb.Append("{ // Entity ").Append(index.ToString()).Append("\r\n");
			foreach (KeyValuePair<string, string> item in entity)
			{
				sb.Append("\"").Append(item.Key).Append("\" \"")
					.Append(item.Value)
					.Append("\"\r\n");
			}
			for (int i = 0; i < entity.brushes.Count; i++)
			{
				ParseBrush(entity.brushes[i], i, sb);
			}
			sb.Append("}\r\n");
		}

		private void ParseBrush(MAPBrush brush, int index, StringBuilder sb)
		{
			if (brush.patch != null || brush.ef2Terrain != null || brush.mohTerrain != null || brush.sides.Count < 4)
			{
				return;
			}
			sb.Append("{ // Brush ").Append(index.ToString()).Append("\r\n");
			if (brush.isDetail)
			{
				sb.Append("\"BRUSHFLAGS\" \"DETAIL\"\r\n");
			}
			foreach (MAPBrushSide side in brush.sides)
			{
				ParseBrushSide(side, sb);
			}
			sb.Append("}\r\n");
		}

		private void ParseBrushSide(MAPBrushSide brushside, StringBuilder sb)
		{
			sb.Append("( ").Append(brushside.vertices[0].X().ToString("###0.000000", _format)).Append(" ")
				.Append(brushside.vertices[0].Y().ToString("###0.000000", _format))
				.Append(" ")
				.Append(brushside.vertices[0].Z().ToString("###0.000000", _format))
				.Append(" ) ( ")
				.Append(brushside.vertices[1].X().ToString("###0.000000", _format))
				.Append(" ")
				.Append(brushside.vertices[1].Y().ToString("###0.000000", _format))
				.Append(" ")
				.Append(brushside.vertices[1].Z().ToString("###0.000000", _format))
				.Append(" ) ( ")
				.Append(brushside.vertices[2].X().ToString("###0.000000", _format))
				.Append(" ")
				.Append(brushside.vertices[2].Y().ToString("###0.000000", _format))
				.Append(" ")
				.Append(brushside.vertices[2].Z().ToString("###0.000000", _format))
				.Append(" ) ")
				.Append(brushside.texture)
				.Append(" [ ")
				.Append(brushside.textureInfo.UAxis.X().ToString("###0.####", _format))
				.Append(" ")
				.Append(brushside.textureInfo.UAxis.Y().ToString("###0.####", _format))
				.Append(" ")
				.Append(brushside.textureInfo.UAxis.Z().ToString("###0.####", _format))
				.Append(" ")
				.Append(brushside.textureInfo.Translation.X().ToString("###0.####", _format))
				.Append(" ] [ ")
				.Append(brushside.textureInfo.VAxis.X().ToString("###0.####", _format))
				.Append(" ")
				.Append(brushside.textureInfo.VAxis.Y().ToString("###0.####", _format))
				.Append(" ")
				.Append(brushside.textureInfo.VAxis.Z().ToString("###0.####", _format))
				.Append(" ")
				.Append(brushside.textureInfo.Translation.Y().ToString("###0.####", _format))
				.Append(" ] ")
				.Append(brushside.textureInfo.rotation.ToString("###0.####", _format))
				.Append(" ")
				.Append(brushside.textureInfo.scale.X().ToString("###0.####", _format))
				.Append(" ")
				.Append(brushside.textureInfo.scale.Y().ToString("###0.####", _format))
				.Append(" ")
				.Append(brushside.textureInfo.Flags)
				.Append(" ")
				.Append(brushside.material)
				.Append(" [ ")
				.Append(brushside.lgtScale.ToString("###0.####", _format))
				.Append(" ")
				.Append(brushside.lgtRot.ToString("###0.####", _format))
				.Append(" ]\r\n");
		}
	}
}
