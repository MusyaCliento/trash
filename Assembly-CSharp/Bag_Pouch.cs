using DG.Tweening;
using TMPro;
using UnityEngine;

public class Bag_Pouch : MonoBehaviour
{
	public TMP_Text itemCountText;

	public SpriteRenderer pouchSpriteRenderer;

	public void SetItemCount(int count, int max)
	{
		if (count <= 1)
		{
			itemCountText.text = "";
		}
		else
		{
			itemCountText.text = count + "x";
		}
		if (count >= max)
		{
			itemCountText.color = Color.yellow;
		}
		else
		{
			itemCountText.color = Color.white;
		}
	}

	public void AddItem()
	{
		DOTween.Complete(base.transform);
		base.transform.DOPunchScale(Vector3.one * 0.15f, 0.25f, 1);
	}
}
