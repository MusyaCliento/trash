using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class UI_ScrollController : MonoBehaviour
{
	[Header("Assign your ScrollRect here (or via GetComponent).")]
	[SerializeField]
	private ScrollRect scrollRect;

	[Header("Smooth Scrolling Options")]
	[Tooltip("Enable or disable smooth scrolling (lerping).")]
	public bool useSmoothScrolling;

	[Tooltip("Controls the speed of the smooth scroll (larger = faster).")]
	public float scrollSpeed = 5f;

	private Coroutine scrollCoroutine;

	private void Reset()
	{
		if (scrollRect == null)
		{
			scrollRect = GetComponent<ScrollRect>();
		}
	}

	public void ScrollToNextPage()
	{
		if (!(scrollRect == null))
		{
			if (scrollRect.vertical)
			{
				ScrollNextPageVertical();
			}
			else if (scrollRect.horizontal)
			{
				ScrollNextPageHorizontal();
			}
		}
	}

	public void ScrollToPreviousPage()
	{
		if (!(scrollRect == null))
		{
			if (scrollRect.vertical)
			{
				ScrollPreviousPageVertical();
			}
			else if (scrollRect.horizontal)
			{
				ScrollPreviousPageHorizontal();
			}
		}
	}

	private void ScrollNextPageVertical()
	{
		float height = scrollRect.content.rect.height;
		float num = scrollRect.viewport.rect.height / height;
		float value = scrollRect.verticalNormalizedPosition - num;
		value = Mathf.Clamp01(value);
		ScrollToVerticalPosition(value);
	}

	private void ScrollPreviousPageVertical()
	{
		float height = scrollRect.content.rect.height;
		float num = scrollRect.viewport.rect.height / height;
		float value = scrollRect.verticalNormalizedPosition + num;
		value = Mathf.Clamp01(value);
		ScrollToVerticalPosition(value);
	}

	private void ScrollNextPageHorizontal()
	{
		float width = scrollRect.content.rect.width;
		float num = scrollRect.viewport.rect.width / width;
		float value = scrollRect.horizontalNormalizedPosition + num;
		value = Mathf.Clamp01(value);
		ScrollToHorizontalPosition(value);
	}

	private void ScrollPreviousPageHorizontal()
	{
		float width = scrollRect.content.rect.width;
		float num = scrollRect.viewport.rect.width / width;
		float value = scrollRect.horizontalNormalizedPosition - num;
		value = Mathf.Clamp01(value);
		ScrollToHorizontalPosition(value);
	}

	private void ScrollToVerticalPosition(float targetPosition)
	{
		if (useSmoothScrolling)
		{
			if (scrollCoroutine != null)
			{
				StopCoroutine(scrollCoroutine);
			}
			scrollCoroutine = StartCoroutine(SmoothScrollVertical(targetPosition));
		}
		else
		{
			scrollRect.verticalNormalizedPosition = targetPosition;
		}
	}

	private void ScrollToHorizontalPosition(float targetPosition)
	{
		if (useSmoothScrolling)
		{
			if (scrollCoroutine != null)
			{
				StopCoroutine(scrollCoroutine);
			}
			scrollCoroutine = StartCoroutine(SmoothScrollHorizontal(targetPosition));
		}
		else
		{
			scrollRect.horizontalNormalizedPosition = targetPosition;
		}
	}

	private IEnumerator SmoothScrollVertical(float targetPos)
	{
		_ = scrollRect.verticalNormalizedPosition;
		float elapsed = 0f;
		while (elapsed < 1f)
		{
			elapsed += Time.deltaTime;
			float verticalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targetPos, Time.deltaTime * scrollSpeed);
			scrollRect.verticalNormalizedPosition = verticalNormalizedPosition;
			yield return null;
		}
		scrollRect.verticalNormalizedPosition = targetPos;
		scrollCoroutine = null;
	}

	private IEnumerator SmoothScrollHorizontal(float targetPos)
	{
		_ = scrollRect.horizontalNormalizedPosition;
		float elapsed = 0f;
		while (elapsed < 1f)
		{
			elapsed += Time.deltaTime;
			float horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targetPos, Time.deltaTime * scrollSpeed);
			scrollRect.horizontalNormalizedPosition = horizontalNormalizedPosition;
			yield return null;
		}
		scrollRect.horizontalNormalizedPosition = targetPos;
		scrollCoroutine = null;
	}
}
