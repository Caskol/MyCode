//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.12.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from CSharpPreprocessorParser.g4 by ANTLR 4.12.0

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
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
[System.CLSCompliant(false)]
public partial class CSharpPreprocessorParser : CSharpPreprocessorParserBase {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		BYTE_ORDER_MARK=1, SINGLE_LINE_DOC_COMMENT=2, EMPTY_DELIMITED_DOC_COMMENT=3, 
		DELIMITED_DOC_COMMENT=4, SINGLE_LINE_COMMENT=5, DELIMITED_COMMENT=6, WHITESPACES=7, 
		SHARP=8, ABSTRACT=9, ADD=10, ALIAS=11, ARGLIST=12, AS=13, ASCENDING=14, 
		ASYNC=15, AWAIT=16, BASE=17, BOOL=18, BREAK=19, BY=20, BYTE=21, CASE=22, 
		CATCH=23, CHAR=24, CHECKED=25, CLASS=26, CONST=27, CONTINUE=28, DECIMAL=29, 
		DEFAULT=30, DELEGATE=31, DESCENDING=32, DO=33, DOUBLE=34, DYNAMIC=35, 
		ELSE=36, ENUM=37, EQUALS=38, EVENT=39, EXPLICIT=40, EXTERN=41, FALSE=42, 
		FINALLY=43, FIXED=44, FLOAT=45, FOR=46, FOREACH=47, FROM=48, GET=49, GOTO=50, 
		GROUP=51, IF=52, IMPLICIT=53, IN=54, INT=55, INTERFACE=56, INTERNAL=57, 
		INTO=58, IS=59, JOIN=60, LET=61, LOCK=62, LONG=63, NAMEOF=64, NAMESPACE=65, 
		NEW=66, NULL_=67, OBJECT=68, ON=69, OPERATOR=70, ORDERBY=71, OUT=72, OVERRIDE=73, 
		PARAMS=74, PARTIAL=75, PRIVATE=76, PROTECTED=77, PUBLIC=78, READONLY=79, 
		REF=80, REMOVE=81, RETURN=82, SBYTE=83, SEALED=84, SELECT=85, SET=86, 
		SHORT=87, SIZEOF=88, STACKALLOC=89, STATIC=90, STRING=91, STRUCT=92, SWITCH=93, 
		THIS=94, THROW=95, TRUE=96, TRY=97, TYPEOF=98, UINT=99, ULONG=100, UNCHECKED=101, 
		UNMANAGED=102, UNSAFE=103, USHORT=104, USING=105, VAR=106, VIRTUAL=107, 
		VOID=108, VOLATILE=109, WHEN=110, WHERE=111, WHILE=112, YIELD=113, IDENTIFIER=114, 
		LITERAL_ACCESS=115, INTEGER_LITERAL=116, HEX_INTEGER_LITERAL=117, BIN_INTEGER_LITERAL=118, 
		REAL_LITERAL=119, CHARACTER_LITERAL=120, REGULAR_STRING=121, VERBATIUM_STRING=122, 
		INTERPOLATED_REGULAR_STRING_START=123, INTERPOLATED_VERBATIUM_STRING_START=124, 
		OPEN_BRACE=125, CLOSE_BRACE=126, OPEN_BRACKET=127, CLOSE_BRACKET=128, 
		OPEN_PARENS=129, CLOSE_PARENS=130, DOT=131, COMMA=132, COLON=133, SEMICOLON=134, 
		PLUS=135, MINUS=136, STAR=137, DIV=138, PERCENT=139, AMP=140, BITWISE_OR=141, 
		CARET=142, BANG=143, TILDE=144, ASSIGNMENT=145, LT=146, GT=147, INTERR=148, 
		DOUBLE_COLON=149, OP_COALESCING=150, OP_INC=151, OP_DEC=152, OP_AND=153, 
		OP_OR=154, OP_PTR=155, OP_EQ=156, OP_NE=157, OP_LE=158, OP_GE=159, OP_ADD_ASSIGNMENT=160, 
		OP_SUB_ASSIGNMENT=161, OP_MULT_ASSIGNMENT=162, OP_DIV_ASSIGNMENT=163, 
		OP_MOD_ASSIGNMENT=164, OP_AND_ASSIGNMENT=165, OP_OR_ASSIGNMENT=166, OP_XOR_ASSIGNMENT=167, 
		OP_LEFT_SHIFT=168, OP_LEFT_SHIFT_ASSIGNMENT=169, OP_COALESCING_ASSIGNMENT=170, 
		OP_RANGE=171, DOUBLE_CURLY_INSIDE=172, OPEN_BRACE_INSIDE=173, REGULAR_CHAR_INSIDE=174, 
		VERBATIUM_DOUBLE_QUOTE_INSIDE=175, DOUBLE_QUOTE_INSIDE=176, REGULAR_STRING_INSIDE=177, 
		VERBATIUM_INSIDE_STRING=178, CLOSE_BRACE_INSIDE=179, FORMAT_STRING=180, 
		DIRECTIVE_WHITESPACES=181, DIGITS=182, DEFINE=183, UNDEF=184, ELIF=185, 
		ENDIF=186, LINE=187, ERROR=188, WARNING=189, REGION=190, ENDREGION=191, 
		PRAGMA=192, NULLABLE=193, DIRECTIVE_HIDDEN=194, CONDITIONAL_SYMBOL=195, 
		DIRECTIVE_NEW_LINE=196, TEXT=197, DOUBLE_CURLY_CLOSE_INSIDE=198;
	public const int
		RULE_preprocessor_directive = 0, RULE_directive_new_line_or_sharp = 1, 
		RULE_preprocessor_expression = 2;
	public static readonly string[] ruleNames = {
		"preprocessor_directive", "directive_new_line_or_sharp", "preprocessor_expression"
	};

