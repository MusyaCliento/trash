using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

public class FX_MetaballManager : MonoBehaviour
{
	public struct System
	{
		internal int index;

		internal int generation;
	}

	public struct Ball
	{
		internal int index;

		internal int generation;
	}

	private struct SystemData : DarkMachineFunctions.IntrusiveGenArray
	{
		public bool firstFrame;

		public int memoryUsed;

		public Transform parent;

		public Material material;

		public Vector3Int dimensions;

		public ComputeBuffer scalarField;

		public ComputeBuffer dirtyCells;

		public ComputeBuffer marchingCubeTargets;

		public ComputeBuffer triangleNeighborhood;

		public ComputeBuffer indirectComputeCommandBuffer;

		public GraphicsBuffer indirectRenderCommandBuffer;

		public int maxBalls;

		public int ballCount;

		public int maxTriangles;

		public ComputeBuffer vertexBuffer;

		public float cellsPerMeter;

		public int firstBall;

		public ComputeBuffer ballsBuffer;

		public int generation { get; set; }

		public int nextFree { get; set; }
	}

	private struct BallData : DarkMachineFunctions.IntrusiveGenArray
	{
		public Transform parent;

		public Vector3 offset;

		public float radius;

		public int nextBall;

		public int lastBall;

		public int nextFree { get; set; }

		public int generation { get; set; }
	}

	private static DarkMachineFunctions.GenArray<SystemData> systems;

	private static DarkMachineFunctions.GenArray<BallData> balls;

	public static FX_MetaballManager instance;

	private bool debug;

	private int debugSpecific = -1;

	public ComputeShader computeScalarField;

	private int scalarFieldDispatch;

	private uint scalarFieldGroupSize;

	private int clearScalarFieldDispatch;

	public ComputeShader marchingCubes;

	private int marchingCubesDispatch;

	public Material materialCubeDebug;

	public Material materialMetaballFallback;

	private GraphicsBuffer.IndirectDrawIndexedArgs[] cubeIndirectCommandsStaging = new GraphicsBuffer.IndirectDrawIndexedArgs[1];

	private GraphicsBuffer cubeIndirectCommand;

	private GraphicsBuffer cubeIndexes;

	private int[] cubeIndexesStaging;

	private int[] indirectComputeCommandBufferBase = new int[8] { 0, 1, 1, 0, 0, 1, 1, 0 };

	private int[] indirectRenderCommandBufferBase = new int[4] { 0, 1, 0, 0 };

	private ComputeBuffer triangleTable;

	private float debugIsovalueOverride = -1f;

	private int debugMemoryUsed;

	private int debugMetaballCount;

	private int debugClearCount;

	private int debugMarchingCubeCount;

	private int debugVertexCount;

	private int debugVertexCapacity;

	private static Plane[] cameraPlanes = new Plane[6];

	private readonly List<Vector4> ballsStaging = new List<Vector4>(150);

	private Rect debugWindowRect = new Rect(100f, 100f, 400f, 400f);

