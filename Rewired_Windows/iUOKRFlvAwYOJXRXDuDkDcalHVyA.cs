using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class iUOKRFlvAwYOJXRXDuDkDcalHVyA
{
	[CompilerGenerated]
	private DateTime LoUuiVnSKOggHoxIWfDcJyoUshsK;

	[CompilerGenerated]
	private WeakReference mIwDUvAtBQzluqKPXZbLIIUsYVecA;

	[CompilerGenerated]
	private string bsPOrQFszsqXBjZQHJcefxQVcoDp;

	public DateTime nPGfCJXWGRiiyYnntaDPZuAzerGW
	{
		[CompilerGenerated]
		get
		{
			return LoUuiVnSKOggHoxIWfDcJyoUshsK;
		}
		[CompilerGenerated]
		private set
		{
			LoUuiVnSKOggHoxIWfDcJyoUshsK = loUuiVnSKOggHoxIWfDcJyoUshsK;
		}
	}

	public WeakReference sDJdNtjQBmHruHMouZZyMUcIyxWdA
	{
		[CompilerGenerated]
		get
		{
			return mIwDUvAtBQzluqKPXZbLIIUsYVecA;
		}
		[CompilerGenerated]
		private set
		{
			mIwDUvAtBQzluqKPXZbLIIUsYVecA = weakReference;
		}
	}

	public string mlTOJvHPbYczesSVQabHlJngZnah
	{
		[CompilerGenerated]
		get
		{
			return bsPOrQFszsqXBjZQHJcefxQVcoDp;
		}
		[CompilerGenerated]
		private set
		{
			bsPOrQFszsqXBjZQHJcefxQVcoDp = text;
		}
	}

	public bool rIzYTfZOXAgiADKrQNcdvBnBePyx => sDJdNtjQBmHruHMouZZyMUcIyxWdA.IsAlive;

	public iUOKRFlvAwYOJXRXDuDkDcalHVyA(DateTime P_0, JEPfEYCraEjyIblcOXJPfjvhhVibb P_1, string P_2)
	{
		nPGfCJXWGRiiyYnntaDPZuAzerGW = P_0;
		sDJdNtjQBmHruHMouZZyMUcIyxWdA = new WeakReference(P_1, trackResurrection: true);
		mlTOJvHPbYczesSVQabHlJngZnah = P_2;
	}

	public virtual string HObaGPfpQhQzMiKhOFLXiFggXZYbA()
	{
		if (!(sDJdNtjQBmHruHMouZZyMUcIyxWdA.Target is JEPfEYCraEjyIblcOXJPfjvhhVibb jEPfEYCraEjyIblcOXJPfjvhhVibb))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", jEPfEYCraEjyIblcOXJPfjvhhVibb.jZMLhMmNWgZQKiIdvGxNhEuSjsYr.ToInt64(), jEPfEYCraEjyIblcOXJPfjvhhVibb.GetType().FullName, nPGfCJXWGRiiyYnntaDPZuAzerGW, mlTOJvHPbYczesSVQabHlJngZnah).AppendLine();
		return stringBuilder.ToString();
	}
}
