using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DarkMachine.UI
{
	[AddComponentMenu("UI/Submit Slider", 34)]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	public class SubmitSlider : Selectable, IDragHandler, IEventSystemHandler, IInitializePotentialDragHandler, ICanvasElement, ISubmitHandler
	{
		public enum Direction
		{
			LeftToRight = 0,
			RightToLeft = 1,
			BottomToTop = 2,
			TopToBottom = 3
		}

		[Serializable]
		public class SliderEvent : UnityEvent<float>
		{
		}

		private enum Axis
		{
			Horizontal = 0,
			Vertical = 1
		}

		[SerializeField]
		private RectTransform m_FillRect;

		[SerializeField]
		private RectTransform m_HandleRect;

		[Space]
		[SerializeField]
		private Direction m_Direction;

		[SerializeField]
		private float m_MinValue;

		[SerializeField]
		private float m_MaxValue = 1f;

		[SerializeField]
		private bool m_WholeNumbers;

		[SerializeField]
		protected float m_Value;

		[Space]
		[SerializeField]
		private SliderEvent m_OnValueChanged = new SliderEvent();

		private Image m_FillImage;

		private Transform m_FillTransform;

		private RectTransform m_FillContainerRect;

		private Transform m_HandleTransform;

		private RectTransform m_HandleContainerRect;

		public Outline backgroundOutline;

		private Vector2 m_Offset = Vector2.zero;

		private DrivenRectTransformTracker m_Tracker;

		private bool m_DelayedUpdateVisuals;

		public float stepAmount = 0.1f;

		public bool submitToPrime;

		private bool primed;

		public bool unityEventOnFinish;

		private bool isDragging;

		public float primedScale = 1.5f;

		public UnityEvent<float> onFinishChange;

		public RectTransform fillRect
		{
			get
			{
				return m_FillRect;
			}
			set
			{
				if (SetPropertyUtility.SetClass(ref m_FillRect, value))
				{
					UpdateCachedReferences();
					UpdateVisuals();
				}
			}
		}

		public RectTransform handleRect
		{
			get
			{
				return m_HandleRect;
			}
			set
			{
				if (SetPropertyUtility.SetClass(ref m_HandleRect, value))
				{
					UpdateCachedReferences();
					UpdateVisuals();
				}
			}
		}

		public Direction direction
		{
			get
			{
				return m_Direction;
			}
			set
			{
				if (SetPropertyUtility.SetStruct(ref m_Direction, value))
				{
					UpdateVisuals();
				}
			}
		}

		public float minValue
		{
			get
			{
				return m_MinValue;
			}
			set
			{
				if (SetPropertyUtility.SetStruct(ref m_MinValue, value))
				{
					Set(m_Value);
					UpdateVisuals();
				}
			}
		}

		public float maxValue
		{
			get
			{
				return m_MaxValue;
			}
			set
			{
				if (SetPropertyUtility.SetStruct(ref m_MaxValue, value))
				{
					Set(m_Value);
					UpdateVisuals();
				}
			}
		}

		public bool wholeNumbers
		{
			get
			{
				return m_WholeNumbers;
			}
			set
			{
				if (SetPropertyUtility.SetStruct(ref m_WholeNumbers, value))
				{
					Set(m_Value);
					UpdateVisuals();
				}
			}
		}

		public virtual float value
		{
			get
			{
				if (!wholeNumbers)
				{
					return m_Value;
				}
				return Mathf.Round(m_Value);
			}
			set
			{
				Set(value);
			}
		}

		public float normalizedValue
		{
			get
			{
				if (Mathf.Approximately(minValue, maxValue))
				{
					return 0f;
				}
				return Mathf.InverseLerp(minValue, maxValue, value);
			}
			set
			{
				this.value = Mathf.Lerp(minValue, maxValue, value);
			}
		}

		public SliderEvent onValueChanged
		{
			get
			{
				return m_OnValueChanged;
			}
			set
			{
				m_OnValueChanged = value;
			}
		}

		private float stepSize
		{
			get
			{
				if (!wholeNumbers)
				{
					return stepAmount;
				}
				return 1f;
			}
		}

		private Axis axis
		{
			get
			{
				if (m_Direction != Direction.LeftToRight && m_Direction != Direction.RightToLeft)
				{
					return Axis.Vertical;
				}
				return Axis.Horizontal;
			}
		}

		private bool reverseValue
		{
			get
			{
				if (m_Direction != Direction.RightToLeft)
				{
					return m_Direction == Direction.TopToBottom;
				}
				return true;
			}
		}

		Transform ICanvasElement.transform => base.transform;

		public virtual void SetValueWithoutNotify(float input)
		{
			Set(input, sendCallback: false);
		}

		protected SubmitSlider()
		{
		}

		public virtual void Rebuild(CanvasUpdate executing)
		{
			if (executing == CanvasUpdate.Prelayout)
			{
				onValueChanged.Invoke(value);
			}
		}

		public virtual void LayoutComplete()
		{
		}

		public virtual void GraphicUpdateComplete()
		{
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			UpdateCachedReferences();
			Set(m_Value, sendCallback: false);
			UpdateVisuals();
		}

		protected override void OnDisable()
		{
			m_Tracker.Clear();
			base.OnDisable();
		}

		protected virtual void Update()
		{
			if (m_DelayedUpdateVisuals)
			{
				m_DelayedUpdateVisuals = false;
				Set(m_Value, sendCallback: false);
				UpdateVisuals();
			}
			if (!submitToPrime)
			{
				return;
			}
			if (primed)
			{
				if (backgroundOutline != null)
				{
					backgroundOutline.effectColor = Color.Lerp(backgroundOutline.effectColor, Color.white, Time.unscaledDeltaTime * 4f);
				}
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.one * 1.1f, Time.unscaledDeltaTime * 8f);
			}
			else
			{
				if (backgroundOutline != null)
				{
					backgroundOutline.effectColor = Color.Lerp(backgroundOutline.effectColor, Color.clear, Time.unscaledDeltaTime * 4f);
				}
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.one, Time.unscaledDeltaTime * 8f);
			}
		}

		protected override void OnDidApplyAnimationProperties()
		{
			m_Value = ClampValue(m_Value);
			float num = normalizedValue;
			if (m_FillContainerRect != null)
			{
				num = ((m_FillImage != null && m_FillImage.type == Image.Type.Filled) ? m_FillImage.fillAmount : (reverseValue ? (1f - m_FillRect.anchorMin[(int)axis]) : m_FillRect.anchorMax[(int)axis]));
			}
			else if (m_HandleContainerRect != null)
			{
				num = (reverseValue ? (1f - m_HandleRect.anchorMin[(int)axis]) : m_HandleRect.anchorMin[(int)axis]);
			}
			UpdateVisuals();
			if (num != normalizedValue)
			{
				UISystemProfilerApi.AddMarker("Slider.value", this);
				onValueChanged.Invoke(m_Value);
			}
			base.OnDidApplyAnimationProperties();
		}

		private void UpdateCachedReferences()
		{
			if ((bool)m_FillRect && m_FillRect != (RectTransform)base.transform)
			{
				m_FillTransform = m_FillRect.transform;
				m_FillImage = m_FillRect.GetComponent<Image>();
				if (m_FillTransform.parent != null)
				{
					m_FillContainerRect = m_FillTransform.parent.GetComponent<RectTransform>();
				}
			}
			else
			{
				m_FillRect = null;
				m_FillContainerRect = null;
				m_FillImage = null;
			}
			if ((bool)m_HandleRect && m_HandleRect != (RectTransform)base.transform)
			{
				m_HandleTransform = m_HandleRect.transform;
				if (m_HandleTransform.parent != null)
				{
					m_HandleContainerRect = m_HandleTransform.parent.GetComponent<RectTransform>();
				}
			}
			else
			{
				m_HandleRect = null;
				m_HandleContainerRect = null;
			}
		}

		private float ClampValue(float input)
		{
			float num = Mathf.Clamp(input, minValue, maxValue);
			if (wholeNumbers)
			{
				num = Mathf.Round(num);
			}
			return num;
		}

		protected virtual void Set(float input, bool sendCallback = true)
		{
			float num = ClampValue(input);
			if (m_Value == num)
			{
				return;
			}
			m_Value = num;
			UpdateVisuals();
			if (sendCallback)
			{
				UISystemProfilerApi.AddMarker("Slider.value", this);
				m_OnValueChanged.Invoke(num);
				if (!isDragging)
				{
					onFinishChange.Invoke(num);
				}
			}
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			if (IsActive())
			{
				UpdateVisuals();
			}
		}

		private void UpdateVisuals()
		{
			if (!Application.isPlaying)
			{
				UpdateCachedReferences();
			}
			m_Tracker.Clear();
			if (m_FillContainerRect != null)
			{
				m_Tracker.Add(this, m_FillRect, DrivenTransformProperties.Anchors);
				Vector2 zero = Vector2.zero;
				Vector2 one = Vector2.one;
				if (m_FillImage != null && m_FillImage.type == Image.Type.Filled)
				{
					m_FillImage.fillAmount = normalizedValue;
				}
				else if (reverseValue)
				{
					zero[(int)axis] = 1f - normalizedValue;
				}
				else
				{
					one[(int)axis] = normalizedValue;
				}
				m_FillRect.anchorMin = zero;
				m_FillRect.anchorMax = one;
			}
			if (m_HandleContainerRect != null)
			{
				m_Tracker.Add(this, m_HandleRect, DrivenTransformProperties.Anchors);
				Vector2 zero2 = Vector2.zero;
				Vector2 one2 = Vector2.one;
				Axis index = axis;
				float num = (one2[(int)axis] = (reverseValue ? (1f - normalizedValue) : normalizedValue));
				float num3 = num;
				zero2[(int)index] = num3;
				m_HandleRect.anchorMin = zero2;
				m_HandleRect.anchorMax = one2;
			}
		}

		private void UpdateDrag(PointerEventData eventData, Camera cam)
		{
			RectTransform rectTransform = m_HandleContainerRect ?? m_FillContainerRect;
			if (rectTransform != null && rectTransform.rect.size[(int)axis] > 0f)
			{
				Vector2 position = Vector2.zero;
				if (MultipleDisplayUtilities.GetRelativeMousePositionForDrag(eventData, ref position) && RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, position, cam, out var localPoint))
				{
					localPoint -= rectTransform.rect.position;
					float num = Mathf.Clamp01((localPoint - m_Offset)[(int)axis] / rectTransform.rect.size[(int)axis]);
					normalizedValue = (reverseValue ? (1f - num) : num);
				}
			}
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			primed = false;
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			primed = false;
		}

		public void OnSubmit(BaseEventData eventData)
		{
			primed = !primed;
		}

		private bool MayDrag(PointerEventData eventData)
		{
			if (IsActive() && IsInteractable())
			{
				return eventData.button == PointerEventData.InputButton.Left;
			}
			return false;
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			if (!MayDrag(eventData))
			{
				return;
			}
			isDragging = true;
			base.OnPointerDown(eventData);
			m_Offset = Vector2.zero;
			if (m_HandleContainerRect != null && RectTransformUtility.RectangleContainsScreenPoint(m_HandleRect, eventData.pointerPressRaycast.screenPosition, eventData.enterEventCamera))
			{
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(m_HandleRect, eventData.pointerPressRaycast.screenPosition, eventData.pressEventCamera, out var localPoint))
				{
					m_Offset = localPoint;
				}
			}
			else
			{
				UpdateDrag(eventData, eventData.pressEventCamera);
			}
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			isDragging = false;
			onFinishChange.Invoke(value);
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
			if (MayDrag(eventData))
			{
				isDragging = true;
				UpdateDrag(eventData, eventData.pressEventCamera);
			}
		}

		public override void OnMove(AxisEventData eventData)
		{
			if (!IsActive() || !IsInteractable())
			{
				base.OnMove(eventData);
				return;
			}
			bool flag = true;
			if (!primed && submitToPrime)
			{
				flag = false;
			}
			switch (eventData.moveDir)
			{
			case MoveDirection.Left:
				if (axis == Axis.Horizontal && FindSelectableOnLeft() == null && flag)
				{
					Set(reverseValue ? (value + stepSize) : (value - stepSize));
				}
				else
				{
					base.OnMove(eventData);
				}
				break;
			case MoveDirection.Right:
				if (axis == Axis.Horizontal && FindSelectableOnRight() == null && flag)
				{
					Set(reverseValue ? (value - stepSize) : (value + stepSize));
				}
				else
				{
					base.OnMove(eventData);
				}
				break;
			case MoveDirection.Up:
				if (axis == Axis.Vertical && FindSelectableOnUp() == null && flag)
				{
					Set(reverseValue ? (value - stepSize) : (value + stepSize));
				}
				else
				{
					base.OnMove(eventData);
				}
				break;
			case MoveDirection.Down:
				if (axis == Axis.Vertical && FindSelectableOnDown() == null && flag)
				{
					Set(reverseValue ? (value + stepSize) : (value - stepSize));
				}
				else
				{
					base.OnMove(eventData);
				}
				break;
			}
		}

		public override Selectable FindSelectableOnLeft()
		{
			if (base.navigation.mode == Navigation.Mode.Explicit && primed)
			{
				return null;
			}
			if (base.navigation.mode == Navigation.Mode.Automatic && axis == Axis.Horizontal && primed)
			{
				return null;
			}
			return base.FindSelectableOnLeft();
		}

		public override Selectable FindSelectableOnRight()
		{
			if (base.navigation.mode == Navigation.Mode.Explicit && primed)
			{
				return null;
			}
			if (base.navigation.mode == Navigation.Mode.Automatic && axis == Axis.Horizontal && primed)
			{
				return null;
			}
			return base.FindSelectableOnRight();
		}

		public override Selectable FindSelectableOnUp()
		{
			if (base.navigation.mode == Navigation.Mode.Explicit && primed)
			{
				return null;
			}
			if (base.navigation.mode == Navigation.Mode.Automatic && axis == Axis.Vertical && primed)
			{
				return null;
			}
			return base.FindSelectableOnUp();
		}

		public override Selectable FindSelectableOnDown()
		{
			if (base.navigation.mode == Navigation.Mode.Explicit && primed)
			{
				return null;
			}
			if (base.navigation.mode == Navigation.Mode.Automatic && axis == Axis.Vertical && primed)
			{
				return null;
			}
			return base.FindSelectableOnDown();
		}

		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
		}

		public void SetDirection(Direction direction, bool includeRectLayouts)
		{
			Axis axis = this.axis;
			bool flag = reverseValue;
			this.direction = direction;
			if (includeRectLayouts)
			{
				if (this.axis != axis)
				{
					RectTransformUtility.FlipLayoutAxes(base.transform as RectTransform, keepPositioning: true, recursive: true);
				}
				if (reverseValue != flag)
				{
					RectTransformUtility.FlipLayoutOnAxis(base.transform as RectTransform, (int)this.axis, keepPositioning: true, recursive: true);
				}
			}
		}
	}
}
