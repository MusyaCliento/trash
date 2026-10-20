using UnityEngine;

public class ItemExecutionModule_SimpleModule : ItemExecutionModule
{
	[SerializeReference]
	public SimpleModule module;

	public bool onPickupAndDrop = true;

	public bool onEnterInventory;

	public bool excludeInHand = true;

	private bool isInInventory;

	private bool hasActivated;

	public override void Initialize(Item i)
	{
		base.Initialize(i);
		if (!onPickupAndDrop && !onEnterInventory)
		{
			Activate();
		}
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		Deactivate();
	}

	public override void OnPickup()
	{
		base.OnPickup();
		if (onPickupAndDrop)
		{
			Activate();
		}
	}

	public override void OnDrop()
	{
		base.OnDrop();
		if (onPickupAndDrop)
		{
			Deactivate();
		}
	}

	public override void Execute()
	{
		base.Execute();
		module.Update();
		if (!onEnterInventory)
		{
			return;
		}
		if (excludeInHand && item.InHand())
		{
			if (isInInventory)
			{
				isInInventory = false;
				Deactivate();
			}
		}
		else if (item.InInventory())
		{
			if (!isInInventory)
			{
				isInInventory = true;
				Activate();
			}
		}
		else if (isInInventory)
		{
			isInInventory = false;
			Deactivate();
		}
	}

	private void Activate()
	{
		if (!hasActivated)
		{
			module.Activate();
			hasActivated = true;
		}
	}

	private void Deactivate()
	{
		if (hasActivated)
		{
			module.Deactivate();
			hasActivated = false;
		}
	}

	public override ItemExecutionModule GetCopy()
	{
		return new ItemExecutionModule_SimpleModule
		{
			module = module,
			onPickupAndDrop = onPickupAndDrop,
			onEnterInventory = onEnterInventory,
			excludeInHand = excludeInHand
		};
	}
}
