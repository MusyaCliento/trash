using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Glyphs
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class KeyedGlyph
	{
		public const uint INVALID_VERSION = 0u;

		private uint mcxEOjKnlpOPOwCpEMItdvfmwiDeb;

		private uint AcBuRZejLTxtvHqRGATVaXUilcKnA;

		private object IciowrEZmFWwTtlWdvYNzrQcinAB;

		private bool IeLuRWyKmVWDWLIgNBWphrxqLCKMA;

		private string aAHyvnJEnrIDfiTBZPOdxwhcFWSAA;

		public bool hasCachedValue => IeLuRWyKmVWDWLIgNBWphrxqLCKMA;

		public object cachedValue
		{
			get
			{
				return IciowrEZmFWwTtlWdvYNzrQcinAB;
			}
			set
			{
				IeLuRWyKmVWDWLIgNBWphrxqLCKMA = true;
				IciowrEZmFWwTtlWdvYNzrQcinAB = value;
				if (value == null)
				{
					aAHyvnJEnrIDfiTBZPOdxwhcFWSAA = null;
				}
			}
		}

		public string cachedKey => aAHyvnJEnrIDfiTBZPOdxwhcFWSAA;

		public KeyedGlyph()
		{
			mcxEOjKnlpOPOwCpEMItdvfmwiDeb = 0u;
			AcBuRZejLTxtvHqRGATVaXUilcKnA = 0u;
		}

		public KeyedGlyph(KeyedGlyph P_0)
		{
			mcxEOjKnlpOPOwCpEMItdvfmwiDeb = P_0.mcxEOjKnlpOPOwCpEMItdvfmwiDeb;
			AcBuRZejLTxtvHqRGATVaXUilcKnA = P_0.AcBuRZejLTxtvHqRGATVaXUilcKnA;
			IciowrEZmFWwTtlWdvYNzrQcinAB = P_0.IciowrEZmFWwTtlWdvYNzrQcinAB;
			IeLuRWyKmVWDWLIgNBWphrxqLCKMA = P_0.IeLuRWyKmVWDWLIgNBWphrxqLCKMA;
			aAHyvnJEnrIDfiTBZPOdxwhcFWSAA = P_0.aAHyvnJEnrIDfiTBZPOdxwhcFWSAA;
		}

		public void Clear()
		{
			mcxEOjKnlpOPOwCpEMItdvfmwiDeb = 0u;
			AcBuRZejLTxtvHqRGATVaXUilcKnA = 0u;
			IciowrEZmFWwTtlWdvYNzrQcinAB = null;
			IeLuRWyKmVWDWLIgNBWphrxqLCKMA = false;
			aAHyvnJEnrIDfiTBZPOdxwhcFWSAA = null;
		}

		public bool TryGetValue(string key, IGlyphProvider glyphProvider, uint glyphProviderVersion, uint userVersion, out bool versionChanged, out object result)
		{
			versionChanged = mcxEOjKnlpOPOwCpEMItdvfmwiDeb != ((glyphProvider != null) ? glyphProviderVersion : 0) || userVersion != AcBuRZejLTxtvHqRGATVaXUilcKnA;
			if (versionChanged)
			{
				Clear();
				mcxEOjKnlpOPOwCpEMItdvfmwiDeb = glyphProviderVersion;
				AcBuRZejLTxtvHqRGATVaXUilcKnA = userVersion;
			}
			if (!versionChanged || glyphProvider == null)
			{
				result = (IeLuRWyKmVWDWLIgNBWphrxqLCKMA ? IciowrEZmFWwTtlWdvYNzrQcinAB : null);
				return IeLuRWyKmVWDWLIgNBWphrxqLCKMA;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				IeLuRWyKmVWDWLIgNBWphrxqLCKMA = glyphProvider.TryGetGlyph(key, out IciowrEZmFWwTtlWdvYNzrQcinAB) && IciowrEZmFWwTtlWdvYNzrQcinAB != null;
				if (IeLuRWyKmVWDWLIgNBWphrxqLCKMA)
				{
					aAHyvnJEnrIDfiTBZPOdxwhcFWSAA = key;
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(IGlyphProvider).Name + ".TryGetGlyph", exception);
			}
			result = (IeLuRWyKmVWDWLIgNBWphrxqLCKMA ? IciowrEZmFWwTtlWdvYNzrQcinAB : null);
			return IeLuRWyKmVWDWLIgNBWphrxqLCKMA;
		}
	}
}
