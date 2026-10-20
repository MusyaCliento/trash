using System;

[Serializable]
public class HandholdModule
{
	internal CL_Handhold handhold;

	public bool enabled = true;

	public string id = "";

	public virtual void Initialize(CL_Handhold h)
	{
		handhold = h;
	}

	public virtual void Update()
	{
	}

	public virtual void LateUpdate()
	{
	}

	public virtual bool CanInteract(ENT_Player p, ENT_Player.Hand hand)
	{
		return true;
	}

	public virtual void OnGrab(ENT_Player p, ENT_Player.Hand hand, Clickable.InteractionInfo info = null)
	{
	}

	public virtual void OnRelease(ENT_Player p, ENT_Player.Hand hand)
	{
	}

	public virtual void OnJump(ENT_Player p, ENT_Player.Hand hand, bool hasJumped = false)
	{
	}

	public virtual void OnDoubleJump(ENT_Player p, ENT_Player.Hand hand, bool hasJumped = false)
	{
	}

	public virtual void SendMessage(string message)
	{
	}
}
