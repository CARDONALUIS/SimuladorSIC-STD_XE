using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.IO;
using System.Linq;
using System.Windows.Forms;



namespace AnalizadorSIC_GRAFICO
{
    public partial class Form1 : Form
    {
        int r;
        string nombreCodigo;
        FileStream archivoActual;
        string cadCompCodig;
        bool bandAbrir = false;
        MapaMem vMapMam;
        visitorSIC_STD visitGlobal;
        visitorSIC_XE visitGlobalXE;

        public Form1()
        {
            InitializeComponent();

            iniciaCabezerasCodigo();
            iniciaCabezerasTabSim();

            LineNumberTextBox.Font = richTextBoxCodigo.Font;
            richTextBoxCodigo.Select();
            AddLineNumbers();
            vMapMam = new MapaMem();
            
        }

        private void BotonAnaliza(object sender, EventArgs e)
        {
            try
            {
                archivoActual = File.Open(nombreCodigo, FileMode.Open, FileAccess.Read);

                r = 0;
                FileStream arError = new FileStream("Errores.t", FileMode.Create);
                r = 0;
                if (archivoActual != null)
                {


                    string ext = Path.GetExtension(archivoActual.Name);

                    if (ext == ".s")
                    {
                        MessageBox.Show("Arquitectura SIC-STD");
                        AntlrInputStream input = new AntlrInputStream(archivoActual);
                        GramaticaSIC_STDLexer lexer = new GramaticaSIC_STDLexer(input);
                        CommonTokenStream token = new CommonTokenStream(lexer);
                        GramaticaSIC_STDParser parser = new GramaticaSIC_STDParser(token);




                        errores error = new errores();
                        parser.RemoveErrorListeners();
                        parser.AddErrorListener(error);

                        IParseTree tree = parser.programa();

                        


                        r = 0;
                        arError.Close();
                        using (BinaryWriter bw = new BinaryWriter(File.Open(arError.Name, FileMode.Open)))
                        {
                            r = 0;
                            bw.Write(error.cad);
                        }
                        r = 0;
                        visitorSIC_STD visitor = new visitorSIC_STD(error.lineaErrores, archivoActual);

                        visitGlobal = visitor;

                        visitor.Visit(tree);

                        agregaValoresACodigo(visitor);
                        agregaValoresATabSim(visitor);
                        agregaLineasErrorRich();
                        //richTextBoxErrores.Text = error.cad;

                        r = 0;
                        richTextBoxRegistros.Text = visitor.cadRegisGlobal;
                    }
                    else
                    if (ext == ".x")
                    {
                        MessageBox.Show("Arquitectura SIC-XE");
                        AntlrInputStream input = new AntlrInputStream(archivoActual);
                        GramaticaSIC_XELexer lexer = new GramaticaSIC_XELexer(input);
                        CommonTokenStream token = new CommonTokenStream(lexer);
                        GramaticaSIC_XEParser parser = new GramaticaSIC_XEParser(token);
                        IParseTree tree = parser.programa();

                        //MessageBox.Show(tree.ToStringTree(parser));
                        arError.Close();
                        
                        visitorSIC_XE visitorXE = new visitorSIC_XE(archivoActual);

                        visitorXE.Visit(tree);

                        visitGlobalXE = visitorXE;

                        agregaValoresACodigo(visitorXE);
                        agregaValoresATabSim(visitorXE);
                        agregaLineasErrorRichXE();
                        richTextBoxRegistros.Clear();
                        richTextBoxRegistros.Text = visitorXE.cadRegisGlobal;
                    }
                    /*AntlrInputStream input = new AntlrInputStream(archivoActual);
                    GramaticaSIC_STDLexer lexer = new GramaticaSIC_STDLexer(input);
                    CommonTokenStream token = new CommonTokenStream(lexer);
                    GramaticaSIC_STDParser parser = new GramaticaSIC_STDParser(token);
                    



                    errores error = new errores();
                    parser.RemoveErrorListeners();
                    parser.AddErrorListener(error);

                    IParseTree tree = parser.programa();

                    

                    
                    r = 0;
                    arError.Close();
                    using (BinaryWriter bw = new BinaryWriter(File.Open(arError.Name, FileMode.Open)))
                    {
                        r = 0;
                        bw.Write(error.cad);
                    }
                    r = 0;
                    visitorSIC_STD visitor = new visitorSIC_STD(error.lineaErrores, archivoActual);

                    visitGlobal = visitor;

                    visitor.Visit(tree);

                    agregaValoresACodigo(visitor);
                    agregaValoresATabSim(visitor);
                    agregaLineasErrorRich();
                    //richTextBoxErrores.Text = error.cad;

                    r = 0;
                    richTextBoxRegistros.Text = visitor.cadRegisGlobal;*/
                }
                archivoActual.Close();

                bandAbrir = false;
            }
            catch (Exception a)
            {
                MessageBox.Show("Hubo un problema al analizar el programa");
            } 
        }

