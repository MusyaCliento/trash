using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public sealed class PostProcessSharpenRenderer : PostProcessEffectRenderer<PostProcessSharpen>
{
	public override void Render(PostProcessRenderContext context)
	{
		PropertySheet propertySheet = context.propertySheets.Get(Shader.Find("Hidden/Dark Machine/Sharpen Post Process"));
		propertySheet.properties.SetFloat("_Amount", base.settings.amount);
		Matrix4x4 inverse = GL.GetGPUProjectionMatrix(context.camera.projectionMatrix, renderIntoTexture: true).inverse;
		propertySheet.properties.SetMatrix("_ClipToView", inverse);
		context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
	}
}
