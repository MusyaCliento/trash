using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;

namespace LibBSP
{
	public class CoDRadiantMapWriter
	{
		private Entities _entities;

		private IFormatProvider _format = CultureInfo.CreateSpecificCulture("en-US");

		public CoDRadiantMapWriter(Entities from)
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
			if (index > 0)
			{
				sb.Append("// entity ").Append(index).Append("\r\n");
			}
			sb.Append("{\r\n");
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
			if (brush.mohTerrain != null || brush.ef2Terrain != null || (brush.sides.Count < 4 && brush.patch == null))
			{
				return;
			}
			sb.Append("// brush ").Append(index.ToString()).Append("\r\n");
			if (brush.patch != null)
			{
				ParsePatch(brush.patch, sb);
				return;
			}
			sb.Append("{\r\n");
			foreach (MAPBrushSide side in brush.sides)
			{
				ParseBrushSide(side, sb);
			}
			sb.Append("}\r\n");
		}

		private void ParseBrushSide(MAPBrushSide brushside, StringBuilder sb)
		{
			sb.Append("( ").Append(brushside.vertices[0].X().ToString("###0.##########", _format)).Append(" ")
				.Append(brushside.vertices[0].Y().ToString("###0.##########", _format))
				.Append(" ")
				.Append(brushside.vertices[0].Z().ToString("###0.##########", _format))
				.Append(" ) ( ")
				.Append(brushside.vertices[1].X().ToString("###0.##########", _format))
				.Append(" ")
				.Append(brushside.vertices[1].Y().ToString("###0.##########", _format))
				.Append(" ")
				.Append(brushside.vertices[1].Z().ToString("###0.##########", _format))
				.Append(" ) ( ")
				.Append(brushside.vertices[2].X().ToString("###0.##########", _format))
				.Append(" ")
				.Append(brushside.vertices[2].Y().ToString("###0.##########", _format))
				.Append(" ")
				.Append(brushside.vertices[2].Z().ToString("###0.##########", _format))
				.Append(" ) ")
				.Append(brushside.texture)
				.Append(" ")
				.Append(brushside.textureInfo.Translation.X().ToString("###0.##########", _format))
				.Append(" ")
				.Append(brushside.textureInfo.Translation.Y().ToString("###0.##########", _format))
				.Append(" ")
				.Append(brushside.textureInfo.rotation.ToString("###0.##########", _format))
				.Append(" ")
				.Append(brushside.textureInfo.scale.X().ToString("###0.##########", _format))
				.Append(" ")
				.Append(brushside.textureInfo.scale.Y().ToString("###0.##########", _format))
				.Append(" ")
				.Append(brushside.textureInfo.Flags)
				.Append(" 0 0 0\r\n");
		}

		private void ParsePatch(MAPPatch patch, StringBuilder sb)
		{
			sb.Append(" {\r\n  patchDef5\r\n  {\r\n   ").Append(patch.texture).Append("\r\n   ( ")
				.Append((int)Math.Round(patch.dims.X()))
				.Append(" ")
				.Append((int)Math.Round(patch.dims.Y()))
				.Append(" 0 0 0 0 8 )\r\n(\r\n");
			for (int i = 0; (float)i < patch.dims.X(); i++)
			{
				sb.Append("( ");
				for (int j = 0; (float)j < patch.dims.Y(); j++)
				{
					UIVertex uIVertex = patch.points[(int)Math.Round(patch.dims.X()) * j + i];
					sb.Append("( ").Append(uIVertex.position.X().ToString("###0.#####", _format)).Append(" ")
						.Append(uIVertex.position.Y().ToString("###0.#####", _format))
						.Append(" ")
						.Append(uIVertex.position.Z().ToString("###0.#####", _format))
						.Append(" ")
						.Append(uIVertex.uv0.X().ToString("###0.#####", _format))
						.Append(" ")
						.Append(uIVertex.uv0.Y().ToString("###0.#####", _format))
						.Append(" ")
						.Append(uIVertex.color.R().ToString(_format))
						.Append(" ")
						.Append(uIVertex.color.G().ToString(_format))
						.Append(" ")
						.Append(uIVertex.color.B().ToString(_format))
						.Append(" ")
						.Append(uIVertex.color.A().ToString(_format))
						.Append(" 0 ) ");
				}
				sb.Append(")\r\n");
			}
			sb.Append(")\r\n  }\r\n }\r\n");
		}
	}
}
