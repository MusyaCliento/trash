using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "White Knuckle/Effects/Decal Shared")]
public class FX_DecalShared : ScriptableObject
{
	public Vector2Int uvTopLeft;

	public Vector2Int uvBottomRight;

	public bool customExtents;

	public Vector2 halfExtents;

	public float height = 0.1f;

	public List<string> tags;

	[Header("Editor")]
	public Vector2Int offset;

	private void OnValidate()
	{
		if (offset != Vector2Int.zero)
		{
			uvTopLeft.x += offset.x;
			uvTopLeft.y += offset.y;
			uvBottomRight.x += offset.x;
			uvBottomRight.y += offset.y;
			offset = Vector2Int.zero;
		}
	}
}
