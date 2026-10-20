using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PostProcessGammaRenderer), PostProcessEvent.BeforeStack, "Dark Machine/Post Process Gamma", true)]
public sealed class PostProcessGamma : PostProcessEffectSettings
{
	public FloatParameter amount = new FloatParameter
	{
		value = 1f
	};
}
