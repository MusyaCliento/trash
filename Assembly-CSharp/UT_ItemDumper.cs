using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UT_ItemDumper : MonoBehaviour
{
	public float dumpRate = 0.1f;

	public float dumpForce = 1f;

	public int maxDumpedItems = 8;

	public List<string> destroyItemTags;

	public void Dump()
	{
		StartCoroutine(DumpAnim());
		IEnumerator DumpAnim()
		{
			List<Item> list = new List<Item>();
			list.AddRange(Inventory.instance.GetItems());
			int dumped = 0;
			List<Item> itemList = new List<Item>();
			foreach (Item item in list)
			{
				if (destroyItemTags != null && destroyItemTags.Count > 0 && item.HasTagInList(destroyItemTags))
				{
					item.Destroy();
				}
				else
				{
					itemList.Add(item);
				}
			}
			yield return null;
			foreach (Item item2 in itemList)
			{
				dumped++;
				Inventory.instance.DropItemIntoWorld(item2, ENT_Player.GetPlayer().transform.position);
				Rigidbody component = item2.GetDropObject().GetComponent<Rigidbody>();
				if (component != null)
				{
					component.AddForce(Random.insideUnitSphere * dumpForce, ForceMode.VelocityChange);
					component.angularVelocity = Random.insideUnitSphere * 15f;
					component.isKinematic = false;
				}
				if (dumped >= maxDumpedItems)
				{
					break;
				}
				yield return new WaitForSeconds(dumpRate);
			}
		}
	}
}
