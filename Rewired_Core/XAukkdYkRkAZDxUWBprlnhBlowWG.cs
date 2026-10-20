using Rewired;

[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
internal interface XAukkdYkRkAZDxUWBprlnhBlowWG
{
	bool enabled { get; set; }

	int id { get; }

	string name { get; }

	string positiveName { get; }

	string negativeName { get; }

	string nonLocalizedName { get; }

	string nonLocalizedPositiveName { get; }

	string nonLocalizedNegativeName { get; }

	string key { get; }

	string positiveKey { get; }

	string negativeKey { get; }

	object glyph { get; }

	object positiveGlyph { get; }

	object negativeGlyph { get; }

	string finalGlyphKey { get; }

	string finalPositiveGlyphKey { get; }

	string finalNegativeGlyphKey { get; }

	string GetCompoundElementSpecialName(int index);

	object GetCompoundElementSpecialGlyph(int index);

	string GetCompoundElementSpecialFinalGlyphKey(int index);
}
