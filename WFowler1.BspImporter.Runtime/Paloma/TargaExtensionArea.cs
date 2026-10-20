using System;
using System.Collections.Generic;
using UnityEngine;

namespace Paloma
{
	public class TargaExtensionArea
	{
		private int intExtensionSize;

		private string strAuthorName = string.Empty;

		private string strAuthorComments = string.Empty;

		private DateTime dtDateTimeStamp = DateTime.Now;

		private string strJobName = string.Empty;

		private TimeSpan dtJobTime = TimeSpan.Zero;

		private string strSoftwareID = string.Empty;

		private string strSoftwareVersion = string.Empty;

		private Color cKeyColor;

		private int intPixelAspectRatioNumerator;

		private int intPixelAspectRatioDenominator;

		private int intGammaNumerator;

		private int intGammaDenominator;

		private int intColorCorrectionOffset;

		private int intPostageStampOffset;

		private int intScanLineOffset;

		private int intAttributesType;

		private List<int> intScanLineTable = new List<int>();

		private List<Color> cColorCorrectionTable = new List<Color>();

		public int ExtensionSize => intExtensionSize;

		public string AuthorName => strAuthorName;

		public string AuthorComments => strAuthorComments;

		public DateTime DateTimeStamp => dtDateTimeStamp;

		public string JobName => strJobName;

		public TimeSpan JobTime => dtJobTime;

		public string SoftwareID => strSoftwareID;

		public string SoftwareVersion => strSoftwareVersion;

		public Color KeyColor => cKeyColor;

		public int PixelAspectRatioNumerator => intPixelAspectRatioNumerator;

		public int PixelAspectRatioDenominator => intPixelAspectRatioDenominator;

		public float PixelAspectRatio
		{
			get
			{
				if (intPixelAspectRatioDenominator > 0)
				{
					return (float)intPixelAspectRatioNumerator / (float)intPixelAspectRatioDenominator;
				}
				return 0f;
			}
		}

		public int GammaNumerator => intGammaNumerator;

		public int GammaDenominator => intGammaDenominator;

		public float GammaRatio
		{
			get
			{
				if (intGammaDenominator > 0)
				{
					return (float)Math.Round((float)intGammaNumerator / (float)intGammaDenominator, 1);
				}
				return 1f;
			}
		}

		public int ColorCorrectionOffset => intColorCorrectionOffset;

		public int PostageStampOffset => intPostageStampOffset;

		public int ScanLineOffset => intScanLineOffset;

		public int AttributesType => intAttributesType;

		public List<int> ScanLineTable => intScanLineTable;

		public List<Color> ColorCorrectionTable => cColorCorrectionTable;

		protected internal void SetExtensionSize(int intExtensionSize)
		{
			this.intExtensionSize = intExtensionSize;
		}

		protected internal void SetAuthorName(string strAuthorName)
		{
			this.strAuthorName = strAuthorName;
		}

		protected internal void SetAuthorComments(string strAuthorComments)
		{
			this.strAuthorComments = strAuthorComments;
		}

		protected internal void SetDateTimeStamp(DateTime dtDateTimeStamp)
		{
			this.dtDateTimeStamp = dtDateTimeStamp;
		}

		protected internal void SetJobName(string strJobName)
		{
			this.strJobName = strJobName;
		}

		protected internal void SetJobTime(TimeSpan dtJobTime)
		{
			this.dtJobTime = dtJobTime;
		}

		protected internal void SetSoftwareID(string strSoftwareID)
		{
			this.strSoftwareID = strSoftwareID;
		}

		protected internal void SetSoftwareVersion(string strSoftwareVersion)
		{
			this.strSoftwareVersion = strSoftwareVersion;
		}

		protected internal void SetKeyColor(Color cKeyColor)
		{
			this.cKeyColor = cKeyColor;
		}

		protected internal void SetPixelAspectRatioNumerator(int intPixelAspectRatioNumerator)
		{
			this.intPixelAspectRatioNumerator = intPixelAspectRatioNumerator;
		}

		protected internal void SetPixelAspectRatioDenominator(int intPixelAspectRatioDenominator)
		{
			this.intPixelAspectRatioDenominator = intPixelAspectRatioDenominator;
		}

		protected internal void SetGammaNumerator(int intGammaNumerator)
		{
			this.intGammaNumerator = intGammaNumerator;
		}

		protected internal void SetGammaDenominator(int intGammaDenominator)
		{
			this.intGammaDenominator = intGammaDenominator;
		}

		protected internal void SetColorCorrectionOffset(int intColorCorrectionOffset)
		{
			this.intColorCorrectionOffset = intColorCorrectionOffset;
		}

		protected internal void SetPostageStampOffset(int intPostageStampOffset)
		{
			this.intPostageStampOffset = intPostageStampOffset;
		}

		protected internal void SetScanLineOffset(int intScanLineOffset)
		{
			this.intScanLineOffset = intScanLineOffset;
		}

		protected internal void SetAttributesType(int intAttributesType)
		{
			this.intAttributesType = intAttributesType;
		}
	}
}
