using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using DarkMachine.Collections;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

[ExecuteInEditMode]
public class FXManager : MonoBehaviour
{
	[Serializable]
	public class ParticleAsset
	{
		public string id;

		public ParticleSystem particleAsset;

		private ParticleSystem particleSystem;

		public void PlayParticle(Vector3 pos, int amount, Quaternion rotation)
		{
			if (particleSystem == null)
			{
				particleSystem = UnityEngine.Object.Instantiate(particleAsset, fxParticleParent);
			}
			ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
			{
				applyShapeToPosition = true,
				position = pos
			};
			particleSystem.transform.rotation = rotation;
			particleSystem.Emit(emitParams, amount);
		}

		public void PlayParticleWithRadius(Vector3 pos, float radius, int amount, Vector3 velocity = default(Vector3))
		{
			if (particleSystem == null)
			{
				particleSystem = UnityEngine.Object.Instantiate(particleAsset, fxParticleParent);
			}
			ParticleSystem.ShapeModule shape = particleSystem.shape;
			float radius2 = shape.radius;
			shape.radius = radius;
			ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
			{
				applyShapeToPosition = true,
				position = pos
			};
			particleSystem.Emit(emitParams, amount);
			if (velocity != Vector3.zero)
			{
				ParticleSystem.Particle[] array = new ParticleSystem.Particle[particleSystem.main.maxParticles];
				int particles = particleSystem.GetParticles(array);
				for (int num = particles - 1; num > particles - amount; num--)
				{
					array[num].velocity += UnityEngine.Random.value * velocity;
				}
				particleSystem.SetParticles(array, particles);
			}
			shape.radius = radius2;
		}

		public ParticleSystem GetParticleSystem()
		{
			if (particleSystem == null)
			{
				particleSystem = UnityEngine.Object.Instantiate(particleAsset, fxParticleParent);
			}
			return particleSystem;
		}
	}

	[Serializable]
	public struct ParticleTracerInfo
	{
		public string tracerID;

		public string hitID;

		public string muzzleID;
	}

	[Serializable]
	public class AnimatedTexture
	{
		public enum AnimatedTextureType
		{
			main = 0,
			emission = 1,
			custom = 2
		}

		public enum AnimatedTextureOrder
		{
			forward = 0,
			random = 1
		}

		public string id;

		public AnimatedTextureType type;

		public AnimatedTextureOrder order;

		public string customTextureName;

		public Material material;

		public List<Texture2D> textures;

		public float speed = 1f;

		public bool useRandomVariation;

		public float randomVariationAmount = 0.3f;

		private float countdown;

		private int currentFrame;

		public void Update()
		{
			if (material == null)
			{
				return;
			}
			if (countdown <= 0f)
			{
				countdown = speed;
				if (useRandomVariation)
				{
					countdown += (UnityEngine.Random.value - 0.5f) * randomVariationAmount * 2f;
				}
				if (order == AnimatedTextureOrder.forward)
				{
					currentFrame++;
					if (currentFrame >= textures.Count)
					{
						currentFrame = 0;
					}
				}
				else
				{
					currentFrame = UnityEngine.Random.Range(0, textures.Count);
				}
				if (type == AnimatedTextureType.main)
				{
					material.SetTexture("_MainTex", textures[currentFrame]);
				}
				else if (type == AnimatedTextureType.emission)
				{
					material.SetTexture("_Emission", textures[currentFrame]);
				}
				else
				{
					material.SetTexture(customTextureName, textures[currentFrame]);
				}
			}
			countdown -= Time.deltaTime;
		}
	}

	[Serializable]
	public class FXData
	{
		public bool affectGeneral = true;

		[Header("Vertex Jitter")]
		public int roundVerts = 160;

		[Space]
		[Header("Dither")]
		public float ditherLevels = 32f;

		public int ditherMinimum = 4;

		[Space]
		[Header("Lighting")]
		public float worldLightDistance = 30f;

		[Space]
		[Header("Wiggle")]
		public Vector3 worldWiggle;

		public Vector4 worldWarp;

		public bool affectLighting = true;

		public float worldBright;

		public float entityBright;

		public float lightOffset;

		public Color brightCol = Color.white;

		public float lightmapMult;

		public bool affectFog = true;

		[Range(0f, 1f)]
		public float fogMultiplier;

		[Range(1f, 32f)]
		public int fogDitherLevels = 4;

		[Range(0f, 1f)]
		public float fogDitherAmount = 0.3f;

		[ColorUsage(true, true)]
		public Color fog;

		public float fogTwoToneBlend;

		public float fogTwoToneDist = 1f;

		public float fogTwoToneOffset;

		[ColorUsage(true, true)]
		public Color fogTop;

		public bool affectColor = true;

		public Color minCol;

		public Color worldTint = Color.white;

		public float gamma;

		public float offset;

		public float invert;

		[Space]
		public bool affectHSV = true;

		public Vector3 hsv = new Vector3(0f, 1f, 1f);

		[Space]
		public bool affectNoise = true;

		public Vector2 noise = Vector2.zero;

		[Space]
		public bool affectScreenWarp = true;

		public Vector4 screenWarp;

		public float screenRadialBlur;

		public bool affectDust;

		public float dustMult = 1f;

		public Color dustColor = Color.grey;

		public Vector3 dustWind = Vector3.zero;

		public float dustNoise = 1f;
	}

	public class FXZoneStore
	{
		public float blend;

		public byte priority;

		public FXData data;
	}

	public struct DecalHandle
	{
		internal int index;

		internal int generation;

		public static bool operator ==(DecalHandle lhs, DecalHandle rhs)
		{
			if (lhs.index == rhs.index)
			{
				return lhs.generation == rhs.generation;
			}
			return false;
		}

		public static bool operator !=(DecalHandle lhs, DecalHandle rhs)
		{
			return !(lhs == rhs);
		}

		public override readonly bool Equals(object obj)
		{
			if (obj is DecalHandle decalHandle)
			{
				return this == decalHandle;
			}
			return false;
		}

		public override readonly int GetHashCode()
		{
			return index ^ generation;
		}
	}

	public enum DecalPriority
	{
		High = 0,
		Low = 1
	}

	public enum DecalRenderMode
	{
		Normal = 0,
		Additive = 1,
		Punchthrough = 2
	}

	public enum DecalWrapBehavior
	{
		Saturate = 0,
		Wrap = 1,
		RoundRobin = 2
	}

	private class DecalInfo
	{
		public DecalPriority priority;

		public DecalRenderMode renderMode;

		public string ident;

		public int generation;

		public int nextFree;

		public float startTime;

		public float timeout;

		public Transform parent;

		public Matrix4x4 offset;

		public Vector3 halfExtents;

		public float boundingSphereRadius;

		public Vector3 punchThroughDirectionLocal;

		public float punchThroughDistance;

		public Vector2Int uvTopLeft;

		public Vector2Int uvBottomRight;

		public Color modulate;

		public Gradient gradient;

		public float gradientDuration;

		public float gradientPos;

		public DecalWrapBehavior gradientWrap;

		public Color punchThroughColor;

		public (float scale, float time)[] scalePath;

		public float scalePathTime;

		public float scaleSpeedMult;

		public List<string> sharedTags;
	}

	private class DecalTagHolder
	{
		public List<DecalHandle> handles;

		public List<DecalHandle> softHandles;

		public int mainCull;

		public int softCull;

		public float softFadeout;
	}

	private struct DecalGpuDefinition
	{
		public Matrix4x4 inverseMatrix;

		public Vector4 forward;

		public Vector4 halfExtents;

		public Vector4 uv;

		public Vector4 modulate;
	}

	private struct HandholdOverrideMaterial
	{
		public string id;

		public Material material;

		public Material originalMaterial;

		public ColorSetting.ColorType handholdColorType;
	}

	private struct ForwardPlusSphereInfo
	{
		public Vector3 cameraPos;

		[ReadOnly]
		public NativeArray<Plane> shiftedHorizontalPlanes;

		[ReadOnly]
		public NativeArray<Plane> shiftedVerticalPlanes;
	}

	[StructLayout(LayoutKind.Sequential, Size = 64)]
	private struct CacheAlignedInt
	{
		public int value;
	}

	private struct DecalJobFrustrumSearch : IJobParallelFor
	{
		[ReadOnly]
		public ForwardPlusSphereInfo sphereInfo;

		[ReadOnly]
		public NativeArray<Vector4> positionsAndRadius;

		[NativeSetThreadIndex]
		public int threadIndex;

		[NativeDisableContainerSafetyRestriction]
		[ReadOnly]
		public NativeArray<CacheAlignedInt> outCount;

		[NativeDisableContainerSafetyRestriction]
		[ReadOnly]
		public NativeArray<NativeArray<int>> outIndexes;

		[NativeDisableContainerSafetyRestriction]
		[ReadOnly]
		public NativeArray<NativeArray<Vector3Int>> outMin;

		[NativeDisableContainerSafetyRestriction]
		[ReadOnly]
		public NativeArray<NativeArray<Vector3Int>> outMax;

		public void Execute(int index)
		{
			Vector4 vector = positionsAndRadius[index];
			(Vector3Int min, Vector3Int max) tuple = ForwardPlusSphere(in sphereInfo, vector, vector.w);
			Vector3Int item = tuple.min;
			Vector3Int item2 = tuple.max;
			int value = outCount[threadIndex].value;
			outCount[threadIndex] = new CacheAlignedInt
			{
				value = value + 1
			};
			NativeArray<int> nativeArray = outIndexes[threadIndex];
			nativeArray[value] = index;
			NativeArray<Vector3Int> nativeArray2 = outMin[threadIndex];
			nativeArray2[value] = item;
			NativeArray<Vector3Int> nativeArray3 = outMax[threadIndex];
			nativeArray3[value] = item2;
		}
	}

	[Serializable]
	public class DecalTagInfo
	{
		public string name;

		public int maxCount;

		public int softLimit;

		public float softFadeTime = 1f;
	}

	public struct DecalSharedOutput
	{
		public string ident;

		public Vector3 extents;

		public Vector2Int uvTopLeft;

		public Vector2Int uvBottomRight;

		public List<string> tags;
	}

	public static Transform fxParticleParent;

	public List<ParticleAsset> particleAssets;

	private Dictionary<string, ParticleAsset> particleDict;

	[HideInInspector]
	public List<FX_CameraShaderController> enabledCameras = new List<FX_CameraShaderController>();

	public static FXManager fxMan;

	private CL_GameManager gMan;

	public FXData defaultLook;

	private static FXZoneStore regionFX;

	public static FXData defaultData;

	public static FXData fxData;

	public static PriorityQueue<FXZoneStore, byte> fxZones = new PriorityQueue<FXZoneStore, byte>();

	private const int decalPriorityHighMaxCount = 24;

	private const int decalPriorityLowMaxCount = 232;

	private static List<DecalInfo> decalGenArray = new List<DecalInfo>();

	private static int decalNextFree;

	private const string decalAtlasPath = "Sprite Assets/fx_decalsheet_01";

	private static Texture decalAtlas;

	private static Dictionary<string, DecalTagHolder> decalTags = new Dictionary<string, DecalTagHolder>();

	private static Gradient decalFadeoutGradient;

	private static float decalMultLast = 1f;

	[SerializeField]
	private List<DecalTagInfo> _decalTags = new List<DecalTagInfo>();

	private const int decalGpuLimit = 256;

	private readonly DecalGpuDefinition[] decalGpuDefinitionStaging = new DecalGpuDefinition[256];

