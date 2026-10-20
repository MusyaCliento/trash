using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PostProcessOutlineRenderer), PostProcessEvent.BeforeStack, "Roystan/Post Process Outline", true)]
public sealed class PostProcessOutline : PostProcessEffectSettings
{
	[Tooltip("Number of pixels between samples that are tested for an edge. When this value is 1, tested samples are adjacent.")]
	public IntParameter scale = new IntParameter
	{
		value = 1
	};

	public ColorParameter color = new ColorParameter
	{
		value = Color.white
	};

	[Tooltip("Difference between depth values, scaled by the current depth, required to draw an edge.")]
	public FloatParameter depthThreshold = new FloatParameter
	{
		value = 1.5f
	};

	[Range(0f, 1f)]
	[Tooltip("The value at which the dot product between the surface normal and the view direction will affect the depth threshold. This ensures that surfaces at right angles to the camera require a larger depth threshold to draw an edge, avoiding edges being drawn along slopes.")]
	public FloatParameter depthNormalThreshold = new FloatParameter
	{
		value = 0.5f
	};

	[Tooltip("Scale the strength of how much the depthNormalThreshold affects the depth threshold.")]
	public FloatParameter depthNormalThresholdScale = new FloatParameter
	{
		value = 7f
	};

	[Range(0f, 1f)]
	[Tooltip("Larger values will require the difference between normals to be greater to draw an edge.")]
	public FloatParameter normalThreshold = new FloatParameter
	{
		value = 0.4f
	};
}
