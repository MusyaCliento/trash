using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UT_Intro : MonoBehaviour
{
	public string loadScene;

	private VideoPlayer video;

	private float videoTime;

	private bool hasSkipped;

	public UnityEvent onSkip;

	public UnityEvent onEnd;

	private AsyncOperation loadMenuOperation;

	public TMP_Text loadPercentageText;

	private void Start()
	{
		video = GetComponent<VideoPlayer>();
		videoTime = (float)video.length + 1f;
		StartCoroutine(StartProcess());
		IEnumerator StartProcess()
		{
			loadPercentageText.transform.parent.gameObject.SetActive(value: false);
			yield return null;
			loadPercentageText.transform.parent.gameObject.SetActive(value: true);
			yield return null;
			loadPercentageText.transform.parent.gameObject.SetActive(value: false);
			loadMenuOperation = SceneManager.LoadSceneAsync(loadScene);
			loadMenuOperation.allowSceneActivation = false;
		}
	}

	private void Update()
	{
		if (!hasSkipped)
		{
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump") || Input.anyKeyDown)
			{
				EndIntro();
			}
			else if (videoTime <= 0f)
			{
				EndIntro();
			}
			videoTime -= Time.deltaTime;
		}
	}

	private void EndIntro()
	{
		video.Stop();
		hasSkipped = true;
		loadPercentageText.transform.parent.gameObject.SetActive(value: true);
		loadPercentageText.text = "Loading: 0%";
		StartCoroutine(WaitOneFrame());
		IEnumerator WaitOneFrame()
		{
			yield return new WaitForSeconds(0.1f);
			onEnd.Invoke();
			yield return new WaitForSeconds(0.1f);
			while (!loadMenuOperation.isDone)
			{
				loadPercentageText.text = $"Loading: {Mathf.RoundToInt(loadMenuOperation.progress * 100f)}%";
				yield return null;
				yield return null;
				if ((double)loadMenuOperation.progress >= 0.89)
				{
					loadMenuOperation.allowSceneActivation = true;
				}
			}
			loadPercentageText.text = $"Loading: {Mathf.RoundToInt(loadMenuOperation.progress * 100f)}%";
			loadMenuOperation.allowSceneActivation = true;
		}
	}
}
