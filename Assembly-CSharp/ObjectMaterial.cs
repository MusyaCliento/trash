using UnityEngine;

public sealed class ObjectMaterial : MonoBehaviour
{
	public enum MaterialType
	{
		standard = 0,
		metal = 1,
		vent = 2,
		carpet = 3,
		water = 4,
		sludge = 5,
		acid = 6,
		wood = 7,
		flesh = 8,
		dirt = 9,
		ice = 10,
		chain = 11,
		metafungus = 12,
		barnacle = 13
	}

	public MaterialType type;

	public MaterialType GetMaterialType()
	{
		return type;
	}
}
