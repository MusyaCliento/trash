using UnityEngine;

public class HUD_CustomElement : MonoBehaviour
{
	public string id;

	public virtual void Remove()
	{
		Object.Destroy(base.gameObject);
	}
}
