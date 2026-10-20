using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MathNet.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class App_FrequencyUnlocker : MonoBehaviour
{
	public Image sinWave;

	public TMP_Text frequencyText;

	public TMP_Text phaseText;

	public TMP_Text scanText;

	public float frequencyMin = 4f;

	public float frequencyMax = 50f;

	public float phaseMin = -1f;

	public float phaseMax = 1f;

	public float changeSpeed = 20f;

	public float currentFrequency = 30.02f;

	public float currentAmplitude;

	private float visualFrequency = 30.02f;

	private float visualAmplitude;

	public float frequencyRounding = 4f;

	public float amplitudeRounding = 10f;

	private bool isLockedIn;

	public float targetFrequency = 10f;

	public float targetPhase = 0.1f;

	private float holdXTime;

	private float holdYTime;

	public string unlockTargetFlag;

	public AudioClip lockInSound;

	public AudioClip clickSound;

	public AudioClip failBlinkSound;

	public AudioClip successBlinkSound;

	public AudioClip scanSound;

	public AudioClip succeedSound;

	public AudioClip failSound;

	private bool scanning;

	private OS_Window window;

	private void Start()
	{
		window = GetComponent<OS_Window>();
		if (window != null)
		{
			window.os.HideCursor();
		}
		Dictionary<string, string> dictionary = DarkMachineFunctions.ParseKeyValueString(window.file.fileInfo.data);
		if (dictionary.TryGetValue("frequency_flag", out var value))
		{
			CL_GameManager.SessionFlag gameFlag = CL_GameManager.GetGameFlag(value);
			if (gameFlag != null && float.TryParse(gameFlag.data, out var result))
			{
				targetFrequency = result;
			}
		}
		if (dictionary.TryGetValue("amplitude_flag", out var value2))
		{
			CL_GameManager.SessionFlag gameFlag2 = CL_GameManager.GetGameFlag(value2);
			if (gameFlag2 != null && float.TryParse(gameFlag2.data, out var result2))
			{
				targetPhase = result2;
			}
		}
		if (dictionary.TryGetValue("unlockFlag", out var value3))
		{
			if (CL_GameManager.HasActiveFlag(value3))
			{
				scanning = true;
				scanText.text = "LOCKED\n<size=12>PULL LEVER TO EMIT SIGNAL";
				currentFrequency = targetFrequency;
				currentAmplitude = targetPhase;
				isLockedIn = true;
				sinWave.material.SetFloat("_Polar", 1f);
			}
			unlockTargetFlag = value3;
		}
	}

	private void Update()
	{
		if (!scanning)
		{
			if (!isLockedIn && InputManager.GetButton("Jump").Down)
			{
				isLockedIn = true;
				AudioManager.PlayUISound(lockInSound);
				StartCoroutine(PerformScan());
			}
			float num = 1f;
			float x = InputManager.GetVector("Move").vector.x;
			if ((double)x < -0.5 || (double)x > 0.5)
			{
				if (holdXTime == 0f)
				{
					currentFrequency = Mathf.Round(currentFrequency * frequencyRounding) / frequencyRounding;
					currentFrequency += Mathf.Sign(x) * 0.2f;
					DOTween.Complete(frequencyText.transform);
					frequencyText.transform.DOPunchScale(Vector3.one * 0.025f, 0.5f);
					visualFrequency = currentFrequency;
					OS_Manager.soundPlayer.PlaySound("os:click");
				}
				holdXTime += Time.deltaTime;
			}
			else
			{
				holdXTime = 0f;
			}
			if (holdXTime > 0.5f)
			{
				currentFrequency = Mathf.Clamp(currentFrequency + InputManager.GetVector("Move").vector.x * changeSpeed * Time.deltaTime * num, frequencyMin, frequencyMax);
			}
			float y = InputManager.GetVector("Move").vector.y;
			if ((double)y < -0.5 || (double)y > 0.5)
			{
				if (holdYTime == 0f)
				{
					currentAmplitude = Mathf.Round(currentAmplitude * amplitudeRounding) / amplitudeRounding;
					currentAmplitude += Mathf.Sign(y) * 0.1f;
					DOTween.Complete(phaseText.transform);
					phaseText.transform.DOPunchScale(Vector3.one * 0.025f, 0.5f);
					visualAmplitude = currentAmplitude;
					OS_Manager.soundPlayer.PlaySound("os:click");
				}
				holdYTime += Time.deltaTime;
			}
			else
			{
				holdYTime = 0f;
			}
			if (holdYTime > 0.5f)
			{
				currentAmplitude = Mathf.Clamp(currentAmplitude + InputManager.GetVector("Move").vector.y * changeSpeed * Time.deltaTime * 0.1f, phaseMin, phaseMax);
			}
			currentAmplitude = Mathf.Clamp(currentAmplitude, phaseMin, phaseMax);
			currentFrequency = Mathf.Clamp(currentFrequency, frequencyMin, frequencyMax);
		}
		float b = Mathf.Round(currentFrequency * frequencyRounding) / frequencyRounding;
		float b2 = Mathf.Round(currentAmplitude * amplitudeRounding) / amplitudeRounding;
		visualFrequency = Mathf.Lerp(visualFrequency, b, Time.deltaTime * 16f);
		visualAmplitude = Mathf.Lerp(visualAmplitude, b2, Time.deltaTime * 16f);
		frequencyText.text = visualFrequency.Round(2).ToString("0.00") + " kHz";
		phaseText.text = visualAmplitude.Round(1).ToString("0.0") + "° P-Angle";
		sinWave.material.SetFloat("_Frequency", currentFrequency);
		sinWave.material.SetFloat("_Amplitude", currentAmplitude);
		sinWave.material.SetFloat("_Polar", Mathf.Lerp(sinWave.material.GetFloat("_Polar"), isLockedIn ? 1 : 0, Time.deltaTime * 2f));
	}

	private IEnumerator PerformScan()
	{
		float actualFrequency = Mathf.Round(currentFrequency * frequencyRounding) / frequencyRounding;
		float actualAmplitude = Mathf.Round(currentAmplitude * amplitudeRounding) / amplitudeRounding;
		scanning = true;
		window.os.SetInteractable(b: false);
		yield return new WaitForSeconds(0.5f);
		AudioManager.PlayUISound(clickSound, 1f, Random.Range(0.98f, 1.03f));
		scanText.text = "SCANNING";
		yield return new WaitForSeconds(1f);
		float scanAmount = 0f;
		float lastTickSound = 0f;
		while (scanAmount < 1f)
		{
			scanText.text = $"{Mathf.Round(scanAmount * 100f)}%";
			scanAmount += Time.deltaTime * 0.5f;
			lastTickSound += Time.deltaTime;
			if (scanAmount > 0.25f + Random.value * 0.4f && (actualFrequency != targetFrequency || actualAmplitude != targetPhase))
			{
				yield return new WaitForSeconds(1f);
				for (int i = 0; i < 6; i++)
				{
					scanText.text = "";
					yield return new WaitForSeconds(0.25f);
					scanText.text = "FAILURE";
					AudioManager.PlayUISound(failBlinkSound);
					yield return new WaitForSeconds(0.25f);
				}
				AudioManager.PlayUISound(failSound);
				scanning = false;
				isLockedIn = false;
				scanText.text = "";
				window.os.SetInteractable(b: true);
				yield break;
			}
			if ((double)lastTickSound > 0.1)
			{
				AudioManager.PlayUISound(clickSound, 1f, Random.Range(0.9f, 1.1f));
				lastTickSound = 0f;
			}
			yield return null;
		}
		scanText.text = "100%";
		yield return new WaitForSeconds(1f);
		for (int i = 0; i < 6; i++)
		{
			scanText.text = "";
			yield return new WaitForSeconds(0.25f);
			scanText.text = "TARGET";
			AudioManager.PlayUISound(successBlinkSound);
			yield return new WaitForSeconds(0.25f);
		}
		yield return new WaitForSeconds(1f);
		AudioManager.PlayUISound(succeedSound);
		window.os.SetInteractable(b: true);
		scanText.text = "LOCKED\n<size=12>PULL LEVER TO EMIT SIGNAL";
		if (unlockTargetFlag != "")
		{
			CL_GameManager.SetGameFlag(unlockTargetFlag, state: true, "", save: true);
		}
		if (window != null)
		{
			window.os.worldInterface.GetEventController().PlayEvent("unlock");
		}
	}
}
