using System;
using UnityEngine;

public class DebugCameraController : MonoBehaviour
{
	public float speed = 10f;

	private float turnSpeed = 1f;

	public float smoothMovement = 1f;

	private Vector3 targetRotation;

	private Vector3 targetMovement;

	private Camera cam;

	private bool active;

	private void Start()
	{
		cam = GetComponent<Camera>();
		CommandConsole.BuildCommand("freecam", ToggleActive).Description("(enabled=toggle)\n<i><b><u>Controls:</u></b>\nWASD/Left Stick: Movement\nSpace/F/LT/RT: Altitude\nScroll: Adjust Fly Speed\nScroll + Left Alt: Adjust Camera Rotation Speed\nScroll + Left Shift: Adjust Camera FOV\nQ: Fine Adjust Modifier</i>").OverValue(() => active);
		CommandConsole.BuildCommand("freecam-setfov", SetFreecamFOV).Description("(fov=amount)").OverValue(() => cam.fieldOfView);
		CommandConsole.BuildCommand("freecam-setspeed", SetFreecamSpeed).Description("(speed=amount)").OverValue(() => speed);
		CommandConsole.BuildCommand("freecam-setturnspeed", SetFreecamTurnSpeed).Description("(turnspeed=amount)").OverValue(() => turnSpeed);
		CommandConsole.BuildCommand("freecam-smoothmovement", SetFreecamSmoothMovement).Description("(smoothmovement=amount)").OverValue(() => smoothMovement);
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (active && !CommandConsole.IsConsoleVisible())
		{
			float axis = Input.GetAxis("Mouse ScrollWheel");
			float num = (Input.GetKey(KeyCode.Q) ? 0.25f : 1f);
			if (Input.GetKey(KeyCode.LeftAlt))
			{
				turnSpeed = Mathf.Clamp(turnSpeed + axis * Time.unscaledDeltaTime * 100f * num, 0f, 100f);
			}
			else if (Input.GetKey(KeyCode.LeftShift))
			{
				cam.fieldOfView += axis * Time.unscaledDeltaTime * 10000f * num;
			}
			else
			{
				speed = Mathf.Max(speed + axis * 1000f * Time.unscaledDeltaTime * num, 0f);
			}
			Vector3 vector = new Vector3(InputManager.GetVector("Move").vector.x, InputManager.GetVector("Move").vector.y, 0f);
			Vector3 vector2 = base.transform.forward * vector.y + base.transform.right * vector.x;
			vector2 += Vector3.up * InputManager.GetVector("Fly").vector.x;
			vector2 = Vector3.ClampMagnitude(vector2, 1f);
			targetMovement = Vector3.Lerp(targetMovement, vector2, Time.unscaledDeltaTime * 4f / smoothMovement);
			base.transform.position += targetMovement * Time.unscaledDeltaTime * speed;
			Vector2 vector3 = InputManager.GetLookVector() * turnSpeed;
			_ = targetRotation;
			targetRotation = new Vector3(targetRotation.x - vector3.y, targetRotation.y + vector3.x, 0f);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(targetRotation), Time.unscaledDeltaTime * 2f / smoothMovement);
		}
	}

	public void ToggleActive(string[] args)
	{
		if (args.Length == 0)
		{
			active = !active;
		}
		else
		{
			if (!bool.TryParse(args[0], out var _))
			{
				CommandConsole.Log("Unable to parse " + args[0] + " arg needs to be a boolean (true/false).");
				return;
			}
			active = Convert.ToBoolean(args[0]);
		}
		CL_GameManager.gMan.freecam = active;
		cam.enabled = active;
		base.gameObject.SetActive(active);
		GetComponent<AudioListener>().enabled = active;
		base.transform.position = Camera.main.transform.position;
		base.transform.rotation = Camera.main.transform.rotation;
		CommandConsole.Log("Free Camera set to " + active);
	}

	public void SetFreecamFOV(string[] args)
	{
		if (args.Length == 0)
		{
			cam.fieldOfView = 90f;
			return;
		}
		float result = 90f;
		float.TryParse(args[0], out result);
		cam.fieldOfView = result;
	}

	public void SetFreecamSpeed(string[] args)
	{
		if (args.Length != 0)
		{
			float.TryParse(args[0], out speed);
		}
	}

	public void SetFreecamTurnSpeed(string[] args)
	{
		if (args.Length != 0)
		{
			float.TryParse(args[0], out turnSpeed);
		}
	}

	public void SetFreecamSmoothMovement(string[] args)
	{
		if (args.Length != 0)
		{
			float.TryParse(args[0], out smoothMovement);
			if (smoothMovement <= 0f)
			{
				smoothMovement = 0.01f;
			}
		}
	}
}
