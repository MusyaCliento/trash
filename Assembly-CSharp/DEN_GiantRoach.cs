using UnityEngine;

public class DEN_GiantRoach : Denizen
{
	public enum AIStates
	{
		searching = 0,
		wandering = 1,
		resting = 2,
		hunting = 3,
		charging = 4
	}

	public enum MovementState
	{
		walking = 0,
		running = 1,
		resting = 2,
		charging = 3,
		leaping = 4
	}

	[Header("Roach")]
	public Transform roachMesh;

	public LayerMask worldMask;

	public float crawlSpeed = 1f;

	public float stickForce = 1f;

	public float rotationSpeed = 2f;

	public float restTimeMin = 1f;

	public float restTimeMax = 2f;

	private float restTime;

	public float chargeHitForce = 2f;

	[Header("AI")]
	public AIStates aiState = AIStates.wandering;

	public MovementState moveState;

	public float sightDistance;

	public float chargeDistance;

	public float loseTargetTimer = 5f;

	private float chargeTime;

	public float chargeWindup = 3f;

	public float chargeCooldown = 10f;

	private float chargeCooldownTime;

	private bool foundRestSpot;

	private bool hasCharged;

	private Collision collision;

	public bool alwaysTargetPlayer;

	private Vector3 targetMoveVector;

	public string[] targetTags;

	private RaycastHit searchRaycast;

	private bool grounded;

	private Vector3 wallNormal;

	private Vector3 facingDir;

	[Header("Physics")]
	public float pGain = 1f;

	public float iGain = 0.1f;

	public float dGain = 0.5f;

	private Rigidbody rigid;

	private Vector3 positionErrorSum = Vector3.zero;

	private Vector3 lastPositionError = Vector3.zero;

	public float noiseIntensity = 0.5f;

	public float noiseFrequency = 1f;

	private float noiseOffsetX;

	private float noiseOffsetY;

	private float noiseOffsetZ;

	private Vector3 landDir;

	[Header("Visuals")]
	public Animator animator;
}
