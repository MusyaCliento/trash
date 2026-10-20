using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Shimmer", fileName = "Shimmer Behavior")]
	[EffectInfo("shimmer", EffectCategory.Behaviors)]
	public sealed class ShimmerBehavior : BehaviorScriptableBase
	{
		public float baseFrequency = 0.5f;

		public float baseWaveSize = 0.08f;

		public Color color1;

		public Color color2;

		private float frequency;

		private float waveSize;

		private Color32 temp;

		public override void SetModifier(ModifierInfo modifier)
		{
			string text = modifier.name;
			if (!(text == "f"))
			{
				if (text == "s")
				{
					waveSize = baseWaveSize * modifier.value;
				}
			}
			else
			{
				frequency = baseFrequency * modifier.value;
			}
		}

		public override void ResetContext(TAnimCore animator)
		{
			frequency = baseFrequency;
			waveSize = baseWaveSize;
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			for (byte b = 0; b < 4; b++)
			{
				temp = Color.Lerp(color1 * character.source.colors[0], color2 * character.source.colors[0], Mathf.PingPong(animator.time.timeSinceStart * frequency + (float)character.index * waveSize, 1f));
				character.current.colors[b] = temp;
			}
		}
	}
}
