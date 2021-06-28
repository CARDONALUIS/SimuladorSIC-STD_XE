namespace AnalizadorSIC_GRAFICO
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapaDeMemoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridCodigo = new System.Windows.Forms.DataGridView();
            this.dataGridTabSim = new System.Windows.Forms.DataGridView();
            this.labelErrores = new System.Windows.Forms.Label();
            this.labelRegistros = new System.Windows.Forms.Label();
            this.richTextBoxCodigo = new System.Windows.Forms.RichTextBox();
            this.richTextBoxErrores = new System.Windows.Forms.RichTextBox();
            this.richTextBoxRegistros = new System.Windows.Forms.RichTextBox();
            this.labelNomArch = new System.Windows.Forms.Label();
            this.LineNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.labelTabSim = new System.Windows.Forms.Label();
            this.guardaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabSim)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.mapaDeMemoriaToolStripMenuItem,
            this.analizaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1314, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardaToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.AbrirCodigo);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar como";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // mapaDeMemoriaToolStripMenuItem
            // 
            this.mapaDeMemoriaToolStripMenuItem.Name = "mapaDeMemoriaToolStripMenuItem";
            this.mapaDeMemoriaToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.mapaDeMemoriaToolStripMenuItem.Text = "MapaDeMemoria";
            this.mapaDeMemoriaToolStripMenuItem.Click += new System.EventHandler(this.mapaMemoriaEvento);
            // 
            // analizaToolStripMenuItem
            // 
            this.analizaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Desktop;
            this.analizaToolStripMenuItem.Name = "analizaToolStripMenuItem";
            this.analizaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.analizaToolStripMenuItem.Text = "Analiza!!!";
            this.analizaToolStripMenuItem.Click += new System.EventHandler(this.BotonAnaliza);
            // 
            // dataGridCodigo
            // 
            this.dataGridCodigo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCodigo.Location = new System.Drawing.Point(368, 27);
            this.dataGridCodigo.Name = "dataGridCodigo";
            this.dataGridCodigo.ReadOnly = true;
            this.dataGridCodigo.Size = new System.Drawing.Size(607, 492);
            this.dataGridCodigo.TabIndex = 1;
            // 
            // dataGridTabSim
            // 
            this.dataGridTabSim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTabSim.Location = new System.Drawing.Point(1067, 47);
            this.dataGridTabSim.Name = "dataGridTabSim";
            this.dataGridTabSim.ReadOnly = true;
            this.dataGridTabSim.Size = new System.Drawing.Size(203, 174);
            this.dataGridTabSim.TabIndex = 2;
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrores.Location = new System.Drawing.Point(989, 204);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(61, 20);
            this.labelErrores.TabIndex = 3;
            this.labelErrores.Text = "Errores";
            // 
            // labelRegistros
            // 
            this.labelRegistros.AutoSize = true;
            this.labelRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegistros.Location = new System.Drawing.Point(989, 342);
            this.labelRegistros.Name = "labelRegistros";
            this.labelRegistros.Size = new System.Drawing.Size(77, 20);
            this.labelRegistros.TabIndex = 5;
            this.labelRegistros.Text = "Registros";
            // 
            // richTextBoxCodigo
            // 
            this.richTextBoxCodigo.Location = new System.Drawing.Point(44, 27);
            this.richTextBoxCodigo.Name = "richTextBoxCodigo";
            this.richTextBoxCodigo.Size = new System.Drawing.Size(285, 492);
            this.richTextBoxCodigo.TabIndex = 8;
            this.richTextBoxCodigo.Text = "";
            this.richTextBoxCodigo.SelectionChanged += new System.EventHandler(this.richTextBoxCodigo_SelectionChanged);
            this.richTextBoxCodigo.VScroll += new System.EventHandler(this.richTextBoxCodigo_VScroll);
            this.richTextBoxCodigo.FontChanged += new System.EventHandler(this.richTextBoxCodigo_FontChanged);
            this.richTextBoxCodigo.TextChanged += new System.EventHandler(this.richTextBoxCodigo_TextChanged);
            // 
            // richTextBoxErrores
            // 
            this.richTextBoxErrores.Location = new System.Drawing.Point(993, 227);
            this.richTextBoxErrores.Name = "richTextBoxErrores";
            this.richTextBoxErrores.ReadOnly = true;
            this.richTextBoxErrores.Size = new System.Drawing.Size(309, 96);
            this.richTextBoxErrores.TabIndex = 9;
            this.richTextBoxErrores.Text = "";
            // 
            // richTextBoxRegistros
            // 
            this.richTextBoxRegistros.Location = new System.Drawing.Point(993, 365);
            this.richTextBoxRegistros.Name = "richTextBoxRegistros";
            this.richTextBoxRegistros.ReadOnly = true;
            this.richTextBoxRegistros.Size = new System.Drawing.Size(309, 154);
            this.richTextBoxRegistros.TabIndex = 10;
            this.richTextBoxRegistros.Text = "";
            // 
            // labelNomArch
            // 
            this.labelNomArch.AutoSize = true;
            this.labelNomArch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomArch.Location = new System.Drawing.Point(514, 4);
            this.labelNomArch.Name = "labelNomArch";
            this.labelNomArch.Size = new System.Drawing.Size(69, 20);
            this.labelNomArch.TabIndex = 11;
            this.labelNomArch.Text = "Archivo: ";
            // 
            // LineNumberTextBox
            // 
            this.LineNumberTextBox.Location = new System.Drawing.Point(12, 27);
            this.LineNumberTextBox.Name = "LineNumberTextBox";
            this.LineNumberTextBox.Size = new System.Drawing.Size(32, 492);
            this.LineNumberTextBox.TabIndex = 12;
            this.LineNumberTextBox.Text = "";
            this.LineNumberTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LineNumberTextBox_MouseDown);
            // 
            // labelTabSim
            // 
            this.labelTabSim.AutoSize = true;
            this.labelTabSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTabSim.Location = new System.Drawing.Point(1131, 24);
            this.labelTabSim.Name = "labelTabSim";
            this.labelTabSim.Size = new System.Drawing.Size(69, 20);
            this.labelTabSim.TabIndex = 13;
            this.labelTabSim.Text = "TABSIM";
            // 
            // guardaToolStripMenuItem
            // 
            this.guardaToolStripMenuItem.Name = "guardaToolStripMenuItem";
            this.guardaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardaToolStripMenuItem.Text = "Guardar";
            this.guardaToolStripMenuItem.Click += new System.EventHandler(this.guardaArchivo);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarToolStripMenuItem.Text = "Salir";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarArchivos);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 531);
            this.Controls.Add(this.labelTabSim);
            this.Controls.Add(this.LineNumberTextBox);
            this.Controls.Add(this.labelNomArch);
            this.Controls.Add(this.richTextBoxRegistros);
            this.Controls.Add(this.richTextBoxErrores);
            this.Controls.Add(this.richTextBoxCodigo);
            this.Controls.Add(this.labelRegistros);
            this.Controls.Add(this.labelErrores);
            this.Controls.Add(this.dataGridTabSim);
            this.Controls.Add(this.dataGridCodigo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "AnalizadoSIC";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabSim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizaToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridCodigo;
        public System.Windows.Forms.DataGridView dataGridTabSim;
        private System.Windows.Forms.Label labelErrores;
        private System.Windows.Forms.Label labelRegistros;
        private System.Windows.Forms.RichTextBox richTextBoxCodigo;
        private System.Windows.Forms.RichTextBox richTextBoxErrores;
        private System.Windows.Forms.RichTextBox richTextBoxRegistros;
        private System.Windows.Forms.Label labelNomArch;
        private System.Windows.Forms.RichTextBox LineNumberTextBox;
        private System.Windows.Forms.Label labelTabSim;
        private System.Windows.Forms.ToolStripMenuItem mapaDeMemoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
    }
}

