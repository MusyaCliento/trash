using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Message_Loading : Message
{
	public Image loadingBar;

	private bool initialized;

	private bool hasFinished;

	public bool useOS = true;

	public override void Initialize(Message_Manager.Message_Packet packet)
	{
		float loadTime = float.Parse(packet.data[0], NumberStyles.Float, CultureInfo.InvariantCulture);
		textObject.text = packet.message;
		if (packet.closeFunction != null)
		{
			closeFunction = packet.closeFunction;
		}
		initialized = true;
		StartCoroutine(LoadingAnimation(loadTime));
	}

	private void OnDisable()
	{
		if (initialized && !hasFinished)
		{
			if (useOS)
			{
				OS_Manager.GetCurrentOS().SetInteractable(b: true);
			}
			CloseMessage("done");
		}
	}

	private IEnumerator LoadingAnimation(float loadTime)
	{
		float timer = 0f;
		if (useOS)
		{
			OS_Manager.GetCurrentOS().SetInteractable(b: false);
		}
		while (timer < loadTime)
		{
			timer += Time.deltaTime;
			loadingBar.material.SetFloat("_Amount", timer / loadTime);
			yield return null;
		}
		hasFinished = true;
		if (useOS)
		{
			OS_Manager.GetCurrentOS().SetInteractable(b: true);
		}
		CloseMessage("done");
	}
}
