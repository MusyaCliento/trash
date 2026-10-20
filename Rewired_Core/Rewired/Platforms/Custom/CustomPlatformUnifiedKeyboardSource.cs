using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformUnifiedKeyboardSource : CustomPlatformUnifiedControllerSource
	{
		public sealed class KeyPropertyMap
		{
			public struct Key
			{
				public KeyboardKeyCode keyCode;

				public string label;
			}

			private IndexedDictionary<int, string> lDVCGYekxiNZQhhddVvbtKEPdNaKA;

			private bool ybHjELaxDDEhSDOBbMdybCUOqrikb;

			internal bool GyUDhZinOkoTncKPwFSyKnHfGKdcb
			{
				get
				{
					return ybHjELaxDDEhSDOBbMdybCUOqrikb;
				}
				set
				{
					ybHjELaxDDEhSDOBbMdybCUOqrikb = flag;
				}
			}

			public KeyPropertyMap()
			{
				lDVCGYekxiNZQhhddVvbtKEPdNaKA = new IndexedDictionary<int, string>();
				IList<int> keyboardKeyValues = Consts.keyboardKeyValues;
				IList<string> keyboardKeyNames = Consts.keyboardKeyNames;
				for (int i = 0; i < 132; i++)
				{
					lDVCGYekxiNZQhhddVvbtKEPdNaKA.Add(keyboardKeyValues[i], keyboardKeyNames[i]);
				}
				ybHjELaxDDEhSDOBbMdybCUOqrikb = true;
			}

			public KeyPropertyMap(KeyPropertyMap P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("other");
				}
				lDVCGYekxiNZQhhddVvbtKEPdNaKA = new IndexedDictionary<int, string>(P_0.lDVCGYekxiNZQhhddVvbtKEPdNaKA);
				ybHjELaxDDEhSDOBbMdybCUOqrikb = true;
			}

			public Key Get(KeyboardKeyCode keyCode)
			{
				if (!lDVCGYekxiNZQhhddVvbtKEPdNaKA.TryGetValue((int)keyCode, out var value))
				{
					return default(Key);
				}
				return new Key
				{
					keyCode = keyCode,
					label = value
				};
			}

			public void Set(Key key)
			{
				lDVCGYekxiNZQhhddVvbtKEPdNaKA.SetValue((int)key.keyCode, key.label);
				ybHjELaxDDEhSDOBbMdybCUOqrikb = true;
			}

			public Key[] Get()
			{
				Key[] array = new Key[lDVCGYekxiNZQhhddVvbtKEPdNaKA.Count];
				int count = lDVCGYekxiNZQhhddVvbtKEPdNaKA.Count;
				for (int i = 0; i < count; i++)
				{
					array[i] = new Key
					{
						keyCode = (KeyboardKeyCode)lDVCGYekxiNZQhhddVvbtKEPdNaKA.GetKeyAt(i),
						label = lDVCGYekxiNZQhhddVvbtKEPdNaKA[i]
					};
				}
				return array;
			}

			public void Set(ICollection<Key> keys)
			{
				if (keys == null)
				{
					throw new ArgumentNullException("keys");
				}
				foreach (Key key in keys)
				{
					lDVCGYekxiNZQhhddVvbtKEPdNaKA.SetValue((int)key.keyCode, key.label);
				}
				ybHjELaxDDEhSDOBbMdybCUOqrikb = true;
			}
		}

		private KeyPropertyMap ckPHQbSSihzefKgxPbSYDEEdBfuDA;

		public KeyPropertyMap keyPropertyMap
		{
			get
			{
				if (ckPHQbSSihzefKgxPbSYDEEdBfuDA == null)
				{
					ckPHQbSSihzefKgxPbSYDEEdBfuDA = new KeyPropertyMap();
				}
				return ckPHQbSSihzefKgxPbSYDEEdBfuDA;
			}
			set
			{
				if (value == null)
				{
					value = new KeyPropertyMap();
				}
				ckPHQbSSihzefKgxPbSYDEEdBfuDA = value;
				lBYaXrtMHWcGYCitHLhnVDQrkBFt();
			}
		}

		public CustomPlatformUnifiedKeyboardSource()
			: base(0, Consts._keyboardKeyValues.Length)
		{
		}

		protected void SetKeyValue(KeyboardKeyCode keyCode, bool value)
		{
			int buttonIndex = ReInput.controllers.Keyboard.GetButtonIndex(keyCode);
			if (buttonIndex >= 0)
			{
				SetButtonValue(buttonIndex, value);
			}
		}

		internal virtual void xyVZWItmIRpqiMpHdsHsKyhjPdub()
		{
			base.BwXxQVCcuUbHwQlFMldfyFIxjspfA();
			if (ckPHQbSSihzefKgxPbSYDEEdBfuDA != null && ckPHQbSSihzefKgxPbSYDEEdBfuDA.GyUDhZinOkoTncKPwFSyKnHfGKdcb)
			{
				lBYaXrtMHWcGYCitHLhnVDQrkBFt();
			}
		}

		private void lBYaXrtMHWcGYCitHLhnVDQrkBFt()
		{
			HardwareControllerMap_Game asJEgTisjEcLUALQMOtkJoREArlC = ReInput.controllers.Keyboard.asJEgTisjEcLUALQMOtkJoREArlC;
			int totalCount = asJEgTisjEcLUALQMOtkJoREArlC.elementIdentifiers.TotalCount;
			for (int i = 0; i < totalCount; i++)
			{
				if (asJEgTisjEcLUALQMOtkJoREArlC.elementIdentifiers.TryGetValueAt(i, out var value))
				{
					KeyboardKeyCode keyCode = (KeyboardKeyCode)Consts.keyboardKeyValues[value.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid];
					string label = ckPHQbSSihzefKgxPbSYDEEdBfuDA.Get(keyCode).label;
					if (!string.Equals(value.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename, label))
					{
						value.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename = label;
					}
				}
			}
			ckPHQbSSihzefKgxPbSYDEEdBfuDA.GyUDhZinOkoTncKPwFSyKnHfGKdcb = false;
		}
	}
}
