using UnityEngine;

public class BakeryVolumeReceiver : MonoBehaviour
{
	public bool forceUsage;

	internal int enterCounter;

	internal BakeryVolumeTrigger movableTrigger;

	private Renderer[] renderers;

	private MaterialPropertyBlock current;

	private void Awake()
	{
		if (renderers == null)
		{
			renderers = GetComponentsInChildren<Renderer>();
		}
		if (forceUsage)
		{
			SetPropertyBlock(new MaterialPropertyBlock());
		}
	}

	public void SetPropertyBlock(MaterialPropertyBlock mb)
	{
		if (renderers == null)
		{
			renderers = GetComponentsInChildren<Renderer>();
		}
		for (int i = 0; i < renderers.Length; i++)
		{
			renderers[i].SetPropertyBlock(mb);
		}
		current = mb;
	}

	private void LateUpdate()
	{
		if (!(movableTrigger == null))
		{
			movableTrigger.UpdateBounds();
			SetPropertyBlock(current);
		}
	}
}
