using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Antlr4.Runtime.Misc;
using System.IO;

namespace AnalizadorSIC_GRAFICO
{

    public class visitorSIC_STD : GramaticaSIC_STDBaseVisitor<int>
    {
        string CP = "000000";
        public string CPInicio = "";
        public string DirCarga = "";
        public List<int> lineasConError = new List<int>();
        public List<codigo> lineasprogramaCompleto;
        public List<tabSim> simDir;
        public FileStream archivo;
        public FileStream arInter;
        public FileStream arTabSim;
        public FileStream arProgramaObjeto;
        string acumCodFinal;
        public string cadRegisGlobal;
        string[] lineaCodigo;
        int contPreElim;
        int r = 0;
        int numlineaActual = 1;
        public List<ConjInst> listInst;
        public string tamCod;
        int conCadErrorGlo = 0;
        string cadReservada;
        public List<int> lineasSimDupli;

        public visitorSIC_STD(List<int> errores, FileStream _archivo)
        {
            
            lineasprogramaCompleto = new List<codigo>();
            lineasConError = errores;
            archivo = _archivo;
            obtenCadenaArchivo(archivo);
            if(arInter != null)
               arInter.Close();
            arInter = new FileStream("Intermedio.t", FileMode.Create);
            
            arTabSim = new FileStream("TabSim.t", FileMode.Create);
            arProgramaObjeto = new FileStream("Objeto.obj", FileMode.Create);
            //simDir = new List<tabSim>();
            simDir = new List<tabSim>();
            lineasprogramaCompleto = new List<codigo>();
            listInst = new List<ConjInst>();
            iniConIntr();
            //iniEfectos();
            lineasSimDupli = new List<int>();

        }

        public override int VisitError([NotNull] GramaticaSIC_STDParser.ErrorContext context)
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
                    if (a != null || cadAReco == "BYTE" || cadAReco == "RESW" || cadAReco == "RESB" || cadAReco == "WORD" || cadAReco == "END" || cadAReco == "START")
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
            int r = 0;
            return base.VisitError(context);
        }

        //INSTRUCCION NORMAL
        public override int VisitInstruccionVisitor([NotNull] GramaticaSIC_STDParser.InstruccionVisitorContext context)
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
                string operando = context.opinstruccion().GetText();

                r = 0;
                añadirATabSim(etiqueta, numlineaActual);

                cadFinal = etiqueta + "\t" + instru + "\t" + operando;

                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.CP = CP + "\t";
                ins.etiqueta = etiqueta + "\t";
                ins.instruccion = instru + "\t";
                ins.operando = operando;

                CP = sumaCP(CP, "3");



