using UnityEngine;

public class BakeryVolumeTrigger : MonoBehaviour
{
	public bool movable;

	private BakeryVolume vol;

	private MaterialPropertyBlock mb;

	private static MaterialPropertyBlock mbEmpty;

	private static int mVolumeMin;

	private static int mVolumeInvSize;

	private void Awake()
	{
		if (mbEmpty == null)
		{
			mbEmpty = new MaterialPropertyBlock();
		}
		vol = GetComponent<BakeryVolume>();
		mb = new MaterialPropertyBlock();
		if (vol.bakedTexture0 != null)
		{
			mb.SetTexture("_Volume0", vol.bakedTexture0);
			mb.SetTexture("_Volume1", vol.bakedTexture1);
			mb.SetTexture("_Volume2", vol.bakedTexture2);
			if (vol.bakedTexture3 != null)
			{
				mb.SetTexture("_Volume3", vol.bakedTexture3);
			}
		}
		if (vol.bakedMask != null)
		{
			mb.SetTexture("_VolumeMask", vol.bakedMask);
		}
		if (mVolumeMin == 0)
		{
			mVolumeMin = Shader.PropertyToID("_VolumeMin");
		}
		if (mVolumeInvSize == 0)
		{
			mVolumeInvSize = Shader.PropertyToID("_VolumeInvSize");
		}
		mb.SetVector(mVolumeMin, vol.GetMin());
		mb.SetVector(mVolumeInvSize, vol.GetInvSize());
		if (vol.supportRotationAfterBake)
		{
			mb.SetMatrix("_VolumeMatrix", vol.GetMatrix());
		}
		if (vol.rotateAroundY)
		{
			mb.SetVector("_VolumeRY", vol.GetRotationY());
		}
		mb.SetVector("_VolumeVoxelSize", new Vector3(1f / (float)vol.bakedTexture0.width, 1f / (float)vol.bakedTexture0.height, 1f / (float)vol.bakedTexture0.depth));
	}

	private void OnTriggerEnter(Collider c)
	{
		BakeryVolumeReceiver component = c.GetComponent<BakeryVolumeReceiver>();
		if (!(component == null))
		{
			Debug.Log(c.name + " entered " + base.name);
			component.enterCounter++;
			component.movableTrigger = (movable ? this : null);
			component.SetPropertyBlock(mb);
		}
	}

	private void OnTriggerExit(Collider c)
	{
		BakeryVolumeReceiver component = c.GetComponent<BakeryVolumeReceiver>();
		if (!(component == null))
		{
			Debug.Log(c.name + " exited " + base.name);
			component.enterCounter--;
			if (component.enterCounter == 0)
			{
				component.SetPropertyBlock(mbEmpty);
			}
		}
	}

	public void UpdateBounds()
	{
		vol.UpdateBounds();
		mb.SetVector(mVolumeMin, vol.GetMin());
		mb.SetVector(mVolumeInvSize, vol.GetInvSize());
	}
}
