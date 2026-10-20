using System;
using System.Collections.Generic;
using UnityEngine;

public class VEH_Driveable : MonoBehaviour
{
	[Serializable]
	public class WheelGroups
	{
		public List<WheelCollider> wheels;

		public bool canSteer;

		public bool canMotor;

		public bool canBrake;

		public float steerAngleMult = 1f;
	}

	public float turnSpeed;

	public float moveSpeed;

	public float brakeForce;

	public float moveAcceleration = 5f;

	public float turnAcceleration = 5f;

	private float turnAmount;

	private Vector3 moveVector;

	public string moveForwardAxis = "";

	public string handbrakeButton = "Jump";

	private bool isControlled;

	private Rigidbody rigid;

	public float turnVelocityMult = 1f;

	public float turnVelocityMultMax = 1f;

	public float rightingForce = 10f;

	public List<WheelGroups> wheels;

	private void Start()
	{
		rigid = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		moveVector = Vector3.Lerp(moveVector, Vector3.zero, Time.deltaTime * moveAcceleration);
		if (isControlled && moveForwardAxis != "")
		{
			MoveForward(InputManager.GetVector(moveForwardAxis).vector.y);
		}
		if (rigid != null)
		{
			bool pressed = InputManager.GetButton(handbrakeButton).Pressed;
			foreach (WheelGroups wheel in wheels)
			{
				foreach (WheelCollider wheel2 in wheel.wheels)
				{
					if (pressed && wheel.canBrake)
					{
						wheel2.brakeTorque = brakeForce;
					}
					else if (wheel.canMotor && !pressed)
					{
						wheel2.motorTorque = moveVector.z * moveSpeed;
					}
					if (!pressed)
					{
						wheel2.brakeTorque = 0f;
					}
					if (wheel.canSteer)
					{
						wheel2.steerAngle = turnAmount * wheel.steerAngleMult;
						wheel2.transform.parent.localRotation = Quaternion.Euler(0f, 0f, wheel2.steerAngle);
					}
					wheel2.transform.localRotation *= Quaternion.Euler(wheel2.rotationSpeed * Time.fixedDeltaTime, 0f, 0f);
				}
			}
			float num = Vector3.Angle(base.transform.up, Vector3.up);
			if ((double)num > 0.001)
			{
				Vector3 vector = Vector3.Cross(base.transform.up, Vector3.up);
				rigid.AddTorque(vector * num * rightingForce);
			}
		}
		else
		{
			base.transform.position += base.transform.forward * moveVector.z * Time.deltaTime;
			base.transform.rotation *= Quaternion.Euler(0f, turnAmount * Time.deltaTime, 0f);
		}
		turnAmount = Mathf.Lerp(turnAmount, 0f, turnAcceleration * Time.deltaTime);
		if (turnAmount == float.NaN)
		{
			turnAmount = 0f;
		}
	}

	public void Turn(float amount)
	{
		turnAmount = Mathf.Lerp(turnAmount, turnSpeed * amount, turnAcceleration * Time.deltaTime);
	}

	public void MoveForward(float amount)
	{
		moveVector.z = Mathf.Lerp(moveVector.z, amount * moveSpeed, Time.deltaTime * moveAcceleration);
	}

	public void MoveUp(float amount)
	{
		moveVector.y = Mathf.Lerp(moveVector.y, amount * moveSpeed, Time.deltaTime * moveAcceleration);
	}

	public void TakeControl()
	{
		isControlled = true;
	}

	public void StopControl()
	{
		isControlled = false;
	}
}