        public void agregaLineasErrorRich()
        {
            r = 0;
            richTextBoxErrores.Clear();

            for (int i = 0; i <visitGlobal.lineasConError.Count;i++)
            {
                    richTextBoxErrores.Text += "Error en la linea " + visitGlobal.lineasConError[i]+"\n";
            }

            r = 0;
            for(int j =0; j <visitGlobal.lineasprogramaCompleto.Count;j++)
            {
                r = 0;
                if(visitGlobal.lineasprogramaCompleto[j].tipoError == 2 || visitGlobal.lineasprogramaCompleto[j].tipoError == 1)
                    richTextBoxErrores.Text += "Error en la linea " + (j+1)+"\n";
            }
    
        }

        public void agregaLineasErrorRichXE()
        {
            r = 0;
            richTextBoxErrores.Clear();

            for (int i = 0; i < visitGlobalXE.lineasConError.Count; i++)
            {
                richTextBoxErrores.Text += "Error en la linea " + visitGlobalXE.lineasConError[i] + "\n";
            }

            r = 0;
            for (int j = 0; j < visitGlobalXE.lineasprogramaCompleto.Count; j++)
            {
                r = 0;
                if (visitGlobalXE.lineasprogramaCompleto[j].tipoError == 2 || visitGlobalXE.lineasprogramaCompleto[j].tipoError == 1)
                    richTextBoxErrores.Text += "Error en la linea " + (j + 1) + "\n";
            }


        }


        public void agregaValoresACodigo(visitorSIC_XE visit)
        {
            int i = 0;

            dataGridCodigo.Rows.Clear();
            dataGridCodigo.Refresh();



            foreach (codigo a in visit.lineasprogramaCompleto)
            {
                dataGridCodigo.Rows.Add();
                if (!a.esInsError)
                {
                    dataGridCodigo.Rows[i].Cells[0].Value = a.linea;
                    dataGridCodigo.Rows[i].Cells[1].Value = a.CP;
                    dataGridCodigo.Rows[i].Cells[2].Value = a.etiqueta;
                    dataGridCodigo.Rows[i].Cells[3].Value = a.instruccion;
                    dataGridCodigo.Rows[i].Cells[4].Value = a.operando;
                    dataGridCodigo.Rows[i].Cells[5].Value = a.codObj;
                    if (a.tipoError == 2 || a.tipoError == 1)
                        dataGridCodigo.Rows[i].Cells[5].Value += " ERROR";
                    if(a.esRelocalisable)
                        dataGridCodigo.Rows[i].Cells[5].Value += " *";


                }
                else
                {
                    /*dataGridCodigo.Rows[i].Cells[0].Value = a.linea;
                    dataGridCodigo.Rows[i].Cells[1].Value = a.CP;
                    dataGridCodigo.Rows[i].Cells[2].Value = "ERROR";*/
                    dataGridCodigo.Rows[i].Cells[0].Value = a.linea;
                    dataGridCodigo.Rows[i].Cells[1].Value = a.CP;
                    dataGridCodigo.Rows[i].Cells[2].Value = a.etiqueta;
                    dataGridCodigo.Rows[i].Cells[3].Value = a.instruccion;
                    dataGridCodigo.Rows[i].Cells[4].Value = a.operando;
                    dataGridCodigo.Rows[i].Cells[5].Value = "ERROR";
                    if (a.tipoError == 2 || a.tipoError == 1)
                        dataGridCodigo.Rows[i].Cells[5].Value += " ERROR";

                }
                i++;

            }

        }



