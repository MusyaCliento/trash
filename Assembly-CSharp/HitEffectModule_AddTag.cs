using System;

[Serializable]
public class HitEffectModule_AddTag : HitEffectModule
{
	public string[] tags;

	public override void OnHit(in Desc desc)
	{
		base.OnHit(in desc);
		if (desc.target.TryGetComponent<ObjectTagger>(out var component))
		{
			string[] array = tags;
			foreach (string tag in array)
			{
				component.AddTag(tag);
			}
		}
	}
}
