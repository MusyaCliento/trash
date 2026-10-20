using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	public abstract class TouchControl : CustomControllerControl
	{
		private Canvas _canvas;

		private RectTransform __rectTransform;

		internal TouchController HaohWPPRiTDzNSpXuAuUWBEqwrtD => NoIazLsYSTwUBTYAJWqIMTXWTYWh() as TouchController;

		internal Canvas RAMbMCVDZNAfRShilkKJyPAzfaiFA => _canvas;

		internal RectTransform UfmIGZThEbWVxpoddgwxllLrghpl
		{
			get
			{
				Canvas canvas = RAMbMCVDZNAfRShilkKJyPAzfaiFA;
				if (canvas == null)
				{
					return null;
				}
				return canvas.transform as RectTransform;
			}
		}

		internal RectTransform dSTzJICOhDURqXqgBtAzmiWIpcKb => __rectTransform ?? (__rectTransform = GetComponent<RectTransform>());

		bool CustomControllerControl.EtAcLDGWDFPgJjzEWQEywAqMgoOdb => NoIazLsYSTwUBTYAJWqIMTXWTYWh() as TouchController != null;

		[CustomObfuscation(rename = false)]
		internal TouchControl()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				DgeBdFERAGwOyOPVtJidlvTSXORB(true, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				DgeBdFERAGwOyOPVtJidlvTSXORB(false, true);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				DgeBdFERAGwOyOPVtJidlvTSXORB(false, true);
			}
		}

		internal virtual bool PuElCCKuVaOGHYLUTJDmtdWXnchF()
		{
			if (!base.FvfXOolhJLGULEPtTKRTbjTgMlRSb())
			{
				return false;
			}
			if (!DgeBdFERAGwOyOPVtJidlvTSXORB(true, true))
			{
				return false;
			}
			return true;
		}

		internal virtual void RzdFNDtNUhBIEdpFosYAhZGefaRLb()
		{
			base.pUykrpNetTUYuDBqRmvvBYWqWEhe();
			if (base.VuxFOLCyORNjXPqrjNuQvkTlJuirA)
			{
				DgeBdFERAGwOyOPVtJidlvTSXORB(true, true);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override IComponentController FindController()
		{
			return UnityTools.GetComponentInSelfOrParents<CustomController>(base.transform);
		}

		[CustomObfuscation(rename = false)]
		internal override Type GetRequiredControllerType()
		{
			return typeof(TouchController);
		}

		private bool DgeBdFERAGwOyOPVtJidlvTSXORB(bool P_0, bool P_1)
		{
			_canvas = UnityTools.GetComponentInSelfOrParents<Canvas>(base.gameObject);
			if (_canvas == null)
			{
				if (P_0)
				{
					Logger.LogError("No Canvas was found. Touch controls must be a child of a Canvas.");
				}
				return false;
			}
			if (_canvas.renderMode == RenderMode.WorldSpace)
			{
				if (P_1)
				{
					Logger.LogError("Touch controls cannot be used with a world space Canvas. Change the canvas render mode to screen space.");
				}
				return false;
			}
			return true;
		}
	}
}
