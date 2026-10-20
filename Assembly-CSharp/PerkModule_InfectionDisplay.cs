using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PerkModule_InfectionDisplay : PerkModule
{
	public List<string> consumeBuffIDs = new List<string> { "food" };

	public List<Sprite> counterSprites;

	public GameObject infectionRootAsset;

	public Image counterAsset;

	private GameObject meterObject;

	private List<Image> counterSpriteObjects;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		meterObject = Object.Instantiate(infectionRootAsset, CL_UIManager.instance.uiMeterLayoutRoot);
		counterSpriteObjects = new List<Image>();
	}

	public override void AddModule(int amount = 1, bool firstTime = true)
	{
		for (int i = 0; i < amount; i++)
		{
			Image image = Object.Instantiate(counterAsset, meterObject.transform);
			image.sprite = counterSprites[counterSpriteObjects.Count];
			counterSpriteObjects.Add(image);
			image.transform.DOPunchScale(Vector3.one * 0.1f, 1f);
			image.transform.DOPunchRotation(Vector3.forward * 5f, 1f, 5);
			meterObject.transform.DOPunchScale(Vector3.one * 0.05f, 1f);
		}
		base.AddModule(amount, firstTime);
	}

	public override void Update()
	{
	}

	public override void OnDestroy(Perk p)
	{
		base.OnDestroy(p);
		Object.Destroy(meterObject.gameObject);
		counterSpriteObjects = new List<Image>();
	}
}
