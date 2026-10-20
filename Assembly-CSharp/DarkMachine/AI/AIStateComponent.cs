using System;
using System.Reflection;
using UnityEngine;

namespace DarkMachine.AI
{
	[Serializable]
	public class AIStateComponent
	{
		public virtual string name => "null";

		public virtual void Initialize(AIGameEntity e, AIStateVariable[] variables, string[] args = null)
		{
			foreach (AIStateVariable aIStateVariable in variables)
			{
				SetValueById(aIStateVariable.id, aIStateVariable.data);
			}
		}

		public void SetValueById(string id, string data)
		{
			FieldInfo field = GetType().GetField(id, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field == null)
			{
				return;
			}
			Type fieldType = field.FieldType;
			try
			{
				object value = Convert.ChangeType(data, fieldType);
				field.SetValue(this, value);
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Failed to set field '" + id + "': " + ex.Message);
			}
		}

		public virtual void Enter(AIGameEntity e, string[] args = null)
		{
		}

		public virtual void Execute(AIGameEntity e, string[] args = null)
		{
		}

		public virtual void Exit(AIGameEntity e, string[] args = null)
		{
		}

		public virtual void SetTarget(Vector3 v)
		{
		}

		public virtual void SetData(string[] args)
		{
		}

		public virtual Vector3 GetLookVector()
		{
			return Vector3.zero;
		}

		public virtual bool CanEnterState()
		{
			return true;
		}

		public virtual void OnOffsetEntity(float amount)
		{
		}
	}
}
