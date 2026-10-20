public abstract class Item_Data_Text : Item_Data
{
	public virtual string GetText()
	{
		return "Null";
	}

	public override string GetDataType()
	{
		return "text";
	}
}
