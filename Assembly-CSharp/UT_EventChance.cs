using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_EventChance : MonoBehaviourGizmos
{
	public SpawnTable.SpawnSettings spawnSettings;

	public UnityEvent successEvent;

	public UnityEvent failEvent;

	public bool onStart = true;

	public bool onEnable;

	private void Start()
	{
		if (onStart)
		{
			Check();
		}
	}

	private void OnEnable()
	{
		if (onEnable)
		{
			Check();
		}
	}

	public void Check()
	{
		if (spawnSettings.RandomCheck())
		{
			successEvent.Invoke();
		}
		else
		{
			failEvent.Invoke();
		}
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this) || DebugCore.showSpawnChances)
		{
			bool num = GetComponent<Item_Object>();
			Color color = Color.green;
			if (!num)
			{
				ColorUtility.TryParseHtmlString("#87a132", out color);
			}
			Draw.Label2D(base.transform.position + -Camera.current.transform.up * 0.5f, $"{spawnSettings.spawnChance * 100f}%", 16f, LabelAlignment.TopCenter, color);
		}
	}
}
