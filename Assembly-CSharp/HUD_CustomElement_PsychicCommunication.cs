using System.Collections;
using DG.Tweening;
using Febucci.UI;
using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.UI;

public class HUD_CustomElement_PsychicCommunication : HUD_CustomElement
{
	public TypewriterCore subtitleText;

	public Image mainRenderer;

	private void Awake()
	{
		mainRenderer.material.SetFloat("_Darken", -1f);
		mainRenderer.material.SetFloat("_SpriteBlend", 0f);
		subtitleText.TextAnimator.SetText("");
	}

	public HUD_CustomElement_PsychicCommunication Show(float time = 5f, float darken = 0.05f)
	{
		StopAllCoroutines();
		DOTween.Kill(mainRenderer.material);
		StartCoroutine(ShowAnimation());
		return this;
		IEnumerator ShowAnimation()
		{
			mainRenderer.material.DOFloat(1f, "_Blend", 1.5f).OnComplete(delegate
			{
				mainRenderer.material.DOFloat(0.5f, "_Blend", 2f);
			});
			yield return mainRenderer.material.DOFloat(darken, "_Darken", 1.5f).WaitForCompletion();
			if (time > 0f)
			{
				yield return new WaitForSeconds(time);
			}
			Hide();
		}
	}

	public HUD_CustomElement_PsychicCommunication Hide()
	{
		StopAllCoroutines();
		DOTween.Kill(mainRenderer.material);
		subtitleText.StartDisappearingText();
		StartCoroutine(HideAnimation());
		return this;
		IEnumerator HideAnimation()
		{
			mainRenderer.material.DOFloat(0f, "_Blend", 2f);
			yield return mainRenderer.material.DOFloat(-1f, "_Darken", 2f).WaitForCompletion();
			subtitleText.TextAnimator.SetText("");
		}
	}

	public HUD_CustomElement_PsychicCommunication PlaySubtitle(string text)
	{
		text = DarkMachineFunctions.ProcessText(text);
		subtitleText.StopShowingText();
		subtitleText.ShowText(text);
		TextAnimator_TMP tmpText = subtitleText.GetComponent<TextAnimator_TMP>();
		string startString = tmpText.textFull.ToLower();
		string rand = "abcdefghijklmnopqrstuvwxyz";
		float delay = 0.15f;
		float timer = 2f;
		StartCoroutine(Descrambler());
		return this;
		IEnumerator Descrambler()
		{
			float scrambleTime = 0f;
			while (scrambleTime < 1f)
			{
				scrambleTime += delay / timer;
				string text2 = "";
				for (int i = 0; i < startString.Length; i++)
				{
					text2 = ((!(Random.value <= scrambleTime) && rand.Contains(startString[i])) ? (text2 + rand[Random.Range(0, rand.Length)]) : (text2 + startString[i]));
				}
				tmpText.SwapTextButKeepAnimation(text2);
				yield return new WaitForSeconds(delay);
			}
		}
	}

	public HUD_CustomElement_PsychicCommunication ShowImage(Sprite sprite, float fadeTime = 2f, float holdTime = 1f)
	{
		mainRenderer.sprite = sprite;
		StartCoroutine(ImageAnimation());
		return this;
		IEnumerator ImageAnimation()
		{
			yield return mainRenderer.material.DOFloat(1f, "_SpriteBlend", fadeTime).WaitForCompletion();
			yield return new WaitForSeconds(holdTime);
			yield return mainRenderer.material.DOFloat(0f, "_SpriteBlend", fadeTime).WaitForCompletion();
		}
	}

	public HUD_CustomElement_PsychicCommunication PlayAudio(AudioClip clip, float flareMult = 1f)
	{
		StartCoroutine(ClipAnimation());
		return this;
		IEnumerator ClipAnimation()
		{
			float clipLength = clip.length;
			float t = 0f;
			AudioManager.PlaySound(clip, base.transform.position, 0.6f, 1f, 0f);
			while (t < clipLength)
			{
				t += Time.deltaTime;
				mainRenderer.material.SetFloat("_FlareAmount", 0.6f + (Mathf.Sin(Time.time * 8f) + 1f) * flareMult * 2f);
				yield return null;
			}
			mainRenderer.material.SetFloat("_FlareAmount", 0.7f);
		}
	}
}
