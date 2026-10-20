using Drawing;
using UnityEngine;

public class ENV_JumpPad : MonoBehaviourGizmos
{
	public float force = 5f;

	public AudioClip jumpSound;

	public string jumpSubtitle = "";

	public float jumpVolume = 0.5f;

	public void Jump(Transform t)
	{
		GameEntity component = t.GetComponent<GameEntity>();
		if (component == ENT_Player.GetPlayer())
		{
			AudioManager.PlaySound(jumpSound, base.transform.position, jumpVolume, 1f, 0f);
		}
		else
		{
			AudioManager.PlaySound(jumpSound, base.transform.position, jumpVolume);
		}
		if (jumpSubtitle != "")
		{
			CL_UIManager.SubtitleSimpleCreate(CL_LocalizationManager.GetLocalization(jumpSubtitle), "", CL_UIManager.SubtitleFlags.Ambient, base.transform);
		}
		if (component != null)
		{
			component.SetDirectionalForce(base.transform.up * force);
		}
		else
		{
			t.GetComponent<Rigidbody>()?.AddForce(base.transform.up * force);
		}
	}

	public override void DrawGizmos()
	{
		Draw.Arrow(base.transform.position, base.transform.position + base.transform.up * force, Color.yellow);
	}
}
