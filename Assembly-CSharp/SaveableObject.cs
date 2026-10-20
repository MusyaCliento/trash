using System.Collections.Generic;

public interface SaveableObject
{
	bool CanSave(string[] flags = null)
	{
		return false;
	}

	string GetSaveID()
	{
		return "";
	}

	SaveableInfo GetSaveInfo();

	void SetSaveInfo(SaveableInfo info, List<string> flags);
}
