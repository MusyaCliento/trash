using Drawing;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class UT_SpawnChance : MonoBehaviourGizmos
{
	public bool checkOnStart = true;

	public SpawnTable.SpawnSettings spawnSettings;

	public UnityEvent onSuccess;

	public UnityEvent onFail;

	private void Start()
	{
		if (checkOnStart)
		{
			Check();
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

	public void Check()
	{
		if (!spawnSettings.RandomCheck())
		{
			base.gameObject.SetActive(value: false);
			onFail.Invoke();
		}
		else
		{
			base.gameObject.SetActive(value: true);
			onSuccess.Invoke();
		}
	}
}
