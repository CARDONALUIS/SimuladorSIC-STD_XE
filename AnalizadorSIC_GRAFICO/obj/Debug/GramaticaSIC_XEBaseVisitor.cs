//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\lluis\Documents\9no Semestre\Labo ProDeSistemas\Practica12\Proyecto LISTO\AnalizadorSIC_GRAFICO\AnalizadorSIC_GRAFICO\GramaticaSIC_XE.g4 by ANTLR 4.6.6

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
/// This class provides an empty implementation of <see cref="IGramaticaSIC_XEVisitor{Result}"/>,
/// which can be extended to create a visitor which only needs to handle a subset
/// of the available methods.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class GramaticaSIC_XEBaseVisitor<Result> : AbstractParseTreeVisitor<Result>, IGramaticaSIC_XEVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by the <c>formato1</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.formato"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFormato1([NotNull] GramaticaSIC_XEParser.Formato1Context context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>formato3</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.formato"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFormato3([NotNull] GramaticaSIC_XEParser.Formato3Context context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>formato2</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.formato"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFormato2([NotNull] GramaticaSIC_XEParser.Formato2Context context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>programIni</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.programa"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProgramIni([NotNull] GramaticaSIC_XEParser.ProgramIniContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>inicioPro</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.inicio"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInicioPro([NotNull] GramaticaSIC_XEParser.InicioProContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>inicioEti</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.inicio"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInicioEti([NotNull] GramaticaSIC_XEParser.InicioEtiContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>directivaBase</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.directiva"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDirectivaBase([NotNull] GramaticaSIC_XEParser.DirectivaBaseContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>directivaExisten</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.directiva"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDirectivaExisten([NotNull] GramaticaSIC_XEParser.DirectivaExistenContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>proposicionDuplicada</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.proposiciones"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProposicionDuplicada([NotNull] GramaticaSIC_XEParser.ProposicionDuplicadaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>proposicionInst</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.proposiciones"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProposicionInst([NotNull] GramaticaSIC_XEParser.ProposicionInstContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>endfinaltotal</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.final"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEndfinaltotal([NotNull] GramaticaSIC_XEParser.EndfinaltotalContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>finEntrada</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.final"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFinEntrada([NotNull] GramaticaSIC_XEParser.FinEntradaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>finalSinEntrada</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.final"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFinalSinEntrada([NotNull] GramaticaSIC_XEParser.FinalSinEntradaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>visinstrRSUB</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.for34"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitVisinstrRSUB([NotNull] GramaticaSIC_XEParser.VisinstrRSUBContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>visformato3_IND</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.for34"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitVisformato3_IND([NotNull] GramaticaSIC_XEParser.Visformato3_INDContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>visformato4_INM</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.for34"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitVisformato4_INM([NotNull] GramaticaSIC_XEParser.Visformato4_INMContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>visformato4_SIM</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.for34"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitVisformato4_SIM([NotNull] GramaticaSIC_XEParser.Visformato4_SIMContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>visformato3_SIM</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.for34"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitVisformato3_SIM([NotNull] GramaticaSIC_XEParser.Visformato3_SIMContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>visformato4_IND</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.for34"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitVisformato4_IND([NotNull] GramaticaSIC_XEParser.Visformato4_INDContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>visformato3_INM</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.for34"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitVisformato3_INM([NotNull] GramaticaSIC_XEParser.Visformato3_INMContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>propsicionInstruccion</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.proposicion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitPropsicionInstruccion([NotNull] GramaticaSIC_XEParser.PropsicionInstruccionContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>error</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.proposicion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitError([NotNull] GramaticaSIC_XEParser.ErrorContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>proposicionDirectiva</c>
	/// labeled alternative in <see cref="GramaticaSIC_XEParser.proposicion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProposicionDirectiva([NotNull] GramaticaSIC_XEParser.ProposicionDirectivaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.programa"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitPrograma([NotNull] GramaticaSIC_XEParser.ProgramaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.inicio"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInicio([NotNull] GramaticaSIC_XEParser.InicioContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.final"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFinal([NotNull] GramaticaSIC_XEParser.FinalContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.entrada"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEntrada([NotNull] GramaticaSIC_XEParser.EntradaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.proposiciones"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProposiciones([NotNull] GramaticaSIC_XEParser.ProposicionesContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.proposicion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProposicion([NotNull] GramaticaSIC_XEParser.ProposicionContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.formato"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFormato([NotNull] GramaticaSIC_XEParser.FormatoContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.for1"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFor1([NotNull] GramaticaSIC_XEParser.For1Context context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.for2"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFor2([NotNull] GramaticaSIC_XEParser.For2Context context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.for34"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFor34([NotNull] GramaticaSIC_XEParser.For34Context context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.directiva"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDirectiva([NotNull] GramaticaSIC_XEParser.DirectivaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.etiqueta"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEtiqueta([NotNull] GramaticaSIC_XEParser.EtiquetaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.simple"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSimple([NotNull] GramaticaSIC_XEParser.SimpleContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.indirecto"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIndirecto([NotNull] GramaticaSIC_XEParser.IndirectoContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.inmediato"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInmediato([NotNull] GramaticaSIC_XEParser.InmediatoContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.indexado"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIndexado([NotNull] GramaticaSIC_XEParser.IndexadoContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.opdirectiva"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitOpdirectiva([NotNull] GramaticaSIC_XEParser.OpdirectivaContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.tipoByte"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitTipoByte([NotNull] GramaticaSIC_XEParser.TipoByteContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.registros"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitRegistros([NotNull] GramaticaSIC_XEParser.RegistrosContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="GramaticaSIC_XEParser.opBase"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitOpBase([NotNull] GramaticaSIC_XEParser.OpBaseContext context) { return VisitChildren(context); }
}
} // namespace AnalizadorSIC_GRAFICO
