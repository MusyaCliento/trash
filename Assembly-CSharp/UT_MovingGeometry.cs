using UnityEngine;

public class UT_MovingGeometry : MonoBehaviour
{
	public float hitForceMult = 1f;

	private Matrix4x4 lastParentWorldMatrix;

	private Matrix4x4 currentParentWorldMatrix;

	private void Start()
	{
		currentParentWorldMatrix = base.transform.localToWorldMatrix;
		lastParentWorldMatrix = currentParentWorldMatrix;
	}

	private void Update()
	{
		lastParentWorldMatrix = currentParentWorldMatrix;
		currentParentWorldMatrix = base.transform.localToWorldMatrix;
	}

	private Vector3 GetVelocityAtPosition(Vector3 p)
	{
		Vector3 point = base.transform.InverseTransformPoint(p);
		Vector3 vector = lastParentWorldMatrix.MultiplyPoint3x4(point);
		return (currentParentWorldMatrix.MultiplyPoint3x4(point) - vector) / Time.deltaTime;
	}

	private void OnCollisionEnter(Collision collision)
	{
		ContactPoint contact = collision.GetContact(0);
		_ = contact.normal;
		Vector3 velocityAtPosition = GetVelocityAtPosition(contact.point);
		velocityAtPosition *= Mathf.Clamp01(Vector3.Dot(contact.impulse, contact.normal));
		Rigidbody component = contact.otherCollider.GetComponent<Rigidbody>();
		Debug.Log("Contact: " + contact.impulse);
		CL_DebugView.draw.Arrow(contact.point, contact.impulse + contact.point, Color.red * 50f);
		if (component != null)
		{
			component.AddForceAtPosition(velocityAtPosition * hitForceMult, contact.point);
			return;
		}
		GameEntity component2 = contact.otherCollider.GetComponent<GameEntity>();
		if (component2 != null)
		{
			component2.AddForceAtPosition(velocityAtPosition * hitForceMult, contact.point);
		}
	}

	public void OnContactCharacterController(ControllerColliderHit hit, GameEntity gE)
	{
		_ = hit.normal;
		Vector3 velocityAtPosition = GetVelocityAtPosition(gE.transform.position);
		velocityAtPosition *= Mathf.Clamp01(Vector3.Dot(velocityAtPosition, hit.normal) - 0.3f);
		gE.AddForce(velocityAtPosition);
		Debug.Log("Contact: " + velocityAtPosition);
		CL_DebugView.draw.Arrow(gE.transform.position + Vector3.down, gE.transform.position + velocityAtPosition + Vector3.down, Color.red * 400f);
	}
}