                r = 0;
            }


            lineasprogramaCompleto.Add(ins);



            acumCodFinal += cadFinal;
            r = 0;

            numlineaActual++;

            return base.VisitInstruccionVisitor(context);
        }





        //Directivas
        public override int VisitDirectivaExisten([NotNull] GramaticaSIC_STDParser.DirectivaExistenContext context)
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
                cadFinal = "\n" + numlineaActual.ToString()  + "\t" + CP + "\t" + cadError;


                ins.linea = "\n" + numlineaActual.ToString()  + "\t";
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
                    CP = sumaCP(CP, obtenValorDirectiva(directiva, operando));
                else
                {
                    int valorASuma = obtenValorByte(operando);
                    CP = sumaCP(CP, tranformaAHexa(valorASuma.ToString()));
                }
            }

            lineasprogramaCompleto.Add(ins);
            numlineaActual++;

            r = 0;
            return base.VisitDirectivaExisten(context);
        }





        //INTRUCCION RSUB
        public override int VisitInstrRSUB([NotNull] GramaticaSIC_STDParser.InstrRSUBContext context)
        {
            string cadFinal;
            CP = rellanaPalabra(CP);
            codigo ins = new codigo();

            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];
                cadFinal = "\n" + numlineaActual.ToString()  + "\t" + CP + "\t" + cadError;
                ins.linea = "\n" + numlineaActual.ToString()  + "\t";
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

                CP = sumaCP(CP, "3");

            }


            lineasprogramaCompleto.Add(ins);

            numlineaActual++;
            return base.VisitInstrRSUB(context);
        }


        //DIRECTIVA START
        public override int VisitInicioEti([NotNull] GramaticaSIC_STDParser.InicioEtiContext context)
        {
            string cadFinal;
            codigo ins = new codigo();


            if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];
                CP = rellanaPalabra(CP);

                cadFinal = "\n" + numlineaActual.ToString()  + "\t" + CP + "\t" + cadError;
                ins.linea = "\n" + numlineaActual.ToString()  + "\t";
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

        public override int VisitFinEntrada([NotNull] GramaticaSIC_STDParser.FinEntradaContext context)
        {
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
            r = 0;
            escribeArchivo();
            escribeArchivoTabSim();
            hazProgramaObjeto();

            numlineaActual++;

            return base.VisitFinEntrada(context);
        }


        //SIMBOLO END
        public override int VisitFinalSinEntrada([NotNull] GramaticaSIC_STDParser.FinalSinEntradaContext context)
        {
            string cadFinal = "";
            codigo ins = new codigo();

            CP = rellanaPalabra(CP);
            /*if (lineasConError.Contains(numlineaActual))
            {
                r = 0;
                string cadError = lineaCodigo[numlineaActual - 1];

                cadFinal = "\n" + numlineaActual.ToString() + "*" + "\t" + CP + "\t" + cadError;
                ins.linea = "\n" + numlineaActual.ToString() + "*" + "\t";
                ins.CP = CP + "\t";
                ins.esInsError = true;
                //ins.cadErrorLinea = cadError;
                string[] arr = cadError.Split('\t');
                ins.etiqueta = arr[0]+"\t";
                ins.instruccion = arr[1]+"\t";
                ins.operando = arr[2]+"\n";
            }
            else
            {*/
                string directiva = context.DIREND().GetText();


                cadFinal = directiva;
                ins.linea = "\n" + numlineaActual.ToString() + "\t";
                ins.instruccion = directiva + "\t";
                ins.CP = CP + "\t";

           // }


            lineasprogramaCompleto.Add(ins);
            escribeArchivo();
            escribeArchivoTabSim();
            hazProgramaObjeto();

            numlineaActual++;

            return base.VisitFinalSinEntrada(context);
        }


        //Metodos para la manipulacion de datos


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
            if(arr.Length > 2 )
            ins.operando = arr[2] + "\n";


            lineasprogramaCompleto.Add(ins);
            numlineaActual++;

            r = 0;
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

        public string rellenaTamañoDeRegistroT(string cad)
        {
            string cadFinal = "";

            if (cad.Length == 1)
                cadFinal = "0" + cad;
            else
                cadFinal = cad;

            return cadFinal;
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
                    if (a.instruccion != "RESW\t" && a.instruccion != "RESB\t" && contLimite <= 30 && (a.codObj.Length - 2) / 2 + contLimite <= 30)
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
                        //ME QUEDE EN QUE VERIFICAR CUANDO YA REGISTRA EL FINAL DE REGISTRO T
                        //Agrega el tamaño del anterior 


                        if (a.instruccion != "RESW\t" && a.instruccion != "RESB\t" && contLimite <= 30 && bandCumLi)
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
        public void escribeArchivoTabSim()
        {
            r = 0;
            string cadFinal = "\nTamaño: ";


            tamCod = rellanaPalabra(tranformaAHexa((Convert.ToInt32(CP, 16) - (Convert.ToInt32(CPInicio, 16))).ToString().ToUpper()));
            cadFinal += tamCod;
            cadFinal += "H\n";

            cadFinal += "\nSimbolo\tDireccion";
            r = 0;
            foreach (tabSim a in simDir)
            {
                cadFinal += "\n" + a.simbolo + "\t" + a.direccion;
            }

            r = 0;
            arTabSim.Close();
            using (BinaryWriter bw = new BinaryWriter(File.Open(arTabSim.Name, FileMode.Open)))
            {
                r = 0;
                bw.Write(cadFinal);
                r = 0;
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
                                a.codObj += "4C0000";
                                r = 0;
                            }
                            else
                            {
                                ConjInst inst = listInst.Find(x => x.nemonico + "\t" == a.instruccion);
                                r = 0;
                                a.codObj += inst.codOp;

                                if (a.operando[a.operando.Length - 1] != 'X')
                                {
                                    tabSim op = simDir.Find(x => x.simbolo == a.operando);
                                    r = 0;
                                    if (op != null)
                                        a.codObj += op.direccion.Substring(2, op.direccion.Length - 2);
                                    else
                                    {
                                        a.codObj += "7FFF";
                                        a.tipoError = 2;
                                    }
                                    r = 0;

                                   
                                }
                                else
                                {
                                    r = 0;
                                    string[] cad1 = a.operando.Split(',');
                                    r = 0;
                                    tabSim op = simDir.Find(x => x.simbolo == cad1[0]);
                                    if (op != null)
                                    {
                                        string cad2 = op.direccion.Substring(2, op.direccion.Length - 2);
                                        cad2 = sumaCP(cad2, "8000");
                                        a.codObj += cad2;
                                    }
                                    else
                                    {
                                        a.codObj += "FFFF";
                                        a.tipoError = 2;
                                    }
                                    r = 0;
                                    
                                }
                            }
                            break;


                    }
                }
                else
                {
                    a.codObj += "ERROR";
                    r = 0;
                }

                string lineaDupli = a.linea.Substring(1, a.linea.Length-2);
               
                r = 0;
                
                if(lineasSimDupli.Contains(Int32.Parse(lineaDupli)))
                {
                    a.tipoError = 1;
                }
                /*
                if (a.instruccion != "START\t")
                {
                    ConjInst inst = listInst.Find(x => x.nemonico+"\t" == a.instruccion);
                    r = 0;
                    a.codObj += inst.codOp;

                    
                    if(a.instruccion == "RSUB\t")
                    {
                        a.codObj += "0000";
                    }
                    else
                    if (a.operando[a.operando.Length - 1] != 'X')
                    {
                        tabSim op = simDir.Find(x => x.simbolo ==a.operando);
                        a.codObj += op.direccion.Substring(2, op.direccion.Length - 2);
                        a.codObj += "\n";
                        r = 0;
                    }
                    else
                    {
                        r = 0;
                        string[] cad1 = a.operando.Split(',');
                        r = 0;
                        tabSim op = simDir.Find(x => x.simbolo == cad1[0]);
                        string cad2 = op.direccion.Substring(2, op.direccion.Length - 2);
                        cad2 = sumaCP(cad2, "8000");
                        a.codObj +=cad2+ "\n";
                        
                        r = 0;

                    }
                }
                else
                    a.codObj += "---";*/

            }

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
                    float valor =(float) cadAEvaX.Length / 2;
                    r = 0;
                    double valorRed = Math.Ceiling(valor);
                    r = 0;
                    valorASumar = Convert.ToInt32(valorRed);
                    r = 0;
                    break;

            }

            return valorASumar;
        }

        public string sumaCP(string CPActual, string valor)
        {
            string resultado = tranformaAHexa((Convert.ToInt32(CPActual, 16) + Convert.ToInt32(valor, 16)).ToString());
            return resultado;
        }

        public string tranformaAHexa(string cadOri)
        {
            string nuevoVal = "";

            if (cadOri[cadOri.Length - 1] == 'H' | cadOri[cadOri.Length - 1] == 'h')
            {
                nuevoVal = cadOri.Remove(cadOri.Length - 1);
                r = 0;
            }
            else
            {
                r = 0;
                int valor = int.Parse(cadOri);
                r = 0;
                nuevoVal = Convert.ToString(valor, 16).ToUpper();
                r = 0;
            }
            r = 0;
            return nuevoVal.ToUpper();
        }


        public void añadirATabSim(string etiqueta,int linea)
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
            inst2.nemonico = "AND";
            inst2.codOp = "40";
            listInst.Add(inst2);

            ConjInst inst3 = new ConjInst();
            inst3.nemonico = "COMP";
            inst3.codOp = "28";
            listInst.Add(inst3);

            ConjInst inst4 = new ConjInst();
            inst4.nemonico = "DIV";
            inst4.codOp = "24";
            listInst.Add(inst4);

            ConjInst inst5 = new ConjInst();
            inst5.nemonico = "J";
            inst5.codOp = "3C";
            listInst.Add(inst5);

            ConjInst inst6 = new ConjInst();
            inst6.nemonico = "JEQ";
            inst6.codOp = "30";
            listInst.Add(inst6);

            ConjInst inst7 = new ConjInst();
            inst7.nemonico = "JGT";
            inst7.codOp = "34";
            listInst.Add(inst7);

            ConjInst inst8 = new ConjInst();
            inst8.nemonico = "JLT";
            inst8.codOp = "38";
            listInst.Add(inst8);

            ConjInst inst9 = new ConjInst();
            inst9.nemonico = "JSUB";
            inst9.codOp = "48";
            listInst.Add(inst9);

            ConjInst inst10 = new ConjInst();
            inst10.nemonico = "LDA";
            inst10.codOp = "00";
            listInst.Add(inst10);

            ConjInst inst11 = new ConjInst();
            inst11.nemonico = "LDCH";
            inst11.codOp = "50";
            listInst.Add(inst11);

            ConjInst inst12 = new ConjInst();
            inst12.nemonico = "LDL";
            inst12.codOp = "08";
            listInst.Add(inst12);

            ConjInst inst13 = new ConjInst();
            inst13.nemonico = "LDX";
            inst13.codOp = "04";
            listInst.Add(inst13);

            ConjInst inst14 = new ConjInst();
            inst14.nemonico = "MUL";
            inst14.codOp = "20";
            listInst.Add(inst14);

            ConjInst inst15 = new ConjInst();
            inst15.nemonico = "OR";
            inst15.codOp = "44";
            listInst.Add(inst15);

            ConjInst inst16 = new ConjInst();
            inst16.nemonico = "RD";
            inst16.codOp = "D8";
            listInst.Add(inst16);

            ConjInst inst17 = new ConjInst();
            inst17.nemonico = "RSUB";
            inst17.codOp = "4C";
            listInst.Add(inst17);

            ConjInst inst18 = new ConjInst();
            inst18.nemonico = "STA";
            inst18.codOp = "0C";
            listInst.Add(inst18);

            ConjInst inst19 = new ConjInst();
            inst19.nemonico = "STCH";
            inst19.codOp = "54";
            listInst.Add(inst19);

            ConjInst inst20 = new ConjInst();
            inst20.nemonico = "STL";
            inst20.codOp = "14";
            listInst.Add(inst20);

            ConjInst inst21 = new ConjInst();
            inst21.nemonico = "STSW";
            inst21.codOp = "E8";
            listInst.Add(inst21);

            ConjInst inst22 = new ConjInst();
            inst22.nemonico = "STX";
            inst22.codOp = "10";
            listInst.Add(inst22);

            ConjInst inst23 = new ConjInst();
            inst23.nemonico = "SUB";
            inst23.codOp = "1C";
            listInst.Add(inst23);

            ConjInst inst24 = new ConjInst();
            inst24.nemonico = "TD";
            inst24.codOp = "E0";
            listInst.Add(inst24);

            ConjInst inst25 = new ConjInst();
            inst25.nemonico = "TIX";
            inst25.codOp = "2C";
            listInst.Add(inst25);

            ConjInst inst26 = new ConjInst();
            inst26.nemonico = "WD";
            inst26.codOp = "DC";
            listInst.Add(inst26);
        }

        ////COMO HACER EL EFECTO
    }

    public class tabSim
    {
        public string simbolo;
        public string direccion;
    }
}
