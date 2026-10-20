using System;

[Serializable]
public class Barnacle_Tongue_Harpoon
{
	private Barnacle_Tongue_Interface_Module barnacleInterface;

	public void Initialize(Barnacle_Tongue_Interface_Module bIn)
	{
		barnacleInterface = bIn;
	}
}
