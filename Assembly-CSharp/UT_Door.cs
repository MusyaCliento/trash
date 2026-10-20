using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_Door : MonoBehaviourGizmos
{
	public enum UseSpace
	{
		Local = 0,
		LocalRelativeToSelf = 1,
		World = 2
	}

	public bool startOpen = true;

	public bool moveToStartPositionInstantly;

	public float startOpenDelay;

	private bool open;

	private bool active;

	private bool canMove = true;

	public UseSpace space;

	public Vector3 move = Vector3.zero;

	public Vector3 rotate = Vector3.zero;

	public float moveSpeed = 1f;

	private Vector3 startPos;

	private Vector3 endPos;

	private Quaternion startRot;

	private Quaternion endRot;

	public bool useCurve;

	public AnimationCurve animationCurve;

	public AnimationCurve rotateAnimationCurve;

	public UnityEvent openEvent;

	public UnityEvent closeEvent;

	public UnityEvent finishEvent;

	public UnityEvent finishOpenEvent;

	public UnityEvent finishCloseEvent;

	public AudioClip openClip;

	public AudioClip closeClip;

	public AudioClip finishOpenClip;

	public AudioClip finishCloseClip;

	public float finishOpenShake;

	public float finishOpenShakeDistance = 10f;

	public float finishCloseShake;

	public float finishCloseShakeDistance = 10f;

	private AudioSource aud;

	private bool latched = true;

	private float lerpAmount;

	private float delayTimer;

	private bool autoMoving;

	private void Start()
	{
		aud = GetComponent<AudioSource>();
		CalculateMovement();
		delayTimer = startOpenDelay;
		if (startOpen)
		{
			if (startOpenDelay > 0f)
			{
				canMove = false;
			}
			else
			{
				Open();
			}
			Open();
			if (moveToStartPositionInstantly)
			{
				SetOpenAmount(1f);
			}
		}
		else
		{
			Close();
			if (moveToStartPositionInstantly)
			{
				SetOpenAmount(0f);
			}
		}
	}

	private void FixedUpdate()
	{
		if (startOpenDelay > 0f && delayTimer > 0f)
		{
			delayTimer -= Time.fixedDeltaTime;
			if (delayTimer <= 0f)
			{
				canMove = true;
				Open();
			}
		}
		if (CL_GameManager.gMan.isPaused || !canMove || latched || !autoMoving)
		{
			return;
		}
		if (open)
		{
			lerpAmount = Mathf.Clamp01(lerpAmount + Time.fixedDeltaTime * moveSpeed);
			if (lerpAmount >= 1f && !latched)
			{
				latched = true;
				if (finishOpenClip != null)
				{
					if (aud != null)
					{
						aud.clip = finishOpenClip;
						aud.Play();
					}
					else
					{
						AudioManager.PlaySound(finishOpenClip, base.transform.position);
					}
				}
				if (finishOpenShake > 0f)
				{
					CL_CameraControl.ShakeAtPosition(base.transform.position, finishOpenShake, finishOpenShakeDistance);
				}
				autoMoving = false;
				finishOpenEvent.Invoke();
				finishEvent.Invoke();
			}
		}
		else
		{
			lerpAmount = Mathf.Clamp01(lerpAmount - Time.fixedDeltaTime * moveSpeed);
			if (lerpAmount <= 0f && !latched)
			{
				latched = true;
				if (finishCloseClip != null)
				{
					if (aud != null)
					{
						aud.clip = finishCloseClip;
						aud.Play();
					}
					else
					{
						AudioManager.PlaySound(finishCloseClip, base.transform.position);
					}
				}
				if (finishCloseShake > 0f)
				{
					CL_CameraControl.ShakeAtPosition(base.transform.position, finishCloseShake, finishCloseShakeDistance);
				}
				autoMoving = false;
				finishEvent.Invoke();
				finishCloseEvent.Invoke();
			}
		}
		float t = (useCurve ? animationCurve.Evaluate(lerpAmount) : lerpAmount);
		float t2 = (useCurve ? rotateAnimationCurve.Evaluate(lerpAmount) : lerpAmount);
		if (space == UseSpace.World)
		{
			base.transform.position = Vector3.LerpUnclamped(startPos, endPos, t);
		}
		else
		{
			base.transform.localPosition = Vector3.LerpUnclamped(startPos, endPos, t);
		}
		if (rotate.magnitude > 0f)
		{
			base.transform.localRotation = Quaternion.LerpUnclamped(startRot, endRot, t2);
		}
	}

	public void Open()
	{
		if (open)
		{
			return;
		}
		open = true;
		active = true;
		openEvent.Invoke();
		latched = false;
		autoMoving = true;
		if (openClip != null)
		{
			if (aud != null)
			{
				aud.clip = openClip;
				aud.Play();
			}
			else
			{
				AudioManager.PlaySound(openClip, base.transform.position);
			}
		}
	}

	public void Close()
	{
		if (!open)
		{
			return;
		}
		open = false;
		active = true;
		closeEvent.Invoke();
		latched = false;
		autoMoving = true;
		if (closeClip != null)
		{
			if (aud != null)
			{
				aud.clip = closeClip;
				aud.Play();
			}
			else
			{
				AudioManager.PlaySound(closeClip, base.transform.position);
			}
		}
	}

	public void AddOpenAmount(float amount)
	{
		if (amount == 0f)
		{
			return;
		}
		autoMoving = false;
		if ((lerpAmount > 0f && amount > 0f) || (lerpAmount < 1f && amount < 0f))
		{
			latched = false;
		}
		else
		{
			latched = true;
		}
		lerpAmount += amount * moveSpeed;
		lerpAmount = Mathf.Clamp01(lerpAmount);
		if (amount > 0f)
		{
			if (lerpAmount >= 1f && !latched)
			{
				latched = true;
				if (finishOpenClip != null)
				{
					if (aud != null)
					{
						aud.clip = finishOpenClip;
						aud.Play();
					}
					else
					{
						AudioManager.PlaySound(finishOpenClip, base.transform.position);
					}
				}
				if (finishOpenShake > 0f)
				{
					CL_CameraControl.ShakeAtPosition(base.transform.position, finishOpenShake, finishOpenShakeDistance);
				}
				finishEvent.Invoke();
				finishOpenEvent.Invoke();
			}
		}
		else if (lerpAmount <= 0f && !latched)
		{
			latched = true;
			if (finishCloseClip != null)
			{
				if (aud != null)
				{
					aud.clip = finishCloseClip;
					aud.Play();
				}
				else
				{
					AudioManager.PlaySound(finishCloseClip, base.transform.position);
				}
			}
			if (finishCloseShake > 0f)
			{
				CL_CameraControl.ShakeAtPosition(base.transform.position, finishCloseShake, finishCloseShakeDistance);
			}
			finishEvent.Invoke();
			finishCloseEvent.Invoke();
		}
		float t = (useCurve ? animationCurve.Evaluate(lerpAmount) : lerpAmount);
		float t2 = (useCurve ? rotateAnimationCurve.Evaluate(lerpAmount) : lerpAmount);
		if (space == UseSpace.World)
		{
			base.transform.position = Vector3.LerpUnclamped(startPos, endPos, t);
		}
		else
		{
			base.transform.localPosition = Vector3.LerpUnclamped(startPos, endPos, t);
		}
		if (rotate.magnitude > 0f)
		{
			base.transform.localRotation = Quaternion.LerpUnclamped(startRot, endRot, t2);
		}
	}

	public void SetOpenAmount(float amount)
	{
		if (amount == 0f)
		{
			return;
		}
		autoMoving = false;
		if (lerpAmount > 0.01f && lerpAmount < 1f)
		{
			latched = false;
		}
		else
		{
			latched = true;
		}
		float num = amount - lerpAmount;
		lerpAmount = Mathf.Clamp01(amount);
		if (num > 0f)
		{
			if (lerpAmount >= 1f && !latched)
			{
				latched = true;
				if (finishOpenClip != null)
				{
					if (aud != null)
					{
						aud.clip = finishOpenClip;
						aud.Play();
					}
					else
					{
						AudioManager.PlaySound(finishOpenClip, base.transform.position);
					}
				}
				if (finishOpenShake > 0f)
				{
					CL_CameraControl.ShakeAtPosition(base.transform.position, finishOpenShake, finishOpenShakeDistance);
				}
				finishEvent.Invoke();
				finishOpenEvent.Invoke();
			}
		}
		else if (lerpAmount <= 0.01f && !latched)
		{
			latched = true;
			if (finishCloseClip != null)
			{
				if (aud != null)
				{
					aud.clip = finishCloseClip;
					aud.Play();
				}
				else
				{
					AudioManager.PlaySound(finishCloseClip, base.transform.position);
				}
				if (finishCloseShake > 0f)
				{
					CL_CameraControl.ShakeAtPosition(base.transform.position, finishCloseShake, finishCloseShakeDistance);
				}
			}
			finishEvent.Invoke();
			finishCloseEvent.Invoke();
		}
		float t = (useCurve ? animationCurve.Evaluate(lerpAmount) : lerpAmount);
		float t2 = (useCurve ? rotateAnimationCurve.Evaluate(lerpAmount) : lerpAmount);
		if (space == UseSpace.World)
		{
			base.transform.position = Vector3.LerpUnclamped(startPos, endPos, t);
		}
		else
		{
			base.transform.localPosition = Vector3.LerpUnclamped(startPos, endPos, t);
		}
		if (rotate.magnitude > 0f)
		{
			base.transform.localRotation = Quaternion.LerpUnclamped(startRot, endRot, t2);
		}
	}

	public void Toggle()
	{
		if (open)
		{
			Close();
		}
		else
		{
			Open();
		}
	}

	public void SetNewOpen(Vector3 newMove)
	{
		endPos = startPos + newMove;
	}

	public void CalculateMovement()
	{
		if (space == UseSpace.Local)
		{
			startPos = base.transform.localPosition;
			endPos = startPos + move;
			startRot = base.transform.localRotation;
			endRot = startRot * Quaternion.Euler(rotate);
		}
		else if (space == UseSpace.LocalRelativeToSelf)
		{
			startPos = base.transform.localPosition;
			Vector3 vector = base.transform.forward * move.y + base.transform.right * move.x + base.transform.up * move.z;
			if (base.transform.parent != null)
			{
				endPos = base.transform.parent.InverseTransformPoint(base.transform.position + vector);
			}
			else
			{
				endPos = startPos + base.transform.InverseTransformPoint(vector);
			}
			startRot = base.transform.localRotation;
			endRot = startRot * Quaternion.Euler(rotate);
		}
		else
		{
			startPos = base.transform.position;
			endPos = startPos + move;
			startRot = base.transform.rotation;
			endRot = startRot * Quaternion.Euler(rotate);
		}
	}

	public bool IsOpen()
	{
		return open;
	}

	private void OnInspectorUpdate()
	{
		if (!Application.isPlaying)
		{
			CalculateMovement();
		}
	}

	public override void DrawGizmos()
	{
		if (!Application.isPlaying)
		{
			CalculateMovement();
		}
		if (space == UseSpace.World || base.transform.parent == null)
		{
			Draw.Arrow(startPos, endPos, base.transform.up, 0.5f, Color.green);
		}
		else
		{
			Draw.Arrow(base.transform.parent.TransformPoint(startPos), base.transform.parent.TransformPoint(endPos), base.transform.up, 0.5f, Color.green);
		}
		DarkMachineFunctions.RenderUnityEvent(ref Draw.editor, base.transform, new List<DarkMachineFunctions.RenderUnityEventDesc>
		{
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = openEvent,
				prependString = "On Open: ",
				color = Color.green
			},
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = closeEvent,
				prependString = "On Close: ",
				color = Color.red
			},
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = finishOpenEvent,
				prependString = "On Finish Open: ",
				color = Color.yellow
			},
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = finishCloseEvent,
				prependString = "On Finish Close: ",
				color = Color.orange
			}
		});
	}
}