	private static ComputeBuffer decalGpuDefinition;

	private const int decalGpuArraysSlotCount = 361856;

	private readonly byte[] decalGpuArraysStaging = new byte[361856];

	private static ComputeBuffer decalGpuArrays;

	private readonly int[] decalGpuIndirectionStaging = new int[1408];

	private static ComputeBuffer decalGpuIndirection;

	public static Action<Camera> OnPreRenderFX;

	private static List<HandholdOverrideMaterial> handholdMaterials;

	private static Dictionary<string, HandholdOverrideMaterial> handholdMaterialDict;

	private static Texture2D whiteTex;

	internal static List<FX_RunningLightFlare> runningLightFlares = new List<FX_RunningLightFlare>();

	public static bool showFog = true;

	public static bool fullBright = false;

	public static bool noTexture = false;

	public static bool noFog = false;

	public Texture2D corruptionTexture;

	public float corruptionHeight;

	private float corruptionHeightOverride = float.NegativeInfinity;

	private int corruptionHeightOverrideFrame;

	public Texture2D ditherTexture;

	public const int forwardPlusGridWidth = 16;

	public const int forwardPlusGridHeight = 8;

	private const int forwardPlusGridDepth = 11;

	private Matrix4x4 cameraWorldProjMat;

	private readonly Plane[] frustrumPlanesCachedArray = new Plane[6];

	private static ForwardPlusSphereInfo forwardPlusSphereInfo = new ForwardPlusSphereInfo
	{
		cameraPos = Vector3.zero,
		shiftedHorizontalPlanes = new NativeArray<Plane>(15, Allocator.Persistent),
		shiftedVerticalPlanes = new NativeArray<Plane>(7, Allocator.Persistent)
	};

	private readonly Vector3[] frustrumCornersCachedArray = new Vector3[4];

	private readonly List<(Vector3 center, Vector3 normal)> frustrumSavedPlanes = new List<(Vector3, Vector3)>();

	private readonly List<Vector3> frustrumSavedPoints = new List<Vector3>();

	private readonly List<Vector3> frustrumSavedPointsTemp = new List<Vector3>();

	private List<CL_Lamp> lights = new List<CL_Lamp>();

	private HashSet<CL_Lamp> lightHash = new HashSet<CL_Lamp>();

	public const int lampMaxCount = 32;

	private Vector4[] lampInfo = new Vector4[32];

	private Vector4[] lampColor = new Vector4[32];

	private Vector4[] lampDirections = new Vector4[32];

	private Vector4[] lampEffects = new Vector4[32];

	private uint[] lampGridStaging = new uint[1408];

	private static ComputeBuffer lampGrid;

	private CL_Lamp[] lightsActive = new CL_Lamp[32];

	private int lightsActiveCount;

	public List<AnimatedTexture> animatedTextures = new List<AnimatedTexture>();

	private bool lampShowRadius;

	private bool lampShowGrid;

	private bool lampNoCulling;

	private int lampShowCounts;

	private bool lampFullDepth;

	private uint lampsVisibleMask = uint.MaxValue;

	private int lampGridDepth;

	private List<CL_Lamp> lockedList;

	private bool decalShowBox;

	private bool decalNoUpload;

	private int decalShowCounts;

	private int decalGridDepth = -1;

	private int decalRenderSpecific = -1;

	private static bool decalRespectTagLimit = true;

	private static bool decalRespectTimeout = true;

	private bool decalForwardPlus = true;

	private bool decalBackCull = true;

	private readonly List<(DecalInfo info, Matrix4x4 mat)> decalsSubmittingQueueCached = new List<(DecalInfo, Matrix4x4)>();

	private readonly List<int> decalsSubmittingPrioritiesCached = new List<int>();

	private readonly Dictionary<Vector3Int, List<byte>> decalBucketToDecals = new Dictionary<Vector3Int, List<byte>>();

	private readonly List<List<byte>> decalBucketToDecalsPool = new List<List<byte>>();

	private static DecalJobFrustrumSearch decalJobFrustrumSearch;

	private static (float, float)[] decalPunchFadeout = new(float, float)[2]
	{
		(1f, 0f),
		(0f, 1f)
	};

	public static void PlayParticle(string id, Vector3 pos, int amount)
	{
		if (!(fxMan == null) && fxMan.particleDict != null && fxMan.particleDict.ContainsKey(id))
		{
			fxMan.particleDict[id].PlayParticle(pos, amount, Quaternion.identity);
		}
	}

	public static void PlayParticleWithRadius(string id, Vector3 pos, float radius, int amount, Vector3 velocity = default(Vector3))
	{
		if (!(fxMan == null) && fxMan.particleDict != null && fxMan.particleDict.ContainsKey(id))
		{
			fxMan.particleDict[id].PlayParticleWithRadius(pos, radius, amount, velocity);
		}
	}

	public static void PlayParticleWithRotation(string id, Vector3 pos, int amount, Quaternion rotation)
	{
		if (!(fxMan == null) && fxMan.particleDict != null && !string.IsNullOrWhiteSpace(id) && fxMan.particleDict.ContainsKey(id))
		{
			fxMan.particleDict[id].PlayParticle(pos, amount, rotation);
		}
	}

	public static void PlayTracer(string tracerParticleID, Vector3 startPoint, Vector3 endPoint, float speed = 100f, string hitParticleID = "", string muzzleFlashParticleID = "")
	{
		ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
		Vector3 vector = endPoint - startPoint;
		emitParams.velocity = vector.normalized * speed;
		emitParams.startLifetime = vector.magnitude / speed;
		ParticleSystem.EmitParams emitParams2 = new ParticleSystem.EmitParams
		{
			position = endPoint,
			applyShapeToPosition = true
		};
		if (hitParticleID != "" && fxMan.particleDict.ContainsKey(hitParticleID))
		{
			fxMan.particleDict[hitParticleID].GetParticleSystem().Emit(emitParams2, 20);
		}
		emitParams2.position = startPoint;
		if (muzzleFlashParticleID != "" && fxMan.particleDict.ContainsKey(muzzleFlashParticleID))
		{
			fxMan.particleDict[muzzleFlashParticleID].GetParticleSystem().Emit(emitParams2, 15);
		}
		emitParams.applyShapeToPosition = true;
		emitParams.position = startPoint;
		if (fxMan.particleDict.ContainsKey(tracerParticleID))
		{
			fxMan.particleDict[tracerParticleID].GetParticleSystem().Emit(emitParams, 1);
		}
	}

	public void SetMapVars(Color fC, Color sC, Color fmC, Texture2D mG, Color sT, Color sB, float fH, float fF, Color wT, Color cT)
	{
		Shader.SetGlobalVectorArray("_LIGHT", lampInfo);
		Shader.SetGlobalVectorArray("_LIGHTCOL", lampColor);
		defaultData.worldTint = wT;
	}

