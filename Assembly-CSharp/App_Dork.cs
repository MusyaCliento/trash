using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

public class App_Dork : MonoBehaviour
{
	internal enum DorkScopeKind
	{
		Using = 0,
		Function = 1,
		FunctionParameterName = 2,
		Command = 3,
		Expression = 4
	}

	internal class DorkScope
	{
		public string name;

		public DorkScopeKind kind;

		public List<DorkScope> scopes = new List<DorkScope>();

		public string error;
	}

	internal class DorkTokens
	{
		public string content;

		public List<DorkToken> tokens = new List<DorkToken>();

		public DorkToken Token(int index)
		{
			DorkToken result = default(DorkToken);
			if (index >= 0 && index < tokens.Count)
			{
				return tokens[index];
			}
			return result;
		}
	}

	internal enum DorkTokenKind
	{
		Invalid = 0,
		Ident = 1,
		Comment = 2,
		Whitespace = 3,
		StringLiteral = 4,
		Comma = 5,
		Dot = 6,
		ParenOpen = 7,
		ParenClose = 8,
		CurlyOpen = 9,
		CurlyClose = 10,
		SquareOpen = 11,
		SquareClose = 12,
		Equals = 13,
		Slash = 14,
		Pipe = 15,
		Pound = 16,
		DoubleEquals = 17,
		ExclamationMark = 18,
		And = 19
	}

	internal struct DorkToken
	{
		public DorkTokenKind kind;

		public DorkTokens res;

		public int contentStart;

		public int contentEnd;

		public string overrideContent;

		public string error;

		public readonly string Content()
		{
			return overrideContent;
		}
	}

	public string filepath;

	public TMP_Text display;

	private void Awake()
	{
		ParseText(File.ReadAllText(filepath).Replace(Environment.NewLine, "\n"));
		StringBuilder stringBuilder = new StringBuilder();
		display.text = stringBuilder.ToString();
	}

	internal static DorkScope CreateAstFromTokens(DorkTokens tokens)
	{
		DorkScope dorkScope = new DorkScope();
		int index = 0;
		FillDorkScope(dorkScope, tokens, ref index);
		return dorkScope;
	}

	private static bool IsDorkKeyword(string thing)
	{
		return false;
	}

