using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PostProcessSharpenRenderer), PostProcessEvent.AfterStack, "Dark Machine/Post Process Sharpen", true)]
public sealed class PostProcessSharpen : PostProcessEffectSettings
{
	public FloatParameter amount = new FloatParameter
	{
		value = 1f
	};
}
