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
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="GramaticaSIC_STDParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IGramaticaSIC_STDListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>programIni</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.programa"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgramIni([NotNull] GramaticaSIC_STDParser.ProgramIniContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>programIni</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.programa"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgramIni([NotNull] GramaticaSIC_STDParser.ProgramIniContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>inicioPro</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.inicio"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInicioPro([NotNull] GramaticaSIC_STDParser.InicioProContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>inicioPro</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.inicio"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInicioPro([NotNull] GramaticaSIC_STDParser.InicioProContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>inicioEti</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.inicio"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInicioEti([NotNull] GramaticaSIC_STDParser.InicioEtiContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>inicioEti</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.inicio"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInicioEti([NotNull] GramaticaSIC_STDParser.InicioEtiContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>directivaExisten</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.directiva"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDirectivaExisten([NotNull] GramaticaSIC_STDParser.DirectivaExistenContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>directivaExisten</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.directiva"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDirectivaExisten([NotNull] GramaticaSIC_STDParser.DirectivaExistenContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>instrRSUB</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.instruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstrRSUB([NotNull] GramaticaSIC_STDParser.InstrRSUBContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>instrRSUB</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.instruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstrRSUB([NotNull] GramaticaSIC_STDParser.InstrRSUBContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>instruccionVisitor</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.instruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstruccionVisitor([NotNull] GramaticaSIC_STDParser.InstruccionVisitorContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>instruccionVisitor</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.instruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstruccionVisitor([NotNull] GramaticaSIC_STDParser.InstruccionVisitorContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>proposicionDuplicada</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposiciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProposicionDuplicada([NotNull] GramaticaSIC_STDParser.ProposicionDuplicadaContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>proposicionDuplicada</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposiciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProposicionDuplicada([NotNull] GramaticaSIC_STDParser.ProposicionDuplicadaContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>proposicionInst</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposiciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProposicionInst([NotNull] GramaticaSIC_STDParser.ProposicionInstContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>proposicionInst</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposiciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProposicionInst([NotNull] GramaticaSIC_STDParser.ProposicionInstContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>endfinaltotal</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.final"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEndfinaltotal([NotNull] GramaticaSIC_STDParser.EndfinaltotalContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>endfinaltotal</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.final"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEndfinaltotal([NotNull] GramaticaSIC_STDParser.EndfinaltotalContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>finEntrada</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.final"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFinEntrada([NotNull] GramaticaSIC_STDParser.FinEntradaContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>finEntrada</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.final"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFinEntrada([NotNull] GramaticaSIC_STDParser.FinEntradaContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>finalSinEntrada</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.final"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFinalSinEntrada([NotNull] GramaticaSIC_STDParser.FinalSinEntradaContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>finalSinEntrada</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.final"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFinalSinEntrada([NotNull] GramaticaSIC_STDParser.FinalSinEntradaContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>propsicionInstruccion</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposicion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropsicionInstruccion([NotNull] GramaticaSIC_STDParser.PropsicionInstruccionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>propsicionInstruccion</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposicion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropsicionInstruccion([NotNull] GramaticaSIC_STDParser.PropsicionInstruccionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>propsicionDirectiva</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposicion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropsicionDirectiva([NotNull] GramaticaSIC_STDParser.PropsicionDirectivaContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>propsicionDirectiva</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposicion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropsicionDirectiva([NotNull] GramaticaSIC_STDParser.PropsicionDirectivaContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>error</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposicion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterError([NotNull] GramaticaSIC_STDParser.ErrorContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>error</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposicion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitError([NotNull] GramaticaSIC_STDParser.ErrorContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.programa"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrograma([NotNull] GramaticaSIC_STDParser.ProgramaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.programa"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrograma([NotNull] GramaticaSIC_STDParser.ProgramaContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.inicio"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInicio([NotNull] GramaticaSIC_STDParser.InicioContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.inicio"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInicio([NotNull] GramaticaSIC_STDParser.InicioContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.final"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFinal([NotNull] GramaticaSIC_STDParser.FinalContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.final"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFinal([NotNull] GramaticaSIC_STDParser.FinalContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.entrada"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEntrada([NotNull] GramaticaSIC_STDParser.EntradaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.entrada"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEntrada([NotNull] GramaticaSIC_STDParser.EntradaContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.proposiciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProposiciones([NotNull] GramaticaSIC_STDParser.ProposicionesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.proposiciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProposiciones([NotNull] GramaticaSIC_STDParser.ProposicionesContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.proposicion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProposicion([NotNull] GramaticaSIC_STDParser.ProposicionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.proposicion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProposicion([NotNull] GramaticaSIC_STDParser.ProposicionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.instruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstruccion([NotNull] GramaticaSIC_STDParser.InstruccionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.instruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstruccion([NotNull] GramaticaSIC_STDParser.InstruccionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.directiva"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDirectiva([NotNull] GramaticaSIC_STDParser.DirectivaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.directiva"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDirectiva([NotNull] GramaticaSIC_STDParser.DirectivaContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.etiqueta"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEtiqueta([NotNull] GramaticaSIC_STDParser.EtiquetaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.etiqueta"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEtiqueta([NotNull] GramaticaSIC_STDParser.EtiquetaContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.opinstruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOpinstruccion([NotNull] GramaticaSIC_STDParser.OpinstruccionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.opinstruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOpinstruccion([NotNull] GramaticaSIC_STDParser.OpinstruccionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.indexado"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndexado([NotNull] GramaticaSIC_STDParser.IndexadoContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.indexado"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndexado([NotNull] GramaticaSIC_STDParser.IndexadoContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.opdirectiva"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOpdirectiva([NotNull] GramaticaSIC_STDParser.OpdirectivaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.opdirectiva"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOpdirectiva([NotNull] GramaticaSIC_STDParser.OpdirectivaContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaSIC_STDParser.tipoByte"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTipoByte([NotNull] GramaticaSIC_STDParser.TipoByteContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaSIC_STDParser.tipoByte"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTipoByte([NotNull] GramaticaSIC_STDParser.TipoByteContext context);
}
} // namespace AnalizadorSIC_GRAFICO
