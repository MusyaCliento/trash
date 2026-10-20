public class PerkModule_ItemRemover : PerkModule
{
	public string itemTagToRemove;

	public override void Update()
	{
		base.Update();
		Item itemByTag = Inventory.instance.GetItemByTag(itemTagToRemove);
		if (itemByTag != null)
		{
			if (itemByTag.GetHandItem() != null)
			{
				Inventory.instance.DropItemFromHand(ENT_Player.playerObject.transform.position, itemByTag.GetHandItem().hand.id);
			}
			else
			{
				Inventory.instance.DropItemIntoWorld(itemByTag, ENT_Player.playerObject.transform.position);
			}
		}
	}
}
