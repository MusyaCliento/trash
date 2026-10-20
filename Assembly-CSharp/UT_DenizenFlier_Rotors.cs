using System.Collections;
using DG.Tweening;
using UnityEngine;

public class UT_DenizenFlier_Rotors : MonoBehaviour
{
	public Denizen targetDenizen;

	private DenizenMovement_BasicFlier flierMovementModule;

	public float rotorAngleMult = 8f;

	public float rotorThrustMult = 1f;

	public float rotorMaxAngle = 45f;

	public float rotorMinAngle = -45f;

	public Vector3 axis = new Vector3(0f, 0f, 1f);

	public float lerpSpeed = 16f;

	public Vector3 thrustAxis = new Vector3(0f, 1f, 0f);

	public float thrust = 128f;

	private void Start()
	{
		if (!(targetDenizen == null))
		{
			Debug.Log("Getting movement module: " + targetDenizen.GetMovementModule().GetType());
			if (targetDenizen.GetMovementModule() is DenizenMovement_BasicFlier)
			{
				flierMovementModule = targetDenizen.GetMovementModule() as DenizenMovement_BasicFlier;
			}
		}
	}

	private void Update()
	{
		if (flierMovementModule != null)
		{
			float angle = flierMovementModule.GetLastAngleDifference() * rotorAngleMult + Vector3.Dot(flierMovementModule.GetLastPIDOutput(), targetDenizen.transform.forward) * rotorThrustMult;
			base.transform.localRotation = Quaternion.Lerp(base.transform.localRotation, Quaternion.AngleAxis(angle, axis), lerpSpeed * Time.deltaTime);
		}
	}

	public void ActivateThrust(float timer)
	{
		if (timer == 0f)
		{
			timer = 100f;
		}
		StartCoroutine(Thrust());
		IEnumerator Thrust()
		{
			while (timer > 0f)
			{
				targetDenizen.GetComponent<Rigidbody>().AddForceAtPosition(base.transform.TransformVector(thrustAxis) * Time.deltaTime * thrust, base.transform.position);
				timer -= Time.deltaTime;
				yield return null;
			}
		}
	}

	public void Hit(float amount = 5f)
	{
		targetDenizen.GetComponent<Rigidbody>().AddForceAtPosition(base.transform.TransformVector(-thrustAxis) * amount, base.transform.position);
		base.transform.localRotation *= Quaternion.AngleAxis(20f, axis);
		base.transform.DOShakeScale(0.5f, 0.05f);
		targetDenizen.clipHandler.PlaySound("denizen:hit", base.transform.position);
	}
}
