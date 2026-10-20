using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.UnityInputManager;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils
{
	public static class UnityTools
	{
		internal struct uaEpAarlcIaaOoCOqAQxcyWtCvMkA
		{
			public Platform PzgCyMmtbvhmhaaGeejAAuYbPCHFB;

			public Platform pKzPdYWRLQIBEDIiWOHMmurkkxFt;

			public EditorPlatform ntRQvjrGkItafLbOeSiLDpItjikDA;

			public bool cAoIKzItobGUBCfIpqMOQqmSqnTfb;

			public WebplayerPlatform KjaRKLMFuVettClmsdKddNDGRJFtA;

			public ScriptingBackend enbaJljnBRdfEFLRkDNuzyqQCPCHA;

			public ScriptingAPILevel fLZLLgiXCIiZqvjYTpzoQnPonEpk;

			public IExternalTools qkgMgcBdVnVuOcXRNtGpnOfhaVCDA;

			public uaEpAarlcIaaOoCOqAQxcyWtCvMkA(Platform P_0, Platform P_1, EditorPlatform P_2, bool P_3, WebplayerPlatform P_4, ScriptingBackend P_5, ScriptingAPILevel P_6, IExternalTools P_7)
			{
				PzgCyMmtbvhmhaaGeejAAuYbPCHFB = P_0;
				pKzPdYWRLQIBEDIiWOHMmurkkxFt = P_1;
				ntRQvjrGkItafLbOeSiLDpItjikDA = P_2;
				cAoIKzItobGUBCfIpqMOQqmSqnTfb = P_3;
				KjaRKLMFuVettClmsdKddNDGRJFtA = P_4;
				enbaJljnBRdfEFLRkDNuzyqQCPCHA = P_5;
				fLZLLgiXCIiZqvjYTpzoQnPonEpk = P_6;
				qkgMgcBdVnVuOcXRNtGpnOfhaVCDA = P_7;
			}
		}

		public enum UnityVersion
		{
			UNITY_2_6 = 0,
			UNITY_2_6_1 = 1,
			UNITY_3_0 = 2,
			UNITY_3_0_0 = 3,
			UNITY_3_1 = 4,
			UNITY_3_2 = 5,
			UNITY_3_3 = 6,
			UNITY_3_4 = 7,
			UNITY_3_5 = 8,
			UNITY_3_5_2 = 9,
			UNITY_3_5_7 = 10,
			UNITY_3_MAX = 11,
			UNITY_4_0 = 12,
			UNITY_4_0_1 = 13,
			UNITY_4_1 = 14,
			UNITY_4_2 = 15,
			UNITY_4_3 = 16,
			UNITY_4_4 = 17,
			UNITY_4_5 = 18,
			UNITY_4_6 = 19,
			UNITY_4_6_3p1 = 20,
			UNITY_4_6_3p1Plus = 21,
			UNITY_4_7 = 22,
			UNITY_4_8 = 23,
			UNITY_4_9 = 24,
			UNITY_4_MAX = 25,
			UNITY_5_0 = 26,
			UNITY_5_0_0p1 = 27,
			UNITY_5_0_0p1Plus = 28,
			UNITY_5_0_1 = 29,
			UNITY_5_0_2 = 30,
			UNITY_5_1 = 31,
			UNITY_5_2 = 32,
			UNITY_5_3 = 33,
			UNITY_5_4 = 34,
			UNITY_5_5 = 35,
			UNITY_5_6 = 36,
			UNITY_5_7 = 37,
			UNITY_5_8 = 38,
			UNITY_5_9 = 39,
			UNITY_5_MAX = 40,
			UNITY_2017_0 = 41,
			UNITY_2017_1 = 42,
			UNITY_2017_2 = 43,
			UNITY_2017_3 = 44,
			UNITY_2017_4 = 45,
			UNITY_2017_5 = 46,
			UNITY_2017_6 = 47,
			UNITY_2017_7 = 48,
			UNITY_2017_8 = 49,
			UNITY_2017_9 = 50,
			UNITY_2017_MAX = 51,
			UNITY_2018_0 = 52,
			UNITY_2018_1 = 53,
			UNITY_2018_2 = 54,
			UNITY_2018_3 = 55,
			UNITY_2018_4 = 56,
			UNITY_2018_5 = 57,
			UNITY_2018_6 = 58,
			UNITY_2018_7 = 59,
			UNITY_2018_8 = 60,
			UNITY_2018_9 = 61,
			UNITY_2018_MAX = 62,
			UNITY_2019_0 = 63,
			UNITY_2019_1 = 64,
			UNITY_2019_2 = 65,
			UNITY_2019_3 = 66,
			UNITY_2019_4 = 67,
			UNITY_2019_5 = 68,
			UNITY_2019_6 = 69,
			UNITY_2019_7 = 70,
			UNITY_2019_8 = 71,
			UNITY_2019_9 = 72,
			UNITY_2019_MAX = 73,
			UNITY_2020_0 = 74,
			UNITY_2020_1 = 75,
			UNITY_2020_2 = 76,
			UNITY_2020_3 = 77,
			UNITY_2020_4 = 78,
			UNITY_2020_5 = 79,
			UNITY_2020_6 = 80,
			UNITY_2020_7 = 81,
			UNITY_2020_8 = 82,
			UNITY_2020_9 = 83,
			UNITY_2020_MAX = 84,
			UNITY_2021_0 = 85,
			UNITY_2021_1 = 86,
			UNITY_2021_2 = 87,
			UNITY_2021_3 = 88,
			UNITY_2021_4 = 89,
			UNITY_2021_5 = 90,
			UNITY_2021_6 = 91,
			UNITY_2021_7 = 92,
			UNITY_2021_8 = 93,
			UNITY_2021_9 = 94,
			UNITY_2021_MAX = 95,
			UNITY_2022_0 = 96,
			UNITY_2022_1 = 97,
			UNITY_2022_2 = 98,
			UNITY_2022_3 = 99,
			UNITY_2022_4 = 100,
			UNITY_2022_5 = 101,
			UNITY_2022_6 = 102,
			UNITY_2022_7 = 103,
			UNITY_2022_8 = 104,
			UNITY_2022_9 = 105,
			UNITY_2022_MAX = 106,
			UNITY_2023_0 = 107,
			UNITY_2023_1 = 108,
			UNITY_2023_2 = 109,
			UNITY_2023_3 = 110,
			UNITY_2023_4 = 111,
			UNITY_2023_5 = 112,
			UNITY_2023_6 = 113,
			UNITY_2023_7 = 114,
			UNITY_2023_8 = 115,
			UNITY_2023_9 = 116,
			UNITY_2023_MAX = 117,
			UNITY_6000_0 = 118,
			UNITY_6000_1 = 119,
			UNITY_6000_2 = 120,
			UNITY_6000_3 = 121,
			UNITY_6000_4 = 122,
			UNITY_6000_5 = 123,
			UNITY_6000_6 = 124,
			UNITY_6000_7 = 125,
			UNITY_6000_8 = 126,
			UNITY_6000_9 = 127,
			UNITY_6000_10 = 128,
			UNITY_6000_11 = 129,
			UNITY_6000_12 = 130,
			UNITY_6000_13 = 131,
			UNITY_6000_14 = 132,
			UNITY_6000_15 = 133,
			UNITY_6000_MAX = 134,
			UNITY_7000_0 = 135,
			UNITY_7000_1 = 136,
			UNITY_7000_2 = 137,
			UNITY_7000_3 = 138,
			UNITY_7000_4 = 139,
			UNITY_7000_5 = 140,
			UNITY_7000_6 = 141,
			UNITY_7000_7 = 142,
			UNITY_7000_8 = 143,
			UNITY_7000_9 = 144,
			UNITY_7000_10 = 145,
			UNITY_7000_11 = 146,
			UNITY_7000_12 = 147,
			UNITY_7000_13 = 148,
			UNITY_7000_14 = 149,
			UNITY_7000_15 = 150,
			UNITY_7000_MAX = 151,
			UNITY_8000_0 = 152,
			UNITY_8000_1 = 153,
			UNITY_8000_2 = 154,
			UNITY_8000_3 = 155,
			UNITY_8000_4 = 156,
			UNITY_8000_5 = 157,
			UNITY_8000_6 = 158,
			UNITY_8000_7 = 159,
			UNITY_8000_8 = 160,
			UNITY_8000_9 = 161,
			UNITY_8000_10 = 162,
			UNITY_8000_11 = 163,
			UNITY_8000_12 = 164,
			UNITY_8000_13 = 165,
			UNITY_8000_14 = 166,
			UNITY_8000_15 = 167,
			UNITY_8000_MAX = 168,
			UNITY_9000_0 = 169,
			UNITY_9000_1 = 170,
			UNITY_9000_2 = 171,
			UNITY_9000_3 = 172,
			UNITY_9000_4 = 173,
			UNITY_9000_5 = 174,
			UNITY_9000_6 = 175,
			UNITY_9000_7 = 176,
			UNITY_9000_8 = 177,
			UNITY_9000_9 = 178,
			UNITY_9000_10 = 179,
			UNITY_9000_11 = 180,
			UNITY_9000_12 = 181,
			UNITY_9000_13 = 182,
			UNITY_9000_14 = 183,
			UNITY_9000_15 = 184,
			UNITY_9000_MAX = 185,
			Unknown = 1000
		}

		[Flags]
		public enum GetComponentFlags
		{
			None = 0,
			SkipInactiveGameObjectRelatives = 1,
			SkipDisabledComponents = 2
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal class UnityVersionClass
		{
			public enum UBequKpNfUoHVOygzBosTTgTKXNk
			{
				Normal = 0,
				Beta = 1,
				Patch = 2
			}

			public readonly int major;

			public readonly int minor;

			public readonly int maintenance;

			public readonly UBequKpNfUoHVOygzBosTTgTKXNk type;

			public readonly int build;

			public UnityVersionClass(string P_0)
			{
				type = UBequKpNfUoHVOygzBosTTgTKXNk.Normal;
				string[] array = P_0.Split('.');
				string text = array[^1];
				if (Regex.IsMatch(text, ".*[a-zA-Z]+.*"))
				{
					if (Regex.IsMatch(text, ".*[bB]+.*", RegexOptions.IgnoreCase))
					{
						type = UBequKpNfUoHVOygzBosTTgTKXNk.Beta;
					}
					else if (Regex.IsMatch(text, ".*[pP]+.*", RegexOptions.IgnoreCase))
					{
						type = UBequKpNfUoHVOygzBosTTgTKXNk.Patch;
					}
					text = Regex.Replace(text, "[a-zA-Z]", "|");
					if (text.Contains("|"))
					{
						string[] array2 = text.Split('|');
						if (array2.Length != 0)
						{
							int.TryParse(array2[0], out maintenance);
						}
						if (array2.Length > 1)
						{
							int.TryParse(array2[1], out build);
						}
					}
					else
					{
						int.TryParse(text, out maintenance);
					}
					Array.Resize(ref array, array.Length - 1);
				}
				else
				{
					int.TryParse(text, out maintenance);
				}
				if (array.Length != 0)
				{
					int.TryParse(array[0], out major);
				}
				if (array.Length > 1)
				{
					int.TryParse(array[1], out minor);
				}
			}

			public override string ToString()
			{
				string[] array = new string[7];
				int num = major;
				array[0] = num.ToString();
				array[1] = ".";
				num = minor;
				array[2] = num.ToString();
				array[3] = ".";
				num = maintenance;
				array[4] = num.ToString();
				array[5] = MEhLkwKmcbdkCQbbsevWFLvvZLOT(type);
				num = build;
				array[6] = num.ToString();
				return string.Concat(array);
			}

			private string MEhLkwKmcbdkCQbbsevWFLvvZLOT(UBequKpNfUoHVOygzBosTTgTKXNk P_0)
			{
				return P_0 switch
				{
					UBequKpNfUoHVOygzBosTTgTKXNk.Normal => "f", 
					UBequKpNfUoHVOygzBosTTgTKXNk.Beta => "b", 
					UBequKpNfUoHVOygzBosTTgTKXNk.Patch => "p", 
					_ => throw new NotImplementedException(), 
				};
			}

			public override bool Equals(object obj)
			{
				if (!(obj is UnityVersionClass))
				{
					return false;
				}
				return this == (UnityVersionClass)obj;
			}

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			public static bool operator <(UnityVersionClass a, UnityVersionClass b)
			{
				return Comparison(a, b) < 0;
			}

			public static bool operator >(UnityVersionClass a, UnityVersionClass b)
			{
				return Comparison(a, b) > 0;
			}

			public static bool operator >=(UnityVersionClass a, UnityVersionClass b)
			{
				return Comparison(a, b) >= 0;
			}

			public static bool operator <=(UnityVersionClass a, UnityVersionClass b)
			{
				return Comparison(a, b) <= 0;
			}

			public static bool operator ==(UnityVersionClass a, UnityVersionClass b)
			{
				return Comparison(a, b) == 0;
			}

			public static bool operator !=(UnityVersionClass a, UnityVersionClass b)
			{
				return Comparison(a, b) != 0;
			}

			public static int Comparison(UnityVersionClass a, UnityVersionClass b)
			{
				if (object.Equals(a, null) && object.Equals(b, null))
				{
					return 0;
				}
				if (object.Equals(a, null))
				{
					return -1;
				}
				if (object.Equals(b, null))
				{
					return 1;
				}
				if (a.major > b.major)
				{
					return 1;
				}
				if (a.major < b.major)
				{
					return -1;
				}
				if (a.minor > b.minor)
				{
					return 1;
				}
				if (a.minor < b.minor)
				{
					return -1;
				}
				if (a.maintenance > b.maintenance)
				{
					return 1;
				}
				if (a.maintenance < b.maintenance)
				{
					return -1;
				}
				if (RdbZcVuiDhmEknoWlwZOUzXrKfPQ(a.type) > RdbZcVuiDhmEknoWlwZOUzXrKfPQ(b.type))
				{
					return 1;
				}
				if (RdbZcVuiDhmEknoWlwZOUzXrKfPQ(a.type) < RdbZcVuiDhmEknoWlwZOUzXrKfPQ(b.type))
				{
					return -1;
				}
				if (a.build > b.build)
				{
					return 1;
				}
				if (a.build < b.build)
				{
					return -1;
				}
				return 0;
			}

			public static bool IsValidVersionString(string versionString)
			{
				if (string.IsNullOrEmpty(versionString))
				{
					return false;
				}
				if (!versionString.Contains("."))
				{
					return false;
				}
				string[] array = versionString.Split('.');
				if (array.Length < 3)
				{
					return false;
				}
				if (!Regex.IsMatch(array[0], "^[0-9]+$"))
				{
					return false;
				}
				if (!Regex.IsMatch(array[1], "^[0-9]+$"))
				{
					return false;
				}
				if (!int.TryParse(array[0], out var result))
				{
					return false;
				}
				if (!int.TryParse(array[1], out result))
				{
					return false;
				}
				if (!Regex.IsMatch(array[2], "^[0-9]+"))
				{
					return false;
				}
				return true;
			}

			private static int RdbZcVuiDhmEknoWlwZOUzXrKfPQ(UBequKpNfUoHVOygzBosTTgTKXNk P_0)
			{
				return P_0 switch
				{
					UBequKpNfUoHVOygzBosTTgTKXNk.Beta => 0, 
					UBequKpNfUoHVOygzBosTTgTKXNk.Normal => 10, 
					UBequKpNfUoHVOygzBosTTgTKXNk.Patch => 100, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private const UnityVersion VhgiEuGIPXFzRXEPETipSFSqCjBD = UnityVersion.UNITY_5_0;

		private static UnityVersionClass qaDRcNougVRuhHLsVztqOSSijKmk;

		private static UnityVersion HYGgKFyLKwxtQgNadZAsXCjDAnxm = UnityVersion.Unknown;

		private static string DJApxkbLLMdjMbOMfPqHwoonleJl;

		private static Platform vQqPLhJiUGqccrMjceRhGeJErzdd;

		private static EditorPlatform tCvCNXBsLFUjOxxLccYxoBKYGktu;

		private static bool VjGPgYdfkEDilVieQJMVwOZMDAdI;

		private static bool ckhXcnLDqVQzxsWtJzusExGPoyCH;

		private static bool YTUDRpNRSllnisKlhEqIZFvLXcno;

		private static WebplayerPlatform CsMqKloFKWaYyhhygsLOzsOCJOuL;

		private static bool tVdvpMTTWDgKjacuLrMuEYDBUvso;

		private static bool aPFohsZJwhBdQBEFPYufCpyVEKFiA;

		private static bool KBreLSbJoDABXLXxdVUGmDvXPgsB;

		private static bool nxXGKovNVIBFDeTaiAJUBQNDUxdfA;

		private static bool SgAjAZsOCUmuDWgIUXVykdoqejEA;

		private static bool DbPUEpdvOXfMCJpktHaVOwTdGQteA;

		private static string CLJlILIgZRWWRiTYcmnengVCeSak;

		private static ScriptingBackend iyrGGtHROpYOgFsLBdcBimgAlzrGb;

		private static ScriptingAPILevel lhWyZYitbkTMEiYBvfLCPnjbvpqH;

		private static bool PWSxpqvKBCYIXaSqhmjRXEEXzQZp;

		private static bool? padAkvECmzgGyHXpMjCRnXlkRJpf;

		private static bool? BaEUbbgYOtItjFcHKVVCLgzfDZdu;

		private static IExternalTools IEUBKDBYEhZkanexmYwKaKmcbOBG;

		[CompilerGenerated]
		private static IAndroidFallbackPlatformHelper dDizkcZICSeTIFpiPmAlwZUESfPA;

		private static bool cFqeyDGFkVoLfzgOAcNniXKYegdOA;

		[CustomObfuscation(rename = false)]
		internal static UnityVersionClass unityVersionObj
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return null;
				}
				return qaDRcNougVRuhHLsVztqOSSijKmk;
			}
		}

		public static UnityVersion unityVersion
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return UnityVersion.Unknown;
				}
				return HYGgKFyLKwxtQgNadZAsXCjDAnxm;
			}
		}

		public static string unityVersionString
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return string.Empty;
				}
				return DJApxkbLLMdjMbOMfPqHwoonleJl;
			}
		}

		public static Platform platform
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return Platform.Unknown;
				}
				return vQqPLhJiUGqccrMjceRhGeJErzdd;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static Platform effectivePlatform
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return Platform.Unknown;
				}
				if (!VjGPgYdfkEDilVieQJMVwOZMDAdI)
				{
					return vQqPLhJiUGqccrMjceRhGeJErzdd;
				}
				return tCvCNXBsLFUjOxxLccYxoBKYGktu switch
				{
					EditorPlatform.Windows => Platform.Windows, 
					EditorPlatform.OSX => Platform.OSX, 
					EditorPlatform.Linux => Platform.Linux, 
					_ => vQqPLhJiUGqccrMjceRhGeJErzdd, 
				};
			}
		}

		public static EditorPlatform editorPlatform
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return EditorPlatform.None;
				}
				return tCvCNXBsLFUjOxxLccYxoBKYGktu;
			}
		}

		public static bool isEditor
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return VjGPgYdfkEDilVieQJMVwOZMDAdI;
			}
		}

		public static bool isPlaying => ckhXcnLDqVQzxsWtJzusExGPoyCH;

		public static bool isDebugBuild
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return YTUDRpNRSllnisKlhEqIZFvLXcno;
			}
		}

		public static WebplayerPlatform webplayerPlatform
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return WebplayerPlatform.None;
				}
				return CsMqKloFKWaYyhhygsLOzsOCJOuL;
			}
		}

		public static bool logToDebugLog
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return true;
				}
				if (VjGPgYdfkEDilVieQJMVwOZMDAdI || Application.isEditor)
				{
					return true;
				}
				if (isAndroidPlatform)
				{
					return true;
				}
				switch (vQqPLhJiUGqccrMjceRhGeJErzdd)
				{
				case Platform.Windows:
				case Platform.OSX:
				case Platform.Linux:
					if (!YTUDRpNRSllnisKlhEqIZFvLXcno)
					{
						return iyrGGtHROpYOgFsLBdcBimgAlzrGb == ScriptingBackend.IL2CPP;
					}
					return true;
				case Platform.XboxOne:
					return true;
				case Platform.Switch:
					return true;
				default:
					if (YTUDRpNRSllnisKlhEqIZFvLXcno)
					{
						return true;
					}
					return false;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool editorPlatformMatchesBuildPlatform
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				if (!VjGPgYdfkEDilVieQJMVwOZMDAdI)
				{
					return true;
				}
				return tCvCNXBsLFUjOxxLccYxoBKYGktu switch
				{
					EditorPlatform.Windows => vQqPLhJiUGqccrMjceRhGeJErzdd == Platform.Windows, 
					EditorPlatform.OSX => vQqPLhJiUGqccrMjceRhGeJErzdd == Platform.OSX, 
					EditorPlatform.Linux => vQqPLhJiUGqccrMjceRhGeJErzdd == Platform.Linux, 
					_ => true, 
				};
			}
		}

		public static bool isSupportedVersion3
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return tVdvpMTTWDgKjacuLrMuEYDBUvso;
			}
		}

		public static bool isSupportedVersion4
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return aPFohsZJwhBdQBEFPYufCpyVEKFiA;
			}
		}

		public static bool supports2DColliders
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_4_3;
			}
		}

		public static bool supportsSortingLayers
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_4_3;
			}
		}

		public static bool supportsUnityUI
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_4_6;
			}
		}

		public static bool supportsTouchControls
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_5_0;
			}
		}

		public static bool supportsPhysicalKeys
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_2021_2;
			}
		}

		public static bool isAndroidPlatform
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return fMJBBdGcIQIZWgCBcREeBOMATWCvE(vQqPLhJiUGqccrMjceRhGeJErzdd);
			}
		}

		public static bool isIOSPlatform
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return wychFjBtiqEixfYJReILOIfKCAeNA(vQqPLhJiUGqccrMjceRhGeJErzdd);
			}
		}

		public static bool isStandalonePlatform
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				if (vQqPLhJiUGqccrMjceRhGeJErzdd != Platform.Windows && vQqPLhJiUGqccrMjceRhGeJErzdd != Platform.Linux)
				{
					return vQqPLhJiUGqccrMjceRhGeJErzdd == Platform.OSX;
				}
				return true;
			}
		}

		public static bool windowsJoystickNamesReturnsEmptyStringsIfJoystickNull
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return KBreLSbJoDABXLXxdVUGmDvXPgsB;
			}
		}

		public static bool supportsUnityUIGraphicRaycastTarget
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_5_2;
			}
		}

		public static bool supportsNestedPrefabs
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_2018_3;
			}
		}

		public static bool supportsWindowsAppStore
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				if (HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_5_0)
				{
					return HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_5_0_1;
				}
				return true;
			}
		}

		public static bool supportsWindowsUWP
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_5_2;
			}
		}

		public static bool supportsWindowsUWP_IL2CPP
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_5_3;
			}
		}

		public static bool supportsXboxOne
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_4_5;
			}
		}

		public static bool windowsStandalone_supportsRawInputForwarding
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return PWSxpqvKBCYIXaSqhmjRXEEXzQZp;
			}
		}

		public static bool supportsUnityInputSystem
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return false;
				}
				return HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_2021_2;
			}
		}

		public static bool isUnityInputSystemEnabled
		{
			get
			{
				if (IEUBKDBYEhZkanexmYwKaKmcbOBG != null)
				{
					return IEUBKDBYEhZkanexmYwKaKmcbOBG.isUnityInputSystemEnabled;
				}
				if (!padAkvECmzgGyHXpMjCRnXlkRJpf.HasValue)
				{
					bool? flag = (padAkvECmzgGyHXpMjCRnXlkRJpf = ReflectionTools.IsUnityInputSystemEnabled());
					return flag.Value;
				}
				return padAkvECmzgGyHXpMjCRnXlkRJpf.Value;
			}
		}

		public static bool isUnityInputManagerEnabled
		{
			get
			{
				if (IEUBKDBYEhZkanexmYwKaKmcbOBG != null)
				{
					return IEUBKDBYEhZkanexmYwKaKmcbOBG.isUnityInputManagerEnabled;
				}
				if (!BaEUbbgYOtItjFcHKVVCLgzfDZdu.HasValue)
				{
					bool? flag = (BaEUbbgYOtItjFcHKVVCLgzfDZdu = ReflectionTools.IsUnityInputManagerEnabled());
					return flag.Value;
				}
				return BaEUbbgYOtItjFcHKVVCLgzfDZdu.Value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static ScriptingBackend scriptingBackend => iyrGGtHROpYOgFsLBdcBimgAlzrGb;

		[CustomObfuscation(rename = false)]
		internal static ScriptingAPILevel scriptingAPILevel => lhWyZYitbkTMEiYBvfLCPnjbvpqH;

		public static IExternalTools externalTools
		{
			get
			{
				if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
				{
					return null;
				}
				return IEUBKDBYEhZkanexmYwKaKmcbOBG;
			}
		}

		internal static IAndroidFallbackPlatformHelper HGibNKTxgWTXsSSrCpyiwwxviScG
		{
			[CompilerGenerated]
			get
			{
				return dDizkcZICSeTIFpiPmAlwZUESfPA;
			}
			[CompilerGenerated]
			set
			{
				dDizkcZICSeTIFpiPmAlwZUESfPA = androidFallbackPlatformHelper;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isInitialized => cFqeyDGFkVoLfzgOAcNniXKYegdOA;

		private static bool xpbfkGPMLPicZzFDWHchwghEcfYCA => nlVgZIddRMknGhPHKZRvTwAsNLHLb();

		private static bool nlVgZIddRMknGhPHKZRvTwAsNLHLb()
		{
			if (cFqeyDGFkVoLfzgOAcNniXKYegdOA)
			{
				return true;
			}
			try
			{
				DJApxkbLLMdjMbOMfPqHwoonleJl = Application.unityVersion;
				qaDRcNougVRuhHLsVztqOSSijKmk = new UnityVersionClass(DJApxkbLLMdjMbOMfPqHwoonleJl);
				xeUaleWTjttQhglaJDLAZCnrBAqu();
				cFqeyDGFkVoLfzgOAcNniXKYegdOA = true;
			}
			catch
			{
				Logger.LogError("Could not determine Unity version.");
			}
			return cFqeyDGFkVoLfzgOAcNniXKYegdOA;
		}

		internal static void XgYPxiDBjDowbkxvxjBuzTsjHTKh(uaEpAarlcIaaOoCOqAQxcyWtCvMkA P_0)
		{
			if (xpbfkGPMLPicZzFDWHchwghEcfYCA)
			{
				if (P_0.pKzPdYWRLQIBEDIiWOHMmurkkxFt == Platform.Windows81Store)
				{
					P_0.pKzPdYWRLQIBEDIiWOHMmurkkxFt = Platform.WindowsUWP;
				}
				vQqPLhJiUGqccrMjceRhGeJErzdd = P_0.pKzPdYWRLQIBEDIiWOHMmurkkxFt;
				tCvCNXBsLFUjOxxLccYxoBKYGktu = P_0.ntRQvjrGkItafLbOeSiLDpItjikDA;
				VjGPgYdfkEDilVieQJMVwOZMDAdI = P_0.cAoIKzItobGUBCfIpqMOQqmSqnTfb;
				CsMqKloFKWaYyhhygsLOzsOCJOuL = P_0.KjaRKLMFuVettClmsdKddNDGRJFtA;
				iyrGGtHROpYOgFsLBdcBimgAlzrGb = P_0.enbaJljnBRdfEFLRkDNuzyqQCPCHA;
				lhWyZYitbkTMEiYBvfLCPnjbvpqH = P_0.fLZLLgiXCIiZqvjYTpzoQnPonEpk;
				if (IEUBKDBYEhZkanexmYwKaKmcbOBG != null)
				{
					IEUBKDBYEhZkanexmYwKaKmcbOBG.Destroy();
				}
				IEUBKDBYEhZkanexmYwKaKmcbOBG = P_0.qkgMgcBdVnVuOcXRNtGpnOfhaVCDA;
				YTUDRpNRSllnisKlhEqIZFvLXcno = Debug.isDebugBuild;
				ckhXcnLDqVQzxsWtJzusExGPoyCH = true;
				yvlFevalEWMqOcfqsStECDrZTOTFb();
			}
		}

		public static WebplayerPlatform DetermineWebplayerPlatformType(Platform platform, EditorPlatform editorPlatform)
		{
			return WebplayerPlatform.None;
		}

		public static bool IsUnityVersionInRange(string minVersionStr, string maxVersionStr)
		{
			if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
			{
				return false;
			}
			if (!string.IsNullOrEmpty(minVersionStr))
			{
				minVersionStr = Regex.Replace(minVersionStr, "[^0-9\\.a-zA-Z]", "", RegexOptions.IgnoreCase);
			}
			if (!string.IsNullOrEmpty(maxVersionStr))
			{
				maxVersionStr = Regex.Replace(maxVersionStr, "[^0-9\\.a-zA-Z]", "", RegexOptions.IgnoreCase);
			}
			mFObGjYPPpyvkLxcQwWvPyoaxIQW(minVersionStr, out var num);
			mFObGjYPPpyvkLxcQwWvPyoaxIQW(maxVersionStr, out var num2);
			if (num > 0)
			{
				minVersionStr = num + ".0.0b0";
			}
			if (num2 > 0)
			{
				maxVersionStr = num2 + 1 + ".0.0b0";
			}
			bool num3 = num > 0 || UnityVersionClass.IsValidVersionString(minVersionStr);
			bool flag = num2 > 0 || UnityVersionClass.IsValidVersionString(maxVersionStr);
			if (num3 && qaDRcNougVRuhHLsVztqOSSijKmk < new UnityVersionClass(minVersionStr))
			{
				return false;
			}
			if (num2 > 0)
			{
				if (flag && qaDRcNougVRuhHLsVztqOSSijKmk >= new UnityVersionClass(maxVersionStr))
				{
					return false;
				}
			}
			else if (flag && qaDRcNougVRuhHLsVztqOSSijKmk > new UnityVersionClass(maxVersionStr))
			{
				return false;
			}
			return true;
		}

		private static bool mFObGjYPPpyvkLxcQwWvPyoaxIQW(string P_0, out int P_1)
		{
			P_1 = 0;
			if (string.IsNullOrEmpty(P_0))
			{
				return false;
			}
			Match match = Regex.Match(P_0, "([0-9]+)[.]*[xX]");
			if (match.Success && int.TryParse(match.Groups[1].Value, out P_1))
			{
				return true;
			}
			return false;
		}

		private static void xeUaleWTjttQhglaJDLAZCnrBAqu()
		{
			HYGgKFyLKwxtQgNadZAsXCjDAnxm = DXBhhEkaCzSooEPsrRZbGeaIHySOB(Application.unityVersion);
			if (HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_3_5 && HYGgKFyLKwxtQgNadZAsXCjDAnxm < UnityVersion.UNITY_4_0)
			{
				tVdvpMTTWDgKjacuLrMuEYDBUvso = true;
			}
			else if (HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_4_0)
			{
				aPFohsZJwhBdQBEFPYufCpyVEKFiA = true;
			}
		}

		private static UnityVersion DXBhhEkaCzSooEPsrRZbGeaIHySOB(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return UnityVersion.Unknown;
			}
			string[] array = P_0.Split(new char[1] { '.' });
			int num = array.Length;
			if (num >= 2)
			{
				int result = -1;
				string empty = string.Empty;
				int.TryParse(array[0], out var result2);
				int.TryParse(array[1], out var result3);
				bool flag = false;
				int result4 = 0;
				if (num >= 3)
				{
					empty = array[2];
					if (empty.IndexOf('p', 0) >= 1)
					{
						flag = true;
					}
					if (!flag)
					{
						if (empty != string.Empty)
						{
							int.TryParse(empty[0].ToString() ?? "", out result);
						}
					}
					else
					{
						string[] array2 = empty.Split('p');
						if (array2.Length != 0)
						{
							int.TryParse(array2[0][0].ToString() ?? "", out result);
						}
						if (array2.Length > 1)
						{
							int.TryParse(array2[1][0].ToString() ?? "", out result4);
						}
					}
				}
				switch (result2)
				{
				case 2:
					if (result3 == 6)
					{
						if (result == 1)
						{
							return UnityVersion.UNITY_2_6_1;
						}
						return UnityVersion.UNITY_2_6;
					}
					break;
				case 3:
					switch (result3)
					{
					case 0:
						if (result == 0)
						{
							return UnityVersion.UNITY_3_0_0;
						}
						return UnityVersion.UNITY_3_0;
					case 1:
						return UnityVersion.UNITY_3_1;
					case 2:
						return UnityVersion.UNITY_3_2;
					case 3:
						return UnityVersion.UNITY_3_3;
					case 4:
						return UnityVersion.UNITY_3_4;
					case 5:
						return result switch
						{
							2 => UnityVersion.UNITY_3_5_2, 
							7 => UnityVersion.UNITY_3_5_7, 
							_ => UnityVersion.UNITY_3_5, 
						};
					default:
						return UnityVersion.UNITY_3_5_7;
					}
				case 4:
					switch (result3)
					{
					case 0:
						if (result == 1)
						{
							return UnityVersion.UNITY_4_0_1;
						}
						return UnityVersion.UNITY_4_0;
					case 1:
						return UnityVersion.UNITY_4_1;
					case 2:
						return UnityVersion.UNITY_4_2;
					case 3:
						return UnityVersion.UNITY_4_3;
					case 4:
						return UnityVersion.UNITY_4_4;
					case 5:
						return UnityVersion.UNITY_4_5;
					case 6:
						if (result == 3)
						{
							if (flag && result4 == 1)
							{
								return UnityVersion.UNITY_4_6_3p1;
							}
						}
						else if (result > 3)
						{
							return UnityVersion.UNITY_4_6_3p1Plus;
						}
						return UnityVersion.UNITY_4_6;
					case 7:
						return UnityVersion.UNITY_4_7;
					case 8:
						return UnityVersion.UNITY_4_8;
					case 9:
						return UnityVersion.UNITY_4_9;
					default:
						return UnityVersion.UNITY_4_0;
					}
				case 5:
					switch (result3)
					{
					case 0:
						switch (result)
						{
						case 0:
							if (flag)
							{
								if (result4 == 1)
								{
									return UnityVersion.UNITY_5_0_0p1;
								}
								return UnityVersion.UNITY_5_0_0p1Plus;
							}
							break;
						case 1:
							return UnityVersion.UNITY_5_0_1;
						case 2:
							return UnityVersion.UNITY_5_0_2;
						}
						return UnityVersion.UNITY_5_0;
					case 1:
						return UnityVersion.UNITY_5_1;
					case 2:
						return UnityVersion.UNITY_5_2;
					case 3:
						return UnityVersion.UNITY_5_3;
					case 4:
						return UnityVersion.UNITY_5_4;
					case 5:
						return UnityVersion.UNITY_5_5;
					case 6:
						return UnityVersion.UNITY_5_6;
					case 7:
						return UnityVersion.UNITY_5_7;
					case 8:
						return UnityVersion.UNITY_5_8;
					case 9:
						return UnityVersion.UNITY_5_9;
					default:
						return UnityVersion.UNITY_5_0;
					}
				case 2017:
					return result3 switch
					{
						0 => UnityVersion.UNITY_2017_0, 
						1 => UnityVersion.UNITY_2017_1, 
						2 => UnityVersion.UNITY_2017_2, 
						3 => UnityVersion.UNITY_2017_3, 
						4 => UnityVersion.UNITY_2017_4, 
						5 => UnityVersion.UNITY_2017_5, 
						6 => UnityVersion.UNITY_2017_6, 
						7 => UnityVersion.UNITY_2017_7, 
						8 => UnityVersion.UNITY_2017_8, 
						9 => UnityVersion.UNITY_2017_9, 
						_ => UnityVersion.UNITY_2017_0, 
					};
				case 2018:
					return result3 switch
					{
						0 => UnityVersion.UNITY_2018_0, 
						1 => UnityVersion.UNITY_2018_1, 
						2 => UnityVersion.UNITY_2018_2, 
						3 => UnityVersion.UNITY_2018_3, 
						4 => UnityVersion.UNITY_2018_4, 
						5 => UnityVersion.UNITY_2018_5, 
						6 => UnityVersion.UNITY_2018_6, 
						7 => UnityVersion.UNITY_2018_7, 
						8 => UnityVersion.UNITY_2018_8, 
						9 => UnityVersion.UNITY_2018_9, 
						_ => UnityVersion.UNITY_2018_0, 
					};
				case 2019:
					return result3 switch
					{
						0 => UnityVersion.UNITY_2019_0, 
						1 => UnityVersion.UNITY_2019_1, 
						2 => UnityVersion.UNITY_2019_2, 
						3 => UnityVersion.UNITY_2019_3, 
						4 => UnityVersion.UNITY_2019_4, 
						5 => UnityVersion.UNITY_2019_5, 
						6 => UnityVersion.UNITY_2019_6, 
						7 => UnityVersion.UNITY_2019_7, 
						8 => UnityVersion.UNITY_2019_8, 
						9 => UnityVersion.UNITY_2019_9, 
						_ => UnityVersion.UNITY_2019_0, 
					};
				case 2020:
					return result3 switch
					{
						0 => UnityVersion.UNITY_2020_0, 
						1 => UnityVersion.UNITY_2020_1, 
						2 => UnityVersion.UNITY_2020_2, 
						3 => UnityVersion.UNITY_2020_3, 
						4 => UnityVersion.UNITY_2020_4, 
						5 => UnityVersion.UNITY_2020_5, 
						6 => UnityVersion.UNITY_2020_6, 
						7 => UnityVersion.UNITY_2020_7, 
						8 => UnityVersion.UNITY_2020_8, 
						9 => UnityVersion.UNITY_2020_9, 
						_ => UnityVersion.UNITY_2020_0, 
					};
				case 2021:
					return result3 switch
					{
						0 => UnityVersion.UNITY_2021_0, 
						1 => UnityVersion.UNITY_2021_1, 
						2 => UnityVersion.UNITY_2021_2, 
						3 => UnityVersion.UNITY_2021_3, 
						4 => UnityVersion.UNITY_2021_4, 
						5 => UnityVersion.UNITY_2021_5, 
						6 => UnityVersion.UNITY_2021_6, 
						7 => UnityVersion.UNITY_2021_7, 
						8 => UnityVersion.UNITY_2021_8, 
						9 => UnityVersion.UNITY_2021_9, 
						_ => UnityVersion.UNITY_2021_0, 
					};
				case 2022:
					return result3 switch
					{
						0 => UnityVersion.UNITY_2022_0, 
						1 => UnityVersion.UNITY_2022_1, 
						2 => UnityVersion.UNITY_2022_2, 
						3 => UnityVersion.UNITY_2022_3, 
						4 => UnityVersion.UNITY_2022_4, 
						5 => UnityVersion.UNITY_2022_5, 
						6 => UnityVersion.UNITY_2022_6, 
						7 => UnityVersion.UNITY_2022_7, 
						8 => UnityVersion.UNITY_2022_8, 
						9 => UnityVersion.UNITY_2022_9, 
						_ => UnityVersion.UNITY_2022_0, 
					};
				case 2023:
					return result3 switch
					{
						0 => UnityVersion.UNITY_2023_0, 
						1 => UnityVersion.UNITY_2023_1, 
						2 => UnityVersion.UNITY_2023_2, 
						3 => UnityVersion.UNITY_2023_3, 
						4 => UnityVersion.UNITY_2023_4, 
						5 => UnityVersion.UNITY_2023_5, 
						6 => UnityVersion.UNITY_2023_6, 
						7 => UnityVersion.UNITY_2023_7, 
						8 => UnityVersion.UNITY_2023_8, 
						9 => UnityVersion.UNITY_2023_9, 
						_ => UnityVersion.UNITY_2023_0, 
					};
				case 6000:
					return result3 switch
					{
						0 => UnityVersion.UNITY_6000_0, 
						1 => UnityVersion.UNITY_6000_1, 
						2 => UnityVersion.UNITY_6000_2, 
						3 => UnityVersion.UNITY_6000_3, 
						4 => UnityVersion.UNITY_6000_4, 
						5 => UnityVersion.UNITY_6000_5, 
						6 => UnityVersion.UNITY_6000_6, 
						7 => UnityVersion.UNITY_6000_7, 
						8 => UnityVersion.UNITY_6000_8, 
						9 => UnityVersion.UNITY_6000_9, 
						10 => UnityVersion.UNITY_6000_10, 
						11 => UnityVersion.UNITY_6000_11, 
						12 => UnityVersion.UNITY_6000_12, 
						13 => UnityVersion.UNITY_6000_13, 
						14 => UnityVersion.UNITY_6000_14, 
						15 => UnityVersion.UNITY_6000_15, 
						_ => UnityVersion.UNITY_6000_0, 
					};
				case 7000:
					return result3 switch
					{
						0 => UnityVersion.UNITY_7000_0, 
						1 => UnityVersion.UNITY_7000_1, 
						2 => UnityVersion.UNITY_7000_2, 
						3 => UnityVersion.UNITY_7000_3, 
						4 => UnityVersion.UNITY_7000_4, 
						5 => UnityVersion.UNITY_7000_5, 
						6 => UnityVersion.UNITY_7000_6, 
						7 => UnityVersion.UNITY_7000_7, 
						8 => UnityVersion.UNITY_7000_8, 
						9 => UnityVersion.UNITY_7000_9, 
						10 => UnityVersion.UNITY_7000_10, 
						11 => UnityVersion.UNITY_7000_11, 
						12 => UnityVersion.UNITY_7000_12, 
						13 => UnityVersion.UNITY_7000_13, 
						14 => UnityVersion.UNITY_7000_14, 
						15 => UnityVersion.UNITY_7000_15, 
						_ => UnityVersion.UNITY_7000_0, 
					};
				case 8000:
					return result3 switch
					{
						0 => UnityVersion.UNITY_8000_0, 
						1 => UnityVersion.UNITY_8000_1, 
						2 => UnityVersion.UNITY_8000_2, 
						3 => UnityVersion.UNITY_8000_3, 
						4 => UnityVersion.UNITY_8000_4, 
						5 => UnityVersion.UNITY_8000_5, 
						6 => UnityVersion.UNITY_8000_6, 
						7 => UnityVersion.UNITY_8000_7, 
						8 => UnityVersion.UNITY_8000_8, 
						9 => UnityVersion.UNITY_8000_9, 
						10 => UnityVersion.UNITY_8000_10, 
						11 => UnityVersion.UNITY_8000_11, 
						12 => UnityVersion.UNITY_8000_12, 
						13 => UnityVersion.UNITY_8000_13, 
						14 => UnityVersion.UNITY_8000_14, 
						15 => UnityVersion.UNITY_8000_15, 
						_ => UnityVersion.UNITY_8000_0, 
					};
				case 9000:
					return result3 switch
					{
						0 => UnityVersion.UNITY_9000_0, 
						1 => UnityVersion.UNITY_9000_1, 
						2 => UnityVersion.UNITY_9000_2, 
						3 => UnityVersion.UNITY_9000_3, 
						4 => UnityVersion.UNITY_9000_4, 
						5 => UnityVersion.UNITY_9000_5, 
						6 => UnityVersion.UNITY_9000_6, 
						7 => UnityVersion.UNITY_9000_7, 
						8 => UnityVersion.UNITY_9000_8, 
						9 => UnityVersion.UNITY_9000_9, 
						10 => UnityVersion.UNITY_9000_10, 
						11 => UnityVersion.UNITY_9000_11, 
						12 => UnityVersion.UNITY_9000_12, 
						13 => UnityVersion.UNITY_9000_13, 
						14 => UnityVersion.UNITY_9000_14, 
						15 => UnityVersion.UNITY_9000_15, 
						_ => UnityVersion.UNITY_9000_0, 
					};
				}
			}
			return UnityVersion.Unknown;
		}

		private static void yvlFevalEWMqOcfqsStECDrZTOTFb()
		{
			switch (vQqPLhJiUGqccrMjceRhGeJErzdd)
			{
			case Platform.Android:
			case Platform.AmazonFireTV:
			case Platform.RazerForgeTV:
				nxXGKovNVIBFDeTaiAJUBQNDUxdfA = true;
				SgAjAZsOCUmuDWgIUXVykdoqejEA = true;
				break;
			case Platform.PS4:
				nxXGKovNVIBFDeTaiAJUBQNDUxdfA = true;
				CLJlILIgZRWWRiTYcmnengVCeSak = "Empty";
				DbPUEpdvOXfMCJpktHaVOwTdGQteA = true;
				break;
			case Platform.Windows:
				if ((HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_4_6_3p1 && HYGgKFyLKwxtQgNadZAsXCjDAnxm < UnityVersion.UNITY_5_0) || HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_5_0_0p1)
				{
					KBreLSbJoDABXLXxdVUGmDvXPgsB = true;
					nxXGKovNVIBFDeTaiAJUBQNDUxdfA = true;
				}
				break;
			case Platform.Linux:
				SgAjAZsOCUmuDWgIUXVykdoqejEA = true;
				break;
			}
			if (VjGPgYdfkEDilVieQJMVwOZMDAdI && tCvCNXBsLFUjOxxLccYxoBKYGktu == EditorPlatform.Windows && ((HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_4_6_3p1 && HYGgKFyLKwxtQgNadZAsXCjDAnxm < UnityVersion.UNITY_5_0) || HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_5_0_0p1))
			{
				KBreLSbJoDABXLXxdVUGmDvXPgsB = true;
				nxXGKovNVIBFDeTaiAJUBQNDUxdfA = true;
			}
			if ((!VjGPgYdfkEDilVieQJMVwOZMDAdI && vQqPLhJiUGqccrMjceRhGeJErzdd == Platform.Windows) || (VjGPgYdfkEDilVieQJMVwOZMDAdI && tCvCNXBsLFUjOxxLccYxoBKYGktu == EditorPlatform.Windows))
			{
				PWSxpqvKBCYIXaSqhmjRXEEXzQZp = HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_2021_2;
			}
		}

		internal static Type QdaDxggwTHatzfqSgvumHVUwiiKOB(hfJgoHBcvwjVYVKKiHfNAMjBWzafb P_0)
		{
			if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
			{
				return null;
			}
			if (HYGgKFyLKwxtQgNadZAsXCjDAnxm >= UnityVersion.UNITY_4_3)
			{
				return TtcmCUFukABxPNCSwhKIMUfycTjE(P_0);
			}
			return null;
		}

		private static Type TtcmCUFukABxPNCSwhKIMUfycTjE(hfJgoHBcvwjVYVKKiHfNAMjBWzafb P_0)
		{
			return P_0 switch
			{
				hfJgoHBcvwjVYVKKiHfNAMjBWzafb.RigidbodyInterpolation2D => typeof(RigidbodyInterpolation2D), 
				hfJgoHBcvwjVYVKKiHfNAMjBWzafb.RigidbodySleepMode2D => typeof(RigidbodySleepMode2D), 
				hfJgoHBcvwjVYVKKiHfNAMjBWzafb.CollisionDetectionMode2D => typeof(CollisionDetectionMode2D), 
				hfJgoHBcvwjVYVKKiHfNAMjBWzafb.PhysicsMaterial2D => typeof(PhysicsMaterial2D), 
				hfJgoHBcvwjVYVKKiHfNAMjBWzafb.Collider2D => typeof(Collider2D), 
				_ => null, 
			};
		}

		public static List<string> GetCurrentPlatformResourecesDLLPaths()
		{
			if (!xpbfkGPMLPicZzFDWHchwghEcfYCA)
			{
				return null;
			}
			List<string> list = new List<string>();
			switch (platform)
			{
			case Platform.Windows:
				list.Add("Libs/Rewired_Windows");
				break;
			case Platform.OSX:
				list.Add("Libs/Rewired_OSX");
				break;
			case Platform.Linux:
				list.Add("Libs/Rewired_Linux");
				break;
			}
			return list;
		}

		internal static bool fMJBBdGcIQIZWgCBcREeBOMATWCvE(Platform P_0)
		{
			if (P_0 != Platform.Android && P_0 != Platform.Ouya && P_0 != Platform.AmazonFireTV)
			{
				return P_0 == Platform.RazerForgeTV;
			}
			return true;
		}

		internal static bool wychFjBtiqEixfYJReILOIfKCAeNA(Platform P_0)
		{
			if (P_0 != Platform.iOS)
			{
				return P_0 == Platform.tvOS;
			}
			return true;
		}

		[CustomObfuscation(rename = false)]
		internal static UnityPrimaryInputSource GetUnityInputSourceDependency(InputSource inputSource)
		{
			switch (inputSource)
			{
			case InputSource.Fallback:
			case InputSource.Fallback_PreConfigured:
			case InputSource.XboxOne:
			case InputSource.PS4:
			case InputSource.PS5:
			case InputSource.UnityKeyboardAndMouse:
				return UnityPrimaryInputSource.InputManager;
			case InputSource.UnityInputSystem:
				return UnityPrimaryInputSource.InputSystem;
			default:
				return UnityPrimaryInputSource.None;
			}
		}

		public static Transform FindTransformInChildren(Transform transform, string name)
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (child.name == name)
				{
					return child;
				}
				Transform transform2 = FindTransformInChildren(child, name);
				if (transform2 != null)
				{
					return transform2;
				}
			}
			return null;
		}

		public static Transform FindTransformInChildren(GameObject gameObject, string name)
		{
			if (gameObject == null)
			{
				return null;
			}
			return FindTransformInChildren(gameObject.transform, name);
		}

		public static GameObject FindGameObjectInChildren(GameObject gameObject, string name)
		{
			if (gameObject == null)
			{
				return null;
			}
			Transform transform = FindTransformInChildren(gameObject.transform, name);
			if (!(transform != null))
			{
				return null;
			}
			return transform.gameObject;
		}

		public static GameObject FindGameObjectInChildren(Transform transform, string name)
		{
			if (transform == null)
			{
				return null;
			}
			Transform transform2 = FindTransformInChildren(transform, name);
			if (transform2 == null)
			{
				return null;
			}
			return transform2.gameObject;
		}

		public static T GetComponent<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			return GetComponent<T>(transform.gameObject);
		}

		public static T GetComponent<T>(Component component) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponent<T>(component.gameObject);
		}

		public static T GetComponent<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			return AwdCUlcKsgfnGhfiFrDivoohYXHy(gameObject.GetComponent(typeof(T)) as T);
		}

		public static T GetComponent<T>(Transform transform, bool includeDisabledComponents) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			return GetComponent<T>(transform.gameObject, includeDisabledComponents);
		}

		public static T GetComponent<T>(Component component, bool includeDisabledComponents) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponent<T>(component.gameObject, includeDisabledComponents);
		}

		public static T GetComponent<T>(GameObject gameObject, bool includeDisabledComponents) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				GetComponents(gameObject, list, append: false);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					T val = list[i] as T;
					if (!IsNullOrDestroyed(val) && (includeDisabledComponents || IsEnabled(list[i])))
					{
						return val;
					}
				}
			}
			return null;
		}

		public static Component GetComponent(Transform transform, Type type, bool includeDisabledComponents)
		{
			if (transform == null)
			{
				return null;
			}
			return GetComponent(transform.gameObject, type, includeDisabledComponents);
		}

		public static Component GetComponent(Component component, Type type, bool includeDisabledComponents)
		{
			if (component == null)
			{
				return null;
			}
			return GetComponent(component.gameObject, type, includeDisabledComponents);
		}

		public static Component GetComponent(GameObject gameObject, Type type, bool includeDisabledComponents)
		{
			if (gameObject == null)
			{
				return null;
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				GetComponents(gameObject, list, append: false);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					if (ReflectionTools.DoesTypeImplement(list[i].GetType(), type) && (includeDisabledComponents || IsEnabled(list[i])))
					{
						return list[i];
					}
				}
			}
			return null;
		}

		public static Component GetComponent(Transform transform, Type type)
		{
			if (transform == null)
			{
				return null;
			}
			return GetComponent(transform.gameObject, type);
		}

		public static Component GetComponent(Component component, Type type)
		{
			if (component == null)
			{
				return null;
			}
			return GetComponent(component.gameObject, type);
		}

		public static Component GetComponent(GameObject gameObject, Type type)
		{
			if (gameObject == null)
			{
				return null;
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				GetComponents(gameObject, list, append: false);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					if (ReflectionTools.DoesTypeImplement(list[i].GetType(), type))
					{
						return list[i];
					}
				}
			}
			return null;
		}

		public static T GetComponentInChildren<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			return GetComponentInChildren<T>(gameObject.transform);
		}

		public static T GetComponentInChildren<T>(Component component) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInChildren<T>(component.transform);
		}

		public static T GetComponentInChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				T component = GetComponent<T>(child);
				if (!IsNullOrDestroyed(component))
				{
					return component;
				}
				T componentInChildren = GetComponentInChildren<T>(child);
				if (!IsNullOrDestroyed(componentInChildren))
				{
					return componentInChildren;
				}
			}
			return null;
		}

		public static T GetComponentInChildren<T>(GameObject gameObject, GetComponentFlags options) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			return GetComponentInChildren<T>(gameObject.transform, options);
		}

		public static T GetComponentInChildren<T>(Component component, GetComponentFlags options) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInChildren<T>(component.transform, options);
		}

		public static T GetComponentInChildren<T>(Transform transform, GetComponentFlags options) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (!(child == null) && ((options & GetComponentFlags.SkipInactiveGameObjectRelatives) == 0 || child.gameObject.activeSelf))
				{
					T component = GetComponent<T>(child, (options & GetComponentFlags.SkipDisabledComponents) == 0);
					if (!IsNullOrDestroyed(component))
					{
						return component;
					}
					T componentInChildren = GetComponentInChildren<T>(child, options);
					if (!IsNullOrDestroyed(componentInChildren))
					{
						return componentInChildren;
					}
				}
			}
			return null;
		}

		public static Component GetComponentInChildren(GameObject gameObject, Type type)
		{
			if (gameObject == null)
			{
				return null;
			}
			return GetComponentInChildren(gameObject.transform, type);
		}

		public static Component GetComponentInChildren(Component component, Type type)
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInChildren(component.transform, type);
		}

		public static Component GetComponentInChildren(Transform transform, Type type)
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				Component component = GetComponent(child, type);
				if (!IsNullOrDestroyed(component))
				{
					return component;
				}
				Component componentInChildren = GetComponentInChildren(child, type);
				if (!IsNullOrDestroyed(componentInChildren))
				{
					return componentInChildren;
				}
			}
			return null;
		}

		public static Component GetComponentInChildren(GameObject gameObject, Type type, GetComponentFlags options)
		{
			if (gameObject == null)
			{
				return null;
			}
			return GetComponentInChildren(gameObject.transform, type, options);
		}

		public static Component GetComponentInChildren(Component component, Type type, GetComponentFlags options)
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInChildren(component.transform, type, options);
		}

		public static Component GetComponentInChildren(Transform transform, Type type, GetComponentFlags options)
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (!(child == null) && ((options & GetComponentFlags.SkipInactiveGameObjectRelatives) == 0 || child.gameObject.activeSelf))
				{
					Component component = GetComponent(child, type, (options & GetComponentFlags.SkipDisabledComponents) == 0);
					if (!IsNullOrDestroyed(component))
					{
						return component;
					}
					Component componentInChildren = GetComponentInChildren(child, type);
					if (!IsNullOrDestroyed(componentInChildren))
					{
						return componentInChildren;
					}
				}
			}
			return null;
		}

		public static T GetComponentInSelfOrChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			return GetComponentInSelfOrChildren<T>(transform.gameObject);
		}

		public static T GetComponentInSelfOrChildren<T>(Component component) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInSelfOrChildren<T>(component.gameObject);
		}

		public static T GetComponentInSelfOrChildren<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			T component = GetComponent<T>(gameObject);
			if (IsNullOrDestroyed(component))
			{
				return GetComponentInChildren<T>(gameObject);
			}
			return component;
		}

		public static T GetComponentInSelfOrChildren<T>(Transform transform, GetComponentFlags options) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			return GetComponentInSelfOrChildren<T>(transform.gameObject, options);
		}

		public static T GetComponentInSelfOrChildren<T>(Component component, GetComponentFlags options) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInSelfOrChildren<T>(component.gameObject, options);
		}

		public static T GetComponentInSelfOrChildren<T>(GameObject gameObject, GetComponentFlags options) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			T component = GetComponent<T>(gameObject, (options & GetComponentFlags.SkipDisabledComponents) == 0);
			if (IsNullOrDestroyed(component))
			{
				return GetComponentInChildren<T>(gameObject, options);
			}
			return component;
		}

		public static T GetComponentInParents<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			return GetComponentInParents<T>(gameObject.transform);
		}

		public static T GetComponentInParents<T>(Component component) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInParents<T>(component.transform);
		}

		public static T GetComponentInParents<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			while ((transform = transform.parent) != null)
			{
				T val = transform.GetComponent(typeof(T)) as T;
				if (!IsNullOrDestroyed(val))
				{
					return val;
				}
			}
			return null;
		}

		public static T GetComponentInSelfOrParents<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			return GetComponentInSelfOrParents<T>(gameObject.transform);
		}

		public static T GetComponentInSelfOrParents<T>(Component component) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInSelfOrParents<T>(component.transform);
		}

		public static T GetComponentInSelfOrParents<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			T val = transform.GetComponent(typeof(T)) as T;
			if (!IsNullOrDestroyed(val))
			{
				return val;
			}
			while ((transform = transform.parent) != null)
			{
				val = transform.GetComponent(typeof(T)) as T;
				if (!IsNullOrDestroyed(val))
				{
					return val;
				}
			}
			return null;
		}

		public static List<T> GetComponents<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return new List<T>();
			}
			return GetComponents<T>(transform.gameObject);
		}

		public static List<T> GetComponents<T>(Component component) where T : class
		{
			if (component == null)
			{
				return new List<T>();
			}
			return GetComponents<T>(component.gameObject);
		}

		public static List<T> GetComponents<T>(GameObject gameObject) where T : class
		{
			List<T> list = new List<T>();
			if (gameObject == null)
			{
				return list;
			}
			Component[] components = gameObject.GetComponents(typeof(Component));
			if (components == null)
			{
				return list;
			}
			for (int i = 0; i < components.Length; i++)
			{
				if (!IsNullOrDestroyed(components[i] as T))
				{
					list.Add(components[i] as T);
				}
			}
			return list;
		}

		public static List<T> GetComponents<T>(Transform transform, bool includeDisabledComponents) where T : class
		{
			if (transform == null)
			{
				return new List<T>();
			}
			return GetComponents<T>(transform.gameObject, includeDisabledComponents);
		}

		public static List<T> GetComponents<T>(Component component, bool includeDisabledComponents) where T : class
		{
			if (component == null)
			{
				return new List<T>();
			}
			return GetComponents<T>(component.gameObject, includeDisabledComponents);
		}

		public static List<T> GetComponents<T>(GameObject gameObject, bool includeDisabledComponents) where T : class
		{
			List<T> list = new List<T>();
			if (gameObject == null)
			{
				return list;
			}
			Component[] components = gameObject.GetComponents(typeof(Component));
			if (components == null)
			{
				return list;
			}
			for (int i = 0; i < components.Length; i++)
			{
				if (!IsNullOrDestroyed(components[i] as T) && (includeDisabledComponents || IsEnabled(components[i])))
				{
					list.Add(components[i] as T);
				}
			}
			return list;
		}

		public static List<Component> GetComponents(Transform transform, Type type)
		{
			if (transform == null)
			{
				return new List<Component>();
			}
			return GetComponents(transform.gameObject, type);
		}

		public static List<Component> GetComponents(Component component, Type type)
		{
			if (component == null)
			{
				return new List<Component>();
			}
			return GetComponents(component.gameObject, type);
		}

		public static List<Component> GetComponents(GameObject gameObject, Type type)
		{
			List<Component> list = new List<Component>();
			if (gameObject == null)
			{
				return list;
			}
			Component[] components = gameObject.GetComponents(type);
			if (components == null)
			{
				return list;
			}
			list.AddRange(components);
			return list;
		}

		public static List<Component> GetComponents(Transform transform, Type type, bool includeDisabledComponents)
		{
			if (transform == null)
			{
				return new List<Component>();
			}
			return GetComponents(transform.gameObject, type, includeDisabledComponents);
		}

		public static List<Component> GetComponents(Component component, Type type, bool includeDisabledComponents)
		{
			if (component == null)
			{
				return new List<Component>();
			}
			return GetComponents(component.gameObject, type, includeDisabledComponents);
		}

		public static List<Component> GetComponents(GameObject gameObject, Type type, bool includeDisabledComponents)
		{
			List<Component> list = new List<Component>();
			if (gameObject == null)
			{
				return list;
			}
			Component[] components = gameObject.GetComponents(type);
			if (components == null)
			{
				return list;
			}
			for (int i = 0; i < components.Length; i++)
			{
				if (includeDisabledComponents || IsEnabled(components[i]))
				{
					list.Add(components[i]);
				}
			}
			return list;
		}

		public static List<T> GetComponentsInChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			List<T> list = new List<T>();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				GetComponentsInSelfAndChildren(transform.GetChild(i), list, append: true);
			}
			return list;
		}

		public static List<T> GetComponentsInChildren<T>(Component component) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInChildren<T>(component.transform);
		}

		public static List<T> GetComponentsInChildren<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInChildren<T>(gameObject.transform);
		}

		public static List<T> GetComponentsInChildren<T>(Transform transform, GetComponentFlags options) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			List<T> list = new List<T>();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				GetComponentsInSelfAndChildren(transform.GetChild(i), options, list, append: true);
			}
			return list;
		}

		public static List<T> GetComponentsInChildren<T>(Component component, GetComponentFlags options) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInChildren<T>(component.transform, options);
		}

		public static List<T> GetComponentsInChildren<T>(GameObject gameObject, GetComponentFlags options) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInChildren<T>(gameObject.transform, options);
		}

		public static List<Component> GetComponentsInChildren(Transform transform)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			List<Component> list = new List<Component>();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				GetComponentsInSelfAndChildren(transform.GetChild(i), list, append: true);
			}
			return list;
		}

		public static List<Component> GetComponentsInChildren(Component component)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInChildren(component.transform);
		}

		public static List<Component> GetComponentsInChildren(GameObject gameObject)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInChildren(gameObject.transform);
		}

		public static List<T> GetComponentsInSelfAndChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return new List<T>();
			}
			return GetComponentsInSelfAndChildren<T>(transform.gameObject);
		}

		public static List<T> GetComponentsInSelfAndChildren<T>(Component component) where T : class
		{
			if (component == null)
			{
				return new List<T>();
			}
			return GetComponentsInSelfAndChildren<T>(component.gameObject);
		}

		public static List<T> GetComponentsInSelfAndChildren<T>(GameObject gameObject) where T : class
		{
			List<T> list = new List<T>();
			if (gameObject == null)
			{
				return list;
			}
			Component[] componentsInChildren = gameObject.GetComponentsInChildren(typeof(Component), includeInactive: true);
			if (componentsInChildren == null)
			{
				return list;
			}
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (!IsNullOrDestroyed(componentsInChildren[i] as T))
				{
					list.Add(componentsInChildren[i] as T);
				}
			}
			return list;
		}

		public static List<T> GetComponentsInParents<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			List<T> list = new List<T>();
			Transform transform2 = transform;
			while ((transform2 = transform2.parent) != null)
			{
				GetComponents(transform2, list, append: true);
			}
			return list;
		}

		public static List<T> GetComponentsInParents<T>(Component component) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInParents<T>(component.transform);
		}

		public static List<T> GetComponentsInParents<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInParents<T>(gameObject.transform);
		}

		public static List<Component> GetComponentsInParents(Transform transform)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			List<Component> list = new List<Component>();
			Transform transform2 = transform;
			while ((transform2 = transform2.parent) != null)
			{
				GetComponents(transform2, list, append: true);
			}
			return list;
		}

		public static List<Component> GetComponentsInParents(Component component)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInParents(component.transform);
		}

		public static List<Component> GetComponentsInParents(GameObject gameObject)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInParents(gameObject.transform);
		}

		public static int GetComponents<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return GetComponents(transform.gameObject, results, append);
		}

		public static int GetComponents<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponents(component.gameObject, results, append);
		}

		public static int GetComponents<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				gameObject.GetComponents(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					T val = list[i] as T;
					if (!IsNullOrDestroyed(val))
					{
						results.Add(val);
					}
				}
			}
			return results.Count;
		}

		public static int GetComponents<T>(Transform transform, bool includeDisabledComponents, List<T> results, bool append) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return GetComponents(transform.gameObject, includeDisabledComponents, results, append);
		}

		public static int GetComponents<T>(Component component, bool includeDisabledComponents, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponents(component.gameObject, includeDisabledComponents, results, append);
		}

		public static int GetComponents<T>(GameObject gameObject, bool includeDisabledComponents, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				gameObject.GetComponents(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					T val = list[i] as T;
					if (!IsNullOrDestroyed(val) && (includeDisabledComponents || IsEnabled(list[i])))
					{
						results.Add(val);
					}
				}
			}
			return results.Count;
		}

		public static int GetComponents(Transform transform, List<Component> results, bool append)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return GetComponents(transform.gameObject, results, append);
		}

		public static int GetComponents(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponents(component.gameObject, results, append);
		}

		public static int GetComponents(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				gameObject.GetComponents(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					Component component = list[i];
					if (!(component == null))
					{
						results.Add(component);
					}
				}
			}
			return results.Count;
		}

		public static int GetComponents(Transform transform, Type type, List<Component> results, bool append)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return GetComponents(transform.gameObject, type, results, append);
		}

		public static int GetComponents(Component component, Type type, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponents(component.gameObject, type, results, append);
		}

		public static int GetComponents(GameObject gameObject, Type type, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				gameObject.GetComponents(type, list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					Component component = list[i];
					if (!(component == null))
					{
						results.Add(component);
					}
				}
			}
			return results.Count;
		}

		public static int GetComponentsInSelfAndChildren(Transform transform, List<Component> results, bool append)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				transform.GetComponents(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					Component component = list[i];
					if (!(component == null))
					{
						results.Add(component);
					}
				}
			}
			int childCount = transform.childCount;
			for (int j = 0; j < childCount; j++)
			{
				GetComponentsInSelfAndChildren(transform.GetChild(j), results, append: true);
			}
			return results.Count;
		}

		public static int GetComponentsInSelfAndChildren(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInSelfAndChildren(component.transform, results, append);
		}

		public static int GetComponentsInSelfAndChildren(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInSelfAndChildren(gameObject.transform, results, append);
		}

		public static int GetComponentsInSelfAndChildren<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				transform.GetComponents(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					T val = list[i] as T;
					if (!IsNullOrDestroyed(val))
					{
						results.Add(val);
					}
				}
			}
			int childCount = transform.childCount;
			for (int j = 0; j < childCount; j++)
			{
				GetComponentsInSelfAndChildren(transform.GetChild(j), results, append: true);
			}
			return results.Count;
		}

		public static int GetComponentsInSelfAndChildren<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInSelfAndChildren(component.transform, results, append);
		}

		public static int GetComponentsInSelfAndChildren<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInSelfAndChildren(gameObject.transform, results, append);
		}

		public static int GetComponentsInSelfAndChildren<T>(Transform transform, GetComponentFlags options, List<T> results, bool append) where T : class
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				transform.GetComponents(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					T val = list[i] as T;
					if (!IsNullOrDestroyed(val) && ((options & GetComponentFlags.SkipDisabledComponents) == 0 || IsEnabled(list[i])))
					{
						results.Add(val);
					}
				}
			}
			int childCount = transform.childCount;
			for (int j = 0; j < childCount; j++)
			{
				Transform child = transform.GetChild(j);
				if (!(child == null) && ((options & GetComponentFlags.SkipInactiveGameObjectRelatives) == 0 || child.gameObject.activeSelf))
				{
					GetComponentsInSelfAndChildren(child, options, results, append: true);
				}
			}
			return results.Count;
		}

		public static int GetComponentsInSelfAndChildren<T>(Component component, GetComponentFlags options, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInSelfAndChildren(component.transform, options, results, append);
		}

		public static int GetComponentsInSelfAndChildren<T>(GameObject gameObject, GetComponentFlags options, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInSelfAndChildren(gameObject.transform, options, results, append);
		}

		public static int GetComponentsInChildren<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (!append)
			{
				results.Clear();
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				GetComponentsInSelfAndChildren(transform.GetChild(i), results, append: true);
			}
			return results.Count;
		}

		public static int GetComponentsInChildren<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInChildren(component.transform, results, append);
		}

		public static int GetComponentsInChildren<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInChildren(gameObject.transform, results, append);
		}

		public static int GetComponentsInChildren<T>(Transform transform, GetComponentFlags options, List<T> results, bool append) where T : class
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (!append)
			{
				results.Clear();
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				GetComponentsInSelfAndChildren(transform.GetChild(i), options, results, append: true);
			}
			return results.Count;
		}

		public static int GetComponentsInChildren<T>(Component component, GetComponentFlags options, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInChildren(component.transform, options, results, append);
		}

		public static int GetComponentsInChildren<T>(GameObject gameObject, GetComponentFlags options, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInChildren(gameObject.transform, options, results, append);
		}

		public static int GetComponentsInChildren(Transform transform, List<Component> results, bool append)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (!append)
			{
				results.Clear();
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				GetComponentsInSelfAndChildren(transform.GetChild(i), results, append: true);
			}
			return results.Count;
		}

		public static int GetComponentsInChildren(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInChildren(component.transform, results, append);
		}

		public static int GetComponentsInChildren(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInChildren(gameObject.transform, results, append);
		}

		public static int GetComponentsInParents<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return GetComponentsInParents(transform.gameObject, results, append);
		}

		public static int GetComponentsInParents<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInParents(component.gameObject, results, append);
		}

		public static int GetComponentsInParents<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!append)
			{
				results.Clear();
			}
			Transform parent = gameObject.transform.parent;
			while ((parent = parent.parent) != null)
			{
				GetComponents(parent, results, append: true);
			}
			return results.Count;
		}

		public static int GetComponentsInParents(Transform transform, List<Component> results, bool append)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return GetComponentsInParents(transform.gameObject, results, append);
		}

		public static int GetComponentsInParents(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInParents(component.gameObject, results, append);
		}

		public static int GetComponentsInParents(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!append)
			{
				results.Clear();
			}
			Transform parent = gameObject.transform.parent;
			while ((parent = parent.parent) != null)
			{
				GetComponents(parent, results, append: true);
			}
			return results.Count;
		}

		public static void ForEachComponent<T>(Transform transform, Action<T> @delegate, bool includeChildren) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (@delegate == null)
			{
				throw new ArgumentNullException("@delegate");
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				transform.GetComponents(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					T val = list[i] as T;
					if (!IsNullOrDestroyed(val))
					{
						@delegate(val);
					}
				}
			}
			if (includeChildren)
			{
				int childCount = transform.childCount;
				for (int j = 0; j < childCount; j++)
				{
					ForEachComponent(transform.GetChild(j), @delegate, includeChildren);
				}
			}
		}

		public static void ForEachComponent<T>(Transform transform, Action<T> @delegate) where T : class
		{
			ForEachComponent(transform, @delegate, includeChildren: false);
		}

		public static void ForEachComponent<T>(Component component, Action<T> @delegate, bool includeChildren) where T : class
		{
			ForEachComponent(component.transform, @delegate, includeChildren);
		}

		public static void ForEachComponent<T>(Component component, Action<T> @delegate) where T : class
		{
			ForEachComponent(component.transform, @delegate, includeChildren: false);
		}

		public static void ForEachComponent<T>(GameObject gameObject, Action<T> @delegate, bool includeChildren) where T : class
		{
			ForEachComponent(gameObject.transform, @delegate, includeChildren);
		}

		public static void ForEachComponent<T>(GameObject gameObject, Action<T> @delegate) where T : class
		{
			ForEachComponent(gameObject.transform, @delegate, includeChildren: false);
		}

		public static void ForEachComponentInChildren<T>(Transform transform, Action<T> @delegate) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (@delegate == null)
			{
				throw new ArgumentNullException("@delegate");
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				ForEachComponent(transform.GetChild(i), @delegate, includeChildren: true);
			}
		}

		public static void ForEachComponentInChildren<T>(Component component, Action<T> @delegate) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			ForEachComponentInChildren(component.transform, @delegate);
		}

		public static void ForEachComponentInChildren<T>(GameObject gameObject, Action<T> @delegate) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			ForEachComponentInChildren(gameObject.transform, @delegate);
		}

		public static bool IsEnabled(Component component)
		{
			if (component == null)
			{
				return false;
			}
			Behaviour behaviour = component as Behaviour;
			if (behaviour != null && !behaviour.enabled)
			{
				return false;
			}
			return true;
		}

		public static bool IsActiveAndEnabled(Component component)
		{
			if (component == null)
			{
				return false;
			}
			Behaviour behaviour = component as Behaviour;
			if (behaviour != null)
			{
				return behaviour.isActiveAndEnabled;
			}
			if (!component.gameObject.activeInHierarchy)
			{
				return false;
			}
			return true;
		}

		public static UnityEngine.Object Instantiate(UnityEngine.Object original, Transform parent, bool instantiateInWorldSpace)
		{
			return Instantiate<UnityEngine.Object>(original, Vector3.zero, Quaternion.identity, parent, instantiateInWorldSpace);
		}

		public static UnityEngine.Object Instantiate(UnityEngine.Object original, Vector3 position, Quaternion rotation, Transform parent, bool instantiateInWorldSpace)
		{
			return Instantiate<UnityEngine.Object>(original, position, rotation, parent, instantiateInWorldSpace);
		}

		public static T Instantiate<T>(UnityEngine.Object original, Transform parent, bool instantiateInWorldSpace) where T : UnityEngine.Object
		{
			return Instantiate<T>(original, Vector3.zero, Quaternion.identity, parent, instantiateInWorldSpace);
		}

		public static T Instantiate<T>(UnityEngine.Object original, Vector3 position, Quaternion rotation, Transform parent, bool instantiateInWorldSpace) where T : UnityEngine.Object
		{
			if (original == null)
			{
				return null;
			}
			UnityEngine.Object obj = UnityEngine.Object.Instantiate(original);
			if (parent != null)
			{
				Transform transform = null;
				if (obj as Component != null)
				{
					transform = (obj as Component).transform;
				}
				else if (obj as GameObject != null)
				{
					transform = (obj as GameObject).transform;
				}
				else if (obj as Transform != null)
				{
					transform = obj as Transform;
				}
				if (transform != null)
				{
					if (!instantiateInWorldSpace)
					{
						Vector3 localScale = transform.localScale;
						transform.parent = parent;
						transform.localPosition = position;
						transform.localRotation = rotation;
						transform.localScale = localScale;
					}
					else
					{
						transform.position = position;
						transform.rotation = rotation;
						transform.parent = parent;
					}
				}
			}
			if (IsNullOrDestroyed(obj as T))
			{
				if (obj as GameObject != null)
				{
					return AwdCUlcKsgfnGhfiFrDivoohYXHy((obj as GameObject).GetComponent(typeof(T)) as T);
				}
				if (obj as Transform != null)
				{
					return AwdCUlcKsgfnGhfiFrDivoohYXHy((obj as Transform).GetComponent(typeof(T)) as T);
				}
			}
			return AwdCUlcKsgfnGhfiFrDivoohYXHy(obj as T);
		}

		public static Vector3 TransformPoint(Transform from, Transform to, Vector3 point)
		{
			Vector3 vector = ((from != null) ? from.TransformPoint(point) : point);
			if (to == null)
			{
				return vector;
			}
			return to.InverseTransformPoint(vector);
		}

		public static Vector3 TransformPoint(Transform from, Transform to)
		{
			return TransformPoint(from, to, Vector3.zero);
		}

		public static Vector3 TransformDirection(Transform from, Transform to, Vector3 direction)
		{
			Vector3 vector = ((from != null) ? from.TransformDirection(direction) : direction);
			if (to == null)
			{
				return vector;
			}
			return to.InverseTransformDirection(vector);
		}

		public static Vector3 TransformDirection(Transform from, Transform to)
		{
			return TransformDirection(from, to, Vector3.zero);
		}

		public static Vector3 TransformVector(Transform from, Transform to, Vector3 vector)
		{
			Vector3 vector2 = ((from != null) ? (from.TransformPoint(vector) - from.position) : Vector3.zero);
			if (to == null)
			{
				return vector2;
			}
			return to.InverseTransformPoint(vector2 + to.position);
		}

		public static Vector3 TransformVector(Transform from, Transform to)
		{
			return TransformVector(from, to, Vector3.zero);
		}

		public static Rect TransformRect(Transform from, Transform to, Rect rect)
		{
			Vector3 position;
			Vector3 position2;
			Vector3 position3;
			if (from != null)
			{
				position = from.TransformPoint(new Vector2(rect.xMin, rect.yMin));
				position2 = from.TransformPoint(new Vector2(rect.xMin, rect.yMax));
				position3 = from.TransformPoint(new Vector2(rect.xMax, rect.yMin));
			}
			else
			{
				position = new Vector2(rect.xMin, rect.yMin);
				position2 = new Vector2(rect.xMin, rect.yMax);
				position3 = new Vector2(rect.xMax, rect.yMin);
			}
			if (to != null)
			{
				position = to.InverseTransformPoint(position);
				position2 = to.InverseTransformPoint(position2);
				position3 = to.InverseTransformPoint(position3);
			}
			return new Rect(position.x, position.y, position3.x - position.x, position.y - position2.y);
		}

		public static void DebugDrawCross(Vector3 position, float length, Color color)
		{
			Debug.DrawLine(position - Vector3.up * length * 0.5f, position + Vector3.up * length * 0.5f, color);
			Debug.DrawLine(position - Vector3.right * length * 0.5f, position + Vector3.right * length * 0.5f, color);
			Debug.DrawLine(position - Vector3.forward * length * 0.5f, position + Vector3.forward * length * 0.5f, color);
		}

		public static void DebugDrawCross(Vector3 position, float length, Color color, float duration)
		{
			Debug.DrawLine(position - Vector3.up * length * 0.5f, position + Vector3.up * length * 0.5f, color, duration);
			Debug.DrawLine(position - Vector3.right * length * 0.5f, position + Vector3.right * length * 0.5f, color, duration);
			Debug.DrawLine(position - Vector3.forward * length * 0.5f, position + Vector3.forward * length * 0.5f, color, duration);
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsObjectInScene<T>(T @object) where T : UnityEngine.Object
		{
			T[] array = FindObjectsOfType<T>();
			if (array == null)
			{
				return false;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == @object)
				{
					return true;
				}
			}
			return false;
		}

		[CustomObfuscation(rename = false)]
		internal static T[] FindObjectsOfType<T>() where T : UnityEngine.Object
		{
			return UnityEngine.Object.FindObjectsOfType<T>();
		}

		[CustomObfuscation(rename = false)]
		internal static T FindObjectOfType<T>() where T : UnityEngine.Object
		{
			return UnityEngine.Object.FindObjectOfType<T>();
		}

		public static string GetUnityInputAxisName(int unityJoystickIndex, int axisIndex)
		{
			return GetUnityInputAxisNameByJoystickId(unityJoystickIndex + 1, axisIndex);
		}

		public static string GetUnityInputAxisNameByJoystickId(int unityJoystickId, int axisIndex)
		{
			return "Joy" + unityJoystickId + "Axis" + (axisIndex + 1);
		}

		public static string GetUnityInputButtonName(int unityJoystickIndex, int buttonIndex)
		{
			return GetUnityInputButtonNameByJoystickId(unityJoystickIndex + 1, buttonIndex);
		}

		public static string GetUnityInputButtonNameByJoystickId(int unityJoystickId, int buttonIndex)
		{
			return "Joy" + unityJoystickId + "Button" + buttonIndex;
		}

		public static bool IsValidUnityJoystickName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && KBreLSbJoDABXLXxdVUGmDvXPgsB)
				{
					return false;
				}
				if (nxXGKovNVIBFDeTaiAJUBQNDUxdfA)
				{
					return false;
				}
			}
			else
			{
				if (!UnityInputManagerSettings.QlCXBAmKPkYBRufluhMnGPBirkFZA(name))
				{
					return false;
				}
				if (DbPUEpdvOXfMCJpktHaVOwTdGQteA && name.Equals(CLJlILIgZRWWRiTYcmnengVCeSak, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
				if (SgAjAZsOCUmuDWgIUXVykdoqejEA && name.IndexOf("keyboard", 0, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return false;
				}
			}
			return true;
		}

		public static AnimationCurve Copy(AnimationCurve orig)
		{
			if (orig == null)
			{
				return null;
			}
			Keyframe[] keys = orig.keys;
			AnimationCurve animationCurve = ((keys == null) ? new AnimationCurve() : new AnimationCurve(keys));
			animationCurve.postWrapMode = orig.postWrapMode;
			animationCurve.preWrapMode = orig.preWrapMode;
			return animationCurve;
		}

		public static bool IsNullOrDestroyed(object @object)
		{
			if (@object == null)
			{
				return true;
			}
			if (@object is UnityEngine.Object)
			{
				return @object as UnityEngine.Object == null;
			}
			return false;
		}

		public static bool IsNullOrDestroyed<T>(T @object) where T : class
		{
			if (@object == null)
			{
				return true;
			}
			if (@object is UnityEngine.Object)
			{
				return @object as UnityEngine.Object == null;
			}
			return false;
		}

		private static _0001 AwdCUlcKsgfnGhfiFrDivoohYXHy<_0001>(_0001 P_0) where _0001 : class
		{
			if (P_0 == null)
			{
				return null;
			}
			if (P_0 is UnityEngine.Object && P_0 as UnityEngine.Object == null)
			{
				return null;
			}
			return P_0;
		}

		internal static ButtonStateFlags mfdfzeynkuBAbsZcXwtMhpgHeziI(KeyboardKeyCode P_0)
		{
			ButtonStateFlags buttonStateFlags = (UnityInputHelper.GetKey(P_0) ? ButtonStateFlags.On : ButtonStateFlags.Off);
			if (UnityInputHelper.GetKeyDown(P_0))
			{
				buttonStateFlags |= ButtonStateFlags.Down;
			}
			if (UnityInputHelper.GetKeyUp(P_0))
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		internal static ButtonStateFlags fYsckMWTaZIymrtZZFiBKWsZnsakA(string P_0)
		{
			ButtonStateFlags buttonStateFlags = (UnityInputHelper.GetButton(P_0) ? ButtonStateFlags.On : ButtonStateFlags.Off);
			if (UnityInputHelper.GetButtonDown(P_0))
			{
				buttonStateFlags |= ButtonStateFlags.Down;
			}
			if (UnityInputHelper.GetButtonUp(P_0))
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		[CustomObfuscation(rename = false)]
		internal static IList<Assembly> GetCurrentAssemblies()
		{
			return AppDomain.CurrentDomain.GetAssemblies();
		}
	}
}