	private static ulong[] triangleTableData = new ulong[256]
	{
		18446744073709551615uL, 18446744073709548416uL, 18446744073709549840uL, 18446744073694385025uL, 18446744073709550113uL, 18446744073703396224uL, 18446744073702345257uL, 18446744041942557570uL, 18446744073709548211uL, 18446744073693528752uL,
		18446744073704513681uL, 18446744054545322673uL, 18446744073696620963uL, 18446744051037766048uL, 18446744046523854995uL, 18446744073704876681uL, 18446744073709549684uL, 18446744073697194036uL, 18446744073700411664uL, 18446744010209315092uL,
		18446744073700411937uL, 18446744048497604419uL, 18446744036264942121uL, 18446543358923450786uL, 18446744073695606600uL, 18446744022207870795uL, 18446744053081211145uL, 18446483020122987380uL, 18446744024446087587uL, 18446545560349711025uL,
		18446516177270249588uL, 18446744051053710196uL, 18446744073709548633uL, 18446744073696445529uL, 18446744073693107280uL, 18446744026789151832uL, 18446744073697335841uL, 18446744028958562307uL, 18446744013649500709uL, 18446607959003903394uL,
		18446744073704514649uL, 18446744028959998640uL, 18446744053078885456uL, 18446559680068396306uL, 18446744023666371386uL, 18446651172092118420uL, 18446516177203122245uL, 18446744054561003589uL, 18446744073702692985uL, 18446744019841421369uL,
		18446744036421208176uL, 18446744073700455249uL, 18446744014023923833uL, 18446523416359309850uL, 18446503999404409352uL, 18446744036450837922uL, 18446744016593122711uL, 18446663947490137945uL, 18446591346576788274uL, 18446744026858238251uL,
		18446660111837792345uL, 17342130783779836021uL, 17326878837949116587uL, 18446744073698768299uL, 18446744073709548906uL, 18446744073699742592uL, 18446744073699741961uL, 18446744033537102721uL, 18446744073694225761uL, 18446744039406572897uL,
		18446744031303079273uL, 18446605767796086933uL, 18446744073698454322uL, 18446744028243474443uL, 18446744033539860752uL, 18446665539044054693uL, 18446744018230799158uL, 18446580595717507968uL, 18446626449057318579uL, 18446744041962432854uL,
		18446744073701639845uL, 18446744049386209332uL, 18446744036269772945uL, 18446543358906668394uL, 18446744041297371670uL, 18446590365476738337uL, 18446570373963093832uL, 17970041294726723895uL, 18446744028248044211uL, 18446663947406231205uL,
		18446579538655136016uL, 17772694497368183081uL, 18446580595767850824uL, 18104553493706267413uL, 17818552081814260048uL, 18446633544684497238uL, 18446744073703549258uL, 18446744020033554084uL, 18446744006164914442uL, 18446640051352863032uL,
		18446744023818443073uL, 18446539741757315075uL, 18446744073699214368uL, 18446744031368217144uL, 18446744018601027914uL, 18446579467288060544uL, 18446640051218612915uL, 17417866316372599110uL, 18446522741585843305uL, 17385655504331702712uL,
		18446744023780964019uL, 18446744073701603398uL, 18446744050500925095uL, 18446646674865128304uL, 18446471499808905066uL, 18446744019772352362uL, 18446592931688486433uL, 17957884751961991522uL, 18446744013686993031uL, 18446744073695355447uL,
		18446592931839519538uL, 17845979061683693314uL, 18100713915888898177uL, 18446488305897943339uL, 17740020562928240280uL, 18446744073700553104uL, 18446469954726293639uL, 18446744073709549239uL, 18446744073709550439uL, 18446744073699571715uL,
		18446744073699571984uL, 18446744032824756504uL, 18446744073700860442uL, 18446744038116702753uL, 18446744038118400146uL, 18446613934224582582uL, 18446744073700270887uL, 18446744005628033031uL, 18446744043920762482uL, 18446576434985570913uL,
		18446744035884377722uL, 18446603437180655226uL, 18446597192818296624uL, 18446744046472428135uL, 18446744073699636358uL, 18446744031839927139uL, 18446744009442626408uL, 18446572211553080905uL, 18446744012012086406uL, 18446572598762420769uL,
		18446632100165994676uL, 17538252470564922266uL, 18446744015260123944uL, 18446744073695281728uL, 18446606936515485841uL, 18446744031869539473uL, 18446491625331262232uL, 18446744022276939802uL, 17553504141517734756uL, 18446744073697649818uL,
		18446744073704732052uL, 18446744032829326208uL, 18446744053963051269uL, 18446551883909924475uL, 18446744053964973145uL, 18446560745188628406uL, 18446498101547260775uL, 17760830946657253443uL, 18446744044804928295uL, 18446594962652398681uL,
		18446467341742453347uL, 17893179861090461734uL, 18446589138961540185uL, 17607112494607178337uL, 18046902728300055044uL, 18446647635680590439uL, 18446744045986997654uL, 18446560482383235939uL, 18446663075201616048uL, 18446744010179699638uL,
		18446574442796915233uL, 18023852482252637104uL, 17663159129287800203uL, 18446521575652156342uL, 18446506795649358213uL, 18446744015191053913uL, 17881023593199442001uL, 18446744073699141201uL, 17769117628110345777uL, 18446469540899495962uL,
		18446744073703675952uL, 18446744073709549146uL, 18446744073704667739uL, 18446744005935348315uL, 18446744007434983349uL, 18446484045811131770uL, 18446744010746212891uL, 18446658816217060224uL, 18446597984850449785uL, 17476642982759395927uL,
		18446744028399741522uL, 18446553469371645992uL, 18446509015337423113uL, 17462516937905050249uL, 18446744073698489649uL, 18446744028362246016uL, 18446744035949515529uL, 18446744073700726665uL, 18446744042479441029uL, 18446466703195591685uL,
		18446555694978337040uL, 17587423596695037114uL, 18446609146009100626uL, 18092396950941535040uL, 17693382095450473760uL, 18446744073696650569uL, 18446541992329820754uL, 18446744005598401189uL, 17946991048679305891uL, 18446502810653708965uL,
		18446744010681058632uL, 18446744073698022720uL, 18446553879827285320uL, 18446744073709548873uL, 18446744055082207156uL, 18446667759547401088uL, 18446660992957619105uL, 17634605703941600275uL, 18446499549029308340uL, 17546054020160525433uL,
		18446744006099776635uL, 18446535390780503163uL, 18446625838403627666uL, 17798796954432935849uL, 18015535517368203891uL, 18446744073697460897uL, 18446744018268275092uL, 18446488443705966996uL, 18446744073696211716uL, 18446744073709549444uL,
		18446744073701927081uL, 18446744050552355075uL, 18446744055062333968uL, 18446744073703504403uL, 18446744042463763233uL, 18446633199694592259uL, 18446744073704344352uL, 18446744073709550371uL, 18446744045971056690uL, 18446744073695462057uL,
		18446614434696144946uL, 18446744073709548193uL, 18446744073701267505uL, 18446744073709547920uL, 18446744073709549616uL, 18446744073709551615uL
	};

