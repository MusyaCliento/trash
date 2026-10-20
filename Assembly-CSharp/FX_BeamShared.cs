using UnityEngine;

[CreateAssetMenu(menuName = "White Knuckle/Effects/Beam Shared")]
public class FX_BeamShared : ScriptableObject
{
	public Material material;

	public float pixelsPerMeter = 32f;

	public FX_BeamManager.TextureOverflow textureOverflow;

	public float resolution = 4f;

	public float widthBase = 1f;

	public float widthVariance = 0.1f;

	public AnimationCurve widthOverLength = AnimationCurve.Constant(0f, 1f, 1f);

	public AnimationCurve widthOverLifetime = AnimationCurve.Constant(0f, 1f, 1f);

	public float maxOffsetBase = 1f;

	public float maxOffsetVariance = 0.2f;

	public int startingIndex = -1;

	public float forwardRateBase = 0.1f;

	public float forwardRateVariance = 0.05f;

	public int forwardStepMin = 1;

	public int forwardStepMax = 4;
}
