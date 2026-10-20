using System.Collections.Generic;

public interface WorldGenerator
{
	List<M_Level.LevelAssetHolder> GetGenerationList(M_Region lastRegion = null, M_Region regionToGenerate = null, M_Subregion startAfterSubregion = null);
}