	private static readonly string[] _LiteralNames = {
		null, "'\\u00EF\\u00BB\\u00BF'", null, "'/***/'", null, null, null, null, 
		"'#'", "'abstract'", "'add'", "'alias'", "'__arglist'", "'as'", "'ascending'", 
		"'async'", "'await'", "'base'", "'bool'", "'break'", "'by'", "'byte'", 
		"'case'", "'catch'", "'char'", "'checked'", "'class'", "'const'", "'continue'", 
		"'decimal'", "'default'", "'delegate'", "'descending'", "'do'", "'double'", 
		"'dynamic'", "'else'", "'enum'", "'equals'", "'event'", "'explicit'", 
		"'extern'", "'false'", "'finally'", "'fixed'", "'float'", "'for'", "'foreach'", 
		"'from'", "'get'", "'goto'", "'group'", "'if'", "'implicit'", "'in'", 
		"'int'", "'interface'", "'internal'", "'into'", "'is'", "'join'", "'let'", 
		"'lock'", "'long'", "'nameof'", "'namespace'", "'new'", "'null'", "'object'", 
		"'on'", "'operator'", "'orderby'", "'out'", "'override'", "'params'", 
		"'partial'", "'private'", "'protected'", "'public'", "'readonly'", "'ref'", 
		"'remove'", "'return'", "'sbyte'", "'sealed'", "'select'", "'set'", "'short'", 
		"'sizeof'", "'stackalloc'", "'static'", "'string'", "'struct'", "'switch'", 
		"'this'", "'throw'", "'true'", "'try'", "'typeof'", "'uint'", "'ulong'", 
		"'unchecked'", "'unmanaged'", "'unsafe'", "'ushort'", "'using'", "'var'", 
		"'virtual'", "'void'", "'volatile'", "'when'", "'where'", "'while'", "'yield'", 
		null, null, null, null, null, null, null, null, null, null, null, "'{'", 
		"'}'", "'['", "']'", "'('", "')'", "'.'", "','", "':'", "';'", "'+'", 
		"'-'", "'*'", "'/'", "'%'", "'&'", "'|'", "'^'", "'!'", "'~'", "'='", 
		"'<'", "'>'", "'?'", "'::'", "'??'", "'++'", "'--'", "'&&'", "'||'", "'->'", 
		"'=='", "'!='", "'<='", "'>='", "'+='", "'-='", "'*='", "'/='", "'%='", 
		"'&='", "'|='", "'^='", "'<<'", "'<<='", "'??='", "'..'", "'{{'", null, 
		null, null, null, null, null, null, null, null, null, "'define'", "'undef'", 
		"'elif'", "'endif'", "'line'", null, null, null, null, null, null, "'hidden'", 
		null, null, null, "'}}'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "BYTE_ORDER_MARK", "SINGLE_LINE_DOC_COMMENT", "EMPTY_DELIMITED_DOC_COMMENT", 
		"DELIMITED_DOC_COMMENT", "SINGLE_LINE_COMMENT", "DELIMITED_COMMENT", "WHITESPACES", 
		"SHARP", "ABSTRACT", "ADD", "ALIAS", "ARGLIST", "AS", "ASCENDING", "ASYNC", 
		"AWAIT", "BASE", "BOOL", "BREAK", "BY", "BYTE", "CASE", "CATCH", "CHAR", 
		"CHECKED", "CLASS", "CONST", "CONTINUE", "DECIMAL", "DEFAULT", "DELEGATE", 
		"DESCENDING", "DO", "DOUBLE", "DYNAMIC", "ELSE", "ENUM", "EQUALS", "EVENT", 
		"EXPLICIT", "EXTERN", "FALSE", "FINALLY", "FIXED", "FLOAT", "FOR", "FOREACH", 
		"FROM", "GET", "GOTO", "GROUP", "IF", "IMPLICIT", "IN", "INT", "INTERFACE", 
		"INTERNAL", "INTO", "IS", "JOIN", "LET", "LOCK", "LONG", "NAMEOF", "NAMESPACE", 
		"NEW", "NULL_", "OBJECT", "ON", "OPERATOR", "ORDERBY", "OUT", "OVERRIDE", 
		"PARAMS", "PARTIAL", "PRIVATE", "PROTECTED", "PUBLIC", "READONLY", "REF", 
		"REMOVE", "RETURN", "SBYTE", "SEALED", "SELECT", "SET", "SHORT", "SIZEOF", 
		"STACKALLOC", "STATIC", "STRING", "STRUCT", "SWITCH", "THIS", "THROW", 
		"TRUE", "TRY", "TYPEOF", "UINT", "ULONG", "UNCHECKED", "UNMANAGED", "UNSAFE", 
		"USHORT", "USING", "VAR", "VIRTUAL", "VOID", "VOLATILE", "WHEN", "WHERE", 
		"WHILE", "YIELD", "IDENTIFIER", "LITERAL_ACCESS", "INTEGER_LITERAL", "HEX_INTEGER_LITERAL", 
		"BIN_INTEGER_LITERAL", "REAL_LITERAL", "CHARACTER_LITERAL", "REGULAR_STRING", 
		"VERBATIUM_STRING", "INTERPOLATED_REGULAR_STRING_START", "INTERPOLATED_VERBATIUM_STRING_START", 
		"OPEN_BRACE", "CLOSE_BRACE", "OPEN_BRACKET", "CLOSE_BRACKET", "OPEN_PARENS", 
		"CLOSE_PARENS", "DOT", "COMMA", "COLON", "SEMICOLON", "PLUS", "MINUS", 
		"STAR", "DIV", "PERCENT", "AMP", "BITWISE_OR", "CARET", "BANG", "TILDE", 
		"ASSIGNMENT", "LT", "GT", "INTERR", "DOUBLE_COLON", "OP_COALESCING", "OP_INC", 
		"OP_DEC", "OP_AND", "OP_OR", "OP_PTR", "OP_EQ", "OP_NE", "OP_LE", "OP_GE", 
		"OP_ADD_ASSIGNMENT", "OP_SUB_ASSIGNMENT", "OP_MULT_ASSIGNMENT", "OP_DIV_ASSIGNMENT", 
		"OP_MOD_ASSIGNMENT", "OP_AND_ASSIGNMENT", "OP_OR_ASSIGNMENT", "OP_XOR_ASSIGNMENT", 
		"OP_LEFT_SHIFT", "OP_LEFT_SHIFT_ASSIGNMENT", "OP_COALESCING_ASSIGNMENT", 
		"OP_RANGE", "DOUBLE_CURLY_INSIDE", "OPEN_BRACE_INSIDE", "REGULAR_CHAR_INSIDE", 
		"VERBATIUM_DOUBLE_QUOTE_INSIDE", "DOUBLE_QUOTE_INSIDE", "REGULAR_STRING_INSIDE", 
		"VERBATIUM_INSIDE_STRING", "CLOSE_BRACE_INSIDE", "FORMAT_STRING", "DIRECTIVE_WHITESPACES", 
		"DIGITS", "DEFINE", "UNDEF", "ELIF", "ENDIF", "LINE", "ERROR", "WARNING", 
		"REGION", "ENDREGION", "PRAGMA", "NULLABLE", "DIRECTIVE_HIDDEN", "CONDITIONAL_SYMBOL", 
		"DIRECTIVE_NEW_LINE", "TEXT", "DOUBLE_CURLY_CLOSE_INSIDE"
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

	public override string GrammarFileName { get { return "CSharpPreprocessorParser.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static CSharpPreprocessorParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public CSharpPreprocessorParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public CSharpPreprocessorParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class Preprocessor_directiveContext : ParserRuleContext {
		public Boolean value;
		public Preprocessor_directiveContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_preprocessor_directive; } }
	 
		public Preprocessor_directiveContext() { }
		public virtual void CopyFrom(Preprocessor_directiveContext context) {
			base.CopyFrom(context);
			this.value = context.value;
		}
	}
	public partial class PreprocessorDiagnosticContext : Preprocessor_directiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ERROR() { return GetToken(CSharpPreprocessorParser.ERROR, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TEXT() { return GetToken(CSharpPreprocessorParser.TEXT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public Directive_new_line_or_sharpContext directive_new_line_or_sharp() {
			return GetRuleContext<Directive_new_line_or_sharpContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode WARNING() { return GetToken(CSharpPreprocessorParser.WARNING, 0); }
		public PreprocessorDiagnosticContext(Preprocessor_directiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.EnterPreprocessorDiagnostic(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.ExitPreprocessorDiagnostic(this);
		}
	}
	public partial class PreprocessorNullableContext : Preprocessor_directiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NULLABLE() { return GetToken(CSharpPreprocessorParser.NULLABLE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TEXT() { return GetToken(CSharpPreprocessorParser.TEXT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public Directive_new_line_or_sharpContext directive_new_line_or_sharp() {
			return GetRuleContext<Directive_new_line_or_sharpContext>(0);
		}
		public PreprocessorNullableContext(Preprocessor_directiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.EnterPreprocessorNullable(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.ExitPreprocessorNullable(this);
		}
	}
	public partial class PreprocessorRegionContext : Preprocessor_directiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode REGION() { return GetToken(CSharpPreprocessorParser.REGION, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public Directive_new_line_or_sharpContext directive_new_line_or_sharp() {
			return GetRuleContext<Directive_new_line_or_sharpContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TEXT() { return GetToken(CSharpPreprocessorParser.TEXT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ENDREGION() { return GetToken(CSharpPreprocessorParser.ENDREGION, 0); }
		public PreprocessorRegionContext(Preprocessor_directiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.EnterPreprocessorRegion(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.ExitPreprocessorRegion(this);
		}
	}
	public partial class PreprocessorDeclarationContext : Preprocessor_directiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DEFINE() { return GetToken(CSharpPreprocessorParser.DEFINE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode CONDITIONAL_SYMBOL() { return GetToken(CSharpPreprocessorParser.CONDITIONAL_SYMBOL, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public Directive_new_line_or_sharpContext directive_new_line_or_sharp() {
			return GetRuleContext<Directive_new_line_or_sharpContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode UNDEF() { return GetToken(CSharpPreprocessorParser.UNDEF, 0); }
		public PreprocessorDeclarationContext(Preprocessor_directiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.EnterPreprocessorDeclaration(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.ExitPreprocessorDeclaration(this);
		}
	}
	public partial class PreprocessorConditionalContext : Preprocessor_directiveContext {
		public Preprocessor_expressionContext expr;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IF() { return GetToken(CSharpPreprocessorParser.IF, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public Directive_new_line_or_sharpContext directive_new_line_or_sharp() {
			return GetRuleContext<Directive_new_line_or_sharpContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public Preprocessor_expressionContext preprocessor_expression() {
			return GetRuleContext<Preprocessor_expressionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ELIF() { return GetToken(CSharpPreprocessorParser.ELIF, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ELSE() { return GetToken(CSharpPreprocessorParser.ELSE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ENDIF() { return GetToken(CSharpPreprocessorParser.ENDIF, 0); }
		public PreprocessorConditionalContext(Preprocessor_directiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.EnterPreprocessorConditional(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.ExitPreprocessorConditional(this);
		}
	}
	public partial class PreprocessorPragmaContext : Preprocessor_directiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PRAGMA() { return GetToken(CSharpPreprocessorParser.PRAGMA, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TEXT() { return GetToken(CSharpPreprocessorParser.TEXT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public Directive_new_line_or_sharpContext directive_new_line_or_sharp() {
			return GetRuleContext<Directive_new_line_or_sharpContext>(0);
		}
		public PreprocessorPragmaContext(Preprocessor_directiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.EnterPreprocessorPragma(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.ExitPreprocessorPragma(this);
		}
	}
	public partial class PreprocessorLineContext : Preprocessor_directiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LINE() { return GetToken(CSharpPreprocessorParser.LINE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public Directive_new_line_or_sharpContext directive_new_line_or_sharp() {
			return GetRuleContext<Directive_new_line_or_sharpContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIGITS() { return GetToken(CSharpPreprocessorParser.DIGITS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DEFAULT() { return GetToken(CSharpPreprocessorParser.DEFAULT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIRECTIVE_HIDDEN() { return GetToken(CSharpPreprocessorParser.DIRECTIVE_HIDDEN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(CSharpPreprocessorParser.STRING, 0); }
		public PreprocessorLineContext(Preprocessor_directiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.EnterPreprocessorLine(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.ExitPreprocessorLine(this);
		}
	}

	[RuleVersion(0)]
	public Preprocessor_directiveContext preprocessor_directive() {
		Preprocessor_directiveContext _localctx = new Preprocessor_directiveContext(Context, State);
		EnterRule(_localctx, 0, RULE_preprocessor_directive);
		int _la;
		try {
			State = 80;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case DEFINE:
				_localctx = new PreprocessorDeclarationContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 6;
				Match(DEFINE);
				State = 7;
				Match(CONDITIONAL_SYMBOL);
				State = 8;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectiveDefine(); 
				}
				break;
			case UNDEF:
				_localctx = new PreprocessorDeclarationContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 11;
				Match(UNDEF);
				State = 12;
				Match(CONDITIONAL_SYMBOL);
				State = 13;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectiveUndef(); 
				}
				break;
			case IF:
				_localctx = new PreprocessorConditionalContext(_localctx);
				EnterOuterAlt(_localctx, 3);
				{
				State = 16;
				Match(IF);
				State = 17;
				((PreprocessorConditionalContext)_localctx).expr = preprocessor_expression(0);
				State = 18;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectiveIf(); 
				}
				break;
			case ELIF:
				_localctx = new PreprocessorConditionalContext(_localctx);
				EnterOuterAlt(_localctx, 4);
				{
				State = 21;
				Match(ELIF);
				State = 22;
				((PreprocessorConditionalContext)_localctx).expr = preprocessor_expression(0);
				State = 23;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectiveElif(); 
				}
				break;
			case ELSE:
				_localctx = new PreprocessorConditionalContext(_localctx);
				EnterOuterAlt(_localctx, 5);
				{
				State = 26;
				Match(ELSE);
				State = 27;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectiveElse(); 
				}
				break;
			case ENDIF:
				_localctx = new PreprocessorConditionalContext(_localctx);
				EnterOuterAlt(_localctx, 6);
				{
				State = 30;
				Match(ENDIF);
				State = 31;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectiveEndif(); 
				}
				break;
			case LINE:
				_localctx = new PreprocessorLineContext(_localctx);
				EnterOuterAlt(_localctx, 7);
				{
				State = 34;
				Match(LINE);
				State = 41;
				ErrorHandler.Sync(this);
				switch (TokenStream.LA(1)) {
				case DIGITS:
					{
					State = 35;
					Match(DIGITS);
					State = 37;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
					if (_la==STRING) {
						{
						State = 36;
						Match(STRING);
						}
					}

					}
					break;
				case DEFAULT:
					{
					State = 39;
					Match(DEFAULT);
					}
					break;
				case DIRECTIVE_HIDDEN:
					{
					State = 40;
					Match(DIRECTIVE_HIDDEN);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				State = 43;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectiveLine(); 
				}
				break;
			case ERROR:
				_localctx = new PreprocessorDiagnosticContext(_localctx);
				EnterOuterAlt(_localctx, 8);
				{
				State = 46;
				Match(ERROR);
				State = 47;
				Match(TEXT);
				State = 48;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectiveError(); 
				}
				break;
			case WARNING:
				_localctx = new PreprocessorDiagnosticContext(_localctx);
				EnterOuterAlt(_localctx, 9);
				{
				State = 51;
				Match(WARNING);
				State = 52;
				Match(TEXT);
				State = 53;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectiveWarning(); 
				}
				break;
			case REGION:
				_localctx = new PreprocessorRegionContext(_localctx);
				EnterOuterAlt(_localctx, 10);
				{
				State = 56;
				Match(REGION);
				State = 58;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==TEXT) {
					{
					State = 57;
					Match(TEXT);
					}
				}

				State = 60;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectiveRegion(); 
				}
				break;
			case ENDREGION:
				_localctx = new PreprocessorRegionContext(_localctx);
				EnterOuterAlt(_localctx, 11);
				{
				State = 63;
				Match(ENDREGION);
				State = 65;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==TEXT) {
					{
					State = 64;
					Match(TEXT);
					}
				}

				State = 67;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectiveEndregion(); 
				}
				break;
			case PRAGMA:
				_localctx = new PreprocessorPragmaContext(_localctx);
				EnterOuterAlt(_localctx, 12);
				{
				State = 70;
				Match(PRAGMA);
				State = 71;
				Match(TEXT);
				State = 72;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectivePragma(); 
				}
				break;
			case NULLABLE:
				_localctx = new PreprocessorNullableContext(_localctx);
				EnterOuterAlt(_localctx, 13);
				{
				State = 75;
				Match(NULLABLE);
				State = 76;
				Match(TEXT);
				State = 77;
				directive_new_line_or_sharp();
				 this.OnPreprocessorDirectiveNullable(); 
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Directive_new_line_or_sharpContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIRECTIVE_NEW_LINE() { return GetToken(CSharpPreprocessorParser.DIRECTIVE_NEW_LINE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(CSharpPreprocessorParser.Eof, 0); }
		public Directive_new_line_or_sharpContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_directive_new_line_or_sharp; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.EnterDirective_new_line_or_sharp(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.ExitDirective_new_line_or_sharp(this);
		}
	}

	[RuleVersion(0)]
	public Directive_new_line_or_sharpContext directive_new_line_or_sharp() {
		Directive_new_line_or_sharpContext _localctx = new Directive_new_line_or_sharpContext(Context, State);
		EnterRule(_localctx, 2, RULE_directive_new_line_or_sharp);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 82;
			_la = TokenStream.LA(1);
			if ( !(_la==Eof || _la==DIRECTIVE_NEW_LINE) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Preprocessor_expressionContext : ParserRuleContext {
		public String value;
		public Preprocessor_expressionContext expr1;
		public Preprocessor_expressionContext expr;
		public Preprocessor_expressionContext expr2;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TRUE() { return GetToken(CSharpPreprocessorParser.TRUE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode FALSE() { return GetToken(CSharpPreprocessorParser.FALSE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode CONDITIONAL_SYMBOL() { return GetToken(CSharpPreprocessorParser.CONDITIONAL_SYMBOL, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode OPEN_PARENS() { return GetToken(CSharpPreprocessorParser.OPEN_PARENS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode CLOSE_PARENS() { return GetToken(CSharpPreprocessorParser.CLOSE_PARENS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public Preprocessor_expressionContext[] preprocessor_expression() {
			return GetRuleContexts<Preprocessor_expressionContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public Preprocessor_expressionContext preprocessor_expression(int i) {
			return GetRuleContext<Preprocessor_expressionContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode BANG() { return GetToken(CSharpPreprocessorParser.BANG, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode OP_EQ() { return GetToken(CSharpPreprocessorParser.OP_EQ, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode OP_NE() { return GetToken(CSharpPreprocessorParser.OP_NE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode OP_AND() { return GetToken(CSharpPreprocessorParser.OP_AND, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode OP_OR() { return GetToken(CSharpPreprocessorParser.OP_OR, 0); }
		public Preprocessor_expressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_preprocessor_expression; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.EnterPreprocessor_expression(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSharpPreprocessorParserListener typedListener = listener as ICSharpPreprocessorParserListener;
			if (typedListener != null) typedListener.ExitPreprocessor_expression(this);
		}
	}

	[RuleVersion(0)]
	public Preprocessor_expressionContext preprocessor_expression() {
		return preprocessor_expression(0);
	}

	private Preprocessor_expressionContext preprocessor_expression(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		Preprocessor_expressionContext _localctx = new Preprocessor_expressionContext(Context, _parentState);
		Preprocessor_expressionContext _prevctx = _localctx;
		int _startState = 4;
		EnterRecursionRule(_localctx, 4, RULE_preprocessor_expression, _p);
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 100;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case TRUE:
				{
				State = 85;
				Match(TRUE);
				 this.OnPreprocessorExpressionTrue(); 
				}
				break;
			case FALSE:
				{
				State = 87;
				Match(FALSE);
				 this.OnPreprocessorExpressionFalse(); 
				}
				break;
			case CONDITIONAL_SYMBOL:
				{
				State = 89;
				Match(CONDITIONAL_SYMBOL);
				 this.OnPreprocessorExpressionConditionalSymbol(); 
				}
				break;
			case OPEN_PARENS:
				{
				State = 91;
				Match(OPEN_PARENS);
				State = 92;
				_localctx.expr = preprocessor_expression(0);
				State = 93;
				Match(CLOSE_PARENS);
				 this.OnPreprocessorExpressionConditionalOpenParens(); 
				}
				break;
			case BANG:
				{
				State = 96;
				Match(BANG);
				State = 97;
				_localctx.expr = preprocessor_expression(5);
				 this.OnPreprocessorExpressionConditionalBang(); 
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 124;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,7,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 122;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,6,Context) ) {
					case 1:
						{
						_localctx = new Preprocessor_expressionContext(_parentctx, _parentState);
						_localctx.expr1 = _prevctx;
						PushNewRecursionContext(_localctx, _startState, RULE_preprocessor_expression);
						State = 102;
						if (!(Precpred(Context, 4))) throw new FailedPredicateException(this, "Precpred(Context, 4)");
						State = 103;
						Match(OP_EQ);
						State = 104;
						_localctx.expr2 = preprocessor_expression(5);
						 this.OnPreprocessorExpressionConditionalEq(); 
						}
						break;
					case 2:
						{
						_localctx = new Preprocessor_expressionContext(_parentctx, _parentState);
						_localctx.expr1 = _prevctx;
						PushNewRecursionContext(_localctx, _startState, RULE_preprocessor_expression);
						State = 107;
						if (!(Precpred(Context, 3))) throw new FailedPredicateException(this, "Precpred(Context, 3)");
						State = 108;
						Match(OP_NE);
						State = 109;
						_localctx.expr2 = preprocessor_expression(4);
						 this.OnPreprocessorExpressionConditionalNe(); 
						}
						break;
					case 3:
						{
						_localctx = new Preprocessor_expressionContext(_parentctx, _parentState);
						_localctx.expr1 = _prevctx;
						PushNewRecursionContext(_localctx, _startState, RULE_preprocessor_expression);
						State = 112;
						if (!(Precpred(Context, 2))) throw new FailedPredicateException(this, "Precpred(Context, 2)");
						State = 113;
						Match(OP_AND);
						State = 114;
						_localctx.expr2 = preprocessor_expression(3);
						 this.OnPreprocessorExpressionConditionalAnd(); 
						}
						break;
					case 4:
						{
						_localctx = new Preprocessor_expressionContext(_parentctx, _parentState);
						_localctx.expr1 = _prevctx;
						PushNewRecursionContext(_localctx, _startState, RULE_preprocessor_expression);
						State = 117;
						if (!(Precpred(Context, 1))) throw new FailedPredicateException(this, "Precpred(Context, 1)");
						State = 118;
						Match(OP_OR);
						State = 119;
						_localctx.expr2 = preprocessor_expression(2);
						 this.OnPreprocessorExpressionConditionalOr(); 
						}
						break;
					}
					} 
				}
				State = 126;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,7,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 2: return preprocessor_expression_sempred((Preprocessor_expressionContext)_localctx, predIndex);
		}
		return true;
	}
	private bool preprocessor_expression_sempred(Preprocessor_expressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 4);
		case 1: return Precpred(Context, 3);
		case 2: return Precpred(Context, 2);
		case 3: return Precpred(Context, 1);
		}
		return true;
	}

	private static int[] _serializedATN = {
		4,1,198,128,2,0,7,0,2,1,7,1,2,2,7,2,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,
		0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,
		1,0,1,0,1,0,1,0,1,0,3,0,38,8,0,1,0,1,0,3,0,42,8,0,1,0,1,0,1,0,1,0,1,0,
		1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,3,0,59,8,0,1,0,1,0,1,0,1,0,1,0,
		3,0,66,8,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,3,0,81,
		8,0,1,1,1,1,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,
		2,1,2,3,2,101,8,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,
		1,2,1,2,1,2,1,2,1,2,1,2,1,2,5,2,123,8,2,10,2,12,2,126,9,2,1,2,0,1,4,3,
		0,2,4,0,1,1,1,196,196,149,0,80,1,0,0,0,2,82,1,0,0,0,4,100,1,0,0,0,6,7,
		5,183,0,0,7,8,5,195,0,0,8,9,3,2,1,0,9,10,6,0,-1,0,10,81,1,0,0,0,11,12,
		5,184,0,0,12,13,5,195,0,0,13,14,3,2,1,0,14,15,6,0,-1,0,15,81,1,0,0,0,16,
		17,5,52,0,0,17,18,3,4,2,0,18,19,3,2,1,0,19,20,6,0,-1,0,20,81,1,0,0,0,21,
		22,5,185,0,0,22,23,3,4,2,0,23,24,3,2,1,0,24,25,6,0,-1,0,25,81,1,0,0,0,
		26,27,5,36,0,0,27,28,3,2,1,0,28,29,6,0,-1,0,29,81,1,0,0,0,30,31,5,186,
		0,0,31,32,3,2,1,0,32,33,6,0,-1,0,33,81,1,0,0,0,34,41,5,187,0,0,35,37,5,
		182,0,0,36,38,5,91,0,0,37,36,1,0,0,0,37,38,1,0,0,0,38,42,1,0,0,0,39,42,
		5,30,0,0,40,42,5,194,0,0,41,35,1,0,0,0,41,39,1,0,0,0,41,40,1,0,0,0,42,
		43,1,0,0,0,43,44,3,2,1,0,44,45,6,0,-1,0,45,81,1,0,0,0,46,47,5,188,0,0,
		47,48,5,197,0,0,48,49,3,2,1,0,49,50,6,0,-1,0,50,81,1,0,0,0,51,52,5,189,
		0,0,52,53,5,197,0,0,53,54,3,2,1,0,54,55,6,0,-1,0,55,81,1,0,0,0,56,58,5,
		190,0,0,57,59,5,197,0,0,58,57,1,0,0,0,58,59,1,0,0,0,59,60,1,0,0,0,60,61,
		3,2,1,0,61,62,6,0,-1,0,62,81,1,0,0,0,63,65,5,191,0,0,64,66,5,197,0,0,65,
		64,1,0,0,0,65,66,1,0,0,0,66,67,1,0,0,0,67,68,3,2,1,0,68,69,6,0,-1,0,69,
		81,1,0,0,0,70,71,5,192,0,0,71,72,5,197,0,0,72,73,3,2,1,0,73,74,6,0,-1,
		0,74,81,1,0,0,0,75,76,5,193,0,0,76,77,5,197,0,0,77,78,3,2,1,0,78,79,6,
		0,-1,0,79,81,1,0,0,0,80,6,1,0,0,0,80,11,1,0,0,0,80,16,1,0,0,0,80,21,1,
		0,0,0,80,26,1,0,0,0,80,30,1,0,0,0,80,34,1,0,0,0,80,46,1,0,0,0,80,51,1,
		0,0,0,80,56,1,0,0,0,80,63,1,0,0,0,80,70,1,0,0,0,80,75,1,0,0,0,81,1,1,0,
		0,0,82,83,7,0,0,0,83,3,1,0,0,0,84,85,6,2,-1,0,85,86,5,96,0,0,86,101,6,
		2,-1,0,87,88,5,42,0,0,88,101,6,2,-1,0,89,90,5,195,0,0,90,101,6,2,-1,0,
		91,92,5,129,0,0,92,93,3,4,2,0,93,94,5,130,0,0,94,95,6,2,-1,0,95,101,1,
		0,0,0,96,97,5,143,0,0,97,98,3,4,2,5,98,99,6,2,-1,0,99,101,1,0,0,0,100,
		84,1,0,0,0,100,87,1,0,0,0,100,89,1,0,0,0,100,91,1,0,0,0,100,96,1,0,0,0,
		101,124,1,0,0,0,102,103,10,4,0,0,103,104,5,156,0,0,104,105,3,4,2,5,105,
		106,6,2,-1,0,106,123,1,0,0,0,107,108,10,3,0,0,108,109,5,157,0,0,109,110,
		3,4,2,4,110,111,6,2,-1,0,111,123,1,0,0,0,112,113,10,2,0,0,113,114,5,153,
		0,0,114,115,3,4,2,3,115,116,6,2,-1,0,116,123,1,0,0,0,117,118,10,1,0,0,
		118,119,5,154,0,0,119,120,3,4,2,2,120,121,6,2,-1,0,121,123,1,0,0,0,122,
		102,1,0,0,0,122,107,1,0,0,0,122,112,1,0,0,0,122,117,1,0,0,0,123,126,1,
		0,0,0,124,122,1,0,0,0,124,125,1,0,0,0,125,5,1,0,0,0,126,124,1,0,0,0,8,
		37,41,58,65,80,100,122,124
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
