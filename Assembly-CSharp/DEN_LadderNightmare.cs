using UnityEngine;

public class DEN_LadderNightmare : MonoBehaviour
{
	public float playerOffset = 15f;

	public float spinSpeed = 1f;

	private Vector3 startPos;

	public bool canAttack;

	private bool attacking;

	public bool canPeek;

	private bool peeking;

	private float peekTime;

	private float hideTime;

	public bool breathing;

	public float breathTimer = 10f;

	private float breathTime = 10f;

	private static DEN_LadderNightmare instance;

	private UT_AudioClipHandler clipHandler;

	private void Start()
	{
		base.transform.parent = null;
		startPos = base.transform.position;
		clipHandler = GetComponent<UT_AudioClipHandler>();
		instance = this;
	}

	private void Update()
	{
		if (CL_GameManager.GetGamemodeName(includeOptions: false) != "Ladder")
		{
			Object.Destroy(base.gameObject);
		}
		Breathing();
		float num = Peek(playerOffset);
		Vector3 b = ENT_Player.playerObject.transform.position + Vector3.up * num;
		b.x = Mathf.Lerp(b.x, startPos.x, 0.2f);
		b.z = Mathf.Lerp(b.z, startPos.z, 0.2f);
		if (!Attack())
		{
			base.transform.position = Vector3.Lerp(base.transform.position, b, Time.deltaTime * 2f);
			base.transform.rotation *= Quaternion.Euler(0f, Time.deltaTime * spinSpeed, 0f);
			if (canAttack && ENT_Player.playerObject.GetCurrentFallDistance() > 25f)
			{
				attacking = true;
				clipHandler.PlaySound("nightmare:attack");
			}
		}
	}

	private bool Attack()
	{
		if (!attacking)
		{
			return false;
		}
		playerOffset = 0f;
		base.transform.position += (ENT_Player.playerObject.transform.position - base.transform.position).normalized * 20f * Time.deltaTime;
		base.transform.rotation *= Quaternion.Euler(0f, Time.deltaTime * spinSpeed * 3f, 0f);
		if (Vector3.Distance(base.transform.position, ENT_Player.playerObject.transform.position) < 3f)
		{
			ENT_Player.playerObject.Kill("laddernightmare");
		}
		CL_CameraControl.Shake(0.3f * Time.deltaTime);
		return true;
	}

	private float Peek(float curOffset)
	{
		if (!peeking)
		{
			if (hideTime > 0f)
			{
				hideTime -= Time.deltaTime;
				curOffset *= 1.25f;
			}
			else
			{
				peeking = true;
				peekTime = Random.Range(2, 6);
			}
		}
		else if (peekTime > 0f)
		{
			peekTime -= Time.deltaTime;
		}
		else
		{
			peeking = false;
			hideTime = Random.Range(5, 20);
			if (ENT_Player.playerObject.camRoot.CanSeeTarget(base.transform))
			{
				clipHandler.PlaySound("nightmare:hide");
			}
		}
		return curOffset;
	}

	private void Breathing()
	{
		if (breathing)
		{
			breathTime -= Time.deltaTime;
			if (breathTime <= 0f)
			{
				breathTime = Random.Range(0f, breathTimer) * 2f + 5f;
				clipHandler.PlaySound("nightmare:breath", ENT_Player.playerObject.transform.position + Random.onUnitSphere * 6f);
			}
		}
	}

	public static void SetPlayerOffset(float f)
	{
		if (!(instance == null))
		{
			instance.playerOffset = f;
		}
	}

	public static void SetCanPeek(bool b)
	{
		if (!(instance == null))
		{
			instance.canPeek = b;
		}
	}

	public static void SetBreathing(bool b)
	{
		if (!(instance == null))
		{
			instance.breathing = b;
		}
	}

	public static void SetCanAttack(bool b)
	{
		if (!(instance == null))
		{
			instance.canAttack = b;
		}
	}
}
