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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IGramaticaSIC_STDVisitor{Result}"/>,
/// which can be extended to create a visitor which only needs to handle a subset
/// of the available methods.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class GramaticaSIC_STDBaseVisitor<Result> : AbstractParseTreeVisitor<Result>, IGramaticaSIC_STDVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by the <c>programIni</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.programa"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProgramIni([NotNull] GramaticaSIC_STDParser.ProgramIniContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>inicioPro</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.inicio"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInicioPro([NotNull] GramaticaSIC_STDParser.InicioProContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>inicioEti</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.inicio"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInicioEti([NotNull] GramaticaSIC_STDParser.InicioEtiContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>directivaExisten</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.directiva"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDirectivaExisten([NotNull] GramaticaSIC_STDParser.DirectivaExistenContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>instrRSUB</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.instruccion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInstrRSUB([NotNull] GramaticaSIC_STDParser.InstrRSUBContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>instruccionVisitor</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.instruccion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInstruccionVisitor([NotNull] GramaticaSIC_STDParser.InstruccionVisitorContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>proposicionDuplicada</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposiciones"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProposicionDuplicada([NotNull] GramaticaSIC_STDParser.ProposicionDuplicadaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>proposicionInst</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposiciones"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProposicionInst([NotNull] GramaticaSIC_STDParser.ProposicionInstContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>endfinaltotal</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.final"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEndfinaltotal([NotNull] GramaticaSIC_STDParser.EndfinaltotalContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>finEntrada</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.final"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFinEntrada([NotNull] GramaticaSIC_STDParser.FinEntradaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>finalSinEntrada</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.final"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFinalSinEntrada([NotNull] GramaticaSIC_STDParser.FinalSinEntradaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>propsicionInstruccion</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposicion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitPropsicionInstruccion([NotNull] GramaticaSIC_STDParser.PropsicionInstruccionContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>propsicionDirectiva</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposicion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitPropsicionDirectiva([NotNull] GramaticaSIC_STDParser.PropsicionDirectivaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>error</c>
	/// labeled alternative in <see cref="GramaticaSIC_STDParser.proposicion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitError([NotNull] GramaticaSIC_STDParser.ErrorContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.programa"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitPrograma([NotNull] GramaticaSIC_STDParser.ProgramaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.inicio"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInicio([NotNull] GramaticaSIC_STDParser.InicioContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.final"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFinal([NotNull] GramaticaSIC_STDParser.FinalContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.entrada"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEntrada([NotNull] GramaticaSIC_STDParser.EntradaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.proposiciones"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProposiciones([NotNull] GramaticaSIC_STDParser.ProposicionesContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.proposicion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProposicion([NotNull] GramaticaSIC_STDParser.ProposicionContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.instruccion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInstruccion([NotNull] GramaticaSIC_STDParser.InstruccionContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.directiva"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDirectiva([NotNull] GramaticaSIC_STDParser.DirectivaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.etiqueta"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEtiqueta([NotNull] GramaticaSIC_STDParser.EtiquetaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.opinstruccion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitOpinstruccion([NotNull] GramaticaSIC_STDParser.OpinstruccionContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.indexado"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIndexado([NotNull] GramaticaSIC_STDParser.IndexadoContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.opdirectiva"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitOpdirectiva([NotNull] GramaticaSIC_STDParser.OpdirectivaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_STDParser.tipoByte"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitTipoByte([NotNull] GramaticaSIC_STDParser.TipoByteContext context) { return VisitChildren(context); }
}
} // namespace AnalizadorSIC_GRAFICO