        public void agregaValoresACodigo(visitorSIC_STD visit)
        {
            int i = 0;

            dataGridCodigo.Rows.Clear();
            dataGridCodigo.Refresh();

            

            foreach (codigo a in visit.lineasprogramaCompleto)
            {
                dataGridCodigo.Rows.Add();
                if (!a.esInsError)
                {
                    dataGridCodigo.Rows[i].Cells[0].Value = a.linea;
                    dataGridCodigo.Rows[i].Cells[1].Value = a.CP;
                    dataGridCodigo.Rows[i].Cells[2].Value = a.etiqueta;
                    dataGridCodigo.Rows[i].Cells[3].Value = a.instruccion;
                    dataGridCodigo.Rows[i].Cells[4].Value = a.operando;
                    dataGridCodigo.Rows[i].Cells[5].Value = a.codObj;
                    if (a.tipoError == 2 || a.tipoError == 1)
                        dataGridCodigo.Rows[i].Cells[5].Value += " ERROR";
                    
                }
                else
                {
                    /*dataGridCodigo.Rows[i].Cells[0].Value = a.linea;
                    dataGridCodigo.Rows[i].Cells[1].Value = a.CP;
                    dataGridCodigo.Rows[i].Cells[2].Value = "ERROR";*/
                    dataGridCodigo.Rows[i].Cells[0].Value = a.linea;
                    dataGridCodigo.Rows[i].Cells[1].Value = a.CP;
                    dataGridCodigo.Rows[i].Cells[2].Value = a.etiqueta;
                    dataGridCodigo.Rows[i].Cells[3].Value = a.instruccion;
                    dataGridCodigo.Rows[i].Cells[4].Value = a.operando;
                    dataGridCodigo.Rows[i].Cells[5].Value = "ERROR";
                    if (a.tipoError == 2 || a.tipoError == 1)
                        dataGridCodigo.Rows[i].Cells[5].Value += " ERROR";

                }
                i++;

            }

        }

        public void agregaValoresATabSim(visitorSIC_STD visit)
        {
            int i = 0;

            dataGridTabSim.Rows.Clear();
            dataGridTabSim.Refresh();

            foreach (tabSim a in visit.simDir)
            {
                dataGridTabSim.Rows.Add();
                dataGridTabSim.Rows[i].Cells[0].Value = a.simbolo;
                dataGridTabSim.Rows[i].Cells[1].Value = a.direccion;
                i++;

            }
        }

        public void agregaValoresATabSim(visitorSIC_XE visit)
        {
            int i = 0;

            dataGridTabSim.Rows.Clear();
            dataGridTabSim.Refresh();

            foreach (tabSim a in visit.simDir)
            {
                dataGridTabSim.Rows.Add();
                dataGridTabSim.Rows[i].Cells[0].Value = a.simbolo;
                dataGridTabSim.Rows[i].Cells[1].Value = a.direccion;
                i++;

            }
        }




        private void AbrirCodigo(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter="SIC/SICXE Files (*.s,*.x)|*.s;*.x"
            };

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                nombreCodigo = abrir.FileName;
                FileInfo fi = new FileInfo(nombreCodigo);
                labelNomArch.Text = "Archivo : " + fi.Name;

