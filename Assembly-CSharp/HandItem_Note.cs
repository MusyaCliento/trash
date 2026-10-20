using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandItem_Note : HandItem
{
	public List<Sprite> noteImages;

	public Transform handRoot;

	public SpriteRenderer noteObject;

	public SpriteRenderer foregroundFingerObject;

	public TMP_Text text;

	private bool isUsing;

	private Vector3 noteStartScale;

	private Vector3 noteStartPosition;

	public float useScale = 1.5f;

	private float zPos;

	private UT_AudioClipHandler clipHandler;

	public static HandItem_Note currentActiveNote;

	public override void Initialize(Item i, ENT_Player.Hand h)
	{
		base.Initialize(i, h);
		List<Item_Data_Text> allDataModulesByType = item.GetAllDataModulesByType<Item_Data_Text>();
		string text = "";
		text = ((allDataModulesByType != null && allDataModulesByType.Count != 0) ? allDataModulesByType[0].GetText() : item.GetFirstDataStringByType("text", returnEverythingAfterType: true));
		List<Item_Data_HandSprite> allDataModulesByType2 = item.GetAllDataModulesByType<Item_Data_HandSprite>();
		if (allDataModulesByType2 != null && allDataModulesByType2.Count > 0)
		{
			noteObject.sprite = allDataModulesByType2[0].handSprite;
		}
		text = DarkMachineFunctions.ProcessText(text);
		this.text.text = text.TrimStart();
		if (base.transform.localScale.x < 0f)
		{
			noteObject.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		noteStartPosition = handRoot.localPosition;
		noteStartScale = handRoot.localScale;
		if (h.id == 0)
		{
			zPos = -0.05f;
		}
		clipHandler = GetComponent<UT_AudioClipHandler>();
	}

	public override void Use()
	{
		base.Use();
		isUsing = true;
		currentActiveNote = this;
		if (clipHandler != null)
		{
			clipHandler.PlaySound("note:examine");
		}
	}

	public override void StopUse()
	{
		base.StopUse();
		isUsing = false;
		if (currentActiveNote == this)
		{
			currentActiveNote = null;
		}
		if (clipHandler != null)
		{
			clipHandler.PlaySound("note:examine");
		}
	}

	public override void Update()
	{
		if (isUsing && currentActiveNote == this)
		{
			Vector3 vector = ENT_Player.playerObject.cam.transform.forward * zPos;
			handRoot.position = Vector3.Lerp(handRoot.position, ENT_Player.playerObject.cam.transform.position + ENT_Player.playerObject.cam.transform.forward + vector, Time.deltaTime * 5f);
			handRoot.localScale = Vector3.Lerp(handRoot.localScale, noteStartScale * useScale, Time.deltaTime * 5f);
			foregroundFingerObject.color = new Color(foregroundFingerObject.color.r, foregroundFingerObject.color.g, foregroundFingerObject.color.b, Mathf.Lerp(foregroundFingerObject.color.a, 0.6f, Time.deltaTime * 2f));
		}
		else
		{
			handRoot.localPosition = Vector3.Lerp(handRoot.localPosition, noteStartPosition, Time.deltaTime * 5f);
			handRoot.localScale = Vector3.Lerp(handRoot.localScale, noteStartScale, Time.deltaTime * 5f);
			foregroundFingerObject.color = new Color(foregroundFingerObject.color.r, foregroundFingerObject.color.g, foregroundFingerObject.color.b, Mathf.Lerp(foregroundFingerObject.color.a, 1f, Time.deltaTime * 2f));
		}
	}
}