	private void Awake()
	{
		gMan = CL_GameManager.gMan;
		OnPreRenderFX = null;
		regionFX = new FXZoneStore();
		regionFX.data = new FXData();
		corruptionHeight = -50000f;
		fxMan = this;
		defaultData = defaultLook;
		fxData = new FXData();
		fxData = defaultData;
		if (lights == null)
		{
			lights = new List<CL_Lamp>();
		}
		else if (Application.isPlaying)
		{
			lights.Clear();
		}
		if (lampGrid == null)
		{
			lampGrid = new ComputeBuffer(1408, Marshal.SizeOf<uint>());
			lampGrid.name = "Lamp Forward+ Clusters";
		}
		decalGenArray.Clear();
		decalNextFree = 0;
		decalTags.Clear();
		DecalAtlas();
		if (decalGpuArrays == null)
		{
			decalGpuArrays = new ComputeBuffer(90464, 4, ComputeBufferType.Structured, ComputeBufferMode.Dynamic);
			decalGpuArrays.name = "Decal Definition Indexes";
		}
		if (decalGpuDefinition == null)
		{
			decalGpuDefinition = new ComputeBuffer(256, Marshal.SizeOf<DecalGpuDefinition>(), ComputeBufferType.Structured, ComputeBufferMode.Dynamic);
			decalGpuDefinition.name = "Decal Definitions";
		}
		if (decalGpuIndirection == null)
		{
			decalGpuIndirection = new ComputeBuffer(1408, Marshal.SizeOf<uint>());
			decalGpuIndirection.name = "Decal Forward+ Clusters";
		}
		foreach (DecalTagInfo decalTag in _decalTags)
		{
			decalTags[decalTag.name] = new DecalTagHolder
			{
				mainCull = decalTag.maxCount,
				softCull = decalTag.softLimit,
				handles = new List<DecalHandle>(decalTag.maxCount),
				softHandles = new List<DecalHandle>(decalTag.softLimit),
				softFadeout = decalTag.softFadeTime
			};
		}
		decalFadeoutGradient = new Gradient();
		GradientAlphaKey[] array = new GradientAlphaKey[2];
		array[0].alpha = 1f;
		array[0].time = 0f;
		array[1].alpha = 0f;
		array[1].time = 1f;
		GradientColorKey[] colorKeys = new GradientColorKey[0];
		decalFadeoutGradient.SetKeys(colorKeys, array);
		decalMultLast = 1f;
		if (SettingsManager.settings != null)
		{
			decalMultLast = SettingsManager.settings.decalMult;
		}
		decalRespectTagLimit = true;
		decalRespectTimeout = true;
		FXRender();
		FXForwardPlus(Camera.main);
		StopAllCoroutines();
		StartCoroutine(QuickSortLoop());
		FX_BeamManager.ClearAll();
		fullBright = false;
		noTexture = false;
		noFog = false;
		showFog = true;
		if (Application.isPlaying)
		{
			CommandConsole.BuildCommand("fullbright", Fullbright).Description("(enabled=toggle): Disable darkness").OverValue(() => fullBright);
			CommandConsole.BuildVariableBool(() => ref noTexture, "notexture", "Hide world textures");
			CommandConsole.BuildVariableBool(() => ref noFog, "nofog", "Hide fog");
			CommandConsole.BuildCommand("forwardplus_addplanes", delegate
			{
				NativeArray<Plane>[] array2 = new NativeArray<Plane>[2] { forwardPlusSphereInfo.shiftedHorizontalPlanes, forwardPlusSphereInfo.shiftedVerticalPlanes };
				for (int i = 0; i < array2.Length; i++)
				{
					for (int j = 0; j < array2[i].Length; j++)
					{
						frustrumSavedPlanes.Add((forwardPlusSphereInfo.cameraPos, array2[i][j].normal));
					}
				}
				frustrumSavedPoints.AddRange(frustrumSavedPointsTemp);
			});
			CommandConsole.BuildCommand("forwardplus_removeplanes", delegate
			{
				frustrumSavedPlanes.Clear();
				frustrumSavedPoints.Clear();
			});
			CommandConsole.BuildVariableBool(() => ref lampShowRadius, "lights_radius", "Show radiuses of all lights").NotCheat();
			CommandConsole.BuildVariableBool(() => ref lampShowGrid, "lights_grid", "Show screenspace light grid").NotCheat();
			CommandConsole.BuildVariableInt(() => ref lampGridDepth, "lights_grid_depth", "Which depth buckets in frustrum we want to see in light grid").NotCheat();
			CommandConsole.BuildVariableBool(() => ref lampNoCulling, "lights_nocull", "Don't perform forward+ culling on lights").NotCheat();
			CommandConsole.BuildVariableInt(() => ref lampShowCounts, "lights_showcounts", "1=The brighter a pixel, the more lights it had to check\n2=Render depth buckets");
			CommandConsole.BuildVariableBool(() => ref lampFullDepth, "lights_depth_forcefull", "Place light in every depth bucket of its tiles.").NotCheat();
			CommandConsole.BuildCommand("lights_active", LightsDebugActive).Description("Bitmask determining which lights to render in order").OverValue(() => $"0x{lampsVisibleMask:X}")
				.NotCheat();
			CommandConsole.BuildCommand("lights_lock", LightsDebugLock).Description("Lock currently rendered lights as only rendered ones").OverValue(() => lockedList != null);
			CommandConsole.BuildVariableBool(() => ref decalShowBox, "decal_showbox", "Render box of decal");
			CommandConsole.BuildVariableBool(() => ref decalNoUpload, "decal_noupload", "Don't upload any forward+ info");
			CommandConsole.BuildVariableInt(() => ref decalShowCounts, "decal_showcounts", "Show counts in world");
			CommandConsole.BuildVariableInt(() => ref decalGridDepth, "decal_griddepth", "Render specific depth of decal grid, showing counts");
			CommandConsole.BuildVariableInt(() => ref decalGridDepth, "decal_griddepth", "Render specific depth of decal grid, showing counts");
			CommandConsole.BuildVariableInt(() => ref decalRenderSpecific, "decal_renderspecific", "Render specific decal");
			CommandConsole.BuildVariableBool(() => ref decalRespectTagLimit, "decal_respecttaglimit", "Whether or not oldest living decal should be killed when surpassing limit defined by tags. May reduce perf.");
			CommandConsole.BuildVariableBool(() => ref decalRespectTimeout, "decal_respecttimeout", "Whether or not decals that request a timeout/fadeout have their timeout respected.");
			CommandConsole.BuildVariableBool(() => ref decalForwardPlus, "decal_forwardplus", "Whether or not forward+ culling should be performed.");
			CommandConsole.BuildVariableBool(() => ref decalBackCull, "decal_backcull", "Whether or not decals facing away from the camera should be rendered.");
		}
		particleDict = new Dictionary<string, ParticleAsset>();
		foreach (ParticleAsset particleAsset in particleAssets)
		{
			particleDict.Add(particleAsset.id, particleAsset);
		}
		Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(PreRender));
	}

	private void OnDestroy()
	{
		Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(PreRender));
	}

	private void LightsDebugActive(string[] args)
	{
		if (args.Length == 0)
		{
			lampsVisibleMask = uint.MaxValue;
		}
		if (args.Length >= 1)
		{
			uint num = Convert.ToUInt32(args[0], 16);
			lampsVisibleMask = num;
		}
	}

	private void LightsDebugLock(string[] args)
	{
		if (lockedList != null)
		{
			CommandConsole.Log("Unlocking list");
			lockedList = null;
			return;
		}
		CommandConsole.Log("Locking list");
		lockedList = new List<CL_Lamp>();
		for (int i = 0; i < lightsActiveCount; i++)
		{
			lockedList.Add(lightsActive[i]);
		}
	}

	private void Update()
	{
		if (regionFX == null)
		{
			regionFX = new FXZoneStore();
			regionFX.data = new FXData();
		}
		if (WorldLoader.instance != null && WorldLoader.instance.GetCurrentLevel() != null && WorldLoader.instance.GetCurrentLevel().GetLevel() != null && WorldLoader.instance.GetCurrentLevel().GetLevel().region != null)
		{
			if (WorldLoader.instance.GetCurrentLevel().GetLevel().region.useCustomFXSettings)
			{
				regionFX.data = BlendFXData(regionFX.data, WorldLoader.instance.GetCurrentLevel().GetLevel().region.fxData, Time.deltaTime);
			}
		}
		else
		{
			regionFX.data = BlendFXData(regionFX.data, defaultData, Time.deltaTime);
		}
		regionFX.blend = 1f;
		regionFX.priority = 0;
		float decalMult = decalMultLast;
		if (SettingsManager.settings != null)
		{
			decalMult = SettingsManager.settings.decalMult;
		}
		if (decalMult < decalMultLast)
		{
			foreach (DecalTagHolder value in decalTags.Values)
			{
				int num = (int)((float)value.mainCull * decalMult);
				List<DecalHandle> list = new List<DecalHandle>(value.mainCull);
				int i;
				for (i = 0; i < value.handles.Count; i++)
				{
					if (list.Count >= num)
					{
						break;
					}
					if (DecalExists(value.handles[i]))
					{
						list.Add(value.handles[i]);
					}
				}
				for (; i < value.handles.Count; i++)
				{
					DecalDestroy(value.handles[i]);
				}
				value.handles = list;
			}
		}
		decalMultLast = decalMult;
		List<Camera> list2 = new List<Camera>();
		for (int j = 0; j < enabledCameras.Count; j++)
		{
			FX_CameraShaderController fX_CameraShaderController = enabledCameras[j];
			if (fX_CameraShaderController != null && fX_CameraShaderController.cam != null && fX_CameraShaderController.renderBeams)
			{
				list2.Add(fX_CameraShaderController.cam);
			}
		}
		FX_BeamManager.Update(list2);
	}

	private void PreRender(Camera camera)
	{
		if (camera == Camera.main && Application.isPlaying)
		{
			for (int i = 0; i < runningLightFlares.Count; i++)
			{
				Transform transform = runningLightFlares[i].transform;
				transform.rotation = Quaternion.LookRotation(camera.transform.position - transform.position);
			}
			FXForwardPlus(camera);
		}
	}

	public static void CameraFX(Camera camera)
	{
		if (fxMan != null)
		{
			defaultData = fxMan.defaultLook;
		}
		fxZones.Enqueue(regionFX, regionFX.priority);
		if (OnPreRenderFX != null)
		{
			OnPreRenderFX(camera);
		}
		FXData d = new FXData();
		while (fxZones.Count > 0)
		{
			FXZoneStore fXZoneStore = fxZones.Dequeue();
			d = BlendFXData(d, fXZoneStore.data, fXZoneStore.blend);
		}
		fxData = d;
		FXRender();
	}

	[ExecuteAlways]
	private void LateUpdate()
	{
		defaultData = defaultLook;
		Shader.SetGlobalFloat("_UNSCALEDTIME", Time.unscaledTime);
		foreach (AnimatedTexture animatedTexture in animatedTextures)
		{
			animatedTexture.Update();
		}
		StartCoroutine(OnEndOfFrame());
	}

	private IEnumerator OnEndOfFrame()
	{
		yield return new WaitForEndOfFrame();
		Cosmetic_HandItem.ReturnSprites();
	}

	private static bool IsSphereInSphere(Vector3 aOrigin, float aRadius, Vector3 bOrigin, float bRadius)
	{
		return (aOrigin - bOrigin).sqrMagnitude < (aRadius + bRadius) * (aRadius + bRadius);
	}

	private static bool IsSphereInFrontOfPlane(Plane plane, Vector3 pos, float radius)
	{
		return plane.GetDistanceToPoint(pos) >= 0f - radius;
	}

	public static bool IsSphereInFrustrum(Plane[] frustrumPlanes, Vector3 pos, float radius)
	{
		for (int i = 0; i < frustrumPlanes.Length; i++)
		{
			if (!IsSphereInFrontOfPlane(frustrumPlanes[i], pos, radius))
			{
				return false;
			}
		}
		return true;
	}

	private void FXForwardPlus(Camera camera)
	{
		bool flag = false;
		if (camera != null && flag)
		{
			camera.depthTextureMode = DepthTextureMode.Depth;
		}
		foreach (var (vector, vector2) in frustrumSavedPlanes)
		{
			CL_DebugView.draw.WirePlane(vector, vector2, new float2(10f, 10f));
		}
		foreach (Vector3 frustrumSavedPoint in frustrumSavedPoints)
		{
			CL_DebugView.draw.WireSphere(frustrumSavedPoint, 1f);
		}
		Vector3 vector3 = Vector3.zero;
		cameraWorldProjMat = Matrix4x4.identity;
		_ = Matrix4x4.identity;
		Matrix4x4 matrix4x = Matrix4x4.identity;
		Plane[] array = frustrumPlanesCachedArray;
		Vector3[] array2 = frustrumCornersCachedArray;
		_ = Vector2.zero;
		if (camera != null)
		{
			GeometryUtility.CalculateFrustumPlanes(camera, array);
			vector3 = camera.transform.position;
			matrix4x = camera.cameraToWorldMatrix;
			cameraWorldProjMat = camera.projectionMatrix * camera.transform.worldToLocalMatrix;
			new Vector2(camera.pixelWidth, camera.pixelHeight);
			camera.CalculateFrustumCorners(new Rect(0f, 0f, 1f, 1f), 1f, Camera.MonoOrStereoscopicEye.Mono, array2);
		}
		_ = ref array[4];
		if (camera != null)
		{
			Matrix4x4 matrix4x2 = matrix4x;
			matrix4x2.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
			Matrix4x4 matrix4x3 = matrix4x2 * camera.projectionMatrix.inverse;
			_ = ref array2[0];
			_ = ref array2[2];
			_ = ref array2[0];
			_ = ref array2[2];
			frustrumSavedPointsTemp.Clear();
			for (int i = 0; i < forwardPlusSphereInfo.shiftedHorizontalPlanes.Length; i++)
			{
				float x = (float)(i + 1) / (float)(forwardPlusSphereInfo.shiftedHorizontalPlanes.Length + 1) * 2f - 1f;
				Vector3 vector4 = matrix4x3.MultiplyPoint(new Vector3(x, -1f, 0.5f));
				Vector3 vector5 = matrix4x3.MultiplyPoint(new Vector3(x, 1f, 0.5f));
				forwardPlusSphereInfo.shiftedHorizontalPlanes[i] = new Plane(Vector3.zero, vector4, vector5);
				frustrumSavedPointsTemp.Add(vector3 + vector4 * 8f);
				frustrumSavedPointsTemp.Add(vector3 + vector5 * 8f);
			}
			for (int j = 0; j < forwardPlusSphereInfo.shiftedVerticalPlanes.Length; j++)
			{
				float y = (float)(j + 1) / (float)(forwardPlusSphereInfo.shiftedVerticalPlanes.Length + 1) * 2f - 1f;
				Vector3 vector6 = matrix4x3.MultiplyPoint(new Vector3(-1f, y, 0.5f));
				Vector3 vector7 = matrix4x3.MultiplyPoint(new Vector3(1f, y, 0.5f));
				forwardPlusSphereInfo.shiftedVerticalPlanes[j] = new Plane(Vector3.zero, vector7, vector6);
				frustrumSavedPointsTemp.Add(vector3 + vector6 * 8f);
				frustrumSavedPointsTemp.Add(vector3 + vector7 * 8f);
			}
		}
		forwardPlusSphereInfo.cameraPos = vector3;
		FXLights(camera);
		FXDecals(camera);
	}

	private void FXLights(Camera camera)
	{
		bool flag = false;
		int num = 0;
		Vector2 vector = Vector2.zero;
		if (camera != null)
		{
			num = 32;
			vector = new Vector2(camera.pixelWidth, camera.pixelHeight);
		}
		CL_Lamp[] array = lightsActive;
		int num2 = 0;
		byte b = 0;
		float num3 = defaultLook.worldLightDistance * defaultLook.worldLightDistance;
		Array.Fill(lampGridStaging, 0u);
		List<CL_Lamp> list = lights;
		bool flag2 = false;
		if (lockedList != null)
		{
			list = lockedList;
			flag2 = true;
		}
		for (int i = 0; i < list.Count; i++)
		{
			CL_Lamp cL_Lamp = list[i];
			if (num2 >= num - 1)
			{
				break;
			}
			if (cL_Lamp == null && !flag2)
			{
				list.RemoveAt(i--);
			}
			if (cL_Lamp == null || !cL_Lamp.lampActive || !cL_Lamp.enabled || !cL_Lamp.gameObject.activeInHierarchy)
			{
				continue;
			}
			num2++;
			Vector3 position = cL_Lamp.transform.position;
			float radius = cL_Lamp.RealRadius();
			bool flag3 = cL_Lamp.angle > 0f;
			bool flag4 = flag || IsSphereInFrustrum(frustrumPlanesCachedArray, position, radius);
			if (!flag4 || Vector3.SqrMagnitude(forwardPlusSphereInfo.cameraPos - position) >= num3)
			{
				continue;
			}
			uint num4 = (uint)(1 << (int)b);
			bool flag5 = (lampsVisibleMask & num4) != 0;
			Vector3Int vector3Int = default(Vector3Int);
			Vector3Int vector3Int2 = default(Vector3Int);
			if (flag5)
			{
				(vector3Int, vector3Int2) = ForwardPlusSphere(in forwardPlusSphereInfo, position, radius);
			}
			if (lampFullDepth)
			{
				vector3Int.z = 0;
				vector3Int2.z = 10;
			}
			if (flag5)
			{
				for (int j = vector3Int.x; j < vector3Int2.x; j++)
				{
					for (int k = vector3Int.y; k < vector3Int2.y; k++)
					{
						for (int l = vector3Int.z; l < vector3Int2.z; l++)
						{
							int num5 = j + k * 16 + l * 16 * 8;
							lampGridStaging[num5] |= num4;
						}
					}
				}
			}
			if (lampShowRadius && flag5)
			{
				Color color = DarkMachineCrayons.crayons[b];
				CL_DebugView.draw.PushColor(color);
				_ = (Vector3)((cameraWorldProjMat.MultiplyPoint(position) * 0.5f + new Vector3(0.5f, 0.5f, 0.5f)) * vector);
				CL_DebugView.draw.WireSphere(position, cL_Lamp.range);
				CL_DebugView.draw.WireSphere(position, radius);
				CL_DebugView.draw.Label2D(position, $"{b}\n{vector3Int} -> {vector3Int2}\nIs spotlight: {flag3}\nIs inside: {flag4}");
				CL_DebugView.draw.PopColor();
			}
			array[b] = cL_Lamp;
			b++;
		}
		if (flag || lampNoCulling || SettingsManager.settings == null || !SettingsManager.settings.forwardPlusRendering)
		{
			uint value = lampsVisibleMask & (uint)((1 << (int)b) - 1);
			Array.Fill(lampGridStaging, value);
		}
		DebugMenu.UpdateDebugText("Lights submitted", $"Submitted light count: {b}/{num2} ({lights.Count} total)");
		if (lampShowGrid)
		{
			using (CL_DebugView.draw.InScreenSpace(camera))
			{
				int num6 = Mathf.Clamp(lampGridDepth, 0, 10);
				for (int m = 0; m <= 16; m++)
				{
					CL_DebugView.draw.xy.Line(new Vector3(vector.x * (float)m / 16f, 0f, 0f), new Vector3(vector.x * (float)m / 16f, vector.y, 0f));
				}
				for (int n = 0; n <= 8; n++)
				{
					CL_DebugView.draw.xy.Line(new Vector3(0f, vector.y * (float)n / 8f, 0f), new Vector3(vector.x, vector.y * (float)n / 8f, 0f));
				}
				for (int num7 = 0; num7 < 16; num7++)
				{
					for (int num8 = 0; num8 < 8; num8++)
					{
						Vector3 vector2 = new Vector3(vector.x * (float)num7 / 16f, 16f + vector.y * (float)num8 / 8f, 0f);
						int num9 = num7 + (7 - num8) * 16 + num6 * 16 * 8;
						uint num10 = lampGridStaging[num9];
						CL_DebugView.draw.xy.Label2D(vector2, $"({num7}, {7 - num8})\n{num10:X}");
					}
				}
			}
		}
		lightsActiveCount = b;
		for (int num11 = 0; num11 < num; num11++)
		{
			if (array.Length > num11 && array[num11] != null)
			{
				CL_Lamp cL_Lamp2 = array[num11];
				if (cL_Lamp2.lampActive && cL_Lamp2.gameObject.activeInHierarchy && cL_Lamp2.enabled)
				{
					Vector3 position2 = cL_Lamp2.transform.position;
					lampInfo[num11].x = position2.x;
					lampInfo[num11].y = position2.y;
					lampInfo[num11].z = position2.z;
					lampInfo[num11].w = cL_Lamp2.curRange;
					lampColor[num11] = cL_Lamp2.color;
					lampColor[num11].w = cL_Lamp2.GetCurrentIntensity() * cL_Lamp2.GetFade();
					Vector3 forward = cL_Lamp2.transform.forward;
					lampDirections[num11].x = forward.x;
					lampDirections[num11].y = forward.y;
					lampDirections[num11].z = forward.z;
					lampDirections[num11].w = Mathf.Cos(MathF.PI / 180f * cL_Lamp2.angle * 0.65f);
					lampEffects[num11].x = cL_Lamp2.bypassLightmap;
					lampEffects[num11].y = cL_Lamp2.attentuation;
					lampEffects[num11].z = cL_Lamp2.emissiveMult;
					lampEffects[num11].w = cL_Lamp2.GetCurrentCorruption() * cL_Lamp2.GetFade();
				}
				else
				{
					lampInfo[num11] = new Vector4(0f, 0f, 0f, 0f);
					lampColor[num11] = new Vector4(0f, 0f, 0f, 0f);
					lampDirections[num11] = new Vector4(0f, 0f, 0f, 0f);
					lampEffects[num11] = new Vector4(0f, 0f, 0f, 0f);
				}
			}
			else
			{
				lampInfo[num11] = new Vector4(0f, 0f, 0f, 0f);
				lampColor[num11] = new Vector4(0f, 0f, 0f, 0f);
				lampDirections[num11] = new Vector4(0f, 0f, 0f, 0f);
				lampEffects[num11] = new Vector4(0f, 0f, 0f, 0f);
			}
		}
		Shader.SetGlobalInt("_LIGHT_TOTAL_COUNT", b);
		Shader.SetGlobalVectorArray("_LIGHT", lampInfo);
		Shader.SetGlobalVectorArray("_LIGHTCOL", lampColor);
		Shader.SetGlobalVectorArray("_LIGHTDIR", lampDirections);
		Shader.SetGlobalVectorArray("_LIGHTFX", lampEffects);
		Shader.SetGlobalInt("_LIGHT_DEBUG_COUNT", lampShowCounts);
		if (lampGrid != null)
		{
			lampGrid.SetData(lampGridStaging);
			Shader.SetGlobalBuffer("_LIGHT_LOOKUP", lampGrid);
		}
	}

	public void OverrideCorruptionHeightFrame(float newHeight)
	{
		corruptionHeightOverride = Mathf.Max(corruptionHeightOverride, newHeight);
		corruptionHeightOverrideFrame = Time.frameCount;
	}

	private unsafe static (Vector3Int min, Vector3Int max) ForwardPlusSphere(in ForwardPlusSphereInfo info, Vector3 pos, float radius)
	{
		int i = 0;
		int num = 0;
		int a = 0;
		int a2 = 0;
		int num2 = 0;
		int num3 = 0;
		bool flag = IsSphereInSphere(info.cameraPos, 0f, pos, radius);
		if (!flag)
		{
			pos -= info.cameraPos;
			Plane* unsafeReadOnlyPtr = (Plane*)info.shiftedHorizontalPlanes.GetUnsafeReadOnlyPtr();
			Plane* unsafeReadOnlyPtr2 = (Plane*)info.shiftedVerticalPlanes.GetUnsafeReadOnlyPtr();
			for (i = 0; i < info.shiftedHorizontalPlanes.Length && !IsSphereInFrontOfPlane(unsafeReadOnlyPtr[i], pos, radius); i++)
			{
			}
			a = info.shiftedHorizontalPlanes.Length;
			while (a-- > 0)
			{
				if (IsSphereInFrontOfPlane(unsafeReadOnlyPtr[a].flipped, pos, radius))
				{
					a++;
					break;
				}
			}
			num = info.shiftedVerticalPlanes.Length;
			while (num-- > 0)
			{
				if (IsSphereInFrontOfPlane(unsafeReadOnlyPtr2[num].flipped, pos, radius))
				{
					num++;
					break;
				}
			}
			for (a2 = 0; a2 < info.shiftedVerticalPlanes.Length && !IsSphereInFrontOfPlane(unsafeReadOnlyPtr2[a2], pos, radius); a2++)
			{
			}
			num = 7 - num;
			a2 = 7 - a2;
			if (a < i)
			{
				int num4 = a;
				int num5 = i;
				i = num4;
				a = num5;
			}
			if (a2 < num)
			{
				int num6 = a2;
				int num5 = num;
				num = num6;
				a2 = num5;
			}
			a++;
			a2++;
			pos += info.cameraPos;
		}
		if (flag)
		{
			a = 16;
			a2 = 8;
		}
		float magnitude = (pos - info.cameraPos).magnitude;
		num2 = Mathf.Max(Mathf.FloorToInt(Mathf.Log(magnitude - radius, 2f)), 0);
		num3 = Mathf.Max(Mathf.CeilToInt(Mathf.Log(magnitude + radius, 2f)), 0);
		if (num3 == num2)
		{
			num3++;
		}
		i = Mathf.Max(i, 0);
		a = Mathf.Min(a, 16);
		num = Mathf.Max(num, 0);
		a2 = Mathf.Min(a2, 8);
		num2 = Mathf.Max(num2, 0);
		num3 = Mathf.Min(num3, 11);
		Vector3Int item = new Vector3Int(i, num, num2);
		Vector3Int item2 = new Vector3Int(a, a2, num3);
		return (min: item, max: item2);
	}

	public static void FXRender()
	{
		if (fxData == null)
		{
			fxData = new FXData();
			return;
		}
		Shader.SetGlobalInt("_ROUND", fxData.roundVerts);
		Shader.SetGlobalInt("_DITHERLEVELS", Mathf.RoundToInt(fxData.ditherLevels));
		Shader.SetGlobalFloat("_FOGDITHERAMOUNT", fxData.fogDitherAmount);
		Shader.SetGlobalInt("_FOGDITHERLEVELS", fxData.fogDitherLevels);
		if (ENT_Player.GetPlayer() != null)
		{
			Shader.SetGlobalFloat("_SCREENWETAMOUNT", ENT_Player.GetPlayer().entityEffects.wet);
		}
		else
		{
			Shader.SetGlobalFloat("_SCREENWETAMOUNT", 0f);
		}
		Shader.SetGlobalFloat("_LIGHTMAPMULT", fxData.lightmapMult);
		if (fxMan != null)
		{
			if (Time.frameCount != fxMan.corruptionHeightOverrideFrame)
			{
				fxMan.corruptionHeightOverride = float.NegativeInfinity;
			}
			Shader.SetGlobalFloat("_CORRUPTHEIGHT", Mathf.Max(fxMan.corruptionHeight, fxMan.corruptionHeightOverride));
			Shader.SetGlobalTexture("_DITHERTEXTURE", fxMan.ditherTexture);
		}
		Shader.SetGlobalVector("_WORLDWIGGLE", fxData.worldWiggle);
		Shader.SetGlobalVector("_WORLDWARP", fxData.worldWarp);
		Vector4 value = new Vector4(fxData.fog.r, fxData.fog.g, fxData.fog.b, fxData.fogMultiplier);
		if (showFog)
		{
			Shader.SetGlobalVector("_FOG", value);
			Shader.SetGlobalFloat("_FOGMULT", fxData.fogMultiplier);
			Shader.SetGlobalFloat("_FOGTONEDIST", fxData.fogTwoToneDist);
			Shader.SetGlobalFloat("_FOGTONEOFFSET", fxData.fogTwoToneOffset);
			Shader.SetGlobalColor("_FOGCOLORTOP", Color.Lerp(fxData.fog, fxData.fogTop, fxData.fogTwoToneBlend));
			Shader.SetGlobalColor("_FOGCOLORBOTTOM", fxData.fog);
		}
		else
		{
			Shader.SetGlobalVector("_FOG", Vector4.zero);
			Shader.SetGlobalFloat("_FOGMULT", 0f);
		}
		if (fullBright)
		{
			Shader.SetGlobalFloat("_WORLDBRIGHT", 2f);
			Shader.SetGlobalFloat("_ENTITYBRIGHT", 1f);
			Shader.SetGlobalInt("_DITHERMINIMUM", 100);
			Shader.SetGlobalFloat("_FULLBRIGHT", 1f);
		}
		else
		{
			Shader.SetGlobalFloat("_WORLDBRIGHT", fxData.worldBright);
			Shader.SetGlobalFloat("_ENTITYBRIGHT", fxData.entityBright);
			Shader.SetGlobalInt("_DITHERMINIMUM", fxData.ditherMinimum);
			Shader.SetGlobalFloat("_LIGHTOFFSET", fxData.lightOffset);
			Shader.SetGlobalFloat("_FULLBRIGHT", 0f);
		}
		Shader.SetGlobalFloat("_NOTEXTURE", noTexture ? 1 : 0);
		Shader.SetGlobalFloat("_NOFOG", noFog ? 1 : 0);
		Shader.SetGlobalVector("_BRIGHTCOL", fxData.brightCol);
		Shader.SetGlobalVector("_HSV", fxData.hsv);
		Shader.SetGlobalVector("_NOISE", fxData.noise);
		Shader.SetGlobalVector("_SCREENWARP", fxData.screenWarp);
		Shader.SetGlobalFloat("_INVERT", fxData.invert);
		Shader.SetGlobalFloat("_OFFSET", fxData.offset);
		Shader.SetGlobalFloat("_SCREENRADIALBLUR", fxData.screenRadialBlur);
		Shader.SetGlobalVector("_WORLDMIN", fxData.minCol);
		Shader.SetGlobalVector("_WORLDTINT", fxData.worldTint);
		if (Application.isPlaying)
		{
			if (SettingsManager.settings != null)
			{
				Shader.SetGlobalFloat("_GAMMA", (float)SettingsManager.settings.brightness + fxData.gamma);
			}
		}
		else
		{
			Shader.SetGlobalFloat("_GAMMA", 1f + fxData.gamma);
		}
		FX_PlayerDust.SetDustAmount(fxData.dustMult);
		FX_PlayerDust.SetDustColor(fxData.dustColor);
		FX_PlayerDust.SetDustWind(fxData.dustWind, fxData.dustNoise);
	}

	public void UpdateLamp(CL_Lamp z)
	{
		if (!lightHash.Contains(z))
		{
			AddLamp(z);
		}
	}

	public void AddLamp(CL_Lamp z)
	{
		if (!lightHash.Contains(z))
		{
			lights.Add(z);
			lightHash.Add(z);
		}
	}

	public void DeleteLamp(CL_Lamp z)
	{
		if (lightHash.Contains(z))
		{
			lights.Remove(z);
			lightHash.Remove(z);
		}
	}

	public void MoveLampToFrontOfQueue(CL_Lamp z)
	{
		if (lights.Contains(z) && lights.IndexOf(z) != 0)
		{
			lights.Remove(z);
			lights.Insert(0, z);
		}
	}

	private int partition(List<CL_Lamp> arr, int low, int high)
	{
		if (high >= arr.Count)
		{
			return high;
		}
		CL_Lamp cL_Lamp = arr[high];
		int num = low - 1;
		for (int i = low; i < high; i++)
		{
			if (Application.isPlaying && gMan != null && gMan.PlayerDistance(arr[i].transform.position) < gMan.PlayerDistance(cL_Lamp.transform.position))
			{
				num++;
				CL_Lamp value = arr[num];
				arr[num] = arr[i];
				arr[i] = value;
			}
		}
		CL_Lamp value2 = arr[num + 1];
		arr[num + 1] = arr[high];
		arr[high] = value2;
		return num + 1;
	}

	private IEnumerator QuickSortLoop()
	{
		while (true)
		{
			if (lights.Count > 1000)
			{
				yield return new WaitForEndOfFrame();
			}
			else
			{
				yield return QuickSortByDistance(lights, 0, lights.Count - 1);
			}
		}
	}

	private IEnumerator QuickSortByDistance(List<CL_Lamp> arr, int low, int high)
	{
		if (low < high)
		{
			int pi = partition(arr, low, high);
			yield return new WaitForEndOfFrame();
			yield return QuickSortByDistance(arr, low, pi - 1);
			yield return QuickSortByDistance(arr, pi + 1, high);
		}
	}

	public static FXData BlendFXData(FXData d1, FXData d2, float blend)
	{
		if (d1 == null || d2 == null)
		{
			return null;
		}
		FXData fXData = new FXData();
		if (d2.affectGeneral)
		{
			fXData.ditherLevels = Mathf.Lerp(d1.ditherLevels, d2.ditherLevels, blend);
			fXData.ditherMinimum = (int)Mathf.Lerp(d1.ditherMinimum, d2.ditherMinimum, blend);
			fXData.roundVerts = (int)Mathf.Lerp(d1.roundVerts, d2.roundVerts, blend);
			fXData.worldWiggle = Vector3.Lerp(d1.worldWiggle, d2.worldWiggle, blend);
			fXData.worldWarp = Vector4.Lerp(d1.worldWarp, d2.worldWarp, blend);
			fXData.affectGeneral = true;
		}
		else if (d1.affectGeneral)
		{
			fXData.ditherLevels = d1.ditherLevels;
			fXData.ditherMinimum = d1.ditherMinimum;
			fXData.roundVerts = d1.roundVerts;
			fXData.worldWiggle = d1.worldWiggle;
			fXData.worldWarp = d1.worldWarp;
			fXData.affectGeneral = true;
		}
		if (d2.affectLighting)
		{
			fXData.worldBright = Mathf.Lerp(d1.worldBright, d2.worldBright, blend);
			fXData.brightCol = Color.Lerp(d1.brightCol, d2.brightCol, blend);
			fXData.entityBright = Mathf.Lerp(d1.entityBright, d2.entityBright, blend);
			fXData.lightOffset = Mathf.Lerp(d1.lightOffset, d2.lightOffset, blend);
			fXData.lightmapMult = Mathf.Lerp(d1.lightmapMult, d2.lightmapMult, blend);
			fXData.affectLighting = true;
		}
		else if (d1.affectLighting)
		{
			fXData.worldBright = d1.worldBright;
			fXData.brightCol = d1.brightCol;
			fXData.entityBright = d1.entityBright;
			fXData.lightOffset = d1.lightOffset;
			fXData.lightmapMult = d1.lightmapMult;
			fXData.affectLighting = true;
		}
		if (d2.affectColor)
		{
			fXData.minCol = Color.Lerp(d1.minCol, d2.minCol, blend);
			fXData.worldTint = Color.Lerp(d1.worldTint, d2.worldTint, blend);
			fXData.gamma = Mathf.Lerp(d1.gamma, d2.gamma, blend);
			fXData.offset = Mathf.Lerp(d1.offset, d2.offset, blend);
			fXData.affectColor = true;
			fXData.invert = Mathf.Lerp(d1.invert, d2.invert, blend);
		}
		else if (d1.affectColor)
		{
			fXData.minCol = d1.minCol;
			fXData.worldTint = d1.worldTint;
			fXData.gamma = d1.gamma;
			fXData.offset = d1.offset;
			fXData.affectColor = true;
			fXData.invert = d1.invert;
		}
		if (d2.affectFog)
		{
			fXData.fog = Color.Lerp(d1.fog, d2.fog, blend);
			fXData.fogTop = Color.Lerp(d1.fogTop, d2.fogTop, blend);
			fXData.fogTwoToneBlend = Mathf.Lerp(d1.fogTwoToneBlend, d2.fogTwoToneBlend, blend);
			fXData.fogTwoToneDist = Mathf.Lerp(d1.fogTwoToneDist, d2.fogTwoToneDist, blend);
			fXData.fogTwoToneOffset = Mathf.Lerp(d1.fogTwoToneOffset, d2.fogTwoToneOffset, blend);
			fXData.fogMultiplier = Mathf.Lerp(d1.fogMultiplier, d2.fogMultiplier, blend);
			fXData.fogDitherAmount = Mathf.Lerp(d1.fogDitherAmount, d2.fogDitherAmount, blend);
			fXData.fogDitherLevels = (int)Mathf.Lerp(d1.fogDitherLevels, d2.fogDitherLevels, blend);
			fXData.affectFog = true;
		}
		else if (d1.affectFog)
		{
			fXData.fog = d1.fog;
			fXData.fogTop = d1.fogTop;
			fXData.fogTwoToneBlend = d1.fogTwoToneBlend;
			fXData.fogTwoToneDist = d1.fogTwoToneDist;
			fXData.fogTwoToneOffset = d1.fogTwoToneOffset;
			fXData.fogMultiplier = d1.fogMultiplier;
			fXData.fogDitherAmount = d1.fogDitherAmount;
			fXData.fogDitherLevels = d1.fogDitherLevels;
			fXData.affectFog = true;
		}
		if (d2.affectHSV)
		{
			fXData.hsv = Vector3.Lerp(d1.hsv, d2.hsv, blend);
			fXData.affectHSV = true;
		}
		else if (d1.affectHSV)
		{
			fXData.hsv = d1.hsv;
			fXData.affectHSV = true;
		}
		if (d2.affectNoise)
		{
			fXData.noise = Vector2.Lerp(d1.noise, d2.noise, blend);
			fXData.affectNoise = true;
		}
		else if (d1.affectNoise)
		{
			fXData.noise = d1.noise;
			fXData.affectNoise = true;
		}
		if (d2.affectScreenWarp)
		{
			fXData.screenWarp = Vector4.Lerp(d1.screenWarp, d2.screenWarp, blend);
			fXData.affectScreenWarp = true;
			fXData.screenRadialBlur = Mathf.Lerp(d1.screenRadialBlur, d2.screenRadialBlur, blend);
		}
		else if (d1.affectScreenWarp)
		{
			fXData.screenWarp = d1.screenWarp;
			fXData.affectScreenWarp = true;
			fXData.screenRadialBlur = d1.screenRadialBlur;
		}
		if (d2.affectDust)
		{
			fXData.dustMult = Mathf.Lerp(d1.dustMult, d2.dustMult, blend);
			fXData.dustColor = Color.Lerp(d1.dustColor, d2.dustColor, blend);
			fXData.dustWind = Vector3.Lerp(d1.dustWind, d2.dustWind, blend);
			fXData.dustNoise = Mathf.Lerp(d1.dustNoise, d2.dustNoise, blend);
			fXData.affectDust = true;
		}
		else if (d1.affectDust)
		{
			fXData.dustMult = d1.dustMult;
			fXData.dustColor = d1.dustColor;
			fXData.dustWind = d1.dustWind;
			fXData.dustNoise = d1.dustNoise;
			fXData.affectDust = true;
		}
		return fXData;
	}

	public static void Fullbright(string[] args)
	{
		if (args.Length == 0)
		{
			fullBright = !fullBright;
		}
		else
		{
			if (!bool.TryParse(args[0], out var _))
			{
				CommandConsole.Log("Unable to parse " + args[0] + " arg needs to be a boolean (true/false/0/1).");
				return;
			}
			fullBright = Convert.ToBoolean(args[0]);
		}
		CommandConsole.Log("Fullbright set to " + fullBright);
		showFog = !fullBright;
	}

	public static Material GetSharedHandholdMaterial(Material m, ColorSetting.ColorType handholdColorType = ColorSetting.ColorType.red)
	{
		if (handholdMaterialDict == null)
		{
			handholdMaterialDict = new Dictionary<string, HandholdOverrideMaterial>();
			handholdMaterials = new List<HandholdOverrideMaterial>();
		}
		string text = $"{m.name}:{handholdColorType}";
		if (handholdMaterialDict.ContainsKey(text))
		{
			return handholdMaterialDict[text].material;
		}
		Material material = new Material(m);
		material.name = text;
		HandholdOverrideMaterial handholdOverrideMaterial = new HandholdOverrideMaterial
		{
			material = material,
			id = text,
			handholdColorType = handholdColorType,
			originalMaterial = m
		};
		handholdMaterialDict.Add(text, handholdOverrideMaterial);
		handholdMaterials.Add(handholdOverrideMaterial);
		UpdateHandholdMaterialSettings();
		UnityEngine.Debug.Log("Added new Handhold Material - " + text + " -- " + m.shader.name);
		return handholdMaterialDict[text].material;
	}

	public static void UpdateHandholdMaterialSettings()
	{
		if (handholdMaterials == null)
		{
			return;
		}
		foreach (HandholdOverrideMaterial handholdMaterial in handholdMaterials)
		{
			if (!handholdMaterialDict.ContainsKey(handholdMaterial.id) || handholdMaterial.material.shader.name != "Dark Machine/SHDR_Base")
			{
				continue;
			}
			ColorSetting currentColorSetting = SettingsManager.GetCurrentColorSetting();
			Material originalMaterial = handholdMaterial.originalMaterial;
			float num = originalMaterial.GetFloat("_EmissionMultiplier");
			float num2 = originalMaterial.GetFloat("_Shimmer");
			float value = originalMaterial.GetFloat("_ShimmerOver");
			float value2 = originalMaterial.GetFloat("_ShimmerOffset");
			float value3 = originalMaterial.GetFloat("_ShimmerSpeed");
			float value4 = originalMaterial.GetFloat("_ShimmerFrequency");
			Color color = originalMaterial.GetColor("_ShimmerColor");
			if (SettingsManager.settings.handholdHighVis)
			{
				if (num > 0f)
				{
					float value5 = Mathf.Clamp(num * 4f, 1f, 8f);
					handholdMaterial.material.SetFloat("_EmissionMultiplier", value5);
				}
				else
				{
					handholdMaterial.material.SetFloat("_EmissionMultiplier", 0.25f);
				}
			}
			else
			{
				handholdMaterial.material.SetFloat("_EmissionMultiplier", num);
			}
			if (SettingsManager.settings.extraHandholdShimmer)
			{
				handholdMaterial.material.SetFloat("_ShimmerOver", 3f);
				handholdMaterial.material.SetFloat("_Shimmer", Mathf.Min(num2 + 0.2f, 1f));
				handholdMaterial.material.SetColor("_ShimmerColor", Color.Lerp(color, new Color(1f, 1f, 1f) * currentColorSetting.GetColor(handholdMaterial.handholdColorType) * 0.8f, 0.9f));
				handholdMaterial.material.SetFloat("_ShimmerOffset", 0f);
				handholdMaterial.material.SetFloat("_ShimmerTextureMix", 0.95f);
			}
			else
			{
				handholdMaterial.material.SetFloat("_ShimmerOver", value);
				handholdMaterial.material.SetFloat("_Shimmer", num2);
				handholdMaterial.material.SetColor("_ShimmerColor", color);
				handholdMaterial.material.SetFloat("_ShimmerOffset", value2);
				handholdMaterial.material.SetFloat("_ShimmerTextureMix", 1f);
			}
			if (SettingsManager.settings.extraHandholdShimmer && SettingsManager.settings.freezeHandholdShimmer)
			{
				handholdMaterial.material.SetFloat("_ShimmerSpeed", 0f);
				handholdMaterial.material.SetFloat("_ShimmerFrequency", 0f);
				handholdMaterial.material.SetFloat("_ShimmerOffset", 1f);
			}
			else
			{
				handholdMaterial.material.SetFloat("_ShimmerSpeed", value3);
				handholdMaterial.material.SetFloat("_ShimmerFrequency", value4);
			}
		}
	}

	private void FXDecals(Camera camera)
	{
		bool flag = false;
		Vector3 vector = Vector3.zero;
		Vector2 vector2 = Vector2.zero;
		if (camera != null)
		{
			vector = camera.transform.position;
			vector2 = new Vector2(camera.pixelWidth, camera.pixelHeight);
		}
		List<int> list = decalsSubmittingPrioritiesCached;
		List<(DecalInfo, Matrix4x4)> list2 = decalsSubmittingQueueCached;
		_ = Time.time;
		float deltaTime = Time.deltaTime;
		int num = 0;
		int num2 = 128;
		if (decalJobFrustrumSearch.positionsAndRadius.Length == 0)
		{
			decalJobFrustrumSearch = new DecalJobFrustrumSearch
			{
				positionsAndRadius = new NativeArray<Vector4>(256, Allocator.Persistent),
				outCount = new NativeArray<CacheAlignedInt>(num2, Allocator.Persistent),
				outIndexes = new NativeArray<NativeArray<int>>(num2, Allocator.Persistent),
				outMin = new NativeArray<NativeArray<Vector3Int>>(num2, Allocator.Persistent),
				outMax = new NativeArray<NativeArray<Vector3Int>>(num2, Allocator.Persistent)
			};
			for (int i = 0; i < num2; i++)
			{
				decalJobFrustrumSearch.outIndexes[i] = new NativeArray<int>(256, Allocator.Persistent);
				decalJobFrustrumSearch.outMin[i] = new NativeArray<Vector3Int>(256, Allocator.Persistent);
				decalJobFrustrumSearch.outMax[i] = new NativeArray<Vector3Int>(256, Allocator.Persistent);
			}
		}
		decalJobFrustrumSearch.sphereInfo = forwardPlusSphereInfo;
		long timestamp = Stopwatch.GetTimestamp();
		list.Clear();
		list.Add(24);
		list.Add(232);
		list2.Clear();
		foreach (List<byte> value5 in decalBucketToDecals.Values)
		{
			value5.Clear();
			decalBucketToDecalsPool.Add(value5);
		}
		decalBucketToDecals.Clear();
		long timestamp2 = Stopwatch.GetTimestamp();
		int num3 = Mathf.Clamp((int)(256f * decalMultLast), 0, 256);
		for (int j = 0; j < decalGenArray.Count; j++)
		{
			DecalInfo decalInfo = decalGenArray[j];
			if (list2.Count == num3)
			{
				break;
			}
			num++;
			if ((decalInfo.generation & 1) == 0)
			{
				continue;
			}
			decalInfo.timeout -= deltaTime;
			if (float.IsFinite(decalInfo.timeout) && decalInfo.timeout <= 0f)
			{
				DecalDestroy(new DecalHandle
				{
					index = j,
					generation = decalInfo.generation
				});
				continue;
			}
			if ((object)decalInfo.parent != null && (decalInfo.parent == null || (decalInfo.priority == DecalPriority.Low && !decalInfo.parent.gameObject.activeInHierarchy)))
			{
				DecalDestroy(new DecalHandle
				{
					index = j,
					generation = decalInfo.generation
				});
				continue;
			}
			int priority = (int)decalInfo.priority;
			if (list[priority] == 0)
			{
				continue;
			}
			Matrix4x4 matrix4x = decalInfo.offset;
			if (decalInfo.parent != null)
			{
				matrix4x = decalInfo.parent.localToWorldMatrix * matrix4x;
			}
			Vector3 position = matrix4x.GetPosition();
			Vector3 lhs = matrix4x.GetColumn(2);
			Vector3 normalized = (vector - position).normalized;
			float num4 = Vector3.Dot(lhs, normalized);
			if (decalBackCull && num4 < 0f)
			{
				continue;
			}
			float num5 = 1f;
			int num6 = -1;
			for (int k = 0; k < decalInfo.scalePath.Length; k++)
			{
				if (decalInfo.scalePathTime < decalInfo.scalePath[k].time)
				{
					num6 = k;
					break;
				}
			}
			if (num6 != -1)
			{
				(float, float) tuple = ((num6 > 0) ? decalInfo.scalePath[num6 - 1] : (0f, 0f));
				(float, float) tuple2 = decalInfo.scalePath[num6];
				float t = (decalInfo.scalePathTime - tuple.Item2) / (tuple2.Item2 - tuple.Item2);
				num5 *= Mathf.Lerp(tuple.Item1, tuple2.Item1, t);
			}
			if (num6 == -1 && decalInfo.scalePath.Length != 0)
			{
				num5 *= decalInfo.scalePath[^1].scale;
			}
			decalInfo.scalePathTime += deltaTime / decalInfo.scaleSpeedMult;
			for (int l = 0; l < 3; l++)
			{
				for (int m = 0; m < 3; m++)
				{
					matrix4x[l, m] *= num5;
				}
			}
			if (!flag && !IsSphereInFrustrum(frustrumPlanesCachedArray, position, decalInfo.boundingSphereRadius))
			{
				continue;
			}
			list[priority]--;
			if (list[priority] == 0)
			{
				bool flag2 = true;
				foreach (int item3 in list)
				{
					flag2 = flag2 && item3 == 0;
				}
				if (flag2)
				{
					break;
				}
			}
			Vector3 lossyScale = matrix4x.lossyScale;
			float num7 = Mathf.Max(lossyScale.x, lossyScale.y, lossyScale.z);
			decalJobFrustrumSearch.positionsAndRadius[list2.Count] = new Vector4(position.x, position.y, position.z, decalInfo.boundingSphereRadius * num7);
			list2.Add((decalInfo, matrix4x));
		}
		for (int n = 0; n < decalJobFrustrumSearch.outCount.Length; n++)
		{
			decalJobFrustrumSearch.outCount[n] = default(CacheAlignedInt);
		}
		JobHandle jobHandle = default(JobHandle);
		if (list2.Count > 32)
		{
			jobHandle = IJobParallelForExtensions.Schedule(decalJobFrustrumSearch, list2.Count, list2.Count / 32);
			JobHandle.ScheduleBatchedJobs();
		}
		else
		{
			decalJobFrustrumSearch.threadIndex = 0;
			for (int num8 = 0; num8 < list2.Count; num8++)
			{
				decalJobFrustrumSearch.Execute(num8);
			}
		}
		long timestamp3 = Stopwatch.GetTimestamp();
		int height = DecalAtlas().height;
		for (int num9 = 0; num9 < list2.Count; num9++)
		{
			var (decalInfo2, matrix) = list2[num9];
			if (decalShowBox && (decalRenderSpecific == -1 || decalRenderSpecific == num9))
			{
				Color color = DarkMachineCrayons.crayons[num9 % DarkMachineCrayons.crayons.Length];
				CL_DebugView.draw.PushColor(color);
				CL_DebugView.draw.PushMatrix(matrix);
				CL_DebugView.draw.WireBox(Vector3.zero, decalInfo2.halfExtents * 2f);
				CL_DebugView.draw.WireSphere(Vector3.zero, decalInfo2.boundingSphereRadius);
				(Vector3Int min, Vector3Int max) tuple4 = ForwardPlusSphere(in forwardPlusSphereInfo, matrix.GetPosition(), decalInfo2.boundingSphereRadius);
				Vector3Int item = tuple4.min;
				Vector3Int item2 = tuple4.max;
				string text = "N/A";
				if (decalInfo2.parent != null)
				{
					text = DarkMachineFunctions.GameObjectFullPath(decalInfo2.parent.gameObject);
				}
				CL_DebugView.draw.Label2D(Vector3.zero, $"{num9}: {decalInfo2.ident}\n{item} -> {item2}\nParent: {text}");
				CL_DebugView.draw.Arrow(Vector3.zero, new Vector3(0f, 0f, 1f));
				CL_DebugView.draw.PopMatrix();
				if (decalInfo2.punchThroughDirectionLocal.magnitude > 0f)
				{
					CL_DebugView.draw.Arrow(matrix.GetPosition(), matrix.GetPosition() + decalInfo2.punchThroughDirectionLocal);
				}
				CL_DebugView.draw.PopColor();
			}
			decalGpuDefinitionStaging[num9].inverseMatrix = matrix.inverse;
			decalGpuDefinitionStaging[num9].forward = matrix.GetColumn(2);
			int num10 = (int)decalInfo2.renderMode;
			if (decalInfo2.renderMode == DecalRenderMode.Punchthrough)
			{
				Vector3 punchThroughDirectionLocal = decalInfo2.punchThroughDirectionLocal;
				punchThroughDirectionLocal = matrix.MultiplyVector(punchThroughDirectionLocal).normalized;
				int num11 = Mathf.CeilToInt(punchThroughDirectionLocal.x * 512f);
				int num12 = Mathf.CeilToInt(punchThroughDirectionLocal.y * 512f);
				int num13 = Mathf.CeilToInt(punchThroughDirectionLocal.z * 512f);
				num10 |= (num11 & 0x3FF) << 22;
				num10 |= (num12 & 0x3FF) << 12;
				num10 |= (num13 & 0x3FF) << 2;
			}
			decalGpuDefinitionStaging[num9].forward.w = BitConverter.Int32BitsToSingle(num10);
			decalGpuDefinitionStaging[num9].halfExtents = decalInfo2.halfExtents;
			if (decalInfo2.renderMode == DecalRenderMode.Punchthrough)
			{
				int value = DarkMachineCrayons.ColorToHex(decalInfo2.punchThroughColor);
				decalGpuDefinitionStaging[num9].halfExtents.w = BitConverter.Int32BitsToSingle(value);
			}
			int num14 = decalInfo2.uvTopLeft.x << 16;
			num14 |= height - decalInfo2.uvTopLeft.y;
			decalGpuDefinitionStaging[num9].uv.x = BitConverter.Int32BitsToSingle(num14);
			int num15 = decalInfo2.uvBottomRight.x << 16;
			num15 |= height - decalInfo2.uvBottomRight.y;
			decalGpuDefinitionStaging[num9].uv.y = BitConverter.Int32BitsToSingle(num15);
			decalGpuDefinitionStaging[num9].uv.z = decalInfo2.punchThroughDistance;
			Color modulate = decalInfo2.modulate;
			if (decalInfo2.gradient != null && float.IsFinite(decalInfo2.gradientPos))
			{
				float num16 = Mathf.Max(decalInfo2.gradientPos, 0f) / decalInfo2.gradientDuration;
				if (decalInfo2.gradientWrap == DecalWrapBehavior.Saturate)
				{
					num16 = Mathf.Min(1f, num16);
				}
				if (decalInfo2.gradientWrap == DecalWrapBehavior.Wrap)
				{
					num16 %= 1f;
				}
				if (decalInfo2.gradientWrap == DecalWrapBehavior.RoundRobin)
				{
					num16 %= 2f;
					if (num16 > 1f)
					{
						num16 = 2f - num16;
					}
				}
				Color color2 = decalInfo2.gradient.Evaluate(num16);
				modulate *= color2;
			}
			decalInfo2.gradientPos += deltaTime;
			decalGpuDefinitionStaging[num9].modulate = modulate;
		}
		if (decalGpuDefinition != null)
		{
			decalGpuDefinition.SetData(decalGpuDefinitionStaging, 0, 0, list2.Count);
			Shader.SetGlobalBuffer("_DECALS", decalGpuDefinition);
		}
		long timestamp4 = Stopwatch.GetTimestamp();
		jobHandle.Complete();
		for (int num17 = 0; num17 < num2; num17++)
		{
			int value2 = decalJobFrustrumSearch.outCount[num17].value;
			NativeArray<int> nativeArray = decalJobFrustrumSearch.outIndexes[num17];
			NativeArray<Vector3Int> nativeArray2 = decalJobFrustrumSearch.outMin[num17];
			NativeArray<Vector3Int> nativeArray3 = decalJobFrustrumSearch.outMax[num17];
			for (int num18 = 0; num18 < value2; num18++)
			{
				int num19 = nativeArray[num18];
				Vector3Int vector3Int = nativeArray2[num18];
				Vector3Int vector3Int2 = nativeArray3[num18];
				for (int num20 = vector3Int.x; num20 < vector3Int2.x; num20++)
				{
					for (int num21 = vector3Int.y; num21 < vector3Int2.y; num21++)
					{
						for (int num22 = vector3Int.z; num22 < vector3Int2.z; num22++)
						{
							if (!decalBucketToDecals.TryGetValue(new Vector3Int(num20, num21, num22), out var value3))
							{
								if (decalBucketToDecalsPool.Count > 0)
								{
									List<List<byte>> list3 = decalBucketToDecalsPool;
									value3 = list3[list3.Count - 1];
									decalBucketToDecalsPool.RemoveAt(decalBucketToDecalsPool.Count - 1);
								}
								else
								{
									value3 = new List<byte>();
								}
								decalBucketToDecals.Add(new Vector3Int(num20, num21, num22), value3);
							}
							value3.Add((byte)num19);
						}
					}
				}
			}
		}
		int num23 = 0;
		Array.Fill(decalGpuIndirectionStaging, 0);
		if (!decalNoUpload)
		{
			byte[] array = decalGpuArraysStaging;
			int[] array2 = decalGpuIndirectionStaging;
			int num24 = 1;
			foreach (KeyValuePair<Vector3Int, List<byte>> decalBucketToDecal in decalBucketToDecals)
			{
				decalBucketToDecal.Deconstruct(out var key, out var value4);
				Vector3Int vector3Int3 = key;
				List<byte> list4 = value4;
				int num25 = vector3Int3.x + vector3Int3.y * 16 + vector3Int3.z * 16 * 8;
				array2[num25] = num24;
				array[num24] = (byte)(list4.Count - 1);
				for (int num26 = 0; num26 < list4.Count; num26++)
				{
					array[num24 + 1 + num26] = list4[num26];
				}
				num24 += list4.Count + 1;
			}
			num23 = num24 - 1;
		}
		long timestamp5 = Stopwatch.GetTimestamp();
		if (decalGridDepth >= 0 && decalGridDepth < 11)
		{
			using (CL_DebugView.draw.InScreenSpace(camera))
			{
				for (int num27 = 0; num27 <= 16; num27++)
				{
					CL_DebugView.draw.xy.Line(new Vector3(vector2.x * (float)num27 / 16f, 0f, 0f), new Vector3(vector2.x * (float)num27 / 16f, vector2.y, 0f));
				}
				for (int num28 = 0; num28 <= 8; num28++)
				{
					CL_DebugView.draw.xy.Line(new Vector3(0f, vector2.y * (float)num28 / 8f, 0f), new Vector3(vector2.x, vector2.y * (float)num28 / 8f, 0f));
				}
				byte[] array3 = decalGpuArraysStaging;
				int[] array4 = decalGpuIndirectionStaging;
				for (int num29 = 0; num29 < 16; num29++)
				{
					for (int num30 = 0; num30 < 8; num30++)
					{
						Vector3 vector3 = new Vector3(vector2.x * (float)num29 / 16f, 16f + vector2.y * (float)num30 / 8f, 0f);
						int num31 = num29 + (7 - num30) * 16 + decalGridDepth * 16 * 8;
						int num32 = array4[num31];
						int num33 = 0;
						if (num32 != 0)
						{
							num33 = array3[num32] + 1;
						}
						CL_DebugView.draw.xy.Label2D(vector3, $"({num29}, {7 - num30})\n{num33}");
					}
				}
			}
		}
		if (!decalForwardPlus || flag)
		{
			Array.Fill(decalGpuIndirectionStaging, (list2.Count > 0) ? 1 : 0);
			byte[] array5 = decalGpuArraysStaging;
			array5[1] = (byte)(list2.Count - 1);
			for (int num34 = 0; num34 < list2.Count; num34++)
			{
				array5[2 + num34] = (byte)num34;
			}
		}
		if (decalGpuArrays != null)
		{
			decalGpuArrays.SetData(decalGpuArraysStaging, 0, 0, num23 * 4);
			Shader.SetGlobalBuffer("_DECAL_LIST", decalGpuArrays);
		}
		Shader.SetGlobalInt("_DECAL_COUNT", list2.Count);
		Shader.SetGlobalInt("_DECAL_SHOWCOUNTS", decalShowCounts);
		Shader.SetGlobalInt("_DECAL_RENDER_SPECIFIC", decalRenderSpecific);
		if (decalGpuIndirection != null)
		{
			decalGpuIndirection.SetData(decalGpuIndirectionStaging);
			Shader.SetGlobalBuffer("_DECAL_LIST_INDIRECTION", decalGpuIndirection);
		}
		long timestamp6 = Stopwatch.GetTimestamp();
		DebugMenu.UpdateDebugText("Decals submitted", $"Submitted decals count: {list2.Count}/{num} ({decalGenArray.Count} total, {num23}/{361856} slots, {decalBucketToDecals.Count} unique) - clean: {new TimeSpan(timestamp2 - timestamp).TotalMilliseconds}ms, search: {new TimeSpan(timestamp3 - timestamp2).TotalMilliseconds}ms, def copy: {new TimeSpan(timestamp4 - timestamp3).TotalMilliseconds}ms, lookup create: {new TimeSpan(timestamp5 - timestamp4).TotalMilliseconds}ms, upload: {new TimeSpan(timestamp6 - timestamp5).TotalMilliseconds}ms");
	}

	public static DecalHandle DecalCreate(DecalPriority priority)
	{
		DecalHandle result = default(DecalHandle);
		DecalInfo decalInfo = null;
		if (decalInfo == null && decalNextFree >= decalGenArray.Count)
		{
			decalInfo = new DecalInfo
			{
				generation = 1
			};
			result.index = decalGenArray.Count;
			result.generation = 1;
			decalGenArray.Add(decalInfo);
			decalNextFree = decalGenArray.Count;
		}
		if (decalInfo == null)
		{
			decalInfo = decalGenArray[decalNextFree];
			decalInfo.generation++;
			result.index = decalNextFree;
			result.generation = decalInfo.generation;
			decalNextFree = decalInfo.nextFree;
		}
		if (decalInfo != null)
		{
			decalInfo.priority = priority;
			decalInfo.renderMode = DecalRenderMode.Normal;
			decalInfo.punchThroughDirectionLocal = Vector3.zero;
			decalInfo.punchThroughColor = Color.black;
			decalInfo.punchThroughDistance = 0f;
			decalInfo.parent = null;
			decalInfo.ident = null;
			decalInfo.startTime = Time.time;
			decalInfo.timeout = float.PositiveInfinity;
			decalInfo.offset = Matrix4x4.identity;
			decalInfo.halfExtents = Vector3.zero;
			decalInfo.boundingSphereRadius = 0f;
			decalInfo.uvTopLeft = Vector2Int.zero;
			decalInfo.uvBottomRight = Vector2Int.zero;
			decalInfo.modulate = Color.white;
			decalInfo.gradient = null;
			decalInfo.gradientDuration = 1f;
			decalInfo.gradientPos = float.PositiveInfinity;
			decalInfo.gradientWrap = DecalWrapBehavior.Saturate;
			decalInfo.scalePath = Array.Empty<(float, float)>();
			decalInfo.scalePathTime = 0f;
			decalInfo.sharedTags = null;
		}
		return result;
	}

	public static void DecalDestroy(DecalHandle handle)
	{
		DecalInfo decalInfo = DecalInfoFromHandle(handle);
		if (decalInfo != null)
		{
			decalInfo.generation++;
			decalInfo.nextFree = decalNextFree;
			decalNextFree = handle.index;
		}
	}

	public static void DecalTag(DecalHandle handle, string tagName)
	{
		DecalTagHolder valueOrDefault = decalTags.GetValueOrDefault(tagName);
		if (valueOrDefault == null)
		{
			UnityEngine.Debug.LogWarning("No decal category " + tagName + " found registered in FX manager!");
		}
		bool flag = DecalExists(handle) && decalRespectTagLimit;
		flag &= Application.isPlaying;
		float decalMult = SettingsManager.settings.decalMult;
		int num = Mathf.FloorToInt((float)valueOrDefault.mainCull * decalMult);
		int num2 = Mathf.FloorToInt((float)valueOrDefault.softCull * decalMult);
		DecalHandle decalHandle = default(DecalHandle);
		if (flag && valueOrDefault != null && valueOrDefault.handles.Count < num)
		{
			valueOrDefault.handles.Add(handle);
			flag = false;
		}
		if (flag && valueOrDefault != null)
		{
			for (int i = 0; i < valueOrDefault.handles.Count; i++)
			{
				if (!DecalExists(valueOrDefault.handles[i]))
				{
					valueOrDefault.handles.RemoveAt(i);
					valueOrDefault.handles.Add(handle);
					flag = false;
					break;
				}
			}
		}
		if (flag && valueOrDefault != null && valueOrDefault.handles.Count > 0)
		{
			decalHandle = valueOrDefault.handles[0];
			valueOrDefault.handles.RemoveAt(0);
			valueOrDefault.handles.Add(handle);
			flag = false;
		}
		if (flag)
		{
			DecalDestroy(handle);
		}
		if (valueOrDefault != null && num2 > 0 && DecalExists(decalHandle))
		{
			if (decalGenArray[decalHandle.index].renderMode == DecalRenderMode.Punchthrough)
			{
				DecalScaleEffect(decalHandle, decalPunchFadeout, valueOrDefault.softFadeout);
				DecalTimeout(decalHandle, valueOrDefault.softFadeout);
			}
			else
			{
				DecalFadeout(decalHandle, valueOrDefault.softFadeout);
			}
			bool flag2 = true;
			if (valueOrDefault.softHandles.Count < num2)
			{
				flag2 = false;
			}
			int num3 = 0;
			while (flag2 && num3 < valueOrDefault.softHandles.Count)
			{
				if (!DecalExists(valueOrDefault.softHandles[num3]))
				{
					valueOrDefault.softHandles.RemoveAt(num3);
				}
				num3++;
			}
			if (flag2)
			{
				DecalDestroy(valueOrDefault.softHandles[0]);
				valueOrDefault.softHandles.RemoveAt(0);
			}
			valueOrDefault.softHandles.Add(decalHandle);
			decalHandle = default(DecalHandle);
		}
		DecalDestroy(decalHandle);
	}

	public static void DecalUv(DecalHandle handle, Vector2Int tl, Vector2Int br)
	{
		DecalInfo decalInfo = DecalInfoFromHandle(handle);
		if (decalInfo != null)
		{
			decalInfo.uvTopLeft = tl;
			decalInfo.uvBottomRight = br;
		}
	}

	public static void DecalColor(DecalHandle handle, Color color)
	{
		DecalInfo decalInfo = DecalInfoFromHandle(handle);
		if (decalInfo != null)
		{
			decalInfo.modulate = color;
		}
	}

	public static void DecalGradient(DecalHandle handle, Gradient gradient, float duration, float startTime = 0f, DecalWrapBehavior wrapBehaviour = DecalWrapBehavior.Saturate)
	{
		DecalInfo decalInfo = DecalInfoFromHandle(handle);
		if (decalInfo != null)
		{
			decalInfo.gradient = gradient;
			decalInfo.gradientDuration = duration;
			decalInfo.gradientWrap = wrapBehaviour;
			decalInfo.gradientPos = 0f - startTime;
		}
	}

	public static void DecalScaleEffect(DecalHandle handle, (float scale, float time)[] scaleInterp, float scaleSpeedMult = 1f)
	{
		DecalInfo decalInfo = DecalInfoFromHandle(handle);
		if (decalInfo != null)
		{
			decalInfo.scalePath = scaleInterp;
			decalInfo.scalePathTime = 0f;
			decalInfo.scaleSpeedMult = scaleSpeedMult;
		}
	}

	public static void DecalTimeout(DecalHandle handle, float timeout)
	{
		if (decalRespectTimeout)
		{
			DecalInfo decalInfo = DecalInfoFromHandle(handle);
			if (decalInfo != null)
			{
				decalInfo.timeout = Mathf.Min(timeout, decalInfo.timeout);
			}
		}
	}

	public static void DecalFadeout(DecalHandle handle, float fadeoutDuration, float timeUntilFadeoutStart = 0f)
	{
		if (decalRespectTimeout)
		{
			DecalGradient(handle, decalFadeoutGradient, fadeoutDuration, timeUntilFadeoutStart);
			DecalTimeout(handle, timeUntilFadeoutStart + fadeoutDuration);
		}
	}

	public static void DecalExtents(DecalHandle handle, Vector3 halfExtents)
	{
		DecalInfo decalInfo = DecalInfoFromHandle(handle);
		if (decalInfo != null)
		{
			decalInfo.halfExtents = halfExtents;
			decalInfo.boundingSphereRadius = halfExtents.magnitude;
		}
	}

	public static void DecalRenderModeSet(DecalHandle handle, DecalRenderMode mode, Vector3? punchDirLocal = null, Color? punchColor = null, float punchDistance = 0f)
	{
		DecalInfo decalInfo = DecalInfoFromHandle(handle);
		if (decalInfo != null)
		{
			decalInfo.renderMode = mode;
			decalInfo.punchThroughDirectionLocal = punchDirLocal.GetValueOrDefault().normalized;
			decalInfo.punchThroughColor = punchColor.GetValueOrDefault(Color.black);
			decalInfo.punchThroughDistance = punchDistance;
		}
	}

	public static void DecalParentWithOffset(DecalHandle handle, Transform parent, Matrix4x4 offset)
	{
		DecalInfo decalInfo = DecalInfoFromHandle(handle);
		if (decalInfo != null)
		{
			decalInfo.parent = parent;
			decalInfo.offset = offset;
		}
	}

	public static Matrix4x4 DecalPointingFrom(DecalHandle handle, Vector3 worldPos, Vector3 normal, Vector3 up, Transform parent = null, Vector3? scale = null)
	{
		Matrix4x4 matrix4x = Matrix4x4.TRS(worldPos, Quaternion.LookRotation(normal, up), scale.GetValueOrDefault(Vector3.one));
		if (parent != null)
		{
			matrix4x = parent.worldToLocalMatrix * matrix4x;
		}
		DecalParentWithOffset(handle, parent, matrix4x);
		return matrix4x;
	}

	public static bool DecalExists(DecalHandle handle)
	{
		return DecalInfoFromHandle(handle) != null;
	}

	private static DecalInfo DecalInfoFromHandle(DecalHandle handle)
	{
		DecalInfo result = null;
		if (handle.index >= 0 && handle.index < decalGenArray.Count && decalGenArray[handle.index].generation == handle.generation)
		{
			result = decalGenArray[handle.index];
		}
		return result;
	}

	public static DecalSharedOutput DecalSharedData(FX_DecalShared shared)
	{
		DecalSharedOutput result = default(DecalSharedOutput);
		if (shared != null)
		{
			result.ident = shared.name;
			Vector3 extents = new Vector3
			{
				z = shared.height
			};
			if (shared.customExtents)
			{
				ref float x = ref extents.x;
				ref float y = ref extents.y;
				float x2 = shared.halfExtents.x;
				float y2 = shared.halfExtents.y;
				x = x2;
				y = y2;
			}
			if (!shared.customExtents)
			{
				int num = 32;
				Vector2 vector = (Vector2)(shared.uvBottomRight - shared.uvTopLeft) / (float)(num * 2);
				ref float x = ref extents.x;
				ref float y3 = ref extents.y;
				float y2 = vector.x;
				float x2 = vector.y;
				x = y2;
				y3 = x2;
			}
			result.extents = extents;
			result.uvTopLeft = shared.uvTopLeft;
			result.uvBottomRight = shared.uvBottomRight;
			result.tags = shared.tags;
		}
		return result;
	}

	public static void DecalSharedApply(DecalHandle handle, DecalSharedOutput shared)
	{
		DecalInfo decalInfo = DecalInfoFromHandle(handle);
		if (decalInfo != null && shared.tags != null && decalInfo.sharedTags != shared.tags)
		{
			foreach (string tag in shared.tags)
			{
				DecalTag(handle, tag);
			}
			decalInfo.sharedTags = shared.tags;
		}
		DecalExtents(handle, shared.extents);
		DecalUv(handle, shared.uvTopLeft, shared.uvBottomRight);
		if (decalInfo != null)
		{
			decalInfo.ident = shared.ident;
		}
	}

	public void RefreshDecalAtlas()
	{
		decalAtlas = Resources.Load<Texture>("Sprite Assets/fx_decalsheet_01");
		Shader.SetGlobalTexture("_DECAL_TEXTURE", decalAtlas);
	}

	public static Texture DecalAtlas()
	{
		if (decalAtlas == null)
		{
			decalAtlas = Resources.Load<Texture>("Sprite Assets/fx_decalsheet_01");
			Shader.SetGlobalTexture("_DECAL_TEXTURE", decalAtlas);
		}
		return decalAtlas;
	}
}
