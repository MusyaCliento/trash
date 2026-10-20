using System;
using System.Collections.Generic;
using DitzelGames.FastIK;
using UnityEngine;
using UnityEngine.Events;

public class IK_Controller : MonoBehaviour
{
	[Serializable]
	public class IKSystems
	{
		public bool active = true;

		public string name;

		public FastIKFabric ik;

		public float blendTarget = 1f;

		private bool locked;

		private Vector3 lockPosition;

		private Quaternion lockRotation;

		public bool useRaycast;

		public LayerMask raycastLayerMask;

		public Vector3 raycastDirection = Vector3.up;

		public UnityEvent activateEvent;

		public void SetTargetPosition(Vector3 p)
		{
			ik.Target.position = p;
		}

		public void Update()
		{
			if (!active)
			{
				ik.blend = 0f;
				return;
			}
			ik.blend = Mathf.Lerp(ik.blend, blendTarget, Time.deltaTime * 5f);
			if (locked)
			{
				ik.Target.position = lockPosition;
				ik.Target.rotation = lockRotation;
			}
		}

		public void SetLockState(bool b)
		{
			locked = b;
			if (useRaycast)
			{
				FindLockSurface();
				return;
			}
			lockPosition = ik.transform.position;
			lockRotation = ik.transform.rotation;
		}

		private void FindLockSurface()
		{
			Vector3 vector = ik.transform.InverseTransformDirection(raycastDirection);
			float num = 0.5f;
			if (Physics.SphereCast(ik.transform.position - vector * (num / 2f), num, vector, out var hitInfo, 0.5f, raycastLayerMask))
			{
				lockPosition = hitInfo.point;
				return;
			}
			lockPosition = ik.transform.position;
			lockRotation = ik.transform.rotation;
		}
	}

	public UnityEvent activateIKEvent;

	public UnityEvent deactivateIKEvent;

	public List<IKSystems> iKSystems;

	private Dictionary<string, IKSystems> ikSystemsDict;

	private void Start()
	{
		ikSystemsDict = new Dictionary<string, IKSystems>();
		foreach (IKSystems iKSystem in iKSystems)
		{
			ikSystemsDict.Add(iKSystem.name, iKSystem);
		}
	}

	private void LateUpdate()
	{
		foreach (IKSystems iKSystem in iKSystems)
		{
			iKSystem.Update();
		}
	}

	public void ActivateIK(string ikName)
	{
		ikSystemsDict[ikName].blendTarget = 1f;
		ikSystemsDict[ikName].SetLockState(b: true);
		ikSystemsDict[ikName].activateEvent.Invoke();
	}

	public void DeactivateIK(string ikName)
	{
		ikSystemsDict[ikName].blendTarget = 0f;
		ikSystemsDict[ikName].SetLockState(b: false);
		deactivateIKEvent.Invoke();
	}

	public void DeactivateAllIK()
	{
		foreach (IKSystems iKSystem in iKSystems)
		{
			iKSystem.SetLockState(b: false);
			iKSystem.blendTarget = 0f;
		}
	}

	public void ResetIKTransforms()
	{
		foreach (IKSystems iKSystem in iKSystems)
		{
			iKSystem.ik.ResetTransform();
		}
	}
}
