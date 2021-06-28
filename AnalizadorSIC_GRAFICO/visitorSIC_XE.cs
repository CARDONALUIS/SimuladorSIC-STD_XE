using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using System.IO;
using System.Linq;

namespace AnalizadorSIC_GRAFICO
{
    public class visitorSIC_XE : GramaticaSIC_XEBaseVisitor<int>
    {
        int r = 0;
        string CP = "000000";
        public string CPInicio = "";
        public string DirCarga = "";
        public List<string> ListCP;
        public List<codigo> lineasprogramaCompleto;
        public List<int> lineasConError;
        public bool bandFor4 = false;
        public List<int> lineasSimDupli;
        public List<tabSim> simDir;
        public List<ConjInstrF2> listInstF2;
        public List<ConjInstrF1> listInstF1;
        public List<registros> lisReg;
        public FileStream arInter;
        public FileStream arProgramaObjeto;
        int numlineaActual = 1;
        string cadReservada;
        string[] lineaCodigo;
        int conCadErrorGlo = 0;
        public List<ConjInst> listInst;
        public bool dirBase = false;
        public string opBase = "";
        public string valorBase = "";
        public string tamCod;
        int contPreElim;
        public string cadRegisGlobal;


        public visitorSIC_XE(FileStream _archivo)
        {
            lineasConError = new List<int>();
            if (arInter != null)
                arInter.Close();
            arInter = new FileStream("Intermedio.tx", FileMode.Create);
            arProgramaObjeto = new FileStream("Objeto.objtx", FileMode.Create);

            ListCP = new List<string>();
            lineasprogramaCompleto = new List<codigo>();
            lineasSimDupli = new List<int>();
            simDir = new List<tabSim>();
            listInst = new List<ConjInst>();
            listInstF2 = new List<ConjInstrF2>();
            listInstF1 = new List<ConjInstrF1>();
            lisReg = new List<registros>();
            iniConIntrF1();
            iniConIntrF2();
            iniConIntr();
            iniRegistros();

            obtenCadenaArchivo(_archivo);

        }

        //DETECTA ERRORES
        public override int VisitError([NotNull] GramaticaSIC_XEParser.ErrorContext context)
        {
            string cadAReco = context.GetText();

            int b = 0;
            //Error de sintaxis comun
            //if (cadAReco == "\r\n" || cadAReco == "\n" || cadAReco == "'\\r\n")
            if (cadAReco[cadAReco.Length - 1] == '\n')
            {
                lineasConError.Add(numlineaActual);
                agregaLineaErrorSintaxis();
                conCadErrorGlo = 0;
            }
            else//Error de sintaxis por palabra reservada
            {
                if (conCadErrorGlo == 0)
                {
                    ConjInst a = listInst.Find(x => x.nemonico == cadAReco);
                    int z = 0;
                    if (a != null || cadAReco == "BYTE" || cadAReco == "RESW" || cadAReco == "RESB" || cadAReco == "WORD" || cadAReco == "BASE" || cadAReco == "END" || cadAReco == "START")
                    {
                        lineasConError.Add(numlineaActual);
                        cadReservada = cadAReco;
                        conCadErrorGlo = 0;
                    }
                    else
                        conCadErrorGlo++;
                }
                else
                    conCadErrorGlo++;
            }

            return base.VisitError(context);
        }

        //Inicio
        public override int VisitInicioEti([NotNull] GramaticaSIC_XEParser.InicioEtiContext context)
        {
            string cadFinal;
            codigo ins = new codigo();


            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];
                CP = rellanaPalabra(CP);

                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;
                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                // ins.cadErrorLinea = cadError;
                ins.esInsError = true;
                string[] arr = cadError.Split('\t');
                ins.etiqueta = arr[0] + "\t";
                ins.instruccion = arr[1] + "\t";
                ins.operando = arr[2] + "\n";
            }
            else
            {

                string cp = "";

                string etiqueta = context.etiqueta().GetText();
                r = 0;
                string direccionIni = context.NUM().GetText();
                r = 0;
                cp = tranformaAHexa(direccionIni);

                CP = rellanaPalabra(cp);

                string directivaSTART = context.DIRSTART().GetText();

                cadFinal = etiqueta + "\t" + directivaSTART + "\t" + direccionIni;
                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.CP = CP + "\t";
                ins.instruccion = directivaSTART + "\t";
                ins.operando = direccionIni;

                r = 0;
            }
            r = 0;

            CPInicio = CP;


            r = 0;

            numlineaActual++;

