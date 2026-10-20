public class HandItem_Food : HandItem
{
	public Item_Object usedObject;

	private bool inUse;

	public float gripAmountAdded = 10f;

	public float healAmount = 2f;

	public bool useBuff;

	public BuffContainer buff;

	public override void Initialize(Item i, ENT_Player.Hand h)
	{
		base.Initialize(i, h);
		if (used)
		{
			anim.SetBool("Empty", value: true);
		}
	}

	public void Eat()
	{
		hand.GetPlayer().AddGripStrength(gripAmountAdded);
		hand.GetPlayer().OnEat("food");
		hand.GetPlayer().Heal(healAmount);
		item.SetUsed(b: true);
		item.SetItemAsset(usedObject);
		if (useBuff)
		{
			buff.Initialize();
		}
		CL_GameManager.gMan.localPlayer.Buff(buff);
		UpdateStats();
	}

	public override void Use()
	{
		base.Use();
		if (used)
		{
			anim.SetBool("Empty", value: true);
		}
		else
		{
			anim.SetTrigger("Eat");
			anim.SetBool("Empty", value: true);
			used = true;
			inUse = true;
		}
		if (active)
		{
			_ = used;
		}
	}

	public void FinishEating()
	{
		inUse = false;
	}

	public override bool CanDrop(bool pocket = false)
	{
		return !inUse;
	}
}
