using UnityEngine;

public class UT_ForceCameraLookAt : MonoBehaviour
{
	public bool active = true;

	public float lookForce = 10f;

	public float minAngle = 20f;

	[Range(0f, 1f)]
	public float normalizeBlend;

	public bool forceFOV;

	public float fov = 90f;

	public bool changePlayerSpeed;

	public float playerSpeedMult = 1f;

	private void Update()
	{
		if (active)
		{
			if (Vector3.Angle(Camera.main.transform.forward, base.transform.position - Camera.main.transform.position) > minAngle)
			{
				Vector3 normalized = (base.transform.position - (Camera.main.transform.forward + Camera.main.transform.position)).normalized;
				Vector3 vector = Camera.main.transform.forward - normalized;
				vector = Camera.main.transform.InverseTransformVector(vector);
				Vector3 a = new Vector3(vector.y, 0f - vector.x, 0f);
				float num = (InputManager.IsGamepad() ? 0.5f : 1f);
				float a2 = Vector3.Dot(-Camera.main.transform.forward, (base.transform.position - Camera.main.transform.position).normalized) + 1f;
				a = Vector3.Lerp(a, a.normalized, normalizeBlend);
				a2 = Mathf.Lerp(a2, 1f, normalizeBlend);
				ENT_Player.GetPlayer().AddQuickRotationVelocity(a * lookForce * a2 * Time.deltaTime * num);
			}
			if (forceFOV)
			{
				ENT_Player.GetPlayer().SetFOVShock(fov - ENT_Player.GetPlayer().GetCurrentFOV(), slow: true);
			}
			if (changePlayerSpeed)
			{
				ENT_Player.GetPlayer().SetFrameSpeedMult(playerSpeedMult);
			}
		}
	}

	public void SetActive(bool b)
	{
		active = b;
	}
}
