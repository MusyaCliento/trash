using System;
using UnityEngine.Events;

[Serializable]
public class HitEffectModule_Event : HitEffectModule
{
	public UnityEvent playEvent;

	public override void OnHit(in Desc desc)
	{
		base.OnHit(in desc);
		playEvent.Invoke();
	}
}
