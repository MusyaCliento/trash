using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Paloma
{
	public class TargaImage
	{
		private TargaHeader objTargaHeader;

		private TargaExtensionArea objTargaExtensionArea;

		private TargaFooter objTargaFooter;

		private Texture2D bmpTargaImage;

		private Texture2D bmpImageThumbnail;

		private TGAFormat eTGAFormat;

		private string strFileName = string.Empty;

		private int intStride;

		private int intPadding;

		private List<List<byte>> rows = new List<List<byte>>();

		private List<byte> row = new List<byte>();

		public TargaHeader Header => objTargaHeader;

		public TargaExtensionArea ExtensionArea => objTargaExtensionArea;

		public TargaFooter Footer => objTargaFooter;

		public TGAFormat Format => eTGAFormat;

		public Texture Image => bmpTargaImage;

		public Texture Thumbnail => bmpImageThumbnail;

		public string FileName => strFileName;

		public int Stride => intStride;

		public int Padding => intPadding;

		public TargaImage()
		{
			objTargaFooter = new TargaFooter();
			objTargaHeader = new TargaHeader();
			objTargaExtensionArea = new TargaExtensionArea();
			bmpTargaImage = null;
			bmpImageThumbnail = null;
		}

		public TargaImage(string strFileName)
			: this()
		{
			if (Path.GetExtension(strFileName).ToLower() == ".tga")
			{
				if (File.Exists(strFileName))
				{
					this.strFileName = strFileName;
					MemoryStream memoryStream = null;
					BinaryReader binaryReader = null;
					byte[] array = null;
					array = File.ReadAllBytes(this.strFileName);
					if (array != null && array.Length != 0)
					{
						using (memoryStream = new MemoryStream(array))
						{
							if (memoryStream != null && memoryStream.Length > 0 && memoryStream.CanSeek)
							{
								using (binaryReader = new BinaryReader(memoryStream))
								{
									LoadTGAFooterInfo(binaryReader);
									LoadTGAHeaderInfo(binaryReader);
									LoadTGAExtensionArea(binaryReader);
									LoadTGAImage(binaryReader);
									return;
								}
							}
							throw new Exception("Error loading file, could not read file from disk.");
						}
					}
					throw new Exception("Error loading file, could not read file from disk.");
				}
				throw new Exception("Error loading file, could not find file '" + strFileName + "' on disk.");
			}
			throw new Exception("Error loading file, file '" + strFileName + "' must have an extension of '.tga'.");
		}

		private void LoadTGAFooterInfo(BinaryReader binReader)
		{
			if (binReader != null && binReader.BaseStream != null && binReader.BaseStream.Length > 0 && binReader.BaseStream.CanSeek)
			{
				try
				{
					binReader.BaseStream.Seek(-18L, SeekOrigin.End);
					string text = Encoding.ASCII.GetString(binReader.ReadBytes(16)).TrimEnd('\0');
					if (string.Compare(text, "TRUEVISION-XFILE") == 0)
					{
						eTGAFormat = TGAFormat.NEW_TGA;
						binReader.BaseStream.Seek(-26L, SeekOrigin.End);
						int extensionAreaOffset = binReader.ReadInt32();
						int developerDirectoryOffset = binReader.ReadInt32();
						binReader.ReadBytes(16);
						string reservedCharacter = Encoding.ASCII.GetString(binReader.ReadBytes(1)).TrimEnd('\0');
						objTargaFooter.SetExtensionAreaOffset(extensionAreaOffset);
						objTargaFooter.SetDeveloperDirectoryOffset(developerDirectoryOffset);
						objTargaFooter.SetSignature(text);
						objTargaFooter.SetReservedCharacter(reservedCharacter);
					}
					else
					{
						eTGAFormat = TGAFormat.ORIGINAL_TGA;
					}
					return;
				}
				catch (Exception ex)
				{
					ClearAll();
					throw ex;
				}
			}
			ClearAll();
			throw new Exception("Error loading file, could not read file from disk.");
		}

		private void LoadTGAHeaderInfo(BinaryReader binReader)
		{
			if (binReader != null && binReader.BaseStream != null && binReader.BaseStream.Length > 0 && binReader.BaseStream.CanSeek)
			{
				try
				{
					binReader.BaseStream.Seek(0L, SeekOrigin.Begin);
					objTargaHeader.SetImageIDLength(binReader.ReadByte());
					objTargaHeader.SetColorMapType((ColorMapType)binReader.ReadByte());
					objTargaHeader.SetImageType((ImageType)binReader.ReadByte());
					objTargaHeader.SetColorMapFirstEntryIndex(binReader.ReadInt16());
					objTargaHeader.SetColorMapLength(binReader.ReadInt16());
					objTargaHeader.SetColorMapEntrySize(binReader.ReadByte());
					objTargaHeader.SetXOrigin(binReader.ReadInt16());
					objTargaHeader.SetYOrigin(binReader.ReadInt16());
					objTargaHeader.SetWidth(binReader.ReadInt16());
					objTargaHeader.SetHeight(binReader.ReadInt16());
					byte b = binReader.ReadByte();
					switch (b)
					{
					case 8:
					case 16:
					case 24:
					case 32:
					{
						objTargaHeader.SetPixelDepth(b);
						byte b2 = binReader.ReadByte();
						objTargaHeader.SetAttributeBits((byte)Utilities.GetBits(b2, 0, 4));
						objTargaHeader.SetVerticalTransferOrder((VerticalTransferOrder)Utilities.GetBits(b2, 5, 1));
						objTargaHeader.SetHorizontalTransferOrder((HorizontalTransferOrder)Utilities.GetBits(b2, 4, 1));
						if (objTargaHeader.ImageIDLength > 0)
						{
							byte[] bytes = binReader.ReadBytes(objTargaHeader.ImageIDLength);
							objTargaHeader.SetImageIDValue(Encoding.ASCII.GetString(bytes).TrimEnd('\0'));
						}
						break;
					}
					default:
						ClearAll();
						throw new Exception("Targa Image only supports 8, 16, 24, or 32 bit pixel depths.");
					}
				}
				catch (Exception ex)
				{
					ClearAll();
					throw ex;
				}
				if (objTargaHeader.ColorMapType == ColorMapType.COLOR_MAP_INCLUDED)
				{
					if (objTargaHeader.ImageType != ImageType.UNCOMPRESSED_COLOR_MAPPED && objTargaHeader.ImageType != ImageType.RUN_LENGTH_ENCODED_COLOR_MAPPED)
					{
						return;
					}
					if (objTargaHeader.ColorMapLength > 0)
					{
						try
						{
							for (int i = 0; i < objTargaHeader.ColorMapLength; i++)
							{
								byte b3 = 0;
								byte b4 = 0;
								byte b5 = 0;
								byte b6 = 0;
								switch (objTargaHeader.ColorMapEntrySize)
								{
								case 15:
								{
									byte[] array2 = binReader.ReadBytes(2);
									objTargaHeader.ColorMap.Add(Utilities.GetColorFrom2Bytes(array2[1], array2[0]));
									break;
								}
								case 16:
								{
									byte[] array = binReader.ReadBytes(2);
									objTargaHeader.ColorMap.Add(Utilities.GetColorFrom2Bytes(array[1], array[0]));
									break;
								}
								case 24:
									b6 = binReader.ReadByte();
									b5 = binReader.ReadByte();
									b4 = binReader.ReadByte();
									objTargaHeader.ColorMap.Add(new Color32(b4, b5, b6, byte.MaxValue));
									break;
								case 32:
									b3 = binReader.ReadByte();
									b6 = binReader.ReadByte();
									b5 = binReader.ReadByte();
									b4 = binReader.ReadByte();
									objTargaHeader.ColorMap.Add(new Color32(b4, b5, b6, b3));
									break;
								default:
									ClearAll();
									throw new Exception("TargaImage only supports ColorMap Entry Sizes of 15, 16, 24 or 32 bits.");
								}
							}
							return;
						}
						catch (Exception ex2)
						{
							ClearAll();
							throw ex2;
						}
					}
					ClearAll();
					throw new Exception("Image Type requires a Color Map and Color Map Length is zero.");
				}
				if (objTargaHeader.ImageType == ImageType.UNCOMPRESSED_COLOR_MAPPED || objTargaHeader.ImageType == ImageType.RUN_LENGTH_ENCODED_COLOR_MAPPED)
				{
					ClearAll();
					throw new Exception("Image Type requires a Color Map and there was not a Color Map included in the file.");
				}
				return;
			}
			ClearAll();
			throw new Exception("Error loading file, could not read file from disk.");
		}

		private void LoadTGAExtensionArea(BinaryReader binReader)
		{
			if (binReader != null && binReader.BaseStream != null && binReader.BaseStream.Length > 0 && binReader.BaseStream.CanSeek)
			{
				if (objTargaFooter.ExtensionAreaOffset <= 0)
				{
					return;
				}
				try
				{
					binReader.BaseStream.Seek(objTargaFooter.ExtensionAreaOffset, SeekOrigin.Begin);
					objTargaExtensionArea.SetExtensionSize(binReader.ReadInt16());
					objTargaExtensionArea.SetAuthorName(Encoding.ASCII.GetString(binReader.ReadBytes(41)).TrimEnd('\0'));
					objTargaExtensionArea.SetAuthorComments(Encoding.ASCII.GetString(binReader.ReadBytes(324)).TrimEnd('\0'));
					short num = binReader.ReadInt16();
					short num2 = binReader.ReadInt16();
					short num3 = binReader.ReadInt16();
					short num4 = binReader.ReadInt16();
					short num5 = binReader.ReadInt16();
					short num6 = binReader.ReadInt16();
					string text = num + "/" + num2 + "/" + num3 + " ";
					text = text + num4 + ":" + num5 + ":" + num6;
					if (DateTime.TryParse(text, out var result))
					{
						objTargaExtensionArea.SetDateTimeStamp(result);
					}
					objTargaExtensionArea.SetJobName(Encoding.ASCII.GetString(binReader.ReadBytes(41)).TrimEnd('\0'));
					num4 = binReader.ReadInt16();
					num5 = binReader.ReadInt16();
					num6 = binReader.ReadInt16();
					TimeSpan jobTime = new TimeSpan(num4, num5, num6);
					objTargaExtensionArea.SetJobTime(jobTime);
					objTargaExtensionArea.SetSoftwareID(Encoding.ASCII.GetString(binReader.ReadBytes(41)).TrimEnd('\0'));
					float num7 = (float)binReader.ReadInt16() / 100f;
					string text2 = Encoding.ASCII.GetString(binReader.ReadBytes(1)).TrimEnd('\0');
					objTargaExtensionArea.SetSoftwareID(num7.ToString("F2") + text2);
					byte a = binReader.ReadByte();
					byte r = binReader.ReadByte();
					byte b = binReader.ReadByte();
					byte g = binReader.ReadByte();
					objTargaExtensionArea.SetKeyColor(new Color32(r, g, b, a));
					objTargaExtensionArea.SetPixelAspectRatioNumerator(binReader.ReadInt16());
					objTargaExtensionArea.SetPixelAspectRatioDenominator(binReader.ReadInt16());
					objTargaExtensionArea.SetGammaNumerator(binReader.ReadInt16());
					objTargaExtensionArea.SetGammaDenominator(binReader.ReadInt16());
					objTargaExtensionArea.SetColorCorrectionOffset(binReader.ReadInt32());
					objTargaExtensionArea.SetPostageStampOffset(binReader.ReadInt32());
					objTargaExtensionArea.SetScanLineOffset(binReader.ReadInt32());
					objTargaExtensionArea.SetAttributesType(binReader.ReadByte());
					if (objTargaExtensionArea.ScanLineOffset > 0)
					{
						binReader.BaseStream.Seek(objTargaExtensionArea.ScanLineOffset, SeekOrigin.Begin);
						for (int i = 0; i < objTargaHeader.Height; i++)
						{
							objTargaExtensionArea.ScanLineTable.Add(binReader.ReadInt32());
						}
					}
					if (objTargaExtensionArea.ColorCorrectionOffset > 0)
					{
						binReader.BaseStream.Seek(objTargaExtensionArea.ColorCorrectionOffset, SeekOrigin.Begin);
						for (int j = 0; j < 256; j++)
						{
							a = Convert.ToByte(binReader.ReadInt16());
							r = Convert.ToByte(binReader.ReadInt16());
							b = Convert.ToByte(binReader.ReadInt16());
							g = Convert.ToByte(binReader.ReadInt16());
							objTargaExtensionArea.ColorCorrectionTable.Add(new Color32(r, g, b, a));
						}
					}
					return;
				}
				catch (Exception ex)
				{
					ClearAll();
					throw ex;
				}
			}
			ClearAll();
			throw new Exception("Error loading file, could not read file from disk.");
		}

		private byte[] LoadImageBytes(BinaryReader binReader)
		{
			byte[] array = null;
			if (binReader != null && binReader.BaseStream != null && binReader.BaseStream.Length > 0 && binReader.BaseStream.CanSeek)
			{
				if (objTargaHeader.ImageDataOffset > 0)
				{
					byte[] array2 = new byte[intPadding];
					MemoryStream memoryStream = null;
					binReader.BaseStream.Seek(objTargaHeader.ImageDataOffset, SeekOrigin.Begin);
					int num = objTargaHeader.Width * objTargaHeader.BytesPerPixel;
					int num2 = num * objTargaHeader.Height;
					if (objTargaHeader.ImageType == ImageType.RUN_LENGTH_ENCODED_BLACK_AND_WHITE || objTargaHeader.ImageType == ImageType.RUN_LENGTH_ENCODED_COLOR_MAPPED || objTargaHeader.ImageType == ImageType.RUN_LENGTH_ENCODED_TRUE_COLOR)
					{
						int num3 = -1;
						int num4 = 0;
						byte[] array3 = null;
						int num5 = 0;
						int num6 = 0;
						while (num5 < num2)
						{
							byte b = binReader.ReadByte();
							num3 = Utilities.GetBits(b, 7, 1);
							num4 = Utilities.GetBits(b, 0, 7) + 1;
							switch (num3)
							{
							case 1:
							{
								array3 = binReader.ReadBytes(objTargaHeader.BytesPerPixel);
								for (int j = 0; j < num4; j++)
								{
									byte[] array4 = array3;
									foreach (byte item in array4)
									{
										row.Add(item);
									}
									num6 += array3.Length;
									num5 += array3.Length;
									if (num6 == num)
									{
										rows.Add(row);
										row = new List<byte>(num2);
										num6 = 0;
									}
								}
								break;
							}
							case 0:
							{
								int num7 = num4 * objTargaHeader.BytesPerPixel;
								for (int i = 0; i < num7; i++)
								{
									row.Add(binReader.ReadByte());
									num5++;
									num6++;
									if (num6 == num)
									{
										rows.Add(row);
										row = new List<byte>(num);
										num6 = 0;
									}
								}
								break;
							}
							}
						}
					}
					else
					{
						for (int l = 0; l < objTargaHeader.Height; l++)
						{
							row.AddRange(binReader.ReadBytes(num));
							rows.Add(row);
							row = new List<byte>(num);
						}
					}
					bool flag = true;
					bool flag2 = false;
					switch (objTargaHeader.FirstPixelDestination)
					{
					case FirstPixelDestination.TOP_LEFT:
						flag = true;
						flag2 = true;
						break;
					case FirstPixelDestination.TOP_RIGHT:
						flag = true;
						flag2 = false;
						break;
					case FirstPixelDestination.BOTTOM_LEFT:
						flag = false;
						flag2 = true;
						break;
					case FirstPixelDestination.UNKNOWN:
					case FirstPixelDestination.BOTTOM_RIGHT:
						flag = false;
						flag2 = false;
						break;
					}
					using (memoryStream = new MemoryStream())
					{
						if (flag)
						{
							rows.Reverse();
						}
						for (int m = 0; m < rows.Count; m++)
						{
							if (flag2)
							{
								rows[m].Reverse();
							}
							byte[] array5 = rows[m].ToArray();
							memoryStream.Write(array5, 0, array5.Length);
							memoryStream.Write(array2, 0, array2.Length);
						}
						return memoryStream.ToArray();
					}
				}
				ClearAll();
				throw new Exception("Error loading file, No image data in file.");
			}
			ClearAll();
			throw new Exception("Error loading file, could not read file from disk.");
		}

		private void LoadTGAImage(BinaryReader binReader)
		{
			intStride = ((objTargaHeader.Width * objTargaHeader.PixelDepth + 31) & -32) >> 3;
			intPadding = intStride - (objTargaHeader.Width * objTargaHeader.PixelDepth + 7) / 8;
			byte[] array = LoadImageBytes(binReader);
			TextureFormat textureFormat = GetPixelFormat();
			bmpTargaImage = new Texture2D(objTargaHeader.Width, objTargaHeader.Height, textureFormat, mipChain: false);
			if (textureFormat == TextureFormat.BGRA32)
			{
				for (int i = 0; i < array.Length; i += 4)
				{
					byte b = array[i];
					array[i] = array[i + 2];
					array[i + 2] = b;
				}
				textureFormat = TextureFormat.ARGB32;
			}
			bmpTargaImage.LoadRawTextureData(array);
			bmpTargaImage.Apply(updateMipmaps: false, makeNoLongerReadable: true);
			LoadThumbnail(binReader, textureFormat);
		}

		private TextureFormat GetPixelFormat()
		{
			TextureFormat result = TextureFormat.ARGB32;
			switch (objTargaHeader.PixelDepth)
			{
			case 8:
				result = TextureFormat.Alpha8;
				break;
			case 16:
				if (Format == TGAFormat.NEW_TGA)
				{
					switch (objTargaExtensionArea.AttributesType)
					{
					case 0:
					case 1:
					case 2:
						result = TextureFormat.RGB565;
						break;
					case 3:
						result = TextureFormat.RGB565;
						break;
					}
				}
				else
				{
					result = TextureFormat.RGB565;
				}
				break;
			case 24:
				result = TextureFormat.RGB24;
				break;
			case 32:
				if (Format == TGAFormat.NEW_TGA)
				{
					switch (objTargaExtensionArea.AttributesType)
					{
					case 1:
					case 2:
						result = TextureFormat.BGRA32;
						break;
					case 0:
					case 3:
						result = TextureFormat.BGRA32;
						break;
					case 4:
						result = TextureFormat.BGRA32;
						break;
					}
				}
				else
				{
					result = TextureFormat.BGRA32;
				}
				break;
			}
			return result;
		}

		private void LoadThumbnail(BinaryReader binReader, TextureFormat pfPixelFormat)
		{
			byte[] array = null;
			if (binReader != null && binReader.BaseStream != null && binReader.BaseStream.Length > 0 && binReader.BaseStream.CanSeek)
			{
				if (ExtensionArea.PostageStampOffset > 0)
				{
					binReader.BaseStream.Seek(ExtensionArea.PostageStampOffset, SeekOrigin.Begin);
					int num = binReader.ReadByte();
					int num2 = binReader.ReadByte();
					int num3 = (((num * objTargaHeader.PixelDepth + 31) & -32) >> 3) - (num * objTargaHeader.PixelDepth + 7) / 8;
					List<List<byte>> list = new List<List<byte>>();
					List<byte> list2 = new List<byte>();
					byte[] array2 = new byte[num3];
					MemoryStream memoryStream = null;
					bool flag = false;
					bool flag2 = false;
					using (memoryStream = new MemoryStream())
					{
						int num4 = num * (objTargaHeader.PixelDepth / 8);
						for (int i = 0; i < num2; i++)
						{
							list2.AddRange(binReader.ReadBytes(num4));
							list.Add(list2);
							list2 = new List<byte>(num4);
						}
						switch (objTargaHeader.FirstPixelDestination)
						{
						case FirstPixelDestination.TOP_RIGHT:
							flag2 = false;
							flag = false;
							break;
						case FirstPixelDestination.UNKNOWN:
						case FirstPixelDestination.BOTTOM_RIGHT:
							flag2 = true;
							flag = false;
							break;
						}
						if (flag2)
						{
							list.Reverse();
						}
						for (int j = 0; j < list.Count; j++)
						{
							if (flag)
							{
								list[j].Reverse();
							}
							byte[] array3 = list[j].ToArray();
							memoryStream.Write(array3, 0, array3.Length);
							memoryStream.Write(array2, 0, array2.Length);
						}
						array = memoryStream.ToArray();
					}
					if (array != null && array.Length != 0)
					{
						bmpImageThumbnail = new Texture2D(num, num2, pfPixelFormat, mipChain: false);
						bmpImageThumbnail.LoadRawTextureData(array);
					}
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(bmpImageThumbnail);
					bmpImageThumbnail = null;
				}
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(bmpImageThumbnail);
				bmpImageThumbnail = null;
			}
		}

		private void ClearAll()
		{
			UnityEngine.Object.DestroyImmediate(bmpTargaImage);
			UnityEngine.Object.DestroyImmediate(bmpImageThumbnail);
			bmpTargaImage = null;
			bmpImageThumbnail = null;
			objTargaHeader = new TargaHeader();
			objTargaExtensionArea = new TargaExtensionArea();
			objTargaFooter = new TargaFooter();
			eTGAFormat = TGAFormat.UNKNOWN;
			intStride = 0;
			intPadding = 0;
			rows.Clear();
			row.Clear();
			strFileName = string.Empty;
		}

		public static Texture2D LoadTargaImage(string sFileName)
		{
			return new TargaImage(sFileName).bmpTargaImage;
		}
	}
}
