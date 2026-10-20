using System;

[Serializable]
public abstract class ItemExecutionModule
{
	internal Item item;

	public virtual void Initialize(Item i)
	{
		item = i;
	}

	public virtual void OnPickup()
	{
	}

	public virtual void OnDrop()
	{
	}

	public virtual void Execute()
	{
	}

	public virtual void OnDestroy()
	{
	}

	public virtual void SendMessage(string m)
	{
	}

	public abstract ItemExecutionModule GetCopy();
}
