//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\lluis\Desktop\9no Semestre\Labo ProDeSistemas\Practica12\Proyecto LISTO\AnalizadorSIC_GRAFICO\AnalizadorSIC_GRAFICO\GramaticaSIC_STD.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace AnalizadorSIC_GRAFICO {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class GramaticaSIC_STDLexer : Lexer {
	public const int
		TIPODIRECTIVA=1, DIRSTART=2, DIREND=3, TRSUB=4, CODOP=5, CONSTCAD=6, CONSTHEX=7, 
		ID=8, DIRBYTE=9, FINL=10, TAB=11, NUM=12, INDICE=13, COMPNUM=14, WS=15;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"TIPODIRECTIVA", "DIRSTART", "DIREND", "TRSUB", "CODOP", "CONSTCAD", "CONSTHEX", 
		"ID", "DIRBYTE", "FINL", "TAB", "NUM", "INDICE", "COMPNUM", "WS"
	};


	public GramaticaSIC_STDLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, null, "'START'", "'END'", "'RSUB'", null, null, null, null, "'BYTE'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "TIPODIRECTIVA", "DIRSTART", "DIREND", "TRSUB", "CODOP", "CONSTCAD", 
		"CONSTHEX", "ID", "DIRBYTE", "FINL", "TAB", "NUM", "INDICE", "COMPNUM", 
		"WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "GramaticaSIC_STD.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\x11\xDC\b\x1\x4"+
		"\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b"+
		"\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4"+
		"\x10\t\x10\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2"+
		"\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x5\x2\x32\n\x2\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x4\x3\x4\x3\x4\x3\x4\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x5\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6"+
		"\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3"+
		"\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6"+
		"\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3"+
		"\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6"+
		"\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3"+
		"\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x5\x6\x8D\n\x6\x3\a\x3\a\x3\a\x3\a\x6"+
		"\a\x93\n\a\r\a\xE\a\x94\x3\a\x3\a\x3\b\x3\b\x3\b\x3\b\x6\b\x9D\n\b\r\b"+
		"\xE\b\x9E\x3\b\x3\b\x3\t\x6\t\xA4\n\t\r\t\xE\t\xA5\x3\n\x3\n\x3\n\x3\n"+
		"\x3\n\x3\v\x6\v\xAE\n\v\r\v\xE\v\xAF\x3\f\a\f\xB3\n\f\f\f\xE\f\xB6\v\f"+
		"\x3\r\x6\r\xB9\n\r\r\r\xE\r\xBA\x3\r\x5\r\xBE\n\r\x3\r\x6\r\xC1\n\r\r"+
		"\r\xE\r\xC2\x3\r\x5\r\xC6\n\r\x5\r\xC8\n\r\x3\xE\x3\xE\x3\xE\x3\xE\x3"+
		"\xE\x5\xE\xCF\n\xE\x3\xF\x6\xF\xD2\n\xF\r\xF\xE\xF\xD3\x3\x10\x6\x10\xD7"+
		"\n\x10\r\x10\xE\x10\xD8\x3\x10\x3\x10\x2\x2\x2\x11\x3\x2\x3\x5\x2\x4\a"+
		"\x2\x5\t\x2\x6\v\x2\a\r\x2\b\xF\x2\t\x11\x2\n\x13\x2\v\x15\x2\f\x17\x2"+
		"\r\x19\x2\xE\x1B\x2\xF\x1D\x2\x10\x1F\x2\x11\x3\x2\n\x5\x2\x32;\x43\\"+
		"\x63|\x4\x2\x32;\x43H\x3\x2\x43\\\x5\x2\f\f\xF\xF))\x4\x2\v\v))\x5\x2"+
		"\x32;\x43H\x63h\x4\x2\x32;\x43\\\x5\x2\xF\xF\"\"))\x103\x2\x3\x3\x2\x2"+
		"\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2"+
		"\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2"+
		"\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B"+
		"\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x3\x31\x3\x2\x2\x2"+
		"\x5\x33\x3\x2\x2\x2\a\x39\x3\x2\x2\x2\t=\x3\x2\x2\x2\v\x8C\x3\x2\x2\x2"+
		"\r\x8E\x3\x2\x2\x2\xF\x98\x3\x2\x2\x2\x11\xA3\x3\x2\x2\x2\x13\xA7\x3\x2"+
		"\x2\x2\x15\xAD\x3\x2\x2\x2\x17\xB4\x3\x2\x2\x2\x19\xC7\x3\x2\x2\x2\x1B"+
		"\xCE\x3\x2\x2\x2\x1D\xD1\x3\x2\x2\x2\x1F\xD6\x3\x2\x2\x2!\"\aT\x2\x2\""+
		"#\aG\x2\x2#$\aU\x2\x2$\x32\aY\x2\x2%&\aT\x2\x2&\'\aG\x2\x2\'(\aU\x2\x2"+
		"(\x32\a\x44\x2\x2)*\aY\x2\x2*+\aQ\x2\x2+,\aT\x2\x2,\x32\a\x46\x2\x2-."+
		"\a\x44\x2\x2./\a[\x2\x2/\x30\aV\x2\x2\x30\x32\aG\x2\x2\x31!\x3\x2\x2\x2"+
		"\x31%\x3\x2\x2\x2\x31)\x3\x2\x2\x2\x31-\x3\x2\x2\x2\x32\x4\x3\x2\x2\x2"+
		"\x33\x34\aU\x2\x2\x34\x35\aV\x2\x2\x35\x36\a\x43\x2\x2\x36\x37\aT\x2\x2"+
		"\x37\x38\aV\x2\x2\x38\x6\x3\x2\x2\x2\x39:\aG\x2\x2:;\aP\x2\x2;<\a\x46"+
		"\x2\x2<\b\x3\x2\x2\x2=>\aT\x2\x2>?\aU\x2\x2?@\aW\x2\x2@\x41\a\x44\x2\x2"+
		"\x41\n\x3\x2\x2\x2\x42\x43\a\x43\x2\x2\x43\x44\a\x46\x2\x2\x44\x8D\a\x46"+
		"\x2\x2\x45\x46\a\x43\x2\x2\x46G\aP\x2\x2G\x8D\a\x46\x2\x2HI\a\x45\x2\x2"+
		"IJ\aQ\x2\x2JK\aO\x2\x2K\x8D\aR\x2\x2LM\a\x46\x2\x2MN\aK\x2\x2N\x8D\aX"+
		"\x2\x2O\x8D\aL\x2\x2PQ\aL\x2\x2QR\aG\x2\x2R\x8D\aS\x2\x2ST\aL\x2\x2TU"+
		"\aI\x2\x2U\x8D\aV\x2\x2VW\aL\x2\x2WX\aN\x2\x2X\x8D\aV\x2\x2YZ\aL\x2\x2"+
		"Z[\aU\x2\x2[\\\aW\x2\x2\\\x8D\a\x44\x2\x2]^\aN\x2\x2^_\a\x46\x2\x2_\x8D"+
		"\a\x43\x2\x2`\x61\aN\x2\x2\x61\x62\a\x46\x2\x2\x62\x63\a\x45\x2\x2\x63"+
		"\x8D\aJ\x2\x2\x64\x65\aN\x2\x2\x65\x66\a\x46\x2\x2\x66\x8D\aN\x2\x2gh"+
		"\aN\x2\x2hi\a\x46\x2\x2i\x8D\aZ\x2\x2jk\aO\x2\x2kl\aW\x2\x2l\x8D\aN\x2"+
		"\x2mn\aQ\x2\x2n\x8D\aT\x2\x2op\aT\x2\x2p\x8D\a\x46\x2\x2qr\aU\x2\x2rs"+
		"\aV\x2\x2s\x8D\a\x43\x2\x2tu\aU\x2\x2uv\aV\x2\x2vw\a\x45\x2\x2w\x8D\a"+
		"J\x2\x2xy\aU\x2\x2yz\aV\x2\x2z\x8D\aN\x2\x2{|\aU\x2\x2|}\aV\x2\x2}~\a"+
		"U\x2\x2~\x8D\aY\x2\x2\x7F\x80\aU\x2\x2\x80\x81\aV\x2\x2\x81\x8D\aZ\x2"+
		"\x2\x82\x83\aU\x2\x2\x83\x84\aW\x2\x2\x84\x8D\a\x44\x2\x2\x85\x86\aV\x2"+
		"\x2\x86\x8D\a\x46\x2\x2\x87\x88\aV\x2\x2\x88\x89\aK\x2\x2\x89\x8D\aZ\x2"+
		"\x2\x8A\x8B\aY\x2\x2\x8B\x8D\a\x46\x2\x2\x8C\x42\x3\x2\x2\x2\x8C\x45\x3"+
		"\x2\x2\x2\x8CH\x3\x2\x2\x2\x8CL\x3\x2\x2\x2\x8CO\x3\x2\x2\x2\x8CP\x3\x2"+
		"\x2\x2\x8CS\x3\x2\x2\x2\x8CV\x3\x2\x2\x2\x8CY\x3\x2\x2\x2\x8C]\x3\x2\x2"+
		"\x2\x8C`\x3\x2\x2\x2\x8C\x64\x3\x2\x2\x2\x8Cg\x3\x2\x2\x2\x8Cj\x3\x2\x2"+
		"\x2\x8Cm\x3\x2\x2\x2\x8Co\x3\x2\x2\x2\x8Cq\x3\x2\x2\x2\x8Ct\x3\x2\x2\x2"+
		"\x8Cx\x3\x2\x2\x2\x8C{\x3\x2\x2\x2\x8C\x7F\x3\x2\x2\x2\x8C\x82\x3\x2\x2"+
		"\x2\x8C\x85\x3\x2\x2\x2\x8C\x87\x3\x2\x2\x2\x8C\x8A\x3\x2\x2\x2\x8D\f"+
		"\x3\x2\x2\x2\x8E\x8F\a\x45\x2\x2\x8F\x90\a)\x2\x2\x90\x92\x3\x2\x2\x2"+
		"\x91\x93\t\x2\x2\x2\x92\x91\x3\x2\x2\x2\x93\x94\x3\x2\x2\x2\x94\x92\x3"+
		"\x2\x2\x2\x94\x95\x3\x2\x2\x2\x95\x96\x3\x2\x2\x2\x96\x97\a)\x2\x2\x97"+
		"\xE\x3\x2\x2\x2\x98\x99\aZ\x2\x2\x99\x9A\a)\x2\x2\x9A\x9C\x3\x2\x2\x2"+
		"\x9B\x9D\t\x3\x2\x2\x9C\x9B\x3\x2\x2\x2\x9D\x9E\x3\x2\x2\x2\x9E\x9C\x3"+
		"\x2\x2\x2\x9E\x9F\x3\x2\x2\x2\x9F\xA0\x3\x2\x2\x2\xA0\xA1\a)\x2\x2\xA1"+
		"\x10\x3\x2\x2\x2\xA2\xA4\t\x4\x2\x2\xA3\xA2\x3\x2\x2\x2\xA4\xA5\x3\x2"+
		"\x2\x2\xA5\xA3\x3\x2\x2\x2\xA5\xA6\x3\x2\x2\x2\xA6\x12\x3\x2\x2\x2\xA7"+
		"\xA8\a\x44\x2\x2\xA8\xA9\a[\x2\x2\xA9\xAA\aV\x2\x2\xAA\xAB\aG\x2\x2\xAB"+
		"\x14\x3\x2\x2\x2\xAC\xAE\t\x5\x2\x2\xAD\xAC\x3\x2\x2\x2\xAE\xAF\x3\x2"+
		"\x2\x2\xAF\xAD\x3\x2\x2\x2\xAF\xB0\x3\x2\x2\x2\xB0\x16\x3\x2\x2\x2\xB1"+
		"\xB3\t\x6\x2\x2\xB2\xB1\x3\x2\x2\x2\xB3\xB6\x3\x2\x2\x2\xB4\xB2\x3\x2"+
		"\x2\x2\xB4\xB5\x3\x2\x2\x2\xB5\x18\x3\x2\x2\x2\xB6\xB4\x3\x2\x2\x2\xB7"+
		"\xB9\t\a\x2\x2\xB8\xB7\x3\x2\x2\x2\xB9\xBA\x3\x2\x2\x2\xBA\xB8\x3\x2\x2"+
		"\x2\xBA\xBB\x3\x2\x2\x2\xBB\xBD\x3\x2\x2\x2\xBC\xBE\aJ\x2\x2\xBD\xBC\x3"+
		"\x2\x2\x2\xBD\xBE\x3\x2\x2\x2\xBE\xC8\x3\x2\x2\x2\xBF\xC1\t\a\x2\x2\xC0"+
		"\xBF\x3\x2\x2\x2\xC1\xC2\x3\x2\x2\x2\xC2\xC0\x3\x2\x2\x2\xC2\xC3\x3\x2"+
		"\x2\x2\xC3\xC5\x3\x2\x2\x2\xC4\xC6\aj\x2\x2\xC5\xC4\x3\x2\x2\x2\xC5\xC6"+
		"\x3\x2\x2\x2\xC6\xC8\x3\x2\x2\x2\xC7\xB8\x3\x2\x2\x2\xC7\xC0\x3\x2\x2"+
		"\x2\xC8\x1A\x3\x2\x2\x2\xC9\xCA\a.\x2\x2\xCA\xCB\a\"\x2\x2\xCB\xCF\aZ"+
		"\x2\x2\xCC\xCD\a.\x2\x2\xCD\xCF\aZ\x2\x2\xCE\xC9\x3\x2\x2\x2\xCE\xCC\x3"+
		"\x2\x2\x2\xCF\x1C\x3\x2\x2\x2\xD0\xD2\t\b\x2\x2\xD1\xD0\x3\x2\x2\x2\xD2"+
		"\xD3\x3\x2\x2\x2\xD3\xD1\x3\x2\x2\x2\xD3\xD4\x3\x2\x2\x2\xD4\x1E\x3\x2"+
		"\x2\x2\xD5\xD7\t\t\x2\x2\xD6\xD5\x3\x2\x2\x2\xD7\xD8\x3\x2\x2\x2\xD8\xD6"+
		"\x3\x2\x2\x2\xD8\xD9\x3\x2\x2\x2\xD9\xDA\x3\x2\x2\x2\xDA\xDB\b\x10\x2"+
		"\x2\xDB \x3\x2\x2\x2\x12\x2\x31\x8C\x94\x9E\xA5\xAF\xB4\xBA\xBD\xC2\xC5"+
		"\xC7\xCE\xD3\xD8\x3\b\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace AnalizadorSIC_GRAFICO