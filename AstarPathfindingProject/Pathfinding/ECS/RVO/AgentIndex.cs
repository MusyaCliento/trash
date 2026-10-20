using Pathfinding.RVO;
using Unity.Collections;
using Unity.Entities;

namespace Pathfinding.ECS.RVO
{
	[WriteGroup(typeof(ResolvedMovement))]
	public readonly struct AgentIndex : ICleanupComponentData, IComponentData, IQueryTypeParameter
	{
		private const int DeletedBit = int.MinValue;

		private const int IndexMask = 16777215;

		private const int VersionOffset = 24;

		private const int VersionMask = 2130706432;

		private readonly int packedAgentIndex;

		internal int Index => packedAgentIndex & 0xFFFFFF;

		private int Version => packedAgentIndex & 0x7F000000;

		internal bool Valid => (packedAgentIndex & int.MinValue) == 0;

		internal AgentIndex(int packedAgentIndex)
		{
			this.packedAgentIndex = packedAgentIndex;
		}

		internal AgentIndex(int version, int index)
		{
			version <<= 24;
			packedAgentIndex = (version & 0x7F000000) | (index & 0xFFFFFF);
		}

		internal AgentIndex WithIncrementedVersion()
		{
			return new AgentIndex((((packedAgentIndex & 0x7F000000) + 16777216) & 0x7F000000) | Index);
		}

		internal AgentIndex WithDeleted()
		{
			return new AgentIndex(packedAgentIndex | int.MinValue);
		}

		public bool Exists(ref SimulatorBurst.AgentData agentData)
		{
			int index;
			return TryGetIndex(ref agentData, out index);
		}

		public bool TryGetIndex(ref SimulatorBurst.AgentData agentData, out int index)
		{
			return TryGetIndex(ref agentData.version, out index);
		}

		public bool TryGetIndex(ref NativeArray<AgentIndex> agentDataVersions, out int index)
		{
			int index2 = Index;
			index = -1;
			if (!agentDataVersions.IsCreated)
			{
				return false;
			}
			if (index2 >= agentDataVersions.Length)
			{
				return false;
			}
			if (agentDataVersions[index2].Version != Version)
			{
				return false;
			}
			index = index2;
			return true;
		}
	}
}