	private static void FillDorkScope(DorkScope scope, DorkTokens tokens, ref int index)
	{
		while (index < tokens.tokens.Count)
		{
			DorkScope dorkScope = new DorkScope();
			DorkToken dorkToken = tokens.Token(index++);
			if (dorkToken.kind != DorkTokenKind.Ident)
			{
				dorkScope.error = "Expected ident";
			}
			else if (dorkToken.Content() == "use")
			{
				dorkScope.kind = DorkScopeKind.Using;
				DorkToken dorkToken2 = tokens.Token(index);
				if (dorkToken2.kind != DorkTokenKind.Ident)
				{
					dorkScope.error = "Using scope expects name identifier";
				}
				else if (IsDorkKeyword(dorkToken2.Content()))
				{
					dorkScope.error = "Cannot use reserved keyword as scope path";
				}
				else
				{
					dorkScope.name = dorkToken2.Content();
					DorkToken dorkToken3 = tokens.Token(++index);
					if (dorkToken3.kind == DorkTokenKind.Ident && dorkToken3.Content() == "as")
					{
						index++;
						DorkToken dorkToken4 = tokens.Token(index);
						if (dorkToken4.kind != DorkTokenKind.Ident)
						{
							dorkScope.error = "Aliasing using scope expects named identifier";
						}
						else if (!IsDorkKeyword(dorkToken4.Content()))
						{
							dorkScope.error = "Using scope alias cannot be reserved keyword";
						}
						else
						{
							index++;
							dorkScope.name = dorkToken4.Content();
						}
					}
				}
			}
			else if (dorkToken.Content() == "func")
			{
				dorkScope.kind = DorkScopeKind.Function;
				DorkToken dorkToken5 = tokens.Token(index);
				if (dorkToken5.kind != DorkTokenKind.Ident)
				{
					dorkScope.error = "Function declaration expects function name";
				}
				else if (IsDorkKeyword(dorkToken5.Content()))
				{
					dorkScope.error = "Function name cannot be reserved keyword";
				}
				else
				{
					dorkScope.name = dorkToken5.Content();
					if (tokens.Token(++index).kind != DorkTokenKind.ParenOpen)
					{
						dorkScope.error = "Syntax error: Expected parentheses.";
					}
					else
					{
						bool flag = tokens.Token(++index).kind != DorkTokenKind.ParenClose;
						while (flag)
						{
							DorkToken dorkToken6 = tokens.Token(index);
							if (dorkToken6.kind != DorkTokenKind.Ident)
							{
								dorkScope.error = "Function prototype expects either name identifier or closing parentheses.";
								break;
							}
							if (IsDorkKeyword(dorkToken6.Content()))
							{
								dorkScope.error = "Parameter name cannot shadow reserved keyword";
								break;
							}
							DorkScope dorkScope2 = new DorkScope();
							dorkScope2.name = dorkToken6.Content();
							dorkScope2.kind = DorkScopeKind.FunctionParameterName;
							dorkScope.scopes.Add(dorkScope2);
							DorkToken dorkToken7 = tokens.Token(++index);
							if (dorkToken7.kind != DorkTokenKind.Comma)
							{
								dorkScope.error = "Function prototype expects either closing parens or ";
								break;
							}
							flag = dorkToken7.kind == DorkTokenKind.Comma;
							index++;
						}
					}
				}
			}
			else if (dorkToken.Content() == "command")
			{
				dorkScope.kind = DorkScopeKind.Command;
			}
			else
			{
				dorkScope.kind = DorkScopeKind.Expression;
			}
			scope.scopes.Add(dorkScope);
		}
	}

