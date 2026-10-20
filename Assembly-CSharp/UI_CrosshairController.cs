using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CrosshairController : MonoBehaviour
{
	[Serializable]
	public struct Crosshair
	{
		public string id;

		public Sprite sprite;

		public Image crosshairImage;

		public float size;

		internal void SetSprite(Sprite s)
		{
			sprite = s;
			crosshairImage.sprite = s;
		}
	}

	public Transform handsRoot;

	public Transform crosshairRoot;

	public Material crosshairMaterial;

	public List<Crosshair> crosshairs;

	public Dictionary<string, Crosshair> crosshairDict;

	public List<Sprite> crosshairSprites;

	private bool focusSpriteActive;

	private float focusInterpTime = 0.13f;

	private float focusTimeBegan;

	private void Awake()
	{
		crosshairDict = new Dictionary<string, Crosshair>();
		foreach (Crosshair crosshair in crosshairs)
		{
			AddCrosshair(crosshair);
		}
	}

	private void OnEnable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
		Refresh();
	}

	private void OnDisable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
	}

	private void Refresh()
	{
		handsRoot.localScale = Vector3.one * (float)SettingsManager.settings.handIconScale;
		crosshairRoot.localScale = Vector3.one * (float)SettingsManager.settings.crosshairScale;
		crosshairDict["base"].SetSprite(crosshairSprites[SettingsManager.settings.crosshair]);
	}

	private void Update()
	{
		Crosshair crosshair = crosshairDict["focus"];
		float a = ((!focusSpriteActive) ? 1 : 0);
		float b = (focusSpriteActive ? 1 : 0);
		float num = Mathf.Lerp(a, b, (Time.time - focusTimeBegan) / focusInterpTime);
		float num2 = num * num * num * crosshair.size;
		crosshair.crosshairImage.rectTransform.localScale = new Vector3(num2, num2, 1f);
	}

	public void SetCrosshairVisibility(bool b)
	{
		crosshairRoot.gameObject.SetActive(b);
	}

	public void SetCrosshairFocus(bool state, bool instant = false)
	{
		if (focusSpriteActive != state)
		{
			float num = float.PositiveInfinity;
			if (!instant)
			{
				num = Time.time;
			}
			focusSpriteActive = state;
			focusTimeBegan = num;
		}
	}

	public Crosshair AddCrosshair(string id, Sprite sprite, float size = 64f)
	{
		Crosshair newCrosshair = new Crosshair
		{
			id = id,
			sprite = sprite,
			size = size
		};
		return AddCrosshair(newCrosshair);
	}

	public Crosshair AddCrosshair(Crosshair newCrosshair)
	{
		if (crosshairDict.ContainsKey(newCrosshair.id))
		{
			return crosshairDict[newCrosshair.id];
		}
		GameObject gameObject = new GameObject("crosshair:" + newCrosshair.id);
		gameObject.transform.parent = crosshairRoot;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = Vector3.one * newCrosshair.size;
		newCrosshair.crosshairImage = gameObject.AddComponent<Image>();
		newCrosshair.crosshairImage.material = crosshairMaterial;
		newCrosshair.crosshairImage.sprite = newCrosshair.sprite;
		newCrosshair.crosshairImage.rectTransform.sizeDelta = Vector3.one;
		crosshairDict.Add(newCrosshair.id, newCrosshair);
		return newCrosshair;
	}

	public void RemoveCrosshair(string id)
	{
		if (crosshairDict.TryGetValue(id, out var value))
		{
			UnityEngine.Object.Destroy(value.crosshairImage.gameObject);
			crosshairDict.Remove(id);
		}
	}
}
