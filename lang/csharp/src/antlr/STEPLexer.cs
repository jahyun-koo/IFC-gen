//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/ikeough/Documents/IFC-gen/schemas/STEP.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace STEP {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public partial class STEPLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, IntegerLiteral=9, 
		Letter=10, CapitalLetter=11, DateTime=12, PlusMinus=13, Derived=14, BoolLogical=15, 
		Enum=16, RealLiteral=17, DATA=18, ENDSEC=19, FILE_DESCRIPTION=20, FILE_NAME=21, 
		FILE_SCHEMA=22, HEADER=23, Id=24, ISO=25, ISO_END=26, StringLiteral=27, 
		TypeRef=28, Undefined=29, DoubleQuote=30, AnyString=31, NewlineChar=32, 
		WS=33, Comments=34;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "Digit", 
		"Digits", "IntegerLiteral", "Letter", "CapitalLetter", "DateTime", "PlusMinus", 
		"Derived", "BoolLogical", "Enum", "RealLiteral", "DATA", "ENDSEC", "FILE_DESCRIPTION", 
		"FILE_NAME", "FILE_SCHEMA", "HEADER", "Id", "ISO", "ISO_END", "StringLiteral", 
		"TypeRef", "Undefined", "DoubleQuote", "AnyString", "NewlineChar", "WS", 
		"Comments"
	};


	public STEPLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public STEPLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'('", "','", "')'", "'()'", "';'", "'''", "'.'", "'='", null, null, 
		null, null, null, "'*'", null, null, null, "'DATA'", "'ENDSEC'", "'FILE_DESCRIPTION'", 
		"'FILE_NAME'", "'FILE_SCHEMA'", "'HEADER'", null, null, null, null, null, 
		"'$'", "''''"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, "IntegerLiteral", 
		"Letter", "CapitalLetter", "DateTime", "PlusMinus", "Derived", "BoolLogical", 
		"Enum", "RealLiteral", "DATA", "ENDSEC", "FILE_DESCRIPTION", "FILE_NAME", 
		"FILE_SCHEMA", "HEADER", "Id", "ISO", "ISO_END", "StringLiteral", "TypeRef", 
		"Undefined", "DoubleQuote", "AnyString", "NewlineChar", "WS", "Comments"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "STEP.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static STEPLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '$', '\x13C', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', 
		'\t', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', '\a', '\v', 
		'\x61', '\n', '\v', '\f', '\v', '\xE', '\v', '\x64', '\v', '\v', '\x3', 
		'\f', '\x5', '\f', 'g', '\n', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', 
		'\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', 
		'\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', 
		'\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', 
		'\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x5', 
		'\xF', '\x80', '\n', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', 
		'\x3', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', '\x12', '\x3', '\x12', 
		'\x3', '\x12', '\x3', '\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', 
		'\a', '\x13', '\x8F', '\n', '\x13', '\f', '\x13', '\xE', '\x13', '\x92', 
		'\v', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x5', '\x14', 
		'\x97', '\n', '\x14', '\x3', '\x14', '\x3', '\x14', '\x5', '\x14', '\x9B', 
		'\n', '\x14', '\x3', '\x14', '\a', '\x14', '\x9E', '\n', '\x14', '\f', 
		'\x14', '\xE', '\x14', '\xA1', '\v', '\x14', '\x3', '\x14', '\x3', '\x14', 
		'\x5', '\x14', '\xA5', '\n', '\x14', '\x3', '\x14', '\x5', '\x14', '\xA8', 
		'\n', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', 
		'\x3', '\x15', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', 
		'\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x17', '\x3', '\x17', 
		'\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', 
		'\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', 
		'\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', 
		'\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', 
		'\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', 
		'\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', 
		'\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', 
		'\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', 
		'\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1B', 
		'\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', 
		'\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', 
		'\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1E', '\x3', '\x1E', '\a', '\x1E', '\x101', '\n', 
		'\x1E', '\f', '\x1E', '\xE', '\x1E', '\x104', '\v', '\x1E', '\x3', '\x1E', 
		'\x3', '\x1E', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\a', '\x1F', 
		'\x10B', '\n', '\x1F', '\f', '\x1F', '\xE', '\x1F', '\x10E', '\v', '\x1F', 
		'\x3', ' ', '\x3', ' ', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', '\"', 
		'\x3', '\"', '\x3', '\"', '\x5', '\"', '\x118', '\n', '\"', '\a', '\"', 
		'\x11A', '\n', '\"', '\f', '\"', '\xE', '\"', '\x11D', '\v', '\"', '\x3', 
		'\"', '\x3', '\"', '\x3', '#', '\x6', '#', '\x122', '\n', '#', '\r', '#', 
		'\xE', '#', '\x123', '\x3', '#', '\x3', '#', '\x3', '$', '\x6', '$', '\x129', 
		'\n', '$', '\r', '$', '\xE', '$', '\x12A', '\x3', '$', '\x3', '$', '\x3', 
		'%', '\x3', '%', '\x3', '%', '\x3', '%', '\a', '%', '\x133', '\n', '%', 
		'\f', '%', '\xE', '%', '\x136', '\v', '%', '\x3', '%', '\x3', '%', '\x3', 
		'%', '\x3', '%', '\x3', '%', '\x4', '\x11B', '\x134', '\x2', '&', '\x3', 
		'\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', '\r', '\b', 
		'\xF', '\t', '\x11', '\n', '\x13', '\x2', '\x15', '\x2', '\x17', '\v', 
		'\x19', '\f', '\x1B', '\r', '\x1D', '\xE', '\x1F', '\xF', '!', '\x10', 
		'#', '\x11', '%', '\x12', '\'', '\x13', ')', '\x14', '+', '\x15', '-', 
		'\x16', '/', '\x17', '\x31', '\x18', '\x33', '\x19', '\x35', '\x1A', '\x37', 
		'\x1B', '\x39', '\x1C', ';', '\x1D', '=', '\x1E', '?', '\x1F', '\x41', 
		' ', '\x43', '!', '\x45', '\"', 'G', '#', 'I', '$', '\x3', '\x2', '\v', 
		'\x3', '\x2', '\x32', ';', '\x4', '\x2', '\x43', '\\', '\x63', '|', '\x3', 
		'\x2', '\x43', '\\', '\x4', '\x2', '-', '-', '/', '/', '\x4', '\x2', 'H', 
		'H', 'V', 'W', '\x5', '\x2', '\x32', ';', '\x43', '\\', '\x61', '\x61', 
		'\x4', '\x2', 'G', 'G', 'g', 'g', '\x4', '\x2', '\f', '\f', '\xE', '\xF', 
		'\x5', '\x2', '\v', '\f', '\xE', '\xF', '\"', '\"', '\x2', '\x14A', '\x2', 
		'\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\t', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x2', '\r', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x1F', '\x3', '\x2', '\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '#', '\x3', '\x2', '\x2', '\x2', '\x2', '%', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\'', '\x3', '\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '+', '\x3', '\x2', '\x2', '\x2', '\x2', '-', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '/', '\x3', '\x2', '\x2', '\x2', '\x2', '\x31', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x33', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x35', '\x3', '\x2', '\x2', '\x2', '\x2', '\x37', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x39', '\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '=', '\x3', '\x2', '\x2', '\x2', '\x2', '?', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x41', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x43', '\x3', '\x2', '\x2', '\x2', '\x2', '\x45', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'G', '\x3', '\x2', '\x2', '\x2', '\x2', 'I', '\x3', 
		'\x2', '\x2', '\x2', '\x3', 'K', '\x3', '\x2', '\x2', '\x2', '\x5', 'M', 
		'\x3', '\x2', '\x2', '\x2', '\a', 'O', '\x3', '\x2', '\x2', '\x2', '\t', 
		'Q', '\x3', '\x2', '\x2', '\x2', '\v', 'T', '\x3', '\x2', '\x2', '\x2', 
		'\r', 'V', '\x3', '\x2', '\x2', '\x2', '\xF', 'X', '\x3', '\x2', '\x2', 
		'\x2', '\x11', 'Z', '\x3', '\x2', '\x2', '\x2', '\x13', '\\', '\x3', '\x2', 
		'\x2', '\x2', '\x15', '^', '\x3', '\x2', '\x2', '\x2', '\x17', '\x66', 
		'\x3', '\x2', '\x2', '\x2', '\x19', 'j', '\x3', '\x2', '\x2', '\x2', '\x1B', 
		'l', '\x3', '\x2', '\x2', '\x2', '\x1D', 'n', '\x3', '\x2', '\x2', '\x2', 
		'\x1F', '\x83', '\x3', '\x2', '\x2', '\x2', '!', '\x85', '\x3', '\x2', 
		'\x2', '\x2', '#', '\x87', '\x3', '\x2', '\x2', '\x2', '%', '\x8B', '\x3', 
		'\x2', '\x2', '\x2', '\'', '\x96', '\x3', '\x2', '\x2', '\x2', ')', '\xA9', 
		'\x3', '\x2', '\x2', '\x2', '+', '\xAE', '\x3', '\x2', '\x2', '\x2', '-', 
		'\xB5', '\x3', '\x2', '\x2', '\x2', '/', '\xC6', '\x3', '\x2', '\x2', 
		'\x2', '\x31', '\xD0', '\x3', '\x2', '\x2', '\x2', '\x33', '\xDC', '\x3', 
		'\x2', '\x2', '\x2', '\x35', '\xE3', '\x3', '\x2', '\x2', '\x2', '\x37', 
		'\xE6', '\x3', '\x2', '\x2', '\x2', '\x39', '\xF0', '\x3', '\x2', '\x2', 
		'\x2', ';', '\xFE', '\x3', '\x2', '\x2', '\x2', '=', '\x107', '\x3', '\x2', 
		'\x2', '\x2', '?', '\x10F', '\x3', '\x2', '\x2', '\x2', '\x41', '\x111', 
		'\x3', '\x2', '\x2', '\x2', '\x43', '\x114', '\x3', '\x2', '\x2', '\x2', 
		'\x45', '\x121', '\x3', '\x2', '\x2', '\x2', 'G', '\x128', '\x3', '\x2', 
		'\x2', '\x2', 'I', '\x12E', '\x3', '\x2', '\x2', '\x2', 'K', 'L', '\a', 
		'*', '\x2', '\x2', 'L', '\x4', '\x3', '\x2', '\x2', '\x2', 'M', 'N', '\a', 
		'.', '\x2', '\x2', 'N', '\x6', '\x3', '\x2', '\x2', '\x2', 'O', 'P', '\a', 
		'+', '\x2', '\x2', 'P', '\b', '\x3', '\x2', '\x2', '\x2', 'Q', 'R', '\a', 
		'*', '\x2', '\x2', 'R', 'S', '\a', '+', '\x2', '\x2', 'S', '\n', '\x3', 
		'\x2', '\x2', '\x2', 'T', 'U', '\a', '=', '\x2', '\x2', 'U', '\f', '\x3', 
		'\x2', '\x2', '\x2', 'V', 'W', '\a', ')', '\x2', '\x2', 'W', '\xE', '\x3', 
		'\x2', '\x2', '\x2', 'X', 'Y', '\a', '\x30', '\x2', '\x2', 'Y', '\x10', 
		'\x3', '\x2', '\x2', '\x2', 'Z', '[', '\a', '?', '\x2', '\x2', '[', '\x12', 
		'\x3', '\x2', '\x2', '\x2', '\\', ']', '\t', '\x2', '\x2', '\x2', ']', 
		'\x14', '\x3', '\x2', '\x2', '\x2', '^', '\x62', '\x5', '\x13', '\n', 
		'\x2', '_', '\x61', '\x5', '\x13', '\n', '\x2', '`', '_', '\x3', '\x2', 
		'\x2', '\x2', '\x61', '\x64', '\x3', '\x2', '\x2', '\x2', '\x62', '`', 
		'\x3', '\x2', '\x2', '\x2', '\x62', '\x63', '\x3', '\x2', '\x2', '\x2', 
		'\x63', '\x16', '\x3', '\x2', '\x2', '\x2', '\x64', '\x62', '\x3', '\x2', 
		'\x2', '\x2', '\x65', 'g', '\a', '/', '\x2', '\x2', '\x66', '\x65', '\x3', 
		'\x2', '\x2', '\x2', '\x66', 'g', '\x3', '\x2', '\x2', '\x2', 'g', 'h', 
		'\x3', '\x2', '\x2', '\x2', 'h', 'i', '\x5', '\x15', '\v', '\x2', 'i', 
		'\x18', '\x3', '\x2', '\x2', '\x2', 'j', 'k', '\t', '\x3', '\x2', '\x2', 
		'k', '\x1A', '\x3', '\x2', '\x2', '\x2', 'l', 'm', '\t', '\x4', '\x2', 
		'\x2', 'm', '\x1C', '\x3', '\x2', '\x2', '\x2', 'n', 'o', '\a', ')', '\x2', 
		'\x2', 'o', 'p', '\x5', '\x15', '\v', '\x2', 'p', 'q', '\a', '/', '\x2', 
		'\x2', 'q', 'r', '\x5', '\x15', '\v', '\x2', 'r', 's', '\a', '/', '\x2', 
		'\x2', 's', 't', '\x5', '\x15', '\v', '\x2', 't', 'u', '\a', 'V', '\x2', 
		'\x2', 'u', 'v', '\x5', '\x15', '\v', '\x2', 'v', 'w', '\a', '<', '\x2', 
		'\x2', 'w', 'x', '\x5', '\x15', '\v', '\x2', 'x', 'y', '\a', '<', '\x2', 
		'\x2', 'y', '\x7F', '\x5', '\x15', '\v', '\x2', 'z', '{', '\x5', '\x1F', 
		'\x10', '\x2', '{', '|', '\x5', '\x15', '\v', '\x2', '|', '}', '\a', '<', 
		'\x2', '\x2', '}', '~', '\x5', '\x15', '\v', '\x2', '~', '\x80', '\x3', 
		'\x2', '\x2', '\x2', '\x7F', 'z', '\x3', '\x2', '\x2', '\x2', '\x7F', 
		'\x80', '\x3', '\x2', '\x2', '\x2', '\x80', '\x81', '\x3', '\x2', '\x2', 
		'\x2', '\x81', '\x82', '\a', ')', '\x2', '\x2', '\x82', '\x1E', '\x3', 
		'\x2', '\x2', '\x2', '\x83', '\x84', '\t', '\x5', '\x2', '\x2', '\x84', 
		' ', '\x3', '\x2', '\x2', '\x2', '\x85', '\x86', '\a', ',', '\x2', '\x2', 
		'\x86', '\"', '\x3', '\x2', '\x2', '\x2', '\x87', '\x88', '\a', '\x30', 
		'\x2', '\x2', '\x88', '\x89', '\t', '\x6', '\x2', '\x2', '\x89', '\x8A', 
		'\a', '\x30', '\x2', '\x2', '\x8A', '$', '\x3', '\x2', '\x2', '\x2', '\x8B', 
		'\x8C', '\a', '\x30', '\x2', '\x2', '\x8C', '\x90', '\t', '\x4', '\x2', 
		'\x2', '\x8D', '\x8F', '\t', '\a', '\x2', '\x2', '\x8E', '\x8D', '\x3', 
		'\x2', '\x2', '\x2', '\x8F', '\x92', '\x3', '\x2', '\x2', '\x2', '\x90', 
		'\x8E', '\x3', '\x2', '\x2', '\x2', '\x90', '\x91', '\x3', '\x2', '\x2', 
		'\x2', '\x91', '\x93', '\x3', '\x2', '\x2', '\x2', '\x92', '\x90', '\x3', 
		'\x2', '\x2', '\x2', '\x93', '\x94', '\a', '\x30', '\x2', '\x2', '\x94', 
		'&', '\x3', '\x2', '\x2', '\x2', '\x95', '\x97', '\a', '/', '\x2', '\x2', 
		'\x96', '\x95', '\x3', '\x2', '\x2', '\x2', '\x96', '\x97', '\x3', '\x2', 
		'\x2', '\x2', '\x97', '\x98', '\x3', '\x2', '\x2', '\x2', '\x98', '\x9A', 
		'\x5', '\x15', '\v', '\x2', '\x99', '\x9B', '\a', '\x30', '\x2', '\x2', 
		'\x9A', '\x99', '\x3', '\x2', '\x2', '\x2', '\x9A', '\x9B', '\x3', '\x2', 
		'\x2', '\x2', '\x9B', '\x9F', '\x3', '\x2', '\x2', '\x2', '\x9C', '\x9E', 
		'\x5', '\x15', '\v', '\x2', '\x9D', '\x9C', '\x3', '\x2', '\x2', '\x2', 
		'\x9E', '\xA1', '\x3', '\x2', '\x2', '\x2', '\x9F', '\x9D', '\x3', '\x2', 
		'\x2', '\x2', '\x9F', '\xA0', '\x3', '\x2', '\x2', '\x2', '\xA0', '\xA7', 
		'\x3', '\x2', '\x2', '\x2', '\xA1', '\x9F', '\x3', '\x2', '\x2', '\x2', 
		'\xA2', '\xA4', '\t', '\b', '\x2', '\x2', '\xA3', '\xA5', '\a', '/', '\x2', 
		'\x2', '\xA4', '\xA3', '\x3', '\x2', '\x2', '\x2', '\xA4', '\xA5', '\x3', 
		'\x2', '\x2', '\x2', '\xA5', '\xA6', '\x3', '\x2', '\x2', '\x2', '\xA6', 
		'\xA8', '\x5', '\x15', '\v', '\x2', '\xA7', '\xA2', '\x3', '\x2', '\x2', 
		'\x2', '\xA7', '\xA8', '\x3', '\x2', '\x2', '\x2', '\xA8', '(', '\x3', 
		'\x2', '\x2', '\x2', '\xA9', '\xAA', '\a', '\x46', '\x2', '\x2', '\xAA', 
		'\xAB', '\a', '\x43', '\x2', '\x2', '\xAB', '\xAC', '\a', 'V', '\x2', 
		'\x2', '\xAC', '\xAD', '\a', '\x43', '\x2', '\x2', '\xAD', '*', '\x3', 
		'\x2', '\x2', '\x2', '\xAE', '\xAF', '\a', 'G', '\x2', '\x2', '\xAF', 
		'\xB0', '\a', 'P', '\x2', '\x2', '\xB0', '\xB1', '\a', '\x46', '\x2', 
		'\x2', '\xB1', '\xB2', '\a', 'U', '\x2', '\x2', '\xB2', '\xB3', '\a', 
		'G', '\x2', '\x2', '\xB3', '\xB4', '\a', '\x45', '\x2', '\x2', '\xB4', 
		',', '\x3', '\x2', '\x2', '\x2', '\xB5', '\xB6', '\a', 'H', '\x2', '\x2', 
		'\xB6', '\xB7', '\a', 'K', '\x2', '\x2', '\xB7', '\xB8', '\a', 'N', '\x2', 
		'\x2', '\xB8', '\xB9', '\a', 'G', '\x2', '\x2', '\xB9', '\xBA', '\a', 
		'\x61', '\x2', '\x2', '\xBA', '\xBB', '\a', '\x46', '\x2', '\x2', '\xBB', 
		'\xBC', '\a', 'G', '\x2', '\x2', '\xBC', '\xBD', '\a', 'U', '\x2', '\x2', 
		'\xBD', '\xBE', '\a', '\x45', '\x2', '\x2', '\xBE', '\xBF', '\a', 'T', 
		'\x2', '\x2', '\xBF', '\xC0', '\a', 'K', '\x2', '\x2', '\xC0', '\xC1', 
		'\a', 'R', '\x2', '\x2', '\xC1', '\xC2', '\a', 'V', '\x2', '\x2', '\xC2', 
		'\xC3', '\a', 'K', '\x2', '\x2', '\xC3', '\xC4', '\a', 'Q', '\x2', '\x2', 
		'\xC4', '\xC5', '\a', 'P', '\x2', '\x2', '\xC5', '.', '\x3', '\x2', '\x2', 
		'\x2', '\xC6', '\xC7', '\a', 'H', '\x2', '\x2', '\xC7', '\xC8', '\a', 
		'K', '\x2', '\x2', '\xC8', '\xC9', '\a', 'N', '\x2', '\x2', '\xC9', '\xCA', 
		'\a', 'G', '\x2', '\x2', '\xCA', '\xCB', '\a', '\x61', '\x2', '\x2', '\xCB', 
		'\xCC', '\a', 'P', '\x2', '\x2', '\xCC', '\xCD', '\a', '\x43', '\x2', 
		'\x2', '\xCD', '\xCE', '\a', 'O', '\x2', '\x2', '\xCE', '\xCF', '\a', 
		'G', '\x2', '\x2', '\xCF', '\x30', '\x3', '\x2', '\x2', '\x2', '\xD0', 
		'\xD1', '\a', 'H', '\x2', '\x2', '\xD1', '\xD2', '\a', 'K', '\x2', '\x2', 
		'\xD2', '\xD3', '\a', 'N', '\x2', '\x2', '\xD3', '\xD4', '\a', 'G', '\x2', 
		'\x2', '\xD4', '\xD5', '\a', '\x61', '\x2', '\x2', '\xD5', '\xD6', '\a', 
		'U', '\x2', '\x2', '\xD6', '\xD7', '\a', '\x45', '\x2', '\x2', '\xD7', 
		'\xD8', '\a', 'J', '\x2', '\x2', '\xD8', '\xD9', '\a', 'G', '\x2', '\x2', 
		'\xD9', '\xDA', '\a', 'O', '\x2', '\x2', '\xDA', '\xDB', '\a', '\x43', 
		'\x2', '\x2', '\xDB', '\x32', '\x3', '\x2', '\x2', '\x2', '\xDC', '\xDD', 
		'\a', 'J', '\x2', '\x2', '\xDD', '\xDE', '\a', 'G', '\x2', '\x2', '\xDE', 
		'\xDF', '\a', '\x43', '\x2', '\x2', '\xDF', '\xE0', '\a', '\x46', '\x2', 
		'\x2', '\xE0', '\xE1', '\a', 'G', '\x2', '\x2', '\xE1', '\xE2', '\a', 
		'T', '\x2', '\x2', '\xE2', '\x34', '\x3', '\x2', '\x2', '\x2', '\xE3', 
		'\xE4', '\a', '%', '\x2', '\x2', '\xE4', '\xE5', '\x5', '\x15', '\v', 
		'\x2', '\xE5', '\x36', '\x3', '\x2', '\x2', '\x2', '\xE6', '\xE7', '\a', 
		'K', '\x2', '\x2', '\xE7', '\xE8', '\a', 'U', '\x2', '\x2', '\xE8', '\xE9', 
		'\a', 'Q', '\x2', '\x2', '\xE9', '\xEA', '\x3', '\x2', '\x2', '\x2', '\xEA', 
		'\xEB', '\a', '/', '\x2', '\x2', '\xEB', '\xEC', '\x5', '\x15', '\v', 
		'\x2', '\xEC', '\xED', '\a', '/', '\x2', '\x2', '\xED', '\xEE', '\x5', 
		'\x15', '\v', '\x2', '\xEE', '\xEF', '\a', '=', '\x2', '\x2', '\xEF', 
		'\x38', '\x3', '\x2', '\x2', '\x2', '\xF0', '\xF1', '\a', 'G', '\x2', 
		'\x2', '\xF1', '\xF2', '\a', 'P', '\x2', '\x2', '\xF2', '\xF3', '\a', 
		'\x46', '\x2', '\x2', '\xF3', '\xF4', '\a', '/', '\x2', '\x2', '\xF4', 
		'\xF5', '\a', 'K', '\x2', '\x2', '\xF5', '\xF6', '\a', 'U', '\x2', '\x2', 
		'\xF6', '\xF7', '\a', 'Q', '\x2', '\x2', '\xF7', '\xF8', '\x3', '\x2', 
		'\x2', '\x2', '\xF8', '\xF9', '\a', '/', '\x2', '\x2', '\xF9', '\xFA', 
		'\x5', '\x15', '\v', '\x2', '\xFA', '\xFB', '\a', '/', '\x2', '\x2', '\xFB', 
		'\xFC', '\x5', '\x15', '\v', '\x2', '\xFC', '\xFD', '\a', '=', '\x2', 
		'\x2', '\xFD', ':', '\x3', '\x2', '\x2', '\x2', '\xFE', '\x102', '\a', 
		'$', '\x2', '\x2', '\xFF', '\x101', '\x5', '\x19', '\r', '\x2', '\x100', 
		'\xFF', '\x3', '\x2', '\x2', '\x2', '\x101', '\x104', '\x3', '\x2', '\x2', 
		'\x2', '\x102', '\x100', '\x3', '\x2', '\x2', '\x2', '\x102', '\x103', 
		'\x3', '\x2', '\x2', '\x2', '\x103', '\x105', '\x3', '\x2', '\x2', '\x2', 
		'\x104', '\x102', '\x3', '\x2', '\x2', '\x2', '\x105', '\x106', '\a', 
		'$', '\x2', '\x2', '\x106', '<', '\x3', '\x2', '\x2', '\x2', '\x107', 
		'\x10C', '\x5', '\x1B', '\xE', '\x2', '\x108', '\x10B', '\x5', '\x1B', 
		'\xE', '\x2', '\x109', '\x10B', '\x5', '\x13', '\n', '\x2', '\x10A', '\x108', 
		'\x3', '\x2', '\x2', '\x2', '\x10A', '\x109', '\x3', '\x2', '\x2', '\x2', 
		'\x10B', '\x10E', '\x3', '\x2', '\x2', '\x2', '\x10C', '\x10A', '\x3', 
		'\x2', '\x2', '\x2', '\x10C', '\x10D', '\x3', '\x2', '\x2', '\x2', '\x10D', 
		'>', '\x3', '\x2', '\x2', '\x2', '\x10E', '\x10C', '\x3', '\x2', '\x2', 
		'\x2', '\x10F', '\x110', '\a', '&', '\x2', '\x2', '\x110', '@', '\x3', 
		'\x2', '\x2', '\x2', '\x111', '\x112', '\a', ')', '\x2', '\x2', '\x112', 
		'\x113', '\a', ')', '\x2', '\x2', '\x113', '\x42', '\x3', '\x2', '\x2', 
		'\x2', '\x114', '\x11B', '\a', ')', '\x2', '\x2', '\x115', '\x117', '\v', 
		'\x2', '\x2', '\x2', '\x116', '\x118', '\x5', '\x41', '!', '\x2', '\x117', 
		'\x116', '\x3', '\x2', '\x2', '\x2', '\x117', '\x118', '\x3', '\x2', '\x2', 
		'\x2', '\x118', '\x11A', '\x3', '\x2', '\x2', '\x2', '\x119', '\x115', 
		'\x3', '\x2', '\x2', '\x2', '\x11A', '\x11D', '\x3', '\x2', '\x2', '\x2', 
		'\x11B', '\x11C', '\x3', '\x2', '\x2', '\x2', '\x11B', '\x119', '\x3', 
		'\x2', '\x2', '\x2', '\x11C', '\x11E', '\x3', '\x2', '\x2', '\x2', '\x11D', 
		'\x11B', '\x3', '\x2', '\x2', '\x2', '\x11E', '\x11F', '\a', ')', '\x2', 
		'\x2', '\x11F', '\x44', '\x3', '\x2', '\x2', '\x2', '\x120', '\x122', 
		'\t', '\t', '\x2', '\x2', '\x121', '\x120', '\x3', '\x2', '\x2', '\x2', 
		'\x122', '\x123', '\x3', '\x2', '\x2', '\x2', '\x123', '\x121', '\x3', 
		'\x2', '\x2', '\x2', '\x123', '\x124', '\x3', '\x2', '\x2', '\x2', '\x124', 
		'\x125', '\x3', '\x2', '\x2', '\x2', '\x125', '\x126', '\b', '#', '\x2', 
		'\x2', '\x126', '\x46', '\x3', '\x2', '\x2', '\x2', '\x127', '\x129', 
		'\t', '\n', '\x2', '\x2', '\x128', '\x127', '\x3', '\x2', '\x2', '\x2', 
		'\x129', '\x12A', '\x3', '\x2', '\x2', '\x2', '\x12A', '\x128', '\x3', 
		'\x2', '\x2', '\x2', '\x12A', '\x12B', '\x3', '\x2', '\x2', '\x2', '\x12B', 
		'\x12C', '\x3', '\x2', '\x2', '\x2', '\x12C', '\x12D', '\b', '$', '\x2', 
		'\x2', '\x12D', 'H', '\x3', '\x2', '\x2', '\x2', '\x12E', '\x12F', '\a', 
		'\x31', '\x2', '\x2', '\x12F', '\x130', '\a', ',', '\x2', '\x2', '\x130', 
		'\x134', '\x3', '\x2', '\x2', '\x2', '\x131', '\x133', '\v', '\x2', '\x2', 
		'\x2', '\x132', '\x131', '\x3', '\x2', '\x2', '\x2', '\x133', '\x136', 
		'\x3', '\x2', '\x2', '\x2', '\x134', '\x135', '\x3', '\x2', '\x2', '\x2', 
		'\x134', '\x132', '\x3', '\x2', '\x2', '\x2', '\x135', '\x137', '\x3', 
		'\x2', '\x2', '\x2', '\x136', '\x134', '\x3', '\x2', '\x2', '\x2', '\x137', 
		'\x138', '\a', ',', '\x2', '\x2', '\x138', '\x139', '\a', '\x31', '\x2', 
		'\x2', '\x139', '\x13A', '\x3', '\x2', '\x2', '\x2', '\x13A', '\x13B', 
		'\b', '%', '\x2', '\x2', '\x13B', 'J', '\x3', '\x2', '\x2', '\x2', '\x15', 
		'\x2', '\x62', '\x66', '\x7F', '\x8E', '\x90', '\x96', '\x9A', '\x9F', 
		'\xA4', '\xA7', '\x102', '\x10A', '\x10C', '\x117', '\x11B', '\x123', 
		'\x12A', '\x134', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace STEP