	internal static DorkTokens ParseText(string from)
	{
		DorkTokens dorkTokens = new DorkTokens();
		dorkTokens.content = from;
		int curIdx = 0;
		char value;
		while (PeekNext(out value))
		{
			DorkToken item = new DorkToken
			{
				contentStart = curIdx
			};
			curIdx++;
			if (char.IsWhiteSpace(value))
			{
				item.kind = DorkTokenKind.Whitespace;
				char value2;
				while (PeekNext(out value2) && char.IsWhiteSpace(value2))
				{
					curIdx++;
				}
			}
			else if (value == '/' && ConsumeIfEq("/"))
			{
				item.kind = DorkTokenKind.Comment;
				char value3;
				while (PeekNext(out value3) && value3 == '\n')
				{
					curIdx++;
				}
			}
			else if (value == '"' && ConsumeIfEq("\"\""))
			{
				item.kind = DorkTokenKind.StringLiteral;
				StringBuilder stringBuilder = new StringBuilder();
				char c = '\0';
				PeekNext(out var value4);
				while (ConsumeIfNe("\"\"\""))
				{
					bool flag = false;
					while (value4 == '\n')
					{
						flag = true;
						curIdx++;
						while (PeekNext(out value4) && char.IsWhiteSpace(value4))
						{
							curIdx++;
						}
					}
					if (flag)
					{
						curIdx++;
					}
					if (flag && !char.IsWhiteSpace(c))
					{
						stringBuilder.Append(' ');
					}
					if (value4 == '\\' && PeekNext(out var value5) && value5 == 'n')
					{
						stringBuilder.Append('\n');
						curIdx++;
					}
					else
					{
						stringBuilder.Append(value4);
					}
					c = value4;
					PeekNext(out value4);
				}
				item.overrideContent = stringBuilder.ToString();
			}
			else if (value == '"')
			{
				item.kind = DorkTokenKind.StringLiteral;
				while (ConsumeIfNe("\""))
				{
				}
				string text = from;
				int num = item.contentStart + 1;
				item.overrideContent = text.Substring(num, curIdx - 1 - num);
			}
			else if (value == ',')
			{
				item.kind = DorkTokenKind.Comma;
			}
			else if (value == '.')
			{
				item.kind = DorkTokenKind.Dot;
			}
			else if (value == '(')
			{
				item.kind = DorkTokenKind.ParenOpen;
			}
			else if (value == ')')
			{
				item.kind = DorkTokenKind.ParenClose;
			}
			else if (value == '{')
			{
				item.kind = DorkTokenKind.CurlyOpen;
			}
			else if (value == '}')
			{
				item.kind = DorkTokenKind.CurlyClose;
			}
			else if (value == '[')
			{
				item.kind = DorkTokenKind.SquareOpen;
			}
			else if (value == ']')
			{
				item.kind = DorkTokenKind.SquareClose;
			}
			else if (value == '=' && ConsumeIfEq("="))
			{
				item.kind = DorkTokenKind.DoubleEquals;
			}
			else if (value == '=')
			{
				item.kind = DorkTokenKind.Equals;
			}
			else if (value == '&' && ConsumeIfEq("&"))
			{
				item.kind = DorkTokenKind.And;
			}
			else
			{
				switch (value)
				{
				case '/':
					item.kind = DorkTokenKind.Slash;
					break;
				case '|':
					item.kind = DorkTokenKind.Pipe;
					break;
				case '#':
					item.kind = DorkTokenKind.Pound;
					break;
				case '!':
					item.kind = DorkTokenKind.ExclamationMark;
					break;
				default:
				{
					item.kind = DorkTokenKind.Ident;
					char value6;
					while (PeekNext(out value6) && (0u | ((value6 == '/') ? 1u : 0u) | ((value6 == '"') ? 1u : 0u) | ((value6 == ',') ? 1u : 0u) | ((value6 == '.') ? 1u : 0u) | ((value6 == '(') ? 1u : 0u) | ((value6 == ')') ? 1u : 0u) | ((value6 == '{') ? 1u : 0u) | ((value6 == '}') ? 1u : 0u) | ((value6 == '[') ? 1u : 0u) | ((value6 == ']') ? 1u : 0u) | ((value6 == '=') ? 1u : 0u) | ((value6 == '|') ? 1u : 0u) | ((value6 == '#') ? 1u : 0u) | ((value6 == '!') ? 1u : 0u) | (char.IsWhiteSpace(value6) ? 1u : 0u)) == 0)
					{
						curIdx++;
					}
					break;
				}
				}
			}
			item.contentEnd = curIdx;
			item.res = dorkTokens;
			if (item.overrideContent == null)
			{
				string text2 = from;
				int num = item.contentStart;
				item.overrideContent = text2.Substring(num, item.contentEnd - num);
			}
			dorkTokens.tokens.Add(item);
		}
		return dorkTokens;
		bool ConsumeIfEq(ReadOnlySpan<char> toWhat)
		{
			if (curIdx + toWhat.Length > from.Length)
			{
				return false;
			}
			for (int i = 0; i < toWhat.Length; i++)
			{
				if (from[curIdx + i] != toWhat[i])
				{
					return false;
				}
			}
			curIdx += toWhat.Length;
			return true;
		}
		bool ConsumeIfNe(ReadOnlySpan<char> toWhat)
		{
			if (curIdx + toWhat.Length > from.Length)
			{
				return false;
			}
			bool flag2 = true;
			for (int i = 0; i < toWhat.Length; i++)
			{
				flag2 &= from[curIdx + i] == toWhat[i];
			}
			if (flag2)
			{
				curIdx += toWhat.Length;
			}
			else
			{
				curIdx++;
			}
			return !flag2;
		}
		bool PeekNext(out char reference)
		{
			bool result = false;
			reference = '\0';
			if (curIdx < from.Length)
			{
				reference = from[curIdx];
				result = true;
			}
			return result;
		}
	}
}
