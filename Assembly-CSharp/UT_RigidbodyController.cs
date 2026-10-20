using UnityEngine;

public class UT_RigidbodyController : MonoBehaviour
{
	private Rigidbody rigid;

	public bool copyRigidbodyVelocityOnAwake;

	public Rigidbody targetCopyRigidbody;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody>();
		if (copyRigidbodyVelocityOnAwake && (bool)targetCopyRigidbody)
		{
			rigid.linearVelocity = targetCopyRigidbody.linearVelocity;
			rigid.angularVelocity = targetCopyRigidbody.angularVelocity;
		}
	}

	public void AddForce(Vector3 v)
	{
		if (rigid == null)
		{
			rigid = GetComponent<Rigidbody>();
		}
		rigid.AddForce(v);
	}

	public void SpinX(float v)
	{
		if (rigid == null)
		{
			rigid = GetComponent<Rigidbody>();
		}
		rigid.AddTorque(new Vector3(v, 0f, 0f));
	}

	public void SpinY(float v)
	{
		if (rigid == null)
		{
			rigid = GetComponent<Rigidbody>();
		}
		rigid.AddTorque(new Vector3(0f, v, 0f));
	}

	public void SpinZ(float v)
	{
		if (rigid == null)
		{
			rigid = GetComponent<Rigidbody>();
		}
		rigid.AddTorque(new Vector3(0f, 0f, v));
	}

	public void AddLocalYVelocity(float v)
	{
		if (rigid == null)
		{
			rigid = GetComponent<Rigidbody>();
		}
		rigid.AddRelativeForce(Vector3.up * v);
	}

	public void AddLocalZVelocity(float v)
	{
		if (rigid == null)
		{
			rigid = GetComponent<Rigidbody>();
		}
		rigid.AddRelativeForce(Vector3.forward * v);
	}

	public void AddLocalXVelocity(float v)
	{
		if (rigid == null)
		{
			rigid = GetComponent<Rigidbody>();
		}
		rigid.AddRelativeForce(Vector3.right * v);
	}
}