            lineasprogramaCompleto.Add(ins);
            return base.VisitInicioEti(context);
        }

        //Formato1
        public override int VisitFormato1([NotNull] GramaticaSIC_XEParser.Formato1Context context)
        {
            string cadFinal;
            codigo ins = new codigo();

            CP = rellanaPalabra(CP);

            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];
                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;


                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.esInsError = true;
                r = 0;
                string[] arr = cadError.Split('\t');
                ins.etiqueta = arr[0] + "\t";
                ins.instruccion = arr[1] + "\t";
                ins.operando = arr[2] + "\n";
                //ins.cadErrorLinea = cadFinal;

            }
            else
            {
                string etiqueta = context.for1().etiqueta().GetText();
                string instru = context.for1().OP1().GetText();

                r = 0;
                añadirATabSim(etiqueta, numlineaActual);

                cadFinal = etiqueta + "\t" + instru;

                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.instruccion = instru + "\t";


                CP = sumaHex(CP, "1");



                r = 0;
            }


            lineasprogramaCompleto.Add(ins);



            r = 0;

            numlineaActual++;

            return base.VisitFormato1(context);
        }

        //Formato2
        public override int VisitFormato2([NotNull] GramaticaSIC_XEParser.Formato2Context context)
        {
            r = 0;
            string cadFinal;
            codigo ins = new codigo();

            CP = rellanaPalabra(CP);

            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];
                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;


                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.esInsError = true;
                r = 0;
                string[] arr = cadError.Split('\t');
                ins.etiqueta = arr[0] + "\t";
                ins.instruccion = arr[1] + "\t";
                ins.operando = arr[2] + "\n";
                //ins.cadErrorLinea = cadFinal;

            }
            else
            {
                string etiqueta = context.for2().etiqueta().GetText();
                string instru = context.for2().OP2().GetText();
                string operando = context.for2().registros().GetText();

                r = 0;
                añadirATabSim(etiqueta, numlineaActual);

                cadFinal = etiqueta + "\t" + instru + "\t" + operando;

                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.instruccion = instru + "\t";
                ins.operando = operando;

                CP = sumaHex(CP, "2");



                r = 0;
            }


            lineasprogramaCompleto.Add(ins);

            r = 0;

            numlineaActual++;

            return base.VisitFormato2(context);
        }


        //formato3 indirecto
        public override int VisitVisformato3_IND([NotNull] GramaticaSIC_XEParser.Visformato3_INDContext context)
        {
            string cadFinal;
            codigo ins = new codigo();

            CP = rellanaPalabra(CP);

            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];
                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;


                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.esInsError = true;
                r = 0;
                string[] arr = cadError.Split('\t');
                ins.etiqueta = arr[0] + "\t";
                ins.instruccion = arr[1] + "\t";
                ins.operando = arr[2] + "\n";
                //ins.cadErrorLinea = cadFinal;

            }
            else
            {
                string etiqueta = context.etiqueta().GetText();
                string instru = context.CODOP().GetText();
                string operando = context.indirecto().GetText();

                r = 0;
                añadirATabSim(etiqueta, numlineaActual);

                cadFinal = etiqueta + "\t" + instru + "\t" + operando;

                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.instruccion = instru + "\t";
                ins.operando = operando;

                CP = sumaHex(CP, "3");



                r = 0;
            }


            lineasprogramaCompleto.Add(ins);
            r = 0;
            numlineaActual++;

            return base.VisitVisformato3_IND(context);

        }

        //formato3 inmediato
        public override int VisitVisformato3_INM([NotNull] GramaticaSIC_XEParser.Visformato3_INMContext context)
        {

            string cadFinal;
            codigo ins = new codigo();

            CP = rellanaPalabra(CP);

            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];
                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;


                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.esInsError = true;
                r = 0;
                string[] arr = cadError.Split('\t');
                ins.etiqueta = arr[0] + "\t";
                ins.instruccion = arr[1] + "\t";
                ins.operando = arr[2] + "\n";
                //ins.cadErrorLinea = cadFinal;

            }
            else
            {
                string etiqueta = context.etiqueta().GetText();
                string instru = context.CODOP().GetText();
                string operando = context.inmediato().GetText();

                r = 0;
                añadirATabSim(etiqueta, numlineaActual);

                cadFinal = etiqueta + "\t" + instru + "\t" + operando;

                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.instruccion = instru + "\t";
                ins.operando = operando;

                CP = sumaHex(CP, "3");



                r = 0;
            }


            lineasprogramaCompleto.Add(ins);
            r = 0;
            numlineaActual++;


            return base.VisitVisformato3_INM(context);
        }


        //formato3 Simple
        public override int VisitVisformato3_SIM([NotNull] GramaticaSIC_XEParser.Visformato3_SIMContext context)
        {
            string cadFinal;
            codigo ins = new codigo();

            CP = rellanaPalabra(CP);

            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];
                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;


                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.esInsError = true;
                r = 0;
                string[] arr = cadError.Split('\t');
                ins.etiqueta = arr[0] + "\t";
                ins.instruccion = arr[1] + "\t";
                ins.operando = arr[2] + "\n";
                //ins.cadErrorLinea = cadFinal;

            }
            else
            {
                string etiqueta = context.etiqueta().GetText();
                string instru = context.CODOP().GetText();
                string operando = context.simple().GetText();

                r = 0;
                añadirATabSim(etiqueta, numlineaActual);

                cadFinal = etiqueta + "\t" + instru + "\t" + operando;

                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.instruccion = instru + "\t";
                ins.operando = operando;

                CP = sumaHex(CP, "3");



                r = 0;
            }


            lineasprogramaCompleto.Add(ins);
            r = 0;
            numlineaActual++;

            return base.VisitVisformato3_SIM(context);
        }

        //formato4 Simple
        public override int VisitVisformato4_SIM([NotNull] GramaticaSIC_XEParser.Visformato4_SIMContext context)
        {
            string cadFinal;
            codigo ins = new codigo();

            CP = rellanaPalabra(CP);

            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];
                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;


                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.esInsError = true;
                r = 0;
                string[] arr = cadError.Split('\t');
                ins.etiqueta = arr[0] + "\t";
                ins.instruccion = arr[1] + "\t";
                ins.operando = arr[2] + "\n";
                //ins.cadErrorLinea = cadFinal;

            }
            else
            {
                string etiqueta = context.etiqueta().GetText();
                string instru = context.CODOP().GetText();
                string operando = context.simple().GetText();

                r = 0;
                añadirATabSim(etiqueta, numlineaActual);

                cadFinal = etiqueta + "\t" + instru + "\t" + operando;

                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.instruccion = "+" + instru + "\t";
                ins.operando = operando;

                CP = sumaHex(CP, "4");



                r = 0;
            }


            lineasprogramaCompleto.Add(ins);
            r = 0;
            numlineaActual++;
            r = 0;
            return base.VisitVisformato4_SIM(context);
        }

        //formato4 indirecto
        public override int VisitVisformato4_IND([NotNull] GramaticaSIC_XEParser.Visformato4_INDContext context)
        {
            string cadFinal;
            codigo ins = new codigo();

            CP = rellanaPalabra(CP);

            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];
                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;


                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.esInsError = true;
                r = 0;
                string[] arr = cadError.Split('\t');
                ins.etiqueta = arr[0] + "\t";
                ins.instruccion = arr[1] + "\t";
                ins.operando = arr[2] + "\n";
                //ins.cadErrorLinea = cadFinal;

            }
            else
            {
                string etiqueta = context.etiqueta().GetText();
                string instru = context.CODOP().GetText();
                string operando = context.indirecto().GetText();

                r = 0;
                añadirATabSim(etiqueta, numlineaActual);

                cadFinal = etiqueta + "\t" + instru + "\t" + operando;

                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.instruccion = "+" + instru + "\t";
                ins.operando = operando;

                CP = sumaHex(CP, "4");



                r = 0;
            }


            lineasprogramaCompleto.Add(ins);
            r = 0;
            numlineaActual++;
            r = 0;
            return base.VisitVisformato4_IND(context);
        }

        //formato4 inmediato
        public override int VisitVisformato4_INM([NotNull] GramaticaSIC_XEParser.Visformato4_INMContext context)
        {
            string cadFinal;
            codigo ins = new codigo();

            CP = rellanaPalabra(CP);

            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];
                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;


                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.esInsError = true;
                r = 0;
                string[] arr = cadError.Split('\t');
                ins.etiqueta = arr[0] + "\t";
                ins.instruccion = arr[1] + "\t";
                ins.operando = arr[2] + "\n";
                //ins.cadErrorLinea = cadFinal;

            }
            else
            {
                string etiqueta = context.etiqueta().GetText();
                string instru = context.CODOP().GetText();
                string operando = context.inmediato().GetText();

                r = 0;
                añadirATabSim(etiqueta, numlineaActual);

                cadFinal = etiqueta + "\t" + instru + "\t" + operando;

                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.instruccion = "+" + instru + "\t";
                ins.operando = operando;

                CP = sumaHex(CP, "4");



                r = 0;
            }


            lineasprogramaCompleto.Add(ins);
            r = 0;
            numlineaActual++;
            r = 0;
            return base.VisitVisformato4_INM(context);
        }


        //RSUB
        public override int VisitVisinstrRSUB([NotNull] GramaticaSIC_XEParser.VisinstrRSUBContext context)
        {
            string cadFinal;
            CP = rellanaPalabra(CP);
            codigo ins = new codigo();

            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];
                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;
                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.esInsError = true;
                //ins.cadErrorLinea = cadError;
                string[] arr = cadError.Split('\t');
                ins.etiqueta = arr[0] + "\t";
                ins.instruccion = arr[1] + "\t";
                ins.operando = arr[2] + "\n";

            }
            else
            {


                string etiqueta = context.etiqueta().GetText();

                string directiva = context.TRSUB().GetText();

                r = 0;



                añadirATabSim(etiqueta, numlineaActual);

                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + etiqueta + "\t" + directiva;

                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.instruccion = directiva;

                CP = sumaHex(CP, "3");

            }


            lineasprogramaCompleto.Add(ins);

            numlineaActual++;

            return base.VisitVisinstrRSUB(context);
        }


        //DIRECTIVA BASE
        public override int VisitDirectivaBase([NotNull] GramaticaSIC_XEParser.DirectivaBaseContext context)
        {
            string cadFinal;
            codigo ins = new codigo();
            CP = rellanaPalabra(CP);

            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];


                r = 0;
                string[] arr = cadError.Split('\t');
                r = 0;
                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;


                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.esInsError = true;
                ins.CP = CP + "\t";
                ins.etiqueta = arr[0] + "\t";
                ins.instruccion = arr[1] + "\t";
                ins.operando = arr[2] + "\n";
                //ins.cadErrorLinea = cadError;
                r = 0;
            }
            else
            {
                string etiqueta = context.etiqueta().GetText();
                string directiva = "BASE";
                string operando = context.opBase().GetText();

                r = 0;
                opBase = operando;
                añadirATabSim(etiqueta, numlineaActual);

                cadFinal = etiqueta + "\t" + directiva + "\t" + operando;

                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.instruccion = directiva + "\t";
                ins.operando = operando;

            }

            lineasprogramaCompleto.Add(ins);
            numlineaActual++;

            dirBase = true;

            r = 0;
            return base.VisitDirectivaBase(context);
        }


        //Directiva
        public override int VisitDirectivaExisten([NotNull] GramaticaSIC_XEParser.DirectivaExistenContext context)
        {
            string cadFinal;
            codigo ins = new codigo();
            CP = rellanaPalabra(CP);

            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];


                r = 0;
                string[] arr = cadError.Split('\t');
                r = 0;
                cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;


                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.esInsError = true;
                ins.CP = CP + "\t";
                ins.etiqueta = arr[0] + "\t";
                ins.instruccion = arr[1] + "\t";
                ins.operando = arr[2] + "\n";
                //ins.cadErrorLinea = cadError;
                r = 0;
            }
            else
            {
                string etiqueta = context.etiqueta().GetText();
                string directiva = context.TIPODIRECTIVA().GetText();
                string operando = context.opdirectiva().GetText();

                r = 0;

                añadirATabSim(etiqueta, numlineaActual);

                cadFinal = etiqueta + "\t" + directiva + "\t" + operando;

                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.instruccion = directiva + "\t";
                ins.operando = operando;

                r = 0;
                if (directiva != "BYTE")
                    CP = sumaHex(CP, obtenValorDirectiva(directiva, operando));
                else
                {
                    int valorASuma = obtenValorByte(operando);
                    CP = sumaHex(CP, tranformaAHexa(valorASuma.ToString()));
                }
            }

            lineasprogramaCompleto.Add(ins);
            numlineaActual++;

            r = 0;
            return base.VisitDirectivaExisten(context);
        }


        //DIRECTIVA FINAL 1
        public override int VisitFinEntrada([NotNull] GramaticaSIC_XEParser.FinEntradaContext context)
        {
            r = 0;
            string cadFinal = "";
            codigo ins = new codigo();

            CP = rellanaPalabra(CP);

            string directiva = context.DIREND().GetText();
            string simbolo = context.entrada().GetText();

            cadFinal = directiva + "\t" + simbolo;
            ins.linea = "\n" + numlineaActual.ToString() + "\t";
            ins.instruccion = directiva + "\t";
            ins.CP = CP + "\t";
            ins.operando = simbolo;

            r = 0;
            lineasprogramaCompleto.Add(ins);
            if (dirBase)
                asignaBase();

            r = 0;
            escribeArchivo();
            //escribeArchivoTabSim();
            tamCod = rellanaPalabra(tranformaAHexa((Convert.ToInt32(CP, 16) - (Convert.ToInt32(CPInicio, 16))).ToString().ToUpper()));

            hazProgramaObjeto();


            numlineaActual++;
            

            return base.VisitFinEntrada(context);
        }


        //DIRECTIVA FINAL 2
        public override int VisitFinalSinEntrada([NotNull] GramaticaSIC_XEParser.FinalSinEntradaContext context)
        {
            r = 0;
            string cadFinal = "";
            codigo ins = new codigo();

            CP = rellanaPalabra(CP);

            string directiva = context.DIREND().GetText();


            cadFinal = directiva;
            ins.linea = "\n" + numlineaActual.ToString() + "\t";
            ins.instruccion = directiva + "\t";
            ins.CP = CP + "\t";

            lineasprogramaCompleto.Add(ins);
            if (dirBase)
                asignaBase();

            escribeArchivo();
            //escribeArchivoTabSim();
            tamCod = rellanaPalabra(tranformaAHexa((Convert.ToInt32(CP, 16) - (Convert.ToInt32(CPInicio, 16))).ToString().ToUpper()));

            hazProgramaObjeto();


            numlineaActual++;


            

            return base.VisitFinalSinEntrada(context);
        }



        //METODO AUXILIARES

        public void asignaBase()
        {
            foreach (tabSim a in simDir)
            {
                if (a.simbolo == opBase)
                {
                    valorBase = a.direccion;
                }
            }
        }

        public void hazProgramaObjeto()
        {
            string cadReg = "\n";


            codigo start = lineasprogramaCompleto.Find(x => x.instruccion == "START\t");
            codigo end = lineasprogramaCompleto.Find(x => x.instruccion == "END\t");

            string nomPro;

            if (start.etiqueta.Length >= 6)
            {
                nomPro = start.etiqueta.Substring(0, 6);
                r = 0;
            }
            else
            {
                int con = start.etiqueta.Length;
                nomPro = start.etiqueta;
                string temp = "";
                r = 0;
                while (con <= 6)
                {
                    temp += "_";
                    con++;

                }
                nomPro = nomPro.Insert(start.etiqueta.Length - 1, temp);
                //nomPro = nomPro.Remove(start.etiqueta.Length);
                r = 0;
                nomPro = nomPro.Remove(nomPro.Length - 1);
                r = 0;
            }

            r = 0;

            codigo primerIns = lineasprogramaCompleto.Find(x => x.instruccion != "START\t" && x.instruccion != "RESW\t" && x.instruccion != "RESB\t" && x.instruccion != "WORD\t" && x.instruccion != "BYTE\t");

            r = 0;
            cadReg += "H" + nomPro + primerIns.CP.Remove(primerIns.CP.Length - 1) + tamCod + "\n";
            r = 0;
            cadReg += llenaRegistroT(cadReg);

            cadReg += llenaRegistrM();

            //Registro END
            r = 0;
            if (end.operando != "")
            {
                tabSim algo = simDir.Find(x => x.simbolo == end.operando);
                cadReg += "\nE" + algo.direccion + "\n";
                DirCarga = algo.direccion;
                r = 0;
            }
            else
            {
                cadReg += "\nE" + primerIns.CP + "\n";
                DirCarga = primerIns.CP;
                r = 0;
            }
            r = 0;
            cadRegisGlobal = cadReg;
            r = 0;
            escribeArchivoProgramaObjeto(cadReg);

        }

        public void escribeArchivoProgramaObjeto(string cad)
        {
            arProgramaObjeto.Close();
            using (BinaryWriter bw = new BinaryWriter(File.Open(arProgramaObjeto.Name, FileMode.Open)))
            //using (BinaryWriter bw = new BinaryWriter(arInter))
            {
                bw.Write(cad);
            }
        }


        public string llenaRegistrM()
        {
            string cadRegM = "\n";
            string nomProg = "";

            if(lineasprogramaCompleto[0].etiqueta.Length >= 6)
            {
                nomProg = lineasprogramaCompleto[0].etiqueta.Substring(0, 6);
            }
            else
            {
                for (int j = 0; j < lineasprogramaCompleto[0].etiqueta.Length; j++)
                {
                    nomProg += lineasprogramaCompleto[0].etiqueta[j];
                }

            }

            

            for(int i = 0; i < lineasprogramaCompleto.Count; i++)
            {
                if(lineasprogramaCompleto[i].esRelocalisable)
                {
                    cadRegM += "M"+rellanaPalabra(sumaHex(lineasprogramaCompleto[i].CP.Substring(0,6),"1")) + "05" + "+" + nomProg +"\n";
                    r = 0;
                }

            }

            return cadRegM;
        }

        public string llenaRegistroT(string cad)
        {
            int contLimite = 0;
            List<string> listRegT = new List<string>();
            int indiceRegT = 0;
            bool termReg = false;
            bool bandCumLi = false;

            r = 0;
            //codigo primerIns = lineasprogramaCompleto.Find(x => x.instruccion != "START\t" && x.instruccion != "RESW\t" && x.instruccion != "RESB\t" && x.instruccion != "WORD\t" && x.instruccion != "BYTE\t");
            codigo primerIns = lineasprogramaCompleto.Find(x => x.instruccion != "START\t" && x.instruccion != "RESW\t");

            string cp1 = primerIns.CP.Replace("\t", "");
            listRegT.Add("T" + cp1);

            foreach (codigo a in lineasprogramaCompleto)
            {
                if (a.instruccion != "START\t" && a.instruccion != "END\t")
                {
                    if (a.instruccion != "RESW\t" && a.instruccion != "RESB\t"  && contLimite <= 30 && (a.codObj.Length - 2) / 2 + contLimite <= 30)//Corta el registro
                    {
                        r = 0;
                        if (!a.esInsError)
                        {

                            if (termReg)
                            {
                                string cp = a.CP.Replace("\t", "");
                                //listRegT.Add("\nT"+ cp);
                                listRegT[indiceRegT] += cp;
                                termReg = false;
                                //indiceRegT++;
                                //bandCumLi = false;

                            }
                            string cadOb = a.codObj.Replace("\t", "");
                            listRegT[indiceRegT] += cadOb;
                            contLimite += cadOb.Length / 2;
                            //termReg = true;
                            bandCumLi = true;
                            r = 0;

                        }
                        contPreElim = contLimite;
                    }
                    else
                    {
                        r = 0;


                        
                        if (a.instruccion != "RESW\t" && a.instruccion != "RESB\t"  && contLimite <= 30 && bandCumLi)
                        {
                            string cp = a.CP.Replace("\t", "");
                            listRegT.Add("T" + cp);
                            string cadOb = a.codObj.Replace("\t", "");
                            listRegT[indiceRegT + 1] += cadOb;
                            //listRegT[indiceRegT] = listRegT[indiceRegT].Insert(7, rellenaTamañoDeRegistroT(tranformaAHexa(contLimite.ToString())));



                            listRegT[indiceRegT] += "\n";
                            indiceRegT++;

                            contLimite = cadOb.Length / 2;


                            bandCumLi = false;

                        }
                        else
                        if ((a.instruccion == "RESW\t" || a.instruccion == "RESB\t") && bandCumLi)
                        {
                            listRegT[indiceRegT] += "\n";
                            //listRegT[indiceRegT] = listRegT[indiceRegT].Insert(7, rellenaTamañoDeRegistroT(tranformaAHexa(contLimite.ToString())));
                            listRegT.Add("T");
                            indiceRegT++;
                            contLimite = 0;
                            bandCumLi = false;
                            termReg = true;

                        }

                    }

                }

            }

            r = 0;
            listRegT.Remove(listRegT.Find(x => x.Length == 1));
            r = 0;
            /*foreach(string c in listRegT)
            {
              c =  c.Insert(7, rellenaTamañoDeRegistroT(tranformaAHexa((((c.Length) - 7) / 2).ToString())));
            }*/
            for (int i = 0; i < listRegT.Count; i++)
            {

                listRegT[i] = listRegT[i].Insert(7, rellenaTamañoDeRegistroT(tranformaAHexa((((listRegT[i].Length) - 7) / 2).ToString())));
            }


            string cadFinal = "";
            foreach (string b in listRegT)
            {
                cadFinal += b;
            }

            return cadFinal;
        }
        public string rellenaTamañoDeRegistroT(string cad)
        {
            string cadFinal = "";

            if (cad.Length == 1)
                cadFinal = "0" + cad;
            else
                cadFinal = cad;

            return cadFinal;
        }


        public void escribeArchivo()
        {
            r = 0;
            string cadAEscribir = "\nLinea|\tCP|  Etiqueta|Instruccion|Operando| Codigo Objeto";

            obtenCodObj();

            foreach (codigo a in lineasprogramaCompleto)
            {


                if (!a.esInsError)
                {
                    cadAEscribir += a.linea;
                    cadAEscribir += a.CP;
                    cadAEscribir += a.etiqueta;
                    cadAEscribir += a.instruccion;
                    cadAEscribir += a.operando;
                    if (a.esRelocalisable)
                        cadAEscribir += a.codObj + "*";
                    else
                        cadAEscribir += a.codObj;
                    
                }
                else
                {
                    cadAEscribir += a.linea;
                    cadAEscribir += a.CP;
                    cadAEscribir += a.cadErrorLinea;
                    cadAEscribir += a.codObj;

                    r = 0;
                }
                r = 0;
            }
            arInter.Close();
            using (BinaryWriter bw = new BinaryWriter(File.Open(arInter.Name, FileMode.Open)))
            //using (BinaryWriter bw = new BinaryWriter(arInter))
            {
                bw.Write(cadAEscribir);
            }
            r = 0;
        }


        //Obtiene el codigo objeto de cada linea del programa
        public void obtenCodObj()
        {
            foreach (codigo a in lineasprogramaCompleto)
            {

                if (!a.esInsError)
                {
                    switch (a.instruccion)
                    {
                        case "START\t":
                            r = 0;
                            a.codObj += "---";
                            break;
                        case "RESB\t":
                            a.codObj += "---";
                            r = 0;
                            break;
                        case "BASE\t":
                            a.codObj += "";
                            r = 0;
                            break;
                        case "WORD\t":
                            r = 0;
                            a.codObj += rellanaPalabra(tranformaAHexa(a.operando));
                            r = 0;
                            break;
                        case "BYTE\t":
                            if (a.operando[0] == 'C')
                            {
                                string b = a.operando.Substring(2, a.operando.Length - 3);
                                char[] cad = b.ToCharArray();

                                foreach (char c in cad)
                                {
                                    a.codObj += tranformaAHexa((char.ConvertToUtf32(c.ToString(), 0)).ToString());

                                }
                            }
                            else
                            {
                                string b = a.operando.Substring(2, a.operando.Length - 3);

                                if (b.Length % 2 != 0)
                                    a.codObj += "0";

                                a.codObj += b;

                                r = 0;

                            }




                            r = 0;
                            break;
                        case "RESW\t":
                            a.codObj += "---";
                            r = 0;
                            break;
                        case "END\t":
                            a.codObj += "---";
                            r = 0;
                            break;
                        default:


                            if (a.instruccion == "RSUB")
                            {
                                a.codObj += "4F0000";
                                r = 0;
                            }
                            else
                            {
                                ConjInst inst;
                                ConjInstrF2 instF2;
                                ConjInstrF1 instF1;



                                if (a.instruccion[0] != '+')
                                {
                                    inst = listInst.Find(x => x.nemonico + "\t" == a.instruccion);
                                    if (inst != null)
                                    {
                                        obtenCodObjF34(inst, a, false);
                                        
                                    }
                                }
                                else
                                {
                                    inst = listInst.Find(x => x.nemonico + "\t" == a.instruccion.Substring(1, a.instruccion.Length - 1));
                                    if (inst != null)
                                    {
                                        obtenCodObjF34(inst, a, true);
                                        a.esRelocalisable = true;
                                    }
                                }

                                if (inst == null)
                                {
                                    instF2 = listInstF2.Find(x => x.nemonico + "\t" == a.instruccion);
                                    //a.codObj += instF2.codOp;
                                    if(instF2 != null)
                                    a.codObj += obtenCodObjF2(instF2, a);
                                    else
                                    {
                                        instF1 = listInstF1.Find(x => x.nemonico + "\t" == a.instruccion);
                                        a.codObj += instF1.codOp;
                                        r = 0;
                                    }
                                }


                                r = 0;


                                r = 0;

                            }
                            break;


                    }
                }
                else
                {
                    a.codObj += "ERROR";
                    r = 0;
                }

                string lineaDupli = a.linea.Substring(1, a.linea.Length - 2);

                r = 0;

                if (lineasSimDupli.Contains(Int32.Parse(lineaDupli)))
                {
                    a.tipoError = 1;
                }


            }

        }

        public void obtenCodObjF34(ConjInst inst, codigo a, bool ext)
        {

            a.codObj += convABinario(inst.codOp[0].ToString());
            a.codObj += rellanaCeros(convABinario(inst.codOp[1].ToString()), 4).Substring(0, 2);

            a.codObj += buscaModoDireccionamiento(a.CP, a.instruccion, a.operando);

            if(!ext)
            a.codObj = "\t\t"+rellanaCeros(convBinAHex(a.codObj.Substring(2, a.codObj.Length - 2)), 6);
            else
                a.codObj = "\t\t"+rellanaCeros(convBinAHex(a.codObj.Substring(2, a.codObj.Length - 2)), 8);

        }

        public string obtenCodObjF2(ConjInstrF2 ins, codigo linAc)
        {
            string codObj = "";

            codObj += ins.codOp;

            if(char.IsDigit(linAc.operando[0]))
            {
                codObj += linAc.operando[0];
            }
            else
            {
                registros Op1 = lisReg.Find(x => x.nemonico == linAc.operando[0].ToString());

                codObj += Op1.numero;
            }

            if (linAc.operando.Length > 1)
            {
                if (char.IsDigit(linAc.operando[linAc.operando.Length-1]))
                {
                    codObj += linAc.operando[linAc.operando.Length - 1];
                }
                else
                {
                    registros Op1 = lisReg.Find(x => x.nemonico == linAc.operando[linAc.operando.Length - 1].ToString());

                    codObj += Op1.numero;
                }
            }
            else
            {
                codObj += "0";
            }

            

            


            return codObj;
        }

        public string buscaModoDireccionamiento(string _cp, string instruccion, string operando)
        {
            string banderas = "";

            string n = "";
            string i = "";
            string b = "";
            string p = "";
            string e = "";


            if (operando[0].ToString() == "@")//indirecta
            {
                if (instruccion[0].ToString() == "+")//Formato4
                {
                    if (char.IsDigit(operando[1]))//operando constante
                    {
                        if (validaConstante(operando.Substring(1, operando.Length - 1)))
                        {
                            banderas = "100000";
                            banderas += rellanaCeros(convABinario(operando.Substring(1, operando.Length - 1)), 20);

                            r = 0;
                        }
                        
                    }
                    else//Operando m///////////CONFIRMADA
                    {
                        r = 0;
                        tabSim op = simDir.Find(x => x.simbolo == operando.Substring(1, operando.Length - 1));

                        

                        if (op != null)
                        {
                            banderas = "100001" + rellanaCeros(convABinario(op.direccion), 20);
                        }
                        else
                        {
                            //Operando no existe
                            banderas += "010001" + convABinario("FFFF");
                        }


                    }

                }
                else//formato3
                {
                    if (char.IsDigit(operando[1]))//operando constante ///////////CONFIRMADA
                    {
                        if (validaConstante(operando.Substring(1, operando.Length - 1)))
                        {
                            banderas = "100000";
                            //string ab = operando.Substring(0, 1);
                            //string a = convABinario(operando.Substring(1, operando.Length - 1));
                            string ab = rellanaCeros(convABinario(operando.Substring(1, operando.Length - 1)), 12);

                            r = 0;

                            banderas += ab;
                        }

                    }
                    else//Operando m//CONFIRMADO
                    {
                        tabSim op = simDir.Find(x => x.simbolo == operando.Substring(1, operando.Length - 1));

                        string desp = obtenDesp(op, _cp, "1000");
                        banderas += desp;
                    }
                }
            }
            else
            {
                if (operando[0].ToString() == "#")//inmediato
                {

                    if (instruccion[0].ToString() == "+")//Formato4
                    {
                        if (char.IsDigit(operando[1]))//operando constante
                        {
                            if (validaConstante(operando.Substring(1, operando.Length - 1)))
                            {
                                banderas = "010000";
                                banderas += rellanaCeros(convABinario(operando.Substring(1, operando.Length - 1)), 20);

                                r = 0;
                            }
                            else
                            {
                                banderas = "010001";
                                banderas += rellanaCeros(convABinario(operando.Substring(1, operando.Length - 1)), 20);
                            }
                        }
                        else//Operando m///////////CONFIRMADA
                        {
                            r = 0;
                            tabSim op = simDir.Find(x => x.simbolo == operando.Substring(1, operando.Length - 1));

                            //banderas = "010001" + rellanaCeros(convABinario(op.direccion), 20);

                            if (op != null)
                            {
                                banderas = "010001" + rellanaCeros(convABinario(op.direccion), 20);
                            }
                            else
                            {
                                //Operando no existe
                                
                                banderas += "010001" + convABinario("FFFF");
                            }


                        }

                    }
                    else//formato3
                    {
                        if (char.IsDigit(operando[1]))//operando constante ///////////CONFIRMADA
                        {
                            if (validaConstante(operando.Substring(1, operando.Length - 1)))
                            {
                                banderas = "010000";
                                //string ab = operando.Substring(0, 1);
                                //string a = convABinario(operando.Substring(1, operando.Length - 1));
                                string ab = rellanaCeros(convABinario(operando.Substring(1, operando.Length - 1)), 12);

                                r = 0;

                                banderas += ab;
                            }
                        }
                        else//Operando m//CONFIRMADO
                        {
                            tabSim op = simDir.Find(x => x.simbolo == operando.Substring(1, operando.Length - 1));

                            if (op != null)
                            {
                                string desp = obtenDesp(op, _cp, "0100");
                                banderas += desp;
                            }
                            else
                            {
                                //Operando no existe
                                banderas += "010110" + convABinario("FFF");
                            }
                        }
                    }
                }
                else//Simple
                {
                    if (instruccion[0].ToString() == "+")//Formato4
                    {

                        if (operando[operando.Length - 1] == 'X')
                        {
                            //banderas = "111001" + rellanaCeros(convABinario(op.direccion), 20);

                            if (char.IsDigit(operando[1]))
                            {
                                banderas += "111111" + convABinario("FFFF");
                            }
                        
                        }
                        else
                        {
                            
                            tabSim op = simDir.Find(x => x.simbolo == operando);
                            /////////////////////////////
                            banderas = "110001" + rellanaCeros(convABinario(op.direccion), 20);
                            r = 0;
                        }
                    }
                    else//formato3
                    {
                        if (operando[operando.Length - 1] == 'X' && (operando[operando.Length - 2] == ' '|| operando[operando.Length - 2] == ','))//Indexada
                        {
                            if (char.IsDigit(operando[0]))
                            {
                                if (validaConstante(operando.Split(',')[0]))
                                {
                                    banderas = "111000";
                                    string ab = rellanaCeros(convABinario(operando.Split(',')[0]), 12);

                                    banderas += ab;
                                    r = 0;
                                }
                                else
                                {
                                    banderas = "111001";
                                    banderas += rellanaCeros(convABinario(operando.Substring(1, operando.Length - 1)), 20);
                                }
                            }
                            else///////////CONFIRMADA
                            {
                                tabSim op = simDir.Find(x => x.simbolo == operando.Split(',')[0]);

                                if (op != null)
                                {
                                    string desp = obtenDesp(op, _cp, "1110");
                                    banderas += desp;

                                }
                                else//CONFIRMADO
                                {
                                    //Operando no existe
                                    banderas += "111110" + convABinario("FFF");
                                }

                            }
                        }
                        else //SIMPLE NO INDEXADA
                        {
                            if (char.IsDigit(operando[1]))//Constante
                            {
                                if (validaConstante(operando))
                                {
                                    banderas = "110000";
                                    banderas += rellanaCeros(convABinario(operando), 12);
                                }

                            }
                            else///////////CONFIRMADA
                            {
                                tabSim op = simDir.Find(x => x.simbolo == operando);

                                if (op != null)
                                {
                                    banderas = obtenDesp(op, _cp, "1100");

                                }
                                else
                                {
                                    banderas += "110110" + convABinario("FFF");

                                    //Operando no existe
                                }

                            }
                        }

                    }
                }
            }

            return banderas;
        }


        public string obtenDesp(tabSim a, string _cp, string banderas)
        {
            string valor = "";
            _cp = sumaHex(_cp.Substring(0, _cp.Length - 1),"3");

            string vTem = esRangoCP(a, _cp);

            if (vTem != "null")
            {
                string bandCp = "01";

                valor += banderas.Insert(3, bandCp);
                string tem = convABinario(vTem);
                valor += rellanaCeros(tem, 12);

                r = 0;

            }
            else
            {
                vTem = esRangoBase(a);
                if (dirBase && vTem != "null")
                {
                    string bandBA = "10";
                    valor += banderas.Insert(3, bandBA);
                    string tem = convABinario(vTem);
                    valor += rellanaCeros(tem, 12);

                }
                else
                {
                    string bandErr = "11";
                    valor += banderas.Insert(3, bandErr);
                    valor += rellanaCeros(convABinario("FFF"), 12);
                }
            }

            return valor;
        }

        public string esRangoCP(tabSim a, string _cp)
        {
            string val = "null";

            string valHex = restaHex(a.direccion, _cp);
            int valDeci = convADecimal(valHex);

            if (valDeci >= -2048 && valDeci <= 2048)
            {
                if (valDeci >= 0)
                {
                    val = valHex;
                }
                else
                {
                    r = 0;
                    val = valHex.Substring(5, 3);
                }
            }
            return val;
        }

        public string esRangoBase(tabSim a)
        {
            string val = "null";

            string valHex = restaHex(a.direccion, valorBase);
            int valDeci = convADecimal(valHex);

            if (valDeci >= 0 && valDeci <= 4095)
                val = valHex;

            return val;
        }

        public bool validaConstante(string valor)
        {
            bool band = false;
            int vDec;
            if (valor[valor.Length - 1] == 'H' || valor[valor.Length - 1] == 'h')
                vDec = convADecimal(valor.Substring(0,valor.Length-1));
            else
                vDec = Int32.Parse(valor);

            if (vDec >= 0 && vDec <= 4095)
            {
                band = true;
            }

            return band;
        }


        public string convABinario(int deci)
        {
            string valorBin = "";

            valorBin = Convert.ToString(deci, 2).ToString();

            return valorBin;
        }

        public string convABinario(string hexa)
        {
            string valorBin = "";

            if (hexa[hexa.Length - 1] == 'H' || hexa[hexa.Length - 1] == 'h')
                hexa = hexa.Substring(0, hexa.Length - 1);

            int valDecimal = convADecimal(hexa);
            valorBin = Convert.ToString(valDecimal, 2).ToString();

            return valorBin;
        }

        public int convADecimal(string valorHexa)
        {   
            
            return Convert.ToInt32(valorHexa, 16);
        }

        public void agregaLineaErrorSintaxis()
        {
            string cadFinal = "";
            codigo ins = new codigo();
            string algo = lineaCodigo[numlineaActual];

            CP = rellanaPalabra(CP);

            string cadError = lineaCodigo[numlineaActual - 1];
            r = 0;
            cadFinal = "\n" + numlineaActual.ToString() + "\t" + CP + "\t" + cadError;
            ins.linea = "\n" + numlineaActual.ToString() + "\t";
            ins.CP = CP + "\t";
            ins.cadErrorLinea = cadError;
            ins.esInsError = true;
            string[] arr = cadError.Split('\t');
            ins.etiqueta = arr[0] + "\t";
            ins.instruccion = arr[1] + "\t";
            if (arr.Length > 2)
                ins.operando = arr[2] + "\n";


            lineasprogramaCompleto.Add(ins);
            numlineaActual++;

            r = 0;
        }

        public void añadirATabSim(string etiqueta, int linea)
        {
            int j = 1;

            if (etiqueta.Length > 1)
            {
                tabSim ob = new tabSim();
                ob.simbolo = etiqueta;
                ob.direccion = CP;
                /* if(!simDir.Contains(ob))
                    
                */
                bool siInserta = true;
                for (int i = 0; i < simDir.Count; i++)
                {

                    if (etiqueta == simDir[i].simbolo)
                        siInserta = false;

                }
                if (siInserta)
                {
                    simDir.Add(ob);
                }
                else
                {
                    lineasSimDupli.Add(linea);
                }

                j++;

            }
        }


        public string sumaHex(string valor, string valorASumar)
        {
            string resultado = tranformaAHexa((Convert.ToInt32(valor, 16) + Convert.ToInt32(valorASumar, 16)).ToString());
            return resultado;
        }

        public string restaHex(string valor, string valorASumar)
        {
            string resultado = tranformaAHexa((Convert.ToInt32(valor, 16) - Convert.ToInt32(valorASumar, 16)).ToString());
            return resultado;
        }

        public string tranformaAHexa(string cadDeci)
        {
            string nuevoVal = "";

            if (cadDeci[cadDeci.Length - 1] == 'H' | cadDeci[cadDeci.Length - 1] == 'h')
            {
                nuevoVal = cadDeci.Remove(cadDeci.Length - 1);
                r = 0;
            }
            else
            {
                r = 0;
                int valor = int.Parse(cadDeci);
                r = 0;
                nuevoVal = Convert.ToString(valor, 16).ToUpper();
                r = 0;
            }
            r = 0;
            return nuevoVal.ToUpper();

        }

        public string convBinAHex(string cadBin)
        {
            string nuevoVal = "";

            r = 0;
            int valor = Convert.ToInt32(cadBin, 2);
            r = 0;
            nuevoVal = Convert.ToString(valor, 16).ToUpper();
            r = 0;

            return nuevoVal.ToUpper();

        }


        public string rellanaPalabra(string cadena)
        {
            int contCad = cadena.Length;

            while (contCad < 6)
            {
                cadena = "0" + cadena;
                contCad++;
            }

            return cadena;
        }

        public string rellanaCeros(string cadena, int cant)
        {
            int contCad = cadena.Length;

            while (contCad < cant)
            {
                cadena = "0" + cadena;
                contCad++;
            }

            return cadena;
        }


        public string obtenValorDirectiva(string directiva, string operando)
        {
            string valorRes = "";

            switch (directiva)
            {
                case "WORD":
                    valorRes = tranformaAHexa("3");
                    r = 0;
                    break;
                case "RESB":
                    valorRes = tranformaAHexa(operando);
                    r = 0;
                    break;
                case "RESW":
                    r = 0;
                    valorRes = tranformaAHexa(operando);
                    r = 0;
                    valorRes = tranformaAHexa((Convert.ToInt32(valorRes, 16) * 3).ToString());
                    break;
            }
            r = 0;

            return valorRes;
        }

        public int obtenValorByte(string opeandoByte)
        {
            int valorASumar = 0;

            switch (opeandoByte[0].ToString().ToUpper())
            {
                case "C":
                    r = 0;
                    string cadAEvaC = opeandoByte.Substring(2, opeandoByte.Length - 3);
                    r = 0;
                    int valorOb = cadAEvaC.Length;
                    valorASumar = valorOb;
                    r = 0;
                    break;
                case "X":
                    r = 0;
                    string cadAEvaX = opeandoByte.Substring(2, opeandoByte.Length - 3);
                    r = 0;
                    float valor = (float)cadAEvaX.Length / 2;
                    r = 0;
                    double valorRed = Math.Ceiling(valor);
                    r = 0;
                    valorASumar = Convert.ToInt32(valorRed);
                    r = 0;
                    break;

            }

            return valorASumar;
        }

        public void obtenCadenaArchivo(FileStream archivo)
        {
            List<string> cadArchiv = new List<string>();

            BinaryReader br = new BinaryReader(archivo);
            archivo.Seek(0, SeekOrigin.Begin);
            char[] algo = br.ReadChars((int)archivo.Length);
            string cadenasArchivo = new string(algo);

            string[] cadenasRecor;

            r = 0;
            cadenasArchivo = cadenasArchivo.Replace("\n\n", "\n");
            cadenasArchivo = cadenasArchivo.Replace("\r\n\r\n", "\r\n");
            cadenasArchivo = cadenasArchivo.Replace("\r", string.Empty);
            cadenasRecor = cadenasArchivo.Split('\n');

            lineaCodigo = cadenasRecor;

            r = 0;
        }

        public void iniConIntr()
        {
            ConjInst inst = new ConjInst();
            inst.nemonico = "ADD";
            inst.codOp = "18";
            listInst.Add(inst);


            ConjInst inst2 = new ConjInst();
            inst2.nemonico = "ADDF";
            inst2.codOp = "58";
            listInst.Add(inst2);

            ConjInst inst3 = new ConjInst();
            inst3.nemonico = "AND";
            inst3.codOp = "40";
            listInst.Add(inst3);

            ConjInst inst4 = new ConjInst();
            inst4.nemonico = "COMP";
            inst4.codOp = "28";
            listInst.Add(inst4);

            ConjInst inst5 = new ConjInst();
            inst5.nemonico = "COMPF";
            inst5.codOp = "88";
            listInst.Add(inst5);

            ConjInst inst6 = new ConjInst();
            inst6.nemonico = "DIV";
            inst6.codOp = "24";
            listInst.Add(inst6);

            ConjInst inst7 = new ConjInst();
            inst7.nemonico = "DIVF";
            inst7.codOp = "64";
            listInst.Add(inst7);

            ConjInst inst8 = new ConjInst();
            inst8.nemonico = "J";
            inst8.codOp = "3C";
            listInst.Add(inst8);

            ConjInst inst9 = new ConjInst();
            inst9.nemonico = "JEQ";
            inst9.codOp = "30";
            listInst.Add(inst9);

            ConjInst inst10 = new ConjInst();
            inst10.nemonico = "JGT";
            inst10.codOp = "34";
            listInst.Add(inst10);

            ConjInst inst11 = new ConjInst();
            inst11.nemonico = "JLT";
            inst11.codOp = "38";
            listInst.Add(inst11);

            ConjInst inst12 = new ConjInst();
            inst12.nemonico = "JSUB";
            inst12.codOp = "48";
            listInst.Add(inst12);

            ConjInst inst13 = new ConjInst();
            inst13.nemonico = "LDA";
            inst13.codOp = "00";
            listInst.Add(inst13);

            ConjInst inst14 = new ConjInst();
            inst14.nemonico = "LDB";
            inst14.codOp = "68";
            listInst.Add(inst14);

            ConjInst inst15 = new ConjInst();
            inst15.nemonico = "LDCH";
            inst15.codOp = "50";
            listInst.Add(inst15);

            ConjInst inst16 = new ConjInst();
            inst16.nemonico = "LDF";
            inst16.codOp = "70";
            listInst.Add(inst16);

            ConjInst inst17 = new ConjInst();
            inst17.nemonico = "LDL";
            inst17.codOp = "08";
            listInst.Add(inst17);

            ConjInst inst18 = new ConjInst();
            inst18.nemonico = "LDS";
            inst18.codOp = "6C";
            listInst.Add(inst18);

            ConjInst inst19 = new ConjInst();
            inst19.nemonico = "LDT";
            inst19.codOp = "74";
            listInst.Add(inst19);

            ConjInst inst20 = new ConjInst();
            inst20.nemonico = "LDX";
            inst20.codOp = "04";
            listInst.Add(inst20);

            ConjInst inst21 = new ConjInst();
            inst21.nemonico = "MUL";
            inst21.codOp = "20";
            listInst.Add(inst21);

            ConjInst inst22 = new ConjInst();
            inst22.nemonico = "MUL";
            inst22.codOp = "20";
            listInst.Add(inst22);

            ConjInst inst23 = new ConjInst();
            inst23.nemonico = "MULF";
            inst23.codOp = "60";
            listInst.Add(inst23);

            ConjInst inst24 = new ConjInst();
            inst24.nemonico = "LPS";
            inst24.codOp = "D0";
            listInst.Add(inst24);

            ConjInst inst25 = new ConjInst();
            inst25.nemonico = "OR";
            inst25.codOp = "44";
            listInst.Add(inst25);

            ConjInst inst26 = new ConjInst();
            inst26.nemonico = "RD";
            inst26.codOp = "D8";
            listInst.Add(inst26);

            ConjInst inst28 = new ConjInst();
            inst28.nemonico = "STA";
            inst28.codOp = "0C";
            listInst.Add(inst28);

            ConjInst inst29 = new ConjInst();
            inst29.nemonico = "STB";
            inst29.codOp = "78";
            listInst.Add(inst29);

            ConjInst inst30 = new ConjInst();
            inst30.nemonico = "SSK";
            inst30.codOp = "EC";
            listInst.Add(inst30);

            ConjInst inst31 = new ConjInst();
            inst31.nemonico = "STCH";
            inst31.codOp = "54";
            listInst.Add(inst31);

            ConjInst inst32 = new ConjInst();
            inst32.nemonico = "STF";
            inst32.codOp = "80";
            listInst.Add(inst32);

            ConjInst inst33 = new ConjInst();
            inst33.nemonico = "STI";
            inst33.codOp = "D4";
            listInst.Add(inst33);

            ConjInst inst34 = new ConjInst();
            inst34.nemonico = "STS";
            inst34.codOp = "7C";
            listInst.Add(inst34);

            ConjInst inst35 = new ConjInst();
            inst35.nemonico = "STSW";
            inst35.codOp = "E8";
            listInst.Add(inst35);

            ConjInst inst36 = new ConjInst();
            inst36.nemonico = "STX";
            inst36.codOp = "10";
            listInst.Add(inst36);

            ConjInst inst37 = new ConjInst();
            inst37.nemonico = "STT";
            inst37.codOp = "84";
            listInst.Add(inst37);

            ConjInst inst38 = new ConjInst();
            inst38.nemonico = "SUB";
            inst38.codOp = "1C";
            listInst.Add(inst38);

            ConjInst inst39 = new ConjInst();
            inst39.nemonico = "SUBF";
            inst39.codOp = "5C";
            listInst.Add(inst39);

            ConjInst inst40 = new ConjInst();
            inst40.nemonico = "TD";
            inst40.codOp = "E0";
            listInst.Add(inst40);

            ConjInst inst41 = new ConjInst();
            inst41.nemonico = "TIX";
            inst41.codOp = "2C";
            listInst.Add(inst41);

            ConjInst inst42 = new ConjInst();
            inst42.nemonico = "WD";
            inst42.codOp = "DC";
            listInst.Add(inst42);
        }

        public void iniConIntrF2()
        {
            ConjInstrF2 inst1 = new ConjInstrF2();
            inst1.nemonico = "ADDR";
            inst1.codOp = "90";
            listInstF2.Add(inst1);

            ConjInstrF2 inst2 = new ConjInstrF2();
            inst2.nemonico = "CLEAR";
            inst2.codOp = "B4";
            listInstF2.Add(inst2);

            ConjInstrF2 inst3 = new ConjInstrF2();
            inst3.nemonico = "COMPR";
            inst3.codOp = "A0";
            listInstF2.Add(inst3);

            ConjInstrF2 inst4 = new ConjInstrF2();
            inst4.nemonico = "DIVR";
            inst4.codOp = "9C";
            listInstF2.Add(inst4);

            ConjInstrF2 inst5 = new ConjInstrF2();
            inst5.nemonico = "MULR";
            inst5.codOp = "98";
            listInstF2.Add(inst5);

            ConjInstrF2 inst6 = new ConjInstrF2();
            inst6.nemonico = "RMO";
            inst6.codOp = "AC";
            listInstF2.Add(inst6);

            ConjInstrF2 inst7 = new ConjInstrF2();
            inst7.nemonico = "SHIFTL";
            inst7.codOp = "A4";
            listInstF2.Add(inst7);

            ConjInstrF2 inst8 = new ConjInstrF2();
            inst8.nemonico = "SHIFTR";
            inst8.codOp = "A8";
            listInstF2.Add(inst8);

            ConjInstrF2 inst9 = new ConjInstrF2();
            inst9.nemonico = "SUBR";
            inst9.codOp = "94";
            listInstF2.Add(inst9);

            ConjInstrF2 inst10 = new ConjInstrF2();
            inst10.nemonico = "SVC";
            inst10.codOp = "B0";
            listInstF2.Add(inst10);

            ConjInstrF2 inst11 = new ConjInstrF2();
            inst11.nemonico = "TIXR";
            inst11.codOp = "B8";
            listInstF2.Add(inst11);

        }

        public void iniConIntrF1()
        {
            ConjInstrF1 ins1 = new ConjInstrF1();
            ins1.nemonico = "FIX";
            ins1.codOp = "C4";
            listInstF1.Add(ins1);

            ConjInstrF1 ins2 = new ConjInstrF1();
            ins2.nemonico = "FLOAT";
            ins2.codOp = "C0";
            listInstF1.Add(ins2);

            ConjInstrF1 ins3 = new ConjInstrF1();
            ins3.nemonico = "HIO";
            ins3.codOp = "F4";
            listInstF1.Add(ins3);

            ConjInstrF1 ins4 = new ConjInstrF1();
            ins4.nemonico = "NORM";
            ins4.codOp = "C8";
            listInstF1.Add(ins4);

            ConjInstrF1 ins5 = new ConjInstrF1();
            ins5.nemonico = "SIO";
            ins5.codOp = "F0";
            listInstF1.Add(ins5);

            ConjInstrF1 ins6 = new ConjInstrF1();
            ins6.nemonico = "TIO";
            ins6.codOp = "F8";
            listInstF1.Add(ins5);
        }


        public void iniRegistros()
        {
            registros reg = new registros();
            reg.nemonico = "B";
            reg.numero = "3";
            lisReg.Add(reg);

            registros reg1 = new registros();
            reg1.nemonico = "S";
            reg1.numero = "4";
            lisReg.Add(reg1);

            registros reg2 = new registros();
            reg2.nemonico = "T";
            reg2.numero = "5";
            lisReg.Add(reg2);

            registros reg3 = new registros();
            reg3.nemonico = "F";
            reg3.numero = "6";
            lisReg.Add(reg3);

            registros reg4 = new registros();
            reg4.nemonico = "A";
            reg4.numero = "0";
            lisReg.Add(reg4);

            registros reg5 = new registros();
            reg5.nemonico = "X";
            reg5.numero = "1";
            lisReg.Add(reg5);

            registros reg6 = new registros();
            reg6.nemonico = "L";
            reg6.numero = "2";
            lisReg.Add(reg6);

        }
    }


    public class registros
    {
        public string nemonico = "";
        public string numero = "";
    }
}
