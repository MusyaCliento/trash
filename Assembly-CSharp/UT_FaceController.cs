using UnityEngine;

public class UT_FaceController : MonoBehaviour
{
	public void SetAvoidPlayer(bool b)
	{
		DEN_Face.SetAvoidPlayer(b);
	}

	public void SetActive(bool b)
	{
		DEN_Face.SetActive(b);
	}

	public void ChangeFaceState(string s)
	{
		DEN_Face.ChangeFaceState(s);
	}

	public void StartHunt()
	{
		DEN_Face.StartHunt();
	}

	public void StartStalk(bool b)
	{
		DEN_Face.StartStalk();
	}

	public void StartDive(bool b)
	{
		DEN_Face.StartDive();
	}

	public void DestroyFace()
	{
		DEN_Face.Despawn();
	}
}
