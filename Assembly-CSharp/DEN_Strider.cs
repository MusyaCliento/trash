using System.Collections.Generic;
using Drawing;
using EditorCools;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(UT_AudioClipHandler))]
public class DEN_Strider : Denizen
{
	private Animator animator;

	public float speed = 1f;

	public float acceleration = 1f;

	public float turnSpeed = 1f;

	private float curSpeed;

	private bool walking;

	private List<Transform> nodes;

	private int currentNode;

	private int direction = 1;

	public Transform nodeParent;

	private float stateTime = 5f;

	public Transform[] feet;

	public LayerMask playerMask;

	public float shakeRadius = 10f;

	public float shakeIntensity = 0.2f;

	public float callFrequency = 10f;

	private float callTime = 10f;

	public ParticleSystem splashEffect;

	public override void Start()
	{
		callTime = Random.Range(callFrequency / 2f, callFrequency * 2f);
		animator = GetComponent<Animator>();
		base.Start();
		clipHandler = GetComponent<UT_AudioClipHandler>();
		RefreshNodes();
	}

	public override void FixedUpdate()
	{
		if (walking)
		{
			if (curSpeed <= speed)
			{
				curSpeed = Mathf.Clamp(curSpeed + Time.fixedDeltaTime * acceleration, 0f, speed);
			}
			animator.SetBool("walking", walking);
			base.transform.position += base.transform.forward * curSpeed * Time.deltaTime;
			Quaternion b = Quaternion.LookRotation((nodes[currentNode].position - base.transform.position).normalized + Vector3.up * Mathf.Sin(Time.time * 1f) * 0.15f);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * turnSpeed);
			if (Vector3.Distance(base.transform.position, nodes[currentNode].position) < 3f)
			{
				currentNode++;
				if (currentNode >= nodes.Count)
				{
					currentNode = 0;
				}
			}
		}
		else if (curSpeed >= 0f)
		{
			curSpeed = Mathf.Clamp(curSpeed - Time.fixedDeltaTime * acceleration, 0f, speed);
		}
		if (stateTime <= 0f)
		{
			stateTime = Random.Range(10, 20);
			walking = !walking;
			animator.SetBool("walking", walking);
		}
		animator.SetFloat("walkspeed", curSpeed / speed);
		stateTime -= Time.fixedDeltaTime;
		callTime -= Time.fixedDeltaTime;
		if (callTime <= 0f)
		{
			clipHandler.PlaySound("strider:call");
			callTime = Random.Range(callFrequency, callFrequency * 2f);
		}
		base.FixedUpdate();
	}

	[Button(null, null, 0f)]
	public void RefreshNodes()
	{
		nodes = new List<Transform>();
		for (int i = 0; i < nodeParent.childCount; i++)
		{
			nodes.Add(nodeParent.GetChild(i));
		}
	}

	public override void DrawGizmos()
	{
		if (nodes == null)
		{
			return;
		}
		for (int i = 0; i < nodes.Count; i++)
		{
			if (!(nodes[i] == null))
			{
				int index = i + 1;
				if (i + 1 >= nodes.Count)
				{
					index = 0;
				}
				Draw.Arrow(nodes[i].position, nodes[index].position, Vector3.up, 0.5f, Color.red);
			}
		}
	}

	public void Footstep(int i)
	{
		clipHandler.PlaySound("strider:footstep", feet[i].position);
		splashEffect.transform.position = feet[i].position;
		splashEffect.Play();
		ShakeScreen();
	}

	public void ShakeScreen()
	{
		Collider[] array = Physics.OverlapSphere(base.transform.position, shakeRadius, playerMask);
		foreach (Collider collider in array)
		{
			collider.BroadcastMessage("ShakeCamera", shakeIntensity * (1f - Vector3.Distance(base.transform.position, collider.transform.position) / shakeRadius));
		}
	}
}
