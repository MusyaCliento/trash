using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class UT_ShatterProp : MonoBehaviour
{
	public float shatterStrength = 1f;

	public float shatterRandomDirectionalStrength;

	public float shatterRandomAngularStrength;

	public Vector3 shatterDirectionalStrength;

	public float lifeTime = 5f;

	private float curLifetime;

	public bool shatterOnStart = true;

	private bool shattered;

	public float shatterDelay;

	public float shatterSoundVolume = 0.7f;

	public List<AudioClip> shatterSounds;

	public UnityEvent shatterEvent;

	private Rigidbody[] childRigidbodies;

	private void Start()
	{
		if (shatterOnStart)
		{
			Shatter();
		}
	}

	private void Update()
	{
		if (shattered)
		{
			curLifetime += Time.deltaTime;
			Rigidbody[] array = childRigidbodies;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 0.1f, curLifetime / lifeTime);
			}
			if (curLifetime > lifeTime)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}

	public void Shatter()
	{
		if (shatterDelay <= 0f)
		{
			FinishShatter();
		}
		else
		{
			StartCoroutine(ShatterDelay());
		}
		IEnumerator ShatterDelay()
		{
			yield return new WaitForSeconds(shatterDelay);
			FinishShatter();
		}
	}

	private void FinishShatter()
	{
		childRigidbodies = GetComponentsInChildren<Rigidbody>();
		Rigidbody[] array = childRigidbodies;
		foreach (Rigidbody obj in array)
		{
			obj.isKinematic = false;
			Vector3 normalized = (obj.transform.position - base.transform.position).normalized;
			obj.AddForce(normalized * shatterStrength + Random.insideUnitSphere * shatterRandomDirectionalStrength + base.transform.TransformVector(shatterDirectionalStrength));
			obj.AddTorque(Random.insideUnitSphere * shatterRandomAngularStrength);
			if (obj.TryGetComponent<MeshCollider>(out var component) && !component.convex)
			{
				component.convex = true;
			}
		}
		shattered = true;
		if (shatterSounds != null && shatterSounds.Count > 0)
		{
			AudioManager.PlaySound(shatterSounds[Random.Range(0, shatterSounds.Count)], base.transform.position, shatterSoundVolume);
		}
		shatterEvent.Invoke();
	}

	public void SetupChildren()
	{
		foreach (Transform item in base.transform)
		{
			Rigidbody rigidbody = item.GetComponent<Rigidbody>();
			if (rigidbody == null)
			{
				rigidbody = item.AddComponent<Rigidbody>();
			}
			rigidbody.isKinematic = true;
			if (!item.GetComponent<Collider>())
			{
				item.AddComponent<MeshCollider>().convex = false;
			}
		}
	}

	public void SetupBreakable()
	{
		SetupChildren();
		UT_Damage orAddComponent = base.gameObject.GetOrAddComponent<UT_Damage>();
		base.gameObject.GetOrAddComponent<ObjectTagger>().AddTag("Damageable");
		if (orAddComponent.KillEvent == null)
		{
			orAddComponent.KillEvent = new UnityEvent();
		}
		orAddComponent.KillEvent.AddListener(Shatter);
		orAddComponent.killType = UT_Damage.KillType.nothing;
		foreach (Transform item in base.transform)
		{
			item.gameObject.GetOrAddComponent<UT_Damage_Passthrough>().damageable = orAddComponent;
			item.GetOrAddComponent<ObjectTagger>().AddTag("Damageable");
		}
	}
}
