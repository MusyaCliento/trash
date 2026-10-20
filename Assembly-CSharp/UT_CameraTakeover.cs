using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UT_CameraTakeover : MonoBehaviour
{
	private ENT_Player player;

	private Camera cam;

	private bool active;

	public float speed = 5f;

	public float fov = 90f;

	public UnityEvent activateEvent;

	public UnityEvent deactivateEvent;

	public bool isTakingOver;

	private void Start()
	{
		player = CL_GameManager.gMan.localPlayer;
		cam = player.cam;
	}

	private void Update()
	{
		if (!CL_GameManager.gMan.isPaused && active)
		{
			cam.transform.position = Vector3.Lerp(cam.transform.position, base.transform.position, Time.deltaTime * speed);
			cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, base.transform.rotation, Time.deltaTime * speed);
			cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, Time.deltaTime * speed);
		}
	}

	public void TakeoverCamera()
	{
		player.Lock();
		active = true;
		activateEvent.Invoke();
		isTakingOver = true;
	}

	public void EndTakeover()
	{
		active = false;
		deactivateEvent.Invoke();
		isTakingOver = false;
		player.UnLock();
	}

	private IEnumerator LerpBack()
	{
		float timer = 0f;
		while (timer < 1f)
		{
			timer += Time.deltaTime * speed;
			cam.transform.position = Vector3.Lerp(base.transform.position, player.GetCameraTargetPosition(), timer);
			cam.transform.rotation = Quaternion.Lerp(base.transform.rotation, player.GetCameraTargetRotation(), timer);
			cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, player.GetCurrentFOV(), timer);
			yield return new WaitForEndOfFrame();
		}
		isTakingOver = false;
		player.UnLock();
	}
}
