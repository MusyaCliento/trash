public class SimpleModule_GivePlayerPouch : SimpleModule
{
	public bool removePouch;

	public override void Activate()
	{
		base.Activate();
		if (removePouch)
		{
			Inventory.instance.RemoveExtraPouch();
		}
		else
		{
			Inventory.instance.AddExtraPouch();
		}
	}
}
