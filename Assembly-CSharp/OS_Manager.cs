using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class OS_Manager : MonoBehaviour
{
	public class DiskController
	{
		private OS_Manager os;

		public bool newDiskLoaded;

		public List<Item> disks;

		private List<Item> loadedDisks = new List<Item>();

		private List<OS_File> diskFolders = new List<OS_File>();

		private bool isLoadingDisks;

		public void Initialize(OS_Manager o)
		{
			os = o;
			disks = new List<Item>();
			loadedDisks = new List<Item>();
		}

		public void LoadDisk(Item floppy)
		{
			disks.Add(floppy);
			newDiskLoaded = true;
			if (os.canControl)
			{
				os.StartCoroutine(DiskLoadSequence());
			}
		}

		public List<Item> GetDisks()
		{
			return loadedDisks;
		}

		public IEnumerator DiskLoadSequence()
		{
			if (!isLoadingDisks)
			{
				isLoadingDisks = true;
				os.SetInteractable(b: false);
				yield return new WaitForSeconds(0.5f);
				newDiskLoaded = false;
				Message_Manager.Message_Packet message_Packet = new Message_Manager.Message_Packet();
				message_Packet.type = "loading";
				message_Packet.closeText = "OK";
				message_Packet.message = "New disk detected. Loading..";
				message_Packet.screenPos = new Vector2(0f, 0f);
				message_Packet.data = new List<string> { "1" };
				Message message = os.messageManager.CreateMessage(message_Packet);
				soundPlayer.PlaySound("os:floppy-load");
				while (message != null)
				{
					yield return null;
				}
				os.SetInteractable(b: true);
				message_Packet = new Message_Manager.Message_Packet();
				message_Packet.type = "default";
				message_Packet.closeText = "OK";
				message_Packet.message = "Disk mounted on desktop.";
				message_Packet.screenPos = new Vector2(0f, 0f);
				os.messageManager.CreateMessage(message_Packet);
				isLoadingDisks = false;
				CreateDiskContents();
			}
		}

		private void CreateDiskContents()
		{
			for (int i = 0; i < disks.Count; i++)
			{
				Item item = disks[i];
				if (loadedDisks.Contains(item))
				{
					continue;
				}
				loadedDisks.Add(item);
				Vector2 pos = new Vector2
				{
					x = -60f,
					y = 0f - Mathf.Repeat(50 * (i + 2), 300f)
				};
				OS_File oS_File = null;
				if (item.data[0].Contains("diskdat:"))
				{
					OS_DiskData oS_DiskData = Object.Instantiate(CL_AssetManager.GetDiskDataAsset(item.data[0].Split(':')[1]));
					oS_DiskData.Initialize();
					oS_File = os.filesystem.desktop.NewFolder(pos, oS_DiskData.GetDiskName(), os.filesystem.GetIcon("disk"), createAtWorldPosition: false);
					oS_File.fileInfo.children = new List<OS_Filesystem.FileInfo>();
					oS_File.fileInfo.children.AddRange(oS_DiskData.GetFiles());
				}
				if (item.data[0].Contains("name:"))
				{
					string text = "Disk " + i;
					text = item.data[0].Split(':')[1];
					oS_File = os.filesystem.desktop.NewFolder(pos, text, os.filesystem.GetIcon("disk"), createAtWorldPosition: false);
					if (oS_File.fileInfo.children == null)
					{
						oS_File.fileInfo.children = new List<OS_Filesystem.FileInfo>();
					}
					int num = 0;
					foreach (string datum in item.data)
					{
						if (datum.Contains(":"))
						{
							string[] array = datum.Split(":");
							if (array[0] == "file")
							{
								num++;
								string name = array[1];
								string name2 = array[2];
								string data = array[3];
								OS_Filesystem.FileInfo defaultFiletype = os.GetFilesystem().GetDefaultFiletype(name);
								defaultFiletype.name = name2;
								defaultFiletype.data = data;
								defaultFiletype.position = new Vector2
								{
									x = 0f - Mathf.Repeat(70 * num, 300f),
									y = -25f
								};
								oS_File.fileInfo.children.Add(defaultFiletype);
							}
						}
					}
				}
				diskFolders.Add(oS_File);
			}
		}

		internal void WipeDisks()
		{
			Debug.Log(diskFolders.Count);
			for (int num = diskFolders.Count - 1; num >= 0; num--)
			{
				if (diskFolders[num] != null)
				{
					Debug.Log("Removing this/Test");
					diskFolders[num].CloseFileRecursive();
					diskFolders[num].DeleteFile();
				}
			}
			diskFolders.Clear();
			loadedDisks.Clear();
			disks.Clear();
		}
	}

	public enum cursorType
	{
		pointer = 0,
		finger = 1,
		hand = 2,
		magnifyingGlass = 3,
		crosshairs = 4
	}

	public class Application
	{
		public string id;

		public OS_Window app;
	}

	public static bool inUse;

	public static OS_Manager activeComputer;

	public UnityEvent activateEvent;

	private DiskController diskController;

	public Message_Manager messageManager;

	public OS_ResourceManager resources;

	public Transform appParent;

	public GameObject customInputModule;

	public GameObject osRoot;

	public Canvas canvas;

	private EventSystem computerEventSystem;

	public Selectable exitButton;

	public CanvasGroup computerGroup;

	public Image desktopBackground;

	private OS_Filesystem filesystem;

	public UT_AudioClipHandler audioClipHandler;

	public static UT_AudioClipHandler soundPlayer;

	public RenderTexture renderTexture;

	public OS_Pointer cursor;

	public CursorMode cursorMode = CursorMode.ForceSoftware;

	public Sprite cursorTexture;

	public Sprite crosshairTexture;

	public Sprite handTexture;

	public Sprite fingerTexture;

	public Sprite magnifyingGlasstexture;

	public float cursorFixDivisor = 2f;

	public static Vector2 mousePosition;

	public static Vector2 mouseRealPosition;

	private Vector2 lastMousePosition;

	public static bool mouseEnabled;

	private Dictionary<string, Application> appDict;

	public bool canControl;

	public List<Application> apps;

	public UT_CameraTakeover cameraControl;

	public OS_Computer_Interface worldInterface;

	private bool hasInitialized;

	private void OnEnable()
	{
		soundPlayer = audioClipHandler;
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
		if (activeComputer == this)
		{
			activeComputer = null;
		}
	}

	private void Awake()
	{
		cursor.Initialize(this);
		diskController = new DiskController();
		diskController.Initialize(this);
		SetCursorImage(cursorType.pointer);
		apps = new List<Application>();
		appDict = new Dictionary<string, Application>();
		filesystem = GetComponent<OS_Filesystem>();
		osRoot.SetActive(value: false);
		computerEventSystem = customInputModule.GetComponent<EventSystem>();
		if (worldInterface != null && worldInterface.desktopData != null && worldInterface.desktopData.isComputerDesktop && desktopBackground != null && worldInterface.desktopData.desktopBackground != null)
		{
			desktopBackground.sprite = worldInterface.desktopData.desktopBackground;
		}
	}

	private void Update()
	{
		if (!hasInitialized || !inUse || !canControl)
		{
			return;
		}
		SetDesktopInteractable();
		CheckAppSelectability();
		Cursor.visible = false;
		if (InputManager.IsGamepad())
		{
			mousePosition = cursor.GetImage().rectTransform.anchoredPosition;
			Vector3 vector = new Vector3(Mathf.Sin(Time.unscaledTime), Mathf.Cos(Time.unscaledTime * 1.23f), 0f);
			if (mouseEnabled && computerEventSystem.currentSelectedGameObject != null)
			{
				cursor.transform.position = Vector3.Lerp(cursor.transform.position, computerEventSystem.currentSelectedGameObject.transform.position + vector * 5f, Time.deltaTime * 10f);
			}
			lastMousePosition = mousePosition;
			mouseRealPosition = cursor.transform.position;
		}
		else
		{
			mousePosition = cursor.GetImage().rectTransform.anchoredPosition;
			if (mouseEnabled)
			{
				cursor.transform.position += new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * 5f;
			}
			lastMousePosition = mousePosition;
			mouseRealPosition = cursor.transform.position;
		}
		if (canControl)
		{
			for (int i = 0; i < ENT_Player.playerObject.hands.Length; i++)
			{
				ENT_Player.playerObject.hands[i].MoveTo(worldInterface.handPositions[i].position);
				ENT_Player.playerObject.hands[i].SmoothHandScale(worldInterface.handScale);
				ENT_Player.playerObject.hands[i].SetSprite(ENT_Player.playerObject.hands[i].GetPoseSprite("grab"));
			}
		}
	}

	public OS_Window CreateAppWindow(OS_Window appAsset, string id)
	{
		if (!appDict.ContainsKey(id))
		{
			OS_Window component = Object.Instantiate(appAsset, appParent.position, Quaternion.identity, appParent).GetComponent<OS_Window>();
			component.Initialize(this);
			Application application = new Application();
			application.id = id;
			application.app = component;
			apps.Add(application);
			appDict.Add(id, application);
			component.SetID(id);
			return component;
		}
		return appDict[id].app;
	}

	public void CloseAppWindow(OS_Window app, string id)
	{
		app.gameObject.SetActive(value: false);
	}

	public Vector2 GetScreenSize()
	{
		return canvas.GetComponent<RectTransform>().sizeDelta;
	}

	public void QuitAppWindow(OS_Window app, string id)
	{
		if (appDict.ContainsKey(id))
		{
			apps.Remove(appDict[id]);
			appDict.Remove(id);
		}
		Object.Destroy(app.gameObject);
	}

	public void SetDesktopInteractable()
	{
		bool flag = false;
		bool flag2 = false;
		if (messageManager.showingMessage)
		{
			flag = true;
		}
		if (apps.Count > 0)
		{
			foreach (Application app in apps)
			{
				if (app.app.gameObject.activeInHierarchy)
				{
					if (InputManager.IsGamepad())
					{
						flag = true;
					}
					flag2 = true;
					break;
				}
			}
		}
		if (exitButton != null)
		{
			exitButton.interactable = !flag;
			exitButton.GetComponent<UI_CloseButtonOnBack>().enabled = !flag2;
		}
		filesystem.desktop.GetComponent<CanvasGroup>().interactable = !flag;
	}

	private void CheckAppSelectability()
	{
		if (appParent.childCount == 0)
		{
			return;
		}
		CanvasGroup canvasGroup = null;
		for (int i = 0; i < appParent.childCount; i++)
		{
			CanvasGroup component = appParent.GetChild(i).GetComponent<CanvasGroup>();
			if (!(component != null))
			{
				continue;
			}
			if (messageManager.showingMessage)
			{
				component.interactable = false;
				continue;
			}
			component.interactable = false;
			if (component.gameObject.activeInHierarchy)
			{
				canvasGroup = component;
			}
		}
		if (canvasGroup != null && !messageManager.showingMessage)
		{
			canvasGroup.interactable = true;
		}
	}

	public void SetCursorImage(cursorType t)
	{
		switch (t)
		{
		case cursorType.pointer:
			cursor.SetSprite(cursorTexture);
			break;
		case cursorType.crosshairs:
			cursor.SetSprite(crosshairTexture);
			break;
		case cursorType.finger:
		case cursorType.hand:
		case cursorType.magnifyingGlass:
			break;
		}
	}

	public void Activate()
	{
		StartCoroutine(ActivateComputer());
	}

	public void SetInteractable(bool b)
	{
		computerGroup.interactable = b;
	}

	public void DeactivateEventSystem()
	{
		computerEventSystem.enabled = false;
	}

	public void ActivateEventSystem()
	{
		computerEventSystem.enabled = true;
	}

	private IEnumerator ActivateComputer()
	{
		if (!hasInitialized)
		{
			GetComponent<OS_Filesystem>().Initialize(this);
			hasInitialized = true;
		}
		activeComputer = this;
		ENT_Player.playerObject.DropHang(0.5f);
		yield return null;
		canControl = true;
		inUse = true;
		mouseEnabled = true;
		customInputModule.SetActive(value: true);
		computerEventSystem.enabled = true;
		CL_UIManager.instance.standardInputModule.SetActive(value: false);
		base.transform.GetChild(0).gameObject.SetActive(value: true);
		activateEvent.Invoke();
		CL_UIManager.instance.crosshairController.SetCrosshairVisibility(b: false);
		osRoot.SetActive(value: true);
		osRoot.transform.rotation = Quaternion.identity;
		cameraControl.TakeoverCamera();
		SetInteractable(b: true);
		while (Vector3.Distance(ENT_Player.playerObject.transform.position, worldInterface.playerPosition.position) > 0.1f)
		{
			ENT_Player.playerObject.transform.position = Vector3.Lerp(ENT_Player.playerObject.transform.position, worldInterface.playerPosition.position, Time.deltaTime * 5f);
			Quaternion b = Quaternion.Euler(0f, worldInterface.playerPosition.rotation.eulerAngles.y, 0f);
			ENT_Player.playerObject.transform.rotation = Quaternion.Lerp(ENT_Player.playerObject.transform.rotation, b, Time.deltaTime * 5f);
			yield return null;
		}
		if (diskController != null && diskController.newDiskLoaded)
		{
			StartCoroutine(diskController.DiskLoadSequence());
		}
		InputManager.ActivateMap(1);
	}

	public void Deactivate()
	{
		ENT_Player.playerObject.transform.position = worldInterface.playerPosition.position;
		inUse = false;
		mouseEnabled = false;
		canControl = false;
		customInputModule.SetActive(value: false);
		CL_UIManager.instance.standardInputModule.SetActive(value: true);
		base.transform.GetChild(0).gameObject.SetActive(value: false);
		renderTexture.Release();
		if (activeComputer == this)
		{
			activeComputer = null;
		}
		CL_UIManager.instance.crosshairController.SetCrosshairVisibility(b: true);
		osRoot.SetActive(value: false);
		cameraControl.EndTakeover();
		soundPlayer.PlaySound("os:logoff");
		ENT_Player.playerObject.FreezeInputForFrame();
	}

	public static OS_Manager GetCurrentOS()
	{
		return activeComputer;
	}

	public OS_Filesystem GetFilesystem()
	{
		return filesystem;
	}

	public void LoadFloppy(Item floppy)
	{
		diskController.LoadDisk(floppy);
	}

	public DiskController GetDiskController()
	{
		return diskController;
	}

	internal bool IsInUse()
	{
		return inUse;
	}

	public static bool IsAnyComputerInUse()
	{
		if (inUse && activeComputer != null)
		{
			return true;
		}
		return false;
	}

	public void HideCursor()
	{
		cursor.GetImage().enabled = false;
	}

	public void ShowCursor()
	{
		cursor.GetImage().enabled = true;
	}
}
