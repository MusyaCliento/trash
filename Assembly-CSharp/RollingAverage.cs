using System;
using UnityEngine;

[Serializable]
public class RollingAverage
{
	public float addMin = 1f;

	public float addMax = 1f;

	[Tooltip("Higher values lead to a more gradular/slow flicker, lower values lead to more extreme flicker")]
	public int bufferSize = 128;

	private static readonly AnimationCurve linearSingleton = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public AnimationCurve outputCurve = linearSingleton;

	private float[] ringBuffer;

	private int ringBufferIndex;

	private float ringBufferSum;

	private void Init()
	{
		if (bufferSize > 0)
		{
			ringBuffer = new float[bufferSize];
			ringBufferIndex = 0;
			ringBufferSum = 0f;
			for (int i = 0; i < bufferSize; i++)
			{
				float num = UnityEngine.Random.Range(addMin, addMax);
				ringBuffer[i] = num;
				ringBufferSum += num;
			}
		}
	}

	public float GetNext()
	{
		float time = 1f;
		if (ringBuffer == null || bufferSize != ringBuffer.Length)
		{
			Init();
		}
		if (bufferSize > 0)
		{
			float num = UnityEngine.Random.Range(addMin, addMax);
			ringBufferSum += num - ringBuffer[ringBufferIndex];
			ringBuffer[ringBufferIndex] = num;
			ringBufferIndex++;
			if (ringBufferIndex >= bufferSize)
			{
				ringBufferIndex = 0;
			}
			time = ringBufferSum / (float)bufferSize;
		}
		return outputCurve.Evaluate(time);
	}
}
