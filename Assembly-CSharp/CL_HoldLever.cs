using System;
using System.Collections.Generic;
using System.Linq;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class CL_HoldLever : CL_HoldButton, Flippable
{
	[Serializable]
	public class SnapPoint
	{
		public float angle;

		public float snapRange = 5f;

		public bool forceAngleWhenHeld = true;

		[Tooltip("How far you must leave the snap before it can re-trigger")]
		public float exitDeadzone = 2f;

		public UnityEvent onEntered;

		public UnityEvent onExited;

		[HideInInspector]
		public bool isActive;

		private float lastEnteredTime;

		private float lastExitedTime;

		public float enterShake = 0.03f;

		public float exitShake = 0.03f;

		public Renderer targetRenderer;

		public int materialIndex;

		public Material activeMaterial;

		public Material inactiveMaterial;

		public AudioClip enterSound;

		public AudioClip exitSound;

		public void OnEnterState(CL_HoldLever lever)
		{
			if (lever.hasRunForAFrame)
			{
				if (Time.time - lastEnteredTime > 0.1f)
				{
					onEntered?.Invoke();
					lastEnteredTime = Time.time;
					CL_CameraControl.ShakeAtPosition(lever.transform.position, enterShake, 5f);
					AudioManager.PlaySound(enterSound, lever.transform.position);
				}
				if (targetRenderer != null && activeMaterial != null)
				{
					SetMaterial(activeMaterial);
				}
			}
		}

		public void OnExitState(CL_HoldLever lever)
		{
			if (lever.hasRunForAFrame)
			{
				if (Time.time - lastExitedTime > 0.1f)
				{
					lastExitedTime = Time.time;
					onExited?.Invoke();
					CL_CameraControl.ShakeAtPosition(lever.transform.position, exitShake, 5f);
					AudioManager.PlaySound(exitSound, lever.transform.position);
				}
				if (targetRenderer != null && inactiveMaterial != null)
				{
					SetMaterial(inactiveMaterial);
				}
			}
		}

		public void SetMaterial(Material mat)
		{
			if (targetRenderer != null && mat != null)
			{
				Material[] materials = targetRenderer.materials;
				materials[materialIndex] = mat;
				targetRenderer.SetMaterials(materials.ToList());
			}
		}
	}

	public enum RotationMode
	{
		Limited = 0,
		Unlimited = 1
	}

	public bool locked;

	public AudioSource dragAudioSource;

	public float dragAudioVolume = 1f;

	public AudioClip dragStartSound;

	public AudioClip dragStopSound;

	[Header("Rotation")]
	public RotationMode rotationMode;

	public bool projectIntoCameraSpace;

	public bool flipDirectionSpace;

	public Vector3 localAxis = Vector3.right;

	public float initialAngle;

	[Header("Limits (Limited mode only)")]
	public float minAngle = -90f;

	public float maxAngle = 90f;

	[Header("Movement")]
	public float maxDegreesPerSecond = 180f;

	public float smoothing;

	public float snapSpeedMultWhenNotHeld = 1f;

	[Header("Snapping")]
	public bool useSnapping = true;

	public bool moveToSnapPositionWhenNotHeld;

	public SnapPoint[] snapPoints;

	public float dragVelocityMultiplier = 0.5f;

	private float currentAngle;

	private float targetAngle;

	private bool isHeld;

	private float grabStartAngle;

	private float grabStartRayAngle;

	private float accumulatedAngle;

	private Vector3 lastProjectedDir;

	private Quaternion initialRotation;

	private Vector3 initialForwardWorld;

	private Vector3 worldAxis;

	private float smoothVelocity;

	private float grabDistance;

	private float lastAngle;

	private float angleVelocity;

	public float deltaAngleOutputMultiplier;

	public UnityEvent<float> angleDeltaOutput;

	public float angleOutputLow = -1f;

	public float angleOutputHigh = 1f;

	public UnityEvent<float> angleOutput;

	public bool onlyAbsoluteGrabAngles;

	public float lookForce = 10f;

	public bool affectParentOnFlip;

	public bool levelFlipAffectAxis;

	public bool isFlipped;

	private bool hasRunForAFrame;

	private void Awake()
	{
		initialRotation = Quaternion.identity;
		worldAxis = base.transform.parent.TransformDirection(localAxis);
		initialForwardWorld = base.transform.InverseTransformVector(localAxis);
		currentAngle = initialAngle;
		targetAngle = initialAngle;
		lastAngle = initialAngle;
		accumulatedAngle = initialAngle;
		base.transform.localRotation = initialRotation * Quaternion.AngleAxis(currentAngle, localAxis);
		GetComponentInParent<M_Level>();
	}

	public override void Update()
	{
		base.Update();
		worldAxis = base.transform.parent.TransformDirection(localAxis);
		if (projectIntoCameraSpace)
		{
			worldAxis = ENT_Player.GetPlayer().cam.transform.position - base.transform.position;
		}
		if (flipDirectionSpace)
		{
			worldAxis = -worldAxis;
		}
		if (isFlipped && levelFlipAffectAxis)
		{
			worldAxis = -worldAxis;
		}
		if (!locked)
		{
			float num = 1f;
			if (hands.Count == 0)
			{
				targetAngle += angleVelocity * Time.deltaTime;
				angleVelocity = Mathf.MoveTowards(angleVelocity, 0f, dragVelocityMultiplier * Time.deltaTime);
				num *= snapSpeedMultWhenNotHeld;
			}
			else if (Vector3.Angle(Camera.main.transform.forward, hands[0].handModel.transform.position - Camera.main.transform.position) > 10f)
			{
				Vector3 normalized = (hands[0].handModel.transform.position - (Camera.main.transform.forward + Camera.main.transform.position)).normalized;
				Vector3 vector = Camera.main.transform.forward - normalized;
				vector = Camera.main.transform.InverseTransformVector(vector);
				Vector3 vector2 = new Vector3(vector.y, 0f - vector.x, 0f);
				float num2 = (InputManager.IsGamepad() ? 0.5f : 1f);
				float num3 = Vector3.Dot(-Camera.main.transform.forward, (hands[0].handModel.transform.position - Camera.main.transform.position).normalized) + 1f;
				ENT_Player.GetPlayer().AddQuickRotationVelocity(vector2 * lookForce * num3 * Time.deltaTime * num2);
			}
			ResolveSnapping();
			if (smoothing > 0f)
			{
				currentAngle = Mathf.SmoothDamp(currentAngle, targetAngle, ref smoothVelocity, 1f / smoothing, maxDegreesPerSecond * num);
			}
			else
			{
				currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, maxDegreesPerSecond * Time.deltaTime * num);
			}
			if (rotationMode == RotationMode.Limited || maxAngle > 0f)
			{
				targetAngle = Mathf.Clamp(targetAngle, minAngle, maxAngle);
				currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);
			}
			if (float.IsNaN(currentAngle))
			{
				currentAngle = 0f;
			}
			_ = initialRotation;
			Quaternion localRotation = initialRotation * Quaternion.AngleAxis(currentAngle, localAxis);
			if (!float.IsNaN(localRotation.x))
			{
				base.transform.localRotation = localRotation;
			}
			angleDeltaOutput?.Invoke((currentAngle - lastAngle) * deltaAngleOutputMultiplier);
			float arg = Mathf.Lerp(angleOutputLow, angleOutputHigh, Mathf.InverseLerp(minAngle, maxAngle, currentAngle));
			angleOutput?.Invoke(arg);
			hasRunForAFrame = true;
		}
	}

	public override void Interact(Clickable.InteractionInfo info)
	{
		base.Interact(info);
		Plane plane = new Plane(worldAxis, base.transform.position);
		Ray ray = new Ray(info.player.cam.transform.position, info.player.cam.transform.forward);
		Vector3 vector = info.interactionPoint;
		grabDistance = Vector3.Distance(info.player.cam.transform.position, vector);
		if (plane.Raycast(ray, out var enter) && Vector3.Dot(plane.normal, info.player.cam.transform.forward) < -0.3f)
		{
			vector = ray.GetPoint(enter);
		}
		Vector3 to = Vector3.ProjectOnPlane(vector - base.transform.position, worldAxis);
		if (!(to.sqrMagnitude < 0.0001f))
		{
			to.Normalize();
			AudioManager.PlaySound(dragStartSound, base.transform.position);
			if (rotationMode == RotationMode.Limited)
			{
				grabStartAngle = currentAngle;
				grabStartRayAngle = Vector3.SignedAngle(initialForwardWorld, to, worldAxis);
			}
			else
			{
				lastProjectedDir = to;
				accumulatedAngle = currentAngle;
			}
		}
	}

	public override void StopInteract(ENT_Player p, ENT_Player.Hand hand = null, string s = "")
	{
		base.StopInteract(p, hand, s);
		targetAngle = currentAngle;
		if (hands.Count == 0)
		{
			AudioManager.PlaySound(dragStopSound, base.transform.position);
		}
	}

	private void LateUpdate()
	{
		worldAxis = base.transform.parent.TransformDirection(localAxis);
		if (projectIntoCameraSpace)
		{
			worldAxis = ENT_Player.GetPlayer().cam.transform.position - base.transform.position;
		}
		if (flipDirectionSpace)
		{
			worldAxis = -worldAxis;
		}
		if (isFlipped && levelFlipAffectAxis)
		{
			worldAxis = -worldAxis;
		}
		if (dragAudioSource != null)
		{
			if (!dragAudioSource.isPlaying)
			{
				dragAudioSource.Play();
			}
			dragAudioSource.volume = Mathf.Clamp01(Mathf.Abs(angleVelocity) / maxDegreesPerSecond) * dragAudioVolume;
		}
		angleVelocity = (currentAngle - lastAngle) / Time.deltaTime;
		if (!float.IsFinite(angleVelocity))
		{
			angleVelocity = 0f;
		}
		if (hands.Count == 0 || locked)
		{
			lastAngle = currentAngle;
			return;
		}
		lastAngle = currentAngle;
		Plane plane = new Plane(worldAxis, base.transform.position);
		Ray ray = new Ray(ENT_Player.GetPlayer().cam.transform.position, ENT_Player.GetPlayer().cam.transform.forward);
		Vector3 vector = ENT_Player.GetPlayer().cam.transform.position + ENT_Player.GetPlayer().cam.transform.forward * grabDistance;
		if (plane.Raycast(ray, out var enter) && Vector3.Dot(plane.normal, ENT_Player.GetPlayer().cam.transform.forward) < -0.7f)
		{
			vector = ray.GetPoint(enter);
		}
		Vector3 vector2 = vector - base.transform.position;
		Vector3 vector3 = Vector3.ProjectOnPlane(vector2, worldAxis);
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Label2D(base.transform.position + Vector3.up * 0.2f, "Angle: " + currentAngle, Color.cyan);
			CL_DebugView.draw.Cross(vector, 0.2f, Color.green);
			CL_DebugView.draw.Arrow(base.transform.position, base.transform.position + vector3, Color.cyan);
			CL_DebugView.draw.Label2D(vector, "angle: " + grabStartAngle + " \n " + currentAngle + "\n" + targetAngle);
			CL_DebugView.draw.Arrow(base.transform.position, base.transform.position + lastProjectedDir, Color.blue);
			CL_DebugView.draw.Arrow(base.transform.position, base.transform.position + worldAxis, Color.red);
			CL_DebugView.draw.Arrow(vector + vector2, vector + vector3);
		}
		if (vector3.sqrMagnitude < 0.0001f)
		{
			return;
		}
		vector3.Normalize();
		if (rotationMode == RotationMode.Limited)
		{
			float num = Vector3.SignedAngle(initialForwardWorld, vector3, worldAxis);
			if (onlyAbsoluteGrabAngles && Mathf.Sign(num) != Mathf.Sign(grabStartRayAngle))
			{
				grabStartRayAngle *= -1f;
			}
			float num2 = num - grabStartRayAngle;
			targetAngle = Mathf.Clamp(grabStartAngle + num2, minAngle, maxAngle);
		}
		else
		{
			float num3 = Vector3.SignedAngle(lastProjectedDir, vector3, worldAxis);
			accumulatedAngle += num3;
			lastProjectedDir = vector3;
			targetAngle = accumulatedAngle;
			if (maxAngle > 0f)
			{
				targetAngle = Mathf.Clamp(targetAngle, minAngle, maxAngle);
				currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);
				accumulatedAngle = Mathf.Clamp(accumulatedAngle, minAngle, maxAngle);
			}
		}
		ResolveSnapping();
	}

	private void ResolveSnapping()
	{
		if (!useSnapping || snapPoints == null)
		{
			return;
		}
		float num = currentAngle;
		SnapPoint[] array;
		if (moveToSnapPositionWhenNotHeld && hands.Count == 0)
		{
			bool flag = false;
			array = snapPoints;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].isActive)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				float num2 = float.MaxValue;
				float num3 = num;
				array = snapPoints;
				foreach (SnapPoint snapPoint in array)
				{
					float num4 = Mathf.Abs(num - snapPoint.angle);
					if (num4 < num2)
					{
						num2 = num4;
						num3 = snapPoint.angle;
					}
				}
				targetAngle = num3;
			}
		}
		array = snapPoints;
		foreach (SnapPoint snapPoint2 in array)
		{
			float num5 = Mathf.Abs(num - snapPoint2.angle);
			float num6 = Mathf.Abs(targetAngle - snapPoint2.angle);
			if (!snapPoint2.isActive && num5 <= snapPoint2.snapRange)
			{
				snapPoint2.isActive = true;
				targetAngle = snapPoint2.angle;
				snapPoint2.OnEnterState(this);
			}
			else if (snapPoint2.isActive && num5 > snapPoint2.snapRange + snapPoint2.exitDeadzone)
			{
				snapPoint2.isActive = false;
				snapPoint2.OnExitState(this);
			}
			if (!snapPoint2.isActive)
			{
				continue;
			}
			angleVelocity = 0f;
			if (num6 < snapPoint2.snapRange && snapPoint2.forceAngleWhenHeld)
			{
				targetAngle = snapPoint2.angle;
			}
			if (hands.Count == 0)
			{
				targetAngle = snapPoint2.angle;
				if (num5 <= 1f)
				{
					currentAngle = snapPoint2.angle;
				}
			}
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Label2D(base.transform.position, "Snapping: " + snapPoint2.angle, Color.cyan);
			}
		}
	}

	public void SetLocked(bool b)
	{
		locked = b;
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Transform transform = null;
		if (base.transform.parent != null)
		{
			transform = base.transform.parent;
		}
		Draw.Arrow(base.transform.position, base.transform.position + base.transform.TransformDirection(localAxis), Color.red);
		Quaternion quaternion2 = Quaternion.AngleAxis(minAngle + 90f, base.transform.parent.TransformDirection(localAxis));
		Quaternion obj = Quaternion.AngleAxis(maxAngle + 90f, base.transform.parent.TransformDirection(localAxis));
		Vector3 lhs = Vector3.up;
		if (Vector3.Dot(lhs, localAxis) > 0.9f)
		{
			lhs = -Vector3.right;
		}
		Quaternion quaternion3 = Quaternion.AngleAxis(initialAngle, base.transform.parent.TransformDirection(localAxis));
		Draw.Arrow(base.transform.position, base.transform.position + quaternion3 * transform.transform.forward, Color.red);
		Vector3 vector = quaternion2 * base.transform.parent.TransformDirection(lhs);
		Vector3 vector2 = obj * base.transform.parent.TransformDirection(lhs);
		Draw.Arrow(base.transform.position, base.transform.position + vector.normalized, Color.yellow);
		Draw.Arrow(base.transform.position, base.transform.position + vector2.normalized, Color.green);
		Draw.SolidArc(base.transform.position, base.transform.position + vector, base.transform.position + vector2);
		List<DarkMachineFunctions.RenderUnityEventDesc> list = new List<DarkMachineFunctions.RenderUnityEventDesc>();
		SnapPoint[] array = snapPoints;
		foreach (SnapPoint snapPoint in array)
		{
			list.Add(new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = snapPoint.onEntered,
				prependString = $"Snap {snapPoint.angle} On Enter: ",
				color = Color.yellow
			});
			list.Add(new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = snapPoint.onExited,
				prependString = $"Snap {snapPoint.angle} On Exit: ",
				color = Color.orange
			});
		}
		DarkMachineFunctions.RenderUnityEvent(ref Draw.editor, base.transform, list);
	}

	public void OnFlip(bool flipped)
	{
		if (flipped)
		{
			if (affectParentOnFlip)
			{
				base.transform.parent.localScale = new Vector3(0f - base.transform.parent.localScale.x, base.transform.parent.localScale.y, base.transform.parent.localScale.z);
			}
			isFlipped = true;
		}
	}

	public void SetTargetAngle(float f)
	{
		targetAngle = f;
	}
}
