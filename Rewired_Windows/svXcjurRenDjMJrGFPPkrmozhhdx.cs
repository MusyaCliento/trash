using System;
using System.Runtime.InteropServices;

internal struct svXcjurRenDjMJrGFPPkrmozhhdx
{
	public IntPtr yKnTPoXWkVqXWlhtccdKjeEFJtST;

	public int kMsEBSxTPvFQGiLhnGecYUyMpaOeA;

	public int ERwKsEbMnPafsEWrYjGCkGlIkCDmA;

	public eKiggKxGFedvgdyyrDINBkJifCvqB troAmoGhctcOyAOTedaJVtjAjwrMc;

	public bool HmNAEkcZTvPdbrogaSdntakwTCTj
	{
		get
		{
			if (yKnTPoXWkVqXWlhtccdKjeEFJtST != IntPtr.Zero && kMsEBSxTPvFQGiLhnGecYUyMpaOeA > 0)
			{
				return ERwKsEbMnPafsEWrYjGCkGlIkCDmA > 0;
			}
			return false;
		}
	}

	public svXcjurRenDjMJrGFPPkrmozhhdx(IntPtr P_0, int P_1, int P_2)
	{
		yKnTPoXWkVqXWlhtccdKjeEFJtST = P_0;
		kMsEBSxTPvFQGiLhnGecYUyMpaOeA = P_1;
		ERwKsEbMnPafsEWrYjGCkGlIkCDmA = P_2;
		troAmoGhctcOyAOTedaJVtjAjwrMc = eKiggKxGFedvgdyyrDINBkJifCvqB.None;
	}

	public void IeOwocHnzcdFdPbxQPrNhyOzpKJv()
	{
		yKnTPoXWkVqXWlhtccdKjeEFJtST = IntPtr.Zero;
		kMsEBSxTPvFQGiLhnGecYUyMpaOeA = 0;
		ERwKsEbMnPafsEWrYjGCkGlIkCDmA = 0;
		troAmoGhctcOyAOTedaJVtjAjwrMc = eKiggKxGFedvgdyyrDINBkJifCvqB.None;
	}

	public string mLCOJabpuvpRisGOqtkGHaCbCwOw()
	{
		string text = "OutputReport:\n";
		text = text + "buffer = " + ((yKnTPoXWkVqXWlhtccdKjeEFJtST == IntPtr.Zero) ? "NULL" : ("Is Valid (" + yKnTPoXWkVqXWlhtccdKjeEFJtST + ")")) + "\n";
		text = text + "bufferLength = " + kMsEBSxTPvFQGiLhnGecYUyMpaOeA + "\n";
		text = text + "reportLength = " + ERwKsEbMnPafsEWrYjGCkGlIkCDmA + "\n";
		string text2 = text;
		int num = (int)troAmoGhctcOyAOTedaJVtjAjwrMc;
		text = text2 + "options = " + num + "\n";
		if (yKnTPoXWkVqXWlhtccdKjeEFJtST != IntPtr.Zero)
		{
			text += "Buffer data:\n";
			for (int i = 0; i < ERwKsEbMnPafsEWrYjGCkGlIkCDmA; i++)
			{
				text += Marshal.ReadByte(yKnTPoXWkVqXWlhtccdKjeEFJtST, i).ToString("X2");
				if (i < ERwKsEbMnPafsEWrYjGCkGlIkCDmA - 1)
				{
					text += ", ";
				}
			}
		}
		return text;
	}
}
