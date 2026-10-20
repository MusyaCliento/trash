using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public sealed class PostProcessOutlineRenderer : PostProcessEffectRenderer<PostProcessOutline>
{
	public override void Render(PostProcessRenderContext context)
	{
		PropertySheet propertySheet = context.propertySheets.Get(Shader.Find("Hidden/Roystan/Outline Post Process"));
		propertySheet.properties.SetFloat("_Scale", (int)base.settings.scale);
		propertySheet.properties.SetColor("_Color", base.settings.color);
		propertySheet.properties.SetFloat("_DepthThreshold", base.settings.depthThreshold);
		propertySheet.properties.SetFloat("_DepthNormalThreshold", base.settings.depthNormalThreshold);
		propertySheet.properties.SetFloat("_DepthNormalThresholdScale", base.settings.depthNormalThresholdScale);
		propertySheet.properties.SetFloat("_NormalThreshold", base.settings.normalThreshold);
		propertySheet.properties.SetColor("_Color", base.settings.color);
		Matrix4x4 inverse = GL.GetGPUProjectionMatrix(context.camera.projectionMatrix, renderIntoTexture: true).inverse;
		propertySheet.properties.SetMatrix("_ClipToView", inverse);
		context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
	}
}
