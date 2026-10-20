using System.Collections.Generic;
using UnityEngine;

public class DEN_Apparition : MonoBehaviour
{
	public SpriteRenderer apparitionSprite;

	private Transform apparitionTransform;

	public List<Sprite> randomSprites;

	public float wanderAmount = 2f;

	public float wanderSpeed = 1f;

	private Vector3 startPosition;

	private void OnEnable()
	{
		apparitionSprite.sprite = randomSprites[Random.Range(0, randomSprites.Count)];
		startPosition = base.transform.position;
	}

	private void Update()
	{
		Vector2 vector = new Vector2(Mathf.PerlinNoise(startPosition.y - Time.time * wanderSpeed, startPosition.x - Time.time * wanderSpeed), Mathf.PerlinNoise(startPosition.x + Time.time * wanderSpeed, startPosition.y + Time.time * wanderSpeed));
		vector -= Vector2.one * 0.5f;
		base.transform.position = startPosition + new Vector3(vector.x, 0f, vector.y) * wanderAmount;
	}
}