                archivoActual = File.Open(nombreCodigo, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(archivoActual);
                cadCompCodig = new string(br.ReadChars((int)archivoActual.Length));
                archivoActual.Close();
                r = 0;
                richTextBoxCodigo.Text = cadCompCodig; 
            }
            bandAbrir = true;
        }

        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1    
            int First_Index = richTextBoxCodigo.GetCharIndexFromPosition(pt);
            int First_Line = richTextBoxCodigo.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1    
            int Last_Index = richTextBoxCodigo.GetCharIndexFromPosition(pt);
            int Last_Line = richTextBoxCodigo.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line; i <= Last_Line + 2; i++)
            {
                LineNumberTextBox.Text += i + 1 + "\n";
            }
        }

        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1    
            int line = richTextBoxCodigo.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)richTextBoxCodigo.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)richTextBoxCodigo.Font.Size;
            }
            else
            {
                w = 50 + (int)richTextBoxCodigo.Font.Size;
            }

            return w;
        }
        

        public void iniciaCabezerasCodigo()
        {
            

            dataGridCodigo.RowHeadersVisible = false;

            DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
            Columna1.HeaderText = "No. de linea";
            dataGridCodigo.Columns.Add(Columna1);

            DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
            Columna2.HeaderText = "CP";
            dataGridCodigo.Columns.Add(Columna2);

            DataGridViewTextBoxColumn Columna3 = new DataGridViewTextBoxColumn();
            Columna3.HeaderText = "Etiqueta";
            dataGridCodigo.Columns.Add(Columna3);

            DataGridViewTextBoxColumn Columna4 = new DataGridViewTextBoxColumn();
            Columna4.HeaderText = "Instruccion";
            dataGridCodigo.Columns.Add(Columna4);

            DataGridViewTextBoxColumn Columna5 = new DataGridViewTextBoxColumn();
            Columna5.HeaderText = "Operando";
            dataGridCodigo.Columns.Add(Columna5);

            DataGridViewTextBoxColumn Columna6 = new DataGridViewTextBoxColumn();
            Columna6.HeaderText = "Codigo Objeto";
            dataGridCodigo.Columns.Add(Columna6);

        }

        public void iniciaCabezerasTabSim()
        {
            dataGridTabSim.Rows.Clear();

            dataGridTabSim.RowHeadersVisible = false;

            DataGridViewTextBoxColumn Columna1 = new DataGridViewTextBoxColumn();
            Columna1.HeaderText = "Simbolo";
            dataGridTabSim.Columns.Add(Columna1);

            DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
            Columna2.HeaderText = "Direccion";
            dataGridTabSim.Columns.Add(Columna2);
            
        }

        private void richTextBoxCodigo_TextChanged(object sender, EventArgs e)
        {
            if (richTextBoxCodigo.Text == "")
            {
                AddLineNumbers();
            }
        }

        private void richTextBoxCodigo_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = richTextBoxCodigo.GetPositionFromCharIndex(richTextBoxCodigo.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void richTextBoxCodigo_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }

        private void richTextBoxCodigo_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBoxCodigo.Font;
            richTextBoxCodigo.Select();
            AddLineNumbers();
        }

        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            richTextBoxCodigo.Select();
            LineNumberTextBox.DeselectAll();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No olvides agregar extencion");

            SaveFileDialog saveDialog = new SaveFileDialog();
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                nombreCodigo = saveDialog.FileName;
                archivoActual = new FileStream(nombreCodigo, FileMode.Create);
                archivoActual.Close();
                FileInfo fi = new FileInfo(nombreCodigo);
                labelNomArch.Text = "Archivo:"+ fi.Name;

                using (BinaryWriter bw = new BinaryWriter(File.Open(archivoActual.Name, FileMode.Open)))
                {

                    bw.Write(richTextBoxCodigo.Text.ToCharArray());


                }

                r = 0;
            }
        }

        private void mapaMemoriaEvento(object sender, EventArgs e)
        {
            if (archivoActual != null)
            {
                if(visitGlobal!=null)
                {
                    vMapMam.cpInicio = visitGlobal.CPInicio;
                    vMapMam.dirCarga = visitGlobal.DirCarga;
                    vMapMam.tamañoCod = visitGlobal.tamCod;
                    vMapMam.cadRegObj = visitGlobal.cadRegisGlobal;
                    vMapMam.codigo = visitGlobal.lineasprogramaCompleto;
                    vMapMam.ShowDialog();
                }
                else
                    MessageBox.Show("Analiza primero");
            }
            else
            {
                MessageBox.Show("No hay archivo abierto");
            }
        }

        private void guardaArchivo(object sender, EventArgs e)
        {
            if (archivoActual != null)
            {
                nombreCodigo = archivoActual.Name;
                archivoActual = new FileStream(nombreCodigo, FileMode.Create);
                archivoActual.Close();
                FileInfo fi = new FileInfo(nombreCodigo);
                labelNomArch.Text = "Archivo:" + fi.Name;

                string final = richTextBoxCodigo.Text;
                r = 0;
                char[] arrFinal = final.ToCharArray();
                archivoActual.Close();
                using (BinaryWriter bw = new BinaryWriter(File.Open(archivoActual.Name, FileMode.Open)))
                {
                    
                    bw.Write(arrFinal);

                    
                }


            }
            else
            {
                MessageBox.Show("Abre primero un archivo");
            }

        }

        private void cerrarArchivos(object sender, EventArgs e)
        {
            richTextBoxCodigo.Clear();
            archivoActual.Close();
            dataGridCodigo.Rows.Clear();
            dataGridTabSim.Rows.Clear();
            richTextBoxErrores.Clear();
            richTextBoxRegistros.Clear();
            
            
         
        }
    }
}
