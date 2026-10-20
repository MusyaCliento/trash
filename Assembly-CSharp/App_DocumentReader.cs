using System.Collections.Generic;
using DarkMachine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class App_DocumentReader : MonoBehaviour
{
	private OS_Window window;

	public TMP_Text text;

	public TMP_Text pageCounter;

	public Button rightButton;

	public Button leftButton;

	private RectTransform rectTransform;

	private List<string> pages;

	private int curPage;

	[Header("Sound Player Info")]
	public SubmitSlider playerSlider;

	private AudioSource audioSource;

	public Button playButton;

	public Sprite playIcon;

	public Sprite pauseIcon;

	public Image playButtonImage;

	public AudioClip loadedClip;

	public TMP_Text clipTimerText;

	public Image imageDisplay;

	private void Start()
	{
		window = GetComponent<OS_Window>();
		string text = "";
		text = ((!(window.file.fileInfo.textAssetData == null)) ? window.file.fileInfo.textAssetData.text : window.file.fileInfo.data);
		text = DarkMachineFunctions.ProcessText(text);
		pages = new List<string> { text };
		audioSource = GetComponent<AudioSource>();
		text = text.Replace('’', '\'');
		if (text.Contains("</page>"))
		{
			pages = new List<string>();
			pages.AddRange(text.Split("</page>"));
		}
		if (pages[0].Contains("AudioClip:"))
		{
			string[] array = pages[0].Split(":");
			if (array != null && array.Length > 1)
			{
				Debug.Log("Document Reader - Loading Clip @ " + array[1]);
				loadedClip = Resources.Load<AudioClip>(array[1]);
				Debug.Log("Load Succeeded: " + loadedClip != null);
			}
			playerSlider.SetValueWithoutNotify(0f);
			pages.RemoveAt(0);
			audioSource.clip = loadedClip;
			audioSource.PlayDelayed(0.5f);
		}
		for (int i = 0; i < pages.Count; i++)
		{
			if (pages[i].Length > 0)
			{
				pages[i] = pages[i].TrimStart();
			}
		}
		UpdatePageData();
		rectTransform = GetComponent<RectTransform>();
		UpdateButtons();
	}

	public void ChangePage(int i)
	{
		if (curPage + i >= 0 && curPage + i < pages.Count)
		{
			curPage += i;
			UpdatePageData();
			OS_Manager.soundPlayer.PlaySound("os:click");
			UpdateButtons();
		}
	}

	public void UpdatePageData()
	{
		if (imageDisplay != null && pages[curPage].Contains("Image:"))
		{
			string[] array = pages[curPage].Split(":");
			if (array != null && array.Length > 1)
			{
				Debug.Log("Document Reader - Loading Image @ " + array[1]);
				Sprite sprite = Resources.Load<Sprite>(array[1]);
				Debug.Log("Load Succeeded: " + sprite != null);
				imageDisplay.sprite = sprite;
				imageDisplay.enabled = true;
			}
			text.text = "";
		}
		else
		{
			text.text = pages[curPage];
			imageDisplay.enabled = false;
		}
	}

	private void UpdateButtons()
	{
		if (pages.Count > 1)
		{
			pageCounter.text = $"Page {curPage + 1}/{pages.Count}";
		}
		else
		{
			pageCounter.text = "";
		}
		if (curPage + 1 >= pages.Count)
		{
			rightButton.gameObject.SetActive(value: false);
		}
		else
		{
			rightButton.gameObject.SetActive(value: true);
		}
		if (curPage - 1 < 0)
		{
			leftButton.gameObject.SetActive(value: false);
		}
		else
		{
			leftButton.gameObject.SetActive(value: true);
		}
	}

	public void PlayToggle()
	{
		if (audioSource == null || loadedClip == null)
		{
			return;
		}
		if (audioSource.isPlaying)
		{
			audioSource.Pause();
			playButtonImage.sprite = playIcon;
			return;
		}
		if (audioSource.time != 0f)
		{
			audioSource.UnPause();
		}
		else
		{
			audioSource.Play();
		}
		playButtonImage.sprite = pauseIcon;
	}

	public void SetTime(float f)
	{
		if (!(audioSource == null) && !(loadedClip == null))
		{
			audioSource.time = Mathf.Lerp(0f, audioSource.clip.length, f);
		}
	}

	private void Update()
	{
		if (audioSource != null)
		{
			if (audioSource.isPlaying && loadedClip != null)
			{
				playerSlider.SetValueWithoutNotify(audioSource.time / audioSource.clip.length);
				clipTimerText.text = DarkMachineFunctions.SecondsToTimeString(audioSource.time) + " : " + DarkMachineFunctions.SecondsToTimeString(audioSource.clip.length);
			}
			if (audioSource.isPlaying)
			{
				playButtonImage.sprite = pauseIcon;
			}
			else
			{
				playButtonImage.sprite = playIcon;
			}
		}
	}
}
