using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnalizadorSIC_GRAFICO
{
    public partial class MapaMem : Form
    {
        public string cpInicio;
        public string dirCarga;
        public string tamañoCod;
        public string cadRegObj;
        public List<string> listReg;
        public List<codigo> codigo;
        public string CP = "";
        public string A = "FFFFFF";
        public string X = "FFFFFF";
        public string L = "FFFFFF";
        public string SW = "FFFFFF";
        public string CC = "null";
        bool bandAccesoAMemoria = true;
        bool areaValida = true;
        int r = 0;

        public MapaMem()
        {
            InitializeComponent();
        }

        public void iniRenglones()
        {
            int i = 0;

            string numIni = RedondeaAbajo(cpInicio);
            string dirUlt = sumaHexadecimal(cpInicio, tamañoCod);
            string numLimite = RedondeaAbajo(dirUlt);
            int numRen = encuentraNumRen(numIni, numLimite);

            labelDirCar.Text = "Direccion de carga: " + dirCarga + " H";
            labelTama.Text = "Tamaño: " + tamañoCod+ " H";

            dataGridViewMapMem.Rows.Clear();
            dataGridViewMapMem.Refresh();

            string direccion = numIni;
            for (i = 0; i < numRen; i++)
            {
                dataGridViewMapMem.Rows.Add();
                dataGridViewMapMem.Rows[i].Cells[0].Value = direccion;
                direccion = sumaHexadecimal(sumaHexadecimal(direccion, "F"), "1");
            }

            for (int fila = 0; fila < dataGridViewMapMem.Rows.Count - 1; fila++)
            {
                for (int col = 1; col < dataGridViewMapMem.Rows[fila].Cells.Count; col++)
                {
                    dataGridViewMapMem.Rows[fila].Cells[col].Value = "FF";
                }
            }
        }

        public int convADecimal(string valorHexa)
        {
            return Convert.ToInt32(valorHexa, 16);
        }

        public int encuentraNumRen(string origen, string destino)
        {
            int ori = Convert.ToInt32(origen, 16);
            int des = Convert.ToInt32(destino, 16);

            int numRen = 1;

            for (int i = ori; i < des; i += 16)
            {
                numRen++;
            }

            r = 0;
            return numRen;

        }

        public void iniColumnas()
        {
            dataGridViewMapMem.RowHeadersVisible = false;
            dataGridViewMapMem.Columns.Clear();
            dataGridViewMapMem.Refresh();

            DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
            Columna1.HeaderText = " ";
            dataGridViewMapMem.Columns.Add(Columna1);

            DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
            Columna2.HeaderText = "0";
            dataGridViewMapMem.Columns.Add(Columna2);

            DataGridViewTextBoxColumn Columna3 = new DataGridViewTextBoxColumn();
            Columna3.HeaderText = "1";
            dataGridViewMapMem.Columns.Add(Columna3);

            DataGridViewTextBoxColumn Columna4 = new DataGridViewTextBoxColumn();
            Columna4.HeaderText = "2";
            dataGridViewMapMem.Columns.Add(Columna4);

            DataGridViewTextBoxColumn Columna5 = new DataGridViewTextBoxColumn();
            Columna5.HeaderText = "3";
            dataGridViewMapMem.Columns.Add(Columna5);

            DataGridViewTextBoxColumn Columna6 = new DataGridViewTextBoxColumn();
            Columna6.HeaderText = "4";
            dataGridViewMapMem.Columns.Add(Columna6);

            DataGridViewTextBoxColumn Columna7 = new DataGridViewTextBoxColumn();
            Columna7.HeaderText = "5";
            dataGridViewMapMem.Columns.Add(Columna7);

            DataGridViewTextBoxColumn Columna8 = new DataGridViewTextBoxColumn();
            Columna8.HeaderText = "6";
            dataGridViewMapMem.Columns.Add(Columna8);

            DataGridViewTextBoxColumn Columna9 = new DataGridViewTextBoxColumn();
            Columna9.HeaderText = "7";
            dataGridViewMapMem.Columns.Add(Columna9);

            DataGridViewTextBoxColumn Columna10 = new DataGridViewTextBoxColumn();
            Columna10.HeaderText = "8";
            dataGridViewMapMem.Columns.Add(Columna10);

            DataGridViewTextBoxColumn Columna11 = new DataGridViewTextBoxColumn();
            Columna11.HeaderText = "9";
            dataGridViewMapMem.Columns.Add(Columna11);

            DataGridViewTextBoxColumn Columna12 = new DataGridViewTextBoxColumn();
            Columna12.HeaderText = "A";
            dataGridViewMapMem.Columns.Add(Columna12);

            DataGridViewTextBoxColumn Columna13 = new DataGridViewTextBoxColumn();
            Columna13.HeaderText = "B";
            dataGridViewMapMem.Columns.Add(Columna13);

            DataGridViewTextBoxColumn Columna14 = new DataGridViewTextBoxColumn();
            Columna14.HeaderText = "C";
            dataGridViewMapMem.Columns.Add(Columna14);

            DataGridViewTextBoxColumn Columna15 = new DataGridViewTextBoxColumn();
            Columna15.HeaderText = "D";
            dataGridViewMapMem.Columns.Add(Columna15);

            DataGridViewTextBoxColumn Columna16 = new DataGridViewTextBoxColumn();
            Columna16.HeaderText = "E";
            dataGridViewMapMem.Columns.Add(Columna16);

            DataGridViewTextBoxColumn Columna17 = new DataGridViewTextBoxColumn();
            Columna17.HeaderText = "F";
            dataGridViewMapMem.Columns.Add(Columna17);
        }

        public string sumaHexadecimal(string valor1, string valor2)
        {
            string resultado = tranformaAHexa((Convert.ToInt32(valor1, 16) + Convert.ToInt32(valor2, 16)).ToString());
            return resultado;
        }

        public string obtenDireccionObjtivo(string valorHexa)
        {
           
            string bitMasSig = valorHexa.Substring(0, 1);
            int deci = Convert.ToInt32(bitMasSig, 16) - Convert.ToInt32("8", 16);
            string res = valorHexa;

            if (deci >= 0)
            {
                res = tranformaAHexa((Convert.ToInt32(valorHexa, 16) - Convert.ToInt32("8000", 16)).ToString());
                if(buscaContenido("X") != "FFFFFF")
                valorHexa = sumaHexadecimal(res, buscaContenido("X"));
                else
                    valorHexa = sumaHexadecimal(res, "0");

                richTextBoxEjecucion.Text += "\nModo de direccionamiento indexado ";

            }
            else
            {
                richTextBoxEjecucion.Text += "\nModo de direccionamiento directo ";
            }

            richTextBoxEjecucion.Text += "m = " + valorHexa;

           r = 0;
            return valorHexa;
        }

        public string RedondeaAbajo(string num)
        {
            int numeroMasAbajo = Convert.ToInt32(num, 16) - Convert.ToInt32(num, 16) % 16;
            r = 0;
            string numeroHexa = tranformaAHexa(numeroMasAbajo.ToString());
            r = 0;
            return numeroHexa;
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

        private void MapaMem_Load(object sender, EventArgs e)
        {
            richTextBoxEjecucion.Text = "";
            richTextBoxEjecucion.Text += "Lineas de ejecucion";
            //richTextBoxEjecucion.Clear();
            iniColumnas();
            iniRenglones();
            iniRegistros();
            listReg = new List<string>();
            cargador();
            CP = rellanaPalabra(dirCarga);
            iniColumnasReg();
            iniValoresReg();
            areaValida = true;
            bandAccesoAMemoria = true;


        }

        public void iniRegistros()
        {
            CP = "";
            A = "FFFFFF";
            X = "FFFFFF";
            L = "FFFFFF";
            SW = "FFFFFF";
            CC = "null";
        }

        public void iniColumnasReg()
        {
           dataGridRegistros.RowHeadersVisible = false;
           dataGridRegistros.Columns.Clear();
           dataGridRegistros.Rows.Clear();
           dataGridRegistros.Refresh();

           DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
           Columna1.HeaderText = "Registro";
           dataGridRegistros.Columns.Add(Columna1);

           DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
           Columna2.HeaderText = "Valor";
           dataGridRegistros.Columns.Add(Columna2);

           
           dataGridRegistros.Rows.Add();
           dataGridRegistros.Rows[0].Cells[0].Value = "(CP)";
            dataGridRegistros.Rows.Add();
            dataGridRegistros.Rows[1].Cells[0].Value = "(A)";
            dataGridRegistros.Rows.Add();
            dataGridRegistros.Rows[2].Cells[0].Value = "(X)";
            dataGridRegistros.Rows.Add();
            dataGridRegistros.Rows[3].Cells[0].Value = "(L)";
            dataGridRegistros.Rows.Add();
            dataGridRegistros.Rows[4].Cells[0].Value = "(CC)";
            dataGridRegistros.Rows.Add();
            dataGridRegistros.Rows[5].Cells[0].Value = "(SW)";
        }

        public List<string> acomodaRegistro(string cadReg)
        {
            List<string> cad = new List<string>();

            string[] arrCadReg = cadReg.Split('\n');
            string[] arrReg = { "" };
            int con = 0;
            foreach (string a in arrCadReg)
            {
                cad.Add(a);
            }
            cad.Remove(cad.Find(x => x.Length == 0));
            cad.Remove(cad.Find(x => x.Length == 0));
            r = 0;
            return cad;
        }

        public void cargador()
        {
            string cadReg = cadRegObj.Substring(1);
            listReg = acomodaRegistro(cadReg);

            string prueba="";

            r = 0;
            for(int i = 1; i<listReg.Count-1;i++)
            {
                r = 0;
                for (int fila = 0; fila < dataGridViewMapMem.Rows.Count - 1; fila++)
                {
                    r = 0;
                    for (int col = 1; col < dataGridViewMapMem.Rows[fila].Cells.Count; col++)
                    {
                        string v1 = dataGridViewMapMem.Rows[fila].Cells[0].Value.ToString();
                        string v2 = dataGridViewMapMem.Columns[col].HeaderText;
                        r = 0;
                        string valor = rellanaPalabra(sumaHexadecimal(v1,v2));
                        string colIni = listReg[i].Substring(1, 6);
                        string cal = rellanaPalabra(RedondeaAbajo(colIni));
                        r = 0;
                       
                        if ( valor == cal)
                        {
                            r = 0;
                            col = Convert.ToInt32(colIni.Substring(colIni.Length-1,1),16);
                            
                            for(int j = 9;j < listReg[i].Length;j+=2)
                            {

                                string algo = listReg[i].Substring(j, 2);
                                prueba += algo;
                                r = 0;
                                dataGridViewMapMem.Rows[fila].Cells[col+1].Value = listReg[i].Substring(j, 2);
                                col++;
                                if (col == 16)
                                {
                                    fila++;
                                    col = 0;
                                }

                            }
                            r = 0;
                        }
                        else
                        {
                            r = 0;
                        }
                    }
                }
            }
            
        }

        public void iniValoresReg()
        {
            //CP = rellanaPalabra(dirCarga);
            dataGridRegistros.Rows[0].Cells[1].Value = CP;
            dataGridRegistros.Rows[1].Cells[1].Value = A;
            dataGridRegistros.Rows[2].Cells[1].Value = X;
            dataGridRegistros.Rows[3].Cells[1].Value = L;
            dataGridRegistros.Rows[4].Cells[1].Value = CC;
            dataGridRegistros.Rows[5].Cells[1].Value = SW;


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

        private void eventoEjecutar(object sender, EventArgs e)
        {
            
            int lineAEje = Convert.ToInt32(numericUpDownLineas.Value.ToString());
            r = 0;
            //CP = dirCarga.Substring(0, 6);
            CP = CP.Substring(0, 6);

            


            areaValida =compruebaAreaValida();
            r = 0;
            for (int i = 0; i < lineAEje && areaValida && bandAccesoAMemoria; i++)
            {    

                string valorMem = buscaInstruccionEnMemoria(CP);
                richTextBoxEjecucion.Text += "\n\n" + valorMem;

                string ins = valorMem.Substring(0, 2);
                string m = valorMem.Substring(2, 4);
                CP = rellanaPalabra(sumaHexadecimal(CP, "3"));
                r = 0;
                
                m = obtenDireccionObjtivo(m);
               
                r = 0;
                
                encuentraEfecto(ins, m);
                //encuentraEfecto(ins, m);
                richTextBoxEjecucion.SelectionStart = richTextBoxEjecucion.Text.Length;
                richTextBoxEjecucion.ScrollToCaret();
                r = 0;
                actualizaRegistros();
                areaValida = compruebaAreaValida();
            }

            if (areaValida == false || bandAccesoAMemoria ==false)
            {
                MessageBox.Show("Ya no se puede ejecutar mas instrucciones");
                
            }


            
        }

        public bool compruebaAreaValida()
        {
            bool ban;

            int valoIni = convADecimal(cpInicio);
            string tamRed = tranformaAHexa((convADecimal(tamañoCod) - 3).ToString());
            r = 0;
            int valorFinal = convADecimal(sumaHexadecimal(cpInicio, tamRed));
            int valAct = convADecimal(CP);

            if (valAct >= valoIni && valAct <= valorFinal)
                ban = true;
            else
                ban = false;


            r = 0;

            return ban;

        }

        public void encuentraEfecto(string codOp, string m)
        {

            switch (codOp)
            {
                case "18":
                    richTextBoxEjecucion.Text += "\nADD m\n" + "A ← (A) + (m..m+2)";
                    A = rellanaPalabra(sumaHexadecimal(buscaContenido("A"), buscaContenido(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2"))));
                    richTextBoxEjecucion.Text += "\n" + "A ← " + A;
                    break;
                case "40":
                    richTextBoxEjecucion.Text += "\nAND m\n" + "A ← (A) & (m..m+2)";
                    A = hazAnd(buscaContenido("A"), buscaContenido(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2")));
                    richTextBoxEjecucion.Text += "\n" + "A ← " + A;
                    break;
                case "28":
                    richTextBoxEjecucion.Text += "\nCOMP m\n" + "(A) : (m..m+2)";
                    hazComparacion(buscaContenido("A"), buscaContenido(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2")));
                    richTextBoxEjecucion.Text += "\n" + "CC: " + CC;
                    break;
                case "24":
                    richTextBoxEjecucion.Text += "\nDIV m\n" + "A ← (A) / (m..m + 2)";
                    A = rellanaPalabra(hazDivicion(buscaContenido("A"), buscaContenido(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2"))));
                    richTextBoxEjecucion.Text += "\n" + "A ← " + A;
                    break;
                case "3C":
                    richTextBoxEjecucion.Text += "\nJ m\n" + "CP ← m";
                    CP = rellanaPalabra(m);
                    richTextBoxEjecucion.Text += "\n" + "CP ← " + CP;
                    break;
                case "30":
                    richTextBoxEjecucion.Text += "\nJEQ m\n" + "CP <- m si CC esta en '='";
                    if (CC == "=")
                    {
                        CP = rellanaPalabra(m);
                        richTextBoxEjecucion.Text += "\n" + "CP <- " + CP;
                    }
                    else
                    {
                        richTextBoxEjecucion.Text += "\n" + "No cumplio";
                        bandAccesoAMemoria = false;
                    }
                    break;
                case "34":
                    richTextBoxEjecucion.Text += "\nJGT m\n" + "CP <- m si CC esta en '>'";
                    if (CC == ">")
                    {
                        CP = rellanaPalabra(m);
                    }
                    else
                    {
                        richTextBoxEjecucion.Text += "\n" + "No cumplio";
                        bandAccesoAMemoria = false;
                    }
                    break;
                case "38":
                    richTextBoxEjecucion.Text += "\nJLT m\n" + "CP <- m si CC esta en '<'";
                    if (CC == "<")
                    {
                        CP = rellanaPalabra(m);
                        richTextBoxEjecucion.Text += "\n" + "CP <- " + CP;
                        r = 0;
                    }
                    else
                    {
                        richTextBoxEjecucion.Text += "\n" + "No cumplio";
                        bandAccesoAMemoria = false;
                    }
                    break;
                case "48":
                    richTextBoxEjecucion.Text += "\nJSUB m\n" + "L <- (CP);";
                    richTextBoxEjecucion.Text += " " + "CP <- m";
                    L = rellanaPalabra(buscaContenido(CP.Substring(2,4)));
                    richTextBoxEjecucion.Text += "\n" + "L <- "+ L + ";";
                    CP = rellanaPalabra(m);  
                    richTextBoxEjecucion.Text += " " + "CP <- "+CP;
                    break;
                case "00":
                    richTextBoxEjecucion.Text += "\nLDA m\n" + "A <- (m...m+2)";
                    A = buscaContenido(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2"));
                    richTextBoxEjecucion.Text += "\n" + "A <- "+A;
                    break;
                case "50":
                    richTextBoxEjecucion.Text += "\nLDCH m\n" + "A[+der] <- (m)";                   
                    A = asigBiteMasDer(buscaContenido(m));
                    richTextBoxEjecucion.Text += "\n" + "A[+der] <- " + A;
                    break;
                case "08":
                    richTextBoxEjecucion.Text += "\nLDL m\n" + "L <- (m...m+2)";
                    L = buscaContenido(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2"));
                    richTextBoxEjecucion.Text += "\n" + "L <- "+ L;
                    break;
                case "04":
                    richTextBoxEjecucion.Text += "\nLDX m\n" + "X <- (m...m+2)";
                    X = buscaContenido(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2"));
                    richTextBoxEjecucion.Text += "\n" + "X <- " + X;
                    break;
                case "20":
                    richTextBoxEjecucion.Text += "\nMUL m\n" + "A <-(A) * (m...m+2)";
                    A =rellanaPalabra(hazMuliplicacion(buscaContenido("A"), buscaContenido(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2"))));
                    richTextBoxEjecucion.Text += "\n" + "A <- "+A;
                    break;
                case "44":
                    richTextBoxEjecucion.Text += "\nOR m\n" + "A <-(A) | (m...m+2)";
                    A = hazOR(buscaContenido("A"), buscaContenido(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2")));
                    richTextBoxEjecucion.Text += "\n" + "A <- "+ A;
                    break;
                case "D8":
                    //A = asigBiteMasDer(buscaContenido(m));//DUDA POR EFECTO 
                    break;
                case "4C":
                    richTextBoxEjecucion.Text += "\nRSUB\n" + "CP <- (L)";
                    CP = rellanaPalabra(buscaContenido("L"));
                    richTextBoxEjecucion.Text += "\n" + "CP <- "+ L;
                    break;
                case "0C":///
                    richTextBoxEjecucion.Text += "\nSTA m\n" + "m...m+2 <- (A)";
                    asignaValorEnMem(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2"), buscaContenido("A"));
                    richTextBoxEjecucion.Text += "\n" + "m...m+2 <- "+ A ;
                    break;
                case "54"://COMPROBADA
                    richTextBoxEjecucion.Text += "\nSTCH m\n" + "m <- (A)[+der]";
                    asignaValorEnMem(m, buscaContenido("A"));
                    richTextBoxEjecucion.Text += "\n" + "m <- "+ A.Substring(A.Length - 2, 2);
                    break;
                case "14":
                    richTextBoxEjecucion.Text += "\nSTL m\n" + "m...m+2 <- (L)";
                    asignaValorEnMem(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2"), buscaContenido("L"));
                    richTextBoxEjecucion.Text += "\n" + "m...m+2 <- "+ L;
                    break;
                case "E8":
                    richTextBoxEjecucion.Text += "\nSTSW m\n" + "m...m+2 <- (SW)";
                    asignaValorEnMem(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2"), buscaContenido("SW"));
                    richTextBoxEjecucion.Text += "\n" + "m...m+2 <- "+ SW;
                    break;
                case "10":
                    richTextBoxEjecucion.Text += "\nSTX m\n" + "m...m+2 <- (X)";
                    asignaValorEnMem(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2"), buscaContenido("X"));
                    richTextBoxEjecucion.Text += "\n" + "m...m+2 <- "+X;
                    break;
                case "1C":
                    richTextBoxEjecucion.Text += "\nSUB m\n" + "A <-(A) - (m...m+2)";
                    A = rellanaPalabra(hazResta(buscaContenido("A"), buscaContenido(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2"))));
                    richTextBoxEjecucion.Text += "\n" + "A <-"+ A;
                    break;
                case "E0"://DUDA POR EFECTO
                    r = 0;
                    break;
                case "2C":
                    richTextBoxEjecucion.Text += "\nTIX m\n" + "X <- (X)+1";
                    richTextBoxEjecucion.Text += "\n" + "(X):(m..m+2)";
                    X =  rellanaPalabra(sumaHexadecimal(buscaContenido("X"), "1"));
                    richTextBoxEjecucion.Text += "\n" + "X <- "+ X;
                    hazComparacion(buscaContenido("X"), buscaContenido(m, sumaHexadecimal(m, "1"), sumaHexadecimal(m, "2")));
                    richTextBoxEjecucion.Text += "\n" + "CC: "+ CC;
                    break;
                case "DC"://DUDA POR EFECTO
                    r = 0;
                    break;

            }
            actualizaRegistros();
            r = 0;
        }

        public void actualizaRegistros()
        {
            iniColumnasReg();
            iniValoresReg();
        }

        public string buscaInstruccionEnMemoria(string dir)
        {
            string ren = RedondeaAbajo(dir);
            string m = "";
            bool bandEncontrado = false;
            bool bandTomaCelda = false;

            for (int fila = 0; fila < dataGridViewMapMem.Rows.Count - 1 && !bandEncontrado; fila++)
            {
                if (ren == dataGridViewMapMem.Rows[fila].Cells[0].Value.ToString())
                {
                    for (int col = 0; col < dataGridViewMapMem.Rows[fila].Cells.Count - 1 && !bandEncontrado; col++)
                    {
                        //dataGridViewMapMem.Rows[fila].Cells[col].Value;
                        string dirActual = rellanaPalabra(ren); 
                        r = 0;

                        if (dirActual == dir)
                        {
                            m = dataGridViewMapMem.Rows[fila].Cells[col + 1].Value.ToString();// + dataGridViewMapMem.Rows[fila].Cells[col + 2].Value.ToString() + dataGridViewMapMem.Rows[fila].Cells[col + 3].Value.ToString();                          
                            bandTomaCelda = true;
                            r = 0;
                        }
                        else
                            if (bandTomaCelda)
                            {
                                m += dataGridViewMapMem.Rows[fila].Cells[col + 1].Value.ToString();
                                if (m.Length == 6)
                                    bandEncontrado = true;
                                r = 0;
                            }
                        ren = sumaHexadecimal("1", ren);

                    }
                }
            }
            r = 0;
            return m; 
        }

        public string hazResta(string A, string m)
        {
            string res = tranformaAHexa((convADecimal(A) - convADecimal(m)).ToString());
            return res;
        }

        public void asignaValorEnMem(string m, string A)
        {
            //Buscar en memoria
            r = 0;
            string biteMasDer = A.Substring(A.Length - 2, 2);

            r = 0;
            bool bandEncon = false;

            for (int fila = 0; fila < dataGridViewMapMem.Rows.Count - 1 && !bandEncon; fila++)
            {
                for (int col = 0; col < dataGridViewMapMem.Rows[fila].Cells.Count-1 && !bandEncon; col++)
                {
                    string celAct = sumaHexadecimal(dataGridViewMapMem.Rows[fila].Cells[0].Value.ToString(), tranformaAHexa(col.ToString()));
                    r = 0;
                    if (m == celAct)
                    {
                        dataGridViewMapMem.Rows[fila].Cells[col + 1].Style.BackColor = Color.Aqua;
                        dataGridViewMapMem.Rows[fila].Cells[col + 1].Value = biteMasDer;
                        bandEncon = true;
                    }
                }
            }


        }

        public void asignaValorEnMem(string m,string m1, string m2, string Val)
        {
            //Buscar en memoria
            bool bandEncon = false;

            for (int fila = 0; fila < dataGridViewMapMem.Rows.Count - 1 && !bandEncon; fila++)
            {
                for (int col = 0; col < dataGridViewMapMem.Rows[fila].Cells.Count - 1 && !bandEncon; col++)
                {
                    string celAct = sumaHexadecimal(dataGridViewMapMem.Rows[fila].Cells[0].Value.ToString(), tranformaAHexa(col.ToString()));
                    r = 0;
                    if (m == celAct)
                    {
                        dataGridViewMapMem.Rows[fila].Cells[col + 1].Style.BackColor = Color.Aqua;
                        dataGridViewMapMem.Rows[fila].Cells[col + 1].Value = Val.Substring(0,2);
                       
                    }
                    if (m1 == celAct)
                    {
                        dataGridViewMapMem.Rows[fila].Cells[col + 1].Style.BackColor = Color.Aqua;
                        dataGridViewMapMem.Rows[fila].Cells[col + 1].Value = Val.Substring(2, 2);

                    }
                    if (m2 == celAct)
                    {
                        dataGridViewMapMem.Rows[fila].Cells[col + 1].Style.BackColor = Color.Aqua;
                        dataGridViewMapMem.Rows[fila].Cells[col + 1].Value = Val.Substring(4, 2);
                        bandEncon = true;

                    }

                }
            }

        }

        public string hazOR(string A, string m)
        {
            string cadFinal = "";
            /*string bin1 = Convert.ToString(convADecimal(A), 2);
            int entero = convADecimal(m);
            string bin2 = Convert.ToString(entero, 2);
            string cadFinal = "";
            */
            try
            {
            for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] == m[i])
                        cadFinal += A[i];
                    else
                        if (A[i] != '0')
                        cadFinal += A[i];
                    else
                            if (m[i] != '0')
                        cadFinal += m[i];
                    else
                        cadFinal += "0";


                }
            }
            catch (Exception a)
            {
                cadFinal = A;
            }


            return cadFinal;
        }

        public string hazMuliplicacion(string A, string m)
        {
           
            string res =tranformaAHexa((convADecimal(A) * convADecimal(m)).ToString());
            r = 0;

            return res;
        }

        public string asigBiteMasDer(string m)
        {
            string ATem = A;
            
            ATem = ATem.Remove(ATem.Length - 2,2);
            ATem += m;

            return ATem;
        }

        public string hazDivicion(string A, string m)
        {
            int div1 = convADecimal(A);
            int div2 = convADecimal(m);
            //int div2 = convADecimal("10");
            string res = "";

            if(div2>0)
             res = tranformaAHexa((div1 / div2).ToString());

            if(res == "")
            {
                bandAccesoAMemoria = false;
            }

            r = 0;
            return res;
        }

        public void hazComparacion(string A, string m)
        {
            r = 0;
            if(A == m)
            {
                CC = "=";
            }
            else
            if(convADecimal(A) > convADecimal(m))
            {
                CC = ">";
            }
            else
            {
                CC = "<";
            }
            r = 0;
            richTextBoxEjecucion.Text += "\n" + A + ":" + m; 
        }

        public string hazAnd(string A, string m)///////DUDA
        {
            string cadFinal ="";

            /*string bin1 = Convert.ToString(convADecimal(A), 2);
            int entero = convADecimal(m);
            string bin2 = Convert.ToString(entero, 2);// + Convert.ToString(convADecimal(m.Substring(2, 4)), 2)+Convert.ToString(convADecimal(m.Substring(4, 6)), 2);
            */
            r = 0;
            for (int i = 0; i < A.Length;i++)
            {
                if (A[i] == m[i])
                    cadFinal += A[i];
                else
                    cadFinal += "0";
            }

            return cadFinal;
           
        }

        public string buscaContenido(string valorABuscar)
        {
            string valFinl ="";

            switch(valorABuscar)
            {
                case "A":
                    valFinl = A;
                    break;
                case "X":
                    valFinl = X;
                    break;
                case "L":
                    valFinl = L;
                    break;
                case "CP":
                    valFinl = CP;
                    break;
                case "SW":
                    valFinl = SW;
                    break;
                default:
                    valFinl = buscaEnMemoria(valorABuscar);
                    break;
                
            }
            return valFinl;

        }

        public string buscaEnMemoria(string m)
        {
            string res = "";
            bool bandEncon = false;

            for (int fila = 0; fila < dataGridViewMapMem.Rows.Count - 1 && !bandEncon; fila++)
            {
                for (int col = 0; col < dataGridViewMapMem.Rows[fila].Cells.Count -1 && !bandEncon; col++)
                {
                    string celAct = sumaHexadecimal(dataGridViewMapMem.Rows[fila].Cells[0].Value.ToString(), tranformaAHexa(col.ToString()));
                    r = 0;
                    if (m == celAct)
                    {
                        res += dataGridViewMapMem.Rows[fila].Cells[col + 1].Value.ToString();
                        bandEncon = true;
                    }
                }
            }

            if (res == "")
            {
                res = "0";
                bandAccesoAMemoria = false;
            }

            r = 0;
            return res;
        }

        public string buscaContenido(string m, string m1,string m2)
        {
            string res = "";           
            bool bandEncon = false;

            for (int fila = 0; fila < dataGridViewMapMem.Rows.Count - 1 && !bandEncon; fila++)
            {
                for (int col = 0; col < dataGridViewMapMem.Rows[fila].Cells.Count-1 && !bandEncon; col++)
                {
                    string celAct = sumaHexadecimal(dataGridViewMapMem.Rows[fila].Cells[0].Value.ToString(),tranformaAHexa(col.ToString()));
                    r = 0;
                    if(m == celAct)
                    {
                        res += dataGridViewMapMem.Rows[fila].Cells[col+1].Value.ToString();
                    }
                    if(m1 == celAct)
                    {
                        res += dataGridViewMapMem.Rows[fila].Cells[col+1].Value.ToString();
                    }
                    if (m2 == celAct)
                    {
                        res += dataGridViewMapMem.Rows[fila].Cells[col+1].Value.ToString();
                        bandEncon = true;
                    }
                    
                }
            }

            r = 0;
            if(res =="")
            {
                res = "0";
                bandAccesoAMemoria = false;
            }

            return res;
        }

        private void presionaBotonEvento(object sender, KeyEventArgs e)
        {
            r = 0;
            if(e.KeyCode == Keys.F9)
            {
                r = 0;
                eventoEjecutar(this, null);
            }            
        }

        private void eventoBotonF9(object sender, KeyEventArgs e)
        {
            r = 0;
            if (e.KeyCode == Keys.F9)
            {
                r = 0;
                eventoEjecutar(this, null);
            }
        }

        private void ejecutarEventoBtn(object sender, KeyPressEventArgs e)
        {
            r = 0;
            if (e.KeyChar ==   Convert.ToChar(Keys.F9))
            {
                r = 0;
                eventoEjecutar(this, null);
            }
        }
    }
}
