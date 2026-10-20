using System;
using System.IO;
using Pathfinding.Collections;
using Pathfinding.Pooling;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Pathfinding.Serialization
{
	public class GraphSerializationContext
	{
		private readonly GraphNode[] id2NodeMapping;

		public readonly BinaryReader reader;

		public readonly BinaryWriter writer;

		public readonly uint graphIndex;

		public readonly GraphMeta meta;

		public bool[] persistentGraphs;

		public GraphSerializationContext(BinaryReader reader, GraphNode[] id2NodeMapping, uint graphIndex, GraphMeta meta)
		{
			this.reader = reader;
			this.id2NodeMapping = id2NodeMapping;
			this.graphIndex = graphIndex;
			this.meta = meta;
		}

		public GraphSerializationContext(BinaryWriter writer, bool[] persistentGraphs)
		{
			this.writer = writer;
			this.persistentGraphs = persistentGraphs;
		}

		public void SerializeNodeReference(GraphNode node)
		{
			writer.Write(((int?)node?.NodeIndex) ?? (-1));
		}

		public void SerializeConnections(Connection[] connections, bool serializeMetadata)
		{
			if (connections == null)
			{
				writer.Write(-1);
				return;
			}
			int num = 0;
			for (int i = 0; i < connections.Length; i++)
			{
				num += (persistentGraphs[connections[i].node.GraphIndex] ? 1 : 0);
			}
			writer.Write(num);
			for (int j = 0; j < connections.Length; j++)
			{
				if (persistentGraphs[connections[j].node.GraphIndex])
				{
					SerializeNodeReference(connections[j].node);
					writer.Write(connections[j].cost);
					if (serializeMetadata)
					{
						writer.Write(connections[j].shapeEdgeInfo);
					}
				}
			}
		}

		public Connection[] DeserializeConnections(bool deserializeMetadata)
		{
			int num = reader.ReadInt32();
			if (num == -1)
			{
				return null;
			}
			Connection[] array = ArrayPool<Connection>.ClaimWithExactLength(num);
			for (int i = 0; i < num; i++)
			{
				GraphNode node = DeserializeNodeReference();
				uint cost = reader.ReadUInt32();
				if (deserializeMetadata)
				{
					byte b = 15;
					if (!(meta.version < AstarSerializer.V4_1_0))
					{
						if (meta.version < AstarSerializer.V4_3_68)
						{
							reader.ReadByte();
						}
						else
						{
							b = reader.ReadByte();
						}
					}
					if (meta.version < AstarSerializer.V4_3_85)
					{
						b &= 0x4F;
					}
					if (meta.version < AstarSerializer.V4_3_87)
					{
						b |= 0x30;
					}
					array[i] = new Connection(node, cost, b);
				}
				else
				{
					array[i] = new Connection(node, cost, isOutgoing: true, isIncoming: true);
				}
			}
			return array;
		}

		public GraphNode DeserializeNodeReference()
		{
			int num = reader.ReadInt32();
			if (id2NodeMapping == null)
			{
				throw new Exception("Calling DeserializeNodeReference when not deserializing node references");
			}
			if (num == -1)
			{
				return null;
			}
			return id2NodeMapping[num] ?? throw new Exception("Invalid id (" + num + ")");
		}

		public void SerializeVector3(Vector3 v)
		{
			writer.Write(v.x);
			writer.Write(v.y);
			writer.Write(v.z);
		}

		public Vector3 DeserializeVector3()
		{
			return new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
		}

		public void SerializeInt3(Int3 v)
		{
			writer.Write(v.x);
			writer.Write(v.y);
			writer.Write(v.z);
		}

		public Int3 DeserializeInt3()
		{
			return new Int3(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
		}

		public UnsafeSpan<T> ReadSpan<T>(Allocator allocator) where T : unmanaged
		{
			UnsafeSpan<T> result = new UnsafeSpan<T>(allocator, reader.ReadInt32());
			if (UnsafeUtility.SizeOf<T>() % 4 != 0)
			{
				throw new Exception("Cannot read data of type " + typeof(T)?.ToString() + " because it has a size which is not a multiple of 4 bytes");
			}
			UnsafeSpan<int> unsafeSpan = result.Reinterpret<int>(UnsafeUtility.SizeOf<T>());
			for (int i = 0; i < unsafeSpan.Length; i++)
			{
				unsafeSpan[i] = reader.ReadInt32();
			}
			return result;
		}
	}
}
