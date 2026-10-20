public class PerkModule_WorldEntityReplacer : PerkModule
{
	public bool replaceOnInitialize;

	public CL_GameManager.ReplaceInfo replacer;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		if (replaceOnInitialize)
		{
			for (int num = GameEntity.entities.Count - 1; num >= 0; num--)
			{
				if (replacer.ShouldReplace(GameEntity.entities[num], useRandom: true))
				{
					replacer.Replace(GameEntity.entities[num]);
				}
			}
		}
		CL_GameManager gMan = CL_GameManager.gMan;
		if (gMan != null)
		{
			gMan.replacementScopes.Add(replacer);
		}
	}

	public override void OnDestroy(Perk p)
	{
		CL_GameManager gMan = CL_GameManager.gMan;
		if (gMan != null)
		{
			gMan.replacementScopes.Remove(replacer);
		}
		base.OnDestroy(p);
	}
}
