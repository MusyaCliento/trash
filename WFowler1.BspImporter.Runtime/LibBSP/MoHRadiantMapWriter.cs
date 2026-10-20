using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;

namespace LibBSP
{
	public class MoHRadiantMapWriter
	{
		private Entities _entities;

		private IFormatProvider _format = CultureInfo.CreateSpecificCulture("en-US");

		public MoHRadiantMapWriter(Entities from)
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
			if (index != 0)
			{
				sb.Append("// Entity ").Append(index).Append("\r\n");
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
			if (brush.ef2Terrain != null || (brush.sides.Count < 4 && brush.patch == null && brush.mohTerrain == null))
			{
				return;
			}
			sb.Append("// Brush ").Append(index.ToString()).Append("\r\n");
			if (brush.patch != null)
			{
				ParsePatch(brush.patch, sb);
				return;
			}
			if (brush.mohTerrain != null)
			{
				ParseTerrain(brush.mohTerrain, sb);
				return;
			}
			sb.Append("{\r\n");
			foreach (MAPBrushSide side in brush.sides)
			{
				ParseBrushSide(side, brush.isDetail, sb);
			}
			sb.Append("}\r\n");
		}

		private void ParseBrushSide(MAPBrushSide brushside, bool isDetail, StringBuilder sb)
		{
			sb.Append("( ").Append(brushside.vertices[0].X().ToString("###0.######", _format)).Append(" ")
				.Append(brushside.vertices[0].Y().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.vertices[0].Z().ToString("###0.######", _format))
				.Append(" ) ( ")
				.Append(brushside.vertices[1].X().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.vertices[1].Y().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.vertices[1].Z().ToString("###0.######", _format))
				.Append(" ) ( ")
				.Append(brushside.vertices[2].X().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.vertices[2].Y().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.vertices[2].Z().ToString("###0.######", _format))
				.Append(" ) ")
				.Append(brushside.texture)
				.Append(" ")
				.Append(brushside.textureInfo.Translation.X().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.textureInfo.Translation.Y().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.textureInfo.rotation.ToString("###0.00", _format))
				.Append(" ")
				.Append(brushside.textureInfo.scale.X().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.textureInfo.scale.Y().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.textureInfo.Flags)
				.Append(" 0 0");
			if (isDetail)
			{
				sb.Append(" +surfaceparm detail");
			}
			sb.Append("\r\n");
		}

		private void ParsePatch(MAPPatch patch, StringBuilder sb)
		{
			sb.Append(" {\r\n  patchDef2\r\n  {\r\n").Append(patch.texture).Append("\r\n( ")
				.Append((int)Math.Round(patch.dims.X()))
				.Append(" ")
				.Append((int)Math.Round(patch.dims.Y()))
				.Append(" 0 0 0 )\r\n(\r\n");
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
						.Append(" ) ");
				}
				sb.Append(")\r\n");
			}
			sb.Append(")\r\n  }\r\n }\r\n");
		}

		private void ParseTerrain(MAPTerrainMoHAA terrain, StringBuilder sb)
		{
			sb.Append(" {\r\n  terrainDef\r\n  {\r\n   ").Append(terrain.size.X()).Append(" ")
				.Append(terrain.size.Y())
				.Append(" ")
				.Append(terrain.flags)
				.Append("\r\n   ")
				.Append(terrain.origin.X().ToString("###0.000000"))
				.Append(" ")
				.Append(terrain.origin.Y().ToString("###0.000000"))
				.Append(" ")
				.Append(terrain.origin.Z().ToString("###0.000000"))
				.Append("\r\n\t\t{\r\n");
			foreach (MAPTerrainMoHAA.Partition partition in terrain.partitions)
			{
				sb.Append("\t\t\t").Append(partition.unknown1).Append(" ")
					.Append(partition.unknown2)
					.Append(" ( ")
					.Append(partition.shader)
					.Append(" ")
					.Append(partition.textureShift[0])
					.Append(" ")
					.Append(partition.textureShift[1])
					.Append(" ")
					.Append(partition.rotation.ToString("###0.00"))
					.Append(" ")
					.Append(partition.unknown3)
					.Append(" ")
					.Append(partition.textureScale[0])
					.Append(" ")
					.Append(partition.textureScale[1])
					.Append(" ")
					.Append(partition.unknown4)
					.Append(" ")
					.Append(partition.flags)
					.Append(" ")
					.Append(partition.unknown5);
				if (!string.IsNullOrEmpty(partition.properties))
				{
					sb.Append(" ").Append(partition.properties);
				}
				sb.Append(" )\r\n");
			}
			sb.Append("\t\t}\r\n\t\t{\r\n");
			foreach (MAPTerrainMoHAA.Vertex vertex in terrain.vertices)
			{
				sb.Append("\t\t\t").Append(vertex.height.ToString("###0.000000")).Append(" ( ");
				if (!string.IsNullOrEmpty(vertex.unknown1))
				{
					sb.Append(vertex.unknown1).Append(" ");
				}
				sb.Append(") ( ");
				if (!string.IsNullOrEmpty(vertex.unknown2))
				{
					sb.Append(vertex.unknown2).Append(" ");
				}
				sb.Append(")\r\n");
			}
			sb.Append("\t\t}\r\n  }\r\n }\r\n");
		}
	}
}
