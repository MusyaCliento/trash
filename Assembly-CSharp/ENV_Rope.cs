using System;
using System.Collections.Generic;
using UnityEngine;

public class ENV_Rope : MonoBehaviour
{
	public List<ENV_Rope_Node> nodes = new List<ENV_Rope_Node>();

	public float nodeDistance = 0.5f;

	public float gravity = -9.81f;

	public float drag = 0.99f;

	public float tightness = 10f;

	public float tightMult = 1f;

	public int constraintIterations = 5;

	public Transform target;

	private Rigidbody targetRigidbody;

	public float targetRigidbodyGravity = -9.81f;

	public GameObject meshRoot;

	public LayerMask layerMask;

	public float grabVelocityTransfer = 20f;

	public float grabVelocityMult = 5f;

	[Header("Audio")]
	public AudioSource swingAudio01;

	public AudioSource swingAudio02;

	public float swingAudioVolume;

	public float swingAudioVelocityMagnitude;

	public float swingAudioPitchMin;

	public float swingAudioPitchMax;

	internal float lastGrabTime;

	private void Start()
	{
		Vector3 position = base.transform.position;
		targetRigidbody = target.GetComponent<Rigidbody>();
		for (int i = 0; i < meshRoot.transform.childCount + 1; i++)
		{
			nodes.Add(new ENV_Rope_Node(position));
			if (i < meshRoot.transform.childCount)
			{
				nodes[i].mesh = meshRoot.transform.GetChild(i);
				nodes[i].mesh.GetComponent<CL_Handhold_Rope>().InitializeRope(this, nodes[i]);
			}
		}
		targetRigidbody.AddForce(UnityEngine.Random.insideUnitSphere * 3f);
	}

	private void OnEnable()
	{
		DarkMachineFunctions.offsetAction = (Action<float>)Delegate.Remove(DarkMachineFunctions.offsetAction, new Action<float>(WorldOffset));
		DarkMachineFunctions.offsetAction = (Action<float>)Delegate.Combine(DarkMachineFunctions.offsetAction, new Action<float>(WorldOffset));
	}

	private void OnDestroy()
	{
		DarkMachineFunctions.offsetAction = (Action<float>)Delegate.Remove(DarkMachineFunctions.offsetAction, new Action<float>(WorldOffset));
	}

	private void FixedUpdate()
	{
		if (CL_GameManager.gMan.isPaused)
		{
			return;
		}
		nodes[0].position = base.transform.position;
		nodes[0].locked = false;
		if ((bool)target)
		{
			nodes[nodes.Count - 1].position = target.position;
			nodes[nodes.Count - 1].locked = false;
		}
		ApplyPhysics();
		SolveConstraints();
		RenderRope();
		float magnitude = targetRigidbody.linearVelocity.magnitude;
		if (targetRigidbody != null)
		{
			targetRigidbody.AddForce(Vector3.up * targetRigidbodyGravity, ForceMode.VelocityChange);
			if (swingAudio01 != null)
			{
				if (magnitude == 0f)
				{
					if (swingAudio01.isPlaying)
					{
						swingAudio01.Pause();
					}
				}
				else if (!swingAudio01.isPlaying)
				{
					swingAudio01.Play();
				}
				swingAudio01.volume = Mathf.Clamp01(magnitude * swingAudioVelocityMagnitude) * swingAudioVolume;
				swingAudio01.pitch = Mathf.Clamp(magnitude * swingAudioVelocityMagnitude, swingAudioPitchMin, swingAudioPitchMax);
			}
			if (swingAudio02 != null)
			{
				if (magnitude == 0f)
				{
					if (swingAudio02.isPlaying)
					{
						swingAudio02.Pause();
					}
				}
				else if (!swingAudio02.isPlaying)
				{
					swingAudio02.Play();
				}
				swingAudio02.volume = Mathf.Clamp01(magnitude * swingAudioVelocityMagnitude) * swingAudioVolume;
			}
		}
		if (!target)
		{
			return;
		}
		float num = Vector3.Distance(target.position, base.transform.position);
		float num2 = nodeDistance * (float)nodes.Count;
		if (num > num2)
		{
			Vector3 force = (LimitDistanceFromTarget(target.position, base.transform.position, nodeDistance * (float)nodes.Count) - target.position) * tightness + (base.transform.position + Vector3.down * (nodeDistance * (float)nodes.Count) - target.position) * tightMult;
			float num3 = num2 + 1f;
			if (num > num3)
			{
				target.position = base.transform.position + (target.position - base.transform.position).normalized * num3;
			}
			targetRigidbody.AddForce(force);
		}
	}

	private void ApplyPhysics()
	{
		for (int i = 0; i < nodes.Count; i++)
		{
			ENV_Rope_Node eNV_Rope_Node = nodes[i];
			if (!eNV_Rope_Node.locked)
			{
				Vector3 position = eNV_Rope_Node.position;
				if (!eNV_Rope_Node.colliding)
				{
					float num = drag * eNV_Rope_Node.velocity.sqrMagnitude;
					Vector3 vector = -eNV_Rope_Node.velocity.normalized * num;
					eNV_Rope_Node.velocity += vector * Time.fixedDeltaTime;
					eNV_Rope_Node.position += eNV_Rope_Node.velocity * Time.fixedDeltaTime;
					eNV_Rope_Node.position += new Vector3(0f, gravity, 0f) * Time.fixedDeltaTime;
				}
				eNV_Rope_Node.previousPosition = position;
			}
		}
	}

