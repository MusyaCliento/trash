using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Drawing;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class FX_BeamManager : MonoBehaviour
{
	public struct System
	{
		internal int index;

		internal int generation;
	}

	public struct Surface
	{
		internal int index;

		internal int generation;
	}

	public struct Beam
	{
		internal int index;

		internal int generation;
	}

	public struct BeamPoint
	{
		internal int index;

		internal int generation;
	}

	public enum TextureOverflow
	{
		Stretch = 0,
		Tile = 1
	}

	public struct BeamHit
	{
		public RaycastHit ray;
	}

	[Serializable]
	public class BeamDamage
	{
		public float amount;

		public string type;

		public List<string> tags;

		public GameEntity sourceEntity;

		public GameObject sourceObject;

		public float damageRate = 0.5f;

		private float damageIntervalTime;

		internal void Damage(GameObject gameObject, RaycastHit hit)
		{
			if (Time.time > damageIntervalTime)
			{
				damageIntervalTime = Time.time + damageRate;
				if (gameObject.TryGetComponent<Damageable>(out var component))
				{
					component.Damage(Damageable.DamageInfo.CreateDamageInfo(amount, type, tags, sourceEntity));
				}
			}
		}
	}

	private struct BeamPointData : DarkMachineFunctions.IntrusiveGenArray
	{
		public Transform parent;

		public Vector3 offset;

		public int nextFree { get; set; }

		public int generation { get; set; }
	}

	private struct BeamData : DarkMachineFunctions.IntrusiveGenArray
	{
		public int firstPoint;

		public int nextBeam;

		public int lastBeam;

		public int parentSystem;

		public int parentTask;

		public Action<BeamHit> physicsOnHit;

		public LayerMask physicsMask;

		public float physicsColliderSizeMult;

		public BeamDamage beamDamage;

		public int materialIndex;

		public int nextWithSameMaterial;

		public int lastWithSameMaterial;

		public TextureOverflow overflow;

		public float pixelsPerMeter;

		public float resolution;

		public float width;

		public float maxOffset;

		public AnimationCurve widthOverLength;

		public AnimationCurve widthOverLifetime;

		public byte rngIndex;

		public byte rngSpeedMin;

		public byte rngSpeedMax;

		public float rngSpeedRate;

		public float rngSpeedRateVariance;

		public float rngSpeedRateRem;

		public float lifetime;

		public float lifetimeMax;

		public Color color;

		public RollingAverage flickerRollingAverage;

		public int nextFree { get; set; }

		public int generation { get; set; }
	}

	public enum SurfaceKind
	{
		Point = 0,
		Rectangle = 1,
		Circle = 2
	}

	[Serializable]
	public struct SurfaceShapeData
	{
		public SurfaceKind kind;

		public float a;

		public float b;
	}

	private struct SurfaceData : DarkMachineFunctions.IntrusiveGenArray
	{
		public bool isEnabled;

		public int nextSurface;

		public int lastSurface;

		public int parentSystem;

		public Transform parent;

		public Matrix4x4 offset;

		public SurfaceShapeData shape;

		public int nextFree { get; set; }

		public int generation { get; set; }
	}

	[Serializable]
	public class SystemTask
	{
		public bool active = true;

		public string name = "";

		public FX_BeamShared beam;

		public float emissionRate = 1f;

		public int maxBeams = 16;

		public float lifetimeBase = 1f;

		public float lifetimeVariance = 0.2f;

		public bool collide;

		public UnityEvent<BeamHit> collisionOnHit;

		public LayerMask collisionLayer;

		public float colliderSizeMult = 1f;

		public bool originIsWhitelist = true;

		public string[] originTags;

		public float targetRadiusMin;

		public float targetRadiusMax = 9999f;

		public float targetAngleMin;

		public float targetAngleMax = 180f;

		public bool targetIsWhitelist = true;

		public string[] targetTags;

		public Color color = Color.white;

		public RollingAverage randomBrightness;

		public bool useBeamDamage;

		public BeamDamage beamDamage;
	}

	private struct SystemSurfaceTags : DarkMachineFunctions.IntrusiveGenArray
	{
		public int nextSurfaceTagged;

		public long nameHash;

		public string name;

		public List<Surface> surfaces;

		public int generation { get; set; }

		public int nextFree { get; set; }
	}

	private struct SystemTaskData : DarkMachineFunctions.IntrusiveGenArray
	{
		public int nextTask;

		public float emissionTimeout;

		public int beamCount;

		public SystemTask task;

		public int generation { get; set; }

		public int nextFree { get; set; }
	}

	private struct SystemData : DarkMachineFunctions.IntrusiveGenArray
	{
		public int firstSurface;

		public int surfaceCount;

		public int firstSurfaceTags;

		public int firstBeam;

		public int beamCount;

		public int beamCountMax;

		public int firstTask;

		public Transform parent;

		public Vector3 offset;

		public int unnamedIndex;

		public int generation { get; set; }

		public int nextFree { get; set; }
	}

	private struct PerMaterial : DarkMachineFunctions.IntrusiveGenArray
	{
		public Material material;

		public int materialId;

		public int firstBeamUsingMaterial;

		public int generation { get; set; }

		public int nextFree { get; set; }
	}

	private struct PerBeamData
	{
		public float totalLength;

		public float uv0Mult;

		public float maxOffset;

		public float widthMult;

		public int startingIndex;

		public int endingIndex;

		public int rngIndex;
	}

	public static FX_BeamManager instance;

	private bool debug;

	private bool enableColliders = true;

	private AnimationCurve unitCurve;

	private readonly RollingAverage nilRollingAverage = new RollingAverage
	{
		addMin = 1f,
		addMax = 1f,
		bufferSize = 1
	};

	public Material fallbackMaterial;

	private static float[] rngTable;

	private static DarkMachineFunctions.GenArray<BeamPointData> points;

	private static DarkMachineFunctions.GenArray<BeamData> beams;

	private static DarkMachineFunctions.GenArray<PerMaterial> materials;

	private static DarkMachineFunctions.GenArray<SurfaceData> surfaces;

	private static DarkMachineFunctions.GenArray<SystemSurfaceTags> surfacesTagged;

	private static DarkMachineFunctions.GenArray<SystemTaskData> tasks;

	private static DarkMachineFunctions.GenArray<SystemData> systems;

	private static GraphicsBuffer triangleStripIndexBuffer;

	private static GraphicsBuffer indirectCommandBuffer;

	private static ComputeBuffer bufferPerBeams;

	private static ComputeBuffer bufferControlPoints;

	private static ComputeBuffer bufferRandomFloats;

	private static ComputeBuffer bufferColors;

	private static List<float> pathDistances = new List<float>();

	private static int unnamedCount = 0;

	private static List<GraphicsBuffer.IndirectDrawIndexedArgs> indirectDrawCalls = new List<GraphicsBuffer.IndirectDrawIndexedArgs>();

	private static List<PerBeamData> perBeams = new List<PerBeamData>();

	private static List<Vector4> controlPoints = new List<Vector4>();

	private static List<float> randomFloats = new List<float>();

	private static List<Color> colors = new List<Color>();

	private static List<int> materialRanges = new List<int>();

	private static List<Vector3> beamPoints = new List<Vector3>();

	private static List<Plane[]> cameraPlanesCache = new List<Plane[]>();

	private Rect debugWindowRect = new Rect(100f, 100f, 400f, 400f);

	private TimeSpan systemUpdateTime;

	private TimeSpan vertexGenerationTime;

	private TimeSpan submitTime;

	private int vertexCount;

	private int commandCount;

	public void Awake()
	{
		instance = this;
		CommandConsole.BuildVariableBool(() => ref debug, "beam_debug", "Render all beam surfaces, systems and beams into world");
		CommandConsole.BuildVariableBool(() => ref enableColliders, "beam_collide", "Whether or not to track collisions with beams");
		unitCurve = AnimationCurve.Constant(0f, 1f, 1f);
		int count = 1024;
		int num = 16384;
		if (triangleStripIndexBuffer == null)
		{
			int num2 = num * 6;
			triangleStripIndexBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Index, num2, 4);
			int[] array = new int[num2];
			int num3 = 0;
			for (int num4 = 0; num4 < num2; num4 += 6)
			{
				array[num4] = num3;
				array[num4 + 1] = num3 + 1;
				array[num4 + 2] = num3 + 2;
				array[num4 + 3] = num3 + 2;
				array[num4 + 4] = num3 + 1;
				array[num4 + 5] = num3 + 3;
				num3 += 2;
			}
			triangleStripIndexBuffer.SetData(array);
			triangleStripIndexBuffer.name = "Beam Index Buffer";
		}
		if (indirectCommandBuffer == null)
		{
			indirectCommandBuffer = new GraphicsBuffer(GraphicsBuffer.Target.IndirectArguments, count, Marshal.SizeOf<GraphicsBuffer.IndirectDrawIndexedArgs>());
			indirectCommandBuffer.name = "Beam Command Buffer";
		}
		if (bufferPerBeams == null)
		{
			bufferPerBeams = new ComputeBuffer(count, Marshal.SizeOf<PerBeamData>(), ComputeBufferType.Structured, ComputeBufferMode.Dynamic);
			bufferPerBeams.name = "Beam Per Beam";
		}
		if (bufferControlPoints == null)
		{
			bufferControlPoints = new ComputeBuffer(num, 16, ComputeBufferType.Structured, ComputeBufferMode.Dynamic);
			bufferControlPoints.name = "Beam Control Points";
		}
		if (bufferRandomFloats == null)
		{
			bufferRandomFloats = new ComputeBuffer(num, 4, ComputeBufferType.Structured, ComputeBufferMode.Dynamic);
			bufferRandomFloats.name = "Beam UVs";
		}
		if (bufferColors == null)
		{
			bufferColors = new ComputeBuffer(num, 16, ComputeBufferType.Structured, ComputeBufferMode.Dynamic);
			bufferColors.name = "Beam Vertex Colors";
		}
	}

	public static Beam BeamCreate(System system)
	{
		(int index, int generation) tuple = beams.Add();
		int item = tuple.index;
		int item2 = tuple.generation;
		ref BeamData reference = ref beams.elements[item];
		reference.firstPoint = -1;
		reference.nextBeam = -1;
		reference.lastBeam = -1;
		reference.parentSystem = -1;
		if (systems.IsValid(system.index, system.generation))
		{
			ref SystemData reference2 = ref systems.elements[system.index];
			if (reference2.firstBeam != -1)
			{
				beams.elements[reference2.firstBeam].lastBeam = item;
			}
			reference.nextBeam = reference2.firstBeam;
			reference2.firstBeam = item;
			reference.parentSystem = system.index;
		}
		reference.parentTask = -1;
		reference.physicsOnHit = null;
		reference.physicsMask = 0;
		reference.physicsColliderSizeMult = 1f;
		reference.beamDamage = null;
		reference.materialIndex = -1;
		reference.nextWithSameMaterial = -1;
		reference.lastWithSameMaterial = -1;
		BeamMaterial(new Beam
		{
			index = item,
			generation = item2
		}, instance.fallbackMaterial);
		reference.overflow = TextureOverflow.Stretch;
		reference.pixelsPerMeter = 32f;
		reference.resolution = 4f;
		reference.width = 1f;
		reference.maxOffset = 1f;
		reference.widthOverLength = instance.unitCurve;
		reference.widthOverLifetime = instance.unitCurve;
		reference.rngIndex = (byte)UnityEngine.Random.Range(0, rngTable.Length);
		reference.rngSpeedMin = 0;
		reference.rngSpeedMax = 0;
		reference.rngSpeedRate = 0f;
		reference.rngSpeedRateVariance = 0f;
		reference.rngSpeedRateRem = 0f;
		reference.lifetime = float.PositiveInfinity;
		reference.lifetimeMax = float.PositiveInfinity;
		reference.color = Color.white;
		reference.flickerRollingAverage = instance.nilRollingAverage;
		return new Beam
		{
			index = item,
			generation = item2
		};
	}

	public static void BeamDestroy(Beam beam)
	{
		if (!beams.IsValid(beam.index, beam.generation))
		{
			return;
		}
		ref BeamData reference = ref beams.elements[beam.index];
		int num = reference.firstPoint;
		while (num != -1)
		{
			ref BeamPointData reference2 = ref points.elements[num];
			int nextFree = reference2.nextFree;
			points.Remove(num, reference2.generation);
			num = nextFree;
		}
		if (reference.parentSystem != -1)
		{
			systems.elements[reference.parentSystem].beamCount--;
		}
		if (reference.parentTask != -1)
		{
			tasks.elements[reference.parentTask].beamCount--;
		}
		if (reference.materialIndex != -1)
		{
			ref PerMaterial reference3 = ref materials.elements[reference.materialIndex];
			if (reference.lastWithSameMaterial != -1)
			{
				beams.elements[reference.lastWithSameMaterial].nextWithSameMaterial = reference.nextWithSameMaterial;
			}
			else
			{
				reference3.firstBeamUsingMaterial = reference.nextWithSameMaterial;
			}
			if (reference.nextWithSameMaterial != -1)
			{
				beams.elements[reference.nextWithSameMaterial].lastWithSameMaterial = reference.lastWithSameMaterial;
			}
			if (reference3.firstBeamUsingMaterial == -1)
			{
				materials.Remove(reference.materialIndex, reference3.generation);
			}
		}
		beams.Remove(beam.index, beam.generation);
	}

	public static void BeamLifetime(Beam beam, float total)
	{
		if (beams.IsValid(beam.index, beam.generation))
		{
			ref BeamData reference = ref beams.elements[beam.index];
			reference.lifetime = total;
			reference.lifetimeMax = total;
		}
	}

	public static void BeamColor(Beam beam, Color color)
	{
		if (beams.IsValid(beam.index, beam.generation))
		{
			beams.elements[beam.index].color = color;
		}
	}

	public static void BeamRandomBrightness(Beam beam, RollingAverage rollingAverage)
	{
		if (beams.IsValid(beam.index, beam.generation))
		{
			ref BeamData reference = ref beams.elements[beam.index];
			reference.flickerRollingAverage.addMin = rollingAverage.addMin;
			reference.flickerRollingAverage.addMax = rollingAverage.addMax;
			reference.flickerRollingAverage.bufferSize = rollingAverage.bufferSize;
			reference.flickerRollingAverage.outputCurve = rollingAverage.outputCurve;
		}
	}

	public static void BeamMaterial(Beam beam, Material material)
	{
		if (!beams.IsValid(beam.index, beam.generation))
		{
			return;
		}
		ref BeamData reference = ref beams.elements[beam.index];
		if (material == null)
		{
			material = instance.fallbackMaterial;
		}
		int instanceID = material.GetInstanceID();
		if (reference.materialIndex != -1 && materials.elements[reference.materialIndex].materialId == instanceID)
		{
			return;
		}
		if (reference.materialIndex != -1)
		{
			ref PerMaterial reference2 = ref materials.elements[reference.materialIndex];
			if (reference.lastWithSameMaterial != -1)
			{
				beams.elements[reference.lastWithSameMaterial].nextWithSameMaterial = beam.index;
			}
			else
			{
				reference2.firstBeamUsingMaterial = reference.nextWithSameMaterial;
			}
			if (reference.nextWithSameMaterial != -1)
			{
				beams.elements[reference.nextWithSameMaterial].lastWithSameMaterial = reference.lastWithSameMaterial;
			}
			if (reference2.firstBeamUsingMaterial == -1)
			{
				materials.Remove(reference.materialIndex, reference2.generation);
			}
		}
		int num = -1;
		for (int i = 0; i < materials.count; i++)
		{
			if (materials.elements[i].generation % 2 == 1 && materials.elements[i].materialId == instanceID)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			ref PerMaterial reference3 = ref materials.elements[num];
			ref BeamData reference4 = ref beams.elements[reference3.firstBeamUsingMaterial];
			reference.nextWithSameMaterial = reference3.firstBeamUsingMaterial;
			reference.lastWithSameMaterial = -1;
			reference.materialIndex = num;
			reference4.lastWithSameMaterial = beam.index;
			reference3.firstBeamUsingMaterial = beam.index;
		}
		else
		{
			int item = materials.Add().index;
			ref PerMaterial reference5 = ref materials.elements[item];
			reference.lastWithSameMaterial = -1;
			reference.nextWithSameMaterial = -1;
			reference.materialIndex = item;
			reference5.material = material;
			reference5.materialId = instanceID;
			reference5.firstBeamUsingMaterial = beam.index;
		}
	}

	public static void BeamPixelsPerMeter(Beam beam, float pixelsPerMeter)
	{
		if (beams.IsValid(beam.index, beam.generation))
		{
			beams.elements[beam.index].pixelsPerMeter = pixelsPerMeter;
		}
	}

	public static void BeamTextureOverflow(Beam beam, TextureOverflow overflow)
	{
		if (beams.IsValid(beam.index, beam.generation))
		{
			beams.elements[beam.index].overflow = overflow;
		}
	}

	public static void BeamResolution(Beam beam, float resolution)
	{
		if (beams.IsValid(beam.index, beam.generation))
		{
			beams.elements[beam.index].resolution = resolution;
		}
	}

	public static void BeamSize(Beam beam, float width, float maxOffset)
	{
		if (beams.IsValid(beam.index, beam.generation))
		{
			ref BeamData reference = ref beams.elements[beam.index];
			reference.width = width;
			reference.maxOffset = maxOffset;
		}
	}

	public static void BeamAnimate(Beam beam, int startingIndex, float forwardRateBase, float forwardRateVariance, int forwardMinStep, int forwardMaxStep)
	{
		if (beams.IsValid(beam.index, beam.generation))
		{
			ref BeamData reference = ref beams.elements[beam.index];
			reference.rngIndex = (byte)((startingIndex != -1) ? startingIndex : UnityEngine.Random.Range(0, 255));
			reference.rngSpeedMin = (byte)forwardMinStep;
			reference.rngSpeedMax = (byte)forwardMaxStep;
			reference.rngSpeedRate = forwardRateBase;
			reference.rngSpeedRateVariance = forwardRateVariance;
			reference.rngSpeedRateRem = RandomRange(forwardRateBase, forwardRateVariance);
		}
	}

	public static void BeamCollision(Beam beam, Action<BeamHit> onHit, LayerMask mask, float colliderSizeMult = 1f, BeamDamage beamDamage = null)
	{
		if (beams.IsValid(beam.index, beam.generation))
		{
			ref BeamData reference = ref beams.elements[beam.index];
			reference.physicsOnHit = onHit;
			reference.physicsMask = mask;
			reference.physicsColliderSizeMult = colliderSizeMult;
			reference.beamDamage = beamDamage;
		}
	}

	public static void BeamWidthOverLengthCurve(Beam beam, AnimationCurve curve)
	{
		if (beams.IsValid(beam.index, beam.generation))
		{
			beams.elements[beam.index].widthOverLength = curve;
		}
	}

	public static void BeamWidthOverLifetimeCurve(Beam beam, AnimationCurve curve)
	{
		if (beams.IsValid(beam.index, beam.generation))
		{
			beams.elements[beam.index].widthOverLifetime = curve;
		}
	}

	public static void BeamApplyShared(Beam beam, FX_BeamShared shared)
	{
		BeamMaterial(beam, shared.material);
		BeamTextureOverflow(beam, shared.textureOverflow);
		BeamPixelsPerMeter(beam, shared.pixelsPerMeter);
		BeamResolution(beam, shared.resolution);
		BeamAnimate(beam, shared.startingIndex, shared.forwardRateBase, shared.forwardRateVariance, shared.forwardStepMin, shared.forwardStepMax);
		BeamSize(beam, RandomRange(shared.widthBase, shared.widthVariance), RandomRange(shared.maxOffsetBase, shared.maxOffsetVariance));
		BeamWidthOverLengthCurve(beam, shared.widthOverLength);
		BeamWidthOverLifetimeCurve(beam, shared.widthOverLifetime);
	}

	public static BeamPoint BeamPointAdd(Beam beam, Surface parentSurface)
	{
		if (!beams.IsValid(beam.index, beam.generation))
		{
			return default(BeamPoint);
		}
		(int index, int generation) tuple = points.Add();
		int item = tuple.index;
		int item2 = tuple.generation;
		ref BeamData reference = ref beams.elements[beam.index];
		ref BeamPointData reference2 = ref points.elements[item];
		reference2.parent = null;
		reference2.offset = Vector3.zero;
		reference2.nextFree = reference.firstPoint;
		reference.firstPoint = item;
		return new BeamPoint
		{
			index = item,
			generation = item2
		};
	}

	public static void BeamPointXForm(BeamPoint point, Transform parent, Vector3 worldOffset)
	{
		if (points.IsValid(point.index, point.generation))
		{
			ref BeamPointData reference = ref points.elements[point.index];
			reference.parent = parent;
			if (parent != null)
			{
				worldOffset = parent.worldToLocalMatrix.MultiplyPoint(worldOffset);
			}
			reference.offset = worldOffset;
		}
	}

	public static System SystemCreate(int maxBeams, Transform parent = null, Vector3? offset = null)
	{
		(int index, int generation) tuple = systems.Add();
		int item = tuple.index;
		int item2 = tuple.generation;
		ref SystemData reference = ref systems.elements[item];
		reference.firstSurface = -1;
		reference.surfaceCount = 0;
		reference.firstSurfaceTags = -1;
		reference.firstBeam = -1;
		reference.beamCount = 0;
		reference.beamCountMax = 128;
		reference.firstTask = -1;
		reference.beamCountMax = maxBeams;
		reference.parent = parent;
		reference.offset = offset ?? Vector3.zero;
		if (reference.parent == null)
		{
			reference.unnamedIndex = unnamedCount++;
		}
		return new System
		{
			index = item,
			generation = item2
		};
	}

	private static Beam SystemTaskBeamCreate(System system, int taskIndex, Surface from, Surface to)
	{
		Beam result = default(Beam);
		if (systems.IsValid(system.index, system.generation) && surfaces.IsValid(from.index, from.generation) && surfaces.IsValid(to.index, to.generation))
		{
			ref SystemTaskData reference = ref tasks.elements[taskIndex];
			systems.elements[system.index].beamCount++;
			reference.beamCount++;
			Beam beam = BeamCreate(system);
			BeamApplyShared(beam, reference.task.beam);
			BeamLifetime(beam, RandomRange(reference.task.lifetimeBase, reference.task.lifetimeVariance));
			BeamColor(beam, reference.task.color);
			BeamRandomBrightness(beam, reference.task.randomBrightness);
			if (reference.task.collide)
			{
				BeamCollision(beam, reference.task.collisionOnHit.Invoke, reference.task.collisionLayer, reference.task.colliderSizeMult, reference.task.useBeamDamage ? reference.task.beamDamage : null);
			}
			(Transform, Vector3) tuple = SurfaceRandomPoint(from);
			(Transform, Vector3) tuple2 = SurfaceRandomPoint(to);
			BeamPointXForm(BeamPointAdd(beam, from), tuple.Item1, tuple.Item2);
			BeamPointXForm(BeamPointAdd(beam, to), tuple2.Item1, tuple2.Item2);
			if (beams.IsValid(beam.index, beam.generation))
			{
				beams.elements[beam.index].parentTask = taskIndex;
			}
			return beam;
		}
		return result;
	}

	public static void SystemTaskAdd(System system, in SystemTask task)
	{
		if (systems.IsValid(system.index, system.generation))
		{
			int item = tasks.Add().index;
			ref SystemTaskData reference = ref tasks.elements[item];
			ref SystemData reference2 = ref systems.elements[system.index];
			reference.nextTask = reference2.firstTask;
			reference.task = task;
			reference.beamCount = 0;
			reference.emissionTimeout = task.emissionRate;
			reference2.firstTask = item;
		}
	}

	public static void SystemSurfaceTagsAdd(System system, string name, List<Surface> surfaces)
	{
		if (!systems.IsValid(system.index, system.generation))
		{
			return;
		}
		ref SystemData reference = ref systems.elements[system.index];
		long num = DarkMachineFunctions.HashString(name);
		int num2 = reference.firstSurfaceTags;
		for (int i = 0; i < 100; i++)
		{
			if (num2 == -1)
			{
				break;
			}
			ref SystemSurfaceTags reference2 = ref surfacesTagged.elements[num2];
			if (reference2.nameHash == num)
			{
				break;
			}
			num2 = reference2.nextSurfaceTagged;
		}
		if (num2 == -1)
		{
			int item = surfacesTagged.Add().index;
			ref SystemSurfaceTags reference3 = ref surfacesTagged.elements[item];
			reference3.nextSurfaceTagged = reference.firstSurfaceTags;
			reference.firstSurfaceTags = item;
			reference3.name = name;
			reference3.nameHash = num;
			reference3.surfaces = surfaces;
		}
		else
		{
			surfacesTagged.elements[num2].surfaces.AddRange(surfaces);
		}
	}

	private static float RandomRange(float @base, float variance)
	{
		return @base + (UnityEngine.Random.value * 2f - 1f) * variance;
	}

	public static void SystemDestroy(System system)
	{
		if (!systems.IsValid(system.index, system.generation))
		{
			return;
		}
		ref SystemData reference = ref systems.elements[system.index];
		int num = reference.firstBeam;
		for (int i = 0; i < 1000; i++)
		{
			if (num == -1)
			{
				break;
			}
			ref BeamData reference2 = ref beams.elements[num];
			int nextBeam = reference2.nextBeam;
			BeamDestroy(new Beam
			{
				index = num,
				generation = reference2.generation
			});
			num = nextBeam;
		}
		int num2 = reference.firstSurface;
		for (int j = 0; j < 1000; j++)
		{
			if (num2 == -1)
			{
				break;
			}
			ref SurfaceData reference3 = ref surfaces.elements[num2];
			int nextSurface = reference3.nextSurface;
			SurfaceDestroy(new Surface
			{
				index = num2,
				generation = reference3.generation
			});
			num2 = nextSurface;
		}
		int num3 = reference.firstTask;
		for (int k = 0; k < 1000; k++)
		{
			if (num3 == -1)
			{
				break;
			}
			ref SystemTaskData reference4 = ref tasks.elements[num3];
			int nextTask = reference4.nextTask;
			tasks.Remove(num3, reference4.generation);
			num3 = nextTask;
		}
		int num4 = reference.firstSurfaceTags;
		for (int l = 0; l < 1000; l++)
		{
			if (num4 == -1)
			{
				break;
			}
			ref SystemSurfaceTags reference5 = ref surfacesTagged.elements[num4];
			int nextSurfaceTagged = reference5.nextSurfaceTagged;
			surfacesTagged.Remove(num4, reference5.generation);
			num4 = nextSurfaceTagged;
		}
		systems.Remove(system.index, system.generation);
	}

	public static Surface SurfaceCreate(System parentSystem)
	{
		if (!systems.IsValid(parentSystem.index, parentSystem.generation))
		{
			UnityEngine.Debug.LogError("Creating surface on destroyed or invalid system!");
			return default(Surface);
		}
		(int index, int generation) tuple = surfaces.Add();
		int item = tuple.index;
		int item2 = tuple.generation;
		ref SurfaceData reference = ref surfaces.elements[item];
		reference.parentSystem = parentSystem.index;
		reference.lastSurface = -1;
		ref SystemData reference2 = ref systems.elements[parentSystem.index];
		reference2.surfaceCount++;
		if (reference2.firstSurface != -1)
		{
			surfaces.elements[reference2.firstSurface].lastSurface = item;
			reference.nextSurface = reference2.firstSurface;
		}
		else
		{
			reference.nextSurface = -1;
		}
		reference2.firstSurface = item;
		return new Surface
		{
			index = item,
			generation = item2
		};
	}

	public static bool SurfaceExists(Surface surface)
	{
		return surfaces.IsValid(surface.index, surface.generation);
	}

	public static void SurfaceEnabled(Surface surface, bool enabled)
	{
		if (surfaces.IsValid(surface.index, surface.generation))
		{
			surfaces.elements[surface.index].isEnabled = enabled;
		}
	}

	public static void SurfaceXForm(Surface surface, Transform parent, Matrix4x4 offset)
	{
		if (surfaces.IsValid(surface.index, surface.generation))
		{
			ref SurfaceData reference = ref surfaces.elements[surface.index];
			reference.parent = parent;
			reference.offset = offset;
		}
	}

	public static void SurfaceShape(Surface surface, in SurfaceShapeData shape)
	{
		if (surfaces.IsValid(surface.index, surface.generation))
		{
			surfaces.elements[surface.index].shape = shape;
		}
	}

	public static (Transform, Vector3) SurfaceRandomPoint(Surface onSurface)
	{
		Transform transform = null;
		Vector3 vector = Vector3.zero;
		if (surfaces.IsValid(onSurface.index, onSurface.generation))
		{
			ref SurfaceData reference = ref surfaces.elements[onSurface.index];
			transform = reference.parent;
			switch (reference.shape.kind)
			{
			case SurfaceKind.Point:
				vector = Vector3.zero;
				break;
			case SurfaceKind.Rectangle:
				vector = new Vector3(RandomRange(0f, reference.shape.a), RandomRange(0f, reference.shape.b), 0f);
				break;
			case SurfaceKind.Circle:
				vector = UnityEngine.Random.insideUnitCircle * reference.shape.a;
				break;
			default:
				UnityEngine.Debug.LogError($"Unknown shape {reference.shape.kind}");
				break;
			}
			if (transform != null)
			{
				vector = transform.localToWorldMatrix.MultiplyPoint(vector);
			}
		}
		return (transform, vector);
	}

	public static void SurfaceDestroy(Surface surface)
	{
		if (!surfaces.IsValid(surface.index, surface.generation))
		{
			return;
		}
		ref SurfaceData reference = ref surfaces.elements[surface.index];
		ref SystemData reference2 = ref systems.elements[reference.parentSystem];
		reference2.surfaceCount--;
		if (reference.lastSurface == -1)
		{
			reference2.firstSurface = reference.nextSurface;
		}
		else
		{
			surfaces.elements[reference.lastSurface].nextSurface = reference.nextSurface;
			if (reference.nextSurface != -1)
			{
				surfaces.elements[reference.nextSurface].lastSurface = reference.lastSurface;
			}
		}
		surfaces.Remove(surface.index, surface.generation);
	}

	public static void SurfaceShapeDraw(ref CommandBuilder draw, in SurfaceShapeData shape, Matrix4x4 localToWorld)
	{
		draw.PushMatrix(localToWorld);
		switch (shape.kind)
		{
		case SurfaceKind.Point:
			draw.WireSphere(Vector3.zero, 0.1f);
			break;
		case SurfaceKind.Rectangle:
			draw.WireBox(Vector3.zero, new float3(Mathf.Max(0.1f, shape.a) * 2f, Mathf.Max(0.1f, shape.b) * 2f, 0.1f));
			break;
		case SurfaceKind.Circle:
			draw.Circle(Vector3.zero, Vector3.forward * 0.1f, Mathf.Max(0.1f, shape.a));
			break;
		default:
			throw new Exception("uhhhh i forgor");
		}
		draw.Arrow(Vector3.zero, Vector3.forward);
		draw.PopMatrix();
	}

	public static void SystemAllSurfacesWithTags(System system, string[] tags, bool isWhitelist, ref NativeList<Surface> outSurfaces)
	{
		if (!systems.IsValid(system.index, system.generation))
		{
			return;
		}
		ref SystemData reference = ref systems.elements[system.index];
		Span<long> span = stackalloc long[tags.Length];
		for (int i = 0; i < tags.Length; i++)
		{
			span[i] = DarkMachineFunctions.HashString(tags[i]);
		}
		int num = reference.firstSurfaceTags;
		while (num != -1)
		{
			ref SystemSurfaceTags reference2 = ref surfacesTagged.elements[num];
			bool flag = false;
			for (int j = 0; j < span.Length; j++)
			{
				if (span[j] == reference2.nameHash)
				{
					flag = true;
					break;
				}
			}
			if (flag == isWhitelist)
			{
				for (int k = 0; k < reference2.surfaces.Count; k++)
				{
					outSurfaces.Add(reference2.surfaces[k]);
				}
			}
			num = reference2.nextSurfaceTagged;
		}
	}

	public static void Update(List<Camera> cameras)
	{
		if (instance == null)
		{
			return;
		}
		if (cameraPlanesCache.Count < cameras.Count)
		{
			int num = cameras.Count - cameraPlanesCache.Count;
			for (int i = 0; i < num; i++)
			{
				cameraPlanesCache.Add(new Plane[6]);
			}
		}
		for (int j = 0; j < cameras.Count; j++)
		{
			GeometryUtility.CalculateFrustumPlanes(cameras[j], cameraPlanesCache[j]);
		}
		float deltaTime = Time.deltaTime;
		int num2 = 0;
		while (instance.debug && num2 < systems.count)
		{
			ref SystemData reference = ref systems.elements[num2];
			if (reference.generation % 2 != 0)
			{
				Color color = DarkMachineCrayons.Arbitrary(num2);
				CL_DebugView.draw.PushColor(color);
				Vector3 vector = reference.parent.localToWorldMatrix.MultiplyPoint(reference.offset);
				CL_DebugView.draw.Label2D(vector, $"{reference.parent.name}\nBeams: {reference.beamCount}/{reference.beamCountMax}");
				CL_DebugView.draw.PopColor();
			}
			num2++;
		}
		int num3 = 0;
		while (instance.debug && num3 < surfaces.count)
		{
			ref SurfaceData reference2 = ref surfaces.elements[num3];
			if (reference2.generation % 2 != 0)
			{
				Matrix4x4 matrix4x = reference2.offset;
				if (reference2.parent != null)
				{
					matrix4x = reference2.parent.localToWorldMatrix * matrix4x;
				}
				Color color2 = DarkMachineCrayons.Arbitrary(num3);
				if (!reference2.isEnabled)
				{
					color2 = Color.red;
				}
				CL_DebugView.draw.PushColor(color2);
				SurfaceShapeDraw(ref CL_DebugView.draw, in reference2.shape, matrix4x);
				CL_DebugView.draw.PopColor();
			}
			num3++;
		}
		long timestamp = Stopwatch.GetTimestamp();
		NativeList<Surface> outSurfaces = new NativeList<Surface>(128, Allocator.Temp);
		for (int k = 0; k < systems.count; k++)
		{
			ref SystemData reference3 = ref systems.elements[k];
			if (reference3.generation % 2 == 0)
			{
				continue;
			}
			outSurfaces.Clear();
			System system = new System
			{
				index = k,
				generation = reference3.generation
			};
			int num4 = reference3.firstTask;
			while (num4 != -1)
			{
				ref SystemTaskData reference4 = ref tasks.elements[num4];
				reference4.emissionTimeout -= deltaTime;
				if (reference4.emissionTimeout < 0f && reference4.beamCount < reference4.task.maxBeams && reference3.beamCount < reference3.beamCountMax && reference4.task.active)
				{
					Surface surface = default(Surface);
					Surface to = default(Surface);
					SystemAllSurfacesWithTags(system, reference4.task.originTags, reference4.task.originIsWhitelist, ref outSurfaces);
					for (int l = 0; l < outSurfaces.Length; l++)
					{
						if (!surfaces.elements[l].isEnabled)
						{
							outSurfaces.RemoveAtSwapBack(l--);
						}
					}
					surface = ((outSurfaces.Length > 0) ? outSurfaces[UnityEngine.Random.Range(0, outSurfaces.Length)] : default(Surface));
					outSurfaces.Clear();
					if (surfaces.IsValid(surface.index, surface.generation))
					{
						ref SurfaceData reference5 = ref surfaces.elements[surface.index];
						Matrix4x4 matrix4x2 = reference5.offset;
						if (reference5.parent != null)
						{
							matrix4x2 = reference5.parent.localToWorldMatrix * matrix4x2;
						}
						Vector3 position = matrix4x2.GetPosition();
						Vector3 rhs = matrix4x2.GetColumn(2);
						SystemAllSurfacesWithTags(system, reference4.task.targetTags, reference4.task.targetIsWhitelist, ref outSurfaces);
						float num5 = reference4.task.targetRadiusMin * reference4.task.targetRadiusMin;
						float num6 = reference4.task.targetRadiusMax * reference4.task.targetRadiusMax;
						float num7 = Mathf.Cos(reference4.task.targetAngleMin * (MathF.PI / 180f));
						float num8 = Mathf.Cos(reference4.task.targetAngleMax * (MathF.PI / 180f));
						for (int m = 0; m < outSurfaces.Length; m++)
						{
							int index = outSurfaces[m].index;
							ref SurfaceData reference6 = ref surfaces.elements[index];
							bool flag = false;
							if (!flag)
							{
								flag = !reference6.isEnabled;
							}
							Vector3 vector2 = default(Vector3);
							if (!flag)
							{
								vector2 = reference6.offset.GetPosition();
								if (reference6.parent != null)
								{
									vector2 = reference6.parent.localToWorldMatrix.MultiplyPoint(vector2);
								}
							}
							if (!flag)
							{
								float sqrMagnitude = (position - vector2).sqrMagnitude;
								flag = !(sqrMagnitude > num5) || !(sqrMagnitude < num6);
							}
							if (!flag)
							{
								float value = Vector3.Dot((vector2 - position).normalized, rhs);
								value = Mathf.Clamp(value, -1f, 1f);
								flag = !(value >= num8) || !(value <= num7);
							}
							if (flag)
							{
								outSurfaces.RemoveAtSwapBack(m--);
							}
						}
						int index2 = UnityEngine.Random.Range(0, outSurfaces.Length);
						to = ((outSurfaces.Length > 0) ? outSurfaces[index2] : default(Surface));
						outSurfaces.Clear();
					}
					SystemTaskBeamCreate(system, num4, surface, to);
				}
				if (reference4.emissionTimeout < 0f)
				{
					reference4.emissionTimeout = reference4.task.emissionRate;
				}
				num4 = reference4.nextTask;
			}
		}
		indirectDrawCalls.Clear();
		perBeams.Clear();
		controlPoints.Clear();
		randomFloats.Clear();
		colors.Clear();
		materialRanges.Clear();
		materialRanges.Add(0);
		long timestamp2 = Stopwatch.GetTimestamp();
		int num9 = 0;
		for (int n = 0; n < materials.count; n++)
		{
			ref PerMaterial reference7 = ref materials.elements[n];
			if (reference7.generation % 2 != 1)
			{
				continue;
			}
			int width = reference7.material.mainTexture.width;
			int num10 = reference7.firstBeamUsingMaterial;
			while (num10 != -1)
			{
				ref BeamData reference8 = ref beams.elements[num10];
				float num11 = 0f;
				float num12 = 0f;
				float num13 = 1f / reference8.resolution;
				float num14 = reference8.widthOverLifetime.Evaluate(1f - reference8.lifetime / reference8.lifetimeMax);
				if (float.IsNaN(num14))
				{
					num14 = 1f;
				}
				reference8.rngSpeedRateRem -= deltaTime;
				if (reference8.rngSpeedRateRem <= 0f && reference8.rngSpeedRate > 0f)
				{
					reference8.rngIndex = (byte)UnityEngine.Random.Range(reference8.rngIndex + reference8.rngSpeedMin, reference8.rngIndex + reference8.rngSpeedMax);
					reference8.rngSpeedRateRem = RandomRange(reference8.rngSpeedRate, reference8.rngSpeedRateVariance);
				}
				float radius = (reference8.width + reference8.maxOffset) * reference8.physicsColliderSizeMult;
				beamPoints.Clear();
				int num15 = reference8.firstPoint;
				MinMaxAABB empty = MinMaxAABB.Empty;
				float num16 = reference8.maxOffset + reference8.width;
				Vector3 vector3 = new Vector3(num16, num16, num16);
				float num17 = 0f;
				int num18 = 0;
				while (num15 != -1 && num18 < 1000)
				{
					ref BeamPointData reference9 = ref points.elements[num15];
					Vector3 vector4 = reference9.offset;
					if (reference9.parent != null)
					{
						vector4 = reference9.parent.localToWorldMatrix.MultiplyPoint(vector4);
					}
					empty.Encapsulate(vector4 - vector3);
					empty.Encapsulate(vector4 + vector3);
					if (beamPoints.Count > 0)
					{
						List<Vector3> list = beamPoints;
						Vector3 vector5 = list[list.Count - 1];
						float magnitude = (vector4 - vector5).magnitude;
						Vector3 direction = (vector4 - vector5) / magnitude;
						if (instance.enableColliders && (reference8.physicsOnHit != null || reference8.beamDamage != null) && Physics.SphereCast(vector5, radius, direction, out var hitInfo, magnitude, reference8.physicsMask))
						{
							if (reference8.physicsOnHit != null)
							{
								BeamHit obj = new BeamHit
								{
									ray = hitInfo
								};
								reference8.physicsOnHit(obj);
							}
							if (reference8.beamDamage != null)
							{
								reference8.beamDamage.Damage(hitInfo.collider.gameObject, hitInfo);
							}
						}
						num17 += magnitude;
					}
					beamPoints.Add(vector4);
					num15 = reference9.nextFree;
					num18++;
				}
				Bounds bounds = new Bounds((empty.Min + empty.Max) * 0.5f, empty.Max - empty.Min);
				bool flag2 = false;
				for (int num19 = 0; num19 < cameras.Count; num19++)
				{
					if (GeometryUtility.TestPlanesAABB(cameraPlanesCache[num19], bounds))
					{
						flag2 = true;
						break;
					}
				}
				int count = controlPoints.Count;
				int num20 = 1;
				while (flag2 && num20 < beamPoints.Count)
				{
					Vector3 vector6 = beamPoints[num20 - 1];
					Vector3 vector7 = beamPoints[num20];
					if (instance.debug)
					{
						CL_DebugView.draw.PushColor(DarkMachineCrayons.Arbitrary(num9++));
						CL_DebugView.draw.Arrow(vector6, vector7);
						CL_DebugView.draw.PopColor();
					}
					float num21 = (vector7 - vector6).magnitude;
					Vector3 vector8 = (vector7 - vector6) / num21;
					vector6 += vector8 * num11;
					float num22 = 0f;
					while (num21 > 0f)
					{
						float num23 = Mathf.Min(num21, num13);
						num11 = num13 - num23;
						Vector3 vector9 = vector6 + vector8 * num22;
						controlPoints.Add(new Vector4(vector9.x, vector9.y, vector9.z, num12));
						randomFloats.Add(reference8.widthOverLength.Evaluate(1f - num12 / num17));
						float next = reference8.flickerRollingAverage.GetNext();
						colors.Add(reference8.color * next);
						num22 += num23;
						num21 -= num23;
						num12 += num23;
					}
					num20++;
				}
				float uv0Mult = 1f;
				float num24 = 1f / num12;
				if (reference8.overflow == TextureOverflow.Stretch)
				{
					uv0Mult = num24;
				}
				if (reference8.overflow == TextureOverflow.Tile)
				{
					uv0Mult = reference8.pixelsPerMeter / (float)width;
				}
				if (controlPoints.Count != count)
				{
					perBeams.Add(new PerBeamData
					{
						totalLength = num12,
						uv0Mult = uv0Mult,
						maxOffset = reference8.maxOffset,
						widthMult = reference8.width * num14,
						startingIndex = count,
						endingIndex = controlPoints.Count,
						rngIndex = reference8.rngIndex
					});
					indirectDrawCalls.Add(new GraphicsBuffer.IndirectDrawIndexedArgs
					{
						baseVertexIndex = (uint)count,
						indexCountPerInstance = (uint)((controlPoints.Count - count - 1) * 3 * 2),
						instanceCount = 1u,
						startIndex = 0u,
						startInstance = 0u
					});
				}
				if (instance.debug)
				{
					CL_DebugView.draw.WireBox(bounds);
				}
				reference8.lifetime -= deltaTime;
				if (reference8.lifetime <= 0f)
				{
					BeamDestroy(new Beam
					{
						index = num10,
						generation = reference8.generation
					});
				}
				num10 = reference8.nextWithSameMaterial;
			}
			materialRanges.Add(indirectDrawCalls.Count);
		}
		long timestamp3 = Stopwatch.GetTimestamp();
		if (indirectDrawCalls.Count > 0)
		{
			indirectCommandBuffer.SetData(indirectDrawCalls);
			bufferPerBeams.SetData(perBeams);
			bufferControlPoints.SetData(controlPoints);
			bufferRandomFloats.SetData(randomFloats);
			bufferColors.SetData(colors);
			int num25 = 0;
			for (int num26 = 0; num26 < materials.count; num26++)
			{
				if (num25 >= materialRanges.Count - 1)
				{
					break;
				}
				ref PerMaterial reference10 = ref materials.elements[num26];
				if (reference10.generation % 2 == 0)
				{
					continue;
				}
				int num27 = materialRanges[num25];
				int num28 = materialRanges[num25 + 1] - num27;
				num25++;
				if (num28 != 0)
				{
					Material material = reference10.material;
					material.SetBuffer("perBeam", bufferPerBeams);
					material.SetBuffer("controlPoints", bufferControlPoints);
					material.SetBuffer("randomFloats", bufferRandomFloats);
					material.SetBuffer("vertexColors", bufferColors);
					material.SetFloatArray("rngTable", rngTable);
					for (int num29 = 0; num29 < cameras.Count; num29++)
					{
						float num30 = 10000f;
						Graphics.RenderPrimitivesIndexedIndirect(new RenderParams
						{
							material = material,
							camera = cameras[num29],
							worldBounds = new Bounds(Vector3.zero, new Vector3(num30, num30, num30))
						}, MeshTopology.Triangles, triangleStripIndexBuffer, indirectCommandBuffer, num28, num27);
					}
				}
			}
		}
		long timestamp4 = Stopwatch.GetTimestamp();
		instance.vertexCount = controlPoints.Count;
		instance.commandCount = indirectDrawCalls.Count;
		instance.systemUpdateTime = new TimeSpan(timestamp2 - timestamp);
		instance.vertexGenerationTime = new TimeSpan(timestamp3 - timestamp2);
		instance.submitTime = new TimeSpan(timestamp4 - timestamp3);
	}

	private void OnGUI()
	{
		if (debug)
		{
			debugWindowRect = GUILayout.Window(GetHashCode(), debugWindowRect, delegate
			{
				GUILayout.Label($"Vertex count: {vertexCount}");
				GUILayout.Label($"Indirect command count: {commandCount}");
				GUILayout.Label($"System update time: {systemUpdateTime.TotalMilliseconds}ms");
				GUILayout.Label($"Vertex generation time: {vertexGenerationTime.TotalMilliseconds}ms");
				GUILayout.Label($"Submit time: {submitTime.TotalMilliseconds}ms");
				GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
			}, "Beam Debug");
		}
	}

	public static void ClearAll()
	{
		points.Clear();
		beams.Clear();
		materials.Clear();
		surfaces.Clear();
		surfacesTagged.Clear();
		tasks.Clear();
		systems.Clear();
		unnamedCount = 0;
		rngTable = new float[256];
		for (int i = 0; i < 256; i++)
		{
			rngTable[i] = UnityEngine.Random.Range(-1f, 1f);
		}
	}
}
