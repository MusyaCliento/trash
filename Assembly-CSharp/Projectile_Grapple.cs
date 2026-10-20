using UnityEngine;

public class Projectile_Grapple : Projectile
{
	public MeshRenderer hookMesh;

	public float hookMeshLerpSpeed = 5f;

	private float hookWiggle;

	public float hookWiggleSpeed = 5f;

	public float reachWiggleAmount = 1f;

	public float yoinkWiggleAmount = 1f;

	public GameObject hookHandleObject;

	private Vector3 lastGrapplePosition;

	private bool latched;

	private bool tetherOverrideFrame;

	public override void Initialize(Vector3 direction, GameEntity ent = null, Item item = null)
	{
		base.Initialize(direction, ent, item);
	}

	public override void Update()
	{
		base.Update();
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (tetherOverrideFrame)
		{
			tetherOverrideFrame = false;
			hookHandleObject.gameObject.SetActive(value: false);
			return;
		}
		hookHandleObject.gameObject.SetActive(value: true);
		if (!latched)
		{
			lastGrapplePosition = Vector3.Lerp(lastGrapplePosition, base.transform.position, Time.deltaTime * 10f);
			hookMesh.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(hookMesh.transform.position, lastGrapplePosition) / base.transform.lossyScale.y);
			hookMesh.transform.rotation = Quaternion.LookRotation(lastGrapplePosition - hookMesh.transform.position);
			hookHandleObject.transform.position = lastGrapplePosition;
			hookHandleObject.transform.rotation = Quaternion.LookRotation(base.transform.position - lastGrapplePosition);
			if (Vector3.Distance(lastGrapplePosition, base.transform.position) < 0.5f)
			{
				hookHandleObject.transform.localPosition = Vector3.zero;
				hookHandleObject.transform.localRotation = Quaternion.identity;
				latched = true;
				hookMesh.gameObject.SetActive(value: false);
			}
		}
	}

	public override void SetTarget(Transform t)
	{
		base.SetTarget(t);
	}

	public void ScaleTetherTo(Vector3 position)
	{
		hookMesh.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(hookMesh.transform.position, position) / base.transform.lossyScale.y);
		hookMesh.transform.rotation = Quaternion.LookRotation(position - hookMesh.transform.position);
		lastGrapplePosition = position;
		tetherOverrideFrame = true;
		hookMesh.gameObject.SetActive(value: true);
		latched = false;
	}
}
