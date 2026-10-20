using UnityEngine;

public class VolumeTestScene2 : MonoBehaviour
{
	public Transform secondFloor;

	public BakeryVolumeTrigger[] secondFloorVolumes;

	public float secondFloorHeight;

	public bool randomizeLastRoom;

	public Transform baseRoom;

	public Transform alternativeRoom;

	private void SwapRooms()
	{
		Vector3 position = alternativeRoom.position;
		alternativeRoom.position = baseRoom.position;
		baseRoom.position = position;
	}

	private void UpdateRooms()
	{
		for (int i = 0; i < secondFloorVolumes.Length; i++)
		{
			secondFloorVolumes[i].UpdateBounds();
		}
	}

	private void Start()
	{
		if (randomizeLastRoom && Random.Range(0, 2) == 1)
		{
			SwapRooms();
		}
		secondFloor.position += Vector3.up * secondFloorHeight;
		UpdateRooms();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SwapRooms();
			UpdateRooms();
		}
	}
}
