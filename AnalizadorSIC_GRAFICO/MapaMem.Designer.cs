namespace AnalizadorSIC_GRAFICO
{
    partial class MapaMem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewMapMem = new System.Windows.Forms.DataGridView();
            this.labelDirCar = new System.Windows.Forms.Label();
            this.labelTama = new System.Windows.Forms.Label();
            this.dataGridRegistros = new System.Windows.Forms.DataGridView();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.richTextBoxEjecucion = new System.Windows.Forms.RichTextBox();
            this.numericUpDownLineas = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMapMem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMapMem
            // 
            this.dataGridViewMapMem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMapMem.Location = new System.Drawing.Point(29, 25);
            this.dataGridViewMapMem.Name = "dataGridViewMapMem";
            this.dataGridViewMapMem.Size = new System.Drawing.Size(808, 439);
            this.dataGridViewMapMem.TabIndex = 0;
            // 
            // labelDirCar
            // 
            this.labelDirCar.AutoSize = true;
            this.labelDirCar.Location = new System.Drawing.Point(162, 9);
            this.labelDirCar.Name = "labelDirCar";
            this.labelDirCar.Size = new System.Drawing.Size(100, 13);
            this.labelDirCar.TabIndex = 1;
            this.labelDirCar.Text = "Direccion de carga:";
            // 
            // labelTama
            // 
            this.labelTama.AutoSize = true;
            this.labelTama.Location = new System.Drawing.Point(440, 9);
            this.labelTama.Name = "labelTama";
            this.labelTama.Size = new System.Drawing.Size(49, 13);
            this.labelTama.TabIndex = 2;
            this.labelTama.Text = "Tamaño:";
            // 
            // dataGridRegistros
            // 
            this.dataGridRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRegistros.Location = new System.Drawing.Point(925, 25);
            this.dataGridRegistros.Name = "dataGridRegistros";
            this.dataGridRegistros.Size = new System.Drawing.Size(213, 191);
            this.dataGridRegistros.TabIndex = 3;
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(888, 239);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(75, 23);
            this.btnEjecutar.TabIndex = 4;
            this.btnEjecutar.Text = "Ejecutar(F9)";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.eventoEjecutar);
            this.btnEjecutar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.presionaBotonEvento);
            // 
            // richTextBoxEjecucion
            // 
            this.richTextBoxEjecucion.Location = new System.Drawing.Point(846, 271);
            this.richTextBoxEjecucion.Name = "richTextBoxEjecucion";
            this.richTextBoxEjecucion.Size = new System.Drawing.Size(339, 193);
            this.richTextBoxEjecucion.TabIndex = 6;
            this.richTextBoxEjecucion.Text = "";
            // 
            // numericUpDownLineas
            // 
            this.numericUpDownLineas.Location = new System.Drawing.Point(1036, 239);
            this.numericUpDownLineas.Name = "numericUpDownLineas";
            this.numericUpDownLineas.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownLineas.TabIndex = 7;
            this.numericUpDownLineas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MapaMem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 476);
            this.Controls.Add(this.numericUpDownLineas);
            this.Controls.Add(this.richTextBoxEjecucion);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.dataGridRegistros);
            this.Controls.Add(this.labelTama);
            this.Controls.Add(this.labelDirCar);
            this.Controls.Add(this.dataGridViewMapMem);
            this.Name = "MapaMem";
            this.Text = "MapaMem";
            this.Load += new System.EventHandler(this.MapaMem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eventoBotonF9);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ejecutarEventoBtn);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMapMem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMapMem;
        private System.Windows.Forms.Label labelDirCar;
        private System.Windows.Forms.Label labelTama;
        private System.Windows.Forms.DataGridView dataGridRegistros;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.RichTextBox richTextBoxEjecucion;
        private System.Windows.Forms.NumericUpDown numericUpDownLineas;
    }
}