	private void SolveConstraints()
	{
		for (int i = 0; i < constraintIterations; i++)
		{
			float num = 0f;
			for (int j = 0; j < nodes.Count - 1; j++)
			{
				ENV_Rope_Node eNV_Rope_Node = nodes[j];
				ENV_Rope_Node eNV_Rope_Node2 = nodes[j + 1];
				Vector3 vector = eNV_Rope_Node.position - eNV_Rope_Node2.position;
				float magnitude = vector.magnitude;
				Vector3 vector2 = ((magnitude != 0f) ? (vector / magnitude) : Vector3.zero);
				float num2 = magnitude - nodeDistance;
				Vector3 vector3 = 0.5f * num2 * vector2;
				num += Mathf.Abs(num2);
				if (j != 0)
				{
					eNV_Rope_Node.position -= vector3;
					eNV_Rope_Node.velocity -= vector3;
				}
				else
				{
					eNV_Rope_Node.position = base.transform.position;
				}
				eNV_Rope_Node2.position += vector3;
				eNV_Rope_Node2.velocity += vector3;
				if ((bool)target && j == nodes.Count - 2)
				{
					eNV_Rope_Node2.position = target.position;
				}
			}
			if (num < 0.01f)
			{
				break;
			}
		}
	}

	private void RenderRope()
	{
		for (int i = 0; i < nodes.Count - 1; i++)
		{
			if (float.IsNaN(nodes[i].mesh.position.x) || float.IsNaN(nodes[i].mesh.position.y) || float.IsNaN(nodes[i].mesh.position.z))
			{
				nodes[i].mesh.position = base.transform.position;
			}
			Debug.DrawLine(nodes[i].position, nodes[i + 1].position, Color.red);
			nodes[i].mesh.position = nodes[i].position;
			nodes[i].mesh.rotation = Quaternion.LookRotation(nodes[i + 1].position - nodes[i].position, base.transform.up);
			float num = Vector3.Distance(nodes[i + 1].position, nodes[i].position);
			if (!float.IsNaN(num) && !float.IsInfinity(num))
			{
				nodes[i].mesh.localScale = new Vector3(1f, 1f, num);
			}
		}
	}

	private void HandleCollisions()
	{
		for (int i = 0; i < nodes.Count - 1; i++)
		{
			ENV_Rope_Node eNV_Rope_Node = nodes[i];
			ENV_Rope_Node eNV_Rope_Node2 = nodes[i + 1];
			if (!(Vector3.Distance(eNV_Rope_Node.position, eNV_Rope_Node2.position) < 0.001f))
			{
				if (Physics.Linecast(eNV_Rope_Node.position, eNV_Rope_Node2.position, out var hitInfo, layerMask))
				{
					Vector3 vector = hitInfo.point + hitInfo.normal * 0.1f;
					eNV_Rope_Node2.colliding = true;
					_ = vector - eNV_Rope_Node2.position;
					eNV_Rope_Node2.position = vector;
				}
				else if (Physics.CheckSphere(eNV_Rope_Node2.position, 0.1f, layerMask))
				{
					eNV_Rope_Node2.colliding = true;
				}
				else
				{
					eNV_Rope_Node2.colliding = false;
				}
			}
		}
	}

	private Vector3 LimitDistanceFromTarget(Vector3 originPosition, Vector3 targetPosition, float maxDistance)
	{
		Vector3 vector = originPosition - targetPosition;
		if (vector.magnitude > maxDistance)
		{
			originPosition = targetPosition + vector.normalized * maxDistance;
		}
		return originPosition;
	}

	public void AddVelocityToClosestNode(Vector3 position, Vector3 addedVelocity)
	{
		float num = float.MaxValue;
		ENV_Rope_Node eNV_Rope_Node = null;
		foreach (ENV_Rope_Node node in nodes)
		{
			float num2 = Vector3.Distance(position, node.position);
			if (num2 < num)
			{
				num = num2;
				eNV_Rope_Node = node;
			}
		}
		if (eNV_Rope_Node != null)
		{
			Vector3 vector = eNV_Rope_Node.position - eNV_Rope_Node.previousPosition;
			vector += addedVelocity;
			eNV_Rope_Node.previousPosition = eNV_Rope_Node.position - vector;
		}
	}

	public void DropRope()
	{
		SetCollision(b: false);
	}

	public void GrabRope()
	{
		SetCollision(b: true);
	}

	public Rigidbody GetTargetRigidbody()
	{
		return targetRigidbody;
	}

	public void SetCollision(bool b)
	{
		foreach (ENV_Rope_Node node in nodes)
		{
			if (b)
			{
				if ((bool)node.mesh)
				{
					node.mesh.gameObject.layer = LayerMask.NameToLayer("Interactable");
				}
			}
			else if ((bool)node.mesh)
			{
				node.mesh.gameObject.layer = LayerMask.NameToLayer("Interactable No Collide");
			}
		}
	}

	public void AddVelocity(Vector3 v)
	{
		Vector3 force = Vector3.ProjectOnPlane(v, base.transform.position - targetRigidbody.position);
		targetRigidbody.AddForce(force);
	}

	public Vector3 GetVelocity()
	{
		return targetRigidbody.linearVelocity;
	}

	public void WorldOffset(float a)
	{
		for (int i = 0; i < nodes.Count - 1; i++)
		{
			nodes[i].position += Vector3.up * a;
			nodes[i].previousPosition += Vector3.up * a;
		}
	}
}
