using UnityEngine;
using UnityEngine.Events;

public class ENV_WarpFissure : MonoBehaviour, Blinkable
{
	public enum FissureState
	{
		none = 0,
		peeked = 1,
		open = 2,
		peered = 3
	}

	private Material fissureMaterial;

	public float fissureOpen;

	private float curFissureOpen;

	public UnityEvent onBlinkTeleport;

	public UT_AudioClipHandler clipHandler;

	private bool peeled;

	private float peelTime;

	public float fissureBrightMult = 23f;

	public UT_AudioEffects loopEffects;

	public bool blockCheats = true;

	private FissureState fissureState;

	private void Start()
	{
		fissureMaterial = GetComponent<MeshRenderer>().material;
	}

	private void Update()
	{
		curFissureOpen = Mathf.Lerp(curFissureOpen, fissureOpen, Time.deltaTime);
		fissureMaterial.SetFloat("_Depth", curFissureOpen * 13f);
		fissureMaterial.SetFloat("_Bright", curFissureOpen * 23f);
		if (peelTime > 0f && peeled)
		{
			peelTime -= Time.deltaTime;
		}
		else if (peelTime <= 0f && peeled)
		{
			OnBlinkEnd();
		}
	}

	public void SetFissureOpenAmount(float f)
	{
		fissureOpen = f;
	}

	public void PeekFissure()
	{
		if (fissureState == FissureState.none)
		{
			fissureState = FissureState.peeked;
			fissureOpen = 0.06f;
			clipHandler?.PlaySound("fissure:peek");
			loopEffects?.SetVolume(0.3f);
		}
	}

	public void OpenFissure()
	{
		if ((fissureState == FissureState.peeked || fissureState == FissureState.none) && !CheckCheated())
		{
			fissureState = FissureState.open;
			fissureOpen = 1f;
			clipHandler?.PlaySound("fissure:open");
			loopEffects?.SetVolume(0.7f);
		}
	}

	public void OnBlinkStart()
	{
		peelTime = 0.5f;
		if (fissureOpen > 0.1f && !peeled)
		{
			fissureState = FissureState.peered;
			fissureOpen = 3f;
			clipHandler?.PlaySound("fissure:peel");
			peeled = true;
			loopEffects?.SetVolume(0.8f);
		}
	}

	public void OnBlinkEnd()
	{
		if (fissureOpen > 0.1f && peeled)
		{
			fissureState = FissureState.open;
			fissureOpen = 1f;
			peeled = false;
			loopEffects?.SetVolume(0.6f);
		}
	}

	public void OnBlinkTeleport()
	{
		if (fissureOpen > 0.1f)
		{
			fissureState = FissureState.open;
			clipHandler?.PlaySound("fissure:use");
			CL_UIManager.instance.FlashVignette("whiteout");
			onBlinkTeleport.Invoke();
		}
	}

	public bool CheckCheated()
	{
		if (CommandConsole.hasCheated && blockCheats)
		{
			CL_UIManager.instance.tipHeader.ShowText("Huh? looks like you cheated or something?");
			return true;
		}
		return false;
	}
}
