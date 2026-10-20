using System.Collections.Generic;
using UnityEngine;

public class FX_RunningLightFlare : MonoBehaviour
{
	public float onTime = 1f;

	public float offTime = 1f;

	public float changeRate = 3f;

	public float blinkOffset;

	public float randomOffset;

	public float randomBright;

	private float blinkTime;

	private bool blinkState;

	[SerializeField]
	private bool faceCamera = true;

	private SpriteRenderer sprite;

	private Color color;

	internal int flareIndex = -1;

	private void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
		color = sprite.color;
		color.a *= Random.Range(1f - randomBright, 1f);
	}

	private void OnEnable()
	{
		blinkTime = blinkOffset + Random.Range(0f, randomOffset);
		if (faceCamera && flareIndex == -1)
		{
			flareIndex = FXManager.runningLightFlares.Count;
			FXManager.runningLightFlares.Add(this);
		}
	}

	private void OnDisable()
	{
		if (flareIndex != -1 && FXManager.runningLightFlares[flareIndex] != this)
		{
			Debug.LogError("Exception: Mismatch in flare index. Wtf.");
		}
		if (flareIndex != -1 && FXManager.runningLightFlares[flareIndex] == this)
		{
			List<FX_RunningLightFlare> runningLightFlares = FXManager.runningLightFlares;
			int index = flareIndex;
			List<FX_RunningLightFlare> runningLightFlares2 = FXManager.runningLightFlares;
			runningLightFlares[index] = runningLightFlares2[runningLightFlares2.Count - 1];
			FXManager.runningLightFlares[flareIndex].flareIndex = flareIndex;
			FXManager.runningLightFlares.RemoveAt(FXManager.runningLightFlares.Count - 1);
			flareIndex = -1;
		}
	}

	private void Update()
	{
		UpdateBlinkState();
	}

	public void ResetBlinkTimer()
	{
		blinkTime = blinkOffset + Random.Range(0f, randomOffset);
	}

	public void UpdateBlinkState()
	{
		blinkTime -= Time.deltaTime;
		if (blinkTime <= 0f)
		{
			blinkState = !blinkState;
			blinkTime = (blinkState ? onTime : offTime);
			if (blinkState && onTime == 0f)
			{
				blinkState = false;
			}
			else if (!blinkState && offTime == 0f)
			{
				blinkState = true;
			}
		}
		sprite.color = Color.Lerp(sprite.color, blinkState ? color : Color.clear, Time.deltaTime * changeRate);
	}

	public bool GetBlinkState()
	{
		return blinkState;
	}

	public void SetColor(Color c)
	{
		color = c;
	}
}
