using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class BaseCRTEffect : MonoBehaviour
{
	public enum Preset
	{
		Custom = 0,
		Default = 1,
		KitchenTV = 2,
		MiniCRT = 3,
		ColorTV = 4,
		OldTV = 5,
		HighEndMonitor = 6,
		ArcadeDisplay = 7,
		BrokenBlackAndWhite = 8,
		GreenTerminal = 9,
		YellowMonitor = 10
	}

	public enum NoiseMode
	{
		Add = 0,
		Subtract = 1,
		Multiply = 2,
		Divide = 3,
		Lighten = 4,
		Darken = 5
	}

	public enum MaskMode
	{
		Thin = 0,
		Dense = 1,
		Denser = 2,
		ThinScanline = 3,
		Scanline = 4,
		DenseScanline = 5
	}

	public enum TextureScalingMode
	{
		Off = 0,
		AdjustForWidth = 1,
		AdjustForHeight = 2
	}

	public enum TextureScalingPolicy
	{
		Always = 0,
		UpscaleOnly = 1,
		DownscaleOnly = 2
	}

	public Preset predefinedModel;

	protected Preset preset;

	[Header("Blur")]
	[Range(0f, 1f)]
	[Tooltip("Blur ammount. How blurry the blurred layer is.")]
	public float blurSize = 0.7f;

	[Range(0f, 1f)]
	[Tooltip("How much of the blurred image is mixed with the base image.")]
	public float blurStrength = 0.6f;

	[Header("Luminosity bleeding")]
	[Range(0f, 2f)]
	[Tooltip("How many adjacent pixels is going to be overlaped by a given brighter pixel.")]
	public float bleedingSize = 0.75f;

	[Range(0f, 1f)]
	[Tooltip("How much of the bleeded image is mixed with the base image.")]
	public float bleedingStrength = 0.5f;

	[Header("Chromatic aberration")]
	[Range(-2.5f, 2.5f)]
	[Tooltip("How many pixels the blurred layer is shifted for Red and Blue channels.")]
	public float chromaticAberrationOffset = 1.25f;

	[Header("RGB Mask")]
	[Range(0f, 1f)]
	[Tooltip("How much each channel blocks other channels for a given pixel. E.g. if set to 1.0 all red channel pixels will show no green or blue values.")]
	public float RGBMaskIntensivity = 0.6f;

	[Range(0f, 1f)]
	[Tooltip("How much of the masked image is mixed with the base image.")]
	public float RGBMaskStrength = 0.6f;

	[Range(0f, 1f)]
	[Tooltip("How much each channel passes through other channels for a given pixel. Basically opposite of RGB Mask Intensitity.")]
	public float RGBMaskBleeding = 0.1f;

	[Header("Noise")]
	[Tooltip("What blending mode is used when mixing base image pixels with color noise pixels.")]
	public NoiseMode colorNoiseMode;

	[Range(0f, 1f)]
	[Tooltip("How much of the generated color noise image is mixed with the base image.")]
	public float colorNoiseStrength = 0.15f;

	[Space(4f)]
	[Tooltip("What blending mode is used when mixing base image pixels with white noise pixels.")]
	public NoiseMode whiteNoiseMode = NoiseMode.Lighten;

	[Range(0f, 1f)]
	[Tooltip("How much of the generated white noise image is mixed with the base image.")]
	public float whiteNoiseStrength = 0.25f;

	[Header("Color adjustments")]
	[Tooltip("This color becomes the new darkest color (works similarly to Photoshop 'Levels' adjustment).")]
	public Color darkestLevel = Color.black;

	[Tooltip("This color becomes the new brightest color (works similarly to Photoshop 'Levels' adjustment).")]
	public Color brightestLevel = Color.Lerp(Color.black, Color.white, 47f / 51f);

	[Space(4f)]
	[Tooltip("Darkest color of the output image, makes image brigther and contrast lower, if brighter than black.")]
	public Color darkestColor = Color.Lerp(Color.black, Color.white, 8f / 51f);

	[Tooltip("Brightest color of the output image, makes image darker and contrast lower if darker than white.")]
	public Color brightestColor = Color.white;

	[Space(4f)]
	[Range(-1f, 1f)]
	[Tooltip("Brightness adjustment.")]
	public float brightness = 0.2f;

	[Range(-1f, 1f)]
	[Tooltip("Contrast adjustment.")]
	public float contrast = 0.1f;

	[Range(-1f, 1f)]
	[Tooltip("Saturation adjustment.")]
	public float saturation = -0.05f;

	[Header("Horizontal interference")]
	[Range(0f, 1000f)]
	[Tooltip("How wide (in pixels) is the horizontal interference bar.")]
	public float interferenceWidth = 25f;

	[Range(-25f, 25f)]
	[Tooltip("How fast does the horizontal interference bar move (in pixels per secons).")]
	public float interferenceSpeed = 3f;

	[Range(0f, 1f)]
	[Tooltip("How much of the interference is mixed with the base image.")]
	public float interferenceStrength;

	[Range(0f, 1f)]
	[Tooltip("How much the RGB channels of the interference are appart (in percent of interference bar width, it's basically chromatic aberration just for the interference).")]
	public float interferenceSplit = 0.25f;

	[Header("CRT")]
	[Tooltip("CRT mask type. Makes some pixels darker than the adjacent ones to simulate CRT display mask.")]
	public MaskMode maskMode = MaskMode.Dense;

	[Range(0f, 1f)]
	[Tooltip("How much of the mask is mixed with the base image.")]
	public float maskStrength = 0.35f;

	[Space(4f)]
	[Range(0f, 1f)]
	[Tooltip("How curvy the display is, on X-asis.")]
	public float curvatureX = 0.6f;

	[Range(0f, 1f)]
	[Tooltip("How curvy the display is, on Y-asis.")]
	public float curvatureY = 0.6f;

	[Range(0f, 1f)]
	[Tooltip("Enlarges the image.")]
	public float overscan;

	[Space(4f)]
	[Range(0f, 1f)]
	[Tooltip("How much of the center part is covered by vignette.")]
	public float vignetteSize = 0.35f;

	[Range(0f, 1f)]
	[Tooltip("How much of the vignette is mixed with the base image.")]
	public float vignetteStrength = 0.1f;

	[Header("Camera's texture")]
	[Tooltip("Internal texture (if used) will be created proportionally to camera's display size.")]
	public TextureScalingMode textureScaling = TextureScalingMode.AdjustForHeight;

	[Tooltip("Internal texture will be created only when the condition is met (e.g., for 'Downscale Only' it will be created only, if camera's display is bigger than the texture size).")]
	public TextureScalingPolicy scalingPolicy = TextureScalingPolicy.DownscaleOnly;

	[Range(0f, 4096f)]
	[Tooltip("How wide or high the internally used texture will be.")]
	public int textureSize = 768;

	[Header("Multi-camera setup workaround")]
	[Tooltip("If you're using more than one camera to render the scene (like with Pro Camera 2D parallax setup), drag your cameras onto this property and add the effect to the last camera on your rendering path.")]
	public Camera[] otherCameras;

	protected Camera mainCamera;

	public RenderTexture cameraTarget;

	protected RenderTexture oldCameraTarget;

	protected Material blurMaterial;

	protected Material postProMaterial;

	protected Material finalPostProMaterial;

	protected float seconds;

	protected float blurSigma = float.NaN;

	protected float[] blurKernel = new float[2];

	protected float blurZ = float.NaN;

	protected float currentBrightness = float.NaN;

	protected Matrix4x4 brightnessMat;

	protected float currentContrast = float.NaN;

	protected Matrix4x4 contrastMat;

	protected float currentSaturation = float.NaN;

	protected Matrix4x4 saturationMat;

	protected Matrix4x4 colorMat;

	protected Vector4 colorTransform;

	public static void SetupDefaultPreset(BaseCRTEffect effect)
	{
		effect.blurSize = 0.7f;
		effect.blurStrength = 0.6f;
		effect.bleedingSize = 0.75f;
		effect.bleedingStrength = 0.5f;
		effect.chromaticAberrationOffset = 1.25f;
		effect.RGBMaskIntensivity = 0.6f;
		effect.RGBMaskStrength = 0.6f;
		effect.RGBMaskBleeding = 0.1f;
		effect.colorNoiseMode = NoiseMode.Add;
		effect.colorNoiseStrength = 0.15f;
		effect.whiteNoiseMode = NoiseMode.Lighten;
		effect.whiteNoiseStrength = 0.25f;
		effect.darkestLevel = Color.black;
		effect.brightestLevel = Color.Lerp(Color.black, Color.white, 47f / 51f);
		effect.darkestColor = Color.Lerp(Color.black, Color.white, 8f / 51f);
		effect.brightestColor = Color.white;
		effect.brightness = 0.2f;
		effect.contrast = 0.1f;
		effect.saturation = -0.05f;
		effect.interferenceWidth = 25f;
		effect.interferenceSpeed = 3f;
		effect.interferenceStrength = 0f;
		effect.interferenceSplit = 0.25f;
		effect.maskMode = MaskMode.Dense;
		effect.maskStrength = 0.35f;
		effect.curvatureX = 0.6f;
		effect.curvatureY = 0.6f;
		effect.overscan = 0f;
		effect.vignetteSize = 0.35f;
		effect.vignetteStrength = 0.1f;
		effect.textureScaling = TextureScalingMode.AdjustForHeight;
		effect.scalingPolicy = TextureScalingPolicy.DownscaleOnly;
		effect.textureSize = 768;
	}

	public static void SetupKitchenTVPreset(BaseCRTEffect effect)
	{
		effect.blurSize = 0.7f;
		effect.blurStrength = 0.6f;
		effect.bleedingSize = 0.75f;
		effect.bleedingStrength = 0.5f;
		effect.chromaticAberrationOffset = 1.25f;
		effect.RGBMaskIntensivity = 0.4f;
		effect.RGBMaskStrength = 0.4f;
		effect.RGBMaskBleeding = 0.1f;
		effect.colorNoiseMode = NoiseMode.Add;
		effect.colorNoiseStrength = 0.15f;
		effect.whiteNoiseMode = NoiseMode.Lighten;
		effect.whiteNoiseStrength = 0.15f;
		effect.darkestLevel = Color.black;
		effect.brightestLevel = Color.Lerp(Color.black, Color.white, 47f / 51f);
		effect.darkestColor = Color.Lerp(Color.black, Color.white, 5f / 51f);
		effect.brightestColor = Color.white;
		effect.brightness = 0.1f;
		effect.contrast = 0.1f;
		effect.saturation = -0.05f;
		effect.interferenceWidth = 25f;
		effect.interferenceSpeed = 3f;
		effect.interferenceStrength = 0f;
		effect.interferenceSplit = 0.25f;
		effect.maskMode = MaskMode.Dense;
		effect.maskStrength = 0.25f;
		effect.curvatureX = 0.3f;
		effect.curvatureY = 0.3f;
		effect.overscan = 0f;
		effect.vignetteSize = 0.35f;
		effect.vignetteStrength = 0.1f;
		effect.textureScaling = TextureScalingMode.AdjustForHeight;
		effect.scalingPolicy = TextureScalingPolicy.DownscaleOnly;
		effect.textureSize = 768;
	}

	public static void SetupMiniCRTPreset(BaseCRTEffect effect)
	{
		effect.blurSize = 0.8f;
		effect.blurStrength = 0.8f;
		effect.bleedingSize = 0.5f;
		effect.bleedingStrength = 1f;
		effect.chromaticAberrationOffset = 2.5f;
		effect.RGBMaskIntensivity = 0.8f;
		effect.RGBMaskStrength = 0.8f;
		effect.RGBMaskBleeding = 0.3f;
		effect.colorNoiseMode = NoiseMode.Add;
		effect.colorNoiseStrength = 0.25f;
		effect.whiteNoiseMode = NoiseMode.Lighten;
		effect.whiteNoiseStrength = 0.25f;
		effect.darkestLevel = Color.black;
		effect.brightestLevel = Color.Lerp(Color.black, Color.white, 0.88235295f);
		effect.darkestColor = Color.Lerp(Color.black, Color.white, 7f / 51f);
		effect.brightestColor = Color.white;
		effect.brightness = 0.3f;
		effect.contrast = 0.3f;
		effect.saturation = -0.1f;
		effect.interferenceWidth = 25f;
		effect.interferenceSpeed = 3f;
		effect.interferenceStrength = 0f;
		effect.interferenceSplit = 0.25f;
		effect.maskMode = MaskMode.Denser;
		effect.maskStrength = 1f;
		effect.curvatureX = 0.7f;
		effect.curvatureY = 0.7f;
		effect.overscan = 0f;
		effect.vignetteSize = 0.5f;
		effect.vignetteStrength = 0.425f;
		effect.textureScaling = TextureScalingMode.AdjustForHeight;
		effect.scalingPolicy = TextureScalingPolicy.DownscaleOnly;
		effect.textureSize = 768;
	}

	public static void SetupColorTVPreset(BaseCRTEffect effect)
	{
		effect.blurSize = 0.9f;
		effect.blurStrength = 0.6f;
		effect.bleedingSize = 0.85f;
		effect.bleedingStrength = 0.75f;
		effect.chromaticAberrationOffset = 1.75f;
		effect.RGBMaskIntensivity = 0.4f;
		effect.RGBMaskStrength = 0.4f;
		effect.RGBMaskBleeding = 0.1f;
		effect.colorNoiseMode = NoiseMode.Add;
		effect.colorNoiseStrength = 0.3f;
		effect.whiteNoiseMode = NoiseMode.Lighten;
		effect.whiteNoiseStrength = 0.2f;
		effect.darkestLevel = Color.black;
		effect.brightestLevel = Color.Lerp(Color.black, Color.white, 47f / 51f);
		effect.darkestColor = Color.Lerp(Color.black, Color.white, 7f / 51f);
		effect.brightestColor = new Color(49f / 51f, 1f, 1f);
		effect.brightness = 0f;
		effect.contrast = 0.2f;
		effect.saturation = 0.1f;
		effect.interferenceWidth = 25f;
		effect.interferenceSpeed = 3f;
		effect.interferenceStrength = 0f;
		effect.interferenceSplit = 0.25f;
		effect.maskMode = MaskMode.Denser;
		effect.maskStrength = 0.2f;
		effect.curvatureX = 0.5f;
		effect.curvatureY = 0.5f;
		effect.overscan = 0.1f;
		effect.vignetteSize = 0.4f;
		effect.vignetteStrength = 0.5f;
		effect.textureScaling = TextureScalingMode.AdjustForHeight;
		effect.scalingPolicy = TextureScalingPolicy.DownscaleOnly;
		effect.textureSize = 768;
	}

	public static void SetupOldTVPreset(BaseCRTEffect effect)
	{
		effect.blurSize = 0.9f;
		effect.blurStrength = 0.8f;
		effect.bleedingSize = 0.95f;
		effect.bleedingStrength = 0.95f;
		effect.chromaticAberrationOffset = 1.9f;
		effect.RGBMaskIntensivity = 0.7f;
		effect.RGBMaskStrength = 0.7f;
		effect.RGBMaskBleeding = 0.3f;
		effect.colorNoiseMode = NoiseMode.Add;
		effect.colorNoiseStrength = 0.5f;
		effect.whiteNoiseMode = NoiseMode.Darken;
		effect.whiteNoiseStrength = 0.55f;
		effect.darkestLevel = Color.black;
		effect.brightestLevel = Color.Lerp(Color.black, Color.white, 47f / 51f);
		effect.darkestColor = Color.Lerp(Color.black, Color.white, 7f / 51f);
		effect.brightestColor = new Color(49f / 51f, 1f, 1f);
		effect.brightness = 0f;
		effect.contrast = -0.1f;
		effect.saturation = -0.05f;
		effect.interferenceWidth = 35f;
		effect.interferenceSpeed = 2f;
		effect.interferenceStrength = 0.075f;
		effect.interferenceSplit = 0.25f;
		effect.maskMode = MaskMode.Thin;
		effect.maskStrength = 0.75f;
		effect.curvatureX = 0.625f;
		effect.curvatureY = 0.625f;
		effect.overscan = 0.1f;
		effect.vignetteSize = 0.4f;
		effect.vignetteStrength = 0.5f;
		effect.textureScaling = TextureScalingMode.AdjustForHeight;
		effect.scalingPolicy = TextureScalingPolicy.DownscaleOnly;
		effect.textureSize = 768;
	}

	public static void SetupHighEndMonitorPreset(BaseCRTEffect effect)
	{
		effect.blurSize = 0.35f;
		effect.blurStrength = 0.5f;
		effect.bleedingSize = 0.5f;
		effect.bleedingStrength = 0.8f;
		effect.chromaticAberrationOffset = 0.5f;
		effect.RGBMaskIntensivity = 0.4f;
		effect.RGBMaskStrength = 0.4f;
		effect.RGBMaskBleeding = 0.1f;
		effect.colorNoiseMode = NoiseMode.Lighten;
		effect.colorNoiseStrength = 0.15f;
		effect.whiteNoiseMode = NoiseMode.Lighten;
		effect.whiteNoiseStrength = 0.1f;
		effect.darkestLevel = Color.black;
		effect.brightestLevel = Color.white;
		effect.darkestColor = Color.black;
		effect.brightestColor = Color.white;
		effect.brightness = 0.1f;
		effect.contrast = 0f;
		effect.saturation = 0.05f;
		effect.interferenceWidth = 25f;
		effect.interferenceSpeed = 3f;
		effect.interferenceStrength = 0f;
		effect.interferenceSplit = 0.25f;
		effect.maskMode = MaskMode.Thin;
		effect.maskStrength = 0.3f;
		effect.curvatureX = 0f;
		effect.curvatureY = 0f;
		effect.overscan = 0f;
		effect.vignetteSize = 0f;
		effect.vignetteStrength = 0f;
		effect.textureScaling = TextureScalingMode.AdjustForHeight;
		effect.scalingPolicy = TextureScalingPolicy.DownscaleOnly;
		effect.textureSize = 768;
	}

	public static void SetupArcadeDisplayPreset(BaseCRTEffect effect)
	{
		effect.blurSize = 0.5f;
		effect.blurStrength = 0.7f;
		effect.bleedingSize = 0.65f;
		effect.bleedingStrength = 0.8f;
		effect.chromaticAberrationOffset = 0.9f;
		effect.RGBMaskIntensivity = 0.4f;
		effect.RGBMaskStrength = 0.4f;
		effect.RGBMaskBleeding = 0.2f;
		effect.colorNoiseMode = NoiseMode.Lighten;
		effect.colorNoiseStrength = 0.15f;
		effect.whiteNoiseMode = NoiseMode.Lighten;
		effect.whiteNoiseStrength = 0.1f;
		effect.darkestLevel = Color.black;
		effect.brightestLevel = Color.white;
		effect.darkestColor = Color.black;
		effect.brightestColor = Color.white;
		effect.brightness = 0.1f;
		effect.contrast = 0.1f;
		effect.saturation = 0.1f;
		effect.interferenceWidth = 25f;
		effect.interferenceSpeed = 3f;
		effect.interferenceStrength = 0f;
		effect.interferenceSplit = 0.25f;
		effect.maskMode = MaskMode.Scanline;
		effect.maskStrength = 0.75f;
		effect.curvatureX = 0f;
		effect.curvatureY = 0f;
		effect.overscan = 0f;
		effect.vignetteSize = 0.3f;
		effect.vignetteStrength = 0.2f;
		effect.textureScaling = TextureScalingMode.AdjustForHeight;
		effect.scalingPolicy = TextureScalingPolicy.DownscaleOnly;
		effect.textureSize = 768;
	}

	public static void SetupBrokenBlackAndWhitePreset(BaseCRTEffect effect)
	{
		effect.blurSize = 0.9f;
		effect.blurStrength = 1f;
		effect.bleedingSize = 0.75f;
		effect.bleedingStrength = 0.9f;
		effect.chromaticAberrationOffset = 2.5f;
		effect.RGBMaskIntensivity = 0.6f;
		effect.RGBMaskStrength = 0.6f;
		effect.RGBMaskBleeding = 0.1f;
		effect.colorNoiseMode = NoiseMode.Add;
		effect.colorNoiseStrength = 0.75f;
		effect.whiteNoiseMode = NoiseMode.Lighten;
		effect.whiteNoiseStrength = 0.5f;
		effect.darkestLevel = Color.Lerp(Color.black, Color.white, 1f / 17f);
		effect.brightestLevel = Color.Lerp(Color.black, Color.white, 0.88235295f);
		effect.darkestColor = Color.Lerp(Color.black, Color.white, 0.23529412f);
		effect.brightestColor = Color.white;
		effect.brightness = 0f;
		effect.contrast = -0.2f;
		effect.saturation = -1f;
		effect.interferenceWidth = 85f;
		effect.interferenceSpeed = 2.5f;
		effect.interferenceStrength = 0.05f;
		effect.interferenceSplit = 0f;
		effect.maskMode = MaskMode.Denser;
		effect.maskStrength = 0.15f;
		effect.curvatureX = 0.6f;
		effect.curvatureY = 0.6f;
		effect.overscan = 0.4f;
		effect.vignetteSize = 0.75f;
		effect.vignetteStrength = 0.5f;
		effect.textureScaling = TextureScalingMode.AdjustForHeight;
		effect.scalingPolicy = TextureScalingPolicy.DownscaleOnly;
		effect.textureSize = 768;
	}

	public static void SetupGreenTerminalPreset(BaseCRTEffect effect)
	{
		effect.blurSize = 0.9f;
		effect.blurStrength = 1f;
		effect.bleedingSize = 0.8f;
		effect.bleedingStrength = 0.65f;
		effect.chromaticAberrationOffset = 0f;
		effect.RGBMaskIntensivity = 0.7f;
		effect.RGBMaskStrength = 0.7f;
		effect.RGBMaskBleeding = 0.2f;
		effect.colorNoiseMode = NoiseMode.Add;
		effect.colorNoiseStrength = 0f;
		effect.whiteNoiseMode = NoiseMode.Lighten;
		effect.whiteNoiseStrength = 0f;
		effect.darkestLevel = Color.Lerp(Color.black, Color.white, 2f / 51f);
		effect.brightestLevel = Color.Lerp(Color.black, Color.white, 41f / 51f);
		effect.darkestColor = new Color(0f, 0.11764706f, 0f);
		effect.brightestColor = new Color(5f / 51f, 1f, 5f / 51f);
		effect.brightness = 0.4f;
		effect.contrast = -0.1f;
		effect.saturation = -0.8f;
		effect.interferenceWidth = 300f;
		effect.interferenceSpeed = 25f;
		effect.interferenceStrength = 0.0035f;
		effect.interferenceSplit = 0f;
		effect.maskMode = MaskMode.DenseScanline;
		effect.maskStrength = 0.25f;
		effect.curvatureX = 0.55f;
		effect.curvatureY = 0.55f;
		effect.overscan = 0f;
		effect.vignetteSize = 0.35f;
		effect.vignetteStrength = 0.35f;
		effect.textureScaling = TextureScalingMode.AdjustForHeight;
		effect.scalingPolicy = TextureScalingPolicy.DownscaleOnly;
		effect.textureSize = 768;
	}

	public static void SetupYellowMonitorPreset(BaseCRTEffect effect)
	{
		effect.blurSize = 0.9f;
		effect.blurStrength = 0.6f;
		effect.bleedingSize = 0.85f;
		effect.bleedingStrength = 0.75f;
		effect.chromaticAberrationOffset = 1.75f;
		effect.RGBMaskIntensivity = 0.4f;
		effect.RGBMaskStrength = 0.4f;
		effect.RGBMaskBleeding = 0.1f;
		effect.colorNoiseMode = NoiseMode.Multiply;
		effect.colorNoiseStrength = 0.4f;
		effect.whiteNoiseMode = NoiseMode.Darken;
		effect.whiteNoiseStrength = 0.2f;
		effect.darkestLevel = Color.Lerp(Color.black, Color.white, 2f / 51f);
		effect.brightestLevel = Color.Lerp(Color.black, Color.white, 41f / 51f);
		effect.darkestColor = new Color(0.11764706f, 0.11764706f, 0f);
		effect.brightestColor = new Color(1f, 1f, 5f / 51f);
		effect.brightness = 0.5f;
		effect.contrast = -0.1f;
		effect.saturation = -1f;
		effect.interferenceWidth = 300f;
		effect.interferenceSpeed = 25f;
		effect.interferenceStrength = 0.0035f;
		effect.interferenceSplit = 0f;
		effect.maskMode = MaskMode.DenseScanline;
		effect.maskStrength = 0.25f;
		effect.curvatureX = 0.4f;
		effect.curvatureY = 0.4f;
		effect.overscan = 0f;
		effect.vignetteSize = 0.35f;
		effect.vignetteStrength = 0.35f;
		effect.textureScaling = TextureScalingMode.AdjustForHeight;
		effect.scalingPolicy = TextureScalingPolicy.DownscaleOnly;
		effect.textureSize = 768;
	}

	protected void InternalPreRender()
	{
		OnCameraPreRender();
	}

	private void OnPostRender()
	{
		if (mainCamera.targetTexture != oldCameraTarget)
		{
			RenderTexture targetTexture = mainCamera.targetTexture;
			mainCamera.targetTexture = oldCameraTarget;
			OnCameraPostRender(targetTexture);
			if ((bool)targetTexture)
			{
				targetTexture.DiscardContents();
			}
		}
	}

	private void Awake()
	{
		mainCamera = GetComponent<Camera>();
		blurMaterial = new Material(Shader.Find("CRT/Blur"));
		postProMaterial = new Material(Shader.Find("CRT/Postprocess"));
		finalPostProMaterial = new Material(Shader.Find("CRT/FinalPostprocess"));
	}

	private void Update()
	{
		seconds += Time.deltaTime;
		if (predefinedModel != preset)
		{
			preset = predefinedModel;
			switch (preset)
			{
			case Preset.Default:
				SetupDefaultPreset(this);
				break;
			case Preset.KitchenTV:
				SetupKitchenTVPreset(this);
				break;
			case Preset.MiniCRT:
				SetupMiniCRTPreset(this);
				break;
			case Preset.ColorTV:
				SetupColorTVPreset(this);
				break;
			case Preset.OldTV:
				SetupOldTVPreset(this);
				break;
			case Preset.HighEndMonitor:
				SetupHighEndMonitorPreset(this);
				break;
			case Preset.ArcadeDisplay:
				SetupArcadeDisplayPreset(this);
				break;
			case Preset.BrokenBlackAndWhite:
				SetupBrokenBlackAndWhitePreset(this);
				break;
			case Preset.GreenTerminal:
				SetupGreenTerminalPreset(this);
				break;
			case Preset.YellowMonitor:
				SetupYellowMonitorPreset(this);
				break;
			case Preset.Custom:
				break;
			}
		}
	}

	private void OnDisable()
	{
		mainCamera.targetTexture = oldCameraTarget;
		if (otherCameras != null && otherCameras.Length != 0)
		{
			Camera[] array = otherCameras;
			foreach (Camera camera in array)
			{
				if (!(camera == null))
				{
					camera.targetTexture = null;
				}
			}
		}
		if (cameraTarget != null)
		{
			cameraTarget.Release();
		}
		cameraTarget = null;
	}

	protected virtual RenderTexture CreateCameraTexture(RenderTexture currentCameraTexture)
	{
		if (textureScaling == TextureScalingMode.Off || textureSize == 0)
		{
			return null;
		}
		float num = Screen.width;
		float num2 = Screen.height;
		int num3;
		int num4;
		if (textureScaling == TextureScalingMode.AdjustForHeight)
		{
			num3 = textureSize;
			num4 = Mathf.RoundToInt(num * (float)textureSize / num2);
		}
		else
		{
			num4 = textureSize;
			num3 = Mathf.RoundToInt(num2 * (float)textureSize / num);
		}
		if (scalingPolicy == TextureScalingPolicy.Always || (scalingPolicy == TextureScalingPolicy.DownscaleOnly && (num > (float)num4 || num2 > (float)num3)) || (scalingPolicy == TextureScalingPolicy.UpscaleOnly && (num < (float)num4 || num2 < (float)num3)))
		{
			if (currentCameraTexture == null || currentCameraTexture.width != num4 || currentCameraTexture.height != num3)
			{
				return new RenderTexture(num4, num3, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
			}
			return currentCameraTexture;
		}
		return null;
	}

	protected virtual void OnCameraPreRender()
	{
	}

	protected virtual void OnCameraPostRender(Texture texture)
	{
	}

	protected void ProcessEffect(Texture src, RenderTexture dest)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(src.width, src.height, 0);
		RenderTexture temporary2 = RenderTexture.GetTemporary(src.width, src.height, 0);
		float num = Mathf.Lerp(1E-05f, 1.99999f, blurSize);
		if (SettingsManager.settings != null && !SettingsManager.settings.crtEffect)
		{
			num = 1E-05f;
		}
		UpdateBlurKernel(num);
		float num2 = Mathf.Lerp(0.8f, 1.2f, (brightness + 1f) / 2f);
		float c = Mathf.Lerp(0.5f, 1.5f, (contrast + 1f) / 2f);
		float s = Mathf.Lerp(0f, 2f, (saturation + 1f) / 2f);
		UpdateColorMatrices(num2 - 1.5f, c, s);
		blurMaterial.SetFloat("pixelSizeX", (float)(1.0 / (double)src.width));
		blurMaterial.SetFloat("pixelSizeY", (float)(1.0 / (double)src.height));
		blurMaterial.SetFloat("blurSigma", num);
		blurMaterial.SetVector("blurKernel", new Vector4(blurKernel[0], blurKernel[1]));
		blurMaterial.SetFloat("blurZ", blurZ);
		postProMaterial.SetTexture("_BlurTex", temporary);
		postProMaterial.SetFloat("pixelSizeX", (float)(1.0 / (double)src.width));
		postProMaterial.SetFloat("pixelSizeY", (float)(1.0 / (double)src.height));
		postProMaterial.SetFloat("seconds", seconds);
		postProMaterial.SetFloat("blurStr", 1f - blurStrength);
		postProMaterial.SetFloat("bleedDist", bleedingSize);
		postProMaterial.SetFloat("bleedStr", bleedingStrength);
		postProMaterial.SetFloat("rgbMaskStr", Mathf.Lerp(0f, 0.3f, RGBMaskStrength));
		postProMaterial.SetFloat("rgbMaskSub", RGBMaskIntensivity);
		postProMaterial.SetFloat("rgbMaskSep", 1f - RGBMaskBleeding);
		postProMaterial.SetFloat("colorNoiseStr", Mathf.Lerp(0f, 0.4f, colorNoiseStrength));
		postProMaterial.SetInt("colorNoiseMode", (int)colorNoiseMode);
		postProMaterial.SetFloat("monoNoiseStr", Mathf.Lerp(0f, 0.4f, whiteNoiseStrength));
		postProMaterial.SetInt("monoNoiseMode", (int)whiteNoiseMode);
		postProMaterial.SetMatrix("colorMat", colorMat);
		postProMaterial.SetColor("minLevels", darkestLevel);
		postProMaterial.SetColor("maxLevels", brightestLevel);
		postProMaterial.SetColor("blackPoint", darkestColor);
		postProMaterial.SetColor("whitePoint", brightestColor);
		postProMaterial.SetFloat("interWidth", interferenceWidth);
		postProMaterial.SetFloat("interSpeed", interferenceSpeed);
		postProMaterial.SetFloat("interStr", interferenceStrength);
		postProMaterial.SetFloat("interSplit", interferenceSplit);
		postProMaterial.SetFloat("aberStr", 0f - chromaticAberrationOffset);
		float num3 = Mathf.Lerp(0f, 0.45f, curvatureX);
		float num4 = Mathf.Lerp(0f, 0.45f, curvatureY);
		finalPostProMaterial.SetFloat("pixelSizeX", (float)(1.0 / (double)src.width));
		finalPostProMaterial.SetFloat("pixelSizeY", (float)(1.0 / (double)src.height));
		finalPostProMaterial.SetFloat("vignetteStr", vignetteStrength);
		finalPostProMaterial.SetFloat("vignetteSize", 1f - vignetteSize);
		finalPostProMaterial.SetFloat("maskStr", maskStrength / 10f);
		finalPostProMaterial.SetInt("maskMode", (int)maskMode);
		finalPostProMaterial.SetFloat("crtBendX", Mathf.Lerp(1f, 100f, (1f - num3) / Mathf.Exp(10f * num3)));
		finalPostProMaterial.SetFloat("crtBendY", Mathf.Lerp(1f, 100f, (1f - num4) / Mathf.Exp(10f * num4)));
		finalPostProMaterial.SetFloat("crtOverscan", Mathf.Lerp(0.1f, 0.25f, overscan));
		finalPostProMaterial.SetInt("flipV", (src.texelSize.y < 0f && cameraTarget != null) ? 1 : 0);
		if (SettingsManager.settings == null || SettingsManager.settings.crtEffect)
		{
			Graphics.Blit(src, temporary, blurMaterial);
			Graphics.Blit(src, temporary2, postProMaterial);
			if (dest == null)
			{
				DrawFullScreenQuad(temporary2, finalPostProMaterial);
			}
			else
			{
				Graphics.Blit(temporary2, dest, finalPostProMaterial);
			}
		}
		else
		{
			Graphics.Blit(src, temporary2, blurMaterial);
			if (dest == null)
			{
				DrawFullScreenQuad(temporary2, blurMaterial);
			}
			else
			{
				Graphics.Blit(temporary2, dest, blurMaterial);
			}
		}
		temporary.DiscardContents();
		temporary2.DiscardContents();
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
	}

	protected void DrawFullScreenQuad(Texture src, Material material)
	{
		RenderTexture.active = null;
		GL.PushMatrix();
		GL.LoadOrtho();
		GL.Viewport(new Rect(0f, 0f, Screen.width, Screen.height));
		material.mainTexture = src;
		for (int i = 0; i < material.passCount; i++)
		{
			material.SetPass(i);
			GL.Begin(7);
			GL.Color(Color.white);
			GL.TexCoord2(0f, 0f);
			GL.Vertex3(0f, 0f, 0.1f);
			GL.TexCoord2(1f, 0f);
			GL.Vertex3(1f, 0f, 0.1f);
			GL.TexCoord2(1f, 1f);
			GL.Vertex3(1f, 1f, 0.1f);
			GL.TexCoord2(0f, 1f);
			GL.Vertex3(0f, 1f, 0.1f);
			GL.End();
		}
		GL.PopMatrix();
		material.mainTexture = null;
	}

	protected float CalculateBlurWeight(float x, float sigma)
	{
		return 0.39894f * Mathf.Exp(-0.5f * x * x / (sigma * sigma)) / sigma;
	}

	protected void UpdateBlurKernel(float sigma)
	{
		if (sigma == blurSigma)
		{
			return;
		}
		blurSigma = sigma;
		blurZ = 0f;
		for (int i = 0; i <= 1; i++)
		{
			float num = CalculateBlurWeight(i, sigma);
			blurKernel[1 - i] = num;
			if (i > 0)
			{
				blurZ += 2f * num;
			}
			else
			{
				blurZ += num;
			}
		}
		blurZ *= blurZ;
	}

	protected void UpdateColorMatrices(float b, float c, float s)
	{
		bool flag = false;
		if (b != currentBrightness)
		{
			flag = true;
			currentBrightness = b;
			brightnessMat.SetColumn(0, new Vector4(1f, 0f, 0f, 0f));
			brightnessMat.SetColumn(1, new Vector4(0f, 1f, 0f, 0f));
			brightnessMat.SetColumn(2, new Vector4(0f, 0f, 1f, 0f));
			brightnessMat.SetColumn(3, new Vector4(b, b, b, 1f));
		}
		if (c != currentContrast)
		{
			flag = true;
			currentContrast = c;
			float num = (1f - contrast) / 2f;
			contrastMat.SetColumn(0, new Vector4(c, 0f, 0f, 0f));
			contrastMat.SetColumn(1, new Vector4(0f, c, 0f, 0f));
			contrastMat.SetColumn(2, new Vector4(0f, 0f, c, 0f));
			contrastMat.SetColumn(3, new Vector4(num, num, num, 1f));
		}
		if (s != currentSaturation)
		{
			flag = true;
			currentSaturation = s;
			Vector3 vector = new Vector3(0.3086f, 0.6094f, 0.082f);
			float num2 = 1f - s;
			Vector4 column = new Vector4(vector.x * num2 + s, vector.x * num2, vector.x * num2, 0f);
			Vector4 column2 = new Vector4(vector.y * num2, vector.y * num2 + s, vector.y * num2, 0f);
			Vector4 column3 = new Vector4(vector.z * num2, vector.z * num2, vector.z * num2 + s, 0f);
			saturationMat.SetColumn(0, column);
			saturationMat.SetColumn(1, column2);
			saturationMat.SetColumn(2, column3);
			saturationMat.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
		}
		if (flag)
		{
			colorMat = brightnessMat * contrastMat * saturationMat;
		}
	}
}