	public static System SystemCreate(Vector3Int dimensions, float cellsPerMeter, Transform parent, Material material, int maxBalls)
	{
		if (dimensions.x % 4 != 0 || dimensions.y % 4 != 0 || dimensions.z % 4 != 0)
		{
			Debug.LogError("Metaball system dimensions need to be divisible by 4 across all axes.");
			return default(System);
		}
		int item = systems.Add().index;
		ref SystemData reference = ref systems.elements[item];
		int num = 0;
		reference.firstFrame = true;
		reference.parent = parent;
		reference.material = ((material != null) ? new Material(material) : null);
		reference.dimensions = dimensions;
		int num2 = dimensions.x * dimensions.y * dimensions.z;
		reference.scalarField = new ComputeBuffer(num2, 4);
		num += num2 * 4;
		reference.dirtyCells = new ComputeBuffer(num2, 4);
		num += num2 * 4;
		reference.marchingCubeTargets = new ComputeBuffer(num2, 4);
		num += num2 * 4;
		reference.indirectComputeCommandBuffer = new ComputeBuffer(8, 4, ComputeBufferType.Structured | ComputeBufferType.DrawIndirect);
		num += 32;
		reference.ballCount = 0;
		reference.maxBalls = maxBalls;
		reference.maxTriangles = num2 / 4;
		reference.indirectRenderCommandBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured | GraphicsBuffer.Target.IndirectArguments, 1, Marshal.SizeOf<GraphicsBuffer.IndirectDrawArgs>());
		num += Marshal.SizeOf<GraphicsBuffer.IndirectDrawArgs>();
		reference.vertexBuffer = new ComputeBuffer(reference.maxTriangles * 3 * 2, 12);
		num += reference.maxBalls * 3 * 2 * 4 * 3;
		reference.triangleNeighborhood = new ComputeBuffer((reference.maxTriangles + 3) / 4, 4);
		num += (reference.maxTriangles + 3) / 4 * 4;
		reference.cellsPerMeter = cellsPerMeter;
		reference.firstBall = -1;
		reference.ballsBuffer = new ComputeBuffer(maxBalls, 16, ComputeBufferType.Structured, ComputeBufferMode.Dynamic);
		num += maxBalls * 4 * 4;
		reference.memoryUsed = num;
		return new System
		{
			index = item,
			generation = reference.generation
		};
	}

	public static int SystemBallCount(System system)
	{
		if (!systems.IsValid(system.index, system.generation))
		{
			return 0;
		}
		return systems.elements[system.index].ballCount;
	}

	public static int SystemBallCapacity(System system)
	{
		if (!systems.IsValid(system.index, system.generation))
		{
			return 0;
		}
		return systems.elements[system.index].maxBalls;
	}

	public static Ball BallCreate(System system)
	{
		if (!systems.IsValid(system.index, system.generation))
		{
			return default(Ball);
		}
		ref SystemData reference = ref systems.elements[system.index];
		if (reference.ballCount >= reference.maxBalls)
		{
			return default(Ball);
		}
		int item = balls.Add().index;
		ref BallData reference2 = ref balls.elements[item];
		reference2.parent = null;
		reference2.offset = default(Vector3);
		reference2.radius = 0f;
		reference2.lastBall = -1;
		reference2.nextBall = reference.firstBall;
		if (reference.firstBall != -1)
		{
			balls.elements[reference.firstBall].lastBall = item;
		}
		reference.firstBall = item;
		reference.ballCount++;
		return new Ball
		{
			index = item,
			generation = reference2.generation
		};
	}

	public static void BallDestroy(System system, Ball ball)
	{
		if (systems.IsValid(system.index, system.generation) && balls.IsValid(ball.index, ball.generation))
		{
			ref SystemData reference = ref systems.elements[system.index];
			ref BallData reference2 = ref balls.elements[ball.index];
			if (reference2.lastBall == -1)
			{
				reference.firstBall = reference2.nextBall;
			}
			else
			{
				balls.elements[reference2.lastBall].nextBall = reference2.nextBall;
			}
			if (reference2.nextBall != -1)
			{
				balls.elements[reference2.nextBall].lastBall = reference2.lastBall;
			}
			reference.ballCount--;
			balls.Remove(ball.index, ball.generation);
		}
	}

	public static void BallXForm(System system, Ball ball, Transform parent, Vector3 offset)
	{
		if (systems.IsValid(system.index, system.generation) && balls.IsValid(ball.index, ball.generation))
		{
			ref BallData reference = ref balls.elements[ball.index];
			reference.parent = parent;
			reference.offset = offset;
		}
	}

	public static void BallRadius(System system, Ball ball, float radius)
	{
		if (systems.IsValid(system.index, system.generation) && balls.IsValid(ball.index, ball.generation))
		{
			balls.elements[ball.index].radius = radius;
		}
	}

	public static void SystemDestroy(System system)
	{
		if (systems.IsValid(system.index, system.generation))
		{
			ref SystemData reference = ref systems.elements[system.index];
			reference.scalarField.Dispose();
			reference.dirtyCells.Dispose();
			reference.marchingCubeTargets.Dispose();
			reference.indirectComputeCommandBuffer.Dispose();
			reference.ballsBuffer.Dispose();
			reference.indirectRenderCommandBuffer.Dispose();
			reference.vertexBuffer.Dispose();
			systems.Remove(system.index, system.generation);
		}
	}

	private void Awake()
	{
		instance = this;
		CommandConsole.BuildVariableBool(() => ref debug, "metaballs_debug", "Debug info for metaballs.");
		CommandConsole.BuildVariableInt(() => ref debugSpecific, "metaballs_debugspecific", "Debug info for specific metaball context.");
		CommandConsole.BuildVariableFloat(() => ref debugIsovalueOverride, "metaballs_isooverride", "Override isovalue used by marching cubes");
		cubeIndirectCommand = new GraphicsBuffer(GraphicsBuffer.Target.IndirectArguments, 1, Marshal.SizeOf<GraphicsBuffer.IndirectDrawIndexedArgs>());
		cubeIndexesStaging = new int[36]
		{
			0, 1, 2, 2, 1, 3, 4, 0, 6, 6,
			0, 2, 7, 5, 6, 6, 5, 4, 3, 1,
			7, 7, 1, 5, 4, 5, 0, 0, 5, 1,
			3, 7, 2, 2, 7, 6
		};
		cubeIndexes = new GraphicsBuffer(GraphicsBuffer.Target.Index, cubeIndexesStaging.Length, 4);
		cubeIndexes.SetData(cubeIndexesStaging);
		triangleTable = new ComputeBuffer(triangleTableData.Length, 8);
		triangleTable.SetData(triangleTableData);
	}

	private void OnDestroy()
	{
		for (int i = 0; i < systems.count; i++)
		{
			SystemDestroy(new System
			{
				index = i,
				generation = systems.elements[i].generation
			});
		}
		cubeIndirectCommand.Dispose();
		cubeIndexes.Dispose();
		triangleTable.Dispose();
		systems.Clear();
		balls.Clear();
	}

	private void Update()
	{
		scalarFieldDispatch = computeScalarField.FindKernel("ComputeScalarField");
		computeScalarField.GetKernelThreadGroupSizes(scalarFieldDispatch, out scalarFieldGroupSize, out var _, out var _);
		clearScalarFieldDispatch = computeScalarField.FindKernel("ClearScalarField");
		marchingCubesDispatch = marchingCubes.FindKernel("MeshReconstruction");
		Camera main = Camera.main;
		GeometryUtility.CalculateFrustumPlanes(main, cameraPlanes);
		int num = 0;
		for (int i = 0; i < systems.count; i++)
		{
			if (systems.elements[i].generation % 2 == 0)
			{
				continue;
			}
			ref SystemData reference = ref systems.elements[i];
			Matrix4x4 value = Matrix4x4.identity;
			if (reference.parent != null)
			{
				value = reference.parent.localToWorldMatrix;
			}
			MinMaxAABB empty = MinMaxAABB.Empty;
			Vector3 vector = (Vector3)reference.dimensions * reference.cellsPerMeter;
			for (int j = 0; j < 8; j++)
			{
				Vector3 point = vector;
				if ((j & 1) == 0)
				{
					point[0] = 0f - point[0];
				}
				if ((j & 2) == 0)
				{
					point[1] = 0f - point[1];
				}
				if ((j & 4) == 0)
				{
					point[2] = 0f - point[2];
				}
				empty.Encapsulate(value.MultiplyPoint(point));
			}
			if (!GeometryUtility.TestPlanesAABB(bounds: new Bounds((empty.Min + empty.Max) * 0.5f, empty.Max - empty.Min), planes: cameraPlanes))
			{
				continue;
			}
			if (!reference.firstFrame)
			{
				computeScalarField.SetBuffer(clearScalarFieldDispatch, "DirtyCells", reference.dirtyCells);
				computeScalarField.SetBuffer(clearScalarFieldDispatch, "ScalarField", reference.scalarField);
				computeScalarField.DispatchIndirect(clearScalarFieldDispatch, reference.indirectComputeCommandBuffer, 0u);
			}
			ballsStaging.Clear();
			int num2 = reference.firstBall;
			while (num2 != -1)
			{
				ref BallData reference2 = ref balls.elements[num2];
				Transform parent = reference2.parent;
				Vector3 offset = reference2.offset;
				float radius = reference2.radius;
				offset = ((parent != null) ? parent.localToWorldMatrix.MultiplyPoint(offset) : offset);
				if (FXManager.IsSphereInFrustrum(cameraPlanes, offset, radius * 1.1f))
				{
					ballsStaging.Add(new Vector4(offset.x, offset.y, offset.z, radius));
				}
				num2 = reference2.nextBall;
			}
			if (ballsStaging.Count == 0)
			{
				continue;
			}
			reference.ballsBuffer.SetData(ballsStaging);
			reference.indirectComputeCommandBuffer.SetData(indirectComputeCommandBufferBase);
			computeScalarField.SetInts("Dims", reference.dimensions.x, reference.dimensions.y, reference.dimensions.z, reference.dimensions.x * reference.dimensions.y);
			computeScalarField.SetFloat("CellsPerMeter", reference.cellsPerMeter);
			computeScalarField.SetVector("TranslationVector", -value.GetPosition());
			computeScalarField.SetBuffer(scalarFieldDispatch, "ScalarField", reference.scalarField);
			computeScalarField.SetBuffer(scalarFieldDispatch, "DirtyCells", reference.dirtyCells);
			computeScalarField.SetBuffer(scalarFieldDispatch, "MarchingCubeTargets", reference.marchingCubeTargets);
			computeScalarField.SetBuffer(scalarFieldDispatch, "IndirectComputeCommandBuffer", reference.indirectComputeCommandBuffer);
			computeScalarField.SetInt("SphereCount", ballsStaging.Count);
			computeScalarField.SetBuffer(scalarFieldDispatch, "SpherePosAndRadius", reference.ballsBuffer);
			int threadGroupsX = DispatchDimension(ballsStaging.Count, scalarFieldGroupSize);
			computeScalarField.Dispatch(scalarFieldDispatch, threadGroupsX, 1, 1);
			if (debugSpecific == num)
			{
				for (int k = 0; k < ballsStaging.Count; k++)
				{
					Vector4 vector2 = ballsStaging[k];
					Vector3 vector3 = vector2;
					CL_DebugView.draw.WireSphere(vector3, 0.1f);
					CL_DebugView.draw.WireSphere(vector3, vector2.w);
				}
				RenderParams rparams = new RenderParams
				{
					material = materialCubeDebug,
					camera = main,
					worldBounds = new Bounds(value.GetPosition(), (Vector3)reference.dimensions * reference.cellsPerMeter)
				};
				cubeIndirectCommandsStaging[0] = new GraphicsBuffer.IndirectDrawIndexedArgs
				{
					indexCountPerInstance = (uint)cubeIndexesStaging.Length,
					instanceCount = (uint)(reference.dimensions.x * reference.dimensions.y * reference.dimensions.z)
				};
				cubeIndirectCommand.SetData(cubeIndirectCommandsStaging);
				materialCubeDebug.SetFloat("CellsPerMeter", reference.cellsPerMeter);
				materialCubeDebug.SetInt("Width", reference.dimensions.x);
				materialCubeDebug.SetInt("Height", reference.dimensions.y);
				materialCubeDebug.SetInt("Depth", reference.dimensions.z);
				materialCubeDebug.SetVector("Translation", value.GetPosition());
				materialCubeDebug.SetBuffer("ScalarField", reference.scalarField);
				Graphics.RenderPrimitivesIndexedIndirect(in rparams, MeshTopology.Triangles, cubeIndexes, cubeIndirectCommand);
			}
			reference.indirectRenderCommandBuffer.SetData(indirectRenderCommandBufferBase);
			marchingCubes.SetInts("Dims", reference.dimensions.x, reference.dimensions.y, reference.dimensions.z, reference.dimensions.x * reference.dimensions.y);
			marchingCubes.SetInt("MaxVerts", reference.maxTriangles * 3);
			marchingCubes.SetFloat("Scale", 1f);
			marchingCubes.SetFloat("Isovalue", (debugIsovalueOverride < 0f) ? 1f : debugIsovalueOverride);
			marchingCubes.SetBuffer(marchingCubesDispatch, "TriangleTable", triangleTable);
			marchingCubes.SetBuffer(marchingCubesDispatch, "Voxels", reference.scalarField);
			marchingCubes.SetBuffer(marchingCubesDispatch, "VertexBuffer", reference.vertexBuffer);
			marchingCubes.SetBuffer(marchingCubesDispatch, "TriangleNeighborhood", reference.triangleNeighborhood);
			marchingCubes.SetBuffer(marchingCubesDispatch, "UpdateQueue", reference.marchingCubeTargets);
			marchingCubes.SetBuffer(marchingCubesDispatch, "IndirectComputeCommandBuffer", reference.indirectComputeCommandBuffer);
			marchingCubes.SetBuffer(marchingCubesDispatch, "IndirectRenderCommandBuffer", reference.indirectRenderCommandBuffer);
			marchingCubes.DispatchIndirect(marchingCubesDispatch, reference.indirectComputeCommandBuffer, 16u);
			ref Material material = ref reference.material;
			if (material == null)
			{
				material = new Material(materialMetaballFallback);
			}
			material.SetBuffer("PosAndNormal", reference.vertexBuffer);
			material.SetBuffer("TriangleNeighborhood", reference.triangleNeighborhood);
			material.SetMatrix("LocalToWorld", value);
			material.SetFloat("CellsPerMeter", reference.cellsPerMeter);
			Graphics.RenderPrimitivesIndirect(new RenderParams
			{
				material = material,
				camera = main,
				worldBounds = new Bounds(value.GetPosition(), (Vector3)reference.dimensions * reference.cellsPerMeter)
			}, MeshTopology.Triangles, reference.indirectRenderCommandBuffer);
			if (debugSpecific == num)
			{
				int[] array = new int[4];
				reference.indirectRenderCommandBuffer.GetData(array);
				int[] array2 = new int[8];
				reference.indirectComputeCommandBuffer.GetData(array2);
				debugMemoryUsed = reference.memoryUsed;
				debugMetaballCount = ballsStaging.Count;
				debugClearCount = array2[3];
				debugMarchingCubeCount = array2[7];
				debugVertexCount = array[0];
				debugVertexCapacity = reference.maxTriangles / 3;
			}
			reference.firstFrame = false;
			num++;
		}
	}

	private void OnGUI()
	{
		if (debugSpecific != -1)
		{
			debugWindowRect = GUILayout.Window(GetHashCode(), debugWindowRect, delegate
			{
				GUILayout.Label("Memory used: " + DarkMachineFunctions.MemoryToString(debugMemoryUsed));
				GUILayout.Label($"Metaball count: {debugMetaballCount}");
				GUILayout.Label($"Clear count: {debugClearCount}");
				GUILayout.Label($"Marching cube count: {debugMarchingCubeCount}");
				GUILayout.Label($"Vertex count: {debugVertexCount}/{debugVertexCapacity} ({(float)debugVertexCount / (float)debugVertexCapacity * 100f}%)");
				GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
			}, "Metaball Debug");
		}
	}

	private static int DispatchDimension(int count, uint groupSize)
	{
		return (int)((count + groupSize - 1) / groupSize);
	}
}
