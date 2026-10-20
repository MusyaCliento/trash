using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public sealed class PostProcessWKRenderer : PostProcessEffectRenderer<PostProcessWK>
{
	public override void Render(PostProcessRenderContext context)
	{
		PropertySheet propertySheet = context.propertySheets.Get(Shader.Find("Hidden/Dark Machine/Post Process WK"));
		propertySheet.properties.SetFloat("_Amount", base.settings.sharpenAmount);
		propertySheet.properties.SetTexture("_WaterNoise", base.settings.waterNoise);
		Matrix4x4 inverse = GL.GetGPUProjectionMatrix(context.camera.projectionMatrix, renderIntoTexture: true).inverse;
		propertySheet.properties.SetMatrix("_ClipToView", inverse);
		context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
	}
}
