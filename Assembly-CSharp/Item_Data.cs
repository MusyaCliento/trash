using System;

[Serializable]
public abstract class Item_Data
{
	internal Item item;

	public virtual void Initialize(Item i)
	{
		item = i;
	}

	public virtual string GetDataType()
	{
		return "null";
	}

	public virtual void OnPickup()
	{
	}

	public virtual void OnDrop()
	{
	}

	public virtual string GetSaveData()
	{
		return "null";
	}

	public virtual void LoadSaveData(string s)
	{
	}
}
