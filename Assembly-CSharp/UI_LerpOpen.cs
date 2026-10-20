using DG.Tweening;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UI_LerpOpen : MonoBehaviourGizmos
{
	private Vector3 targetSize;

	private Vector3 targetPosition;

	public Vector3 startPosition = Vector3.zero;

	public Vector3 startScale = Vector3.zero;

	private Vector3 rootPositon = Vector3.zero;

	private Vector3 rootScale = Vector3.zero;

	public float positionLerpTime = 1f;

	public float scaleLerpTime = 1f;

	public float fadeInLerpTime = 0.5f;

	public float fadeOutLerpTime = 0.5f;

	private CanvasGroup group;

	public bool startHidden;

	public bool affectScale = true;

	public bool affectPosition = true;

	public bool hideOpposite;

	public Ease easeIn = Ease.Linear;

	public Ease easeOut = Ease.Linear;

	public float easeInAmplitude = 1f;

	public float easeOutAmplitude = 1f;

	private bool state;

	private bool isHidden;

	public bool fadeInCanvasGroup;

	public UnityEvent eventOnShow;

	public UnityEvent eventOnHide;

	private void Awake()
	{
		isHidden = startHidden;
		targetSize = base.transform.localScale;
		targetPosition = base.transform.localPosition;
		group = GetComponent<CanvasGroup>();
		rootPositon = base.transform.localPosition;
		rootScale = base.transform.localScale;
		if (startHidden)
		{
			if (group != null)
			{
				group.interactable = false;
				if (fadeInCanvasGroup)
				{
					group.alpha = 0f;
					group.blocksRaycasts = false;
				}
			}
			if (affectScale)
			{
				base.transform.localScale = startScale;
			}
			if (affectPosition)
			{
				base.transform.localPosition = targetPosition + startPosition;
			}
			state = false;
		}
		else
		{
			state = true;
		}
	}

	private void OnEnable()
	{
		if (startHidden && isHidden)
		{
			if (group != null)
			{
				group.interactable = false;
			}
			if (affectScale)
			{
				base.transform.localScale = startScale;
			}
			if (affectPosition)
			{
				base.transform.localPosition = targetPosition + startPosition;
			}
		}
		else
		{
			Show();
		}
	}

	private void OnDisable()
	{
		if (startHidden)
		{
			state = false;
		}
		DOTween.Complete(base.transform);
		if (state)
		{
			if (affectScale)
			{
				base.transform.localScale = targetSize;
			}
			isHidden = false;
		}
		else if (affectScale)
		{
			base.transform.localScale = startScale;
		}
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.Cross(base.transform.parent.TransformPoint(base.transform.localPosition + startPosition), 20f, new Color(1f, 0.561f, 0f, 0.25f));
		}
	}

	public void Hide()
	{
		if (!state)
		{
			return;
		}
		isHidden = true;
		state = false;
		DOTween.Complete(base.transform);
		if (affectScale)
		{
			base.transform.localScale = targetSize;
		}
		if (affectPosition)
		{
			base.transform.localPosition = targetPosition;
		}
		if (affectScale)
		{
			base.transform.DOScale(startScale, scaleLerpTime).SetUpdate(isIndependentUpdate: true);
		}
		if (affectPosition)
		{
			if (!hideOpposite)
			{
				base.transform.DOLocalMove(targetPosition + startPosition, positionLerpTime).SetUpdate(isIndependentUpdate: true).SetEase(easeOut, easeOutAmplitude, 0f);
			}
			else
			{
				base.transform.DOLocalMove(targetPosition - startPosition, positionLerpTime).SetUpdate(isIndependentUpdate: true).SetEase(easeOut, easeOutAmplitude, 0f);
			}
		}
		if (group != null)
		{
			group.interactable = false;
			DOTween.Complete(group);
			group.blocksRaycasts = false;
			if (fadeInCanvasGroup)
			{
				group.DOFade(0f, fadeOutLerpTime).SetUpdate(isIndependentUpdate: true);
			}
		}
		eventOnHide.Invoke();
	}

	public void Show()
	{
		if (state)
		{
			return;
		}
		isHidden = false;
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
		}
		state = true;
		DOTween.Complete(base.transform);
		if (affectScale)
		{
			base.transform.localScale = startScale;
		}
		if (affectPosition)
		{
			base.transform.localPosition = targetPosition + startPosition;
		}
		if (affectScale)
		{
			base.transform.DOScale(targetSize, scaleLerpTime).SetUpdate(isIndependentUpdate: true).SetEase(easeIn);
		}
		if (affectPosition)
		{
			base.transform.DOLocalMove(targetPosition, positionLerpTime).SetUpdate(isIndependentUpdate: true).SetEase(easeIn, easeInAmplitude, 0f);
		}
		if (group != null)
		{
			DOTween.Complete(group);
			group.interactable = true;
			group.blocksRaycasts = true;
			if (fadeInCanvasGroup)
			{
				group.DOFade(1f, fadeInLerpTime).SetUpdate(isIndependentUpdate: true);
			}
		}
		eventOnShow.Invoke();
	}
}
