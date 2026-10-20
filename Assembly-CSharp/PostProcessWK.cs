using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PostProcessWKRenderer), PostProcessEvent.AfterStack, "Dark Machine/Post Process WK", true)]
public sealed class PostProcessWK : PostProcessEffectSettings
{
	public FloatParameter sharpenAmount = new FloatParameter
	{
		value = 1f
	};

	public TextureParameter waterNoise = new TextureParameter();
}
