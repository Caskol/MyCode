//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.12.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from pascal.g4 by ANTLR 4.12.0

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
[System.CLSCompliant(false)]
public partial class pascalLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		AND=1, ARRAY=2, BEGIN=3, BOOLEAN=4, CASE=5, CHAR=6, CHR=7, CONST=8, DIV=9, 
		DO=10, DOWNTO=11, ELSE=12, END=13, FILE=14, FOR=15, FUNCTION=16, GOTO=17, 
		IF=18, IN=19, INTEGER=20, LABEL=21, MOD=22, NIL=23, NOT=24, OF=25, OR=26, 
		PACKED=27, PROCEDURE=28, PROGRAM=29, REAL=30, RECORD=31, REPEAT=32, SET=33, 
		THEN=34, TO=35, TYPE=36, UNTIL=37, VAR=38, WHILE=39, WITH=40, PLUS=41, 
		MINUS=42, STAR=43, SLASH=44, ASSIGN=45, COMMA=46, SEMI=47, COLON=48, EQUAL=49, 
		NOT_EQUAL=50, LT=51, LE=52, GE=53, GT=54, LPAREN=55, RPAREN=56, LBRACK=57, 
		LBRACK2=58, RBRACK=59, RBRACK2=60, POINTER=61, AT=62, DOT=63, DOTDOT=64, 
		LCURLY=65, RCURLY=66, UNIT=67, INTERFACE=68, USES=69, STRING=70, IMPLEMENTATION=71, 
		TRUE=72, FALSE=73, WS=74, COMMENT_1=75, COMMENT_2=76, IDENT=77, STRING_LITERAL=78, 
		NUM_INT=79, NUM_REAL=80;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"AND", "ARRAY", "BEGIN", "BOOLEAN", "CASE", "CHAR", "CHR", "CONST", "DIV", 
		"DO", "DOWNTO", "ELSE", "END", "FILE", "FOR", "FUNCTION", "GOTO", "IF", 
		"IN", "INTEGER", "LABEL", "MOD", "NIL", "NOT", "OF", "OR", "PACKED", "PROCEDURE", 
		"PROGRAM", "REAL", "RECORD", "REPEAT", "SET", "THEN", "TO", "TYPE", "UNTIL", 
		"VAR", "WHILE", "WITH", "PLUS", "MINUS", "STAR", "SLASH", "ASSIGN", "COMMA", 
		"SEMI", "COLON", "EQUAL", "NOT_EQUAL", "LT", "LE", "GE", "GT", "LPAREN", 
		"RPAREN", "LBRACK", "LBRACK2", "RBRACK", "RBRACK2", "POINTER", "AT", "DOT", 
		"DOTDOT", "LCURLY", "RCURLY", "UNIT", "INTERFACE", "USES", "STRING", "IMPLEMENTATION", 
		"TRUE", "FALSE", "WS", "COMMENT_1", "COMMENT_2", "IDENT", "STRING_LITERAL", 
		"NUM_INT", "NUM_REAL", "EXPONENT"
	};


	public pascalLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public pascalLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'AND'", "'ARRAY'", "'BEGIN'", "'BOOLEAN'", "'CASE'", "'CHAR'", 
		"'CHR'", "'CONST'", "'DIV'", "'DO'", "'DOWNTO'", "'ELSE'", "'END'", "'FILE'", 
		"'FOR'", "'FUNCTION'", "'GOTO'", "'IF'", "'IN'", "'INTEGER'", "'LABEL'", 
		"'MOD'", "'NIL'", "'NOT'", "'OF'", "'OR'", "'PACKED'", "'PROCEDURE'", 
		"'PROGRAM'", "'REAL'", "'RECORD'", "'REPEAT'", "'SET'", "'THEN'", "'TO'", 
		"'TYPE'", "'UNTIL'", "'VAR'", "'WHILE'", "'WITH'", "'+'", "'-'", "'*'", 
		"'/'", "':='", "','", "';'", "':'", "'='", "'<>'", "'<'", "'<='", "'>='", 
		"'>'", "'('", "')'", "'['", "'(.'", "']'", "'.)'", "'^'", "'@'", "'.'", 
		"'..'", "'{'", "'}'", "'UNIT'", "'INTERFACE'", "'USES'", "'STRING'", "'IMPLEMENTATION'", 
		"'TRUE'", "'FALSE'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "AND", "ARRAY", "BEGIN", "BOOLEAN", "CASE", "CHAR", "CHR", "CONST", 
		"DIV", "DO", "DOWNTO", "ELSE", "END", "FILE", "FOR", "FUNCTION", "GOTO", 
		"IF", "IN", "INTEGER", "LABEL", "MOD", "NIL", "NOT", "OF", "OR", "PACKED", 
		"PROCEDURE", "PROGRAM", "REAL", "RECORD", "REPEAT", "SET", "THEN", "TO", 
		"TYPE", "UNTIL", "VAR", "WHILE", "WITH", "PLUS", "MINUS", "STAR", "SLASH", 
		"ASSIGN", "COMMA", "SEMI", "COLON", "EQUAL", "NOT_EQUAL", "LT", "LE", 
		"GE", "GT", "LPAREN", "RPAREN", "LBRACK", "LBRACK2", "RBRACK", "RBRACK2", 
		"POINTER", "AT", "DOT", "DOTDOT", "LCURLY", "RCURLY", "UNIT", "INTERFACE", 
		"USES", "STRING", "IMPLEMENTATION", "TRUE", "FALSE", "WS", "COMMENT_1", 
		"COMMENT_2", "IDENT", "STRING_LITERAL", "NUM_INT", "NUM_REAL"
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

	public override string GrammarFileName { get { return "pascal.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static pascalLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,80,565,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,2,46,7,46,2,47,7,47,2,48,7,48,2,49,
		7,49,2,50,7,50,2,51,7,51,2,52,7,52,2,53,7,53,2,54,7,54,2,55,7,55,2,56,
		7,56,2,57,7,57,2,58,7,58,2,59,7,59,2,60,7,60,2,61,7,61,2,62,7,62,2,63,
		7,63,2,64,7,64,2,65,7,65,2,66,7,66,2,67,7,67,2,68,7,68,2,69,7,69,2,70,
		7,70,2,71,7,71,2,72,7,72,2,73,7,73,2,74,7,74,2,75,7,75,2,76,7,76,2,77,
		7,77,2,78,7,78,2,79,7,79,2,80,7,80,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,
		1,1,1,2,1,2,1,2,1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,
		4,1,4,1,4,1,5,1,5,1,5,1,5,1,5,1,6,1,6,1,6,1,6,1,7,1,7,1,7,1,7,1,7,1,7,
		1,8,1,8,1,8,1,8,1,9,1,9,1,9,1,10,1,10,1,10,1,10,1,10,1,10,1,10,1,11,1,
		11,1,11,1,11,1,11,1,12,1,12,1,12,1,12,1,13,1,13,1,13,1,13,1,13,1,14,1,
		14,1,14,1,14,1,15,1,15,1,15,1,15,1,15,1,15,1,15,1,15,1,15,1,16,1,16,1,
		16,1,16,1,16,1,17,1,17,1,17,1,18,1,18,1,18,1,19,1,19,1,19,1,19,1,19,1,
		19,1,19,1,19,1,20,1,20,1,20,1,20,1,20,1,20,1,21,1,21,1,21,1,21,1,22,1,
		22,1,22,1,22,1,23,1,23,1,23,1,23,1,24,1,24,1,24,1,25,1,25,1,25,1,26,1,
		26,1,26,1,26,1,26,1,26,1,26,1,27,1,27,1,27,1,27,1,27,1,27,1,27,1,27,1,
		27,1,27,1,28,1,28,1,28,1,28,1,28,1,28,1,28,1,28,1,29,1,29,1,29,1,29,1,
		29,1,30,1,30,1,30,1,30,1,30,1,30,1,30,1,31,1,31,1,31,1,31,1,31,1,31,1,
		31,1,32,1,32,1,32,1,32,1,33,1,33,1,33,1,33,1,33,1,34,1,34,1,34,1,35,1,
		35,1,35,1,35,1,35,1,36,1,36,1,36,1,36,1,36,1,36,1,37,1,37,1,37,1,37,1,
		38,1,38,1,38,1,38,1,38,1,38,1,39,1,39,1,39,1,39,1,39,1,40,1,40,1,41,1,
		41,1,42,1,42,1,43,1,43,1,44,1,44,1,44,1,45,1,45,1,46,1,46,1,47,1,47,1,
		48,1,48,1,49,1,49,1,49,1,50,1,50,1,51,1,51,1,51,1,52,1,52,1,52,1,53,1,
		53,1,54,1,54,1,55,1,55,1,56,1,56,1,57,1,57,1,57,1,58,1,58,1,59,1,59,1,
		59,1,60,1,60,1,61,1,61,1,62,1,62,1,63,1,63,1,63,1,64,1,64,1,65,1,65,1,
		66,1,66,1,66,1,66,1,66,1,67,1,67,1,67,1,67,1,67,1,67,1,67,1,67,1,67,1,
		67,1,68,1,68,1,68,1,68,1,68,1,69,1,69,1,69,1,69,1,69,1,69,1,69,1,70,1,
		70,1,70,1,70,1,70,1,70,1,70,1,70,1,70,1,70,1,70,1,70,1,70,1,70,1,70,1,
		71,1,71,1,71,1,71,1,71,1,72,1,72,1,72,1,72,1,72,1,72,1,73,1,73,1,73,1,
		73,1,74,1,74,1,74,1,74,5,74,494,8,74,10,74,12,74,497,9,74,1,74,1,74,1,
		74,1,74,1,74,1,75,1,75,5,75,506,8,75,10,75,12,75,509,9,75,1,75,1,75,1,
		75,1,75,1,76,1,76,5,76,517,8,76,10,76,12,76,520,9,76,1,77,1,77,1,77,1,
		77,5,77,526,8,77,10,77,12,77,529,9,77,1,77,1,77,1,78,4,78,534,8,78,11,
		78,12,78,535,1,79,4,79,539,8,79,11,79,12,79,540,1,79,1,79,4,79,545,8,79,
		11,79,12,79,546,1,79,3,79,550,8,79,3,79,552,8,79,1,79,3,79,555,8,79,1,
		80,1,80,3,80,559,8,80,1,80,4,80,562,8,80,11,80,12,80,563,2,495,507,0,81,
		1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,
		29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,22,45,23,47,24,49,25,51,26,
		53,27,55,28,57,29,59,30,61,31,63,32,65,33,67,34,69,35,71,36,73,37,75,38,
		77,39,79,40,81,41,83,42,85,43,87,44,89,45,91,46,93,47,95,48,97,49,99,50,
		101,51,103,52,105,53,107,54,109,55,111,56,113,57,115,58,117,59,119,60,
		121,61,123,62,125,63,127,64,129,65,131,66,133,67,135,68,137,69,139,70,
		141,71,143,72,145,73,147,74,149,75,151,76,153,77,155,78,157,79,159,80,
		161,0,1,0,27,2,0,65,65,97,97,2,0,78,78,110,110,2,0,68,68,100,100,2,0,82,
		82,114,114,2,0,89,89,121,121,2,0,66,66,98,98,2,0,69,69,101,101,2,0,71,
		71,103,103,2,0,73,73,105,105,2,0,79,79,111,111,2,0,76,76,108,108,2,0,67,
		67,99,99,2,0,83,83,115,115,2,0,72,72,104,104,2,0,84,84,116,116,2,0,86,
		86,118,118,2,0,87,87,119,119,2,0,70,70,102,102,2,0,85,85,117,117,2,0,77,
		77,109,109,2,0,80,80,112,112,2,0,75,75,107,107,3,0,9,10,13,13,32,32,2,
		0,65,90,97,122,4,0,48,57,65,90,95,95,97,122,1,0,39,39,2,0,43,43,45,45,
		576,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,
		0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,
		0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,
		1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,
		0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,
		1,0,0,0,0,57,1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,0,0,63,1,0,0,0,0,65,1,0,0,
		0,0,67,1,0,0,0,0,69,1,0,0,0,0,71,1,0,0,0,0,73,1,0,0,0,0,75,1,0,0,0,0,77,
		1,0,0,0,0,79,1,0,0,0,0,81,1,0,0,0,0,83,1,0,0,0,0,85,1,0,0,0,0,87,1,0,0,
		0,0,89,1,0,0,0,0,91,1,0,0,0,0,93,1,0,0,0,0,95,1,0,0,0,0,97,1,0,0,0,0,99,
		1,0,0,0,0,101,1,0,0,0,0,103,1,0,0,0,0,105,1,0,0,0,0,107,1,0,0,0,0,109,
		1,0,0,0,0,111,1,0,0,0,0,113,1,0,0,0,0,115,1,0,0,0,0,117,1,0,0,0,0,119,
		1,0,0,0,0,121,1,0,0,0,0,123,1,0,0,0,0,125,1,0,0,0,0,127,1,0,0,0,0,129,
		1,0,0,0,0,131,1,0,0,0,0,133,1,0,0,0,0,135,1,0,0,0,0,137,1,0,0,0,0,139,
		1,0,0,0,0,141,1,0,0,0,0,143,1,0,0,0,0,145,1,0,0,0,0,147,1,0,0,0,0,149,
		1,0,0,0,0,151,1,0,0,0,0,153,1,0,0,0,0,155,1,0,0,0,0,157,1,0,0,0,0,159,
		1,0,0,0,1,163,1,0,0,0,3,167,1,0,0,0,5,173,1,0,0,0,7,179,1,0,0,0,9,187,
		1,0,0,0,11,192,1,0,0,0,13,197,1,0,0,0,15,201,1,0,0,0,17,207,1,0,0,0,19,
		211,1,0,0,0,21,214,1,0,0,0,23,221,1,0,0,0,25,226,1,0,0,0,27,230,1,0,0,
		0,29,235,1,0,0,0,31,239,1,0,0,0,33,248,1,0,0,0,35,253,1,0,0,0,37,256,1,
		0,0,0,39,259,1,0,0,0,41,267,1,0,0,0,43,273,1,0,0,0,45,277,1,0,0,0,47,281,
		1,0,0,0,49,285,1,0,0,0,51,288,1,0,0,0,53,291,1,0,0,0,55,298,1,0,0,0,57,
		308,1,0,0,0,59,316,1,0,0,0,61,321,1,0,0,0,63,328,1,0,0,0,65,335,1,0,0,
		0,67,339,1,0,0,0,69,344,1,0,0,0,71,347,1,0,0,0,73,352,1,0,0,0,75,358,1,
		0,0,0,77,362,1,0,0,0,79,368,1,0,0,0,81,373,1,0,0,0,83,375,1,0,0,0,85,377,
		1,0,0,0,87,379,1,0,0,0,89,381,1,0,0,0,91,384,1,0,0,0,93,386,1,0,0,0,95,
		388,1,0,0,0,97,390,1,0,0,0,99,392,1,0,0,0,101,395,1,0,0,0,103,397,1,0,
		0,0,105,400,1,0,0,0,107,403,1,0,0,0,109,405,1,0,0,0,111,407,1,0,0,0,113,
		409,1,0,0,0,115,411,1,0,0,0,117,414,1,0,0,0,119,416,1,0,0,0,121,419,1,
		0,0,0,123,421,1,0,0,0,125,423,1,0,0,0,127,425,1,0,0,0,129,428,1,0,0,0,
		131,430,1,0,0,0,133,432,1,0,0,0,135,437,1,0,0,0,137,447,1,0,0,0,139,452,
		1,0,0,0,141,459,1,0,0,0,143,474,1,0,0,0,145,479,1,0,0,0,147,485,1,0,0,
		0,149,489,1,0,0,0,151,503,1,0,0,0,153,514,1,0,0,0,155,521,1,0,0,0,157,
		533,1,0,0,0,159,538,1,0,0,0,161,556,1,0,0,0,163,164,7,0,0,0,164,165,7,
		1,0,0,165,166,7,2,0,0,166,2,1,0,0,0,167,168,7,0,0,0,168,169,7,3,0,0,169,
		170,7,3,0,0,170,171,7,0,0,0,171,172,7,4,0,0,172,4,1,0,0,0,173,174,7,5,
		0,0,174,175,7,6,0,0,175,176,7,7,0,0,176,177,7,8,0,0,177,178,7,1,0,0,178,
		6,1,0,0,0,179,180,7,5,0,0,180,181,7,9,0,0,181,182,7,9,0,0,182,183,7,10,
		0,0,183,184,7,6,0,0,184,185,7,0,0,0,185,186,7,1,0,0,186,8,1,0,0,0,187,
		188,7,11,0,0,188,189,7,0,0,0,189,190,7,12,0,0,190,191,7,6,0,0,191,10,1,
		0,0,0,192,193,7,11,0,0,193,194,7,13,0,0,194,195,7,0,0,0,195,196,7,3,0,
		0,196,12,1,0,0,0,197,198,7,11,0,0,198,199,7,13,0,0,199,200,7,3,0,0,200,
		14,1,0,0,0,201,202,7,11,0,0,202,203,7,9,0,0,203,204,7,1,0,0,204,205,7,
		12,0,0,205,206,7,14,0,0,206,16,1,0,0,0,207,208,7,2,0,0,208,209,7,8,0,0,
		209,210,7,15,0,0,210,18,1,0,0,0,211,212,7,2,0,0,212,213,7,9,0,0,213,20,
		1,0,0,0,214,215,7,2,0,0,215,216,7,9,0,0,216,217,7,16,0,0,217,218,7,1,0,
		0,218,219,7,14,0,0,219,220,7,9,0,0,220,22,1,0,0,0,221,222,7,6,0,0,222,
		223,7,10,0,0,223,224,7,12,0,0,224,225,7,6,0,0,225,24,1,0,0,0,226,227,7,
		6,0,0,227,228,7,1,0,0,228,229,7,2,0,0,229,26,1,0,0,0,230,231,7,17,0,0,
		231,232,7,8,0,0,232,233,7,10,0,0,233,234,7,6,0,0,234,28,1,0,0,0,235,236,
		7,17,0,0,236,237,7,9,0,0,237,238,7,3,0,0,238,30,1,0,0,0,239,240,7,17,0,
		0,240,241,7,18,0,0,241,242,7,1,0,0,242,243,7,11,0,0,243,244,7,14,0,0,244,
		245,7,8,0,0,245,246,7,9,0,0,246,247,7,1,0,0,247,32,1,0,0,0,248,249,7,7,
		0,0,249,250,7,9,0,0,250,251,7,14,0,0,251,252,7,9,0,0,252,34,1,0,0,0,253,
		254,7,8,0,0,254,255,7,17,0,0,255,36,1,0,0,0,256,257,7,8,0,0,257,258,7,
		1,0,0,258,38,1,0,0,0,259,260,7,8,0,0,260,261,7,1,0,0,261,262,7,14,0,0,
		262,263,7,6,0,0,263,264,7,7,0,0,264,265,7,6,0,0,265,266,7,3,0,0,266,40,
		1,0,0,0,267,268,7,10,0,0,268,269,7,0,0,0,269,270,7,5,0,0,270,271,7,6,0,
		0,271,272,7,10,0,0,272,42,1,0,0,0,273,274,7,19,0,0,274,275,7,9,0,0,275,
		276,7,2,0,0,276,44,1,0,0,0,277,278,7,1,0,0,278,279,7,8,0,0,279,280,7,10,
		0,0,280,46,1,0,0,0,281,282,7,1,0,0,282,283,7,9,0,0,283,284,7,14,0,0,284,
		48,1,0,0,0,285,286,7,9,0,0,286,287,7,17,0,0,287,50,1,0,0,0,288,289,7,9,
		0,0,289,290,7,3,0,0,290,52,1,0,0,0,291,292,7,20,0,0,292,293,7,0,0,0,293,
		294,7,11,0,0,294,295,7,21,0,0,295,296,7,6,0,0,296,297,7,2,0,0,297,54,1,
		0,0,0,298,299,7,20,0,0,299,300,7,3,0,0,300,301,7,9,0,0,301,302,7,11,0,
		0,302,303,7,6,0,0,303,304,7,2,0,0,304,305,7,18,0,0,305,306,7,3,0,0,306,
		307,7,6,0,0,307,56,1,0,0,0,308,309,7,20,0,0,309,310,7,3,0,0,310,311,7,
		9,0,0,311,312,7,7,0,0,312,313,7,3,0,0,313,314,7,0,0,0,314,315,7,19,0,0,
		315,58,1,0,0,0,316,317,7,3,0,0,317,318,7,6,0,0,318,319,7,0,0,0,319,320,
		7,10,0,0,320,60,1,0,0,0,321,322,7,3,0,0,322,323,7,6,0,0,323,324,7,11,0,
		0,324,325,7,9,0,0,325,326,7,3,0,0,326,327,7,2,0,0,327,62,1,0,0,0,328,329,
		7,3,0,0,329,330,7,6,0,0,330,331,7,20,0,0,331,332,7,6,0,0,332,333,7,0,0,
		0,333,334,7,14,0,0,334,64,1,0,0,0,335,336,7,12,0,0,336,337,7,6,0,0,337,
		338,7,14,0,0,338,66,1,0,0,0,339,340,7,14,0,0,340,341,7,13,0,0,341,342,
		7,6,0,0,342,343,7,1,0,0,343,68,1,0,0,0,344,345,7,14,0,0,345,346,7,9,0,
		0,346,70,1,0,0,0,347,348,7,14,0,0,348,349,7,4,0,0,349,350,7,20,0,0,350,
		351,7,6,0,0,351,72,1,0,0,0,352,353,7,18,0,0,353,354,7,1,0,0,354,355,7,
		14,0,0,355,356,7,8,0,0,356,357,7,10,0,0,357,74,1,0,0,0,358,359,7,15,0,
		0,359,360,7,0,0,0,360,361,7,3,0,0,361,76,1,0,0,0,362,363,7,16,0,0,363,
		364,7,13,0,0,364,365,7,8,0,0,365,366,7,10,0,0,366,367,7,6,0,0,367,78,1,
		0,0,0,368,369,7,16,0,0,369,370,7,8,0,0,370,371,7,14,0,0,371,372,7,13,0,
		0,372,80,1,0,0,0,373,374,5,43,0,0,374,82,1,0,0,0,375,376,5,45,0,0,376,
		84,1,0,0,0,377,378,5,42,0,0,378,86,1,0,0,0,379,380,5,47,0,0,380,88,1,0,
		0,0,381,382,5,58,0,0,382,383,5,61,0,0,383,90,1,0,0,0,384,385,5,44,0,0,
		385,92,1,0,0,0,386,387,5,59,0,0,387,94,1,0,0,0,388,389,5,58,0,0,389,96,
		1,0,0,0,390,391,5,61,0,0,391,98,1,0,0,0,392,393,5,60,0,0,393,394,5,62,
		0,0,394,100,1,0,0,0,395,396,5,60,0,0,396,102,1,0,0,0,397,398,5,60,0,0,
		398,399,5,61,0,0,399,104,1,0,0,0,400,401,5,62,0,0,401,402,5,61,0,0,402,
		106,1,0,0,0,403,404,5,62,0,0,404,108,1,0,0,0,405,406,5,40,0,0,406,110,
		1,0,0,0,407,408,5,41,0,0,408,112,1,0,0,0,409,410,5,91,0,0,410,114,1,0,
		0,0,411,412,5,40,0,0,412,413,5,46,0,0,413,116,1,0,0,0,414,415,5,93,0,0,
		415,118,1,0,0,0,416,417,5,46,0,0,417,418,5,41,0,0,418,120,1,0,0,0,419,
		420,5,94,0,0,420,122,1,0,0,0,421,422,5,64,0,0,422,124,1,0,0,0,423,424,
		5,46,0,0,424,126,1,0,0,0,425,426,5,46,0,0,426,427,5,46,0,0,427,128,1,0,
		0,0,428,429,5,123,0,0,429,130,1,0,0,0,430,431,5,125,0,0,431,132,1,0,0,
		0,432,433,7,18,0,0,433,434,7,1,0,0,434,435,7,8,0,0,435,436,7,14,0,0,436,
		134,1,0,0,0,437,438,7,8,0,0,438,439,7,1,0,0,439,440,7,14,0,0,440,441,7,
		6,0,0,441,442,7,3,0,0,442,443,7,17,0,0,443,444,7,0,0,0,444,445,7,11,0,
		0,445,446,7,6,0,0,446,136,1,0,0,0,447,448,7,18,0,0,448,449,7,12,0,0,449,
		450,7,6,0,0,450,451,7,12,0,0,451,138,1,0,0,0,452,453,7,12,0,0,453,454,
		7,14,0,0,454,455,7,3,0,0,455,456,7,8,0,0,456,457,7,1,0,0,457,458,7,7,0,
		0,458,140,1,0,0,0,459,460,7,8,0,0,460,461,7,19,0,0,461,462,7,20,0,0,462,
		463,7,10,0,0,463,464,7,6,0,0,464,465,7,19,0,0,465,466,7,6,0,0,466,467,
		7,1,0,0,467,468,7,14,0,0,468,469,7,0,0,0,469,470,7,14,0,0,470,471,7,8,
		0,0,471,472,7,9,0,0,472,473,7,1,0,0,473,142,1,0,0,0,474,475,7,14,0,0,475,
		476,7,3,0,0,476,477,7,18,0,0,477,478,7,6,0,0,478,144,1,0,0,0,479,480,7,
		17,0,0,480,481,7,0,0,0,481,482,7,10,0,0,482,483,7,12,0,0,483,484,7,6,0,
		0,484,146,1,0,0,0,485,486,7,22,0,0,486,487,1,0,0,0,487,488,6,73,0,0,488,
		148,1,0,0,0,489,490,5,40,0,0,490,491,5,42,0,0,491,495,1,0,0,0,492,494,
		9,0,0,0,493,492,1,0,0,0,494,497,1,0,0,0,495,496,1,0,0,0,495,493,1,0,0,
		0,496,498,1,0,0,0,497,495,1,0,0,0,498,499,5,42,0,0,499,500,5,41,0,0,500,
		501,1,0,0,0,501,502,6,74,0,0,502,150,1,0,0,0,503,507,5,123,0,0,504,506,
		9,0,0,0,505,504,1,0,0,0,506,509,1,0,0,0,507,508,1,0,0,0,507,505,1,0,0,
		0,508,510,1,0,0,0,509,507,1,0,0,0,510,511,5,125,0,0,511,512,1,0,0,0,512,
		513,6,75,0,0,513,152,1,0,0,0,514,518,7,23,0,0,515,517,7,24,0,0,516,515,
		1,0,0,0,517,520,1,0,0,0,518,516,1,0,0,0,518,519,1,0,0,0,519,154,1,0,0,
		0,520,518,1,0,0,0,521,527,5,39,0,0,522,523,5,39,0,0,523,526,5,39,0,0,524,
		526,8,25,0,0,525,522,1,0,0,0,525,524,1,0,0,0,526,529,1,0,0,0,527,525,1,
		0,0,0,527,528,1,0,0,0,528,530,1,0,0,0,529,527,1,0,0,0,530,531,5,39,0,0,
		531,156,1,0,0,0,532,534,2,48,57,0,533,532,1,0,0,0,534,535,1,0,0,0,535,
		533,1,0,0,0,535,536,1,0,0,0,536,158,1,0,0,0,537,539,2,48,57,0,538,537,
		1,0,0,0,539,540,1,0,0,0,540,538,1,0,0,0,540,541,1,0,0,0,541,554,1,0,0,
		0,542,544,5,46,0,0,543,545,2,48,57,0,544,543,1,0,0,0,545,546,1,0,0,0,546,
		544,1,0,0,0,546,547,1,0,0,0,547,549,1,0,0,0,548,550,3,161,80,0,549,548,
		1,0,0,0,549,550,1,0,0,0,550,552,1,0,0,0,551,542,1,0,0,0,551,552,1,0,0,
		0,552,555,1,0,0,0,553,555,3,161,80,0,554,551,1,0,0,0,554,553,1,0,0,0,555,
		160,1,0,0,0,556,558,7,6,0,0,557,559,7,26,0,0,558,557,1,0,0,0,558,559,1,
		0,0,0,559,561,1,0,0,0,560,562,2,48,57,0,561,560,1,0,0,0,562,563,1,0,0,
		0,563,561,1,0,0,0,563,564,1,0,0,0,564,162,1,0,0,0,14,0,495,507,518,525,
		527,535,540,546,549,551,554,558,563,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
