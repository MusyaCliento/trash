using System.Collections.Generic;
using UnityEngine;

namespace Paloma
{
	public class TargaHeader
	{
		private byte bImageIDLength;

		private ColorMapType eColorMapType;

		private ImageType eImageType;

		private short sColorMapFirstEntryIndex;

		private short sColorMapLength;

		private byte bColorMapEntrySize;

		private short sXOrigin;

		private short sYOrigin;

		private short sWidth;

		private short sHeight;

		private byte bPixelDepth;

		private byte bImageDescriptor;

		private VerticalTransferOrder eVerticalTransferOrder = VerticalTransferOrder.UNKNOWN;

		private HorizontalTransferOrder eHorizontalTransferOrder = HorizontalTransferOrder.UNKNOWN;

		private byte bAttributeBits;

		private string strImageIDValue = string.Empty;

		private List<Color> cColorMap = new List<Color>();

		public byte ImageIDLength => bImageIDLength;

		public ColorMapType ColorMapType => eColorMapType;

		public ImageType ImageType => eImageType;

		public short ColorMapFirstEntryIndex => sColorMapFirstEntryIndex;

		public short ColorMapLength => sColorMapLength;

		public byte ColorMapEntrySize => bColorMapEntrySize;

		public short XOrigin => sXOrigin;

		public short YOrigin => sYOrigin;

		public short Width => sWidth;

		public short Height => sHeight;

		public byte PixelDepth => bPixelDepth;

		protected internal byte ImageDescriptor
		{
			get
			{
				return bImageDescriptor;
			}
			set
			{
				bImageDescriptor = value;
			}
		}

		public FirstPixelDestination FirstPixelDestination
		{
			get
			{
				if (eVerticalTransferOrder == VerticalTransferOrder.UNKNOWN || eHorizontalTransferOrder == HorizontalTransferOrder.UNKNOWN)
				{
					return FirstPixelDestination.UNKNOWN;
				}
				if (eVerticalTransferOrder == VerticalTransferOrder.BOTTOM && eHorizontalTransferOrder == HorizontalTransferOrder.LEFT)
				{
					return FirstPixelDestination.BOTTOM_LEFT;
				}
				if (eVerticalTransferOrder == VerticalTransferOrder.BOTTOM && eHorizontalTransferOrder == HorizontalTransferOrder.RIGHT)
				{
					return FirstPixelDestination.BOTTOM_RIGHT;
				}
				if (eVerticalTransferOrder == VerticalTransferOrder.TOP && eHorizontalTransferOrder == HorizontalTransferOrder.LEFT)
				{
					return FirstPixelDestination.TOP_LEFT;
				}
				return FirstPixelDestination.TOP_RIGHT;
			}
		}

		public VerticalTransferOrder VerticalTransferOrder => eVerticalTransferOrder;

		public HorizontalTransferOrder HorizontalTransferOrder => eHorizontalTransferOrder;

		public byte AttributeBits => bAttributeBits;

		public string ImageIDValue => strImageIDValue;

		public List<Color> ColorMap => cColorMap;

		public int ImageDataOffset
		{
			get
			{
				int num = 18;
				num += bImageIDLength;
				int num2 = 0;
				switch (bColorMapEntrySize)
				{
				case 15:
					num2 = 2;
					break;
				case 16:
					num2 = 2;
					break;
				case 24:
					num2 = 3;
					break;
				case 32:
					num2 = 4;
					break;
				}
				return num + sColorMapLength * num2;
			}
		}

		public int BytesPerPixel => bPixelDepth / 8;

		protected internal void SetImageIDLength(byte bImageIDLength)
		{
			this.bImageIDLength = bImageIDLength;
		}

		protected internal void SetColorMapType(ColorMapType eColorMapType)
		{
			this.eColorMapType = eColorMapType;
		}

		protected internal void SetImageType(ImageType eImageType)
		{
			this.eImageType = eImageType;
		}

		protected internal void SetColorMapFirstEntryIndex(short sColorMapFirstEntryIndex)
		{
			this.sColorMapFirstEntryIndex = sColorMapFirstEntryIndex;
		}

		protected internal void SetColorMapLength(short sColorMapLength)
		{
			this.sColorMapLength = sColorMapLength;
		}

		protected internal void SetColorMapEntrySize(byte bColorMapEntrySize)
		{
			this.bColorMapEntrySize = bColorMapEntrySize;
		}

		protected internal void SetXOrigin(short sXOrigin)
		{
			this.sXOrigin = sXOrigin;
		}

		protected internal void SetYOrigin(short sYOrigin)
		{
			this.sYOrigin = sYOrigin;
		}

		protected internal void SetWidth(short sWidth)
		{
			this.sWidth = sWidth;
		}

		protected internal void SetHeight(short sHeight)
		{
			this.sHeight = sHeight;
		}

		protected internal void SetPixelDepth(byte bPixelDepth)
		{
			this.bPixelDepth = bPixelDepth;
		}

		protected internal void SetVerticalTransferOrder(VerticalTransferOrder eVerticalTransferOrder)
		{
			this.eVerticalTransferOrder = eVerticalTransferOrder;
		}

		protected internal void SetHorizontalTransferOrder(HorizontalTransferOrder eHorizontalTransferOrder)
		{
			this.eHorizontalTransferOrder = eHorizontalTransferOrder;
		}

		protected internal void SetAttributeBits(byte bAttributeBits)
		{
			this.bAttributeBits = bAttributeBits;
		}

		protected internal void SetImageIDValue(string strImageIDValue)
		{
			this.strImageIDValue = strImageIDValue;
		}
	}
}
