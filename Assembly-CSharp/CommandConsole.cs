using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class CommandConsole : MonoBehaviour
{
	internal class Command
	{
		public string name;

		public string description;

		public bool cheat;

		public Action<string[]> callback;

		public Func<object> wrapping;

		public Action<CommandAutocomplete> autocomplete = delegate
		{
		};

		public Action<CommandValidator> validator;
	}

	[Serializable]
	private class Binds
	{
		public List<Bind> binds = new List<Bind>();

		public List<Alias> aliases = new List<Alias>();
	}

	[Serializable]
	private class Bind
	{
		public string chord;

		public string exec;
	}

	[Serializable]
	private class Alias
	{
		public string name;

		public string exec;
	}

	internal class CommandLineState
	{
		public Dictionary<string, Command> commands = new Dictionary<string, Command>();

		public List<Command> commandList = new List<Command>();

		public bool commandListDirty;
	}

	internal struct AutocompleteEntry
	{
		public string name;

		public string desc;

		public Func<object> wrapping;

		public AutocompleteEntry(string name, string desc, Func<object> value)
		{
			this.name = name;
			this.desc = desc;
			wrapping = value;
		}

		public readonly string NameEscaped()
		{
			string text = name;
			if (text.Contains(' ') && (!text.StartsWith('"') || !text.EndsWith('"')))
			{
				text = "\"" + text + "\"";
			}
			return text;
		}
	}

	public delegate ref bool VariableBoolDelegate();

	public delegate ref int VariableIntDelegate();

	public delegate ref float VariableFloatDelegate();

	public class CommandValidator
	{
		internal CommandAutocomplete autocomplete;

		public int activeArg => autocomplete.activeArg;

		public string ArgumentAt(int index)
		{
			return autocomplete.ArgumentAt(index);
		}

		public void Reject()
		{
			autocomplete.wasRejected = true;
		}
	}

	public class CommandAutocomplete
	{
		internal List<string> args = new List<string>();

		internal List<AutocompleteEntry> validAutocomplete = new List<AutocompleteEntry>();

		internal bool wasRejected;

		internal AutocompleteBuilt subautocomplete;

		internal int caretPosition;

		internal CommandLineState state;

		public int activeArg { get; internal set; }

		public string ArgumentAt(int index)
		{
			if (index < 0 || index >= args.Count)
			{
				return "";
			}
			return args[index];
		}

		public void FromArray(IReadOnlyList<string> fromWhat)
		{
			foreach (string item in fromWhat)
			{
				validAutocomplete.Add(new AutocompleteEntry(item, null, null));
			}
		}

		public void FromArrayWithDesc(IReadOnlyList<(string name, string desc)> fromWhat)
		{
			foreach (var (name, desc) in fromWhat)
			{
				validAutocomplete.Add(new AutocompleteEntry(name, desc, null));
			}
		}

		public void Reject()
		{
			wasRejected = true;
		}
	}

	public class CommandBuilder
	{
		internal Command command;

		private static readonly string[] trueFalseArray = new string[2] { "true", "false" };

		public CommandBuilder NotCheat()
		{
			command.cheat = false;
			return this;
		}

		public CommandBuilder Description(string text)
		{
			command.description = text;
			return this;
		}

		public CommandBuilder OverValue(Func<object> obj)
		{
			command.wrapping = obj;
			return this;
		}

		public CommandBuilder Execute(Action<string[]> additionalCallback)
		{
			Command obj = command;
			obj.callback = (Action<string[]>)Delegate.Combine(obj.callback, additionalCallback);
			return this;
		}

		public CommandBuilder AutocompleteVariadicFromArray(IReadOnlyList<string> entries)
		{
			command.autocomplete = delegate(CommandAutocomplete autocomplete)
			{
				autocomplete.FromArray(entries);
			};
			return this;
		}

		public CommandBuilder AutocompleteSingleFromArray(IReadOnlyList<string> entries)
		{
			command.autocomplete = delegate(CommandAutocomplete autocomplete)
			{
				if (autocomplete.activeArg == 0)
				{
					autocomplete.FromArray(entries);
				}
				else
				{
					autocomplete.Reject();
				}
			};
			return this;
		}

		public CommandBuilder AutocompleteSingeFloat()
		{
			command.autocomplete = delegate(CommandAutocomplete autocomplete)
			{
				if (autocomplete.activeArg != 0 || !float.TryParse(autocomplete.ArgumentAt(0), out var _))
				{
					autocomplete.Reject();
				}
			};
			return this;
		}

		public CommandBuilder AutocompleteSingleBool()
		{
			command.autocomplete = delegate(CommandAutocomplete autocomplete)
			{
				autocomplete.FromArray(trueFalseArray);
			};
			return this;
		}

		public CommandBuilder AutocompleteCustom(Action<CommandAutocomplete> builder)
		{
			command.autocomplete = builder;
			return this;
		}

		public CommandBuilder AutocompleteValidator(Action<CommandValidator> builder)
		{
			command.validator = builder;
			return this;
		}
	}

	private class CommandExecState
	{
		public CommandLexResult executingRes;

		public int executingResIdx;
	}

	private struct CommandLexResult
	{
		public List<CommandToken> tokens;

		public readonly int FindFocusedToken(int caretPosition)
		{
			for (int i = 0; i < tokens.Count; i++)
			{
				if (caretPosition >= 0 && caretPosition <= tokens[i].content.Length)
				{
					return i;
				}
				caretPosition -= tokens[i].content.Length;
			}
			return -1;
		}
	}

	private struct CommandToken
	{
		public bool isEndOfCommand;

		public bool isArgumentSeparator;

		public bool isQuoted;

		public string content;

		public string contentEscaped()
		{
			string text = content;
			if (isQuoted)
			{
				if (text.StartsWith('"'))
				{
					string text2 = text;
					text = text2.Substring(1, text2.Length - 1);
				}
				if (text.EndsWith('"'))
				{
					string text2 = text;
					text = text2.Substring(0, text2.Length - 1);
				}
				text = text.Replace("\"\"", "\"");
			}
			return text;
		}
	}

	internal class AutocompleteBuilt
	{
		public int caretPosition;

		public IReadOnlyList<AutocompleteEntry> autocompleteSuggestions = Array.Empty<AutocompleteEntry>();

		public List<(string line, bool isRejected)> inputFieldContent = new List<(string, bool)>();

		public int focusedLine = -1;

		public string autocompleteCurrent = "";
	}

	private enum CommandUsageKind
	{
		MayUse = 0,
		CheatsNotEnabled = 1,
		CheatBlockedByGamemode = 2
	}

	private struct MemoryMemory
	{
		public long lastFrame;

		public long lowest;
	}

	private static string bindsPath;

	private static Binds loadedBinds;

	private string bindsPressedSequence = "";

	public GameObject consoleUI;

	public TMP_InputField historyText;

	public TMP_InputField inputField;

	public ScrollRect historyScrollRect;

	public ScrollRect autocompleteScrollRect;

	public TMP_Text autocomplete;

	public TMP_Text bindPreview;

	public static CommandConsole instance;

	private const int historyMaxTextAmount = 16384;

	private static int historyTextCur = 0;

	private static LinkedList<string> historyTextString = new LinkedList<string>();

	private bool historyTextDirty;

	private static List<string> commandHistory = new List<string>();

	private int commandHistoryIndex = -1;

	private Stack<CommandLineState> states = new Stack<CommandLineState>();

	public static bool cheatsEnabled = false;

	public static bool hasCheated = false;

	private bool isConsoleVisible;

	private bool buttonPressed;

	private string redTag = "<color=\"red\">";

	private string greenTag = "<color=\"green\">";

	private string greyTag = "<color=#d3d3d3>";

	private string colorEndTag = "</color>";

	private string linkStart = "<link=\"dumb\">";

	private string linkEnd = "</link>";

	private string lastTextField = "";

	private int lastCaret;

	private List<AutocompleteEntry> autocompleteEntries = new List<AutocompleteEntry>();

	private bool autocompleteAnyWrapping;

	private int historyOrAutocompleteIndex;

	private string lastNeutralText = "";

	private int lastFrameCaret;

	private readonly List<CommandExecState> execStates = new List<CommandExecState>();

	private int lastHoveredLinkIndex = -1;

	private bool memoryDebug;

	private bool memoryDebugReset;

	private Rect memoryWindowRect = new Rect(100f, 100f, 400f, 400f);

	private MemoryMemory memoryGc;

	private MemoryMemory memoryGpuDriver;

	private MemoryMemory memoryTotalAllocated;

	private MemoryMemory memoryTotalUnused;

	private void Awake()
	{
		if (bindsPath == null)
		{
			bindsPath = Path.Combine(Application.persistentDataPath, "binds.json");
		}
		historyText.scrollSensitivity = 0f;
		states.Push(new CommandLineState());
		hasCheated = false;
		historyTextDirty = true;
		commandHistoryIndex = commandHistory.Count;
		InitializeBinds();
		if (instance == null)
		{
			instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			BuildCommand("help", HelpCommand).NotCheat().Description("View all available commands and their descriptions.");
			BuildCommand("cheats", EnableCheatsCommand).NotCheat().Description("Allows access to additional commands, which disable scoring").OverValue(() => cheatsEnabled);
			BuildCommand("delay", DelayCommand).NotCheat().Description("[frames=1] (toexecute): Delays execution of further commands, optionally for some number of frames or seconds. Useful with ';'. May also specify deferred command as 2nd parameter.").AutocompleteCustom(delegate(CommandAutocomplete autocomplete)
			{
				if (autocomplete.activeArg != 1)
				{
					if (autocomplete.activeArg != 0)
					{
						autocomplete.Reject();
					}
					bool flag = false;
					string text = autocomplete.ArgumentAt(0);
					if (text.EndsWith('s'))
					{
						string text2 = text;
						text = text2.Substring(0, text2.Length - 1);
						flag = true;
					}
					if (flag && (!float.TryParse(text, out var _) || text.Length == 0))
					{
						autocomplete.Reject();
					}
					if (!flag && !int.TryParse(text, out var _))
					{
						autocomplete.Reject();
					}
				}
			});
			BuildCommand("clear", ClearConsole).NotCheat().Description("Clear console.");
			BuildCommand("bind", BindBind).NotCheat().Description("[chord] [commands]: bind a keychord to some commands, e.g. bind rr restart").AutocompleteCustom(delegate(CommandAutocomplete autocomplete)
			{
				if (autocomplete.activeArg != 0)
				{
					if (autocomplete.activeArg == 1)
					{
						string content = autocomplete.ArgumentAt(autocomplete.activeArg);
						autocomplete.subautocomplete = BuildAutocompleteEntries(content, autocomplete.caretPosition, autocomplete.state);
					}
					else
					{
						autocomplete.Reject();
					}
				}
			});
			BuildCommand("unbind", UnbindBind).NotCheat().Description("[chord]: remove bind bound to written chord").AutocompleteCustom(delegate(CommandAutocomplete autocomplete)
			{
				if (autocomplete.activeArg != 0)
				{
					autocomplete.Reject();
				}
				else
				{
					autocomplete.FromArrayWithDesc(loadedBinds.binds.Select((Bind b) => (chord: b.chord, exec: b.exec)).ToArray());
				}
			});
			BuildCommand("unbindall", UnbindBindAll).NotCheat().Description("Unbind all binds");
			BuildCommand("listbinds", ListBinds).NotCheat().Description("list all active binds");
			BuildCommand("alias", BindAlias).NotCheat().Description("[name] [commands]: associate a certain name with certain commands").AutocompleteCustom(delegate(CommandAutocomplete autocomplete)
			{
				if (autocomplete.activeArg != 0)
				{
					if (autocomplete.activeArg == 1)
					{
						string content = autocomplete.ArgumentAt(autocomplete.activeArg);
						autocomplete.subautocomplete = BuildAutocompleteEntries(content, autocomplete.caretPosition, autocomplete.state);
					}
					else
					{
						autocomplete.Reject();
					}
				}
			});
			BuildCommand("unalias", RemoveAlias).Description("[name]: alias to remove").NotCheat().AutocompleteCustom(delegate(CommandAutocomplete autocomplete)
			{
				if (autocomplete.activeArg != 0)
				{
					autocomplete.Reject();
				}
				else
				{
					autocomplete.FromArrayWithDesc(loadedBinds.aliases.Select((Alias b) => (name: b.name, exec: b.exec)).ToArray());
				}
			});
			BuildCommand("unaliasall", RemoveAliasAll).Description("Remove all aliases.").NotCheat();
			BuildCommand("listaliases", ListAliases).NotCheat().Description("list all active binds");
			BuildVariableBool(() => ref memoryDebug, "memory_debug", "View memory usage over time");
			BuildVariableBool(() => ref memoryDebugReset, "memory_debug_reset", "Reset persistent counters");
			foreach (Alias a in loadedBinds.aliases)
			{
				BuildCommand(a.name, delegate
				{
					ExecuteCommand(a.exec, recordHistory: true, recordInCommandHistory: false);
				}).NotCheat().Description(a.exec);
			}
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		HideConsole();
	}

	private void LateUpdate()
	{
		foreach (CommandLineState state in states)
		{
			if (state.commandListDirty)
			{
				state.commandList.Sort((Command x, Command y) => x.name.CompareTo(y.name));
				state.commandListDirty = false;
			}
		}
		if (Input.GetKey(KeyCode.BackQuote) && Input.GetKey(KeyCode.LeftShift) && !buttonPressed)
		{
			inputField.text = string.Empty;
			buttonPressed = true;
			ToggleConsole();
		}
		if (!Input.GetKey(KeyCode.BackQuote) || (!Input.GetKey(KeyCode.LeftShift) && buttonPressed))
		{
			buttonPressed = false;
		}
		if (isConsoleVisible)
		{
			if (historyTextDirty)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string item in historyTextString)
				{
					stringBuilder.AppendLine(item);
				}
				string text = stringBuilder.ToString();
				historyText.text = text;
				historyTextDirty = false;
			}
			if (Input.GetKeyDown(KeyCode.Backspace) && Input.GetKey(KeyCode.LeftControl))
			{
				DeleteWordBeforeCursor();
			}
			int num = historyOrAutocompleteIndex;
			if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Tab)))
			{
				inputField.caretPosition = lastFrameCaret;
				num--;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow) || (!Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Tab)))
			{
				inputField.caretPosition = lastFrameCaret;
				num = (num + 1) % (autocompleteEntries.Count + 1);
			}
			num = Mathf.Clamp(num, -commandHistory.Count, autocompleteEntries.Count);
			if (historyOrAutocompleteIndex == 0)
			{
				lastNeutralText = inputField.text;
			}
			if (num != historyOrAutocompleteIndex && num == 0)
			{
				inputField.text = lastNeutralText;
				inputField.caretPosition = inputField.text.Length;
			}
			if (num != historyOrAutocompleteIndex && num < 0)
			{
				inputField.text = commandHistory[commandHistory.Count + num];
				inputField.caretPosition = inputField.text.Length;
			}
			if (num != historyOrAutocompleteIndex && num > 0)
			{
				string with = autocompleteEntries[num - 1].NameEscaped();
				ReplaceTextAtCaretPositionWith(with);
			}
			if (num != historyOrAutocompleteIndex)
			{
				UpdateAutocomplete(updateAutocompleteEntries: false);
			}
			historyOrAutocompleteIndex = num;
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				HideConsole();
			}
			if (inputField.text != lastTextField)
			{
				lastNeutralText = inputField.text;
				historyOrAutocompleteIndex = 0;
			}
			UpdateAutocomplete(updateAutocompleteEntries: true);
			lastFrameCaret = inputField.caretPosition;
			if (Input.GetKeyDown(KeyCode.Return))
			{
				ExecuteCommand(RemoveTags(inputField.text), recordHistory: true, recordInCommandHistory: true);
				inputField.text = string.Empty;
				inputField.ActivateInputField();
			}
		}
		if (isConsoleVisible || (!(CL_GameManager.gMan == null) && CL_GameManager.gMan.isPaused) || loadedBinds == null || !Input.anyKeyDown || Input.GetKeyDown(KeyCode.LeftShift))
		{
			return;
		}
		string text2 = null;
		Bind bind = null;
		bool key = Input.GetKey(KeyCode.LeftShift);
		foreach (Bind bind2 in loadedBinds.binds)
		{
			if (bindsPressedSequence.Length < bind2.chord.Length && bind2.chord.StartsWith(bindsPressedSequence))
			{
				char c = bind2.chord[bindsPressedSequence.Length];
				string text3 = null;
				if (char.IsLetter(c) || char.IsNumber(c) || char.IsPunctuation(c))
				{
					text3 = char.ToLower(c).ToString();
				}
				if (c == ' ')
				{
					text3 = "space";
				}
				bool flag = text3 != null && Input.GetKeyDown(text3);
				if (char.IsLetter(c) && char.IsUpper(c))
				{
					flag = flag && key;
				}
				if (char.IsLetter(c) && char.IsLower(c))
				{
					flag = flag && !key;
				}
				if (flag)
				{
					text2 = c.ToString();
				}
				if (flag && bindsPressedSequence.Length + 1 == bind2.chord.Length)
				{
					bind = bind2;
				}
			}
		}
		if (bind == null && text2 == null)
		{
			bindsPressedSequence = "";
		}
		if (bind == null && text2 != null)
		{
			bindsPressedSequence += text2;
		}
		if (bind != null)
		{
			ExecuteCommand(bind.exec, recordHistory: true, recordInCommandHistory: false);
			bindsPressedSequence = bind.chord;
		}
		if (bindPreview != null)
		{
			bool flag2 = false;
			string text4 = bindsPressedSequence;
			foreach (char c2 in text4)
			{
				flag2 |= char.IsWhiteSpace(c2);
			}
			string text5 = bindsPressedSequence;
			if (flag2)
			{
				text5 = "\"" + text5 + "\"";
			}
			bindPreview.text = text5;
			DOTween.Complete(bindPreview);
			bindPreview.color = Color.white;
			if (bind != null)
			{
				bindPreview.DOFade(0f, 0.3f).SetUpdate(isIndependentUpdate: true);
				bindsPressedSequence = "";
			}
		}
	}

	public static void Log(string message)
	{
		if (instance != null)
		{
			instance.AddMessageToHistory(message);
			Debug.Log(message);
			return;
		}
		historyTextString.AddLast(message);
		historyTextCur += message.Length;
		while (historyTextCur > 16384)
		{
			historyTextCur -= historyTextString.First.Value.Length;
			historyTextString.RemoveFirst();
		}
	}

	public static void LogError(string message)
	{
		if (instance != null)
		{
			instance.AddMessageToHistory("<color=red>" + message + "</color>");
			Debug.LogError(message);
		}
	}

	public static void AddCommand(string command, Action<string[]> callback, bool cheat = true)
	{
		if (instance != null)
		{
			instance.RegisterCommand(command, callback, cheat);
		}
	}

	public static CommandBuilder BuildCommand(string command, Action<string[]> callback)
	{
		CommandBuilder commandBuilder = null;
		if (instance != null)
		{
			Command command2 = instance.RegisterCommand(command, callback);
			commandBuilder = new CommandBuilder();
			commandBuilder.command = command2;
		}
		else
		{
			Debug.LogWarning("Attempted to register " + command + " before CommandConsole was created! Passing nil command. Register your command later!");
			commandBuilder = new CommandBuilder();
			commandBuilder.command = new Command();
		}
		return commandBuilder;
	}

	public static CommandBuilder BuildVariableBool(VariableBoolDelegate what, string name, string desc)
	{
		return BuildCommand(name, Command).Description(desc).AutocompleteSingleBool().OverValue(() => what());
		void Command(string[] args)
		{
			ref bool reference = ref what();
			if (args.Length == 0)
			{
				reference = !reference;
			}
			if (args.Length != 0 && bool.TryParse(args[0], out var result))
			{
				reference = result;
			}
		}
	}

	public static CommandBuilder BuildVariableInt(VariableIntDelegate what, string name, string desc, int? defaultValue = null)
	{
		return BuildCommand(name, Command).Description(desc).AutocompleteCustom(delegate(CommandAutocomplete autocomplete)
		{
			if (autocomplete.activeArg > 1)
			{
				autocomplete.Reject();
			}
			if (autocomplete.activeArg == 0 && !int.TryParse(autocomplete.ArgumentAt(0), out var _))
			{
				autocomplete.Reject();
			}
		}).OverValue(() => what());
		void Command(string[] args)
		{
			ref int reference = ref what();
			if (args.Length == 0 && defaultValue.HasValue)
			{
				reference = defaultValue.Value;
			}
			if (args.Length == 0 && !defaultValue.HasValue)
			{
				instance.AddMessageToHistory("Missing value!");
			}
			if (args.Length != 0 && int.TryParse(args[0], out var result))
			{
				reference = result;
			}
		}
	}

	public static CommandBuilder BuildVariableFloat(VariableFloatDelegate what, string name, string desc, int? defaultValue = null)
	{
		return BuildCommand(name, Command).Description(desc).AutocompleteCustom(delegate(CommandAutocomplete autocomplete)
		{
			if (autocomplete.activeArg > 1)
			{
				autocomplete.Reject();
			}
			if (autocomplete.activeArg == 0 && !float.TryParse(autocomplete.ArgumentAt(0), out var _))
			{
				autocomplete.Reject();
			}
		}).OverValue(() => what());
		void Command(string[] args)
		{
			ref float reference = ref what();
			if (args.Length == 0 && defaultValue.HasValue)
			{
				reference = defaultValue.Value;
			}
			if (args.Length == 0 && !defaultValue.HasValue)
			{
				instance.AddMessageToHistory("Missing value!");
			}
			if (args.Length != 0 && float.TryParse(args[0], out var result))
			{
				reference = result;
			}
		}
	}

	public static void CommandContextPush()
	{
		if (instance != null)
		{
			instance.states.Push(new CommandLineState());
		}
	}

	public static void CommandContextPop()
	{
		if (instance != null && instance.states.Count > 1)
		{
			instance.states.Pop();
		}
	}

	public static void RemoveCommand(string command)
	{
		command = command.ToLower();
		if (instance != null && instance.states.TryPeek(out var result))
		{
			if (result.commands.TryGetValue(command, out var value))
			{
				result.commandList.Remove(value);
			}
			result.commands.Remove(command);
		}
	}

	private Command RegisterCommand(string command, Action<string[]> callback, bool cheat = true)
	{
		Command command2 = null;
		command = command.ToLower();
		CommandLineState commandLineState = states.Peek();
		if (commandLineState.commands.TryGetValue(command, out var value))
		{
			Command command3 = value;
			command3.callback = (Action<string[]>)Delegate.Combine(command3.callback, callback);
			command2 = value;
		}
		else
		{
			Command command4 = new Command();
			command4.name = command;
			command4.callback = callback;
			command4.cheat = cheat;
			commandLineState.commands[command] = command4;
			commandLineState.commandList.Add(command4);
			command2 = command4;
		}
		commandLineState.commandListDirty = true;
		return command2;
	}

	private void ToggleConsole()
	{
		isConsoleVisible = !isConsoleVisible;
		consoleUI.SetActive(isConsoleVisible);
		autocompleteScrollRect.gameObject.SetActive(isConsoleVisible);
		if (isConsoleVisible)
		{
			inputField.ActivateInputField();
			Cursor.lockState = CursorLockMode.None;
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine(WaitForScrollToBottom());
			}
		}
		else if (!CL_GameManager.isDead() && !CL_GameManager.gMan.isPaused)
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
		CL_GameManager.gMan.lockPlayerInput = isConsoleVisible;
	}

	public static void HideConsole()
	{
		if (instance.isConsoleVisible)
		{
			instance.ToggleConsole();
		}
	}

	public static bool IsConsoleVisible()
	{
		if (instance == null)
		{
			return false;
		}
		return instance.isConsoleVisible;
	}

	public string CancelCommandExecution()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (CommandExecState execState in execStates)
		{
			for (int i = execState.executingResIdx + 1; i < execState.executingRes.tokens.Count; i++)
			{
				stringBuilder.Append(execState.executingRes.tokens[i].content);
			}
			stringBuilder.Append(";");
			execState.executingRes = default(CommandLexResult);
			execState.executingResIdx = int.MaxValue;
		}
		execStates.Clear();
		return stringBuilder.ToString();
	}

	public void ExecuteCommand(string input, bool recordHistory)
	{
		ExecuteCommand(input, recordHistory, recordHistory);
	}

	internal void ExecuteCommand(string input, bool recordHistory, bool recordInCommandHistory)
	{
		CommandLineState commandLineState = states.Peek();
		if (recordHistory && input.Length > 0)
		{
			AddMessageToHistory(input);
		}
		if (recordInCommandHistory)
		{
			if (commandHistory.Count != 0)
			{
				List<string> list = commandHistory;
				if (!(list[list.Count - 1] != input))
				{
					goto IL_0053;
				}
			}
			commandHistory.Add(input);
			goto IL_0053;
		}
		goto IL_0063;
		IL_0053:
		commandHistoryIndex = commandHistory.Count;
		goto IL_0063;
		IL_0063:
		CommandExecState commandExecState = new CommandExecState
		{
			executingRes = CommandLineLex(input),
			executingResIdx = 0
		};
		execStates.Add(commandExecState);
		bool flag = true;
		Command command = null;
		List<string> list2 = new List<string>();
		bool flag2 = false;
		commandExecState.executingResIdx = 0;
		while (commandExecState.executingRes.tokens != null && commandExecState.executingResIdx < commandExecState.executingRes.tokens.Count)
		{
			CommandToken commandToken = commandExecState.executingRes.tokens[commandExecState.executingResIdx];
			if (!commandToken.isArgumentSeparator)
			{
				if (flag && !commandToken.isEndOfCommand)
				{
					command = commandLineState.commands.GetValueOrDefault(commandToken.contentEscaped());
					CommandUsageKind commandUsageKind = MayUseCommand(command);
					if (command == null || commandUsageKind == CommandUsageKind.CheatsNotEnabled)
					{
						AddMessageToHistory("Unknown command: " + commandToken.contentEscaped());
						command = null;
					}
					if (commandUsageKind == CommandUsageKind.CheatBlockedByGamemode)
					{
						AddMessageToHistory("Hey, cheats are blocked here. Stop it!");
						command = null;
					}
					if (command != null)
					{
						flag2 |= command.cheat;
					}
				}
				if (!flag && !commandToken.isEndOfCommand)
				{
					list2.Add(commandToken.contentEscaped());
				}
				flag = false;
				if (commandToken.isEndOfCommand)
				{
					command?.callback(list2.ToArray());
				}
				if (commandToken.isEndOfCommand)
				{
					list2.Clear();
					command = null;
					flag = true;
				}
			}
			commandExecState.executingResIdx++;
		}
		if (commandExecState.executingRes.tokens != null)
		{
			command?.callback(list2.ToArray());
		}
		execStates.Remove(commandExecState);
		if (!hasCheated && flag2)
		{
			hasCheated = true;
			CL_UIManager.instance.cheatTracker.SetActive(value: true);
			Log("WARNING: Cheat activated. Saving of stats has been disabled for this session.");
		}
	}

	private void AddMessageToHistory(string message)
	{
		historyTextString.AddLast(message);
		historyTextCur += message.Length;
		while (historyTextCur > 16384)
		{
			historyTextCur -= historyTextString.First.Value.Length;
			historyTextString.RemoveFirst();
		}
		historyTextDirty = true;
		if (base.gameObject.activeInHierarchy)
		{
			StartCoroutine(WaitForScrollToBottom());
		}
	}

	private IEnumerator WaitForScrollToBottom()
	{
		yield return new WaitForNextFrameUnit();
		yield return new WaitForNextFrameUnit();
		historyScrollRect.verticalNormalizedPosition = -1f;
	}

	private void HelpCommand(string[] args)
	{
		CommandLineState commandLineState = states.Peek();
		string text = "---\nAvailable commands:\n";
		foreach (Command command in commandLineState.commandList)
		{
			bool flag = false;
			if (!command.cheat)
			{
				flag = true;
			}
			else if (cheatsEnabled && command.cheat && CL_GameManager.gamemode.allowCheats)
			{
				flag = true;
			}
			if (flag)
			{
				text += command.name;
				if (command.description != null && command.description.Length > 0)
				{
					text = text + ": <color=grey>" + command.description + "</color>";
				}
				text += "\n";
			}
		}
		AddMessageToHistory(text);
	}

	private void InitializeBinds()
	{
		bool flag = false;
		if (loadedBinds == null && File.Exists(bindsPath))
		{
			Debug.Log("Initializing binds");
			loadedBinds = JsonUtility.FromJson<Binds>(File.ReadAllText(bindsPath));
			flag = loadedBinds != null;
		}
		if (loadedBinds == null)
		{
			Debug.Log("Binds file not found");
			loadedBinds = new Binds();
		}
		if (!flag)
		{
			return;
		}
		Debug.Log("Successfully loaded binds");
		foreach (Bind bind in loadedBinds.binds)
		{
			Debug.Log(bind.chord + " is bound to " + bind.exec);
		}
		foreach (Alias alias in loadedBinds.aliases)
		{
			Debug.Log(alias.name + " aliases " + alias.exec);
		}
	}

	private void ClearConsole(string[] args)
	{
		historyTextString.Clear();
		historyTextCur = 0;
		historyTextDirty = true;
	}

	private void BindBind(string[] args)
	{
		if (args.Length == 0)
		{
			AddMessageToHistory("Missing keychord!");
			return;
		}
		if (args.Length == 1)
		{
			AddMessageToHistory("Missing bound command!");
			return;
		}
		InitializeBinds();
		loadedBinds.binds.RemoveAll((Bind old) => old.chord == args[0]);
		loadedBinds.binds.Add(new Bind
		{
			chord = args[0],
			exec = args[1]
		});
		Debug.Log("Command bound");
		string contents = JsonUtility.ToJson(loadedBinds, prettyPrint: true);
		File.WriteAllText(bindsPath, contents);
	}

	private void UnbindBind(string[] args)
	{
		InitializeBinds();
		if (args.Length == 0)
		{
			AddMessageToHistory("Missing keychord!");
			return;
		}
		bool num = loadedBinds.binds.RemoveAll((Bind b) => b.chord == args[0]) > 0;
		if (num)
		{
			AddMessageToHistory("Removed bind");
		}
		if (!num)
		{
			AddMessageToHistory("Could not find any bind using chord \"" + args[0] + "\"");
		}
		string contents = JsonUtility.ToJson(loadedBinds, prettyPrint: true);
		File.WriteAllText(bindsPath, contents);
	}

	private void UnbindBindAll(string[] args)
	{
		InitializeBinds();
		if (loadedBinds.binds.Count > 0)
		{
			AddMessageToHistory($"Removed {loadedBinds.binds.Count} binds!");
			loadedBinds.binds.Clear();
			string contents = JsonUtility.ToJson(loadedBinds, prettyPrint: true);
			File.WriteAllText(bindsPath, contents);
		}
		else
		{
			AddMessageToHistory("There are no binds to remove...");
		}
	}

	private void ListBinds(string[] args)
	{
		InitializeBinds();
		if (loadedBinds.binds.Count == 0)
		{
			AddMessageToHistory("No binds currently bound! Use \"bind\" command to add some.");
		}
		foreach (Bind bind in loadedBinds.binds)
		{
			AddMessageToHistory(bind.chord + " is bound to \"" + bind.exec + "\"");
		}
	}

	private void BindAlias(string[] args)
	{
		if (args.Length == 0)
		{
			AddMessageToHistory("Missing alias name!");
			return;
		}
		if (args.Length == 1)
		{
			AddMessageToHistory("Missing bound command!");
			return;
		}
		InitializeBinds();
		string name = args[0];
		string command = args[1];
		loadedBinds.aliases.RemoveAll((Alias old) => old.name == name);
		loadedBinds.aliases.Add(new Alias
		{
			name = name,
			exec = command
		});
		Debug.Log("Command aliased");
		string contents = JsonUtility.ToJson(loadedBinds, prettyPrint: true);
		File.WriteAllText(bindsPath, contents);
		RemoveCommand(name);
		BuildCommand(name, delegate
		{
			ExecuteCommand(command, recordHistory: true, recordInCommandHistory: false);
		}).NotCheat().Description(command);
	}

	private void RemoveAlias(string[] args)
	{
		InitializeBinds();
		if (args.Length == 0)
		{
			AddMessageToHistory("Missing name!");
			return;
		}
		bool num = loadedBinds.aliases.RemoveAll((Alias old) => old.name == args[0]) > 0;
		if (num)
		{
			AddMessageToHistory("Removed bind");
			RemoveCommand(args[0]);
		}
		if (!num)
		{
			AddMessageToHistory("Could not find any alias named \"" + args[0] + "\"");
		}
		string contents = JsonUtility.ToJson(loadedBinds, prettyPrint: true);
		File.WriteAllText(bindsPath, contents);
	}

	private void RemoveAliasAll(string[] args)
	{
		InitializeBinds();
		if (loadedBinds.aliases.Count > 0)
		{
			AddMessageToHistory($"Removed {loadedBinds.aliases.Count} aliases!");
			loadedBinds.aliases.Clear();
			string contents = JsonUtility.ToJson(loadedBinds, prettyPrint: true);
			File.WriteAllText(bindsPath, contents);
		}
		else
		{
			AddMessageToHistory("There are no aliases to remove...");
		}
	}

	private void ListAliases(string[] args)
	{
		InitializeBinds();
		if (loadedBinds.aliases.Count == 0)
		{
			AddMessageToHistory("No aliases currently bound! Use \"alias\" command to add some.");
		}
		foreach (Alias alias in loadedBinds.aliases)
		{
			AddMessageToHistory(alias.name + " is aliasing \"" + alias.exec + "\"");
		}
	}

	private void DelayCommand(string[] args)
	{
		string text = ((args.Length != 0) ? args[0] : "");
		bool isSeconds = false;
		if (text.EndsWith('s'))
		{
			isSeconds = true;
			string text2 = text;
			text = text2.Substring(0, text2.Length - 1);
		}
		if (!float.TryParse(text, out var count))
		{
			count = 1f;
		}
		string whatToExec = ((args.Length <= 1) ? CancelCommandExecution() : args[1]);
		StartCoroutine(DelayCoroutine(whatToExec));
		IEnumerator DelayCoroutine(string input)
		{
			if (isSeconds)
			{
				yield return new WaitForSeconds(count);
			}
			else
			{
				int intCount = (int)count;
				for (int i = 0; i < intCount; i++)
				{
					yield return new WaitForEndOfFrame();
				}
			}
			ExecuteCommand(input, recordHistory: false);
		}
	}

	private void EnableCheatsCommand(string[] args)
	{
		if (args.Length == 0)
		{
			cheatsEnabled = !cheatsEnabled;
		}
		else
		{
			if (!bool.TryParse(args[0], out var result))
			{
				Log("Unable to parse " + args[0] + " arg needs to be a boolean (true/false/0/1).");
				return;
			}
			cheatsEnabled = result;
		}
		if (cheatsEnabled)
		{
			AddMessageToHistory("Cheats Enabled");
			AddMessageToHistory("WARNING: Cheat activated. Saving of stats has been disabled for this session.");
			hasCheated = true;
			CL_UIManager.instance.cheatTracker.SetActive(value: true);
		}
		else
		{
			AddMessageToHistory("Cheats Disabled");
		}
	}

	private void DeleteWordBeforeCursor()
	{
		string text = RemoveTags(lastTextField);
		int num = lastCaret - 1;
		int num2 = num;
		while (num2 >= 0 && text[num2] == ' ')
		{
			num2--;
		}
		while (num2 >= 0)
		{
			char c = text[num2];
			if (c == ' ' || c == ';')
			{
				break;
			}
			num2--;
		}
		num2++;
		num++;
		if (num2 == lastCaret)
		{
			num2--;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		string text2 = text.Substring(0, num2);
		string text3 = text;
		int num3 = num;
		string text4 = text3.Substring(num3, text3.Length - num3);
		inputField.text = text2 + text4;
		inputField.caretPosition = num2;
	}

	private void ReplaceTextAtCaretPositionWith(string with)
	{
		string text = inputField.text.Replace(redTag, "").Replace(colorEndTag, "");
		int caretPosition = inputField.caretPosition;
		int num = text.IndexOf(linkStart);
		int num2 = ((num != -1) ? text.IndexOf(linkEnd, num) : (-1));
		int num3;
		if (num != -1)
		{
			num3 = ((num2 != -1) ? 1 : 0);
			if (num3 != 0)
			{
				string text2 = text.Substring(0, num);
				string text3 = text;
				int num4 = num2 + linkEnd.Length;
				string text4 = text2 + with + text3.Substring(num4, text3.Length - num4);
				inputField.text = text4;
			}
		}
		else
		{
			num3 = 0;
		}
		int num5 = num;
		int num6 = num2;
		if (caretPosition > num6)
		{
			num6 -= linkStart.Length + linkEnd.Length;
		}
		if (num3 != 0 && caretPosition < num5)
		{
			inputField.caretPosition = caretPosition;
		}
		if (num3 != 0 && num5 <= caretPosition && caretPosition < num6)
		{
			inputField.caretPosition = num + with.Length;
		}
		if (num3 != 0 && num2 <= caretPosition)
		{
			inputField.caretPosition = caretPosition - num2 + num + with.Length;
		}
	}

	private static CommandLexResult CommandLineLex(string content)
	{
		List<CommandToken> list = new List<CommandToken>();
		int i;
		for (i = 0; i < content.Length && content[i] == ' '; i++)
		{
		}
		if (i > 0)
		{
			list.Add(new CommandToken
			{
				isEndOfCommand = false,
				isArgumentSeparator = true,
				content = new string(' ', i)
			});
		}
		int num = i;
		for (; i < content.Length; i++)
		{
			char num2 = content[i];
			bool flag = num2 == ' ';
			bool flag2 = num2 == ';';
			bool flag3 = num2 == '"';
			CommandToken item;
			int num3;
			if (flag2)
			{
				if (num != i)
				{
					item = new CommandToken
					{
						isEndOfCommand = false,
						isArgumentSeparator = (content[num] == ' ')
					};
					num3 = num;
					item.content = content.Substring(num3, i - num3);
					list.Add(item);
				}
				list.Add(new CommandToken
				{
					isEndOfCommand = true,
					isArgumentSeparator = false,
					content = ";"
				});
				num = i + 1;
			}
			if (flag)
			{
				if (num != i)
				{
					item = new CommandToken
					{
						isEndOfCommand = false,
						isArgumentSeparator = false
					};
					num3 = num;
					item.content = content.Substring(num3, i - num3);
					list.Add(item);
				}
				num = i;
				for (; i < content.Length && content[i] == ' '; i++)
				{
				}
				item = new CommandToken
				{
					isEndOfCommand = false,
					isArgumentSeparator = true
				};
				num3 = num;
				item.content = content.Substring(num3, i - num3);
				list.Add(item);
				num = i;
				i--;
			}
			if (!flag3)
			{
				continue;
			}
			if (num != i)
			{
				item = new CommandToken
				{
					isEndOfCommand = false,
					isArgumentSeparator = false
				};
				num3 = num;
				item.content = content.Substring(num3, i - num3);
				list.Add(item);
			}
			num = i;
			for (i++; i < content.Length; i++)
			{
				if (content[i] == '"')
				{
					bool num4 = num + 1 == i;
					bool flag4 = content[i - 1] == '"';
					bool flag5 = i + 1 < content.Length && content[i + 1] == '"';
					if ((!num4 || flag5) && !(flag4 || flag5))
					{
						i++;
						break;
					}
				}
			}
			item = new CommandToken
			{
				isEndOfCommand = false,
				isArgumentSeparator = false,
				isQuoted = true
			};
			num3 = num;
			item.content = content.Substring(num3, i - num3);
			list.Add(item);
			num = i;
			if (content[i - 1] != '"')
			{
				num++;
			}
			else
			{
				i--;
			}
		}
		if (num < content.Length)
		{
			CommandToken item = new CommandToken
			{
				isEndOfCommand = (content[num] == ';'),
				isArgumentSeparator = (content[num] == ' ')
			};
			int num3 = num;
			item.content = content.Substring(num3, content.Length - num3);
			list.Add(item);
		}
		if (list.Count == 0)
		{
			list.Add(new CommandToken
			{
				isEndOfCommand = false,
				isArgumentSeparator = false,
				content = ""
			});
		}
		return new CommandLexResult
		{
			tokens = list
		};
	}

	private AutocompleteBuilt BuildAutocompleteEntries(string content, int caretPosition, CommandLineState state)
	{
		AutocompleteBuilt autocompleteBuilt = new AutocompleteBuilt();
		autocompleteBuilt.caretPosition = caretPosition;
		CommandLexResult commandLexResult = CommandLineLex(content);
		List<CommandToken> tokens = commandLexResult.tokens;
		bool flag = true;
		Command command = null;
		int num = commandLexResult.FindFocusedToken(caretPosition);
		CommandAutocomplete commandAutocomplete = new CommandAutocomplete();
		commandAutocomplete.state = state;
		CommandValidator commandValidator = new CommandValidator();
		commandValidator.autocomplete = commandAutocomplete;
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < tokens.Count; i++)
		{
			CommandToken commandToken = tokens[i];
			num2 += commandToken.content.Length;
			bool flag2 = i == num;
			if (commandToken.isArgumentSeparator && flag2)
			{
				autocompleteBuilt.focusedLine = num;
			}
			if (commandToken.isArgumentSeparator)
			{
				autocompleteBuilt.inputFieldContent.Add((commandToken.content, false));
				continue;
			}
			string text = commandToken.contentEscaped();
			bool flag3 = false;
			bool flag4 = true;
			string autocompleteCurrent = text;
			int num4 = i + num3;
			IReadOnlyList<AutocompleteEntry> readOnlyList = Array.Empty<AutocompleteEntry>();
			if (flag)
			{
				command = state.commands.GetValueOrDefault(text);
				if (MayUseCommand(command) != CommandUsageKind.MayUse)
				{
					command = null;
				}
				commandAutocomplete.activeArg = -1;
				commandAutocomplete.args.Clear();
				for (int j = i + 1; j < tokens.Count; j++)
				{
					CommandToken commandToken2 = tokens[j];
					if (commandToken2.isEndOfCommand)
					{
						break;
					}
					if (!commandToken2.isArgumentSeparator)
					{
						commandAutocomplete.args.Add(commandToken2.contentEscaped());
					}
				}
			}
			if (flag && flag2)
			{
				List<AutocompleteEntry> list = new List<AutocompleteEntry>();
				foreach (Command command2 in state.commandList)
				{
					if (MayUseCommand(command2) == CommandUsageKind.MayUse)
					{
						list.Add(new AutocompleteEntry(command2.name, command2.description, command2.wrapping));
					}
				}
				readOnlyList = list;
			}
			if (!flag && command != null && !commandToken.isEndOfCommand && (flag2 || command.validator == null))
			{
				commandAutocomplete.validAutocomplete.Clear();
				commandAutocomplete.wasRejected = false;
				commandAutocomplete.subautocomplete = null;
				commandAutocomplete.caretPosition = caretPosition - (num2 - commandToken.content.Length + 1);
				command.autocomplete(commandAutocomplete);
				flag3 = commandAutocomplete.wasRejected;
				readOnlyList = commandAutocomplete.validAutocomplete;
				AutocompleteBuilt subautocomplete = commandAutocomplete.subautocomplete;
				if (subautocomplete != null && subautocomplete.autocompleteSuggestions.Count > 0)
				{
					readOnlyList = subautocomplete.autocompleteSuggestions;
				}
				if (subautocomplete != null)
				{
					num4 = i + subautocomplete.focusedLine;
					if (commandToken.content.StartsWith("\""))
					{
						autocompleteBuilt.inputFieldContent.Add(("\"", false));
						num4++;
						num3++;
					}
					for (int k = 0; k < subautocomplete.inputFieldContent.Count; k++)
					{
						(string line, bool isRejected) tuple = subautocomplete.inputFieldContent[k];
						string item = tuple.line;
						bool item2 = tuple.isRejected;
						item = item.Replace("\"", "\"\"");
						autocompleteBuilt.inputFieldContent.Add((item, item2));
					}
					if (commandToken.content.Length > 1 && commandToken.content.EndsWith("\""))
					{
						autocompleteBuilt.inputFieldContent.Add(("\"", false));
					}
					autocompleteCurrent = subautocomplete.autocompleteCurrent;
					flag4 = false;
					num3 += subautocomplete.inputFieldContent.Count;
				}
			}
			if (flag2)
			{
				autocompleteBuilt.autocompleteSuggestions = new List<AutocompleteEntry>(readOnlyList);
				autocompleteBuilt.autocompleteCurrent = autocompleteCurrent;
				autocompleteBuilt.focusedLine = num4;
			}
			if (!flag && command != null && command.validator != null)
			{
				readOnlyList = Array.Empty<AutocompleteEntry>();
				commandAutocomplete.wasRejected = false;
				command.validator(commandValidator);
				flag3 = commandAutocomplete.wasRejected;
			}
			if (!flag && command == null)
			{
				flag3 = true;
			}
			if (flag)
			{
				readOnlyList = Array.Empty<AutocompleteEntry>();
				flag3 = command == null;
			}
			bool flag5 = true;
			flag5 &= readOnlyList.Count > 0;
			if (flag5)
			{
				foreach (AutocompleteEntry item3 in readOnlyList)
				{
					if (string.Equals(item3.name, text, StringComparison.OrdinalIgnoreCase))
					{
						flag5 = false;
						break;
					}
				}
			}
			flag5 = flag5 || flag3;
			flag5 &= !commandToken.isEndOfCommand;
			if (flag4)
			{
				autocompleteBuilt.inputFieldContent.Add((commandToken.content, flag5));
			}
			commandAutocomplete.activeArg++;
			flag = false;
			if (commandToken.isEndOfCommand)
			{
				command = null;
				flag = true;
			}
		}
		if (autocompleteBuilt.autocompleteSuggestions.Count == 0 && tokens.Count > 0)
		{
			if (tokens[tokens.Count - 1].isArgumentSeparator && command != null)
			{
				commandAutocomplete.validAutocomplete.Clear();
				command.autocomplete(commandAutocomplete);
				autocompleteBuilt.autocompleteSuggestions = commandAutocomplete.validAutocomplete;
			}
		}
		if (flag)
		{
			List<AutocompleteEntry> list2 = new List<AutocompleteEntry>();
			foreach (Command command3 in state.commandList)
			{
				if (MayUseCommand(command3) == CommandUsageKind.MayUse)
				{
					list2.Add(new AutocompleteEntry(command3.name, command3.description, command3.wrapping));
				}
			}
			autocompleteBuilt.autocompleteSuggestions = list2;
		}
		return autocompleteBuilt;
	}

	private void UpdateAutocomplete(bool updateAutocompleteEntries)
	{
		CommandLineState state = states.Peek();
		string text = inputField.text;
		int caretPosition = inputField.caretPosition;
		bool flag = text != lastTextField || caretPosition != lastCaret;
		if (flag)
		{
			AutocompleteBuilt autocompleteBuilt = BuildAutocompleteEntries(RemoveTags(text), caretPosition, state);
			int selectionStringAnchorPosition = inputField.selectionStringAnchorPosition;
			int selectionAnchorPosition = inputField.selectionAnchorPosition;
			int selectionFocusPosition = inputField.selectionFocusPosition;
			int selectionStringFocusPosition = inputField.selectionStringFocusPosition;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < autocompleteBuilt.inputFieldContent.Count; i++)
			{
				(string line, bool isRejected) tuple = autocompleteBuilt.inputFieldContent[i];
				string item = tuple.line;
				bool item2 = tuple.isRejected;
				bool flag2 = i == autocompleteBuilt.focusedLine;
				bool flag3 = flag2 && string.IsNullOrWhiteSpace(item);
				if (flag2 && !flag3)
				{
					stringBuilder.Append(linkStart);
				}
				if (item2)
				{
					stringBuilder.Append(redTag);
				}
				stringBuilder.Append(item);
				if (item2)
				{
					stringBuilder.Append(colorEndTag);
				}
				if (flag2 && flag3)
				{
					stringBuilder.Append(linkStart);
				}
				if (flag2)
				{
					stringBuilder.Append(linkEnd);
				}
			}
			if (autocompleteBuilt.focusedLine == -1)
			{
				stringBuilder.Append(linkStart);
				stringBuilder.Append(linkEnd);
			}
			string text2 = (lastTextField = stringBuilder.ToString());
			lastCaret = autocompleteBuilt.caretPosition;
			inputField.text = text2;
			inputField.caretPosition = autocompleteBuilt.caretPosition;
			inputField.selectionStringAnchorPosition = selectionStringAnchorPosition;
			inputField.selectionAnchorPosition = selectionAnchorPosition;
			inputField.selectionFocusPosition = selectionFocusPosition;
			inputField.selectionStringFocusPosition = selectionStringFocusPosition;
			if (updateAutocompleteEntries)
			{
				List<int> list = new List<int>();
				List<int> list2 = new List<int>();
				for (int j = 0; j < autocompleteBuilt.autocompleteSuggestions.Count; j++)
				{
					string text3 = autocompleteBuilt.autocompleteSuggestions[j].name;
					if (text3.StartsWith(autocompleteBuilt.autocompleteCurrent, StringComparison.OrdinalIgnoreCase))
					{
						list.Add(j);
					}
					else if (text3.Contains(autocompleteBuilt.autocompleteCurrent, StringComparison.OrdinalIgnoreCase))
					{
						list2.Add(j);
					}
				}
				autocompleteAnyWrapping = false;
				autocompleteEntries.Clear();
				foreach (int item3 in list)
				{
					autocompleteEntries.Add(autocompleteBuilt.autocompleteSuggestions[item3]);
					autocompleteAnyWrapping |= autocompleteBuilt.autocompleteSuggestions[item3].wrapping != null;
				}
				foreach (int item4 in list2)
				{
					autocompleteEntries.Add(autocompleteBuilt.autocompleteSuggestions[item4]);
					autocompleteAnyWrapping |= autocompleteBuilt.autocompleteSuggestions[item4].wrapping != null;
				}
			}
		}
		if (!flag && !autocompleteAnyWrapping)
		{
			return;
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		int count = autocompleteEntries.Count;
		for (int k = 0; k < count; k++)
		{
			AutocompleteEntry autocompleteEntry = autocompleteEntries[k];
			stringBuilder2.Append(linkStart);
			stringBuilder2.Append(autocompleteEntry.name);
			if (autocompleteEntry.desc != null && autocompleteEntry.wrapping == null)
			{
				stringBuilder2.Append(greyTag);
				stringBuilder2.Append("; ");
				stringBuilder2.Append(autocompleteEntry.desc);
				stringBuilder2.Append(colorEndTag);
			}
			if (autocompleteEntry.desc == null && autocompleteEntry.wrapping != null)
			{
				stringBuilder2.Append(greyTag);
				stringBuilder2.Append("; ");
				stringBuilder2.Append(CommandValueAsString(autocompleteEntry.wrapping));
				stringBuilder2.Append(colorEndTag);
			}
			if (autocompleteEntry.desc != null && autocompleteEntry.wrapping != null)
			{
				stringBuilder2.Append(greyTag);
				stringBuilder2.Append("; ");
				stringBuilder2.Append(autocompleteEntry.desc);
				stringBuilder2.Append(". ");
				stringBuilder2.Append(CommandValueAsString(autocompleteEntry.wrapping));
				stringBuilder2.Append(colorEndTag);
			}
			stringBuilder2.Append(linkEnd);
			stringBuilder2.AppendLine();
		}
		autocomplete.text = stringBuilder2.ToString();
	}

	private string RemoveTags(string from)
	{
		return from.Replace(redTag, "").Replace(greenTag, "").Replace(greyTag, "")
			.Replace(colorEndTag, "")
			.Replace(linkStart, "")
			.Replace(linkEnd, "");
	}

	private CommandUsageKind MayUseCommand(Command command)
	{
		CommandUsageKind result = CommandUsageKind.MayUse;
		if (!cheatsEnabled && command != null && command.cheat)
		{
			result = CommandUsageKind.CheatsNotEnabled;
		}
		if (command != null && command.cheat && !CL_GameManager.gamemode.allowCheats)
		{
			result = CommandUsageKind.CheatBlockedByGamemode;
		}
		return result;
	}

	private static string CommandValueAsString(Func<object> functor)
	{
		object obj = functor();
		if (obj is IEnumerable enumerable && obj.GetType() != typeof(string))
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");
			IEnumerator enumerator = enumerable.GetEnumerator();
			if (enumerator.MoveNext())
			{
				bool flag;
				do
				{
					object current = enumerator.Current;
					stringBuilder.Append($"{current}");
					flag = enumerator.MoveNext();
					if (flag)
					{
						stringBuilder.Append(", ");
					}
				}
				while (flag);
			}
			stringBuilder.Append("]");
			obj = stringBuilder.ToString();
		}
		return $"Value: {obj}";
	}

	public List<string> GetCommandHistory()
	{
		return commandHistory;
	}

	public void OnAutocompleteClicked(PointerEventData data)
	{
		int num = TMP_TextUtilities.FindIntersectingLink(autocomplete, data.position, null);
		if (num != -1)
		{
			string text = autocompleteEntries[num].NameEscaped();
			ReplaceTextAtCaretPositionWith(text + " ");
			UpdateAutocomplete(updateAutocompleteEntries: true);
			inputField.ActivateInputField();
		}
	}

	public void OnAutocompleteMove(PointerEventData data)
	{
		if (autocomplete.textInfo.linkCount == 0)
		{
			return;
		}
		if (lastHoveredLinkIndex != -1)
		{
			int linkTextfirstCharacterIndex = autocomplete.textInfo.linkInfo[lastHoveredLinkIndex].linkTextfirstCharacterIndex;
			int linkTextLength = autocomplete.textInfo.linkInfo[lastHoveredLinkIndex].linkTextLength;
			for (int i = 0; i < linkTextLength; i++)
			{
				SetCharacterColor(linkTextfirstCharacterIndex + i, Color.white);
			}
		}
		int num = TMP_TextUtilities.FindIntersectingLink(autocomplete, data.position, null);
		if (num != -1)
		{
			lastHoveredLinkIndex = num;
			int linkTextfirstCharacterIndex2 = autocomplete.textInfo.linkInfo[num].linkTextfirstCharacterIndex;
			int linkTextLength2 = autocomplete.textInfo.linkInfo[num].linkTextLength;
			for (int j = 0; j < linkTextLength2; j++)
			{
				SetCharacterColor(linkTextfirstCharacterIndex2 + j, Color.green);
			}
		}
		autocomplete.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
		void SetCharacterColor(int charID, Color color)
		{
			if (autocomplete.textInfo.characterInfo[charID].isVisible)
			{
				int materialReferenceIndex = autocomplete.textInfo.characterInfo[charID].materialReferenceIndex;
				int vertexIndex = autocomplete.textInfo.characterInfo[charID].vertexIndex;
				Color32[] colors = autocomplete.textInfo.meshInfo[materialReferenceIndex].colors32;
				colors[vertexIndex] = color * autocomplete.textInfo.characterInfo[charID].color;
				colors[vertexIndex + 1] = color * autocomplete.textInfo.characterInfo[charID].color;
				colors[vertexIndex + 2] = color * autocomplete.textInfo.characterInfo[charID].color;
				colors[vertexIndex + 3] = color * autocomplete.textInfo.characterInfo[charID].color;
			}
		}
	}

	private void OnGUI()
	{
		if (memoryDebug)
		{
			memoryWindowRect = GUILayout.Window(GetHashCode(), memoryWindowRect, delegate
			{
				long totalMemory = GC.GetTotalMemory(forceFullCollection: false);
				ThisFrame("GC Memory", ref memoryGc, totalMemory);
				long allocatedMemoryForGraphicsDriver = Profiler.GetAllocatedMemoryForGraphicsDriver();
				ThisFrame("Gpu Driver Memory", ref memoryGpuDriver, allocatedMemoryForGraphicsDriver);
				long totalAllocatedMemoryLong = Profiler.GetTotalAllocatedMemoryLong();
				ThisFrame("Total Allocated by Unity", ref memoryTotalAllocated, totalAllocatedMemoryLong);
				long totalUnusedReservedMemoryLong = Profiler.GetTotalUnusedReservedMemoryLong();
				ThisFrame("Total Unused by Unity", ref memoryTotalUnused, totalUnusedReservedMemoryLong);
				GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
				memoryDebugReset = false;
			}, "Memory Debug");
		}
		void ThisFrame(string name, ref MemoryMemory mem, long newValue)
		{
			GUILayout.Label(name + " " + DarkMachineFunctions.MemoryToString(newValue));
			GUILayout.Label("Delta " + name + " " + DarkMachineFunctions.MemoryToString(newValue - mem.lastFrame));
			GUILayout.Label("Lowest " + name + " " + DarkMachineFunctions.MemoryToString(mem.lowest));
			GUILayout.Space(4f);
			mem.lastFrame = newValue;
			mem.lowest = Math.Min(mem.lowest, newValue);
			if (mem.lowest == 0L)
			{
				mem.lowest = newValue;
			}
			if (memoryDebugReset)
			{
				mem.lowest = 0L;
			}
		}
	}
}
