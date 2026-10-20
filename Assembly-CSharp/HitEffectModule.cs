using System;
using UnityEngine;

[Serializable]
public class HitEffectModule
{
	public struct Desc
	{
		public Transform target;

		public Vector3 position;

		public Vector3 normal;
	}

	public virtual void OnHit(in Desc desc)
	{
	}
}
