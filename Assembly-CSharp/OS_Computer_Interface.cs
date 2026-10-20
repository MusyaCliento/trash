using System;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class OS_Computer_Interface : MonoBehaviour, SaveableObject, Seedable
{
	public class SystemData
	{
		public bool leverPulled;

		public bool floppyInserted;
	}

	public OS_Manager managerPrefab;

	private OS_Manager os;

	public OS_DiskData desktopData;

	public UT_CameraTakeover screenTakeover;

	public Transform[] handPositions;

	public SystemData systemData = new SystemData();

	public Transform playerPosition;

	public CL_ToggleButton lever;

	public string computerID;

	public string facilityID;

	private AudioSource aud;

	private float pitchTarget;

	private float volume;

	private UT_EventController eventController;

	public float handScale = 0.8f;

	private int seed = -1;

	private void Start()
	{
		os = UnityEngine.Object.Instantiate(managerPrefab, null);
		os.cameraControl = screenTakeover;
		systemData.leverPulled = false;
		os.worldInterface = this;
		Debug.Log(os.worldInterface);
		os.gameObject.SetActive(value: false);
		aud = GetComponent<AudioSource>();
		volume = aud.volume;
		eventController = GetComponent<UT_EventController>();
		if (computerID != "")
		{
			CL_GameManager.SessionFlag gameFlag = CL_GameManager.GetGameFlag("recieved-" + computerID + "-perk");
			if (gameFlag != null && gameFlag.state)
			{
				eventController.PlayEvent("injector-plunge");
			}
		}
	}

	private void OnDisable()
	{
		if (os != null)
		{
			os.gameObject.SetActive(value: false);
		}
	}

	private void OnEnable()
	{
		_ = os != null;
	}

	private void OnDestroy()
	{
		if (os != null)
		{
			UnityEngine.Object.Destroy(os.gameObject);
		}
	}

	public void ActivateComputer()
	{
		if (!CL_GameManager.IsLoading() && !CL_GameManager.gMan.IsReviving() && (!(OS_Manager.activeComputer != null) || !OS_Manager.activeComputer.IsInUse()) && ENT_Player.playerObject.CanStashItemsInHand())
		{
			ENT_Player.playerObject.StashItemsInHand();
			ENT_Player.GetPlayer().DropHang();
			os.gameObject.SetActive(value: true);
			os.Activate();
			aud.Play();
			pitchTarget = 1f;
		}
	}

	public void DeactivateComputer()
	{
		pitchTarget = 0.8f;
		os.Deactivate();
	}

	private void Update()
	{
		if (aud != null)
		{
			aud.pitch = Mathf.Lerp(aud.pitch, pitchTarget, Time.deltaTime);
			aud.volume = Mathf.Lerp(aud.volume, pitchTarget * volume, Time.deltaTime);
		}
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Label2D(base.transform.position, "Computer Seed: " + seed, 8f, LabelAlignment.Center, Color.white);
		}
	}

	public void SetLeverState(bool b)
	{
		systemData.leverPulled = b;
	}

	public OS_Manager GetComputer()
	{
		return os;
	}

	public UT_EventController GetEventController()
	{
		return eventController;
	}

	public SaveableInfo GetSaveInfo()
	{
		new SaveableInfo();
		throw new NotImplementedException();
	}

	public void SetSaveInfo(SaveableInfo info, List<string> flags)
	{
		throw new NotImplementedException();
	}

	public void SetSeed(int s)
	{
		seed = s;
	}

	public int GetSeed()
	{
		return seed;
	}
}
