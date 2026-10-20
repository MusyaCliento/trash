using System.Collections;
using System.Collections.Generic;
using Febucci.UI.Core;
using Rewired.Glyphs.UnityUI;
using TMPro;
using UnityEngine;

public class UT_TextScrawl : MonoBehaviour
{
	public string id = "";

	public static Dictionary<string, UT_TextScrawl> scrawls;

	public TypewriterCore typewriter;

	public AudioClip typeSound;

	private AudioSource aud;

	private bool typing;

	private UI_DMTextAnim dMTextAnim;

	private UnityTextMeshProGlyphHelper glyphHelper;

	private TMP_Text tmpText;

	private void Start()
	{
		aud = GetComponent<AudioSource>();
		typewriter = GetComponent<TypewriterCore>();
		if (typewriter != null)
		{
			typewriter.onCharacterVisible.AddListener(PlayTypeSound);
			typewriter.ShowText("");
		}
		dMTextAnim = GetComponent<UI_DMTextAnim>();
		glyphHelper = GetComponent<UnityTextMeshProGlyphHelper>();
		if (glyphHelper == null)
		{
			glyphHelper = base.gameObject.AddComponent<UnityTextMeshProGlyphHelper>();
		}
		tmpText = GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		if (scrawls == null)
		{
			scrawls = new Dictionary<string, UT_TextScrawl>();
		}
		if (id != "")
		{
			scrawls.Add(id, this);
		}
		if (typewriter != null)
		{
			typewriter.ShowText("");
		}
	}

	private void OnDisable()
	{
		if (id != "" && scrawls.ContainsKey(id))
		{
			scrawls.Remove(id);
		}
	}

	public static void ShowTextOnScrawl(string id, string text)
	{
		if (scrawls.ContainsKey(id))
		{
			Debug.Log("Showing Text on ID: " + id);
			scrawls[id].ShowText(text);
		}
	}

	public void ShowText(string s)
	{
		if (!(base.gameObject == null) && !(this == null) && s != null)
		{
			Debug.Log(s);
			s = DarkMachineFunctions.ProcessText(s);
			Debug.Log(s);
			string text = glyphHelper.ProcessText(s);
			Debug.Log(text);
			dMTextAnim?.ParseAndApply();
			if (typewriter != null)
			{
				typewriter.StopDisappearingText();
				typewriter.ShowText(text);
				typewriter.StartShowingText();
			}
			typing = true;
			StopAllCoroutines();
		}
	}

	public void HideText()
	{
		typewriter.StartDisappearingText();
	}

	private void Update()
	{
		if (typewriter != null && !typewriter.isShowingText && typing)
		{
			typing = false;
			StartCoroutine(DisappearWait());
		}
	}

	private IEnumerator DisappearWait()
	{
		yield return new WaitForSeconds(3f);
		typewriter.StartDisappearingText();
	}

	public void PlayTypeSound(char c)
	{
		if (!(aud == null) && !(typeSound == null))
		{
			aud.clip = typeSound;
			aud.Play();
		}
	}
}
