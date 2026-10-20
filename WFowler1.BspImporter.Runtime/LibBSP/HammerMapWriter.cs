using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LibBSP
{
	public class HammerMapWriter
	{
		private Entities _entities;

		private IFormatProvider _format = CultureInfo.CreateSpecificCulture("en-US");

		private int _nextID;

		public HammerMapWriter(Entities from)
		{
			_entities = from;
		}

		public string ParseMap()
		{
			StringBuilder stringBuilder = new StringBuilder(524288);
			for (int i = 0; i < _entities.Count; i++)
			{
				_nextID++;
				ParseEntity(_entities[i], stringBuilder);
			}
			return stringBuilder.ToString();
		}

		private void ParseEntity(Entity entity, StringBuilder sb)
		{
			if (entity.ValueIs("classname", "worldspawn"))
			{
				sb.Append("world\r\n{\r\n");
			}
			else
			{
				sb.Append("entity\r\n{\r\n");
			}
			foreach (KeyValuePair<string, string> item in entity)
			{
				sb.Append("\t\"").Append(item.Key).Append("\" \"")
					.Append(item.Value)
					.Append("\"\r\n");
			}
			sb.Append("\t\"id\" \"").Append(_nextID).Append("\"\r\n");
			if (entity.connections.Any())
			{
				sb.Append("\tconnections\r\n\t{\r\n");
				foreach (Entity.EntityConnection connection in entity.connections)
				{
					sb.Append("\t\t\"").Append(connection.name).Append("\" \"")
						.Append(connection.target)
						.Append(",")
						.Append(connection.action)
						.Append(",")
						.Append(connection.param)
						.Append(",")
						.Append(connection.delay.ToString("###0.######", _format))
						.Append(",")
						.Append(connection.fireOnce);
					if (connection.unknown0 != "" || connection.unknown1 != "")
					{
						sb.Append(",").Append(connection.unknown0).Append(",")
							.Append(connection.unknown1);
					}
					sb.Append("\"\r\n");
				}
				sb.Append("\t}\r\n");
			}
			for (int i = 0; i < entity.brushes.Count; i++)
			{
				_nextID++;
				ParseBrush(entity.brushes[i], sb);
			}
			sb.Append("}\r\n");
		}

		private void ParseBrush(MAPBrush brush, StringBuilder sb)
		{
			if (brush.patch != null || brush.ef2Terrain != null || brush.mohTerrain != null || brush.sides.Count < 4)
			{
				return;
			}
			sb.Append("\tsolid\r\n\t{\r\n\t\t\"id\" \"").Append(_nextID).Append("\"\r\n");
			foreach (MAPBrushSide side in brush.sides)
			{
				_nextID++;
				ParseBrushSide(side, sb);
			}
			sb.Append("\t}\r\n");
		}

		private void ParseBrushSide(MAPBrushSide brushside, StringBuilder sb)
		{
			sb.Append("\t\tside\r\n\t\t{\r\n\t\t\t\"id\" \"").Append(_nextID).Append("\"\r\n\t\t\t\"plane\" \"(")
				.Append(brushside.vertices[0].X().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.vertices[0].Y().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.vertices[0].Z().ToString("###0.######", _format))
				.Append(") (")
				.Append(brushside.vertices[1].X().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.vertices[1].Y().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.vertices[1].Z().ToString("###0.######", _format))
				.Append(") (")
				.Append(brushside.vertices[2].X().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.vertices[2].Y().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.vertices[2].Z().ToString("###0.######", _format))
				.Append(")\"\r\n\t\t\t\"material\" \"")
				.Append(brushside.texture)
				.Append("\"\r\n\t\t\t\"uaxis\" \"[")
				.Append(brushside.textureInfo.UAxis.X().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.textureInfo.UAxis.Y().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.textureInfo.UAxis.Z().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.textureInfo.Translation.X().ToString("###0.######", _format))
				.Append("] ")
				.Append(brushside.textureInfo.scale.X().ToString("###0.####", _format))
				.Append("\"\r\n\t\t\t\"vaxis\" \"[")
				.Append(brushside.textureInfo.VAxis.X().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.textureInfo.VAxis.Y().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.textureInfo.VAxis.Z().ToString("###0.######", _format))
				.Append(" ")
				.Append(brushside.textureInfo.Translation.Y().ToString("###0.######", _format))
				.Append("] ")
				.Append(brushside.textureInfo.scale.Y().ToString("###0.####", _format))
				.Append("\"\r\n\t\t\t\"rotation\" \"")
				.Append(brushside.textureInfo.rotation.ToString("###0.####", _format))
				.Append("\"\r\n\t\t\t\"lightmapscale\" \"")
				.Append(brushside.lgtScale.ToString("###0.####", _format))
				.Append("\"\r\n\t\t\t\"smoothing_groups\" \"0\"\r\n");
			if (brushside.displacement != null)
			{
				ParseDisplacement(brushside.displacement, sb);
			}
			sb.Append("\t\t}\r\n");
		}

		private void ParseDisplacement(MAPDisplacement displacement, StringBuilder sb)
		{
			sb.Append("\t\t\tdispinfo\r\n\t\t\t{\r\n\t\t\t\t\"power\" \"").Append(displacement.power).Append("\"\r\n\t\t\t\t\"startposition\" \"[")
				.Append(displacement.start.X().ToString("###0.######", _format))
				.Append(" ")
				.Append(displacement.start.Y().ToString("###0.######", _format))
				.Append(" ")
				.Append(displacement.start.Z().ToString("###0.######", _format))
				.Append("]\"\r\n\t\t\t\t\"elevation\" \"0\"\r\n\t\t\t\t\"subdiv\" \"0\"\r\n\t\t\t\tnormals\r\n\t\t\t\t{\r\n");
			for (int i = 0; i < displacement.normals.GetLength(0); i++)
			{
				sb.Append("\t\t\t\t\t\"row").Append(i).Append("\" \"");
				for (int j = 0; j < displacement.normals.GetLength(1); j++)
				{
					if (j > 0)
					{
						sb.Append(" ");
					}
					sb.Append(displacement.normals[i, j].X().ToString("###0.######", _format));
					sb.Append(" ");
					sb.Append(displacement.normals[i, j].Y().ToString("###0.######", _format));
					sb.Append(" ");
					sb.Append(displacement.normals[i, j].Z().ToString("###0.######", _format));
				}
				sb.Append("\"\r\n");
			}
			sb.Append("\t\t\t\t}\r\n\t\t\t\tdistances\r\n\t\t\t\t{\r\n");
			for (int k = 0; k < displacement.distances.GetLength(0); k++)
			{
				sb.Append("\t\t\t\t\t\"row").Append(k).Append("\" \"");
				for (int l = 0; l < displacement.distances.GetLength(1); l++)
				{
					if (l > 0)
					{
						sb.Append(" ");
					}
					sb.Append(displacement.distances[k, l].ToString("###0.####", _format));
				}
				sb.Append("\"\r\n");
			}
			sb.Append("\t\t\t\t}\r\n\t\t\t\talphas\r\n\t\t\t\t{\r\n");
			for (int m = 0; m < displacement.alphas.GetLength(0); m++)
			{
				sb.Append("\t\t\t\t\t\"row").Append(m).Append("\" \"");
				for (int n = 0; n < displacement.alphas.GetLength(1); n++)
				{
					if (n > 0)
					{
						sb.Append(" ");
					}
					sb.Append(displacement.alphas[m, n].ToString(_format));
				}
				sb.Append("\"\r\n");
			}
			sb.Append("\t\t\t\t}\r\n\t\t\t\ttriangle_tags\r\n\t\t\t\t{\r\n\t\t\t\t}\r\n\t\t\t\ttriangle_tags\r\n\t\t\t\t{\r\n\t\t\t\t\t\"10\" \"-1 -1 -1 -1 -1 -1 -1 -1 -1 -1\"\r\n\t\t\t\t}\r\n\t\t\t}\r\n");
		}
	}
}
