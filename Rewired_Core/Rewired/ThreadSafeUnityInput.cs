using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class ThreadSafeUnityInput
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Keyboard
		{
			private class IYeBUAZGeHikeBqGeTsFUCespbObb
			{
				private readonly bool[] PHlTkiBkwUwsTLdMBafUEADdSLyT;

				private readonly bool[] JQIeXqEFXCbZcHxOxKwGPfEokZaf;

				private bool LediNjgjuoAGePuYUSQkdyhAAYSe;

				private bool RjuelAklZdlkobJQNxEumephnsOM;

				public bool[] UFiTEZGOBgIXUmQnYlYVHKOdgtjy => PHlTkiBkwUwsTLdMBafUEADdSLyT;

				public bool[] LTpLwRCmGNGTHRdQwWbVNfhCiIWv => JQIeXqEFXCbZcHxOxKwGPfEokZaf;

				public IYeBUAZGeHikeBqGeTsFUCespbObb()
				{
					PHlTkiBkwUwsTLdMBafUEADdSLyT = new bool[132];
					JQIeXqEFXCbZcHxOxKwGPfEokZaf = new bool[132];
				}

				public void mHGOqqEUlKxEdyFlJDvTvLaWCkKR(bool P_0)
				{
					if (P_0)
					{
						for (int i = 0; i < PHlTkiBkwUwsTLdMBafUEADdSLyT.Length; i++)
						{
							if (PHlTkiBkwUwsTLdMBafUEADdSLyT[i])
							{
								JQIeXqEFXCbZcHxOxKwGPfEokZaf[i] = true;
							}
						}
						RjuelAklZdlkobJQNxEumephnsOM = true;
						LediNjgjuoAGePuYUSQkdyhAAYSe = true;
					}
					else if (LediNjgjuoAGePuYUSQkdyhAAYSe)
					{
						Array.Clear(PHlTkiBkwUwsTLdMBafUEADdSLyT, 0, PHlTkiBkwUwsTLdMBafUEADdSLyT.Length);
						LediNjgjuoAGePuYUSQkdyhAAYSe = false;
					}
				}

				public void isgvoWIcszYQjkOmvlbtaQOAKZJI()
				{
					if (RjuelAklZdlkobJQNxEumephnsOM)
					{
						RjuelAklZdlkobJQNxEumephnsOM = false;
					}
					Array.Clear(JQIeXqEFXCbZcHxOxKwGPfEokZaf, 0, JQIeXqEFXCbZcHxOxKwGPfEokZaf.Length);
				}

				public void vfQQwRaTrfyqFYXUhRhWCuodKYpD()
				{
					LediNjgjuoAGePuYUSQkdyhAAYSe = false;
					RjuelAklZdlkobJQNxEumephnsOM = false;
					Array.Clear(PHlTkiBkwUwsTLdMBafUEADdSLyT, 0, PHlTkiBkwUwsTLdMBafUEADdSLyT.Length);
					Array.Clear(JQIeXqEFXCbZcHxOxKwGPfEokZaf, 0, JQIeXqEFXCbZcHxOxKwGPfEokZaf.Length);
				}
			}

			private const int UzcggWvkYtUFUmWpEklSOaXviLCt = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] AnYEddvxhezwQNFCIHcMvvJLdLoX;

			private readonly int jCTXgscieLnZRKQeWnrTkGCQzimf;

			private readonly int[] OYRBQndmIBqDOSiuYbQBBjKbobbtA;

			private readonly IYeBUAZGeHikeBqGeTsFUCespbObb FkUpZbKkWSufAtomNiFfNDcAHkbD;

			private bool vOTeYVqICcGbLKbGzKQfbvswELWV;

			private int MtyZaERsJROhnMyAZNpRJCsJIECi;

			private readonly bool mbPzojhyRUibSDjMmJthefkcniZW;

			private Action BsWPGsSDEVRjgxvxLSprJBWrkprK;

			public bool enabled
			{
				get
				{
					return vOTeYVqICcGbLKbGzKQfbvswELWV;
				}
				set
				{
					if (value != vOTeYVqICcGbLKbGzKQfbvswELWV)
					{
						vOTeYVqICcGbLKbGzKQfbvswELWV = value;
						if (!vOTeYVqICcGbLKbGzKQfbvswELWV)
						{
							Clear();
						}
					}
				}
			}

			public bool monitoring => MtyZaERsJROhnMyAZNpRJCsJIECi > 0;

			public int keyCount => 132;

			public event Action KeyboardLayoutChangedEvent
			{
				add
				{
					BsWPGsSDEVRjgxvxLSprJBWrkprK = (Action)Delegate.Combine(BsWPGsSDEVRjgxvxLSprJBWrkprK, value);
				}
				remove
				{
					BsWPGsSDEVRjgxvxLSprJBWrkprK = (Action)Delegate.Remove(BsWPGsSDEVRjgxvxLSprJBWrkprK, value);
				}
			}

			static Keyboard()
			{
				if (UnityTools.isAndroidPlatform)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					AnYEddvxhezwQNFCIHcMvvJLdLoX = new int[7]
					{
						(keyValueIndex_Escape = ArrayTools.IndexOf(keyboardKeyValues, 27)),
						(keyValueIndex_Menu = ArrayTools.IndexOf(keyboardKeyValues, 319)),
						(keyValueIndex_F2 = ArrayTools.IndexOf(keyboardKeyValues, 283)),
						(keyValueIndex_UpArrow = ArrayTools.IndexOf(keyboardKeyValues, 273)),
						(keyValueIndex_RightArrow = ArrayTools.IndexOf(keyboardKeyValues, 275)),
						(keyValueIndex_DownArrow = ArrayTools.IndexOf(keyboardKeyValues, 274)),
						(keyValueIndex_LeftArrow = ArrayTools.IndexOf(keyboardKeyValues, 276))
					};
				}
			}

			public Keyboard()
			{
				mbPzojhyRUibSDjMmJthefkcniZW = UnityTools.isAndroidPlatform;
				FkUpZbKkWSufAtomNiFfNDcAHkbD = new IYeBUAZGeHikeBqGeTsFUCespbObb();
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > jCTXgscieLnZRKQeWnrTkGCQzimf)
					{
						jCTXgscieLnZRKQeWnrTkGCQzimf = keyboardKeyValues[i];
					}
				}
				OYRBQndmIBqDOSiuYbQBBjKbobbtA = new int[jCTXgscieLnZRKQeWnrTkGCQzimf + 1];
				ArrayTools.Fill(OYRBQndmIBqDOSiuYbQBBjKbobbtA, -1);
				for (int j = 0; j < num; j++)
				{
					OYRBQndmIBqDOSiuYbQBBjKbobbtA[keyboardKeyValues[j]] = j;
				}
				lqOJoawhNiBadVgeqFIQOhCLxlmV();
			}

			private void lqOJoawhNiBadVgeqFIQOhCLxlmV()
			{
				if (MtyZaERsJROhnMyAZNpRJCsJIECi != 0)
				{
					KsZKtwEXcRdOEsqqubjOSONKmCCS();
				}
				hUQAIcdeQbyHkuaxegdcqtkKPSIrA();
				UnityInputHelper.KeyboardLayoutChangedEvent += cQdAOoBOxjANgIPjmMFwVMUTrVoH;
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Deinitialize()
			{
				UnityInputHelper.KeyboardLayoutChangedEvent -= cQdAOoBOxjANgIPjmMFwVMUTrVoH;
			}

			public void ThreadFrameStart()
			{
				FkUpZbKkWSufAtomNiFfNDcAHkbD.isgvoWIcszYQjkOmvlbtaQOAKZJI();
			}

			public void Update()
			{
				if (MtyZaERsJROhnMyAZNpRJCsJIECi == 0)
				{
					return;
				}
				bool flag = UnityInputHelper.anyKey;
				if (flag)
				{
					bool[] array = FkUpZbKkWSufAtomNiFfNDcAHkbD.UFiTEZGOBgIXUmQnYlYVHKOdgtjy;
					if (vOTeYVqICcGbLKbGzKQfbvswELWV)
					{
						int[] keyboardKeyValues = Consts._keyboardKeyValues;
						for (int i = 0; i < 132; i++)
						{
							array[i] = UnityInputHelper.GetKey((KeyboardKeyCode)keyboardKeyValues[i]);
						}
					}
					else if (mbPzojhyRUibSDjMmJthefkcniZW)
					{
						array[keyValueIndex_Escape] = UnityInputHelper.GetKey(KeyboardKeyCode.Escape);
						array[keyValueIndex_Menu] = UnityInputHelper.GetKey(KeyboardKeyCode.Menu);
						array[keyValueIndex_F2] = UnityInputHelper.GetKey(KeyboardKeyCode.F2);
						array[keyValueIndex_UpArrow] = UnityInputHelper.GetKey(KeyboardKeyCode.UpArrow);
						array[keyValueIndex_RightArrow] = UnityInputHelper.GetKey(KeyboardKeyCode.RightArrow);
						array[keyValueIndex_DownArrow] = UnityInputHelper.GetKey(KeyboardKeyCode.DownArrow);
						array[keyValueIndex_LeftArrow] = UnityInputHelper.GetKey(KeyboardKeyCode.LeftArrow);
					}
					else
					{
						flag = false;
					}
				}
				FkUpZbKkWSufAtomNiFfNDcAHkbD.mHGOqqEUlKxEdyFlJDvTvLaWCkKR(flag);
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					MtyZaERsJROhnMyAZNpRJCsJIECi++;
					if (MtyZaERsJROhnMyAZNpRJCsJIECi == 1)
					{
						lqVwZJvBsHNIVGBDKnxbbqjssjAk();
					}
					return;
				}
				MtyZaERsJROhnMyAZNpRJCsJIECi--;
				if (MtyZaERsJROhnMyAZNpRJCsJIECi < 0)
				{
					MtyZaERsJROhnMyAZNpRJCsJIECi = 0;
					PtDSZmJwzNWatyoXoDdzCoXMtonF();
				}
				if (MtyZaERsJROhnMyAZNpRJCsJIECi == 0)
				{
					HIndYNHFPCQhtmDXIkgUXuegxymq();
				}
			}

			public void GetThreadFrameKeyValues(bool[] values)
			{
				if (MtyZaERsJROhnMyAZNpRJCsJIECi == 0)
				{
					OKXWlbYmGvTwvNmHFAlQvGNYcewY();
				}
				else if (values != null && values.Length >= 132)
				{
					Array.Copy(FkUpZbKkWSufAtomNiFfNDcAHkbD.LTpLwRCmGNGTHRdQwWbVNfhCiIWv, values, 132);
				}
			}

			public bool GetKeyLabels(string[] keyLabels, string[] modifierShortLabels, string[] modifierLongLabels)
			{
				if (keyLabels == null || keyLabels.Length != 132)
				{
					return false;
				}
				return UnityInputHelper.GetKeyLabels(keyLabels, modifierShortLabels, modifierLongLabels);
			}

			public void Clear()
			{
				if (mbPzojhyRUibSDjMmJthefkcniZW)
				{
					bool[] array = FkUpZbKkWSufAtomNiFfNDcAHkbD.UFiTEZGOBgIXUmQnYlYVHKOdgtjy;
					for (int i = 0; i < 132; i++)
					{
						if (Array.IndexOf(AnYEddvxhezwQNFCIHcMvvJLdLoX, i) < 0)
						{
							array[i] = false;
						}
					}
				}
				else
				{
					FkUpZbKkWSufAtomNiFfNDcAHkbD.vfQQwRaTrfyqFYXUhRhWCuodKYpD();
				}
			}

			private void KsZKtwEXcRdOEsqqubjOSONKmCCS()
			{
				FkUpZbKkWSufAtomNiFfNDcAHkbD.vfQQwRaTrfyqFYXUhRhWCuodKYpD();
			}

			private void hUQAIcdeQbyHkuaxegdcqtkKPSIrA()
			{
				MtyZaERsJROhnMyAZNpRJCsJIECi = 0;
				vOTeYVqICcGbLKbGzKQfbvswELWV = true;
			}

			private void lqVwZJvBsHNIVGBDKnxbbqjssjAk()
			{
			}

			private void HIndYNHFPCQhtmDXIkgUXuegxymq()
			{
				KsZKtwEXcRdOEsqqubjOSONKmCCS();
			}

			private void OKXWlbYmGvTwvNmHFAlQvGNYcewY()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void PtDSZmJwzNWatyoXoDdzCoXMtonF()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}

			private void cQdAOoBOxjANgIPjmMFwVMUTrVoH()
			{
				BsWPGsSDEVRjgxvxLSprJBWrkprK?.Invoke();
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private class zDUOYFQhLTqxLOKzKctvPQGbSbwV
			{
				private readonly bool[] OLSTbemroFVrfTHlvacJzEmHACfv;

				private readonly bool[] YvBnYHlAJJYVhccVdTVnNaflsYin;

				private readonly float[] ykjbSQwurXGJyoKslbQCGnibiZbi;

				private readonly float[] gIeclYvfOMvIFpdUWFpOdrJBqxXrA;

				public bool[] GSkUjIdPtGfALRRVOjASGCRjDaoP => OLSTbemroFVrfTHlvacJzEmHACfv;

				public bool[] jkxIpRprutpeoYSoIReyGHgUHUicA => YvBnYHlAJJYVhccVdTVnNaflsYin;

				public float[] YjfwdiubvsynSrbRsHDimeDVKscT => ykjbSQwurXGJyoKslbQCGnibiZbi;

				public float[] RgZDVupSUDrINWAqSwUSScPmAedK => gIeclYvfOMvIFpdUWFpOdrJBqxXrA;

				public zDUOYFQhLTqxLOKzKctvPQGbSbwV()
				{
					OLSTbemroFVrfTHlvacJzEmHACfv = new bool[7];
					YvBnYHlAJJYVhccVdTVnNaflsYin = new bool[7];
					ykjbSQwurXGJyoKslbQCGnibiZbi = new float[4];
					gIeclYvfOMvIFpdUWFpOdrJBqxXrA = new float[4];
				}

				public void IpMvaMeBgbzkFDVACIWUZlhcaKqN()
				{
					for (int i = 0; i < OLSTbemroFVrfTHlvacJzEmHACfv.Length; i++)
					{
						if (OLSTbemroFVrfTHlvacJzEmHACfv[i])
						{
							YvBnYHlAJJYVhccVdTVnNaflsYin[i] = true;
						}
					}
					for (int j = 0; j < ykjbSQwurXGJyoKslbQCGnibiZbi.Length; j++)
					{
						gIeclYvfOMvIFpdUWFpOdrJBqxXrA[j] += ykjbSQwurXGJyoKslbQCGnibiZbi[j];
					}
				}

				public void BOuUHRNWUWGgeDnTHDYBSQtLncOv()
				{
					Array.Clear(YvBnYHlAJJYVhccVdTVnNaflsYin, 0, YvBnYHlAJJYVhccVdTVnNaflsYin.Length);
					Array.Clear(gIeclYvfOMvIFpdUWFpOdrJBqxXrA, 0, gIeclYvfOMvIFpdUWFpOdrJBqxXrA.Length);
				}

				public void sKqdffqVfFpqQyMWSWOLmeHQRizl()
				{
					Array.Clear(OLSTbemroFVrfTHlvacJzEmHACfv, 0, OLSTbemroFVrfTHlvacJzEmHACfv.Length);
					Array.Clear(YvBnYHlAJJYVhccVdTVnNaflsYin, 0, YvBnYHlAJJYVhccVdTVnNaflsYin.Length);
					Array.Clear(ykjbSQwurXGJyoKslbQCGnibiZbi, 0, ykjbSQwurXGJyoKslbQCGnibiZbi.Length);
					Array.Clear(gIeclYvfOMvIFpdUWFpOdrJBqxXrA, 0, gIeclYvfOMvIFpdUWFpOdrJBqxXrA.Length);
				}
			}

			private const int iHtYjXGleuYmyXKIsjVmBrKqtgcHA = 7;

			private const int yeAhaQxNLPTaGBpPZfXMJzpWAJwk = 4;

			private readonly zDUOYFQhLTqxLOKzKctvPQGbSbwV TAjdZZYFbjbltCWdgYerlDzeonIAb;

			private int yhBUMhKEPsdaebIPOBAdDQFbmJYub;

			private Vector3 pzJixlntsSKDcWuJuiyKrvUAXeoB;

			private bool kNZrUIVPYqakxEVDRJodfCqElyLfc;

			private Action ajRTaSeyeMfHpXXDghUpnyuFtUVB;

			public bool monitoring => yhBUMhKEPsdaebIPOBAdDQFbmJYub > 0;

			public Vector3 mousePosition => pzJixlntsSKDcWuJuiyKrvUAXeoB;

			public bool mousePresent => kNZrUIVPYqakxEVDRJodfCqElyLfc;

			public event Action InputUpdatedEvent
			{
				add
				{
					ajRTaSeyeMfHpXXDghUpnyuFtUVB = (Action)Delegate.Combine(ajRTaSeyeMfHpXXDghUpnyuFtUVB, value);
				}
				remove
				{
					ajRTaSeyeMfHpXXDghUpnyuFtUVB = (Action)Delegate.Remove(ajRTaSeyeMfHpXXDghUpnyuFtUVB, value);
				}
			}

			public Mouse()
			{
				TAjdZZYFbjbltCWdgYerlDzeonIAb = new zDUOYFQhLTqxLOKzKctvPQGbSbwV();
				KsXdMHxbFLqPuRQsiqLITqkQcJMl();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void ThreadFrameStart()
			{
				TAjdZZYFbjbltCWdgYerlDzeonIAb.BOuUHRNWUWGgeDnTHDYBSQtLncOv();
			}

			public void Update()
			{
				if (yhBUMhKEPsdaebIPOBAdDQFbmJYub != 0)
				{
					bool[] array = TAjdZZYFbjbltCWdgYerlDzeonIAb.GSkUjIdPtGfALRRVOjASGCRjDaoP;
					float[] array2 = TAjdZZYFbjbltCWdgYerlDzeonIAb.YjfwdiubvsynSrbRsHDimeDVKscT;
					for (int i = 0; i < 7; i++)
					{
						array[i] = UnityInputHelper.GetButton(Consts.mouseButtonUnityNames[i]);
					}
					for (int j = 0; j < 3; j++)
					{
						array2[j] = UnityInputHelper.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
					}
					array2[3] = UnityInputHelper.mouseScrollDelta.x;
					pzJixlntsSKDcWuJuiyKrvUAXeoB = UnityInputHelper.mousePosition;
					kNZrUIVPYqakxEVDRJodfCqElyLfc = UnityInputHelper.mousePresent;
					TAjdZZYFbjbltCWdgYerlDzeonIAb.IpMvaMeBgbzkFDVACIWUZlhcaKqN();
					ajRTaSeyeMfHpXXDghUpnyuFtUVB?.Invoke();
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					yhBUMhKEPsdaebIPOBAdDQFbmJYub++;
					if (yhBUMhKEPsdaebIPOBAdDQFbmJYub == 1)
					{
						YYhJfwzdhKXbsMgdXDtNsBehIBNl();
					}
					return;
				}
				yhBUMhKEPsdaebIPOBAdDQFbmJYub--;
				if (yhBUMhKEPsdaebIPOBAdDQFbmJYub < 0)
				{
					yhBUMhKEPsdaebIPOBAdDQFbmJYub = 0;
					qjpYsMzOzNWxpxekvPwjMofQffmW();
				}
				if (yhBUMhKEPsdaebIPOBAdDQFbmJYub == 0)
				{
					izVdFgsCvCXFRaxGUeGQwdhfkKZJ();
				}
			}

			public void GetLatestButtonValues(bool[] buttons)
			{
				if (yhBUMhKEPsdaebIPOBAdDQFbmJYub == 0)
				{
					tynSXuJCZmLOwldiNqJoWpxMoTQM();
				}
				else if (buttons != null && buttons.Length >= 7)
				{
					Array.Copy(TAjdZZYFbjbltCWdgYerlDzeonIAb.GSkUjIdPtGfALRRVOjASGCRjDaoP, buttons, 7);
				}
			}

			public void GetLatestAxisValues(float[] axes)
			{
				if (yhBUMhKEPsdaebIPOBAdDQFbmJYub == 0)
				{
					tynSXuJCZmLOwldiNqJoWpxMoTQM();
				}
				else if (axes != null && axes.Length >= 4)
				{
					Array.Copy(TAjdZZYFbjbltCWdgYerlDzeonIAb.YjfwdiubvsynSrbRsHDimeDVKscT, axes, 4);
				}
			}

			public void GetThreadFrameButtonValues(bool[] buttons)
			{
				if (yhBUMhKEPsdaebIPOBAdDQFbmJYub == 0)
				{
					tynSXuJCZmLOwldiNqJoWpxMoTQM();
				}
				else if (buttons != null && buttons.Length >= 7)
				{
					Array.Copy(TAjdZZYFbjbltCWdgYerlDzeonIAb.jkxIpRprutpeoYSoIReyGHgUHUicA, buttons, 7);
				}
			}

			public void GetThreadFrameAxisValues(float[] axes)
			{
				if (yhBUMhKEPsdaebIPOBAdDQFbmJYub == 0)
				{
					tynSXuJCZmLOwldiNqJoWpxMoTQM();
				}
				else if (axes != null && axes.Length >= 4)
				{
					Array.Copy(TAjdZZYFbjbltCWdgYerlDzeonIAb.RgZDVupSUDrINWAqSwUSScPmAedK, axes, 4);
				}
			}

			private void wLfUutrMvTaGCeWuklLRffyQOYTgA()
			{
				TAjdZZYFbjbltCWdgYerlDzeonIAb.sKqdffqVfFpqQyMWSWOLmeHQRizl();
			}

			private void KsXdMHxbFLqPuRQsiqLITqkQcJMl()
			{
				yhBUMhKEPsdaebIPOBAdDQFbmJYub = 0;
				pzJixlntsSKDcWuJuiyKrvUAXeoB = Vector3.zero;
				kNZrUIVPYqakxEVDRJodfCqElyLfc = false;
			}

			private void YYhJfwzdhKXbsMgdXDtNsBehIBNl()
			{
			}

			private void izVdFgsCvCXFRaxGUeGQwdhfkKZJ()
			{
				wLfUutrMvTaGCeWuklLRffyQOYTgA();
			}

			private void tynSXuJCZmLOwldiNqJoWpxMoTQM()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void qjpYsMzOzNWxpxekvPwjMofQffmW()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		private static Mouse GsSFnahdBgUMihpcEIwIdPdWLrJz;

		private static Keyboard seTnzPvfbLeJHiPJXmEbNRqwKuiN;

		public static Mouse mouse => GsSFnahdBgUMihpcEIwIdPdWLrJz ?? (GsSFnahdBgUMihpcEIwIdPdWLrJz = new Mouse());

		public static Keyboard keyboard => seTnzPvfbLeJHiPJXmEbNRqwKuiN ?? (seTnzPvfbLeJHiPJXmEbNRqwKuiN = new Keyboard());

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (seTnzPvfbLeJHiPJXmEbNRqwKuiN != null)
			{
				seTnzPvfbLeJHiPJXmEbNRqwKuiN.PostInitialize();
			}
			if (GsSFnahdBgUMihpcEIwIdPdWLrJz != null)
			{
				GsSFnahdBgUMihpcEIwIdPdWLrJz.PostInitialize();
			}
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (seTnzPvfbLeJHiPJXmEbNRqwKuiN != null)
			{
				seTnzPvfbLeJHiPJXmEbNRqwKuiN.Deinitialize();
				seTnzPvfbLeJHiPJXmEbNRqwKuiN = null;
			}
			if (GsSFnahdBgUMihpcEIwIdPdWLrJz != null)
			{
				GsSFnahdBgUMihpcEIwIdPdWLrJz = null;
			}
		}

		public static void ThreadFrameStart()
		{
			if (seTnzPvfbLeJHiPJXmEbNRqwKuiN != null)
			{
				seTnzPvfbLeJHiPJXmEbNRqwKuiN.ThreadFrameStart();
			}
			if (GsSFnahdBgUMihpcEIwIdPdWLrJz != null)
			{
				GsSFnahdBgUMihpcEIwIdPdWLrJz.ThreadFrameStart();
			}
		}

		public static void Update()
		{
			if (seTnzPvfbLeJHiPJXmEbNRqwKuiN != null)
			{
				seTnzPvfbLeJHiPJXmEbNRqwKuiN.enabled = ReInput.controllers.Keyboard.enabled;
				seTnzPvfbLeJHiPJXmEbNRqwKuiN.Update();
			}
			if (GsSFnahdBgUMihpcEIwIdPdWLrJz != null)
			{
				GsSFnahdBgUMihpcEIwIdPdWLrJz.Update();
			}
		}
	}
}
